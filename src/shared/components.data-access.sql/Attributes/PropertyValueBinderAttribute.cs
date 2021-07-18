namespace Components.DataAccess.Sql.Attributes
{
    using System;
    using System.Linq;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class PropertyValueBinderAttribute : Attribute
    {
        private readonly Type _type;

        public PropertyValueBinderAttribute(Type type)
        {
            _type = type;
        }

        public PropertyInfo[] GetAllPropertiesWithCustomAttributes()
        {
            var properties = _type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Select(prop => prop.GetCustomAttributesData());

            return new PropertyInfo[1];
        }
    }
}
