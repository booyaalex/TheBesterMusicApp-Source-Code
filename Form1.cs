using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using TagLib.Riff;
using Windows.Media.Playback;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Microsoft.VisualBasic;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheBesterMusicApp
{
    public partial class Form1 : Form
    {
        List<Track> tracks = [];
        List<Track> displayed_tracks = [];
        Track[] track_queue = [];
        Track current_track;
        string selected_album = "";
        string selected_artist = "";
        string selected_playlist = "";

        IWavePlayer music_player = new WaveOutEvent();
        AudioFileReader music_reader;
        int current_mode = 0; //0 Normal, 1 Shuffle, 2 Repeat;

        Page[] pages;
        Page current_page;

        ListViewItem held_item;

        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Pages
         */
        private void MapPages()
        {
            pages = new Page[4];
            pages[0] = new Page(0, lv_Tracks_Track_List, lv_Tracks_Most_Popular);
            pages[1] = new Page(1, lv_Albums_Track_List, lv_Albums_Album_List);
            pages[2] = new Page(2, lv_Artists_Track_List, lv_Artists_Artist_List);
            pages[3] = new Page(3, lv_Playlists_Track_List, lv_Playlists_Playlist_List);

            current_page = pages[0];
        }
        private Page GetPage()
        {
            if (tab_Page_Select.SelectedTab.Name == "tp_Tracks")
            {
                return pages[0];
            }
            else if (tab_Page_Select.SelectedTab.Name == "tp_Albums")
            {
                return pages[1];
            }
            else if (tab_Page_Select.SelectedTab.Name == "tp_Artists")
            {
                return pages[2];
            }
            else if (tab_Page_Select.SelectedTab.Name == "tp_Playlists")
            {
                return pages[3];
            }
            return new Page();
        }

        /*
         * Displaying Music 
         */
        private async void Form1_Load(object sender, EventArgs e)
        {
            Database db = await Database.Create();

            tracks.AddRange(await db.GetAllTracks());
            if (tracks.Count == 0)
            {
                await db.GetTracksFromFiles(tracks);
            }

            MapPages();

            DisplayList();
            DisplayMusic();
        }

        private void tab_Page_Select_TabIndexChanged(object sender, TabControlEventArgs e)
        {
            Page page = GetPage();
            current_page = page;

            DisplayList();
            DisplayMusic();
        }
        private async void DisplayMusic()
        {
            Database db = await Database.Create();

            Track track;
            ListView track_list = current_page.track_list;
            displayed_tracks.Clear();

            if (current_page.index == 0)
            {
                displayed_tracks.AddRange(tracks);
            }
            else if (current_page.index == 1)
            {
                displayed_tracks.AddRange(await db.GetTracksByProperty("album", selected_album));
            }
            else if (current_page.index == 2)
            {
                displayed_tracks.AddRange(await db.GetTracksByProperty("artist", selected_artist));
            }
            else if (current_page.index == 3)
            {
                displayed_tracks.AddRange(await db.GetTracksFromPlaylist(selected_playlist));
            }

            if (track_queue.Length == 0)
            {
                track_queue = displayed_tracks.ToArray();
            }

            track_list.Items.Clear();
            for (int i = 0; i < displayed_tracks.Count; i++)
            {
                track = displayed_tracks[i];

                string[] row = [track.title, track.album, track.artist, ConvertToTimestamp(track.duration)];
                track_list.Items.Add(track.track.ToString()).SubItems.AddRange(row);
                track_list.Items[i].Tag = track;
            }
        }
        private async void DisplayList()
        {
            Database db = await Database.Create();
            List<string> item_list = [];
            ListView selection_list = current_page.selection_list;

            if (current_page.index == 0)
            {
                item_list = await db.GetMostPopularTracks();
            }
            else if (current_page.index == 1)
            {
                item_list = await db.GetAllWithProperty("album");
                if (selected_album == "")
                {
                    selected_album = item_list[0];
                }
            }
            else if (current_page.index == 2)
            {
                item_list = await db.GetAllWithProperty("artist");
                if (selected_artist == "")
                {
                    selected_artist = item_list[0];
                }
            }
            else if (current_page.index == 3)
            {
                item_list = await db.GetPlaylists();
                if (selected_playlist == "")
                {
                    selected_playlist = item_list[0];
                }
            }

            selection_list.Clear();
            foreach (string item in item_list)
            {
                selection_list.Items.Add(item);
            }
        }

        private void ListSelect(object sender, EventArgs e)
        {
            ListView selected_list = current_page.selection_list;
            if (selected_list.SelectedItems.Count < 1)
            {
                return;
            }

            if (current_page.index == 1)
            {
                selected_album = selected_list.SelectedItems[0].Text;
            }
            if (current_page.index == 2)
            {
                selected_artist = selected_list.SelectedItems[0].Text;
            }
            if (current_page.index == 3)
            {
                selected_playlist = selected_list.SelectedItems[0].Text;
            }
            DisplayMusic();
        }

        /*
         * Playing Music 
         */
        private async void PlayTrack(Track track)
        {
            Database db = await Database.Create();
            current_track = track;

            music_player.Dispose();
            tmr_Track_Timer.Dispose();

            try
            {
                music_reader = new AudioFileReader(track.path);
                tmr_Track_Timer.Enabled = true;
                tmr_Track_Timer.Tick += new EventHandler(UpdateTime);
                tmr_Track_Timer.Interval = 1000;

                btn_Control_Play_Button.BackgroundImage = Properties.Resources.Pause;

                music_player.Init(music_reader);
                music_player.Play();
                tmr_Track_Timer.Start();

                await db.IncrementPlayCount(track);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void UpdateTime(object sender, EventArgs e)
        {
            double current_time = music_reader.CurrentTime.TotalSeconds;
            double total_time = music_reader.TotalTime.TotalSeconds;
            lbl_Control_Track_Duration.Text = $"{ConvertToTimestamp(current_time)} / {ConvertToTimestamp(total_time)}";
            tkb_Control_Time_Bar.Value = Convert.ToInt32(current_time / total_time * 100);

            if (music_player.PlaybackState.ToString() == "Stopped")
            {
                Track track;
                int index = Array.IndexOf(track_queue, current_track);
                if (current_mode != 2)
                {
                    index++;
                    if (index > track_queue.Length - 1)
                    {
                        index = 0;
                    }
                    track = track_queue[index];
                }
                else
                {
                    track = current_track;
                }
                PlayTrack(track);
                DisplayTrackOnControl(track);
            }
        }
        private void DisplayTrackOnControl(Track track)
        {
            pic_Control_Album_Cover.Image = Database.GetImageFromPath(track.path);
            lbl_Control_Track_Name.Text = track.title;
            lbl_Control_Album_Name.Text = track.album;
            lbl_Control_Artist_Name.Text = track.artist;
            lbl_Control_Track_Duration.Text = $"00:00 / {ConvertToTimestamp(track.duration)}";
            tkb_Control_Time_Bar.Value = 0;
        }
        private void Track_List_DoubleClick(object sender, EventArgs e)
        {
            ListView track_list = current_page.track_list;
            if (track_list.SelectedItems.Count > 0)
            {
                track_queue = displayed_tracks.ToArray();
                ChangeMode();

                Track track = (Track)track_list.SelectedItems[0].Tag;
                PlayTrack(track);
                DisplayTrackOnControl(track);
            }
        }
        private static string ConvertToTimestamp(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"mm\:ss");
        }

        /*
         * Controlling Music 
         */
        private void btn_Control_Play_Button_Click(object sender, EventArgs e)
        {
            if (music_player.PlaybackState.ToString() == "Playing")
            {
                tmr_Track_Timer.Enabled = false;
                btn_Control_Play_Button.BackgroundImage = Properties.Resources.Play;
                music_player.Stop();
            }
            else
            {
                tmr_Track_Timer.Enabled = true;
                btn_Control_Play_Button.BackgroundImage = Properties.Resources.Pause;
                music_player.Play();
            }
        }

        private void btn_Control_Previous_Button_Click(object sender, EventArgs e)
        {
            Track track = current_track;
            int index = Array.IndexOf(track_queue, current_track);
            if (current_mode != 2)
            {
                index--;
                if (index < 0)
                {
                    index = track_queue.Length - 1;
                }
                track = track_queue[index];
            }
            PlayTrack(track);
            DisplayTrackOnControl(track);
        }
        private void btn_Control_Next_Button_Click(object sender, EventArgs e)
        {
            Track track = current_track;
            int index = Array.IndexOf(track_queue, current_track);
            if (current_mode != 2)
            {
                index++;
                if (index > track_queue.Length - 1)
                {
                    index = 0;
                }
                track = track_queue[index];
            }
            PlayTrack(track);
            DisplayTrackOnControl(track);
        }
        private void tkb_Control_Time_Bar_Scroll(object sender, EventArgs e)
        {
            music_reader.CurrentTime = TimeSpan.FromSeconds(tkb_Control_Time_Bar.Value * music_reader.TotalTime.TotalSeconds / 100);
        }

        private void btn_Control_Mode_Change_Click(object sender, EventArgs e)
        {
            if (current_mode == 2)
            {
                current_mode = 0;
                btn_Control_Mode_Change.BackgroundImage = Properties.Resources.Circle;
            }
            else if (current_mode == 0)
            {
                current_mode = 1;
                btn_Control_Mode_Change.BackgroundImage = Properties.Resources.Shuffle;
            }
            else
            {
                current_mode = 2;
                btn_Control_Mode_Change.BackgroundImage = Properties.Resources.Repeat;
            }
            ChangeMode();
        }
        private void ChangeMode()
        {
            if (current_mode == 1)
            {
                Random rng = new();
                track_queue = track_queue.OrderBy(track => rng.Next()).ToArray();
            }
            else
            {
                if (current_page.index != 3)
                {
                    track_queue = track_queue.OrderBy(track => track.artist).ThenByDescending(track => track.year).ThenBy(track => track.album).ThenBy(track => track.track).ToArray();
                }
            }
        }

        private void tkb_Control_Volume_Scroll(object sender, EventArgs e)
        {
            music_player.Volume = tkb_Control_Volume.Value / 100f;
        }

        private async void btn_Update_Tracks_Click(object sender, EventArgs e)
        {
            Database db = await Database.Create();
            await db.GetTracksFromFiles(tracks);
        }

        /* 
         * Playlists 
         */
        private async void btn_New_Playlist_Click(object sender, EventArgs e)
        {
            Database db = await Database.Create();
            string input = Interaction.InputBox("Enter in The Name of Your Playlist:", "Type in a Name");
            await db.CreatePlaylist(input);
            DisplayList();
        }

        private async void Track_List_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            ToolStripMenuItem playlist_dropdown = this.tsmi_Add_To_Playlist;
            this.tsmi_Remove_From_Playlist.Enabled = false;
            playlist_dropdown.DropDownItems.Clear();


            Database db = await Database.Create();
            List<string> playlist_list = await db.GetPlaylists();
            foreach (string playlist in playlist_list)
            {
                ToolStripMenuItem item = new()
                {
                    Text = playlist
                };
                item.Click += tsmi_Add_To_Playlist_Selected;
                playlist_dropdown.DropDownItems.Add(item);
            }

            if (current_page.index == 3)
            {
                this.tsmi_Remove_From_Playlist.Enabled = true;
            }

            cms_Track_Menu.Show(Cursor.Position);
        }

        private async void tsmi_Add_To_Playlist_Selected(object sender, EventArgs e)
        {
            Database db = await Database.Create();
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ListView track_list = current_page.track_list;

            if (track_list.SelectedItems.Count < 1)
            {
                return;
            }

            await db.AddTrackToPlaylist((Track)track_list.SelectedItems[0].Tag, item.Text);
        }

        private async void tsmi_Remove_From_Playlist_Click(object sender, EventArgs e)
        {
            Database db = await Database.Create();
            ListView track_list = current_page.track_list;

            if (track_list.SelectedItems.Count < 1)
            {
                return;
            }

            await db.RemoveTrackFromPlaylist((Track)track_list.SelectedItems[0].Tag, selected_playlist);
            DisplayMusic();
        }

        /*
         * Playlist Options
         */
        private void lv_Playlists_Playlist_List_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            cms_Playlist_Menu.Show(Cursor.Position);
        }
        private async void tsmi_Rename_Playlist_Click(object sender, EventArgs e)
        {
            Database db = await Database.Create();
            string input = Interaction.InputBox("Enter in The New Name of Your Playlist:", "Type in a Name");
            await db.RenamePlaylist(lv_Playlists_Playlist_List.SelectedItems[0].Text, input);
            DisplayList();
        }
        private async void tsmi_Delete_Playlist_Click(object sender, EventArgs e)
        {
            Database db = await Database.Create();
            await db.DeletePlaylist(lv_Playlists_Playlist_List.SelectedItems[0].Text);
            selected_playlist = "";
            DisplayList();
            DisplayMusic();
        }

        /*
         * Drag And Reordering Playlists
         */
        private void lv_Playlists_Track_List_MouseDown(object sender, MouseEventArgs e)
        {
            held_item = lv_Playlists_Track_List.GetItemAt(e.X, e.Y);
            if (held_item == null) { return; }
        }

        private void lv_Playlists_Track_List_MouseMove(object sender, MouseEventArgs e)
        {
            if (held_item == null) { return; }
            Cursor = Cursors.SizeAll;
        }

        private void lv_Playlists_Track_List_MouseUp(object sender, MouseEventArgs e)
        {
            if (held_item == null) { return; }
            ListViewItem item_at_insert_pos = lv_Playlists_Track_List.GetItemAt(0, e.Y);
            if (item_at_insert_pos == null || held_item == item_at_insert_pos) { return; }
            lv_Playlists_Track_List.Items.Remove(held_item);
            lv_Playlists_Track_List.Items.Insert(item_at_insert_pos.Index, held_item);

            RearangePlaylist((Track)held_item.Tag, item_at_insert_pos.Index);

            held_item = null;
            Cursor = Cursors.Default;
        }
        private async void RearangePlaylist(Track track, int new_index)
        {
            Database db = await Database.Create();
            await db.RemoveTrackFromPlaylist(track, selected_playlist);
            await db.AddTrackToPlaylist(track, selected_playlist, new_index - 1);
        }
    }
    public struct Track
    {
        public string artist;
        public string album;
        public double duration;
        public string path;
        public int track;
        public int track_count;
        public string title;
        public int year;
    }

    public struct Page(int index, ListView track_list, ListView selection_list)
    {
        public int index = index;
        public ListView track_list = track_list;
        public ListView selection_list = selection_list;
    }
}