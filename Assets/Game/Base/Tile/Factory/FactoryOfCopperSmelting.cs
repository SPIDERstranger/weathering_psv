﻿

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(CopperProduct), 100)]
    public class FactoryOfCopperSmelting : AbstractFactoryStatic
    {
        public override string SpriteKey => DecoratedSpriteKey(typeof(FactoryOfMetalSmelting).Name);

        protected override (Type, long) In_0_Inventory => (typeof(Worker), 1);
        protected override (Type, long) In_1_Inventory => (typeof(ElectricitySupply), 1);

        protected override (Type, long) Out0 => (typeof(CopperIngotSupply), 3);

        protected override (Type, long) In_0 => (typeof(CopperOreSupply), 5);

    }
}
