using System;
using ScriptCore;
using NiecMod.Nra;

internal static class a {

    internal static object tea()
    {
        te();
        return te();
    }

    internal static object te()
    {
        return tea();
    }

    // bool bmethed_METestAddInteractionErrorTestPMPP
    internal static bool a_ = true;

    // bool bmethed_METestAddInteractionErrorTestPMPbP
    internal static bool b_ = true;

    internal static bool c_ = true;

    // void METestAddInteractionErrorTestPMPP(e,iop,ActiveActor)
    internal static void _(Sims3.Gameplay.Interactions.InteractionDefinition e, Sims3.Gameplay.Autonomy.InteractionObjectPair iop, Sims3.Gameplay.Actors.Sim ActiveActor)
    {
        if (!a_) return;
        try
        {
            e.Equals(e);
            e.GetHashCode();
        }
        catch (Exception ex) // unprotected mono mscorlib 
        {
            ex.stack_trace = null;
            ex.trace_ips = null;
            ex.message = "";
            ex.inner_exception = null;
            throw;
        }
        if (c_)
            iop = new Sims3.Gameplay.Autonomy.InteractionObjectPair(e, NiecMod.Helpers.NiecRunCommand.HitTargetGameObject() ?? NiecMod.Helpers.NiecRunCommand.HitTargetLot());
        //bool sot = iop.mTarget == null;
        Sims3.SimIFace.GreyedOutTooltipCallback g = null;
        //try
        {
            //if (sot)
            //    iop.mTarget = NiecMod.Helpers.NiecRunCommand.HitTargetGameObject();

            Sims3.Gameplay.Interactions.InteractionInstanceParameters aa = new Sims3.Gameplay.Interactions.InteractionInstanceParameters(iop, ActiveActor, new Sims3.Gameplay.Interactions.InteractionPriority(Sims3.Gameplay.Interactions.InteractionPriorityLevel.UserDirected), Sims3.Gameplay.Autonomy.AutonomySearchType.None, Sims3.Gameplay.Interactions.InteractionFlags.None, NiecMod.Helpers.NiecRunCommand.GetGameObjectHit(), null, false);
            if (b_ || e.Test(ref aa, ref g) == Sims3.Gameplay.Interactions.InteractionTestResult.Pass)
            {
                //aa = new InteractionInstanceParameters(iop, ActiveActor, new InteractionPriority(InteractionPriorityLevel.UserDirected), AutonomySearchType.None, InteractionFlags.None, NiecRunCommand.GetGameObjectHit(), null, false);
                int i = 0;
                var s = NiecMod.Helpers.NiecRunCommand.GetUnSafeContextList<Sims3.UI.ObjectPicker.TabInfo>();
                NFinalizeDeath. List_FastClearEx(ref s);
                var r = NiecMod.Helpers.NiecRunCommand.GetUnSafeContextList<Sims3.UI.ObjectPicker.HeaderInfo>();
                NFinalizeDeath.List_FastClearEx(ref r);

                e.PopulatePieMenuPicker(ref aa, out s, out r, out i);
            }
        }
        //finally { if (sot) iop.mTarget = null; }
    }
}
// unprotected mono mscorlib 
// Tested x32dbg :)

public class niecstd_i_equatable_of_t_equality_comparer<T> : niecstd_equality_comparer<T> where T : IEquatable<T>
{
    public override int GetHashCode(T obj)
    {
        return obj.GetHashCode();
    }

    public override bool Equals(T x, T y)
    {
        if (x == null)
        {
            return y == null;
        }
        return x.Equals(y);
    }
}


public abstract
    class niecstd_equality_comparer<T> : System.Collections.IEqualityComparer, System.Collections.Generic.IEqualityComparer<T>
{
    public class niecstd_default_equality_comparer : niecstd_equality_comparer<T>
    {
        public override int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        public override bool Equals(T x, T y)
        {
            if (x == null)
            {
                return y == null;
            }
            return x.Equals(y);
        }
    }

    public static readonly niecstd_equality_comparer<T> Default;

