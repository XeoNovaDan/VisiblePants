using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;

namespace VisiblePants
{

    public class VisiblePants : Mod
    {

        public VisiblePantsSettings settings;
        public static Harmony harmonyInstance;

        public VisiblePants(ModContentPack content) : base(content)
        {
            settings = GetSettings<VisiblePantsSettings>();
            harmonyInstance = new Harmony("XeoNovaDan.VisiblePants");
        }

        public override string SettingsCategory() => "VisiblePants.SettingsCategory".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }

    }

}
