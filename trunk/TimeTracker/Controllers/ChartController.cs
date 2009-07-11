namespace TimeTracker.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Mobile.Mvc;

    public class ChartController : Controller
    {
         private TimeTracker.Services.TaskService taskService { get; set; }

         public ChartController(IView view)
            : base(view)
        {
            this.taskService = new TimeTracker.Services.TaskService();
        }

        protected override void OnViewStateChanged(string key)
        {
            switch (key)
            {
             
                default:
                    break;
            }
        }
    }
}
