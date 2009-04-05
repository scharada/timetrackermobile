namespace TimeTracker.Services.Providers
{
    using System;
    using System.Data;
    using System.Data.SqlServerCe;

    public class DBConnectionProvider : IDBConnectionProvider, IDisposable
    {
        private static readonly string ConnectionString = "Data Source=" + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data\\Store.sdf;");

        private SqlCeConnection connection;
        private bool isDisposed;

        static DBConnectionProvider()
        {
            Current = new DBConnectionProvider();
        }

        ~DBConnectionProvider()
        {
            this.Dispose(false);
        }

        public static IDBConnectionProvider Current
        {
            get;
            private set;
        }

        private SqlCeConnection Connection
        {
            get
            {
                if (this.connection == null || this.connection.State == ConnectionState.Closed || this.connection.State == ConnectionState.Broken)
                {
                    this.connection = new SqlCeConnection(ConnectionString);
                    this.connection.Open();
                }

                return this.connection;
            }
        }

        private SqlCeTransaction Transaction
        {
            get;
            set;
        }

        public IDbCommand CreateCommand()
        {
            return this.CreateCommand(null);
        }

        public IDbCommand CreateCommand(string commandText)
        {
            if (this.Transaction != null)
            {
                return new SqlCeCommand()
                {
                    CommandText = commandText,
                    Connection = this.Connection,
                    Transaction = this.Transaction
                };
            }
            else
            {
                return new SqlCeCommand()
                {
                    CommandText = commandText,
                    Connection = this.Connection
                };
            }
        }

        public void RollbackTransaction()
        {
            this.Transaction.Rollback();
            this.Transaction = null;
        }

        public void CommitTransaction()
        {
            this.Transaction.Commit();
            this.Transaction = null;
        }

        public void BeginTransaction()
        {
            this.Transaction = this.Connection.BeginTransaction();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    if (this.connection != null)
                    {
                        this.connection.Dispose();
                    }
                }

                this.isDisposed = true;
            }
        }
    }
}