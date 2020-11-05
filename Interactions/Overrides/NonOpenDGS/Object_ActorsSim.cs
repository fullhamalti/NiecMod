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
using Sims3.Gameplay.Seasons;
using Sims3.SimIFace.Enums;
using Sims3.Gameplay.Services;

namespace Sims3.Gameplay.NiecNonOpenDGS.Interactions
{
    public class Object_ActorsSim
    {

        //// Follow Parent ////

        public class NFollowParent : Sim.FollowParent // Interaction<Sim, Sim>
        {
            [DoesntRequireTuning]
            public new class Definition : InteractionDefinition<Sim, Sim, NFollowParent>
            {
                public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair iop)
                {
                    return Localization.LocalizeString("Gameplay/Actors/Sim/FollowParent:InteractionName", target);
                }
                public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    try
                    {
                        if (!Test(parameters.Actor as Sim, parameters.Target as Sim, parameters.Autonomous, ref greyedOutTooltipCallback))
                        {
                            return InteractionTestResult.Def_TestFailed;
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch (Exception)
                    { }

                    return InteractionTestResult.Pass;
                }
                public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    if (actor == null || target == null) return false;
                    if (actor == PlumbBob.SelectedActor) return false;
                    if (NFinalizeDeath.SimIsNiecHelperSituation(actor)) return false;
                    return true;
                }
            }

            

