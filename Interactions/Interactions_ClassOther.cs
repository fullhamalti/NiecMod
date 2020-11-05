using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Objects.Vehicles;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.Gameplay.Core;
using Sims3.NiecHelp.Tasks;

namespace NiecMod.Interactions
{
    public class NInteractionsClass
    {
















        //  DriveAwayInServiceCar
        public class SafeDriveAwayInServiceCar : Interaction<Sim, Lot>, IPreventSocialization
        {
            public class Definition : InteractionDefinition<Sim, Lot, SafeDriveAwayInServiceCar>, IUsableDuringFire
            {
                public CarService Car;

                public Definition()
                {}

                public Definition(CarService carService)
                { Car = carService; }

                public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    return InteractionTestResult.Pass;
                }

                public override bool Test(Sim a, Lot target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
                {
                    return true;
                }
            }

            public override bool Run()
            {
                CarService car = ((Definition)base.InteractionDefinition).Car;
                try
                {
                    if (!Actor.HasBeenDestroyed)
                    {
                        bool Ok;
                        if (car != null)
                        {
                            Ok = CarNpcManager.Singleton.DriveAwayInNpcCar(car, Actor, Target);
                            if (Ok)
                            {
                                car.GetOut(Actor);
                            }
                            if (Actor.SimDescription.VirtualLotHome != null)
                            {
                                Sim.MakeSimGoHome(Actor, false);
                                return true;
                            }
                            if (!Ok)
                            {
                                Ok = WalkOffLot();
                            }
                        }
                        else
                        {
                            if (Actor.SimDescription.VirtualLotHome != null)
                            {
                                Sim.MakeSimGoHome(Actor, false);
                                return true;
                            }
                            Ok = WalkOffLot();
                        }
                        return Ok;
                    }
                    return false;
                }
                finally
                {
                    NiecTask.Perform(delegate {
                        
                        if (car == null || car.Passengers == null) 
                            return;
                        car.GetOut(Actor);
                        Actor.FadeOut();
                        Sim[] copypa = (Sim[])car.Passengers.Clone();
                        
                        foreach (var item in copypa)
                        {
                            if (item == null) 
                                continue;
                            //item.AddToWorld();
                            //item.FadeIn();
                            car.GetOut(item);
                            item.FadeOut();
                        } 

                        Simulator.Sleep(100);

                        foreach (var item in copypa)
                        {
                            if (item == null)
                                continue;
                            item.AddToWorld();
                            item.FadeIn();
                        } 

                        if (car != null)
                        {
                            car.Destroy();
                        }
                        Actor.AddToWorld();
                        Actor.FadeIn();
                        
                    });
                }
            }

            public bool WalkOffLot()
            {
                if (Actor.HasExitReason(ExitReason.Canceled))
                {
                    return false;
                }
                uint offsetHint = 0u;
                Vector3 outPos = Vector3.Invalid;
                if (LotManager.FindPlaceOutsideLot(Actor.LotCurrent, ref offsetHint, ref outPos))
                {
                    Route route = Actor.CreateRoute();
                    route.PlanToPoint(outPos);
                    return Actor.DoRoute(route);
                }
                return false;
            }

            public bool SocializationAllowed(Sim simA, Sim simB)
            {
                if (simB.CarryingChildPosture != null)
                {
                    return simB.CarryingChildPosture.Child == simA;
                }
                return false;
            }

            public string GreyedOutTooltipText(Sim simA, Sim simB)
            {
                string entryKey = "Gameplay/Socializing/SocialInteractionA:CannotSocializeWhileLeaving";
                return Localization.LocalizeString(simB.IsFemale, entryKey, simB);
            }
        }
    }
}
