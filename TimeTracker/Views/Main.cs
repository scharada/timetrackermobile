namespace TimeTracker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Mobile.Mvc;
    using System.Threading;
    using System.Windows.Forms;
    using TimeTracker.Services.Contracts;

    public partial class Main : ViewForm, IView<Task>
    {

        public Main()
        {
            InitializeComponent();
        }

        private bool running = false;
        private TimeTracker.Services.TaskService taskService { get; set; }
        private System.Threading.Timer timer;
        private DateTime start;
        private DateTime now;
        private Guid activityGuid;

        public delegate void ChangeTime();
        public ChangeTime myDelegate;


        private void Main_Load(object sender, EventArgs e)
        {
            lvwTasks.Activation = ItemActivation.Standard;
            this.taskService = new TimeTracker.Services.TaskService();

            myDelegate = new ChangeTime(ChangeTimeMethod);

            this.ViewData["today"] = DateTime.Now.Date;

            this.lblDate.Text = ((DateTime)this.ViewData["today"]).ToLongDateString();

            this.OnViewStateChanged("FillActivitiesCombo");
            this.OnViewStateChanged("FillGrid");
        }

        protected override void OnUpdateView(string key)
        {
            switch (key)
            {
                case "FillGrid":
                    this.FillGrid();
                    break;
                case "FillActivitiesCombo":
                    this.cmbActivities.DisplayMember = "Description";
                    this.cmbActivities.ValueMember = "Id";
                    this.cmbActivities.DataSource = (List<Activity>)this.ViewData["activities"];
                    break;
                case "DatePrev":
                    this.lblDate.Text = ((DateTime)this.ViewData["today"]).ToLongDateString();
                    this.FillGrid();
                    break;
                case "DatePost":
                    this.lblDate.Text = ((DateTime)this.ViewData["today"]).ToLongDateString();
                    this.FillGrid();
                    break;
                default:
                    break;
            }
        }

        private void FillGrid()
        {
            this.lvwTasks.Items.Clear();
            int total = 0;

            IList<Task> tasks = (List<Task>)this.ViewData["tasksByDay"];

            foreach (Task task in tasks)
            {
                ListViewItem item = new ListViewItem(new string[]{ task.activity.Description, 
                        task.DatetimeFrom.ToString("HH:mm tt"),
                        task.DatetimeTo.ToString("HH:mm tt"), 
                        SecondsToDiff(task.Diff)});

                item.Tag = task.Id;
                this.lvwTasks.Items.Add(item);
                total = total + task.Diff;
            }
            this.lblTotal.Text = SecondsToDiff(total);
        }

        public void ChangeTimeMethod()
        {
            now = DateTime.Now;
            TimeSpan timeSpan = now - start;
            lblStop.Text = timeSpan.Hours.ToString().PadLeft(2, '0') + ":" + timeSpan.Minutes.ToString().PadLeft(2, '0') + ":" + timeSpan.Seconds.ToString().PadLeft(2, '0');
        }

        private string SecondsToDiff(int diff)
        {
            int hours, minutes, seconds, total;
            total = diff;

            hours = total / 3600;
            total = total - (hours * 3600);
            minutes = total / 60;
            total = total - minutes * 60;
            seconds = total;

            return String.Format("{0}:{1}:{2}", hours.ToString().PadLeft(2, '0'), minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));
        }

        public void TimerElapsed(object o)
        {
            this.Invoke(myDelegate);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                running = true;
                start = DateTime.Now;
                timer = new System.Threading.Timer(new TimerCallback(this.TimerElapsed), null, 0, 100);
                this.btnStartStop.Text = "Stop";
                lblStart.Text = DateTime.Now.ToShortTimeString();
            }
            else
            {
                running = false;
                timer.Dispose();
                timer = null;
                this.btnStartStop.Text = "Start";

                SaveTask(activityGuid);
                //new Guid(this.cmbActivities.SelectedValue.ToString())
                this.OnViewStateChanged("FillGrid");
            }
        }

        private void SaveTask(Guid activityId)
        {
            TimeSpan timeSpan = new TimeSpan();
            int diff = 0;
            timeSpan = now - start;
            diff = diff + timeSpan.Hours * 3600;
            diff = diff + timeSpan.Minutes * 60;
            diff = diff + timeSpan.Seconds;

            Task task = new Task { ActivityId = activityId, DatetimeFrom = start, DatetimeTo = now, Diff = diff };
            this.taskService.AddTask(task);
        }

        private void lblDatePost_Click(object sender, EventArgs e)
        {
            this.OnViewStateChanged("DatePost");
        }

        private void lblDatePrev_Click(object sender, EventArgs e)
        {
            this.OnViewStateChanged("DatePrev");
        }

        private void cmbActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (running)
            {
                btnStartStop_Click(sender, e);
                System.Threading.Thread.Sleep(400);
                btnStartStop_Click(sender, e);
                activityGuid = new Guid(this.cmbActivities.SelectedValue.ToString());
            }
            else
            {
                activityGuid = new Guid(this.cmbActivities.SelectedValue.ToString());
            }
        }

        private void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabMain.SelectedIndex == 2)
            {
                FillActivityGrid();
            }
        }

        private void FillActivityGrid()
        {
            this.lvwActivity.Items.Clear();
            IList<Activity> activities = this.taskService.GetActivities();

            foreach (Activity activity in activities)
            {
                this.lvwActivity.Items.Add(new ListViewItem(new string[] { activity.Description }));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity { Color = "", Description = this.txtCategory.Text.Trim(), Id = new Guid() };

            this.taskService.AddActivity(activity);
            this.txtCategory.Text = "";
            FillActivityGrid();
            this.OnViewStateChanged("FillActivitiesCombo");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.prgExport.Value = 0;
            this.lblExportStatus.Text = "Status";

            this.ViewData["ExportFrom"] = this.dtpFrom.Value;
            this.ViewData["ExportTo"] = this.dtpTo.Value;

            this.OnViewStateChanged("ExportTasks");
        }

        private void OnExportStatusUpdated(object sender, DataEventArgs<string> e)
        {
            this.prgExport.Value = this.prgExport.Value + 1;
            this.lblExportStatus.Text = e.Value;
            this.lblExportStatus.Refresh();
        }

        private void OnTasksCount(object sender, DataEventArgs<int> e)
        {
            this.prgExport.Maximum = e.Value;
        }

         private void lvwTasks_ItemActivate(object sender, EventArgs e)
        {
            if (lvwTasks.SelectedIndices.Count > 0)
            {
                TaskForm taskForm = new TaskForm();
                Controllers.TaskController taskController = new TimeTracker.Controllers.TaskController(taskForm);
                taskForm.TaskId = new Guid(this.lvwTasks.Items[this.lvwTasks.SelectedIndices[0]].Tag.ToString());

                taskForm.ShowDialog();

                if (taskForm.DialogResult == DialogResult.Yes)
                {
                    this.OnViewStateChanged("FillGrid");
                }
            }
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