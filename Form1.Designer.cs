using System.Drawing;

namespace TheBesterMusicApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tab_Page_Select = new System.Windows.Forms.TabControl();
            tp_Tracks = new System.Windows.Forms.TabPage();
            lv_Tracks_Most_Popular = new System.Windows.Forms.ListView();
            lv_Tracks_Track_List = new System.Windows.Forms.ListView();
            Tracks_No = new System.Windows.Forms.ColumnHeader();
            Tracks_Track = new System.Windows.Forms.ColumnHeader();
            Tracks_Album = new System.Windows.Forms.ColumnHeader();
            Tracks_Artist = new System.Windows.Forms.ColumnHeader();
            Track_Time = new System.Windows.Forms.ColumnHeader();
            tp_Albums = new System.Windows.Forms.TabPage();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lv_Albums_Album_List = new System.Windows.Forms.ListView();
            lv_Albums_Track_List = new System.Windows.Forms.ListView();
            Albums_No = new System.Windows.Forms.ColumnHeader();
            Albums_Track = new System.Windows.Forms.ColumnHeader();
            Albums_Album = new System.Windows.Forms.ColumnHeader();
            Albums_Artist = new System.Windows.Forms.ColumnHeader();
            Albums_Length = new System.Windows.Forms.ColumnHeader();
            tp_Artists = new System.Windows.Forms.TabPage();
            lv_Artists_Artist_List = new System.Windows.Forms.ListView();
            lv_Artists_Track_List = new System.Windows.Forms.ListView();
            Artists_No = new System.Windows.Forms.ColumnHeader();
            Artists_Track = new System.Windows.Forms.ColumnHeader();
            Artists_Album = new System.Windows.Forms.ColumnHeader();
            Artists_Artist = new System.Windows.Forms.ColumnHeader();
            Artists_Length = new System.Windows.Forms.ColumnHeader();
            tp_Playlists = new System.Windows.Forms.TabPage();
            btn_New_Playlist = new System.Windows.Forms.Button();
            lv_Playlists_Track_List = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            lv_Playlists_Playlist_List = new System.Windows.Forms.ListView();
            tp_Settings = new System.Windows.Forms.TabPage();
            btn_Update_Tracks = new System.Windows.Forms.Button();
            pnl_Song_Control = new System.Windows.Forms.Panel();
            tkb_Control_Volume = new System.Windows.Forms.TrackBar();
            btn_Control_Mode_Change = new System.Windows.Forms.Button();
            btn_Control_Next_Button = new System.Windows.Forms.Button();
            btn_Control_Previous_Button = new System.Windows.Forms.Button();
            btn_Control_Play_Button = new System.Windows.Forms.Button();
            lbl_Control_Track_Duration = new System.Windows.Forms.Label();
            lbl_Control_Artist_Name = new System.Windows.Forms.Label();
            lbl_Control_Album_Name = new System.Windows.Forms.Label();
            lbl_Control_Track_Name = new System.Windows.Forms.Label();
            tkb_Control_Time_Bar = new System.Windows.Forms.TrackBar();
            pic_Control_Album_Cover = new System.Windows.Forms.PictureBox();
            tmr_Track_Timer = new System.Windows.Forms.Timer(components);
            cms_Track_Menu = new System.Windows.Forms.ContextMenuStrip(components);
            tsmi_Add_To_Playlist = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Remove_From_Playlist = new System.Windows.Forms.ToolStripMenuItem();
            tab_Page_Select.SuspendLayout();
            tp_Tracks.SuspendLayout();
            tp_Albums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tp_Artists.SuspendLayout();
            tp_Playlists.SuspendLayout();
            tp_Settings.SuspendLayout();
            pnl_Song_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tkb_Control_Volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tkb_Control_Time_Bar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_Control_Album_Cover).BeginInit();
            cms_Track_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // tab_Page_Select
            // 
            tab_Page_Select.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tab_Page_Select.Controls.Add(tp_Tracks);
            tab_Page_Select.Controls.Add(tp_Albums);
            tab_Page_Select.Controls.Add(tp_Artists);
            tab_Page_Select.Controls.Add(tp_Playlists);
            tab_Page_Select.Controls.Add(tp_Settings);
            tab_Page_Select.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tab_Page_Select.Location = new Point(6, 3);
            tab_Page_Select.Margin = new System.Windows.Forms.Padding(0);
            tab_Page_Select.Name = "tab_Page_Select";
            tab_Page_Select.Padding = new Point(0, 0);
            tab_Page_Select.SelectedIndex = 0;
            tab_Page_Select.Size = new Size(992, 393);
            tab_Page_Select.TabIndex = 0;
            tab_Page_Select.Selected += tab_Page_Select_TabIndexChanged;
            // 
            // tp_Tracks
            // 
            tp_Tracks.BackColor = Color.FromArgb(34, 36, 37);
            tp_Tracks.Controls.Add(lv_Tracks_Most_Popular);
            tp_Tracks.Controls.Add(lv_Tracks_Track_List);
            tp_Tracks.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tp_Tracks.Location = new Point(4, 26);
            tp_Tracks.Margin = new System.Windows.Forms.Padding(0);
            tp_Tracks.Name = "tp_Tracks";
            tp_Tracks.Size = new Size(984, 363);
            tp_Tracks.TabIndex = 0;
            tp_Tracks.Text = "Tracks";
            // 
            // lv_Tracks_Most_Popular
            // 
            lv_Tracks_Most_Popular.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lv_Tracks_Most_Popular.AutoArrange = false;
            lv_Tracks_Most_Popular.BackColor = Color.FromArgb(57, 61, 63);
            lv_Tracks_Most_Popular.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Tracks_Most_Popular.ForeColor = Color.WhiteSmoke;
            lv_Tracks_Most_Popular.FullRowSelect = true;
            lv_Tracks_Most_Popular.HideSelection = true;
            lv_Tracks_Most_Popular.Location = new Point(765, 0);
            lv_Tracks_Most_Popular.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Tracks_Most_Popular.MultiSelect = false;
            lv_Tracks_Most_Popular.Name = "lv_Tracks_Most_Popular";
            lv_Tracks_Most_Popular.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lv_Tracks_Most_Popular.ShowGroups = false;
            lv_Tracks_Most_Popular.Size = new Size(219, 363);
            lv_Tracks_Most_Popular.TabIndex = 7;
            lv_Tracks_Most_Popular.UseCompatibleStateImageBehavior = false;
            lv_Tracks_Most_Popular.View = System.Windows.Forms.View.List;
            // 
            // lv_Tracks_Track_List
            // 
            lv_Tracks_Track_List.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_Tracks_Track_List.BackColor = Color.FromArgb(46, 49, 50);
            lv_Tracks_Track_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Tracks_Track_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { Tracks_No, Tracks_Track, Tracks_Album, Tracks_Artist, Track_Time });
            lv_Tracks_Track_List.ForeColor = Color.WhiteSmoke;
            lv_Tracks_Track_List.FullRowSelect = true;
            lv_Tracks_Track_List.Location = new Point(0, 0);
            lv_Tracks_Track_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Tracks_Track_List.MultiSelect = false;
            lv_Tracks_Track_List.Name = "lv_Tracks_Track_List";
            lv_Tracks_Track_List.Size = new Size(757, 363);
            lv_Tracks_Track_List.TabIndex = 0;
            lv_Tracks_Track_List.UseCompatibleStateImageBehavior = false;
            lv_Tracks_Track_List.View = System.Windows.Forms.View.Details;
            lv_Tracks_Track_List.DoubleClick += Track_List_DoubleClick;
            lv_Tracks_Track_List.MouseClick += Track_List_RightClick;
            // 
            // Tracks_No
            // 
            Tracks_No.Text = "#";
            Tracks_No.Width = 25;
            // 
            // Tracks_Track
            // 
            Tracks_Track.Text = "Track";
            Tracks_Track.Width = 250;
            // 
            // Tracks_Album
            // 
            Tracks_Album.Text = "Album";
            Tracks_Album.Width = 150;
            // 
            // Tracks_Artist
            // 
            Tracks_Artist.Text = "Artist";
            Tracks_Artist.Width = 150;
            // 
            // Track_Time
            // 
            Track_Time.Text = "Length";
            Track_Time.Width = 61;
            // 
            // tp_Albums
            // 
            tp_Albums.BackColor = Color.FromArgb(34, 36, 37);
            tp_Albums.Controls.Add(pictureBox1);
            tp_Albums.Controls.Add(lv_Albums_Album_List);
            tp_Albums.Controls.Add(lv_Albums_Track_List);
            tp_Albums.Location = new Point(4, 26);
            tp_Albums.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tp_Albums.Name = "tp_Albums";
            tp_Albums.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tp_Albums.Size = new Size(984, 363);
            tp_Albums.TabIndex = 1;
            tp_Albums.Text = "Albums";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(976, 0);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1, 1);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lv_Albums_Album_List
            // 
            lv_Albums_Album_List.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lv_Albums_Album_List.AutoArrange = false;
            lv_Albums_Album_List.BackColor = Color.FromArgb(57, 61, 63);
            lv_Albums_Album_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Albums_Album_List.ForeColor = Color.WhiteSmoke;
            lv_Albums_Album_List.FullRowSelect = true;
            lv_Albums_Album_List.Location = new Point(0, 0);
            lv_Albums_Album_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Albums_Album_List.Name = "lv_Albums_Album_List";
            lv_Albums_Album_List.Size = new Size(219, 363);
            lv_Albums_Album_List.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lv_Albums_Album_List.TabIndex = 3;
            lv_Albums_Album_List.UseCompatibleStateImageBehavior = false;
            lv_Albums_Album_List.View = System.Windows.Forms.View.List;
            lv_Albums_Album_List.DoubleClick += ListSelect;
            // 
            // lv_Albums_Track_List
            // 
            lv_Albums_Track_List.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_Albums_Track_List.BackColor = Color.FromArgb(46, 49, 50);
            lv_Albums_Track_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Albums_Track_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { Albums_No, Albums_Track, Albums_Album, Albums_Artist, Albums_Length });
            lv_Albums_Track_List.ForeColor = Color.WhiteSmoke;
            lv_Albums_Track_List.FullRowSelect = true;
            lv_Albums_Track_List.Location = new Point(227, 0);
            lv_Albums_Track_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Albums_Track_List.MultiSelect = false;
            lv_Albums_Track_List.Name = "lv_Albums_Track_List";
            lv_Albums_Track_List.Size = new Size(757, 363);
            lv_Albums_Track_List.TabIndex = 1;
            lv_Albums_Track_List.UseCompatibleStateImageBehavior = false;
            lv_Albums_Track_List.View = System.Windows.Forms.View.Details;
            lv_Albums_Track_List.DoubleClick += Track_List_DoubleClick;
            lv_Albums_Track_List.MouseClick += Track_List_RightClick;
            // 
            // Albums_No
            // 
            Albums_No.Text = "#";
            Albums_No.Width = 25;
            // 
            // Albums_Track
            // 
            Albums_Track.Text = "Track";
            Albums_Track.Width = 291;
            // 
            // Albums_Album
            // 
            Albums_Album.Text = "Album";
            Albums_Album.Width = 0;
            // 
            // Albums_Artist
            // 
            Albums_Artist.Text = "Artist";
            Albums_Artist.Width = 150;
            // 
            // Albums_Length
            // 
            Albums_Length.Text = "Length";
            Albums_Length.Width = 75;
            // 
            // tp_Artists
            // 
            tp_Artists.BackColor = Color.FromArgb(34, 36, 37);
            tp_Artists.Controls.Add(lv_Artists_Artist_List);
            tp_Artists.Controls.Add(lv_Artists_Track_List);
            tp_Artists.Location = new Point(4, 26);
            tp_Artists.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tp_Artists.Name = "tp_Artists";
            tp_Artists.Size = new Size(984, 363);
            tp_Artists.TabIndex = 3;
            tp_Artists.Text = "Artists";
            // 
            // lv_Artists_Artist_List
            // 
            lv_Artists_Artist_List.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lv_Artists_Artist_List.AutoArrange = false;
            lv_Artists_Artist_List.BackColor = Color.FromArgb(57, 61, 63);
            lv_Artists_Artist_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Artists_Artist_List.ForeColor = Color.WhiteSmoke;
            lv_Artists_Artist_List.FullRowSelect = true;
            lv_Artists_Artist_List.Location = new Point(0, 0);
            lv_Artists_Artist_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Artists_Artist_List.Name = "lv_Artists_Artist_List";
            lv_Artists_Artist_List.Size = new Size(219, 363);
            lv_Artists_Artist_List.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lv_Artists_Artist_List.TabIndex = 5;
            lv_Artists_Artist_List.UseCompatibleStateImageBehavior = false;
            lv_Artists_Artist_List.View = System.Windows.Forms.View.List;
            lv_Artists_Artist_List.DoubleClick += ListSelect;
            // 
            // lv_Artists_Track_List
            // 
            lv_Artists_Track_List.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_Artists_Track_List.BackColor = Color.FromArgb(46, 49, 50);
            lv_Artists_Track_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Artists_Track_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { Artists_No, Artists_Track, Artists_Album, Artists_Artist, Artists_Length });
            lv_Artists_Track_List.ForeColor = Color.WhiteSmoke;
            lv_Artists_Track_List.FullRowSelect = true;
            lv_Artists_Track_List.Location = new Point(227, 0);
            lv_Artists_Track_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Artists_Track_List.MultiSelect = false;
            lv_Artists_Track_List.Name = "lv_Artists_Track_List";
            lv_Artists_Track_List.Size = new Size(757, 363);
            lv_Artists_Track_List.TabIndex = 4;
            lv_Artists_Track_List.UseCompatibleStateImageBehavior = false;
            lv_Artists_Track_List.View = System.Windows.Forms.View.Details;
            lv_Artists_Track_List.DoubleClick += Track_List_DoubleClick;
            lv_Artists_Track_List.MouseClick += Track_List_RightClick;
            // 
            // Artists_No
            // 
            Artists_No.Text = "#";
            Artists_No.Width = 25;
            // 
            // Artists_Track
            // 
            Artists_Track.Text = "Track";
            Artists_Track.Width = 291;
            // 
            // Artists_Album
            // 
            Artists_Album.Text = "Album";
            Artists_Album.Width = 150;
            // 
            // Artists_Artist
            // 
            Artists_Artist.Text = "Artist";
            Artists_Artist.Width = 0;
            // 
            // Artists_Length
            // 
            Artists_Length.Text = "Length";
            Artists_Length.Width = 75;
            // 
            // tp_Playlists
            // 
            tp_Playlists.BackColor = Color.FromArgb(34, 36, 37);
            tp_Playlists.Controls.Add(btn_New_Playlist);
            tp_Playlists.Controls.Add(lv_Playlists_Track_List);
            tp_Playlists.Controls.Add(lv_Playlists_Playlist_List);
            tp_Playlists.Location = new Point(4, 26);
            tp_Playlists.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tp_Playlists.Name = "tp_Playlists";
            tp_Playlists.Size = new Size(984, 363);
            tp_Playlists.TabIndex = 2;
            tp_Playlists.Text = "Playlists";
            // 
            // btn_New_Playlist
            // 
            btn_New_Playlist.BackColor = Color.DarkViolet;
            btn_New_Playlist.FlatAppearance.BorderSize = 0;
            btn_New_Playlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_New_Playlist.ForeColor = Color.Black;
            btn_New_Playlist.Location = new Point(0, 0);
            btn_New_Playlist.Name = "btn_New_Playlist";
            btn_New_Playlist.Size = new Size(219, 25);
            btn_New_Playlist.TabIndex = 8;
            btn_New_Playlist.Text = "Create New Playlist";
            btn_New_Playlist.UseVisualStyleBackColor = false;
            btn_New_Playlist.Click += btn_New_Playlist_Click;
            // 
            // lv_Playlists_Track_List
            // 
            lv_Playlists_Track_List.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_Playlists_Track_List.AutoArrange = false;
            lv_Playlists_Track_List.BackColor = Color.FromArgb(46, 49, 50);
            lv_Playlists_Track_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Playlists_Track_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            lv_Playlists_Track_List.ForeColor = Color.WhiteSmoke;
            lv_Playlists_Track_List.FullRowSelect = true;
            lv_Playlists_Track_List.LabelEdit = true;
            lv_Playlists_Track_List.Location = new Point(227, 0);
            lv_Playlists_Track_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Playlists_Track_List.MultiSelect = false;
            lv_Playlists_Track_List.Name = "lv_Playlists_Track_List";
            lv_Playlists_Track_List.Size = new Size(757, 363);
            lv_Playlists_Track_List.TabIndex = 7;
            lv_Playlists_Track_List.UseCompatibleStateImageBehavior = false;
            lv_Playlists_Track_List.View = System.Windows.Forms.View.Details;
            lv_Playlists_Track_List.DoubleClick += Track_List_DoubleClick;
            lv_Playlists_Track_List.MouseClick += Track_List_RightClick;
            lv_Playlists_Track_List.MouseDown += lv_Playlists_Track_List_MouseDown;
            lv_Playlists_Track_List.MouseMove += lv_Playlists_Track_List_MouseMove;
            lv_Playlists_Track_List.MouseUp += lv_Playlists_Track_List_MouseUp;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "#";
            columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Track";
            columnHeader2.Width = 291;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Album";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Artist";
            columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Length";
            columnHeader5.Width = 75;
            // 
            // lv_Playlists_Playlist_List
            // 
            lv_Playlists_Playlist_List.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lv_Playlists_Playlist_List.AutoArrange = false;
            lv_Playlists_Playlist_List.BackColor = Color.FromArgb(57, 61, 63);
            lv_Playlists_Playlist_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lv_Playlists_Playlist_List.ForeColor = Color.WhiteSmoke;
            lv_Playlists_Playlist_List.FullRowSelect = true;
            lv_Playlists_Playlist_List.Location = new Point(0, 23);
            lv_Playlists_Playlist_List.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Playlists_Playlist_List.Name = "lv_Playlists_Playlist_List";
            lv_Playlists_Playlist_List.Size = new Size(219, 340);
            lv_Playlists_Playlist_List.Sorting = System.Windows.Forms.SortOrder.Ascending;
            lv_Playlists_Playlist_List.TabIndex = 6;
            lv_Playlists_Playlist_List.UseCompatibleStateImageBehavior = false;
            lv_Playlists_Playlist_List.View = System.Windows.Forms.View.List;
            lv_Playlists_Playlist_List.DoubleClick += ListSelect;
            // 
            // tp_Settings
            // 
            tp_Settings.BackColor = Color.FromArgb(34, 36, 37);
            tp_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            tp_Settings.Controls.Add(btn_Update_Tracks);
            tp_Settings.ForeColor = SystemColors.ControlText;
            tp_Settings.Location = new Point(4, 26);
            tp_Settings.Margin = new System.Windows.Forms.Padding(0);
            tp_Settings.Name = "tp_Settings";
            tp_Settings.Size = new Size(984, 363);
            tp_Settings.TabIndex = 4;
            tp_Settings.Text = "Settings";
            // 
            // btn_Update_Tracks
            // 
            btn_Update_Tracks.BackColor = Color.DarkViolet;
            btn_Update_Tracks.Location = new Point(4, 3);
            btn_Update_Tracks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Update_Tracks.Name = "btn_Update_Tracks";
            btn_Update_Tracks.Size = new Size(132, 27);
            btn_Update_Tracks.TabIndex = 0;
            btn_Update_Tracks.Text = "Update Library";
            btn_Update_Tracks.UseVisualStyleBackColor = false;
            btn_Update_Tracks.Click += btn_Update_Tracks_Click;
            // 
            // pnl_Song_Control
            // 
            pnl_Song_Control.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnl_Song_Control.BackColor = Color.FromArgb(46, 49, 50);
            pnl_Song_Control.Controls.Add(tkb_Control_Volume);
            pnl_Song_Control.Controls.Add(btn_Control_Mode_Change);
            pnl_Song_Control.Controls.Add(btn_Control_Next_Button);
            pnl_Song_Control.Controls.Add(btn_Control_Previous_Button);
            pnl_Song_Control.Controls.Add(btn_Control_Play_Button);
            pnl_Song_Control.Controls.Add(lbl_Control_Track_Duration);
            pnl_Song_Control.Controls.Add(lbl_Control_Artist_Name);
            pnl_Song_Control.Controls.Add(lbl_Control_Album_Name);
            pnl_Song_Control.Controls.Add(lbl_Control_Track_Name);
            pnl_Song_Control.Controls.Add(tkb_Control_Time_Bar);
            pnl_Song_Control.Controls.Add(pic_Control_Album_Cover);
            pnl_Song_Control.ForeColor = Color.WhiteSmoke;
            pnl_Song_Control.Location = new Point(6, 400);
            pnl_Song_Control.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pnl_Song_Control.Name = "pnl_Song_Control";
            pnl_Song_Control.Size = new Size(992, 118);
            pnl_Song_Control.TabIndex = 1;
            // 
            // tkb_Control_Volume
            // 
            tkb_Control_Volume.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            tkb_Control_Volume.AutoSize = false;
            tkb_Control_Volume.Location = new Point(505, 78);
            tkb_Control_Volume.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tkb_Control_Volume.Maximum = 100;
            tkb_Control_Volume.Name = "tkb_Control_Volume";
            tkb_Control_Volume.Size = new Size(426, 33);
            tkb_Control_Volume.TabIndex = 10;
            tkb_Control_Volume.TickStyle = System.Windows.Forms.TickStyle.None;
            tkb_Control_Volume.Value = 100;
            tkb_Control_Volume.Scroll += tkb_Control_Volume_Scroll;
            // 
            // btn_Control_Mode_Change
            // 
            btn_Control_Mode_Change.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Control_Mode_Change.BackColor = Color.Transparent;
            btn_Control_Mode_Change.BackgroundImage = Properties.Resources.Circle;
            btn_Control_Mode_Change.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_Control_Mode_Change.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Control_Mode_Change.FlatAppearance.BorderSize = 0;
            btn_Control_Mode_Change.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_Control_Mode_Change.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Control_Mode_Change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Control_Mode_Change.Location = new Point(940, 72);
            btn_Control_Mode_Change.Margin = new System.Windows.Forms.Padding(6);
            btn_Control_Mode_Change.Name = "btn_Control_Mode_Change";
            btn_Control_Mode_Change.Size = new Size(41, 40);
            btn_Control_Mode_Change.TabIndex = 9;
            btn_Control_Mode_Change.UseVisualStyleBackColor = false;
            btn_Control_Mode_Change.Click += btn_Control_Mode_Change_Click;
            // 
            // btn_Control_Next_Button
            // 
            btn_Control_Next_Button.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Control_Next_Button.BackColor = Color.Transparent;
            btn_Control_Next_Button.BackgroundImage = Properties.Resources.Forward;
            btn_Control_Next_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_Control_Next_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Control_Next_Button.FlatAppearance.BorderSize = 0;
            btn_Control_Next_Button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_Control_Next_Button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Control_Next_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Control_Next_Button.Location = new Point(454, 72);
            btn_Control_Next_Button.Margin = new System.Windows.Forms.Padding(6);
            btn_Control_Next_Button.Name = "btn_Control_Next_Button";
            btn_Control_Next_Button.Size = new Size(41, 40);
            btn_Control_Next_Button.TabIndex = 8;
            btn_Control_Next_Button.UseVisualStyleBackColor = false;
            btn_Control_Next_Button.Click += btn_Control_Next_Button_Click;
            // 
            // btn_Control_Previous_Button
            // 
            btn_Control_Previous_Button.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Control_Previous_Button.BackColor = Color.Transparent;
            btn_Control_Previous_Button.BackgroundImage = Properties.Resources.Backward;
            btn_Control_Previous_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_Control_Previous_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Control_Previous_Button.FlatAppearance.BorderSize = 0;
            btn_Control_Previous_Button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_Control_Previous_Button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Control_Previous_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Control_Previous_Button.Location = new Point(349, 72);
            btn_Control_Previous_Button.Margin = new System.Windows.Forms.Padding(6);
            btn_Control_Previous_Button.Name = "btn_Control_Previous_Button";
            btn_Control_Previous_Button.Size = new Size(41, 40);
            btn_Control_Previous_Button.TabIndex = 7;
            btn_Control_Previous_Button.UseVisualStyleBackColor = false;
            btn_Control_Previous_Button.Click += btn_Control_Previous_Button_Click;
            // 
            // btn_Control_Play_Button
            // 
            btn_Control_Play_Button.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Control_Play_Button.BackColor = Color.Transparent;
            btn_Control_Play_Button.BackgroundImage = Properties.Resources.Play;
            btn_Control_Play_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btn_Control_Play_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_Control_Play_Button.FlatAppearance.BorderSize = 0;
            btn_Control_Play_Button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_Control_Play_Button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Control_Play_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Control_Play_Button.Location = new Point(401, 72);
            btn_Control_Play_Button.Margin = new System.Windows.Forms.Padding(6);
            btn_Control_Play_Button.Name = "btn_Control_Play_Button";
            btn_Control_Play_Button.Size = new Size(41, 40);
            btn_Control_Play_Button.TabIndex = 6;
            btn_Control_Play_Button.UseVisualStyleBackColor = false;
            btn_Control_Play_Button.Click += btn_Control_Play_Button_Click;
            // 
            // lbl_Control_Track_Duration
            // 
            lbl_Control_Track_Duration.AutoSize = true;
            lbl_Control_Track_Duration.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Control_Track_Duration.Location = new Point(126, 89);
            lbl_Control_Track_Duration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Control_Track_Duration.Name = "lbl_Control_Track_Duration";
            lbl_Control_Track_Duration.Size = new Size(83, 17);
            lbl_Control_Track_Duration.TabIndex = 5;
            lbl_Control_Track_Duration.Text = "00:00 / 00:00";
            // 
            // lbl_Control_Artist_Name
            // 
            lbl_Control_Artist_Name.AutoSize = true;
            lbl_Control_Artist_Name.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Control_Artist_Name.ForeColor = SystemColors.ControlDarkDark;
            lbl_Control_Artist_Name.Location = new Point(126, 57);
            lbl_Control_Artist_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Control_Artist_Name.MaximumSize = new Size(198, 23);
            lbl_Control_Artist_Name.Name = "lbl_Control_Artist_Name";
            lbl_Control_Artist_Name.Size = new Size(0, 17);
            lbl_Control_Artist_Name.TabIndex = 4;
            // 
            // lbl_Control_Album_Name
            // 
            lbl_Control_Album_Name.AutoSize = true;
            lbl_Control_Album_Name.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Control_Album_Name.Location = new Point(125, 33);
            lbl_Control_Album_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Control_Album_Name.MaximumSize = new Size(204, 23);
            lbl_Control_Album_Name.Name = "lbl_Control_Album_Name";
            lbl_Control_Album_Name.Size = new Size(0, 20);
            lbl_Control_Album_Name.TabIndex = 3;
            // 
            // lbl_Control_Track_Name
            // 
            lbl_Control_Track_Name.AutoSize = true;
            lbl_Control_Track_Name.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Control_Track_Name.Location = new Point(124, 5);
            lbl_Control_Track_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Control_Track_Name.MaximumSize = new Size(233, 29);
            lbl_Control_Track_Name.Name = "lbl_Control_Track_Name";
            lbl_Control_Track_Name.Size = new Size(130, 25);
            lbl_Control_Track_Name.TabIndex = 2;
            lbl_Control_Track_Name.Text = "Select A Track";
            // 
            // tkb_Control_Time_Bar
            // 
            tkb_Control_Time_Bar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            tkb_Control_Time_Bar.Location = new Point(349, 5);
            tkb_Control_Time_Bar.Margin = new System.Windows.Forms.Padding(0);
            tkb_Control_Time_Bar.Maximum = 100;
            tkb_Control_Time_Bar.Name = "tkb_Control_Time_Bar";
            tkb_Control_Time_Bar.Size = new Size(638, 45);
            tkb_Control_Time_Bar.TabIndex = 1;
            tkb_Control_Time_Bar.TickStyle = System.Windows.Forms.TickStyle.Both;
            tkb_Control_Time_Bar.Scroll += tkb_Control_Time_Bar_Scroll;
            // 
            // pic_Control_Album_Cover
            // 
            pic_Control_Album_Cover.InitialImage = null;
            pic_Control_Album_Cover.Location = new Point(4, 3);
            pic_Control_Album_Cover.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pic_Control_Album_Cover.Name = "pic_Control_Album_Cover";
            pic_Control_Album_Cover.Size = new Size(112, 111);
            pic_Control_Album_Cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic_Control_Album_Cover.TabIndex = 0;
            pic_Control_Album_Cover.TabStop = false;
            // 
            // cms_Track_Menu
            // 
            cms_Track_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_Add_To_Playlist, tsmi_Remove_From_Playlist });
            cms_Track_Menu.Name = "contextMenuStrip1";
            cms_Track_Menu.Size = new Size(189, 48);
            // 
            // tsmi_Add_To_Playlist
            // 
            tsmi_Add_To_Playlist.Name = "tsmi_Add_To_Playlist";
            tsmi_Add_To_Playlist.Size = new Size(188, 22);
            tsmi_Add_To_Playlist.Text = "Add to Playlist";
            // 
            // tsmi_Remove_From_Playlist
            // 
            tsmi_Remove_From_Playlist.Enabled = false;
            tsmi_Remove_From_Playlist.Name = "tsmi_Remove_From_Playlist";
            tsmi_Remove_From_Playlist.Size = new Size(188, 22);
            tsmi_Remove_From_Playlist.Text = "Remove From Playlist";
            tsmi_Remove_From_Playlist.Click += tsmi_Remove_From_Playlist_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 36, 37);
            ClientSize = new Size(1002, 519);
            Controls.Add(pnl_Song_Control);
            Controls.Add(tab_Page_Select);
            ForeColor = Color.WhiteSmoke;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "The Bester Music App";
            Load += Form1_Load;
            tab_Page_Select.ResumeLayout(false);
            tp_Tracks.ResumeLayout(false);
            tp_Albums.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tp_Artists.ResumeLayout(false);
            tp_Playlists.ResumeLayout(false);
            tp_Settings.ResumeLayout(false);
            pnl_Song_Control.ResumeLayout(false);
            pnl_Song_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tkb_Control_Volume).EndInit();
            ((System.ComponentModel.ISupportInitialize)tkb_Control_Time_Bar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Control_Album_Cover).EndInit();
            cms_Track_Menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tab_Page_Select;
        private System.Windows.Forms.TabPage tp_Tracks;
        private System.Windows.Forms.TabPage tp_Albums;
        private System.Windows.Forms.TabPage tp_Playlists;
        private System.Windows.Forms.Panel pnl_Song_Control;
        private System.Windows.Forms.ListView lv_Tracks_Track_List;
        private System.Windows.Forms.ColumnHeader Tracks_No;
        private System.Windows.Forms.ColumnHeader Tracks_Track;
        private System.Windows.Forms.ColumnHeader Tracks_Album;
        private System.Windows.Forms.ColumnHeader Tracks_Artist;
        private System.Windows.Forms.ColumnHeader Track_Time;
        private System.Windows.Forms.ListView lv_Albums_Track_List;
        private System.Windows.Forms.ColumnHeader Albums_No;
        private System.Windows.Forms.ColumnHeader Albums_Track;
        private System.Windows.Forms.ColumnHeader Albums_Artist;
        private System.Windows.Forms.ColumnHeader Albums_Length;
        private System.Windows.Forms.ListView lv_Albums_Album_List;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColumnHeader Albums_Album;
        private System.Windows.Forms.PictureBox pic_Control_Album_Cover;
        private System.Windows.Forms.TrackBar tkb_Control_Time_Bar;
        private System.Windows.Forms.Label lbl_Control_Track_Name;
        private System.Windows.Forms.Label lbl_Control_Album_Name;
        private System.Windows.Forms.Label lbl_Control_Artist_Name;
        private System.Windows.Forms.Label lbl_Control_Track_Duration;
        private System.Windows.Forms.Button btn_Control_Play_Button;
        private System.Windows.Forms.Button btn_Control_Next_Button;
        private System.Windows.Forms.Button btn_Control_Previous_Button;
        private System.Windows.Forms.Button btn_Control_Mode_Change;
        private System.Windows.Forms.Timer tmr_Track_Timer;
        private System.Windows.Forms.TabPage tp_Artists;
        private System.Windows.Forms.ListView lv_Artists_Artist_List;
        private System.Windows.Forms.ListView lv_Artists_Track_List;
        private System.Windows.Forms.ColumnHeader Artists_No;
        private System.Windows.Forms.ColumnHeader Artists_Track;
        private System.Windows.Forms.ColumnHeader Artists_Album;
        private System.Windows.Forms.ColumnHeader Artists_Artist;
        private System.Windows.Forms.ColumnHeader Artists_Length;
        private System.Windows.Forms.TrackBar tkb_Control_Volume;
        private System.Windows.Forms.TabPage tp_Settings;
        private System.Windows.Forms.Button btn_Update_Tracks;
        private System.Windows.Forms.ListView lv_Playlists_Playlist_List;
        private System.Windows.Forms.ListView lv_Tracks_Most_Popular;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lv_Playlists_Track_List;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btn_New_Playlist;
        private System.Windows.Forms.ContextMenuStrip cms_Track_Menu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Add_To_Playlist;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Remove_From_Playlist;
    }
}

