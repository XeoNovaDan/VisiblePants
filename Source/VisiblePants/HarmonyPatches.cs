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
using Harmony;

namespace VisiblePants
{
    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {

        private static readonly Type patchType = typeof(HarmonyPatches);

        static HarmonyPatches()
        {
            HarmonyInstance h = HarmonyInstance.Create("XeoNovaDan.VisiblePants");

            h.Patch(AccessTools.Method(typeof(Pawn_ApparelTracker), "SortWornApparelIntoDrawOrder"),
                new HarmonyMethod(patchType, nameof(Detour_SortWornApparelIntoDrawOrder)));
        }

        public static bool Detour_SortWornApparelIntoDrawOrder(Pawn_ApparelTracker __instance, ref ThingOwner<Apparel> ___wornApparel)
        {
            ___wornApparel.InnerListForReading.Sort((Apparel a, Apparel b) => AdjustedDrawOrder(a.def).CompareTo(AdjustedDrawOrder(b.def)));
            return false;
        }

        private static int AdjustedDrawOrder(ThingDef apparel) =>
            apparel.apparel.LastLayer.drawOrder + ((apparel.IsPants()) ? 99 : 0);

        private static bool IsPants(this ThingDef apparel) =>
            apparel == VP_ThingDefOf.Apparel_Pants || apparel == VP_ThingDefOf.Apparel_FlakPants;

    }
}
