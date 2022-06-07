

using System;

namespace Weathering
{
    // 卫星组件
    [Depend(typeof(DiscardableSolid))]
    [Concept]
    public class SatelliteComponent { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfSatelliteComponent : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(FactoryOfSatelliteComponent).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 50);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(LightMaterial), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(CircuitBoardAdvanced), 1);
    }
}
