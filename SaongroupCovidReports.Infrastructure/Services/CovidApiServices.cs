namespace SaongroupCovidReports.Infrastructure.Services
{
    using Microsoft.Extensions.Configuration;

    using Newtonsoft.Json;

    using RestSharp;

    using SaongroupCovidReports.Domain.Entities;
    using SaongroupCovidReports.Infrastructure.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CovidApiService : ICovidApiService
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;
        private readonly IConfiguration _config;

        public CovidApiService(IConfiguration config)
        {
            _client = new RestClient(config["AppSettings:Endpoint"]) { Timeout = -1 };
            _request = new RestRequest("reports", Method.GET);
            _request.AddHeader("x-rapidapi-key", config["AppSettings:ApiKey"]);
            _request.AddHeader("x-rapidapi-host", config["AppSettings:Host"]);
            _request.AddHeader("useQueryString", config["AppSettings:UseQueryString"]);
            _config = config;
        }

        public async Task<Info> GetProvincesReportAsync(string country)
        {
            _request.AddParameter("region_name", country);

            var result = await _client.ExecuteAsync(_request);

            var data = JsonConvert.DeserializeObject<Info>(result.Content);

            return data;
        }

        public async Task<Info> GetReportsAsync()
        {
            var result = await _client.ExecuteAsync(_request);

            var data = JsonConvert.DeserializeObject<Info>(result.Content);

            return data;
        }
    }
}
