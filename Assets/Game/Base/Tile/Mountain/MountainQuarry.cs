﻿
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{
    // 石材
    [ConceptSupply(typeof(StoneSupply))]
    [ConceptDescription(typeof(StoneDescription))]
    [Depend(typeof(DiscardableSolid))]
    [Concept]
    public class Stone { }
    [ConceptResource(typeof(Stone))]
    [Depend(typeof(TransportableSolid))]
    [Concept]
    public class StoneSupply { }
    [Concept]
    public class StoneDescription { }

    [ConstructionCostBase(typeof(WoodPlank), 100, 20)]
    [BindTerrainType(typeof(TerrainType_Mountain))]
    [Concept]
    public class MountainQuarry : AbstractFactoryStatic
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => DecoratedSpriteKey(typeof(MountainQuarry).Name);
        protected override (Type, long) In_0_Inventory => (typeof(Worker), 1);
        protected override (Type, long) Out0 => (typeof(StoneSupply), 1);
    }
}

