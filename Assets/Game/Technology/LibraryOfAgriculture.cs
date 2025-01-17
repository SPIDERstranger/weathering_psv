﻿

using System;
using System.Collections.Generic;

namespace Weathering
{
    [ConstructionCostBase(typeof(Book), 100, 10)]
    public class LibraryOfAgriculture : AbstractTechnologyCenter
    {
        private const long BaseCost = 3000;
        protected override long TechnologyPointMaxRevenue => BaseCost;
        protected override long TechnologyPointIncRequired => 6;
        protected override Type TechnologyPointType => typeof(Grain);

        protected override List<ValueTuple<Type, long>> TechList => new List<ValueTuple<Type, long>> {

           new ValueTuple<Type, long> (typeof(Farm), 0),
           new ValueTuple<Type, long> (typeof(HuntingGround), 1*BaseCost),
           new ValueTuple<Type, long> (typeof(SeaFishery), 2*BaseCost),
           new ValueTuple<Type, long> (typeof(Pasture), 5*BaseCost),
           new ValueTuple<Type, long> (typeof(Hennery), 5*BaseCost),
        };

        protected override void DecorateItems(List<IUIItem> items, Action back) {

            IWeatherDefinition weather = Map as IWeatherDefinition;
            if (weather == null) throw new Exception();

            int hour = (int)(((weather.ProgressOfDay + 0.25f) % 1) * 24) + 1;
            string monthDescription = GeographyUtility.MonthTimeDescription(weather.MonthInYear + 1);
            string dateDescription = GeographyUtility.DateDescription(weather.DayInMonth + 1);
            string hourDescription = GeographyUtility.HourDescription(hour);

            items.Add(UIItem.CreateDynamicText(() => $"当前时令  {monthDescription} {dateDescription} {hourDescription}"));
            items.Add(UIItem.CreateSeparator());
        }
    }
}
