

using System;

namespace Weathering
{
    [ConstructionCostBase(typeof(ConcretePowder), 100, 30)]
    public class ResidenceOfConcrete : AbstractFactoryStatic
    {
        public override string SpriteKey => typeof(ResidenceOfConcrete).Name;
        protected override ValueTuple<Type, long> In_0 => new ValueTuple<Type, long>(typeof(Food), 18);
        protected override ValueTuple<Type, long> Out0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 6);
    }
}
