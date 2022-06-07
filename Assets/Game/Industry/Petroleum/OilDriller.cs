

using System;

namespace Weathering
{
    // 石油, 液体
    [Depend(typeof(DiscardableFluid))]
    [Concept]
    public class CrudeOil { }


    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class OilDriller : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(OilDriller).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CrudeOil), 2);
    }
}
