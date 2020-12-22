using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Sims3.NiecModList.Persistable;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.NiecRoot;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;

namespace NiecMod.Nra
{
    // Kill Mono Security ;)
    // WARNING: testing save task context! Game Crash?
    // UnverifiableCodeAttribute bug?
    public class NInjetMethed 
    {
        // no name class ;)
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public delegate void reiterueratemp(Sims3.Gameplay.Autonomy.Autonomy unused);
        public delegate void reireireterertemp(Sims3.Gameplay.Abstracts.GameObject.ResetInformation unused);
        public delegate void reirdrtyaartemp(bool unused);
        public delegate bool reryertewtytemp(Household unused);
        public delegate bool reryertewtyratemp(SimDescription unused);
        public delegate bool rytutytytrytyutemp(Sim unused, bool unused1);
        public delegate Sims3.Gameplay.Routing.RouteAction.ActionResult roiretoerotwwwetemp();
        public delegate Sim  rysesoyiroriaftemp(SimDescription simd, Vector3 pos, ResourceKey simo);
        public delegate bool rrttyutcsuyuuetemp(out string tnsKey);
        public delegate bool rryorieioefeiewtemp(Sims3.Gameplay.Interfaces.IGameObject objectToIntersect, Matrix44 testMatrix, bool bThisObjectShifted);
        public delegate void ritaiyiaututtittemp(Lot lot, bool active, ObjectGuid simRequestingService, bool bImmediate);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        /*
        
        // The x32dbg's Debugger log //
        
        DebugString: "NiecMod: --- :D Anti-AwesomeMod :D --- Exception:
        System.NullReferenceException: A null value was found where an object instance was required.
        
        #0: 0x00010 throw      in NiecMod.Nra.NiecMod.Nra.NFinalizeDeath:CallingAssemblyDebuggerDEBUG () ()
        #1: 0x00011 call       in Awesome.Awesome.Main:PostGameInitialize () ()
        #2: 0x0000f call       in Sims3.Gameplay.Sims3.Gameplay.StartupState:RunInitializers () ()
        #3: 0x00008 ret.void   in Sims3.Gameplay.Sims3.Gameplay.StartupState:Startup () ()
        #4: 0x00016 leave.s    in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:StartupCurState () ()
        #5: 0x0001a ret.void   in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:SetState (Sims3.SimIFace.StateMachineState) (36A9D660 [36AA0AA0] )
        #6: 0x0009e ldc.i4.1   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Update (single) (36AD4F60 [0] )
        #7: 0x0001b ldc.i4.0   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Simulate () ()"
        DebugString: "SException:
        System.NullReferenceException: A null value was found where an object instance was required.
        
        #0: 0x0000e throw      in Awesome.Awesome.Main:PostGameInitialize () ()
        #1: 0x0000f call       in Sims3.Gameplay.Sims3.Gameplay.StartupState:RunInitializers () ()
        #2: 0x00008 ret.void   in Sims3.Gameplay.Sims3.Gameplay.StartupState:Startup () ()
        #3: 0x00016 leave.s    in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:StartupCurState () ()
        #4: 0x0001a ret.void   in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:SetState (Sims3.SimIFace.StateMachineState) (36A9D660 [36AA0AA0] )
        #5: 0x0009e ldc.i4.1   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Update (single) (36AD4F60 [0] )
        #6: 0x0001b ldc.i4.0   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Simulate () ()"
        DebugString: "Type.GetType("NiecMod.Nra.NFinalizeDeath", false): False" // if Assembly.GetCallingAssembly()
        DebugString: "Type.GetType("Sims3.SimIFace.GameUtils", false): False" // if Assembly.GetCallingAssembly()
        DebugString: "Type.GetType("Awesome.Main", false): True" // if Assembly.GetCallingAssembly()
        
         */

        public static 
            bool ACoreMain_InjectMethed(MethodInfo a)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;
            
            var o = NFinalizeDeath.FindGetFunctionPointer("Awesome.Main", "PostGameInitialize", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null);
            var m = ((MonoMethod)o[0]);
            if (m != null)
            {
                return niec_script_func.niecmod_script_copy_ptr_func_to_func(a, m, false, true, true, false);
            }
            return false;
        }

        public static bool NMotive_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NMotive.InitClass();


