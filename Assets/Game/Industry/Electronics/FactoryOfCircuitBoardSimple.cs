

using System;

namespace Weathering
{
    // 简单电路板
    [Depend(typeof(DiscardableSolid))]
    public class CircuitBoardSimple { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfCircuitBoardSimple : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CircuitBoardSimple), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CopperWire), 2);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(WoodPlank), 1);
    }
}
