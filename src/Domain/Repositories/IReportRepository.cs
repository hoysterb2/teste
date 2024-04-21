 using Domain.Entities;

namespace Domain.Repositories;

public interface IReportRepository : IRepository
{
    void Add(Report report);
    void Update(Report report);
    Task<Report> GetByDate(DateTime date);
}