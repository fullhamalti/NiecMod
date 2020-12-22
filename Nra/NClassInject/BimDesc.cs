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
    public class NewBimDesc : SimDescriptionCore
    {
        public static bool dontCall = false;
        

        public NewBimDesc()
        {
            if (dontCall)
                return;

            var _this = (SimDescription)(object)this;
            Create.AddNiecSimDescription(_this);
            NiecException.NewSendTextExceptionToDebugger();
            _this.mSkinToneKey = default(ResourceKey);
            _this.mSecondaryNormalMapWeights = new float[2];
            _this.mFlags = SimDescription.FlagField.Marryable | SimDescription.FlagField.CanBeKilledOnJob | SimDescription.FlagField.ShowSocialsOnSim | SimDescription.FlagField.Contactable | SimDescription.FlagField.CanStartFires | SimDescription.FlagField.WasCasCreated;
            _this.mAlmaMaterName = string.Empty;
            _this.UserDaysInCurrentAge = int.MaxValue;
            _this.CharismaStats = default(SimDescription.Charisma);
            _this.mShapeDeltaMultiplier = 1f;
            _this.mPreferredVehicleGuid = ObjectGuid.InvalidObjectGuid;
            _this.mPreferredBoatGuid = ObjectGuid.InvalidObjectGuid;
            _this.LastMakeoverReceivedUserDirected = SimClock.CurrentTime() - new DateAndTime(4, DaysOfTheWeek.Sunday, 0, 0, 0);
            _this.mStoredSlot = PASSPORTSLOT.PASSPORTSLOT_NUM;
            _this.mReturnSimAlarm = AlarmHandle.kInvalidHandle;

            if (SimDescription.sLoadedSimDescriptions != null)
                SimDescription.sLoadedSimDescriptions.Add(_this);

            ACoreS_Census.SpeciallyMark(this);
        }

        public NewBimDesc(SimDescriptionCore sdCore)
        {
            if (dontCall)
                return;

            var _this = (SimDescription)(object)this;
            if (!NStackTrace.IsCallingMyMethedLite("CreateSimHead", true, 3))
            {
                Create.AddNiecSimDescription(_this);
                NiecException.NewSendTextExceptionToDebugger();
            }

            _this.mSkinToneKey = default(ResourceKey);
            _this.mSecondaryNormalMapWeights = new float[2];
            _this.mFlags = SimDescription.FlagField.Marryable | SimDescription.FlagField.CanBeKilledOnJob | SimDescription.FlagField.ShowSocialsOnSim | SimDescription.FlagField.Contactable | SimDescription.FlagField.CanStartFires | SimDescription.FlagField.WasCasCreated;
            _this.mAlmaMaterName = string.Empty;
            _this.UserDaysInCurrentAge = int.MaxValue;
            _this.CharismaStats = default(SimDescription.Charisma);
            _this.mShapeDeltaMultiplier = 1f;
            _this.mPreferredVehicleGuid = ObjectGuid.InvalidObjectGuid;
            _this.mPreferredBoatGuid = ObjectGuid.InvalidObjectGuid;
            _this.LastMakeoverReceivedUserDirected = SimClock.CurrentTime() - new DateAndTime(4, DaysOfTheWeek.Sunday, 0, 0, 0);
            _this.mStoredSlot = PASSPORTSLOT.PASSPORTSLOT_NUM;
            _this.mReturnSimAlarm = AlarmHandle.kInvalidHandle;

            _this.mIsValidDescription = true;

            if (SimDescription.sLoadedSimDescriptions != null)
                SimDescription.sLoadedSimDescriptions.Add(_this);
            try
            {
                _this.TraitManager = new TraitManager(sdCore.TraitManager);
                _this.TraitManager.SetSimDescription(_this);
                _this.CopyAllOutfits(sdCore);
                _this.CopyCoreFileds(sdCore);
                SimOutfit outfit = sdCore.GetOutfit(OutfitCategories.Everyday, 0);
                _this.Init(outfit);
                _this.CopyPetFields(sdCore);
            }
            catch (Exception)
            { }
           
        }

        public NewBimDesc(SimOutfit defaultOutfit)
        {
            if (dontCall)
                return;

            var _this = (SimDescription)(object)this;
            Create.AddNiecSimDescription(_this);
            NiecException.NewSendTextExceptionToDebugger();

            _this.mSkinToneKey = default(ResourceKey);
            _this.mSecondaryNormalMapWeights = new float[2];
            _this.mFlags = SimDescription.FlagField.Marryable | SimDescription.FlagField.CanBeKilledOnJob | SimDescription.FlagField.ShowSocialsOnSim | SimDescription.FlagField.Contactable | SimDescription.FlagField.CanStartFires | SimDescription.FlagField.WasCasCreated;
            _this.mAlmaMaterName = string.Empty;
            _this.UserDaysInCurrentAge = int.MaxValue;
            _this.CharismaStats = default(SimDescription.Charisma);
            _this.mShapeDeltaMultiplier = 1f;
            _this.mPreferredVehicleGuid = ObjectGuid.InvalidObjectGuid;
            _this.mPreferredBoatGuid = ObjectGuid.InvalidObjectGuid;
            _this.LastMakeoverReceivedUserDirected = SimClock.CurrentTime() - new DateAndTime(4, DaysOfTheWeek.Sunday, 0, 0, 0);
            _this.mStoredSlot = PASSPORTSLOT.PASSPORTSLOT_NUM;
            _this.mReturnSimAlarm = AlarmHandle.kInvalidHandle;

            if (defaultOutfit != null && defaultOutfit.IsValid)
            {
                _this.mIsValidDescription = true;
                _this.Init(defaultOutfit);
                _this.InitHairColors(defaultOutfit);
            }
        }
    }

    [Persistable(false)]
    public class BimDesc : SimDescription
    {
        private static object OV = null;
        private static bool runI = false;
        private static bool waitrunningtask01 = false;
        internal static bool UnsafeFixNUllSimDESC = false;
        public static bool DoneECMK = false;
        public static ulong safeID = 2520000;

        public static void InitNCreate()
        {
            if ((OV as BimDesc) != null)
                return;

            OV = new BimDesc();
            var nullSimDesc = (BimDesc)OV;


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

            if (ListCollon.NiecDisposedSimDescriptions != null)
                ListCollon.NiecDisposedSimDescriptions.Remove(nullSimDesc);
            if (ListCollon.NiecSimDescriptions != null)
                ListCollon.NiecSimDescriptions.Remove(nullSimDesc);
            if (SimDescription.sLoadedSimDescriptions != null)
                SimDescription.sLoadedSimDescriptions.Remove(nullSimDesc);
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
            GetStatic().bd_ExportContent(null, null, null);
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

        public bool bd_ExportContent(ResKeyTable resKeyTable, ObjectIdTable objIdTable, IPropertyStreamWriter writer)
        {
            if (runI)
                return false;
            try {
            writer.WriteUint64(1752637606u, SimDescriptionId);
            writer.WriteUint32(1758328370u, (uint)mSimFlags);
            writer.WriteFloat(3391843422u, AgingYearsSinceLastAgeTransition);
            writer.WriteInt32(183048852u, UserDaysInCurrentAge);
            writer.WriteInt32(2625491639u, resKeyTable.AddKey(mSkinToneKey));
            writer.WriteFloat(3647343526u, mSkinToneIndex);
            writer.WriteFloat(2843729478u, mSecondaryNormalMapWeights[0]);
            writer.WriteFloat(3384101496u, mSecondaryNormalMapWeights[1]);
            writer.WriteInt32(4180891374u, resKeyTable.AddKey(mDefaultOutfitKey));

            writer.WriteUint32(1343616996u, new uint[3]
		    {
		    	base.HairColors[0].Genetic.ARGB,
		    	base.HairColors[0].Dye.ARGB,
		    	base.HairColors[0].UseDye ? 1u : 0u
		    });
            writer.WriteUint32(4135393849u, new uint[3]
		    {
		    	base.HairColors[1].Genetic.ARGB,
		    	base.HairColors[1].Dye.ARGB,
		    	base.HairColors[1].UseDye ? 1u : 0u
		    });
            writer.WriteUint32(2471843458u, new uint[3]
		    {
		    	base.HairColors[2].Genetic.ARGB,
		    	base.HairColors[2].Dye.ARGB,
		    	base.HairColors[2].UseDye ? 1u : 0u
		    });
            writer.WriteUint32(1055971375u, new uint[3]
		    {
		    	base.HairColors[3].Genetic.ARGB,
		    	base.HairColors[3].Dye.ARGB,
		    	base.HairColors[3].UseDye ? 1u : 0u
		    });
            writer.WriteUint32(1836098543u, new uint[3]
		    {
		    	base.EyebrowColor.Genetic.ARGB,
		    	base.EyebrowColor.Dye.ARGB,
		    	base.EyebrowColor.UseDye ? 1u : 0u
		    });
            writer.WriteUint32(1836098544u, new uint[3]
		    {
		    	base.BodyHairColor.Genetic.ARGB,
		    	base.BodyHairColor.Dye.ARGB,
		    	base.BodyHairColor.UseDye ? 1u : 0u
		    });
            writer.WriteUint32(4209090540u, new uint[3]
		    {
		    	base.FacialHairColors[0].Genetic.ARGB,
		    	base.FacialHairColors[0].Dye.ARGB,
		    	base.FacialHairColors[0].UseDye ? 1u : 0u
		    });
            writer.WriteUint32(2711019873u, new uint[3]
		    {
		    	base.FacialHairColors[1].Genetic.ARGB,
		    	base.FacialHairColors[1].Dye.ARGB,
		    	base.FacialHairColors[1].UseDye ? 1u : 0u
		    });
            writer.WriteUint32(4258326570u, new uint[3]
		    {
		    	base.FacialHairColors[2].Genetic.ARGB,
		    	base.FacialHairColors[2].Dye.ARGB,
		    	base.FacialHairColors[2].UseDye ? 1u : 0u
		    });
            writer.WriteUint32(3921444919u, new uint[3]
		    {
			    base.FacialHairColors[3].Genetic.ARGB,
			    base.FacialHairColors[3].Dye.ARGB,
			    base.FacialHairColors[3].UseDye ? 1u : 0u
		    });

            writer.WriteUint32(125685374u, base.BeardUsesHairColor ? 1u : 0u);
            writer.WriteUint32(3390394279u, base.EyebrowsUseHairColor ? 1u : 0u);
            writer.WriteUint32(3390394280u, base.BodyHairUsesHairColor ? 1u : 0u);
            writer.WriteUint32(992007321u, PropagateHairStyle ? 1u : 0u);

            if (mHousehold != null)
            {
                writer.WriteUint64(2221750924u, mHousehold.HouseholdId);
            }

            string value = mFirstName;
            string value2 = mLastName;
            string value3 = mBio;

            writer.WriteString(3947983776u, value);
            writer.WriteString(1883753236u, value2);
            writer.WriteUint32(1723164892u, (uint)mDeathStyle);
            writer.WriteBool(2257506273u, IsNeverSelectable);
            writer.WriteBool(797789854u, AgingEnabled);
            writer.WriteFloat(167162779u, mLifetimeHappiness);
            writer.WriteFloat(3632991774u, mSpendableHappiness);
            writer.WriteUint32(376622899u, (uint)mFavouriteMusicType);
            writer.WriteUint32(904967806u, (uint)mFavouriteFoodType);
            writer.WriteUint32(2418364207u, mFavouriteColor.ARGB);
            writer.WriteString(647611013u, value3);
            writer.WriteUint32(176483828u, (uint)mZodiacSign);
            writer.WriteUint32(183048650u, (uint)AlmaMater);
            writer.WriteString(183661639u, mAlmaMaterName);
            writer.WriteUint32(183048646u, (uint)GraduationType);
            writer.WriteUint32(3732926166u, (uint)ServiceHistory);
            writer.WriteBool(808457844u, Marryable);
            writer.WriteBool(2446075705u, CanBeKilledOnJob);
            writer.WriteBool(130688069u, IsGhost);
            writer.WriteBool(103218814u, Contactable);
            writer.WriteBool(452878294u, IsPregnant);
            writer.WriteBool(1660858165u, IsVisuallyPregnant);
            writer.WriteFloat(233156252u, base.AlienDNAPercentage);

            IPropertyStreamWriter writer2 = writer.CreateChild(2805376650u);

            mInitialShape.ExportContent(resKeyTable, objIdTable, writer2);

            writer.CommitChild();
            writer2 = null;
            writer2 = writer.CreateChild(2533203143u);

            mCurrentShape.ExportContent(resKeyTable, objIdTable, writer2);

            writer.CommitChild();
            writer2 = null;
            writer.WriteFloat(298511592u, mFitnessShapeDelta);
            writer.WriteFloat(4088477862u, mWeightShapeDelta);
            writer.WriteFloat(1817337409u, mShapeDeltaMultiplier);
            writer.WriteUint32(2011243416u, (uint)mVoiceVariation);
            writer.WriteFloat(1170154690u, mVoicePitchModifier);
            writer.WriteInt32(4008810486u, resKeyTable.AddKey(mGeneticHairstyleKey));

            for (uint num = 0u; num < 8; num++)
            {
                writer.WriteInt32(193344880 + num, resKeyTable.AddKey(mGeneticBodyhairStyleKeys[num]));
            }

            writer.WriteInt32(2384582960u, (int)mHomeWorld);
            writer2 = writer.CreateChild(1481885306u);
            mOutfits.ExportContent(resKeyTable, objIdTable, writer2);
            writer.CommitChild();
            writer2 = null;
            writer2 = writer.CreateChild(3152150573u);
            ExportSpecialOutfitIndicies(writer);
            writer.CommitChild();
            writer2 = null;
            List<ulong> list = new List<ulong>();
            foreach (Trait item in base.TraitManager.List)
            {
                list.Add((ulong)item.Guid);
            }
            if (list.Count > 0)
            {
                writer.WriteUint32(1533688765u, (uint)list.Count);
                writer.WriteUint64(1769582843u, list.ToArray());
            }
            ExportContentChild(resKeyTable, objIdTable, writer, 155067715u, base.TraitManager);
            ExportContentChild(resKeyTable, objIdTable, writer, 2057337028u, mGenealogy);
            writer.WriteUint32(2216711505u, LifetimeWish);
            writer.WriteBool(2264331350u, HasCompletedLifetimeWish);
            if (mSupernaturalData != null)
            {
                writer.WriteUint32(226598758u, (uint)mSupernaturalData.OccultType);
                mSupernaturalData.ExportContent(resKeyTable, objIdTable, writer);
            }
            ExportContentChild(resKeyTable, objIdTable, writer, 2368840039u, SkillManager);
            ExportContentChild(resKeyTable, objIdTable, writer, 3850691202u, CareerManager);
            ExportContentChild(resKeyTable, objIdTable, writer, 243549899u, VisaManager);
            ExportContentChild(resKeyTable, objIdTable, writer, 243549900u, CelebrityManager);
            ExportContentChild(resKeyTable, objIdTable, writer, 1916741826u, LifeEventManager);
            ExportContentChild(resKeyTable, objIdTable, writer, 146573769u, OccultManager);
            if (HealthManager != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 222542822u, HealthManager);
            }
            if (mReputation != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 146573776u, mReputation);
            }
            if (MidlifeCrisisManager != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 181659961u, MidlifeCrisisManager);
            }
            if (PetManager != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 4095203657u, PetManager);
            }
            writer.WriteInt32(2081779727u, ReadBookDataList.Count);
            uint num2 = 0u;
            foreach (KeyValuePair<string, ReadBookData> readBookData in ReadBookDataList)
            {
                writer.WriteString(1155630664 + num2, readBookData.Key);
                ExportContentChild(resKeyTable, objIdTable, writer, (uint)(-1873278614 + (int)num2), readBookData.Value);
                num2++;
            }
            if (IsPregnant)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 1064352938u, Pregnancy);
            }
            if (OpportunityHistory != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 3825310104u, OpportunityHistory);
            }
            writer.WriteBool(148913893u, NeedsOpportunityImport);
            if (CreatedSim != null && CreatedSim.DreamsAndPromisesManager != null)
            {
                DnPExportData = new DnPExportData(this);
                ExportContentChild(resKeyTable, objIdTable, writer, 3039377755u, DnPExportData);
            }
            else
            {
                DnPExportData = null;
            }
            if (RelicStats != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 142971188u, RelicStats);
            }
            if (TombStats != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 4233889236u, TombStats);
            }
            if (TravelBuffs != null)
            {
                int count = TravelBuffs.Count;
                IPropertyStreamWriter propertyStreamWriter = writer.CreateChild(143219793u);
                propertyStreamWriter.WriteInt32(0u, count);
                uint num3 = 1u;
                foreach (BuffInstance travelBuff in TravelBuffs)
                {
                    ExportContentChild(resKeyTable, objIdTable, propertyStreamWriter, num3++, travelBuff);
                }
                writer.CommitChild();
            }
            if (mPreferredVehicleGuid != ObjectGuid.InvalidObjectGuid)
            {
                int value4 = objIdTable.AddId(mPreferredVehicleGuid);
                writer.WriteInt32(3836047044u, value4);
            }
            if (Singing != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 145650758u, Singing);
            }
            if (GameStates.IsTravelling)
            {
                writer.WriteInt32(350667110u, CharismaStats.KnownSims);
                writer.WriteInt32(2680064337u, CharismaStats.FriendSims);
                writer.WriteInt32(2649604395u, CharismaStats.BestFriendSims);
                writer.WriteInt32(1611073300u, CharismaStats.JokesSuccesfullyTold);
                writer.WriteInt32(426808711u, CharismaStats.TraitsLearned);
                writer.WriteBool(150904202u, HadFirstKiss);
                writer.WriteBool(150904210u, HadFirstRomance);
                writer.WriteBool(150904214u, HadFirstWooHoo);
                writer.WriteBool(150904215u, HadBachelorParty);
            }
            writer.WriteByte(3475610776u, (byte)KnownSnowmanTypes);
            ExportSurgeryBlends(writer);
            if (CareerManager.DegreeManager != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 240491398u, CareerManager.DegreeManager);
            }
            if (mTraitChipManager != null)
            {
                ExportContentChild(resKeyTable, objIdTable, writer, 2471919987u, mTraitChipManager);
            }
            } catch { }
            return true;
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
            if (niec_native_func.cache_done_niecmod_native_debug_text_to_debugger)
            {
                try
                {
                    throw new Exception("_NDispose");
                }
                catch (Exception ex)
                {
                    niec_native_func.OutputDebugString("NMScriptN Exception Log\n" + ex.ToString() + "\nEnd");
                }
            }
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
