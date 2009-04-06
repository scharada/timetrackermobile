namespace TimeTracker
{
    partial class TaskForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblActivity = new System.Windows.Forms.Label();
            this.cmbActivities = new System.Windows.Forms.ComboBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.txtElapsed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(132, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 20);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.cmbActivities.Size = new System.Drawing.Size(100, 22);
            this.cmbActivities.TabIndex = 2;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(74, 55);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(100, 21);
            this.txtFrom.TabIndex = 3;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(74, 98);
            this.txtTo.Name = "txtTo";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(100, 21);
            this.txtTo.TabIndex = 4;
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
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.txtElapsed);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.cmbActivities);
            this.Controls.Add(this.lblActivity);
            this.Controls.Add(this.btnSave);
            this.Menu = this.mainMenu1;
            this.Name = "TaskForm";
            this.Text = "Task";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.ComboBox cmbActivities;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.TextBox txtElapsed;
    }
}