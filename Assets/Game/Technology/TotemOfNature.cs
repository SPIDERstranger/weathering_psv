﻿

using System;
using System.Collections.Generic;

namespace Weathering
{


    public class KnowledgeOfGatheringBerry { }
    public class KnowledgeOfGatheringBerryEfficiently { }

    public class KnowledgeOfHammer { }

    // BerryBush

    public class KnowledgeOfGatheringWood { }
    public class KnowledgeOfGatheringWoodEfficiently { }

    // WareHouse




    [Depend(typeof(Technology))]
    public class KnowledgeOfNature { public const long Max = 1000; }

    public class TotemOfNature : AbstractTechnologyCenter
    {
        protected override Type TechnologyPointType => typeof(KnowledgeOfNature);

        protected override long TechnologyPointIncRequired => 0;

        protected override bool DontConsumeTechnologyPoint => true;
        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

            // nature
            new ValueTuple<Type, long>(typeof(KnowledgeOfGatheringBerry), 0), // 采集
            new ValueTuple<Type, long>(typeof(KnowledgeOfGatheringBerryEfficiently), 5), // 高效采集
            new ValueTuple<Type, long>(typeof(BerryBush), 20), // 浆果丛

            new ValueTuple<Type, long>(typeof(KnowledgeOfHammer), 100), // 工具：锤子
            new ValueTuple<Type, long>(typeof(KnowledgeOfMagnet), 300), // 磁铁

            new ValueTuple<Type, long>(typeof(TotemOfAncestors), 1000), // 祖先雕像

        };

        protected override void DecorateIfCompleted(List<IUIItem> items) {
            
        }

        private readonly Type OfferingType = typeof(Berry);
        protected override void DecorateItems(List<IUIItem> items, Action onTap) {
            IValue techValue = Globals.Ins.Values.Get(TechnologyPointType);
            long quantity = Math.Min(techValue.Max - techValue.Val, Map.Inventory.CanRemove(OfferingType));

            string offeringName = Localization.Ins.ValUnit(OfferingType);

            if (quantity == 0) {
                if (!techValue.Maxed) {
                    items.Add(UIItem.CreateMultilineText($"{Localization.Ins.Get(GetType())}发出了一个声音：“给点{offeringName}吧”"));
                }
            } else {
                items.Add(new UIItem {
                    Type = IUIItemType.Slider,
                    InitialSliderValue = 1,
                    DynamicSliderContent = (float x) => {
                        slider = x;
                        sliderRounded = (long)Math.Round(slider * quantity);
                        return $"选择贡献数量 {sliderRounded}";
                    }
                });
                items.Add(UIItem.CreateDynamicContentButton(() => quantity == 0 ? $"献上{offeringName}" :
                    $"献上{offeringName} {Localization.Ins.ValPlus(OfferingType, -sliderRounded)} {Localization.Ins.ValPlus(TechnologyPointType, sliderRounded)}", () => {

                        Map.Inventory.Remove(OfferingType, sliderRounded);
                        Globals.Ins.Values.Get(TechnologyPointType).Val += sliderRounded;
                        onTap();

                    }, () => sliderRounded > 0));
            }
            items.Add(UIItem.CreateSeparator());
        }
        private float slider = 0;
        private long sliderRounded = 0;
    }
}
