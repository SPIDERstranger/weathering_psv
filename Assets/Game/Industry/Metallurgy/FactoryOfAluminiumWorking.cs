﻿

using System;

namespace Weathering
{

    // 铝锭
    [Depend(typeof(MetalIngot))]
    public class AluminiumIngot { }


    [ConstructionCostBase(typeof(BuildingPrefabrication), 100)]
    public class FactoryOfAluminiumWorking : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(Factory).Name;


        protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);
        protected override ValueTuple<Type, long> In_1_Inventory => new ValueTuple<Type, long>(typeof(Electricity), 10);
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(AluminiumIngot), 1);
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(AluminumOre), 1);
    }
}
