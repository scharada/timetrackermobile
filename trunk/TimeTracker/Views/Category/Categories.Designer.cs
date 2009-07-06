namespace TimeTracker.Views.Category
{
	partial class Categories
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
            this.mnuClose = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuAdd = new System.Windows.Forms.MenuItem();
            this.mnuDelete = new System.Windows.Forms.MenuItem();
            this.lvwActivity = new System.Windows.Forms.ListView();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuClose);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // mnuClose
            // 
            this.mnuClose.Text = "Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.mnuAdd);
            this.menuItem2.MenuItems.Add(this.mnuDelete);
            this.menuItem2.Text = "Actions";
            // 
            // mnuAdd
            // 
            this.mnuAdd.Text = "Add";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // lvwActivity
            // 
            this.lvwActivity.Columns.Add(this.colCategory);
            this.lvwActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwActivity.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lvwActivity.FullRowSelect = true;
            this.lvwActivity.Location = new System.Drawing.Point(0, 0);
            this.lvwActivity.Name = "lvwActivity";
            this.lvwActivity.Size = new System.Drawing.Size(240, 268);
            this.lvwActivity.TabIndex = 5;
            this.lvwActivity.View = System.Windows.Forms.View.Details;
            // 
            // colCategory
            // 
            this.colCategory.Text = "Category";
            this.colCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCategory.Width = 237;
            // 
            // Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lvwActivity);
            this.Menu = this.mainMenu1;
            this.Name = "Categories";
            this.Text = "Categories";
            this.Load += new System.EventHandler(this.Categories_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.MenuItem mnuClose;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuAdd;
        private System.Windows.Forms.MenuItem mnuDelete;
        private System.Windows.Forms.ListView lvwActivity;
        private System.Windows.Forms.ColumnHeader colCategory;
	}
}