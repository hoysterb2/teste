using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Services.Events.CreateUpdateReportEvent;

public class CreateUpdateReportEventHandler(ITransactionRepository transactionRepository, IReportRepository reportRepository)
    : INotificationHandler<CreateUpdateReportEventRequest>
{

    public async Task Handle(CreateUpdateReportEventRequest notification, CancellationToken cancellationToken)
    {
        var debitAmount =
            (await transactionRepository.GetByTypeAndDate(notification.Date, TransactionType.Debit)).Sum(x => x.Amount);

        var creditAmount =
            (await transactionRepository.GetByTypeAndDate(notification.Date, TransactionType.Credit)).Sum(x => x.Amount);

        var report = await reportRepository.GetByDate(notification.Date);

        if (report is null)
        {
            report = new Report(notification.Date, debitAmount, creditAmount);
            reportRepository.Add(report);
        }
        else
        {
            report.UpdateDailyReport(debitAmount, creditAmount);
            reportRepository.Update(report);
        }

        await reportRepository.CommitAsync();
    }
     
}