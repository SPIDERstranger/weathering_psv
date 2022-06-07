

using System;

namespace Weathering
{
    // 燃料
    [Depend(typeof(Discardable))]
    public class Electricity { }


    [ConstructionCostBase(typeof(BuildingPrefabrication), 300)]
    public class PowerPlant : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(PowerPlant).Name;

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Fuel), 3);

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 100);
    }
}
