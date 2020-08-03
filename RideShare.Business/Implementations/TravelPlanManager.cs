using System;
using System.Collections.Generic;
using RideShare.Business.Interfaces;
using RideShare.Data.Repository.Interfaces;
using RideShare.Data.Context;

namespace RideShare.Business.Implementations
{
    public class TravelPlanManager : ITravelPlanManager
    {
        ITravelPlanRepository _travelPlanRepository;
        public TravelPlanManager(ITravelPlanRepository travelPlanRepository)
        {
            _travelPlanRepository = travelPlanRepository;
        }
         
        public void Add(TravelPlan travelPlan)
        {
           _travelPlanRepository.Add(travelPlan);
        }

        public void Delete(int id)
        {
            var travelPlan = GetByID(id);
            if (travelPlan != null)
            {
                _travelPlanRepository.Delete(travelPlan);
            }
            else
              throw new Exception("There is no travel plan");
        }

        public TravelPlan GetByID(int id)
        {
            return id > 0 ? _travelPlanRepository.Get(x => x.Id == id) : new TravelPlan();
        }

        public List<TravelPlan> GetTravelPlanList(int? fromCityId,int? toCityId)
        {
            if (fromCityId is null || toCityId is null)
                throw new Exception("From or To city can not be nullable value");
            return _travelPlanRepository.GetList(t=>t.FromCityId==fromCityId && t.ToCityId==toCityId && t.IsPublished.HasValue && t.IsPublished.Value);
        }

        public void Update(TravelPlan travelPlan)
        {
            var _travelPlan = GetByID(travelPlan.Id);
            if (_travelPlan != null)
                _travelPlanRepository.Update(travelPlan);
            else
                throw new Exception("There is no travel plan");
        }

        public List<TravelPlan> AdvanceSearchForTravelPlans(int? fromCityId, int? toCityId)
        {
            if (fromCityId is null || toCityId is null)
                throw new Exception("From or To city can not be nullable value");
            return _travelPlanRepository.GetList(t => t.FromCityId >= fromCityId && t.ToCityId <= toCityId && t.IsPublished.HasValue && t.IsPublished.Value);
        }
    }
}
