﻿
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{
    public class PopulationCount { }
    public class Village : StandardTile, ILinkConsumer
    {
        public override string SpriteKey => typeof(Village).Name;

        public override bool HasDynamicSpriteAnimation => true;
        public override string SpriteLeft => GetSprite(Vector2Int.left, typeof(ILeft));
        public override string SpriteRight => GetSprite(Vector2Int.right, typeof(IRight));
        public override string SpriteUp => GetSprite(Vector2Int.up, typeof(IUp));
        public override string SpriteDown => GetSprite(Vector2Int.down, typeof(IDown));
        private string GetSprite(Vector2Int pos, Type direction) {
            IRefs refs = Map.Get(Pos - pos).Refs;
            if (refs == null) return null;
            if (refs.TryGet(direction, out IRef result)) return result.Value < 0 ? ConceptResource.Get(result.Type).Name : null;
            return null;
        }

        //public override string SpriteLeft => Refs.Has<IRight>() && Refs.Get<IRight>().Value > 0 ? ConceptResource.Get(foodRef.Type).Name : null;
        //public override string SpriteRight => Refs.Has<ILeft>() && Refs.Get<ILeft>().Value > 0 ? ConceptResource.Get(foodRef.Type).Name : null;
        //public override string SpriteUp => Refs.Has<IDown>() && Refs.Get<IDown>().Value > 0 ? ConceptResource.Get(foodRef.Type).Name : null;
        //public override string SpriteDown => Refs.Has<IUp>() && Refs.Get<IUp>().Value > 0 ? ConceptResource.Get(foodRef.Type).Name : null;

        public override void OnConstruct() {
            base.OnConstruct();
            Refs = Weathering.Refs.GetOne();
            foodRef = Refs.Create<FoodSupply>();
            foodRef.BaseValue = foodPerWorker * villagePopMax;
            foodRef.Value = 0;
            foodRef.Type = typeof(FoodSupply);

            Values = Weathering.Values.GetOne();
            popValue = Values.Create<Worker>();
        }

        private IRef foodRef;
        private IValue popValue;

        private IValue mapPopulation;

        public override void OnEnable() {
            base.OnEnable();
            foodRef = Refs.Get<FoodSupply>();
            popValue = Values.Get<Worker>();
            mapPopulation = Map.Values.GetOrCreate<PopulationCount>();
        }

        public void Consume(List<IRef> refs) {
            refs.Add(foodRef);
        }

        public const long foodPerWorker = 5;
        public const long villagePopMax = 3;

        public override void OnTap() {
            var items = UI.Ins.GetItems();

            // items.Add(UIItem.CreateValueProgress<Worker>(popValue));


            items.Add(UIItem.CreateText($"人口 {Localization.Ins.Val<Worker>(popValue.Max)}"));

            long quantityIn = Math.Min(Math.Min(foodRef.Value / foodPerWorker, villagePopMax - popValue.Max), Map.Inventory.CanAdd<Worker>());
            items.Add(UIItem.CreateButton("居民入住", () => {
                foodRef.Value -= quantityIn * foodPerWorker;
                foodRef.BaseValue -= quantityIn * foodPerWorker;
                popValue.Max += quantityIn;
                Map.Inventory.Add<Worker>(quantityIn);
                mapPopulation.Max += quantityIn;
                OnTap();
            }, () => quantityIn > 0));

            long quantityOut = Math.Min(popValue.Max, Map.Inventory.Get<Worker>());
            items.Add(UIItem.CreateButton("居民离开", () => {
                foodRef.BaseValue += quantityOut * foodPerWorker;
                foodRef.Value += quantityOut * foodPerWorker;
                popValue.Max -= quantityOut;
                Map.Inventory.Remove<Worker>(quantityOut);
                mapPopulation.Max -= quantityIn;
                OnTap();
            }, () => quantityOut > 0));

            items.Add(UIItem.CreateSeparator());
            LinkUtility.AddButtons(items, this);

            if (popValue.Max == 0 && foodRef.Value == 0) {
                items.Add(UIItem.CreateDestructButton<TerrainDefault>(this));
            }

            items.Add(UIItem.CreateText($"每个村庄最多住{Localization.Ins.Val<Worker>(villagePopMax)}"));
            items.Add(UIItem.CreateText($"每个居民消耗{Localization.Ins.Val(foodRef.Type, foodPerWorker)}"));

            UI.Ins.ShowItems("村庄", items);
        }
    }
}

