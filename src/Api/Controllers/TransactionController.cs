using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;
using Services.Services.Requests;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TransactionController(ITransactionServices transactionServices) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTransaction(CreateTransactionRequest request)
    {
        var response = await transactionServices.Create(request);

        return Ok(response);
    }

    [HttpGet("get-by-date")]
    public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
    {
        var response = await transactionServices.GetByDate(date);

        return Ok(response);
    }
}

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