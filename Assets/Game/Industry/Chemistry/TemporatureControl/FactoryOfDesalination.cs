

using System;

namespace Weathering
{

    // 纯净水
    [Depend(typeof(DiscardableFluid))]
    public class Water { }


    public class FactoryOfDesalination : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(FactoryOfElectrolysis).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 2);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(SeaWater), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Water), 1);
    }
}
