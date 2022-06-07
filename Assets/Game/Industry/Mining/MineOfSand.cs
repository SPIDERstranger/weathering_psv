

using System;

namespace Weathering
{
    // 沙子
    [Depend(typeof(DiscardableSolid))]
    [Concept]
    public class Sand { }

    [ConstructionCostBase(typeof(WoodPlank), 100)]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [Concept]
    public class MineOfSand : AbstractFactoryStatic, IPassable
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(MountainMine).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Clay), 3);

        public bool Passable => false;
    }
}
