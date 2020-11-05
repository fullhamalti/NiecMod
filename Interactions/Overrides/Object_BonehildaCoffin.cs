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
using NiecMod;
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
using Sims3.Gameplay.Objects.Environment;
using Sims3.Gameplay.Services;

namespace Sims3.Gameplay.NiecInteractions
{
    public class Object_BonehildaCoffin
    {




        // Dismiss Bonehilda Interaction

        public class NDismissBonehilda : BonehildaCoffin.DismissBonehilda
        {
            [DoesntRequireTuning]
            public new class Definition : InteractionDefinition<Sim, BonehildaCoffin, NDismissBonehilda>
            {

                public override string GetInteractionName(Sim actor, BonehildaCoffin target, InteractionObjectPair iop) // custom
                {
                    return Localization.LocalizeString(true, "Gameplay/Objects/Environment/BonehildaCoffin/DismissBonehilda:InteractionName");
                }

                public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    try
                    {
                        if (!Test(parameters.Actor as Sim, parameters.Target as BonehildaCoffin, parameters.Autonomous, ref greyedOutTooltipCallback))
                        {
                            return InteractionTestResult.Def_TestFailed;
                        }
                        return InteractionTestResult.Pass;
                    }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { return InteractionTestResult.GenericFail; }

                }
                public override bool Test(Sim a, BonehildaCoffin target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    // custom
                    if (a == null || target == null) return false;


                    if (isAutonomous) 
                        return false;

                    SimDescription simd = a.SimDescription;
                    if (simd == null || simd.IsPet)
                        return false;

                    if (simd.ToddlerOrBelow)
                        return false;

                    if (a.Posture is SwimmingInPool)
                    {
                        return false;
                    }

                    bool hasBonehildaReturnToCoffin
                        = target.BonehildaSim != null 
                        && target.BonehildaSim.InteractionQueue != null 
                        && target.BonehildaSim.InteractionQueue.HasInteractionOfType(BonehildaCoffin.BonehildaReturnToCoffin.Singleton);


                    if (!target.BonehildaActive)
                    {
                        if (!hasBonehildaReturnToCoffin)
                        {
                            return target.BonehildaSim != null;
                        }
                        return false;
                    }

                    return true;
                }
            }

            public bool ___ReturnBonehildaToCoffin(BonehildaCoffin target)
            {
                if (target  == null || target.mBonehildaSim == null) // custom
                {
                    return false;
                }
                InteractionQueue tInteractionQueue = target.mBonehildaSim.InteractionQueue;
                if (tInteractionQueue != null && !tInteractionQueue.HasInteractionOfType(BonehildaCoffin.BonehildaReturnToCoffin.Singleton))
                {
                    Sim targetsim = target.mBonehildaSim;

                    try
                    {
                        tInteractionQueue.CancelAllInteractions();
                    }
                    catch (Exception)
                    {
                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(targetsim);
                        NFinalizeDeath.ForceDestroyObject(targetsim);

                        target.mBonehildaSim = null;

                        return true;
                    }

                    targetsim = target.mBonehildaSim;

                    if (targetsim == null || targetsim.SimDescription == null || targetsim.HasBeenDestroyed)
                    { 
                        target.mBonehildaSim = null; 
                        return true; 
                    }
                   
                    var entry =
                        BonehildaCoffin.BonehildaReturnToCoffin
                        .Singleton.CreateInstance(target, targetsim, 
                        new InteractionPriority(InteractionPriorityLevel.RequiredNPCBehavior), 
                        isAutonomous: false, 
                        cancellableByPlayer: true) 
                        as BonehildaCoffin.BonehildaReturnToCoffin;

                    tInteractionQueue.AddNext(entry);
                } 
                if (tInteractionQueue == null) 
                    target.mBonehildaSim = null; 
                return true;
            }


            public override bool Run()
            {
                try
                {
                    if (!Target.SetCoffinActive(isActive: false))
                        return false;

                    StandardEntry();

                    AcquireStateMachine("BonehildaAwaken");
                    SetActor("x", Actor);
                    SetActor("coffin", Target);

                    EnterState("x", "Enter");

                    BeginCommodityUpdates();
                    AnimateSim("Exit_Dismiss");

                    bool ok = ___ReturnBonehildaToCoffin(Target); // custom

                    Actor.LoopIdle();
                    for (int i = 0; i < 25; i++)
                    {
                        Simulator.Sleep(0);
                    }

                    EndCommodityUpdates(succeeded: ok);
                    StandardExit();
                    return ok;
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    if (Target != null && Target.mBonehildaSim != null)
                    {
                        NFinalizeDeath.ForceDestroyObject(Target.mBonehildaSim);
                        Target.mBonehildaSim = null;
                        //throw new ArgumentException("None", ex);
                    } 
                    return true;
                }
                finally
                {
                    if (Target != null && Target.mBonehildaSim != null && Target.mBonehildaSim.InteractionQueue != null && !Target.mBonehildaSim.InteractionQueue.HasInteractionOfType(BonehildaCoffin.BonehildaReturnToCoffin.Singleton))
                    {
                        NFinalizeDeath.ForceDestroyObject(Target.mBonehildaSim);
                        Target.mBonehildaSim = null;
                    }
                }
            }
        }


















