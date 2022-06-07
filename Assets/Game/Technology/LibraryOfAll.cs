

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfAll : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;
        protected override Type TechnologyPointType => typeof(Book);
        protected override long TechnologyPointIncRequired => 1;
        protected override long TechnologyPointMaxRevenue => BaseCost;

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>  (typeof(LibraryOfAll), 0),

            new ValueTuple<Type, long> (typeof(LibraryOfAgriculture), 1*BaseCost),
            new ValueTuple<Type, long> (typeof(LibraryOfHandcraft),  2*BaseCost),
            new ValueTuple<Type, long> (typeof(LibraryOfGeography),  3*BaseCost),
            new ValueTuple<Type, long> (typeof(LibraryOfLogistics),  5*BaseCost),
            new ValueTuple<Type, long> (typeof(LibraryOfEconomy),  5*BaseCost),
            new ValueTuple<Type, long> (typeof(LibraryOfConstruction),  5*BaseCost),
            new ValueTuple<Type, long> (typeof(LibraryOfMetalWorking),  10*BaseCost),

            new ValueTuple<Type, long> (typeof(SchoolOfAll), 10*BaseCost)
        };
    }
}
