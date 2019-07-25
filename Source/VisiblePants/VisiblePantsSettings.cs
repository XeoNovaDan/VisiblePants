using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace VisiblePants
{

    public class VisiblePantsSettings : ModSettings
    {

        public static bool drawPantsOver = true;

        public void DoWindowContents(Rect wrect)
        {
            var options = new Listing_Standard();
            var defaultColor = GUI.color;
            options.Begin(wrect);
            GUI.color = defaultColor;
            Text.Font = GameFont.Small;
            Text.Anchor = TextAnchor.UpperLeft;

            // Draw pants over shirts
            options.Gap();
            options.CheckboxLabeled("VisiblePants.DrawPantsOver".Translate(), ref drawPantsOver, "VisiblePants.DrawPantsOver_Tooltip".Translate());

            // Finish
            options.End();
            Mod.GetSettings<VisiblePantsSettings>().Write();

        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref drawPantsOver, "drawPantsOver", drawPantsOver);
        }

    }

}
