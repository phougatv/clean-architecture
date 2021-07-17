namespace Components.Value.Persistence.Poco
{
    using Components.Core.DataAccess.Base.Poco;
    using System;

    internal class Value : Entity
    {
        internal string Name { get; set; }
    }
}
