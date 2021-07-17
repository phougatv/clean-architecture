namespace Components.Value.Automapper.Profiles
{
    using AutoMapper;
    using Components.Value.Business.Models;
    using Components.Value.Persistence.Poco;

    public class ValueProfile : Profile
    {
        public ValueProfile()
        {
            CreateMap<Value, ValueDomainModel>()
                .ForMember(destinationMember => destinationMember.Name, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Name))
                //.ForMember(destinationMember => destinationMember.DateTime, memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.DateTime))
                .ReverseMap();
        }
    }
}
