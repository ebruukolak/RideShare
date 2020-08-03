using System;
using Microsoft.AspNetCore.Mvc;
using RideShare.Api.Models;
using RideShare.Business.Interfaces;
using RideShare.Data.Context;

namespace RideShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        ITravelPlanDetailManager _travelPlanDetailManager;
        public BookingController(ITravelPlanDetailManager travelPlanDetailManager)
        {
            _travelPlanDetailManager = travelPlanDetailManager;
        }
        [HttpPost]
        [Route("CreateBook")]
        public ActionResult CreateBook(BookingViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {
                _travelPlanDetailManager.Add(new TravelPlanDetail
                {
                    CustomerId=bookingViewModel.CustomerId,
                    TravelPlanId=bookingViewModel.TravelPlanId,
                    PurchasedSeat=bookingViewModel.PurchasedSeat
                });
                return StatusCode(201);
            }
            return BadRequest();
        }
    }
}
