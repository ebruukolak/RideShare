using System;
namespace RideShare.Data.Adapter.Models
{
    public class TravelPlanDetailModel
    {
        public int Id { get; set; }
        public int TravelPlanId { get; set; }
        public int CustomerId { get; set; }
        public int? PurchasedSeat { get; set; }
    }
}
