

using System;

namespace Weathering
{
    /// <summary>
    /// 电动机
    /// </summary>
    [Depend(typeof(DiscardableSolid))]
    public class ElectroMotor { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfElectroMotor : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 2);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(ElectroMotor), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(SteelPipe), 4);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(CopperWire), 32);
    }
}
