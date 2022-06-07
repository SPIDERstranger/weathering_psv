

using System;

namespace Weathering
{

    // 氯气
    [Depend(typeof(DiscardableFluid))]
    public class Chlorine { }



    // 氢氧化钠
    [Depend(typeof(DiscardableFluid))]
    public class SodiumHydroxide { }


    public class FactoryOfElectrolysisOfSaltedWater : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(FactoryOfElectrolysis).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 30);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(SeaWater), 2);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Hydrogen), 1);
        protected override ValueTuple<Type, long> Out1 => new ValueTuple<Type, long>(typeof(Chlorine), 1);
        protected override ValueTuple<Type, long> Out2 => new ValueTuple<Type, long>(typeof(SodiumHydroxide), 1);
    }
}
