using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bkd_utileria_centralizada.Models
{
    public partial class CatRoute
    {
        public CatRoute()
        {
            ScheduleServices = new HashSet<ScheduleService>();
        }

        public int IdRoute { get; set; }
        public string? RouteName { get; set; }
        public int? IdDistribution { get; set; }

        public virtual CatDistribution? oDistribution { get; set; }
        [JsonIgnore]
        public virtual ICollection<ScheduleService> ScheduleServices { get; set; }
    }
}
