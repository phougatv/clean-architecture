namespace Components.User.Persistance.Poco
{
    using Components.Core.DataAccess.Base.Poco;
    using System;

    internal class Value : Entity
    {
        internal string Name { get; set; }
        internal DateTime? DateTime { get; set; }
    }
}
