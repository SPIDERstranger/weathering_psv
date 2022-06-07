

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfAll : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(SchoolEquipment);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(LibraryOfAll), 0),
            new ValueTuple<Type, long>(typeof(SchoolOfAll), 0),

            new ValueTuple<Type, long>(typeof(SchoolOfGeology), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(SchoolOfEngineering), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(SchoolOfLogistics), 2*BaseCost),
            new ValueTuple<Type, long>(typeof(SchoolOfPhysics), 3*BaseCost),
            new ValueTuple<Type, long>(typeof(SchoolOfChemistry), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(SchoolOfElectronics), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(SchoolOfSpace), 6*BaseCost),
        };
    }
}