    static niecstd_equality_comparer()
    {

        if (typeof(IEquatable<T>).IsAssignableFrom(typeof(T)))
        {
            try
            {
                Default = (niecstd_equality_comparer<T>)Activator.CreateInstance(typeof(niecstd_i_equatable_of_t_equality_comparer<>).MakeGenericType(typeof(T)) ?? typeof(niec_std));
            }
            catch (Exception)
            { Default = new niecstd_default_equality_comparer(); }
        }
        else
        {
            Default = new niecstd_default_equality_comparer();
        }
    }

    public abstract int GetHashCode(T obj);

    public abstract bool Equals(T x, T y);

    int System.Collections.IEqualityComparer.GetHashCode(object obj)
    {
        return GetHashCode((T)obj);
    }

    bool System.Collections.IEqualityComparer.Equals(object x, object y)
    {
        return Equals((T)x, (T)y);
    }
}





internal class niec_std
{
    internal static void exit() {
        if ((int)niec_native_func.LoadDLLNativeLibrary("exitgame.dll") == 0)
            GameUtils.GameUtils_TransitionToQuitImpl();
    }

    internal static void all_call_native()
    {
        
        try
        {
            ScriptCore.Route.Route_Plan(ScriptCore.Route.Route_CreateRoute(0, 2));
        }
        catch
        { }

        try
        {
            ScriptCore.Route.Route_Replan(0xFECFFFF2);
        }
        catch
        { }

        try
        {
            ScriptCore.World.World_IsEditInGameFromWBModeImpl();
        }
        catch
        { }

        try
        {
            ScriptCore.World.World_IsObjectOnScreenImpl(0xEAFCFAFC);
        }
        catch
        { }

        try
        {
            ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString("ScriptCore::LocalizedStringService::LocalizedStringService_GetLocalizedStringByString");
        }
        catch
        { }

        try
        {
            ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByUInt64(0xFEEAFFC1);
        }
        catch
        { }

        try
        {
            ScriptCore.LoadSaveManager.LoadSaveManager_SaveGame_Impl(0xFBBBBBC1, true, true);
        }
        catch
        { }

        try
        {
            ScriptCore.DownloadContent.DownloadContent_GenerateGUIDImpl();
        }
        catch
        { }

        try
        {
            ScriptCore.SACS.SACS_RequestStateImpl(0xFACFFFF1, 0xFACFFFF2, 0xFACFFFF3, (Sims3.SimIFace.SACS.DriverRequestFlags)0xFACFFFF4, 0xFACFFFF5, 0xFACFFFF6, 0xFACFFFF7);
        }
        catch
        { }

        try
        {
            ScriptCore.SACS.SACS_AcquireDriverNoYieldImpl(0, 245111456, 7452, 64212, 1);
        }
        catch
        { }

        try
        {
            ScriptCore.SACS.SACS_AcquireDriverImpl(0, 84265542, 2456, 421142, 1, null);
        }
        catch
        { }

        try
        {
            ScriptCore.Random.Random_NextDoubleImpl();
        }
        catch
        { }

        try
        {
            ScriptCore.Objects.Objects_IsValid((ulong)ScriptCore.Random.Random_NextDoubleImpl());
        }
        catch
        { }

        try
        {
            ScriptCore.CommandSystem.Command_ExecuteCommandStringImpl("veitc fixallsimdesc");
        }
        catch
        { }

        try
        {
            ScriptCore.CameraController.Camera_GetControllerType();
        }
        catch
        { }

        try
        {
            ScriptCore.CameraController.Camera_GetTarget();
        }
        catch
        { }

        try
        {
            ScriptCore.CameraController.Camera_GetPosition();
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_DidSecuritySystemFailImpl();
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_GetCurrentTaskImpl();
        }
        catch
        { }

        try
        {
            ScriptCore.EAText.EAText_GetMoneyString(100000);
        }
        catch
        { }

        try
        {
            ScriptCore.UserToolUtils.UserToolUtils_CreateNewCollectionImpl("TestName", 1, 0, 0, 0);
        }
        catch
        { }

        try
        {
            ScriptCore.DeviceConfig.DeviceConfig_AuthenticateDisc();
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_IsValidInstallation();
        }
        catch
        { }

        try
        {
            ScriptCore.UIManager.UIManager_SetResolutionImpl(1366, 768, 0, false);
        }
        catch
        { }

        try
        {
            ScriptCore.Queries.Query_GetObjects(typeof(Sims3.Gameplay.Abstracts.GameObject));
        }
        catch
        { }

        try
        {
            ScriptCore.Queries.Query_CountObjects(typeof(Sims3.Gameplay.Abstracts.GameObject));
        }
        catch
        { }

        try
        {
            var v0 = default(Sims3.SimIFace.Vector3);
            var v1 = default(float);
            ScriptCore.World.World_FindGoodLocation(0x0ABFFFF1, default(Sims3.SimIFace.Vector3), 0x0ABFFFF2, 0x0ABFFFF3, 0x0ABFFFF4, 0x0ABFFFF5, 0x0ABFFFF6, 0x0ABFFFF7, null, null, ref v0, ref v1, true, 0x0ABFFFF8, 0x0ABFFFF9);
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_GetWorldName();
        }
        catch
        { }

        try
        {
            ScriptCore.VideoRecorder.VideoRecorder_TakeSnapshot();
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_GetWorldType();
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_DeleteSaveFileImpl("libNiecMod.so");
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_IsPausedImpl();
        }
        catch
        { }
        if (!NInjetMethed.DoneInjectOuit)
        {
            try
            {
                ScriptCore.GameUtils.GameUtils_TransitionToQuitImpl();
            }
            catch
            { }
        }
        try
        {
            ScriptCore.GameUtils.GameUtils_IsSaveGameCorruptedByEP1("Veitc_C.dll");
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_DestroyObjectImpl(0);
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_GetTickCountImpl();
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_CreateObjectImpl(0xFFCADDD1, 0xFFCADDD2, 0xFFCADDD3, null);
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_AddObjectImpl(0xFFBDDDD1, 0xFFBDDDD2);
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_DisableScriptImpl(0xFFBDDDC1);
        }
        catch
        { }

        try
        {
            ScriptCore.Simulator.Simulator_WakeImpl(0xFFBDDDB1, true);
        }
        catch
        { }

        try
        {
            var o = default(Sims3.SimIFace.ResourceKey);
            ScriptCore.DownloadContent.DownloadContent_SaveTravelSim(null, null, null, default(Sims3.SimIFace.ResourceKey), ref o);
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_SetGameTimeScaleImpl(100);
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_PauseImpl();
        }
        catch
        { }
        try
        {
            ScriptCore.GameUtils.GameUtils_SetGameTimeSpeedLevel(3);
        }
        catch
        { }

        try
        {
            ScriptCore.DownloadContent.DownloadContent_InstallContentImpl("HelloWorld.Sims3Pack");
        }
        catch
        { }

        try
        {
            ScriptCore.GameUtils.GameUtils_GetFrameNumber();
        }
        catch
        { }
        try
        {
            ScriptCore.GameUtils.GameUtils_GetCurrentMemoryUsage();
        }
        catch
        { }
        try
        {
            ScriptCore.GameUtils.GameUtils_FreezeLotLODs(true);
        }
        catch
        { }
        try
        {
            ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl();
        }
        catch
        { }
        try
        {
            ScriptCore.GameUtils.GameUtils_GetGameTimeSpeedLevel();
        }
        catch
        { }
        try
        {
            ScriptCore.GameUtils.GameUtils_UnpauseImpl();
        }
        catch
        { }

        throw new NullReferenceException();
    }

