/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 15/09/2018
 * Time: 0:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Academics;
using Sims3.Gameplay.ActiveCareer;
using Sims3.Gameplay.ActiveCareer.ActiveCareers;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.ActorSystems.Children;
using Sims3.Gameplay.Actors;
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
using  Sims3.UI.Resort;
using NiecMod.Nra;
using Sims3.Gameplay.NiecRoot;
using NiecMod.KillNiec;
namespace NiecMod.Interactions
{
    public sealed class ForceRequestGrimReaper: ImmediateInteraction<Sim, Sim>
    {
        public static readonly InteractionDefinition Singleton = new Definition();

        public bool IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");

        public bool NoAutoCreateNiecHelperSituation = false;

        public override bool Run() // Run
        {
            try
            {
               //bool asdasd = NFinalizeDeath.IsSimFastActiveHousehold(Target);
               //
               //if (!asdasd && !AssemblyCheckByNiec.IsInstalled("OpenDGS") && Target.Service is GrimReaper)
               //{
               //    asdasd = true;
               //
               //}
               //
               //else if (asdasd && Target.Service is GrimReaper)
               //{
               //    if (!NFinalizeDeath.CheckAccept("Warning: Remove Sim Family Death Good System or Grim Reaper?")) return false;
               //    {
               //        if (Target == NFinalizeDeath.ActiveActor)
               //        {
               //            //UserToolUtils.OnClose();
               //            LotManager.SelectNextSim();
               //        }
               //        Target.SimDescription.Household.Remove(this.Target.SimDescription);
               //        Household.NpcHousehold.Add(this.Target.SimDescription);
               //
               //    }
//#pragma warni//g disable 1058
               //    //try {LotManager.SelectNextSim();}catch (Exception) { }catch { }
//#pragma warni//g restore 1058
               //    return true;
               //}
               //if (!asdasd && NFinalizeDeath.CheckAccept("AntiNPCSim:\nKill NPC Sim? Request Grim Reaper"))
               //{
               //    if (Target.LotCurrent.IsWorldLot)
               //    {
               //        //if (Nra.NFinalizeDeath.MyActiveActor(PlumbBob.SelectedActor.SimDescription) && PlumbBob.SelectedActor != null && !PlumbBob.SelectedActor.LotCurrent.IsWorldLot)
               //        //    Target.SetPosition(PlumbBob.SelectedActor.Position);
               //        //else
               //        //    Target.SetPosition(PlumbBob.SelectedActor.LotHome.Position);
               //        Target.SetPosition((NFinalizeDeath.ActiveActor_ChildAndTeen ?? Actor).Position);
               //    }
               //    try
               //    {
               //        if ( /* Actor.SimDescription.DeathStyle != SimDescription.DeathType.None && */ Target.SimDescription.IsGhost || Target.SimDescription.IsDead)
               //        {
               //            SimDescription simDescriptiongot = Target.SimDescription;
               //            simDescriptiongot.IsGhost = false;
               //            World.ObjectSetGhostState(Target.ObjectId, 0u, (uint)simDescriptiongot.AgeGenderSpecies);
               //            
               //            Target.Autonomy.Motives.RemoveMotive(CommodityKind.BeGhostly);
               //            simDescriptiongot.mDeathStyle = SimDescription.DeathType.None; // (SimDescription.DeathType.None, false);
               //            simDescriptiongot.ShowSocialsOnSim = true;
               //            simDescriptiongot.IsNeverSelectable = false;
               //            Target.Autonomy.AllowedToRunMetaAutonomy = true;
               //        }
               //    }
               //    catch
               //    { }
               //    Target.SimDescription.mDeathStyle = SimDescription.DeathType.Drown;
               //
               //    //GrimReaper.Instance.MakeServiceRequest(Target.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
               //    //return true;
               //}
               //
               //else if (!NFinalizeDeath.CheckAccept("Force Request Grim Reaper?")) return false;
               //
               //if (!NoAutoCreateNiecHelperSituation && NiecHelperSituation.Spawn.UnSafeRunAll && NiecHelperSituation.WorkingNiecHelperSituationCount == 0 && NFinalizeDeath.CheckAccept("Create All NHS ?"))
               //{
               //    Sim ActiveActor = NFinalizeDeath.ActiveActor;
               //    foreach (var Actorfor in NFinalizeDeath.SC_GetObjects<Sim>())
               //    {
               //        try
               //        {
               //            if (Actorfor == ActiveActor) continue;
               //
               //            NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actorfor).CreateInteractionToAddIQ(Target);
               //            
               //        }
               //        catch (Exception)
               //        {
               //            continue;
               //        }
               //
               //        break;
               //    }
               //}

               // if ( GrimReaper.Instance != null)
               //     GrimReaper.Instance.MakeServiceRequest(Target.LotCurrent, true, ObjectGuid.InvalidObjectGuid);

                if (!Simulator.CheckYieldingContext(false)) 
                    return false;

                if (Target.SimDescription != null && NFinalizeDeath.CheckAccept("Kill Sim? Request Grim Reaper"))
                {

                    SimDescription simDescriptiongot = Target.SimDescription;
                    if (simDescriptiongot.IsGhost || simDescriptiongot.IsDead)
                    {

                        simDescriptiongot.IsGhost = false;
                        if (Target.ObjectId.mValue != 0)
                            ScriptCore.World.World_ObjectSetGhostState(Target.ObjectId.mValue, 0u, (uint)simDescriptiongot.AgeGenderSpecies);

                        simDescriptiongot.mDeathStyle = SimDescription.DeathType.None;
                        simDescriptiongot.ShowSocialsOnSim = true;
                        simDescriptiongot.IsNeverSelectable = false;

                    }

                    try
                    {
                        var a = Target.Autonomy;
                        if (a != null)
                        {
                            a.AllowedToRunMetaAutonomy = true;
                            var m = a.Motives;
                            if (m != null && m.mMotives != null)
                            {
                                m.RemoveMotive(CommodityKind.BeGhostly);
                            }
                        }
                    }
                    catch
                    { }

                    simDescriptiongot.mDeathStyle = SimDescription.DeathType.Drown;


                    if (GrimReaper.Instance != null)
                        GrimReaper.Instance.MakeServiceRequest(Target.LotCurrent ?? GetCameraTargetLot(), true, ObjectGuid.InvalidObjectGuid);

                    if (Target.LotCurrent != null && Target.LotCurrent.IsWorldLot)
                    {
                        var p = get_non_world_lot_pos(Actor, Target, false);
                        if (p != snwlot_return_failed)
                            Target.SetPosition(p);
                        //Sims3.Gameplay.Core.Camera.FocusOnSim(Target);
                    }
                }

                else if (GrimReaper.Instance != null && NFinalizeDeath.CheckAccept("Force Request Grim Reaper?"))
                {
                    GrimReaper.Instance.MakeServiceRequest(Target.LotCurrent ?? GetCameraTargetLot(), true, ObjectGuid.InvalidObjectGuid);
                }

            }
            catch (ResetException) { throw; }
            catch (Exception)
            {
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS")) 
                    throw;
                // else why Send bug EA
            }
            
        	return true;
        }

