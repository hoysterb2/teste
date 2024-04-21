using System.Runtime.InteropServices.ComTypes;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;
    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public void Add(Transaction transaction)
    {
        _context.Add(transaction);
    }

    public async Task<IEnumerable<Transaction>> GetByTypeAndDate(DateTime date, TransactionType type)
    {
        var query = GetByDateQuery(date).Where(x => x.TransactionType == type);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByDate(DateTime date)
    {
        var query = GetByDateQuery(date);

        var response = await query.ToListAsync();

        return response;
    }

    private IQueryable<Transaction> GetByDateQuery(DateTime date)
    {
        return _context.Transactions.Where(x => x.CreatedAt.Date == date.Date);
    }
}