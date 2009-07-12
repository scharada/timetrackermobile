namespace TimeTracker
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Mobile.Mvc;
    using System.Threading;
    using System.Windows.Forms;
    using TimeTracker.Services.Contracts;
    using System.Resources;
    using System.Reflection;

    public partial class MainStd : ViewForm, IView<Task>
    {
        public MainStd()
        {
            InitializeComponent();
        }

        [PublishEvent("OnStartStop")]
        public event EventHandler OnStartStopEvent;

        [PublishEvent("OnActivityComboIndexSelectedChanged")]
        public event EventHandler<DataEventArgs<Guid>> OnActivityComboIndexSelectedChangedEvent;

        public delegate void ChangeTime(string time);
        public ChangeTime myDelegate;

        private void Main_Load(object sender, EventArgs e)
        {
            lvwTasks.Activation = ItemActivation.Standard;

            myDelegate = new ChangeTime(ChangeTimeMethod);

            this.ViewData["today"] = DateTime.Now.Date;

            this.lblDate.Text = ((DateTime)this.ViewData["today"]).ToLongDateString();

            this.OnViewStateChanged("FillActivitiesCombo");
            this.OnViewStateChanged("FillGrid");

            this.lvwTasks.Focus();
        }

        private void OnTaskStoped(object sender, EventArgs e)
        {
            this.OnViewStateChanged("FillGrid");
            this.OnViewStateChanged("TaskStopped");
        }

        private void OnTaskElapsedTimeUpdated(object sender, DataEventArgs<string> e)
        {
            this.Invoke(myDelegate, e.Value.ToString());
        }

        private void OnTaskStarted(object sender, EventArgs e)
        {
            lblStart.Text = DateTime.Now.ToShortTimeString();
        }

        protected override void OnUpdateView(string key)
        {
            switch (key)
            {
                case "FillGrid":
                    this.FillGrid();
                    break;
                case "FillActivitiesCombo":
                    this.FillActivitiesCombo();
                    break;
                case "DatePrev":
                    this.lblDate.Text = ((DateTime)this.ViewData["today"]).ToLongDateString();
                    this.FillGrid();
                    break;
                case "DatePost":
                    this.lblDate.Text = ((DateTime)this.ViewData["today"]).ToLongDateString();
                    this.FillGrid();
                    break;
                case "TaskStopped":
                    this.txtNotes.Text = this.ViewData["notes"].ToString();
                    break;

                default:
                    break;
            }
        }

        private void FillActivitiesCombo()
        {
            this.cmbActivities.DisplayMember = "Description";
            this.cmbActivities.ValueMember = "Id";
            this.cmbActivities.DataSource = (List<Activity>)this.ViewData["activities"];
        }

        public void ChangeTimeMethod(string time)
        {
            lblStop.Text = time;
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

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            //if (OnStartStopEvent != null)
            //{
            //    OnStartStopEvent(this, new EventArgs());
            //}

            //if (this.btnStartStop.Text == "Stop")
            //{
            //    this.btnStartStop.Text = "Start";
            //}
            //else
            //{
            //    this.btnStartStop.Text = "Stop";
            //}
        }

        private void lblDatePost_Click(object sender, EventArgs e)
        {
            this.OnViewStateChanged("DatePost");
        }

        private void lblDatePrev_Click(object sender, EventArgs e)
        {
            this.OnViewStateChanged("DatePrev");
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

            if (this.lvwTasks.Items.Count > 0)
            {
                this.lvwTasks.Items[0].Selected = true;
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

        private void imgDatePost_Click(object sender, EventArgs e)
        {
            this.OnViewStateChanged("DatePost");
        }

        private void imgDatePrev_Click(object sender, EventArgs e)
        {
            this.OnViewStateChanged("DatePrev");
        }

        private void mnuStartStop_Click(object sender, EventArgs e)
        {
            imgStart_Click(new object(), new EventArgs());
        }

        private void mnuCategory_Click(object sender, EventArgs e)
        {
            Views.Category.Categories categoriesForm = new Views.Category.Categories();
            Controllers.CategoryController categoryController = new Controllers.CategoryController(categoriesForm);
            categoriesForm.ShowDialog();

            if (categoriesForm.ItemChanged)
            {
                this.OnViewStateChanged("FillActivitiesCombo");
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            Views.AboutForm aboutForm = new Views.AboutForm();
            Controllers.AboutController aboutController = new Controllers.AboutController(aboutForm);
            aboutForm.ShowDialog();
        }

        private void mnuExportTasks_Click(object sender, EventArgs e)
        {
            Views.Export exportForm = new Views.Export();
            Controllers.ExportController exportController = new Controllers.ExportController(exportForm);
            exportForm.ShowDialog();
        }

        private void cmbActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnActivityComboIndexSelectedChangedEvent != null)
            {
                OnActivityComboIndexSelectedChangedEvent(this, new DataEventArgs<Guid>(new Guid(this.cmbActivities.SelectedValue.ToString())));
            }
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

        private void imgStart_Click(object sender, EventArgs e)
        {
            ResourceManager resmgr = new ResourceManager("TimeTracker.Resources", Assembly.GetExecutingAssembly());

            if (this.txtNotes.Text.Trim() != "Notes")
            {
                this.ViewData["notes"] = this.txtNotes.Text.Trim();
            }
            else
            {
                this.ViewData["notes"] = "";
            }

            if (OnStartStopEvent != null)
            {
                OnStartStopEvent(this, new EventArgs());
            }

            if (this.imgStart.Tag.ToString() == "Stop")
            {
                this.imgStart.Tag = "Start";
                this.imgStart.Image = (System.Drawing.Image)resmgr.GetObject("record");
                this.mnuStartStop.Text = "Start";
            }
            else
            {
                this.imgStart.Tag = "Stop";
                this.imgStart.Image = (System.Drawing.Image)resmgr.GetObject("stop");
                this.mnuStartStop.Text = "Stop";
            }
        }

        private void mnuChangeCategory_Click(object sender, EventArgs e)
        {
            Views.Category.CategoriesSelect categoriesSelectForm = new Views.Category.CategoriesSelect();
            Controllers.CategoryController categoryController = new Controllers.CategoryController(categoriesSelectForm);
            categoriesSelectForm.ShowDialog();

            if (categoriesSelectForm.SelectionDone)
            {
                this.ViewData["activityGuid"] = categoriesSelectForm.SelectedId;
                PositionCategoryCombo();
            }
        }

        private void PositionCategoryCombo()
        {
            cmbActivities.SelectedValue = new Guid(this.ViewData["activityGuid"].ToString());
        }

        private void mnuDeleteTask_Click(object sender, EventArgs e)
        {
            if (this.lvwTasks.SelectedIndices.Count > 0)
            {
                if (MessageBox.Show("Do you want to delete this Task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.ViewData["taskGuid"] = this.lvwTasks.Items[lvwTasks.SelectedIndices[0]].Tag;
                    this.OnViewStateChanged("RemoveTask");
                }
            }
        }

        private void txtNotes_GotFocus(object sender, EventArgs e)
        {
            if (this.txtNotes.Text.Trim() == "Notes")
            {
                this.txtNotes.Text = "";
            }
            else if (this.txtNotes.Text.Trim() == "")
            {
                this.txtNotes.Text = "Notes";
            }
        }

        private void mnuChart_Click(object sender, EventArgs e)
        {
            Views.Chart chartForm = new Views.Chart();
            Controllers.ChartController chartController = new Controllers.ChartController(chartForm);
            chartForm.ShowDialog();
        }
    }
}