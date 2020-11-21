using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifySharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Downtify.GUI
{
    public partial class frmMain : Form
    {
        public const string NoText = "-";
        public const string StatusTextReady = "";
        public const string StatusTextInvalidLink = "Invalid Spotify link";
        public const string StatusTextUpdatingTrackInfo = "Updating track info...";

        SpotifyDownloader downloader;
        private long _totalDuration = 0;
        public static XmlConfiguration configuration;
        public static LanguageXML lang;

        public frmMain()
        {
            InitializeComponent();

            downloader = new SpotifyDownloader();
            configuration = new XmlConfiguration("config.xml");
            downloader.OnLoginResult += OnLoginResult;
            downloader.OnDownloadComplete += downloader_OnDownloadComplete;
            downloader.OnDownloadProgress += downloader_OnDownloadProgress;
        }

        // Very ugly, todo: move parts of this to the downloader class
        private void downloader_OnDownloadComplete(bool successfully)
        {
            var list = new object[listBoxTracks.SelectedItems.Count];
            for (int i = 1; i < listBoxTracks.SelectedItems.Count; i++)
                list[i - 1] = listBoxTracks.SelectedItems[i];

            listBoxTracks.SelectedItems.Clear();

            foreach (var track in list)
                listBoxTracks.SelectedItems.Add(track);

            if (listBoxTracks.SelectedItems.Count == 0)
            {
                listBoxTracks.SelectedItems.Clear();
                MessageBox.Show(lang.GetString("download/done"));
                EnableControls(true);
                return;
            }

            downloader.Download(((TrackItem)listBoxTracks.SelectedItems[0]).Track);
        }

        private void downloader_OnDownloadProgress(int value)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (value > 100 || value < 0)
                    return;

                progressBar1.Value = value;
            });
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            EnableControls(false);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            this.Activate();

            ClearTrackInfo();

            // very ugly, use config parser (json for example) would be nicer
            string username = "", password = "";
            configuration.LoadConfigurationFile();
            TransferConfig();
            username = configuration.GetConfiguration("username");
            password = configuration.GetConfiguration("password");
            lang = new LanguageXML(configuration.GetConfiguration("language"));

            textBoxLink.Placeholder = lang.GetString("download/paste_uri");

            downloader.Login(username, password);
        }

        private void TransferConfig()
        {
            if (File.Exists("config.txt"))
            {
                string username = "", password = "";
                foreach (var currentLine in File.ReadAllLines("config.txt"))
                {
                    var line = currentLine.Trim();
                    if (line.StartsWith("#"))
                        continue;

                    if (line.StartsWith("username"))
                        username = line.Split('"')[1].Split('"')[0];
                    else if (line.StartsWith("password"))
                        password = line.Split('"')[1].Split('"')[0];
                }
                if (configuration.GetConfiguration("username") == "USERNAME")
                    configuration.SetConfigurationEntry("username", username);
                if (configuration.GetConfiguration("password") == "PASSWORD")
                    configuration.SetConfigurationEntry("password", password);
                configuration.SaveConfigurationFile();
                File.Delete("config.txt");
            }
        }

        private void OnLoginResult(bool isLoggedIn)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show(lang.GetString("error/no_premium"), lang.GetString("title/error"));
                Application.Exit();
                return;
            }

            EnableControls(true);
        }

        private void EnableControls(bool enable)
        {
            foreach (var control in this.Controls)
                ((Control)control).Enabled = enable;
        }

        private async Task FetchSongsFromUrl(string text)
        {

            string[] urls = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string url in urls) {

                var link = SpotifyDownloader.SpotifyUrlToUri(url);

                try
                {
                    EnableControls(false);

                    //Validate pasted URI
                    //                if((link.Length > 0 && !link.ToLower().StartsWith("spotify:")))
                    //                {
                    //                    MessageBox.Show(lang.GetString("download/invalid_uri"));
                    //                    textBoxLink.Clear();
                    //                    SetStatusStripLabelText(StatusTextInvalidLink);
                    //                    return;
                    //                }

                    SetStatusStripLabelText(StatusTextReady);

                    if (link.ToLower().Contains("playlist"))
                    {
                        var playlist = await downloader.FetchPlaylist(link);
                        for (int i = 0; i < playlist.NumTracks(); i++)
                            listBoxTracks.Items.Add(new TrackItem(playlist.Track(i)));
                        int a = playlist.NumTracks();
                        textBoxLink.Clear();
                    }
                    else if (link.ToLower().Contains("track"))
                    {
                        var track = await downloader.FetchTrack(link);
                        listBoxTracks.Items.Add(new TrackItem(track));
                        textBoxLink.Clear();
                    }
                    else if (link.ToLower().Contains("album"))
                    {
                        var album = await downloader.FetchAlbum(link);
                        for (int i = 0; i < album.NumTracks(); i++)
                            listBoxTracks.Items.Add(new TrackItem(album.Track(i)));
                        textBoxLink.Clear();
                    }
                    else
                    {
                        SetStatusStripLabelText(StatusTextInvalidLink);
                    }
                }
                catch (NullReferenceException)
                {
                    SetStatusStripLabelText(StatusTextInvalidLink);
                }
                finally
                {
                    EnableControls(true);
                }
            }
        }

        private void listBoxTracks_KeyDown(object sender, KeyEventArgs e)
        {

            ClearTrackInfo();

            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxTracks.SelectedItems.Count == 0)
                    return;

                var list = new TrackItem[listBoxTracks.SelectedItems.Count];
                listBoxTracks.SelectedItems.CopyTo(list, 0);

                foreach (var track in list)
                    listBoxTracks.Items.Remove(track);
            }
            else if (e.KeyCode == Keys.A && e.Control)
            {
                var list = new TrackItem[listBoxTracks.Items.Count];
                listBoxTracks.Items.CopyTo(list, 0);

                listBoxTracks.SelectedItems.Clear();
                foreach (var track in list)
                    listBoxTracks.SelectedItems.Add(track);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (listBoxTracks.SelectedItems.Count == 0)
            {
                MessageBox.Show(lang.GetString("error/no_download_selection"), lang.GetString("title/error"));
                return;
            }

            EnableControls(false);
            downloader.Download(((TrackItem)listBoxTracks.SelectedItems[0]).Track);
        }

        private async void listBoxTracks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _totalDuration = 0;

            if (listBoxTracks.SelectedItem == null)
            {
                UpdateTrackInfo(null, null);
                UpdateTotalDuration();
                SetStatusStripLabelText(StatusTextReady);
                return;
            }

            Track track = null;
            for (var i = 0; i < listBoxTracks.SelectedIndices.Count; i++)
            {
                track = ((TrackItem)listBoxTracks.SelectedItems[i]).Track;
                _totalDuration += track.Duration();
            }

            UpdateTotalDuration();

            if (toolStripStatusLabelMain.Text != StatusTextUpdatingTrackInfo && listBoxTracks.SelectedIndices.Count == 1)
            {
                Debug.WriteLine("in listBoxTracks_SelectedIndexChanged");
                SetStatusStripLabelText(StatusTextUpdatingTrackInfo);
                var bmp = await downloader.DownloadImage(((TrackItem)listBoxTracks.SelectedItem).Track, 1);
                UpdateTrackInfo(track, bmp);
            }

            SetStatusStripLabelText(StatusTextReady);

        }

        private void UpdateTrackInfo(Track track, Bitmap bmp)
        {
            pictureBoxAlbumCover.Image = track == null ? null : bmp;
            labelTite.Text = track == null ? "-" : track.Name();
            labelAlbum.Text = track == null ? "-" : track.Album().Name();
            labelArtist.Text = track == null ? "-" : SpotifyDownloader.GetTrackArtistsNames(track);
        }

        private void ClearTrackInfo()
        {
            pictureBoxAlbumCover.Image = null;
            labelTite.Text = NoText;
            labelAlbum.Text = NoText;
            labelArtist.Text = NoText;
        }

        private void SetStatusStripLabelText(string test)
        {
            toolStripStatusLabelMain.Text = test;
        }

        private async void textBoxLink_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                await FetchSongsFromUrl(textBoxLink.Text);
            }
        }

        private void UpdateTotalDuration()
        {
            labelDurationTextValue.Text = TimeSpan.FromMilliseconds(_totalDuration).ToString(@"hh\:mm\:ss");
        }
    }
}
