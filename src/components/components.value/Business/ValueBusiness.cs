namespace Components.Value.Business
{
    using AutoMapper;
    using Components.Value.Business.Models;
    using Components.Value.Persistence.Repository;
    using Components.Value.Persistence.Poco;
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

        public bool Create(ValueDomainModel model)
        {
            var poco = _mapper.Map<Value>(model);
            var isCreated = _repository.Create(poco);

            return isCreated;
        }

        public ValueDomainModel Get(Guid id)
        {
            var poco = _repository.Get(id);
            var dto = _mapper.Map<ValueDomainModel>(poco);

            return dto;
        }
    }
}
