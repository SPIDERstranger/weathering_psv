

using System;

namespace Weathering
{
    // 燃料
    [Depend(typeof(DiscardableSolid))]
    public class Fuel { }


    // 煤矿
    [BindMine(typeof(MineOfCoal))]
    [Depend(typeof(Fuel))]
    public class Coal { }


    [ConstructionCostBase(typeof(MachinePrimitive), 100, 20)]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [CanBeBuildOnNotPassableTerrain]
    [BindMineral(typeof(Coal))]
    [Concept]
    public class MineOfCoal : AbstractFactoryStatic, IPassable
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(MountainMine).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Coal), 5);

        public bool Passable => false;
    }
}
