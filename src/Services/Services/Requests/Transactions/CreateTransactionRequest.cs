using Domain.Entities;

namespace Services.Services.Requests;

public record CreateTransactionRequest(decimal Amount, TransactionType Type);