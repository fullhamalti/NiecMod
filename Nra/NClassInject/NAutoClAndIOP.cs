using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Controllers;
using Sims3.SimIFace;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.ThoughtBalloons;
using Sims3.Gameplay.Pools;
using Sims3.SimIFace.CAS;
using Sims3.Gameplay;
using System.Reflection;

namespace NiecMod.Nra
{
    public class NAutoCl
    {
        private static object OV = null;

        public static void InitNCreate()
        {
            if ((OV as NAutoCl) != null)
                return;

            OV = new NAutoCl();
        }

        public static NAutoCl GetStatic()
        {
            InitNCreate();
            return (NAutoCl)OV;
        }

        public static void InitClass()
        {
            var p = GetStatic();
            NFinalizeDeath.M(p.IsNSufficientlyOnScreenForHighLODSimulation);
            NFinalizeDeath.M(p.IsNRunningHighLODSimulation);
            NFinalizeDeath.M(p.NShouldRunLocalAutonomy);
        }
        public bool IsNSufficientlyOnScreenForHighLODSimulation
        {
            get
            {
                return true;
            }
        }
        public bool IsNRunningHighLODSimulation
        {
            get
            {
                return true;
            }
        }
        public bool NShouldRunLocalAutonomy
        {
            get
            {
                return true;
            }
        }
    }

    public class NMotive : Sims3.Gameplay.Autonomy.Motive
    {
        private static bool IsCheckKillSimInteraction(Sim sim)
        {
            if (sim == null || Urnstone.KillSim.Singleton == null)
            {
                return false;
            }

            InteractionQueue intt = sim.InteractionQueue;
            if (intt == null || intt.mInteractionList == null)
            {
                return false;
            }

            Type typeKillSim = Urnstone.KillSim.Singleton.GetType();
            Type typeSocialInteractionB = typeof(SocialInteractionB.DefinitionDeathInteraction);

            foreach (InteractionInstance item in intt.mInteractionList)
            {
                if (item != null && item.InteractionDefinition != null)
                {
                    Type tf2 = item.InteractionDefinition.GetType();
                    if (tf2 == typeSocialInteractionB)
                    {
                        return true;
                    }
                    if (tf2 == typeKillSim)
                    {
                        return true;
                    }
                }
            }

            Type typeCacheNiecModSocial = typeof(NiecMod.KillNiec.KillSimNiecX.NiecDefinitionDeathInteraction);
            Type typeExtKillSimNiec = typeof(NiecMod.Interactions.ExtKillSimNiec);

            foreach (InteractionInstance mInteraction in intt.mInteractionList)
            {
                if (mInteraction.GetType() == typeExtKillSimNiec)
                {
                    return true;
                }

                if (mInteraction.InteractionDefinition != null && mInteraction.InteractionDefinition.GetType() == typeCacheNiecModSocial)
                {
                    return true;
                }
            }

            return false;
        }

        private static object OV = null;
        public static void InitNCreate()
        {
            if ((OV as NMotive) != null)
                return;

            OV = new NMotive();
        }

        public static NMotive GetStatic()
        {
            InitNCreate();
            return (NMotive)OV;
        }

        public static void InitClass()
        {
            var p = GetStatic();
            p.motive_motive_distress(null, (CommodityKind)0x44440444);
            p.update_motive_buffs(null, CommodityKind.None, -333);
        }

