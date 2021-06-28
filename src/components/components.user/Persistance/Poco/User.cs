namespace Components.User.Persistance.Poco
{
    using Shared.DataAccess.Base.Poco;
    using System;

    internal class User : Entity
    {
        internal string FirstName { get; set; }
        internal string MiddleName { get; set; }
        internal string LastName { get; set; }
        internal string EmailId { get; set; }
        internal DateTime DateOfBirth { get; set; }
    }
}
