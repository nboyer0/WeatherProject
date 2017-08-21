namespace WeatherRadar
{
    partial class MapSettings
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
            this.mapCmbox = new System.Windows.Forms.ComboBox();
            this.accessCmbox = new System.Windows.Forms.ComboBox();
            this.mapProviderLbl = new System.Windows.Forms.Label();
            this.accessModeLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapCmbox
            // 
            this.mapCmbox.FormattingEnabled = true;
            this.mapCmbox.Items.AddRange(new object[] {
            "Bing",
            "Google",
            "Yahoo",
            "Cloud",
            "OpenCycle",
            "OpenStreet",
            "Wiki"});
            this.mapCmbox.Location = new System.Drawing.Point(131, 32);
            this.mapCmbox.Name = "mapCmbox";
            this.mapCmbox.Size = new System.Drawing.Size(246, 24);
            this.mapCmbox.TabIndex = 0;
            this.mapCmbox.SelectedIndexChanged += new System.EventHandler(this.mapCmbox_SelectedIndexChanged);
            // 
            // accessCmbox
            // 
            this.accessCmbox.FormattingEnabled = true;
            this.accessCmbox.Items.AddRange(new object[] {
            "Server",
            "Server and Cache",
            "Cache"});
            this.accessCmbox.Location = new System.Drawing.Point(131, 80);
            this.accessCmbox.Name = "accessCmbox";
            this.accessCmbox.Size = new System.Drawing.Size(246, 24);
            this.accessCmbox.TabIndex = 1;
            this.accessCmbox.SelectedIndexChanged += new System.EventHandler(this.accessCmbox_SelectedIndexChanged);
            // 
            // mapProviderLbl
            // 
            this.mapProviderLbl.AutoSize = true;
            this.mapProviderLbl.Location = new System.Drawing.Point(28, 32);
            this.mapProviderLbl.Name = "mapProviderLbl";
            this.mapProviderLbl.Size = new System.Drawing.Size(92, 17);
            this.mapProviderLbl.TabIndex = 2;
            this.mapProviderLbl.Text = "Map Provider";
            // 
            // accessModeLbl
            // 
            this.accessModeLbl.AutoEllipsis = true;
            this.accessModeLbl.AutoSize = true;
            this.accessModeLbl.Location = new System.Drawing.Point(28, 87);
            this.accessModeLbl.Name = "accessModeLbl";
            this.accessModeLbl.Size = new System.Drawing.Size(92, 17);
            this.accessModeLbl.TabIndex = 3;
            this.accessModeLbl.Text = "Access Mode";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(224, 129);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(153, 34);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(31, 129);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(159, 34);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // MapSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 184);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.accessModeLbl);
            this.Controls.Add(this.mapProviderLbl);
            this.Controls.Add(this.accessCmbox);
            this.Controls.Add(this.mapCmbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapSettings";
            this.Text = "MapSettings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MapSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mapCmbox;
        private System.Windows.Forms.ComboBox accessCmbox;
        private System.Windows.Forms.Label mapProviderLbl;
        private System.Windows.Forms.Label accessModeLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}