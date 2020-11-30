using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using NiecMod.Interactions;
using NiecMod.KillNiec;
using Sims3.Gameplay.Controllers.Niec;

using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Academics;
using Sims3.Gameplay.ActiveCareer;
using Sims3.Gameplay.ActiveCareer.ActiveCareers;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.ActorSystems.Children;
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
using Sims3.Gameplay.StoryProgression;
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
using Sims3.Gameplay;
using Sims3.Gameplay.CAS.Locale;
using Niec.iCommonSpace;
using Sims3.NiecModList.Persistable;
using System.Reflection;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay.NiecRoot;
using NiecMod.Helpers;

namespace NiecMod.Nra
{

    [Persistable(false)]
    public class BimDesc : SimDescription
    {
        private static object OV = null;
        private static bool runI = false;
        private static bool waitrunningtask01 = false;
        internal static bool UnsafeFixNUllSimDESC = false;

        public static ulong safeID = 2520000;

        public static void InitNCreate()
        {
            if ((OV as BimDesc) != null)
                return;

            OV = new BimDesc();
            var nullSimDesc = (BimDesc)OV;

            if (SimDescription.sLoadedSimDescriptions != null)
                SimDescription.sLoadedSimDescriptions.Remove(nullSimDesc);

            nullSimDesc.mDescription = null;
            nullSimDesc.mVoicePitchModifier = -1f;
            nullSimDesc.mTraitManager = null;
            nullSimDesc.mOutfits = null;
            nullSimDesc.mMaternityOutfits = null;
            nullSimDesc.PreSurgeryBodyWeight = -1f;
            nullSimDesc.PreSurgeryBodyFitness = -1f;
            nullSimDesc.mZodiacSign = Zodiac.Unset;
            nullSimDesc.mFavouriteColor = Color.Preset.None;
            nullSimDesc.mBio = null;

            nullSimDesc.mHairColors = null;

            nullSimDesc.mEyebrowColor = null;

            nullSimDesc.mFacialHairColors = null;

            nullSimDesc.mBodyHairColor = null;
            nullSimDesc.mBeardUsesHairColor = false;
            nullSimDesc.mEyebrowsUseHairColor = false;
            nullSimDesc.mBodyHairUsesHairColor = false;
            nullSimDesc.PropagateHairStyle = false;
            nullSimDesc.PropagateMakeupStyle = false;

            nullSimDesc.mGeneticBodyhairStyleKeys = null;

            nullSimDesc.AgingYearsSinceLastAgeTransition = -1f;
            nullSimDesc.mHomeWorld = WorldName.Undefined;


            nullSimDesc.mSkinToneKey = default(ResourceKey);
            nullSimDesc.mSecondaryNormalMapWeights = null;

            nullSimDesc.mFlags = FlagField.None;

            nullSimDesc.mAlmaMaterName = null;
            nullSimDesc.UserDaysInCurrentAge = int.MaxValue;
            nullSimDesc.CharismaStats = default(SimDescription.Charisma);
            nullSimDesc.mShapeDeltaMultiplier = -1f;
            nullSimDesc.mPreferredVehicleGuid = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;
            nullSimDesc.mPreferredBoatGuid = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;
            nullSimDesc.LastMakeoverReceivedUserDirected = new DateAndTime(0);
            nullSimDesc.mStoredSlot = PASSPORTSLOT.PASSPORTSLOT_NUM;
            nullSimDesc.mReturnSimAlarm = AlarmHandle.kInvalidHandle;
        }

        public static BimDesc GetStatic()
        {
            InitNCreate();
            return (BimDesc)OV;
        }

        public static void InitClass()
        {
            runI = true;
            GetStatic()._NInstantiate(default(Vector3), default(ResourceKey), false, false);
            _NOnWorldLoadFinished();
            _NPostLoadFixUp();
            GetStatic()._NMakeUniqueID();
            GetStatic()._NFixUp();
            GetStatic()._NDispose(false, false, false, false, false);
            runI = false;
        }

