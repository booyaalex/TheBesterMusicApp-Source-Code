using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBesterMusicApp
{
    public class Database
    {
        private SqliteConnection Connection { get; set; }
        public static async Task<Database> Create()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=Data.db");
            await connection.OpenAsync();

            Database db = new Database();
            db.Connection = connection;

            await db.CreateDatabase();
            return db;
        }
        private async Task CreateDatabase()
        {
            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = @"CREATE TABLE IF NOT EXISTS tracks (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                title TEXT NOT NULL,
                artist TEXT,
                album TEXT,
                path TEXT UNIQUE NOT NULL,
                track INTEGER,
                track_count INTEGER,
                year INTEGER,
                duration FLOAT,
                play_count INTEGER,
                rating FLOAT
                )";

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task GetTracksFromFiles(List<Track> tracks)
        {
            tracks.Clear();
            string[] dirs = Directory.GetFiles(Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\") + @"Music", "*.mp3", SearchOption.AllDirectories);
            Console.WriteLine("Music Files Found: {0}", dirs.Length);
            foreach (string dir in dirs)
            {
                TagLib.File tagFile = TagLib.File.Create(dir);

                Track track = new Track()
                {
                    artist = tagFile.Tag.FirstPerformer,
                    album = tagFile.Tag.Album,
                    duration = tagFile.Properties.Duration.TotalSeconds,
                    path = dir,
                    title = tagFile.Tag.Title,
                    track = (int)tagFile.Tag.Track,
                    track_count = (int)tagFile.Tag.TrackCount,
                    year = (int)tagFile.Tag.Year
                };
                tracks.Add(track);
            }
            await InsertTracks(tracks);
            await RemoveTracks(tracks);
        }

        private async Task InsertTracks(List<Track> tracks)
        {
            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = "INSERT OR IGNORE INTO tracks (title, artist, album, path, track, track_count, year, duration, play_count) VALUES (?1, ?2, ?3, ?4, ?5, ?6, ?7, ?8, ?9);";

                foreach (Track t in tracks)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("?1", t.title);
                    command.Parameters.AddWithValue("?2", t.artist);
                    command.Parameters.AddWithValue("?3", t.album);
                    command.Parameters.AddWithValue("?4", t.path);
                    command.Parameters.AddWithValue("?5", t.track);
                    command.Parameters.AddWithValue("?6", t.track_count);
                    command.Parameters.AddWithValue("?7", t.year);
                    command.Parameters.AddWithValue("?8", t.duration);
                    command.Parameters.AddWithValue("?9", 0);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        private async Task RemoveTracks(List<Track> tracks)
        {
            IEnumerable<string> paths = from track in tracks
                                        select track.path;

            List<string> db_paths = await GetAllWithProperty("path");

            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM tracks WHERE path=\"?1\"";
                foreach (string path in db_paths)
                {
                    if(!paths.Contains(path))
                    {
                        command.Parameters.AddWithValue("?1", path);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        public async Task<List<Track>> GetAllTracks()
        {
            List<Track> tracks = new List<Track>();
            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM tracks";

                var data = await command.ExecuteReaderAsync();
                while (await data.ReadAsync())
                {
                    Console.WriteLine($"{data.GetValue(0)}: {data.GetValue(1)}");
                    Track track = new Track()
                    {
                        title = data.GetString(1),
                        artist = data.GetString(2),
                        album = data.GetString(3),
                        path = data.GetString(4),
                        track = data.GetInt32(5),
                        track_count = data.GetInt32(6),
                        year = data.GetInt32(7),
                        duration = data.GetDouble(8)
                    };
                    tracks.Add(track);
                }
                await command.DisposeAsync();

                return SortTracks(tracks);
            }
        }

        public async Task<List<string>> GetAllWithProperty(string property)
        {
            List<string> list = new List<string>();
            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = $"SELECT DISTINCT ({property}) FROM tracks";

                var data = await command.ExecuteReaderAsync();
                while (await data.ReadAsync())
                {
                    list.Add(data.GetString(0));
                }
                await command.DisposeAsync();

                return list;
            }
        }

        public async Task<List<Track>> GetTracksByProperty(string property, string property_value)
        {
            List<Track> tracks = new List<Track>();
            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM tracks WHERE {property}=\"{property_value}\"";

                var data = await command.ExecuteReaderAsync();
                while (await data.ReadAsync())
                {
                    Track track = new Track()
                    {
                        title = data.GetString(1),
                        artist = data.GetString(2),
                        album = data.GetString(3),
                        path = data.GetString(4),
                        track = data.GetInt32(5),
                        track_count = data.GetInt32(6),
                        year = data.GetInt32(7),
                        duration = data.GetDouble(8)
                    };
                    tracks.Add(track);
                }
                await command.DisposeAsync();

                return SortTracks(tracks);
            }
        }

        public System.Drawing.Image GetImageFromPath(string path)
        {
            System.Drawing.Image image = Properties.Resources.rect;

            TagLib.File tagFile = TagLib.File.Create(path);
            if (tagFile.Tag.Pictures.Length > 0)
            {
                MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                image = System.Drawing.Image.FromStream(ms);
            }
            return image;
        }

        public async Task IncrementPlayCount(Track track)
        {
            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = $""" 
                UPDATE tracks
                SET play_count = play_count + 1
                WHERE path = "{track.path}"
                """;
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<string>> GetMostPopularTracks()
        {
            List<string> tracks = new List<string>();

            using (var command = this.Connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM tracks WHERE play_count > 0 ORDER BY play_count DESC";

                var data = await command.ExecuteReaderAsync();
                while (await data.ReadAsync())
                {
                    tracks.Add($"{data.GetString(1)}: {data.GetInt32(9)}");
                }
                await command.DisposeAsync();
            }

            return tracks;
        }

        private static List<Track> SortTracks(List<Track> tracks)
        {
            //Artist => Year => Album => Track No
            return tracks.OrderBy(track => track.artist).ThenByDescending(track => track.year).ThenBy(track => track.album).ThenBy(track => track.track).ToList();
        }
    }
}
