namespace TimeTracker
{
    partial class MainStd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainStd));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuEditTask = new System.Windows.Forms.MenuItem();
            this.mnuDeleteTask = new System.Windows.Forms.MenuItem();
            this.mnuExportTasks = new System.Windows.Forms.MenuItem();
            this.mnuChangeCategory = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuCategory = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.mnuStartStop = new System.Windows.Forms.MenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lvwTasks = new System.Windows.Forms.ListView();
            this.colActivity = new System.Windows.Forms.ColumnHeader();
            this.colStart = new System.Windows.Forms.ColumnHeader();
            this.colEnd = new System.Windows.Forms.ColumnHeader();
            this.colElapsed = new System.Windows.Forms.ColumnHeader();
            this.cmbActivities = new System.Windows.Forms.ComboBox();
            this.imgDatePrev = new System.Windows.Forms.PictureBox();
            this.imgDatePost = new System.Windows.Forms.PictureBox();
            this.imgStop = new System.Windows.Forms.PictureBox();
            this.imgStart = new System.Windows.Forms.PictureBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.mnuChart = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuOptions);
            this.mainMenu1.MenuItems.Add(this.mnuStartStop);
            // 
            // mnuOptions
            // 
            this.mnuOptions.MenuItems.Add(this.mnuEditTask);
            this.mnuOptions.MenuItems.Add(this.mnuDeleteTask);
            this.mnuOptions.MenuItems.Add(this.mnuExportTasks);
            this.mnuOptions.MenuItems.Add(this.mnuChangeCategory);
            this.mnuOptions.MenuItems.Add(this.menuItem2);
            this.mnuOptions.MenuItems.Add(this.menuItem1);
            this.mnuOptions.Text = "Options";
            // 
            // mnuEditTask
            // 
            this.mnuEditTask.Text = "Edit Task";
            // 
            // mnuDeleteTask
            // 
            this.mnuDeleteTask.Text = "Delete Task";
            this.mnuDeleteTask.Click += new System.EventHandler(this.mnuDeleteTask_Click);
            // 
            // mnuExportTasks
            // 
            this.mnuExportTasks.Text = "Export Tasks";
            this.mnuExportTasks.Click += new System.EventHandler(this.mnuExportTasks_Click);
            // 
            // mnuChangeCategory
            // 
            this.mnuChangeCategory.Text = "Change Category";
            this.mnuChangeCategory.Click += new System.EventHandler(this.mnuChangeCategory_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "-";
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.mnuCategory);
            this.menuItem1.MenuItems.Add(this.mnuChart);
            this.menuItem1.MenuItems.Add(this.menuItem3);
            this.menuItem1.MenuItems.Add(this.mnuAbout);
            this.menuItem1.Text = "Options";
            // 
            // mnuCategory
            // 
            this.mnuCategory.Text = "Category";
            this.mnuCategory.Click += new System.EventHandler(this.mnuCategory_Click_1);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click_1);
            // 
            // mnuStartStop
            // 
            this.mnuStartStop.Text = "Start";
            this.mnuStartStop.Click += new System.EventHandler(this.mnuStartStop_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(151, 175);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 20);
            this.lblTotal.Text = "[Total]";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblDate.Location = new System.Drawing.Point(48, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(129, 16);
            this.lblDate.Text = "Today";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStop
            // 
            this.lblStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStop.BackColor = System.Drawing.Color.White;
            this.lblStop.Location = new System.Drawing.Point(79, 174);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(82, 20);
            this.lblStop.Text = "Elapsed";
            // 
            // lblStart
            // 
            this.lblStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStart.BackColor = System.Drawing.Color.White;
            this.lblStart.Location = new System.Drawing.Point(7, 174);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(73, 20);
            this.lblStart.Text = "Start";
            // 
            // lvwTasks
            // 
            this.lvwTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTasks.Columns.Add(this.colActivity);
            this.lvwTasks.Columns.Add(this.colStart);
            this.lvwTasks.Columns.Add(this.colEnd);
            this.lvwTasks.Columns.Add(this.colElapsed);
            this.lvwTasks.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lvwTasks.FullRowSelect = true;
            this.lvwTasks.Location = new System.Drawing.Point(0, 27);
            this.lvwTasks.Name = "lvwTasks";
            this.lvwTasks.Size = new System.Drawing.Size(240, 144);
            this.lvwTasks.TabIndex = 8;
            this.lvwTasks.View = System.Windows.Forms.View.Details;
            this.lvwTasks.ItemActivate += new System.EventHandler(this.lvwTasks_ItemActivate_1);
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
            this.cmbActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbActivities.Location = new System.Drawing.Point(7, 238);
            this.cmbActivities.Name = "cmbActivities";
            this.cmbActivities.Size = new System.Drawing.Size(154, 22);
            this.cmbActivities.TabIndex = 11;
            this.cmbActivities.SelectedIndexChanged += new System.EventHandler(this.cmbActivities_SelectedIndexChanged_1);
            // 
            // imgDatePrev
            // 
            this.imgDatePrev.Image = ((System.Drawing.Image)(resources.GetObject("imgDatePrev.Image")));
            this.imgDatePrev.Location = new System.Drawing.Point(12, 4);
            this.imgDatePrev.Name = "imgDatePrev";
            this.imgDatePrev.Size = new System.Drawing.Size(22, 22);
            this.imgDatePrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // imgDatePost
            // 
            this.imgDatePost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgDatePost.Image = ((System.Drawing.Image)(resources.GetObject("imgDatePost.Image")));
            this.imgDatePost.Location = new System.Drawing.Point(202, 4);
            this.imgDatePost.Name = "imgDatePost";
            this.imgDatePost.Size = new System.Drawing.Size(22, 22);
            this.imgDatePost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // imgStop
            // 
            this.imgStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStop.Image = ((System.Drawing.Image)(resources.GetObject("imgStop.Image")));
            this.imgStop.Location = new System.Drawing.Point(170, 199);
            this.imgStop.Name = "imgStop";
            this.imgStop.Size = new System.Drawing.Size(65, 65);
            this.imgStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgStop.Visible = false;
            // 
            // imgStart
            // 
            this.imgStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgStart.Image = ((System.Drawing.Image)(resources.GetObject("imgStart.Image")));
            this.imgStart.Location = new System.Drawing.Point(170, 199);
            this.imgStart.Name = "imgStart";
            this.imgStart.Size = new System.Drawing.Size(65, 65);
            this.imgStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgStart.Tag = "Start";
            this.imgStart.Click += new System.EventHandler(this.imgStart_Click_1);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(7, 198);
            this.txtNotes.MaxLength = 512;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(154, 33);
            this.txtNotes.TabIndex = 16;
            this.txtNotes.Text = "Notes";
            this.txtNotes.GotFocus += new System.EventHandler(this.txtNotes_GotFocus);
            // 
            // mnuChart
            // 
            this.mnuChart.Text = "Chart";
            this.mnuChart.Click += new System.EventHandler(this.mnuChart_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "-";
            // 
            // MainStd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lvwTasks);
            this.Controls.Add(this.cmbActivities);
            this.Controls.Add(this.imgDatePrev);
            this.Controls.Add(this.imgDatePost);
            this.Controls.Add(this.imgStop);
            this.Controls.Add(this.imgStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "MainStd";
            this.Text = "Time Tracker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuOptions;
        private System.Windows.Forms.MenuItem mnuStartStop;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuCategory;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.MenuItem mnuEditTask;
        private System.Windows.Forms.MenuItem mnuDeleteTask;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuExportTasks;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ListView lvwTasks;
        private System.Windows.Forms.ColumnHeader colActivity;
        private System.Windows.Forms.ColumnHeader colStart;
        private System.Windows.Forms.ColumnHeader colEnd;
        private System.Windows.Forms.ColumnHeader colElapsed;
        private System.Windows.Forms.ComboBox cmbActivities;
        private System.Windows.Forms.PictureBox imgDatePrev;
        private System.Windows.Forms.PictureBox imgDatePost;
        private System.Windows.Forms.PictureBox imgStop;
        private System.Windows.Forms.PictureBox imgStart;
        private System.Windows.Forms.MenuItem mnuChangeCategory;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.MenuItem mnuChart;
        private System.Windows.Forms.MenuItem menuItem3;
    }
}