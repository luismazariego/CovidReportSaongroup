namespace SaongroupCovidReports.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using SaongroupCovidReports.Application.Interfaces;

    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]    
    public class CovidReportsController : ControllerBase
    {
        private readonly ICovidApiReportService _service;

        public CovidReportsController(ICovidApiReportService service)
        {
            _service = service;
        }

        [Route("regions")]
        public IActionResult GetTopRegions()
        {
            return Ok(_service.GetTopTenRegions());
        }

        [Route("provinces")]
        public async Task<IActionResult> GetTopRegions([FromQuery] string country)
        {
            return Ok(await _service.GetTopTenProvinces(country).ConfigureAwait(false));
        }
    }
}

