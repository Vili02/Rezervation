using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rezervation.DTOs;
using Rezervation.Models;
using Rezervation.Services;

namespace Rezervation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly IOrganizerService _organizerService;

        public OrganizersController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrganizerCrudDto dto)
        {
            return Ok(_organizerService.Create(dto));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_organizerService.GetAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            return Ok(_organizerService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] OrganizerCrudDto dto)
        {
            return Ok(_organizerService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _organizerService.Delete(id);
            return NoContent();
        }
    }
}