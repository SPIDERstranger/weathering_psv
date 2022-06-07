

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfConstruction : AbstractTechnologyCenter
    {
        public const long BaseCost = 100;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(ToolPrimitive);
        protected override long TechnologyPointIncRequired => 1;

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long> (typeof(ResidenceOfGrass), 0),
            new ValueTuple<Type, long> (typeof(WareHouseOfGrass), 0),

            new ValueTuple<Type, long>(typeof(ResidenceOfWood), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(WareHouseOfWood), 1*BaseCost),

            new ValueTuple<Type, long> (typeof(ResidenceCoastal), 1*BaseCost),
            new ValueTuple<Type, long> (typeof(ResidenceOverTree), 1*BaseCost),

            new ValueTuple<Type, long> (typeof(ResidenceOfStone), 2*BaseCost),
            new ValueTuple<Type, long> (typeof(WareHouseOfStone), 2*BaseCost),

            new ValueTuple<Type, long>  (typeof(ResidenceOfBrick), 3*BaseCost),
            new ValueTuple<Type, long>  (typeof(WareHouseOfBrick), 3*BaseCost),

            // (typeof(ResidenceOfConcrete), 5*BaseCost),
        };
    }
}
