

using System;

namespace Weathering
{
    // 铜器
    [Depend(typeof(MetalProduct))]
    public class CopperProduct { }


    [ConstructionCostBase(typeof(ToolPrimitive), 100)]
    public class WorkshopOfCopperCasting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(WorkshopOfMetalSmelting).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CopperProduct), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CopperIngot), 3);

        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Fuel), 1);
    }
}
