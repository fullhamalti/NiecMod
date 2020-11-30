using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using NiecMod.Interactions;
using NiecMod.KillNiec;
using Sims3.Gameplay.Controllers.Niec;

using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Academics;
using Sims3.Gameplay.ActiveCareer;
using Sims3.Gameplay.ActiveCareer.ActiveCareers;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.ActorSystems.Children;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Careers;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.CelebritySystem;
using Sims3.Gameplay.ChildAndTeenUpdates;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.DreamsAndPromises;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.InteractionsShared;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.MapTags;
using Sims3.Gameplay.Moving;
using Sims3.Gameplay.ObjectComponents;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.Objects.Academics;
using Sims3.Gameplay.Objects.Alchemy;
using Sims3.Gameplay.Objects.Elevator;
using Sims3.Gameplay.Objects.Environment;
using Sims3.Gameplay.Objects.Fishing;
using Sims3.Gameplay.Objects.FoodObjects;
using Sims3.Gameplay.Objects.Gardening;
using Sims3.Gameplay.Objects.HobbiesSkills;
using Sims3.Gameplay.Objects.Insect;
using Sims3.Gameplay.Objects.Island;
using Sims3.Gameplay.Objects.Misc;
using Sims3.Gameplay.Objects.Miscellaneous;
using Sims3.Gameplay.Objects.Rewards;
using Sims3.Gameplay.Objects.Vehicles;
using Sims3.Gameplay.OnlineGiftingSystem;
using Sims3.Gameplay.Opportunities;
using Sims3.Gameplay.Passport;
using Sims3.Gameplay.PetObjects;
using Sims3.Gameplay.PetSystems;
using Sims3.Gameplay.Pools;
using Sims3.Gameplay.RealEstate;
using Sims3.Gameplay.Rewards;
using Sims3.Gameplay.Roles;
using Sims3.Gameplay.Routing;
using Sims3.Gameplay.Scuba;
using Sims3.Gameplay.Seasons;
using Sims3.Gameplay.Services;
using Sims3.Gameplay.Situations;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.StoreSystems;
using Sims3.Gameplay.StoryProgression;
using Sims3.Gameplay.ThoughtBalloons;
using Sims3.Gameplay.TimeTravel;
using Sims3.Gameplay.TuningValues;
using Sims3.Gameplay.Tutorial;
using Sims3.Gameplay.UI;
using Sims3.Gameplay.Utilities;
using Sims3.Gameplay.Visa;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.SimIFace.CustomContent;
using Sims3.SimIFace.Enums;
using Sims3.SimIFace.RouteDestinations;
using Sims3.SimIFace.SACS;
using Sims3.UI;
using Sims3.UI.CAS;
using Sims3.UI.Controller;
using Sims3.UI.Dialogs;
using Sims3.UI.Hud;
using Sims3.UI.Resort;
using Sims3.Gameplay;
using Sims3.Gameplay.CAS.Locale;
using Niec.iCommonSpace;
using Sims3.NiecModList.Persistable;
using System.Reflection;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay.NiecRoot;
using NiecMod.Helpers;
using Sims3.Gameplay.DynamicChallenges;

namespace NiecMod.Nra
{
    // Kill Mono Security :D
    internal sealed class NJOClass
    {
        private static object sHome = new NJOClass();

        public static NJOClass get_instance<T>()
        {
            if (sHome as NJOClass == null)
                sHome = new NJOClass();
            return (NJOClass)sHome;
        }

        internal static bool bs_dont_call = false;
        internal static bool alynull = false;
        internal static bool unsaferunpe = false;

        public static bool get_method_checksum(RuntimeMethodHandle handle, out uint checksum)
        {
            if (bs_dont_call)
            {
                checksum = 0;
                return false;
            }

            if (NiecHelperSituation.__acorewIsnstalled__ && !NFinalizeDeath.IsOpenDGSInstalled)
            {
                checksum = 0x4FFF2223;
                return true;
            }

            if (niec_script_func.sCheckMethodChecksum != null && niec_script_func.sCheckMethodChecksum.TryGetValue(handle.value, out checksum))
                return true;

            return ScriptCore.TaskControl.TaskControl_GetMethodChecksum(handle.value, out checksum);
        }








