

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfLightOilCracking : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(FactoryOfLightOilCracking).Name;

        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 5);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(LiquefiedPetroleumGas), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(LightOil), 1);
    }
}
