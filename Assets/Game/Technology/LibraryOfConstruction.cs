﻿

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfConstruction : AbstractTechnologyCenter
    {
        protected override long TechnologyPointMaxRevenue => 100;
        protected override Type TechnologyPointType => typeof(ToolPrimitive);
        protected override long TechnologyPointMaxRevenueIncRequired => 1;

        protected override List<(Type, long)> TechList => new List<(Type, long)> {

            (typeof(ResidenceOfGrass), 0),
            (typeof(ResidenceOfWood), 200),
            (typeof(ResidenceOfStone), 500),
            (typeof(ResidenceOfBrick), 500),
        };
    }
}