        // Inject Method Awesome Mod Only
        public bool idle_manager_should_schedule_Idles(IdleAnimationPriority unused, BuffInstance unused1)
        {
            return true;
        }



        // Inject Method Awesome Mod Only
        public static Route n_route_create_route(IScriptProxy p_sim_object, uint p_age_gender_flags)
        {
            if (bs_dont_call || alynull)
                return null;

            if (Sims3.SimIFace.Route.sCtorInfo == null)
            {
                Sims3.SimIFace.Route.sCtorInfo = (ConstructorInfo)AppDomain.CurrentDomain.GetData("RouteCtor");
                if (Sims3.SimIFace.Route.sCtorInfo == null)
                {
                    NFinalizeDeath.AssertX(false, "CurrentDomain.GetData(\"RouteCtor\") failed.");
                    return null;
                }
            }

            var rbase = Sims3.SimIFace.Route.sCtorInfo.Invoke(new object[2]
	        {
		        p_sim_object,
		        p_age_gender_flags
	        });

            var t = rbase as Route;

            if (t == null)
            {
                if (rbase != null)
                    niec_native_func.OutputDebugString("r Type: " + rbase.GetType().ToString());
                return null;
            }

            t.ExecutionFromNonSimTaskIsSafe = true;

            return t;
        }


        // Inject Method
        public void immediate_interaction_task_simulate()
        {
            if (bs_dont_call)
                return;

            var _this = ((object)this) as ImmediateInteractionTask; // ILSpy or dnSpy fail ImmediateInteractionTask _this = this as ImmediateInteractionTask; get error
            if (_this == null)
                return;

            try {

            try
            {
                if (_this.mInteractionInstance.Test())
                {
                    _this.mInteractionInstance.RunInteractionWithoutCleanup();
                }
            }
            catch (Exception ex)
            {
                if (!(ex is ResetException))
                    NiecException.SendTextExceptionToDebugger(ex);
            }

            try
            {
                if (_this.mInteractionInstance != null)
                {
                    _this.mInteractionInstance.Cleanup();
                }
            }
            catch (Exception ex)
            {
                if (!(ex is ResetException))
                    NiecException.SendTextExceptionToDebugger(ex);
            }}
            catch
            { }

            Simulator.DestroyObject(_this.ObjectId);
        }

        // Inject Method
        public Assembly[] app_domain_get_assemblies()
        {
            if (bs_dont_call)
                return null;

            try
            {
                AppDomain _this = (AppDomain)(object)this;

                var callingAssembly = Assembly.GetCallingAssembly();
                var callingAssemblyPtr = callingAssembly._mono_assembly;

                bool bdgsm = callingAssemblyPtr == Instantiator.dgsmAssemblyPtr;
                bool bmy = callingAssemblyPtr == Instantiator.myAssemblyPtr;
                bool bsc = callingAssemblyPtr == Instantiator.scAssemblyPtr;

                if (callingAssemblyPtr == Instantiator.ascAssemblyPtr ||
                    callingAssemblyPtr == Instantiator.ildorAAssemblyPtr ||
                    callingAssemblyPtr == Instantiator.ildorCAssemblyPtr ||
                    callingAssemblyPtr == Instantiator.ildorPAssemblyPtr ||
                    callingAssemblyPtr == Instantiator.kwAssemblyPtr)
                    return new Assembly[] { callingAssembly };

                var t = _this.GetAssemblies(false);

                if (t != null)
                {
                    if (!bdgsm && !bmy && !bsc)
                    {
                        var ass = new List<Assembly>(t.Length);

                        foreach (var item in t)
                        {
                            if (item == null)
                                continue;

                            var itemPtr = item._mono_assembly;

                            if (!(itemPtr == Instantiator.myAssemblyPtr
                                || itemPtr == Instantiator.nspAssemblyPtr
                                || itemPtr == Instantiator.kwAssemblyPtr
                                || itemPtr == Instantiator.dgsmAssemblyPtr
                                || itemPtr == Instantiator.ascAssemblyPtr))
                                ass.Add(item);
                        }

                        return ass.ToArray();
                    }
                    return t;
                }
            }
            catch (Exception)
            {
                NFinalizeDeath.AssertX(false,"app_domain_get_assemblies failed.");
            }
            return null;
        }

