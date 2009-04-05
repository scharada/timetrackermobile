namespace TimeTracker.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlServerCe;
    using System.Linq;
    using System.Text;
    using TimeTracker.Services.Contracts;
    using TimeTracker.Services.Providers;

    public class Dataaccess
    {
        public SqlCeConnection conn { get; set; }

        public Dataaccess()
        {
        }

        public IList<Activity> GetActivities()
        {
            List<Activity> activities = new List<Activity>();

            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Id, Description, Color FROM Activities";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        activities.Add(new Activity { Id = reader.GetGuid(0), Description = reader.GetString(1) });
                    }
                }
            }
            return activities;
        }

        public void AddActivity(Activity activity)
        {
            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Activities(Id, Description, Color) VALUES (newid(),'" + activity.Description + "','" + activity.Color + "')";
                command.ExecuteNonQuery();
            }
        }

        public void AddTask(Task task)
        {
            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Tasks(Id, ActivityId, DatetimeFrom, DatetimeTo, Diff) VALUES (newid(),'" + task.ActivityId + "','" + task.DatetimeFrom + "','" + task.DatetimeTo + "'," + task.Diff + ")";
                command.ExecuteNonQuery();
            }
        }

        public IList<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();

            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT T.Id, T.ActivityId, T.DatetimeFrom, T.DatetimeTo, T.Diff, A.Description FROM Tasks T INNER JOIN Activities A ON A.Id = T.ActivityId";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity { Id = reader.GetGuid(1), Description = reader.GetString(5) };
                        tasks.Add(new Task
                        {
                            Id = reader.GetGuid(0),
                            ActivityId = reader.GetGuid(1),
                            DatetimeFrom = reader.GetDateTime(2),
                            DatetimeTo = reader.GetDateTime(3),
                            Diff = reader.GetInt32(4),
                            activity = activity
                        });
                    }
                }
            }
            return tasks;
        }

        public IList<Task> GetTasksByDay(DateTime day)
        {
            List<Task> tasks = new List<Task>();
            string formatedDay = day.Year.ToString() + "-" + day.Month.ToString().PadLeft(2, '0') + "-" + day.Day.ToString().PadLeft(2, '0');

            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT T.Id, T.ActivityId, T.DatetimeFrom, T.DatetimeTo, T.Diff, A.Description FROM Tasks T INNER JOIN Activities A ON A.Id = T.ActivityId WHERE CONVERT(nvarchar(10),DatetimeFrom,120) = '" + formatedDay + "'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity { Id = reader.GetGuid(1), Description = reader.GetString(5) };
                        tasks.Add(new Task
                        {
                            Id = reader.GetGuid(0),
                            ActivityId = reader.GetGuid(1),
                            DatetimeFrom = reader.GetDateTime(2),
                            DatetimeTo = reader.GetDateTime(3),
                            Diff = reader.GetInt32(4),
                            activity = activity
                        });
                    }
                }
            }

            return tasks;
        }

        public IList<Task> GetTasksByRange(DateTime from, DateTime to)
        {
            List<Task> tasks = new List<Task>();
            string formatedDayFrom = from.Year.ToString() + "-" + from.Month.ToString().PadLeft(2, '0') + "-" + from.Day.ToString().PadLeft(2, '0');
            string formatedDayTo = to.Year.ToString() + "-" + to.Month.ToString().PadLeft(2, '0') + "-" + to.Day.ToString().PadLeft(2, '0');

            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT T.Id, T.ActivityId, T.DatetimeFrom, T.DatetimeTo, T.Diff, A.Description FROM Tasks T INNER JOIN Activities A ON A.Id = T.ActivityId WHERE CONVERT(nvarchar(10),DatetimeFrom,120) >= '" + formatedDayFrom + "' AND CONVERT(nvarchar(10),DatetimeFrom,120) <= '" + formatedDayTo + "'";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity { Id = reader.GetGuid(1), Description = reader.GetString(5) };
                        tasks.Add(new Task
                        {
                            Id = reader.GetGuid(0),
                            ActivityId = reader.GetGuid(1),
                            DatetimeFrom = reader.GetDateTime(2),
                            DatetimeTo = reader.GetDateTime(3),
                            Diff = reader.GetInt32(4),
                            activity = activity
                        });
                    }
                }
            }
            return tasks;
        }
    }
}
