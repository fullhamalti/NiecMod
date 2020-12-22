using System;
using System.Collections.Generic;
using System.Text;

using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.ObjectComponents;
using Sims3.Gameplay.Objects.Vehicles;
using Sims3.Gameplay.Routing;

using Sims3.SimIFace;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Visa;

namespace NiecMod.Nra
{
    internal sealed class NGetInVehicleRouteAction : GetInVehicleRouteAction
    {
        private static object OV = null;
        private static bool dontCall = false;

        public static void InitNCreate()
        {
            if ((OV as NGetInVehicleRouteAction) != null)
                return;

            OV = new NGetInVehicleRouteAction();
        }

        public static NGetInVehicleRouteAction GetStatic()
        {
            InitNCreate();
            return (NGetInVehicleRouteAction)OV;
        }

        public static void InitClass()
        {
            var p = GetStatic();
            dontCall = true;
            p.NM_PerformAction();
            dontCall = false;
        }

        ////////////////

        public static Vehicle Vehicle_CreateTaxiBicycle(bool simChildren)
        {
            if (simChildren)
            {
                var childTaxiBicycle = (ChildTaxiBicycle)GlobalFunctions.CreateObjectOutOfWorld
                    ("BicycleChildStreet", "Sims3.Gameplay.Objects.Vehicles.ChildTaxiBicycle", null);

                if (childTaxiBicycle != null)
                {
                    childTaxiBicycle.DestroyOnRelease = true;
                }
                return childTaxiBicycle;
            }
            else
            {
                var adultTaxiBicycle = (AdultTaxiBicycle)GlobalFunctions.CreateObjectOutOfWorld
                    ("BicycleAdultStreet", "Sims3.Gameplay.Objects.Vehicles.AdultTaxiBicycle", null);

                if (adultTaxiBicycle != null)
                {
                    adultTaxiBicycle.DestroyOnRelease = true;
                }
                return adultTaxiBicycle;
            }
        }

