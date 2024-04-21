namespace Services.Services.Responses.Reports;

public record GetByDateResponse(Guid Id, decimal Amount, decimal DebitAmount, decimal CreditAmount, IEnumerable<TransactionResponse> Transactions);

public record TransactionResponse(decimal Amount, string Type);