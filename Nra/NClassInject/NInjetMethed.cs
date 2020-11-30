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
        public delegate void reiterueratemp(Sims3.Gameplay.Autonomy.Autonomy unused);
        public delegate void reireireterertemp(Sims3.Gameplay.Abstracts.GameObject.ResetInformation unused);
        public delegate void reirdrtyaartemp(bool unused);
        public delegate bool reryertewtytemp(Household unused);
        public delegate bool rytutytytrytyutemp(Sim unused, bool unused1);


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

            NJOClass.bs_dont_call = true;
            NJOClass.get_instance<BimDesc>().game_utils_transition_to_quit();
            NJOClass.game_utils_transition_to_quit_internal();
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
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSystemException)GetConstructor(); is null.");
                return false;
            }

            var m01 = (MonoCMethod)typeof(NSystemException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSystemException)GetConstructor(str); is null.");
                return false;
            }
            //
            var m02 = (MonoCMethod)typeof(NNullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NNullReferenceException)GetConstructor(); is null.");
                return false;
            }

            var m03 = (MonoCMethod)typeof(NNullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NNullReferenceException)GetConstructor(str); is null.");
                return false;
            }

            //
            var m04 = (MonoCMethod)typeof(NApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NApplicationException)GetConstructor(); is null.");
                return false;
            }

            var m05 = (MonoCMethod)typeof(NApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m05 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NApplicationException)GetConstructor(str); is null.");
                return false;
            }
            //

            /////////////

            //
            var m00_i = (MonoCMethod)typeof(SystemException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SystemException)GetConstructor(); is null.");
                return false;
            }

            var m01_i = (MonoCMethod)typeof(SystemException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(SystemException)GetConstructor(str); is null.");
                return false;
            }

            //
            var m02_i = (MonoCMethod)typeof(NullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NullReferenceException)GetConstructor(); is null.");
                return false;
            }

            var m03_i = (MonoCMethod)typeof(NullReferenceException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NullReferenceException)GetConstructor(str); is null.");
                return false;
            }

            //
            var m04_i = (MonoCMethod)typeof(ApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if (m04_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ApplicationException)GetConstructor(); is null.");
                return false;
            }

            var m05_i = (MonoCMethod)typeof(ApplicationException).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(string) }, null);
            if (m05_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ApplicationException)GetConstructor(str); is null.");
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

            return true;
        }

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

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr); // Required 

            NFinalizeDeath.ETMY();

            var m00 = (MonoMethod)typeof(NFinalizeDeath).GetMethod("ETMY", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NFinalizeDeath).GetMethod(\"ETMY\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(Sims3.Gameplay.Core.LotManager).GetMethod("CleanUpLotsAndInventories", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(LotManager).GetMethod(\"CleanUpLotsAndInventories\"); is null.");
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

            NHousehold._CleanUp();
            NHousehold.runI = false;

            var m00 = (MonoMethod)typeof(NHousehold).GetMethod("_CleanUp", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NHousehold).GetMethod(\"_CleanUp\"); is null.");
                return false;
            }

            var m00_i = (MonoMethod)typeof(Household).GetMethod("Cleanup", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(Household).GetMethod(\"Cleanup\"); is null.");
                return false;
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("NHousehold_InjectOtherMehed: copy_ptr_func_to_func(m00, m00_i) failed.");
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
            return true;
        }

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

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m04, m04_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m04, m04_i) failed.");
                return false;
            }

            if (!NFinalizeDeath.IsOpenDGSInstalled && NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m05, m05_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("BimDesc_InjectOtherMethed: copy_ptr_func_to_func(m06, m06_i) failed.");
                    return false;
                }
            }

            return true;
        }


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
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m03_i); failed.");
                return false;
            }

            try
            {
                Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m05_i); // Required if no create method pointer.
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("Delegate.CreateDelegate(typeof(NFinalizeDeath.Function), Bim.GetStatic(), m03_i); failed.");
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
                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m07, m07_i, false, false, false, false))
                {
                    NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m07, m07_i) failed.");
                    return false;
                }
            }

            if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m08, m08_i, false, false, false, false))
            {
                NFinalizeDeath.Assert("Bim_InjectOtherMethed: copy_ptr_func_to_func(m08, m08_i) failed.");
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
