/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 27/09/2018
 * Time: 4:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

using NiecMod.Nra;
using NiecMod.KillNiec;


using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.DreamsAndPromises;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.Pools;
using Sims3.Gameplay.Scuba;
using Sims3.Gameplay.Services;
using Sims3.Gameplay.Situations;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Tutorial;
using Sims3.Gameplay.Utilities;

using Sims3.SimIFace;
using Sims3.SimIFace.CAS;

using Sims3.UI;
using Sims3.Gameplay.Seasons;
using Sims3.Gameplay.Controllers.Niec;
using Sims3.Gameplay.Careers;
using Sims3.Gameplay.ThoughtBalloons;
using Sims3.UI.GameEntry;
using NiecMod.Helpers;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay.NiecRoot;



namespace NiecMod.Interactions
{
    /// <summary>
    /// Fix no Exit ExtKillSimNiec to Focre Kill NPC ONLY
    /// KillSim Is Helper By Niec
    /// Support Killing Baby The Sims 3 is Modified Support Killing Babies By Niec
    /// </summary>
    public sealed class ExtKillSimNiec : Interaction<Sim, Sim>, IRouteFromInventoryOrSelfWithoutCarrying, IInteractionDoesntAllowReactions
    {
        //[Persistable] // Test?
        public Household homehome = null;
        public bool stemprun = false;
        public bool stemprun_ = false;


        public override void ConfigureInteraction()
        {
            onRuntimeThisRun = false;
        }

        public AlarmHandle loadalarm = AlarmHandle.kInvalidHandle; 


       
        public override bool Run()
        {
            onRuntimeThisRun = true;
            NFinalizeDeath.CheckYieldingContext();
            Simulator.Sleep(0);

            try
            {
               


                SimDescription simDescription = Actor.SimDescription;
                
                SimDescription.DeathType deathStyle = Actor.SimDescription.DeathStyle;
                if (this.simDeathType == SimDescription.DeathType.None) // Fix Error
                {
                    this.CancelDeath = false;
                    this.DeathTypeFix = false;
                    this.FixNotExit = false;
                    this.ActiveFix = false;
                    Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    return false;
                }
                if (Actor.Service != null && Actor.Service is GrimReaper && !mForceKillGrim)
                {
                    Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    this.Actor.Motives.MaxEverything();
                    Actor.BuffManager.RemoveAllElements();
                    Actor.FadeIn();
                    this.CancelDeath = false;
                    this.DeathTypeFix = false;
                    this.FixNotExit = false;
                    this.ActiveFix = false;
                    return false;
                }
                try
                {
                    CheckCancelListInteractionByNiec(Actor);
                }
                catch (Exception)
                {
                    try
                    {
                        CheckCancelListInteractionByNiec(Actor);
                    }
                    catch (Exception)
                    { }
                }

                try
                {
                    if (Actor.Household == null && homehome != null)
                    {
                        //homehome.Add(Actor.SimDescription);
                        NFinalizeDeath.Household_Add(homehome, Actor.SimDescription, false);
                    }
                }
                catch (NullReferenceException)
                { }

                // I Know Loaded Save Fix None to Ghost Running TimePortal 
                try
                {
                    if ( /* Actor.SimDescription.DeathStyle != SimDescription.DeathType.None && */ Actor.SimDescription.IsGhost || Actor.SimDescription.IsDead)
                    {
                        SimDescription simDescriptiongot = Actor.SimDescription;
                        simDescriptiongot.IsGhost = false;
                        World.ObjectSetGhostState(Actor.ObjectId, 0u, (uint)simDescriptiongot.AgeGenderSpecies);
                        Actor.Autonomy.Motives.RemoveMotive(CommodityKind.BeGhostly);
                        simDescriptiongot.SetDeathStyle(SimDescription.DeathType.None, false);
                        simDescriptiongot.ShowSocialsOnSim = true;
                        simDescriptiongot.IsNeverSelectable = false;
                        Actor.Autonomy.AllowedToRunMetaAutonomy = true;
                    }
                }
                catch
                { }

                try
                {
                    StartDeathEffect();
                }
                catch (Exception exception)
                {
                    NiecException.WriteLog("StartDeathEffect " + NiecException.NewLine + NiecException.LogException(exception), true, true, false);
                }

                if (!NFinalizeDeath.OpenDGS_GetOrSet_ForceWorldLotFromGrimReaper) {

                if (Actor.LotCurrent.IsWorldLot) // Tested
                {
                    bool successFail = false;
                    // Fix NullReferenceException
                    NiecMod.Nra.SpeedTrap.Sleep(3);
                    if (PlumbBob.sSingleton == null)
                    {
                        GlobalFunctions.CreateObjectOutOfWorld("PlumbBob");
                    }
                    if ( /*Sim.ActiveActor == null || */ PlumbBob.sSingleton.mSelectedActor == null)
                    {
                        if (NTunable.kCreatesSim && !Create.RandomActiveHouseholdAndActiveActor() || Create.CreateActiveHouseholdAndActiveActor(null, false) == null) 
                            return false;
                    }

                    if (PlumbBob.Singleton.mSelectedActor.LotHome == null)
                    {
                        try
                        {
                            List<Lot> lieast = new List<Lot>();
                            Lot lot = null;
                            foreach (object obj in LotManager.AllLotsWithoutCommonExceptions)
                            {
                                Lot lot2 = (Lot)obj;
                                lieast.Add(lot2);
                            }
                            try
                            {
                                Lot virtualLotHome = PlumbBob.Singleton.mSelectedActor.Household.VirtualLotHome;
                                if (virtualLotHome != null)
                                {
                                    virtualLotHome.VirtualMoveOut(PlumbBob.Singleton.mSelectedActor.Household);
                                }
                            }
                            catch
                            { }
                            
                            lot = RandomUtil.GetRandomObjectFromList<Lot>(lieast);
                            lot.MoveIn(PlumbBob.Singleton.mSelectedActor.Household);

                        }
                        catch
                        { }
                    }
                    // ActiveHousehold LotHome
                    try
                    {
                        var terraininstance = new Terrain.TeleportMeHere.Definition(false).CreateInstance(Terrain.Singleton, this.Actor, base.GetPriority(), base.Autonomous, base.CancellableByPlayer) as TerrainInteraction;
                        if (terraininstance != null)
                        {
                            Sim activeHouseholdselectedActor = PlumbBob.Singleton.mSelectedActor;
                            if (activeHouseholdselectedActor != null)
                            {
                                Mailbox mailboxOnHomeLot = Mailbox.GetMailboxOnHomeLot(activeHouseholdselectedActor);
                                if (mailboxOnHomeLot != null)
                                {
                                    Vector3 vector2;
                                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(mailboxOnHomeLot.Position);
                                    fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                                    fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0x7);
                                    if (GlobalFunctions.FindGoodLocation(Actor, fglParams, out terraininstance.Destination, out vector2))
                                    {
                                        successFail = terraininstance.RunInteraction();
                                    }
                                    else
                                    {
                                        terraininstance.Destination = mailboxOnHomeLot.Position;
                                        successFail = terraininstance.RunInteraction();
                                    }
                                }
                                else
                                {
                                    Vector3 vector2;
                                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(PlumbBob.SelectedActor.LotHome.Position);
                                    fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                                    fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0x7);
                                    if (GlobalFunctions.FindGoodLocation(Actor, fglParams, out terraininstance.Destination, out vector2))
                                    {
                                        successFail = terraininstance.RunInteraction();
                                    }
                                    else
                                    {
                                        terraininstance.Destination = PlumbBob.Singleton.mSelectedActor.LotHome.Position;
                                        successFail = terraininstance.RunInteraction();
                                    }
                                }
                            }
                        }
                    }
                    catch (NullReferenceException)
                    { }
                    


                    // ActiveHousehold
                    try
                    {
                        if (!successFail && Actor.IsInActiveHousehold)
                        {
                            bool successFailx = false;
                            var viasitLot = VisitLot.Singleton.CreateInstance(Household.ActiveHousehold.LotHome, this.Actor, base.GetPriority(), base.Autonomous, false) as VisitLot;
                            if (!viasitLot.RunInteraction())
                            {
                                //StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " Test? Cancel? :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                if (!Actor.SimDescription.IsEP11Bot)
                                {
                                    if (Actor.SimDescription.Elder)
                                    {
                                        Actor.SimDescription.AgingState.ResetAndExtendAgingStage(0f);
                                    }
                                }
                                this.DeathTypeFix = false;
                                this.FixNotExit = false;
                                Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                                Actor.BuffManager.RemoveAllElements();
                                Actor.FadeIn();
                                this.Actor.Motives.MaxEverything();
                                return false;
                            }
                            successFailx = true;

                            // Part 2
                            if (!successFailx)
                            {
                                //StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " Test? Cancel? :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                var goToLoAtx = GoToLot.Singleton.CreateInstance(Household.ActiveHousehold.LotHome, this.Actor, base.GetPriority(), base.Autonomous, false) as GoToLot;
                                //goToLoAtx.RunInteraction();
                                if (!goToLoAtx.RunInteraction())
                                {
                                    if (!Actor.SimDescription.IsEP11Bot)
                                    {
                                        if (Actor.SimDescription.Elder)
                                        {
                                            Actor.SimDescription.AgingState.ResetAndExtendAgingStage(0f);
                                        }
                                    }
                                    this.DeathTypeFix = false;
                                    this.FixNotExit = false;
                                    Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                                    Actor.BuffManager.RemoveAllElements();
                                    Actor.FadeIn();
                                    this.Actor.Motives.MaxEverything();
                                    return false;
                                }
                            }
                        }
                        // End If ActiveHousehold





                        // NPC
                        if (!successFail && !Actor.IsInActiveHousehold)
                        {
                            bool successFailx = false;
                            var viasitLot = VisitLot.Singleton.CreateInstance(Household.ActiveHousehold.LotHome, this.Actor, base.GetPriority(), base.Autonomous, false) as VisitLot;

                            // Start
                            viasitLot.MustRun = true;
                            MustRun = true;
                            if (!viasitLot.RunInteraction())
                            {
                                this.FixNotExit = true;
                                this.Cleanup();
                                return true;

                                /*
                                this.CancelDeath = false;
                                this.DeathTypeFix = false;
                                this.FixNotExit = false;
                                this.ActiveFix = false;
                                try
                                {
                                    this.Actor.MoveInventoryItemsToAFamilyMember();
                                }
                                catch (Exception)
                                { }



                            
                                StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " is Cancel and Exit ExtKillSimNiec! to Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                // List Mod

                                try
                                {
                                    // Found System.NullReferenceException: A null value was found where an object instance was required. Fixed Bug No Household :) 

                                    if (Actor.SimDescription.Household != null)
                                    {
                                        ExtKillSimNiec.ListMorunExtKillSim(Actor, simDeathType);
                                    }
                                    NFinalizeDeath.FinalizeSimDeathRelationships(Actor.SimDescription, 0);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        Actor.SimDescription.ShowSocialsOnSim = false;
                                        Actor.SimDescription.IsNeverSelectable = true;
                                        Actor.SimDescription.Contactable = false;
                                    }
                                    catch (Exception)
                                    { }
                                    Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                                    return true;
                                }
                                finally
                                {
                                    try
                                    {
                                        Actor.SimDescription.ShowSocialsOnSim = false;
                                        Actor.SimDescription.IsNeverSelectable = true;
                                        Actor.SimDescription.Contactable = false;
                                    }
                                    catch (Exception)
                                    { }
                                    Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                                }
                                return true;
                                // End
                                 */
                            }
                            successFailx = true;




                            // Part 2
                            if (!successFailx)
                            {
                                var goToLoAtx = GoToLot.Singleton.CreateInstance(Household.ActiveHousehold.LotHome, this.Actor, base.GetPriority(), base.Autonomous, false) as GoToLot;
                                // Start

                                goToLoAtx.MustRun = true;
                                MustRun = true;
                                if (!NFinalizeDeath._RunInteraction(goToLoAtx))
                                {


                                    /*

                                    this.CancelDeath = false;
                                    this.DeathTypeFix = false;
                                    this.FixNotExit = false;
                                    this.ActiveFix = false;
                                    try
                                    {
                                        this.Actor.MoveInventoryItemsToAFamilyMember();
                                    }
                                    catch (Exception)
                                    { }

                                    StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " is Cancel and Exit ExtKillSimNiec! to Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                    // List Mod

                                    try
                                    {
                                        // Found System.NullReferenceException: A null value was found where an object instance was required. Fixed Bug No Household :) 

                                        if (Actor.SimDescription.Household != null)
                                        {
                                            ExtKillSimNiec.ListMorunExtKillSim(Actor, simDeathType);
                                        }
                                        NFinalizeDeath.FinalizeSimDeathRelationships(Actor.SimDescription, 0f);

                                    }
                                    catch (Exception)
                                    {
                                        try
                                        {
                                            Actor.SimDescription.ShowSocialsOnSim = false;
                                            Actor.SimDescription.IsNeverSelectable = true;
                                            Actor.SimDescription.Contactable = false;
                                        }
                                        catch (Exception)
                                        { }
                                        Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                                        return true;
                                    }
                                    finally
                                    {
                                        try
                                        {
                                            Actor.SimDescription.ShowSocialsOnSim = false;
                                            Actor.SimDescription.IsNeverSelectable = true;
                                            Actor.SimDescription.Contactable = false;
                                        }
                                        catch (Exception)
                                        { }
                                        Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                                    }
                                     */
                                    this.FixNotExit = true;
                                    this.Cleanup();
                                    return true;
                                }
                                // End
                            }
                        }
                    }
                    // End If NPCHousehold
                    catch (NullReferenceException)
                    { }
                    
                    
                }


                if (Actor.LotCurrent.IsWorldLot && !Actor.IsInActiveHousehold)
                {
                    this.CancelDeath = false;
                    this.DeathTypeFix = false;
                    this.FixNotExit = false;
                    this.ActiveFix = false;

                    try
                    {
                        this.Actor.MoveInventoryItemsToAFamilyMember();
                    }
                    catch (Exception)
                    { }

                    StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " is Cancel and Exit ExtKillSimNiec! to Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                    // List Mod

                    try
                    {
                        // Found System.NullReferenceException: A null value was found where an object instance was required. Fixed Bug No Household :) 

                        ExtKillSimNiec.ListMorunExtKillSim(Actor, simDeathType);
                        NFinalizeDeath.FinalizeSimDeathRelationships(Actor.SimDescription, 0f);

                    }
                    catch (Exception)
                    {
                        try
                        {
                            Actor.SimDescription.ShowSocialsOnSim = false;
                            Actor.SimDescription.IsNeverSelectable = true;
                            Actor.SimDescription.Contactable = false;
                        }
                        catch (Exception)
                        { }
                        SafeNRaas.NRUrnstones_CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                        return true;
                    }
                    finally
                    {
                        try
                        {
                            Actor.SimDescription.ShowSocialsOnSim = false;
                            Actor.SimDescription.IsNeverSelectable = true;
                            Actor.SimDescription.Contactable = false;
                        }
                        catch (Exception)
                        { }

                        SafeNRaas.NRUrnstones_CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                    }
                    return true;
                }

                } // if !AssemblyCheckByNiec.IsInstalled("OpenDGS")

                



