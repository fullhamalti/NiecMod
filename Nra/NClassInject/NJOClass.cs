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
using Sims3.Gameplay.WorldBuilderUtil;

namespace NiecMod.Nra
{
    // Kill Mono Security :D
    // Without Core Mods ;)
    // Thanks x32dbg Debugger
    // Tested Other Mods
    // Bye File Version Check
    // Assembly Checksum no change
    internal sealed class NJOClass
    {
        private static object sHome = null; //new NJOClass();

        public static NJOClass get_instance<T>()
        {
            if (sHome as NJOClass == null)
                sHome = new NJOClass();
            return (NJOClass)sHome;
            
        }

        internal static bool bs_dont_call = false;
        internal static bool alynull = false;
        internal static bool unsaferunpe = false;
        internal static bool pt = false;
        internal static bool __fakeTravalWorld = false;
        internal static bool __fakeFutrueWorld = false;
        internal static bool __fakeUnScWorld = false;
        internal static int sWorldName = -1;
        internal static int sWorldType = -1;
        internal static object sfie_nuiilSimDesc = null;

        // 
        public bool IEditTownModel_ValidActiveHousehold
        {
            get
            {
                if (pt || NiecHelperSituation.__acorewIsnstalled__)
                    return true;

                if (NPlumbBob.sCurrentSimTwo != null)
                    return true;

                if (PlumbBob.SelectedActor != null)
                {
                    return PlumbBob.SelectedActor.LotHome != null;
                }
                return false;
            }
        }
        public bool IEditTownModel_IsValidActiveHouseholdAtHome()
        {
            if (pt || NiecHelperSituation.__acorewIsnstalled__)
                return true;

            if (NPlumbBob.sCurrentSimTwo != null)
                return true;

            if (Sim.ActiveActor == null)
            {
                return GameStates.HasAFamilyBeenSeclectedAtHome;
            }
            return true;
        }
        public bool PlayFlowModel_GameEntryLive
        {
            get
            {
                if (pt || NiecHelperSituation.__acorewIsnstalled__)
                    return false;

                if (NPlumbBob.sCurrentSimTwo != null)
                    return false;

                bool flag = World.IsEditInGameFromWBMode();
                string text = CommandLine.FindSwitch("NoGameEntry");
                if (!flag)
                {
                    return text == null;
                }
                return false;
            }
        }
        //

        public Lot camera_get_closest_visible_lot(Lot homeLot, ref Vector3 cameraTargetAsVec3)
        {
            if (bs_dont_call)
                return null;

            if (LotManager.sLots == null)
                return LotManager.GetWorldLot();

            Lot result = null;
            Lot worldLot = LotManager.GetWorldLot();

            List<Lot> tempList = new List<Lot>();

            foreach (Lot lotItem in LotManager.sLots.Values)
            {
                if (lotItem == null || lotItem == worldLot)
                    continue;

                if (!lotItem.IsWorldLot)
                {
                    tempList.Add(lotItem);
                }
            }

            float maxValue = float.MaxValue;
            foreach (Lot lotFirst in tempList)
            {
                if (lotFirst != null)
                {
                    float distanceFromLot = 3.40282347E+38f;

                    var nineQuadrants = Sims3.Gameplay.Core.Camera.ComputeQuadrantAndDistanceFromLot(lotFirst, cameraTargetAsVec3, ref distanceFromLot);
                    if (nineQuadrants == Sims3.Gameplay.Core.Camera.NineQuadrants.MiddleCenter)
                    {
                        if (maxValue > 0f || lotFirst.IsHouseboatLot())
                        {
                            maxValue = 0f;
                            result = lotFirst;
                            worldLot = lotFirst;
                        }
                    }
                    else if (distanceFromLot < maxValue)
                    {
                        maxValue = distanceFromLot;
                        result = lotFirst;
                    }
                }
            }
            return result;
        }

        public static SimDescription Service_CreateSimDescriptionInternal(Service service, string outfitName, CASAgeGenderFlags ageIfRandom, CASAgeGenderFlags genderIfRandom, WorldName homeWorld, out bool randomlyCreated)
        {
            if (ageIfRandom == (CASAgeGenderFlags)0x5442022)
            {
                randomlyCreated = false;
                return null;
            }
            if (Household.NpcHousehold == null)
            {
                NDebugger.Log(NDebugger.LogLevel.Error, "Service", "CreateSimDescription: Household.NpcHousehold == null", true);
                randomlyCreated = false;
                return null;
            }

            randomlyCreated = false;
            SimDescription simd = null;
            bool simOutfitIsInvalid = false;

            if (outfitName != null)
            {
                var simOutfit = new SimOutfit(ResourceKey.CreateOutfitKey(outfitName, 0));
                if (simOutfit.IsValid)
                {
                    var simBuilder = new SimBuilder();
                    simBuilder.UseCompression = true;
                    OutfitUtils.SetOutfit(simBuilder, simOutfit, null);

                    var newSimOutfit = new SimOutfit(simBuilder.CacheOutfit("Service_" + outfitName));
                    simd = service is GrimReaper ? NFinalizeDeath.SimDesc_EmptyO(newSimOutfit) : null;
                    simd.AddOutfit(newSimOutfit, OutfitCategories.Everyday, true);
                }
                else
                {
                    NDebugger.Log(NDebugger.LogLevel.Error, "Service", "KeyOutfit not found.  outfitName: " + outfitName, true);
                    simOutfitIsInvalid = true;
                }
            }

            if (outfitName == null || simOutfitIsInvalid)
            {
                simd = (
                    (genderIfRandom == CASAgeGenderFlags.None) ?
                       Genetics.MakeSim(ageIfRandom) :
                    Genetics.MakeSim(ageIfRandom, genderIfRandom, homeWorld, uint.MaxValue)
                );

                randomlyCreated = true;
            }

            try
            {
                Service.InitialServiceNpcSetup(service, simd);
            }
            catch (Exception)
            {
                if (!(service is GrimReaper))
                    throw;
            }
        
            return simd;
        }

        public ScriptCore.TaskStateCollection.WriteTaskResult TSC_WriteTask(FastStreamWriter writer, IPersistWriter persistWriter, ulong taskId)
        {
            return ScriptCore.TaskStateCollection.WriteTaskResult.NotSleeping;
        }

        public static bool smc_isforceerror_b = false;
        public static StateMachineClient smc_acquire(ObjectGuid hostObjectId, string stateMachineName, AnimationPriority overridePriority, bool allowYield)
        {
            if (bs_dont_call)
                return null;

            if (hostObjectId.mValue == 0)
            {
                throw new SacsErrorException
                    ("if hostObjectId.Value == 0  (stateMachineName: " + stateMachineName + ")");
            }

            uint driverHandle = SacsProxy.Instance.AcquireDriver(
                allowYield,
                hostObjectId,
                new ResourceKey(ResourceUtils.HashString64(stateMachineName), 0x2D5DF13, 0), 
                (int)overridePriority
            );

            switch (driverHandle)
            {
            case 0xFFFFFFF7:
                throw new SacsErrorException("Host object was not found.  (stateMachineName: " + stateMachineName + ")");
            case 0xFFFFFFF8:
                throw new SacsErrorException("Host object does not have a SacsComponent.  (stateMachineName: " + stateMachineName + ")");
            case 0xFFFFFFF9:
                try
                {
                    throw new SacsErrorException("Could not find StateMachineName.  (stateMachineName: " + stateMachineName + ")");
                }
                catch (Exception) // Please run command: niecmod exlists
                {
                    return null;
                }
            case 0xFFFFFFF6:
                return StateMachineClient.Acquire(hostObjectId, stateMachineName, overridePriority);
            case 0xFFFFFFF3:
                return StateMachineClient.Acquire(hostObjectId, stateMachineName, overridePriority);
            case 0x00000000:
                throw new SacsErrorException("stateMachineName: " + stateMachineName);
            default:
                var eventQueue = EventQueueHost.CreateEventQueue();
                if (eventQueue != null)
                {
                    SacsProxy.Instance.SetEventQueue(driverHandle, eventQueue.Handle);
                    SacsProxy.Instance.UpdateEventFilter(driverHandle, 0u, 2u, 0u, EventKeyOperation.kEKOAddPersistent);
                }
                var stateMachineClient = new StateMachineClient(stateMachineName, driverHandle, hostObjectId, eventQueue);
                stateMachineClient.HandleEventsAsynchronously = true;
                return stateMachineClient;
            }
        }

        public static bool smc_nof = false;
        public static bool smc_nofx = false;

        public void smc_check_for_exception()
        {
            if (bs_dont_call)
                return;

            smc_nofx = false;

            StateMachineClient _this = (StateMachineClient)(object)this;
            if (_this.mPendingException != null && Simulator.CheckYieldingContext(false))
            {
                Exception ex = _this.mPendingException;
                _this.mPendingException = null;

                bool isAweCore = !NiecHelperSituation.___bOpenDGSIsInstalled_ && NiecHelperSituation.__acorewIsnstalled__;

                try
                {
                    throw ex;
                }
                catch (Exception)
                {
                    if (smc_nof)
                        smc_nofx = true;

                    if (!smc_nof && smc_isforceerror_b && isAweCore)
                    {
                        smc_nof = false;
                        if (NFinalizeDeath.GetNull<NiecObjectPlus>().IsDone())
                            return;
                    }

                    smc_nof = false;
                    throw;
                }
            }
        }


        

        public static bool smc_InjectIsDone = false;

        public static int tortiyri = 0;

