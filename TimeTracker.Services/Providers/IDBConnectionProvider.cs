namespace TimeTracker.Services.Providers
{
    using System.Data;

    public interface IDBConnectionProvider
    {
        IDbCommand CreateCommand(string commandText);

        IDbCommand CreateCommand();

        void RollbackTransaction();

        void CommitTransaction();

        void BeginTransaction();
    }
}
