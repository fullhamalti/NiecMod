using System;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Services;
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
using Sims3.Gameplay.CelebritySystem;
using Sims3.UI.CAS;
using Sims3.UI.Controller;

namespace NiecMod.Nra
{
    [Persistable]
    public class NPCSimCanDisgraced // if not AweCore or OpenDGS
    {

        public static List<NPCSimCanDisgraced> NPCSimCanDisgracedList = new List<NPCSimCanDisgraced>();

        public CelebrityManager CelebrityManager_ = null;

        public void Dispose() {
            CelebrityManager_ = null;
        }

        public NPCSimCanDisgraced(CelebrityManager celebrityManager) {
            //NPCSimCanDisgracedList.Add(this);
            CelebrityManager_ = celebrityManager;
        }

        public void StartNPCSimCanDisgraced() {
            FalselyAccuseCheck(CelebrityManager_);
        }

        public static bool CantBeDisgraced(CelebrityManager This)
        {
            if (This.Level >= 1)
            {
                if (This.mClearNameCooldown > 0f)
                {
                    return SimClock.ElapsedTime(TimeUnit.Minutes) - This.mClearNameCooldown < CelebrityManager.kCooldownAfterClearingName;
                }
                return false;
            }
            return true;
        }


        public static ListenerAction OnFindSimCommittedDisgracefulAction(Event e) {

            if (CelebrityUtil.sCelebrityDisgracefulActionData == null) // EA Fail if not EP Installed.
                return ListenerAction.Keep;

            try
            {
                DisgracefulActionEvent disgracefulActionEvent = e as DisgracefulActionEvent;
                if (disgracefulActionEvent == null)
                    return ListenerAction.Keep;

                Sim sim = disgracefulActionEvent.Actor as Sim;
                if (sim == null)
                    return ListenerAction.Keep;

                SimDescription findsim = sim.SimDescription;

                if (findsim == null)
                    return ListenerAction.Keep;

                if (findsim == null || !findsim.IsValid || !findsim.IsValidDescription || !findsim.IsCelebrity)
                    return ListenerAction.Keep;

                Household household = findsim.Household;
                if (household != null && household == Household.ActiveHousehold)
                    return ListenerAction.Keep;

                CelebrityManager celma = findsim.CelebrityManager;
                if (celma == null || CantBeDisgraced(celma))
                    return ListenerAction.Keep;




                //SimDescription simDescription = sim.SimDescription;
                
                DisgracefulActionType disgracefulActionType = disgracefulActionEvent.DisgracefulActionType;
                CelebrityDisgracefulActionStaticData value;

                if (!CelebrityUtil.sCelebrityDisgracefulActionData.TryGetValue(disgracefulActionType, out value))
                    return ListenerAction.Keep;

                if (celma.mDisgracefulActionQueue != null)
                {
                    foreach (DisgracefulActionEvent item in celma.mDisgracefulActionQueue)
                    {
                        if (item.TargetId == disgracefulActionEvent.TargetId && item.DisgracefulActionType == disgracefulActionEvent.DisgracefulActionType)
                        {
                            return ListenerAction.Keep;
                        }
                    }
                }

                if (RandomUtil.RandomChance01(value.Chance) || RandomUtil.RandomChance01(65))
                {
                    if (celma.mDisgracefulActionQueue == null)
                    {
                        celma.mDisgracefulActionQueue = new List<DisgracefulActionEvent>();
                    }

                    celma.mDisgracefulActionQueue.Add(disgracefulActionEvent);

                    sim.AddAlarm(30, TimeUnit.Minutes, delegate
                    {
                        try
                        {
                             STriggerDisgrace(celma);
                        }
                        catch (ResetException)
                        { throw; }
                        catch { }
                    },
                    null, AlarmType.NeverPersisted);
                }
            }
            //catch (ResetException){ throw; }
            catch { }
            return ListenerAction.Keep;
        }




