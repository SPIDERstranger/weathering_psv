

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(MachinePrimitive), 100)]
    public class PowerGeneratorOfWood : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(PowerPlant).Name;

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Fuel), 5);

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);
    }
}
