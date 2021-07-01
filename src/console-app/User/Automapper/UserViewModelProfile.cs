namespace ConsoleApp.User.Automapper
{
    using AutoMapper;
    using Components.User.Business.Models;

    public class UserViewModelProfile : Profile
    {
        public UserViewModelProfile()
        {
            CreateMap<UserViewModel, UserDomainModel>().ReverseMap();
        }
    }
}
