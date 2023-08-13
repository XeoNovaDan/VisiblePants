using Verse;
using RimWorld;
using HarmonyLib;

namespace VisiblePants
{

    public static class Patch_Pawn_ApparelTracker
    {

        [HarmonyPatch(typeof(Pawn_ApparelTracker))]
        [HarmonyPatch("SortWornApparelIntoDrawOrder")]
        public static class Patch_SortWornApparelIntoDrawOrder
        {

            public static bool Prefix(Pawn_ApparelTracker __instance, ThingOwner<Apparel> ___wornApparel)
            {
                // I don't like doing detours but this was too much of a pain to transpile
                ___wornApparel.InnerListForReading.Sort((Apparel a, Apparel b) => AdjustedDrawOrder(a.def.apparel.LastLayer.drawOrder, a.def).CompareTo(AdjustedDrawOrder(b.def.apparel.LastLayer.drawOrder, b.def)));
                return false;
            }

            public static int AdjustedDrawOrder(int original, ThingDef apparelDef)
            {
                // If the apparel def has this mod's ThingDefExtension (essentially a flag), add 1 to the draw order
                if (apparelDef.HasModExtension<ThingDefExtension>())
                    return original + (VisiblePantsSettings.drawPantsOver ? 1 : -1);

                return original;
            }

        }

    }
}
