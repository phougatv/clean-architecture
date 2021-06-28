namespace ConsoleApp.Controllers
{
    using Components.Value.Business;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly IValueBusiness _business;

        public ValueController(IValueBusiness business)
        {
            _business = business;
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
            //_business.Get(id);
            //return Ok();
        }
    }
}
