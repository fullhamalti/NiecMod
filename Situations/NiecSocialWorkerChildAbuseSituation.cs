// New Claas 13:21 26/08/2019 :)
namespace Sims3.Gameplay.NiecRoot
{
    #region Using Directives
    using System;
    using Sims3.Gameplay;
    using Sims3.Gameplay.ActiveCareer.ActiveCareers;
    using Sims3.Gameplay.Actors;
    using Sims3.Gameplay.ActorSystems;
    using Sims3.Gameplay.ActorSystems.Children;
    using Sims3.Gameplay.Autonomy;
    using Sims3.Gameplay.CAS;
    using Sims3.Gameplay.CelebritySystem;
    using Sims3.Gameplay.Core;
    using Sims3.Gameplay.EventSystem;
    using Sims3.Gameplay.Interactions;
    using Sims3.Gameplay.Moving;
    using Sims3.Gameplay.Objects.Vehicles;
    using Sims3.Gameplay.PetSystems;
    using Sims3.Gameplay.Services;
    using Sims3.Gameplay.ThoughtBalloons;
    using Sims3.Gameplay.Utilities;
    using Sims3.SimIFace;
    using Sims3.UI;
    using System.Collections.Generic;
    using Sims3.Gameplay.Abstracts;
    using NiecMod.KillNiec;
    using NiecMod.Nra;
    using Sims3.NiecModList.Persistable;
    using Sims3.Gameplay.Objects.Island;
    using Sims3.NiecHelp.Tasks;
    using NiecMod.Interactions;
    #endregion
    
    public class NiecSocialWorkerChildAbuseSituation : RootSituation
    {

        public AlarmHandle mInitAlarm;

        internal static bool ___bOpenDGSIsInstalled_ = AssemblyCheckByNiec.IsInstalled("OpenDGS");

        public bool NeedDestroyWorker = false;

        public global:: Sims3.Gameplay.Services.ServiceSituation.ServiceCleanupBehavior mCleanupBehavior;

        public static List<Sim> GetTeenOrAboveSimsFromHousehold(Household household)
        {
            List<Sim> list = new List<Sim>();
            if (household != null)
            {
                bool isactive = household.IsActive;
                foreach (Sim sim in NFinalizeDeath.Household_GetAllActors(household)) //household.Sims)
                {
                    SimDescription simDescription = sim.SimDescription;
                    if ((!isactive || sim.IsSelectable) && simDescription != null && simDescription.IsHuman && simDescription.TeenOrAbove && (simDescription.DeathStyle == SimDescription.DeathType.None || simDescription.IsPlayableGhost))
                    {
                        list.Add(sim);
                    }
                }
            }
            return list;
        }

        public bool _Unsafe = false;

        public Household TargetHousehold;

        public Sim Worker;



        /// <summary>
        /// Create Niec Social Worker Child Abuse Situation
        /// </summary>
        /// <param name="currentlot"></param>
        /// <param name="workersim"></param>
        /// <param name="addSituationlist"></param>
        /// <param name="bUnSafe"></param>
        /// <returns>default</returns>
        /// <exception cref="ArgumentNullException">CurrentLot or WorkerSim is null.</exception>
        /// <exception cref="ArgumentException">WorkerSim is invalid.</exception>
        /// <exception cref="NullReferenceException"></exception>
        public static NiecSocialWorkerChildAbuseSituation Create(Lot currentLot, Sim workerSim, bool addSituationlist, bool bUnSafe)
        {
            if (workerSim == null)
                throw new ArgumentNullException("workerSim");
            if (workerSim.SimDescription == null || workerSim.HasBeenDestroyed)
                throw new ArgumentException("workerSim can't be invalid", "workerSim");


            if (currentLot == null)
            //  currentlot = LotManager.GetWorldLot();
                throw new ArgumentNullException("currentLot");

            //Household household = currentLot.Household;
            if (addSituationlist)
            {
                if (currentLot.Household == null || currentLot.Household.mMembers == null)
                    throw new ArgumentException("currentLot.Household: None", "currentLot");
                else if (currentLot.IsWorldLot)
                    throw new ArgumentException("currentLot is World Lot", "currentLot");
                else {

                    bool foundChildOrPet = false;

                    foreach (Sim simDesc in NFinalizeDeath.Household_GetAllActors(currentLot.Household)) { //currentLot.Household.AllActors) {
                        if (simDesc == null || simDesc.SimDescription == null) 
                            continue;
                        if (simDesc.IsPet || simDesc.SimDescription.ChildOrBelow)
                        {
                            foundChildOrPet = true;
                            break;
                        }
                    }

                    if (!foundChildOrPet) 
                        throw new ArgumentException("currentLot.Household is not child or pet", "currentLot");
                }
                
            }

            NiecSocialWorkerChildAbuseSituation niecSWChildASituation = new NiecSocialWorkerChildAbuseSituation(currentLot, workerSim);

            if (niecSWChildASituation == null)
                throw new NullReferenceException("niecSWChildASituation == null");

            if (addSituationlist)
            {
                if (!workerSim.Autonomy.SituationComponent.Situations.Contains(niecSWChildASituation))
                    workerSim.Autonomy.SituationComponent.Situations.Add(niecSWChildASituation);

                workerSim.AddToWorld();
                workerSim.FadeIn();

                if (niecSWChildASituation.Init(currentLot, bUnSafe))
                {
                    niecSWChildASituation.SetState(new WaitToRoute(niecSWChildASituation));
                }
                else
                {
                    niecSWChildASituation.Exit();

                    if (niecSWChildASituation.mSocialWorkerVehicle != null)
                        niecSWChildASituation.mSocialWorkerVehicle.Destroy();

                    niecSWChildASituation.mSocialWorkerVehicle = null;

                    workerSim.Autonomy.SituationComponent.Situations.Remove(niecSWChildASituation);
                    return null;
                }
            }

            return niecSWChildASituation;
        }



        // Methods
        public NiecSocialWorkerChildAbuseSituation()
        { }

        public NiecSocialWorkerChildAbuseSituation(Lot lot, Sim worker)
            : base(lot)
        {
            
            Worker = worker;
            mSocialWorkerVehicle = CarNpcManager.Singleton.CreateServiceCar(ServiceType.SocialWorkerChildProtection);
            
        }











        ////////////////////////////////////////////////////////////////

        public CarService mSocialWorkerVehicle;

        public CarService SocialWorkerCar
        {
            get
            {
                return mSocialWorkerVehicle;
            }
            set
            {
                mSocialWorkerVehicle = value;
            }
        }


        public bool IsAdultSimOnLot(GameObject gameObject)
        {
            Sim sim = gameObject as Sim;
            if (sim != null && sim.Household != null)
            {
                SimDescription simDescription = sim.SimDescription;
                if (sim.HouseholdOwnsResidentialLot(Lot) && simDescription.YoungAdultOrAbove && simDescription.IsHuman && (simDescription.DeathStyle == SimDescription.DeathType.None || simDescription.IsPlayableGhost))
                {
                    return sim.LotCurrent == Lot;
                }
            }
            return false;
        }

        public bool IsAdultSimInHouse(GameObject gameObject)
        {
            if (!gameObject.IsOutside)
            {
                return IsAdultSimOnLot(gameObject);
            }
            return false;
        }

        [Persistable]
        public class DestroySimsHelper
        {
            public List<Sim> mSimsToDestroy;

            public DestroySimsHelper()
            {
            }

            public DestroySimsHelper(List<Sim> sims)
            {
                if (sims != null)
                    mSimsToDestroy = new List<Sim>(sims);
            }

            public virtual void DeleteSims()
            {
                if (mSimsToDestroy == null)
                {
                    return;
                }

                foreach (var item in mSimsToDestroy)
                {

                    

                    if (item == null)
                        continue;
                    
                    SimDescription simd = item.SimDescription;
                    if (simd == null)
                        continue;

                    Autonomy auton = item.Autonomy;
                    if (auton == null) 
                        continue;
                    if (simd.LotHome == null)
                        continue;
                    if (item.LotCurrent == simd.LotHome)
                        continue;

                    item.SetObjectToReset();

                    if (auton.Motives != null)
                        auton.Motives.MaxEverything();

                    Vector3 pos; //= Vector3.OutOfWorld;
                    Vector3 fwd; //= Vector3.OutOfWorld;


                    try
                    {
                        if (item.AttemptToFindSafeLocation(true, out pos, out fwd))
                        {

                            item.SetPosition(pos);
                            item.SetForward(fwd);

                            if (item.SimRoutingComponent != null)
                                item.SimRoutingComponent.ForceUpdateDynamicFootprint();

                            SpeedTrap.Sleep(0);

                            if (item.LotCurrent == item.LotHome)
                                continue;
                        }
                    }
                    catch (Exception)
                    {
                        if (item.LotCurrent == item.LotHome)
                            continue;
                    }

                    if (item.LotHome == null)
                        continue;

                    Mailbox mailbox = item.LotHome.FindMailbox();
                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(mailbox != null ? mailbox.Position : item.LotHome.Position);
                    fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0xF);
                    fglParams.BooleanConstraints = FindGoodLocationBooleans.None;



                    if (!GlobalFunctions.FindGoodLocation(item, fglParams, out pos, out fwd))
                    {
                        SpeedTrap.Sleep(0);
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

                /*
                List<Sim>.Enumerator enumerator = mSimsToDestroy.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Sim current = enumerator.Current;
                    if (current == null)
                    {
                        continue;
                    }
                    if (current.IsPet)
                    {
                        SimDescription simDescription = current.SimDescription;
                        if (simDescription != null && simDescription.IsPregnant)
                        {
                            simDescription.Dispose();
                        }
                    }
                    if (!current.HasBeenDestroyed)
                    {
                        current.FadeOut();
                        current.Destroy();
                    }
                    mSimsToDestroy.Remove(current);
                    enumerator = mSimsToDestroy.GetEnumerator();
                }*/

               
            }
        }

