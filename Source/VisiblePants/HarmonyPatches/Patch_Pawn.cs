using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;

namespace VisiblePants
{

    public static class Patch_Pawn
    {

        [HarmonyPatch(typeof(Pawn))]
        [HarmonyPatch(nameof(Pawn.Tick))]
        public static class Patch_Tick
        {

            public static void Postfix(Pawn __instance)
            {
                // Redraw pawn apparel if settings have changed
                if (__instance.apparel != null && VisiblePantsUtility.cachedDrawPantsOver != VisiblePantsSettings.drawPantsOver)
                {
                    if (VisiblePantsUtility.ticksToCacheChange == 0)
                    {
                        VisiblePantsUtility.ticksToCacheChange = GenTicks.TicksPerRealSecond;
                        VisiblePantsUtility.cachedDrawPantsOver = VisiblePantsSettings.drawPantsOver;
                    }
                    else
                        VisiblePantsUtility.ticksToCacheChange--;

                    var sortWornApparelIntoDrawOrder = __instance.GetType().GetMethod("SortWornApparelIntoDrawOrder", BindingFlags.NonPublic | BindingFlags.Instance);
                    var apparelChanged = __instance.GetType().GetMethod("ApparelChanged", BindingFlags.NonPublic | BindingFlags.Instance);

                    sortWornApparelIntoDrawOrder.Invoke(__instance, new object[] { });
                    apparelChanged.Invoke(__instance, new object[] { });
                }
            }

        }

    }
}
