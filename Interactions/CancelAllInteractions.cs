using System;
using System.Collections.Generic;

using NiecMod.KillNiec;
using NiecMod.Nra;


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
using Sims3.NiecHelp.Tasks;

namespace NiecMod.Interactions
{
    public sealed class CancelAllInteractions : ImmediateInteraction<Sim, Sim>
    {
    	public bool FixExit = true;
        public bool evt = true;
        public static readonly InteractionDefinition Singleton = new Definition();

        public override bool Run()
        {
            NiecTask.Perform(delegate
            {
                try
                {
                    RXXun();
                }
                finally
                {
                    evt = false;
                    Cleanup();
                } 
            });
            evt = true;
            return true;
        }

        public bool RXXun()
        {
            try
            {

                try
                {
                    foreach (InteractionInstance interactionInstance in Target.mInteractionQueue.mInteractionList.ToArray()) // Cant Cancel Fix
                    {
                        interactionInstance.mbOnStopCalled = true;
                    }
                }
                catch (ResetException)
                { throw; }
                catch (Exception)
                { }

                if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Target.mPosture = Target.Standing;"))
                {
                    Target.mPosture = Target.Standing;
                }

                if (Target.mActorsUsingMe != null)
                    Target.mActorsUsingMe.Clear();
                if (Target.mReferenceList != null) {
                    Target.mReferenceList.Clear();
                }
                if (Target.mRoutingReferenceList != null && Target.mRoutingReferenceList.Count != 0)
                    Target.mRoutingReferenceList.Clear();

                Target.AddExitReason(ExitReason.SuspensionRequested);

                

                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);


                Target.AddExitReason(ExitReason.Default);


                /*
                if (Target.InteractionQueue.HasInteractionOfType(Sims3.Gameplay.Objects.Environment.BonehildaCoffin.AwakenBonehilda.Singleton)) // Fixed Error Cancel All GrimReaperSituation.ReapSoul.Singleton
                {
                    SimpleMessageDialog.Show("NiecMod", "Cancel BonehildaCoffin.AwakenBonehilda.Singleton");
                    Target.SetObjectToReset();
                    NiecMod.Nra.SpeedTrap.Sleep();
                    return true;
                }
                if (Target.InteractionQueue.HasInteractionOfType(GrimReaperSituation.ReapSoul.Singleton)) // Fixed Error Cancel All GrimReaperSituation.ReapSoul.Singleton
                {
                    if (!NFinalizeDeath.CheckAccept("Cancel Quit ReapSoul? Accept Reset ReapSoul")) return false;
                    //SimpleMessageDialog.Show("NiecS3Mod", " Sorry, Can't Cancel GrimReaperSituation.ReapSoul");
                    Target.SetObjectToReset();
                    NiecMod.Nra.SpeedTrap.Sleep();
                    return true;
                }
                if (!Target.HasBeenDestroyed && Simulator.CheckYieldingContext(false))
                {
                    NiecMod.Nra.SpeedTrap.Sleep();
                    if (NFinalizeDeath.CheckAccept("Force Cancel All Interactions Without Cleanup?"))
                    {
                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                        Target.InteractionQueue.OnReset();
                        return true;
                    }
                    else if (!NFinalizeDeath.CheckAccept("Cancel All Interactions?"))
                    {
                        this.FixExit = false;
                        return true;
                    }

                    try
                    {
                        foreach (InteractionInstance interactionInstance in Target.InteractionQueue.InteractionList) // Cant Cancel Fix
                        {
                            interactionInstance.MustRun = false;
                            interactionInstance.Hidden = false;
                        }
                    }
                    catch
                    { }
                    NFinalizeDeath.CancelAllInteractions(Target);
                }
                
                return true;


                /*
                //Custom CancelAllInteractions
                checked
                {
                    for (int i = Target.InteractionQueue.mInteractionList.Count - 1; i >= 0; i--)
                    {
                        if (!(Target.InteractionQueue.mInteractionList[i] is ExtKillSimNiec))
                        {
                            try
                            {
                                Target.InteractionQueue.CancelNthInteraction(i, true, ExitReason.SuspensionRequested);
                            }
                            catch
                            { }

                        }
                    }
                }
                */
                


                /*
                for (int i = Target.InteractionQueue.mInteractionList.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        InteractionInstance interactionInstance = Target.InteractionQueue.mInteractionList[i];
                        if (!(interactionInstance is ExtKillSimNiec))
                        {
                            Target.InteractionQueue.CancelNthInteraction(i);
                        }
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    
                }
                */
                /*
                try
                {
                    Target.InteractionQueue.OnReset();
                }
                catch
                { }
                */


                /*
                // Test 1
                {
                    //try
                    //Target.InteractionQueue.OnReset();

                }

                {
                    Target.InteractionQueue.CancelAllInteractions(); // Cancel All Interactions Byasss Anti-Cancel 
                }

                // Test 2




                // Test 3
                {
                    Target.InteractionQueue.OnReset(); // Sim Interactions is Reset
                    Target.InteractionQueue.CancelAllInteractions();
                }
                // Test 4
                {
                    Target.InteractionQueue.CancelAllInteractions(); // Cancel All Interactions Byasss Anti-Cancel 
                    Target.InteractionQueue.OnReset();
                }
                foreach (InteractionInstance interactionInstance in Target.InteractionQueue.InteractionList) // Cant Cancel Fix
                {
                    interactionInstance.MustRun = false;
                    interactionInstance.Hidden = false;
                }
                {
                    Target.InteractionQueue.CancelAllInteractions();
                }

                {
                    Target.InteractionQueue.OnReset();
                }

                {
                    Target.InteractionQueue.CancelAllInteractions();
                }

                {
                    Target.InteractionQueue.CancelAllInteractions();
                }
                //
                {
                    
                    if (Target.IsInActiveHousehold)
                    {
                        //Target.BuffManager.AddElement(BuffNames.HeartBroken, 60000, 6000000, Origin.FromGrimReaper);
                        return false;
                    }
                    
                   
                    Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999), false, true));
                    Target.InteractionQueue.AddNext(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999), false, true));
                    Target.InteractionQueue.OnReset();
                }
                //Actor.LoopIdle();
                return true;
            */

            }
            catch (ResetException)
            {
                /*
            	foreach (InteractionInstance interactionInstance in Target.InteractionQueue.InteractionList) // Cant Cancel Fix
                {
            		interactionInstance.SetPriority(new InteractionPriority((InteractionPriorityLevel)0, -1f));
                    interactionInstance.MustRun = false;
                    interactionInstance.Hidden = false;
                }
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.CancelAllInteractions();*/
                throw;
            }
            catch (Exception) //ex)
            {
                //NiecException.WriteLog("CancelAllInteractions: " + NiecException.NewLine + NiecException.LogException(ex), true, false, true);
            }
            /*
            if (Target.InteractionQueue.HasInteractionOfType(Sims3.Gameplay.Objects.Environment.BonehildaCoffin.AwakenBonehilda.Singleton)) // Fixed Error Cancel All GrimReaperSituation.ReapSoul.Singleton
            {
                SimpleMessageDialog.Show("NiecS3Mod", " Sorry, Can't Cancel GrimReaperSituation.ReapSoul");
                Target.SetObjectToReset();
                return false;
            }
            */
            return true;
        }

