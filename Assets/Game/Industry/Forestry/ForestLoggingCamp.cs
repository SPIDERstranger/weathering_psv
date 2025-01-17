﻿
using System;
using System.Collections.Generic;

namespace Weathering
{
    // 木材
    [Depend(typeof(Fuel))]
    public class Wood { }

    [ConstructionCostBase(typeof(Wood), 10, 20)]
    [BindTerrainType(typeof(TerrainType_Forest))]
    [Concept]
    class ForestLoggingCamp : AbstractFactoryStatic, IPassable
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(ForestLoggingCamp).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Wood), 1);

        public bool Passable => false;
    }
}

