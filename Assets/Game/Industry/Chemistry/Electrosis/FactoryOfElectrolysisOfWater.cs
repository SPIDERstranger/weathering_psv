

using System;

namespace Weathering
{
    // 氢气
    [Depend(typeof(DiscardableFluid))]
    public class Hydrogen { }

    public class FactoryOfElectrolysis { }

    public class FactoryOfElectrolysisOfWater : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(FactoryOfElectrolysis).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 30);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Water), 2);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Hydrogen), 2);
        protected override ValueTuple<Type, long> Out1 => new ValueTuple<Type, long>(typeof(Oxygen), 1);
    }
}