        public ListenerAction OnSimCommittedDisgracefulAction(Event e)
        {
            if (CelebrityUtil.sCelebrityDisgracefulActionData == null) // EA Fail if not Installed.
                return ListenerAction.Remove; 
            
            if (CelebrityManager_ == null) 
                return ListenerAction.Remove;

            if (CantBeDisgraced(CelebrityManager_))
            {
                return ListenerAction.Keep;
            }

            DisgracefulActionEvent disgracefulActionEvent = e as DisgracefulActionEvent;
            if (disgracefulActionEvent == null)
            {
                return ListenerAction.Keep;
            }
            Sim sim = disgracefulActionEvent.Actor as Sim;
            if (sim == null)
            {
                return ListenerAction.Keep;
            }
            SimDescription simDescription = sim.SimDescription;
            if (simDescription == null || !simDescription.IsValid || !simDescription.IsValidDescription)
            {
                return ListenerAction.Keep;
            }
            DisgracefulActionType disgracefulActionType = disgracefulActionEvent.DisgracefulActionType;
            CelebrityDisgracefulActionStaticData value;
            if (!CelebrityUtil.sCelebrityDisgracefulActionData.TryGetValue(disgracefulActionType, out value))
            {
                return ListenerAction.Keep;
            }
            if (CelebrityManager_.mDisgracefulActionQueue != null)
            {
                foreach (DisgracefulActionEvent item in CelebrityManager_.mDisgracefulActionQueue)
                {
                    if (item.TargetId == disgracefulActionEvent.TargetId && item.DisgracefulActionType == disgracefulActionEvent.DisgracefulActionType)
                    {
                        return ListenerAction.Keep;
                    }
                }
            }
           
            if (RandomUtil.RandomChance01(value.Chance))
            {
                if (CelebrityManager_.mDisgracefulActionQueue == null)
                {
                    CelebrityManager_.mDisgracefulActionQueue = new List<DisgracefulActionEvent>();
                }
                CelebrityManager_.mDisgracefulActionQueue.Add(disgracefulActionEvent);
                sim.AddAlarm(CelebrityManager.kDelayBeforeDisgracefulActionIsKnown, TimeUnit.Minutes, TriggerDisgrace, "CelebrityManager: Disgrace delay alarm", AlarmType.AlwaysPersisted);
            }
            return ListenerAction.Keep;
        }




        public static void STriggerDisgrace(CelebrityManager This)
        {
            // Test New 96?

            //CelebrityManager This = CelebrityManager_;

            Sim ownerSim = This.OwnerSim;
            BuffManager buffManager = This.OwnerSim.BuffManager;
            if (This.mDisgracefulActionQueue != null && This.mDisgracefulActionQueue.Count != 0)
            {
                DisgracefulActionEvent disgracefulActionEvent = This.mDisgracefulActionQueue[0];
                DisgracefulActionType disgracefulActionType = disgracefulActionEvent.DisgracefulActionType;

                This.mDisgracefulActionQueue.Remove(disgracefulActionEvent);
                CelebrityDisgracefulActionStaticData value;

                if (!CantBeDisgraced(This) && CelebrityUtil.sCelebrityDisgracefulActionData.TryGetValue(disgracefulActionType, out value) /* || !(Sims3.Gameplay.Moded.DGSHelperCommands.kNoDisgracedInIsPlayer && (ownerSim.IsInActiveHousehold || ownerSim.IsSafeInActiveHousehold)) */)
                {
                    buffManager.RemoveElement(BuffNames.PubliclyDisgraced);
                    SimDescription simDescription = disgracefulActionEvent.TargetId == 0 ? null : SimDescription.Find(disgracefulActionEvent.TargetId);
                    bool flag = disgracefulActionType == DisgracefulActionType.Cheating && !ownerSim.HasTrait(TraitNames.NoJealousy);
                    foreach (Relationship relationship in ownerSim.SocialComponent.Relationships)
                    {
                        if (relationship.SimDescriptionB != simDescription)
                        {
                            if (flag && relationship.AreRomantic())
                            {
                                Sim createdSim = relationship.SimDescriptionB.CreatedSim;
                                if (createdSim != null)
                                {
                                    SocialComponent.OnIWasCheatedOn(createdSim, ownerSim.SimDescription, simDescription, JealousyLevel.Medium);
                                }
                            }
                            relationship.LTR.UpdateLiking(0f - CelebrityManager.kLTRLostFromDisgrace);
                        }
                    }

                    if (value != null)
                        buffManager.AddElement(BuffNames.PubliclyDisgraced, value.DisgracedOrigin);
                    else
                    {
                        buffManager.AddElement(BuffNames.PubliclyDisgraced, Origin.FromFalselyAccused);
                    }

                    if (value != null && value.DisgracedOrigin == Origin.FromFalselyAccused)
                    {
                        ownerSim.CelebrityManager.IncrementFalselyAccused();
                    }
                    else
                    {
                        ownerSim.CelebrityManager.IncrementPubliclyDisgraced();
                    }
                    if (value != null)
                    {
                        ownerSim.ShowTNSAndPlayStingIfSelectable("sting_generic_tragic", value.TnsId, null, ownerSim, null, null, new bool[1]
					    {
						    ownerSim.IsFemale
					    }, ownerSim.IsFemale, ownerSim);
                    }
                }
            }
        }


