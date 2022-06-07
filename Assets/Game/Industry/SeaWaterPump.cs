

using System;

namespace Weathering
{
    // 海水
    [Depend(typeof(DiscardableFluid))]
    [Concept]
    public class SeaWater { }

    [ConstructionCostBase(typeof(MachinePrimitive), 100)]
    [BindTerrainType(typeof(TerrainType_Sea))]
    [Concept]
    public class SeaWaterPump : AbstractFactoryStatic, IPassable
    {
        public bool Passable => false;

        protected override bool PreserveLandscape => true;
        public override string SpriteKey => "FactoryOfAirSeparator";

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 3);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(SeaWater), 3);
    }
}
