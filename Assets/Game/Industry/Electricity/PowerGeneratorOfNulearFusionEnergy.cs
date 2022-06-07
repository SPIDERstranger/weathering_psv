

using System;

namespace Weathering
{

    // 氘
    [Depend(typeof(DiscardableSolid))]
    public class Deuterium { }


    // 氚
    [Depend(typeof(DiscardableSolid))]
    public class Tritium { }



    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class PowerGeneratorOfNulearFusionEnergy : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(PowerPlant).Name;

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Deuterium), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(Tritium), 1);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 500);
    }
}
