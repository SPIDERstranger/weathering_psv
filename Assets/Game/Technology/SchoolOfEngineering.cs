

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(SchoolEquipment), 100, 10)]
    public class SchoolOfEngineering : AbstractTechnologyCenter
    {
        public const long BaseCost = 1000;

        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override Type TechnologyPointType => typeof(SteelIngot);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            new ValueTuple<Type, long>(typeof(WorkshopOfSteelWorking), 0),
            new ValueTuple<Type, long>(typeof(WorkshopOfConcrete), 1*BaseCost),
            new ValueTuple<Type, long>(typeof(WorkshopOfBuildingPrefabrication),  2*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfSteelWorking), 2*BaseCost),

            new ValueTuple<Type, long>(typeof(FactoryOfAluminiumWorking),  3*BaseCost),

            new ValueTuple<Type, long>(typeof(FactoryOfLightMaterial), 3*BaseCost),

            // 钢

            new ValueTuple<Type, long>(typeof(FactoryOfSteelPlate), 3*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfSteelPipe), 3*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfSteelRod), 3*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfSteelWire), 3*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfSteelGear), 3*BaseCost),

            // 内燃机
            new ValueTuple<Type, long>(typeof(FactoryOfCombustionMotor), 5*BaseCost),

            // 电动机
            new ValueTuple<Type, long>(typeof(FactoryOfElectroMotor), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfWindTurbineComponent), 5*BaseCost),
            new ValueTuple<Type, long>(typeof(FactoryOfSolarPanelComponent), 5*BaseCost),

            // 涡轮机
            new ValueTuple<Type, long>(typeof(FactoryOfTurbine), 5*BaseCost),
        };
    }
}
