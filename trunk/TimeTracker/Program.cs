namespace TimeTracker
{
    using System;
    using System.Windows.Forms;
    using TimeTracker.Controllers;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //if (TimeTracker.Helpers.Platform.IsWindowsMobileProfessional)
            //{
            //    Main form = new Main();
            //    TaskController controller = new TaskController(form);
            //    Application.Run(form);
            //}
            //else if (TimeTracker.Helpers.Platform.IsWindowsMobileStandard)
            //{
            MainStd form = new MainStd();
            TaskController controller = new TaskController(form);
            Application.Run(form);
            //}
        }
    }
}