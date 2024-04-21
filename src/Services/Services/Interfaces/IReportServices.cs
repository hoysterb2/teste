using Services.Services.Base;
using Services.Services.Responses.Reports;

namespace Services.Services.Interfaces;

public interface IReportServices
{ 
    Task<Response<GetByDateResponse>> GetByDate(DateTime date);
}