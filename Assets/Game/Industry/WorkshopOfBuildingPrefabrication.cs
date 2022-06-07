

using System;

namespace Weathering
{

    // 预制体
    [Depend(typeof(DiscardableSolid))]
    public class BuildingPrefabrication { }


    [ConstructionCostBase(typeof(MachinePrimitive), 100)]
    public class WorkshopOfBuildingPrefabrication : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(BuildingPrefabrication), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(SteelIngot), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(ConcretePowder), 2);
    }
}
