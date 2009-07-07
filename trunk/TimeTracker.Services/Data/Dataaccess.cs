namespace TimeTracker.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlServerCe;
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

        public void RemoveActivity(Guid id)
        {
            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                try
                {
                    command.Transaction = command.Connection.BeginTransaction();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE Tasks WHERE ActivityId = '" + id.ToString() + "'";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE Activities WHERE Id = '" + id.ToString() + "'";
                    command.ExecuteNonQuery();

                    command.Transaction.Commit();
                }
                catch (Exception)
                {
                    command.Transaction.Rollback();
                    throw;
                }
            }
        }

        public void RemoveTask(Guid id)
        {
            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                try
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "DELETE Tasks WHERE Id = '" + id.ToString() + "'";
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
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

        public void UpdateTask(Task task)
        {
            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE Tasks SET ActivityId ='" + task.ActivityId +
                    "', DatetimeFrom = '" + task.DatetimeFrom + "', DatetimeTo = '" + task.DatetimeTo +
                    "', Diff = " + task.Diff + " WHERE Id = '" + task.Id + "'";

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

        public Task GetTask(Guid id)
        {

            using (var command = DBConnectionProvider.Current.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT T.Id, T.ActivityId, T.DatetimeFrom, T.DatetimeTo, T.Diff, A.Description FROM Tasks T INNER JOIN Activities A ON A.Id = T.ActivityId WHERE T.Id = '" + id.ToString() + "'";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Activity activity = new Activity { Id = reader.GetGuid(1), Description = reader.GetString(5) };

                        return new Task
                        {
                            Id = reader.GetGuid(0),
                            ActivityId = reader.GetGuid(1),
                            DatetimeFrom = reader.GetDateTime(2),
                            DatetimeTo = reader.GetDateTime(3),
                            Diff = reader.GetInt32(4),
                            activity = activity
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
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