    internal static void force_crash<T>()
    {
        try
        {
            Niec.iCommonSpace.KillPro.YGeneration.GetHashCode();
        }
        catch (Exception)
        {
            NFinalizeDeath.World_NativeInstance = 0x10000000U;
            throw;
        }
       
    }

    internal static T force_exit<T>() {
        foreach (var item in NFinalizeDeath.SC_GetObjects<Sims3.Gameplay.Abstracts.GameObject>())
        {
            if (item == null) continue;
            ScriptCore.TaskContext context;

            if (!ScriptCore.TaskControl.GetTaskContext(item.ObjectId.mValue, true, out context))
            {
                continue;
            }
            try
            {
                context.mFrames = new TaskFrame[context.mSleepTicks + 45 + NFinalizeDeath.SC_GetObjects<Sims3.SimIFace.IScriptLogic>().LongLength + World.World_GetWorldNameKey().Length];
            }
            catch (Exception)
            {
                context.mFrames = new TaskFrame[1000000];
            }

            context.mSleepTicks = -1;

            TaskControl.SetTaskContext(item.ObjectId.mValue, ref context);
            context.mFrames[0].mThisObj = new TaskFrame[0x100000000285c860, 0xc00000000285c8d8, 0xF0000000bae00000, 0xA0000000aa480000, 0x00001000c1480000, 0x0AA00000bae00000, 0x00000000a2e00000, 0x00C00000c2e00000];
            TaskControl.SetTaskContext(item.ObjectId.mValue, ref context);
        }
        string asde = Sims3.NiecModList.Persistable.ListCollon.SafeRandomPart2.NextDouble().ToString();
        if (CommandSystem.Command_RegisterCommandImpl(asde, "", new Sims3.SimIFace.CommandHandler(delegate
        {
            Sims3.UI.TwoButtonDialog.Show("", "", "");
            return -1;
        }), false)) CommandSystem.Command_ExecuteCommandStringImpl(asde);

        Niec.iCommonSpace.KillPro.YGeneration.GetHashCode();

        Mono.Runtime.mono_runtime_install_handlers();

        GameUtils.GameUtils_TransitionToQuitImpl();
        return default(T);
    }
    public unsafe static bool is_valid_handle(IntPtr handle)
    {
        var h = (uint)handle.value;
        if (h == 0 || h == 0xFFFFFFFF)
            return false;
        return true;
    }
    internal static void checkf<T>(T obj) {
        if (obj == null)
            throw new InvalidOperationException("checkf failed: obj == null");
    }


