

using System;
using System.Collections.Generic;

namespace Weathering
{

    public class KnowledgeOfPlanetLander { }

    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfSpace : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(CircuitBoardAdvanced);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(KnowledgeOfPlanetLander), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(LaunchSite), 2*BaseCost),
            new ValueTuple<Type, long>(typeof(SpaceElevator), 3*BaseCost),
        };
    }
}
