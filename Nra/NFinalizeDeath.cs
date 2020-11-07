/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 20/10/2018
 * Time: 2:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

#define EA_LOG_ENABLED
#define EA_TRACE_ENABLED

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
using Sims3.SimIFace.VideoRecording;
 
namespace NiecMod.Nra
{
    [Persistable()]
    public class HelperNraPro
    {

        ~HelperNraPro()
        {
            //StyledNotification.Show(new StyledNotification.Format("HelperNraPro Done Dispose.", StyledNotification.NotificationStyle.kGameMessagePositive));
            Dispose(true);
           
        }
        public void Dispose()
        { 
#if EA_LOG_ENABLED
            Dispose(false);
             
#elif a
            mSim = null;
#endif
        }
        public void Dispose(bool fromDtor)
        {
            this_alarm = AlarmHandle.kInvalidHandle;
            mHousehold = null;
            malarmx = AlarmHandle.kInvalidHandle;
            mSim = null;
            mSimdesc = null;
            mdeathtype = SimDescription.DeathType.None;
            mHouseVeri3 = Vector3.Invalid;
            if (!fromDtor)
            {
                //GC.SuppressFinalize(this);
            }
        }

        
        public AlarmHandle this_alarm = AlarmHandle.kInvalidHandle;


        /*
        public HelperNraPro()
        {
            if (sHelperNraProList == null) { sHelperNraProList = new List<HelperNraPro>(); }







        }
        [PersistableStatic]
        public static List<HelperNraPro> sHelperNraProList;
        */



        public Sim mSim = null;

        public HelperNraPro test = null;

        public SimDescription mSimdesc = null;

        public SimDescription.DeathType mdeathtype = SimDescription.DeathType.OldAge;

        public Vector3 mHouseVeri3 = Vector3.Invalid;

        public AlarmHandle malarmx = AlarmHandle.kInvalidHandle;

        public Household mHousehold = null;

        /*
        public static HelperNraPro FoundSleep()
        {
            //Type type = this.GetType();
            //HelperNraPro t
            
            //return default;
            return t;
        }

        

        public unsafe static void asdoasd()
        {
            char* sad = (char*)3;
            string sadas = new string(sad);
        }
        */

        

        public void FailedCallBookSleep()
        {
            try
            {
                AlarmManager.Global.RemoveAlarm(this_alarm);
                this_alarm = AlarmHandle.kInvalidHandle;
            }
            catch (Exception)
            { }
            if (mSimdesc == null) return;
           
            if (mSimdesc.CreatedSim == null)
            {
                Dispose(true);
                return;
            }
            if (mSim == null)
            {
                Dispose(true);
                return;
            }
            if (mSim.InteractionQueue == null)
            {
                Dispose(true);
                return;
            }
            if (AssemblyCheckByNiec.IsInstalled("OpenDGS") && !mSimdesc.IsValidDescription && mSimdesc.OccultManager == null)
            {
                Dispose(true);
                return;
            }
            try
            {
                if (!mSim.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton) || AssemblyCheckByNiec.IsInstalled("OpenDGS") && !mSim.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                {
                    return;
                }
            }
            catch
            { }
            
            try
            {
                if (!mSimdesc.IsValidDescription)
                {
                    if (mSimdesc.Genealogy == null)
                    {
                        mSimdesc.mGenealogy = new Genealogy(mSimdesc);
                    }
                    mSimdesc.Fixup();
                }
                
            }
            catch
            { }
            try
            {
                if (mSimdesc.Household == null)
                {
                    if (mHousehold != null)
                    {
                        mHousehold.Add(mSimdesc);
                    }
                    else
                    {
                        Household.NpcHousehold.Add(mSimdesc);
                    }
                }
            }
            catch
            { Household.NpcHousehold.Add(mSimdesc); }

            if (mHouseVeri3 == null || mHouseVeri3 == Vector3.Invalid)
            {


                if (Household.ActiveHousehold != null)
                {
                    try
                    {
                        List<SimDescription> listxt = new List<SimDescription>();
                        foreach (SimDescription simat in Household.ActiveHousehold.SimDescriptions)
                        {
                            listxt.Add(simat);
                        }
                        if (listxt.Count != 0)
                        {
                            foreach (SimDescription item in listxt)
                            {
                                Sim sim = item.CreatedSim;
                                if (sim == null) continue;
                                if (sim.LotCurrent != null && sim.LotCurrent.IsWorldLot) continue;
                                mHouseVeri3 = sim.Position;
                                break;
                            }
                        }
                        else
                        {
                            this_alarm = AlarmManager.Global.AddAlarm(3f, TimeUnit.Hours, new AlarmTimerCallback(FailedCallBookSleep), "FailedCallBookSleep " + mSim.FullName, AlarmType.AlwaysPersisted, null);
                            return;
                        }
                    }
                    catch (Exception ex)
                    { NiecException.WriteLog("HelperNraPro: Error" + NiecException.LogException(ex), true, true, false); }
                }
                else
                {
                    this_alarm = AlarmManager.Global.AddAlarm(3f, TimeUnit.Hours, new AlarmTimerCallback(FailedCallBookSleep), "FailedCallBookSleep " + mSim.FullName, AlarmType.AlwaysPersisted, null);
                    return;
                }
            }
            try
            {
                /*
                if (malarmx != AlarmHandle.kInvalidHandle)
                {
                    AlarmManager.Global.RemoveAlarm(malarmx);
                }
                 * */
                try
                {
                    if (mSim.SimDescription.DeathStyle != SimDescription.DeathType.None && mSim.SimDescription.IsGhost || mSim.SimDescription.IsDead)
                    {
                        try
                        {
                            SimDescription simDescriptiongot = mSim.SimDescription;
                            simDescriptiongot.IsGhost = false;
                            World.ObjectSetGhostState(mSim.ObjectId, 0u, (uint)simDescriptiongot.AgeGenderSpecies);
                            mSim.Autonomy.Motives.RemoveMotive(CommodityKind.BeGhostly);
                            simDescriptiongot.SetDeathStyle(SimDescription.DeathType.None, false);
                            simDescriptiongot.ShowSocialsOnSim = true;
                            simDescriptiongot.IsNeverSelectable = false;
                            mSim.Autonomy.AllowedToRunMetaAutonomy = true;
                            SpeedTrap.Sleep();
                        }
                        catch (Exception ex)
                        { NiecException.WriteLog("HelperNraPro: Error X" + NiecException.LogException(ex), true, true, false); }

                        finally
                        {
                            if (mdeathtype == SimDescription.DeathType.None)
                            {
                                mSimdesc.SetDeathStyle(SimDescription.DeathType.OldAge, false);
                            }
                            else
                            {
                                mSimdesc.SetDeathStyle(mdeathtype, false);
                            }

                        }
                    }
                }
                catch (Exception ex)
                { NiecException.WriteLog("HelperNraPro: Error XXX" + NiecException.LogException(ex), true, true, false); }
                
                
                if (NTunable.kCheckFailed)
                {
                    if (!GlobalFunctions.PlaceAtGoodLocation(mSim, new World.FindGoodLocationParams(mHouseVeri3), false))
                    {
                        try
                        {
                            if (PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.Singleton.mSelectedActor.LotCurrent.IsWorldLot)
                            {
                                mHouseVeri3 = PlumbBob.Singleton.mSelectedActor.Position;
                                if (!GlobalFunctions.PlaceAtGoodLocation(mSim, new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position), false))
                                {
                                    mSim.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                }




                                GrimReaper.Instance.MakeServiceRequest(PlumbBob.Singleton.mSelectedActor.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                            }
                            else
                            {
                                bool yesRamdon = false;
                                Sim simrandom = null;
                                if (Household.ActiveHousehold != null && PlumbBob.Singleton.mSelectedActor != null)
                                {
                                    try
                                    {
                                        List<SimDescription> listxt = new List<SimDescription>();
                                        foreach (SimDescription simat in Household.ActiveHousehold.SimDescriptions)
                                        {
                                            listxt.Add(simat);
                                        }
                                        if (listxt.Count != 0)
                                        {
                                            foreach (SimDescription item in listxt)
                                            {
                                                Sim sim = item.CreatedSim;
                                                if (sim == null) continue;
                                                if (sim.LotCurrent != null && sim.LotCurrent.IsWorldLot) continue;
                                                simrandom = RandomUtil.GetRandomObjectFromList(sim);
                                                yesRamdon = true;
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    { NiecException.WriteLog("HelperNraPro: Error XXXX" + NiecException.LogException(ex), true, true, false); }
                                }

                                if (yesRamdon && simrandom != null)
                                {
                                    mSim.SetPosition(simrandom.Position);
                                }
                                else
                                {
                                    mSim.SetPosition(mHouseVeri3);
                                }

                                if (!mSim.LotCurrent.IsWorldLot)
                                {
                                    GrimReaper.Instance.MakeServiceRequest(mSim.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                                }
                                /*
                                var asdoei = mSim.CurrentInteraction as ExtKillSimNiec;
                                if (asdoei != null)
                                {
                                    // Add New
                                    if (GameUtils.IsInstalled(ProductVersion.EP10) && mSim.Posture != null && !(mSim.Posture is ScubaDiving))
                                    {
                                        Lot lotloot = mSim.LotCurrent;
                                        if (lotloot != null && lotloot.IsDivingLot)
                                        {
                                            ScubaDiving scubaDivinga = new ScubaDiving(asdoei.mCurrentStateMachine, Ocean.Singleton, mSim);
                                            if (scubaDivinga != null)
                                            {
                                                mSim.Posture = scubaDivinga;
                                                scubaDivinga.StartBubbleEffects();
                                            }
                                        }
                                    }
                                }
                                 * */
                            }
                        }
                        catch
                        { }
                    }
                }
                else
                {
                    if (PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.Singleton.mSelectedActor.LotCurrent.IsWorldLot)
                    {
                        if (!GlobalFunctions.PlaceAtGoodLocation(mSim, new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position), false))
                        {
                            try
                            {
                                if (PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.Singleton.mSelectedActor.LotCurrent.IsWorldLot)
                                {
                                    mHouseVeri3 = PlumbBob.Singleton.mSelectedActor.Position;
                                    if (!GlobalFunctions.PlaceAtGoodLocation(mSim, new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position), false))
                                    {
                                        mSim.SetPosition(PlumbBob.Singleton.mSelectedActor.Position);
                                    }
                                    GrimReaper.Instance.MakeServiceRequest(PlumbBob.Singleton.mSelectedActor.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                                }
                                else
                                {
                                    bool yesRamdon = false;
                                    Sim simrandom = null;
                                    if (Household.ActiveHousehold != null && PlumbBob.Singleton.mSelectedActor != null)
                                    {
                                        try
                                        {
                                            List<SimDescription> listxt = new List<SimDescription>();
                                            foreach (SimDescription simat in Household.ActiveHousehold.SimDescriptions)
                                            {
                                                listxt.Add(simat);
                                            }
                                            if (listxt.Count != 0)
                                            {
                                                foreach (SimDescription item in listxt)
                                                {
                                                    Sim sim = item.CreatedSim;
                                                    if (sim == null) continue;
                                                    if (sim.LotCurrent != null && sim.LotCurrent.IsWorldLot) continue;
                                                    simrandom = RandomUtil.GetRandomObjectFromList(sim);
                                                    yesRamdon = true;
                                                    break;
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        { NiecException.WriteLog("HelperNraPro: Error XXXXX" + NiecException.LogException(ex), true, true, false); }
                                    }

                                    if (yesRamdon && simrandom != null)
                                    {
                                        mSim.SetPosition(simrandom.Position);
                                    }
                                    else
                                    {
                                        mSim.SetPosition(mHouseVeri3);
                                    }
                                   
                                    if (!mSim.LotCurrent.IsWorldLot)
                                    {
                                        GrimReaper.Instance.MakeServiceRequest(mSim.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                                    }
                                    /*
                                    var asdoei = mSim.CurrentInteraction as ExtKillSimNiec;
                                    if (asdoei != null)
                                    {
                                        // Add New
                                        if (GameUtils.IsInstalled(ProductVersion.EP10) && mSim.Posture != null && !(mSim.Posture is ScubaDiving))
                                        {
                                            Lot lotloot = mSim.LotCurrent;
                                            if (lotloot != null && lotloot.IsDivingLot)
                                            {
                                                ScubaDiving scubaDivinga = new ScubaDiving(asdoei.mCurrentStateMachine, Ocean.Singleton, mSim);
                                                if (scubaDivinga != null)
                                                {
                                                    mSim.Posture = scubaDivinga;
                                                    scubaDivinga.StartBubbleEffects();
                                                }
                                            }
                                        }
                                    }
                                     * */
                                }
                            }
                            catch
                            { }
                        }
                    }
                    
                }

                

                try
                {
                    ExtKillSimNiec asdoei = mSim.CurrentInteraction as ExtKillSimNiec;
                    if (asdoei != null)
                    {
                        // Add New
                        if (GameUtils.IsInstalled(ProductVersion.EP10) && mSim.Posture != null && !(mSim.Posture is ScubaDiving))
                        {
                            Lot lotloot = mSim.LotCurrent;
                            if (lotloot != null && lotloot.IsDivingLot)
                            {
                                ScubaDiving scubaDivinga = new ScubaDiving(asdoei.mCurrentStateMachine, Ocean.Singleton, mSim);
                                if (scubaDivinga != null)
                                {
                                    mSim.Posture = scubaDivinga;
                                    scubaDivinga.StartBubbleEffects();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                { NiecException.WriteLog("HelperNraPro: Error A" + NiecException.LogException(ex), true, true, false); }
                mSim.FadeIn();
                //mSim.SimRoutingComponent.DisableDynamicFootprint();
                
                //mSim.SimRoutingComponent.EnableDynamicFootprint();
                
                if (!mSim.LotCurrent.IsWorldLot)
                {
                    GrimReaper.Instance.MakeServiceRequest(mSim.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                }
                if (!PlumbBob.Singleton.mSelectedActor.LotCurrent.IsWorldLot)
                {
                    GrimReaper.Instance.MakeServiceRequest(PlumbBob.Singleton.mSelectedActor.LotCurrent, true, ObjectGuid.InvalidObjectGuid);
                }
            }
            catch (Exception gers)
            {
                NiecException.PrintMessage("FailedCallBookSleep Error");
                NiecException.WriteLog("FailedCallBookSleep: " + NiecException.NewLine + NiecException.LogException(gers), true, false, false);
            }

            this_alarm = AlarmManager.Global.AddAlarm(3f, TimeUnit.Hours, new AlarmTimerCallback(FailedCallBookSleep), "FailedCallBookSleep " + mSim.FullName, AlarmType.AlwaysPersisted, null);

            return;
        }
    }
    public class TempSetActiveActor : IDisposable {

        public Sim activeActor;
        public bool noDispose;
        public PlumbBob bob;

        public TempSetActiveActor()
        { activeActor = null; noDispose = true; bob = null; }

        public TempSetActiveActor(Sim ActorSim)
        {
            activeActor = null;
            noDispose = false;
            bob = PlumbBob.Singleton;
            if (bob == null) { 
                noDispose = true; 
                return; 
            }

            activeActor = bob.mSelectedActor;
            bob.mSelectedActor = ActorSim;
        }

        public static TempSetActiveActor Run(Sim Actor)
        {
            return new TempSetActiveActor(Actor);
        }

        public static TempSetActiveActor SetAndRun(TempSetActiveActor TempSAA, Sim Actor)
        {
            if (TempSAA == null)
                throw new ArgumentNullException("TempSAA");

            if (TempSAA == Empty)
                return TempSAA;

            if (TempSAA.bob == null)
            {
                TempSAA.bob = PlumbBob.Singleton;
                if (TempSAA.bob == null)
                {
                    TempSAA.noDispose = true;
                    return TempSAA;
                }
            }

            if (Actor == NFinalizeDeath.ActiveActor)
            {
                TempSAA.activeActor = null;
                TempSAA.noDispose = true;
                return TempSAA;
            }


            TempSAA.activeActor = TempSAA.bob.mSelectedActor;
            TempSAA.bob.mSelectedActor = Actor;
            TempSAA.noDispose = false;

            return TempSAA;
        }
        public void Dispose()
        {
            if (this == Empty || noDispose || bob == null) 
                return;
            //try
            //{
            //    bob.mSelectedActor = activeActor;
            //    activeActor = null; noDispose = true; bob = null;
            //}
            //catch (ResetException)
            //{ throw; }
            //catch { }
            bob.mSelectedActor = activeActor;
            activeActor = null; noDispose = true; bob = null;
        }
        public static readonly TempSetActiveActor Empty = new TempSetActiveActor();
    }

    public class TempSetActiveActorAndHousehold : IDisposable
    {
        public Sim activeActor;
        public Household currentHousehold;
        public bool noDispose;
        public PlumbBob bob;

        public TempSetActiveActorAndHousehold()
        { activeActor = null; currentHousehold = null; noDispose = true; bob = null; }

        public TempSetActiveActorAndHousehold(Sim ActorSim)
        {
            activeActor = null;
            currentHousehold = null;
            noDispose = false;
            bob = PlumbBob.Singleton;

            if (bob == null)
            {
                noDispose = true;
                return;
            }

            currentHousehold = PlumbBob.sCurrentNonNullHousehold;
            activeActor = bob.mSelectedActor;

            bob.mSelectedActor = ActorSim;

            if (ActorSim != null)
                PlumbBob.sCurrentNonNullHousehold = ActorSim.Household;
            else 
                PlumbBob.sCurrentNonNullHousehold = null;
        }

        public static TempSetActiveActorAndHousehold Run(Sim Actor)
        {
            return new TempSetActiveActorAndHousehold(Actor);
        }

        public static TempSetActiveActorAndHousehold SetAndRun(TempSetActiveActorAndHousehold TempSAAAH, Sim Actor)
        {
            if (TempSAAAH == null)
                throw new ArgumentNullException("TempSAAAH");

            if (TempSAAAH == Empty)
                return TempSAAAH;

            if (TempSAAAH.bob == null)
            {
                TempSAAAH.bob = PlumbBob.Singleton;
                if (TempSAAAH.bob == null)
                {
                    TempSAAAH.noDispose = true;
                    return TempSAAAH;
                }
            }

            if (Actor == NFinalizeDeath.ActiveActor)
            {
                TempSAAAH.activeActor = null;
                TempSAAAH.noDispose = true;
                return TempSAAAH;
            }

            TempSAAAH.currentHousehold = PlumbBob.sCurrentNonNullHousehold;
            TempSAAAH.activeActor = TempSAAAH.bob.mSelectedActor;

            TempSAAAH.bob.mSelectedActor = Actor;

            if (Actor != null)
                PlumbBob.sCurrentNonNullHousehold = Actor.Household;
            else 
                PlumbBob.sCurrentNonNullHousehold = null;

            TempSAAAH.noDispose = false;
            return TempSAAAH;
        }

        public void Dispose()
        {
            if (this == Empty || noDispose || bob == null)
                return;

            bob.mSelectedActor = activeActor;
            PlumbBob.sCurrentNonNullHousehold = currentHousehold;

            activeActor = null; currentHousehold = null; noDispose = true; bob = null;
        }

        public static readonly TempSetActiveActorAndHousehold Empty = new TempSetActiveActorAndHousehold();
    }

    public class SafeSimUpdate : IDisposable {

        private static readonly SafeSimUpdate Empty = new SafeSimUpdate();

        SimUpdate _SimUpdate;
        Sim _ActorSim;



        public SafeSimUpdate() { _SimUpdate = null; _ActorSim = null; }

        public SafeSimUpdate(Sim ActorSim, SimUpdate ActorSimUpdate) {
            _ActorSim = ActorSim;
            _SimUpdate = ActorSimUpdate;
            if (ActorSim != null && ActorSimUpdate != null)
            {
                Simulator.DestroyObject(ActorSim.mSimUpdateId);
                ActorSim.mSimUpdateId = new ObjectGuid(0);
            }
        }

        public void Dispose()
        {
            if (_SimUpdate != null && !NiecRunCommand.GameObjectHasDestroyed(_ActorSim)) {
                _ActorSim.mSimUpdateId = Simulator.AddObject(_SimUpdate);
            }
            _SimUpdate = null;
            _ActorSim = null;
        }

        public static SafeSimUpdate Run(Sim Actor)
        {
            if (Actor == null)
                return Empty;

            var simUpdate = NFinalizeDeath.GetSimUpdate(Actor);
            if (simUpdate == null)
                return Empty;

            return new SafeSimUpdate(Actor, simUpdate);
        }
    }

    public class NiecCleanClass
    {

    }

    [Persistable]
    public class NContext
    {
        public object TaskContext;
        public object FieldData;
        public object TaskFieldReference;
        public NContext() { TaskContext = null; FieldData = null; TaskFieldReference = null; }
    }
    //[Persistable]
    //public class NContextIndex
    //{
    //    public int FrameIndex;
    //    public int FieldIndex;
    //    public NContextIndex() { FrameIndex = 0; FieldIndex = 0; }
    //}

    public class HelperNraTask : ITask
    {
        public bool Sata = false;

        public virtual bool Sitso(object ors)
        {
            Type type = ors.GetType();
            //Debugger.IsLogging();
            return type != null && Sata;
        }

        public virtual void Ayoa()
        {
            if (Sitso(this))
                NiecException.PrintMessage("Hello: " + Sata);
        }
        public string ClassName
        {
            get
            {
                try
                {
                    throw new NiecModException();
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog(ex.ToString(), true, true, false);
                } return "";
            }
        }

        public ScriptExecuteType ExecuteType
        {
            get
            {
                try
                {
                    throw new NiecModException();
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog(ex.ToString(), true, true, false);
                } return ScriptExecuteType.Task;
            }
        }

        public ObjectGuid ObjectId
        {
            get
            {
                try
                {
                    throw new NiecModException();
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog(ex.ToString(), true, true, false);
                }
                return new ObjectGuid(444);
            }
            set
            {
                
            }
        }

        public void Simulate()
        {
            try
            {
                throw new NiecModException();
            }
            catch (Exception ex)
            {
                NiecException.WriteLog(ex.ToString(), true, true, false);
            }
            if (Simulator.CheckYieldingContext(false))
            Simulator.Sleep(uint.MaxValue);
        }

        public void Stop()
        {
            try
            {
                throw new NiecModException();
            }
            catch (Exception ex)
            {
                NiecException.WriteLog(ex.ToString(), true, true, false);
            }
        }

        public void Dispose()
        {
            try
            {
                throw new NiecModException();
            }
            catch (Exception ex)
            {
                NiecException.WriteLog(ex.ToString(), true, true, false);
            }
        }
    }

    public class CloueObject
    {
        public object _value = null;

        public object _hash = 0;

        public object[] _valuelist = null;

        public unsafe void* _ptrvalue = null;

        public virtual object SelfHelloWorld(object[] args)
        {
            return true;
        }

        public CloueObject() { }
        public CloueObject(object value)
        { 
            _value = value;
            if (_value != null)
            {
                _hash = _value.GetHashCode();
            }
        }

        public CloueObject CopyToObject()
        { return MemberwiseClone() as CloueObject; }

        public static object CloueToObject(object value)
        {
            if (value == null) return null;

            return new CloueObject(value).CopyToObject()._value;
        }

    }



    public class NiecObjectPlus : EventArgs, IAlarmOwner
    {
        public string KeyName = "Default";

        public object Value = null;

        public object TwoValue = null;

        public FieldInfo ValueField = null;


        public virtual void Dispose_()
        {
            ValueField = null;
            Value = null;
            KeyName = null;
            _hash = 0;
            ValueList = null;
        }

        protected object _hash = 0;

        public object HashCode
        {
            get {
                return _hash;
            }
        }

        public virtual void Update() {
            //_hash = Value.GetHashCode;
        }

        public object[] ValueList = null;

        public virtual object RunValueArgs(params object[] args)
        {
            return null;
        }

    }





    public class NiecObjectPlusWithTask : EventArgs, IAlarmOwner, ITask
    {
        public string KeyName = "Default";

        public object ValueResult = null;

        public object Value = null;

        public object Hash = 0;

        public ObjectGuid mObjectGuidId;

        public object[] ValueList = null;

        public virtual object RunValueArgs(params object[] args)
        {
            return null;
        }

        public virtual string ClassName
        {
            get { return GetType().ToString(); }
        }

        public virtual ScriptExecuteType ExecuteType
        {
            get { return ScriptExecuteType.None; }
        }

        public virtual ObjectGuid ObjectId
        {
            get
            {
                return mObjectGuidId;
            }
            set
            {
                mObjectGuidId = value;
            }
        }

        public virtual void Simulate() 
        { 
            ValueResult = RunValueArgs(ValueList); 
            Simulator.DestroyObject(mObjectGuidId); 
        }

        public virtual void Stop() { }

        public virtual void Dispose() { }
    }

    [Persistable]
    public class HelperNra : IPersistPostLoad
    {
        //[PersistableStatic]
        public static List<HelperNra> HelperNraLists = new List<HelperNra>();

        public HelperNra() {
            if (HelperNraLists != null)
                HelperNraLists.Add(this);
        }

        ~HelperNra()
        {
            //StyledNotification.Show(new StyledNotification.Format("HelperNra Done Dispose.", StyledNotification.NotificationStyle.kGameMessagePositive));
            Dispose(true);
        }
        public void Dispose()
        {
            Dispose(false);
        }
        public void Dispose(bool fromDtor)
        {
            if (HelperNraLists != null)
                HelperNraLists.Remove(this);
            this_alarm = AlarmHandle.kInvalidHandle;
            malarm = AlarmHandle.kInvalidHandle;
            malarmx = AlarmHandle.kInvalidHandle;
            mSim = null;
            mSimdesc = null;
            mdeathtype = SimDescription.DeathType.None;
            mHouseVeri3 = Vector3.Invalid;
            if (!fromDtor)
            {
                //GC.SuppressFinalize(this);
            }
        }
        

        public AlarmHandle this_alarm = AlarmHandle.kInvalidHandle;

        public AlarmHandle malarm = AlarmHandle.kInvalidHandle;

        public AlarmHandle malarmx = AlarmHandle.kInvalidHandle;

        public static Urnstone TFindGhostsGrave(SimDescription sim)
        {
            if (sim == null) return null;
            foreach (Urnstone urnstone in NFinalizeDeath.SC_GetObjects<Urnstone>())
            {
                if (object.ReferenceEquals(urnstone.DeadSimsDescription, sim))
                {
                    return urnstone;
                }
            }

            return null;
        }

        public Sim mSim = null;

        public SimDescription mSimdesc = null;

        public SimDescription.DeathType mdeathtype = SimDescription.DeathType.OldAge;

        public Vector3 mHouseVeri3 = Vector3.Invalid;

        public unsafe static char* TestUnsafe01(int argc, char* str)
        {
            int ads = str->CompareTo('a');
            str[30 + ads* argc] = 'F';
            str++;
            str += 's';

           
            return str;
        }


        public unsafe static string TestUnsafe(string Sta)
        {
            fixed (char* str = Sta)
            {
                char* stra =TestUnsafe01(Sta.Length, str);
                if (stra != null)
                    return new string(stra);
            }
            return null;
        }

        public void OpenDGS_UnLoadSimDispose()
        {
            try
            {
                AlarmManager.Global.RemoveAlarm(this_alarm);
                this_alarm = AlarmHandle.kInvalidHandle;
            }
            catch (Exception)
            { }
            if (mSimdesc == null) return;
            //Distsae(true, null);
            if (mSimdesc.Household == NFinalizeDeath.ActiveHousehold) {
                try{mSimdesc.Fixup();}
                catch (Exception){}
                Dispose(true);
                return; 
            }
            NFinalizeDeath.SimDescCleanse(mSimdesc, mSimdesc.Household != NFinalizeDeath.ActiveHousehold);
            Dispose(true);
            return;
        }













        public void CheckKillSimNotUrnstone()
        {
            //if (mSim == null) return;
            //NFinalizeDeath.DKill(mSim.SimDescription);
            //StyledNotification.Show(new StyledNotification.Format("HelperNra: " + mSim.Name + " ??? Check ??? :)", StyledNotification.NotificationStyle.kGameMessagePositive));
            
            Urnstone urnstone = Urnstone.CreateGrave(mSim.SimDescription, false, false);
            if (urnstone == null)
            {
                return;
            }
            if (!GlobalFunctions.PlaceAtGoodLocation(urnstone, new World.FindGoodLocationParams(mSim.Position), true))
            {
                return;
            }
            urnstone.OnHandToolMovement();
            
        }


        public void FailedCallBookSleep()
        {
            if (mSimdesc == null) return;
            if (mSim == null) return;
            try
            {
                AlarmManager.Global.RemoveAlarm(malarm);
                mSim.SimRoutingComponent.DisableDynamicFootprint();
                mSim.SetPosition(mHouseVeri3);
                mSim.SimRoutingComponent.EnableDynamicFootprint();

            }
            catch
            { }

            finally
            {
                malarmx = AlarmManager.Global.AddAlarm(3f, TimeUnit.Hours, new AlarmTimerCallback(FailedCallBookSleep), "FailedCallBookSleep", AlarmType.AlwaysPersisted, null);

            }

            return;
        }

        public void ResetReset()
        {
            try
            {
                if (mSimdesc == null) return;
                if (mSim == null) return;
                Household household = mSim.SimDescription.Household;
                if (household == Household.ActiveHousehold)
                {
                    /*
                    if (malarm != AlarmHandle.kInvalidHandle)
                    {
                        AlarmManager.Global.RemoveAlarm(malarm);
                    }
                     * */



                    mSimdesc.AgingEnabled = false;
                    mSimdesc.AgingState.ResetAndExtendAgingStage(0f);
                    if (mSimdesc.CreatedSim != null)
                    {
                        mSimdesc.CreatedSim.Autonomy.IncrementAutonomyDisabled();
                    }
                    
                    /*malarm = */AlarmManager.Global.AddAlarm(1f, TimeUnit.Hours, new AlarmTimerCallback(ResetReset), "Helper Name IRESET", AlarmType.AlwaysPersisted, null);
                }
                else
                {
                    return;
                }
            }
            catch (NullReferenceException)
            { }
            
        }

        
       

        public void CheckKillSimNotUrnstonePro()
        {
            
            //if (mSim == null) return;
            try
            {
                if (AlarmManager.Global != null)
                {
                    AlarmManager.Global.RemoveAlarm(this_alarm);
                    this_alarm = AlarmHandle.kInvalidHandle;
                }
            }
            catch (ResetException)
            { throw; }
            catch (Exception)
            { }

            //if (mSimdesc == null && mSim != null)
            //{
            //    mSimdesc = mSim.mSimDescription; 
            //}

            if (mSimdesc == null || mSimdesc == ListCollon.NullSimSimDescription)
            {
                Dispose(true);
                return;
            }

            //if (mSim == null)
            //{
            //    mSim = mSimdesc.mSim; 
            //}

            if (mSim == null)
            {
                Dispose(true);
                return;
            }

            if (AssemblyCheckByNiec.IsInstalled("OpenDGS") && !mSimdesc.IsValidDescription && mSimdesc.OccultManager == null)
            {
                Dispose(true);
                return;
            }

            try
            {
                var iq = mSim.InteractionQueue;
                if (iq != null && (iq.HasInteractionOfType(ExtKillSimNiec.Singleton) || AssemblyCheckByNiec.IsInstalled("OpenDGS") && iq.HasInteractionOfType(Urnstone.KillSim.Singleton)))
                {
                    while (AlarmManager.Global == null)
                    {
                        Simulator.Sleep(0);
                    }
                    if (mSimdesc == ListCollon.NullSimSimDescription)
                        return;
                    this_alarm = AlarmManager.Global.AddAlarm(30f, TimeUnit.Hours, new AlarmTimerCallback(CheckKillSimNotUrnstonePro), "CheckKillSimNotUrnstonePro " + mSim.Name, AlarmType.AlwaysPersisted, null);
                    return;
                }
            }
            catch (ResetException)
            { throw; }
            catch (Exception)
            { }

            try
            {
                if (NTunable.kHelperNraNoCheckKillSim)
                {
                    try
                    {
                        Household household = mSimdesc.Household;
                        if (household != Household.ActiveHousehold)
                        {
                            mSimdesc.SetDeathStyle(mdeathtype, false);

                            mSimdesc.IsGhost = true;
                            mSimdesc.ShowSocialsOnSim = false;
                            mSimdesc.IsNeverSelectable = true;
                            mSimdesc.Contactable = false;



                            SimDescription taroa = mSimdesc;
                            try
                            {
                                taroa.mDeathStyle = mdeathtype;
                            }
                            catch (Exception)
                            { }
                            if (TFindGhostsGrave(mSimdesc) == null)
                            {
                                Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                                if (mGravebackup != null)
                                {
                                    try
                                    {
                                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(mSim);
                                        if (!mSim.HasBeenDestroyed)
                                            NFinalizeDeath.ForceDestroyObject(mSim, false);
                                        SpeedTrap.Sleep();
                                    }
                                    catch (Exception)
                                    { }
                                    if (!NFinalizeDeath.TryInteHelper(mGravebackup))
                                    {
                                        if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                        {
                                            //if (PlumbBob.sSingleton.mSelectedActor.Inventory != null && !PlumbBob.sSingleton.mSelectedActor.Inventory.TryToAdd(mGravebackup))
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
                                                mGravebackup.SetPosition(lotwt.Position);
                                            }
                                            catch
                                            { }
                                        }
                                    }
                                    mGravebackup.OnHandToolMovement();
                                    mGravebackup.FadeIn(false, 5f);
                                    //mGravebackup.FogEffectStart();
                                    try
                                    {
                                        taroa.Fixup();
                                    }
                                    catch (Exception)
                                    { }

                                }
                                else SafeNRaas.NRUrnstones_CreateGrave(mSimdesc, mdeathtype, true, false);
                            }
                            StyledNotification.Show(new StyledNotification.Format("CheckKillSimNotUrnstonePro: " + mSimdesc.FullName + " Ok :)", StyledNotification.NotificationStyle.kGameMessagePositive));

                        }
                    }
                    catch (NullReferenceException)
                    {
                        mSimdesc.SetDeathStyle(mdeathtype, false);

                        mSimdesc.IsGhost = true;
                        mSimdesc.ShowSocialsOnSim = false;
                        mSimdesc.IsNeverSelectable = true;
                        mSimdesc.Contactable = false;

                        SimDescription taroa = mSimdesc;
                        try
                        {
                            taroa.mDeathStyle = mdeathtype;
                        }
                        catch (Exception)
                        { }
                        if (TFindGhostsGrave(mSimdesc) == null)
                        {
                            Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                            if (mGravebackup != null)
                            {
                                try
                                {
                                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(mSim);
                                    if (!mSim.HasBeenDestroyed)
                                        NFinalizeDeath.ForceDestroyObject(mSim, false);
                                    SpeedTrap.Sleep();
                                }
                                catch (Exception)
                                { }
                                if (!NFinalizeDeath.TryInteHelper(mGravebackup))
                                {
                                    if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                    {
                                        //if (PlumbBob.sSingleton.mSelectedActor.Inventory != null && !PlumbBob.sSingleton.mSelectedActor.Inventory.TryToAdd(mGravebackup))
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
                                            mGravebackup.SetPosition(lotwt.Position);
                                        }
                                        catch
                                        { }
                                    }
                                }
                                mGravebackup.OnHandToolMovement();
                                mGravebackup.FadeIn(false, 5f);
                                //mGravebackup.FogEffectStart();
                                try
                                {
                                    taroa.Fixup();
                                }
                                catch (Exception)
                                { }

                            }
                            else SafeNRaas.NRUrnstones_CreateGrave(mSimdesc, mdeathtype, true, false);
                        }
                        StyledNotification.Show(new StyledNotification.Format("CheckKillSimNotUrnstonePro: " + mSimdesc.FullName + " Ok :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                    }

                }
                else
                {
                    try
                    {
                        Household household = mSim.SimDescription.Household;
                        if (household != Household.ActiveHousehold)
                        {
                            if (mSimdesc.DeathStyle == SimDescription.DeathType.None)
                            {
                                try
                                {
                                    KillPro.CleanseGenealogy(mSimdesc);
                                    KillPro.RemoveSimDescriptionRelationships(mSimdesc);
                                }
                                catch (NullReferenceException)
                                { }

                                mSimdesc.SetDeathStyle(mdeathtype, false);

                                mSimdesc.IsGhost = true;
                                mSimdesc.ShowSocialsOnSim = false;
                                mSimdesc.IsNeverSelectable = true;
                                mSimdesc.Contactable = false;
                                SimDescription taroa = mSimdesc;
                                try
                                {
                                    taroa.mDeathStyle = mdeathtype;
                                }
                                catch (Exception)
                                { }
                                if (TFindGhostsGrave(mSimdesc) == null)
                                {
                                    Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                                    if (mGravebackup != null)
                                    {
                                        try
                                        {
                                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(mSim);
                                            if (!mSim.HasBeenDestroyed)
                                                mSim.Destroy();
                                            SpeedTrap.Sleep();
                                        }
                                        catch (Exception)
                                        { }
                                        if (!NFinalizeDeath.TryInteHelper(mGravebackup))
                                        {
                                            if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                            {
                                                //if (PlumbBob.sSingleton.mSelectedActor.Inventory != null && !PlumbBob.sSingleton.mSelectedActor.Inventory.TryToAdd(mGravebackup))
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
                                                    mGravebackup.SetPosition(lotwt.Position);
                                                }
                                                catch
                                                { }
                                            }
                                        }
                                        mGravebackup.OnHandToolMovement();
                                        mGravebackup.FadeIn(false, 5f);
                                        //mGravebackup.FogEffectStart();
                                        try
                                        {
                                            taroa.Fixup();
                                        }
                                        catch (Exception)
                                        { }

                                    }
                                    else SafeNRaas.NRUrnstones_CreateGrave(mSimdesc, mdeathtype, true, false);
                                }
                                StyledNotification.Show(new StyledNotification.Format("CheckKillSimNotUrnstonePro: " + mSim.SimDescription.FullName + " Ok :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                            }

                        }
                    }
                    catch (NullReferenceException)
                    {
                        mSimdesc.SetDeathStyle(mdeathtype, false);
                        mSimdesc.IsGhost = true;
                        mSimdesc.ShowSocialsOnSim = false;
                        mSimdesc.IsNeverSelectable = true;
                        mSimdesc.Contactable = false;
                        SimDescription taroa = mSimdesc;
                        try
                        {
                            taroa.mDeathStyle = mdeathtype;
                        }
                        catch (Exception)
                        { }
                        if (TFindGhostsGrave(mSimdesc) == null)
                        {
                            Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                            if (mGravebackup != null)
                            {
                                try
                                {
                                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(mSim);
                                    if (!mSim.HasBeenDestroyed)
                                        mSim.Destroy();
                                    SpeedTrap.Sleep();
                                }
                                catch (Exception)
                                { }
                                if (!NFinalizeDeath.TryInteHelper(mGravebackup))
                                {
                                    if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                    {
                                        //if (PlumbBob.sSingleton.mSelectedActor.Inventory != null && !PlumbBob.sSingleton.mSelectedActor.Inventory.TryToAdd(mGravebackup))
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
                                            mGravebackup.SetPosition(lotwt.Position);
                                        }
                                        catch
                                        { }
                                    }
                                }
                                mGravebackup.OnHandToolMovement();
                                mGravebackup.FadeIn(false, 5f);
                                //mGravebackup.FogEffectStart();
                                try
                                {
                                    taroa.Fixup();
                                }
                                catch (Exception)
                                { }

                            }
                            else SafeNRaas.NRUrnstones_CreateGrave(mSimdesc, mdeathtype, true, false);
                        }
                        StyledNotification.Show(new StyledNotification.Format("CheckKillSimNotUrnstonePro: " + mSimdesc.FullName + " Ok :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                    }
                }


                /*
                Urnstone urnstone = TFindGhostsGrave(mSim.SimDescription);
                if (urnstone == null)
                {
                    Urnstones.CreateGrave(mSim.SimDescription, mdeathtype, true, false);
                }
                */
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception gers)
            {

                if (gers is ResetException)
                {
                    throw;
                }
                StyledNotification.Show(new StyledNotification.Format("CheckKillSimNotUrnstonePro: " + " Failed :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                NiecException.WriteLog("CheckKillSimNotUrnstonePro: " + NiecException.NewLine + NiecException.LogException(gers), true, false, false);
            }
            finally
            {
                try
                {
                   
                    if (TFindGhostsGrave(mSimdesc) == null)
                    {
                        if (mSimdesc.Household == NFinalizeDeath.ActiveHousehold) goto end; // Why error CS0131: return; in finally is not allowed.
                        if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && mSim == PlumbBob.sSingleton.mSelectedActor)
                        {
                            LotManager.SelectNextSim();
                        }
                        SimDescription taroa = mSimdesc;
                        try
                        {
                            taroa.mDeathStyle = mdeathtype;
                        }
                        catch (Exception)
                        { }
                        Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                        if (mGravebackup != null)
                        {
                            try
                            {
                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(mSim);
                                if (!mSim.HasBeenDestroyed)
                                    mSim.Destroy();
                                SpeedTrap.Sleep();
                            }
                            catch (Exception)
                            { }





                            if (!NFinalizeDeath.TryInteHelper(mGravebackup))
                            {


                                if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && NFinalizeDeath.MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
                                {
                                    //if (PlumbBob.sSingleton.mSelectedActor.Inventory != null && !PlumbBob.sSingleton.mSelectedActor.Inventory.TryToAdd(mGravebackup))
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
                                        mGravebackup.SetPosition(lotwt.Position);
                                    }
                                    catch
                                    { }
                                }
                            }
                            mGravebackup.OnHandToolMovement();
                            mGravebackup.FadeIn(false, 5f);
                            //mGravebackup.FogEffectStart();
                            try
                            {
                                taroa.Fixup();
                            }
                            catch (Exception)
                            { }
                            
                        }
                        
                    }
                
                }
                catch (Exception)
                { }
            end:;
            }
        }

        public ThumbnailKey GetThumbnailForGameObjectATSARS(ObjectGuid objGuid, ThumbnailSize size, int index, bool bForceUseSimDescription)
        {
            GameObject @object = GameObject.GetObject<GameObject>(objGuid);
            if (@object == null)
            {
                return new ThumbnailKey(ResourceKey.kInvalidResourceKey, ThumbnailSize.Medium);
            }
            Sim sim = mSim;
            if (sim == null || sim.SimDescription == null)
            {
                ThumbnailKey thumbnailKey = @object.GetThumbnailKey();
                thumbnailKey.mSize = size;
                thumbnailKey.mCamera = ThumbnailCamera.Body;
                return thumbnailKey;
            }
            if (bForceUseSimDescription)
            {
                SimOutfit currentOutfit = sim.CurrentOutfit;
                ThumbnailKey result = new ThumbnailKey(currentOutfit, 0, ThumbnailSize.Large, ThumbnailCamera.Default);
                if (sim.SimDescription.IsGhost)
                {
                    result.mIndex = (int)(5u + sim.SimDescription.DeathStyle);
                }
                return result;
            }
            return sim.SimDescription.GetThumbnailKey(ThumbnailSize.Large, index);
        }

        public void PersistPostLoad()
        {
            AlarmHandle ah = this_alarm;
            if (mSimdesc != null)
            {
                if (mSimdesc.mOutfits == null && mSimdesc.mSimDescriptionId == 0)
                { 
                    Dispose();
                    if (AlarmManager.Global != null)
                        AlarmManager.Global.RemoveAlarm(ah);
                }
                else mSim = mSimdesc.mSim;
            }
            else
            {
                Dispose();
                if (AlarmManager.Global != null)
                    AlarmManager.Global.RemoveAlarm(ah);
            }
        }
    }

    public class nonYieldRunFunc
    {
        private static List<object> GCSafe = new List<object>(100); // fixed Game Crash i know GC bug
        private static bool runningClearGC = false;

        private nonYieldRunFunc(NFinalizeDeath.Function func)
        {
            if (func == null || (int)func.method_ptr == 0)
                throw new ArgumentNullException();

            var temp = func;
            NFinalizeDeath.Assert(GCSafe != null && GCSafe._items != null, "GCSafe or GCSafe.Items == NULL!");

            GCSafe.Add(new object[] { this, temp });
            temp();
            ClearGC();
        }

        public static nonYieldRunFunc RunFunc(NFinalizeDeath.Function func)
        {
            if (func == null || (int)func.method_ptr == 0)
                throw new ArgumentNullException();

            return new nonYieldRunFunc(func);
        }

        public static void ClearGC()
        {
            if (runningClearGC)
                return;

            runningClearGC = true;
            NiecTask.Perform(delegate
            {
                for (int i = 0; i < 1500; i++)
                {
                    Simulator.Sleep(0);
                }
                NFinalizeDeath.Assert(GCSafe != null && GCSafe._items != null, "ClearGC() GCSafe or GCSafe.Items == NULL!");
                runningClearGC = false;
                GCSafe.Clear();
            });
        }
    }

    /// <summary>
    /// This a Helper Morun By Niec 
    /// C++
    /// NFinalizeDeath.cpp and NFinalizeDeath.h
    /// </summary>
    
    public static class NFinalizeDeath
    {
        internal static bool cache_MsCorlibIsModifed = false;
        internal static bool sMsCorlibIsModifed = false;
        internal static bool MsCorlibIsMod()
        {
            if (!cache_MsCorlibIsModifed)
            {
                cache_MsCorlibIsModifed = true;
                sMsCorlibIsModifed = MsCorlibModifed_GetExLists() != null;
            }
            return sMsCorlibIsModifed;
        }
        public static List<Exception> MsCorlibModifed_GetExLists()
        {
            try
            {
                Type type = typeof(SystemException); 
                if (type != null)
                {
                    FieldInfo mField = type.GetField ("__IListEx", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (mField != null)
                    {
                        return mField.GetValue (null) as List<Exception>;
                    }
                }
            }
            catch (Exception ex)
            { Assert("getexlists\n"+ex.ToString()); }

            return null;
        }

        public static Exception MsCorlibModifed_GetLastException () // unprotected mono mscorlib 
        {
            var CacheListEx = MsCorlibModifed_GetExLists ();
            if (CacheListEx == null || CacheListEx.Count == 0 || CacheListEx._items == null) return null;
            try
            {
                return CacheListEx._items [CacheListEx.Count - 1];
            }
            catch (IndexOutOfRangeException) // Mono bug?
            {
                //if (CacheListEx._items.Length < 1) return ex;
                //return CacheListEx._items [CacheListEx._items.Length - 2];
                
                return null;
            }
            
        }

        public static bool is_d_scobjectscmd = false;

        public static string MsCorlibModifed_Exlists()
        {
            var CacheListEx = MsCorlibModifed_GetExLists ();
            if (CacheListEx == null || CacheListEx.Count == 0) return "The Ex Lists Empty";
            StringBuilder text = new StringBuilder();
            int nos = 0;
            text.Append("Ex Lists\n");
            foreach (var item in CacheListEx.ToArray())
            {
                nos++;
                if (item == null || item.StackTrace == null)
                {
                    continue;
                }

                //text.Append("\nNo: " + nos + "\nStack Trace:\n" + item.ToString());
                text.Append("\nNo: " + nos);

                var soc = GetExceptionBaseSource(item);
                if (soc != null && soc.Length > 0) {
                    text.Append("\nSource: " + soc + "\n" + item.ToString());
                } else {
                    text.Append("\nStack Trace:\n" + item.ToString());
                }

               // text.Append(item.ToString());
            }
            text.Append("\nEnd Ex Lists");
            //Message.WriteLog(text.ToString());
           // NiecException.WriteLog(text.ToString(), true, false, false);
            CacheListEx.Clear();
            return text.ToString();
        }
        public static int MsCorlibModifed_Exlists(bool safe)
        {
            var CacheListEx = MsCorlibModifed_GetExLists();
            if (CacheListEx == null || CacheListEx.Count == 0) return 1;
            StringBuilder text = new StringBuilder();
            int nos = 0;
            text.Append("Ex Lists\n");
            foreach (var item in CacheListEx.ToArray())
            {
                nos++;
                if (item == null || item.StackTrace == null)
                {
                    continue;
                }
                if (safe)
                    text.Append("\nNo: " + nos + "\nStack Trace:\n" + item.ToString());
                else
                {
                    text.Append("\nNo: " + nos);
                    var soc = GetExceptionBaseSource(item);
                    if (soc != null && soc.Length > 0)
                    {
                        text.Append("\nSource: " + soc + "\n" + item.ToString());
                    }
                    else
                    {
                        text.Append("\nStack Trace:\n" + item.ToString());
                    }
                }
            }
            text.Append("\nEnd Ex Lists");
            uint fileHandle = 0;
            string s = Simulator.CreateExportFile(ref fileHandle, "NiecModExList");
            if (fileHandle == 0)
                return 2;
            text.Append("\nFile Name: " + s + "\nDate: " + DateTime.Now.ToString());
            text.Append('\0');
            if (!Simulator.AppendToScriptErrorFile(fileHandle, text.ToString().ToCharArray()))
            {
                Simulator.CloseScriptErrorFile(fileHandle);
                return 2;
            }
            Simulator.CloseScriptErrorFile(fileHandle);
            CacheListEx.Clear();
            return 0;
        }
        public static int MsCorlibModifed_ExlistsX(bool safe, bool shouldClear)
        {
            if (!niec_native_func.cache_done_niecmod_native_debug_text_to_debugger)
                return 3;

            var CacheListEx = MsCorlibModifed_GetExLists();
            if (CacheListEx == null || CacheListEx.Count == 0) 
                return 1;

            StringBuilder text = new StringBuilder();
            int nos = 0;

            foreach (var item in CacheListEx.ToArray())
            {
                nos++;
                if (item == null || item.StackTrace == null)
                {
                    continue;
                }

                text.Append("Start ELOG\n");

                if (safe)
                    text.Append("\nNo: " + nos + "\nStack Trace:\n" + item.ToString());
                else
                {
                    text.Append("\nNo: " + nos);
                    var soc = GetExceptionBaseSource(item);
                    if (soc != null && soc.Length > 0)
                    {
                        text.Append("\nSource: " + soc + "\n" + item.ToString());
                    }
                    else
                    {
                        text.Append("\nStack Trace:\n" + item.ToString());
                    }
                }

                text.Append("\nEnd");

                niec_native_func.OutputDebugString(text.ToString());
                text = new StringBuilder();
            }
            if (shouldClear)
                CacheListEx.Clear();
            return 0;
        }
        public static bool IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");

        [Obsolete("", true)]
        public static bool IsGrimReaperService_OutService(SimDescription sim, out GrimReaper grimService)
        {
            grimService = null;
            GrimReaper grimReaperService = GrimReaper.sGrimReaper;
            if (grimReaperService != null) {
                return true;
            }
            return false;
        }
        public static bool SimDescIsGrimReaperService(SimDescription sim, bool force)
        {
            if (sim == null) 
                return false;

            GrimReaper grimReaperService = GrimReaper.sGrimReaper;
            if (grimReaperService == null && Services.sAllServices != null)
            {
                foreach (var item in Services.sAllServices)
                {
                    if (item == null)
                        continue;
                    if (item is GrimReaper) {
                        grimReaperService = item as GrimReaper;
                        GrimReaper.sGrimReaper = item as GrimReaper;
                        break;
                    }
                }
            }
            if (grimReaperService != null)// && grimReaperService.IsSimDescriptionInPool(sim))
            {
                if (!force && grimReaperService.mPool != null && grimReaperService.IsSimDescriptionInPool(sim))
                    return true;
                else if ((sim.Service as GrimReaper ?? sim.CreatedByService as GrimReaper) != null)//is GrimReaper)
                {
                    try
                    {
                        GrimReaper serv = (sim.Service as GrimReaper ?? sim.CreatedByService as GrimReaper);
                        if (serv != null && serv.mPool != null)
                            for (int i = 0; i < 10; i++)
                                serv.mPool.Remove(sim);
                    }
                    catch (ResetException)
                    { throw; }
                    catch { }

                    sim.Service = null;
                    sim.CreatedByService = null;

                    FixAllHouseholdMembers();
                    if (sim.IsValidDescription)
                    {




                        try
                        {
                            sim.Fixup();

                            if (sim.mOutfits == null)
                            {
                                sim.mOutfits = new OutfitCategoryMap(); 
                                ResourceKey key = ResourceKey.CreateOutfitKey("YmDeath", 0u);
                                SimOutfit simOutfit = new SimOutfit(key);
                                if (simOutfit.IsValid)
                                {
                                    SimBuilder simBuilder = new SimBuilder();
                                    simBuilder.UseCompression = true;
                                    OutfitUtils.SetOutfit(simBuilder, simOutfit, null);
                                    ResourceKey keyOutfit = simBuilder.CacheOutfit("Service_" + "YmDeath");
                                    SimOutfit keyOutfit2 = new SimOutfit(keyOutfit);
                                    sim.AddOutfit(keyOutfit2, OutfitCategories.Everyday, true);
                                }
                            }    
                            else
                            {
                                SimOutfit occult = sim.GetOutfit(OutfitCategories.Everyday, 0);
                                if (occult == null || !occult.IsValid)
                                {
                                    sim.mOutfits.Clear();
                                    sim.mOutfits = new OutfitCategoryMap();

                                    ResourceKey key = ResourceKey.CreateOutfitKey("YmDeath", 0u);
                                    SimOutfit simOutfit = new SimOutfit(key);
                                    if (simOutfit.IsValid)
                                    {
                                        SimBuilder simBuilder = new SimBuilder();
                                        simBuilder.UseCompression = true;
                                        OutfitUtils.SetOutfit(simBuilder, simOutfit, null);
                                        ResourceKey keyOutfit = simBuilder.CacheOutfit("Service_" + "YmDeath");
                                        SimOutfit keyOutfit2 = new SimOutfit(keyOutfit);
                                        sim.AddOutfit(keyOutfit2, OutfitCategories.Everyday, true);
                                    }
                                }
                            }
                            if (sim.Genealogy == null)
                                sim.mGenealogy = new Genealogy(sim);
                            if (sim.Household == null)
                            {
                                var npcHousehold = Household.sNpcHousehold;
                                if (npcHousehold != null)
                                    Household_Add(npcHousehold, sim, true);
                                else if (Instantiator.RootIsOpenDGSInstalled)
                                {
                                    Household activeHousehold = ActiveHousehold;
                                    foreach (Household household in SC_GetObjects<Household>()) // Safe // Dont Use Household.sHouseholdList
                                    {
                                        if (household != activeHousehold && household.mMembers != null)
                                        {
                                            Household_Add(household, sim, true);
                                            break;
                                        }
                                    }
                                }
                                else return false;
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        {
                            try
                            {
                                SimDescCleanse(sim, true, false);
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }  
                            return false;
                        }

                        sim.IsGhost = false;
                        sim.mDeathStyle = SimDescription.DeathType.None;


                        if (grimReaperService.mPool == null)
                            grimReaperService.mPool = new List<SimDescription>();
                        if (!grimReaperService.mPool.Contains(sim))
                            grimReaperService.mPool.Add(sim);
                        return true;
                    }
                }
            }
            
            return false;
        }
        public static List<Lot> GetAllResidentialLots()
        {
            List<Lot> lotList = null;
            foreach (Lot allLot in LotManager.AllLots)
            {
                if (allLot.IsResidentialLot)
                {
                    Lazy.Allocate(ref lotList);
                    lotList.Add(allLot);
                }
            }
            return lotList;
        }
        public static int GetLotHouseholdLeft02()
        {
            if (LotManager.sLots == null) 
                return 0;

            int lotList = 0;
            foreach (Lot lot2 in LotManager.sLots.Values)
            {
                if (lot2 == null) continue;
                if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null && !World.LotIsEmpty(lot2.LotId) && !lot2.IsLotEmptyFromObjects())
                {
                    lotList++;
                }
                if (lotList == 0)
                {
                    if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null)
                    {
                        lotList++;
                    }
                }
            }
            return lotList;
        }

        public static int GetLotHouseholdLeft(bool bResidentiaLotOnly)
        {
            int lotList = 0;
            if (LotManager.sLots == null) 
                return lotList;
            foreach (Lot allLot in LotManager.sLots.Values)
            {
                if (allLot == null) continue;
                if (bResidentiaLotOnly)
                {
                    if (allLot.IsResidentialLot && allLot.Household == null)
                    {
                        lotList++;
                    }
                }
                else
                {
                    if (allLot.Household == null)
                    {
                        lotList++;
                    }
                }
            }
            return lotList;
        }
        internal static bool NRAAS_SP_wait = false;
        public static void NRAAS_SP(bool enable) 
        {
            Type nameNRRAS_SP = null;
            try
            {
                nameNRRAS_SP = Type.GetType("NRaas.StoryProgression,NRaasStoryProgression", false);
            }
            catch
            {
                return;
            }

            if (nameNRRAS_SP == null)
                return;

            while (NRAAS_SP_wait) 
            {
                SleepTask(10);
            }

            ITask task_StoryProgression;
            FindTaskPro("NRaas.StoryProgression", null, out task_StoryProgression);
            try
            {
                while (task_StoryProgression != null)
                {
                    NRAAS_SP_wait = true;
                    SleepTask(100);
                    FindTaskPro("NRaas.StoryProgression", null, out task_StoryProgression);
                }
            }
            finally
            {
                NRAAS_SP_wait = false;
            }


            FieldInfo fieldNRRAS_SP = nameNRRAS_SP.GetField("sMain", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (fieldNRRAS_SP == null)
            {
                niec_std.assert("nameNRRAS_SP sMain failed");
                return;
            }

            object obj = fieldNRRAS_SP.GetValue(null);
            while (obj == null)
            {
                SleepTask(10);
                obj = fieldNRRAS_SP.GetValue(null);
            }

            Type typeMain = obj.GetType();
            if (typeMain == null)
            {
                return;
            }

            FieldInfo typeMain_fieldinfo = typeMain.GetField("mInTimer", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (typeMain_fieldinfo == null)
            {
                niec_std.assert("typeMain_fieldinfo == NULL");
                return;
            }
            typeMain_fieldinfo.SetValue(obj, enable);
        }

        public static bool SimIsGRReaper(SimDescription item) {
            return item != null && (item.Service as GrimReaper ?? item.CreatedByService as GrimReaper) != null;
        }

        public static void MineCraftName()
        {
            UpdateNiecSimDescriptions(false, true, true);
            int ino = 1;
            //int ibobot = ListCollon.SafeRandomPart2.Next(2634, 543724);
            foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
            {
                if (item == null)
                    continue;

                if (!item.IsValidDescription)
                    continue;
                if (item.OccultManager == null || item.mHairColors == null)
                    continue;

                try
                {
                    if ((item.Service as GrimReaper ?? item.CreatedByService as GrimReaper) != null)
                    {

                        item.mFirstName = "Deather";
                        item.mLastName = "";
                        continue;
                    }
                    if (item.IsPet)
                    {
                        if (item.IsHorse)
                        {
                            if (item.IsUnicorn)
                            {
                                item.mFirstName = "Unicorn Horse";
                                item.mLastName = "";
                            }
                            else if (item.IsFoal)
                            {
                                item.mFirstName = "Foal Horse";
                                item.mLastName = "";
                            }
                            else
                            {
                                item.mFirstName = "Wild Horse";
                                item.mLastName = "";
                            }
                        }
                        else if (item.IsADogSpecies)
                        {
                            if (item.IsFullSizeDog)
                            {
                                item.mFirstName = "Dog";
                                item.mLastName = "";
                            }
                            else if (item.IsLittleDog)
                            {
                                item.mFirstName = "Little Dog";
                                item.mLastName = "";
                            }
                            else if (item.IsPuppy)
                            {
                                item.mFirstName = "Puppy";
                                item.mLastName = "";
                            }
                            else
                            {
                                item.mFirstName = "Dog";
                                item.mLastName = "";
                            }
                        }
                        else if (item.IsCat)
                        {
                            item.mFirstName = "Cat";
                            item.mLastName = "";
                        }
                        else if (item.IsDeer)
                        {
                            item.mFirstName = "Deer";
                            item.mLastName = "";
                        }
                        else if (item.IsRaccoon)
                        {
                            item.mFirstName = "Raccoon";
                            item.mLastName = "";
                        }
                    }
                    else if (item.IsBonehilda)
                    {
                        item.mFirstName = "Gameplay/Actors/Sim:BonehildaName";//ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString("Gameplay/Actors/Sim:BonehildaName");
                        item.mLastName = "";
                    }
                    else if (item.IsAlien)
                    {
                        item.mFirstName = "Alien";
                        item.mLastName = "";
                    }
                    else if (item.IsTimeTraveler)
                    {
                        item.mFirstName = "Time Traveler";
                        item.mLastName = "";
                    }
                    else if (item.IsFairy)
                    {
                        item.mFirstName = "Fairy Villager";
                        item.mLastName = "#" + ino;
                    }
                    else if (item.IsPlantSim)
                    {
                        item.mFirstName = "Plantman";
                        item.mLastName = "";
                    }
                    else if (item.IsMummy)
                    {
                        item.mFirstName = "Mummy";
                        item.mLastName = "";
                    }
                    else if (item.IsRobot)
                    {
                        item.mFirstName = "Robot";// + ibobot;
                        item.mLastName = "";
                        //ibobot += 458;
                    }
                    else if (item.IsVampire)
                    {
                        item.mFirstName = "Vampire";// + ibobot;
                        item.mLastName = "";
                        //ibobot += 458;
                    }
                    else if (item.IsHuman)
                    {
                        item.mFirstName = "Villager";
                        item.mLastName = "#" + ino;
                        ino++;
                    }
                    else
                    {
                        item.mFirstName = "No Name";
                        item.mLastName = "";
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
            }
        }
        public static bool IsOnVacation() {
            return IsOnVacation(true) || IsOnVacation(false);
        }
        public static bool IsOnVacation(bool EP1_Worlds)
        {
            if (EP1_Worlds)
            {
                var currentWorld = ScriptCore.GameUtils.GameUtils_GetWorldName();
                if (currentWorld >= WorldName.Egypt)
                {
                    return currentWorld <= WorldName.France;
                }
                return false;
            }
            return GameStates.IsOnVacation; // GameUtils.IsOnVacation();
        }

        // ------------------------------------------------ Force Save Game ------------------------------------------------ //
        public static string SaveLocalizeString___(string name, params object[] parameters)
        {
            return Localization.LocalizeString("Ui/Caption/Options:" + name, parameters);
        }

        public static bool SaveFileNameExists_(string fileName, bool noSubStr = false)
        {
            if (fileName == null) return false;
            foreach (string item in new WorldFileSearch(1u))
            {
                string text2 = item;
                if (!noSubStr && text2.ToLower().EndsWith(".sims3"))
                {
                    text2 = text2.Substring(0, text2.Length - 6);
                }
                if (text2.ToLower() == fileName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ForceSaveGame() {
            return ForceSaveGame(World.GetWorldFileName().Replace(".world", "") + " I" + RandomUtil.GetInt(0, 1000000, ListCollon.SafeRandomPart2));
        }

        public static bool ForceSaveGameNoDialog()
        {
            return ForceSaveGame(World.GetWorldFileName().Replace(".world", "") + " I" + RandomUtil.GetInt(0, 1000000, ListCollon.SafeRandomPart2), true);
        }

        public static string GetAddDotSims3(string saveFilePath)
        {
            if (saveFilePath == null) return null;
            //  Path
            if (!saveFilePath.EndsWith(".sims3"))
            {
                return saveFilePath + ".sims3";
            }
            return saveFilePath;
        }

        public static int ActiveHouseCount()
        {
            
            Household activehousehold = Household.ActiveHousehold;
            if (activehousehold != null)
            {
                var a = ActiveHousehold_AllSim;
                if (a != null)
                {
                    return a.Count;
                }
            }
            return 0;
        }
        public static int ActiveHouseCount2()
        {

            Household activehousehold = Household.ActiveHousehold;
            if (activehousehold != null)
            {
                RemoveNullForHouseholdMembers(activehousehold);
                var hm = activehousehold.mMembers;
                if (hm != null)
                {
                    int c = 0;
                    foreach (var item in hm.mAllSimDescriptions)
                    {
                        if (item == null) continue;
                        var simCreated = item.mSim;
                        if (simCreated != null && simCreated.mSimDescription == item)
                        {
                            c++;
                        }
                    }
                    return c;
                }
            }
            return 0;
        }
        public static LoadSaveManager.eLoadSaveErrorCode unsafeForceSaveGameNoDialog(String saveFile = null)
        {
            if (ScriptCore.World.World_IsEditInGameFromWBModeImpl()) 
                return LoadSaveManager.eLoadSaveErrorCode.kOpenFailure;
            if (ScriptCore.World.World_GetWorldFileName() == null) 
                return LoadSaveManager.eLoadSaveErrorCode.kOpenFailure;

            string saveFileID = "UnsafeForceSaveGameNoDialog.sims3";
            LoadSaveManager.eLoadSaveErrorCode eLoadSaveErrorCode = LoadSaveManager.eLoadSaveErrorCode.kOtherError;
            try
            {
                
                using (LoadSaveFileInfo load_save_file_info = LoadSaveManager.CreateLoadSaveFileInfo(GetAddDotSims3(saveFile) ?? (ScriptCore.World.World_GetWorldFileName().Replace(".world", "") + " I" + RandomUtil.GetInt(0, 1000000, ListCollon.SafeRandomPart2) + ".sims3") ?? saveFileID))
                {
                    if (load_save_file_info == null)
                    {
                        return LoadSaveManager.eLoadSaveErrorCode.kNoSaveFileInfo;
                    }

                    OptionsModel tOptionsModel = null;
                    var tInstanceResponder = Sims3.Gameplay.UI.Responder.Instance;
                    if (tInstanceResponder != null)
                    {
                        tOptionsModel = tInstanceResponder.OptionsModel as OptionsModel;
                        if (tOptionsModel != null)
                            tOptionsModel.mSaveInProgress = true;
                    }

                    niec_std.mono_runtime_install_handlers(); // Prevent Game Crash Caused by SIGSEGV.  Need call mono_runtime_install_handlers();

                    eLoadSaveErrorCode = (LoadSaveManager.eLoadSaveErrorCode)ScriptCore.LoadSaveManager.LoadSaveManager_SaveGame_Impl(load_save_file_info.mNativeObjectHandle, false, true);
                    if (tOptionsModel != null)
                        tOptionsModel.mSaveInProgress = false;

                    saveFileID = load_save_file_info.ID;

                    if (!saveFileID.EndsWith(".sims3"))
                    {
                        saveFileID += ".sims3";
                    }

                }
                if (eLoadSaveErrorCode == LoadSaveManager.eLoadSaveErrorCode.kNoError)
                {
                    niec_std.mono_runtime_install_handlers(); // Prevent Game Crash Caused by SIGSEGV.  Need again call mono_runtime_install_handlers();
                    UIManager.SetSaveGameMetadata(saveFileID, null, null, null, 0, 0, false);
                }
            }
            catch
            {
                OptionsModel tOptionsModel = null;
                var tInstanceResponder = Sims3.Gameplay.UI.Responder.Instance;
                if (tInstanceResponder != null)
                {
                    tOptionsModel = tInstanceResponder.OptionsModel as OptionsModel;
                    if (tOptionsModel != null)
                        tOptionsModel.mSaveInProgress = false;
                }
                if (eLoadSaveErrorCode == LoadSaveManager.eLoadSaveErrorCode.kNoError)
                    return eLoadSaveErrorCode;
                return LoadSaveManager.eLoadSaveErrorCode.kWorldFileSaveFailure;
            }
           
            return eLoadSaveErrorCode;
        }

        public static bool ForceSaveGame(string name, bool noDialog = false, bool forceSaveAs = false, bool ovDeleteSave = false, bool needAllExport = true)
        {

            if (!Simulator.CheckYieldingContext(false) || GameStates.IsInMainMenuState)
                return false;

            if (ScriptCore.World.World_IsEditInGameFromWBModeImpl())
            {
                UIManager.DarkenBackground(true);
                bool a = LoadSaveManager.SaveWorld(); // Custom
                UIManager.DarkenBackground(false);
                return a;
            }

            string worldFileName = World.GetWorldFileName(); // custom
            if (!string.IsNullOrEmpty(worldFileName))
            {
                worldFileName = worldFileName.Replace(".world", ".sims3");
                if (!GameUtils.IsValidFilename(worldFileName ?? ""))
                {

                    NiecException.PrintMessagePro
                        ("Current World Name is invalid\nPlease Use Command: niecmod allexhouse", false , 100);
                    if (needAllExport)
                        return Create.AllHouseholdToExportHousehold(true, false, true, false, true);
                    return false;
                }
            }
            else
            {
                NiecException.PrintMessagePro
                    ("Current World Name is invalid\nPlease Use Command: niecmod allexhouse", false, 100);
                return false;
            }

            if (string.IsNullOrEmpty(name) || (ovDeleteSave && !GameUtils.IsValidFilename(name)))
                return false;

            string titleText = Localization.LocalizeString("Ui/Caption/GameEntry/MainMenu:NewTownTitle");
            string promptText = Localization.LocalizeString("Ui/Caption/GameEntry/MainMenu:NewTownPrompt");


            string text = name;

            string temptext = name;

            if (!temptext.EndsWith(".sims3"))
            {
                temptext += ".sims3";
            }

            if (SaveFileNameExists_(temptext) && ovDeleteSave)
            {
                GameUtils.DeleteSaveFile(temptext);
            }
            if (!ovDeleteSave && !noDialog)
            {
                if (text == null || text == "" || forceSaveAs)
                {
                    if (!forceSaveAs)
                    {
                        if (GameStates.WorldFileMetadata != null)
                        {
                            text = GameStates.WorldFileMetadata.mCaption;
                        }
                        else if (GameStates.SaveGameMetadata != null)
                        {
                            Sims3.UI.GameEntry.WorldFileMetadata info = new Sims3.UI.GameEntry.WorldFileMetadata();
                            info.mWorldFile = GameStates.SaveGameMetadata.mWorldFile;
                            if (Sims3.Gameplay.UI.Responder.Instance.MainMenuModel.GetWorldFileDetails(ref info))
                            {
                                text = info.mCaption;
                            }
                        }
                        else
                        {
                            text = "";
                        }
                        if (text.ToLower().EndsWith(".world"))
                        {
                            text = text.Substring(0, text.Length - 6);
                        }
                    }
                    else if (text.ToLower().EndsWith(".sims3"))
                    {
                        text = text.Substring(0, text.Length - 6);
                    }

                    bool forceShowDialog = true;
                    //if (CommandLine.FindSwitch("ForceShowSaveDialog") != null)
                    //{
                    //    forceShowDialog = true;
                    //}
                    while (Simulator.CheckYieldingContext(false))
                    {
                        text = StringInputDialog.Show(titleText, promptText, text, -1, ThumbnailKey.kInvalidThumbnailKey, new Vector2(-1f, -1f), StringInputDialog.Validation.SaveGameName, false, ModalDialog.PauseMode.PauseSimulator, forceShowDialog, false);
                        if (text.ToLower().EndsWith(".sims3"))
                        {
                            text = text.Substring(0, text.Length - 6);
                        }
                        if (!SaveFileNameExists_(text))
                        {
                            break;
                        }
                        string promptText2 = Localization.LocalizeString("Ui/Caption/Options:SaveConfirm");
                        if (AcceptCancelDialog.Show(promptText2, forceShowDialog))
                        {
                            GameUtils.DeleteSaveFile(text);
                            break;
                        }
                    }
                }
            }
            else
            {

            }
            if (text == null || text.Length <= 0)
            {
                return false;
            }
            if (!text.EndsWith(".sims3"))
            {
                text += ".sims3";
            }
            else if (!text.EndsWith(".sims3", StringComparison.OrdinalIgnoreCase))
            {
                text += ".sims3";
            }


            string householdName = null;
            string householdBio = null;
            string homeworldName = null;
            ulong householdId = 0;
            ulong lotId = 0;

            Simulator.Sleep(0);
            Sims3.SimIFace.Gameflow.GameSpeed currentGameSpeed = Sims3.Gameplay.UI.Responder.Instance.ClockSpeedModel.CurrentGameSpeed;
            bool gameSpeedLocked = Sims3.Gameplay.UI.Responder.Instance.ClockSpeedModel.GameSpeedLocked;
            if (!noDialog)
            {
                
                

                try
                {
                    if (!gameSpeedLocked)
                    {
                        Sims3.Gameplay.UI.Responder.Instance.ClockSpeedModel.LockGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause);
                    }
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog(ex.ToString());
                }

            }
            try
            {
                if (!noDialog)
                {
                    try
                    {
                        Sims3.UI.GameEntry.ScreenCaptureOverlay.Display(true, Simulator.CheckYieldingContext(false));
                    }
                    catch (Exception ex)
                    {
                        NiecException.WriteLog(ex.ToString());
                    }

                    ProgressDialog.Show(SaveLocalizeString___("Saving"), false);
                }
                try
                {
                    if (PlumbBob.SelectedActor != null)
                    {
                        Household household = PlumbBob.SelectedActor.Household;
                        if (household != null)
                        {
                            householdName = household.Name;
                            householdBio = household.BioText;
                            householdId = household.HouseholdId;
                            homeworldName = GameStates.HomeworldMetadataName;
                            lotId = household.LotId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog(ex.ToString());
                }
                Simulator.Sleep(0);
                using (//LoadSaveFileInfo loadSaveFileInfo = 
                    LoadSaveManager.GetCurrentSaveGameInfo())
                {
                    string text2 = text;
                    if (text2 != null && text2.Length > 0)
                    {
                        LoadSaveManager.eLoadSaveErrorCode eLoadSaveErrorCode = LoadSaveManager.eLoadSaveErrorCode.kNoError;
                        string text3 = null;
                        using (LoadSaveFileInfo loadSaveFileInfo2 = LoadSaveManager.CreateLoadSaveFileInfo(text2))
                        {
                            if (loadSaveFileInfo2 == null)
                            {
                                return false;
                            }
                            OptionsModel tOptionsModel = null;
                            var tInstanceResponder = Sims3.Gameplay.UI.Responder.Instance;
                            if (tInstanceResponder != null)
                            {
                                tOptionsModel = tInstanceResponder.OptionsModel as OptionsModel;
                                if (tOptionsModel != null)
                                    tOptionsModel.mSaveInProgress = true;
                            }

                            if (!IsOpenDGSInstalled && AssemblyCheckByNiec.IsInstalled("AweCore"))
                                GC.Collect();

                            eLoadSaveErrorCode = (LoadSaveManager.eLoadSaveErrorCode)LoadSaveManager.SaveGame(loadSaveFileInfo2, (GameStates.HasTravelData || GameStates.MovingWorldName != null) ? true : false);
                            if (tOptionsModel != null)
                                tOptionsModel.mSaveInProgress = false;
                            switch (eLoadSaveErrorCode)
                            {
                                case LoadSaveManager.eLoadSaveErrorCode.kNoError:
                                    break;
                                case LoadSaveManager.eLoadSaveErrorCode.kInvalidSaveFileLength:
                                case LoadSaveManager.eLoadSaveErrorCode.kFilePathLengthTooLarge:
                                    if (noDialog)
                                        NiecException.PrintMessagePro(SaveLocalizeString___("SaveGameDialog") + "\n" + SaveLocalizeString___("SaveGameFailTooLong"), false, 50f);
                                    else 
                                        SimpleMessageDialog.Show(SaveLocalizeString___("SaveGameDialog"), SaveLocalizeString___("SaveGameFailTooLong"), ModalDialog.PauseMode.PauseSimulator);
                                    return false;
                                case LoadSaveManager.eLoadSaveErrorCode.kFilenameIsInvalid: 
                                    if (noDialog)
                                        NiecException.PrintMessagePro(SaveLocalizeString___("SaveGameDialog") + "\n" + SaveLocalizeString___("SaveGameFailInvalid"), false, 50f);
                                    else 
                                        SimpleMessageDialog.Show(SaveLocalizeString___("SaveGameDialog"), SaveLocalizeString___("SaveGameFailInvalid"), ModalDialog.PauseMode.PauseSimulator);
                                    return false;
                                default:
                                    if (noDialog)
                                        NiecException.PrintMessagePro(SaveLocalizeString___("SaveGameDialog") + "\n" + SaveLocalizeString___("SaveGameFailErrorCode", (int)eLoadSaveErrorCode), false, 50f);
                                    else
                                        SimpleMessageDialog.Show(SaveLocalizeString___("SaveGameDialog"), SaveLocalizeString___("SaveGameFailErrorCode", (int)eLoadSaveErrorCode), ModalDialog.PauseMode.PauseSimulator);
                                    return false;
                            }

                            text3 = loadSaveFileInfo2.ID;

                            if (!text3.EndsWith(".sims3"))
                            {
                                text3 += ".sims3";
                            }

                            if (!noDialog)
                            {
                                GameStates.LoadFileName = text3;
                            }
                        }
                        if (eLoadSaveErrorCode == LoadSaveManager.eLoadSaveErrorCode.kNoError)
                        {
                            UIManager.SetSaveGameMetadata(text3, householdName, householdBio, homeworldName, householdId, lotId, false);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                NiecException.WriteLog(ex.ToString());
                return false;
            }
            finally
            {
                try
                {
                    if (!noDialog)
                    {
                        if (!gameSpeedLocked)
                        {
                            Sims3.Gameplay.UI.Responder.Instance.ClockSpeedModel.UnlockGameSpeed();
                        }
                        if (currentGameSpeed != 0)
                        {
                            Sims3.Gameplay.UI.Responder.Instance.ClockSpeedModel.CurrentGameSpeed = currentGameSpeed;
                        }
                    }
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog(ex.ToString());
                }


                try
                {
                    ProgressDialog.Close();
                }
                catch
                { }


                try
                {
                    Sims3.UI.GameEntry.ScreenCaptureOverlay.Display(false, Simulator.CheckYieldingContext(false));
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog(ex.ToString());
                    NiecTask.Perform(delegate
                    {
                        Sims3.UI.GameEntry.ScreenCaptureOverlay.Display(false, Simulator.CheckYieldingContext(false));
                    });
                }
            }
        }
        // ------------------------------------------------ End Force Save Game ------------------------------------------------ //

        public static void SetStartingFunds(Household hh)
        {
            int funds = 0;

            
            int child;
            int teen;
            int adult;
            int elder;

            int babyortoddler = child = (teen = (adult = (elder = 0)));

            foreach (SimDescription simDescription in hh.SimDescriptions)
            {
                //GrimReaper tasd;
                //IsGrimReaperService_OutService(simDescription, out tasd ); 
                switch (simDescription.Age)
                {
                    case CASAgeGenderFlags.Baby:
                    case CASAgeGenderFlags.Toddler:
                        babyortoddler++;
                        break;
                    case CASAgeGenderFlags.Child:
                    case CASAgeGenderFlags.Teen:
                        child++;
                        break;
                    case CASAgeGenderFlags.YoungAdult:
                        adult++;
                        break;
                    case CASAgeGenderFlags.Adult:
                        adult++;
                        break;
                    case CASAgeGenderFlags.Elder:
                        elder++;
                        break;
                }
            }

            funds += RandomUtil.GetInt(babyortoddler * CASLogic.kMoneyPerBaby / 2, babyortoddler * CASLogic.kMoneyPerToddler);
            funds += RandomUtil.GetInt(child * CASLogic.kMoneyPerChild, child * CASLogic.kMoneyPerTeen);
            funds += RandomUtil.GetInt(teen * CASLogic.kMoneyPerTeen, teen * CASLogic.kMoneyPerAdultElder + CASLogic.kStartingFundsForFamily);
            funds += RandomUtil.GetInt(adult * CASLogic.kMoneyPerAdultElder / 2, adult * CASLogic.kMoneyPerAdultElder * 2 + CASLogic.kStartingFundsForFamily);
            funds += RandomUtil.GetInt(elder * CASLogic.kMoneyPerAdultElder, elder * CASLogic.kMoneyPerAdultElder * 2);

            hh.SetFamilyFunds(Math.Max(funds, Household.kInitialFamilyFunds), false);
        }






        public static bool SimIsActiveHouseholdWithoutDGSCore(Sim Target)
        {
            if (Target == null) return false;
            //return PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && ;
            if (PlumbBob.Singleton == null || PlumbBob.Singleton.mSelectedActor == null) return false;
            return PlumbBob.Singleton.mSelectedActor.Household == Target.Household;
        }
        public static bool SimDescriptionIsActiveHouseholdWithoutDGSCore(SimDescription Target)
        {

            if (Target == null) return false;
            return PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && Target.Household == PlumbBob.sSingleton.mSelectedActor.Household;
        }
        public static bool IsSimFastActiveHousehold(Sim Target)
        {
            if (Target == null || Target.Household == null) return false;
            return ActiveHousehold == Target.Household;
        }
        public static bool IsSimDescriptionFastActiveHousehold(SimDescription Target)
        {
            if (Target == null || Target.Household == null) return false;
            return ActiveHousehold == Target.Household;
        }
        public static bool _IsActiveHousehold(Household household) { return household != null && household == Household.ActiveHousehold; }
        public static bool IsActiveHouseholdWithActiveActorPro(Household household, Sim activeActor)
        {
            if (household == null) return false;
            var sim = activeActor ?? ActiveActor;
            if (sim == null) return false;
            return household == sim.Household;
        }
        public static bool Household_IsActiveHousehold(Household household)
        {
            if (household == null) return false;
            return household == ActiveHousehold || household == Household.ActiveHousehold;
        }
        public static bool IsAllActiveHousehold_SimDesc(SimDescription Target)
        {
            if (Target == null)
                return false;

            Household household = Target.Household;
            if (household != null)
            {
                //if (household == ActiveHousehold)
                //    return true;
                //if (household == Household.ActiveHousehold)
                //    return true;
                return household == ActiveHousehold || household == Household.ActiveHousehold;
            }
            return false;
        }
        public static bool IsAllActiveHousehold_SimObject(Sim Target)
        {
            if (Target == null)
                return false;
            if (IsOpenDGSInstalled)
            {
                if (Target == ActiveActor || Target == PlumbBob.SelectedActor)
                    return true;

                Household household = Target.Household;
                if (household != null)
                    return household == ActiveHousehold || household == Household.ActiveHousehold;

                return false;
            }
            else
            {
                if (Target == PlumbBob.SelectedActor)
                    return true;

                Household household = Target.Household;
                if (household != null)
                    return household == Household.ActiveHousehold;

                return Target.IsInActiveHousehold;
            }
        }













        public static bool OnCancelTryRunInteraction(GameObject actorObj, InteractionInstance interaction)
        {
            if (Simulator.CheckYieldingContext(false) && actorObj != null && GetObject_internalFast(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) == actorObj && (!IsOpenDGSInstalled && baCheckACoreThrowNRaasErrorTrap && AssemblyCheckByNiec.IsInstalled("AweCore") || !interaction.IsTargetValid())) //&& actorObj.ObjectId.mValue == ScriptCore.Simulator.Simulator_GetCurrentTaskImpl() && ScriptCore.Simulator.Simulator_GetTaskImpl(actorObj.ObjectId.mValue, false) is T && !interaction.IsTargetValid()) 
            {
                bool a = _RunInteraction(interaction);
                CheckYieldingContext();
                return a;
            }
            return false;
        }


        public static void M(params object[] unused) { }


        public static bool CheckAccpetWithoutYield(string text)
        {
            if (!niec_native_func.cache_done_niecmod_native_message_box)
                return false;
            if (niec_native_func.MessageBox(0, text, "NiecMod", niec_native_func.MB_Type.MB_ICONEXCLAMATION | niec_native_func.MB_Type.MB_OKCANCEL) == niec_native_func.ResultMB.IDOK)
            {
                return true;
            }
            return false;
        }

        public static bool testnomessbox_b = false;

        public static bool CheckAccept(string text)
        { 
            //return Simulator.CheckYieldingContext(false) && AcceptCancelDialog.Show("NiecMod\n" + text); 
            if (!Simulator.CheckYieldingContext(false) || (testnomessbox_b && niec_native_func.cache_done_niecmod_native_message_box))
            {
                return CheckAccpetWithoutYield(text);
            }
            return AcceptCancelDialog.Show("NiecMod\n" + text);
        }

        public static readonly OutfitCategories[] OutfitCategories_OnlyEveryday = new OutfitCategories[] {
            OutfitCategories.Athletic,
            OutfitCategories.Career,
            OutfitCategories.Formalwear,
            OutfitCategories.Naked,
            OutfitCategories.Outerwear,
            OutfitCategories.Sleepwear,
            OutfitCategories.Swimwear,
            OutfitCategories.Singed
	    };

        public static void RemoveHandleFromAlarmGlobal(ref AlarmHandle handle)
        {
            var am = AlarmManager.Global;
            if (am != null)
                am.RemoveAlarm(handle);
            handle = new AlarmHandle();
        }

        public static void RemoveTaskFromSimulator(ref ObjectGuid taskHandle)
        {
            ScriptCore.Simulator.Simulator_DestroyObjectImpl(taskHandle.Value);
            taskHandle = new ObjectGuid(0);
        }
        public static void UnSafeRemoveOutfitsExEveryday(SimDescription simDesc)
        {

            if (simDesc == null || !simDesc.IsValidDescription || simDesc.Outfits == null || simDesc.Outfits.Count == 0)
                return;

            try
            {
                var createdSim = simDesc.CreatedSim;
                if (createdSim != null)
                {
                    if (createdSim.SimDescription == simDesc)
                    {
                        createdSim.SwitchToOutfitWithoutSpin(Sim.ClothesChangeReason.Force, OutfitCategories.Everyday);
                    }
                    else { 
                        ForceDestroyObject(createdSim, false);
                        //SimDesc_SafeInstantiate(simDesc, Vector3_OutOfWorld);
                    }
                    SpeedTrap.Sleep(0);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception) { }  

            foreach (var item in OutfitCategories_OnlyEveryday)
            {
                if (item == OutfitCategories.Everyday) 
                    continue;

                simDesc.RemoveOutfits(item, false);
            }
        }

        public static List<object> GCoutfitsBackup = new List<object>();

        public static SimOutfit GetOutfitBackup(OutfitCategoryMap outfitsBackup, OutfitCategories category, int index)
        {
            ArrayList outfitsList = null;
            if (outfitsList == null)
            {
                outfitsList = (outfitsBackup[category] as ArrayList);
            }
            if (outfitsList == null || index < 0 || outfitsList.Count <= index)
            {
                return null;
            }
            return (SimOutfit)outfitsList._items[index];
        }


        public static void UnsafeReOutfit(SimDescription simd, OutfitCategories category, OutfitCategoryMap outfitsBackup, bool isDefault, int index)
        {
            niec_native_func.OutputDebugString("UnsafeReOutfit() called");
            niec_native_func.OutputDebugString("UnsafeReOutfit category: " + category);
            niec_native_func.OutputDebugString("UnsafeReOutfit name: " + simd.mFirstName + " " + simd.mLastName);

            switch (category)
            {
                case OutfitCategories.None:
                case OutfitCategories.All:
                case OutfitCategories.CategoryMask:
                case OutfitCategories.PrimaryCategories:
                case OutfitCategories.PrimaryHorseCategories: // EA fail.
                    niec_native_func.OutputDebugString("UnsafeReOutfit category is invalid.");
                    return;
            }

            if (!simd.IsValidDescription || simd.mHairColors == null || simd.mOutfits == null)
            {
                niec_native_func.OutputDebugString("UnsafeReOutfit: if (!simd.IsValidDescription || simd.mHairColors == null || simd.mOutfits == null)");
                return;
            }

            if (simd.Pregnancy != null)
            {
                niec_native_func.OutputDebugString("UnsafeReOutfit: desc is pregnancy. cancelled");
                return;
            }

            var o = outfitsBackup != null ? GetOutfitBackup(outfitsBackup, category, (!isDefault) ? (index) : 0) : simd.GetOutfit(category, (!isDefault) ? (index) : 0);
            if (o != null && o.IsValid)
            {
                var simBuilder = new SimBuilder();
                simBuilder.Clear();
                simBuilder.UseCompression = true;

                OutfitUtils.SetAutomaticModifiers(simBuilder);
                OutfitUtils.SetOutfit(simBuilder, o, null);
                OutfitUtils.ExtractOutfitHairColor(simd, simBuilder);

                simBuilder.Age = simd.Age;
                simBuilder.Gender = simd.Gender;
                simBuilder.Species = simd.Species;

                ResourceKey outfitKey = simBuilder.CacheOutfit("UnsafeReOutfit NiecMod ID" + simd.SimDescriptionId, true);

                NiecException.WriteLog("UnsafeReOutfit Key: " + outfitKey.ToString());

                SimOutfit newSimOutfit = new SimOutfit(outfitKey);

                if (newSimOutfit != null && newSimOutfit.IsValid)
                {
                    simd.AddOutfitInternal(newSimOutfit, category, (!isDefault) ? (index) : 0, false, true);
                }
                else
                {
                    niec_native_func.OutputDebugString("UnsafeReOutfit: if (newSimOutfit != null && newSimOutfit.IsValid) failed.");
                    return;
                }

                var test_o = simd.GetOutfit(category, (!isDefault) ? (index) : 0);
                if (test_o != null && test_o.IsValid) { }
                else
                {
                    niec_native_func.OutputDebugString("UnsafeReOutfit: if (test_o != null && test_o.IsValid) failed.");
                }
            }
            else niec_native_func.OutputDebugString("UnsafeReOutfit: if (o != null && o.IsValid) failed.");
        }

        public static void UnSafeEverydayToAddOtherOutfits(SimDescription simDesc, bool simOutfitCopyToSimOutfit)
        {

            if (simDesc == null || !simDesc.IsValidDescription || simDesc.Outfits == null || simDesc.Outfits.Count == 0)
                return;

            //var createdSim = simDesc.CreatedSim;
            //if (createdSim != null && createdSim.SimDescription == simDesc)
            //    createdSim.SwitchToOutfitWithoutSpin(Sim.ClothesChangeReason.Force, OutfitCategories.Everyday);

            SimOutfit simout = simDesc.GetOutfit(OutfitCategories.Everyday, 0);
            if (simout == null || !simout.IsValid) return;
            foreach (var item in OutfitCategories_OnlyEveryday)
            {
                if (item == OutfitCategories.Everyday || item == OutfitCategories.Naked || item == OutfitCategories.Singed || item == OutfitCategories.Career)
                    continue;

                if (simOutfitCopyToSimOutfit)
                {
                    SimBuilder simBuilder = new SimBuilder();
                    simBuilder.Clear();
                    simBuilder.UseCompression = true;

                    OutfitUtils.SetAutomaticModifiers(simBuilder);
                    OutfitUtils.SetOutfit(simBuilder, simout, null, IsOpenDGSInstalled);
                    OutfitUtils.ExtractOutfitHairColor(simDesc, simBuilder);

                    simBuilder.Age = simDesc.Age;
                    simBuilder.Gender = simDesc.Gender;
                    simBuilder.Species = simDesc.Species;

                    ResourceKey outfitKey = simBuilder.CacheOutfit("NiecMod ID" + simDesc.SimDescriptionId, true);

                    NiecException.WriteLog(outfitKey.ToString()); // Debug

                    SimOutfit simOutfit = new SimOutfit(outfitKey);

                    if (simOutfit == null || !simOutfit.IsValid)
                    {
                        niec_native_func.OutputDebugString("UnSafeEverydayToAddOtherOutfits: if (simOutfit == null || !simOutfit.IsValid)");
                        return;
                    }
                    simDesc.AddOutfit(simOutfit, item, true);
                }
                else
                {
                    simDesc.AddOutfit(simout, item, true);
                }
            }
        }








        // ------------------------------------------------ AutoMET ------------------------------------------------ //


        public static ObjectGuid AutoMETask = new ObjectGuid(0);

        public static List<Sim> AutoMET_ListQueueSim = null;

        public static bool AutoMET_mSleepTask = false;

        public static TimePortal AutoMET_TimePortal = null;

        public static EventListener AutoMET = null;

        public static ListenerAction AutoMET_OnCreatedSim(Event Event)
        {
           

            try
            {
                if (AutoMET_ListQueueSim == null) { 
                    AutoMET_ShutDown(); 
                    return ListenerAction.Remove; 
                }

                AutoMET_ResetEventTracker();

                Sim Actor = Event.TargetObject as Sim;
                if (Actor != null)
                {
                    SimDescription simd = Actor.SimDescription;
                    if (simd != null && simd.TeenOrAbove && !simd.IsPet)
                    {
                        if (!AutoMET_ListQueueSim.Contains(Actor))
                        {
                            AutoMET_ListQueueSim.Add(Actor);
                            AutoMET_mSleepTask = false;
                            
                        }
                    }
                }
            }

            //catch (ResetException) { throw; }

            catch
            { }

            //try
            //{
            //    if (!Instantiator.RootIsOpenDGSInstalled && Simulator.CheckYieldingContext(false))
            //    {
            //        Simulator.Sleep(uint.MaxValue);
            //    }
            //}
            //catch (ResetException) {
            //    if (!Instantiator.RootIsOpenDGSInstalled)
            //    NiecTask.Perform(delegate {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Simulator.Sleep(0);
            //        }
            //        AutoMET = EventTracker.AddListener(EventTypeId.kSimInstantiated, AutoMET_OnCreatedSim);
            //    });
            //    throw; 
            //}
            
            return ListenerAction.Remove;
        }

        public static bool AutoMET_NTaskNeedAddToQure = false;

        public static bool AutoMET_StartUp(TimePortal Portal, bool TaskDontNeedAddToQure)
        {
            if (Portal == null || !GameUtils.IsInstalled(ProductVersion.EP11))
                return false;

            //if (AutoMETask != ObjectGuid.InvalidObjectGuid)
            if (AutoMET_TimePortal != null)
            {
                AutoMET_ShutDown();
            }

            AutoMET = EventTracker.AddListener(EventTypeId.kSimInstantiated, AutoMET_OnCreatedSim);
            AutoMET_TimePortal = Portal;

            if (AutoMET_ListQueueSim == null)
                AutoMET_ListQueueSim = new List<Sim>();

            if (AutoMET_ListQueueSim.Count != 0)
                AutoMET_ListQueueSim.Clear();

            AutoMETask = NiecTask.Perform(AutoMET_OnTick);

            AutoMET_NTaskNeedAddToQure = TaskDontNeedAddToQure;
            return true;
        }

        
        public static bool AutoMET_Reset()
        {
            TimePortal Portal = AutoMET_TimePortal;
            AutoMET_ShutDown();
            AutoMET_StartUp(Portal, AutoMET_NTaskNeedAddToQure);
            return true;
        }

        public static void AutoMET_ResetEventTracker()
        {
            if (Sims3.Gameplay.EventSystem.EventTracker.Instance != null)
            {
                if (AutoMET != null)
                    EventTracker.RemoveListener(AutoMET);
                AutoMET = EventTracker.AddListener(EventTypeId.kSimInstantiated, AutoMET_OnCreatedSim);
            }
            else AutoMET_ShutDown();
        }

        public static bool AutoMET_ShutDown()
        {
            if (AutoMET != null && Sims3.Gameplay.EventSystem.EventTracker.Instance != null)
                EventTracker.RemoveListener(AutoMET);

            AutoMET = null;
            if (AutoMET_TimePortal != null && !AutoMET_TimePortal.HasBeenDestroyed)
                AutoMET_TimePortal.State = TimePortal.PortalState.Inactive;
            AutoMET_TimePortal = null;

            Simulator.DestroyObject(AutoMETask);
            AutoMETask = ObjectGuid.InvalidObjectGuid;

            if (AutoMET_ListQueueSim != null)
                AutoMET_ListQueueSim.Clear();

            AutoMET_ListQueueSim = null;
            return true;
        }

        public static bool AutoMET_WaitSim = false;

        public static void AutoMET_SimRunningMET(Sim TargetToPortal, TimePortal Portal) {

            if (TargetToPortal  == null || Portal == null)
                return;

            NiecTask.Perform(delegate
            {
                Simulator.Sleep(0);

                if (AutoMET_NTaskNeedAddToQure)
                {
                    NinecReaper.CustomRun cuRun = delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                    {
                        (CurrentInteraction as NinecReaper).dataBoolens[5] = true;
                        if (Portal != null)
                        {
                            if (RandomUtil.RandomChance(TimeTravelerSituation.TimeTravelerAppear.kChanceOfCauseAndEffectBuff))
                            {
                                Actor.BuffManager.AddElement(
                                    TimeTravelerSituation.TimeTravelerAppear.kCauseAndEffectBuffs[0],
                                    Origin.None
                                );
                            }


                            Actor.FadeOut();
                            Actor.SetPosition(Portal.GetSlotPosition(Slot.ContainmentSlot_0));
                            Actor.SetForward(Portal.GetForwardOfSlot(Slot.ContainmentSlot_0));

                            var CSM = StateMachineClient.Acquire(Actor, "timeportal", AnimationPriority.kAPUltraPlus);

                            for (byte i = 0; i < 15; i++)
                                Simulator.Sleep(0);

                            while (AutoMET_WaitSim)
                                Simulator.Sleep(0);

                            try
                            {
                                AutoMET_WaitSim = true;

                                CSM.SetActor("x", Actor);
                                CSM.EnterState("x", "Enter");

                                CSM.SetActor("portal", Portal);

                                CSM.AddOneShotScriptEventHandler(
                                    121u,
                                    delegate
                                    {
                                        Portal.SignalSimsToStepBack();
                                    }
                                );
                                Simulator.Sleep(0);
                                CSM.AddPersistentScriptEventHandler(
                                    201u,
                                    delegate
                                    {
                                        Portal.ShakeCamera();
                                        List<Sim> list = new List<Sim>(1);
                                        list.Add(TargetToPortal);
                                        Portal.MakeNearbySimsReact(list);
                                    }
                                );

                                Actor.FadeIn(false, 2f);

                                CSM.RequestState("x", "Jump Out");
                                CSM.RequestState("x", "Exit");

                                Vector3 position = Target.Position;
                                position += (RandomUtil.CoinFlip() ? 2.5f : 3.5f) * Target.ForwardVector;
                                Actor.RouteToPoint(position);
                            }
                            finally
                            {
                                AutoMET_WaitSim = false;
                                Actor.FadeIn();
                            }
                            if (RandomUtil.RandomChance(43))
                            {
                                Actor.PlaySoloAnimation("a_timeTraveler_adventurous_x", ProductVersion.EP11);
                            }
                            CSM.Dispose();
                        }

                        return true;
                    };

                    while (TargetToPortal.InteractionQueue == null)
                        Simulator.Sleep(0);

                    NinecReaper niecr = NinecReaper.Create(TargetToPortal, TargetToPortal, cuRun);
                    niecr.customRun = cuRun;
                    niecr.mMustRun = true;
                    niecr.customCleanUp = delegate
                    {
                        if (TargetToPortal.ObjectId == Simulator.CurrentTask)
                        {
                            if (!niecr.dataBoolens[5])
                                cuRun(TargetToPortal, TargetToPortal, niecr);
                        }
                    };
                    niecr.CustomRunName = "AutoMET";

                    while (TargetToPortal.InteractionQueue == null)
                        Simulator.Sleep(0);

                    TargetToPortal.InteractionQueue.Add(niecr);
                }
                else
                {
                    if (Portal != null)
                    {


                        if (RandomUtil.RandomChance(TimeTravelerSituation.TimeTravelerAppear.kChanceOfCauseAndEffectBuff))
                        {
                            TargetToPortal.BuffManager.AddElement(
                                TimeTravelerSituation.TimeTravelerAppear.kCauseAndEffectBuffs[0],
                                Origin.None
                            );
                        }


                        TargetToPortal.FadeOut();
                        TargetToPortal.SetPosition(Portal.GetSlotPosition(Slot.ContainmentSlot_0));
                        TargetToPortal.SetForward(Portal.GetForwardOfSlot(Slot.ContainmentSlot_0));

                        var CSM = StateMachineClient.Acquire(TargetToPortal, "timeportal", AnimationPriority.kAPUltraPlus);

                        while (AutoMET_WaitSim)
                            Simulator.Sleep(0);

                        try
                        {
                            AutoMET_WaitSim = true;
                            //TargetToPortal.FadeIn(false, 2f);
                            CSM.SetActor("x", TargetToPortal);
                            CSM.EnterState("x", "Enter");

                            CSM.SetActor("portal", Portal);

                            CSM.AddOneShotScriptEventHandler(
                                121u,
                                delegate
                                {
                                    Portal.SignalSimsToStepBack();
                                }
                            );
                            Simulator.Sleep(0);
                            CSM.AddPersistentScriptEventHandler(
                                201u,
                                delegate
                                {
                                    Portal.ShakeCamera();
                                    List<Sim> list = new List<Sim>(1);
                                    list.Add(TargetToPortal);
                                    Portal.MakeNearbySimsReact(list);
                                }
                            );

                            CSM.RequestState("x", "Jump Out");
                            CSM.RequestState("x", "Exit");

                            Vector3 position = Portal.Position;
                            position += (RandomUtil.CoinFlip() ? 2.5f : 3.5f) * Portal.ForwardVector;
                            RoutingComponent rc = TargetToPortal.RoutingComponent;
                            if (rc != null)
                            {
                                var route = rc.CreateRoute();
                                route.ExecutionFromNonSimTaskIsSafe = true;
                                route.PlanToPoint(position);
                                rc.DoRoute(route);
                            }
                            //iActor.RouteToPoint(position);
                        }
                        finally
                        {
                            AutoMET_WaitSim = false;
                            TargetToPortal.FadeIn();
                        }

                        //if (!mPortal.HasTimeTravelerBeenSummoned())
                        if (RandomUtil.RandomChance(43))
                        {
                            TargetToPortal.PlaySoloAnimation("a_timeTraveler_adventurous_x", ProductVersion.EP11);
                        }
                        CSM.Dispose();
                    }
                }
            });
        }

        public static void AutoMET_OnTick()
        {
            
            while (true)
            {
                Simulator.Sleep(0);
                TimePortal mPortal = AutoMET_TimePortal;
                if (mPortal == null || AutoMET_ListQueueSim == null || mPortal.HasBeenDestroyed)
                {
                    NiecException.PrintMessagePro("Failed Auto_MET", false, 10);
                    AutoMET_ShutDown();
                    return;
                }
                
                if (AutoMET_mSleepTask || AutoMET_ListQueueSim.Count == 0)
                    for (int advi = 0; advi < 15; advi++)
                        Simulator.Sleep(0);
                else
                {
                    
                    foreach (var iActor in AutoMET_ListQueueSim.ToArray())
                    {
                        AutoMET_ListQueueSim.Remove(iActor);
                        if (iActor == null)
                            continue;


                        SimDescription simd = iActor.SimDescription;
                        if (simd != null && simd.TeenOrAbove && !simd.IsPet)
                        {
                            if (iActor.HasBeenDestroyed)
                                continue;

                            mPortal.State = TimePortal.PortalState.Active;
                            AutoMET_SimRunningMET(iActor, mPortal);
                        }
                       
                    }
                    AutoMET_mSleepTask = true;
                }
            }
        }



        // ------------------------------------------------ End AutoMET ------------------------------------------------ //















        public static bool DeleteSavedLotSimDesc(object deleteSimDesc)
        {
            if (LotManager.sLots == null) 
                return false;

            bool r = false;
            List<ObjectGuid> dvar = null;
            foreach (var lot in LotManager.sLots.Values)
            {
                //if (item == null) continue;
                //Lot lot = item.mTarget as Lot;
                if (lot != null)
                {
                    var saveDatalot = lot.mSavedData;
                    if (saveDatalot != null) {
                        var residentDictionary = saveDatalot.mDoorsToVirtualResidentDictionary;
                        if (residentDictionary != null && residentDictionary.Count > 0) {

                            

                            foreach (var resident in residentDictionary) {
                                if (resident.Value == deleteSimDesc) {
                                    Lazy.Allocate(ref dvar);
                                    dvar.Add(resident.Key);
                                    r = true;
                                }
                            }

                            if (dvar == null || dvar.Count == 0) 
                                continue;

                            foreach (var resident in dvar)
                                residentDictionary.Remove(resident);

                            if (dvar.Count > 0)
                                dvar.Clear();
                        }
                    }
                }
            } 
            return r;
        }


        public static void RepairAllForLot(Lot lot)
        {
            if (lot == null) {
                return;
            }

            Sim sim_ = PlumbBob.SelectedActor ?? NFinalizeDeath.GetRandomSim();

            foreach (GameObject gameObject in SC_GetObjectsOnLot<GameObject>(lot))
            {
                if (gameObject == null || gameObject.InUse || !gameObject.InWorld)
                {
                    continue;
                }

                if (gameObject.Charred)
                {
                    gameObject.Charred = false;
                    if (gameObject is Windows)
                    {
                        RepairableComponent.CreateReplaceObject(gameObject);
                    }
                }

                RepairableComponent repairable = gameObject.Repairable;
                if (repairable != null && repairable.Broken)
                {
                    repairable.ForceRepaired(sim_);
                }
            }

            TombRoomManager tombm = lot.TombRoomManager;

            LotLocation[] burntTiles = World.GetBurntTiles(lot.LotId, LotLocation.Invalid);
            if (burntTiles != null && burntTiles.Length > 0)
            {
                foreach (LotLocation lotLocation in burntTiles)
                {
                    if (lot.LotLocationIsPublicResidential(lotLocation) && (tombm == null || !tombm.IsObjectInATombRoom(lotLocation)))
                    {
                        World.SetBurnt(lot.LotId, lotLocation, burnt: false);
                    }
                }
            }
        }

        public static void CleanUpAllForLot(Lot lot, bool bNeedCleanBill)
        {
            if (lot == null)
            {
                return;
            }

            World.DecayLeaves(lot.LotId, 1f);

            TombRoomManager tombm = lot.TombRoomManager;

            foreach (GameObject gameObject in SC_GetObjectsOnLot<GameObject>(lot))
            {
                if (gameObject == null || gameObject.InUse || gameObject.InInventory) {
                    continue;
                }

                var cleanable = gameObject.Cleanable;

                if (cleanable != null) {
                    cleanable.ForceClean();
                }

                Hamper hamper = gameObject as Hamper;
                if (hamper != null) {
                    hamper.RemoveClothingPiles();
                }

                if (bNeedCleanBill) {
                    Bill bill = gameObject as Bill;
                    if (bill != null) {
                        bill.Amount = 0;
                        bill.OriginatingHousehold = null;
                        bill.mBillAgeInDays = 0;
                        bill.DestroyBill(false);
                    }
                }

                IThrowAwayable throwAwayable = gameObject as IThrowAwayable;
                if ( throwAwayable != null && 
                    !throwAwayable.InUse && 
                    throwAwayable.HandToolAllowUserPickupBase() && 
                    throwAwayable.ShouldBeThrownAway() && 
                    (throwAwayable.Parent == null || !throwAwayable.Parent.InUse) && 
                    !(throwAwayable is Sims3.Gameplay.Objects.Counters.Bar.Glass) && 
                    !(throwAwayable is Bill) )
                {
                    bool isBarGlass = false;
                    if (throwAwayable is Sims3.Gameplay.Objects.CookingObjects.BarTray)
                    {
                        foreach (Slot slotName in throwAwayable.GetContainmentSlots())
                        {
                            if (throwAwayable.GetContainedObject(slotName) is Sims3.Gameplay.Objects.Counters.Bar.Glass)
                            {
                                isBarGlass = true;
                                break;
                            }
                        }
                    }

                    if (!isBarGlass) {
                        throwAwayable.ThrowAwayImmediately();
                    }
                }

                if (gameObject is IDestroyOnMagicalCleanup && !(gameObject is Sim) && !(gameObject is PlumbBob)) {
                    gameObject.FadeOut(false, true);
                }

            }

            var firem = lot.FireManager;

            if (firem != null)
                firem.RestoreObjects();

            LotLocation[] puddles = World.GetPuddles(lot.LotId, LotLocation.Invalid);

            if (puddles != null && puddles.Length > 0)
            {
                foreach (LotLocation lotl in puddles)
                {
                    if (tombm == null || !tombm.IsObjectInATombRoom(lotl))
                    {
                        PuddleManager.RemovePuddle(lot.LotId, lotl);
                    }
                }
            }

            LotLocation[] burntTiles = World.GetBurntTiles(lot.LotId, LotLocation.Invalid);
            if (burntTiles != null && burntTiles.Length > 0)
            {
                foreach (LotLocation lotl in burntTiles)
                {
                    if (lot.LotLocationIsPublicResidential(lotl) && (tombm == null || !tombm.IsObjectInATombRoom(lotl)))
                    {
                        World.SetBurnt(lot.LotId, lotl, false);
                    }
                }
            }

            var householdLot = lot.Household;
            if (householdLot != null)
            {
                var listFridge = SC_GetObjectsOnLot<Sims3.Gameplay.Objects.Appliances.Fridge>(lot);
                if (listFridge.Length > 0)
                {
                    Sims3.Gameplay.Objects.Appliances.Fridge fridge = listFridge[0];
                    Inventory hSharedFridgeInventory = householdLot.SharedFridgeInventory == null ? null : householdLot.SharedFamilyInventory.Inventory;

                    if (fridge != null && hSharedFridgeInventory != null)
                    {
                        var servingConList = SC_GetObjectsOnLot
                            <Sims3.Gameplay.Objects.CookingObjects.ServingContainer>(lot);

                        foreach (var servingContainer in servingConList)
                        {
                            if (!servingContainer.InUse && 
                                fridge.HandToolAllowDragDrop(servingContainer) && 
                                servingContainer.HasFood && 
                                servingContainer.HasFoodLeft() && 
                                !servingContainer.IsSpoiled && 
                                servingContainer.GetQuality() >= Sims3.Gameplay.Objects.Quality.Neutral)
                            {
                                hSharedFridgeInventory.TryToAdd((IGameObject)servingContainer, false);
                            }
                        }
                    }
                }
            }

            foreach (Sim allActor in SC_GetObjectsOnLot<Sim>(lot))
            {
                var sInventory = allActor.Inventory;
                if (sInventory != null && sInventory.mItems != null && sInventory.mInventoryItems != null)
                {
                    foreach (IThrowAwayable item in sInventory.FindAll<IThrowAwayable>(true))
                    {
                        if ( item != null && 
                            item.HandToolAllowUserPickupBase() && 
                            item.ShouldBeThrownAway() && 
                            !item.InUse && 
                            (!(item is Newspaper) || (item as Newspaper).IsOld) && 
                            !(item is TrashPileOpportunity) && 
                            (!(item is Sims3.Gameplay.Objects.CookingObjects.PreparedFood) || (item as Sims3.Gameplay.Objects.CookingObjects.PreparedFood).IsSpoiled) )
                        {
                            item.ThrowAwayImmediately();
                        }
                    }
                }
            }
        }

        public static bool RouteTurnToFace(RoutingComponent ths ,Vector3 point, ulong routeOptionAddFlags, ulong routeOptionRemoveFlags)
        {
            if (ths == null) 
                throw new ArgumentNullException("ths");
            Route route = ths.CreateRoute();
            uint checkloop = 500000;
            while (routeOptionAddFlags != 0)
            {
                ulong num = MathUtils.IsolateLowestBit(routeOptionAddFlags);
                route.SetOption((Route.RouteOption)routeOptionAddFlags, true);
                routeOptionAddFlags &= ~num;
                checkloop--;
                if (checkloop == 0) return false;
            }
            checkloop = 500000;
            while (routeOptionRemoveFlags != 0)
            {
                ulong num2 = MathUtils.IsolateLowestBit(routeOptionRemoveFlags);
                route.SetOption((Route.RouteOption)routeOptionRemoveFlags, false);
                routeOptionRemoveFlags &= ~num2;
                checkloop--;
                if (checkloop == 0) return false;
            }
            route = ths.PlanRouteTurnToFace(route, point);
            route.SetOption(Route.RouteOption.PushSimsAtDestination, false);
            route.ExecutionFromNonSimTaskIsSafe = true;
            return ths.DoRoute(route);
        }

        public static void _MoveInventoryItemsToAFamilyMember(Sim Actor, Sim ToSim)
        {
            if (Actor.Inventory != null && !Actor.Inventory.IsEmpty && (!IsOpenDGSInstalled || Actor.SimDescription != null))
            {
                if (ToSim == null && Actor.Household != null)
                {
                    Sim sim = null;
                    foreach (Sim sim2 in Actor.Household.Sims)
                    {
                        if (sim2 != Actor && sim2.Household != null && (sim2.SimDescription.DeathStyle == SimDescription.DeathType.None || sim2.SimDescription.IsPlayableGhost) && (sim == null || sim2.SimDescription.Age > sim.SimDescription.Age) && (Household.RoommateManager == null || Household.RoommateManager.IsNPCRoommate(sim2) == Household.RoommateManager.IsNPCRoommate(Actor)))
                        {
                            sim = sim2;
                        }
                    }
                   //Actor.MoveInventoryItemsToSim(sim);
                    _MoveInventoryItemsToSim(Actor, ToSim);
                }
                else
                    _MoveInventoryItemsToSim(Actor, ToSim);
            }
        }



        public static void _MoveInventoryItemsToSim(Sim Actor, Sim toGiveTo)
        {
            if (toGiveTo != null)
            {
                List<INotTransferableOnDeath> list = Actor.Inventory.FindAll<INotTransferableOnDeath>(false);
                foreach (INotTransferableOnDeath item in list)
                {
                    item.Destroy();
                }
                List<IGameObject> list2 = new List<IGameObject>();
                if (GameUtils.IsInstalled(ProductVersion.EP4))
                {
                    ulong simDescriptionId = Actor.SimDescription.SimDescriptionId;
                    List<IImaginaryDoll> list3 = Actor.Inventory.FindAll<IImaginaryDoll>(false);
                    foreach (IImaginaryDoll item2 in list3)
                    {
                        if (item2.GetOwnerSimDescriptionId() == simDescriptionId)
                        {
                            if (Actor.Inventory.TryToRemove(item2))
                            {
                                list2.Add(item2);
                            }
                            else
                            {
                                item2.Destroy();
                            }
                        }
                    }
                }
                if (!Actor.Inventory.IsEmpty && Actor.IsSelectable)
                {
                    if (IsOpenDGSInstalled) // check inf loop
                        Actor.Inventory.MoveObjectsTo(toGiveTo.Inventory);
                    else if (Actor.Inventory != toGiveTo.Inventory)
                    {
                        Actor.Inventory.MoveObjectsTo(toGiveTo.Inventory);
                    }
                    string entryKey = "Sims3.Gameplay.Objects".Substring(6).Replace('.', '/') + "/Urnstone:TransferredInventoryTNS";
                    string titleText = Localization.LocalizeString(Actor.IsFemale, entryKey, Actor, toGiveTo);
                    StyledNotification.Format format = new StyledNotification.Format(titleText, StyledNotification.NotificationStyle.kSystemMessage);
                    StyledNotification.Show(format);
                }
                foreach (IGameObject item3 in list2)
                {
                    if (!Actor.Inventory.TryToAdd(item3))
                    {
                        item3.Destroy();
                    }
                }
            }
        }

        public static bool CanAddSituation(Sim Actor, Situation addToSituation = null) { 
            List<Situation> unusd;
            return CanAddSituation(Actor, addToSituation, out unusd); 
        }

        public static bool CanAddSituation(Sim Actor, Situation addToSituation, out List<Situation> outSituation)
        {
            outSituation = null;
            if (Actor == null)
                return false;

            Autonomy automoy = Actor.Autonomy;
            if (automoy == null)
                return false;

            SituationComponent sSituationComponent = automoy.SituationComponent;
            if (sSituationComponent == null)
                return false;

            List<Situation> listSituations = sSituationComponent.Situations;
            if (listSituations == null)
                return false;
            outSituation = listSituations;
            if (addToSituation != null) {
                try
                {
                    if (!listSituations.Contains(addToSituation))
                        listSituations.Add(addToSituation);
                }
                catch 
                {
                    sSituationComponent.mSituations = outSituation = new List<Situation>() { addToSituation };
                }
            }
            return true;
        }

        public static float MathU_Triangular(float x)
        {
            x = x / 2.0f;

            if (x < 0.0)
            {
                return (x + 1.0f);
            }
            else
            {
                return (1.0f - x);
            }
        }

        public static float MathU_BSpline(float x)
        {
            float f = x;

            if (f < 0.0)
            {
                f = -f;
            }
            if (f >= 0.0 && f <= 1.0)
            {
                return (2.0f / 3.0f) + (0.5f) * (f * f * f) - (f * f);
            }
            else if (f > 1.0 && f <= 2.0)
            {
                return (float)(1.0f / 6.0f * Math.Pow((2.0f - f), 3.0f));
            }
            return 1.0f;
        }

        private static readonly Vector3 _MathU_FaceToPos_VEmpty = new Vector3(0f, 0f, 0f);
        public static Vector3 MathU_FaceToPos(Vector3 aPosition, Vector3 tPosition)
        {
            Vector3 fwd = tPosition - aPosition;
            fwd.y = 0f;
            fwd.Normalize();
            if (_MathU_FaceToPos_VEmpty == fwd)
                return new Vector3(0, 0, 1);
            return fwd;
        }
        public static Vector3 MathU_FaceToPos(GameObject a, GameObject t)
        {
            Vector3 fwd = t.Position - a.Position;
            fwd.y = 0f;
            fwd.Normalize();
            if (_MathU_FaceToPos_VEmpty == fwd)
                return new Vector3(0, 0, 1);
            return fwd;
        }

        public static float MathU_CatMullRom(float x)
        {
            float b = 0.0f;
            float c = 0.5f;
            float f = x;

            if (f < 0.0)
            {
                f = -f;
            }
            if (f < 1.0)
            {
                return (float)((12.0 - 9.0 * b - 6.0 * c) *
                        (f * f * f) + (-18.0 + 12.0 * b + 6.0 * c) *
                        (f * f) + (6.0 - 2.0 * b)) / 6.0f;
            }
            else if (f >= 1.0 && f < 2.0)
            {
                return (float)((-b - 6.0 * c) * (f * f * f) +
                        (6.0 * b + 30.0 * c) * (f * f) +
                        (-(12.0 * b) - 48.0 * c) * f +
                        8.0 * b + 24.0 * c) / 6.0f;
            }
            else
            {
                return 0.0f;
            }
        }
        /* Fix?
System.NullReferenceException: A null value was found where an object instance was required.
#0: 0x0000e callvirt   in Sims3.Gameplay.Objects.Insect.Sims3.Gameplay.Objects.Insect.Terrarium:GetLocalizedName () ()
#1: 0x0001c callvirt   in NRaas.Common+Logger`1:Convert (Sims3.SimIFace.IScriptLogic,NRaas.Common/StringBuilder,NRaas.Common/StringBuilder) ([4B1DFBE0] [3A7E0E60] [3A7E0E00] )
#2: 0x00032 call       in NRaas.NRaas.Common:Exception (Sims3.SimIFace.IScriptLogic,Sims3.SimIFace.IScriptLogic,NRaas.Common/StringBuilder,System.Exception) ([3B7A5C00] [4B1DFBE0] [00000000] [3B375428] )
#3: 0x0000d call       in NRaas.NRaas.Common:Exception (Sims3.SimIFace.IScriptLogic,Sims3.SimIFace.IScriptLogic,System.Exception) ([3B7A5C00] [4B1DFBE0] [3B375428] )
#4: 0x000e9 call       in NRaas.CommonSpace.Interactions.CommonInteraction`2+CommonDefinition`1:AddInteractions (Sims3.Gameplay.Autonomy.InteractionObjectPair,Sims3.Gameplay.Interfaces.IActor,Sims3.Gameplay.Abstracts.GameObject,System.Collections.Generic.List`1) (3BC10B00 [3BCB0978] [3B7A5C00] [4B1DFBE0] [975714488/0x3a2838b8] )
         */
        /*
        public static bool bmethed_METestAddInteractionErrorTestPMPP = true;
        public static bool bmethed_METestAddInteractionErrorTestPMPbP = true;

        public static void METestAddInteractionErrorTestPMPP(InteractionDefinition e, InteractionObjectPair iop, Sim ActiveActor)
        {
            if (!bmethed_METestAddInteractionErrorTestPMPP) return;
            try
            {
                e.Equals(e);
                e.GetHashCode();
            }
            catch (Exception ex) // unprotected mono mscorlib 
            {
                ex.stack_trace = null;
                ex.trace_ips = null;
                ex.message = "";
                ex.inner_exception = null;
                throw;
            }
            bool sot = iop.mTarget == null;
            GreyedOutTooltipCallback g = null;
            try
            {
                if (sot)
                    iop.mTarget = NiecRunCommand.HitTargetGameObject();

                InteractionInstanceParameters aa = new InteractionInstanceParameters(iop, ActiveActor, new InteractionPriority(InteractionPriorityLevel.UserDirected), AutonomySearchType.None, InteractionFlags.None, NiecRunCommand.GetGameObjectHit(), null, false);
                if (bmethed_METestAddInteractionErrorTestPMPbP || e.Test(ref aa, ref g) == InteractionTestResult.Pass)
                {
                    //aa = new InteractionInstanceParameters(iop, ActiveActor, new InteractionPriority(InteractionPriorityLevel.UserDirected), AutonomySearchType.None, InteractionFlags.None, NiecRunCommand.GetGameObjectHit(), null, false);
                    int i = 0;
                    var s = NiecRunCommand.GetUnSafeContextList<ObjectPicker.TabInfo>();
                    List_FastClearEx(ref s);
                    var r = NiecRunCommand.GetUnSafeContextList<ObjectPicker.HeaderInfo>();
                    List_FastClearEx(ref r);

                    e.PopulatePieMenuPicker(ref aa, out s, out r, out i);
                }
            }
            finally { if (sot) iop.mTarget = null; }
        }
       */

        public static object OnFunc_TestAddInteractionError = null;

        public static
            bool AutoActiveActor()
        {
            if (PlumbBob.sSingleton == null) 
                return false;

            for (int i = 0; i < 5; i++)
            {
                PlumbBob.ForceSelectActor(null);
                ActiveActor = null;
            }

            PlumbBob.sCurrentNonNullHousehold = null;
            PlumbBob.sSingleton.mSelectedActor = null;

            ActiveActor = null;

            Sim rsim = null;
            foreach (var item in SC_GetObjects<Sim>())
            {
                if (item == null) continue;
                var simd = item.SimDescription;
                if (simd == null || !simd.IsValidDescription) 
                    continue;

                if (simd.mSim != item) 
                    continue;

                var household = simd.Household;
                if (household == null || !Household_IsSafeHousehold(household)) 
                    continue;

                rsim = item;
                break;
            }

            if (rsim == null)
                return false;

            for (int i = 0; i < 5; i++)
            {
                PlumbBob.ForceSelectActor(null);
                ActiveActor = null;
            }

            PlumbBob.sCurrentNonNullHousehold = null;
            PlumbBob.sSingleton.mSelectedActor = null;

            ActiveActor = rsim;

            return ActiveActor != null;
        }


        public static
            bool FixUpIfActiveActorNoHousehold()
        {
            var activeActor = ActiveActor;
            if (activeActor == null) return false;
            var simd = activeActor.SimDescription;
            if (simd == null)
            {
                PlumbBob.sCurrentNonNullHousehold = null;
                PlumbBob.sSingleton.mSelectedActor = null;

                //ActiveActor = null;
                //var t = AutoActiveActor();
                NiecRunCommand.forcesetaa3_Command(GetRandomSim(SimIsValidFromLoadingSaveFile), false, false);
                var t = ActiveActor != null;
                NiecException.WriteLog("FixUpIfActiveActorNoHousehold() if (simd == null) ok AutoActiveActor: " + t);
                return t;
            }
            var household = simd.Household;
            if (household == null || household.LotHome == null)
            {
                NiecException.WriteLog("FixUpIfActiveActorNoHousehold() if (household == null || household.LotHome == null) ok\n Desc Vaild: " + simd.IsValidDescription);
                var t = GetFirstHouseholdExFunc(Household_IsSafeHouseholdFromLoadingSaveFile);
                if (t == null)
                {
                    t = Household_Create(simd);
                    if (t.LotHome == null) {
                        MoveOutAllHousehold();
                        Create.AutoMoveInLotFromHousehold(t);
                        ForceAllMoveIn();
                    }
                }
                else
                {
                    Household_Add(t, simd, false);
                    if (ActiveHousehold.LotHome == null)
                    {
                        MoveOutAllHousehold();
                        Create.AutoMoveInLotFromHousehold(ActiveHousehold);
                        ForceAllMoveIn();
                    }
                }
                return ActiveHousehold != null;
            }
            return false;
        }





        internal static NMAntiSpyException _AntiSpy_ThrowDefault = null;
        internal static NMAntiSpyException _AntiSpy_ThrowDefault01 = null;
        public static void AntiSpy_ThrowDefault() {
            Exception ex = null;
            try
            {
                if (_AntiSpy_ThrowDefault != null)
                    _AntiSpy_ThrowDefault.No_EA_Collect_Exception_ToString = true;
                else {
                    _AntiSpy_ThrowDefault = new NMAntiSpyException("") { No_EA_Collect_Exception_ToString = true };
                }
                ex = _AntiSpy_ThrowDefault;
                //ThrowOtherException(_AntiSpy_ThrowDefault);
                throw _AntiSpy_ThrowDefault;
                    //(_AntiSpy_ThrowDefault ?? (_AntiSpy_ThrowDefault = new NiecModException("") { No_EA_Collect_Exception_ToString = true }));
            }
            catch (StackOverflowException exc)
            {
                exc.stack_trace = null;
                exc.trace_ips = null;
                exc.message = "";
                throw;
            }
            catch
            {
                //ex.message = Message ?? "";
                ex.class_name = null;
                ex.stack_trace = null;
                ex.trace_ips = null;
                ex.inner_exception = null;
                ex.source = null;
                ex = null;
                throw;
            }
        }

        public static bool BuLot(Lot TargetLot, bool Force)
        {
            if (TargetLot == null || TargetLot.IsWorldLot) 
                return false;
            if (!Force)
            {
                try
                {
                    bool isVaild = false;
                    foreach (var item in LotManager.sLots.Keys)
                    {
                        if (item == TargetLot.LotId)
                        {
                            isVaild = true;
                        }
                    }
                    if (!isVaild)
                        return false;

                    if (World.LotIsEmpty(TargetLot.LotId) && TargetLot.IsLotEmptyFromObjects())
                        return true;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
            }

            Sim ActiveActor = NFinalizeDeath.ActiveActor;
            if (ActiveActor != null && ActiveActor.LotCurrent == TargetLot)
            {
                ActiveActor.SetPosition(Create.GetPositionInRandomLot(LotManager.GetWorldLot()));
            }
            try
            {
                NFinalizeDeath.DestroyAllObjectsOnLot(TargetLot, true, true, AssemblyCheckByNiec.IsInstalled("AweCore"));
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            
            ActiveActor = NFinalizeDeath.ActiveActor;

            if (ActiveActor != null && ActiveActor.LotCurrent == TargetLot)
            {
                ActiveActor.SetPosition(Lot_SafeGetPositionInRandomLot(LotManager.GetWorldLot()));
            }

            try
            {
                Lot_Bulldoze(TargetLot, false, true, true, false);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            return SC_GetObjectsOnLot<GameObject>(TargetLot).Length == 0 && World.LotIsEmpty(TargetLot.LotId);
        }

        private static bool _PShouldKeepSpawnerAfterBulldoze(SpawnerBase spawner)
        {
            if (spawner.StaysAfterBulldoze)
            {
                return spawner.Level >= 0;
            }
            return false;
        }

        public static void Lot_Bulldoze(Lot _This,bool bAllowDestruction, bool bRestartLotRenderer, bool bForceIncludeSpawners, bool bAllowEnsureObjects)
        {
            if (_This == null) 
                throw new NullReferenceException();
            try
            {
                foreach (var seasonalLotMarker in SC_GetObjectsOnLot<SeasonalLotMarker>(_This))
                {
                    ForceDestroyObject(seasonalLotMarker, false);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }


            List<SpawnerBase> listSpawnerBase = null;
            Vector3[] verSpawnerList = null;

            try
            {
                if (!bForceIncludeSpawners)
                {
                    listSpawnerBase = new List<SpawnerBase>();
                    var listTemp = SC_GetObjectsOnLot<SpawnerBase>(_This);
                    foreach (var item in listTemp)
                    {
                        if (item != null && _PShouldKeepSpawnerAfterBulldoze(item))
                        {
                            listSpawnerBase.Add(item);
                        }
                    }

                    verSpawnerList = new Vector3[listSpawnerBase.Count];
                    for (int j = 0; j < listSpawnerBase.Count; j++)
                    {
                        verSpawnerList[j] = listSpawnerBase._items[j].Position;
                        listSpawnerBase._items[j].SetPosition(Vector3.OutOfWorld);
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            

            try
            {
                RealEstateManager.OnLotBulldozed(_This);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            

            bool isDeleteLot = bAllowDestruction && World.LotIsEmpty(_This.LotId);

            ScriptCore.World.World_BulldozeLotImpl(_This.LotId, bAllowDestruction, bRestartLotRenderer);

            try
            {
                if (listSpawnerBase != null)
                {
                    for (int k = 0; k < listSpawnerBase.Count; k++)
                    {
                        listSpawnerBase._items[k].SetPosition(verSpawnerList[k]);
                    }
                }


                if (_This.mSavedData.mOpportunityHelper != null)
                {
                    _This.mSavedData.mOpportunityHelper.CancelOpportunity();
                }

                if (bAllowDestruction)
                {
                    if (_This.mVirtualSlotHouseholds != null && _This.mVirtualSlotHouseholds.Count > 0)
                    {
                        _This.VirtualMoveOut(_This.mVirtualSlotHouseholds);
                    }
                    if (_This.mVirtualSlotSims != null && _This.mVirtualSlotSims.Count > 0)
                    {
                        _This.VirtualMoveOut(_This.mVirtualSlotSims);
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            

            _This.mImportedDoorList = null;
            _This.mImportedResidentList = null;
            _This.mImportedDoorIsHouseholdList = null;

            if (_This.IsCommunityLot)
            {
                _This.CommercialLotSubType = CommercialLotSubType.kMisc_NoVisitors;
            }

            try
            {
                if (isDeleteLot)
                {
                    if (_This.IsHouseboatLot())
                    {
                        Houseboat houseboat = _This.GetHouseboat();
                        if (houseboat != null)
                        {
                            houseboat.Destroy();
                        }
                    }
                    MetaAutonomyManager.RemoveHotSpotsOrDeadZoneIfNecessary(_This);
                }
                else
                {
                    Occupation.OnBulldozeLot(_This);
                    if (bAllowEnsureObjects)
                    {
                        _This.EnsureLotObjects();
                    }

                    _This.Name = "";
                    _This.Description = "";
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
        }



        public static int IsSTAwesomeMod_SleepS = 0;

        public static int IsSTAwesomeMod_Sleep = 0;

        

        public static bool IsSTAwesomeMod()
        {
            string st = GetStackTraceToString(new StackTrace(2), false);
            if (st != null && !st.Contains("ScriptProxy.OnScriptError") && !st.Contains("NiecHelperSituation") && !st.Contains("ScriptProxy.OnReset"))
                return true;
            return false;
        }

       
        public static MethodInfo sIs_m_OnScriptError = null;
        public static MethodInfo sIs_m_OnResetGameObject = null;
        public static bool IsSTAwesomeMod02Fast<T>() where T : GameObject
        {
            if (sIs_m_OnScriptError == null) 
                return false;
            try
            {
                if (!Simulator.CheckYieldingContext(false))
                {
                    return false;
                }
            }
            catch (NotSupportedException ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
                return false;
            }
           
            //ScriptExecuteType eType;
            if ((GetObject_internalFast(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) as T) == null)
            {
                return false;
            }
            try
            {
                //return !NStackTrace.FastIsCallStackMethed(sIs_m_OnScriptError, true);
                if (NStackTrace.FastIsCallStackMethed(sIs_m_OnScriptError, true))
                {
                    NiecHelperSituation.IsSTAwesomeModFast_Sleep++;
                    if (NiecHelperSituation.IsSTAwesomeModFast_Sleep >= NiecHelperSituation.IsSTAwesomeModFast_SleepMax)
                        IsSTAwesomeModFast_SleepMethed();
                    return false;
                }
                return true;
            }
            catch (StackOverflowException)
            {
                if (NiecRunCommand.isstsleepmax)
                {
                    Simulator.Sleep(uint.MaxValue);
                    return false;
                }
                if (IsOpenDGSInstalled) { }
                else { ThrowResetException(null); }
                throw;
            }
        }

        public static bool IsSTAwesomeMod02<T>(bool shouldIsNotT, bool isPEvent, bool isRunningTaskReset) where T : GameObject
        {
            //if (shouldIsSim && Simulator.CheckYieldingContext(false) && GetCurrentGameObject<Sim>() == null) {
            //    return false;
            //}
            //T objGame = null;
            if (!shouldIsNotT)
            {
                if (!Simulator.CheckYieldingContext(false))
                {
                    return false;
                }
                //objGame = (GetObject_internalFast(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) as T);
                //if (objGame == null)
                if ((GetObject_internalFast(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) as T) == null)
                {
                    return false;
                }
            }
            // && !st.Contains("ScriptProxy.OnScriptError") && !st.Contains("NiecHelperSituation") && !st.Contains("ScriptProxy.OnReset") && (!isPEvent || !st.Contains("EventTracker.ProcessEvent")))
            string st;
            try
            {
                st = GetStackTraceToStringFast(new NStackTrace(2, false), false);
            }
            catch (StackOverflowException) 
            {
                if (NiecRunCommand.isstsleepmax)
                {
                    Simulator.Sleep(uint.MaxValue);
                    return false;
                }
                if (IsOpenDGSInstalled) { }
                else { ThrowResetException(null);}
                throw;
            }
            
            if (st != null)
            {

                if (st.Contains("ScriptProxy.OnScriptError"))
                {
                    IsSTAwesomeMod_SleepMethed(shouldIsNotT);
                    return false;
                }
                if (st.Contains("NiecHelperSituation"))
                {
                    IsSTAwesomeMod_SleepMethed(shouldIsNotT);
                    return false;
                }
                if (isRunningTaskReset && st.Contains("ScriptProxy.OnReset"))
                {
                    IsSTAwesomeMod_SleepMethed(shouldIsNotT);
                    return false;
                }
                if (isPEvent && st.Contains("EventTracker.ProcessEvent"))
                {
                    IsSTAwesomeMod_SleepMethed(shouldIsNotT);
                    return false;
                }
                return true;
            } 
            return false;
        }

        public static void ResetEvList(ref EventListener rtt, ProcessEventDelegate func)
        {
            if (EventTracker.sInstance == null) return;
            rtt = EventTracker.AddListener(rtt.EventId, func);
        }

        public static void IsSTAwesomeMod_SleepMethed(bool shouldIsNotT)
        {
            IsSTAwesomeMod_Sleep++;
            if (!shouldIsNotT && IsSTAwesomeMod_Sleep > 20 && Simulator.CheckYieldingContext(false))
            {
                IsSTAwesomeMod_Sleep = 0;
                bool isOnSccen = ScriptCore.World.World_IsObjectOnScreenImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl());
                if (GetCurrentExecuteType() == ScriptExecuteType.Task)
                    Simulator.Sleep(isOnSccen ? 105u : 1640u);
                else
                    Simulator.Sleep(isOnSccen ? 1u : 415u);
            }
        }
        public static void IsSTAwesomeModFast_SleepMethed()
        {
            NiecHelperSituation.IsSTAwesomeModFast_Sleep = 0;
           // bool isOnSccen = ScriptCore.World.World_IsObjectOnScreenImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl());
            if (GetCurrentExecuteType() == ScriptExecuteType.Task)
                Simulator.Sleep(ScriptCore.World.World_IsObjectOnScreenImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) ? 405u : 3340u);
            else
                Simulator.Sleep(ScriptCore.World.World_IsObjectOnScreenImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) ? 0u : 445u);
        }
        public static bool IsSTAwesomeMod04<T>(bool shouldIsNotT, bool isPEvent, bool isRunningTaskReset, int skipFrames) where T : GameObject
        {
            //if (shouldIsSim && Simulator.CheckYieldingContext(false) && GetCurrentGameObject<Sim>() == null) {
            //    return false;
            //}
            
            if (!shouldIsNotT)
            {
                if (!Simulator.CheckYieldingContext(false))
                {
                    return false;
                }
                //if (GetCurrentGameObjectFast<T>() == null)
                if ((GetObject_internalFast(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) as T) == null)
                {
                    return false;
                }
            }
            // && !st.Contains("ScriptProxy.OnScriptError") && !st.Contains("NiecHelperSituation") && !st.Contains("ScriptProxy.OnReset") && (!isPEvent || !st.Contains("EventTracker.ProcessEvent")))
            if (skipFrames < 0)
                skipFrames = 0;

            string st;
            try
            {
                st = GetStackTraceToStringFast(new NStackTrace(skipFrames, false), false);
            }
            catch (StackOverflowException)
            {
                if (IsOpenDGSInstalled) { }
                else
                {
                    if (NiecRunCommand.isstsleepmax)
                    {
                        Simulator.Sleep(uint.MaxValue);
                        return false;
                    }
                    ThrowResetException(null);
                }
                throw;
            }

            if (st != null)
            {


                if (st.Contains("ScriptProxy.OnScriptError"))
                {
                    STACoreSleep03_Sleep();
                    return false;
                }
                if (st.Contains("NiecHelperSituation"))
                {
                    STACoreSleep03_Sleep();
                    return false;
                }
                if (isRunningTaskReset && st.Contains("ScriptProxy.OnReset"))
                {
                    STACoreSleep03_Sleep();
                    return false;
                }
                if (isPEvent && st.Contains("EventTracker.ProcessEvent"))
                {
                    STACoreSleep03_Sleep();
                    return false;
                }
                    
                return true;
            }
            return false;
        }

        public static void STACoreSleep03_Sleep()
        {
            IsSTAwesomeMod_SleepS++;
            if (IsSTAwesomeMod_SleepS > 13 && Simulator.CheckYieldingContext(false))
            {
                IsSTAwesomeMod_SleepS = 0;
                Simulator.Sleep(50);
            }
        }

        public static bool IsSTAwesomeMod03(bool isPEvent)
        {
            //if (shouldIsSim && Simulator.CheckYieldingContext(false) && GetCurrentGameObject<Sim>() == null) {
            //    return false;
            //}

            //string st = GetStackTraceToString(new StackTrace(2), false);
            //if (st != null && !st.Contains("ScriptProxy.OnScriptError") && !st.Contains("NiecHelperSituation") && !st.Contains("ScriptProxy.OnReset") && (!isPEvent || !st.Contains("EventTracker.ProcessEvent")))
            //    return true;

            string st = GetStackTraceToString(new StackTrace(2), false);
            if (st != null)
            {
                if (st.Contains("ScriptProxy.OnScriptError"))
                    return false;
                if (st.Contains("NiecHelperSituation"))
                    return false;
                if (st.Contains("ScriptProxy.OnReset"))
                    return false;
                if (isPEvent && st.Contains("EventTracker.ProcessEvent"))
                    return false;
                return true;
            } 
            return false;
        }

        public static object TestAddInteractionError_data01 = null;
        public static void TestAddInteractionError()//(bool bNoNeedTask)
        {
            if (IsOpenDGSInstalled)// || (!bNoNeedTask && GetCurrentExecuteType() != ScriptExecuteType.Task))
                return;

            //Simulator.CheckYieldingContext(true);

            if (GetCurrentExecuteType() != ScriptExecuteType.Task)
            {
                throw new InvalidOperationException("if GetCurrentExecuteType() != ScriptExecuteType.Task");
            }

            Simulator.Sleep(0); // check yield

            if (TestAddInteractionError_data01 is IStringTable)
            {
                Sims3.SimIFace.StringTable.gStringTable = TestAddInteractionError_data01 as IStringTable;
                TestAddInteractionError_data01 = null;
            }

            List<InteractionObjectPair> listTemp = new List<InteractionObjectPair>(5000);
            List<InteractionObjectPair> listkeep = null;

            GameObject targetObjectBack__ = null;

            MethodBase methed_AddInteractions = null;
            MethodBase methed_GetAllInteractionsForActor = null;
            MethodBase methed_METestAddInteractionErrorTestPMPP = null;

            try
            {
                methed_GetAllInteractionsForActor = typeof(GameObject).GetMethod
                    ("GetAllInteractionsForActor", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                methed_AddInteractions = typeof(InteractionObjectPair).GetMethod
                    ("AddInteractions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            }
            catch (Exception)
            {}

            try
            {
                methed_METestAddInteractionErrorTestPMPP = typeof(a).GetMethod("_", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            }
            catch (Exception)
            {}

            bool ciscrr = false;
            while (true)
            {
                // Do not use try/catch 
                // Do not use SpeedTrap.Sleep(); or NRaas.Comman.Sleep();
                // What? command run remove task. game loop!
                // Caused by niecmod removetask

                Simulator.Sleep(0); // is recommended.
                
                try
                {
                    Sim activeActor = ActiveActor;
                    if (targetObjectBack__ == null && activeActor == null)
                        continue;

                    var targetGameObject = NiecRunCommand.HitTargetGameObject() ?? NiecRunCommand.HitTargetLot();
                    //if (targetGameObject == null)
                    if (targetObjectBack__ != null && targetObjectBack__ != targetGameObject)
                    {

                        if (listkeep == null)
                        {
                            niec_std.assert("listkeep == null");

                            if (GetCurrentExecuteType() == ScriptExecuteType.Task)
                                Simulator.Sleep(50);
                            else
                                Simulator.Sleep(0);

                            targetObjectBack__ = null;
                            continue;
                        }
                        targetObjectBack__.mInteractions = listkeep;
                        listkeep = null;
                        if (ciscrr)
                        {
                            ciscrr = false;
                            targetObjectBack__.AddFlags(GameObject.FlagField.Charred);
                        }
                        targetObjectBack__ = null;
                       
                      
                        continue;
                    }

                    if (targetGameObject == null)
                        continue;

                    if (listkeep != null)
                        continue;

                    if (activeActor == null)
                        continue;
                  
                    if (targetGameObject.Charred)
                    {
                        ciscrr = true;
                        targetGameObject.RemoveFlags(GameObject.FlagField.Charred);
                    }
                    if (targetGameObject.mInteractions == null)
                    {
                        try
                        {

                            List<InteractionObjectPair> st;
                            if (methed_GetAllInteractionsForActor != null)
                            {
                                st = methed_GetAllInteractionsForActor.Invoke(targetGameObject, new object[] { activeActor }) as List<InteractionObjectPair>;
                            }
                            else
                            {
                                st = targetGameObject.GetAllInteractionsForActor(activeActor);
                            }
                            if (st != null)
                                st.Clear();
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception ex)
                        {
                            // !(ex is TargetInvocationException)) {
                            if (ex != null && ex.Source == "mscorlib" && ex.inner_exception != null)
                            {
                                ex.inner_exception = null;
                                ex.stack_trace = null;
                                ex.trace_ips = null;
                                ex.message = "";
                            }
                        }
                        // mono runtime error no Exception
#pragma warning disable 1058
                        catch { }
#pragma warning restore 1058
                    }
                    var insInteractions = targetGameObject.mInteractions;

                    if (insInteractions == null)
                        continue;
                    if (insInteractions._items == null)
                    {
                        targetGameObject.mInteractions = null;
                        continue;
                    }

                    try
                    {
                        while (insInteractions.Remove(null)) { }
                    }
                    catch (StackOverflowException)
                    {
                        throw;
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch {
                        targetGameObject.mInteractions = new List<InteractionObjectPair>();
                        continue;
                    }

                    try
                    {
                        Instantiator.AddInteractions(targetGameObject as Sim);
                        var func = OnFunc_TestAddInteractionError as Predicate<GameObject>;
                        if (func != null && func.method_info != null)
                            func(targetGameObject);
                    }
                    catch (StackOverflowException)
                    {
                        throw;
                    }
                    catch (ResetException)
                    { throw; }
                    catch { }

                    listkeep = new List<InteractionObjectPair>(insInteractions);
                    targetObjectBack__ = targetGameObject;

                    object[] tempPar = null;
                    object[] tempPar2 = null;

                    bool cachemethed_AddInteractionIsNotNull = methed_AddInteractions != null;
                    bool cachemethed_METestAddInteractionErrorTestPMPPIsNotNull = a.a_ && methed_METestAddInteractionErrorTestPMPP != null;

                    if (cachemethed_AddInteractionIsNotNull)
                    {
                        tempPar = new object[] { activeActor, listTemp };
                    }
                    if (cachemethed_METestAddInteractionErrorTestPMPPIsNotNull) {
                        tempPar2 = new object[] { null, null, activeActor };
                    }

                    //bool doneciscrr = false;
                    if (ciscrr)
                    {
                        try
                        {
                            insInteractions.Add(new InteractionObjectPair(RepairableComponent.Replace.Singleton, targetGameObject));
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }
                    }

                    foreach (var testInteraction in insInteractions.ToArray())
                    {
                       
                        if (cachemethed_AddInteractionIsNotNull)
                        {
                            if (testInteraction == null)
                            {
                                while (insInteractions.Remove(testInteraction)) { }
                                continue;
                            }
                            try
                            {
                                TestAddInteractionError_data01 = Sims3.SimIFace.StringTable.gStringTable;
                                Sims3.SimIFace.StringTable.gStringTable = null;

                                methed_AddInteractions.Invoke(testInteraction, tempPar); // info: tempPar = new object[] {activeActor, listTemp};
                                if (cachemethed_METestAddInteractionErrorTestPMPPIsNotNull)
                                {
                                    // info: tempPar2 = new object[] {  testInteraction.InteractionDefinition, testInteraction, activeActor };
                                    tempPar2[0] = testInteraction.InteractionDefinition;
                                    tempPar2[1] = testInteraction;
                                    methed_METestAddInteractionErrorTestPMPP.Invoke(null, tempPar2);
                                }
                                else a._(testInteraction.InteractionDefinition, testInteraction, activeActor);
                            }
                            // command: (dgsmods exlists) info: create log Exception Lists
                            catch (StackOverflowException) { throw; }
                            catch (Exception ex)
                            {
                                // !(ex is TargetInvocationException)) {
                                if (ex != null && ex.Source == "mscorlib" && ex.inner_exception != null)
                                {
                                    ex.inner_exception = null;
                                    ex.stack_trace = null;
                                    ex.trace_ips = null;
                                    ex.message = "";
                                }
                                while (insInteractions.Remove(testInteraction)) { }
                            }
                            // mono runtime error no Exception
#pragma warning disable 1058
                            catch
                            {
                                while (insInteractions.Remove(testInteraction)) { }
                            }
#pragma warning restore 1058
                            finally
                            {
                                if (TestAddInteractionError_data01 is IStringTable)
                                {
                                    Sims3.SimIFace.StringTable.gStringTable = TestAddInteractionError_data01 as IStringTable;
                                    TestAddInteractionError_data01 = null;
                                }
                                listTemp.Clear();
                            }

                        }
                        else
                        {
                            try
                            {
                                TestAddInteractionError_data01 = Sims3.SimIFace.StringTable.gStringTable;
                                Sims3.SimIFace.StringTable.gStringTable = null;

                                testInteraction.AddInteractions(activeActor, listTemp); // info: tempPar = new object[] {activeActor, listTemp};
                                if (cachemethed_METestAddInteractionErrorTestPMPPIsNotNull)
                                {
                                    // info: tempPar2 = new object[] {  testInteraction.InteractionDefinition, testInteraction, activeActor };
                                    tempPar2[0] = testInteraction.InteractionDefinition;
                                    tempPar2[1] = testInteraction;
                                    methed_METestAddInteractionErrorTestPMPP.Invoke(null, tempPar2);
                                }
                                else a._(testInteraction.InteractionDefinition, testInteraction, activeActor);
                            }
                            catch (StackOverflowException) { throw; }
                            catch // command: (dgsmods exlists) info: create log Exception Lists
                            {
                                while (insInteractions.Remove(testInteraction)) { }
                            }
                            finally
                            {
                                if (TestAddInteractionError_data01 is IStringTable)
                                {
                                    Sims3.SimIFace.StringTable.gStringTable = TestAddInteractionError_data01 as IStringTable;
                                    TestAddInteractionError_data01 = null;
                                }
                                listTemp.Clear();
                            }
                        }
                    }
                    tempPar = null;
                }
                catch (StackOverflowException)
                {
                    for (int i = 0; i < 855; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
                catch (ResetException)
                { throw; }
                catch
                {
                    for (int i = 0; i < 125; i++)
                    {
                        Simulator.Sleep(0);
                    }
                    List_FastClearEx(ref listTemp);
                }
                
            }
        }


        public static float MathU_Bell(float x)
        {
            float f = (x / 2.0f) * 1.5f;

            if (f > -1.5f && f < -0.5f)
            {
                return (0.5f * (float)Math.Pow((f + 1.5f), 2.0f));
            }
            else if (f > -0.5f && f < 0.5f)
            {
                return 3.0f / 4.0f - (f * f);
            }
            else if ((f > 0.5f && f < 1.5f))
            {
                return (0.5f * (float)Math.Pow(f - 1.5f, 2.0f));
            }
            return 0.0f;
        }

        public static
            void TestFixList<T>(List<T> list) // unprotected mono mscorlib 
        {
            if (list == null) 
                return;
            if (list._items == null)
            {
                list._size = 0;
                list._items = new T[5];
            }
            //else if (list._items.Length < list._size)
            //{
            //    list._size = 0;
            //    list._items = new T[5];
            //}
            
        }

        public static Vector3 GetPositionBase(ulong objID)
        {
            if (objID == 0) return default(Vector3);
           return ScriptCore.Objects.Objects_GetPosition(objID);
        }

        public static Vector3 GetPositionBase(ObjectGuid objID)
        {
            if (objID.mValue == 0) return default(Vector3);
           return ScriptCore.Objects.Objects_GetPosition(objID.mValue);
        }

        public static Vector3 GetForwardBase(ulong objID)
        {
            if (objID == 0) return new Vector3(0, 0, 1);
            return ScriptCore.Objects.Objects_GetForward(objID);
        }
        public static Vector3 GetForwardBase(ObjectGuid objID)
        {
            if (objID.mValue == 0) return new Vector3(0, 0, 1);
            return ScriptCore.Objects.Objects_GetForward(objID.mValue);
        }
        public static void CheckNHSP() {
            if (Simulator.CheckYieldingContext(false)) {
                Sim currentSim = GetCurrentGameObjectFast<Sim>();
                if (currentSim != null && currentSim.Posture is NiecHelperSituationPosture) {
                    NiecHelperSituationPosture.r_internal(currentSim);
                }
            }
        }
        public static void CheckNHSPFast(Sim currentSim)
        {
            if (Simulator.CheckYieldingContext(false))
            {
                //Sim currentSim = GetCurrentGameObjectFast<Sim>();
                if (currentSim != null && currentSim.Posture is NiecHelperSituationPosture)
                {
                    NiecHelperSituationPosture.r_internal(currentSim);
                }
            }
        }

        public static 
            S GetSituationFromSituationList<S>(List<Situation> pSituationList)
            where S : Situation 
        {
            if (pSituationList == null) 
                return null;
            //TestFixList(pSituationList);
            foreach (var item in pSituationList)
            {
                S val = item as S;
                if (val != null)
                {
                    return val;
                }
            }
            return null;
        }

        public static void sims3NameToMinecraftNamePlayer(bool forcesp) {

            var sdFullList = UpdateNiecSimDescriptions(false, false, false);
            if (sdFullList == null || sdFullList.Count == 0) 
                return;

            MineCraftName();

            var sdlArray = sdFullList.ToArray();
            int _CserAamesNo = 0;
            var simdA = ActiveActor_SimDescription;

            for (int i = 0; i < sdlArray.Length; i++)
            {
                var simDesc = sdlArray[i];
                if (simDesc == null || simDesc.mHairColors == null || !simDesc.IsValidDescription) 
                    continue;
                if (i != 0)
                    _CserAamesNo++;
                if (!forcesp && (simDesc.IsPet || simDesc.IsBonehilda || SimIsGRReaper(simDesc) || simDesc.IsRobot || simDesc.IsTimeTraveler || simDesc.IsVampire || simDesc.IsMummy || simDesc.IsAlien))
                {
                    if (_CserAamesNo != 0)
                        _CserAamesNo--;
                    continue;
                }
                var nameU = getUserName(_CserAamesNo);
                if (nameU == null) 
                    break;

                simDesc.mFirstName = nameU;
                simDesc.mLastName = "";
                if (simDesc == simdA) {
                    simDesc.mFirstName = "TJamaTPA";
                }
            }
        }

        public static string getUserName(int index)
        {
            if (index < 0 || index >= _CserAames.Length)
            {
                return null;
            }
            return _CserAames[index];
        }


        internal static readonly string[] _CserAames = new string[] { 
        	"yanmelly18",
        	"g0ntiang",
        	"winnn9s",
        	"nohong27",
        	"olaewolk",
        	"mardykuran",
        	"barkkubda43",
        	"hola1",
        	"dita116",
        	"jackcalvinjc",
        	
        	"CrashOverride808",
        	"DOOMSWORD",
        	"iThePvPGoD",
        	"bryce111103",
        	"chizler332",
        	"MaxZ19",
        	"kazzax",
        	"ProShahar",
        	"youngking",
        	"tweste",
        	
        	"mythnet420",
        	"FzHuntrr",
        	"McLovin69",
        	"kimkim12",
        	"miickhail",
        	"raganlim",
        	"UlquiorraCifer",
        	"Naughty_Scopez",
        	"RojhVic707",
        	"miel141",
        	
        	"petermolit",
        	"clyde45",
        	"deadshotshadow",
        	"Muddy546",
        	"Atharva_15",
        	"CloudBC21",
        	"ImDamonH",
        	"SinzGamers190",
        	"xxXXRaven91XXxx",
        	"thesky",
        	
        	"EpicTissue",
        	"poopIsDaBaus",
        	"Kaled1503",
        	"FadeMeBro",
        	"iTzKhaled",
        	"momomofro123",
        	"XLDialgaLX",
        	"Justin0729",
        	"SKT1Impact",
        	"Zul97",
        	
        	"xXModXx",
        	"pooilyor",
        	"Stress",
        	"yoav765",
        	"liorpap",
        	"AilloDoa",
        	"imalittledevil",
        	"epicplayer2012",
        	"Creepatron05",
        	"kurt",
        	
        	"VG_Vanoss_VG",
        	"Fluflu007",
        	"Ninja_Squirrel",
        	"beastpro1251",
        	"R3SOL",
        	"TheColdFire",
        	"Oneeye",
        	"vary",
        	"cest07",
        	"wither_bossb",
        	
        	"CallMehAlec",
        	"Sir_Wabbitt",
        	"TheFish",
        	"JESturtlez",
        	"yanirx",
        	"leroyjankins",
        	"FoayAvg33",
        	"PinoyHack",
        	"djtkx",
        	"Boul77",
        	
        	"baggelis",
        	"enzo77700",
        	"HadiHamdanX2",
        	"GDawg55555",
        	"Farrel22Gamer",
        	"BAMitisMEWT",
        	"BloodDistruction",
        	"fr00b",
        	"RazorSpadee",
        	"xxosmhxx",
        	
        	"_otiy",
        	"Dotiydan100",
        	"gaooSdda",
        	"Eoti_Aoi",
        	"btoti_",
        	"botot20",
        	"AiauoOS",
        	"too9302",
        	"AOD_Heoe_AOD",
        	"Vohito",
        	
        	"yhlcoiro0000",
        	"EtoieDanman",
        	"Rtotpco12",
        	"artoiv_aoit",
        	"boaituaov333k",
        	"tosiao00l",
        	"ATOIS93",
        	"aorinbo00_",
        	"atofysn_aar",
        	"toaivut1515",
        	
            "Royivo4004",
        	"rtodap_vroe",
        	"Vot9i",
        	"tofir330b",
        	"EotiboTine",
        	"RuGuul",
        	"NINEinam",
        	"AoCot1",
        	"ZonMan",
        	"GlykaoM2k",
        	
        	"YiuioGamer",
        	"CyoEKUE",
        	"TofieoG33Man",
        	"hpiru",
        	"oyubo240_k",
        	"jogiro42",
        	"ltopONE",
        	"QortovGamer",
        	"Bmyo000",
        	"BiogCNPA1122",
        	
        	"EdamLueoad",
        	"Boyi_AV",
        	"iyoao30World",
        	"Xnbiro",
        	"540Doai",
        	"VxoivID",
        	"totipa20k",
        	"xXxXOIOXxXx",
        	"kyhi53",
        	"PAOAMC",
        	
        	"Michael12",
        	"mnj12",
        	"lu01ke",
        	"gustavo2424",
        	"pascal11",
        	"Natsu9022_gamer",
        	"Allygoldminer",
        	"MATRIXJL17",
        	"360_The_Killer",
        	"Cyber_Pank",
        	
        	"linis99",
        	"jo13man",
        	"_AppleLP_",
        	"GoldenStars",
        	"RoxonPL",
        	"maiklhes",
        	"xProJarriex",
        	"ni5o",
        	"bobo0",
        	"VayDeeHouys",
        	
        	"huahuahuahua",
        	"DomiTenja123",
        	"AquaGoesCrazy",
        	"IsparKI",
        	"Mujkic123",
        	"boki_killer",
        	"tyventyven",
        	"necromh",
        	"building999",
        	"isidor",
        	
        	"Yarom8144",
        	"PaotHA",
        	"OmegaPlayz",
        	"ramonm12",
        	"Mujkic123",
        	"HugomgBug",
        	"Stijncool2000",
        	"MerFMan98",
        	"abdullah_craft",
        	"DJBroake",
        	
        	"pokefan101705",
        	"Muji786192",
        	"manu_stone",
        	"bamftsp2012",
        	"fadil1234",
        	"mato010",
        	"jonathanrgamer",
        	"nmd1414",
        	"abdullah_craft",
        	"djulian1",
        };


        public static readonly Vector3 Vector3_O = new Vector3(0, 0, 0);
        public static readonly Vector3 Vector3_OV = new Vector3(0, 0, 1);
        public static readonly Vector3 Vector3_OutOfWorld = new Vector3(-20000f, -20000f, -20000f);

        public static
            Sim SimDesc_SafeInstantiate(SimDescription simDesc, Vector3 pos)
        {
            if (simDesc == null) 
                return null;
            try
            {
                ValidateSimCreated(simDesc, null);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception) { return null; }


            bool isAweCore = AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") && AssemblyCheckByNiec.IsInstalled("AweCore");
            bool bc = isAweCore && simDesc.mHousehold == null;
            try
            {
                if (!IsOpenDGSInstalled && !isAweCore && simDesc.Household == null)
                    return simDesc.CreatedSim;

                if (simDesc.CreatedSim != null)
                    return simDesc.CreatedSim;

                try
                {
                    simDesc.Fixup();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    if ( simDesc.mSim != ActiveActor && simDesc != ActiveActor_SimDescription && !IsActiveHouseholdWithActiveActorPro(simDesc.Household, PlumbBob.SelectedActor))
                    {
                        if (isAweCore && !IsOpenDGSInstalled)
                        {
                            SimDescCleanse(simDesc, true, false);

                            simDesc.mIsValidDescription = true;
                            simDesc.mSimDescriptionId = 444555;
                            Household_Add(Household.sNpcHousehold, simDesc, false);
                            simDesc.mHousehold = Household.sNpcHousehold;
                            simDesc.mOutfits = new OutfitCategoryMap();
                            simDesc.Species = CASAgeGenderFlags.Human;
                            simDesc.Gender = CASAgeGenderFlags.Male;
                            simDesc.Age = CASAgeGenderFlags.Adult;
                            NiecException.PrintMessagePro("SimDesc_SafeInstantiate: AwesomeMod is unsafe.", false, 10);
                        }
                        else
                        {
                            SimDescCleanse(simDesc, true, false);
                            return null;
                        }
                    }
                }

                if (isAweCore || (simDesc.IsValidDescription && simDesc.IsValid))
                {
                    if (pos == Vector3_OutOfWorld)
                    {
                        pos = Lot_SafeGetPositionInRandomLot(simDesc.LotHome ?? LotManager.GetWorldLot());
                    }
                   
                    if (bc)
                    {
                        simDesc.mHousehold = Household.NpcHousehold;
                    }
                    Sim r = simDesc.Instantiate(pos, IsOpenDGSInstalled || ScriptCore.World.World_IsEditInGameFromWBModeImpl());
                    if (bc)
                    {
                        simDesc.mHousehold = null;
                    }
                    return r;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception) {
                if (bc)
                {
                    simDesc.mHousehold = null;
                }
                //SpeedTrap.Sleep(0);
                var sim = simDesc.CreatedSim;
                if (sim != null && GameObjectIsValid(sim.ObjectId.mValue))
                {
                    return sim;
                }
                else if (!isAweCore) {
                    simDesc.mSim = null;
                    ForceDestroyObject(sim, false);
                    return null;
                }
            }
            return simDesc.CreatedSim;
        }


        public static Household GetFirstHouseholdExActive()
        {
            Household ah = ActiveHousehold;
            foreach (var item in SC_GetObjects<Household>())
            {
                if (item == null || item == ah) 
                    continue;

                var members = item.mMembers;
                if (members == null)
                    continue;

                if (members.mAllSimDescriptions == null) continue;
                if (members.mPetSimDescriptions == null) continue;
                if (members.mSimDescriptions == null) continue;

                return item;
            }
            return null;
        }

        public static Household GetFirstHouseholdExFunc(Predicate<Household> func)
        {
            if (func == null)
                throw new ArgumentNullException("func");
            foreach (var item in SC_GetObjects<Household>())
            {
                if (!func(item)) 
                    continue;
                return item;
            }
            return null;
        }

        public static bool Household_IsSafeHousehold(Household household)
        {
            if (household == null || IsSpecialHousehold(household) || HouseholdIsRole(household))
                return false;

            var members = household.mMembers;
            if (members == null) 
                return false;

            if (members.mAllSimDescriptions == null) return false;
            if (members.mPetSimDescriptions == null) return false;
            if (members.mSimDescriptions == null)    return false;

            return !household.HasBeenDestroyed;
        }
        public static bool Household_IsSafeHouseholdFromLoadingSaveFile(Household household)
        {
            if (household == null || IsSpecialHousehold(household) || HouseholdIsRole(household))
                return false;

            var members = household.mMembers;
            if (members == null)
                return false;

            if (members.mAllSimDescriptions == null) return false;
            if (members.mPetSimDescriptions == null) return false;
            if (members.mSimDescriptions == null)    return false;

            return household.LotHome != null;
        }

        public static bool Household_IsSafeHousehold02(Household item)
        {
            return Household_IsSafeHouseholdFromLoadingSaveFile(item) && !item.HasBeenDestroyed;
        }

        public static Household GetSafeRandomHousehold()
        {
            return GetRandomGameObject<Household>(Household_IsSafeHousehold);
        }

        public static Household GetUnSafeRandomHousehold()
        {
            return GetRandomGameObject<Household>();
        }

        public static
            void HouseholdAllCreateSim(Household houseHold, Lot lot)
        {
            if (houseHold == null) 
                return;

            Lot worldLot = LotManager.GetWorldLot();
            Assert(worldLot != null, "LotManager.GetWorldLot() is Failed");
            var pos = Create.GetPositionInRandomLot(lot ?? worldLot);

            RemoveNullForHouseholdMembers(houseHold);
            foreach (SimDescription itemMember in houseHold.AllSimDescriptions.ToArray())
            {
                Assert(itemMember != null, "itemMember == null");
                if (itemMember == null) 
                    continue;

                SimDesc_SafeInstantiate(itemMember, pos);
            }
            if (houseHold.LotHome == lot)
            {
                Create.ForceSendHomeAllActors(houseHold);
            }
        }


        public static 
            S SafeGetSituationOfType<S>(Sim Actor) 
            where S : Situation
        {
            try
            {
                if (Actor == null)
                    return null;

                Autonomy automoy = Actor.Autonomy;
                if (automoy == null)
                    return null;

                SituationComponent sSituationComponent = automoy.SituationComponent;
                if (sSituationComponent == null)
                    return null;

                List<Situation> listSituations = sSituationComponent.Situations;
                if (listSituations == null)
                    return null;
                //if (!IsOpenDGSInstalled && !_IsActiveHousehold(Actor.Household)) // unprotected mono mscorlib 
                //{
                //    if (listSituations._items == null)
                //        listSituations._items = new Situation[0];
                //    if (listSituations._items.Length != listSituations._size)
                //    {
                //        listSituations._size = listSituations._items.Length;
                //        //listSituations._version++;
                //    }
                //}
                foreach (Situation situation in listSituations)
                {
                    S val = situation as S;
                    if (val != null)
                    {
                        return val;
                    }
                }
                return null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch { return null; }
            
        }

        public static S NewSafeGetSituationOfType<S>(Sim Actor)
            where S : Situation
        {
            try
            {
                if (Actor == null)
                    return null;

                Autonomy automoy = Actor.Autonomy;
                if (automoy == null)
                    return null;

                SituationComponent sSituationComponent = automoy.SituationComponent;
                if (sSituationComponent == null)
                    sSituationComponent = automoy.mSituationComponent = new SituationComponent();

                List<Situation> listSituations = sSituationComponent.Situations;
                if (listSituations == null)
                    listSituations = sSituationComponent.mSituations = new List<Situation>();
                else
                {
                    try
                    {
                        foreach (Situation situation in listSituations)
                        {
                            S val = situation as S;
                            if (val != null)
                            {
                                return val;
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception ex)
                    {
                        string ty = ex.Source;
                        if (ty != null && ty.Contains("mscorlib"))
                        {
                            sSituationComponent.mSituations = new List<Situation>();
                        }
                        else
                            throw;
                    }
                }
                return null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch { return null; }

        }

        public static readonly Predicate<Sim> DefaultTest_NiecSocialWorkerChildAbuseSituation = delegate(Sim obj)
        {
            if (obj == null)
                return false;
            if (obj == ActiveActor) 
                return false;

            SimDescription simd = obj.SimDescription;
            if (simd == null)
                return false;

            if (!simd.IsValidDescription)
                return false;

            if (simd.ChildOrBelow || simd.IsPet)
                return false;

            Household hold = simd.Household;
            if (hold == null)
                return false;


            if (obj.HasBeenDestroyed)
                return false;



            global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = obj.InteractionQueue;
            if (yInteractionQueue == null || yInteractionQueue.mInteractionList == null)
                return false;


            Autonomy automoy = obj.Autonomy;
            if (automoy == null)
                return false;

            SituationComponent sSituationComponent = automoy.SituationComponent;
            if (sSituationComponent == null)
                return false;

            List<Situation> listSituations = sSituationComponent.Situations;
            if (listSituations == null)
                return false;

            if (GetSituationFromSituationList<NiecSocialWorkerChildAbuseSituation>(listSituations) != null)
                return false;

            return true;
        };

        public static readonly Predicate<Sim> IsNPCSimTest_NiecSocialWorkerChildAbuseSituation = delegate(Sim obj)
        {
            if (obj == null)
                return false;

            SimDescription simd = obj.SimDescription;
            if (simd == null)
                return false;

            if (!simd.IsValidDescription)
                return false;

            if (simd.ChildOrBelow || simd.IsPet)
                return false;

            Household hold = simd.Household;
            if (hold == null)
                return false;

            if (hold == Household.ActiveHousehold)
                return false;

            if (obj.HasBeenDestroyed)
                return false;



            global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = obj.InteractionQueue;
            if (yInteractionQueue == null || yInteractionQueue.mInteractionList == null)
                return false;


            Autonomy automoy = obj.Autonomy;
            if (automoy == null)
                return false;

            SituationComponent sSituationComponent = automoy.SituationComponent;
            if (sSituationComponent == null)
                return false;

            List<Situation> listSituations = sSituationComponent.Situations;
            if (listSituations == null)
                return false;

            if (obj.GetSituationOfType<NiecSocialWorkerChildAbuseSituation>() != null)
                return false;

            return true;
        };

        private static Exception cache_GetST = null;

        public static
            string Get_Stack_Trace()  // unprotected mono mscorlib 
        {
            try
            {
                throw cache_GetST ?? (cache_GetST = new ResetException() { message = "" }); 
            }
            catch (Exception ex)
            {
                try
                {
                    return ex.StackTrace;
                }
                finally 
                {
                    ex.message = "";
                    ex.trace_ips = null;
                    ex.stack_trace = null;
                }
            }
        }
        public static 
            string GetObjectSTLite(ulong ObjectID) 
        { 
            int unused;
            return GetObjectSTLite(ObjectID, out unused);
        }

        public static
            void FixUpSimIsBad(Sim[] simList) 
        {
            var simAC = ActiveActor;
            foreach (var item in simList ?? SC_GetObjects<Sim>())
            {

                if (item == null) 
                    continue;
                if (NiecHelperSituation.SimHasBeenDestroyed(item))
                {
                    if (item == simAC) 
                        continue;
                    if (IsOpenDGSInstalled && item.mSimDescription == null)
                        item.mSimDescription = ListCollon.NullSimSimDescription;
                    ForceDestroyObject(item, false);
                }
            }
        }

        internal static
            void ReAllNHSOnTick_internal(Sim item)
        {
            NiecHelperSituation nhs = SafeGetSituationOfType<NiecHelperSituation>(item);
            if (nhs == null)
                return;
            nhs.Worker = item;
            NiecHelperSituation.Spawn nhsSp = nhs.Child as NiecHelperSituation.Spawn;
            if (nhsSp == null)
                return;
            nhsSp.ReCreateTick(item);
        }

        public static 
            void ReAllNHSOnTick(Sim[] simList) 
        {
            foreach (var item in simList ?? SC_GetObjects<Sim>())
            {
                if (item == null) 
                    continue;
                ReAllNHSOnTick_internal(item);
            }
        }

        public static 
            void SimDesc_GetAging(IMiniSimDescription me, out int age, out int maxAge)
        {
            var amst = AgingManager.Singleton;
            if (amst == null) { age = 0; maxAge = 0; return; }

            SimDescription simDescription = me as SimDescription;
            MiniSimDescription miniSimDescription = me as MiniSimDescription;
            float agingYears = 0f;

            if (simDescription != null)
            {
                agingYears = simDescription.AgingYearsSinceLastAgeTransition;
            }
            else if (miniSimDescription != null)
            {
                agingYears = miniSimDescription.AgingYearsSinceLastAgeTransition;
            }

            maxAge = (int)amst.AgingYearsToSimDays(AgingManager.GetMaximumAgingStageLength(me));
            age = (int)amst.AgingYearsToSimDays(agingYears);
        }

        public static
            void SimDesc_SetAging(IMiniSimDescription me, int newAge, bool bDEBUGAssert)
        {
            SimDescription simDescription = me as SimDescription;
            MiniSimDescription miniSimDescription = me as MiniSimDescription;

            if (simDescription != null && simDescription.AgingState == null)
            {
                simDescription.AgingState = new AgingState(simDescription);
            }

            float agingYears = 0f;

            if (simDescription != null)
            {
                agingYears = simDescription.AgingYearsSinceLastAgeTransition;
            }
            else if (miniSimDescription != null)
            {
                agingYears = miniSimDescription.AgingYearsSinceLastAgeTransition;
            }

            var amst = AgingManager.Singleton;

            if (bDEBUGAssert)
                Assert(amst != null, "AgingManager.Singleton == null");

            var rederInst = Sims3.UI.Responder.Instance;
            if (bDEBUGAssert)
                Assert(rederInst != null, "Sims3.UI.Responder.Instance == null");

            if (rederInst == null) 
            {
                return;
            }

            var hudModel = (rederInst.HudModel as HudModel);
            if (bDEBUGAssert)
                Assert(hudModel != null, "(Sims3.UI.Responder.Instance.HudModel as HudModel) == null");

            if (amst == null || hudModel == null)
            {
                return;
            }

            int currentAge = (int)amst.AgingYearsToSimDays(agingYears);
            if (newAge == currentAge)
            {
                return;
            }

            if (simDescription != null)
            {
                if (amst != null)
                {
                    amst.CancelAgingAlarmsForSim(simDescription.AgingState);
                    simDescription.AgingYearsSinceLastAgeTransition = amst.SimDaysToAgingYears(newAge);
                }

                if (rederInst != null && simDescription.Household == Household.ActiveHousehold && simDescription.CreatedSim != null)
                {
                    if (hudModel != null)
                    {
                        hudModel.OnSimAgeChanged(simDescription.CreatedSim.ObjectId);
                    }
                }
            }
            else if (miniSimDescription != null && amst != null)
            {
                miniSimDescription.AgingYearsSinceLastAgeTransition = amst.SimDaysToAgingYears(newAge);
            }
        }

        public static
            void ReAllNHSOnTickSleep(Sim[] simList)
        {
            int lsleep = 0;
            var t = simList ?? SC_GetObjects<Sim>();
            foreach (var item in t)
            {
                lsleep++;
                if (lsleep > 65)
                {
                    lsleep = 0;
                    SleepTask((uint)t.Length);
                }
                if (item == null)
                    continue;
                ReAllNHSOnTick_internal(item);
            }
        }

        public static
            void AllTrimSimsAndPets(bool isAweCore, bool isOpenDGS, bool needValidateSimCreated) 
        {
            if (needValidateSimCreated)
            {
                try
                {
                    //Sim[] simList = SC_GetObjects<Sim>();
                    UpdateNiecSimDescriptions(false, false, true);
                    foreach (var item in ListCollon.NiecSimDescriptions)
                    {
                        ValidateSimCreated(item, null);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }
            }
            Sim activeActor = ActiveActor;
            foreach (var item in SC_GetObjects<Sim>())
            {
                if (item == null) 
                    continue;
                if (item == activeActor) 
                    continue;

                SimDescription simd = item.mSimDescription;
                if (simd == null || simd.mSimDescriptionId == 0)
                {
                    if (isAweCore)
                    {
                        UnSafe_OrgToNull_SimDesc(item);
                    }
                    ForceDestroyObject(item, false);
                }
                else
                {
                    //if (simd.mSim != item)
                    //{
                    //    if (isAweCore)
                    //    {
                    //        UnSafe_OrgToNull_SimDesc(item);
                    //    }
                    //    ForceDestroyObject(item, false);
                    //    simd.mSim = null;
                    //    continue;
                    //}
                    Household simdHousehold = simd.Household;
                    if (simdHousehold != null)
                    {
                        Lot lotHome = simdHousehold.LotHome;
                        if (lotHome == null) {
                            if (HouseholdIsRole(simdHousehold)) 
                                continue;
                            if (isAweCore)
                            {
                                ForceCancelAllInteractionsWithoutCleanup(item);
                                ForceDeAttachAndDestroyAllSlots(item, false);
                                UnSafe_OrgToNull_SimDesc(item);
                            }
                            ForceDestroyObject(item, false);
                        }
                        else if (isOpenDGS) {
                            SafePosGoToHouse(item, false);
                        }
                        else {
                            if (isAweCore)
                            {
                                ForceCancelAllInteractionsWithoutCleanup(item);
                                ForceDeAttachAndDestroyAllSlots(item, false);
                            }
                            else
                            {
                                var iq = item.InteractionQueue;
                                try
                                {
                                    if (iq != null)
                                    {
                                        iq.CancelAllInteractions();
                                    }
                                    item.SetToResetAndSendHome();
                                    SpeedTrap.Sleep();
                                }
                                catch (StackOverflowException) { throw; }
                                catch (ResetException) { throw; }
                                catch (Exception)
                                {
                                    try
                                    {
                                        if (iq != null)
                                        {
                                            iq.Dispose();
                                            GC.SuppressFinalize(iq);
                                        }
                                        item.mInteractionQueue = new Sims3.Gameplay.ActorSystems.InteractionQueue(item);
                                        item.mPosture = item.Standing;
                                        item.SetToResetAndSendHome();
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    {
                                        if (isAweCore)
                                        {
                                            UnSafe_OrgToNull_SimDesc(item);
                                        }
                                        ForceDestroyObject(item, false);
                                        SafeSimHaveHomeInstantiate(simd);
                                        continue;
                                    }
                                }
                            }
                            SafePosGoToHouse(item, false);
                        }
                    }
                    else
                    {
                        if (isAweCore)
                        {
                            UnSafe_OrgToNull_SimDesc(item);
                        }
                        ForceDeAttachAndDestroyAllSlots(item, true);
                        ForceDestroyObject(item, false);
                    }
                }
            }
            //if (isOpenDGS) {
            //    foreach (var item in ListCollon.NiecSimDescriptions)
            //    {
            //        SafeSimHaveHomeInstantiate(item);
            //    }
            //}
        }

        public static
            void FixUpAllHouseholdNoLotHome()
        {
            FixUpHouseholdListObjects(true);
            var householdList = SC_GetObjects<Household>();

            foreach (var itemHousehold in householdList)
            {
                if (itemHousehold == null) continue;
                if (itemHousehold.IsSpecialHousehold)
                {
                    try
                    {
                        if (itemHousehold.LotHome != null && !Household_IsActiveHousehold(itemHousehold))
                            Household_ForceMoveOut(itemHousehold);
                    }
                    catch (Exception)
                    {}
                    continue;
                }

                var lotHome = itemHousehold.LotHome;
                if (lotHome != null)
                {
                    if (lotHome.Household == itemHousehold)
                    {
                        lotHome.mHousehold = itemHousehold;
                        itemHousehold.mLotId = lotHome.LotId;
                    }
                    else// if (!Household_IsActiveHousehold(itemHousehold))
                    {
                        try
                        {
                            Household_ForceMoveOut(itemHousehold);
                        }
                        catch (Exception)
                        {
                            lotHome.mHousehold = null;
                            itemHousehold.mLotHome = null;
                            itemHousehold.mLotId = 0;
                        }

                        if (_IsActiveHousehold(itemHousehold))
                        {
                            NiecException.PrintMessagePro("FixUpAllHouseholdNoLotHome()\n_IsActiveHousehold Found Fix Lot :)", false, 10);
                            Create.AutoMoveInLotFromHousehold(itemHousehold);
                        }
                        else if (IsActiveHouseholdWithActiveActorPro(itemHousehold, null))
                        {
                            NiecException.PrintMessagePro("FixUpAllHouseholdNoLotHome()\nIsActiveHouseholdWithActiveActorPro Found Fix Lot :)", false, 10);
                            Create.AutoMoveInLotFromHousehold(itemHousehold);
                        }
                    }
                }
            }
            var dataLots = LotManager.sLots;
            if (dataLots != null)
            {
                foreach (var itemLot in dataLots.Values)
                {
                    if (itemLot == null) continue;
                    var household = itemLot.mHousehold;
                    if (itemLot.IsWorldLot) {
                        if (household != null)
                        {
                            try
                            {
                                Household_ForceMoveOut(household);
                            }
                            catch (Exception)
                            {
                                itemLot.mHousehold = null;
                                household.mLotHome = null;
                                household.mLotId = 0;
                            }
                        }
                        continue;
                    }
                    
                    if (household != null)
                    {
                        if (household.LotHome != itemLot) {
                            household.mLotHome = itemLot;
                        }
                        if (household.LotId != itemLot.LotId) {
                            household.mLotId = itemLot.LotId;
                        }
                        //else
                        //{
                        //    var lotOld = LotManager.GetLot(itemLot.LotId);
                        //
                        //    household.mLotHome = itemLot;
                        //    household.mLotId = itemLot.LotId;
                        //
                        //    var allSimHuman = Household_GetAllActors(household); // custom
                        //    if (allSimHuman != null)
                        //    {
                        //        foreach (Sim sim in allSimHuman)
                        //        {
                        //            sim.OnHomeLotChanged(lotOld, itemLot);
                        //        }
                        //    }
                        //}
                    }
                    else {
                        foreach (var itemHousehold in householdList)
                        {
                            if (itemHousehold == null) continue;
                            if (itemHousehold.LotHome == itemLot)
                            {
                                Household_ForceMoveOut(itemHousehold);
                                Household_MoveIn(itemHousehold, itemLot, false);
                            }
                        }
                    }
                }
            }
        }

        public static T GetFirstSafeObject<T>(T[] ar) {
            if (ar == null || ar.Length == 0)
                return default(T);
            return ar[0];
        }

        public static void Lot_MoveOut(Lot This, Household household, bool force)
        {
            if (This == null)
                return;

            var vhousehold = This.mHousehold;
            if (vhousehold != null && (household == vhousehold || force))
            {
                try
                {
                    if (household == vhousehold && _IsActiveHousehold(vhousehold))
                    {
                        This.OnBecameUnselected();
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }

                try
                {
                    Mailbox mailbox = This.FindMailbox();
                    if (mailbox != null)
                    {
                        mailbox.MoveOut(vhousehold);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }

                try
                {
                    Party.CancelAllHouseParties(This);
                    This.TryTurnOffHolidayHouseLights();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }






                var vLothousehold = This.mHousehold;
                Household_SetLot(vLothousehold, null);

                try
                {
                    vLothousehold.UpdateSharedInventories(This, false);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }

                This.mHousehold = null;

                try
                {
                    Service.OnMoveOut(This);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }
            }
            try
            {
                Lot.UpdatePlayerNeighbors();
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception) { }
        }

        public static void Household_ForceMoveOut(Household household) {
            if (household == null)
                return;

            Lot oldHome = household.LotHome;
            var dataLots = LotManager.sLots;

            if (dataLots != null)
            {
                foreach (var itemLot in dataLots.Values)
                {
                    Lot_MoveOut(itemLot, household, false);
                }
            }

            Household_SetLot(household, null);

            var hhallSim = Household_GetAllActors(household); // custom
            if (hhallSim != null)
            {
                try
                {
                    foreach (Sim sim in hhallSim)
                    {
                        sim.OnHomeLotChanged(oldHome, null);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }
                
            }
        }

        

        public static Lot Household_SetLot(Household This, Lot lot)
        {
            if (This == null) return null;
            if (lot == null || lot.IsWorldLot)
            {
                This.mLotHome = null;
                This.mLotId = 0uL;
                return null;
            }
            Lot oldLot = (This.mLotId != lot.LotId) ? LotManager.GetLot(This.mLotId) : lot;
            This.mLotHome = lot;
            This.mLotId = lot.LotId;
            return oldLot;
        }

        public static void Household_MoveIn(Household household, Lot targetLot, bool bOnLoad)
        {
            if (targetLot == null || targetLot.IsWorldLot)
            {
                return;
            }
            if (targetLot.mHousehold != null)
            {
                Lot_MoveOut(targetLot, targetLot.Household, true);
            }
            var updateHousehold = (targetLot.mHousehold = household);
            if (updateHousehold != null)
            {
                foreach (Bill bill in SC_GetObjectsOnLot<Bill>(targetLot))  // custom
                {
                    if (bill != null && bill.OriginatingHousehold == null)
                    {
                        bill.OriginatingHousehold = updateHousehold;
                    }
                }
                List<Sim> hhallSim = null;
                try
                {
                    Lot oldLot = Household_SetLot(updateHousehold, targetLot);
                    hhallSim = Household_GetAllActors(updateHousehold); // custom

                    if (hhallSim != null)
                    {
                        foreach (Sim sim in hhallSim)
                        {
                            sim.OnHomeLotChanged(oldLot, targetLot);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }
                try
                {
                    //bool lotIsActiveHouehold = updateHousehold == Household.ActiveHousehold;

                    if (updateHousehold == Household.ActiveHousehold)
                    {
                        targetLot.OnBecameSelected();
                    }

                    updateHousehold.UpdateSharedInventories(targetLot, bOnLoad);

                    if (updateHousehold == Household.ActiveHousehold)
                    {
                        Lot.UpdatePlayerNeighbors();
                    }

                    if (!bOnLoad && GameUtils.IsInstalled(ProductVersion.EP5))
                    {
                        PetAdoption.OnHouseholdMoved(updateHousehold);
                    }

                    hhallSim = Household_GetAllActors(updateHousehold); // custom
                    if (hhallSim != null)
                    {
                        foreach (Sim sim in hhallSim)
                        {
                            if (sim.IsPet)
                                continue;
                            EventTracker.SendEvent(EventTypeId.kMovedIntoLot, sim);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }
            }
            Mailbox mailbox = targetLot.FindMailbox();
            if (mailbox != null)
            {
                mailbox.MoveIn(household, false);
            }
        }

        public static 
            void FixUpAllNiecHelperSituation(Sim[] simList, bool needFixSituations, bool unSafeAdd)
        {
            foreach (var item in simList ?? SC_GetObjects<Sim>())
            {
                if (item == null)
                    continue; 
                bool niecHelperSituationCreated = false;
                NiecHelperSituation nhs = needFixSituations ? NewSafeGetSituationOfType<NiecHelperSituation>(item) : SafeGetSituationOfType<NiecHelperSituation>(item);
                if (nhs == null)
                {
                resetGlobalSituationList:
                    if (needFixSituations && CanAddSituation(item))
                    {
                        var globalSituationList = Situation.sAllSituations;
                        if (globalSituationList != null) {
                            try
                            {
                                foreach (var itemSituation in globalSituationList)
                                {
                                    NiecHelperSituation nhsFound = itemSituation as NiecHelperSituation;
                                    if (nhsFound != null && nhsFound.Worker == item) {
                                        nhs = nhsFound;
                                        if (CanAddSituation(item, nhs))
                                            goto nextFixWorker;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex is ResetException) throw;
                                string ty = ex.Source;
                                if (ty != null && ty.Contains("mscorlib"))
                                {
                                    Situation.sAllSituations = new List<Situation>();
                                    goto resetGlobalSituationList;
                                }

                                if (unSafeAdd)
                                    goto gUnSafeAdd;
                            }
                            if (!unSafeAdd) 
                                continue;
                        gUnSafeAdd:
                            List<Situation> outSituationList;
                            //bool doneCanAddSituation = CanAddSituation(item, null, out outSituationList);
                            if (nhs == null && CanAddSituation(item, null, out outSituationList))
                            {
                                var nhsExistsOrCreate = NiecHelperSituation.ExistsOrCreate(item);
                                if (nhsExistsOrCreate != null && !outSituationList.Contains(nhsExistsOrCreate)) {
                                    outSituationList.Add(nhsExistsOrCreate);
                                }
                                niecHelperSituationCreated = true;
                                nhs = nhsExistsOrCreate;
                                if (nhs == null)
                                {
                                    continue;
                                }
                                goto nextFixWorker;
                            }
                            if (nhs == null)
                            {
                                continue;
                            }
                        }
                    }
                    continue;
                }
            nextFixWorker:
                if (!niecHelperSituationCreated && nhs != null && nhs.Worker != item) {
                    nhs.Worker = item;
                    NiecHelperSituation.Spawn nhsSp = nhs.Child as NiecHelperSituation.Spawn;
                    if (nhsSp == null)
                        continue;
                    nhsSp.ReCreateTick(item);
                }
            }
        }

        public static
            string GetSimDescToName(SimDescription simDesc) 
        {
            if (simDesc == null) 
                return " ";

            string rt = Sims3.SimIFace.StringTable.GetLocalizedString("Ui/Global:FullName");
            if (rt == "" || rt == "Ui/Global:FullName") 
                return simDesc.mFirstName + " " + simDesc.mLastName;

            try
            {
                rt = Localization.LocalizeString("Ui/Global:FullName", simDesc.mFirstName, simDesc.mLastName);
                if (rt == "" || rt == "Ui/Global:FullName")
                    return simDesc.mFirstName + " " + simDesc.mLastName;
                return rt;
            }
            catch (ResetException)
            { throw; }
            catch { return simDesc.mFirstName + " " + simDesc.mLastName; }
            
        }

        public static
            string GetRuntimeMethedToString(RuntimeMethodHandle handle) 
        {
            if (handle.Value == new IntPtr(0))
                return "None";
            var mthodInfo = MethodBase.GetMethodFromHandle(handle);
            if (mthodInfo == null) return "None";
            return mthodInfo.ToString();
        }

        public static
            string GetCallbackToString(Delegate func) 
        {
            if (func == null) return "None";
            var method = func.Method;
            if (method == null) return "None";
            return ("\n Method: " + method.ToString() + 
                    "\n DType: " + method.DeclaringType.ToString()); 
        }

        public static bool field_NeedNewSituations = false;

        public static 
            void LoopReAllNHSOnTick()
        {
            for (byte sleepc = 0; sleepc < 15; sleepc++)
            {
                Simulator.Sleep(0);
            } 
            while (true) {
                Simulator.Sleep(0);
                var simList = SC_GetObjects<Sim>();
                if (simList == null) continue;
                try
                {
                    FixUpSimIsBad(simList);
                    FixUpAllNiecHelperSituation(simList, field_NeedNewSituations, false);
                    ReAllNHSOnTick(simList);
                }
                catch (ResetException)
                { throw; }
                catch
                {
                    for (byte i = 0; i < 150; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
                
            }
        }

        public static 
            void ValidateSimCreated(SimDescription simDesc, Sim[] simList) 
        {
            if (simDesc == null) 
                return;
            var activeActor = ActiveActor;
            Sim simCreated = simDesc.CreatedSim;
            if (simCreated != null && simCreated != activeActor)
            {
                SimDescription simCreated_SimDesc = simCreated.mSimDescription;
                if (simCreated_SimDesc == simDesc)
                {
                    if (!GameObjectIsValid(simCreated.ObjectId.mValue))
                    {
                        simDesc.mSim = null;
                    }
                    else { return; }
                }
                else
                {
                    simDesc.mSim = null;
                    if (simCreated_SimDesc == null)
                    {
                        ForceDestroyObject(simCreated, false);
                    }
                    else
                    {
                        Sim simCreated_mSim = simCreated_SimDesc.mSim;
                        if (simCreated_mSim != null && simCreated_SimDesc == simCreated_mSim.mSimDescription)
                        {
                            if (!GameObjectIsValid(simCreated_mSim.ObjectId.mValue))
                            {
                                //if (simCreated_SimDesc != null)
                                //{
                                //    simCreated_SimDesc.CreatedSim = null;
                                //}
                                simCreated_SimDesc.mSim = null;
                            }
                            else 
                            {
                                simCreated_SimDesc.mSim = simCreated_mSim;
                                simCreated_mSim.mSimDescription = simCreated_SimDesc;
                            }
                        }
                        else
                        {
                            simCreated_SimDesc.mSim = null;
                            ForceDestroyObject(simCreated_mSim, false);
                        }
                    }
                }
            }
            bool foundSimDesc = false;
            foreach (var item in simList ?? SC_GetObjects<Sim>())
            {
                if (item == null || item == activeActor) continue;
                if (item.mSimDescription == simDesc) {
                    if (foundSimDesc) {
                        SetCreatedSim_SimDesc(item, GetRandomSimDescription((SimDescription _i) => _i.mSim == null));
                        ForceDestroyObject(item, false);
                        continue; 
                    } 
                    foundSimDesc = true;
                    simDesc.mSim = item;
                }
            }
        }

        public static
            bool SafeSimHaveHomeInstantiate(SimDescription simd) 
        {
            Sim unused;
            return SafeSimHaveHomeInstantiate(simd, out unused);
        }

        public static
            bool SafeSimHaveHomeInstantiate(SimDescription simd, out Sim simCreated) 
        {
            simCreated = null;
            if (simd == null || simd.LotHome == null) 
                return false;

            simCreated = simd.CreatedSim;
            if (simCreated != null) {
                SimDescription simCreated_SimDesc = simCreated.mSimDescription;
                if (simCreated_SimDesc == simd) 
                {
                    if (!GameObjectIsValid(simCreated.ObjectId.mValue))
                    {
                        simd.CreatedSim = null;
                        simCreated = null;
                    }
                    else return SafePosGoToHouse(simCreated, false);
                }
                
                else {
                    simd.mSim = null;
                    if (simCreated_SimDesc == null)
                    {
                        ForceDestroyObject(simCreated, false);
                    }
                    else {
                        Sim simCreated_mSim = simCreated_SimDesc.mSim;
                        if (simCreated_mSim != null && simCreated_SimDesc == simCreated_mSim.mSimDescription) 
                        {
                            if (!GameObjectIsValid(simCreated_mSim.ObjectId.mValue))
                            {
                                if (simCreated_SimDesc != null)
                                    simCreated_SimDesc.CreatedSim = null;
                            }
                            else
                            {
                                simCreated_SimDesc.mSim = simCreated_mSim;
                                simCreated_mSim.mSimDescription = simCreated_SimDesc;
                            }
                        }
                        else { 
                            simCreated_SimDesc.mSim = null;
                            ForceDestroyObject(simCreated_mSim, false); 
                        }
                    }
                    simCreated = null;
                }
            }
            try
            {
                Sim sim = simd.Instantiate
                    (Create.GetPositionInRandomLot(LotManager.GetWorldLot()), IsOpenDGSInstalled || ScriptCore.World.World_IsEditInGameFromWBModeImpl());

                if (sim == null) 
                    return false;

                simCreated = sim;
                return SafePosGoToHouse(sim, false);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            {
                simCreated = simd.CreatedSim;
                if (simCreated != null)
                {
                    if (simCreated.mSimDescription == simd)
                        return SafePosGoToHouse(simCreated, false);
                    else { 
                        ForceDestroyObject(simCreated, false);
                        simCreated = null;
                    }
                }
                
                return false;   
            }
        }

        public static void UnsafeAllThatBugSimCantUse(Sim objSim)
        {
            if (objSim == null)
                return;

            try
            {
                NFinalizeDeath.UnSafe_RemoveActorsUsingMe(objSim);
                NFinalizeDeath.UnSafeSimDeAttachAndPosture(objSim);
            }
            catch (ResetException)
            {
                throw;
            }
            catch { }
        }

        public static string GetObjectSTLite01(ulong ObjectID)
        {
            ScriptCore.TaskContext context;
            if (!ScriptCore.TaskControl.GetTaskContext(ObjectID, true, out context) || context.mFrames == null)
                return "<no call stack>";

            StringBuilder stringBuilder = new StringBuilder();

            for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
            {
                ScriptCore.TaskFrame taskFrame = context.mFrames[stack];


                if (taskFrame.mMethodHandle.Value == IntPtr.Zero)
                    continue;

                MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                Type declaringType = methodInfo.DeclaringType;
                stringBuilder.Append(declaringType.Name);
                stringBuilder.Append("::");
                stringBuilder.Append(methodInfo.Name);
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }

        public static T GetFirstObjectForTaskFrames<T>(ulong ObjectID)
        {
            if (ObjectID != 0)
            {
                ScriptCore.TaskContext context;
                if (!ScriptCore.TaskControl.GetTaskContext(ObjectID, true, out context) || context.mFrames == null)
                {
                    return default(T);
                }
                for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
                {
                    ScriptCore.TaskFrame taskFrame = context.mFrames[stack];
                    if (taskFrame.mMethodHandle.Value != IntPtr.Zero)
                    {
                        MethodInfo methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle) as MethodInfo;
                        if (methodInfo != null && !methodInfo.IsStatic)
                        {
                            if (taskFrame.mThisObj is T)
                            {
                                return (T) taskFrame.mThisObj;
                            }
                        }
                    }
                }
            }
            return default(T);
        }


        public static string GetObjectSTLite(ulong ObjectID, out int TaskSleep)
        {
            TaskSleep = 0;
            if (Simulator.CurrentTask.Value == ObjectID)
                return GetStackTraceToString(new StackTrace(1, false), false);
            ScriptCore.TaskContext context;
            if (!ScriptCore.TaskControl.GetTaskContext(ObjectID, true, out context) || context.mFrames == null)
                return "<no call stack>";

            StringBuilder stringBuilder = new StringBuilder();

            for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
            {
                ScriptCore.TaskFrame taskFrame = context.mFrames[stack];


                if (taskFrame.mMethodHandle.Value == IntPtr.Zero)
                    continue;

                MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                Type declaringType = methodInfo.DeclaringType;
                stringBuilder.Append(declaringType.Name);
                stringBuilder.Append("::");
                stringBuilder.Append(methodInfo.Name);
                stringBuilder.Append('\n');
            }
            TaskSleep = context.mSleepTicks;
            return stringBuilder.ToString();
        }

        public static bool IsKeepGrave(Urnstone grave) 
        {
            if (grave == null || grave.HasBeenDestroyed) 
                return false;

            SimDescription deadSimDesc = grave.DeadSimsDescription;
            if (deadSimDesc != null) 
            {
                Sim createdSim = deadSimDesc.CreatedSim;
                if (createdSim != null) 
                {
                    if (createdSim.SimDescription == deadSimDesc) 
                    {
                        if (!deadSimDesc.IsGhost && !deadSimDesc.IsDead) 
                            return false;
                    }
                    //if (NiecHelperSituation.SimHasBeenDestroyed(createdSim))
                    //    return true;
                }
            }

            Lot lotCurrent = grave.LotCurrent;
            if (lotCurrent != null)
            {
                if (lotCurrent.CommercialLotSubType == CommercialLotSubType.kGraveyard) 
                    return true;
                if (deadSimDesc == null && SC_GetObjectsOnLot<IMausoleum>(lotCurrent).Length > 0) 
                    return true;
            }

            foreach (var mausoleum in SC_GetObjects<IMausoleum>())
            {
                if (mausoleum == null)
                    continue;

                Inventory invetory = mausoleum.Inventory;
                if (invetory == null || invetory.mInventoryItems == null || invetory.mItems == null)
                    continue;

                if (invetory.Contains(grave))
                    return true;
            }

            return false;
        }

        public static Motive GetSMotive(Motives ths, CommodityKind motive)
        {
            return niec_std.dictionary_get_value_no_error_not_find(ths.mMotives, (int)motive);
        }

        public static bool IsGraveToInventoryMausoleum(Urnstone grave)
        {
            if (grave == null)
                throw new ArgumentNullException("grave");
            foreach (var mausoleum in SC_GetObjects<IMausoleum>())
            {
                if (mausoleum == null)
                    continue;

                Inventory invetory = mausoleum.Inventory;
                if (invetory == null || invetory.mInventoryItems == null || invetory.mItems == null)
                    continue;

                if (invetory.Contains(grave))
                    return true;
            }
            return false;
        }

        public static void GC_KeepObjV(object obj) { obj.GetHashCode(); }

        public static bool IsNullOrEmpty(string value)
        {
            return value == null || value.Length == 0;
        }

        private static bool _b_WaitAssert = false;
        public static void WaitAssert(string message) {
            if (_b_WaitAssert) // lock()?
                return;
            try
            {
                _b_WaitAssert = true;
                Assert(message);
            }
            finally
            {
                _b_WaitAssert = false;
            }
        }

       //public static IntPtr GetFunctionPtr() { 
       //    new NFinalizeDeath.FunctionX(NFinalizeDeath.DTESTMOK).method_ptr;
       //}

        public unsafe static void Assert(string message) { Assert(false, message); }
        private unsafe static void assertbool_internal(bool condition, string message)
        {
            //if (Assembly.GetExecutingAssembly() != Assembly.GetCallingAssembly()) return;
            if (Simulator.CheckYieldingContext(false))
            {
                var ctask = ScriptCore.Simulator.Simulator_GetCurrentTaskImpl();
                NiecTask.CreateWaitPerformWithExecuteType(GetCurrentExecuteType(), () =>
                {
                    ModalDialog.EnableModalDialogs = true;
                    NiecException.WriteLog("Assertion Failed!\nMessage: " + message);
                    var r = ThreeButtonDialog.Show("[- NiecMod -]\nAssertion Failed!\nMessage: " + message, "About", "Retry", "Ignore");
                    
                    switch (r)
                    {
                        case ThreeButtonDialog.ButtonPressed.FirstButton:

                            if (ScriptCore.CameraController.Camera_GetTarget() != new Vector3(0, 0, 0))
                            {
                                VideoRecorder.SnapshotFileName = "NiecMod_Assert";
                                VideoRecorder.TakeSnapshot();
                            }

                            string st = Get_Stack_Trace();//GetStackTraceToString(new StackTrace(1, false), true);
                            bool or =  ScriptCore.CameraController.Camera_GetTarget() == new Vector3(0,0,0) || (!CheckAccept("Save Game?") || ForceSaveGameNoDialog());

                            NiecException.WriteLog("Assertion Failed!\nMessage: " + message + "\nStack Trace:\n" + st);

                            if (or)
                            {
#if NIECMOD_NATIVE_DEBUG_ASSERT
                                string ty;
                                if (niec_native_func.cache_done_niecmod_native_debug_text_to_debugger)
                                {
                                    try
                                    {
                                        throw new ExecutionEngineException("Debug Stack Trace.");
                                    }
                                    catch (Exception ex)
                                    {
                                        ty = ex.ToString() + "\n";
                                    }
                                    niec_native_func.OutputDebugString("\nNM: Assertion Failed!\nMessage: " + (message ?? "no message") + "\n\nStack Trace:\n" + ty);
                                }
#endif
                                if ((int)niec_native_func.LoadDLLNativeLibrary("exitgame.dll") != 0) { }
                                else {
                                NiecTask.Perform(delegate
                                {
                                    for (int i = 0; i < 50; i++)
                                    {
                                        SpeedTrap.Sleep(0);
                                    }

                                    while (true)
                                    {
                                        Simulator.Sleep(0);
                                        try
                                        {
                                            MsCorlibModifed_Exlists();

                                            World_NativeInstance = 0xFFFFAAAA;

                                            RuntimeMethodHandle.GetFunctionPointer(MethodBase.GetCurrentMethod().MethodHandle.Value);
                                        }
                                        catch (Exception)
                                        { }
                                    }
                                });
                                NiecTask.Perform(delegate
                                {
                                    for (int g = 0; g < 75; g++)
                                    {
                                        SpeedTrap.Sleep(0);
                                    }

                                    MsCorlibModifed_Exlists();

                                    SpeedTrap.Sleep(0);
                                    SpeedTrap.Sleep(0);
                                    SpeedTrap.Sleep(0);

                                    foreach (var item in SC_GetObjects<GameObject>())
                                    {
                                        if (item == null) continue;
                                        ScriptCore.TaskContext context;
                                        if (!ScriptCore.TaskControl.GetTaskContext(item.ObjectId.mValue, true, out context))
                                        {
                                            continue;
                                        }
                                        context.mFrames = null;
                                        context.mSleepTicks = -1;
                                        ScriptCore.TaskControl.SetTaskContext(item.ObjectId.mValue, ref context);
                                    }

                                    int i = KillPro.YGeneration;
                                    TrimHouse((uint)i.GetHashCode());
                                });
                                NiecTask.Perform(delegate
                                {
                                    for (int g = 0; g < 100; g++)
                                    {
                                        SpeedTrap.Sleep(0);
                                    }

                                    MsCorlibModifed_Exlists();

                                    SpeedTrap.Sleep(0);
                                    SpeedTrap.Sleep(0);
                                    SpeedTrap.Sleep(0);

                                    niec_std.force_exit<_NI>();
                                });
                                }
                            }
                            Simulator.Sleep(uint.MaxValue);
                            break;
                        case ThreeButtonDialog.ButtonPressed.SecondButton:
                            //ObjectGuid guidtask = Simulator.CurrentTask;
                            NiecTask.Perform(delegate
                            {
                                Simulator.Sleep(0);
                                int sl;
                                string yt = GetObjectSTLite(ctask, out sl);
                                NiecException.PrintMessagePro("NiecMod\nCall Stack\nSleep: " + sl + "\n" + yt, true, float.MaxValue);
                            });

                            //for (int g = 0; g < 50; g++)
                            //{
                            //    SpeedTrap.Sleep(0);
                            //}
                            //
                            //if (CheckAccpetWithoutYield("Do you want call Debugger_Break()?"))
                            //{
                            //    Debugger_Break();
                            //    return;
                            //}

                            Simulator.Sleep(uint.MaxValue);
                            break;
                        case ThreeButtonDialog.ButtonPressed.ThirdButton:
                            return;
                        default:
                            throw new NotSupportedException(r.ToString());
                    }
                }).Waiting();
            }
            else
            {
                if (niec_native_func.cache_done_niecmod_native_message_box)
                {
                    switch (niec_native_func.MessageBox(0, "Assertion failed!\n\nMessage:\n\n" + message + "\n\n(Press Retry to debug the game)\nPlease run the x32dbg app. You can debug to Sims 3", "NiecMod", (niec_native_func.MB_Type)0x00012012u))
                    {
                        case niec_native_func.ResultMB.IDABORT:  
                        {
                            if ((int)niec_native_func.LoadDLLNativeLibrary("exitgame.dll") != 0) { World_NativeInstance = 0xFFFFFFFE; }
                            else {
                                World_NativeInstance = 0xFFFFFFFE;
                                RuntimeMethodHandle.GetFunctionPointer(MethodBase.GetCurrentMethod().MethodHandle.Value); 
                            }
                            break;
                        } 
                        case niec_native_func.ResultMB.IDRETRY:
                        {
#if NIECMOD_NATIVE_DEBUG_ASSERT
                            niec_native_func.OutputDebugString("Please x32dbg attech to Sims 3"); // Debugging to Sims 3
#endif
                            niec_native_func.MessageBox(0, "Please x32dbg attech to Sims 3", "NiecMod", 0);

                            if (CheckAccpetWithoutYield("Do you want call Debugger_Break()?"))
                                Debugger_Break();
                            return;
                        }
                        case niec_native_func.ResultMB.IDIGNORE: 
                        {
                            break;
                        }
                        default:
                        { 
                            goto failed; 
                        }
                    }
                    return;
                }
                failed:
                if (NotificationManager.sNotificationManager != null)
                    NiecException.PrintMessagePro("Assertion Failed!\nMessage: " + message + "\nStack Trace: " + GetStackTraceToString(new StackTrace(1, false), true), false, float.MaxValue);
                else new NCopyableTextDialog("Assertion Failed!\nMessage: " + message + "\nStack Trace: " + GetStackTraceToString(new StackTrace(1, false), true)).SafeShow("Niec Assert");
                ThrowResetException(null);
            }
        }
        public unsafe static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                string ty = "";

#if NIECMOD_NATIVE_DEBUG_ASSERT
                if (niec_native_func.cache_done_niecmod_native_debug_text_to_debugger)
                {
                    try
                    {
                        throw new ExecutionEngineException("Debug Stack Trace.");
                    }
                    catch (Exception ex)
                    {
                        ty = ex.ToString() + "\n";
                    }
                    niec_native_func.OutputDebugString("\nNM: Assertion Failed!\nMessage: " + (message ?? "no message") + "\n\nStack Trace:\n" + ty);
                }
#endif

                if (message == null)
                {
                    if (ty == null)
                    {
                        try
                        {
                            throw new Exception();
                        }
                        catch (Exception ex)
                        {
                            message = ex.ToString();
                        }
                    }
                    else
                    {
                        message = ty;
                    }
                }

                assertbool_internal(condition, message);
            }
        }

        public static void CheckYieldingContext() // unprotected mono mscorlib 
        {
            if (!Simulator.CheckYieldingContext(false))
            {
                ThrowResetException(null);
            }
        }
        public static void ActorCheckYieldingContext(GameObject Actor) // unprotected mono mscorlib 
        {
            if (Actor != null)
            {
                var ct = Simulator.CurrentTask;
                if (ct.mValue != 0 && ct == Actor.ObjectId && !Simulator.CheckYieldingContext(false))
                {
                    ThrowResetException(null);
                }
            }
        }
        public static bool SD_OutfitsIsValid2(SimDescription _This, bool pa)
        {
            try
            {
                var p = _This.mOutfits;
                if (p != null && p.Count > 0)
                {
                    foreach (OutfitCategories key in p.Keys)
                    {
                        var arrayList = p[key] as System.Collections.ArrayList;
                        if (arrayList != null && arrayList.Count > 0)
                        {
                            foreach (object item in arrayList)
                            {
                                if (!(item is SimOutfit))
                                    return false;
                            }
                        }
                    }
                    return true;
                }
                return p != null && pa;
            }
            catch (StackOverflowException)
            { throw; }
            catch (ResetException)
            { throw; }
            catch { }

            return false;
        }
        public static bool FixUpPlumbBobSingletonNull()
        {
            if (PlumbBob.sSingleton == null)
            {
                try
                {
                    GlobalFunctions.CreateObjectOutOfWorld("PlumbBob");
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }

                if (Simulator.CheckYieldingContext(false))
                    Simulator.Sleep(0);
            }

            if (PlumbBob.sSingleton == null)
            {
                return false;
            }

            return true;
        }


        public static bool SimIsAvailable(Sim actor)
        {
            if (actor == null  || actor.mInteractionQueue == null || actor.SimDescription == null || actor.mAutonomy == null || actor.mAutonomy.mSituationComponent == null)
                return false;

            if (actor.Autonomy.SituationComponent.InSituationOfType(typeof(GoHereWithSituation)))
                return false;

            if (ActorIsQueueNHS(actor))
                return false;

            if (FastHasInteraction<Sim.GoToVirtualHome>(actor.mInteractionQueue.mInteractionList, 10) || FastHasInteraction<Sim.GoToVirtualHome.GoToVirtualHomeInternal>(actor.mInteractionQueue.mInteractionList, 10))
                return false;

            if (VisitSituation.FindVisitSituationInvolvingHost(actor) != null)
                return false;

            var time = SimClock.Add(SimClock.CurrentTime(), TimeUnit.Hours, 1f);
            if (actor.Occupation != null && (actor.Occupation.ShouldBeAtWork() || actor.Occupation.IsWorkHour(time)))
                return false;

            if (actor.CareerManager != null && actor.CareerManager.School != null && (actor.CareerManager.School.ShouldBeAtWork() || actor.CareerManager.School.IsWorkHour(time)))
                return false;

            if (NpcParty.IsHostAtNpcParty(actor))
                return false;

            return actor.IsSimulating;
        }

        public static 
            void TestSetActiveActor(Sim Target, bool checkPlumbBobNull)
        {
            if (!GameStates.IsInWorld())
                return;

            if (checkPlumbBobNull && Target != null && Target.Proxy != null)
            {
                FixUpPlumbBobSingletonNull();
            }

            Assert(checkPlumbBobNull || PlumbBob.sSingleton != null, "PlumbBob.sSingleton != null");
            if (PlumbBob.sSingleton == null)
                return;

            PlumbBob.sCurrentNonNullHousehold = null;
            PlumbBob.sSingleton.mSelectedActor = null;

            for (int i = 0; i < 5; i++)
            {
                PlumbBob.ForceSelectActor(null);
                ActiveActor = null;
            }

            PlumbBob.sCurrentNonNullHousehold = null;
            PlumbBob.sSingleton.mSelectedActor = null;

            ActiveActor = Target;

            if (Target != null) {
                if (Target.Household != null) 
                {
                    Assert
                        (PlumbBob.sCurrentNonNullHousehold != null,
                        "PlumbBob.sCurrentNonNullHousehold != null");
                }

                Assert(PlumbBob.sSingleton.mSelectedActor != null, 
                      "PlumbBob.sSingleton.mSelectedActor != null");
            } 
            else {
                Assert(PlumbBob.sCurrentNonNullHousehold == null, 
                      "PlumbBob.sCurrentNonNullHousehold == null");

                Assert(PlumbBob.sSingleton.mSelectedActor == null,
                      "PlumbBob.sSingleton.mSelectedActor == null");
            }
        }

        public static
            void CheckFailSelectActor() 
        {
            var activeActor = PlumbBob.SelectedActor;
            if (activeActor == null || activeActor.Household == null) 
                return;

            bool selectActorResult = false;
            foreach (var item in Household_GetAllActors(activeActor.Household))
            {
                if (item == activeActor) 
                    continue;

                selectActorResult = PlumbBob.SelectActor(item ?? activeActor);

                Assert(
                    selectActorResult,
                    "PlumbBob.SelectActor(item) failed: " + item.GetLocalizedName()
                );

                if (selectActorResult) 
                    break;
            }

            selectActorResult = PlumbBob.SelectActor(activeActor);

            Assert(
                selectActorResult,
                "PlumbBob.SelectActor(activeActor) failed: " + activeActor.GetLocalizedName()
            );

            if (!selectActorResult) {
                // Keep DreamsAndPromisesManager
                PlumbBob.sCurrentNonNullHousehold = null;
                if (!PlumbBob.ForceSelectActor(activeActor))
                {
                    PlumbBob.ForceSelectActor(null);

                    var simDesc = activeActor.SimDescription;
                    if (simDesc == null)
                    {
                        PlumbBob.ForceSelectActor(GetRandomSim((Sim test) => test.LotHome != null));
                        return;
                    }

                    // Why TraitChipManager.OnSimDisposed()?
                    NFinalizeDeath.ForceDestroyObject(activeActor, true);

                    try
                    {
                        simDesc.Fixup();
                    }
                    catch (Exception)
                    { }

                    Assert(
                        PlumbBob.ForceSelectActor(SimDesc_SafeInstantiate(activeActor.SimDescription, Vector3_OutOfWorld)),
                       "PlumbBob.ForceSelectActor(SimDesc_SafeInstantiate(activeActor.SimDescription, Vector3_OutOfWorld))"
                    );
                    
                }
            }
        }


        public static
            void Runfakeh_Commamnd(Sim Target)
        {
            Sim sim = Target;
            if (sim == null)
                return;

            var simDescSim = sim.SimDescription;
            if (simDescSim == null)
                return;

            Sim activeActor = PlumbBob.SelectedActor;
            if (activeActor == null)
                return;

            var simDescActiveActor = activeActor.SimDescription;
            if (simDescActiveActor == null)
                return;

            FakeHousehold(simDescSim, simDescActiveActor);

            // Keep DreamsAndPromisesManager
            PlumbBob.sCurrentNonNullHousehold = NFinalizeDeath.ActiveHousehold;

            for (int i = 0; i < 2; i++)
            {
                PlumbBob.SelectActor(activeActor);
            }
            
        }

        public static 
            void RunSwapHousehold(Sim Target) 
        {
            // Break CheckForChangeInActiveHousehold()
            // Awesome Mod Fail Script Error
            /*
Exception StackTrace:
System.NullReferenceException: A null value was found where an object instance was required.
#0: 0x00033 callvirt   in Awesome.StoryBus.Awesome.StoryBus.Core:IsSacred (Sims3.Gameplay.CAS.Household) ([3A257E00] )
#1: 0x0002a call       in Awesome.StoryBus.Awesome.StoryBus.Core:IsSacred (Sims3.Gameplay.Core.Lot) ([4BDFD920] )
#2: 0x0005e call       in Awesome.MapTags.Awesome.MapTags.Manager:AddAwesomeMapTag (Sims3.Gameplay.MapTags.MapTagManager,Sims3.Gameplay.Abstracts.GameObject) ([6F2562A0] [4BDFD920] )
#3: 0x00021 call       in Awesome.MapTags.Awesome.MapTags.Manager:_AddAwesomeMapTags (Sims3.Gameplay.MapTags.MapTagManager) ([6F2562A0] )
#4: 0x00004 call       in Awesome.MapTags.Awesome.MapTags.Manager:AddAwesomeMapTags (Sims3.Gameplay.MapTags.MapTagManager) ([6F2562A0] )
#5: 0x00672 call       in Sims3.Gameplay.MapTags.Sims3.Gameplay.MapTags.MapTagManager:Reset () ()
#6: 0x00026 call       in Sims3.Gameplay.MapTags.Sims3.Gameplay.MapTags.MapTagManager:.ctor (Sims3.Gameplay.Actors.Sim) (6F2562A0 [9E66E800] )
#7: 0x00007 newobj     in Sims3.Gameplay.Actors.Sims3.Gameplay.Actors.Sim:SetupSelectableSimManagers () ()
#8: 0x00010 call       in Sims3.Gameplay.Actors.Sims3.Gameplay.Actors.Sim:OnBecameSelectable () ()
#9: 0x000a8 callvirt   in Sims3.Gameplay.Core.Sims3.Gameplay.Core.PlumbBob:CheckForChangeInActiveHousehold (Sims3.Gameplay.CAS.Household,bool) ([4A836C40] [1] )
#10: 0x0017a call       in Sims3.Gameplay.Core.Sims3.Gameplay.Core.PlumbBob:DoSelectActor (Sims3.Gameplay.Actors.Sim,bool) ([4BA56000] [1] )
             */

            if (Target == null || !ActorIsValidExNull(Target)) 
                return;

            Sim activeActor = PlumbBob.SelectedActor;
            if (activeActor == null) 
                return;

            var simDescTarget = Target.SimDescription;
            if (simDescTarget == null || simDescTarget.Household == null)
                return;

            var simDescActiveActor = activeActor.SimDescription;
            if (simDescActiveActor == null)
                return;

            FakeHousehold(simDescTarget, simDescActiveActor);

            // Keep DreamsAndPromisesManager
            PlumbBob.sCurrentNonNullHousehold = ActiveHousehold;

            for (int i = 0; i < 2; i++)
            {
                PlumbBob.SelectActor(activeActor);
            }

            //SleepTask(1);

            foreach (var itemTarget in Household_GetAllActors(Household.ActiveHousehold) ?? Household_GetAllActors(activeActor.Household)) 
            {
                if (itemTarget != null && itemTarget != PlumbBob.SelectedActor && itemTarget != activeActor && ActorIsValidExNull(itemTarget) && PlumbBob.SelectActor(itemTarget) && PlumbBob.SelectActor(itemTarget))
                {
                    FakeHousehold(simDescTarget, simDescActiveActor);

                    // Keep DreamsAndPromisesManager
                    PlumbBob.sCurrentNonNullHousehold = ActiveHousehold;

                    for (int i = 0; i < 2; i++)
                    {
                        PlumbBob.SelectActor(itemTarget);
                    }

                    //SleepTask(1);

                    Assert
                        (itemTarget == PlumbBob.SelectedActor,
                        "itemTarget == PlumbBob.SelectedActor");

                    if (PlumbBob.SelectedActor == null)
                    {
                        Assert
                          (//PlumbBob.SelectedActor != null,
                          "PlumbBob.SelectedActor != null");

                        PlumbBob.ForceSelectActor(Target);
                        return;
                    }
                    else
                    {
                        // Keep DreamsAndPromisesManager
                        PlumbBob.sCurrentNonNullHousehold = ActiveHousehold;

                        Assert
                            (Target.IsInActiveHousehold,
                            "Target.IsInActiveHousehold");

                       // try
                       // {
                       //     Target.OnBecameSelectable();
                       // }
                       // catch (ResetException)
                       // { throw; }
                       // catch { }

                        Assert
                         (PlumbBob.SelectActor(Target),
                         "PlumbBob.SelectActor(Target)");

                        //PlumbBob.SelectActor(Target);

                       //for (int i = 0; i < 2; i++)
                       //{
                       //    PlumbBob.SelectActor(Target);
                       //}

                        Household_RefrashAllActors(Household.ActiveHousehold);

                        //SleepTask(1);

                        if (!Vector3_IsUnsafe(PlumbBob.SelectedActor.Position))
                            Sims3.Gameplay.Core.Camera.FocusOnSim(PlumbBob.SelectedActor);

                        PlumbBob.SelectActor(Target);
                    }

                    Assert
                        (Target == PlumbBob.SelectedActor || itemTarget == PlumbBob.SelectedActor,
                        "Target == PlumbBob.SelectedActor || itemTarget == PlumbBob.SelectedActor");

                    break;
                }
            }
        }

        public static
           void RemoveAllSimBuffInstance()
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                
                if (item == null) continue;
                BuffManager buffm = item.mBuffManager;
                if (buffm == null || buffm.mValues == null)
                    continue;
                //if (buffm.List == null)
                //    continue;

                buffm.RemoveAllElements();
            }
        }
        public static
           void RemoveAllIQRunningIList()  // unprotected mono mscorlib 
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null) continue;
                var InteractionQueue = item.InteractionQueue;
                if (InteractionQueue == null)
                    continue;

                var ru = InteractionQueue.mRunningInteractions;
                if (ru == null)
                    continue;

                ru.Clear();

                var quList = InteractionQueue.mInteractionList;
                if (quList == null || quList._items == null || quList._items.Length == 0 || quList.Count == 0)
                    continue;

                var ci = InteractionQueue.GetCurrentInteraction();
                if (ci != null)
                    ru.Push(ci);
            }
        }
        public static void ThrowOtherException(Exception ex = null)  // unprotected mono mscorlib 
        {
            try
            {
                throw ex ?? (ex = new NullReferenceException());
            }
            catch
            {
                //ex.message = Message ?? "";
                ex.class_name = null;
                ex.stack_trace = null;
                ex.trace_ips = null;
                ex.inner_exception = null;
                ex.source = null;
                throw;
            }

        }

        public static object tDataR_ExV = null;

        public static void ThrowResetException(string Message)
        {
            //var resetEx = new NResetEx() { message = Message ?? "" };
            var resetEx = tDataR_ExV as NResetEx ?? new NResetEx();
            resetEx.message = Message ?? "";
            try
            {
                throw resetEx;
            }
            catch // unprotected mono mscorlib 
            {
                resetEx.class_name = null;
                resetEx.stack_trace = null;
                resetEx.trace_ips = null;
                resetEx.inner_exception = null;
                resetEx.source = null;
                throw;
            }
        }

        public static bool IsHouseholdListBad() {
            try
            {
                foreach (var item in SC_GetObjects<Household>())
                {
                    if (item == null)
                        return true;

                    var members = item.mMembers;
                    if (members == null)
                        return true;

                    var allsimdesc = members.mAllSimDescriptions;
                    if (allsimdesc == null || allsimdesc._items == null)
                        return true;

                    //TestFixList(allsimdesc);

                    foreach (var itemMember in allsimdesc)
                    {
                        if (itemMember == null)
                            return true;
                    }
                }
            }
            catch (StackOverflowException)
            { throw; }
            catch { return true; }
            
            return false;
        }

        public static bool IsSpecialHousehold(Household hd) // fast code
        {
            if (hd == null) 
                return false;

            return hd == Household.sNpcHousehold              || 
                   hd == Household.sPreviousTravelerHousehold || 
                   hd == Household.sTouristHousehold          || 
                   hd == Household.sPetHousehold              || 
                   hd == Household.sAlienHousehold            || 
                   hd == Household.sMermaidHousehold;
        }

        public static ScriptExecuteType GetCurrentExecuteType()
        {
            /*
            Task task = Simulator.GetTask(Simulator.CurrentTask) as Task;
            if (task == null || task.ExecuteType == ScriptExecuteType.None)
            {
                var proxy = Simulator.GetTask(Simulator.CurrentTask) as ScriptCore.ScriptProxy; //GetProxyFromObjectIDWithoutSimIFace(Simulator.CurrentTask);
                if (proxy == null) 
                    return ScriptExecuteType.None;

                return proxy.mExecuteType;
            }
            return task.ExecuteType;
             * */

            var iTask = ScriptCore.Simulator.Simulator_GetTaskImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl(), false); // Simulator.GetTask(Simulator.CurrentTask);
            if (iTask == null) {
                return ScriptExecuteType.None;
            }

            var proxy = iTask as ScriptCore.ScriptProxy;
            if (proxy != null) {
                return proxy.mExecuteType;
            }

            var task = iTask as Task;
            if (task != null) {
                return task.ExecuteType;
            }

            // DEBUG check
            //NiecException.PrintMessagePro("GetCurrentExecuteType()\nType:\n" + task.GetType().ToString(), true, 200);

            return ScriptExecuteType.None;
        }

        public static bool SimDesc_OutfitsIsValid(SimDescription _This) {
            if (_This == null) 
                throw new NullReferenceException();
            if (_This.mOutfits == null) 
                return false;
            if (_This.Pregnancy != null && _This.mMaternityOutfits == null) 
                return false;
            if (_This.GetCurrentOutfits() == null) 
                return false;
            try
            {
                SimOutfit o = _This.GetOutfit(OutfitCategories.Everyday, 0);
                return o != null && o.IsValid;
            }
            catch (StackOverflowException)
            {throw;}
            catch (ResetException)
            {throw;}
            catch { return false; }
            
        }

        public static void Household_RefrashAllActors(Household _This)
        {
            if (_This == null) return;
            try
            {
                RemoveNullForHouseholdMembers(_This);
                foreach (var item in Household_GetAllActors(_This))
                {
                    _This.OnMemberChanged(item.SimDescription, item);
                }
            }
            catch (ResetException)
            {
                throw;
            }
            catch { }
            
            
        }

        public static bool Sim_IsBad(Sim Target)
        {
            return 
                (Target == null                       || 
                Target.mObjComponents == null         ||
                Target.SocialComponent == null        ||
                Target.BuffManager == null            ||
                Target.LookAtManager == null          ||
                Target.Autonomy == null               ||
                Target.SimRoutingComponent == null    ||
                Target.ThoughtBalloonManager == null); //&& Simulator.GetProxy(Target.ObjectId) != null;
        }

        public static string GetNowTimeToStr()
        {
            return DateTime.Now.ToString().Replace('/', '-').Replace(':', '_');
        }

        public static Household Household_CloneHousehold(Household d, bool deleteNewPackageFile)
        {
            if (d == null) return null;
            RemoveNullForHouseholdMembers(d);
            if (d.mMembers.mAllSimDescriptions.Count == 0)
            {
                var h = Household.Create(false);
                h.mFamilyFunds = d.mFamilyFunds;
                h.Name = d.mName;
                h.mUnpaidBills = d.mUnpaidBills;
                h.mDelinquentFunds = d.mDelinquentFunds;
                h.mBioText = d.mBioText;
                return h;
            }

            string packageFile = null;
            packageFile = Commom.Proxies.HouseholdContentsProxy.NExportHousehold(Bin.Singleton, d, false, false, !IsOpenDGSInstalled, deleteNewPackageFile);


            if (packageFile == null)
                return null;

            if (!deleteNewPackageFile)
                NiecException.PrintMessagePro(packageFile, false, float.MaxValue);

            if (Simulator.CheckYieldingContext(false))
                Simulator.Sleep(0);

            var ts = Commom.Proxies.HouseholdContentsProxy.Import(packageFile);
            
            if (ts == null)
                return null;
            
            var r = ts.Household;
            if (r == null) { 
                if (deleteNewPackageFile) { 
                    ExportBin.DeleteExportBinPackage(packageFile); 
                } 
                return null; 
            }
            try
            {
                try
                {
                    foreach (var item in r.AllSimDescriptions)
                    {
                        if (item == null)
                            continue;
                        AddNiecSimDescriptions(item);
                        SimDesc_SetID(item, GetRandomID());
                    }
                }
                finally
                {
                    ts.Contents.mHousehold = null;
                    if (deleteNewPackageFile) { ExportBin.DeleteExportBinPackage(packageFile); }
                }
            }
            catch (ExecutionEngineException) 
            { }
           
            return r;
           
            
        }
        // unprotected mono mscorlib 
        public static string GetLastPackageName(bool needLotPackageFile)
        {
            if (BinModel.sBinModel == null || BinModel.sBinModel.mExportBin == null)
                return null;

            if (BinModel.sBinModel.mExportBin._items == null)
                BinModel.sBinModel.mExportBin = new List<ExportBinContents>();

            if (BinModel.sBinModel.mExportBin.Count == 0)
                return null;

            var exportBinlist = new List<ExportBinContents>(BinModel.sBinModel.mExportBin ?? new List<ExportBinContents>());
            Comparison<ExportBinContents> sortTime = delegate(ExportBinContents a, ExportBinContents b)
            {
                if (a == b)
                {
                    return 0;
                }
                if (a == null)
                {
                    return -1;
                }
                if (b == null)
                {
                    return 1;
                }
                return b.ExportDateTime.CompareTo(a.ExportDateTime);
            };

            try
            {
                if (sortTime != null)
                    exportBinlist.Sort(sortTime);
            }
            catch (Exception)
            { }

            if (needLotPackageFile)
            {
                foreach (var item in exportBinlist._items)
                {
                    if (item == null)
                        continue;

                    if (item.Type == Sims3.UI.GameEntry.ExportBinType.Lot)
                    {
                        return item.mPackageName;
                    }
                }
            }
            else
            {
                foreach (var item in exportBinlist._items)
                {
                    if (item == null)
                        continue;

                    if (item.Type == Sims3.UI.GameEntry.ExportBinType.HouseholdLot || item.Type == Sims3.UI.GameEntry.ExportBinType.Household)
                    {
                        return item.mPackageName;
                    }
                }
            }
            //Print("GetLastPackageName: Could not find Package!");
            return null;
        }
        public static List<SimDescription> CopyFullSimDesc()
        {
            if (Bin.sSingleton == null)
            {
                throw new NullReferenceException("Bin.sSingleton == null");
            }
            Simulator.CheckYieldingContext(true);
            var si = UpdateNiecSimDescriptions(false, false, false);
            if (si == null || si.Count == 0)
                return null;

            Household household = Household.Create();
            if (household == null) {
                niec_std.assert("Household.Create() == null");
                return null;
            }
            household.SetName("CFSD WorldName " + World.GetWorldFileName());
            household.mBioText = "Date " + GetNowTimeToStr();
            var hMembers = household.mMembers;
            if (hMembers == null) {
                niec_std.assert("hMembers == null");
                HouseholdCleanse(household, false, true);
                return null;
            }

            var simList = si.ToArray();
            bool shouldSleep = Simulator.CheckYieldingContext(false) && simList.Length > 190;
            int i = 0;

            foreach (var item in simList)
            {
                if (item == null) 
                    continue;

                if (item.mHairColors == null || item.mSimDescriptionId == 0 || item.mOutfits == null) 
                    continue;

                if (!SimDesc_OutfitsIsValid(item))
                    continue;

                if (item.IsValidDescription)
                {
                    hMembers.mAllSimDescriptions.Add(item);

                    if (item.IsPet)
                        hMembers.mPetSimDescriptions.Add(item);
                    else
                        hMembers.mSimDescriptions.Add(item);
                }
                if (shouldSleep) {
                    i++;
                    if (i > 30) {
                        i = 0;
                        Simulator.Sleep(0);
                    }
                }
            }
            if (hMembers.mAllSimDescriptions.Count == 0)
            {
                HouseholdCleanse(household, false, true);
                return null;
            }
            string packageFile = null;
            try
            {
                try
                {
                    packageFile = Commom.Proxies.HouseholdContentsProxy.NExportHousehold(Bin.Singleton, household, false, false, true, true);
                }
                finally
                {
                    hMembers.mAllSimDescriptions.Clear();

                    hMembers.mPetSimDescriptions.Clear();

                    hMembers.mSimDescriptions.Clear();

                    HouseholdCleanse(household, false, true);
                }
            }
            // error by Sleep()
            catch (ExecutionEngineException)
            { }

            // script error 
            if (packageFile == null) 
                return null;

            NiecException.PrintMessagePro(packageFile, false, float.MaxValue);

            if (Simulator.CheckYieldingContext(false))
                Simulator.Sleep(0);

            var ts = Commom.Proxies.HouseholdContentsProxy.Import(packageFile);
            if (ts == null || ts.Household == null) 
                return null;
            if (ts.Household.AllSimDescriptions.Count == 0 || ts.Household.AllSimDescriptions.Count < 0)
            {
                HouseholdCleanse(ts.Household, false, true);
                return null;
            }
            Create.AutoMoveInLotFromHousehold(ts.Household);
            i = 0;
            List<SimDescription> s = new List<SimDescription>(ts.Household.AllSimDescriptions.Count + 5);
            foreach (var item in ts.Household.AllSimDescriptions.ToArray())
            {
                if (item == null) 
                    continue;
                s.Add(AddNiecSimDescriptions(item));
                SimDesc_SetID(item, GetRandomID());
                if (shouldSleep)
                {
                    i++;
                    if (i > 30)
                    {
                        i = 0;
                        Simulator.Sleep(0);
                    }
                }
            }
            
            return s;
        }
        



        public static bool CreateSocialWorkerToTargetLot(Lot lot, Predicate<Sim> customTest, bool bUnsafe, out NiecSocialWorkerChildAbuseSituation niecSWCAS) {
            niecSWCAS = null;
            if (lot != null && !lot.IsWorldLot && lot.Household != null)
            {
                List<Sim> rmsim = new List<Sim>();
                bool customTestIsNotNull = customTest != null;

                foreach (var ActorFor in SC_GetObjects<Sim>())
                {
                    if (ActorFor == null)
                        continue;
                    if (customTestIsNotNull)
                    {
                        if (!customTest(ActorFor)) 
                            continue;
                        rmsim.Add(ActorFor);
                    }
                    else
                    {
                        SimDescription simd = ActorFor.SimDescription;
                        if (simd == null)
                            continue;
                        if (!simd.IsValidDescription)
                            continue;

                        if (simd.ChildOrBelow || simd.IsPet)
                            continue;

                        if (simd.Household == null)
                            continue;

                        if (ActorFor.HasBeenDestroyed)
                            continue;


                        global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = ActorFor.InteractionQueue;
                        if (yInteractionQueue == null || yInteractionQueue.mInteractionList == null)
                            continue;


                        Autonomy automoy = ActorFor.Autonomy;
                        if (automoy == null)
                            continue;

                        SituationComponent sSituationComponent = automoy.SituationComponent;
                        if (sSituationComponent == null)
                            continue;

                        List<Situation> listSituations = sSituationComponent.Situations;
                        if (listSituations == null)
                            continue;

                        if (ActorFor.GetSituationOfType<NiecSocialWorkerChildAbuseSituation>() != null)
                            continue;

                        rmsim.Add(ActorFor);
                    }
                   
                }

                if (rmsim.Count > 0)
                {
                    niecSWCAS = NiecSocialWorkerChildAbuseSituation.Create (
                        lot, // Current Lot
                        RandomUtil.GetRandomObjectFromList<Sim>(rmsim, ListCollon.SafeRandomPart2), // Worker Sim
                        true, // Add Situation List
                        bUnsafe // UnSafe
                    );
                    rmsim.Clear();
                    return true;
                }
            }
            return false;
        }


        /*
        public static bool AntiNPCSim_SocialWorkerToTargetLotId(ulong lotId) {
            if (lotId == 0) 
                return false;
            Lot TargetLot = LotManager.GetLot(lotId);

            if (TargetLot != null && !TargetLot.IsWorldLot && TargetLot.Household != null)
            {

                foreach (var item in Sims3.Gameplay.Queries.GetObjects<Sim>())
                {
                    
                }


                NiecSocialWorkerChildAbuseSituation.Create(TargetLot, null, true, false);
                return true;
            }
            return false;
        }
        */



        public static int TargetObjectIsRunningTask(object targetObj, bool bNiecTaskOnly) {
            int ifound = 0;
            if (ifound == 0)
            {
                foreach (var item in SC_GetObjects<NiecTask>())
                {
                    if (item == null) continue;
                    if (item.GetTargetObject() == targetObj)
                        ifound++;
                }
            }
            
            if (!IsOpenDGSInstalled &&ifound == 0 && !bNiecTaskOnly) {
                var d = typeof(MulticastDelegate);
                foreach (var itemObj in SC_GetObjects<object>())
                {
                    Task item = itemObj as Task;
                    if (item == null) 
                        continue;
                    var valueType = item.GetType();
                    if (valueType == null)
                        continue;

                    FieldInfo field = valueType.GetField("mFunc", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    if (field == null || !d.IsAssignableFrom(field.FieldType))
                    {
                        field = valueType.GetField("mFunction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        if (field == null || !d.IsAssignableFrom(field.FieldType))
                            continue;
                    }

                    var tarFunction = field.GetValue(valueType) as MulticastDelegate;
                    if (tarFunction == null)
                        continue;

                    var vtarget_obj = tarFunction.Target;
                    if (vtarget_obj == targetObj)
                        ifound++;
                }
            }
            if (ifound == 0 && ScriptCore.Simulator.mObjHash != null && ScriptCore.Simulator.mObjHash.Count < 1750)
            {
                var d = !bNiecTaskOnly ? typeof(MulticastDelegate) : null;
                foreach (var item in ScriptCore.Simulator.mObjHash)
                {
                    if (item.Value == null)
                        continue;
                    NiecTask niecTask = item.Value as NiecTask;
                    if (niecTask != null)
                    {
                        if (niecTask.TargetObject == targetObj)
                            ifound++;
                    }
                    else if (!bNiecTaskOnly) {
                        var valueType = item.Value.GetType();
                        if (valueType == null) 
                            continue;

                        FieldInfo field = valueType.GetField("mFunc", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        if (field == null || !d.IsAssignableFrom(field.FieldType))
                        {
                            field = valueType.GetField("mFunction", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                            if (field == null || !d.IsAssignableFrom(field.FieldType))
                                continue;
                        }

                        var tarFunction = field.GetValue(valueType) as MulticastDelegate;
                        if (tarFunction == null) 
                            continue;

                        var vtarget_obj = tarFunction.Target;
                        if (vtarget_obj == targetObj)
                            ifound++;
                    }
                }
            }
            return ifound;
        }




        public static
            bool IsHasInteractionGRSTargetSim(Sim Target)
        {
            if (Target == null)
                return false;
            foreach (var AllActor in SC_GetObjects<Sim>())//Sims3.Gameplay.Queries.GetObjects<Sim>())
            {
                //SimDescription AllActorSimDesc = AllActor.SimDescription;
                //if (AllActorSimDesc == null)
                //    continue;

                global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = AllActor.InteractionQueue;
                if (yInteractionQueue == null)
                    continue;

                List<InteractionInstance> yInteractionList = yInteractionQueue.mInteractionList;
                if (yInteractionList == null)
                    continue;
                foreach (var itemInteraction in yInteractionList)
                {
                    if (itemInteraction == null)
                        continue;
                    if (!(itemInteraction is GrimReaperSituation.ReapSoul) && !(itemInteraction is GrimReaperSituation.ReapPetSoul) && !(itemInteraction is GrimReaperSituation.ReapSoulDiving))
                        continue;
                    if (itemInteraction.Target == Target)
                        return true;
                }
                Stack<InteractionInstance> sInteractionList = yInteractionQueue.mRunningInteractions;
                if (sInteractionList == null)
                    continue;
                foreach (var itemInteraction in sInteractionList)
                {
                    if (itemInteraction == null)
                        continue;
                    if (!(itemInteraction is GrimReaperSituation.ReapSoul) && !(itemInteraction is GrimReaperSituation.ReapPetSoul) && !(itemInteraction is GrimReaperSituation.ReapSoulDiving))
                        continue;
                    if (itemInteraction.Target == Target)
                        return true;
                }
            }
            return false;
        }

        public static List<InteractionInstance> NiecHelperSituationInteractioList = new List<InteractionInstance>();

        public static bool IsTargetIQNHS(Sim Target) { return ActorIsQueueNHS(Target) || IsHasInteractionNHSTargetSim(Target); }

        public static
            void UnSafe_RemoveActorsUsingMe(GameObject item)
        {
            try
            {
                if (item.mActorsUsingMe != null && item.mActorsUsingMe.Count != 0)
                    List_FastClearEx(ref item.mActorsUsingMe);

                if (item.mReferenceList != null && item.mReferenceList.Count != 0)
                    //item.mReferenceList.Clear();
                    List_FastClearEx(ref item.mReferenceList);

                if (item.mRoutingReferenceList != null && item.mRoutingReferenceList.Count != 0)
                    //item.mRoutingReferenceList.Clear();
                    List_FastClearEx(ref item.mRoutingReferenceList);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException)         { throw; }
            catch (Exception)              { }
            
        }

        public static
            bool IsHasInteractionNHSTargetSim(Sim Target)
        {
            if (Target == null)
                return false;
            foreach (var itemInteraction in NiecHelperSituationInteractioList)
            {
                if (itemInteraction == null)
                    continue;
                if (!(itemInteraction is NiecHelperSituation.NiecAppear) && !(itemInteraction is NiecHelperSituation.ReapSoul))
                    continue;
                if (itemInteraction.Target == Target)
                    return true;
            }
            foreach (var AllActor in SC_GetObjects<Sim>())
            {
                //SimDescription AllActorSimDesc = AllActor.SimDescription;
                //if (AllActorSimDesc == null)
                //    continue;
                if (AllActor == null)
                    continue;
                global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = AllActor.InteractionQueue;
                if (yInteractionQueue == null)
                    continue;

                List<InteractionInstance> yInteractionList = yInteractionQueue.mInteractionList;
                if (yInteractionList == null)
                    continue;
                foreach (var itemInteraction in yInteractionList)
                {
                    if (itemInteraction == null)
                        continue;
                    if (!(itemInteraction is NiecHelperSituation.NiecAppear) && !(itemInteraction is NiecHelperSituation.ReapSoul))
                        continue;
                    if (itemInteraction.Target == Target)
                        return true;
                }
                Stack<InteractionInstance> sInteractionList = yInteractionQueue.mRunningInteractions;
                if (sInteractionList == null)
                    continue;
                foreach (var itemInteraction in sInteractionList)
                {
                    if (itemInteraction == null)
                        continue;
                    if (!(itemInteraction is NiecHelperSituation.NiecAppear) && !(itemInteraction is NiecHelperSituation.ReapSoul))
                        continue;
                    if (itemInteraction.Target == Target)
                        return true;
                }
            }
            return false;
        }

        public static IHasScriptProxy axdasd = null;

        public static bool asdsett = true;

        public static StateMachineClient StateMachineClient_Acquire(IHasScriptProxy hostObject, string stateMachineName) {
            try
            {
                if (axdasd != null)
                {
                    var to = axdasd as GameObject;
                    if (to != null)
                    {
                        if (to.mActorsUsingMe != null && to.mActorsUsingMe.Count != 0)
                            to.mActorsUsingMe.Clear();

                        if (to.mReferenceList != null && to.mReferenceList.Count != 0)
                            to.mReferenceList.Clear();

                        if (to.mRoutingReferenceList != null && to.mRoutingReferenceList.Count != 0)
                            to.mRoutingReferenceList.Clear();
                    }
                }
                return Instantiator.RootIsOpenDGSInstalled ? 
                    StateMachineClient.Acquire(hostObject, stateMachineName, AnimationPriority.kAPUltraPlus) :

                StateMachineClient.Acquire (
                    axdasd = (asdsett ? GetFirstSafeObject(SC_GetObjects<global::Sims3.Gameplay.Objects.Plumbing.Shower>()) : null) ??
                    GetRandomSim() ??
                    hostObject ??
                    //
                    ActiveActor,
                    stateMachineName,
                    AnimationPriority.kAPLookAt
                );
            }
            catch (SacsErrorException ex)
            { if (asdsett && ex.Message != null && ex.Message.Contains("SacsComponent")) asdsett = false; return null; }
            
        }
        public static StateMachineClient StateMachineClient_AcquireX(IHasScriptProxy hostObject, string stateMachineName, AnimationPriority priority)
        {
            try
            {
                return Instantiator.RootIsOpenDGSInstalled ?
                    StateMachineClient.Acquire(hostObject, stateMachineName, priority) :

                StateMachineClient.Acquire(
                    (asdsett ? GetFirstSafeObject(SC_GetObjects<global::Sims3.Gameplay.Objects.Plumbing.Shower>()) : null) ??
                    GetRandomSim() ??
                    hostObject ??
                    //
                    ActiveActor,
                    stateMachineName,
                    priority
                );
            }
            catch (SacsErrorException ex)
            { if (asdsett && ex.Message != null && ex.Message.Contains("SacsComponent")) asdsett = false; return null; }

        }
        public static bool InteractionIsNiecHelperSituation(InteractionInstance itemInteraction)
        {
            return itemInteraction is NiecHelperSituation.NiecAppear || itemInteraction is NiecHelperSituation.ReapSoul;
        }
        public static bool ForceAAInteractionIsNiecHelperSituationPosture_internal = true;
        public static bool InteractionIsNiecHelperSituationPosture_internal(GameObject actor,InteractionInstance itemInteraction)
        {
            if (itemInteraction == null) 
                return false;

            if (itemInteraction is NiecHelperSituation.NiecAppear || itemInteraction is NiecHelperSituation.ReapSoul)
                return true;

            NinecReaper custi = itemInteraction as NinecReaper;
            if (custi != null && custi.CustomRunName == "uloopnhs")
                return true;

            if (IsOpenDGSInstalled)
            {
                if (itemInteraction is Urnstone.KillSim || itemInteraction is ExtKillSimNiec)
                    return true;

                var activeActor = PlumbBob.SelectedActor;
                if (activeActor != null)
                {
                    if (ForceAAInteractionIsNiecHelperSituationPosture_internal && activeActor == actor) return true;
                    var goHere = itemInteraction as Terrain.GoHere ?? itemInteraction as Terrain.GoHereWith;
                    if (goHere != null)
                    {
                        if (goHere.Actor == activeActor)
                            return true;
                    }

                    if (Terrain.GoHere.IsInstance(itemInteraction) && itemInteraction.InstanceActor == activeActor)
                        return true;

                    if (!itemInteraction.Autonomous && itemInteraction.InstanceActor == activeActor && itemInteraction.Target == NiecRunCommand.HitTargetGameObject())
                        return true;
                }

                //var inDefin = itemInteraction.InteractionDefinition;
                //if (inDefin != null)
                //{
                //    InteractionDefinition goHereDe = (inDefin as Terrain.GoHere.SameLotDefinition ?? inDefin as Terrain.GoHereWith.SameLotDefinition);
                //    if (goHereDe != null)
                //    {
                //        if (goHere.Actor == PlumbBob.SelectedActor)
                //            return true;
                //    }
                //    goHereDe = (inDefin as Terrain.GoHere.OtherLotDefinition ?? inDefin as Terrain.GoHereWith.OtherLotDefinition);
                //    if (goHereDe != null)
                //    {
                //        if (goHere.Actor == PlumbBob.SelectedActor)
                //            return true;
                //    }
                //}
            }
            return false;   
        }

        public static bool ActorIsQueueNHS(Sim Actor)
        {
            if (Actor == null) return false;
            global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = Actor.InteractionQueue;
            if (yInteractionQueue == null)
                return false;

            List<InteractionInstance> yInteractionList = yInteractionQueue.mInteractionList;
            if (yInteractionList == null)
                return false;
            foreach (var itemInteraction in yInteractionList)
            {
                if (itemInteraction == null)
                    continue;
                if (!(itemInteraction is NiecHelperSituation.NiecAppear) && !(itemInteraction is NiecHelperSituation.ReapSoul))
                    continue;
                if (!Instantiator.RootIsOpenDGSInstalled)
                {
                    itemInteraction.mPriority = new InteractionPriority(InteractionPriorityLevel.MaxDeath, 0f);
                    itemInteraction.mMustRun = true;
                }
                return true;
            }
            Stack<InteractionInstance> sInteractionList = yInteractionQueue.mRunningInteractions;
            if (sInteractionList == null)
                return false;
            foreach (var itemInteraction in sInteractionList)
            {
                if (itemInteraction == null)
                    continue;
                if (!(itemInteraction is NiecHelperSituation.NiecAppear) && !(itemInteraction is NiecHelperSituation.ReapSoul))
                    continue;
                if (!Instantiator.RootIsOpenDGSInstalled)
                {
                    itemInteraction.mPriority = new InteractionPriority(InteractionPriorityLevel.MaxDeath, 0f);
                    itemInteraction.mMustRun = true;
                }
                return true;
            }
            return false;
        }

        public static ObjectGuid FindTask(string FindCallStack, string FindClassName)
        {
            if (ScriptCore.Simulator.mObjHash == null)
                return ObjectGuid.InvalidObjectGuid;

            bool haveFindClassName = FindClassName != null && FindClassName != "";
            bool haveFindCallStack = FindCallStack != null && FindCallStack != "";

            if (!haveFindClassName && !haveFindCallStack)
                return ObjectGuid.InvalidObjectGuid;

            //Dictionary<ulong, ITask> dictionary = new Dictionary<ulong, ITask>(ScriptCore.Simulator.mObjHash);
            foreach (var item in ScriptCore.Simulator.mObjHash)
            {
                if (item.Value == null)
                    continue;
                if (haveFindClassName && item.Value.ClassName == FindClassName
                    && !____GetObjectStackTrace(item.Key).Contains("at Void NRaas.CommonSpace.Tasks.RepeatingTask.Simulate()")) // NRaas Fail
                {
                    return item.Value.ObjectId;
                }
                if (haveFindCallStack)
                {
                    string st = ____GetObjectStackTrace(item.Key);

                    if (st == null || st == "<no call stack>")
                        continue;
                    if (st.Contains(FindCallStack) && !st.Contains("at Void NRaas.CommonSpace.Tasks.RepeatingTask.Simulate()")) // NRaas Fail
                        return new ObjectGuid(item.Key);
                }
            }
            return ObjectGuid.InvalidObjectGuid;
        }

        public static SimDescription SetCreatedSim_SimDesc(Sim TargetSim, SimDescription ToSimDesc)
        {
            if (TargetSim == null) return null;
            //if (simDesc == null) return null;

            var TargetSimDesc = TargetSim.SimDescription;
            if (ToSimDesc != null)
            {
                if (TargetSimDesc != null)
                {
                    TargetSimDesc.mSim = null;
                }

                var ToSimDesc_CreatedSim = ToSimDesc.CreatedSim;
                if (ToSimDesc_CreatedSim != null)
                {
                    var RandomSimDesc = GetRandomSimDescription((SimDescription sim_Test) => sim_Test.CreatedSim == null && !_IsActiveHousehold(sim_Test.Household), false);
                    if (RandomSimDesc != null)
                    {
                        ToSimDesc_CreatedSim.mSimDescription = RandomSimDesc;
                        RandomSimDesc.mSim = ToSimDesc_CreatedSim;
                    }
                }

                TargetSim.mSimDescription = ToSimDesc;
                ToSimDesc.mSim = TargetSim;
                
            }
            return TargetSimDesc;
        }

        public static SimDescription UnSafe_OrgToNull_SimDesc(Sim obj_Sim) {
            SimDescription simd = obj_Sim.SimDescription;
            obj_Sim.mSimDescription = Create.NiecNullSimDescription();
            obj_Sim.mSimDescription.mSim = obj_Sim;
            if (simd != null) {
                simd.mSim = null;
                return simd;
            }
            return null;
        }

       

        public static void DestroyAllObjectsOnLot(Lot TargetLot, bool KillNPCSim = false, bool Sleep = false, bool NeedAllNullSimDesc = false) {
            PlumbBob bob = PlumbBob.sSingleton;
            Sim activeActor = ActiveActor;
            int iSleep = 0;
            //Lot WorldLot = LotManager.GetWorldLot();
            var outofwolrd = Vector3.OutOfWorld;
            foreach (var iteam in SC_GetObjectsOnLot<IScriptLogic>(TargetLot))
            {
                
                if (iteam == null)
                    continue;
                if (iteam == bob)
                    continue;
                if (iteam == activeActor) {
                    var src = activeActor.SimRoutingComponent;
                    try
                    {
                        src.DisableDynamicFootprint();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                    activeActor.SetPosition(Lot_SafeGetPositionInRandomLot(activeActor.LotHome ?? LotManager.GetWorldLot()));

                    try
                    {
                        src.EnableDynamicFootprint();
                        src.ForceUpdateDynamicFootprint();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                    continue;
                }
                GameObject item = iteam as GameObject;
                if (item == null)
                {
                    var pxy = iteam.Proxy;
                    if (pxy != null)
                    {
                        if (pxy == activeActor || pxy == bob)
                            continue;
                        Simulator.DestroyObject(pxy.ObjectId);
                    }
                    continue; 
                }
                
                try
                {
                    Sim sim = iteam as Sim;
                    if (sim != null)
                    {
                        if ((!KillNPCSim || IsAllActiveHousehold_SimObject(sim)))
                        {
                            var src = sim.SimRoutingComponent;
                            try
                            {
                                src.DisableDynamicFootprint();
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch
                            { }
                            
                            sim.SetPosition(Service.GetPositionInRandomLot(TargetLot));

                            try
                            {
                                src.EnableDynamicFootprint();
                                src.ForceUpdateDynamicFootprint();
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch
                            { }
                           
                            continue;
                        }
                        else if (NeedAllNullSimDesc) {
                            UnSafe_OrgToNull_SimDesc(sim);
                        }
                    }
                    item.SetPosition(outofwolrd);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch { }
                
                if (Sleep) {
                    iSleep++;
                    if (iSleep > 500) {
                        iSleep = 0;
                        Simulator.Sleep(0);
                    }
                }

                ForceDestroyObject(item, false);
            }
        }


        public static ObjectGuid FindTaskPro(string FindCallStack, string FindClassName, out ITask OutTask)
        {
            OutTask = null;
            if (ScriptCore.Simulator.mObjHash == null)
                return ObjectGuid.InvalidObjectGuid;

            bool haveFindClassName = FindClassName != null && FindClassName != "";
            bool haveFindCallStack = FindCallStack != null && FindCallStack != "";

            if (!haveFindClassName && !haveFindCallStack)
                return ObjectGuid.InvalidObjectGuid;

            //Dictionary<ulong, ITask> dictionary = new Dictionary<ulong, ITask>(ScriptCore.Simulator.mObjHash);
            foreach (var item in ScriptCore.Simulator.mObjHash)
            {
                if (item.Value == null)
                    continue;
                if (haveFindClassName && item.Value.ClassName == FindClassName)
                {
                    OutTask = item.Value;
                    return item.Value.ObjectId;
                }
                if (haveFindCallStack)
                {
                    string st = ____GetObjectStackTrace(item.Key);

                    if (st == null || st == "<no call stack>")
                        continue;
                    if (st.Contains(FindCallStack))
                    {
                        OutTask = item.Value;
                        return new ObjectGuid(item.Key);
                    }
                }
            }
            return ObjectGuid.InvalidObjectGuid;
        }
        public static Vector3 Fast_SnapToFloor(Vector3 position)
        {
            var locInvalid = LotLocation.Invalid;
            var atFloor = ScriptCore.World.World_GetLotLocationAtFloorImpl(position, ref locInvalid, eRoomDefinition.PlacementBlocking);
            if (atFloor != 0 && atFloor != ulong.MaxValue)
            {
                var worldPosition = position;
                ScriptCore.World.World_GetWorldPositionImpl(atFloor, locInvalid, ref worldPosition);
                if (ScriptCore.World.World_IsOnPlatformImpl(worldPosition))
                {
                    worldPosition.y += 0.1875f;
                }
                position.y = worldPosition.y;
            }
            else
            {
                position.y = ScriptCore.World.World_GetTerrainHeightImpl(position.x, position.z, true);
            }
            return position;
        }
        public static bool baCheckACoreThrowNRaasErrorTrap = false;

        public static void DEBUG_NSTack()
        {
            new NCopyableTextDialog(GetStackTraceToStringFast(new NStackTrace(0, false), false)).SafeShow("DEBUG_NSTack");
            new NCopyableTextDialog(GetStackTraceToStringFast(new NStackTrace(2, false), false)).SafeShow("DEBUG_NSTack 2");
            //new NCopyableTextDialog("Success?: " + niec_std.okindexifar).SafeShow("DEBUG array_indexof item Found");
            new NCopyableTextDialog(
#if EA_DEBUG
                "Current memory usage: %" + ScriptCore.GameUtils.GameUtils_GetCurrentMemoryUsage() + "\n" +
#endif
                "Current total memory: " + GC.GetTotalMemory(false) + "\n"
                + "Current used bytes: " + ScriptCore.Simulator.Simulator_GetUsedBytesImpl())
                .SafeShow("DEBUG MEM");
        }
        public static bool NoThrowCheckACoreThrowNRaasErrorTrap(int skipFrames)
        {
            return !IsOpenDGSInstalled && !SCOSR.IsScriptCore2020() && baCheckACoreThrowNRaasErrorTrap && AssemblyCheckByNiec.IsInstalled("AweCore") && AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") && IsSTAwesomeMod04<Sim>(false, false, true, skipFrames + 3);
        }
        public static void CheckACoreThrowNRaasErrorTrap()
        {
            //if (SCOSR.IsScriptCore2020()) return;
            if (!IsOpenDGSInstalled && !SCOSR.IsScriptCore2020() && baCheckACoreThrowNRaasErrorTrap && AssemblyCheckByNiec.IsInstalled("AweCore") && AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") && IsSTAwesomeMod04<Sim>(false, false, true, 3))
                AntiSpy_ThrowDefault();
        }
        public static string GetStackTraceToStringFast(NStackTrace nStackTrace, bool newFistline)
        {
            if (nStackTrace == null)
                throw new ArgumentNullException("nStackTrace");

            var stringBuilder = new StringBuilder();
            if (newFistline)
                stringBuilder.AppendLine();

            int count = nStackTrace.FrameCountFast;

            //int countEnd = ex_ST.FrameCount - 1;

            int it = 0;
            for (int i = 0; i < count; i++)
            {
                StackFrame frame = nStackTrace.GetFrameFast(i);
                if (frame == null)
                    break;

                MethodInfo methodInfo = frame.GetMethod() as MethodInfo;
                if (methodInfo == null)
                    continue;

                stringBuilder.Append("	at ");
                stringBuilder.Append(methodInfo.ReturnType.Name);
                stringBuilder.Append(' ');

                Type declaringType = methodInfo.DeclaringType;
                stringBuilder.Append(declaringType.FullName);
                stringBuilder.Append('.');
                stringBuilder.Append(methodInfo.Name);
                stringBuilder.Append(" ()");
                //ParameterInfo[] parameters = methodInfo.GetParameters();
                //
                //if (parameters != null)
                //{
                //    for (int iPInfo = 0; iPInfo < parameters.Length; iPInfo++)
                //    {
                //        if (iPInfo != 0)
                //        {
                //            stringBuilder.Append(", ");
                //        }
                //        ParameterInfo parameterInfo = parameters[iPInfo];
                //        Type parameterType = parameterInfo.ParameterType;
                //        stringBuilder.Append(parameterType.Name);
                //        stringBuilder.Append(' ');
                //        stringBuilder.Append(parameterInfo.Name);
                //    }
                //}
                //stringBuilder.Append(')');

                it++;
                if (it < count)
                    stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();

        }
        public static string GetStackTraceToString(StackTrace ex_ST, bool newFistline)
        {
            if (ex_ST == null)
                throw new ArgumentNullException("ex_ST");
            
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (newFistline)
                    stringBuilder.AppendLine();
                int count = ex_ST.FrameCount;
                //int countEnd = ex_ST.FrameCount - 1;
                int it = 0;
                for (int i = 0; i < count; i++)
                {
                    StackFrame frame = ex_ST.GetFrame(i);
                    if (frame == null) continue;
                    MethodInfo methodInfo = frame.GetMethod() as MethodInfo;
                    if (methodInfo == null) continue;

                    stringBuilder.Append("	at ");
                    stringBuilder.Append(methodInfo.ReturnType.Name);
                    stringBuilder.Append(' ');
                    Type declaringType = methodInfo.DeclaringType;
                    stringBuilder.Append(declaringType.FullName);
                    stringBuilder.Append('.');
                    stringBuilder.Append(methodInfo.Name);
                    stringBuilder.Append(" (");
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters != null)
                    {
                        for (int iPInfo = 0; iPInfo < parameters.Length; iPInfo++)
                        {
                            if (iPInfo != 0)
                            {
                                stringBuilder.Append(", ");
                            }
                            ParameterInfo parameterInfo = parameters[iPInfo];
                            Type parameterType = parameterInfo.ParameterType;
                            stringBuilder.Append(parameterType.Name);
                            stringBuilder.Append(' ');
                            stringBuilder.Append(parameterInfo.Name);
                        }
                    }
                    stringBuilder.Append(')');
                    it++;
                    //if (it < count)
                    if (it < count)
                        stringBuilder.Append('\n');
                }
                return stringBuilder.ToString();
            }
            catch (ResetException)
            { throw; }
            catch { return ex_ST.ToString(); }
        }







        

        public static
            EventListener EventTracker_FindEventListener(Predicate<EventListener> testFunc)
        {
            if (testFunc == null)
                throw new ArgumentNullException("testFunc");
            var evI = EventTracker.Instance;
            if (evI == null)
                return null;

            if (evI.mAddList != null)
            {
                foreach (var item in evI.mAddList)
                {
                    var deLister = item.Second;
                    if (deLister == null) 
                        continue; 
                    if (!testFunc(deLister))
                        continue;

                    return deLister;
                }
            }
            if (evI.mListeners != null)
            {
                foreach (var item in evI.mListeners)
                {
                    var c01 = item.Value;
                    if (c01 == null)
                        continue;
                    foreach (var itemChild01 in c01)
                    {
                        var c02 = itemChild01.Value;
                        if (c02 == null)
                            continue;
                        foreach (var itemChild02 in c02)
                        {
                            //var deLister = itemChild02;
                            if (itemChild02 == null)
                                continue;
                            if (!testFunc(itemChild02))
                                continue;

                            return itemChild02;
                        }
                    }
                }
            }
            return null;
        }

        public static
            List<EventListener> EventTracker_FindAllEventListener(Predicate<EventListener> testFunc)
        {
            if (testFunc == null)
                throw new ArgumentNullException("testFunc");
            var evI = EventTracker.Instance;

            if (evI == null)
                return null;

            List<EventListener> tempEventListenerList = null;
            try
            {
                if (evI.mAddList != null)
                {
                    foreach (var item in evI.mAddList)
                    {
                        var deLister = item.Second;
                        if (deLister == null)
                            continue;
                        if (!testFunc(deLister))
                            continue;

                        Lazy.Add(ref tempEventListenerList, deLister);
                    }
                }
                if (evI.mListeners != null)
                {
                    foreach (var item in evI.mListeners)
                    {
                        var c01 = item.Value;
                        if (c01 == null)
                            continue;
                        foreach (var itemChild01 in c01)
                        {
                            var c02 = itemChild01.Value;
                            if (c02 == null)
                                continue;
                            foreach (var itemChild02 in c02)
                            {
                                if (itemChild02 == null)
                                    continue;
                                if (!testFunc(itemChild02))
                                    continue;

                                Lazy.Add(ref tempEventListenerList, itemChild02);
                            }
                        }
                    }
                }
            }
            catch (ResetException)
            { throw; }
            catch { }
            
            return tempEventListenerList;
        }


        public static
            DelegateListener EventTracker_FindDelegateListener(Predicate<DelegateListener> testFunc)
        {
            if (testFunc == null)
                throw new ArgumentNullException("testFunc");
            var evI = EventTracker.Instance;
            if (evI == null)
                return null;

            if (evI.mAddList != null)
            {
                foreach (var item in evI.mAddList)
                {
                    //if (item == null) continue;
                    var deLister = item.Second as DelegateListener;
                    if (deLister == null) { continue; }
                    if (!testFunc(deLister))
                        continue;
                    return deLister;
                }
            }
            if (evI.mListeners != null)
            {
                foreach (var item in evI.mListeners)
                {
                    var c01 = item.Value;
                    if (c01 == null)
                        continue;
                    foreach (var itemChild01 in c01)
                    {
                        var c02 = itemChild01.Value;
                        if (c02 == null)
                            continue;
                        foreach (var itemChild02 in c02)
                        {
                            var deLister = itemChild02 as DelegateListener;
                            if (deLister == null)
                                continue;
                            if (!testFunc(deLister))
                                continue;

                            return deLister;
                        }
                    }
                }
            }
            return null;
        }

        public static
            List<DelegateListener> EventTracker_FindAllDelegateListener(Predicate<DelegateListener> testFunc)
        {
            if (testFunc == null)
                throw new ArgumentNullException("testFunc");

            var evI = EventTracker.Instance;
            if (evI == null)
                return null;

            List<DelegateListener> tempDelegateListenerList = null;
            try
            {
                if (evI.mAddList != null)
                {
                    foreach (var item in evI.mAddList)
                    {
                        var deLister = item.Second as DelegateListener;
                        if (deLister == null)
                            continue;

                        if (!testFunc(deLister))
                            continue;

                        Lazy.Add(ref tempDelegateListenerList, deLister);
                    }
                }
                if (evI.mListeners != null)
                {
                    foreach (var item in evI.mListeners)
                    {
                        var c01 = item.Value;
                        if (c01 == null)
                            continue;
                        foreach (var itemChild01 in c01)
                        {
                            var c02 = itemChild01.Value;
                            if (c02 == null)
                                continue;
                            foreach (var itemChild02 in c02)
                            {
                                var deLister = itemChild02 as DelegateListener;
                                if (deLister == null)
                                    continue;
                                if (!testFunc(deLister))
                                    continue;

                                Lazy.Add(ref tempDelegateListenerList, deLister);
                            }
                        }
                    }
                }
            }
            catch (ResetException)
            { throw; }
            catch { }
            
            return tempDelegateListenerList;
        }
        public static MethodBase _GetTaskContextTraceOne(object tcontext, out object thisStackObj)
        {
            thisStackObj = null;
            if (!(tcontext is ScriptCore.TaskContext))
            {
                return null;
            }

            ScriptCore.TaskContext context = (ScriptCore.TaskContext)tcontext;
            if (context.mFrames == null) 
                return null;

            for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
            {
                ScriptCore.TaskFrame taskFrame = context.mFrames[stack];
                
                if (taskFrame.mMethodHandle.Value != IntPtr.Zero)
                {
                    MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                    if (methodInfo == null) 
                        continue;
                    if (!methodInfo.IsStatic)
                    {
                        thisStackObj = taskFrame.mThisObj;
                    }
                    return methodInfo;
                }
            }
            return null;
        }
        public static MethodBase _GetTaskContextTraceIndex(object tcontext, int index, out object thisStackObj)
        {
            thisStackObj = null;
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (!(tcontext is ScriptCore.TaskContext))
            {
                return null;
            }

            ScriptCore.TaskContext context = (ScriptCore.TaskContext)tcontext;
            if (context.mFrames == null)
                return null;

            if ( ((context.mFrames.Length - 1) - index) < 0 ) 
                return null;

            for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
            {
                if (stack == index)
                {
                    ScriptCore.TaskFrame taskFrame = context.mFrames[index];

                    if (taskFrame.mMethodHandle.Value != IntPtr.Zero)
                    {
                        MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                        if (methodInfo == null)
                            continue;
                        if (!methodInfo.IsStatic)
                        {
                            thisStackObj = taskFrame.mThisObj;
                        }
                        return methodInfo;
                    }
                    break;
                }
            }
            return null;
        }
        public static string ____GetObjectStackTrace(ulong objectHandle)
        {
            ScriptCore.TaskContext context;
            if (!ScriptCore.TaskControl.GetTaskContext(objectHandle, true, out context) || context.mFrames == null)
            {
                return "<no call stack>";
            }
            
            StringBuilder stringBuilder = new StringBuilder();
            ScriptCore.TaskFieldReference fieldRef = default(ScriptCore.TaskFieldReference);
            for (int num = context.mFrames.Length - 1; num >= 0; num--)
            {
                ScriptCore.TaskFrame taskFrame = context.mFrames[num];
                fieldRef.mFrameIndex = num;
                if (taskFrame.mMethodHandle.Value != IntPtr.Zero)
                {
                    MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                    if (methodInfo == null) continue;
                    stringBuilder.Append("    at ");

                    var methedinfoC = methodInfo as MethodInfo;
                    if (methedinfoC != null)
                    {
                        stringBuilder.Append(methedinfoC.ReturnType.Name);
                    }
                    else 
                        stringBuilder.Append("Void");

                    stringBuilder.Append(' ');

                    Type declaringType = methodInfo.DeclaringType;
                    stringBuilder.Append(declaringType.FullName);
                    stringBuilder.Append('.');
                    //stringBuilder.Append(declaringType.Name);
                    //stringBuilder.Append('.');
                    stringBuilder.Append(methodInfo.Name);
                    stringBuilder.Append('(');
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (i != 0)
                        {
                            stringBuilder.Append(", ");
                        }
                        ParameterInfo parameterInfo = parameters[i];
                        Type parameterType = parameterInfo.ParameterType;
                        stringBuilder.Append(parameterType.Name);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(parameterInfo.Name);
                        fieldRef.mFieldIndex = i;
                        switch (Type.GetTypeCode(parameterType))
                        {
                            case TypeCode.Boolean:
                                {
                                    object fieldValue = ScriptCore.TaskControl.GetFieldValue(objectHandle, fieldRef);
                                    if (fieldValue != null)
                                    {
                                        stringBuilder.Append(((bool)fieldValue) ? " = true" : " = false");
                                    }
                                    break;
                                }
                            case TypeCode.Char:
                                {
                                    object fieldValue = ScriptCore.TaskControl.GetFieldValue(objectHandle, fieldRef);
                                    if (fieldValue != null)
                                    {
                                        stringBuilder.AppendFormat(" = {0}", (int)(char)fieldValue);
                                    }
                                    break;
                                }
                            case TypeCode.SByte:
                            case TypeCode.Byte:
                            case TypeCode.Int16:
                            case TypeCode.UInt16:
                            case TypeCode.Int32:
                            case TypeCode.UInt32:
                            case TypeCode.Int64:
                            case TypeCode.UInt64:
                            case TypeCode.Single:
                            case TypeCode.Double:
                            case TypeCode.Decimal:
                            case TypeCode.DateTime:
                                {
                                    object fieldValue = ScriptCore.TaskControl.GetFieldValue(objectHandle, fieldRef);
                                    if (fieldValue != null)
                                    {
                                        stringBuilder.AppendFormat(" = {0}", fieldValue);
                                    }
                                    break;
                                }
                            case TypeCode.String:
                                {
                                    object fieldValue = ScriptCore.TaskControl.GetFieldValue(objectHandle, fieldRef);
                                    if (fieldValue != null)
                                    {
                                        stringBuilder.AppendFormat(" = \"{0}\"", fieldValue);
                                    }
                                    else
                                    {
                                        stringBuilder.Append(" = null");
                                    }
                                    break;
                                }
                        }
                    }
                    stringBuilder.Append(')');
                    stringBuilder.Append('\n');
                }
                else
                {
                    stringBuilder.AppendLine("<Invalid method>");
                }

            }
            if (context.mNativeYieldCall != 0)
            {
                ScriptCore.TaskControl.TaskControl_ReleaseYieldingCall(context.mNativeYieldCall);
            }
            stringBuilder.Append("\nSleep: " + context.mSleepTicks);
            return stringBuilder.ToString();
        }

        public static string TaskContext_GetToString(object taskContext)
        {
            if (!(taskContext is ScriptCore.TaskContext)) return "<no call stack>"; 
            var context = (ScriptCore.TaskContext)taskContext;
            if (context.mFrames == null)
            {
                return "<no call stack>";
            }
            StringBuilder stringBuilder = new StringBuilder();
            ScriptCore.TaskFieldReference fieldRef = default(ScriptCore.TaskFieldReference);
            for (int num = context.mFrames.Length - 1; num >= 0; num--)
            {
                ScriptCore.TaskFrame taskFrame = context.mFrames[num];
                fieldRef.mFrameIndex = num;
                if (taskFrame.mMethodHandle.Value != IntPtr.Zero)
                {
                    MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                    stringBuilder.Append("    at ");
                    var methedinfoC = methodInfo as MethodInfo;
                    if (methedinfoC != null)
                    {
                        stringBuilder.Append(methedinfoC.ReturnType.Name);
                    }
                    else
                        stringBuilder.Append("Void");
                    //
                    stringBuilder.Append(' ');

                    Type declaringType = methodInfo.DeclaringType;
                    stringBuilder.Append(declaringType.FullName);
                    stringBuilder.Append('.');
                    //stringBuilder.Append(declaringType.Name);
                    //stringBuilder.Append('.');
                    stringBuilder.Append(methodInfo.Name);
                    stringBuilder.Append('(');
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (i != 0)
                        {
                            stringBuilder.Append(", ");
                        }
                        ParameterInfo parameterInfo = parameters[i];
                        Type parameterType = parameterInfo.ParameterType;
                        stringBuilder.Append(parameterType.Name);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(parameterInfo.Name);
                    }
                    stringBuilder.Append(')');
                    stringBuilder.Append('\n');
                }
                else
                {
                    stringBuilder.AppendLine("<Invalid method>");
                }
            }
            stringBuilder.Append("\nSleep: " + context.mSleepTicks);
            return stringBuilder.ToString();
        }

        private static
            object forceThrowStackOverflowExceptiona()
        {
            ForceThrowStackOverflowException();
            return ForceThrowStackOverflowException();
        }

        public static
            object ForceThrowStackOverflowException() // i did Mono Auto br.s ?
        {
            return forceThrowStackOverflowExceptiona();
        }

        public static void StyledNotification__Add(NotificationManager ths, Notification notification, NotificationManager.TNSCategory category)
        {

            if (ths == null)
            {
                notification.Dispose();
                return;
            }
            WindowBase win = ths.mTabGlows[category];
            ths.SetGlow(win, true);
            ths.mNotifications[category].Add(notification);
            ths.mTabs[category].Enabled = true;
            if (ths.mNotifications[ths.mCurrentCategory].Count == 0)
            {
                ths.mCurrentCategory = category;
            }
            if (category == ths.mCurrentCategory)
            {
                if (!ths.mOpen)
                {
                    ths.AddShowDelayTask();
                    return;
                }
                if (ths.mShowDelayTask == null)
                {
                    ths.SetGlow(win, false);
                }
                ths.SetGlow(ths.mMaxTextGlow, true);
                ths.UpdatePageInfo();
            }
            else if (!ths.mOpen)
            {
                ths.AddShowDelayTask();
            }
        }



        public static void ServicePoolCleanUp_Perform()
        {

            try
            {
                GrimReaper grim = null;
                if (Services.sAllServices == null) 
                    Services.sAllServices = new List<Service>();
                for (int i = Services.sAllServices.Count - 1; i >= 0; i--)
                {
                    Service service = Services.sAllServices[i];

                    if (service == null)
                    {
                        Services.sAllServices.RemoveAt(i);

                        //msg += Common.NewLine + "Empty Service Removed";
                        continue;
                    }

                    //msg += Common.NewLine + "Service: " + service.ServiceType;

                    if (service is GrimReaper)
                    {
                        grim = service as GrimReaper;
                    }

                    List<SimDescription> pool = new List<SimDescription>();

                    for (int j = service.mPool.Count - 1; j >= 0; j--)
                    {
                        SimDescription sim = service.mPool[j];
                        if ((sim == null) || (!sim.IsValidDescription) || (sim.Household == null))
                        {
                            service.mPool.RemoveAt(j);

                            //msg += Common.NewLine + "Bogus Service Removed " + service.GetType();
                        }
                        else
                        {
                            pool.Add(sim);
                        }
                    }

                    if (pool.Count == 0) continue;

                    int maxSims = 2;

                    if (service.Tuning != null)
                    {
                        maxSims = service.Tuning.kMaxNumNPCsInPool;
                        if (maxSims < 0)
                        {
                            maxSims = 0;
                        }
                    }

                    Dictionary<ulong, bool> assigned = new Dictionary<ulong, bool>();

                    //msg += Common.NewLine + "Tuning: " + maxSims;
                    //msg += Common.NewLine + "Count: " + pool.Count;

                    ResortWorker workerService = service as ResortWorker;
                    List<ObjectGuid> objsToUnReg = new List<ObjectGuid>();
                    if (workerService != null)
                    {
                        if (workerService.mWorkerInfo != null)
                        {
                            foreach (KeyValuePair<ObjectGuid, ResortWorker.WorkerInfo> info in workerService.mWorkerInfo)
                            {
                                bool objValid = false;
                                GameObject obj = GameObject.GetObject(info.Key);
                                if (obj != null && obj.InWorld)
                                {
                                    Lot lotCurrent = obj.LotCurrent;
                                    if (lotCurrent != null && lotCurrent.IsCommunityLotOfType(CommercialLotSubType.kEP10_Resort))
                                    {
                                        objValid = true;
                                        assigned[info.Value.CurrentSimDescriptionID] = true;
                                        assigned[info.Value.DesiredSimDescriptionID] = true;
                                    }
                                }

                                if (!objValid)
                                {
                                    objsToUnReg.Add(info.Key);
                                }
                            }

                            foreach (ObjectGuid guid in objsToUnReg)
                            {
                                workerService.UnregisterObject(guid);
                            }
                            objsToUnReg.Clear();
                        }
                    }

                    //RandomUtil.RandomizeListOfObjects(pool);

                    if (!AssemblyCheckByNiec.IsInstalled("OpenDGS") && !(service is GrimReaper))
                    {
                        for (int j = pool.Count - 1; j >= 0; j--)
                        {
                            //if (workerService == null)
                            //{
                            //    if (pool.Count <= maxSims) break;
                            //}

                            if (pool.Count <= maxSims) break;

                            SimDescription choice = pool[j];

                            if (service.IsSimAssignedTask(choice)) continue;

                            if (assigned.ContainsKey(choice.SimDescriptionId)) continue;

                            //ServiceCleanup.AttemptServiceDisposal(choice, false, "Too Many " + service.ServiceType);
                            SimDescCleanse(choice, true, false);

                            pool.RemoveAt(j);
                        }
                    }

                    List<SimDescription> serviceSims = new List<SimDescription>(service.Pool);
                    foreach (SimDescription serviceSim in serviceSims)
                    {
                        if (serviceSim == null) continue;

                        if (!serviceSim.IsValidDescription)
                        {
                            service.EndService(serviceSim);
                        }
                    }
                }

                if (grim != null)
                {
                    if (grim.mPool.Count == 0)
                    {
                        SimDescription sim = grim.CreateNewNPCForPool(null);
                        if (sim != null)
                        {
                            grim.AddSimToPool(sim);
                        }
                        else Assert("grim.CreateNewNPCForPool(null) failed");
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch //(Exception e)
            {
                //Common.Exception(msg, e);
            }
            //finally
            //{
            //    //Common.DebugNotify(msg);
            //}
        }

        public static List<ulong> CreateIndexMap_(Household house)
        {
            List<ulong> list = new List<ulong>();
            if (house != null)
            {
                foreach (SimDescription simDescription in house.AllSimDescriptions)
                {
                    list.Add(simDescription.SimDescriptionId);
                }
            }
            return list;
        }
        public static void CreateActorsPro(Household mhouse, Lot targetLot, HouseholdContents hoc, bool updateLot, bool updateLot2, bool bStartingFunds)
        {
            if (mhouse == null) return;
            //ulong lotID = 0;
            try
            {
                if (updateLot) {
                    if (targetLot != null) {
                        targetLot.mHousehold = null;
                        mhouse.mLotId = 0;
                        mhouse.mLotHome = null;
                    }
                }
                if (targetLot != null && targetLot.Household == null)
                {
                    //lotID = targetLot.LotId;
                    try
                    {
                        targetLot.MoveIn(mhouse);
                    }
                    catch
                    {
                        targetLot.mHousehold = mhouse;
                        mhouse.mLotId = targetLot.mLotId;
                        mhouse.mLotHome = targetLot;
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            RemoveNullForHouseholdMembers(mhouse);
            try
            {
                foreach (SimDescription siteem in mhouse.AllSimDescriptions)
                {
                    try
                    {
                        siteem.mHousehold = mhouse;

                        Sim simCreated;
                        simCreated = siteem.Instantiate(Vector3.OutOfWorld);
                        if (simCreated != null)
                            simCreated.SetPosition(Vector3.OutOfWorld);
                        siteem.GetMiniSimForProtection().AddProtection(MiniSimDescription.ProtectionFlag.PartialFromPlayer);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            try
            {
                BinCommon.CreateInventories(mhouse, hoc, CreateIndexMap_(mhouse));
                BinCommon.CreateFamilyInventories(mhouse, hoc);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            try
            {
                mhouse.PostImport();
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                Create.ForceSendHomeAllActors(mhouse);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            

            try
            {
                if (bStartingFunds)
                    SetStartingFunds(mhouse);
                else {
                    if (!BinCommon.PayForLot(mhouse, targetLot, true)) {
                        mhouse.SetFamilyFunds(0, true);
                        SetStartingFunds(mhouse);
                    }
                }
                ThumbnailManager.GenerateHouseholdThumbnail(mhouse.HouseholdId, mhouse.HouseholdId, ThumbnailSizeMask.Medium | ThumbnailSizeMask.Large);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            if (updateLot2 && targetLot != null) {
                targetLot.MoveOut(mhouse);
                try
                {
                    targetLot.MoveIn(mhouse);
                }
                catch
                {
                    targetLot.mHousehold = mhouse;
                    mhouse.mLotId = targetLot.mLotId;
                    mhouse.mLotHome = targetLot;
                }
            }
        }






        // NRaas's Code
        public static bool HouseholdIsRole(Household home)
        {
            Household.Members mem = home.mMembers; // custom
            if (mem != null && mem.mAllSimDescriptions != null && mem.mAllSimDescriptions._items != null)
            {
                //foreach (SimDescription item in mem.mAllSimDescriptions._items)
                var a = mem.mAllSimDescriptions.Count;
                var t = mem.mAllSimDescriptions._items;
                for (int i = 0; i < t.Length; i++)
                {
                    if (i >= a) 
                        break;

                    var item = t[i];
                    if (item != null && item.AssignedRole != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static readonly List<object> NeedRunNHSI = IsOpenDGSInstalled ? null : new List<object>(10000);

        public static uint attt_DoRunInteractionNHS = 0;
        internal static object CacheCClean__Data = null;

        public static 
            bool CacheCClean()
        {
            if (CacheCClean__Data != null && CacheCClean__Data is CCnlean)
                return true;
            if (CCnlean.Singleton == null) 
                return false;
            Sim randomSim = GetRandomSim();
            if (randomSim == null) 
                return false;

            CacheCClean__Data = CCnlean.Singleton.CreateInstance(randomSim, randomSim, new InteractionPriority(InteractionPriorityLevel.MaxDeath), false, true);
            return CacheCClean__Data != null && CacheCClean__Data is CCnlean;
        }

        public static 
            void RunFuncDoIntRun(InteractionInstance i)
        {
            if (i == null)
                return;
            NiecTask.Perform(GetCurrentExecuteType(), delegate {
                _RunInteraction(i);
            });
        }

        // unprotected mono mscorlib 

        public static // fast code
            int AddItemToList<T>(List<T> list, T item) // void List'1.Add(item)
        {
            if (list != null && list._items != null && list._items.Length > 0)
            {
                if (list._size < 0 || list._size > list._items.Length)
                    list._size = 0;

                var index = list._size - 1;
                if (index < 0)
                    index = 0;

                list._items[index] = item;
                list._version++;
                list._size++;

                return index;
            }
            return -1;
        }

        public static
            int AddInteractionToNeedRunNHSI(InteractionInstance i)
        {
            if (NeedRunNHSI != null && i != null) 
            {
                if (NeedRunNHSI._size < 0 || NeedRunNHSI._size > NeedRunNHSI._items.Length)
                    NeedRunNHSI._size = 0;

                var index = NeedRunNHSI._size - 1;
                if (index < 0)
                    index = 0;

                NeedRunNHSI._items[index] = i;
                NeedRunNHSI._version++;
                NeedRunNHSI._size++;

                return index;
            }
            return -1;
        }

        public static void SafeInsetIQRunInInteraction(Sims3.Gameplay.ActorSystems.InteractionQueue iq, InteractionInstance ii)
        {
            if (iq == null || ii == null) return;
            var milst = iq.mInteractionList;
            if (milst != null)
            {
                var it = milst._items;
                if (it != null && it.Length > 0)
                {
                    if (milst._size == 0)
                        milst._size = 1;

                    it[0] = ii;

                    milst._version++;

                    iq.mCurrentTransitionInteraction = ii;
                    iq.mIsHeadInteractionActive = true;
                    iq.mIsHeadInteractionLocked = true;
                    iq.mInteractionTimerRunning = true;

                    if (iq.mRunningInteractions == null)
                        iq.mRunningInteractions = new Stack<InteractionInstance>();

                    var ri = iq.mRunningInteractions;
                    if (ri.data == null) 
                        return;

                    ri.Clear();
                    if (ri.data.Length > 0)
                        ri.data[0] = ii;
                }
            }
        }

        public static
            bool SMCIsHandleEventsAsynchronously(string actorName, bool unsafesmc, StateMachineClient smc)
        {
            //if (smc.mHandleEventsAsynchronously && !unsafesmc)
            //{
            //    return true;
            //}

            if (smc == null)
                throw new NullReferenceException("smc == null");

            if (unsafesmc) 
            {
                smc.mHandleEventsAsynchronously = true;
            }

            if (actorName == null)
                return smc.mHandleEventsAsynchronously;

            StateMachineClient smcOrigin = smc;
            StateMachineClient smcBackup = smc;
            BridgeOrigin origin;

            for (int i = 0; i < (unsafesmc ? 300 : 15); i++)
            //while (true) //(origin != null && origin.mStateMachineClient != null)
            {
                origin = null;
                try
                {
                    if (smcOrigin.mActors != null)
                    {
                        IHasBridgeOrigin hasBridgeOrigin = null;
                        if (IsOpenDGSInstalled ? smcOrigin.mActors.ContainsKey(actorName) : niec_std.dictionary_contains_key(smcOrigin.mActors, actorName))
                        {
                            hasBridgeOrigin = IsOpenDGSInstalled ? smcOrigin.mActors[actorName] : niec_std.dictionary_get_value(smcOrigin.mActors, actorName);
                            if (hasBridgeOrigin != null && (origin = hasBridgeOrigin.BridgeOrigin) != null)
                            {
                                smcBackup = smcOrigin;
                                smcOrigin = origin.mStateMachineClient;

                                if (smcOrigin != null && !smcOrigin.mHandleEventsAsynchronously)
                                {
                                    if (unsafesmc) {
                                        //smc.mActors[actorName] = null;
                                        //smcBackup.mActors[actorName] = null;
                                        origin.mUseInterrupt = false;
                                        smcOrigin.mHandleEventsAsynchronously = true;
                                    }
                                    else return false;
                                }
                            }
                        }
                    }
                }
                catch (StackOverflowException) 
                {
                    throw;
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }

                if (origin == null || smcOrigin == smc || smcOrigin == smcBackup)
                    break;
            }
            return smc.mHandleEventsAsynchronously; // return true;
        }

        public static
            bool SMCIsGood(string actorName, StateMachineClient smc)
        {
            return SMCIsValid(actorName, false, smc) && SMCIsHandleEventsAsynchronously(actorName, false, smc);
        }

        public static
            bool SMCIsValid(string actorName, bool unsafesmc, StateMachineClient smc)
        {
            //if (smc.IsValid && !unsafesmc)
            //{
            //    return true;
            //}

            if (smc == null)
                throw new NullReferenceException("smc == null");

            //if (unsafesmc)
            //{
            //    smc.mHandleEventsAsynchronously = true;
            //}

            if (actorName == null)
                return smc.IsValid;

            StateMachineClient smcOrigin = smc;
            StateMachineClient smcBackup = smc;
            BridgeOrigin origin;

            for (int i = 0; i < (unsafesmc ? 300 : 15); i++)
            //while (true) //(origin != null && origin.mStateMachineClient != null)
            {
                origin = null;
                try
                {
                    if (smcOrigin.mActors != null)
                    {
                        IHasBridgeOrigin hasBridgeOrigin = null;
                        if (IsOpenDGSInstalled ? smcOrigin.mActors.ContainsKey(actorName) : niec_std.dictionary_contains_key(smcOrigin.mActors, actorName))
                        {
                            hasBridgeOrigin = IsOpenDGSInstalled ? smcOrigin.mActors[actorName] : niec_std.dictionary_get_value(smcOrigin.mActors, actorName);
                            if (hasBridgeOrigin != null && (origin = hasBridgeOrigin.BridgeOrigin) != null)
                            {
                                smcBackup = smcOrigin;
                                smcOrigin = origin.mStateMachineClient;

                                if ((smcOrigin != null && !smcOrigin.IsValid))
                                {
                                    if (NiecHelperSituation.kUnsafeSMCNULLSIM)
                                    {
                                        origin.PreviousOrigin = null;
                                    }
                                    if (unsafesmc)
                                    {
                                        if (IsOpenDGSInstalled)
                                        {
                                            smc.mActors[actorName] = null;
                                            smcBackup.mActors[actorName] = null;
                                        }
                                        else
                                        {
                                            niec_std.dictionary_set_value(smc.mActors, actorName, null);
                                            niec_std.dictionary_set_value(smcBackup.mActors, actorName, null);
                                        }
                                    }
                                    else return false;
                                }
                            }
                        }
                    }
                }
                catch (StackOverflowException)
                {
                    throw;
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }

                if (origin == null || smcOrigin == smc || smcOrigin == smcBackup)
                    break;
            }
            return smc.IsValid;
        }



        public static
          bool DoRunInteractionCustom<ICUSTSOM>(Sim currentTask, bool isDefinition)
        {
            if (currentTask == null)
                return false;

            var iq = currentTask.InteractionQueue;

            if (iq == null)// || iq.mInteractionList == null || iq.mInteractionList._items == null || iq.) 
                return false;

            var miList = iq.mInteractionList;

            if (miList == null)// || miList._items == null || miList._items.Length == 0) 
                return false;

            var NUT_miList = miList._items;

            if (NUT_miList == null || NUT_miList.Length == 0)
                return false;

            InteractionInstance iInteraction;
            if (iq.IsInteractionRunning())
            {
                iInteraction = NUT_miList[0];
                if (iInteraction != null && (iInteraction is ICUSTSOM || (isDefinition && iInteraction.InteractionDefinition is ICUSTSOM)))
                {
                    return true;
                }
             
            }
            var miList_count = miList.Count;

            for (int i = 0; i < NUT_miList.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                if (i >= miList_count)
                {
                    break;
                }

                iInteraction = NUT_miList[i];
                if (iInteraction == null)
                    continue;

                if (!(iInteraction is ICUSTSOM))
                {
                    if (!isDefinition || !(iInteraction.InteractionDefinition is ICUSTSOM))
                        continue;
                }

                CheckYieldingContext();

                // saved TaskContext ?
                NUT_miList[i] = CacheCClean__Data as CCnlean;

                miList_count = 0;

                NUT_miList = null;
                currentTask = null;
                iq = null;
                miList = null;

                bool r = false;

                CheckYieldingContext();

                try
                {
                    CheckACoreThrowNRaasErrorTrap();
                }
                catch (NMAntiSpyException)
                {
                    NiecTask.Perform(GetCurrentExecuteType(), delegate
                    {
                        _RunInteraction(iInteraction);
                    });
                    throw;
                }

                Simulator.Sleep(0);

                try
                {
                    try
                    {
                        r = _RunInteractionWithoutCleanUp(iInteraction);
                        return r;
                    }
                    finally { iInteraction.Cleanup(); }
                }
                catch (ExecutionEngineException) { CheckYieldingContext(); return r; }

            }
            return false;
        }
        // TODO: unprotected mono mscorlib 
        /// <summary>
        /// Run Interaction NHS
        /// </summary>
        /// <param name="currentTask">Actor == CurrentTask</param>
        /// <returns>retrun bool</returns>
        public static
            bool DoRunInteractionNHS (Sim currentTask) 
        {

            if (currentTask == null)
                return false;

            var iq = currentTask.InteractionQueue;

            if (iq == null)// || iq.mInteractionList == null || iq.mInteractionList._items == null || iq.) 
                return false;

            var miList = iq.mInteractionList;

            if (miList == null)// || miList._items == null || miList._items.Length == 0) 
                return false;

            var NUT_miList = miList._items;

            if (NUT_miList == null || NUT_miList.Length == 0) 
                return false;


            if (iq.IsInteractionRunning() && InteractionIsNiecHelperSituation(NUT_miList[0]))
                return AddInteractionToNeedRunNHSI(null) == -1;

            if (currentTask.ObjectId.mValue != ScriptCore.Simulator.Simulator_GetCurrentTaskImpl() || !Simulator.CheckYieldingContext(false))
                return false;

            //var iqList = iq.mInteractionList.ToArray();

            

            var miList_count = miList.Count;

            for (int i = 0; i < NUT_miList.Length; i++)
            {
                if (i == 0) { 
                    continue; 
                }

                if (i >= miList_count) {
                    break;
                }

                var iterin = NUT_miList[i];
                if (iterin == null || !InteractionIsNiecHelperSituation(iterin)) 
                    continue;

                


                try
                {
                    CheckYieldingContext();
                }
                catch (StackOverflowException)
                {
                    if (!IsOpenDGSInstalled)
                    {
                        if (NeedRunNHSI != null)
                        {
                            if (NeedRunNHSI._size < 0 || NeedRunNHSI._size > NeedRunNHSI._items.Length)
                                NeedRunNHSI._size = 0;

                            NeedRunNHSI._items[NeedRunNHSI._size] = iterin;
                            NeedRunNHSI._version++;
                            NeedRunNHSI._size++;
                        }
                        ThrowResetException(null);
                    }
                    throw;
                }



                // saved TaskContext ?
                NUT_miList[i] = CacheCClean__Data as CCnlean;

                //NUT_miList[i] = null;
                //try
                //{
                //    miList_count = 100;
                //    while (miList.Remove(null) && miList_count > 0) { miList_count--; }
                //}
                //catch (StackOverflowException)
                //{
                //    if (!IsOpenDGSInstalled)
                //        NFinalizeDeath.ThrowResetException(null);
                //    throw;
                //}
                //catch (ResetException) { throw; }
                //catch { List_FastClearEx(ref iq.mInteractionList); }


                






                miList_count = 0;

                NUT_miList = null;
                currentTask = null;
                iq = null;
                miList = null;

                bool r = false;

                CheckYieldingContext();

                try
                {
                    CheckACoreThrowNRaasErrorTrap();
                }
                catch (ResetException)
                {
                    if (NeedRunNHSI != null)
                    {
                        if (NeedRunNHSI._size < 0 || NeedRunNHSI._size > NeedRunNHSI._items.Length)
                            NeedRunNHSI._size = 0;

                        NeedRunNHSI._items[NeedRunNHSI._size] = iterin;
                        NeedRunNHSI._version++;
                        NeedRunNHSI._size++;
                    }

                    try
                    {
                        throw;
                    }
                    catch (ExecutionEngineException) 
                    {
                        ThrowResetException(null);
                        throw;
                    }
                }
                catch (StackOverflowException)
                {
                    if (!IsOpenDGSInstalled)
                    {
                        if (NeedRunNHSI != null)
                        {
                            if (NeedRunNHSI._size < 0 || NeedRunNHSI._size > NeedRunNHSI._items.Length)
                                NeedRunNHSI._size = 0;

                            NeedRunNHSI._items[NeedRunNHSI._size] = iterin;
                            NeedRunNHSI._version++;
                            NeedRunNHSI._size++;
                        }
                        if (NiecRunCommand.isstsleepmax)
                        {
                            CheckYieldingContext();
                            Simulator.Sleep(uint.MaxValue);
                            return false;
                        }
                        ThrowResetException(null);
                    }
                    throw;
                }
                catch (NMAntiSpyException)
                {
                    NiecTask.Perform(GetCurrentExecuteType(), delegate
                    {
                        _RunInteraction(iterin);
                    });
                    throw;
                }

                attt_DoRunInteractionNHS++;

                if (attt_DoRunInteractionNHS > 4)
                {
                    attt_DoRunInteractionNHS = 0;

                    bool isOnSccen = ScriptCore.World.World_IsObjectOnScreenImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl());
                    if (GetCurrentExecuteType() == ScriptExecuteType.Task)
                        Simulator.Sleep(isOnSccen ? 105u : 500u);
                    else
                        Simulator.Sleep(isOnSccen ? 0u : 105u);
                }


                try
                {
                    //if (IsOpenDGSInstalled)
                    //{
                    //    if (NiecHelperSituation.RuningDeadSimList != null)
                    //        NiecHelperSituation.RuningDeadSimList.Remove(iterin.Target as Sim);
                    //}
                    //else
                    //{
                    //    NiecTask.Perform(delegate
                    //    {
                    //        if (NiecHelperSituation.RuningDeadSimList != null)
                    //            NiecHelperSituation.RuningDeadSimList.Remove(iterin.Target as Sim);
                    //    });
                    //}

                    // GC Bug
                    if (iterin == null) 
                        return false;

                    if (NiecHelperSituation.RuningDeadSimList != null)
                        niec_std.list_remove(NiecHelperSituation.RuningDeadSimList, iterin.Target as Sim);
                }
                catch (StackOverflowException)
                {
                    if (!IsOpenDGSInstalled)
                    {
                        
                        if (NeedRunNHSI != null)
                        {
                            if (NeedRunNHSI._size < 0 || NeedRunNHSI._size > NeedRunNHSI._items.Length)
                                NeedRunNHSI._size = 0;

                            NeedRunNHSI._items[NeedRunNHSI._size] = iterin;
                            NeedRunNHSI._version++;
                            NeedRunNHSI._size++;
                        } 
                        if (NiecRunCommand.isstsleepmax)
                        {
                            CheckYieldingContext();
                            Simulator.Sleep(uint.MaxValue);
                            return false;
                        }
                        ThrowResetException(null);
                    }
                    throw; 
                }
                catch (ResetException)
                { throw; }
                catch { }
                
                Simulator.Sleep(0);

                try
                {
                    if (!IsOpenDGSInstalled && (NiecRunCommand.forcefastdoinhs))// || Random_CoinFlip()))
                    {
                        return (bool)NiecTask.CreateWaitPerformWithExecuteType(GetCurrentExecuteType(), delegate
                        {
                            bool b;
                            do
                            {
                                b = _RunInteraction(iterin);
                                Simulator.Sleep(0);
                            }
                            while (b && Random_Chance(25) && NiecHelperSituation.__acorewIsnstalled__);
                            NiecTask.GetCurrentNiecTask().WaitPerform_DoneResult = b; return;
                        }).WaitingCanThrow();
                    }
                    try
                    {
                        r = _RunInteractionWithoutCleanUp(iterin);
                        return r;
                    }
                    finally { iterin.Cleanup(); }
                }
                catch (TargetInvocationException e) {
                    var t = MsCorlibModifed_GetExLists();
                    if (t != null)
                    {
                        t._items[t._size] = e;
                        t._size++;
                        t._version++;
                    }
                    CheckYieldingContext(); 
                    throw; 
                }
                //catch (ResetException) { throw; }
                catch (StackOverflowException)
                {
                    if (!IsOpenDGSInstalled)
                    {
                        if (NiecRunCommand.isstsleepmax)
                        {
                            Simulator.Sleep(uint.MaxValue);
                            return false;
                        }
                        ThrowResetException(null);
                    }
                    throw;
                }
                catch (ExecutionEngineException) { CheckYieldingContext(); return r; }

            }
            return false;
        }


        public static bool SChelsea = false;
        //public unsafe static int asdr(void* sf, char** foais) { return 0; }
        public static List<SimDescription> OpenDGS_GetNiecSimDescriptions()
        {
            List<SimDescription> l = ListCollon.NiecSimDescriptions;
            if (l  == null) return new List<SimDescription>();

            if (l.Contains(null))
                foreach (var item in l.ToArray())
                    if (item == null)
                       l.Remove(item);
            
            return l;//new List<SimDescription>(l);
        }

        public static bool OpenDGS_CustomKill(Sim target, SimDescription.DeathType deathType, GameObject obj, bool playDeathAnim)
        {
             return KillPro.FastKill(target, deathType, obj, playDeathAnim, false);
            //return false;
        }




        /*
        public static CASMode XGetMode(SimDescription sim, ref OutfitCategories startCategory, ref int startIndex, ref CASBase.EditType editType)
        {
            
            return CASMode.Full;
        }

        public static void EditCASNRaas(SimDescription ths)
        {

        }
        */

        public static void SimDescDispose_Internal(SimDescription ths, bool clearInstantiatedBit, bool keepPartnerGenealogy, bool addMiniSim, bool fromPostWorldInit, bool destroyAging)
        {

            /*
            Function runf = null;

            if (AssemblyCheck.IsInstalled("DGSCore"))
            {
                Type type = Type.GetType("DGSCore.Override.CustomOverride, DGSCore");
                if (type != null)
                {
                    MethodInfo infao = type.GetMethod("SimDescDispose_Internal");
                    if (infao != null)
                        runf = (Function)Delegate.CreateDelegate((typeof(Function)), infao);
                }
            }
            runf();

            */

            /*
            try
            {
                if (AssemblyCheck.IsInstalled("NiecMod"))
                {
                    Type type = Type.GetType("NiecMod.Nra.NFinalizeDeath, NiecMod");
                    if (type != null)
                    {
                        MethodInfo infao = type.GetMethod("SimDescDispose_Internal");
                        if (infao != null)
                            infao.Invoke(null, (new object[] { this, clearInstantiatedBit, keepPartnerGenealogy, addMiniSim, fromPostWorldInit, destroyAging }));
                        return;
                    }
                }
            }
            catch (Exception)
            { }
            
            */
            if (ths == null) return;
            try
            {
                if (clearInstantiatedBit)
                {
                    MiniSimDescription miniSimDescription = MiniSimDescription.Find(ths.SimDescriptionId);
                    if (miniSimDescription != null)
                    {
                        miniSimDescription.Instantiated = false;
                    }
                    if (NiecHelperSituation.__acorewIsnstalled__)
                    {
                       SafeCall(() => { EventTracker.SendEvent(new DnPSubjectDestroyedEvent(null, ths, true)); });
                    }
                    else
                        EventTracker.SendEvent(new DnPSubjectDestroyedEvent(null, ths, true));
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (!GameStates.IsGameShuttingDown && addMiniSim)
                {
                    MiniSimDescription.AddMiniSim(ths);
                }
                else
                {
                    MiniSimDescription.RemoveMSD(ths.SimDescriptionId);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                 KillPro.RemoveSimDescriptionRelationships(ths);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                ths.mIsValidDescription = false;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (destroyAging)
                {
                    ths.AgingEnabled = false;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (ths.CelebrityManager != null)
                {
                    ths.CelebrityManager.OnDispose();
                    ths.CelebrityManager = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }


            try
            {
                if (ths.CareerManager != null)
                {
                    ths.CareerManager.LeaveAllJobs(Career.LeaveJobReason.kDebug);
                    ths.CareerManager = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                ths.ClearPregnancyData();
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                ths.ClearMaternityOutfits();
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (ths.Household != null)
                {
                    ths.Household.Remove(ths);
                    ths.mHousehold = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (ths.CreatedSim != null)
                {
                    try
                    {
                        ths.CreatedSim.Destroy();
                    }
                    catch (Exception)
                    {
                        ths.CreatedSim.mPosture = ths.CreatedSim.Standing;
                        //ths.CreatedSim.Destroy();
                        NFinalizeDeath.ForceDestroyObject(ths.CreatedSim);
                    }
                    
                    ths.CreatedSim = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (ths.Service != null)
                {
                    ths.Service.EndService(ths);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }


            try
            {
                if (ths.mVirtualLotHome != null)
                {
                    ths.mVirtualLotHome.VirtualMoveOut(ths);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }


            try
            {
                if (ths.Partner != null && (GameStates.IsTravelling || keepPartnerGenealogy))
                {
                    ths.Partner.mPartner = null;
                    ths.mPartner = null;
                }
                else
                {
                    ths.ClearPartner();
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }


            try
            {
                if (clearInstantiatedBit)
                {
                    if (GameStates.IsTravelling && (Sims3.Gameplay.UI.PieMenu.sSimHead == null || Sims3.Gameplay.UI.PieMenu.sSimHead.PieMenuHeadSimDescription != ths))
                    {
                        if (fromPostWorldInit)
                        {
                            ths.AssertClearOutfitsUnsafeWorks();
                        }
                        else
                        {
                            ths.ClearOutfits(false);
                        }
                    }
                    else if (!GameStates.IsGameShuttingDown && (ths.mOutfits != null || ths.mMaternityOutfits != null))
                    {
                        ths.ClearOutfitsExcept(OutfitCategories.Everyday, true);
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            AlarmManager alm = AlarmManager.Global;
            try
            {
                EventTracker.SendEvent(new SimDescriptionEvent(EventTypeId.kSimDescriptionDisposed, ths));
                if (alm != null)
                alm.OnDispose(ths);
            }
            catch
            { }
            try
            {
                if (alm != null)
                alm.OnDispose(ths);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            try
            {
                if (ths.mPackingDescriptionTask != null)
                {
                    Simulator.DestroyObject(ths.mPackingDescriptionTask.ObjectId);
                    ths.mPackingDescriptionTask = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }


            try
            {
                if (SimDescription.sLoadedSimDescriptions != null)
                {
                    SimDescription.sLoadedSimDescriptions.Remove(ths);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (ths.mGenealogy != null)
                {
                    ths.Genealogy.ClearSimDescription();
                    ths.mGenealogy = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            //if (clearInstantiatedBit && !keepPartnerGenealogy && !addMiniSim && !fromPostWorldInit && destroyAging)
            try
            {
                if (ths.AssignedRole != null)
                {
                    ths.AssignedRole.RemoveSimFromRole();
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (ths.PetManager != null)
                {
                    ths.PetManager.Dispose();
                    ths.PetManager = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

            try
            {
                if (ths.TraitChipManager != null)
                {
                    ths.TraitChipManager.Dispose();
                    ths.TraitChipManager = null;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }










        }

#if unused
        public static ListenerAction OnSelectedSimChanged(HudModel ths ,Event e)
        {
            Job job = null;
            if (ths.mSavedCurrentSim != null)
            {
                if (ths.mSavedCurrentSim.SkillManager != null)
                {
                    ths.mSavedCurrentSim.SkillManager.SkillsChanged -= ths.OnSkillChanged;
                }
                if (ths.mSavedCurrentSim.SocialComponent != null)
                {
                    ths.mSavedCurrentSim.SocialComponent.SocializingUICallback -= ths.OnRelationshipChanged;
                }
                if (ths.mSavedCurrentSim.CareerManager != null)
                {
                    ths.mSavedCurrentSim.CareerManager.CareerUpdated -= ths.OnCareerUpdated;
                    ths.mSavedCurrentSim.CareerManager.UpdateJobTracker -= ths.OnJobTrackingUpdate;
                    ths.mSavedCurrentSim.CareerManager.CareerPerformanceChanged -= ths.OnCareerPerformanceChanged;
                    Occupation occupation = ths.mSavedCurrentSim.Occupation;
                    if (occupation != null)
                    {
                        job = occupation.CurrentJob;
                    }
                }
                if (ths.mSavedCurrentSim.OccultManager != null)
                {
                    ths.mSavedCurrentSim.OccultManager.OccultUpdated -= ths.OnOccultUpdated;
                }
                if (ths.mSavedCurrentSim.TraitManager != null)
                    ths.mSavedCurrentSim.TraitManager.OnRewardTraitsChanged -= ths.OnRewardTraitsChanged;
                if (ths.mSavedCurrentSim.SimDescription != null)
                {
                    ths.mSavedCurrentSim.SimDescription.OnLifetimeHappinessChanged -= ths.OnLifetimePointsChanged;
                    ths.mSavedCurrentSim.SimDescription.OnTraitToDisplayUpdated -= ths.OnTraitUseUpdated;
                }
                if (ths.mSavedCurrentSim.InteractionQueue != null)
                {
                    ths.mSavedCurrentSim.InteractionQueue.QueueChanged -= ths.OnInteractionQueueDirtied;
                }

                mSavedCurrentSim.PostureChanged -= OnPostureChanged;
            }
            else
            {
                HudController.EnableBuildMode = InWorldState.CanEnableBuildBuy();
                HudController.EnableBuyMode = InWorldState.CanEnableBuildBuy();
            }
            mSavedCurrentSim = (e.Actor as Sim);
            if (e.Actor != null)
            {
                if (mSavedCurrentSim.SkillManager != null)
                    mSavedCurrentSim.SkillManager.SkillsChanged += OnSkillChanged;
                if (mSavedCurrentSim.SocialComponent != null)
                    mSavedCurrentSim.SocialComponent.SocializingUICallback += OnRelationshipChanged;
                if (mSavedCurrentSim.CareerManager != null)
                {
                    mSavedCurrentSim.CareerManager.CareerUpdated += OnCareerUpdated;
                    mSavedCurrentSim.CareerManager.UpdateJobTracker += OnJobTrackingUpdate;
                    mSavedCurrentSim.CareerManager.CareerPerformanceChanged += OnCareerPerformanceChanged;
                }
                if (mSavedCurrentSim.OccultManager != null)
                    mSavedCurrentSim.OccultManager.OccultUpdated += OnOccultUpdated;
                Occupation occupation2 = mSavedCurrentSim.Occupation;
                if (occupation2 != null)
                {
                    occupation2.UpdateJobAudio(job);
                }
                else if (job != null)
                {
                    job.StopMusic();
                }
                if (mSavedCurrentSim.TraitManager != null)
                    mSavedCurrentSim.TraitManager.OnRewardTraitsChanged += OnRewardTraitsChanged;
                if (mSavedCurrentSim.SimDescription != null)
                {
                    mSavedCurrentSim.SimDescription.OnLifetimeHappinessChanged += OnLifetimePointsChanged;
                    mSavedCurrentSim.SimDescription.OnTraitToDisplayUpdated += OnTraitUseUpdated;
                }
                if (mSavedCurrentSim.InteractionQueue != null)
                {
                    mSavedCurrentSim.InteractionQueue.QueueChanged += OnInteractionQueueDirtied;
                }
                mSavedCurrentSim.PostureChanged += OnPostureChanged;
                OnRewardTraitsChanged();
                OnLifetimePointsChanged();
                bool flag = false;
                Household household = e.Actor.Household;
                if (mCurrentHousehold != household)
                {
                    if (mCurrentHousehold != null)
                    {
                        mCurrentHousehold.HouseholdSimsChanged -= OnHouseholdSimChanged;
                        mCurrentHousehold.FamilyFundsChanged -= OnFamilyFundsChanged;
                        mCurrentHousehold.AncientCoinCountChanged -= OnFamilyAncientCoinCountChanged;
                    }
                    mCurrentHousehold = household;
                    flag = true;
                    if (mCurrentHousehold != null)
                    {
                        mCurrentHousehold.HouseholdSimsChanged += OnHouseholdSimChanged;
                        mCurrentHousehold.FamilyFundsChanged += OnFamilyFundsChanged;
                        mCurrentHousehold.AncientCoinCountChanged += OnFamilyAncientCoinCountChanged;
                    }
                }
                if (flag)
                {
                    ClearSimList();
                    if (mCurrentHousehold != null && mCurrentHousehold.CurrentMembers != null)
                    {
                        int count = mCurrentHousehold.CurrentMembers.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Household.Member member = mCurrentHousehold.CurrentMembers[i];
                            if (!Household.RoommateManager.IsNPCRoommate(member.mSimDescription))
                            {
                                SimInfo simInfo = CreateSimInfo(member.mSimDescription);
                                if (simInfo != null)
                                {
                                    mSimList.Add(simInfo);
                                }
                            }
                        }
                        mSimList.Sort();
                    }
                }
                else
                {
                    foreach (SimInfo mSim in mSimList)
                    {
                        if (mSim != null && e.Actor != null)
                        {
                            mSim.mIsCurrent = (mSim.mGuid == e.Actor.ObjectId);
                        }
                    }
                }
                if (this.SimChanged != null)
                {
                    this.SimChanged(e.Actor.ObjectId);
                }


                if (this.HouseholdChanged != null && flag)
                {
                    this.HouseholdChanged(Sims3.UI.Hud.HouseholdEvent.NewHousehold, ObjectGuid.InvalidObjectGuid);
                }
                if (this.CurrentSimInventoryOwnerChanged != null)
                {
                    this.CurrentSimInventoryOwnerChanged(CurrentSimInventory);
                }
                IPhoneFuture phoneFuture = e.Actor.Inventory.Find<IPhoneFuture>();
                IPhoneSmart phoneSmart = e.Actor.Inventory.Find<IPhoneSmart>();
                if (phoneFuture != null)
                {
                    UpdateCellPhoneIcon(PhoneType.FuturePhone, (int)phoneSmart.GetPhoneSkin(), phoneSmart.IsBroken);
                }
                else if (phoneSmart != null)
                {
                    UpdateCellPhoneIcon(PhoneType.SmartPhone, (int)phoneSmart.GetPhoneSkin(), phoneSmart.IsBroken);
                }
                else
                {
                    UpdateCellPhoneIcon(PhoneType.CellPhone, 0, false);
                }
            }
            else
            {
                ClearSimList();
                if (this.SimChanged != null)
                {
                    this.SimChanged(ObjectGuid.InvalidObjectGuid);
                }
                if (this.HouseholdChanged != null)
                {
                    this.HouseholdChanged(Sims3.UI.Hud.HouseholdEvent.NewHousehold, ObjectGuid.InvalidObjectGuid);
                }
                if (this.CurrentSimInventoryOwnerChanged != null)
                {
                    this.CurrentSimInventoryOwnerChanged(null);
                }
                OnRewardTraitsChanged();
                OnLifetimePointsChanged();
                if (mCurrentHousehold != null)
                {
                    mCurrentHousehold.HouseholdSimsChanged -= OnHouseholdSimChanged;
                    mCurrentHousehold.FamilyFundsChanged -= OnFamilyFundsChanged;
                    mCurrentHousehold.AncientCoinCountChanged -= OnFamilyAncientCoinCountChanged;
                }
                mCurrentHousehold = null;
            }
            return ListenerAction.Keep;
        }
#endif


        public static Sim HouseholdMembersToSim(Household household, bool needTeenOrAbove, bool needForceSelectActor)
        {
            if (household == null) 
                return null;

            Household.Members currentMembers = household.mMembers;
            if (currentMembers == null) 
                return null;

            RemoveNullForHouseholdMembers(household);

            Sim newSim = null;

            foreach (SimDescription simDesc in currentMembers.mAllSimDescriptions)
            {
                var createdSim = simDesc.CreatedSim;
                if (createdSim != null && !simDesc.IsNeverSelectable)
                {
                    if (needTeenOrAbove && (simDesc.IsPet || !simDesc.TeenOrAbove))
                        continue;
                    newSim = createdSim;
                    break;
                }
            }

            if (newSim != null && needForceSelectActor)
                ActiveActor = newSim;
           
            return newSim;
        }





        public static void YieldHouseholdCleanse(Household house, bool noCheck, bool safe) {
            if (house == null) 
                return;

            NiecTask.Perform(delegate { HouseholdCleanse(house, noCheck, safe); });
        }

        public static List<SimDescription> NiecHouseholdsAll(Household house)
        {
            if (house == null || house.mMembers == null)
            {
                return new List<SimDescription>();
            }
            return house.AllSimDescriptions;
        }
        public static SimDescription[] NiecHouseholdsAllPro(Household house)
        {
            if (house == null || house.mMembers == null || house.AllSimDescriptions == null)
            {
                return new SimDescription[0];
            }
            return house.AllSimDescriptions.ToArray();
        }
        public unsafe static bool StringEqualsHelper(string strA, string strB)
        {
            //if (strA == strB) 
            //    return true;
            if (strA == null || strB == null)
                return false;
            int num = strA.Length;
            if (num != strB.Length)
            {
                return false; 
            }
            fixed (char* ptr = strA)
            {
                fixed (char* ptr3 = strB)
                {
                    char* ptr2 = ptr;
                    char* ptr4 = ptr3;
                    while (num >= 10 && *(int*)ptr2 == *(int*)ptr4 && *(int*)(ptr2 + 2) == *(int*)(ptr4 + 2) && *(int*)(ptr2 + 4) == *(int*)(ptr4 + 4) && *(int*)(ptr2 + 6) == *(int*)(ptr4 + 6) && *(int*)(ptr2 + 8) == *(int*)(ptr4 + 8))
                    {
                        ptr2 += 10;
                        ptr4 += 10;
                        num -= 10;
                    }
                    while (num > 0 && *(int*)ptr2 == *(int*)ptr4)
                    {
                        ptr2 += 2;
                        ptr4 += 2;
                        num -= 2;
                    }
                    return num <= 0 || strA == strB;
                }
            }
        }
        public static void HouseholdCleanse(Household house, bool noCheck)
        {
            HouseholdCleanse(house, noCheck, true);
        }
        public static void HouseholdCleanse(Household house, bool noCheck, bool safe)
        {
            if (house == null) return;
            if (safe && house.HasBeenDestroyed) return;
            try
            {
                if (house == ActiveHousehold) return;
                try
                {
                    if (house == Household.ActiveHousehold) return;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                {}
                if (!noCheck)
                {

                    
                    if (house.IsSpecialHousehold) return;
                }

            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            
            try
            {

                //ObjectGuid sad = house.ObjectId;

                Lot HouseHome = house.LotHome;

                foreach (SimDescription sim in NiecHouseholdsAll(house).ToArray())
                {
                    SimDescCleanse(sim, true, safe);
                }

                try
                {
                    foreach (var item in SC_GetObjects<Bill>())
                    {
                        if (item.OriginatingHousehold == house)
                        {
                            item.OriginatingHousehold = null;
                            item.DestroyBill(false);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    if (house == PlumbBob.sCurrentNonNullHousehold) 
                        PlumbBob.sCurrentNonNullHousehold = null;

                    if (house == Household.sNpcHousehold)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            Household.sNpcHousehold = null;
                        else
                        {
                            Household.sNpcHousehold = Household.Create(true);
                            Household.sNpcHousehold.Name = "World/Household:ServiceNpcFamilyName";
                        }
                    }

                    if (house == Household.sPetHousehold)
                    {
                        PetPoolManager.sPetPoolManager = new Dictionary<PetPoolType, PetPool>();
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            Household.sPetHousehold = null;
                        else if (GameUtils.IsInstalled(ProductVersion.EP5))
                        {
                            Household.sPetHousehold = Household.Create(true);
                            Household.sPetHousehold.Name = "Pet Household";
                        }
                    }

                    if (house == Household.sAlienHousehold)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            Household.sAlienHousehold = null;
                        else if (GameUtils.IsInstalled(ProductVersion.EP8))
                        {
                            Household.sAlienHousehold = Household.Create(true);
                            Household.sAlienHousehold.Name = "Alien Household";
                        }
                    }

                    if (house == Household.sMermaidHousehold)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            Household.sMermaidHousehold = null;
                        else if (GameUtils.IsInstalled(ProductVersion.EP10))
                        {
                            Household.sMermaidHousehold = Household.Create(true);
                            Household.sMermaidHousehold.Name = "Mermaid Household";
                        }
                    }

                    if (house == Household.sPreviousTravelerHousehold)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            Household.sPreviousTravelerHousehold = null;
                        else if (GameUtils.IsOnVacation() || GameStates.IsEditingOtherTown)
                        {
                            Household.sPreviousTravelerHousehold = Household.Create(true);
                            Household.sPreviousTravelerHousehold.Name = "Previous Traveler Household";
                        }
                    }

                    if (house == Household.sServobotHousehold)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            Household.sServobotHousehold = null;
                        else if (GameUtils.IsInstalled(ProductVersion.EP11))
                        {
                            Household.sServobotHousehold = Household.Create(true);
                            Household.sServobotHousehold.Name = "Servo Bot Household";
                        }
                    }

                    if (house == Household.sTouristHousehold)
                    {
                        //if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        //    Household.sTouristHousehold = null;
                        //else
                        //{
                        //    Household.sTouristHousehold = Household.Create(true);
                        //    Household.sTouristHousehold.mName = "Tourist Household";
                        //}
                        Household.sTouristHousehold = null;
                    }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                

                try
                {
                    house.Destroy();
                    house.Dispose();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                {}
               
                
                
                if (HouseHome != null)
                {
                    HouseHome.mHousehold = null;

                }
                if (!safe)
                {
                    try
                    {
                        house.mbInited = false;
                        house.mAncientCoinCount = 0;
                        house.mBioText = null;
                        house.mFamilyFunds = 0;
                        house.mDelinquentFunds = 0;
                        house.mHouseholdId = 0;
                        house.Name = null;

                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        {
                            if (house.mMembers.mAllSimDescriptions != null)
                                house.mMembers.mAllSimDescriptions.Clear();
                            if (house.mMembers.mPetSimDescriptions != null)
                                house.mMembers.mPetSimDescriptions.Clear();
                            if (house.mMembers.mSimDescriptions != null)
                                house.mMembers.mSimDescriptions.Clear();
                            house.mMembers = null;
                        }
                        else
                        {
                            house.mMembers.mAllSimDescriptions.Clear();
                            house.mMembers.mPetSimDescriptions.Clear();
                            house.mMembers.mSimDescriptions.Clear();
                            house.mMembers = new Household.Members();
                        }
                        house.mVirtualLotHome = null;
                        house.mVirtualLotId = 0;
                        house.mHouseholdTelemetryId = 0;
                        house.DoorbellSound = null;
                        
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                }
                
                house.mLotHome = null;
                house.mLotId = 0;

                try
                {
                    if (Household.sHouseholdList != null && Household.sHouseholdList.Contains(house))
                        Household.sHouseholdList.Remove(house);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    // Do Nothing 
                } 
               // if (!safe)
               //     house.mbInited = false;
                //if (!safe)
                //    Simulator.DestroyObject(sad);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { 
                // Do Nothing
            }
        }
        public static void HouseholdCleanse(Household house)
        {
            HouseholdCleanse(house, false, true);
        }
        /*
        public:
            void NFinalizeDeath::HouseholdCleanse(Household* house, SimDescription* NoSimDesc) {
            if (house == null) return;
            try
            {
                for each (SimDescription sim in new List<SimDescription>(NiecHouseholdsAll(house)))
                {
                    if (sim != NoSimDesc)
                        SimDescCleanse(sim, true);
                }

                house->Destroy();
                house->Dispose();
            }
            catch (...) 
            { }
         }
         */
        public static void  HouseholdCleanse (Household house, SimDescription NoSimDesc)
        {
            if (house == null) return;
            try
            {
                
                foreach (SimDescription sim in new List<SimDescription>(NiecHouseholdsAll(house)))
                {
                    if (sim != NoSimDesc)
                        SimDescCleanse(sim, true);
                }

                house.Destroy();
                house.Dispose();
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
        }

        public static void OpenDGS_FixExtKillSim(InteractionInstance ExtKillSimNiec, SimDescription.DeathType SimDeathType, bool CancelDeath, bool PlayDeathAnimation)
        {
            if (!(ExtKillSimNiec is ExtKillSimNiec)) return;
            (ExtKillSimNiec as NiecMod.Interactions.ExtKillSimNiec).PlayDeathAnimation = PlayDeathAnimation;
            (ExtKillSimNiec as NiecMod.Interactions.ExtKillSimNiec).simDeathType = SimDeathType;
            (ExtKillSimNiec as NiecMod.Interactions.ExtKillSimNiec).CancelDeath = CancelDeath;
            
            
        }

        public static List<SimDescription> EverySimDescriptionProX_()
        {
            var list = new List<SimDescription>(250);
            if (Household.sHouseholdList == null)
                return list;

            foreach (var household in Household.sHouseholdList)
            {
                //if (!household.IsPreviousTravelerHousehold)
                //{
                //    list.AddRange(sHousehold.AllSimDescriptions);
                //}

                if (household == null || household.IsPreviousTravelerHousehold)
                    continue;

                var mem = household.mMembers;
                if (mem == null) 
                    continue;

                var allmembers = mem.mAllSimDescriptions;
                if (allmembers == null) 
                    continue;

                foreach (var item in allmembers)
                {
                    if (item == null) 
                        continue;
                    list.Add(item);
                }
            }
            return list;
        }

        public static SimDescription OpenDGS_GetNullSimSimDescription()
        {
            /*
            try
            {
                if (ListCollon.NullSimSimDescription == null)
                {
                    foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
                    {
                        if (item == null) continue;
                        if (item.IsValidDescription && item.IsValid) continue;
                        ListCollon.NullSimSimDescription = item;
                        break;
                    } 
                }
                if (ListCollon.NullSimSimDescription == null)
                {
                    ListCollon.NullSimSimDescription = new SimDescription();
                    ListCollon.NullSimSimDescription.mIsValidDescription = false;
                }
            }
            catch
            {
                // Nothing
            }
            
            return ListCollon.NullSimSimDescription;*/

            try
            {
                return NiecMod.Helpers.Create.NiecNullSimDescription(false, true);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            {return ListCollon.NullSimSimDescription;}
            
        }

        public static InteractionInstance OpenDGS_CreateExtKillSim(Sim Actor, SimDescription.DeathType SimDeathType, bool CancelDeath, bool PlayDeathAnimation)
        {
            InteractionInstance mKillSim = null;
             mKillSim = NiecMod.Interactions.ExtKillSimNiec.Singleton.CreateInstance(Actor, Actor, KillNiec.KillSimNiecX.DGSAndNonDGSPriority(), false, true) as NiecMod.Interactions.ExtKillSimNiec;
            (mKillSim as NiecMod.Interactions.ExtKillSimNiec).PlayDeathAnimation = PlayDeathAnimation;
            (mKillSim as NiecMod.Interactions.ExtKillSimNiec).simDeathType = SimDeathType;
            (mKillSim as NiecMod.Interactions.ExtKillSimNiec).CancelDeath = CancelDeath;
            try
            {
                (mKillSim as NiecMod.Interactions.ExtKillSimNiec).mForceKillGrim = (Actor.Service is GrimReaper);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            return mKillSim;
        }

        public static void OpenDGS_CreateHelperNra(Sim Actor, SimDescription SimDescription, SimDescription.DeathType SimDeathType)
        {
            try
            {

                HelperNra helperNra = new HelperNra();

                //helperNra = HelperNra;

                helperNra.mSim = Actor;

                helperNra.mSimdesc = SimDescription;

                helperNra.mdeathtype = SimDeathType;

                helperNra.this_alarm = AlarmManager.Global.AddAlarm(1f, TimeUnit.Days, new AlarmTimerCallback(helperNra.CheckKillSimNotUrnstonePro), "Esoiax44", AlarmType.AlwaysPersisted, null);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception exception)
            { NiecException.WriteLog("OpenDGS_CreateHelperNra" + NiecException.NewLine + NiecException.LogException(exception), true, true, false); }
        }

        public static void OpenDGS_SimDisposePro(IMiniSimDescription Me, bool Clear, bool SafeError)
        {
            SimDescCleanse(Me, Clear, SafeError);
        }

        public static void OpenDGS_SimDispose(IMiniSimDescription me, bool clear)
        {
            Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
            {
                SimDescCleanse(me, clear);
                /*
                if (LoadingScreenController.Instance == null || !LoadingScreenController.IsLayoutLoaded())
                    SimDescCleanse(me, clear);
                else 
                {
                    HelperNra nra = new HelperNra();
                    SimDescription sim = me as SimDescription;
                    try
                    {
                        if (sim != null && sim.CreatedSim != null)
                        {
                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(sim.CreatedSim);
                            sim.CreatedSim.Destroy();
                        }
                    }
                    catch (Exception ex)
                    {
                        NiecException.WriteLog(" OpenDGS_SimDispose Destory Sim Error :" + NiecException.NewLine + NiecException.LogException(ex), true, false, false);
           
                    }
                    
                    nra.mSimdesc = sim;
                    if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap"))
                        nra.this_alarm = AlarmManager.Global.AddAlarm(1f, TimeUnit.Days, new AlarmTimerCallback(nra.OpenDGS_UnLoadSimDispose), "OpenDGS_UnLoadSimDispose", AlarmType.AlwaysPersisted, null);
                    else
                        nra.this_alarm = AlarmManager.Global.AddAlarm(3f, TimeUnit.Minutes, new AlarmTimerCallback(nra.OpenDGS_UnLoadSimDispose), "OpenDGS_UnLoadSimDispose", AlarmType.AlwaysPersisted, null);
                }
                 */
            });
            return;
        }

        public static T[] SC_GetObjects<T>() where T : class // fast code
        {
            //Array objects = ScriptCore.Queries.Query_GetObjects(typeof(T));
            //if (objects != null)
            //{
            //    return objects as T[];
            //}
            //return new T[0];
            return (ScriptCore.Queries.Query_GetObjects(typeof(T)) as T[] ?? new T[0]);
        }

        public static T[] SC_GetObjectsOnLot<T>(Lot targetLot) where T : class
        {
            if (targetLot == null) 
                return new T[0];

            return (ScriptCore.Queries.Query_GetObjectsOnLot(typeof(T), targetLot.LotId, -1) as T[] ?? new T[0]);
        }

        public static T[] SC_GetObjectsOnLotID<T>(ulong lotID, int roomID = -1) where T : class // fast code
        {
            return (ScriptCore.Queries.Query_GetObjectsOnLot(typeof(T), lotID, roomID) as T[] ?? new T[0]);
        }

        //internal static Assembly[] EA_Assemblies = null;
        //
        //internal static Assembly[] EAStore_Assemblies = null;


        // Fix that mscorlib Bug or Mono Bug 
        // StackTrace
        // at   UI.TestAssertAssEqualsAss()
        // Assembly uiAssembly = Assembly.FindAssembly("UI");
        // Assembly uiAssembly2 = Assembly.GetCallingAssembly();
        // Bad: Assert(uiAssembly == uiAssembly2, "uiAssembly == uiAssembly2 failed"); <--- Mono Bug?
        // Good: Assert(uiAssembly._mono_assembly == uiAssembly2._mono_assembly, "uiAssembly == uiAssembly2 failed");
        internal static IntPtr[] EA_Assemblies = null;

        internal static IntPtr[] EAStore_Assemblies = null;

        public static void CacheAssemblyEA()
        {
            //List<Assembly> atemp = null;
            //if (EA_Assemblies == null)
            //{
            //
            //    if (atemp == null)
            //        atemp = new List<Assembly>();
            //
            //    atemp.Add(AssemblyCheckByNiec.FindAssemblyPro("Sims3GameplaySystems"));
            //    atemp.Add(AssemblyCheckByNiec.FindAssemblyPro("Sims3StoreObjects"));
            //    atemp.Add(AssemblyCheckByNiec.FindAssemblyPro("Sims3GameplayObjects"));
            //    atemp.Add(AssemblyCheckByNiec.FindAssemblyPro("UI"));
            //    atemp.Add(AssemblyCheckByNiec.FindAssemblyPro("ScriptCore"));
            //    atemp.Add(AssemblyCheckByNiec.FindAssemblyPro("SimIFace"));
            //    atemp.Add(AssemblyCheckByNiec.FindAssemblyPro("Sims3Metadata"));
            //
            //    while (atemp.Remove(null)) { }
            //
            //    EA_Assemblies = atemp.ToArray();
            //    atemp.Clear();
            //
            //    
            //}
            //if (EAStore_Assemblies == null)
            //{
            //
            //    if (atemp == null)
            //        atemp = new List<Assembly>();
            //
            //    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            //    {
            //        if (assembly.GetName().Name.StartsWith("StoreObjects"))
            //            atemp.Add(assembly);
            //    }
            //
            //    while (atemp.Remove(null)) { }
            //
            //    EAStore_Assemblies = atemp.ToArray();
            //    atemp.Clear();
            //}

            if (AppDomain.CurrentDomain == null) 
                return;

            List<IntPtr> atemp = null;
            if (EA_Assemblies == null)
            {

                if (atemp == null)
                    atemp = new List<IntPtr>();

                Assembly ass = AssemblyCheckByNiec.FindAssemblyPro("Sims3GameplaySystems");
                if (ass != null)
                    atemp.Add(ass._mono_assembly);

                //ass = AssemblyCheckByNiec.FindAssemblyPro("Sims3StoreObjects");
                //if (ass != null)
                //    atemp.Add(ass._mono_assembly);

                ass = AssemblyCheckByNiec.FindAssemblyPro("Sims3GameplayObjects");
                if (ass != null)
                    atemp.Add(ass._mono_assembly);

                ass = AssemblyCheckByNiec.FindAssemblyPro("UI");
                if (ass != null)
                    atemp.Add(ass._mono_assembly);

                ass = AssemblyCheckByNiec.FindAssemblyPro("ScriptCore");
                if (ass != null)
                    atemp.Add(ass._mono_assembly);

                ass = AssemblyCheckByNiec.FindAssemblyPro("SimIFace");
                if (ass != null)
                    atemp.Add(ass._mono_assembly);

                ass = AssemblyCheckByNiec.FindAssemblyPro("Sims3Metadata");
                if (ass != null)
                    atemp.Add(ass._mono_assembly);

                EA_Assemblies = atemp.ToArray();
                atemp.Clear();


            }
            if (EAStore_Assemblies == null)
            {

                if (atemp == null)
                    atemp = new List<IntPtr>();

                var ass = AssemblyCheckByNiec.FindAssemblyPro("Sims3StoreObjects");
                if (ass != null)
                    atemp.Add(ass._mono_assembly);

                foreach (Assembly assembly in GetAssemblies())
                {
                    if (assembly == null)
                        continue;
                    try
                    {
                        if (assembly.GetName().Name.StartsWith("StoreObjects"))
                            atemp.Add(assembly._mono_assembly);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    
                }

               
                EAStore_Assemblies = atemp.ToArray();
                atemp.Clear();
            }


        }
        public static bool AssemblyIsEA(Assembly assembly)
        {
            return AssemblyIsEA(assembly, true);
        }
        public unsafe static bool AssemblyIsEA(Assembly assembly, bool isEAStoreObjects)
        {
            CacheAssemblyEA();
            var p = assembly._mono_assembly.value;
            foreach (var item in EA_Assemblies)
            {
                //if (assembly == item) return true;
                if (p == item.value) 
                    return true;
            }
            if (isEAStoreObjects)
            {
                foreach (var item in EAStore_Assemblies)
                {
                    //if (assembly == item) return true;
                    if (p == item.value)
                        return true;
                }
            }
            return false;
        }

        public unsafe static bool ShouldTimerByEA(AlarmTimerCallback atc) {
           
            if (atc == null || atc.method_info == null)
                return true;

            CacheAssemblyEA();

            Assembly assemy = atc.method_info.DeclaringType.Assembly;

            var p = assemy._mono_assembly.value;
            foreach (var item in EA_Assemblies)
            {
                //if (assemy == item) return true;
                if (p == item.value)
                    return true;
            }

            foreach (var item in EAStore_Assemblies)
            {
                //if (assemy == item) return true;
                if (p == item.value)
                    return true;
            }

            return false;
        }
        public static Sims3.Gameplay.Objects.Beds.Bed GetBedInRange(Lot lot)
        {
            if (!lot.IsWorldLot)
            {
                foreach (var bed in SC_GetObjectsOnLot<Sims3.Gameplay.Objects.Beds.Bed>(lot))
                {
                    if (bed is Sims3.Gameplay.Objects.Beds.BedSingle && !bed.IsBeingUsed)
                    {
                        return bed;
                    }
                    if (bed is Sims3.Gameplay.Objects.Beds.BedSingle && !bed.InUse)
                    {
                        return bed;
                    }
                }
            }
            return null;
        }
        public static void SimulateAlarm(AlarmManager amX, bool bUnSafe, bool bUnSafe1, bool isAweCore)
        {
            if (NiecRunCommand.ShouldCreatedBackupAlarmWorldManager())
                return;

            try
            {
                var am = amX; // TODO: test?
                // am arg Check Null :)
                DateAndTime other = SimClock.CurrentTime();
                int sleep = 0;
                int sleepC = 0;
                while (am.mTimerQueue.Count > 0)
                {
                    sleepC++;
                    if (sleepC > 1000)
                    {
                        sleepC = 0;
                        Simulator.Sleep(0);
                        if (NiecRunCommand.ShouldCreatedBackupAlarmWorldManager())
                            return;
                    }
                    AlarmManager.Timer timer = am.mTimerQueue[0] as AlarmManager.Timer;
                    if (timer.Cleared && !bUnSafe)
                    {
                        am.mTimerQueue.RemoveAt(0);
                        continue;
                    }
                    else if (timer.CallBack == null || (isAweCore && ShouldTimerByEA(timer.CallBack)))
                    {
                        am.InternalRemoveAlarm(timer, false);
                        am.mTimerQueue.RemoveAt(0);
                        timer.CallBack = null;
                        timer.Cleared = true;
                        continue;
                    }
                   
                    else
                    {
                        timer.Cleared = false;
                        if (timer.AlarmDateAndTime.CompareTo(other) >= 0)
                        {
                            break;
                        }
                        am.mTimerQueue.RemoveAt(0);
                        ScriptObject scriptObject = timer.CallBack.Target as ScriptObject;
                        if (scriptObject != null && scriptObject.Proxy == null && !bUnSafe)
                        {
                            am.InternalRemoveAlarm(timer, false);
                        }
                        else
                        {
                            AlarmTimerCallback callBack = timer.CallBack;

                            bool yieldRequired = timer.YieldRequired;
                            bool repeating = timer.Repeating;

                            if (repeating)
                            {
                                long num = SimClock.ConvertToTicks(timer.RepeatLength, timer.UnitOfTime);
                                long num2;
                                for (num2 = timer.AlarmDateAndTime.Ticks + num; num2 < other.Ticks; num2 += num) { }
                                timer.AlarmDateAndTime = new DateAndTime(num2);
                                am.mTimerQueue.Add(timer.AlarmDateAndTime.Ticks, timer);
                            }
                            else
                            {
                                am.InternalRemoveAlarm(timer, false);
                            }
                            if (callBack != null)
                            {
                                if (NiecRunCommand.ShouldCreatedBackupAlarmWorldManager())
                                    return;
                                try
                                {
                                    if (yieldRequired)
                                    {
                                        if (bUnSafe && NiecHelperSituation.__acorewIsnstalled__)// && !NiecHelperSituation.isdgmods)
                                        {
                                            NiecTask.PerformSID(ScriptExecuteType.Threaded,() =>
                                            {
                                                Simulator.CheckYieldingContext(false);

                                                var mItemerTimer = timer;
                                                var m = am;

                                                try
                                                {
                                                    if (callBack != null)
                                                    {
                                                        var funcType = typeof(Function);
                                                        if (funcType == null)
                                                            return;

                                                        var methed = callBack.method_info;
                                                        var obj = callBack.m_target;

                                                        if (methed != null)
                                                        {
                                                            if (!methed.IsStatic && obj != null)
                                                            {
                                                                var func = (Function)System.Delegate.CreateDelegate(funcType, obj, methed);
                                                                if (func != null)
                                                                    func();
                                                            }
                                                            else
                                                            {
                                                                var func = (Function)System.Delegate.CreateDelegate(funcType, methed);
                                                                if (func != null)
                                                                    func();
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (ResetException)
                                                {
                                                    throw;
                                                }
                                                catch (Exception)
                                                {
                                                    if (mItemerTimer.Repeating)
                                                    {
                                                        if (!bUnSafe)
                                                        {
                                                            m.InternalRemoveAlarm(mItemerTimer, true);
                                                        }
                                                        else if (bUnSafe1 && ShouldTimerByEA(callBack))
                                                        {
                                                            m.InternalRemoveAlarm(mItemerTimer, true);
                                                        }
                                                    }
                                                }
                                            });
                                        }
                                        else am.InvokeYieldingAlarm(timer, callBack);
                                    }
                                    else
                                    {
                                        if (bUnSafe && bUnSafe1)
                                        {
                                            
                                            //NiecTask.CreateWaitPerformWithExecuteTypeSID(ScriptExecuteType.Threaded, () => 
                                            //{
                                            //    var funcType = typeof(Function);
                                            //    if (funcType == null)
                                            //        return;
                                            //
                                            //    var methed = callBack.method_info;
                                            //    var obj = callBack.m_target;
                                            //
                                            //    if (methed != null)
                                            //    {
                                            //        if (!methed.IsStatic && obj != null)
                                            //        {
                                            //            var func = (Function)System.Delegate.CreateDelegate(funcType, obj, methed);
                                            //            if (func != null)
                                            //                func();
                                            //        }
                                            //        else
                                            //        {
                                            //            var func = (Function)System.Delegate.CreateDelegate(funcType, methed);
                                            //            if (func != null)
                                            //                func();
                                            //        }
                                            //    }
                                            //}).WaitingCanThrow();

                                            if (callBack != null)
                                            {
                                                var funcType = typeof(Function);
                                                if (funcType == null)
                                                    return;

                                                var methed = callBack.method_info;
                                                var obj = callBack.m_target;

                                                if (methed != null)
                                                {
                                                    if (!methed.IsStatic && obj != null)
                                                    {
                                                        var func = (Function)System.Delegate.CreateDelegate(funcType, obj, methed);
                                                        if (func != null)
                                                            func();
                                                    }
                                                    else
                                                    {
                                                        var func = (Function)System.Delegate.CreateDelegate(funcType, methed);
                                                        if (func != null)
                                                            func();
                                                    }
                                                }
                                            }
                                        }
                                        else callBack();
                                    }
                                    sleep++;
                                    if (sleep > 450)
                                    {
                                        sleep = 0;
                                        Simulator.Sleep(0);
                                        if (NiecRunCommand.ShouldCreatedBackupAlarmWorldManager())
                                            return;
                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                {
                                    if (repeating)
                                    {
                                        if (!bUnSafe)
                                        {
                                            am.InternalRemoveAlarm(timer, true);
                                        }
                                        else if (bUnSafe1 && ShouldTimerByEA(callBack))
                                        {
                                            am.InternalRemoveAlarm(timer, true);
                                        }
                                    }
                                }
                            }
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
			
        }


        public static T[] SC_GetObjectsIScriptLogic<T>() where T : IScriptLogic
        {
            Array objects = ScriptCore.Queries.Query_GetObjects(typeof(T));
            if (objects != null)
            {
                return objects as T[];
            }
            return new T[0];
        }

        public static void DeleteInvSim(Sim Actor)
        {
            if (Actor == null) return;
            try
            {
                _MoveInventoryItemsToAFamilyMember
                    (Actor, NiecRunCommand.HitTargetSim() ?? HouseholdMembersToSim(Household.ActiveHousehold, false, false) ?? PlumbBob.SelectedActor ?? HouseholdMembersToSim(Actor.Household, true, false));
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch { }
            if (Actor.mObjComponents != null)
            {
                Type typeI = typeof(Sims3.Gameplay.ObjectComponents.InventoryComponent);
                foreach (var item in Actor.mObjComponents.ToArray())
                {
                    if (item == null) continue;
                    if (item.BaseType == typeI)
                    {
                        try
                        {
                            item.Dispose();
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }
                        
                        Actor.mObjComponents.Remove(item);
                    }
                }
            }
        }

        public static SimUpdate GetSimUpdate(Sim sim)
        {
            foreach (var simUpdate in SC_GetObjects<SimUpdate>())//(ScriptCore.Queries.Query_GetObjects(typeof(ScriptCore.ScriptProxy)) as ScriptCore.ScriptProxy[]))
            {
                if (simUpdate == null)
                    continue;
                if (simUpdate.mSim == sim)
                    return simUpdate;
            }
            if (ScriptCore.Simulator.mObjHash != null)
            {
                foreach (var item in ScriptCore.Simulator.mObjHash)
                {
                    SimUpdate simUpdate = item.Value as SimUpdate;
                    if (simUpdate != null && simUpdate.mSim == sim)
                        return simUpdate;


                    ScriptCore.ScriptProxy proxy = item.Value as ScriptCore.ScriptProxy;
                    if (proxy != null)
                    {
                        simUpdate = proxy.mTarget as SimUpdate;
                        if (simUpdate != null && simUpdate.mSim == sim)
                        {
                            return simUpdate;
                        }


                    }   //return proxy;
                }
            }
            return null;
        }

        private static CommodityKind[] Sim_MaxMood_sCommodities = new CommodityKind[14] {
		    CommodityKind.VampireThirst,
		    CommodityKind.Hygiene,
		    CommodityKind.Bladder,
		    CommodityKind.Energy,
		    CommodityKind.Fun,
		    CommodityKind.Hunger,
		    CommodityKind.Social,
		    CommodityKind.HorseThirst,
		    CommodityKind.HorseExercise,
		    CommodityKind.CatScratch,
		    CommodityKind.DogDestruction,
		    CommodityKind.AlienBrainPower,
		    CommodityKind.Maintenence,
		    CommodityKind.BatteryPower
	    };

        public static void Motives_ForceSetMax(Motives ths, CommodityKind commodity)
        {
            Motive motive = IsOpenDGSInstalled ? ths.GetMotive(commodity) : GetSMotive(ths, commodity);
            if (motive != null && motive.Value != motive.Tuning.Max)
            {
                motive.UpdateMotiveBuffs(ths.mSim, commodity, (int)motive.Tuning.Max);
                motive.mValue = motive.Tuning.Max;
            }
        }

        public static
            bool sObjectsGameObjectIsValid = false;

        public static
            bool GameObjectIsValid(ulong objID)
        {
            if (objID == 0) // legal
                return false;
            if (sObjectsGameObjectIsValid)
                return ScriptCore.Objects.Objects_IsValid(objID);
            else
            {
                if (ScriptCore.Objects.Objects_GetPosition(objID) == Vector3_O && 
                    !ScriptCore.Objects.Objects_SetVisibleForLOS(objID, ScriptCore.Objects.Objects_IsVisibleForLOS(objID)) &&
                    ScriptCore.Objects.Objects_GetForward(objID) == Vector3_OV)
                {
                    return false;
                }
                return true;
                // return ScriptCore.Simulator.Simulator_GetTaskImpl(objID, false) != null;
            }

        }

        public static
           bool GameObjectAllIsValid(ulong objID)
        {
            if (objID == 0) 
                return false;
            return ScriptCore.Objects.Objects_IsValid(objID) || 
                ScriptCore.Simulator.Simulator_GetTaskImpl(objID, false) != null;
        }

        public static
            void Sim_MaxMood(Sim sim)
        {
            if (sim != null && GameObjectIsValid(sim.ObjectId.mValue))
            {
                var autonomy = sim.Autonomy;// ?? (sim.mAutonomy = new Autonomy(sim);
                if (autonomy == null) 
                    return;

                bool fixUp = false;
                var vMotives = autonomy.Motives;

                if (vMotives == null)
                {
                    fixUp = true;
                }
                else
                {
                    foreach (KeyValuePair<int, Motive> mMotive in vMotives.mMotives)
                    {
                        if (mMotive.Value == null || mMotive.Value.Tuning == null)
                        {
                            fixUp = true;
                            break;
                        }
                    }
                }

                if (fixUp)
                {
                    autonomy.RecreateAllMotives();
                }

                vMotives = autonomy.Motives;

                if (vMotives == null) 
                    return;

                foreach (CommodityKind commodity in Sim_MaxMood_sCommodities)
                {
                    Motives_ForceSetMax(vMotives, commodity);
                }
            }
        }

        public static ScriptCore.ScriptProxy GetProxyWithoutSimIFace(IScriptLogic gameObject)
        {
            foreach (var item in SC_GetObjects<ScriptCore.ScriptProxy>())//(ScriptCore.Queries.Query_GetObjects(typeof(ScriptCore.ScriptProxy)) as ScriptCore.ScriptProxy[]))
            {
                if (item == null) 
                    continue;
                if (item.mTarget == gameObject) 
                    return item;
            }
            if (ScriptCore.Simulator.mObjHash != null)
            {
                foreach (var item in ScriptCore.Simulator.mObjHash)
                {
                    if (item.Value == null)
                        continue;
                    ScriptCore.ScriptProxy proxy = item.Value as ScriptCore.ScriptProxy;
                    if (proxy != null && proxy.mTarget == gameObject)
                        return proxy;
                }
            }
            return null;
        }

        public static ScriptCore.ScriptProxy GetProxyFromObjectIDWithoutSimIFace(ObjectGuid objectID)
        {
            if (objectID.mValue == 0) return null;
            foreach (var item in SC_GetObjects<ScriptCore.ScriptProxy>())//(ScriptCore.Queries.Query_GetObjects(typeof(ScriptCore.ScriptProxy)) as ScriptCore.ScriptProxy[]))
            {
                if (item == null)
                    continue;
                if (item.ObjectId == objectID)
                    return item;
            }
            if (ScriptCore.Simulator.mObjHash != null)
            {
                foreach (var item in ScriptCore.Simulator.mObjHash)
                {
                    if (item.Value == null)
                        continue;
                    ScriptCore.ScriptProxy proxy = item.Value as ScriptCore.ScriptProxy;
                    if (proxy != null && proxy.mObjectId == objectID)
                        return proxy;
                }
            }
            return null;
        }

        public static T GetProxyPro<T>() where T : class
        {
            foreach (var item in SC_GetObjects<ScriptCore.ScriptProxy>())//(ScriptCore.Queries.Query_GetObjects(typeof(ScriptCore.ScriptProxy)) as ScriptCore.ScriptProxy[]))
            {
                if (item == null)
                    continue;
                if (item.mTarget is T)
                    return item as T;
            }
            if (ScriptCore.Simulator.mObjHash != null)
            {
                foreach (var item in ScriptCore.Simulator.mObjHash)
                {
                    if (item.Value == null)
                        continue;
                    ScriptCore.ScriptProxy proxy = item.Value as ScriptCore.ScriptProxy;
                    if (proxy != null && proxy.mTarget is T)
                        return proxy.mTarget as T;
                }
            }
            return null;
        }

        public static Sim NonOpenDGS_SimDesc_Instantiate(SimDescription ths, Vector3 position, SimOutfit outfit, bool forceAlwaysAnimate)
        {

            if (ths == null)
                return null; 
            if (ths.CreatedSim != null && ths != ths.CreatedSim.SimDescription)  // Custom
            {
                try
                {
                    ForceCancelAllInteractionsWithoutCleanup(ths.CreatedSim);
                    ths.CreatedSim.Destroy();
                }
                catch (Exception)
                { }
                ths.mSim = null;
            }
            if (!SafeNRaas.isnraasloaded) { return ths.Instantiate(position, ths.mDefaultOutfitKey, false, forceAlwaysAnimate); }
            
            if (ths.CreatedSim != null) 
                return ths.CreatedSim;
            if (ths.mOutfits == null)
            {
                ths.mOutfits = new OutfitCategoryMap();
                try
                {
                    ths.mOutfits[OutfitCategories.Everyday] = new ArrayList().Add(new Sims3.SimIFace.CAS.SimOutfit() { mIsLoaded = true, mHandle = 1 });
                    ths.mOutfits[OutfitCategories.Naked] = new ArrayList().Add(new Sims3.SimIFace.CAS.SimOutfit() { mIsLoaded = true, mHandle = 1 });
                    ths.Fixup();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                {}
               
            }
            if (outfit == null)
            {
                try
                {
                    if (ths.IsHorse)
                    {
                        outfit = ths.GetOutfit(OutfitCategories.Naked, 0);
                    }
                    else outfit = ths.GetOutfit(OutfitCategories.Everyday, 0);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                try
                {
                    if (outfit == null && Sim.ActiveActor != null && Sim.ActiveActor.mSimDescription != null)
                    {
                        outfit = Sim.ActiveActor.mSimDescription.GetOutfit(OutfitCategories.Everyday, 0);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                {}
                
            }
            Sim sim = null;
            NiecNraTask.NraFunction temp = delegate
            {
                sim = NRaas.CommonSpace.Helpers.Instantiation.Perform(ths, position, outfit, null);
            };
            temp();
            return sim;
        }

        public static void CreateNRaasFunctionTask(Sims3.Gameplay.Function function)
        {
            if (!SafeNRaas.isnraasloaded) { return; }

            if (function == null) 
                throw new ArgumentNullException("function");
            
            //ref Sim asda = null;

            NiecNraTask.NraFunction temp = delegate
            {
                NRaas.Common.FunctionTask.Perform(function);
            };
            temp();
        }


        public static bool SimDescCleanse(IMiniSimDescription me, bool clear)
        {
            return SimDescCleanse(me, clear, true);
        }

        public static bool ServiceGRImp_WaitBool = true;

        [TaskSaveSafe(false)]
        public static void OpenDGS_ServiceGRImp()
        {
            if (mService is GrimReaper)
            {
                try
                {
                    while (!Sims3.SimIFace.Environment.HasEditInGameModeSwitch)
                    {
                        if (ServiceGRImp_WaitBool && mService.mPool != null && mService.mPool.Count == 0 && NiecHelperSituation.bUnsafeRunReapSoulIsSelectable && NiecHelperSituation.Spawn._bUnSafeRunAll && NiecHelperSituation.WorkingNiecHelperSituationCount > 0)
                            Simulator.Sleep(50);
                        else
                        {
                            mService.Simulate();
                            Simulator.Sleep(10);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception ex)
                {
                    NiecException.WriteLog("OpenDGS_ServiceGR" + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
                    if (Simulator.CheckYieldingContext(false)) Simulator.Sleep(0);
                }
                if (!Sims3.SimIFace.Environment.HasEditInGameModeSwitch)
                     mthisService = AlarmManager.Global.AddAlarm(3f, TimeUnit.Minutes, new AlarmTimerCallback(delegate { OpenDGS_ServiceGR(mService); }), "OpenDGS_ServiceGR", AlarmType.NeverPersisted, null);
            }
        }


        public static ObjectGuid OpenDGS_ServiceGRTask = NiecRunCommand.NiecInvalidObjectGuid;
        public static void OpenDGS_ServiceGR(Service ser)
        {
            if (ser == null) ser = GrimReaper.Instance;
            try
            {
                AlarmManager.Global.RemoveAlarm(mthisService);
                mthisService = AlarmHandle.kInvalidHandle;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            mService = ser;
            Simulator.DestroyObject(OpenDGS_ServiceGRTask);
            OpenDGS_ServiceGRTask=NiecTask.Perform(OpenDGS_ServiceGRImp);
            
        }

        private static Service mService = null;
        private static AlarmHandle mthisService = AlarmHandle.kInvalidHandle;

        public static void SimDescBuffClear(Sim[] SimList, Sim ClearTarget, SimDescription ClearTargetSimDesc)
        {
            bool found = false;
            bool found2 = false;
            foreach (Sim sim in SimList)
            {
                //if (description == null) continue;
                //Sim sim = description.CreatedSim;
                //if (sim == null) continue;

                BuffManager buff = sim.BuffManager;
                if (buff == null) continue;

                try
                {
                    try
                    {
                        BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken = buff.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken;
                        if (buffInstanceHeartBroken != null && buffInstanceHeartBroken.MissedSim == ClearTargetSimDesc)
                        {
                            

                            buffInstanceHeartBroken.MissedSim = null;
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        BuffGermy.BuffInstanceGermy buffInstanceGermy = buff.GetElement(BuffNames.Germy) as BuffGermy.BuffInstanceGermy;
                        if (buffInstanceGermy != null && buffInstanceGermy.mOwningSim == ClearTargetSimDesc)
                        {

                            found2 = true;
                            buffInstanceGermy.mOwningSim = null;
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        BuffMourning.BuffInstanceMourning mBuffInstanceMourning = buff.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning;
                        if (mBuffInstanceMourning != null && mBuffInstanceMourning.MissedSim == ClearTargetSimDesc)
                        {
                            
                            mBuffInstanceMourning.MissedSim = null;
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    
                    try
                    {
                        BuffNegligent.BuffInstanceNegligent mNegligent = buff.GetElement(BuffNames.Negligent) as BuffNegligent.BuffInstanceNegligent;
                        if (mNegligent != null)
                        {
                            if (mNegligent.MissedSims != null)
                            {
                                foreach (var item in mNegligent.MissedSims)
                                {
                                    if (item == null) 
                                        continue;
                                    if (item.mSim == ClearTarget)
                                        item.mSim = null;
                                    if (item == ClearTargetSimDesc)
                                    {
                                        found = true; 
                                        break;
                                    }
                                }
                                if (found)
                                {
                                    mNegligent.MissedSims.Clear();
                                    mNegligent.MissedSims = null;
                                }
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    if (found)
                        buff.RemoveElement(BuffNames.Negligent);
                    if (found2)
                        buff.RemoveElement(BuffNames.Germy);
                    buff.RemoveElement(BuffNames.Mourning);
                    
                    buff.RemoveElement(BuffNames.HeartBroken);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
            }
        }


        public static
            bool InteractionQueue_HasInteraction<I>(IActor Actor)
            where I : InteractionInstance
        {
            if (Actor == null) 
                return false;

            var iq = Actor.InteractionQueue;
            if (iq == null) 
                return false;

            var iqList = iq.mInteractionList;
            if (iqList == null) 
                return false;
            var iqitems = iqList._items;
            if (iqitems == null) return false;
            for (int i = 0, maxL = iqitems.Length; i < maxL; i++)
            {
                if (iqitems[i] is I)
                    return true;
            }
            
           
            return false;
        }

        public static void Household_CleanUp()
        {
            NiecTask.Perform(delegate
            {
                //try
                //{
                //    foreach (var sHousehold in Household.sHouseholdList.ToArray())
                //    {
                //        if (sHousehold == null || sHousehold.IsSpecialHousehold) continue;
                //        Household.Members mm = sHousehold.mMembers;
                //        if (mm == null)
                //            HouseholdCleanse(sHousehold, false, false);
                //        else
                //        {
                //            if (mm.mAllSimDescriptions == null || mm.mAllSimDescriptions.Count == 0)
                //                HouseholdCleanse(sHousehold, false, false);
                //        }
                //    }
                //}
                //catch (StackOverflowException) { throw; }
                //catch (ResetException) { throw; }
                //catch
                //{ }
                try
                {
                    foreach (Lot lot in LotManager.AllLots)
                    {
                        if (lot == null) continue;

                        Household sHousehold = lot.Household;
                        if (sHousehold != null)
                        {
                            if ((sHousehold == Household.ActiveHousehold || (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && sHousehold == PlumbBob.sSingleton.mSelectedActor.Household)))
                                continue;

                            if (sHousehold.IsSpecialHousehold)
                            {
                                if (sHousehold.LotHome != null)
                                {
                                    try
                                    {
                                        lot.MoveOut(sHousehold);
                                    }
                                    catch
                                    { lot.mHousehold = null; sHousehold.mLotHome = null; }
                                }
                                //continue;
                            }

                            Household.Members mm = sHousehold.mMembers;
                            if (mm == null)
                            {
                                if (sHousehold.IsSpecialHousehold)
                                {
                                    sHousehold.mMembers = new Household.Members();
                                    continue;
                                }
                                HouseholdCleanse(sHousehold, false, false);
                                lot.mHousehold = null;
                            }
                            else
                            {
                                if (sHousehold.IsSpecialHousehold) continue;
                                if (mm.mAllSimDescriptions == null || mm.mAllSimDescriptions.Count == 0)
                                {
                                    HouseholdCleanse(sHousehold, false, false);
                                    lot.mHousehold = null;
                                }
                            }

                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }

                FixUpHouseholdListObjects(false);
                foreach (var sHousehold in SC_GetObjects<Household>())
                {
                    if (sHousehold == null ) continue;
                    Household.Members mm = sHousehold.mMembers;
                    if (mm == null)
                    {
                        if (sHousehold.IsSpecialHousehold) {
                            sHousehold.mMembers = new Household.Members();
                            continue;
                        }
                        else
                            HouseholdCleanse(sHousehold, false, false);
                    }
                    else
                    {
                        if (sHousehold.IsSpecialHousehold) continue;
                        if (mm.mAllSimDescriptions == null || mm.mAllSimDescriptions.Count == 0)
                            HouseholdCleanse(sHousehold, false, false);
                    }
                }
            });
            return;
        }

        public static bool SimDescCleanse(IMiniSimDescription me, bool clear, bool safe)
        {
            if (me == null) return false;
            try
            {

                Sim[] sl = SC_GetObjects<Sim>();
                DeleteCacheSimDescription(sl);

                List<DreamsAndPromisesManager> listDreamsAndPromisesManager = new List<DreamsAndPromisesManager>();
                try
                {
                    foreach (var item in sl)
                    {
                        if (item != null)
                        {
                            if (item.mDreamsAndPromisesManager != null)
                            {
                                listDreamsAndPromisesManager.Add(item.mDreamsAndPromisesManager);
                            }
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                {}
                

                //try
                //{
                //    if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                //    {
                //        NiecException.PrintMessage("NiecMod\nSimDescCleanse:\n" + "Name: " + me.FullName);
                //        NiecException.WriteLog("DEBUG SimDescCleanse(IMiniSimDescription me, bool clear, bool safeNoError):\n" + NiecException.GetDescription(me), true, false, false);
                //    }
                //}
                //catch (Exception)
                //{}
                
                SimDescription sim = me as SimDescription;
                //MiniSimDescription mini = me as MiniSimDescription;

                bool isAweCore = AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") && AssemblyCheckByNiec.IsInstalled("AweCore");


                Sim vKillNPC = null;

                if (sim != null)
                {
                    vKillNPC = sim.mSim;
                }
                if (isAweCore)
                {
                    try
                    {
                        if (vKillNPC != null)
                        {
                            InteractionInstance[] inlist = null;

                            var iq = vKillNPC.mInteractionQueue;
                            if (iq != null)
                            {
                                var iqList = iq.mInteractionList;
                                if (iqList != null)
                                    inlist = iqList.ToArray();
                            }

                            ForceDeAttachAndDestroyAllSlots(vKillNPC, false);
                            ForceCancelAllInteractionsWithoutCleanup(vKillNPC);

                            if (inlist != null)
                            {
                                foreach (var item in inlist)
                                {
                                    if (item == null) 
                                        continue;
                                    if (item is NiecHelperSituation.INHSInteraction)
                                    {
                                        var i = item;
                                        NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                                        {
                                            //var aa = ActiveActor;
                                            //if (aa != null)
                                            //    i.mInstanceActor = aa ??;
                                            //else
                                            //{
                                            //    try
                                            //    {
                                            //        i.mInstanceActor = vKillNPC;
                                            //        vKillNPC.mInteractionQueue = new Sims3.Gameplay.ActorSystems.InteractionQueue();
                                            //        vKillNPC.mInteractionQueue.mActor = vKillNPC;
                                            //    }
                                            //    catch (Exception)
                                            //    { }
                                            //   
                                            //}

                                            i.mInstanceActor = ActiveActor ?? vKillNPC;
                                            NFinalizeDeath._RunInteraction(i);

                                        });

                                        item.mInteractionState = InteractionInstance.InteractionState.None;
                                        item.mCancelled = false;

                                        continue;
                                    }

                                    item.mInteractionState = InteractionInstance.InteractionState.StandardExitDoNotValidateUseList;
                                    item.mCancelled = true;
                                }
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                }

                KillPro.CleanseGenealogy(me);

                try
                {
                    if (MiniSimDescription.sMiniSims != null)
                    {
                        foreach (SimDescription other in ListCollon.NiecSimDescriptions)
                        {
                            if (other == null)
                                continue;
                            MiniSimDescription miniOther = MiniSimDescription.Find(other.SimDescriptionId);
                            if (miniOther == null)
                                continue;

                            miniOther.RemoveMiniRelatioship(me.SimDescriptionId);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                ulong asdtr = me.SimDescriptionId;
                

                bool result = FindDelSimDesc(sim, clear);
                if (safe && sim != null && sim != ListCollon.NullSimSimDescription && !ListCollon.AllowNiecDisposedSimDescriptions)
                {
                    sim.mTraitManager = new TraitManager();
                    sim.OccultManager = new OccultManager();
                    //sim.mOutfits = new OutfitCategoryMap(); 
                }

                SimDescBuffClear(sl, vKillNPC, sim);

                if (clear) {
                    
                    if (HelperNra.HelperNraLists != null)
                    {
                        try
                        {
                            foreach (HelperNra helperNra in HelperNra.HelperNraLists.ToArray())
                            {
                                if (helperNra == null) continue;
                                if (helperNra.mSimdesc == me)
                                {
                                    AlarmManager alarm = AlarmManager.Global;
                                    if (alarm != null)
                                        alarm.RemoveAlarm(helperNra.this_alarm);
                                    helperNra.Dispose();
                                }
                            }
                            
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                    }
                    try
                    {
                        DeleteSavedLotSimDesc(me);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception) { }

                    List<Household> outHouseholdList;
                    if (Should_SimNoHousehold_HouseholdFound(sim, false, out outHouseholdList))
                    {
                        foreach (var itemHousehold in outHouseholdList)
                        {
                            if (itemHousehold == null)
                                continue;

                            Household.Members mem = itemHousehold.mMembers;
                            if (mem == null)
                                continue;

                            for (int i = 0; i < 100; i++)
                            {
                                if (mem.mAllSimDescriptions != null)
                                    mem.mAllSimDescriptions.Remove(sim);
                                if (mem.mPetSimDescriptions != null)
                                    mem.mPetSimDescriptions.Remove(sim);
                                if (mem.mSimDescriptions != null)
                                    mem.mSimDescriptions.Remove(sim);
                                sim.mHousehold = null;
                            }
                            if (mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                            {
                                HouseholdCleanse(itemHousehold, false, true);
                            }
                        }
                        outHouseholdList.Clear();
                    }
                }

                if (isAweCore)
                {
                    if (vKillNPC != null)
                    {
                        vKillNPC.mSimDescription = ListCollon.NullSimSimDescription;
                        if (vKillNPC.mSimDescription != null)
                            UnSafeForceErrorTargetSim(vKillNPC);
                    }
                }

                if (vKillNPC != null && clear)
                {
                    try
                    {
                        foreach (Sims3.Store.Objects.BlackjackTable blackjackTable in SC_GetObjects<Sims3.Store.Objects.BlackjackTable>())
                        {

                            try
                            {
                                for (int i = 0; i < blackjackTable.mPlayers.Length; i++)
                                {
                                    try
                                    {
                                        Sim Tsim = blackjackTable.mPlayers[i];
                                        if (Tsim == null) continue;
                                        if (Tsim == vKillNPC)
                                        {
                                            blackjackTable.mPlayers[i] = null;
                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    {}
                                    
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                            try
                            {
                                for (int i = 0; i < blackjackTable.mPlayersToAdd.Length; i++)
                                {
                                    try
                                    {
                                        Sim Tsim = blackjackTable.mPlayersToAdd[i];
                                        if (Tsim == null) continue;
                                        if (Tsim == vKillNPC)
                                        {
                                            blackjackTable.mPlayersToAdd[i] = null;
                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }

                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                            try
                            {
                                for (int i = 0; i < blackjackTable.mPlayersToRemove.Length; i++)
                                {
                                    try
                                    {
                                        Sim Tsim = blackjackTable.mPlayersToRemove[i];
                                        if (Tsim == null) continue;
                                        if (Tsim == vKillNPC)
                                        {
                                            blackjackTable.mPlayersToRemove[i] = null;
                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }

                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    {}

                    foreach (var dapm in listDreamsAndPromisesManager)
                    {
                        try
                        {
                           // DreamsAndPromisesManager dapm = item.mDreamsAndPromisesManager;
                            if (dapm != null)
                            { 
                                if (dapm.mPromiseNodes != null)
                                {
                                    try
                                    {
                                        ActiveNodeBase[] lisn = dapm.mPromiseNodes;
                                        foreach (var simr in lisn)
                                        {
                                            if (simr == null) continue; // || item.mOwner == null) continue;
                                            try
                                            {
                                                if (vKillNPC == simr.mOwner)
                                                {
                                                    try
                                                    {
                                                        dapm.RemoveActiveNode(simr);
                                                    }
                                                    catch
                                                    {}
                                                    simr.mOwner.mSimDescription = ListCollon.NullSimSimDescription;
                                                    simr.mOwner = null;
                                                }
                                            }
                                            catch (StackOverflowException) { throw; }
                                            catch (ResetException) { throw; }
                                            catch (Exception)
                                            { }

                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    {}
                                    
                                }
                                if (dapm.mActiveNodes != null)
                                {
                                    try
                                    {
                                        foreach (var simr in dapm.mActiveNodes.ToArray())
                                        {
                                            try
                                            {
                                                if (simr == null) continue;
                                                
                                                if (vKillNPC == simr.mOwner)
                                                {
                                                    try
                                                    {
                                                        dapm.RemoveActiveNode(simr);
                                                    }
                                                    catch
                                                    { }
                                                    simr.mOwner.mSimDescription = ListCollon.NullSimSimDescription;
                                                    simr.mOwner = null;
                                                }
                                            }
                                            catch (StackOverflowException) { throw; }
                                            catch (ResetException) { throw; }
                                            catch (Exception)
                                            { }
                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }
                                }
                                if (dapm.mSleepingNodes != null)
                                {
                                    try
                                    {
                                        foreach (var simr in dapm.mSleepingNodes.ToArray())
                                        {
                                            try
                                            {
                                                if (simr == null) continue;

                                                if (vKillNPC == simr.mOwner)
                                                {
                                                    try
                                                    {
                                                        dapm.RemoveCompletedNode(simr);
                                                    }
                                                    catch
                                                    { }
                                                    simr.mOwner.mSimDescription = ListCollon.NullSimSimDescription;
                                                    simr.mOwner = null;
                                                }
                                            }
                                            catch (StackOverflowException) { throw; }
                                            catch (ResetException) { throw; }
                                            catch (Exception)
                                            { }
                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }
                                }
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        { }
                    }
                }

                SimDescRemoveMSD(asdtr);
                DeleteCacheSimDescription(sl);

                try
                {
                    if (sim != null && ListCollon.AllowNiecDisposedSimDescriptions) // StackOverflowException?
                        NiecDisposedList_Add(sim);
                }
                catch (StackOverflowException) { ListCollon.AllowNiecDisposedSimDescriptions = false; throw; }
                catch (ResetException) { throw; }
                catch { }

                return result;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("Dispose SimDescCleanse: " + NiecException.NewLine + NiecException.GetDescription(me) + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
                return false;
            }
        }

        public static bool SimDescCleanse(IMiniSimDescription me)
        {
            return SimDescCleanse(me, false);
        }

        public static void UnSafeSimDeAttachAndPosture(Sim obj_Sim) {

            if (obj_Sim == null) return;
            try
            {
                Sim simChild = obj_Sim.GetObjectInRightHand() as Sim;
                if (simChild != null)
                {
                    simChild.mPosture = simChild.Standing;
                    Slots.DetachFromSlot(simChild.ObjectId);
                }

                simChild = obj_Sim.GetObjectInLeftHand() as Sim;
                if (simChild != null)
                {
                    simChild.mPosture = simChild.Standing;
                    Slots.DetachFromSlot(simChild.ObjectId);
                }

                simChild = obj_Sim.GetObjectInMouth() as Sim;
                if (simChild != null)
                {
                    simChild.mPosture = simChild.Standing;
                    Slots.DetachFromSlot(simChild.ObjectId);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException)
            { throw; }
            catch { }
            

            ForceDeAttachAndDestroyAllSlots(obj_Sim, true);

            obj_Sim.mPosture = obj_Sim.Standing;
        }

        internal static List<AlarmManager> temp_RandomAlarmManager = null;

        public static AlarmManager RandomAlarmManager
        {
            get
            {
                var lotList = LotManager.sLots;
                AlarmManager glAm = AlarmManager.Global;
                if (lotList != null)
                {
                    if (temp_RandomAlarmManager == null)
                        temp_RandomAlarmManager = new List<AlarmManager>();

                    try
                    {
                        if (temp_RandomAlarmManager.Count > 0)
                            temp_RandomAlarmManager.Clear();
                    }
                    catch
                    {
                        temp_RandomAlarmManager = new List<AlarmManager>();
                    }
                    

                    foreach (var item in lotList)
                    {
                        Lot valueItem = item.Value;
                        if (valueItem == null) 
                            continue;

                        Lot.SavedData lotSavedData = valueItem.mSavedData;
                        if (lotSavedData == null) 
                            continue;

                        AlarmManager am = lotSavedData.mAlarmManager;
                        if (am == null || am == glAm) 
                            continue;

                        temp_RandomAlarmManager.Add(am);
                    }

                    if (temp_RandomAlarmManager.Count > 0)
                    {
                        return RandomUtil.GetRandomObjectFromList<AlarmManager>(temp_RandomAlarmManager, ListCollon.SafeRandomPart2);
                    }
                }
                return glAm;
            }
        }

        //public static AlarmManager GetRandomAlarmManager() {
        ////var count = lotList.Count;
        //if (count > 0)
        //{
        //    var randomCount = ListCollon.SafeRandomPart2.Next(0, count);
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (i == randomCount)
        //            
        //    }
        //}
        //    return null;
        //}

        public static void ForceDeAttachAndDestroyAllSlotsWithObjectID(ulong objID, bool needHaveScript) { 
            ForceDeAttachAndDestroyAllSlotsWithObjectID(new ObjectGuid(objID), needHaveScript); 
        }
        public static void ForceDeAttachAndDestroyAllSlotsWithObjectID(ObjectGuid objID, bool needHaveScript)
        {
            if (objID.mValue == 0)
            { throw new ArgumentException("objID is not valid.", "objID"); }

            Slot[] slots = Slots.GetContainmentSlotNames(objID);
            if (slots == null || slots.Length == 0) { return; }
            foreach (var itemSlot in slots)
            {
                ObjectGuid[] itemChilderns = Slots.GetChildren(objID, itemSlot);
                if (itemChilderns == null || itemChilderns.Length == 0)
                { continue; }

                foreach (var itemChild in itemChilderns)
                {
                    if (GameObjectIsValid(itemChild.Value))
                    {
                        IScriptProxy proxy = Simulator.GetProxy(itemChild);
                        if (proxy != null)
                        {
                            var gameObj = proxy.Target as GameObject;
                            if (gameObj == null)
                            {
                                if (needHaveScript)
                                {
                                    continue;
                                }
                                Simulator.DestroyObject(itemChild);
                            }
                            else
                            {
                                if (objID == itemChild || gameObj is PlumbBob || gameObj is Lot)
                                {
                                    continue;
                                }
                                var simChild = gameObj as Sim;
                                if (simChild != null)
                                {
                                    simChild.mPosture = simChild.Standing;
                                    Slots.DetachFromSlot(simChild.ObjectId);
                                    continue;
                                }
                                ForceDestroyObject(gameObj, false);
                            }
                        }
                        else if (!needHaveScript)
                        {
                            Simulator.DestroyObject(itemChild);
                        }
                    }
                    else if (!needHaveScript)
                    {
                        if (itemChild != NiecRunCommand.NiecInvalidObjectGuid)
                        {
                            var task = Simulator.GetTask(itemChild);
                            if (task != null)
                            {
                                if (objID == itemChild || task is PlumbBob || task is Lot)
                                {
                                    continue;
                                }

                                var simChild = task as Sim;
                                if (simChild != null)
                                {
                                    simChild.mPosture = simChild.Standing;
                                    Slots.DetachFromSlot(simChild.ObjectId);
                                    continue;
                                }

                                IDisposable sdispose = task as IDisposable;
                                if (sdispose != null)
                                {
                                    try
                                    {
                                        sdispose.Dispose();
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch { }
                                }
                                Simulator.DestroyObject(itemChild);
                            }
                            else { Slots.DetachFromSlot(itemChild); }
                        }
                        else { Slots.DetachFromSlot(itemChild); }
                    }
                }
            }
        }
        public static void UnSafeForceDeAttachAndDestroyAllSlotsWithObjectID(ObjectGuid objID, bool needHaveScript)
        {
            if (objID.mValue == 0)
            { throw new ArgumentException("objID is not valid.", "objID"); }

            Slot[] slots = Slots.GetContainmentSlotNames(objID);
            if (slots == null || slots.Length == 0) { return; }
            foreach (var itemSlot in slots)
            {
                ObjectGuid[] itemChilderns = Slots.GetChildren(objID, itemSlot);
                if (itemChilderns == null || itemChilderns.Length == 0)
                { continue; }

                foreach (var itemChild in itemChilderns)
                {
                    if (GameObjectIsValid(itemChild.Value))
                    {
                        IScriptProxy proxy = Simulator.GetProxy(itemChild);
                        if (proxy != null)
                        {
                            var gameObj = proxy.Target as GameObject;
                            if (gameObj == null)
                            {
                                if (needHaveScript)
                                {
                                    continue;
                                }
                                Slots.DetachFromSlot(itemChild);
                            }
                            else
                            {
                                if (objID == itemChild || gameObj is PlumbBob || gameObj is Lot)
                                {
                                    continue;
                                }
                                var simChild = gameObj as Sim;
                                if (simChild != null)
                                {
                                    simChild.mPosture = simChild.Standing;
                                    Slots.DetachFromSlot(simChild.ObjectId);
                                    continue;
                                }
                                Slots.DetachFromSlot(itemChild);
                            }
                        }
                        else if (!needHaveScript)
                        {
                            Slots.DetachFromSlot(itemChild);
                        }
                    }
                    else if (!needHaveScript)
                    {
                        if (itemChild != NiecRunCommand.NiecInvalidObjectGuid)
                        {
                            var task = Simulator.GetTask(itemChild);
                            if (task != null)
                            {
                                if (objID == itemChild || task is PlumbBob || task is Lot)
                                {
                                    continue;
                                }

                                var simChild = task as Sim;
                                if (simChild != null)
                                {
                                    simChild.mPosture = simChild.Standing;
                                    Slots.DetachFromSlot(simChild.ObjectId);
                                    continue;
                                }

                                IDisposable sdispose = task as IDisposable;
                                if (sdispose != null)
                                {
                                    try
                                    {
                                        sdispose.Dispose();
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch { }
                                }
                                Slots.DetachFromSlot(itemChild); 
                            }
                            else { Slots.DetachFromSlot(itemChild); }
                        }
                        else { Slots.DetachFromSlot(itemChild); }
                    }
                }
            }
        }

        public static
            void List_ClearEx<T>(ref List<T> list)
        {
            if (list == null) 
                return;
            try
            {
                list.Clear();
            }
            catch (Exception)
            { list = new List<T>(); }
        }

        public static
            void List_FastClearEx<T>(ref List<T> list)
        {
            if (list == null || list.Count == 0)
                return;
            try
            {
                list.Clear();
            }
            catch (Exception)
            { list = new List<T>(); }
        }

        public static void ForceDeAttachAndDestroyAllSlots(GameObject obj, bool needHaveScript)
        {
            ObjectGuid guid = obj.ObjectId;
            Slot[] slots = Slots.GetContainmentSlotNames(guid);
            if (slots == null || slots.Length == 0) { return; }
            foreach (var itemSlot in slots)
            {
                ObjectGuid[] itemChilderns = Slots.GetChildren(guid, itemSlot);
                if (itemChilderns == null || itemChilderns.Length == 0) 
                { continue; }

                foreach (var itemChild in itemChilderns)
                {
                    if (GameObjectIsValid(itemChild.Value))
                    {
                        IScriptProxy proxy = Simulator.GetProxy(itemChild);
                        if (proxy != null)
                        {
                            var gameObj = proxy.Target as GameObject;
                            if (gameObj == null)
                            {
                                if (needHaveScript) {
                                    continue;
                                }
                                Simulator.DestroyObject(itemChild);
                            }
                            else
                            {
                                if (gameObj == obj || gameObj is PlumbBob || gameObj is Lot)
                                {
                                    continue;
                                }
                                var simChild = gameObj as Sim;
                                if (simChild != null) {
                                    simChild.mPosture = simChild.Standing;
                                    Slots.DetachFromSlot(simChild.ObjectId);
                                    continue;
                                }
                                ForceDestroyObject(gameObj, false);
                            }
                        }
                        else if (!needHaveScript) {
                            Simulator.DestroyObject(itemChild);
                        }
                    }
                    else if (!needHaveScript)
                    {
                        if (itemChild != NiecRunCommand.NiecInvalidObjectGuid)
                        {
                            var task = Simulator.GetTask(itemChild);
                            if (task != null)
                            {
                                if (task == obj || task is PlumbBob || task is Lot)
                                {
                                    continue;
                                }

                                var simChild = task as Sim;
                                if (simChild != null)
                                {
                                    simChild.mPosture = simChild.Standing;
                                    Slots.DetachFromSlot(simChild.ObjectId);
                                    continue;
                                }

                                IDisposable sdispose = task as IDisposable;
                                if (sdispose != null)
                                {
                                    try
                                    {
                                        sdispose.Dispose();
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch { }
                                }
                                Simulator.DestroyObject(itemChild);
                            }
                            else { Slots.DetachFromSlot(itemChild); }
                        }
                        else { Slots.DetachFromSlot(itemChild); }
                    }
                }
            }
        }

        public static void UnSafeForceErrorTargetSim(Sim obj_Sim)
        {
            Autonomy autonmy = obj_Sim.Autonomy;
            if (autonmy != null)
            {
                var aSituationComponent = autonmy.SituationComponent;

                if (aSituationComponent != null)
                    aSituationComponent.mSituations = new List<Situation>();

                autonmy.mSituationComponent = null;
                autonmy.mMotives = null;
            }

            obj_Sim.mBuffManager = null;
            obj_Sim.mMoodManager = null;
            obj_Sim.mInteractionQueue = null;
            obj_Sim.mLookAtManager = null;
            obj_Sim.mIdleManager = null;
            obj_Sim.mThoughtBalloonManager = null;
            obj_Sim.mSocialComponent = null;
            obj_Sim.mSnubManager = null;
            obj_Sim.mMapTagManager = null;
            obj_Sim.mDreamsAndPromisesManager = null;
            obj_Sim.mDreamsAndPromisesManager = null;
            obj_Sim.mDeepSnowEffectManager = null;
            obj_Sim.mFlags = 0;
            obj_Sim.SleepDreamManager = null;

            //if (!IsOpenDGSInstalled)
            //{
            //    obj_Sim.mObjComponents = new List<ObjectComponent>(100);
            //    obj_Sim.mObjComponents.Add(null);
            //
            //    try
            //    {
            //        if (obj_Sim.mInteractions != null && obj_Sim.mInteractions._items != null)
            //        {
            //            List_FastClearEx(ref obj_Sim.mInteractions);
            //            for (int i = 0; i < 50; i++)
            //            {
            //                obj_Sim.mInteractions.Add(null);
            //            }
            //        }
            //    }
            //    catch (StackOverflowException) { throw; }
            //    catch (ResetException) { throw; }
            //    catch { }
            //    
            //}

           // NiecPosture niecPo = obj_Sim.mPosture as NiecPosture;
            //if (niecPo == null)
            //if (!(obj_Sim.mPosture is NiecPosture ))

            if (obj_Sim.mPosture as NiecPosture == null)
                obj_Sim.mPosture = new NiecPosture(obj_Sim);

            DeleteInvSim(obj_Sim);
        }

        public static void SimDescRemoveMSD(ulong id)
        {
            RRemoveMSD(id);

            if (FutureDescendantService.sPersistableData != null)
            {
                if (FutureDescendantService.sPersistableData.DescendantHouseholdsMap != null)
                {
                    FutureDescendantService.sPersistableData.DescendantHouseholdsMap.Remove(id);
                }
            }

            CauseEffectService instance = CauseEffectService.GetInstance();
            if (instance != null)
            {
                if (CauseEffectService.sPersistableData != null)
                {
                    if (CauseEffectService.sPersistableData.TimeTravelerSimID == id)
                    {
                        CauseEffectService.sPersistableData.TimeTravelerSimID = 0;
                    }
                }

                List<ITimeStatueUiData> timeStatueData = instance.GetTimeAlmanacTimeStatueData();
                if (timeStatueData != null)
                {
                    foreach (ITimeStatueUiData data in timeStatueData)
                    {
                        TimeStatueRecordData record = data as TimeStatueRecordData;
                        if (record == null) continue;

                        if (record.mRecordHolderId == id)
                        {
                            record.mRecordHolderId = 0;
                        }
                    }
                }
            }
        }

        internal static void Debugger_Break() // Debugger App Only
        {
            try
            {
                while (true)
                {
                    // no code
                }
            }
            catch (Exception)
            {}
        }




        public static bool FindDelSimDesc(SimDescription sim, bool clear)
        {
            
            if (sim == null)
            {
                return false;
                
            }
            try
            {
                Sim createdSim = sim.CreatedSim;
                if (createdSim != null)
                {

                    createdSim.ReservedVehicle = null;
                    try
                    { ForceCancelAllInteractionsWithoutCleanup(createdSim); }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }


                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                if (clear)
                {
                    FixCantRemoveHousehold(sim, true, false);
                    /*
                    // Household holde = null;
                    // if (clear)
                    //    holde = sim.Household;
                    //    
                    Household holde = sim.Household;
                    if (holde != null)
                    {
                        if (holde.IsServiceNpcHousehold)
                        {
                            if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                            holde.mLotHome = null;

                            holde.mLotId = 0uL;
                        }
                        try
                        {
                            holde.Remove(sim, !holde.IsServiceNpcHousehold);
                        }
                        catch (Exception)
                        { }


                        if (!holde.IsServiceNpcHousehold)
                        {
                            if (holde.mMembers != null && holde.mMembers.Count == 0)
                            {
                                //holde.HandleLastSimsDeath();
                                try
                                {
                                    if (holde.LotHome != null) // Test New 130?
                                    {
                                        Sims3.Gameplay.Services.Services.ClearServicesForLot(holde.LotHome);
                                        Bill.DestroyAllBillsForHousehold(sim.CreatedSim, holde.LotHome);
                                        holde.LotHome.CleanUpForMoving();
                                    }
                                }
                                catch (ResetException)
                                { throw; }
                                catch { }

                                try
                                {
                                    holde.MoveOut();
                                    
                                }
                                catch (Exception)
                                { }

                                try
                                {
                                    
                                    if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                                }
                                catch (Exception)
                                { }

                                holde.mLotHome = null;

                                holde.mLotId = 0uL;
                                try
                                {
                                    holde.Dispose();
                                }
                                catch (Exception)
                                {}
                            }
                            else if (holde.mMembers != null && holde.mMembers.mAllSimDescriptions != null &&  holde.mMembers.mAllSimDescriptions.Contains(sim)) 
                            {
                                if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                                
                                try
                                {
                                    holde.MoveOut();
                                }
                                catch (Exception)
                                { }

                                try
                                {
                                    if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                                }
                                catch (Exception)
                                { } 
                                
                                holde.mLotHome = null;

                                holde.mLotId = 0uL;
                            }
                        }
                        sim.mHousehold = null;
                    }
                     */
                }

            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            {}
            try
            {
                if (PetAdoption.sNeighborAdoption != null)
                {
                    if (PetAdoption.sNeighborAdoption.mMother == sim)
                    {
                        try
                        {
                            PetAdoption.ResetNeighborAdoption();
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                        finally
                        {
                            PetAdoption.sNeighborAdoption = null;
                        }
                    }
                    else
                    {
                        PetAdoption.sNeighborAdoption.mPetsToAdopt.Remove(sim);
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc B: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                foreach (Service service in Services.AllServices)
                {
                    try
                    {
                        if (service == null) continue;



                        if (sim.CreatedSim != null)
                        {
                            service.RemoveAssignment(sim.CreatedSim);
                            
                        }

                        service.RemovePreferredSim(sim);

                        service.mPool.Remove(sim);

                        ResortWorker resortWorker = service as ResortWorker;
                        if (resortWorker != null)
                        {
                            if (resortWorker.mWorkerInfo != null)
                            {
                                List<ObjectGuid> remove = new List<ObjectGuid>();

                                foreach (KeyValuePair<ObjectGuid, ResortWorker.WorkerInfo> info in resortWorker.mWorkerInfo)
                                {
                                    if ((info.Value.CurrentSimDescriptionID == sim.SimDescriptionId) ||
                                        (info.Value.DesiredSimDescriptionID == sim.SimDescriptionId))
                                    {
                                        remove.Add(info.Key);
                                    }
                                }

                                foreach (ObjectGuid rem in remove)
                                {
                                    resortWorker.mWorkerInfo[rem] = new ResortWorker.WorkerInfo();
                                }
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                }
            }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc C: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            
            try
            {
                if (sim.LifeEventManager != null)
                {
                    sim.LifeEventManager.Purge();
                }
                sim.LifeEventManager = null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc D: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }

            try
            {
                KillPro.RemoveSimDescriptionRelationships(sim);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            try
            {
                if (sim.CareerManager != null)
                {
                    sim.CareerManager.LeaveAllJobs(Career.LeaveJobReason.kDied);
                }
                if (sim.CareerManager != null)
                    sim.CareerManager.mJob = null;
                if (sim.CareerManager != null)
                    sim.CareerManager.mSchool = null;
                sim.CareerManager = null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            {
                try
                {
                    try
                    {
                        sim.CareerManager.mJob = null;
                        sim.CareerManager.mSchool = null;
                    }
                    catch (Exception)
                    { }
                    sim.CareerManager = null;
                }
                catch (Exception ex)
                {
                    NiecException.WriteLog("FindDelSimDesc E: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

                }
                
            }
            try
            {
                if ((clear))
                {
                    try
                    {
                        foreach (Sim.Placeholder placeholder in SC_GetObjects<Sim.Placeholder>())
                        {
                            try
                            {
                                if (placeholder.SimDescription == sim)
                                {
                                    placeholder.mSimDescription = null;
                                    placeholder.Destroy();
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    
                    try
                    {
                        foreach (CaregiverRoutingMonitor.ChildPlaceholder childPlaceholder in SC_GetObjects<CaregiverRoutingMonitor.ChildPlaceholder>())
                        {
                            
                            try
                            {
                                if (childPlaceholder.SimDescription == sim)
                                {
                                    childPlaceholder.mSimDescription = null;
                                    childPlaceholder.Destroy();
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                        }

                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    int isleep = 0;
                    int isleepX = 0;
                    while (isleepX < 1000)
                    {
                        isleepX++;
                        Urnstone urnstone = HelperNra.TFindGhostsGrave(sim);
                        if (urnstone != null)
                        {
                            urnstone.SetPosition(Vector3.OutOfWorld);
                            urnstone.DeadSimsDescription = null;
                            //try
                            //{
                            //    urnstone.Dispose();
                            //}
                            //catch (StackOverflowException) { throw; }
                            //catch (ResetException) { throw; }
                            //catch
                            //{ }
                            //try
                            //{
                            //    urnstone.Destroy();
                            //}
                            //catch (StackOverflowException) { throw; }
                            //catch (ResetException) { throw; }
                            //catch
                            //{ }
                            isleep++;
                            ForceDestroyObject(urnstone, false);
                            if (isleep > 200)
                            {
                                isleep = 0;
                                if (Simulator.CheckYieldingContext(false))
                                    Simulator.Sleep(0);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc G: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }

            try
            {
                if (sim.Partner != null)
                {
                    sim.Partner.Partner = null;
                }

                sim.Partner = null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A1: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                if (sim.mPartner != null)
                {
                    sim.mPartner.mPartner = null;
                }
                sim.mPartner = null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A2: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                if ((FakeMetaAutonomy.Instance != null) && (FakeMetaAutonomy.Instance.mPool != null))
                {
                    FakeMetaAutonomy.Instance.mPool.Remove(sim);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A3: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }


            try
            {
                if (Sims3.Gameplay.Services.FakeMetaAutonomy.mToDestroy != null)
                {
                    Sims3.Gameplay.Services.FakeMetaAutonomy.mToDestroy.Remove(sim);
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A4: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }

            try
            {
                if (sim.AssignedRole != null)
                {
                    sim.AssignedRole.RemoveSimFromRole();
                }

            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A5: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                sim.AssignedRole = null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A6: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            
            try
            {
                if ((CarNpcManager.Singleton != null) && (CarNpcManager.Singleton.NpcDriversManager != null))
                {
                    foreach (Stack<SimDescription> stack in CarNpcManager.Singleton.NpcDriversManager.mDescPools)
                    {
                        if (stack == null) continue;

                        List<SimDescription> sims = new List<SimDescription>();

                        bool found = false;
                        foreach(SimDescription stackSim in stack)
                        {
                            if (stackSim == sim)
                            {
                                found = true;
                            }
                            else
                            {
                                sims.Add(stackSim);
                            }
                        }

                        if (found)
                        {
                            stack.Clear();

                            foreach (SimDescription stackSim in sims)
                            {
                                stack.Push(stackSim);
                            }
                        }
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A7: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                Sim sia = sim.mSim;
                if (sia != null)
                {
                    Lot xlot = sia.LotCurrent;
                    if (xlot != null && xlot.LastDiedSim == sim)
                    {
                        xlot.LastDiedSim = null;
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FindDelSimDesc A8: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                //if (ListCollon.NullSimSimDescription == null)
                //{
                //    foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
                //    {
                //        if (item == null) continue;
                //        if (item.IsValidDescription && item.IsValid) continue;
                //        NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(item));
                //        ListCollon.NullSimSimDescription = item;
                //        break;
                //    }
                //}
                Create.NiecNullSimDescription(false, false, true);
                if (ListCollon.NullSimSimDescription == null)
                    ListCollon.NullSimSimDescription = sim;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch{ }


            if (clear)
            {
                Sim sa = sim.mSim;

                if (sa != null)
                {
                    
                    
                    /*
                    try
                    {
                        sa.SetObjectToReset();
                    }
                    catch
                    {}
                     */
                    
                    try
                    {
                        ObjectGuid a = sa.ObjectId;
                        try
                        {
                            try
                            {
                                sa.Destroy();
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            {
                                sa.mPosture = sa.Standing;
                                sa.Destroy();
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception ex)
                        {
                            NiecException.WriteLog("Sim.Destroy(): " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

                        }
                       
                        try
                        {
                            World.RemoveObjectFromObjectManager(a);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                        Simulator.DisableScript(a);

                        Simulator.DestroyObject(a);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                }
                
                
                /*
                try
                {
                    //sim.CreatedSim = null;
                    sim.mSim = null;
                }
                catch
                {sim.mSim = null;}
                */
                try
                {



                    if (ListCollon.NullSimSimDescription == null)
                    {
                        AlarmHandle LoadArimPart6 = AlarmHandle.kInvalidHandle;
                        LoadArimPart6 = AlarmManager.Global.AddAlarm(1f, TimeUnit.Hours, new AlarmTimerCallback(delegate
                        {

                            AlarmManager.Global.RemoveAlarm(LoadArimPart6);
                            LoadArimPart6 = AlarmHandle.kInvalidHandle;



                            if (sa != null)
                                sa.mSimDescription = ListCollon.NullSimSimDescription;

                        }), "Safe :)", AlarmType.NeverPersisted, null);

                    }
                    else
                    {
                        if (sa != null)
                            sa.mSimDescription = ListCollon.NullSimSimDescription;
                    }
                    sim.mSim = null;
                    sa = null;

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                {}
               

                NFinalizeDeath.SimDescDispose(sim);
            }
            return true;
        }

        public static InteractionDefinition OpenDGS_NeedCacheDefinition()
        {
            return ExtKillSimNiec.Singleton;
        }


        public static void SimDescDispose(SimDescription description)
        {
            if (description == null) return;
            //Household mec = null;
            //try
            //{
            //    mec = description.Household;
            //    //mec = description.Household.SimDescriptions[0].Household;
            //}
            //catch (StackOverflowException) { throw; }
            //catch (ResetException) { throw; }
            //catch (Exception)
            //{ }
             

            try
            {
                /*
                foreach (List<Role> collection in new List<List<Role>>(RoleManager.sRoleManager.mRoles.Values))
				{
                    if (collection == null) continue;
                    try
                    {
                        foreach (Role role in collection)
                        {
                            try
                            {
                                if (role == null) continue;
                                if (role.mSim == description)
                                {
                                    role.mSim = null;
                                }
                            }
                            catch (Exception)
                            { }
                            
                            
                        }
                    }
                    catch (Exception)
                    { }
                    
				}
                 */

                List<Role> list = new List<Role>();
                if (RoleManager.sRoleManager != null && RoleManager.sRoleManager.mRoles != null)
                {
                    foreach (List<Role> collection in RoleManager.sRoleManager.mRoles.Values)
                    {
                        if (collection == null) continue;
                        list.AddRange(collection);
                    }
                }
                try
                {
                    foreach (Role role in list)
                    {
                        try
                        {
                            if (role == null) continue;
                            if (role.mSim == description)
                            {
                                role.mSim = null;
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }


                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            {
               // NiecException.WriteLog("SimDescDispose A1: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);

            }
            try
            {
                if (LotManager.sLots != null)
                {
                    foreach (Lot item in LotManager.AllLots)
                    {
                        if (item == null) continue;
                        if (description == item.LastDiedSim)
                        {
                            item.LastDiedSim = null;
                        }
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            {}
            try
            {
                try
                {
                    foreach (GenieLamp genieLamp in SC_GetObjects<GenieLamp>())
                    {
                        if (description == genieLamp.mGenieDescription)
                        {
                            genieLamp.mGenieDescription = null;
                            //break;
                        }
                    }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    foreach (BonehildaCoffin bonehildaCoffin in SC_GetObjects<BonehildaCoffin>())
                    {
                        if (description == bonehildaCoffin.mBonehilda)
                        {
                            bonehildaCoffin.mBonehilda = null;
                            //break;
                        }
                    }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    if (description.mOutfits != null || description.mMaternityOutfits != null)
                    {
                        if (description.IsPregnant)
                        {
                            if (AssemblyCheckByNiec.IsInstalled("NRaasMasterController") || AssemblyCheckByNiec.IsInstalled("NRaasRegister"))
                            {
                                Type type = Type.GetType("NRaas.CommonSpace.Helpers.CASParts, NRaasRegister");
                                if (type == null)
                                {
                                    type = Type.GetType("NRaas.CommonSpace.Helpers.CASParts, NRaasMasterController");
                                }
                                if (type != null)
                                {
                                    MethodInfo infao = type.GetMethod("RemoveOutfits");
                                    if (infao != null)
                                    {
                                        infao.Invoke(null, (new object[] { description, OutfitCategories.All, false }));
                                    }
                                }
                            }
                            else description.RemoveOutfits(OutfitCategories.All, true, true);
                            //NRaas.CommonSpace.Helpers.CASParts.RemoveOutfits(description, OutfitCategories.All, false);
                        }
                        else
                        {
                            if (AssemblyCheckByNiec.IsInstalled("NRaasMasterController") || AssemblyCheckByNiec.IsInstalled("NRaasRegister"))
                            {
                                Type type = Type.GetType("NRaas.CommonSpace.Helpers.CASParts, NRaasRegister");
                                if (type == null)
                                {
                                    type = Type.GetType("NRaas.CommonSpace.Helpers.CASParts, NRaasMasterController");
                                }
                                if (type != null)
                                {
                                    MethodInfo infao = type.GetMethod("RemoveOutfits");
                                    if (infao != null)
                                    {
                                        infao.Invoke(null, (new object[] { description, OutfitCategories.All, true }));
                                    }
                                }
                            }
                            else description.RemoveOutfits(OutfitCategories.All, true, false);
                            //NRaas.CommonSpace.Helpers.CASParts.RemoveOutfits(description, OutfitCategories.All, true);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }


                if (description.Genealogy != null)
                {
                    try
                    {
                        description.Genealogy.ClearMiniSimDescription();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                    try
                    {
                        description.Genealogy.ClearDerivedData();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                    try
                    {
                        description.Genealogy.ClearSimDescription();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                    try
                    {
                        description.Genealogy.ClearAllGenealogyInformation();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                }

                try
                {
                    if (description.CreatedSim != null)
                    {
                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(description.CreatedSim);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }


                try
                {
                    
                    Household household = description.Household;
                    if (household != null)
                    {
                       // household.mMembers.mSimDescriptions.Remove(description);
                        //household.mMembers.mPetSimDescriptions.Remove(description);
                        //household.mMembers.mAllSimDescriptions.Remove(description);
                       household.Remove(description, !household.IsSpecialHousehold);
                        //household.Dispose(false);
                    }
                    
                    //HouseholdCleanse(description.Household, description);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                
                try
                {
                    int isleep = 0;
                    int isleepX = 0;
                    while (isleepX < 1000)
                    {
                        isleepX++;
                        Urnstone urnstone = null;
                        urnstone = HelperNra.TFindGhostsGrave(description);
                        if (urnstone != null)
                        {
                            //urnstone.SetPosition(Vector3.OutOfWorld);
                            Sims3.SimIFace.Objects.SetPosition(urnstone.ObjectId, Vector3.OutOfWorld);
                            urnstone.DeadSimsDescription = null;
                            //try
                            //{
                            //    urnstone.Dispose();
                            //}
                            //catch (StackOverflowException) { throw; }
                            //catch (ResetException) { throw; }
                            //catch
                            //{ }
                            //try
                            //{
                            //    urnstone.Destroy();
                            //}
                            //catch (StackOverflowException) { throw; }
                            //catch (ResetException) { throw; }
                            //catch
                            //{ }
                            isleep++;
                            ForceDestroyObject(urnstone, false);
                            if (isleep > 200)
                            {
                                isleep = 0;
                                if (Simulator.CheckYieldingContext(false))
                                    Simulator.Sleep(0);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }

                try
                {
                    foreach (Urnstone urnstone in SC_GetObjects<Urnstone>())
                    {
                        try
                        {
                            if (object.ReferenceEquals(urnstone.DeadSimsDescription, description))
                            {
                                urnstone.DeadSimsDescription = null;
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                        
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }

                MiniSimDescription imini = null;
                try
                {
                    imini = MiniSimDescription.Find(description.SimDescriptionId);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    MiniSimDescription.RemoveMSD(description.SimDescriptionId);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                try
                {
                    if (imini != null)
                    {
                        imini.mAgeGenderFlags = CASAgeGenderFlags.None;
                        imini.mAlmaMater = AlmaMater.None;
                        imini.mAlmaMaterName = null;
                        imini.mbAgingEnabled = false;
                        imini.mCelebrityLevel = 0;
                        imini.mDeathStyle = SimDescription.DeathType.None;
                        imini.mDegrees = null;
                        imini.mFirstName = null;
                        imini.mHomeLotId = 0;
                        imini.mGenealogy = null;
                        imini.mHomeWorld = WorldName.Undefined;
                        imini.mFirstName = null;
                        imini.mHouseholdMembers = null;
                        imini.mMiniRelationships = null;
                        imini.mLastName = null;
                        imini.mMotherDescId = 0;
                        imini.mNumPetsInHousehold = 0;
                        imini.mNumSimsInHousehold = 0;
                        imini.mProtectionFlags = null;
                        imini.mSimDescriptionId = 0;
                        imini.mStatusFlags = MiniSimDescription.SimDescriptionStatus.None;
                        imini.mThumbKey = ThumbnailKey.kInvalidThumbnailKey;
                        imini.mTraits = null;
                        imini.mTravelKey = ResourceKey.kInvalidResourceKey;
                        imini.mZodiac = Zodiac.Unset;
                        imini.JobIcon = null;
                        imini.JobOrServiceName = null;
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                imini = null;


                try
                {
                    //description.Dispose();
                    //if (NiecHelperSituation.__kinkymdisInstalled)
                    //{
                    //    SafeCall(() => { SimDescDispose_Internal(description, true, false, false, false, true); });
                    //}
                    //else
                    {
                        SimDescDispose_Internal(description, true, false, false, false, true);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                List<Sim> asdo = new List<Sim>();
                try
                {
                    try
                    {
                        if (GameStates.sTravelData != null && GameStates.sTravelData.mSimDescriptionNeedPostFixUp != null)
                        {
                            foreach (SimDescription simDescription4 in GameStates.sTravelData.mSimDescriptionNeedPostFixUp)
                            {
                                if (simDescription4 == description)
                                {
                                    GameStates.sTravelData.mSimDescriptionNeedPostFixUp.Remove(description);
                                    break;
                                }
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        try
                        {
                            foreach (Sim simau in SC_GetObjects<Sim>())
                            {
                                try
                                {
                                    if (!asdo.Contains(simau))
                                        asdo.Add(simau);
                                }
                                catch (StackOverflowException) { throw; }
                                catch (ResetException) { throw; }
                                catch
                                { }
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        { }

                        try
                        {
                            foreach (Sim simau in LotManager.Actors)
                            {
                                try
                                {
                                    if (!asdo.Contains(simau))
                                        asdo.Add(simau);
                                }
                                catch (StackOverflowException) { throw; }
                                catch (ResetException) { throw; }
                                catch
                                { }
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        { }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }
                    try
                    {
                        foreach (Sim simaue in asdo)
                        {
                            try
                            {
                                SimDescription checkkillsim = simaue.mSimDescription;
                                if (checkkillsim == description)
                                {
                                    try
                                    {
                                        simaue.Destroy();
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch
                                    {}
                                    try
                                    {
                                        try
                                        {
                                            World.RemoveObjectFromObjectManager(simaue.ObjectId);
                                        }
                                        catch (StackOverflowException) { throw; }
                                        catch (ResetException) { throw; }
                                        catch (Exception)
                                        { }

                                        Simulator.DestroyObject(simaue.ObjectId);
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }
                                    
                                    break;
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                            
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                asdo = null;
                try
                {
                    description.mDeathStyle = Sims3.NiecHelp.Tasks.KillTask.GetDeathType(null);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    if (description.mOutfits != null || description.mMaternityOutfits != null)
                        description.ClearOutfits(true);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }







                try
                {
                    if (description.mTraitManager != null)
                    {
                        foreach (Trait trait in description.mTraitManager.List)
                        {
                            description.mTraitManager.RemoveTraitEffects(description, trait.Guid);
                            description.mTraitManager.mRewardTraits.Remove(trait);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    if (description.mTraitManager != null)
                    description.mTraitManager.RemoveAllElements();

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    if (description.mTraitChipManager !=null)
                    description.mTraitChipManager.OnSimDisposed();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }








                try
                {
                    if (description.SkillManager != null) {
                    List<Skill> nrsa = new List<Skill>(description.SkillManager.List);
                    foreach (var item in nrsa)
                    {
                        if (item == null) continue;
                        try
                        {
                            item.ResetStats();
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                        try
                        {
                            description.SkillManager.RemoveElement(item.mSkillGuid);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }

                    }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }



               

                try
                {
                    description.mReputation = null;
                    description.mFlags = SimDescription.FlagField.None;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }









                try
                {
                    if (description.CelebrityManager != null)
                    description.CelebrityManager.OnDispose();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.CelebrityManager = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.mTraitManager = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.mTraitChipManager = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.SkillManager = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }


                try
                {
                    description.mHomeWorld = WorldName.Undefined;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }






                try
                {
                    if (description.AssignedRole != null)
                    {
                        description.AssignedRole.RemoveSimFromRole();
                    }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }


                try
                {
                    description.AssignedRole = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                






                try
                {
                    try
                    {
                        if (description.OccultManager != null)
                        {
                            description.OccultManager.RemoveAllOccultTypes();
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                    description.OccultManager = null;

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }









                try
                {
                    if (description.PetManager != null)
                    description.PetManager.Dispose();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                if (description.Occupation != null)
                {
                    try
                    {
                        description.Occupation.FireSim(true);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        description.Occupation.OnDispose();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        description.Occupation.FireSim(true);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                }
                try
                {
                    if (description.CareerManager != null)
                    description.CareerManager.mJob = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.mInitialShape.Owner = null;
                    description.mInitialShape = default(SimDescriptionCore.BodyShape);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.mCurrentShape.Owner = null;
                    description.mCurrentShape = default(SimDescriptionCore.BodyShape);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.mDisplayedShape.Owner = null;
                    description.mDisplayedShape  = default(SimDescriptionCore.BodyShape);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.LifetimeWish = 0;
                    description.PetManager = null;
                    description.mFirstName = null;
                    description.mDescription = null;
                    description.mSupernaturalData = null;
                    description.mPartner = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    if (description.Service != null)
                    description.Service.EndService(description);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    if (description.CreatedByService != null)
                    description.CreatedByService.EndService(description);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.Service = null;
                    description.CreatedByService = null;
                    description.mReputation = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    try
                    {
                        if (description.CareerManager != null)
                        description.CareerManager.OnRemoved(null);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        if (description.MidlifeCrisisManager != null)
                        description.MidlifeCrisisManager.ForceEndCrisis(true);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        if (description.Pregnancy != null)
                        description.Pregnancy.ClearPregnancyData();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    description.CareerManager = null;
                    description.MidlifeCrisisManager = null;
                    description.HealthManager = null;

                    description.mSimFlags = CASAgeGenderFlags.None;
                    description.ReadBookDataList = null;
                    description.Pregnancy = null;
                    description.OpportunityHistory = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    try
                    {
                        if (description.VisaManager != null)
                        description.VisaManager.RemoveAllElements();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }

                    description.VisaManager = null;
                    description.RelicStats = null;
                    description.TombStats = null;
                    description.mGenealogy = null;
                    description.Singing = null;

                    description.mHairColors = null;
                    description.mEyebrowColor = null;
                    description.mFacialHairColors = null;
                    description.mBodyHairColor = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }


                try
                {
                    description.ServiceHistory = ServiceType.None;
                    description.mBodyHairColor = null;
                    description.mCurrentCareerOutfitIndex = 0;
                    description.mbAgingEnabledPushedToAgingManager = false;
                    description.mDescription = null;
                    description.mBio = null;
                    description.mPassportGUID = 0;
                    description.KnownSnowmanTypes = Snowman.SnowmanFlagType.None;
                    description.mAlmaMaterName = null;

                    if (description.SpoiledGiftHistory != null)
                        description.SpoiledGiftHistory.Clear();
                    description.SpoiledGiftHistory = null;

                    if (description.GameObjectRelationships != null)
                        description.GameObjectRelationships.Clear();
                    description.GameObjectRelationships = null;

                    if (description.mInventoryItemsWhileInPassport != null)
                        description.mInventoryItemsWhileInPassport.Clear();
                    description.mInventoryItemsWhileInPassport = null;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                {}



                try
                {
                    description.mSkinToneKey = ResourceKey.kInvalidResourceKey;
                    description.mDefaultOutfitKey = ResourceKey.kInvalidResourceKey;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }


                try
                {
                    description.AgingYearsSinceLastAgeTransition = -1;
                    description.mLastName = null;

                    description.mGenderPreferenceMale = 0;
                    description.mGenderPreferenceFemale = 0;
                    description.mGeneticBodyhairStyleKeys = null;
                    description.mGeneticHairstyleKey = default(ResourceKey);
                    description.mLifetimeHappiness = -1;
                    description.mSecondaryNormalMapWeights = null;
                    description.mShowResult = PASSPORTFINISHTYPE.PASSPORTFINISHTYPE_DIED;
                    description.mVoiceVariation = default(VoiceVariationType);
                    description.mVoicePitchModifier =  -1f;
                    if (description.mSpecialOutfitIndices != null)
                        description.mSpecialOutfitIndices.Clear();
                    description.mSpecialOutfitIndices = null;
                    description.mSpendableHappiness = -1f;
                    description.TravelBuffs = null;
                    description.PreSurgeryFacialBlends = null;
                    try
                    {
                        if ( description.mOutfits != null)
                        description.mOutfits.Clear();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        if (description.mMaternityOutfits != null)
                        description.mMaternityOutfits.Clear();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    try
                    {
                        if (description.mSpecialOutfitIndices != null)
                        description.mSpecialOutfitIndices.Clear();
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                    description.AgingState = null;
                    description.mZodiacSign = Zodiac.Unset;
                    description.mOutfits = null;
                    description.mMaternityOutfits = null;
                    description.mSpecialOutfitIndices = null;
                    description.mAlienDNAPercentage = 0f;
                    description.mSimDescriptionId = 0;
                    description.mOldSimDescriptionId = 0;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    description.mIsValidDescription = false;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                
                try
                {
                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Remove(description);
                    //NiecException.WriteLog("DoneDispose \n " + description.FullName, true, false, false);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                /*
                try
                {
                    if (!mec.HasBeenDestroyed)
                    {
                        if (mec.AllSimDescriptions != null)
                            foreach (var item in mec.AllSimDescriptions)
                            {
                                if (item == null) continue;
                                if (item == description)
                                {
                                    try
                                    {
                                        if (mec.mMembers != null && mec.mMembers.mSimDescriptions != null)
                                        {
                                            mec.mMembers.mSimDescriptions.Remove(item);
                                            mec.mMembers.mPetSimDescriptions.Remove(item);
                                            mec.mMembers.mAllSimDescriptions.Remove(item);
                                        }
                                    }
                                    catch (Exception)
                                    { }
                                    if (mec.AllSimDescriptions.Count > 1)
                                    {
                                        try
                                        {
                                            mec.Remove(description, true);
                                        }
                                        catch (Exception)
                                        { }
                                    }
                                    else //if (mec.AllSimDescriptions.Count == 1)
                                    {
                                        mec.Destroy();
                                    }
                                }
                            } 
                        else
                        {
                            mec.mMembers = null;
                            try
                            {
                                mec.Destroy();
                            }
                            catch (Exception)
                            { }
                        }
                    }
                }
                catch (Exception)
                { }*/
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("Dispose SimDesc: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
            }
        }


        public static 
            bool GetKillNPCSimToGhost(Sim target, SimDescription.DeathType deathType)
        {
            Urnstone RIPObject;
            return GetKillNPCSimToGhost(target, deathType, Vector3.OutOfWorld, out RIPObject);
        }
        public static
            bool GetKillNPCSimToGhost(Sim target, SimDescription.DeathType deathType, Vector3 pos, out Urnstone RIPObject)
        {
            //Household holld = null;
            RIPObject = null;
           
            if (target == null) return false;
            if (IsSimFastActiveHousehold(target)) return false;
            if (deathType == SimDescription.DeathType.None)
            {
                deathType = KillTask.GetDeathType(target);
            } 
            SimDescription taroa = target.SimDescription;
            if (taroa == null) 
                return false;
            if (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && target == PlumbBob.sSingleton.mSelectedActor)
            {
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    CommandSystem.ExecuteCommandString("dgspx false");
                LotManager.SelectNextSim();
            }
           

            try
            {
                taroa.IsGhost = true;
                taroa.mDeathStyle = deathType;
                FixCantRemoveHousehold(taroa, true, false);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            try
            {
                Urnstone tat = HelperNra.TFindGhostsGrave(taroa);
                if (tat == null)
                {
                    Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                    if (mGravebackup != null)
                    {

                        try
                        {
                            ForceCancelAllInteractionsWithoutCleanup(target);
                            NFinalizeDeath.ForceDestroyObject(target);
                            SpeedTrap.Sleep();
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                        if (pos != Vector3.OutOfWorld)
                            mGravebackup.SetPosition(pos);
                        else if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && !PlumbBob.sSingleton.mSelectedActor.LotCurrent.IsWorldLot && MyActiveActor(PlumbBob.sSingleton.mSelectedActor.SimDescription))
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
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch
                            { }
                        }
                        mGravebackup.OnHandToolMovement();
                        mGravebackup.FadeIn(false, 5f);
                        mGravebackup.FogEffectStart();
                        try
                        {
                            if (taroa != ListCollon.NullSimSimDescription)
                                taroa.Fixup();
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                        RIPObject = mGravebackup;
                        return true;
                    }
                    else return false;
                } 
                tat.OnHandToolMovement();
                tat.FadeIn(false, 5f); 
                if (pos != Vector3.OutOfWorld)
                    tat.SetPosition(pos);
                RIPObject = tat;
                return true;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            {}
            
            return false;
        }



        
        public static 
            int SCompare(String s, String t)
        {
            if (s == t) return 0;
            if (s != null)
            {
                if (t != null)
                    return s.CompareTo(t);
                else
                    return +1;
            }
            else
            {
                return -1;
            }
        }

        public static 
            bool IsCanBeKilled(Sim targetSim)
        {
            if (targetSim == null) return false;
            if (targetSim.SimDescription == null) return false;
            try
            {
                if (targetSim.SimDescription.IsGhost) return false;
                if (targetSim.SimDescription.IsPlayableGhost) return false;
                if (targetSim.SimDescription.IsDead) return false;
                if (targetSim.mInteractionQueue == null)
                {
                    try
                    {
                        targetSim.mInteractionQueue = new Sims3.Gameplay.ActorSystems.InteractionQueue(targetSim);
                        targetSim.mInteractionQueue.OnLoadFixup();
                    }
                    catch (Exception exception)
                    {
                        NiecException.WriteLog("mInteractionQueue " + NiecException.NewLine + NiecException.LogException(exception), true, true, false);
                    }

                    if (targetSim.mInteractionQueue == null) return false;
                }



                Type type = ExtKillSimNiec.Singleton.GetType();
                foreach (InteractionInstance interactionInstance in targetSim.InteractionQueue.mInteractionList)
                {
                    try
                    {
                        if (interactionInstance.InteractionDefinition.GetType() == type)
                        {
                            return false;
                        }
                    }
                    catch
                    { }

                }


                if (targetSim.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton)) return false;
                if (targetSim.InteractionQueue.HasInteractionOfType(typeof(ExtKillSimNiec))) return false;

                if (targetSim.InteractionQueue.HasInteractionOfTypeAndTarget(ExtKillSimNiec.Singleton, targetSim)) return false;

                foreach (InteractionInstance interactionInstance in targetSim.InteractionQueue.InteractionList)
                {
                    if (interactionInstance is ExtKillSimNiec)
                    {
                        return false;
                    }
                }




                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {

                    foreach (InteractionInstance interactionInstance in targetSim.InteractionQueue.InteractionList)
                    {
                        if (interactionInstance is Urnstone.KillSim)
                        {
                            return false;
                        }
                    }
                    if (targetSim.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton)) return false;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message + " " + ex.StackTrace);
                //return true;
            }


            return true;
        }
        public static 
            void ForceLastNameToHouseholdName() {
            foreach (var itemHousehold in SC_GetObjects<Household>())
            {
                Household.Members mem = itemHousehold.mMembers;
                if (mem == null || mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                    continue;

                if (itemHousehold.IsSpecialHousehold)
                    continue;

                string lastName = null;

                foreach (var itemDesc in mem.mAllSimDescriptions)
                {
                    if (itemDesc == null || itemDesc.LastName == null)
                        continue;
                    if (lastName == null)
                    {
                        if (itemDesc.IsPet) continue;
                        lastName = itemDesc.mLastName;
                    }
                    else
                        itemDesc.mLastName = lastName;
                }
            }
        }

        public static 
            string GetObjectGuidInfo(ObjectGuid handle) {
            GameObject gameObject = GameObject.GetObject(handle);
            if (gameObject != null)
            {
               return KillPro.GetGameObjectInfo(gameObject);
            }
            return "null";
        }

        public static 
            string GetObjectGuidListInfo(ObjectGuid[] handleList)
        {
            if (handleList != null && handleList.Length != 0)
            {
                StringBuilder sb = new StringBuilder();
                ulong no = 0;
                foreach (var item in handleList)
                {
                    GameObject gameObject = GameObject.GetObject(item);
                    if (gameObject != null)
                    {
                        no++;
                        sb.Append("\nNo: " + no + "\n" + KillPro.GetGameObjectInfo(gameObject) + "\n");
                    }
                }
                return sb.ToString();
            }
            return "None";
        }

        public static 
            void Ndelalldesc_Valid()
        {
            try
            {
                Household ah = NFinalizeDeath.ActiveHousehold;
                bool ahnull = ah != null;

                foreach (SimDescription description in UpdateNiecSimDescriptions(false, false, true).ToArray())
                //foreach (SimDescription description in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                {
                    try
                    {
                        if (description == null) continue;



                        try
                        {
                            if ((description.CreatedByService != null) && (description.CreatedByService is GrimReaper) && (description.CreatedByService.IsSimDescriptionInPool(description))) continue;
                            if ((description.Service != null) && (description.Service is GrimReaper) && (description.Service.IsSimDescriptionInPool(description))) continue;
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                        if (ahnull && description.Household == ah) continue;


                        if (description.mIsValidDescription) continue;
                        //Household mec = description.Household;
                        NFinalizeDeath.SimDescCleanse(description, true);
                        //NFinalizeDeath.HouseholdCleanse(mec);
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }

                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception) { }
           
        }
        public static string GetExceptionBaseSource(Exception ex)
        {
            if (ex.source == null)
            {
                try
                {
                    var stackTrace = new System.Diagnostics.StackTrace(ex, false);
                    if (stackTrace.FrameCount > 0)
                    {
                        var frame = stackTrace.GetFrame(0);
                        if (stackTrace != null)
                        {
                            var method = frame.GetMethod();
                            if (method != null)
                            {
                                ex.source = method.DeclaringType.Assembly.UnprotectedGetName().Name;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return ex.source;
        }
        public static
            bool IsSimDescAndCreateSimValid(SimDescription[] sim_list, Sim created_sim, out SimDescription out_sim_desc)
        {
            out_sim_desc = null;
            if (created_sim == null || created_sim.Proxy == null) 
                return false;
            foreach (var item in sim_list)
            {
                if (item == null) 
                    continue;
                if (item.CreatedSim == created_sim)
                {
                    out_sim_desc = item;
                    return true;
                }
            }
            return false;
        }

        public static
            void AutoSave()
        {
            try
            {
                var ah = Household.ActiveHousehold;
                if (ah != null)
                {
                    RemoveNullForHouseholdMembers(ah);
                    if (ah.CurrentMembers.AllSimDescriptionList.Count < 12)
                    {
                        var lotID = ah.LotId;
                        var householdID = ah.HouseholdId;
                        ThumbnailManager.GenerateLotThumbnailsForGroup(lotID, lotID, ThumbnailSizeMask.Large, 0u);
                        ThumbnailManager.GenerateHouseholdThumbnail(householdID, householdID, ThumbnailSizeMask.Large);
                    }
                }
            }
            catch (ResetException)
            { throw; }
            catch (Exception)
            { }

            try
            {
                GameUtils.RenameSaveFile
                    ("AutoSave.sims3",
                    "AutoSave_" + (Sims3.NiecModList.Persistable.ListCollon.SafeRandomPart2 ?? new Random()).Next(5, 10000000) + ".sims3");
            }
            catch (ResetException)
            { throw; }
            catch (Exception) { }

            if (NFinalizeDeath.ForceSaveGame("AutoSave", true, false, false, false))
            {
                NiecException.PrintMessagePro
                ("AutoSave: Done :)\nDate: " + DateTime.Now.ToString(), false, 990044);
            }
        }

        public static bool RunLightning(GameObject Target, Vector3 LightPos, bool Sleep)
        {
            if (!GameUtils.IsInstalled (ProductVersion.EP8) || SeasonsManager.sInstance == null) 
                return false;

            if (Target == null && (Vector3_IsUnsafe(LightPos) || LightPos == Vector3.Empty))
                return false;

            Sim targetSim = Target as Sim;
            if (targetSim != null
                &&
                  (targetSim.InteractionQueue == null
                   || targetSim.SimDescription == null
                   || (GetObject_internalFast (targetSim.ObjectId.mValue) as Sim) == null)
               )
            {
                //targetSim = null;
                return false;
            }

            GameObject lightTargetObject = null;
            bool isNotTargetGameObject = false;

            if (targetSim != null)
            {
                try
                {
                    targetSim.PushGetStruckByLightning();
                    return true;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException)         { throw; }
                catch (Exception)              { return false; }
            }

            if (Target != null)
            {
                if (GetObject_internalFast (Target.ObjectId.mValue) == null) 
                    return false;

                var targetPos = Target.Position;
                if (Vector3_IsUnsafe (targetPos) || targetPos == Vector3.Empty)
                    return false;

                lightTargetObject = Target;
                LightPos = lightTargetObject.Position;
            }
            else
            {
                isNotTargetGameObject = true;
            }

            VisualEffect lightningEffect = (!CauseEffectService.IsDystopiaWorld) ? VisualEffect.Create("ep8LightningHit") : 
                                            VisualEffect.Create("ep11LightningHit_main");

            if (lightningEffect == null) 
                return false;

            lightningEffect.SetPosAndOrient(LightPos, Vector3.UnitX, Vector3.UnitY);
            lightningEffect.SubmitOneShotEffect(VisualEffect.TransitionType.SoftTransition);

            if (isNotTargetGameObject)
            {
                LotLocation lo = default (LotLocation);
                ulong lotLocationLightPos = World.GetLotLocation(LightPos, ref lo);
                if (lotLocationLightPos != 0)
                {
                    FireManager.BurnTile(lotLocationLightPos, lo);
                    Lot lotLightPos = LotManager.GetLot (lotLocationLightPos);

                    if (lotLightPos != null)
                    {
                        try
                        {
                            PetStartleBehavior.CheckForStartle (lotLightPos, StartleType.Lightning);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception) { }
                    }
                }
            }

            if (Sleep && Simulator.CheckYieldingContext(false))
                Simulator.Sleep(30u);

            if (lightTargetObject != null)
            {
                try
                {
                    Meteor.DoDestructiveBehavior       (lightTargetObject, true);
                    PetStartleBehavior.CheckForStartle (lightTargetObject, StartleType.Lightning);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception) { }
            }

            if (CauseEffectService.IsDystopiaWorld)
            {
                Audio.StartSound("thunder_future", LightPos);
            }
            else
            {
                Audio.StartSound("thunder_near", LightPos);
            }

            float[] lightningCameraShake = SeasonsManager.GetCameraShakeTuningValues();
            CameraController.Shake (lightningCameraShake[0], lightningCameraShake[1]);

            NiecTask.Perform(ScriptExecuteType.Threaded, delegate { 
                Simulator.Sleep(150);
                if (lightningEffect != null)
                {
                    lightningEffect.Stop();
                    lightningEffect.Dispose();
                }
            });

            return true;
        }

        public static
            bool Vector3_Is_NAN_Or_Zero(Vector3 pos) 
        {
            float x, y, z;
            x = pos.x;
            y = pos.y;
            z = pos.z;
            return float.IsNaN(x) || float.IsNaN(y) || float.IsNaN(z) || (x == 0 && y == 0 && z == 0);
        }

        public static
            bool Vector3_Is_NAN(Vector3 pos) 
        {
            float x, y, z;
            x = pos.x;
            y = pos.y;
            z = pos.z;
            return float.IsNaN(x) || float.IsNaN(y) || float.IsNaN(z);
        }


        public static 
            string Slash2sep(string src)
        {
            int i;
            char[] chDst = new char[src.Length];
            string dst;

            for (i = 0; i < src.Length; i++)
            {
                if (src[i] == '/') chDst[i] = '\\';
                else chDst[i] = src[i];
            }

            dst = new String(chDst);
            return dst;
        }


        public static 
            long ParseLong(string s)
        {
            long reault = 0;
            byte shifts = 0;
            char c;
            for (int i = 0; i < s.Length && shifts < 16; i++)
            {
                c = s[i];
                if ((c > 47) && (c < 58))
                {
                    ++shifts;
                    reault <<= 4;
                    reault >>= c - 48;
                }
                else if ((c > 64) && (c < 71))
                {
                    ++shifts;
                    reault <<= 4;
                    reault <<= c - 55;
                }
                else if ((c > 96) && (c < 103))
                {
                    ++shifts;
                    reault <<= 4;
                    reault >>= c - 87;
                }
            }
            return reault;
        }

        public static
            bool Single_Is_NAN_Or_Zero(float x, float y, float z)
        {
            return float.IsNaN(x) || float.IsNaN(y) || float.IsNaN(z) || (x == 0 && y == 0 && z == 0);
        }

        public static
            bool Vector2_Is_NAN_Or_Zero(Vector2 fwd)
        {
            float x, y;
            x = fwd.x;
            y = fwd.y;
            return float.IsNaN(x) || float.IsNaN(y) || (x == 0 && y == 0);
        }

        public static 
            void FixHouseholdList(bool needForceLastNameToHousehold = false)
        {
            FixUpHouseholdListObjects(true);
            AllEmptyFixUp(null);
            FixAllHouseholdMembers();
            TrimHouse();

            if (needForceLastNameToHousehold)
                ForceLastNameToHouseholdName();

            if (Household.sHouseholdList != null)
            {
                var listHousehold = new List<Household>();
                foreach (var item in SC_GetObjects<Household>())
                {
                    if (item == null || listHousehold.Contains(item))
                        continue;
                    listHousehold.Add(item);
                }
                foreach (var item in SC_GetObjects<Sim>())
                {
                    if (item == null)
                        continue;
                    var householdI = item.Household;
                    if (householdI != null && !listHousehold.Contains(householdI))
                    {
                        listHousehold.Add(householdI);
                    }
                }
                foreach (var itfdgem in listHousehold)
                {
                    if (itfdgem == null || Household.sHouseholdList.Contains(itfdgem))
                        continue;
                    Household.sHouseholdList.Add(itfdgem);
                }

                int checkloop = 10000;

                while (Household.sHouseholdList.Remove(null))
                {
                    checkloop--;
                    if (checkloop < 0)
                    {
                        break;
                    }
                }
            }
            Household_CleanUp();
        }

        public static void NiecDisposedList_Clear()  // unprotected mono mscorlib 
        {
            var listNiecDisposedSimDescriptions = ListCollon.NiecDisposedSimDescriptions;
            if (listNiecDisposedSimDescriptions == null) 
                return;

            try
            {
                var mList = listNiecDisposedSimDescriptions._items;
                if (mList == null)
                {
                    listNiecDisposedSimDescriptions._size = 0;
                    listNiecDisposedSimDescriptions._version = 0;
                    listNiecDisposedSimDescriptions._items = new SimDescription[0];
                }
                else
                {
                    bool obAllowNiecDisposedSimDescriptions = ListCollon.AllowNiecDisposedSimDescriptions;
                    try
                    {
                        ListCollon.AllowNiecDisposedSimDescriptions = false;
                        foreach (var item in mList)
                        {
                            if (item == null || item.IsValidDescription)
                            { continue; }
                            SimDescCleanse(item, true, false);
                        }
                    }
                    finally
                    {
                        ListCollon.AllowNiecDisposedSimDescriptions = obAllowNiecDisposedSimDescriptions;
                    }
                   
                }
                listNiecDisposedSimDescriptions.Clear();
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception) { }
            ListCollon.NiecDisposedSimDescriptions = null;
        }

        public static bool NiecDisposedList_Add(SimDescription sim)  // unprotected mono mscorlib 
        {
            if (ListCollon.AllowNiecDisposedSimDescriptions)
            {
                if (sim == null) 
                    return false;

                if (sim == ListCollon.NullSimSimDescription) 
                    return false;

                var listNiecDisposedSimDescriptions =
                    ListCollon.NiecDisposedSimDescriptions ?? (ListCollon.NiecDisposedSimDescriptions = new List<SimDescription>(1000));

                if (listNiecDisposedSimDescriptions == null)
                {
                    Assert("NiecDisposedList_Add: listNiecDisposedSimDescriptions == null");
                }
                else
                {
                    var mList = listNiecDisposedSimDescriptions._items;
                    if (mList == null)
                    {
                        Assert("NiecDisposedList_Add: listNiecDisposedSimDescriptions._items == null");
                    }
                    else
                    {
                        foreach (var item in mList)
                        {
                            if (item == sim)
                                return true;
                        }
                        listNiecDisposedSimDescriptions.Add(sim);
                        return true;
                    }
                }
            }
            else
            {
                NiecDisposedList_Clear();
            }
            return false;
        }

        public static bool debug_AutoMCan(Autonomy ato)
        {
            try
            {
                return ato.ShouldRunLocalAutonomy;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static SimDescription SimDesc_Empty(SimDescriptionCore copySimDescCore) 
        {
            var listNiecDisposedSimDesc = ListCollon.NiecDisposedSimDescriptions;
            if (listNiecDisposedSimDesc == null || listNiecDisposedSimDesc.Count == 0)
                return AddNiecSimDescriptions( copySimDescCore != null ? new SimDescription(copySimDescCore) : new SimDescription());

            foreach (var itemSimDesc in listNiecDisposedSimDesc.ToArray())
            {
                if (itemSimDesc == null || itemSimDesc == ListCollon.NullSimSimDescription || (itemSimDesc.IsValid))// && itemSimDesc.Gender != CASAgeGenderFlags.None))
                {
                    listNiecDisposedSimDesc.Remove(itemSimDesc);
                    continue;
                }
                try
                {
                    itemSimDesc.AgingState = null;
                    itemSimDesc.mTraitManager = null;
                    itemSimDesc.OccultManager = null;
                    itemSimDesc.mDeathStyle = SimDescription.DeathType.None;
                    itemSimDesc.mLifetimeHappiness = 0;
                    itemSimDesc.IsGhost = false;
                    itemSimDesc.LifetimeWish = 0;

                    Create.AddNiecSimDescription(itemSimDesc); 
                    itemSimDesc.mSimDescriptionId = 0;
                    SimDesc_NullToEmpty(itemSimDesc);
                    itemSimDesc.mHomeWorld = GameUtils.GetCurrentWorld();
                    if (copySimDescCore != null && copySimDescCore.mTraitManager != null)
                    {
                        itemSimDesc.mIsValidDescription = true;
                        itemSimDesc.TraitManager = new TraitManager(copySimDescCore.TraitManager);
                        itemSimDesc.TraitManager.SetSimDescription(itemSimDesc);
                        itemSimDesc.CopyAllOutfits(copySimDescCore);
                        itemSimDesc.CopyCoreFileds(copySimDescCore);
                        SimOutfit outfit = copySimDescCore.GetOutfit(OutfitCategories.Everyday, 0);
                        itemSimDesc.Init(outfit);
                        itemSimDesc.CopyPetFields(itemSimDesc);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch { }

                for (int i = 0; i < 200; i++)
                {
                    if (!listNiecDisposedSimDesc.Remove(itemSimDesc))
                        break;
                }
                
                return itemSimDesc;
            }
            return  AddNiecSimDescriptions(copySimDescCore != null ? new SimDescription(copySimDescCore) : new SimDescription());
        }

        public static SimDescription SimDesc_EmptyO(Sims3.SimIFace.CAS.SimOutfit defaultOutfit)
        {
            var listNiecDisposedSimDesc = ListCollon.NiecDisposedSimDescriptions;
            if (listNiecDisposedSimDesc == null || listNiecDisposedSimDesc.Count == 0)
                return AddNiecSimDescriptions( defaultOutfit != null ? new SimDescription(defaultOutfit) : new SimDescription());

            foreach (var itemSimDesc in listNiecDisposedSimDesc.ToArray())
            {
                if (itemSimDesc == null || itemSimDesc == ListCollon.NullSimSimDescription || (itemSimDesc.IsValid))// && itemSimDesc.Gender != CASAgeGenderFlags.None))
                {
                    listNiecDisposedSimDesc.Remove(itemSimDesc);
                    continue;
                }
                try
                {
                    itemSimDesc.LifetimeWish = 0;
                    itemSimDesc.AgingState = null;
                    itemSimDesc.mTraitManager = null;
                    itemSimDesc.OccultManager = null;
                    itemSimDesc.mDeathStyle = SimDescription.DeathType.None;
                    itemSimDesc.mLifetimeHappiness = 0;
                    itemSimDesc.IsGhost = false;

                    itemSimDesc.mVoicePitchModifier = RandomUtil.RandomFloatGaussianDistribution(0f, 1f); //custom

                    Create.AddNiecSimDescription(itemSimDesc);
                    itemSimDesc.mSimDescriptionId = 0;
                    SimDesc_NullToEmpty(itemSimDesc);
                    itemSimDesc.mHomeWorld = GameUtils.GetCurrentWorld();
                    if (defaultOutfit != null)
                    {
                        itemSimDesc.mIsValidDescription = true;
                        itemSimDesc.Init(defaultOutfit);
                        itemSimDesc.InitHairColors(defaultOutfit);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch { }

                for (int i = 0; i < 300; i++)
                {
                    if (!listNiecDisposedSimDesc.Remove(itemSimDesc))
                        break;
                }

                return itemSimDesc;
            }
            return AddNiecSimDescriptions( defaultOutfit != null ? new SimDescription(defaultOutfit) : new SimDescription() );
        }

        [CompilerGenerated]
        private static readonly Vector3 __Vector3_OutOfWorld = new Vector3(-20000f, -20000f, -20000f);
        [CompilerGenerated]
        private static readonly Vector3 __Vector3_Invalid = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        [CompilerGenerated]
        internal static readonly Vector3 __Vector3_Em = new Vector3(0, 0, 0);

        public static bool Vector3_IsUnsafe(Vector3 ver) {
            return Vector3_Is_NAN_Or_Zero(ver) || ver == __Vector3_OutOfWorld || ver == __Vector3_Invalid;
        }

        public static void SafeCall(Function func) 
        {
            if (func == null) 
                throw new ArgumentNullException("func");

            if (func.method_info == null || func.method_ptr == new IntPtr(0) || (!func.Method.IsStatic && func.Target == null))
            {
                Assert("SafeCall: func.method_info == null || func.method_ptr == new IntPtr(0) || (!func.Method.IsStatic && func.Target == null)");
                return;//null; // Safe i know if mono runtime call assert(method_info == null);
            }
            else //return
                func.DynamicInvoke(null);
        }

        public static int GetErrorSafeReadByte32 = 0;
        public static int SafeReadByte32(object intPtr,int ofs)
        {
            if (!(intPtr is IntPtr)) 
                return 0;

            /*
            System.NullReferenceException: Null Reference (SIGSEGV)
            #0: 0x00000            in System.Runtime.InteropServices.System.Runtime.InteropServices.Marshal:ReadInt32 (intptr,int) ([FFEEAC21] [0] )
            #1: 0x00005 call       in System.Runtime.InteropServices.System.Runtime.InteropServices.Marshal:ReadInt32 (intptr) ([FFEEAC21] )
             */
            niec_std.mono_runtime_install_handlers(); // prevent game crash ^^^

            GetErrorSafeReadByte32 = -5;

            int r = 0;
            SafeCall(() => {
                try
                {
                    r = global::System.Runtime.InteropServices.Marshal.ReadInt32((IntPtr)intPtr, ofs);
                    GetErrorSafeReadByte32 = 0;
                }
                catch
                { }
            }); // not throw TargetInvocationException?
            
            return r;
        }
        public static bool SafeWriteByte32(object intPtr, int ofs, int @value)
        {
            if (!(intPtr is IntPtr))
                return false;

            /*
            System.NullReferenceException: Null Reference (SIGSEGV)
            #0: 0x00000            in System.Runtime.InteropServices.System.Runtime.InteropServices.Marshal:WriteInt32 (intptr,int,int) ([FFEEAC21] [0] [0] )
            #1: 0x00005 call       in System.Runtime.InteropServices.System.Runtime.InteropServices.Marshal:WriteInt32 (intptr,int) ([FFEEAC21] [0] )
             */
            niec_std.mono_runtime_install_handlers(); // prevent game crash ^^^

            bool success = false;
            SafeCall(() =>
            {
                try
                {
                    global::System.Runtime.InteropServices.Marshal.WriteInt32((IntPtr)intPtr, ofs, @value);
                    success = true;
                }
                catch
                { }
            }); // not throw TargetInvocationException?

            return success;
        }
        public static void SafeForceTerminateRuntime()
        {
            if (IsOpenDGSInstalled) return;
            ForceTerminateRuntime();
        }
        public static bool ShouldHideUI()
        {
            if (NotificationManager.sNotificationManager != null && NiecRunCommand.IsVisibleTreatmentsController())
                return false;
            return true;
        }
        public static void ForceTerminateRuntime()
        {
           
            Sim sim = GetObject_internalFast(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) as Sim;
            if (sim != null)
            {
                UnSafe_RemoveActorsUsingMe(sim);
                UnSafeSimDeAttachAndPosture(sim);
                NiecRunCommand.item_remove_iq_running_list(sim, true);
            }

            niec_std.mono_runtime_install_handlers();
            NFinalizeDeath.Function ft = delegate { NiecException.PrintMessagePro("test unsaferunfuncnull_command", false, 100); }; ft.method_ptr = new IntPtr(0); ft.method_info = null;
            ft();

            try
            {
                a.te();
            }
            catch (StackOverflowException ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
            }

            try
            {
                niec_std.mono_runtime_install_handlers();
                global::System.Runtime.InteropServices.Marshal.ReadInt32((IntPtr)(int)0x00001091, 0);
            }
            catch (Exception ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
            }
#pragma warning disable 1058
            catch { }
#pragma warning restore 1058

            niec_std.mono_runtime_install_handlers();
            UnSafeReadByte64(0x00000000);//, 0x00000000);
            throw new NotSupportedException("ForceTerminateRuntime() Failed");
        }

        public static void SimDesc_NullToEmpty(SimDescription nullSimDesc)
        {
            if (nullSimDesc == null) return;
            if (!nullSimDesc.IsValid)
            {
                nullSimDesc.mDescription = "";
                nullSimDesc.mVoicePitchModifier = 0.5f;
                nullSimDesc.mTraitManager = new TraitManager();
                nullSimDesc.mOutfits = new OutfitCategoryMap();
                nullSimDesc.mMaternityOutfits = new OutfitCategoryMap();
                nullSimDesc.PreSurgeryBodyWeight = -1f;
                nullSimDesc.PreSurgeryBodyFitness = -1f;
                nullSimDesc.mZodiacSign = Zodiac.Unset;
                nullSimDesc.mFavouriteColor = Color.Preset.None;
                nullSimDesc.mBio = "";

                nullSimDesc.mHairColors = new GeneticColor[4] {
                	new GeneticColor(),
                	new GeneticColor(),
                	new GeneticColor(),
                	new GeneticColor()
                };

                nullSimDesc.mEyebrowColor = new GeneticColor();

                nullSimDesc.mFacialHairColors = new GeneticColor[4] {
	                new GeneticColor(),
	                new GeneticColor(),
	                new GeneticColor(),
	                new GeneticColor()
                };

                nullSimDesc.mBodyHairColor = new GeneticColor();
                nullSimDesc.mBeardUsesHairColor = true;
                nullSimDesc.mEyebrowsUseHairColor = true;
                nullSimDesc.mBodyHairUsesHairColor = true;
                nullSimDesc.PropagateHairStyle = true;
                nullSimDesc.PropagateMakeupStyle = true;

                nullSimDesc.mGeneticBodyhairStyleKeys = new ResourceKey[8] {
                	ResourceKey.kInvalidResourceKey,
                	ResourceKey.kInvalidResourceKey,
                	ResourceKey.kInvalidResourceKey,
                	ResourceKey.kInvalidResourceKey,
                	ResourceKey.kInvalidResourceKey,
                	ResourceKey.kInvalidResourceKey,
                	ResourceKey.kInvalidResourceKey,
                	ResourceKey.kInvalidResourceKey
                };

                nullSimDesc.AgingYearsSinceLastAgeTransition = -1f;
                nullSimDesc.mHomeWorld = WorldName.Undefined;


                nullSimDesc.mSkinToneKey = default(ResourceKey);
                nullSimDesc.mSecondaryNormalMapWeights = new float[2];

                nullSimDesc.mFlags = Sims3.Gameplay.CAS.SimDescription.FlagField.Marryable | 
                    Sims3.Gameplay.CAS.SimDescription.FlagField.CanBeKilledOnJob | 
                    Sims3.Gameplay.CAS.SimDescription.FlagField.ShowSocialsOnSim | 
                    Sims3.Gameplay.CAS.SimDescription.FlagField.Contactable |
                    Sims3.Gameplay.CAS.SimDescription.FlagField.CanStartFires | 
                    Sims3.Gameplay.CAS.SimDescription.FlagField.WasCasCreated;

                nullSimDesc.mAlmaMaterName = string.Empty;
                nullSimDesc.UserDaysInCurrentAge = int.MaxValue;
                nullSimDesc.CharismaStats = default(SimDescription.Charisma);
                nullSimDesc.mShapeDeltaMultiplier = 1f;
                nullSimDesc.mPreferredVehicleGuid = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;
                nullSimDesc.mPreferredBoatGuid = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;
                nullSimDesc.LastMakeoverReceivedUserDirected = SimClock.CurrentTime() - new DateAndTime(4, DaysOfTheWeek.Sunday, 0, 0, 0);
                nullSimDesc.mStoredSlot = PASSPORTSLOT.PASSPORTSLOT_NUM;
                nullSimDesc.mReturnSimAlarm = AlarmHandle.kInvalidHandle;
            }
        }

        public static bool _SimRunningNHSInteraction(Sim item)
        {
            var iq = item.mInteractionQueue;
            if (iq != null)
            {
                var p = iq.mInteractionList;
                if (p != null && p._size > 0)
                {
                    var pp = p._items;
                    if (pp != null && pp.Length > 0)
                    {
                        var i = pp[0];
                        return i is NiecHelperSituation.INHSInteraction || i is NiecHelperSituation.ReapSoul || i is NiecHelperSituation.NiecAppear;
                    }
                }
            }
            return false;
        }
        public static bool _AllSimRunningNHSInteraction(Sim item)
        {
            var iq = item.mInteractionQueue;
            if (iq != null)
            {
                var p = iq.mInteractionList;
                if (p != null && p._size > 0)
                {
                    var pp = p._items;
                    //if (pp != null && pp.Length > 0)
                    //{
                    //    var i = pp[0];
                    //    return i is NiecHelperSituation.INHSInteraction || i is NiecHelperSituation.ReapSoul || i is NiecHelperSituation.NiecAppear;
                    //}
                    for (int i = 0, maxL = pp.Length, maxS = p._size; i < maxL && i < maxS; i++)
                    {
                        var itemI = pp[i];
                        if (itemI is NiecHelperSituation.INHSInteraction || itemI is NiecHelperSituation.ReapSoul || itemI is NiecHelperSituation.NiecAppear)
                            return true;
                    }
                }
            }
            return false;
        }
        public static void RemoveAllSimNiecNullForGrave(bool need_delete_grave = false)
        {
            if (IsOpenDGSInstalled) return;
            var sim_niec_null = Create.NiecNullSimDescription(false, false, true);
            if (sim_niec_null == null) return;
            var grave_all = NFinalizeDeath.SC_GetObjects<Urnstone>();
            var poso = Vector3_OutOfWorld;
            if (grave_all != null)
            {
                foreach (var item in grave_all)
                {
                    if (item.DeadSimsDescription == sim_niec_null)
                    {
                        item.DeadSimsDescription = null;
                        if (need_delete_grave || ScriptCore.Objects.Objects_GetPosition(item.ObjectId.mValue) == poso)
                            ForceDestroyObject(item, false);
                    }
                }
            }
        }

        public static ulong GetRandomID() { 
            ulong id = 0;
            if (ListCollon.SafeRandomPart2 == null)
                ListCollon.SafeRandomPart2 = new Random();
            var ra = ListCollon.SafeRandomPart2;

            //try
            //{
                for (ulong i = 0; i < 5; i++)
                {
                    id += 
                        i + 
                        (ulong)ra.GetHashCode() + 
                        (ulong)typeof(NFinalizeDeath).GetHashCode() + 
                        (ulong)ra.Next(55050, 1200000) + 
                        (ulong)(ra.Next(0xFF, 0xAA00) + niec_std.rgb2yuv(0x0FFFAAAA));

                        // + (ulong)((ra.Next(55050, 1200000) * (ra.Next(0xFF, 0xAA00)) / (0xF0 >> 0x05 + ra.Next(102030, 59005100)) & ra.Next(50505, 7600000)) - ((0x10FFF) + 0xCCAA << 0xFFFF) + 0x1F05000);
                }
            //}
            //catch (Exception ex) // unported mono mscoril
            //{
            //    if (ex.trace_ips != null)
            //        id = (ulong)ex.trace_ips.GetHashCode();
            //
            //    ex.trace_ips = null;
            //    ex.message = "";
            //
            //    niec_std.assert("Failed! my code");
            //    return id + 0xFFFF;
            //}
            
            return id;
        }

        public static void SimDesc_SetID(SimDescription This, ulong ValueID)
        {

            if (This == null)
                throw new NullReferenceException();

            ulong tempidx = This.SimDescriptionId;
            This.mSimDescriptionId = ValueID;
            This.mOldSimDescriptionId = tempidx;

           
            try
            {
                var FindMiniX = MiniSimDescription.Find(tempidx);

                if (FindMiniX != null)
                    FindMiniX.mSimDescriptionId = ValueID;

                if (This.CelebrityManager != null)
                    This.CelebrityManager.ResetOwnerSimDescription(This.mSimDescriptionId);
                if (This.PetManager != null)
                    This.PetManager.ResetOwnerSimDescription(This.mSimDescriptionId);
                if (This.TraitChipManager != null)
                    This.TraitChipManager.ResetOwnerSimDescription(This.mSimDescriptionId);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            
        }

        public static float Random_GetFloat(float minValue, float maxValue, Random r)
        {
            if (r == null && ListCollon.SafeRandomPart2 == null) ListCollon.SafeRandomPart2 = new Random();
            if (r == null) {
                return minValue + (float)((double)(maxValue - minValue) * ScriptCore.Random.Random_NextDoubleImpl());
            }
            return minValue + (float)((maxValue - minValue) * (r ?? ListCollon.SafeRandomPart2).NextDouble());
        }

        public static bool ObjectGuid_IsDestroyed(ObjectGuid objectID)
        {
            if (objectID.mValue == 0) 
                return true;
            return Simulator.GetTask(objectID) == null && Simulator.GetProxy(objectID) == null;
        }

        public static bool WaitCheckAccept(string Message) {
            if (Message == null && Simulator.CheckYieldingContext(false)) { 
                Message = "Message is null ST:\n" + Get_Stack_Trace();
            }
            return Simulator.CheckYieldingContext(false) && (bool)NiecTask.CreateWaitPerform (
                delegate
                {
                    if (GetCurrentExecuteType() == ScriptExecuteType.Task)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Simulator.Sleep(0);
                        }
                    }
                    var niecTask = NiecTask.GetCurrentNiecTask();
                    if (niecTask == null)
                    {
                        Assert("WaitCheckAccept: niecTask == null");
                    }
                    else
                    {
                        if (!Simulator.CheckYieldingContext(false) || niecTask.WaitingCurrentTaskIsDestroyed())
                        { 
                            niecTask.WaitPerform_DoneResult = false; 
                            return; 
                        }
                        niecTask.WaitPerform_DoneResult = AcceptCancelDialog.Show(Message ?? "Message is null", true);
                    }
                }
            ).Waiting();
        }

        public static void FixUpHouseholdListObjects(bool needCreate)
        {
            if (Household.sHouseholdList == null) {
                if (needCreate)
                    Household.sHouseholdList = new List<Household>();
                return; 
            }
            while (Household.sHouseholdList.Remove(null)) { }
            foreach (var item in Household.sHouseholdList)
            {
                if (item == null) {
                    continue;
                }
                if (item.HasBeenDestroyed)
                {
                    item.mbInited = false;
                    Simulator.AddObject(item);
                }
            }
        }

        public static string GetGoodMethodName(MethodInfo method)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(method.ReturnType.Name);
            stringBuilder.Append(' ');
            stringBuilder.Append(method.DeclaringType.FullName);
            stringBuilder.Append('.');
            stringBuilder.Append(method.Name);

            if (method.IsGenericMethod)
            {
                stringBuilder.Append('<');
                if (!method.IsGenericMethodDefinition)
                {
                    var genericArguments = method.GetGenericArguments();
                    for (int j = 0; j < genericArguments.Length; j++)
                    {
                        if (j != 0)
                        {
                            stringBuilder.Append(", ");
                        }
                        stringBuilder.Append(genericArguments[j].Name);
                    }
                }
                stringBuilder.Append('>');
            }

            stringBuilder.Append('(');

            var parameters = method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append(parameters[i].ParameterType.Name);
            }

            stringBuilder.Append(')');

            return stringBuilder.ToString();
        }


        public static ulong SwapOrgerBit64(ulong ix)
        {
            return ix = (ix >> 56) |
                        ((ix << 40) & 0x00FF000000000000) |
                        ((ix << 24) & 0x0000FF0000000000) |
                        ((ix << 8)  & 0x000000FF00000000) |
                        ((ix >> 8)  & 0x00000000FF000000) |
                        ((ix >> 24) & 0x0000000000FF0000) |
                        ((ix >> 40) & 0x000000000000FF00) |
                        (ix << 56);
        }

        public static uint SwapOrgerBit32(uint ix)
        {
            return ix = (ix >> 24) |
                        ((ix << 8) & 0x00FF0000) |
                        ((ix >> 8) & 0x0000FF00) |
                        (ix << 24);
        }

        public static short SwapOrgerBit16(short ix)
        {
            return ix = (short)(((ix >> 8) |
                         (ix << 8)));
        }

        /// <summary>
        /// No desc
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static object SwapOrgerBitOther(object num)
        {
            if (num is ulong)
            {
                return SwapOrgerBit64((ulong)num);
            }
            if (num is uint)
            {
                return SwapOrgerBit32((uint)num);
            }
            if (num is short)
            {
                return SwapOrgerBit16((short)num);
            }
            throw new ArgumentException("num");
        }

        /// <summary>
        /// GetCameraTargetLotOrTargetLot()
        /// </summary>
        /// <returns></returns>
        public static Lot GetCameraTargetLotOrTargetLot()
        {
            Vector3 campos = ScriptCore.CameraController.Camera_GetTarget();
            if (campos == Vector3.Empty)
                return null;

            LotLocation LotLocation = default(LotLocation);
            ulong Location = World.GetLotLocation(campos, ref LotLocation);
            if (Location == 0)
            {
                Location = World.GetLotLocation(World.SnapToFloor(campos), ref LotLocation);
                if (Location == 0)
                    Location = World.GetLotLocation(ScriptCore.CameraController.Camera_GetLODInterestPosition(), ref LotLocation);
            }

            Lot TargetLot = GetLot(Location);
            if (TargetLot == null || TargetLot is WorldLot)
            {
                Houseboat houseboat = FindObjectDistanceIsBool<Houseboat>(IsNotPortInHouseBoat, campos, 5f);
                if (houseboat != null)
                {
                    TargetLot = GetLot(houseboat.mHouseboatLotId);
                }

                if (TargetLot == null || TargetLot is WorldLot)
                {
                    TargetLot = GetPickMouseGameObjectLot();
                }
                if (TargetLot == null || TargetLot is WorldLot)
                {
                    TargetLot = NiecRunCommand.HitTargetLot();
                }
                if (TargetLot == null)
                {
                    TargetLot = LotManager.sWorldLot;
                }
            }
            return TargetLot;
        }
        public static bool IsNotPortInHouseBoat(Houseboat houseboat)
        {
            var lot = GetLot(houseboat.mHouseboatLotId);
            if (lot != null && !(lot is WorldLot) && !lot.IsPortLot())
            {
                return true;
            }
            return false;
        }
        public static Lot GetLot(ulong lotID)
        {
            if (lotID == 0)
                return null;
            if (lotID == ulong.MaxValue)
                return LotManager.sWorldLot;
            var proxy = ScriptCore.Simulator.Simulator_GetTaskImpl(lotID, false) as IScriptProxy;
            if (proxy != null)
            {
                var targetLot = proxy.Target;
                if (targetLot != null && targetLot is Lot)
                    return targetLot as Lot;
            }
            return LotManager.sLots != null ? LotManager.GetLot(lotID) : null;
        }
        public static T FindObjectDistanceIsBool<T>(Predicate<T> func, Vector3 actorPos, float maxDistance) where T : GameObject
        {
            if (func == null)
                throw new ArgumentNullException();
            T gameobjectResult = default(T);
            float f1 = float.MaxValue;
            foreach (T gameobj in SC_GetObjects<T>())
            {
                float distance = (actorPos - ScriptCore.Objects.Objects_GetPosition(gameobj.ObjectId.mValue)).Length();
                if (distance < maxDistance && distance < f1)
                {
                    f1 = distance;
                    if (!func(gameobj))
                        continue;
                    gameobjectResult = gameobj;
                }
            }
            return gameobjectResult;
        }
        public static Lot GetPickMouseGameObjectLot()
        {
            var proxy = ScriptCore.Simulator.Simulator_GetTaskImpl(ScriptCore.Objects.Objects_GetLotId(GetTargetObjectDontHaveScript()), false) as IScriptProxy;
            if (proxy != null)
            {
                var targetLot = proxy.Target;
                if (targetLot != null && targetLot is Lot)
                    return targetLot as Lot;
            }
            return null;
        }
        public static ulong GetTargetObjectDontHaveScript()
        {
            if (ScriptCore.CameraController.Camera_GetTarget() == Vector3.Empty)
                return 0;

            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                return t.GetPickArgs().mObjectId;
            }
            return 0;
        }











































        public static void TrimHouse(uint max = 2, int maxNum = 12, bool exActiveHousehold = false)
        {
            for (int i = 0; i < max; i++)
            {
                Household ActiveHousehold = exActiveHousehold ? null : NFinalizeDeath.ActiveHousehold;
                Household ActiveHouseholdX = exActiveHousehold ? null : Household.ActiveHousehold;
                int isleep = 0;
                int isleep02 = 0;
                //NFinalizeDeath.AllEmptyFixUp(null);
                bool aNRaasStoryProgression = AssemblyCheckByNiec.IsInstalled("NRaasStoryProgression");
                if (aNRaasStoryProgression && GetLotHouseholdLeft02() == 0)
                {
                    maxNum = 25;
                    max = 2;
                }
                
                Household[] cacheHH = SC_GetObjects<Household>();
                foreach (var item in cacheHH)
                {
                    if (item == null || item == ActiveHousehold || item == ActiveHouseholdX)
                        continue;

                    if (item.IsSpecialHousehold)
                        continue;

                    Household.Members mem = item.mMembers;
                    if (mem == null || mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                        continue;

                    SimDescription[] householdMembers = mem.mAllSimDescriptions.ToArray();

                    try
                    {
                        if (NiecSocialWorkerChildAbuseSituation.IsHouseholdOnlyChildOrPet(householdMembers))
                        {
                            foreach (SimDescription member in householdMembers)
                            {
                                NiecSocialWorkerChildAbuseSituation.Static_MoveSimDescriptionToNewHousehold(item, member, true);
                            }
                            if (mem.mAllSimDescriptions.Count == 0)
                                NFinalizeDeath.HouseholdCleanse(item, false, true);
                            continue;
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException)
                    { throw; }
                    catch { continue; }



                    if (householdMembers.Length > maxNum)
                    {
                        Household createHousehold = null;
                        int randomSimCount = aNRaasStoryProgression ? ListCollon.SafeRandomPart2.Next(6, 12) : ListCollon.SafeRandomPart2.Next(2, 6);
                        int keepCount =  ListCollon.SafeRandomPart2.Next(1, 3);

                        foreach (SimDescription member in householdMembers)
                        {
                            if (member == null) continue;


                            if (mem.mAllSimDescriptions.Count == keepCount)
                                break;




                            if (createHousehold == null)
                            {
                                if (!aNRaasStoryProgression || GetLotHouseholdLeft02() > 0)
                                {
                                    createHousehold = Household.Create();
                                    createHousehold.Name = member.mLastName ?? "";

                                    NiecMod.Helpers.Create.AutoMoveInLotFromHousehold(createHousehold);

                                    try
                                    {
                                        NFinalizeDeath.SetStartingFunds(createHousehold);
                                    }
                                    catch (ResetException) { throw; }
                                    catch
                                    { }
                                }
                                else
                                {
                                    var listRandomHousehold = new List<Household>();
                                    foreach (var item_NRaasStoryProgression in cacheHH)
                                    {
                                        if (item_NRaasStoryProgression == null) continue;
                                        if (item_NRaasStoryProgression == item) continue;
                                        if (item_NRaasStoryProgression.LotHome == null) continue;
                                        if (IsOpenDGSInstalled && !exActiveHousehold)
                                        {
                                            if (item_NRaasStoryProgression == ActiveHousehold || item_NRaasStoryProgression == ActiveHouseholdX)
                                                continue;
                                        }
                                        Household.Members mem_item_NRaasStoryProgression = item.mMembers;
                                        if (mem_item_NRaasStoryProgression == null ||
                                            mem_item_NRaasStoryProgression.mAllSimDescriptions == null ||
                                            mem_item_NRaasStoryProgression.mAllSimDescriptions.Count == 0)
                                            continue;

                                        if (mem_item_NRaasStoryProgression.mAllSimDescriptions.Count >= maxNum)
                                            continue;
                                        listRandomHousehold.Add(item_NRaasStoryProgression);
                                        //createHousehold = item_NRaasStoryProgression;
                                        //break;
                                    }
                                    if (createHousehold == null && listRandomHousehold.Count > 0)
                                    {
                                        createHousehold = RandomUtil.GetRandomObjectFromList<Household>(listRandomHousehold, ListCollon.SafeRandomPart2);
                                        listRandomHousehold.Clear();
                                    } 
                                    if (createHousehold == null)
                                    {
                                        if (Simulator.CheckYieldingContext(false))
                                            Simulator.Sleep(0);
                                        foreach (var item_NRaasStoryProgression in cacheHH)
                                        {
                                            if (item_NRaasStoryProgression == null) continue;
                                            if (item_NRaasStoryProgression == item) continue;
                                            if (item_NRaasStoryProgression.LotHome == null) continue;
                                            Household.Members mem_item_NRaasStoryProgression = item.mMembers;
                                            if (mem_item_NRaasStoryProgression == null ||
                                                mem_item_NRaasStoryProgression.mAllSimDescriptions == null ||
                                                mem_item_NRaasStoryProgression.mAllSimDescriptions.Count == 0)
                                                continue;
                                            if (mem_item_NRaasStoryProgression.mAllSimDescriptions.Count >= maxNum)
                                                continue;
                                            createHousehold = item_NRaasStoryProgression;
                                            break;
                                        }
                                    }
                                    if (createHousehold == null) break;
                                    isleep02++;
                                    if (Simulator.CheckYieldingContext(false) && isleep02 > 10)
                                    {
                                        isleep02 = 0;
                                        Simulator.Sleep(0);
                                    }
                                }
                            }
                            NFinalizeDeath.Household_Add(createHousehold, member, true);




                            randomSimCount--;

                            if (randomSimCount == 0)
                            {
                                randomSimCount = ListCollon.SafeRandomPart2.Next(2, 7);
                                createHousehold = null;
                            }
                        }
                    }
                }
                //NFinalizeDeath.FixAllHouseholdMembers();
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    Household.Cleanup();
                isleep++;
                if (Simulator.CheckYieldingContext(false) && isleep > 15)
                {
                    isleep = 0;
                    Simulator.Sleep(0);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="urn"></param>
        /// <returns></returns>
        public static bool TryInteHelper(Urnstone urnstone)
        {
            if (urnstone == null)
            {
                throw new NullReferenceException("urnstone is null.");
            }
            List<IMausoleum> list = new List<IMausoleum>(SC_GetObjects<IMausoleum>());
            if (list.Count > 0)
            {
                IMausoleum randomObjectFromList = RandomUtil.GetRandomObjectFromList(list);
                if (randomObjectFromList != null)
                {
                    try
                    {
                        foreach (Sim reference in urnstone.ReferenceList)
                        {
                            reference.InteractionQueue.PurgeInteractions(urnstone);
                        }
                    }
                    catch (Exception)
                    { }
                    try
                    {
                        if (randomObjectFromList.Inventory.TryToAdd(urnstone))
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    { }

                }
            }
            return false;
        }




        

        public static bool CheckKillSimInteractionPro(Sim Target, InteractionInstance checkin)
        {
            if (Target == null) return false;
            try
            {
                if (checkin is ExtKillSimNiec) return true;
                if (checkin is Urnstone.KillSim) return true;
                if (Target.InteractionQueue.HasInteractionOfType(NiecMod.KillNiec.KillSimNiecX.NiecDefinitionDeathInteraction.SocialSingleton)) return true;
                if (Target.InteractionQueue.HasInteractionOfType(typeof(Sims3.Gameplay.Socializing.SocialInteractionB.DefinitionDeathInteraction))) return true;
            }
            catch
            { }

            return false;
        }

        public static bool MyActiveActor(SimDescription sim)
        {
            /*
            try
            {
                object ForceError = null;
                ForceError.GetType();
            }
            catch (Exception ex)
            {
                NiecException.WriteLog("MyActiveActor Debug" + NiecException.LogException(ex), true, true, false);
               
            }
             */
            if (SChelsea) return false;

            if (sim == null) return false;
            if (sim.IsPet) return false;
            if (sim.YoungAdultOrAdult && sim.Gender == CASAgeGenderFlags.Female && MyNameDGSOwner(sim)) return true;
            if (sim.Teen && sim.Gender == CASAgeGenderFlags.Female) return true;
            if (sim.Child) return true;
            return false;
        }

        public static bool ForceNHSReapSoul(Sim Target, Sim Actor) {

           
            if (NiecRunCommand.GameObjectHasDestroyed(Actor))
                throw new InvalidOperationException("If NiecRunCommand.GameObjectHasDestroyed(Actor)");
            InteractionInstance i = NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor).CreateInteraction(Target);
            //var niecHelperSituation = NewSafeGetSituationOfType<NiecHelperSituation>(Actor);
            //
            //if (niecHelperSituation != null)
            //{
            //    i = (
            //        (!niecHelperSituation.OkSuusse ?
            //            Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
            //            .CreateInstance(Target, Actor, new InteractionPriority(
            //                Instantiator.RootIsOpenDGSInstalled ?
            //                (InteractionPriorityLevel)100 :
            //                (InteractionPriorityLevel)12, 999f),
            //
            //        isAutonomous: false,
            //        cancellableByPlayer: true
            //    ));
            //}
            //else
            //{
            //    //if (Actor.Autonomy.SituationComponent.Situations != null)
            //    Actor.Autonomy.SituationComponent.Situations.Add(NiecHelperSituation.Create(Target.LotCurrent, Target));
            //    niecHelperSituation = NewSafeGetSituationOfType<NiecHelperSituation>(Actor);
            //
            //     i = (
            //        (!niecHelperSituation.OkSuusse ?
            //            Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
            //            .CreateInstance(Target, Actor, new InteractionPriority(
            //                Instantiator .RootIsOpenDGSInstalled ?
            //                (InteractionPriorityLevel)100 :
            //                (InteractionPriorityLevel)12, 999f
            //            ),
            //
            //        isAutonomous: false,
            //        cancellableByPlayer: true
            //    ));
            //
            //    
            //}
            //try
            //{
            //    NiecHelperSituationInteractioList.Add(i);
            //    return _RunInteraction(i);
            //}
            //finally
            //{
            //    NiecHelperSituationInteractioList.Remove(i);
            //}
            if (NiecHelperSituationInteractioList.Count > 1000)
                List_ClearEx(ref NiecHelperSituationInteractioList);
            try
            {
                NiecHelperSituationInteractioList.Add(i);
                return _RunInteraction(i);
            }
            finally
            {
                NiecHelperSituationInteractioList.Remove(i);
            }
        }

        public static Household GetTargetSimHousehold()
        {
            var sim = NiecRunCommand.HitTargetSim();
            if (sim != null && sim.mSimDescription != null)
            {
                return sim.Household;
            }
            return null;
        }

        public static Sim GetRandomSim(Predicate<Sim> customTest = null)
        {
            var simList = SC_GetObjects<Sim>();
            var count =  simList.Length;
            var simListTemp = count > 0 ? new List<Sim>(count) : new List<Sim>();

            foreach (var item in simList)
            {
                if (item == null) continue;
                if (customTest == null || customTest(item))
                    simListTemp.Add(item);
            }

            if (simListTemp.Count > 0)
            {
                try
                {
                    return RandomUtil.GetRandomObjectFromList<Sim>(simListTemp, ListCollon.SafeRandomPart2);
                }
                finally
                {
                    simListTemp.Clear();
                }
            }

            return null;
        }


        public static GObject GetRandomGameObject<GObject>(Predicate<GObject> customTest = null) where GObject : class
        {
            List<GObject> listTemp = new List<GObject>();
            //if (ListCollon.NiecSimDescriptions != null && typeof(GObject).IsAssignableFrom(typeof(SimDescription)))
            //{
            //    foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
            //    {
            //        if (item == null) 
            //            continue;
            //
            //        var simDesc = item as GObject;
            //        if (simDesc == null) 
            //            continue;
            //
            //        if (customTest == null || customTest(simDesc))
            //            simListTemp.Add(simDesc);
            //    }
            //}
            //else
            {
                bool cacheISNull = customTest == null;
                foreach (var item in SC_GetObjects<GObject>())
                {
                    if (item == null) continue;
                    if (cacheISNull || customTest(item))
                        listTemp.Add(item);
                }
            }
            if (listTemp.Count > 0)
            {
                try
                {
                    return RandomUtil.GetRandomObjectFromList<GObject>(listTemp, ListCollon.SafeRandomPart2);
                }
                finally
                {
                    listTemp.Clear();
                }
               
            }
            return null;
        }
        public static SimDescription GetRandomSimDescription(Predicate<SimDescription> customTest = null, bool bNeedUpdateList = false)
        {
            List<SimDescription> simDescListTemp = new List<SimDescription>();
            bool cacheISNull = customTest == null;
            if (bNeedUpdateList)
                UpdateNiecSimDescriptions(false, false, true);
            foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
            {
                if (item == null) continue;
                if (cacheISNull || customTest(item))
                    simDescListTemp.Add(item);
            }
            if (simDescListTemp.Count > 0)
            {
                try
                {
                    return RandomUtil.GetRandomObjectFromList<SimDescription>(simDescListTemp, ListCollon.SafeRandomPart2);
                }
                finally
                {
                    simDescListTemp.Clear();
                }

            }
            return null;
        }

        public static Household Find_HouseholdList(ulong household_ID)
        {
            var hlist = Household.sHouseholdList;
            if (hlist != null)
            {
                foreach (Household household in hlist)
                {
                    if (household == null) continue;
                    if (household.mHouseholdId == household_ID)
                    {
                        return household;
                    }
                }
            }
            return null;
        }


        public static Household FindTelemetryID_HouseholdList(ulong household_TelemetryID)
        {
            var hlist = Household.sHouseholdList;
            if (hlist != null)
            {
                foreach (Household household in hlist)
                {
                    if (household == null) continue;
                    if (household.mHouseholdTelemetryId == household_TelemetryID)
                    {
                        return household;
                    }
                }
            }
            return null;
        }

        public static Household Find_SCGetHouseholds(ulong household_ID)
        {
            foreach (Household household in SC_GetObjects<Household>())
            {
                if (household == null) continue;
                if (household.mHouseholdId == household_ID)
                {
                    return household;
                }
            }
            return null;
        }

        public static Household FindTelemetryID_SCGetHouseholds(ulong household_TelemetryID)
        {
            foreach (Household household in SC_GetObjects<Household>())
            {
                if (household == null) continue;
                if (household.mHouseholdTelemetryId == household_TelemetryID)
                {
                    return household;
                }
            }
            return null;
        }

        public static
            void ForceAllMoveIn
            (params Household[] BlockHousehold)
        {
            List<Lot> lieastERS = new List<Lot>();
            Lot lotERS = null;
            List<Household> newlistERS = new List<Household>();
            try
            {
                foreach (var item in SC_GetObjects<Household>())
                {
                    if (item == null) continue;
                    if (!newlistERS.Contains(item))
                    {
                        newlistERS.Add(item);
                    }
                }
            }
            catch (Exception)
            { }

            try
            {
                foreach (var item in Household.sHouseholdList.ToArray())
                {
                    if (item == null) continue;
                    if (!newlistERS.Contains(item))
                    {
                        newlistERS.Add(item);
                    }
                }
            }
            catch (Exception)
            { }
            foreach (Household mhouselist in newlistERS)
            {
                if (mhouselist == null) continue;

                bool found = false;
                if (BlockHousehold != null)
                {
                    foreach (var item in BlockHousehold)
                    {
                        if (item == mhouselist)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found)
                        continue;
                }
                if (mhouselist.mMembers == null || mhouselist.AllSimDescriptions == null || mhouselist.AllSimDescriptions.Count == 0) continue;
                try
                {
                    if (mhouselist == Household.sNpcHousehold || mhouselist == Household.sPetHousehold || mhouselist == Household.sMermaidHousehold || mhouselist == Household.sTouristHousehold || mhouselist == Household.sPreviousTravelerHousehold || mhouselist == Household.sAlienHousehold || mhouselist == Household.sServobotHousehold) continue;
                }
                catch
                { }







                try
                {
                    if (mhouselist.LotHome != null) continue;
                }
                catch
                { }


                lieastERS.Clear();

                foreach (object obj in LotManager.AllLots)
                {
                    Lot lot2 = (Lot)obj;
                    if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null && !World.LotIsEmpty(lot2.LotId) && !lot2.IsLotEmptyFromObjects())
                    {
                        lieastERS.Add(lot2);
                    }
                    if (lieastERS.Count == 0)
                    {
                        if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null)
                        {
                            lieastERS.Add(lot2);
                        }
                    }
                }

                if (lieastERS.Count > 0)
                {
                    lotERS = RandomUtil.GetRandomObjectFromList<Lot>(lieastERS);
                    try
                    {
                        if (IsOpenDGSInstalled)
                            lotERS.MoveIn(mhouselist);
                        else
                            Household_MoveIn(mhouselist, lotERS, false);
                    }
                    catch (Exception)
                    { }
                }

                else return;


            }
        }

        public static Household Household_Create(SimDescription simDesc) {
            if (simDesc == null)
                return Household.Create(true);
            else
            {
                var simdHousehold = simDesc.Household;
                if (simdHousehold == null)
                {
                    var household = Household.Create(true);
                    household.Name = simDesc.mLastName;

                    Household_Add(household, simDesc, false);

                    if (!IsOpenDGSInstalled && NiecSocialWorkerChildAbuseSituation.IsHouseholdOnlyChildOrPet(household))
                    {
                        SimDescription simd = CreateRandomSimDescription();
                        if (simd != null)
                        {
                            household.Name = simd.mLastName;
                            Household_Add(household, simd, false);
                        }
                        else {
                            Household_Add(household, GetRandomSimDescription(delegate(SimDescription _simd) { 
                                return _simd.IsValidDescription && _simd.Household == null; 
                            }), false);
                        }
                    }

                    Create.AutoMoveInLotFromHousehold(household);

                    return household;
                }
                else {
                    return simdHousehold;
                }
            }
        }

        public static bool ResuetSim(SimDescription deadSimDesc, Household originalHousehold, bool createHousehold, bool toSpecialHousehold) {
            if (deadSimDesc == null || deadSimDesc.mHairColors == null) 
                return false;

            if (string.IsNullOrEmpty(deadSimDesc.mFirstName) && string.IsNullOrEmpty(deadSimDesc.mLastName))
                return false;

            if (!deadSimDesc.IsValidDescription)
            {
                try
                {
                    deadSimDesc.Fixup();
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException)
                { throw; }
                catch
                { deadSimDesc.mIsValidDescription = false; return false; }
            }

            if (!deadSimDesc.IsValidDescription) 
                return false;

            if (deadSimDesc.Household == null)
            {
                if (originalHousehold != null)
                {
                    Household_Add(originalHousehold, deadSimDesc, false);
                }
                if (deadSimDesc.Household == null)
                {
                    Household_Add(GetRandomGameObject<Household>(delegate(Household item)
                    {
                        if (item == null)
                            return false;

                        if (IsSpecialHousehold(item))
                            return false;

                        Household.Members mem = item.mMembers;
                        if (mem == null || mem.mAllSimDescriptions == null)// || mem.mAllSimDescriptions.Count == 0)
                        { HouseholdCleanse(item, false, false); return false; }

                        if (!NiecRunCommand.IsOpenDGSInstalled && item.LotHome == null)
                            return false;

                        return true;
                    }), deadSimDesc, false);
                }
                if (createHousehold && deadSimDesc.Household == null) {
                    Household va = Household.Create();
                    SimDescription simd = NFinalizeDeath.CreateRandomSimDescription();
                    if (simd != null)
                    {
                        va.Name = simd.mLastName;
                        Household_Add(va, simd, false);
                    }
                    //va.Add(CreateRandomSimDescription());
                    Create.AutoMoveInLotFromHousehold(va);
                    Household_Add(va, deadSimDesc, false);
                }
                if (toSpecialHousehold && deadSimDesc.Household == null) {
                    Household_Add(Household.sServobotHousehold ?? Household.sPetHousehold ?? Household.ActiveHousehold, deadSimDesc, false);
                }
                if (deadSimDesc.Household == null) {
                    return false;
                }
            }

            deadSimDesc.IsGhost = false;
            deadSimDesc.mDeathStyle = SimDescription.DeathType.None;
            deadSimDesc.IsNeverSelectable = false;

            foreach (var itemGrave in SC_GetObjects<Urnstone>())
            {
                if (itemGrave != null && itemGrave.DeadSimsDescription == deadSimDesc)
                    itemGrave.GhostTurnDeathEffectOff(VisualEffect.TransitionType.SoftTransition);
            }
            
            Sim createdSim = deadSimDesc.CreatedSim;
            if (createdSim != null && createdSim.SimDescription == deadSimDesc) {
                World.ObjectSetGhostState(createdSim.ObjectId, 0u, (uint)deadSimDesc.AgeGenderSpecies);
                Autonomy auon = createdSim.Autonomy;
                if (auon != null)
                    auon.AllowedToRunMetaAutonomy = true; 
                try
                {
                    if (createdSim.DeathReactionBroadcast != null)
                    {
                        createdSim.DeathReactionBroadcast.Dispose();
                        createdSim.DeathReactionBroadcast = null;
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    //CheckYieldingContext();
                }
                try
                {
                    if (createdSim.GhostReactionBroadcast != null)
                    {
                        createdSim.GhostReactionBroadcast.Dispose();
                        createdSim.GhostReactionBroadcast = null;
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    //CheckYieldingContext();
                }
                
            }
            if (HelperNra.HelperNraLists != null)
            {
                AlarmManager alram = AlarmManager.Global;
                foreach (HelperNra helperNra in HelperNra.HelperNraLists.ToArray())
                {
                    if (helperNra == null)
                        continue;
                    if (helperNra.mSimdesc == deadSimDesc)
                    {
                        if (alram != null)
                            alram.RemoveAlarm(helperNra.this_alarm);
                        helperNra.Dispose();
                    }
                }
            }
            return true; 
        }
        public static bool sMasterForceDestroyObject = false;
        public static bool ForceDestroyObject(GameObject Item, bool Sleep = true)
        {
            if (Item == null || Item == NFinalizeDeath.ActiveActor)
                return false;

            if (!IsOpenDGSInstalled && Item == global::NiecMod.Helpers.NiecRunCommand.looptargetdied_data) return false;

            ObjectGuid ObjectID = Item.ObjectId;
            ScriptCore.ScriptProxy proxy = ObjectID.mValue != 0 ? Item.Proxy as ScriptCore.ScriptProxy : null;
            var ItemAsGrave = Item as Urnstone;
            var ItemAsSim = Item as Sim;

            bool IsACore = false;

            if (ItemAsGrave != null)
            {
                SimDescription DeadSimDesc = ItemAsGrave.DeadSimsDescription;
                if (DeadSimDesc != null)
                {
                    var orgHousehold = Find_SCGetHouseholds(ItemAsGrave.mOriginalHouseholdId);// ?? Find_HouseholdList(grave.mOriginalHouseholdId);
                    if (!ResuetSim(DeadSimDesc, orgHousehold, NiecRunCommand.IsOpenDGSInstalled, NiecRunCommand.IsOpenDGSInstalled) && !SimDescCleanseTask.Add(DeadSimDesc, true))
                       SimDescCleanse(DeadSimDesc, true, false);
                }
                ItemAsGrave.mOriginalHouseholdId = 0;
                ItemAsGrave.DeadSimsDescription = null;
            }
            try
            {
                try
                {
                    if (ItemAsSim!= null)
                    {
                        Sim ActiveActor = PlumbBob.SelectedActor;
                        if (ActiveActor != null)
                            _MoveInventoryItemsToAFamilyMember(ItemAsSim, ActiveActor);
                    }
                }
                catch (ResetException) { throw; }
                catch 
                {}
                if (AssemblyCheckByNiec.IsInstalled("AweCore") && !IsOpenDGSInstalled) {
                    IsACore = true;
                    try
                    {
                       // Item.FadeIn();
                        ScriptCore.World.World_ObjectSetHiddenFlags(ObjectID.mValue, 0);//(uint)((int)ScriptCore.World.World_ObjectGetHiddenFlags(ObjectID.mValue) & -2));
                        ScriptCore.World.World_ObjectSetOpacity(ObjectID.mValue, 1, 1);
                    }
                    catch (ResetException) { throw; }
                    catch
                    { }
                   
                    UnSafe_RemoveActorsUsingMe(Item);
                    if (ItemAsSim != null)
                    {
                        UnSafeSimDeAttachAndPosture(ItemAsSim);
                       
                        if (!NiecHelperSituation.isdgmods || Random_Chance(41))
                        {
                            UnSafeForceErrorTargetSim(ItemAsSim);
                            if (ItemAsSim.SimDescription != null)
                                UnSafe_OrgToNull_SimDesc(ItemAsSim);
                            if (!NiecHelperSituation.isdgmods)
                            {
                                UnSafeForceDeAttachAndDestroyAllSlotsWithObjectID(ObjectID, false);
                            }
                        }
                    }
                }
                Item.Destroy();
                if (Sleep)
                    SpeedTrap.Sleep(0);
                if (!Item.HasBeenDestroyed)
                { try { ScriptCore.Simulator.Simulator_DestroyObjectImpl(ObjectID.mValue); } catch { } }
            }
            catch (ResetException) { throw; }
            catch { try { ScriptCore.Simulator.Simulator_DestroyObjectImpl(ObjectID.mValue); } catch { } }
            if (IsACore && ItemAsSim != null)
            {
                if (sMasterForceDestroyObject)
                {
                    ScriptCore.Simulator.Simulator_DestroyObjectImpl(ObjectID.mValue);
                    if (ObjectID.mValue != 0)
                    {
                        if (proxy != null)
                        {
                            proxy.mTarget = null;
                            proxy.mObjectId.mValue = 0;
                        }
                    }
                }
            }
            return true;
        }

        

        public static bool ForceDestroyObjectI(IGameObject Item)
        {
            if (Item == null || Item == NFinalizeDeath.ActiveActor)
                return false;
            ObjectGuid ObjectID = Item.ObjectId;
            try
            {
                Item.Destroy();
                if (!Item.HasBeenDestroyed)
                { try { Simulator.DestroyObject(ObjectID); } catch { } }
            }
            catch (ResetException) { throw; }
            catch { try { Simulator.DestroyObject(ObjectID); } catch { } }
            return true;
        }

        public static void FastProCancel(Sim Target)
        {
            try
            {
                if (Target.mInteractionQueue != null)
                {
                    if (Target.mInteractionQueue.mInteractionList.Count != 0)
                    {
                        InteractionInstance ii = Target.CurrentInteraction;
                        InteractionPriority pr = new InteractionPriority((InteractionPriorityLevel)0);
                        foreach (var item in Target.mInteractionQueue.mInteractionList.ToArray())
                        {
                            if (item == null)
                                continue;
                            item.mCancelled = true;
                            item.mbOnStopCalled = true;
                            item.mMustRun = false;
                            item.mPriority = pr;
                            if (ii != item)
                                Target.mInteractionQueue.mInteractionList.Remove(item);
                        }
                    }
                    Target.mInteractionQueue.mCurrentTransitionInteraction = null;
                    if (Target.mInteractionQueue.mRunningInteractions.Count != 0)
                        Target.mInteractionQueue.mRunningInteractions.Clear();
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

        }

// ----------------------------------------------------------- Methed Hacks ------------------------------------------------------------ //
/*
------------------------------------------------------------------------------------------------
// x86-32 Code
 * (1.67.2.024017 Date: 2014-01-16-1625) 
 * 00788640 World_IsEditInGameFromWBModeImpl:
	// World* world = World_sInstance;
	mov eax, [11EDBC4]
	
	// if (world != NULL)
	test eax, eax 
	je goto_retfalse
	
	// return world->flags == 2;
	xor ecx, ecx 
	cmp [eax+1B4], 2
	sete cl
	mov al, cl 
	ret 
	
 goto_retfalse:
	// return false;
	xor al, al 
	ret 
------------------------------------------------
// C++ Code
bool ScriptCore::World::World_IsEditInGameFromWBModeImpl() {
	World* world = World_sInstance;
	if (world != NULL)
	{
		return world->flags == 2;
	}
	return false;
}
------------------------------------------------------------------------------------------------
 */
////////////////////////////////////////////////////////////////////////
public unsafe static
    bool World_IsEditInGameFromWBModeImpl()
{
    if (GameIs64Bit(false))
        return ScriptCore.World.World_IsEditInGameFromWBModeImpl();

    uint world = World_NativeInstance;
    if (world != 0)
    {
        //IntPtr ptr_flags = new IntPtr(world + 0x1B4); // Check 64 bit?
        //return *(uint*)ptr_flags.value == 2;
        return (*(uint*)(world + 0x1B4u)) == 2;
    }
    return false;
}
////////////////////////////////////////////////////////////////////////
public unsafe static 
    uint World_NativeFlags
{
    get
    {
        if (GameIs64Bit(false))
            return 0;

        uint world = World_NativeInstance;
        if (world != 0)
        {
            //var ptr_flags = new IntPtr(world + 0x1B4);
            return *(uint*)(world + 0x1B4u);
        }
        return 0;
    }
    set
    {
        if (GameIs64Bit(false))
            return;

        uint world = World_NativeInstance;
        if (world != 0)
        {
            //IntPtr ptr_flags = new IntPtr(world + 0x1B4);
            *(uint*)(world + 0x1B4u) = value;
        }
    }
}
////////////////////////////////////////////////////////////////////////
public unsafe static 
    uint World_NativeInstance
{
    get
    {
        if (GameIs64Bit(false))
            return 0;

        //var world_instance_ptr = new IntPtr(0x11EDBC4);
        //return *(uint*)world_instance_ptr.value;
#if GameVersion_0_Release_2_0_209
        return *(uint*)(0x11EDBC4u);
#else 
        return 0;
#endif

    }
    set
    {
        if (GameIs64Bit(false))
            return;

        //var world_instance_ptr = new IntPtr(0x11EDBC4);
        //*(uint*)world_instance_ptr.value = value;
#if GameVersion_0_Release_2_0_209
        *(uint*)(0x11EDBC4u) = value;
#else
        return;
#endif

    }
}

////////////////////////////////////////////////////////////////////////
// 009AED00 sub esp,10  DownloadContent_IsDevBuild
/*
    sub esp,10
    cmp [11EA6C1],0
    je 009AED15
    mov al,[11EA6C0]
    add esp,10
    ret 
    ....
 */
public unsafe static bool DownloadCoutext_CacheBoolIsDevBuild
{
    get
    {
        if (GameIs64Bit(false))
            return false;

        #if GameVersion_0_Release_2_0_209
        return *(byte*)(0x11EA6C0u) == 1; 
#else
        return ScriptCore.DownloadContent.DownloadContent_IsDevBuild();
#endif

    }
    set
    {
        if (GameIs64Bit(false))
            return;

#if GameVersion_0_Release_2_0_209
        if (value)
            *(byte*)(0x11EA6C0u) = (byte)1;
        else
            *(byte*)(0x11EA6C0u) = (byte)0;
#endif
    }
}
////////////////////////////////////////////////////////////////////////


// ------------------------------------------ End World Metheds -------------------------------------- //


/* // ScriptCore.GameUtils.GameUtils_ToggleDebugInfo // This a Set Methed ToggleDebugInfo. don't have get methed 
 * // or command cheat: fps on 
 * //
 * // Need Game Patch (1.67.2.024017 Date: 2014-01-16-1625)
 * // test 1.69.* [ts3.01196F98]???
 * //
 * // My Create Get Methed :)
   mov eax, [01196F98] // x86 code
   eax:
   // 2 Debug info
   // 1 FPS info
   // 0 Off
   ret
   .text:00EC06F6 ts3w.exe:$AC06F6 #AC06F6 // PE
*/
////////////////////////////////////////////////////////////////////////
public static 
    short TestGetDEBUGEAINFO()
{
    if (GameIs64Bit(false))
        return 0;

#if GameVersion_0_Release_2_0_209
    niec_std.mono_runtime_install_handlers();
    var ptr = new IntPtr(0x01196F98); // check 64-bit?
    try
    {
        return global:: System.Runtime.InteropServices.Marshal.ReadInt16(ptr);
    }
    catch
    {
        return -2;
    }
#else
    return -2;
#endif
}
////////////////////////////////////////////////////////////////////////
public unsafe static 
    short UnSafeTestGetDEBUGEAINFO()
{
    if (GameIs64Bit(false))
        return 0;

#if GameVersion_0_Release_2_0_209
    niec_std.mono_runtime_install_handlers();
    short r = -2;
    SafeCall(() =>
    {
        var ptr = new IntPtr(0x01196F98); // check 64-bit?
        r = *(short*)ptr.value;
    });
    return r;
#else
    return -2;
#endif
}
////////////////////////////////////////////////////////////////////////
public unsafe static 
    bool UnSafeTestSetDEBUGEAINFO(short pFlags)
{
    if (GameIs64Bit(false))
        return false;

#if GameVersion_0_Release_2_0_209
    niec_std.mono_runtime_install_handlers();
    bool r = false;
    SafeCall(() =>
    {
        var ptr = new IntPtr(0x01196F98); // check 64-bit?
        *(short*)ptr.value = pFlags; 
        r = true;
    });
    return r;
#else
    return false;
#endif
}
////////////////////////////////////////////////////////////////////////
public static 
    bool TestSetDEBUGEAINFO(short pFlags)
{
    if (GameIs64Bit(false))
        return false;

#if GameVersion_0_Release_2_0_209
    niec_std.mono_runtime_install_handlers();
    var ptr = new IntPtr(0x01196F98); // check 64-bit?
    try
    {
        global:: System.Runtime.InteropServices.Marshal.WriteInt16(ptr, pFlags);
        return true;
    }
    catch 
    { }
    return false;
#else
    return false;
#endif
}
////////////////////////////////////////////////////////////////////////
// -----------------------------------------------------------  End Methed Hacks ------------------------------------------------------------ //








        public static StringBuilder debugRemoveSituationList = new StringBuilder();

        public static 
            void SimRemove_SituationList(Sim actor, Situation removeSituation, bool needWhile)
        {
            if (actor == null) 
                return;

            Autonomy automoy = actor.Autonomy;
            if (automoy == null)
                return;

            SituationComponent sSituationComponent = automoy.SituationComponent;
            if (sSituationComponent == null)
                return;

            List<Situation> listSituations = sSituationComponent.Situations;
            if (listSituations == null)
                return;
            try
            {
                if (!IsOpenDGSInstalled)
                {
                    debugRemoveSituationList.Append("SimRemove_SituationList(): Removed\nNHS?: " + SimIsNiecHelperSituation(actor) + "\nIsDestroyed?: " + ObjectGuid_IsDestroyed(actor.ObjectId));
                    debugRemoveSituationList.AppendLine();
                    debugRemoveSituationList.AppendLine();
                }
                int s = 100000;
                if (needWhile) { while (listSituations.Remove(removeSituation)) { s--; if (s == 0) { sSituationComponent.mSituations = new List<Situation>(); break; } } }
                else listSituations.Remove(removeSituation);
            }
            catch (ResetException)
            { throw; }
            catch (Exception)
            { sSituationComponent.mSituations = new List<Situation>(); }
        }

        public static void ForceCancelAllInteractionsWithoutCleanup(Sim Target)
        {
            try
            {
                if (Target.mInteractionQueue != null)
                {
                    Target.mInteractionQueue.mCurrentTransitionInteraction = null;
                    if (Target.mInteractionQueue.mInteractionList != null && Target.mInteractionQueue.mInteractionList.Count != 0)
                    {
                        Target.mInteractionQueue.mInteractionList.Clear();
                    }
                    if (Target.mInteractionQueue.mRunningInteractions.Count != 0)
                    {
                        Target.mInteractionQueue.mRunningInteractions.Clear();
                    }
                   
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

        }



        public static void DeleteCacheSimDescription (Sim[] simlist) {
            try
            {
                foreach (var item in (simlist != null ? simlist : SC_GetObjects<Sim>()))
                {
                    try
                    {
                        if (item == null || item.mDreamsAndPromisesManager == null) continue;
                        if (item.mDreamsAndPromisesManager.mActiveNodes != null)
                        {
                            foreach (var i in item.mDreamsAndPromisesManager.mActiveNodes.ToArray())
                            {
                                if (i == null || i.mNodeSubject == null) continue;
                                i.mNodeSubject.mMiniSimDescriptionCache = null;
                            }
                        }
                        if (item.mDreamsAndPromisesManager.mCompletedNodes != null)
                        {
                            foreach (var i in item.mDreamsAndPromisesManager.mCompletedNodes.ToArray())
                            {
                                if (i == null || i.mNodeSubject == null) continue;
                                i.mNodeSubject.mMiniSimDescriptionCache = null;
                            }
                        }
                        if (item.mDreamsAndPromisesManager.mPromiseNodes != null)
                        {
                            foreach (var i in item.mDreamsAndPromisesManager.mPromiseNodes)
                            {
                                if (i == null || i.mNodeSubject == null) continue;
                                i.mNodeSubject.mMiniSimDescriptionCache = null;
                            }
                        }
                        if (item.mDreamsAndPromisesManager.mDisplayedDreamNodes != null)
                        {
                            foreach (var i in item.mDreamsAndPromisesManager.mDisplayedDreamNodes.ToArray())
                            {
                                if (i == null || i.mNodeSubject == null) continue;
                                i.mNodeSubject.mMiniSimDescriptionCache = null;
                            }
                        }
                        if (item.mDreamsAndPromisesManager.mDreamNodes != null)
                        {
                            foreach (var i in item.mDreamsAndPromisesManager.mDreamNodes.ToArray())
                            {
                                if (i == null || i.mNodeSubject == null) continue;
                                i.mNodeSubject.mMiniSimDescriptionCache = null;
                            }
                        }
                        if (item.mDreamsAndPromisesManager.mPotentialRemovalNodes != null)
                        {
                            foreach (var i in item.mDreamsAndPromisesManager.mPotentialRemovalNodes.Values)
                            {
                                if (i == null) continue;
                                foreach (var ityem in i.ToArray())
                                {
                                    if (ityem == null || ityem.mNodeSubject == null) continue;
                                    ityem.mNodeSubject.mMiniSimDescriptionCache = null;
                                }
                            }
                        }
                        if (item.mDreamsAndPromisesManager.mReferenceList != null)
                        {
                            foreach (var i in item.mDreamsAndPromisesManager.mReferenceList.Values)
                            {
                                if (i == null) continue;
                                foreach (var ityem in i.ToArray())
                                {
                                    if (ityem == null || ityem.mNodeSubject == null) continue;
                                    ityem.mNodeSubject.mMiniSimDescriptionCache = null;
                                }
                            }
                        }
                        if (item.mDreamsAndPromisesManager.LifetimeWishNode != null && item.mDreamsAndPromisesManager.LifetimeWishNode.mNodeSubject != null)
                        {
                            item.mDreamsAndPromisesManager.LifetimeWishNode.mNodeSubject.mMiniSimDescriptionCache = null;
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception ex)
                    {
                        NiecException.WriteLog("DeleteCacheSimDescription: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("DeleteCacheSimDescription: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
            }
        }

        public static BonehildaCoffin FindBonehildaCoffinSimDesc(BonehildaCoffin[] bonehildaCoffinList, SimDescription findSimDesc)
        {
            if (bonehildaCoffinList == null)
                bonehildaCoffinList = SC_GetObjects<BonehildaCoffin>();
            foreach (var item in bonehildaCoffinList)
            {
                if (item == null) continue;
                if (item.mBonehilda == findSimDesc)
                    return item;
            }
            return null;
        }

        public static TransformParentingReturnCode PlumbBob_ParentToPreviewSim(PlumbBob pSingleton, GameObject previewSim)
        {
            if (pSingleton != null && pSingleton.Proxy != null && previewSim != null && previewSim.Proxy != null) // Custom :)
            {
                var simOutfit = new global::Sims3.SimIFace.CAS.SimOutfit
                    (global::Sims3.SimIFace.CAS.CASUtils.GetOutfitInGameObject(previewSim.Proxy.ObjectId));

                if (simOutfit == null || !simOutfit.IsValid)
                    return TransformParentingReturnCode.ContainmentViolation;

                CASAgeGenderFlags simOutfitAgeGenderSpecies = simOutfit.AgeGenderSpecies;

                CASAgeGenderFlags age = simOutfitAgeGenderSpecies & CASAgeGenderFlags.AgeMask;
                CASAgeGenderFlags species = simOutfitAgeGenderSpecies & CASAgeGenderFlags.SpeciesMask;

                if (species == CASAgeGenderFlags.None) {
                    species = CASAgeGenderFlags.Human;
                }

                Dictionary<CASAgeGenderFlags, PlumbBob.SlotOffset> slotOffsets;
                PlumbBob.SlotOffset slotOffset;

                if (PlumbBob.sPlumbbobOffsets.TryGetValue(species, out slotOffsets))
                {
                    if (!slotOffsets.TryGetValue(age, out slotOffset))
                    {
                        slotOffset = PlumbBob.sPlumbbobOffsets[CASAgeGenderFlags.Human][CASAgeGenderFlags.Adult];
                    }
                }
                else
                {
                    slotOffset = PlumbBob.sPlumbbobOffsets[CASAgeGenderFlags.Human][CASAgeGenderFlags.Adult];
                }

                return Slots.AttachToSlot
                    (pSingleton.ObjectId, previewSim.ObjectId, (uint)slotOffset.Slot, false, ref slotOffset.Offset, ref slotOffset.Offset, 0);

                //return Slots.IsSuccess(result);
            }
            return (TransformParentingReturnCode)323341; //TransformParentingReturnCode.ArgsInvalid
        }

        public static SimDescription FindSimDescFromSimOutfit(SimDescription[] simList, SimOutfit o, OutfitCategories category)
        {
            if (o == null)
                throw new ArgumentNullException();

            int sleep = 0;
            foreach (var item in simList ?? UpdateNiecSimDescriptions(false, Simulator.CheckYieldingContext(false), true).ToArray())
            {
                sleep++;

                if (sleep > 50)
                {
                    if (Simulator.CheckYieldingContext(false))
                        SleepTask(50);
                    sleep = 0;
                }

                if (item == null || !item.IsValid || !item.IsValidDescription) 
                    continue;

                if (!SimDesc_OutfitsIsValid(item)) 
                    continue;

                var t = item.GetOutfits(category);
                if (t == null) 
                    continue;

                foreach (SimOutfit Outfit in t._items)
                {
                    if (Outfit == null) 
                        continue;
                    if (Outfit.Key.InstanceId == o.Key.InstanceId && Outfit.Key.GroupId == o.Key.GroupId)
                        return item;
                } 

            }
            return null;
        }

        public static void DeleteAllMiniSimDescription() {

            DeleteCacheSimDescription(null);
            if (MiniSimDescription.sMiniSims == null)
                return;
            foreach (var item in new List<ulong>(MiniSimDescription.sMiniSims.Keys))
            {
                MiniSimDescription imini = null;
                try
                {
                    imini = MiniSimDescription.Find(item);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    SimDescRemoveMSD(item);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    if (imini != null)
                    {
                        imini.mAgeGenderFlags = CASAgeGenderFlags.None;
                        imini.mAlmaMater = AlmaMater.None;
                        imini.mAlmaMaterName = null;
                        imini.mbAgingEnabled = false;
                        imini.mCelebrityLevel = 0;
                        imini.mDeathStyle = SimDescription.DeathType.None;
                        imini.mDegrees = null;
                        imini.mFirstName = null;
                        imini.mHomeLotId = 0;
                        imini.mGenealogy = null;
                        imini.mHomeWorld = WorldName.Undefined;
                        imini.mFirstName = null;
                        imini.mHouseholdMembers = null;
                        imini.mMiniRelationships = null;
                        imini.mLastName = null;
                        imini.mMotherDescId = 0;
                        imini.mNumPetsInHousehold = 0;
                        imini.mNumSimsInHousehold = 0;
                        imini.mProtectionFlags = null;
                        imini.mSimDescriptionId = 0;
                        imini.mStatusFlags = MiniSimDescription.SimDescriptionStatus.None;
                        imini.mThumbKey = ThumbnailKey.kInvalidThumbnailKey;
                        imini.mTraits = null;
                        imini.mTravelKey = ResourceKey.kInvalidResourceKey;
                        imini.mZodiac = Zodiac.Unset;
                        imini.JobIcon = null;
                        imini.JobOrServiceName = null;
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    MiniSimDescription.sMiniSims.Remove(item);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
            }
            if (MiniSimDescription.sMiniSims != null)
                MiniSimDescription.sMiniSims.Clear();
            MiniSimDescription.sMiniSims = null;
            MiniSimDescription.sMiniSims = new Dictionary<ulong, MiniSimDescription>();
        }

        public static bool FixCantRemoveHousehold(SimDescription sim, bool forceremove, bool forcedellothome)
        {
            if (sim == null) return false;
            try
            {
                Household holde = sim.Household;
                if (holde != null)
                {
                    if (holde.IsServiceNpcHousehold)
                    {
                        if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                        holde.mLotHome = null;

                        holde.mLotId = 0uL;
                    }
                    if (forceremove)
                    {
                        try
                        {
                            if (holde.IsServiceNpcHousehold && sim.VirtualLotHome != null)
                            {
                                sim.VirtualLotHome.VirtualMoveOut(sim);
                            }
                            if (sim.CreatedSim != null)
                            {
                                Sim createdSim = sim.CreatedSim;
                                if (createdSim.LotCurrent != null)
                                {
                                    createdSim.UpdateVisibleLotsForActiveHousehold(createdSim.LotCurrent);
                                }
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }

                        Household.Members hm = holde.mMembers;
                        if (hm != null)
                        {
                            try
                            {
                                if (hm.mSimDescriptions != null)
                                    hm.mSimDescriptions.Remove(sim);
                                if (hm.mPetSimDescriptions != null)
                                    hm.mPetSimDescriptions.Remove(sim);
                                if (hm.mAllSimDescriptions != null)
                                    hm.mAllSimDescriptions.Remove(sim);
                                //hm.RemoveAt(hm.mAllSimDescriptions.IndexOf(sim));
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            {
                                /*
                                if (hm.mSimDescriptions != null)
                                    hm.mSimDescriptions.Remove(sim);
                                if (hm.mPetSimDescriptions != null)
                                    hm.mPetSimDescriptions.Remove(sim);
                                if (hm.mAllSimDescriptions != null)
                                    hm.mAllSimDescriptions.Remove(sim);
                                */
                            }
                        }
                        try
                        {
                            sim.OnHouseholdChanged(null, true);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }
                        /*
                        try
                        {
                            if (Sims3.UI.Responder.Instance != null)
                            {
                                HudModel hudModel = Sims3.UI.Responder.Instance.HudModel as HudModel;
                                if (sim.CreatedSim != null)
                                {
                                    hudModel.OnHouseholdSimChanged(Sims3.Gameplay.CAS.HouseholdEvent.kSimRemoved, sim.CreatedSim, holde);
                                }
                            }
                        }
                        catch (ResetException)
                        { throw; }
                        catch { }
                        */
                        try
                        {
                            holde.HouseholdSimRemovedChangeFutureDescendants(sim);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }
                        try
                        {
                            if (ParentsLeavingTownSituation.Adults != null && ParentsLeavingTownSituation.Adults.Contains(sim.SimDescriptionId))
                            {
                                ParentsLeavingTownSituation parentsLeavingTownSituation = ParentsLeavingTownSituation.FindParentsGoneSituationForHousehold(holde);
                                parentsLeavingTownSituation.BringParentsBack();
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }
                        try
                        {
                            holde.RemoveDescriptionIdFromPetAddedToHousehold(sim.SimDescriptionId);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }



                    }
                    else
                    {
                        try
                        {
                            holde.Remove(sim, !holde.IsServiceNpcHousehold);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                    }

                    if (!holde.IsServiceNpcHousehold)
                    {
                        if (forcedellothome)
                        {
                            try
                            {
                                if (holde.LotHome != null) // Test New 130?
                                {
                                    Sims3.Gameplay.Services.Services.ClearServicesForLot(holde.LotHome);
                                    Bill.DestroyAllBillsForHousehold(sim.CreatedSim, holde.LotHome);
                                    holde.LotHome.CleanUpForMoving();
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch { }

                            try
                            {
                                holde.MoveOut();

                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                            try
                            {

                                if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                            holde.mLotHome = null;

                            holde.mLotId = 0uL;
                        }
                        if (holde.mMembers != null && holde.mMembers.Count == 0)
                        {
                            //holde.HandleLastSimsDeath();
                            try
                            {
                                if (holde.LotHome != null) // Test New 130?
                                {
                                    Sims3.Gameplay.Services.Services.ClearServicesForLot(holde.LotHome);
                                    Bill.DestroyAllBillsForHousehold(sim.CreatedSim, holde.LotHome);
                                    holde.LotHome.CleanUpForMoving();
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch { }

                            try
                            {
                                holde.MoveOut();

                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                            try
                            {

                                if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                            holde.mLotHome = null;

                            holde.mLotId = 0uL;
                            try
                            {
                                holde.Dispose();
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                        }
                        else if (holde.mMembers != null && holde.mMembers.mAllSimDescriptions != null && holde.mMembers.mAllSimDescriptions.Contains(sim) && holde.mMembers.mAllSimDescriptions.Count == 1)
                        {
                            try
                            {
                                if (holde.LotHome != null) // Test New 130?
                                {
                                    Sims3.Gameplay.Services.Services.ClearServicesForLot(holde.LotHome);
                                    Bill.DestroyAllBillsForHousehold(sim.CreatedSim, holde.LotHome);
                                    holde.LotHome.CleanUpForMoving();
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch { }


                            try
                            {
                                holde.MoveOut();
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                            try
                            {
                                if (holde.mLotHome != null) holde.mLotHome.mHousehold = null;
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                            holde.mLotHome = null;

                            holde.mLotId = 0uL;
                            try
                            {
                                holde.Dispose();
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                        }
                    }
                    sim.mHousehold = null;
                    return true;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.WriteLog("FixCantRemoveHousehold:" + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
            }

            return false;
        }

        public static 
            bool SafePosGoToHouse(Sim item, bool sleep)
        {
            if (item == null || !GameObjectIsValid(item.ObjectId.mValue)) //!global::Sims3.SimIFace.Objects.IsValid(item.ObjectId))
                return false;

            SimDescription simd = item.SimDescription;
            if (simd == null)
                return false;

            if (simd.LotHome == null)
                return false;
            if (item.LotCurrent == simd.LotHome)
                return true;
            if (item.InteractionQueue != null && item.InteractionQueue.GetHeadInteraction() != null)
                return false;

            Vector3 pos = Vector3.OutOfWorld;
            Vector3 fwd = Vector3.OutOfWorld;


            try
            {
                if (item.AttemptToFindSafeLocation(true, out pos, out fwd))
                {

                    item.SetPosition(pos);
                    item.SetForward(fwd);

                    if (item.SimRoutingComponent != null)
                        item.SimRoutingComponent.ForceUpdateDynamicFootprint();

                    if (sleep)
                        Simulator.Sleep(0);

                    if (item.LotCurrent == item.LotHome)
                        return true;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            {
                if (item.LotCurrent == item.LotHome)
                    return true;
            }


            Mailbox mailbox = item.LotHome.FindMailbox();
            World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(mailbox != null ? mailbox.Position : item.LotHome.Position);
            fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0xF);
            fglParams.BooleanConstraints = FindGoodLocationBooleans.None;



            if (!GlobalFunctions.FindGoodLocation(item, fglParams, out pos, out fwd))
            {
                if (sleep)
                    Simulator.Sleep(0);
                if (mailbox != null)
                {
                    pos = mailbox.Position;
                    fwd = mailbox.ForwardVector;
                }
                else
                {
                    pos = item.LotHome.Position;
                    fwd = item.LotHome.ForwardVector;
                }

            }

            item.SetPosition(pos);
            item.SetForward(fwd);

            if (item.SimRoutingComponent != null)
                item.SimRoutingComponent.ForceUpdateDynamicFootprint();

            return item.LotCurrent == item.LotHome;
        }



























        public static bool _RunInteraction(InteractionInstance i)
        {
            if (i == null) return false;
            try
            {
                Sim instanceActor = i.InstanceActor;
                if (instanceActor != null && instanceActor.Inventory != null && instanceActor.Inventory.Contains(i.Target))
                    return i.RunFromInventory();
                else
                    return i.Run();
            }
            finally { i.Cleanup(); }
        }
        public static bool _RunInteractionWithoutCleanUp(InteractionInstance i)
        {
            if (i == null) 
                return false;
            Sim instanceActor = i.InstanceActor;
            if (instanceActor != null)
            {
                var iv = instanceActor.Inventory;
                if (iv != null && iv.mItems != null && iv.mInventoryItems != null && iv.Contains(i.Target))
                {
                    iv = null;
                    return i.RunFromInventory();
                }
                else iv = null;
            }
            return i.Run();
        }
        public static List<SimDescription> ActiveHousehold_AllSimDesc
        {
            get
            { 
                Household bActiveHousehold = ActiveHousehold;
                if (bActiveHousehold != null)
                {
                    RemoveNullForHouseholdMembers(bActiveHousehold);
                    var hm = bActiveHousehold.mMembers;
                    if (hm != null)
                    {
                        return hm.mAllSimDescriptions;
                    }
                }
                return null;
            }
        }
        public static List<SimDescription> ActiveHousehold_AllSimDesc2
        {
            get
            {
                Household bActiveHousehold = Household.ActiveHousehold;
                if (bActiveHousehold != null)
                {
                    RemoveNullForHouseholdMembers(bActiveHousehold);
                    var hm = bActiveHousehold.mMembers;
                    if (hm != null)
                    {
                        return hm.mAllSimDescriptions;
                    }
                }
                return null;
            }
        }

        public static List<Sim> Household_GetAllActors(Household household)
        {
            if (household != null)
            {
                RemoveNullForHouseholdMembers(household);
                var hm = household.mMembers;
                if (hm != null)
                {
                    List<Sim> vlist = new List<Sim>();
                    foreach (var item in hm.mAllSimDescriptions)
                    {
                        if (item == null) continue;
                        var simCreated = item.CreatedSim;
                        if (simCreated != null && simCreated.mSimDescription == item)
                        {
                            vlist.Add(simCreated);
                        }
                    }
                    return vlist;
                }
            }
            return null;
        }







        public static List<Sim> ActiveHousehold_AllSim
        {
            get
            {
                Household bActiveHousehold = ActiveHousehold;
                if (bActiveHousehold != null) {
                    RemoveNullForHouseholdMembers(bActiveHousehold);
                    var hm = bActiveHousehold.mMembers;
                    if (hm != null) {
                        List<Sim> vlist = new List<Sim>(hm.mAllSimDescriptions.Count + 1);
                        foreach (var item in hm.mAllSimDescriptions)
                        {
                            if (item == null) continue;
                            var simCreated = item.mSim;
                            if (simCreated != null && simCreated.mSimDescription == item) {
                                vlist.Add(simCreated);
                            }
                        }
                        return vlist;
                    }
                }
                return null;
            }
        }
        public static List<Sim> ActiveHousehold_AllSim2
        {
            get
            {
                Household bActiveHousehold = Household.ActiveHousehold;
                if (bActiveHousehold != null)
                {
                    RemoveNullForHouseholdMembers(bActiveHousehold);
                    var hm = bActiveHousehold.mMembers;
                    if (hm != null && hm.mAllSimDescriptions != null)
                    {
                        List<Sim> vlist = new List<Sim>(30);
                        foreach (var item in hm.mAllSimDescriptions)
                        {
                            if (item == null) 
                                continue;

                            var simCreated = item.mSim;
                            if (simCreated != null && simCreated.mSimDescription == item)
                            {
                                vlist.Add(simCreated);
                            }

                        }
                        return vlist;
                    }
                }
                return null;
            }
        }
        public static Household ActiveHousehold
        {
            get
            {
                Sim bActiveActor = ActiveActor;
                if (bActiveActor == null)
                    return null;
                return bActiveActor.Household;
            }

        }
        public static Lot ActiveLotHome
        {
            get
            {
                var ah = ActiveHousehold;
                if (ah == null)
                    return null;
                return ah.LotHome;
            }

        }
        //public static Household ActiveHouseholdWithoutDGSCore
        //{
        //    get
        //    {
        //        if (PlumbBob.sSingleton == null || PlumbBob.sSingleton.mSelectedActor == null) return null;
        //        return PlumbBob.sSingleton.mSelectedActor.Household;
        //    }
        //
        //}
        public static InteractionInstance _GetCurrentInteraction(Sim sim)
        {
            if (sim.mInteractionQueue != null)  // Custom 3:08 18/05/2019
            {
                return sim.mInteractionQueue.GetCurrentInteraction();
            }
            return null;
        }
        public static InteractionInstance _GetCHeadInteraction(Sim sim)
        {
            //if (sim.mInteractionQueue != null)  // Custom 3:08 18/05/2019
            //{
            //    return sim.mInteractionQueue.GetHeadInteraction();
            //}
            if (sim.mInteractionQueue != null && sim.mInteractionQueue.mInteractionList != null && sim.mInteractionQueue.mInteractionList._items != null && sim.mInteractionQueue.mInteractionList._items.Length > 0)  // Custom 3:08 18/05/2019
            {
                return sim.mInteractionQueue.mInteractionList._items[0];
            }
            return null;
        }
        public static FieldInfo mCacheField_ForceWorldLotFromGrimReaper = null;

        public static bool OpenDGS_GetOrSet_ForceWorldLotFromGrimReaper
        {
            get
            {
                try
                {
                    if (mCacheField_ForceWorldLotFromGrimReaper != null)
                    {
                        return (bool)mCacheField_ForceWorldLotFromGrimReaper.GetValue(null);
                    }
                    if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        Type type = Type.GetType("Sims3.Gameplay.Moded.CommandHelperCore, Sims3GameplaySystems", false);
                        if (type != null)
                        {
                            FieldInfo mField = mCacheField_ForceWorldLotFromGrimReaper = type.GetField("ForceWorldLotFromGrimReaper", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (mField != null)
                            {
                                return (bool)mField.GetValue(null);
                            }
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                return false;
            }
            set
            {
                if (mCacheField_ForceWorldLotFromGrimReaper != null)
                {
                    mCacheField_ForceWorldLotFromGrimReaper.SetValue(null, value);
                }
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    Type type = Type.GetType("Sims3.Gameplay.Moded.CommandHelperCore, Sims3GameplaySystems", false);
                    if (type != null)
                    {
                        FieldInfo mField = mCacheField_ForceWorldLotFromGrimReaper = type.GetField("ForceWorldLotFromGrimReaper", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        if (mField != null)
                        {
                            mField.SetValue(null, value);
                        }
                    }
                }
            }
        }

        public static Sim SActorAndActiveActor_AAndChildAndTeen
        {
            get {
                Sim __ActiveActor = PlumbBob.SelectedActor;
                if (__ActiveActor != null && __ActiveActor.mSimDescription != null && MyActiveActor(__ActiveActor.mSimDescription))
                {
                    return __ActiveActor;
                }

                __ActiveActor = ActiveActor;
                if (__ActiveActor != null && __ActiveActor.mSimDescription != null && MyActiveActor(__ActiveActor.mSimDescription))
                {
                    return __ActiveActor;
                }
                return null;
            }
            set {
                if (ActiveActor_AAndChildAndTeen == value)
                    ActiveActor = value;
            }
        }

        public static Sim ActiveActor_AAndChildAndTeen
        {
            get
            {
                var __ActiveActor = ActiveActor;
                if (__ActiveActor != null && __ActiveActor.mSimDescription != null && MyActiveActor(__ActiveActor.mSimDescription))
                {
                    return __ActiveActor;
                }
                return null;
            }
            set
            {
                Sim valuea = value;
                if (valuea == null || valuea.mSimDescription == null || !MyActiveActor(valuea.mSimDescription))
                {
                    return;
                }
                ActiveActor = value;
            }
        }

        public static Sim SelectedActor_ChildAndTeen
        {
            get
            {
                Sim __ActiveActor = PlumbBob.SelectedActor;
                if (__ActiveActor != null && __ActiveActor.mSimDescription != null && MyActiveActor(__ActiveActor.mSimDescription))
                {
                    return __ActiveActor;
                }
                return null;
            }
            set
            {
                Sim valuea = value;
                if (valuea == null || valuea.mSimDescription == null || !MyActiveActor(valuea.mSimDescription))
                {
                    return;
                }
                PlumbBob.ForceSelectActor(value);
            }
        }

        public static 
            bool CustomApplyDeviantBehaviorToSim_IsSimValidPunisher (Sim sim)
        {
            if (!Instantiator.RootIsOpenDGSInstalled)
            {
                if (sim.IsSelectable && sim.SimDescription.YoungAdultOrAbove)
                {
                    return !sim.IsSleeping;
                }
                return false;
            }
            else
            {
                if (sim == null || sim.mSimDescription == null || sim.mSimDescription.IsPet) return false;
                if (sim.mSimDescription.YoungAdultOrAbove)
                {
                    return !sim.IsSleeping;
                }
                return false;
            }
        }

        public static 
            Sim CustomApplyDeviantBehaviorToSim_GetValidPunisher (Sim ownerPunishment)
        {


            //ulong faf = 0xF0005000F0000800;
            //faf.ToString();


            if (ownerPunishment.LotCurrent == null) 
                return null;

            List<Sim> adults = new List<Sim>();
            foreach (Sim Adult in ownerPunishment.LotCurrent.GetAllActors())
            {
                if (CustomApplyDeviantBehaviorToSim_IsSimValidPunisher(Adult))
                {
                    adults.Add(Adult);
                }
            }

            if (adults.Count > 0)
            {
                adults.Sort(delegate(Sim first, Sim second) {

                    bool roomIdFirst = first.RoomId == ownerPunishment.RoomId;
                    bool roomIdSecond = second.RoomId == ownerPunishment.RoomId;

                    if (roomIdFirst == roomIdSecond)
                    {
                        Vector3 position = ownerPunishment.Position;
                        float posFirst = (position - first.Position).LengthSqr();
                        float posSecond = (position - second.Position).LengthSqr();
                        return posFirst.CompareTo(posSecond);
                    }

                    if (!roomIdFirst)
                        return 1;

                    return -1;
                });
                return adults[0];
            }

            return null;
        }

        public static 
            List<Sim> CustomApplyDeviantBehaviorToSim_GetValidPunisherList (Sim ownerPunishment, bool ignoreWorldLot)
        {
            if (ownerPunishment.LotCurrent == null) 
                return null;

            if (!ignoreWorldLot && ownerPunishment.LotCurrent.IsWorldLot) 
                return null;

            List<Sim> adults = new List<Sim>();
            foreach (Sim adult in ownerPunishment.LotCurrent.GetAllActors())
            {
                if (CustomApplyDeviantBehaviorToSim_IsSimValidPunisher(adult))
                {
                    adults.Add(adult);
                }
            }
            if (adults.Count > 1)
            {
                adults.Sort(delegate(Sim first, Sim second) {

                    Simulator.Sleep(0);

                    bool roomIdFirst = first.RoomId == ownerPunishment.RoomId;
                    bool roomIdSecond = second.RoomId == ownerPunishment.RoomId;

                    if (roomIdFirst == roomIdSecond)
                    {
                        Vector3 ownerPosition = ownerPunishment.Position;
                        float posFirst = (ownerPosition - first.Position).LengthSqr();
                        float posSecond = (ownerPosition - second.Position).LengthSqr();
                        return posFirst.CompareTo(posSecond);
                    }

                    if (!roomIdFirst)
                        return 1;

                    return -1;
                });
            }
            return adults;
        }

        private static Assembly[] cacheGetAssemblies = null;

        private static Assembly[] cacheGetAssembliesEmtpy = null;
        private static Assembly[] cacheGetAssembliesEmtpyX = null;

        public static Assembly[] GetAssemblies()
        {
            if (cacheGetAssemblies == null)
                cacheGetAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            return (Assembly[])cacheGetAssemblies.Clone();
        }

        // Kill Mono Security :D
        public unsafe static
            void RemovePreventGetAssemblies()
        {
            GetAssemblies();
            if (func_address_GetAssemblies != 0)
            {
                var m01 = (MonoMethod)typeof(AppDomain).GetMethod
                    ("GetAssemblies", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(bool) }, null);

                if (m01 == null)
                    return;

                if (niec_script_func.niecmod_script_set_custom_native_function(m01.mhandle, new IntPtr() { value = (void*)func_address_GetAssemblies }))
                    func_address_GetAssemblies = 0;

                if (GetAssemblies().Length != AppDomain.CurrentDomain.GetAssemblies().Length)
                {
                    Assert("GetAssemblies().Length != AppDomain.CurrentDomain.GetAssemblies().Length");
                }
            }
        }

        // Kill Mono Security :D
        public unsafe static
            bool PreventGetAssemblies()
        {
            if (GameIs64Bit(false))
                return false;

            GetAssemblies();

            niec_native_func.OutputDebugString("PreventGetAssemblies() called");
            niec_native_func.OutputDebugString("Processing...");

            const string newNative = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌINF:AppDomain_PreventGetAssemblies()";

            var type = typeof(AppDomain);
            var m01 = (MonoMethod)type.GetMethod("GetAssemblies", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(bool) }, null);

            if (func_address_GetAssemblies == 0)
                func_address_GetAssemblies = niec_script_func.niecmod_script_get_func_ptr(m01.mhandle); // check null or (SIGSEGV)

            var tem = newNative.Length * 2 - 0x8;

            var native_address = (uint)newNative.obj_address();
            var func_address = native_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native_address + i) = 0xCCCCCCCC; //  Code for x86: CC int3
            }

            native_address.obj_address(); // check (SIGSEGV)

            // Code for x86:
            // B3 ........    mov eax, assemblyList.obj_address()
            // C3             ret

            if (cacheGetAssembliesEmtpy == null)
            {
                cacheGetAssembliesEmtpy = new Assembly[] { 
                    //AssemblyCheckByNiec.FindAssembly("mscorlib"),
                    //AssemblyCheckByNiec.FindAssembly("System"),
                    //AssemblyCheckByNiec.FindAssembly("System.Xml"),
                    //AssemblyCheckByNiec.FindAssembly("SimIFace")
                };

                GC.KeepAlive(cacheGetAssembliesEmtpy);

                AppDomain.CurrentDomain.SetData (
                    "GCAppDomain_PreventGetAssemblies()" + ((uint)cacheGetAssembliesEmtpy.obj_address() * 2) + "GC" + GetRandomID() + func_address,
                    cacheGetAssembliesEmtpy
                );
            }

            var t2 = (uint)cacheGetAssembliesEmtpy.obj_address();
            var func_addresstemp = func_address + 1;

            *(byte*)(func_address) = (byte)0xB8;
            *(uint*)(func_addresstemp) = t2;
            *(byte*)(func_addresstemp + 0x4) = (byte)0xC3;

            var b0 = niec_script_func.niecmod_script_set_custom_native_function(m01.mhandle, new IntPtr() { value = (void*)func_address });
            niec_native_func.OutputDebugString("Done! R: " + b0);

            Assert(
               AppDomain.CurrentDomain.GetAssemblies().Length == 0,
               "AppDomain.CurrentDomain.GetAssemblies().Length == 0 failed."
            );

            return b0;
        }

        // Kill Mono Security :D
        public unsafe static
            bool SafePreventGetAssemblies()
        {
            if (GameIs64Bit(false))
                return false;

            GetAssemblies();

            niec_native_func.OutputDebugString("SafePreventGetAssemblies() called");
            niec_native_func.OutputDebugString("Processing...");

            const string newNative = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌINF:AppDomain_SafePreventGetAssemblies()";

            var type = typeof(AppDomain);
            var m01 = (MonoMethod)type.GetMethod("GetAssemblies", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(bool) }, null);

            if (func_address_GetAssemblies == 0)
                func_address_GetAssemblies = niec_script_func.niecmod_script_get_func_ptr(m01.mhandle); // check null or (SIGSEGV)

            var tem = newNative.Length * 2 - 0x8;

            var native_address = (uint)newNative.obj_address();
            var func_address = native_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native_address + i) = 0xCCCCCCCC; //  Code for x86: CC int3
            }

            native_address.obj_address(); // check (SIGSEGV)

            // Code for x86:
            // B3 ........    mov eax, assemblyList.obj_address()
            // C3             ret

            var assertCheckL = 0;

            if (cacheGetAssembliesEmtpyX == null)
            {
                //cacheGetAssembliesEmtpyX = new Assembly[] { 
                //    AssemblyCheckByNiec.FindAssembly("mscorlib"),
                //    AssemblyCheckByNiec.FindAssembly("System"),
                //    AssemblyCheckByNiec.FindAssembly("System.Xml"),
                //    AssemblyCheckByNiec.FindAssembly("Sims3GameplayObjects"),
                //    AssemblyCheckByNiec.FindAssembly("Sims3GameplaySystems"),
                //    AssemblyCheckByNiec.FindAssembly("NRaasTraveler"),
                //    AssemblyCheckByNiec.FindAssembly("NRaasErrorTrap"),
                //    AssemblyCheckByNiec.FindAssembly("SimIFace")
                //};

                var tListAssembly = new List<Assembly>();

                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("mscorlib"));
                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("SimIFace"));

                //tListAssembly.Add(AssemblyCheckByNiec.FindAssembly("System"));
                //tListAssembly.Add(AssemblyCheckByNiec.FindAssembly("System.Xml"));

                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("Sims3GameplayObjects"));
                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("Sims3GameplaySystems"));

                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("NRaasTraveler"));
                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("NRaasErrorTrap"));
                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("NRaasGoHere"));
                tListAssembly.Add(AssemblyCheckByNiec.FindAssemblyPro("NRaasSelector"));

                while (tListAssembly.Remove(null));

                cacheGetAssembliesEmtpyX = tListAssembly.ToArray();

                tListAssembly.Clear();

                GC.KeepAlive(cacheGetAssembliesEmtpyX);

                AppDomain.CurrentDomain.SetData(
                    "GCAppDomain_SafePreventGetAssemblies()" + ((uint)cacheGetAssembliesEmtpyX.obj_address() * 2) + "GC" + GetRandomID() + func_address,
                    cacheGetAssembliesEmtpyX
                );

                assertCheckL = cacheGetAssembliesEmtpyX.Length;
            }
            else 
                assertCheckL = cacheGetAssembliesEmtpyX.Length;

            var t2 = (uint)cacheGetAssembliesEmtpyX.obj_address();
            var func_addresstemp = func_address + 1;

            *(byte*)(func_address) = (byte)0xB8;
            *(uint*)(func_addresstemp) = t2;
            *(byte*)(func_addresstemp + 0x4) = (byte)0xC3;

            var b0 = niec_script_func.niecmod_script_set_custom_native_function(m01.mhandle, new IntPtr() { value = (void*)func_address });
            niec_native_func.OutputDebugString("Done! R: " + b0);

            Assert(
                assertCheckL == AppDomain.CurrentDomain.GetAssemblies().Length,
                "assertCheckL == AppDomain.CurrentDomain.GetAssemblies().Length failed."
            );

            return b0;
        }

        // Kill Mono Security :D
        public unsafe static
            bool UnsafePreventGetAssemblies()
        {
            if (GameIs64Bit(false))
                return false;

            GetAssemblies();

            niec_native_func.OutputDebugString("UnsafePreventGetAssemblies() called");
            niec_native_func.OutputDebugString("Processing...");

            const string newNative = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌINF:AppDomain_UnsafePreventGetAssemblies()";

            var type = typeof(AppDomain);
            var m01 = (MonoMethod)type.GetMethod("GetAssemblies", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(bool) }, null);

            if (func_address_GetAssemblies == 0)
                func_address_GetAssemblies = niec_script_func.niecmod_script_get_func_ptr(m01.mhandle); // check null or (SIGSEGV)

            var tem = newNative.Length * 2 - 0x8;

            var native_address = (uint)newNative.obj_address();
            var func_address = native_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native_address + i) = 0xCCCCCCCC; //  Code for x86: CC int3
            }

            native_address.obj_address(); // check (SIGSEGV)

            // Code for x86:
            // 31 C0          xor eax, eax
            // C3             ret
            // CC             int3

            *(uint*)(func_address) = SwapOrgerBit32(0x31C0C3CCu);

            var b0 = niec_script_func.niecmod_script_set_custom_native_function(m01.mhandle, new IntPtr() { value = (void*)func_address });

            niec_native_func.OutputDebugString("Done! R: " + b0);
            func_address_xoreret_all = func_address;

            Assert(
               AppDomain.CurrentDomain.GetAssemblies() == null,
               "AppDomain.CurrentDomain.GetAssemblies() == null failed."
            );

            return b0;
        }

        public unsafe static bool NiecModIs64Bit()
        {
#if NiecMod_Native_64_bit
            return true;
#else 
            return false;
#endif
        }

        public unsafe static bool GameIs64Bit(bool shouldAssert)
        {
            if (sizeof(void*) == 0x8)
            {
                if (shouldAssert)
                    Assert("Sims 3 64 bit Found!");
                return true;
            }
            return false;

        }

        public static uint func_address_GetAssemblies = 0;
        public static uint func_address_xoreret_all = 0;
        public static uint func_address_ret_all = 0;

        // Kill Mono Security :D
        public unsafe static
            bool PreventSetYieldingDisabled()
        {
            if (GameIs64Bit(false))
                return false;

            niec_native_func.OutputDebugString("PreventSetYieldingDisabled() called");
            niec_native_func.OutputDebugString("Processing...");

            //ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(false);

            const string newNative = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌINF:Simulator_PreventSetYieldingDisabled()";

            var type = typeof(ScriptCore.Simulator);
            var m01 = (MonoMethod)type.GetMethod("Simulator_SetYieldingDisabledImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            m01.GetType(); // check null
            m01.ToString(); // check null or (SIGSEGV)

            var tem = newNative.Length * 2 - 0x8;

            var native_address = (uint)newNative.obj_address();
            var func_address = native_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native_address + i) = 0xCCCCCCCC; //  Code for x86: CC int3
            }

            native_address.obj_address(); // check (SIGSEGV)

            // Code for x86:
            // C3             ret
            // CC             int3
            // CC             int3
            // CC             int3

            *(uint*)(func_address) = SwapOrgerBit32(0xC3CCCCCC);

            var b0 = niec_script_func.niecmod_script_set_custom_native_function_dll(m01.mhandle, func_address);
            var b1 = niec_script_func.niecmod_script_set_custom_native_function(m01.mhandle, new IntPtr() { value = (void*)func_address });
            var b2 = false;
            var b3 = false;

            type = typeof(ScriptCore.UTFConnectorSimulator);
            var m02 = (MonoMethod)type.GetMethod("Simulator_SetYieldingDisabledImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (m02 != null)
            {
                b2 = niec_script_func.niecmod_script_set_custom_native_function_dll(m02.mhandle, func_address);
                b3 = niec_script_func.niecmod_script_set_custom_native_function(m02.mhandle, new IntPtr() { value = (void*)func_address });
            }

            /* Debugger app log
            DebugString: "PreventSetYieldingDisabled() called"
            DebugString: "Name Methed: Simulator_SetYieldingDisabledImpl"
            DebugString: "native_function_dll OK: True"
            DebugString: "native_function OK: True"
            DebugString: "func address: 0x81EAF94"
            DebugString: "Methed Handle address: 0x38AF8140"
            DebugString: "Object address: 0x35FF1EB8"
            DebugString: "Name Methed: UTFConnectorSimulator_SetYieldingDisabledImpl"
            DebugString: "native_function_dll OK: False"
            DebugString: "native_function OK: True"
            DebugString: "Methed Handle address: 0x4B7C42E8"
            DebugString: "Object address: 0x36FE6AF8"
             */

            niec_native_func.OutputDebugString("Name Methed: Simulator_SetYieldingDisabledImpl");
            niec_native_func.OutputDebugString("native_function_dll OK: " + b0);
            niec_native_func.OutputDebugString("native_function OK: " + b1);
            niec_native_func.OutputDebugString("func address: 0x" + ((uint)func_address).ToString("X"));
            niec_native_func.OutputDebugString("Methed Handle address: 0x" + ((uint)m01.mhandle).ToString("X"));
            niec_native_func.OutputDebugString("Object address: 0x" + ((uint)m01.obj_address()).ToString("X"));

            if (m02 != null)
            {
                niec_native_func.OutputDebugString("Name Methed: UTFConnectorSimulator_SetYieldingDisabledImpl");
                niec_native_func.OutputDebugString("native_function_dll OK: " + b2);
                niec_native_func.OutputDebugString("native_function OK: " + b3);
                niec_native_func.OutputDebugString("Methed Handle address: 0x" + ((uint)m02.mhandle).ToString("X"));
                niec_native_func.OutputDebugString("Object address: 0x" + ((uint)m02.obj_address()).ToString("X"));
            }

            if (b0 || b1)
            {
                func_address_ret_all = func_address;
                niec_native_func.OutputDebugString("Done!");
                return true;
            }
            else {
                niec_native_func.OutputDebugString("Failed!");
                Assert("PSYD() Failed.");
                return false;
            }
        }

        public static
            void MoveOutAllHousehold()
        {
            List<Household> asdrt = new List<Household>();
            try
            {
                foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                {
                    if (item == null) continue;
                    if (!asdrt.Contains(item))
                    {
                        asdrt.Add(item);
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            try
            {
                foreach (var item in Household.sHouseholdList.ToArray())
                {
                    if (item == null) continue;
                    if (!asdrt.Contains(item))
                    {
                        asdrt.Add(item);
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            foreach (var item in asdrt)
            {
                if (item == null)
                {
                    continue;
                }
                if (item == Household.ActiveHousehold || (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && item == PlumbBob.sSingleton.mSelectedActor.Household))
                    continue;
                Lot lothome = item.LotHome;
                if (lothome == null) continue;
                try
                {
                    lothome.MoveOut(item);
                    lothome.mHousehold = null;
                    item.mLotHome = null;
                    item.mLotId = 0;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    lothome.mHousehold = null;
                    item.mLotHome = null;
                    item.mLotId = 0;
                }
            }

            foreach (Lot lot in LotManager.AllLots)
            {
                if (lot == null) continue;



                Household t = lot.Household;

                if (t != null && (t == Household.ActiveHousehold || (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && t == PlumbBob.sSingleton.mSelectedActor.Household)))
                    continue;

                lot.mHousehold = null;
                if (t != null)
                {
                    t.mLotHome = null;
                    t.mLotId = 0;
                }

            }

        }


        public static 
            bool CustomApplyDeviantBehaviorToSim
            (Punishment bPunish, Punishment.DeviantBehaviorType type, bool throwOnArgInvalid, bool bUnsafe, int maxCount)
        {
            if (bPunish == null)
            {
                if (throwOnArgInvalid)
                    throw new ArgumentNullException("bPunish");
                else 
                    return false;

            }
            if (maxCount < 0)
            {
                if (throwOnArgInvalid)
                    throw new ArgumentOutOfRangeException("maxCount");
                else
                    return false;
            }
            else if (maxCount == 0) return false;



            Sim OwnerPunishment = bPunish.mOwner;
            if (OwnerPunishment == null || OwnerPunishment.InteractionQueue == null || OwnerPunishment.SimDescription == null || OwnerPunishment.HasBeenDestroyed || OwnerPunishment.IsSleeping || OwnerPunishment.LotCurrent == null || (OwnerPunishment.Posture is SwimmingInPool)) 
                return false;

            if (!Instantiator.RootIsOpenDGSInstalled && !OwnerPunishment.IsSelectable)
                return false;

            if (bPunish.mUnpunishedDeviantBehaviors == null)
                bPunish.mUnpunishedDeviantBehaviors = new Queue<Punishment.DeviantBehaviorInstance>();

            if (bPunish.mUnpunishedDeviantBehaviors.Count < 10)
            {
                Punishment.DeviantBehaviorInstance item = new Punishment.DeviantBehaviorInstance(type, SimClock.CurrentTime());
                bPunish.mUnpunishedDeviantBehaviors.Enqueue(item);
            }


            if (!bPunish.HasUnpunishedDeviantBehaviors())
            {
                Punishment.ClearEventListener(ref bPunish.mSimsChangedLotsListener);
                Punishment.ClearAlarmHandle(OwnerPunishment, ref bPunish.mScoldTryAgainAlarm);
                //return true;
            }


            int minCount = 0;

            bool Ok = false;

            foreach (Sim validPunisher in ( 
                    bUnsafe ? SC_GetObjectsOnLot<Sim>(OwnerPunishment.LotCurrent) : //OwnerPunishment.LotCurrent.GetSims() : 
                    ( CustomApplyDeviantBehaviorToSim_GetValidPunisherList(OwnerPunishment, true) ?? OwnerPunishment.LotCurrent.GetSims() )
                ))
            {

                if (minCount == maxCount) break;

                if (validPunisher != null && 
                    !validPunisher.mIsSleeping && 
                    validPunisher.mSimDescription != null && 
                    validPunisher.mSimDescription.YoungAdultOrAbove)
                {


                    if (OwnerPunishment.InteractionQueue == null || OwnerPunishment.InteractionQueue.HasInteractionOfType(typeof(Punishment.DoTimeOut)))
                        break;

                    if (validPunisher.InteractionQueue == null) 
                        continue;

                    bool continueChild = false;


                    if (validPunisher.InteractionQueue.mInteractionList.Count > 7) continue;

                    foreach (InteractionInstance interaction in validPunisher.InteractionQueue.InteractionList)
                    {
                        var socialInteractionA = interaction as SocialInteractionA;
                        if (socialInteractionA != null && socialInteractionA.Target == OwnerPunishment)
                        {
                            var socialDefinition = socialInteractionA.InteractionDefinition as SocialInteractionA.Definition;
                            if (socialDefinition != null && socialDefinition.ActionKey == "Punishment Scold")
                            {
                                Ok = true;
                                minCount++;
                                Simulator.Sleep(10);
                                continueChild = true;
                                break;
                            }
                        }
                    }

                    if (continueChild) 
                        continue;

                    //var OwnerPunishmentInteractionQueue = OwnerPunishment.InteractionQueue;

                    //if (OwnerPunishmentInteractionQueue == null || OwnerPunishmentInteractionQueue.mInteractionList.Count > maxCount) 
                    if (OwnerPunishment.InteractionQueue == null)
                        break;

                    bPunish.ApplyPendingDeviantBehaviors();

                    if (Sim.ForceSocial (
                            actor: validPunisher, 
                            target: OwnerPunishment, 
                            socialName: "Punishment Scold", 
                            priority: ( 
                                Instantiator.RootIsOpenDGSInstalled ? InteractionPriorityLevel.RequiredNPCBehavior : 
                                    InteractionPriorityLevel.High
                            ),
                            cancelable: true
                        )) 
                    {
                        minCount++;
                        Simulator.Sleep(50); 
                        Ok = true; 
                    }

                    else
                        Simulator.Sleep(0);
                }
            }

            //Punishment.ClearEventListener(ref bPunish.mSimsChangedLotsListener);
            //Punishment.ClearAlarmHandle(OwnerPunishment, ref bPunish.mScoldTryAgainAlarm);

            return Ok;
        }

        public static void SendHomeForSimList(IEnumerable<Sim> simList)
        {
            foreach (var item in simList ?? SC_GetObjects<Sim>())
            {
                SendHomeForSim(item);
            }
        }

        public static void SendHomeForSim(Sim item)
        {
            if (item == null || NiecHelperSituation.SimHasBeenDestroyed(item))
                return;

            SimDescription simd = item.SimDescription;
            if (simd == null)
                return;

            if (simd.LotHome == null)
                return;
            if (item.LotCurrent == simd.LotHome)
                return;

            Vector3 pos = Vector3.OutOfWorld;
            Vector3 fwd = Vector3.OutOfWorld;


            try
            {
                if (item.AttemptToFindSafeLocation(true, out pos, out fwd))
                {

                    item.SetPosition(pos);
                    item.SetForward(fwd);

                    if (item.SimRoutingComponent != null)
                        item.SimRoutingComponent.ForceUpdateDynamicFootprint();

                    Simulator.Sleep(0);
                    if (item.LotCurrent == item.LotHome)
                        return;
                }
            }
            catch (ResetException) { throw; }
            catch (Exception)
            {
                if (item.LotCurrent == item.LotHome)
                    return;
            }


            Mailbox mailbox = item.LotHome.FindMailbox();
            World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(mailbox != null ? mailbox.Position : item.LotHome.Position);
            fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0xF);
            fglParams.BooleanConstraints = FindGoodLocationBooleans.None;



            if (!GlobalFunctions.FindGoodLocation(item, fglParams, out pos, out fwd))
            {
                if (mailbox != null)
                {
                    pos = mailbox.Position;
                    fwd = mailbox.ForwardVector;
                }
                else
                {
                    pos = item.LotHome.Position;
                    fwd = item.LotHome.ForwardVector;
                }

            }

            item.SetPosition(pos);
            item.SetForward(fwd);

            if (item.SimRoutingComponent != null)
                item.SimRoutingComponent.ForceUpdateDynamicFootprint();
        }

        internal static void Show_MessageDialog(string message) { Sims3.UI.SimpleMessageDialog.Show("NiecMod", message ?? "no message"); }

        public static int GetIntDialog(string promptText)
        {
            Simulator.CheckYieldingContext(true);
            Simulator.Sleep(0);
            string str = StringInputDialog.Show(
                "NiecMod",
                promptText ?? "Number Dialog",
                "0",
                StringInputDialog.Validation.None
            );

            if (NFinalizeDeath.IsNullOrEmpty(str))
                return -101;

            int ix; bool noError = int.TryParse (
                str,
                out ix
            );

            if (!noError) 
                return -102;

            return ix;
        }

        public static
            int Lot_GetCost(Lot TargetLot)
        {
            return TargetLot == null ? 0 : (Create.GetAllCostLot(TargetLot) + World.GetLotWorth(TargetLot.LotId)); 
        }

        public static 
            Vector3 Lot_SafeGetPositionInRandomLot(Lot lot)
        {
            Vector3 vector = Vector3.Origin;
            Vector3[] posResults;
            Quaternion[] orientResults;

            if (lot == null && (LotManager.sLots == null || LotManager.sLots.Count == 0))
            {
                if (World.FindPlaceOnRoadOffScreen(null, vector, FindPlaceOnRoadOption.FootpathOrSidewalk, 30f, out posResults, out orientResults) && posResults != null && posResults.Length > 0)
                {
                    return posResults[0];
                }
                if (World.FindPlaceOnRoadOffScreen(null, vector, FindPlaceOnRoadOption.FootpathOrSidewalk, 200f, out posResults, out orientResults) && posResults != null && posResults.Length > 0)
                {
                    return posResults[0];
                }
                Vector3 posResult = Vector3.Invalid;
                Quaternion orientResult = Quaternion.Identity;
                if (World.FindPlaceOnRoad(null, vector, 4u, ref posResult, ref orientResult))
                {
                    return posResult;
                }
                return vector;
            }
            
            if (lot != null)
            {
                vector = lot.EntryPoint();
            }
            else if (LotManager.AllLots.Count > 0)
            {
                Lot[] array = new Lot[LotManager.AllLots.Count];
                LotManager.AllLots.CopyTo(array, 0);
                lot = array[RandomUtil.GetInt(array.Length - 1)];
            }
            
            if (World.FindPlaceOnRoadOffScreen(null, vector, FindPlaceOnRoadOption.FootpathOrSidewalk, 30f, out posResults, out orientResults) && posResults != null && posResults.Length > 0)
            {
                return posResults[0];
            }
            if (World.FindPlaceOnRoadOffScreen(null, vector, FindPlaceOnRoadOption.FootpathOrSidewalk, 200f, out posResults, out orientResults) && posResults != null && posResults.Length > 0)
            {
                return posResults[0];
            }
            if (lot != null)
            {
                uint offsetHint = 0u;
                Vector3 outPos = Vector3.Invalid;
                if (LotManager.FindPlaceOutsideLot(lot, ref offsetHint, ref outPos))
                {
                    return outPos;
                }
            }
            return vector;
        }

        public static
            void MergeHousehold(Household sourceHousehold, Household targetHousehold, bool bNeedGoHome)
        {
            if (sourceHousehold == null || targetHousehold == null) 
                return;

            if (sourceHousehold == targetHousehold) 
                return;

            var activeActor = ActiveActor;
            var sourceHouseholdIsActive = sourceHousehold == ActiveHousehold || sourceHousehold == Household.ActiveHousehold;

            RemoveNullForHouseholdMembers(sourceHousehold);
            RemoveNullForHouseholdMembers(targetHousehold);

            var memberSourceHousehold = sourceHousehold.mMembers;
            var simList = memberSourceHousehold.mAllSimDescriptions.ToArray();

            foreach (var item in simList)
            {
                if (item == null)
                    continue;
                Household_Remove(item, true);
                item.mHousehold = null;
            }

            memberSourceHousehold.mAllSimDescriptions.Clear();
            memberSourceHousehold.mPetSimDescriptions.Clear();
            memberSourceHousehold.mSimDescriptions.Clear();

            targetHousehold.mFamilyFunds += (sourceHousehold.FamilyFunds + Lot_GetCost(sourceHousehold.LotHome));

            if (sourceHouseholdIsActive)
            {
                using (TempSetActiveActorAndHousehold.Run(null))
                {
                    HouseholdCleanse(sourceHousehold, true, true);
                }
            }
            else { HouseholdCleanse(sourceHousehold, true, true); }

            var lotHome = targetHousehold.LotHome;

            foreach (var item in simList)
            {
                if (Household_Add(targetHousehold, item, true) && bNeedGoHome && lotHome != null)
                    SimDesc_SafeInstantiate(item, Lot_SafeGetPositionInRandomLot(lotHome));
            }

            if (targetHousehold.AllActors.Count == 0) 
                return;

            if (sourceHouseholdIsActive)
            {
                PlumbBob.sCurrentNonNullHousehold = null;
                ActiveActor = null;
                if (NiecHelperSituation.SimHasBeenDestroyed(activeActor))
                {
                    ActiveActor = HouseholdMembersToSim(targetHousehold, false, false) ?? HouseholdMembersToSim(targetHousehold, true, false);
                }
                else {
                    ActiveActor = activeActor;
                }
            }

            if (!bNeedGoHome) 
                return;

           
            var iGoHome = GoHome.Singleton;
            if (lotHome == null || iGoHome == null) 
                return;

            try
            {
                foreach (var item in simList)
                {
                    if (item == null)
                        continue;
                    var itemSim = item.CreatedSim;
                    if (itemSim == null)
                        continue;
                    var iq = itemSim.InteractionQueue;
                    if (iq != null && iq.mInteractionList != null)
                    {
                        iq.Add(iGoHome.CreateInstance(lotHome, itemSim, new InteractionPriority(InteractionPriorityLevel.High), false, true));
                    }
                }
            } 
            catch (ResetException){ throw; }
            catch (Exception){}
            
        }

        public static
            bool InfoPackagesLib_HasPets(List<Sims3.UI.GameEntry.UISimInfo> householdMembers)
        {
            foreach (var householdSim in householdMembers.ToArray())
            {
                if (householdSim.Species != 0 && householdSim.Species != CASAgeGenderFlags.Human)
                {
                    return true;
                }
            }
            return false;
        }

        public static
           int InfoPackagesLib_PetsCount(List<Sims3.UI.GameEntry.UISimInfo> householdMembers)
        {
            int i = 0;
            foreach (var householdSim in householdMembers.ToArray())
            {
                if (householdSim.Species != 0 && householdSim.Species != CASAgeGenderFlags.Human)
                {
                    i++;
                }
            }
            return i;
        }

        public static
            void GC_Emp(object obj) 
        {
            if (obj == obj.GetType())
                CheckMorun();
        }

        public static 
            string InfoPackagesLib()
        {
            if (BinModel.sBinModel == null || BinModel.sBinModel.mExportBin == null) 
                return null;

            if (BinModel.sBinModel.mExportBin._items == null)
                List_FastClearEx(ref BinModel.sBinModel.mExportBin);

            if (BinModel.sBinModel.mExportBin.Count == 0) 
                return null;

            //string[] packageNames = ExportBin.GetPackageNames();
            //if (packageNames == null || packageNames.Length == 0)
            //{
            //    return null;
            //}

            var exportBinlist = new List<ExportBinContents>(BinModel.sBinModel.mExportBin ?? new List<ExportBinContents>());
            Comparison<ExportBinContents> sortTime = delegate(ExportBinContents a, ExportBinContents b) {
                if (a == b)
                {
                    return 0;
                }
                if (a == null)
                {
                    return -1;
                }
                if (b == null)
                {
                    return 1;
                }
                return b.ExportDateTime.CompareTo(a.ExportDateTime);
            };

            try
            {
                if (sortTime != null)
                    exportBinlist.Sort(sortTime);
            }
            catch (Exception)
            {}
            
            StringBuilder sb = new StringBuilder();

            sb.Append("InfoPackagesLib() Count: " + BinModel.sBinModel.mExportBin.Count);
            sb.AppendLine();

            sb.Append("--------------------- Start ---------------------");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();

            sb.Append("-------------------------------------------------------");
            sb.AppendLine();

            int no = 0;
            foreach (var item in exportBinlist.ToArray())
            {
                if (item == null) 
                    continue;
                no++;

                sb.Append("No: " + no);
                sb.AppendLine();
                // -----------------

                sb.Append("Package Name: " + (item.PackageName ?? "NULL"));
                sb.AppendLine();
                // -----------------

                sb.Append("Export Date: " + item.ExportDateTime.ToString());
                sb.AppendLine();
                // -----------------

                sb.Append("Modified Date: " + item.ModifiedDateTime.ToString());
                sb.AppendLine();

                sb.Append("-------------------------------------------------------");
                sb.AppendLine();
                // -----------------

                sb.AppendLine();

                try
                {
                    string t;
                    switch (item.mExportBinType)
                    {
                        case Sims3.UI.GameEntry.ExportBinType.Household:
                            sb.Append("-Household-");
                            sb.AppendLine();

                            sb.Append("  Name: " + item.HouseholdName + "\n");
                            sb.Append("  ID: " + item.HouseholdId + "\n");
                            t = IsNullOrEmpty(item.HouseholdBio) ? "[None]" : item.HouseholdBio;
                            sb.Append("  Bio: " + t + "\n");
                            sb.Append("  Funds: " + item.HouseholdFunds + "\n");
                            sb.Append("  Difficulty: " + item.HouseholdDifficulty + "\n");
                            sb.Append("  Sims Count: " + item.HouseholdSims.Count + "\n");
                            sb.Append("  Pets Count: " + InfoPackagesLib_PetsCount(item.HouseholdSims) + "\n");
                            sb.Append("  Has Pets: " + InfoPackagesLib_HasPets(item.HouseholdSims) + "\n");

                            break;
                        case Sims3.UI.GameEntry.ExportBinType.HouseholdLot:
                            sb.Append("-Household And Lot-");
                            sb.AppendLine();

                            sb.Append("  Lot Name: " + item.LotName + "\n");
                            sb.Append("  Lot ID: " + item.LotId + "\n");
                            sb.Append("  Lot Worth: " + item.LotWorth + "\n");
                            sb.Append("  Lot Size_X: " + item.LotContentsSizeX + "\n");
                            sb.Append("  Lot Size_Y: " + item.LotContentsSizeY + "\n");
                            t = IsNullOrEmpty(item.LotDescription) ? "[None]" : item.LotDescription;
                            sb.Append("  Lot Description: " + t + "\n");

                            sb.Append("  ---------------------------------------------------\n");

                            sb.Append("  Household Name: " + item.HouseholdName + "\n");
                            sb.Append("  Household ID: " + item.HouseholdId + "\n");
                            t = IsNullOrEmpty(item.HouseholdBio) ? "[None]" : item.HouseholdBio;
                            sb.Append("  Household Bio: " + t + "\n");
                            sb.Append("  Household Funds: " + item.HouseholdFunds + "\n");
                            sb.Append("  Household Difficulty: " + item.HouseholdDifficulty + "\n");
                            sb.Append("  Household Sims Count: " + item.HouseholdSims.Count + "\n");
                            sb.Append("  Household Pets Count: " + InfoPackagesLib_PetsCount(item.HouseholdSims) + "\n");
                            sb.Append("  Household Has Pets: " + InfoPackagesLib_HasPets(item.HouseholdSims) + "\n");

                            break;
                        case Sims3.UI.GameEntry.ExportBinType.Lot:
                            sb.Append("-Lot-");
                            sb.AppendLine();
                            
                            sb.Append("  Name: " + item.LotName + "\n");
                            sb.Append("  ID: " + item.LotId + "\n");
                            sb.Append("  Lot Worth: " + item.LotWorth + "\n");
                            sb.Append("  Size_X: " + item.LotContentsSizeX + "\n");
                            sb.Append("  Size_Y: " + item.LotContentsSizeY + "\n");
                            t = IsNullOrEmpty(item.LotDescription) ? "[None]" : item.LotDescription;
                            sb.Append("  Description: " + t + "\n");

                            break;
                        default:
                            sb.Append("Unkrown? Type: " + item.mExportBinType);
                            continue;
                    }
                }
                // see MsCorlibModifed
                catch (ExecutionEngineException) 
                {
                    sb.Append("-- Canceled --");
                    break;
                }
                catch (StackOverflowException)
                {
                    break;
                }
                catch (Exception ex)
                { sb.Append("-- Bad Package ExceptionMessage: " + ex.Message + " --"); }
                
                sb.AppendLine();
                sb.Append("-------------------------------------------------------");
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("--------------------- End ---------------------");
            exportBinlist.Clear();

            uint key = 0;
            string createFile = Simulator.CreateExportFile(ref key, "InfoPackageLib");

            if (key == 0 || createFile == null)
                return sb.ToString();

            sb.Append("\nFile Name: " + createFile + "\nDate: " + DateTime.Now.ToString());
            sb.AppendLine();
            sb.AppendLine();
            for (int i = 0; i < 15; i++)
            {
                sb.Append('\0');
            }

            // i did GC BUG
            var result = sb.ToString();
            //var v = result.ToCharArray();

            if (!Simulator.AppendToScriptErrorFile(key, result.ToCharArray()))
                return result;
            
            Simulator.CloseScriptErrorFile(key);
            
            return result;
            //return "E:\\My OAS\\Niec And Linc\\NiecMod\\Interactions\\Overrides\\OverrideClass.cs";
        }

        public static void NResetAllAnimation(Sim _this)
        {
            AnimationUtil.StopAllAnimation(_this);

            if (_this.OverlayComponent != null)
            {
                _this.OverlayComponent.StopAllOverlays();
            }

            if (_this.CarryStateMachine != null)
            {
                _this.CarryStateMachine.Dispose();
                _this.CarryStateMachine = null;
            }

            var tt = _this.IdleManager;
            if (tt != null && tt.FacialIdleStateMachineClient != null)
            {
                tt.FacialIdleStateMachineClient.Dispose();
                tt.FacialIdleStateMachineClient = null;
            }

            if (_this.Standing != null)
                _this.Standing.OnReset(_this);
        }



        public static void SafeXRemoveMourningRelatedBuffs(Sim simWhoDied)
        {
            if (simWhoDied == null)
                return;
            foreach (Relationship relationship in Relationship.GetRelationships(simWhoDied))
            {
                if (relationship == null)
                    continue;

                Sim otherSim = relationship.GetOtherSim(simWhoDied);
                if (otherSim == null || otherSim.BuffManager == null)
                {
                    continue;
                }

                if (otherSim.BuffManager.HasElement(BuffNames.HeartBroken))
                {
                    var buffInstanceHeartBroken = otherSim.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken;
                    if (buffInstanceHeartBroken != null && buffInstanceHeartBroken.MissedSim == simWhoDied.SimDescription)
                    {
                        otherSim.BuffManager.RemoveElement(BuffNames.HeartBroken);
                    }
                }

                if (otherSim.BuffManager.HasElement(BuffNames.Mourning))
                {
                    var buffInstanceMourning = otherSim.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning;
                    if (buffInstanceMourning != null && buffInstanceMourning.MissedSim == simWhoDied.SimDescription)
                    {
                        otherSim.BuffManager.RemoveElement(BuffNames.Mourning);
                    }
                }
            }
        }

        public static void SafeXGhostSetup(Urnstone grave, Sim ghost, bool addReactionBroadcast, bool isAngry)
        {
            var simd = ghost.SimDescription;
            if (simd == null)
                return;

            if (ghost.CurrentOutfitCategory == OutfitCategories.Naked)
                ghost.SwitchToOutfitWithoutSpin(Sim.ClothesChangeReason.Force, OutfitCategories.Everyday);

            if (simd.ChildOrAbove)
            {
                grave.GhostTurnDeathEffectOff(VisualEffect.TransitionType.SoftTransition);
                bool deathFreeze = false;

                switch (simd.DeathStyle)
                {
                    case SimDescription.DeathType.Burn:
                    case SimDescription.DeathType.Meteor:
                    case SimDescription.DeathType.Jetpack:

                        if (simd.Child)
                            grave.mDeathEffect = VisualEffect.Create("ghostBurnSmokeChild");
                        else
                            grave.mDeathEffect = VisualEffect.Create("ghostBurnSmokeAdult");

                        if (grave.mDeathEffect == null)
                            break;

                        grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Spine2);
                        grave.mDeathEffect.Start();

                        if (ghost.Motives != null)
                            ghost.Motives.SetValue(CommodityKind.Hygiene, -80f);

                        break;
                    case SimDescription.DeathType.Drown:
                    case SimDescription.DeathType.WateryGrave:

                        if (simd.Age == CASAgeGenderFlags.Child) // if (simd.Child)
                            grave.mDeathEffect = VisualEffect.Create("ghostDrownDripsChild");
                        else
                            grave.mDeathEffect = VisualEffect.Create("ghostDrownDripsAdult");

                        if (grave.mDeathEffect == null)
                            break;

                        grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Pelvis);
                        grave.mDeathEffect.Start();

                        break;
                    case SimDescription.DeathType.Electrocution:
                        grave.TurnOnGhostElectrocutionEffects(ghost);
                        break;
                    case SimDescription.DeathType.OldAge:

                        grave.mDeathEffect = VisualEffect.Create("ghostOldAge");
                        if (grave.mDeathEffect == null)
                            break;

                        grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Pelvis);
                        grave.mDeathEffect.Start();

                        if (ghost.Motives != null)
                            ghost.Motives.SetValue(CommodityKind.Fun, -80f);

                        break;
                    case SimDescription.DeathType.Starve:

                        simd.SetBodyShape(-1f, 0f);

                        if (ghost.Motives != null)
                            ghost.Motives.SetValue(CommodityKind.Hunger, -80f);

                        break;
                    case SimDescription.DeathType.MummyCurse:
                        grave.TurnOnGhostMummysCurseEffects(ghost);
                        break;
                    case SimDescription.DeathType.Thirst:

                        simd.SetBodyShape(-1f, 0f);
                        if (ghost.Motives != null)
                            ghost.Motives.SetValue(CommodityKind.VampireThirst, -50f);

                        grave.mDeathEffect = VisualEffect.Create("ep3GhostVampire");
                        if (grave.mDeathEffect == null)
                            break;

                        grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Spine2);
                        grave.mDeathEffect.Start();

                        break;
                    case SimDescription.DeathType.PetOldAgeGood:
                    case SimDescription.DeathType.PetOldAgeBad:
                        switch (simd.Species)
                        {
                            case CASAgeGenderFlags.Horse:
                                grave.mDeathEffect = VisualEffect.Create("ep5GhostHorse");
                                break;
                            case CASAgeGenderFlags.Dog:
                                grave.mDeathEffect = VisualEffect.Create("ep5GhostDog");
                                break;
                            case CASAgeGenderFlags.Cat:
                            case CASAgeGenderFlags.LittleDog:
                                grave.mDeathEffect = VisualEffect.Create("ep5GhostSmPet");
                                break;
                        }

                        if (grave.mDeathEffect != null)
                        {
                            grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Spine2);
                            grave.mDeathEffect.Start();
                        }

                        break;
                    case SimDescription.DeathType.Transmuted:
                    case SimDescription.DeathType.HauntingCurse:
                        grave.TurnOnComplexEffects(ghost);
                        break;
                    case SimDescription.DeathType.JellyBeanDeath:

                        grave.mDeathEffect = VisualEffect.Create("ep7GhostJellyBean_ghost");

                        if (grave.mDeathEffect == null)
                            break;

                        grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Spine0);
                        grave.mDeathEffect.Start();

                        break;
                    case SimDescription.DeathType.Freeze:

                        if (ghost.Motives != null)
                            ghost.Motives.SetValue(CommodityKind.Temperature, -80f);

                        grave.mDeathEffect = SimTemperature.GetParentedAndStartedColdBreathVisualEffectForSim(ghost);
                        deathFreeze = true;

                        break;
                    case SimDescription.DeathType.BluntForceTrauma:

                        grave.mDeathEffect = VisualEffect.Create("ep9GhostMurphyBed_ghost");
                        if (grave.mDeathEffect == null)
                            break;

                        grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Spine2);
                        grave.mDeathEffect.Start();

                        break;
                    case SimDescription.DeathType.Ranting:
                        grave.TurnOnComplexEffects(ghost);
                        break;
                    case SimDescription.DeathType.Shark:
                    case SimDescription.DeathType.ScubaDrown:

                        grave.mDeathEffect = VisualEffect.Create("ep10ScubaGhostBubbles");
                        if (grave.mDeathEffect == null)
                            break;

                        grave.mDeathEffect.ParentTo(ghost, Sim.FXJoints.Mouth);
                        grave.mDeathEffect.Start();

                        break;
                    case SimDescription.DeathType.MermaidDehydrated:

                        if (ghost.Motives != null)
                            ghost.Motives.SetValue(CommodityKind.MermaidDermalHydration, -80f);

                        break;
                }

                if (!deathFreeze && ghost.Motives != null)
                    ghost.Motives.SetValue(CommodityKind.Temperature, 0f);
            }

            if (simd.OccultManager != null)
            {
                var occultFairy = simd.OccultManager.GetOccultType(OccultTypes.Fairy) as OccultFairy;
                if (occultFairy != null)
                {
                    occultFairy.GrantWings();
                }
            }

            if (simd.SupernaturalData == null || simd.SupernaturalData.OccultType == OccultTypes.None)
            {
                simd.AddSupernaturalData(OccultTypes.Ghost);
                var casGhostData = simd.SupernaturalData as CASGhostData;
                if (casGhostData != null)
                {
                    casGhostData.DeathStyle = simd.DeathStyle;
                }
            }

            if (!simd.IsEP11Bot)
                World.ObjectSetGhostState(ghost.ObjectId, (uint)simd.DeathStyle, (uint)simd.AgeGenderSpecies);
            else
                World.ObjectSetGhostState(ghost.ObjectId, 23, (uint)simd.AgeGenderSpecies);

            if (ghost.Autonomy != null && ghost.Autonomy.Motives != null && ghost.Autonomy.InteractionScorer != null)
                ghost.Autonomy.Motives.CreateMotive(ghost, ghost.Autonomy.InteractionScorer, CommodityKind.BeGhostly);

            simd.IsGhost = true;

            if (!simd.IsFrankenstein && ghost.SimRoutingComponent != null && !ghost.SimRoutingComponent.IsWalkStyleRequested(Sim.WalkStyle.GhostWalk))
            {
                ghost.RequestWalkStyle(Sim.WalkStyle.GhostWalk);
            }

            if (addReactionBroadcast && ghost.GhostReactionBroadcast == null)
            {
                if (isAngry)
                    ghost.GhostReactionBroadcast = new ReactionBroadcaster
                        (ghost, grave.ReactToGhostBroadcastParams, GhostHunter.GhostHunterJob.OnPanicStart, null);
                else
                    ghost.GhostReactionBroadcast = new ReactionBroadcaster
                        (ghost, grave.ReactToGhostBroadcastParams, Urnstone.OnReactToGhost, null);

                ghost.SimsReactedToGhost = new List<Sim>();
            }
        }

        public static void SafeXGhostCleanup(Urnstone grave, Sim ghost, bool modifyHousehold, bool bDestroyHousehold)
        {
            if (ghost.Household != null && modifyHousehold)
            {
                if (bDestroyHousehold)
                {
                    Household_Remove(ghost.SimDescription, false);
                }
                else
                {
                    Household_Remove(ghost.SimDescription, true);
                }
            }

            if (ghost.GhostReactionBroadcast != null)
            {
                ghost.GhostReactionBroadcast.Dispose();
                ghost.GhostReactionBroadcast = null;
            }

            grave.GhostTurnDeathEffectOff(VisualEffect.TransitionType.SoftTransition);

            ghost.SimsReactedToGhost = null;

            grave.FogEffectStop(VisualEffect.TransitionType.SoftTransition);

            if (ghost.OccultManager != null && ghost.OccultManager.HasOccultType(OccultTypes.Fairy))
            {
                var occultFairy = ghost.OccultManager.GetOccultType(OccultTypes.Fairy) as OccultFairy;
                if (occultFairy != null)
                {
                    occultFairy.StopWingEffect();
                }
            }
        }

        public static void SafeXGhostToSim(Urnstone grave, Sim sim, bool bResetAge, bool modifyHousehold)
        {
            var simd = sim.SimDescription;
            if (simd == null)
                return;

            SafeXRemoveMourningRelatedBuffs(sim);

            simd.IsGhost = false;

            World.ObjectSetGhostState(sim.ObjectId, 0, (uint)simd.AgeGenderSpecies);

            if (sim.mAutonomy != null && sim.Autonomy.mMotives != null)
                sim.mAutonomy.mMotives.RemoveMotive(CommodityKind.BeGhostly);

            simd.SetDeathStyle(SimDescription.DeathType.None, false);
            simd.ShowSocialsOnSim = true;
            simd.IsNeverSelectable = false;

            if (sim.mAutonomy != null)
                sim.mAutonomy.AllowedToRunMetaAutonomy = true;

            if (!simd.IsFrankenstein)
            {
                sim.UnrequestWalkStyle(Sim.WalkStyle.GhostWalk);
            }

            if (sim.DeathReactionBroadcast != null)
            {
                sim.DeathReactionBroadcast.Dispose();
                sim.DeathReactionBroadcast = null;
            }

            if (!simd.IsEP11Bot && simd.AgingState != null)
            {
                simd.AgingEnabled = true;
                if (bResetAge)
                {
                    simd.AgingState.ResetAndExtendAgingStage(0f);
                }
            }

            SafeXGhostCleanup(grave, sim, modifyHousehold, true);

            if (modifyHousehold)
            {
                var orhousehold = grave.OriginalHousehold;
                if (simd.IsHuman)
                {
                    if (orhousehold != null)
                    {
                        Household_Remove(simd, false);
                        Household_Add(orhousehold, simd, false);
                    }
                }
                else
                {
                    if (orhousehold != null && simd.Household != orhousehold)
                    {
                        Household_Remove(simd, false);
                        Household_Add(orhousehold, simd, false);
                    }
                }

                var p = sim.LotCurrent;
                if (p != null && grave.LotCurrent != null && p.IsResidentialLot)
                {
                    sim.GreetSimOnLot(grave.LotCurrent);
                }
            }

            simd.PushAgingEnabledToAgingManager();
            simd.Contactable = true;

            if (AlarmManager.Global != null && grave.LotCurrent != null)
            {
                grave.DestroyGrave();
            }
            else
            {
                grave.Destroy();
            }

            if (simd.OccultManager != null)
            {
                var occultFairy = sim.SimDescription.OccultManager.GetOccultType(OccultTypes.Fairy) as OccultFairy;
                if (occultFairy != null)
                {
                    occultFairy.GrantWings();
                }
            }

            if (simd.SupernaturalData != null && simd.SupernaturalData.OccultType == OccultTypes.Ghost)
            {
                simd.RemoveSupernaturalData();
            }

            if (sim.MoodManager != null)
            {
                var hudModel = (HudModel)Sims3.UI.Responder.Instance.HudModel;
                if (hudModel != null)
                {
                    sim.MoodManager.TriggerMoodChanged();
                    hudModel.OnSimAppearanceChanged(sim.ObjectId);
                }
            }
        }


        public static void TraitManagerFixUp(SimDescription item, bool needNew)
        {
            TraitManager tm = item.TraitManager;
            if (tm == null)
            {
                if (needNew) 
                {
                    item.mTraitManager = new TraitManager();

                    item.mTraitManager.SetSimDescription(item);

                    if (item.mTraitManager.mValues == null)
                        item.mTraitManager.mValues = new Dictionary<ulong, Trait>();
                }
                else
                    return;
            }
            else if (tm.mValues == null)
            {
                if (needNew)
                {
                    item.mTraitManager.SetSimDescription(item);
                    item.mTraitManager.mValues = new Dictionary<ulong, Trait>();
                }
                else
                    return;
            }
            
            if (tm.mValues.Count == 0)
            {
                try
                {
                    Genetics.AssignRandomTraits(item);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
            }
        }

        public static
            SimDescription AddNiecSimDescriptions(SimDescription simDesc) 
        {
            if (simDesc != null)
            {
                var listsimdesc = ListCollon.NiecSimDescriptions;
                if (listsimdesc != null && !listsimdesc.Contains(simDesc))
                    listsimdesc.Add(simDesc);
            }
            return simDesc;
        }

        public static 
            SimDescription CreateRandomSimDescription
            (
                CASAgeGenderFlags age = CASAgeGenderFlags.YoungAdult, 
                CASAgeGenderFlags gender = CASAgeGenderFlags.Male, 
                WorldName worldName = WorldName.SunsetValley
            )
        {
            float f = 0;
            var simDesc = MakeSim
            (null, age, gender, Genetics.RandomSkin(false, worldName, ref f), f, Genetics.Black1, worldName, uint.MaxValue, false);

            if (simDesc != null && 
                ListCollon.NiecSimDescriptions != null && 
                !AssemblyCheckByNiec.IsInstalled("OpenDGS") && 
                !ListCollon.NiecSimDescriptions.Contains(simDesc)
            ) ListCollon.NiecSimDescriptions.Add(simDesc);

            simDesc.mHomeWorld = GameUtils.GetCurrentWorld();

            Genetics.AssignRandomTraits(simDesc);

            simDesc.FirstName = SimUtils.GetRandomGivenName(false, WorldName.France);
            simDesc.LastName = SimUtils.GetRandomFamilyName(WorldName.Egypt);

            return simDesc;
        }

        public static 
            void FakeHousehold(SimDescription simDescSim, SimDescription simDescActiveActor)
        {
            var householdSim = simDescSim.Household;
            var householdActiveActor = simDescActiveActor.Household;

            RemoveNullForHouseholdMembers(householdSim);
            RemoveNullForHouseholdMembers(householdActiveActor);

            Household.Members mem = null;

            if (householdSim != null)
            {
                mem = householdSim.mMembers;
                if (mem != null)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (mem.mAllSimDescriptions != null)
                            mem.mAllSimDescriptions.Remove(simDescSim);
                        if (mem.mPetSimDescriptions != null)
                            mem.mPetSimDescriptions.Remove(simDescSim);

                        if (mem.mSimDescriptions != null)
                            mem.mSimDescriptions.Remove(simDescSim);
                    }

                    if (mem.mAllSimDescriptions != null)
                        mem.mAllSimDescriptions.Add(simDescActiveActor);
                    if (mem.mPetSimDescriptions != null && simDescActiveActor.IsPet)
                        mem.mPetSimDescriptions.Add(simDescActiveActor);

                    if (mem.mSimDescriptions != null && !simDescActiveActor.IsPet)
                        mem.mSimDescriptions.Add(simDescActiveActor);
                }
            }

            if (householdActiveActor != null)
            {
                mem = householdActiveActor.mMembers;
                if (mem != null)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (mem.mAllSimDescriptions != null)
                            mem.mAllSimDescriptions.Remove(simDescActiveActor);
                        if (mem.mPetSimDescriptions != null)
                            mem.mPetSimDescriptions.Remove(simDescActiveActor);

                        if (mem.mSimDescriptions != null)
                            mem.mSimDescriptions.Remove(simDescActiveActor);
                    }

                    if (mem.mAllSimDescriptions != null)
                        mem.mAllSimDescriptions.Add(simDescSim);
                    if (mem.mPetSimDescriptions != null && simDescSim.IsPet)
                        mem.mPetSimDescriptions.Add(simDescSim);

                    if (mem.mSimDescriptions != null && !simDescSim.IsPet)
                        mem.mSimDescriptions.Add(simDescSim);
                }
            }

            simDescSim.mHousehold = householdActiveActor;
            simDescActiveActor.mHousehold = householdSim;
        }

        public static bool DTESTMOK()
        {
            return true;
        }

        public static bool DTESTM()
        {
            return false;
        }

        public static void Household_Remove(SimDescription simd, bool bKeepHousehold)
        {
            if (simd == null) return;
            try
            {
                List<Household> outHouseholdlist;
                if (Should_SimNoHousehold_HouseholdFound(simd, true, out outHouseholdlist))
                {
                    foreach (var itemHousehold in outHouseholdlist.ToArray())
                    {
                        if (itemHousehold == null) continue;
                        Household.Members mem = itemHousehold.mMembers;
                        if (mem == null)
                            continue;
                        for (int i = 0; i < 100; i++)
                        {
                            if (mem.mAllSimDescriptions != null)
                                mem.mAllSimDescriptions.Remove(simd);
                            if (mem.mPetSimDescriptions != null)
                                mem.mPetSimDescriptions.Remove(simd);
                            if (mem.mSimDescriptions != null)
                                mem.mSimDescriptions.Remove(simd);
                        }
                        simd.mHousehold = null;
                        if (!bKeepHousehold && ((mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0) && !IsSpecialHousehold(itemHousehold)))
                        {
                            itemHousehold.Destroy();
                        }
                    }
                    simd.mHousehold = null;
                    outHouseholdlist.Clear();
                }
                else simd.mHousehold = null;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }

        }

        public static
            InteractionInstance Interaction_CreateKillSim(Sim Actor, SimDescription.DeathType SimDeathType)
        {
            if (Actor == null || !GameObjectIsValid(Actor.ObjectId.mValue)) 
                return null;

            bool isOpenDGS = AssemblyCheckByNiec.IsInstalled("OpenDGS");
            if (Urnstone.KillSim.Singleton == null)
            {
                if (isOpenDGS)
                    Urnstone.KillSim.Singleton = new Urnstone.KillSim.Definition();
                else {
                    Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.ReInit();
                }
            }

            if (!isOpenDGS && !(Urnstone.KillSim.Singleton is Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.Definition))
            {
                Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.ReInit();
            }

            var killSimSingleton = Urnstone.KillSim.Singleton;
            Assert(killSimSingleton != null, "Urnstone.KillSim.Singleton == null");
            if (killSimSingleton == null) 
                return null;

            InteractionInstance killSimCore = killSimSingleton.CreateInstance(Actor, Actor, KillSimNiecX.DGSAndNonDGSPriority(), false, Actor.IsSelectable);
            //Assert(killSim != null, "Failed to Create Urnstone.KillSim!");
            Assert(killSimCore != null, "Failed to killSimCore CreateInstance!");

            if (killSimCore == null) 
                return null;

            Urnstone.KillSim killSim = killSimCore as Urnstone.KillSim;

            if (killSim == null)
            {
                Assert (
                    false,
                    "Failed to killSimCore as Urnstone.KillSim!\n" +
                    "Urnstone.KillSim.Singleton: " + killSimSingleton.GetType().AssemblyQualifiedName + "\n" +
                    "killSimCore Type: " + killSimCore.GetType().AssemblyQualifiedName
                );
                return null;
            }

            killSim.simDeathType = SimDeathType;
            killSim.PlayDeathAnimation = true;
            return killSim;
        }




        public static List<SimDescription> UpdateNiecSimDescriptions(bool force = false, bool sleep = true, bool createList = false)
        {
            if (ListCollon.NiecSimDescriptions == null) {
                if (createList)
                {
                    force = true;
                    ListCollon.NiecSimDescriptions = new List<SimDescription>(2000);
                }
                else
                    return null; 
            }
            if (Instantiator.RootIsOpenDGSInstalled && !force) return ListCollon.NiecSimDescriptions;
            int iSleep = 0;
            foreach (var item in NFinalizeDeath.TattoaX())
            {
                global::NiecMod.Helpers.Create.AddNiecSimDescription(item);
                if (sleep)
                {
                    iSleep++;
                    if (iSleep > 120 && Simulator.CheckYieldingContext(false))
                    {
                        iSleep = 0;
                        Simulator.Sleep(0);
                    }
                }
            } 
            return ListCollon.NiecSimDescriptions;
        }

        public static bool Household_Add(Household targetHousehold, SimDescription simDesc, bool bKeepHousehold) {

            if (simDesc == null || targetHousehold == null || targetHousehold.mMembers == null) 
                return false;

            Household simDescHousehold = simDesc.Household;
            if (simDescHousehold != null)
            {
                Household.Members mem = simDescHousehold.mMembers;
                if (mem != null) {

                    for (int i = 0; i < 10; i++)
                    {
                        if (mem.mAllSimDescriptions != null)
                            mem.mAllSimDescriptions.Remove(simDesc);
                        if (mem.mPetSimDescriptions != null)
                            mem.mPetSimDescriptions.Remove(simDesc);
                        if (mem.mSimDescriptions != null)
                            mem.mSimDescriptions.Remove(simDesc);
                        
                        simDesc.mHousehold = null;
                    }

                    if (!bKeepHousehold && (mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0))
                        NFinalizeDeath.HouseholdCleanse(simDescHousehold, false, true);
                }
                
            }

            Household_Remove(simDesc, bKeepHousehold);

            try
            {
                targetHousehold.Add(simDesc);
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            {
                Household.Members targetMembers = targetHousehold.mMembers;
                if (targetMembers != null)
                {
                    Household_Remove(simDesc, bKeepHousehold);

                    if (!targetMembers.mAllSimDescriptions.Contains(simDesc))
                    {
                        targetMembers.mAllSimDescriptions.Add(simDesc);

                        if (simDesc.IsPet)
                            targetMembers.mPetSimDescriptions.Add(simDesc);
                        else
                            targetMembers.mSimDescriptions.Add(simDesc);
                    }
                }
                else return simDesc.Household == targetHousehold;

                simDesc.mHousehold = targetHousehold;
                return true;
            }
            return simDesc.Household == targetHousehold;
        }


        public static void PD(string msg, int isleep) {
            if (ProgressDialog.sDialog == null)
                ProgressDialog.Show(msg);
            NiecTask.Perform(delegate {
                for (int i = 0; i < isleep; i++)
                {
                    Simulator.Sleep(0);
                }
                if (ProgressDialog.sDialog != null)
                    ProgressDialog.Close();
            });
            Simulator.Sleep(0);
        }




        public static void AllEmptyFixUp(SimDescription[] simlist)
        {
            if (simlist == null)
                UpdateNiecSimDescriptions();
            foreach (SimDescription item in simlist ?? ListCollon.NiecSimDescriptions.ToArray())
            {
                if (item == null) 
                    continue;
                if (!item.IsValidDescription) 
                    continue;

                if (item.mFirstName == null)
                    item.mFirstName = "";

                if (item.mLastName == null)
                    item.mLastName = "";

                if (string.IsNullOrEmpty(item.mFirstName.Trim()) && string.IsNullOrEmpty(item.mLastName.Trim()))
                {
                    item.FirstName = SimUtils.GetRandomGivenName(item.IsMale, WorldName.France);
                    item.mLastName = SimUtils.GetRandomFamilyName(WorldName.Egypt);
                }

                TraitManagerFixUp(item, false);
                
            }
            foreach (var item in SC_GetObjects<Household>())
            {
                if (item == null) continue;

                if (item.mName == null)
                    item.Name = "";


                

                Household.Members mem = item.mMembers;
                if (mem == null || mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                    continue;

                //if (item.IsSpecialHousehold) continue;

                if (!string.IsNullOrEmpty(item.mName.Trim())) continue;


                foreach (var itemDesc in mem.mAllSimDescriptions)
                {
                    if (itemDesc == null || itemDesc.LastName == null) 
                        continue;

                    item.Name = itemDesc.mLastName ?? "";
                    break;
                }
                if (string.IsNullOrEmpty(item.mName.Trim()))
                    item.Name = SimUtils.GetRandomFamilyName(WorldName.Egypt);
            }
        }

        public static 
            bool GraveTwoToGraveOne
            (SimDescription[] simDescList, Urnstone[] graveList, bool needDestroy, out Dictionary<SimDescription, List<Urnstone>> out_UrnstoneList) {

            out_UrnstoneList = null;

            if (simDescList == null) 
                return false;

            Dictionary<SimDescription, List<Urnstone>> urnlist = new Dictionary<SimDescription, List<Urnstone>>();
            foreach (var item in simDescList)
            {
                //Simulator.Sleep(0);

                if (item == null) 
                    continue;
                if (urnlist.ContainsKey(item)) 
                    continue;

                List<Urnstone> simitemlist = new List<Urnstone>();
                foreach (var grav in (graveList ?? SC_GetObjects<Urnstone>()))
                {
                    //Simulator.Sleep(0);
                    if (grav == null) 
                        continue;
                    if (grav.DeadSimsDescription == item) {// || grav.DeadSimsDescription == ListCollon.NullSimSimDescription) {
                        
                        simitemlist.Add(grav);
                    }
                }
                urnlist.Add(item, simitemlist);
            }

            if (ListCollon.NullSimSimDescription != null && !urnlist.ContainsKey(ListCollon.NullSimSimDescription)) {
                List<Urnstone> simitemlist = new List<Urnstone>();
                foreach (var grav in (graveList ?? SC_GetObjects<Urnstone>()))
                {
                    //Simulator.Sleep(0);
                    if (grav == null)
                        continue;
                    if (grav.DeadSimsDescription == ListCollon.NullSimSimDescription)
                    {
                        simitemlist.Add(grav);
                    }
                }
                urnlist.Add(ListCollon.NullSimSimDescription, simitemlist);
            }


            

            if (needDestroy && urnlist.Count > 0)
            {
                bool One;
                foreach (var urnlist_Value in urnlist.Values)
                {
                    //Simulator.Sleep(0);
                    if (urnlist_Value == null)
                        continue;

                    One = false;
                    if (urnlist_Value.Count == 1)
                    {
                        urnlist_Value.Clear();
                        continue;
                    }

                    foreach (var grave in urnlist_Value)
                    {
                        //Simulator.Sleep(0);

                        if (grave == null)
                            continue;

                        if (!One)
                        {
                            One = true;
                            continue;
                        }
                        grave.DeadSimsDescription = null;
                        ForceDestroyObject(grave);
                    }
                    urnlist_Value.Clear();
                }
                urnlist.Clear();
                urnlist = null;
                return true;
            }
            else
            {
                out_UrnstoneList = urnlist;
                return urnlist.Count > 0;
            }
        }

        public static void CheatWindowPro_OnButtonDown(WindowBase sender, UIButtonClickEventArgs eventArgs) { NiecTask.Perform(delegate { CheatWindowPro_internal(); }); }

        public static void CheatWindowPro()
        {
            if (Simulator.CheckYieldingContext(false))
            {
                CheatWindowPro_internal();
            }
        }
        public static bool Random_CoinFlip() { return Random_GetFloat(0, 100, null) < 50; }
        public static bool Random_Chance(float c) { return Random_GetFloat(0, 100, null) < c; }
        public static bool Random_Chance01(float c) { return Random_GetFloat(0, 1, null) < c; }
        internal static string CheatWindowPro_internal_data = null;
        public static string CheatWindowPro_internal()
        {
            if (!CommandSystem.Exists()) 
                return null;
            reset:
            Simulator.CheckYieldingContext(true);
            //if (!IsOpenDGSInstalled && (!ModalDialog.EnableModalDialogs || LoadingScreenController.IsLayoutLoaded()))
            //    ModalDialog.EnableModalDialogs = true;
            //if (!ModalDialog.EnableModalDialogs) 
            //    return null; 
            string commandStr = StringInputDialog.Show (
                "Command Console",
                "What you do want?\nTry: moveobjects on",
                CheatWindowPro_internal_data ?? CommandConsoleDialog.smLastCommandString ?? "",
                -1, 
                ThumbnailKey.kInvalidThumbnailKey, 
                new Vector2(-1f, -1f), 
                StringInputDialog.Validation.None, 
                false,
                ModalDialog.PauseMode.PauseSimulator,
                !IsOpenDGSInstalled, 
                false
            );

            if (IsNullOrEmpty(commandStr))
                return commandStr;
            if (commandStr == "help") {
                new NCopyableTextDialog(CommandSystem.GetCommandList() ?? "GetCommandList == NULL").SafeShow("Command List");
                Simulator.Sleep(0);
                goto reset;
            }


            string[] cheatKey = commandStr.Split(' ');
            if (cheatKey != null && cheatKey.Length > 0)
            {
                string commandtext = cheatKey[0].ToLower();
                if (commandtext == "help" && cheatKey.Length > 1)
                {
                    string msgHelp = CommandSystem.GetCommandHelp(cheatKey[1] ?? "niecmod");
                    if (!IsNullOrEmpty(msgHelp))
                    {
                        new NCopyableTextDialog(msgHelp).SafeShow(cheatKey[1] + " Help");
                        return commandStr;
                    }
                }
                if (!IsNullOrEmpty(CommandSystem.GetCommandHelp(commandtext)))
                {
                    CommandSystem.ExecuteCommandString(commandStr);
                    CheatWindowPro_internal_data = commandStr;
                    CheckMorun();
                }
            }
            return commandStr;
        }



        public static void RemoveNullForHouseholdMembers(Household item)
        {
            if (item == null)
                return;
            Sims3.Gameplay.CAS.Household.Members mem = item.mMembers;

            int checkloop;// = 10000;

            if (mem == null)
                item.mMembers = new Household.Members();

            else if (mem != null)
            {
                checkloop = 10000;
                if (mem.mAllSimDescriptions == null)
                    mem.mAllSimDescriptions = new List<SimDescription>();
                else
                {
                    while (mem.mAllSimDescriptions.Remove(null))
                    {
                        checkloop--;
                        if (checkloop < 0)
                        {
                            break;
                        }
                    }
                }

                checkloop = 10000;

                if (mem.mPetSimDescriptions == null)
                    mem.mPetSimDescriptions = new List<SimDescription>();
                else
                {
                    while (mem.mPetSimDescriptions.Remove(null))
                    {
                        checkloop--;
                        if (checkloop < 0)
                        {
                            break;
                        }
                    }
                }

                checkloop = 10000;

                if (mem.mSimDescriptions == null)
                    mem.mSimDescriptions = new List<SimDescription>();
                else
                {
                    while (mem.mSimDescriptions.Remove(null))
                    {
                        checkloop--;
                        if (checkloop < 0)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public static void FixAllHouseholdMembers() {

            foreach (var item in SC_GetObjects<Household>()) 
                // Fix Game Crash from LoadingSaveFile
                // #0: 0x00003 ldfld.o    in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.Household:get_AllSimDescriptions () ()
            {
                RemoveNullForHouseholdMembers(item);
            } 
            if (ListCollon.NiecSimDescriptions != null)
            {
                UpdateNiecSimDescriptions();
                foreach (SimDescription item in ListCollon.NiecSimDescriptions.ToArray())
                {
                    if (item == null)
                        continue;

                    List<Household> outHouseholdlist;

                    if (Should_SimNoHousehold_HouseholdFound(item, false, out outHouseholdlist))
                    {
                        int c = outHouseholdlist.Count;
                        foreach (var itemHousehold in outHouseholdlist)
                        {
                            if (itemHousehold == null) continue;
                            Household.Members mem = itemHousehold.mMembers;
                            if (mem == null)
                                continue;
                            for (int i = 0; i < 100; i++)
                            {
                                mem.mAllSimDescriptions.Remove(item);
                                mem.mPetSimDescriptions.Remove(item);
                                mem.mSimDescriptions.Remove(item);
                                item.mHousehold = null;
                            }
                            c--;
                            if (c == 1)
                            {
                                try
                                {
                                    item.Fixup();
                                    if (!item.IsValidDescription)
                                    {
                                        if (item.Household == null || item.Household != ActiveHousehold)
                                            SimDescCleanse(item, true, false);
                                        outHouseholdlist.Clear();
                                        break;
                                    }
                                }
                                catch (StackOverflowException) { throw; }
                                catch (ResetException) { throw; }
                                catch (Exception)
                                {
                                    if (item.Household == null || item.Household != ActiveHousehold)
                                        SimDescCleanse(item, true, false);
                                    outHouseholdlist.Clear();
                                    break; 
                                }

                                mem.mAllSimDescriptions.Add(item);
                                mem.mPetSimDescriptions.Add(item);
                                mem.mSimDescriptions.Add(item);
                                item.mHousehold = itemHousehold;
                                outHouseholdlist.Clear();
                                break;
                            }
                            if (mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                            {
                                HouseholdCleanse(itemHousehold, false, true);
                            }
                        }
                    }
                }
            }
        }







        public static bool Should_SimNoHousehold_HouseholdFound(SimDescription simDescDontHaveHousehold, bool force, out List<Household> householdFound) {
            householdFound = null;
            if (simDescDontHaveHousehold != null && (force || simDescDontHaveHousehold.mHousehold == null))
            {
                foreach (var item in SC_GetObjects<Household>())
                {
                    if (item == null) 
                        continue;

                    Household.Members mem = item.mMembers;
                    if (mem == null) 
                        continue;

                    List<SimDescription> householdMembers = mem.mAllSimDescriptions;
                    if (householdMembers == null) 
                        continue;

                    if (householdFound == null)
                        householdFound = new List<Household>();

                    if (householdMembers.Contains(simDescDontHaveHousehold))
                        householdFound.Add(item);

                }
                return householdFound != null;
            }
            return false;
        }

        public static bool tadasdreter456rf = false;
        public static void LoopSpeedSPSlow(uint ia) {
            if (!AssemblyCheckByNiec.IsInstalled("NRaasStoryProgression")) {Instantiator.LoopSpeedSPSlowdone = false; return; }
            NiecTask.Perform(ScriptExecuteType.Threaded,delegate()
            {
                if (tadasdreter456rf || !NiecHelperSituation.isdgmods && NiecHelperSituation.__acorewIsnstalled__)
                {
                    tadasdreter456rf = true;
                    NiecTask.SimulateAgainRuntimeFound();
                    NiecTask.SetNeedNoErrorRuntime(true);
                }
                while (true) {
                    Simulator.Sleep(0);
                    try
                    {
                        NRAAS_SP(true);

                        SleepForNSimMinutes(3020);

                        NRAAS_SP(false);

                        SleepForNSimMinutes(220);
                        SleepTask(ia);
                    }
                    catch (ResetException) { throw; }
                    catch (Exception)      { Simulator.Sleep(150); }
                }
            });
        }


        public static SimDescription ActiveActor_SimDescription
        {
            get
            {
                PlumbBob plumbBobSingleton = PlumbBob.sSingleton;
                if (plumbBobSingleton == null) 
                    return null;

                Sim activeActor = plumbBobSingleton.mSelectedActor;
                if (activeActor == null) 
                    return null;

                return activeActor.mSimDescription;
            }
            
        }

        public static SimDescription SelectedActor_SimDescription
        {
            get
            {
                Sim activeActor = PlumbBob.SelectedActor;
                if (activeActor == null)
                    return null;

                return activeActor.mSimDescription;
            }

        }

        public static bool ActorIsValidExNull(Sim Actor)
        {
            if (Actor != null)
            {
                SimDescription actorde = Actor.SimDescription;
                if (actorde == null || actorde.GetCurrentOutfits() == null || !Sims3.SimIFace.Objects.IsValid(Actor.ObjectId))
                    return false;

            }
            return true;
        }

        public static void SleepForNSimMinutes(float n)
        {
            //Simulator.CheckYieldingContext(true);
            uint tickCount = (uint)SimClock.ConvertToTicks(n, TimeUnit.Minutes);
            Simulator.Sleep(tickCount);
        }
        public static void SleepTask(uint tickLeft)
        {
            //Simulator.CheckYieldingContext(true); // Simulator.CheckYieldingContext();
            if (tickLeft == 0)
            {
                Simulator.Sleep(0);
            }
            else
            {
                uint t = tickLeft == 1 ? 1 : tickLeft - 1;
                for (uint i = 0; i < t; i++)
                {
                    Simulator.Sleep(0);
                }
                Simulator.Sleep(0);
            }
        }

        public static char DecodeLeetChar(char chLeet)
        {
            if (chLeet >= 'À' && chLeet <= 'Æ')
            {
                return 'a';
            }
            if (chLeet >= 'È' && chLeet <= 'Ë')
            {
                return 'e';
            }
            if (chLeet >= 'Ì' && chLeet <= 'Ï')
            {
                return 'i';
            }
            if (chLeet >= 'Ò' && chLeet <= 'Ö')
            {
                return 'o';
            }
            if (chLeet >= 'Ù' && chLeet <= 'Ü')
            {
                return 'u';
            }
            if (chLeet >= 'à' && chLeet <= 'æ')
            {
                return 'a';
            }
            if (chLeet >= 'è' && chLeet <= 'ë')
            {
                return 'e';
            }
            if (chLeet >= 'ì' && chLeet <= 'ï')
            {
                return 'i';
            }
            if (chLeet >= 'ò' && chLeet <= 'ö')
            {
                return 'o';
            }
            if (chLeet >= 'ù' && chLeet <= 'ü')
            {
                return 'u';
            }
            switch (chLeet)
            {
                case '4':
                case '?':
                case '@':
                case '^':
                case 'ª':
                    return 'a';
                case '8':
                case 'ß':
                    return 'b';
                case '(':
                case '<':
                case '[':
                case '{':
                case '¢':
                case '©':
                case 'Ç':
                case 'ç':
                    return 'c';
                case 'Ð':
                case 'ð':
                    return 'd';
                case '&':
                case '3':
                case '£':
                case '€':
                    return 'e';
                case '6':
                case '9':
                    return 'g';
                case '#':
                    return 'h';
                case '!':
                case '1':
                case '|':
                case '¡':
                case '¦':
                    return 'i';
                case 'Ñ':
                case 'ñ':
                    return 'n';
                case '*':
                case '0':
                case '¤':
                case '°':
                case 'Ø':
                case 'ø':
                    return 'o';
                case '®':
                    return 'r';
                case '$':
                case '5':
                case '§':
                    return 's';
                case '+':
                case '7':
                    return 't';
                case 'µ':
                    return 'u';
                case '%':
                case '×':
                    return 'x';
                case '¥':
                case 'Ý':
                case 'ý':
                case 'ÿ':
                    return 'y';
                case '2':
                    return 'z';
                default:
                    return chLeet;
            }
        }

        private static int g_iWeakSeed = 0;
        public static Random NewWeakRandom()
        {
            long nowTime = DateTime.UtcNow.ToBinary();
            int seed = (int)((nowTime >> 32) ^ nowTime);
            g_iWeakSeed += 2024326327;
            seed ^= g_iWeakSeed;
            if (seed == int.MinValue)
            {
                seed = int.MaxValue;
            }
            return new Random(seed);
        }


        public static Sim ActiveActor
        {
            get
            {
               PlumbBob w=PlumbBob.sSingleton;
               if (w == null) return null;
               return NiecRunCommand.looppaa_SIM ?? w.mSelectedActor;
            }
            set {
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    try
                    {
                        Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommandsNoStatic, Sims3GameplaySystems");
                        if (type != null)
                        {
                            FieldInfo mField = type.GetField("kFakeActiveActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (mField != null)
                            {
                                mField.SetValue(null, false);
                                mField = type.GetField("kDGSPlayerTwo", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (mField != null)
                                {
                                    mField.SetValue(null, false);
                                }
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }
                }
                if (IsOpenDGSInstalled) { 
                    if (!ActorIsValidExNull(value))
                        return;
                    if (value != null)
                    {
                        if (NiecRunCommand.looppaa_SIM != null)
                            NiecRunCommand.looppaa_SIM = value;
                        var household = value.Household ?? Household_Create(value.SimDescription);
                        Create.AutoMoveInLotFromHousehold(household);
                    }
                }
                // // Keep DreamsAndPromisesManager
                //if (!IsOpenDGSInstalled && value != null && PlumbBob.sCurrentNonNullHousehold != value.Household)
                //{
                //    var SActorDescription = SelectedActor_SimDescription;
                //    var ValueDesc = value.SimDescription;
                //    if (SActorDescription != null && ValueDesc != null)
                //        FakeHousehold(ValueDesc, SActorDescription);
                //    PlumbBob.sCurrentNonNullHousehold = value.Household;
                //    if (!PlumbBob.SelectActor(value)) {
                //        PlumbBob.ForceSelectActor(value);
                //    } 
                //    if (SActorDescription != null && ValueDesc != null)
                //        FakeHousehold(ValueDesc, SActorDescription);
                //    return;
                //}
                if (AssemblyCheckByNiec.IsInstalled("AweCore") && !IsOpenDGSInstalled)
                {
                    if (PlumbBob.sSingleton == null)
                        return;

                    PlumbBob.sCurrentNonNullHousehold = null;
                    PlumbBob.sSingleton.mSelectedActor = null;

                    PlumbBob.ForceSelectActor(null); 
                }
                PlumbBob.ForceSelectActor(value); 
                
            }
        }





        















        public static void ForceCancelAllInteractionsPro(Sim Target)
        {
            checked
            {
                for (int i = Target.InteractionQueue.mInteractionList.Count - 1; i >= 0; i--)
                {
                    /*
                    //InteractionInstance interactionInstance = Target.InteractionQueue.mInteractionList[i];
                    //if (!(mInteractionList[i] is ExtKillSimNiec))
                    if (!CheckKillSimInteractionPro(Target, Target.InteractionQueue.mInteractionList[i]))
                    {
                        try
                        {
                            //mActor.AddExitReason(ExitReason.SuspensionRequested);
                            //CancelNthInteraction(i, false, ExitReason.Default);
                            if (!Target.InteractionQueue.IsRunning(Target.InteractionQueue.mInteractionList[i], true))
                            {
                                Target.InteractionQueue.mInteractionList[i].OnRemovedFromQueue(i == 0);
                                Target.InteractionQueue.mInteractionList.RemoveAt(i);
                            }

                            //else
                            //{
                            //     mActor.AddExitReason(ExitReason.Default);
                            //}
                        }
                        catch
                        { 

                    }
                     */
                    try
                    {
                        if (!CheckKillSimInteractionPro(Target, Target.InteractionQueue.mInteractionList[i]))
                        {
                            if (Target.InteractionQueue.IsRunning(Target.InteractionQueue.mInteractionList[i], true) && (Target.InteractionQueue.mIsHeadInteractionLocked || Target.InteractionQueue.mCurrentTransitionInteraction != null))
                            {
                                Target.AddExitReason(ExitReason.SuspensionRequested);
                            }
                            else
                            {
                                RemoveInteraction( Target,  i, false, true      );
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    {
                        
                        
                    }
                    
                }
                try
                {
                    if (!Target.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton) && !Target.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                    {
                        Target.AddExitReason(ExitReason.Canceled);
                        Target.AddExitReason(ExitReason.StageComplete);
                        Target.AddExitReason(ExitReason.Default);
                        Target.AddExitReason(ExitReason.BuffFailureState);
                        Target.AddExitReason(ExitReason.HigherPriorityNext);
                        Target.AddExitReason(ExitReason.CanceledByScript);
                    }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
            }
        }

        

        public static void ForceCancelAllInteractionsProPartA(Sim Target)
        {
            checked
            {
                for (int i = Target.InteractionQueue.mInteractionList.Count - 1; i >= 0; i--)
                {
                    /*
                    //InteractionInstance interactionInstance = Target.InteractionQueue.mInteractionList[i];
                    //if (!(mInteractionList[i] is ExtKillSimNiec))
                    if (!CheckKillSimInteractionPro(Target, Target.InteractionQueue.mInteractionList[i]))
                    {
                        try
                        {
                            //mActor.AddExitReason(ExitReason.SuspensionRequested);
                            //CancelNthInteraction(i, false, ExitReason.Default);
                            if (!Target.InteractionQueue.IsRunning(Target.InteractionQueue.mInteractionList[i], true))
                            {
                                Target.InteractionQueue.mInteractionList[i].OnRemovedFromQueue(i == 0);
                                Target.InteractionQueue.mInteractionList.RemoveAt(i);
                            }

                            //else
                            //{
                            //     mActor.AddExitReason(ExitReason.Default);
                            //}
                        }
                        catch
                        { 

                    }
                     */
                    try
                    {
                        if (!CheckKillSimInteractionPro(Target, Target.InteractionQueue.mInteractionList[i]))
                        {
                            if (Target.InteractionQueue.IsRunning(Target.InteractionQueue.mInteractionList[i], true) && (Target.InteractionQueue.mIsHeadInteractionLocked || Target.InteractionQueue.mCurrentTransitionInteraction != null))
                            {
                                Target.AddExitReason(ExitReason.SuspensionRequested);
                            }
                            else
                            {
                                RemoveInteraction(Target, i, false, true);
                            }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    {


                    }

                }
            }
        }


        public static void ForceCancelAllInteractionsProOld(Sim Target)
        {
            checked
            {
                for (int i = Target.InteractionQueue.mInteractionList.Count - 1; i >= 0; i--)
                {
                    InteractionInstance interactionInstance = Target.InteractionQueue.mInteractionList[i];
                    //if (!(mInteractionList[i] is ExtKillSimNiec))
                    if (!CheckKillSimInteractionPro(Target, interactionInstance))
                    {
                        try
                        {
                            //mActor.AddExitReason(ExitReason.SuspensionRequested);
                            //CancelNthInteraction(i, false, ExitReason.Default);
                            if (!Target.InteractionQueue.IsRunning(interactionInstance, true))
                            {
                                interactionInstance.OnRemovedFromQueue(i == 0);
                                Target.InteractionQueue.mInteractionList.RemoveAt(i);
                            }

                            //else
                            //{
                            //     mActor.AddExitReason(ExitReason.Default);
                            //}
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        { }

                    }
                }
                try
                {
                    if (!Target.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton) && !Target.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                    {
                        Target.AddExitReason(ExitReason.Canceled);
                        Target.AddExitReason(ExitReason.StageComplete);
                        Target.AddExitReason(ExitReason.Default);
                        Target.AddExitReason(ExitReason.BuffFailureState);
                        Target.AddExitReason(ExitReason.HigherPriorityNext);
                        Target.AddExitReason(ExitReason.CanceledByScript);
                    }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
            }
        }

        public static bool Household_IsNoActiveOrSpecialOrHomeless(Household test) // customTest
        {
            if (test == null)
                return false;
            if (test.IsSpecialHousehold)
                return false;
            if (test.LotHome == null)
                return false;
            if (IsOpenDGSInstalled && (test == ActiveHousehold))
                return false;
            return true;
        }

        public static bool mResetError = false;

        public static void ClearMiniRelationships (MiniSimDescription ths) {
            if (ths == null || ths.MiniRelationships == null) return;
            ths.mMiniRelationships.Clear();
        }

        public static void ResetError()
        {
            while (mResetError)
            {
                //try
                //{
                    //Simulator.YieldingDisabled = false;
                    //Simulator.Sleep(0);
                   // Nra.SpeedTrap.ForceSleep();
                //}
                //catch
                //{}
                Simulator.Sleep(0);
            }
        }

        public static bool SimIsNiecHelperSituation(Sim Actor)
        {
            return Actor != null && SafeGetSituationOfType<NiecHelperSituation>(Actor) != null;
        }
        public static bool SimIsNiecHelperSituation02(Sim Actor)
        {
            if (Actor == null) return false;
            /*
            SimDescription simd = Actor.SimDescription;

            if (simd == null)
                return false;





            Autonomy automoy = Actor.Autonomy;
            if (automoy == null)
                return false;

            SituationComponent sSituationComponent = automoy.SituationComponent;
            if (sSituationComponent == null)
                return false;

            List<Situation> listSituations = sSituationComponent.Situations;
            if (listSituations == null)
                return false;
            */
            try
            {
                NiecHelperSituation niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();
                if (niecHelperSituation != null)
                {
                    return true;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch { }

            return false;
        }

        public static bool SimIsValid(Sim item)
        {
            if (item == null) 
                return false;
            if (Sim_IsBad(item)) 
                return false;

            var simd = item.SimDescription;
            if (simd == null || !simd.IsValidDescription)
                return false;

            if (simd.CreatedSim != item)
                return false;

            var household = simd.Household;
            if (household == null || !Household_IsSafeHousehold(household))
                return false;
            return true;
        }

        public static bool SimIsValidFromLoadingSaveFile(Sim item)
        {
            if (item == null)
                return false;
            if (Sim_IsBad(item))
                return false;

            var simd = item.SimDescription;
            if (simd == null)
                return false;

            if (simd.CreatedSim != item)
                return false;

            var household = simd.Household;
            if (household == null || !Household_IsSafeHouseholdFromLoadingSaveFile(household))
                return false;
            return true;
        }

        public delegate void Function();

        public delegate bool FunctionX();

        public static void CancelAllInteractions(Sim Target)
        {
            checked
            {
                for (int i = Target.InteractionQueue.mInteractionList.Count - 1; i >= 0; i--)
                {
                    if (!(Target.InteractionQueue.mInteractionList[i] is ExtKillSimNiec))
                    {
                        try
                        {
                            Target.AddExitReason(ExitReason.SuspensionRequested);
                            Target.InteractionQueue.CancelNthInteraction(i, false, ExitReason.Default);
                        }
                        catch
                        { }

                    }
                }
                try
                {
                    if (!Target.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton))
                    {
                        Target.AddExitReason(ExitReason.Canceled);
                        Target.AddExitReason(ExitReason.StageComplete);
                        Target.AddExitReason(ExitReason.Default);
                        Target.AddExitReason(ExitReason.BuffFailureState);
                        Target.AddExitReason(ExitReason.HigherPriorityNext);
                        Target.AddExitReason(ExitReason.CanceledByScript);
                    }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
            }
        }
        public static bool MyNameDGSOwner(SimDescription item)
        {
            if (item == null) return false;
            var fm = item.FirstName;
            var lm = item.LastName;
            if (fm == "Fullham" && lm == "Alfayet")
            {
                return true;
            }
            if (fm == "You" && lm == "Boy")
            {
                return true;
            }

            if (fm == "You" && lm == "Girl")
            {
                return true;
            }

            if (fm == "Ktiata" && lm == "Tuaiyhn")
            {
                return true;
            }

            if (fm == "Bajyiae" && lm == "Autiyu")
            {
                return true;
            }

            return false;
        }

        public static GameObject GetObject_internal(ObjectGuid objectID)
        {
            if (objectID.mValue != 0)
            {
                IScriptProxy proxy = Simulator.GetProxy(objectID) ?? GetProxyFromObjectIDWithoutSimIFace(objectID);
                if (proxy != null)
                {
                    return proxy.Target as GameObject;
                }
            }
            return null;
        }
        public static GameObject GetObject_internalFast(ulong objectID)
        {
            if (objectID != 0)
            {
                IScriptProxy proxy = ScriptCore.Simulator.Simulator_GetTaskImpl(objectID, false) as IScriptProxy;
                if (proxy != null)
                {
                    return proxy.Target as GameObject;
                }
            }
            return null;
        }

        public static IScriptLogic GetObject_internalFastO(ulong objectID)
        {
            if (objectID != 0)
            {
                IScriptProxy proxy = ScriptCore.Simulator.Simulator_GetTaskImpl(objectID, false) as IScriptProxy;
                if (proxy != null)
                {
                    return proxy.Target;
                }
            }
            return null;
        }
        public static GameObject GetObject_internalFast2(ulong objectID, out ScriptExecuteType eType)
        {
            eType = 0;
            if (objectID != 0)
            {
                IScriptProxy proxy = ScriptCore.Simulator.Simulator_GetTaskImpl(objectID, false) as IScriptProxy;
                if (proxy != null)
                {
                    eType = proxy.ExecuteType;
                    return proxy.Target as GameObject;
                }
            }
            return null;
        }
        public static object GetObject_internalFastTask(ulong objectID)
        {
            if (objectID != 0)
            {
                var task = ScriptCore.Simulator.Simulator_GetTaskImpl(objectID, false);
                IScriptProxy proxy = task as IScriptProxy;
                if (proxy != null)
                {
                    return proxy.Target;
                }
                return task;
            }
            return null;
        }




        

        public static T GetCurrentGameObject<T>() where T : GameObject
        {
            return GetObject_internal(new ObjectGuid(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl())) as T;
        }
        public static T GetCurrentGameObjectFast<T>() where T : GameObject
        {
            return GetObject_internalFast(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) as T;
        }
        public static T GetCurrentGameObjectFastTask<T>() where T : class
        {
            return GetObject_internalFastTask(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl()) as T;
        }


        public static bool NonOpenDGSStateMachineClient_HumanIsBaby(IHasScriptProxy actor)
        {
            if (IsOpenDGSInstalled) return false;
            Sim sim = actor as Sim;
            if (sim != null && sim.SimDescription != null && !sim.SimDescription.IsPet && sim.SimDescription.Age == CASAgeGenderFlags.Baby)
            {
                return true;
            }
            return false;
        }
        public static bool StateMachineClient_HumanIsBaby(IHasScriptProxy actor)
        {
            Sim sim = actor as Sim;
            if (sim != null && sim.SimDescription != null && !sim.SimDescription.IsPet && sim.SimDescription.Age == CASAgeGenderFlags.Baby)
            {
                return true;
            }
            return false;
        }

        public static bool StateMachineClient_SimIsPet(IHasScriptProxy actor) {
            Sim sim = actor as Sim;
            if (sim != null && sim.SimDescription != null && sim.IsPet)
            {
                return true;
            }
            return false;
        }

        public static ulong GetAgeHashSMC(SimDescription simd)
        {
            switch (simd.Age)
            {
            case CASAgeGenderFlags.Baby:
                return (ulong) Age.baby;
                
            case CASAgeGenderFlags.Toddler:
                return (ulong) Age.todler;
               
            case CASAgeGenderFlags.Child:
                return (ulong) Age.child;

            case CASAgeGenderFlags.Teen:
                return (ulong) Age.teen;

            case CASAgeGenderFlags.YoungAdult:
                return (ulong) Age.young_adult;

            case CASAgeGenderFlags.Adult:
                return (ulong) Age.adult;

            case CASAgeGenderFlags.Elder:
                return (ulong) Age.elder;

            default:
                return (ulong) Age.young_adult; // custom
               
            }
        }
        public static bool FastHasInteraction<T>(List<InteractionInstance> ilist, int maxCount)
        {
            var p = ilist._items;
            int i = 0;

            int maxl = ilist._items.Length;
            int maxs = ilist._size;

            if (maxl < 0 || maxl == 0)// || maxs > maxCount)
                return false;

            while (i < maxl && i < maxs && i < maxCount)
            {
                if (p[i] is T)
                    return true;
                i++;
            }
            return false;
        }
        public static int MyCountInteractionInstance<T>(List<InteractionInstance> ilist, int maxCount)
        {
            var p = ilist._items;
            int i = 0;
            
            int maxl = ilist._items.Length;
            int maxs = ilist._size;
            if (maxl < 0 || maxl == 0 || maxl > maxCount)
                return i;

            int foundCount = 0;
            while (i < maxl && i < maxs)
            {
                if (p[i] is T)
                    foundCount++;
                i++;
            }
            return foundCount;
        }

        public static bool RemoveDuplicateInteraction<T>(
            List<InteractionInstance> ilist,
            GameObject target,
            int foundCount,
            int maximumCount) 
            where T : InteractionInstance
        {
            var p = ilist._items;

            int maxl = ilist._items.Length;
            int maxs = ilist._size;

            //if (maxs < 0)
            if (maxs < 0 || maxs > maxl) // mscorlib bug
                ilist._size = maxs = maxl;

            if (maxl < 0 || maxl == 0)
                return false;

            int i = 0;
            int count = 0;
            InteractionInstance itemBackup = null;
            while (i < maxl)// && i < maxs)
            {
                var item = p[i] as T;
                i++;
                if (item != null)
                {
                    var inpair = item.InteractionObjectPair;
                    if (inpair == null) 
                        continue;

                    if (inpair.mTarget == target)
                    {
                        itemBackup = item;
                        count++;
                        if (count >= foundCount)
                        {
                            bool is_one_item = false;
                            //CCnlean ccl = new CCnlean();
                            for (int ic = 0; ic < maxl; ic++)
                            {
                                item = p[ic] as T;
                                if (item == null) 
                                    continue;
                                
                                inpair = item.InteractionObjectPair;
                                if (inpair == null) 
                                    continue;

                                if (inpair.mTarget == target)
                                {
                                    if (!is_one_item)
                                    {
                                        is_one_item = true;
                                        continue;
                                    }
                                    p[ic] = null;
                                }
                            }
                            while(ilist.Remove(null));
                            return true;
                        }
                    }
                }
                
                if (i >= maximumCount)
                {
                    niec_std.safeb32_list_clear(ilist, true);
                    if (itemBackup != null)
                    {
                        ilist._items[0] = itemBackup;
                        ilist._size = 1;
                    }
                    return true;
                }
                if (i >= maxs)
                    break;
            }
            return false;
        }

        // unprotected mono mscorlib 
        public static void Sim_SetSacsDefaultParameters(Sim _this,StateMachineClient smc, string actorName)
        {
            if (_this == null) throw new NullReferenceException();
            if (IsOpenDGSInstalled) { _this.SetSacsDefaultParameters(smc, actorName); return; }
            if (smc != null && _this.mSimDescription != null) // Custom 1:58 14/05/2019 
            {
                // GC bug or mono bug?
                // System.NullReferenceException: A null value was found where an object instance was required.
                // #0: 0x00018 ldfld.o    in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.OverlayComponent:InteractionPartLevelCallback (Sims3.SimIFace.StateMachineClient,Sims3.SimIFace.IEvent) (00000000 [5F088870] [3A9D43A8] )
                var ovc = _this.OverlayComponent;
                if (ovc != null)
                {
                    smc.AddPersistentSacsEventHandler(
                        SacsEventSubTypes.kSacsEventOverlayLevelEvent, 
                        delegate(StateMachineClient sender, IEvent evt) 
                        {
                            try
                            {
                                UnSafe_RemoveActorsUsingMe(_this);

                                AnimationPriority defaultPriority = sender.DefaultPriority;
                                AwarenessLevel eventID = (AwarenessLevel)evt.EventId;

                                ovc.mOverlayLevelRecords.RemoveAll
                                    (new OverlayComponent.OverlayLevelRecordRemoveHelper(defaultPriority).Predicate);

                                var item = default(OverlayComponent.OverlayLevelRecord);
                                item.mPriority = defaultPriority;
                                item.mOverlayLevel = eventID;

                                ovc.mOverlayLevelRecords.Add(item);
                                ovc.mOverlayLevelRecords.Sort();

                                var overlayLevels = ovc.mInteractionPartsUsedFlags;
                                ovc.UpdateInteractionFreeParts(OverlayComponent.GetPartsFromLevel(eventID), defaultPriority);

                                if (ovc.mInteractionPartsUsedFlags > OverlayComponent.OverlayLevels.None && 
                                    ovc.mInteractionPartsUsedFlags > overlayLevels)
                                {
                                    ovc.StopOverlaysAbovePriority(defaultPriority);
                                }
                                else if (Simulator.CheckYieldingContext(false))
                                {
                                    if (Random_GetFloat(0, 100f, null) < 1)
                                    {
                                        if (Simulator.GetProxy(_this.ObjectId) != null)
                                            NiecHelperSituationPosture.ExistsOrCreatePosture(_this, false);

                                        NiecHelperSituationPosture.r_internal(_this);
                                    }
                                }
                            }
                            catch (ResetException) { throw; }
                            catch (Exception ex)
                            {
                                if (ex is StackOverflowException)
                                    ThrowResetException(null);
                                if (Simulator.GetProxy(_this.ObjectId) != null)
                                    NiecHelperSituationPosture.ExistsOrCreatePosture(_this, false);

                                if (ex is ArgumentException) { ex.stack_trace = null; ex.trace_ips = null; ex.message = null; }

                                if (Simulator.CheckYieldingContext(false) && Random_GetFloat(0, 100f, null) < 1)
                                {
                                    NiecHelperSituationPosture.r_internal(_this);
                                }

                                if (Simulator.CurrentTask == _this.ObjectId)
                                    throw;
                            }
                        }
                    );
                    smc.AddPersistentSacsEventHandler(
                        SacsEventSubTypes.kSacsEventAnimationDone,
                        delegate(StateMachineClient sender, IEvent evt)
                        {
                            try
                            {
                                UnSafe_RemoveActorsUsingMe(_this);

                                var list = ovc.mOverlayLevelRecords.FindAll
                                    (new OverlayComponent.OverlayLevelRecordRemoveHelper(sender.DefaultPriority).Predicate);

                                if (list != null)
                                {
                                    foreach (var item in list)
                                    {
                                        var overlayLevelRecord = item;
                                        var partsFromLevel = OverlayComponent.GetPartsFromLevel(overlayLevelRecord.mOverlayLevel);
                                        ovc.mInteractionPartsUsedFlags &= partsFromLevel;
                                    }
                                }
                                else if (Simulator.CheckYieldingContext(false) && Random_GetFloat(0, 100f, null) <1)
                                {
                                    if (Simulator.GetProxy(_this.ObjectId) != null)
                                        NiecHelperSituationPosture.ExistsOrCreatePosture(_this, false);
                                    //if (Random_GetFloat(0, 100f, null) < 5)
                                        NiecHelperSituationPosture.r_internal(_this);
                                }
                                if (ovc.mOverlayLevelRecords == null && Random_GetFloat(0, 100f, null) < 1)
                                {
                                    if (Simulator.GetProxy(_this.ObjectId) != null)
                                        NiecHelperSituationPosture.ExistsOrCreatePosture(_this, false);
                                    //if (Random_GetFloat(0, 100f, null) < 10)
                                        NiecHelperSituationPosture.r_internal(_this);
                                }
                                ovc.mOverlayLevelRecords.RemoveAll
                                    (new OverlayComponent.OverlayLevelRecordRemoveHelper(sender.DefaultPriority).Predicate);

                            }
                            catch (ResetException) { throw; }
                            catch (Exception ex)
                            {
                                if (ex is StackOverflowException)
                                    ThrowResetException(null);

                                if (Simulator.GetProxy(_this.ObjectId) != null)
                                    NiecHelperSituationPosture.ExistsOrCreatePosture(_this, false);

                                if (ex is ArgumentException) { ex.stack_trace = null; ex.trace_ips = null; ex.message = null; }

                                if (Simulator.CheckYieldingContext(false) && Random_GetFloat(0, 100f, null) < 1)
                                {
                                    NiecHelperSituationPosture.r_internal(_this);
                                }

                                if (Simulator.CurrentTask == _this.ObjectId)
                                    throw;
                            }
                        }
                    );
                }
                Age age;
                switch (_this.mSimDescription.Age)
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
                        age = Age.young_adult; // custom
                        break;
                }
                Species species;
                switch (_this.mSimDescription.Species)
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
                try
                {
                    if (_this.TraitManager != null && _this.TraitManager.List != null)  // Custom 1:58 14/05/2019
                    {
                        foreach (Trait item in _this.TraitManager.List)
                        {
                            if (item == null) continue; // Custom
                            smc.SetParameter(actorName, typeof(TraitNames), (ulong)item.Guid, YesOrNo.yes);
                        }
                    }
                    if (_this.BuffManager != null && _this.BuffManager.List != null)  // Custom 1:58 14/05/2019
                    {
                        foreach (BuffInstance item2 in _this.BuffManager.List)
                        {
                            if (item2 == null || item2.mBuff == null) continue;   // Custom 1:58 14/05/2019
                            smc.SetParameter(actorName, typeof(BuffNames), (ulong)item2.mBuff.BuffGuid, YesOrNo.yes);
                        }
                    }
                    if (_this.MoodManager != null)
                    {
                        MoodFlavor moodFlavor = _this.MoodManager.MoodFlavor;
                        if (moodFlavor != 0 && moodFlavor != MoodFlavor.Fulfilled)
                        {
                            smc.SetParameter(actorName, typeof(MoodFlavor), (ulong)_this.MoodManager.MoodFlavor, YesOrNo.yes);
                        }
                    }
                }
                catch (ResetException)  { throw; }
                catch                   { }
                
                uint paramHash;
                uint paramHash2;
                uint paramHash3;
                uint paramHash4;
                uint paramHash5;
                switch (actorName[0])
                {
                    case 'X':
                    case 'x':
                        paramHash = 499670524u;
                        paramHash2 = 3485968198u;
                        paramHash3 = 1341508501u;
                        paramHash4 = 2555509350u;
                        paramHash5 = 3242275675u;
                        break;
                    case 'Y':
                    case 'y':
                        paramHash = 2084444177u;
                        paramHash2 = 1976724487u;
                        paramHash3 = 1780181412u;
                        paramHash4 = 2689495323u;
                        paramHash5 = 585333186u;
                        break;
                    case 'Z':
                    case 'z':
                        paramHash = 3151015778u;
                        paramHash2 = 2159644272u;
                        paramHash3 = 2309280715u;
                        paramHash4 = 2470126784u;
                        paramHash5 = 3937651281u;
                        break;
                    default:
                        paramHash = ResourceUtils.HashString32(actorName + ":Age");
                        paramHash2 = ResourceUtils.HashString32(actorName + ":InBadMood");
                        paramHash3 = ResourceUtils.HashString32(actorName + ":Sex");
                        paramHash4 = ResourceUtils.HashString32(actorName + ":ScriptPosture");
                        paramHash5 = ResourceUtils.HashString32(actorName + ":Species");
                        break;
                }
                smc.SetParameter(paramHash, typeof(Age), (ulong)age);
                smc.SetParameter(paramHash2, (uint)(_this.MoodManager != null && _this.MoodManager.IsInNegativeMood ? 979470758 : 1668749452));
                smc.SetParameter(paramHash3, (uint)((_this.mSimDescription.Gender == CASAgeGenderFlags.Male) ? (-1183391106) : (-2090525483)));
                smc.SetParameter(paramHash5, typeof(Species), (ulong)species);
                if (_this.Posture != null)
                {
                    smc.SetParameter(paramHash4, typeof(ScriptPosture), (ulong)_this.Posture.GetSacsPostureParameter());
                }
            }
        }

        public static bool FixUpFullSim(Sim s)
        {
            if (s == null) 
                return false;
            if (s.SimRoutingComponent != null && s.InventoryComp != null)
                return true;

            var objID = s.ObjectId.mValue;
           
            try
            {
                s.OnLoad();
            }
            catch (ResetException)
            { throw; }
            catch (Exception ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
            }

            if (ScriptCore.Simulator.Simulator_GetTaskImpl(objID, false) == null) 
                return false;

            if (s.mLotCurrent == null)
                s.mLotCurrent = LotManager.GetWorldLot();

            try
            {
                s.OnCreation();
            }
            catch (ResetException)
            { throw; }
            catch (Exception ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
            }

            if (ScriptCore.Simulator.Simulator_GetTaskImpl(objID, false) == null)
                return false;

            if (s.mLotCurrent == null)
                s.mLotCurrent = LotManager.GetWorldLot();

            try
            {
                s.OnStartup();
            }
            catch (ResetException)
            { throw; }
            catch (Exception ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
            }

            if (s.mLotCurrent == null)
                s.mLotCurrent = LotManager.GetWorldLot();

            return ScriptCore.Simulator.Simulator_GetTaskImpl(objID, false) != null;
        }

        public static long ReadByte64(uint pointer)
        {
            niec_std.mono_runtime_install_handlers();
            try
            {
                return global::System.Runtime.InteropServices.Marshal.ReadInt64((IntPtr)pointer);
            }
            catch (Exception ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
                return 0;
            }
           
        }

        public unsafe static long UnSafeReadByte64(uint pointer)
        {
            niec_std.mono_runtime_install_handlers();
            //try
            //{
            //   // byte* vl = (byte*)pointer;
            //    return (long)*(long*)pointer;//(&pointer);
            //}
            //catch (Exception ex) // Terminate Runtime?
            //{
            //    ex.stack_trace = null;
            //    ex.message = "";
            //    ex.inner_exception = null;
            //    ex.trace_ips = null;
            //    ex.source = null;
            //    ex._data = null;
            //    return 0;
            //}
            //void* t = (void*)pointer;
            return *(long*)((void*)pointer);
        }

        public unsafe static void UnSafeWriteByte64(uint pointer, long val)
        {
            niec_std.mono_runtime_install_handlers();
            niec_std.write_byte_bit64(pointer, val);

        }

        public static void WriteByte64(uint pointer, long val)
        {
            niec_std.mono_runtime_install_handlers();
            try
            {
                global::System.Runtime.InteropServices.Marshal.WriteInt64((IntPtr)pointer, val);
            }
            catch (Exception ex)
            {
                ex.stack_trace = null;
                ex.message = "";
                ex.inner_exception = null;
                ex.trace_ips = null;
                ex.source = null;
                ex._data = null;
            }

        }
        public static void SimDesc_SMCSetActor(SimDescription _this, StateMachineClient smc, string actorName)
        {
            if (_this == null) 
                throw new NullReferenceException();
            if (smc == null) 
                throw new ArgumentNullException("smc");
            if (actorName == null) 
                throw new ArgumentNullException("actorName");

            Age age;
            switch (_this.Age)
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
                    age = Age.young_adult; // custom
                    break;
            }
            Species species;
            switch (_this.Species)
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
            if (_this.TraitManager != null && _this.TraitManager.List != null)  // Custom 1:58 14/05/2019
            {
                foreach (Trait item in _this.TraitManager.List)
                {
                    if (item == null) continue; // Custom
                    smc.SetParameter(actorName, typeof(TraitNames), (ulong)item.Guid, YesOrNo.yes);
                }
            }
           
            uint paramHash;
            uint paramHash2;
            uint paramHash3;
            //uint paramHash4;
            uint paramHash5;
            switch (actorName[0])
            {
                case 'X':
                case 'x':
                    paramHash = 499670524u;
                    paramHash2 = 3485968198u;
                    paramHash3 = 1341508501u;
                    //paramHash4 = 2555509350u;
                    paramHash5 = 3242275675u;
                    break;
                case 'Y':
                case 'y':
                    paramHash = 2084444177u;
                    paramHash2 = 1976724487u;
                    paramHash3 = 1780181412u;
                    //paramHash4 = 2689495323u;
                    paramHash5 = 585333186u;
                    break;
                case 'Z':
                case 'z':
                    paramHash = 3151015778u;
                    paramHash2 = 2159644272u;
                    paramHash3 = 2309280715u;
                    //paramHash4 = 2470126784u;
                    paramHash5 = 3937651281u;
                    break;
                default:
                    paramHash = ResourceUtils.HashString32(actorName + ":Age");
                    paramHash2 = ResourceUtils.HashString32(actorName + ":InBadMood");
                    paramHash3 = ResourceUtils.HashString32(actorName + ":Sex");
                    //paramHash4 = ResourceUtils.HashString32(actorName + ":ScriptPosture");
                    paramHash5 = ResourceUtils.HashString32(actorName + ":Species");
                    break;
            }
            smc.SetParameter(paramHash, typeof(Age), (ulong)age);
            smc.SetParameter(paramHash2, (uint)1668749452);
            smc.SetParameter(paramHash3, (uint)((_this.Gender == CASAgeGenderFlags.Male) ? (-1183391106) : (-2090525483)));
            smc.SetParameter(paramHash5, typeof(Species), (ulong)species);
        }

        public static bool vbb_UnSafeAwCoreSMCHEATask = true;

        public static void UnSafeAwCoreSMCHEATask(StateMachineClient SMC) {
            // && !SMC.AbortRequested && !SMC.HandleEventsAsynchronously) // test error scrprit
            if (vbb_UnSafeAwCoreSMCHEATask && NiecHelperSituation.__acorewIsnstalled__ && !SMC.HandleEventsAsynchronously)
            {
                NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, SMC);
                NFinalizeDeath.SMCIsValid("x", true, SMC);

                NFinalizeDeath.SMCIsHandleEventsAsynchronously("y", true, SMC);
                NFinalizeDeath.SMCIsValid("y", true, SMC);

                SMC.mHandleEventsAsynchronously = true;
            }
        }

        public static void StateMachineClient_SetActor(StateMachineClient ths, string actorName, IHasScriptProxy actor)
        {
            if (ths == null)
                throw new NullReferenceException(); //throw new ArgumentNullException("ths");
            if (actorName == null) 
                throw new ArgumentNullException("actorName");
            if (ths.mVirtualAddRefs == null)
            {
                throw new SacsErrorException("ths.mVirtualAddRefs == null (ActorName: " + actorName + ")");
            }
            if (ths.mActors == null)
            {
                throw new SacsErrorException("ths.mActors == null (ActorName: " + actorName + ")");
            }
            //if (IsOpenDGSInstalled) {
            //    if (actorName == "x" && StateMachineClient_SimIsPet(actor))
            //    {
            //        var simDesc = (actor as Sim).SimDescription;
            //        var flagSim = simDesc.mSimFlags;
            //        try
            //        {
            //            simDesc.Species = CASAgeGenderFlags.Human;
            //            ths.SetActor(actorName, actor);
            //        }
            //        finally
            //        {
            //            simDesc.mSimFlags = flagSim;
            //        }
            //    }
            //    else
            //    {
            //        ths.SetActor(actorName, actor);
            //    }
            //    return;
            //}
            ths.mVirtualAddRefs[actorName] = actor;
            ObjectGuid actorObjectId = ObjectGuid.InvalidObjectGuid;
            if (actor != null && actor.Proxy != null)
            {
                actorObjectId = actor.Proxy.ObjectId;
            }
            BridgeOrigin origin = null;
            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                SMCIsValid(actorName, true, ths);
                SMCIsHandleEventsAsynchronously(actorName, true, ths);
            }
            if (ths.UseActorBridgeOrigins && actor is IHasBridgeOrigin)
            {
                origin = (actor as IHasBridgeOrigin).BridgeOrigin;
                ths.mActors[actorName] = (actor as IHasBridgeOrigin);
                if (NiecHelperSituation.__acorewIsnstalled__)
                {
                    SMCIsValid(actorName, true, ths);
                    SMCIsHandleEventsAsynchronously(actorName, true, ths);
                }
            }
            ISacsAware sacsAware = actor as ISacsAware;
            if (sacsAware != null)
            {

                try
                {
                    //if (actorName == "x" && StateMachineClient_SimIsPet(actor))
                    //{
                    //    var simDesc = (actor as Sim).SimDescription;
                    //    var flagSim = simDesc.mSimFlags;
                    //    try
                    //    {
                    //        simDesc.Species = CASAgeGenderFlags.Human;
                    //        sacsAware.SetSacsDefaultParameters(ths, actorName);
                    //    }
                    //    finally
                    //    {
                    //        simDesc.mSimFlags = flagSim;
                    //    }
                    //}
                    //else
                    //{
                    //    sacsAware.SetSacsDefaultParameters(ths, actorName);
                    //}
                    if (IsOpenDGSInstalled)
                    {
                        sacsAware.SetSacsDefaultParameters(ths, actorName);
                    }
                    else {
                        Sim sim = actor as Sim;
                        if (sim != null)
                            Sim_SetSacsDefaultParameters(sim, ths, actorName);
                        else 
                            sacsAware.SetSacsDefaultParameters(ths, actorName);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch { if (IsOpenDGSInstalled) throw; }
                
            }
            UnSafeAwCoreSMCHEATask(ths);
            if (vbb_UnSafeAwCoreSMCHEATask && NiecHelperSituation.__acorewIsnstalled__)
                ths.mPendingException = null;
            ths.SetActor(actorName, actorObjectId, origin);
        }

        public static Sim TestSNull(int TestDEBUG)
        {
            // Test :)
            /*
            try
            {
                object DEBUG_ForceError = HelperNra.TFindGhostsGrave(null);
                if (DEBUG_ForceError.ToString() == "") return null;
            }
            catch (Exception exception)
            {
                KillPro.LogTraneEx.Append(exception.ToString());
                if (TestDEBUG == 45452) return null;
            }
             */
            //object DEBUG_ForceError = HelperNra.TFindGhostsGrave(null);
            //if (DEBUG_ForceError.ToString() == "") return null;
            if (TestDEBUG == 45452) return null;
            return Sim.ActiveActor; //new Sim();
        }
        

        public static void ForceCancelAllInteractions(Sim Target)
        {
            
            checked
            {
                for (int i = Target.InteractionQueue.mInteractionList.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        Target.AddExitReason(ExitReason.SuspensionRequested);
                        Target.InteractionQueue.CancelNthInteraction(i, false, ExitReason.Default);
                    }
                    catch
                    { }
                }
            }
             
            //Target.InteractionQueue.mInteractionList.Clear();
        }




        public static void PayForOther(SimDescription simd, Lot lot, int fee)
        {
            if (!lot.IsCommunityLot && lot.Household == null)
                return;

            var household = GetLotOwnerInHousehold(lot);
            var simdHousehold = simd.Household;
            if (household != null && household != simdHousehold)
            {
                household.ModifyFamilyFunds(fee);
                if (simd.FamilyFunds >= fee)
                {
                    simdHousehold.ModifyFamilyFunds(-fee);
                }
                else
                {
                    simdHousehold.UnpaidBills += fee;
                }
            }
            else if (household == null || (household != null && household != simdHousehold))
            {
                simdHousehold.ModifyFamilyFunds(-fee);
            }
        }

        public static Household GetLotOwnerInHousehold(Lot lot)
        {
            if (lot != null)
            {
                foreach (Household item in SC_GetObjects<Household>())
                {
                    if (item == null) 
                        continue;

                    var rem = item.RealEstateManager;
                    if (rem == null)
                        continue;

                    var propertyData = rem.FindProperty(lot);
                    if (propertyData != null && propertyData.Owner != null)
                    {
                        return propertyData.Owner.OwningHousehold;
                    }
                }
                return lot.Household;
            }
            return null;
        }

        public static void RemoveInteraction(Sim Target, int index, bool stopImmediately, bool succeeded)
        {
            if (index >= 0 && index < Target.InteractionQueue.mInteractionList.Count)
            {
                InteractionInstance interactionInstance = Target.InteractionQueue.mInteractionList[index];
                if (Target.InteractionQueue.mIsHeadInteractionLocked && index == 0)
                {
                    throw new ApplicationException("Sim: " + interactionInstance.InstanceActor.SimDescription.FullName + " is removing head interaction: " + interactionInstance.GetInteractionName() + " while it is locked.");
                    //return;
                }
                interactionInstance.OnRemovedFromQueue(index == 0);
                Target.InteractionQueue.mInteractionList.RemoveAt(index);
                /*
                if (!interactionInstance.InstanceActor.HasExitReason(ExitReason.SuspensionRequested))
                {
                    CleanupInteraction(Target, interactionInstance, stopImmediately, succeeded);
                }
                 */
                if (succeeded || Target.InteractionQueue.mBabyOrToddlerTransitionTargetInteraction == interactionInstance || Target.InteractionQueue.mInteractionList.Count == 0)
                {
                    Target.InteractionQueue.mBabyOrToddlerTransitionTargetInteraction = null;
                }
                
            }
        }

        public static void CleanupInteraction(Sim Target, InteractionInstance i, bool stopImmediately, bool succeeded)
        {
            if (i.InteractionObjectPair != null)
            {
                InteractionInstance linkedInteractionInstance = i.LinkedInteractionInstance;
                if (linkedInteractionInstance != null)
                {
                    i.LinkedInteractionInstance = null;
                    Sim instanceActor = linkedInteractionInstance.InstanceActor;
                    if (instanceActor != null && !instanceActor.HasBeenDestroyed)
                    {
                        if (instanceActor.InteractionQueue.IsRunning(linkedInteractionInstance, false) && stopImmediately)
                        {
                            instanceActor.SetObjectToReset();
                        }
                        else
                        {
                            instanceActor.InteractionQueue.CancelInteraction(linkedInteractionInstance, succeeded);
                        }
                    }
                }
                if (succeeded && !stopImmediately)
                {
                    i.CallCallbackOnCompletion(Target);
                }
                else
                {
                    i.CallCallbackOnFailure(Target);
                }
                i.Cleanup();
            }
        }

        public static void ForceChangeState(Relationship relation, LongTermRelationshipTypes state)
        {
            LongTermRelationship.InteractionBits bits = relation.LTR.LTRInteractionBits & (LongTermRelationship.InteractionBits.HaveBeenBestFriends | LongTermRelationship.InteractionBits.HaveBeenFriends | LongTermRelationship.InteractionBits.HaveBeenPartners);

            LTRData data = LTRData.Get(state);
            if (relation.LTR.RelationshipIsInappropriate(data))
            {
                relation.LTR.ChangeBitsForState(state);
                relation.LTR.ChangeState(state);
                relation.LTR.UpdateUI();
            }
            else
            {
                relation.LTR.ForceChangeState(state);
            }

            if (state == LongTermRelationshipTypes.Spouse)
            {
                relation.SimDescriptionA.Genealogy.Marry(relation.SimDescriptionB.Genealogy);

                MidlifeCrisisManager.OnBecameMarried(relation.SimDescriptionA, relation.SimDescriptionB);

                relation.LTR.RemoveInteractionBit(LongTermRelationship.InteractionBits.Divorce);
                relation.LTR.AddInteractionBit(LongTermRelationship.InteractionBits.Marry);

                relation.SetMarriedInGame();

                if (SeasonsManager.Enabled)
                {
                    relation.WeddingAnniversary = new WeddingAnniversary(SeasonsManager.CurrentSeason, (int)SeasonsManager.DaysElapsed);
                    relation.WeddingAnniversary.SimA = relation.SimDescriptionA;
                    relation.WeddingAnniversary.SimB = relation.SimDescriptionB;
                    relation.WeddingAnniversary.CreateAlarm();
                }
            }

            relation.LTR.AddInteractionBit(bits);
        }


        public static SimDescription MakeSim(SimBuilder builder, CASAgeGenderFlags age, CASAgeGenderFlags gender, ResourceKey skinTone, float skinToneIndex, Color[] hairColors, WorldName homeWorld, uint outfitCategoriesToBuild, bool isAlien)
        {
            if (age == CASAgeGenderFlags.None)
            {
                return null;
            }
            if (builder == null)
            {
                builder = new SimBuilder();
                builder.Age = age;
                builder.Gender = gender;
                builder.Species = CASAgeGenderFlags.Human;
                builder.SkinTone = skinTone;
                builder.SkinToneIndex = skinToneIndex;
                builder.TextureSize = 1024u;
                builder.UseCompression = true;
            }
            if (hairColors.Length == 9)
            {
                Color[] array = new Color[10];
                hairColors.CopyTo(array, 0);
                array[9] = hairColors[0];
                hairColors = array;
            }
            if (hairColors.Length != 10)
            {
                hairColors = Genetics.Black1;
            }
            Color[] array2 = new Color[4];
            Array.Copy(hairColors, 5, array2, 0, 4);
            Color activeEyebrowColor = hairColors[4];
            SimDescriptionCore simDescriptionCore = new SimDescriptionCore();
            simDescriptionCore.HomeWorld = homeWorld;
            bool useDyeColor = age == CASAgeGenderFlags.Elder;
            GeneticColor[] hairColors2 = simDescriptionCore.HairColors;
            for (int i = 0; i < 4; i++)
            {
                hairColors2[i].UseDyeColor = useDyeColor;
            }
            simDescriptionCore.HairColors = hairColors2;
            simDescriptionCore.ActiveHairColors = hairColors;
            simDescriptionCore.EyebrowColor.UseDyeColor = useDyeColor;
            simDescriptionCore.ActiveEyebrowColor = activeEyebrowColor;
            simDescriptionCore.BodyHairColor.UseDyeColor = useDyeColor;
            simDescriptionCore.ActiveBodyHairColor = hairColors[9];
            GeneticColor[] facialHairColors = simDescriptionCore.FacialHairColors;
            for (int j = 0; j < 4; j++)
            {
                facialHairColors[j].UseDyeColor = useDyeColor;
            }
            simDescriptionCore.FacialHairColors = facialHairColors;
            simDescriptionCore.ActiveFacialHairColors = array2;
            Dictionary<ResourceKey, float> dictionary = new Dictionary<ResourceKey, float>();
            if (LocaleConstraints.GetFacialShape(ref dictionary, homeWorld))
            {
                foreach (KeyValuePair<ResourceKey, float> keyValuePair in dictionary)
                {
                    builder.SetFacialBlend(keyValuePair.Key, keyValuePair.Value);
                }
            }
            OutfitUtils.AddMissingParts(builder, (OutfitCategories)2097154u, true, simDescriptionCore, isAlien);
            Genetics.SleepIfPossible();
            OutfitUtils.AddMissingParts(builder, OutfitCategories.Everyday, true, simDescriptionCore, isAlien);
            Genetics.SleepIfPossible();
            ResourceKey key = default(ResourceKey);
            if (LocaleConstraints.GetUniform(ref key, homeWorld, age, gender, OutfitCategories.Everyday))
            {
                OutfitUtils.SetOutfit(builder, new SimOutfit(key), simDescriptionCore);
            }
            OutfitUtils.SetAutomaticModifiers(builder);
            ResourceKey key2 = builder.CacheOutfit(string.Format("Genetics.MakeSim_{0}_{1}_{2}", builder.Age, Simulator.TicksElapsed(), OutfitCategories.Everyday));
            if (key2.InstanceId == 0UL)
            {
                return null;
            }
            OutfitCategories[] array3 = new OutfitCategories[]
			{
				OutfitCategories.Naked,
				OutfitCategories.Athletic,
				OutfitCategories.Formalwear,
				OutfitCategories.Sleepwear,
				OutfitCategories.Swimwear
			};
            SimOutfit simOutfit = new SimOutfit(key2);
            SimDescription simDescription = SimDesc_EmptyO(simOutfit); // new SimDescription(simOutfit);
            simDescription.HomeWorld = simDescriptionCore.HomeWorld;
            simDescription.HairColors = simDescriptionCore.HairColors;
            simDescription.FacialHairColors = simDescriptionCore.FacialHairColors;
            simDescription.EyebrowColor = simDescriptionCore.EyebrowColor;
            simDescription.BodyHairColor = simDescriptionCore.BodyHairColor;
            simDescription.AddOutfit(simOutfit, OutfitCategories.Everyday, true);
            foreach (OutfitCategories outfitCategories in array3)
            {
                if ((outfitCategoriesToBuild & (uint)outfitCategories) != 0u)
                {
                    OutfitUtils.MakeCategoryAppropriate(builder, outfitCategories, simDescription);
                    if (LocaleConstraints.GetUniform(ref key, homeWorld, age, gender, outfitCategories))
                    {
                        OutfitUtils.SetOutfit(builder, new SimOutfit(key), simDescriptionCore);
                    }
                    ResourceKey key3 = builder.CacheOutfit(string.Format("Genetics.MakeSim_{0}_{1}_{2}", builder.Age, Simulator.TicksElapsed(), outfitCategories));
                    simDescription.AddOutfit(new SimOutfit(key3), outfitCategories);
                    Genetics.SleepIfPossible();
                }
            }
            simDescription.RandomizePreferences();
            TraitNames cultureSpecificTrait = Genetics.GetCultureSpecificTrait(homeWorld);
            if (cultureSpecificTrait == TraitNames.FutureSim)
            {
                simDescription.TraitManager.AddHiddenElement(cultureSpecificTrait);
                Skill skill = simDescription.SkillManager.AddElement(SkillNames.Future);
                if ((skill.AvailableAgeSpecies & simDescription.GetCASAGSAvailabilityFlags()) != CASAGSAvailabilityFlags.None)
                {
                   // while (simDescription.SkillManager.GetSkillLevel(SkillNames.Future) < skill.MaxSkillLevel)
                    for (int i = 0; i < 10; i++)
                        simDescription.SkillManager.ForceGainPointsForLevelUp(SkillNames.Future);
                }
            }
            else if (cultureSpecificTrait != TraitNames.Unknown)
            {
                simDescription.TraitManager.AddHiddenElement(cultureSpecificTrait);
            }
            builder.Dispose();
            builder = null;
            return simDescription;
        }


        

        public static void RRemoveMSD(ulong msdId)
        {
            MiniSimDescription miniSimDescription = MiniSimDescription.Find(msdId);
            if (miniSimDescription != null )
            {
                if (miniSimDescription.mMiniRelationships != null)
                {
                    foreach (MiniRelationship miniRelationship in miniSimDescription.mMiniRelationships)
                    {
                        MiniSimDescription miniSimDescription2 = MiniSimDescription.Find(miniRelationship.SimDescriptionId);
                        if (miniSimDescription2 != null)
                        {
                            miniSimDescription2.RemoveMiniRelatioship(msdId);
                        }
                    }
                }
                ClearMiniRelationships(miniSimDescription);
                miniSimDescription.Genealogy = null;
                if (MiniSimDescription.sMiniSims != null)
                MiniSimDescription.sMiniSims.Remove(msdId);
            }
        }
        public static void GetCameraPositionAndForward(bool isCameraTargetPos, out Vector3 pos, out Vector3 fwd)
        {
            //pos = NFinalizeDeath.Fast_SnapToFloor
            //    (cameraTargetPos ? ScriptCore.CameraController.Camera_GetTarget() : ScriptCore.CameraController.Camera_GetPosition());
            //Vector3 target = ScriptCore.CameraController.Camera_GetTarget();
            //target.y = pos.y;
            //fwd = target - pos;
            //fwd = fwd.Normalize();

            var cameraPos = ScriptCore.CameraController.Camera_GetPosition();
            var cameraTargetPos = ScriptCore.CameraController.Camera_GetTarget();
            fwd = NFinalizeDeath.MathU_FaceToPos(cameraPos, cameraTargetPos);
            pos = NFinalizeDeath.Fast_SnapToFloor(isCameraTargetPos ? cameraTargetPos : cameraPos);
        }
        public static List<SimDescription> TattoaX()
        {
            List<SimDescription> list = new List<SimDescription>();

            /*
            List<SimDescription> cpplist = new List<SimDescription>(GameStates.sTravelData.mSimDescriptionNeedPostFixUp);
            List<SimDescription> cpplisti = new List<SimDescription>(SimDescription.sLoadedSimDescriptions);
            List<SimDescription> cpplistj = new List<SimDescription>();
            List<SimDescription> cpplistk = new List<SimDescription>();
            List<SimDescription> cpplista = new List<SimDescription>();
            List<SimDescription> cpplistc = new List<SimDescription>();


            */




            List<Sim> asdo = new List<Sim>();

            try
            {
                if (RoleManager.sRoleManager != null && RoleManager.sRoleManager.mRoles != null)
                foreach (List<Role> collection in RoleManager.sRoleManager.mRoles.Values)
                {
                    if (collection == null) continue;
                    try
                    {
                        foreach (Role role in collection)
                        {
                            if (role == null) continue;
                            if (!list.Contains(role.mSim))
                                list.Add(role.mSim);
                            //role.mSim = null;
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception)
                    { }

                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            try
            {
                try
                {
                    if (GameStates.sTravelData != null && GameStates.sTravelData.mSimDescriptionNeedPostFixUp != null)
                    foreach (SimDescription simDescription4 in GameStates.sTravelData.mSimDescriptionNeedPostFixUp)
                    {
                        if (simDescription4 == null) continue;
                        if (!list.Contains(simDescription4))
                            list.Add(simDescription4);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    try
                    {
                        foreach (Sim simau in SC_GetObjects<Sim>())
                        {
                            try
                            {
                                if (!asdo.Contains(simau))
                                    asdo.Add(simau);
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch
                            { }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }


                    try
                    {
                        foreach (Sim simau in LotManager.Actors)
                        {
                            try
                            {
                                if (!asdo.Contains(simau))
                                    asdo.Add(simau);
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch
                            { }
                        }
                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch
                    { }

                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }





                try
                {
                    foreach (Sim simaue in asdo)
                    {
                        if (simaue == null) continue;
                        SimDescription checkkillsim = simaue.SimDescription;
                        if (checkkillsim != null && !list.Contains(checkkillsim))
                            list.Add(checkkillsim);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }




            try
            {
                try
                {

                    //list.Add(SimDescription.sLoadedSimDescriptions)
                    //list.AddRange(SimDescription.sLoadedSimDescriptions);
                    if ( SimDescription.sLoadedSimDescriptions != null)
                    foreach (SimDescription sdra in SimDescription.sLoadedSimDescriptions)
                    {
                        if (sdra == null) continue;
                        if (!list.Contains(sdra))
                            list.Add(sdra);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                try
                {
                    foreach (Household household in SC_GetObjects<Household>())//Household.sHouseholdList)
                    {
                        if (household == null) continue;
                        if (household.mMembers == null || household.mMembers.mAllSimDescriptions == null) continue;
                        try
                        {
                            foreach (SimDescription sda in household.mMembers.mAllSimDescriptions)
                            {
                                if (sda == null) continue;
                                if (!list.Contains(sda))
                                    list.Add(sda);
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        {}
                        
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                

                try
                {
                    Urnstone[] objects = SC_GetObjects<Urnstone>();
                    foreach (Urnstone urnstone in objects)
                    {
                        if (urnstone.DeadSimsDescription != null && !list.Contains(urnstone.DeadSimsDescription))
                        {
                            
                            list.Add(urnstone.DeadSimsDescription);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                
                try
                {
                    foreach (SimDescription sd in EverySimDescriptionProX_()) //Household.EverySimDescription())
                    {
                        if (sd == null) 
                            continue;

                        if (!list.Contains(sd))
                            list.Add(sd);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                
                try
                {
                    if (GameStates.sTravelData != null && GameStates.sTravelData.mEarlyDepartures != null)
                    {
                        foreach (Sim sirtyrtym in GameStates.sTravelData.mEarlyDepartures)
                        {
                            if (sirtyrtym == null || sirtyrtym.mSimDescription == null)
                                continue;

                            if (!list.Contains(sirtyrtym.SimDescription))
                                list.Add(sirtyrtym.SimDescription);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }
                
                try
                {
                    if (IntroTutorial.SimsRemovedFromHousehold != null)
                    {
                        foreach (Sim simta in IntroTutorial.SimsRemovedFromHousehold)
                        {
                            if (simta == null || simta.mSimDescription == null) 
                                continue;

                            if ( !list.Contains(simta.SimDescription))
                            list.Add(simta.SimDescription);
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch
                { }



                //try
                //{
                //    foreach (SimDescription simDescripaation in SimDescription.GetAll(SimDescription.Repository.Household))
                //    {
                //        if (simDescripaation == null) continue;
                //        if (!list.Contains(simDescripaation))
                //            list.Add(simDescripaation);
                //    }
                //}
                //catch (StackOverflowException) { throw; }
                //catch (ResetException) { throw; }
                //catch
                //{ }


            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch
            { }
            return list;
        }







        public static List<SimDescription> TattoaXDebug()
        {
            List<SimDescription> list = new List<SimDescription>();

            /*
            List<SimDescription> cpplist = new List<SimDescription>(GameStates.sTravelData.mSimDescriptionNeedPostFixUp);
            List<SimDescription> cpplisti = new List<SimDescription>(SimDescription.sLoadedSimDescriptions);
            List<SimDescription> cpplistj = new List<SimDescription>();
            List<SimDescription> cpplistk = new List<SimDescription>();
            List<SimDescription> cpplista = new List<SimDescription>();
            List<SimDescription> cpplistc = new List<SimDescription>();


            */




            List<Sim> asdo = new List<Sim>();
            try
            {
                try
                {
                    foreach (SimDescription simDescription4 in GameStates.sTravelData.mSimDescriptionNeedPostFixUp)
                    {
                        if (simDescription4 == null) continue;
                        if (!list.Contains(simDescription4))
                            list.Add(simDescription4);
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                try
                {
                    try
                    {
                        foreach (Sim simau in SC_GetObjects<Sim>())
                        {
                            try
                            {
                                if (!asdo.Contains(simau))
                                    asdo.Add(simau);
                            }
                            catch
                            { }
                        }
                    }
                    catch
                    { }


                    try
                    {
                        foreach (Sim simau in LotManager.Actors)
                        {
                            try
                            {
                                if (!asdo.Contains(simau))
                                    asdo.Add(simau);
                            }
                            catch
                            { }
                        }
                    }
                    catch
                    { }

                }
                catch
                { }





                try
                {
                    foreach (Sim simaue in asdo)
                    {
                        SimDescription checkkillsim = simaue.SimDescription;
                        if (checkkillsim != null && !list.Contains(checkkillsim))
                            list.Add(checkkillsim);
                    }
                }
                catch
                { }
            }
            catch
            { }




            try
            {
                try
                {

                    //list.Add(SimDescription.sLoadedSimDescriptions)
                    //list.AddRange(SimDescription.sLoadedSimDescriptions);
                    foreach (SimDescription sdra in SimDescription.sLoadedSimDescriptions)
                    {
                        if (sdra == null) continue;
                        if (!list.Contains(sdra))
                            list.Add(sdra);
                    }
                }
                catch
                { }
                try
                {
                    foreach (Household household in Household.sHouseholdList)
                    {
                        foreach (SimDescription sda in household.AllSimDescriptions)
                        {
                            if (sda == null) continue;
                            if (!list.Contains(sda))
                                list.Add(sda);
                        }
                    }
                }
                catch
                { }


                try
                {
                    Urnstone[] objects = SC_GetObjects<Urnstone>();
                    foreach (Urnstone urnstone in objects)
                    {
                        if (urnstone.DeadSimsDescription != null && !list.Contains(urnstone.DeadSimsDescription))
                        {

                            list.Add(urnstone.DeadSimsDescription);
                        }
                    }
                }
                catch
                { }

                try
                {
                    foreach (SimDescription sd in Household.EverySimDescription())
                    {
                        if (sd == null) continue;
                        if (!list.Contains(sd))
                            list.Add(sd);
                    }
                }
                catch
                { }

                try
                {
                    if (GameStates.sTravelData != null && GameStates.sTravelData.mEarlyDepartures != null)
                    {
                        foreach (Sim sirtyrtym in GameStates.sTravelData.mEarlyDepartures)
                        {
                            if (sirtyrtym == null) continue;
                            if (!list.Contains(sirtyrtym.SimDescription))
                                list.Add(sirtyrtym.SimDescription);
                        }
                    }
                }
                catch
                { }

                try
                {
                    if (IntroTutorial.SimsRemovedFromHousehold != null)
                    {
                        foreach (Sim simta in IntroTutorial.SimsRemovedFromHousehold)
                        {
                            if (simta == null) continue;
                            if (!list.Contains(simta.SimDescription))
                                list.Add(simta.SimDescription);
                        }
                    }
                }
                catch
                { }



                try
                {
                    foreach (SimDescription simDescripaation in SimDescription.GetAll(SimDescription.Repository.Household))
                    {
                        if (simDescripaation == null) continue;
                        if (!list.Contains(simDescripaation))
                            list.Add(simDescripaation);
                    }
                }
                catch
                { }


            }

            catch
            { }
            return list;
        }










        public static List<SimDescription> Tattoa()
        {
            List<SimDescription> list = new List<SimDescription>();
            list.AddRange(ATTSE());
            list.AddRange(ATTSS());
            return list;
        }

        public static List<SimDescription> ATTSS()
        {
            List<SimDescription> list = new List<SimDescription>();
            Urnstone[] objects = SC_GetObjects<Urnstone>();
            for (int i = 0; i < objects.Length; i++)
            {
                SimDescription deadSimsDescription = objects[i].DeadSimsDescription;
                if (deadSimsDescription != null)
                {
                    list.Add(deadSimsDescription);
                }
            }
            return list;
        }

        public static List<SimDescription> ATTSE()
        {
            List<SimDescription> list = new List<SimDescription>();
            foreach (Household household in Household.sHouseholdList)
            {
                if (household.mMembers.mAllSimDescriptions == null) continue;
                list.AddRange(household.mMembers.mAllSimDescriptions);
            }
            return list;
        }

        public static bool IsExtKillSimNiecAndYLevel(Sim actor)
        {

            

            /*
            if (actor == null)
            {
                //throw new ArgumentNullException("actor");
                return false;
            }
            */
            /*
            if (actor.InteractionQueue == null) return false;
            */
            if (actor.SimDescription == null) return false;


            try
            {
                if (actor.SimDescription.Household == Household.ActiveHousehold)
                {
                    return true;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            if (AssemblyCheckByNiec.IsInstalled("NiecMod"))
            {
                try
                {
                    if (actor.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton)) return true;
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    foreach (InteractionInstance interactionInstance in actor.InteractionQueue.InteractionList)
                    {
                        if (interactionInstance is ExtKillSimNiec)
                        {
                            return true;
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                try
                {
                    foreach (InteractionInstance interactionInstance in actor.InteractionQueue.InteractionList)
                    {
                        if (interactionInstance.InteractionDefinition == ExtKillSimNiec.Singleton)
                        {
                            return true;
                        }
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

            }
            try
            {
                if (!(actor.Service is Sims3.Gameplay.Services.GrimReaper))
                {
                    foreach (InteractionInstance interactionInstance in actor.InteractionQueue.InteractionList)
                    {
                        if (interactionInstance.GetPriority().Level > (InteractionPriorityLevel)100)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }


            return false;
        
        }

        public static bool AdertyrtyX = false;

        public static bool Adertyrty = false;

        public static StringBuilder LogHelper = new StringBuilder();
        /// <summary>
        /// This a Aotoa
        /// </summary>
        public enum APACheck
        {
            Aota,
            Aots
        }
        /// <summary>
        /// Check Has
        /// </summary>
        public static void CheckMorun() {}
        // UnTested
        /*
        public static InteractionPriority AutonomousCheckWithActiveHousehold()
        {
            try
            {
                Sim a = null;
                InteractionPriority autonomous = new InteractionPriority(InteractionPriorityLevel.Autonomous, 0f);
                //if (Sim.ActiveActor != null && Sim.ActiveActor.Household != null)
                if (Household.ActiveHousehold != null)
                if (a.Household != Household.ActiveHousehold)
                //if (Aicota.IsInActiveHousehold)
                {
                    StyledNotification.Show(new StyledNotification.Format("AutonomousCheckWithActiveHousehold: Done", StyledNotification.NotificationStyle.kGameMessagePositive));
                    autonomous = new InteractionPriority((InteractionPriorityLevel)14, 0f);
                }
                else
                {
                    StyledNotification.Show(new StyledNotification.Format("AutonomousCheckWithActiveHousehold: Failed", StyledNotification.NotificationStyle.kGameMessagePositive));
                    autonomous = new InteractionPriority(InteractionPriorityLevel.Autonomous, 0f);
                }
                return autonomous;
            }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
                StyledNotification.Show(new StyledNotification.Format("AutonomousCheckWithActiveHousehold: Catch", StyledNotification.NotificationStyle.kGameMessagePositive));
                InteractionPriority autonomous = new InteractionPriority(InteractionPriorityLevel.Autonomous, 0f);
                return autonomous;
            }
        }
        */
        /// <summary>
        /// This a CheckPregnancy 
        /// </summary>
        /// <param name="target"></param>
        public static void CheckPregnancy(Sim target)
        {
            if (target.SimDescription.IsPregnant)
            {
                target.SimDescription.Pregnancy.ClearPregnancyData();
                if (target.SimDescription.Pregnancy == null)
                {
                    StyledNotification.Show(new StyledNotification.Format(target.Name + Localization.LocalizeString("cmarXmods/PregControl/PregNotice:NoMorePreg", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                }
                else
                {
                    StyledNotification.Show(new StyledNotification.Format(Localization.LocalizeString("cmarXmods/PregControl/PregNotice:TerminationFail", new object[0]), StyledNotification.NotificationStyle.kGameMessagePositive));
                }
            }
        }
        /// <summary>
        /// This a DKill
        /// </summary>
        /// <param name="simd"></param>
        /// <returns></returns>
        public static bool DKill(SimDescription simd)
        {
            Sim sime = simd.CreatedSim;
            /*
            if (simd.CreatedSim == null)
            {
                return false;
            }
            if (sime == null)
            {
                return false;
            }
            */
            if (simd == null)
            {
                return false;
            }
            try
            {
                if (IsExtKillSimNiecAndYLevel(sime))
                {
                    return true;
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            Household mec = sime.Household.SimDescriptions[0].Household.SimDescriptions[4].CreatedSim.Household.AllSimDescriptions[1].TraitManager.mSimDescription.Household;
            if (mec != null) mec.SendEventsOnFundsChanged(0);
            try
            {
                throw new NiecModException("Not Error Show Sim Description");
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (NiecModException ex)
            {
                NiecException.WriteLog("DKill: " + NiecException.NewLine + NiecException.LogException(ex), true, false, true);
            }
            try
            {
                
                
                try
                {
                    CheckPregnancy(sime);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                if (!simd.IsGhost || !simd.IsPlayableGhost || !simd.IsDead)
                {
                    try
                    {

                        if (simd.Household != null)
                        {
                            ExtKillSimNiec.ListMorunExtKillSim(sime, SimDescription.DeathType.Shark);
                        }
                        FinalizeSimDeathRelationships(simd, 0f);

                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception ex)
                    {
                        NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
                        try
                        {
                            simd.ShowSocialsOnSim = false;
                            simd.IsNeverSelectable = true;
                            simd.Contactable = false;
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                    }
                    finally
                    {
                        try
                        {
                            simd.ShowSocialsOnSim = false;
                            simd.IsNeverSelectable = true;
                            simd.Contactable = false;
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                    }
                    SafeNRaas.NRUrnstones_CreateGrave(simd, SimDescription.DeathType.Shark, true, false);
                    StyledNotification.Show(new StyledNotification.Format("DKill: " + simd.FullName + " Done Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                }
                else
                {
                    StyledNotification.Show(new StyledNotification.Format("DKill: " + simd.FullName + " Failed :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                }
                return true;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
                StyledNotification.Show(new StyledNotification.Format("DKill: " + simd.FullName + " Failed :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                return true;
            }
        }
        /// <summary>
        /// This a SKill
        /// </summary>
        /// <param name="sims"></param>
        /// <returns></returns>

        public static void DKillVoid(SimDescription simd)
        {
            Sim sime = simd.CreatedSim;
            try
            {
                throw new NiecModException("Not Error Show Sim Description");
            }
            catch (NiecModException ex)
            {

                NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
            }
            try
            {
                try
                {
                    CheckPregnancy(sime);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
                if (!simd.IsGhost || !simd.IsPlayableGhost || !simd.IsDead)
                {
                    try
                    {

                        if (simd.Household != null)
                        {
                            ExtKillSimNiec.ListMorunExtKillSim(sime, SimDescription.DeathType.Shark);
                        }
                        FinalizeSimDeathRelationships(simd, 0f);

                    }
                    catch (StackOverflowException) { throw; }
                    catch (ResetException) { throw; }
                    catch (Exception ex)
                    {
                        NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
                        try
                        {
                            simd.ShowSocialsOnSim = false;
                            simd.IsNeverSelectable = true;
                            simd.Contactable = false;
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                    }
                    finally
                    {
                        try
                        {
                            simd.ShowSocialsOnSim = false;
                            simd.IsNeverSelectable = true;
                            simd.Contactable = false;
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch (Exception)
                        { }
                    }
                    SafeNRaas.NRUrnstones_CreateGrave(simd, SimDescription.DeathType.Shark, true, false);
                    StyledNotification.Show(new StyledNotification.Format("DKill: " + simd.FullName + " Done Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                }
                else
                {
                    StyledNotification.Show(new StyledNotification.Format("DKill: " + simd.FullName + " Failed :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                }
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
                StyledNotification.Show(new StyledNotification.Format("DKill: " + simd.FullName + " Failed :)", StyledNotification.NotificationStyle.kGameMessagePositive));
            }
        }

        public static bool SKill(Sim sims)
        {

            try
            {
                if (!sims.SimDescription.IsGhost || !sims.SimDescription.IsPlayableGhost || !sims.SimDescription.IsDead)
                {
                    SafeNRaas.NRUrnstones_CreateGrave(sims.SimDescription, SimDescription.DeathType.Shark, true, false);
                    StyledNotification.Show(new StyledNotification.Format("SKill: " + sims.Name + " Done Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                }
                else
                {
                    StyledNotification.Show(new StyledNotification.Format("SKill: " + sims.Name + " Failed :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                }
                return true;
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message + NiecException.NewLine + ex.StackTrace);
                StyledNotification.Show(new StyledNotification.Format("SKill: " + sims.Name + " Failed :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                return true;
            }
        }

        private static void Told(Household newHousehold, bool bForce)
        {
            
            if (newHousehold != null)
            {
                Lot.UpdatePlayerNeighbors();
                TombRoomManager.OnChangeHousehold(newHousehold);
            }
        }

        public static Sim MakeRandomSimWithFutureWorld(Vector3 point, CASAgeGenderFlags age, CASAgeGenderFlags gender)
        {
            LotLocation lotLocation = default(LotLocation);
            ulong lotLocation2 = World.GetLotLocation(point, ref lotLocation);
            Lot lot = LotManager.GetLot(lotLocation2);
            if ((age & (CASAgeGenderFlags.Baby | CASAgeGenderFlags.Toddler | CASAgeGenderFlags.Child)) != CASAgeGenderFlags.None)
            {
                bool flag = false;
                if (lot != null && lot.Household != null)
                {
                    foreach (SimDescription simDescription in lot.Household.SimDescriptions)
                    {
                        if (simDescription.TeenOrAbove)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    return null;
                }
            }
            SimDescription simDescription2 = Genetics.MakeSim(age, gender, WorldName.FutureWorld, uint.MaxValue);
            Genetics.AssignRandomTraits(simDescription2);
            if (lot != null)
            {
                if (lot.Household == null)
                {
                    Household household = Household.Create();
                    household.Name = simDescription2.mLastName ?? "";
                    lot.MoveIn(household);
                }
                lot.Household.Add(simDescription2);
            }
            else
            {
                Household household2 = Household.Create();
                household2.SetName("Default");
                household2.Add(simDescription2);
            }
            WorldName currentWorld = GameUtils.GetCurrentWorld();
            simDescription2.FirstName = SimUtils.GetRandomGivenName(simDescription2.IsMale, currentWorld);
            simDescription2.LastName = SimUtils.GetRandomFamilyName(currentWorld);
            return simDescription2.Instantiate(point);
        }

        public static Sim MakeRandomSimWithChina(Vector3 point, CASAgeGenderFlags age, CASAgeGenderFlags gender)
        {
            LotLocation lotLocation = default(LotLocation);
            ulong lotLocation2 = World.GetLotLocation(point, ref lotLocation);
            Lot lot = LotManager.GetLot(lotLocation2);
            if ((age & (CASAgeGenderFlags.Baby | CASAgeGenderFlags.Toddler | CASAgeGenderFlags.Child)) != CASAgeGenderFlags.None)
            {
                bool flag = false;
                if (lot != null && lot.Household != null)
                {
                    foreach (SimDescription simDescription in lot.Household.SimDescriptions)
                    {
                        if (simDescription.TeenOrAbove)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    return null;
                }
            }
            SimDescription simDescription2 = Genetics.MakeSim(age, gender, WorldName.China, uint.MaxValue);
            Genetics.AssignRandomTraits(simDescription2);
            if (lot != null)
            {
                if (lot.Household == null)
                {
                    Household household = Household.Create();
                    household.Name = simDescription2.mLastName ?? "";
                    lot.MoveIn(household);
                }
                lot.Household.Add(simDescription2);
            }
            else
            {
                Household household2 = Household.Create();
                household2.SetName("Default");
                household2.Add(simDescription2);
            }
            WorldName currentWorld = WorldName.China;
            simDescription2.FirstName = SimUtils.GetRandomGivenName(simDescription2.IsMale, currentWorld);
            simDescription2.LastName = SimUtils.GetRandomFamilyName(currentWorld);
            return simDescription2.Instantiate(point);
        }

        
        /*
        public static WorldName GetCurrentWorldAST()
        {
            if (GameUtils.CheatOverrideCurrentWorld != WorldName.Undefined)
            a
            return GameUtils.gGameUtils.GetCurrentWorldName();{
                return GameUtils.CheatOverrideCurrentWorld;
            }
        }
        */

        public static WorldName GetCurrentWorldLAYOPA()
        {
            WorldName anychild = WorldName.China;
            return anychild;
        }
        /// <summary>
        /// This a Finalize Anti-NPC
        /// </summary>
        /// <param name="deadSim">Dead Sim</param>
        /// <param name="timeoutToAdd">TimeOut</param>
        public static void FinalizeSimDeathRelationships(SimDescription deadSim, float timeoutToAdd)
        {
            if (deadSim == null) return;
            bool flag = timeoutToAdd != 0f;
            foreach (Relationship item in Relationship.Get(deadSim))
            {
                if (item != null)
                {
                    SimDescription otherSimDescription = item.GetOtherSimDescription(deadSim);
                    if (otherSimDescription == null) 
                        continue;

                    Sim createdSim = otherSimDescription.CreatedSim;
                    if (createdSim != null && createdSim.BuffManager != null)
                    {
                        LTRData.RelationshipClassification relationshipClass = LTRData.Get(item.LTR.CurrentLTR).RelationshipClass;
                        if (item.AreRomantic() && item.LTR.IsPositive && (relationshipClass == LTRData.RelationshipClassification.High || (item.LTR.Liking > BuffHeartBroken.LikingValueForPartner && relationshipClass == LTRData.RelationshipClassification.Medium)))
                        {
                            BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken;
                            if (flag)
                            {
                                buffInstanceHeartBroken = (createdSim.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                                if (buffInstanceHeartBroken == null || buffInstanceHeartBroken.BuffOrigin != Origin.FromWitnessingDeath || buffInstanceHeartBroken.TimeoutCount < timeoutToAdd)
                                {
                                    createdSim.BuffManager.AddElement(BuffNames.HeartBroken, timeoutToAdd, Origin.FromWitnessingDeath);
                                }
                            }
                            else
                            {
                                createdSim.BuffManager.AddElement(BuffNames.HeartBroken, Origin.FromWitnessingDeath);
                            }
                            buffInstanceHeartBroken = (createdSim.BuffManager.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken);
                            if (buffInstanceHeartBroken != null)
                            {
                                buffInstanceHeartBroken.MissedSim = deadSim;
                            }
                        }
                        else if (item.LTR.Liking > Urnstone.kMinLikingAddMourning || otherSimDescription.Household == deadSim.Household)
                        {
                            BuffMourning.BuffInstanceMourning buffInstanceMourning;
                            if (flag)
                            {
                                buffInstanceMourning = (createdSim.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                                if (buffInstanceMourning == null || buffInstanceMourning.TimeoutCount < timeoutToAdd)
                                {
                                    createdSim.BuffManager.AddElement(BuffNames.Mourning,  timeoutToAdd, Origin.FromWitnessingDeath);
                                }
                            }
                            else
                            {
                                createdSim.BuffManager.AddElement(BuffNames.Mourning, Origin.FromWitnessingDeath);
                            }
                            buffInstanceMourning = (createdSim.BuffManager.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning);
                            if (buffInstanceMourning != null)
                            {
                                buffInstanceMourning.MissedSim = deadSim;
                            }
                        }
                    }

                    //deadSim.LotCurrent.LastDiedSim = deadSim;

                    if (deadSim.Partner == otherSimDescription)
                    {
                        if (item.LTR.HasInteractionBit(LongTermRelationship.InteractionBits.Marry))
                        {
                            item.LTR.RemoveInteractionBit(LongTermRelationship.InteractionBits.Marry);
                            item.LTR.AddInteractionBit(LongTermRelationship.InteractionBits.Divorce);
                            WeddingAnniversary weddingAnniversary = item.WeddingAnniversary;
                            if (weddingAnniversary != null)
                            {
                                AlarmManager.Global.RemoveAlarm(weddingAnniversary.AnniversaryAlarm);
                                item.WeddingAnniversary = null;
                            }
                            SocialCallback.BreakUpDescriptionsShared(deadSim, otherSimDescription);
                        }
                        else if (item.LTR.HasInteractionBit(LongTermRelationship.InteractionBits.Propose))
                        {
                            item.LTR.RemoveInteractionBit(LongTermRelationship.InteractionBits.Propose);
                            item.LTR.AddInteractionBit(LongTermRelationship.InteractionBits.BreakUp);
                        }
                        else if (item.LTR.HasInteractionBit(LongTermRelationship.InteractionBits.MakeCommitment))
                        {
                            item.LTR.RemoveInteractionBit(LongTermRelationship.InteractionBits.MakeCommitment);
                            item.LTR.AddInteractionBit(LongTermRelationship.InteractionBits.BreakUp);
                        }
                        deadSim.ClearPartner();
                    }
                }
            }
        }
    }
}
