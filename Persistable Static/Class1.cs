using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.CAS;
using Sims3.SimIFace;
using Sims3.Gameplay.ActorSystems;

namespace Sims3.NiecModList.Persistable
{
    public static class NOther
    {
       // [PersistableStatic(true)]
           // public static uint AlrTgger = 0; 
        public static TraitManager Emtpy_TraitManager = null;
        public static OccultManager Emtpy_OccultManager = null;
    }
    internal class _NI
    {}
    //internal struct _NS
    //{ }
    internal class _niecinternal<T>
    {
        internal _NI v = null;

        internal static object data00 = null;
        internal static T data01 = default(T);
        internal static Dictionary<ulong, NiecMod.Nra.NiecObjectPlus> data02 = null;
        internal static Dictionary<ulong, T> data03 = null;
    }

    // game crash from saveing

    //[Persistable]
    //internal class _pniecinternal<T>
    //{
    //    internal _NI v = null;
    //
    //    [PersistableStatic]
    //    internal static object data00 = null;
    //    [PersistableStatic]
    //    internal static T data01 = default(T);
    //    [PersistableStatic]
    //    internal static Dictionary<ulong, NiecMod.Nra.NiecObjectPlus> data02 = null;
    //    [PersistableStatic]
    //    internal static Dictionary<ulong, T> data03 = null;
    //}
    //[Persistable]
    public static class ListCollon
    {
        public static Household __NiecDeadSimDescriptionsHousehold = null;

        public static List<SimDescription> __NiecDeadSimDescriptions = new List<SimDescription>();

        public static Random SafeRandom = new Random(522000262);

        [PersistableStatic]
        public static bool AllowNiecDisposedSimDescriptions = true;

        [PersistableStatic]
        public static List<SimDescription> NiecDisposedSimDescriptions = null;

        [PersistableStatic]
        public static List<NiecMod.Nra.NContext> NContexts = null;

        public static List<object> SafeObjectGC = new List<object>();

        public static Random SafeRandomPart2 = new Random();

        public static Random SafeRandomPart3 = new Random(22555100);

        public static Random SafeRandomPart4 = new Random(51);

        [Persistable(false)]
            public static SimDescription NullSimSimDescription = null;
        //[PersistableStatic(true)]
            public static List<SimDescription> NiecSimDescriptions = new List<SimDescription>(2000);
        //[PersistableStatic(true)]
            public static Dictionary<ulong, MiniSimDescription> NiecMiniSimDescriptions = new Dictionary<ulong, MiniSimDescription>();
    }
}
