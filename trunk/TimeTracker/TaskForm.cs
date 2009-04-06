namespace TimeTracker
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TimeTracker.Services.Contracts;

    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
        }

        private TimeTracker.Services.TaskService taskService { get; set; }
        public Task Task { get; set; }

        private void TaskForm_Load(object sender, System.EventArgs e)
        {
            this.taskService = new TimeTracker.Services.TaskService();
            this.FillCombo();
            this.cmbActivities.SelectedValue = this.Task.ActivityId;
            this.txtElapsed.Text = this.Task.Diff.ToString();
            this.txtFrom.Text = this.Task.DatetimeFrom.ToString();
            this.txtTo.Text = this.Task.DatetimeTo.ToString();
        }

        private void FillCombo()
        {
            IList<Activity> activities = this.taskService.GetActivities();

            this.cmbActivities.DisplayMember = "Description";
            this.cmbActivities.ValueMember = "Id";
            this.cmbActivities.DataSource = activities;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.Task.ActivityId = new Guid(this.cmbActivities.SelectedValue.ToString());
            this.taskService.UpdateTask(this.Task);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}