

using System;

namespace Weathering
{
    // 铜导线
    [Depend(typeof(DiscardableSolid))]
    public class CopperWire { }

    public class FactoryOfConductorOfCopperWire : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CopperWire), 8);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CopperIngot), 1);
    }
}