        public override void Cleanup()
        {
            if (evt || Target.HasBeenDestroyed) return;
            try
            {
            	 
                if (this.FixExit)
                {
                    //Target.InteractionQueue.OnReset();
                    //Target.InteractionQueue.CancelAllInteractions();
                    //Target.InteractionQueue.CancelAllInteractions();
                    try
                    {
                        foreach (InteractionInstance interactionInstance in Target.InteractionQueue.InteractionList) // Cant Cancel Fix
                        {
                            interactionInstance.mMustRun = false;
                            interactionInstance.mHidden = false;
                        }
                    }
                    catch (ResetException) { throw; }
                    catch
                    { }
                    return;
                }
            }
            catch (ResetException)
            {
            	foreach (InteractionInstance interactionInstance in Target.InteractionQueue.InteractionList) // Cant Cancel Fix
                {
                    interactionInstance.MustRun = false;
                    interactionInstance.Hidden = false;
                }
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.CancelAllInteractions();
                //throw;
            }
            catch (Exception)
            {
            	foreach (InteractionInstance interactionInstance in Target.InteractionQueue.InteractionList) // Cant Cancel Fix
                {
                    interactionInstance.MustRun = false;
                    interactionInstance.Hidden = false;
                }
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                Target.InteractionQueue.Add(Singleton.CreateInstance(Target, Target, new InteractionPriority((InteractionPriorityLevel)999, 999f), false, true));
                //Target.InteractionQueue.OnReset();
                Target.InteractionQueue.CancelAllInteractions();
                //throw;
            }
        }

        [DoesntRequireTuning]

        private sealed class Definition : ImmediateInteractionDefinition<Sim, Sim, CancelAllInteractions>, IAllowedOnClosedVenues, IOverridesAgeTests, IUseTargetForAutonomousIsAllowedInRoomCheck, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
        {
            public override string GetInteractionName(Sim actor, Sim target, InteractionObjectPair interaction)
            {
                return "Force Cancel All Interactions";
            }
            public override bool Test(Sim actor, Sim target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if (isAutonomous) return false; // Autonomous is DisAllow

                return true;                    //comment out or delete if using test
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

            public SpecialCaseAgeTests GetSpecialCaseAgeTests()
            {
                return SpecialCaseAgeTests.None;
            }
        }
    }
}