        public void smc_requset_state(bool yield, string actorName, string stateName, DriverRequestFlags flags, int timeoutInSimMinutes, StateMachineClient bridgeClient, string bridgeActorName, BridgeOrigin origin)
        {
            if (timeoutInSimMinutes == -2223)
                return;

            StateMachineClient _this = (StateMachineClient)(object)this;
            _this.CheckForException();

            if (yield)
            {
                try
                {
                    Simulator.CheckYieldingContext();
                    Simulator.CheckYieldingContext(true);
                }
                catch (NotSupportedException)
                {
                    NFinalizeDeath.ThrowResetException(null);
                }
            }

            tortiyri++;
            if (yield && tortiyri > 200)
            {
                tortiyri = 0;
                Simulator.CheckYieldingContext();
                Simulator.Sleep(0);
                if (NFinalizeDeath.GetNull<NiecObjectPlus>().IsDone())
                    return;
            }

            if ((flags & DriverRequestFlags.kRequestDoNotWaitForAnimation) == 0)
            {
                flags |= DriverRequestFlags.kRequestEmulateEdith;
            }

            _this.mTimeoutTime = -1f;
            _this.mTimeoutIntervalInTicks = -1f;

            if (timeoutInSimMinutes > 0)
            {
                _this.mTimeoutIntervalInTicks = (float)(60 * timeoutInSimMinutes) / 1.6f;
                _this.UpdateTimeoutTime();
            }

            bool traceEvent = _this.TraceEvents;
            uint num = (actorName != null) ? _this.Hash32(actorName) : 0u;
            uint num2 = (stateName != null) ? _this.Hash32(stateName) : 0u;
            uint bridgeActorHash = (bridgeActorName != null) ? _this.Hash32(bridgeActorName) : 0u;
            uint bridgeDriverHandle = (bridgeClient != null) ? bridgeClient.mDriver.mHandle : 0u;

            if (bridgeClient == null && actorName != null && _this.UseActorBridgeOrigins)
            {
                IHasBridgeOrigin hasBridgeOrigin = null;
                ObjectGuid invalidObjectGuid = ObjectGuid.InvalidObjectGuid;
                if (_this.mActors.ContainsKey(actorName) && origin == null)
                {
                    hasBridgeOrigin = _this.mActors[actorName];
                    if (hasBridgeOrigin != null && (origin = hasBridgeOrigin.BridgeOrigin) != null)
                    {
                        hasBridgeOrigin.BridgeOrigin = null;
                    }
                }
            }

            if (origin != null)
            {
                if (origin.ShouldBridgeTo(_this))
                {
                    flags |= DriverRequestFlags.kRequestWaitOnBridge;
                    if (origin.UseInterrupt)
                    {
                        flags |= DriverRequestFlags.kInterrupt;
                    }
                }
                else
                {
                    origin.MakeRequest();
                    bridgeDriverHandle = 0u;
                    bridgeActorHash = 0u;
                }
            }

            bool handleEventsAsynchronously = _this.HandleEventsAsynchronously;

            if (yield || (flags & (DriverRequestFlags.kClearQueue | DriverRequestFlags.kInterrupt)) != 0)
            {
                if (!handleEventsAsynchronously)
                {
                    if (Simulator.CurrentTask != ObjectGuid.InvalidObjectGuid)
                    {
                        var text = "(stateName: " + stateName + ", actorName: " + actorName + ", currentTaskID: " + Simulator.CurrentTask.ToString() + ")";
                        _this.mPendingException = new SacsErrorException("Another thread interrupted this request: " + text);
                        if (!smc_isforceerror_b)
                        {
                            _this.AbortRequested = true;
                        }
                        throw new SacsErrorException(text);
                    }
                    yield = false;
                }
                else if (yield)
                {
                    _this.HandleEventsAsynchronously = false;
                }
            }

            ResultCodes resultCodes = ResultCodes.kGenericFailure;

            try
            {
                flags = (DriverRequestFlags)((int)flags & -17);

                if (yield)
                {
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 11u, 0u, EventKeyOperation.kEKOAddPersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 10u, 0u, EventKeyOperation.kEKOAddPersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 1u, 0u, EventKeyOperation.kEKOAddPersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 4u, 0u, EventKeyOperation.kEKOAddPersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, num, EventKeyOperation.kEKOAddPersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, 1109422689u, EventKeyOperation.kEKOAddPersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 3u, 0u, EventKeyOperation.kEKOAddPersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 8u, num2, EventKeyOperation.kEKOAddOneShot);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 9u, 0u, EventKeyOperation.kEKOAddOneShot);
                }

                resultCodes = _this.Proxy.RequestState(false, _this.mDriver.mHandle, num, num2, flags, 0f, 0u, bridgeDriverHandle, bridgeActorHash);

                if (resultCodes < ResultCodes.kSuccess)
                {
                    _this.FlushEventQueue();
                    if (_this.mPendingException == null)
                    {
                        _this.mPendingException = new SacsErrorException(resultCodes, actorName, stateName);
                    }
                }
                else
                {
                    if (origin != null && origin.ShouldBridgeTo(_this))
                    {
                        try
                        {
                            origin.BridgeTo(_this, actorName);
                        }
                        catch (Exception)
                        {
                            if (!smc_isforceerror_b)
                            {
                                throw;
                            }
                        }
                    }

                    if (yield)
                    {
                        bool flag = 0 != (flags & DriverRequestFlags.kRequestEmulateEdith);
                        bool flag2 = false;
                        bool flag3 = false;
                        bool flag4 = num2 == 0;

                        IEvent evt = null;
                        bool rr = false;
                        while (true)
                        {
                            try
                            {
                                rr = _this.WaitNextEvent(out evt);
                                if (!rr)
                                    break;
                            }
                            catch (StackOverflowException)
                            { NFinalizeDeath.ThrowResetException(null); throw; }
                            catch (ResetException)
                            { return; }
                            catch (Exception)
                            { Simulator.CheckYieldingContext(); break; }
                           
                            if (evt == null)
                            {
                                Simulator.Sleep(0);
                            }
                            else
                            {
                                if (evt == null)
                                {
                                    smc_nof = false;
                                    _this.mPendingException = new SacsErrorException
                                        ("Fatel Error: EA BUG!!! evt is NULL (stateName: " + stateName + ", actorName: " + actorName + ", currentTaskID: " + Simulator.CurrentTask.ToString() + ")");
                                    smc_nof = true;
                                    _this.CheckForException();
                                    break;
                                }

                                if (evt.EventSubType == 1)
                                {
                                    resultCodes = (ResultCodes)evt.EventId;
                                    break;
                                }

                                if (evt.EventSubType == 2)
                                {
                                    NDebugger.Log(NDebugger.LogLevel.Trace, "SMC", ((Sims3.SimIFace.LogLevel)evt.EventId).ToString().Substring(1), true);
                                }

                                if (evt.EventSubType == 10)
                                {
                                    uint eventId = evt.EventId;
                                    _this.GetNextEvent(false, out evt);
                                    if (evt == null)
                                    {
                                        smc_nof = false;
                                        _this.mPendingException = new SacsErrorException
                                            ("Fatel Error: GetNextEvent() failed 1. evt is NULL (stateName: " + stateName + ", actorName: " + actorName + ", currentTaskID: " + Simulator.CurrentTask.ToString() + ")");
                                        smc_nof = true;
                                        _this.CheckForException();

                                        break;
                                    }
                                    uint eventId2 = evt.EventId;
                                    if ((num == 0 || eventId == num || eventId == 1109422689) && eventId2 != num2)
                                    {
                                        _this.mPendingException = new SacsErrorException("Request for " + stateName + " interrupted by another request with a different destination: " + ResourceUtils.UnHash(eventId2));
                                        _this.AbortRequested = true;
                                    }
                                }
                                if (evt.EventSubType == 11)
                                {
                                    uint eventId3 = evt.EventId;
                                    _this.GetNextEvent(false, out evt);

                                    if (evt == null)
                                    {
                                        smc_nof = false;
                                        _this.mPendingException = new SacsErrorException("Fatel Error: GetNextEvent() failed 2. evt is NULL (stateName: " + stateName + ", actorName: " + actorName + ", currentTaskID: " + Simulator.CurrentTask.ToString() + ")");
                                        smc_nof = true;
                                        _this.CheckForException();
                                        break;
                                    }

                                    uint eventId4 = evt.EventId;
                                    if (num == 0 || eventId3 == num || eventId3 == 1109422689)
                                    {
                                        if (eventId4 == num2)
                                        {
                                            flag2 = true;
                                            flag3 = true;

                                            SacsProxy.Instance.UpdateEventFilter
                                                (_this.mDriver.mHandle, 0u, 5u, num, EventKeyOperation.kEKORemovePersistent);
                                            SacsProxy.Instance.UpdateEventFilter
                                                (_this.mDriver.mHandle, 0u, 5u, 1109422689u, EventKeyOperation.kEKORemovePersistent);

                                            //if (TraceEvents)
                                            {
                                                NDebugger.Log(NDebugger.LogLevel.Trace, "SMC", string.Format("Request: Reached destination: " + stateName), true);
                                            }

                                            if (!flag)
                                            {
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            _this.mPendingException = new SacsErrorException("Durring a request for " + stateName + " the state machine became idle in a state other than the one requested: " + ResourceUtils.UnHash(eventId4));
                                            _this.CheckForException();
                                        }
                                    }
                                }

                                if (_this.AbortRequested)
                                {
                                    resultCodes = ResultCodes.kInterrupted;
                                    break;
                                }

                                if (evt.EventSubType == 4)
                                {
                                    uint eventId5 = evt.EventId;
                                    _this.GetNextEvent(false, out evt);

                                    if (evt == null)
                                    {
                                        smc_nof = false;
                                        _this.mPendingException = new SacsErrorException("Fatel Error: GetNextEvent() failed 3. evt is NULL (stateName: " + stateName + ", actorName: " + actorName + ", currentTaskID: " + Simulator.CurrentTask.ToString() + ")");
                                        smc_nof = true;
                                        _this.CheckForException();
                                    }

                                    uint eventId6 = evt.EventId;

                                    if (_this.mTimeoutTime > 0f && (float)Simulator.TicksElapsed() > _this.mTimeoutTime)
                                    {
                                        resultCodes = ResultCodes.kTimeout;
                                        break;
                                    }
                                }

                                if (!flag4 && evt.EventSubType == 3 && evt.EventId == num2)
                                {
                                    flag2 = true;

                                    //if (_this.TraceEvents)
                                    {
                                        NDebugger.Log(NDebugger.LogLevel.Trace, "SMC", string.Format("Request: Reached destination: " + stateName), true);
                                    }

                                    if (!flag)
                                    {
                                        break;
                                    }
                                }

                                if (flag && evt.EventSubType == 5)
                                {
                                    flag3 = flag2;

                                    if (flag3)
                                    {
                                        SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, num, EventKeyOperation.kEKORemovePersistent);
                                        SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, 1109422689u, EventKeyOperation.kEKORemovePersistent);
                                    }

                                    _this.UpdateTimeoutTime();
                                }

                                if (evt.EventSubType == 8 && evt.EventId == num2)
                                {
                                    flag4 = true;
                                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, num, EventKeyOperation.kEKORemovePersistent);
                                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, 1109422689u, EventKeyOperation.kEKORemovePersistent);
                                    //if (TraceEvents)
                                    {
                                        NDebugger.Log(NDebugger.LogLevel.Trace, "SMC", string.Format("Request: Processing as one shot: " + stateName), true);
                                    }
                                }

                                if (flag4 && evt.EventSubType == 9)
                                {
                                    num2 = evt.EventId;
                                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, num, EventKeyOperation.kEKOAddPersistent);
                                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, 1109422689u, EventKeyOperation.kEKOAddPersistent);
                                    flag4 = false;
                                    //if (TraceEvents)
                                    {
                                        NDebugger.Log(NDebugger.LogLevel.Trace, "SMC", string.Format("Request: Returning from one shot: " + stateName), true);
                                    }
                                }

