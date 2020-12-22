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
    public class NiecPosture : Posture
    {
        public static bool IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");

        public Sim _Actor = null;

        public NiecPosture()
        { }
        public NiecPosture(Sim sim)
        {_Actor = sim;}

        public override bool AllowsNormalSocials()
        {
            return true;
        }

        public override void OnSimDisposed()
        {
            if (!IsOpenDGSInstalled && _Actor != null)
            {
                var simd = _Actor.SimDescription;

                _Actor.mSimDescription = Create.NiecNullSimDescription();
                _Actor.mSimDescription.mSim = _Actor;

                if (simd != null)
                    simd.mSim = null;

                _Actor = null;
            }
        }
        
        public override void OnSimDestroy()
        {
            if (!IsOpenDGSInstalled && NiecHelperSituation.__acorewIsnstalled__)
            {
                if (_Actor != null)
                    NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(_Actor, false);
                try
                {
                    //NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(null, false);
                    throw new ExecutionEngineException("DEBUG OnSimDestroy().");
                }
                catch
                {
                    if (Simulator.CheckYieldingContext(false))
                        throw;
                }
               
            }
        }

        public override bool Satisfies(PreconditionOptions options, IGameObject target, CommodityKind requiredCheck)
        {
            var pp = PreviousPosture;
            if (pp != null && pp == this)
                PreviousPosture = null;
            return false;
        }

        public override bool AllowsReactionOverlay()
        {
            return true;
        }

        public override bool AllowsRouting()
        {
            return true;
        }

        public override IGameObject Container
        {
            get {
                if (IsOpenDGSInstalled || !NiecHelperSituation.__acorewIsnstalled__ || this is NiecHelperSituationPosture) 
                    return null;
                if (NFinalizeDeath.GetCurrentGameObjectFast<Lot>() != null)
                    return null;
                return NFinalizeDeath.GetRandomGameObject<IGameObject>(delegate(IGameObject obj) { return obj != NFinalizeDeath.ActiveActor; }); 
            }
        }

        public override ScriptPosture GetSacsPostureParameter()
        {
            return ScriptPosture.Standing;
        }

        public override InteractionInstance GetStandingTransition()
        {
            if (IsOpenDGSInstalled)
                return null;
            else if (_Actor != null && _Actor.Autonomy != null)
            {
                // TODO
                var tyy = NiecHelperSituation.ExistsOrCreateAndAddToSituationList(_Actor);
                if (tyy == null)
                    return null;

                return tyy.CreateInteraction(_Actor);
            }
            else
                return null;
        }
        public override InteractionInstance GetTransition(InteractionInstance interaction)
        {
            if (IsOpenDGSInstalled)
                return null;
            return GetStandingTransition() ?? Posture.FindTransitionInteraction(interaction, CommodityKind.None);
        }

        public override string Name
        {
            get { return "by NiecMod"; }
        }


        public override Posture OnReset(IGameObject objectBeingReset)
        {
            var sim = objectBeingReset as Sim ?? _Actor;
            if (sim != null && sim.mPosture is NiecPosture)
            {
                // Stop StackOverflowException
                sim.mPosture = null; 
            }
            if (IsOpenDGSInstalled) return null;
            if (NiecHelperSituation.isdgmods || !NiecHelperSituation.__acorewIsnstalled__)
            {
                objectBeingReset.OnReset();
            }
            else // if AweCore
            {
                bool done = false;
                NFinalizeDeath.SafeCall(() => {
                    var p = sim.mPosture;
                    try
                    {
                        sim.mPosture = null;
                        objectBeingReset.OnReset();
                    }
                    finally
                    {
                        sim.mPosture = p;
                    }
                    done = true;
                });
                if (!done && sim.mPosture != null)
                    sim.mPosture = this;
            }
            return this;
        }

        public override bool PerformIdleLogic
        {
            get { return false; }
        }

        public override void PopulateInteractions()
        {}

        public override float Satisfaction(CommodityKind condition, IGameObject target)
        {
            return 0;
        }

        public override void Shoo(bool yield, List<Sim> shooedSims)
        {
            if (yield)
                shooedSims.Clear();
        }
    }
    public class NiecHelperSituationPosture : NiecPosture
    {
        public Posture PBack = null;

        //public bool dataBool = false;
        //public bool dataBool02 = false;
        //public bool dataBool03 = false;

        public bool NeedMaxMood = false;

        public NiecHelperSituationPosture()
        { }
        public NiecHelperSituationPosture(Sim sim)
        { 
            _Actor = sim;
            if (sim != null)
                PBack = sim.Posture;
        }

        public static bool Disallowr_internal = false;

        public static NiecHelperSituationPosture ExistsOrCreatePosture(Sim actor, bool bNeedMaxMood)
        {
            if (actor == null || Simulator.GetProxy(actor.ObjectId) == null)
                throw new ArgumentNullException("actor");

            if (actor.Posture is NiecHelperSituationPosture)
                return actor.Posture as NiecHelperSituationPosture;

            if (NiecHelperSituation.ExistsOrCreateAndAddToSituationList(actor, null) != null)
            {
                NiecHelperSituationPosture nhsp = new NiecHelperSituationPosture(actor);
                nhsp.NeedMaxMood = bNeedMaxMood;
                actor.mPosture = nhsp;
                return nhsp;
            }
            throw new ArgumentException("actor is bad.", "actor");
        }

        public static void RunPosture(Sim Actor)
        {
            if (NiecRunCommand.GameObjectHasDestroyed(Actor))
                throw new InvalidOperationException("If NiecRunCommand.GameObjectHasDestroyed(Actor)");
            r_internal(Actor);
        }
        public static bool TestDEBUGMyMod = false;
        internal static void r_internal(Sim Actor)
        {
            NiecHelperSituationPosture nhsp = null;
            if (Actor != null && !NFinalizeDeath.GameObjectIsValid(Actor.ObjectId.mValue)) //NFinalizeDeath.GetObject_internalFastO(Actor.ObjectId.mValue) == null)
            {
                nhsp = (Actor.Posture as NiecHelperSituationPosture);
                Actor.mPosture = null;
                if (nhsp != null)
                {
                    nhsp._Actor = null;
                    nhsp.PBack = null;
                }
            }
            
            if (Actor == null || Actor.ObjectId.mValue != ScriptCore.Simulator.Simulator_GetCurrentTaskImpl() || !Simulator.CheckYieldingContext(false))
                return;

            var sim = Actor;
            bool bNeedMaxMood = false;
            Posture pBackUp = null;

            if (sim.Posture is NiecHelperSituationPosture) {
                nhsp = (sim.Posture as NiecHelperSituationPosture);
                pBackUp = nhsp.PBack;
                bNeedMaxMood = nhsp.NeedMaxMood;
                nhsp._Actor = null;
                if (sim.Standing is NiecHelperSituationPosture)
                {
                    sim.Standing = null;
                    sim.mPosture = null;
                    if (sim.mSimDescription != null)
                    {
                        if (sim.mSimDescription.IsPet)
                        {
                            PetStandingPosture dr = new PetStandingPosture(sim);
                            sim.PetSittingOnGround = new PetSittingOnGroundPosture(sim);
                            sim.Standing = dr;
                            sim.Posture = null;
                        }
                        else
                        {
                            Sim.StandingPosture dre = new Sim.StandingPosture(sim);
                            sim.Standing = dre;
                            sim.Posture = null;
                        }
                    }

                }
                else if (nhsp.PBack != null)
                    sim.mPosture = nhsp.PBack;//sim.Standing;
                else 
                    sim.mPosture = sim.Standing;

                nhsp.PBack = null;
            }

            if (Disallowr_internal || (NiecHelperSituation.ExAA && sim == (NPlumbBob.DoneInitClass ? NFinalizeDeath.GetSafeSelectActor() : PlumbBob.SelectedActor)))
                return;

            if (!TestDEBUGMyMod && !SCOSR.IsScriptCore2020() && !IsOpenDGSInstalled &&
               NFinalizeDeath.baCheckACoreThrowNRaasErrorTrap &&
               NiecHelperSituation.__acorewIsnstalled__ &&
               NFinalizeDeath.IsSTAwesomeMod02Fast<Sim>()
               )
            {
                if (nhsp != null) {
                NiecTask.Perform(delegate {
                    Simulator.Sleep(450);
                    var p = sim.mPosture;
                    if (p is NiecHelperSituationPosture)
                    {
                        return;
                    }

                    //NFinalizeDeath.Assert(nhsp != null, "r_internal(): nhsp failed!");

                    if (p != null && p == p.PreviousPosture)
                        p.PreviousPosture = null;

                    sim.mPosture = p = nhsp;
                    nhsp.PBack = pBackUp;
                    nhsp._Actor = sim;

                    if (p != null && p == p.PreviousPosture)
                        p.PreviousPosture = null;
                });}

                NFinalizeDeath.AntiSpy_ThrowDefault();
            }

            var lookm = Actor.LookAtManager;
            if (lookm != null)
                lookm.DisableLookAts();


            lookm = null;   // i know Saving TaskContext Failed. From OnSavingGame()
            nhsp = null;    //
            pBackUp = null; //


            //using(SafeSimUpdate.Run(sim)) {
            while (true)
            {
                NFinalizeDeath.CheckYieldingContext();


                if (NiecHelperSituation.__acorewIsnstalled__
                    && !NiecHelperSituation.___bOpenDGSIsInstalled_)
                {
                    var iV = ScriptCore.Queries.Query_CountObjects(typeof(Sim));
                    if (iV >= 2)
                        NiecRunCommand.native_testcpu_debug(null, null);
                    else if (iV == 1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            NiecRunCommand.native_testcpu_debug(null, null);
                        }
                    }
                }

                if (!IsOpenDGSInstalled && NFinalizeDeath.GetCurrentExecuteType() == ScriptExecuteType.Task)
                    Simulator.Sleep(20);
                else 
                    Simulator.Sleep(IsOpenDGSInstalled ? 15u:0u);

                if (NiecHelperSituation.__acorewIsnstalled__
                    && !NiecHelperSituation.___bOpenDGSIsInstalled_)
                {
                    var iV = ScriptCore.Queries.Query_CountObjects(typeof(Sim));
                    if (iV >= 2)
                        NiecRunCommand.native_testcpu_debug(null, null);
                    else if (iV == 1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            NiecRunCommand.native_testcpu_debug(null, null);
                        }
                    }
                }

                if (!NFinalizeDeath.SimIsNiecHelperSituation(sim)) 
                    continue;
                if (Simulator.GetProxy(sim.ObjectId) == null)
                    break;
                if (Disallowr_internal || (NiecHelperSituation.ExAA && sim == (NPlumbBob.DoneInitClass ? NFinalizeDeath.GetSafeSelectActor() : PlumbBob.SelectedActor)))
                    break;

                var simIQ = sim.InteractionQueue;

                try
                {
                    if (IsOpenDGSInstalled)
                    {
                        if (sim.SimDescription == null)
                            break;
                        if (simIQ == null)
                            break;
                    }
                    else
                    {
                        if (sim.SimDescription == null)
                        {
                            sim.mSimDescription = Create.NiecNullSimDescription(true, false, true);
                        }

                        if (NFinalizeDeath.SimIsGRReaper(sim.SimDescription))
                            NiecHelperSituation.ExistsOrCreateAndAddToSituationList(sim);

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
                                while (simIQ.mInteractionList != null && niec_std.list_remove(simIQ.mInteractionList, null)) //simIQ.mInteractionList.Remove(null))
                                { 
                                    Simulator.Sleep(0); 
                                }
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

                    if (IsOpenDGSInstalled)
                        throw;
                    else
                    {
                        for (int i = 0; i < 45; i++)
                        {
                            Simulator.Sleep(0);
                        }
                        continue;
                    }
                }

                if (bNeedMaxMood)
                {
                    try
                    {
                        NFinalizeDeath.Sim_MaxMood(sim);
                    }
                    catch (NMAntiSpyException)
                    { NFinalizeDeath.SafeForceTerminateRuntime(); }
                    catch (StackOverflowException)
                    { if (!IsOpenDGSInstalled) NFinalizeDeath.ThrowResetException(null); throw; }
                    catch (ResetException)
                    { throw; }
                    catch
                    {
                        NFinalizeDeath.CheckYieldingContext();

                        if (IsOpenDGSInstalled)
                            throw;
                        else
                        {
                            for (int i = 0; i < 45; i++)
                            {
                                Simulator.Sleep(0);
                            }
                            continue;
                        }
                    }
                }
                try
                {
                    if (!IsOpenDGSInstalled && sim.mAutonomy != null)
                    {
                        //var sg = sim.mAutonomy;
                        try
                        {
                            AutonomyManager.Add(sim.mAutonomy);
                        }
                        catch (NMAntiSpyException)
                        { NFinalizeDeath.SafeForceTerminateRuntime(); }
                        catch (StackOverflowException)
                        { if (!IsOpenDGSInstalled) NFinalizeDeath.ThrowResetException(null); throw; }
                        catch (ResetException)
                        { throw; }
                        catch { }
                    }
                    var simIQList = simIQ.mInteractionList;
                    if (simIQList == null || simIQList.Count == 0) 
                        continue;

                    var simIQListArray = simIQList.ToArray();
                    for (int i = 0; i < simIQListArray.Length; i++)
                    {
                        InteractionInstance inCurrentInteraction = simIQListArray[i];
                        if (inCurrentInteraction == null || inCurrentInteraction.InteractionDefinition == null)
                        {
                            while(simIQList != null && niec_std.list_remove(simIQList, null))//simIQList.Remove(null)) 
                            {
                                Simulator.Sleep(0);
                                simIQList = simIQ.mInteractionList;
                            }

                            if (simIQList == null) 
                                break;

                            continue;
                        }

                        if (IsOpenDGSInstalled)
                        {
                            if (simIQList.IndexOf(inCurrentInteraction) != 0)
                            {
                                break;
                            }
                        }
                        else if (i != 0)
                        {
                            break;
                        }

                        if (simIQList == null) 
                            break;

                        if (! NFinalizeDeath.InteractionIsNiecHelperSituationPosture_internal(sim,inCurrentInteraction)) {
                            //simIQList.Remove(inCurrentInteraction);
                            niec_std.list_remove(simIQList, inCurrentInteraction);
                            if (IsOpenDGSInstalled)
                            {
                                try
                                {
                                    inCurrentInteraction.CallCallbackOnFailure(sim);
                                    inCurrentInteraction.Cleanup();
                                }
                                catch (NMAntiSpyException)
                                { NFinalizeDeath.SafeForceTerminateRuntime(); }
                                catch (StackOverflowException)
                                { sim.mPosture = null; throw; }
                                catch (ResetException)
                                { throw; }
                                catch (Exception)
                                {
                                    NFinalizeDeath.CheckYieldingContext();
                                    if (IsOpenDGSInstalled)
                                        throw;
                                }

                            }
                            else
                            {
                                if (inCurrentInteraction.Target is Sim)
                                    inCurrentInteraction.mInstanceActor = inCurrentInteraction.Target;
                            }

                            if (sim.IsSelectable)
                                simIQ.FireQueueChanged();

                            break;
                        }

                        if (!Bim.TestInteractionEx(inCurrentInteraction) || (IsOpenDGSInstalled && !inCurrentInteraction.IsTargetValid()))
                        {
                            // simIQList.Remove(inCurrentInteraction);
                            niec_std.list_remove(simIQList, inCurrentInteraction);
                            try
                            {
                                inCurrentInteraction.CallCallbackOnFailure(sim);
                                inCurrentInteraction.Cleanup();
                            }
                            catch (NMAntiSpyException)
                            { NFinalizeDeath.SafeForceTerminateRuntime(); }
                            catch (StackOverflowException)
                            { sim.mPosture = null; throw; }
                            catch (ResetException)
                            { throw; }
                            catch (Exception)
                            {
                                NFinalizeDeath.CheckYieldingContext();
                                if (IsOpenDGSInstalled)
                                    throw;
                            }

                            //if (IsOpenDGSInstalled)
                            //    simIQ.DeQueue(false);

                            if (sim.IsSelectable)
                                simIQ.FireQueueChanged();

                            continue;
                        }

                        simIQ.mIsHeadInteractionLocked = true;

                        var runningInList = simIQ.mRunningInteractions;
                        if (runningInList != null)
                            runningInList.Push(inCurrentInteraction);

                        try
                        {
                            inCurrentInteraction.CallCallbackOnStart(sim);
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
                            if (IsOpenDGSInstalled)
                                throw;
                        }
                        

                        simIQ.mIsHeadInteractionActive = true;

                        bool okI = false;

                        try
                        {
                            okI = NFinalizeDeath._RunInteractionWithoutCleanUp(inCurrentInteraction);
                            if (okI) {
                                inCurrentInteraction.CallCallbackOnCompletion(sim);
                            } else {
                                inCurrentInteraction.CallCallbackOnFailure(sim);
                            }
                        }
                        catch (NMAntiSpyException)
                        { NFinalizeDeath.SafeForceTerminateRuntime(); }
                        catch (StackOverflowException)
                        {
                            if (!IsOpenDGSInstalled)
                            {
                                try
                                {
                                    NiecTask.Perform(inCurrentInteraction.Cleanup);
                                }
                                catch (StackOverflowException)
                                {}
                                
                                NFinalizeDeath.ThrowResetException(null);
                            }
                            throw; 
                        }
                        catch (ResetException)
                        { throw; }
                        catch
                        {
                            NFinalizeDeath.CheckYieldingContext();
                            if (IsOpenDGSInstalled)
                                throw;
                        }


                        if (IsOpenDGSInstalled && Simulator.CheckYieldingContext(false))
                            simIQ.PutDownCarriedObjects(inCurrentInteraction);

                        simIQ = sim.InteractionQueue;
                        if (simIQ == null)
                        {
                            inCurrentInteraction.Cleanup();
                            break;
                        }

                        NFinalizeDeath.CheckYieldingContext();

                        if (IsOpenDGSInstalled)
                            simIQ.PutDownCarriedObjects(inCurrentInteraction);

                        simIQ.mIsHeadInteractionActive = false;
                        simIQ.mIsHeadInteractionLocked = false;

                        //if (IsOpenDGSInstalled)
                        //    simIQ.DeQueue(okI);

                        if (runningInList != null && runningInList.Count > 0)
                        {
                            runningInList.Pop();
                        }

                        simIQList = simIQ.mInteractionList;
                        if (simIQList == null)
                        {
                            inCurrentInteraction.Cleanup();
                            break;
                        }

                        NFinalizeDeath.CheckYieldingContext();

                        //simIQList.Remove(inCurrentInteraction);
                        niec_std.list_remove(simIQList, inCurrentInteraction);
                        inCurrentInteraction.Cleanup();

                        NFinalizeDeath.CheckYieldingContext();

                        while (simIQList != null && niec_std.list_remove(simIQList, null))
                        {
                            Simulator.Sleep(0);
                            simIQList = simIQ.mInteractionList;
                        }

                        if (simIQList == null)
                            break;

                        if (sim.IsSelectable)
                            simIQ.FireQueueChanged();
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

                    if (IsOpenDGSInstalled)
                        throw;
                    else
                    {
                        for (int i = 0; i < 45; i++)
                        {
                            Simulator.Sleep(0);
                        }
                        continue;
                    }
                }
            }//}
            //NFinalizeDeath.M();
        }

        public override bool AllowNonScreamThoughBalloons
        {
            get
            {
                r_internal(_Actor);
                return base.AllowNonScreamThoughBalloons;
            }
        }

        public override bool AllowsReaction(AutonomyLevel level)
        {
            r_internal(_Actor);
            return base.AllowsReaction(level);
        }

        public override void AddInteractions(IActor actor, IActor target, List<InteractionObjectPair> results)
        {
            r_internal(_Actor);
            base.AddInteractions(actor, target, results);
        }

        public override bool AllowsNormalSocials()
        {
            r_internal(_Actor);
            return true;
        }

        public override void PlayScheduledIdle(IdleAnimationData idleAnimData, string jazzStateNamePrefix, bool isDistressIdle)
        {
            r_internal(_Actor);
            base.PlayScheduledIdle(idleAnimData, jazzStateNamePrefix, isDistressIdle);
        }

        public override bool OverrideFxSlots
        {
            get
            {
                r_internal(_Actor);
                return base.OverrideFxSlots;
            }
        }

        public override bool OverrideAllowIntersection
        {
            get
            {
                r_internal(_Actor);
                return base.OverrideAllowIntersection;
            }
        }

        public override void GroupTalkStopTalking()
        {
            r_internal(_Actor);
            base.GroupTalkStopTalking();
        }

        public override void GroupTalkStopListening()
        {
            r_internal(_Actor);
            base.GroupTalkStopListening();
        }

        public override bool GroupTalkStartTalking()
        {
            r_internal(_Actor);
            return base.GroupTalkStartTalking();
        }

        public override bool GroupTalkStartListening()
        {
            r_internal(_Actor);
            return base.GroupTalkStartListening();
        }

        public override bool GroupTalkPlayResponse(ReactionTypes response)
        {
            r_internal(_Actor);
            return base.GroupTalkPlayResponse(response);
        }

        public override bool Implicit
        {
            get
            {
                r_internal(_Actor);
                return base.Implicit;
            }
        }

        public override bool HasSlaveRouteObjects(out List<GameObject> slaveObjs, out bool bSlavesRoute)
        {
            r_internal(_Actor);
            return base.HasSlaveRouteObjects(out slaveObjs, out bSlavesRoute);
        }

        public override bool RemoveInteractionFromQueue(InteractionInstance instance)
        {
            r_internal(_Actor);
            return base.RemoveInteractionFromQueue(instance);
        }

        

        public override bool HandToolAllowIntersection(IGameObject objectToIntersect, Matrix44 testMatrix, bool bThisObjectShifted)
        {
            r_internal(_Actor);
            return base.HandToolAllowIntersection(objectToIntersect, testMatrix, bThisObjectShifted);
        }

        public override float GetPostureMotiveDecayUpdate(float currentValue, CommodityKind commodity, float hoursPassed)
        {
            r_internal(_Actor);
            return base.GetPostureMotiveDecayUpdate(currentValue, commodity, hoursPassed);
        }

        public override bool ReactionAllowed()
        {
            r_internal(_Actor);
            return base.ReactionAllowed();
        }

        public override string StateMachineActorName
        {
            get
            {
                r_internal(_Actor);
                return base.StateMachineActorName;
            }
        }

        public override BridgeOrigin Idle()
        {
            r_internal(_Actor);
            return base.Idle();
        }

        public override StateMachineClient GetPostureStateMachine(PostureInteractions interaction, Posture.GetStateMachineDelegate GetInteractionStateMachine)
        {
            r_internal(_Actor);
            return base.GetPostureStateMachine(interaction, GetInteractionStateMachine);
        }

        public override InteractionInstance GetCancelTransition()
        {
            r_internal(_Actor);
            return base.GetCancelTransition();
        }

        public override float GetAutonomyScoreMultiplierForInteraction(Sim actor, IGameObject target, PosturePreconditionOptionsData options)
        {
            r_internal(_Actor);
            return base.GetAutonomyScoreMultiplierForInteraction(actor, target, options);
        }

        public override void CancelSocializing(Sim sim)
        {
            r_internal(_Actor);
            base.CancelSocializing(sim);
        }

        public override bool AllowsOverlays()
        {
            r_internal(_Actor);
            return base.AllowsOverlays();
        }

        public override bool Compatible(Posture currentPosture)
        {
            r_internal(_Actor);
            return false;
        }

        public override void OnInteractionQueueEmpty()
        {
            if (IsOpenDGSInstalled)
            {
                r_internal(_Actor);
                base.OnInteractionQueueEmpty();
                return;
            }

            NFinalizeDeath.CheckACoreThrowNRaasErrorTrap();

            if (NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.isdgmods)
            {
                var t = Assembly.GetCallingAssembly()._mono_assembly == Instantiator.myAssemblyPtr;
                if (_Actor != null && _Actor.mSimDescription != null && NFinalizeDeath.SimIsGRReaper(_Actor.mSimDescription))
                {
                    NiecRunCommand.fcreap_Icommand(_Actor, true, false);
                }
                while (_Actor != null)
                {
                    try
                    {
                        
                        NFinalizeDeath.CheckYieldingContext();
                    }
                    catch (ResetException)
                    {
                        if (!t)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }

                    Simulator.Sleep(0);

                    try
                    {
                        r_internal(_Actor);
                        break;
                    }
                    catch (ResetException)
                    {
                        if (_Actor != null && NFinalizeDeath.GameObjectIsValid(_Actor.ObjectId.mValue))
                            ExistsOrCreatePosture(_Actor, NeedMaxMood);
                        if (!t)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            NFinalizeDeath.CheckYieldingContext();
                        }
                        catch (ResetException)
                        {
                            if (_Actor != null && NFinalizeDeath.GameObjectIsValid(_Actor.ObjectId.mValue))
                                ExistsOrCreatePosture(_Actor, NeedMaxMood);
                            if (!t)
                                NFinalizeDeath.SafeForceTerminateRuntime();
                            throw;
                        }
                    }
                }
            }
            else
            {
                r_internal(_Actor);
            }
            base.OnInteractionQueueEmpty();
        }

        public override bool AllowsCallOver()
        {
            r_internal(_Actor);
            return base.AllowsCallOver();
        }



        public override void OnExitPosture()
        {
            var simt = _Actor;
            if (simt != null && simt.ObjectId == Simulator.CurrentTask)
            {
                PBack = null;
                _Actor = null;
                try
                {
                    r_internal(simt);
                }
                finally
                {
                    if (IsOpenDGSInstalled && simt.Posture is NiecHelperSituationPosture)
                        simt.mPosture = simt.Standing;
                }
            }
            base.OnExitPosture();
        }

        public override void OnSimDisposed()
        {
            var simt = _Actor;
            PBack = null;
            _Actor = null;
            r_internal(simt);
            if (simt != null && simt.Posture is NiecHelperSituationPosture)
                simt.mPosture = simt.Standing;
        }

        public override void OnSimDestroy()
        {
            var simt = _Actor;
            PBack = null;
            _Actor = null;
            r_internal(simt);
            if (simt != null && simt.Posture is NiecHelperSituationPosture)
                simt.mPosture = simt.Standing;
        }

        public override void OnCancelPosture()
        {
            //var simt = _Actor;
            //_Actor = null;
            r_internal(_Actor);
            base.OnCancelPosture();
        }

        public override bool Satisfies(PreconditionOptions options, IGameObject target, CommodityKind requiredCheck)
        {
            var pp = PreviousPosture;
            if (pp != null && pp == this)
                PreviousPosture = null;
            r_internal(_Actor);
            return false;
        }

        public override bool AllowsReactionOverlay()
        {
            r_internal(_Actor);
            return true;
        }

        public override bool AllowsRouting()
        {
            r_internal(_Actor);
            return true;
        }

        public override IGameObject Container
        {
            get { r_internal(_Actor); return null; }
        }

        public override ScriptPosture GetSacsPostureParameter()
        {
            r_internal(_Actor);
            return ScriptPosture.Standing;
        }

        public override InteractionInstance GetStandingTransition()
        {
            r_internal(_Actor);
            if (IsOpenDGSInstalled)
                return null;
            else if (_Actor != null)
                return NiecHelperSituation.ExistsOrCreateAndAddToSituationList(_Actor).CreateInteraction(_Actor);
            else
                return null;
        }
        public override InteractionInstance GetTransition(InteractionInstance interaction)
        {
            r_internal(_Actor);
            if (IsOpenDGSInstalled)
                return null;
            return GetStandingTransition() ?? Posture.FindTransitionInteraction(interaction, CommodityKind.None);
        }

        public override string Name
        {
            get { r_internal(_Actor); return "Niec Helper Situation Posture"; }
        }

        public override Posture OnReset(IGameObject objectBeingReset)
        {
            r_internal(_Actor);
            //objectBeingReset.OnReset();
            return null;
        }

        public override bool PerformIdleLogic
        {
            get { r_internal(_Actor); return false; }
        }

        public override void PopulateInteractions()
        { r_internal(_Actor); }
        /// ----------------------------------------- ///
        public override void ParentHeadlineFx(VisualEffect effect, Slot normalSlot)
        {
            r_internal(_Actor);
            base.ParentHeadlineFx(effect, normalSlot);
        }
        public override ThumbnailKey GetIconKey()
        {
            r_internal(_Actor);
            return base.GetIconKey();
        }
        public override bool Equals(object o)
        {
            r_internal(_Actor);
            return base.Equals(o);
        }
        public override bool OverridePlumbBob
        {
            get
            {
                r_internal(_Actor);
                return base.OverridePlumbBob;
            }
        }
        public override int GetHashCode()
        {
            if (!IsOpenDGSInstalled)
                r_internal(_Actor);
            return base.GetHashCode();
        }
        public override bool ParentPlumbBob(PlumbBob plumbbob, Slot originalSlot, Vector3 originalOffset)
        {
            r_internal(_Actor);
            return base.ParentPlumbBob(plumbbob, originalSlot, originalOffset);
        }
        public override string ToString()
        {
            if (!IsOpenDGSInstalled)
                r_internal(_Actor);
            return base.ToString();
        }
        /// ----------------------------------------- ///
        public override float Satisfaction(CommodityKind condition, IGameObject target)
        {
            r_internal(_Actor);
            return 0;
        }

        public override void Shoo(bool yield, List<Sim> shooedSims)
        {
            r_internal(_Actor);
            if (yield)
                shooedSims.Clear();
        }
    }
}
