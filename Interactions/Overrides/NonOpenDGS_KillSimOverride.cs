using System;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Core;

using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;

using Sims3.Gameplay.Interactions;
using Sims3.SimIFace;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.Interfaces;
using System.Collections.Generic;
using NiecMod.Nra;
using NiecMod.KillNiec;
using Sims3.Gameplay.Pools;
using Sims3.Gameplay.ChildAndTeenUpdates;
using Sims3.UI;
using Sims3.Gameplay.EventSystem;
using Sims3.SimIFace.CAS;
using Sims3.Gameplay.PetSystems;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.ThoughtBalloons;
using Sims3.Gameplay.Objects.Gardening;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Controllers.Niec;
using NiecMod.Interactions;
using Sims3.Gameplay.Scuba;
using Sims3.NiecHelp.Tasks;
using Sims3.NiecModList.Persistable;
using Sims3.Gameplay.NiecRoot;

namespace Sims3.Gameplay.NiecNonOpenDGS.Interactions
{
    public class NonOpenDGS_KillSimOverride
    {
        private static bool mInited = false;

        public static bool _IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");

        public static bool Inited { get { return mInited; } }

        public static void Init() {
            if (mInited) 
                return;

            if (Urnstone.KillSim.Singleton is Urnstone.KillSim.Definition) // if mod other
                Urnstone.KillSim.Singleton = new Definition();
            else
            {
                NiecException.WriteLog("Urnstone.KillSim.Singleton: " + Urnstone.KillSim.Singleton.GetType().AssemblyQualifiedName);
                Urnstone.KillSim.Singleton = new Definition();
            }

            mInited = true;
        }

        public static void ReInit()
        {
            mInited = false;
            Init();
        }

        public class NiecKillSim : Urnstone.KillSim, IRouteFromInventoryOrSelfWithoutCarrying, IInteractionDoesntAllowReactions
        {
            public static uint ActorIDNext = 2001;

            public ExtKillSimNiec runI = null;

            public ObjectGuid AutoKillSimTask = ObjectGuid.InvalidObjectGuid;

            public ObjectGuid ATask = ObjectGuid.InvalidObjectGuid;

            public override bool CheckForCancelAndCleanup()
            {
                if (runI == null)
                    return base.CheckForCancelAndCleanup();

                return runI.CheckForCancelAndCleanup();
            }

            public override bool RunFromInventory()
            {
                if (runI == null)
                    return base.RunFromInventory();

                return runI.RunFromInventory();
            }

