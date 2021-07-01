namespace ConsoleApp.User.Controllers
{
    using AutoMapper;
    using Components.User.Business;
    using Components.User.Business.Models;
    using ConsoleApp.Base;
    using ConsoleApp.User.Dtos;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ComponentControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserBusiness _userBusiness;

        public UserController(
            IMapper mapper,
            IUserBusiness userBusiness)
        {
            _mapper = mapper;
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public IActionResult Create(UserViewModel user)
        {
            var userModel = _mapper.Map<UserDomainModel>(user);
            var isCreated = _userBusiness.Create(userModel);
            if (isCreated)
                //return InternalActionResult(Status201Created, "User created.");
                return StatusCode(Status201Created, "User created.");
            //return InternalActionResult(Status304NotModified, "User NOT created.");
            return StatusCode(Status304NotModified, "User NOT created.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var isDeleted = _userBusiness.Delete(id);
            if (isDeleted)
                return InternalActionResult(Status204NoContent, "User deleted.");
            return InternalActionResult(Status304NotModified, "User NOT deleted");
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userBusiness.Get(id);
            if (null != user)
                return InternalActionResult(Status200OK, user);
            return InternalActionResult(Status404NotFound, "User not found");            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userBusiness.GetAll();
            if (users == null || !users.Any())
                return NotFound();
            //var dto = new UserDto(users, true);
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update(UserDto dto)
        {
            _userBusiness.Update(dto.Data);

            return Ok();
        }
    }
}
