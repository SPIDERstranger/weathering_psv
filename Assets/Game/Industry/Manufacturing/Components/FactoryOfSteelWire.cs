

using System;

namespace Weathering
{
    [Depend(typeof(DiscardableSolid))]
    public class SteelWire { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfSteelWire : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 2);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(SteelWire), 8);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(SteelIngot), 1);
    }
}
