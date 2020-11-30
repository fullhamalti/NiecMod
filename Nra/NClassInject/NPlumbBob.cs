using System;
using System.Collections.Generic;
using System.Text;
using Sims3.SimIFace;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.CelebritySystem;
using Sims3.Gameplay.UI;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Situations;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.PetSystems;
using Sims3.Gameplay.NiecRoot;

namespace NiecMod.Nra
{
    public class NPlumbBob
    {
        [PersistableStatic]
        public static Household sCurrentNonNullHousehold;

        [PersistableStatic]
        public static Sim sCurrentSim;

        [PersistableStatic]
        public static Sim sCurrentSimTwo;

        public static bool DoneInitClass = false;

        public static void InitClass()
        {
            if (DoneInitClass)
                return;

            DoneInitClass = true;

            LoadSaveManager.ObjectGroupSaving += OnSavingGame;

            //World.OnObjectPendingDestructionEventHandler -= PlumbBob.OnObjectPendingDestruction;
            //World.OnObjectPendingDestructionEventHandler += OnObjectPendingDestruction;
        }

        public static void _OnObjectPendingDestruction(object sender, EventArgs e)
        {
            if (sender == null)
                return;

            if (sCurrentSimTwo != null && (sCurrentSimTwo.ObjectId.mValue == 0 || !NFinalizeDeath.GameObjectIsValid(sCurrentSimTwo.ObjectId.mValue)))
            {
                sCurrentSimTwo = null;
            }

            World.OnObjectPendingDestructionEventArgs onObjectPendingDestructionEventArgs = e as World.OnObjectPendingDestructionEventArgs;
            if (onObjectPendingDestructionEventArgs == null || sCurrentSim == null || !(onObjectPendingDestructionEventArgs.ObjectId == sCurrentSim.ObjectId))
                return;

            LotManager.SelectNextSim();

            if (sCurrentSim == null || !(onObjectPendingDestructionEventArgs.ObjectId == sCurrentSim.ObjectId))
                return;

            bool y = false;

            if (!PlumbBob.DoSelectActor(null, true))
            {
                var p = sCurrentSimTwo;
                sCurrentSimTwo = null;
                y = PlumbBob.DoSelectActor(p, true);
            }

            if (!y)
            {
                sCurrentSim = null;
                if (PlumbBob.sSingleton != null)
                {
                    PlumbBob.sSingleton.mSelectedActor = null;
                }
            }
        }

        private static void OnSavingGame(IScriptObjectGroup group)
        {
            PlumbBob.sCurrentNonNullHousehold = null;
            if (sCurrentSim != null)
            {
                PlumbBob.sCurrentNonNullHousehold = sCurrentSim.Household;
                sCurrentNonNullHousehold = sCurrentSim.Household;
            }

            PlumbBob splumbBob = PlumbBob.sSingleton;
            if (splumbBob != null)
            {
                if (NFinalizeDeath.World_IsEditInGameFromWBModeImpl())
                {
                    splumbBob.mSelectedActor = null;
                }
                else
                {
                    splumbBob.mSelectedActor = sCurrentSim;
                }
            }
        }

        public static bool ShouldCheckTwoPlayer()
        {
            return sCurrentSimTwo != null;
        }


        public static bool SetActiveActor(Sim actor, bool force)
        {
            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            if (ShouldCheckTwoPlayer())
                return false;

            if (!force && actor != null && !actor.IsSelectable)
            {
                return false;
            }

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Sims3.Gameplay.GameStates.IsGameShuttingDown && !force && actor == null)
                {
                    return false;
                }
            }

            try
            {
                throw new Exception("DEBUG SetActiveActor(Sim actor, bool force): " + (Type.GetType("Sims3.Gameplay.Core.PlumbBob") != null));
            }
            catch (Exception ex)
            {
                NiecException.SendTextExceptionToDebugger(ex);
            }

