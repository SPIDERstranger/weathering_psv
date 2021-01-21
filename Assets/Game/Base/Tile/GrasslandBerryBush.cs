﻿
using System;
using System.Collections.Generic;

namespace Weathering
{

    [Concept("浆果丛", "ff9999")]
    public class GrasslandBerryBush : StandardTile
    {
        public override string SpriteKey {
            get {
                if (!food.Maxed) {
                    return typeof(GrasslandBerryBush).Name + "Growing";
                }
                return typeof(GrasslandBerryBush).Name;
            }
        }

        private IValue food;

        private static string destruct;
        private static string berryBush;
        public override void OnEnable() {
            base.OnEnable();
            if (Values == null) {
                Values = Weathering.Values.GetOne();
                food = Values.Create<Food>();
                food.Max = 10;
                food.Inc = 1;
                food.Del = 10 * Value.Second;
            }
            food = Values.Get<Food>();

            destruct = Concept.Ins.ColoredNameOf<Destruct>();
            berryBush = Concept.Ins.ColoredNameOf<GrasslandBerryBush>();
        }

        public override void OnConstruct() {
        }

        public override void OnDestruct() {
        }

        public override void OnTap() {
            const long sanityCost = 1;
            var items = new List<IUIItem>() {
                UIItem.CreateValueProgress<Food>(Values),
                UIItem.CreateTimeProgress<Food>(Values),
                new UIItem {
                    Type = IUIItemType.Button,
                    Content = $"拿走食材{Concept.Ins.Val<Sanity>(-sanityCost)}",
                    OnTap = () => {
                        Map.Inventory.AddAsManyAsPossible<Food>(food);
                        Globals.Ins.Values.Get<Sanity>().Val -= sanityCost;
                    },
                    CanTap = () => Map.Inventory.CanAdd<Food>() > 0
                        && Globals.Ins.Values.Get<Sanity>().Val >= sanityCost,
                },
            };

            items.Add(UIItem.CreateSeparator());

            UIItem.AddInventory<Food>(Map.Inventory, items);
            // items.Add(UIItem.CreateValueProgress<Sanity>(Globals.Ins.Values));

            items.Add(new UIItem {
                Type = IUIItemType.Button,
                Content = $"{destruct}{berryBush}",
                OnTap = UIDecorator.ConfirmBefore(
                    () => {
                        Map.UpdateAt<Grassland>(Pos);
                        UI.Ins.Active = false;
                    }
                ),
            });

            UI.Ins.ShowItems(berryBush, items);
        }
    }
}
