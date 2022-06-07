

using System;

namespace Weathering
{
    /// <summary>
    /// 内燃机
    /// </summary>
    [Depend(typeof(DiscardableSolid))]
    public class CombustionMotor { }

    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfCombustionMotor : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 2);

        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(CombustionMotor), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(SteelPipe), 4);
        protected override ValueTuple<Type, long> In_1 => new ValueTuple<Type, long>(typeof(SteelRod), 8);
    }
}