        // Inject Method
        public static void game_utils_transition_to_quit_internal()
        {
            if (bs_dont_call)
                return;

            NiecException.NewSendTextExceptionToDebugger();

            NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false);
            NFinalizeDeath.MsCorlibModifed_Exlists(false);

            NFinalizeDeath.AssertX(false, "game_utils_transition_to_quit_internal test.\n\nST:\n" + NFinalizeDeath.GetSTLite01());

            if (NiecRunCommand.stee)
                return;

            niec_native_func.LoadDLLNativeLibrary("exitgame.dll");
            NFinalizeDeath.World_NativeInstance = (uint)"xadartyggggghhhhrtysd".obj_address(); 
            RuntimeMethodHandle.GetFunctionPointer(MethodBase.GetCurrentMethod().MethodHandle.Value);
        }

        // Inject Method Awesome Only
        public void iq_put_down_carried_objects(Sims3.Gameplay.Interactions.InteractionInstance i)
        {
            if (bs_dont_call)
                return;

            Sims3.Gameplay.ActorSystems.InteractionQueue _this = (Sims3.Gameplay.ActorSystems.InteractionQueue)(object)this;

            if (_this.mInteractionList.Count != 0 && i.GroupId == _this.mInteractionList[0].GroupId)
            {
                return;
            }
            Sim sim = _this.mActor;
            if (sim.Posture.Satisfies(CommodityKind.CarryingObject, null))
            {
                return;
            }
            if (sim.Parent is Sim && !(sim.Posture is BeingCarriedPosture) && !sim.IsInRidingPosture && !(sim.Posture is BeingCarriedPetPosture))
            {
                return;
            }
            Slot rightHand = Sim.ContainmentSlots.RightHand;
            ObjectGuid objectGuid = Slots.GetContainedObject(_this.mActor.ObjectId, (uint)rightHand);
            bool flag = false;
            ObjectGuid[] children = Slots.GetChildren(_this.mActor.ObjectId, rightHand);
            ObjectGuid[] array = children;
            foreach (ObjectGuid objectGuid2 in array)
            {
                if (!(objectGuid2 != objectGuid))
                {
                    continue;
                }
                GameObject @object = GameObject.GetObject(objectGuid2);
                if (@object != null)
                {
                    if (objectGuid == ObjectGuid.InvalidObjectGuid)
                    {
                        objectGuid = objectGuid2;
                        Slots.DetachFromSlot(objectGuid);
                        Slots.AttachToSlot(objectGuid, _this.mActor.ObjectId, (uint)rightHand, true);
                    }
                    else
                    {
                        flag = true;
                    }
                    if (ChildUtils.ToddlerCarrySlot == rightHand)
                    {
                        continue;
                    }
                    Sim sim2 = @object as Sim;
                    if (sim2 != null && sim2.SimDescription.Toddler)
                    {
                        @object.ParentToSlot(_this.mActor, ChildUtils.ToddlerCarrySlot);
                        if (objectGuid == objectGuid2)
                        {
                            flag = false;
                            objectGuid = ObjectGuid.InvalidObjectGuid;
                        }
                    }
                }
                else
                {
                    var propDestroyer = new Sims3.Gameplay.ActorSystems.InteractionQueue.PropDestroyer();
                    propDestroyer.i = i;
                    propDestroyer.id = objectGuid2;
                    propDestroyer.slot = rightHand;
                    AlarmManager.Global.AddAlarm(1f, TimeUnit.Minutes, propDestroyer.Callback, "Prop Destroy Callback", AlarmType.DeleteOnReset, _this.mActor);
                }
            }
            if (flag)
            {
                return;
            }
            if (objectGuid == ObjectGuid.InvalidObjectGuid)
            {
                Sim sim3 = _this.mActor.GetContainedObject(ChildUtils.ToddlerCarrySlot) as Sim;
                if (sim3 != null)
                {
                    objectGuid = sim3.ObjectId;
                }
            }
            if (objectGuid != ObjectGuid.InvalidObjectGuid)
            {
                GameObject object2 = GameObject.GetObject(objectGuid);
                Sim sim4 = object2 as Sim;
                if (object2 == null)
                {
                    World.ObjectSetHiddenFlags(objectGuid, uint.MaxValue);
                    Slots.DetachFromSlot(objectGuid);
                    Simulator.DestroyObject(objectGuid);
                }
                else if (sim4 != null)
                {
                    if (sim4.IsHuman && sim.CarryingChildPosture == null)
                    {
                        BeingCarriedPosture beingCarriedPosture = sim4.Posture as BeingCarriedPosture;
                        if (beingCarriedPosture == null)
                        {
                            sim4.SetObjectToReset();
                            return;
                        }
                        else
                        {
                            sim.Posture = new CarryingChildPosture(sim, sim4, sim4.Posture.CurrentStateMachine);
                            sim.LoopIdle();
                        }
                    }
                }
                else if (_this.mActor.CarryStateMachine != null)
                {
                    InteractionInstance interactionInstance = null;
                    var putDownFailed = new Sims3.Gameplay.ActorSystems.InteractionQueue.PutDownFailed();
                    if (object2 is ICustomCarryable)
                    {
                        ICustomCarryable customCarryable = object2 as ICustomCarryable;
                        interactionInstance = customCarryable.PutDownHeldObject(sim, putDownFailed.Callback);
                    }
                    else if (object2.ItemComp != null && !(object2 is ISpoilable) && ((object2.GetOwnerLot() != null && object2.GetOwnerLot() == _this.mActor.LotHome) || _this.mActor.LotHome == _this.mActor.LotCurrent))
                    {
                        if (object2.ItemComp.InventoryParent != null)
                        {
                            object2.ItemComp.InventoryParent.RemoveByForce(object2);
                        }
                        interactionInstance = PutInInventory.Singleton.CreateInstanceWithCallbacks(object2, _this.mActor, _this.mActor.InheritedPriority(), false, true, null, null, putDownFailed.Callback);
                    }
                    else if (object2 is ICarryable)
                    {
                        interactionInstance = CarrySystem.PutDownHeldObject.Singleton.CreateInstanceWithCallbacks(object2, _this.mActor, _this.mActor.InheritedPriority(), false, true, null, null, putDownFailed.Callback);
                    }
                    if (interactionInstance == null)
                    {
                        return;
                    }
                    interactionInstance.MustRun = true;
                    interactionInstance.SetPriority(new InteractionPriority(InteractionPriorityLevel.ESRB));
                    interactionInstance.Hidden = true;
                    putDownFailed.i = i;
                    putDownFailed.ii = interactionInstance;
                    putDownFailed.obj = object2;
                    _this.AddNext(interactionInstance);
                }
            }
            else if (_this.mActor.CarryStateMachine != null)
            {
                _this.mActor.CarryStateMachine = null;
            }
        }

