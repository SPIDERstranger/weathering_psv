

using System;

namespace Weathering
{
    // 鸡蛋
    [Depend(typeof(Food))]
    public class Egg { }

    [ConstructionCostBase(typeof(WoodPlank), 100, 20)]
    public class Hennery : AbstractFactoryStatic, IPassable
    {
        public bool Passable => false;

        public override string SpriteKey => typeof(Hennery).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Grain), 6);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Egg), 18);
    }
}
