﻿
using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(ConcretePowder), 30, 0)]
    public class RoadOfConcrete : AbstractRoad
    {
        public override float WalkingTimeModifier => 0.4f;

        private const string RoadBase = "RoadOfConcrete";
        protected override string SpriteKeyRoadBase => RoadBase;
        public override long RoadQuantityRestriction => 50;
        public override Type LinkTypeRestriction => typeof(DiscardableSolid);
    }
}

