namespace Services.Services.Responses.Transactions;

public record GetTransactionResponse(Guid Id, decimal Amount, string Type);