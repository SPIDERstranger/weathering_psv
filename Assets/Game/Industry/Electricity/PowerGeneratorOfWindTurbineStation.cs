

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(WindTurbineComponent), 100)]
    public class PowerGeneratorOfWindTurbineStation : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(PowerPlant).Name;

        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 20);
    }
}
