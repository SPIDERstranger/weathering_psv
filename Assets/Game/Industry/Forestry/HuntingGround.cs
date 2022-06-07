
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{

    // 兽肉
    [Depend(typeof(AnimalFlesh))]
    public class Meat { }

    // 鹿肉
    [Depend(typeof(Meat))]
    public class DeerMeat { }

    // 兔肉
    [Depend(typeof(Meat))]
    public class RabbitMeat { }


    /// <summary>
    /// 猎场
    /// </summary>
    [ConstructionCostBase(typeof(Wood), 10)]
    [BindTerrainType(typeof(TerrainType_Forest))]
    [Concept]
    public class HuntingGround : AbstractFactoryStatic, IPassable
    {
        protected override bool PreserveLandscape => true;
        public override string SpriteKey => typeof(HuntingGround).Name;
        protected override ValueTuple<Type, long> Out0 => new ValueTuple<Type, long>(typeof(DeerMeat), 3);

        public bool Passable => false;
        // protected override ValueTuple<Type, long> In_0_Inventory => new ValueTuple<Type, long>(typeof(Worker), 1);

        protected override void AddBuildingDescriptionPage(List<IUIItem> items) {
            items.Add(UIItem.CreateMultilineText($"{Localization.Ins.Get<HuntingGround>()}之间不能相邻"));
        }
    }
}