        [CompilerGenerated]
        public static readonly Vector3 snwlot_return_failed = new Vector3(-1, 5, -1);

        public static Vector3 get_non_world_lot_pos(Sim actor_obj = null, Sim target_obj = null, bool safe = true)
        {
            bool is_t_null = false;
            if (target_obj == null)
            {
                is_t_null = true;
                target_obj = actor_obj;
            }

            if (target_obj != null)
            {
                var lotC = target_obj.LotCurrent;
                Lot lotHome;

                if (lotC != null)
                {
                    if (lotC.IsWorldLot)
                    {
                        lotHome = target_obj.LotHome;
                        if (lotHome != null && !(lotHome is WorldLot))
                            return lotHome.EntryPoint();
                    }
                    else return target_obj.Position;
                }

                if (is_t_null)
                    actor_obj = null;

                var other_obj = actor_obj ?? NFinalizeDeath.ActiveActor_AAndChildAndTeen;// ?? NFinalizeDeath.GetRandomSim();
                if (other_obj != null)
                {
                    lotC = other_obj.LotCurrent;
                    if (lotC != null)
                    {
                        if (lotC.IsWorldLot)
                        {
                            lotHome = other_obj.LotHome;
                            if (lotHome != null && !(lotHome is WorldLot))
                                return lotHome.EntryPoint();
                        }
                        else
                        {
                            var other_obj_pos = NFinalizeDeath.GetPositionBase
                                (other_obj.ObjectId.mValue);

                            other_obj_pos += 
                                (NFinalizeDeath.Random_CoinFlip() ? 1.8f : 2.7f) * 
                                NFinalizeDeath.GetForwardBase(other_obj.ObjectId.mValue);

                            if (!(GetPostionTargetLot(other_obj_pos) is WorldLot))
                                return other_obj_pos;
                        }
                    }
                }
            }

            var t = GetCameraTargetLot();
            if (t is WorldLot)
            {
                var lots = LotManager.sLots;
                if (lots != null && lots.Count > 0)
                {
                    foreach (var item in lots)
                    {
                        Lot item_lot = item.value;
                        if (item_lot == null || item_lot.IsWorldLot)
                            continue;
                        return item_lot.EntryPoint();
                    }
                }
                if (!safe)
                {
                    var p = ScriptCore.CameraController.Camera_GetTarget();
                    if (NFinalizeDeath.Vector3_IsUnsafe(p))
                        return snwlot_return_failed;
                    else return p;
                }
                else return snwlot_return_failed;
            }
            else return t.EntryPoint();
        }
        public static Lot GetPostionTargetLot(Vector3 pos)
        {
            if (LotManager.sLots == null)
                return LotManager.GetWorldLot();
            LotLocation LotLocation = default(LotLocation);
            ulong Location = World.GetLotLocation(pos, ref LotLocation);
            Lot TargetLot = LotManager.GetLot(Location);
            if (TargetLot == null)
                return LotManager.GetWorldLot();
            return TargetLot;
        }
        public static Lot GetCameraTargetLot()
        {
            if (LotManager.sLots == null)
                return LotManager.sActiveLot ?? LotManager.sWorldLot;
            LotLocation LotLocation = default(LotLocation);
            ulong Location = World.GetLotLocation(NFinalizeDeath.Fast_SnapToFloor(ScriptCore.CameraController.Camera_GetTarget()), ref LotLocation);
            Lot TargetLot = LotManager.GetLot(Location);
            if (TargetLot == null)
                return LotManager.sActiveLot ?? LotManager.sWorldLot;
            return TargetLot;
        }
        [DoesntRequireTuning]
        
