using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace VisiblePants
{

    public static class VisiblePantsUtility
    {

        public static bool cachedDrawPantsOver;
        public static int ticksToCacheChange = GenTicks.TicksPerRealSecond;

    }

}
