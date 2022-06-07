

using System;

namespace Weathering
{
    // 红砖
    [Depend(typeof(DiscardableSolid))]
    public class Brick { }


    [ConstructionCostBase(typeof(ToolPrimitive), 100)]
    public class WorkshopOfBrickMaking : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Workshop).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Brick), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Clay), 3);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Fuel), 2);
        // protected override ValueTuple<Type, long> In_2 => new ValueTuple<Type, long>(typeof(StoneSupply), 1);
    }
}
