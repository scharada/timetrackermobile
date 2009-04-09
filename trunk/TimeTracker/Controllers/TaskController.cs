namespace TimeTracker.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Mobile.Mvc;
    using TimeTracker.Services.Contracts;

    public class TaskController : Controller<Task>
    {
        private TimeTracker.Services.TaskService taskService { get; set; }

        public TaskController(IView<Task> view): base(view)
        {
            this.taskService = new TimeTracker.Services.TaskService();
        }

        protected override void OnViewStateChanged(string key)
        {
            switch (key)
            {
                case "FillForm":
                    this.view.ViewData["activities"] = this.taskService.GetActivities();
                    this.view.ViewData.Model = this.taskService.GetTask(new Guid(this.view.ViewData["taskId"].ToString()));
                    this.view.UpdateView("FillForm");
                    break;
                case "Save":
                    this.taskService.UpdateTask(this.view.ViewData.Model);
                    this.view.UpdateView("");
                    break;
                default:
                    break;
            }
        }
    }
}
