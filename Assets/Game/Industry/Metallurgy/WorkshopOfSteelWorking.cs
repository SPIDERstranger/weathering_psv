

using System;

namespace Weathering
{

    // 钢锭
    [Depend(typeof(MetalIngot))]
    public class SteelIngot { }


    // 钢厂
    [ConstructionCostBase(typeof(MachinePrimitive), 100)]
    public class WorkshopOfSteelWorking : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Workshop).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 2);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(SteelIngot), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(IronIngot), 3);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Fuel), 5);

    }
}
