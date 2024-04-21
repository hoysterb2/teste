using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReportController(IReportServices reportServices) : ControllerBase
{
    [HttpGet("get-by-date")]
    public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
    {
        return Ok(await reportServices.GetByDate(date));
    }
}