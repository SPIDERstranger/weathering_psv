

using System;

namespace Weathering
{
    // 铜矿
    [BindMine(typeof(MineOfCopper))]
    [Depend(typeof(MetalOre))]
    [Concept]
    public class CopperOre : IMineralType { }


    [ConstructionCostBase(typeof(WoodPlank), 100)]
    [CanBeBuildOnNotPassableTerrain]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [BindMineral(typeof(CopperOre))]
    [Concept]
    public class MineOfCopper : AbstractFactoryStatic, IPassable
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(MountainMine).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CopperOre), 1);

        public bool Passable => false;
    }
}
