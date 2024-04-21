using FluentValidation;
using Services.Services.Requests;

namespace Services.Services.Validations.Transactions;

public class CreateTransactionRequestValidator : AbstractValidator<CreateTransactionRequest>
{
    public CreateTransactionRequestValidator()
    {
        RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull()
            .Must(x => x > 0)
            .WithMessage("Invalid Amount");
    }
}