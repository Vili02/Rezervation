using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Rezervation.Models;
using Microsoft.AspNetCore.Identity;
using Rezervation.Services;
using Rezervation.DTOs;
using Rezervation.Exceptions;

namespace Rezervation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                _userService.Create(user);
                return Ok($"You have register successfully {model.Username}");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {

            var user = _userService.GetById(id);
            var model = _mapper.Map<User>(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] RegisterModel model)
        {
            //allows to only edit your own profile and if you are admin you can edit all
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole("Admin"))
                return Forbid();

            // map model to entity and set id
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                // update user 
                _userService.Update(user);
                return Ok("Successfully updated");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            //allows to only delete your own profile and if you are admin you can delete all
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole("Admin"))
                return Forbid();

            _userService.Delete(id);
            return Ok("Deleted!");
        }
    }
}
