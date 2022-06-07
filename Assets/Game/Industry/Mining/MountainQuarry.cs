
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{
    // 石材
    [Depend(typeof(DiscardableSolid))]
    [Concept]
    public class Stone { }

    [ConstructionCostBase(typeof(WoodPlank), 100, 20)]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [Concept]
    public class MountainQuarry : AbstractFactoryStatic
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(MountainQuarry).Name;
        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Stone), 1);
    }
}

