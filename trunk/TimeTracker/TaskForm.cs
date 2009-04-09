﻿namespace TimeTracker
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TimeTracker.Services.Contracts;
    using System.Mobile.Mvc;

    public partial class TaskForm : ViewForm, IView<Task>
    {
        public TaskForm()
        {
            InitializeComponent();
        }

        public Guid TaskId { get; set; }

        private void TaskForm_Load(object sender, System.EventArgs e)
        {
            this.ViewData["taskId"] = this.TaskId;
            this.OnViewStateChanged("FillForm");
        }

        protected override void OnUpdateView(string key)
        {
            if (key == "FillForm")
            {
                this.cmbActivities.DisplayMember = "Description";
                this.cmbActivities.ValueMember = "Id";
                this.cmbActivities.DataSource = (List<Activity>)this.ViewData["activities"];
                this.cmbActivities.SelectedValue = this.ViewData.Model.ActivityId;

                this.txtElapsed.Text = this.ViewData.Model.Diff.ToString();
                this.txtFrom.Value = this.ViewData.Model.DatetimeFrom;
                this.txtTo.Value = this.ViewData.Model.DatetimeTo;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            this.ViewData.Model.ActivityId = new Guid(this.cmbActivities.SelectedValue.ToString());
            this.ViewData.Model.DatetimeFrom = this.txtFrom.Value;
            this.ViewData.Model.DatetimeTo = this.txtTo.Value;

            this.OnViewStateChanged("Save");
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        #region IView<Task> Members

        public new Task Model
        {
            get;
            set;
        }

        public new ViewDataDictionary<Task> ViewData
        {
            get;
            set;
        }

        #endregion
    }
}