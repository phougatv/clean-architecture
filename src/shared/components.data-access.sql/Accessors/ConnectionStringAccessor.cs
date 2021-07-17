using System.Collections.Generic;

namespace Components.DataAccess.Sql.Accessors
{
    class ConnectionStringAccessor : IConnectionStringAccessor
    {
        private readonly SqlConfiguration _sqlConfiguration;
        
        public ConnectionStringAccessor(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        string IConnectionStringAccessor.GetConnectionString(string key)
        {
            if (_sqlConfiguration.ConnectionStrings.TryGetValue(key, out var connectionString))
                return connectionString;
            throw new KeyNotFoundException();
        }
    }
}
