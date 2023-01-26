using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rezervation.DTOs;
using Rezervation.Services;

namespace Rezervation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RoleCrudDto dto)
        {
            return Ok(_roleService.Create(dto));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_roleService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] RoleCrudDto dto)
        {
            return Ok(_roleService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _roleService.Delete(id);
            return NoContent();
        }
    }
}
