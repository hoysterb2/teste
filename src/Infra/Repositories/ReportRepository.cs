using System.Runtime.InteropServices.JavaScript;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly ApplicationDbContext _context;
    public ReportRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public void Add(Report report)
    {
        _context.Add(report);
    }

    public void Update(Report report)
    {
        _context.Update(report);
    }

    public async Task<Report> GetByDate(DateTime date)
    {
        var report = await _context.Reports
            .SingleOrDefaultAsync(x => x.Date.Date == date.Date);

        return report;
    }
}