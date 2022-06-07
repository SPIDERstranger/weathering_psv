

using System;

namespace Weathering
{

    // 氧气
    [Depend(typeof(DiscardableFluid))]
    public class Oxygen { }

    // 氮气
    [Depend(typeof(DiscardableFluid))]
    public class Nitrogen { }


    public class FactoryAsAirSeparator : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Nitrogen), 3);
        protected override ValueTuple<Type, long> Out1 => new ValueTuple<Type, long>(typeof(Oxygen), 1);
    }
}
