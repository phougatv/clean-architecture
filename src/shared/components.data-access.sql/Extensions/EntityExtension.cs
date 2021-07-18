namespace Components.DataAccess.Sql.Extensions
{
    using Components.DataAccess.Sql.Attributes;
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    public static class EntityExtension
    {
        private static readonly BindingFlags _nonPublic = BindingFlags.NonPublic;
        private static readonly BindingFlags _instance = BindingFlags.Instance;
        private static readonly BindingFlags _public = BindingFlags.Public;

        public static Action<SqlParameterCollection> GetSqlParameterCollection<T>(this T entity, Action<SqlParameterCollection> performParamBinding)
        {
            var allInstanceProperties = entity
                .GetType()
                .GetProperties(_public | _nonPublic | _instance);

            performParamBinding = p =>
            {
                foreach (var property in allInstanceProperties)
                {
                    var attribute = (PropertyParameterBinderAttribute)property.GetCustomAttributes().FirstOrDefault(p => p is PropertyParameterBinderAttribute);
                    if (null == attribute)
                        continue;
                    var param = attribute.StoredProcParameterName;
                    var value = property.GetValue(entity, null);
                    p.AddWithValue(param, value);
                }
            };

            return performParamBinding;
        }
    }
}