        public static void _NPostLoadFixUp()
        {
            if (runI)
                return;

            var list = new List<SimDescription>();

            foreach (Household sHousehold in Household.sHouseholdList)
            {
                bool isPreviousTravelerHousehold = !sHousehold.IsPreviousTravelerHousehold;
                List<SimDescription> allSimDescriptions = sHousehold.AllSimDescriptions;
                int i = 0;

                while (i < allSimDescriptions.Count)
                {
                    var simd = allSimDescriptions[i];
                    try
                    {
                        sLoadedSimDescriptions.Remove(simd);

                        simd.Fixup();

                        MiniSimDescription miniSimDescription = MiniSimDescription.Find(simd.SimDescriptionId);
                        if (miniSimDescription != null && isPreviousTravelerHousehold)
                        {
                            miniSimDescription.Instantiated = true;
                        }

                        if (simd.IsEnrolledInBoardingSchool())
                        {
                            list.Add(simd);
                        }
                    }
                    catch (Exception)
                    {
                        //simd.Dispose();
                        i++;
                        continue;
                    }
                    i++;
                }
                sHousehold.PostSimDescriptionLoadFixup();
            }

            if (list.Count > 0 && !GameUtils.IsInstalled(ProductVersion.EP4))
            {
                foreach (var item in list)
                {
                    if (item.BoardingSchool != null)
                        item.BoardingSchool.OnRemovedFromSchool();

                    item.AssignSchool();

                    if (item.CreatedSim == null)
                    {
                        item.Instantiate(item.LotHome);
                    }
                }
            }

            var dictionary = new Dictionary<SimDescription, bool>();

            foreach (KeyValuePair<SimDescription, Dictionary<SimDescription, Relationship>> sAllRelationship in Relationship.sAllRelationships)
            {
                SimDescription key = sAllRelationship.Key;
                if (!key.IsValidDescription)
                {
                    dictionary[key] = true;
                }

                foreach (SimDescription item in new List<SimDescription>(sAllRelationship.Value.Keys))
                {
                    if (!item.IsValidDescription)
                    {
                        dictionary[item] = true;
                    }
                }
            }

            foreach (SimDescription key in dictionary.Keys)
            {
                Relationship.RemoveSimDescriptionRelationships(key);
            }

            sLoadedSimDescriptions.Clear();
        }

        public static void _NOnWorldLoadFinished()
        {
            if (runI)
                return;
            //FixDataSimBuilder = null;
            GameStates.CleanupEarlyDepatures();
        }
        public void _NDispose(bool clearInstantiatedBit, bool keepPartnerGenealogy, bool addMiniSim, bool fromPostWorldInit, bool destroyAging)
        {
            if (runI)
                return;
            SimDescription simd = (SimDescription)this;
            NiecTask.Perform(() =>
            {
                NFinalizeDeath.SimDescCleanse(simd, true, false);
            });
        }
        public ulong _NMakeUniqueID()
        {
            if (runI)
                return 0;

            //ulong id = mSimDescriptionId;

            try
            {
                for (int i = 0; i < 500 && !IsSimDescriptionIdUnique(safeID); i++)
                {
                    safeID++;
                }
                //id = safeID;
            }
            catch (Exception)
            { 
                safeID += 10; //id = safeID; 
            }


            if (safeID != mSimDescriptionId)
            {
                mOldSimDescriptionId = mSimDescriptionId;
            }

            mSimDescriptionId = safeID;

            if (CelebrityManager != null)
            {
                CelebrityManager.ResetOwnerSimDescription(mSimDescriptionId);
            }
            if (PetManager != null)
            {
                PetManager.ResetOwnerSimDescription(mSimDescriptionId);
            }
            if (TraitChipManager != null)
            {
                TraitChipManager.ResetOwnerSimDescription(mSimDescriptionId);
            }

            return mSimDescriptionId;
        }

