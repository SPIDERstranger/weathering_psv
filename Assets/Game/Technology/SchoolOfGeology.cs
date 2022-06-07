

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfGeology : AbstractTechnologyCenter
    {
        public const long BaseCost = 6000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(Coal);
        protected override long TechnologyPointIncRequired => 5;

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(MineOfCoal), 0),
            new ValueTuple<Type, long>(typeof(MineOfAluminum), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(SeaWaterPump), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(OilDriller), 3*BaseCost),
        };
    }
}
