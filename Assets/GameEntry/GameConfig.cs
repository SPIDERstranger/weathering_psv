﻿

using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{
	/// <summary>
	/// 发布时和测试时，需要改哪几个地方？
	/// GlobalGameEvents的设置
	/// </summary>
	public static class GameConfig
	{
		public static System.Type InitialMap { get; private set; } = typeof(IslandMap);
		public const int VersionCode = 20210203;
		public static void OnGameConstruct(IGlobals globals) {
			GameMenu.RestoreDefaultSettings();

			// 全局理智
			IValue sanity = globals.Values.Create<Sanity>();
			sanity.Max = 100;
			sanity.Inc = 1;
			sanity.Del = Value.Second;
			// 全局农场科技
			IValue farmTech = globals.Values.Create<FarmTech>();
			farmTech.Del = 360 * Value.Second;
		}

		public static void OnGameConstruct() {

		}

		public static void OnGameEnable() {

		}

		public static void OnGameUpdate() {

		}

		public static void OnSave() {

		}



	}
}
