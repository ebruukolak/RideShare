using System;
using Microsoft.AspNetCore.Mvc;
using RideShare.Business.Interfaces;
using RideShare.Data.Context;

namespace RideShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlanController:ControllerBase
    {
        ITravelPlanManager _travelPlanManager;
        public TravelPlanController(ITravelPlanManager travelPlanManager)
        {
            _travelPlanManager = travelPlanManager;
        }

        [HttpPost]
        [Route("AddTravelPlan")]
        public ActionResult AddTravelPlan(TravelPlan travelPlan)
        {
            if (ModelState.IsValid)
            {
                _travelPlanManager.Add(travelPlan);
                return StatusCode(201);

            }
            return BadRequest();
        }

        [HttpPut]
        [Route("ChangePublishStatus")]
        public ActionResult ChangePublishStatus(int travelPlanId,bool isPublished)
        {
            if (ModelState.IsValid)
            {
                var travelPlan = _travelPlanManager.GetByID(travelPlanId);
                if (travelPlan != null)
                {
                    travelPlan.IsPublished = isPublished;
                    _travelPlanManager.Update(travelPlan);
                    return StatusCode(202);
                }

            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetTravelPlans/{fromCityId}/{toCityId}")]
        public ActionResult GetTravelPlans(int fromCityId,int toCityId)
        {
            var travelPlans = _travelPlanManager.GetTravelPlanList(fromCityId,toCityId);
            if (travelPlans.Count > 0)
            {
                return Ok(travelPlans);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("AdvanceSearchForTravelPlans/{fromCityId}/{toCityId}")]
        public ActionResult AdvanceSearchForTravelPlans(int fromCityId, int toCityId)
        {
            var travelPlans = _travelPlanManager.AdvanceSearchForTravelPlans(fromCityId, toCityId);
            if (travelPlans.Count > 0)
            {
                return Ok(travelPlans);
            }
            return BadRequest();
        }
    }
}
