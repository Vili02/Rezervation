using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rezervation.DTOs;
using Rezervation.Services;

namespace Rezervation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TripCrudDto dto)
        {
            return Ok(_tripService.Create(dto));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tripService.GetAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_tripService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TripCrudDto dto)
        {
            return Ok(_tripService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _tripService.Delete(id);
            return NoContent();
        }
    }
}