    public static void array_copy(Array source_array, int source_index, Array destination_array, int destination_index, int length) // fast code.  Mono Interpreter only
    {
        if (source_array == null)
        {
            throw new ArgumentException("source_array == null");
        }
        if (destination_array == null)
        {
            throw new ArgumentException("destination_array == null");
        }
        if (length < 0)
        {
            throw new ArgumentException("length has to be >= 0.");
        }
        if (source_index < 0)
        {
            throw new ArgumentException("source_index has to be >= 0.");
        }
        if (destination_index < 0)
        {
            throw new ArgumentException("destination_index has to be >= 0.");
        }
        if (Array.FastCopy(source_array, source_index, destination_array, destination_index, length))
        {
            return; // ok
        }
        throw new ArgumentException("FastCopy() failed."); // show debug
        // slow Array.Copy() :(
    }
    public static int array_indexof<T>(T[] array, T item) // fast code.  Mono Interpreter only
    {
        if (array == null)
        {
            throw new ArgumentException("array == null");
        }
        for (int i = 0, max_l = array.Length; i < max_l; i++)
        {
            //if (object.ReferenceEquals(array[i], item)) 
            if ((object)array[i] == (object)item) 
                return i;
        }
        return -1;
    }
    public static int array_indexof<T>(T[] array, T item, int length) // fast code.  Mono Interpreter only
    {
        if (array == null)
        {
            throw new ArgumentException("array == null");
        }
        if (length < 0) { throw new ArgumentException("length has to be >= 0."); }
        for (int i = 0; i < length; i++)
        {
            //if (object.ReferenceEquals(array[i], item)) 
            if ((object)array[i] == (object)item)
                return i;
        }
        return -1;
    }
    //public static bool okindexifar = false;
    public static bool list_remove<T>(System.Collections.Generic.List<T> list, T item) // fast code.  Mono Interpreter only
    {
        int index = array_indexof(list._items, item, list._size);
        if (index != -1)
        {
            //okindexifar = true;
            if (index < 0 || (uint)index > (uint)list._size) {
                throw new ArgumentException("array_indexof() is out of range.");
            }

            int start = index; 
            int delta = -1;

            if (delta < 0)
                start -= delta;

            array_copy(list._items, start, list._items, start + delta, list._size - start);

            list._size += delta;
            list._items[list._size] = default(T);
            list._version++;
        }
        return index != -1;
    }

