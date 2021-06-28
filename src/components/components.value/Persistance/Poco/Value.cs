namespace Components.User.Persistance.Poco
{
    using Components.Shared.DataAccess.Base.Poco;
    using System;

    internal class Value : Entity
    {
        internal string Name { get; set; }
        internal DateTime? DateTime { get; set; }
    }
}