            try
            {
                Sim sim = sCurrentSim;
                if (sim != null && sim.Inventory != null)
                {
                    sim.Inventory.MuteMP3();
                }

                if (actor != null && actor.Inventory != null)
                {
                    actor.Inventory.UnmuteMP3();
                }

                if (actor != null)
                {
                    if (actor.Household != Household.ActiveHousehold)
                    {
                        actor.Household.MarkSimsAsProtected();
                    }

                    PlumbBob splumbBob = PlumbBob.sSingleton;
                    if (splumbBob != null)
                    {
                        if (NFinalizeDeath.World_IsEditInGameFromWBModeImpl())
                            splumbBob.mSelectedActor = null;
                        else
                            splumbBob.mSelectedActor = actor;
                    }

                    sCurrentSim = actor;

                    bool okParentTo = false;
                    if (actor.InWorld)
                    {
                        okParentTo = splumbBob != null && PlumbBob.ParentTo(actor);
                        if (sim != actor)
                        {
                            if (actor.BuffManager != null)
                            {
                                BuffMummysCurse.BuffInstanceMummysCurse buffInstanceMummysCurse = actor.BuffManager.GetElement(BuffNames.MummysCurse) as BuffMummysCurse.BuffInstanceMummysCurse;
                                if (buffInstanceMummysCurse != null)
                                {
                                    BuffMummysCurse.SetCursedScreenFX(buffInstanceMummysCurse.CurseStage, false);
                                }
                                else
                                {
                                    BuffMummysCurse.SetCursedScreenFX(0, false);
                                }
                            }

                            if (actor.Household != null)
                            {
                                foreach (Sim itemSim in actor.Household.Sims)
                                {
                                    if (itemSim == null)
                                        continue;

                                    Conversation conversation = itemSim.Conversation;
                                    if (conversation != null)
                                    {
                                        foreach (Sim member in conversation.Members)
                                        {
                                            if (member == null)
                                                continue;

                                            if (member != actor && member.ProgressMeter is CelebrityImpressProgressMeter)
                                            {
                                                ProgressMeter.HideProgressMeter(member, false);
                                            }
                                        }
                                    }
                                }
                            }

                            if (actor.InteractionQueue != null)
                            {
                                InteractionInstance currentInteraction = actor.InteractionQueue.GetCurrentInteraction();
                                if (currentInteraction is ICelebrityImpressInteraction)
                                {
                                    CelebrityManager.ShowImpressProgressMeterIfNecessary(actor, currentInteraction.Target as Sim);
                                }
                            }
                        }
                    }

                    if (splumbBob != null)
                    {
                        if (okParentTo)
                        {
                            World.AddObjectToScene(splumbBob.ObjectId);
                            PlumbBob.ShowPlumbBob();
                        }
                        else
                        {
                            PlumbBob.HidePlumbBob();
                        }
                    }

                    World.SetWallCutawayFocusPos(actor.Position);
                    PlumbBob.CheckForChangeInActiveHousehold(actor.Household, force);
                    PieMenu.ClearInteractions();

                    EventTracker.SendEvent(EventTypeId.kEventSimSelected, actor, sim);
                }
                else
                {
                    PlumbBob splumbBob = PlumbBob.sSingleton;
                    if (splumbBob != null)
                    {
                        splumbBob.mSelectedActor = null;
                    }

                    sCurrentSim = null;

                    if (splumbBob != null)
                    {
                        PlumbBob.HidePlumbBob();

                        Slots.DetachFromSlot(splumbBob.ObjectId);

                        if (splumbBob.LotCurrent != null)
                        {
                            splumbBob.LotCurrent.RemoveObjectFromLot(splumbBob.ObjectId, false);
                        }
                    }

                    PlumbBob.CheckForChangeInActiveHousehold(null, force);

                    PieMenu.ClearInteractions();

                    EventTracker.SendEvent(EventTypeId.kEventSimSelected, null, sim);
                }

                if (sim != actor && actor != null && actor.MoodManager != null)
                {
                    actor.MoodManager.UpdatePlumbbobColor();
                }
            }
            catch (Exception ex) // Should EA debug?
            {
                niec_native_func.OutputDebugString("SetActiveActor(Sim actor, bool force) failed.");
                if (actor != null)
                {
                    var simDescription = actor.SimDescription;
                    if (simDescription != null)
                    {
                        niec_native_func.OutputDebugString("Sim Name: " + simDescription.FullName);
                        niec_native_func.OutputDebugString("Sim ID: " + simDescription.SimDescriptionId.ToString("X"));
                    }
                }
                NiecException.SendTextExceptionToDebugger(ex);
                return false;
            }
            return true;
        }

        public static void CheckChangeInActiveHousehold(Household newHousehold, bool bForce)
        {
            if (newHousehold == null)
            {
                return;
            }

            if (sCurrentNonNullHousehold == null)
            {
                sCurrentNonNullHousehold = PlumbBob.sCurrentNonNullHousehold;
                PlumbBob.sCurrentNonNullHousehold = null;
            }

            try
            {
                if (sCurrentNonNullHousehold != newHousehold || bForce)
                {
                    Lot lot = null;
                    if (sCurrentNonNullHousehold != null)
                    {
                        lot = sCurrentNonNullHousehold.LotHome;
                    }
                    if (sCurrentNonNullHousehold != null && sCurrentNonNullHousehold != newHousehold)
                    {
                        Situation.OnActiveHouseholdChanged(sCurrentNonNullHousehold, newHousehold);

                        if (!NiecHelperSituation.__acorewIsnstalled__)
                            Party.CancelAllHouseParties(sCurrentNonNullHousehold.LotHome);

                        //sCurrentNonNullHousehold.ResetSocialWorkerTrigger();

                        foreach (Sim allActor in sCurrentNonNullHousehold.AllActors)
                        {
                            try
                            {
                                allActor.OnBecameUnselectable();
                            }
                            catch (Exception)
                            { if (!NiecHelperSituation.__acorewIsnstalled__) throw; }
                           
                        }
                        if (lot != null)
                        {
                            lot.OnBecameUnselected();
                        }
                        sCurrentNonNullHousehold.ResetParentVacationsTrigger();
                    }
                    if (newHousehold != null)
                    {
                        foreach (Sim actor in newHousehold.AllActors)
                        {
                            if (!Household.RoommateManager.IsNPCRoommate(actor))
                            {
                                try
                                {
                                    actor.OnBecameSelectable();
                                }
                                catch (Exception)
                                { if (!NiecHelperSituation.__acorewIsnstalled__) throw; }

                            }
                        }
                        if (sCurrentNonNullHousehold != newHousehold)
                        {
                            if (lot != null)
                            {
                                //lot.TryTurnOffHolidayHouseLights();
                            }
                            newHousehold.GiveIngredients();
                        }
                        if (newHousehold.LotHome != null)
                        {
                            newHousehold.LotHome.OnBecameSelected();
                        }

                        Lot.UpdatePlayerNeighbors();

                        TombRoomManager.OnChangeHousehold(newHousehold);

                        try
                        {
                            if (sCurrentNonNullHousehold != newHousehold)
                            {
                                newHousehold.SetParentFreeVacationTrigger(false, false);
                            }
                        }
                        catch (Exception)
                        { if (!NiecHelperSituation.__acorewIsnstalled__) throw; }
                        
                    }
                    EventTracker.SendEvent(new HouseholdUpdateEvent(EventTypeId.kHouseholdSelected, newHousehold));
                }
                sCurrentNonNullHousehold = newHousehold;
                PlumbBob.sCurrentNonNullHousehold = newHousehold;
            }
            catch (Exception ex)
            {
                niec_native_func.OutputDebugString("CheckChangeInActiveHousehold(Household newHousehold, bool bForce) failed.");
                NiecException.SendTextExceptionToDebugger(ex);
            }
        }

        public static Sim ActiveActor
        {
            get
            {
                if (NiecHelperSituation.__acorewIsnstalled__)
                {
                    if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                    {
                        NFinalizeDeath.RUNIACORE(false);
                    }
                    else NFinalizeDeath.CheckNHSP();
                }

                if (sCurrentSimTwo != null)
                    return sCurrentSimTwo;
                if (sCurrentSim != null)
                    return sCurrentSim;

                PlumbBob splumbBob = PlumbBob.sSingleton;
                if (splumbBob != null)
                    return splumbBob.mSelectedActor;

                return null;
            }
        }
    }
}
