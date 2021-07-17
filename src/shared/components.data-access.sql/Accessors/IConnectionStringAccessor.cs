namespace Components.DataAccess.Sql.Accessors
{
    internal interface IConnectionStringAccessor
    {
        string GetConnectionString(string key);
    }
}
