

using System;

namespace Weathering
{
    // 高级电路板
    [Depend(typeof(DiscardableSolid))]
    public class CircuitBoardAdvanced { }

    [ConstructionCostBase(typeof(LightMaterial), 100)]
    public class FactoryOfCircuitBoardAdvanced : AbstractFactoryStatic
    {
        public override string SpriteKey =>typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 30);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CircuitBoardAdvanced), 1);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(CircuitBoardIntegrated), 2);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(LightMaterial), 1);
    }
}
