using System;
using System.Collections.Generic;
using RideShare.Business.Interfaces;
using RideShare.Data.Repository.Interfaces;
using RideShare.Data.Context;

namespace RideShare.Business.Implementations
{
    public class TravelPlanDetailManager : ITravelPlanDetailManager
    {
         ITravelPlanDetailRepository _travelPlanDetailRepository;
         ITravelPlanRepository _travelPlanRepository;

        public TravelPlanDetailManager(ITravelPlanDetailRepository travelPlanDetailRepository,ITravelPlanRepository travelPlanRepository)
        {
            _travelPlanDetailRepository = travelPlanDetailRepository;
            _travelPlanRepository = travelPlanRepository;
        }

        public void Add(TravelPlanDetail travelPlanDetail)
        {
            if (travelPlanDetail != null)
            {
                var travelPlan = GetTravelPlan(travelPlanDetail.TravelPlanId);
                if (travelPlan != null && travelPlan.AvailableSeatCount>travelPlanDetail.PurchasedSeat)
                {
                  _travelPlanDetailRepository.Add(travelPlanDetail);

                    travelPlan.AvailableSeatCount-=travelPlanDetail.PurchasedSeat;
                    _travelPlanRepository.Update(travelPlan);
                }
                else
                   throw new Exception("There is no available seat");
            }
            else
                throw new Exception("You should choose travel plan");
        }

        public void Delete(int id)
        {
            var travelPlanDetail = GetByID(id);
            if (travelPlanDetail != null)
            {
                _travelPlanDetailRepository.Delete(travelPlanDetail);
            }
            else
                throw new Exception("There is no travel plan detail");
        }

        public TravelPlanDetail GetByID(int id)
        {
             return  id > 0 ? _travelPlanDetailRepository.Get(x => x.Id == id) : new TravelPlanDetail();
        }

        public List<TravelPlanDetail> GetTravelPlanDetailList()
        {
            return _travelPlanDetailRepository.GetList();
        }

        public void Update(TravelPlanDetail travelPlanDetail)
        {
            var _travelPlanDetail = GetByID(travelPlanDetail.Id);
            if (_travelPlanDetail != null)
                _travelPlanDetailRepository.Update(travelPlanDetail);
            else
                throw new Exception("There is no travel plan detail");
        }

        public TravelPlan GetTravelPlan(int id)
        {
            return id > 0 ? _travelPlanRepository.Get(x => x.Id == id) : new TravelPlan();
        }
    }
}
