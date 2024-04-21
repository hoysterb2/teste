namespace Domain.Repositories;

public interface IRepository
{
    Task<bool> CommitAsync();
}