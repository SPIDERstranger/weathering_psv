

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(Grain), 10, 20)]
    public class ResidenceOfGrass : AbstractFactoryStatic, IPassable
    {
        public override string SpriteKey => typeof(ResidenceOfGrass).Name;

        public bool Passable => false;

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Food), 3);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
    }
}
