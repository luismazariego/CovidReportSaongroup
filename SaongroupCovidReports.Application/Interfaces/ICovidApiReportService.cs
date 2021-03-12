namespace SaongroupCovidReports.Application.Interfaces
{
    using SaongroupCovidReports.Application.DTOs;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICovidApiReportService
    {
        IEnumerable<RegionsReportDto> GetTopTenRegions();

        Task<IEnumerable<ProvinceReportDto>> GetTopTenProvinces(string region);
    }
}
