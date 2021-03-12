namespace SaongroupCovidReports.Domain.Entities
{
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;

    public class Info
    {
        [JsonProperty("data")]
        public List<Report> Data { get; set; }
    }

    public class Report
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }

        [JsonProperty("confirmed_diff")]
        public int Confirmed_Diff { get; set; }

        [JsonProperty("deaths_diff")]
        public int Deaths_Diff { get; set; }

        [JsonProperty("recovered_diff")]
        public int Recovered_Diff { get; set; }

        [JsonProperty("last_update")]
        public DateTime Last_Update { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("active_diff")]
        public int Active_Diff { get; set; }

        [JsonProperty("fatality_rate")]
        public decimal Fatality_Rate { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

    }
}
