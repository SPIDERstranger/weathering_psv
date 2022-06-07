

using System;

namespace Weathering
{
    // 木板
    [Depend(typeof(DiscardableSolid))]
    public class WoodPlank { }


    public class Workshop { }


    [ConstructionCostBase(typeof(Wood), 100)]
    public class WorkshopOfWoodcutting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Workshop).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(WoodPlank), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Wood), 2);
    }
}
