

using System;

namespace Weathering
{
    // 航空燃油
    [Depend(typeof(DiscardableFluid))]
    [Concept]
    public class JetFuel { }


    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfJetFuel : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(JetFuel), 2);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(LightOil), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(HeavyOil), 1);
    }
}
