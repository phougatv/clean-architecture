namespace Components.Value.Business
{
    using AutoMapper;
    using Components.Value.Persistance.Repository;
    using Components.Value.Business.Models;
    using System;

    internal class ValueBusiness : IValueBusiness
    {
        private readonly IValueRepository _repository;
        private readonly IMapper _mapper;

        public ValueBusiness(IValueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ValueModel Get(Guid id)
        {
            var poco = _repository.Get(id);
            var dto = _mapper.Map<ValueModel>(poco);

            return dto;
        }
    }
}
