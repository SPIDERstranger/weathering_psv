

using System;

namespace Weathering
{
    // 浆果
    [Depend(typeof(Fruit))]
    public class Berry { }



    [ConstructionCostBase(typeof(Berry), 10)]
    public class BerryBush : AbstractFactoryStatic, IPassable
    {
        protected override bool CanStoreSomething => true;
        protected override bool CanStoreOut0 => true;

        public override string SpriteKey => typeof(BerryBush).Name;

        public bool Passable => true;

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Berry), 1);
    }
}
