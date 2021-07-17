namespace ConsoleApp.Controllers
{
    using AutoMapper;
    using Components.Value.Business;
    using Components.Value.Business.Models;
    using ConsoleApp.Value;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValueBusiness _business;

        public ValueController(
            IMapper mapper,
            IValueBusiness business)
        {
            _mapper = mapper;
            _business = business;
        }

        [HttpPost]
        public IActionResult Create(ValueViewModel viewModel)
        {
            var domainModel = _mapper.Map<ValueDomainModel>(viewModel);
            var isCreated = _business.Create(domainModel);
            if (isCreated)
                return StatusCode(Status201Created, "Successfully Created Value.");
            return StatusCode(Status304NotModified, "Failed to Create Value.");
        }
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Ping!");

        [HttpGet("ping/{name}")]
        public IActionResult PingName(string name) => Ok($"Hello {name}");

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var dto = _business.Get(id);
            return Ok(dto);
        }
    }
}