        /*
        DebugString: "_NFixUp(): if (ListCollon.NullSimSimDescription == this)"
        DebugString: "NMScript Exception Log
        System.Exception: no message
        
        #0: 0x0001f throw      in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.SimDescription:Fixup () ()
        #1: 0x00050 callvirt   in NRaas.OverwatchSpace.Alarms.NRaas.OverwatchSpace.Alarms.RecoverMissingSims:PrivatePerformAction (bool) (9193E9C0 [0] )
        #2: 0x00011 callvirt   in NRaas.OverwatchSpace.Alarms.NRaas.OverwatchSpace.Alarms.AlarmOption:PerformAction (bool) (9193E9C0 [0] )
        #3: 0x00002 call       in NRaas.OverwatchSpace.Alarms.NRaas.OverwatchSpace.Alarms.AlarmOption:PerformAlarm () ()
        #4: 0x0001b callvirt   in NRaas.NRaas.Overwatch:OnTimer () ()
        #5: 0x00000            in Sims3.Gameplay.Sims3.Gameplay.Function:Invoke () ()
        #6: 0x00003 callvirt   in NRaas.Common+FunctionTask:Simulate () ()
         */
        public void _NFixUp()
        {
            if (runI)
                return;

            if (ListCollon.NullSimSimDescription == this)
            {
                if (niec_native_func.cache_done_niecmod_native_debug_text_to_debugger)
                {
                    niec_native_func.OutputDebugString("_NFixUp(): if (ListCollon.NullSimSimDescription == this)");
                    try
                    {
                        throw new Exception("no message");
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                    }
                } 

                mIsValidDescription = false;
                NFinalizeDeath.SimDesc_NullToEmpty(this);
                mIsValidDescription = true;

                if (UnsafeFixNUllSimDESC)
                {
                    var p = NFinalizeDeath.GetSafeSelectActor();
                    if (p != null && p.SimDescription != null)
                    {
                        mOutfits = p.SimDescription.Outfits;
                    }
                    if (!waitrunningtask01)
                    {
                        waitrunningtask01 = true;
                        NiecTask.Perform(() =>
                        {
                            for (int i = 0; i < 800; i++)
                            {
                                Simulator.Sleep(0);
                            }
                            waitrunningtask01 = false;
                            NFinalizeDeath.SimDescCleanse(this, true, false);
                        });
                    }
                }
                else if (!waitrunningtask01)
                {
                    waitrunningtask01 = true;
                    NiecTask.Perform(() =>
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            Simulator.Sleep(0);
                        }
                        waitrunningtask01 = false;
                        NFinalizeDeath.SimDescCleanse(this, true, true);
                    });
                }
                return;
            }

            mIsValidDescription = true;

            if (base.TraitManager != null)
            {
                base.TraitManager.SetSimDescription(this);
                base.TraitManager.Fixup();
            }

            if (CreatedSim != null && CreatedSim.Inventory != null)
            {
                foreach (TraitChip item in CreatedSim.Inventory.FindAll<TraitChip>(false))
                {
                    item.OnLoadFixup();
                    if (item.Owner == null)
                    {
                        item.SetOwner(this);
                    }
                }
            }

            MiniSimDescription miniSimDescription = MiniSimDescription.Find(SimDescriptionId);
            if ((GameStates.IsTravelling || GameStates.IsEditingOtherTown) && miniSimDescription != null)
            {
                base.CASGenealogy = miniSimDescription.Genealogy;
            }

