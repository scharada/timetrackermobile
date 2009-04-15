namespace TimeTracker.Controllers
{
    using System.Mobile.Mvc;
    using System.Windows.Forms;

    public class AboutController : Controller
    {
        public AboutController(IView view)
            : base(view)
        {
        
        }

        protected override void OnViewStateChanged(string key)
        {
            switch (key)
            {
                case "Load":
                    this.view.ViewData["author"] = "Sebastian Renzi";
                    this.view.ViewData["version"] = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    this.view.UpdateView("Load");
                    break;

                default:
                    break;
            }
        }
    }
}
