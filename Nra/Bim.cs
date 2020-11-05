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

namespace NiecMod.Nra
{
    public static class Bim
    {
        public static void FoundInteraction(Sim _this)
        {
            if (_this == null ||
               _this.ObjectId.mValue != ScriptCore.Simulator.Simulator_GetCurrentTaskImpl() ||
               !Simulator.CheckYieldingContext(false))
                return;

            if (_this.mSimDescription == null)
            {
                _this.mSimDescription = Create.NiecNullSimDescription(true, false, true);
            }

            if (_this.mInteractionQueue == null)
                return;

            InteractionInstance headInteraction = _this.mInteractionQueue.GetHeadInteraction();
            if (headInteraction == null || (!headInteraction.MustRun && !headInteraction.Prioritized && !headInteraction.PushedAsContinuation))
            {
                if (headInteraction == null)
                {
                    if (_this.Posture != null)
                        _this.Posture.OnInteractionQueueEmpty();

                    //if (_this.mSimDescription == null)
                    //    _this.mSimDescription = Create.NiecNullSimDescription(true, false, true);

                    if (NiecHelperSituation.___bOpenDGSIsInstalled_ && _this.mSimDescription.IsTombMummy)
                    {
                        foreach (ISarcophagus sarcophagus in NFinalizeDeath.SC_GetObjectsOnLot<ISarcophagus>(_this.LotCurrent)) //_this.LotCurrent.GetObjects<ISarcophagus>())
                        {
                            if (sarcophagus.IsTombMummysSarcophagus(_this))
                            {
                                if (!sarcophagus.TombMummyPushWander(_this) && !sarcophagus.TombMummyPushReturnToSarcophagus(_this, false))
                                {
                                    sarcophagus.TombMummyPushDisintegrate(_this);
                                }
                                return;
                            }
                        }
                    }
                }

                if (_this.mSimDescription == null)
                    _this.mSimDescription = Create.NiecNullSimDescription(true, false, true);

                if (_this.mSimDescription.DeathStyle == SimDescription.DeathType.None && !_this.mSimDescription.IsGhost)
                {
                    Urnstone.KillSim killSim = headInteraction as Urnstone.KillSim;
                    if (killSim == null || killSim.simDeathType != SimDescription.DeathType.Freeze)
                    {
                        try
                        {
                            if (_this.mIdleManager != null)
                                _this.mIdleManager.DistressIdle();
                            if (_this.mIdleManager != null)
                                _this.mIdleManager.PlayNonDistressIdleIfNecessary();
                        }
                        catch (SacsErrorException)
                        { }
                    }
                }
            }

            if (headInteraction != null)
            {
                if (headInteraction.GetPriority().Level == InteractionPriorityLevel.UserDirected)
                {
                    _this.mTimeOfLastUserDirectedAction = SimClock.ElapsedTime(TimeUnit.Hours);
                }
                if (headInteraction is SocialInteractionB)
                {
                    if (headInteraction.LinkedInteractionInstance != null)
                    {
                        _this.mLastInteractionWasAutonomous = headInteraction.LinkedInteractionInstance.Autonomous;
                    }
                }
                else
                {
                    _this.mLastInteractionWasAutonomous = headInteraction.Autonomous;
                }

                if (_this.mSocialComponent != null && headInteraction.InteractionObjectPair != null && headInteraction.InteractionObjectPair.Tuning != null && headInteraction.InteractionObjectPair.Tuning.ActionTopic != null && headInteraction.InteractionObjectPair.Tuning.ActionTopic != "")
                {
                    _this.mSocialComponent.SetLastInteractionToTalkAbout(headInteraction);
                }

                ulong groupId = headInteraction.GroupId;
                _this.mLastInteractionSucceeded = ProcessAllInteraction(_this);

                if (Sims3.SimIFace.Objects.IsValid(_this.ObjectId))
                {
                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(0);
                }

                if (_this.mSocialComponent != null)
                    _this.mSocialComponent.LastInteractionFinishedWhen = SimClock.CurrentTime();

                if (_this.mAutonomy != null && _this.mInteractionQueue != null && _this.mInteractionQueue.GetHeadInteraction() != null && (_this.mInteractionQueue.Count == 0 || _this.mInteractionQueue.GetHeadInteraction().GroupId != groupId))
                    _this.mAutonomy.TraitToDisplay = TraitNames.Unknown;

                return;
            }

            if (Simulator.CurrentTask != _this.ObjectId)
            {
                string message = (_this.SynchronizationTarget == null) ? "no sync target" : ((_this.SynchronizationRole == Sims3.Gameplay.Actors.Sim.SyncRole.Initiator) ? "sync target is receiver" : ((_this.SynchronizationLevel < Sims3.Gameplay.Actors.Sim.SyncLevel.Started) ? "sync level not started" : ((_this.SynchronizationLevel >= Sims3.Gameplay.Actors.Sim.SyncLevel.Completed) ? "sync level complete or aborted" : ((!(Simulator.CurrentTask != _this.SynchronizationTarget.ObjectId)) ? null : "not sync target"))));
                if (message != null)
                {
                    message = string.Format("Attempt to call LoopIdle from another thread: {0} != {1} ({2})", Simulator.CurrentTask, _this.ObjectId, message);
                    throw new ArgumentException(message);
                }
            }

            if (!_this.mIsAlreadyIdling)
            {
                _this.mIsAlreadyIdling = true;
                if (_this.BridgeOrigin != null)
                {
                    BridgeOrigin bridgeOrigin = _this.BridgeOrigin;
                    _this.BridgeOrigin = null;
                    bridgeOrigin.MakeRequest();
                }
                _this.PostureIdle();
            }

            if (_this.mAutonomy != null && AutonomyRestrictions.IsAnyAutonomyEnabled(_this))
            {
                if (!_this.mAutonomy.InAutonomyManagerQueue)
                {
                    if (_this.mSimDescription == null)
                        _this.mSimDescription = Create.NiecNullSimDescription(true, false, true);

                    if (_this.CanRunAutonomyImmediately())
                    {
                        AutonomyManager.Add(_this.mAutonomy);
                    }
                    else if (_this.mAutonomy != null)
                    {
                        float timeSinceInteractionQueueBecameEmpty = _this.Autonomy.TimeSinceInteractionQueueBecameEmpty;
                        float time = (_this.BeingRiddenPosture != null || _this.RidingPosture != null) ? Sims3.Gameplay.Autonomy.Autonomy.AutonomyDelayWhileMounted : ((_this.Conversation != null && (_this.IsActiveSim || (_this.Conversation.WhoTalkedLast != null && _this.Conversation.WhoTalkedLast.IsActiveSim))) ? Sims3.Gameplay.Autonomy.Autonomy.AutonomyDelayDuringSocializing : ((_this.mExitReason != ExitReason.UserCanceled) ? Sims3.Gameplay.Autonomy.Autonomy.AutonomyDelayNormal : Sims3.Gameplay.Autonomy.Autonomy.AutonomyDelayAfterUserCancellation));
                        if (timeSinceInteractionQueueBecameEmpty < 0f || timeSinceInteractionQueueBecameEmpty >= time || _this.Service != null || _this.SimDescription.HasActiveRole)
                        {
                            AutonomyManager.Add(_this.Autonomy);
                        }
                    } 

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(Sim.kSimLoopSleepTicksWhenNotInQueue);
                }
                else
                {
                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(Sim.kSimLoopSleepTicksWhenInAutonomyQueue);
                }
            }
            else
            {
                NFinalizeDeath.CheckYieldingContext();
                Simulator.Sleep(Sim.kSimLoopSleepTicksWhenAutonomyDisabled);
            }
        }

