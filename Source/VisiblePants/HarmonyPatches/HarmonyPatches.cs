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
    public static class HarmonyPatches
    {

        private static readonly Type patchType = typeof(HarmonyPatches);

        static HarmonyPatches()
        {
            var h = HarmonyInstance.Create("XeoNovaDan.VisiblePants");

            h.Patch(typeof(Pawn_ApparelTracker).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).First(m => m.HasAttribute<CompilerGeneratedAttribute>() && m.Name.Contains("SortWornApparelIntoDrawOrder")),
                transpiler: new HarmonyMethod(typeof(Patch_Pawn_ApparelTracker.ManualPatch_SortWornApparelIntoDrawOrder), "Transpiler"));
        }

    }
}
