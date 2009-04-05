using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using TimeTracker.Services.Contracts;
using System.Data;

namespace TimeTracker.Services.Data
{
    public class Dataaccess
    {
        public SqlCeConnection conn { get; set; }

        public Dataaccess()
        {
            this.conn = new SqlCeConnection(@"Data Source=\Program Files\timetracker\Data\Store.sdf");
            try
            {
                this.conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public IList<Activity> GetActivities()
        {
            List<Activity> activities = new List<Activity>();

            SqlCeCommand comm = new SqlCeCommand("SELECT Id, Description, Color FROM Activities");
            comm.Connection = this.conn;
            SqlCeDataReader myReader = comm.ExecuteReader();

            while (myReader.Read())
            {
                activities.Add(new Activity { Id = myReader.GetGuid(0), Description = myReader.GetString(1) });
            }
            myReader.Close();

            return activities;
        }

        public void AddActivity(Activity activity)
        {
            SqlCeCommand comm = new SqlCeCommand("INSERT INTO Activities(Id, Description, Color) VALUES (newid(),'" + activity.Description + "','" + activity.Color + "')");
            comm.Connection = this.conn;
            comm.ExecuteNonQuery();
        }

        public void AddTask(Task task)
        {
            SqlCeCommand comm = new SqlCeCommand("INSERT INTO Tasks(Id, ActivityId, DatetimeFrom, DatetimeTo, Diff) VALUES (newid(),'" + task.ActivityId + "','" + task.DatetimeFrom + "','" + task.DatetimeTo + "'," + task.Diff + ")");
            comm.Connection = this.conn;
            comm.ExecuteNonQuery();
        }

        public IList<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();

            SqlCeCommand comm = new SqlCeCommand("SELECT T.Id, T.ActivityId, T.DatetimeFrom, T.DatetimeTo, T.Diff, A.Description FROM Tasks T INNER JOIN Activities A ON A.Id = T.ActivityId");
            comm.Connection = this.conn;
            SqlCeDataReader myReader = comm.ExecuteReader();

            while (myReader.Read())
            {
                Activity activity = new Activity { Id = myReader.GetGuid(1), Description = myReader.GetString(5) };
                tasks.Add(new Task { Id = myReader.GetGuid(0), ActivityId = myReader.GetGuid(1), DatetimeFrom = myReader.GetDateTime(2), 
                    DatetimeTo = myReader.GetDateTime(3), Diff = myReader.GetInt32(4), activity = activity });
            }
            myReader.Close();

            return tasks;
        }

        public IList<Task> GetTasksByDay(DateTime day) 
        {
            List<Task> tasks = new List<Task>();
            string formatedDay = day.Year.ToString() + "-" + day.Month.ToString().PadLeft(2, '0') + "-" + day.Day.ToString().PadLeft(2, '0');

            SqlCeCommand comm = new SqlCeCommand("SELECT T.Id, T.ActivityId, T.DatetimeFrom, T.DatetimeTo, T.Diff, A.Description FROM Tasks T INNER JOIN Activities A ON A.Id = T.ActivityId WHERE CONVERT(nvarchar(10),DatetimeFrom,120) = '" + formatedDay + "'");
            comm.Connection = this.conn;
            SqlCeDataReader myReader = comm.ExecuteReader();

            while (myReader.Read())
            {
                Activity activity = new Activity { Id = myReader.GetGuid(1), Description = myReader.GetString(5) };
                tasks.Add(new Task
                {
                    Id = myReader.GetGuid(0),
                    ActivityId = myReader.GetGuid(1),
                    DatetimeFrom = myReader.GetDateTime(2),
                    DatetimeTo = myReader.GetDateTime(3),
                    Diff = myReader.GetInt32(4),
                    activity = activity
                });
            }
            myReader.Close();

            return tasks;
        }

        public IList<Task> GetTasksByRange(DateTime from, DateTime to)
        {
            List<Task> tasks = new List<Task>();
            string formatedDayFrom = from.Year.ToString() + "-" + from.Month.ToString().PadLeft(2, '0') + "-" + from.Day.ToString().PadLeft(2, '0');
            string formatedDayTo = to.Year.ToString() + "-" + to.Month.ToString().PadLeft(2, '0') + "-" + to.Day.ToString().PadLeft(2, '0');

            SqlCeCommand comm = new SqlCeCommand("SELECT T.Id, T.ActivityId, T.DatetimeFrom, T.DatetimeTo, T.Diff, A.Description FROM Tasks T INNER JOIN Activities A ON A.Id = T.ActivityId WHERE CONVERT(nvarchar(10),DatetimeFrom,120) >= '" + formatedDayFrom + "' AND CONVERT(nvarchar(10),DatetimeFrom,120) <= '" + formatedDayTo + "'");
            comm.Connection = this.conn;
            SqlCeDataReader myReader = comm.ExecuteReader();

            while (myReader.Read())
            {
                Activity activity = new Activity { Id = myReader.GetGuid(1), Description = myReader.GetString(5) };
                tasks.Add(new Task
                {
                    Id = myReader.GetGuid(0),
                    ActivityId = myReader.GetGuid(1),
                    DatetimeFrom = myReader.GetDateTime(2),
                    DatetimeTo = myReader.GetDateTime(3),
                    Diff = myReader.GetInt32(4),
                    activity = activity
                });
            }
            myReader.Close();

            return tasks;
        }
    }
}
