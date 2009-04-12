namespace TimeTracker.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Mobile.Mvc;
    using TimeTracker.Services.Contracts;
    using System.IO;

    public class TaskController : Controller<Task>
    {
        [PublishEvent("OnExportStatusUpdated")]
        public event EventHandler<DataEventArgs<string>> OnExportStatusUpdatedEvent;

        [PublishEvent("OnTasksCount")]
        public event EventHandler<DataEventArgs<int>> OnTasksCountEvent;

        private TimeTracker.Services.TaskService taskService { get; set; }

        public TaskController(IView<Task> view)
            : base(view)
        {
            this.taskService = new TimeTracker.Services.TaskService();
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

                default:
                    break;
            }
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

            string path =  System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Exports\\";
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
