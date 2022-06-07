

using System;

namespace Weathering
{
    // 金属矿
    [Depend(typeof(DiscardableSolid))]
    [Concept]
    public class MetalOre { }

    [ConstructionCostBase(typeof(WoodPlank), 100)]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [Concept]
    public class MountainMine : AbstractFactoryStatic
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(MountainMine).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(MetalOre), 1);
    }
}

