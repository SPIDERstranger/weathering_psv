﻿

using System;

namespace Weathering
{


    [ConstructionCostBase(typeof(ConcretePowder), 1000, 30)]
    public class ResidenceOfTruth : AbstractFactoryStatic
    {
        public override string SpriteKey => DecoratedSpriteKey(typeof(ServiceOfTruth).Name);
        protected override (Type, long) In_0 => (typeof(Food), 30);
        protected override (Type, long) In_0_Inventory => (typeof(Truth), 15);
        protected override (Type, long) Out0_Inventory => (typeof(Worker), 15);
    }
}