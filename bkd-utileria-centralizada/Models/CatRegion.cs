﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bkd_utileria_centralizada.Models
{
    public partial class CatRegion
    {
        public CatRegion()
        {
            CatDistributions = new HashSet<CatDistribution>();
            ScheduleServices = new HashSet<ScheduleService>();
        }

        public int IdRegion { get; set; }
        public string? RegionName { get; set; }
        [JsonIgnore]
        public int? IdCountry { get; set; }
        [JsonIgnore]
        public virtual CatCountry? oCountry { get; set; }
        [JsonIgnore]
        public virtual ICollection<CatDistribution> CatDistributions { get; set; }
        [JsonIgnore]
        public virtual ICollection<ScheduleService> ScheduleServices { get; set; }
    }
}
