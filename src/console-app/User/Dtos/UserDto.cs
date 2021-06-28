namespace ConsoleApp.User.Dtos
{
    using Components.User.Business.Models;
    using ConsoleApp.Base;
    using System.Collections.Generic;

    public class UserDto : ComponentBaseResponse
    {
        public UserModel User { get; set; }
        public IEnumerable<UserModel> Users { get; set; }
        
        public UserDto(UserModel user, bool isValid, string message)
            : base(isValid, message)
        {
            User = user;
        }
        public UserDto(IEnumerable<UserModel> users, bool isValid, string message)
            : base(isValid, message)
        {
            Users = users;
        }
    }
}
