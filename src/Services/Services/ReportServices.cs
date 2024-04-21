using Domain.Repositories;
using Services.Services.Base;
using Services.Services.Interfaces;
using Services.Services.Responses.Reports;

namespace Services.Services;

public class ReportServices(IReportRepository reportRepository, ITransactionRepository transactionRepository) : IReportServices
{
    public async Task<Response<GetByDateResponse>> GetByDate(DateTime date)
    { 
        var report = await reportRepository.GetByDate(date);

        if (report is null) return new Response<GetByDateResponse>(null, true);

        var transactions =
            await transactionRepository.GetByDate(date);

        var transactionsResponse =
            transactions.Select(x => new TransactionResponse(x.Amount, x.TransactionType.ToString()));

        var reportResponse = new GetByDateResponse(report.Id, report.Amount, report.DebitAmount, report.CreditAmount,
            transactionsResponse);

        return new(reportResponse, true);
    }
}