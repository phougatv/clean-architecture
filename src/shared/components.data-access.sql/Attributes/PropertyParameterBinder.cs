namespace Components.DataAccess.Sql.Attributes
{
    using System;

    public class PropertyParameterBinderAttribute : Attribute
    {
        public string StoredProcParameterName { get; }

        public PropertyParameterBinderAttribute(string storedProcParameterName)
        {
            StoredProcParameterName = storedProcParameterName;
        }
    }
}
