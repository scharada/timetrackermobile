using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Mobile.Mvc;
using TimeTracker.Services.Contracts;

namespace TimeTracker.Controllers
{
    public class CategoryController : Controller<Activity>
    {
        private TimeTracker.Services.TaskService activityService { get; set; }

        public CategoryController(IView<Activity> view)
            : base(view)
        {
            this.activityService = new TimeTracker.Services.TaskService();
        }

        protected override void OnViewStateChanged(string key)
        {
            switch (key)
            {
                case "FillActivityGrid":
                    this.view.ViewData["activities"] = this.activityService.GetActivities();
                    this.view.UpdateView("FillActivityGrid");
                    break;
                case "AddActivity":
                    this.activityService.AddActivity((Activity)this.view.ViewData["activity"]);
                    this.view.ViewData["activities"] = this.activityService.GetActivities();
                    this.view.UpdateView("FillActivityGrid");
                    break;
                case "RemoveActivity":
                    this.activityService.RemoveActivity(new Guid(this.view.ViewData["activityGuid"].ToString()));
                    this.view.ViewData["activities"] = this.activityService.GetActivities();
                    //TODO: Review this call, should connect both controllers (category one with tasks)
                    //this.view.ViewData["tasksByDay"] = this.activityService.GetTasksByDay((DateTime)this.view.ViewData["today"]);
                    this.view.UpdateView("FillActivityGrid");
                    break;

                default:
                    break;
            }
        }

        private void OnCategorySelectedChanged(object sender, DataEventArgs<Guid> e)
        {
            this.view.ViewData["activityGuid"] = e.Value;
        }
    }
}