    internal static void mono_runtime_install_handlers() // Windows Only. Not working on Linux Should Wine bug? 
    {
        Mono.Runtime.mono_runtime_install_handlers();
    }

    internal static int yuv2rgb(int yuv)
    {
        double y, Cr, Cb;
        int r, g, b;

        y = (yuv >> 16) & 0xff;
        Cr = (yuv >> 8) & 0xff;
        Cb = (yuv) & 0xff;

        r = (int)(1.164 * (y - 16) + 1.596 * (Cr - 128));
        g = (int)(1.164 * (y - 16) - 0.392 * (Cb - 128) - 0.813 * (Cr - 128));
        b = (int)(1.164 * (y - 16) + 2.017 * (Cb - 128));

        r = (r < 0) ? 0 : r;
        g = (g < 0) ? 0 : g;
        b = (b < 0) ? 0 : b;

        r = (r > 255) ? 255 : r;
        g = (g > 255) ? 255 : g;
        b = (b > 255) ? 255 : b;

        return (r << 16) | (g << 8) | b;
    }

    internal static int rgb2yuv(int rgb)
    {
        double r, g, b;
        int y, Cr, Cb;

        r = (rgb >> 16) & 0xff;
        g = (rgb >> 8) & 0xff;
        b = (rgb) & 0xff;

        y = (int)(16.0 + (0.257 * r) + (0.504 * g) + (0.098 * b));
        Cb = (int)(128.0 + (-0.148 * r) - (0.291 * g) + (0.439 * b));
        Cr = (int)(128.0 + (0.439 * r) - (0.368 * g) - (0.071 * b));

        y = (y < 0) ? 0 : y;
        Cb = (Cb < 0) ? 0 : Cb;
        Cr = (Cr < 0) ? 0 : Cr;

        y = (y > 255) ? 255 : y;
        Cb = (Cb > 255) ? 255 : Cb;
        Cr = (Cr > 255) ? 255 : Cr;

        return (y << 16) | (Cr << 8) | Cb;
    }

    internal static long list_nonnull_item_count_int64<T>(System.Collections.Generic.List<T> list)
    {
        var list_items = list._items;
        for (long i = 0, max_length = list_items.LongLength; i < max_length; i++)
        {
            if (list_items[i] != null)
                continue;
            return i;
        }
        return 0;
    }

    internal static void safeb64_list_clear<T>(System.Collections.Generic.List<T> list, bool trim_count)
    {
        var list_items = list._items;

        for(long i = 0, max_length = list_items.LongLength; i < max_length; list_items[i++] = default(T));

        if (trim_count)
            list._size = 0;

        list._version++;
    }

    internal static void safeb32_list_clear<T>(System.Collections.Generic.List<T> list, bool trim_count)
    {
        var list_items = list._items;

        for(int i = 0, max_length = list_items.Length; i < max_length; list_items[i++] = default(T));

        if (trim_count)
            list._size = 0;

        list._version++;
    }

    internal static int list_nonnull_item_count_int32<T>(System.Collections.Generic.List<T> list)
    {
        var list_items = list._items;
        for (int i = 0, max_length = list_items.Length; i < max_length; i++)
        {
            if (list_items[i] != null)
                continue;
            return i;
        }
        return 0;
    }