        private sealed class Definition : ImmediateInteractionDefinition<Sim, Sim, ForceRequestGrimReaper>, IAllowedOnClosedVenues, IOverridesAgeTests, IUseTargetForAutonomousIsAllowedInRoomCheck, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
        {
            public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair interaction)
            {
                try
                {
                    if (target.IsInActiveHousehold && target.Service is GrimReaper)
                    {
                        return "Remove to Family " + target.Name;
                    }
                    return Localization.LocalizeString("NiecMod/Interactions/Force:RequestGrimReaperX", new object[0]);
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    return "Force Request Grim Reaper";
                }
            }
            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {

                if (!Test(parameters.Actor as Sim, parameters.Target as Sim, parameters.Autonomous, ref greyedOutTooltipCallback))
                {
                    return InteractionTestResult.Def_TestFailed;
                }
                return InteractionTestResult.Pass;
            }
            public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
            	if (isAutonomous) return false;
            	//if (actor.IsNPC) return false;
            	
            	return true;
            }
            public override string[] GetPath(bool bPath)
            {
            	return new string[] { "NiecMod..." };
            }
            public SpecialCaseAgeTests GetSpecialCaseAgeTests()
            {
                return SpecialCaseAgeTests.None;
            }
        }
    }
    /*//Actor.Autonomy.SituationComponent.Situations.Add(NiecHelperSituation.Create(Actor.LotCurrent, Actor));
                            SpeedTrap.Sleep(0);

                            NiecHelperSituation situationOfTypex = ActiveActor.GetSituationOfType<NiecHelperSituation>();
                            if (situationOfTypex != null)
                            {
                                if (Target != ActiveActor)
                                {
                                    ActiveActor.InteractionQueue.Add(NiecHelperSituation.NiecAppear.Singleton.CreateInstance(
                                        Target, Actorfor, 
                                        IsOpenDGSInstalled ? 
                                        new InteractionPriority((InteractionPriorityLevel)100, 999f)
                                        : new InteractionPriority(InteractionPriorityLevel.ESRB, 999f),
                                    isAutonomous: false,
                                    cancellableByPlayer: true));
                                }
                            }
                            else
                            {
                                var nhs = NiecHelperSituation.Create(Actorfor.LotCurrent, Actorfor);
                                if (nhs != null)
                                    Actorfor.Autonomy.SituationComponent.Situations.Add(nhs);
                                else continue;
                                situationOfTypex = ActiveActor.GetSituationOfType<NiecHelperSituation>();


                                if (Target != ActiveActor)
                                {
                                    Actorfor.InteractionQueue.Add(
                                        (!situationOfTypex.OkSuusse ? Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton 
                                        : NiecHelperSituation.ReapSoul.Singleton).
                                        CreateInstance(Target, Actorfor, 
                                        IsOpenDGSInstalled ?
                                        new InteractionPriority((InteractionPriorityLevel)100, 999f)
                                        : new InteractionPriority(InteractionPriorityLevel.ESRB, 999f),
                                    isAutonomous: false,
                                    cancellableByPlayer: true));
                                }
                            }*/
}
