using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TimeTracker.Services.Contracts;
using System.IO;

namespace TimeTracker
{
    public partial class Main : Form
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
        private DateTime today;
        private Guid activityGuid;

        public delegate void ChangeTime();
        public ChangeTime myDelegate;


        private void Main_Load(object sender, EventArgs e)
        {
            this.taskService = new TimeTracker.Services.TaskService();

            myDelegate = new ChangeTime(ChangeTimeMethod);

            today = DateTime.Now.Date;

            this.lblDate.Text = today.ToLongDateString();
            FillCombo();
            FillGrid();
        }

        private void FillCombo()
        {
            IList<Activity> activities = this.taskService.GetActivities();

            cmbActivities.DisplayMember = "Description";
            cmbActivities.ValueMember = "Id";
            cmbActivities.DataSource = activities;
        }

        private void FillGrid()
        {
            this.lvwTasks.Items.Clear();
            int total = 0;

            IList<Task> tasks = this.taskService.GetTasksByDay(today);

            foreach (Task task in tasks)
            {
                this.lvwTasks.Items.Add(new ListViewItem(new string[]{ task.activity.Description, 
                    task.DatetimeFrom.ToString("HH:mm tt"),
                    task.DatetimeTo.ToString("HH:mm tt"), 
                    SecondsToDiff(task.Diff)}));
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
                this.FillGrid();
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
            today = today.AddDays(1);
            this.lblDate.Text = today.ToLongDateString();
            this.FillGrid();
        }

        private void lblDatePrev_Click(object sender, EventArgs e)
        {
            today = today.AddDays(-1);
            this.lblDate.Text = today.ToLongDateString();
            this.FillGrid();
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
            FillCombo();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.prgExport.Value = 0;
            UpdateProgressStatus("Status");

            IList<Task> tasks = this.taskService.GetTasksByRange(this.dtpFrom.Value.Date, this.dtpTo.Value.Date);
            this.prgExport.Maximum = tasks.Count + 3;

            this.prgExport.Value = this.prgExport.Value + 1;
            UpdateProgressStatus("Creating file");

            StreamWriter textWriter = new StreamWriter(@"Export" + DateTime.Now.Second.ToString() + ".csv", true);
            string pc = ";";

            int count = 1;

            foreach (Task task in tasks)
            {
                textWriter.WriteLine(task.activity.Description + pc + task.DatetimeFrom + pc + task.DatetimeTo + pc + task.Diff);

                this.prgExport.Value = this.prgExport.Value + 1;
                UpdateProgressStatus("Exporting tasks " + count.ToString() + " / " + tasks.Count.ToString());
                count = count + 1;
            }

            this.prgExport.Value = this.prgExport.Value + 1;
            UpdateProgressStatus("Closing file");

            textWriter.Flush();
            textWriter.Close();

            this.prgExport.Value = this.prgExport.Value + 1;
            UpdateProgressStatus("Done !");
        }

        private void UpdateProgressStatus(string status)
        {
            this.lblExportStatus.Text = status;
            this.lblExportStatus.Refresh();
        }
    }
}