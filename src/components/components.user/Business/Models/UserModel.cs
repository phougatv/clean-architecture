namespace Components.User.Business.Models
{
    using System;
    using Components.Shared.Domain.Base;

    public class UserModel : EntityModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
