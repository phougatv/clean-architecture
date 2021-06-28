namespace Components.User.Automapper.Profiles
{
    using AutoMapper;
    using Components.User.Business.Models;
    using Components.User.Persistance.Poco;

    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(destinationMember => destinationMember.Id, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Id))
                .ForMember(destinationMember => destinationMember.FirstName, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.FirstName))
                .ForMember(destinationMember => destinationMember.MiddleName, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.MiddleName))
                .ForMember(destinationMember => destinationMember.LastName, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.LastName))
                .ForMember(destinationMember => destinationMember.EmailId, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.EmailId))
                .ForMember(destinationMember => destinationMember.DateOfBirth, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.DateOfBirth))
                .ForMember(destinationMember => destinationMember.CreatedBy, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.CreatedBy))
                .ForMember(destinationMember => destinationMember.UpdatedBy, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.UpdatedBy))
                .ForMember(destinationMember => destinationMember.CreatedOn, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.CreatedOn))
                .ForMember(destinationMember => destinationMember.UpdatedOn, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.UpdatedOn))
                //.ForAllMembers(memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.)
                .ReverseMap();
        }
    }
}
