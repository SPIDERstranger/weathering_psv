

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class PowerGeneratorOfLiquefiedPetroleumGas : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(PowerPlant).Name;

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(LiquefiedPetroleumGas), 6);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 150);
    }
}
