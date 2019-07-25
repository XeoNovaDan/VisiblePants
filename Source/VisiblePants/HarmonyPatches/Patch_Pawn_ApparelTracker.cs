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

    public static class Patch_Pawn_ApparelTracker
    {

        public static class ManualPatch_SortWornApparelIntoDrawOrder
        {

            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var instructionList = instructions.ToList();

                var drawOrderInfo = AccessTools.Field(typeof(ApparelLayerDef), nameof(ApparelLayerDef.drawOrder));

                for (int i = 0; i < instructionList.Count; i++)
                {
                    var instruction = instructionList[i];

                    if (instruction.opcode == OpCodes.Callvirt && instruction.operand == drawOrderInfo)
                    {
                        var thirdInstructionBehind = instructionList[i - 3];
                        yield return instruction; // a.def.apparel.LastLayer.drawOrder or b.def.apparel.LastLayer.drawOrder
                        yield return new CodeInstruction(thirdInstructionBehind.opcode, thirdInstructionBehind.operand); // a or b
                        instruction = new CodeInstruction(OpCodes.Call);
                    }

                    yield return instruction;
                }
            }

            public static int AdjustedDrawOrder(int original, Apparel apparel)
            {
                // Determine the new draw order if apparel has this mod's ThingDefExtension (which effectively acts like a flag)
                if (VisiblePantsSettings.drawPantsOver && apparel.def.HasModExtension<ThingDefExtension>())
                    return original + 1;

                return original;
            }

        }

    }
}
