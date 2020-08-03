using System;
using System.Collections.Generic;
using RideShare.Data.Context;

namespace RideShare.Business.Interfaces
{
    public interface ITravelPlanManager
    {
        TravelPlan GetByID(int id);
        List<TravelPlan> GetTravelPlanList(int? fromCityId,int? toCityId);
        void Add(TravelPlan travelPlan);
        void Update(TravelPlan travelPlan);
        void Delete(int id);
        List<TravelPlan> AdvanceSearchForTravelPlans(int? fromCityId, int? toCityId);
        
    }
}
