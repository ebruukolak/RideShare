using System;
namespace RideShare.Data.Adapter.Models
{
    public class TravelPlanModel
    {
       
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public string Description { get; set; }
        public DateTime TravelDate { get; set; }
        public int? AvailableSeatCount { get; set; }
        public bool? IsPublished { get; set; }
    
    }
}
