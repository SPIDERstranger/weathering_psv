

using System;

namespace Weathering
{
    [BindTerrainType(typeof(TerrainType_Sea))]
    [ConstructionCostBase(typeof(WoodPlank), 100, 20)]
    public class ResidenceCoastal : AbstractFactoryStatic
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(ResidenceCoastal).Name;
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Food), 6);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 2);
    }
}