        public void update_motive_buffs(Sim sim, CommodityKind commodity, int currentValue)
        {
            if (currentValue == -333)
                return;

            BuffManager buffManager = sim.BuffManager;
            SimDescription simd = sim.SimDescription;
            TraitManager traitManager = simd.TraitManager;

            MotiveTuning motiveTuning = sim.GetMotiveTuning(commodity);
            if (motiveTuning != null)
            {
                List<MotiveTuning.MotiveBuffTrigger> buffTriggers = motiveTuning.BuffTriggers;
                foreach (MotiveTuning.MotiveBuffTrigger item in buffTriggers)
                {
                    if ((float)currentValue <= Math.Max(item.mTriggerValueStart, item.mTriggerValueEnd) && (float)currentValue >= Math.Min(item.mTriggerValueStart, item.mTriggerValueEnd))
                    {
                        foreach (BuffNames item2 in item.mRemoveBuff)
                        {
                            if (item2 == BuffNames.Hungry)
                            {
                                buffManager.RemoveElement(BuffNames.HungryLikeTheWolf);
                            }
                            buffManager.RemoveElement(item2);
                        }
                        if (item.mAddBuff != BuffNames.Undefined)
                        {
                            if (item.mAddBuff == BuffNames.VeryHungry && simd.IsWerewolf && !buffManager.HasElement(BuffNames.HungryLikeTheWolf))
                            {
                                buffManager.AddElement(BuffNames.HungryLikeTheWolf, Origin.None);
                            }
                            if (!buffManager.HasElement(item.mAddBuff))
                            {
                                buffManager.AddElement(item.mAddBuff, Origin.None);
                            }
                        }
                        if (item.mCustomClass != null)
                        {
                            item.mCustomClass.Invoke(null, new object[1]
							{
								sim
							});
                        }
                    }
                    else if (buffManager.IsPermaMoodlet(item.mAddBuff) && commodity != CommodityKind.Hygiene && commodity != CommodityKind.CatScratch && commodity != CommodityKind.MermaidDermalHydration)
                    {
                        buffManager.RemoveElement(item.mAddBuff);
                    }
                }
            }
            if ((float)currentValue == Tuning.Min || (commodity == CommodityKind.Temperature && (float)currentValue == Tuning.Max))
            {
                MotiveDistress(sim, commodity);
            }
            if (traitManager.HasElement(TraitNames.BroodingTrait))
            {
                if (commodity == CommodityKind.Social && (float)currentValue <= kMisunderstoodSocialMotiveAddValue && !buffManager.HasElement(BuffNames.Misunderstood) && !buffManager.HasElement(BuffNames.NeedToBrood))
                {
                    buffManager.AddElement(BuffNames.Misunderstood, Origin.FromBeingBroodingTrait);
                }
                if (commodity == CommodityKind.Social && (float)currentValue >= kMisunderstoodSocialMotiveRemoveValue)
                {
                    buffManager.RemoveElement(BuffNames.Misunderstood);
                }
            }
            if ((commodity == CommodityKind.Hygiene || commodity == CommodityKind.Energy) && (buffManager.HasElement(BuffNames.SickAndTired) || buffManager.HasElement(BuffNames.PestilencePlague)))
            {
                BuffSickAndTired.CheckForStartStopFlySwarmEffect(sim, commodity, currentValue);
            }
            if (Commodity == CommodityKind.AuraPower)
            {
                BuffFairyAuraProjecting.BuffAuraInstanceBase buffAuraInstanceBase = buffManager.GetElement(BuffNames.FairyAuraProjectingSoothe) as BuffFairyAuraProjecting.BuffAuraInstanceBase;
                if (buffAuraInstanceBase == null)
                {
                    buffAuraInstanceBase = (buffManager.GetElement(BuffNames.FairyAuraProjectingCreative) as BuffFairyAuraProjecting.BuffAuraInstanceBase);
                }
                if (buffAuraInstanceBase == null)
                {
                    buffAuraInstanceBase = (buffManager.GetElement(BuffNames.FairyAuraProjectingMind) as BuffFairyAuraProjecting.BuffAuraInstanceBase);
                }
                if (buffAuraInstanceBase != null)
                {
                    buffAuraInstanceBase.UpdateColor();
                }
            }
        }

