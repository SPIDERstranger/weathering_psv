

using System;

namespace Weathering
{
    // 牛奶
    [Depend(typeof(Food))]
    public class Milk { }

    [ConstructionCostBase(typeof(Grain), 200, 20)]
    public class Pasture : AbstractFactoryStatic, IPassable
    {
        public bool Passable => true;

        public override string SpriteKey => typeof(Pasture).Name;

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Milk), 2);
    }
}
