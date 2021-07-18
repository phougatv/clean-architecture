namespace Components.Value.Persistence.Repository
{
    using Components.Core.DataAccess.Base.Interfaces;
    using Components.DataAccess.Sql;
    using Components.DataAccess.Sql.Enums;
    using Components.DataAccess.Sql.Executioner;
    using Components.DataAccess.Sql.Extensions;
    using Components.Value.Persistence.Base;
    using Components.Value.Persistence.Poco;
    using System;
    using System.Collections.Generic;
    using System.Data;

    internal class ValueRepository : IValueRepository
    {
        private bool _disposed = false;
        private ValueDbContext _dbContext;
        private IExecutioner _sqlExecutioner;

        public ValueRepository(ValueDbContext dbContext, IExecutioner sqlExecutioner)
        {
            _dbContext = dbContext;
            _sqlExecutioner = sqlExecutioner;
        }

        bool IRepository<Value>.Create(Value entity)
        {
            var commandDetail = new SqlCommandDetail
            {
                Command = Command.Create,
                CommandText = "CreateValue",
                CommandType = CommandType.StoredProcedure
            };
            commandDetail.PerformParamBinding = entity.GetSqlParameterCollection(commandDetail.PerformParamBinding);

            _sqlExecutioner.Execute(commandDetail);

            return true;
        }
        bool IRepository<Value>.Delete(Guid id) => throw new NotImplementedException();
        bool IRepository<Value>.Delete(Value entity) => throw new NotImplementedException();
        Value IRepository<Value>.Get(Guid id) =>
            new Value
            {
                Name = "value_1",
            };
        IEnumerable<Value> IRepository<Value>.GetAll() => throw new NotImplementedException();
        bool IRepository<Value>.Update(Value entity) => throw new NotImplementedException();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {

            }

            _disposed = true;
        }
    }
}