    internal static 
        int dictionary_do_hash<TKey, TValue>
        (System.Collections.Generic.Dictionary<TKey, TValue> _this, TKey key)
    {
        //uint length = (uint)_this.table.Length;
        //uint hash_code = (uint)(hcp.GetHashCode(key) & int.MaxValue);
        return (int)((uint)_this.table.Length % (uint)(niecstd_equality_comparer<TKey>.Default.GetHashCode(key) & int.MaxValue));
    }


    internal static
        bool dictionary_contains_key<TKey, TValue>
        (System.Collections.Generic.Dictionary<TKey, TValue> _this, TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("key", "Key is null");
        }
        int index;
        return dictionary_get_slot(_this, key, out index) != null;
    }

    internal static
        TValue dictionary_get_value<TKey, TValue>
        (System.Collections.Generic.Dictionary<TKey, TValue> _this, TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("key", "Key is null");
        }
        uint length = (uint)_this.table.Length;
        uint hash_code = (uint)(niecstd_equality_comparer<TKey>.Default.GetHashCode(key) & int.MaxValue) % length;
        for (var slot = _this.table[hash_code]; slot != null; slot = slot.Next)
        {
            if (niecstd_equality_comparer<TKey>.Default.Equals(slot.Key, key))
            {
                return slot.Value;
            }
        }
        throw new System.Collections.Generic.KeyNotFoundException();
    }

    internal static
        TValue dictionary_get_value_no_error_not_find<TKey, TValue>
        (System.Collections.Generic.Dictionary<TKey, TValue> _this, TKey key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("key", "Key is null");
        }
        uint length = (uint)_this.table.Length;
        uint hash_code = (uint)(niecstd_equality_comparer<TKey>.Default.GetHashCode(key) & int.MaxValue) % length;
        for (var slot = _this.table[hash_code]; slot != null; slot = slot.Next)
        {
            if (niecstd_equality_comparer<TKey>.Default.Equals(slot.Key, key))
            {
                return slot.Value;
            }
        }
        return default(TValue);
    }

    internal static 
        void dictionary_set_threshold<TKey, TValue>
        (System.Collections.Generic.Dictionary<TKey, TValue> _this)
    {
        _this.threshold = (int)(_this.table.Length * 0.9f);
        if (_this.threshold == 0 && _this.table.Length > 0)
        {
            _this.threshold = 1;
        }
    }

    internal static 
        void dictionary_resize<TKey, TValue>
        (System.Collections.Generic.Dictionary<TKey, TValue> _this)
    {
        uint hash = (uint)System.Collections.Hashtable.ToPrime((_this.table.Length << 1) | 1);

        System.Collections.Generic.Dictionary<TKey, TValue>.Slot slot = null;
        System.Collections.Generic.Dictionary<TKey, TValue>.Slot[] slotArray = _this.table;

        _this.table = new System.Collections.Generic.Dictionary<TKey, TValue>.Slot[hash];

        dictionary_set_threshold(_this);

        for (int i = 0; i < slotArray.Length; i++)
        {
            for (var itemSlot = slotArray[i]; itemSlot != null; itemSlot = slot)
            {
                slot = itemSlot.Next;

                int itemHash = dictionary_do_hash(_this, itemSlot.Key);

                itemSlot.Next = _this.table[itemHash];
                _this.table[itemHash] = itemSlot;
            }
        }
    }


    internal static
        void dictionary_set_value<TKey, TValue>
        (System.Collections.Generic.Dictionary<TKey, TValue> _this, TKey key, TValue value)
    {
        if (key == null)
        {
            throw new ArgumentNullException("key", "Key is null");
        }

        int index;

        var prev = dictionary_get_prev(_this, key, out index);
        var slot = (prev == null) ? _this.table[index] : prev.Next;

        if (slot == null)
        {
            if (_this.Count++ >= _this.threshold)
            {
                dictionary_resize(_this);
                index = dictionary_do_hash(_this, key);
            }
            _this.table[index] = new System.Collections.Generic.Dictionary<TKey, TValue>.Slot(key, value, _this.table[index]);
            return;
        }

        _this.generation++;

        if (prev != null)
        {
            prev.Next = slot.Next;
            slot.Next = _this.table[index];
            _this.table[index] = slot;
        }

        slot.Key = key;
        slot.Value = value;
    }

    internal static 
        System.Collections.Generic.Dictionary<TKey, TValue>.Slot 
        dictionary_get_slot<TKey, TValue>(System.Collections.Generic.Dictionary<TKey, TValue> _this, TKey key, out int index)
    {
        var prev = dictionary_get_prev(_this, key, out index);
        if (prev != null)
        {
            return prev.Next;
        }
        return _this.table[index];
    }

    internal static 
        System.Collections.Generic.Dictionary<TKey, TValue>.Slot
        dictionary_get_prev<TKey, TValue>(System.Collections.Generic.Dictionary<TKey, TValue> _this, TKey key, out int index)
    {
        uint length = (uint)_this.table.Length;
        uint hash_code = (uint)(niecstd_equality_comparer<TKey>.Default.GetHashCode(key) & int.MaxValue) % length;
        var slot = _this.table[hash_code];
        if (slot != null)
        {
            System.Collections.Generic.Dictionary<TKey, TValue>.Slot result = null;
            while (!niecstd_equality_comparer<TKey>.Default.Equals(slot.Key, key))
            {
                result = slot;
                slot = slot.Next;
                if (slot == null)
                    break;
                if (slot == slot.Next)
                    break;
            }
            index = (int)hash_code;
            return result;
        }
        index = (int)hash_code;
        return null;
    }

    internal static int array_nonnull_item_count_int32<T>(T[] list)
    {
        for (int i = 0, max_length = list.Length; i < max_length; i++)
        {
            if (list[i] != null)
                continue;
            return i;
        }
        return 0;
    }

    internal unsafe static void reduce(int* x, int* y, int num, int den)
    {
        int n = num, d = den;
        while (d != 0)
        {
            int t = d;
            d = n % d;
            n = t;
        }
        if (n != 0)
        {
            *x = num / n;
            *y = den / n;
        }
        else
        {
            *x = num;
            *y = den;
        }
    }

    internal unsafe static void write_byte_bit64(uint pointer, long val)
    {
        //try
        //{
        //    // byte* vl = (byte*)pointer;
        //    //*(long*)(uint*)pointer = *(long*)val;
        //
        //    //byte* ptr = (byte*)pointer;
        //    //byte* ptrC = (byte*)val;
        //    //for (int i = 0; i < 8; i++)
        //    //{
        //    //    ptr[i] = ptrC[i];
        //    //}
        //    //*(uint*)pointer = *(uint*)val;
        //    *(long*)((void*)pointer) = val;
        //}
        //catch (Exception ex) // Terminate Runtime?
        //{
        //    ex.stack_trace = null;
        //    ex.message = "";
        //    ex.inner_exception = null;
        //    ex.trace_ips = null;
        //    ex.source = null;
        //    ex._data = null;
        //}
        *(long*)((void*)pointer) = val;
    }

    internal static void checkfc(bool condition) {
        if (!condition)
            throw new InvalidOperationException("checkf failed");
    }

    internal static void printf(string message) {
        NiecException.PrintMessagePro(message ?? "no message", false, 50);
    }

    internal static void printfm(params string[] messages)
    {
        if (messages == null || messages.Length == 0)
        {
            NiecException.PrintMessagePro("no message", false, 50);
            return;
        }

        string str = "";
        for (int i = 0; i < messages.Length; i++)
        {
            str += messages[i] ?? (i + ": no message");
        }

        NiecException.PrintMessagePro(str, false, 50);
    }

    internal static void show_message(string message) { Sims3.UI.SimpleMessageDialog.Show("NiecMod", message ?? "no message"); }

    internal static void printfo(object obj) {
        NiecException.PrintMessagePro(obj != null ? obj.ToString() : "no message", false, 50);
    }

    internal static void wait_assert(string message) {
        NFinalizeDeath.WaitAssert(message);
    }

    internal static void assert(string message) {
        NFinalizeDeath.Assert(message);
    }

}