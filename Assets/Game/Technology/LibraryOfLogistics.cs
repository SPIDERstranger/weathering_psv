

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfLogistics : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(WheelPrimitive);
        protected override long TechnologyPointIncRequired => 1;

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type,long>(typeof(RoadForSolid), 0),
            new ValueTuple<Type,long>(typeof(RoadOfStone), 0),
            new ValueTuple<Type,long>(typeof(RoadAsBridge), 1*BaseCost),
            new ValueTuple<Type,long>(typeof(RoadAsTunnel), 1*BaseCost),

            new ValueTuple<Type,long>(typeof(TransportStationSimpliest), 1*BaseCost),
            new ValueTuple<Type,long>(typeof(TransportStationDestSimpliest), 1*BaseCost),

            new ValueTuple<Type,long>(typeof(RoadAsCanal), 3*BaseCost),
            new ValueTuple<Type,long>(typeof(RoadLoaderOfRoadAsCanal), 3*BaseCost),
        };
    }
}
