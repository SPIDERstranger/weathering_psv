

using System;

namespace Weathering
{
    public class Factory { }


    // 钢厂 混合
    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfSteelWorking : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;

        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 20);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(SteelIngot), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(IronIngot), 3);
    }
}
