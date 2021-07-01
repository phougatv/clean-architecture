namespace Components.Value.Persistance.Repository
{
    using Components.Core.DataAccess.Base.Interfaces;
    using Components.User.Persistance.Poco;
    using System;
    using System.Collections.Generic;

    internal class ValueRepository : IValueRepository
    {
        private bool _disposed = false;
        bool IRepository<Value>.Create(Value entity) => throw new NotImplementedException();
        bool IRepository<Value>.Delete(Guid id) => throw new NotImplementedException();
        bool IRepository<Value>.Delete(Value entity) => throw new NotImplementedException();
        Value IRepository<Value>.Get(Guid id) =>
            new Value
            {
                Name = "value_1",
                DateTime = DateTime.Now
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
