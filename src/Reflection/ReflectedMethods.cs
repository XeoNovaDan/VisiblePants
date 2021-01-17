using System;
using Verse;
using RimWorld;
using System.Reflection;

namespace VisiblePants
{

    [StaticConstructorOnStartup]
    public static class ReflectedMethods
    {

        static ReflectedMethods()
        {
            SortWornApparelIntoDrawOrder = (OpenDelegate<Pawn_ApparelTracker>)Delegate.CreateDelegate(typeof(OpenDelegate<Pawn_ApparelTracker>), null,
                typeof(Pawn_ApparelTracker).GetMethod("SortWornApparelIntoDrawOrder", BindingFlags.NonPublic | BindingFlags.Instance));
        }

        public static OpenDelegate<Pawn_ApparelTracker> SortWornApparelIntoDrawOrder;

        public delegate void OpenDelegate<T>(T instance);

    }

}
