namespace SaongroupCovidReports.Application.DTOs
{
    using SaongroupCovidReports.Application.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RegionsReportDto : IReport
    {
        public string Region { get; set; }

        public int Cases { get; set; }

        public int Deaths { get; set; }
    }
}
