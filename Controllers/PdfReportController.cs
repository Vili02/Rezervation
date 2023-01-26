using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rezervation.Services;

namespace Rezervation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfReportController : ControllerBase
    {
        private readonly IPdfReport _pdfreportservice;

        public PdfReportController(IPdfReport pdfreportservice)
        {
            _pdfreportservice = pdfreportservice;
        }

        [HttpGet]
        public IActionResult GetPdfReport()
        {
            _pdfreportservice.ExportPdf();
            return Ok("Pdf Report created!");
        }
    }

}
