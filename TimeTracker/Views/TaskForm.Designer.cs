namespace TimeTracker
{
    partial class TaskForm
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
            this.lblActivity = new System.Windows.Forms.Label();
            this.cmbActivities = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.txtElapsed = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.DateTimePicker();
            this.txtTo = new System.Windows.Forms.DateTimePicker();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuSave = new System.Windows.Forms.MenuItem();
            this.mnuCancel = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // lblActivity
            // 
            this.lblActivity.Location = new System.Drawing.Point(16, 16);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(52, 20);
            this.lblActivity.Text = "Activity:";
            // 
            // cmbActivities
            // 
            this.cmbActivities.Location = new System.Drawing.Point(74, 14);
            this.cmbActivities.Name = "cmbActivities";
            this.cmbActivities.Size = new System.Drawing.Size(144, 22);
            this.cmbActivities.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(16, 55);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(52, 20);
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(16, 98);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(52, 20);
            this.lblTo.Text = "To:";
            // 
            // lblElapsed
            // 
            this.lblElapsed.Location = new System.Drawing.Point(16, 138);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(52, 20);
            this.lblElapsed.Text = "Elapsed:";
            // 
            // txtElapsed
            // 
            this.txtElapsed.Location = new System.Drawing.Point(74, 138);
            this.txtElapsed.Name = "txtElapsed";
            this.txtElapsed.ReadOnly = true;
            this.txtElapsed.Size = new System.Drawing.Size(100, 21);
            this.txtElapsed.TabIndex = 10;
            // 
            // txtFrom
            // 
            this.txtFrom.CustomFormat = "dd/MM/yy hh:mm:ss tt";
            this.txtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFrom.Location = new System.Drawing.Point(75, 52);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(144, 22);
            this.txtFrom.TabIndex = 14;
            // 
            // txtTo
            // 
            this.txtTo.CustomFormat = "dd/MM/yy hh:mm:ss tt";
            this.txtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTo.Location = new System.Drawing.Point(74, 96);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(144, 22);
            this.txtTo.TabIndex = 15;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuCancel);
            this.mainMenu1.MenuItems.Add(this.mnuSave);
            // 
            // mnuSave
            // 
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Text = "Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.txtElapsed);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.cmbActivities);
            this.Controls.Add(this.lblActivity);
            this.Menu = this.mainMenu1;
            this.Name = "TaskForm";
            this.Text = "Task";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.ComboBox cmbActivities;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.TextBox txtElapsed;
        private System.Windows.Forms.DateTimePicker txtFrom;
        private System.Windows.Forms.DateTimePicker txtTo;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuSave;
        private System.Windows.Forms.MenuItem mnuCancel;
    }
}