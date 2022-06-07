

using System;

namespace Weathering
{
    [Depend(typeof(DiscardableSolid))]
    public class WindTurbineComponent { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfWindTurbineComponent : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 2);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(WindTurbineComponent), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(AluminiumIngot), 1);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(ElectroMotor), 1);
    }
}
