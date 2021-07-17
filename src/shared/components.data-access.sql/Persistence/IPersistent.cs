namespace Components.DataAccess.Sql.Persistence
{
    using System.Collections.Generic;

    internal interface IPersistent
    {
        internal void PersistMultipleCommandsInSingleTransaction(
            string connectionString,
            Queue<SqlCommandDetail> orderOfExecutions);
    }
}