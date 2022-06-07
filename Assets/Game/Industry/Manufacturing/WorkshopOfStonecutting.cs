

using System;

namespace Weathering
{
    // 石砖
    [Depend(typeof(DiscardableSolid))]
    public class StoneBrick { }


    [ConstructionCostBase(typeof(WoodPlank), 100)]
    public class WorkshopOfStonecutting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(WorkshopOfWoodcutting).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(StoneBrick), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Stone), 3);
    }
}
