

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfCopperSmelting : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CopperIngot), 3);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CopperOre), 5);

    }
}
