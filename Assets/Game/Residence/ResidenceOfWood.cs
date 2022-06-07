

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(WoodPlank), 50, 20)]
    public class ResidenceOfWood : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(ResidenceOfWood).Name;
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Food), 6);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 2);
    }
}