            var m00 = (MonoMethod)typeof(NMotive).GetMethod("motive_motive_distress", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NMotive).GetMethod(\"motive_motive_distress\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(NMotive).GetMethod("update_motive_buffs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NMotive).GetMethod(\"update_motive_buffs\"); is null.");
                return false;
            } 
            
            ///////////

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Autonomy.Motive).GetMethod("MotiveDistress", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sim), typeof(Sims3.Gameplay.Autonomy.CommodityKind) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Motive).GetMethod(\"MotiveDistress\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)typeof(Sims3.Gameplay.Autonomy.Motive).GetMethod("UpdateMotiveBuffs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sim), typeof(Sims3.Gameplay.Autonomy.CommodityKind), typeof(int) }, null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Motive).GetMethod(\"UpdateMotiveBuffs\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NMotive_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NMotive_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            return true;
        }

        public static bool NSCGameUtils_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            object obj = null;
            if (obj != null)
            {
                GameUtils.GetCurrentWorld();
                GameUtils.GetCurrentWorldType();
            }

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<BimDesc>().game_utils_transition_to_quit();
            NJOClass.game_utils_transition_to_quit_internal();
            NJOClass.sc_gameutils_getworldname_internal();
            NJOClass.sc_gameutils_getworldtype_internal();
            NJOClass.bs_dont_call = false;

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("game_utils_transition_to_quit", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"game_utils_transition_to_quit\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(NJOClass).GetMethod("game_utils_transition_to_quit_internal", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"game_utils_transition_to_quit_internal\"); is null.");
                return false;
            }

            var m02 = (MonoMethod)typeof(NJOClass).GetMethod("sc_gameutils_getworldname_internal", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"sc_gameutils_getworldname_internal\"); is null.");
                return false;
            }

            var m03 = (MonoMethod)typeof(NJOClass).GetMethod("sc_gameutils_getworldtype_internal", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"sc_gameutils_getworldtype_internal\"); is null.");
                return false;
            }

            ///////////

            var m00_i = (MonoMethod)typeof(ScriptCore.GameUtils).GetMethod("TransitionToQuit", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.GameUtils).GetMethod(\"TransitionToQuit\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)typeof(ScriptCore.GameUtils).GetMethod("GameUtils_TransitionToQuitImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.GameUtils).GetMethod(\"GameUtils_TransitionToQuitImpl\"); is null.");
                return false;
            }
            var m02_i = (MonoMethod)typeof(ScriptCore.GameUtils).GetMethod("GameUtils_GetWorldName", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.GameUtils).GetMethod(\"GameUtils_GetWorldName\"); is null.");
                return false;
            }
            var m03_i = (MonoMethod)typeof(ScriptCore.GameUtils).GetMethod("GameUtils_GetWorldType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.GameUtils).GetMethod(\"GameUtils_GetWorldType\"); is null.");
                return false;
            }

            var mS00_i = (MonoMethod)typeof(Sims3.SimIFace.GameUtils).GetMethod("GetCurrentWorld", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (mS00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.SimIFace.GameUtils).GetMethod(\"GetCurrentWorld\"); is null.");
                return false;
            }
            var mS01_i = (MonoMethod)typeof(Sims3.SimIFace.GameUtils).GetMethod("GetCurrentWorldType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (mS01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.SimIFace.GameUtils).GetMethod(\"GetCurrentWorldType\"); is null.");
                return false;
            }


            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSCGameUtils_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSCGameUtils_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

        



            DoneInjectOuit = true;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NSCGameUtils_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                    return false;
                }
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NSCGameUtils_InjectOtherMethed: copy_ptr_func_to_func(m03, m03_i) failed.");
                    return false;
                }

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, mS00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NSCGameUtils_InjectOtherMethed: copy_ptr_func_to_func(m02, mS00_i) failed.");
                    return false;
                }

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, mS01_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NSCGameUtils_InjectOtherMethed: copy_ptr_func_to_func(m03, mS01_i) failed.");
                    return false;
                }
                DoneInjectToUserCreated = true;
            }
            return true;
        }

        public static bool NEvertTracker_InjectOtherMethed(MethodInfo myPSendEvent)
        {
            if (NiecMod.Instantiator.osdiertoeryo && myPSendEvent == null)
                return true;

            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NFinalizeDeath.aroreye = false;
            NFinalizeDeath.ETracker_SEvent_int_dgs(null);

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<niec_std>().event_tracker_process_event(null);
            NJOClass.bs_dont_call = false;

            var type = typeof(Sims3.Gameplay.EventSystem.EventTracker); //NFinalizeDeath.GetGoodType("Sims3.Gameplay.EventSystem.EventTracker", false);
            if (type == null)
            {
                NFinalizeDeath.AssertX(false, "NEvertTracker_InjectOtherMethed:\nGetGoodType(\"Sims3.Gameplay.EventSystem.EventTracker\", false) is null");
                return false;
            }

            MonoMethod m = null;

            try
            {
                var tpaev = typeof(Sims3.Gameplay.EventSystem.Event);
                try
                {
                    m = (MonoMethod)type.GetMethod(
                        "SendEvent",
                        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                        null,
                        new Type[] { tpaev },
                        null
                    );
                }
                catch (Exception ex)
                {
                    ex.trace_ips = null;
                    ex.stack_trace = null;
                    ex.message = "";
                }

                if (m == null)
                {
                    foreach (var item in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        if (item == null || !item.IsStatic)
                            continue;

                        var pa = item.GetParameters();

                        if (pa == null || pa.Length != 1)
                            continue;

                        if (item.ReturnType != tpaev)
                            continue;

                        if (pa[0].ParameterType == tpaev && item.Name.Contains("SendEvent"))
                        {
                            m = (MonoMethod)item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.trace_ips = null;
                ex.stack_trace = null;
                ex.message = "";

                NFinalizeDeath.AssertX(false, "NEvertTracker_InjectOtherMethed\nGetMethod Throw");
                return false;
            }


            if (m == null)
            {
                NFinalizeDeath.AssertX(false, "InjectEventG: M is null");
                return false;
            }

            // {

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("event_tracker_process_event", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"event_tracker_process_event\"); is null.");
                return false;
            }

            //////////////


            var m00_i = (MonoMethod)type.GetMethod("ProcessEvent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof( Sims3.Gameplay.EventSystem.Event ) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(EventTracker).GetMethod(\"ProcessEvent\"); is null.");
                return false;
            }


            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NEvertTracker_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            // }


            try
            {
                Delegate.CreateDelegate(typeof(NFinalizeDeath.XtryfrdrtyTemp), m); // Required if no create method pointer.
            }
            catch (Exception ex)
            {
                ex.trace_ips = null;
                ex.stack_trace = null;
                ex.message = "";

                NFinalizeDeath.AssertX(false, "NEvertTracker_InjectOtherMethed\nCreateDelegate(typeof(XtryfrdrtyTemp), m) Throw");
                return false;
            }

            MonoMethod myM = null;

            try
            {
                myM = myPSendEvent != null ? (MonoMethod)myPSendEvent : null;
            }
            catch (Exception)
            {
                NFinalizeDeath.AssertX(false, "NEvertTracker_InjectOtherMethed: myM = myPSendEvent != null ? (MonoMethod)myPSendEvent : null; failed.");
                return false;
            }
              

            if (myM == null)
            {
                try
                {
                    myM = (MonoMethod)typeof(NFinalizeDeath).GetMethod (
                        "ETracker_SEvent_int_dgs",
                        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
                    );
                }
                catch (Exception ex)
                {
                    ex.trace_ips = null;
                    ex.stack_trace = null;
                    ex.message = "";

                    NFinalizeDeath.AssertX(false, "NEvertTracker_InjectOtherMethed\nGetMethod(ETracker_SEvent_int_dgs) Throw");
                    return false;
                }
            }

            if (myM == null)
            {
                NFinalizeDeath.AssertX(false, "NEvertTracker_InjectOtherMethed: myM is null");
                return false;
            }

            try
            {
                Delegate.CreateDelegate(typeof(NFinalizeDeath.XtryfrdrtyTemp), myM); // Required if no create method pointer.
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func
                (
                    myM,
                    m,
                    false,
                    false,
                    true,
                    false
                )){
                    NFinalizeDeath.Assert("NEvertTracker_InjectOtherMethed: niecmod_script_copy_ptr_func_to_func(myM, m) failed.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                NFinalizeDeath.AssertX(false, "NEvertTracker_InjectOtherMethed:\n" + ex.Message);
                return false;
            }
            

            
            return true;
        }

        public static bool DoneInjectOuit = false;

        public static
           bool NSystemEx_InjectMethod()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            // Required 
            new NSystemException();
            new NSystemException("");

            new SystemException();
            new SystemException("");
            //
            new NNullReferenceException();
            new NNullReferenceException("");

            new NullReferenceException();
            new NullReferenceException("");
            //
            new NApplicationException();
            new NApplicationException("");

            new ApplicationException();
            new ApplicationException("");

            NSystemException.__IListEx.Clear();

            var m00 = (MonoCMethod)typeof(NSystemException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NSystemException)GetConstructor(); is null.");
                return false;
            }

            var m01 = (MonoCMethod)typeof(NSystemException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NSystemException)GetConstructor(str); is null.");
                return false;
            }
            //
            var m02 = (MonoCMethod)typeof(NNullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NNullReferenceException)GetConstructor(); is null.");
                return false;
            }

            var m03 = (MonoCMethod)typeof(NNullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NNullReferenceException)GetConstructor(str); is null.");
                return false;
            }

            //
            var m04 = (MonoCMethod)typeof(NApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NApplicationException)GetConstructor(); is null.");
                return false;
            }

            var m05 = (MonoCMethod)typeof(NApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m05 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NApplicationException)GetConstructor(str); is null.");
                return false;
            }
            //

            /////////////

            //
            var m00_i = (MonoCMethod)typeof(SystemException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(SystemException)GetConstructor(); is null.");
                return false;
            }

            var m01_i = (MonoCMethod)typeof(SystemException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(SystemException)GetConstructor(str); is null.");
                return false;
            }

            //
            var m02_i = (MonoCMethod)typeof(NullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NullReferenceException)GetConstructor(); is null.");
                return false;
            }

            var m03_i = (MonoCMethod)typeof(NullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NullReferenceException)GetConstructor(str); is null.");
                return false;
            }

            //
            var m04_i = (MonoCMethod)typeof(ApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m04_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(ApplicationException)GetConstructor(); is null.");
                return false;
            }

            var m05_i = (MonoCMethod)typeof(ApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m05_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(ApplicationException)GetConstructor(str); is null.");
                return false;
            }
            //

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSystemEx_InjectMethod: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSystemEx_InjectMethod: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSystemEx_InjectMethod: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSystemEx_InjectMethod: copy_ptr_func_to_func(m03, m03_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m04, m04_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSystemEx_InjectMethod: copy_ptr_func_to_func(m04, m04_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m05, m05_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSystemEx_InjectMethod: copy_ptr_func_to_func(m05, m05_i) failed.");
                return false;
            }

            try
            {
                throw new SystemException();
            }
            catch (Exception)
            {
                if (NSystemException.__IListEx == null || NSystemException.__IListEx.Count == 0)
                {
                    NFinalizeDeath.Assert("NSystemException.__IListEx == null || NSystemException.__IListEx.Count == 0");
                    return false;
                }
                NSystemException.__IListEx.Clear();
            }

            return true;
        }

        public static bool DoneNROUTECarOrBoat_InjectMethod = false;

        public static
            bool NROUTECarOrBoat_InjectMethod()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NGetInBoatRouteAction.InitClass();
            NGetInVehicleRouteAction.InitClass();

            var m00 = (MonoMethod)typeof(NGetInBoatRouteAction).GetMethod
                ("NM_PerformAction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGetInBoatRouteAction).GetMethod(\"NM_PerformAction\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(NGetInVehicleRouteAction).GetMethod
                ("NM_PerformAction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGetInVehicleRouteAction).GetMethod(\"NM_PerformAction\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Routing.GetInBoatRouteAction).GetMethod
                ("PerformAction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);

            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(GetInBoatRouteAction).GetMethod(\"PerformAction\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)typeof(Sims3.Gameplay.Routing.GetInVehicleRouteAction).GetMethod
                ("PerformAction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);

            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(GetInVehicleRouteAction).GetMethod(\"PerformAction\"); is null.");
                return false;
            }

            // Required if no create method pointer.
            //Delegate.CreateDelegate(typeof(roiretoerotwwwetemp), new Sims3.Gameplay.Routing.GetInBoatRouteAction(),    m00_i);
            //Delegate.CreateDelegate(typeof(roiretoerotwwwetemp), new Sims3.Gameplay.Routing.GetInVehicleRouteAction(), m01_i);

            niec_script_func.niecmod_scipt_pre_ptr_obj_create_method2<Sims3.Gameplay.Routing.GetInBoatRouteAction, roiretoerotwwwetemp>(m00_i);
            niec_script_func.niecmod_scipt_pre_ptr_obj_create_method2<Sims3.Gameplay.Routing.GetInVehicleRouteAction, roiretoerotwwwetemp>(m01_i);

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NROUTECarOrBoat_InjectMethod: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NROUTECarOrBoat_InjectMethod: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }
            DoneNROUTECarOrBoat_InjectMethod = true;
            return true;
        }

        public static
            bool NPieMenu_InjectMethod()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            Sims3.Gameplay.UI.PieMenu.HidePieMenuSimHead = true;
            NJOClass.PM_CreateSimHead();
            Sims3.Gameplay.UI.PieMenu.HidePieMenuSimHead = false;

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("PM_CreateSimHead", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"PM_CreateSimHead\"); is null.");
                return false;
            }
            /////////
            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.UI.PieMenu).GetMethod("CreateSimHead", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(PieMenu).GetMethod(\"CreateSimHead\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NPieMenu_InjectMethod: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }
            return true;
        }

        public static
            bool NResortServiceAll_InjectMethod()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NJOClass.bs_dont_call = true;
            NJOClass.ResortWorker_ValidateWorkers();
            NJOClass.ResortWorkerBar_ValidateWorkers();
            NJOClass.bs_dont_call = false;

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("ResortWorker_ValidateWorkers", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"ResortWorker_ValidateWorkers\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(NJOClass).GetMethod("ResortWorkerBar_ValidateWorkers", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"ResortWorkerBar_ValidateWorkers\"); is null.");
                return false;
            }

            ///////////

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Services.ResortWorker).GetMethod("ValidateWorkers", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResortWorker).GetMethod(\"ValidateWorkers\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)typeof(Sims3.Gameplay.Services.ResortWorkerBar).GetMethod("ValidateWorkers", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResortWorkerBar).GetMethod(\"ValidateWorkers\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NResortServiceAll_InjectMethod: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NResortServiceAll_InjectMethod: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            return true;
        }

        public static
            bool NSMCClass_InjectMethod()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NSC_ETRAP>().smc_check_for_exception();
            NJOClass.get_instance<NSC_ETRAP>().smc_requset_state(false, null, null, Sims3.SimIFace.SACS.DriverRequestFlags.kNone, -2223, null, null, null);
            NJOClass.smc_acquire(default(ObjectGuid), null, AnimationPriority.kAPUnset, false);
            NJOClass.bs_dont_call = false;

            StateMachineClient smc = null;
            if (smc != null)
            {
                smc.CheckForException();
                smc.RequestState(false, null, null, Sims3.SimIFace.SACS.DriverRequestFlags.kNone, -2223, null, null, null);
                StateMachineClient.Acquire(default(ObjectGuid), null, AnimationPriority.kAPUnset, false);
            }

            var m00 = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(NJOClass), null, "smc_check_for_exception", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"smc_check_for_exception\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(NJOClass), new Type[] { typeof(bool), typeof(string), typeof(string), typeof(Sims3.SimIFace.SACS.DriverRequestFlags), typeof(int), typeof(StateMachineClient), typeof(string), typeof(BridgeOrigin) }, "smc_requset_state", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"smc_requset_state\"); is null.");
                return false;
            }
            var m02 = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(NJOClass), new Type[] { typeof(ObjectGuid), typeof(string), typeof(AnimationPriority), typeof(bool) }, "smc_acquire", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"smc_acquire\"); is null.");
                return false;
            }
            ////

            var v00_i = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(StateMachineClient), null, "CheckForException", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (v00_i == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)typeof(StateMachineClient).GetMethod(\"CheckForException\"); is null.");
                return false;
            }
            var v01_i = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(StateMachineClient), new Type[] { typeof(bool), typeof(string), typeof(string), typeof(Sims3.SimIFace.SACS.DriverRequestFlags), typeof(int), typeof(StateMachineClient), typeof(string), typeof(BridgeOrigin) }, "RequestState", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (v01_i == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)typeof(StateMachineClient).GetMethod(\"RequestState\"); is null.");
                return false;
            }
            var v02_i = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(StateMachineClient), new Type[] { typeof(ObjectGuid), typeof(string), typeof(AnimationPriority), typeof(bool) }, "Acquire", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (v02_i == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)typeof(StateMachineClient).GetMethod(\"Acquire\"); is null.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, v00_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSMCClass_InjectMethod: copy_ptr_func_to_func(m00, v00_i) failed.");
                return false;
            }

            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, v01_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSMCClass_InjectMethod: copy_ptr_func_to_func(m01, v01_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, v02_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSMCClass_InjectMethod: copy_ptr_func_to_func(m02, v02_i) failed.");
                return false;
            }
            NJOClass.smc_InjectIsDone = true;
            Sims3.NiecHelp.Tasks.NiecTask.Perform(NFinalizeDeath.LoopSMCI);
            return true;
        }

        public static
            bool NOtherClass_InjectMethod()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            // IdleManger Class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<niec_std>().idle_manager_should_schedule_Idles(Sims3.Gameplay.ActorSystems.IdleAnimationPriority.Undefined, null);
            NJOClass.bs_dont_call = false;

            var vIMm00 = (MonoMethod)typeof(NJOClass).GetMethod("idle_manager_should_schedule_Idles", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vIMm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"idle_manager_should_schedule_Idles\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vIMm00_i = (MonoMethod)typeof(Sims3.Gameplay.ActorSystems.IdleManager).GetMethod("ShouldScheduleIdles", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.ActorSystems.IdleAnimationPriority), typeof(Sims3.Gameplay.ActorSystems.BuffInstance) }, null);
            if (vIMm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(IdleManager).GetMethod(\"ShouldScheduleIdles\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vIMm00, vIMm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vIMm00, vIMm00_i) failed.");
                return false;
            }

            // InteractionQueue Class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<niec_std>().iq_put_down_carried_objects(null);
            NJOClass.bs_dont_call = false;


            var vIQm00 = (MonoMethod)typeof(NJOClass).GetMethod("iq_put_down_carried_objects", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vIQm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"iq_put_down_carried_objects\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vIQm00_i = (MonoMethod)typeof(Sims3.Gameplay.ActorSystems.InteractionQueue).GetMethod("PutDownCarriedObjects", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.Interactions.InteractionInstance) }, null);
            if (vIQm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(InteractionQueue).GetMethod(\"PutDownCarriedObjects\"); is null.");
                return false;
            }

            if (NiecHelperSituation.__acorewIsnstalled__ && !NFinalizeDeath.IsOpenDGSInstalled)
            {
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vIQm00, vIQm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vIQm00, vIQm00_i) failed.");
                    return false;
                }
            }

            // TaskControl Class

            uint unused = 0;
            NJOClass.bs_dont_call = true;
            NJOClass.get_method_checksum(new RuntimeMethodHandle(new IntPtr(0)), out unused);
            NJOClass.bs_dont_call = false;


            var vTCm00 = (MonoMethod)typeof(NJOClass).GetMethod("get_method_checksum", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vTCm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"idle_manager_should_schedule_Idles\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vTCm00_i = (MonoMethod)typeof(ScriptCore.TaskControl).GetMethod("GetMethodChecksum", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vTCm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.TaskControl).GetMethod(\"GetMethodChecksum\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vTCm00, vTCm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vTCm00, vTCm00_i) failed.");
                return false;
            }

            // IEditTownModel and PlayFlowModel class

            NJOClass.pt = true;
            NFinalizeDeath.M(NJOClass.get_instance<ObfuscateAssemblyAttribute>().IEditTownModel_ValidActiveHousehold);
            NJOClass.get_instance<ObfuscateAssemblyAttribute>().IEditTownModel_IsValidActiveHouseholdAtHome();
            NFinalizeDeath.M(NJOClass.get_instance<ObfuscateAssemblyAttribute>().PlayFlowModel_GameEntryLive);
            NJOClass.pt = false;

            // IEditTownModel

            var vVETMPFm00 = (MonoMethod)typeof(NJOClass).GetMethod("get_IEditTownModel_ValidActiveHousehold", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vVETMPFm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"get_IEditTownModel_ValidActiveHousehold\"); is null.");
                return false;
            }

            var vVETMPFm01 = (MonoMethod)typeof(NJOClass).GetMethod("IEditTownModel_IsValidActiveHouseholdAtHome", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vVETMPFm01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"IEditTownModel_IsValidActiveHouseholdAtHome\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vVETMPFm00_i = (MonoMethod)typeof(Sims3.Gameplay.EditTownModel).GetMethod("get_ValidActiveHousehold", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vVETMPFm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(EditTownModel).GetMethod(\"get_ValidActiveHousehold\"); is null.");
                return false;
            }

            var vVETMPFm01_i = (MonoMethod)typeof(Sims3.Gameplay.EditTownModel).GetMethod("IsValidActiveHouseholdAtHome", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vVETMPFm01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(EditTownModel).GetMethod(\"IsValidActiveHouseholdAtHome\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vVETMPFm00, vVETMPFm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vVETMPFm00, vVETMPFm00_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vVETMPFm01, vVETMPFm01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vVETMPFm00, vVETMPFm00_i) failed.");
                return false;
            }

            // PlayFlowModel

            var vVETMPFMm00 = (MonoMethod)typeof(NJOClass).GetMethod("get_PlayFlowModel_GameEntryLive", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vVETMPFMm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"get_PlayFlowModel_GameEntryLive\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vVETMPFMm00_i = (MonoMethod)typeof(Sims3.Gameplay.PlayFlowModel).GetMethod("get_GameEntryLive", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vVETMPFMm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(PlayFlowModel).GetMethod(\"get_GameEntryLive\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vVETMPFMm00, vVETMPFMm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vVETMPFMm00, vVETMPFMm00_i) failed.");
                return false;
            }

            // RoutingComponent class

            NJOClass.bs_dont_call = true;
            NJOClass.routing_component_push_sims_static(null, null, 0, 0, false, false, default(Sims3.Gameplay.Interactions.InteractionPriority), false);
            NJOClass.bs_dont_call = false;

            var vRCm00 = (MonoMethod)typeof(NJOClass).GetMethod("routing_component_push_sims_static", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vRCm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"routing_component_push_sims_static\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vRCm00_i = (MonoMethod)typeof(Sims3.Gameplay.ObjectComponents.RoutingComponent).GetMethod("PushSimsStatic", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sim), typeof(List<Sim>), typeof(float), typeof(float), typeof(bool), typeof(bool), typeof(Sims3.Gameplay.Interactions.InteractionPriority), typeof(bool) }, null);
            if (vRCm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(RoutingComponent).GetMethod(\"PushSimsStatic\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vRCm00, vRCm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vRCm00, vRCm00_i) failed.");
                return false;
            }

            // SwimmingInPool Class

            NJOClass.SwimmingInPool_SelfInteractionCanHappenInPool(null);

            var vSIPm00 = (MonoMethod)typeof(NJOClass).GetMethod("SwimmingInPool_SelfInteractionCanHappenInPool", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vSIPm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"SwimmingInPool_SelfInteractionCanHappenInPool\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vSIPm00_i = (MonoMethod)typeof(Sims3.Gameplay.Pools.SwimmingInPool).GetMethod("SelfInteractionCanHappenInPool", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.Interactions.InteractionInstance) }, null);
            if (vSIPm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SwimmingInPool).GetMethod(\"SelfInteractionCanHappenInPool\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSIPm00, vSIPm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSIPm00, vSIPm00_i) failed.");
                return false;
            }

            // ScubaDiving Class

            NJOClass.ScubaDiving_SelfInteractionCanHappenWhileDiving(null);

            var vSDm00 = (MonoMethod)typeof(NJOClass).GetMethod("ScubaDiving_SelfInteractionCanHappenWhileDiving", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vSDm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"ScubaDiving_SelfInteractionCanHappenWhileDiving\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vSDm00_i = (MonoMethod)typeof(Sims3.Gameplay.Scuba.ScubaDiving).GetMethod("SelfInteractionCanHappenWhileDiving", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.Interactions.InteractionInstance) }, null);
            if (vSDm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScubaDiving).GetMethod(\"SelfInteractionCanHappenWhileDiving\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSDm00, vSDm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSDm00, vSDm00_i) failed.");
                return false;
            }

            // Photography Class

            NJOClass.bs_dont_call = true;
            NJOClass.nOnTriggerTakePhotograph();
            NJOClass.bs_dont_call = false;

            var vPGYm00 = (MonoMethod)typeof(NJOClass).GetMethod("nOnTriggerTakePhotograph", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vPGYm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"nOnTriggerTakePhotograph\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vPGYm00_i = (MonoMethod)typeof(Sims3.Gameplay.Skills.Photography).GetMethod("OnTriggerTakePhotograph", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (vPGYm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Photography).GetMethod(\"OnTriggerTakePhotograph\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vPGYm00, vPGYm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vPGYm00, vPGYm00_i) failed.");
                return false;
            }

            // Notification Class

            NJOClass.get_instance<Sim>().notification_Add(null, Sims3.UI.NotificationManager.TNSCategory.Unknown);

            var vNONm00 = (MonoMethod)typeof(NJOClass).GetMethod("notification_Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vNONm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"notification_Add\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var vNONm00_i = (MonoMethod)typeof(Sims3.UI.NotificationManager).GetMethod("Add", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vNONm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NotificationManager).GetMethod(\"Add\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vNONm00, vNONm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vNONm00, vNONm00_i) failed.");
                return false;
            }

            // LotManger Class

            object objlm = null;
            if (objlm != null)
            {
                objlm.GetHashCode();
                NFinalizeDeath.M(LotManager.AllLots);
            }

            NJOClass.bs_dont_call = true;
            NFinalizeDeath.M(NJOClass.LotManger_AllLots);
            NJOClass.bs_dont_call = false;

            var vLMm00 = (MonoMethod)typeof(NJOClass).GetMethod("get_LotManger_AllLots", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vLMm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"get_LotManger_AllLots\"); is null.");
                return false;
            }

            var vLMm00_i = (MonoMethod)typeof(LotManager).GetMethod("get_AllLots", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vLMm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(LotManager).GetMethod(\"get_AllLots\"); is null.");
                return false;
            }

            if (NiecHelperSituation.__acorewIsnstalled__ && NiecHelperSituation.isdgmods)
            {
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vLMm00, vLMm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vLMm00, vLMm00_i) failed.");
                    return false;
                }
            }

            if (NiecMod.KillNiec.AssemblyCheckByNiec.IsInstalled("Oniki_KinkyMod") || NFinalizeDeath.GetGoodType("Oniki.Services.Police", false) != null)
            {
                // Oniki.Services.Police class

                NFinalizeDeath.ETMY();

                var vOSPm00 = (MonoMethod)typeof(NFinalizeDeath).GetMethod("ETMY", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vOSPm00 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NFinalizeDeath).GetMethod(\"ETMY\"); is null.");
                    return false;
                }
                ////
                var vOSPm00_i = (MonoMethod)NFinalizeDeath.GetGoodType("Oniki.Services.Police", true).GetMethod("ProtectTheInnocent", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vOSPm00_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(Oniki.Services.Police).GetMethod(\"ProtectTheInnocent\"); is null.");
                    return false;
                }

                Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), vOSPm00_i); // Required if no create method pointer.

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vOSPm00, vOSPm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vOSPm00, vOSPm00_i) failed.");
                    return false;
                }

                // Oniki.Utilities.SimTools class

                NJOClass.OIT_InvSIM(null, default(Vector3), default(ResourceKey));

                var vOUSTm00 = (MonoMethod)typeof(NJOClass).GetMethod("OIT_InvSIM", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vOUSTm00 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"OIT_InvSIM\"); is null.");
                    return false;
                }
                ////
                var vOUSTm00_i = (MonoMethod)NFinalizeDeath.GetGoodMethods(NFinalizeDeath.GetGoodType("Oniki.Utilities.SimTools", true), new Type[] { typeof(Sims3.Gameplay.CAS.SimDescription), typeof(Sims3.SimIFace.Vector3), typeof(Sims3.SimIFace.ResourceKey) }, "Instantiate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vOUSTm00_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(Oniki.Utilities.SimTools).GetMethod(\"Instantiate\"); is null.");
                    return false;
                }

                Delegate.CreateDelegate(typeof(rysesoyiroriaftemp), vOUSTm00_i); // Required if no create method pointer.

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vOUSTm00, vOUSTm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vOUSTm00, vOUSTm00_i) failed.");
                    return false;
                }
            }

            // HudModel class

            nobjecoD.Home.boolTrue();

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NHousehold>().HudModel_LoadingScreenDisposed();
            NJOClass.bs_dont_call = false;

            var vHUDMm00 = (MonoMethod)typeof(nobjecoD).GetMethod("boolTrue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vHUDMm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(nobjecoD).GetMethod(\"boolTrue\"); is null.");
                return false;
            }
            var vHUDMm01 = (MonoMethod)typeof(NJOClass).GetMethod("HudModel_LoadingScreenDisposed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vHUDMm01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"HudModel_LoadingScreenDisposed\"); is null.");
                return false;
            }
            ////
            var vHUDMm00_i = (MonoMethod)typeof(Sims3.Gameplay.UI.HudModel).GetMethod("IsInteractionCancellableByPlayer", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vHUDMm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(HudModel).GetMethod(\"IsInteractionCancellableByPlayer\"); is null.");
                return false;
            }
            var vHUDMm01_i = (MonoMethod)typeof(Sims3.Gameplay.UI.HudModel).GetMethod("LoadingScreenDisposed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vHUDMm01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(HudModel).GetMethod(\"LoadingScreenDisposed\"); is null.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vHUDMm00, vHUDMm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vHUDMm00, vHUDMm00_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vHUDMm01, vHUDMm01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vHUDMm01, vHUDMm01_i) failed.");
                return false;
            }
            // TaskStateCollection class 
            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                NJOClass.get_instance<Task>().TSC_WriteTask(null, null, 0);

                object obj = null;
                if (obj != null)
                {
                    ((ScriptCore.TaskStateCollection)obj).WriteTask(null, null, 0);
                }

                var vTASKSCm00 = (MonoMethod)typeof(NJOClass).GetMethod("TSC_WriteTask", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (vTASKSCm00 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"TSC_WriteTask\"); is null.");
                    return false;
                }
                ////
                var vTASKSCm00_i = (MonoMethod)typeof(ScriptCore.TaskStateCollection).GetMethod("WriteTask", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (vTASKSCm00_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.TaskStateCollection).GetMethod(\"WriteTask\"); is null.");
                    return false;
                }

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vTASKSCm00, vTASKSCm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vTASKSCm00, vTASKSCm00_i) failed.");
                    return false;
                }
            }

            // Camera Class
            Vector3 ov = new Vector3(0,0,0);
            NJOClass.get_instance<Null>().camera_get_closest_visible_lot(null, ref ov);

            Camera cameraTask = null;
            if (cameraTask != null)
            {
                cameraTask.GetClosestVisibleLot(null, ref ov);
            }

            var vCAm00 = (MonoMethod)typeof(NJOClass).GetMethod("camera_get_closest_visible_lot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vCAm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"camera_get_closest_visible_lot\"); is null.");
                return false;
            }

            /////////////////////////////

            var vCAm00_i = (MonoMethod)typeof(Camera).GetMethod("GetClosestVisibleLot", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vCAm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Camera).GetMethod(\"GetClosestVisibleLot\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vCAm00, vCAm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vCAm00, vCAm00_i) failed.");
                return false;
            }

            // Service Class
            bool unused0b;
            NJOClass.Service_CreateSimDescriptionInternal(null, null, (CASAgeGenderFlags)0x5442022, CASAgeGenderFlags.None, WorldName.Undefined, out unused0b);

            object objse = null;
            if (objse != null)
            {
                objse = objse.GetHashCode();
                Sims3.Gameplay.Services.Service.CreateSimDescriptionInternal(null, null, (CASAgeGenderFlags)0x5442022, CASAgeGenderFlags.None, WorldName.Undefined, out unused0b);
            }

            var vSEVm00 = (MonoMethod)typeof(NJOClass).GetMethod("Service_CreateSimDescriptionInternal", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vSEVm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"Service_CreateSimDescriptionInternal\"); is null.");
                return false;
            }

            var vSEVm00_i = (MonoMethod)typeof(Sims3.Gameplay.Services.Service).GetMethod("CreateSimDescriptionInternal", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vSEVm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Service).GetMethod(\"CreateSimDescriptionInternal\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSEVm00, vSEVm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSEVm00, vSEVm00_i) failed.");
                return false;
            }

            // ScriptCore World Class
            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                NJOClass.World_GetWorldNameFile();
                NJOClass.World_GetWorldNameKey();

                object objWorld = null;
                if (objWorld != null)
                {
                    ScriptCore.World.World_GetWorldFileName();
                    ScriptCore.World.World_GetWorldNameKey();
                    World.GetWorldFileName();
                    World.GetWorldNameKey();
                }

                var vSCWOm00 = (MonoMethod)typeof(NJOClass).GetMethod("World_GetWorldNameFile", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vSCWOm00 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"World_GetWorldNameFile\"); is null.");
                    return false;
                }
                var vSCWOm01 = (MonoMethod)typeof(NJOClass).GetMethod("World_GetWorldNameKey", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vSCWOm01 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"World_GetWorldNameKey\"); is null.");
                    return false;
                }

                var vSCWOm00_i = (MonoMethod)typeof(ScriptCore.World).GetMethod("World_GetWorldFileName", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vSCWOm00_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.World).GetMethod(\"World_GetWorldFileName\"); is null.");
                    return false;
                }
                var vSCWOm01_i = (MonoMethod)typeof(ScriptCore.World).GetMethod("World_GetWorldNameKey", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vSCWOm01_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.World).GetMethod(\"World_GetWorldNameKey\"); is null.");
                    return false;
                }

                var vSIF3WOm00_i = (MonoMethod)typeof(Sims3.SimIFace.World).GetMethod("GetWorldFileName", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vSIF3WOm00_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.SimIFace.World).GetMethod(\"GetWorldFileName\"); is null.");
                    return false;
                }
                var vSIF3WOm01_i = (MonoMethod)typeof(Sims3.SimIFace.World).GetMethod("GetWorldNameKey", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vSIF3WOm01_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.SimIFace.World).GetMethod(\"GetWorldNameKey\"); is null.");
                    return false;
                }

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSCWOm00, vSCWOm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSCWOm00, vSCWOm00_i) failed.");
                    return false;
                }
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSCWOm01, vSCWOm01_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSCWOm01, vSCWOm01_i) failed.");
                    return false;
                }

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSCWOm00, vSIF3WOm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSCWOm00, vSIF3WOm00_i) failed.");
                    return false;
                }
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSCWOm01, vSIF3WOm01_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSCWOm01, vSIF3WOm01_i) failed.");
                    return false;
                }
                DoneInjectToUserCreated = true;
            }

            // DeviceConfig class
