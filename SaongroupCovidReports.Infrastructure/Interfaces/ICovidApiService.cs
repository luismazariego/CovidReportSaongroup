namespace SaongroupCovidReports.Infrastructure.Interfaces
{
    using SaongroupCovidReports.Domain.Entities;

    using System.Threading.Tasks;

    public interface ICovidApiService
    {
        Task<Info> GetReportsAsync();

        Task<Info> GetProvincesReportAsync(string country);
    }
}
