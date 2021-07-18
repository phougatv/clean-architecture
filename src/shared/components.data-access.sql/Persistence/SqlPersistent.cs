namespace Components.DataAccess.Sql.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class SqlPersistent : IPersistent
    {
        public SqlPersistent()
        {

        }

        void IPersistent.PersistMultipleCommandsInSingleTransaction(
            string connectionString,
            Queue<SqlCommandDetail> orderOfExecutions)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();  //TODO: provide transaction and log it. So one can get a better handle on why the transaction failed and why?
            try
            {
                foreach (var detail in orderOfExecutions)
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;
                    command.CommandType = detail.CommandType;
                    command.CommandText = detail.CommandText;
                    detail.PerformParamBinding(command.Parameters);
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)        //TODO: Use specific exception.
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