                try
                {
                    CheckCancelListInteractionByNiec(Actor);
                }
                catch (Exception)
                {
                    try
                    {
                        CheckCancelListInteractionByNiec(Actor);
                    }
                    catch (Exception)
                    { }
                }
                if (Actor.Service != null && Actor.Service is GrimReaper && !mForceKillGrim)
                {
                    Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    this.Actor.Motives.MaxEverything();
                    Actor.BuffManager.RemoveAllElements();
                    Actor.FadeIn();
                    this.CancelDeath = false;
                    this.DeathTypeFix = false;
                    this.FixNotExit = false;
                    this.ActiveFix = false;
                    return false;
                }
                if (this.simDeathType == SimDescription.DeathType.None) // Fix Error
                {
                    this.CancelDeath = false;
                    this.DeathTypeFix = false;
                    this.FixNotExit = false;
                    this.ActiveFix = false;
                    Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    return false;
                }
                if (this.simDeathType == SimDescription.DeathType.PetOldAgeBad && !Actor.IsPet)
                {
                    this.CancelDeath = false;
                    this.DeathTypeFix = false;
                    this.FixNotExit = false;
                    this.ActiveFix = false;
                    Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    return false;
                }
                if (this.simDeathType == SimDescription.DeathType.PetOldAgeGood && !Actor.IsPet)
                {
                    this.CancelDeath = false;
                    this.DeathTypeFix = false;
                    this.FixNotExit = false;
                    this.ActiveFix = false;
                    Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    
                    return false;
                }
                //if ((Actor.IsInActiveHousehold || NFinalizeDeath.IsSimFastActiveHousehold(Actor)))
                if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                {
                    if (Simulator.CheckYieldingContext(false)) // Safe
                    {

                        ObjectGuid sma = Simulator.CurrentTask;
                        NiecTask.Perform(delegate {
                            for (int i = 0; i < 20; i++)
                            {
                                Simulator.Sleep(0);
                            }
                            if (Actor.Household == Household.ActiveHousehold && NFinalizeDeath.ActiveHouseCount2() != 1 && NFinalizeDeath.CheckAccept("Do you want Force Kill?\n(Yes Run or No Next)\nName: " + Actor.SimDescription.FullName) /* && Simulator.CheckYieldingContext(false) */)
                            {
                                try
                                {

                                    try
                                    {

                                        HelperNra helperNra = new HelperNra();

                                        //helperNra = HelperNra;

                                        helperNra.mSim = Actor;

                                        helperNra.mSimdesc = Actor.SimDescription;

                                        helperNra.mdeathtype = simDeathType;

                                        helperNra.this_alarm = AlarmManager.Global.AddAlarm(1f, TimeUnit.Days, new AlarmTimerCallback(helperNra.CheckKillSimNotUrnstonePro), "Esoiax44", AlarmType.AlwaysPersisted, null);
                                    }
                                    catch (ResetException) { throw; }
                                    catch (Exception exception)
                                    { NiecException.WriteLog("helperNra " + NiecException.NewLine + NiecException.LogException(exception), true, true, false); }

                                    //Actor.SimDescription.SetDeathStyle(this.simDeathType, false);

                                    //Actor.SimDescription.IsGhost = true;
                                    //Actor.SimDescription.ShowSocialsOnSim = false;
                                    //Actor.SimDescription.IsNeverSelectable = true;
                                    //Actor.SimDescription.Contactable = false;




                                    try
                                    {
                                        Actor.SimDescription.IsGhost = true;
                                        Actor.SimDescription.SetDeathStyle(simDeathType, true);
                                        Actor.SimDescription.ShowSocialsOnSim = false;
                                        Actor.SimDescription.IsNeverSelectable = true;
                                        Actor.SimDescription.Contactable = false;


                                        if (Actor.SimDescription.Household != null)
                                        {
                                            //SimDescription actor = Actor.SimDescription;
                                            List<Sim> listx = new List<Sim>();
                                            foreach (Sim sim in Actor.Household.Sims)
                                            {
                                                if (sim != Actor && !sim.IsSelectable && !(sim.Service is GrimReaper) && !sim.BuffManager.HasElement(BuffNames.Mourning) && !sim.BuffManager.HasElement(BuffNames.HeartBroken))
                                                {
                                                    listx.Add(sim);
                                                }
                                            }
                                            if (listx.Count > 0)
                                            {
                                                foreach (Sim nlist in listx)
                                                {
                                                    BuffMourning.BuffInstanceMourning buffInstanceMourning;

                                                    buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                                                    if (buffInstanceMourning == null)
                                                    {
                                                        nlist.BuffManager.AddElement(BuffNames.Mourning, Origin.FromWitnessingDeath);
                                                    }
                                                    buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                                                    if (buffInstanceMourning != null)
                                                    {
                                                        buffInstanceMourning.MissedSim = Actor.SimDescription;
                                                    }

                                                    BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken;
                                                    buffInstanceHeartBroken = (nlist.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                                                    if (buffInstanceHeartBroken == null || buffInstanceHeartBroken.BuffOrigin != Origin.FromWitnessingDeath)
                                                    {
                                                        nlist.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                                                    }
                                                    else
                                                    {
                                                        nlist.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                                                    }
                                                    buffInstanceHeartBroken = (nlist.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                                                    if (buffInstanceHeartBroken != null)
                                                    {
                                                        buffInstanceHeartBroken.MissedSim = Actor.SimDescription;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (ResetException) { throw; }
                                    catch (NullReferenceException) { }





                                    try
                                    {
                                        List<Sim> listxe = new List<Sim>();
                                        foreach (Sim sim in Actor.LotCurrent.GetAllActors())
                                        {
                                            if (sim != Actor && !sim.IsInActiveHousehold && !(sim.Service is GrimReaper) && !sim.BuffManager.HasElement(BuffNames.Mourning) && !sim.BuffManager.HasElement(BuffNames.HeartBroken))
                                            {
                                                listxe.Add(sim);
                                            }
                                        }
                                        if (listxe.Count > 0)
                                        {
                                            foreach (Sim nlist in listxe)
                                            {
                                                BuffMourning.BuffInstanceMourning buffInstanceMourning;

                                                buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                                                if (buffInstanceMourning == null)
                                                {
                                                    nlist.BuffManager.AddElement(BuffNames.Mourning, Origin.FromWitnessingDeath);
                                                }
                                                buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                                                if (buffInstanceMourning != null)
                                                {
                                                    buffInstanceMourning.MissedSim = Actor.SimDescription;
                                                }

                                                BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken;
                                                buffInstanceHeartBroken = (nlist.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                                                if (buffInstanceHeartBroken == null || buffInstanceHeartBroken.BuffOrigin != Origin.FromWitnessingDeath)
                                                {
                                                    nlist.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                                                }
                                                else
                                                {
                                                    nlist.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                                                }
                                                buffInstanceHeartBroken = (nlist.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                                                if (buffInstanceHeartBroken != null)
                                                {
                                                    buffInstanceHeartBroken.MissedSim = Actor.SimDescription;
                                                }
                                            }
                                        }
                                    }
                                    catch (ResetException) { throw; }
                                    catch (NullReferenceException) { }

                                    NiecMod.Nra.SpeedTrap.Sleep();
                                    Urnstone mGravebackup = Urnstone.CreateGrave(Actor.SimDescription, false, false);
                                    if (mGravebackup != null)
                                    {
                                        if (!GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(Actor.Position), false))
                                        {
                                            mGravebackup.SetPosition(Actor.Position);
                                        }
                                        mGravebackup.OnHandToolMovement();
                                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                        {
                                            mGravebackup.mHeartBrokenBroadcaster = new ReactionBroadcaster(mGravebackup, Urnstone.kHeartBrokenParams, Urnstone.UrnstoneHeartBrokenReaction);
                                        }
                                        else
                                        {
                                            mGravebackup.mHeartBrokenBroadcaster = new ReactionBroadcaster(mGravebackup, Urnstone.kHeartBrokenParams, UrnstoneHeartBrokenReaction);
                                        }
                                        // Test?

                                        //Actor.InteractionQueue.AddNext(entry);
                                    }




                                    if (Actor == PlumbBob.SelectedActor)
                                    {
                                        if (IntroTutorial.IsRunning)
                                        {
                                            IntroTutorial.ForceExitTutorial();
                                        }

                                    }

                                    if (Household.ActiveHousehold != null)
                                    {
                                        List<SimDescription> householdonly1 = Household.ActiveHousehold.SimDescriptions;
                                        if (Actor.Household != null && Actor.Household == Household.ActiveHousehold)
                                        {
                                            if (householdonly1.Count == 1)
                                            {
                                                List<Sim> listat = new List<Sim>();
                                                foreach (Sim actor in NFinalizeDeath.SC_GetObjects<Sim>())
                                                {
                                                    if (actor.SimDescription.CreatedSim != null && !actor.IsInActiveHousehold && actor.IsHuman && !actor.SimDescription.IsGhost && actor.SimDescription.TeenOrAbove && actor.SimDescription.Household != null && actor.SimDescription.Household != Household.NpcHousehold && actor.SimDescription.Household != Household.PetHousehold && actor.SimDescription.Household != Household.MermaidHousehold && actor.SimDescription.Household != Household.TouristHousehold && actor.SimDescription.Household != Household.PreviousTravelerHousehold && actor.SimDescription.Household != Household.AlienHousehold && actor.SimDescription.Household != Household.ServobotHousehold)
                                                    {
                                                        listat.Add(actor);
                                                    }
                                                }
                                                if (listat.Count == 0)
                                                {
                                                    StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec" + NiecException.NewLine + "Sorry, Found if listat.Count == 0" + NiecException.NewLine + "Note: Cant Find Sims" + NiecException.NewLine + "ExtKillSimNiec is cancelled", StyledNotification.NotificationStyle.kGameMessageNegative));
                                                    Actor.Motives.SetMax(CommodityKind.Hunger);
                                                    if (!Actor.SimDescription.IsEP11Bot)
                                                    {
                                                        if (Actor.SimDescription.Elder)
                                                        {
                                                            Actor.SimDescription.AgingState.ResetAndExtendAgingStage(0f);
                                                        }
                                                    }
                                                    DeathTypeFix = false;
                                                    FixNotExit = false;
                                                    try
                                                    {
                                                        SimDescription simDescriptiongot = Actor.SimDescription;
                                                        simDescriptiongot.IsGhost = false;
                                                        World.ObjectSetGhostState(Actor.ObjectId, 0u, (uint)simDescriptiongot.AgeGenderSpecies);
                                                        Actor.Autonomy.Motives.RemoveMotive(CommodityKind.BeGhostly);
                                                        simDescriptiongot.SetDeathStyle(SimDescription.DeathType.None, false);
                                                        Actor.Autonomy.AllowedToRunMetaAutonomy = true;
                                                    }
                                                    catch
                                                    { }
                                                    //Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                                                    try
                                                    {
                                                        NiecMod.Nra.SpeedTrap.Sleep();
                                                        Actor.BuffManager.RemoveAllElements();
                                                        Actor.FadeIn();
                                                        Actor.Motives.MaxEverything();
                                                        NiecMod.Nra.SpeedTrap.Sleep();
                                                        mGravebackup.Destroy();
                                                    }
                                                    catch
                                                    { }

                                                    stemprun = true;
                                                    stemprun_ = true;
                                                    Simulator.Wake(sma);
                                                }
                                                if (listat.Count > 0)
                                                {
                                                    Sim randomObjectFromList = RandomUtil.GetRandomObjectFromList(listat);
                                                    /*
                                                    if (!randomObjectFromList.InWorld)
                                                    {
                                                        randomObjectFromList.AddToWorld();
                                                    }
                                                     * */
                                                    PlumbBob.ForceSelectActor(randomObjectFromList);

                                                }
                                            }
                                        }
                                    }


                                    if (Actor.IsActiveSim)
                                    {
                                        //UserToolUtils.OnClose();
                                        LotManager.SelectNextSim();
                                    }


                                    if (Actor.SimDescription.IsPregnant)
                                    {
                                        this.Actor.SimDescription.Pregnancy.ClearPregnancyData();
                                        if (this.Actor.SimDescription.Pregnancy == null)
                                        {
                                            StyledNotification.Show(new StyledNotification.Format(this.Actor.Name + Localization.LocalizeString("cmarXmods/PregControl/PregNotice:NoMorePreg", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                                        }
                                        else
                                        {
                                            StyledNotification.Show(new StyledNotification.Format(Localization.LocalizeString("cmarXmods/PregControl/PregNotice:TerminationFail", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                                        }
                                    }

                                    try
                                    {
                                        Actor.BuffManager.RemoveAllElements();
                                        Actor.MoveInventoryItemsToAFamilyMember();
                                    }
                                    catch (ResetException) { throw; }
                                    catch { }


                                    this.DeathTypeFix = false;
                                    this.ActiveFix = false;
                                    this.FixNotExit = false;
                                    //Actor.SimDescription.Contactable = false;
                                    StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " Ok Active Household Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));

                                    NiecMod.Nra.SpeedTrap.Sleep();

                                    try
                                    {
                                        if (mGravebackup != null)
                                        {
                                            if (Actor.SimDescription.Household != null)
                                            {

                                                try
                                                {
                                                    //Actor.SimDescription.Household.Remove(Actor.SimDescription);
                                                    NFinalizeDeath.Household_Remove(Actor.SimDescription, false);
                                                    //Household.NpcHousehold.Add(Actor.SimDescription);
                                                    NFinalizeDeath.Household_Add(Household.NpcHousehold ?? Household.ActiveHousehold, Actor.SimDescription, false);
                                                }
                                                catch (ResetException) { throw; }
                                                catch
                                                { }

                                            }

                                            NiecMod.Nra.SpeedTrap.Sleep();
                                            InteractionInstance entry = Sims3.Gameplay.Objects.Urnstone.ReturnToGrave.Singleton.CreateInstance(mGravebackup, Actor, new InteractionPriority((InteractionPriorityLevel)8195, 0f), false, true);
                                            entry.MustRun = true;
                                            Actor.FadeOut();
                                            entry.RunInteraction();
                                            Actor.FadeOut();
                                            AlarmManager.Global.AddAlarm(3f, TimeUnit.Minutes, new AlarmTimerCallback(FailedCallBook), "Esoiax44X", AlarmType.AlwaysPersisted, null);
                                            stemprun = true;
                                            stemprun_ = true;
                                            //Simulator.Wake(sma);
                                            Simulator.Sleep(1000);
                                            return;
                                        }

                                    }
                                    catch (ResetException) { throw; }
                                    catch { }


                                    //return true;
                                    //ExtKillSimNiec.ListMorunExtKillSim(Actor, simDeathType);
                                }
                                catch (NullReferenceException) { }

                                catch (ResetException) { throw; }

                                stemprun = true;
                                stemprun_ = true;
                                Simulator.Wake(sma);
                            }
                            if (NFinalizeDeath.CheckAccept("Do you want Kill?\n(Yes Run or No Cancel)\nName: " + Actor.SimDescription.FullName) /* && Simulator.CheckYieldingContext(false) */)
                            {
                                //stemprun = true;
                                Simulator.Wake(sma);
                            }
                            else
                            {
                                if (!Actor.SimDescription.IsEP11Bot)
                                {
                                    if (Actor.SimDescription.Elder)
                                    {
                                        Actor.SimDescription.AgingState.ResetAndExtendAgingStage(0f);
                                    }
                                }
                                DeathTypeFix = false;
                                FixNotExit = false;
                                Actor.SimDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                                Actor.BuffManager.RemoveAllElements();
                                Actor.FadeIn();
                                //Actor.Motives.MaxEverything();
                                foreach (KeyValuePair<int, Motive> mMotive in Actor.Motives.mMotives)
                                {
                                    Actor.Motives.SetMax((CommodityKind)mMotive.Key);
                                }
                            
                                stemprun = true;
                                stemprun_ = true;
                                Simulator.Wake(sma);
                            }
                            
                        });
                        //char* asd = null;
                        //asd[1] = '2';
                        Simulator.Sleep(uint.MaxValue);
                        if (stemprun && stemprun_) return true;
                       // if (stemprun_ && stemprun) return true;
                        //if (this.simDeathType == SimDescription.DeathType.None) return false;
                        //if (NiecException.AcceptCancelDialogWithoutCommonException.Valid && NiecException.AcceptCancelDialogWithoutCommonException.Invoke<bool>(new object[] { "Do you want Force Kill? (Yes Run or No Next)" }))
                        
                    }
                }
                else
                {
                    try
                    {
                        //ExtKillSimNiec aasod = MemberwiseClone() as ExtKillSimNiec;
                        HelperNraPro helperNra = new HelperNraPro();

                        //helperNra = HelperNra;

                        if (Actor.Household != null)
                        {
                            helperNra.mHousehold = Actor.Household;
                        }
                        

                        helperNra.mSim = Actor;
                        helperNra.mdeathtype = simDeathType;

                        helperNra.mSimdesc = Actor.SimDescription;

                        helperNra.mHouseVeri3 = Actor.Position;

                        //helperNra.mdeathtype = simDeathType;

                        /*helperNra.malarmx =  */
                        helperNra.this_alarm = AlarmManager.Global.AddAlarm(3f, TimeUnit.Hours, new AlarmTimerCallback(helperNra.FailedCallBookSleep), "FailedCallBookSleep " + Actor.Name, AlarmType.NeverPersisted, null);
                    }
                    catch (Exception exception)
                    { NiecException.WriteLog("helperNra " + NiecException.NewLine + NiecException.LogException(exception), true, true, false); }
                }


                




                this.simDeathType = simDescription.SetDeathStyle(this.simDeathType, this.Actor.IsSelectable);
                if (Actor.SimDescription.IsPregnant && !Actor.IsInActiveHousehold)
                {
                    this.Actor.SimDescription.Pregnancy.ClearPregnancyData();
                    if (this.Actor.SimDescription.Pregnancy == null)
                    {
                        StyledNotification.Show(new StyledNotification.Format(this.Actor.Name + Localization.LocalizeString("cmarXmods/PregControl/PregNotice:NoMorePreg", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                    }
                    else
                    {
                        StyledNotification.Show(new StyledNotification.Format(Localization.LocalizeString("cmarXmods/PregControl/PregNotice:TerminationFail", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                    }
                }

                /*
                if (this.simDeathType == SimDescription.DeathType.ScubaDrown && !(this.Actor.Posture is ScubaDiving)) ... EA Dont Lot ScubaBrown Fix Remove
                {
                    return false;
                }
                */
                //if (Actor.IsNPC)
                //if (!Actor.IsInActiveHousehold || !NFinalizeDeath.IsSimFastActiveHousehold(Actor))
                if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                {
                    MustRun = false;
                    try
                    {
                        this.Actor.MoveInventoryItemsToAFamilyMember();
                    }
                    catch (NullReferenceException)
                    { }

                    if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        if (Actor.SimDescription.TraitManager.HasElement(TraitNames.Unlucky))
                        {
                            this.Actor.SimDescription.TraitManager.RemoveAllElements();
                            this.Actor.SimDescription.TraitManager.AddElement(TraitNames.Brave);
                            this.Actor.SimDescription.TraitManager.AddElement(TraitNames.Evil);
                            this.Actor.SimDescription.TraitManager.AddElement(TraitNames.Lucky);
                            this.Actor.SimDescription.TraitManager.AddElement(TraitNames.Athletic);
                            this.Actor.SimDescription.TraitManager.AddElement(TraitNames.Perfectionist);
                        }
                    }
                    /*
                    if (this.simDeathType == SimDescription.DeathType.Ranting)
                    {
                        this.Actor.BuffManager.AddElement(BuffNames.ThereAndBackAgain, Origin.FromRanting);
                    }
                    */
                }

                try
                {
                    if (NTunable.kCarmeraExtKillSimNiec)
                    {
                        if (!Camera.CameraTargetWithInLot(Actor.LotCurrent))
                        {
                            Camera.CameraNotification.ShowNotificationAndFocusOnSim(Actor.ObjectId, "ExtKillSimNiec: Found " + Actor.Name + " is Dead " + simDeathType.ToString(), Actor);
                        }
                    }
                }
                catch (Exception exception)
                {
                    NiecException.PrintMessage(exception.Message + NiecException.NewLine + exception.StackTrace);
                }

                /*
                // Add New
                if (Actor.Posture != null && !(Actor.Posture is ScubaDiving))
                {
                    Lot lotloot = Actor.LotCurrent;
                    if (GameUtils.IsInstalled(ProductVersion.EP10) && lotloot != null && lotloot.IsDivingLot)
                    {
                        ScubaDiving scubaDivinga = new ScubaDiving(mCurrentStateMachine, Ocean.Singleton, Actor);
                        if (scubaDivinga != null)
                        {
                            Actor.Posture = scubaDivinga;
                            scubaDivinga.StartBubbleEffects();
                        }
                    }
                }
                
                */
                

                // Add New
                if (GameUtils.IsInstalled(ProductVersion.EP10) && Actor.Posture != null && !(Actor.Posture is ScubaDiving))
                {
                    Lot lotloot = Actor.LotCurrent;
                    if (lotloot != null && lotloot.IsDivingLot)
                    {
                        ScubaDiving scubaDivinga = new ScubaDiving(mCurrentStateMachine, Ocean.Singleton, Actor);
                        if (scubaDivinga != null)
                        {
                            Actor.Posture = scubaDivinga;
                            scubaDivinga.StartBubbleEffects();
                        }
                    }
                }
#if unused
                GrimReaper sGrimReaperInstance = GrimReaper.Instance;


                NiecHelperSituation niecHelperSituation;
                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS") || sGrimReaperInstance == null)
                {
                    if (NiecHelperSituation.WorkingNiecHelperSituationCount == 0)
                    {
                        Actor.SimDescription.IsGhost = true;

                        niecHelperSituation = Create.
                            CreateRandomNiecHelperSituation(Actor, true, false, true);

                        if (niecHelperSituation == null) {
                            niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();
                            if (niecHelperSituation == null) {
                                Actor.Autonomy.SituationComponent.Situations.Add(NiecHelperSituation.Create(Actor.LotCurrent, Actor));
                                niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Actor, Actor, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            } 
                            else {
                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Target, Target, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            }
                        }
                    }
                }
                else if (sGrimReaperInstance != null)
                {
                    if ((sGrimReaperInstance.mPool == null || sGrimReaperInstance.mPool.Count == 0) && NiecHelperSituation.WorkingNiecHelperSituationCount == 0)
                    {
                        niecHelperSituation = Create.
                            CreateRandomNiecHelperSituation(Actor, true, true, true);

                        if (niecHelperSituation == null)
                        {
                            niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();
                            if (niecHelperSituation == null)
                            {
                                Actor.Autonomy.SituationComponent.Situations.Add(NiecHelperSituation.Create(Actor.LotCurrent, Actor));
                                niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Target, Target, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            }
                            else {
                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Target, Target, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            }
                        }
                    }

                    if (!Actor.LotCurrent.IsWorldLot || NFinalizeDeath.OpenDGS_GetOrSet_ForceWorldLotFromGrimReaper)
                    {
                        sGrimReaperInstance.MakeServiceRequest(Actor.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                    }
                }
#endif

                GrimReaper igrimreaper = GrimReaper.Instance;
                if (igrimreaper != null && Instantiator.RootIsOpenDGSInstalled) {
                    if (!Actor.LotCurrent.IsWorldLot || NFinalizeDeath.OpenDGS_GetOrSet_ForceWorldLotFromGrimReaper)
                    {
                        igrimreaper.MakeServiceRequest(Actor.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                    }
                }

                if (simDescription.IsMermaid)
                {
                    ScubaDiving scubaDiving = this.Actor.Posture as ScubaDiving;
                    if (scubaDiving != null)
                    {
                        InteractionInstance interactionInstance = EndScubaDive.Singleton.CreateInstance(this.Actor, this.Actor, base.GetPriority(), base.Autonomous, false);
                        interactionInstance.RunInteraction();
                        Lot nearestLot = LotManager.GetNearestLot(this.Actor.Position);
                        if (nearestLot != null)
                        {
                            GoToLot goToLot = VisitLot.Singleton.CreateInstance(Household.ActiveHousehold.LotHome, this.Actor, base.GetPriority(), base.Autonomous, false) as GoToLot;
                            goToLot.RunInteraction();
                        }
                        else
                        {
                            GoHome goHome = VisitLot.Singleton.CreateInstance(Household.ActiveHousehold.LotHome, this.Actor, base.GetPriority(), base.Autonomous, false) as GoHome;
                            goHome.RunInteraction();
                        }
                    }
                    else
                    {
                        SwimmingInPool swimmingInPool = this.Actor.Posture as SwimmingInPool;
                        if (swimmingInPool != null)
                        {
                            ISwimLocation containerPool = swimmingInPool.ContainerPool;
                            if (containerPool != null)
                            {
                                containerPool.RouteToEdge(this.Actor);
                            }
                        }
                    }
                }


                /*
                if (this.Actor.IsSelectable)
                {
                    EventTracker.SendEvent(new SimDescriptionEvent(EventTypeId.kSelectableSimDied, simDescription));
                }
                */
                if (Actor == NFinalizeDeath.ActiveActor)
                {
                    if (IntroTutorial.IsRunning)
                    {
                        IntroTutorial.ForceExitTutorial();
                    }
                }
                /*
                if (this.Actor.LotCurrent == PlumbBob.SelectedActor.LotHome || this.Actor.Household == PlumbBob.SelectedActor.Household)
                {
                    Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Normal, Sims3.Gameplay.Gameflow.SetGameSpeedContext.Gameplay);
                }
                 */

                try
                {
                    CheckCancelListInteractionByNiec(Actor);
                }
                catch (Exception)
                {
                    try
                    {
                        CheckCancelListInteractionByNiec(Actor);
                    }
                    catch (Exception)
                    { }
                }

                try
                {
                    if (Actor.Household != Household.ActiveHousehold)
                    {
                        this.Actor.Autonomy.IncrementAutonomyDisabled();
                    }
                }
                catch
                { }
                
                //this.Actor.Autonomy.IncrementAutonomyDisabled();

                simDescription.IsNeverSelectable = false;
                /*
                if (this.Actor.IsActiveSim)
                {
                    UserToolUtils.OnClose();
                    LotManager.SelectNextSim();
                }
                 */
                simDescription.ShowSocialsOnSim = true;
                if (Instantiator.RootIsOpenDGSInstalled)
                    TraitFunctions.SearchForUnrelatedEvilSimToTriggerLaugh(this.Actor);
                List<BuffInstance> list = new List<BuffInstance>(this.Actor.BuffManager.List);
                foreach (BuffInstance buffInstance in list)
                {
                    this.Actor.BuffManager.RemoveElement(buffInstance.Guid);
                }
                if (this.simDeathType == SimDescription.DeathType.Meteor)
                {
                    this.Actor.FadeIn();
                }
                /*
                if (!this.Actor.LotCurrent.IsFireOnLot())
                {
                    Urnstone.CreateDeathReactionBroadcaster(this.Actor);
                }
                */

                Urnstone.CreateDeathReactionBroadcaster(Actor);

                StateMachineClient stateMachineClient = null;
                Actor.AddInteraction(Sim.DeathReaction.Singleton);

                bool PlayaCore =NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.___bOpenDGSIsInstalled_;

                if (PlayaCore || this.Actor.IsHuman)
                {

                    if (this.PlayDeathAnimation && (PlayaCore || !Actor.SimDescription.Baby))
                    {
                        stateMachineClient = StateMachineClient.Acquire(this.Actor, "DeathTypes");
                        stateMachineClient.SetActor("x", this.Actor);
                        if (PlayaCore)
                        {
                            if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor))
                            {
                                stateMachineClient.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                            }
                            if (NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(Actor))
                                stateMachineClient.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                        }
                        if (simDeathType == SimDescription.DeathType.OldAge && Actor.SimDescription.Age != CASAgeGenderFlags.Elder)
                        {
                            stateMachineClient.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.elder);
                        }
                        stateMachineClient.EnterState("x", "Enter");
                        if (this.simDeathType == SimDescription.DeathType.Burn || this.simDeathType == SimDescription.DeathType.MummyCurse || this.simDeathType == SimDescription.DeathType.Thirst)
                        {
                            int xEventId = (this.simDeathType == SimDescription.DeathType.Burn) ? 100 : 101;
                            stateMachineClient.AddOneShotScriptEventHandler((uint)xEventId, new SacsEventHandler(this.EventCallbackCreateAshPile));
                        }
                        else if (this.simDeathType == SimDescription.DeathType.OldAge)
                        {
                            stateMachineClient.AddOneShotScriptEventHandler(101u, new SacsEventHandler(this.EventCallbackTurnToGhost));
                        }
                        else if (this.simDeathType == SimDescription.DeathType.Drown)
                        {
                            stateMachineClient.AddOneShotScriptEventHandler(100u, new SacsEventHandler(this.EventCallbackFadeOutSim));
                        }
                    }
                    else
                    {
                        try
                        {
                            Actor.LoopIdle();
                        }
                        catch
                        { }
                        if (!Simulator.CheckYieldingContext(false))
                        {
                            if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                            {
                                NFinalizeDeath.ThrowResetException(null);
                                NFinalizeDeath.Assert("ThrowResetException failed");
                                return true;
                            }
                            Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                            {
                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                                Simulator.Sleep(0);
                                Cleanup();
                            });
                            NFinalizeDeath.ThrowResetException(null);
                            NFinalizeDeath.Assert("ThrowResetException failed");
                            return false;
                        }
                    }
                    /*
                    if (GrimReaperSituation.ShouldDoDeathEvent(this.Actor))
                    {
                        //Camera.FocusOnSim(this.Actor, Urnstone.kCameraZoomOnDeathLerp, Urnstone.kCameraPitchOnDeathLerp);
                        World.SetWallCutawayFocusPos(this.Actor.Position);
                        if (this.simDeathType == SimDescription.DeathType.Thirst)
                        {
                            Audio.StartObjectSound(this.Actor.ObjectId, "sting_vampire_death", false);
                        }
                    }
                    */
                    World.SetWallCutawayFocusPos(this.Actor.Position);
                    if (this.simDeathType == SimDescription.DeathType.Thirst)
                    {
                        Audio.StartObjectSound(this.Actor.ObjectId, "sting_vampire_death", false);
                    }
                    EventTracker.SendEvent(new DnPSubjectDestroyedEvent(null, Actor.SimDescription, false));
                    ScubaDiving scubaDiving2 = this.Actor.Posture as ScubaDiving;
                    if (this.PlayDeathAnimation && (PlayaCore || !Actor.SimDescription.Baby))
                    {
                        if (scubaDiving2 != null)
                        {
                            scubaDiving2.StopBubbleEffects();
                        }
                        NFinalizeDeath.CheckYieldingContext();
                        stateMachineClient.RequestState("x", Urnstone.DeathAnimns[(uint)simDeathType]);
                        NFinalizeDeath.CheckYieldingContext();
                        stateMachineClient.RequestState("x", "Exit");
                    }
                    else
                    {
                        try
                        {
                            Actor.LoopIdle();
                        }
                        catch
                        { }
                        if (!Simulator.CheckYieldingContext(false)) {
                            if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                            {
                                NFinalizeDeath.ThrowResetException(null);
                                NFinalizeDeath.Assert("ThrowResetException failed");
                                return true;
                            }
                            Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate {
                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                                Simulator.Sleep(0);
                                Cleanup();
                            });
                            NFinalizeDeath.ThrowResetException(null);
                            NFinalizeDeath.Assert("ThrowResetException failed");
                            return false;
                        }
                    }/*
                    if (scubaDiving2 != null)
                    {
                        this.Actor.AddInteraction(GrimReaperSituation.ReapSoul.Singleton);
                    }
                    else
                    {
                        this.Actor.AddInteraction(GrimReaperSituation.ReapSoul.Singleton);
                    }*/
                }
                else // IsHuman
                {
                    Audio.StartObjectSound(this.Actor.ObjectId, "sting_pet_death", false);
                    this.SocialJig = SocialJigTwoPerson.CreateJigForTwoPersonSocial(CASAgeGenderFlags.Human, CASAgeGenderFlags.Adult, this.Target.SimDescription.Species, this.Target.SimDescription.Age, 0f);
                    Slot slotForActor = this.SocialJig.GetSlotForActor(this.Actor, false);
                    float num = (this.SocialJig.GetPositionOfSlot(slotForActor) - this.SocialJig.GetPositionOfSlot(SocialJigTwoPerson.RoutingSlots.SimA)).Length();
                    Vector3 forward = -this.Actor.ForwardVector;
                    Vector3 position = this.Actor.Position;
                    position = World.SnapToFloor(position);
                    this.SocialJig.RegisterParticipants(null, this.Actor);
                    if (!GlobalFunctions.FindGoodLocationNearby(this.SocialJig, ref position, ref forward, -num, GlobalFunctions.FindGoodLocationStrategies.All, FindGoodLocationBooleans.PreferEmptyTiles | FindGoodLocationBooleans.Routable | FindGoodLocationBooleans.TemporaryPlacement))
                    {
                        position = World.SnapToFloor(this.Actor.Position) - num;
                    }
                    this.SocialJig.SetPosition(position);
                    this.SocialJig.SetForward(forward);
                    this.SocialJig.SetOpacity(0f, 0f);
                    this.SocialJig.AddToWorld();
                    try
                    {
                        this.Actor.DoRoute(this.SocialJig.RouteToJigB(this.Actor));
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        if (Instantiator.RootIsOpenDGSInstalled)
                            throw;
                    }
                    
                    EventTracker.SendEvent(new DnPSubjectDestroyedEvent(null, this.Actor.SimDescription, false));
                    //this.Actor.AddInteraction(GrimReaperSituation.ReapPetSoul.PetSingleton);
                    try
                    {
                        this.Actor.LoopIdle();
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        if (Instantiator.RootIsOpenDGSInstalled)
                            throw;
                    }
                    
                }

                //if (!Actor.IsInActiveHousehold)
                //if (!Actor.IsInActiveHousehold || !NFinalizeDeath.IsSimFastActiveHousehold(Actor))
                if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                {
                    NiecMod.Nra.SpeedTrap.Sleep(20);
                }

                try
                {
                    CheckCancelListInteractionByNiec(Actor);
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    try
                    {
                        CheckCancelListInteractionByNiec(Actor);
                    }
                    catch (Exception)
                    { }
                }


                bool doneNiecHelperS = false;


                if (!Simulator.CheckYieldingContext(false))
                {
                    if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                    {
                        NFinalizeDeath.ThrowResetException(null);
                        NFinalizeDeath.Assert("ThrowResetException failed");
                        return true;
                    }
                    Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                    {
                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                        Simulator.Sleep(0);
                        Cleanup();
                    });
                    NFinalizeDeath.ThrowResetException(null);
                    NFinalizeDeath.Assert("ThrowResetException failed");
                    return false;
                }


                /////////////////// ---- ///////////////////


                GrimReaper sGrimReaperInstance = GrimReaper.Instance;
                NiecHelperSituation niecHelperSituation;

                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS") || sGrimReaperInstance == null)
                {
                    if (NiecHelperSituation.WorkingNiecHelperSituationCount == 0)
                    {
                        Actor.SimDescription.IsGhost = true;

                        niecHelperSituation = Create.
                            CreateRandomNiecHelperSituation(Actor, true, false, true);

                        if (niecHelperSituation == null)
                        {
                            doneNiecHelperS = true;

                            niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                            if (niecHelperSituation == null)
                            {
                                var nhs = NiecHelperSituation.Create(Actor.LotCurrent, Actor);
                                if (nhs != null)
                                    Actor.Autonomy.SituationComponent.Situations.Add(nhs);
                                else return false;
                                niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Actor, Actor, new InteractionPriority (
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f
                                    ),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                {
                                    FixNotExit = false;
                                    while (Actor != PlumbBob.SelectedActor &&NFinalizeDeath._RunInteraction(interactionNiecHelperSituation))
                                    {
                                        Simulator.Sleep(10);
                                    }
                                }
                                else NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            }
                            else
                            {
                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Actor, Actor, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f
                                    ),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            }
                        }
                        else if (niecHelperSituation.Worker == Actor && NFinalizeDeath.SC_GetObjects<Sim>().Length== 1) {
                            var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Actor, Actor, new InteractionPriority (
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f
                                    ),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                            NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);

                            doneNiecHelperS = true;
                        }
                    }
                }
                else if (sGrimReaperInstance != null)
                {
                    if ((sGrimReaperInstance.mPool == null || sGrimReaperInstance.mPool.Count == 0) && NiecHelperSituation.WorkingNiecHelperSituationCount == 0)
                    {
                        niecHelperSituation = Create.
                            CreateRandomNiecHelperSituation(Actor, true, true, true);

                        if (niecHelperSituation == null)
                        {
                            NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
                            NiecHelperSituation.Spawn._bUnSafeRunAll = true;

                            doneNiecHelperS = true;

                            niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                            if (niecHelperSituation == null)
                            {
                                var nhs = NiecHelperSituation.Create(Actor.LotCurrent, Actor);
                                if (nhs != null)
                                    Actor.Autonomy.SituationComponent.Situations.Add(nhs);
                                else return false;
                                niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Actor, Actor, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f
                                    ),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            }
                            else
                            {

                                var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Actor, Actor, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f
                                    ),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                                NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);
                            }
                        }
                        else if (niecHelperSituation.Worker == Actor && NFinalizeDeath.SC_GetObjects<Sim>().Length == 1)
                        {
                            var interactionNiecHelperSituation = (
                                    !niecHelperSituation.OkSuusse ?
                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                    .CreateInstance(Actor, Actor, new InteractionPriority(
                                        NiecRunCommand.IsOpenDGSInstalled ?
                                        (InteractionPriorityLevel)100 :
                                        (InteractionPriorityLevel)12, 999f
                                    ),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                );
                            NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);

                            doneNiecHelperS = true;
                        }
                    }
                    else 
                    {
                        niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();
                        if (niecHelperSituation != null && NiecHelperSituation.WorkingNiecHelperSituationCount == 1)
                        {
                            var interactionNiecHelperSituation = (
                                        !niecHelperSituation.OkSuusse ?
                                        Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                        .CreateInstance(Actor, Actor, new InteractionPriority(
                                            NiecRunCommand.IsOpenDGSInstalled ?
                                            (InteractionPriorityLevel)100 :
                                            (InteractionPriorityLevel)12, 999f
                                        ),

                                        isAutonomous: false,
                                        cancellableByPlayer: true
                            );

                            NFinalizeDeath._RunInteraction(interactionNiecHelperSituation);

                            doneNiecHelperS = true;
                        }
                    }
                }

                /////////////////// ---- ///////////////////


                NiecMod.Nra.SpeedTrap.Sleep(1);


                //if (Actor.IsInActiveHousehold || NFinalizeDeath.IsSimFastActiveHousehold(Actor))// (Actor.IsInActiveHousehold)

                if (!doneNiecHelperS)
                {
                    if (!Simulator.CheckYieldingContext(false))
                    {
                        if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                        {
                            NFinalizeDeath.ThrowResetException(null);
                            NFinalizeDeath.Assert("ThrowResetException failed");
                        }
                        Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                        {
                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                            Simulator.Sleep(0);
                            Cleanup();
                        });
                        NFinalizeDeath.ThrowResetException(null);
                        NFinalizeDeath.Assert("ThrowResetException failed");
                    }
                    if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                    {
                        base.DoLoop(ExitReason.Default);
                    }
                    else if (Actor.Service is GrimReaper)
                    {
                        Actor.ClearExitReasons();
                        base.DoLoop(ExitReason.CanceledByScript);
                    }
                    else if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        Actor.ClearExitReasons();
                        base.DoLoop(ExitReason.HigherPriorityNext);
                    }
                    else
                    {
                        Actor.ClearExitReasons();
                        //base.DoLoop(ExitReason.CanceledByScript, LoopExtKill, stateMachineClient);
                        base.DoLoop(ExitReason.CanceledByScript);
                    }
                }
                else Actor.ClearExitReasons();

                //[] sadasd = "sad";

                if (!Actor.IsInActiveHousehold)
                {
                    NiecMod.Nra.SpeedTrap.Sleep(15);
                }


                try
                {
                    CheckCancelListInteractionByNiec(Actor);
                }
                catch (Exception)
                {
                    try
                    {
                        CheckCancelListInteractionByNiec(Actor);
                    }
                    catch (Exception)
                    { }
                }



                Actor.RemoveInteractionByType(Sim.DeathReaction.Singleton);
                //if (Actor.InteractionQueue.HasInteractionOfType(NiecDefinitionDeathInteractionSocialSingleton) && !Actor.IsInActiveHousehold)
                //if (!Actor.IsInActiveHousehold)

                if (doneNiecHelperS) FixNotExit = false;

                if (!NFinalizeDeath.IsSimFastActiveHousehold(Actor) && !doneNiecHelperS && Actor.InteractionQueue != null && Actor.InteractionQueue.mInteractionList != null)
                {
                    while (Actor.InteractionQueue.mInteractionList.Remove(null)) { Simulator.Sleep(0); }
                    if (Actor.InteractionQueue.HasInteractionOfType(GrimReaperSituation.BeUnReaped.Singleton) || Actor.InteractionQueue.HasInteractionOfType(NinecReaper.Singleton) || Actor.InteractionQueue.HasInteractionOfType(KillSimNiecX.NiecDefinitionDeathInteraction.SocialSingleton) || Actor.InteractionQueue.HasInteractionOfType(NiecDefinitionDeathInteractionSocialSingleton) || Actor.InteractionQueue.HasInteractionOfType(GrimReaperSituation.BeReapedDiving.Singleton) || NFinalizeDeath.IsHasInteractionNHSTargetSim(Actor) || NFinalizeDeath.IsHasInteractionGRSTargetSim(Actor) || NFinalizeDeath.WaitCheckAccept("Do you want FixNotExit?\n(Yes Exit or No Run Force Kill)\nName: " + Actor.SimDescription.FullName))
                    {
                        FixNotExit = false;
                    }
                }
                //this.FixNotExit = false;
                CancelDeath = false;
                /*
                try
                {
                    CheckCancelListInteractionByNiec(Actor);
                }
                catch (Exception)
                {
                    try
                    {
                        CheckCancelListInteractionByNiec(Actor);
                    }
                    catch (Exception)
                    { }
                }
                */
                
                return true;
            }

            catch (ResetException)
            {
                //this.Cleanup();
                // Crash Game
                /*
                try
                {
                    throw new NiecModException("Server Error :D", exae);
                }
                catch (NiecModException exeax)
                {
                    if (exeax.StackTrace != null)
                    {
                        NiecException.WriteLog("ResetException KillSim: " + NiecException.NewLine + NiecException.LogException(exeax), true, false, false);
                    }
                    NiecException.PrintMessage("KillSim Run():" + NiecException.NewLine + "ResetException is Found No: " + NiecException.sLogEnumerator);
                }
                 */
                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS")) {
                    Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                    {
                        if (!doneCleanUp)
                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                        var ci = Sims3.NiecModList.Persistable.ListCollon.SafeRandomPart2.Next(15,55);
                        for (int i = 0; i < ci; i++)
                        {
                            Simulator.Sleep(0);
                        }
                        if (!doneCleanUp)
                        {
                            Cleanup();
                            doneCleanUp = true;
                        }
                    });
                }
                try
                {
                    throw;
                }
                catch (ExecutionEngineException)
                {
                    NFinalizeDeath.ThrowResetException(null);
                    return true;
                }
                
            }

            catch (Exception exception)
            {
                NiecException.WriteLog("ExtKillSimNiec: " + NiecException.NewLine + NiecException.LogException(exception), true, true, false);
                //nocleanup = true;
                //if (Actor.IsInActiveHousehold || NFinalizeDeath.IsSimFastActiveHousehold(Actor)) return true;
                if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor)) return true;
                Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate {
                    /*
                    if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && Actor == PlumbBob.sSingleton.mSelectedActor)
                    {
                        LotManager.SelectNextSim();
                    }
                    SimDescription taroa = Actor.SimDescription;
                    try
                    {
                        taroa.IsGhost = true;
                        if (simDeathType == SimDescription.DeathType.None)
                        {
                            List<SimDescription.DeathType> list = new List<SimDescription.DeathType>();
                            list.Add(SimDescription.DeathType.Drown);
                            list.Add(SimDescription.DeathType.Starve);
                            list.Add(SimDescription.DeathType.Thirst);
                            list.Add(SimDescription.DeathType.Burn);
                            list.Add(SimDescription.DeathType.Freeze);
                            list.Add(SimDescription.DeathType.ScubaDrown);
                            list.Add(SimDescription.DeathType.Shark);
                            list.Add(SimDescription.DeathType.Jetpack);
                            list.Add(SimDescription.DeathType.Meteor);
                            list.Add(SimDescription.DeathType.Causality);
                            if (!Actor.SimDescription.IsFrankenstein)
                            {
                                list.Add(SimDescription.DeathType.Electrocution);
                            }
                            list.Add(SimDescription.DeathType.Burn);
                            if (Actor.SimDescription.Elder)
                            {
                                list.Add(SimDescription.DeathType.OldAge);
                            }
                            if (Actor.SimDescription.IsWitch)
                            {
                                list.Add(SimDescription.DeathType.HauntingCurse);
                            }
                            SimDescription.DeathType randomObjectFromList = RandomUtil.GetRandomObjectFromList(list);
                            simDeathType = randomObjectFromList;

                        }
                        taroa.mDeathStyle = simDeathType;
                    }
                    catch (Exception)
                    { }
                    Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                    if (mGravebackup != null && HelperNra.TFindGhostsGrave(taroa) == null)
                    {

                        try
                        {
                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                            Actor.Destroy();
                            NiecMod.Nra.SpeedTrap.Sleep();
                        }
                        catch (Exception)
                        { }
                        if (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot)
                            mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                        else if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && PlumbBob.sSingleton.mSelectedActor.LotHome != null)
                            mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.LotHome.Position);
                        else
                        {
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


                                lotwt = RandomUtil.GetRandomObjectFromList<Lot>(lieastwt);
                                mGravebackup.SetPosition(lotwt.Position);
                            }
                            catch
                            { }
                        }
                        mGravebackup.OnHandToolMovement();
                        mGravebackup.FadeIn(false, 5f);
                        mGravebackup.FogEffectStart();
                        try
                        {
                            taroa.Fixup();
                        }
                        catch (Exception)
                        { }
                        //return true;
                    }
                     */
                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                    Cleanup();
                });
                NiecMod.Nra.SpeedTrap.Sleep(uint.MaxValue);
                /*
                if (this.ActiveFix)
                {
                    
                    {
                        if (Actor.SimDescription.IsPregnant)
                        {
                            this.Actor.SimDescription.Pregnancy.ClearPregnancyData();
                            if (this.Actor.SimDescription.Pregnancy == null)
                            {
                                StyledNotification.Show(new StyledNotification.Format(this.Actor.Name + Localization.LocalizeString("cmarXmods/PregControl/PregNotice:NoMorePreg", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                            else
                            {
                                StyledNotification.Show(new StyledNotification.Format(Localization.LocalizeString("cmarXmods/PregControl/PregNotice:TerminationFail", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                        }
                        try
                        {
                            this.Actor.MoveInventoryItemsToAFamilyMember();
                        }
                        catch (NullReferenceException)
                        { }
                        this.DeathTypeFix = false;
                        this.FixNotExit = false;
                        this.CancelDeath = false;
                        this.ActiveFix = false;
                        StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " is Failed Error. Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                        try
                        {
                            // Found System.NullReferenceException: A null value was found where an object instance was required. Fixed Bug No Household :) 

                            ExtKillSimNiec.ListMorunExtKillSim(Actor, simDeathType);
                            NFinalizeDeath.FinalizeSimDeathRelationships(Actor.SimDescription, 0);

                        }
                        catch (Exception)
                        {
                            Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                            StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " Failed To Catch Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                            return false;
                        }
                        finally
                        {
                            Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                            StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " Done To Finally Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                        }
                    }
                }
                 */
            }
            return false;
        }




        public void LoopExtKill(StateMachineClient smc, LoopData loopData)
        {
            if (Simulator.CheckYieldingContext(false) && NiecMod.Nra.SpeedTrap.SleepBool(71200))
            {
                Actor.AddExitReason(ExitReason.CanceledByScript);
            }
            else
            {
                //Actor.InteractionQueue.DeQueue(false);
               // this.Cleanup();
                Actor.AddExitReason(ExitReason.CanceledByScript);
            }
        }


        public void CheckKillAllSimGraveToPos()
        {
            NiecMod.Nra.SpeedTrap.Sleep();
            Sim simgrim = null;
            List<Urnstone> ras = new List<Urnstone>();
            try
            {
                foreach (Urnstone temp in NFinalizeDeath.SC_GetObjects<Urnstone>())
                {
                    try
                    {
                        if (!ras.Contains(temp))
                            ras.Add(temp);
                    }
                    catch
                    { }
                }
            }
            catch
            { }
            //while (true) // UnTested
            //for (int i = 0; i < 20; i++)
            foreach (Urnstone mGravebackup in ras.ToArray())
            {
                Simulator.Sleep(0);
                if (mGravebackup == null) continue;
                if (CheckYield)
                {
                    NiecMod.Nra.SpeedTrap.Sleep();
                    if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                    {
                        mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                    }
                    else if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && PlumbBob.sSingleton.mSelectedActor.SimDescription != null)
                    {
                        if (PlumbBob.sSingleton.mSelectedActor.Inventory != null && !PlumbBob.sSingleton.mSelectedActor.Inventory.TryToAdd(mGravebackup))
                        {
                            if (!PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot)
                                mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                            else if (PlumbBob.sSingleton.mSelectedActor.LotHome != null)
                            {
                                mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.LotHome.Position);
                            }
                        }
                    }
                    else if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && PlumbBob.sSingleton.mSelectedActor.LotHome != null)
                        mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.LotHome.Position);
                    else
                    {
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


                            lotwt = RandomUtil.GetRandomObjectFromList<Lot>(lieastwt);
                            if (lotwt != null)
                                mGravebackup.SetPosition(lotwt.Position);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch
                        { }
                    }
                }
                else
                {
                    if (mGravebackup != null && mGravebackup.LotCurrent != null && mGravebackup.LotCurrent.IsWorldLot)
                    {
                        List<Lot> lieast = new List<Lot>();
                        Lot loet = null;
                        foreach (Lot obj in LotManager.AllLotsWithoutCommonExceptions)
                        {
                            lieast.Add(obj);
                        }
                        if (lieast.Count != 0)
                        {
                            try
                            {
                                loet = RandomUtil.GetRandomObjectFromList<Lot>(lieast);

                                if (loet != null)
                                {
                                    if (mGravebackup != null && !GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(loet.Position), false))
                                    {
                                        mGravebackup.SetPosition(loet.Position);
                                    }
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }
                        }
                    }


                    NiecMod.Nra.SpeedTrap.Sleep();
                    //Urnstone mGravebackup = Create.GhostsGrave(Actor.SimDescription);
                    if (mGravebackup != null && Actor != null && object.ReferenceEquals(mGravebackup.DeadSimsDescription, Actor.SimDescription))
                    {
                        try
                        {
                            try
                            {
                                if (simgrim == null)
                                {
                                    foreach (Sim sim in NFinalizeDeath.SC_GetObjects<Sim>())
                                    {
                                        if (sim.Service != null && (sim.Service is GrimReaper))
                                        {
                                            simgrim = sim;
                                            break;
                                        }
                                    }
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }
                            NiecMod.Nra.SpeedTrap.Sleep();
                            if (simgrim != null && !simgrim.HasBeenDestroyed && !simgrim.LotCurrent.IsWorldLot)
                            {
                                if (!GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(simgrim.Position), false))
                                {
                                    mGravebackup.SetPosition(simgrim.Position);
                                }
                            }
                            else if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.Singleton.mSelectedActor.LotCurrent.IsWorldLot)
                            {
                                if (!GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position), false))
                                {
                                    mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                }
                            }
                            else
                            {
                                Lot lotm = mGravebackup.LotCurrent;
                                if (lotm != null)
                                {
                                    if (!GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(lotm.Position), false))
                                    {
                                        mGravebackup.SetPosition(lotm.Position);
                                    }
                                }
                            }

