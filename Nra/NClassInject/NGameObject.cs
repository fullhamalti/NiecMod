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
    public class NGameObject : GameObject
    {
        public static bool isAwcore = AssemblyCheckByNiec.IsInstalled("AweCore");
        public static List<object> gcList = new List<object>(5000);
        private static object OV = null;

        public static void InitNCreate()
        {
            if ((OV as NGameObject) != null)
                return;

            OV = new NGameObject();
            var O = (NGameObject)OV;

            O.mReferenceList = null;
            O.mActorsUsingMe = null;
        }

        public static NGameObject GetStatic()
        {
            InitNCreate();
            return (NGameObject)OV;
        }

        public static void InitClass()
        {
            var p = GetStatic();
            p.mbInited = true;
            p._InitInit(false);
            p.mbInited = false;
        }

        public ScriptExecuteType _InitInit(bool postLoad)
        {
            if (mbInited)
            {
                return GetScriptExecuteType();
            }

            mbInited = true;

            mProduct = UserToolUtils.GetProduct(UserToolUtils.BuildBuyProductType.Object, GetResourceKey());
            if (mProduct != null)
                mbProductInited = true;

            if (mActorsUsingMe != null)
            {
                while (mActorsUsingMe.Remove(null)) { }
            }

            if (postLoad)
            {
                if (mRoutingReferenceList != null)
                {
                    int i = 0;
                    while (i < mRoutingReferenceList.Count)
                    {
                        if (mRoutingReferenceList[i] == null || !Sims3.SimIFace.Objects.IsValid(mRoutingReferenceList[i].ObjectId))
                        {
                            mRoutingReferenceList.RemoveAt(i);
                        }
                        else
                        {
                            i++;
                        }
                    }
                }

                try
                {
                    OnLoad();
                }
                catch (Exception)
                {
                    if (!isAwcore)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") || SCOSR.IsScriptCore2020())
                        {
                            throw;
                        }
                    }
                }
              
            }
            else
            {
                try
                {
                    OnCreation();
                }
                catch (Exception)
                {
                    if (!isAwcore)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") || SCOSR.IsScriptCore2020())
                        {
                            throw;
                        }
                    }
                }
            }

            try
            {
                if (AddToLot())
                {
                    LotManager.PlaceObjectOnLot(this, base.Proxy.ObjectId);
                }
            }
            catch (Exception)
            {
                if (!isAwcore)
                {
                    if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") || SCOSR.IsScriptCore2020())
                    {
                        throw;
                    }
                }
            }

            try
            {
                OnStartup();
            }
            catch (Exception)
            {
                if (!NiecHelperSituation.__acorewIsnstalled__)
                {
                    if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") || SCOSR.IsScriptCore2020())
                    {
                        throw;
                    }
                }
            }
         
            if (mObjComponents != null)
            {
                try
                {
                    int j = 0;
                    while (j < mObjComponents.Count)
                    {
                        ObjectComponent objectComponent = mObjComponents[j];
                        if (objectComponent != null)
                        {
                            if (postLoad)
                            {
                                objectComponent.OnLoad();
                            }
                            objectComponent.OnStartup();
                            j++;
                        }
                        else
                        {
                            mObjComponents.RemoveAt(j);
                        }
                    }
                    if (mObjComponents.Count == 0)
                    {
                        mObjComponents = null;
                    }
                }
                catch (Exception)
                {
                    if (!NiecHelperSituation.__acorewIsnstalled__)
                    {
                        if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") || SCOSR.IsScriptCore2020())
                        {
                            throw;
                        }
                    }
                }
            }

            try
            {
                if (!postLoad && LotManager.sIsBuildBuyModeOn)
                {
                    SetOwnerLot(LotManager.ActiveLot);
                }
                UpdateOwnerLot(LotCurrent);
            }
            catch (Exception)
            {
                mLotCurrent = LotManager.sWorldLot; 
                if (!isAwcore)
                {
                    if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap") || SCOSR.IsScriptCore2020())
                    {
                        throw;
                    }
                }
            }
            if (isAwcore)
            {
                Sim obj_Sim = ((object)this) as Sim;
                if (obj_Sim != null)
                {
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mAutonomy);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mBuffManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mMoodManager);
                    if (obj_Sim.mInteractionQueue != null)
                    {
                        NFinalizeDeath.AddItemToList(gcList, obj_Sim.mInteractionQueue);
                        NFinalizeDeath.AddItemToList(gcList, obj_Sim.mInteractionQueue.mInteractionList);
                    }
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mLookAtManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mIdleManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mThoughtBalloonManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mSocialComponent);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mSnubManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mMapTagManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mDreamsAndPromisesManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mDreamsAndPromisesManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mDeepSnowEffectManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mFlags);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.SleepDreamManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mCelebrity);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mActorsUsingMe);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mClothingReactionBroadcaster);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mOpportunityManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mPosture);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mActiveSwitchOutfitHelper);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mMapTagManager);
                    NFinalizeDeath.AddItemToList(gcList, obj_Sim.mSimCommodityInteractionMap);

                }
            }
            return GetScriptExecuteType();
        }
    }
}
