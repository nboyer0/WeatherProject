namespace WeatherRadar
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wichitaKSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kansasCityKSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outlooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.WindcheckBox1 = new System.Windows.Forms.CheckBox();
            this.HailcheckBox = new System.Windows.Forms.CheckBox();
            this.TornadocheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flightLbl = new System.Windows.Forms.Label();
            this.ksuCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 1011);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1902, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.siteToolStripMenuItem,
            this.outlooksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // siteToolStripMenuItem
            // 
            this.siteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wichitaKSToolStripMenuItem,
            this.kansasCityKSToolStripMenuItem,
            this.chooseSiteToolStripMenuItem});
            this.siteToolStripMenuItem.Name = "siteToolStripMenuItem";
            this.siteToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.siteToolStripMenuItem.Text = "Site";
            // 
            // wichitaKSToolStripMenuItem
            // 
            this.wichitaKSToolStripMenuItem.Name = "wichitaKSToolStripMenuItem";
            this.wichitaKSToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.wichitaKSToolStripMenuItem.Text = "Wichita, KS";
            this.wichitaKSToolStripMenuItem.Click += new System.EventHandler(this.wichitaKSToolStripMenuItem_Click);
            // 
            // kansasCityKSToolStripMenuItem
            // 
            this.kansasCityKSToolStripMenuItem.Name = "kansasCityKSToolStripMenuItem";
            this.kansasCityKSToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.kansasCityKSToolStripMenuItem.Text = "Kansas City, KS";
            this.kansasCityKSToolStripMenuItem.Click += new System.EventHandler(this.kansasCityKSToolStripMenuItem_Click);
            // 
            // chooseSiteToolStripMenuItem
            // 
            this.chooseSiteToolStripMenuItem.Name = "chooseSiteToolStripMenuItem";
            this.chooseSiteToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.chooseSiteToolStripMenuItem.Text = "Choose Site";
            this.chooseSiteToolStripMenuItem.Click += new System.EventHandler(this.chooseSiteToolStripMenuItem_Click);
            // 
            // outlooksToolStripMenuItem
            // 
            this.outlooksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dayToolStripMenuItem,
            this.dayToolStripMenuItem1,
            this.dayToolStripMenuItem2});
            this.outlooksToolStripMenuItem.Name = "outlooksToolStripMenuItem";
            this.outlooksToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.outlooksToolStripMenuItem.Text = "Outlooks";
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.dayToolStripMenuItem.Text = "1 Day Outlook";
            this.dayToolStripMenuItem.Click += new System.EventHandler(this.dayToolStripMenuItem_Click);
            // 
            // dayToolStripMenuItem1
            // 
            this.dayToolStripMenuItem1.Name = "dayToolStripMenuItem1";
            this.dayToolStripMenuItem1.Size = new System.Drawing.Size(179, 26);
            this.dayToolStripMenuItem1.Text = "2 Day Outlook";
            this.dayToolStripMenuItem1.Click += new System.EventHandler(this.dayToolStripMenuItem1_Click);
            // 
            // dayToolStripMenuItem2
            // 
            this.dayToolStripMenuItem2.Name = "dayToolStripMenuItem2";
            this.dayToolStripMenuItem2.Size = new System.Drawing.Size(179, 26);
            this.dayToolStripMenuItem2.Text = "3 Day Outlook";
            this.dayToolStripMenuItem2.Click += new System.EventHandler(this.dayToolStripMenuItem2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1902, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gmap);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1902, 958);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 3;
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(3, 3);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 5;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1562, 934);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 8D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gmap_OnPolygonClick);
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // WindcheckBox1
            // 
            this.WindcheckBox1.AutoSize = true;
            this.WindcheckBox1.Checked = true;
            this.WindcheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WindcheckBox1.Location = new System.Drawing.Point(117, 31);
            this.WindcheckBox1.Name = "WindcheckBox1";
            this.WindcheckBox1.Size = new System.Drawing.Size(62, 21);
            this.WindcheckBox1.TabIndex = 4;
            this.WindcheckBox1.Text = "Wind";
            this.WindcheckBox1.UseVisualStyleBackColor = true;
            this.WindcheckBox1.CheckedChanged += new System.EventHandler(this.WindcheckBox1_CheckedChanged);
            // 
            // HailcheckBox
            // 
            this.HailcheckBox.AutoSize = true;
            this.HailcheckBox.Checked = true;
            this.HailcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HailcheckBox.Location = new System.Drawing.Point(185, 31);
            this.HailcheckBox.Name = "HailcheckBox";
            this.HailcheckBox.Size = new System.Drawing.Size(54, 21);
            this.HailcheckBox.TabIndex = 5;
            this.HailcheckBox.Text = "Hail";
            this.HailcheckBox.UseVisualStyleBackColor = true;
            this.HailcheckBox.CheckStateChanged += new System.EventHandler(this.HailcheckBox_CheckStateChanged);
            // 
            // TornadocheckBox
            // 
            this.TornadocheckBox.AutoSize = true;
            this.TornadocheckBox.Checked = true;
            this.TornadocheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TornadocheckBox.Location = new System.Drawing.Point(245, 31);
            this.TornadocheckBox.Name = "TornadocheckBox";
            this.TornadocheckBox.Size = new System.Drawing.Size(84, 21);
            this.TornadocheckBox.TabIndex = 6;
            this.TornadocheckBox.Text = "Tornado";
            this.TornadocheckBox.UseVisualStyleBackColor = true;
            this.TornadocheckBox.CheckStateChanged += new System.EventHandler(this.TornadocheckBox_CheckStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Storm Reports";
            // 
            // flightLbl
            // 
            this.flightLbl.AutoSize = true;
            this.flightLbl.Location = new System.Drawing.Point(335, 32);
            this.flightLbl.Name = "flightLbl";
            this.flightLbl.Size = new System.Drawing.Size(100, 17);
            this.flightLbl.TabIndex = 8;
            this.flightLbl.Text = "Current Flights";
            // 
            // ksuCheckBox
            // 
            this.ksuCheckBox.AutoSize = true;
            this.ksuCheckBox.BackColor = System.Drawing.SystemColors.Control;
            this.ksuCheckBox.Location = new System.Drawing.Point(441, 31);
            this.ksuCheckBox.Name = "ksuCheckBox";
            this.ksuCheckBox.Size = new System.Drawing.Size(93, 21);
            this.ksuCheckBox.TabIndex = 9;
            this.ksuCheckBox.Text = "KSU Fleet";
            this.ksuCheckBox.UseVisualStyleBackColor = false;
            this.ksuCheckBox.CheckStateChanged += new System.EventHandler(this.ksuCheckBox_CheckStateChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.ksuCheckBox);
            this.Controls.Add(this.flightLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TornadocheckBox);
            this.Controls.Add(this.HailcheckBox);
            this.Controls.Add(this.WindcheckBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Weather Radar";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem wichitaKSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kansasCityKSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.ToolStripMenuItem outlooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem2;
        private System.Windows.Forms.CheckBox WindcheckBox1;
        private System.Windows.Forms.CheckBox HailcheckBox;
        private System.Windows.Forms.CheckBox TornadocheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label flightLbl;
        private System.Windows.Forms.CheckBox ksuCheckBox;
    }
}

