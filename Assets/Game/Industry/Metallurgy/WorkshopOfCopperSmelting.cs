

using System;

namespace Weathering
{

    // 铜锭
    [Depend(typeof(MetalIngot))]
    public class CopperIngot { }


    [ConstructionCostBase(typeof(ToolPrimitive), 100)]
    public class WorkshopOfCopperSmelting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(WorkshopOfMetalSmelting).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CopperIngot), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CopperOre), 2);

        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Fuel), 2);
    }
}
