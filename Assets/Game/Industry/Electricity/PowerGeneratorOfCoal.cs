

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class PowerGeneratorOfCoal : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(PowerPlant).Name;

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Coal), 20);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Water), 3);
        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 80);
    }
}