        // Awaken Bonehilda Interaction

        public class NAwakenBonehilda : BonehildaCoffin.AwakenBonehilda
        {
            [DoesntRequireTuning]
            public new class Definition : InteractionDefinition<Sim, BonehildaCoffin, NAwakenBonehilda>
            {
                public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    try
                    {
                        if (!Test(parameters.Actor as Sim, parameters.Target as BonehildaCoffin, parameters.Autonomous, ref greyedOutTooltipCallback))
                        {
                            return InteractionTestResult.Def_TestFailed;
                        }
                        return InteractionTestResult.Pass;
                    }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { return InteractionTestResult.GenericFail; }

                }
                public override bool Test(Sim a, BonehildaCoffin target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    if (a == null || target == null) return false;


                    if (isAutonomous) return false;
                    SimDescription simd = a.SimDescription;
                    if (simd == null || simd.IsPet)
                        return false;

                    if (simd.ToddlerOrBelow)
                        return false;

                    if (a.Posture is SwimmingInPool)
                    {
                        return false;
                    }
                    if (!target.BonehildaActive && target.mBonehildaSim != null)
                    {
                        if (target.BonehildaSim != null && target.BonehildaSim.InteractionQueue != null && target.BonehildaSim.InteractionQueue.HasInteractionOfType(Sims3.Gameplay.Objects.Environment.BonehildaCoffin.BonehildaReturnToCoffin.Singleton))
                        {
                            greyedOutTooltipCallback = InteractionInstance.CreateTooltipCallback(BonehildaCoffin.LocalizeString("BonehildaReturningToCoffin", a));
                        }
                        return false;
                    }
                    return !target.BonehildaActive;
                }
                public override string GetInteractionName(Sim actor, BonehildaCoffin target, InteractionObjectPair iop) // custom
                {
                    return Localization.LocalizeString(true, "Gameplay/Objects/Environment/BonehildaCoffin/AwakenBonehilda:InteractionName");
                }
            }



           

