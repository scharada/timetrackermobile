namespace TimeTracker.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Mobile.Mvc;
    using TimeTracker.Services.Contracts;
    using System.IO;
    using System.Threading;

    public class TaskController : Controller<Task>
    {
        [PublishEvent("OnExportStatusUpdated")]
        public event EventHandler<DataEventArgs<string>> OnExportStatusUpdatedEvent;

        [PublishEvent("OnTasksCount")]
        public event EventHandler<DataEventArgs<int>> OnTasksCountEvent;

        [PublishEvent("OnTaskStarted")]
        public event EventHandler OnTaskStartedEvent;

        [PublishEvent("OnTaskStoped")]
        public event EventHandler OnTaskStopedEvent;

        [PublishEvent("OnTaskElapsedTimeUpdated")]
        public event EventHandler<DataEventArgs<string>> OnTaskElapsedTimeUpdatedEvent;


        private TimeTracker.Services.TaskService taskService { get; set; }
        private System.Threading.Timer timer;

        private DateTime start;
        private DateTime now;

        private bool running = false;

        public TaskController(IView<Task> view)
            : base(view)
        {
            this.taskService = new TimeTracker.Services.TaskService();
        }

        public void TimerElapsed(object o)
        {
            now = DateTime.Now;
            TimeSpan timeSpan = now - start;
            if (OnTaskElapsedTimeUpdatedEvent != null)
            {
                string msg = timeSpan.Hours.ToString().PadLeft(2, '0') + ":" + timeSpan.Minutes.ToString().PadLeft(2, '0') + ":" + timeSpan.Seconds.ToString().PadLeft(2, '0');
                OnTaskElapsedTimeUpdatedEvent(this, new DataEventArgs<string>(msg));
            }
        }

        private void OnStartStop(object sender, EventArgs e)
        {
            if (!running)
            {
                running = true;
                start = DateTime.Now;
                timer = new System.Threading.Timer(new TimerCallback(this.TimerElapsed), null, 0, 100);
                if (OnTaskStartedEvent != null)
                {
                    OnTaskStartedEvent(this, new EventArgs());
                }
            }
            else
            {
                running = false;
                timer.Dispose();
                timer = null;

                SaveTask((Guid)this.view.ViewData["activityGuid"], this.view.ViewData["notes"].ToString());
                this.view.ViewData["notes"] = "";

                if (OnTaskStopedEvent != null)
                {
                    OnTaskStopedEvent(this, new EventArgs());
                }
            }
        }

        private void OnActivityComboIndexSelectedChanged(object sender, DataEventArgs<Guid> e)
        {
            if (running)
            {
                OnStartStop(sender, new EventArgs());
                System.Threading.Thread.Sleep(400);
                OnStartStop(sender, new EventArgs());
                this.view.ViewData["activityGuid"] = e.Value;
            }
            else
            {
                this.view.ViewData["activityGuid"] = e.Value;
            }
        }

        protected override void OnViewStateChanged(string key)
        {
            switch (key)
            {
                case "FillTaskForm":
                    this.view.ViewData["activities"] = this.taskService.GetActivities();
                    this.view.ViewData.Model = this.taskService.GetTask(new Guid(this.view.ViewData["taskId"].ToString()));
                    this.view.UpdateView("FillTaskForm");
                    break;
                case "FillActivitiesCombo":
                    this.view.ViewData["activities"] = this.taskService.GetActivities();
                    this.view.UpdateView("FillActivitiesCombo");
                    break;
                case "FillGrid":
                    this.view.ViewData["tasksByDay"] = this.taskService.GetTasksByDay((DateTime)this.view.ViewData["today"]);
                    this.view.UpdateView("FillGrid");
                    break;
                case "FillActivityGrid":
                    this.view.ViewData["activities"] = this.taskService.GetActivities();
                    this.view.UpdateView("FillActivityGrid");
                    break;
                case "AddActivity":
                    this.taskService.AddActivity((Activity)this.view.ViewData["activity"]);
                    this.view.ViewData["activities"] = this.taskService.GetActivities();
                    this.view.UpdateView("FillActivityGrid");
                    break;
                case "RemoveActivity":
                    this.taskService.RemoveActivity(new Guid(this.view.ViewData["activityGuid"].ToString()));
                    this.view.ViewData["activities"] = this.taskService.GetActivities();
                    this.view.ViewData["tasksByDay"] = this.taskService.GetTasksByDay((DateTime)this.view.ViewData["today"]);
                    this.view.UpdateView("FillActivityGrid");
                    break;
                case "DeleteTask":
                    this.taskService.RemoveTask(new Guid(this.view.ViewData["taskGuid"].ToString()));
                    this.view.ViewData["activities"] = this.taskService.GetActivities();
                    this.view.ViewData["tasksByDay"] = this.taskService.GetTasksByDay((DateTime)this.view.ViewData["today"]);
                    this.view.UpdateView("FillActivityGrid");
                    break;
                case "Save":
                    this.taskService.UpdateTask(this.view.ViewData.Model);
                    this.view.UpdateView("");
                    break;
                case "DatePrev":
                    this.view.ViewData["today"] = ((DateTime)this.view.ViewData["today"]).AddDays(-1);
                    this.view.ViewData["tasksByDay"] = this.taskService.GetTasksByDay((DateTime)this.view.ViewData["today"]);
                    this.view.UpdateView("DatePrev");
                    break;
                case "DatePost":
                    this.view.ViewData["today"] = ((DateTime)this.view.ViewData["today"]).AddDays(1);
                    this.view.ViewData["tasksByDay"] = this.taskService.GetTasksByDay((DateTime)this.view.ViewData["today"]);
                    this.view.UpdateView("DatePost");
                    break;
                case "ExportTasks":
                    ExportTasks();
                    this.view.UpdateView("");
                    break;
                case "TaskStopped":
                    this.view.ViewData["today"] = "";
                    this.view.UpdateView("TaskStopped");
                    break;

                default:
                    break;
            }
        }

        private void SaveTask(Guid activityId, string notes)
        {
            Task task = new Task { ActivityId = activityId, DatetimeFrom = start, DatetimeTo = now, Diff = 0, Notes = notes };
            this.taskService.AddTask(task);
        }

        private void ExportTasks()
        {
            IList<Task> tasks = this.taskService.GetTasksByRange(((DateTime)this.view.ViewData["ExportFrom"]).Date, ((DateTime)this.view.ViewData["ExportTo"]).Date);

            if (OnTasksCountEvent != null)
            {
                OnTasksCountEvent(this, new DataEventArgs<int>(tasks.Count + 3));
            }

            if (OnExportStatusUpdatedEvent != null)
            {
                OnExportStatusUpdatedEvent(this, new DataEventArgs<string>("Creating File"));
            }

            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Exports\\";
            StreamWriter textWriter = new StreamWriter(@path + "export" + DateTime.Now.Second.ToString() + ".csv", true);
            string pc = ";";

            int count = 1;

            foreach (Task task in tasks)
            {
                textWriter.WriteLine(task.activity.Description + pc + task.DatetimeFrom + pc + task.DatetimeTo + pc + task.Diff);

                if (OnExportStatusUpdatedEvent != null)
                {
                    OnExportStatusUpdatedEvent(this, new DataEventArgs<string>("Exporting tasks " + count.ToString() + " / " + tasks.Count.ToString()));
                }

                count = count + 1;
            }

            if (OnExportStatusUpdatedEvent != null)
            {
                OnExportStatusUpdatedEvent(this, new DataEventArgs<string>("Closing File"));
            }

            textWriter.Flush();
            textWriter.Close();

            if (OnExportStatusUpdatedEvent != null)
            {
                OnExportStatusUpdatedEvent(this, new DataEventArgs<string>("Done !"));
            }
        }
    }
}