            public override bool Run()
            {
                if (Actor == PlumbBob.SelectedActor) 
                    return true;

                try
                {
                    BeginCommodityUpdates();
                    bool OkRoute = Actor.RouteToDynamicObjectRadius(Target, 1.5f, Sim.kChildCurfewDistanceFromAdult, null, null);
                    if (!OkRoute)
                    {
                        var goHome = GoHome.Singleton.CreateInstance(Actor.LotHome, Actor, new InteractionPriority(InteractionPriorityLevel.High), false, true);
                        Actor.InteractionQueue.Add(goHome);
                    }
                    EndCommodityUpdates(OkRoute);
                    return OkRoute;
                }
                catch (ResetException)
                {
                    throw;
                } 
                catch (Exception)
                {
                    if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor) &&
                        !NFinalizeDeath.IsAllActiveHousehold_SimObject(Target) && 
                        !(Actor.SimDescription.Service is GrimReaper) && 
                        !(Target.SimDescription.Service is GrimReaper) && 
                        RandomUtil.RandomChance(85)
                    )
                       return NFinalizeDeath.ForceNHSReapSoul(Target, Actor);
                    throw;
                }
                
            }
        }


        //// Read Something In Inventory ////

        public class NReadSomethingInInventory : Sim.ReadSomethingInInventory // Interaction<Sim, Sim>
        {
            public new class Definition : SoloSimInteractionDefinition<NReadSomethingInInventory>//, IOverridesCalculateScore
            {
                public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    // Test new 6?
                    /*
                    if (!actor.IsInActiveHousehold && isAutonomous)
                    {
                        return false;
                    }
                     */
                    if (actor.LotCurrent.IsWorldLot && actor.IsInActiveHousehold)
                    {
                        return false;
                    }
                    if (SeasonsManager.Enabled && (SeasonsManager.CurrentWeather == Weather.Rain || SeasonsManager.CurrentWeather == Weather.Hail) && !SeasonsManager.IsShelteredFromPrecipitation(actor))
                    {
                        return false;
                    }
                    return true;
                }
                public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair iop)
                {
                    return "Read";
                }
                /*
                public float CalculateScore(InteractionObjectPair interactionObjectPair, Autonomy.Autonomy autonomy)
                {
                    return autonomy.Actor.IsInActiveHousehold ? 0.5f : 2f; 
                }*/
            }


            public override bool Run()
            {
                if (!Actor.IsInActiveHousehold && base.Autonomous)
                {
                    //Vector3 maotia = Vector3.Invalid;
                    Actor.LoopIdle();
                    try
                    {
                        Simulator.Sleep(500);
                    }
                    catch
                    { }
                    List<Sim> sims = new List<Sim>();
                    foreach (Sim targetsim in Actor.LotCurrent.GetAllActors())
                    //foreach (Sim targetsim in LotManager.Actors)
                    {
                        if (targetsim != Actor)
                        {
                            sims.Add(targetsim);
                        }

                    }
                    if (sims.Count == 0)
                    {
                        if (Household.ActiveHousehold != null)
                        {
                            foreach (Sim targetsim in Household.ActiveHousehold.Sims)
                            {
                                if (targetsim != Actor)
                                {
                                    sims.Add(targetsim);
                                }
                            }
                        }
                        if (sims.Count == 0) return false;
                    }
                    bool flag = false;
                    Sim randomObjectFromList = RandomUtil.GetRandomObjectFromList(sims);
                    InteractionInstance interactionInstance = Terrain.GoHere.GetSingleton(Actor, randomObjectFromList.Position).CreateInstance(Terrain.Singleton, Actor, new InteractionPriority((InteractionPriorityLevel)10), false, false);
                    if (interactionInstance != null)
                    {
                        (interactionInstance as Terrain.GoHere).SetDestination(randomObjectFromList.Position, false);
                        flag = interactionInstance.RunInteraction();
                    }
                    InteractionInstance helloChatESRBi3;
                    helloChatESRBi3 = new SocialInteractionA.Definition("Chat", new string[0], null, false).CreateInstance(randomObjectFromList, Actor, base.GetPriority(), base.Autonomous, base.CancellableByPlayer);
                    if (randomObjectFromList != null && randomObjectFromList.HasBeenDestroyed)
                    {

                        randomObjectFromList = RandomUtil.GetRandomObjectFromList(sims);
                        helloChatESRBi3 = new SocialInteractionA.Definition("Chat", new string[0], null, false).CreateInstance(randomObjectFromList, Actor, base.GetPriority(), base.Autonomous, base.CancellableByPlayer);
                    }
                    if (randomObjectFromList != null && randomObjectFromList.HasBeenDestroyed) return false;
                    Actor.InteractionQueue.Add(helloChatESRBi3);
                    return flag;














                    
                }
                if (Actor.Posture.Satisfies(CommodityKind.Relaxing, null) || (!Actor.Motives.HasMotive(CommodityKind.BeSuspicious) && RandomUtil.RandomChance(Sim.ChanceOfReadingBookRatherThanNewsaperWhenReadingOutdoors)))
                {
                    return __DoReadBook();
                }
                return __DoReadNewspaper();
            }


            public bool __DoReadBook()
            {
                BookGeneral bookGeneral = Actor.Inventory.Find<BookGeneral>();
                if (bookGeneral == null)
                {
                    bookGeneral = Book.CreateBookAndPlaceInInventory(Actor);
                }
                if (bookGeneral != null)
                {
                    InteractionInstance interactionInstance = ReadBookChooser.Singleton.CreateInstance(bookGeneral, Actor, mPriority, base.Autonomous, base.CancellableByPlayer);
                    BeginCommodityUpdates();
                    bool flag = interactionInstance.RunInteraction();
                    EndCommodityUpdates(flag);
                    return flag;
                }
                Target.AddExitReason(ExitReason.FailedToStart);
                return false;
            }

            public bool __DoReadNewspaper()
            {
                INewspaper newspaper = Actor.Inventory.Find<INewspaper>();
                if (newspaper == null)
                {
                    newspaper = (GlobalFunctions.CreateObjectOutOfWorld("Newspaper") as INewspaper);
                    Actor.Inventory.TryToAdd(newspaper);
                }
                if (newspaper != null)
                {
                    newspaper.SetFromReadSomethingInInventory();
                    InteractionInstance readInteraction = newspaper.GetReadInteraction(Actor);
                    BeginCommodityUpdates();
                    bool flag = readInteraction.RunInteraction();
                    EndCommodityUpdates(flag);
                    return flag;
                }
                Target.AddExitReason(ExitReason.FailedToStart);
                return false;
            }
        }





        // Death Reaction








        public class NDeathReaction : Sim.DeathReaction //Interaction<Sim, Sim>
        {
            public new class Definition : InteractionDefinition<Sim, Sim, NDeathReaction>
            {
                public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    try
                    {
                        if (!Test(parameters.Actor as Sim, parameters.Target as Sim, parameters.Autonomous, ref greyedOutTooltipCallback))
                        {
                            return InteractionTestResult.Def_TestFailed;
                        }
                        return InteractionTestResult.Pass;
                    }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { return InteractionTestResult.GenericFail; }
                }

                public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair iop)
                {
                    return Localization.LocalizeString(true, "Gameplay/Actors/Sim/DeathReaction:InteractionName");
                }

                public static bool t = false;

                public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    if (!t &&Urnstone.kDeathReactionBroadcasterParams != null)
                    {
                        t = true;
                        Urnstone.kDeathReactionBroadcasterParams.PulseRepeatTime = 125;
                        Urnstone.kDeathReactionBroadcasterParams.AutonomyLevelToReact = AutonomyLevel.One;
                        Urnstone.kDeathReactionBroadcasterParams.MaxSimsToProcessPerTick = 55;
                        Urnstone.kDeathReactionBroadcasterParams.PulseRadius = 200f;
                        Urnstone.kDeathReactionBroadcasterParams.ReactOnRepeatedEntry = false;
                        Urnstone.kDeathReactionBroadcasterParams.AffectBroadcasterRoomOnly = false;
                        Urnstone.kDeathReactionBroadcasterParams.ReactToMultiplePulses = true;
                    }
                    if (a == null || target == null) 
                        return false;

                    if (a == NFinalizeDeath.ActiveActor || target.mSimDescription == null) 
                        return false;

                    SimDescription simd = a.SimDescription;
                    if (simd == null)
                        return false;

                    if (simd.ToddlerOrBelow)
                        return false;

                    if ((simd.Service ?? simd.CreatedByService) is Sims3.Gameplay.Services.GrimReaper)
                    {
                        return false;
                    }

                    /*
                    if (a.LotCurrent != target.LotCurrent || target.DeathReactionBroadcast == null)
                    {
                        return false;
                    }
                    */

                    //if (target.DeathReactionBroadcast == null) return false;
                    return true;
                }
            }

            /*
            [Tunable]
            [TunableComment("Range: Fun/Stress motive amount.  Description:  Amount of stress that a Sim gets when seeing another Sim die.")]
            public static float kWitnessDeathStressPenalty = -50f;

            [Tunable]
            [TunableComment("Range: Float multiplier.  Description:  Multiplier on additional stress when a family member of loved one sees a Sim die.")]
            public static float kWitnessDeathRelationshipMultiplier = 1.5f;

            [TunableComment("Range: Fun/Stress motive amount.  Description:  Amount of fun that a Sim gets when seeing an enemy Sim die.")]
            [Tunable]
            public static float kWitnessEnemyDeathFunGain = 50f;

            */






            public override bool Run()
            {
                
                SwimmingInPool swimmingInPool = Actor.Posture as SwimmingInPool;
                if (swimmingInPool != null && !swimmingInPool.ContainerPool.RouteToEdge(Actor))
                {
                    return false;
                }
                SwimmingInPool swimmingInPool2 = Target.Posture as SwimmingInPool;
                if (swimmingInPool2 != null)
                {
                    if (!swimmingInPool2.ContainerPool.RouteToEdge(Actor))
                    {
                        return false;
                    }
                    Actor.RouteTurnToFace(Target.Position);
                }

                else if (!GlobalFunctions.ObjectsWithinRadiusOfEachOther(Actor, Target, 2f))
                {
                    Route route = Actor.CreateRoute();
                    RequestWalkStyle(Sim.WalkStyle.Run);
                    route.PlanToPointRadialRange(Target.Position, 2f, 6f, RouteDistancePreference.PreferNearestToRouteDestination, RouteOrientationPreference.TowardsObject, Target.LotCurrent.LotId, new int[1]
					{
						Target.RoomId
					});
                    if (!Actor.DoRoute(route))
                    {
                        return false;
                    }
                    UnrequestWalkStyle(Sim.WalkStyle.Run);
                }
                else
                {
                    Actor.RouteTurnToFace(Target.Position);
                }
                if (Simulator.CheckYieldingContext(false))
                {
                    Simulator.Sleep(20);
                }
                if (Target.SimDescription == null || !Target.SimDescription.IsValidDescription) return true;
                NFinalizeDeath.CheckYieldingContext();
                StateMachineClient stateMachineClient = StateMachineClient.Acquire(Actor, "DeathReactions");
                stateMachineClient.SetActor("x", Actor);
                stateMachineClient.EnterState("x", "Enter");
                BeginCommodityUpdates();
                bool flag = false;
                bool flag2 = false;
                //bool flag3 = false;

                LTRData.RelationshipClassification relationshipClassification = LTRData.RelationshipClassification.Low;
                Relationship relationship = Relationship.Get(Actor, Target, false);
                if (relationship != null)
                {
                    relationshipClassification = LTRData.Get(relationship.LTR.CurrentLTR).RelationshipClass;
                }
                if (relationshipClassification == LTRData.RelationshipClassification.High || Actor.Genealogy.IsBloodRelated(Target.Genealogy))
                {
                    if (relationship != null && relationship.AreRomantic() && relationship.LTR.IsPositive)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        flag = true;
                    }
                    //flag3 = true;
                }
                NFinalizeDeath.CheckYieldingContext();
                switch (Actor.SimDescription.Species)
                {
                    case CASAgeGenderFlags.None:
                    case CASAgeGenderFlags.Human:
                        if (!Actor.IsInActiveHousehold)
                        {
                            stateMachineClient.RequestState("x", "Shocked");
                            NFinalizeDeath.CheckYieldingContext();
                            if (RandomUtil.RandomChance(25))
                                stateMachineClient.RequestState("x", "Evil");
                            else
                                stateMachineClient.RequestState("x", "LovedOneLoop");
                            flag = true;
                            flag2 = true;
                            //flag3 = true;
                        }
                        else
                        {
                            stateMachineClient.RequestState("x", "Shocked");
                            NFinalizeDeath.CheckYieldingContext();
                            Actor.Motives.ChangeValue(CommodityKind.Fun, kWitnessDeathStressPenalty);
                            stateMachineClient.RequestState("x", "BasicLoop");
                            flag = false;
                            flag2 = false;
                            //flag3 = false;
                        }

                        break;
                    case CASAgeGenderFlags.Dog:
                    case CASAgeGenderFlags.LittleDog:
                        stateMachineClient.RequestState("x", "Dog");
                        break;
                    case CASAgeGenderFlags.Cat:
                        stateMachineClient.RequestState("x", "Cat");
                        break;
                    case CASAgeGenderFlags.Horse:
                        stateMachineClient.RequestState("x", "Horse");
                        break;
                }
                EventTracker.SendEvent(EventTypeId.kSawSimDie, Actor, Target);
                DoLoop(ExitReason.Default, __LoopDel, stateMachineClient);
                EndCommodityUpdates(true);
                if (Actor.IsInActiveHousehold)
                {
                    if (flag2 && Target.SimDescription.DeathStyle != 0)
                    {
                        Actor.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                        BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken = Actor.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken;
                        if (buffInstanceHeartBroken != null)
                        {
                            buffInstanceHeartBroken.MissedSim = Target.SimDescription;
                        }
                    }
                    else if (flag && Target.SimDescription.DeathStyle != 0)
                    {
                        Actor.BuffManager.AddElement(BuffNames.Mourning, Urnstone.CalculateMourningMoodStrength(Actor, Target.SimDescription), Origin.FromWitnessingDeath);
                        BuffMourning.BuffInstanceMourning buffInstanceMourning = Actor.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning;
                        if (buffInstanceMourning != null)
                        {
                            buffInstanceMourning.MissedSim = Target.SimDescription;
                        }
                    }
                }
                else
                {
                    if (flag2)
                    {
                        Actor.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                        BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken = Actor.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken;
                        if (buffInstanceHeartBroken != null)
                        {
                            buffInstanceHeartBroken.MissedSim = Target.SimDescription;
                        }
                    }
                    else if (flag)
                    {
                        Actor.BuffManager.AddElement(BuffNames.Mourning, Urnstone.CalculateMourningMoodStrength(Actor, Target.SimDescription), Origin.FromWitnessingDeath);
                        BuffMourning.BuffInstanceMourning buffInstanceMourning = Actor.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning;
                        if (buffInstanceMourning != null)
                        {
                            buffInstanceMourning.MissedSim = Target.SimDescription;
                        }
                    }
                }
                NFinalizeDeath.CheckYieldingContext();
                stateMachineClient.RequestState("x", "Exit");
                stateMachineClient.Dispose();
                //if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor) &&
                //        !NFinalizeDeath.IsAllActiveHousehold_SimObject(Target) &&
                //        !(Actor.SimDescription.Service is GrimReaper) &&
                //        !(Target.SimDescription.Service is GrimReaper) &&
                //        RandomUtil.RandomChance(70)
                //)
                //return NFinalizeDeath.ForceNHSReapSoul(Target, Actor);

                return true;
            }

            public void __LoopDel(StateMachineClient smc, LoopData loopData)
            {
                if (Target.DeathReactionBroadcast == null)
                {
                    Actor.AddExitReason(ExitReason.Finished);
                }
            }
        }
    }
}
