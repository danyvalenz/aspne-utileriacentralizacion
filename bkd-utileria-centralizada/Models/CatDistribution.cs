using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bkd_utileria_centralizada.Models
{
    public partial class CatDistribution
    {
        public CatDistribution()
        {
            CatRoutes = new HashSet<CatRoute>();
            ScheduleServices = new HashSet<ScheduleService>();
        }

        public int IdDistribution { get; set; }
        public string? DistributionName { get; set; }
        public int? IdRegion { get; set; }

        public virtual CatRegion? oRegion { get; set; }
        public virtual ICollection<CatRoute> CatRoutes { get; set; }
        [JsonIgnore]
        public virtual ICollection<ScheduleService> ScheduleServices { get; set; }
    }
}
