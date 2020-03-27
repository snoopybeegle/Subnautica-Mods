﻿using Harmony;
using QModManager.API.ModLoading;
using System.Reflection;

namespace WarpersNoWarping
{
	[QModCore]
	public class Main
    {

		[QModPatch]
		public void Load()
		{
			HarmonyInstance.Create("MrPurple6411.WarpersNoWarping").PatchAll(Assembly.GetExecutingAssembly());
		}
	}

	[HarmonyPatch(typeof(WarpOut), nameof(WarpOut.Evaluate))]
	public class WarpOut_Evaluate
	{
		[HarmonyPrefix]
		public static bool Prefix(ref float __result)
		{
			__result = 0f;
			return false;
		}
	}

	[HarmonyPatch(typeof(Warper), nameof(Warper.OnKill))]
	public class Warper_OnKill
	{
		[HarmonyPrefix]
		public static void Postfix(Warper __instance)
		{
			__instance.WarpOut();
		}
	}
}