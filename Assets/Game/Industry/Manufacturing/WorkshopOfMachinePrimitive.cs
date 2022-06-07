

using System;

namespace Weathering
{
    [Depend(typeof(DiscardableSolid))]
    public class MachinePrimitive { }


    [ConstructionCostBase(typeof(ToolPrimitive), 100)]
    public class WorkshopOfMachinePrimitive : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Workshop).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 3);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(MachinePrimitive), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(IronProduct), 2);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(CopperProduct), 1);
    }
}