            if (GameObjectRelationships != null)
            {
                int i = 0;
                while (i < GameObjectRelationships.Count)
                {
                    if (!Sims3.SimIFace.Objects.IsValid(GameObjectRelationships[i].GameObjectDescription.GameObject.ObjectId))
                    {
                        GameObjectRelationships.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if (mGenealogy == null)
            {
                mGenealogy = new Genealogy(this);
            }

            if (SkillManager == null)
            {
                SkillManager = new SkillManager(this);
            }
            else
            {
                SkillManager.OnLoadFixup();
            }

            if (CareerManager == null)
            {
                CareerManager = new CareerManager(this);
            }
            else
            {
                CareerManager.OnLoadFixup();
            }

            if (VisaManager == null)
            {
                VisaManager = new VisaManager(this);
            }
            else
            {
                VisaManager.OnLoadFixup();
            }

            if (CelebrityManager == null)
            {
                CelebrityManager = new CelebrityManager(SimDescriptionId);
            }
            else if (CelebrityManager.Owner == null)
            {
                CelebrityManager.ResetOwnerSimDescription(SimDescriptionId);
            }

            if (LifeEventManager == null || !LifeEventManager.IsValid)
            {
                LifeEventManager = new LifeEventManager(this);
            }

            LifeEventManager.ClearInvalidActiveNodes();

            if (OccultManager == null)
            {
                OccultManager = new OccultManager(this);
            }
            else
            {
                OccultManager.OnLoadFixup();
            }

            if (IsPet)
            {
                if (PetManager == null)
                {
                    PetManager = CreatePetManager();
                }
            }
            else if (PetManager != null)
            {
                PetManager.Dispose();
                PetManager = null;
            }

            if (IsEP11Bot)
            {
                if (TraitChipManager == null)
                {
                    TraitChipManager = new TraitChipManager(this);
                }
                else if (TraitChipManager.Owner == null)
                {
                    TraitChipManager.ResetOwnerSimDescription(SimDescriptionId);
                }
                TraitChipManager.OnLoadFixup();
            }
            else if (TraitChipManager != null)
            {
                TraitChipManager.Dispose();
                TraitChipManager = null;
            }

            AssignSchool();

            if (mSimDescriptionId == 0)
            {
                MakeUniqueId();
            }

            if (ReadBookDataList == null)
            {
                ReadBookDataList = new Dictionary<string, ReadBookData>();
            }

            PushAgingEnabledToAgingManager();

            if (mInitialShape.Owner == null || mCurrentShape.Owner == null || mInitialShape.Owner != this || mCurrentShape.Owner != this)
            {
                mInitialShape.Owner = (mCurrentShape.Owner = this);
            }

            if (OpportunityHistory == null)
            {
                OpportunityHistory = new OpportunityHistory();
            }

            if (Sims3.Gameplay.Gameflow.sGameLoadedFromWorldFile && !Household.IsTravelImport && !GameStates.IsIdTravelling(SimDescriptionId))
            {
                mDisplayedShape.Owner = mCurrentShape.Owner;
                mDisplayedShape.Fit = mCurrentShape.Fit;
                mDisplayedShape.Weight = mCurrentShape.Weight;
                mDisplayedShape.Pregnant = mCurrentShape.Pregnant;
                ResetLifetimeHappinessStatistics();
                mHomeWorld = GameUtils.GetCurrentWorld();
            }

            if (mHomeWorld == WorldName.Undefined)
            {
                mHomeWorld = GameUtils.GetCurrentWorld();
            }

            if (RelicStats == null)
            {
                RelicStats = new RelicStatTracking(this);
            }

            RelicStats.SetSimDescription(this);

            if (TombStats == null)
            {
                TombStats = new TombStatTracking(this);
            }

            TombStats.SetSimDescription(this);

            if (Singing == null)
            {
                Singing = new SingingInfo(this);
            }

            Singing.SetSimDesctiption(this);

            if (AssignedRole != null)
            {
                AssignedRole.OnLoadFixUp();
            }

            Lot lot = LotManager.GetLot(mVirtualLotId);
            if (lot != null)
            {
                lot.VirtualMoveIn(this);
            }

            if (Species == CASAgeGenderFlags.None)
            {
                Species = CASAgeGenderFlags.Human;
            }

            if (!CASLogic.GetSingleton().IsMusicTypeInstalled(FavoriteMusic))
            {
                RandomizeFavoriteMusic();
            }

            if (GetCurrentOutfits() != null)
            {
                OutfitCategories[] array = new OutfitCategories[5]
	            {
	            	OutfitCategories.None,
	            	OutfitCategories.All,
	            	OutfitCategories.CategoryMask,
	            	OutfitCategories.PrimaryCategories,
	            	OutfitCategories.PrimaryHorseCategories
	            };

                foreach (var outfitCategories in array)
                {
                    if (GetOutfitCount(outfitCategories) > 0)
                    {
                        RemoveOutfits(outfitCategories, false);
                        if (base.mMaternityOutfits != null)
                            base.mMaternityOutfits.Remove(outfitCategories);
                        if (base.mOutfits != null)
                            base.mOutfits.Remove(outfitCategories);
                    }
                }
            }

            if (!GameUtils.IsInstalled(ProductVersion.EP4))
            {
                Sim.PlayPretend.RemoveAllChildCostumeOutfits(this);

                if (CreatedSim != null && CreatedSim.CurrentOutfitCategory == OutfitCategories.ChildImagination)
                {
                    CreatedSim.SwitchToOutfitWithoutSpin(OutfitCategories.Everyday);
                }

                RemoveOutfits(OutfitCategories.ChildImagination, true);

                base.Outfits.Remove(OutfitCategories.ChildImagination);

                if (SpoiledGiftHistory != null)
                {
                    SpoiledGiftHistory.Clear();
                    SpoiledGiftHistory = null;
                }
            }

            if (CreatedSim != null && (OccultManager == null || !OccultManager.HasOccultType(OccultTypes.Vampire | OccultTypes.Genie | OccultTypes.Werewolf | OccultTypes.Ghost)) && mSkinToneKey.InstanceId == 15475186560318337848uL)
            {
                World.ObjectSetVisualOverride(CreatedSim.ObjectId, eVisualOverrideTypes.Genie, null);
            }
        }

        public Sim _NInstantiate(Vector3 position, ResourceKey outfitKey, bool addInitialObjects, bool forceAlwaysAnimate)
        {
            if (runI)
                return null;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            if (CreatedSim != null)
            {
                return CreatedSim;
            }

            if (AgingState != null)
            {
                bool isDefaultOutfit = outfitKey == mDefaultOutfitKey;
                AgingState.PreInstantiateSim(ref outfitKey);
                if (isDefaultOutfit)
                {
                    mDefaultOutfitKey = outfitKey;
                }
            }

            Hashtable hashtable = new Hashtable(forceAlwaysAnimate ? 4 : 2);
            hashtable["simOutfitKey"] = outfitKey;
            hashtable["rigKey"] = CASUtils.GetRigKeyForAgeGenderSpecies(Age | Gender | Species);

            if (forceAlwaysAnimate)
            {
                hashtable["enableSimPoseProcessing"] = 1u;
                hashtable["animationRunsInRealtime"] = 1u;
            }

            string instanceName = "GameSim";
            ProductVersion version = ProductVersion.BaseGame;
            if (Species != CASAgeGenderFlags.Human)
            {
                instanceName = "Game" + Species;
                version = ProductVersion.EP5;
            }

            bool shouldNullHousehold = false;
            if (Household == null)
            {
                mHousehold = Household.NpcHousehold ?? Household.ActiveHousehold;
                shouldNullHousehold = true;
            }

            Sim sim = GlobalFunctions.CreateObjectWithOverrides(instanceName, version, position, 0, Vector3.UnitZ, hashtable, new SimInitParameters(this)) as Sim;
            if (sim != null)
            {
                sim.mSimDescription = this;
                this.mSim = sim;

                if (sim.SimRoutingComponent != null)
                {
                    sim.SimRoutingComponent.EnableDynamicFootprint();
                    sim.SimRoutingComponent.ForceUpdateDynamicFootprint();
                }

                try
                {
                    if (sim.IsSelectable)
                    {
                        sim.AddInitialObjects(true);
                    }
                }
                catch (ResetException)
                { throw; }
                catch (Exception)
                { }
                
                PushAgingEnabledToAgingManager();

                if (OccultManager != null)
                    OccultManager.SetupForInstantiatedSim();

                if (GameUtils.IsFutureWorld())
                {
                    CauseEffectService.ApplyCauseAndEffectModsToSim(sim);
                }
                if (IsAlien)
                {
                    World.ObjectSetVisualOverride(sim.ObjectId, eVisualOverrideTypes.Alien, null);
                }

                if (EventTracker.sInstance != null)
                {
                    EventTracker.SendEvent(EventTypeId.kSimInstantiated, null, sim);
                }

                MiniSimDescription miniSimDescription = MiniSimDescription.Find(SimDescriptionId);
                if (miniSimDescription != null && (GameStates.IsTravelling || mHomeWorld != GameUtils.GetCurrentWorld()))
                {
                    miniSimDescription.UpdateInWorldRelationships(this);
                }

                if (HealthManager != null)
                {
                    HealthManager.Startup();
                }

                if (Household.RoommateManager != null && Household.RoommateManager.IsNPCRoommate(SimDescriptionId))
                {
                    Household.RoommateManager.AddRoommateInteractions(sim);
                }
            }

            if (OccultManager != null && SkinToneKey.InstanceId == 15475186560318337848uL && !OccultManager.HasOccultType(OccultTypes.Vampire) && !OccultManager.HasOccultType(OccultTypes.Werewolf) && !IsGhost)
            {
                World.ObjectSetVisualOverride(CreatedSim.ObjectId, eVisualOverrideTypes.Genie, null);
            }

            if (Household != null && Household.IsAlienHousehold)
            {
                (Sims3.UI.Responder.Instance.HudModel as HudModel).OnSimCurrentWorldChanged(true, this);
            }

            if (shouldNullHousehold && mHousehold == Household.NpcHousehold)
            {
                mHousehold = null;
            }

            sim.mSimDescription = this;
            this.mSim = sim;

            return sim;
        }
    }
}
