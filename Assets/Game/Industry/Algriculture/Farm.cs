
using System;
using System.Collections.Generic;

namespace Weathering
{
    // 谷物
    [Depend(typeof(Food))]
    public class Grain { }


    [ConstructionCostBase(typeof(Grain), 10, 20)]
    [Concept]
    public class Farm : AbstractFactoryStatic, IPassable
    {
        protected override bool CanStoreSomething => true;
        protected override bool CanStoreOut0 => true;

        public bool Passable => true;

        public override string SpriteKeyRoad {
            get {
                int index = TileUtility.Calculate4x4RuleTileIndex(this, (tile, direction) => { 
                    if (tile is Farm && tile is IRunnable ) {
                        IRunnable runnable = tile as IRunnable;
                        return Running == runnable.Running;
                    }
                    return false;
                }
                );
                return $"{(Running ? "Farm" : "FarmGrowing")}_{index}";
            }
        }
        public override string SpriteKey => null;
        public override string SpriteKeyHighLight => null;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Grain), 6);
    }
}

