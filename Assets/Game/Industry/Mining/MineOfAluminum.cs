

using System;

namespace Weathering
{
    // 铝土 Bauxite
    [BindMine(typeof(MineOfCopper))]
    [Depend(typeof(DiscardableSolid))]
    public class AluminumOre : IMineralType { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    [CanBeBuildOnNotPassableTerrain]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [BindMineral(typeof(AluminumOre))]
    [Concept]
    public class MineOfAluminum : AbstractFactoryStatic, IPassable
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(MountainMine).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(AluminumOre), 3);

        public bool Passable => false;
    }
}
