

using System;

namespace Weathering
{
    // 轻质材料
    [Depend(typeof(DiscardableSolid))]
    [Concept]
    public class LightMaterial { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfLightMaterial : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 5);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(LightMaterial), 3);

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Plastic), 2);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(AluminiumIngot), 2);
    }
}
