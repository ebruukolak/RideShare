using System;
using System.Collections.Generic;

namespace RideShare.Data.Context
{
    public partial class TravelPlanDetail
    {
        public int Id { get; set; }
        public int TravelPlanId { get; set; }
        public int CustomerId { get; set; }
        public int? PurchasedSeat { get; set; }

        public virtual User Customer { get; set; }
        public virtual TravelPlan TravelPlan { get; set; }
    }
}