            public override bool Run()
            {
                if (!Target.SetCoffinActive(true))
                {
                    return false;
                }
                StandardEntry();

                bool createsimdesc = false; // custom


                SimDescription BonehildaDesc = null;

                if (Target.mBonehilda == null)
                {

                    Target.mBonehilda = 
                        Instantiator.RootIsOpenDGSInstalled ? 
                            Genetics.MakeSim(CASAgeGenderFlags.Adult, CASAgeGenderFlags.Female, GameUtils.GetCurrentWorld(), uint.MaxValue) 
                        : null;

                    if (Target.mBonehilda == null)
                    {
                        BonehildaCoffin[] blist = NFinalizeDeath.SC_GetObjects<BonehildaCoffin>();

                        Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                        Household ActiveHouseholdX = Household.ActiveHousehold;

                        List<SimDescription> sSimDescriptionList = new List<SimDescription>();

                        //if (!Instantiator.RootIsOpenDGSInstalled)
                        //{
                        //    foreach (var item in NFinalizeDeath.TattoaX())
                        //    {
                        //        global::NiecMod.Helpers.Create.
                        //            AddNiecSimDescription(item);
                        //        Simulator.Sleep(0);
                        //    }
                        //}


                        int isleep = 0;

                        foreach (SimDescription item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true))
                        {
                            if (item == null)
                                continue;
                           
                            

                            if (!item.mIsValidDescription)
                                continue;

                            if (item.IsPet) 
                                continue;

                            if (Instantiator.RootIsOpenDGSInstalled && item.mSim != null)
                                continue;

                            isleep++;
                            if (isleep > 20)
                            {
                                isleep = 0;
                                Simulator.Sleep(0);
                            }


                            if (item.LotHome != null)
                                continue;

                            //if (item.Household == null)
                            //    continue;

                            if (item.mHousehold == ActiveHousehold)
                                continue;
                            if (item.mHousehold == ActiveHouseholdX)
                                continue;
                            if (NFinalizeDeath.FindBonehildaCoffinSimDesc(blist, item) != null) 
                                continue;

                            if ((item.Service ?? item.CreatedByService) is GrimReaper) continue;

                            if (item.TeenOrAbove)
                            {
                                sSimDescriptionList.Add(item);
                            }
                        }
                        if (sSimDescriptionList.Count > 0)
                        {
                            SimDescription simd = RandomUtil.GetRandomObjectFromList<SimDescription>(sSimDescriptionList, ListCollon.SafeRandom);
                            sSimDescriptionList.Clear();
                            if (simd != null)
                            {
                                Target.mBonehilda = simd;
                                simd.IsBonehilda = true;
                            }
                        }

                        BonehildaDesc = Target.mBonehilda;

                        if (BonehildaDesc == null)
                        {
                            //EndCommodityUpdates(false);
                            Simulator.Sleep(10);
                            Target.SetCoffinActive(false);
                            StandardExit();
                            return false;
                        }

                        if (BonehildaDesc.Household == null)
                        {
                            BonehildaDesc.IsGhost = false;
                            BonehildaDesc.mDeathStyle = 0;

                            (Household.NpcHousehold ?? Actor.Household ?? Household.ActiveHousehold).Add(BonehildaDesc);
                        }

                    }
                    else
                    {
                        BonehildaDesc = Target.mBonehilda;

                        BonehildaDesc.Marryable = false;
                        BonehildaDesc.CanBeKilledOnJob = false;
                        BonehildaDesc.AgingEnabled = false;
                        BonehildaDesc.Contactable = false;
                        BonehildaDesc.FirstName = "Gameplay/Actors/Sim:BonehildaName"; //Localization.LocalizeString("Gameplay/Actors/Sim:BonehildaName");
                        BonehildaDesc.LastName = "";
                        BonehildaDesc.TraitManager.RemoveAllElements();
                        BonehildaDesc.TraitManager.AddElement(TraitNames.Brave);
                        BonehildaDesc.TraitManager.AddElement(TraitNames.Neat);
                        BonehildaDesc.TraitManager.AddElement(TraitNames.Workaholic);
                        BonehildaDesc.TraitManager.AddElement(TraitNames.Athletic);
                        BonehildaDesc.TraitManager.AddElement(TraitNames.Perfectionist);
                        BonehildaDesc.TraitManager.AddHiddenElement(TraitNames.ImmuneToFire);
                        BonehildaDesc.VoiceVariation = VoiceVariationType.B;
                        BonehildaDesc.VoicePitchModifier = 0f;

                        if (BonehildaDesc.Household == null)
                            (Household.NpcHousehold ?? Actor.Household ?? Household.ActiveHousehold).Add(BonehildaDesc);

                        createsimdesc = true;
                    }
                }


                BonehildaDesc = Target.mBonehilda;

                if (BonehildaDesc.Household == null)
                {
                    BonehildaDesc.IsGhost = false;
                    BonehildaDesc.mDeathStyle = 0;

                    (Household.NpcHousehold ?? Actor.Household ?? Household.ActiveHousehold).Add(BonehildaDesc);
                }

                if (BonehildaDesc.CreatedSim == null)
                    Target.mBonehildaSim = BonehildaDesc.Instantiate(Vector3.OutOfWorld, Instantiator.RootIsOpenDGSInstalled);
                else
                    Target.mBonehildaSim = BonehildaDesc.CreatedSim;

                BonehildaDesc = null;

                if (Target.mBonehildaSim == null)
                {
                    Simulator.Sleep(10);
                    Target.SetCoffinActive(false);
                    StandardExit();
                    return false;
                }

                Target.mBonehildaSim.GreetSimOnLot(Target.LotCurrent);

                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS") && Target.mBonehildaSim.Inventory != null)
                    Target.mBonehildaSim.Inventory.DestroyItems(true);

                Target.mBonehildaSim.SetOpacity(0f, 0f);

                if (createsimdesc) // custom
                    Target.SetUpBonehildaOutfit();

                AcquireStateMachine("BonehildaAwaken");
                SetActor("x", Actor);
                SetActor("coffin", Target);
                EnterState("x", "Enter");
                BeginCommodityUpdates();
                AnimateSim("Exit_Awaken");
                bool ok = Target.SpawnBonehilda(); // custom
                EndCommodityUpdates(ok);
                StandardExit();
                return ok;
            }
        }
    }
}
