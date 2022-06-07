

using System;

namespace Weathering
{
    // 铜导线
    [Depend(typeof(DiscardableSolid))]
    public class Turbine { }

    public class FactoryOfTurbine : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 5);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(SteelPipe), 4);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(SteelPlate), 2);
    }
}
