

using System;

namespace Weathering
{

    // 铁锭
    [Depend(typeof(MetalIngot))]
    public class IronIngot { }



    [ConstructionCostBase(typeof(ToolPrimitive), 100)]
    public class WorkshopOfIronSmelting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(WorkshopOfMetalSmelting).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(IronIngot), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(IronOre), 2);

        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Fuel), 2);
    }
}
