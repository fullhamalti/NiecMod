/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 06/10/2018
 * Time: 6:45
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
using NiecMod.Nra;

namespace NiecMod.Interactions.Objects
{
    public sealed class NiecObjectAsktoAdd : ImmediateInteraction<Sim, NiecAutoKill>
    {
        public static readonly InteractionDefinition Singleton = new Definition();
        private void XPruneSelectedObjects()
        {
            if (mSelectedObjects == null || mSelectedObjects.Count == 0)
            {
                return;
            }
            for (int num = mSelectedObjects.Count - 1; num >= 0; num--)
            {
                GameObject gameObject = mSelectedObjects[num] as GameObject;
                if (gameObject != null && !NFinalizeDeath.GameObjectIsValid(gameObject.ObjectId.mValue))
                {
                    niec_std.list_remove(mSelectedObjects, gameObject);
                }
            }
        }
        public override bool Run()
        {
            XPruneSelectedObjects();
            if (mSelectedObjects == null) return false;
            foreach (Sim item in mSelectedObjects)
            {
                if (item != null && item.mInteractionQueue != null)
                {
                    item.mInteractionQueue.Add(NiecAutoKill.KillSimNiec.Singleton.CreateInstance(Target, item, base.GetPriority(), false, true));
                }
            }
           
            return true;
        }

        public override bool RunFromInventory()
        {
            return false;
        }

        [DoesntRequireTuning]

        private sealed class Definition : ImmediateInteractionDefinition<Sim, NiecAutoKill, NiecObjectAsktoAdd>, IInteractionDefinitionIsValidForStrangerTarget, IAllowedOnClosedVenues, IOverridesAgeTests, IUseTargetForAutonomousIsAllowedInRoomCheck, IScubaDivingInteractionDefinition, IUsableWhileOnFire, IUsableDuringFire, IUsableDuringBirthSequence, IUsableDuringShow
        {
            public override string GetInteractionName(Sim actor, NiecAutoKill target, InteractionObjectPair interaction)
            {
                return "Ask to Eat Jelly";
            }

            public override void PopulatePieMenuPicker(ref InteractionInstanceParameters parameters, out List<ObjectPicker.TabInfo> listObjs, out List<ObjectPicker.HeaderInfo> headers, out int NumSelectableRows)
            {
                NumSelectableRows = 32;
                Sim actor = parameters.Actor as Sim;
                List<Sim> sims = new List<Sim>();

                foreach (Sim sim in NFinalizeDeath.SC_GetObjectsOnLot<Sim>(actor.LotCurrent))
                {
                    if (sim != actor)
                    {
                        sims.Add(sim);
                    }
                }

                base.PopulateSimPicker(ref parameters, out listObjs, out headers, sims, true);
            }


            public override bool Test(Sim actor, NiecAutoKill target, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
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
