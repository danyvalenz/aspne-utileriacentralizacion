using System;
using System.Collections.Generic;

namespace bkd_utileria_centralizada.Models
{
    public partial class ScheduleService
    {
        public int IdScheduleService { get; set; }
        public int? IdCountry { get; set; }
        public int? IdRegion { get; set; }
        public int? IdDistribution { get; set; }
        public int? IdRoute { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual CatCountry? IdCountryNavigation { get; set; }
        public virtual CatDistribution? IdDistributionNavigation { get; set; }
        public virtual CatRegion? IdRegionNavigation { get; set; }
        public virtual CatRoute? IdRouteNavigation { get; set; }
    }
}
