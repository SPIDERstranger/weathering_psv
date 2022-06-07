

using System;

namespace Weathering
{
    // 轮子
    [Depend(typeof(DiscardableSolid))]
    public class WheelPrimitive { }


    [ConstructionCostBase(typeof(ToolPrimitive), 100)]
    public class WorkshopOfWheelPrimitive : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Workshop).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(WheelPrimitive), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(WoodPlank), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(StoneBrick), 1);
    }
}
