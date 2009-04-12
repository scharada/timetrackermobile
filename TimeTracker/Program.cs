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
            Main form = new Main();
            TaskController controller = new TaskController(form);
            Application.Run(form);
        }
    }
}