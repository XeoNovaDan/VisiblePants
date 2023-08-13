using UnityEngine;
using Verse;

namespace VisiblePants
{
    public class VisiblePants : Mod
    {
        public VisiblePantsSettings settings;
        public VisiblePants(ModContentPack content) : base(content)
        {
            settings = GetSettings<VisiblePantsSettings>();
        }

        public override string SettingsCategory() => "VisiblePants.SettingsCategory".Translate();

        public override void DoSettingsWindowContents(Rect rect)
        {
            settings.DoWindowContents(rect);
            base.DoSettingsWindowContents(rect);
        }
    }
}