        public static Vehicle Sim_GetVehicle(Sim ths, Lot lot, bool allowUFO)
        {
            if (ths.IsPet)
                return null;

            var vehicleForCurrentInteraction = ths.GetVehicleForCurrentInteraction();
            if (vehicleForCurrentInteraction != null && !(vehicleForCurrentInteraction is Boat))
            {
                return vehicleForCurrentInteraction;
            }

            bool child = ths.Posture == null || !ths.Posture.Satisfies(CommodityKind.CarryingChild, null);
            bool canDrive = ths.CanDriveOrCallTaxi();

            if (canDrive && 
                !Vehicle.WorldHasSpecialCarRules(GameUtils.GetCurrentWorld()) 

                && (!(ths.SimRoutingComponent != null && ths.SimRoutingComponent.AllowBikes) 

                || (ths.Autonomy != null 
                && ths.Autonomy.SituationComponent != null 
                && ths.Autonomy.SituationComponent.InSituationOfType(typeof(GoHereWithSituation)))

                || ths.CurrentInteraction is TravelUtil.SitInCarToTriggerTravel 
                || ths.CurrentInteraction is TravelUtil.SitInCarToReturnHomeWithinHomeWorld))
            {
                child = false;
            }

            Vehicle vehicle = null;
            vehicle = ths.GetOwnedAndUsableVehicle(lot, true, child && !ths.IsHoldingAnything(), !GameUtils.IsInstalled(ProductVersion.EP4), allowUFO);

            if (vehicle == null || vehicle.HasBeenDestroyed)
            {
                if (canDrive)
                {
                    if (ths.SimDescription == null)
                        return null;

                    if (child)
                    {
                        vehicle = Vehicle_CreateTaxiBicycle(ths.SimDescription.Child);
                    }
                    else if (ths.SimDescription.CanDrive && ths.IsHoldingAnything())
                    {
                        IGameObject gameObject = (!GameUtils.IsInstalled(ProductVersion.EP11) ||
                            GameUtils.GetCurrentWorld() != WorldName.FutureWorld) ?
                            GlobalFunctions.CreateObjectOutOfWorld(RandomUtil.CoinFlip() ?
                            "CarUsed2" : "CarSedan", ProductVersion.BaseGame, null, null) 
                            : GlobalFunctions.CreateObjectOutOfWorld(RandomUtil.CoinFlip() ? "HoverCarUsed" 
                            : "HoverCarExpensive", ProductVersion.EP11, null, null);

                        CarOwnable carOwnable = gameObject as CarOwnable;
                        if (carOwnable != null)
                        {
                            Lot lotHome = ths.LotHome;
                            Household household = ths.Household;

                            if (lotHome != null && household != null && !household.IsServiceNpcHousehold)
                            {
                                int cost = carOwnable.Cost;
                                if (ths.FamilyFunds >= cost)
                                {
                                    ths.ModifyFunds(-cost);
                                }
                                else
                                {
                                    household.UnpaidBills += cost;
                                }
                            }

                            carOwnable.GeneratedOwnableForNpc = (lotHome == null);
                            carOwnable.DestroyOnRelease = (lotHome == null);
                            carOwnable.LotHome = lotHome;

                            vehicle = carOwnable;
                        }
                        else if (gameObject != null)
                        {
                            gameObject.Destroy();
                            vehicle = null;
                        }
                    }
                    else
                    {
                        try
                        {
                            if (CarNpcManager.Singleton == null)
                            {
                                throw new NullReferenceException("CarNpcManager.Singleton == null");
                            }
                            vehicle = CarNpcManager.Singleton.CreateNpcCar(CarNpcManager.NpcCars.Taxi);
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch (Exception) { }
                    }
                }
                else
                {
                    if (ths.IsHoldingAnything())
                    {
                        return null;
                    }
                    vehicle = Vehicle_CreateTaxiBicycle(ths.SimDescription.Child);
                }
            }

            if (vehicle == null || vehicle.HasBeenDestroyed)
            {
                if (child && !ths.IsHoldingAnything() && ths.SimDescription != null)
                {
                    vehicle = Vehicle_CreateTaxiBicycle(ths.SimDescription.Child);
                }
                else if (CarNpcManager.Singleton != null)
                {
                    vehicle = CarNpcManager.Singleton.CreateNpcCar(CarNpcManager.NpcCars.Taxi);
                }
            }
            return vehicle;
        }

        public ActionResult NM_PerformAction()
        {
            if (dontCall)
                return ActionResult.Continue;

            Vehicle vehicle = null;

            try
            {
                var simRoutingComponentx = mRoutingSim.SimRoutingComponent;

                mRoutingSim.PopHoverboardPostureIfNecessary();

                simRoutingComponentx.DisallowBeingPushed = true;
                simRoutingComponentx.TriggerOnCarSequenceStartedEvent();

                if (mRoutingSim.HasExitReason((ExitReason)mOriginalRoute.ExitReasonsInterrupt))
                {
                    AddFailureExplanation(FailureExplanation.CancelledByScript);
                    return ActionResult.Terminate;
                }

                Lot lot = (mOriginalRoute == null) ? mRoutingSim.LotCurrent : LotManager.GetLotAtPoint(mOriginalRoute.GetOriginalStartPoint());
                vehicle = Sim_GetVehicle(mRoutingSim, lot, GameUtils.IsInstalled(ProductVersion.EP8));
                if (vehicle == null || vehicle.HasBeenDestroyed)
                {
                    AddFailureExplanation(FailureExplanation.VehicleSequenceFailure);
                    return ActionResult.Terminate;
                }


                mOriginalRoute.SetOption(Route.RouteOption.EnableUFOPlanning, vehicle is CarUFO);
                Household household = mRoutingSim.Household;
                if (household != null)
                {
                    CarOwnable carOwnable = vehicle as CarOwnable;
                    if (carOwnable != null && carOwnable.GeneratedOwnableForNpc)
                    {
                        Lot lotHome = household.LotHome;
                        if (lotHome != null)
                        {
                            int cost = carOwnable.Cost;
                            if (household.FamilyFunds >= cost)
                            {
                                household.ModifyFamilyFunds(-cost);
                            }
                            else
                            {
                                household.UnpaidBills += cost;
                            }
                            carOwnable.GeneratedOwnableForNpc = (lotHome == null);
                            carOwnable.DestroyOnRelease = (lotHome == null);
                            carOwnable.LotHome = lotHome;
                        }
                    }
                }


                Vector3 pt;
                mOriginalRoute.GetSegmentStartPoint(0u, out pt);
                Vector3 dir;
                mOriginalRoute.GetSegmentStartDirection(0u, out dir);

                ItemComponent itemComp = vehicle.ItemComp;
                if (itemComp != null && itemComp.InventoryParent != null)
                {
                    itemComp.InventoryParent.RemoveByForce(vehicle);
                }

                vehicle.PlaceAt(pt, dir, mRoutingSim);

                if (vehicle is Bicycle && mRoutingSim.Posture.Satisfies(CommodityKind.CarryingObject, null))
                {
                    InteractionInstance standingTransition = mRoutingSim.Posture.GetStandingTransition();
                    if (standingTransition != null)
                    {
                        standingTransition.RunInteraction();
                    }
                }

                if (GameUtils.IsInstalled(ProductVersion.EP9))
                {
                    mRoutingSim.PopBackpackPostureIfNecessary();
                    if (mRoutingSim.SimDescription.IsPlantSim)
                    {
                        (mRoutingSim.RoutingComponent as SimRoutingComponent).StopPlantSimRoutingVFX();
                    }
                }

                mRoutingSim.PopJetpackPostureIfNecessary();
                mRoutingSim.FadeOut(true, 0.5f, null);

                if (vehicle.Driver == null)
                {
                    vehicle.PutInDriver(mRoutingSim);
                }
                else
                {
                    vehicle.PutInPassenger(mRoutingSim);
                }

                mRoutingSim.FadeIn(true, 0.5f);

                var objectInRightHand = mRoutingSim.GetObjectInRightHand();
                if (objectInRightHand != null && !(objectInRightHand is Sim))
                {
                    objectInRightHand.SetHiddenFlags(HiddenFlags.Model);
                }

                simRoutingComponentx.ClearPush();

                var followSubPathRouteAction = new VehicleFollowSubPathRouteAction(vehicle, mOriginalRoute);
                followSubPathRouteAction.AssociatedSim = mRoutingSim;

                mRoutingSim.RoutingComponent.InsertRouteActionAfter(this, followSubPathRouteAction);

                return ActionResult.Continue;
            }
            catch
            {
                if (vehicle != null && vehicle.DestroyOnRelease)
                {
                    vehicle.Destroy();
                }
                throw;
            }
            finally
            {
                mRoutingSim.SimRoutingComponent.DisallowBeingPushed = false;
            }
        }
    }

