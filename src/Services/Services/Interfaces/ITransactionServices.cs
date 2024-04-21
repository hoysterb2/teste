using Services.Services.Base;
using Services.Services.Requests;
using Services.Services.Responses.Transactions;

namespace Services.Services.Interfaces;

public interface ITransactionServices
{
    Task<Response<CreateTransactionResponse>> Create(CreateTransactionRequest request);
    Task<Response<IEnumerable<GetByDateResponse>>> GetByDate(DateTime date);
}