        public void TriggerDisgrace()
        {
            // Test New 96?

            CelebrityManager This = CelebrityManager_;

            Sim ownerSim = This.OwnerSim;
            BuffManager buffManager = This.OwnerSim.BuffManager;
            if (This.mDisgracefulActionQueue != null && This.mDisgracefulActionQueue.Count != 0)
            {
                DisgracefulActionEvent disgracefulActionEvent = This.mDisgracefulActionQueue[0];
                DisgracefulActionType disgracefulActionType = disgracefulActionEvent.DisgracefulActionType;
                This.mDisgracefulActionQueue.Remove(disgracefulActionEvent);
                CelebrityDisgracefulActionStaticData value = null;
                if (!CantBeDisgraced(This) && CelebrityUtil.sCelebrityDisgracefulActionData.TryGetValue(disgracefulActionType, out value) /* || !(Sims3.Gameplay.Moded.DGSHelperCommands.kNoDisgracedInIsPlayer && (ownerSim.IsInActiveHousehold || ownerSim.IsSafeInActiveHousehold)) */)
                {
                    buffManager.RemoveElement(BuffNames.PubliclyDisgraced);
                    SimDescription simDescription = SimDescription.Find(disgracefulActionEvent.TargetId);
                    bool flag = disgracefulActionType == DisgracefulActionType.Cheating && !ownerSim.HasTrait(TraitNames.NoJealousy);
                    foreach (Relationship relationship in ownerSim.SocialComponent.Relationships)
                    {
                        if (relationship.SimDescriptionB != simDescription)
                        {
                            if (flag && relationship.AreRomantic())
                            {
                                Sim createdSim = relationship.SimDescriptionB.CreatedSim;
                                if (createdSim != null)
                                {
                                    SocialComponent.OnIWasCheatedOn(createdSim, ownerSim.SimDescription, simDescription, JealousyLevel.Medium);
                                }
                            }
                            relationship.LTR.UpdateLiking(0f - CelebrityManager.kLTRLostFromDisgrace);
                        }
                    }
                    if (value != null)
                        buffManager.AddElement(BuffNames.PubliclyDisgraced, value.DisgracedOrigin);
                    else
                    {
                        buffManager.AddElement(BuffNames.PubliclyDisgraced, Origin.FromFalselyAccused);
                    }
                    if (value != null && value.DisgracedOrigin == Origin.FromFalselyAccused)
                    {
                        ownerSim.CelebrityManager.IncrementFalselyAccused();
                    }
                    else
                    {
                        ownerSim.CelebrityManager.IncrementPubliclyDisgraced();
                    }
                    if (value != null)
                    {
                        ownerSim.ShowTNSAndPlayStingIfSelectable("sting_generic_tragic", value.TnsId, null, ownerSim, null, null, new bool[1]
					    {
						    ownerSim.IsFemale
					    }, ownerSim.IsFemale, ownerSim);
                    }
                }
            }
        }





        public static void FalselyAccuseCheck(CelebrityManager This)
        {
            if (This.OwnerSim != null && !CantBeDisgraced(This) && !This.OwnerSim.IsSelectable)
            {
                Sim ownerSim = This.OwnerSim;
                if (This.Owner == null)
                    return;
                float num = 0f;
                
                List<IMiniRelationship> miniRelationships = Relationship.GetMiniRelationships(This.Owner);
                foreach (IMiniRelationship item in miniRelationships)
                {
                    switch (item.CurrentLTR)
                    {
                        case LongTermRelationshipTypes.Enemy:
                        case LongTermRelationshipTypes.OldEnemies:
                            num += 1f;
                            break;
                    }
                }
                float val = CelebrityManager.kBaseAccusationChance[This.Level - 1] + num * CelebrityManager.kPerEnemyAccusationChance[This.Level - 1];
                if (RandomUtil.RandomChance01(Math.Min(val, CelebrityManager.kMaxAccusationChance[This.Level - 1])))
                {
                    ownerSim.AddAlarm(RandomUtil.GetFloat(CelebrityManager.kFalselyAccuseMinDelay, CelebrityManager.kFalselyAccuseMaxDelay), TimeUnit.Minutes, This.TriggerFalseAccusation, "CelebrityManager: False Accusation delay alarm", AlarmType.AlwaysPersisted);
                }
            }
        }
    }
}
