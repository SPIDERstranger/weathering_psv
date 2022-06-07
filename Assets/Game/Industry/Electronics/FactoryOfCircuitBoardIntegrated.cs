

using System;

namespace Weathering
{
    // 集成电路板
    [Depend(typeof(DiscardableSolid))]
    public class CircuitBoardIntegrated { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfCircuitBoardIntegrated : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 20);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CircuitBoardIntegrated), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CircuitBoardSimple), 2);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Plastic), 1);
    }
}
