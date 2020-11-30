using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.CAS;
using Sims3.SimIFace.CAS;
using Sims3.UI.Hud;
using Sims3.SimIFace;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay.NiecRoot;
using Sims3.Gameplay.Actors;

namespace NiecMod.Nra
{
    public class NGenetics
    {
        private static int CheckLoop = -1;

        public static object NULLSIMDESC = null;

        private static void OnSavingGame(IScriptObjectGroup group)
        {
            var p = Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription;
            if (p != null)
            {
                if (p.mSim != null)
                {
                    try
                    {
                        Bim.bSDestroy(p.mSim);
                    }
                    catch (Exception) { }
                }

                if (NiecHelperSituation.__acorewIsnstalled__)
                {
                    foreach (var item in Sims3.NiecModList.Persistable.ListCollon.SafeObjectGC_TempBim)
                    {
                        var itemSim = item as Sim;
                        if (itemSim == null)
                            continue;
                        itemSim.mSimDescription = p;
                    }
                }

                if (!NFinalizeDeath.IsNullOrEmpty(p.mFirstName) || (p.Household == Household.sNpcHousehold || p.Household == Household.sPetHousehold || p.Household == Household.sAlienHousehold))
                {
                    NFinalizeDeath.Household_Remove(p, true);
                    if (!NFinalizeDeath.IsNullOrEmpty(p.mFirstName) || p.IsValid || p.IsValidDescription)
                    {
                        NFinalizeDeath.RemoveAllSimNiecNullForGrave(true);
                        SimDescCleanseTask.SafeCallSimDescCleanseO1(p);
                    }
                }
                else
                    p.mSim = null;
            }
        }
        public static void InitClass()
        {
            if (CheckLoop == -1)
            {
                //if (Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription == null)
                //    Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription = new SimDescription();

                LoadSaveManager.ObjectGroupSaving += OnSavingGame;

                NiecTask.Perform(() =>
                {
                    while (true)
                    {
                        Simulator.Sleep(0);
                        CheckLoop = 0;
                    }
                });

                //NiecTask.Perform(() =>
                //{
                //    if (NULLSIMDESC as SimDescription == null)
                //        NULLSIMDESC = new SimDescription();
                //
                //    SimDescCleanseTask.SafeCallSimDescCleanse((SimDescription)NULLSIMDESC);
                //
                //    while (true)
                //    {
                //        Simulator.Sleep(0);
                //        for (int i = 0; i < 1350; i++)
                //        {
                //            Simulator.Sleep(0);
                //        }
                //
                //        var p = NULLSIMDESC as SimDescription;
                //        if (p != null)
                //        {
                //            SimDescCleanseTask.SafeCallSimDescCleanse(p);
                //        }
                //    }
                //});

                NiecTask.Perform(() =>
                {
                    while(Helpers.Create.NiecNullSimDescription(true, false, true) == null)
                        Simulator.Sleep(0);

                    if (SimDescription.sLoadedSimDescriptions != null)
                        SimDescription.sLoadedSimDescriptions.Remove(Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription);

                    while (true)
                    {
                        Simulator.Sleep(0);
                        for (int i = 0; i < 350; i++)
                        {
                            Simulator.Sleep(0);
                        }

                        var p = Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription;
                        if (p != null && (p.Household == Household.sNpcHousehold || p.Household == Household.sPetHousehold || p.Household == Household.sAlienHousehold))
                        {
                            NFinalizeDeath.Household_Remove(p, true);
                            if (p.IsValid || p.IsValidDescription)
                            {
                                SimDescCleanseTask.SafeCallSimDescCleanseO1(p);
                            }
                            p.mSim = Bim.nullsim;
                        }
                    }
                });

                CreateSimDesc(null, CASAgeGenderFlags.None, CASAgeGenderFlags.None, default(ResourceKey), 0, null, WorldName.Undefined, 0, false);
                CreatePetBabyPetSimDescription(null, null, null, null, false, GeneticsPet.SetName.DoNotSetName, null, -1, OccultTypes.None, WorldName.Undefined);
                CreatePetFamily(null, null, CASAgeGenderFlags.None, CASAgeGenderFlags.None, CASAgeGenderFlags.None, null, false, GeneticsPet.SetName.DoNotSetName, -1, OccultTypes.None);
                CreatePet(null, CASAgeGenderFlags.None, CASAgeGenderFlags.None, CASAgeGenderFlags.None, null, WorldName.Undefined);
                CreateRobot(default(ResourceKey));

                CheckLoop = 0;
            }
        }

