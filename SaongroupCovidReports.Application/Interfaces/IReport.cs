namespace SaongroupCovidReports.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IReport
    {
        int Cases { get; set; }

        int Deaths { get; set; }
    }
}
