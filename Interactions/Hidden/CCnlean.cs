/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 26/09/2018
 * Time: 1:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Interfaces;

using Sims3.SimIFace;
using System.Collections.Generic;

namespace NiecMod.Interactions
{
    public  class NinecReaper : Interaction<Sim, Sim>, IRouteFromInventoryOrSelfWithoutCarrying
    {
        public static NinecReaper CreateP(Sim Actor, Sim Target, CustomRun customRun, InteractionPriority priority)
        {
            NinecReaper ii = NinecReaper.Singleton.CreateInstance(Target, Actor, priority, false, true) as NinecReaper;
            ii.customRun = customRun;
            return ii;
        }

        public static NinecReaper Create(Sim Actor, Sim Target, CustomRun customRun)
        { 
            NinecReaper ii = NinecReaper.Singleton.CreateInstance
                (Target, Actor, new InteractionPriority(InteractionPriorityLevel.MaxDeath), false, true) as NinecReaper;
            ii.customRun = customRun;
            return ii;
        }


        public static NinecReaper AddToInteranctionQueue(Sim Actor, Sim Target, CustomRun customRun)
        {
            if (Actor == null || Actor.InteractionQueue == null) 
                return null;

            NinecReaper ii = Create(Actor, Target, customRun);

            ii.customRun = customRun;
            Actor.InteractionQueue.Add(ii);

            return ii;
        }


        public override string GetInteractionName()
        {
            if (CustomRunName == null)
                return base.GetInteractionName();
            else return CustomRunName;
        }


        public static NinecReaper AddToInteranctionQueue(Sim Actor, Sim Target, CustomRun customRun, InteractionPriority priority, bool isAutonomous, bool cancellableByPlayer)
        {
            if (Actor == null || Actor.InteractionQueue == null) return null;
            NinecReaper ii = NinecReaper.Singleton.CreateInstance(Target, Actor, priority, isAutonomous, cancellableByPlayer) as NinecReaper;
            ii.customRun = customRun;
            Actor.InteractionQueue.Add(ii);
            return ii;
        }

        public delegate bool CustomRun(Sim Actor, Sim Target, InteractionInstance CurrentInteraction);
        public string CustomRunName = null;

        public static bool EmtpyRun(Sim Actor, Sim Target, InteractionInstance CurrentInteraction) { return true; }

        public delegate void CustomCleanUp(InteractionInstance CurrentInteraction);

        public string CustomCleanUpName = null;


        [global::Sims3.SimIFace.Persistable(false)]
        public CustomRun customRun = null;
        [global::Sims3.SimIFace.Persistable(false)]
        public CustomCleanUp customCleanUp = null;

        public List<NiecMod.Nra.NiecObjectPlus> iData = null;//= new List<Nra.NiecObjectPlus>();

        public bool[] dataBoolens = new bool[10];

        public static readonly InteractionDefinition Singleton = new Definition();

        public override bool Run()
        {
            // GC Bug Fixed
            if (customRun == null || customRun.method_info == null || (!customRun.Method.IsStatic && customRun.Target == null)) // unprotected mono mscorlib 
            {
                Simulator.Sleep(uint.MaxValue);
                return base.Run();
            }
            else return customRun(Actor, Target, this);
        }

        public override void Cleanup()
        {
            // GC Bug Fixed
            // unprotected mono mscorlib 
            if (customCleanUp == null || customCleanUp.method_info == null || (!customCleanUp.Method.IsStatic && customCleanUp.Target == null)) 
                return;
            else customCleanUp(this);

            //if (customCleanUp != null)
            //    customCleanUp(this);
            //else
            //    return;
        }

        [DoesntRequireTuning]

        private sealed class Definition : InteractionDefinition<Sim, Sim, NinecReaper>, IAllowedOnClosedVenues, IOverridesAgeTests, IUseTargetForAutonomousIsAllowedInRoomCheck, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
        {
            public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair interaction)
            {
                return "NinecReaper Interaction";
            }

            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {

                if (!Test(parameters.Actor as Sim, parameters.Target as Sim, parameters.Autonomous, ref greyedOutTooltipCallback))
                {
                    return InteractionTestResult.Def_TestFailed;
                }
                return InteractionTestResult.Pass;
            }

            public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if (isAutonomous) return false;

                return true;
            }
            public SpecialCaseAgeTests GetSpecialCaseAgeTests()
            {
                return SpecialCaseAgeTests.None;
            }
        }
    }

    public sealed class CCnlean : Interaction<Sim, Sim>, IRouteFromInventoryOrSelfWithoutCarrying
    {
        public static readonly InteractionDefinition Singleton = new Definition();

        public override void ConfigureInteraction() { }

        public override bool Run()
        {
            return true;
        }

        public override void Cleanup()
        {
            return;
        }

        [DoesntRequireTuning]
        
        private sealed class Definition : InteractionDefinition<Sim, Sim, CCnlean>, IAllowedOnClosedVenues, IOverridesAgeTests, IUseTargetForAutonomousIsAllowedInRoomCheck, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
        {
            public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair interaction)
            {
                return "Empty Interaction";
            }

            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {

                if (!Test(parameters.Actor as Sim, parameters.Target as Sim, parameters.Autonomous, ref greyedOutTooltipCallback))
                {
                    return InteractionTestResult.Def_TestFailed;
                }
                return InteractionTestResult.Pass;
            }

            public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if (isAutonomous) return false;

                return true;
            }
            public SpecialCaseAgeTests GetSpecialCaseAgeTests()
            {
                return SpecialCaseAgeTests.None;
            }
        }
    }
}
