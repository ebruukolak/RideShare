using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RideShare.Data.Context;
using RideShare.Data.Repository.Interfaces;

namespace RideShare.Data.Repository.Implementations
{
    public class TravelPlanRepository : RepositoryAccess<TravelPlan, RideShareContext>, ITravelPlanRepository
    {
        
    }

}
