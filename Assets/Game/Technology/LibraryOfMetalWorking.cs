

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfMetalWorking : AbstractTechnologyCenter
    {
        public const long BaseCost = 600;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(CopperOre);
        protected override long TechnologyPointIncRequired => 1;

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

           new ValueTuple<Type, long> (typeof(RoadAsTunnel), 0*BaseCost),
           new ValueTuple<Type, long> (typeof(WorkshopOfCopperSmelting), 1*BaseCost),
           new ValueTuple<Type, long> (typeof(WorkshopOfCopperCasting), 2*BaseCost),

           new ValueTuple<Type, long> (typeof(WorkshopOfIronSmelting), 2*BaseCost),
           new ValueTuple<Type, long> (typeof(WorkshopOfIronCasting), 3*BaseCost),
        };
    }
}
