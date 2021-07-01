namespace ConsoleApp.User.Dtos
{
    using Components.User.Business.Models;
    using ConsoleApp.Base;

    public class UserDto : ComponentBaseResponse
    {
        public UserDomainModel Data { get; set; }

        public UserDto(UserDomainModel userModel, bool isValid)
            : base(isValid)
        {
            Data = userModel;
        }
    }
}
