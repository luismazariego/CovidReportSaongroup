namespace SaongroupCovidReports.Application.DTOs
{
    using SaongroupCovidReports.Application.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProvinceReportDto : IReport
    {
        public int Cases { get; set; }

        public int Deaths { get; set; }

        public string Province { get; set; }
    }
}
