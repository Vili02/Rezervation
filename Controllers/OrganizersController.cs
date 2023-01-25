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
            var organizers = _organizerService.GetAll();
            return Ok(organizers);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var organizer = _organizerService.GetById(id);
            return Ok(organizer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrganizerCrudDto dto)
        {
            var organizer = _organizerService.Update(id, dto);
            return Ok(organizer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _organizerService.Delete(id);
            return Ok("Deleted!");
        }
    }
}