        public static SimDescription CreatePet(SimBuilder builder, CASAgeGenderFlags age, CASAgeGenderFlags gender, CASAgeGenderFlags species, Sims3.Gameplay.CAS.GeneticsPet.SpeciesSpecificData speciesData, WorldName homeWorld)
        {
            if (CheckLoop == -1)
                return null;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            CheckLoop++;
            if (CheckLoop > 500)
            {
                CheckLoop = 0;
                Simulator.Sleep(0);
            }

            if (Type.GetType("Sims3.Gameplay.Services.Maid", false) != null)
            {
                var task = NFinalizeDeath.GetCurrentGameObjectFastTask<object>();
                if (task is Sims3.Gameplay.Services.Services || task is Sims3.Gameplay.Roles.RoleManagerTask)
                {
                    for (int i = 0; i < 450; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
            }

            var t = Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription;

            if (t != null && t.PetManager == null)
            {
                t.PetManager = new Sims3.Gameplay.ActorSystems.PetManager();
            }

            return t ?? NULLSIMDESC as SimDescription;
        }


        public static SimDescription CreatePetFamily(SimDescription dad, SimDescription mom, CASAgeGenderFlags age, CASAgeGenderFlags gender, CASAgeGenderFlags species, Random pregoRandom, bool updateGenealogy, Sims3.Gameplay.CAS.GeneticsPet.SetName setNameType, int offspringIndex, OccultTypes occult)
        {
            //if (dad == null && mom == null && age == CASAgeGenderFlags.None && gender == CASAgeGenderFlags.None)
            if (CheckLoop == -1)
                return null;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            CheckLoop++;
            if (CheckLoop > 500)
            {
                CheckLoop = 0;
                Simulator.Sleep(0);
            }

            if (Type.GetType("Sims3.Gameplay.Services.Maid", false) != null)
            {
                var task = NFinalizeDeath.GetCurrentGameObjectFastTask<object>();
                if (task is Sims3.Gameplay.Services.Services || task is Sims3.Gameplay.Roles.RoleManagerTask)
                {
                    for (int i = 0; i < 450; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
            }

            return Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription ?? NULLSIMDESC as SimDescription;
        }

        public static SimDescription CreatePetBabyPetSimDescription(SimBuilder builder, SimDescription dad, SimDescription mom, Random pregoRandom, bool updateGenealogy, Sims3.Gameplay.CAS.GeneticsPet.SetName setNameType, Sims3.Gameplay.CAS.GeneticsPet.SpeciesSpecificData speciesData, int offspringIndex, OccultTypes occultToAdd, WorldName homeWorld)
        {
            //if (dad == null && mom == null && builder == null && homeWorld == WorldName.Undefined)
            if (CheckLoop == -1)
                return null;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            CheckLoop++;
            if (CheckLoop > 500)
            {
                CheckLoop = 0;
                Simulator.Sleep(0);
            }

            if (Type.GetType("Sims3.Gameplay.Services.Maid", false) != null)
            {
                var task = NFinalizeDeath.GetCurrentGameObjectFastTask<object>();
                if (task is Sims3.Gameplay.Services.Services || task is Sims3.Gameplay.Roles.RoleManagerTask)
                {
                    for (int i = 0; i < 450; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
            }

            return Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription ?? NULLSIMDESC as SimDescription;
        }

        public static SimDescription CreateSimDesc(SimBuilder builder, CASAgeGenderFlags age, CASAgeGenderFlags gender, ResourceKey skinTone, float skinToneIndex, Color[] hairColors, WorldName homeWorld, uint outfitCategoriesToBuild, bool isAlien)
        {
            //if (age == CASAgeGenderFlags.None && gender == CASAgeGenderFlags.None)
            if (CheckLoop == -1)
                return null;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            CheckLoop++;
            if (CheckLoop > 500)
            {
                CheckLoop = 0;
                Simulator.Sleep(0);
            }

            if (Type.GetType("Sims3.Gameplay.Services.Maid", false) != null)
            {
                var task = NFinalizeDeath.GetCurrentGameObjectFastTask<object>();
                if (task is Sims3.Gameplay.Services.Services || task is Sims3.Gameplay.Roles.RoleManagerTask)
                {
                    for (int i = 0; i < 450; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
            }

            return Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription ?? NULLSIMDESC as SimDescription;
        }

        public static SimDescription CreateRobot(ResourceKey outfitKey)
        {
            //if (outfitKey.InstanceId == 0)
            if (CheckLoop == -1)
                return null;

            if (NiecHelperSituation.__acorewIsnstalled__)
            {
                if (!Instantiator.kDontCallDGSACore && NFinalizeDeath.RUNIACORE != null)
                {
                    NFinalizeDeath.RUNIACORE(false);
                }
                else NFinalizeDeath.CheckNHSP();
            }

            CheckLoop++;
            if (CheckLoop > 500)
            {
                CheckLoop = 0;
                Simulator.Sleep(0);
            }

            if (Type.GetType("Sims3.Gameplay.Services.Maid", false) != null)
            {
                var task = NFinalizeDeath.GetCurrentGameObjectFastTask<object>();
                if (task is Sims3.Gameplay.Services.Services || task is Sims3.Gameplay.Roles.RoleManagerTask)
                {
                    for (int i = 0; i < 450; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
            }

            return Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription ?? NULLSIMDESC as SimDescription;
        }
    }
}
