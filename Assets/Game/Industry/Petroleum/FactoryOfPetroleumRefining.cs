

using System;

namespace Weathering
{
    // 重油
    [Depend(typeof(DiscardableFluid))]
    [Concept]
    public class HeavyOil { }

    // 轻油
    [Depend(typeof(DiscardableFluid))]
    [Concept]
    public class LightOil { }

    // 石油气
    [Depend(typeof(DiscardableFluid))]
    [Concept]
    public class LiquefiedPetroleumGas { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfPetroleumRefining : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(FactoryOfPetroleumRefining).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(LiquefiedPetroleumGas), 1);
        protected override ValueTuple<Type, long> Out1 => new ValueTuple<Type, long>(typeof(LightOil), 1);
        protected override ValueTuple<Type, long> Out2 => new ValueTuple<Type, long>(typeof(HeavyOil), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CrudeOil), 3);
    }
}