    internal sealed class NGetInBoatRouteAction : GetInBoatRouteAction
    {
        private static object OV = null;
        private static bool dontCall = false;

        public static void InitNCreate()
        {
            if ((OV as NGetInBoatRouteAction) != null)
                return;

            OV = new NGetInBoatRouteAction();
        }

        public static NGetInBoatRouteAction GetStatic()
        {
            InitNCreate();
            return (NGetInBoatRouteAction)OV;
        }

        public static void InitClass()
        {
            var p = GetStatic();
            dontCall = true;
            p.NM_PerformAction();
            dontCall = false;
        }

        public static Boat Sim_GetBoatForGetInBoatRouteAction(Sim ths, Lot lot)
        {
            bool disallowedOnlyTemporary = false;
            if (ths.GetObjectInRightHand() == null && ths.InteractionQueue != null)
            {
                LeaderGoHereWith leaderGoHereWith = ths.InteractionQueue.RunningInteraction as LeaderGoHereWith;
                List<Sim> followers = null;

                if (leaderGoHereWith != null)
                {
                    GoHereWithSituation situation = leaderGoHereWith.Situation;
                    if (situation != null)
                    {
                        followers = situation.Followers;
                    }
                }

                var ttt = ths.GetOwnedAndUsableBoat(lot, true, followers, ref disallowedOnlyTemporary);
                if (ttt != null)
                    return ttt;
            }
            return Vehicle.CreateTaxiBoat();
        }

