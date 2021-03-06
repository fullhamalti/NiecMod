﻿/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 21/09/2018
 * Time: 8:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Academics;
using Sims3.Gameplay.ActiveCareer;
using Sims3.Gameplay.ActiveCareer.ActiveCareers;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.ActorSystems.Children;
using Sims3.Gameplay.Actors;
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
using Sims3.Gameplay.Objects.Niec;

namespace NiecMod.Interactions.Objects
{
    public sealed class EnableAndDisble : Interaction<Sim, TriasTrvalKi>
    {
        public static readonly InteractionDefinition Singleton = new Definition();

        public override bool Run() // Run
        {
        	Sim targetsim = GetSelectedObject() as Sim;
            if (targetsim != null)
            {
            	targetsim.InteractionQueue.Add(TriasTrvalKi.Trias_Time.Singleton.CreateInstance(Target, targetsim, base.GetPriority(), true, true));
            }
            //EnableAndDisble.Definition definition = base.InteractionDefinition as EnableAndDisble.Definition;
            int num;
            if (!this.Actor.RouteToSlotList(this.Target, TriasTrvalKi.kRoutingSlots, out num))
            {
                return false;
            }
            this.Target.State = TimePortal.PortalState.Active;
            base.SetPriority(InteractionPriorityLevel.RequiredNPCBehavior, 10f);
            base.StandardEntry(false);
            base.EnterStateMachine("timeportal", "Enter", "x");
            base.AnimateSim("Repair");
            base.BeginCommodityUpdates();
            bool flag = base.DoLoop(ExitReason.UserCanceled, new InteractionInstance.InsideLoopFunction(this.Loop), null);
            base.EndCommodityUpdates(flag);
            base.AnimateSim("Exit");
            base.StandardExit(false, false);

            return true;
        }

        public void Loop(StateMachineClient smc, InteractionInstance.LoopData data)
        {
            if (data.mLifeTime > 676)
            {
                this.Actor.AddExitReason(ExitReason.Finished);
            }
        }
        
        public override bool RunFromInventory()
        {
        	return true;
        }
        /*

        public override void Cleanup()
        {
        	//this.Target.State = TimePortal.PortalState.Inactive;
        	base.Cleanup();
        }
        */
        /*
        public bool mTimeTravlerArrivalHandled = true;
        public StopWatch emergencyStopWatch;
        */

        [DoesntRequireTuning]

        private sealed class Definition : InteractionDefinition<Sim, TriasTrvalKi, EnableAndDisble>, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
        {
            public override string GetInteractionName(Sim actor, TriasTrvalKi target, InteractionObjectPair interaction)
            {
                return "Repair The Oais Eirts";
            }
            
            public override void PopulatePieMenuPicker(ref InteractionInstanceParameters parameters, out List<ObjectPicker.TabInfo> listObjs, out List<ObjectPicker.HeaderInfo> headers, out int NumSelectableRows)
            {
                NumSelectableRows = 2;
                Sim actor = parameters.Actor as Sim;
                List<Sim> sims = new List<Sim>();

                foreach (Sim sim in NiecMod.Nra.NFinalizeDeath.SC_GetObjectsOnLot<Sim>(actor.LotCurrent)) //actor.LotCurrent.GetSims())
                {
                    if (sim != actor && sim.SimDescription.ToddlerOrAbove)
                    {
                        sims.Add(sim);
                    }
                }

                base.PopulateSimPicker(ref parameters, out listObjs, out headers, sims, true);
            }

            public override bool Test(Sim a, TriasTrvalKi target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                if (isAutonomous) return false;
                if (a.IsNPC) return false;
                
                return true;
            }
            public TimePortal.PortalState curState = TimePortal.PortalState.Invalid_State;
        }
    }
}

