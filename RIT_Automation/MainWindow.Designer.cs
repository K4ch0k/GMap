
namespace RIT_Automation
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.MainGMap = new GMap.NET.WindowsForms.GMapControl();
            this.MainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateMarkerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMarkerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoContextMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.MapProviderCombo = new System.Windows.Forms.ComboBox();
            this.textBoxToolTip = new System.Windows.Forms.TextBox();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.textBoxLng = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.SqlConnprogressBar = new System.Windows.Forms.ProgressBar();
            this.SqlConnTimer = new System.Windows.Forms.Timer(this.components);
            this.BackgroundMap = new System.Windows.Forms.PictureBox();
            this.TxtBackgroundImg = new System.Windows.Forms.Label();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.MainContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundMap)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGMap
            // 
            this.MainGMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainGMap.Bearing = 0F;
            this.MainGMap.CanDragMap = true;
            this.MainGMap.ContextMenuStrip = this.MainContextMenu;
            this.MainGMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainGMap.GrayScaleMode = false;
            this.MainGMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainGMap.LevelsKeepInMemmory = 5;
            this.MainGMap.Location = new System.Drawing.Point(5, 5);
            this.MainGMap.MarkersEnabled = true;
            this.MainGMap.MaxZoom = 2;
            this.MainGMap.MinZoom = 2;
            this.MainGMap.MouseWheelZoomEnabled = true;
            this.MainGMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainGMap.Name = "MainGMap";
            this.MainGMap.NegativeMode = false;
            this.MainGMap.PolygonsEnabled = true;
            this.MainGMap.RetryLoadTile = 0;
            this.MainGMap.RoutesEnabled = true;
            this.MainGMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainGMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainGMap.ShowTileGridLines = false;
            this.MainGMap.Size = new System.Drawing.Size(875, 350);
            this.MainGMap.TabIndex = 0;
            this.MainGMap.Visible = false;
            this.MainGMap.Zoom = 0D;
            this.MainGMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.MainGMap_OnMarkerClick);
            this.MainGMap.Load += new System.EventHandler(this.MainGMap_Load);
            this.MainGMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainGMap_MouseDoubleClick);
            this.MainGMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainGMap_MouseDown);
            this.MainGMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainGMap_MouseMove);
            this.MainGMap.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainGMap_PreviewKeyDown);
            // 
            // MainContextMenu
            // 
            this.MainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMarkerBtn,
            this.DeleteMarkerBtn,
            this.InfoContextMenuBtn});
            this.MainContextMenu.Name = "contextMenuStrip1";
            this.MainContextMenu.Size = new System.Drawing.Size(176, 70);
            this.MainContextMenu.Text = "Действия";
            // 
            // CreateMarkerBtn
            // 
            this.CreateMarkerBtn.Name = "CreateMarkerBtn";
            this.CreateMarkerBtn.Size = new System.Drawing.Size(175, 22);
            this.CreateMarkerBtn.Text = "Поставить маркер";
            this.CreateMarkerBtn.Click += new System.EventHandler(this.CreateMarkerBtn_Click);
            // 
            // DeleteMarkerBtn
            // 
            this.DeleteMarkerBtn.Name = "DeleteMarkerBtn";
            this.DeleteMarkerBtn.Size = new System.Drawing.Size(175, 22);
            this.DeleteMarkerBtn.Text = "Удалить маркер";
            this.DeleteMarkerBtn.Visible = false;
            this.DeleteMarkerBtn.Click += new System.EventHandler(this.DeleteMarkerBtn_Click);
            // 
            // InfoContextMenuBtn
            // 
            this.InfoContextMenuBtn.Name = "InfoContextMenuBtn";
            this.InfoContextMenuBtn.Size = new System.Drawing.Size(175, 22);
            this.InfoContextMenuBtn.Text = "Справка";
            this.InfoContextMenuBtn.Click += new System.EventHandler(this.InfoContextMenuBtn_Click);
            // 
            // MapProviderCombo
            // 
            this.MapProviderCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MapProviderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapProviderCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapProviderCombo.FormattingEnabled = true;
            this.MapProviderCombo.Location = new System.Drawing.Point(5, 371);
            this.MapProviderCombo.Name = "MapProviderCombo";
            this.MapProviderCombo.Size = new System.Drawing.Size(144, 28);
            this.MapProviderCombo.TabIndex = 1;
            this.MapProviderCombo.Visible = false;
            this.MapProviderCombo.SelectedValueChanged += new System.EventHandler(this.MapProviderCombo_SelectedValueChanged);
            // 
            // textBoxToolTip
            // 
            this.textBoxToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxToolTip.Location = new System.Drawing.Point(531, 363);
            this.textBoxToolTip.MaxLength = 50;
            this.textBoxToolTip.Multiline = true;
            this.textBoxToolTip.Name = "textBoxToolTip";
            this.textBoxToolTip.Size = new System.Drawing.Size(159, 45);
            this.textBoxToolTip.TabIndex = 2;
            this.textBoxToolTip.Visible = false;
            this.textBoxToolTip.TextChanged += new System.EventHandler(this.textBoxToolTip_TextChanged);
            // 
            // textBoxLat
            // 
            this.textBoxLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLat.Location = new System.Drawing.Point(780, 361);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(100, 22);
            this.textBoxLat.TabIndex = 3;
            this.textBoxLat.Visible = false;
            this.textBoxLat.TextChanged += new System.EventHandler(this.textBoxLat_TextChanged);
            this.textBoxLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLat_KeyPress);
            // 
            // textBoxLng
            // 
            this.textBoxLng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLng.Location = new System.Drawing.Point(780, 387);
            this.textBoxLng.Name = "textBoxLng";
            this.textBoxLng.Size = new System.Drawing.Size(100, 22);
            this.textBoxLng.TabIndex = 4;
            this.textBoxLng.Visible = false;
            this.textBoxLng.TextChanged += new System.EventHandler(this.textBoxLng_TextChanged);
            this.textBoxLng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLat_KeyPress);
            // 
            // labelY
            // 
            this.labelY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY.Location = new System.Drawing.Point(703, 388);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(71, 20);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "Широта:";
            this.labelY.Visible = false;
            // 
            // labelX
            // 
            this.labelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.Location = new System.Drawing.Point(696, 361);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(78, 20);
            this.labelX.TabIndex = 6;
            this.labelX.Text = "Долгота:";
            this.labelX.Visible = false;
            // 
            // SqlConnprogressBar
            // 
            this.SqlConnprogressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SqlConnprogressBar.Location = new System.Drawing.Point(208, 371);
            this.SqlConnprogressBar.Maximum = 15;
            this.SqlConnprogressBar.Name = "SqlConnprogressBar";
            this.SqlConnprogressBar.Size = new System.Drawing.Size(407, 23);
            this.SqlConnprogressBar.Step = 1;
            this.SqlConnprogressBar.TabIndex = 7;
            // 
            // SqlConnTimer
            // 
            this.SqlConnTimer.Enabled = true;
            this.SqlConnTimer.Interval = 1000;
            this.SqlConnTimer.Tick += new System.EventHandler(this.SqlConnTimer_Tick);
            // 
            // BackgroundMap
            // 
            this.BackgroundMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundMap.BackColor = System.Drawing.Color.Silver;
            this.BackgroundMap.Location = new System.Drawing.Point(5, 5);
            this.BackgroundMap.Name = "BackgroundMap";
            this.BackgroundMap.Size = new System.Drawing.Size(867, 350);
            this.BackgroundMap.TabIndex = 8;
            this.BackgroundMap.TabStop = false;
            // 
            // TxtBackgroundImg
            // 
            this.TxtBackgroundImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBackgroundImg.AutoSize = true;
            this.TxtBackgroundImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TxtBackgroundImg.Location = new System.Drawing.Point(335, 187);
            this.TxtBackgroundImg.Name = "TxtBackgroundImg";
            this.TxtBackgroundImg.Size = new System.Drawing.Size(167, 20);
            this.TxtBackgroundImg.TabIndex = 9;
            this.TxtBackgroundImg.Text = "Подключение к БД...";
            // 
            // HelpLabel
            // 
            this.HelpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.HelpLabel.Location = new System.Drawing.Point(155, 371);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(24, 25);
            this.HelpLabel.TabIndex = 10;
            this.HelpLabel.Text = "?";
            this.HelpLabel.MouseHover += new System.EventHandler(this.HelpLabel_MouseHover);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.HelpLabel);
            this.Controls.Add(this.TxtBackgroundImg);
            this.Controls.Add(this.BackgroundMap);
            this.Controls.Add(this.SqlConnprogressBar);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.textBoxLng);
            this.Controls.Add(this.textBoxLat);
            this.Controls.Add(this.textBoxToolTip);
            this.Controls.Add(this.MapProviderCombo);
            this.Controls.Add(this.MainGMap);
            this.MinimumSize = new System.Drawing.Size(550, 450);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RIT Automation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MainContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MainGMap;
        private System.Windows.Forms.ComboBox MapProviderCombo;
        private System.Windows.Forms.ContextMenuStrip MainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem InfoContextMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem CreateMarkerBtn;
        private System.Windows.Forms.TextBox textBoxToolTip;
        private System.Windows.Forms.TextBox textBoxLat;
        private System.Windows.Forms.TextBox textBoxLng;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.ToolStripMenuItem DeleteMarkerBtn;
        private System.Windows.Forms.ProgressBar SqlConnprogressBar;
        private System.Windows.Forms.Timer SqlConnTimer;
        private System.Windows.Forms.PictureBox BackgroundMap;
        private System.Windows.Forms.Label TxtBackgroundImg;
        private System.Windows.Forms.Label HelpLabel;
    }
}