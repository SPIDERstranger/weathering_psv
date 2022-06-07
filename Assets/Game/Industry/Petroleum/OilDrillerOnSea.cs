

using System;

namespace Weathering
{
    [BindTerrainType(typeof(TerrainType_Sea))]
    [ConstructionCostBase(typeof(LightMaterial), 100)]
    public class OilDrillerOnSea : AbstractFactoryStatic
    {
        public override string SpriteKey => "FactoryOfAirSeparator";

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 30);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CrudeOil), 3);
    }
}
