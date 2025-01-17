﻿

using System;

namespace Weathering
{
    // 金矿石
    [BindMine(typeof(MineOfGold))]
    [Depend(typeof(DiscardableSolid))]
    [Concept]
    public class GoldOre : IMineralType { }

    [ConstructionCostBase(typeof(WoodPlank), 100)]
    [CanBeBuildOnNotPassableTerrain]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [BindMineral(typeof(GoldOre))]
    [Concept]
    public class MineOfGold : AbstractFactoryStatic, IPassable
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(MountainMine).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(GoldOre), 1);

        public bool Passable => false;
    }
}
