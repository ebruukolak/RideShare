using System;
using System.Collections.Generic;

namespace RideShare.Data.Context
{
    public partial class TravelPlan
    {
        public TravelPlan()
        {
            TravelPlanDetail = new HashSet<TravelPlanDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public string Description { get; set; }
        public DateTime TravelDate { get; set; }
        public int? AvailableSeatCount { get; set; }
        public bool? IsPublished { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TravelPlanDetail> TravelPlanDetail { get; set; }
    }
}
