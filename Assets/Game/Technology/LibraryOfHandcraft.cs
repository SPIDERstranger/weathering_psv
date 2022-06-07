

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfHandcraft : AbstractTechnologyCenter
    {
        private const long BaseCost = 1000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override long TechnologyPointIncRequired => 1;
        protected override Type TechnologyPointType => typeof(WoodPlank);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(WorkshopOfWoodcutting), 0),
            new ValueTuple<Type, long>(typeof(WorkshopOfStonecutting), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(WorkshopOfBrickMaking), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(WorkshopOfToolPrimitive), 3*BaseCost),
            new ValueTuple<Type, long>(typeof(WorkshopOfWheelPrimitive), 3*BaseCost),

            new ValueTuple<Type, long>(typeof(WorkshopOfMachinePrimitive), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(WorkshopOfSchoolEquipment), 5*BaseCost),
        };
    }
}