            public override void ConfigureInteraction()
            {
                Sims3.Gameplay.CAS.SimDescription.DeathType deathtyp = base.simDeathType;
                try
                {
                    bool isplayer = Actor.IsSelectable;

                    if (isplayer)
                    {
                        mMustRun = false;
                        mHidden = false;
                        CancellableByPlayer = true;
                    }

                    var killSim =
                        ExtKillSimNiec.Singleton.CreateInstance(Target, Actor, KillSimNiecX.DGSAndNonDGSPriority(), Autonomous, isplayer) as ExtKillSimNiec;

                    killSim.simDeathType = base.simDeathType;
                    killSim.PlayDeathAnimation = base.PlayDeathAnimation;
                    killSim.mMustRun = true;

                    base.mPriority = KillSimNiecX.DGSAndNonDGSPriority();

                    runI = killSim;
                    runI.ConfigureInteraction();
                }
                catch (ResetException){ throw; }
                catch{ }
                if (!_IsOpenDGSInstalled && !Actor.IsInActiveHousehold) {


                    SimDescription ActorDesc = Actor.SimDescription;
                    Sim Actior = Actor;


                    if (ATask == ObjectGuid.InvalidObjectGuid)
                    {
                        InteractionPriority MaxDeathP = KillSimNiecX.DGSAndNonDGSPriority();

                        ATask = NiecTask.Perform(delegate
                        {

                            for (int i = 0; i < 190; i++)
                            {
                                Simulator.Sleep(10);
                            }
                            try
                            {
                                while (Actior != null && Actior.mSimDescription != null && !Actior.HasBeenDestroyed && Actior.InteractionQueue != null && Actior.InteractionQueue.HasInteractionOfType(typeof(NiecKillSim)))
                                {
                                    Simulator.Sleep(0);
                                    base.mPriority = MaxDeathP;
                                    base.mMustRun = true;
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch { }
                        });
                    }
                    if (AutoKillSimTask == ObjectGuid.InvalidObjectGuid)
                    {
                        AutoKillSimTask = NiecTask.Perform(delegate
                        {
                            /*
                            ActorDesc.IsGhost = true;
                            ActorDesc.mDeathStyle = base.simDeathType;




                            if (NFinalizeDeath.GetKillNPCSimToGhost(Actor, deathtyp)) return;
                            else SafeNRaas.NRUrnstones_CreateGrave(ActorDesc, deathtyp, false, false);*/


                            for (int i = 0; i < 190; i++)
                            {
                                Simulator.Sleep(10);
                            }

                            try
                            {
                                try
                                {
                                    while (Actior != null && Actior.mSimDescription != null && !Actior.HasBeenDestroyed && Actior.InteractionQueue != null && Actior.InteractionQueue.HasInteractionOfType(typeof(NiecKillSim)))
                                        Simulator.Sleep(170);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch { }

                                Sim CreatedSim = ActorDesc.CreatedSim;

                                try
                                {
                                    if (NFinalizeDeath.IsHasInteractionNHSTargetSim(Actior))
                                        return;
                                    if (CreatedSim != null && CreatedSim.mSimDescription == ActorDesc)
                                    {
                                        if (NFinalizeDeath.IsHasInteractionNHSTargetSim(CreatedSim))
                                            return;
                                    }

                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                { }

                                try
                                {
                                    if (ActorDesc.AssignedRole != null)
                                        ActorDesc.AssignedRole.RemoveSimFromRole();
                                    ActorDesc.AssignedRole = null;
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                { }

                                try
                                {
                                    ActorDesc.IsGhost = true;
                                    ActorDesc.mDeathStyle = deathtyp;
                                    NiecHelperSituation.FinalizeSimDeathPro(
                                        ActorDesc, ActorDesc.Household, AssemblyCheckByNiec.IsInstalled(NiecMod.Instantiator.DGSModsAssembly)
                                    );
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                { }

                                try
                                {
                                    if (Actior.Inventory != null)
                                        //Actior.MoveInventoryItemsToSim(NFinalizeDeath.ActiveActor ?? PlumbBob.SelectedActor);
                                        NFinalizeDeath._MoveInventoryItemsToAFamilyMember
                                            (Target, NFinalizeDeath.HouseholdMembersToSim(Household.ActiveHousehold, true, false) ?? NFinalizeDeath.ActiveActor ?? PlumbBob.SelectedActor);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                { }


                                Urnstone RIPObject;

                                RIPObject = HelperNra.TFindGhostsGrave(ActorDesc);

                                if (RIPObject == null)
                                    NFinalizeDeath.GetKillNPCSimToGhost(Actior, deathtyp, Vector3.OutOfWorld, out RIPObject);
                                if (RIPObject == null)
                                    RIPObject = Urnstone.CreateGrave(ActorDesc, false, true);

                                NiecHelperSituation.safePosRIPObject(Actior, Actior, RIPObject);

                                NFinalizeDeath.ForceDestroyObject(Actior);
                                NFinalizeDeath.ForceDestroyObject(CreatedSim);

                                if (ActorDesc.DeathStyle == SimDescription.DeathType.None)
                                {
                                    ActorDesc.mDeathStyle = SimDescription.DeathType.Drown;
                                }
                                ActorDesc.IsGhost = true;


                                RIPObject = HelperNra.TFindGhostsGrave(ActorDesc);

                                if (RIPObject == null)
                                    NFinalizeDeath.GetKillNPCSimToGhost(Actior, deathtyp, Vector3.OutOfWorld, out RIPObject);

                                NiecHelperSituation.safePosRIPObject(Actior, Actior, RIPObject);

                                RIPObject.AddToWorld();
                                RIPObject.FadeIn();

                                RIPObject.SetHiddenFlags(HiddenFlags.Nothing);
                                RIPObject.SetOpacity(1f, 0f);
                                RIPObject.AddToWorld();
                                RIPObject.FadeIn();

                                if (ActorDesc.DeathStyle == SimDescription.DeathType.None)
                                {
                                    ActorDesc.mDeathStyle = SimDescription.DeathType.Drown;
                                }
                                ActorDesc.IsGhost = true;
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch { }


                        });
                    }
                }
            }

            public override bool Run()
            {
                Lot alot = Actor.LotCurrent;

                if (alot == null) 
                    alot = Actor.mLotCurrent = LotManager.GetWorldLot();

                if (alot.IsWorldLot && NiecHelperSituation.WorkingNiecHelperSituationCount == 0)
                {
                    //Actor.Motives.MaxEverything();
                    //Actor.FadeIn();

                    //Sim Acvice = null;


                    try
                    {
                        List<Lot> lieastwt = new List<Lot>();
                        Lot lotwt = null;
                        foreach (object obtj in LotManager.AllLotsWithoutCommonExceptions)
                        {
                            Lot lott2 = (Lot)obtj;
                            if (lott2 != null && lott2.IsResidentialLot)
                                lieastwt.Add(lott2);
                        }

                        if (lieastwt.Count != 0)
                        {
                            lotwt = RandomUtil.GetRandomObjectFromList<Lot>(lieastwt);
                        }
                        Actor.SetPosition(lotwt.Position);
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    { }






                    alot = Actor.LotCurrent;
                    if (alot.IsWorldLot && runI == null)
                    {
                        Actor.Motives.MaxEverything();
                        Actor.FadeIn();
                        return false;
                    }
                }

                if (runI == null)
                {
                    if (Actor.LotCurrent.IsWorldLot)
                    {
                        Actor.Motives.MaxEverything();
                        Actor.FadeIn();
                        return false;
                    }
                    return base.Run();
                }

                runI.simDeathType = base.simDeathType;
                runI.PlayDeathAnimation = base.PlayDeathAnimation;
                runI.mMustRun = true;

                return runI.Run();
            }

            public override void Cleanup()
            {
                if (runI == null)
                    base.Cleanup();
                else
                {
                    
                    try
                    {
                        if (!_IsOpenDGSInstalled && Actor.SimDescription != null && !Actor.HasBeenDestroyed && Actor.Autonomy == null)
                            Actor.mAutonomy = new Autonomy.Autonomy((ActorIDNext++).ToString(), Actor);
                    }
                    catch (ResetException)
                    { throw; }
                    catch { }

                    Simulator.DestroyObject(AutoKillSimTask);
                    AutoKillSimTask = ObjectGuid.InvalidObjectGuid;

                    Simulator.DestroyObject(ATask);
                    ATask = ObjectGuid.InvalidObjectGuid;

                    runI.simDeathType = base.simDeathType;
                    runI.PlayDeathAnimation = base.PlayDeathAnimation;
                    runI.Cleanup();
                }

                runI = null;
            }
        }
        public class Definition : InteractionDefinition<Sim, Sim, NiecKillSim>, IUsableWhileOnFire, IUsableDuringFire, IScubaDivingInteractionDefinition, IInteractionDefinitionIsValidForStrangerTarget
        {
            public static string CacheInteractionName = null;

            public override string GetInteractionName(Sim a, Sim target, InteractionObjectPair interaction)
            {
                if (CacheInteractionName == null)
                    CacheInteractionName = Localization.LocalizeString(true, "Gameplay/Actors/Sim/ReapSoul:InteractionName");
                return CacheInteractionName ?? "";
                //return StringTable.GetLocalizedString("Gameplay/Actors/Sim/ReapSoul:InteractionName");
            }

            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                return InteractionTestResult.Pass;
            }

            public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                return true;
            }
        }
    }
}
