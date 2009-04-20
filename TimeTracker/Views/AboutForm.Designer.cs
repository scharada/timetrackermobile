namespace TimeTracker.Views
{
    partial class AboutForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblAuthorDesc = new System.Windows.Forms.Label();
            this.lblVersionDesc = new System.Windows.Forms.Label();
            this.lnkCodeURL = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Italic);
            this.lblTitle.Location = new System.Drawing.Point(16, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 25);
            this.lblTitle.Text = "Time Tracker Mobile";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(20, 90);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(49, 20);
            this.lblAuthor.Text = "Author:";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(20, 127);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(55, 20);
            this.lblVersion.Text = "Version:";
            // 
            // lblAuthorDesc
            // 
            this.lblAuthorDesc.Location = new System.Drawing.Point(74, 90);
            this.lblAuthorDesc.Name = "lblAuthorDesc";
            this.lblAuthorDesc.Size = new System.Drawing.Size(114, 20);
            this.lblAuthorDesc.Text = "Author";
            // 
            // lblVersionDesc
            // 
            this.lblVersionDesc.Location = new System.Drawing.Point(74, 127);
            this.lblVersionDesc.Name = "lblVersionDesc";
            this.lblVersionDesc.Size = new System.Drawing.Size(114, 20);
            this.lblVersionDesc.Text = "Version";
            // 
            // lnkCodeURL
            // 
            this.lnkCodeURL.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Underline);
            this.lnkCodeURL.Location = new System.Drawing.Point(18, 169);
            this.lnkCodeURL.Name = "lnkCodeURL";
            this.lnkCodeURL.Size = new System.Drawing.Size(222, 20);
            this.lnkCodeURL.TabIndex = 7;
            this.lnkCodeURL.Text = "http://code.google.com/p/timetrackermobile/";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(84, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lnkCodeURL);
            this.Controls.Add(this.lblVersionDesc);
            this.Controls.Add(this.lblAuthorDesc);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.KeyPreview = true;
            this.Name = "AboutForm";
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAuthorDesc;
        private System.Windows.Forms.Label lblVersionDesc;
        private System.Windows.Forms.LinkLabel lnkCodeURL;
        private System.Windows.Forms.Button btnClose;
    }
}