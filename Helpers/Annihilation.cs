using Sims3.Gameplay;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.ActorSystems.Children;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Careers;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.Objects.Vehicles;
using Sims3.Gameplay.PetSystems;
using Sims3.Gameplay.Services;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Situations;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.TimeTravel;
using Sims3.Gameplay.UI;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using Sims3.UI.CAS;
using Sims3.UI.Dialogs;
using Sims3.UI.Hud;
using System;
using System.Collections.Generic;
using NiecMod.Nra;
using NiecMod.Interactions;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Abstracts;
using NiecMod.KillNiec;
using Sims3.Gameplay.Controllers.Niec;
using Sims3.Gameplay.Passport;
//using NRaas.CommonSpace.Helpers;
using NiecMod.Interactions.Hidden;
//using NiecS3Mod;
using System.Text;
using Sims3.Gameplay.Roles;
using Sims3.Gameplay.Scuba;
using Sims3.Gameplay.Objects.Seating;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Niec.iCommonSpace
{
    public class KillPro
    {


        public static bool NonEACanBeKilledPro(Sim targetSim, out string textReason)
        {
            textReason = " None";
            if (targetSim == null)
            {
                textReason = " Sim Is Null";
                return false;
            }
            if (targetSim.SimDescription == null)
            {
                textReason = " Sim doesn't have a description!";
                return false;
            }
            try
            {
                if (targetSim.SimDescription.IsGhost && !targetSim.SimDescription.IsPlayableGhost)
                {
                    textReason = " Sim Is Ghost";
                    return false;
                }
                if (targetSim.SimDescription.IsPlayableGhost)
                {
                    textReason = " Sim Is Playable Ghost";
                    return false;
                }
                if (targetSim.SimDescription.IsDead)
                {
                    textReason = " Sim Is Dead";
                    return false;
                }
                if (targetSim.mInteractionQueue == null)
                {
                    textReason = " Sim don't have a InteractionQueue";
                    return false;
                }

                try
                {
                    foreach (var checknull in targetSim.InteractionQueue.mInteractionList)
                    {
                        if (checknull == null)
                        {
                            textReason = " Sim's mInteractionList[Item] in Null Found";
                            return false;
                        }
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception)
                { }

                


                if (targetSim.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton))
                {
                    textReason = " Sim Is ExtKillSimNiec Found A";
                    return false;
                }

                Type type = ExtKillSimNiec.Singleton.GetType();
                foreach (InteractionInstance interactionInstance in targetSim.InteractionQueue.mInteractionList)
                {
                    try
                    {
                        if (interactionInstance.InteractionDefinition.GetType() == type)
                        {
                            textReason = " Sim Is ExtKillSimNiec Found B";
                            return false;
                        }
                    }
                    catch
                    { }

                }

                if (targetSim.InteractionQueue.HasInteractionOfType(typeof(ExtKillSimNiec)))
                {
                    textReason = " Sim Is ExtKillSimNiec Found C";
                    return false;
                }

                if (targetSim.InteractionQueue.HasInteractionOfTypeAndTarget(ExtKillSimNiec.Singleton, targetSim))
                {
                    textReason = " Sim Is ExtKillSimNiec Found D";
                    return false;
                }

                foreach (InteractionInstance interactionInstance in targetSim.InteractionQueue.InteractionList)
                {
                    if (interactionInstance is ExtKillSimNiec)
                    {
                        textReason = " Sim Is ExtKillSimNiec Found E";
                        return false;
                    }
                }




                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {

                    foreach (InteractionInstance interactionInstance in targetSim.InteractionQueue.InteractionList)
                    {
                        if (interactionInstance is Urnstone.KillSim)
                        {
                            textReason = " Sim Is UrnstoneKillSim Found A";
                            return false;
                        }
                    }
                    if (targetSim.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                    {
                        textReason = " Sim Is  UrnstoneKillSim Found B";
                        return false;
                    }
                }


                if (targetSim.Service != null && targetSim.Service is GrimReaper)
                {
                    textReason = " Sim Is Grim Reaper";
                    return false;
                }
            }
            catch (Exception ex)
            {
                //textReason = " Error: " + ex.GetType().FullName + ": " + ex.Message;
                textReason = " Error: " + NL + ex.ToString(); // + ex.GetType().FullName + ": " + ex.Message;
                return false;
            }


            return true;
        }

        public static bool EACanBeKilledPro(Sim targetSim, out string textReason)
        {
            textReason = " None";
            try
            {

                OccultImaginaryFriend occultImaginaryFriend = null;
                if (OccultImaginaryFriend.TryGetOccultFromSim(targetSim, out occultImaginaryFriend) && !occultImaginaryFriend.IsReal)
                {
                    textReason = " Sim Is Occult Imaginary Friend";
                    return false;
                }
                if (targetSim.SimDescription.AssignedRole is NPCAnimal)
                {
                    textReason = " Assigned Role NPC Animal";
                    return false;
                }
                if (targetSim.OccultManager.HasOccultType(OccultTypes.TimeTraveler))
                {
                    textReason = " Sim is TimeTraveler";
                    return false;
                }
                if (HolographicProjectionSituation.IsSimHolographicallyProjected(targetSim))
                {
                    textReason = " Sim is HolographicProjectionSituation";
                    return false;
                }

                if (targetSim.InteractionQueue == null)
                {
                    textReason = " Sim don't have a InteractionQueue";
                    return false;
                }
                if (targetSim.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                {
                    textReason = " Kill Sim Interaction Found";
                    return false;
                }
                if (targetSim.SimDescription.IsPregnant )
                {
                    textReason = " Sim Is Pregnant";
                    return false;
                }
                if (targetSim.SimDescription.IsGhost)
                {
                    textReason = " Sim Is Ghost";
                    return false;
                }
                if ((ServiceSituation.IsSimOnJob(targetSim) && !targetSim.SimDescription.CanBeKilledOnJob))
                {
                    textReason = " SimOnJob And Not CanBeKilledOnJob";
                    return false;
                }
                if (targetSim.IsNPC)
                {
                    if (!targetSim.LotCurrent.IsWorldLot)
                    {
                        foreach (Sim sim in targetSim.LotCurrent.GetSims())
                        {
                            if (sim.IsSelectable)
                            {
                                //textReason = " Target Is NPC : Sim Is Selectable";
                                return true;
                            }
                        }
                    }
                    textReason = " SimNPC In LotCurrent Sim Is Selectable Not Found";
                    return false;
                }
                if (targetSim.LotCurrent.IsDivingLot && !(targetSim.Posture is ScubaDiving))
                {
                    textReason = " Sim Is DivingLot Found : ScubaDiving Not Found";
                    return false;
                }
                if (targetSim.LotCurrent.IsWorldLot)
                {
                    textReason = " Sim Is WorldLot Failed";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                textReason = " Error: " + NL + ex.ToString(); // + ex.GetType().FullName + ": " + ex.Message;

                /*
                if (!AcceptCancelDialog.Show("EA CanBeKilled By Niec: Name (" + targetSim.Name + ") Found Error (" + ex.Message + ") Do want you run? [Yes Run or No Cancel]", true))
                {
                    return false;
                }
                */
            }
            return false;
        }








        [Tunable]
        public static bool sLoaderLogTraneEx = true;
        [Persistable(false)]
        public static bool sForceError = false;

        public static string sIForceError = null;


        public static int sLogEnumeratorTrane = 0;

        public static StringBuilder LogTraneEx = new StringBuilder();
         


        private static SimDescription.DeathType GetDeathType(Sim target)
        {
            try
            {
                List<SimDescription.DeathType> listr = new List<SimDescription.DeathType>();

                if (target.BuffManager.HasElement(BuffNames.Drowning))
                {
                    listr.Add(SimDescription.DeathType.Drown);

                    if (GameUtils.IsInstalled(ProductVersion.EP10))
                    {
                        listr.Add(SimDescription.DeathType.ScubaDrown);
                        listr.Add(SimDescription.DeathType.Shark);
                    }
                }
                else if (target.BuffManager.HasElement(BuffNames.OnFire))
                {
                    listr.Add(SimDescription.DeathType.Burn);

                    if (GameUtils.IsInstalled(ProductVersion.EP2))
                        listr.Add(SimDescription.DeathType.Meteor);
                }
                else if (target.CurrentOutfitCategory == OutfitCategories.Singed || target.BuffManager.HasElement(BuffNames.SingedElectricity))
                {
                    listr.Add(SimDescription.DeathType.Electrocution);
                }
                else if (target.SimDescription.Elder)
                {
                    if (!target.IsPet)
                        listr.Add(SimDescription.DeathType.OldAge);

                    else
                    {
                        listr.Add(SimDescription.DeathType.PetOldAgeGood);
                        listr.Add(SimDescription.DeathType.PetOldAgeBad);
                    }

                }
                else
                {
                    listr.Add(SimDescription.DeathType.Starve);
                    listr.Add(SimDescription.DeathType.Burn);

                    if (GameUtils.IsInstalled(ProductVersion.EP10) && target.Motives.IsSleepy())
                        listr.Add(SimDescription.DeathType.MermaidDehydrated);
                }
                return Sims3.Gameplay.Core.RandomUtil.GetRandomObjectFromList(listr);
            }
            catch
            {
                return SimDescription.DeathType.Starve;
            }
        }



        /*
        public static void FixIsCrib(Sim target)
        {

        }
        */


        public static readonly string NL = System.Environment.NewLine;

        public static InteractionDefinition NiecS3Mod_PauseNiecIns_Definition_Singleton = null;

        public static Type T_NiecS3Mod_PauseNiecIns = null;

        public static void CacheNiecS3Mod() {
            if (AssemblyCheckByNiec.IsInstalled("NiecS3Mod"))
            {
                Type niecs3Type = Type.GetType("NiecS3Mod.PauseNiecIns,NiecS3Mod", false);
                if (niecs3Type != null)
                {
                    T_NiecS3Mod_PauseNiecIns = niecs3Type;
                    FieldInfo fi = niecs3Type.GetField("Singleton", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (fi != null)
                    {
                        NiecS3Mod_PauseNiecIns_Definition_Singleton = fi.GetValue(null) as InteractionDefinition;
                    }
                }
            }
        }


        public static bool MineKill(Sim target, SimDescription.DeathType deathType, GameObject obj, bool playDeathAnim, bool sleepyes, bool wasisCrib)
        {
            if (target == null) { StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Note: " + NL + "target is Cannot be null.", StyledNotification.NotificationStyle.kGameMessagePositive)); return false; }

            if (deathType == SimDescription.DeathType.None) deathType = GetDeathType(target);






            bool householdisActive = NFinalizeDeath.IsAllActiveHousehold_SimObject(target); //target.IsInActiveHousehold ||  NiecMod.Nra.NFinalizeDeath.IsSimFastActiveHousehold(target);

            bool asscheckDGSCore = AssemblyCheckByNiec.IsInstalled("OpenDGS");

            bool checkkillsimcrach = false;
            
            bool canBeKilled = NFinalizeDeath.IsCanBeKilled(target); //CanBeKilledInternal(target);


            try
            {
                if (NTunable.kEACanBeKilledExByNiecNotification && asscheckDGSCore)
                {
                    if (KillSimNiecX.EACanBeKilledExByNiec(target))
                    {
                        StyledNotification.Show(new StyledNotification.Format("MineKill: Found, " + target.Name + " Check EA CanBeKilled is OK", StyledNotification.NotificationStyle.kGameMessagePositive));
                    }
                    else 
                    {
                        StyledNotification.Show(new StyledNotification.Format("MineKill: Found, " + target.Name + " Check EA CanBeKilled is Failed", StyledNotification.NotificationStyle.kGameMessagePositive));
                    }
                }
            }
            catch
            { }






            try
            {
                if (GameStates.IsGameShuttingDown) return true;
                if (Sims3.UI.Responder.Instance.IsGameStateShuttingDown) return true;

                try
                {
                    if (!asscheckDGSCore && !target.IsInActiveHousehold && deathType == SimDescription.DeathType.Ranting && target.SimDescription.IsHuman)
                    {
                        deathType = SimDescription.DeathType.Electrocution;
                    }
                }
                catch
                { }


                if (deathType == SimDescription.DeathType.PetOldAgeBad || deathType == SimDescription.DeathType.PetOldAgeGood)
                {
                    if (target.SimDescription.IsHuman)
                    {
                        switch (deathType)
                        {
                            case SimDescription.DeathType.PetOldAgeBad:
                            case SimDescription.DeathType.PetOldAgeGood:
                                deathType = SimDescription.DeathType.OldAge;
                                break;
                        }
                    }
                }
            }
            catch
            { }

            



            try
            {
                // Fix Crach Game Why?
                // sim is Destroyed

                if (!target.InWorld)
                {
                    target.AddToWorld();
                }

                Sim simes = target.SimDescription.CreatedSim;
                if (simes == null || target.HasBeenDestroyed)
                {

                    

                    Vector3 pos = Vector3.OutOfWorld;
                    checkkillsimcrach = true;
                    ResourceKey outfitKey = target.SimDescription.mDefaultOutfitKey;
                    try
                    {
                        if ((PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null))
                        {
                            World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position);
                            fglParams.InitialSearchDirection = RandomUtil.GetInt(0, 7);
                            Vector3 vector;
                            if (!GlobalFunctions.FindGoodLocation(PlumbBob.Singleton.mSelectedActor, fglParams, out pos, out vector))
                            {
                                pos = PlumbBob.Singleton.mSelectedActor.Position;
                            }
                        }
                    }
                    catch
                    { }
                    Sim fixsim = target.SimDescription.Instantiate(pos, outfitKey, false, true);
                    if (fixsim == null)
                    {
                        StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note: " + NL + "Failed Instantiate In Fix Crash Game", StyledNotification.NotificationStyle.kGameMessagePositive));
                        return false;
                    }
                    target = fixsim;
                    NiecMod.Nra.SpeedTrap.Sleep();
                }
            }
            catch
            { }


            try
            {
                if (!asscheckDGSCore && target.IsPet)
                {
                    bool sata = target.IsInActiveHousehold;
                    if (target.InteractionQueue == null)
                    {
                        if (target.SimDescription.IsPregnant)
                        {
                            target.SimDescription.Pregnancy.ClearPregnancyData();
                            if (target.SimDescription.Pregnancy == null)
                            {
                                StyledNotification.Show(new StyledNotification.Format(target.Name + "OK Clear Pregnancy Data", StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                            else
                            {
                                StyledNotification.Show(new StyledNotification.Format("Failed Clear Pregnancy Data", StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                        }
                        try
                        {
                            StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note:" + NL + " Wait Move Inventory Items To A Family Member", StyledNotification.NotificationStyle.kGameMessagePositive));
                            target.MoveInventoryItemsToAFamilyMember();
                        }
                        catch
                        { }
                        SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                        return true;
                    }
                    if (!canBeKilled) return false;
                    if (target.SimDescription.IsPregnant && !sata)
                    {
                        target.SimDescription.Pregnancy.ClearPregnancyData();
                        if (target.SimDescription.Pregnancy == null)
                        {
                            StyledNotification.Show(new StyledNotification.Format(target.Name + "OK Clear Pregnancy Data", StyledNotification.NotificationStyle.kGameMessagePositive));
                        }
                        else
                        {
                            StyledNotification.Show(new StyledNotification.Format("Failed Clear Pregnancy Data", StyledNotification.NotificationStyle.kGameMessagePositive));
                        }
                    }
                    if (deathType == SimDescription.DeathType.Electrocution && obj != null)
                    {
                        PetStartleBehavior.CheckForStartle(target, StartleType.Electrocution);
                    }
                    if (Passport.IsPassportSim(target.SimDescription))
                    {
                        if (!Passport.Instance.IsHostedSim(target.SimDescription) && target.SimDescription.mSenderNucleusID == SocialFeatures.Accounts.GetID())
                        {
                            SocialFeatures.Passport.CancelPassport(target.SimDescription.mStoredSlot);
                            Passport.HouseholdSimDied(target.SimDescription);
                        }
                    }
                    else
                    {
                        Passport.HouseholdSimDied(target.SimDescription);
                    }
                    if (target.SimDescription.mReturnSimAlarm != AlarmHandle.kInvalidHandle)
                    {
                        AlarmManager.Global.RemoveAlarm(target.SimDescription.mReturnSimAlarm);
                        target.SimDescription.mReturnSimAlarm = AlarmHandle.kInvalidHandle;
                    }
                    if (sata)
                    {
                        var killSim = Urnstone.KillSim.Singleton.CreateInstance(target, target, new InteractionPriority(InteractionPriorityLevel.MaxDeath, 0f), false, true) as Urnstone.KillSim;
                        killSim.simDeathType = deathType;
                        killSim.PlayDeathAnimation = playDeathAnim;
                        target.InteractionQueue.Add(killSim);
                    }
                    else
                    {

                        try
                        {

                            HelperNra helperNra = new HelperNra();

                             

                            helperNra.mSim = target;

                            helperNra.mSimdesc = target.SimDescription;

                            helperNra.mdeathtype = deathType;

                            helperNra.this_alarm = AlarmManager.Global.AddAlarm(1f, TimeUnit.Days, new AlarmTimerCallback(helperNra.CheckKillSimNotUrnstonePro), "MineKillCheckKillSim Name " + target.SimDescription.LastName, AlarmType.AlwaysPersisted, null);



                        }
                        catch (Exception exception)
                        { NiecException.WriteLog("helperNra " + NiecException.NewLine + NiecException.LogException(exception), true, true, false); }

                        var killSim = Urnstone.KillSim.Singleton.CreateInstance(target, target, new InteractionPriority(InteractionPriorityLevel.MaxDeath, 0f), false, false) as Urnstone.KillSim;
                        killSim.simDeathType = deathType;
                        killSim.PlayDeathAnimation = playDeathAnim;
                        target.InteractionQueue.Add(killSim);
                    }

                    if (GameUtils.IsInstalled(ProductVersion.EP10))
                    {
                        foreach (object objx in LotManager.AllLots)
                        {
                            Lot lot = (Lot)objx;
                            if (lot.CommercialLotSubType == CommercialLotSubType.kEP10_Resort)
                            {
                                lot.ResortManager.CheckOutSim(target);
                            }
                        }
                    }
                    return true;
                }
            }
            catch
            { }


            
            // Start
            try
            {
                if (!canBeKilled)
                {
                    if (deathType == SimDescription.DeathType.OldAge && !target.SimDescription.IsEP11Bot && target.SimDescription.Elder)
                    {
                        target.SimDescription.AgingState.ResetAndExtendAgingStage(0f);
                    }

                    target.FadeIn();

                    if (NTunable.kDedugNotificationCheckNiecKill)
                    {
                        StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "CanBeKilled is False Sorry,", StyledNotification.NotificationStyle.kGameMessagePositive));
                    }

                    if (checkkillsimcrach)
                    {
                        Sim.MakeSimGoHome(target, true);
                    }
                    return false;
                }
                

                else
                {


                    // DGS: ... 
                    // Too Many Add Interaction Toddler InCrib Fix

                    try
                    {



                        try
                        {
                            if (NTunable.kDedugNiecModExceptionMineKill)
                            {
                                throw new NiecModException("MineKill: Not Error");
                            }
                        }
                        catch (NiecModException eex)
                        {
                            if (NTunable.kDedugNiecModExceptionMineKill)
                            {
                                NiecException.PrintMessage(eex.Message + NiecException.NewLine + eex.StackTrace);
                                NiecException.WriteLog("Dedug Exception MineKill" + NiecException.NewLine + NiecException.LogException(eex), true, true, false);
                            }
                        }





                        if (asscheckDGSCore || wasisCrib || (target.SimDescription.Age == CASAgeGenderFlags.Toddler || target.SimDescription.Age == CASAgeGenderFlags.Baby))
                        {
                            Sim asdta = null;
                            ulong newidsimdsc = 0L;
                            SimDescription simdescfixllop = null;
                            ICrib crib = target.Posture.Container as ICrib;
                            if (wasisCrib || (target.Posture.Satisfies(CommodityKind.InCrib, null) || crib != null || (target.mPosture is HighChairBase.InChairPosture) || (target.mPosture is RidingPosture) || (target.mPosture is BeingRiddenPosture)))
                            {



                                newidsimdsc = target.SimDescription.SimDescriptionId;
                                try
                                {
                                    NFinalizeDeath.ForceCancelAllInteractionsPro(target);
                                }
                                catch
                                { }
                                try
                                {
                                    target.SetObjectToReset();
                                }
                                catch (Exception errer)
                                {
                                    if (errer is ResetException)
                                    {
                                        try
                                        {
                                            throw new NiecModException("Only assignment, call, increment, decrement, and new object expressions can be used as a statement.", errer);
                                        }
                                        catch (NiecModException)
                                        {
                                            StyledNotification.Show(new StyledNotification.Format("MineKill ResetException" + NL + "Note: " + NL + "SetObjectToReset", StyledNotification.NotificationStyle.kGameMessagePositive));
                                            NiecException.WriteLog("MineKill ResetException In SetObjectToReset" + NiecException.NewLine + NiecException.LogException(errer), true, true, false);
                                        }
                                        
                                    }
                                    else
                                    {
                                        StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Note: " + NL + "Failed SetObjectToReset", StyledNotification.NotificationStyle.kGameMessagePositive));
                                        NiecException.WriteLog("MineKill In SetObjectToReset" + NiecException.NewLine + NiecException.LogException(errer), true, true, false);
                                    }
                                }

                                if (Simulator.CheckYieldingContext(false)) { NiecMod.Nra.SpeedTrap.Sleep(); }

                                simdescfixllop = SimDescription.Find(newidsimdsc);

                                if (simdescfixllop == null)
                                {
                                    foreach (SimDescription iatem in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                                    {
                                        if (iatem == null) continue;
                                        if (iatem.SimDescriptionId == newidsimdsc)
                                        {
                                            simdescfixllop = iatem;
                                            break;
                                        }
                                    }
                                }

                                if (Simulator.CheckYieldingContext(false)) { NiecMod.Nra.SpeedTrap.Sleep(); }

                                if (simdescfixllop == null)
                                {
                                    
                                    StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note: " + NL + "Failed simdescfixllop is null", StyledNotification.NotificationStyle.kGameMessagePositive));
                                    return false;
                                }
                                else
                                {
                                    if (simdescfixllop.CreatedSim ==  null)
                                    {
                                        Vector3 vector;
                                        Vector3 pos = Vector3.OutOfWorld;
                                        ResourceKey outfitKey = simdescfixllop.mDefaultOutfitKey;
                                        try
                                        {
                                            if ((PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null))
                                            {
                                                World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position);
                                                fglParams.InitialSearchDirection = RandomUtil.GetInt(0, 7);

                                                if (!GlobalFunctions.FindGoodLocation(simdescfixllop.LotHome, fglParams, out pos, out vector))
                                                {
                                                    pos = PlumbBob.Singleton.mSelectedActor.Position;
                                                }
                                            }
                                            else if (simdescfixllop.LotHome != null)
                                            {
                                                World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(simdescfixllop.LotHome.Position);
                                                fglParams.InitialSearchDirection = RandomUtil.GetInt(0, 7);

                                                if (!GlobalFunctions.FindGoodLocation(simdescfixllop.LotHome, fglParams, out pos, out vector))
                                                {
                                                    pos = simdescfixllop.LotHome.Position;
                                                }
                                            }
                                        }
                                        catch
                                        { }
                                        asdta = simdescfixllop.Instantiate(pos, outfitKey, false, false);
                                        if (asdta == null)
                                        {
                                            StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + "???" + NL + "Note: " + NL + "Failed Instantiate InCrib", StyledNotification.NotificationStyle.kGameMessagePositive));
                                            return false;
                                        }
                                        if (Simulator.CheckYieldingContext(false)) { NiecMod.Nra.SpeedTrap.Sleep(); }
                                    }
                                    if (simdescfixllop.CreatedSim != null && !simdescfixllop.CreatedSim.HasBeenDestroyed)
                                    {
                                        target = simdescfixllop.CreatedSim;
                                    }
                                    else if (asdta != null)
                                    {
                                        target = asdta;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception errer)
                    {
                        NiecException.WriteLog("MineKill In Crib" + NiecException.NewLine + NiecException.LogException(errer), true, true, false);
                    }


                    // Start Add Interaction
                    try
                    {
                        // Active Household
                        if (target.IsInActiveHousehold || householdisActive)
                        {
                            try
                            {
                                ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                            }
                            catch
                            {
                                try
                                {
                                    ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                                }
                                catch
                                { }
                            }

                            try
                            {
                                StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "DeathType: " + deathType.ToString(), StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                            catch
                            { }


                            ExtKillSimNiec killSim = ExtKillSimNiec.Singleton.CreateInstance(target, target, KillSimNiecX.DGSAndNonDGSPriority(), false, true) as ExtKillSimNiec;
                            killSim.simDeathType = deathType;
                            killSim.PlayDeathAnimation = playDeathAnim;
                            killSim.MustRun = false;

                            try
                            {
                                killSim.mForceKillGrim = (target.Service is GrimReaper);
                            }
                            catch
                            { }

                            try
                            {

                                if (target.Household != null)
                                {
                                    killSim.homehome = target.Household;
                                }

                            }
                            catch
                            { }


                            //killSim.sWasIsActiveHousehold = (NFinalizeDeath.IsSimFastActiveHousehold(target));
                            killSim.sWasIsActiveHousehold = (NFinalizeDeath.IsSimFastActiveHousehold(target) || target.IsInActiveHousehold || householdisActive);

                            try
                            {
                                killSim.WhatSimsCount = NFinalizeDeath.ActiveHousehold.AllActors.Count;
                            }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }
                            

                            target.InteractionQueue.AddNext(killSim);


                            try
                            {
                                if (!target.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton))
                                {
                                    target.InteractionQueue.Add(killSim);
                                }
                            }
                            catch
                            { }

                            return true;
                        }
                        // Non Active Household
                        else
                        {
                            
                            try
                            {
                                if (target.SimDescription.CreatedSim == null || target.HasBeenDestroyed)
                                {
                                    ResourceKey outfitKey = target.SimDescription.mDefaultOutfitKey;


                                    target.SimDescription.Instantiate(Vector3.OutOfWorld, outfitKey, false, true);
                                }
                            }
                            catch (Exception trtyr)
                            { NiecException.WriteLog("Instantiate " + NiecException.NewLine + NiecException.LogException(trtyr), true, true, false); }


                            try
                            {
                                target.EnableInteractions();
                            }
                            catch (Exception)
                            { }

                            /////////////////////////////////////////////////////

                            bool CheckAntiCancel = false;

                            if (AssemblyCheckByNiec.IsInstalled("NiecS3Mod"))
                            {
                                try
                                {
                                    if (target.InteractionQueue.HasInteractionOfType(NiecS3Mod_PauseNiecIns_Definition_Singleton))
                                    {
                                        CheckAntiCancel = true;
                                    }
                                    if (!CheckAntiCancel)
                                    {
                                        foreach (InteractionInstance interactionInstance in target.InteractionQueue.InteractionList)
                                        {
                                            if (interactionInstance == null) 
                                                continue;
                                            if (interactionInstance.GetType() == T_NiecS3Mod_PauseNiecIns)
                                            {
                                                CheckAntiCancel = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch
                                { }

                            }

                            if (!CheckAntiCancel)
                            {
                                try
                                {
                                    if (target.InteractionQueue.HasInteractionOfType(AllPauseNiecDone.Singleton))
                                    {
                                        CheckAntiCancel = true;
                                    }
                                    if (!CheckAntiCancel)
                                    {
                                        foreach (InteractionInstance interactionInstance in target.InteractionQueue.InteractionList)
                                        {
                                            if (interactionInstance is AllPauseNiecDone)
                                            {
                                                CheckAntiCancel = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                catch 
                                { }
                            }


                            ///////////////////////////////////////////////////

                            if (CheckAntiCancel)
                            {
                                try
                                {
                                    StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "DeathType: " + deathType.ToString(), StyledNotification.NotificationStyle.kGameMessagePositive));
                                }
                                catch
                                { }

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
                                
                                try
                                {
                                    StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note:" + NL + "Wait Move Inventory Items To A Family Member", StyledNotification.NotificationStyle.kGameMessagePositive));
                                    target.MoveInventoryItemsToAFamilyMember();
                                }
                                catch
                                { }




                                try
                                {
                                    /*
                                    target.SimDescription.IsGhost = true;
                                    target.SimDescription.SetDeathStyle(deathType, false);
                                    ExtKillSimNiec.ListMorunExtKillSim(target, deathType);
                                    NFinalizeDeath.FinalizeSimDeathRelationships(target.SimDescription, 0);

                                     */


                                    try
                                    {
                                        target.Household.Remove(target.SimDescription);
                                    }
                                    catch (Exception)
                                    { }
                                    target.SimDescription.IsGhost = true;
                                    target.SimDescription.mDeathStyle = deathType; //(deathType, false);




                                    if (NFinalizeDeath.GetKillNPCSimToGhost(target, deathType)) return true;
                                    else SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, false, false);





                                }
                                catch
                                {
                                    //Urnstones.CreateGrave(target.SimDescription, deathType, true, false);
                                    StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note: " + NL + "Found CheckAntiCancel Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                }
                                finally
                                {
                                    //Urnstones.CreateGrave(target.SimDescription, deathType, true, false);
                                    StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note: " + NL + "Found CheckAntiCancel Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                }
                                return true;
                            }

                            


                            try
                            {
                                if (target.SimDescription.mReturnSimAlarm != AlarmHandle.kInvalidHandle)
                                {
                                    AlarmManager.Global.RemoveAlarm(target.SimDescription.mReturnSimAlarm);
                                    target.SimDescription.mReturnSimAlarm = AlarmHandle.kInvalidHandle;
                                }
                            }
                            catch (Exception passportaaata)
                            { NiecException.WriteLog("MineKill AlarmManager: " + NiecException.NewLine + NiecException.LogException(passportaaata), true, false, false); }

                            //if (!(NFinalizeDeath.IsSimFastActiveHousehold(target) || target.IsInActiveHousehold))
                            if (!NFinalizeDeath.IsAllActiveHousehold_SimObject(target))
                            {
                                try
                                {

                                    HelperNra helperNra = new HelperNra();



                                    helperNra.mSim = target;

                                    helperNra.mSimdesc = target.SimDescription;

                                    helperNra.mdeathtype = deathType;

                                    helperNra.this_alarm = AlarmManager.Global.AddAlarm(1f, TimeUnit.Days, new AlarmTimerCallback(helperNra.CheckKillSimNotUrnstonePro), "MineKillCheckKillSim Name " + target.SimDescription.LastName, AlarmType.AlwaysPersisted, null);



                                }
                                catch (Exception exception)
                                { NiecException.WriteLog("helperNra " + NiecException.NewLine + NiecException.LogException(exception), true, true, false); }

                            }

                            try
                            {
                                StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "DeathType: " + deathType.ToString(), StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                            catch
                            { }

                            try
                            {
                                StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note:" + NL + "Wait Move Inventory Items To A Family Member", StyledNotification.NotificationStyle.kGameMessagePositive));
                                target.MoveInventoryItemsToAFamilyMember();
                            }
                            catch (NullReferenceException)
                            {
                            }

                           
                            StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note:" + NL + "Wait Add Interaction", StyledNotification.NotificationStyle.kGameMessagePositive));

                            if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            {
                                try
                                {
                                    ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                                }
                                catch
                                {
                                    try
                                    {
                                        ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                                    }
                                    catch
                                    { }
                                }
                                Simulator.Sleep(0);
                                try
                                {
                                    ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                                }
                                catch
                                {
                                    try
                                    {
                                        ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                                    }
                                    catch
                                    { }
                                }

                                try
                                {
                                    //target.InteractionQueue.CancelAllInteractions();
                                    NFinalizeDeath.ForceCancelAllInteractionsProPartA(target);
                                }
                                catch
                                {
                                    try
                                    {
                                        //target.InteractionQueue.CancelAllInteractions();
                                        NFinalizeDeath.ForceCancelAllInteractionsProPartA(target);
                                    }
                                    catch
                                    { }
                                }
                                Simulator.Sleep(0);
                                try
                                {
                                    if (asscheckDGSCore) // Anti-CallCallbackOnFailure NPC Only
                                    {
                                        var clla = CCnlean.Singleton.CreateInstance(target, target, new InteractionPriority((InteractionPriorityLevel)100, 0f), false, true) as CCnlean;
                                        clla.MustRun = false;
                                        clla.Hidden = false;
                                        target.InteractionQueue.AddNextIfPossibleAfterCheckingForDuplicates(clla);
                                    }
                                }
                                catch (StackOverflowException)
                                {
                                    throw;
                                }
                                catch (OutOfMemoryException)
                                {
                                    throw;
                                }
                                catch (ResetException) { throw; }
                                catch (ApplicationException)
                                { }
                                Simulator.Sleep(0);
                                try
                                {
                                    ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                                }
                                catch
                                {
                                    try
                                    {
                                        ExtKillSimNiec.CheckCancelListInteractionByNiec(target);
                                    }
                                    catch
                                    { }
                                }



                                try
                                {
                                    //target.InteractionQueue.CancelAllInteractions();
                                    NFinalizeDeath.ForceCancelAllInteractionsProPartA(target);
                                }

                                catch (Exception)
                                {
                                    try
                                    {
                                        //target.InteractionQueue.CancelAllInteractions();
                                        NFinalizeDeath.ForceCancelAllInteractionsProPartA(target);
                                        //NFinalizeDeath.ForceCancelAllInteractionsPro(target);
                                    }

                                    catch (Exception)
                                    { }
                                }
                                Simulator.Sleep(0);
                            }
                            else {
                                NFinalizeDeath.FastProCancel(target);
                            }
                            try
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
                            catch (ResetException) { throw; }
                            catch (NullReferenceException)
                            { }


                            try
                            {
                                if (deathType == SimDescription.DeathType.Electrocution && obj != null)
                                {
                                    PetStartleBehavior.CheckForStartle(obj, StartleType.Electrocution);
                                }
                            }
                            catch (ResetException) { throw; }
                            catch (Exception caheckForStartle)
                            { NiecException.WriteLog("MineKill PetStartleBehavior: " + NiecException.NewLine + NiecException.LogException(caheckForStartle), true, false, false); }

                            try
                            {
                                if (Passport.IsPassportSim(target.SimDescription))
                                {
                                    if (!Passport.Instance.IsHostedSim(target.SimDescription) && target.SimDescription.mSenderNucleusID == SocialFeatures.Accounts.GetID())
                                    {
                                        SocialFeatures.Passport.CancelPassport(target.SimDescription.mStoredSlot);
                                        Passport.HouseholdSimDied(target.SimDescription);
                                    }
                                }
                                else
                                {
                                    Passport.HouseholdSimDied(target.SimDescription);
                                }
                            }
                            catch (ResetException) { throw; }
                            catch (Exception passportaaaa)
                            { NiecException.WriteLog("MineKill Passport: " + NiecException.NewLine + NiecException.LogException(passportaaaa), true, false, false); }




                            
                            try
                            {
                                ExtKillSimNiec killSim = ExtKillSimNiec.Singleton.CreateInstance(target, target, KillSimNiecX.DGSAndNonDGSPriority(), false, false) as ExtKillSimNiec;
                                killSim.simDeathType = deathType;
                                killSim.PlayDeathAnimation = playDeathAnim;
                                killSim.MustRun = true;
                                killSim.Hidden = true;

                                try
                                {
                                    killSim.mForceKillGrim = (target.Service is GrimReaper);
                                }
                                catch
                                { }

                                try
                                {

                                    if (target.Household != null)
                                    {
                                        killSim.homehome = target.Household;
                                    }

                                }
                                catch
                                { }
                                target.InteractionQueue.AddNextIfPossibleAfterCheckingForDuplicates(killSim);
                            }
                            catch (StackOverflowException)
                            {
                                throw;
                            }
                            catch (OutOfMemoryException)
                            {
                                throw;
                            }
                            catch (ResetException) { throw; }
                            catch (ApplicationException)
                            { }


                            try
                            {
                                if (!target.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton))
                                {
                                    
                                    var killSim2 = ExtKillSimNiec.Singleton.CreateInstance(target, target, KillSimNiecX.DGSAndNonDGSPriority(), false, false) as ExtKillSimNiec;
                                    killSim2.simDeathType = deathType;
                                    killSim2.PlayDeathAnimation = playDeathAnim;
                                    killSim2.MustRun = true;
                                    killSim2.Hidden = true;
                                    
                                    try
                                    {
                                        killSim2.mForceKillGrim = (target.Service is GrimReaper);
                                        
                                    }
                                    catch
                                    { }

                                    try
                                    {
                                        if (target.Household != null) 
                                        {
                                            killSim2.homehome = target.Household;
                                        }

                                    }
                                    catch
                                    { }

                                    killSim2.sWasIsActiveHousehold = (NFinalizeDeath.IsSimFastActiveHousehold(target) || target.IsInActiveHousehold || householdisActive);

                                    try
                                    {
                                        killSim2.WhatSimsCount = NFinalizeDeath.ActiveHousehold.AllActors.Count;
                                    }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }

                                    target.InteractionQueue.AddAfterCheckingForDuplicates(killSim2);
                                }
                            }
                            catch (StackOverflowException)
                            {
                                throw;
                            }
                            catch (OutOfMemoryException)
                            {
                                throw;
                            }
                            catch (ResetException) { throw; }
                            catch (ApplicationException)
                            { }


                            

                            if (target.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton))
                            {
                                StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note: " + NL + "Done Added Interaction", StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                            else
                            {
                                if (AcceptCancelDialog.Show("MineKill: Failed! Add Interaction do you want Force Kill? (Yes Run or No Cancel)", true))
                                {
                                    try
                                    {
                                        StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + NL + "Note:" + NL + "Wait Move Inventory Items To A Family Member", StyledNotification.NotificationStyle.kGameMessagePositive));
                                        target.MoveInventoryItemsToAFamilyMember();
                                    }
                                    catch (Exception)
                                    { }
                                    
                                    StyledNotification.Show(new StyledNotification.Format("MineKill" + NL + "Name: " + target.Name + " is Died", StyledNotification.NotificationStyle.kGameMessagePositive));
                                    try
                                    {

                                        if (target.SimDescription.Household != null)
                                        {
                                            ExtKillSimNiec.ListMorunExtKillSim(target, deathType);
                                        }
                                        NFinalizeDeath.FinalizeSimDeathRelationships(target.SimDescription, 0);

                                    }
                                    catch (Exception)
                                    {
                                        SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                                        StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Failed To Catch Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                        return false;
                                    }
                                    finally
                                    {
                                        SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                                        StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Done To Finally Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                    }
                                    return false;
                                }
                                StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Add Interaction Failed", StyledNotification.NotificationStyle.kGameMessagePositive));
                                return false;
                            }
                            
                            try
                            {
                                if (GameUtils.IsInstalled(ProductVersion.EP10))
                                {
                                    foreach (object objx in LotManager.AllLots)
                                    {
                                        Lot lot = (Lot)objx;
                                        if (lot.CommercialLotSubType == CommercialLotSubType.kEP10_Resort)
                                        {
                                            lot.ResortManager.CheckOutSim(target);
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            { }

                            return true;
                        }
                    }
                    
                    catch (StackOverflowException)
                    {
                        return false;
                    }
                    catch (OutOfMemoryException)
                    {
                        return false;
                    }
                    catch (ResetException)
                    {
                        //if (NFinalizeDeath.IsSimFastActiveHousehold(target) || target.IsInActiveHousehold) //(target.IsInActiveHousehold)
                        if (NFinalizeDeath.IsAllActiveHousehold_SimObject(target))
                        {
                            StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Failed Error: ", StyledNotification.NotificationStyle.kGameMessagePositive));
                            throw;
                        }
                        else
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
                            
                            try
                            {
                                StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Wait Move Inventory Items To A Family Member", StyledNotification.NotificationStyle.kGameMessagePositive));
                                target.MoveInventoryItemsToAFamilyMember();
                            }
                            catch (NullReferenceException)
                            {
                            }
                            target.SimDescription.SetDeathStyle(deathType, false);

                            try
                            {
                                //Found System.NullReferenceException: A null value was found where an object instance was required. Fixed Bug No Household :) 

                                ExtKillSimNiec.ListMorunExtKillSim(target, deathType);
                                NFinalizeDeath.FinalizeSimDeathRelationships(target.SimDescription, 0);

                            }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            {
                                SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                                StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Failed To Catch Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                            finally
                            {
                                SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                                StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Done To Finally Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                            }
                        }
                        throw;
                    }
                    
                    catch (Exception exception)
                    {
                        try
                        {
                            NiecException.WriteLog("MineKill " + NiecException.NewLine + NiecException.LogException(exception), true, true, false);

                            //if (NFinalizeDeath.IsSimFastActiveHousehold(target) || target.IsInActiveHousehold)//(target.IsInActiveHousehold)
                            if (NFinalizeDeath.IsAllActiveHousehold_SimObject(target))
                            {
                                StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Failed Error: " + exception.Message, StyledNotification.NotificationStyle.kGameMessagePositive));
                                return false;
                            }
                            else
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
                                
                                try
                                {
                                    StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Wait Move Inventory Items To A Family Member", StyledNotification.NotificationStyle.kGameMessagePositive));
                                    target.MoveInventoryItemsToAFamilyMember();
                                }
                                catch (ResetException) { throw; }
                                catch (NullReferenceException)
                                {
                                }

                                target.SimDescription.SetDeathStyle(deathType, false);

                                try
                                {
                                    
                                    ExtKillSimNiec.ListMorunExtKillSim(target, deathType);
                                    NFinalizeDeath.FinalizeSimDeathRelationships(target.SimDescription, 0);

                                }
                                catch (ResetException) { throw; }
                                catch (Exception)
                                {
                                    SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                                    StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Failed To Catch Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                    return true;
                                }
                                finally
                                {
                                    SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                                    StyledNotification.Show(new StyledNotification.Format("MineKill: " + target.Name + " Done To Finally Run Force Kill :)", StyledNotification.NotificationStyle.kGameMessagePositive));
                                }
                            }
                            return true;
                        }
                        catch (ResetException) { throw; }
                        catch (Exception exception2Failed)
                        {
                            StyledNotification.Show(new StyledNotification.Format("MineKill Failed Again: " + target.Name + " Error: " + exception2Failed.Message, StyledNotification.NotificationStyle.kGameMessagePositive));
                            NiecException.WriteLog("MineKill Failed Again: " + NiecException.NewLine + NiecException.LogException(exception2Failed), true, true, false);
                            try
                            {

                                target.SimDescription.SetDeathStyle(deathType, false);
                                try
                                {
                                    ExtKillSimNiec.ListMorunExtKillSim(target, deathType);
                                    NFinalizeDeath.FinalizeSimDeathRelationships(target.SimDescription, 0);
                                }
                                finally
                                {
                                    SafeNRaas.NRUrnstones_CreateGrave(target.SimDescription, deathType, true, false);
                                }
                            }
                            catch (Exception exception3FailedAgain)
                            { 
                                try
                                {
                                    NiecException.WriteLog("MineKill Failed Again Again!: " + NiecException.NewLine + NiecException.LogException(exception3FailedAgain), true, true, false);
                                    //if (NFinalizeDeath.IsSimFastActiveHousehold(target)) return false;
                                    if (NFinalizeDeath.IsAllActiveHousehold_SimObject(target)) return false;
                                    if (PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null && target == PlumbBob.sSingleton.mSelectedActor)
                                    {
                                        LotManager.SelectNextSim();
                                    }
                                    SimDescription taroa = target.SimDescription;
                                    try
                                    {
                                        taroa.mDeathStyle = deathType;
                                    }
                                    catch (Exception)
                                    { }
                                    Urnstone mGravebackup = Urnstone.CreateGrave(taroa, false, true);
                                    if (mGravebackup != null)
                                    {
                                        
                                        try
                                        {
                                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(target);
                                            target.Destroy();
                                            SpeedTrap.Sleep();
                                        }
                                        catch (Exception)
                                        { }
                                        Sim ah = NFinalizeDeath.ActiveActor;
                                        if (ah != null && NFinalizeDeath.MyActiveActor(ah.SimDescription))
                                            mGravebackup.SetPosition(ah.Position);
                                        else if (ah != null && ah.LotHome != null)
                                            mGravebackup.SetPosition(ah.Position);
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
                                        return true;
                                    }
                                    else throw new NotSupportedException("Create Failed.");
                                }
                                catch (Exception rtyry)
                                {
                                    SimDescription asota = target.mSimDescription;
                                    try
                                    {
                                        NiecMod.Helpers.Create.NiecNullSimDescription();
                                        target.mSimDescription = Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription;
                                        asota.mSim = null;
                                    }
                                    catch
                                    { }
                                   
                                    
                                    NFinalizeDeath.ForceDestroyObject(target);
                                    NiecException.WriteLog("MineKill Failed Again Again Again!: " + NiecException.NewLine + NiecException.LogException(rtyry), true, true, false);
                                    return NFinalizeDeath.SimDescCleanse(asota, true, false);
                                }
                            }
                            return false;
                        }
                    }
                }
            }
            catch (ResetException) { throw; }
            catch
            { }
            
            return false;
        }















































        private static bool CanBeKilledInternal(Sim targetSim)
        {
            if (targetSim == null)  return false;
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
                    catch (ResetException)
                    {
                        throw;
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
                    catch (ResetException)
                    {
                        throw;
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
                    try
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
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    { }
                    
                }
                if (targetSim.Service is GrimReaper && !AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    if (!Simulator.CheckYieldingContext(false)) return false;
                    if (!AcceptCancelDialog.Show("CanBeKilledInternal: Killing the " + targetSim.Name + " [GrimReaper] will prevent souls to cross over to the other side. If this happens, Sims that die from now on will be trapped between this world and the next, and you'll end up with a city full of dead bodies laying around. Are you sure you want to kill Death itself?", true))
                    {
                        return false;
                    }
                }
            }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                NiecException.PrintMessage(ex.Message + " " + ex.StackTrace);
                if (!Simulator.CheckYieldingContext(false)) return false;
                if (!AcceptCancelDialog.Show("CanBeKilledInternal: Name (" + targetSim.Name + ") Found Error (" + ex.Message + ") Do want you run? [Yes Run or No Cancel]", true))
                {
                    return false;
                }
            }
            

            return true;
        }




        public static bool DGSIsCrib(Sim targetSim)
        {
            if (targetSim == null) return false;
            try
            {
                // DGS: ... 
                // Too Many Add Interaction Toddler InCrib Fix
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS") || targetSim.SimDescription.Age == CASAgeGenderFlags.Toddler || targetSim.SimDescription.Age == CASAgeGenderFlags.Baby)
                {
                    if (targetSim.Posture != null)
                    {
                        ICrib crib = targetSim.Posture.Container as ICrib;
                        if (targetSim.Posture.Satisfies(CommodityKind.InCrib, null) || crib != null || (targetSim.mPosture is HighChairBase.InChairPosture) || (targetSim.mPosture is RidingPosture) || (targetSim.mPosture is BeingRiddenPosture))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (ResetException) { throw; }
            catch
            { }
            return false;
        }

        
        public static bool CanBeKilled(Sim targetSim, out bool outInCrib)
        {
            outInCrib = false;
            if (targetSim == null || targetSim.SimDescription == null) return false;
            try
            {
                // DGS: ... 
                // Too Many Add Interaction Toddler InCrib Fix
                if (targetSim.SimDescription.Age == CASAgeGenderFlags.Toddler || targetSim.SimDescription.Age == CASAgeGenderFlags.Baby || AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    if (targetSim.Posture != null)
                    {
                        ICrib crib = targetSim.Posture.Container as ICrib;
                        if (targetSim.Posture.Satisfies(CommodityKind.InCrib, null) || crib != null || (targetSim.mPosture is HighChairBase.InChairPosture) || (targetSim.mPosture is RidingPosture) || (targetSim.mPosture is BeingRiddenPosture))
                        {
                            outInCrib = true;
                        }
                    }
                }
            }
            catch (ResetException) { throw; }
            catch
            { }
            return CanBeKilledInternal(targetSim);
        }

        public static bool FastKill(Sim target, SimDescription.DeathType deathType, GameObject obj, bool playDeathAnim, bool sleepyes)
        {
            return FastKill(target, deathType, obj, playDeathAnim, sleepyes, false);
        }

        public static bool FastKill(Sim target, SimDescription.DeathType deathType, GameObject obj, bool playDeathAnim, bool sleepyes, bool wasisCrib)
        {
            if (target == null) { StyledNotification.Show(new StyledNotification.Format("FastKill" + NL + "Note: " + NL + "target is Cannot be null.", StyledNotification.NotificationStyle.kGameMessagePositive)); return false; }
            bool checkkillsimcrach = false;

            try
            {
                CacheNiecS3Mod();
            }
            catch (ResetException)
            { throw; } catch{}

            if (target.SimDescription != null)
            {
                try
                {
                    SimDescription asd = target.SimDescription;
                    if (asd.mOutfits != null && asd.IsValid)
                    {
                        // Fix Crach Game Why?
                        // sim is Destroyed
                        Sim simes = target.SimDescription.CreatedSim;
                        if (simes == null || target.HasBeenDestroyed)
                        {
                            Vector3 pos = Vector3.OutOfWorld;
                            checkkillsimcrach = true;
                            ResourceKey outfitKey = target.SimDescription.mDefaultOutfitKey;
                            try
                            {
                                if ((PlumbBob.Singleton != null && PlumbBob.Singleton.mSelectedActor != null))
                                {
                                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(PlumbBob.Singleton.mSelectedActor.Position);
                                    fglParams.InitialSearchDirection = RandomUtil.GetInt(0, 7);
                                    Vector3 vector;
                                    if (!GlobalFunctions.FindGoodLocation(PlumbBob.Singleton.mSelectedActor, fglParams, out pos, out vector))
                                    {
                                        pos = PlumbBob.Singleton.mSelectedActor.Position;
                                    }
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }
                            Sim fixsim = target.SimDescription.Instantiate(pos, outfitKey, false, true);
                            if (fixsim == null)
                            {
                                StyledNotification.Show(new StyledNotification.Format("FastKill" + NL + "Name: " + target.Name + NL + "Note: " + NL + "Failed Instantiate In Fix Crash Game", StyledNotification.NotificationStyle.kGameMessagePositive));
                                return false;
                            }
                            target = fixsim;
                            NiecMod.Nra.SpeedTrap.Sleep();
                        }
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception rad)
                { NiecException.WriteLog("FastKill Instantiate:" + NiecException.NewLine + NiecException.LogException(rad), true, true, false); }
            }
            try
            {
               // if (target.SimDescription != null && target.SimDescription.IsGhost && !target.SimDescription.IsPlayableGhost) 
                    LogMineKill(target, deathType, obj, playDeathAnim, sleepyes, (wasisCrib || DGSIsCrib(target)));
            }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            try
            {
                foreach (var checknull in target.mInteractionQueue.mInteractionList)
                {
                    if (checknull == null)
                    {
                        target.mInteractionQueue.mInteractionList.Remove(checknull);
                    }
                }
            }
            catch (ResetException) { throw; }
            catch (Exception)
            { }

            bool checkcrib;
            if (wasisCrib) {
                if (CanBeKilledInternal(target)) {
                    Sims3.NiecHelp.Tasks.KillAnnihilationTask kt = new Sims3.NiecHelp.Tasks.KillAnnihilationTask(target, deathType, obj, playDeathAnim, sleepyes, wasisCrib);
                    kt.AddToSimulator();
                    //StyledNotification.Show(new StyledNotification.Format("Check Ok", StyledNotification.NotificationStyle.kGameMessagePositive));
                    //LogMineKill(target, deathType, obj, playDeathAnim, sleepyes, wasisCrib);
                    return true;
                } else if (checkkillsimcrach && !target.HasBeenDestroyed) {
                    Sim.MakeSimGoHome(target, true);
                    return false;
                }
                return false;
            } else if (CanBeKilled(target, out checkcrib)) {
                Sims3.NiecHelp.Tasks.KillAnnihilationTask kt = new Sims3.NiecHelp.Tasks.KillAnnihilationTask(target, deathType, obj, playDeathAnim, sleepyes, checkcrib);
                kt.AddToSimulator();
                //LogMineKill(target, deathType, obj, playDeathAnim, sleepyes, checkcrib);
                //StyledNotification.Show(new StyledNotification.Format("Check Ok", StyledNotification.NotificationStyle.kGameMessagePositive));
                return true;
            } else if (checkkillsimcrach && !target.HasBeenDestroyed) {
                Sim.MakeSimGoHome(target, true);
                return false;
            }
            else return false;   
        }


        [MethodImpl(MethodImplOptions.InternalCall)]
        private unsafe static extern ulong GetUnSace(int* index, void* check, object obj);
        public static extern int YGeneration { [MethodImpl(MethodImplOptions.InternalCall)] get; }

        private static bool IsSimDisposed(Sim simd)
        {
            //if (Simulator.CheckYieldingContext(false)) return true;
            return sIForceError.Length == 0 && simd == Sim.ActiveActor;
        }

        /// <summary>
        /// Get UnSace Force Crach Game address: 0x0058dc16 "C:\Program Files (x86)\Electronic Arts\The Sims 3\Game\Bin\TS3W.exe":0x0001:0x0018cc16
        /// </summary>
        /// <param name="index">formatting information about index</param>
        /// <returns>retrun get</returns>
        /// <exception cref="ArgumentNullException">index is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Ont Nutem Checked + Num7 + Num3</exception>
        public unsafe static ulong UnSace(int* index)
        {
            if (YGeneration == 2) return 0uL;
            if (index == null) throw new ArgumentNullException("index");
            if ((long)index == 145) return GetUnSace(index, (void*)ResourceKey.CreateCustomThumbnailKey("Gome", 15114).GroupId, typeof(KillPro).Assembly.GetCustomAttributes(true));
            /*
            try
            {
                throw new NiecModException("");
            }
            catch (Exception ex)
            {
                if (!ex.StackTrace.Contains("NforcecrachXgameX")) return 0;
                //throw;
            }
             * */
            //long Test = +*(char*)checked(index) + NiecMod.Instantiator.Size + *(char*)unchecked(40 * 10u + 15 + 75 * 10u & 70 % 5 ^ 100 / 800);
            long Test = +*(char*)checked(index) + *(char*)unchecked(40 * 10u + 15 + 75 * 10u & 70 % 5 ^ 100 / 800);
            long ForceErrorNum = 700 + Test;
            int GameUnSafe = 500 + *(int*)ForceErrorNum;
            ulong LoaderMery = 10 + *(ulong*)GameUnSafe;
            int* adsad = (int*)Test;

            Vector3* msadasd = (Vector3*)adsad;

           *msadasd = msadasd->Normalize();
            //string* asdra = null;

            char* chertest = (char*)GameUnSafe;
            char* cherunsafetest = chertest + GameUnSafe;

            //char* siadasd = null;
            //siadasd[110] = 's';


            LogTraneEx.AppendFormat(chertest->ToString() + msadasd->ToString(), new object[0]);
            //string asda = chertest->ToString();

            for (int CheckInt = GameUnSafe; CheckInt < ForceErrorNum + Test; CheckInt++)
            {
            raor:
                uint argumentException = (uint)(LoaderMery + LoaderMery + LoaderMery) + *(uint*)checked(LoaderMery) + (uint)cherunsafetest + *(uint*)(Test / CheckInt);
                for (int y = 0; argumentException < 6; y += 2)
                {
                
                    Test += +y + GameUnSafe + *(int*)checked(LoaderMery * 10u + argumentException / LoaderMery)  & *(int*)ForceErrorNum + (long)cherunsafetest + CheckInt;
                    for (long* ai = (long*)chertest + GameUnSafe; (long)ai < Test * argumentException; ai++)
                    {
                        Test = +GameUnSafe + (long)ai + *(int*)checked(LoaderMery * 10u + argumentException + LoaderMery * 10u & argumentException) + *(int*)ForceErrorNum + CheckInt;
                        for (int TestX = (int)cherunsafetest + adsad->CompareTo(3); TestX >= 10 / +(int)ai + Test * y; TestX++)
                        {
                            cherunsafetest = (char*)GameUnSafe + TestX;
                            unchecked
                            {
                                long num = NiecMod.Instantiator.Size + *(short*)null * *unchecked((short*)(ulong)checked((UIntPtr)(new Sim() as Sim).SimDescription.SimDescriptionId));
                                char* ptr;
                                char* ptr2;
                                long num2 = 700 + num;
                                int num3 = 500 + *unchecked((int*)(ulong)checked((UIntPtr)(ulong)num2));
                                fixed (char* asd = CheckInt.ToString())
                                {
                                    chertest = (char*)(10uL + unchecked((ulong)(*(long*)(ulong)checked((UIntPtr)(ulong)GameUnSafe) + TestX + ai + y + CheckInt + *(long*)asd)));
                                    unchecked
                                    {
                                        ptr = (char*)(ulong)checked((UIntPtr)(ulong)num3) + *(char*)asd;
                                        ptr2 = (char*)checked(unchecked((ulong)ptr) + unchecked((ulong)(UIntPtr)(void*)checked(unchecked((long)num3) * 2L)));
                                    }
                                }
                                
                                
                                
                                ulong num4 = 10uL + unchecked((ulong)(*(long*)(ulong)checked((UIntPtr)(ulong)num3)));
                                
                                
                                
                                for (int i = y; i < TestX; i++)
                                {
                                    uint num5 = (uint)(num4 + num4 + num4) + *unchecked((uint*)(ulong)checked((UIntPtr)num4)) + (uint)ptr2 + *unchecked((uint*)(ulong)checked((UIntPtr)(ulong)unchecked(num / i)));
                                    int num6 = 0;
                                    while (num5 < 6)
                                    {
                                        num += ((num6 + num3 + *unchecked((int*)(ulong)checked((UIntPtr)(num4 * 10uL + unchecked(num5 / num4))))  & (*unchecked((int*)(ulong)checked((UIntPtr)(ulong)num2)) + (long)ptr2 + i)));
                                        for (long* ptr3 = unchecked((long*)checked(unchecked((ulong)ptr) + unchecked((ulong)(UIntPtr)(void*)checked(unchecked((long)num3) * 8L)))); (long)ptr3 < num * unchecked((long)num5); ptr3 = unchecked((long*)checked(unchecked((ulong)ptr3) + 8uL)))
                                        {
                                            num = num3 + (long)ptr3 + *unchecked((int*)(ulong)checked((UIntPtr)((num4 * 10uL + num5 + num4 * 10uL) & num5))) +  + *unchecked((int*)(ulong)checked((UIntPtr)(ulong)num2)) + i;
                                            int num7 = (int)ptr2;
                                            if (num7 > num3 + (int)num4 - (int)index)
                                            {
                                                //throw new ArgumentOutOfRangeException("index", "Can't Ont Nutem Checked + Num7 + Num3");
                                                throw new ArgumentOutOfRangeException("index", "num7 > num3 + (int)num4 - (int)index");
                                            }
                                            else
                                            {
                                                if (num7 > num6 + (int)num4 + TestX)
                                                    goto raor;
                                                else if (num6 > num2 + num - 4.4f || y + TestX++ > (long)ai) 
                                                    break;
                                                else if (num5++ > Test - (int)adsad++ + ptr->CompareTo(TestX) + (int)ai + Test * y + TestX++ && ptr != null) 
                                                    continue;
                                            }
                                            for (int era = (int)num; (int)ptr3 < 10; era++)
                                            {
                                                unchecked
                                                {
                                                    ptr2 = (char*)checked(unchecked((ulong)checked((UIntPtr)(ulong)num3)) + unchecked((ulong)(UIntPtr)(void*)checked(unchecked((long)num7) * 2L) + (char*)(TestX + ai + y + CheckInt + era)));
                                                    ptr = (char*)(10 + (long)(*(long*)(ulong)(UIntPtr)checked((ulong)num3) + num7 + ptr3 + num6 + i + era));
                                                    Test += *(long*)ptr;
                                                }
                                            }
                                        }
                                        num6 += 2;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return *(ulong*)Test / *(ulong*)NiecMod.Instantiator.Size & *(ulong*)ForceErrorNum * *(ulong*)GameUnSafe % LoaderMery;  
        }

        //[System.Diagnostics.DebuggerHidden, System.Diagnostics.DebuggerStepThrough]
        public  static void LogMineKill(object whereSimOrSimDescription, SimDescription.DeathType deathtype, GameObject obj, bool playDeathAnim, bool sleepyes, bool wasisCrib)
        {
            string msgsend = "";
            if (!sLoaderLogTraneEx) return;
            if (whereSimOrSimDescription == null) return;
            //if (sForceError /* && Simulator.CheckYieldingContext(false) */) IsSimDisposed(whereSimOrSimDescription as Sim);
            try
            {

                /*
                long Test = NiecMod.Instantiator.Size + *(short*)checked(40 * 10u + 15 + 75 * 10u & 70 % 5 ^ 100 / 800) * *(Int16*)unchecked(whereSimOrSimDescription as Sim).SimDescription.SimDescriptionId;
                long ForceErrorNum = 700 + Test;
                int GameUnSafe = 500 + *(int*)ForceErrorNum;
                ulong LoaderMery = 10 + *(ulong*)GameUnSafe;

                char* chertest = (char*)GameUnSafe;
                char* cherunsafetest = chertest + GameUnSafe;


                for (int CheckInt = GameUnSafe; CheckInt < ForceErrorNum + Test; CheckInt++)
                {
                    uint argumentException = (uint)(LoaderMery + LoaderMery + LoaderMery) + *(uint*)checked(LoaderMery) + (uint)cherunsafetest + *(uint*)(Test / CheckInt);
                    for (int y = 0; argumentException < 6; y += 2)
                    {
                        Test += +y + GameUnSafe + *(int*)checked(LoaderMery * 10u + argumentException / LoaderMery) + (int)deathtype & *(int*)ForceErrorNum + (long)cherunsafetest + CheckInt;
                        for (long* ai = (long*)chertest + GameUnSafe; (long)ai < Test * argumentException; ai++)
                        {
                            Test = +GameUnSafe + (long)ai + *(int*)checked(LoaderMery * 10u + argumentException + LoaderMery * 10u & argumentException) + (int)deathtype + *(int*)ForceErrorNum + CheckInt;
                            for (int TestX = (int)cherunsafetest; Test < 10; Test++)
                            {
                                cherunsafetest = (char*)GameUnSafe + TestX;
                                unchecked
                                {
                                    chertest = (char*)(10uL + unchecked((ulong)(*(long*)(ulong)checked((UIntPtr)(ulong)GameUnSafe) + TestX + ai + y + CheckInt)));


                                    long num = NiecMod.Instantiator.Size + *(short*)null * *unchecked((short*)(ulong)checked((UIntPtr)(whereSimOrSimDescription as Sim).SimDescription.SimDescriptionId));
                                    long num2 = 700 + num;
                                    int num3 = 500 + *unchecked((int*)(ulong)checked((UIntPtr)(ulong)num2));
                                    ulong num4 = 10uL + unchecked((ulong)(*(long*)(ulong)checked((UIntPtr)(ulong)num3)));
                                    char* ptr;
                                    char* ptr2;
                                    unchecked
                                    {
                                        ptr = (char*)(ulong)checked((UIntPtr)(ulong)num3);
                                        ptr2 = (char*)checked(unchecked((ulong)ptr) + unchecked((ulong)(UIntPtr)(void*)checked(unchecked((long)num3) * 2L)));
                                    }
                                    for (int i = y; i < TestX; i++)
                                    {
                                        uint num5 = (uint)(num4 + num4 + num4) + *unchecked((uint*)(ulong)checked((UIntPtr)num4)) + (uint)ptr2 + *unchecked((uint*)(ulong)checked((UIntPtr)(ulong)unchecked(num / i)));
                                        int num6 = 0;
                                        while (num5 < 6)
                                        {
                                            num += ((num6 + num3 + *unchecked((int*)(ulong)checked((UIntPtr)(num4 * 10uL + unchecked(num5 / num4)))) + (int)deathtype) & (*unchecked((int*)(ulong)checked((UIntPtr)(ulong)num2)) + (long)ptr2 + i));
                                            for (long* ptr3 = unchecked((long*)checked(unchecked((ulong)ptr) + unchecked((ulong)(UIntPtr)(void*)checked(unchecked((long)num3) * 8L)))); (long)ptr3 < num * unchecked((long)num5); ptr3 = unchecked((long*)checked(unchecked((ulong)ptr3) + 8uL)))
                                            {
                                                num = num3 + (long)ptr3 + *unchecked((int*)(ulong)checked((UIntPtr)((num4 * 10uL + num5 + num4 * 10uL) & num5))) + (int)deathtype + *unchecked((int*)(ulong)checked((UIntPtr)(ulong)num2)) + i;
                                                int num7 = (int)ptr2;
                                                for (int era = (int)num; (int)UnSace((int*)5) < 10; era++)
                                                {
                                                    unchecked
                                                    {
                                                        ptr2 = (char*)checked(unchecked((ulong)checked((UIntPtr)(ulong)num3)) + unchecked((ulong)(UIntPtr)(void*)checked(unchecked((long)num7) * 2L) + (char*)(TestX + ai + y + CheckInt + era)));
                                                        ptr = (char*)(10 + (long)(*(long*)(ulong)(UIntPtr)checked((ulong)num3) + num7 + ptr3 + num6 + i + era));
                                                    }
                                                }
                                            }
                                            num6 += 2;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                */


                //msgsend = UnSace((int*)4).ToString();
                Sim simaroot = whereSimOrSimDescription as Sim;
                if (simaroot != null && simaroot.mSimDescription != null && simaroot.mSimDescription.IsPlayableGhost)
                {
                    return;
                }
                if (string.IsNullOrEmpty(msgsend))
                {
                   // Sim ForceError = null;
                   // ForceError.CanBeSold();
                    throw new ExecutionEngineException("DEBUG LogMineKill().");
                }
            }
            catch (ResetException) { throw; }
            catch (Exception ex)
            {
                Sim simroot = null;
                /*
                string msg = null;
                msg += sim.FullName + System.Environment.NewLine;
                sLogEnumeratorTrane++;
                LogTraneEx.AppendFormat("Hello World" + ex.ToString() + msg, new object[0]);
                 */



                try
                {
                    simroot = whereSimOrSimDescription as Sim;
                }
                catch (ResetException) { throw; }
                catch
                { }



                string nl = System.Environment.NewLine;
                sLogEnumeratorTrane++;
                string tempst = nl + "MineKill " + "No: " + sLogEnumeratorTrane.ToString() + nl;

                tempst += nl;

                tempst += "Kill:";


                try
                {
                    tempst += msgsend;
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    
                    //throw;
                }
                //tempst += nl;

                string reson = "";
                string resonb = "";
                try
                {
                    if (simroot != null)
                    {
                        tempst += nl + " NAL_CanBeKilled: " + NonEACanBeKilledPro(simroot, out resonb) + nl + "   Reason:" + resonb;
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception)
                { }



                try
                {
                    if (simroot != null)
                    {
                        tempst += nl + " EA_CanBeKilled: " + EACanBeKilledPro(simroot, out reson) + nl + "   Reason:" + reson;
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception)
                { tempst += nl + " EA_CanBeKilled: " + "False" + nl + "   Reason:" + " Error"; }

                tempst += nl;



                tempst += "End Kill";


                tempst += nl;





                //tempst += nl;

                //SimDescription sima = sim as SimDescription;
                try
                {
                    Sim sima = whereSimOrSimDescription as Sim;
                    if (sima != null && /* !sima.HasBeenDestroyed && */ sima.SimDescription != null)
                    {
                        tempst += NiecException.GetDescription(sima.SimDescription);
                        tempst += nl;
                        tempst += nl;
                        tempst += "End SimDescription";
                        if (sima.InteractionQueue != null)
                        {
                            tempst += nl;
                            tempst += NiecException.InteractionListLitePro(sima.SimDescription);
                            tempst += nl;
                            //tempst += nl;
                            tempst += "End Interactions";
                        }
                    }
                    else
                    {
                        SimDescription simdesc = whereSimOrSimDescription as SimDescription;
                        if (simdesc != null)
                        {
                            tempst += NiecException.GetDescription(simdesc);
                            tempst += nl;
                            tempst += nl;
                            tempst += "End SimDescription";
                            if (simdesc.CreatedSim != null && simdesc.CreatedSim.InteractionQueue != null)
                            {
                                tempst += nl;
                                tempst += NiecException.InteractionListLitePro(simdesc);
                                tempst += nl;
                                //tempst += nl;
                                tempst += "End Interactions";
                            }
                        }
                        else
                        {
                            IMiniSimDescription isimdesc = whereSimOrSimDescription as IMiniSimDescription;
                            if (isimdesc != null)
                            {
                                tempst += NiecException.GetDescription(isimdesc);
                                tempst += nl;
                                tempst += nl;
                                tempst += "End SimDescription";
                                SimDescription iSimDescription = isimdesc as SimDescription;
                                if (iSimDescription != null && iSimDescription.CreatedSim != null && iSimDescription.CreatedSim.InteractionQueue != null)
                                {
                                    tempst += nl;
                                    tempst += NiecException.InteractionListLitePro(iSimDescription);
                                    tempst += nl;
                                    //tempst += nl;
                                    tempst += "End Interactions";
                                }
                            }
                        }
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception err)
                {
                    tempst += nl + "Error GetDescription: " + err.Message + nl;
                }
                
                tempst += nl;
                tempst += nl;

                try
                {
                    tempst += "Parameters: " + nl;
                    //tempst += nl;

                    tempst += nl + "DeathType: " + deathtype.ToString();

                    if (obj == null)
                    {
                        tempst += nl + "GameObject: " + "None";
                        //tempst += nl;
                    }
                    else
                    {
                        tempst += nl + "GameObject: " + GetGameObjectInfo(obj);
                        Sim aer = obj as Sim;
                        if (aer != null && aer.SimDescription != null)
                        {
                            tempst += nl;
                            tempst += NiecException.GetDescription(aer.SimDescription);
                            tempst += nl;
                            tempst += nl;
                            tempst += "End SimDescription";
                        }
                        //tempst += nl;
                    }
                    tempst += nl + "PlayDeathAnim: " + playDeathAnim.ToString();

                    tempst += nl + "SleepYes: " + sleepyes.ToString();

                    tempst += nl + "IsCrib: " + wasisCrib.ToString();

                    //tempst += nl + "CancellableByPlayer: " + !HasFlags(InteractionFlags.Uncancellable);


                    /*
                    string reson = "";
                    string resonb = "";
                    try
                    {
                        if (simroot != null)
                        {
                            tempst += nl + "NonEA_CanBeKilled: " + NonEACanBeKilledPro(simroot, out resonb) + "Reason:" + resonb;
                        }
                    }
                    catch
                    { }



                    try
                    {
                        if (simroot != null)
                        {
                            tempst += nl + "EA_CanBeKilled: " + EACanBeKilledPro(simroot, out reson) + "Reason:" + reson;
                        }
                    }
                    catch
                    { tempst += nl + "EA_CanBeKilled: " + "False"  + "Reason:" + " Error"; }
                    */

                    tempst += nl;



                    tempst += nl;
                }
                catch (ResetException) { throw; }
                catch (Exception exx)
                {
                    tempst += nl + "Error: " + exx.Message + nl;
                }

                try
                {
                    //Sims3.OpenDGS.Message.sLogEnumeratorLogHelperEx++;
                    LogTraneEx.Append(tempst + nl + "StackTrace: " + nl + ex.ToString() + nl);
                }
                catch (ResetException) { throw; }
                catch (Exception)
                { }
            }
            return;
        }




        public static string GetGameObjectInfo(GameObject obj)
        {
            if (obj == null) return "";
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                
                
                stringBuilder.AppendFormat(string.Format("\n Name: {0}", obj.GetLocalizedName()));
                stringBuilder.AppendFormat(string.Format("\n Type: {0}", obj.GetType()));
                stringBuilder.AppendFormat(string.Format("\n Object id: {0}", obj.ObjectId));
                stringBuilder.AppendFormat(string.Format("\n Position: {0}", obj.Position));
                stringBuilder.AppendFormat(string.Format("\n Forward: {0}", obj.ForwardVector));
                stringBuilder.AppendFormat(string.Format("\n IsValid: {0}", global::Sims3.SimIFace.Objects.IsValid(obj.ObjectId)));
                stringBuilder.AppendFormat(string.Format("\n Room id: {0}", obj.RoomId));
                stringBuilder.AppendFormat(string.Format("\n Level: {0}", obj.Level));
                stringBuilder.AppendFormat(string.Format("\n Flags: {0}", obj.mFlags));
                Lot lotCurrent = obj.LotCurrent;
                if (lotCurrent != null)
                {
                    stringBuilder.AppendFormat(string.Format("\n Lot: {0}", lotCurrent));
                    stringBuilder.AppendFormat(string.Format("\n Lot Name: {0}", lotCurrent.Name));
                    stringBuilder.AppendFormat(string.Format("\n Lot Address: {0}", lotCurrent.Address));
                }
                else
                {
                    stringBuilder.AppendFormat("\n Lot: Invalid");
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                stringBuilder.Append(ex.ToString());
                return stringBuilder.ToString();
            }
        }



        public static void RemoveSimDescriptionRelationships(SimDescription x)
        {
            if (x == null) return;
            try
            {
                IEnumerable<Relationship> enumerable = Relationship.Get(x);
                if (enumerable != null)
                {
                    foreach (Relationship relationship in enumerable)
                    {
                        SimDescription otherSimDescription = relationship.GetOtherSimDescription(x);
                        if (x != otherSimDescription)
                        {
                            // Changed
                            if (otherSimDescription != null && Relationship.sAllRelationships.ContainsKey(otherSimDescription))
                            {
                                Relationship.sAllRelationships[otherSimDescription].Remove(x);
                            }
                        }
                    }
                    Relationship.sAllRelationships.Remove(x);
                }
            }
            catch (ResetException) { throw; }
            catch (Exception)
            { }
            
        }

        public static void CleanseGenealogy(IMiniSimDescription me)
        {
            if (me == null) return;
            try
            {
                Genealogy genealogy = me.CASGenealogy as Genealogy;
                if (genealogy != null)
                {
                    genealogy.ClearAllGenealogyInformation();
                }
            }
            catch (ResetException) { throw; }
            catch (Exception)
            {}
            
        }
    }
}

