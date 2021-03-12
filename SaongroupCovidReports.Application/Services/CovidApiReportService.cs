namespace SaongroupCovidReports.Application.Services
{
    using SaongroupCovidReports.Application.DTOs;
    using SaongroupCovidReports.Application.Interfaces;
    using SaongroupCovidReports.Domain.Entities;
    using SaongroupCovidReports.Infrastructure.Interfaces;
    

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CovidApiReportService : ICovidApiReportService
    {
        private readonly ICovidApiService _service;
        private Info _reportInfo;

        public CovidApiReportService(ICovidApiService service)
        {
            _service = service;

            _ = Initialize();
        }

        private Info Initialize()
        {
            try
            {
                _reportInfo = _service.GetReportsAsync().GetAwaiter().GetResult();

                return _reportInfo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProvinceReportDto>> GetTopTenProvinces(string region)
        {
            var regionResult = await _service.GetProvincesReportAsync(region).ConfigureAwait(false);

            var results = regionResult.Data.OrderByDescending(x => x.Confirmed).Take(10).ToList();

            return results.Select(x => new ProvinceReportDto
            {
                Province = x.Region.Province,
                Cases = x.Confirmed,
                Deaths = x.Deaths
            });
        }

        public IEnumerable<RegionsReportDto> GetTopTenRegions()
        {
            var report = GetTopTen(_reportInfo.Data);

            return report.OrderByDescending(x => x.Cases);
        }

        private List<RegionsReportDto> GetTopTen(List<Report> list)
        {
            var response = new List<RegionsReportDto>();

            var results = list.OrderByDescending(x => x.Confirmed).GroupBy(x => x.Region.Name).Take(10).ToList();

            foreach (var result in results)
            {
                var confirmed = 0;
                var deaths = 0;
                var name = "";
                foreach (var res in result)
                {
                    confirmed += res.Confirmed;
                    deaths += res.Deaths;
                    name = res.Region.Name;
                }
                var temp = new RegionsReportDto
                {
                    Cases = confirmed,
                    Deaths = deaths,
                    Region = name
                };

                response.Add(temp);
            }

            return response;
        }
    }
}
