

using System;

namespace Weathering
{

    // 铀235
    [Depend(typeof(DiscardableSolid))]
    public class Uranrium235 { }


    // 铀238
    [Depend(typeof(DiscardableSolid))]
    public class Uranrium238 { }




    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class PowerGeneratorOfNulearFissionEnergy : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(PowerPlant).Name;

        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Uranrium235), 1);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 300);
    }
}
