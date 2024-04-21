using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Services.Events.CreateUpdateReportEvent;
using Services.Services.Base;
using Services.Services.Interfaces;
using Services.Services.Requests;
using Services.Services.Responses.Transactions;

namespace Services.Services;

public class TransactionServices(ITransactionRepository transactionRepository, IMediator mediator)
    : ITransactionServices
{
    public async Task<Response<CreateTransactionResponse>> Create(CreateTransactionRequest request)
    {
        Transaction transaction = new(request.Amount, request.Type);

        transactionRepository.Add(transaction);

        var success = await transactionRepository.CommitAsync();
        var transactionResponse = new CreateTransactionResponse(transaction.Id);

        if (success)
        {
            await mediator.Publish(new CreateUpdateReportEventRequest(transaction.CreatedAt, transaction.TransactionType,
                transaction.Amount));
        }

        return new(transactionResponse, success);
    }

    public async Task<Response<IEnumerable<GetByDateResponse>>> GetByDate(DateTime date)
    {
        var transactions = await transactionRepository.GetByDate(date);

        var transactionsResponse = transactions.Select(x => new GetByDateResponse(x.Id, x.CreatedAt, x.Amount, x.TransactionType.ToString()));

        return new Response<IEnumerable<GetByDateResponse>>(transactionsResponse, true);
    }
}