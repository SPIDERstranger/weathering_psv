

using System;

namespace Weathering
{
    [Depend(typeof(DiscardableSolid))]
    public class SchoolEquipment { }


    [ConstructionCostBase(typeof(MachinePrimitive), 100)]
    public class WorkshopOfSchoolEquipment : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Workshop).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(SchoolEquipment), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(MachinePrimitive), 1);
    }
}
