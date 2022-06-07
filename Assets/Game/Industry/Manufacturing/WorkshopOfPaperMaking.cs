

using System;

namespace Weathering
{
    [Depend(typeof(DiscardableSolid))]
    public class Paper { }


    [ConstructionCostBase(typeof(Wood), 100)]
    public class WorkshopOfPaperMaking : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(WorkshopOfWoodcutting).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(Paper), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Wood), 1);
    }

}