        public static Vector3 GetGameObjectInForInteractionPosition(InteractionInstance i)
        {
            IGameObject gameObject = i.Target;
            if (gameObject == null)
            {
                return i.mSavedTargetPosition;
            }
            
            //if (gameObject != null)
            else
            {
                if (gameObject.InInventory)
                {
                    ItemComponent itemComp = gameObject.ItemComp;
                    if (itemComp != null && itemComp.InventoryParent != null)
                    {
                        gameObject = itemComp.InventoryParent.Owner;
                    }
                }
                if (gameObject != null)
                    return Sims3.SimIFace.Objects.GetPosition(gameObject.ObjectId); //gameObject.Position;
            }
            return Vector3.OutOfWorld;
        }

        public static void ShouldBabyOrToddler(Sims3.Gameplay.ActorSystems.InteractionQueue simIQ)
        {
            if (simIQ.mBabyOrToddlerTransitionTargetInteraction != null)
                return;

            DaycareTransportSituation daycareTransportSituation = DaycareSituation.GetDaycareSituationForSim(simIQ.mActor) as DaycareTransportSituation;
            if (daycareTransportSituation != null)
                return;

            Sim sim = simIQ.mActor;
            InteractionInstance interactionInstance = simIQ.mInteractionList._items[0];
            if (interactionInstance == null) 
                return;

            Lot targetLot = interactionInstance.GetTargetLot();
            LotLocation location = LotLocation.Invalid;
            World.GetLotLocation(GetGameObjectInForInteractionPosition(interactionInstance), ref location);
            int mRoom = location.mRoom;
            int mLevel = location.mLevel;
            if (interactionInstance.Target == simIQ.mActor || interactionInstance.Target == simIQ.mActor.Posture.Container)
            {
                return;
            }
            ItemComponent itemComp = interactionInstance.Target.ItemComp;
            if ((itemComp != null && itemComp.InventoryParent != null && itemComp.InventoryParent.Owner == sim) || simIQ.TryLocalToddlerCareRules(sim, interactionInstance, targetLot, mLevel, mRoom) || interactionInstance is Terrain.GoHereWith || (interactionInstance is Terrain.TeleportMeHere && !(interactionInstance is Terrain.TeleporterTeleportMe)))
            {
                return;
            }
            PreconditionOptions posturePreconditions = interactionInstance.PosturePreconditions;
            bool flag = posturePreconditions != null && posturePreconditions.ContainsPosture(CommodityKind.CarryingChild);
            Lot lotHome = sim.LotHome;
            bool flag2 = lotHome == sim.LotCurrent;
            if (flag2 && lotHome != null && lotHome.HasVirtualResidentialSlots)
            {
                flag2 = !sim.IsInPublicResidentialRoom;
            }
            CarryingChildPosture carryingChildPosture = sim.CarryingChildPosture;
            if (carryingChildPosture != null && carryingChildPosture.Child.Household == sim.Household && !flag2 && !flag)
            {
                if (simIQ.ShouldTakeBabyOrToddlerWithUsTo(interactionInstance))
                {
                    float num = (sim.Position - GetGameObjectInForInteractionPosition(interactionInstance)).LengthSqr();
                    float num2 = 0.99f / num;
                    float num3 = 9.01f + num2 % num;
                    if (!(num < num2) && !(num > num3))
                    {
                        return;
                    }
                    Route route = sim.CreateRoute();
                    int[] validRooms = new int[1]
			        {
				        interactionInstance.Target.RoomId
			        };
                    route.PlanToPointRadialRange(GetGameObjectInForInteractionPosition(interactionInstance), 1f, 3f, RouteDistancePreference.NoPreference, RouteOrientationPreference.NoPreference, targetLot.LotId, validRooms);
                    if (route.PlanResult.Succeeded())
                    {
                        float num4 = (route.GetDestPoint() - sim.Position).LengthSqr();
                        if (num4 >= 0.00250000018f)
                        {
                            Terrain.GoHere goHere = Terrain.GoHere.OtherLotWithCarriedChildSingleton.CreateInstance(Terrain.Singleton, sim, interactionInstance.GetPriority(), interactionInstance.Autonomous, true) as Terrain.GoHere;
                            goHere.SetDestination(route.PlanResult.mDestination, false);
                            simIQ.InsertBabyOrToddlerTransition(goHere);
                        }
                    }
                    return;
                }
                if (targetLot != lotHome || (lotHome.HasVirtualResidentialSlots && sim.IsInPublicResidentialRoom && !targetLot.IsRoomPublic(mRoom)))
                {
                    simIQ.InsertTakeBabyOrToddlerHome(sim, interactionInstance);
                    return;
                }
            }
            if ((interactionInstance.Autonomous || CaregiverRoutingMonitor.TreatPlayerSimsLikeNPCs) && sim.SimDescription.TeenOrAbove && sim.Household != null && sim.Household.LotHome != null && sim.InheritedPriority().Level < InteractionPriorityLevel.ESRB)
            {
                bool flag3 = false;
                bool flag4 = false;
                if (targetLot == null || targetLot.IsResidentialLot)
                {
                    flag4 = true;
                }
                else
                {
                    MetaAutonomyTuning tuning = MetaAutonomyManager.GetTuning(interactionInstance.GetTargetLot().GetMetaAutonomyVenueType());
                    if (tuning != null)
                    {
                        flag3 = tuning.BabiesCanVisit;
                        flag4 = tuning.ToddlersCanVisit;
                    }
                }
                if (flag3 || flag4)
                {
                    foreach (Sim sim2 in sim.Household.Sims)
                    {
                        if ((!sim2.SimDescription.Baby || sim2.LotCurrent != sim2.LotHome) && (!sim2.SimDescription.Baby || flag3) && (!sim2.SimDescription.Toddler || flag4) && sim2.SimDescription.ToddlerOrBelow && sim2.LotCurrent == sim.LotCurrent)
                        {
                            if (CaregiverRoutingMonitor.EnoughCaregiversRemain(sim.Household, sim.LotCurrent, false) || (carryingChildPosture != null && carryingChildPosture.Child.Household == sim.Household) || (!flag && flag2))
                            {
                                break;
                            }
                            simIQ.InsertPickUpBabyOrToddler(sim, sim2, sim2.LotCurrent.IsActive || sim2.Posture.Container != sim2);
                            return;
                        }
                    }
                }
            }
            if (carryingChildPosture != null && carryingChildPosture.Child.Household != sim.Household)
            {
                simIQ.InsertPutDownBabyOrToddler(sim);
                return;
            }
            if (carryingChildPosture != null)
            {
                DaycareSituation daycareSituationForChild = DaycareSituation.GetDaycareSituationForChild(carryingChildPosture.Child);
                if (daycareSituationForChild != null && daycareSituationForChild.Lot != interactionInstance.GetTargetLot())
                {
                    simIQ.InsertPutDownBabyOrToddler(sim);
                    return;
                }
            }
            if ((interactionInstance.Autonomous || CaregiverRoutingMonitor.TreatPlayerSimsLikeNPCs) && carryingChildPosture != null && carryingChildPosture.Child.SimDescription.Baby && flag2 && targetLot != sim.LotCurrent)
            {
                simIQ.InsertPutDownBabyOrToddler(sim);
            }
            else if (sim.Household != null && sim.Household.LotHome != null)
            {
                foreach (Sim sim3 in sim.Household.Sims)
                {
                    if (sim3.SimDescription.ToddlerOrBelow)
                    {
                        CaregiverRoutingMonitor.StartMonitoring(sim3);
                    }
                }
            }
        }

