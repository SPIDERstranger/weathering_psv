

using System;

namespace Weathering
{
    [BindTerrainType(typeof(TerrainType_Forest))]
    [ConstructionCostBase(typeof(WoodPlank), 50, 10)]
    public class ResidenceOverTree : AbstractFactoryStatic
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(ResidenceOverTree).Name;
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Food), 6);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 2);
    }
}
