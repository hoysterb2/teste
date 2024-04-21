using Domain.Entities;

namespace Domain.Repositories;

public interface ITransactionRepository : IRepository
{
    void Add(Transaction transaction);
    Task<IEnumerable<Transaction>> GetByTypeAndDate(DateTime date, TransactionType type);
    Task<IEnumerable<Transaction>> GetByDate(DateTime date);
}