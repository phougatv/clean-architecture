namespace ConsoleApp.User.Controllers
{
    using Components.User.Business;
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
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public IActionResult Create(UserDto dto)
        {
            dto.User.Id = Guid.NewGuid();

            var isCreated = _userBusiness.Create(dto.User);
            if (!isCreated)
                return InternalActionResult(Status304NotModified, "User not created.");

            //dto.
            return InternalActionResult(Status201Created, dto.User);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var isDeleted = _userBusiness.Delete(id);
            if (isDeleted)
                InternalActionResult(Status204NoContent, "User deleted.");
            return InternalActionResult(Status304NotModified, id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userBusiness.Get(id);
            if (user == null)
                return InternalActionResult(Status404NotFound, "User not found");
            return InternalActionResult(Status200OK, user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userBusiness.GetAll();
            if (users == null || !users.Any())
                return NotFound();
            var dto = new UserDto(users, true, "");
            return Ok(dto);
        }

        [HttpPut]
        public IActionResult Update(UserDto dto)
        {
            _userBusiness.Update(dto.User);

            return Ok();
        }
    }
}
