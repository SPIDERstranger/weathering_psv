﻿

using System;

namespace Weathering
{
    // 工具
    [Depend(typeof(DiscardableSolid))]
    public class ToolPrimitive { }


    [ConstructionCostBase(typeof(WoodPlank), 100)]
    public class WorkshopOfToolPrimitive : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(WorkshopOfWoodcutting).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(ToolPrimitive), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(WoodPlank), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(StoneBrick), 1);
    }
}
