

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfPhysics : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(SchoolEquipment);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(SeaWaterPump), 0),
            new ValueTuple<Type, long>(typeof(PowerGeneratorOfWood), 0),
            new ValueTuple<Type, long>(typeof(PowerGeneratorOfCoal), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(PowerGeneratorOfLiquefiedPetroleumGas), 2*BaseCost),
            new ValueTuple<Type, long>(typeof(PowerGeneratorOfWindTurbineStation), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(PowerGeneratorOfSolarPanelStation), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(PowerGeneratorOfNulearFissionEnergy), 8*BaseCost),
            new ValueTuple<Type, long>(typeof(PowerGeneratorOfNulearFusionEnergy), 8*BaseCost),
        };
    }
}
