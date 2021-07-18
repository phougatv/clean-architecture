namespace Components.DataAccess.Sql
{
    using System.Collections.Generic;

    class SqlConfiguration
    {
        internal IDictionary<string, string> ConnectionStrings { get; set; }
        public SqlConfiguration()
        {

        }
    }
}
