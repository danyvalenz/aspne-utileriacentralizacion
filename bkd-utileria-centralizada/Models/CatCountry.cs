using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bkd_utileria_centralizada.Models
{
    public partial class CatCountry
    {
        public CatCountry()
        {
            CatRegions = new HashSet<CatRegion>();
            ScheduleServices = new HashSet<ScheduleService>();
        }

        public int IdCountry { get; set; }
        public string? CountryName { get; set; }
        
        public virtual ICollection<CatRegion> CatRegions { get; set; }
        [JsonIgnore]
        public virtual ICollection<ScheduleService> ScheduleServices { get; set; }
    }
}
