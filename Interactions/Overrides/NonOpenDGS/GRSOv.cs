using System;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Core;

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
using Sims3.NiecModList.Persistable;
using Sims3.Gameplay.NiecRoot;
using Sims3.Gameplay.Seasons;
using Sims3.SimIFace.Enums;
using Sims3.Gameplay.Services;

namespace Sims3.Gameplay.NiecNonOpenDGS.Interactions
{
    public class GRSOVInteraction
    {
        public class NGrimReaperAppear : Sims3.Gameplay.Services.GrimReaperSituation.GrimReaperAppear {
            public InteractionInstance dataNHSInteraction = null;
            public override void ConfigureInteraction()
            {
                if (Simulator.GetProxy(Actor.ObjectId) != null)
                    dataNHSInteraction = NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(Target);
                base.ConfigureInteraction();
            }
            public override bool Run()
            {
                if (dataNHSInteraction == null)
                    return base.Run();
                return dataNHSInteraction.Run();
            }
            public override void Cleanup()
            {
                if (dataNHSInteraction == null)
                     base.Cleanup();
                else dataNHSInteraction.Cleanup();
            }
        }
        public class NGrimReaper_ReapPetSoul : Sims3.Gameplay.Services.GrimReaperSituation.ReapPetSoul
        {
            public InteractionInstance dataNHSInteraction = null;
            public override void ConfigureInteraction()
            {
                if (Simulator.GetProxy(Actor.ObjectId) != null)
                    dataNHSInteraction = NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(Target);
                base.ConfigureInteraction();
            }
            public override bool Run()
            {
                if (dataNHSInteraction == null)
                    return base.Run();
                return dataNHSInteraction.Run();
            }
            public override void Cleanup()
            {
                if (dataNHSInteraction == null)
                    base.Cleanup();
                else dataNHSInteraction.Cleanup();
            }
        }
        public class NGrimReaper_ReapSoul : Sims3.Gameplay.Services.GrimReaperSituation.ReapSoul
        {
            public InteractionInstance dataNHSInteraction = null;
            public override void ConfigureInteraction()
            {
                if (Simulator.GetProxy(Actor.ObjectId) != null)
                    dataNHSInteraction = NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(Target);
                base.ConfigureInteraction();
            }
            public override bool Run()
            {
                if (dataNHSInteraction == null)
                    return base.Run();
                return dataNHSInteraction.Run();
            }
            public override void Cleanup()
            {
                if (dataNHSInteraction == null)
                    base.Cleanup();
                else dataNHSInteraction.Cleanup();
            }
        }
        public class NGrimReaper_ReapSoulDiving : Sims3.Gameplay.Services.GrimReaperSituation.ReapSoulDiving
        {
            public InteractionInstance dataNHSInteraction = null;
            public override void ConfigureInteraction()
            {
                if (Simulator.GetProxy(Actor.ObjectId) != null)
                    dataNHSInteraction = NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(Target);
                base.ConfigureInteraction();
            }
            public override bool Run()
            {
                if (dataNHSInteraction == null)
                    return base.Run();
                return dataNHSInteraction.Run();
            }
            public override void Cleanup()
            {
                if (dataNHSInteraction == null)
                    base.Cleanup();
                else dataNHSInteraction.Cleanup();
            }
        }
    }
    public class GRSOv // Fix Test :)
    {
        [DoesntRequireTuning]
        public class GrimReaperAppear_Definition : InteractionDefinition<Sim, Sim, Sims3.Gameplay.Services.GrimReaperSituation.GrimReaperAppear>
        {
            public override string GetInteractionName(Sim a, Sim target, InteractionObjectPair interaction)
            {
                return "GrimReaperAppear";
            }

            public override InteractionInstance CreateInstance(ref InteractionInstanceParameters parameters)
            {
                Sim Actor = parameters.Actor as Sim;
                if (Actor != null && Actor.SimDescription != null)
                {
                    if ((Actor.Service as GrimReaper ?? Actor.SimDescription.CreatedByService as GrimReaper) != null)
                    {
                        var inty = new GRSOVInteraction.NGrimReaperAppear();
                        inty.Init(ref parameters);
                        return inty;
                    }
                    else if (NFinalizeDeath.SimIsNiecHelperSituation(Actor) && (ServiceSituation.FindServiceSituationInvolving(Actor) as GrimReaperSituation) == null)
                    {
                        return NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(parameters.Target as Sim);
                    }
                }
                return base.CreateInstance(ref parameters);
            }

            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                try
                {
                    if (parameters.Actor == null) return InteractionTestResult.GenericFail;
                    if (parameters.Target == null) return InteractionTestResult.GenericFail;
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

            public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                // a.SetForward(target.ForwardVector);
                return true;
            }
        }

        public class ReapSoulPet_Definition : InteractionDefinition<Sim, Sim, Sims3.Gameplay.Services.GrimReaperSituation.ReapPetSoul>, IUsableDuringFire
        {
            public override string GetInteractionName(Sim a, Sim target, InteractionObjectPair interaction)
            {
                return "ReapSoulPet";
            }