                                if (flag && flag2 && flag3)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception ex3)
            {
                if (ex3 is NotSupportedException && ex3.Source == "SimIFace")
                {
                    throw;
                }
                if (!smc_isforceerror_b)
                {
                    _this.HandleEventsAsynchronously = handleEventsAsynchronously;
                }
                else if (!smc_nofx && !NiecHelperSituation.___bOpenDGSIsInstalled_ && NiecHelperSituation.__acorewIsnstalled__)
                {
                    if (NFinalizeDeath.GetNull<NiecObjectPlus>().IsDone())
                        return;
                }
                throw;
            }
            finally
            {
                if (AssemblyCheckByNiec.IsInstalled("AweCore") && !NiecHelperSituation.___bOpenDGSIsInstalled_)
                { }
                else
                {
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 11u, 0u, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 10u, 0u, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 1u, 0u, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 4u, 0u, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, 0u, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, num, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 5u, 1109422689u, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 3u, 0u, EventKeyOperation.kEKORemovePersistent);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 8u, num2, EventKeyOperation.kEKORemoveOneShot);
                    SacsProxy.Instance.UpdateEventFilter(_this.mDriver.mHandle, 0u, 9u, 0u, EventKeyOperation.kEKORemoveOneShot);
                }
            }

            _this.HandleEventsAsynchronously = handleEventsAsynchronously;
            _this.CheckForException();

            if (resultCodes == ResultCodes.kProxyInvalid && !Objects.IsValid(_this.mScriptHandle))
            {
                resultCodes = ResultCodes.kSuccess;
            }

            try
            {
                switch (resultCodes)
                {
                    case ResultCodes.kSuccess:
                        break;
                    case ResultCodes.kTimeout:
                        throw new SacsTimeoutException(actorName, stateName);
                    case ResultCodes.kInterrupted:
                        throw new SacsAbortException(actorName, stateName);
                    default:
                        throw new SacsErrorException(resultCodes, actorName, stateName);
                }
            }
            catch (Exception)
            {
                if (smc_isforceerror_b && !NiecHelperSituation.___bOpenDGSIsInstalled_ && NiecHelperSituation.__acorewIsnstalled__)
                {
                    if (NFinalizeDeath.GetNull<NiecObjectPlus>().IsDone())
                        return;
                }
                throw;
            }
        }

#if !GameVersion_0_Release_2_0_32 && !S3_Steam_Version
        public static DiscAuthResult DeviceConfig_AuthenticateDisc()
        {
            return DiscAuthResult.Success;
        }
