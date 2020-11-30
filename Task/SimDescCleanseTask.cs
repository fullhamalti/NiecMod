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
namespace NiecMod.Nra {
    public static class SimDescCleanseTask {

        public const int MaxListLen = 200;

        internal static ObjectGuid objectSimDescTask = NiecRunCommand.NiecInvalidObjectGuid;

        private static List<SimDescription> qureSimDescList = null;

        public static bool Sleeping = false;

        public static bool StartUp() {

            if (objectSimDescTask != NiecRunCommand.NiecInvalidObjectGuid)
                Simulator.DestroyObject(objectSimDescTask);
            objectSimDescTask = NiecTask.Perform(OnTick);

            if (qureSimDescList == null)
                qureSimDescList = new List<SimDescription>(MaxListLen);

            return objectSimDescTask != NiecRunCommand.NiecInvalidObjectGuid;
        }

        public static void ShutDown() {

            if (qureSimDescList != null)
            {
                foreach (var item in qureSimDescList)
                {
                    NFinalizeDeath.SimDescCleanse(item, true, false);
                }
                qureSimDescList.Clear();
            }
            qureSimDescList = null;

            if (objectSimDescTask != NiecRunCommand.NiecInvalidObjectGuid)
                Simulator.DestroyObject(objectSimDescTask);
            objectSimDescTask = NiecRunCommand.NiecInvalidObjectGuid;
        }

        public static bool Add(SimDescription simDesc, bool needCreateTask = false) {
            if (objectSimDescTask == NiecRunCommand.NiecInvalidObjectGuid) {
                if (simDesc != null && needCreateTask)
                    StartUp();
                else
                    return false; 
            }
            if (simDesc != null) {
                if (qureSimDescList == null)
                    qureSimDescList = new List<SimDescription>(MaxListLen);
                qureSimDescList.Add(simDesc);
                Sleeping = false;
                return true;
            }
            return false;
        }

        public static bool Remove(SimDescription simDesc) {
            var qSimDescList = qureSimDescList;
            bool r = false;
            if (qSimDescList != null)
            {
                r = qSimDescList.Remove(simDesc);
                if (qSimDescList.Count == 0)
                {
                    Sleeping = true;
                }
                else Sleeping = false;
            }
            return r;
        }

        private static void SafeCallSimDescCleanse(SimDescription simd)
        {
            NFinalizeDeath.SafeCall(() => { NFinalizeDeath.SimDescCleanse(simd, true, false); });
        }

        internal static void SafeCallSimDescCleanseO(SimDescription simd)
        {
            NFinalizeDeath.SafeCall(() => { NFinalizeDeath.SimDescCleanse(simd, true, false); });
        }

        internal static void SafeCallSimDescCleanseO1(SimDescription simd)
        {
            NFinalizeDeath.SafeCall(() => { NFinalizeDeath.SimDescCleanse(simd, true, false); });
        }

        private static void OnTick() {
            try
            {
                var isOpenDGS = AssemblyCheckByNiec.SafeIsInstalled("OpenDGS");
                if (!isOpenDGS)
                {
                    NiecTask.SimulateAgainRuntimeFound();
                    NiecTask.SetNeedNoErrorRuntime(true);
                    Sleeping = qureSimDescList != null && qureSimDescList.Count == 0;
                }
                while (true) { 

                    Simulator.Sleep(0);

                    if (qureSimDescList == null)
                        qureSimDescList = new List<SimDescription>(MaxListLen);
                    if (qureSimDescList.Count == 0)
                    {
                        for (int i = 0; i < 250; i++)
                        {
                            Simulator.Sleep(0);
                            if (!Sleeping) 
                                break;
                        }
                    }

                    if (qureSimDescList == null)
                        qureSimDescList = new List<SimDescription>(MaxListLen);
                    if (qureSimDescList.Count == 0) 
                        continue;
                   
                    foreach (var item in qureSimDescList.ToArray())
                    {
                        if (isOpenDGS)
                        {
                            qureSimDescList.Remove(item);
                            NFinalizeDeath.SimDescCleanse(item, true, false);
                        }
                        else
                        {
                            niec_std.list_remove(qureSimDescList, item);
                            SafeCallSimDescCleanse(item);
                        }
                        Simulator.Sleep(0);
                    }
                    Sleeping = qureSimDescList.Count == 0;
                }
            }
            finally
            {
                objectSimDescTask = default(ObjectGuid);
                Sleeping = true;
            }
        }
    }
}
