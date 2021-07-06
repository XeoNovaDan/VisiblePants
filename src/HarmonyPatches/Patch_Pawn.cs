using System.Reflection;
using Verse;
using HarmonyLib;

namespace VisiblePants
{
    public static class Patch_Pawn
    {
        [HarmonyPatch(typeof(Pawn))]
        [HarmonyPatch(nameof(Pawn.Tick))]
        public static class Patch_Tick
        {
            // Redraw pawn apparel if settings have changed
            public static void Postfix(Pawn __instance)
            {
                //Don't try to update anything that doesn't have apparel
                if (__instance.apparel == null) return;

                //Have to check that we have a valid key
                if (__instance.Name == null) return;

                var redrawFound = VisiblePantsUtility.NeedsRedraw.TryGetValue(__instance.Name, out var needsRedraw);
                if (needsRedraw || !redrawFound)
                {
                    var sortWornApparelIntoDrawOrder = __instance.apparel.GetType().GetMethod("SortWornApparelIntoDrawOrder", BindingFlags.NonPublic | BindingFlags.Instance);
                    sortWornApparelIntoDrawOrder.Invoke(__instance.apparel, new object[] { });

                    __instance.apparel.Notify_ApparelChanged();

                    VisiblePantsUtility.NeedsRedraw[__instance.Name] = false;
                }
            }
        }
    }
}
