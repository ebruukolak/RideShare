using System;
using System.Collections.Generic;
using RideShare.Data.Context;

namespace RideShare.Business.Interfaces
{
    public interface ITravelPlanDetailManager
    {

        TravelPlanDetail GetByID(int id);
        List<TravelPlanDetail> GetTravelPlanDetailList();
        void Add(TravelPlanDetail travelPlanDetail);
        void Update(TravelPlanDetail travelPlanDetail);
        void Delete(int id);
    }
}
