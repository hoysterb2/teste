namespace Services.Services.Responses.Transactions;

public record GetByDateResponse(Guid Id, DateTime Date, decimal Amount, string Type);