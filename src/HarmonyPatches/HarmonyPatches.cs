using HarmonyLib;
using System.Reflection;
using Verse;

namespace VisiblePants
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("XeoNovaDan.VisiblePants");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
