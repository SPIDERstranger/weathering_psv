

using System;
using System.Collections.Generic;

namespace Weathering
{
    // 金币
    [Depend(typeof(DiscardableSolid))]
    public class GoldCoin { }

    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfEconomy : AbstractTechnologyCenter
    {
        public const long BaseCost = 100;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(GoldOre);
        protected override long TechnologyPointIncRequired => 1;

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            // (typeof(MarketForPlayer), BaseCost),
            new ValueTuple<Type, long> (typeof(CellarForPersonalStorage), 0),
            new ValueTuple<Type, long> (typeof(RecycleStation), 0),
            new ValueTuple<Type, long> (typeof(MarketOfAgriculture), 1*BaseCost),
            new ValueTuple<Type, long> (typeof(MarketOfMineral), 2*BaseCost),
            new ValueTuple<Type, long> (typeof(MarketOfHandcraft), 2*BaseCost),
            new ValueTuple<Type, long> (typeof(MarketOfMetalProduct), 3* BaseCost),
        };
    }
}
