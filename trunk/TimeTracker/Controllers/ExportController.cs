using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Mobile.Mvc;
using System.IO;
using TimeTracker.Services.Contracts;

namespace TimeTracker.Controllers
{
    public class ExportController :Controller
    {

        [PublishEvent("OnExportStatusUpdated")]
        public event EventHandler<DataEventArgs<string>> OnExportStatusUpdatedEvent;

        [PublishEvent("OnTasksCount")]
        public event EventHandler<DataEventArgs<int>> OnTasksCountEvent;

        private TimeTracker.Services.TaskService taskService { get; set; }

        public ExportController(IView view)
            : base(view)
        {
            this.taskService = new TimeTracker.Services.TaskService();
        }

        protected override void OnViewStateChanged(string key)
        {
            switch (key)
            {
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

            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Exports\\";
            StreamWriter textWriter = new StreamWriter(@path + "export" + DateTime.Now.Second.ToString() + ".csv", true);
            string pc = ";";
            string dateTimeFrom = string.Empty;
            string dateTimeTo = string.Empty;

            int count = 1;

            foreach (Task task in tasks)
            {
                dateTimeFrom = string.Format("{0:dd/MM/yyyy HH:mm:ss}", task.DatetimeFrom);
                dateTimeTo = string.Format("{0:dd/MM/yyyy HH:mm:ss}", task.DatetimeTo);

                textWriter.WriteLine(task.activity.Description + pc + dateTimeFrom + pc + dateTimeTo + pc + task.Diff + pc + task.Notes);

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
