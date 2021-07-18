namespace Components.DataAccess.Sql.Executioner
{
    using Components.DataAccess.Sql.Accessors;
    using Components.DataAccess.Sql.Persistence;
    using System.Collections.Generic;

    internal class SqlExecutioner : IExecutioner
    {
        private readonly IConnectionStringAccessor _connectionStringAccessor;
        private readonly Queue<SqlCommandDetail> _orderOfExecutions;
        private readonly IPersistent _peristent;

        public SqlExecutioner(
            IConnectionStringAccessor connectionStringAccessor,
            Queue<SqlCommandDetail> orderOfExecutions,
            IPersistent sqlPeristent)
        {
            _connectionStringAccessor = connectionStringAccessor;
            _orderOfExecutions = orderOfExecutions;
            _peristent = sqlPeristent;
        }

        public void Commit(string connectionStringKey) => InternalCommit(connectionStringKey);
        public void Execute(SqlCommandDetail detail) => InternalExecute(detail);

        private void InternalCommit(string connectionStringKey)
        {
            var connectionString = _connectionStringAccessor.GetConnectionString(connectionStringKey);            
            _peristent.PersistMultipleCommandsInSingleTransaction(connectionString, _orderOfExecutions);
        }
        private void InternalExecute(SqlCommandDetail detail) => _orderOfExecutions.Enqueue(detail);
    }
}
