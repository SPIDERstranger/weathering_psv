

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(StoneBrick), 100, 20)]
    public class ResidenceOfStone : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(ResidenceOfStone).Name;
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Food), 9);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 3);
    }
}
