using System;
namespace RideShare.Api.Models
{
    public class BookingViewModel
    {
        public int CustomerId { get; set; }
        public int TravelPlanId { get; set; }
        public int PurchasedSeat { get; set; }
    }
}
