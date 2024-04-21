using Domain.Entities;
using FluentValidation.Results;
using Services.Services.Validations.Transactions;

namespace Services.Services.Requests;

public record CreateTransactionRequest(decimal Amount, TransactionType Type)
{
    public ValidationResult ValidationResult()
    {
        var validator = new CreateTransactionRequestValidator();
        var result = validator.Validate(this);
        return result;
    }
}