                            mGravebackup.OnHandToolMovement();
                            mGravebackup.FadeIn(false, 5f);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch
                        { }
                        NiecMod.Nra.SpeedTrap.Sleep();
                        try
                        {
                            mGravebackup.OnHandToolMovement();
                            mGravebackup.FadeIn(false, 5f);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch
                        { }
                    }
                }
                
                //else return;
            }
            CheckYield = true;
            AlarmManager.Global.RemoveAlarm(loadalarm);
            loadalarm = AlarmHandle.kInvalidHandle;

        }






        //bool nocleanup = false;

        bool CheckYield = false;

        public int WhatSimsCount = 0;


        //public static InteractionDefinition DGSMods_Interactions_Objects_TimePortalObject_Trias_Time = null;

        public static InteractionDefinition DGSMods_Interactions_Objects_TimePortalObject_Trias_Time = null;
        public bool doneCleanUp = false;
        public bool onRuntimeThisRun = false;


        public override void Cleanup()
        {
            if (!onRuntimeThisRun && Simulator.CheckYieldingContext(false) && Actor != null && InteractionObjectPair != null && Target != null)
            {
                onRuntimeThisRun = true;
                if (NFinalizeDeath.OnCancelTryRunInteraction(Actor, this))
                    return;
            }

            if (doneCleanUp && NiecRunCommand.IsOpenDGSInstalled) 
                return;

            doneCleanUp = true;
            if (Target == null || Target.SimDescription == null) 
                return;

            stemprun = false;
            stemprun_ = false;
            //if (nocleanup) return;
            Exception tempStackTrace = null;
            try { throw new ExecutionEngineException("DEBUG KillSim::Cleanup()"); }
            catch(Exception et){tempStackTrace = et;}
            SimDescription simdx = Actor.SimDescription;
            if (simdx == null || !simdx.IsValidDescription && simdx.mBio == null) return;
            NiecTask.Perform(delegate
            {
                bool Aleadly = false;
                //List<Sim> checkitem = new List<Sim>();
                int cont = 0;
                if (!CheckYield && DGSMods_Interactions_Objects_TimePortalObject_Trias_Time != null)
                {
                    foreach (var aitem in NFinalizeDeath.SC_GetObjects<Sim>())
                    {
                        if (cont > 11) break;
                        try
                        {
                            if (aitem.InteractionQueue != null&& aitem.InteractionQueue.HasInteractionOfType(DGSMods_Interactions_Objects_TimePortalObject_Trias_Time))
                            {
                                //checkitem.Add(aitem);
                                cont++;
                            }
                        }
                        catch (Exception)
                        { }

                    }
                }

                //StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: Cont? " + cont, StyledNotification.NotificationStyle.kGameMessagePositive));
                //if (checkitem != null && checkitem.Count > 9)
                if (cont > 10)
                {
                    //try
                    //{
                    //    //StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: CheckYield?", StyledNotification.NotificationStyle.kGameMessagePositive));
                    //}
                    //catch
                    //{ }
                    CheckYield = true;
                    //checkitem.Clear();
                    //checkitem = null;
                }

                if (CheckYield && Simulator.CheckYieldingContext(false))
                {
                    Simulator.Sleep(10);
                }
                else if (CheckYield && !Aleadly)
                {
                    Aleadly = true;
                    try
                    {
                        StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: CheckYield Aleadly?", StyledNotification.NotificationStyle.kGameMessagePositive));
                    }
                    catch
                    { }
                    NiecMod.Nra.SpeedTrap.Sleep();
                    Sims3.NiecHelp.Tasks.NiecTask.Perform(Cleanup);
                    return;
                }
                SimDescription simd = null;
                /*
                string msg = " Sim Name Null ";
                string msg2 = " SimDescription Null ";
                SimDescription simd = null;
                try
                {
                    if (Actor.SimDescription != null)
                    {
                        msg2 = " Found SimDescription " + Actor.SimDescription.ToString();
                    }
                    simd = Actor.SimDescription;
                }
                catch
                { }
                try
                {
                    if (Actor.Name != null)
                    {
                        msg = " Found Actor Name " + Actor.Name;
                    }
                }
                catch
                { }
                try
                {
                    StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: Test?" + msg + msg2, StyledNotification.NotificationStyle.kGameMessagePositive));
                }
                catch
                { }

                */


                try
                {
                    int activehouseholdint = 0;
                    if (GameStates.IsGameShuttingDown || Responder.Instance.IsGameStateShuttingDown)
                    {
                        if (this.SocialJig != null)
                        {
                            this.SocialJig.Destroy();
                            this.SocialJig = null;
                        }
                        base.Cleanup();
                        return;
                    }
                    // ????
                    if (this.FixNotExit)
                    {
                        try
                        {
                            if (NFinalizeDeath.ActiveHousehold != null && NFinalizeDeath.ActiveHousehold.AllSimDescriptions != null)
                                activehouseholdint = NFinalizeDeath.ActiveHousehold.AllSimDescriptions.Count;
                            else
                                activehouseholdint = 0;
                        }
                        catch
                        { }

                        //NiecMod.Nra.SpeedTrap.Sleep(1); Not tempStackTrace

                        //if (!Actor.IsInActiveHousehold)
                        //if (Actor.SimDescription != null && PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && PlumbBob.sSingleton.mSelectedActor.SimDescription != null && Actor.SimDescription.Household != PlumbBob.sSingleton.mSelectedActor.SimDescription.Household)

                        //if (!NFinalizeDeath.IsSimFastActiveHousehold(Actor))
                        if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                        {

                            /*
                            // Old tempStackTrace
                            try
                            {
                                throw new NiecModException("Wait Find XeginSocialInteraction");
                            }
                            catch (NiecModException e)
                            {
                                if (e.StackTrace.Contains("ReapSoul") && e.StackTrace.Contains("BeginSocialInteraction") || e.StackTrace.Contains("ReapPetSoul") && e.StackTrace.Contains("BeginSocialInteraction"))
                                {
                                    if (this.SocialJig != null)
                                    {
                                        this.SocialJig.Destroy();
                                        this.SocialJig = null;
                                    }
                                    base.Cleanup();
                                    return;
                                }
                            }
                            */
                            // New tempStackTrace
                            string sta = tempStackTrace.StackTrace;
                            if (
                                    sta.Contains("NiecHelperSituation+Spawn") 
                                 ||
                                    (sta.Contains("ReapSoul") && sta.Contains("BeginSocialInteraction")) 
                                 ||
                                    (sta.Contains("ReapPetSoul") && sta.Contains("BeginSocialInteraction"))
                                )
                            {
                                if (this.SocialJig != null)
                                {
                                    this.SocialJig.Destroy();
                                    this.SocialJig = null;
                                }
                                base.Cleanup();
                                return;
                            }
                            if (Actor.SimDescription == null) return; // 2020
                            if (sWasIsActiveHousehold)
                            {

                                if (activehouseholdint == 1 || WhatSimsCount == 1)
                                {
                                    Actor.SimDescription.ShowSocialsOnSim = true;
                                    Actor.SimDescription.IsNeverSelectable = false;
                                    if (this.SocialJig != null)
                                    {
                                        this.SocialJig.Destroy();
                                        this.SocialJig = null;
                                    }
                                    base.Cleanup();
                                    return;
                                }
                            }

                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                            try
                            {
                                Actor.SimDescription.IsGhost = true;
                                if (simDeathType == SimDescription.DeathType.None)
                                {
                                    List<SimDescription.DeathType> list = new List<SimDescription.DeathType>();
                                    list.Add(SimDescription.DeathType.Drown);
                                    list.Add(SimDescription.DeathType.Starve);
                                    list.Add(SimDescription.DeathType.Thirst);
                                    list.Add(SimDescription.DeathType.Burn);
                                    list.Add(SimDescription.DeathType.Freeze);
                                    list.Add(SimDescription.DeathType.ScubaDrown);
                                    list.Add(SimDescription.DeathType.Shark);
                                    list.Add(SimDescription.DeathType.Jetpack);
                                    list.Add(SimDescription.DeathType.Meteor);
                                    list.Add(SimDescription.DeathType.Causality);
                                    if (!Actor.SimDescription.IsFrankenstein)
                                    {
                                        list.Add(SimDescription.DeathType.Electrocution);
                                    }
                                    list.Add(SimDescription.DeathType.Burn);
                                    if (Actor.SimDescription.Elder)
                                    {
                                        list.Add(SimDescription.DeathType.OldAge);
                                    }
                                    if (Actor.SimDescription.IsWitch)
                                    {
                                        list.Add(SimDescription.DeathType.HauntingCurse);
                                    }
                                    SimDescription.DeathType randomObjectFromList = RandomUtil.GetRandomObjectFromList(list);
                                    simDeathType = randomObjectFromList;

                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }



                            if (!NFinalizeDeath.SChelsea && Actor.LotCurrent != null && !Actor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(NFinalizeDeath.ActiveActor_SimDescription))
                            {
                                try
                                {
                                    Actor.SimDescription.SetDeathStyle(this.simDeathType, true);
                                    if (!CheckYield && Create.GhostsGrave(Actor.SimDescription) == null)
                                    {
                                        Urnstone mGrave = Urnstone.CreateGrave(Actor.SimDescription, false, true);
                                        if (mGrave != null)
                                        {
                                            mGrave.SetOpacity(0f, 0f);
                                            SimDescription.DeathType deathStylea = this.simDeathType;
                                            World.FindGoodLocationParams fglParams = (deathStylea == SimDescription.DeathType.Drown) ? new World.FindGoodLocationParams(Actor.Position) : new World.FindGoodLocationParams(Actor.Position);
                                            fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                                            if (!CheckYield && !GlobalFunctions.PlaceAtGoodLocation(mGrave, fglParams, false))
                                            {

                                                if (Simulator.CheckYieldingContext(false))
                                                    Simulator.Sleep(0u);
                                                else
                                                    StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: CheckYieldingContext Failed", StyledNotification.NotificationStyle.kGameMessagePositive));
                                                fglParams.BooleanConstraints = FindGoodLocationBooleans.None;
                                                if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, fglParams, false))
                                                {
                                                    mGrave.SetPosition(Actor.Position);
                                                }
                                            }
                                            mGrave.OnHandToolMovement();
                                            mGrave.FadeIn(false, 10f);
                                            mGrave.FogEffectStart();

                                            if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && PlumbBob.sSingleton.mSelectedActor.LotCurrent != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                            {
                                                mGrave.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);

                                            }
                                        }

                                    }


                                    try
                                    {
                                        if (!CheckYield && PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                        {
                                            foreach (Urnstone iteem in NFinalizeDeath.SC_GetObjects<Urnstone>())
                                            {
                                                NiecMod.Nra.SpeedTrap.Sleep();
                                                //if (iteem.DeadSimsDescription == Actor.SimDescription)
                                                if (iteem != null && object.ReferenceEquals(iteem.DeadSimsDescription, Actor.SimDescription))
                                                {
                                                    iteem.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                                }
                                            }

                                        }
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch
                                    { }

                                    if (NFinalizeDeath.MyActiveActor(Actor.SimDescription) && !CheckYield && Create.GhostsGrave(Actor.SimDescription) == null)
                                    {
                                        Urnstone mGravebackup = Urnstone.CreateGrave(Actor.SimDescription, false, false);
                                        if (mGravebackup != null)
                                        {
                                            if (!CheckYield && !GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(Actor.Position), false))
                                            {
                                                mGravebackup.SetPosition(Target.Position);
                                            }
                                            mGravebackup.OnHandToolMovement();
                                            if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                            {
                                                mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);

                                            }
                                        }
                                    }

                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (NullReferenceException)
                                { }
                                try
                                {

                                    if (!CheckYield && Create.GhostsGrave(Actor.SimDescription) != null)
                                        NiecHelperSituation.FinalizeSimDeathPro(Actor.SimDescription, homehome != null ? homehome : Household.sNpcHousehold, !AssemblyCheckByNiec.IsInstalled("OpenDGS"));
                                    /*
                                else
                                {

                                    Actor.Destroy();
                                }
                                 */
                                    if (!Actor.HasBeenDestroyed)
                                    {
                                        Actor.Destroy();
                                        if (Simulator.CheckYieldingContext(false))
                                            Simulator.Sleep(0u);
                                    }

                                    //Urnstone.FinalizeSimDeath(Actor.SimDescription, homehome != null ? homehome : Household.sNpcHousehold, !AssemblyCheckByNiec.IsInstalled("DGSCore"));
                                }
                                catch (Exception)
                                { }
                            }
                            else
                            {
                                Urnstone mGravebackup = null;
                                try
                                {
                                    //List<Sim> sims = new List<Sim>();
                                    Sim simgrim = null;
                                    //foreach (Sim sim in Actor.LotCurrent.GetAllActors())
                                    foreach (Sim sim in NFinalizeDeath.SC_GetObjects<Sim>())
                                    {
                                        if (sim.Service != null && (sim.Service is GrimReaper))
                                        {
                                            simgrim = sim;
                                            break;
                                        }
                                    }
                                    //if (!PlumbBob.Singleton.mSelectedActor.LotCurrent.IsWorldLot)
                                    if (!CheckYield && Create.GhostsGrave(Actor.SimDescription) == null)
                                    {
                                        mGravebackup = Urnstone.CreateGrave(Actor.SimDescription, false, false);
                                        if (mGravebackup != null)
                                        {
                                            /*
                                            if (!GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position), false))
                                            {
                                                mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                                mGravebackup.SetForward(PlumbBob.Singleton.mSelectedActor.Position);
                                                mGravebackup.OnHandToolMovement();
                                                mGravebackup.FadeIn(true, 5f);
                                                mGravebackup.FogEffectStart();
                                            }
                                             * */
                                            NiecMod.Nra.SpeedTrap.Sleep();
                                            if (simgrim != null && !simgrim.HasBeenDestroyed && !simgrim.LotCurrent.IsWorldLot)
                                            {
                                                if (!CheckYield && !GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(simgrim.Position), false))
                                                {
                                                    mGravebackup.SetPosition(simgrim.Position);
                                                }
                                            }
                                            else if (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && PlumbBob.sSingleton.mSelectedActor.SimDescription != null && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                            {
                                                if (CheckYield || !GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(PlumbBob.sSingleton.mSelectedActor.Position), false))
                                                {
                                                    mGravebackup.SetPosition(PlumbBob.sSingleton.mSelectedActor.Position);
                                                }
                                            }
                                            else
                                            {
                                                Lot lotm = mGravebackup.LotCurrent;
                                                if (lotm != null && !lotm.IsWorldLot)
                                                {
                                                    if (!GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(lotm.Position), false))
                                                    {
                                                        mGravebackup.SetPosition(lotm.Position);
                                                    }
                                                }

                                            }

                                            //mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                            mGravebackup.OnHandToolMovement();
                                            mGravebackup.FadeIn(false, 5f);
                                            mGravebackup.FogEffectStart();
                                        }
                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (NullReferenceException)
                                {
                                    if (mGravebackup != null)
                                    {
                                        mGravebackup.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                        mGravebackup.OnHandToolMovement();
                                        mGravebackup.FadeIn(false, 5f);
                                        mGravebackup.FogEffectStart();
                                    }
                                }
                            }

                            //if (Actor.IsInActiveHousehold)
                           // if (NFinalizeDeath.IsSimFastActiveHousehold(Actor))
                            if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                            {
                                try
                                {
                                    if (Actor.Household == null && homehome != null)
                                    {
                                       // homehome.Add(Actor.SimDescription);
                                        NFinalizeDeath.Household_Add(homehome, Actor.SimDescription, false);
                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (NullReferenceException)
                                { }
                            }

                            if (!CheckYield && Create.GhostsGrave(Actor.SimDescription) != null)
                                NiecHelperSituation.FinalizeSimDeathPro(Actor.SimDescription, homehome != null ? homehome : Household.sNpcHousehold, !AssemblyCheckByNiec.IsInstalled("OpenDGS"));

                            if (!Actor.HasBeenDestroyed)
                            {
                                Actor.Destroy();
                                if (Simulator.CheckYieldingContext(false))
                                    Simulator.Sleep(0u);
                            }

                            this.CancelDeath = false;
                            this.FixNotExit = false;
                            this.DeathTypeFix = false;
                            this.ActiveFix = false;
                            try
                            {
                                try
                                {
                                    if (!CheckYield && Simulator.CheckYieldingContext(false) && PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot &&  NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                    {
                                        foreach (Urnstone iteem in NFinalizeDeath.SC_GetObjects<Urnstone>())
                                        {
                                            //if (iteem.DeadSimsDescription == Actor.SimDescription)
                                            NiecMod.Nra.SpeedTrap.Sleep();

                                            if (PlumbBob.Singleton.mSelectedActor == null)
                                                break;

                                            if (iteem != null && (object)iteem.DeadSimsDescription == (object)Actor.SimDescription)
                                            {
                                                iteem.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                            }
                                        }

                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                { }
                                //Sims3.NiecHelp.Tasks.NiecTask.Perform(CheckKillAllSimGraveToPos);
                                if (AlarmManager.Global != null)
                                {
                                    loadalarm = AlarmManager.Global.AddAlarm(5f, TimeUnit.Minutes, new AlarmTimerCallback(CheckKillAllSimGraveToPos), "CheckKillAllSimGraveToPos Name " + Actor.SimDescription.LastName, AlarmType.NeverPersisted, null);
                                    AlarmManager.Global.AlarmWillYield(loadalarm);
                                }
                                else NiecTask.Perform( ScriptExecuteType.Threaded,() =>
                                {
                                    for (int i = 0; i < 500; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }
                                    CheckKillAllSimGraveToPos();
                                });

                                StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " is Cancel and Exit ExtKillSimNiec! to Run Force Kill :) " + simDeathType.ToString(), StyledNotification.NotificationStyle.kGameMessagePositive));

                                if (Actor.Inventory != null)
                                    Actor.MoveInventoryItemsToAFamilyMember();
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch (NullReferenceException)
                            { }





                            /*
                            try
                            {
                                StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " is Cancel and Exit ExtKillSimNiec! to Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                try
                                {
                                    Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                                }
                                catch (Exception ex3)
                                { NiecException.WriteLog("CreateGrave: " + NiecException.NewLine + NiecException.LogException(ex3), true, true, false); }
                            }
                            catch (Exception)
                            { }
                            */
                            // List Mod


                            // Old tempStackTrace
                            /*
                            try
                            {
                                if (NTunable.kDedugNiecModExceptionExtKillSimNiec)
                                {
                                    throw new NiecModException("ExtKillSimNiec: Not Error");
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch (NiecModException ex)
                            {
                                if (NTunable.kDedugNiecModExceptionExtKillSimNiec)
                                {
                                    NiecException.WriteLog("ExtKillSimNiec: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
                                }
                            }
                             * */

                            // New tempStackTrace

                            if (NTunable.kDedugNiecModExceptionExtKillSimNiec)
                            {
                                NiecException.WriteLog("ExtKillSimNiec: " + NiecException.NewLine + NiecException.LogException(tempStackTrace), true, true, false);
                            }
                            try
                            {
                                // Found System.NullReferenceException: A null value was found where an object instance was required. Fixed Bug No Household :) 

                                ExtKillSimNiec.ListMorunExtKillSim(Actor, simDeathType);
                                try
                                {
                                    Actor.SimDescription.ShowSocialsOnSim = false;
                                    Actor.SimDescription.IsNeverSelectable = true;
                                    Actor.SimDescription.Contactable = false;
                                    if (this.SocialJig != null)
                                    {
                                        this.SocialJig.Destroy();
                                        this.SocialJig = null;
                                    }
                                    Actor.LotCurrent.LastDiedSim = Actor.SimDescription;

                                    if (Create.GhostsGrave(Actor.SimDescription) == null)
                                        SafeNRaas.NRUrnstones_CreateGrave(Actor.SimDescription, this.simDeathType, true, false);


                                    if (Actor.Household != null) Actor.Household.Remove(Actor.SimDescription);

                                    if (simd != null && simd.CreatedSim != null)
                                    {
                                        simd.CreatedSim.Destroy();
                                        if (Simulator.CheckYieldingContext(false))
                                            Simulator.Sleep(0u);
                                    }

                                    return;
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (NullReferenceException)
                                { }

                                //NFinalizeDeath.FinalizeSimDeathRelationships(Actor.SimDescription, 0);
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch (Exception)
                            {
                                Actor.SimDescription.ShowSocialsOnSim = false;
                                Actor.SimDescription.IsNeverSelectable = true;
                                Actor.SimDescription.Contactable = false;
                                if (this.SocialJig != null)
                                {
                                    this.SocialJig.Destroy();
                                    this.SocialJig = null;
                                }

                                if (!CheckYield && Create.GhostsGrave(Actor.SimDescription) == null)
                                    SafeNRaas.NRUrnstones_CreateGrave(Actor.SimDescription, this.simDeathType, true, false);

                                if (Actor.Household != null) Actor.Household.Remove(Actor.SimDescription);


                                if (simd != null && simd.CreatedSim != null)
                                {
                                    simd.CreatedSim.Destroy();
                                    if (Simulator.CheckYieldingContext(false))
                                        Simulator.Sleep(0u);
                                }

                                return;
                            }
                            /*
                        finally
                        {
                            try
                            {
                                Actor.SimDescription.ShowSocialsOnSim = false;
                                Actor.SimDescription.IsNeverSelectable = true;
                                Actor.SimDescription.Contactable = false;
                                if (this.SocialJig != null)
                                {
                                    this.SocialJig.Destroy();
                                    this.SocialJig = null;
                                }
                                Urnstones.CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                            }
                            catch (Exception)
                            { }

                        }
                        // End
                             * */
                        }
                    }
                }
                catch (ResetException)
                {
                    /*
                    try
                    {
                        throw new NiecModException();
                    }
                    catch (NiecModException exeax)
                    {
                        if (exeax.StackTrace != null)
                        {
                            NiecException.WriteLog("ResetException FixNotExit: " + NiecException.NewLine + NiecException.LogException(exeax), true, false, false);
                        }
                        NiecException.PrintMessage("FixNotExit:" + NiecException.NewLine + "ResetException is Found No: " + NiecException.sLogEnumerator);
                    }
                    */
                    throw;
                }
                catch (Exception ex)
                { NiecException.WriteLog("FixNotExit: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false); return; }


                //if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor)) return;
                homehome = null;
                this.Actor.RemoveInteractionByType(Sim.DeathReaction.Singleton);
                if (this.CancelDeath)
                {
                    SimDescription.DeathType deathStyle = this.Actor.SimDescription.DeathStyle;
                    SimDescription simDescription = this.Actor.SimDescription;
                    simDescription.ShowSocialsOnSim = true;
                    World.ObjectSetGhostState(this.Actor.ObjectId, 0u, (uint)simDescription.AgeGenderSpecies);
                    simDescription.IsNeverSelectable = false;

                    try
                    {
                        if (this.ActiveFix)
                        {
                            //if (!Actor.IsInActiveHousehold)
                            //if (!NFinalizeDeath.IsSimFastActiveHousehold(Actor))
                            if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(Actor))
                            {
                                //Actor.SimDescription.Contactable = false;
                                try
                                {
                                    this.Actor.MoveInventoryItemsToAFamilyMember();
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (Exception)
                                { }

                                this.DeathTypeFix = false;

                                StyledNotification.Show(new StyledNotification.Format("ExtKillSimNiec: " + Actor.Name + " is Dont Run ExtKillSimNiec! to Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                // List Mod
                                try
                                {
                                    if (NTunable.kDedugNiecModExceptionExtKillSimNiec)
                                    {
                                        throw new NiecModException("ExtKillSimNiec: Not Error");
                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (NiecModException ex)
                                {
                                    if (NTunable.kDedugNiecModExceptionExtKillSimNiec)
                                    {

                                        NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
                                    }
                                }

                                try
                                {
                                    // Found System.NullReferenceException: A null value was found where an object instance was required. Fixed Bug No Household :) 

                                    ExtKillSimNiec.ListMorunExtKillSim(Actor, simDeathType);
                                    NFinalizeDeath.FinalizeSimDeathRelationships(Actor.SimDescription, 0);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (Exception)
                                {
                                    Actor.SimDescription.ShowSocialsOnSim = false;
                                    Actor.SimDescription.IsNeverSelectable = true;
                                    Actor.SimDescription.Contactable = false;
                                    if (this.SocialJig != null)
                                    {
                                        this.SocialJig.Destroy();
                                        this.SocialJig = null;
                                    }
                                    SafeNRaas.NRUrnstones_CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                                    return;
                                }
                                finally
                                {
                                    SafeNRaas.NRUrnstones_CreateGrave(Actor.SimDescription, this.simDeathType, true, false);
                                }
                                // End
                            }
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch (Exception aas)
                    { NiecException.WriteLog("FixNotExit: " + NiecException.NewLine + NiecException.LogException(aas), true, true, false); }

                    if (this.DeathTypeFix)
                    {
                        if (!simDescription.IsEP11Bot)
                        {
                            simDescription.AgingEnabled = true;
                            if (simDescription.DeathStyle == SimDescription.DeathType.OldAge)
                            {
                                simDescription.AgingState.ResetAndExtendAgingStage(0f);
                            }
                        }
                        simDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    }
                }
                if (this.SocialJig != null)
                {
                    this.SocialJig.Destroy();
                    this.SocialJig = null;
                }
                base.Cleanup();
            });
            
        }

        public static void CreateDeathReactionBroadcasterX(Sim corpse)
        {
            corpse.DeathReactionBroadcast = new ReactionBroadcaster(corpse, Urnstone.kDeathReactionBroadcasterParams, new ReactionBroadcaster.BroadcastCallback(Urnstone.DeathReactionCallback));
        }


        public void FailedCallBookSleep()
        {
            while (NiecMod.Nra.SpeedTrap.SleepBool(40))
            {
                Actor.SimRoutingComponent.DisableDynamicFootprint();
                Actor.SetPosition(Actor.Position);
                
                Actor.SimRoutingComponent.EnableDynamicFootprint();
            }
            return;
        }

        public SimDescription TestDesc = null;

        public void FailedCallBook()
        {
            TestDesc = Actor.SimDescription;
            Actor.FadeOut();
            Actor.Destroy();
            SafeNRaas.NRUrnstones_CreateGrave(TestDesc, simDeathType, false, false);

            //this.Cleanup();
            return;
        }

        public static void ListMorunExtKillSim(Sim actorlist, SimDescription.DeathType deathType)
        {
            if (actorlist == null)
                return;

            if (actorlist.mSimDescription == null)
                actorlist.mSimDescription = Create.NiecNullSimDescription();

            var simDescription = actorlist.SimDescription;

            try
            {

                try
                {
                    simDescription.IsGhost = true;
                    simDescription.SetDeathStyle(deathType, true);
                }

                catch
                { }

                if (simDescription.Household != null)
                {
                    foreach (Sim nlist in NFinalizeDeath.Household_GetAllActors(simDescription.Household))
                    {
                        if (nlist != actorlist && nlist.SimDescription != null  && nlist.SimDescription.IsHuman && nlist.BuffManager != null && !nlist.IsSelectable && !(nlist.Service is GrimReaper) && !nlist.BuffManager.HasElement(BuffNames.Mourning) && !nlist.BuffManager.HasElement(BuffNames.HeartBroken))
                        {
                            nlist.EnableInteractions();
                            BuffMourning.BuffInstanceMourning buffInstanceMourning;
                            buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                            if (buffInstanceMourning == null)
                            {
                                nlist.BuffManager.AddElement(BuffNames.Mourning, Origin.FromWitnessingDeath);
                            }
                            buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                            if (buffInstanceMourning != null)
                            {
                                buffInstanceMourning.MissedSim = actorlist.SimDescription;
                            }
                            foreach (Relationship relationship in Relationship.Get(simDescription))
                            {
                                if (relationship == null)
                                    continue;

                                if (actorlist.SimDescription.Partner == nlist.SimDescription)
                                {
                                    if (relationship.LTR.HasInteractionBit(LongTermRelationship.InteractionBits.Marry))
                                    {
                                        relationship.LTR.RemoveInteractionBit(LongTermRelationship.InteractionBits.Marry);
                                        relationship.LTR.AddInteractionBit(LongTermRelationship.InteractionBits.Divorce);
                                        WeddingAnniversary weddingAnniversary = relationship.WeddingAnniversary;
                                        if (weddingAnniversary != null)
                                        {
                                            AlarmManager.Global.RemoveAlarm(weddingAnniversary.AnniversaryAlarm);
                                            relationship.WeddingAnniversary = null;
                                        }
                                        SocialCallback.BreakUpDescriptionsShared(actorlist.SimDescription, nlist.SimDescription);
                                    }
                                    else if (relationship.LTR.HasInteractionBit(LongTermRelationship.InteractionBits.Propose))
                                    {
                                        relationship.LTR.RemoveInteractionBit(LongTermRelationship.InteractionBits.Propose);
                                        relationship.LTR.AddInteractionBit(LongTermRelationship.InteractionBits.BreakUp);
                                    }
                                    else if (relationship.LTR.HasInteractionBit(LongTermRelationship.InteractionBits.MakeCommitment))
                                    {
                                        relationship.LTR.RemoveInteractionBit(LongTermRelationship.InteractionBits.MakeCommitment);
                                        relationship.LTR.AddInteractionBit(LongTermRelationship.InteractionBits.BreakUp);
                                    }
                                    actorlist.SimDescription.ClearPartner();
                                }
                            }
                        }
                    }
                }


                foreach (Sim nlist in NFinalizeDeath.SC_GetObjectsOnLot<Sim>(actorlist.LotCurrent))
                {
                    if (nlist != null && nlist != actorlist && nlist.BuffManager != null && !nlist.IsInActiveHousehold && !(nlist.Service is GrimReaper) && !nlist.BuffManager.HasElement(BuffNames.Mourning) && !nlist.BuffManager.HasElement(BuffNames.HeartBroken))
                    {
                        BuffMourning.BuffInstanceMourning buffInstanceMourning;

                        buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                        if (buffInstanceMourning == null)
                        {
                            nlist.BuffManager.AddElement(BuffNames.Mourning, Origin.FromWitnessingDeath);
                        }
                        buffInstanceMourning = (nlist.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                        if (buffInstanceMourning != null)
                        {
                            buffInstanceMourning.MissedSim = actorlist.SimDescription;
                        }

                        BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken;
                        buffInstanceHeartBroken = (nlist.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                        if (buffInstanceHeartBroken == null || buffInstanceHeartBroken.BuffOrigin != Origin.FromWitnessingDeath)
                        {
                            nlist.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                        }
                        else
                        {
                            nlist.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                        }
                        buffInstanceHeartBroken = (nlist.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                        if (buffInstanceHeartBroken != null)
                        {
                            buffInstanceHeartBroken.MissedSim = actorlist.SimDescription;
                        }
                    }
                }

                Urnstone urnstone = FindGhostsGrave(simDescription);
                if (urnstone != null)
                {
                    if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        urnstone.mHeartBrokenBroadcaster = new ReactionBroadcaster(urnstone, Urnstone.kHeartBrokenParams, Urnstone.UrnstoneHeartBrokenReaction);
                    }
                    else
                    {
                        urnstone.mHeartBrokenBroadcaster = new ReactionBroadcaster(urnstone, Urnstone.kHeartBrokenParams, UrnstoneHeartBrokenReaction);
                    }
                }
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message);
            }
        }


        public static void UrnstoneHeartBrokenReaction(Sim sim, ReactionBroadcaster broadcaster)
        {
            var simd = (broadcaster.BroadcastingObject as Urnstone);
            if (sim != null && sim.BuffManager != null && simd != null)
            {
                if (sim.BuffManager.HasElement(BuffNames.HeartBroken))
                {
                    var buffInstanceHeartBroken = sim.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken;
                    if (buffInstanceHeartBroken != null &&
                        buffInstanceHeartBroken.MissedSim.SimDescriptionId != 0 &&
                        buffInstanceHeartBroken.MissedSim == simd)
                    {
                        ThumbnailKey thumbnailKey = buffInstanceHeartBroken.MissedSim.GetThumbnailKey(ThumbnailSize.Large, 0);
                        var bd = new ThoughtBalloonManager.DoubleBalloonData(thumbnailKey, buffInstanceHeartBroken.ThumbString);
                        bd.mPriority = ThoughtBalloonPriority.High;
                        if (sim.ThoughtBalloonManager != null)
                            sim.ThoughtBalloonManager.ShowBalloon(bd);
                        sim.PlayReaction(ReactionTypes.HeartBroken, ReactionSpeed.AfterInteraction);
                    }
                }

                if (sim.BuffManager.HasElement(BuffNames.Mourning))
                {
                    var buffInstanceMourning = sim.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning;
                    if (buffInstanceMourning != null &&
                        buffInstanceMourning.MissedSim.SimDescriptionId != 0 &&
                        buffInstanceMourning.MissedSim == simd)
                    {
                        ThumbnailKey thumbnailKey2 = buffInstanceMourning.MissedSim.GetThumbnailKey(ThumbnailSize.Large, 0);
                        var bd = new ThoughtBalloonManager.DoubleBalloonData(thumbnailKey2, buffInstanceMourning.ThumbString);
                        bd.mPriority = ThoughtBalloonPriority.High;
                        if (sim.ThoughtBalloonManager != null)
                            sim.ThoughtBalloonManager.ShowBalloon(bd);
                        sim.PlayReaction(ReactionTypes.HeartBroken, ReactionSpeed.AfterInteraction);
                    }
                }
            }
        }


        public static Urnstone FindGhostsGrave(SimDescription sim)
        {
            foreach (Urnstone urnstone in NFinalizeDeath.SC_GetObjects<Urnstone>())
            {
                //if (object.ReferenceEquals(urnstone.DeadSimsDescription, sim))
                if ((object)urnstone.DeadSimsDescription == (object)sim)
                {
                    return urnstone;
                }
            }
            return null;
        }


        public static void CheckCancelListInteractionByNiec(Sim sima)
        {
            if (sima == null || sima.InteractionQueue == null) return;
            try
            {
                try
                {
                    if (sima.InteractionQueue.HasInteractionOfType(typeof(GoToSchoolInRabbitHole)) || sima.InteractionQueue.HasInteractionOfType(GoToSchoolInRabbitHole.Singleton)) sima.AddExitReason(ExitReason.StageComplete);

                    //if (sima.InteractionQueue.HasInteractionOfType(GoToSchoolInRabbitHole.Singleton)) sima.AddExitReason(ExitReason.StageComplete);
                }
                catch
                { }
                /*
                sima.AddExitReason(ExitReason.Canceled);
                sima.AddExitReason(ExitReason.StageComplete);
                sima.AddExitReason(ExitReason.Default);
                sima.AddExitReason(ExitReason.BuffFailureState);
                sima.AddExitReason(ExitReason.HigherPriorityNext);
                sima.AddExitReason(ExitReason.CanceledByScript);
                 * */
                foreach (InteractionInstance interactionInstance in sima.InteractionQueue.InteractionList)
                {
                    if (interactionInstance is GoToSchoolInRabbitHole || interactionInstance is ICountsAsWorking)
                    {
                        sima.AddExitReason(ExitReason.StageComplete);
                    }
                }
            }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
            }
            try
            {
                if (sima.mInteractionQueue != null && !sima.mInteractionQueue.IsInteractionQueueEmpty())
                {

                    foreach (InteractionInstance interactionInstance in sima.mInteractionQueue.mInteractionList.ToArray()) // Cant Cancel Fix
                    {
                        interactionInstance.MustRun = false;
                        interactionInstance.CancellableByPlayer = true;
                        interactionInstance.Hidden = false;
                    }
                }
            }
            catch
            {
                try
                {
                    if (sima.mInteractionQueue != null && !sima.mInteractionQueue.IsInteractionQueueEmpty())
                    {
                        foreach (InteractionInstance interactionInstance in sima.mInteractionQueue.mInteractionList.ToArray()) // Cant Cancel Fix
                        {
                            interactionInstance.MustRun = false;
                            interactionInstance.CancellableByPlayer = true;
                            interactionInstance.Hidden = false;
                        }
                    }
                }
                catch
                { }
            }
        }


        private void EventCallbackCreateAshPile(StateMachineClient sender, IEvent evt)
        {
            this.mAshPile = (GlobalFunctions.CreateObjectOutOfWorld("AshPile") as AshPile);
            if (this.Actor.SimDescription.IsMummy || this.Actor.SimDescription.DeathStyle == SimDescription.DeathType.MummyCurse)
            {
                this.mAshPile.SetMaterial("mummy");
            }
            this.mAshPile.AddToWorld();
            this.mAshPile.SetPosition(this.Actor.Position);
            this.mAshPile.SetTooltipText(this.Actor.SimDescription.FirstName + " " + this.Actor.SimDescription.LastName);
            LotLocation invalid = LotLocation.Invalid;
            World.GetLotLocation(this.mAshPile.Position, ref invalid);
            FireManager.BurnTile(this.mAshPile.LotCurrent.LotId, invalid);
            SimDescription.DeathType deathStyle = this.Actor.SimDescription.DeathStyle;
            float fadeTime = (deathStyle == SimDescription.DeathType.MummyCurse || deathStyle == SimDescription.DeathType.Thirst) ? 1.2f : GameObject.kGlobalObjectFadeTime;
            this.Actor.FadeOut(false, false, fadeTime);
        }


        private void EventCallbackHideSim(StateMachineClient sender, IEvent evt)
        {
            this.Actor.SetHiddenFlags((HiddenFlags)4294967295u);
        }


        private void EventCallbackTurnToGhost(StateMachineClient sender, IEvent evt)
        {
            if (!this.Actor.SimDescription.IsEP11Bot)
            {
                uint deathStyle = (uint)this.Actor.SimDescription.DeathStyle;
                World.ObjectSetGhostState(this.Actor.ObjectId, deathStyle, (uint)this.Actor.SimDescription.AgeGenderSpecies);
                return;
            }
            World.ObjectSetGhostState(this.Actor.ObjectId, 23u, (uint)this.Actor.SimDescription.AgeGenderSpecies);
        }


        private void EventCallbackFadeOutSim(StateMachineClient sender, IEvent evt)
        {
            this.Actor.FadeOut();
        }

        public void StartDeathEffect()
        {
            try
            {
                if (this.mDeathEffect == null)
                {
                    this.mDeathEffect = VisualEffect.Create("death");
                    this.mDeathEffect.ParentTo(this.Target, Sim.FXJoints.Spine1);
                    this.mDeathEffect.Start();
                }
            }
            catch (Exception exception)
            {
                NiecException.PrintMessage("StartDeathEffect" + exception.Message + NiecException.NewLine + exception.StackTrace);
            }
        }

        public void StopDeathEffect()
        {
            if (this.mDeathEffect != null)
            {
                this.mDeathEffect.Stop();
                this.mDeathEffect.Dispose();
                this.mDeathEffect = null;
            }
        }


        public static readonly InteractionDefinition Singleton = new Definition();

        public static readonly InteractionDefinition NiecDefinitionDeathInteractionSocialSingleton = new SocialInteractionB.DefinitionDeathInteraction();


        private AshPile mAshPile;

        public bool CancelDeath = true;


        public bool sWasIsActiveHousehold = false;








        private bool ActiveFix = true;

        private bool DeathTypeFix = true;

        private bool FixNotExit = true;


        public bool mForceKillGrim = false;

  
        public SocialJig SocialJig;

        private VisualEffect mDeathEffect;

    
        public SimDescription.DeathType simDeathType = SimDescription.DeathType.None;

     
        public bool PlayDeathAnimation = true;


        [DoesntRequireTuning]

        private sealed class Definition : InteractionDefinition<Sim, Sim, ExtKillSimNiec>, IDontNeedToBeCheckedInResort, IIgnoreIsAllowedInRoomCheck, IAllowedOnClosedVenues, IOverridesAgeTests, IUseTargetForAutonomousIsAllowedInRoomCheck, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
        {
          
            public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair iop)
            {
                try
                {
                    return Localization.LocalizeString("Gameplay/Actors/Sim/ReapSoul:InteractionName", new object[0]);
                }
                catch (Exception)
                {
                    return "Exipre";
                }
            }

            /*
            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                try
                {
                    if (parameters.Autonomous)
                    {
                        return InteractionTestResult.GenericFail;
                    }
                    return InteractionTestResult.Pass;
                }
                catch (Exception)
                { return InteractionTestResult.Pass; }
            }
            */




            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                try
                {
                    if (!Test(parameters.Actor as Sim, parameters.Target as Sim, parameters.Autonomous, ref greyedOutTooltipCallback))
                    {
                        return InteractionTestResult.Def_TestFailed;
                    }
                }
                catch (Exception)
                { }
                
                return InteractionTestResult.Pass;
            }

           
            public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                try
                {
                    //if (actor.Service is GrimReaper && !mForceKillGrim) return false;
                    //if (actor.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton)) return false;
                    if (isAutonomous) return false;
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            }
            public SpecialCaseAgeTests GetSpecialCaseAgeTests()
            {
                return SpecialCaseAgeTests.None;
            }
            public override string[] GetPath(bool isFemale)
            {
                return new string[] { "Test myMod" };
            }
            public override InteractionInstance CreateInstance(ref InteractionInstanceParameters parameters)
            {
                InteractionInstance interactionInstance = base.CreateInstance(ref parameters);
                interactionInstance.MustRun = true;
                return interactionInstance;
            }

        }
    }
}