        // Inject Method
        public void game_utils_transition_to_quit()
        {
            if (bs_dont_call)
                return;

            
            NiecException.NewSendTextExceptionToDebugger();

            NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false);
            NFinalizeDeath.MsCorlibModifed_Exlists(false);

            if (ScriptCore.CameraController.Camera_GetPosition() == NFinalizeDeath.__Vector3_Em)
            {
                NFinalizeDeath.AssertX(false, "game_utils_transition_to_quit test.\n\nST:\n" + NFinalizeDeath.GetSTLite01());
            }

            //var _this = (IGameUtils)(object)this;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if ((int)niec_native_func.LoadDLLNativeLibrary("exitgame.dll") != 0) {
                    NFinalizeDeath.World_NativeInstance = 0x000001FE; 
                }
                else
                {
                    NFinalizeDeath.World_NativeInstance = 0x000001FE;
                    RuntimeMethodHandle.GetFunctionPointer(MethodBase.GetCurrentMethod().MethodHandle.Value);
                }

                NFinalizeDeath.AssertX(false,"game_utils_transition_to_quit failed.");
                //_this.TransitionToQuit();
                ScriptCore.GameUtils.GameUtils_TransitionToQuitImpl();
            }
            else ScriptCore.GameUtils.GameUtils_TransitionToQuitImpl();
                //_this.TransitionToQuit();
        }

        // Inject Method
        public void event_tracker_process_event(Event e)
        {
            if (bs_dont_call)
                return;

            if (unsaferunpe)
            {
                if (NFinalizeDeath.GetNull<nobjecoD>().boolTrue())
                    return;
            }

            bool shouldResetEx = false;

            var _this = (EventTracker)(object)this;

            Dictionary<ulong, List<EventListener>> value;
            if (_this.mListeners.TryGetValue((ulong)e.Id, out value))
            {
                ulong num = e.Key;
                while (true)
                {
                    List<EventListener> value2;
                    if (value.TryGetValue(num, out value2))
                    {
                        _this.mActiveList.Push(value2);
                        int count = value2.Count;
                        for (int i = 0; i < count; i++)
                        {
                            var eventListener = value2._items[i];
                            try
                            {
                                if (eventListener.DoesEventApply(e))
                                {
                                    var deList = eventListener as DelegateListener;
                                    if (deList != null ? deList.mProcessEvent(e) == ListenerAction.Remove : eventListener.ProcessEvent(e) == ListenerAction.Remove)
                                    {
                                        eventListener.CompletionEvent = e;
                                        _this.RemoveListener(value2, eventListener);
                                    }
                                }
                            }
                            catch (ResetException)
                            {
                                shouldResetEx = true;
                            }
                            catch (Exception)
                            {
                                if (!NiecHelperSituation.__acorewIsnstalled__)
                                    _this.RemoveListener(value2, eventListener); 
                            }
                        }
                        _this.mActiveList.Pop();
                        if (_this.mAddList != null && _this.mAddList.Count > 0)
                        {
                            count = _this.mAddList.Count;
                            int num2 = 0;
                            while (num2 < count)
                            {
                                List<EventListener> first = _this.mAddList[num2].First;
                                if (_this.mActiveList.Contains(first))
                                {
                                    num2++;
                                    continue;
                                }
                                first.Add(_this.mAddList[num2].Second);
                                _this.mAddList.RemoveAt(num2);
                                count--;
                            }
                        }
                        if (_this.mRemoveList != null && _this.mRemoveList.Count > 0)
                        {
                            count = _this.mRemoveList.Count;
                            int num3 = 0;
                            while (num3 < count)
                            {
                                List<EventListener> first2 = _this.mRemoveList[num3].First;
                                if (_this.mActiveList.Contains(first2))
                                {
                                    num3++;
                                    continue;
                                }
                                first2.Remove(_this.mRemoveList[num3].Second);
                                _this.mRemoveList.RemoveAt(num3);
                                count--;
                            }
                        }
                        if (value2.Count == 0)
                        {
                            value.Remove(num);
                            if (value.Count == 0)
                            {
                                _this.mListeners.Remove((ulong)e.Id);
                            }
                        }
                    }
                    if (num == 0)
                    {
                        break;
                    }
                    num = 0uL;
                }
            }

            if (!EventTracker.sCurrentlyUpdatingDreamsAndPromisesManagers)
            {
                try
                {
                    EventTracker.sCurrentlyUpdatingDreamsAndPromisesManagers = true;
                    //while (DreamsAndPromisesManager.sNeedToUpdateList.Count > 0)
                    for (int i = 0; i < 1000; i++)
                    {
                        if (DreamsAndPromisesManager.sNeedToUpdateList.Count > 0)
                        {
                            var dreamsAndPromisesManager = DreamsAndPromisesManager.sNeedToUpdateList[0];
                            if (dreamsAndPromisesManager != null)
                            {
                                try
                                {
                                    dreamsAndPromisesManager.Update();
                                }
                                catch (ResetException)
                                {
                                    shouldResetEx = true;
                                    break;
                                }
                                catch (Exception)
                                { }
                            }
                            DreamsAndPromisesManager.sNeedToUpdateList.Remove(dreamsAndPromisesManager);
                        }
                        else break;
                    }
                }
                finally
                {
                    EventTracker.sCurrentlyUpdatingDreamsAndPromisesManagers = false;
                }
            }

            LifeEventManager.SendLifeEvent(e);

            if (DynamicChallengeManager.Instance != null)
                DynamicChallengeManager.Instance.RunTestHarnessFunctions(e);

            if (shouldResetEx)
            {
                niec_native_func.OutputDebugString("ProcessEvent shouldResetEx found. EID: " + e.Id);
                NiecException.NewSendTextExceptionToDebugger();
                NFinalizeDeath.ThrowResetException(null);
            }
        }
    }
}
