

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfLogistics : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;

        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(CombustionMotor);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(RoadForSolid), 0),
            new ValueTuple<Type, long>(typeof(RoadAsBridge), 0),
            new ValueTuple<Type, long>(typeof(RoadAsTunnel), 0),
            new ValueTuple<Type, long>(typeof(RoadForFluid), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(RoadOfConcrete), 1*BaseCost),

            new ValueTuple<Type, long>(typeof(TransportStationPort), 3*BaseCost),
            new ValueTuple<Type, long>(typeof(TransportStationDestPort), 3*BaseCost),

            new ValueTuple<Type, long>(typeof(RoadAsRailRoad), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(RoadLoaderOfRoadAsRailRoad), 5*BaseCost),

            new ValueTuple<Type, long>(typeof(TransportStationAirport), 7*BaseCost),
            new ValueTuple<Type, long>(typeof(TransportStationDestAirport), 7*BaseCost),
        };
    }
}
