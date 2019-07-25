using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace VisiblePants
{

    public class VisiblePants : Mod
    {

        public VisiblePantsSettings settings;

        public VisiblePants(ModContentPack content) : base(content)
        {
            GetSettings<VisiblePantsSettings>();
        }

        public override string SettingsCategory() => "VisiblePants.SettingsCategory".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GetSettings<VisiblePantsSettings>().DoWindowContents(inRect);
        }

    }

}
