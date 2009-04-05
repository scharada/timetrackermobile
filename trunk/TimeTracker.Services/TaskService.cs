using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracker.Services.Contracts;
using TimeTracker.Services.Contracts.Services;

namespace TimeTracker.Services
{
    public class TaskService : ITaskService
    {
        public TaskService()
        {
            this.dataAccess = new TimeTracker.Services.Data.Dataaccess();
        }

        public Data.Dataaccess dataAccess { get; set; }

        public IList<Activity> GetActivities()
        {
            return this.dataAccess.GetActivities();
        }

        public IList<Task> GetTasks()
        {
            return this.dataAccess.GetTasks();
        }

        public IList<Task> GetTasksByDay(DateTime day)
        {
            return this.dataAccess.GetTasksByDay(day);
        }

        public IList<Task> GetTasksByRange(DateTime from, DateTime to)
        {
            return this.dataAccess.GetTasksByRange(from, to);
        }

        public void AddActivity(Activity activity)
        {
            this.dataAccess.AddActivity(activity);
        }

        public void AddTask(Task task)
        {
            this.dataAccess.AddTask(task);
        }

    }
}
