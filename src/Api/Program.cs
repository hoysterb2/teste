using Api.Middlewares;
using Domain.Repositories;
using Infra;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Events.CreateUpdateReportEvent;
using Services.Services;
using Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddScoped<ITransactionServices, TransactionServices>();
builder.Services.AddScoped<IReportServices, ReportServices>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUpdateReportEventRequest).Assembly));

var app = builder.Build();

app.UseErrorHandlingMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();