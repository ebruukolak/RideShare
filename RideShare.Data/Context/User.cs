using System;
using System.Collections.Generic;

namespace RideShare.Data.Context
{
    public partial class User
    {
        public User()
        {
            TravelPlan = new HashSet<TravelPlan>();
            TravelPlanDetail = new HashSet<TravelPlanDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<TravelPlan> TravelPlan { get; set; }
        public virtual ICollection<TravelPlanDetail> TravelPlanDetail { get; set; }
    }
}
