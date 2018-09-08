using System;
using System.Collections.Generic;
using System.Linq;
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
                new HarmonyMethod(patchType, nameof(Prefix_SortWornApparelIntoDrawOrder)));
        }

        public static bool Prefix_SortWornApparelIntoDrawOrder(Pawn_ApparelTracker __instance, ref ThingOwner<Apparel> ___wornApparel)
        {
            ___wornApparel.InnerListForReading.Sort((Apparel a, Apparel b) => (a.IsPants() ? 99 : a.def.apparel.LastLayer.drawOrder).CompareTo(b.def.apparel.LastLayer.drawOrder));
            return false;
        }

        private static bool IsPants(this Apparel a) => a.def == VP_ThingDefOf.Apparel_Pants || a.def == VP_ThingDefOf.Apparel_FlakPants;

    }
}
