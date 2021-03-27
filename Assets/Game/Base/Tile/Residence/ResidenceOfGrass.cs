﻿

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(Food), 30)]
    public class ResidenceOfGrass : AbstractFactoryStatic, IPassable
    {
        public override string SpriteKey => DecoratedSpriteKey(typeof(ResidenceOfGrass).Name);

        public bool Passable => false;

        protected override (Type, long) In_0 => (typeof(FoodSupply), 4);
        protected override (Type, long) Out0_Inventory => (typeof(Worker), 1);
    }
}
