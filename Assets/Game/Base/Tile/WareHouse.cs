﻿
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{
    public class WareHouseProgress { }

    public class WareHouse : StandardTile //, ILinkable
    {
        public override string SpriteKey => "StorageBuilding";
        public override bool HasDynamicSpriteAnimation => true;
        //public override string SpriteLeft => Refs.Has<IRight>() && Refs.Get<IRight>().Value > 0 ? typeof(Food).Name : null;
        //public override string SpriteRight => Refs.Has<ILeft>() && Refs.Get<ILeft>().Value > 0 ? typeof(Food).Name : null;
        //public override string SpriteUp => Refs.Has<IDown>() && Refs.Get<IDown>().Value > 0 ? typeof(Food).Name : null;
        //public override string SpriteDown => Refs.Has<IUp>() && Refs.Get<IUp>().Value > 0 ? typeof(Food).Name : null;

        public void OnLink(Type direction) {
            wareHouseProgressType.Type = ConceptResource.Get(Res.Type);
            wareHouseProgress.Inc = Res.Value;

            if (Res.Value == 0) Res.Type = null;
        }
        public IRef Res { get; private set; } // 无法作为输入

        public override void OnConstruct() {
            base.OnConstruct();
            Values = Weathering.Values.GetOne();

            wareHouseProgress = Values.Create<WareHouseProgress>();
            wareHouseProgress.Max = 1000;
            wareHouseProgress.Del = Value.Second;

            Refs = Weathering.Refs.GetOne();
            Res = Refs.Create<WareHouse>();
        }

        private IValue wareHouseProgress;
        private IRef wareHouseProgressType; // value

        public override void OnEnable() {
            base.OnEnable();
            Res = Refs.Get<WareHouse>();
            wareHouseProgress = Values.GetOrCreate<WareHouseProgress>();
            wareHouseProgressType = Refs.GetOrCreate<WareHouseProgress>();
        }

        public override void OnTap() {
            var items = UI.Ins.GetItems();

            if (wareHouseProgressType.Type != null) {
                items.Add(UIItem.CreateValueProgress(wareHouseProgressType.Type, wareHouseProgress));
                items.Add(UIItem.CreateTimeProgress(wareHouseProgressType.Type, wareHouseProgress));



                items.Add(UIItem.CreateSeparator());
            }

            // LinkUtility.CreateButtons(items, this);

            if (wareHouseProgress.Val == 0) {
                items.Add(UIItem.CreateDestructButton<TerrainDefault>(this));
            }

            UI.Ins.ShowItems("仓库", items);
        }
    }
}
