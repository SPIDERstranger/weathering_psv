

using System;

namespace Weathering
{
    // 铁器
    [Depend(typeof(MetalProduct))]
    public class IronProduct { }


    [ConstructionCostBase(typeof(ToolPrimitive), 100)]
    public class WorkshopOfIronCasting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Workshop).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(IronProduct), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(IronIngot), 2);

        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Fuel), 1);
    }
}
