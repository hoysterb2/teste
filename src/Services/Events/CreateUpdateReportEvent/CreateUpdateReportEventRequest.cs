using Domain.Entities;
using MediatR;

namespace Services.Events.CreateUpdateReportEvent;

public record CreateUpdateReportEventRequest(DateTime Date, TransactionType TransactionType, decimal Amount) : INotification;