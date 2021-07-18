namespace Components.Value.Business
{
    using AutoMapper;
    using Components.DataAccess.Sql.Executioner;
    using Components.Value.Business.Models;
    using Components.Value.Persistence.Poco;
    using Components.Value.Persistence.Repository;
    using System;

    internal class ValueBusiness : IValueBusiness
    {
        private readonly IExecutioner _sqlExecutioner;
        private readonly IValueRepository _repository;
        private readonly IMapper _mapper;

        public ValueBusiness(IExecutioner sqlExecutioner, IValueRepository repository, IMapper mapper)
        {
            _sqlExecutioner = sqlExecutioner;
            _repository = repository;
            _mapper = mapper;
        }

        public bool Create(ValueDomainModel model)
        {
            var poco = _mapper.Map<Value>(model);
            var isCreated = _repository.Create(poco);
            _sqlExecutioner.Commit("Value");

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