        public abstract class TakeBabyOrToddlerAway : Interaction<Sim, Sim>
        {
            public abstract class TakeBabyOrToddlerAwayDefinition<T> : InteractionDefinition<Sim, Sim, T> where T : TakeBabyOrToddlerAway, new()
            {}

            public OneShotFunction mOneShotBabyToddlerDetonator;

            public abstract bool RouteToKid();

            public override bool Run()
            {
                InteractionInstance entry = ForceKidToIdle.Singleton.CreateInstance(Target, Target, new InteractionPriority(InteractionPriorityLevel.High), false, false);
                if (entry == null) return false;
                Target.InteractionQueue.Add(entry);
                if (!RouteToKid())
                {
                    return false;
                }
                BeginCommodityUpdates();
                Target.FadeOut();
                EndCommodityUpdates(true);
                if (Target.Parent != null)
                {
                    Target.Parent.SetObjectToReset();
                }
                mOneShotBabyToddlerDetonator = new OneShotFunction(CaptureKid);
                Simulator.AddObject(mOneShotBabyToddlerDetonator);
                return true;
            }

            public void CaptureKid()
            {
                //Target.Destroy();
                mOneShotBabyToddlerDetonator = null;
            }
        }

        public sealed class ForceKidToIdle : Interaction<Sim, Sim>
        {
            [DoesntRequireTuning]
            public sealed class Definition : InteractionDefinition<Sim, Sim, ForceKidToIdle>
            {
                public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair iop)
                {
                    return Localization.LocalizeString(actor.IsFemale, "Gameplay/Services/SocialWorkerChildAbuseSituation:Idle");
                }

                public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    return a == target;
                }
            }

            public static readonly InteractionDefinition Singleton = new Definition();

            public override bool Run()
            {
                Actor.LoopIdle();
                Simulator.Sleep(1000);
                return true;
            }
        }

        public sealed class RouteAndTakeKidAway : TakeBabyOrToddlerAway
        {
            public sealed class Definition : TakeBabyOrToddlerAwayDefinition<RouteAndTakeKidAway>
            {
                public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    return true;
                }
            }

            public static readonly InteractionDefinition Singleton = new Definition();

