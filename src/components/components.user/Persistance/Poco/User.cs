namespace Components.User.Persistance.Poco
{
    using Components.Core.DataAccess.Base.Poco;
    using System;

    internal class User : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