        public ActionResult NM_PerformAction()
        {
            if (dontCall)
                return ActionResult.Continue;

            Boat boat = null;
            try
            {
                mRoutingSim.SimRoutingComponent.DisallowBeingPushed = true;

                if (mRoutingSim.HasExitReason((ExitReason)mOriginalRoute.ExitReasonsInterrupt))
                {
                    AddFailureExplanation(FailureExplanation.CancelledByScript);
                    return ActionResult.Terminate;
                }

                Lot lot = (mOriginalRoute == null) ? mRoutingSim.LotCurrent : LotManager.GetLotAtPoint(mOriginalRoute.GetOriginalStartPoint());
                boat = Sim_GetBoatForGetInBoatRouteAction(mRoutingSim, lot); 
                if (boat == null)
                {
                    AddFailureExplanation(FailureExplanation.VehicleSequenceFailure);
                    return ActionResult.Terminate;
                }

                mLastFoundBoatId = boat.ObjectId;
                Vector3 pt;
                mOriginalRoute.GetSegmentStartPoint(0u, out pt);
                Vector3 dir;
                mOriginalRoute.GetSegmentStartDirection(0u, out dir);

                mBoatAppearingPt = pt;

                mnReplanFrequency = RandomUtil.GetInt(SimRoutingComponent.AvoidanceReplanCheckFrequencyMin, SimRoutingComponent.AvoidanceReplanCheckFrequencyMax);
                mnReplanOffset = RandomUtil.GetInt(SimRoutingComponent.AvoidanceReplanCheckOffsetMin, SimRoutingComponent.AvoidanceReplanCheckOffsetMax);

                StandAndWaitController standAndWaitController = new StandAndWaitController();
                standAndWaitController.AllowZeroCycle = true;
                standAndWaitController.Duration = SimRoutingComponent.DefaultStandAndWaitDuration;
                standAndWaitController.OnCycle = base.StandAndWaitCycleHandler;
                standAndWaitController.Run(mRoutingSim);

                if (mStandAndWaitResult == ActionResult.Terminate)
                {
                    if (mLastFoundObstruction.IsValid && mOriginalRoute.DoRouteFail)
                    {
                        mRoutingSim.SimRoutingComponent.PlayRouteFailureIfAppropriate(mLastFoundObstruction.ObjectFromId<GameObject>());
                    }
                    return mStandAndWaitResult;
                }

                if (mStandAndWaitResult == ActionResult.ContinueAndFollowPath)
                {
                    return mStandAndWaitResult;
                }

                ItemComponent itemComp = boat.ItemComp;
                if (itemComp != null && itemComp.InventoryParent != null)
                {
                    itemComp.InventoryParent.RemoveByForce(boat);
                }

                MooringPost mooringPost = boat.Parent as MooringPost;
                if (mooringPost != null)
                {
                    mooringPost.UnReserveSpot(boat);
                }

                boat.PlaceAt(pt, dir, mRoutingSim);

                BoatRoutingComponent boatRoutingComponent = boat.RoutingComponent as BoatRoutingComponent;
                if (boatRoutingComponent != null)
                {
                    boatRoutingComponent.ForceUpdateDynamicFootprint();
                    boatRoutingComponent.EnableDynamicFootprint();
                }

                mRoutingSim.FadeOut(true, 0.5f, null);

                if (!boat.HaveSimWaitBeforeGettingIn(mRoutingSim))
                {
                    mRoutingSim.FadeIn(false, 0f);
                    return ActionResult.Terminate;
                }

                boat.SimIsGettingIn = true;

                if (boat.Driver == null)
                {
                    boat.PutInDriver(mRoutingSim);
                }
                else
                {
                    boat.PutInPassenger(mRoutingSim);
                }

                boat.SimIsGettingIn = false;

                if (!(boat is BoatTaxi))
                {
                    mRoutingSim.FadeIn(true, 0.5f);
                }

                GameObject objectInRightHand = mRoutingSim.GetObjectInRightHand();
                if (objectInRightHand != null && !(objectInRightHand is Sim))
                {
                    objectInRightHand.SetHiddenFlags(HiddenFlags.Model);
                }

                mRoutingSim.SimRoutingComponent.ClearPush();

                mOriginalRoute.FollowerAgeGenderSpecies = (uint)boat.GetBoatSpecies();
                mOriginalRoute.Follower = boat.Proxy;
                mOriginalRoute.SetOption2(Route.RouteOption2.BeginAsBoat, true);
                mOriginalRoute.SetOption2(Route.RouteOption2.UseFollowerStartOrientation, boat.UsesTurnHelperFootprint());
                mOriginalRoute.SetOption(Route.RouteOption.RouteAsGhost, false);

                return ActionResult.ContinueAndPopPathAndReplan;
            }
            catch
            {
                if (boat != null && boat.DestroyOnRelease)
                {
                    boat.Destroy();
                }
                throw;
            }
            finally
            {
                mRoutingSim.SimRoutingComponent.DisallowBeingPushed = false;
            }
        }
    }
}