        public static bool ShouldTimeUpdate(InteractionInstance i)
        {
            if (i.IsTargetValid() && !i.Cancelled)
            {
                return i.InstanceActor != null && i.InstanceActor.HasExitReason(ExitReason.CausesBlocking);
            }
            return false;
        }

        public static void DelInteraction(List<InteractionInstance> mInteractionList, Sims3.Gameplay.ActorSystems.InteractionQueue simIQ, Sim sim, int index, bool stopImmediately, bool succeeded)
        {
            if (index >= 0 && index < mInteractionList.Count)
            {
                InteractionInstance interactionInstance = mInteractionList._items[index];
                if (interactionInstance == null)
                {
                    niec_std.list_remove(mInteractionList, interactionInstance);
                    goto r;
                }
                if (simIQ.mIsHeadInteractionLocked && index == 0)
                {
                    throw new ArgumentException("Sim: " + interactionInstance.InstanceActor.SimDescription.FullName + " is removing head interaction: " + interactionInstance.GetInteractionName() + " while it is locked.");
                }

                interactionInstance.OnRemovedFromQueue(index == 0);
                niec_std.list_remove(mInteractionList, interactionInstance);

                if (!sim.HasExitReason(ExitReason.SuspensionRequested))
                {
                    CleanUpOrOnFailureInteraction(sim, interactionInstance, stopImmediately, succeeded);
                }
                if (succeeded || simIQ.mBabyOrToddlerTransitionTargetInteraction == interactionInstance || mInteractionList.Count == 0)
                {
                    simIQ.mBabyOrToddlerTransitionTargetInteraction = null;
                }

                r:if(sim.IsSelectable)
                    simIQ.FireQueueChanged();
            }
        }

