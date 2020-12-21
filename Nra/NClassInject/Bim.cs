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
    public class UpdateBim
    {
        

        

        public static void UpdateSim_Update(Autonomy _this)
        {
            if (_this == null || _this.Actor == null)
            {
                return;
            }

            if (_this.mLastTime == 0f)
            {
                _this.mLastTime = SimClock.ElapsedTime(TimeUnit.Minutes);
            }

            bool isActiveSim = _this.Actor.IsActiveSim;
            float lastTime = (NiecHelperSituation.isdgmods || Type.GetType("Awesome.Main", false) != null) ? _this.mLastTime : 0;
            float time = SimClock.ElapsedTimeInMinutes(ref lastTime);

            if (!_this.Actor.HasBeenDestroyed && time > 0f && (isActiveSim || time >= 1f))
            {
                if (_this.Actor.Motives != null)
                {
                    _this.Actor.Motives.UpdateMotives(time, _this.Actor);
                }
                if (_this.Actor.BuffManager != null)
                {
                    _this.Actor.BuffManager.UpdateBuffs(time);
                }
                if (_this.Actor.MoodManager != null)
                {
                    _this.Actor.MoodManager.UpdateMood(time, isActiveSim);
                }
                if (_this.Actor.SkillManager != null)
                {
                    _this.Actor.SkillManager.UpdateSkills(time);
                }
                if (_this.Actor.CareerManager != null)
                {
                    _this.Actor.CareerManager.UpdateCareers(time);
                }
                if (_this.Actor.SocialComponent != null)
                {
                    _this.Actor.SocialComponent.UpdateRelationships(time);
                }
                if (_this.Actor.OpportunityManager != null)
                {
                    _this.Actor.OpportunityManager.UpdateOpportunities();
                }
                if (_this.Actor.ThoughtBalloonManager != null && _this.Actor.ThoughtBalloonManager.NeedsToUpdate)
                {
                    _this.Actor.ThoughtBalloonManager.Update(time);
                }
                if (_this.Actor.MapTagManager != null)
                {
                    _this.Actor.MapTagManager.Update(time);
                }

                _this.mLastTime = lastTime;

                EventTracker.SendEvent(EventTypeId.kSimHeartbeat, _this.Actor);
                EventTracker.SendEvent(EventTypeId.kDnPSynchronizeEvent, _this.Actor);

                if (_this.Actor.DreamsAndPromisesManager != null && _this.Actor.DreamsAndPromisesManager.NeedsUpdate)
                {
                    _this.Actor.DreamsAndPromisesManager.SetToUpdate(true, false);
                }
            }
        }
    }

    [Persistable(false)]
    public class Bim : Sim
    {
        //public static bool DEBURUN = false;
        public static List<object> GCSafeList = new List<object>(5000);
        public static bool DontPlayReaction = false;
        public static bool XRun__ = false;
        public static bool XRun__X = false;
        public static bool AOrGROnlyRunningSim = false;
        public static Sim nullsim = null;

        public bool bimHasBeenDestroyed
        {
            get
            {
                return false;
            }
        }

        public void bimPlayCustomIdle(StateMachineClient smc, IEvent evt)
        {
            if (XRun__X)
                return;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            if (ObjectId.mValue == 0)
                return;
            if (SimDescription == null || !SimDescription.IsValidDescription)
                return;
            if (IdleManager == null)
                return;
            if (BuffManager == null)
                return;
            if (LookAtManager == null)
                return;
            if (OverlayComponent == null)
                return;
            if (Inventory == null)
                return;

            if (!(Posture is StandingPosture) || Posture.CurrentStateMachine == null || InteractionQueue == null || InteractionQueue.HasInteractionOfType(CustomIdle.Singleton))
            {
                return;
            }
            if ((base.Inventory.Find<IPhoneCell>() as GameObject) == null)
                return;
            Posture.CurrentStateMachine.SetParameter("CustomJazzGraph", false);
            CustomIdle customIdle = CustomIdle.Singleton.CreateInstance(this, this, new InteractionPriority(InteractionPriorityLevel.Zero), true, true) as CustomIdle;
            customIdle.Hidden = true;
            customIdle.JazzGraphName = IdleManager.LastCustomJazzGraph;
            customIdle.LoopTimes = IdleManager.LastLoopCount;
            if (customIdle.JazzGraphName == "TraitWorkaholic")
            {
                customIdle.IdleObject = (base.Inventory.Find<IPhoneCell>() as GameObject);
                customIdle.ObjectName = "phonecell";
            }
            else if (customIdle.JazzGraphName == "Photography_idle")
            {
                customIdle.IdleObject = (Photography.GetBestCameraFromInventory(this) as GameObject);
                if (customIdle.IdleObject is IPhone)
                {
                    customIdle.IdleObject = null;
                }
                else
                {
                    customIdle.ObjectName = "camera";
                }
            }
            else if (customIdle.JazzGraphName == "SmartPhoneIdles")
            {
                customIdle.IdleObject = (base.Inventory.Find<IPhoneSmart>() as GameObject);
                IPhoneSmart phoneSmart = customIdle.IdleObject as IPhoneSmart;
                customIdle.ObjectName = "smartphone";
                customIdle.VFX = VisualEffect.Create(phoneSmart.GetTextingEffect());
                customIdle.VFX.ParentTo(customIdle.IdleObject, Slot.FXJoint_0);
                customIdle.WaitAnimationToFinish = true;
            }
            else if (customIdle.JazzGraphName == "FuturePhoneIdles")
            {
                customIdle.IdleObject = (base.Inventory.Find<IPhoneFuture>() as GameObject);
                IPhoneFuture phoneFuture = customIdle.IdleObject as IPhoneFuture;
                customIdle.ObjectName = "smartphone";
                customIdle.VFX = VisualEffect.Create(phoneFuture.GetTextingEffect());
                customIdle.VFX.ParentTo(customIdle.IdleObject, Slot.FXJoint_0);
                customIdle.WaitAnimationToFinish = true;
            }
            if (customIdle.IdleObject != null)
            {
                base.Inventory.SetInUse(customIdle.IdleObject);
            }
            InteractionQueue.AddNext(customIdle);
        }
        public void bimChooseStandingIdle(StateMachineClient smc, IEvent evt)
        {
            if (XRun__X)
                return;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            if (ObjectId.mValue == 0)
                return;
            if (SimDescription == null || !SimDescription.IsValidDescription)
                return;
            if (IdleManager == null)
                return;
            if (BuffManager == null)
                return;
            if (LookAtManager == null)
                return;
            if (OverlayComponent == null)
                return;
            if (SimDescription.ToddlerOrBelow)
                return;

            BuffInstance element = BuffManager.GetElement(BuffNames.HeartBroken);
            if (((element != null && element.BuffOrigin == Origin.FromWitnessingDeath) || BuffManager.HasElement(BuffNames.Mourning)) && RandomUtil.RandomChance01(kMournPercentChance))
            {
                MournInteraction mournInteraction = MournInteraction.Singleton.CreateInstance(this, this, new InteractionPriority(InteractionPriorityLevel.Autonomous), true, true) as MournInteraction;
                mournInteraction.Hidden = true;
                InteractionQueue.AddNext(mournInteraction);
                return;
            }
            if (BuffManager.HasElement(BuffNames.ItsJustSoTragic) && RandomUtil.RandomChance01(kMournTragicClown))
            {
                MournTragicClown mournTragicClown = MournTragicClown.Singleton.CreateInstance(this, this, new InteractionPriority(InteractionPriorityLevel.Autonomous), true, true) as MournTragicClown;
                mournTragicClown.Hidden = true;
                InteractionQueue.AddNext(mournTragicClown);
                return;
            }

            string text = null;
            int num = 0;
            bool customJazzGraph;
            ProductVersion productVersion;
            do
            {
                if (text != null)
                {
                    return;
                }
                customJazzGraph = false;
                productVersion = ProductVersion.BaseGame;
                ThoughtBalloonPriority priority = mIdleManager.IsDistress ? ThoughtBalloonPriority.Extreme_ShowInSkewer : ThoughtBalloonPriority.Low;
                if (Standing.CurrentIdleInstance != null)
                {
                    text = Standing.CurrentIdleInstance.GetNextAnimationName();
                    productVersion = Standing.CurrentIdleInstance.ProductVersion;
                }
                if (string.IsNullOrEmpty(text))
                {
                    object thoughtBalloon;
                    ThoughtBalloonAxis thoughtBalloonAxis;
                    int nLoops;
                    string text2 = mIdleManager.ChooseStandingIdle(out thoughtBalloon, out thoughtBalloonAxis, out customJazzGraph, out productVersion, out nLoops);
                    DisplayIdleThoughtBalloon(thoughtBalloon, thoughtBalloonAxis, priority, IdleManager.IsDistress);
                    if (!string.IsNullOrEmpty(text2))
                    {
                        if (customJazzGraph)
                        {
                            Standing.CurrentIdleInstance = new IdleInstance(text2, productVersion);
                            text = Standing.CurrentIdleInstance.GetCustomJazzGraphName();
                        }
                        else
                        {
                            Standing.CurrentIdleInstance = new IdleInstance(text2, productVersion, nLoops);
                            text = Standing.CurrentIdleInstance.GetNextAnimationName();
                        }
                    }
                }
                mIdleManager.LastIdle = text;
            }
            while (num++ <= 150 && string.IsNullOrEmpty(text));
            if (!string.IsNullOrEmpty(text))
            {
                if (!customJazzGraph)
                {
                    smc.SetParameter("CustomJazzGraph", false);
                    smc.SetParameter("AnimationName", text, productVersion);
                }
                else
                {
                    smc.SetParameter("CustomJazzGraph", true);
                }
            }
        }
        public void bimPlayDynamicIdle(StateMachineClient smc, IEvent evt)
        {
            if (XRun__X)
                return;
            if (InWorld && ObjectId.mValue != 0 && mIdleManager != null && mLookAtManager != null && OverlayComponent != null)
            {
                if (mIdleManager.LastIdleHasAudio)
                {
                    if (IsPlayingAudio)
                    {
                        IdleManager.ChooseStandingIdleWithoutAudio();
                    }
                    else
                    {
                        IsPlayingAudio = true;
                    }
                }
                if (mIdleManager.LastIdle == "a_trait_insane_catchfly")
                {
                    smc.AddOneShotScriptEventHandler(1001u, mIdleManager.PlayCatchFlySound);
                }
                mLookAtManager.ClearAllLookAts(true);
                smc.RemoveEventHandler(base.OverlayComponent.InteractionPartLevelCallback);
                smc.RemoveEventHandler(base.OverlayComponent.ClearInteractionPartLevelCallback);
                PlayFacialIdle(smc, evt);
                base.OverlayComponent.UpdateInteractionFreeParts(IdleManager.LastAwarenessLevel);
            }
        }

        public void bimExitDynamicIdle(StateMachineClient smc, IEvent evt)
        {
            if (XRun__X)
                return;
            if (InWorld && ObjectId.mValue != 0 && mIdleManager != null && OverlayComponent != null)
            {
                if (mIdleManager.LastIdleHasAudio)
                {
                    IsPlayingAudio = false;
                    mIdleManager.StopIdleSound();
                }
                base.OverlayComponent.UpdateInteractionFreeParts(AwarenessLevel.OverlayUpperbody);
                smc.AddPersistentSacsEventHandler(SacsEventSubTypes.kSacsEventOverlayLevelEvent, base.OverlayComponent.InteractionPartLevelCallback);
                smc.AddPersistentSacsEventHandler(SacsEventSubTypes.kSacsEventAnimationDone, base.OverlayComponent.ClearInteractionPartLevelCallback);
            }
        }

        public void bimChooseSeatedIdle(StateMachineClient smc, IEvent evt)
        {
            if (XRun__X)
                return;
            if (InWorld && ObjectId.mValue != 0 && mIdleManager != null && OverlayComponent != null)
            {
                ThoughtBalloonPriority priority = IdleManager.IsDistress ? ThoughtBalloonPriority.Extreme_ShowInSkewer : ThoughtBalloonPriority.Low;
                bool isLivingChair = false;
                bool hidden = false;
                SittingPosture sittingPosture = Posture as SittingPosture;
                if (sittingPosture != null)
                {
                    SitData target = sittingPosture.Part.Target;
                    isLivingChair = (target != null && target.SitStyle == SitStyle.Living);
                }
                string thoughtBalloon;
                ProductVersion productVersion;
                string text = IdleManager.ChooseSeatedIdle(out thoughtBalloon, isLivingChair, out hidden, out productVersion);
                if (string.IsNullOrEmpty(text))
                {
                    smc.SetParameter("Hidden", true);
                }
                else
                {
                    smc.SetParameter("AnimationName", text, productVersion);
                    smc.SetParameter("Hidden", hidden);
                }
                DisplayIdleThoughtBalloon(thoughtBalloon, ThoughtBalloonAxis.kNeutral, priority, IdleManager.IsDistress);
            }
        }

        public void bimDispose() {
            if (XRun__X)
                return;
            nullsim = this;

            var t = mThoughtBalloonManager;
            if (t != null)
            {
                if (ListCollon.SafeObjectGC != null)
                {
                    ListCollon.SafeObjectGC.Add(t);

                    if (t.CurrentBalloon != null)
                        ListCollon.SafeObjectGC.Add(t.CurrentBalloon);
                    if (t.mPendingBalloons != null)
                        ListCollon.SafeObjectGC.Add(t.mPendingBalloons);
                }

                if (t.mEffect != null)
                {
                    if (ListCollon.SafeObjectGC != null)
                        ListCollon.SafeObjectGC.Add(t.mEffect);
                    t.mEffect.SetAutoDestroy(false);
                }

                t.mPendingBalloons = null;
                t.mCurrentBalloon = null;
                t.mEffect = null;

                mThoughtBalloonManager = null;
            }

        }

        public void bimLoopIdle()
        {
            if (XRun__X)
                return;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            if (!mIsAlreadyIdling)
            {
                mIsAlreadyIdling = true;
                try
                {
                    if (BridgeOrigin != null)
                    {
                        var bridgeOrigin = BridgeOrigin;
                        BridgeOrigin = null;
                        bridgeOrigin.MakeRequest();
                    }
                    PostureIdle();
                }
                catch (NotSupportedException ex)
                {
                    if (ex.source == "SimIFace")
                    {
                        if (!Instantiator.NSMCINJECT)
                            throw;
                        Simulator.Sleep(0);
                        mIsAlreadyIdling = false;
                    }
                    else throw;
                }
                catch (SacsErrorException)
                {
                    Simulator.Sleep(0);
                    mIsAlreadyIdling = false;
                }
            }
        }

        public void bimStandingBridgeOriginUsed()
        {
            if (XRun__X)
                return;

            mPostureReturnedBridgeOrigin = false;
            mIsAlreadyIdling = false;

            if (IdleManager != null && base.ObjectId.mValue != 0)
                IdleManager.StopFacialIdle(true);
        }


        public void bimRouteFailure()
        {
            if (XRun__X)
                return;

            if (SimDescription.ToddlerOrBelow || Posture == null)// || !Posture.AllowsRouting()) 
            {
                for (int i = 0; i < 100; i++)
                {
                    Simulator.Sleep(0);
                }
                return;
            }

            for (int i = 0; i < 20; i++)
            {
                if (NiecHelperSituation.__acorewIsnstalled__)
                {
                    if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                    {
                        NFinalizeDeath.RUNIACORE(false);
                    }
                    else NFinalizeDeath.CheckNHSP();
                }

                if (ObjectId.mValue == 0)
                    return;

                PopCanePostureIfNecessary();

                //var scubaDiving = Posture as ScubaDiving;
                if (Posture is ScubaDiving)
                {
                    PlaySoloAnimation(SimDescription.IsMatureMermaid ? "a_mermaid_diveSwim_routeFail_x" : "a_scubaDiving_routeFail_x", true, ProductVersion.EP10);
                }

                else
                {
                    StateMachineClient stateMachineClient = null;
                    try
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        stateMachineClient = StateMachineClient.Acquire(this, "routeFail");
                        if (stateMachineClient == null)
                            return;

                        stateMachineClient.AddInterest<ScriptPosture>();
                        var beingRiddenPosture = Posture as BeingRiddenPosture;

                        if (beingRiddenPosture != null)
                        {
                            stateMachineClient.SetActor("x", this);
                            stateMachineClient.SetActor("y", beingRiddenPosture.Rider);
                            stateMachineClient.EnterState("x", "Enter");
                            stateMachineClient.EnterState("y", "Enter");
                            stateMachineClient.RequestState(false, "x", "RouteFailMounted");
                            stateMachineClient.RequestState(true, "y", "RouteFailMounted");
                            stateMachineClient.RequestState("x", "Exit Synced");
                        }
                        else
                        {
                            stateMachineClient.SetActor("x", this);
                            stateMachineClient.EnterState("x", "Enter");
                            NFinalizeDeath.CheckYieldingContext();
                            stateMachineClient.RequestState("x", "RouteFail");
                            NFinalizeDeath.CheckYieldingContext();
                            stateMachineClient.RequestState("x", "Exit");
                        }
                    }
                    catch (SacsErrorException)
                    {
                        if (stateMachineClient != null)
                            stateMachineClient.Dispose();
                        break;
                    }

                    if (stateMachineClient != null)
                        stateMachineClient.Dispose();
                }

                if (NiecHelperSituation.__acorewIsnstalled__)
                {
                    for (int xi = 0; xi < 5; xi++)
                    {
                        TraitFunctions.TraitReactionOnRouteFailure(this, ReactionSpeed.Immediate);
                    }
                }

                if (!NiecHelperSituation.__acorewIsnstalled__ || !NiecHelperSituation.isdgmods)
                    break;
            }
        }

        public bool bimPlayReaction(ReactionTypes reactionType, InteractionPriority priority, GameObject target, string thoughtBalloon, ResourceKey key, ThoughtBalloonAxis axis, ReactionSpeed reactionSpeed, PlayReactionCallback beforeCallback, PlayReactionCallback callback, bool ShouldWatchUntilExit, float timeout, bool doubleBalloon, bool allowWhileSleeping)
        {
            if (DontPlayReaction)
                return false;
            if (Sims3.SimIFace.Environment.HasEditInGameModeSwitch)
            {
                return false;
            }
            if (IsSleeping && !allowWhileSleeping)
            {
                return false;
            }
            InteractionInstance currentInteraction = CurrentInteraction;
            if (currentInteraction is IInteractionDoesntAllowReactions)
            {
                return false;
            }

            target = NFinalizeDeath.SActorAndActiveActor_AAndChildAndTeen ?? target;

            bool flag = false;
            Sim sim = target as Sim;
            if (sim != null && sim.SimDescription.ToddlerOrBelow && Genealogy.IsParentOrStepParent(sim.Genealogy))
            {
                flag = true;
            }
            Posture posture = Posture;
            if (posture is CarryingChildPosture && (currentInteraction == null || currentInteraction.GetPriority().Level <= InteractionPriorityLevel.UserDirected) && reactionSpeed != ReactionSpeed.Immediate)
            {
                return false;
            }
            if (reactionType == ReactionTypes.None || reactionSpeed == ReactionSpeed.None)
            {
                if (beforeCallback != null)
                {
                    beforeCallback(this, target, ReactionTypes.None, ReactionSpeed.None, false);
                }
                if (callback != null)
                {
                    callback(this, target, ReactionTypes.None, ReactionSpeed.None, false);
                }
                return false;
            }
            //if (posture is SwimmingInPool || posture is SittingInVehicle || posture is RidingPosture)
            //{
            //    if (beforeCallback != null)
            //    {
            //        beforeCallback(this, target, ReactionTypes.None, ReactionSpeed.None, false);
            //    }
            //    if (callback != null)
            //    {
            //        callback(this, target, reactionType, ReactionSpeed.None, false);
            //    }
            //    return false;
            //}
            bool flag2 = 0 != (reactionSpeed & ReactionSpeed.Immediate);
            bool flag3 = 0 != (reactionSpeed & ReactionSpeed.ImmediateWithoutOverlay);
            bool flag4 = 0 != (reactionSpeed & ReactionSpeed.AfterInteraction);
            //if (flag3)
            //{
            //    if (Simulator.CurrentTask != base.ObjectId)
            //    {
            //        return false;
            //    }
            //}
            //else 
            //if ((Conversation != null || posture is SocializingPosture) && priority.Level <= InteractionPriorityLevel.UserDirected)
            //{
            //    return false;
            //}
            if (mIsAlreadyIdling && IsStandingIdle && flag2)
            {
                flag2 = false;
                flag4 = true;
            }
            if (flag2 && (mIsAlreadyIdling || (IsRouting && CarryStateMachine == null && (SimRoutingComponent.CheckCanPlayReactionAtEndOfRoute() || (base.RoutingComponent != null && base.RoutingComponent.GetDistanceRemainingOnRoute() >= SimScriptAdaptor.DistanceToTriggerOverlay)))) && (!IdleManager.sReactionAnimations.ContainsKey(reactionType) || IdleManager.TestReactionAnimation(reactionType, flag, true)))
            {
                //if (posture == null || !posture.AllowsReactionOverlay())
                //{
                //    return false;
                //}
                if (beforeCallback != null)
                {
                    beforeCallback(this, target, reactionType, ReactionSpeed.Immediate, true);
                }
                bool flag5 = base.OverlayComponent.PlayReaction(reactionType, target, false);
                if (flag5 || reactionSpeed != ReactionSpeed.NowOrLater)
                {
                    bool flag6 = target != null && target.ObjectId != ObjectGuid.InvalidObjectGuid && !target.HasBeenDestroyed && target.InWorld;
                    if (flag6)
                    {
                        LookAtManager.ConsiderReactionLookAt(target, 50, LookAtJointFilter.TorsoBones);
                    }
                    ThoughtBalloonManager.BalloonData balloonData = null;
                    if (doubleBalloon)
                    {
                        if (flag6)
                        {
                            ThumbnailKey thoughtBalloonThumbnailKey = target.GetThoughtBalloonThumbnailKey();
                            if (!string.IsNullOrEmpty(thoughtBalloon))
                            {
                                balloonData = new ThoughtBalloonManager.DoubleBalloonData(thoughtBalloonThumbnailKey, thoughtBalloon);
                            }
                            else if (key != ResourceKey.kInvalidResourceKey)
                            {
                                balloonData = new ThoughtBalloonManager.DoubleBalloonData(thoughtBalloonThumbnailKey, new ThumbnailKey(key, ThumbnailSize.Large));
                            }
                        }
                        else if (key != ResourceKey.kInvalidResourceKey && !string.IsNullOrEmpty(thoughtBalloon))
                        {
                            balloonData = new ThoughtBalloonManager.DoubleBalloonData(new ThumbnailKey(key, ThumbnailSize.Large), thoughtBalloon);
                        }
                    }
                    if (balloonData == null)
                    {
                        if (key != ResourceKey.kInvalidResourceKey)
                        {
                            balloonData = new ThoughtBalloonManager.BalloonData(new ThumbnailKey(key, ThumbnailSize.Large));
                        }
                        else if (!string.IsNullOrEmpty(thoughtBalloon))
                        {
                            balloonData = ThoughtBalloonManager.GetBalloonData(thoughtBalloon, this);
                        }
                        else if (flag6)
                        {
                            balloonData = new ThoughtBalloonManager.BalloonData(target.GetThoughtBalloonThumbnailKey());
                        }
                    }
                    if (balloonData != null && balloonData.IsValid)
                    {
                        balloonData.LowAxis = axis;
                        ThoughtBalloonManager.ShowBalloon(balloonData);
                    }
                    if (callback != null)
                    {
                        callback(this, target, reactionType, ReactionSpeed.Immediate, flag5);
                    }
                    return flag5;
                }
            }
            if ((flag3 || flag4) && IdleManager.sReactionAnimations.ContainsKey(reactionType))
            {
                priority.Level += 2;
                var reactionInteraction = ReactionInteraction.Singleton.CreateInstance(this, this, this.Household == Household.ActiveHousehold ? new InteractionPriority(InteractionPriorityLevel.Zero) : priority, true, true) as ReactionInteraction;

                reactionInteraction.SetReactionType(reactionType);
                reactionInteraction.SetLookAtTarget(target);
                reactionInteraction.SetRoute(reactionSpeed == ReactionSpeed.CriticalWithRoute);
                reactionInteraction.SetThoughtBalloon(thoughtBalloon);
                reactionInteraction.SetThoughtBalloonAxis(axis);
                reactionInteraction.SetResourceKey(key);
                reactionInteraction.SetReactionBeforeCallback(beforeCallback);
                reactionInteraction.SetReactionCallback(callback);
                reactionInteraction.SetWatch(ShouldWatchUntilExit);
                reactionInteraction.SetCheckOwnChild(flag);
                reactionInteraction.SetPosture(posture);

                if (this.Household == Household.ActiveHousehold)
                { }
                else
                {
                    reactionInteraction.Hidden = true;
                    reactionInteraction.mMustRun = true;
                }

                reactionInteraction.SetTimeout(timeout, SimClock.Add(SimClock.CurrentTime(), TimeUnit.Minutes, timeout));
                InteractionQueue.CancelAllInteractionsByType(ReactionInteraction.Singleton);


                if (flag3)
                {
                    NiecTask.PerformSID(ScriptExecuteType.Threaded,() =>
                    {
                        NFinalizeDeath._RunInteraction(reactionInteraction);
                    });
                    return true;
                }
                if (this.Household == Household.ActiveHousehold)
                { return InteractionQueue.AddNext(reactionInteraction); }
                else
                {
                    return InteractionQueue.Add(reactionInteraction);
                }
            }
            return false;
        }

        public static int checkintabimIsPointInLotSafelyRoutable = 0;
        public static bool chekcdont = false;

        public bool bimHandToolAllowIntersection(IGameObject objectToIntersect, Matrix44 testMatrix, bool bThisObjectShifted)
        {
            if (chekcdont || Posture == null)
                return false;

            if (Posture.OverrideAllowIntersection)
            {
                return Posture.HandToolAllowIntersection(objectToIntersect, testMatrix, bThisObjectShifted);
            }
            return false;
        }


        public bool bimIsPointInLotSafelyRoutable(Lot lot, Vector3 pos)
        {
            if (checkintabimIsPointInLotSafelyRoutable > 5)
            {
                return false;
            }
            try
            {
                if (lot == null || lot.Corners == null)
                {
                    return false;
                }
                if (pos.IsSimilarTo(Vector3.Zero) || pos.IsSimilarTo(Vector3.OutOfWorld))
                {
                    return false;
                }
                LotLocation location = LotLocation.Invalid;
                ulong lotLocation = World.GetLotLocation(pos, ref location);
                if (lot.IsWorldLot || lotLocation == lot.LotId)
                {
                    switch (World.GetTerrainType(pos))
                    {
                        case TerrainType.WorldSea:
                        case TerrainType.WorldPond:
                        case TerrainType.LotPool:
                        case TerrainType.LotPond:
                            return false;
                        default:
                            if (!lot.IsWorldLot)
                            {
                                Route route = SimRoutingComponent.CreateRouteAsAdult();
                                route.SetOption(Route.RouteOption.EnableWaterPlanning, IsHuman);
                                float num = 1f;
                                if (lot.IsHouseboatLot())
                                {
                                    num += 1f;
                                }
                                for (int i = 0; i < 4; i++)
                                {
                                    RadialRangeDestination radialRangeDestination = new RadialRangeDestination();
                                    radialRangeDestination.mCenterPoint = lot.Corners[i];
                                    radialRangeDestination.mfMinRadius = 0f;
                                    radialRangeDestination.mfMaxRadius = num;
                                    route.AddDestination(radialRangeDestination);
                                    radialRangeDestination = new RadialRangeDestination();
                                    int corner = (i + 1) % 4;
                                    radialRangeDestination.mCenterPoint = (lot.Corners[i] + lot.Corners[corner]) * 0.5f;
                                    radialRangeDestination.mfMinRadius = 0f;
                                    radialRangeDestination.mfMaxRadius = num;
                                    route.AddDestination(radialRangeDestination);
                                }
                                route.PlanFromPoint(pos);
                                if (route.PlanResult.mType != RoutePlanResultType.Succeeded)
                                {
                                    return false;
                                }
                            }
                            return true;
                    }
                }
            }
            catch (Exception)
            {
                checkintabimIsPointInLotSafelyRoutable++;
                if (checkintabimIsPointInLotSafelyRoutable > 5)
                {
                    NFinalizeDeath.LoopISPoIntPos();
                }
                return false;
            }

            return false;
        }

        public void bimSetSacsDefaultParameters(StateMachineClient smc, string actorName)
        {
            if (smc != null && mSimDescription != null)
            {
                if (base.OverlayComponent != null)
                {
                    smc.AddPersistentSacsEventHandler(SacsEventSubTypes.kSacsEventOverlayLevelEvent, base.OverlayComponent.InteractionPartLevelCallback);
                    smc.AddPersistentSacsEventHandler(SacsEventSubTypes.kSacsEventAnimationDone, base.OverlayComponent.ClearInteractionPartLevelCallback);
                }
                Age age;
                switch (mSimDescription.Age)
                {
                    case CASAgeGenderFlags.Baby:
                        age = Age.baby;
                        break;
                    case CASAgeGenderFlags.Toddler:
                        age = Age.todler;
                        break;
                    case CASAgeGenderFlags.Child:
                        age = Age.child;
                        break;
                    case CASAgeGenderFlags.Teen:
                        age = Age.teen;
                        break;
                    case CASAgeGenderFlags.YoungAdult:
                        age = Age.young_adult;
                        break;
                    case CASAgeGenderFlags.Adult:
                        age = Age.adult;
                        break;
                    case CASAgeGenderFlags.Elder:
                        age = Age.elder;
                        break;
                    default:
                        age = Age.todler;
                        break;
                }
                Species species;
                switch (mSimDescription.Species)
                {
                    case CASAgeGenderFlags.Horse:
                        species = Species.horse;
                        break;
                    case CASAgeGenderFlags.Dog:
                        species = Species.dog;
                        break;
                    case CASAgeGenderFlags.Cat:
                        species = Species.cat;
                        break;
                    case CASAgeGenderFlags.LittleDog:
                        species = Species.littleDog;
                        break;
                    case CASAgeGenderFlags.Deer:
                        species = Species.deer;
                        break;
                    case CASAgeGenderFlags.Raccoon:
                        species = Species.raccoon;
                        break;
                    default:
                        species = Species.human;
                        break;
                }
                if (TraitManager != null && TraitManager.List != null)
                {
                    foreach (Trait item3 in TraitManager.List)
                    {
                        if (item3 != null)
                        {
                            smc.SetParameter(actorName, typeof(TraitNames), (ulong)item3.Guid, YesOrNo.yes);
                        }
                    }
                }
                if (BuffManager != null && BuffManager.List != null)
                {
                    foreach (BuffInstance item2 in BuffManager.List)
                    {
                        if (item2 != null && item2.mBuff != null)
                        {
                            smc.SetParameter(actorName, typeof(BuffNames), (ulong)item2.mBuff.BuffGuid, YesOrNo.yes);
                        }
                    }
                }
                if (MoodManager != null)
                {
                    MoodFlavor moodFlavor = MoodManager.MoodFlavor;
                    if (moodFlavor != 0 && moodFlavor != MoodFlavor.Fulfilled)
                    {
                        smc.SetParameter(actorName, typeof(MoodFlavor), (ulong)MoodManager.MoodFlavor, YesOrNo.yes);
                    }
                }
                uint paramHash9;
                uint paramHash8;
                uint paramHash7;
                uint paramHash6;
                uint paramHash5;
                switch (actorName[0])
                {
                    case 'X':
                    case 'x':
                        paramHash9 = 499670524u;
                        paramHash8 = 3485968198u;
                        paramHash7 = 1341508501u;
                        paramHash6 = 2555509350u;
                        paramHash5 = 3242275675u;
                        break;
                    case 'Y':
                    case 'y':
                        paramHash9 = 2084444177u;
                        paramHash8 = 1976724487u;
                        paramHash7 = 1780181412u;
                        paramHash6 = 2689495323u;
                        paramHash5 = 585333186u;
                        break;
                    case 'Z':
                    case 'z':
                        paramHash9 = 3151015778u;
                        paramHash8 = 2159644272u;
                        paramHash7 = 2309280715u;
                        paramHash6 = 2470126784u;
                        paramHash5 = 3937651281u;
                        break;
                    default:
                        paramHash9 = ResourceUtils.HashString32(actorName + ":Age");
                        paramHash8 = ResourceUtils.HashString32(actorName + ":InBadMood");
                        paramHash7 = ResourceUtils.HashString32(actorName + ":Sex");
                        paramHash6 = ResourceUtils.HashString32(actorName + ":ScriptPosture");
                        paramHash5 = ResourceUtils.HashString32(actorName + ":Species");
                        break;
                }
                smc.SetParameter(paramHash9, typeof(Age), (ulong)age);
                smc.SetParameter(paramHash8, (uint)(MoodManager != null && MoodManager.IsInNegativeMood ? 979470758 : 1668749452));
                smc.SetParameter(paramHash7, (mSimDescription.Gender == CASAgeGenderFlags.Male) ? 3111576190u : 2204441813u);
                smc.SetParameter(paramHash5, typeof(Species), (ulong)species);
                if (Posture != null)
                {
                    smc.SetParameter(paramHash6, typeof(ScriptPosture), (ulong)Posture.GetSacsPostureParameter());
                }
            }
        }

        public void bimSimulate()
        {
            if (XRun__)
                return;

            this.Autonomy.SetTimeInteractionQueueBecameEmpty();

            while (true)
            {
                if (!AOrGROnlyRunningSim || NFinalizeDeath.SimIsGRReaper(SimDescription) || this == (NPlumbBob.DoneInitClass ? NFinalizeDeath.GetSafeSelectActor() : PlumbBob.SelectedActor))
                {
                    FoundInteraction(this);
                    Simulator.Sleep(0);
                }
                else
                {
                    LoopIdle();
                    Simulator.Sleep(0);
                }
            }
        }



        public void bboolDoOnReset(Sims3.Gameplay.Abstracts.GameObject.ResetInformation resetInformation)
        {
            if (mPosture != null)
                mPosture.OnReset(this);
        }

        public static void bSDestroy(Sim _this)
        {
            nullsim = _this;
            var proxy = _this.Proxy as ScriptCore.ScriptProxy;

            var t = _this.mThoughtBalloonManager;
            if (t != null)
            {
                if (ListCollon.SafeObjectGC != null)
                {
                    ListCollon.SafeObjectGC.Add(t);

                    if (t.CurrentBalloon != null)
                        ListCollon.SafeObjectGC.Add(t.CurrentBalloon);
                    if (t.mPendingBalloons != null)
                        ListCollon.SafeObjectGC.Add(t.mPendingBalloons);
                }

                if (t.mEffect != null)
                {
                    if (ListCollon.SafeObjectGC != null)
                        ListCollon.SafeObjectGC.Add(t.mEffect);
                    t.mEffect.SetAutoDestroy(false);
                }

                t.mPendingBalloons = null;
                t.mCurrentBalloon = null;
                t.mEffect = null;

                _this.mThoughtBalloonManager = null;
            }

            var iq = _this.InteractionQueue;
            if (iq != null)
            {
                if (iq.mInteractionList != null)
                {
                    NFinalizeDeath.AddItemToList(GCSafeList, iq.mInteractionList);
                    if (NiecHelperSituation.isdgmods)
                    {
                        iq.mInteractionList = new List<InteractionInstance>();
                    }
                    else iq.mInteractionList = null;
                }
                if (iq.mRunningInteractions != null)
                {
                    NFinalizeDeath.AddItemToList(GCSafeList, iq.mRunningInteractions);
                    if (NiecHelperSituation.isdgmods)
                    {
                        iq.mRunningInteractions = new Stack<InteractionInstance>();
                    }
                    else
                        iq.mRunningInteractions = null;
                }
            }

            Simulator.DestroyObject(_this.mSimUpdateId);
            Simulator.DestroyObject(_this.ObjectId);

            if (proxy != null)
            {
                proxy.mTarget = null;
                proxy.mObjectId.mValue = 0;
            }

            var simd = _this.SimDescription;
            if (simd != null)
            {
                simd.mSim = null;
                _this.mSimDescription = Create.NiecNullSimDescription(false, false, false);
                _this.mSimDescription.mSim = _this;
            }
            else
            {
                _this.mSimDescription = Create.NiecNullSimDescription(false, false, false);
                _this.mSimDescription.mSim = _this;
            }

            NFinalizeDeath.AddItemToList(ListCollon.SafeObjectGC_TempBim, _this);

            NiecTask.Perform(NiecRunCommand.fixsimlist_command);
        }

        /*
         DebugString: "NMScript Exception Log
         System.Exception: DEBUG bboolDestroy(): True Name: John Floda
         
         #0: 0x0004b throw      in Sims3.Gameplay.Actors.Sims3.Gameplay.Actors.Sim:Destroy () ()
         #1: 0x00080 callvirt   in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.SimDescription:Dispose (bool,bool,bool,bool,bool) (57088990 [1] [0] [0] [0] [1] )
         #2: 0x00006 call       in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.SimDescription:Dispose () ()
         #3: 0x00517 callvirt   in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.Annihilation:Perform (Sims3.Gameplay.CAS.SimDescription,bool) ([57088990] [1] )
         #4: 0x00052 call       in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.Annihilation:Cleanse (Sims3.UI.CAS.IMiniSimDescription) ([57088990] )
         #5: 0x000fa call       in NRaas.RegisterSpace.Helpers.NRaas.RegisterSpace.Helpers.ServiceCleanup:AttemptServiceDisposal (Sims3.Gameplay.CAS.SimDescription,bool,string) ([57088990] [0] [46E0AB98] )
         #6: 0x002a8 call       in NRaas.RegisterSpace.Helpers.ServiceCleanup+Task:Perform () ()
         #7: 0x0003a call       in NRaas.NRaas.Register:OnRestoreRoles () ()
         #8: 0x00000            in Sims3.Gameplay.Sims3.Gameplay.Function:Invoke () ()
         #9: 0x00003 callvirt   in NRaas.Common+FunctionTask:Simulate () ()
         */
        public unsafe void bboolDestroy()
        {
            if (XRun__X)
                return;

            nullsim = this;
            var simd = SimDescription;
            if (niec_native_func.cache_done_niecmod_native_debug_text_to_debugger)
            {
                try
                {
                    var name = simd != null ? simd.FullName : "No Name";

                    throw new Exception("DEBUG bboolDestroy(): " + (Type.GetType("Sims3.Gameplay.Core.PlumbBob") != null) + " Name: " + name);
                }
                catch (Exception ex)
                {
                    NiecException.SendTextExceptionToDebugger(ex);
                }
            }

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            var t = mThoughtBalloonManager;
            if (t != null)
            {
                if (ListCollon.SafeObjectGC != null)
                {
                    ListCollon.SafeObjectGC.Add(t);

                    if (t.CurrentBalloon != null)
                        ListCollon.SafeObjectGC.Add(t.CurrentBalloon);
                    if (t.mPendingBalloons != null)
                        ListCollon.SafeObjectGC.Add(t.mPendingBalloons);
                }

                if (t.mEffect != null)
                {
                    if (ListCollon.SafeObjectGC != null)
                        ListCollon.SafeObjectGC.Add(t.mEffect);
                    t.mEffect.SetAutoDestroy(false);
                }

                t.mPendingBalloons = null;
                t.mCurrentBalloon = null;
                t.mEffect = null;

                mThoughtBalloonManager = null;
            }

            var iq = this.InteractionQueue;
            if (iq != null)
            {
                if (iq.mInteractionList != null)
                {
                    NFinalizeDeath.AddItemToList(GCSafeList, iq.mInteractionList);
                    if (NiecHelperSituation.isdgmods)
                    {
                        iq.mInteractionList = new List<InteractionInstance>();
                    }
                    else iq.mInteractionList = null;
                }
                if (iq.mRunningInteractions != null)
                {
                    NFinalizeDeath.AddItemToList(GCSafeList, iq.mRunningInteractions);
                    if (NiecHelperSituation.isdgmods)
                    {
                        iq.mRunningInteractions = new Stack<InteractionInstance>();
                    }
                    else
                        iq.mRunningInteractions = null;
                }
            }


            var proxy = Proxy as ScriptCore.ScriptProxy;

            Simulator.DestroyObject(mSimUpdateId);
            Simulator.DestroyObject(ObjectId);

            if (proxy != null)
            {
                proxy.mTarget = null;
                proxy.mObjectId.mValue = 0;
            }

            if (simd != null)
            {
                simd.mSim = null;
            }

            mSimDescription = Create.NiecNullSimDescription(false, false, false);
            mSimDescription.mSim = this;

            NFinalizeDeath.AddItemToList(ListCollon.SafeObjectGC_TempBim, this);
        }

        public bool bboolCanBeKill()
        {
            return true;
        }

        public bool bboolIsDying()
        {
            return false;
        }

        public bool Sim_NonOpenDGSKill(SimDescription.DeathType deathType, GameObject target, bool playDeathAnim)
        {
            //DEBURUN = true;

            if (deathType == (SimDescription.DeathType)0x55555555)
                return false;

            //niec_native_func.OutputDebugString("Sim_NonOpenDGSKill called");
            //if (this == null)
            //{
            //    niec_native_func.OutputDebugString("Sim_NonOpenDGSKill: This == null");
            //    return false;
            //}

            return KillPro.FastKill(this, deathType, target, playDeathAnim, false, false);
        }

        private static object OV = null;

        public static void InitBimCreate()
        {
            if ((OV as Bim) != null)
                return;

            OV = new Bim();
            var BimO = (Bim)OV;

            BimO.mActorId = 0;

            BimO.CanIndividualSimReact = false;
            BimO.PartyAnimalWooList = null;
            BimO.WakeupAlarmClocks = null;
            BimO.HistoryOfClips = null;
            BimO.SoloInteractions = null;
            BimO.SelfObjectInteractions = null;
            BimO.mMotiveTuning = null;
            BimO.mSituationSpecificInteractions = null;

            BimO.Standing = null;
            BimO.mPosture = null;

            Sim.sNumberOfActors--;

        }

        public static Bim GetStatic()
        {
            InitBimCreate();
            return (Bim)OV;
        }























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
                        catch (NotSupportedException ex)
                        {
                            if (ex.source == "SimIFace")
                            {
                                if (!Instantiator.NSMCINJECT)
                                    throw;
                                NFinalizeDeath.CheckYieldingContext();
                                Simulator.Sleep(0);
                            }
                            else throw;
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

                try
                {
                    _this.PostureIdle();
                }
                catch (NotSupportedException ex)
                {
                    if (ex.source == "SimIFace")
                    {
                        if (!Instantiator.NSMCINJECT)
                            throw;
                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(0);
                    }
                    else throw;
                }
                catch (SacsErrorException)
                { }
               
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
            if (interactionInstance == null || interactionInstance.Target == null) 
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

            if (interactionInstance.Target == null)
                return;

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
                    float num2 = 0.99f / num + 1f;
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

        public static bool TestInteractionEx(InteractionInstance inCurrentInteraction)
        {
            try
            {
                if (inCurrentInteraction is NiecHelperSituation.INHSInteraction)
                {
                    InteractionInstanceParameters parameters = inCurrentInteraction.GetInteractionParameters();
                    GreyedOutTooltipCallback greyedOutTooltipCallback = null;
                    return IUtil.IsPass(inCurrentInteraction.InteractionDefinition.Test(ref parameters, ref greyedOutTooltipCallback));
                }
                else
                return inCurrentInteraction.Test();
            } 
            catch (StackOverflowException)
            { NFinalizeDeath.ThrowResetException(null); throw; }
            catch (ResetException)
            {
                throw;
            }
            catch 
            { 
                if (!NiecHelperSituation.__acorewIsnstalled__) 
                    throw; 
                return false; 
            }
        }

        public static bool SafeCallRunInteraction(InteractionInstance i)
        {
            var r = NiecTask.CreateWaitPerformWithExecuteTypeSID(ScriptExecuteType.Threaded, () =>
            {
                var p = NiecTask.GetCurrentNiecTask();
                try
                {
                    p.WaitPerform_DoneResult = NFinalizeDeath._RunInteractionWithoutCleanUp(i);
                }
                catch (Exception)
                {
                    p.WaitPerform_DoneResult = false;
                }
            }).Waiting();

            if (r is bool)
                return (bool)r;
            else
            {
                NDebugger.Log(NDebugger.LogLevel.FatelError, "SafeCallRunInteraction", "Interaction Name: " + i.GetType().AssemblyQualifiedName, false);
            }
            return false;
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

                    //if (simIQList.IndexOf(inCurrentInteraction) != 0)
                    //{
                    //    break;
                    //}

                    if (simIQList == null)
                        break;

                    if (sim.mPosture != null)
                    {
                        int num = 4;
                        bool flag = false;
                        int num2 = 10;

                        sim.PlayRouteFailFrequency = Sim.RouteFailFrequency.PlayRouteFailNextTimeOnly;

                        List<InteractionObjectPair> list = new List<InteractionObjectPair>();

                        if (inCurrentInteraction.Target == null)
                        {
                            niec_std.list_remove(simIQList, inCurrentInteraction);
                            if (sim.IsSelectable)
                                simIQ.FireQueueChanged();
                            continue;
                        }

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

                            interactionInstance2 = ((inCurrentInteraction.PosturePreconditions != null || sim.Posture is IHaveCustomTransitionForNullPosturePreconditions) ? sim.Posture.GetTransition(inCurrentInteraction) : (NiecHelperSituation.__acorewIsnstalled__ ? null : sim.Posture.GetStandingTransition()));
                            if (interactionInstance2 == null)
                            {
                                num = 0;
                            }

                            else
                            {
                                if (num == 4 && (!TestInteractionEx(inCurrentInteraction) || (!inCurrentInteraction.IsTargetValid())))
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
                                    flag = NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.isdgmods && NInjetMethed.DoneLoopIdle ? SafeCallRunInteraction(inCurrentInteraction) : NFinalizeDeath._RunInteractionWithoutCleanUp(interactionInstance2);
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

                    if (t || !TestInteractionEx(inCurrentInteraction) || (!inCurrentInteraction.IsTargetValid()))
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
                        okI = NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.isdgmods && NInjetMethed.DoneLoopIdle ? SafeCallRunInteraction(inCurrentInteraction) : NFinalizeDeath._RunInteractionWithoutCleanUp(inCurrentInteraction);
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
                        if (NFinalizeDeath.IsOpenDGSInstalled || !NiecHelperSituation.__acorewIsnstalled__)
                            throw;
                    }

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
