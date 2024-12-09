﻿using System;
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

namespace TheBesterMusicApp
{
    public partial class Form1 : Form
    {
        List<Track> tracks = new List<Track>();
        List<Track> displayed_tracks = new List<Track>();
        Track[] track_queue = new Track[0];
        Track current_track;
        string selected_album = "";
        string selected_artist = "";
        string selected_playlist = "";

        IWavePlayer music_player = new WaveOutEvent();
        AudioFileReader music_reader;
        int current_mode = 0; //0 Normal, 1 Shuffle, 2 Repeat;

        public Form1()
        {
            InitializeComponent();
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
            DisplayList(0);
            DisplayMusic(0);
        }

        private void tab_Page_Select_TabIndexChanged(object sender, TabControlEventArgs e)
        {
            int page = GetPageIndex();
            DisplayList(page);
            DisplayMusic(page);
        }
        private async void DisplayMusic(int page)
        {
            Database db = await Database.Create();
            ListView track_list = new ListView();
            displayed_tracks.Clear();

            if (page == 0)
            {
                track_list = lv_Tracks_Track_List;
                displayed_tracks.AddRange(tracks);
            }
            else if (page == 1)
            {
                track_list = lv_Albums_Track_List;
                displayed_tracks.AddRange(await db.GetTracksByProperty("album", selected_album));
            }
            else if (page == 2)
            {
                track_list = lv_Artists_Track_List;
                displayed_tracks.AddRange(await db.GetTracksByProperty("artist", selected_artist));
            }
            else if (page == 3)
            {
                track_list = lv_Playlists_Track_List;
                displayed_tracks.AddRange(await db.GetTracksFromPlaylist(selected_playlist));
            }

            if (track_queue.Length == 0)
            {
                track_queue = displayed_tracks.ToArray();
            }

            track_list.Items.Clear();
            for (int i = 0; i < displayed_tracks.Count; i++)
            {
                Track track = displayed_tracks[i];

                string duration = ConvertToTimestamp(track.duration);
                string[] row = { track.title, track.album, track.artist, duration };
                track_list.Items.Add(track.track.ToString()).SubItems.AddRange(row);
                track_list.Items[i].Tag = track;
            }
        }
        private async void DisplayList(int page)
        {
            Database db = await Database.Create();
            List<string> item_list = new List<string>();
            ListView listview = new ListView();

            if (page == 0)
            {
                item_list = await db.GetMostPopularTracks();
                listview = lv_Tracks_Most_Popular;
            }
            else if (page == 1)
            {
                item_list = await db.GetAllWithProperty("album");
                listview = lv_Albums_Album_List;
                if (selected_album == "")
                {
                    selected_album = item_list[0];
                }
            }
            else if (page == 2)
            {
                item_list = await db.GetAllWithProperty("artist");
                listview = lv_Artists_Artist_List;
                if (selected_artist == "")
                {
                    selected_artist = item_list[0];
                }
            }
            else if (page == 3)
            {
                item_list = await db.GetPlaylists();
                listview = lv_Playlists_Playlist_List;
                if (selected_playlist == "")
                {
                    selected_playlist = item_list[0];
                }
            }

            listview.Clear();
            foreach (string item in item_list)
            {
                ListViewItem listview_item = new ListViewItem();
                listview_item.Text = item;
                listview_item.Tag = item;
                listview.Items.Add(listview_item);
            }
        }

        private int GetPageIndex()
        {
            if (tab_Page_Select.SelectedTab.Name == "tp_Tracks")
            {
                return 0;
            } 
            else if (tab_Page_Select.SelectedTab.Name == "tp_Albums")
            {
                return 1;
            }
            else if (tab_Page_Select.SelectedTab.Name == "tp_Artists")
            {
                return 2;
            }
            else if (tab_Page_Select.SelectedTab.Name == "tp_Playlists")
            {
                return 3;
            }
            return -1;
        }
        private void ListSelect(object sender, EventArgs e)
        {
            ListView list = sender as ListView;
            if (list.SelectedItems.Count < 1)
            {
                return;
            }

            int page = GetPageIndex();
            if (page == 1)
            {
                selected_album = list.SelectedItems[0].Text;
            }
            if (page == 2)
            {
                selected_artist = list.SelectedItems[0].Text;
            }
            if (page == 3)
            {
                selected_playlist = list.SelectedItems[0].Text;
            }
            DisplayMusic(page);
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
        private async Task DisplayTrackOnControl(Track track)
        {
            Database db = await Database.Create();

            pic_Control_Album_Cover.Image = db.GetImageFromPath(track.path);
            lbl_Control_Track_Name.Text = track.title;
            lbl_Control_Album_Name.Text = track.album;
            lbl_Control_Artist_Name.Text = track.artist;
            lbl_Control_Track_Duration.Text = $"00:00 / {ConvertToTimestamp(track.duration)}";
            tkb_Control_Time_Bar.Value = 0;
        }
        private void Track_List_DoubleClick(object sender, EventArgs e)
        {
            Track track;
            ListView listview = sender as ListView;
            if (listview.SelectedItems.Count > 0)
            {
                track_queue = displayed_tracks.ToArray();
                ChangeMode();

                track = (Track)listview.SelectedItems[0].Tag;
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
            Track track;
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
            else
            {
                track = current_track;
            }
            PlayTrack(track);
            DisplayTrackOnControl(track);
        }
        private void btn_Control_Next_Button_Click(object sender, EventArgs e)
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
                Random rng = new Random();
                track_queue = track_queue.OrderBy(track => rng.Next()).ToArray();
            }
            else
            {
                if(GetPageIndex() != 3)
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
            DisplayList(3);
        }

        private async void Track_List_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }
            ToolStripMenuItem playlist_dropdown = this.tsmi_Add_To_Playlist;
            playlist_dropdown.DropDownItems.Clear();

            Database db = await Database.Create();
            List<string> playlists = await db.GetPlaylists();
            foreach (string playlist in playlists)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = playlist;
                item.Click += tsmi_Add_To_Playlist_Selected;
                playlist_dropdown.DropDownItems.Add(item);
            }

            cms_Track_Menu.Show(Cursor.Position);
        }

        private async void tsmi_Add_To_Playlist_Selected(object sender, EventArgs e)
        {
            Database db = await Database.Create();
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ListView listview = new ListView();

            int page = GetPageIndex();
            switch (page)
            {
                case 0:
                    listview = this.lv_Tracks_Track_List;
                    break;

                case 1:
                    listview = this.lv_Albums_Track_List;
                    break;

                case 2:
                    listview = this.lv_Artists_Track_List;
                    break;

                case 3:
                    listview = this.lv_Playlists_Track_List;
                    break;
            }
            if (listview.SelectedItems.Count < 1)
            {
                return;
            }

            await db.AddTrackToPlaylist((Track)listview.SelectedItems[0].Tag, item.Text);
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
}