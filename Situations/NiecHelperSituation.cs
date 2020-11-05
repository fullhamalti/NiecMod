namespace Sims3.Gameplay.NiecRoot
{
    #region Using Directives
    using System;
    using Sims3.Gameplay.Actors;
    using Sims3.Gameplay.Autonomy;
    using Sims3.Gameplay.Core;
    //using Sims3.Gameplay.Services;
    using Sims3.Gameplay.Socializing;
    using Sims3.Gameplay.Utilities;
    // New
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
    using Sims3.Gameplay.Skills;

    #endregion

    
    // NHS, NiecHelperSituation
    [Persistable]
    public class NiecHelperSituation : RootSituation, IPersistPostLoad
    {
        [PersistableStatic]
        public static bool sFakeSetActor = false;
        [PersistableStatic]
        public static bool sFakeSetActorR = false;
        [PersistableStatic]
        public static bool sFakeSetActorA = true;

        [PersistableStatic]
        public static bool kLoopAllSimFadnIn = false;

        [PersistableStatic]
        public static bool kDEBUGIsO03 = false;
        [PersistableStatic]
        public static bool kUnsafeSMCNULLSIM = false;
        [PersistableStatic]
        public static bool klooppet = false;

        [PersistableStatic]
        public static bool kUnsafeOpenDGSReapSoulPetHoruse = true;

        public static bool sFakeSetActorFoFadeIn = false;

        public static Sim sFakeSetActorC = null;

        public static
            bool ShouldSoctalSlowNHSRPS()
        {
            return __acorewIsnstalled__ && !isdgmods;
        }
        public static Sim GetCheckSimDeadX() {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null) 
                    continue;

                var simd = item.mSimDescription;
                if (simd == null) 
                    continue;

                if (!___bOpenDGSIsInstalled_ && __bIsGrimReaper(item))
                    continue;
                
                if (simd.DeathStyle != 0 && !simd.IsGhost)
                {
                    if (___bOpenDGSIsInstalled_ && _bTargetNoActiveHouseholdExAA && item != NiecMod.Helpers.NiecRunCommand.looptargetdied_data && item != NFinalizeDeath.ActiveActor)
                    {
                        //if (sim == NFinalizeDeath.ActiveActor)
                        //    return false;
                        //if (sim.Household != null && sim.Household == NFinalizeDeath.ActiveHouseholdWithoutDGSCore)
                        //    return false;
                        Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                        if (ActiveHousehold != null && simd.Household == ActiveHousehold )
                        {
                            Sims3.Gameplay.Services.GrimReaper sGrimReaperInstance = Sims3.Gameplay.Services.GrimReaper.Instance;
                            //if (sGrimReaperInstance != null && (sGrimReaperInstance.mPool == null || sGrimReaperInstance.mPool.Count == 0)) { }
                            if (sGrimReaperInstance == null || sGrimReaperInstance.mPool == null || sGrimReaperInstance.mPool.Count == 0) { }
                            else continue; 
                        } 
                    }
                    return item;
                }
            }
            return null;
        }


        public static int IsSTAwesomeModFast_Sleep = 0;
        [PersistableStatic]
        public static int IsSTAwesomeModFast_SleepMax = 0xFF;

        public interface INHSInteraction { }

        public static T FindInv<T>(Sim Target) where T : class, IGameObject
        {
            if (___bOpenDGSIsInstalled_)
                return Target.Inventory.Find<T>();
            try
            {
                return Target.Inventory.Find<T>();
            }
            catch (StackOverflowException)
            {
                NFinalizeDeath.SafeForceTerminateRuntime();
                throw;
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception)
            {
                NFinalizeDeath.CheckYieldingContext();
            }
            return null;
        }

        public void Dispose_2() {
            CleanUp();
            var sim = Worker;
            if (sim != null && !NFinalizeDeath.GameObjectIsValid(sim.ObjectId.mValue))
                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(sim);
            Worker = null;
        }


        public static bool ExAA = false;

        public void PersistPostLoad()
        {
            try
            {
                //var sim = Worker;
                //if (sim == null || NFinalizeDeath.ObjectGuid_IsDestroyed(sim.ObjectId)) //!ScriptCore.Objects.Objects_IsValid(sim.ObjectId.mValue))
                //{
                //    Dispose_2();
                //    Dispose();
                //
                //    NFinalizeDeath.SimRemove_SituationList(sim, this, true);
                //    var _Spawn = Child as Spawn;
                //    if (_Spawn != null)
                //    {
                //        _Spawn.CleanUp();
                //        _Spawn._Dispose();
                //        _Spawn.mParent = null;
                //    }
                //
                //    try
                //    {
                //        if (mInteractions != null)
                //            mInteractions.Clear();
                //        if (mSimsWithInteractions != null)
                //            mSimsWithInteractions.Clear();
                //    }
                //    catch (ResetException)
                //    {
                //        throw;
                //    }
                //    catch 
                //    { mInteractions = new List<InteractionInstance>(); }
                //    mChild = null;
                //   //goto e;
                //}
                if (!___bOpenDGSIsInstalled_)
                {
                    var sim = Worker;
                    if (sim == null || NFinalizeDeath.ObjectGuid_IsDestroyed(sim.ObjectId)) //!ScriptCore.Objects.Objects_IsValid(sim.ObjectId.mValue))
                    {
                        Dispose_2();
                        Dispose();

                        NFinalizeDeath.SimRemove_SituationList(sim, this, true);
                        var _Spawn = Child as Spawn;
                        if (_Spawn != null)
                        {
                            _Spawn.CleanUp();
                            _Spawn._Dispose();
                            _Spawn.mParent = null;
                        }

                        try
                        {
                            if (mInteractions != null)
                                mInteractions.Clear();
                            if (mSimsWithInteractions != null)
                                mSimsWithInteractions.Clear();
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch
                        { mInteractions = new List<InteractionInstance>(); }
                        mChild = null;
                        return;
                    }
                    var _SpawnC = Child as Spawn;
                    if (_SpawnC != null)
                        _SpawnC.PersistPostLoad();
                }
                else
                {
                    klooppet = false;
                    NFinalizeDeath.List_FastClearEx(ref mInteractions); 
                    var _Spawn = Child as Spawn;
                    if (_Spawn != null)
                    { NFinalizeDeath.List_FastClearEx(ref _Spawn.mInteractions); }
                }
            }
            catch (ResetException)
            {
                throw;
            }
            catch { }

        }
        [PersistableStatic]
        public static bool ShouldOnSavingGame_NonOpenDGS = false;
        [PersistableStatic]
        public static bool ForceRunReapSoulPet = false;
        [PersistableStatic]
        public static bool ForceRunReapSoul = false;
        [PersistableStatic]
        public static object asdoetr = null;

        public static bool bShouldOnSavingGame = false;


        public static void OnSavingGame()
        {
            bShouldOnSavingGame = true;
            if (NiecMod.Helpers.NiecRunCommand.tausevAlarm != null)
            {
                NiecMod.Helpers.NiecRunCommand.usam_Command();
                NiecTask.Perform(delegate
                {
                    Sims3.Gameplay.UI.Responder re = Sims3.Gameplay.UI.Responder.Instance;
                    if (re != null)
                    {
                        IOptionsModel io = re.OptionsModel;

                        while (io != null && io.SaveGameInProgress)
                            Simulator.Sleep(0);

                        Simulator.Sleep(0);
                        Simulator.Sleep(0);
                        Simulator.Sleep(0);

                        if (NiecMod.Helpers.NiecRunCommand.tausevAlarm == null)
                            NiecMod.Helpers.NiecRunCommand.usam_Command();
                    }
                });
            }
            var ity = NFinalizeDeath.SC_GetObjects<Sim>();
            if (___bOpenDGSIsInstalled_)
            {
                if (NiecMod.Helpers.NiecRunCommand.BackupTEV != null)
                {
                    ListCollon.SafeObjectGC.Add(NiecMod.Helpers.NiecRunCommand.BackupTEV);
                    NiecMod.Helpers.NiecRunCommand.BackupTEV = null; //new List<object>();
                }
                else
                    NiecMod.Helpers.NiecRunCommand.BackupTEV = null;

                asdoetr = null;
                foreach (var item in ity)
                {
                    var nhs = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(item);
                    if (nhs == null)
                        continue;

                    NFinalizeDeath.List_FastClearEx(ref nhs.mInteractions);
                    NFinalizeDeath.List_FastClearEx(ref nhs.mForcedInteractions);

                    var nhsChild = nhs.Child as Spawn;
                    if (nhsChild == null)
                        continue;

                    NFinalizeDeath.List_FastClearEx(ref nhsChild.mInteractions);
                    NFinalizeDeath.List_FastClearEx(ref nhsChild.mForcedInteractions);
                }
                try
                {
                    NFinalizeDeath.RemoveAllIQRunningIList();
                }
                catch (ResetException)
                { throw; }
                catch { }
                
            }
            else
            {
                NFinalizeDeath.RemoveAllSimNiecNullForGrave(); // i know PontLoad call sim desc Fixup() error: System.NullReferenceException
                GC.Collect();
                if (__acorewIsnstalled__ && !AssemblyCheckByNiec.SafeIsInstalled("OpenDGS"))
                {
                    if (NiecMod.Helpers.NiecRunCommand.GCKeepGameCrash != null)
                    asdoetr = NiecMod.Helpers.NiecRunCommand.GCKeepGameCrash;
                    foreach (var item in ity)
                    {
                        if (item == null) 
                            continue;
                        try
                        {
                            var pa = item.Parent as GameObject;
                            if (pa != null)
                                NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(pa, true);

                            NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(item, true);
                            NFinalizeDeath.UnSafe_RemoveActorsUsingMe(item);
                            item.mPosture = item.Standing ?? item.mPosture;
                            var iq = item.mInteractionQueue;
                            if (iq != null)
                            {
                                //if (iq.mRunningInteractions == null) {
                                    iq.mRunningInteractions = new Stack<InteractionInstance>();
                                    iq.mCurrentTransitionInteraction = null;
                                    iq.mInteractionTimerRunning = false;
                                    iq.mIsHeadInteractionActive = false;
                                    iq.mIsHeadInteractionLocked = false;
                                    if (iq.mInteractionList != null && iq.mInteractionList._items != null && iq.mInteractionList._items.Length > 0)
                                    {
                                        var ii = iq.mInteractionList._items[0];
                                        if (ii != null)
                                        {
                                            ii.mInteractionState = InteractionInstance.InteractionState.None;
                                        }
                                    }
                                // } else iq.mRunningInteractions.Clear();
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                }
                if (!__acorewIsnstalled__) { NiecMod.Helpers.NiecRunCommand.BackupTEV = null; NiecMod.Helpers.NiecRunCommand.GCKeepGameCrash = null; return; }
                if (ity.Length > 245 || AssemblyCheckByNiec.SafeIsInstalled("OpenDGS"))
                    return;
                if (ity.Length == 0) 
                    return;


                // // // // // /// /// /// /// /// /// /// /// /// /-< Big Size Save File :) >-/ /// /// /// /// /// /// /// /// // // // // //

                bool humanone = ity.Length < 10;// || ity.Length == 1 || ity.Length == 2 || ity.Length == 3 || ity.Length == 4;
                bool humanonepro = ity.Length == 1 || ity.Length == 2 || ity.Length == 3 || ity.Length == 4;
                ShouldOnSavingGame_NonOpenDGS = true;
                
                var th = RuningDeadSimList;
                foreach (var item in ity)
                {
                    try
                    {
                        if (item == null) continue;
                        var nhs = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(item);
                        if (nhs == null) continue;

                        NFinalizeDeath.List_FastClearEx(ref nhs.mInteractions);

                        var im = nhs.mInteractions;
                        if (im == null || im._items == null) 
                            continue;

                        int itemc = humanonepro ? 19716 : humanone ? 15716 : MathUtils.Clamp(ListCollon.SafeRandomPart2.Next(150, 350), 150, 350);

                        for (int i = 0; i < itemc; i++)
                        {
                            var co = th != null && th.Contains(item);
                            var cif = nhs.CreateInteraction(item) as Interaction<Sim, Sim>;
                            if (cif != null)
                            {

                                //if (nhs.OkSuusse)
                                {
                                    ReapSoul nt = cif as ReapSoul;
                                    if (nt != null)
                                    {
                                        while (!co && th != null && th.Remove(item)) { }
                                        nt.Notfixdgs = true;
                                    }
                                    else
                                    {
                                        NiecAppear ap = cif as NiecAppear;
                                        if (ap != null)
                                        {
                                            while (!co && th != null && th.Remove(item)) { }
                                            ap.DoneRun = true;
                                        }
                                    }
                                }
                                
                                //var fe = cif.InteractionObjectPair;
                                //if (fe != null)
                                //{
                                //    fe.mInteraction = null;
                                //}
                                im.Add(cif);
                            }
                            //if (!co)
                            //    th.Add(item);
                        }
                    }
                    catch (StackOverflowException)
                    {
                        return;
                    }
                    catch (ExecutionEngineException)
                    {
                        return;
                    }
                    catch (ResetException) { throw; }
                    catch { }
                   
                }
                GC.Collect();
            }
            bShouldOnSavingGame = false;
        }
        internal static void OnLoadingDialogDispose() {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>()) 
            {
                if (item == null) 
                    continue;

                var iq = item.InteractionQueue;
                if (iq == null) 
                    continue;

                try
                {
                    if (NFinalizeDeath.SimIsNiecHelperSituation(item) && NFinalizeDeath.IsTargetIQNHS(item))
                    {
                        InteractionInstance ii = null;
                        if (iq.mInteractionList != null) {
                            iq.mCurrentTransitionInteraction = ii = iq.GetHeadInteraction();
                        }

                        NFinalizeDeath.UnSafe_RemoveActorsUsingMe(item);

                        if (ii != null && ii.Target is Sim) {
                            NFinalizeDeath.UnSafe_RemoveActorsUsingMe(ii.Target as Sim);
                        }

                    }
                }
                catch (StackOverflowException) { throw; } 
                catch (ResetException) { throw; }
                catch (Exception ex)
                {
                    if (!___bOpenDGSIsInstalled_)
                        ex.stack_trace = null;
                    ex.inner_exception = null;
                    ex.trace_ips = null;
                   
                    continue;
                }
                
            }
        }

        //public static bool forceRandomAntiNPCOpenDGSOnly = false;
        internal static bool __kinkymdisInstalled = false;
        internal static bool ___bOpenDGSIsInstalled_ = AssemblyCheckByNiec.IsInstalled("OpenDGS");
        internal static bool __acorewIsnstalled__ = AssemblyCheckByNiec.IsInstalled("AweCore");
        public override bool AllowRoles
        {
            get
            {
                return !___bOpenDGSIsInstalled_;
            }
        }
        public static bool RandomAntiNPCOpenDGSOnly(Sim Actor) {
            if (!___bOpenDGSIsInstalled_) return true;
            if (!bRandomAntiNPCOpenDGSOnly) return true;

            //if (ListCollon.SafeRandomPart2 == null) 
            //    ListCollon.SafeRandomPart2 = new Random();
            if (Actor != null && Actor.InteractionQueue != null)
            {
                NinecReaper custi = Actor.CurrentInteraction as NinecReaper;
                if (custi != null && custi.CustomRunName == "uloopnhs")
                    return true;
            }
            return NFinalizeDeath.Random_GetFloat(0, 100, null) < 47;
        }

        public static bool IsUnSafeUsingListSim() {
            return !___bOpenDGSIsInstalled_ || bUnSafeUsingListSim;
        }
        public static bool IsTargetGood(GameObject Target)
        {
            if (!___bOpenDGSIsInstalled_) return true;
            return Simulator.GetProxy(Target.ObjectId) != null;
        }
        public static bool fUnSafe_FakeThrowRunInteraction = false;

        [PersistableStatic(true)]
        public static bool bUnSafeUsingListSim = false;

        [PersistableStatic(true)]
        public static bool bRandomAntiNPCOpenDGSOnly = true;

        [PersistableStatic]
        public static bool TestDivingPool = false;

        [PersistableStatic(true)]
        internal static bool ___bTestOpenDGS = true;

        [PersistableStatic]
        internal static bool NewYear2020SafePos_forcebool01 = false;

        [PersistableStatic(true)]
        internal static bool NewYear2020SafePos = true;
        public static bool SafePos2020() {
            if (___bOpenDGSIsInstalled_) {
                return NewYear2020SafePos;
            }
            else return false;
        }
        public static bool RunSafePos2020(Sim Actor, Sim Target, bool Forcebool01) {

            if (Actor == null || Target == null || !SafePosNHSTickOnly()) return false;
            if (SafePos2020())
            {
                Sim ActiveActor 
                = 
                    PlumbBob.SelectedActor ??
                    NFinalizeDeath.ActiveActor ??
                    Target ??
                    Actor
                ;

                if (ActiveActor == null) 
                    return false;

                bool tdone = false;
                var activelot = NFinalizeDeath.ActiveLotHome;
                if (ActiveActor.LotCurrent != null && ActiveActor.LotCurrent.IsWorldLot)
                {
                    foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                    {
                        if (item == null || item.LotCurrent == null || item.LotCurrent.IsWorldLot) 
                            continue;

                        ActiveActor = item;
                        // DEBUG Check
#if DEBUG
                        StyledNotification.Format format = new StyledNotification.Format("NiecHelperSituation:\nFound IsWorldLot Lot != Lot", item.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                        StyledNotification.Show(format);
#endif
                        tdone = true;
                        break;
                    }
                }

                if (!tdone && ___bOpenDGSIsInstalled_)
                {
                    if (ActiveActor.LotCurrent == activelot)
                    {
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            if (item == null || item.LotCurrent == null || item.LotCurrent == activelot || item.LotCurrent.IsWorldLot)
                                continue;
                            ActiveActor = item;
                            break;
                        }
                    }
                }

                Lot actorLotCurrent = ActiveActor.LotCurrent;
                if (actorLotCurrent != null && actorLotCurrent.CommercialLotSubType == CommercialLotSubType.kGraveyard)
                {
                    foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                    {

                        if (item == null)
                            continue;

                        Lot itemLotCurrent = item.LotCurrent;
                        if (itemLotCurrent == null ||
                            itemLotCurrent.IsWorldLot ||
                            itemLotCurrent.CommercialLotSubType == CommercialLotSubType.kGraveyard)
                            continue;

                        ActiveActor = item;
                        break;
                    }
                }

                if (NFinalizeDeath.Vector3_IsUnsafe(ActiveActor.Position))
                    ActiveActor.SetPosition(NFinalizeDeath.Lot_SafeGetPositionInRandomLot(LotManager.GetWorldLot()));

                Vector3 pos;
                Vector3 fwd;

                World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(ActiveActor.Position);

                fglParams.InitialSearchDirection = RandomUtil.GetInt(1, 2);

                if (!GlobalFunctions.FindGoodLocation(Actor, fglParams, out pos, out fwd))
                {
                    pos = ActiveActor.Position;
                    fwd = ActiveActor.ForwardVector;
                }

                if (!NFinalizeDeath.Vector3_IsUnsafe(pos))
                    Actor.SetPosition(pos);

                fwd = Target.Position - pos;
                fwd.y = 0f;
                fwd.Normalize();

                Actor.SetForward(fwd);

                //if (Actor.SimRoutingComponent != null)
                //    Actor.SimRoutingComponent.ForceUpdateDynamicFootprint();


                if (((Forcebool01 //|| (actorLotCurrent != null && actorLotCurrent.IsWorldLot) 
                    || (Target != null && actorLotCurrent != Target.LotCurrent))) && Simulator.GetProxy(Target.ObjectId) != null)
                {
                    fglParams.StartPosition = Actor.Position;

                    if (!GlobalFunctions.FindGoodLocation(Actor, fglParams, out pos, out fwd))
                    {
                        pos = ActiveActor.Position;
                        fwd = ActiveActor.ForwardVector;
                    }

                    if (!NFinalizeDeath.Vector3_IsUnsafe(pos))
                        Target.SetPosition(pos);

                    fwd = Actor.Position - pos;
                    fwd.y = 0f;
                    fwd.Normalize();

                    Target.SetForward(fwd);

                    //if (Target.SimRoutingComponent != null)
                    //    Target.SimRoutingComponent.ForceUpdateDynamicFootprint();
                }
                return ActiveActor.LotCurrent == Target.LotCurrent;
            }
            return false;
        }
        public static bool SafeGhostSetup= false;
        public static bool NeedCreateNHSTask = false;
        public static bool otherBool01 = false;

        [PersistableStatic]
        public static bool _bNoActiveHousehold = false;

        [PersistableStatic]
        public static bool _bTargetNoActiveHouseholdExAA = true;

        public static bool IsNoActiveHousehold(Sim worker)
        {
#if AddCodeIsOpenDGSInstalled 
             if (!___bOpenDGSIsInstalled_)
#else
            if (NiecHelperSituation.__acorewIsnstalled__)
#endif
                return false;

            if (!_bNoActiveHousehold) 
                return false;
            return worker != null && NFinalizeDeath.IsActiveHouseholdWithActiveActorPro(worker.Household, null);
        }






        [PersistableStatic]
        public static bool b_SafePosNHSTickOnly = true;

        public static bool SafePosNHSTickOnly()
        {
            if (!___bOpenDGSIsInstalled_) return true;
            //if (b_SafePosNHSTickOnly) return true;

            return b_SafePosNHSTickOnly;
        }












        public static bool SimHasBeenDestroyed(Sim sim)
        {
            if (sim == null) return true;
            try
            {

                if (sim.mSimDescription == null || sim.mSimDescription.mSim != sim)
                {
                    return true;
                }

                return Simulator.GetProxy(sim.ObjectId) == null;
            }
            catch (ResetException) { throw; }
            catch { return true; }
        }

        public static bool sIsGrimReaperFast = false;
        public static bool sIsGrimReaperFastX = false;
        public static bool IsGrimReaperFast()
        {
            if (!sIsGrimReaperFast)
            {
                sIsGrimReaperFast = true;
                try
                {

                    
                    sIsGrimReaperFastX = World.ResourceExists(ResourceKey.Parse("0333406C:00000000:483A5E1271FA41CA"));

                }
                catch (StackOverflowException) { sIsGrimReaperFast = false; }
                catch (ResetException) { throw; }
                catch
                { }
            }
            return sIsGrimReaperFastX;
        }

        public static Sim GetRandomAllActorForActiveHouseholdExAA()
        {
            var active_household = Household.ActiveHousehold;
            if (active_household != null)
            {
                var vmembers = active_household.mMembers;
                if (vmembers != null)
                {
                    var vitems_members = vmembers.mAllSimDescriptions;
                    if (vitems_members != null)
                    {
                        var items = vitems_members._items;
                        if (items == null)
                        {
                            return null;
                        }

                        var size_items = vitems_members._size;
                        if (size_items == 1)
                        {
                            // Ex Active Actor Active Household Count 1!
                            return null; 
                        }

                        // mscorlib bug
                        if (size_items < 0 || size_items > items.Length) 
                        {
#if DEBUG
                            NiecException.PrintMessagePro
                                ("GetRandomAllActorForActiveHouseholdExAA: (size_items < 0 || size_items > items.Length)", false, 100000);
#endif
                            vitems_members._size = size_items = niec_std.list_nonnull_item_count_int32(vitems_members);
                            if (size_items < 0 || size_items > items.Length)
                            {
                                NFinalizeDeath.Assert(false, "again failed: (size_items < 0 || size_items > items.Length)");
                                return null;
                            }
                        }

                        var aa = PlumbBob.SelectedActor;
                        Sim[] list_sim = new Sim[size_items + 1];
                        int found = 0;

                        for (int i = 0; i < size_items; i++)
                        {
                            var sim_desc = items[i];
                            if (sim_desc == null)
                                continue;

                            var sim_created = sim_desc.mSim;
                            if (sim_created == null || sim_created == aa) 
                                continue;

                            list_sim[i] = sim_created;
                            found++;
                        }
                        if (found > 0)
                        {
                            return list_sim
                                [ListCollon.SafeRandomPart2.Next(found)];
                        }
//#if DEBUG
//                        else
//                        {
//                            NiecException.PrintMessagePro("GetRAFAHExAA()\nCould not find sim! [Count 1? AA]", false, 1000);
//                        }
//#endif
                    }
                }
            }
            return null;
        }

        public static int sFakeSetActorRCacheI = 0;
        [PersistableStatic]
        public static uint kFakeSetActorRCacheIMax = 25;
        public static Sim sFakeSetActorRCacheSim = null;

        public static int sFakeSetActorACacheI = 0;
        [PersistableStatic]
        public static uint kFakeSetActorACacheIMax = 3;
        public static Sim sFakeSetActorACacheSim = null;

        public static Sim FakeSetActor(Sim actor, Sim target)
        {
            if (sFakeSetActor)
            {
                if (sFakeSetActorC != null)
                {
                    if (NFinalizeDeath.GameObjectIsValid(sFakeSetActorC.ObjectId.mValue))
                    {
                        target = sFakeSetActorC;
                        goto nextFadnIn;
                    }
                }

                var sTarget = target;
                target = null;
               
                if (sFakeSetActorA) {
                    if (sFakeSetActorACacheSim != null)
                    {
                        if (NFinalizeDeath.GameObjectIsValid(sFakeSetActorACacheSim.ObjectId.mValue))
                        {
                            sFakeSetActorACacheI++;
                            if (sFakeSetActorACacheI > kFakeSetActorACacheIMax)
                            {
                                sFakeSetActorACacheI = 0;
                                sFakeSetActorACacheSim = null;
                                
                            }
                            else
                            {
                                target = sFakeSetActorACacheSim;
                            }
                        }
                        else sFakeSetActorACacheSim = null;
                    }

                    if (target == null)
                        target = sFakeSetActorACacheSim = GetRandomAllActorForActiveHouseholdExAA() ?? NFinalizeDeath.ActiveActor;
                }
                if (target == null && sFakeSetActorR)
                {
                    if (sFakeSetActorRCacheSim != null)
                    {
                        if (NFinalizeDeath.GameObjectIsValid(sFakeSetActorRCacheSim.ObjectId.mValue))
                        {
                            sFakeSetActorRCacheI++;
                            if (sFakeSetActorRCacheI > kFakeSetActorRCacheIMax)
                            {
                                sFakeSetActorRCacheI = 0;
                                sFakeSetActorRCacheSim = null;

                            }
                            else
                            {
                                target = sFakeSetActorRCacheSim;
                            }
                        }
                        else sFakeSetActorRCacheSim = null;
                    }
                    if (target == null)
                        target = sFakeSetActorRCacheSim = NFinalizeDeath.GetRandomSim();//((Sim item) => item != sFakeSetActorRCacheSim);
                }
                if (target == null)
                {
                    target = actor ?? sTarget;
                }
            nextFadnIn:
                if (sFakeSetActorFoFadeIn)
                {
                    var ObjectID = target.ObjectId; // check null
                    ScriptCore.World.World_ObjectSetHiddenFlags(ObjectID.mValue, 0);// (uint)((int)ScriptCore.World.World_ObjectGetHiddenFlags(ObjectID.mValue) & -2));
                    ScriptCore.World.World_ObjectSetOpacity(ObjectID.mValue, 1, 1);
                }
            }
           
            return target;
        }

        public static void FinalizeSimDeathPro(SimDescription deadSim, Household originalHousehold, bool requestSocialWorkerIfNeeded)
        {
            if (deadSim == null) return;
            MidlifeCrisisManager.OnSimDied(deadSim);
            //Urnstone.FinalizeSimDeathRelationships(deadSim, 0f);
            NFinalizeDeath.FinalizeSimDeathRelationships(deadSim, 0f);
            if (deadSim.CareerManager != null)
            {
                deadSim.CareerManager.LeaveAllJobs(Sims3.Gameplay.Careers.Career.LeaveJobReason.kDied);
            }
            if (deadSim.SkillManager != null) // Fix 03/05/2019
            {
                RockBand skill = deadSim.SkillManager.GetSkill<RockBand>(SkillNames.RockBand);
                if (skill != null)
                {
                    skill.BandMemberDied();
                }
            }
            deadSim.Contactable = false;
            deadSim.Marryable = false;
            Urnstone.CheckForAbandonedChildren(deadSim, originalHousehold, requestSocialWorkerIfNeeded);
            TraitManager traitManager = deadSim.TraitManager; // Fix 03/05/2019
            if (traitManager != null) // Fix 03/05/2019
            {
                if (deadSim.DeathStyle == SimDescription.DeathType.MummyCurse && !traitManager.HasElement(TraitNames.Evil))
                {

                    if (traitManager.HasElement(TraitNames.Good))
                    {
                        traitManager.RemoveElement(TraitNames.Good);
                    }
                    else
                    {
                        Trait randomElement = traitManager.GetRandomElement();
                        if (randomElement != null)
                        {
                            traitManager.RemoveElement(randomElement.Guid);
                        }
                    }
                    traitManager.AddElement(TraitNames.Evil);
                }
                else if (deadSim.DeathStyle == SimDescription.DeathType.PetOldAgeBad)
                {
                    TraitManager traitManager2 = deadSim.TraitManager;
                    if (!traitManager2.HasElement(TraitNames.NoisyPet))
                    {
                        if (traitManager2.HasElement(TraitNames.QuietPet))
                        {
                            traitManager2.RemoveElement(TraitNames.QuietPet);
                        }
                        traitManager2.AddElement(TraitNames.NoisyPet);
                    }
                    if (!traitManager2.HasElement(TraitNames.AggressivePet))
                    {
                        if (traitManager2.HasElement(TraitNames.FriendlyPet))
                        {
                            traitManager2.RemoveElement(TraitNames.FriendlyPet);
                        }
                        traitManager2.AddElement(TraitNames.AggressivePet);
                    }
                }
            }
            MiniSimDescription miniSimDescription = MiniSimDescription.Find(deadSim.SimDescriptionId);
            if (miniSimDescription != null)
            {
                miniSimDescription.UpdateForLocalization(deadSim);
            }
            if (___bOpenDGSIsInstalled_)
                EventTracker.SendEvent(new SimDescriptionEvent(EventTypeId.kSimDied, deadSim));
            else {

                try
                {
                    EventTracker.SendEvent(new SimDescriptionEvent(EventTypeId.kSimDied, deadSim));
                }
                catch (ResetException)
                {
                    throw;
                }
                catch (StackOverflowException)
                {
                    throw;
                }
                catch { }
                NiecTask.Perform(ScriptExecuteType.Threaded, delegate {
                    while (true) {
                        Simulator.Sleep(0);
                        var r = EventTracker.sInstance;

                        if (r != null && r.mActiveList != null && r.mActiveList.Count > 29)
                        {
                            Simulator.Sleep(35);
                        }

                        if (NFinalizeDeath._IsActiveHousehold(deadSim.Household)) 
                            break;
                        EventTracker.SendEvent(new SimDescriptionEvent(EventTypeId.kSimDied, deadSim));
                    }
                    NFinalizeDeath.CheckYieldingContext();
                });
            }
        }












        public static bool ForceUnsafeD = false;

        public bool OkRealSocl = false;

        public Sim Worker;

        public bool OkSuusse = false;

        public bool OkSuusseD = false;

        public bool OkSuusseDD = false;


        public static bool __bIsGrimReaper(Sim target)
        {
            if (!___bOpenDGSIsInstalled_)
            {
                SimDescription simd = target.SimDescription;
                if (simd == null)
                {
                    try
                    {
                        target.mSimDescription = NiecMod.Helpers.Create.NiecNullSimDescription();
                        target.mSimDescription.mSim = target;
                        NFinalizeDeath._MoveInventoryItemsToAFamilyMember(target, PlumbBob.SelectedActor);
                    }
                    catch (ResetException)
                    { throw; }
                    catch { }
                    NFinalizeDeath.ForceDestroyObject(target);
                    return true;
                }
                if ((simd.CreatedByService is global::Sims3.Gameplay.Services.GrimReaper) || (simd.Service is global::Sims3.Gameplay.Services.GrimReaper))
                {
                    return true;
                }

                /*
                Autonomy automoy = target.Autonomy;
                if (automoy == null)
                    return false;

                SituationComponent sSituationComponent = automoy.SituationComponent;
                if (sSituationComponent == null)
                    return false;

                List<Situation> listSituations = sSituationComponent.Situations;
                if (listSituations == null)
                    return false;




                Sims3.Gameplay.Services.GrimReaperSituation
                grimReaperSituation = Sims3.Gameplay.Services.ServiceSituation.FindServiceSituationInvolving(target) as Sims3.Gameplay.Services.GrimReaperSituation;


                if (grimReaperSituation != null) return true;
                */
                //if (((simd.Service ?? simd.CreatedByService) is Sims3.Gameplay.Services.GrimReaper)) {
                
            }
            return false;
        }





        public static uint WorkingNiecHelperSituationCount
        {
            get
            {
                return Spawn.RunningWorkingNiecHelperSituation;
            }
        }

        [PersistableStatic]
        public static bool bUnsafeRunReapSoulIsSelectable = false;

        public static bool UnsafeRunReapSoul(Sim Actor) {
            if (Actor == null) return false;
            if (!___bOpenDGSIsInstalled_) return true;
            if (bUnsafeRunReapSoulIsSelectable)
            {
                return true;
            }
            if (Actor.IsSelectable) 
                return true;
            return false;
        }

        // Methods
        protected NiecHelperSituation()
        { }

        public NiecHelperSituation(Lot lot, Sim worker)
            : base(lot)
        {
            Worker = worker;
            if (worker != null)
            {
                var debug_nhsFound = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(worker);
                if (debug_nhsFound != null)
                {
                    var text = "debug_nhsFound! ST:\n" + NFinalizeDeath.Get_Stack_Trace();
                    NiecException.PrintMessagePro(text, false, 100);
                    NiecException.WriteLog(text);
                }
            }
        }


        public override void OnParticipantDeleted(Sim participant)
        {
            if (participant == Worker)
            {
                if (___bOpenDGSIsInstalled_)
                    CleanUp__();
                base.Exit();
            }
            //base.OnParticipantDeleted(participant);
        }

        public static bool bbb_SafeGhostToSim = false;

        public static  bool ReapSoul_SafeGhostToSim(Sim Target) {
            if (global::NiecMod.Helpers.NiecRunCommand.looptargetdied3_data) return true;
            if (Target == null) return false;
            if (Target == global::NiecMod.Helpers.NiecRunCommand.looptargetdied_data || Target == global::NiecMod.Helpers.NiecRunCommand.looptargetdied2_data) return true;
            //if (!___bOpenDGSIsInstalled_ && NFinalizeDeath.IsAllActiveHousehold_SimObject(Target))
            //{
            //    return true;
            //}
            if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Target)) 
                return true;
            return bbb_SafeGhostToSim;
        }

        public static NiecHelperSituation Create(Lot lot, Sim workerSim)
        {
            if (workerSim == null)
                throw new ArgumentNullException("workerSim");
            //NiecHelperSituation niecHelperSituation = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(workerSim);
            //if (niecHelperSituation != null)
            //    return niecHelperSituation;

            ulong objID = workerSim.ObjectId.mValue;
            if (objID == 0 || !NFinalizeDeath.GameObjectIsValid(objID)) 
                return null;

            if (lot == null)
                lot = workerSim.LotCurrent ?? (workerSim.mLotCurrent = LotManager.GetWorldLot());

            NFinalizeDeath.Assert(lot != null, "lot is null");

            NiecHelperSituation niecHelperSituation = new NiecHelperSituation(lot, workerSim);

            NFinalizeDeath.Assert(niecHelperSituation != null, "failed to create niecHelperSituation\nMono bug?");

            if (niecHelperSituation == null)
                throw new NullReferenceException("niecHelperSituation == null");

            //if (___bOpenDGSIsInstalled_)
            {
                 niecHelperSituation.SetState(new NiecHelperSituation.Spawn(niecHelperSituation));
            } 
            return niecHelperSituation;
        }

        public static NiecHelperSituation ExistsOrCreate(Sim workerSim, Lot lot = null)
        {
            if (workerSim == null)
                throw new ArgumentNullException("workerSim");
            NiecHelperSituation niecHelperSituation = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(workerSim);
            if (niecHelperSituation != null)
                return niecHelperSituation;
            niecHelperSituation = Create(lot, workerSim);
            return niecHelperSituation;
        }

        public static NiecHelperSituation ExistsOrCreateAndAddToSituationList(Sim workerSim, Lot lot = null)
        {
            var niecHelperSituation = ExistsOrCreate(workerSim, lot);
            NFinalizeDeath.CanAddSituation(workerSim, niecHelperSituation);
            return niecHelperSituation;
        }

        public InteractionInstance CreateInteraction(Sim Target)
        {
            if (Worker == null)
                throw new ObjectDisposedException("NiecHelperSituation", "Worker == null");
            if (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Worker) == null)
                throw new ObjectDisposedException("NiecHelperSituation", "NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Worker) == null");
            if (Target == null)
                throw new ArgumentNullException("Target");
            return (
                CreateInstance_internal (
                    p_target: Target,
                    p_actor: Worker,
                    priority: new InteractionPriority (
                        NiecMod.Instantiator.RootIsOpenDGSInstalled ?
                            (InteractionPriorityLevel)100 :
                        (InteractionPriorityLevel)12, 999f
                    ),
                    isAutonomous: false,
                    cancellableByPlayer: true
                )
            );
        }


        internal InteractionInstance CreateInstance_internal(IGameObject p_target, IActor p_actor, InteractionPriority priority, bool isAutonomous, bool cancellableByPlayer)
        {
            NFinalizeDeath.Assert(NHSDefinition != null, "NHSDefinition == null");
            if (___bOpenDGSIsInstalled_)
            {
                return NHSDefinition.CreateInstance(p_target, p_actor, priority, isAutonomous, cancellableByPlayer);
            }
            
            InteractionObjectPair iop = new InteractionObjectPair(NHSDefinition, p_target);
            InteractionInstanceParameters parameters = new InteractionInstanceParameters(iop, p_actor, priority, isAutonomous, cancellableByPlayer);
            InteractionInstance inCreate = null;

            if (!OkSuusse) {
                inCreate = new NiecAppear();
            }
            else {
                inCreate = new ReapSoul();
            }

            NFinalizeDeath.Assert(inCreate != null, "failed to create NHSInteraction!");
            inCreate.Init(ref parameters);

            try
            {
                inCreate.ConfigureInteraction();
                return inCreate; 
            } 
            catch (StackOverflowException)
            {
                NFinalizeDeath.Assert("NHS:CreateInstance_internal() StackOverflowException!");
                throw;
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception)
            { }

            return inCreate;
        }

        public static InteractionInstance CreateInstance_internalX<TInteraction>(InteractionDefinition definition, IGameObject p_target, IActor p_actor, InteractionPriority priority, bool isAutonomous, bool cancellableByPlayer) where TInteraction : InteractionInstance, new()
        {
            NFinalizeDeath.Assert(definition != null, "definition == null");
            if (___bOpenDGSIsInstalled_)
            {
                return definition.CreateInstance(p_target, p_actor, priority, isAutonomous, cancellableByPlayer);
            }

            InteractionObjectPair iop = new InteractionObjectPair(definition, p_target);
            InteractionInstanceParameters parameters = new InteractionInstanceParameters(iop, p_actor, priority, isAutonomous, cancellableByPlayer);
            InteractionInstance inCreate = null;

            inCreate = new TInteraction();

            NFinalizeDeath.Assert(inCreate != null, "failed to create NHSInteraction!");
            inCreate.Init(ref parameters);

            try
            {
                inCreate.ConfigureInteraction();
                return inCreate;
            }
            catch (StackOverflowException)
            {
                NFinalizeDeath.Assert("NHS:CreateInstance_internal() StackOverflowException!");
                throw;
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception)
            { }

            return inCreate;
        }




        public InteractionInstance CreateInteractionToAddIQ(Sim Target)
        {
            if (Worker == null)
                throw new ObjectDisposedException("NiecHelperSituation", "Worker == null");
            if (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Worker) == null)
                throw new ObjectDisposedException("NiecHelperSituation", "NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Worker) == null");
            if (Target == null)
                return null;

            if (SimHasBeenDestroyed(Worker))
                return null;

            var iq = Worker.InteractionQueue;
            if (iq == null || iq.mInteractionList == null) 
                return null;

            var nhsI = CreateInteraction(Target);
            if (nhsI != null)
                iq.Add(nhsI);

            return nhsI;
        }

        public InteractionDefinition NHSDefinition {
            get { return GetNHSDefinition(OkSuusse); }
        }

        public static InteractionDefinition GetNHSDefinition(bool a_OkSuusse)
        {
            return (!a_OkSuusse ? NiecAppear.Singleton : ReapSoul.Singleton);
        }

        public override bool CanSimAgeUp(Sim s)
        {
            if (Worker != null && s == Worker)
            {
                SimDescription WorkerSimDesc = Worker.SimDescription;
                if (WorkerSimDesc != null && WorkerSimDesc.AgingState != null)
                {
                    if (!WorkerSimDesc.IsEP11Bot)
                        WorkerSimDesc.AgingState.ResetAndExtendAgingStage(0);
                }
                return false;
            }
            else
                return base.CanSimAgeUp(s);
        }

        public override void OnReset(Sim s)
        {
            if (s == Worker)
            {
                CleanUp__();
                base.OnReset(s);
            }
        }

        public override void Dispose()
        {
            CleanUp__();
            NFinalizeDeath.SimRemove_SituationList(Worker, this, true);

            if (!___bOpenDGSIsInstalled_)
                Worker = null;
            if (sAllSituations != null)
                base.Dispose();
        }

        public void CleanUp__() 
        {
            if (___bOpenDGSIsInstalled_) {
                NFinalizeDeath.List_FastClearEx(ref mInteractions);
                NFinalizeDeath.List_FastClearEx(ref mForcedInteractions);
            }

            StopGrimReaperSmoke();
            
            if (mScubaDeathJig != null) {
                NFinalizeDeath.ForceDestroyObject(mScubaDeathJig);
                mScubaDeathJig = null;
            }

            if (ScaredReactionBroadcaster != null)
            {
                if (!___bOpenDGSIsInstalled_) {
                    var lot = LotManager.GetWorldLot();
                    foreach (var item in NFinalizeDeath.SC_GetObjects<GameObject>())
                    {
                        if (item == null || item.mLotCurrent!= null) continue;
                        item.mLotCurrent = lot;
                    }
                }
                ScaredReactionBroadcaster.Dispose();
                ScaredReactionBroadcaster = null;
            }
            
            LastSimOfHousehold = null;
            LastGraveCreated = null;

            PetSavior = null;

            OkSuusseDD = false;
            OkSuusseD = false;
            OkSuusse = false;

            if (ReaperLoop != null)
                ReaperLoop.Dispose();
            ReaperLoop = null;

            if (SMCDeath != null)
                SMCDeath.Dispose();
            SMCDeath = null;
        }

        public override void CleanUp()
        {
            try
            {
                CleanUp__();
                base.CleanUp();
            }
            catch (ResetException)
            { throw; }
            catch (Exception)
            { }
            
        }




        // Lib New

        public StateMachineClient SMCDeath;

        public ObjectSound ReaperLoop;

        public List<Sim> ignoreList = new List<Sim>();




        // Lib New 2

        public static bool isdgmods = false;
        public static List<Sim> RuningDeadSimList = new List<Sim>(250); // gc high size

        public static void InitClass() {
            IsGrimReaperFast(); // cache
            if (!___bOpenDGSIsInstalled_)
            {
                isdgmods = AssemblyCheckByNiec.IsInstalled(NiecMod.Instantiator.DGSModsAssembly);

                kLoopAllSimFadnIn = true;
                sFakeSetActorR = true;
                sFakeSetActorA = false;
                sFakeSetActorFoFadeIn = true;

                __kinkymdisInstalled = AssemblyCheckByNiec.IsInstalled("Oniki_KinkyMod") && NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.___bOpenDGSIsInstalled_;

                RuningDeadSimList = new List<Sim>(500);

                NFinalizeDeath._AntiSpy_ThrowDefault = new NMAntiSpyException("") { No_EA_Collect_Exception_ToString = true };

                Spawn.FastGoodFindPOS =// __acorewIsnstalled__ && 
                    !isdgmods;

                NFinalizeDeath.testnomessbox_b = NiecHelperSituation.__acorewIsnstalled__ && !isdgmods;
            }
            else
            {
                sFakeSetActor = false;
                sFakeSetActorR = false;
                sFakeSetActorA = false;
                sFakeSetActorC = null;
            }
        }

        public ReactionBroadcaster ScaredReactionBroadcaster;

        public Urnstone LastGraveCreated;

        public Sim ChessOpponent;

        public IChessTable ChessTable;

        public IVendingMachine VendingMachine;

        public bool ChessMatchWon;

        public bool FadeDeathIn;

        public Sim LastSimOfHousehold;



        public Sim PetSavior;

        public VisualEffect mGrimReaperSmoke;

        public bool mIsFirstSim = true;

        public SocialJig mScubaDeathJig;


        // End Lib 2







        public Sim FindClosestDeadSim()
        {
            Sim closestObject = GlobalFunctions.GetClosestObject(Worker, false, true, true, 0, ignoreList, VerifyDeadSimSkipSelected);
            if (closestObject == null)
            {
                closestObject = GlobalFunctions.GetClosestObject(Worker, false, true, true, 0, ignoreList, VerifyDeadSim);
            }
            return closestObject;
        }



        public bool VerifyDeadSim(IGameObject simToCheck, ref float score)
        {
            Sim sim = simToCheck as Sim;
            return sim != null && (sim.SimDescription.DeathStyle != SimDescription.DeathType.None && !sim.SimDescription.IsGhost);
        }

        public bool VerifyDeadSimSkipSelected(IGameObject simToCheck, ref float score)
        {
            if (this.VerifyDeadSim(simToCheck, ref score))
            {
                Sim sim = simToCheck as Sim;
                return !sim.IsActiveSim;
            }
            return false;
        }

        public static void safePosRIPObject(Sim Actor, Sim Target, Urnstone RIPObject)
        {
            if (Actor != null && Target != null && RIPObject != null)
            {
                try
                {
                    for (int i = 0; i < 20; i++)
                    {
                        RIPObject.RemoveFromUseList(Actor);
                    }
                    //RIPObject.SetOpacity(0f, 0f);
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { }

                try
                {
                    StyledNotification.Format format = new StyledNotification.Format("AntiNPCSim:\nRIP " + Target.GetLocalizedName(), RIPObject.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                    StyledNotification.Show(format);
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { }
                if (RIPObject.LotCurrent == null) { 
                    RIPObject.mLotCurrent = LotManager.GetWorldLot(); 
                }
                if (RIPObject.LotCurrent.IsWorldLot) {
                    try
                    {
                        RIPObject.SetPosition(NiecAppear.getPositionForGhost(NFinalizeDeath.ActiveActor_AAndChildAndTeen ?? Actor, Actor));
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    { }
                }
                if (RIPObject.LotCurrent.IsWorldLot)
                {
                    try
                    {
                        NiecAppear.placeGraveStone(Actor, Target, RIPObject);
                        if (RIPObject.LotCurrent.IsWorldLot)
                        {
                            List<Lot> lieastwt = new List<Lot>();
                            Lot lotwt = null;
                            foreach (object obtj in LotManager.AllLotsWithoutCommonExceptions)
                            {
                                Lot lott2 = (Lot)obtj;
                                if (lott2 != null)
                                    lieastwt.Add(lott2);
                            }

                            if (lieastwt.Count != 0)
                            {
                                lotwt = RandomUtil.GetRandomObjectFromList<Lot>(lieastwt, ListCollon.SafeRandom);
                            }
                            RIPObject.SetPosition(lotwt.Position);
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
        }


        public static bool ShouldDoDeathEvent(Sim deadSim)
        {
            if (deadSim != null && NiecMod.Helpers.NiecRunCommand.looptargetdied_data != deadSim)  
            {
                if (deadSim.Household != null && deadSim.Household.IsActive || deadSim.LotCurrent == LotManager.ActiveLot)
                {
                    return true;
                }
                var ph = PlumbBob.SelectedActor;
                if (ph != null && ph.LotHome == deadSim.LotCurrent) 
                    return true;
            }
            
            return false;
        }


        // End Lib 1








        // New


        public void AddRelationshipWithEverySimInHousehold()
        {
            try
            {
                if (Lot != null)
                    // && Lot.IsResidentialLot)&& Lot.EffectiveHousehold != null)
                {
                    foreach (Sim allActor in Lot.GetAllActors())
                    {
                        Relationship relationship = Relationship.Get(Worker, allActor, true);
                        if (relationship != null)
                            relationship.MakeAcquaintances();
                    }
                }
            }
            catch
            { }

        }


























        public Sim FindClosestDeadDivingSim()
        {
            Sim closestObject = GlobalFunctions.GetClosestObject(Worker, false, true, true, 0, ignoreList, this.VerifyDeadDivingSimSkipSelected);
            if (closestObject == null)
            {
                closestObject = GlobalFunctions.GetClosestObject(Worker, false, true, true, 0, ignoreList, this.VerifyDeadDivingSim);
            }
            return closestObject;
        }

        public bool VerifyDeadDivingSim(IGameObject simToCheck, ref float score)
        {
            Sim sim = simToCheck as Sim;
            if (sim == null)
            {
                return false;
            }
            if (sim.Posture is ScubaDiving && sim.SimDescription.DeathStyle != 0 && !sim.SimDescription.IsGhost)
            {
                return true;
            }
            return false;
        }

        public bool VerifyDeadDivingSimSkipSelected(IGameObject simToCheck, ref float score)
        {
            if (VerifyDeadDivingSim(simToCheck, ref score))
            {
                Sim sim = simToCheck as Sim;
                return !sim.IsActiveSim;
            }
            return false;
        }




























        private void StartGrimReaperSmoke()
        {
            if (mGrimReaperSmoke == null)
            {
                mGrimReaperSmoke = VisualEffect.Create("reaperSmokeConstant");
                mGrimReaperSmoke.ParentTo(Worker, Sim.FXJoints.Pelvis);
                mGrimReaperSmoke.Start();
            }
        }




        

        private void StopGrimReaperSmoke()
        {
            if (mGrimReaperSmoke != null)
            {
                mGrimReaperSmoke.Stop();
                mGrimReaperSmoke.Dispose();
                mGrimReaperSmoke = null;
            }
        }











        public class ReapSoul : SocialInteraction, INHSInteraction
        {
            private sealed class Definition : InteractionDefinition<Sim, Sim, ReapSoul>, IDontNeedToBeCheckedInResort, IScubaDivingInteractionDefinition, IIgnoreIsAllowedInRoomCheck, IAllowedOnClosedVenues, IOverridesAgeTests, IUseTargetForAutonomousIsAllowedInRoomCheck,  IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
            {
                public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair interaction)
                {
                    //return "ReapSoul Master";
                    return Localization.LocalizeString(false, "Gameplay/Actors/Sim/ReapSoul:InteractionName");
                }

                public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    if (actor == null) return false;
                    if (target == null) return false;
                    if (isAutonomous) return false;

                    if (__bIsGrimReaper(target)) 
                        return false;


                    NiecHelperSituation situationOfType = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(actor);
                    if (situationOfType == null) return false;
                    if (UnsafeRunReapSoul(actor) && (situationOfType.OkSuusse || situationOfType.OkSuusseDD))
                    {
                        return true;
                    }
                    return false;
                }

                
                

                public override string[] GetPath(bool bPath)
                {
                    return new string[] { "Niec Helper Situation" };
                }

                public SpecialCaseAgeTests GetSpecialCaseAgeTests()
                {
                    return SpecialCaseAgeTests.None;
                }

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
            }
            public override void PostureTransitionFailed(bool transitionExitResult)
            {
                if (___bOpenDGSIsInstalled_)
                    base.PostureTransitionFailed(transitionExitResult);
                else if (Actor != null && Actor.ObjectId == Simulator.CurrentTask)
                    NFinalizeDeath._RunInteraction(this);
            }

            //public override bool Test()
            //{
            //    if (___bOpenDGSIsInstalled_)
            //         return base            .Test();
            //
            //    else if (Actor != null && Actor.ObjectId == Simulator.CurrentTask)
            //         return NFinalizeDeath  ._RunInteraction(this);
            //
            //    else return                 true;
            //}

            //public bool ShouoldGetTargetLot = false;
            public override Lot GetTargetLot()
            {
                if (!___bOpenDGSIsInstalled_ && Simulator.CheckYieldingContext(false) && NFinalizeDeath.GetCurrentGameObjectFast<Sim>() != null)
                {
                    var p = NStackTrace.IsCallingMyMethedLite("CountBabiesToddlersAndCaregivers", true, 3);
                    try
                    {
                        NFinalizeDeath.CheckACoreThrowNRaasErrorTrap();
                    }
                    catch (NMAntiSpyException)
                    {
                        if (Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                            Actor.mInteractionQueue.mCurrentTransitionInteraction = null;
                        NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate
                        {
                            var t = NFinalizeDeath._GetCHeadInteraction(Actor);
                            if (t != null && NFinalizeDeath.InteractionIsNiecHelperSituation(t))
                                NFinalizeDeath._RunInteraction(t);
                        });
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }

                    if (Actor.mInteractionQueue != null && Actor.mInteractionQueue.mInteractionList != null)
                        niec_std.list_remove(Actor.mInteractionQueue.mInteractionList, this);

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(0);

                    try
                    {
                        if (__acorewIsnstalled__)
                        {
                            NiecTask.CreateWaitPerformWithExecuteType(NFinalizeDeath.GetCurrentExecuteType(), delegate
                            {
                                NFinalizeDeath._RunInteraction(this);
                            }).WaitingCanThrow();
                        }
                        else
                        {
                            NFinalizeDeath._RunInteraction(this);
                        }
                    }
                    catch (StackOverflowException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        NFinalizeDeath.ThrowResetException(null);
                        throw;
                    }
                    catch (ResetException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }
                    catch
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        if (!Simulator.CheckYieldingContext(false))
                            NFinalizeDeath.ThrowResetException(null);

                        throw;
                    }
                }
                return base.GetTargetLot();
            }

            public override Vector3 GetTargetPosition()
            {
                if (!___bOpenDGSIsInstalled_ && Simulator.CheckYieldingContext(false) && NFinalizeDeath.GetCurrentGameObjectFast<Sim>() != null)
                {
                    var p = NStackTrace.IsCallingMyMethedLite("CountBabiesToddlersAndCaregivers", true, 3);
                    try
                    {
                        NFinalizeDeath.CheckACoreThrowNRaasErrorTrap();
                    }
                    catch (NMAntiSpyException)
                    {
                        if (Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                            Actor.mInteractionQueue.mCurrentTransitionInteraction = null;
                        NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate
                        {
                            var t = NFinalizeDeath._GetCHeadInteraction(Actor);
                            if (t != null && NFinalizeDeath.InteractionIsNiecHelperSituation(t))
                                NFinalizeDeath._RunInteraction(t);
                        });
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }

                    if (Actor.mInteractionQueue != null && Actor.mInteractionQueue.mInteractionList != null)
                        niec_std.list_remove(Actor.mInteractionQueue.mInteractionList, this);

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(0);

                    try
                    {
                        if (__acorewIsnstalled__)
                        {
                            NiecTask.CreateWaitPerformWithExecuteType(NFinalizeDeath.GetCurrentExecuteType(), delegate
                            {
                                NFinalizeDeath._RunInteraction(this);
                            }).WaitingCanThrow();
                        }
                        else
                        {
                            NFinalizeDeath._RunInteraction(this);
                        }
                    }
                    catch (StackOverflowException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        NFinalizeDeath.ThrowResetException(null);
                        throw;
                    }
                    catch (ResetException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }
                    catch
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        if (!Simulator.CheckYieldingContext(false))
                            NFinalizeDeath.ThrowResetException(null);

                        throw;
                    }
                }
                return base.GetTargetPosition();
            }

            public virtual bool OnQueueStomp() // test aweCore
            {
                if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.GetCurrentGameObjectFast<Sim>() != null)
                    return NFinalizeDeath._RunInteraction(this);
                return false;
            }

            //public override void Init(ref InteractionInstanceParameters parameters)
            //{
            //    if (___bOpenDGSIsInstalled_)
            //        base.Init(ref parameters);
            //    else { 
            //
            //    }
            //}

            public enum DeathProgress
            {
                None,
                
                GraveCreated,
                GravePlaced,
                DeathFlowerStarted,
                DeathFlowerPostEvent,
                UnluckyStarted,
                UnluckyPostEvent,
                NormalStarted,
                Complete
            }

            public enum DEBUGRUNTIME
            {
                DEBUG_0,
                DEBUG_1,
                DEBUG_1B,
                DEBUG_2,
                DEBUG_3,
                DEBUG_4,
                DEBUG_5,
                DEBUG_6,
                DEBUG_7,
                DEBUG_8,
                DEBUG_9,
                DEBUG_10,
                DEBUG_11,
                DEBUG_12,
                DEBUG_13,
                DEBUG_14,
                DEBUG_15,
                DEBUG_16,
                DEBUG_17,
                DEBUG_18,
                DEBUG_19,
                DEBUG_20
            }
            public DEBUGRUNTIME debug_runtime;
            //public bool shuoldbRunSB;

            public static readonly InteractionDefinition Singleton = new Definition();

            public StateMachineClient mSMCDeath;

            public Urnstone mGrave;

            public Vector3 mGhostPosition;

            public VisualEffect mDeathEffect;

            public Household mDeadSimsHousehold;

            public NiecHelperSituation mSituation;

            public DeathProgress mDeathProgress;

            public bool mWasMemberOfActiveHousehold = false;

            public DeathFlower mDeathFlower;

            public VisualEffect mGhostExplosion;
           
            
            public override void ConfigureInteraction()
            {
                onRuntimeThisRun = false;
                if (!___bOpenDGSIsInstalled_)
                {
                    try
                    {
                        if (Actor.mInteractionQueue != null && Actor.mInteractionQueue.mInteractionList != null)
                        {
                            try
                            {
                                foreach (InteractionInstance interactionInstance in Actor.mInteractionQueue.mInteractionList.ToArray()) // Cant Cancel Fix
                                {
                                    if (interactionInstance != null)
                                    {
                                        interactionInstance.mbOnStopCalled = true;
                                        interactionInstance.CancellableByPlayer = true;
                                        interactionInstance.mMustRun = false;
                                        interactionInstance.mHidden = false;
                                    }
                                }
                            }
                            catch (ResetException)
                            { throw; }
                            catch (Exception)
                            { }
                        }

                        try
                        {
                            CancellableByPlayer = true;
                            if (mSituation == null)
                            {
                                mSituation = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Actor);//Actor.GetSituationOfType<NiecHelperSituation>();
                            }

                            //if (!RuningDeadSimList.Contains(Target))

                            if (niec_std.array_indexof(RuningDeadSimList._items, Target) == -1)
                                RuningDeadSimList.Add(Target);
                        }
                        catch (StackOverflowException)
                        {
                            if (___bOpenDGSIsInstalled_)
                                throw;
                            NFinalizeDeath.SafeForceTerminateRuntime();
                            return;
                        }

                        SetPriority((InteractionPriorityLevel)12, 2f);
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    { }
                    try
                    {
                        Actor.AddExitReason(ExitReason.Default | ExitReason.Finished | ExitReason.HigherPriorityNext | ExitReason.CanceledByScript);
                        if (!bShouldOnSavingGame && Actor.IsSelectable && Actor.Autonomy != null && Actor.Autonomy.Motives != null)
                            NFinalizeDeath.Sim_MaxMood(Actor); //Actor.Autonomy.Motives.MaxEverything();
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }


                    /*
                    try
                    {
                        Actor.InteractionQueue.CancelAllInteractions();
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    {}
                     * */
                }
            }

            public ulong GraveObjectId
            {
                get
                {
                    return mGrave.ObjectId.Value;
                }
            }
            public bool onRuntimeThisRun = true;
            public override void Cleanup()
            {
                
                if (!___bOpenDGSIsInstalled_ && Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                {
                    try
                    {
                        NFinalizeDeath.CheckACoreThrowNRaasErrorTrap();
                    }
                    catch (NMAntiSpyException) 
                    {
                        if (Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                            Actor.mInteractionQueue.mCurrentTransitionInteraction = null;
                        NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate
                        {
                            var t = NFinalizeDeath._GetCHeadInteraction(Actor);
                            if (t != null && NFinalizeDeath.InteractionIsNiecHelperSituation(t))
                            NFinalizeDeath._RunInteraction(t);
                        });
                        throw;
                    }
                }
                if (!onRuntimeThisRun && Actor != null && InteractionObjectPair != null && Target != null)
                {
                    onRuntimeThisRun = true;
                    if (NFinalizeDeath.OnCancelTryRunInteraction(Actor, this))
                        return;
                }

                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    niec_std.list_remove(RuningDeadSimList, Target); // RuningDeadSimList.Remove(Target);
               


                if (Notfixdgs)
                {
                    return;
                }
                bool bbbNotEventCallbackResurrectSimBool = false;
                try
                {
                    /*
                    if (Target.Service is Sims3.Gameplay.Services.GrimReaper)
                    {
                        if (!TwoButtonDialog.Show("ReapSoul CleanUp: Killing the " + Target.Name + " [GrimReaper] will prevent souls to cross over to the other side. If this happens, Sims that die from now on will be trapped between this world and the next, and you'll end up with a city full of dead bodies laying around. Are you sure you want to kill Death itself?", "Yes", "No"))
                        {
                            Notfixdgs = true;
                            mDeathProgress = DeathProgress.Complete;
                            return;
                        }
                    }
                     * */


                    if (AlarmManager.Global != null)
                    {
                        if (AlarmCheckSocialLoop != AlarmHandle.kInvalidHandle)
                            AlarmManager.Global.RemoveAlarm(AlarmCheckSocialLoop);
                        AlarmCheckSocialLoop = AlarmHandle.kInvalidHandle;
                    }
                    

                    if (mSituation == null)
                    {
                        mSituation = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Actor);//Actor.GetSituationOfType<NiecHelperSituation>();
                    }

                    // 21:44 13/01/2020 // Fix Target 15/9/2020
                    if (mSituation == null || Target == null)  {
                        //goto end_done;
                        return;
                    }

                    if (Target.SimDescription == null)
                    {
                        if (___bOpenDGSIsInstalled_) // 21:44 13/01/2020
                            Target.mSimDescription = ListCollon.NullSimSimDescription;
                        goto end_done;
                    }

                    if (Target.SimDescription.DeathStyle == SimDescription.DeathType.None && !ReapSoul_SafeGhostToSim(Target))
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
                        if (!Target.SimDescription.IsFrankenstein)
                        {
                            list.Add(SimDescription.DeathType.Electrocution);
                        }
                        list.Add(SimDescription.DeathType.Burn);
                        if (Target.SimDescription.Elder)
                        {
                            list.Add(SimDescription.DeathType.OldAge);
                        }
                        if (Target.SimDescription.IsWitch)
                        {
                            list.Add(SimDescription.DeathType.HauntingCurse);
                        }
                        SimDescription.DeathType randomObjectFromList = RandomUtil.GetRandomObjectFromList(list, ListCollon.SafeRandomPart2);
                        Target.SimDescription.SetDeathStyle(randomObjectFromList, Target.IsSelectable);
                        Target.SimDescription.IsGhost = true;
                    }

                    if (mDeathProgress != DeathProgress.Complete)
                    {

                        if (!___bOpenDGSIsInstalled_ && !ReapSoul_SafeGhostToSim(Target))
                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                        else if (___bOpenDGSIsInstalled_ && !ReapSoul_SafeGhostToSim(Target))
                        {

                            if (Target.mActorsUsingMe != null && Target.mActorsUsingMe.Count != 0)
                                Target.mActorsUsingMe.Clear();

                            if (Target.mReferenceList != null && Target.mReferenceList.Count != 0)
                                Target.mReferenceList.Clear();

                            if (Target.mRoutingReferenceList != null && Target.mRoutingReferenceList.Count != 0)
                                Target.mRoutingReferenceList.Clear();

                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target); 
                        }




                        if (mDeathProgress == DeathProgress.None)
                        {
                            if (mGrave == null) {
                                var d = Target.SimDescription;
                                foreach (var item in NFinalizeDeath.SC_GetObjects<Urnstone>())
                                {
                                    if (item == null) continue;
                                    if (item.DeadSimsDescription == d)
                                    {
                                        mGrave = item;
                                        break;
                                    }
                                }
                            }
                            if (mGrave == null) 
                                mGrave = Urnstone.CreateGrave(Target.SimDescription, true, true);
                            if (mGrave == null) { base.Cleanup(); return; }
                            mDeathProgress = DeathProgress.GraveCreated;
                        }

                        if (mDeathProgress == DeathProgress.GraveCreated)
                        {

                            //if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, new World.FindGoodLocationParams((NFinalizeDeath.ActiveActor_ChildAndTeen ?? Actor).Position), false))
                            if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, new World.FindGoodLocationParams(Actor.Position), false))
                            {
                                //mGrave.SetPosition((NFinalizeDeath.ActiveActor_ChildAndTeen ?? Actor).Position);
                                mGrave.SetPosition(Actor.Position);
                            }

                            mGrave.OnHandToolMovement();
                            mDeathProgress = DeathProgress.GravePlaced;
                        }

                        if (Target.HasBeenDestroyed)
                            goto end_done;

                        if (mDeathProgress == DeathProgress.GravePlaced)
                        {
                            if (mGrave == null)
                            {
                                CreateGraveStone();
                                NFinalizeDeath.Assert(mGrave != null, "mGrave is null");
                            }
                            try
                            {
                                mGrave.GhostSetup(Target, false);
                            }
                            catch (ResetException)
                            { throw; }
                            catch { }
                           
                        }
                        if (mDeathFlower == null && Target.Inventory != null)
                        {
                            mDeathFlower = FindInv <DeathFlower>(Target);
                        }
                        bool isResurrected = false;
                        if (Target == NFinalizeDeath.ActiveActor || mDeathProgress == DeathProgress.UnluckyStarted || ReapSoul_SafeGhostToSim(Target))// || (Target.Household != null && Target.IsInActiveHousehold && Target.SimDescription.DeathStyle != (SimDescription.DeathType)69u))
                        {
                            isResurrected=true;
                            EventCallbackResurrectSim();
                            Target.AddExitReason(ExitReason.HigherPriorityNext);
                            Target.SimDescription.IsGhost = false;
                            Target.SimDescription.mDeathStyle = SimDescription.DeathType.None;
                            bbbNotEventCallbackResurrectSimBool = true;
                        }

                        else if (mDeathProgress == DeathProgress.DeathFlowerStarted || mDeathFlower != null && ReapSoul_SafeGhostToSim(Target))// || Target == NFinalizeDeath.ActiveActor)
                        {

                            EventCallbackResurrectSim();

                            Target.SimDescription.IsGhost = false;
                            Target.SimDescription.mDeathStyle = SimDescription.DeathType.None;

                            bbbNotEventCallbackResurrectSimBool = true;


                            Target.AddExitReason(ExitReason.HigherPriorityNext);

                            Target.Inventory.RemoveByForce(mDeathFlower);
                            mDeathFlower.Destroy();
                        }

                        else if (mDeathProgress != DeathProgress.UnluckyPostEvent)
                        {
                            if (mDeathProgress == DeathProgress.DeathFlowerPostEvent)
                            {
                                if (Target.Inventory.Contains(mDeathFlower))
                                {
                                    Target.Inventory.RemoveByForce(mDeathFlower);
                                }
                                if (mDeathFlower != null)
                                {
                                    mDeathFlower.Destroy();
                                }
                            }
                            else
                            {
                                mDeathProgress = DeathProgress.NormalStarted;
                            }
                        }

                        if (mDeathProgress == DeathProgress.NormalStarted)
                        {
                            if (isResurrected)
                            {
                                Target.SimDescription.mDeathStyle = SimDescription.DeathType.None;
                                Target.SimDescription.IsGhost = false;
                                if (Target.Motives != null)
                                    Target.Motives.MaxEverything();
                            }
                            else
                            {
                                if (Target == null)
                                {
                                    if (___bOpenDGSIsInstalled_)
                                        throw new NotSupportedException("_MoveInventoryItemsToAFamilyMember(): (Target == null)");
                                    else  return;
                                }
                                try
                                {
                                    if (Target.Inventory != null)
                                        NFinalizeDeath._MoveInventoryItemsToAFamilyMember(Target, NFinalizeDeath.HouseholdMembersToSim(Household.ActiveHousehold, true, false) ?? Actor);
                                }
                                catch (ResetException)
                                { throw; }
                                catch { }

                                try
                                {
                                    FinalizeDeath();
                                }
                                catch (ResetException)
                                { throw; }
                                catch { }

                                CleanUpAndDestroyDeadSim(true);
                            }
                        }

                        GrimReaperPostSequenceCleanup();

                        Urnstone.FogEffectTurnAllOff(Actor.LotCurrent);

                        StopGhostExplosion();
                    }
                    if (bbbNotEventCallbackResurrectSimBool) {
                        Target.SimDescription.IsGhost = false;
                        Target.SimDescription.mDeathStyle = SimDescription.DeathType.None;
                        Target.SimDescription.IsNeverSelectable = false;
                    }

                    end_done:;

                    try
                    {
                        if (Target.DeathReactionBroadcast != null)
                        {
                            Target.DeathReactionBroadcast.Dispose();
                            Target.DeathReactionBroadcast = null;
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    { }
                    try
                    {
                        if (!mFastLikeTSMReaper && mSituation.OkSuusse && mSMCDeath != null)
                        {
                            mSMCDeath.EnterState("x", "Enter");
                        }
                    }
                    catch (NotSupportedException)
                    {
                        mSituation.CleanUp__();
                    }
                    catch (SacsErrorException)
                    {
                        mSituation.CleanUp__();
                    }
                    

                    Notfixdgxs = true;

                    //mSMCDeath.EnterState("x", "EnterReaperBrushingHimself");

                    try
                    {
                        base.Cleanup();
                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception)
                    {
                        if (___bOpenDGSIsInstalled_)
                            throw;
                        //NFinalizeDeath.ActorCheckYieldingContext(Actor);
                    }
                    return;
                }
                catch (ResetException)
                { throw; }
                catch
                {
                    try
                    {
                        if (!mFastLikeTSMReaper && mSituation.OkSuusse && !Notfixdgxs)
                        {
                            mSMCDeath.EnterState("x", "Enter");
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    { }
                    try
                    {
                        base.Cleanup();
                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception)
                    {
                        if (___bOpenDGSIsInstalled_ && Simulator.CheckYieldingContext(false))
                            throw;
                        //NFinalizeDeath.ActorCheckYieldingContext(Actor);
                    }
                    
                }
                finally {
                    if (Notfixdgs || Target == null)
                    {
                        //return; 
                    }
                    else
                    {
                        try
                        {
                            SimDescription simd = Target.SimDescription;
                            if (simd == null || NFinalizeDeath.IsAllActiveHousehold_SimDesc(simd)) {
                                //return; 
                            } 
                            else
                            {
                                Urnstone RIPObject = null;
                                RIPObject = HelperNra.TFindGhostsGrave(simd);
                                bool isActiveHousehold__ = ReapSoul_SafeGhostToSim(Target);
                                
                                if (RIPObject == null && !AssemblyCheckByNiec.IsInstalled("OpenDGS") && Actor != Target && !isActiveHousehold__) //!NFinalizeDeath.IsSimFastActiveHousehold(Target) && !Target.IsInActiveHousehold)
                                {
                                    try
                                    {

                                        try
                                        {
                                            if (Target.Inventory != null)
                                                //Target.MoveInventoryItemsToSim(NFinalizeDeath.ActiveActor ?? PlumbBob.SelectedActor ?? Actor);
                                                NFinalizeDeath._MoveInventoryItemsToAFamilyMember
                                            (Target, NFinalizeDeath.HouseholdMembersToSim(Household.ActiveHousehold, true, false) ?? Actor);
                                        }
                                        catch (ResetException)
                                        {
                                            throw;
                                        }
                                        catch
                                        { }


                                        if (RIPObject == null)
                                            NFinalizeDeath.GetKillNPCSimToGhost(Target, simd.DeathStyle, NiecAppear.getPositionForGhost(Actor, Target, Actor), out RIPObject);
                                        if (RIPObject == null)
                                            RIPObject = Urnstone.CreateGrave(simd, false, true);
                                        safePosRIPObject(Actor, Target, RIPObject);
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch { }

                                }
                                if (!bbbNotEventCallbackResurrectSimBool && RIPObject == null)
                                    RIPObject = Urnstone.CreateGrave(simd, false, true);
                                else if (Actor != Target && !isActiveHousehold__) //&& !NFinalizeDeath.IsSimFastActiveHousehold(Target) && !Target.IsInActiveHousehold)
                                {
                                    if (simd == ListCollon.NullSimSimDescription) { }
                                    else
                                    {
                                        if (!___bOpenDGSIsInstalled_ || RIPObject != null)
                                            safePosRIPObject(Actor, Target, RIPObject);
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
                        //mGrave = null;
                        //mSMCDeath = null;
                    }
                }
            }

           

            public void EventCallbackFadeInReaper(StateMachineClient sender, IEvent evt)
            {
                if (IsTargetGood(Actor))
                    Actor.FadeIn(false, 3f);

            }

            public static bool CheckStackOverflowOnRoutePoolIfAwesomeMod = false;

            public void OnRoutePoolIfAM()
            {
                Route route_to_jiga = null;
                try
                {
                    if (CheckStackOverflowOnRoutePoolIfAwesomeMod)
                        throw new StackOverflowException();
                    NFinalizeDeath.SafeCall(() =>
                    {
                        CheckStackOverflowOnRoutePoolIfAwesomeMod = true;
                        route_to_jiga = mSituation.mScubaDeathJig.RouteToJigA(Actor);
                    });
                    CheckStackOverflowOnRoutePoolIfAwesomeMod = false;
                }
                catch (StackOverflowException)
                {
                    if (___bOpenDGSIsInstalled_)
                        throw;
                    NFinalizeDeath.SafeForceTerminateRuntime();
                    return; 
                }
                catch (Exception)
                { CheckStackOverflowOnRoutePoolIfAwesomeMod = false; return; }

                if (route_to_jiga != null)
                {
                    if (!route_to_jiga.PlanResult.Succeeded()) 
                        return;

                    Vector3 position_route = route_to_jiga.GetDestPoint();
                    bool routefail = true;

                    if (!NFinalizeDeath.Vector3_IsUnsafe(position_route) 
                        && !(ForceRequestGrimReaper.GetPostionTargetLot(position_route) is WorldLot))
                    {
                        position_route +=
                            (NFinalizeDeath.Random_CoinFlip() ? 1.4f : 2.5f) * NFinalizeDeath.GetForwardBase(Target.ObjectId.mValue);

                        if (!NFinalizeDeath.Vector3_IsUnsafe(position_route)
                            && !(ForceRequestGrimReaper.GetPostionTargetLot(position_route) is WorldLot))
                        {
                            routefail = false;
                            Actor.SetPosition(position_route);
                        }
                    }

                    if (routefail)
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        if (NFinalizeDeath.Random_Chance(30))
                        {
                            Actor.PlayRouteFailure(Target.GetThoughtBalloonThumbnailKey());
                        }
                        Actor.SetPosition(Target.Position);
                    }
                }
                else
                {
#if DEBUG
                    NiecException.PrintMessagePro("_OnRoutePoolNonOpenDGS\nroute_to_jiga == null", false, 100);
#endif
                }
            }
            
            public bool Notfixdgs = false;

            public bool Notfixdgxs = false;

            protected Vector3 mGhostForward = Vector3.Invalid;


            private void FadeDeathEventCallBack(StateMachineClient sender, IEvent evt)
            {
                switch (evt.EventId)
                {
                    case 111:
                        if (IsTargetGood(Target))
                            Target.SetOpacity(0f, 0.4f);
                        break;
                    case 112: {
                            Actor.SetOpacity(0f, 0.4f);
                            NiecHelperSituation grimReaperSituation = mSituation;
                            if (grimReaperSituation != null)
                                grimReaperSituation.StopGrimReaperSmoke();
                            break;
                    }
                    default: 
                        NFinalizeDeath.CheckMorun(); 
                        break;
                }
            }



            public bool ReapPetPool()
            {
                //NFinalizeDeath.RemoveAllSimNiecNullForGrave();
                if (mSituation == null)
                    mSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                if (!CreateGraveStone())
                {
                    Notfixdgs = true;
                    mDeathProgress = DeathProgress.Complete;
                    return false;
                }



                mSMCDeath = mSituation.SMCDeath;

                if (___bOpenDGSIsInstalled_ && mSMCDeath == null)
                    throw new NullReferenceException("Error: mSMCDeath == null");

                if (AssemblyCheckByNiec.IsInstalled("AweCore") && mSMCDeath == null)
                {
                    mSituation.CleanUp__();
                    NiecHelperSituationPosture.r_internal(Actor);
                    mSMCDeath = (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Actor) ?? mSituation).SMCDeath;
                    if (mSMCDeath == null)
                    {
                        if (NiecTask.GetCurrentNiecTask() != null)
                            return false;
                        NFinalizeDeath.CheckYieldingContext();
                        throw new NullReferenceException("Fatel Error: mSMCDeath == null");
                    }
                }

                var fake_target_smc = FakeSetActor(Actor, Target);
                if (___bOpenDGSIsInstalled_)
                {
                    mSMCDeath.SetActor("y", fake_target_smc);
                   
                    mSMCDeath.SetActor("grave", mGrave);
                }
                else {
                    NFinalizeDeath.StateMachineClient_SetActor(mSMCDeath, "y", fake_target_smc);
                    NFinalizeDeath.StateMachineClient_SetActor(mSMCDeath, "grave", mGrave);
                }

                if (NFinalizeDeath.StateMachineClient_SimIsPet(fake_target_smc) || NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(fake_target_smc)) // fix Could not find clip pet
                {
                    mSMCDeath.SetParameter(585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                    mSMCDeath.SetParameter(2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                }

               // fake_target_smc = null;

                mSMCDeath.EnterState("y", "Enter");

                ScubaDiving scubaDiving = Target.Posture as ScubaDiving;
                if (scubaDiving != null)
                {
                    scubaDiving.StopBubbleEffects();
                }

                if (Target.SimDescription == null)
                    throw new ArgumentNullException("Target.SimDescription");

                SimDescription.DeathType deathStyle = Target.SimDescription.DeathStyle;
                if (!mSituation.mIsFirstSim || mSituation.mScubaDeathJig == null)
                {
                    //NiecException.PrintMessagePro("!mSituation.mIsFirstSim || mSituation.mScubaDeathJig == null) ok\nSituation.ScubaDeathJig == NULL: " + (mSituation.mScubaDeathJig == null), false, 50);
                    if (!mSituation.mIsFirstSim)
                        mSMCDeath.EnterState("x", "Enter");
                    NFinalizeDeath.CheckYieldingContext();
                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                    mSMCDeath.RequestState(false, "x", "TreadWater");

                    if (mSituation.mScubaDeathJig != null)
                    {
                        NFinalizeDeath.ForceDestroyObject(mSituation.mScubaDeathJig);
                        mSituation.mScubaDeathJig = null;
                    }

                    mSituation.mScubaDeathJig = (GlobalFunctions.CreateObjectOutOfWorld("UnderwaterSocial_Jig", ProductVersion.EP10) as SocialJig);

                    CheckTargetIsNull("ReapPetPool", 0);
                    if (mSituation.mScubaDeathJig == null)
                        goto t;

                    Vector3 position = Target.Position;

                    CheckTargetIsNull("ReapPetPool 2", 0);
                    Vector3 forward = Target.ForwardVector;
                    NFinalizeDeath.CheckYieldingContext();
                    if (!GlobalFunctions.FindGoodLocationNearbyOnLevel(mSituation.mScubaDeathJig, 0, ref position, ref forward, FindGoodLocationBooleans.Routable | FindGoodLocationBooleans.AllowOnSlopes | FindGoodLocationBooleans.AllowInSea))
                    {
                        //return false;
                        CheckTargetIsNull("ReapPetPool 3", 0);
                        if (NFinalizeDeath.GameObjectIsValid(Target.ObjectId.mValue)) //Objects.IsValid(Target.ObjectId))
                            Actor.SetPosition(Target.Position);

                        if (Actor.SimRoutingComponent != null) 
                            Actor.SimRoutingComponent.ForceUpdateDynamicFootprint();
                    }
                    else
                    {
                        if (mSituation.mScubaDeathJig == null)
                            throw new ArgumentNullException("mSituation.mScubaDeathJig");
                        mSituation.mScubaDeathJig.SetPosition(position);
                        mSituation.mScubaDeathJig.SetForward(forward);

                        // Run Route
                        if (___bOpenDGSIsInstalled_ || !__acorewIsnstalled__)
                        {
                            if (!b_SafePosNHSTickOnly)
                            {
                                Route route_to_jiga = null;

                                route_to_jiga = mSituation.mScubaDeathJig.RouteToJigA(Actor);
                                route_to_jiga.DoRouteFail = false;

                                Actor.DoRoute(route_to_jiga);
                            }
                        }
                        else // if AwesomeMod
                        {
                            OnRoutePoolIfAM();
                        }
                    }
                   t:;
                }
                else
                {
                    //niec_std.printf("!mSituation.mIsFirstSim || mSituation.mScubaDeathJig == null) failed\nSituation.ScubaDeathJig == NULL: " + (mSituation.mScubaDeathJig == null));
                    mSituation.mIsFirstSim = false;
                }

                //Target.FadeOut(false, false, 2f);

                //PlaceGraveStone();
                //if (mSituation.mScubaDeathJig != null)
                {
                    mGrave.SetOpacity(0f, 0f);
                    mGrave.SetHiddenFlags(HiddenFlags.Nothing);

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(1);

                    if (mGrave == null)
                    {
                        if (__acorewIsnstalled__ && Target.SimDescription == null)
                        {
                            Target.mSimDescription = global::NiecMod.Helpers.Create.NiecNullSimDescription(false, false, false);
                            Target.mSimDescription.mSim = Target;
                        }

                        if (Target.mSimDescription == null)
                            throw new NullReferenceException("Error: Target.mSimDescription is null");

                        mGrave = HelperNra.TFindGhostsGrave(Target.SimDescription);
                    }
                    if (mGrave != null && mSituation.mScubaDeathJig != null)
                    {
                        mGrave.SetPosition(mSituation.mScubaDeathJig.GetPositionOfSlot(SocialJigTwoPerson.RoutingSlots.SimB));
                        mGrave.SetForward(mSituation.mScubaDeathJig.GetForwardOfSlot(SocialJigTwoPerson.RoutingSlots.SimB));
                    }

                    //else if (Objects.IsValid(Target.ObjectId))
                    //else 
                    //{
                    //    mGrave.SetPosition(Target.Position);
                    //    mGrave.SetForward(Target.Position);
                    //}
                    else if (mGrave != null)
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        Vector3 position = Actor.Position;
                        Vector3 forward = Actor.ForwardVector;
                        if (!GlobalFunctions.FindGoodLocationNearbyOnLevel(Actor, 0, ref position, ref forward, FindGoodLocationBooleans.None))
                        {
                            mGrave.SetPosition(Actor.Position);
                            mGrave.SetForward(Actor.Position);
                        }
                        else
                        {
                            mGrave.SetPosition(position);
                            mGrave.SetForward(forward);
                        }
                    }
                    if (mGrave != null)
                    {
                        mGrave.OnHandToolMovement();
                        mGrave.FadeIn(false, 5f);
                        mGrave.FogEffectStart();
                    }
                }

                mDeathProgress = DeathProgress.GravePlaced;

                NFinalizeDeath.CheckYieldingContext();
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);

                if (___bOpenDGSIsInstalled_ )//&&!NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", mSMCDeath)) //mSMCDeath.mHandleEventsAsynchronously)
                {
                    if (!NFinalizeDeath.SMCIsGood("x", mSMCDeath))
                        return rSetObjectToReset();
                }
                else if (__acorewIsnstalled__)
                {
                    if (NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask)
                    {
                        NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, mSMCDeath);
                        NFinalizeDeath.SMCIsValid("x", true, mSMCDeath);
                    }
                }

                if (!___bOpenDGSIsInstalled_ && __acorewIsnstalled__)
                {
                    int ia = 0;
                    bool iad = AssemblyCheckByNiec.DGSSimIFaceIsInstalled();
                    while (true)
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        if (ia > 0)
                        {
                            if (Target == null && !NFinalizeDeath.GameObjectIsValid(Target.ObjectId.mValue))
                            {
                                if (isdgmods)
                                    return true;
                                else
                                {
                                    CheckTargetIsNull("PoolLoop SMC CreateGrave Check Target == null", 10);
                                    break;
                                }
                            }
                            Simulator.Sleep(5);
                        }

                        mSMCDeath.mAbortRequested = false;

                        if (Actor != null && (mSMCDeath.mDriver.mHandle == 0 || !ScriptCore.SACS.SACS_IsEventQueueValidImpl(mSMCDeath.mDriver.mHandle)))
                        {
                            mSituation.CleanUp__();
                            return NFinalizeDeath.ForceNHSReapSoul(Target, Actor);
                        }

                        if (ia > 0 && isdgmods)
                            Objects.GetPosition(new ObjectGuid());
                        CheckTargetIsNull("ReapPetPool CreateTombstone:loop", 1);

                        if (fUnSafe_FakeThrowRunInteraction)
                        {
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);

                            try
                            {
                                mSMCDeath.RequestState(false, "x", "CreateTombstone");
                            }
                            catch (StackOverflowException)
                            {
                                NFinalizeDeath.ThrowResetException(null);
                                throw;
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch (Exception)
                            { }

                            NFinalizeDeath.CheckYieldingContext();
                            Simulator.Sleep(85);
                            NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });//(new NullReferenceException("fUnSafe_FakeThrowRunInteraction"));
                        }

                        try
                        {
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                            mSMCDeath.RequestState(true, "x", "CreateTombstone");//, (Sims3.SimIFace.SACS.DriverRequestFlags)0x80);
                            break;
                        }
                        catch (StackOverflowException)
                        {
                            NFinalizeDeath.ThrowResetException(null);
                            throw;
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch (SacsTimeoutException)
                        {
                            break;
                        }
                        catch (Exception)
                        {
                            if (iad)
                            {
                                ia++;
                                if (mSMCDeath.mDriver.mHandle == 0 || ia > 3)
                                    throw;
                            }
                            else throw;
                        }
                    }
                }
                else
                {
                    if (fUnSafe_FakeThrowRunInteraction)
                    {
                        mSMCDeath.RequestState(false, "x", "CreateTombstone");

                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(85);
                        NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });//(new NullReferenceException("fUnSafe_FakeThrowRunInteraction"));
                    }
                    mSMCDeath.RequestState(true, "x", "CreateTombstone");
                }








                NFinalizeDeath.CheckYieldingContext();

                if (Actor.ThoughtBalloonManager != null)
                {
                    ThoughtBalloonManager.BalloonData balloonData = new ThoughtBalloonManager.DoubleBalloonData("balloon_moodlet_mourning", (fake_target_smc ?? Target).GetThoughtBalloonThumbnailKey());
                    if (balloonData != null) {
                        balloonData.BalloonType = ThoughtBalloonTypes.kSpeechBalloon;
                        balloonData.mPriority = ThoughtBalloonPriority.High;
                        
                        try
                        {
                            Actor.ThoughtBalloonManager.ShowBalloon(balloonData);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            if (___bOpenDGSIsInstalled_)
                                throw;
                            NFinalizeDeath.CheckYieldingContext();
                        } NFinalizeDeath.CheckYieldingContext();
                    }
                    //fake_target_smc = null; 2
                }
                NFinalizeDeath.CheckYieldingContext();
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                mSMCDeath.RequestState(false, "x", "ReaperFloating");

                if (mSituation.mScubaDeathJig != null)
                {
                    mGhostPosition = mSituation.mScubaDeathJig.GetPositionOfSlot(SocialJigTwoPerson.RoutingSlots.SimB);
                    mGhostForward = mSituation.mScubaDeathJig.GetForwardOfSlot(SocialJigTwoPerson.RoutingSlots.SimB);
                }
                else {
                    Vector3 position; // = Actor.Position;
                    Vector3 forward; // = Actor.ForwardVector;
                    //if (!GlobalFunctions.FindGoodLocationNearbyOnLevel(Actor, 0, ref position, ref forward, FindGoodLocationBooleans.Routable | FindGoodLocationBooleans.AllowOnSlopes | FindGoodLocationBooleans.AllowInSea))


                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(mGrave.HasBeenDestroyed ? Actor.Position : mGrave.Position);

                    if (!GlobalFunctions.FindGoodLocation(Actor, fglParams, out position, out forward))
                    {
                        mGhostPosition = Actor.Position;
                        mGhostForward = Actor.ForwardVector;
                    }
                    else { 
                         mGhostPosition = position;
                         mGhostForward = forward;
                    }
                }

                Lot lotCurrent = Target.LotCurrent;

                try
                {
                    if (lotCurrent != Target.LotHome && lotCurrent.Household != null)
                    {
                        Target.GreetSimOnLot(lotCurrent);
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }

                NFinalizeDeath.CheckYieldingContext();

                GoToVirtualHome__AntiNPC();
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                switch (deathStyle)
                {
                    case SimDescription.DeathType.ScubaDrown:
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseDrown");
                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.RequestState(true, "y", "DrownToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                    case SimDescription.DeathType.Shark:
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseShark");
                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.RequestState(true, "y", "SharkToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                    default:
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseDrown");
                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.RequestState(true, "y", "DrownToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                }
                Target.FadeIn();
                Target.AddToWorld();
                mDeathFlower = Target.Inventory != null ? FindInv <DeathFlower>(Target) : null;
                GoToVirtualHome__AntiNPC();
                if (Target.InteractionQueue  != null && Target.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                    Target.AddExitReason(ExitReason.HigherPriorityNext);

                Target.AddExitReason(ExitReason.CanceledByScript);

                /* error :D
                
                if (StartSync(true, true, null, 0f, false))
                {
                    if (Target.IsInActiveHousehold)
                    {
                        mDeathProgress = DeathProgress.DeathFlowerStarted;
                        Target.Inventory.RemoveByForce(mDeathFlower);
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimDeathFlower);
                        mSMCDeath.RequestState(false, "x", "DeathFlower");
                        mSMCDeath.RequestState(true, "y", "DeathFlower");
                       // mDeathFlower.Destroy();
                       // mDeathFlower = null;
                        mSMCDeath.RequestState(false, "x", "Exit");
                        mSMCDeath.RequestState(true, "y", "Exit");
                        FinishLinkedInteraction(true);
                        mDeathProgress = DeathProgress.Complete;
                        return true;
                    }
                    mDeathProgress = DeathProgress.NormalStarted;
                    mSMCDeath.RequestState(false, "x", "Accept");
                    mSMCDeath.RequestState(true, "y", "Accept");
                    mSMCDeath.RequestState(false, "y", "Exit");
                    mSMCDeath.RequestState(true, "x", "Exit");
                }
                else
                {
                    if (Target.IsInActiveHousehold)
                    {
                        mDeathProgress = DeathProgress.DeathFlowerStarted;
                        Target.Inventory.RemoveByForce(mDeathFlower);
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimDeathFlower);
                        mSMCDeath.RequestState(false, "x", "DeathFlower");
                        mSMCDeath.RequestState(true, "y", "DeathFlower");
                        //mDeathFlower.Destroy();
                        //mDeathFlower = null;
                        mSMCDeath.RequestState(false, "x", "Exit");
                        mSMCDeath.RequestState(true, "y", "Exit");
                        FinishLinkedInteraction(true);
                        mDeathProgress = DeathProgress.Complete;
                        return true;
                    }
                    mDeathProgress = DeathProgress.NormalStarted;
                    mSMCDeath.RequestState("x", "ExitNoSocial");
                    Target.FadeOut();
                    mDeathEffect = mGrave.GetSimToGhostEffect(Target, mGrave.Position);
                    mSMCDeath.SetEffectActor("deathEffect", mDeathEffect);
                    mDeathEffect.Start();
                }
                 */

                Target.FadeIn();
                Target.AddToWorld();
                GoToVirtualHome__AntiNPC();

                if (ReapSoul_SafeGhostToSim(Target) || Target == NFinalizeDeath.ActiveActor)
                {
                    mDeathProgress = DeathProgress.DeathFlowerStarted;

                    if (Target.Inventory != null)
                        Target.Inventory.RemoveByForce(mDeathFlower);

                    mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimDeathFlower);
                    NFinalizeDeath.CheckYieldingContext();
                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                    mSMCDeath.RequestState(false, "x", "DeathFlower");
                    mSMCDeath.RequestState(true, "y", "DeathFlower");

                    if (mDeathFlower != null && Target != NFinalizeDeath.ActiveActor)
                    {
                        mDeathFlower.Destroy();
                        mDeathFlower = null;
                    }
                    NFinalizeDeath.CheckYieldingContext();
                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                    mSMCDeath.RequestState(false, "x", "Exit");
                    mSMCDeath.RequestState(true, "y", "Exit");

                    mDeathProgress = DeathProgress.Complete;

                    //FinishLinkedInteraction(true);
                    
                    return CreateTaskFadeInForActor(true);
                }

                mDeathProgress = DeathProgress.NormalStarted;
                NFinalizeDeath.CheckYieldingContext();
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                mSMCDeath.RequestState(false, "x", "Accept");
                mSMCDeath.RequestState(true, "y", "Accept");
                NFinalizeDeath.CheckYieldingContext();
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                mSMCDeath.RequestState(false, "y", "Exit");
                mSMCDeath.RequestState(true, "x", "Exit");


                FixFadnInFakeTargetSim(fake_target_smc);
                fake_target_smc = null; 

                mDeathProgress = DeathProgress.NormalStarted;

                FinalizeDeath();

                Target.StartOneShotFunction(ReapSoulCallback, GameObject.OneShotFunctionDisposeFlag.OnDispose);
                mDeathProgress = DeathProgress.Complete;

                //FinishLinkedInteraction(true);

             

                Target.FadeIn();
                CreateTaskFadeInForActor(true);
                
                return true;
                /*
                //string m = SMsg;
                if (!CreateGraveStone())
                {
                    return false;
                }
                mSMCDeath = mSituation.SMCDeath;
                mSMCDeath.SetActor("y", Target);
                mSMCDeath.SetActor("grave", mGrave);
                mSMCDeath.EnterState("y", "Enter");
                SMsg = "Pet Enter";
                SimDescription.DeathType deathStyle = Target.SimDescription.DeathStyle;
                if (!mSituation.mIsFirstSim)
                {
                    SMsg = "Pet Enter 2";
                    //mSMCDeath.EnterState("x", "Enter");
                    mSMCDeath.RequestState(false, "x", "TreadWater");
                    mSituation.mScubaDeathJig = (GlobalFunctions.CreateObjectOutOfWorld("UnderwaterSocial_Jig", ProductVersion.EP10) as SocialJig);
                    Vector3 position = Target.Position;
                    Vector3 forward = Target.ForwardVector;
                    if (!GlobalFunctions.FindGoodLocationNearbyOnLevel(mSituation.mScubaDeathJig, 0, ref position, ref forward, FindGoodLocationBooleans.Routable | FindGoodLocationBooleans.AllowOnSlopes | FindGoodLocationBooleans.AllowInSea))
                    {
                        return false;
                    }
                    mSituation.mScubaDeathJig.SetPosition(position);
                    mSituation.mScubaDeathJig.SetForward(forward);
                    SMsg = "Pet Enter 3";
                    Route route = mSituation.mScubaDeathJig.RouteToJigA(Actor);
                    if (route != null)
                    {
                        route.DoRouteFail = false;
                        Actor.DoRoute(route);
                    }

                    SMsg = "Pet Enter 4";
                }
                else
                {
                    mSituation.mIsFirstSim = false;
                }
                Target.FadeOut(false, false, 2f);
                PlaceGraveStone();
                mDeathProgress = DeathProgress.GravePlaced;
                SMsg = "Pet Enter 5";
                mSMCDeath.RequestState(true, "x", "CreateTombstone");
                ThoughtBalloonManager.BalloonData balloonData = new ThoughtBalloonManager.DoubleBalloonData("balloon_moodlet_mourning", Target.GetThoughtBalloonThumbnailKey());
                balloonData.BalloonType = ThoughtBalloonTypes.kSpeechBalloon;
                balloonData.mPriority = ThoughtBalloonPriority.High;
                Actor.ThoughtBalloonManager.ShowBalloon(balloonData);
                SMsg = "Pet Enter 6";
                mSMCDeath.RequestState(false, "x", "ReaperFloating");
                //mGhostPosition = mSituation.mScubaDeathJig.GetPositionOfSlot(SocialJigTwoPerson.RoutingSlots.SimB);
                //mGhostForward = mSituation.mScubaDeathJig.GetForwardOfSlot(SocialJigTwoPerson.RoutingSlots.SimB);
                try
                {
                    Lot lotCurrent = Target.LotCurrent;
                    if (lotCurrent != Target.LotHome && lotCurrent.Household != null)
                    {
                        Target.GreetSimOnLot(lotCurrent);
                    }
                }
                catch (Exception)
                { }
                SMsg = "Pet Enter 6a";
                switch (deathStyle)
                {
                    case SimDescription.DeathType.ScubaDrown:
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseDrown");
                        mSMCDeath.RequestState(true, "y", "DrownToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                    case SimDescription.DeathType.Shark:
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseShark");
                        mSMCDeath.RequestState(true, "y", "SharkToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                    default:
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseDrown");
                        mSMCDeath.RequestState(true, "y", "DrownToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                }
                mDeathFlower = Target.Inventory.Find<DeathFlower>();
                //BeReapedDiving beReapedDiving = (BeReapedDiving)(LinkedInteractionInstance = (BeReapedDiving.Singleton.CreateInstance(Actor, Target, new InteractionPriority(InteractionPriorityLevel.MaxExpireDeathX, 1f), false, true) as BeReapedDiving));
                //beReapedDiving.mHadDeathFlower = (mDeathFlower != null);
                Target.AddExitReason(ExitReason.HigherPriorityNext);
                //Target.InteractionQueue.AddNext(beReapedDiving);

                SMsg = "Pet Enter 7";
                Target.FadeIn();
                if (Target.IsInActiveHousehold)
                {
                    mDeathProgress = DeathProgress.DeathFlowerStarted;
                    Target.Inventory.RemoveByForce(mDeathFlower);
                    mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimDeathFlower);
                    mSMCDeath.RequestState(false, "x", "DeathFlower");
                    mSMCDeath.RequestState(true, "y", "DeathFlower");
                    if (mDeathFlower != null)
                    {
                        mDeathFlower.Destroy();
                        mDeathFlower = null;
                    }

                    mSMCDeath.RequestState(false, "x", "Exit");
                    mSMCDeath.RequestState(true, "y", "Exit");
                    FinishLinkedInteraction(true);
                    mDeathProgress = DeathProgress.Complete;
                    return true;
                }
                SMsg = "Pet Enter 8";
                mDeathProgress = DeathProgress.NormalStarted;
                mSMCDeath.RequestState(false, "x", "Accept");
                mSMCDeath.RequestState(true, "y", "Accept");
                mSMCDeath.RequestState(false, "y", "Exit");
                mSMCDeath.RequestState(true, "x", "Exit");

                SMsg = "Pet Enter 9";
                mDeathProgress = DeathProgress.NormalStarted;
                FinalizeDeath();
                Target.StartOneShotFunction(ReapSoulCallback, GameObject.OneShotFunctionDisposeFlag.OnDispose);
                mDeathProgress = DeathProgress.Complete;
                //FinishLinkedInteraction(true);
                Target.FadeIn();
                SMsg = "Pet Enter 10";
                */
                //return true;
            }



            public bool ReapPetSoul()
            {
                //NFinalizeDeath.RemoveAllSimNiecNullForGrave();
                var extKillSimNiec = Target.CurrentInteraction as ExtKillSimNiec;
                var killSim = Target.CurrentInteraction as Urnstone.KillSim;
                if (extKillSimNiec != null && extKillSimNiec.SocialJig != null)
                {
                    base.SocialJig = extKillSimNiec.SocialJig;
                    extKillSimNiec.SocialJig = null;
                    SocialJig.ClearParticipants();
                    SocialJig.RegisterParticipants(Actor, Target);
                }
                
                else if (killSim != null && killSim.SocialJig != null)
                {
                    base.SocialJig = killSim.SocialJig;
                    killSim.SocialJig = null;
                    SocialJig.ClearParticipants();
                    SocialJig.RegisterParticipants(Actor, Target);
                }
                

                



                if (!CreateGraveStone())
                {
                    Notfixdgs = true;
                    mDeathProgress = DeathProgress.Complete;
                    return false;
                }

                if (IsUnSafeUsingListSim())
                {
                    NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                    NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Target);
                }

                GoToVirtualHome__AntiNPC();

                mSMCDeath = mSituation.SMCDeath;
                Sim fake_target_smc;
                if (___bOpenDGSIsInstalled_)
                {
                    if (mSMCDeath == null)
                        throw new NullReferenceException("Error: mSMCDeath == null");

                    fake_target_smc = FakeSetActor(Actor, Target);

                    mSMCDeath.SetActor("y", fake_target_smc);

                    if (fake_target_smc.SimDescription != null && fake_target_smc.SimDescription.IsHuman)
                    {
                        if (kUnsafeOpenDGSReapSoulPetHoruse)
                        {
                            mSMCDeath.SetParameter(585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.horse);
                            mSMCDeath.SetParameter(2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                        }
                        else
                        {
                            mSMCDeath.SetParameter(585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.dog);
                            mSMCDeath.SetParameter(2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                        }
                    }

                    mSMCDeath.SetActor("grave", mGrave);

                    //fake_target_smc = null;
                }
                else {
                    fake_target_smc = FakeSetActor(Actor, Target);
                    if  (mSMCDeath == null && AssemblyCheckByNiec.IsInstalled("AweCore") && Simulator.CheckYieldingContext(false))
                    {
                        if (NFinalizeDeath.Random_CoinFlip())
                        {
                            NFinalizeDeath.ThrowOtherException (
                                new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true }
                            );
                        }

                        mSituation.CleanUp__();
                        NiecHelperSituationPosture.r_internal(Actor);

                        mSMCDeath = mSituation.SMCDeath;
                        if (mSMCDeath == null)
                            NFinalizeDeath.ThrowResetException(null);
                    }

                    NFinalizeDeath.CheckYieldingContext();
                    NFinalizeDeath.StateMachineClient_SetActor(mSMCDeath, "y", fake_target_smc);

                    if (fake_target_smc.SimDescription != null && fake_target_smc.SimDescription.IsHuman)
                    {
                        mSMCDeath.SetParameter(585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.horse);
                        mSMCDeath.SetParameter(2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                    }

                    NFinalizeDeath.StateMachineClient_SetActor(mSMCDeath, "grave", mGrave);
                    //fake_target_smc = null;
                }
                mSMCDeath.EnterState("y", "Enter");

                PlaceGraveStone();

                mDeathProgress = DeathProgress.GravePlaced;

                if (!mSituation.mIsFirstSim)
                {
                    mSMCDeath.EnterState("x", "Enter");
                }

                NFinalizeDeath.CheckYieldingContext();
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);


                if (___bOpenDGSIsInstalled_) //&& !mSMCDeath.mHandleEventsAsynchronously)
                {
                    if (!NFinalizeDeath.SMCIsGood("x", mSMCDeath))
                        return rSetObjectToReset();
                } 
                else //if (__acorewIsnstalled__)
                {
                    if (NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask)
                    {
                        NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, mSMCDeath);
                        NFinalizeDeath.SMCIsValid("x", true, mSMCDeath);
                    }
                }

                if (!___bOpenDGSIsInstalled_ && __acorewIsnstalled__)
                {
                    int ia = 0;
                    bool iad = AssemblyCheckByNiec.DGSSimIFaceIsInstalled();
                    while (true)
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        if (ia > 0)
                        {
                            if (Target == null && !NFinalizeDeath.GameObjectIsValid(Target.ObjectId.mValue))
                            {
                                if (isdgmods)
                                    return true;
                                else
                                {
                                    CheckTargetIsNull("PetLoop SMC CreateGrave Check Target == null", 10);
                                    break;
                                }
                            }
                            Simulator.Sleep(5);
                        }

                        mSMCDeath.mAbortRequested = false;

                        if (Actor != null && ( mSMCDeath.mDriver.mHandle == 0 || !ScriptCore.SACS.SACS_IsEventQueueValidImpl(mSMCDeath.mDriver.mHandle) ))
                        {
                            mSituation.CleanUp__();
                            return NFinalizeDeath.ForceNHSReapSoul(Target, Actor);
                        }
                        if (ia > 0 && isdgmods)
                            Objects.GetPosition(new ObjectGuid());
                        CheckTargetIsNull("ReapPetSoul CreateTombstone:loop", 1);

                        if (fUnSafe_FakeThrowRunInteraction)
                        {
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                            NFinalizeDeath.CheckYieldingContext();

                            try
                            {
                                mSMCDeath.RequestState(false, "x", "CreateTombstone");
                            }
                            catch (StackOverflowException)
                            {
                                NFinalizeDeath.ThrowResetException(null);
                                throw;
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch (Exception)
                            { }

                            NFinalizeDeath.CheckYieldingContext();
                            Simulator.Sleep(85);
                            NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });//(new NullReferenceException("fUnSafe_FakeThrowRunInteraction"));
                        }

                        try
                        {
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                            NFinalizeDeath.CheckYieldingContext();
                            mSMCDeath.RequestState(true, "x", "CreateTombstone");//, (Sims3.SimIFace.SACS.DriverRequestFlags)0x80);
                            break;
                        }
                        catch (StackOverflowException)
                        {
                            NFinalizeDeath.ThrowResetException(null);
                            throw;
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch (SacsTimeoutException)
                        {
                            //if (iad)
                            //{
                            //    ia++;
                            //    continue;
                            //}
                            break;
                        }
                        catch (Exception)
                        {
                            if (iad)
                            {
                                ia++;
                                if (mSMCDeath.mDriver.mHandle == 0 || ia > 3)
                                    throw;
                            }
                            else throw;
                        }
                    }
                }
                else
                {
                    //try
                    //{
                    //    mSMCDeath.RequestState(true, "x", "CreateTombstone");
                    //}
                    //catch (ResetException)
                    //{
                    //    throw;
                    //}
                    //catch (SacsTimeoutException)
                    //{ NFinalizeDeath.CheckYieldingContext(); }
                    if (fUnSafe_FakeThrowRunInteraction)
                    {
                        mSMCDeath.RequestState(false, "x", "CreateTombstone");

                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(85);
                        NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });//(new NullReferenceException("fUnSafe_FakeThrowRunInteraction"));
                    }
                    mSMCDeath.RequestState(true, "x", "CreateTombstone");
                }
                CheckTargetIsNull("ReapPetSoul", 1);
                Actor.FadeIn();
                if (!___bOpenDGSIsInstalled_ || !Target.HasBeenDestroyed)
                    Target.FadeIn();

                Lot lotCurrent = Target.LotCurrent;
                try
                {
                   
                    if (lotCurrent == null)
                    {
#if DEBUG 
                        if (!__acorewIsnstalled__)
                            NiecException.PrintMessagePro("ReapPetSoul() Fail if (lotCurrent == null) Try Reset.", false, float.MaxValue);
#endif
                        Target.mLotCurrent = lotCurrent = LotManager.GetWorldLot();
                    }
                    if (lotCurrent != Target.LotHome && lotCurrent.Household != null)
                    {
                        Target.GreetSimOnLot(lotCurrent);
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }
               

                bool flag = false;
                try
                {
                    RequestWalkStyle(Sim.WalkStyle.DeathWalk);
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { if (___bOpenDGSIsInstalled_) throw; NFinalizeDeath.CheckYieldingContext(); }
            
                string name = Localization.LocalizeString(Target.SimDescription.IsFemale, "Gameplay/Actors/Sim/ReapSoul:InteractionName");
                Target.AddExitReason(ExitReason.CanceledByScript);

                GoToVirtualHome__AntiNPC();

                if (AlarmManager.Global != null)
                    AlarmCheckSocialLoop = AlarmManager.Global.AddAlarm(WorkingNiecHelperSituationCount > 10 ? 11f : 3.2f, TimeUnit.Hours, CheckSocialInf, !___bOpenDGSIsInstalled_ ? null : "CheckSocialLoop", AlarmType.AlwaysPersisted, null);

                if (___bOpenDGSIsInstalled_ )//&& !NFinalizeDeath.GameObjectIsValid(Actor.ObjectId.mValue)) { 
                {
                    if ( Actor == null || Target == null 
                        || !NFinalizeDeath.GameObjectIsValid(Actor.ObjectId.mValue) || !NFinalizeDeath.GameObjectIsValid(Target.ObjectId.mValue)
                    )
                    {
                        GrimReaperPostSequenceCleanup();
                        return false;
                    }
                } 
                Target.FadeIn();


                CheckTargetIsNull("ReapPetSoul() on social", 1);
                bool checkerror = false;
                
                if (Actor == null)
                {
                    if (Target == null)
                    {
                        throw new NotSupportedException("ReapPetSoul() Fatal Error: failed again Target or Actor == null on Social Interaction !!!");
                    }
                    throw new NullReferenceException("ReapPetSoul() Error: Failed Actor == null on Social Interaction !!!");
                }

                if (___bOpenDGSIsInstalled_ && (Target == null || Simulator.GetProxy(Target.ObjectId) == null))
                {
                    return ForceExitSocialLite(false);
                }

                try
                {
                    Actor.ClearExitReasons();

                    checkerror = 

                        (___bOpenDGSIsInstalled_ ?
                             BeginSocialInteraction
                             (new KillSimNiecX.NiecDefinitionDeathInteraction(name, true), true, Target.GetSocialRadiusWith(Actor), false) :
                           (ShouldSoctalSlowNHSRPS() && BeginSocialInteraction
                           (new KillSimNiecX.NiecDefinitionDeathInteraction(name, true), true, Target != null ? Target.GetSocialRadiusWith(Actor) : 1f, false))
                        )

                        || ((!___bOpenDGSIsInstalled_ 

                        || kUnsafeOpenDGSReapSoulPetHoruse) 

                        && (Actor.CurrentInteraction is NiecAppear 

                        || (ForceRunReapSoulPet 

                        || (___bOpenDGSIsInstalled_ ? Target.IsHorse :
                            Target != null ? Target.IsHorse : true))));
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                {
                    NFinalizeDeath.CheckYieldingContext();

                    checkerror = false;

                    //mSMCDeath.RequestState("x", "ExitNoSocial");

                    //if (!___bOpenDGSIsInstalled_)
                    //    mDeathProgress = DeathProgress.None;

                    if (!___bOpenDGSIsInstalled_)
                        CheckTargetIsNull("ReapPetSoul() on catch social", 1);

                    if (Actor == null)
                    {
                        if (Target == null)
                        {
                            throw new NotSupportedException
                                ("ReapPetSoul() Fatal Error: failed again Target or Actor == null on Catch Social Interaction !!!");
                        }
                        throw new NullReferenceException
                            ("ReapPetSoul() Error: Failed Actor == null on Catch Social Interaction !!!");
                    }

                    GrimReaperPostSequenceCleanup();
                    if (ForceRunReapSoulPet && __acorewIsnstalled__ && !___bOpenDGSIsInstalled_)
                    {
                        checkerror = true;
                    }
                    else return checkerror;
                }

                NFinalizeDeath.CheckYieldingContext();
                if (___bOpenDGSIsInstalled_ && Target.HasBeenDestroyed)
                {
                    GrimReaperPostSequenceCleanup();
                    FixFadnInFakeTargetSim(fake_target_smc);
                    fake_target_smc = null; 
                    return false;
                } 


                //if (BeginSocialInteraction(new KillSimNiecX.NiecDefinitionDeathInteraction(name, false), true, Target.GetSocialRadiusWith(Actor), false) || Actor.CurrentInteraction is NiecAppear || Target.IsHorse)
                if (checkerror)
                {
                    CheckTargetIsNull("ReapPetSoul", 2);
                    if (!___bOpenDGSIsInstalled_ || !Target.HasBeenDestroyed)
                    {
                        //Target.FadeIn();

                        var ObjectID = Target.ObjectId;
                        ScriptCore.World.World_ObjectSetHiddenFlags(ObjectID.mValue, 0);
                        ScriptCore.World.World_ObjectSetOpacity(ObjectID.mValue, 1, 1);
                    }

                    mDeathProgress = DeathProgress.NormalStarted;
                    CheckTargetIsNull("ReapPetSoul", 3);
                    if (Target.IsHorse)
                    {
                        mSMCDeath.AddOneShotScriptEventHandler(112u, FadeDeathEventCallBack);
                    }

                    mSMCDeath.AddOneShotScriptEventHandler(111u, FadeDeathEventCallBack);

                    bool p = false; //klooppet && __acorewIsnstalled__;

                    do
                    {
                        if (klooppet)
                        {
                            NFinalizeDeath.CheckYieldingContext();
                            if (Actor == null || !NFinalizeDeath.GameObjectIsValid(Actor.ObjectId.mValue)) return false;
                            if (!NFinalizeDeath.GameObjectIsValid(Target.ObjectId.mValue)) {
                                //if (___bOpenDGSIsInstalled_)
                                //{
                                //    Target.FadeIn();
                                //}
                                //else
                                {
                                    Actor.FadeIn();
                                    Target.FadeIn();
                                }
                            }
                            Simulator.Sleep(0);

                            NFinalizeDeath.CheckYieldingContext();
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                            fake_target_smc = FakeSetActor(Actor, Target);
                            if (fake_target_smc != null && fake_target_smc != Target)
                            {
                                var desc_fake_target_smc = fake_target_smc.mSimDescription;
                                if (desc_fake_target_smc != null && desc_fake_target_smc.IsHuman)
                                {
                                    if (___bOpenDGSIsInstalled_)
                                    {
                                        mSMCDeath.SetActor
                                            ("y", fake_target_smc);

                                        if (kUnsafeOpenDGSReapSoulPetHoruse)
                                        {
                                            mSMCDeath.SetParameter
                                                (585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.horse);
                                            mSMCDeath.SetParameter
                                                (2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                                        }
                                        else
                                        {
                                            mSMCDeath.SetParameter
                                                (585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.dog);
                                            mSMCDeath.SetParameter
                                                (2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                                        }
                                    }
                                    else
                                    {
                                        mSMCDeath.mPendingException = null;
                                        NFinalizeDeath.StateMachineClient_SetActor
                                            (mSMCDeath, "y", fake_target_smc);

                                        mSMCDeath.SetParameter
                                            (585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.horse);
                                        mSMCDeath.SetParameter
                                            (2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                                    }
                                }
                                desc_fake_target_smc = null;
                            }
                            //fake_target_smc = null;

                            mSMCDeath.EnterState("x", "Enter");
                            mSMCDeath.EnterState("y", "Enter");
                        }

                        //p = klooppet && __acorewIsnstalled__;

                        //////////////

                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.RequestState(p, "x", "Pet");

                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.RequestState(!p, "y", "Pet");

                        //////////////

                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.RequestState(p, "x", "ReapPet");

                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.RequestState(!p, "y", "ReapPet");

                        //////////////
                        if (klooppet)
                        {
                            NFinalizeDeath.CheckYieldingContext();
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                            mSMCDeath.RequestState(!p, "y", "Exit");

                            //////////////

                            NFinalizeDeath.CheckYieldingContext();
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                            mSMCDeath.RequestState(p, "x", "Exit");
                        }
                    } while (klooppet);

                    NFinalizeDeath.CheckYieldingContext();
                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                    mSMCDeath.RequestState(p, "x", "Exit");

                    NFinalizeDeath.CheckYieldingContext();
                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                    mSMCDeath.RequestState(!p, "y", "Exit");


                        //////////////



                    

                    NFinalizeDeath.CheckYieldingContext();

                    if (IsGrimReaperFast())
                        Actor.FadeOut(true, false, 5f);

                    if (ReapSoul_SafeGhostToSim(Target) || Target == NFinalizeDeath.ActiveActor)
                    {

                        GrimReaperPostSequenceCleanup();
                        mDeathProgress = DeathProgress.Complete;

                        Actor.FadeOut(false, false, 0f);
                        CheckTargetIsNull("ACORE failed Target ==null", 1);
                        Target.FadeIn();

                        if (ShouldDoDeathEvent(Target))
                        {
                            //StyledNotification.Format format = new StyledNotification.Format(Localization.LocalizeString("Gameplay/Services/GrimReaper:Unlucky1", Target), Actor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                            StyledNotification.Format format = new StyledNotification.Format("Good Sim :)", Actor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                            StyledNotification.Show(format);
                        }

                        bool bResetAge = false;
                        if (Target.SimDescription.DeathStyle == SimDescription.DeathType.OldAge)
                        {
                            bResetAge = true;
                        }
                        try
                        {
                            if (mGrave != null && IsTargetGood(Target))
                            {
                                if (___bOpenDGSIsInstalled_)
                                    mGrave.GhostToSim(Target, bResetAge, false);
                                else
                                {
                                    NFinalizeDeath.SafeXGhostToSim(mGrave, Target, bResetAge, false);
                                }
                            }
                        }
                        catch (ResetException)
                        { throw; }
                        catch { 

                            if (___bOpenDGSIsInstalled_) 
                                throw;

                            NFinalizeDeath.CheckYieldingContext();
                            CheckTargetIsNull("ACORE failed Target ==null", 2);
                            NFinalizeDeath.ResuetSim

                            (Target.SimDescription, mGrave == null ? null :
                            NFinalizeDeath.Find_SCGetHouseholds(mGrave.mOriginalHouseholdId), true, false); 
                        }
                        
                        Actor.ClearSynchronizationData();
                        if (mGrave != null)
                        {
                            mGrave.Destroy();
                            mGrave = null;
                        }
                        if (Target.SimDescription != null)
                        {
                            Target.SimDescription.IsNeverSelectable = false;
                            Target.SimDescription.ShowSocialsOnSim = true;
                        }
                        if (Target.Autonomy != null)
                            Target.Autonomy.DecrementAutonomyDisabled();

                        FixFadnInFakeTargetSim(fake_target_smc);
                        fake_target_smc = null;
                        return CreateTaskFadeInForActor();
                    }
                    flag = true;
                }
                else if (!ReapSoul_SafeGhostToSim(Target))
                {
                    Actor.FadeOut(false, false, 0f);
                    Target.FadeOut(false, false, 0f);
                }
                else
                {


                    GrimReaperPostSequenceCleanup();

                    mDeathProgress = DeathProgress.Complete;

                    Actor.FadeOut(false, false, 0f);
                    if (IsTargetGood(Target))
                    {
                        if (___bOpenDGSIsInstalled_)
                        {
                            Target.FadeIn();
                        }
                        else
                        {
                            CheckTargetIsNull("ACORE failed Target ==null", 3);
                            var ObjectID = Target.ObjectId;
                            ScriptCore.World.World_ObjectSetHiddenFlags(ObjectID.mValue, 0);
                            ScriptCore.World.World_ObjectSetOpacity(ObjectID.mValue, 1, 1);
                        }
                    }
                    if (ShouldDoDeathEvent(Target))
                    {
                        //StyledNotification.Format format = new StyledNotification.Format(Localization.LocalizeString("Gameplay/Services/GrimReaper:Unlucky1", Target), Actor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                        StyledNotification.Format format = new StyledNotification.Format("Good Sim :)", Actor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                        StyledNotification.Show(format);
                    }

                    bool bResetAge = false;
                    if (Target.SimDescription!= null && Target.SimDescription.DeathStyle == SimDescription.DeathType.OldAge)
                    {
                        bResetAge = true;
                    }

                    try
                    {
                        if (IsTargetGood(Target))
                        {
                            if (___bOpenDGSIsInstalled_)
                                mGrave.GhostToSim(Target, bResetAge, false);
                            else
                            {
                                NFinalizeDeath.SafeXGhostToSim(mGrave, Target, bResetAge, false);
                            }
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    {
                        if (___bOpenDGSIsInstalled_)
                            throw;
                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.ResuetSim
                        (Target.SimDescription, mGrave == null ? null : NFinalizeDeath.Find_SCGetHouseholds(mGrave.mOriginalHouseholdId), true, false);
                    }

                    Actor.ClearSynchronizationData();

                    if (mGrave != null)
                    {
                        mGrave.Destroy();
                        mGrave = null;
                    }
                    if (Target.SimDescription != null)
                    {
                        Target.SimDescription.IsNeverSelectable = false;
                        Target.SimDescription.ShowSocialsOnSim = true;
                    }
                    if (Target.Autonomy != null)
                        Target.Autonomy.DecrementAutonomyDisabled();

                    FixFadnInFakeTargetSim(fake_target_smc);
                    fake_target_smc = null;

                    return CreateTaskFadeInForActor();
                }

                Target.AddExitReason(ExitReason.HigherPriorityNext);
                Target.AddExitReason(ExitReason.CanceledByScript);

                try
                {
                    mGrave.GhostSetup(Target, false);
                }
                catch (ResetException)
                { throw; }
                catch { }
               
                mDeathProgress = DeathProgress.NormalStarted;

                FinalizeDeath();
                GrimReaperPostSequenceCleanup();
                if (IsTargetGood(Target))
                {
                    CheckTargetIsNull("ACORE failed Target ==null", 4);
                    Target.StartOneShotFunction(ReapSoulCallback, GameObject.OneShotFunctionDisposeFlag.OnDispose);
                }

                if (flag && Target.IsHorse)
                {
                    NiecHelperSituation grimReaperSituation = Actor.GetSituationOfType<NiecHelperSituation>();
                    grimReaperSituation.FadeDeathIn = true;
                }

                mDeathProgress = DeathProgress.Complete;
                
                
                //if (Target.IsHorse)
                FixFadnInFakeTargetSim(fake_target_smc);
                fake_target_smc = null;

                return CreateTaskFadeInForActor();
            }

            public bool CreateTaskFadeInForActor(bool IsTarget = false)
            {
                NiecTask.Perform(delegate
                {
                    for (int i = 0; i < 300; i++)
                    {
                        Simulator.Sleep(0);
                    }
                    if (IsTarget) 
                        Target.FadeIn();
                    Actor.FadeIn();
                });

                return true;
            }

            public string SMsg = "Run";

            public int IsSocialTargetNHSInt()
            {
                int ii = 0;
                var actor = Actor;
                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (item == null || item == actor) 
                        continue;
                    var iq = item.mInteractionQueue;
                    if (iq != null && iq.mInteractionList != null)
                    {
                        var i = iq.GetHeadInteraction() as SocialInteractionB;
                        if (i != null)
                        {
                            var iInteractionObjectPair = i.InteractionObjectPair;
                            if (iInteractionObjectPair != null
                                && iInteractionObjectPair.mInteraction is NiecMod.KillNiec.KillSimNiecX.NiecDefinitionDeathInteraction)
                            {
                                //var sim = iInteractionObjectPair.mTarget as Sim;
                                //if (sim != null && sim == actor)
                                if (iInteractionObjectPair.mTarget == actor)
                                {
                                    //var targetiq = sim.InteractionQueue;
                                    //if (targetiq != null)
                                    //{
                                    //    var targeti = iq.GetHeadInteraction();
                                    //    if (targeti != null && targeti is INHSInteraction)
                                    //    {
                                    //        ii++;
                                    //    }
                                    //}
                                    ii++;
                                }
                            }
                        }
                    }
                }
                return ii;
            }
            public int IsSocialTargetNHSIntX()
            {
                int ii = 0;
                var target = Target;
                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (item == null || item == target)
                        continue;
                    var iq = item.mInteractionQueue;
                    if (iq != null && iq.mInteractionList != null)
                    {
                        var i = iq.GetHeadInteraction() as SocialInteractionB;
                        if (i != null)
                        {
                            var iInteractionObjectPair = i.InteractionObjectPair;
                            if (iInteractionObjectPair != null
                                && iInteractionObjectPair.mInteraction is NiecMod.KillNiec.KillSimNiecX.NiecDefinitionDeathInteraction)
                            {
                                if (iInteractionObjectPair.mTarget == target)
                                {
                                    ii++;
                                }
                            }
                        }
                    }
                }
                return ii;
            }
            public bool mFastLikeTSMReaper = false;
            public AlarmHandle AlarmCheckSocialLoop = AlarmHandle.kInvalidHandle;
            public void CheckSocialInf()
            {
                if (AlarmCheckSocialLoop != AlarmHandle.kInvalidHandle && AlarmManager.Global != null)
                    AlarmManager.Global.RemoveAlarm(AlarmCheckSocialLoop);
                AlarmCheckSocialLoop = AlarmHandle.kInvalidHandle;

                //if (Target.InteractionQueue == null || Target.InteractionQueue.HasInteractionOfType(typeof(SocialInteractionB.DefinitionDeathInteraction)))
                if (Actor != null && IsTargetGood(Actor))
                {
                    if (!___bOpenDGSIsInstalled_ || IsSocialTargetNHSIntX() > 1) // 2 sims
                    {
                        NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                        
                    }
                    try
                    {
                        Actor.SetObjectToReset();
                    }
                    catch (Exception)
                    {}
                    
                }
            }

            public virtual void GoToVirtualHome__AntiNPC()
            {
                if (!___bOpenDGSIsInstalled_ && (Target.Household == null || Target.Household != Household.ActiveHousehold))
                {
                    try
                    {
                        if (Target.InteractionQueue != null) // Target.InteractionQueue.HasInteractionOfType(typeof(Sim.GoToVirtualHome.GoToVirtualHomeInternal)
                        {
                            if (NFinalizeDeath.InteractionQueue_HasInteraction<Sim.GoToVirtualHome>(Target) || NFinalizeDeath.InteractionQueue_HasInteraction<Sim.GoToVirtualHome.GoToVirtualHomeInternal>(Target))
                            {
                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                                Sims3.NiecHelp.Tasks.NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(),delegate
                                {
                                    try
                                    {
                                       // NFinalizeDeath.InteractionQueue_HasInteraction<TabContainer>(null);
                                        if (Target.mActorsUsingMe != null)
                                            Target.mActorsUsingMe.Clear();
                                        Target.DoReset(new Sims3.Gameplay.Abstracts.GameObject.ResetInformation());
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch
                                    { }
                                });
                                for (int i = 0; i < 40; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                                Target.InteractionQueue.Add(NinecReaper.Singleton.CreateInstance(Target, Target, base.GetPriority(), base.Autonomous, base.CancellableByPlayer));
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

            public void ghostSetup()
            {
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                switch (Target.SimDescription.DeathStyle)
                {

                    case SimDescription.DeathType.Electrocution:
                    case SimDescription.DeathType.BluntForceTrauma:
                    case SimDescription.DeathType.Ranting:
                        StartGhostExplosion();
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseElectrocution");
                        mSMCDeath.RequestState(true, "y", "ElectrocutionToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        StopGhostExplosion();
                        break;
                    case SimDescription.DeathType.Starve:
                        StartGhostExplosion();
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseStarvation");
                        mSMCDeath.RequestState(true, "y", "StarvationToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        StopGhostExplosion();
                        break;
                    case SimDescription.DeathType.Drown:
                        if (Target.BridgeOrigin != null)
                        {
                            Target.BridgeOrigin.MakeRequest();
                        }
                        Target.PopPosture();
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseStarvation");
                        mSMCDeath.RequestState(true, "y", "StarvationToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                    case SimDescription.DeathType.Burn:
                    case SimDescription.DeathType.MummyCurse:
                    case SimDescription.DeathType.Meteor:
                    case SimDescription.DeathType.Thirst:
                    case SimDescription.DeathType.Transmuted:
                    case SimDescription.DeathType.HauntingCurse:
                    case SimDescription.DeathType.JellyBeanDeath:
                    case SimDescription.DeathType.Jetpack:
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackSimToGhostEffectNoFadeOut);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseElectrocution");
                        mSMCDeath.RequestState(true, "y", "ElectrocutionToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                    case SimDescription.DeathType.Freeze:
                        StartGhostExplosion();
                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.AddOneShotScriptEventHandler(102u, EventCallbackFadeBodyFromPose);
                        mSMCDeath.RequestState(true, "y", "PoseFreeze");
                        mSMCDeath.RequestState(true, "y", "FreezeToFloat");
                        mSMCDeath.RequestState(false, "y", "GhostFloating");
                        break;
                    case SimDescription.DeathType.MermaidDehydrated:
                        MermaidDehydratedToGhostSequence();
                        break;

                    default:
                        if (Target.SimDescription.DeathStyle != SimDescription.DeathType.OldAge)
                        {
                            Target.SetPosition(mGhostPosition);
                        }
                        if (Target.SimDescription.mDeathStyle == SimDescription.DeathType.None)
                        {
                            Target.SimDescription.mDeathStyle = SimDescription.DeathType.Burn;
                            Target.SimDescription.IsGhost = true;
                        }
                        try
                        {
                            mGrave.GhostSetup(Target, false);
                        }
                        catch (ResetException)
                        {

                            throw;
                        }
                        catch
                        { }


                        Target.SetHiddenFlags(HiddenFlags.Nothing);
                        Target.FadeIn();
                        break;
                }
            }
            public virtual void rtfaceIN() {
                if (Actor.RoutingComponent == null) return;
                var adt = new  NiecObjectPlus() { Value = Actor.RoutingComponent };
                NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate
                {
                    bool a;
                    try
                    {
                        a = NFinalizeDeath.RouteTurnToFace(adt.Value as Sims3.Gameplay.ObjectComponents.RoutingComponent, Target.Position, 0uL, 0uL);
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { a = false; }
                    
                    float b = a ? 30 : 85;
                    while (NFinalizeDeath.Random_GetFloat(0, 100, null) < b)
                    {
                        Simulator.Sleep(10);
                        NFinalizeDeath.RouteTurnToFace(adt.Value as Sims3.Gameplay.ObjectComponents.RoutingComponent, Target.Position, 0uL, 0uL);
                    }
                });
            }

            public virtual void ApplyDeviantBehaviorToNPCSim()
            {
                try
                {
                    if (___bOpenDGSIsInstalled_ && Actor.Autonomy != null && Actor.SimDescription != null && Actor.SimDescription.TeenOrBelow && !ReapSoul_SafeGhostToSim(Actor))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Simulator.Sleep(0);
                            Punishment.ApplyDeviantBehaviorToSim(Actor, Punishment.DeviantBehaviorType.Fight);
                        }
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }
               
            }


            public virtual bool AntiNPCSimHelper() {
                try
                {
                    //int adsdsa = 0;
                    bool a = mSituation.mIsFirstSim;
                    if (!___bOpenDGSIsInstalled_)
                    {
                        OnLoadingDialogDispose();
                        rtfaceIN();
                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(30);
                    }
                    else //if (___bOpenDGSIsInstalled_)
                        //Actor.RouteTurnToFace(Target.Position);
                        Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, Target.Position));

                    mFastLikeTSMReaper = true;
                    if (!CreateGraveStone())
                    {
                        if (NFinalizeDeath.SimDescCleanse(Target.SimDescription, true, false)) 
                            Actor.FadeIn();
                        return Target.CanBeSold();

                    }

                    if (IsUnSafeUsingListSim())
                    {
                        NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                        NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Target);
                    }

                    PlaceGraveStone();
                    mDeathProgress = DeathProgress.GravePlaced;
                    /*
                    if (a)
                    {
                        Actor.FadeOut();
                        try
                        {
                           mSituation.SMCDeath.EnterState("x", "Enter"); 
                                            
                           mSituation.SMCDeath.RequestState(false, "x", "ReaperPointAtGrave");
                           mSituation.SMCDeath.RequestState(false, "x", "ReaperFloating");
                           mSituation.SMCDeath.RequestState(false, "x", "CreateTombstone");
                             *
                        }
                        catch (Exception ex)
                        {
                            StyledNotification.Format format = new StyledNotification.Format(ex.GetType().FullName + ": " + ex.Message, StyledNotification.NotificationStyle.kSimTalking);
                            StyledNotification.Show(format);
                        }
                    }
        */

                    if (__acorewIsnstalled__ || NFinalizeDeath.Random_Chance(30))
                    {
                        Vector3 position = Target.Position;
                        position += (NFinalizeDeath.Random_CoinFlip() ? 2.3f : 2.8f) * Target.ForwardVector;
                        if (___bOpenDGSIsInstalled_)
                            NFinalizeDeath.RunLightning(null, position, true);
                        else
                        {
                            if (Spawn.reRunLightning != null)
                            {
                                Spawn.reRunLightning.Push(position);
                            }
                            else NFinalizeDeath.RunLightning(null, position, true);
                        }
                    }

                    if (!mSituation.mIsFirstSim)
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(10);
                        //StateMachineClient eSMCDeath = StateMachineClient.Acquire(Actor, "DeathSequence");
                        StateMachineClient eSMCDeath = NFinalizeDeath.StateMachineClient_Acquire(Actor, "DGSDeath");
                        if (eSMCDeath == null) { sIsGrimReaperFastX = false; return false; }
                        //eSMCDeath.SetActor("x", Actor);
                        //NFinalizeDeath.StateMachineClient_SetActor(eSMCDeath, "x", Actor);
                        if (!___bOpenDGSIsInstalled_)
                            NFinalizeDeath.StateMachineClient_SetActor(eSMCDeath, "x", Actor);
                        else eSMCDeath.SetActor("x", Actor);

                        if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor))
                        {
                            eSMCDeath.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                        }

                        if (NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(Actor))
                        {
                            eSMCDeath.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                        }


                        eSMCDeath.EnterState("x", "Enter");

                        

                        //mSituation.mIsFirstSim = true;

                        eSMCDeath.AddOneShotScriptEventHandler(666u, EventCallbackFadeInReaper);
                        if (___bOpenDGSIsInstalled_)
                            Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, Target.Position));
                        NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                        eSMCDeath.RequestState("x", "Float");
                        /*
                        try
                        {
                            eSMCDeath.RequestState(false, "x", "ReaperFloating");
                        }
                        catch (Exception ex)
                        { 
                            StyledNotification.Format format = new StyledNotification.Format(ex.GetType().FullName + ": " + ex.Message, StyledNotification.NotificationStyle.kSimTalking);
                            StyledNotification.Show(format);
                        }
                        Actor.Posture = new SimCarryingObjectPosture(Actor, null);
                         */

                        Actor.Posture = new SimCarryingObjectPosture(Actor, null);

                        mWasMemberOfActiveHousehold = Target.Household == Household.ActiveHousehold;
                        if (Target.DeathReactionBroadcast == null)
                        {
                            try
                            {
                                Urnstone.CreateDeathReactionBroadcaster(Target);
                            }
                            catch (ResetException)
                            { throw; }
                            catch (Exception)
                            { }
                            
                        }
                        if (Target.Inventory != null && FindInv <DeathFlower>(Target) != null)
                        {

                            try
                            {
                                StyledNotification.Format format = new StyledNotification.Format("AntiNPCSim: Found Death Flower To Player", NFinalizeDeath.ActiveActor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                                StyledNotification.Show(format);


                                foreach (DeathFlower df in Target.Inventory.FindAll<DeathFlower>(false))
                                {
                                    Target.Inventory.RemoveByForce(df);

                                    if (!NFinalizeDeath.ActiveActor.Inventory.TryToAdd(df)) df.Destroy();



                                }


                                if (Target.SimDescription.ChildOrBelow)
                                {
                                    Target.SimDescription.TraitManager.RemoveAllElements();
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.Evil);
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.MeanSpirited);
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.Loser);
                                }
                                else
                                {
                                    Target.SimDescription.TraitManager.RemoveAllElements();
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.AntiTV);
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.Evil);
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.MeanSpirited);
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.Loser);
                                    Target.SimDescription.TraitManager.AddElement(TraitNames.DislikesChildren);
                                }


                            }
                            catch (ResetException)
                            { throw; }
                            catch (Exception)
                            { }
                            
                        }
                        else
                        {
                            try
                            {
                                if (Target.Inventory != null)
                                    NFinalizeDeath._MoveInventoryItemsToAFamilyMember(Target, Actor);
                            }
                            catch (ResetException)
                            { throw; }
                            catch (Exception)
                            { }
                        }
                        Actor.SynchronizationLevel = Sim.SyncLevel.NotStarted;
                        Target.SynchronizationLevel = Sim.SyncLevel.NotStarted;

                        if (!___bOpenDGSIsInstalled_)
                            mDeadSimsHousehold = Target.Household;
                        //eSMCDeath = mSituation.SMCDeath;

                        ThoughtBalloonManager.BalloonData dgsballoonData = new ThoughtBalloonManager.DoubleBalloonData("moodlet_mourning", Target.GetThoughtBalloonThumbnailKey());
                        dgsballoonData.BalloonType = ThoughtBalloonTypes.kSpeechBalloon;
                        dgsballoonData.mPriority = ThoughtBalloonPriority.High;

                        if (Actor.ThoughtBalloonManager != null)
                        {
                            try
                            {
                                Actor.ThoughtBalloonManager.ShowBalloon(dgsballoonData);
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch (Exception)
                            {
                                if (___bOpenDGSIsInstalled_)
                                    throw;
                            } 
                            NFinalizeDeath.CheckYieldingContext();
                        }
                        if (ShouldDoDeathEvent(Target))
                        {
                            Audio.StartSound("sting_death");
                        }

                        Target.FadeOut(false, false, 2);
                        NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                        
                        if (fUnSafe_FakeThrowRunInteraction) {
                           
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(eSMCDeath);
                           
                            eSMCDeath.RequestState(false, "x", "take_sim");
                            NFinalizeDeath.CheckYieldingContext();
                            Simulator.Sleep(80);
                            NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });
                        }
                           
                        else  eSMCDeath.RequestState("x", "take_sim");
                        try
                        {
                            if (___bOpenDGSIsInstalled_ && Target.InteractionQueue != null && !NFinalizeDeath.InteractionQueue_HasInteraction<NinecReaper>(Target))
                            {
                                InteractionInstance tae = NinecReaper.Singleton.CreateInstance(Actor, Target, KillSimNiecX.DGSAndNonDGSPriority(), false, false);
                                Target.InteractionQueue.AddNext(tae);
                                Target.AddExitReason(ExitReason.CanceledByScript);
                                Target.AddExitReason(ExitReason.HigherPriorityNext);
                            }
                        }
                        catch (ResetException)
                        { throw; }
                        catch (Exception)
                        { }
                        

                        Target.FadeOut();
                        //FinalizeDeath();

                        //GrimReaperPostSequenceCleanup();

                        Target.StartOneShotFunction(ReapSoulCallback, GameObject.OneShotFunctionDisposeFlag.OnDispose);
                        //Actor.FadeOut(false, false, 2.9f);

                        mDeathProgress = DeathProgress.Complete;
                        try
                        {
                            FinalizeDeath();
                            if (Target.Autonomy != null)
                            {
                                Target.Autonomy.DecrementAutonomyDisabled();
                            }
                            Target.SimDescription.ShowSocialsOnSim = false;
                        }
                        catch (ResetException)
                        { throw; }
                        catch (Exception)
                        { }


                        try
                        {
                            // Test New 100
                            if (!Target.SimDescription.IsGhost)
                                Target.SimDescription.IsGhost = true;

                            if (Target.SimDescription.DeathStyle == SimDescription.DeathType.None)
                                Target.SimDescription.SetDeathStyle(SimDescription.DeathType.Thirst, true);

                        }
                        catch (ResetException)
                        { throw; }
                        catch (Exception)
                        { }

                        //Simulator.Sleep(40);
                        NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                        eSMCDeath.RequestState("x", "Exit");
                        //Actor.FadeOut();

                        //Actor.SetHiddenFlags(HiddenFlags.Everything);
                        //if (Simulator.CheckYieldingContext(false))
                        //    Simulator.Sleep(70);

                        ApplyDeviantBehaviorToNPCSim();


                        return true;

                    }
                    else mSituation.mIsFirstSim = false;


                    if (a)
                    {

                        Actor.FadeIn(false, 1f);
                    }


                    GoToVirtualHome__AntiNPC();

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(20);
                    //if (!a)
                    {
                        //Actor.PlaySoloAnimation("a_death_appear_x", true);
                        //Actor.PlaySoloAnimation("a_death_appear_x", true); 
                        //Actor.PlaySoloAnimation("a_death_showOff_x", true);
                    }

                    Target.FadeOut(false, false, 4f);
                    //Actor.FadeOut(false, false, 3f);
                    //InteractionInstance tae = Services.GrimReaperSituation.BeUnReaped.Singleton.CreateInstance(Actor, Target, KillSimNiecX.DGSAndNonDGSPriority(), false, false);
                    try
                    {
                        if (___bOpenDGSIsInstalled_ && Target.InteractionQueue != null && !NFinalizeDeath.InteractionQueue_HasInteraction<NinecReaper>(Target))
                        {
                            InteractionInstance tae = NinecReaper.Singleton.CreateInstance(Actor, Target, KillSimNiecX.DGSAndNonDGSPriority(), false, false);
                            Target.InteractionQueue.AddNext(tae);
                            Target.AddExitReason(ExitReason.CanceledByScript);
                            Target.AddExitReason(ExitReason.HigherPriorityNext);
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception)
                    { }
                    

                    StateMachineClient erSMCDeath = NFinalizeDeath.StateMachineClient_Acquire(Actor, "DGSfaistDeath");
                    if (erSMCDeath == null) { sIsGrimReaperFastX = false; return false; }
                    //erSMCDeath.EnterState("x", "Enter");
                    //erSMCDeath.SetActor("x", Actor);
                    if (!___bOpenDGSIsInstalled_)
                        NFinalizeDeath.StateMachineClient_SetActor(erSMCDeath, "x", Actor);
                    else erSMCDeath.SetActor("x", Actor);

                    if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor))
                    {
                        erSMCDeath.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                    }

                    if (NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(Actor))
                    {
                        erSMCDeath.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                    }

                    erSMCDeath.EnterState("x", "Enter");
                    /*
                    try
                    {
                        mSituation.SMCDeath.RequestState(false, "x", "ReaperFloating");
                        //erSMCDeath.RequestState("x", "reaper_float");
                    }
                    catch (Exception ex)
                    {
                        StyledNotification.Format format = new StyledNotification.Format(ex.GetType().FullName + ": " + ex.Message, StyledNotification.NotificationStyle.kSimTalking);
                        StyledNotification.Show(format);
                    }
                   */
                    try
                    {

                        if (mSituation.SMCDeath != null)
                        {
                            NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSituation.SMCDeath);
                            mSituation.SMCDeath.RequestState(false, "x", "CreateTombstone");
                        }//"a_death_getScythe_"); //"CreateTombstone");
                        //mSituation.SMCDeath.RequestState(true, "x", "ReaperPointAtGrave");
                        //mSituation.SMCDeath.RequestState(false, "x", "ReaperFloating");
                        // TERSAER

                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception ex)
                    {
                        StyledNotification.Format format = new StyledNotification.Format(ex.GetType().FullName + ": " + ex.Message, StyledNotification.NotificationStyle.kSimTalking);
                        StyledNotification.Show(format);
                    }

                    if (___bOpenDGSIsInstalled_)
                        Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, Target.Position));
                    NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(erSMCDeath);
                    erSMCDeath.RequestState("x", "dgsmidle");
                    ThoughtBalloonManager.BalloonData dgsballoonDatra = new ThoughtBalloonManager.DoubleBalloonData("moodlet_mourning", Target.GetThoughtBalloonThumbnailKey());
                    dgsballoonDatra.BalloonType = ThoughtBalloonTypes.kSpeechBalloon;
                    dgsballoonDatra.mPriority = ThoughtBalloonPriority.High;
                    if (Actor.ThoughtBalloonManager != null)
                    {
                        try
                        {
                            Actor.ThoughtBalloonManager.ShowBalloon(dgsballoonDatra);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            if (___bOpenDGSIsInstalled_)
                                throw;
                        }
                        NFinalizeDeath.CheckYieldingContext();
                    }
                    NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                    if (fUnSafe_FakeThrowRunInteraction)
                    {
                        erSMCDeath.RequestState(false, "x", "dgsmland");
                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(75);
                        NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });//(new NullReferenceException("fUnSafe_FakeThrowRunInteraction"));
                    }
                    else erSMCDeath.RequestState("x", "dgsmland");
                    NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                    Simulator.Sleep(20);
                    erSMCDeath.RequestState("x", "Exit");







                    GoToVirtualHome__AntiNPC();







                    //Simulator.Sleep(14);
                    //Actor.PlaySoloAnimation("a_death_float_x", true, ProductVersion.BaseGame, false);
                    //Simulator.Sleep(9);
                    //Actor.PlaySoloAnimation("a_ghost_land_x", true, ProductVersion.BaseGame, false);
                    if (Target.Inventory != null && FindInv <DeathFlower>(Target) != null)
                    {

                        try
                        {
                            StyledNotification.Format format = new StyledNotification.Format("AntiNPCSim: Found Death Flower To Player", NFinalizeDeath.ActiveActor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                            StyledNotification.Show(format);


                            foreach (DeathFlower df in Target.Inventory.FindAll<DeathFlower>(false))
                            {
                                Target.Inventory.RemoveByForce(df);

                                if (!NFinalizeDeath.ActiveActor.Inventory.TryToAdd(df)) df.Destroy();


                                //.TryToAddStack(Target.Inventory.FindAll<DeathFlower>(false));
                            }


                            if (Target.SimDescription.ChildOrBelow)
                            {
                                Target.SimDescription.TraitManager.RemoveAllElements();
                                Target.SimDescription.TraitManager.AddElement(TraitNames.Evil);
                                Target.SimDescription.TraitManager.AddElement(TraitNames.MeanSpirited);
                                Target.SimDescription.TraitManager.AddElement(TraitNames.Loser);
                            }
                            else
                            {
                                Target.SimDescription.TraitManager.RemoveAllElements();
                                Target.SimDescription.TraitManager.AddElement(TraitNames.AntiTV);
                                Target.SimDescription.TraitManager.AddElement(TraitNames.Evil);
                                Target.SimDescription.TraitManager.AddElement(TraitNames.MeanSpirited);
                                Target.SimDescription.TraitManager.AddElement(TraitNames.Loser);
                                Target.SimDescription.TraitManager.AddElement(TraitNames.DislikesChildren);
                            }

                            //List<IGameObject> dflist = new List<IGameObject>(Target.Inventory.FindAll<DeathFlower>(false));
                        }
                        catch (ResetException)
                        { throw; }
                        catch (Exception)
                        { }
                    }
                    else
                    {
                        try
                        {
                            if (Target.Inventory != null)
                                NFinalizeDeath._MoveInventoryItemsToAFamilyMember(Target, Actor);
                        }
                        catch (ResetException)
                        { throw; }
                        catch (Exception)
                        { }
                    }
                    mDeathProgress = DeathProgress.Complete;
                    try
                    {
                        FinalizeDeath();
                        if (Target.Autonomy != null)
                        {
                            Target.Autonomy.DecrementAutonomyDisabled();
                        }
                        Target.SimDescription.ShowSocialsOnSim = false;

                        try
                        {
                            if (mSituation.SMCDeath != null)
                            {
                                mSituation.SMCDeath.EnterState("x", "Enter");
                            }
                        }
                        catch (SacsErrorException)
                        { }

                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception)
                    { }


                    try
                    {
                        // Test New 100
                        if (!Target.SimDescription.IsGhost)
                            Target.SimDescription.IsGhost = true;

                        if (Target.SimDescription.DeathStyle == SimDescription.DeathType.None)
                            Target.SimDescription.SetDeathStyle(SimDescription.DeathType.Thirst, true);

                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception)
                    { }
                    Target.StartOneShotFunction(ReapSoulCallback, GameObject.OneShotFunctionDisposeFlag.OnDispose);
                    NFinalizeDeath.CheckYieldingContext(); // new // 11:32 10/02/2020
                    Simulator.Sleep(9);

                    try
                    {
                        if (mSituation.SMCDeath != null)
                        {
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSituation.SMCDeath);
                            mSituation.SMCDeath.RequestState(false, "x", "Exit");
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception)
                    { }

                }
                finally
                {
                    try
                    {
                        if (mSituation.SMCDeath != null)
                            mSituation.SMCDeath.EnterState("x", "Enter");
                    }
                    catch (ResetException)
                    { throw; }
                    catch (Exception)
                    { }
                    GrimReaperPostSequenceCleanup();
                    //Actor.mPosture = backp;
                }
                ApplyDeviantBehaviorToNPCSim();
                return true;
            }

            //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.InternalCall)]
            //public override extern void CleanupAfterExitReason();

            public bool ForceExitSocial()
            {
                NFinalizeDeath.CheckYieldingContext();

                if (___bOpenDGSIsInstalled_)
                    mDeathProgress = DeathProgress.NormalStarted;
                else 
                    mDeathProgress = DeathProgress.None;

                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                mSMCDeath.RequestState("x", "ExitNoSocial");

                if (___bOpenDGSIsInstalled_)
                    mDeathProgress = DeathProgress.Complete;

                GrimReaperPostSequenceCleanup();

                return ___bOpenDGSIsInstalled_;
            }
            public bool ForceExitSocialLite(bool t)
            {
                NFinalizeDeath.CheckYieldingContext();

                mDeathProgress = DeathProgress.Complete;

                GrimReaperPostSequenceCleanup();

                return t;
            }

            public bool rDoneSetObjectToReset = false; // Safe

            public bool rSetObjectToReset()
            {
                if (!Simulator.CheckYieldingContext(false))
                {
#if DEBUG
                    NiecException.PrintMessagePro
                        ("rSetObjectToReset failed\nName: " + Actor.Name, false, 100);
#endif

                    //return false;
                    throw new ResetException();
                }

                NiecException.PrintMessagePro
                    ("rSetObjectToReset Called\nName: " + Actor.Name, false, 100);

                NiecTask.Perform(delegate {
                    if (rDoneSetObjectToReset) 
                        return;
                    if (___bOpenDGSIsInstalled_ && IsSocialTargetNHSIntX() > 1) // 2 sims
                    {
                        NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                    }
                    Actor.SetObjectToReset();
                });

                rDoneSetObjectToReset = false;

                try
                {
                    Simulator.Sleep(uint.MaxValue);
                }
                catch (ResetException)
                {
                    rDoneSetObjectToReset = true;
                    throw;
                }
               
                return true;
            }







            public void CheckTargetIsNull(string funcName, uint debug)
            {
                if (Target == null)
                {
                    if (InteractionObjectPair == null)
                    {
                        throw new NullReferenceException("Error: (InteractionObjectPair == null) " + debug);
                    }

                    if (!___bOpenDGSIsInstalled_)
                    {
                        NiecException.PrintMessagePro("CheckTargetIsNull found: " + debug, false, float.MaxValue);
                        InteractionObjectPair.mTarget = NiecMod.Helpers.NiecRunCommand.looptargetdied_data ?? GetCheckSimDeadX() ?? (isdgmods ? Actor : null) ?? NFinalizeDeath.ActiveActor;
                    }
                    if (Target == null)
                        throw new NullReferenceException("Error: (Target == null) " + debug);
                }
            }

            public void FixFadnInFakeTargetSim(Sim fake_target_smc)
            {
                if (___bOpenDGSIsInstalled_ && fake_target_smc != null && Target != fake_target_smc && !fake_target_smc.HasBeenDestroyed)
                {
                    fake_target_smc.FadeIn();
                }
            }

            public unsafe override bool Run()
            {
                //NFinalizeDeath.RemoveAllSimNiecNullForGrave();
                onRuntimeThisRun = true;
                if (Actor == null)
                    throw new NotSupportedException("Actor == null");
                if (InteractionObjectPair == null) // stop
                    throw new NotSupportedException("InteractionObjectPair == null");
                string DEBUG = null;
                try
                {
                    Actor.ClearExitReasons();
                    /*
                    if (Target.Service is Sims3.Gameplay.Services.GrimReaper)
                    {
                        if (!TwoButtonDialog.Show("ReapSoul: Killing the " + Target.Name + " [GrimReaper] will prevent souls to cross over to the other side. If this happens, Sims that die from now on will be trapped between this world and the next, and you'll end up with a city full of dead bodies laying around. Are you sure you want to kill Death itself?", "Yes", "No"))
                        {
                            Notfixdgs = true;
                            mDeathProgress = DeathProgress.Complete;
                            return false;
                        }
                    }
                     */




                    if (__acorewIsnstalled__ && InteractionObjectPair.mTarget == null)
                    {
                        InteractionObjectPair.mTarget = NiecMod.Helpers.NiecRunCommand.looptargetdied_data ?? GetCheckSimDeadX() ?? NFinalizeDeath.ActiveActor_AAndChildAndTeen ?? (isdgmods ? Actor : null);
                        if (Target == null)
                        {
                            throw new NotSupportedException("AweCore: Target == null");
                        }
                    }

                    

                    if (__acorewIsnstalled__ && Target.SimDescription == null)
                    {
                        Target.mSimDescription = global::NiecMod.Helpers.Create.NiecNullSimDescription(false, false, false);
                    }

                    CheckTargetIsNull("ReapSoul", 0);

                    if (!NFinalizeDeath.GameObjectIsValid(Actor.ObjectId.mValue))
                    {
                        if (__acorewIsnstalled__)
                            NFinalizeDeath.ThrowResetException(null);
                        return false;
                    }

                    if (___bOpenDGSIsInstalled_ || !__acorewIsnstalled__)
                    {
                        if (mSituation == null)
                            mSituation = Actor.GetSituationOfType<NiecHelperSituation>();
                    }
                    else
                    {
                        if (mSituation == null)
                            mSituation = NFinalizeDeath.NewSafeGetSituationOfType<NiecHelperSituation>(Actor);
                    }

                    if (mSituation != null && mSituation.OkSuusse && UnsafeRunReapSoul(Actor))
                    {


                        {
                            CheckTargetIsNull("ReapSoul", 1);
                            if (!___bOpenDGSIsInstalled_ && Target.SimDescription == null)
                            {
                                Target.mSimDescription = global::NiecMod.Helpers.Create.NiecNullSimDescription(false, false, false);
                            }
                            if (Target.SimDescription.DeathStyle == SimDescription.DeathType.None)
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
                                if (!Target.SimDescription.IsFrankenstein)
                                {
                                    list.Add(SimDescription.DeathType.Electrocution);
                                }
                                list.Add(SimDescription.DeathType.Burn);
                                if (Target.SimDescription.Elder)
                                {
                                    list.Add(SimDescription.DeathType.OldAge);
                                }
                                if (Target.SimDescription.IsWitch)
                                {
                                    list.Add(SimDescription.DeathType.HauntingCurse);
                                }
                                SimDescription.DeathType randomObjectFromList = RandomUtil.GetRandomObjectFromList(list, ListCollon.SafeRandomPart2);
                                Target.SimDescription.SetDeathStyle(randomObjectFromList, Target.IsSelectable);
                                //Notfixdgs = true;
                                //return true;
                            }

                            //if (shuoldbRunSB || Actor.LotCurrent != Target.LotCurrent)
                            {
                                RunSafePos2020(Actor, Target, NewYear2020SafePos_forcebool01);
                            }
                            //else
                            //{
                            //    if (___bOpenDGSIsInstalled_)
                            //    {
                            //        Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, Target.Position));
                            //    }
                            //}

                            if (IsUnSafeUsingListSim())
                            {
                                NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                                NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Target);
                            }

                            //debugopendgs
#if __My 
                            if (Target != NiecMod.Helpers.NiecRunCommand.looptargetdied_data && IsGrimReaperFast() && !mSituation.OkSuusseD && Actor != Target && (___bTestOpenDGS || !AssemblyCheckByNiec.IsInstalled("OpenDGS")) && !NFinalizeDeath.IsAllActiveHousehold_SimObject(Target)) // TODO: Why OpenDGS Add Fake Active Actor in PlumbBob.SafeSelectedActor? NonOpenDGS PlumbBob.sSingleton.mSelectedActor
                            {
                                if (RandomAntiNPCOpenDGSOnly(Actor))
                                {
                                    //Posture backp = Actor.mPosture;
                                    CheckTargetIsNull("ReapSoul", 2);
                                    GoToVirtualHome__AntiNPC();
                                    if (___bOpenDGSIsInstalled_)
                                        NFinalizeDeath.List_FastClearEx(ref mSituation. mInteractions);
                                    return AntiNPCSimHelper();
                                }
                            }
#endif
                            CheckTargetIsNull("ReapSoul", 3);
                            if (!(mSituation.OkSuusseD || TestDivingPool) && !NFinalizeDeath.IsAllActiveHousehold_SimObject(Target) && (__acorewIsnstalled__ || NFinalizeDeath.Random_Chance(32)))
                            {
                                Vector3 position = NFinalizeDeath.GetPositionBase(Target.ObjectId.mValue); //Target.Position;
                                position += (NFinalizeDeath.Random_CoinFlip() ? 1.9f : 2.8f) * NFinalizeDeath.GetForwardBase(Target.ObjectId.mValue); //Target.ForwardVector;
                                if (___bOpenDGSIsInstalled_)
                                    NFinalizeDeath.RunLightning(null, position, true);
                                else
                                {
                                    if ((ForceRunReapSoulPet || Target.IsPet) && NFinalizeDeath.Random_Chance(85))
                                    { }
                                    else
                                    {
                                        if (Spawn.reRunLightning != null)
                                        {
                                            Spawn.reRunLightning.Push(position);
                                        }
                                        else
                                            NFinalizeDeath.RunLightning(null, position, true);
                                    }
                                }
                            }


                            if (!___bOpenDGSIsInstalled_)
                            {
                                OnLoadingDialogDispose();
                            }


                            Actor.FadeIn(false, 3f);



                            //Lot ActorLot = Actor.LotCurrent;
                            //Lot TargetLot = Target.LotCurrent;
                            GoToVirtualHome__AntiNPC();
                            if (___bOpenDGSIsInstalled_)
                                NFinalizeDeath.List_FastClearEx(ref mSituation.mInteractions);
                            //if (Target.Posture is ScubaDiving && !Target.SimDescription.IsMermaid)
                            //if (Target != NFinalizeDeath.ActiveActor)
                            if (!ForceRunReapSoul || mSituation.OkSuusseD)
                            {
                                if (mSituation.OkSuusseD)// || ActorLot != null && ActorLot.IsDivingLot || TargetLot != null && TargetLot.IsDivingLot && Target.Posture != null && Target.Posture is ScubaDiving && !Target.SimDescription.IsMermaid)
                                {
                                    return ReapPetPool();
                                }

                                if (ForceRunReapSoulPet || Target.IsPet)// && !Target.IsInActiveHousehold)
                                {
                                    return ReapPetSoul();
                                }
                            }
                            if (!CreateGraveStone())
                            {
                                Notfixdgs = true;
                                mDeathProgress = DeathProgress.Complete;
                                return false;
                            }


                            var fake_target_smc = FakeSetActor(Actor, Target);
                            mSMCDeath = mSituation.SMCDeath;
                            if (___bOpenDGSIsInstalled_)
                            {
                                mSMCDeath.SetActor("y", fake_target_smc);
                                mSMCDeath.SetActor("grave", mGrave);
                            }
                            else {
                                if (AssemblyCheckByNiec.IsInstalled("AweCore") && mSMCDeath == null) {
                                    if (NFinalizeDeath.Random_CoinFlip())
                                        NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });
                                    mSituation.CleanUp__();
                                    NiecHelperSituationPosture.r_internal(Actor);
                                    mSMCDeath = mSituation.SMCDeath;
                                    if (mSMCDeath == null)
                                        NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });
                                }
                                NFinalizeDeath.StateMachineClient_SetActor(mSMCDeath, "y", fake_target_smc);
                                NFinalizeDeath.StateMachineClient_SetActor(mSMCDeath, "grave", mGrave);
                            }

                            if (NFinalizeDeath.StateMachineClient_SimIsPet(fake_target_smc))
                            {
                                mSMCDeath.SetParameter(585333186u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                            }

                            if (NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(fake_target_smc))
                            {
                                mSMCDeath.SetParameter(2084444177u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                            }

                            //fake_target_smc = null;
                            mSMCDeath.EnterState("y", "Enter");

                            if (Target.SimDescription != null && Target.SimDescription.DeathStyle == SimDescription.DeathType.Drown)
                            {
                                if (!RouteGrimReaperToEdgeOfTargetPool())
                                {
                                    //Actor.RouteTurnToFace(Target.Position);
                                   //if (!___bOpenDGSIsInstalled_ && Actor.RoutingComponent != null)
                                   //{ NiecTask.Perform(ScriptExecuteType.Threaded, delegate { NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, Target.Position, 0uL, 0uL); }); Simulator.Sleep(30); }
                                   //else if (___bOpenDGSIsInstalled_)
                                   //    Actor.RouteTurnToFace(Target.Position);
                                    debug_runtime = DEBUGRUNTIME.DEBUG_0;
                                    if (!___bOpenDGSIsInstalled_)
                                    {
                                        NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                                        {
                                            if (Actor.RoutingComponent == null) return;
                                            NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, Target.Position, 0uL, 0uL);
                                            while (NFinalizeDeath._GetCHeadInteraction(Actor) == this)
                                            {
                                                Simulator.Sleep(25);
                                                if (Actor.RoutingComponent == null || Simulator.GetProxy(Target.ObjectId) == null)
                                                    break;
                                                NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, Target.Position, 0uL, 0uL);
                                            }
                                        });

                                        NFinalizeDeath.CheckYieldingContext();
                                        Simulator.Sleep(45);
                                    }
                                    else //if (Actor.RoutingComponent != null)
                                    {
                                        //Actor.RouteTurnToFace(sim.Position);
                                        Simulator.Sleep(5);
                                        Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, Target.Position));
                                    }
                                }
                            }
                            else if (!mSituation.mIsFirstSim && SafePosNHSTickOnly())
                            {
                                debug_runtime = DEBUGRUNTIME.DEBUG_1B;
                               // Actor.DoRoute(route);
                                try
                                {
                                    if (SafePos2020() && NFinalizeDeath.Random_Chance(47)) { }
                                    else
                                    {
                                        if (___bOpenDGSIsInstalled_)
                                        {
                                            Route route = Actor.CreateRoute();
                                            route.PlanToPointRadialRange(Target.Position, 1f, 5f, RouteDistancePreference.PreferNearestToRouteDestination, RouteOrientationPreference.TowardsObject, Target.LotCurrent.LotId, null);
                                            Actor.DoRoute(route);
                                        }
                                        else
                                        {
                                            NiecTask.CreateWaitPerformWithExecuteType(NFinalizeDeath.GetCurrentExecuteType(), () =>
                                            {
                                                Route route = Actor.CreateRoute();
                                                route.PlanToPointRadialRange(Target.Position, 1f, 5f, RouteDistancePreference.PreferNearestToRouteDestination, RouteOrientationPreference.TowardsObject, Target.LotCurrent.LotId, null);
                                                Actor.DoRoute(route);
                                            }).Waiting();
                                        }
                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (Exception)
                                {
                                    NFinalizeDeath.CheckYieldingContext();
                                    if (___bOpenDGSIsInstalled_)
                                        throw;
                                }
                                NFinalizeDeath.CheckYieldingContext();
                            }
                            /*
                        else
                        {
                            mSituation.mIsFirstSim = false;
                        }
                         */

                            /*
                            Route route = Actor.CreateRoute();
                            route.PlanToPointRadialRange(Target.Position, 1f, 5f, RouteDistancePreference.PreferNearestToRouteDestination, RouteOrientationPreference.TowardsObject, Target.LotCurrent.LotId, null);
                            Actor.DoRoute(route);
                            mSituation.mIsFirstSim = true;
                             * */

                            debug_runtime = DEBUGRUNTIME.DEBUG_1;
                            if (___bOpenDGSIsInstalled_)
                            {
                                PlaceGraveStone();
                            }
                            else
                            {
                                NFinalizeDeath.CheckYieldingContext();
                                NiecTask.CreateWaitPerformWithExecuteType(NFinalizeDeath.GetCurrentExecuteType(), () =>
                                {
                                    Simulator.Sleep(0);
                                    PlaceGraveStone();
                                }).Waiting();
                            }
                            //PlaceGraveStone();
                            mDeathProgress = DeathProgress.GravePlaced;
                            debug_runtime = DEBUGRUNTIME.DEBUG_2;
                            //if (!___bOpenDGSIsInstalled_ && Actor.RoutingComponent != null)
                            //{ NiecTask.Perform(ScriptExecuteType.Threaded, delegate { NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, Target.Position, 0uL, 0uL); }); Simulator.Sleep(30); }
                            //else if (___bOpenDGSIsInstalled_)
                            //    Actor.RouteTurnToFace(Target.Position);


                            if (!___bOpenDGSIsInstalled_)
                            {
                                NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                                {
                                    if (Actor.RoutingComponent == null) return;
                                    NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, Target.Position, 0uL, 0uL);
                                    while (NFinalizeDeath._GetCHeadInteraction(Actor) == this)
                                    {
                                        Simulator.Sleep(15);
                                        if (Actor.RoutingComponent == null || Simulator.GetProxy(Target.ObjectId) == null)
                                            break;
                                        NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, Target.Position, 0uL, 0uL);
                                    }
                                });
                                NFinalizeDeath.CheckYieldingContext();
                                Simulator.Sleep(45);
                            }
                            else //if (Actor.RoutingComponent != null)
                            {
                                //Actor.RouteTurnToFace(sim.Position);
                                
                                Simulator.Sleep(5);
                                Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, Target.Position));
                                
                            }
                            
                            //Actor.RouteTurnToFace(Target.Position);

                            //PetStartleBehavior.CheckForStartle(Actor, StartleType.GrimReaperAppear);
                            /*
                            if (!mSituation.mIsFirstSim)
                            {
                                mSMCDeath.EnterState("x", "Enter");
                            }
                             * */
                            debug_runtime = DEBUGRUNTIME.DEBUG_3;
                            Actor.FadeIn(false, 3f);

                            //if (fUnSafe_FakeThrowRunInteraction)
                            //{
                            //    mSMCDeath.RequestState(false, "x", "CreateTombstone");
                            //    Simulator.Sleep(20);
                            //    NFinalizeDeath.ThrowOtherException(new NullReferenceException("fUnSafe_FakeThrowRunInteraction"));
                            //}
                            //else 

                            GoToVirtualHome__AntiNPC();
                            debug_runtime = DEBUGRUNTIME.DEBUG_4;
                            try
                            {
                                NFinalizeDeath.CheckYieldingContext();
                                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                                if (___bOpenDGSIsInstalled_)
                                {
                                    //if (!mSMCDeath.mHandleEventsAsynchronously)
                                    if (!NFinalizeDeath.SMCIsGood("x", mSMCDeath))
                                    {
                                        return rSetObjectToReset();
                                    }
                                    mSMCDeath.RequestState(true, "x", "CreateTombstone");//, (Sims3.SimIFace.SACS.DriverRequestFlags)0x80);
                                }
                                else
                                {
                                    if (__acorewIsnstalled__)
                                    {
                                        if (NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask)
                                        {
                                            NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, mSMCDeath);
                                            NFinalizeDeath.SMCIsValid("x", true, mSMCDeath);
                                        }
                                    }
                                    var execute_type = NFinalizeDeath.GetCurrentExecuteType();
                                    NiecTask.Perform(execute_type, () => { 
                                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                                        mSMCDeath.RequestState(true, "x", "CreateTombstone"); 
                                    });
                                    NFinalizeDeath.CheckYieldingContext();
                                    if (NFinalizeDeath.Random_Chance(35))
                                    {
                                        if (execute_type == ScriptExecuteType.Threaded)
                                        {
                                            for (int i = 0; i < 200; i++)
                                            {
                                                Simulator.Sleep(0);
                                            }
                                        }
                                        else
                                        {
                                            Simulator.Sleep(200);
                                        }
                                    }
                                    else
                                    {
                                        Simulator.Sleep(0);
                                    }
                                }
                            }
                            catch (ResetException) { throw; }
                            catch (Exception ex)
                            {
                                if (___bOpenDGSIsInstalled_)
                                {
                                    if (ex is OperationCanceledException && !IsGrimReaperFast())
                                    {
                                        ex.stack_trace = null;
                                        ex.message = "";
                                        ex.trace_ips = null;
                                        ex.class_name = null;
                                        ex.source = null;
                                    }
                                    else throw;
                                }
                                NFinalizeDeath.CheckYieldingContext();
                            }

                            debug_runtime = DEBUGRUNTIME.DEBUG_5;

                            NFinalizeDeath.CheckYieldingContext();

                            GoToVirtualHome__AntiNPC();

                            if (AlarmManager.Global != null)
                                AlarmCheckSocialLoop = AlarmManager.Global.AddAlarm(WorkingNiecHelperSituationCount > 10 ? 14f : 4f, TimeUnit.Hours, CheckSocialInf, !___bOpenDGSIsInstalled_ ? null : "CheckSocialLoop", AlarmType.AlwaysPersisted, null);
                            
                            if (Actor.ThoughtBalloonManager != null)
                            {
                                ThoughtBalloonManager.BalloonData balloonData = new ThoughtBalloonManager.DoubleBalloonData("balloon_moodlet_mourning", (fake_target_smc ?? Target).GetThoughtBalloonThumbnailKey());
                                balloonData.BalloonType = ThoughtBalloonTypes.kSpeechBalloon;
                                balloonData.mPriority = ThoughtBalloonPriority.High;
                                //fake_target_smc = null;
                                try
                                {
                                    Actor.ThoughtBalloonManager.ShowBalloon(balloonData);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch (Exception)
                                {
                                    NFinalizeDeath.CheckYieldingContext();
                                    if (___bOpenDGSIsInstalled_)
                                        throw;
                                }
                                NFinalizeDeath.CheckYieldingContext();
                                
                            }
                            //mSMCDeath.RequestState(true, "x", "ReaperPointAtGrave");
                            debug_runtime = DEBUGRUNTIME.DEBUG_6;
                            if (___bOpenDGSIsInstalled_)
                                Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, Target.Position));

                            NFinalizeDeath.CheckYieldingContext();

                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);

                            if (fUnSafe_FakeThrowRunInteraction)
                            {
                                mSMCDeath.RequestState(false, "x", "ReaperPointAtGrave");
                                NFinalizeDeath.CheckYieldingContext();
                                Simulator.Sleep(75);
                                NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });//(new NullReferenceException("fUnSafe_FakeThrowRunInteraction"));
                            }
                            else {
                                if (__acorewIsnstalled__ && !isdgmods)
                                {
                                    try
                                    {
                                        mSMCDeath.RequestState(true, "x", "ReaperPointAtGrave"); 
                                    }
                                    catch (SacsErrorException) 
                                    {
                                        mSMCDeath.mAbortRequested = false;
                                    }
                                }
                                else mSMCDeath.RequestState(true, "x", "ReaperPointAtGrave"); 
                            }
                            mSMCDeath.RequestState(false, "x", "ReaperFloating");

                            debug_runtime = DEBUGRUNTIME.DEBUG_7;

                            DEBUG = "1";

                            mGhostPosition = GetPositionForGhost(Target, mGrave);
                            Lot lotCurrent = Target.LotCurrent;

                            try
                            {
                                if (lotCurrent != Target.LotHome && lotCurrent != null && lotCurrent.Household != null)
                                {
                                    Target.GreetSimOnLot(lotCurrent);
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }

                            debug_runtime = DEBUGRUNTIME.DEBUG_8;
                            GoToVirtualHome__AntiNPC();

                            try
                            {
                                RequestWalkStyle(Target, Sim.WalkStyle.GhostWalk);
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { if (___bOpenDGSIsInstalled_) throw; NFinalizeDeath.CheckYieldingContext(); } // custom

                            if (___bOpenDGSIsInstalled_ && (Target.SimDescription == null || Target.HasBeenDestroyed))
                            {
                                // mSMCDeath.RequestState("x", "ExitNoSocial");
                                //
                                // if (!___bOpenDGSIsInstalled_)
                                //     mDeathProgress = DeathProgress.None;
                                //
                                // GrimReaperPostSequenceCleanup();
                                // return false;
                                return ForceExitSocial();
                            }
                            debug_runtime = DEBUGRUNTIME.DEBUG_9;

                            DEBUG = "2";


                            if (___bOpenDGSIsInstalled_ || SafeGhostSetup)
                            {
                                ghostSetup();
                            }
                            else {
                                //NiecTask.Perform(delegate { ghostSetup(); });
                                debug_runtime = DEBUGRUNTIME.DEBUG_10;
                                if (Target.LotCurrent == null)
                                    Target.mLotCurrent = LotManager.GetWorldLot();
                                if (Target.SimDescription == null)
                                    Target.mSimDescription = ListCollon.NullSimSimDescription;
                                if (___bOpenDGSIsInstalled_ &&(Target.SimDescription == null || Target.HasBeenDestroyed))
                                {
                                    //mSMCDeath.RequestState("x", "ExitNoSocial");
                                    //
                                    //if (!___bOpenDGSIsInstalled_)
                                    //    mDeathProgress = DeathProgress.None;
                                    //
                                    //GrimReaperPostSequenceCleanup();
                                    return ForceExitSocial();
                                }

                                if (Target.SimDescription.DeathStyle != SimDescription.DeathType.OldAge)
                                {
                                    Target.SetPosition(mGhostPosition);
                                }

                                if (Target.SimDescription.mDeathStyle == SimDescription.DeathType.None)
                                {
                                    Target.SimDescription.mDeathStyle = SimDescription.DeathType.Drown;
                                    Target.SimDescription.IsGhost = true;
                                }

                                try
                                {
                                    mGrave.GhostSetup(Target, false);
                                }
                                catch (ResetException)
                                {throw;}
                                catch{ }

                                Target.AddToWorld();
                                Target.SetHiddenFlags(HiddenFlags.Nothing);
                                Target.FadeIn();
                                

                                

                                //Target.SetPosition(mGhostPosition);

                                


                                if (Target.LotCurrent.IsWorldLot)
                                    Target.SetPosition(GetPositionForGhostPro( Actor,Target, mGrave));

                                
                                if (Target.LotCurrent.IsWorldLot) {
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
                                            lotwt = RandomUtil.GetRandomObjectFromList<Lot>(lieastwt, ListCollon.SafeRandomPart2);
                                        }
                                        Target.SetPosition(lotwt.Position);


                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch
                                    { }

                                    try
                                    {
                                        StyledNotification.Format format = new StyledNotification.Format("Found :)" + Target.GetLocalizedName(), Target.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                                        StyledNotification.Show(format);
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch
                                    { }
                                }

                                debug_runtime = DEBUGRUNTIME.DEBUG_11;
                            }
                            //if (___bOpenDGSIsInstalled_)
                            //    RequestWalkStyle(Sim.WalkStyle.RobotHoverRun);
                            //else
                            //    RequestWalkStyle(Sim.WalkStyle.DeathWalk);

                            // AntiNPC
                            if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor)) {
                                try
                                {
                                    RequestWalkStyle
                                        (___bOpenDGSIsInstalled_ || ReapSoul_SafeGhostToSim(Actor) ? Sim.WalkStyle.ForceRun : Sim.WalkStyle.RideHorseRun);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                { if (___bOpenDGSIsInstalled_) throw; NFinalizeDeath.CheckYieldingContext(); }
                            }
                            else
                            {
                                try
                                {
                                    RequestWalkStyle(
                                        GameUtils.IsInstalled(ProductVersion.EP11) && (___bOpenDGSIsInstalled_ || ReapSoul_SafeGhostToSim(Actor)) ?
                                            Sim.WalkStyle.RobotHoverRun :
                                        Sim.WalkStyle.ForceRun
                                    );
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch
                                { if (___bOpenDGSIsInstalled_) throw; NFinalizeDeath.CheckYieldingContext(); }
                                
                            }
                            string nameInteraction;
                            try
                            {
                                nameInteraction = Localization.LocalizeString(Target.SimDescription.IsFemale, "Gameplay/Actors/Sim/ReapSoul:InteractionName");
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch { nameInteraction = "Expire"; }
                            debug_runtime = DEBUGRUNTIME.DEBUG_12;
                            NFinalizeDeath.CheckYieldingContext();

                            Target.AddExitReason(ExitReason.CanceledByScript);

                            if (!___bOpenDGSIsInstalled_)
                                Target.AddExitReason(ExitReason.HigherPriorityNext);

                            GoToVirtualHome__AntiNPC();

                            if (!___bOpenDGSIsInstalled_)
                            {
                                NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(),delegate
                                {
                                    //NiecTask r;
                                    //NiecTask.SSetFakeObjectId(Actor.ObjectId, out r);
                                    if (NFinalizeDeath.GetCurrentExecuteType() == ScriptExecuteType.Task)
                                    {
                                        for (int i = 0; i < 250; i++)
                                        {
                                            Simulator.Sleep(0);
                                        }
                                    }
                                    else
                                    {
                                        Simulator.Sleep(250);
                                    }
                                    if (Target.InteractionQueue != null && Target.InteractionQueue.IsRunning(NinecReaper.Singleton, true))
                                        Simulator.Wake(Target.ObjectId, false);
                                });

                            }
                            if (___bOpenDGSIsInstalled_&& (Target == null || Simulator.GetProxy(Target.ObjectId) == null))
                            {
                                return ForceExitSocial();
                            }
                            debug_runtime = DEBUGRUNTIME.DEBUG_13;
                            bool checkerror = false;
                            try
                            {
                                Actor.ClearExitReasons();
                                /*
                                if (!sEventCallbackFadeBodyFromPoseDone && Target.SimDescription != null && !Target.SimDescription.IsGhost)
                                {
                                    EventCallbackFadeBodyFromPose(null, null);
                                    Target.SimDescription.IsGhost = true;
                                }*/
                                checkerror = BeginSocialInteraction(new KillSimNiecX.NiecDefinitionDeathInteraction(nameInteraction, true), true, NFinalizeDeath.StateMachineClient_SimIsPet(Target) ? Target.GetSocialRadiusWith(Actor) : 1.25f, false) || Actor.CurrentInteraction is NiecAppear || (!___bOpenDGSIsInstalled_ && RandomUtil.RandomChance(40));
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            {
                                
                                //checkerror = false;
                                //
                                //mSMCDeath.RequestState("x", "ExitNoSocial");
                                //
                                //if (!___bOpenDGSIsInstalled_)
                                //    mDeathProgress = DeathProgress.NormalStarted;
                                //
                                //GrimReaperPostSequenceCleanup();
                                return ForceExitSocial();
                            }

                            NFinalizeDeath.CheckYieldingContext();

                            if (Target.SimDescription == null)
                                Target.mSimDescription = ListCollon.NullSimSimDescription;
                            if (checkerror)
                            {
                                if (___bOpenDGSIsInstalled_ && (Target == null || Simulator.GetProxy(Target.ObjectId) == null))
                                {
                                    return ForceExitSocial();
                                }
                                if ( /*Target.SimDescription.DeathStyle != (SimDescription.DeathType)69u && */ ReapSoul_SafeGhostToSim(Target) || Target == NFinalizeDeath.ActiveActor)
                                {
                                    /*
                                    mDeathProgress = DeathProgress.UnluckyStarted;
                                    if (Target.SimDescription.DeathStyle == SimDescription.DeathType.OldAge)
                                    {
                                        Target.Motives.SetValue(CommodityKind.VampireThirst, -50f);
                                    }
                                    mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimUnlucky);
                                    mSMCDeath.RequestState(false, "x", "Unlucky");
                                    mSMCDeath.RequestState(true, "y", "Unlucky");
                                    mSMCDeath.RequestState(false, "x", "Exit");
                                    mSMCDeath.RequestState(true, "y", "Exit");
                                    GrimReaperPostSequenceCleanup();
                                    mDeathProgress = DeathProgress.Complete;
                                    return true;
                                     */

                                    mDeathProgress = DeathProgress.DeathFlowerStarted;

                                    if (mDeathFlower != null)
                                    {
                                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimDeathFlower);
                                    }
                                    else
                                    {
                                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimUnlucky);
                                    }
                                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                                    mSMCDeath.RequestState(false, "x", "DeathFlower");
                                    mSMCDeath.RequestState(true, "y", "DeathFlower");
                                    mSMCDeath.RequestState(false, "x", "Exit");
                                    mSMCDeath.RequestState(true, "y", "Exit");

                                    GrimReaperPostSequenceCleanup();
                                    mDeathProgress = DeathProgress.Complete;

                                    FixFadnInFakeTargetSim(fake_target_smc);
                                    fake_target_smc = null;

                                    return true;
                                }

                                if (Target.SimDescription.DeathStyle == SimDescription.DeathType.Ranting && ReapSoul_SafeGhostToSim(Target) && Target.TraitManager != null && !Target.TraitManager.HasElement(TraitNames.ThereAndBackAgain))
                                {
                                    mDeathProgress = DeathProgress.UnluckyStarted;
                                    mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimRanting);
                                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                                    mSMCDeath.RequestState(false, "x", "Unlucky");
                                    mSMCDeath.RequestState(true, "y", "Unlucky");
                                    mSMCDeath.RequestState(false, "x", "Exit");
                                    mSMCDeath.RequestState(true, "y", "Exit");
                                    GrimReaperPostSequenceCleanup();
                                    mDeathProgress = DeathProgress.Complete;

                                    FixFadnInFakeTargetSim(fake_target_smc);
                                    fake_target_smc = null;

                                    return true;
                                }
                                if (Target.Inventory != null)
                                {
                                    mDeathFlower = FindInv<DeathFlower>(Target);
                                    if (mDeathFlower != null && ReapSoul_SafeGhostToSim(Target))
                                    {
                                        mDeathProgress = DeathProgress.DeathFlowerStarted;
                                        Target.Inventory.RemoveByForce(mDeathFlower);
                                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimDeathFlower);
                                        mSMCDeath.RequestState(false, "x", "DeathFlower");
                                        mSMCDeath.RequestState(true, "y", "DeathFlower");
                                        mDeathFlower.Destroy();
                                        mDeathFlower = null;
                                        mSMCDeath.RequestState(false, "x", "Exit");
                                        mSMCDeath.RequestState(true, "y", "Exit");
                                        GrimReaperPostSequenceCleanup();
                                        mDeathProgress = DeathProgress.Complete;

                                        FixFadnInFakeTargetSim(fake_target_smc);
                                        fake_target_smc = null;

                                        return true;
                                    }

                                    else NFinalizeDeath._MoveInventoryItemsToAFamilyMember
                                            (Target, NFinalizeDeath.HouseholdMembersToSim(Household.ActiveHousehold, true, false) ?? Actor);//Target.MoveInventoryItemsToSim(Actor);
                                }
                                /*
                                if (Target.SimDescription.DeathStyle != SimDescription.DeathType.OldAge)
                                {
                                    Actor.AddInteraction(ChessChallenge.Singleton);
                                }
                                 * */
                                mDeathProgress = DeathProgress.NormalStarted;
                                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                                /*
                                if (Target.IsInActiveHousehold)
                                {
                                    mSMCDeath.RequestState(false, "x", "Accept");
                                    mSMCDeath.RequestState(true, "y", "Accept");
                                    Route route2 = Target.CreateRouteTurnToFace(mGrave.Position);
                                    route2.ExecutionFromNonSimTaskIsSafe = true;
                                    Target.DoRoute(route2);
                                }
                                else if (Target.IsInActiveHousehold)
                                {
                                    mSMCDeath.RequestState(false, "x", "Reject");
                                    mSMCDeath.RequestState(true, "y", "Reject");
                                    Route route3 = Target.CreateRouteTurnToFace(mGrave.Position);
                                    route3.ExecutionFromNonSimTaskIsSafe = true;
                                    Target.DoRoute(route3);
                                    mSMCDeath.RequestState(false, "x", "GhostJumpInGrave");
                                    mSMCDeath.RequestState(true, "y", "GhostJumpInGrave");
                                }
                                 * */
                                //else
                                {
                                    Target.FadeIn(false, 3f);

                                    mSMCDeath.RequestState(false, "x", "GhostKickedDive");
                                    mSMCDeath.RequestState(true, "y", "GhostKickedDive");

                                    mSMCDeath.RequestState(false, "x", "Kicked");
                                    mSMCDeath.RequestState(true, "y", "Kicked");

                                }

                                mSMCDeath.RequestState(false, "y", "Exit");
                                mSMCDeath.RequestState(true, "x", "Exit");
                            }
                            else
                            {
                                Target.FadeIn(false, 3f);




                                if (Target == NFinalizeDeath.ActiveActor //Target.SimDescription.DeathStyle != (SimDescription.DeathType)69u 
                                    || ReapSoul_SafeGhostToSim(Target)  //Target.IsInActiveHousehold
                                    )
                                {
                                    mDeathProgress = DeathProgress.UnluckyStarted;
                                    mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimUnlucky);
                                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                                    mSMCDeath.RequestState(false, "x", "Unlucky");
                                    mSMCDeath.RequestState(true, "y", "Unlucky");
                                    mSMCDeath.RequestState(false, "x", "Exit");
                                    mSMCDeath.RequestState(true, "y", "Exit");
                                    GrimReaperPostSequenceCleanup();
                                    Target.AddExitReason(ExitReason.HigherPriorityNext);
                                    mDeathProgress = DeathProgress.Complete;

                                    FixFadnInFakeTargetSim(fake_target_smc);
                                    fake_target_smc = null;

                                    return true;
                                }

                                if (Target.Inventory != null)
                                {
                                    mDeathFlower = FindInv<DeathFlower>(Target);

                                    if (mDeathFlower != null && ReapSoul_SafeGhostToSim(Target))
                                    {
                                        mDeathProgress = DeathProgress.DeathFlowerStarted;
                                        Target.Inventory.RemoveByForce(mDeathFlower);
                                        mSMCDeath.AddOneShotScriptEventHandler(101u, EventCallbackResurrectSimDeathFlower);
                                        mSMCDeath.RequestState(false, "x", "Unlucky");
                                        mSMCDeath.RequestState(true, "y", "Unlucky");
                                        mDeathFlower.Destroy();
                                        mDeathFlower = null;
                                        mSMCDeath.RequestState(false, "x", "Exit");
                                        mSMCDeath.RequestState(true, "y", "Exit");
                                        GrimReaperPostSequenceCleanup();
                                        Target.AddExitReason(ExitReason.HigherPriorityNext);
                                        mDeathProgress = DeathProgress.Complete;

                                        FixFadnInFakeTargetSim(fake_target_smc);
                                        fake_target_smc = null;

                                        return true;
                                    }

                                    else
                                        //Target.MoveInventoryItemsToSim(Actor);
                                        NFinalizeDeath._MoveInventoryItemsToAFamilyMember
                                            (Target, NFinalizeDeath.HouseholdMembersToSim(Household.ActiveHousehold, true, false) ?? Actor);
                                }

                                if (Target.SimDescription.mDeathStyle == SimDescription.DeathType.None)
                                    Target.SimDescription.mDeathStyle = SimDescription.DeathType.Burn;

                                Target.SimDescription.IsGhost = true;

                                mDeathProgress = DeathProgress.NormalStarted;
                                mSMCDeath.RequestState("x", "ExitNoSocial");

                                Target.FadeOut();

                                mDeathEffect = mGrave.GetSimToGhostEffect(Target, mGrave.Position);
                                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                                mSMCDeath.SetEffectActor("deathEffect", mDeathEffect);
                                if (mDeathEffect != null)
                                    mDeathEffect.Start();
                            }
                            //mSituation.CheckAndSetPetSavior(Target);

                            mDeathProgress = DeathProgress.NormalStarted;


                            try
                            {
                                FinalizeDeath();
                                GrimReaperPostSequenceCleanup();
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }

                            if (!Target.HasBeenDestroyed)
                                Target.StartOneShotFunction(ReapSoulCallback, GameObject.OneShotFunctionDisposeFlag.OnDispose);

                            mDeathProgress = DeathProgress.Complete;

                            if (___bOpenDGSIsInstalled_ && Actor.SimDescription.TeenOrBelow && !ReapSoul_SafeGhostToSim(Actor))
                            {
                                for (int i = 0; i < 5; i++)
                                    Punishment.ApplyDeviantBehaviorToSim(Actor, Punishment.DeviantBehaviorType.Fight);
                                //Punishment.ApplyDeviantBehaviorToSim(Actor, Punishment.DeviantBehaviorType.Fight); 
                            }
                        }
                    }
                }
                catch (NMAntiSpyException)
                { NFinalizeDeath.SafeForceTerminateRuntime(); }
                catch (ResetException) {
                    if (mSituation != null) {
                        mSituation.StopGrimReaperSmoke();
                        mSituation.OkSuusse = false; 
                        mSituation.OkSuusseDD = false; 
                    }
                    throw;
                }
                catch (Exception exception)
                {
                   
                    if (!___bOpenDGSIsInstalled_)
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        Simulator.Sleep(30);
                    }

                    string r = "";
                    if (DEBUG != null)
                        r = DEBUG; 

                    if (mSituation != null)
                        mSituation.StopGrimReaperSmoke();

                    
                    
                    //if (mSituation != null)
                    //{
                    //    mSituation.OkSuusseDD = false;
                    //    mSituation.OkSuusseD = false;
                    //    mSituation.OkSuusse = false;
                    //}

                    if (mSituation != null)
                        mSituation.CleanUp__();

                    NFinalizeDeath.CheckYieldingContext();

                   // if (!(exception is StackOverflowException) && exception.Message != "fUnSafe_FakeThrowRunInteraction")
                    if ( !( (exception is StackOverflowException) || (exception.Message == "fUnSafe_FakeThrowRunInteraction")) )
                    {
                        if (___bOpenDGSIsInstalled_)
                        {
                            if (exception.stack_trace == null && exception is OperationCanceledException)
                            {
                                
                            }
                            else NiecException.PrintMessage(SMsg + " NRP " + r + exception.Message + NiecException.NewLine + exception.StackTrace);
                        }
                        else NiecException.PrintMessagePro(SMsg + "NRP " + exception.Message + NiecException.NewLine + exception.StackTrace, false, 100);
                    }
                    //else { NiecException.PrintMessagePro(SMsg + "NRP " + exception.Message + NiecException.NewLine + exception.StackTrace, false, 100); }

                    GrimReaperPostSequenceCleanup();
                    try
                    {
                        try
                        {
                            if (___bOpenDGSIsInstalled_)
                            {
                                Actor.ResetAllAnimation();
                            }
                            else
                            {
                                NFinalizeDeath.NResetAllAnimation(Actor);
                            }
                        }
                        catch (StackOverflowException) 
                        {
                            if (!___bOpenDGSIsInstalled_)
                                NFinalizeDeath.ThrowResetException(null);
                            throw;
                        }
                       
                        NiecMod.Nra.SpeedTrap.Sleep();
                        AnimationUtil.StopAllAnimation(Actor);
                        NiecMod.Nra.SpeedTrap.Sleep();
                        NiecMod.Nra.SpeedTrap.Sleep();
                        Actor.SetObjectToReset();
                    }
                    catch
                    {
                        if (___bOpenDGSIsInstalled_)
                            throw;
                    }
                    NFinalizeDeath.CheckYieldingContext();

                }
                
                return true;
            }

            protected bool CreateGraveStone()
            {

                Urnstone.KillSim killSim = Target.CurrentInteraction as Urnstone.KillSim;
                if (killSim != null)
                {
                    killSim.CancelDeath = false;
                }

                mWasMemberOfActiveHousehold = NFinalizeDeath._IsActiveHousehold(Target.Household); //Target.Household == Household.ActiveHousehold;
                if (Target.DeathReactionBroadcast == null)
                {
                    Urnstone.CreateDeathReactionBroadcaster(Target);
                }
                Actor.SynchronizationLevel = Sim.SyncLevel.NotStarted;
                Target.SynchronizationLevel = Sim.SyncLevel.NotStarted;
                if (mGrave == null) 
                    mGrave = HelperNra.TFindGhostsGrave(Target.SimDescription);
                if (mGrave == null)
                {
                    if (Urnstone.kFutureDeathType == null)
                        Urnstone.kFutureDeathType = new SimDescription.DeathType[0];

                    try
                    {
                        if (PlumbBob.SelectedActor == null)
                        {
                            if (!___bOpenDGSIsInstalled_) using (TempSetActiveActorAndHousehold.Run(NFinalizeDeath.GetRandomSim()))
                            {
                                mGrave = Urnstone.CreateGrave(Target.SimDescription, true, true);
                            }
                            else
                            {
                                mGrave = Urnstone.CreateGrave(Target.SimDescription, true, true);
                            }
                        }
                        else
                        {
                            mGrave = Urnstone.CreateGrave(Target.SimDescription, true, false);
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }
                } 
                if (mGrave == null) {
                    Urnstone urnstone = GlobalFunctions.CreateObject("UrnstoneHumanPoor", ProductVersion.BaseGame, Vector3.Origin, 0, Vector3.UnitZ, null, null) as Urnstone;
                    if (urnstone == null)
                    {
                        NFinalizeDeath.Assert("CreateGraveStone(): failed to GlobalFunctions.CreateObject Urnstone!");
                        return false;
                    }
                    urnstone.SetDeadSimDescription(Target.SimDescription);
                    mGrave = urnstone;
                }
                if (mGrave == null)
                {
                    NFinalizeDeath.Assert("CreateGraveStone(): mGrave == null");
                    return false;
                }
                if (!___bOpenDGSIsInstalled_)
                    mDeadSimsHousehold = Target.Household;
                mGrave.AddToUseList(Actor);
                mSituation = mSituation ?? Actor.GetSituationOfType<NiecHelperSituation>();
                mSituation.LastGraveCreated = mGrave;
                mDeathProgress = DeathProgress.GraveCreated;
                return mGrave != null;
            }

            protected virtual void PlaceGraveStone()
            {
                if (mGrave ==null || Simulator.GetProxy(mGrave.ObjectId) == null) return;
                if (ScriptCore.Objects.Objects_GetPosition(mGrave.ObjectId.mValue) != NFinalizeDeath.Vector3_O && NFinalizeDeath.Random_Chance(77))
                    return;
                mGrave.SetOpacity(0f, 0f);
                if (Target == null)
                {
                    CheckTargetIsNull("void PlaceGraveStone()", 0);
                    return;
                }
                if (Target.SimDescription == null)
                {
                    Target.mSimDescription = NiecMod.Helpers.Create.NiecNullSimDescription();
                    Target.SimDescription.mSim = Target;
                }
                SimDescription.DeathType deathStyle = Target.SimDescription.DeathStyle;
                World.FindGoodLocationParams fglParams = (deathStyle == SimDescription.DeathType.Drown || Simulator.GetProxy(Target.ObjectId) == null) ? new World.FindGoodLocationParams(Actor.Position) : new World.FindGoodLocationParams(Target.Position);
                fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, fglParams, false))
                {
                    fglParams.BooleanConstraints = FindGoodLocationBooleans.None;
                    if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, fglParams, false))
                    {
                        if (Simulator.GetProxy(Target.ObjectId) == null)
                            mGrave.SetPosition(Actor.Position);
                        else
                        {
                            var aa = NFinalizeDeath.ActiveActor_AAndChildAndTeen;
                            if (aa != null)
                                mGrave.SetPosition(aa.Position);
                            else
                                mGrave.SetPosition(Target.Position);
                        }
                    }
                }
                mGrave.OnHandToolMovement();
                mGrave.FadeIn(false, 10f);
                mGrave.FogEffectStart();
            }

            protected Vector3 GetPositionForGhost(Sim ghost, Urnstone grave)
            {
                World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(grave.HasBeenDestroyed ? Actor.Position : grave.Position);
                fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                Vector3 pos;
                Vector3 fwd;
                if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                {
                    Simulator.Sleep(0u);
                    fglParams.BooleanConstraints &= ~FindGoodLocationBooleans.StayInRoom;
                    if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                    {
                        Simulator.Sleep(0u);
                        fglParams.BooleanConstraints &= ~FindGoodLocationBooleans.Routable;
                        if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                        {
                            Simulator.Sleep(0u);
                            fglParams.BooleanConstraints = FindGoodLocationBooleans.None;
                            if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                            {
                                return grave.HasBeenDestroyed ? Actor.Position : grave.Position;
                            }
                        }
                    }
                }
                return pos;
            }

            public static Vector3 GetPositionForGhostPro(Sim ActorV, Sim ghost, Urnstone grave)
            {
                World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(grave.HasBeenDestroyed ? ActorV.Position : grave.Position);
                fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                Vector3 pos;
                Vector3 fwd;
                if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                {
                    Simulator.Sleep(0u);
                    fglParams.BooleanConstraints &= ~FindGoodLocationBooleans.StayInRoom;
                    if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                    {
                        Simulator.Sleep(0u);
                        fglParams.BooleanConstraints &= ~FindGoodLocationBooleans.Routable;
                        if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                        {
                            Simulator.Sleep(0u);
                            fglParams.BooleanConstraints = FindGoodLocationBooleans.None;
                            if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                            {
                                return ActorV.Position;
                            }
                        }
                    }
                }
                return pos;
            }

            private bool RouteGrimReaperToEdgeOfTargetPool()
            {
                if (Target.Posture == null) return false;
                Pool pool = Target.Posture.Container as Pool;
                if (pool != null)
                {
                    return pool.RouteToEdge(Actor);
                }
                return false;
            }

            public bool sEventCallbackFadeBodyFromPoseDone = false;

            public void EventCallbackFadeBodyFromPosePool(StateMachineClient sender, IEvent evt) {
                uint eventId = evt.EventId;
                if (eventId == 102)
                {
                    Target.SetForward(mGhostForward);
                }
                EventCallbackFadeBodyFromPose(sender, evt);
            }


            protected virtual void EventCallbackFadeBodyFromPose(StateMachineClient sender, IEvent evt)
            {
                if (!sEventCallbackFadeBodyFromPoseDone)
                    sEventCallbackFadeBodyFromPoseDone = true;
                //else return;
                if (Target == null || Target.SimDescription == null) return;
                if (!IsTargetGood(Target)) return;
                SimDescription.DeathType deathtype = Target.SimDescription.DeathStyle;

                try
                {
                    switch (evt != null ? evt.EventId : 102)
                    {
                        case 101u:
                            Target.FadeOut();
                            mDeathEffect = mGrave.GetSimToGhostEffect(Target, mGhostPosition);
                            NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                            mSMCDeath.SetEffectActor("deathEffect", mDeathEffect);
                            mDeathEffect.Start();
                            break;
                        case 102u:
                            Target.SetPosition(mGhostPosition);
                            mGrave.GhostSetup(Target, false);
                            Target.SetHiddenFlags(HiddenFlags.Nothing);
                            if (mDeathEffect != null)
                            {
                                mDeathEffect.Stop();
                                mDeathEffect = null;
                            }
                            Target.FadeIn();
                            break;
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch (Exception)
                {
                    Target.SimDescription.IsGhost = true;
                    if (deathtype == SimDescription.DeathType.None)
                        deathtype = SimDescription.DeathType.Drown;
                    Target.SimDescription.mDeathStyle = deathtype;
                    Target.FadeIn();
                }
                
            }

            protected void EventCallbackSimToGhostEffectNoFadeOut(StateMachineClient sender, IEvent evt)
            {
                if (Target == null)
                {
                    if (___bOpenDGSIsInstalled_ && InteractionObjectPair != null)
                    {
                        if (mSMCDeath != null)
                            InteractionObjectPair.mTarget = (Sim)mSMCDeath.GetActor("y");

                        if (InteractionObjectPair.mTarget == null)
                            InteractionObjectPair.mTarget = NiecMod.Helpers.NiecRunCommand.looptargetdied_data ?? GetCheckSimDeadX();
                    }
                    else
                        CheckTargetIsNull("EventCallbackSimToGhostEffectNoFadeOut", 1);
                }

                if (Target == null)
                {
                    NFinalizeDeath.ThrowResetException(null);
                }

                if (Target.SimDescription == null)
                    Target.mSimDescription = NiecMod.Helpers.Create.NiecNullSimDescription();

                if (Target.SimDescription.mDeathStyle == SimDescription.DeathType.None) 
                    Target.SimDescription.mDeathStyle = SimDescription.DeathType.Drown;

                try
                {
                    mDeathEffect = mGrave.GetSimToGhostEffect(Target, mGhostPosition);
                    if (mDeathEffect != null)
                    {
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                        mSMCDeath.SetEffectActor("deathEffect", mDeathEffect);
                        mDeathEffect.Start();
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                {}
            }

            private void StartGhostExplosion()
            {
                if (Target.SimDescription.DeathStyle == SimDescription.DeathType.Freeze)
                {
                    mGhostExplosion = VisualEffect.Create("ashesToAshesFreeze");
                }
                else
                {
                    mGhostExplosion = VisualEffect.Create("ashesToAshes");
                }
                mGhostExplosion.SetPosAndOrient(Target.Position, Target.ForwardVector, Target.UpVector);
                mGhostExplosion.Start();
            }

            private void StopGhostExplosion()
            {
                if (mGhostExplosion != null)
                {
                    mGhostExplosion.Stop();
                    mGhostExplosion = null;
                }
            }

            protected void ReapSoulCallback()
            {
                if (Target == null)
                {
                    if (___bOpenDGSIsInstalled_)
                        return;
                    else CheckTargetIsNull("CleanUpAndDestroyDeadSim AweCore", 1);
                }
                try
                {
                    int timeout = 0;
                    do
                    {
                        Simulator.Sleep(10u);
                        timeout++;
                        InteractionQueue inxte = Target.InteractionQueue;
                        if (inxte == null)
                            break;
                        if (inxte.HasInteractionOfType(KillSimNiecX.NiecDefinitionDeathInteraction.SocialSingleton))
                            timeout = 0;
                    }
                    while (Target.ReferenceList != null && Target.ReferenceList.Count > 0 && timeout < 30);
                }
                catch (ResetException)
                {throw;}
                catch { }
                
                CleanUpAndDestroyDeadSim(false);
            }

            public void CleanUpAndDestroyDeadSim(bool forceCleanup)
            {
                if (Target == null)
                {
                    if (___bOpenDGSIsInstalled_)
                        return;
                    else CheckTargetIsNull("CleanUpAndDestroyDeadSim AweCore", 1);
                }
                SimDescription simDescription = Target.SimDescription;
                try
                {
                    if (mDeathEffect != null)
                    {
                        mDeathEffect.Stop();
                        mDeathEffect = null;
                    }

                    Target.ClearReferenceList();
                    if (simDescription == null) 
                        return;

                    if (forceCleanup || mSituation.LastSimOfHousehold == null || mSituation.LastSimOfHousehold != Target)
                    {
                        if (simDescription.Household == null || simDescription.Household.IsPetHousehold)
                        {
                           
                            PetPoolType petPoolType = PetPoolType.None;
                            switch (simDescription.Species)
                            {
                                case CASAgeGenderFlags.Dog:
                                case CASAgeGenderFlags.LittleDog:
                                    petPoolType = PetPoolType.StrayDog;
                                    break;
                                case CASAgeGenderFlags.Cat:
                                    petPoolType = PetPoolType.StrayCat;
                                    break;
                                case CASAgeGenderFlags.Horse:
                                    petPoolType = ((!simDescription.IsUnicorn) ? PetPoolType.WildHorse : PetPoolType.Unicorn);
                                    break;
                            }
                            if (PetPoolManager.IsPetInPoolType(simDescription, petPoolType))
                            {
                                PetPoolManager.RemovePet(petPoolType, simDescription);
                            }
                        }
                        if (mGrave != null)
                            mGrave.GhostCleanup(Target, true);
                        if (Target.Autonomy != null)
                        {
                            Target.Autonomy.DecrementAutonomyDisabled();
                        }
                        simDescription.ShowSocialsOnSim = true;
                        if (MoveToMausoleum(mGrave) && !mWasMemberOfActiveHousehold && Household.ActiveHousehold != null && Actor.LotCurrent != Household.ActiveHousehold.LotHome)
                        {
                            if (mGrave != null)
                                mGrave.FadeOut(false, 5f, HandleNPCGrave);
                        }
                        
                    }
                }
                catch (ResetException)
                { throw;}
                catch { }

                simDescription.IsGhost = true;

                if (simDescription.mDeathStyle == SimDescription.DeathType.None)
                    simDescription.mDeathStyle = SimDescription.DeathType.Drown;

                simDescription.IsNeverSelectable = false;

                if (NiecMod.Helpers.NiecRunCommand.looptargetdied_data == Target)
                    return;

                if (___bOpenDGSIsInstalled_)
                {
                    ObjectGuid targetobjectid = Target.ObjectId;
                    try
                    {
                        Target.Destroy();
                    }
                    catch
                    {
                        try
                        {
                            Simulator.DestroyObject(targetobjectid);
                        }
                        catch
                        { }

                    }
                }
                else {
                    //SimDescription TaDesc = Target.SimDescription;
                    //simDescription.mSim = null;
                    //Sim TarSim = Target;

                    try
                    {
                        if (simDescription != null && simDescription.Household != null)
                        {
                            simDescription.Household.Remove(simDescription);
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch {
                        NFinalizeDeath.Household_Remove(simDescription, false);
                    }

                    try
                    {
                        List<Household> householdlist;
                        if (NFinalizeDeath.Should_SimNoHousehold_HouseholdFound(simDescription, true, out householdlist)) {
                            foreach (var itemHousehold in householdlist)
                            {
                                if (itemHousehold == null) 
                                    continue;

                                Household.Members mem = itemHousehold.mMembers;
                                if (mem == null)
                                    continue;

                                for (int i = 0; i < 100; i++)
                                {
                                    if (mem.mAllSimDescriptions != null)
                                        mem.mAllSimDescriptions.Remove(simDescription);
                                    if (mem.mPetSimDescriptions != null)
                                        mem.mPetSimDescriptions.Remove(simDescription);
                                    if (mem.mSimDescriptions != null)
                                        mem.mSimDescriptions.Remove(simDescription);
                                    simDescription.mHousehold = null;
                                }
                                if (mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                                {
                                    NFinalizeDeath. HouseholdCleanse(itemHousehold, false, true);
                                }
                            }
                            householdlist.Clear();
                        }
                        NFinalizeDeath.FixAllHouseholdMembers();
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }


                    NFinalizeDeath.ForceDestroyObject(Target);
                    //global::NiecMod.Helpers.Create.NiecNullSimDescription(true);
                    //TarSim.mSimDescription = ListCollon.NullSimSimDescription;
                }
            }

            public static bool MoveToMausoleum(Urnstone urnstone)
            {
                IMausoleum[] list = NFinalizeDeath.SC_GetObjects<IMausoleum>();
                if (list.Length == 0)
                {
                    return false;
                }
                if (list.Length > 0)
                {
                    return true;
                }
                return false;
            }

            public void EventCallbackResurrectSim()
            {
                SimDescription simd = Target.SimDescription;
                if (simd == null) {
                    if (mGrave != null)
                        simd = mGrave.DeadSimsDescription;
                    if (simd == null)
                        return;
                }
                if (!ReapSoul_SafeGhostToSim(Target))
                {
                    NiecTask.Perform(delegate {
                        Simulator.Sleep(1);
                        NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Target);
                        NFinalizeDeath.GetKillNPCSimToGhost(Target, simd.DeathStyle);
                    });
                    return;
                }
                try
                {
                    bool resetAge = false;
                    if (simd.DeathStyle == SimDescription.DeathType.OldAge)
                    {
                        resetAge = true;
                    }

                    if (IsTargetGood(Target) && mGrave != null)
                    {
                        if (___bOpenDGSIsInstalled_)
                        {
                            mGrave.GhostToSim(Target, resetAge, false);
                        }
                        else
                        {
                            NFinalizeDeath.SafeXGhostToSim(mGrave, Target, resetAge, false);
                        }
                    }
                    else {
                        NFinalizeDeath.ResuetSim
                            (simd, NFinalizeDeath.Find_SCGetHouseholds(mGrave != null ? mGrave.mOriginalHouseholdId : 0), ___bOpenDGSIsInstalled_, false);

                        Actor.ClearSynchronizationData();

                        NFinalizeDeath.ActorCheckYieldingContext(Actor);

                        if (mGrave != null)
                            mGrave.FadeOut(false, true);

                        return;
                    }

                    Actor.ClearSynchronizationData();

                    if (mGrave != null)
                        mGrave.FadeOut(false, true);

                    simd.IsNeverSelectable = false;
                    simd.ShowSocialsOnSim = true;

                    if (Target.Autonomy != null)
                        Target.Autonomy.DecrementAutonomyDisabled();
                }
                catch (ResetException)
                { throw; }
                catch { 
                    NFinalizeDeath.ResuetSim
                    (simd, NFinalizeDeath.Find_SCGetHouseholds(mGrave != null ? mGrave.mOriginalHouseholdId : 0), ___bOpenDGSIsInstalled_, false);
                    if (IsTargetGood(Target))
                        Target.FadeIn();
                    simd.IsNeverSelectable = false;
                    simd.ShowSocialsOnSim = true;
                    NFinalizeDeath.ActorCheckYieldingContext(Actor);
                }
                
                
            }

            public virtual void EventCallbackResurrectSimDeathFlower(StateMachineClient sender, IEvent evt)
            {
                try
                {
                    EventTracker.SendEvent(EventTypeId.kGotSavedByDeathFlower, Target);
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch { }
                
                mDeathProgress = DeathProgress.DeathFlowerPostEvent;
                if (ShouldDoDeathEvent(Target))
                {
                    StyledNotification.Format format = new StyledNotification.Format(Localization.LocalizeString("Gameplay/Services/GrimReaper:DeathFlower1", Target), Actor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                    StyledNotification.Show(format);
                }
                if (mDeathFlower != null && Actor.ThoughtBalloonManager != null && !mDeathFlower.HasBeenDestroyed)
                {
                    ThoughtBalloonManager.BalloonData balloonData = new ThoughtBalloonManager.BalloonData(mDeathFlower.GetThoughtBalloonThumbnailKey());
                    balloonData.mPriority = ThoughtBalloonPriority.High;
                    balloonData.Duration = ThoughtBalloonDuration.Medium;
                    balloonData.mCoolDown = ThoughtBalloonCooldown.Medium;
                    balloonData.LowAxis = ThoughtBalloonAxis.kLike;

                    Actor.ThoughtBalloonManager.ShowBalloon(balloonData);
                }
                EventCallbackResurrectSim();
            }

            public void EventCallbackResurrectSimUnlucky(StateMachineClient sender, IEvent evt)
            {
                mDeathProgress = DeathProgress.UnluckyPostEvent;
                if (ShouldDoDeathEvent(Target))
                {
                    StyledNotification.Format format = new StyledNotification.Format("Good Sim :)", Actor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                    StyledNotification.Show(format);
                }
                EventCallbackResurrectSim();
            }

            public void EventCallbackResurrectSimRanting(StateMachineClient sender, IEvent evt)
            {
                mDeathProgress = DeathProgress.UnluckyPostEvent;
                if (ShouldDoDeathEvent(Target))
                {
                    StyledNotification.Format format = new StyledNotification.Format(Localization.LocalizeString("Gameplay/Services/GrimReaper:RantingWarning", Target), Actor.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                    StyledNotification.Show(format);
                }
                if (Target.BuffManager != null)
                    Target.BuffManager.AddElement(BuffNames.ThereAndBackAgain, Origin.FromRanting);
                EventCallbackResurrectSim();
            }

            public void GrimReaperPostSequenceCleanup()
            {
                Actor.Posture = Actor.Standing;
            }

            public void FinalizeDeath()
            {
                //MakeHouseholdHorsesGoHome();




                SimDescription si = Target.SimDescription;
                
                if (si != null)
                {
                    try
                    {
                        if (si.AssignedRole != null)
                            si.AssignedRole.RemoveSimFromRole(); // Custom 3:08 18/05/2019
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }
                    try
                    {
                        si.AssignedRole = null;
                        if (si.BoardingSchool != null && si.IsEnrolledInBoardingSchool())
                        {
                            si.BoardingSchool.OnRemovedFromSchool();
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }
                }
                else { 
                    Target.mSimDescription = global:: Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription;
                    Target.mSimDescription.mSim = Target;
                    NFinalizeDeath.ForceDestroyObject(Target); 
                    return; 
                }




                try
                {
                    if (si.IsEnrolledInBoardingSchool())
                    {
                        si.BoardingSchool.OnRemovedFromSchool();
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }
                
                try
                {
                    if (___bOpenDGSIsInstalled_)
                    {
                        if (Target.Household != null)
                        {
                            Urnstone.FinalizeSimDeath(si, Target.Household, mSituation.PetSavior == null);
                        }
                        else
                        {
                            Urnstone.FinalizeSimDeath(si, Household.NpcHousehold, mSituation.PetSavior == null);
                        }
                    }
                    else
                    {
                        if (Target.Household != null)
                        {
                            FinalizeSimDeathPro(si, Target.Household, mSituation.PetSavior == null);
                        }
                        else
                        {
                            FinalizeSimDeathPro(si, Household.NpcHousehold, mSituation.PetSavior == null);
                        }
                    }
                }
                catch (ResetException)
                { throw; }
                catch {
                    try
                    {
                        if (___bOpenDGSIsInstalled_)
                        {
                            if (Target.Household != null)
                            {
                                Urnstone.FinalizeSimDeath(si, Target.Household, mSituation.PetSavior == null);
                            }
                            else
                            {
                                Urnstone.FinalizeSimDeath(si, Household.NpcHousehold, mSituation.PetSavior == null);
                            }
                        }
                        else
                        {
                            if (Target.Household != null)
                            {
                                FinalizeSimDeathPro(si, Target.Household, false);
                            }
                            else
                            {
                                FinalizeSimDeathPro(si, Household.NpcHousehold, false);
                            }
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    { }
                }
                
                int minuteOfDeath = (int)Math.Floor(SimClock.ConvertFromTicks(SimClock.CurrentTime().Ticks, TimeUnit.Minutes)) % 60;
                mGrave.MinuteOfDeath = minuteOfDeath;
                if (___bOpenDGSIsInstalled_)
                {
                    Target.SetHiddenFlags(HiddenFlags.Everything);
                }
                else {
                    if (Target.mParent != null)
                    {
                        try
                        {
                            Target.SetHiddenFlags(HiddenFlags.Everything);
                        }
                        catch (StackOverflowException)
                        {
                            NFinalizeDeath.SafeForceTerminateRuntime();
                            throw;
                        }
                        catch (ResetException) { throw; }
                        catch (Exception) { }
                    }
                }
                Household household = Target.Household;
                if (household != null)
                {
                    // Moded Not If
                    /*
                    if (household.IsActive)
                    {
                        Target.MoveInventoryItemsToAFamilyMember();
                    }
                    */
                    //
                    if (___bOpenDGSIsInstalled_)
                    {
                        //var inv = Target.Inventory;
                        if (Target.Inventory != null)
                        Target.MoveInventoryItemsToAFamilyMember();
                    }
                    else NFinalizeDeath._MoveInventoryItemsToAFamilyMember(Target, NFinalizeDeath.HouseholdMembersToSim(Target.Household, true, false) ?? PlumbBob.SelectedActor);
                    if (Target.LotCurrent != null)
                    {
                        Target.LotCurrent.LastDiedSim = Target.SimDescription;
                        Target.LotCurrent.NumDeathsOnLot++;
                    }
                    Actor.ClearSynchronizationData();
                    /*
                    if (Target.SimDescription.DeathStyle != SimDescription.DeathType.OldAge)
                    {
                        Actor.RemoveInteractionByType(ChessChallenge.Singleton);
                    }
                     * */
                    if (BoardingSchool.ShouldSimsBeRemovedFromBoardingSchool(household))
                    {
                        BoardingSchool.RemoveAllSimsFromBoardingSchool(household);
                    }
                    /*
                    if (!Target.BuffManager.HasElement(BuffNames.Ensorcelled))
                    {
                        int num = 0;
                        foreach (Sim allActor in household.AllActors)
                        {
                            if (allActor.BuffManager.HasElement(BuffNames.Ensorcelled))
                            {
                                num++;
                            }
                        }
                        if (household.AllActors.Count == num + 1)
                        {
                            foreach (Sim allActor2 in household.AllActors)
                            {
                                if (allActor2.BuffManager.HasElement(BuffNames.Ensorcelled))
                                {
                                    allActor2.BuffManager.RemoveElement(BuffNames.Ensorcelled);
                                }
                            }
                        }
                    }
                    int num2 = household.AllActors.Count - household.GetNumberOfRoommates();
                    if (household.IsActive && num2 == 1 && !Household.RoommateManager.IsNPCRoommate(Target))
                    {
                        mSituation.LastSimOfHousehold = Target;
                    }
                    else
                    {
                        if (Target.IsActiveSim)
                        {
                            LotManager.SelectNextSim();
                        }
                        household.RemoveSim(Target);
                    }*/

                    if (NFinalizeDeath.ActiveActor == Target)
                    {
                        LotManager.SelectNextSim();
                        try
                        {
                            household.Remove(si);
                        }
                        catch (ResetException) { throw; }
                        catch
                        {
                            Household.Members mexa = household.mMembers;
                            if (mexa != null)
                            {

                                mexa.mAllSimDescriptions.Remove(si);
                                mexa.mPetSimDescriptions.Remove(si);
                                mexa.mSimDescriptions.Remove(si);
                            }
                            si.mHousehold = null;

                        }
                        
                    }
                }
                mGrave.RemoveFromUseList(Actor);
                Ocean singleton = Ocean.Singleton;
                if (singleton != null && singleton.IsActorUsingMe(Target))
                {
                    singleton.RemoveFromUseList(Target);
                    Target.Posture = null;
                }
            }

            public void HandleNPCGrave()
            {
                if (MoveToMausoleum(mGrave))
                {
                    AddGraveToRandomMausoleum(mGrave);
                    return;
                }
                if (!mGrave.HasBeenDestroyed)
                    mGrave.FadeIn();
            }


            public static void AddGraveToRandomMausoleum(Urnstone urn)
            {
                if (urn == null) return;
                if (!MoveToMausoleum(urn))
                {
                    return;
                }
                IMausoleum randomObjectFromList = NFinalizeDeath.GetRandomGameObject<IMausoleum>();
                if (randomObjectFromList != null)
                {
                    try
                    {
                        foreach (Sim reference in urn.ReferenceList)
                        {
                            if (reference.InteractionQueue != null)
                                reference.InteractionQueue.PurgeInteractions(urn);
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }
                    
                    if (!randomObjectFromList.Inventory.TryToAdd(urn))
                    {
                        return;
                    }
                }
            }

            public void MakeHouseholdHorsesGoHome()
            {
                if (!mWasMemberOfActiveHousehold && !Target.IsAtHome)
                {
                    Lot lotCurrent = Target.LotCurrent;
                    if (!lotCurrent.IsWorldLot)
                    {
                        List<Sim> lazyList = null;
                        foreach (Sim allActor in Target.Household.AllActors)
                        {
                            if (allActor.LotCurrent == lotCurrent && allActor != Target)
                            {
                                if (allActor.IsHuman)
                                {
                                    if (allActor.SimDescription.ChildOrAbove)
                                    {
                                        return;
                                    }
                                }
                                else if (allActor.IsHorse)
                                {
                                    Lazy.Add(ref lazyList, allActor);
                                }
                            }
                        }
                        if (lazyList != null)
                        {
                            foreach (Sim item in lazyList)
                            {
                                Sim.MakeSimGoHome(item, false);
                            }
                        }
                    }
                }
            }

            public void MermaidDehydratedToGhostSequence()
            {
                StartGhostExplosion();
                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                mSMCDeath.RequestState(true, "y", "PoseDehydrate");
                Target.FadeOut();
                mDeathEffect = mGrave.GetSimToGhostEffect(Target, mGhostPosition);
                if (mDeathEffect != null)
                {
                    NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSMCDeath);
                    mSMCDeath.SetEffectActor("deathEffect", mDeathEffect);
                    mDeathEffect.Start();
                }
                Target.SetPosition(mGhostPosition);
                mGrave.GhostSetup(Target, false);
                Target.SetHiddenFlags(HiddenFlags.Nothing);
                if (mDeathEffect != null)
                {
                    mDeathEffect.Stop();
                    mDeathEffect = null;
                }
                Target.FadeIn();
                mSMCDeath.RequestState(true, "y", "DehydrateToFloat");
                mSMCDeath.RequestState(false, "y", "GhostFloating");
                StopGhostExplosion();
            }
        }



        // End





































        // Interaction
        public class NiecAppear : Interaction<Sim, Sim>, INHSInteraction
        {
            [DoesntRequireTuning]
            private sealed class Definition : InteractionDefinition<Sim, Sim, NiecAppear>, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence
            {
                public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair interaction)
                {
                    return "NHS Appear";
                }


                public override string[] GetPath(bool bPath)
                {
                    return new string[] { "Niec Helper Situation" };
                }

                public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    /*
                    if (AssemblyCheckByNiec.IsInstalled("DGSCore"))
                    {
                        if (actor == null) throw new ArgumentNullException("actor");
                        if (target == null) throw new ArgumentNullException("target");
                        if (isAutonomous) throw new System.TypeLoadException("Cant Find Autonomous");
                    }
                     * */
                    if (actor == null) return false;
                    if (target == null) return false;



                    if (isAutonomous && !actor.IsSelectable) return false;

                    if (__bIsGrimReaper(target))
                        return false;


                    //if (actor.IsNPC) return false;
                    NiecHelperSituation situationOfType = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(actor);//actor.GetSituationOfType<NiecHelperSituation>();
                    if (situationOfType == null) return false;
                    if (situationOfType.OkSuusseDD) return true;
                    if (situationOfType.OkSuusse) return false;
                    //return true;
                    /*
                    try
                    {
                        if (!AssemblyCheckByNiec.IsInstalled("OpenDGS") && !target.IsInActiveHousehold)
                        {
                           return global::Niec.iCommonSpace.KillPro.FastKill(target, Sims3.NiecHelp.Tasks.KillTask.GetDeathType(target), target, true, false);
                        }
                    }
                    catch (Exception)
                    {}
                   */
                    return //actor.IsSelectable;
                        UnsafeRunReapSoul(actor);
                }
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
                    catch (Exception)
                    { return InteractionTestResult.GenericFail; }

                }
            }

            public static readonly InteractionDefinition Singleton = new Definition();

           
            public NiecHelperSituation mSituation;
            public virtual bool OnQueueStomp() // test aweCore
            {
                if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.GetCurrentGameObject<Sim>() != null)
                    return Run();
                return false;
            }

            public override void PostureTransitionFailed(bool transitionExitResult)
            {
                if (___bOpenDGSIsInstalled_)
                    base.PostureTransitionFailed(transitionExitResult);
                else if (Actor != null && Actor.ObjectId == Simulator.CurrentTask)
                    NFinalizeDeath._RunInteraction(this);
            }
            //public override bool Test()
            //{
            //    if (___bOpenDGSIsInstalled_)
            //        return base.Test();
            //
            //    else if (Actor != null && Actor.ObjectId == Simulator.CurrentTask)
            //        return NFinalizeDeath._RunInteraction(this);
            //
            //    else return true;
            //}








            public override Lot GetTargetLot()
            {
                if (!___bOpenDGSIsInstalled_ && Simulator.CheckYieldingContext(false) && NFinalizeDeath.GetCurrentGameObjectFast<Sim>() != null)
                {
                    var p = NStackTrace.IsCallingMyMethedLite("CountBabiesToddlersAndCaregivers", true, 3);
                    try
                    {
                        NFinalizeDeath.CheckACoreThrowNRaasErrorTrap();
                    }
                    catch (NMAntiSpyException)
                    {
                        if (Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                            Actor.mInteractionQueue.mCurrentTransitionInteraction = null;
                        NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate
                        {
                            var t = NFinalizeDeath._GetCHeadInteraction(Actor);
                            if (t != null && NFinalizeDeath.InteractionIsNiecHelperSituation(t))
                                NFinalizeDeath._RunInteraction(t);
                        });
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }

                    if (Actor.mInteractionQueue != null && Actor.mInteractionQueue.mInteractionList != null)
                        niec_std.list_remove(Actor.mInteractionQueue.mInteractionList, this);

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(0);

                    try
                    {
                        if (__acorewIsnstalled__)
                        {
                            NiecTask.CreateWaitPerformWithExecuteType(NFinalizeDeath.GetCurrentExecuteType(), delegate
                            {
                                NFinalizeDeath._RunInteraction(this);
                            }).WaitingCanThrow();
                        }
                        else
                        {
                            NFinalizeDeath._RunInteraction(this);
                        }
                    }
                    catch (StackOverflowException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        NFinalizeDeath.ThrowResetException(null);
                        throw;
                    }
                    catch (ResetException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }
                    catch
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        if (!Simulator.CheckYieldingContext(false))
                            NFinalizeDeath.ThrowResetException(null);

                        throw;
                    }
                }
                return base.GetTargetLot();
            }

            public override Vector3 GetTargetPosition()
            {
                if (!___bOpenDGSIsInstalled_ && Simulator.CheckYieldingContext(false) && NFinalizeDeath.GetCurrentGameObjectFast<Sim>() != null)
                {
                    var p = NStackTrace.IsCallingMyMethedLite("CountBabiesToddlersAndCaregivers", true, 3);
                    try
                    {
                        NFinalizeDeath.CheckACoreThrowNRaasErrorTrap();
                    }
                    catch (NMAntiSpyException)
                    {
                        if (Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                            Actor.mInteractionQueue.mCurrentTransitionInteraction = null;
                        NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate
                        {
                            var t = NFinalizeDeath._GetCHeadInteraction(Actor);
                            if (t != null && NFinalizeDeath.InteractionIsNiecHelperSituation(t))
                                NFinalizeDeath._RunInteraction(t);
                        });
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }

                    if (Actor.mInteractionQueue != null && Actor.mInteractionQueue.mInteractionList != null)
                        niec_std.list_remove(Actor.mInteractionQueue.mInteractionList, this);

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(0);

                    try
                    {
                        if (__acorewIsnstalled__)
                        {
                            NiecTask.CreateWaitPerformWithExecuteType(NFinalizeDeath.GetCurrentExecuteType(), delegate
                            {
                                NFinalizeDeath._RunInteraction(this);
                            }).WaitingCanThrow();
                        }
                        else
                        {
                            NFinalizeDeath._RunInteraction(this);
                        }
                    }
                    catch (StackOverflowException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        NFinalizeDeath.ThrowResetException(null);
                        throw;
                    }
                    catch (ResetException)
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();
                        throw;
                    }
                    catch
                    {
                        if (p)
                            NFinalizeDeath.SafeForceTerminateRuntime();

                        if (!Simulator.CheckYieldingContext(false))
                            NFinalizeDeath.ThrowResetException(null);

                        throw;
                    }
                }
                return base.GetTargetPosition();
            }

            public int IsSocialTargetNHSIntX()
            {
                int ii = 0;
                var target = Target;
                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (item == null || item == target)
                        continue;
                    var iq = item.mInteractionQueue;
                    if (iq != null && iq.mInteractionList != null)
                    {
                        var i = iq.GetHeadInteraction() as SocialInteractionB;
                        if (i != null)
                        {
                            var iInteractionObjectPair = i.InteractionObjectPair;
                            if (iInteractionObjectPair != null
                                && iInteractionObjectPair.mInteraction is NiecMod.KillNiec.KillSimNiecX.NiecDefinitionDeathInteraction)
                            {
                                if (iInteractionObjectPair.mTarget == target)
                                {
                                    ii++;
                                }
                            }
                        }
                    }
                }
                return ii;
            }
            public bool rDoneSetObjectToReset = false; // Safe
            public bool rSetObjectToReset()
            {
                if (!Simulator.CheckYieldingContext(false))
                {
#if DEBUG
                    NiecException.PrintMessagePro
                        ("NiecAppear\nrSetObjectToReset failed\nName: " + Actor.Name, false, 100);
#endif
                    return false;
                }

                NiecException.PrintMessagePro
                    ("NiecAppear\nrSetObjectToReset Called\nName: " + Actor.Name, false, 100);

                NiecTask.Perform(delegate
                {
                    if (rDoneSetObjectToReset)
                        return;
                    if (___bOpenDGSIsInstalled_ && IsSocialTargetNHSIntX() > 1) // 2 sims
                    {
                        NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                    }
                    Actor.SetObjectToReset();
                });

                rDoneSetObjectToReset = false;

                try
                {
                    Simulator.Sleep(uint.MaxValue);
                }
                catch (ResetException)
                {
                    rDoneSetObjectToReset = true;
                    throw;
                }

                return true;
            }



            public override void ConfigureInteraction()
            {
                onRuntimeThisRun = false;
                if (!___bOpenDGSIsInstalled_)
                {
                    if (niec_std.array_indexof(RuningDeadSimList._items, Target) == -1)
                        RuningDeadSimList.Add(Target);

                    //if (!RuningDeadSimList.Contains(Target))
                    //    RuningDeadSimList.Add(Target);


                    try
                    {
                        if (mSituation == null)
                        {
                            mSituation = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Actor);
                        }
                        try
                        {
                            Actor.AddExitReason(ExitReason.Default | ExitReason.Finished | ExitReason.HigherPriorityNext | ExitReason.CanceledByScript);
                            if (!bShouldOnSavingGame && Actor.Autonomy != null && Actor.Autonomy.Motives != null)
                                //Actor.Autonomy.Motives.MaxEverything();
                                NFinalizeDeath.Sim_MaxMood(Actor);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch { }

                        //mSituation.OkSuusse = true;
                        //mSituation.OkSuusseDD = true;

                        try
                        {
                            if (Actor.mInteractionQueue != null && Actor.mInteractionQueue.mInteractionList != null)
                            {
                                foreach (InteractionInstance interactionInstance in Actor.mInteractionQueue.mInteractionList.ToArray()) // Cant Cancel Fix
                                {
                                    interactionInstance.mbOnStopCalled = true;
                                    interactionInstance.CancellableByPlayer = true;
                                    interactionInstance.mMustRun = false;
                                    interactionInstance.mHidden = false;
                                }
                            }
                        }
                        catch (ResetException)
                        { throw; }
                        catch (Exception)
                        { }

                        try
                        {
                            if (NFinalizeDeath.ActorIsQueueNHS(Actor))
                            {
                                Actor.AddExitReason(ExitReason.Default);
                            }
                            CancellableByPlayer = true;
                        }
                        catch (ResetException)
                        { throw; }
                        catch (Exception)
                        { }

                        SetPriority((InteractionPriorityLevel)12, 2f);
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    { }
                }
            }





            public bool Sitoaito()
            {

                try
                {
                    NiecHelperSituation niecHelperSituation = Actor.GetSituationOfType<NiecHelperSituation>();

                    if (niecHelperSituation.SMCDeath != null)
                        niecHelperSituation.SMCDeath.Dispose();
                    niecHelperSituation.SMCDeath = null;

                    if (niecHelperSituation.ReaperLoop != null)
                        niecHelperSituation.ReaperLoop.Dispose();
                    niecHelperSituation.ReaperLoop = null;

                    niecHelperSituation.LastSimOfHousehold = null;
                    niecHelperSituation.LastGraveCreated = null;
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { }

                if (!TestDivingPool && Actor.LotCurrent != null && Actor.LotCurrent.IsDivingLot)
                    mSituation.AddRelationshipWithEverySimInHousehold();

                Actor.SetOpacity(0f, 0f);
                Actor.SetPosition(mSituation.Lot.Position);

                if (!TestDivingPool && Actor.LotCurrent != null && Actor.LotCurrent.IsDivingLot)
                {
                    try
                    {
                        Actor.RequestWalkStyle(Sim.WalkStyle.ScubaDive);
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    { if (___bOpenDGSIsInstalled_) throw; NFinalizeDeath.CheckYieldingContext(); }
                

                }
                SimDescription.DeathType deathType = SimDescription.DeathType.ScubaDrown;
                Vector3 position = Vector3.Invalid;
                Vector3 invalid = Vector3.Invalid;

                Sim sim = Target; //mSituation.FindClosestDeadDivingSim();
                if (sim != null)
                {
                    if (sim.SimDescription == null)
                    {
                        if (__acorewIsnstalled__)
                        {
                            Target.mSimDescription = NiecMod.Helpers.Create.NiecNullSimDescription();
                            Target.mSimDescription.mSim = Target;
                        }
                        else return false;
                    }
                    if (sim.SimDescription.DeathStyle == SimDescription.DeathType.None)
                    {
                        deathType = SimDescription.DeathType.ScubaDrown;
                    }
                    else
                    {
                        deathType = sim.SimDescription.DeathStyle;
                    }
                     
                    //deathType = SimDescription.DeathType.Shark;
                    position = sim.Position;
                    if (Actor.LotCurrent != null && Actor.LotCurrent.IsDivingLot)
                    position.y = World.GetLevelHeight(position.x, position.z, 0);

                    Vector3 forward = sim.ForwardVector;
                    if (mSituation.mScubaDeathJig == null)
                    {
                        mSituation.mScubaDeathJig = (GlobalFunctions.CreateObjectOutOfWorld("UnderwaterSocial_Jig", ProductVersion.EP10) as SocialJig);
                        if (Actor.LotCurrent != null && Actor.LotCurrent.IsDivingLot)
                            position.y = World.GetLevelHeight(position.x, position.z, 0);
                        else position.y = ScriptCore.World.World_GetTerrainHeightImpl(position.x, position.z, true);
                        if (GlobalFunctions.FindGoodLocationNearby(mSituation.mScubaDeathJig, new ObjectGuid[2]
						{
							sim.ObjectId,
							Actor.ObjectId
						}, ref position, ref forward, 0f, GlobalFunctions.FindGoodLocationStrategies.All, FindGoodLocationBooleans.AllowOnSlopes | FindGoodLocationBooleans.AllowInSea))
                        {
                            mSituation.mScubaDeathJig.SetPosition(position);
                            mSituation.mScubaDeathJig.SetForward(forward);
                            Actor.SetPosition(mSituation.mScubaDeathJig.GetPositionOfSlot(SocialJigTwoPerson.RoutingSlots.SimA));
                            Actor.SetForward(mSituation.mScubaDeathJig.GetForwardOfSlot(SocialJigTwoPerson.RoutingSlots.SimA));
                        }
                        else {
                            Actor.SetPosition(Target.Position);
                            Actor.SetForward(Target.ForwardVector);
                        }
                    }
                }
                try
                {
                    if (!TestDivingPool && Actor.LotCurrent != null && Actor.LotCurrent.IsDivingLot)
                        Actor.GreetSimOnLot(Actor.LotCurrent);
                }
                catch (ResetException)
                { throw; }
                catch (Exception)
                {}

                NFinalizeDeath.CheckYieldingContext();

                mSituation.SMCDeath = NFinalizeDeath.StateMachineClient_Acquire(Actor, "DeathSequenceScuba");
                if (mSituation.SMCDeath == null)
                {
                    niec_std.assert("NFinalizeDeath.StateMachineClient_Acquire(Actor, \"DeathSequenceScuba\") failed.");
                    return false;
                }
                if (___bOpenDGSIsInstalled_)
                {
                    mSituation.SMCDeath.SetActor("x", Actor);
                    if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor))
                    {
                        mSituation.SMCDeath.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                        mSituation.SMCDeath.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                    }
                    mSituation.SMCDeath.EnterState("x", "Enter");
                }
                else
                {
                    NFinalizeDeath.StateMachineClient_SetActor(mSituation.SMCDeath, "x", Actor);
                    if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor) || NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(Actor))
                    {
                        mSituation.SMCDeath.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                        mSituation.SMCDeath.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);
                    }
                    mSituation.SMCDeath.EnterState("x", "Enter");
                }


                if (mSituation.Worker == null)
                {
                    if (!___bOpenDGSIsInstalled_)
                    {

                        if (Actor == null)
                        {
                            NFinalizeDeath.CheckYieldingContext();
                            Actor = NFinalizeDeath.GetCurrentGameObject<Sim>();
                            if (Actor == null)
                            {
                                throw new NullReferenceException("Fatel AweCore: Actor == null");
                            }
                        }

                        mSituation.Worker = Actor;

                        var spawn = mSituation.Child as Spawn;
                        if (spawn == null)
                        {
                            mSituation.SetState(new Spawn(mSituation));
                        }
                        else
                        {
                            spawn.ReCreateTick(Actor);
                        }
                        if (mSituation.Child as Spawn == null)
                        {
                            throw new NullReferenceException("Fatel AweCore Error: mSituation.Child as Spawn == null");
                        } 
                        if (mSituation.Worker == null)
                            throw new NullReferenceException("Fatel AweCore: Situation.Worker == null");
                    }
                    else
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        throw new NullReferenceException("Fatel Error: Situation.Worker == null");
                    }
                }
                if (mSituation.Worker.LotCurrent != null)
                    Urnstone.FogEffectTurnAllOn(mSituation.Worker.LotCurrent);

                /*
                try
                {
                    mDeathEffect = Urnstone.ReaperApperEffect(Actor, deathType);
                }
                catch (Exception)
                { }
                */

                if (ShouldDoDeathEvent(sim))
                {
                    Audio.StartSound("sting_death");
                    //Camera.FocusOnSim(Actor);
                }

                if (mSituation.SMCDeath == null)
                {
                    niec_std.assert("mSituation.SMCDeath failed.");
                    return false;
                }

                mSituation.SMCDeath.AddOneShotScriptEventHandler(103u, FadeInReaper);

                NFinalizeDeath.CheckYieldingContext();
                if (___bOpenDGSIsInstalled_)
                {
                    if (!NFinalizeDeath.SMCIsGood("x", mSituation.SMCDeath))
                        return rSetObjectToReset();
                }
                else if (__acorewIsnstalled__)
                {
                    if (NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask)
                    {
                        NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, mSituation.SMCDeath);
                        NFinalizeDeath.SMCIsValid("x", true, mSituation.SMCDeath);
                    }
                }

                NFinalizeDeath.UnSafeAwCoreSMCHEATask(mSituation.SMCDeath);
                mSituation.SMCDeath.RequestState("x", "DiveDown");
                 
                try
                {
                    if (mDeathEffect != null)
                    {
                        mDeathEffect.Stop();
                        mDeathEffect.Dispose();
                    }
                }
                catch                                                                                                                                           (Exception)
                { }
                
                mSituation.ReaperLoop = new ObjectSound(Actor.ObjectId, "death_reaper_lp");
                mSituation.ReaperLoop.Start(true);

                if (!___bOpenDGSIsInstalled_ && Target.InteractionQueue  != null && (Target.Household == null || Target.Household != Household.ActiveHousehold))
                {
                    try
                    {
                        if (Target.InteractionQueue.HasInteractionOfType(typeof(Sim.GoToVirtualHome)) || Target.InteractionQueue.HasInteractionOfType(typeof(Sim.GoToVirtualHome.GoToVirtualHomeInternal))) 
                        {
                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                            try
                            {
                                Target.DoReset(new Sims3.Gameplay.Abstracts.GameObject.ResetInformation());
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }
                            Target.InteractionQueue.Add(NinecReaper.Singleton.CreateInstance(Target, Target, base.GetPriority(), base.Autonomous, base.CancellableByPlayer));
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    { }
                }
                //if (Target != Actor)
                { 
                    ReapSoul goToLoAtx;
                    if (___bOpenDGSIsInstalled_)
                    {
                        goToLoAtx = ReapSoul.Singleton.CreateInstance(Target, Actor, base.GetPriority(), base.Autonomous, base.CancellableByPlayer) as ReapSoul;
                    }
                    else goToLoAtx = CreateInstance_internalX<ReapSoul>(ReapSoul.Singleton, Target, Actor, GetPriority(), Autonomous, CancellableByPlayer) as ReapSoul;
                    //goToLoAtx.RunInteraction();
                   return NFinalizeDeath._RunInteraction(goToLoAtx);
                }
                //return true;
            }

            public VisualEffect mDeathEffect;


           

            public void FadeInReaper(StateMachineClient sender, IEvent evt)
            {
                if (mDeathEffect != null)
                {
                    mDeathEffect.Start();
                }
                if (!TestDivingPool && Actor.LotCurrent != null && Actor.LotCurrent.IsDivingLot)
                {
                    if (mSituation != null)
                    {
                        mSituation.StartGrimReaperSmoke();
                    }
                }
                Actor.FadeIn(false, 3f);
            }

            public bool DoneRun = false;

            public static void placeGraveStone(Sim Actor, Sim Target, Urnstone mGrave)
            {
                mGrave.SetOpacity(0f, 0f);
                if (mGrave.LotCurrent.IsWorldLot)
                {
                    SimDescription.DeathType deathStyle = Target.SimDescription.DeathStyle;
                    World.FindGoodLocationParams fglParams = (deathStyle == SimDescription.DeathType.Drown) ? new World.FindGoodLocationParams(Actor.Position) : new World.FindGoodLocationParams(Target.Position);
                    fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                    if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, fglParams, false))
                    {
                        fglParams.BooleanConstraints = FindGoodLocationBooleans.None;
                        if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, fglParams, false))
                        {
                            mGrave.SetPosition(Target.Position);
                        }
                    }
                }
                mGrave.OnHandToolMovement();
                mGrave.FadeIn(false, 10f);
                mGrave.FogEffectStart();
            }


            public static Vector3 getPositionForGhost(Sim ghost, GameObject grave) 
            { return getPositionForGhost(null, ghost, grave); }

            public static Vector3 getPositionForGhost(Sim Actor, Sim ghost, GameObject grave)
            {
                Vector3 pos;// = Vector3.Empty;
                try
                {
                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(Actor != null && grave.HasBeenDestroyed ? Actor.Position : grave.Position);
                    fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                    
                    Vector3 fwd;
                    if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                    {
                        SpeedTrap.Sleep(0);
                        fglParams.BooleanConstraints &= ~FindGoodLocationBooleans.StayInRoom;
                        if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                        {
                            SpeedTrap.Sleep(0);
                            fglParams.BooleanConstraints &= ~FindGoodLocationBooleans.Routable;
                            if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                            {
                                SpeedTrap.Sleep(0);
                                fglParams.BooleanConstraints = FindGoodLocationBooleans.None;
                                if (!GlobalFunctions.FindGoodLocation(ghost, fglParams, out pos, out fwd))
                                {
                                    return ghost.Position;
                                }
                            }
                        }
                    }
                    return pos;
                }
                catch (ResetException)
                { throw; }
                catch { }

                //return ghost != null ? ghost.Position : Vector3.Invalid;
                return Vector3.OutOfWorld;
            }

            public bool onRuntimeThisRun = true;

            public override void Cleanup()
            {
               
                if (!___bOpenDGSIsInstalled_ && Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                {
                    try
                    {
                        NFinalizeDeath.CheckACoreThrowNRaasErrorTrap();
                    }
                    catch (NMAntiSpyException)
                    {
                        if (Actor != null && Actor.mInteractionQueue != null && Actor.mInteractionQueue.mCurrentTransitionInteraction == this)
                            Actor.mInteractionQueue.mCurrentTransitionInteraction = null;
                        NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate
                        {
                            var t = NFinalizeDeath._GetCHeadInteraction(Actor) as NiecAppear ?? this;
                            if (t != null)// && NFinalizeDeath.InteractionIsNiecHelperSituation(t))
                                NFinalizeDeath._RunInteraction(t);
                        });
                        throw;
                    }

                }
                if (!onRuntimeThisRun && Actor != null && InteractionObjectPair != null && Target != null)
                {
                    onRuntimeThisRun = true;
                    if (NFinalizeDeath.OnCancelTryRunInteraction(Actor, this))
                        return;
                }
                if (!DoneRun && !AssemblyCheckByNiec.IsInstalled("OpenDGS") && Actor != null && InteractionObjectPair != null && Target != null && Actor != Target && !NFinalizeDeath.IsAllActiveHousehold_SimObject(Target))
                {
                    //mSituation.OkSuusse = false;
                    //mSituation.OkSuusseD = false;
                    //mSituation.OkSuusseDD = false;
                    try
                    {

                        try
                        {
                            if (Target.Inventory != null)
                                //Target.MoveInventoryItemsToSim(NFinalizeDeath.ActiveActor ?? PlumbBob.SelectedActor  ?? Actor);
                                NFinalizeDeath._MoveInventoryItemsToAFamilyMember(Target, NFinalizeDeath.ActiveActor ?? PlumbBob.SelectedActor ?? Actor);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch
                        { }
                        SimDescription simd = Target.SimDescription;

                        if (simd == null)
                        {
                            //base.Cleanup(); Get error
                            goto end;
                        }
                        Urnstone RIPObject = null;
                        RIPObject = HelperNra.TFindGhostsGrave(simd);
                        if (RIPObject == null)
                            NFinalizeDeath.GetKillNPCSimToGhost(Target, simd.DeathStyle, getPositionForGhost(Target, Actor), out RIPObject);
                        if (RIPObject == null)
                            RIPObject = Urnstone.CreateGrave(simd, false, true);
                        safePosRIPObject(Actor, Target, RIPObject);
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }
                    
                }
                end:
                if (DoneRun && !AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    niec_std.list_remove(RuningDeadSimList, Target); //RuningDeadSimList.Remove(Target);
                //base.Cleanup();
            }

            public void checkACoreThrowNRaasErrorTrap()
            {
                try
                {
                    if (NFinalizeDeath.NoThrowCheckACoreThrowNRaasErrorTrap(1))
                    {
                        if (NFinalizeDeath._AntiSpy_ThrowDefault01 == null)
                        {
                            NFinalizeDeath._AntiSpy_ThrowDefault01 = new NMAntiSpyException("") { No_EA_Collect_Exception_ToString = true, ta = true };
                        }
                        throw NFinalizeDeath._AntiSpy_ThrowDefault01;
                    }
                }
                catch (NMAntiSpyException)
                {
                    //if (NFinalizeDeath.MsCorlibIsMod())
                    //{
                    //    var sysEx = new SystemException();
                    //    sysEx.message = "checkACoreThrowNRaasErrorTrap() Found";
                    //    sysEx.trace_ips = e.trace_ips;
                    //    if ( NFinalizeDeath.IsNullOrEmpty  (sysEx.ToString()) ) {
                    //        sysEx.stack_trace = NFinalizeDeath.GetStackTraceToString(new System.Diagnostics.StackTrace(sysEx, false), true);
                    //    }
                    //}
                    //
                    //// NiecModException
                    //e.class_name = null;
                    //e.stack_trace = null;
                    //e.trace_ips = null;
                    //e.inner_exception = null;
                    //e.source = null;
                    //e.ta = true;
                    onRuntimeThisRun = true;
                    NiecTask.Perform(NFinalizeDeath.GetCurrentExecuteType(), delegate { NFinalizeDeath._RunInteraction(this); });

                    try
                    {
                        throw;
                    }
                    catch (ExecutionEngineException ex)
                    {
                        ex.message = "Should not throw?";
                        NFinalizeDeath.AntiSpy_ThrowDefault();
                    }
                    throw new ExecutionEngineException("Should not throw? ( Bug NF.AntiSpy_ThrowDefault() )");
                }
            }

            public override bool Run()
            {
                if (!___bOpenDGSIsInstalled_)
                    checkACoreThrowNRaasErrorTrap();

                onRuntimeThisRun = true;

                //NFinalizeDeath.RemoveAllSimNiecNullForGrave();

                if (!NFinalizeDeath.GameObjectIsValid(Actor.ObjectId.mValue))
                {
                    if (__acorewIsnstalled__)
                        NFinalizeDeath.ThrowResetException(null);
                    return false;
                }

                Actor.ClearExitReasons();

                NiecHelperSituation niecHelperSituation = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Actor);
                if (niecHelperSituation != null)
                {
                    if (niecHelperSituation.OkSuusse)
                    {
                        ReapSoul goToLoAtx = null;
                        if (___bOpenDGSIsInstalled_)
                        {
                            goToLoAtx =
                                ReapSoul.Singleton.CreateInstance(Target, Actor, base.GetPriority(), base.Autonomous, base.CancellableByPlayer) as ReapSoul;
                        }
                        else 
                            goToLoAtx = CreateInstance_internalX<ReapSoul>(ReapSoul.Singleton, Target, Actor, GetPriority(), Autonomous, CancellableByPlayer) as ReapSoul;

                        if (goToLoAtx == null)
                        {
                            throw new NullReferenceException("goToLoAtx: CreateInstance as ReapSoul Failed");
                        }
                        return NFinalizeDeath._RunInteraction(goToLoAtx);
                    }
                }
                try
                {
                    if (niecHelperSituation != null  && UnsafeRunReapSoul(Actor))
                    {
                        //bool bRunSB = false;
                        if (!___bOpenDGSIsInstalled_ && NFinalizeDeath.Random_GetFloat(0, 100, null) < 45)
                        {
                            OnLoadingDialogDispose();
                        }

                        if (IsUnSafeUsingListSim())
                        {
                            NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                            NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Target);
                        }

                        mSituation = niecHelperSituation;
                        niecHelperSituation.Worker = Actor;
                        NiecHelperSituation.Spawn nhsSp = niecHelperSituation.Child as NiecHelperSituation.Spawn;
                        if (nhsSp != null)
                        {
                            nhsSp.ReCreateTick(Actor);
                        }

                        SimDescription TargetSimDesc = Target.SimDescription;
                        if (TargetSimDesc == null)
                        {
                            if (___bOpenDGSIsInstalled_)
                            {
                                return false;
                            }
                            else
                                NFinalizeDeath.UnSafe_OrgToNull_SimDesc(Target);
                        }
                        Lot ActorLot = Actor.LotCurrent;
                        Lot TargetLot = Target.LotCurrent;

                        //if (!niecHelperSituation.OkSuusseDD)
                            niecHelperSituation.OkSuusse = true;


                        if (TestDivingPool || ActorLot != null && ActorLot.IsDivingLot || TargetLot != null && TargetLot.IsDivingLot && Target.Posture != null && Target.Posture is ScubaDiving && TargetSimDesc != null && !TargetSimDesc.IsMermaid)
                        {
                            niecHelperSituation.OkSuusseD = true;
                            return Sitoaito();
                        }
                        else
                        {
                            niecHelperSituation.OkSuusseD = false;
                        }
                        /*
                        if (!___bOpenDGSIsInstalled_)
                        {
                            try
                            {
                                niecHelperSituation.AddRelationshipWithEverySimInHousehold();

                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch (Exception)
                            {}
                        }*/

                       
                        bool otFindGoodLocation = false;
                        SimDescription.DeathType deathType = SimDescription.DeathType.Drown;
                        Sim sim = Target; //niecHelperSituation.FindClosestDeadSim();
                        if (sim != null)
                        {
                            if (!SafePos2020() || NFinalizeDeath.Random_Chance(45))
                            {
                                Vector3 pos = Vector3.Invalid;
                                World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(sim.Position);
                                Vector3 fwd;
                                if (!GlobalFunctions.FindGoodLocation(Actor, fglParams, out pos, out fwd)) {
                                    pos = fglParams.StartPosition;
                                }
                                Actor.SetPosition(pos);
                                otFindGoodLocation = true;
                                //bRunSB = false;
                            }
                            //else bRunSB = true;

                            try
                            {
                                //if (Actor.RoutingComponent != null)
                                //    Actor.RouteTurnToFace(sim.Position);
                                if (!___bOpenDGSIsInstalled_)
                                { 
                                    NiecTask.Perform(ScriptExecuteType.Threaded, delegate {
                                        if (Actor.RoutingComponent == null) return;
                                        NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, sim.Position, 0uL, 0uL);
                                        while (NFinalizeDeath._GetCHeadInteraction(Actor) == this)
                                        {
                                            Simulator.Sleep(15);
                                            if (Actor.RoutingComponent == null || Simulator.GetProxy(sim.ObjectId) == null) 
                                                break;
                                            NFinalizeDeath.RouteTurnToFace(Actor.RoutingComponent, sim.Position, 0uL, 0uL);
                                        }
                                    });

                                    NFinalizeDeath.CheckYieldingContext();
                                    Simulator.Sleep(45); 
                                }
                                else //if (Actor.RoutingComponent != null)
                                {
                                    //Actor.RouteTurnToFace(sim.Position);
                                    Actor.SetForward(NFinalizeDeath.MathU_FaceToPos(Actor.Position, sim.Position));
                                    Simulator.Sleep(5);
                                }
                            }
                            catch (ResetException)
                            { throw; }
                            catch { }
                            SimDescription simDesc = sim.mSimDescription;
                            if (simDesc != null)
                            {
                                if (simDesc.DeathStyle == SimDescription.DeathType.None)
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
                                    if (!simDesc.IsFrankenstein)
                                    {
                                        list.Add(SimDescription.DeathType.Electrocution);
                                    }
                                    list.Add(SimDescription.DeathType.Burn);
                                    if (simDesc.Elder)
                                    {
                                        list.Add(SimDescription.DeathType.OldAge);
                                    }
                                    if (simDesc.IsWitch)
                                    {
                                        list.Add(SimDescription.DeathType.HauntingCurse);
                                    }
                                    SimDescription.DeathType randomObjectFromList = RandomUtil.GetRandomObjectFromList(list, ListCollon.SafeRandomPart2);
                                    //Target.SimDescription.SetDeathStyle(randomObjectFromList, Target.IsSelectable);
                                    deathType = randomObjectFromList;
                                }
                                else
                                {
                                    deathType = simDesc.DeathStyle;
                                }
                            }
                        }

                        if (!otFindGoodLocation) {
                            if (TargetLot != null)
                                Actor.SetPosition(TargetLot.Position);//(niecHelperSituation.Lot.Position);
                            else
                                Actor.SetPosition(Target.Position);
                        }

                        try
                        {
                            if (niecHelperSituation.Worker == null)
                                niecHelperSituation.Worker = Actor;
                            
                            if (niecHelperSituation.SMCDeath != null)
                                niecHelperSituation.SMCDeath.Dispose();
                            niecHelperSituation.SMCDeath = null;

                            if (niecHelperSituation.ReaperLoop != null)
                                niecHelperSituation.ReaperLoop.Dispose();
                            niecHelperSituation.ReaperLoop = null;

                            niecHelperSituation.LastSimOfHousehold = null;
                            niecHelperSituation.LastGraveCreated = null;

                            Actor.GreetSimOnLot(niecHelperSituation.Worker.LotCurrent);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch
                        { }

                        NFinalizeDeath.CheckYieldingContext();


                        niecHelperSituation.SMCDeath = NFinalizeDeath.StateMachineClient_Acquire(Actor, "DeathSequence");
                        if (___bOpenDGSIsInstalled_)
                            niecHelperSituation.SMCDeath.SetActor("x", Actor);
                        else 
                            NFinalizeDeath.StateMachineClient_SetActor(niecHelperSituation.SMCDeath, "x", Actor);
                        if (niecHelperSituation.SMCDeath == null)
                        {
                            NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });
                        }
                        if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor))
                        {
                            niecHelperSituation.SMCDeath.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                        }

                        if (NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(Actor))
                            niecHelperSituation.SMCDeath.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);

                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(niecHelperSituation.SMCDeath);
                        niecHelperSituation.SMCDeath.EnterState("x", "Enter");
                        
                        //Urnstone.FogEffectTurnAllOn(niecHelperSituation.Worker.LotCurrent);

                        /*
                        if (deathType == SimDescription.DeathType.None)
                        {
                        }
                         * */

                        //VisualEffect visualEffect = Urnstone.ReaperApperEffect(Actor, deathType);
                        //visualEffect.Start();

                        

                        if (!___bOpenDGSIsInstalled_ && NFinalizeDeath.SimIsGRReaper(Actor.SimDescription))
                            niecHelperSituation.StartGrimReaperSmoke();

                        //VisualEffect.FireOneShotEffect("reaperSmokeConstant", Actor, Sim.FXJoints.Pelvis, VisualEffect.TransitionType.HardTransition);

                        if (ShouldDoDeathEvent(sim))
                        {
                            Audio.StartSound("sting_death");
                        }

                        niecHelperSituation.SMCDeath.AddOneShotScriptEventHandler(666u, EventCallbackFadeInReaper);
                        NFinalizeDeath.CheckYieldingContext();
                        NFinalizeDeath.UnSafeAwCoreSMCHEATask(niecHelperSituation.SMCDeath);
                        if (niecHelperSituation.SMCDeath == null)
                        {
                            NFinalizeDeath.ThrowOtherException(new NiecModException("fUnSafe_FakeThrowRunInteraction") { No_EA_Collect_Exception_ToString = true });
                        }
                        if (___bOpenDGSIsInstalled_)//&&!NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", mSMCDeath)) //mSMCDeath.mHandleEventsAsynchronously)
                        {
                            if (!NFinalizeDeath.SMCIsGood("x", niecHelperSituation.SMCDeath))
                                return rSetObjectToReset();
                        }
                        else if (__acorewIsnstalled__)
                        {
                            if (NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask)
                            {
                                NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, niecHelperSituation.SMCDeath);
                                NFinalizeDeath.SMCIsValid("x", true, niecHelperSituation.SMCDeath);
                            }
                        }
                        niecHelperSituation.SMCDeath.RequestState("x", "ReaperBrushingHimself");
                        /*
                        if (!Target.IsInActiveHousehold)
                        {
                            Simulator.Sleep(0);
                            Actor.PlaySoloAnimation("a_ghost_land_x", true);
                            foreach (var sigm in Actor.LotCurrent.GetAllActors())
                           // while (true)
                            {
                                if (sigm != null && sigm.SimDescription != null && sigm.SimDescription.DeathStyle != SimDescription.DeathType.None && !sigm.SimDescription.IsGhost)
                               
                                //if (sigm != null)
                                {
                                    TestFastFinalizeDeathNPC(Actor, sigm, niecHelperSituation);
                                }
                                else return true;
                            }
                        }
                         */

                        //visualEffect.Stop();

                        niecHelperSituation.ReaperLoop = new ObjectSound(Actor.ObjectId, "death_reaper_lp");
                        niecHelperSituation.ReaperLoop.Start(true);

                        DoneRun = true;

                        if (!___bOpenDGSIsInstalled_ && Target.InteractionQueue != null && (Target.Household == null || Target.Household != Household.ActiveHousehold))
                        {
                            try
                            {
                                if (Target.InteractionQueue.HasInteractionOfType(typeof(Sim.GoToVirtualHome)) || Target.InteractionQueue.HasInteractionOfType(typeof(Sim.GoToVirtualHome.GoToVirtualHomeInternal)))
                                {
                                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                                    Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                                    {
                                        try
                                        {
                                            Target.DoReset(new Sims3.Gameplay.Abstracts.GameObject.ResetInformation());
                                        }
                                        catch (ResetException)
                                        {
                                            throw;
                                        }
                                        catch
                                        { }
                                    });
                                    for (int i = 0; i < 40; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }
                                    Target.InteractionQueue.Add(NinecReaper.Singleton.CreateInstance(Target, Target, base.GetPriority(), base.Autonomous, base.CancellableByPlayer));
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            { }
                        }

                        //if (Target != Actor)
                        {
                            ReapSoul goToLoAtx = null;

                            if (___bOpenDGSIsInstalled_)
                                goToLoAtx = ReapSoul.Singleton.CreateInstance(Target, Actor, base.GetPriority(), base.Autonomous, base.CancellableByPlayer) as ReapSoul;
                            else 
                                goToLoAtx = CreateInstance_internalX<ReapSoul>(ReapSoul.Singleton, Target, Actor, GetPriority(), Autonomous, CancellableByPlayer) as ReapSoul;

                            if (goToLoAtx == null)
                            {
                                throw new NullReferenceException("goToLoAtx: CreateInstance as ReapSoul Failed");
                            }
                            Actor.Posture = new SimCarryingObjectPosture(Actor, null);
                            //goToLoAtx.shuoldbRunSB = bRunSB;

                            return NFinalizeDeath._RunInteraction(goToLoAtx);
                        }
                        
                        //Actor.Posture = new SimCarryingObjectPosture(Actor, null);
                    }

                }
                catch (NMAntiSpyException)
                { NFinalizeDeath.SafeForceTerminateRuntime(); }
                catch (ResetException)
                {
                    if (mSituation != null)
                        mSituation.CleanUp__();
                    throw;
                }
                catch (Exception exception)
                {
                    
                    if (!___bOpenDGSIsInstalled_)
                    {
                        if (NiecHelperSituation.__acorewIsnstalled__)
                        {
                            if (Actor.mPosture != null && Actor.mPosture.PreviousPosture == Actor.mPosture)
                            {
                                Actor.mPosture.PreviousPosture = null;
                            }
                            Actor.mPosture = Actor.Standing;
                            if (Actor.mPosture != null && Actor.mPosture.PreviousPosture == Actor.Standing)
                            {
                                Actor.mPosture.PreviousPosture = null;
                            }
                            if (Actor.mPosture != null && Actor.mPosture.PreviousPosture == Actor.mPosture)
                            {
                                Actor.mPosture.PreviousPosture = null;
                            }
                            NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Actor);
                            NFinalizeDeath.UnSafe_RemoveActorsUsingMe(Target);
                        }
                        NFinalizeDeath.CheckYieldingContext();
                        SpeedTrap.Sleep(100);
                    }
                    //mSituation.StopGrimReaperSmoke();
                    //if (exception.Message != "fUnSafe_FakeThrowRunInteraction")
                    //    NiecException.PrintMessage("NHS " + exception.Message + NiecException.NewLine + exception.StackTrace);
                    //if (niecHelperSituation != null)
                    //{
                    //    niecHelperSituation.OkSuusseDD = false;
                    //    niecHelperSituation.OkSuusseD = false;
                    //    niecHelperSituation.OkSuusse = false;
                    //}

                    if (mSituation != null)
                    {
                        mSituation.CleanUp__();
                    }

                    NFinalizeDeath.CheckYieldingContext();

                    if (mSituation != null)
                    {
                        mSituation.StopGrimReaperSmoke();
                    }

                    if (!(exception is StackOverflowException) && exception.Message != "fUnSafe_FakeThrowRunInteraction")
                    {
                        if (___bOpenDGSIsInstalled_)
                        NiecException.PrintMessage("NHS " + exception.Message + NiecException.NewLine + exception.StackTrace);
                        else NiecException.PrintMessagePro("NHS " + exception.Message + NiecException.NewLine + exception.StackTrace, false, 100);
                    }

                    if (___bOpenDGSIsInstalled_)
                    {
                        Actor.ResetAllAnimation();
                    }
                    else
                    {
                        NFinalizeDeath.NResetAllAnimation(Actor);
                    }

                    NiecMod.Nra.SpeedTrap.Sleep();
                    AnimationUtil.StopAllAnimation(Actor);
                    NiecMod.Nra.SpeedTrap.Sleep();
                    Actor.SetObjectToReset();
                }
                
                return true;
            }






            public static void TestFastFinalizeDeathNPC(Sim Actor, Sim Target, NiecHelperSituation mSituation)
            {

                if (NFinalizeDeath.IsSimFastActiveHousehold(Target))
                {



                    Vector3 vector2;
                    Vector3 vector5 = Vector3.Invalid;

                    World.FindGoodLocationParams fglParams;

                    Mailbox mailboxOnHomeLot = Mailbox.GetMailboxOnHomeLot(Target);

                    if (mailboxOnHomeLot != null)
                    {
                        fglParams = new World.FindGoodLocationParams(mailboxOnHomeLot.Position);
                        fglParams.BooleanConstraints |= FindGoodLocationBooleans.StayInRoom;
                        fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0x7);
                    }
                    else
                    {
                        fglParams = new World.FindGoodLocationParams(Target.LotHome.Position);
                        fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0x7);
                    }





                    if (!GlobalFunctions.FindGoodLocation(Target, fglParams, out vector5, out vector2))
                    {
                        vector5 = Target.LotHome.Position;
                    }




                    bool bResetAge = false;

                    if (Target.SimDescription.DeathStyle == SimDescription.DeathType.OldAge)
                    {
                        bResetAge = true;
                    }

                    Actor.ClearSynchronizationData();
                    Target.SimDescription.IsNeverSelectable = false;
                    Target.SimDescription.ShowSocialsOnSim = true;
                    Target.Autonomy.DecrementAutonomyDisabled();




                    SimDescription simDescription = Target.SimDescription;
                    Sim sim = Target;
                    simDescription.IsGhost = false;
                    World.ObjectSetGhostState(sim.ObjectId, 0u, (uint)simDescription.AgeGenderSpecies);
                    sim.Autonomy.Motives.RemoveMotive(CommodityKind.BeGhostly);
                    simDescription.SetDeathStyle(SimDescription.DeathType.None, false);
                    simDescription.ShowSocialsOnSim = true;
                    simDescription.IsNeverSelectable = false;
                    sim.Autonomy.AllowedToRunMetaAutonomy = true;

                    if (!sim.SimDescription.IsFrankenstein)
                    {
                        try
                        {
                            sim.UnrequestWalkStyle(Sim.WalkStyle.GhostWalk);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch
                        { if (___bOpenDGSIsInstalled_) throw; NFinalizeDeath.CheckYieldingContext(); }
                        
                    }
                    if (sim.DeathReactionBroadcast != null)
                    {
                        sim.DeathReactionBroadcast.Dispose();
                        sim.DeathReactionBroadcast = null;
                    }
                    if (!sim.SimDescription.IsEP11Bot)
                    {
                        simDescription.AgingEnabled = true;
                        if (bResetAge)
                        {
                            simDescription.AgingState.ResetAndExtendAgingStage(0f);
                        }
                    }



                    simDescription.PushAgingEnabledToAgingManager();
                    simDescription.Contactable = true;

                    if (sim.SimDescription.OccultManager != null)
                    {
                        OccultFairy occultFairy = sim.SimDescription.OccultManager.GetOccultType(Sims3.UI.Hud.OccultTypes.Fairy) as OccultFairy;
                        if (occultFairy != null)
                        {
                            occultFairy.GrantWings();
                        }
                    }

                    if (sim.SimDescription.SupernaturalData != null && sim.SimDescription.SupernaturalData.OccultType == Sims3.UI.Hud.OccultTypes.Ghost)
                    {
                        sim.SimDescription.RemoveSupernaturalData();
                    }

                    


                    try
                    {
                        Target.Motives.MaxEverything();
                    }
                    catch
                    { }
                    Target.Autonomy.DecrementAutonomyDisabled();
                    Target.SetPosition(vector5);

                    Target.FadeIn(Simulator.CheckYieldingContext(false), 3);
                    Target.AddExitReason(ExitReason.HigherPriorityNext);
                    Target.AddExitReason(ExitReason.CanceledByScript);
                    return;
                }
                Urnstone mGrave = null;
                SimDescription targetSimDesc = null;
                try
                {
                    targetSimDesc = Target.SimDescription;
                    if (targetSimDesc == null) return;
                    if (targetSimDesc.DeathStyle == SimDescription.DeathType.None && !Target.IsInActiveHousehold)
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
                        if (!targetSimDesc.IsFrankenstein)
                        {
                            list.Add(SimDescription.DeathType.Electrocution);
                        }
                        list.Add(SimDescription.DeathType.Burn);
                        if (targetSimDesc.Elder)
                        {
                            list.Add(SimDescription.DeathType.OldAge);
                        }
                        if (targetSimDesc.IsWitch)
                        {
                            list.Add(SimDescription.DeathType.HauntingCurse);
                        }
                        SimDescription.DeathType randomObjectFromList = RandomUtil.GetRandomObjectFromList(list, ListCollon.SafeRandomPart2);
                        targetSimDesc.SetDeathStyle(randomObjectFromList, Target.IsSelectable);
                    }
                }
                catch (Exception)
                { }
                try
                {
                    foreach (Urnstone mGravebackup in NFinalizeDeath.SC_GetObjects<Urnstone>())
                    {
                        if (mGravebackup != null && (mGravebackup.LotCurrent == null || mGravebackup.LotCurrent.IsWorldLot))
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
                                    loet = RandomUtil.GetRandomObjectFromList<Lot>(lieast, ListCollon.SafeRandomPart2);

                                    if (loet != null)
                                    {
                                        if (!GlobalFunctions.PlaceAtGoodLocation(mGravebackup, new World.FindGoodLocationParams(loet.Position), false))
                                        {
                                            mGravebackup.SetPosition(loet.Position);
                                        }
                                    }
                                }
                                catch
                                { }
                            }
                        }
                    }
                }
                catch (Exception)
                { }
                try
                {
                    Urnstone atatyr = HelperNra.TFindGhostsGrave(targetSimDesc);
                    if (atatyr != null)
                        mGrave = atatyr;
                    else
                        mGrave = Urnstone.CreateGrave(targetSimDesc, true, true);
                    if (mGrave != null)
                    {
                        if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, new World.FindGoodLocationParams(Actor.Position), false))
                        {
                            mGrave.SetPosition(Actor.Position);
                        }
                        mGrave.OnHandToolMovement();
                        mGrave.FadeIn(false, 10f);
                    }
                    //MakeHouseholdHorsesGoHome();
                    if (targetSimDesc != null && targetSimDesc.BoardingSchool != null && targetSimDesc.IsEnrolledInBoardingSchool())
                    {
                        targetSimDesc.BoardingSchool.OnRemovedFromSchool();
                    }
                    if (___bOpenDGSIsInstalled_)
                    {
                        if (Target.Household != null)
                        {
                            Urnstone.FinalizeSimDeath(targetSimDesc, Target.Household, false);
                        }
                        else
                        {
                            Urnstone.FinalizeSimDeath(targetSimDesc, Household.NpcHousehold, false);
                        }
                    }
                    else
                    {
                        if (Target.Household != null)
                        {
                            FinalizeSimDeathPro(targetSimDesc, Target.Household, false);
                        }
                        else
                        {
                            FinalizeSimDeathPro(targetSimDesc, Household.NpcHousehold, false);
                        }
                    }
                    int minuteOfDeath = (int)Math.Floor((double)SimClock.ConvertFromTicks(SimClock.CurrentTime().Ticks, TimeUnit.Minutes)) % 60;
                    mGrave.MinuteOfDeath = minuteOfDeath;
                    if (Target.DeathReactionBroadcast != null)
                    {
                        Target.DeathReactionBroadcast.Dispose();
                        Target.DeathReactionBroadcast = null;
                    }
                    //Target.SetHiddenFlags(HiddenFlags.Everything);
                    Household household = Target.Household;
                    if (household != null)
                    {
                        // Moded Not If
                        /*
                        if (household.IsActive)
                        {
                            Target.MoveInventoryItemsToAFamilyMember();
                        }
                        */
                        NFinalizeDeath._MoveInventoryItemsToAFamilyMember(Target, NFinalizeDeath.ActiveActor);
                        Target.LotCurrent.LastDiedSim = Target.SimDescription;
                        Target.LotCurrent.NumDeathsOnLot++;
                        Actor.ClearSynchronizationData();
                       
                        /*
                        if (Target.SimDescription.DeathStyle != SimDescription.DeathType.OldAge)
                        {
                            Actor.RemoveInteractionByType(ChessChallenge.Singleton);
                        }
                         * */
                        if (BoardingSchool.ShouldSimsBeRemovedFromBoardingSchool(household))
                        {
                            BoardingSchool.RemoveAllSimsFromBoardingSchool(household);
                        }
                        if (!___bOpenDGSIsInstalled_)
                        {
                            if (!Target.BuffManager.HasElement(BuffNames.Ensorcelled))
                            {
                                int num = 0;
                                foreach (Sim allActor in household.AllActors)
                                {
                                    if (allActor.BuffManager.HasElement(BuffNames.Ensorcelled))
                                    {
                                        num++;
                                    }
                                }
                                if (household.AllActors.Count == num + 1)
                                {
                                    foreach (Sim allActor2 in household.AllActors)
                                    {
                                        if (allActor2.BuffManager.HasElement(BuffNames.Ensorcelled))
                                        {
                                            allActor2.BuffManager.RemoveElement(BuffNames.Ensorcelled);
                                        }
                                    }
                                }
                            }
                        }
                        int num2 = household.AllActors.Count - household.GetNumberOfRoommates();
                        if (household.IsActive && num2 == 1 && !Household.RoommateManager.IsNPCRoommate(Target))
                        {
                            mSituation.LastSimOfHousehold = Target;
                        }
                        else
                        {
                            if (Target.IsActiveSim)
                            {
                                LotManager.SelectNextSim();
                            }
                            household.RemoveSim(Target);
                        }
                    }
                    mGrave.RemoveFromUseList(Actor);
                    Ocean singleton = Ocean.Singleton;
                    if (singleton != null && singleton.IsActorUsingMe(Target))
                    {
                        singleton.RemoveFromUseList(Target);
                        Target.Posture = null;
                    }

                }
                catch
                { }
                try
                {
                        PetPoolType petPoolType = PetPoolType.None;
                        switch (targetSimDesc.Species)
                        {
                            case CASAgeGenderFlags.Dog:
                            case CASAgeGenderFlags.LittleDog:
                                petPoolType = PetPoolType.StrayDog;
                                break;
                            case CASAgeGenderFlags.Cat:
                                petPoolType = PetPoolType.StrayCat;
                                break;
                            case CASAgeGenderFlags.Horse:
                                petPoolType = ((!targetSimDesc.IsUnicorn) ? PetPoolType.WildHorse : PetPoolType.Unicorn);
                                break;
                        }
                    if (PetPoolManager.IsPetInPoolType(targetSimDesc, petPoolType))
                        PetPoolManager.RemovePet(petPoolType, targetSimDesc);                                                                               if (Target.Autonomy != null)
                    {
                        Target.Autonomy.DecrementAutonomyDisabled();
                    }
                }
                catch (Exception)
                {}
                try
                {
                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                    //Target.FadeOut(false, true, 1f);
                    Target.Destroy();
                    Simulator.Sleep(0);
                }
                catch (Exception)
                { }
            }










            public void EventCallbackFadeInReaper(StateMachineClient sender, IEvent evt)
            {
                Actor.FadeIn(false, 3f);
            }
        }

        // End Interaction







        














        ///// End

        // ChildSituation

        [Persistable]
        public class Spawn : ChildSituation<NiecHelperSituation>, IPersistPostLoad
        {
            private Spawn()
            {
            }

            public Spawn(NiecHelperSituation parent)
                : base(parent)
            { }
            // Static
            //public static uint iSleep = 0;

            internal static uint RunningWorkingNiecHelperSituation = 0;
            [PersistableStatic]
            public static bool DisableOnTick_OpenDGSOnly = false;
            [PersistableStatic]
            public static bool DisableOnTick = false;
            [PersistableStatic]
            public static bool _bUnSafeRunAll = false;

            public void _Dispose() {
                this.intat = null;
                if (this.mInteractions != null)
                    this.mInteractions.Clear();
                if (this.mForcedInteractions != null)
                    this.mForcedInteractions.Clear();
                CleanUp();
                ___Worker = null;
                base.Dispose();
            }

            public static bool UnSafeRunAll
            {
                get
                {
                    if (!IsOpenDGSInstalled) 
                        return true;
                    return _bUnSafeRunAll;
                }
                set { _bUnSafeRunAll = value; }
            }

            public static bool sIsGrimReaper = false;

            public static List<Sim> EmptySimList = new List<Sim>();

            private static bool IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");
            // End Static
            public static bool Disable_ReCreateTick = false;

            public uint iSleep = 0;

           // public bool asoiryodirow_Dispore = false;


            // (Deprecated): use if (NFinalizeDeath.TargetObjectIsRunningTask(this, true) > 0)

            //[Persistable(false)]
            //private bool _RunTick = false;
            //[Persistable(false)]
            //private bool _Wait_ReCreateTick = false;

            // end Deprecated


            public static Stack<Vector3> reRunLightning = new Stack<Vector3>();





            public void ReCreateTick(Sim setWorker) {
                bShouldOnSavingGame = false;
                if (Disable_ReCreateTick) return;
                if (setWorker != null)
                    ___Worker = setWorker;

                if (NFinalizeDeath.TargetObjectIsRunningTask(this, true) > 0)
                    return;

                if (!IsOpenDGSInstalled)
                {
                    iuSleepMax = (uint)ListCollon.SafeRandomPart2.Next(10, 27);
                    _StartOnTick();
                    return;
                }
                //if (_RunTick || _Wait_ReCreateTick) 
                //    return;

                var nhs = Parent;
                if (nhs != null && nhs.Child == this)
                {
                    var simWorker = nhs.Worker;
                    if (simWorker != null && Simulator.GetProxy(simWorker.ObjectId) != null)
                    {
                        try
                        {
                            simWorker.Autonomy.Motives.MaxEverything();
                        }
                        catch (ResetException) { throw; }
                        catch { }

                        //_Wait_ReCreateTick = true;
                        ___Worker = simWorker;

                        if (IsOpenDGSInstalled)
                            iuSleepMax = (uint)ListCollon.SafeRandomPart2.Next(7, 21);
                        else
                            iuSleepMax = (uint)ListCollon.SafeRandomPart2.Next(10, 27);

                        if (!IsOpenDGSInstalled || UnSafeRunAll)
                        {
                            _StartOnTick();
                            return;
                        }
                        bool o = false;
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            if (item == null || item == simWorker || item.mSimDescription == null || item.mAutonomy == null || item.mAutonomy.mSituationComponent == null || item.HasBeenDestroyed)
                                continue;

                            if (item.GetSituationOfType<NiecHelperSituation>() != null) { o = true; break; }
                        }
                        if (!o)
                        {
                            _StartOnTick();
                        }
                        //else _Wait_ReCreateTick = false;
                    }
                }
            }


            public void ___OnTick05() {
                while (true) {
                    NFinalizeDeath.SleepTask(50);
                    NFinalizeDeath.List_FastClearEx(ref mInteractions);
                    if (___Worker == null) {
                        NFinalizeDeath.SleepTask(200);
                        NFinalizeDeath.List_FastClearEx(ref mInteractions);
                        break;
                    }
                }
            }


            public  bool verifyDeadSim(IGameObject simToCheck, ref float score)
            {
                Sim sim = simToCheck as Sim;
                if (sim == null) 
                    return false;

                SimDescription simd = sim.SimDescription;
                if (simd == null) // Custom
                {
                    if (___bOpenDGSIsInstalled_)
                        return false;
                    else
                    {
                        sim.mSimDescription = NiecMod.Helpers.Create.NiecNullSimDescription();
                        try
                        {
                            NFinalizeDeath._MoveInventoryItemsToAFamilyMember(sim, PlumbBob.SelectedActor);
                            NFinalizeDeath.DeleteInvSim(sim);
                        }
                        catch (ResetException)
                        { throw; }
                        catch { }
                        NFinalizeDeath.ForceDestroyObject(sim);
                        return false;
                    }
                }


                if (!IsOpenDGSInstalled) {

                    iSleep++;
                    if (iSleep > 13) { 
                        iSleep = 0; 
                        Simulator.Sleep(0); 
                    }
                    //if ((simd.CreatedByService is global::Sims3.Gameplay.Services.GrimReaper) || (simd.Service is global::Sims3.Gameplay.Services.GrimReaper))
                    if ( __bIsGrimReaper(sim))
                        return false;
                }
                //else 

                if (simd.DeathStyle != 0 && !simd.IsGhost)
                {
                    if (IsOpenDGSInstalled && _bTargetNoActiveHouseholdExAA && sim != NiecMod.Helpers.NiecRunCommand.looptargetdied_data && sim != NFinalizeDeath.ActiveActor)
                    {
                        //if (sim == NFinalizeDeath.ActiveActor)
                        //    return false;
                        //if (sim.Household != null && sim.Household == NFinalizeDeath.ActiveHouseholdWithoutDGSCore)
                        //    return false;
                        Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                        if (ActiveHousehold != null && simd.Household == ActiveHousehold )
                        {
                            Sims3.Gameplay.Services.GrimReaper sGrimReaperInstance = Sims3.Gameplay.Services.GrimReaper.Instance;
                            //if (sGrimReaperInstance != null && (sGrimReaperInstance.mPool == null || sGrimReaperInstance.mPool.Count == 0)) { }
                            if (sGrimReaperInstance == null || sGrimReaperInstance.mPool == null || sGrimReaperInstance.mPool.Count == 0) { }
                            else return false; 
                        } 
                    }
                    return true;
                }
                return false;
            }

            public bool verifyDeadSimSkipSelected(IGameObject simToCheck, ref float score)
            {
                if (verifyDeadSim(simToCheck, ref score))
                {
                    Sim sim = simToCheck as Sim;
                    if (sim != null && !sim.HasBeenDestroyed)
                    {
                        SimDescription simd = sim.SimDescription;
                        return simd != null && !(simd.CreatedByService is global:: Sims3.Gameplay.Services.GrimReaper) && !(simd.Service is global:: Sims3.Gameplay.Services.GrimReaper);
                    }
                }
                if (IsOpenDGSInstalled)
                {
                    iuSleep++;
                    if (iuSleep > iuSleepMax)
                    {
                        iuSleep = 0;
                        Simulator.Sleep(0);
                    }
                }
                return false;
            }


            private uint iuSleep = 0;

            public uint iuSleepMax = 8;

            [Persistable(false)]
            private Sim ___Worker = null;








            /// <summary>
            /// ///////////////////////////////////////////////////////////////
            /// </summary>
            private InteractionInstance intat = null;
            public uint __ResetAginGrim = 0;
            public uint __ResetAginGrimX = 0;
            private void ___OnTick01__()
            {
                while (!otherBool01)
                {
                    //Simulator.Sleep(1050);
                    for (int i = 0; i < 1750; i++)
                    {
                        Simulator.Sleep(0);
                        
                        if (___Worker == null || ___Worker.SimDescription == null || ___Worker.HasBeenDestroyed)
                            break;
                    }

                    if (___Worker == null || ___Worker.SimDescription == null || ___Worker.HasBeenDestroyed) 
                        break;

                    if (NiecMod.Helpers.NiecRunCommand.loopaadied_ObjectID.mValue != 0)
                        continue;

                    if (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker) == null) //___Worker.GetSituationOfType<NiecHelperSituation>() == null)
                    {  break; }

                    if (!UnsafeRunReapSoul(___Worker)) { Simulator.Sleep(30); continue; }

                    if (___Worker.InteractionQueue == null)
                        continue;

                    if (__ResetAginGrim > 3)
                    {
                        intat = null;

                        __ResetAginGrimX = 0;
                        __ResetAginGrim = 0;

                        ___Worker.SetObjectToReset();

                        Simulator.Sleep(0);
                        NFinalizeDeath.SafePosGoToHouse(___Worker, Simulator.CheckYieldingContext(false));
                        Parent.CleanUp__();
                        Parent.OkSuusse = false;
                        Parent.OkSuusseD = false;
                        Parent.OkSuusseDD = false;

                        continue;
                    }

                    if (__ResetAginGrim == 0)
                        intat = NFinalizeDeath._GetCurrentInteraction(___Worker);


                    Simulator.Sleep(0);
                    if (___Worker == null) 
                        break;
                    if (___Worker.InteractionQueue == null)
                        continue;

                    ___Worker.FadeIn();

                    if (___Worker.InteractionQueue.HasInteractionOfType(NiecAppear.Singleton)) {
                        if (intat == NFinalizeDeath._GetCurrentInteraction(___Worker))
                            __ResetAginGrim++;
                        else
                            __ResetAginGrim = 0;
                        continue;
                    }
                    if (___Worker.InteractionQueue.HasInteractionOfType(ReapSoul.Singleton)) {
                        if (intat == NFinalizeDeath._GetCurrentInteraction(___Worker))
                            __ResetAginGrim++;
                        else
                            __ResetAginGrim = 0;
                        continue;
                    }

                    Simulator.Sleep(0);
                    if (___Worker == null) 
                        break;
                    if (___Worker.InteractionQueue == null)
                        continue;

                    //ResetAginGrim = 0;
                    if (___Worker != PlumbBob.SelectedActor && ___Worker.LotCurrent != ___Worker.LotHome)
                    {
                        __ResetAginGrimX++;
                        if (__ResetAginGrimX > 7)
                        {
                            intat = null;

                            __ResetAginGrimX = 0;
                            __ResetAginGrim = 0;

                            Parent.OkSuusse = false;
                            Parent.OkSuusseD = false;
                            Parent.OkSuusseDD = false;

                            ___Worker.SetObjectToReset();

                            Simulator.Sleep(0);
                            NFinalizeDeath.SafePosGoToHouse(___Worker, Simulator.CheckYieldingContext(false));
                        }
                    }
                    else __ResetAginGrimX = 0;
                }
            }
            /// <summary>
            /// /////////////////////////////////////////////////
            /// </summary>





            public static bool iesroesrte = false;
            private void ___OnTick03__()
            {
                List<InteractionInstance> list = new List<InteractionInstance>(200);
                InteractionPriority s = new InteractionPriority(InteractionPriorityLevel.Zero);
                while (true)
                {
                    Simulator.Sleep(0);


                    if (___Worker == null || ___Worker.SimDescription == null || ___Worker.HasBeenDestroyed)
                        break;

                    if (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker) == null) //___Worker.GetSituationOfType<NiecHelperSituation>() == null)
                    { break; }

                    if (!UnsafeRunReapSoul(___Worker)) { Simulator.Sleep(30); continue; }


                    Sim Sim = ___Worker;

                    //if (Sim == null) continue;
                    try
                    {
                        InteractionQueue actormIQ = Sim.mInteractionQueue;
                        if (actormIQ == null) continue;
                        var actormIQList = actormIQ.mInteractionList;
                        if (actormIQList != null)
                        {
                            if (actormIQList._items == null)
                            {
                                actormIQList._items = new InteractionInstance[50];
                                actormIQList._size = 0;
                                actormIQList._version++;
                            }
                            if (NFinalizeDeath.RemoveDuplicateInteraction<ReapSoul>(actormIQList, Sim, 8, 15) && Sim == NFinalizeDeath.ActiveActor)
                            {
                                actormIQ.FireQueueChanged();
                            }

                            if (NFinalizeDeath.RemoveDuplicateInteraction<NiecAppear>(actormIQList, Sim, 8, 15) && Sim == NFinalizeDeath.ActiveActor)
                            {
                                actormIQ.FireQueueChanged();
                            }

                        }
                        else continue;

                        InteractionInstance actorInteracton = actormIQ.GetCurrentInteraction();
                        if (actorInteracton == null || actorInteracton.InteractionObjectPair == null) continue;



                        Sim KillNPC = (actorInteracton.InteractionObjectPair.mTarget as Sim);
                        if (KillNPC != null && KillNPC != Sim && !KillNPC.IsSelectable)
                        {
                            if (KillNPC.mActorsUsingMe != null && KillNPC.mActorsUsingMe.Count != 0)
                                KillNPC.mActorsUsingMe.Clear();

                            if (KillNPC.mReferenceList != null && KillNPC.mReferenceList.Count != 0)
                                KillNPC.mReferenceList.Clear();

                            if (KillNPC.mRoutingReferenceList != null && KillNPC.mRoutingReferenceList.Count != 0)
                                KillNPC.mRoutingReferenceList.Clear();

                            if (NFinalizeDeath.ActorIsQueueNHS(KillNPC)) continue;

                            InteractionQueue KillNPCIQ = KillNPC.mInteractionQueue;
                            if (KillNPCIQ == null) continue;
                            Simulator.Sleep(0);
                            List<InteractionInstance> KillNPCIQList = KillNPCIQ.mInteractionList;
                            if (KillNPCIQList != null)
                            {
                                if (list.Count != 0)
                                    list.Clear();

                                if (NFinalizeDeath.RemoveDuplicateInteraction<ReapSoul>(KillNPCIQList, KillNPC, 8, 15) && KillNPC == NFinalizeDeath.ActiveActor)
                                {
                                    KillNPCIQ.FireQueueChanged();
                                }

                                if (NFinalizeDeath.RemoveDuplicateInteraction<NiecAppear>(KillNPCIQList, KillNPC, 8, 15) && KillNPC == NFinalizeDeath.ActiveActor)
                                {
                                    KillNPCIQ.FireQueueChanged();
                                }
                                Simulator.Sleep(0);
                                if (NFinalizeDeath.RemoveDuplicateInteraction<ReapSoul>(actormIQList, KillNPC, 8, 15) && Sim == NFinalizeDeath.ActiveActor)
                                {
                                    actormIQ.FireQueueChanged();
                                }

                                if (NFinalizeDeath.RemoveDuplicateInteraction<NiecAppear>(actormIQList, KillNPC, 8, 15) && Sim == NFinalizeDeath.ActiveActor)
                                {
                                    actormIQ.FireQueueChanged();
                                }

                                list.AddRange(KillNPCIQList);
                                //Simulator.Sleep(0);
                                foreach (InteractionInstance xinteractionInstance in list)
                                {
                                    if (xinteractionInstance == null)
                                        KillNPCIQList.Remove(xinteractionInstance);
                                    else
                                    {
                                        if (xinteractionInstance is NinecReaper)
                                            continue;
                                        if (xinteractionInstance is ExtKillSimNiec || xinteractionInstance.InteractionDefinition is KillSimNiecX.NiecDefinitionDeathInteraction)
                                        {
                                            xinteractionInstance.mPriority = new InteractionPriority(InteractionPriorityLevel.MaxDeath, 10f);
                                            continue;
                                        }
                                        if (xinteractionInstance is NiecAppear || xinteractionInstance.InteractionDefinition is ReapSoul)
                                        {
                                            xinteractionInstance.mPriority = new InteractionPriority(InteractionPriorityLevel.MaxDeath, 0f);
                                            xinteractionInstance.mMustRun = true;
                                            continue;
                                        }
                                        if (xinteractionInstance is Urnstone.KillSim || xinteractionInstance is global::Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.NiecKillSim)
                                        {
                                            xinteractionInstance.mPriority = new InteractionPriority(InteractionPriorityLevel.MaxDeath, 10f);
                                            continue;
                                        }
                                        if (iesroesrte && (xinteractionInstance is INHSInteraction))
                                        {
                                            if (kDEBUGIsO03)
                                            {
                                                kDEBUGIsO03 = false;
                                                NFinalizeDeath.Assert(false, "___OnTick03__: (xinteractionInstance is INHSInteraction) failed");
                                                for (int i = 0; i < 700; i++)
                                                {
                                                    Simulator.Sleep(0);
                                                }
                                                kDEBUGIsO03 = true;
                                            }
                                            continue;
                                        }
                                        xinteractionInstance.mbOnStopCalled = true;
                                        xinteractionInstance.CancellableByPlayer = true;
                                        xinteractionInstance.mMustRun = false;
                                        xinteractionInstance.mHidden = false;
                                        xinteractionInstance.mPriority = s;
                                        if (xinteractionInstance is Sim.GoToVirtualHome || xinteractionInstance.InteractionDefinition is Sim.GoToVirtualHome.GoToVirtualHomeInternal)
                                            KillNPCIQList.Remove(xinteractionInstance);
                                    }
                                }
                            }
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Simulator.Sleep(0);
                        }
                    }
                }
            }


            private void ___OnTick04__()
            {
                while (true)
                {
                    Simulator.Sleep(0);

                    try
                    {
                        if (___Worker == null || ___Worker.SimDescription == null || ___Worker.HasBeenDestroyed)
                            break;

                        if (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker) == null) //___Worker.GetSituationOfType<NiecHelperSituation>() == null)
                        { break; }

                        if (!UnsafeRunReapSoul(___Worker) || PlumbBob.SelectedActor == ___Worker) { Simulator.Sleep(30); continue; }

                        if (___Worker == null) 
                            break;

                        InteractionQueue inet = ___Worker.mInteractionQueue;
                        if (inet == null)
                            continue;

                        List<InteractionInstance> lttist = inet.mInteractionList;
                        if (lttist != null && lttist.Count > 0)
                        {
                            //InteractionPriority DRathPr = KillSimNiecX.DGSAndNonDGSPriority();
                            foreach (InteractionInstance xinteractionInstance in lttist.ToArray())
                            {
                                if (xinteractionInstance == null) 
                                    continue;

                                if (xinteractionInstance is NiecAppear || xinteractionInstance.InteractionDefinition is ReapSoul)
                                {
                                    xinteractionInstance.mPriority = new InteractionPriority(InteractionPriorityLevel.MaxDeath, 0f);
                                    xinteractionInstance.mMustRun = true;
                                    continue;
                                }

                                if (xinteractionInstance is NinecReaper)
                                    continue;
                                if (xinteractionInstance is ExtKillSimNiec || xinteractionInstance.InteractionDefinition is KillSimNiecX.NiecDefinitionDeathInteraction)
                                    continue;
                                if (xinteractionInstance is Urnstone.KillSim || xinteractionInstance is global::Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.NiecKillSim)
                                    continue;
                                //if (xinteractionInstance == ___Worker.CurrentInteraction) continue;
                                xinteractionInstance.mPriority = lowPr;
                                xinteractionInstance.mbOnStopCalled = true;
                                xinteractionInstance.mMustRun = false;
                            }
                            inet.RemoveLowerPriorityInteractions();
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Simulator.Sleep(0);
                        }
                    }
                    
                }
            }

            private  static bool aotot___OnTick02__ = false;

            private void ___OnTick02__()
            {
                try
                {
                    while (aotot___OnTick02__)
                    {
                        if (___Worker == null || ___Worker.SimDescription == null || ___Worker.HasBeenDestroyed)
                            break;
                        if (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker) == null) //___Worker.GetSituationOfType<NiecHelperSituation>() == null)
                        { break; }
                        Simulator.Sleep(0);
                    } 
                    while (true)
                    {
                        aotot___OnTick02__ = true;
                        //Simulator.Sleep(250);
                        //Simulator.Sleep(1050);

                        for (int i = 0; i < 250; i++)
                        {
                            Simulator.Sleep(0);
                            if (reRunLightning.Count > 0)
                                NFinalizeDeath.RunLightning(null, reRunLightning.Pop(), false);
                            if (___Worker == null || ___Worker.SimDescription == null || ___Worker.HasBeenDestroyed)
                                break;
                        }

                        if (___Worker == null || ___Worker.SimDescription == null || ___Worker.HasBeenDestroyed)
                            break;



                        if (NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker) == null) //___Worker.GetSituationOfType<NiecHelperSituation>() == null)
                        { break; }

                        if (!UnsafeRunReapSoul(___Worker)) { Simulator.Sleep(30); continue; }

                        //if (___Worker.InteractionQueue == null)
                        //    continue;
                        
                        //if (___Worker.InteractionQueue == null || (!___Worker.InteractionQueue.HasInteractionOfType(NiecAppear.Singleton)
                        //    && !___Worker.InteractionQueue.HasInteractionOfType(ReapSoul.Singleton)))
                        if (___Worker.mInteractionQueue == null || ___Worker.mInteractionQueue.mInteractionList == null|| !NFinalizeDeath.FastHasInteraction<INHSInteraction>(___Worker.mInteractionQueue.mInteractionList, 15))
                        {
                            int sleep = 0;
                            foreach (Sim Target in RuningDeadSimList.ToArray())
                            {
                                sleep++;
                                if (sleep > 200)
                                {
                                    Simulator.Sleep(0);
                                    break;
                                }
                                //RuningDeadSimList.Remove(Target);
                                niec_std.list_remove(RuningDeadSimList, Target);
                                if (Target == null)
                                    continue;
                                if (___Worker == Target)
                                    continue;
                                //if (NFinalizeDeath.IsSimFastActiveHousehold(Target) || Target.IsInActiveHousehold)
                                if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Target))
                                    continue;
                                if (NFinalizeDeath.IsTargetIQNHS(Target))
                                { 
                                    //if (!RuningDeadSimList.Contains(Target)) 
                                    if (niec_std.array_indexof(RuningDeadSimList._items, Target) == -1)
                                        // RuningDeadSimList.Add(Target); 
                                        NFinalizeDeath.AddItemToList(RuningDeadSimList, Target);
                                    continue; 
                                }
                                try
                                {

                                    if (Target.mActorsUsingMe != null && Target.mActorsUsingMe.Count != 0)
                                        Target.mActorsUsingMe.Clear();

                                    if (Target.mReferenceList != null && Target.mReferenceList.Count != 0)
                                        Target.mReferenceList.Clear();

                                    if (Target.mRoutingReferenceList != null && Target.mRoutingReferenceList.Count != 0)
                                        Target.mRoutingReferenceList.Clear();


                                    if (Target.mInteractionQueue != null)
                                        Target.mInteractionQueue.mCurrentTransitionInteraction = null;

                                    if (Target.mSimDescription == null)
                                    {
                                        Target.mSimDescription = NiecMod.Helpers.Create.NiecNullSimDescription(false, false, true);
                                        Target.mSimDescription.mSim = Target;
                                    }

                                    SimDescription simd = Target.SimDescription;
                                    Urnstone RIPObject = null;

                                    RIPObject = HelperNra.TFindGhostsGrave(simd);

                                    if (RIPObject == null)
                                        NFinalizeDeath.GetKillNPCSimToGhost(Target, simd.DeathStyle, NiecAppear.getPositionForGhost(Target, ___Worker), out RIPObject);
                                    if (RIPObject == null)
                                        RIPObject = Urnstone.CreateGrave(simd, false, true);


                                    if (RIPObject != null)
                                    {
                                        try
                                        {
                                            StyledNotification.Format format = new StyledNotification.Format("AntiNPCSim:\nRIP " + simd.FullName, RIPObject.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                                            StyledNotification.Show(format);
                                        }
                                        catch (ResetException)
                                        {
                                            throw;
                                        }
                                        catch
                                        { }
                                        NiecAppear.placeGraveStone(___Worker, Target, RIPObject);
                                        if (RIPObject.LotCurrent.IsWorldLot)
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

                                                if (lieastwt.Count != 0)
                                                {
                                                    lotwt = RandomUtil.GetRandomObjectFromList<Lot>(lieastwt, ListCollon.SafeRandomPart2);
                                                }
                                                RIPObject.SetPosition(lotwt.Position);
                                            }
                                            catch (ResetException)
                                            {
                                                throw;
                                            }
                                            catch
                                            { }
                                        }
                                    }
                                    else NFinalizeDeath.SimDescCleanse(simd, true, false);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch { }



                                //break;
                            }
                        }
                    }
                    aotot___OnTick02__ = false;
                }
                catch (Exception)
                {
                    aotot___OnTick02__ = false;
                    throw;
                }
                
            }
           

            //public void Stop() {
            //
            //}
            private InteractionPriority deathPr = KillSimNiecX.DGSAndNonDGSPriority();
            private InteractionPriority lowPr = new InteractionPriority((InteractionPriorityLevel)1, 0);

            //public bool RunningOnTick { get { return _RunTick; } }

            //private void SetReT()
            //{
            //    _RunTick = true;
            //    _Wait_ReCreateTick = false;
            //}

            public static uint ActiveHouseholdWorkingNHS_Count() {
                var ah = NFinalizeDeath.ActiveHousehold_AllSim;
                if (ah == null) return 0;
                uint foundCountActiveHousehold = 0;
                int sleep = 0;
                uint i;
                //Sim simActiveActor = NFinalizeDeath.ActiveActor;

                //foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                foreach (var item in ah)
                {
                    sleep++;
                    if (sleep >= 35)
                    { 
                        sleep = 0;
                        if (foundCountActiveHousehold == 0) { Simulator.Sleep(0); }
                        else
                        {
                            for (i = 0; i < foundCountActiveHousehold; i++)
                            {
                                Simulator.Sleep(0);
                            }
                        }
                        //simActiveActor = NFinalizeDeath.ActiveActor;
                    }

                    NiecHelperSituation nhs = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(item);
                    if (nhs == null) 
                        continue; 

                    NiecHelperSituation.Spawn nhsSp = nhs.Child as NiecHelperSituation.Spawn;
                    if (nhsSp == null)
                        continue;

                    //if (NFinalizeDeath.IsActiveHouseholdWithActiveActorPro(item.Household, simActiveActor)) 
                        foundCountActiveHousehold++;
                }
                return foundCountActiveHousehold;
            }

            public static bool FastGoodFindPOS = false;

            private void ___OnTick()
            {
                //SetReT();
                for (int i = 0; i < 10; i++)
                {
                    Simulator.Sleep(0);
                }
                //if (!IsOpenDGSInstalled)
                //{
                //    if (NFinalizeDeath.TargetObjectIsRunningTask(this, true) != 1)
                //        return;
                //}
                try
                {
                    if (NFinalizeDeath.ActorIsQueueNHS(___Worker))
                    {
                        ___Worker.AddExitReason(ExitReason.Default);
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }
                
                RunningWorkingNiecHelperSituation++;
                bool fo = false;
                 start:;
                
                try
                {
                    while (___Worker != null && ___bOpenDGSIsInstalled_ ? !___Worker.HasBeenDestroyed : !SimHasBeenDestroyed(___Worker)) // Loop 
                    {
                        //SetReT();
                        Simulator.Sleep(0);

                        bShouldOnSavingGame = false;

                        var ty = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker);
                        if (ty == null) //___Worker.GetSituationOfType<NiecHelperSituation>() == null)
                        { fo = false; break; }
                        if (ty.mChild != this) {
                            fo = false; 
                            break; 
                        }
                        if (!UnsafeRunReapSoul(___Worker)) { Simulator.Sleep(30); continue; }
                        
                        if (___Worker.InteractionQueue == null)
                        {
                            continue;
                        }
                        
                        if (IsOpenDGSInstalled)
                        {

                            if (___Worker.InteractionQueue.HasInteractionOfType(NiecAppear.Singleton) || ___Worker.InteractionQueue.HasInteractionOfType(ReapSoul.Singleton))
                            { 
                                Simulator.Sleep(23);

                                continue;
                            }

                        }
                        if (IsNoActiveHousehold(___Worker) && RunningWorkingNiecHelperSituation != ActiveHouseholdWorkingNHS_Count()) { continue; }

                        Simulator.Sleep(0);

                        if (IsOpenDGSInstalled)
                        {
                            if (DisableOnTick_OpenDGSOnly)
                            {
                                for (int i = 0; i < 50; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                                continue;
                            }
                        }
                        else if (DisableOnTick)
                        {
                            if (!NFinalizeDeath.SimIsGRReaper(___Worker.mSimDescription))
                            {
                                if (NFinalizeDeath.ActiveActor != ___Worker)
                                    continue;
                            }
                        }

                        if (ExAA && (___Worker == PlumbBob.SelectedActor || ___Worker == NFinalizeDeath.ActiveActor))
                            continue;


                        Sim[] simlist = NFinalizeDeath.SC_GetObjects<Sim>();

                       // if (//!IsOpenDGSInstalled || 
                        //sIsGrimReaper)

                        

                        if (IsOpenDGSInstalled && sIsGrimReaper)
                        {
                            bool o = false;
                            int i = 0;
                            foreach (var item in simlist)
                            {
                                if (IsOpenDGSInstalled)
                                {
                                    i++;
                                    if (i == 8) { Simulator.Sleep(0); i = 0; }
                                }
                                if (item == null || item.mSimDescription == null || item.mAutonomy == null || item.mAutonomy.mSituationComponent == null)
                                    continue;

                                else if (item.GetSituationOfType<Sims3.Gameplay.Services.GrimReaperSituation>() != null) { o = true; break; }


                            }

                            if (o)
                                continue;
                        }
                        if (___Worker == null) { fo = false; break; }
                        Sim closestObject = GlobalFunctions.GetClosestObject(simlist, ___Worker, false, true, true, 0, EmptySimList, verifyDeadSimSkipSelected);
                        if (closestObject == null)
                        {
                           // Simulator.Sleep(0);
                            Simulator.Sleep(IsOpenDGSInstalled ? 50u : 0u);
                            if (___Worker == null) { fo = false; break; }
                            closestObject = GlobalFunctions.GetClosestObject(simlist, ___Worker, false, true, true, 0, EmptySimList, verifyDeadSim);
                            if (closestObject == null)
                            {
                                //Simulator.Sleep(IsOpenDGSInstalled ? 190u : RunningWorkingNiecHelperSituation > 3 ? 1u : 0u);
                                Simulator.Sleep(IsOpenDGSInstalled ? 150u : 0u);
                                if (IsOpenDGSInstalled)
                                    NFinalizeDeath.List_FastClearEx(ref mInteractions);
                                continue;
                            }
                        }

                        if (IsOpenDGSInstalled && DisableOnTick_OpenDGSOnly)
                        {
                            for (int i = 0; i < 50; i++)
                            {
                                Simulator.Sleep(0);
                            }
                            continue;
                        }

                        if (!UnsafeRunReapSoul(___Worker)) { Simulator.Sleep(30); continue; }

                        if (closestObject != null)
                        {
                            //if (!IsOpenDGSInstalled)
                            //{
                            //    if (RuningDeadSimList.Contains(closestObject)) 
                            //        continue;
                            //}
                            /*
                            if (!IsOpenDGSInstalled)
                            {
                                try // Cant Add
                                {
                                    foreach (InteractionInstance interactionInstance in ___Worker.mInteractionQueue.mInteractionList.ToArray()) // Cant Cancel Fix
                                    {
                                        if (interactionInstance == null) continue;
                                        interactionInstance.mbOnStopCalled = true;
                                        interactionInstance.CancellableByPlayer = true;
                                        interactionInstance.mMustRun = false;
                                        interactionInstance.mHidden = false;
                                    }
                                    ___Worker.InteractionQueue.CancelAllInteractions();
                                }
                                catch
                                { }

                            }*/
                            if (!IsOpenDGSInstalled)
                            {
                                try
                                {
                                    NFinalizeDeath.UnSafeSimDeAttachAndPosture(closestObject);
                                    NFinalizeDeath.UnSafeSimDeAttachAndPosture(___Worker);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch { }
                               
                            }
                            if (SimHasBeenDestroyed(___Worker)) //___Worker.GetSituationOfType<NiecHelperSituation>() == null)
                            { fo = false; break; }
                            if (___Worker.InteractionQueue == null)
                                continue;
                            if (IsOpenDGSInstalled && NFinalizeDeath.InteractionIsNiecHelperSituation(NFinalizeDeath._GetCHeadInteraction(___Worker))) continue;
                            bool OkSuusse_ = Parent.OkSuusse;
                            if (ForceSituationSpecificInteraction(
                            priority: 

                            IsOpenDGSInstalled ? 
                                new InteractionPriority((InteractionPriorityLevel)100, 999f)
                            : new InteractionPriority(InteractionPriorityLevel.ESRB, 999f),

                            x: closestObject,
                            s: ___Worker,
                            i: !OkSuusse_ ? NiecAppear.Singleton : ReapSoul.Singleton,
                            callbackOnStart: null,
                            callbackOnCompletion: null,
                            callbackOnFailure: null) != null)
                            {
                                if (!OkSuusse_)
                                {
                                    Parent.OkSuusseDD = true;
                                }
                                if (!IsOpenDGSInstalled)
                                {
                                   
                                    try
                                    {
                                        int ia =  NFinalizeDeath.Random_CoinFlip() ? 5 : 2;
                                        for (int i = 0; i < ia; i++)
                                        {
                                            if (mInteractions != null)
                                                mInteractions.Add(NFinalizeDeath._GetCHeadInteraction(___Worker));
                                        }
                                        

                                        if (___Worker.Autonomy != null && ___Worker.Autonomy.Motives != null && !(___Worker.CurrentInteraction is NiecAppear) 
                                            && !(___Worker.CurrentInteraction is ReapSoul))
                                            ___Worker.AddExitReason
                                                (ExitReason.Default | ExitReason.Finished | 
                                                ExitReason.HigherPriorityNext | ExitReason.CanceledByScript);
                                        // End if
                                        if (___Worker.Autonomy != null && ___Worker.Autonomy.Motives != null)
                                            ___Worker.Autonomy.Motives.MaxEverything();
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch { }
                                }


                                if (!SafePosNHSTickOnly()) continue;
                                if (SafePos2020()) continue;
                                Sim ActiveActor = PlumbBob.SelectedActor ??
                                    NFinalizeDeath.ActiveActor ??
                                    closestObject ??
                                    ___Worker ??
                                    ((NFinalizeDeath.SC_GetObjects<Sim>().Length > 0) ? NFinalizeDeath.SC_GetObjects<Sim>()[0] : null);

                                


                                if (ActiveActor != null)
                                {
                                    bool tdone = false;
                                    var activelot = NFinalizeDeath.ActiveLotHome;
                                    if (ActiveActor.LotCurrent != null && ActiveActor.LotCurrent.IsWorldLot)
                                    {
                                        foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                                        {
                                            if (item == null || item.LotCurrent == null || item.LotCurrent.IsWorldLot) continue;
                                            ActiveActor = item;
                                            StyledNotification.Format format = new StyledNotification.Format("NiecHelperSituation:\nFound IsWorldLot Lot != Lot", item.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                                            StyledNotification.Show(format);
                                            tdone = true;
                                            break;
                                        }
                                    }

                                    if (!tdone && IsOpenDGSInstalled) {
                                        if (ActiveActor.LotCurrent == activelot)
                                        {
                                            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                                            {
                                                if (item == null || item.LotCurrent == null || item.LotCurrent == activelot || item.LotCurrent.IsWorldLot) 
                                                    continue;
                                                ActiveActor = item;
                                                break;
                                            }
                                        } 
                                    }
                                    Lot actorLotCurrent = ActiveActor.LotCurrent;
                                    if (actorLotCurrent != null && actorLotCurrent.CommercialLotSubType == CommercialLotSubType.kGraveyard)
                                    {
                                        foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                                        {
                                            
                                            if (item == null)
                                                continue;

                                            Lot itemLotCurrent = item.LotCurrent;
                                            if (itemLotCurrent == null                                                  || 
                                                itemLotCurrent.IsWorldLot                                               || 
                                                itemLotCurrent.CommercialLotSubType == CommercialLotSubType.kGraveyard) 
                                            continue;

                                            ActiveActor = item;
                                            break;
                                        }
                                    }

                                    Vector3 pos;
                                    Vector3 fwd;

                                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams((FastGoodFindPOS ? closestObject : ActiveActor).Position);

                                    fglParams.InitialSearchDirection = IsOpenDGSInstalled ? 1 : RandomUtil.GetInt(0x5, 0x11);


                                    if (!GlobalFunctions.FindGoodLocation((FastGoodFindPOS ? closestObject : ActiveActor), fglParams, out pos, out fwd))
                                    {
                                        pos = (FastGoodFindPOS ? closestObject : ActiveActor).Position;
                                        fwd = (FastGoodFindPOS ? closestObject : ActiveActor).ForwardVector;
                                    }

                                    if (IsOpenDGSInstalled)
                                        Simulator.Sleep(1);


                                    ___Worker.SetPosition(pos);
                                    ___Worker.SetForward(fwd);

                                    if (___Worker.SimRoutingComponent != null)
                                        ___Worker.SimRoutingComponent.ForceUpdateDynamicFootprint();

                                    if (IsOpenDGSInstalled)
                                        Simulator.Sleep(1);


                                    if (!GlobalFunctions.FindGoodLocation((FastGoodFindPOS ? closestObject : ActiveActor), fglParams, out pos, out fwd))
                                    {
                                        pos = (FastGoodFindPOS ? closestObject : ActiveActor).Position;
                                        fwd = (FastGoodFindPOS ? closestObject : ActiveActor).ForwardVector;
                                    }

                                    if (IsOpenDGSInstalled)
                                        Simulator.Sleep(1);

                                    closestObject.SetPosition(pos);
                                    closestObject.SetForward(fwd);

                                    if (closestObject.SimRoutingComponent != null)
                                        closestObject.SimRoutingComponent.ForceUpdateDynamicFootprint();

                                    if (IsOpenDGSInstalled)
                                        Simulator.Sleep(1);
                                }

                                if (IsOpenDGSInstalled)
                                {
                                    NFinalizeDeath.List_FastClearEx(ref mInteractions);
                                    Simulator.Sleep(1);
                                }

                                if (!IsOpenDGSInstalled && !closestObject.SimDescription.IsGhost)
                                {
                                    if (NiecHelperSituation.__acorewIsnstalled__ && !isdgmods)
                                    {
                                        aweoerpasd++;
                                        if (aweoerpasd < 4)
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                Simulator.Sleep(0);
                                            }
                                        }
                                        else {
                                            aweoerpasd = 0;
                                            closestObject.SimDescription.IsGhost = true; 
                                        }
                                    }
                                    else closestObject.SimDescription.IsGhost = true;

                                    try
                                    {
                                        if (!closestObject.IsSelectable && closestObject.InteractionQueue != null)
                                        {
                                            NFinalizeDeath.FastProCancel(closestObject);
                                            closestObject.InteractionQueue.Add(
                                                NinecReaper.Singleton.CreateInstance(closestObject, closestObject,
                                                    IsOpenDGSInstalled ?
                                                        new InteractionPriority((InteractionPriorityLevel)100, 999f)
                                                    : new InteractionPriority(InteractionPriorityLevel.ESRB, 999f)
                                                , 
                                                false, 
                                                true
                                            ));
                                            //InteractionQueue tarQueuesimdiad = closestObject.mInteractionQueue;
                                            //if (tarQueuesimdiad != null)
                                            //{
                                            //    List<InteractionInstance> tara = tarQueuesimdiad.mInteractionList;
                                            //    if (tara != null)
                                            //    {
                                            //        foreach (var item in tara.ToArray())
                                            //        {
                                            //            if (item == null)
                                            //                tara.Remove(item);
                                            //            else
                                            //            {
                                            //                if (item is Sim.GoToVirtualHome || item.InteractionDefinition is Sim.GoToVirtualHome.GoToVirtualHomeInternal)
                                            //                { 
                                            //                    tara.Remove(item); 
                                            //                    continue; 
                                            //                }
                                            //                if (item is NinecReaper) 
                                            //                    continue;
                                            //                if (item is ExtKillSimNiec || 
                                            //                    item.InteractionDefinition is KillSimNiecX.NiecDefinitionDeathInteraction)
                                            //                    continue;
                                            //                if (item is NiecAppear || 
                                            //                    item.InteractionDefinition is ReapSoul)
                                            //                    continue;
                                            //                if (item is Urnstone.KillSim || 
                                            //                    item is global::Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.NiecKillSim)
                                            //                    continue;
                                            //                item.mbOnStopCalled = true;
                                            //                item.mMustRun = false;
                                            //                item.mHidden = false;
                                            //                item.mPriority = lowPr;
                                            //            }
                                            //        }
                                            //        closestObject.InteractionQueue.Add(
                                            //            NinecReaper.Singleton.CreateInstance(closestObject, closestObject,
                                            //            IsOpenDGSInstalled ?
                                            //            new InteractionPriority((InteractionPriorityLevel)100, 999f)
                                            //            : new InteractionPriority(InteractionPriorityLevel.ESRB, 999f)
                                            //            , false, true
                                            //        ));
                                            //    }
                                            //}
                                        }
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch (Exception)
                                    { }
                                    


                                    if (RunningWorkingNiecHelperSituation == 1)
                                        Camera.FocusOnSim(closestObject);
                                    else
                                    {
                                        try
                                        {
                                            //StyledNotification.Format format = new StyledNotification.Format(___Worker.GetLocalizedName() + ": Found Sim Dead", ___Worker.ObjectId, closestObject.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                                            //StyledNotification.Show(format);
                                            Camera.CameraNotification.ShowNotificationAndFocusOnSim (
                                                ___Worker.ObjectId, 
                                                ___Worker.GetLocalizedName() + ": Found Sim Dead",
                                                ___Worker
                                            );
                                        }
                                        catch (ResetException)
                                        {
                                            throw;
                                        }
                                        catch (Exception)
                                        { }
                                    }
                                }
                            }
                            else { niec_std.wait_assert("NiecHelperSituation:\nFailed (NiecApper || NiecReapSoul) == null"); ___Worker = null; return; }
                        }
                    }
                }
                catch (ResetException)
                {
                    if (!fo)
                        ___Worker = null;
                    RunningWorkingNiecHelperSituation--;
                    //_RunTick = false;
                    //_Wait_ReCreateTick = false;
                    throw;
                }
                catch
                {
                    try
                    {
                        if (___Worker != null && ___Worker.SimDescription != null && ___Worker.SimDescription.IsValidDescription && ___Worker.InteractionQueue != null && NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker) != null)
                        {
                            fo = true;
                            if (IsOpenDGSInstalled)
                            {
                                AlarmManager.AddAlarm(30, TimeUnit.Minutes, delegate
                                {
                                    ___Worker = Parent.Worker;
                                    Sims3.NiecHelp.Tasks.NiecTask.Perform(___OnTick);
                                }, null, AlarmType.NeverPersisted, ___Worker);
                            }
                            else if (Simulator.CheckYieldingContext(false))
                            {
                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(___Worker);
                                ___Worker.mPosture = ___Worker.Standing;
                                for (int i = 0; i < 120; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                                goto start;
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
                if (!fo)
                    ___Worker = null;
                RunningWorkingNiecHelperSituation--;
                //_RunTick = false;
                //_Wait_ReCreateTick = false;
            }

            private void _StartOnTick()
            {
                
                Sims3.NiecHelp.Tasks.NiecTask.Perform(___OnTick);
                if (IsOpenDGSInstalled)
                {
                    //Sims3.NiecHelp.Tasks.NiecTask.Perform(___OnTick05);
                }
                //if (!IsOpenDGSInstalled && !_RunTick)
                else
                {
                    if (!otherBool01)
                        Sims3.NiecHelp.Tasks.NiecTask.Perform(___OnTick01__);
                    Sims3.NiecHelp.Tasks.NiecTask.Perform(___OnTick02__);
                    Sims3.NiecHelp.Tasks.NiecTask.Perform(___OnTick03__);
                    Sims3.NiecHelp.Tasks.NiecTask.Perform(___OnTick04__);
                }
            }

            
            public override void Init(NiecHelperSituation parent)
            {
                try
                {
                    if (parent.Worker == NFinalizeDeath.ActiveActor)
                        parent.Worker.Autonomy.Motives.MaxEverything();
                }
                catch (ResetException){ throw; }
                catch { }
               

                ___Worker = Parent.Worker;
                if (IsOpenDGSInstalled)
                    iuSleepMax = (uint)ListCollon.SafeRandomPart2.Next(7, 21);
                else 
                    iuSleepMax = (uint)ListCollon.SafeRandomPart2.Next(10, 27);
                if (!IsOpenDGSInstalled || UnSafeRunAll)
                {
                   
                    _StartOnTick();
                    return;
                }

                




                bool o = false;
                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    
                    if (item == null || item.mSimDescription == null || item.mAutonomy == null || item.mAutonomy.mSituationComponent == null || item.HasBeenDestroyed)
                        continue;

                    if (item.GetSituationOfType<NiecHelperSituation>() != null) { o = true; break; }


                }
                if (!o)
                {
                    _StartOnTick();
                }
                //parent.Worker.Autonomy.Motives.FreezeDecayEverythingExcept();
                
                return;
            }

            /*
            public void NiecCFailed(Sim actor, float x)
            {
                ForceSituationSpecificInteraction(priority: new InteractionPriority((InteractionPriorityLevel)350, 999f), x: parent.Worker, s: actor, i: NiecAppear.Singleton, callbackOnStart: null, callbackOnCompletion: null, callbackOnFailure: NiecCFailed);
            }
            */


            // // 18:53 04/01/2020
            public override void OnParticipantDeleted(Sim participant)
            {
                if (___bOpenDGSIsInstalled_)
                {
                    NFinalizeDeath.List_FastClearEx(ref mInteractions);
                    NFinalizeDeath.List_FastClearEx(ref mForcedInteractions);
                }
                base.OnParticipantDeleted(participant);
            }

            public override void OnReset(Sim s)
            {
                if (s == ___Worker)
                {
                    if (___bOpenDGSIsInstalled_)
                    {
                        NFinalizeDeath.List_FastClearEx(ref mInteractions);
                        NFinalizeDeath.List_FastClearEx(ref mForcedInteractions);
                    }
                }
                base.OnReset(s);
            }

            public override void CleanUp()
            {
                if (___bOpenDGSIsInstalled_)
                {
                    NFinalizeDeath.List_FastClearEx(ref mInteractions);
                    NFinalizeDeath.List_FastClearEx(ref mForcedInteractions);
                }
                try
                {
                    base.AlarmManager.RemoveAlarm(mAlarmHandle);
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { }
                
                base.CleanUp();
            }

            private AlarmHandle mAlarmHandle = AlarmHandle.kInvalidHandle;

            [Persistable(false)]
            public bool OnLoadDone = false;
            public static int aweoerpasd = 0;

            public override void PostLoad()
            {
                RunningWorkingNiecHelperSituation = 0;

                if (OnLoadDone) 
                    return;
                else 
                    OnLoadDone = true;

                try
                {
                    //var niechs = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker);
                    //if (niechs != null && niechs.Child is Spawn)
                    {
                        ___Worker = Parent.Worker;
                        if (IsOpenDGSInstalled && NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(___Worker) != null)
                        {
                            if (NiecMod.Helpers.NiecRunCommand.AutoAllNewNiecSWLoad) goto et;
                           NeedCreateNHSTask = true;
                           //AlarmManager.AddAlarm(10, TimeUnit.Minutes, delegate
                           //{
                           //    if (!IsOpenDGSInstalled || UnSafeRunAll)
                           //    {
                           //
                           //        _StartOnTick();
                           //    }
                           //    else
                           //    {
                           //        int i = 0;
                           //        foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                           //        {
                           //
                           //            if (item == null || item.mSimDescription == null || item.mAutonomy == null || item.mAutonomy.mSituationComponent == null || item.HasBeenDestroyed)
                           //                continue;
                           //
                           //            if (item.GetSituationOfType<NiecHelperSituation>() != null) { i++; }
                           //
                           //
                           //        }
                           //        if (i == 1)
                           //        {
                           //            _StartOnTick();
                           //        }
                           //    }
                           //}, null, AlarmType.NeverPersisted, ___Worker);
                        }
                        else if (!IsOpenDGSInstalled)
                        {
                            NiecTask.Perform(delegate
                            {
                                Simulator.Sleep(1);
                                _StartOnTick();
                            });
                        }
                    }
                    et:base.PostLoad();
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }

            }
            public void PersistPostLoad()
            {
                try
                {
                    if (!IsOpenDGSInstalled)
                        PostLoad();
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }
                
            }
        }


        // ChildSituation
        public class Working : ChildSituation<NiecHelperSituation>
        {
            private Working()
            {
            }

            public Working(NiecHelperSituation parent)
                : base(parent)
            {
            }

            public override void Init(NiecHelperSituation parent)
            {
                return;
            }

            public override void CleanUp()
            {
                return;
            }
            
        }
    }
}