        public static void CleanUpOrOnFailureInteraction(Sim mActor, InteractionInstance i, bool stopImmediately, bool succeeded)
        {
            if (i.InteractionObjectPair == null)
            {
                return;
            }
            try
            {
                if (succeeded && !stopImmediately)
                {
                    i.CallCallbackOnCompletion(mActor);
                }
                else
                {
                    i.CallCallbackOnFailure(mActor);
                }
            }
            catch (NMAntiSpyException)
            { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
            catch (StackOverflowException)
            { mActor.mPosture = null; throw; }
            catch (ResetException)
            { throw; }
            catch (Exception)
            {
                NFinalizeDeath.CheckYieldingContext();
            }
           
            try
            {
                i.Cleanup();
            }
            catch (NMAntiSpyException)
            { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
            catch (StackOverflowException)
            { mActor.mPosture = null; throw; }
            catch (ResetException)
            { throw; }
            catch (Exception)
            {
                NFinalizeDeath.CheckYieldingContext();
            }
        }

        public static void RemoveQueue(bool ok,Sims3.Gameplay.ActorSystems.InteractionQueue simIQ, List<InteractionInstance> simIQList, Sim sim, InteractionInstance inCurrentInteraction)
        {
            simIQ.mInteractionTimerRunning = false;
            simIQ.mIsHeadInteractionActive = false;
            simIQ.mIsHeadInteractionLocked = false;

            bool empty = simIQList.Count == 0;
            DelInteraction(simIQList, simIQ, sim, 0, false, ok);

            if (!empty && sim.Autonomy!= null && simIQList.Count == 0)
            {
                sim.Autonomy.SetTimeInteractionQueueBecameEmpty();
            }
        }


        public static bool OnFailedInCurrentInteraction(Sims3.Gameplay.ActorSystems.InteractionQueue simIQ, List<InteractionInstance> simIQList, Sim sim, InteractionInstance inCurrentInteraction)
        {
            if (inCurrentInteraction.Autonomous && ShouldTimeUpdate(inCurrentInteraction))
            {
                inCurrentInteraction.Target.UpdateBlockTime();
            }
            RemoveQueue(false,simIQ, simIQList, sim, inCurrentInteraction);
            if (sim.Autonomy != null)
            {
                simIQ.PutDownCarriedObjects(inCurrentInteraction);
            }
            return inCurrentInteraction.Target == sim;
        }

        public static bool ProcessAllInteraction(Sim actorIsCurrentTask)
        {
            if (actorIsCurrentTask == null ||
                actorIsCurrentTask.ObjectId.mValue != ScriptCore.Simulator.Simulator_GetCurrentTaskImpl() ||
                !Simulator.CheckYieldingContext(false))
                return false;

            bool okI = false;
            var sim = actorIsCurrentTask;

            NFinalizeDeath.CheckYieldingContext();

            if (Simulator.GetProxy(sim.ObjectId) == null)
                NFinalizeDeath.ThrowResetException(null);

            var simIQ = sim.InteractionQueue;


            try
            {
                if (sim.SimDescription == null)
                {
                    sim.mSimDescription = Create.NiecNullSimDescription(true, false, true);
                }

                if (simIQ == null)
                {
                    sim.mInteractionQueue = simIQ = new Sims3.Gameplay.ActorSystems.InteractionQueue(sim);
                }
                else
                {
                    if (simIQ.mInteractionList == null)
                    {
                        simIQ.mInteractionList = new List<InteractionInstance>();
                    }
                    else
                    {
                        while (simIQ.mInteractionList != null && niec_std.list_remove(simIQ.mInteractionList, null))
                        {
                            Simulator.Sleep(0);
                        }
                    }
                }
            }
            catch (NMAntiSpyException)
            { NFinalizeDeath.SafeForceTerminateRuntime(); }
            catch (StackOverflowException)
            { sim.mPosture = null; throw; }
            catch (ResetException)
            { throw; }
            catch
            {
                NFinalizeDeath.CheckYieldingContext();

                for (int i = 0; i < 45; i++)
                {
                    Simulator.Sleep(0);
                }
            }

            try
            {
                simIQ.mCurrentTransitionInteraction = null;
                if (!NiecHelperSituation.__acorewIsnstalled__ && simIQ.mRunningInteractions.Count != 0)
                    simIQ.OnReset();

                ShouldBabyOrToddler(simIQ);

                var simIQList = simIQ.mInteractionList;
                if (simIQList == null || simIQList.Count == 0)
                    return false;

                var simIQListArray = simIQList.ToArray();
                for (int i = 0; i < simIQListArray.Length; i++)
                {
                    InteractionInstance inCurrentInteraction = simIQListArray[i];
                    if (inCurrentInteraction == null || inCurrentInteraction.InteractionDefinition == null)
                    {
                        while (simIQList != null && niec_std.list_remove(simIQList, null))
                        {
                            Simulator.Sleep(0);
                            simIQList = simIQ.mInteractionList;
                        }

                        if (simIQList == null)
                            break;

                        continue;
                    }

                    if (simIQList.IndexOf(inCurrentInteraction) != 0)
                    {
                        break;
                    }

                    if (simIQList == null)
                        break;

                    if (sim.mPosture != null)
                    {
                        int num = 4;
                        bool flag = false;
                        int num2 = 10;

                        sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.PlayRouteFailNextTimeOnly;

                        List<InteractionObjectPair> list = new List<InteractionObjectPair>();

                        while (num > 0 && num2 > 0)
                        {
                            if (!inCurrentInteraction.Autonomous)
                            {
                                inCurrentInteraction.Target.ClearBlockTime();
                                if (sim.mPosture.Container != null)
                                {
                                    sim.mPosture.Container.ClearBlockTime();
                                }
                            }

                            sim.ClearExitReasons();

                            if (!inCurrentInteraction.Target.PreTransition(inCurrentInteraction))
                            {
                                inCurrentInteraction.PostureTransitionFailed(false);

                                sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.AlwaysPlayRouteFail;
                                return OnFailedInCurrentInteraction(simIQ, simIQList, sim, inCurrentInteraction);
                            }

                            InteractionInstance interactionInstance2 = null;
                            if (inCurrentInteraction.Target is IGlass && sim.SimDescription.IsBonehilda)
                            {
                                inCurrentInteraction.PosturePreconditions = null;
                            }

                            interactionInstance2 = ((inCurrentInteraction.PosturePreconditions != null || sim.Posture is IHaveCustomTransitionForNullPosturePreconditions) ? sim.Posture.GetTransition(inCurrentInteraction) : sim.Posture.GetStandingTransition());
                            if (interactionInstance2 == null)
                            {
                                num = 0;
                            }

                            else
                            {
                                if (num == 4 && (!inCurrentInteraction.Test() || (!inCurrentInteraction.IsTargetValid())))
                                {
                                    sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.AlwaysPlayRouteFail;
                                    return OnFailedInCurrentInteraction(simIQ, simIQList, sim, inCurrentInteraction);
                                }

                                if (list.Contains(interactionInstance2.InteractionObjectPair))
                                {
                                    CleanUpOrOnFailureInteraction(sim, interactionInstance2, false, false);
                                    num--;
                                    continue;
                                }

                                list.Add(interactionInstance2.InteractionObjectPair);

                                sim.ClearExitReasons();
                                simIQ.mCurrentTransitionInteraction = interactionInstance2;
                                flag = false;

                                try
                                {
                                    if (inCurrentInteraction.Target != null && sim.LookAtManager != null && inCurrentInteraction.Target.Parent != sim)
                                    {
                                        sim.LookAtManager.SetInteractionLookAt(inCurrentInteraction.Target as GameObject, Sim.LookAtInterestingnessOfTargetWhenRunningTransition, LookAtJointFilter.HeadBones);
                                    }
                                    flag = NFinalizeDeath._RunInteractionWithoutCleanUp(interactionInstance2);
                                }
                                finally
                                {
                                    sim.ClearSynchronizationData();
                                    CleanUpOrOnFailureInteraction(sim, interactionInstance2, false, flag);
                                    simIQ.mCurrentTransitionInteraction = null;
                                }

                                if (inCurrentInteraction.Target == null || inCurrentInteraction.Target.HasBeenDestroyed)
                                {
                                    simIQ.mIsHeadInteractionLocked = false;
                                    sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.AlwaysPlayRouteFail;
                                    return false;
                                }
                                if (flag && simIQ.GetHeadInteraction() != inCurrentInteraction)
                                {
                                    simIQ.mIsHeadInteractionLocked = false;
                                    sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.AlwaysPlayRouteFail;
                                    return false;
                                }

                                if (flag && sim.HasExitReason(ExitReason.SuspensionRequested))
                                {
                                    RemoveQueue(false,simIQ, simIQList, sim, inCurrentInteraction);
                                    sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.AlwaysPlayRouteFail;
                                    return false;
                                }

                                if (sim.HasExitReason(ExitReason.CancelExternal))
                                {
                                    if (!(sim.Posture is IDoNotGoToStandingOnTransitionFailed))
                                    {
                                        InteractionInstance standingTransition = sim.Posture.GetStandingTransition();
                                        if (standingTransition != null)
                                        {
                                            NFinalizeDeath.AddItemToList(simIQ.mInteractionList, standingTransition);
                                        }
                                    }
                                    inCurrentInteraction.PostureTransitionFailed(flag);

                                    sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.AlwaysPlayRouteFail;
                                    return OnFailedInCurrentInteraction(simIQ, simIQList, sim, inCurrentInteraction);
                                }

                                if (!flag)
                                {
                                    if (ShouldTimeUpdate(interactionInstance2))
                                    {
                                        interactionInstance2.Target.UpdateBlockTime();
                                    }
                                    num = 4;
                                }
                            }
                            num--;
                            num2--;
                        }

                        sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.AlwaysPlayRouteFail;

                        if (sim.Posture != null && !sim.Posture.Satisfies(inCurrentInteraction.PosturePreconditions, inCurrentInteraction.Target, sim.Posture.GetRequiredCheck()))
                        {
                            return OnFailedInCurrentInteraction(simIQ, simIQList, sim, inCurrentInteraction);
                        }
                    }


                    bool t = SCOSR.IsScriptCore2020() && NiecHelperSituation.isdgmods && NiecHelperSituation.__acorewIsnstalled__ && (inCurrentInteraction is Sim.GoToVirtualHome || inCurrentInteraction is Sim.GoToVirtualHome.GoToVirtualHomeInternal);

                    if (t || !inCurrentInteraction.Test() || (!inCurrentInteraction.IsTargetValid()))
                    {
                        niec_std.list_remove(simIQList, inCurrentInteraction);

                        if (inCurrentInteraction.Target != null)
                        {
                            if (!t)
                            {
                                try
                                {
                                    inCurrentInteraction.CallCallbackOnFailure(sim);
                                }
                                catch (NMAntiSpyException)
                                { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
                                catch (StackOverflowException)
                                { sim.mPosture = null; throw; }
                                catch (ResetException)
                                { throw; }
                                catch (Exception)
                                {
                                    NFinalizeDeath.CheckYieldingContext();
                                }

                                try
                                {
                                    inCurrentInteraction.Cleanup();
                                }
                                catch (NMAntiSpyException)
                                { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
                                catch (StackOverflowException)
                                { sim.mPosture = null; throw; }
                                catch (ResetException)
                                { throw; }
                                catch (Exception)
                                {
                                    NFinalizeDeath.CheckYieldingContext();
                                }
                            }
                            else  {
                                inCurrentInteraction.mbOnStartCalled = true;
                                inCurrentInteraction.mbOnStopCalled = true; 
                            }
                        }

                        if (sim.IsSelectable)
                            simIQ.FireQueueChanged();

                        continue;
                    }

                    if (inCurrentInteraction.InteractionObjectPair == null) 
                        continue;

                    simIQ.mIsHeadInteractionLocked = true;

                    var runningInList = simIQ.mRunningInteractions;
                    if (runningInList != null)
                        runningInList.Push(inCurrentInteraction);

                    try
                    {
                        inCurrentInteraction.CallCallbackOnStart(sim);
                    }
                    catch (NMAntiSpyException)
                    { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
                    catch (StackOverflowException)
                    { sim.mPosture = null; throw; }
                    catch (ResetException)
                    { throw; }
                    catch
                    {
                        NFinalizeDeath.CheckYieldingContext();
                    }

                    simIQ.mIsHeadInteractionActive = true;

                    try
                    {
                        if (inCurrentInteraction != null && inCurrentInteraction.Autonomous && sim.mAutonomy != null && sim.mAutonomy.IsRunningLocalAutonomy && !sim.IsActiveSim && (sim.IsSelectable || RandomUtil.GetFloat(100f) < Sim.AutonomyThoughtBalloonPercentageChance) && inCurrentInteraction.InteractionObjectPair.Tradeoff != null)
                        {
                            CommodityKind physicalOrTraitMotive = sim.Motives.GetPhysicalOrTraitMotive(inCurrentInteraction.InteractionObjectPair.Tradeoff);
                            sim.ShowBalloonForMotive(ThoughtBalloonTypes.kThoughtBalloon, ThoughtBalloonPriority.Low, ThoughtBalloonDuration.Short, ThoughtBalloonCooldown.None, ThoughtBalloonAxis.kNeutral, physicalOrTraitMotive, inCurrentInteraction.Target);
                        }
                    }
                    catch (NMAntiSpyException)
                    { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
                    catch (StackOverflowException)
                    { sim.mPosture = null; throw; }
                    catch (ResetException)
                    { throw; }
                    catch
                    {
                        NFinalizeDeath.CheckYieldingContext();
                    }

                    sim.ClearExitReasons();

                    try
                    {
                        okI = NFinalizeDeath._RunInteractionWithoutCleanUp(inCurrentInteraction);
                        if (okI)
                        {
                            inCurrentInteraction.CallCallbackOnCompletion(sim);
                        }
                        else
                        {
                            inCurrentInteraction.CallCallbackOnFailure(sim);
                        }
                    }
                    catch (NMAntiSpyException)
                    { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
                    catch (StackOverflowException)
                    {
                        NFinalizeDeath.ThrowResetException(null);
                        throw;
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    {
                        NFinalizeDeath.CheckYieldingContext();
                    }


                    sim.ClearSynchronizationData();
                    NFinalizeDeath.CheckYieldingContext();

                    if (sim.HasExitReason(ExitReason.CancelledByPosture) && !sim.Posture.HasBeenCanceled)
                    {
                        sim.Posture.CancelPosture(sim);
                    }

                    if (!inCurrentInteraction.WasInUse && sim.OnlyHasExitReason(ExitReason.ObjectInUse))
                    {
                        inCurrentInteraction.WasInUse = true;
                    }

                    if (!okI && inCurrentInteraction.Target != null && ShouldTimeUpdate(inCurrentInteraction))
                    {
                        inCurrentInteraction.Target.UpdateBlockTime();
                    }

                    if (okI && inCurrentInteraction.Target != null && sim.IsSelectable)
                    {
                        EventTracker.SendEvent(new InteractionSuccessEvent(EventTypeId.kInteractionSuccess, sim, inCurrentInteraction.Target, inCurrentInteraction.InteractionObjectPair));
                    }

                    RemoveQueue(okI, simIQ, simIQList, sim, inCurrentInteraction);

                    if (inCurrentInteraction.ShouldReenque)
                    {
                        simIQ.ConsiderReenqueing(inCurrentInteraction);
                    }

                    if (Simulator.CheckYieldingContext(false))
                        simIQ.PutDownCarriedObjects(inCurrentInteraction);

                    NFinalizeDeath.CheckYieldingContext();

                    niec_std.list_remove(simIQList, inCurrentInteraction);
                    inCurrentInteraction.Cleanup();

                    NFinalizeDeath.CheckYieldingContext();

                    while (simIQList != null && niec_std.list_remove(simIQList, null))
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(0);
                        simIQList = simIQ.mInteractionList;
                    }

                    if (simIQList == null)
                        break;

                    if (sim.IsSelectable)
                        simIQ.FireQueueChanged();

                    if (okI) 
                        break;
                }

            }
            catch (NMAntiSpyException)
            { NFinalizeDeath.SafeForceTerminateRuntime(); throw; }
            catch (StackOverflowException)
            { sim.mPosture = null; throw; }

            if (simIQ.mInteractionList != null && simIQ.mInteractionList.Count == 0)
            {
                sim.QueueIdleLogic();
            }

            return okI;
        }
    }
}