            public override bool RouteToKid()
            {
                Route route = Actor.CreateRoute();
                route.PlanToPointRadius(Target, Target.Position, 0.7f, RouteOrientationPreference.TowardsObject, Target.LotCurrent.LotId, new int[1]
			    {
				    Target.RoomId
			    });
                route.DoRouteFail = false;
                return Actor.DoRoute(route);
            }
        }

        public sealed class TeleportAndTakeKidAway : TakeBabyOrToddlerAway
        {
            public sealed class Definition : TakeBabyOrToddlerAwayDefinition<TeleportAndTakeKidAway>
            {
                public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    return true;
                }
            }

            public static readonly InteractionDefinition Singleton = new Definition();

            public override bool RouteToKid()
            {
                FindGoodLocationBooleans booleanConstraints = FindGoodLocationBooleans.StayInRoom | FindGoodLocationBooleans.PreferEmptyTiles | FindGoodLocationBooleans.Routable;
                return SocialWorkerSituation.TeleportActorToObject(Actor, Target, booleanConstraints);
            }
        }

        public sealed class TakeChildAway : Interaction<Sim, Sim>
        {
            public sealed class Definition : InteractionDefinition<Sim, Sim, TakeChildAway>
            {
                public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    return true;
                }
            }

            public static readonly InteractionDefinition Singleton = new Definition();

            public override bool Run()
            {
                BeginCommodityUpdates();
                ThoughtBalloonManager.BalloonData bd = new ThoughtBalloonManager.BalloonData(Target.GetThoughtBalloonThumbnailKey());
                Actor.ThoughtBalloonManager.ShowBalloon(bd);
                if (Actor.IsStandingIdle)
                {
                    EnterStateMachine("social_callOver", "Enter", "x");
                    AnimateSim("Exit");
                }

                if (___bOpenDGSIsInstalled_ || !NiecHelperSituation.__acorewIsnstalled__)
                    Target.InteractionQueue.CancelAllInteractions();
                else
                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);

                Target.PlayReaction(ReactionTypes.Cry, ReactionSpeed.Immediate);
                EndCommodityUpdates(true);
                return true;
            }
        }

        public class RouteActorCloseToVehicle : Interaction<Sim, CarService>
        {
            [DoesntRequireTuning]
            public class Definition : InteractionDefinition<Sim, CarService, RouteActorCloseToVehicle>
            {
                public bool IsLargeVehicle;

                public Definition()
                {
                }

                public Definition(bool isLargeVehicle)
                {
                    IsLargeVehicle = isLargeVehicle;
                }

                public override string GetInteractionName(Sim a, CarService target, InteractionObjectPair interaction)
                {
                    return LocalizeString("RouteToCar");
                }

                public override bool Test(Sim a, CarService target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    return true;
                }
            }

            public const string sLocalizationKey = "Gameplay/Services/SocialWorkerChildAbuseSituation/RouteActorCloseToVehicle";

            [TunableComment("Range: floats > 0. Distance to route around vehicle when putting a pet up for adoption, for non horses.")]
            [Tunable]
            public static float kSocialWorkerVehicleRoutingDistance = 3f;

            [Tunable]
            [TunableComment("Range: floats > 0. Distance to route around vehicle when putting a pet up for adoption, for horses.")]
            public static float kSocialWorkerVehicleRoutingDistanceForHorse = 5f;

            public static readonly InteractionDefinition Singleton = new Definition();

            public static string LocalizeString(string name, params object[] parameters)
            {
                return Localization.LocalizeString("Gameplay/Services/SocialWorkerChildAbuseSituation/RouteActorCloseToVehicle:" + name, parameters);
            }

            public override bool Run()
            {
                float radius = (base.InteractionDefinition as Definition).IsLargeVehicle ? kSocialWorkerVehicleRoutingDistanceForHorse : kSocialWorkerVehicleRoutingDistance;
                if (!Actor.RouteToObjectRadius(Target, radius))
                {
                    return SocialWorkerSituation.TeleportActorToObject(Actor, Target, FindGoodLocationBooleans.PreferEmptyTiles | FindGoodLocationBooleans.Routable);
                }
                return true;
            }
        }

        public class WaitToRoute : ChildSituation<NiecSocialWorkerChildAbuseSituation>
        {
            public AlarmHandle mAlarmHandle;

            public WaitToRoute()
            {
            }

            public WaitToRoute(NiecSocialWorkerChildAbuseSituation parent)
                : base(parent)
            {
            }

            public override void Init(NiecSocialWorkerChildAbuseSituation parent)
            {
                if (parent.mSimsToCollect != null)
                {
                    foreach (Sim item in parent.mSimsToCollect)
                    {
                        if (item == null || item.mSimDescription == null)
                            continue;

                        if (item.LotCurrent != Lot && item.InteractionQueue != null)
                        {
                            bool isSelectable = item.IsSelectable;
                            var entry = GoHome.Singleton.CreateInstance
                                (item.LotHome, item, new InteractionPriority(InteractionPriorityLevel.MaxDeath), isSelectable, isSelectable);
                            item.InteractionQueue.Add(entry);
                        }

                        if (item.BuffManager != null)
                            item.BuffManager.RemoveAllElements();
                        if (item.SocialComponent != null)
                            item.SocialComponent.ClearAllRelationshipInteractionBits();

                        //if (item.SimDescription.AgingState != null)
                        //{
                        //    item.SimDescription.AgingState.DeathTransitionStarted();
                        //}
                    }
                }
                if (parent.Worker.LotCurrent != Lot)
                {
                    mAlarmHandle = base.AlarmManager.AddAlarm(3, TimeUnit.Minutes, TimeToRoute, "Social Worker waiting to route", AlarmType.AlwaysPersisted, parent.Worker);
                }
                else
                {
                    Parent.SetState(new RouteToLot(Parent));
                }
            }

            public void TimeToRoute()
            {
                try
                {
                    Parent.SetState(new RouteToLot(Parent));
                }
                catch (ResetException)
                { throw; }
                catch
                {
                    foreach (Sim item in Parent.mSimsToCollect)
                    {
                        if (item == null) continue;
                        Static_MoveSimDescriptionToNewHousehold(Parent.TargetHousehold, item.SimDescription, true);
                    }
                    Parent.SetState(new Leave(Parent));
                }
                
            }

            public override void CleanUp()
            {
                base.AlarmManager.RemoveAlarm(mAlarmHandle);
                base.CleanUp();
            }
        }

        public  class RouteToLot : ChildSituation<NiecSocialWorkerChildAbuseSituation>
        {
            public const string sLocalizationKey = "Gameplay/Services/SocialWorkerChildAbuseSituation/RouteToLot";

            public const int kAttemptsToRouteToLot = 3;

            public const string kYellAtSocialKey = "Social Worker Yell At";

            public int mAttemptsToRouteToLot;

            public static string LocalizeString(string name, params object[] parameters)
            {
                return Localization.LocalizeString(sLocalizationKey + name, parameters);
            }

            public RouteToLot()
            {
            }

            public RouteToLot(NiecSocialWorkerChildAbuseSituation parent)
                : base(parent)
            {
            }

            public override void Init(NiecSocialWorkerChildAbuseSituation parent)
            {
                Sim worker = parent.Worker;
                //parent.OnServiceStarting();
                if (worker == null || worker.SocialComponent == null)
                    return;

                if (worker.mLotCurrent == null)
                {
                    worker.mLotCurrent = LotManager.GetWorldLot();
                }

                worker.SocialComponent.OnlyAllowedSocial = kYellAtSocialKey;
                worker.EnableSocialsOnSim();

                if (parent.Worker.LotCurrent != Lot)
                {
                    bool bStartOffscreen = worker.SimDescription.VirtualLotHome == null;
                    ForceSituationSpecificInteraction(Lot, worker, new DriveToLotInServiceCar.Definition(Parent.mSocialWorkerVehicle, bStartOffscreen, true), null, OnRoute, OnRouteFailed);
                }
                else
                {
                    ScoldAdultAndStartGrabbingKids(parent);
                }
            }

            public override void CleanUp()
            {
                Sim worker = Parent.Worker;
                if (worker != null)
                {
                    worker.DisableSocialsOnSim();
                    if (worker.SocialComponent != null)
                        worker.SocialComponent.OnlyAllowedSocial = null;
                }
                base.CleanUp();
            }

            public void OnSocialPassOrFail(Sim actor, float x)
            {
                DaycareWorkdaySituation daycareWorkdaySituationForLot = DaycareWorkdaySituation.GetDaycareWorkdaySituationForLot(Lot);
                if (daycareWorkdaySituationForLot != null)
                {
                    daycareWorkdaySituationForLot.Daycare.TriggerSuspension(true);
                }
                if (Parent.mTakeHousholdKids || Parent.mTakeHouseholdPets)
                {
                    Parent.Worker.SimDescription.ShowSocialsOnSim = false;
                    Parent.SetState(new GrabKidsRegularRouting(Parent, Parent.mSimsToCollect[0]));
                }
                else
                {
                    Parent.SetState(new Leave(Parent));
                }
            }

            public void OnRoute(Sim actor, float x)
            {
                ScoldAdultAndStartGrabbingKids(Parent);
            }

            public void OnRouteFailed(Sim actor, float x)
            {
                if (actor.LotCurrent == Lot)
                {
                    OnRoute(actor, x);
                    return;
                }
                if (mAttemptsToRouteToLot < 3)
                {
                    mAttemptsToRouteToLot++;
                    Init(Parent);
                    return;
                }
                if (Parent.TargetHousehold == Household.ActiveHousehold)
                {
                    List<Sim> teenOrAbove = GetTeenOrAboveSimsFromHousehold(Parent.TargetHousehold);
                    bool householdIsActive = Parent.TargetHousehold != null && Parent.TargetHousehold.IsActive;

                    if (teenOrAbove.Count > 0)
                    {
                        if (householdIsActive)
                        {
                            if (teenOrAbove[0] != null)
                                PlumbBob.SelectActor(teenOrAbove[0]);

                            DaycareWorkdaySituation daycareWorkdaySituationForLot = DaycareWorkdaySituation.GetDaycareWorkdaySituationForLot(Lot);
                            DisplayScoldTNS(daycareWorkdaySituationForLot);
                        }
                        TriggerCollection(actor);
                    }
                    else if (householdIsActive)
                    {
                        PlumbBob.ForceSelectActor(null);
                        bool o = NiecMod.Helpers.Create.CreateActiveHouseholdAndActiveActor(null, false) != null;
                        if (!o && PlumbBob.SelectedActor == null)
                        {
                            GameOverScenario(Parent);
                            
                        }
                        else 
                            TriggerCollection(actor);
                    }
                    else
                        TriggerCollection(actor);
                }

                else 
                    TriggerCollection(actor);

                bool bdNeedDestroyWorker = Parent.NeedDestroyWorker;

                try
                {
                    Exit();

                    Parent.CleanUp();

                    actor.Autonomy.SituationComponent.Situations.Remove(Parent);
                }
                catch (ResetException)
                { throw; }
                catch { }
                

                if (bdNeedDestroyWorker)
                    NFinalizeDeath.ForceDestroyObject(actor);

            }

            public void TriggerCollection(Sim actor)
            {
                if (Parent.mTakeHousholdKids || Parent.mTakeHouseholdPets)
                {
                    ShiftKidsToNewHouseholds(Parent.mSimsToCollect, true);
                    DestroySimsHelper @object = new DestroySimsHelper(Parent.mSimsToCollect);
                    Parent.mSimsToCollect.Clear();
                    OneShotFunction obj = new OneShotFunction(@object.DeleteSims);
                    Simulator.AddObject(obj, false);
                    actor.SimDescription.ShowSocialsOnSim = true;
                }
            }

            public void ScoldNotify(string scoldLocalizedString)
            {
                if (Camera.CameraTargetWithInLot(Parent.Lot))
                {
                    StyledNotification.Format format = new StyledNotification.Format(scoldLocalizedString, Parent.Worker.ObjectId, StyledNotification.NotificationStyle.kSimTalking);
                    StyledNotification.Show(format);
                }
                else
                {
                    Camera.CameraNotification.ShowNotificationAndFocusOnSim(Parent.Worker.ObjectId, scoldLocalizedString, Parent.Worker);
                }
            }

            public static void _createTaskFadnIn(Sim actor, int sleep)
            {
               
                NiecTask.Perform(delegate
                {
                    for (int i = 0; i < sleep; i++)
                    {
                        Simulator.Sleep(0);
                    }
                    while (!actor.InWorld)
                        Simulator.Sleep(0);
                    actor.AddToWorld();
                    actor.FadeIn();
                });
            }


            public void ScoldAdultAndStartGrabbingKids(NiecSocialWorkerChildAbuseSituation parent)
            {
                if (parent.VerifyChildren())
                {
                    DaycareWorkdaySituation 
                        daycareWorkdaySituation = parent.mTargetedSimPickup ? null : DaycareWorkdaySituation.GetDaycareWorkdaySituationForLot(Lot);

                    List<Sim> teenOrAboveSimsFromHousehold = GetTeenOrAboveSimsFromHousehold(parent.TargetHousehold);

                    Household TargetHousehold_ = parent.TargetHousehold;
                    bool TargetHouseholdIsActive = TargetHousehold_ != null && TargetHousehold_ == Household.ActiveHousehold;

                    if (TargetHouseholdIsActive)
                    {
                        Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Normal, Sims3.Gameplay.Gameflow.SetGameSpeedContext.Gameplay);
                        Audio.StartSound("sting_social_worker_arrive");

                        if (teenOrAboveSimsFromHousehold.Count > 0 && !Parent.mIgnoreNegativeFactors)
                        {
                            DisplayScoldTNS(daycareWorkdaySituation);
                        }
                    }

                    if (TryScoldingAdultsThenCarryBusiness(parent))
                    {
                        return;
                    }

                    Sim kid = parent.mSimsToCollect[0];
                    if (TargetHouseholdIsActive && !parent.mTargetedSimPickup)
                    {
                        teenOrAboveSimsFromHousehold.Clear();
                        if (parent.TargetHousehold != null)
                        {
                            teenOrAboveSimsFromHousehold = GetTeenOrAboveSimsFromHousehold(parent.TargetHousehold);
                        }
                        if (teenOrAboveSimsFromHousehold.Count <= 0)
                        {
                            PlumbBob.ForceSelectActor(null);
                            bool o = NiecMod.Helpers.Create.CreateActiveHouseholdAndActiveActor(null, false) != null;
                            SpeedTrap.Sleep(0);
                            if (!o && PlumbBob.SelectedActor == null)
                            {
                                Sim WoSim = parent.Worker;

                                bool bdNeedDestroyWorker = parent.NeedDestroyWorker;

                                WoSim.FadeOut();

                                if (!bdNeedDestroyWorker)
                                    _createTaskFadnIn(WoSim, 500);

                                try
                                {
                                    GameOverScenario(parent);

                                    parent.CleanUp();

                                    Exit();

                                    WoSim.Autonomy.SituationComponent.Situations.Remove(parent);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch { }



                                if (bdNeedDestroyWorker)
                                    NFinalizeDeath.ForceDestroyObject(WoSim);


                                parent.Worker = null;


                                return;
                            }
                        }
                        else
                        {
                            var p = RandomUtil.GetRandomObjectFromList(teenOrAboveSimsFromHousehold, ListCollon.SafeRandomPart2);
                            if (p == null)
                            {
                                NiecMod.Helpers.Create.CreateActiveHouseholdAndActiveActor(null, false);
                            }
                            else if (!PlumbBob.SelectActor(p) && PlumbBob.SelectedActor == null)
                            {
                                NFinalizeDeath.TestSetActiveActor(p, true);
                            }
                        }
                    }

                    if (daycareWorkdaySituation != null)
                    {
                        daycareWorkdaySituation.Daycare.TriggerSuspension(TargetHouseholdIsActive);
                    }

                    if (Parent.mTakeHousholdKids || Parent.mTakeHouseholdPets)
                    {
                        ShiftKidsToNewHouseholds(parent.mSimsToCollect, true);
                        Parent.SetState(new GrabKidsRegularRouting(parent, kid));
                    }
                    else
                    {
                        Parent.SetState(new Leave(parent));
                    }
                }
                else
                {
                    Parent.SetState(new Leave(Parent));
                }
            }

            public void DisplayScoldTNS(DaycareWorkdaySituation daycareSituation)
            {
                if (Parent.mTakeHousholdKids)
                {
                    ScoldNotify(LocalizeString("TreatedPoor"));
                }
                if (daycareSituation != null && daycareSituation.Daycare.OwnerDescription != null)
                {
                    ScoldNotify(LocalizeString("TreatedPoorDaycare", daycareSituation.Daycare.OwnerDescription));
                    if (!Parent.mTakeHousholdKids && Parent.mChildAndBelowSims.Count > 0)
                    {
                        ScoldNotify(LocalizeString("TreatedPoorDaycare_HouseholdKidsWarning", daycareSituation.Daycare.OwnerDescription));
                    }
                }
                if (Parent.mTakeHouseholdPets)
                {
                    ScoldNotify(LocalizeString("TreatedPoorPet"));
                }
            }

            //public bool sleep = false;

            public void GameOverScenario(NiecSocialWorkerChildAbuseSituation parent)
            {
                //sleep = false;

                if (GameStates.IsOnVacation)
                    GameStates.sOldActiveHousehold = Household.ActiveHousehold;
                
                string titleText = LocalizeString("GameOverTitle");
                string messageText = LocalizeString("GameOverMessage");

                if (GameUtils.IsInstalled(ProductVersion.EP5))
                {
                    messageText = LocalizeString("GameOverMessagePetsandKids");
                }

                SimpleMessageDialog.Show(titleText, messageText, ModalDialog.PauseMode.PauseSimulator);

                
                if (Parent.mTakeHousholdKids || Parent.mTakeHouseholdPets)
                {
                    ShiftKidsToNewHouseholds(parent.mSimsToCollect, false);

                }

                try
                { MovingSituation.CleanUpLotForMoveOut(Parent.Lot);}
                catch (ResetException)
                { throw; }
                catch { }
                

                //ServiceSituation.sGotoFamilySelectionReason = global:: Sims3.Gameplay.Services.ServiceSituation.FamilySelectionReason.SocialWorker;

                Parent.mCleanupBehavior = Sims3.Gameplay.Services.ServiceSituation.ServiceCleanupBehavior.GameEntry;

                


                NiecTask.Perform(delegate
                {
                    while (PlumbBob.SelectedActor != null || UIManager.GetModalWindow() != null)
                    {
                        Simulator.Sleep(0);
                    }

                    if (GameStates.IsLiveState && PlumbBob.SelectedActor == null)
                        GameStates.TransitionToPlayFlow();

                    DestroyAllRepossedChildren(parent.mSimsToCollect);


                });

                
            }

            public Sim GetAdultToScold()
            {
                Sim result = null;
                DaycareWorkdaySituation daycareWorkdaySituationForLot = DaycareWorkdaySituation.GetDaycareWorkdaySituationForLot(Lot);
                if (!Parent.mTargetedSimPickup && daycareWorkdaySituationForLot != null && daycareWorkdaySituationForLot.Daycare.OwnerDescription != null)
                {
                    result = daycareWorkdaySituationForLot.Daycare.OwnerDescription.CreatedSim;
                }
                else
                {
                    List<Sim> objects = Lot.GetObjects<Sim>(Parent.IsAdultSimOnLot);
                    if (objects.Count > 0)
                    {
                        result = RandomUtil.GetRandomObjectFromList(objects);
                    }
                }
                return result;
            }

            public bool TryScoldingAdultsThenCarryBusiness(NiecSocialWorkerChildAbuseSituation parent)
            {
                Sim adultToScold = GetAdultToScold();
                if (adultToScold == null)
                {
                    return false;
                }

                if (parent.mIgnoreNegativeFactors)
                {
                    ShiftKidsToNewHouseholds(parent.mSimsToCollect, true);
                    OnSocialPassOrFail(parent.Worker, 0f);
                    return true;
                }

                if (adultToScold.IsSelectable && Sim.ActiveActor != adultToScold)
                {
                    if (!PlumbBob.SelectActor(adultToScold) && PlumbBob.SelectedActor == null)
                    {
                        NFinalizeDeath.TestSetActiveActor(adultToScold, true);
                    }
                }

                if (Parent.mTakeHousholdKids || Parent.mTakeHouseholdPets)
                {
                    ShiftKidsToNewHouseholds(parent.mSimsToCollect, true);
                }

                if (adultToScold.HasBeenDestroyed)
                {
                    adultToScold = GetAdultToScold();
                    if (adultToScold == null)
                    {
                        return false;
                    }
                }

                InteractionDefinition i = new SituationSocial.Definition("Social Worker Yell At", new string[0], null, false);
                ForceSituationSpecificInteraction(adultToScold, Parent.Worker, i, null, OnSocialPassOrFail, OnSocialPassOrFail, InteractionPriorityLevel.MaxDeath);
                return true;
            }

            public void ShiftKidsToNewHouseholds(List<Sim> listOfKidsInHousehold, bool adultsOnLot)
            {
                foreach (Sim item in listOfKidsInHousehold)
                {
                    //if (item.IsUnicorn && item.Household != null && Parent. _Unsafe)
                    //{
                        /*
                        if (adultsOnLot)
                        {
                            item.InteractionQueue.CancelAllInteractions();
                            while (!item.InteractionQueue.IsInteractionQueueEmpty())
                            {
                                Simulator.Sleep(0u);
                            }
                            OccultUnicorn.UnicornReturnToWild unicornReturnToWild = OccultUnicorn.UnicornReturnToWild.Singleton.CreateInstance(item, item, new InteractionPriority(InteractionPriorityLevel.MaxDeath), false, false) as OccultUnicorn.UnicornReturnToWild;
                            unicornReturnToWild.ForceDueToAbuse = false;
                            item.InteractionQueue.Add(unicornReturnToWild);
                        }*/
                        // else
                        //{
                           // OccultUnicorn.UnicornReturnToWild.ExecuteReturnToWild(item, false, null, null);
                        //}
                    //}
                    //else
                    {
                        try
                        {
                            Parent.MoveSimDescriptionToNewHousehold(item.SimDescription);
                        }
                        catch (ResetException)
                        { throw; }
                        catch { }
                       
                    }
                }
                try
                {
                    if (!Parent.mIgnoreNegativeFactors)
                    {
                        //if (Parent.TargetHousehold == Household.ActiveHousehold)
                        if (Parent.TargetHousehold != null)
                        {
                            // List<Sim> teenOrAboveSimsFromHousehold = GetTeenOrAboveSimsFromHousehold(Parent.TargetHousehold);
                            foreach (Sim item2 in Parent.TargetHousehold.Sims)
                            {
                                if (Parent.mTakeHousholdKids)
                                {
                                    item2.SocialComponent.SetHasTreatedKidsPoorly();
                                }
                                if (Parent.mTakeHouseholdPets)
                                {
                                    item2.SocialComponent.SetHasTreatedPetsPoorly();
                                }
                            }
                        }
                    }
                }
                catch (ResetException)
                { throw; }
                catch { }
                
            }

            public void DestroyAllRepossedChildren(List<Sim> listOfKidsInHousehold)
            {
                foreach (Sim item in listOfKidsInHousehold)
                {
                    //item.Destroy();
                    if (item == null)
                        continue;

                    SimDescription simd = item.SimDescription;
                    if (simd == null)
                        continue;

                    Autonomy auton = item.Autonomy;
                    if (auton == null)
                        continue;
                    if (simd.LotHome == null)
                        continue;
                    if (item.LotCurrent == simd.LotHome)
                        continue;

                    item.SetObjectToReset();

                    if (auton.Motives != null)
                        auton.Motives.MaxEverything();

                    Vector3 pos; 
                    Vector3 fwd; 


                    try
                    {
                        if (item.AttemptToFindSafeLocation(true, out pos, out fwd))
                        {

                            item.SetPosition(pos);
                            item.SetForward(fwd);

                            if (item.SimRoutingComponent != null)
                                item.SimRoutingComponent.ForceUpdateDynamicFootprint();

                            SpeedTrap.Sleep(0);

                            if (item.LotCurrent == item.LotHome)
                                continue;
                        }
                    }
                    catch (Exception)
                    {
                        if (item.LotCurrent == item.LotHome)
                            continue;
                    }

                    Mailbox mailbox = item.LotHome.FindMailbox();
                    World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(mailbox != null ? mailbox.Position : item.LotHome.Position);
                    fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0xF);
                    fglParams.BooleanConstraints = FindGoodLocationBooleans.None;



                    if (!GlobalFunctions.FindGoodLocation(item, fglParams, out pos, out fwd))
                    {
                        SpeedTrap.Sleep(0);
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
            }
        }

        public class GrabKidsRegularRouting : ChildSituation<NiecSocialWorkerChildAbuseSituation>
        {
            public Sim mKid;

            public AlarmHandle mTriggerDelayedKidnaping;

            public GrabKidsRegularRouting()
            {
            }

            public GrabKidsRegularRouting(NiecSocialWorkerChildAbuseSituation parent)
                : this(parent, null)
            {
            }

            public GrabKidsRegularRouting(NiecSocialWorkerChildAbuseSituation parent, Sim kid)
                : base(parent)
            {
                mKid = kid;
            }

            public override void Init(NiecSocialWorkerChildAbuseSituation parent)
            {
                if (mKid == null && Parent.mSimsToCollect.Count > 0)
                {
                    mKid = Parent.mSimsToCollect[0];
                }
                if (mKid != null && Parent.IsADependent(mKid.SimDescription) && !mKid.HasBeenDestroyed)
                {
                    if (mKid.IsHuman)
                    {
                        Household TargetHousehold_ = parent.TargetHousehold;
                        if (TargetHousehold_ != null)
                        {
                            foreach (Sim sim in TargetHousehold_.Sims)
                            {
                                if (sim.SimDescription.YoungAdultOrAbove)
                                {
                                    DisgracefulActionEvent e = new DisgracefulActionEvent(EventTypeId.kSimCommittedDisgracefulAction, sim, mKid, DisgracefulActionType.ChildTaken);
                                    EventTracker.SendEvent(e);
                                }
                            }
                        }
                    }
                    if (Parent.ShouldRouteToCollect(mKid.SimDescription))
                    {
                        ForceSituationSpecificInteraction(mKid, parent.Worker, RouteAndTakeKidAway.Singleton, null, CheckIfAllKidsArePicked, GrabWithUberRouting, InteractionPriorityLevel.NonCriticalNPCBehavior);
                    }
                    else
                    {
                        ForceSituationSpecificInteraction(mKid, parent.Worker, TakeChildAway.Singleton, null, MoveChildCloseToServiceVehicle, MoveChildCloseToServiceVehicle, InteractionPriorityLevel.CriticalNPCBehavior);
                    }
                }
                else if (mKid != null)
                {
                    CheckIfAllKidsArePicked(mKid, 0f);
                }
                else
                {
                    Parent.SetState(new Leave(Parent));
                }
            }

            public override void CleanUp()
            {
                base.AlarmManager.RemoveAlarm(mTriggerDelayedKidnaping);
                base.CleanUp();
            }

            public void MoveChildCloseToServiceVehicle(Sim s, float x)
            {
                InteractionDefinition i = new RouteActorCloseToVehicle.Definition(mKid.IsHorse);
                ForceSituationSpecificInteraction(Parent.SocialWorkerCar, mKid, i, null, GetChildIntoServiceVehicle, GetChildIntoServiceVehicle, InteractionPriorityLevel.High);
            }

            public void GetChildIntoServiceVehicle(Sim s, float x)
            {
                if (s.IsHorse)
                {
                    //s.DisableAutonomousInteractions();
                    //s.FadeOut();
                    //s.RemoveFromWorld();
                    CheckIfAllKidsArePicked(s, x);
                }
                else
                {
                    ForceSituationSpecificInteraction(Parent.SocialWorkerCar, mKid, GetInCarPassenger.Singleton, null, CheckIfAllKidsArePicked, CheckIfAllKidsArePicked, InteractionPriorityLevel.High);
                }
            }

            public void CheckIfAllKidsArePicked(Sim s, float x)
            {
                Parent.mSimsToCollect.Remove(mKid);
                if (!Parent.ShouldRouteToCollect(mKid.SimDescription) && !mKid.HasBeenDestroyed)
                {
                    Parent.mKidsToBeDestroyed.Add(mKid);
                }
                Parent.SetState(new GrabKidsRegularRouting(Parent));
            }

            public void GrabWithUberRouting(Sim s, float x)
            {
                mTriggerDelayedKidnaping = base.AlarmManager.AddAlarm(1f, TimeUnit.Minutes, DoneDoneOnToTheNextOne, "Social Worker transitioning to GrabKidsWhileRoutingThrough", AlarmType.AlwaysPersisted, Parent.Worker);
            }

            public void DoneDoneOnToTheNextOne()
            {
                Parent.SetState(new GrabKidsWhileRoutingThrough(Parent, mKid));
            }
        }

        public class Leave : ChildSituation<NiecSocialWorkerChildAbuseSituation>
        {
            public const string kSocialWorkerLeaveSound = "sting_sad_things";

            public Leave()
            {
            }

            public Leave(NiecSocialWorkerChildAbuseSituation parent)
                : base(parent)
            {
            }

            public override void Init(NiecSocialWorkerChildAbuseSituation parent)
            {
                //parent.ChargeForService(OnServiceDone);
                OnServiceDone(parent.Worker, 0);
            }

            public void OnServiceDone(Sim actor, float x)
            {
                Sim worker = Parent.Worker;
                LotManager.SetAutoGameSpeed(ServiceType.SocialWorkerChildProtection);
                ForceSituationSpecificInteraction(Parent.mSocialWorkerVehicle, worker, RouteActorCloseToVehicle.Singleton, null, OnRouteToVehicle, OnRouteToVehicle);
            }

            public void createTaskFadnIn(Sim actor, int sleep)
            {
                if (Parent.NeedDestroyWorker) return;
                NiecTask.Perform(delegate
                {
                    for (int i = 0; i < sleep; i++)
                    {
                        Simulator.Sleep(0);
                    }
                    while (!actor.InWorld)
                        Simulator.Sleep(0);
                    actor.AddToWorld();
                    actor.FadeIn();
                });
            }

            public void OnRouteToVehicle(Sim actor, float x)
            {
                Audio.StartSound(kSocialWorkerLeaveSound);
                createTaskFadnIn(actor, 700);
                ForceSituationSpecificInteraction(Lot, actor, new NInteractionsClass.SafeDriveAwayInServiceCar.Definition(Parent.mSocialWorkerVehicle), null, OnRouteOrFail, OnRouteOrFail);
            }

            public void OnRouteOrFail(Sim actor, float x)
            {
                actor.FadeOut();
                createTaskFadnIn(actor, 150);
                if (Parent.mTakeHousholdKids)
                {
                    Parent.GatherPlaceholderKids();
                }
                DestroySimsHelper @object = new DestroySimsHelper(Parent.mKidsToBeDestroyed);
                Parent.mKidsToBeDestroyed.Clear();
                OneShotFunction obj = new OneShotFunction(@object.DeleteSims);
                Simulator.AddObject(obj, false);
                actor.SimDescription.ShowSocialsOnSim = true;
                actor.FadeOut();
                NiecTask.Perform(delegate
                {
                    
                    for (int i = 0; i < 10; i++)
                    {
                        Simulator.Sleep(15);
                    }
                    Parent.CleanUp();
                    Exit();
                    if (Parent.NeedDestroyWorker)
                        NFinalizeDeath.ForceDestroyObject(actor);
                    else
                    {
                        actor.Autonomy.SituationComponent.Situations.Remove(Parent);
                        actor.FadeIn();
                    }
                });
            }
        }

        public class GrabKidsWhileRoutingThrough : ChildSituation<NiecSocialWorkerChildAbuseSituation>
        {
            public Sim mKid;

            public AlarmHandle mTriggerDelayedKidnaping;

            public GrabKidsWhileRoutingThrough()
            {
            }

            public GrabKidsWhileRoutingThrough(NiecSocialWorkerChildAbuseSituation parent, Sim kid)
                : base(parent)
            {
                mKid = kid;
            }

            public override void Init(NiecSocialWorkerChildAbuseSituation parent)
            {
                //SocialWorkerChildAbuse socialWorkerChildAbuse = Parent.Service as SocialWorkerChildAbuse;
                //if (socialWorkerChildAbuse != null)
                {
                    //socialWorkerChildAbuse.NeedsSpecialRouting = true;
                    ForceSituationSpecificInteraction(mKid, parent.Worker, RouteAndTakeKidAway.Singleton, null, CheckIfThereAreMoreKids, SetUpUltraUberTeleporting, InteractionPriorityLevel.NonCriticalNPCBehavior);
                }
            }

            public void CheckIfThereAreMoreKids(Sim actor, float x)
            {
                Parent.mSimsToCollect.Remove(mKid);
                Parent.SetState(new GrabKidsRegularRouting(Parent));
            }

            public void SetUpUltraUberTeleporting(Sim actor, float x)
            {
                mTriggerDelayedKidnaping = base.AlarmManager.AddAlarm(1f, TimeUnit.Minutes, DoneDoneOnToTheNextOne, "Social Worker transitioning to GrabKidsWhileTeleporting", AlarmType.AlwaysPersisted, Parent.Worker);
            }

            public void DoneDoneOnToTheNextOne()
            {
                Parent.SetState(new GrabKidsWhileTeleporting(Parent, mKid));
            }

            public override void CleanUp()
            {
                /*
                SocialWorkerChildAbuse socialWorkerChildAbuse = Parent.Service as SocialWorkerChildAbuse;
                if (socialWorkerChildAbuse != null)
                {
                    socialWorkerChildAbuse.NeedsSpecialRouting = false;
                }*/
                base.AlarmManager.RemoveAlarm(mTriggerDelayedKidnaping);
                base.CleanUp();
            }
        }

        public class GrabKidsWhileTeleporting : ChildSituation<NiecSocialWorkerChildAbuseSituation>
        {
            public Sim mKid;

            public AlarmHandle mTriggerDelayedKidnaping;

            public GrabKidsWhileTeleporting()
            {
            }

            public GrabKidsWhileTeleporting(NiecSocialWorkerChildAbuseSituation parent, Sim kid)
                : base(parent)
            {
                mKid = kid;
            }

            public override void Init(NiecSocialWorkerChildAbuseSituation parent)
            {
                ForceSituationSpecificInteraction(mKid, parent.Worker, TeleportAndTakeKidAway.Singleton, null, CheckIfThereAreMoreKids, AddToListOfFailedSims, InteractionPriorityLevel.NonCriticalNPCBehavior);
            }

            public override void CleanUp()
            {
                base.AlarmManager.RemoveAlarm(mTriggerDelayedKidnaping);
                base.CleanUp();
            }

            public void CheckIfThereAreMoreKids(Sim actor, float x)
            {
                Parent.mSimsToCollect.Remove(mKid);
                TransitionState();
            }

            public void AddToListOfFailedSims(Sim s, float x)
            {
                Parent.mSimsToCollect.Remove(mKid);
                if (!mKid.HasBeenDestroyed)
                {
                    Parent.mKidsToBeDestroyed.Add(mKid);
                }
                TransitionState();
            }

            public void TransitionState()
            {
                mTriggerDelayedKidnaping = base.AlarmManager.AddAlarm(1f, TimeUnit.Minutes, DoneDoneOnToTheNextOne, "Social Worker delaying next kid grab", AlarmType.AlwaysPersisted, Parent.Worker);
            }

            public void DoneDoneOnToTheNextOne()
            {
                Parent.SetState(new GrabKidsRegularRouting(Parent));
            }
        }

        public List<Sim> mChildAndBelowSims = new List<Sim>();

        public List<Sim> mPetSims = new List<Sim>();

        public List<Sim> mSimsToCollect = new List<Sim>();

        public List<Sim> mKidsToBeDestroyed = new List<Sim>();

        public List<SimDescription> mKidsWhoWereMoved = new List<SimDescription>();

        public bool mTakeHousholdKids;

        public bool mTakeHouseholdPets;

        public bool mTargetedSimPickup;

        public bool mIgnoreNegativeFactors;

        public bool mSaveDisabled;

        public bool SaveDisabled
        {
            get
            {
                return mSaveDisabled;
            }
        }





        public virtual bool TargetedInit(Lot lot, List<ObjectGuid> guidsToPickup)
        {
            if (guidsToPickup == null || guidsToPickup.Count == 0)
            {
                return false;
            }
            foreach (ObjectGuid item in guidsToPickup)
            {
                Sim sim = item.ObjectFromId<Sim>();
                if (sim != null)
                {
                    mSimsToCollect.Add(sim);
                    mChildAndBelowSims.Add(sim);
                }
            }
            if (mSimsToCollect.Count == 0)
            {
                return false;
            }
            mTargetedSimPickup = true;
            mIgnoreNegativeFactors = true;
            mTakeHousholdKids = true;
            return true;
        }

        public virtual bool Init(Lot lot, bool Unsafe)
        {
            //try
            {
                
                if (lot == null) 
                    return false;

                Household household = lot.Household;
                if (household == null)
                {
                    return false;
                }

                TargetHousehold = household;
                if (!Unsafe && (household == NFinalizeDeath.ActiveHousehold || household == Household.ActiveHousehold)) 
                    return false;
                _Unsafe = Unsafe;
                DaycareWorkdaySituation daycareWorkdaySituationForLot = DaycareWorkdaySituation.GetDaycareWorkdaySituationForLot(lot);
                if (daycareWorkdaySituationForLot != null)
                {
                    mTakeHousholdKids = false;
                }
                //bool flag = GetTeenOrAboveSimsFromHousehold(lot.Household).Count <= 0;

                //if (household.AllActors != null)
                {
                    foreach (Sim allActor in NFinalizeDeath.Household_GetAllActors(household)) //household.AllActors)
                    {
                        SimDescription simd = allActor.SimDescription;
                        if (simd == null) 
                            continue;
                        if (simd.IsPet)// && !allActor.IsInActiveHousehold)
                        {
                            if (!Unsafe && NFinalizeDeath.IsAllActiveHousehold_SimObject(allActor)) 
                                continue;
                            mPetSims.Add(allActor);
                            if (!mTakeHouseholdPets)
                            {
                                mTakeHouseholdPets = true;
                            }
                        }
                        else if (simd.ChildOrBelow)// && !NFinalizeDeath.IsAllActiveHousehold_SimObject(allActor))
                        {
                            if (!Unsafe && NFinalizeDeath.IsAllActiveHousehold_SimObject(allActor)) 
                                continue;
                            mChildAndBelowSims.Add(allActor);
                            if (!mTakeHousholdKids)
                            {
                                mTakeHousholdKids = true;
                            }
                        }
                    }
                }
                if (mChildAndBelowSims.Count <= 0)
                {
                    if (household.NumActorMembersCountingPregnancy != 0)
                    {
                        GatherPlaceholderKids();
                    }
                    if (daycareWorkdaySituationForLot == null)
                    {
                        if (!mTakeHouseholdPets)
                        {
                            return false;
                        }
                        mTakeHousholdKids = false;
                    }
                }
                if (mTakeHousholdKids)
                {
                    mSimsToCollect.AddRange(mChildAndBelowSims);
                }
                if (mTakeHouseholdPets)
                {
                    
                    foreach (Sim mPetSim in mPetSims)
                    {
                        if (mPetSim.SimDescription != null && mPetSim.SimDescription.IsHorse)
                        {
                            if (SocialWorkerCar != null)
                            {
                                SocialWorkerCar.Destroy();
                                SocialWorkerCar = null;
                            }
                            SocialWorkerCar = (GlobalFunctions.CreateObjectOutOfWorld("carBusHorse", ProductVersion.EP5, null, null) as CarService);
                            break;
                        }
                    }
                    mSimsToCollect.AddRange(mPetSims);
                }
                mSimsToCollect.Sort(CompareSimsToCollect);
                if (household.Sims != null)
                {
                    if (daycareWorkdaySituationForLot != null && daycareWorkdaySituationForLot.Daycare.OwnerSim != null)
                    {
                        List<Sim> list = new List<Sim>(daycareWorkdaySituationForLot.ChildSims);
                        if (mTakeHousholdKids)
                        {
                            list.AddRange(mChildAndBelowSims);
                            AddNegligentBuffWithSimList(daycareWorkdaySituationForLot.Daycare.OwnerSim, list);
                        }
                    }
                    foreach (Sim sim in NFinalizeDeath.Household_GetAllActors(household)) //household.Sims)
                    {
                        if (sim.SimDescription != null && (NiecHelperSituation.__acorewIsnstalled__ || sim.SimDescription.IsHuman && sim.SimDescription.ChildOrAbove))
                        {
                            if (mTakeHousholdKids && (daycareWorkdaySituationForLot == null || daycareWorkdaySituationForLot.Daycare.OwnerSim != sim))
                            {
                                AddNegligentBuffWithSimList(sim, mChildAndBelowSims);
                            }
                            if (mTakeHouseholdPets)
                            {
                                AddNegligentBuffWithPetList(sim, mPetSims);
                            }
                        }
                    }
                }


                if (AlarmManager != null)
                mInitAlarm = AlarmManager.AddAlarm(10, TimeUnit.Hours, delegate
                {
                    if (AlarmManager != null)
                        AlarmManager.RemoveAlarm(mInitAlarm);

                    mInitAlarm = AlarmHandle.kInvalidHandle;

                    if (Worker == null || 
                        Worker.mSimDescription == null ||
                        !NFinalizeDeath.GameObjectIsValid(Worker.ObjectId.mValue) ||
                        Worker.GetSituationOfType<NiecSocialWorkerChildAbuseSituation>() == null) return;

                    CleanUp();
                    Exit();

                    Worker.Autonomy.SituationComponent.Situations.Remove(this);
                    Worker.SetObjectToReset();
                }, null, AlarmType.AlwaysPersisted, Worker);

                NiecTask.Perform(OnTick);
                Worker.FlagSet(Sim.SimFlags.IgnoreDoorLocks, true);

                return true;
            }
            //catch (NullReferenceException)
            //{
            //    return false;
            //}
        }

        public virtual void OnTick() {
            SimDescription WorkerSimDesc = Worker.SimDescription;
            while (true) {
                Simulator.Sleep(0); // SpeedTrap.Sleep();
                if (Worker ==null|| Worker.InteractionQueue == null || WorkerSimDesc == null || Worker.HasBeenDestroyed || Worker.GetSituationOfType<NiecSocialWorkerChildAbuseSituation>() == null)
                { break; }
                if (WorkerSimDesc.LotHome != null) 
                    continue;
                foreach (var item in Worker.InteractionQueue.mInteractionList.ToArray())
                {
                    if (item is Sim.GoToVirtualHome || item is Sim.GoToVirtualHome.GoToVirtualHomeInternal)
                    {
                        //Worker.AddExitReason(ExitReason.Default);
                        Worker.InteractionQueue.mInteractionList.Remove(item);
                    }
                }
            }
        }


        public void AddNegligentBuffWithSimList(Sim adult, IEnumerable<Sim> children)
        {
            BuffNegligent.BuffInstanceNegligent buffInstanceNegligent = null;
            if (adult.BuffManager != null)
            {
                adult.BuffManager.AddElement(BuffNames.Negligent, Origin.FromNeglectingChildren);
                buffInstanceNegligent = adult.BuffManager.GetElement(BuffNames.Negligent) as BuffNegligent.BuffInstanceNegligent;
            }
            if (buffInstanceNegligent != null)
            {
                foreach (Sim child in children)
                {
                    if (child.mSimDescription == null)
                        continue;
                    buffInstanceNegligent.MissedSims.Add(child.mSimDescription);
                }
            }
        }

        public void AddNegligentBuffWithPetList(Sim adult, IEnumerable<Sim> pets)
        {
            BuffNegligent.BuffInstanceNegligent buffInstanceNegligent = null;
            if (adult.BuffManager != null)
            {
                adult.BuffManager.AddElement(BuffNames.PetNegligent, Origin.FromNeglectingPets);
                buffInstanceNegligent = adult.BuffManager.GetElement(BuffNames.PetNegligent) as BuffNegligent.BuffInstanceNegligent;
            }
            if (buffInstanceNegligent != null)
            {
                foreach (Sim pet in pets)
                {
                    if (pet.mSimDescription == null)
                        continue;
                    buffInstanceNegligent.MissedSims.Add(pet.mSimDescription);
                }
            }
        }

        public override void CleanUp()
        {
            if (AlarmManager != null)
                AlarmManager.RemoveAlarm(mInitAlarm);

            mInitAlarm = AlarmHandle.kInvalidHandle;


            if (Worker != null && Worker.SimDescription != null && !Worker.HasBeenDestroyed)
                Worker.FlagSet(Sim.SimFlags.IgnoreDoorLocks, false);
            if (Worker != null && Worker.Autonomy != null)
                Worker.Autonomy.mAutonomyDisabledCount = 0;
            //Worker = null;

            if (mKidsWhoWereMoved != null)
            {
                foreach (SimDescription item in mKidsWhoWereMoved)
                {
                    if (item != null)
                        item.ClearSpecialFlags();
                }
            }
            mKidsWhoWereMoved = null;

            if (mSocialWorkerVehicle != null && (mSocialWorkerVehicle.Passengers == null || mSocialWorkerVehicle.Passengers.Length == 0))
                mSocialWorkerVehicle.Destroy();
            else if (mSocialWorkerVehicle != null)
            {
                CarService car = mSocialWorkerVehicle;
                NiecTask.Perform(delegate
                {
                    Simulator.Sleep(200);
                    if (car != null && !car.HasBeenDestroyed && (car.Passengers == null || car.Passengers.Length == 0))
                        car.Destroy();
                    car = null;
                });
            }

            mSocialWorkerVehicle = null;
            base.CleanUp();
        }

        public  void SetToLeave()
        {
            SetState(new Leave(this));
        }

        public  string NotEnoughFundsMessage()
        {
            return "Gameplay/Services/SocialWorkerChildAbuseSituation:NotEnoughFunds";
        }

        public void AddTargetedSim(Sim toAdd)
        {
            mSimsToCollect.Add(toAdd);
            mChildAndBelowSims.Add(toAdd);
        }

        public virtual void MoveSimDescriptionToNewHousehold(SimDescription sim)
        {
           

            if (sim == null || !sim.IsValidDescription)
                return;

            if (!sim.IsPet && !sim.ChildOrBelow) return;

            bool isNRaasStoryProgressionInstalledOrNRaasOverwatch
                = AssemblyCheckByNiec.IsInstalled("NRaasStoryProgression"); //|| AssemblyCheckByNiec.IsInstalled("NRaasOverwatch");

            mKidsWhoWereMoved.Add(sim);

            Household otherhousehold = null;

            if (sim.Household == TargetHousehold)
            {
                // Custom
                List<Household> templist = new List<Household>();
                foreach (var item in NFinalizeDeath.SC_GetObjects<Household>()) // Don't use Household.sHouseholdList
                {
                    if (item == null || item == TargetHousehold)
                        continue;
                    if (item.IsSpecialHousehold)
                        continue;
                    if (isNRaasStoryProgressionInstalledOrNRaasOverwatch && item.LotHome == null) // Why NRaas
                        continue;
                    templist.Add(item);
                }

                if (templist.Count > 0)
                {
                    otherhousehold = RandomUtil.GetRandomObjectFromList<Household>(templist, ListCollon.SafeRandom);
                    templist.Clear();
                }
                else if (___bOpenDGSIsInstalled_)
                {
                    otherhousehold = Household.Create();
                    otherhousehold.Name = SimUtils.GetRandomFamilyName(WorldName.SunsetValley);

                    //////////////////////////////////////////////////////////////////////////////////////

                    global::NiecMod.Helpers.Create.AutoMoveInLotFromHousehold(otherhousehold);
                }
                else
                {
                    if (Worker.Household != null && !Worker.Household.IsSpecialHousehold) {
                        otherhousehold = Worker.Household;
                    }
                    else
                    {
                        SimUtils.HouseholdCreationSpec householdCreationSpec = SimUtils.HouseholdCreationSpec.MakeTypicalFamily();
                        if (householdCreationSpec.Sims.Count == 8)
                        {
                            householdCreationSpec.Sims.RemoveAt(RandomUtil.GetInt(1, 7, ListCollon.SafeRandom));
                        }
                        try
                        {
                            mSaveDisabled = true;
                            otherhousehold = householdCreationSpec.Instantiate();
                        }
                        finally
                        {
                            mSaveDisabled = false;
                        }
                    }

                    //////////////////////////////////////////////////////////////////////////////////////

                    global::NiecMod.Helpers.Create.AutoMoveInLotFromHousehold(otherhousehold);
                }


                if (otherhousehold == null)
                    goto end;

                Sim createdSim = sim.CreatedSim;
                if (createdSim != null)
                {
                    //if (sim.Household != null)
                    //    sim.Household.Remove(sim);

                    try
                    {
                        createdSim.InteractionQueue.CancelAllInteractions();
                        createdSim.SetObjectToReset();
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }

                    try
                    {
                        // Custom
                        if (createdSim.Inventory != null)
                            NFinalizeDeath._MoveInventoryItemsToAFamilyMember(createdSim, null); 
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch { }


                    SpeedTrap.Sleep(0);
                    createdSim.UpdateBlockTime();

                    /*
                    if (sim.IsPet)
                    {
                        createdSim.DisableInteractions();
                        createdSim.DisableAutonomousInteractions();
                        createdSim.Autonomy.IncrementAutonomyDisabled();
                    }*/
                }
                if (PlumbBob.SelectedActor == createdSim)
                {
                    List<Sim> teenOrAboveSimsFromHousehold = GetTeenOrAboveSimsFromHousehold(TargetHousehold);
                    if (teenOrAboveSimsFromHousehold.Count > 0)
                    {
                        PlumbBob.SelectActor(RandomUtil.GetRandomObjectFromList(teenOrAboveSimsFromHousehold, ListCollon.SafeRandom));
                    }
                }

                //sim.Household.Remove(sim);
                //if (isActive && createdSim != null)
                //{
                //    createdSim.OnBecameUnselectable();
                //    createdSim.DisablePieMenuOnSim = true;
                //}
            }
            end:

            if (sim.IsHuman)
            {
                //if (otherhousehold != null)
                //    otherhousehold.Add(sim);
                NFinalizeDeath.Household_Add(otherhousehold, sim, false);
                EventTracker.SendEvent(EventTypeId.kChildTakenBySocialWorker, null, sim.CreatedSim);
            }
            //else if (!sim.IsGhost && !sim.IsPregnant && !sim.IsUnicorn)
            else
            {
                //PetAdoption.PutPetBackToPool(sim);
                //if (otherhousehold != null)
                //    otherhousehold.Add(sim);
                NFinalizeDeath.Household_Add(otherhousehold, sim, false);
                EventTracker.SendEvent(EventTypeId.kPetTakenBySocialWorker, null, sim.CreatedSim);
            }
        }


        public static void Static_MoveSimDescriptionToNewHousehold(Household TargetHousehold, SimDescription sim, bool needAdultHousehold)
        {
            

            if (sim == null || !sim.IsValidDescription)
                return;

            if (!sim.IsPet && !sim.ChildOrBelow) return;

            bool isNRaasStoryProgressionInstalled = AssemblyCheckByNiec.IsInstalled("NRaasStoryProgression");

            Household otherhousehold = null;


            // Custom
            List<Household> templist = new List<Household>();
            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>()) // Don't use Household.sHouseholdList
            {
                if (item == null || item == TargetHousehold)
                    continue;
                

                if (item.IsSpecialHousehold)
                    continue;
                if (isNRaasStoryProgressionInstalled && item.LotHome == null)
                    continue;


                try
                {
                    if (needAdultHousehold && IsHouseholdOnlyChildOrPet(item.mMembers.mAllSimDescriptions.ToArray()))
                        continue;
                }
                catch (ResetException)
                { throw; }
                catch { NFinalizeDeath.FixAllHouseholdMembers(); continue; }

                templist.Add(item);
            }

            if (templist.Count > 0)
            {
                otherhousehold = RandomUtil.GetRandomObjectFromList<Household>(templist, ListCollon.SafeRandom);
                templist.Clear();
            }
            else if (___bOpenDGSIsInstalled_)
            {
                otherhousehold = Household.Create();
                otherhousehold.Name = sim.mLastName;

                

                //////////////////////////////////////////////////////////////////////////////////////

                global::NiecMod.Helpers.Create.AutoMoveInLotFromHousehold(otherhousehold);

                if (needAdultHousehold)
                {
                    var simDesc = NFinalizeDeath.CreateRandomSimDescription();
                    
                    try
                    {
                        if (simDesc != null)
                        {
                            otherhousehold.Name = simDesc.mLastName;
                            //otherhousehold.Add(simDesc);
                            NFinalizeDeath.Household_Add(otherhousehold, simDesc, true);
                            //simDesc.Instantiate(Vector3.OutOfWorld);
                            NFinalizeDeath.SimDesc_SafeInstantiate(simDesc, NFinalizeDeath.Vector3_OutOfWorld);
                            global::NiecMod.Helpers.Create.ForceSendHomeAllActors(otherhousehold);
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch 
                    { }
                    
                }

            }
            else
            {
                SimUtils.HouseholdCreationSpec householdCreationSpec = SimUtils.HouseholdCreationSpec.MakeTypicalFamily();
                if (householdCreationSpec.Sims.Count == 8)
                {
                    householdCreationSpec.Sims.RemoveAt(RandomUtil.GetInt(1, 7, ListCollon.SafeRandom));
                }
                otherhousehold = householdCreationSpec.Instantiate();

                //////////////////////////////////////////////////////////////////////////////////////

                global::NiecMod.Helpers.Create.AutoMoveInLotFromHousehold(otherhousehold);
            }


            if (otherhousehold == null)
                return;

            Sim createdSim = sim.CreatedSim;
            if (createdSim != null)
            {
                //if (sim.Household != null)
                //    sim.Household.Remove(sim);


                try
                {
                    if (___bOpenDGSIsInstalled_ || !NiecHelperSituation.__acorewIsnstalled__)
                        createdSim.InteractionQueue.CancelAllInteractions();
                    else 
                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(createdSim);
                    createdSim.SetObjectToReset();
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }

                try
                {
                    // Custom
                    if (createdSim.Inventory != null)
                        NFinalizeDeath._MoveInventoryItemsToAFamilyMember(createdSim, null);
                }
                catch (ResetException)
                {
                    throw;
                }
                catch { }


                SpeedTrap.Sleep(0);
                createdSim.UpdateBlockTime();
            }
            if (NFinalizeDeath.ActiveActor == createdSim)
            {
                List<Sim> teenOrAboveSimsFromHousehold = GetTeenOrAboveSimsFromHousehold(TargetHousehold);
                if (teenOrAboveSimsFromHousehold.Count > 0)
                {
                    PlumbBob.SelectActor(RandomUtil.GetRandomObjectFromList(teenOrAboveSimsFromHousehold, ListCollon.SafeRandom));
                }
                else {
                    PlumbBob.ForceSelectActor(null);
                    NiecMod.Helpers.Create.CreateActiveHouseholdAndActiveActor(null, false);
                }
            }

            if (otherhousehold != null)
                NFinalizeDeath.Household_Add(otherhousehold, sim, false);
        }




        public void GatherPlaceholderKids()
        {
            foreach (var childPlaceholder in NFinalizeDeath.SC_GetObjectsOnLot<CaregiverRoutingMonitor.ChildPlaceholder>(Lot))
            {
                if (childPlaceholder.SimDescription != null && childPlaceholder.SimDescription.LotHome == Lot)
                {
                    MoveSimDescriptionToNewHousehold(childPlaceholder.SimDescription);
                    childPlaceholder.Destroy();
                }
            }
        }

        public bool VerifyChildren()
        {
            int i = 0;
            while (i < mChildAndBelowSims.Count)
            {
                Sim sim = mChildAndBelowSims[i];
                if (sim.SimDescription != null && sim.SimDescription.ChildOrBelow)
                {
                    i++;
                }
                else
                {
                    mChildAndBelowSims.RemoveAt(i);
                }
            }
            DaycareWorkdaySituation daycareWorkdaySituationForLot = DaycareWorkdaySituation.GetDaycareWorkdaySituationForLot(Lot);
            if (mChildAndBelowSims.Count == 0)
            {
                mTakeHousholdKids = false;
                if (mTargetedSimPickup || (daycareWorkdaySituationForLot == null && mPetSims.Count <= 0))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsADependent(SimDescription sim)
        {
            if (!sim.IsPet)
            {
                return sim.ChildOrBelow;
            }
            return true;
        }

        public bool ShouldRouteToCollect(SimDescription sim)
        {
            if (sim.IsHuman)
            {
                return sim.ToddlerOrBelow;
            }
            if (sim.ChildOrBelow)
            {
                return !sim.IsHorse;
            }
            return false;
        }

        public int CompareSimsToCollect(Sim x, Sim y)
        {
            bool flag = ShouldRouteToCollect(x.SimDescription);
            bool flag2 = ShouldRouteToCollect(y.SimDescription);
            if (!flag && flag2)
            {
                return 1;
            }
            if (flag && !flag2)
            {
                return -1;
            }
            return 0;
        }

        public bool OnlyPetsCollected()
        {
            foreach (Sim item in mSimsToCollect)
            {
                if (item.SimDescription != null && item.SimDescription.IsHuman)
                {
                    return false;
                }
            }
            return true;
        }

        public static void CheckForAbandonedChildren(Household household) {

            if (household  == null || household.mMembers == null || household.mMembers.mAllSimDescriptions == null) return;

            SimDescription[] householdMembers = household.mMembers.mAllSimDescriptions.ToArray();

            if (IsHouseholdOnlyChildOrPet(householdMembers))
            {
                foreach (var member in householdMembers)
                    Static_MoveSimDescriptionToNewHousehold(household, member, true);

                if (household.NumMembers == 0)
                    NFinalizeDeath.HouseholdCleanse(household, false, true);
            }
        }

        public static bool IsHouseholdOnlyChildOrPet(Household household) {
            SimDescription[] householdMembers = household.mMembers.mAllSimDescriptions.ToArray();
            return OnlySimDescPets(householdMembers) || OnlySimDescChildens(householdMembers);
        }


        public static bool IsHouseholdOnlyChildOrPet(SimDescription[] householdMembers)
        {
            return OnlySimDescPets(householdMembers) || OnlySimDescChildens(householdMembers);

            /*
            bool foundChildOrPet = false;

            foreach (SimDescription simDesc in householdMembers)
            {
                if (simDesc == null)
                    continue;
                if (simDesc.IsPet || simDesc.SimDescription.ChildOrBelow)
                {
                    foundChildOrPet = true;
                    break;
                }
            }

            if (!foundChildOrPet)
                return false;

            */



        }



        public static bool OnlySimDescPets(SimDescription[] simlist)
        {
            foreach (SimDescription member in simlist)
            {
                if (member == null) 
                    continue;

                if (member.IsHuman)
                {
                    return false;
                }
            }
            return true;
        }


        public static bool OnlySimDescChildens(SimDescription[] simlist)
        {
            foreach (SimDescription member in simlist)
            {
                if (member == null) continue;
                if (member.IsHuman && member.TeenOrAbove)
                {
                    return false;
                }
            }
            return true;
        }

        public override void OnParticipantDeleted(Sim participant)
        {
            if (participant == Worker)
            {
                CleanUp();
                Exit();
                try
                {
                    Worker.Autonomy.SituationComponent.Situations.Remove(this);
                    
                }
                catch (ResetException)
                { throw;}
                catch { }
                Worker = null;
            }
        }
    }
}
