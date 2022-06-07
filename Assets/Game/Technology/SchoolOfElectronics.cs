

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfElectronics : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;

        protected override long TechnologyPointIncRequired => 8;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(CircuitBoardSimple);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(FactoryOfConductorOfCopperWire), 0),
            new ValueTuple<Type, long>(typeof(FactoryOfCircuitBoardSimple), 0),
            new ValueTuple<Type, long>(typeof(FactoryOfCircuitBoardIntegrated), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfCircuitBoardAdvanced), 2*BaseCost),
        };
    }
}