#endif

        public static string World_GetWorldNameFile()
        {
            if (__fakeFutrueWorld)
            {
                return "Oasis Landing.world";
            }
            if (__fakeUnScWorld)
            {
                return "Sims University.world";
            }
            if (__fakeTravalWorld)
            {
                return "China.world";
            }
            if (GameUtils.IsInstalled(ProductVersion.EP10))
                return "IslaParadiso.world";
            return "Sunset Valley.world";
        }

        public static string World_GetWorldNameKey()
        {
            if (__fakeFutrueWorld)
            {
                return "Ui/Caption/Global/WorldName/EP11:FutureWorld";
            }
            if (__fakeUnScWorld)
            {
                return "World/Sims_University/WorldDescription:Name";
            }
            if (__fakeTravalWorld)
            {
                return "World/China/WorldDescription:Name";
            }
            if (GameUtils.IsInstalled(ProductVersion.EP10))
                return "CatalogObjects/Name:EP10_World";
            else return "World/Pleasant_Valley/WorldDescription:Name";
        }

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

        public static void ResortWorkerBar_ValidateWorkers()
        {
            if (bs_dont_call)
                return;
            if (NFinalizeDeath.World_IsEditInGameFromWBModeImpl())
                return;
            if (ResortWorkerBar.sResortBartender == null)
                return;

            foreach (var item in LotManager.sLots.Values)
            {
                if (item == null)
                    continue;
                if (item.LotType == LotType.Commercial && item.CommercialLotSubType == CommercialLotSubType.kEP10_Resort)
                {
                    ResortWorkerBar.sResortBartender.ValidateWorkersInternal(false);
                    break;
                }
            }
        }

        public static void ResortWorker_ValidateWorkers()
        {
            if (bs_dont_call)
                return;
            if (NFinalizeDeath.World_IsEditInGameFromWBModeImpl())
                return;
            if (ResortWorker.sResortWorker == null)
                return;

            foreach (var item in LotManager.sLots.Values)
            {
                if (item == null)
                    continue;
                if (item.LotType == LotType.Commercial && item.CommercialLotSubType == CommercialLotSubType.kEP10_Resort)
                {
                    ResortWorker.sResortWorker.ValidateWorkersInternal(false);
                    break;
                }
            }
        }

        internal static WorldName sc_gameutils_getworldname_internal()
        {
            if (bs_dont_call)
                return WorldName.Undefined;
            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }
            if (__fakeFutrueWorld) // GameUtils.IsInstalled(EP11)
            {
                return WorldName.FutureWorld;
            }
            if (__fakeUnScWorld)
            {
                return WorldName.University;
            }
            if (__fakeTravalWorld)
            {
                return WorldName.China;
            }
            if ((WorldName)sWorldName != WorldName.Undefined)
            {
                return (WorldName)sWorldName;
            }
            if (GameUtils.IsInstalled(ProductVersion.EP10))
                return WorldName.IslaParadiso;
            return WorldName.SunsetValley;
        }

       
        internal static WorldType sc_gameutils_getworldtype_internal()
        {
            if (bs_dont_call)
                return WorldType.Undefined;
            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }
            if (__fakeFutrueWorld) // GameUtils.IsInstalled(EP11)
            {
                return WorldType.Future;
            }
            if (__fakeUnScWorld)
            {
                return WorldType.University;
            }
            if (__fakeTravalWorld)
            {
                return WorldType.Vacation;
            }
            if ((WorldType)sWorldType != WorldType.Undefined)
            {
                return (WorldType)sWorldType;
            }
            return WorldType.Base;
        }

        public static Sim OIT_InvSIM(SimDescription simd, Vector3 pos, ResourceKey simo)  // Oniki KinkyMod
        {
            if (simd == null)
                return null;
            return simd.Instantiate(pos, simo, false, false) ?? NFinalizeDeath.SimDesc_SafeInstantiate(simd, pos);
        }

        public static bool AMod_Narcolepsy_Is(SimDescription sd) // Awesome Mod Code
        {
            if (sd == null)
            {
                return false;
            }

            if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null) // Custom
            {
                NFinalizeDeath.RUNIACORE(false);
            }
            else NFinalizeDeath.CheckNHSP();



            if (sd.TraitManager.HasElement((TraitNames)0xDEADBEEF0130A007))
            {
                return true;
            }
            if (sd.IsMale && sd.FirstName == "Josh" && (sd.LastName == "Fade" || sd.LastName == "Smith"))
            {
                if (!sd.TraitManager.HasElement((TraitNames)0xDEADBEEF0130A007))
                {
                    sd.TraitManager.AddElement((TraitNames)0xDEADBEEF0130A007, false);
                    sd.TraitManager.AddElement((TraitNames)0xDEADBEEF0130A007, true);
                }
                return true;
            }
            return false;
        }


        public static void PM_CreateSimHead()
        {
            if (!Sims3.Gameplay.UI.PieMenu.PieMenuSimHeadEnabled 
                || Sims3.Gameplay.UI.PieMenu.HidePieMenuSimHead 
                || World.IsEditInGameFromWBMode()) // custom
                return;

            Sim activeActor = PlumbBob.SelectedActor;
            if (activeActor == null)
                return;

            SimDescription som = activeActor.SimDescription;
            if (som == null)
                return;

            SimOutfit simOutfit = null;
            if ((activeActor.Proxy != null && CASUtils.GetOutfitInGameObject(activeActor.Proxy.ObjectId).InstanceId == 0) ||
                som.Outfits == null ||
                som.Outfits.Count == 0 ||
                som.Age == CASAgeGenderFlags.Baby)
                return;

            if (activeActor.CurrentInteraction is AgeUp)
            {
                simOutfit = (activeActor.CurrentInteraction as AgeUp).OriginalSimOutfit;
            }
            if (simOutfit == null || !simOutfit.IsValid)
            {
                simOutfit = activeActor.CurrentOutfit;
            }
            if (simOutfit == null || !simOutfit.IsValid)
            {
                simOutfit = som.GetOutfit(activeActor.CurrentOutfitCategory, activeActor.CurrentOutfitIndex);
            }

            if (!som.IsValidDescription || som.mHairColors == null || !som.IsValid || som.Outfits == null || simOutfit == null || !simOutfit.IsValid)
                return;

            ResourceKey key = simOutfit.Key;

            var hashtable = new Hashtable(4);
            hashtable["simOutfitKey"] = key;
            hashtable["scriptClass"] = "Sims3.Gameplay.UI.PieMenuSimHead";
            hashtable["animationRunsInRealtime"] = 1u;
            hashtable["enableSimPoseProcessing"] = 1u;

            var nillSimDesc = sfie_nuiilSimDesc as SimDescription;

            if (nillSimDesc == null)
            {
                sfie_nuiilSimDesc = NFinalizeDeath.SimDesc_Empty(som);
                nillSimDesc = sfie_nuiilSimDesc as SimDescription;
            }
            else
            {
                SimDescCleanseTask.SafeCallSimDescCleanseO(nillSimDesc);
                NFinalizeDeath.SetSafeSimDesc(nillSimDesc, som);
            }

            //
            if (ListCollon.NiecDisposedSimDescriptions != null)
            {
                ListCollon.NiecDisposedSimDescriptions.Remove(nillSimDesc);
            }

            if (ListCollon.NiecSimDescriptions != null)
            {
                ListCollon.NiecSimDescriptions.Remove(nillSimDesc);
            }
            //

            var simDescription = nillSimDesc ?? new SimDescription(som);
            if (ListCollon.NiecSimDescriptions != null)
            {
                ListCollon.NiecSimDescriptions.Remove(simDescription);
            }

            simDescription.AgingEnabled = false;

            var simInitParameters = new SimInitParameters(simDescription);
            simInitParameters.AddToObjectManager = false;

            var pieMenuSimHead = GlobalFunctions.CreateObjectWithOverrides
                ("GameSim", ProductVersion.BaseGame, Vector3.Zero, 0, Vector3.Origin, hashtable, simInitParameters) as PieMenuSimHead;

            if (pieMenuSimHead != null)
            {
                try
                {
                    if (som.IsGhost)
                    {
                        if (!som.IsEP11Bot)
                        {
                            World.ObjectSetGhostState(pieMenuSimHead.ObjectId, (uint)som.DeathStyle, (uint)som.AgeGenderSpecies);
                        }
                        else
                        {
                            World.ObjectSetGhostState(pieMenuSimHead.ObjectId, 23u, (uint)som.AgeGenderSpecies);
                        }
                    }
                    else if (activeActor.CurrentSkinColoration != 0)
                    {
                        float[] tuningForSkinColoration = SimTemperature.GetTuningForSkinColoration
                            (activeActor.CurrentSkinColoration, som.IsAlien);

                        World.ObjectSetVisualOverride
                            (pieMenuSimHead.ObjectId,
                            activeActor.IsFemale ? eVisualOverrideTypes.FemaleTan : eVisualOverrideTypes.Tan,
                            tuningForSkinColoration);
                    }
                    else if (som.IsVampire)
                    {
                        World.ObjectSetVisualOverride(pieMenuSimHead.ObjectId, eVisualOverrideTypes.Vampire, null);
                    }
                    if (som.IsAlien)
                    {
                        World.ObjectSetVisualOverride(pieMenuSimHead.ObjectId, eVisualOverrideTypes.Alien, null);
                    }

                    pieMenuSimHead.SetCreationData(activeActor, simDescription);
                    pieMenuSimHead.SetIdle();

                    CASUtils.SetOutfitInGameObject(key, pieMenuSimHead.ObjectId);

                    Sims3.UI.Hud.PieMenu.ShowSimHead(pieMenuSimHead.ObjectId);

                    CASUtils.SetPieMenuHeadScale(Sims3.Gameplay.UI.PieMenu.GetPieMenuHeadScale(activeActor));

                }
                catch (Exception) { }
                
                Sims3.Gameplay.UI.PieMenu.sSimHead = pieMenuSimHead;
            }
            else
            {
                simDescription.Dispose();
            }
        }

        public static bool SwimmingInPool_SelfInteractionCanHappenInPool(InteractionInstance interaction)
        {
            if (interaction == null)
                return false;

            return (interaction is NiecMod.Interactions.ExtKillSimNiec)
                || (interaction is Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.NiecKillSim) 
                || (interaction is NiecHelperSituation.INHSInteraction) 
                || (interaction is Urnstone.KillSim) 
                || (interaction is Sim.DEBUG_KillSim) 
                || (interaction is Sim.RouteToVIPRoom) 
                || (interaction is SimRoutingComponent.BePushed);
        }

        public static bool ScubaDiving_SelfInteractionCanHappenWhileDiving(InteractionInstance interaction)
        {
            if (interaction == null)
                return false;

            return (interaction is NiecMod.Interactions.ExtKillSimNiec)
                || (interaction is NiecHelperSituation.INHSInteraction)
                || (interaction is Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.NiecKillSim) 
                || (interaction is Urnstone.KillSim)
                || (interaction is Sim.DEBUG_KillSim)
                || (interaction is SimRoutingComponent.BePushed);
        }

        public static bool bNoStyledNotification = false;
        public static bool bNONMnoLog = false;

        public static ICollection LotManger_AllLots
        {
            get
            {
                if (bs_dont_call)
                    return null;

                var ass = Assembly.GetCallingAssembly();
                if (ass._mono_assembly == Instantiator.myAssemblyPtr || ass._mono_assembly == Instantiator.dgsmAssemblyPtr)
                {
                    if (LotManager.sLots != null)
                        return LotManager.sLots.Values;
                }
                return new List<Lot>();
            }
        }
        /* The Debugger log
        DebugString: "NNotification"
        DebugString: "Style: kSystemMessage"
        DebugString: "TNSCategory: Lessons"
        DebugString: "Timeout: 15"
        DebugString: "Message: Go Here Recorded: 1"
        DebugString: "NNotification Exception Log
        #0: 0x##### throw      in Sims3.UI.Sims3.UI.NotificationManager:Add (Sims3.UI.Notification,Sims3.UI.NotificationManager/TNSCategory) (47325120 [6E21CE00] [1] )
        #1: 0x##### callvirt   in Sims3.UI.Sims3.UI.StyledNotification:Show (Sims3.UI.StyledNotification/Format,string,string,Sims3.SimIFace.ProductVersion,Sims3.SimIFace.ProductVersion) ([vt:823DBB3C] [00000000] [00000000] [1] [1] )
        #2: 0x##### call       in NRaas.NRaas.Common:Notify (NRaas.Common/StoredNotice) ([467B8B10] )
        #3: 0x##### call       in NRaas.NRaas.Common:Notify (string,Sims3.SimIFace.ObjectGuid,Sims3.SimIFace.ObjectGuid,Sims3.UI.StyledNotification/NotificationStyle,string,Sims3.SimIFace.ProductVersion) ([48419540] [vt:823DBA64] [vt:823DBA6C] [5] [00000000] [1] )
        #4: 0x##### call       in NRaas.NRaas.Common:Notify (string,Sims3.SimIFace.ObjectGuid,Sims3.SimIFace.ObjectGuid,Sims3.UI.StyledNotification/NotificationStyle) ([48419540] [vt:823DB9DC] [vt:823DB9E4] [5] )
        #5: 0x##### call       in NRaas.NRaas.Common:Notify (string,Sims3.SimIFace.ObjectGuid,bool) ([48419540] [vt:823DB994] [1] )
        #6: 0x##### call       in NRaas.NRaas.Common:Notify (string) ([48419540] )
        #7: 0x##### call       in NRaas.NRaas.Common:OnNoticeAlarm () ()
        #8: 0x#####            in Sims3.Gameplay.Sims3.Gameplay.Function:Invoke () ()
        #9: 0x##### callvirt   in NRaas.Common+FunctionTask:Simulate () ()
         */
        public void notification_Add(Notification notification, Sims3.UI.NotificationManager.TNSCategory category)
        {
            if (notification == null)
                return;

            var SN = notification as Sims3.UI.StyledNotification;
            if (SN != null)
            {
                if (niec_native_func.cache_done_niecmod_native_debug_text_to_debugger && !bNONMnoLog)
                {
                    niec_native_func.OutputDebugString("NNotification");
                    niec_native_func.OutputDebugString("Style: " + SN.mFormat.mStyle);
                    niec_native_func.OutputDebugString("TNSCategory: " + SN.mFormat.mTNSCategory);
                    niec_native_func.OutputDebugString("Timeout: " + SN.mFormat.mTimeout);
                    niec_native_func.OutputDebugString("Message: " + SN.mFormat.mText);

                    try
                    {
                        throw new Exception("");
                    }
                    catch (Exception ex)
                    {
                        niec_native_func.OutputDebugString("NNotification Exception Log\n" + ex.stack_trace + "\nEnd");
                    }
                }
            }

            if (bNoStyledNotification)
            {
                notification.Dispose();
                return;
            }

            Sims3.UI.NotificationManager _this = (Sims3.UI.NotificationManager)(object)this;

            WindowBase win = _this.mTabGlows[category];
            _this.SetGlow(win, true);
            _this.mNotifications[category].Add(notification);
            _this.mTabs[category].Enabled = true;
            if (_this.mNotifications[_this.mCurrentCategory].Count == 0)
            {
                _this.mCurrentCategory = category;
            }
            if (category == _this.mCurrentCategory)
            {
                if (!_this.mOpen)
                {
                    _this.AddShowDelayTask();
                    return;
                }
                if (_this.mShowDelayTask == null)
                {
                    _this.SetGlow(win, false);
                }
                _this.SetGlow(_this.mMaxTextGlow, true);
                _this.UpdatePageInfo();
            }
            else if (!_this.mOpen)
            {
                _this.AddShowDelayTask();
            }
        }

        public void SocialWorkerChildAbuse_MakeServiceRequest(Lot lot, bool active, ObjectGuid simRequestingService, bool bImmediate)
        {
            if (lot == null)
                return;
            Babysitter intase = Babysitter.Instance;
            if (intase != null)
            {
                intase.MakeServiceRequest(lot, active, simRequestingService, bImmediate);
            }
        }

        public static void LotManager_OnWorldEvent(object sender, EventArgs args)
        {
            if (sender == null)
                return;
            try
            {
                LotManager.DispatchMessage(args);
            }
            catch (Exception)
            { }
        }

        public static void GameStates_ClearStaticsOnReturnToMainMenu()
        {
            if (bs_dont_call)
            { return; }
            try
            {
                PersistStatic.MainMenuLoading = true;
                GameStates.ClearTravelStatics();
                GameStates.ClearMovingData();
                MiniSimDescription.Clear();
                LoadSaveManager.ResetSaveLocation();
                EditTownModel.ClearPlaceLotsWizardFlags();
                Occupation.ClearJobCooldowns();
                InteriorDesigner.ClearPendingJobDataStatics();
                CelebrityManager.PlayerHasObtainedCelebrityStatus = 0u;
                School.ResetStatics();
                Secrets.ResetStatics();
                ParentsLeavingTownSituation.ResetStatics();
                PlayDateManager.ClearStatics();
                Type.GetType("Sims3.Gameplay.Objects.Environment.MagicGnome, Sims3GameplayObjects").GetMethod("ClearSpawnToddlerAlarm", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[0]);
                Type.GetType("Sims3.Gameplay.Objects.Electronics.DataDisc, Sims3GameplayObjects").GetField("sDataDiscCount", BindingFlags.Static | BindingFlags.Public).SetValue(null, 0);
                SleepDreamManager.ClearStatics();
                Punishment.ClearStatics();
                ScavengerManager.ClearStatics();
                HealthManager.ClearStatics();
                StrayPets.sLastActiveHouseholdVisit = DateAndTime.Invalid;
                DaycareToddlerTransportSituation.ClearStatics();
                FacePaintingBooth.ClearAlarmStatic();
                ZombieDanceTimeOut.ClearStatics();
                HolidayManager.PostWorldShutdown();
                AlienUtils.sAlienAbductionHelper = null;
                OnlineDatingManager.ClearStatics();
                AcademicCareer.ClearStatics();
                MascotIntroSituation.ClearStatics();
                UnchartedIslandMarker.ClearStatics();
                Household.ClearStatics();
                GameStates.sInstalledWorldList.Clear();
                GameStates.sPriorWorldTicksPlayed = 0L;
                GameStates.sResetTheFuture = false;
                Type.GetType("Sims3.Gameplay.Objects.Miscellaneous.TimePortal, Sims3GameplayObjects").GetMethod("ClearStatics", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[0]);
                Type.GetType("Sims3.Gameplay.Objects.Electronics.HoloComputer, Sims3GameplayObjects").GetMethod("ClearStatics", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[0]);
                Type.GetType("Sims3.Gameplay.Objects.Miscellaneous.Sims4VideoWallProgram, Sims3GameplayObjects").GetMethod("ClearStatics", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[0]);
                FutureDescendantService.ClearStaticMembers();
                CauseEffectService.ClearStaticMembers();
                //Type.GetType("Sims3.Gameplay.Objects.Miscellaneous.Sims4VideoWallProgram, Sims3GameplayObjects").GetMethod(NFinalizeDeath.GetNull<string>(), BindingFlags.Static | BindingFlags.Public).Invoke(NFinalizeDeath.GetNull<string>(), new object[0]);
                if (ErrorFileHandles != null)
                {
                    uint tttyty = 0;
                    ScriptCore.Simulator.Simulator_CreateExportFileImpl(ref tttyty, null);
                }
                else
                {
                    Type.GetType("Sims3.Gameplay.Objects.Miscellaneous.Sims4VideoWallProgram, Sims3GameplayObjects").GetMethod(NFinalizeDeath.GetNull<string>(), BindingFlags.Static | BindingFlags.Public).Invoke(NFinalizeDeath.GetNull<string>(), new object[0]);
                }
            }
            catch (Exception)
            {}
        }

        public static uint sGetRandomFast = 0;
        public static uint sGetRandomFastc = 0;

        public static uint GetRandomFast()
        {
            if (sGetRandomFast == 0)
            {
                sGetRandomFast = (uint)ListCollon.SafeRandom.obj_address() + (uint)ListCollon.SafeRandom.Next() *(uint)ListCollon.SafeRandom.GetHashCode() + 0x4FA9ECEB;
            }

            sGetRandomFast *= 0xCDFE1224;
            sGetRandomFast -= 0xCFFA;
            sGetRandomFast /= 0x4FA9ECEB;

            if (sGetRandomFast == sGetRandomFastc)
                sGetRandomFast = (uint)ListCollon.SafeRandom.obj_address() + (uint)ListCollon.SafeRandom.Next() * (uint)ListCollon.SafeRandom.GetHashCode() + 0x4FA9ECEB / sGetRandomFastc + 0xFCCAFEEA;

            sGetRandomFastc = sGetRandomFast;
            return sGetRandomFast;
        }

        public static Dictionary<uint, IntPtr> ErrorFileHandles = null; //new Dictionary<uint, IntPtr>();

        public static bool Simulator_AppendToFileImpl(uint fileHandle, char[] text)
        {
            if (fileHandle == 0 || text == null)
                return false;

            IntPtr ptr; 
            if (!ErrorFileHandles.TryGetValue(fileHandle, out ptr))
                return false;

            if (text.Length == 0)
                return true;

            var ttt = new string(text);
            if (ttt.Length == 0)
                return false;

            var tttl = ttt.Length - 1;
            if (tttl == 0)
                tttl = 1;
            if (tttl < 0)
                return false;

            NDebugger.LogLite("AppendToFile\n" + NDebugger.GetCurrentStack());

            var ttta = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(ttt);

            var t = niec_native_func.niecmod_native_file_write(ptr, ttta, tttl);

            //System.Runtime.InteropServices.Marshal.FreeHGlobal(ttta);

            return t == 1;
        }

        public static bool Simulator_CloseScriptErrorFileImpl(uint fileHandle)
        {
            if (fileHandle == 0)
                return false;

            IntPtr ptr;
            if (!ErrorFileHandles.TryGetValue(fileHandle, out ptr))
                return false;

            niec_native_func.niecmod_native_file_close(ptr);
            return ErrorFileHandles.Remove(fileHandle);
        }

        public static string Simulator_CreateScriptErrorFileImpl(ref uint fileHandle)
        {
            if (ErrorFileHandles == null)
                return null;

            if (ErrorFileHandles.ContainsKey(fileHandle))
                return null;

            NDebugger.LogLite("CreateScriptErrorFile\n" + NDebugger.GetCurrentStack());

            var createFile = "Script Error " + NFinalizeDeath.GetNowTimeToStr() + " " + GetRandomFast().ToString("X") + ".xml";
            fileHandle = (uint)(DateTime.Now.GetHashCode() * createFile.length);

            var handle = niec_native_func.niecmod_native_file_create("Sims 3 Data\\Script Errors\\" + createFile);
            if (!niec_std.is_valid_handle(handle))
                handle = niec_native_func.niecmod_native_file_create("C:\\Sims 3 Data\\Script Errors\\" + createFile);
            if (!niec_std.is_valid_handle(handle))
            {
                fileHandle = 0;
                return null;
            }

            fileHandle += (uint)handle;
            ErrorFileHandles.Add(fileHandle, handle);

            return createFile;
        }

        public static string Simulator_CreateExportFileImpl(ref uint fileHandle, string prefix)
        {
            if (ErrorFileHandles == null)
                return null;
            if (ErrorFileHandles.ContainsKey(fileHandle))
                return null;
            if (prefix == null)
                throw new ArgumentNullException("prefix");
            if (prefix.Length == 0)
                prefix = "NoPrefix";

            NDebugger.LogLite("CreateExportFile\n" + NDebugger.GetCurrentStack());

            var createFile = prefix + " " + NFinalizeDeath.GetNowTimeToStr() + " " + GetRandomFast().ToString("X") + ".xml";

            fileHandle = (uint)(DateTime.Now.GetHashCode() * createFile.length);

            var handle = niec_native_func.niecmod_native_file_create("Sims 3 Data\\XMLExports\\" + createFile);
            if (!niec_std.is_valid_handle(handle))
                handle = niec_native_func.niecmod_native_file_create("C:\\Sims 3 Data\\XMLExports\\" + createFile);
            if (!niec_std.is_valid_handle(handle))
            {
                fileHandle = 0;
                return null;
            }

            fileHandle += (uint)handle;
            ErrorFileHandles.Add(fileHandle, handle);

            return createFile;
        }

        public void InWorldState_GotoSubState(Sims3.Gameplay.InWorldState.SubState stateID)
        {
            if (bs_dont_call)
            { return; }

            InWorldState _this = (InWorldState)(object)this;

            try
            {
                _this.mPrevStateId = (Sims3.Gameplay.InWorldState.SubState)((_this.mStateMachine.CurState != null) ? _this.mStateMachine.CurStateId : 21);
                _this.mNextStateId = stateID;
                if (_this.mStateMachine.CurStateId != 21)
                {
                    InWorldSubState inWorldSubState3 = _this.mStateMachine.CurState as InWorldSubState;
                    if (inWorldSubState3 != null && !inWorldSubState3.WillExit)
                    {
                        _this.mNextStateId = Sims3.Gameplay.InWorldState.SubState.None;
                        return;
                    }
                }
            }
            catch (Exception)
            { }

            try
            {
                if (SocialFeatures.Accounts.IsLoggedIn())
                {
                    uint value = 0u;
                    DeviceConfig.GetOption("ReceiveConnectTNS", out value);
                    if (InWorldState.HomeTNSShouldShowInThisState((int)_this.mNextStateId) && value != 0)
                    {
                        NotificationManager instance3 = NotificationManager.Instance;
                        if (instance3 != null && !_this.mHasNotification)
                        {
                            _this.mHasNotification = true;
                            ConnectHomeNotification.Create();
                            InGameWallController.SendOfflineTNSMessages();
                        }
                    }
                    else
                    {
                        NotificationManager instance2 = NotificationManager.Instance;
                        if (instance2 != null && _this.mHasNotification)
                        {
                            instance2.ClearAllInCategory(NotificationManager.TNSCategory.Connected);
                            _this.mHasNotification = false;
                        }
                    }
                }
            }
            catch (Exception)
            { }


            bool flag3 = _this.mPrevStateId == InWorldState.SubState.BuildMode || _this.mPrevStateId == InWorldState.SubState.BuyMode;
            bool flag2 = _this.mNextStateId == InWorldState.SubState.BuildMode || _this.mNextStateId == InWorldState.SubState.BuyMode;

            try
            {
                if (flag3 && !flag2)
                {
                    Sims3.Gameplay.UI.Responder.Instance.BuildBuyModel.ClearStoreTNSMessages();
                }
            }
            catch (Exception)
            { }

            try
            {
                foreach (InWorldSubState inWorldSubState2 in _this.mSubStates)
                {
                    if (inWorldSubState2 != null)
                    {
                        inWorldSubState2.UpdateReturnState(stateID);
                    }
                }
            }
            catch (Exception)
            { }

            try
            {
                UIManager.GetSceneWindow().CursorID = 0;
            }
            catch (Exception)
            { }
          

            try
            {
                if (_this.mPrevStateId == InWorldState.SubState.LiveMode)
                {
                    _this.mToggleState = 1u;
                    _this.UpdateUI();
                }
            }
            catch (Exception)
            { }

            try
            {
                var t = (Sims3.Gameplay.InWorldState.InWorldSubStateChangingCallback)typeof(Sims3.Gameplay.InWorldState).GetField("InWorldSubStateChanging", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
                if (t != null)
                {
                    t(_this.mPrevStateId, stateID);
                }
            }
            catch (Exception)
            { }

            try
            {
                _this.mStateMachine.SetNextState((int)stateID);
            }
            catch (Exception)
            { }
          
        }

        public void HudModel_LoadingScreenDisposed()
        {
            if (bs_dont_call)
            { return; }
            try
            {
                EventTracker.SendEvent(new Event(EventTypeId.kLoadingScreenDisposed));
            }
            catch (Exception)
            {}
            
        }

        public static bool UIManager_ProcessEventCallback(uint winHandle, uint eventType, uint srcHandle, uint dstHandle, int arg1, int arg2, int arg3, float f1, float f2, float f3, float f4, ref bool result, string text)
        {
            if (arg1 == 0x7FFFFAAA)
                return true;
            try
            {
                return UIManager.ProcessEvent(winHandle, eventType, srcHandle, dstHandle, arg1, arg2, arg3, f1, f2, f3, f4, ref result, text);
            }
            catch (Exception)
            { return true; }
            finally
            {
                if (winHandle != 0)
                {
                    UIManager.gUIMgr.DestroyWindow(winHandle);
                }
            }
        }

        public void MapTagController_Simulate()
        {
            if (bs_dont_call)
            { return; }
            try
            {
                MapTagController _this = (MapTagController)(object)this;
                while (_this != null)
                {
                    IMapTagsModel mapTagsModel = Sims3.UI.Responder.Instance.MapTagsModel;
                    if (!_this.mbActive || mapTagsModel == null)
                    {
                        break;
                    }
                    if (MapTagController.sbReInit)
                    {
                        MapTagController.sInstance = _this;
                        UIManager.InitMapTagSystem(MapTagController.kDefaultMapTag2DOffset, MapTagController.kAllowedBoundsOutsideScreen, MapTagController.kMapTagRadius, MapTagController.kPushForce, MapTagController.kCollisionDamping, MapTagController.kMass, MapTagController.kPullDamping, MapTagController.kPullForce, MapTagController.kTimeStep, MapTagController.kIdealSeparation, MapTagController.kInnerBorder, MapTagController.kMinFadeDistance, MapTagController.kMaxFadeDistance, MapTagController.kMaxFade);
                        MapTagController.sbReInit = false;
                    }
                    UIManager.UpdateMapTagCamera();
                    if (_this.mCurrentMapTags == null)
                    {
                        _this.mCurrentMapTags = mapTagsModel.GetCurrentMapTags();
                        _this.mCurrentMapTags.Sort(MapTagController.TagComparison);
                        _this.mbRunCollisions = true;
                    }
                    UIManager.UpdateMapTags();
                    Simulator.Sleep(0u);
                }
            }
            catch (ResetException)
            { }
            catch (Exception)
            {
                for (int i = 0; i < 200; i++)
                {
                    Simulator.Sleep(0);
                }
            }
        }
        public void MapTagVisibilityUpdate_Simulate()
        {
            if (bs_dont_call)
            { return; }
            try
            {
                var _this = (Sims3.UI.MapTagController.MapTagVisibilityUpdate)(object)this;
                while (_this != null)
                {
                    IMapTagsModel mapTagsModel = Sims3.UI.Responder.Instance.MapTagsModel;
                    if (!_this.mController.mbActive || mapTagsModel == null || _this.mController.mCurrentMapTags == null)
                    {
                        break;
                    }
                    int num = 0;
                    IMapTag[] array = _this.mController.mCurrentMapTags.ToArray();
                    int i = 0;
                    for (int num2 = array.Length; i < num2; i++)
                    {
                        if (i % 5 == 0 && !_this.mController.mbForceUpdate)
                        {
                            Simulator.Sleep(0u);
                            if (_this.mController.mCurrentMapTags == null || _this.mController.mbForceUpdate)
                            {
                                return;
                            }
                        }
                        IMapTag mapTag = array[i];
                        MapTagType tagType = mapTag.TagType;
                        bool stickToScreenBounds = false;
                        MapTagController.AllowedBoundsOutsideScreen = MapTagController.sSpreadsheetData[tagType].AllowedBoundsOutside;
                        if (mapTag.AlwaysShow || MapTagController.sSpreadsheetData[tagType].AllowedBoundsOutside > 1f)
                        {
                            stickToScreenBounds = true;
                        }
                        MapTagWin value = null;
                        _this.mController.mVisibleMapTags.TryGetValue(mapTag, out value);
                        if (num < MapTagController.kMaxNumMaptagsToDisplay && mapTag.IsActive && (mapTag.AlwaysShow || ((!mapTag.IsSimInContainer || (tagType == MapTagType.SelectedSim && !CameraController.IsMapViewModeEnabled())) && _this.mController.FilterCull(mapTag) && _this.mController.CameraCull(mapTag, ref stickToScreenBounds))))
                        {
                            if (tagType == MapTagType.SelectedSim && value != null && !CameraController.IsMapViewModeEnabled())
                            {
                                value.mHideStopwatch.Stop();
                            }
                            _this.mController.ShowTag(mapTag, stickToScreenBounds);
                            if (value == null)
                            {
                                _this.mController.mVisibleMapTags.TryGetValue(mapTag, out value);
                            }
                            num++;
                        }
                        else if (tagType == MapTagType.SelectedSim && value != null && !CameraController.IsMapViewModeEnabled())
                        {
                            if (value.mHideStopwatch.IsRunning())
                            {
                                if (value.mHideStopwatch.GetElapsedTimeFloat() > MapTagController.kSecondsBeforeHideActiveSimTag)
                                {
                                    value.mHideStopwatch.Stop();
                                    _this.mController.HideTag(mapTag);
                                }
                            }
                            else
                            {
                                value.mHideStopwatch.Restart();
                            }
                        }
                        else
                        {
                            _this.mController.HideTag(mapTag);
                        }
                        if (value != null)
                        {
                            if (MapTagController.sDiscoTags)
                            {
                                uint num3 = (uint)(RandomGen.NextDouble() * 16777215.0);
                                num3 = (uint)((int)num3 | -16777216);
                                value.ShadeColor = new Color(num3);
                            }
                            UIManager.SetMapTagStickToScreenBounds(value, stickToScreenBounds);
                        }
                    }
                    _this.mController.mbForceUpdate = false;
                    if (_this.mController.mbRunCollisions)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            UIManager.UpdateMapTags();
                        }
                        _this.mController.mbRunCollisions = false;
                    }
                    Simulator.Sleep(0u);
                }
            }
            catch (ResetException)
            { }
            catch (Exception)
            {
                if (Simulator.CheckYieldingContext(false))
                {
                    for (int k = 0; k < 500; k++)
                    {
                        Simulator.Sleep(0);
                    }
                }
            }
        }

        public void TooltipManager_Simulate()
        {
            if (bs_dont_call)
            { return; }
            try
            {
                TooltipManager _this = (TooltipManager)(object)this;
                while (_this != null)
                {
                    Vector2 tooltipPosition = UIManager.GetCursorPosition();
                    WindowBase windowFromPoint = UIManager.GetWindowFromPoint(tooltipPosition);
                    if (windowFromPoint == null)
                    {
                        Simulator.Sleep(0u);
                    }
                    else
                    {
                        ulong num;
                        ulong num2 = num = windowFromPoint.InstanceID;
                        ITooltippable tooltippable = null;
                        Vector2 mousePosition = new Vector2(0f, 0f);
                        float startTime = TooltipManager.TOOLTIP_DEFAULT_START_TIME;
                        float timeoutTime = TooltipManager.TOOLTIP_DEFAULT_TIMEOUT_TIME;
                        float transitionTime = TooltipManager.TOOLTIP_DEFAULT_TRANSITION_TIME;
                        WindowBase windowBase = windowFromPoint;
                        while (windowBase != null)
                        {
                            WindowBase parent = windowBase.Parent;
                            tooltippable = windowBase;
                            if (tooltippable != null)
                            {
                                mousePosition = ((parent != null) ? parent.ScreenToWindow(tooltipPosition) : windowBase.ScreenToWindow(tooltipPosition));
                                num = tooltippable.ShouldShowTooltip(mousePosition, windowFromPoint);
                                if (num != 0)
                                {
                                    if (tooltippable.UseDefaultTiming(ref startTime, ref timeoutTime, ref transitionTime))
                                    {
                                        startTime = TooltipManager.TOOLTIP_DEFAULT_START_TIME;
                                        timeoutTime = TooltipManager.TOOLTIP_DEFAULT_TIMEOUT_TIME;
                                        transitionTime = TooltipManager.TOOLTIP_DEFAULT_TRANSITION_TIME;
                                    }
                                    if (transitionTime <= 0f)
                                    {
                                        transitionTime = TooltipManager.TOOLTIP_DEFAULT_TRANSITION_TIME;
                                    }
                                    break;
                                }
                            }
                            windowBase = parent;
                        }
                        if (tooltippable != null && num != 0)
                        {
                            if (windowBase.InstanceID == _this.mCurrWindowID && num == _this.mCurrTooltippableID)
                            {
                                if (!_this.mbTimedOut && (_this.mStopWatch.GetElapsedTimeFloat() >= startTime || _this.mTransitionStopWatch.GetElapsedTimeFloat() < transitionTime))
                                {
                                    if (_this.mCurrentTooltip == null)
                                    {
                                        Vector2 a = tooltipPosition;
                                        _this.mCurrentTooltip = tooltippable.CreateTooltip(mousePosition, windowFromPoint, ref tooltipPosition);
                                        if (a == tooltipPosition)
                                        {
                                            tooltipPosition = _this.CalculateTooltipPosition(tooltipPosition);
                                        }
                                        _this.mCurrActiveTooltippable = tooltippable;
                                        _this.ShowTooltip(tooltipPosition);
                                    }
                                    else if (timeoutTime != -1f && _this.mStopWatch.GetElapsedTimeFloat() >= timeoutTime)
                                    {
                                        _this.HideTooltip(_this.mCurrActiveTooltippable);
                                        _this.mCurrActiveTooltippable = null;
                                        _this.mbTimedOut = true;
                                    }
                                }
                                Simulator.Sleep(0u);
                                continue;
                            }
                            _this.mbTimedOut = false;
                        }
                        if (_this.mCurrentTooltip != null)
                        {
                            _this.HideTooltip(_this.mCurrActiveTooltippable);
                            _this.mCurrActiveTooltippable = null;
                        }
                        if (windowBase != null)
                        {
                            _this.mCurrWindowID = windowBase.InstanceID;
                            _this.mCurrTooltippableID = num;
                        }
                        else
                        {
                            _this.mCurrTooltippableID = num2;
                            _this.mCurrWindowID = (uint)num2;
                        }
                        _this.mStopWatch.Restart();
                        Simulator.Sleep(0);
                    }
                }
            }
            catch (ResetException)
            { }
            catch (Exception)
            {
                for (int i = 0; i < 200; i++)
                {
                    Simulator.Sleep(0);
                }
            }
        }

        public ListenerAction TraitListener_OnEvilRespondingToMisfortune(Event e)
        {
            if (e == null)
                return ListenerAction.Remove;

            var _this = (TraitListener)(object)this;
            if (_this.mSim == null|| _this.mSim.mAutonomy == null || _this.mSim.SocialComponent == null || _this.mSim.ObjectId.mValue == 0)
            {
                return ListenerAction.Remove;
            }
            if (e.Actor == null)
            {
                return ListenerAction.Keep;
            }
            if (e.Actor.LotCurrent == _this.mSim.LotCurrent && e.Actor != _this.mSim)
            {
                try
                {
                    ActiveTopic.AddToSim(_this.mSim, "Evil Responding to Misfortune", (e.Actor as Sim).SimDescription);
                }
                catch (Exception)
                {
                    return ListenerAction.Remove;
                }
            }
            return ListenerAction.Keep;
        }


        public static void nOnTriggerTakePhotograph()
        {
            if (bs_dont_call)
            { return; }

            Sim activeActor = PlumbBob.SelectedActor;
            if (activeActor != null)
            {
                try
                {
                    foreach (var interaction in activeActor.InteractionQueue.mInteractionList.ToArray())
                    {
                        interaction.mMustRun = false;
                        interaction.CancellableByPlayer = true;
                        interaction.Hidden = false;
                    }
                }
                catch (Exception)
                { }

                try
                {
                    activeActor.InteractionQueue.AddNext(nGetBestInteractionForTakePhoto(activeActor));
                }
                catch (Exception)
                { }
               
            }
        }

        public static InteractionInstance nGetBestInteractionForTakePhoto(Sim actor)
        {
            if (actor == null || actor.ObjectId.mValue == 0)
            {
                return null;
            }
            ICamera bestCameraFromInventory = Photography.GetBestCameraFromInventory(actor);
            if (bestCameraFromInventory == null || bestCameraFromInventory.TakePhotoSingleton == null)
            {
                return null;
            }
            // return NiecHelperSituation.CreateInstance_internalX<InteractionInstance>(bestCameraFromInventory.TakePhotoSingleton, bestCameraFromInventory, actor, new InteractionPriority(InteractionPriorityLevel.ESRB), false, true);
            return bestCameraFromInventory.TakePhotoSingleton.CreateInstance(bestCameraFromInventory, actor, new InteractionPriority(InteractionPriorityLevel.ESRB), false, true);
        }

        public static bool routing_component_push_sims_static(Sim actor, List<Sim> sims, float minPushAwayDist, float maxPushAwayDist, bool allowPushOutOfConversation, bool waitForPushes, InteractionPriority priority, bool bForceAllowPushOutOfInteraction)
        {
            if (bs_dont_call)
            {
                return false;
            }

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            int num = 0;
            List<Sim> list = new List<Sim>(sims);
            if (actor != null)
            {
                list.Remove(actor);
            }
            int count = list.Count;
            RoutingComponent.RemoveNonPushableSims(actor, list);
            if (!allowPushOutOfConversation)
            {
                int num2 = 0;
                while (num2 < list.Count)
                {
                    if (list[num2] == null || list[num2].Conversation != null)
                    {
                        list.RemoveAt(num2);
                    }
                    else
                    {
                        num2++;
                    }
                }
            }
            int count2 = list.Count;
            if (count2 > 0)
            {
                foreach (Sim item in list)
                {
                    InteractionInstance pushRelevantInteractionForSim = RoutingComponent.GetPushRelevantInteractionForSim(item);
                    SimRoutingComponent.BePushed bePushed = pushRelevantInteractionForSim as SimRoutingComponent.BePushed;
                    if (item.IsRouting && bePushed == null)
                    {
                        if (item.SimRoutingComponent.RequestMidRoutePush(actor, minPushAwayDist, maxPushAwayDist))
                        {
                            num++;
                        }
                    }
                    else
                    {
                        BePushedCanCancelResult bePushedCanCancelResult = BePushedCanCancelResult.Disallow;
                        IBePushedCanCancel bePushedCanCancel = pushRelevantInteractionForSim as IBePushedCanCancel;
                        if (pushRelevantInteractionForSim == null)
                        {
                            bePushedCanCancelResult = BePushedCanCancelResult.Allow;
                        }
                        else
                        {
                            if (bePushed != null && bePushed.Pusher == actor)
                            {
                                num++;
                                continue;
                            }
                            if (bePushedCanCancel != null)
                            {
                                bePushedCanCancelResult = bePushedCanCancel.CanBePushedCancel(actor);
                            }
                            else if (bForceAllowPushOutOfInteraction)
                            {
                                bePushedCanCancelResult = BePushedCanCancelResult.AllowForHigherPriority;
                            }
                        }
                        if (bePushedCanCancelResult != 0)
                        {
                            SimRoutingComponent.BePushed bePushed2 = SimRoutingComponent.BePushed.Singleton.CreateInstance(item, item, priority, false, false) as SimRoutingComponent.BePushed;
                            if (bePushed2 != null)
                            {
                                bePushed2.Pusher = actor;
                                bePushed2.Hidden = true;
                                bePushed2.PushAwayDistanceMin = minPushAwayDist;
                                bePushed2.PushAwayDistanceMax = maxPushAwayDist;
                                switch (bePushedCanCancelResult)
                                {
                                    case BePushedCanCancelResult.Allow:
                                        item.InteractionQueue.AddNext(bePushed2);
                                        num++;
                                        break;
                                    case BePushedCanCancelResult.AllowForHigherPriority:
                                        if (item.InteractionQueue.AddNextIfPossible(bePushed2) && item.HasExitReason(ExitReason.HigherPriorityNext))
                                        {
                                            num++;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                if (waitForPushes)
                {
                    if (actor != null && actor.ObjectId == Simulator.CurrentTask)
                    {
                        actor.LoopIdle();
                    }
                    float num3 = SimRoutingComponent.TotalSimMinutesToWaitForSimsToBePushed;
                    uint num4 = 10u;
                    bool flag = false;
                    do
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            Sim sim = list[i];
                            if (sim.HasBeenDestroyed || (!sim.InteractionQueue.HasInteractionOfType(SimRoutingComponent.BePushed.Singleton) && !sim.SimRoutingComponent.IsInvolvedInPush))
                            {
                                list.RemoveAt(i);
                            }
                            else
                            {
                                i++;
                            }
                        }
                        flag = (list.Count == 0 || num3 < 0f);
                        if (flag)
                        {
                            Simulator.Sleep(0); // Custom Fixed Game freeze
                            continue;
                        }
                        DateAndTime previousDateAndTime = SimClock.CurrentTime();
                        if (actor != null)
                        {
                            actor.WaitForExitReason(SimClock.ConvertFromTicks(num4, TimeUnit.Minutes), ExitReason.TimedOut | ExitReason.UserCanceled | ExitReason.CanceledByScript | ExitReason.CancelledByPosture);
                            if (actor.HasExitReason(ExitReason.Canceled))
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            Simulator.Sleep(num4);
                        }
                        num3 -= SimClock.ElapsedTime(TimeUnit.Minutes, previousDateAndTime);
                    }
                    while (!flag);
                }
            }
            bool flag2 = true;
            if (actor != null)
            {
                flag2 &= !actor.HasExitReason(ExitReason.TimedOut | ExitReason.UserCanceled | ExitReason.CanceledByScript | ExitReason.CancelledByPosture);
            }
            if (flag2)
            {
                return num == count;
            }
            return false;
        }

        public static bool AcceptCancelDialog_Show(string message, bool trueButtonEnabled, bool falseButtonEnabled, Vector2 position, bool forceShowDialog)
        {
            if (message == null)
            {
                return false;
            }

            try
            {
                throw new Exception("");
            }
            catch (Exception ex)
            {
                niec_native_func.OutputDebugString("ACDSHOW" + " Message: " + message + "\nExLog\n" + ex.stack_trace + "\nEnd");
            }

            return niec_native_func.MessageBox(0, message, "Sims 3 Accept Cancel Dialog Yield: " + Simulator.CheckYieldingContext(false), niec_native_func.MB_Type.MB_ICONEXCLAMATION | niec_native_func.MB_Type.MB_OKCANCEL) == niec_native_func.ResultMB.IDOK;
        }

        public static bool TwoButtonDialog_Show(string promptText, string buttonTrue, string buttonFalse, bool trueButtonEnabled, bool falseButtonEnabled, Vector2 position, bool disableTooltip)
        {
            if (promptText == null)
            {
                return false;
            }

            try
            {
                throw new Exception("");
            }
            catch (Exception ex)
            {
                niec_native_func.OutputDebugString("TBDSHOW" + " Message: " + promptText + "\nExLog\n" + ex.stack_trace + "\nEnd");
            }

            return niec_native_func.MessageBox(0, promptText + "\n\nOK: " + buttonTrue + "\nCancel: " + buttonFalse, "Sims 3 Two Button Dialog Yield: " + Simulator.CheckYieldingContext(false), niec_native_func.MB_Type.MB_ICONEXCLAMATION | niec_native_func.MB_Type.MB_OKCANCEL) == niec_native_func.ResultMB.IDOK;
        }

        public static bool asdertert = false;
        /* Debugger Log Old 
        DebugString: "ThreeBD ExLog
        #0: 0x##### throw      in Sims3.UI.Sims3.UI.ThreeButtonDialog:Show (string,string,string,string,Sims3.SimIFace.Vector2) ([374D9BA0] [6652A840] [384A2CD0] [48813BB8] [vt:827691FC] )
        #1: 0x##### call       in Sims3.UI.Sims3.UI.ThreeButtonDialog:Show (string,string,string,string) ([374D9BA0] [6652A840] [384A2CD0] [48813BB8] )
        #2: 0x##### call       in Sims3.Gameplay.Sims3.Gameplay.InWorldState:PromptedQuit () ()
        #3: 0x##### call       in Sims3.Gameplay.Sims3.Gameplay.GameStates:TransitionToGameStateQuitTask () ()
        #4: 0x#####            in Sims3.Gameplay.Sims3.Gameplay.Function:Invoke () ()
        #5: 0x##### callvirt   in Sims3.Gameplay.Sims3.Gameplay.OneShotFunctionTask:Simulate () ()
         */
        public static Sims3.UI.ThreeButtonDialog.ButtonPressed ThreeButtonDialog_Show(string promptText, string firstButton, string secondButton, string thirdButton, Vector2 position)
        {
            if (promptText == null)
            {
                return ThreeButtonDialog.ButtonPressed.ThirdButton;
            }

            try
            {
                throw new Exception("");
            }
            catch (Exception ex)
            {
                //niec_native_func.OutputDebugString("ThreeBD ExLog\n" + ex.stack_trace + "\nEnd");
                niec_native_func.OutputDebugString("ThreeBD" + " Message: " + promptText + "\nExLog\n" + ex.stack_trace + "\nEnd");
            }

            switch(niec_native_func.MessageBox(0, promptText + "\n\nYES: " + firstButton + "\nNo: " + secondButton + "\nCancel: " + thirdButton, "Sims 3 Three Button Dialog Yield: " + Simulator.CheckYieldingContext(false), niec_native_func.MB_Type.MB_ICONEXCLAMATION | niec_native_func.MB_Type.MB_YESNOCANCEL)) {
                case niec_native_func.ResultMB.IDYES:
                    return ThreeButtonDialog.ButtonPressed.FirstButton;
                case niec_native_func.ResultMB.IDNO:
                    return ThreeButtonDialog.ButtonPressed.SecondButton;
                case niec_native_func.ResultMB.IDCANCEL:
                    return ThreeButtonDialog.ButtonPressed.ThirdButton;
                default:
                    if (!asdertert)
                    {
                        asdertert = true;
                        NFinalizeDeath.AssertX(false, "ThreeButtonDialog_Show Failed.");
                    }
                    return ThreeButtonDialog.ButtonPressed.ThirdButton;
            }
        }

        public static void SimpleMessageDialog_Show(string titleText, string messageText, string layoutName, Sims3.UI.ModalDialog.PauseMode pauseMode, Vector2 position, string openSound, string closeSound)
        {
            if (messageText == null && titleText == null)
                return;
            niec_native_func.MessageBox(0, messageText ?? "No Message\nST:\n" + NDebugger.GetCurrentStackLite(), titleText != null && titleText.Length > 0 ? titleText : "Sims 3 Message", 0);
        }

        public static void CharacterImportOnGameLoad_GatherHouseholdsAndDisposeCruft()
        {
            if (bs_dont_call) return;
            var dictionary = new Dictionary<ulong, Household>();
            foreach (Household sHousehold in Household.sHouseholdList)
            {
                //if (Sims3.SimIFace.Environment.HasEditInGameModeSwitch)
                //{
                //    List<Sim> sims = sHousehold.Sims;
                //    if (sims.Count > 0 && sims[0].WorldBuilderDeath != null)
                //    { }
                //    else
                //    {
                //        dictionary[sHousehold.HouseholdId] = sHousehold;
                //    }
                //}
                //else 
                if (CharacterImportOnGameLoad.sGhostSetupHouseholds == null || !CharacterImportOnGameLoad.sGhostSetupHouseholds.ContainsKey(sHousehold) || sHousehold.IsServiceNpcHousehold)
                {
                    dictionary[sHousehold.HouseholdId] = sHousehold;
                }
            }

            CharacterImportOnGameLoad.PopulateHouseholdDictionary(dictionary);

            bool t = false;
            foreach (Household value in dictionary.Values)
            {
                if (value == null)
                    continue;

                t = true;

                try
                {
                    NFinalizeDeath.RemoveNullForHouseholdMembers(value);
                }
                catch (Exception)
                { }

                var ee = value.mMembers;
                if (ee == null)
                    continue;

                var e = ee.mAllSimDescriptions;
                if (e == null)
                    continue;

                foreach (var item in e)
                {
                    try
                    {
                        item.Fixup();
                    }
                    catch (Exception)
                    {}
                }
            }
            if (t)
            {
                NFinalizeDeath.TrimHouse();
            }
        }
        public static FirefighterEmergencySituation FirefighterEmergencySituation_FindInvolvingSim(Sim victim)
        {
            if (victim == null)
                return null;
            SimDescription simDescription = victim.SimDescription;
            if (victim.Autonomy != null && victim.Autonomy.SituationComponent != null && victim.Autonomy.SituationComponent.Situations != null)
            {
                foreach (Situation situation in victim.Autonomy.SituationComponent.Situations)
                {
                    FirefighterEmergencySituation firefighterEmergencySituation = situation as FirefighterEmergencySituation;
                    if (firefighterEmergencySituation != null && firefighterEmergencySituation.Victims != null && firefighterEmergencySituation.Victims.ContainsKey(simDescription))
                    {
                        return firefighterEmergencySituation;
                    }
                }
            }
            return null;
        }
        public static void CharacterImportOnGameLoad_GatherSimDescriptionsAndDisposeCruft()
        {
            if (bs_dont_call) return;
            if (CharacterImportOnGameLoad.sSimDescriptionMapInWorld == null)
            {
                CharacterImportOnGameLoad.PopulateDescriptionsInWorldMap(SimDescription.GetSimDescriptionsInWorld());
            }
            CharacterImportOnGameLoad.sSimDictionaryKeyedOnSpreadsheetId = new Dictionary<string, SimDescriptionAttributes>();
            for (int i = 0; i < CharacterImportOnGameLoad.kSimSpecificTabs.Length; i++)
            {
                SpreadsheetTab key = CharacterImportOnGameLoad.kSimSpecificTabs[i];
                XmlDbTable value;
                if (CharacterImportOnGameLoad.sImportDataTable.TryGetValue((short)key, out value))
                {
                    CharacterImportOnGameLoad.PopulateSimDescriptionDictionary(value, CharacterImportOnGameLoad.sSimDescriptionMapInWorld);
                }
            }
            bool t = false;
            Household householdee = null;

            foreach (SimDescription simd in CharacterImportOnGameLoad.sSimDescriptionMapInWorld.Values)
            {
                t = true;
                if (simd.Household == null)
                {
                    if (householdee == null)
                        householdee = Household.Create(false);
                    NFinalizeDeath.Household_Add(householdee, simd, true);
                }

                try
                {
                    simd.Fixup();
                }
                catch (Exception)
                { }

                if (simd.Household == null)
                {
                    if (householdee == null)
                        householdee = Household.Create(false);
                    NFinalizeDeath.Household_Add(householdee, simd, true);
                }
            }

            if (t)
            {
                NFinalizeDeath.TrimHouse();
            }

            if (householdee != null)
            {
                if (householdee.mMembers.mAllSimDescriptions.Count == 0)
                {
                    NFinalizeDeath.HouseholdCleanse(householdee, false, true);
                }
                else
                {
                    NFinalizeDeath.RemoveNullForHouseholdMembers(householdee);
                    Create.AutoMoveInLotFromHousehold(householdee);
                    householdee.Name = householdee.mMembers.mAllSimDescriptions._items[0].mLastName;
                }
            }
           
            CharacterImportOnGameLoad.sSimDescriptionMapInWorld = null;
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

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

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

        

        public static uint UI_AddTriggerHook(WindowBase window, string map, TriggerActivationMode mode, int priority, bool modal)
        {
            if (mode == (TriggerActivationMode)0x5FE00000)
            {
                return uint.MaxValue;
            }
            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!NFinalizeDeath.dontdebstr)
                    niec_native_func.OutputDebugString("UI_AddTriggerHook called. ST:\n" + NDebugger.GetCurrentStackLite());

                if (window is LoadingScreenController)
                {
                    if (!NFinalizeDeath.dontdebstr)
                        niec_native_func.OutputDebugString("UI_AddTriggerHook 2");
                    return uint.MaxValue;
                }

                if ((object)map == (object)"OKCancelDialog" && mode == TriggerActivationMode.kPermanent && priority == 16 && modal && window == UIManager.GetUITopWindow())
                {
                    if (!NFinalizeDeath.dontdebstr)
                        niec_native_func.OutputDebugString("UI_AddTriggerHook 3");
                    return uint.MaxValue;
                }

                if (!NFinalizeDeath.dontdebstr)
                    niec_native_func.OutputDebugString("UI_AddTriggerHook calling UIManager::AddTriggerHook");
            }
            return UIManager.gUIMgr.AddTriggerHook(window.WinHandle, map, (int)mode, priority, modal);
        }

        public static bool InWorldSubState_IsBuildBuyValid(Lot lot, ref string failReason, bool forEditTown)
        { 
            if (lot == null) 
                return false; 
            return true; 
        }

        public static bool InWorldSubState_IsEditTownValid(Lot lot, ref string failReason)
        {
            return true;
        }

        public void CaregiverRoutingMonitor_AlarmCallback()
        {
            if (bs_dont_call || NiecHelperSituation.isdgmods || NiecHelperSituation.__acorewIsnstalled__)
                return;
            CaregiverRoutingMonitor _this = (CaregiverRoutingMonitor)(object)this; 
            _this.AlarmCallbackInternal();
        }

        public static void EmptyAlarmCallBack()
        {
            int a = 
                500 * 
                5 / 
                2; // = 1250

            a += 500;

            return;
        }


        public bool Gameflow_IsSaveDisabled(out string tnsKey)
        {
            tnsKey = null;
            return false;
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
                if (_this.mInteractionInstance != null)
                {
                    NiecTask.CreateWaitPerformWithExecuteTypeSID(ScriptExecuteType.Task, () =>
                    {
                        try
                        {
                            if (_this.mInteractionInstance != null && _this.mInteractionInstance.Test())
                            {
                                _this.mInteractionInstance.RunInteractionWithoutCleanup();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!(ex is ResetException))
                                NiecException.SendTextExceptionToDebugger(ex);
                        }
                    })
                    .Waiting();
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
                    NiecTask.CreateWaitPerformWithExecuteTypeSID(ScriptExecuteType.Task, () =>
                    {
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
                        }
                    })
                    .Waiting();
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

        public static object cacheACGTNOM = null;

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

                if (callingAssemblyPtr == Instantiator.ascAssemblyPtr)
                {
                    if (!(cacheACGTNOM is Assembly[]))
                    {
                        var xt = _this.GetAssemblies(false);
                        var ass = new List<Assembly>(11);

                        foreach (var item in xt)
                        {
                            if (item == null)
                                continue;
                            if (NFinalizeDeath.AssemblyIsEA(item, false))
                            {
                                ass.Add(item);
                                continue;
                            }
                            var name = item.GetName().Name;
                            if (name == "mscorlib" || name == "System" || name == "System.Xml" || name == "Sims3StoreObjects")
                            {
                                ass.Add(item);
                                continue;
                            }
                        }

                        ass.Add(callingAssembly);

                        if (ass.Contains(null))
                            NFinalizeDeath.Assert(false, "!ass.Contains(null) ST:\n" + NDebugger.GetCurrentStackLite());

                        niec_native_func.OutputDebugString("callingAssemblyPtr == Instantiator.ascAssemblyPtr");
                        foreach (var item in ass)
                        {
                            niec_native_func.OutputDebugString("Name: " + item.GetName().Name);
                        }

                        cacheACGTNOM = ass.ToArray();
                        return ass.ToArray();
                    }
                    else return (Assembly[])((Assembly[])cacheACGTNOM).Clone();
                }

                if (//callingAssemblyPtr == Instantiator.ascAssemblyPtr ||
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

            NFinalizeDeath.AssertX(false, "game_utils_transition_to_quit_internal test.\n\nStackTrace:\n" + NDebugger.GetCurrentStackLite());

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
                NFinalizeDeath.AssertX(false, "game_utils_transition_to_quit test.\n\nStackTrace:\n" + NDebugger.GetCurrentStackLite());
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
                if (NFinalizeDeath.GetNull<NiecObjectPlus>().IsDone())
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

            try
            {
                LifeEventManager.SendLifeEvent(e);
            }
            catch (ResetException)
            {
                shouldResetEx = true;
            }
            catch (Exception)
            { }
          

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
