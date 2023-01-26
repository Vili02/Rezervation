using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rezervation.DTOs;
using Rezervation.Services;

namespace Rezervation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfTransportsController : ControllerBase
    {
        private readonly ITypeOfTransportService _typeoftransportService;

        public TypeOfTransportsController(ITypeOfTransportService typeoftransportService)
        {
            _typeoftransportService = typeoftransportService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TypeOfTransportCrudDto dto)
        {
            return Ok(_typeoftransportService.Create(dto));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_typeoftransportService.GetAll());

        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_typeoftransportService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TypeOfTransportCrudDto dto)
        {
            return Ok(_typeoftransportService.Update(id, dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _typeoftransportService.Delete(id);
            return NoContent();
        }
    }
}
