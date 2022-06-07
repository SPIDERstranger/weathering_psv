

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(Brick), 100, 20)]
    public class ResidenceOfBrick : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(ResidenceOfBrick).Name;
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Food), 12);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 4);
    }
}