        public void motive_motive_distress(Sim sim, CommodityKind commodity)
        {
            if (commodity == (CommodityKind)0x44440444)
                return;

            SimDescription simd = sim.SimDescription;
            BuffManager buffManager = sim.BuffManager;
            Motives moves = sim.Motives;

            switch (commodity)
            {
                case CommodityKind.Bladder:
                    {
                        bool flag = true;
                        InteractionDefinition interactionDefinition;
                        switch (simd.Species)
                        {
                            case CASAgeGenderFlags.Horse:
                                interactionDefinition = Sim.HorsePee.Singleton;
                                break;
                            case CASAgeGenderFlags.Dog:
                            case CASAgeGenderFlags.LittleDog:
                                interactionDefinition = (InteractionDefinition)Sim.DogPeeStart.Singleton;
                                break;
                            case CASAgeGenderFlags.Cat:
                                interactionDefinition = (InteractionDefinition)Sim.CatPeeStart.Singleton;
                                break;
                            default:
                                interactionDefinition = Sim.BladderFailure.Singleton;
                                break;
                        }

                        foreach (InteractionInstance interaction in sim.InteractionQueue.InteractionList)
                        {
                            if (interaction is Sim.DogPee || interaction is Sim.CatPee || interaction.InteractionDefinition == interactionDefinition)
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag)
                        {
                            SwimmingInPool swimmingInPool = sim.Posture as SwimmingInPool;
                            if (swimmingInPool == null)
                            {
                                InteractionInstance interactionInstance = interactionDefinition.CreateInstance(sim, sim, new InteractionPriority(InteractionPriorityLevel.High), false, false);
                                Sim.DogPeeStart dogPeeStart = interactionInstance as Sim.DogPeeStart;
                                if (dogPeeStart != null)
                                {
                                    dogPeeStart.DoNotRoute = true;
                                }
                                else
                                {
                                    Sim.CatPeeStart catPeeStart = interactionInstance as Sim.CatPeeStart;
                                    if (catPeeStart != null)
                                    {
                                        catPeeStart.DoNotRoute = true;
                                    }
                                }
                                if (sim.InteractionQueue.AddNext(interactionInstance) && simd.IsRaccoon)
                                {
                                    sim.AddExitReason(ExitReason.BuffFailureState);
                                }
                                else
                                {

                                    BuffInstance buffOfSolveCommodity = buffManager.GetBuffOfSolveCommodity(commodity);
                                    if (buffOfSolveCommodity != null && buffOfSolveCommodity.EffectValue <= 0)
                                    {
                                        ThoughtBalloonManager.BalloonData balloonData = new ThoughtBalloonManager.BalloonData(buffOfSolveCommodity.ThumbString);
                                        if (balloonData.IsValid)
                                        {
                                            balloonData.BalloonType = ThoughtBalloonTypes.kScreamBalloon;
                                            balloonData.mCoolDown = ThoughtBalloonCooldown.None;
                                            sim.ThoughtBalloonManager.ShowBalloon(balloonData);
                                        }
                                    }

                                    moves.SetMax(CommodityKind.Bladder);

                                    if (!simd.IsPet)
                                    {
                                        PuddleManager.AddPuddle(sim.Position);
                                        moves.SetValue(CommodityKind.Hygiene, -100f);
                                        if (GlobalFunctions.AreOtherSimsNearby(sim, BuffEmbarrassed.DistanceForEmbarrassedBuff))
                                        {
                                            buffManager.AddElement(BuffNames.Embarrassed, Origin.FromPeeingSelf);
                                        }
                                        ActiveTopic.AddToSim(sim, "Embarrassment");
                                    }
                                    else
                                    {
                                        MetaAutonomyVenueType metaAutonomyVenueType = sim.LotCurrent.GetMetaAutonomyVenueType();
                                        if ((!simd.IsADogSpecies || metaAutonomyVenueType != MetaAutonomyVenueType.DogPark) && World.GetTerrainType(sim.Position) == TerrainType.LotFloor)
                                        {
                                            PuddleManager.AddPuddle(sim.Position);
                                        }
                                    }
                                    EventTracker.SendEvent(EventTypeId.kBladderFailure, sim);
                                }
                                Motive motive = moves.GetMotive(CommodityKind.Bladder);
                                if (motive != null)
                                {
                                    motive.PotionBladderDecayOverride = false;
                                }
                            }
                            else
                            {
                                swimmingInPool.ContainerPool.PeeInPool(sim);
                            }
                        }
                        break;
                    }
                case CommodityKind.Hunger:
                case CommodityKind.VampireThirst:

                    if (simd.IsFrankenstein)
                    {
                        OccultFrankenstein.PushFrankensteinShortOut(sim);
                    }
                    else if (!simd.IsGhost && !simd.IsDead && !IsCheckKillSimInteraction(sim))
                    {
                        if (sim.Posture.Satisfies(CommodityKind.ScubaDiving, null) && !simd.IsMermaid)
                        {
                            sim.Kill(SimDescription.DeathType.ScubaDrown);
                        }
                        else if (sim.Posture.Satisfies(CommodityKind.SwimmingInPool, null) && !simd.IsMermaid)
                        {
                            sim.Kill(SimDescription.DeathType.Drown);
                        }
                        else if (SimTemperature.HasFrozenSolidInteraction(sim))
                        {
                            sim.Kill(SimDescription.DeathType.Freeze, null, false);
                        }
                        else if (OccultMermaid.IsDehydrated(sim))
                        {
                            sim.Kill(SimDescription.DeathType.MermaidDehydrated, null, false);
                        }
                        else
                        {
                            sim.Kill(sim.SimDescription.IsVampire ? SimDescription.DeathType.Thirst : SimDescription.DeathType.Starve);
                        }
                    }
                    break;
                case CommodityKind.Temperature:
                    {
                        float value = moves.GetValue(CommodityKind.Temperature);
                        if (value > 0f)
                        {
                            SimTemperature.PushSpontaneouslyCombustInteraction(sim);
                        }
                        else
                        {
                            SimTemperature.PushFreezeInteraction(sim);
                        }
                        break;
                    }
                case CommodityKind.MermaidDermalHydration:
                    OccultMermaid.CollapseFromDehydration(sim);
                    break;
            }
        }
    }

    public class NInteractionObjectPair : Sims3.Gameplay.Autonomy.InteractionObjectPair
    {
        private static object OV = null;

        public static void InitNCreate()
        {
            if ((OV as NInteractionObjectPair) != null)
                return;

            OV = new NInteractionObjectPair();
        }

        public static NInteractionObjectPair GetStatic()
        {
            InitNCreate();
            return (NInteractionObjectPair)OV;
        }

        public static void InitClass()
        {
            var p = GetStatic();
            p.NAddInteractions(null, null);
        }

        public void NAddInteractions(IActor s, List<InteractionObjectPair> results)
        {
            var p = mInteraction;
            if (p == null)
                return;

            try
            {
                p.AddInteractions(this, s, results);
            }
            catch (Exception)
            {}
           
        }
    }
}
