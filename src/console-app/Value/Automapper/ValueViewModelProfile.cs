namespace ConsoleApp.Value.Automapper
{
    using AutoMapper;
    using Components.Value.Business.Models;

    public class ValueViewModelProfile : Profile
    {
        public ValueViewModelProfile()
        {
            CreateMap<ValueViewModel, ValueDomainModel>().ReverseMap();
        }
    }
}
