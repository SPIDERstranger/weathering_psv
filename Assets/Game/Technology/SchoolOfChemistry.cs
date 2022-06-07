

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfChemistry : AbstractTechnologyCenter
    {
        public const long BaseCost = 3000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(LiquefiedPetroleumGas);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(FactoryOfDesalination), 0*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfPetroleumRefining), 0),
            new ValueTuple<Type, long>(typeof(FactoryOfLightOilCracking), BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfHeavyOilCracking), 2*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfPlastic), 3*BaseCost),

            new ValueTuple<Type, long>(typeof(FactoryOfJetFuel), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfFuelPack_Oxygen_Hydrogen), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfFuelPack_Oxygen_JetFuel), 5*BaseCost),

            new ValueTuple<Type, long>(typeof(FactoryAsAirSeparator), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfElectrolysisOfSaltedWater), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfElectrolysisOfWater), 5*BaseCost),
        };
    }
}
