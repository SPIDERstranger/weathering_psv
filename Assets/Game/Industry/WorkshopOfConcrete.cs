

using System;

namespace Weathering
{

    // 水泥
    [Depend(typeof(DiscardableSolid))]
    public class ConcretePowder { }


    [ConstructionCostBase(typeof(MachinePrimitive), 100)]
    public class WorkshopOfConcrete : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(ConcretePowder), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(IronOre), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Stone), 1);
    }
}
