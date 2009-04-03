namespace TimeTracker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.tabPageTasks = new System.Windows.Forms.TabPage();
            this.lblDatePost = new System.Windows.Forms.LinkLabel();
            this.lblDatePrev = new System.Windows.Forms.LinkLabel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lvwTasks = new System.Windows.Forms.ListView();
            this.colActivity = new System.Windows.Forms.ColumnHeader();
            this.colStart = new System.Windows.Forms.ColumnHeader();
            this.colEnd = new System.Windows.Forms.ColumnHeader();
            this.colElapsed = new System.Windows.Forms.ColumnHeader();
            this.cmbActivities = new System.Windows.Forms.ComboBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.lblTotal = new System.Windows.Forms.Label();
            this.TabMain.SuspendLayout();
            this.tabPageTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.tabPageTasks);
            this.TabMain.Controls.Add(this.tabPageGraph);
            this.TabMain.Location = new System.Drawing.Point(0, 0);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(240, 267);
            this.TabMain.TabIndex = 0;
            // 
            // tabPageTasks
            // 
            this.tabPageTasks.Controls.Add(this.lblTotal);
            this.tabPageTasks.Controls.Add(this.lblDatePost);
            this.tabPageTasks.Controls.Add(this.lblDatePrev);
            this.tabPageTasks.Controls.Add(this.lblDate);
            this.tabPageTasks.Controls.Add(this.lblStop);
            this.tabPageTasks.Controls.Add(this.lblStart);
            this.tabPageTasks.Controls.Add(this.lvwTasks);
            this.tabPageTasks.Controls.Add(this.cmbActivities);
            this.tabPageTasks.Controls.Add(this.btnStartStop);
            this.tabPageTasks.Location = new System.Drawing.Point(0, 0);
            this.tabPageTasks.Name = "tabPageTasks";
            this.tabPageTasks.Size = new System.Drawing.Size(240, 244);
            this.tabPageTasks.Text = "Tasks";
            // 
            // lblDatePost
            // 
            this.lblDatePost.Location = new System.Drawing.Point(209, 3);
            this.lblDatePost.Name = "lblDatePost";
            this.lblDatePost.Size = new System.Drawing.Size(24, 20);
            this.lblDatePost.TabIndex = 6;
            this.lblDatePost.Text = ">";
            this.lblDatePost.Click += new System.EventHandler(this.lblDatePost_Click);
            // 
            // lblDatePrev
            // 
            this.lblDatePrev.Location = new System.Drawing.Point(12, 3);
            this.lblDatePrev.Name = "lblDatePrev";
            this.lblDatePrev.Size = new System.Drawing.Size(24, 20);
            this.lblDatePrev.TabIndex = 5;
            this.lblDatePrev.Text = "<";
            this.lblDatePrev.Click += new System.EventHandler(this.lblDatePrev_Click);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDate.Location = new System.Drawing.Point(48, 5);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(145, 16);
            this.lblDate.Text = "Today";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStop
            // 
            this.lblStop.Location = new System.Drawing.Point(79, 179);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(82, 20);
            this.lblStop.Text = "Elapsed";
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(7, 179);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(73, 20);
            this.lblStart.Text = "Start";
            // 
            // lvwTasks
            // 
            this.lvwTasks.Columns.Add(this.colActivity);
            this.lvwTasks.Columns.Add(this.colStart);
            this.lvwTasks.Columns.Add(this.colEnd);
            this.lvwTasks.Columns.Add(this.colElapsed);
            this.lvwTasks.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lvwTasks.FullRowSelect = true;
            this.lvwTasks.Location = new System.Drawing.Point(0, 23);
            this.lvwTasks.Name = "lvwTasks";
            this.lvwTasks.Size = new System.Drawing.Size(240, 130);
            this.lvwTasks.TabIndex = 3;
            this.lvwTasks.View = System.Windows.Forms.View.Details;
            // 
            // colActivity
            // 
            this.colActivity.Text = "Activity";
            this.colActivity.Width = 70;
            // 
            // colStart
            // 
            this.colStart.Text = "Start";
            this.colStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStart.Width = 53;
            // 
            // colEnd
            // 
            this.colEnd.Text = "End";
            this.colEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colEnd.Width = 53;
            // 
            // colElapsed
            // 
            this.colElapsed.Text = "Elapsed";
            this.colElapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colElapsed.Width = 56;
            // 
            // cmbActivities
            // 
            this.cmbActivities.Location = new System.Drawing.Point(7, 217);
            this.cmbActivities.Name = "cmbActivities";
            this.cmbActivities.Size = new System.Drawing.Size(129, 22);
            this.cmbActivities.TabIndex = 2;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(161, 180);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(72, 59);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start-Stop";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Location = new System.Drawing.Point(0, 0);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Size = new System.Drawing.Size(232, 239);
            this.tabPageGraph.Text = "Graph";
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(151, 156);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 20);
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.TabMain);
            this.Menu = this.mainMenu1;
            this.Name = "Main";
            this.Text = "Time Tracker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.TabMain.ResumeLayout(false);
            this.tabPageTasks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage tabPageTasks;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.ComboBox cmbActivities;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ListView lvwTasks;
        private System.Windows.Forms.ColumnHeader colActivity;
        private System.Windows.Forms.ColumnHeader colStart;
        private System.Windows.Forms.ColumnHeader colEnd;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ColumnHeader colElapsed;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.LinkLabel lblDatePrev;
        private System.Windows.Forms.LinkLabel lblDatePost;
        private System.Windows.Forms.Label lblTotal;
    }
}