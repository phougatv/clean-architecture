namespace Components.Value.Automapper.Profiles
{
    using AutoMapper;
    using Components.User.Persistance.Poco;
    using Components.Value.Business.Models;

    public class ValueProfile : Profile
    {
        public ValueProfile()
        {
            CreateMap<Value, ValueModel>()
                //.ForMember(destinationMember => destinationMember.Name, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Name))
                //.ForMember(destinationMember => destinationMember.DateTime, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.DateTime))
                .ReverseMap();
        }
    }
}
