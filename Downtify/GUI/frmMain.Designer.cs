using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Downtify.GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxTracks = new System.Windows.Forms.ListBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.textBoxLink = new Downtify.GUI.PlaceholderTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBoxAlbumCover = new System.Windows.Forms.PictureBox();
            this.labelTite = new System.Windows.Forms.Label();
            this.labelAlbum = new System.Windows.Forms.Label();
            this.labelArtist = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDurationText = new System.Windows.Forms.Label();
            this.labelDurationTextValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTracks
            // 
            this.listBoxTracks.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTracks.FormattingEnabled = true;
            this.listBoxTracks.ItemHeight = 16;
            this.listBoxTracks.Location = new System.Drawing.Point(11, 40);
            this.listBoxTracks.Name = "listBoxTracks";
            this.listBoxTracks.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxTracks.Size = new System.Drawing.Size(494, 196);
            this.listBoxTracks.TabIndex = 0;
            this.listBoxTracks.SelectedIndexChanged += new System.EventHandler(this.listBoxTracks_SelectedIndexChanged);
            this.listBoxTracks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxTracks_KeyDown);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDownload.Location = new System.Drawing.Point(399, 241);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(106, 23);
            this.buttonDownload.TabIndex = 2;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // textBoxLink
            // 
            this.textBoxLink.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLink.Location = new System.Drawing.Point(12, 12);
            this.textBoxLink.Multiline = true;
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Placeholder = "Put your track or playlist link here";
            this.textBoxLink.Size = new System.Drawing.Size(493, 20);
            this.textBoxLink.TabIndex = 1;
            this.textBoxLink.Text = "https://open.spotify.com/track/39dqDqHv63oMoogN6sgITQ\r\nhttps://open.spotify.com/t" +
    "rack/5treNJZ0gCdEO3EcWp9aDu";
            this.textBoxLink.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLink_KeyPress);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 241);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(381, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // pictureBoxAlbumCover
            // 
            this.pictureBoxAlbumCover.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAlbumCover.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBoxAlbumCover.Location = new System.Drawing.Point(39, 19);
            this.pictureBoxAlbumCover.Name = "pictureBoxAlbumCover";
            this.pictureBoxAlbumCover.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxAlbumCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAlbumCover.TabIndex = 4;
            this.pictureBoxAlbumCover.TabStop = false;
            // 
            // labelTite
            // 
            this.labelTite.AutoEllipsis = true;
            this.labelTite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTite.Location = new System.Drawing.Point(5, 179);
            this.labelTite.Name = "labelTite";
            this.labelTite.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelTite.Size = new System.Drawing.Size(221, 15);
            this.labelTite.TabIndex = 6;
            this.labelTite.Text = "Title";
            this.labelTite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAlbum
            // 
            this.labelAlbum.AutoEllipsis = true;
            this.labelAlbum.Location = new System.Drawing.Point(3, 205);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelAlbum.Size = new System.Drawing.Size(223, 19);
            this.labelAlbum.TabIndex = 7;
            this.labelAlbum.Text = "Album";
            this.labelAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelArtist
            // 
            this.labelArtist.AutoEllipsis = true;
            this.labelArtist.Location = new System.Drawing.Point(2, 229);
            this.labelArtist.Name = "labelArtist";
            this.labelArtist.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.labelArtist.Size = new System.Drawing.Size(224, 20);
            this.labelArtist.TabIndex = 7;
            this.labelArtist.Text = "Artist";
            this.labelArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxAlbumCover);
            this.groupBox1.Controls.Add(this.labelArtist);
            this.groupBox1.Controls.Add(this.labelTite);
            this.groupBox1.Controls.Add(this.labelAlbum);
            this.groupBox1.Location = new System.Drawing.Point(524, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 252);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Track";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMain});
            this.statusStripMain.Location = new System.Drawing.Point(0, 321);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(759, 22);
            this.statusStripMain.TabIndex = 9;
            this.statusStripMain.Text = "Ready";
            // 
            // toolStripStatusLabelMain
            // 
            this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            this.toolStripStatusLabelMain.Size = new System.Drawing.Size(0, 17);
            // 
            // labelDurationText
            // 
            this.labelDurationText.AutoSize = true;
            this.labelDurationText.Location = new System.Drawing.Point(12, 285);
            this.labelDurationText.Name = "labelDurationText";
            this.labelDurationText.Size = new System.Drawing.Size(128, 13);
            this.labelDurationText.TabIndex = 10;
            this.labelDurationText.Text = "Selected Songs Duration:";
            // 
            // labelDurationTextValue
            // 
            this.labelDurationTextValue.AutoSize = true;
            this.labelDurationTextValue.Location = new System.Drawing.Point(146, 285);
            this.labelDurationTextValue.Name = "labelDurationTextValue";
            this.labelDurationTextValue.Size = new System.Drawing.Size(49, 13);
            this.labelDurationTextValue.TabIndex = 10;
            this.labelDurationTextValue.Text = "00:00:00";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 343);
            this.Controls.Add(this.labelDurationTextValue);
            this.Controls.Add(this.labelDurationText);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.textBoxLink);
            this.Controls.Add(this.listBoxTracks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downtify";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumCover)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBoxTracks;
        private PlaceholderTextBox textBoxLink;
        private Button buttonDownload;
        private ProgressBar progressBar1;
        private PictureBox pictureBoxAlbumCover;
        private Label labelTite;
        private Label labelAlbum;
        private Label labelArtist;
        private GroupBox groupBox1;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusLabelMain;
        private Label labelDurationText;
        private Label labelDurationTextValue;
    }
}

