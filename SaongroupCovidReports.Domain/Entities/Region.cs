namespace SaongroupCovidReports.Domain.Entities
{
    using Newtonsoft.Json;

    using System.Collections.Generic;

    public class Region
    {
        [JsonProperty("iso")]
        public string Iso { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("cities")]
        public ICollection<City> Cities { get; set; }
    }
}