            public override InteractionInstance CreateInstance(ref InteractionInstanceParameters parameters)
            {
                Sim Actor = parameters.Actor as Sim;
                if (Actor!= null && Actor.SimDescription != null)
                {
                    if ((Actor.Service as GrimReaper ?? Actor.SimDescription.CreatedByService as GrimReaper) != null)
                    {
                        var inty = new GRSOVInteraction.NGrimReaper_ReapPetSoul();
                        inty.Init(ref parameters);
                        return inty;
                    }
                    else if (NFinalizeDeath.SimIsNiecHelperSituation(Actor) && (ServiceSituation.FindServiceSituationInvolving(Actor) as GrimReaperSituation) == null)
                    {
                        return NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(parameters.Target as Sim);
                    }
                }
                return base.CreateInstance(ref parameters);
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
                { return InteractionTestResult.Pass; }
                //return base.Test(ref parameters, ref greyedOutTooltipCallback);
            }
            public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                /*
                if ((ServiceSituation.FindServiceSituationInvolving(a) as GrimReaperSituation) != null) return true;
                if (a.Service is GrimReaper)
                {
                    return target.SimDescription.DeathStyle != SimDescription.DeathType.None;
                }
                return false;*/
                if (isAutonomous)
                {
                    return false;
                }
                if (a.IsSelectable)
                {
                    return true;
                }
                if (a.Service is GrimReaper || a.SimDescription.CreatedByService is GrimReaper)
                {
                    return true;
                }
                if ((ServiceSituation.FindServiceSituationInvolving(a) as GrimReaperSituation) != null) return true;
                return false;
            }
        }
        public class ReapSoul_Definition : InteractionDefinition<Sim, Sim, Sims3.Gameplay.Services.GrimReaperSituation.ReapSoul>, IUsableDuringFire
        {

            public override string GetInteractionName(Sim a, Sim target, InteractionObjectPair interaction)
            {
                return "ReapSoul";
            }

            public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if (isAutonomous)
                {
                    return false;
                }
                if (a.IsSelectable)
                {
                    return true;
                }
                if (a.Service is GrimReaper || a.SimDescription.CreatedByService is GrimReaper)
                {
                    return true;
                }
                if ((ServiceSituation.FindServiceSituationInvolving(a) as GrimReaperSituation) != null) return true;
                return false;
            }

            public override InteractionInstance CreateInstance(ref InteractionInstanceParameters parameters)
            {
                Sim Actor = parameters.Actor as Sim;
                if (Actor != null && Actor.SimDescription != null)
                {
                    if ((Actor.Service as GrimReaper ?? Actor.SimDescription.CreatedByService as GrimReaper) != null)
                    {
                        var inty = new GRSOVInteraction.NGrimReaper_ReapSoul();
                        inty.Init(ref parameters);
                        return inty;
                    }
                    else if (NFinalizeDeath.SimIsNiecHelperSituation(Actor) && (ServiceSituation.FindServiceSituationInvolving(Actor) as GrimReaperSituation) == null)
                    {
                        return NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(parameters.Target as Sim);
                    }
                }
                return base.CreateInstance(ref parameters);
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

        public class ReapSoulDiving_Definition : InteractionDefinition<Sim, Sim, Sims3.Gameplay.Services.GrimReaperSituation.ReapSoulDiving>, IUsableDuringFire, IScubaDivingInteractionDefinition
        {
            public override string GetInteractionName(Sim a, Sim target, InteractionObjectPair interaction)
            {
                return "ReapSoulDiving";
            }

            public override InteractionInstance CreateInstance(ref InteractionInstanceParameters parameters)
            {
                Sim Actor = parameters.Actor as Sim;
                if (Actor != null && Actor.SimDescription != null)
                {
                    if ((Actor.Service as GrimReaper ?? Actor.SimDescription.CreatedByService as GrimReaper) != null)
                    {
                        var inty = new GRSOVInteraction.NGrimReaper_ReapSoulDiving();
                        inty.Init(ref parameters);
                        return inty;
                    }
                    else if (NFinalizeDeath.SimIsNiecHelperSituation(Actor) && (ServiceSituation.FindServiceSituationInvolving(Actor) as GrimReaperSituation) == null)
                    {
                        return NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor, null).CreateInteraction(parameters.Target as Sim);
                    }
                }
                return base.CreateInstance(ref parameters);
            }

            public override bool Test(Sim a, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if ((ServiceSituation.FindServiceSituationInvolving(a) as GrimReaperSituation) != null) return true;
                if (a.Service is GrimReaper)
                {
                    return target.SimDescription.DeathStyle != SimDescription.DeathType.None;
                }
                return false;
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
                }catch (ResetException) { throw;}
                catch (Exception)
                { return InteractionTestResult.GenericFail; }

            }
        }
    }
}