#if !GameVersion_0_Release_2_0_32 && !S3_Steam_Version
            NJOClass.DeviceConfig_AuthenticateDisc();
            ScriptCore.DeviceConfig.DeviceConfig_AuthenticateDisc();
            var vDCMm00 = (MonoMethod)typeof(NJOClass).GetMethod("DeviceConfig_AuthenticateDisc", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vDCMm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"DeviceConfig_AuthenticateDisc\"); is null.");
                return false;
            }
            ////
            var vDCMm00_i = (MonoMethod)typeof(ScriptCore.DeviceConfig).GetMethod("DeviceConfig_AuthenticateDisc", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vDCMm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.DeviceConfig).GetMethod(\"DeviceConfig_AuthenticateDisc\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vDCMm00, vDCMm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vDCMm00, vDCMm00_i) failed.");
                return false;
            }
#endif 

            // UIManager class

            NJOClass.UI_AddTriggerHook(null, null, (Sims3.UI.TriggerActivationMode)0x5FE00000, 0, false);
            bool utttt = false;
            NJOClass.UIManager_ProcessEventCallback(0, 0, 0, 0, 0x7FFFFAAA, 0, 0, 0, 0, 0, 0, ref utttt, null);

            object uiobj = null;
            if (uiobj != null)
            {
                Sims3.UI.UIManager.AddTriggerHook(null, null, 0, 0, false);
                Sims3.UI.UIManager.ProcessEventCallback(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ref utttt, null);
            }

            var vUIMm00 = (MonoMethod)typeof(NJOClass).GetMethod("UI_AddTriggerHook", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vUIMm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"UI_AddTriggerHook\"); is null.");
                return false;
            }
            var vUIMm01 = (MonoMethod)typeof(NJOClass).GetMethod("UIManager_ProcessEventCallback", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vUIMm01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"UIManager_ProcessEventCallback\"); is null.");
                return false;
            }
            ////
            var vUIMm00_i = (MonoMethod)typeof(Sims3.UI.UIManager).GetMethod("AddTriggerHook", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vUIMm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.UI.UIManager).GetMethod(\"AddTriggerHook\"); is null.");
                return false;
            }
            var vUIMm01_i = (MonoMethod)typeof(Sims3.UI.UIManager).GetMethod("ProcessEventCallback", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vUIMm01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.UI.UIManager).GetMethod(\"ProcessEventCallback\"); is null.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vUIMm00, vUIMm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vUIMm00, vUIMm00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vUIMm01, vUIMm01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vUIMm01, vUIMm01_i) failed.");
                return false;
            }


            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                // InWorldSubState class
                string ustr = null;
                NJOClass.InWorldSubState_IsBuildBuyValid(null, ref ustr, false);
                NJOClass.InWorldSubState_IsEditTownValid(null, ref ustr);

                if (ustr != null)
                {
                    Sims3.Gameplay.InWorldSubState.IsBuildBuyValid(null, ref ustr, false);
                    Sims3.Gameplay.InWorldSubState.IsEditTownValid(null, ref ustr);
                }

                var vIWSSMm00 = (MonoMethod)typeof(NJOClass).GetMethod("InWorldSubState_IsBuildBuyValid", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vIWSSMm00 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"InWorldSubState_IsBuildBuyValid\"); is null.");
                    return false;
                }

                var vIWSSMm01 = (MonoMethod)typeof(NJOClass).GetMethod("InWorldSubState_IsEditTownValid", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vIWSSMm01 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"InWorldSubState_IsEditTownValid\"); is null.");
                    return false;
                }
                ////
                var vIWSSMm00_i = (MonoMethod)typeof(Sims3.Gameplay.InWorldSubState).GetMethod("IsBuildBuyValid", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vIWSSMm00_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.Gameplay.InWorldSubState).GetMethod(\"IsBuildBuyValid\"); is null.");
                    return false;
                }
                var vIWSSMm01_i = (MonoMethod)typeof(Sims3.Gameplay.InWorldSubState).GetMethod("IsEditTownValid", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (vIWSSMm01_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.Gameplay.InWorldSubState).GetMethod(\"IsEditTownValid\"); is null.");
                    return false;
                }

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vIWSSMm00, vIWSSMm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vIWSSMm00, vIWSSMm00_i) failed.");
                    return false;
                }
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vIWSSMm01, vIWSSMm01_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vIWSSMm01, vIWSSMm01_i) failed.");
                    return false;
                }
            }

            // CaregiverRoutingMonitor class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<Array>().CaregiverRoutingMonitor_AlarmCallback();
            NJOClass.bs_dont_call = false;

            Sims3.Gameplay.ActorSystems.Children.CaregiverRoutingMonitor crmobj = null;
            if (crmobj != null)
            {
                crmobj.AlarmCallback();
            }

            var vCRMMm00 = (MonoMethod)typeof(NJOClass).GetMethod("CaregiverRoutingMonitor_AlarmCallback", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vCRMMm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"CaregiverRoutingMonitor_AlarmCallback\"); is null.");
                return false;
            }
            ////
            var vCRMMm00_i = (MonoMethod)typeof(Sims3.Gameplay.ActorSystems.Children.CaregiverRoutingMonitor).GetMethod("AlarmCallback", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vCRMMm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(CaregiverRoutingMonitor).GetMethod(\"AlarmCallback\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vCRMMm00, vCRMMm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vCRMMm00, vCRMMm00_i) failed.");
                return false;
            }

            DoneInjectCaregiverRoutingMonitor = true;

            // AlienUtils and PetPoolManager class

            NJOClass.EmptyAlarmCallBack();

            object objvAPMU = null;
            if (objvAPMU != null)
            {
                Sims3.Gameplay.ActorSystems.AlienUtils.AlienRefreshCallBack();
                Sims3.Gameplay.PetSystems.PetPoolManager.AlarmCallBack();
            }

            var vAPMUm00 = (MonoMethod)typeof(NJOClass).GetMethod("EmptyAlarmCallBack", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vAPMUm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"EmptyAlarmCallBack\"); is null.");
                return false;
            }

            var vAPMUm00_i = (MonoMethod)typeof(Sims3.Gameplay.ActorSystems.AlienUtils).GetMethod("AlienRefreshCallBack", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vAPMUm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(AlienUtils).GetMethod(\"AlienRefreshCallBack\"); is null.");
                return false;
            }
            var vAPMUm01_i = (MonoMethod)typeof(Sims3.Gameplay.PetSystems.PetPoolManager).GetMethod("AlarmCallBack", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vAPMUm01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(PetPoolManager).GetMethod(\"AlarmCallBack\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vAPMUm00, vAPMUm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vAPMUm00, vAPMUm00_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vAPMUm00, vAPMUm01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vAPMUm00, vAPMUm01_i) failed.");
                return false;
            }

            // Gameflow class
            //if (Gameflow.sSingleton != null)
            {
                string gfstr;
                NJOClass.get_instance<NMAntiSpyException>().Gameflow_IsSaveDisabled(out gfstr);

                var vS3GFm00 = (MonoMethod)typeof(NJOClass).GetMethod("Gameflow_IsSaveDisabled", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (vS3GFm00 == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"Gameflow_IsSaveDisabled\"); is null.");
                    return false;
                }
                ////
                var vS3GFm00_i = (MonoMethod)typeof(Sims3.Gameplay.Gameflow).GetMethod("IsSaveDisabled", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (vS3GFm00_i == null)
                {
                    NFinalizeDeath.Assert("(MonoMethod)typeof(Gameflow).GetMethod(\"IsSaveDisabled\"); is null.");
                    return false;
                }

                // Required if no create method pointer.
                //Delegate.CreateDelegate(typeof(rrttyutcsuyuuetemp), Gameflow.sSingleton, vS3GFm00_i);
                niec_script_func.niecmod_scipt_pre_ptr_obj_create_method2<Sims3.Gameplay.Gameflow, rrttyutcsuyuuetemp>(vS3GFm00_i);

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vS3GFm00, vS3GFm00_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vS3GFm00, vS3GFm00_i) failed.");
                    return false;
                }
            }

            // FirefighterEmergencySituation class

            NJOClass.FirefighterEmergencySituation_FindInvolvingSim(null);

            object vFESObj = null;
            if (vFESObj != null)
            {
                Sims3.Gameplay.Situations.FirefighterEmergencySituation.FindFirefighterEmergencySituationInvolvingSim(null);
            }
            
            var vFESm00 = (MonoMethod)typeof(NJOClass).GetMethod("FirefighterEmergencySituation_FindInvolvingSim", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vFESm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"FirefighterEmergencySituation_FindInvolvingSim\"); is null.");
                return false;
            }
            ////
            var vFESm00_i = (MonoMethod)typeof(Sims3.Gameplay.Situations.FirefighterEmergencySituation).GetMethod("FindFirefighterEmergencySituationInvolvingSim", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vFESm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(FirefighterEmergencySituation).GetMethod(\"FindFirefighterEmergencySituationInvolvingSim\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vFESm00, vFESm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vFESm00, vFESm00_i) failed.");
                return false;
            }

            // GameStates class

            NJOClass.bs_dont_call = true;
            NJOClass.GameStates_ClearStaticsOnReturnToMainMenu();
            NJOClass.bs_dont_call = false;

            object vGSSTObj = null;
            if (vGSSTObj != null)
            {
                Sims3.Gameplay.GameStates.ClearStaticsOnReturnToMainMenu();
            }

            var vGSSTObjm00 = (MonoMethod)typeof(NJOClass).GetMethod("GameStates_ClearStaticsOnReturnToMainMenu", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vGSSTObjm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"GameStates_ClearStaticsOnReturnToMainMenu\"); is null.");
                return false;
            }
            ////
            var vGSSTObjm00_i = (MonoMethod)typeof(Sims3.Gameplay.GameStates).GetMethod("ClearStaticsOnReturnToMainMenu", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vGSSTObjm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.Gameplay.GameStates).GetMethod(\"ClearStaticsOnReturnToMainMenu\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vGSSTObjm00, vGSSTObjm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vGSSTObjm00, vGSSTObjm00_i) failed.");
                return false;
            }

            // InWorldState class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NMotive>().InWorldState_GotoSubState(Sims3.Gameplay.InWorldState.SubState.None);
            NJOClass.bs_dont_call = false;

            Sims3.Gameplay.InWorldState vIWSObj = null;
            if (vIWSObj != null)
            {
                vIWSObj.GotoSubState(Sims3.Gameplay.InWorldState.SubState.None);
            }

            var vIWSm00 = (MonoMethod)typeof(NJOClass).GetMethod("InWorldState_GotoSubState", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vIWSm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"InWorldState_GotoSubState\"); is null.");
                return false;
            }
            ////
            var vIWSm00_i = (MonoMethod)typeof(Sims3.Gameplay.InWorldState).GetMethod("GotoSubState", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vIWSm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.Gameplay.InWorldState).GetMethod(\"GotoSubState\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vIWSm00, vIWSm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vIWSm00, vIWSm00_i) failed.");
                return false;
            }

            // TraitListener class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NNullReferenceException>().TraitListener_OnEvilRespondingToMisfortune(null);
            NJOClass.bs_dont_call = false;

            Sims3.Gameplay.Socializing.TraitListener vTLObj = null;
            if (vTLObj != null)
            {
                vTLObj.OnEvilRespondingToMisfortune(null);
            }

            var vTLObjm00 = (MonoMethod)typeof(NJOClass).GetMethod("TraitListener_OnEvilRespondingToMisfortune", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vTLObjm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"TraitListener_OnEvilRespondingToMisfortune\"); is null.");
                return false;
            }
            ////
            var vTLObjm00_i = (MonoMethod)typeof(Sims3.Gameplay.Socializing.TraitListener).GetMethod("OnEvilRespondingToMisfortune", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vTLObjm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.Gameplay.Socializing.TraitListener).GetMethod(\"OnEvilRespondingToMisfortune\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vTLObjm00, vTLObjm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vTLObjm00, vTLObjm00_i) failed.");
                return false;
            }

            // Simulator class
            uint sunSimulator = 0;

            NJOClass.Simulator_AppendToFileImpl(0, null);
            NJOClass.Simulator_CloseScriptErrorFileImpl(0);
            NJOClass.Simulator_CreateExportFileImpl(ref sunSimulator, null);
            NJOClass.Simulator_CreateScriptErrorFileImpl(ref sunSimulator);

            NJOClass.ErrorFileHandles = new Dictionary<uint, IntPtr>();

            object objSimulator = null;
            if (objSimulator != null)
            {
                ScriptCore.Simulator.Simulator_AppendToScriptErrorFileImpl(0, null);
                ScriptCore.Simulator.Simulator_CloseScriptErrorFileImpl(0);
                ScriptCore.Simulator.Simulator_CreateExportFileImpl(ref sunSimulator, null);
                ScriptCore.Simulator.Simulator_CreateScriptErrorFileImpl(ref sunSimulator);
            }

            var vsunSm00 = (MonoMethod)typeof(NJOClass).GetMethod("Simulator_AppendToFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"Simulator_AppendToFileImpl\"); is null.");
                return false;
            }
            var vsunSm01 = (MonoMethod)typeof(NJOClass).GetMethod("Simulator_CloseScriptErrorFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"Simulator_CloseScriptErrorFileImpl\"); is null.");
                return false;
            }
            var vsunSm02 = (MonoMethod)typeof(NJOClass).GetMethod("Simulator_CreateExportFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"Simulator_CreateExportFileImpl\"); is null.");
                return false;
            }
            var vsunSm03 = (MonoMethod)typeof(NJOClass).GetMethod("Simulator_CreateScriptErrorFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"Simulator_CreateScriptErrorFileImpl\"); is null.");
                return false;
            }
            ////
            var vsunSm00_i = (MonoMethod)typeof(ScriptCore.Simulator).GetMethod("Simulator_AppendToScriptErrorFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.Simulator).GetMethod(\"Simulator_AppendToScriptErrorFileImpl\"); is null.");
                return false;
            }
            var vsunSm01_i = (MonoMethod)typeof(ScriptCore.Simulator).GetMethod("Simulator_CloseScriptErrorFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.Simulator).GetMethod(\"Simulator_CloseScriptErrorFileImpl\"); is null.");
                return false;
            }
            var vsunSm02_i = (MonoMethod)typeof(ScriptCore.Simulator).GetMethod("Simulator_CreateExportFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.Simulator).GetMethod(\"Simulator_CreateExportFileImpl\"); is null.");
                return false;
            }
            var vsunSm03_i = (MonoMethod)typeof(ScriptCore.Simulator).GetMethod("Simulator_CreateScriptErrorFileImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (vsunSm03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.Simulator).GetMethod(\"Simulator_CreateScriptErrorFileImpl\"); is null.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vsunSm00, vsunSm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vsunSm00, vsunSm00_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vsunSm01, vsunSm01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vsunSm01, vsunSm01_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vsunSm02, vsunSm02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vsunSm02, vsunSm02_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vsunSm03, vsunSm03_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vsunSm03, vsunSm03_i) failed.");
                return false;
            }

            // MapTagController class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NMotive>().MapTagController_Simulate();
            NJOClass.bs_dont_call = false;


            var vMTCUIm00 = (MonoMethod)typeof(NJOClass).GetMethod("MapTagController_Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vMTCUIm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"MapTagController_Simulate\"); is null.");
                return false;
            }
            ////
            var vMTCUIm00_i = (MonoMethod)typeof(Sims3.UI.MapTagController).GetMethod("Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vMTCUIm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.UI.MapTagController).GetMethod(\"Simulate\"); is null.");
                return false;
            }

            niec_script_func.niecmod_scipt_pre_ptr_obj_create_method2<Sims3.UI.MapTagController, NFinalizeDeath.Function>(vMTCUIm00_i);

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vMTCUIm00, vMTCUIm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vMTCUIm00, vMTCUIm00_i) failed.");
                return false;
            }

            // MapTagVisibilityUpdate class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NMotive>().MapTagVisibilityUpdate_Simulate();
            NJOClass.bs_dont_call = false;

            var vMTVUUIm00 = (MonoMethod)typeof(NJOClass).GetMethod("MapTagVisibilityUpdate_Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vMTVUUIm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"MapTagVisibilityUpdate_Simulate\"); is null.");
                return false;
            }
            ////
            var vMTVUUIm00_i = (MonoMethod)typeof(Sims3.UI.MapTagController.MapTagVisibilityUpdate).GetMethod("Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vMTVUUIm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.UI.MapTagController.MapTagVisibilityUpdate).GetMethod(\"Simulate\"); is null.");
                return false;
            }

            niec_script_func.niecmod_scipt_pre_ptr_obj_create_method2<Sims3.UI.MapTagController.MapTagVisibilityUpdate, NFinalizeDeath.Function>(vMTVUUIm00_i);

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vMTVUUIm00, vMTVUUIm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vMTVUUIm00, vMTVUUIm00_i) failed.");
                return false;
            }

            // TooltipManager class

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NMotive>().TooltipManager_Simulate();
            NJOClass.bs_dont_call = false;

            var vTMUIm00 = (MonoMethod)typeof(NJOClass).GetMethod("TooltipManager_Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vTMUIm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"TooltipManager_Simulate\"); is null.");
                return false;
            }
            ////
            var vTMUIm00_i = (MonoMethod)typeof(Sims3.UI.TooltipManager).GetMethod("Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vTMUIm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.UI.TooltipManager).GetMethod(\"Simulate\"); is null.");
                return false;
            }

            niec_script_func.niecmod_scipt_pre_ptr_obj_create_method2<Sims3.UI.TooltipManager, NFinalizeDeath.Function>(vTMUIm00_i);

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vTMUIm00, vTMUIm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vTMUIm00, vTMUIm00_i) failed.");
                return false;
            }

            // SocialWorkerChildAbuse class

            //NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NMotive>().SocialWorkerChildAbuse_MakeServiceRequest(null, false, default(ObjectGuid), false);
            //NJOClass.bs_dont_call = false;

            var vSWCAm00 = (MonoMethod)typeof(NJOClass).GetMethod("SocialWorkerChildAbuse_MakeServiceRequest", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vSWCAm00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"SocialWorkerChildAbuse_MakeServiceRequest\"); is null.");
                return false;
            }
            ////
            var vSWCAm00_i = (MonoMethod)typeof(Sims3.Gameplay.Services.SocialWorkerChildAbuse).GetMethod("MakeServiceRequest", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (vSWCAm00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sims3.Gameplay.Services.SocialWorkerChildAbuse).GetMethod(\"MakeServiceRequest\"); is null.");
                return false;
            }

            niec_script_func.niecmod_scipt_pre_ptr_obj_create_method2<Sims3.Gameplay.Services.SocialWorkerChildAbuse, ritaiyiaututtittemp>(vSWCAm00_i);

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(vSWCAm00, vSWCAm00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NOtherClass_InjectMethod: copy_ptr_func_to_func(vSWCAm00, vSWCAm00_i) failed.");
                return false;
            }
            return true;
        }

        public static bool DoneInjectCaregiverRoutingMonitor = false;
        public static bool DoneInjectToUserCreated = false;

        public static
            bool PlumbBob_InjectAAAndSAA()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NPlumbBob.InitClass();

            NPlumbBob.sCurrentSimTwo = Bim.GetStatic();
            NPlumbBob.SetActiveActor(null, false);
            NPlumbBob.sCurrentSimTwo = null;

            NFinalizeDeath.M(NPlumbBob.ActiveActor);
            NPlumbBob.CheckChangeInActiveHousehold(null, false);
            NPlumbBob._OnObjectPendingDestruction(null, null);

            var m00 = (MonoMethod)typeof(NPlumbBob).GetMethod("SetActiveActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NPlumbBob).GetMethod(\"SetActiveActor\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(NPlumbBob).GetMethod("get_ActiveActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NPlumbBob).GetMethod(\"get_ActiveActor\"); is null.");
                return false;
            }

            var m02 = (MonoMethod)typeof(NPlumbBob).GetMethod("CheckChangeInActiveHousehold", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NPlumbBob).GetMethod(\"CheckChangeInActiveHousehold\"); is null.");
                return false;
            }

            var m03 = (MonoMethod)typeof(NPlumbBob).GetMethod("_OnObjectPendingDestruction", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NPlumbBob).GetMethod(\"_OnObjectPendingDestruction\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var m00_i = (MonoMethod)typeof(PlumbBob).GetMethod("DoSelectActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);//, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(PlumbBob).GetMethod(\"DoSelectActor\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)typeof(PlumbBob).GetMethod("get_SelectedActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);//, null, new Type[0], null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(PlumbBob).GetMethod(\"get_SelectedActor\"); is null.");
                return false;
            }

            var m02_i = (MonoMethod)typeof(PlumbBob).GetMethod("CheckForChangeInActiveHousehold", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);//, null, new Type[0], null);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(PlumbBob).GetMethod(\"CheckForChangeInActiveHousehold\"); is null.");
                return false;
            }

            var m03_i = (MonoMethod)typeof(PlumbBob).GetMethod("OnObjectPendingDestruction", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);//, null, new Type[0], null);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(PlumbBob).GetMethod(\"OnObjectPendingDestruction\"); is null.");
                return false;
            }

            ///////////////////////////////////////////


            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("InjectAAAndSAA: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("InjectAAAndSAA: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("InjectAAAndSAA: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("InjectAAAndSAA: copy_ptr_func_to_func(m03, m03_i) failed.");
                return false;
            }

            return true;
        }

        public static
           bool NGameObject_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NGameObject.InitClass();


            var m00 = (MonoMethod)typeof(NGameObject).GetMethod("_InitInit", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGameObject).GetMethod(\"_InitInit\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(GameObject).GetMethod("Init", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(bool) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(GameObject).GetMethod(\"Init\"); is null.");
                return false;
            }

            try
            {
                if (m00_i.DeclaringType.Equals(typeof(Sims3.Gameplay.Abstracts.ScriptObject)))
                {
                    NFinalizeDeath.Assert("if (m00_i.DeclaringType Equals typeof(Sims3.Gameplay.Abstracts.ScriptObject) failed.");
                }
                Delegate.CreateDelegate(typeof(reirdrtyaartemp), NGameObject.GetStatic(), m00_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(reirdrtyaartemp), NGameObject.GetStatic(), m00_i); failed.");
                return false;
            }


            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NGameObject_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            return true;
        }

        public static
          bool NIOP_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NInteractionObjectPair.InitClass();

            var m00 = (MonoMethod)typeof(NInteractionObjectPair).GetMethod("NAddInteractions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NInteractionObjectPair).GetMethod(\"NAddInteractions\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Autonomy.InteractionObjectPair).GetMethod("AddInteractions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.Interfaces.IActor), typeof(List<Sims3.Gameplay.Autonomy.InteractionObjectPair>) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(InteractionObjectPair).GetMethod(\"AddInteractions\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NIOP_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            return true;
        }
        public static
          bool NAuto_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NAutoCl.InitClass();

            var m00 = (MonoMethod)typeof(NAutoCl).GetMethod("get_IsNSufficientlyOnScreenForHighLODSimulation", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NAutoCl).GetMethod(\"get_IsNSufficientlyOnScreenForHighLODSimulation\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)typeof(NAutoCl).GetMethod("get_IsNRunningHighLODSimulation", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NAutoCl).GetMethod(\"get_IsNRunningHighLODSimulation\"); is null.");
                return false;
            }
            var m02 = (MonoMethod)typeof(NAutoCl).GetMethod("get_NShouldRunLocalAutonomy", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NAutoCl).GetMethod(\"get_NShouldRunLocalAutonomy\"); is null.");
                return false;
            }

            //////////////////////

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Autonomy.Autonomy).GetMethod("get_IsSufficientlyOnScreenForHighLODSimulation", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Autonomy).GetMethod(\"get_IsSufficientlyOnScreenForHighLODSimulation\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(Sims3.Gameplay.Autonomy.Autonomy).GetMethod("get_IsRunningHighLODSimulation", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Autonomy).GetMethod(\"get_IsRunningHighLODSimulation\"); is null.");
                return false;
            }
            var m02_i = (MonoMethod)typeof(Sims3.Gameplay.Autonomy.Autonomy).GetMethod("get_ShouldRunLocalAutonomy", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Autonomy).GetMethod(\"get_ShouldRunLocalAutonomy\"); is null.");
                return false;
            }


            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NAuto_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NAuto_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NAuto_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }


            return true;
        }

        public static
           bool NIMT_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<NJOClass>().immediate_interaction_task_simulate();
            NJOClass.bs_dont_call = false;

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("immediate_interaction_task_simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"immediate_interaction_task_simulate\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.ImmediateInteractionTask).GetMethod("Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ImmediateInteractionTask).GetMethod(\"Simulate\"); is null.");
                return false;
            }

            // Required if no create method pointer.
            Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), new Sims3.Gameplay.ImmediateInteractionTask(null, null), m00_i);

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NIMT_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            return true;
        }

        public static
            bool NLotManger_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;
            object objt = null;
            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 
            NJOClass.LotManager_OnWorldEvent(objt, null);
            NFinalizeDeath.ETMY();

            if (objt != null)
            {
                Sims3.Gameplay.Core.LotManager.OnWorldEvent(objt, null);
            }

            var m00 = (MonoMethod)typeof(NFinalizeDeath).GetMethod("ETMY", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NFinalizeDeath).GetMethod(\"ETMY\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)typeof(NJOClass).GetMethod("LotManager_OnWorldEvent", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"LotManager_OnWorldEvent\"); is null.");
                return false;
            }
            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Core.LotManager).GetMethod("CleanUpLotsAndInventories", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(LotManager).GetMethod(\"CleanUpLotsAndInventories\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(Sims3.Gameplay.Core.LotManager).GetMethod("OnWorldEvent", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(LotManager).GetMethod(\"OnWorldEvent\"); is null.");
                return false;
            }

            // Required if no create method pointer.
            Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), m00_i);
            Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), m00); 

            var p = new NFinalizeDeath.Function(NFinalizeDeath.ETMY);
            var p1 = new NFinalizeDeath.Function(LotManager.CleanUpLotsAndInventories);

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false) && !niec_script_func.niecmod_script_copy_ptr_methed_to_methed_internal<nobjecoD>(p.method_ptr, p1.method_ptr, false))
            {
                NFinalizeDeath.Assert("NLotManger_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NLotManger_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }
            return true;
        }

        public static
            bool NFireS_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NFinalizeDeath.TempCall01 = true;
            NFinalizeDeath.IsNFireOnSim(null);
            NFinalizeDeath.TempCall01 = false;

            var m00 = (MonoMethod)typeof(NFinalizeDeath).GetMethod("IsNFireOnSim", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NFinalizeDeath).GetMethod(\"IsNFireOnSim\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Services.FirefighterSituation).GetMethod("IsSimOnFire", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.Interfaces.IActor) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(FirefighterSituation).GetMethod(\"IsSimOnFire\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NFireS_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            return true;
        }

        public static
            bool NHousehold_InjectOtherMehed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NHousehold.InitClass();

            var m00 = (MonoMethod)typeof(NHousehold).GetMethod("_CleanUp", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHousehold).GetMethod(\"_CleanUp\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(NHousehold).GetMethod("get_NAllSimDescriptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHousehold).GetMethod(\"get_NAllSimDescriptions\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(Household).GetMethod("Cleanup", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Household).GetMethod(\"Cleanup\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(Household).GetMethod("get_AllSimDescriptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Household).GetMethod(\"get_AllSimDescriptions\"); is null.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHousehold_InjectOtherMehed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHousehold_InjectOtherMehed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            return true;
        }

        public static
            bool NSimFaceWorld_InjectOtherMehed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NFinalizeDeath.TempCall01 = true;
            NFinalizeDeath.SInjectOnStartupApp();
            NFinalizeDeath.TempCall01 = false;

            var m00 = (MonoMethod)typeof(NFinalizeDeath).GetMethod("SInjectOnStartupApp", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NFinalizeDeath).GetMethod(\"SInjectOnStartupApp\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(World).GetMethod("OnStartupApp", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(World).GetMethod(\"OnStartupApp\"); is null.");
                return false;
            }

            // Required if no create method pointer.
            Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), m00_i);
            Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), m00); 

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NSimFaceWorld_InjectOtherMehed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            return true;
        }

        public static
            bool NACoreSBC_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NFinalizeDeath.ACoreStoryBusIsSacred(null);

            var m00 = (MonoMethod)typeof(NFinalizeDeath).GetMethod("ACoreStoryBusIsSacred", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NFinalizeDeath).GetMethod(\"ACoreStoryBusIsSacred\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)NFinalizeDeath.GetGoodType("Awesome.StoryBus.Core", true).GetMethod("IsSacred", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Household) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Awesome.StoryBus.Core).GetMethod(\"IsSacred\"); is null.");
                return false;
            }

            Delegate.CreateDelegate(typeof(reryertewtytemp), m00_i); // Required if no create method pointer.

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NACoreSBC_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            // Part 2

            NJOClass.AMod_Narcolepsy_Is(null);

            var m01 = (MonoMethod)typeof(NJOClass).GetMethod("AMod_Narcolepsy_Is", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"AMod_Narcolepsy_Is\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)NFinalizeDeath.GetGoodType("Awesome.Schtick.Narcolepsy", true).GetMethod("Is", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimDescription) }, null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Narcolepsy).GetMethod(\"Is\"); is null.");
                return false;
            }

            Delegate.CreateDelegate(typeof(reryertewtyratemp), m01_i); // Required if no create method pointer.

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NACoreSBC_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            return true;
        }

        public static bool done_NewBimDesc_InjectOtherMethed = false;

        public static
            bool NewBimDesc_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NewBimDesc.dontCall = true;
            // GC safe
            var simd0 = new NewBimDesc();
            var simd1 = new NewBimDesc((SimDescriptionCore)null);
            var simd2 = new NewBimDesc((SimOutfit)null);

            NewBimDesc.dontCall = false;

            var m00 = (MonoCMethod)typeof(NewBimDesc).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NewBimDesc)GetConstructor(); is null.");
                return false;
            }

            var m01 = (MonoCMethod)typeof(NewBimDesc).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimDescriptionCore) }, null);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NewBimDesc)GetConstructor(sdcore); is null.");
                return false;
            }

            var m02 = (MonoCMethod)typeof(NewBimDesc).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimOutfit) }, null);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(NewBimDesc)GetConstructor(simo); is null.");
                return false;
            }

            //////////////////////////////

            var m00_i = (MonoCMethod)typeof(SimDescription).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(SimDescription)GetConstructor(); is null.");
                return false;
            }

            var m01_i = (MonoCMethod)typeof(SimDescription).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimDescriptionCore) }, null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(SimDescription)GetConstructor(sdcore); is null.");
                return false;
            }

            var m02_i = (MonoCMethod)typeof(SimDescription).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimOutfit) }, null);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoCMethod)typeof(SimDescription)GetConstructor(simo); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NewBimDesc_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NewBimDesc_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NewBimDesc_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }

            done_NewBimDesc_InjectOtherMethed = true;

            return simd0 != null && simd1 != null && simd2 != null;
        }

        public static
            bool NAskBool_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false) || !niec_native_func.cache_done_niecmod_native_message_box)
                return false;

            NJOClass.TwoButtonDialog_Show     (null, null, null, false, false, default(Vector2), false);
            NJOClass.AcceptCancelDialog_Show  (null, false, false, default(Vector2), false);
            NJOClass.ThreeButtonDialog_Show   (null, null, null, null, default(Vector2));
            NJOClass.SimpleMessageDialog_Show (null, null, null, Sims3.UI.ModalDialog.PauseMode.NoPause, default(Vector2), null, null);

            object obj = null; // Required 
            if (obj != null)
            {
                Sims3.UI.AcceptCancelDialog.Show(null, obj != null, false, default(Vector2), false);
                Sims3.UI.TwoButtonDialog.Show(null, null, null, false, false, default(Vector2), false);
                Sims3.UI.ThreeButtonDialog.Show(null, null, null, null, default(Vector2));
                Sims3.UI.SimpleMessageDialog.Show(null, null, null, Sims3.UI.ModalDialog.PauseMode.NoPause, default(Vector2), null, null);
            }

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("AcceptCancelDialog_Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"TwoButtonDialog_Show\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)typeof(NJOClass).GetMethod("TwoButtonDialog_Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"TwoButtonDialog_Show\"); is null.");
                return false;
            }
            var m02 = (MonoMethod)typeof(NJOClass).GetMethod("ThreeButtonDialog_Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"ThreeButtonDialog_Show\"); is null.");
                return false;
            }
            var m03 = (MonoMethod)typeof(NJOClass).GetMethod("SimpleMessageDialog_Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"SimpleMessageDialog_Show\"); is null.");
                return false;
            }
            ///////////
            var m00_i = (MonoMethod)typeof(Sims3.UI.AcceptCancelDialog).GetMethod("Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(bool), typeof(bool), typeof(Vector2), typeof(bool) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(AcceptCancelDialog).GetMethod(\"MakeSim\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(Sims3.UI.TwoButtonDialog).GetMethod("Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(Vector2), typeof(bool) }, null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(TwoButtonDialog).GetMethod(\"Show\"); is null.");
                return false;
            }
            var m02_i = (MonoMethod)typeof(Sims3.UI.ThreeButtonDialog).GetMethod("Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(Vector2) }, null);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ThreeButtonDialog).GetMethod(\"Show\"); is null.");
                return false;
            }
            var m03_i = (MonoMethod)typeof(Sims3.UI.SimpleMessageDialog).GetMethod("Show", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(string), typeof(string), typeof(Sims3.UI.ModalDialog.PauseMode), typeof(Vector2), typeof(string), typeof(string) }, null);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimpleMessageDialog).GetMethod(\"Show\"); is null.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NAskBool_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NAskBool_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NAskBool_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NAskBool_InjectOtherMethed: copy_ptr_func_to_func(m03, m03_i) failed.");
                return false;
            }
            return true;
        }

        public static
            bool NCharacterImportOnGameLoad_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NJOClass.bs_dont_call = true;
            NJOClass.CharacterImportOnGameLoad_GatherHouseholdsAndDisposeCruft();
            NJOClass.CharacterImportOnGameLoad_GatherSimDescriptionsAndDisposeCruft();
            NJOClass.bs_dont_call = false;

            object obj = null;
            if (obj != null)
            {
                obj = obj.GetHashCode();
                Sims3.Gameplay.WorldBuilderUtil.CharacterImportOnGameLoad.GatherHouseholdsAndDisposeCruft();
                Sims3.Gameplay.WorldBuilderUtil.CharacterImportOnGameLoad.GatherSimDescriptionsAndDisposeCruft();
            }

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("CharacterImportOnGameLoad_GatherHouseholdsAndDisposeCruft", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"CharacterImportOnGameLoad_GatherHouseholdsAndDisposeCruft\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)typeof(NJOClass).GetMethod("CharacterImportOnGameLoad_GatherSimDescriptionsAndDisposeCruft", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"CharacterImportOnGameLoad_GatherSimDescriptionsAndDisposeCruft\"); is null.");
                return false;
            }
            ///////////
            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.WorldBuilderUtil.CharacterImportOnGameLoad).GetMethod("GatherHouseholdsAndDisposeCruft", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(CharacterImportOnGameLoad).GetMethod(\"GatherHouseholdsAndDisposeCruft\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(Sims3.Gameplay.WorldBuilderUtil.CharacterImportOnGameLoad).GetMethod("GatherSimDescriptionsAndDisposeCruft", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(CharacterImportOnGameLoad).GetMethod(\"GatherSimDescriptionsAndDisposeCruft\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NCharacterImportOnGameLoad_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NCharacterImportOnGameLoad_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            return true;
        }

        public static bool NHashDEBUG = false;

        public static
            bool NHashDEBUG_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            object obj = null;
            string unused;
            if (obj != null)
            {
                Sims3.SimIFace.ResourceUtils.HashString24((string)obj);
                Sims3.SimIFace.ResourceUtils.HashString32((string)obj);
                Sims3.SimIFace.ResourceUtils.HashString64((string)obj);
                Sims3.SimIFace.ResourceUtils.XorFoldHashString32((string)obj);

                Sims3.SimIFace.ResourceUtils.UnHash(0);
                Sims3.SimIFace.ResourceUtils.UnHash(0, out unused);
                Sims3.SimIFace.ResourceUtils.UnHash(0UL, out unused);
            }

            NHashStringDEBUG.dontCall = true;

            NHashStringDEBUG.HashString24(null);
            NHashStringDEBUG.HashString32(null);
            NHashStringDEBUG.HashString64(null);
            NHashStringDEBUG.XorFoldHashString32(null);

            NHashStringDEBUG.UnHash(0);
            NHashStringDEBUG.UnHash(0, out unused);
            NHashStringDEBUG.UnHash(0UL, out unused);

            NHashStringDEBUG.dontCall = false;

            var m00 = (MonoMethod)typeof(NHashStringDEBUG).GetMethod("HashString24", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHashStringDEBUG).GetMethod(\"HashString24\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)typeof(NHashStringDEBUG).GetMethod("HashString32", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHashStringDEBUG).GetMethod(\"HashString32\"); is null.");
                return false;
            }
            var m02 = (MonoMethod)typeof(NHashStringDEBUG).GetMethod("HashString64", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHashStringDEBUG).GetMethod(\"HashString64\"); is null.");
                return false;
            }
            var m03 = (MonoMethod)typeof(NHashStringDEBUG).GetMethod("XorFoldHashString32", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHashStringDEBUG).GetMethod(\"XorFoldHashString32\"); is null.");
                return false;
            }
            // UnHash
            var m04 = (MonoMethod)typeof(NHashStringDEBUG).GetMethod("UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(uint) }, null);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHashStringDEBUG).GetMethod(\"UnHash1\"); is null.");
                return false;
            }
            var m05 = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(NHashStringDEBUG), new Type[] { typeof(uint), typeof(string).MakeByRefType() }, "UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m05 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHashStringDEBUG).GetMethod(\"UnHash2\"); is null.");
                return false;
            }
            var m06 = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(NHashStringDEBUG), new Type[] { typeof(ulong), typeof(string).MakeByRefType() }, "UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic); //(MonoMethod)typeof(NHashStringDEBUG).GetMethod("UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(ulong), typeof(string) }, null);
            if (m06 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHashStringDEBUG).GetMethod(\"UnHash3\"); is null.");
                return false;
            }
            ////////////////////////////
            var m00_i = (MonoMethod)typeof(Sims3.SimIFace.ResourceUtils).GetMethod("HashString24", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResourceUtils).GetMethod(\"HashString24\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(Sims3.SimIFace.ResourceUtils).GetMethod("HashString32", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResourceUtils).GetMethod(\"HashString32\"); is null.");
                return false;
            }
            var m02_i = (MonoMethod)typeof(Sims3.SimIFace.ResourceUtils).GetMethod("HashString64", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResourceUtils).GetMethod(\"HashString64\"); is null.");
                return false;
            }
            var m03_i = (MonoMethod)typeof(Sims3.SimIFace.ResourceUtils).GetMethod("XorFoldHashString32", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResourceUtils).GetMethod(\"XorFoldHashString32\"); is null.");
                return false;
            }
            // UnHash
            var m04_i = (MonoMethod)typeof(Sims3.SimIFace.ResourceUtils).GetMethod("UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(uint) }, null);
            if (m04_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResourceUtils).GetMethod(\"UnHash1\"); is null.");
                return false;
            }
            var m05_i = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(Sims3.SimIFace.ResourceUtils), new Type[] { typeof(uint), typeof(string).MakeByRefType() }, "UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);//(MonoMethod)typeof(Sims3.SimIFace.ResourceUtils).GetMethod("UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(uint), typeof(string) }, null);
            if (m05_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResourceUtils).GetMethod(\"UnHash2\"); is null.");
                return false;
            }
            var m06_i = (MonoMethod)NFinalizeDeath.GetGoodMethods(typeof(Sims3.SimIFace.ResourceUtils), new Type[] { typeof(ulong), typeof(string).MakeByRefType() }, "UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);//typeof(Sims3.SimIFace.ResourceUtils).GetMethod("UnHash", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(ulong), typeof(string) }, null);
            if (m06_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ResourceUtils).GetMethod(\"UnHash3\"); is null.");
                return false;
            }



            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: copy_ptr_func_to_func(m03, m03_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m04, m04_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: copy_ptr_func_to_func(m04, m04_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m05, m05_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: copy_ptr_func_to_func(m05, m05_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m06, m06_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: copy_ptr_func_to_func(m06, m06_i) failed.");
                return false;
            }

            try
            {
                Sims3.SimIFace.ResourceUtils.HashString24("niecmodhash");
                var hash = Sims3.SimIFace.ResourceUtils.HashString32("niecmodhash");
                var hash64 = Sims3.SimIFace.ResourceUtils.HashString64("niecmodhash");
                Sims3.SimIFace.ResourceUtils.XorFoldHashString32("niecmodhash");

                Sims3.SimIFace.ResourceUtils.UnHash(hash);
                Sims3.SimIFace.ResourceUtils.UnHash(hash, out unused);
                Sims3.SimIFace.ResourceUtils.UnHash(hash64, out unused);
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("NHashDEBUG_InjectOtherMethed: NHashStringDEBUG test failed.");
                return false;
            }

            NHashDEBUG = true;

            return true;
        }

        public static
           bool NGenetics_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NGenetics.InitClass();

            var m00 = (MonoMethod)typeof(NGenetics).GetMethod("CreateSimDesc", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGenetics).GetMethod(\"CreateSimDesc\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)typeof(NGenetics).GetMethod("CreatePetBabyPetSimDescription", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGenetics).GetMethod(\"CreatePetBabyPetSimDescription\"); is null.");
                return false;
            }
            var m02 = (MonoMethod)typeof(NGenetics).GetMethod("CreatePetFamily", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGenetics).GetMethod(\"CreatePetFamily\"); is null.");
                return false;
            }
            var m03 = (MonoMethod)typeof(NGenetics).GetMethod("CreatePet", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGenetics).GetMethod(\"CreatePet\"); is null.");
                return false;
            }
            var m04 = (MonoMethod)typeof(NGenetics).GetMethod("CreateRobot", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NGenetics).GetMethod(\"CreateRobot\"); is null.");
                return false;
            }


            //////////////////////////////////////////


            var m00_i = (MonoMethod)typeof(Genetics).GetMethod("MakeSim", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimBuilder), typeof(CASAgeGenderFlags), typeof(CASAgeGenderFlags), typeof(ResourceKey), typeof(float), typeof(Color[]), typeof(WorldName), typeof(uint), typeof(bool) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Genetics).GetMethod(\"MakeSim\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(GeneticsPet).GetMethod("CreateAndModifyBabyPetSimDescription", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimBuilder), typeof(SimDescription), typeof(SimDescription), typeof(Random), typeof(bool), typeof(Sims3.Gameplay.CAS.GeneticsPet.SetName), typeof(Sims3.Gameplay.CAS.GeneticsPet.SpeciesSpecificData), typeof(int), typeof(Sims3.UI.Hud.OccultTypes), typeof(WorldName) }, null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(GeneticsPet).GetMethod(\"CreateAndModifyBabyPetSimDescription\"); is null.");
                return false;
            }
            var m02_i = (MonoMethod)typeof(GeneticsPet).GetMethod("MakePetDescendant", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimDescription), typeof(SimDescription), typeof(CASAgeGenderFlags), typeof(CASAgeGenderFlags), typeof(CASAgeGenderFlags), typeof(Random), typeof(bool), typeof(Sims3.Gameplay.CAS.GeneticsPet.SetName), typeof(int), typeof(Sims3.UI.Hud.OccultTypes) }, null);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(GeneticsPet).GetMethod(\"MakePetDescendant\"); is null.");
                return false;
            }
            var m03_i = (MonoMethod)typeof(GeneticsPet).GetMethod("MakePet", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(SimBuilder), typeof(CASAgeGenderFlags), typeof(CASAgeGenderFlags), typeof(CASAgeGenderFlags), typeof(Sims3.Gameplay.CAS.GeneticsPet.SpeciesSpecificData), typeof(WorldName) }, null);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(GeneticsPet).GetMethod(\"MakeRobot\"); is null.");
                return false;
            }
            var m04_i = (MonoMethod)typeof(Sims3.Gameplay.ActorSystems.OccultRobot).GetMethod("MakeRobot", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(ResourceKey) }, null);
            if (m04_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(OccultRobot).GetMethod(\"MakeRobot\"); is null.");
                return false;
            }


            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NGenetics_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NGenetics_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NGenetics_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NGenetics_InjectOtherMethed: copy_ptr_func_to_func(m03, m03_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m04, m04_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NGenetics_InjectOtherMethed: copy_ptr_func_to_func(m04, m04_i) failed.");
                return false;
            }

            return true;
        }

        public static bool DoneNSIFRoute = false;

        public static 
            bool NSIFRoute_InjectMethod()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NJOClass.bs_dont_call = true;
            NJOClass.n_route_create_route(null, 0);
            NJOClass.bs_dont_call = false;

            var m00 = (MonoMethod)typeof(NJOClass).GetMethod("n_route_create_route", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NJOClass).GetMethod(\"n_route_create_route\"); is null.");
                return false;
            }

            /////////////////////////////////////////

            var m00_i = (MonoMethod)typeof(Sims3.SimIFace.Route).GetMethod("Create", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(IScriptProxy), typeof(uint) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Route).GetMethod(\"Create\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NRoune_InjectMethoed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            DoneNSIFRoute = true;

            return true;
        }

        public static bool DoneMakeSimDescID = false;

        public static
            bool BimDesc_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            BimDesc.InitClass();

            var m00 = (MonoMethod)typeof(BimDesc).GetMethod("_NInstantiate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(BimDesc).GetMethod(\"_NInstantiate\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(BimDesc).GetMethod("_NOnWorldLoadFinished", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(BimDesc).GetMethod(\"_NOnWorldLoadFinished\"); is null.");
                return false;
            }

            var m02 = (MonoMethod)typeof(BimDesc).GetMethod("_NPostLoadFixUp", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(BimDesc).GetMethod(\"_NPostLoadFixUp\"); is null.");
                return false;
            }

            var m03 = (MonoMethod)typeof(BimDesc).GetMethod("_NMakeUniqueID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(BimDesc).GetMethod(\"_NMakeUniqueID\"); is null.");
                return false;
            }

            var m04 = (MonoMethod)typeof(BimDesc).GetMethod("_NFixUp", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(BimDesc).GetMethod(\"_NFixUp\"); is null.");
                return false;
            }

            var m05 = (MonoMethod)typeof(BimDesc).GetMethod("_NDispose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m05 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(BimDesc).GetMethod(\"_NDispose\"); is null.");
                return false;
            }
            var m06 = (MonoMethod)typeof(BimDesc).GetMethod("bd_ExportContent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m06 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(BimDesc).GetMethod(\"bd_ExportContent\"); is null.");
                return false;
            }
            /////////////////////////////////////////

            var m00_i = (MonoMethod)typeof(SimDescription).GetMethod("Instantiate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Vector3), typeof(ResourceKey), typeof(bool), typeof(bool) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimDescription).GetMethod(\"Instantiate\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)typeof(SimDescription).GetMethod("OnWorldLoadFinished", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimDescription).GetMethod(\"OnWorldLoadFinished\"); is null.");
                return false;
            }

            var m02_i = (MonoMethod)typeof(SimDescription).GetMethod("PostLoadFixUp", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimDescription).GetMethod(\"PostLoadFixUp\"); is null.");
                return false;
            }

            var m03_i = (MonoMethod)typeof(SimDescription).GetMethod("MakeUniqueId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimDescription).GetMethod(\"MakeUniqueId\"); is null.");
                return false;
            }

            var m04_i = (MonoMethod)typeof(SimDescription).GetMethod("Fixup", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m04_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimDescription).GetMethod(\"Fixup\"); is null.");
                return false;
            }

            var m05_i = (MonoMethod)typeof(SimDescription).GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(bool), typeof(bool), typeof(bool), typeof(bool), typeof(bool) }, null);
            if (m05_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimDescription).GetMethod(\"Dispose\"); is null.");
                return false;
            }

            var m06_i = (MonoMethod)typeof(SimDescription).GetMethod("ExportContent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m06_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SimDescription).GetMethod(\"ExportContent\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m03, m03_i) failed.");
                return false;
            }
            else DoneMakeSimDescID = true;
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m04, m04_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m04, m04_i) failed.");
                return false;
            }

            if (!NFinalizeDeath.IsOpenDGSInstalled && NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m05, m05_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m05, m05_i) failed.");
                    return false;
                }
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m06, m06_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m06, m06_i) failed.");
                return false;
            }
            else BimDesc.DoneECMK = true;
            return true;
        }

        public static bool DoneIBimDestroy = false;

        public static bool DoneLoopIdle = false;

        public static
           bool Bim_InjectOtherMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            Bim.GetStatic().bboolCanBeKill();
            Bim.GetStatic().bboolIsDying();

            Bim.XRun__ = true;
            Bim.GetStatic().bimSimulate();
            Bim.XRun__ = false;


            Bim.XRun__X = true;
            Bim.GetStatic().bboolDestroy();
            Bim.GetStatic().bimLoopIdle();
            Bim.GetStatic().bimDispose();
            Bim.GetStatic().bimRouteFailure();
            Bim.GetStatic().bimSetSacsDefaultParameters(null, null);
            Bim.GetStatic().bimChooseStandingIdle(null, null);
            Bim.GetStatic().bimPlayDynamicIdle(null, null);
            Bim.GetStatic().bimExitDynamicIdle(null, null);
            Bim.GetStatic().bimChooseSeatedIdle(null, null);
            NFinalizeDeath.M(Bim.GetStatic().bimHasBeenDestroyed);
            Bim.GetStatic().bimStandingBridgeOriginUsed();
            Bim.GetStatic().bimPlayCustomIdle(null, null);
            Bim.GetStatic().bimIsPointInLotSafelyRoutable(null, default(Vector3));
            Bim.chekcdont = true;
            Bim.GetStatic().bimHandToolAllowIntersection(null, default(Matrix44), false);
            Bim.chekcdont = false;
            Bim.XRun__X = false;

            Bim.DontPlayReaction = true;
            Bim.GetStatic().bimPlayReaction(Sims3.Gameplay.ActorSystems.ReactionTypes.None, new Sims3.Gameplay.Interactions.InteractionPriority(), null, null, default(ResourceKey), Sims3.Gameplay.ThoughtBalloons.ThoughtBalloonAxis.kAutoSelect, Sims3.Gameplay.ActorSystems.ReactionSpeed.None, null, null, false, 0, false, false);
            Bim.DontPlayReaction = false;

            Bim.GetStatic().bboolDoOnReset(null);            

            var m00 = (MonoMethod)typeof(Bim).GetMethod("bboolCanBeKill", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bboolCanBeKill\"); is null.");
                return false;
            }

            var m01 = (MonoMethod)typeof(Bim).GetMethod("bboolIsDying", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bboolIsDying\"); is null.");
                return false;
            }

            var m02 = (MonoMethod)typeof(Bim).GetMethod("bimSimulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimSimulate\"); is null.");
                return false;
            }

            var m03 = (MonoMethod)typeof(Bim).GetMethod("bboolDestroy", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bboolDestroy\"); is null.");
                return false;
            }

            var m04 = (MonoMethod)typeof(Bim).GetMethod("bboolDoOnReset", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bboolDoOnReset\"); is null.");
                return false;
            }

            var m05 = (MonoMethod)typeof(Bim).GetMethod("bimDispose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m05 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimDispose\"); is null.");
                return false;
            }

            var m06 = (MonoMethod)typeof(Bim).GetMethod("bimLoopIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m06 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimLoopIdle\"); is null.");
                return false;
            }

            var m07 = (MonoMethod)typeof(Bim).GetMethod("bimPlayReaction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m07 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimPlayReaction\"); is null.");
                return false;
            }

            var m08 = (MonoMethod)typeof(Bim).GetMethod("bimRouteFailure", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m08 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimRouteFailure\"); is null.");
                return false;
            }

            var m09 = (MonoMethod)typeof(Bim).GetMethod("bimSetSacsDefaultParameters", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m09 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimSetSacsDefaultParameters\"); is null.");
                return false;
            }

            // Idle

            var m10 = (MonoMethod)typeof(Bim).GetMethod("bimChooseStandingIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m10 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimChooseStandingIdle\"); is null.");
                return false;
            }

            var m11 = (MonoMethod)typeof(Bim).GetMethod("bimPlayDynamicIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m11 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimPlayDynamicIdle\"); is null.");
                return false;
            }

            var m12 = (MonoMethod)typeof(Bim).GetMethod("bimExitDynamicIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m12 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimExitDynamicIdle\"); is null.");
                return false;
            }

            var m13 = (MonoMethod)typeof(Bim).GetMethod("bimChooseSeatedIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m13 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimChooseSeatedIdle\"); is null.");
                return false;
            }

            var m14 = (MonoMethod)typeof(Bim).GetMethod("get_bimHasBeenDestroyed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m14 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"get_bimHasBeenDestroyed\"); is null.");
                return false;
            }

            var m15 = (MonoMethod)typeof(Bim).GetMethod("bimStandingBridgeOriginUsed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m15 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimStandingBridgeOriginUsed\"); is null.");
                return false;
            }

            var m16 = (MonoMethod)typeof(Bim).GetMethod("bimPlayCustomIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m16 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimPlayCustomIdle\"); is null.");
                return false;
            }
            var m17 = (MonoMethod)typeof(Bim).GetMethod("bimIsPointInLotSafelyRoutable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m17 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimIsPointInLotSafelyRoutable\"); is null.");
                return false;
            }
            var m18 = (MonoMethod)typeof(Bim).GetMethod("bimHandToolAllowIntersection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m18 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"bimHandToolAllowIntersection\"); is null.");
                return false;
            }

            ////////////////////////////////////////////

            var m00_i = (MonoMethod)typeof(Sim).GetMethod("CanBeKilled", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"CanBeKilled\"); is null.");
                return false;
            }

            var m01_i = (MonoMethod)typeof(Sim).GetMethod("IsDying", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"IsDying\"); is null.");
                return false;
            }

            MonoMethod m02_i = null;// = (MonoMethod)typeof(Sim).GetMethod("Simulate", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);

            var aVoidType = typeof(void);

            try
            {
                foreach (var item in typeof(Sim).GetMethods())
                {
                    if (item == null)
                        continue;

                    var pas = item.GetParameters();
                    if (pas == null || pas.Length != 0)
                        continue;

                    var name = item.Name;
                    if (name == null)
                        continue;

                    if (aVoidType == item.ReturnType && name.Contains("Simulate"))
                    {
                        m02_i = (MonoMethod)item;
                        break;
                    }
                }
            }
            catch (Exception)
            { }
           

            if (m02_i == null)
            {
                NFinalizeDeath.Assert("m02_i == null");//"(MonoMethod)typeof(Sim).GetMethod(\"Simulate\"); is null.");
                return false;
            }

            var m03_i = (MonoMethod)typeof(Sim).GetMethod("Destroy", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"Destroy\"); is null.");
                return false;
            }

            var m04_i = (MonoMethod)typeof(Sim).GetMethod("DoReset", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.Abstracts.GameObject.ResetInformation) }, null);
            if (m04_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"DoReset\"); is null.");
                return false;
            }

            var m05_i = (MonoMethod)typeof(Sim).GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m05_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"Dispose\"); is null.");
                return false;
            }

            var m06_i = (MonoMethod)typeof(Sim).GetMethod("LoopIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m06_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"LoopIdle\"); is null.");
                return false;
            }

            var m07_i = (MonoMethod)typeof(Sim).GetMethod("PlayReaction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.ActorSystems.ReactionTypes), typeof(Sims3.Gameplay.Interactions.InteractionPriority ), typeof(GameObject ), typeof(string ), typeof(ResourceKey ), typeof(Sims3.Gameplay.ThoughtBalloons.ThoughtBalloonAxis ), typeof(Sims3.Gameplay.ActorSystems.ReactionSpeed ), typeof(Sims3.Gameplay.Actors.Sim.PlayReactionCallback ), typeof(Sims3.Gameplay.Actors.Sim.PlayReactionCallback), typeof(bool ), typeof(float ), typeof(bool), typeof(bool)}, null);
            if (m07_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"PlayReaction\"); is null.");
                return false;
            }

            var m08_i = (MonoMethod)typeof(Sim).GetMethod("RouteFailure", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m08_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"RouteFailure\"); is null.");
                return false;
            }

            var m09_i = (MonoMethod)typeof(Sim).GetMethod("SetSacsDefaultParameters", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m09_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"SetSacsDefaultParameters\"); is null.");
                return false;
            }

            // Idle

            var m10_i = (MonoMethod)typeof(Sim).GetMethod("ChooseStandingIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(StateMachineClient), typeof(IEvent) }, null);
            if (m10_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"ChooseStandingIdle\"); is null.");
                return false;
            }

            var m11_i = (MonoMethod)typeof(Sim).GetMethod("PlayDynamicIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(StateMachineClient), typeof(IEvent) }, null);
            if (m11_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"PlayDynamicIdle\"); is null.");
                return false;
            }

            var m12_i = (MonoMethod)typeof(Sim).GetMethod("ExitDynamicIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(StateMachineClient), typeof(IEvent) }, null);
            if (m12_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"ExitDynamicIdle\"); is null.");
                return false;
            }

            var m13_i = (MonoMethod)typeof(Sim).GetMethod("ChooseSeatedIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(StateMachineClient), typeof(IEvent) }, null);
            if (m13_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"ChooseSeatedIdle\"); is null.");
                return false;
            }

            var m14_i = (MonoMethod)typeof(Sim).GetMethod("get_HasBeenDestroyed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m14_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"get_HasBeenDestroyed\"); is null.");
                return false;
            }


            var m15_i = (MonoMethod)typeof(Sim).GetMethod("StandingBridgeOriginUsed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m15_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"StandingBridgeOriginUsed\"); is null.");
                return false;
            }

            var m16_i = (MonoMethod)typeof(Sim).GetMethod("PlayCustomIdle", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m16_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"PlayCustomIdle\"); is null.");
                return false;
            }
            var m17_i = (MonoMethod)typeof(Sim).GetMethod("IsPointInLotSafelyRoutable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m17_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"IsPointInLotSafelyRoutable\"); is null.");
                return false;
            }
            var m18_i = (MonoMethod)typeof(Sim).GetMethod("HandToolAllowIntersection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m18_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"HandToolAllowIntersection\"); is null.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }


            try
            {
                if (m02_i.DeclaringType.Equals(typeof(Sims3.Gameplay.Abstracts.ScriptObject)))
                {
                    NFinalizeDeath.Assert("if (m02_i.DeclaringType Equals typeof(Sims3.Gameplay.Abstracts.ScriptObject) failed.");
                }
                Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m02_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m02_i); failed.");
                return false;
            }

            try
            {
                if (m03_i.DeclaringType.Equals(typeof(Sims3.Gameplay.Abstracts.ScriptObject)))
                {
                    NFinalizeDeath.Assert("if (m03_i.DeclaringType Equals typeof(Sims3.Gameplay.Abstracts.ScriptObject) failed.");
                }
                Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m03_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m03_i); failed.");
                return false;
            }

            try
            {
                if (m04_i.DeclaringType.Equals(typeof(Sims3.Gameplay.Abstracts.GameObject)))
                {
                    NFinalizeDeath.Assert("if (m04_i.DeclaringType Equals typeof(Sims3.Gameplay.Abstracts.GameObject) failed.");
                }
                Delegate.CreateDelegate(typeof(reireireterertemp), Bim.GetStatic(), m04_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(reireireterertemp), Bim.GetStatic(), m04_i); failed.");
                return false;
            }

            try
            {
                Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m05_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m05_i); failed.");
                return false;
            }

            try
            {
                if (m14_i.DeclaringType.Equals(typeof(Sims3.Gameplay.Abstracts.ScriptObject)))
                {
                    NFinalizeDeath.Assert("if (m14_i.DeclaringType Equals typeof(Sims3.Gameplay.Abstracts.ScriptObject) failed.");
                }
                Delegate.CreateDelegate(typeof(NFinalizeDeath.FunctionX), Bim.GetStatic(), m14_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(NFinalizeDeath.FunctionX), Bim.GetStatic(), m14_i); failed.");
                return false;
            }
            try
            {
                if (m18_i.DeclaringType.Equals(typeof(Sims3.Gameplay.Abstracts.GameObject)))
                {
                    NFinalizeDeath.Assert("if (m18_i.DeclaringType Equals typeof(Sims3.Gameplay.Abstracts.GameObject) failed.");
                }
                Delegate.CreateDelegate(typeof(rryorieioefeiewtemp), Bim.GetStatic(), m18_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(rryorieioefeiewtemp), Bim.GetStatic(), m18_i); failed.");
                return false;
            }
            try
            {
                var pt = (MonoMethod)typeof(Sim).GetMethod("Simulate", BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
                if (pt != null)
                {
                    if (pt.DeclaringType.Equals(typeof(Sims3.Gameplay.Abstracts.ScriptObject)))
                    {
                        NFinalizeDeath.Assert("if (pt.DeclaringType Equals typeof(Sims3.Gameplay.Abstracts.ScriptObject) failed.");
                    }
                    Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), pt); // Required if no create method pointer.
                }
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), pt); failed.");
                return false;
            }

            ////////////////////////////////////

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }

            if (!NFinalizeDeath.IsOpenDGSInstalled && NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m03, m03_i) failed.");
                    return false;
                }
                else DoneIBimDestroy = true;
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m04, m04_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m04, m04_i) failed.");
                    return false;
                }
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m05, m05_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m05, m05_i) failed.");
                    return false;
                }

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m06, m06_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m06, m06_i) failed.");
                    return false;
                }
                else DoneLoopIdle = true;

                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m07, m07_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m07, m07_i) failed.");
                    return false;
                }
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m14, m14_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m14, m14_i) failed.");
                    return false;
                }
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m15, m15_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m15, m15_i) failed.");
                    return false;
                }
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m08, m08_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m08, m08_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m09, m09_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m09, m09_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m10, m10_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m10, m10_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m11, m11_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m11, m11_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m12, m12_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m12, m12_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m13, m13_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m13, m13_i) failed.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m16, m16_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m16, m16_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m17, m17_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m17, m17_i) failed.");
                return false;
            }
            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m18, m18_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m18, m18_i) failed.");
                return false;
            }
            return true;
        }

       

        public static
            bool Bim_InjectKillMethed()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            Bim.GetStatic().Sim_NonOpenDGSKill((SimDescription.DeathType)0x55555555, null, false);

            var m00 = (MonoMethod)typeof(Bim).GetMethod("Sim_NonOpenDGSKill", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Bim).GetMethod(\"Sim_NonOpenDGSKill\"); is null.");
                return false;
            }

            var yy = new Type[] {
                typeof(SimDescription.DeathType),
                typeof(GameObject),
                typeof(bool),
            };

            foreach (var item in yy)
            {
                if (item == null)
                {
                    NFinalizeDeath.Assert("yy[i] is null should mono bug?");
                    return false;
                }
            }

            var m01 = (MonoMethod)typeof(Sim).GetMethod("Kill", BindingFlags.Instance | BindingFlags.Public, null, yy, null);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Sim).GetMethod(\"Kill\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m01, false, false, false, false))
            {
                NFinalizeDeath.Assert("InjectKillMethed: niecmod_script_copy_ptr_func_to_func failed.");
                return false;
            }

            //ortyrterte = false;
            //
            //if (NFinalizeDeath.ActiveActor != null)
            //{
            //    NFinalizeDeath.SafeCall(() =>
            //    {
            //        try
            //        {
            //            Bim.DEBURUN = false;
            //            NFinalizeDeath.ActiveActor.Kill(SimDescription.DeathType.BluntForceTrauma, null, false);
            //        }
            //        catch (Exception)
            //        { }
            //        ortyrterte = true;
            //    });
            //}
            //else
            //{
            //    Bim.DEBURUN = true;
            //    ortyrterte = true;
            //}
            //
            //NFinalizeDeath.Assert(ortyrterte, "Sim.Kill Failed.");
            //NFinalizeDeath.Assert(Bim.DEBURUN, "DEBURUN Failed.");

            return true;
        }



        public static 
            bool BimUpdate_InjectMethedACore(MethodInfo toMethodNeedPreLink)
        {
            if (toMethodNeedPreLink == null || NFinalizeDeath.GameIs64Bit(false))
                return false;

            UpdateBim.UpdateSim_Update(null);

            var m00 = (MonoMethod)NFinalizeDeath.GetGoodType("Awesome.Motivator", true).GetMethod("Update", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(Sims3.Gameplay.Autonomy.Autonomy) }, null);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Awesome.Motivator).GetMethod(\"Update\"); is null.");
                return false;
            }

            Delegate.CreateDelegate(typeof(reiterueratemp), m00); // Required if no create method pointer.

            return niec_script_func.niecmod_script_copy_ptr_func_to_func(toMethodNeedPreLink, m00, false, false, true, false);
        }
    }
}
