using UnityEngine;
using Verse;

namespace VisiblePants
{
    public class VisiblePantsSettings : ModSettings
    {
        public static bool drawPantsOver = true;

        public VisiblePantsSettings() : base() { }

        public void DoWindowContents(Rect rect)
        {
            var ls = new Listing_Standard();
            ls.Begin(rect);

            // Draw pants over shirts
            ls.Gap();
            ls.CheckboxLabeled("VisiblePants.DrawPantsOver".Translate(), ref drawPantsOver, "VisiblePants.DrawPantsOver_Tooltip".Translate());

            ls.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref drawPantsOver, "drawPantsOver", true);
            base.ExposeData();

            if (Scribe.mode == LoadSaveMode.PostLoadInit)
                VisiblePantsUtility.cachedDrawPantsOver = drawPantsOver;
        }
    }
}
