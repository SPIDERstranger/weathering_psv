

using System;

namespace Weathering
{
    // 木材
    [Depend(typeof(DiscardableSolid))]
    public class MetalProduct { }


    [ConstructionCostBase(typeof(StoneBrick), 100)]
    public class WorkshopOfMetalCasting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(WorkshopOfMetalSmelting).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(MetalProduct), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(MetalIngot), 1);

        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Fuel), 1);
    }
}
