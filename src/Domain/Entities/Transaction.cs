using Domain.Entities.Base;

namespace Domain.Entities;

public class Transaction : Entity
{
    public decimal Amount { get; private set; }
    public TransactionType TransactionType { get; private set; }

    public Transaction(decimal amount, TransactionType transactionType)
    {
        Amount = amount;
        TransactionType = transactionType;
    }

    protected Transaction()
    {
    }
}