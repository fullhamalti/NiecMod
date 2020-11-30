/*
 * Created by SharpDevelop.
 * User: Niec 2018
 * Date: 13/09/2018
 * Time: 0:20
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
//using Sims3.Gameplay.Services;
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
using NiecMod.Interactions;
using Sims3.Gameplay.Controllers.Niec;
using NiecMod.Nra;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay;
using NiecMod.Helpers.MakeSimPro;
using Sims3.Gameplay.Services;
using Sims3.UI.GameEntry;
using Sims3.SimIFace.VideoRecording;
using System.Runtime.InteropServices;
using NiecMod.Helpers;
using NiecMod.KillNiec;
using System.Reflection;
using Sims3.NiecModList.Persistable;
using Sims3.Gameplay.NiecRoot;
using Niec.iCommonSpace;
using Sims3.Gameplay.Objects.RabbitHoles;
using Sims3.Gameplay.Objects.Electronics;
//using NRaas.NiecMod.Interactions;


#if NUMNAMEASS
namespace NRaas
{
    public class BootStrap
    {
        [Tunable]
        protected static bool kInstantiator;
    }
}
#endif

namespace NiecMod
{
	/// <summary>
	/// Description of Scripting Mod Instantiator, value does not matter, only its existence.
	/// </summary>
    public class Instantiator
    {
        // Anti GetMethed(str) :)
        public static bool dsffgherofhgfdig = false;

        public static bool otryirtuyortyoerd = false;

        public static object reytrjgosdfkr = null;

        public static readonly bool RootIsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");

        [Tunable, TunableComment("Scripting Mod Instantiator, value does not matter, only its existence")]
        protected static bool kInstantiator = false;

        [Tunable, TunableComment("Readly?")]
        protected static bool kMEBOXRealy = true;

        public static bool osdiertoeryo = false;

        public static string DGSModsAssembly = "DGSMods";

        //private static EventListener sSimInstantiatedListener = null;

        public static AlarmHandle mait =  AlarmHandle.kInvalidHandle;

        public static IntPtr nativbllv = new IntPtr(0);

        private static bool AddedNiecCore = false;

        public static void xmlload_DGS() { kInstantiator.Equals(false); kInstantiator = true; }

        public static ObjectGuid onKillSimTask = new ObjectGuid(0);

        public static EventListener AllDisgracefulActionEventListener = null;

        public static EventListener SimDied_AHNHSGoHome = null; 

        static Instantiator()
        {
            try
            {
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    Type type = Type.GetType("Sims3.Gameplay.ActorSystems.InteractionQueue, Sims3GameplaySystems");
                    if (type != null)
                    {
                        FieldInfo mField = type.GetField("NiecDefinitionSocialDeath_InteractionDefinition", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        if (mField != null)
                        {
                            mField.SetValue(null, KillSimNiecX.NiecDefinitionDeathInteraction.SocialSingleton);
                            mField = type.GetField("CacheNiecModSocial", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (mField != null)
                            {
                                mField.SetValue(null, typeof(KillSimNiecX.NiecDefinitionDeathInteraction));
                            }
                        }
                    }
                }
                else {
                    niec_std.mono_runtime_install_handlers();



                    try
                    {
                        NFinalizeDeath.StartCreateTaskFNHSWOW();
                        if (!NFinalizeDeath.MsCorlibModifed_IsExLists())
                        {
                            SafeCallInitClassSYN();
                        }
                        SafeCallInitClassNAW();
                        KillPro.CacheNiecS3Mod();
                        CreateAutoPoNull();
                        CreateNaviteTa();
                        CreateTaskAutoKillSim();
                        NiecHelperSituation.InitClass();
                    }
                    catch (Exception)
                    { }
                   
                }

                AssemblyCheckByNiec.create_cache_dmm_testh_xml();

                if (!NiecHelperSituation.isdgmods && (!NiecHelperSituation.___bOpenDGSIsInstalled_ && !NiecHelperSituation.__acorewIsnstalled__))
                    LoadSaveManager.ObjectGroupSaving += OnSavingGame;

                try
                {
                    if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        PreLinkDGSMODS();

                        NiecHelperSituation.InitClass();
                    }
                }
                catch (Exception)
                { }


                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    SafeCallInitClassNA();
                }

            }
            catch
            { }

            World.OnWorldLoadFinishedEventHandler += OnWorldLoadFinishedHandler;
            World.OnStartupAppEventHandler += OnStartupApp;
            World.OnWorldQuitEventHandler += OnWorldQuit;

            LoadSaveManager.ObjectGroupsPostLoad += PostLoad;
            LoadSaveManager.ObjectGroupsPreLoad += PostLoad; 
        }

        public static void PostLoad()
        {
            try
            {
                if (NiecRunCommand.ltrimhouse_bb)
                {
                    NFinalizeDeath.FixUpHouseholdListObjects(true);
                    NFinalizeDeath.TrimHouse(5, 10, true);
                }
            }
            catch (Exception)
            { }
        }

        [Tunable]
        public static bool kDontCallDGSACore = false;


        public static bool isdjreert = false;

        public static bool aH = false;
        public static bool aHh = false;
        public static bool ahHH = false;
        public static bool ahHHh = false;
        public static bool ahHHHh = false;
        public static bool ahHHHHh = false;
        public static bool ahHHHHHh = false;

        public static bool NGOInject = false;
        public static bool NSDInject = false; 
        public static bool NGInject = false;

        public static bool NACSDCInject = false;
        public static bool NFSInject = false;

        public static bool NHHInject = false;

        public static bool NLMInject = false;

        public static bool NSFWInject = false;

        public static bool NSCGUInject = false;

        public static bool NIMTInject = false;
        public static bool NIOPInject = false;
        public static bool NAUTOInject = false;

        public static bool NSIFROUNEInject = false;

        public static bool NOtherCLASS_Inject = false;

        public static bool NMotiveMood_Inject = false;

        public static bool SYNInject = false;

        public static void SafeCallInitClassSYN()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
            {
                try
                {
                    throw new NotSupportedException("Sims 3 64 bit version not supported.");
                }
                catch (Exception)
                {
                    return;
                }
            }

#if !GameVersion_0_Release_2_0_209
            try
            {
                 throw new NotSupportedException("Game versions not supported. Only Patch 1.67.2");
            }
            catch (Exception)
            {
                return;
            }
#else

            try
            {
                NFinalizeDeath.SafeCall(() =>
                {
                    if (!RootIsOpenDGSInstalled)
                    {
                        niec_native_func.init_class();
                        if ((uint)nativbllv == 0)
                            nativbllv = niec_native_func.LoadDLLNativeLibrary("Vrty.dll");
                    }
                    SYNInject = false;

                    try
                    {
                        SYNInject = NInjetMethed.NSystemEx_InjectMethod();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        SYNInject = false;
                    }

                    if (!SYNInject)
                    {
                        NFinalizeDeath.Assert("SYNInject failed.");
                        SYNInject = true;
                    }
                });
            }
            catch (Exception)
            {
                return;
            }
#endif
            if (!SYNInject)
            {
                NFinalizeDeath.Assert("SYNInject failed.");
            }
        }

        public static void SafeCallInitClassNAW()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
            {
                try
                {
                    throw new NotSupportedException("Sims 3 64 bit version not supported.");
                }
                catch (Exception)
                {
                    return;
                }
            }
           
#if !GameVersion_0_Release_2_0_209
            try
            {
                 throw new NotSupportedException("Game versions not supported. Only Patch 1.67.2");
            }
            catch (Exception)
            {
                return;
            }
#else

            try
            {
                NFinalizeDeath.SafeCall(() =>
                {
                    niec_native_func.init_class();
                    nativbllv = niec_native_func.LoadDLLNativeLibrary("Vrty.dll");
                    isdjreert = true;

                    NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr);
                    NFinalizeDeath.TestRunSEDInitProductFlags();

                    aH = false;
                    aHh = false;
                    ahHH = false;
                    ahHHh = false;
                    ahHHHh = false;
                    ahHHHHh = false;
                    ahHHHHHh = false;

                    NGOInject = false;
                    NSDInject = false;
                    NGInject = false;

                    NACSDCInject = false;
                    NFSInject = false;

                    NHHInject = false;

                    NLMInject = false;

                    NSFWInject = false;

                    NSCGUInject = false;

                    NIMTInject = false;
                    NIOPInject = false;
                    NAUTOInject = false;

                    NSIFROUNEInject = false;

                    NOtherCLASS_Inject = false;
                    NMotiveMood_Inject = false;


                    if (AssemblyCheckByNiec.IsInstalled("AweCore"))
                    {
                        try
                        {
                            aHh = NInjetMethed.ACoreMain_InjectMethed(typeof(NFinalizeDeath).GetMethod("TestRunSEDInitProductFlags"));
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            aHh = false;
                        }

                       

                        try
                        {
                            ahHH = NInjetMethed.BimUpdate_InjectMethedACore(typeof(UpdateBim).GetMethod("UpdateSim_Update", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            ahHH = false;
                        }

                        try
                        {
                            NGInject = NInjetMethed.NGenetics_InjectOtherMethed();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NGInject = false;
                        }
                        try
                        {
                            NACSDCInject = NInjetMethed.NACoreSBC_InjectOtherMethed();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NACSDCInject = false;
                        }

                        try
                        {
                            NHHInject = NInjetMethed.NHousehold_InjectOtherMehed();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NHHInject = false;
                        }
                        try
                        {
                            NLMInject = NInjetMethed.NLotManger_InjectOtherMethed();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NLMInject = false;
                        }
                        try
                        {
                            NSCGUInject = NInjetMethed.NSCGameUtils_InjectOtherMethed();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NSCGUInject = false;
                        }
                        try
                        {
                            NAUTOInject = NInjetMethed.NAuto_InjectOtherMethed();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NAUTOInject = false;
                        }
                        try
                        {
                            NSIFROUNEInject = NInjetMethed.NSIFRoute_InjectMethod();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NSIFROUNEInject = false;
                        }
                    }
                    else
                    {
                        aHh = true;
                        ahHH = true;
                        NGInject = true;
                        NACSDCInject = true;
                        NHHInject = true;
                        NLMInject = true;
                        NSCGUInject = true;
                        NAUTOInject = true;
                        NSIFROUNEInject = true;
                    }

                    try
                    {
                        NOtherCLASS_Inject = NInjetMethed.NOtherClass_InjectMethod();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        NOtherCLASS_Inject = false;
                    }

                    try
                    {
                        NMotiveMood_Inject = NInjetMethed.NMotive_InjectOtherMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        NMotiveMood_Inject = false;
                    }

                    try
                    {
                        NGOInject = NInjetMethed.NGameObject_InjectOtherMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        NGOInject = false;
                    }

                    try
                    {
                        NIMTInject = NInjetMethed.NIMT_InjectOtherMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        NIMTInject = false;
                    }
                    try
                    {
                        NIOPInject = NInjetMethed.NIOP_InjectOtherMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        NIOPInject = false;
                    }


                    try
                    {
                        NSDInject = NInjetMethed.BimDesc_InjectOtherMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        NSDInject = false;
                    }

                    bool issimiface2020 =
#if TESTSimIFace
                        AssemblyCheckByNiec.DGSSimIFaceIsInstalled();
#else
                        false;
#endif

                    if (!issimiface2020)
                    {
                        try
                        {
                            NSFWInject = NInjetMethed.NSimFaceWorld_InjectOtherMehed();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            NSFWInject = false;
                        }
                    }
                    else 
                        NSFWInject = true;

                    try
                    {
                        NFSInject = NInjetMethed.NFireS_InjectOtherMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        NFSInject = false;
                    }

                

                   

                    //if (!NiecMod.Instantiator.osdiertoeryo)
                    if (NFinalizeDeath.GetGoodType("DGSMods.Instantiator", false) == null)
                    {
                        try
                        {
                            ahHHHHHh = NInjetMethed.NEvertTracker_InjectOtherMethed(null);
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            ahHHHHHh = false;
                        }

                    }
                    else
                    {
                        ahHHHHHh = true;
                    }



                    try
                    {
                        ahHHh = NInjetMethed.Bim_InjectKillMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        ahHHh = false;
                    }




                    try
                    {
                        ahHHHh = NInjetMethed.Bim_InjectOtherMethed();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        ahHHHh = false;
                    }

                    try
                    {
                        ahHHHHh = NInjetMethed.PlumbBob_InjectAAAndSAA();
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        ahHHHHh = false;
                    }





                    if (!ahHHHHHh)
                    {
                        NFinalizeDeath.Assert("InjectEventX failed.");
                        ahHHHHHh = true;
                    }
                    if (!ahHHHHh)
                    {
                        NFinalizeDeath.Assert("PlumbBob_InjectAAAndSAA failed.");
                        ahHHHHh = true;
                    }
                    if (!ahHHHh)
                    {
                        NFinalizeDeath.Assert("Bim_InjectCanKillAndIsDyingMethed failed.");
                        ahHHHh = true;
                    }
                    if (!ahHHh)
                    {
                        NFinalizeDeath.Assert("Bim_InjectKillMethed failed.");
                        ahHHh = true;
                    }
                    if (!aHh)
                    {
                        NFinalizeDeath.Assert("AwCORInjectMethed failed.");
                        aHh = true;
                    }
                    if (!ahHH)
                    {
                        NFinalizeDeath.Assert("InjectMethedACore failed.");
                        ahHH = true;
                    }
                    if (!NGInject)
                    {
                        NFinalizeDeath.Assert("NGInject failed.");
                        NGInject = true;
                    }
                    if (!NGOInject)
                    {
                        NFinalizeDeath.Assert("NGOInject failed.");
                        NGOInject = true;
                    }
                    if (!NSDInject)
                    {
                        NFinalizeDeath.Assert("NSDInject failed.");
                        NSDInject = true;
                    }
                    if (!NACSDCInject)
                    {
                        NFinalizeDeath.Assert("NACSDCInject failed.");
                        NACSDCInject = true;
                    }
                    if (!NFSInject)
                    {
                        NFinalizeDeath.Assert("NFSInject failed.");
                        NFSInject = true;
                    }
                    if (!NHHInject) 
                    {
                        NFinalizeDeath.Assert("NHHInject failed.");
                        NHHInject = true;
                    }
                    if (!NLMInject)
                    {
                        NFinalizeDeath.Assert("NLMInject failed.");
                        NLMInject = true;
                    }
                    if (!NSFWInject)
                    {
                        NFinalizeDeath.Assert("NSFWInject failed.");
                        NSFWInject = true;
                    }
                    if (!NSCGUInject)
                    {
                        NFinalizeDeath.Assert("NSCGUInject failed.");
                        NSCGUInject = true;
                    }
                    if (!NIMTInject)
                    {
                        NFinalizeDeath.Assert("NIMTInject failed.");
                        NIMTInject = true;
                    }
                    if (!NIOPInject)
                    {
                        NFinalizeDeath.Assert("NIOPInject failed.");
                        NSFWInject = true;
                    }
                    if (!NAUTOInject)
                    {
                        NFinalizeDeath.Assert("NAUTOInject failed.");
                        NAUTOInject = true;
                    }
                    if (!NSIFROUNEInject)
                    {
                        NFinalizeDeath.Assert("NSIFROUNEInject failed.");
                        NSIFROUNEInject = true;
                    }
                    if (!NOtherCLASS_Inject)
                    {
                        NFinalizeDeath.Assert("NOtherCLASS_Inject failed.");
                        NOtherCLASS_Inject = true;
                    }
                    if (!NMotiveMood_Inject)
                    {
                        NFinalizeDeath.Assert("NMotiveMood_Inject failed.");
                        NMotiveMood_Inject = true;
                    }
                    try
                    {
                     
                        if (aH)
                            Sims3.SimIFace.GameUtils.InitProductFlags();

                        aH = niec_script_func.niecmod_script_copy_ptr_func_to_func(typeof(NFinalizeDeath).GetMethod("TestRunSEDInitProductFlags"), typeof(GameUtils).GetMethod("InitProductFlags"), false, false, true, false);
                    }
                    catch (Exception ex)
                    {
                        NiecException.SendTextExceptionToDebugger(ex);
                        aH = false;
                    }

                    if (!aH)
                        NFinalizeDeath.Assert("InjectRunSEDInitProductFlags failed.");
                });
            }
            catch { }

            if (!aH)
                NFinalizeDeath.Assert("InjectRunSEDInitProductFlags failed.");

            if (!aHh)
                NFinalizeDeath.Assert("AwCORInjectMethed failed.");

            if (!ahHH)
                NFinalizeDeath.Assert("InjectMethedACore failed.");

            if (!ahHHh)
                NFinalizeDeath.Assert("Bim_InjectKillMethed failed.");

            if (!ahHHHh)
                NFinalizeDeath.Assert("Bim_InjectCanKillAndIsDyingMethed failed.");

            if (!ahHHHHh)
                NFinalizeDeath.Assert("PlumbBob_InjectAAAndSAA failed.");

            if (!ahHHHHHh)
                NFinalizeDeath.Assert("InjectEventX failed.");

            if (!NGInject)
                NFinalizeDeath.Assert("NGInject failed.");

            if (!NGOInject)
                NFinalizeDeath.Assert("NGOInject failed.");

            if (!NSDInject)
                NFinalizeDeath.Assert("NSDInject failed.");

            if (!NACSDCInject)
                NFinalizeDeath.Assert("NACSDCInject failed.");

            if (!NFSInject)
                NFinalizeDeath.Assert("NFSInject failed.");

            if (!NHHInject)
                NFinalizeDeath.Assert("NHHInject failed.");

            if (!NLMInject)
                NFinalizeDeath.Assert("NLMInject failed.");

            if (!NSFWInject)
                NFinalizeDeath.Assert("NSFWInject failed.");

            if (!NSCGUInject)
                NFinalizeDeath.Assert("NSCGUInject failed.");

            if (!NIMTInject)
                NFinalizeDeath.Assert("NIMTInject failed.");

            if (!NIOPInject)
                NFinalizeDeath.Assert("NIOPInject failed.");

            if (!NAUTOInject)
                NFinalizeDeath.Assert("NAUTOInject failed.");

            if (!NSIFROUNEInject)
                NFinalizeDeath.Assert("NSIFROUNEInject failed.");

            if (!NMotiveMood_Inject)
                NFinalizeDeath.Assert("NMotiveMood_Inject failed.");

            if (!NOtherCLASS_Inject)
                NFinalizeDeath.Assert("NOtherCLASS_Inject failed.");
#endif
        }

        internal static IntPtr myAssemblyPtr = new IntPtr(0);
        internal static IntPtr dgsmAssemblyPtr = new IntPtr(0);
        internal static IntPtr ascAssemblyPtr = new IntPtr(0);
        internal static IntPtr kwAssemblyPtr = new IntPtr(0);
        internal static IntPtr nspAssemblyPtr = new IntPtr(0);

        internal static IntPtr ildorAAssemblyPtr = new IntPtr(0);
        internal static IntPtr ildorCAssemblyPtr = new IntPtr(0);
        internal static IntPtr ildorPAssemblyPtr = new IntPtr(0);

        internal static IntPtr scAssemblyPtr = new IntPtr(0);

        public static bool OKPSR = false;

        public static void SafeCallInitClassNA()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
            {
                try
                {
                    throw new NotSupportedException("Sims 3 64 bit version not supported.");
                }
                catch (Exception)
                {
                    return;
                }
            }
#if !GameVersion_0_Release_2_0_209
            try
            {
                 throw new NotSupportedException("Game versions not supported. Only Patch 1.67.2");
            }
            catch (Exception)
            {
                return;
            }
#else
            try
            {
                if (!isdjreert)
                    return;

                NFinalizeDeath.SafeCall(() =>
                {
                    OKPSR = false;
                    myAssemblyPtr = typeof(NFinalizeDeath).Assembly._mono_assembly;

                    var p = NFinalizeDeath.GetGoodType("Awesome.Main", false);
                    if (p != null)
                    {
                        ascAssemblyPtr = p.Assembly._mono_assembly;
                    }
                    if (ascAssemblyPtr != new IntPtr(0))
                    {
                        p = NFinalizeDeath.GetGoodType("Oniki.Utilities.SimTools", false);
                        if (p != null)
                        {
                            kwAssemblyPtr = p.Assembly._mono_assembly;
                        }

                        p = NFinalizeDeath.GetGoodType("NRaas.StoryProgressionModule", false);
                        if (p != null)
                        {
                            nspAssemblyPtr = p.Assembly._mono_assembly;
                        }

                        var a = AssemblyCheckByNiec.FindAssembly("lizcandorCommon");
                        if (a != null)
                        {
                            ildorCAssemblyPtr = a._mono_assembly;
                        }

                        a = AssemblyCheckByNiec.FindAssembly("lizcandorAttraction");
                        if (a != null)
                        {
                            ildorAAssemblyPtr = a._mono_assembly;
                        }

                        a = AssemblyCheckByNiec.FindAssembly("lizcandorPolyamory");
                        if (a != null)
                        {
                            ildorPAssemblyPtr = a._mono_assembly;
                        }

                        a = AssemblyCheckByNiec.FindAssembly("ScriptCore");
                        if (a != null)
                        {
                            scAssemblyPtr = a._mono_assembly;
                        }

                        try
                        {
                            OKPSR = NFinalizeDeath.SafePreventGetAssembliesPro();
                        }
                        catch (Exception ex)
                        {
                            NiecException.SendTextExceptionToDebugger(ex);
                            OKPSR = false;
                        }

                        if (!OKPSR)
                        {
                            NFinalizeDeath.Assert("OKPSR Failed.");
                        }
                    }
                    else
                        OKPSR = true;

                    // Mono bug that.

                    //if (!RootIsOpenDGSInstalled && AssemblyCheckByNiec.IsInstalled("AweCore"))
                    //{
                    //    bool p = false;
                    //    if (osdiertoeryo)
                    //    {
                    //        p = NFinalizeDeath.SafePreventGetAssemblies();
                    //    }
                    //    else
                    //    {
                    //        Assembly myAssembly = typeof(Instantiator).Assembly;
                    //        List<Assembly> aX = new List<Assembly>();
                    //
                    //        foreach (var item in NFinalizeDeath.GetAssemblies())
                    //        {
                    //            if (item == null) 
                    //                continue;
                    //
                    //            if (myAssembly == item || myAssembly._mono_assembly == item._mono_assembly)
                    //            {
                    //                aX.Add(item);
                    //                continue;
                    //            }
                    //
                    //            var v = item.GetName();
                    //            if (v == null)
                    //                continue;
                    //            if (v.Name == null) 
                    //                continue;
                    //
                    //            if (v.Name.Contains("AweCore") || v.Name.Contains("AwesomeMod") || v.Name.Contains("Oniki_KinkyMod") || v.Name.Contains("NRaasStoryProgression"))
                    //            {
                    //                aX.Add(item);
                    //            }
                    //        }
                    //
                    //        p = NFinalizeDeath.SafePreventGetAssembliesEx(aX.ToArray());
                    //    }
                    //
                    //    if (p)
                    //    {
                    //        otryirtuyortyoerd = true;
                    //    }
                    //    else
                    //    {
                    //        NFinalizeDeath.Assert("SafePreventGetAssemblies() || SafePreventGetAssembliesEx() failed.");
                    //        return;
                    //    }
                    //}

                    if (isdjreert && kMEBOXRealy)
                    {
                        niec_native_func.MessageBox(0, "Welcome to NiecMod\nNiecMod is free and open source\n\nHave Fun ;)", "NiecMod", 0);
                    }
                });
            }
            catch (Exception)
            { NFinalizeDeath.Assert("SafeCallInitClassNA failed."); }

            if (!OKPSR)
            {
                NFinalizeDeath.Assert("OKPSR Failed.");
            }
#endif
        }

        public static void AntiNPCACoreModSlowTickSim()
        {
            for (int i = 0; i < 5; i++)
            {
                NiecTask.Perform(ScriptExecuteType.Threaded,delegate {
                    while (true)
                    {
                        Simulator.Sleep(0);
                        //if (ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl() == 0)
                        //    continue;
                        if (NFinalizeDeath.SC_GetObjects<Sim>().Length >= 50)
                            continue;
                        NiecRunCommand.native_testcpu_debug(null, null);
                        
                    }
                });
            }

            NiecTask.Perform(ScriptExecuteType.Threaded, delegate
            {
                while (true)
                {
                    Simulator.Sleep(0);

                    if (ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl() == 1f || ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl() < 0.9f)
                        continue;

                    //var ic = NFinalizeDeath.SC_GetObjects<Sim>().Length;
                    if (NFinalizeDeath.SC_GetObjects<Sim>().Length < 15)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            NiecRunCommand.native_testcpu_debug(null, null);
                        }
                    }
                }
            });

            NiecTask.Perform(ScriptExecuteType.Threaded, delegate
            {
                while (true)
                {
                    Simulator.Sleep(0);
                    for (int i = 0; i < 3; i++)
                    {
                        NiecRunCommand.native_testcpu_debug(null, null);
                    }
                }
            });
        }

        public static void AutoLoopMaxIntSleepToWake()
        {
            NiecTask.Perform(delegate {
                NiecTask.SimulateAgainRuntimeFound();
                NiecTask.SetNeedNoErrorRuntime(true);

                List<MethodBase> cacheMBList = new List<MethodBase>(50), 
                                 cacheFailedMBList = new List<MethodBase>(200);

                List<ulong> cacheObjIDList = new List<ulong>(1500);

                int clueapint = 0, 
                    clueapintc = 0, 
                    sleep = 0;

                NiecTask niecTask = NiecTask.GetCurrentNiecTask();

                while (true)
                {
                    NFinalizeDeath.SleepTask (1355);

                    foreach (var item in NFinalizeDeath.SC_GetObjects<NiecTask>())
                    {
                        if (item == null || item == niecTask) 
                            continue;

                        var objID = item.ObjectId.mValue;
                        niec_std.mono_runtime_install_handlers();

                        try
                        {
                            ScriptCore.TaskContext context;
                            ScriptCore.TaskControl.GetTaskContext(objID, true, out context);
                            if (context.mSleepTicks == -1001)
                            {
                                sleep++;
                                if (sleep > 1150)
                                {
                                    sleep = 0;
                                    NFinalizeDeath.SleepTask(100);
                                    break;
                                }
                                object thisObj;
                                var mb = NFinalizeDeath._GetTaskContextTraceOne(context, out thisObj);
                                
                                if (mb == null || niec_std.array_indexof(cacheFailedMBList._items, mb) > 0)
                                    continue;


                                if (niec_std.array_indexof(cacheMBList._items, mb) < 0)
                                {
                                    if (cacheMBList._size > 99)
                                        cacheMBList.Clear();

                                    var name = mb.DeclaringType.ToString() + ":" + mb.Name;
                                    if (name.Contains("FollowRouteAction:PerformRoute"))
                                    {
                                        cacheMBList.Add(mb);
                                        goto done;
                                    }
                                    else if (name.Contains("EventQueue:GetNextEvent"))
                                    {
                                        cacheMBList.Add(mb);
                                        goto done;
                                    }
                                    else
                                    {
                                        if (cacheFailedMBList._size > 350)
                                        {
                                            cacheFailedMBList._version++;
                                            cacheFailedMBList._size = 0;
                                        }
                                        NFinalizeDeath.AddItemToList(cacheFailedMBList, mb);
                                        goto failed;
                                    }
                                }
                            done:
                                if (niec_std.array_indexof(cacheObjIDList._items, objID) > 0)
                                {
                                    ScriptCore.Simulator.Simulator_WakeImpl(objID, false);
                                    niec_std.list_remove(cacheObjIDList, objID);
                                }
                                else { cacheObjIDList.Add(objID); }
                            failed:;
                            }
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            NFinalizeDeath.SleepTask(755);
                            break;
                        }
                    }
                    clueapint++;
                    if (clueapint > 10)
                    {
                        cacheObjIDList.Clear();
                        clueapint = 0;
                    }
                    clueapintc++;
                    if (clueapintc > 50)
                    {
                        cacheFailedMBList.Clear();
                        clueapintc = 0;
                    }
                }
            });
        }

        public unsafe static void OnWorldQuit(object sender, EventArgs args) 
        {
            bool p = false;
            if (!NiecHelperSituation.___bOpenDGSIsInstalled_ && !NInjetMethed.DoneInjectOuit && GameStates.IsGameShuttingDown && !NiecRunCommand.ShouldUseUnWiz && NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.isdgmods)
            {
                //NFinalizeDeath.World_NativeInstance = 0x10000000u;
                NFinalizeDeath.SafeCall(() =>
                {
                    if (!NiecHelperSituation.___bOpenDGSIsInstalled_ && NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.isdgmods)
                    {
                        uint* ptr = stackalloc uint[0x2FFFF];
                        //for (int i = 0; i < 0x2FFFE; i++)
                        //{
                        //    ptr[i] = (uint)niec_std.yuv2rgb((i + 1) % 5 + (i * 5));
                        //}

                        NFinalizeDeath.World_NativeInstance = (uint)ptr;

                        NFinalizeDeath.MsCorlibModifed_Exlists(false);
                    }
                });
                p = true;
            }

            NiecHelperSituation.ShouldOnSavingGame_NonOpenDGS = false;

            try
            {
                NiecHelperSituation.NeedCreateNHSTask = false;

                SimDescCleanseTask.ShutDown();

                if (EventTracker.Instance != null)
                    EventTracker.RemoveListener(AllDisgracefulActionEventListener);

                AllDisgracefulActionEventListener = null;

                if (EventTracker.Instance != null)
                    EventTracker.RemoveListener(SimDied_AHNHSGoHome);

                SimDied_AHNHSGoHome = null;
            }
            catch (Exception) { }

            if (p)
                NFinalizeDeath.MsCorlibModifed_Exlists(false);

            NFinalizeDeath.RemoveTaskFromSimulator(ref onKillSimTask);

            if (p)
                NFinalizeDeath.MsCorlibModifed_Exlists(false);

            try
            {
                WriteLogOnWorldQuit(sender, args); 
            }
            catch (Exception) { }
            var tusev = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
            // stop slow runtime

            if (p)
                NFinalizeDeath.MsCorlibModifed_Exlists(false);

            if (!RootIsOpenDGSInstalled)
            {
                //NWorldFerry<NiecHelperSituation>.LoadCargo(true);
                Sims3.Gameplay.EventSystem.EventTracker.sInstance = new Sims3.Gameplay.EventSystem.EventTracker();
            }
            try
            {
                if (ListCollon.AllowNiecDisposedSimDescriptions && !RootIsOpenDGSInstalled && GameStates.sTravelData == null)
                {
                    using (TempSetActiveActorAndHousehold.Run(null))
                    {
                        foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                        {
                            if (p)
                                NFinalizeDeath.MsCorlibModifed_Exlists(false);
                            //NFinalizeDeath.SimDescCleanse(item, true, false);
                            SimDescCleanseTask.SafeCallSimDescCleanseO(item);
                        }
                    }
                }
            }
            catch (Exception) { }

            NFinalizeDeath.List_ClearEx(ref ListCollon.NiecSimDescriptions);

            if (p)
                NFinalizeDeath.MsCorlibModifed_Exlists(false);

            var lNiecDisposedSimDescriptions = ListCollon.NiecDisposedSimDescriptions;
            if (RootIsOpenDGSInstalled)
            {
                try
                {

                    if (lNiecDisposedSimDescriptions != null)
                        lNiecDisposedSimDescriptions.Clear();
                }
                catch (Exception) { } // mono bug or mod virus why?
                ListCollon.NiecDisposedSimDescriptions = null;
            }
            else
            {
                try
                {
                    if (lNiecDisposedSimDescriptions != null)
                    {
                        SimDescription[] simDescList;
                        try
                        {
                            simDescList = lNiecDisposedSimDescriptions.ToArray();
                        }
                        catch (Exception)
                        {
                            ListCollon.NiecDisposedSimDescriptions = null;
                            goto next;
                        }
                        
                        foreach (var item in simDescList)
                        {
                            //NFinalizeDeath.SimDescCleanse(item, true, false);
                            SimDescCleanseTask.SafeCallSimDescCleanseO(item);
                        }
                    }
                }
                catch (Exception) { }
            }

            if (p)
                NFinalizeDeath.MsCorlibModifed_Exlists(false);

            next:;
            if (tusev != null && Sims3.Gameplay.EventSystem.EventTracker.sInstance != null)
            {
                Sims3.Gameplay.EventSystem.EventTracker.sInstance = tusev;

                tusev.mActiveList = new Stack<List<EventListener>>();
                tusev.mAddList = new List<Pair<List<EventListener>, EventListener>>();
                tusev.mRemoveList = new List<Pair<List<EventListener>, EventListener>>();
            }

            if (p)
            {
                NFinalizeDeath.MsCorlibModifed_Exlists(false);

                Sims3.NiecHelp.Tasks.NiecTask.Perform(() =>
                {
                    while (true)
                    {
                        Simulator.Sleep(0);
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);
                    }
                });
            }
        }


        public static void WriteLogOnWorldQuit(object sender, EventArgs args)
        {
            
            

            string msge = Niec.iCommonSpace.KillPro.LogTraneEx.ToString();
            if (!string.IsNullOrEmpty(msge))
            {
                try
                {

                    NiecException.WriteLog(msge, true, false, false);
                    Niec.iCommonSpace.KillPro.sLogEnumeratorTrane = 0;
                    //Niec.iCommonSpace.KillPro.LogTraneEx = null;
                    Niec.iCommonSpace.KillPro.LogTraneEx = new StringBuilder();
                }
                catch
                { }
            }
            try
            {
                Niec.iCommonSpace.KillPro.sLogEnumeratorTrane = 0;
            }
            catch
            { }
            
        }

        public static bool testwihe = false;


        public static bool OpenDGS_GetNoCreate()
        {
            try
            {
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommands, Sims3GameplaySystems");
                    if (type != null)
                    {
                        FieldInfo mField = type.GetField("kNoCreateRandomSim", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        if (mField != null)
                        {
                           return (bool)mField.GetValue(null);
                        }
                    }
                }
            }
            catch (ResetException)
            { throw; }
            catch (Exception)
            { }
            return false;
        }

        public static void OpenDGS_SetNoCreate(bool value)
        {
            try
            {
                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommands, Sims3GameplaySystems");
                    if (type != null)
                    {
                        FieldInfo mField = type.GetField("kNoCreateRandomSim", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        if (mField != null)
                        {
                            mField.SetValue(null, value);

                        }
                    }
                }
            }
            catch (Exception)
            { }
            
        }

        public static bool Running_Task_Auto_Kill_Sim = false;
        public static bool Running_CreateAutoPoNull = false;
        public static ObjectGuid CreateAutoPoNull()
        {
            if (RootIsOpenDGSInstalled ||
                //AssemblyCheckByNiec.IsInstalled("DGSMods") ||
                Running_CreateAutoPoNull ||
                GameStates.IsGameShuttingDown)

                return ObjectGuid.InvalidObjectGuid;

            return NiecTask.Perform(() => {
                while (true)
                {
                    Simulator.Sleep(0);
                    try
                    {
                        niec_std.mono_runtime_install_handlers();
                        foreach (var ActorFor in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            if (ActorFor == null) continue;
                            //var s = ActorFor.Standing;
                            //if (s == null)
                            if (ActorFor.Standing == null)
                            {
                                ActorFor.Standing = new NiecPosture(ActorFor);
                            }
                            if (ActorFor.mPosture == null)
                            {
                                ActorFor.mPosture = ActorFor.Standing ?? new Sim.StandingPosture(ActorFor);
                            }
                            if (ActorFor.mPosture.PreviousPosture == ActorFor.mPosture)
                            {
                                ActorFor.mPosture.PreviousPosture = null;
                            }
                        }
                    }
                    catch (ResetException)
                    {
                        Running_CreateAutoPoNull = false;
                        if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        {
                            CreateAutoPoNull();
                            try
                            {
                                throw;
                            }
                            catch (ExecutionEngineException)
                            {
                                return;
                            }
                        }
                        else throw;
                    }
                    catch
                    {
                        for (int i = 0; i < 250; i++)
                            Simulator.Sleep(0);
                    }
                }
            });
        }

        public static object naitve_ui_my_o_CreateNaviteTa = null;

        public static void CreateNaviteTa()
        {
            if (naitve_ui_my_o_CreateNaviteTa == null || !(naitve_ui_my_o_CreateNaviteTa is Sims3.UI.SimpleTextTooltip))
            {
                try
                {
                    naitve_ui_my_o_CreateNaviteTa = new SimpleTextTooltip("naitve_ui_my_nonopendgs");
                }
                catch (Exception)
                { naitve_ui_my_o_CreateNaviteTa = null; }
               
            }
            Sims3.UI.SimpleTextTooltip dataTest = naitve_ui_my_o_CreateNaviteTa as Sims3.UI.SimpleTextTooltip;
            if (dataTest != null)
            {
                try
                {
                    if (dataTest.TooltipWindow != null)
                    {
                        dataTest.TooltipWindow.Position = UIManager.GetCursorPosition();
                        dataTest.TooltipWindow.Visible = false;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            var mainwindow = dataTest != null && dataTest.TooltipWindow != null ? dataTest.TooltipWindow : UIManager.GetMainWindow();
            if (mainwindow != null)
            {
                UIEventHandler<UIEventArgs> pTASK = delegate
                {
                    if (NFinalizeDeath.Vector3_IsUnsafe(ScriptCore.CameraController.Camera_GetTarget())) 
                        return;

                    var simList = NFinalizeDeath.SC_GetObjects<Sim>();
                    if (simList == null) return;
                    foreach (var ActorFor in simList)
                    {
                        if (ActorFor == null) continue;
                        if (ActorFor.Standing == null)
                        {
                            ActorFor.Standing = new NiecPosture(ActorFor);
                        }
                        if (ActorFor.mPosture == null)
                        {
                            ActorFor.mPosture = ActorFor.Standing ?? new Sim.StandingPosture(ActorFor);
                        }
                        if (ActorFor.mPosture.PreviousPosture == ActorFor.mPosture)
                        {
                            ActorFor.mPosture.PreviousPosture = null;
                        }
                    }
                };

                mainwindow.Tick -= pTASK;
                mainwindow.Tick += pTASK;

                UIEventHandler<UIEventArgs> monoEXTASK = delegate
                {
                    niec_std.mono_runtime_install_handlers();
                }; 

                mainwindow.Tick -= monoEXTASK;
                mainwindow.Tick += monoEXTASK;
            }
        }

        internal static ObjectGuid CreateTaskAutoKillSim()
        {
            if (RootIsOpenDGSInstalled || Running_Task_Auto_Kill_Sim || GameStates.IsGameShuttingDown)// || GameStates.IsInMainMenuState)
                return ObjectGuid.InvalidObjectGuid;
            
            return NiecTask.Perform(delegate {

                NiecTask.SimulateAgainRuntimeFound();
                NiecTask.SetNeedNoErrorRuntime(true);

                int sleep = 0;
                //bool isDGSMODS = AssemblyCheckByNiec.IsInstalled("DGSMods");
                while (true)
                {
                    Running_Task_Auto_Kill_Sim = true;
                    sleep = 0;
                    Simulator.Sleep(0); // WARNING!! don't use try catch.
                    try
                    {
                        //Sim[] simlist = Sims3.Gameplay.Queries.GetObjects<Sim>();
                        //var psim = NFinalizeDeath.SC_GetObjects<Sim>();

                        if (ScriptCore.CameraController.Camera_GetTarget() == NFinalizeDeath.__Vector3_Em)
                            continue;

                        foreach (var ActorFor in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            sleep++;
                            if (sleep > 19)
                            {
                                sleep = 0;
                                for (int i = 0; i < 10; i++)
                                    Simulator.Sleep(0);

                            }
                            if (NFinalizeDeath.Random_Chance(0.01f))
                                NiecRunCommand.AutoAllNewNiecSW(false, false, true);
                            else if (NFinalizeDeath.Random_Chance(0.010f))
                            { 
                                NFinalizeDeath.LoopSpeedSPSlow(110); 
                            }
                            try
                            {
                                if (ActorFor == null)
                                    continue;

                                Autonomy automoy = ActorFor.mAutonomy;
                                if (automoy == null)
                                    continue;








                                SimDescription simd = ActorFor.mSimDescription;
                                if (simd == null)
                                    continue;

                                if (simd.IsGhost || simd.IsDead)
                                    continue;

                                //if (ActorFor.HasBeenDestroyed)
                                //    continue;


                                global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = ActorFor.mInteractionQueue;
                                if (yInteractionQueue == null || yInteractionQueue.mInteractionList == null)
                                    continue;

                                if (yInteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton)
                                    || yInteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton))
                                    continue;



                                BuffManager bat = ActorFor.mBuffManager;
                                if (bat == null || bat.mValues == null)
                                    continue;



                                ICollection<BuffInstance> dfs = bat.List;
                                if (dfs == null)
                                    continue;

                                if (simd.ChildOrBelow || simd.IsPet) // Children Can use Starving Death
                                {
                                    foreach (var item in dfs)
                                    {
                                        if (item == null)
                                            continue;
                                        if (
                                            (item.mBuffGuid == BuffNames.Starving || item.mBuffGuid == BuffNames.StarvingPet)
                                                &&
                                            (item.mTimeoutCount < 30)
                                           )
                                        {

                                            if (KillPro.FastKill(ActorFor, SimDescription.DeathType.Starve, null, true, false))
                                            {
                                                bat.RemoveElement(item.mBuffGuid);
                                                Simulator.Sleep(0);
                                                goto nextOnFire;
                                            }
                                        }
                                    }

                                    Motives bMotives = automoy.mMotives;
                                    if (bMotives == null || bMotives.mMotives == null)
                                        continue;



                                    IEnumerable<Motive> sAllMotives = bMotives.AllMotives;
                                    if (sAllMotives == null)
                                        continue;
                                    foreach (var item in sAllMotives)
                                    {
                                        if (item == null)
                                            continue;
                                        if (item.Commodity == CommodityKind.Hunger && item.Tuning != null && item.mValue == item.Tuning.Min)
                                        {
                                            Simulator.Sleep(0);
                                            KillPro.FastKill(ActorFor, SimDescription.DeathType.Starve, null, true, false);

                                            break;
                                        }
                                    }
                                }
                            nextOnFire:
                                //if (!ActorFor.IsSelectable)
                                {
                                    foreach (var item in dfs)
                                    {
                                        if (item == null)
                                            continue;
                                        if (item.mBuffGuid == BuffNames.OnFire && item.mTimeoutCount < 3) {
                                            if (KillPro.FastKill(ActorFor, SimDescription.DeathType.Burn, null, true, false))
                                            {
                                                bat.RemoveElement(item.mBuffGuid);
                                                break;
                                            }
                                        }
                                        else if (item.mBuffGuid == BuffNames.Drowning && item.mTimeoutCount < 3) {
                                            if (KillPro.FastKill(ActorFor, SimDescription.DeathType.Drown, null, true, false))
                                            {
                                                bat.RemoveElement(item.mBuffGuid);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            catch (ResetException)
                            { throw; }
                            catch (Exception)
                            {
                                for (int i = 0; i < 45; i++)
                                    Simulator.Sleep(0);
                                continue;
                            }
                        }
                    }
                    catch (ResetException)
                    {
                        Running_Task_Auto_Kill_Sim = false;
                        if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        {
                            CreateTaskAutoKillSim();
                            try
                            {
                                throw;
                            }
                            catch (ExecutionEngineException)
                            {
                                return;
                            }
                        }
                        else throw;
                    }
                    catch
                    {
                        for (int i = 0; i < 150; i++)
                            Simulator.Sleep(0);
                    }

                }
            });
        }

        public static bool CancelActiveActorOnly = false;
        public static bool RunningActiveActorOnly = false;


        public static 
            bool ForceTrueTest
            (Sim actor, Sim target, ActiveTopic topic, bool isAutonomous, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
        { return true; }


        public static bool craetedTaskD_01 = false;
        public static bool craetedTaskD_02 = false;
        public static bool craetedTaskD_03 = false;
        public static bool craetedTaskD_04 = false;
        public static bool craetedTaskD_05 = false;
        public static bool OnSimDiedb = false;
        public static ListenerAction OpenDGS_OnSimDied(Event pSimDescEvent)
        {
            if (OnSimDiedb) // StackOverflowException?
                return ListenerAction.Keep;

            SimDescriptionEvent simDescEvent = pSimDescEvent as SimDescriptionEvent;
            if (simDescEvent == null)// || !Simulator.CheckYieldingContext(false)) 
                return ListenerAction.Keep;

            Sim deadSim = simDescEvent.mActor as Sim;
            if (deadSim == null) 
                return ListenerAction.Keep;
            

            var ahs = NFinalizeDeath.Household_GetAllActors(Household.ActiveHousehold);
            if (ahs == null) 
                return ListenerAction.Keep;

            var aa = PlumbBob.SelectedActor;
            try 
            {
                foreach (var item in ahs)
                {
                    if (item == null || item == aa) 
                        continue;
                    if (deadSim.LotCurrent == item.LotCurrent && item.mSimDescription != null && item.mAutonomy != null && NFinalizeDeath.SimIsNiecHelperSituation(item))
                    {
                        Sim.MakeSimGoHome(item, false);
                        //NFinalizeDeath.Sim_MaxMood(item);
                    }
                }
            }
            catch 
            { OnSimDiedb = true; }

            return ListenerAction.Keep;
        }
        public static ListenerAction NonOpenDGS_OnSimDied(Event unused)
        {
  
            if (onKillSimTask.mValue == 0) 
            {
                onKillSimTask = NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                {
                    try
                    {
                        Simulator.Sleep(40);
                        for (int i = 0; i < 1350; i++)
                        {
                            Simulator.Sleep(0);
                            var ahs = NFinalizeDeath.SC_GetObjects<Sim>();
                            if (ahs == null)
                                return;
                            var aa = PlumbBob.SelectedActor;
                            foreach (var item in ahs)
                            {
                                if (item == null || NFinalizeDeath.IsActiveHouseholdWithActiveActorPro(item.Household, aa))
                                    continue;
                                if (item.mInteractionQueue != null && item.mInteractionQueue.mInteractionList != null && NFinalizeDeath.SimIsNiecHelperSituation(item))
                                {
                                    item.mInteractionQueue.CancelAllInteractionsByType(GoHome.Singleton);
                                }
                            }
                        }
                        OnSimDiedb = false;
                        OpenDGS_OnSimDied(null);
                    }
                    finally
                    {
                        onKillSimTask.mValue = 0;
                    }
                    
                });
            }
            return ListenerAction.Keep;
        }

        public static void WaitLoadingDialogDispose() {
            NiecTask.Perform(delegate {
                while (NotificationManager.sNotificationManager == null) {
                    Simulator.Sleep(0);
                }
                OnLoadingDialogDispose();
            });
        }
        
        private static void OnLoadingDialogDispose() {
            if (Assembly.GetExecutingAssembly() == Assembly.GetCallingAssembly())
            {
                NiecHelperSituation.OnLoadingDialogDispose();
            }
        }

       


        public static void PreLinkDGSMODS()
        {
            foreach (var item in NFinalizeDeath.GetAssemblies())
            {
                if (item == null) 
                    continue;

                var ax = item.GetType("DGSMods.Instantiator", false);
                if (ax != null)
                {
                    var px = ax.GetField("kNInstantiator", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (px != null)
                    {
                        dgsmAssemblyPtr = px.DeclaringType.Assembly._mono_assembly;
                        px.SetValue(null, true);
                        return;
                    }
                }
            }
        }

        public static void OnSavingGame(IScriptObjectGroup group)
        {
            if (!NiecHelperSituation.isdgmods && (!NiecHelperSituation.___bOpenDGSIsInstalled_ && !NiecHelperSituation.__acorewIsnstalled__))
                NFinalizeDeath.RemoveAllSimNiecNullForGrave();
        }

        public static bool LoopSpeedSPSlowdone = false;
        public static void OnWorldLoadFinishedHandler(object sender, System.EventArgs e)
        {

            try
            {
                if (NiecRunCommand.ltrimhouse_bb) {
                    NFinalizeDeath.FixUpHouseholdListObjects(true);
                    NFinalizeDeath.TrimHouse(10, 8, true);
                }
                if (!LoopSpeedSPSlowdone)
                {
                    LoopSpeedSPSlowdone = true;
                    NFinalizeDeath.LoopSpeedSPSlow(15);
                }
                
            }
            catch (Exception)
            { } 
            WaitLoadingDialogDispose();
            NiecRunCommand.ltrimhouse_bb = false;
            try
            {
                NiecTask.Perform(delegate
                {
                    Simulator.Sleep(1);
                    //KillPro.CacheNiecS3Mod();
                    try
                    {
                        CASAGSAvailabilityFlags cas = ParserFunctions.ParseAllowableAgeSpecies("T,Y,A,E");
                        ActionData socialdata;
                        if (ActionData.sData.TryGetValue("Teen Insult", out socialdata))
                        {
                            socialdata.mActorAgeAllowed = cas;
                            socialdata.mTargetAgeAllowed = cas;
                            socialdata.ProceduralTest = null;//typeof(Instantiator).GetMethod("ForceTrueTest");
                        }
                    }
                    catch (Exception)
                    { }
                });
                if (ScriptCore. World.World_IsEditInGameFromWBModeImpl()) 
                    OpenDGS_SetNoCreate(false);

                if (AlarmManager.Global != null)
                {
                    try
                    {
                        foreach (var helperNra in HelperNra.HelperNraLists)
                        {
                            if (helperNra != null)
                                helperNra.this_alarm = AlarmManager.Global.AddAlarm
                                    (1f, TimeUnit.Days, helperNra.FailedCallBookSleep, null, AlarmType.NeverPersisted, null);
                        }
                    }
                    catch (Exception)
                    { }
                }
                else {
                    NiecTask.Perform(delegate
                    {
                        Simulator.Sleep(1);
                        foreach (var helperNra in HelperNra.HelperNraLists)
                        {
                            if (helperNra != null)
                                helperNra.this_alarm = AlarmManager.Global.AddAlarm
                                    (1f, TimeUnit.Days, helperNra.FailedCallBookSleep, null, AlarmType.NeverPersisted, null);
                        }
                    });
                }

                try
                {
                    SCOSR.OnLoading();
                }
                catch (Exception)
                { }

                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    if (NiecHelperSituation.__acorewIsnstalled__)
                    {
                        NFinalizeDeath.sMasterForceDestroyObject = AssemblyCheckByNiec.IsInstalled(DGSModsAssembly);
                    }

                    
                 
                    NiecRunCommand.GCKeepGameCrash = NiecHelperSituation.asdoetr as List<object> ?? NiecRunCommand.GCKeepGameCrash;
                    NiecHelperSituation.asdoetr = null; 
                    if (NFinalizeDeath.tDataR_ExV == null)
                    {
                        NFinalizeDeath.tDataR_ExV = new NResetEx();
                    }
                    
                    NiecHelperSituation.ShouldOnSavingGame_NonOpenDGS = false;

                    Household.kMinFamilyFunds = 0; // Non-active Household cheat Funds ?
                    Household.kInitialFamilyFunds = 30000;

                    Lot.kInactiveLotSleepTicks = 0;

                    Sim.kSimLoopSleepTicksWhenNotInQueue = 1;
                    Sim.kSimLoopSleepTicksWhenInAutonomyQueue = 1;
                    Sim.kSimLoopSleepTicksWhenAutonomyDisabled = 1;

                    Services.kSimulatorSleepCount = 200;



                    try
                    {
                        NiecRunCommand.testFuncCPUC = (ListCollon.SafeRandomPart2 ?? new Random(5000)).Next(900, 2000);
                        if (NiecHelperSituation.__kinkymdisInstalled)
                        {
                            NiecTask.Perform(delegate
                            {
                                while (NotificationManager.sNotificationManager == null)
                                {
                                    Simulator.Sleep(0);
                                }
                                while (!GameStates.IsLiveState)
                                {
                                    Simulator.Sleep(0);
                                }
                                for (int i = 0; i < 10; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                                global::Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.Init();
                                global::Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_InteractionOverrides.Init();
                            });
                        }
                        else
                        {
                            global::Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_KillSimOverride.Init();
                            global::Sims3.Gameplay.NiecNonOpenDGS.Interactions.NonOpenDGS_InteractionOverrides.Init();
                        }
                    }
                    catch
                    { }

                    NiecTask.Perform(delegate {
                        Simulator.Sleep(1);
                        Dictionary<ObjectGuid, bool> sAllRunning;
                        var NRaasErrorTrapType = Type.GetType("NRaas.ErrorTrap, NRaasErrorTrap", false);
                        if (NRaasErrorTrapType == null) return;
                        var fi = NRaasErrorTrapType.GetField("sAllRunning", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        if (fi == null)
                            return;
                        sAllRunning = fi.GetValue(null) as Dictionary<ObjectGuid, bool>;
                        while (sAllRunning == null)
                        {
                            sAllRunning = fi.GetValue(null) as Dictionary<ObjectGuid, bool>;
                            Simulator.Sleep(0);
                        } 
                        if (sAllRunning == null)
                            return;
                        while (true)
                        {
                            Simulator.Sleep(0);
                            fi.SetValue(null, new Dictionary<ObjectGuid, bool>());
                        }
                    });
                    NiecTask.Perform(delegate
                    {
                        Simulator.Sleep(550);
                        if (!AssemblyCheckByNiec.IsInstalled(DGSModsAssembly))
                        {
                            var lot_world = LotManager.GetWorldLot();
                            if (lot_world != null)
                            {
                                var saved_data = lot_world.mSavedData;
                                if (saved_data != null)
                                {
                                    if (saved_data.mAlarmManager == null)
                                    {
                                        saved_data.mAlarmManager = AlarmManager.sWorldAlarmManager;
                                    }
                                }
                            }
                        }
                    });
                    NiecTask.Perform(delegate
                    {
                        //Simulator.Sleep(1);
                        while (NotificationManager.sNotificationManager == null)
                        {
                            Simulator.Sleep(0);
                        }
                        //Simulator.Sleep(10);
                        HudModel hudModel = Sims3.UI.Responder.Instance.HudModel as HudModel;
                        while (hudModel == null) {
                            hudModel = Sims3.UI.Responder.Instance.HudModel as HudModel;
                            //Simulator.Sleep(1);
                            Simulator.Sleep(0);
                        }
                        if (hudModel != null)
                        {

                            try
                            {
                                EventTracker.RemoveListener(hudModel.mOnSelectedSimChangedEvent);
                            }
                            catch (Exception)
                            {}
                           
                            hudModel.mOnSelectedSimChangedEvent = null;


                            ProcessEventDelegate keepOnSelectedSimChanged = delegate(Event ex)
                            {
                                try
                                {
                                    hudModel.OnSelectedSimChanged(ex);
                                }
                                catch (ResetException)
                                { }
                                catch
                                {
                                    try
                                    {
                                        if (AssemblyCheckByNiec.IsInstalled("AweCore"))
                                        {
                                            NFinalizeDeath.List_FastClearEx(ref hudModel.mVisitorList);
                                            //hudModel.mVisitorList = null;
                                            NFinalizeDeath.List_FastClearEx(ref hudModel.mSimList);
                                            //hudModel.mSimList = null;
                                        }
                                        hudModel.mCurrentHousehold = null;
                                        hudModel.mSavedCurrentSim = null;
                                        hudModel.OnSelectedSimChanged(ex);
                                    }
                                    catch
                                    { }
                                }
                                return ListenerAction.Keep;
                            };

                            while (true)
                            {
                                try
                                {
                                    if (GameStates.IsGameShuttingDown || GameStates.IsWorldShuttingDown || GameStates.IsInMainMenuState)
                                        return;
                                    hudModel.mOnSelectedSimChangedEvent = EventTracker.AddListener(EventTypeId.kEventSimSelected, keepOnSelectedSimChanged);
                                    if (hudModel.mOnSelectedSimChangedEvent != null && EventTracker.ContainsListener(hudModel.mOnSelectedSimChangedEvent))
                                        break;
                                    Simulator.Sleep(0);
                                }
                                catch (ResetException)
                                { return; }
                                catch (Exception)
                                {
                                    for (int i = 0; i < 200; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }
                                    continue;
                                }
                                NFinalizeDeath.M();
                            }
                            while (true)
                            {
                                Simulator.Sleep(0);

                                if (GameStates.IsGameShuttingDown || GameStates.IsWorldShuttingDown || GameStates.IsInMainMenuState)
                                    return;

                                while (EventTracker.Instance == null)
                                {
                                    if (GameStates.IsGameShuttingDown || GameStates.IsWorldShuttingDown || GameStates.IsInMainMenuState)
                                        return;
                                    Simulator.Sleep(0);
                                }

                                for (int i = 0; i < 100; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                                try
                                {
                                    if (!EventTracker.ContainsListener(hudModel.mOnSelectedSimChangedEvent))
                                    {
                                        EventTracker.RemoveListener(hudModel.mOnSelectedSimChangedEvent);
                                        hudModel.mOnSelectedSimChangedEvent = null;
                                        hudModel.mOnSelectedSimChangedEvent = EventTracker.AddListener(EventTypeId.kEventSimSelected, keepOnSelectedSimChanged);
                                        Simulator.Sleep(0);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < 1000; i++)
                                        {
                                            Simulator.Sleep(0);
                                        }
                                    }
                                }
                                catch (ResetException)
                                { throw; }
                                catch
                                {
                                    for (int i = 0; i < 200; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }
                                }
                            }
                        }
                    });
                    NiecTask.Perform(delegate
                    {
                        Simulator.Sleep(0);
                        NFinalizeDeath.CacheCClean__Data = null;
                        while (!NFinalizeDeath.CacheCClean())
                        {
                            Simulator.Sleep(0);
                        }
                    });
                    if (!craetedTaskD_01)
                    {
                        craetedTaskD_01 = true;
                        // unprotected mono mscorlib 
                        // Need Fast Code :)
                        AutoLoopMaxIntSleepToWake();
                        if (AssemblyCheckByNiec.IsInstalled(DGSModsAssembly) && AssemblyCheckByNiec.IsInstalled("AweCore"))
                        {
                            AntiNPCACoreModSlowTickSim();
                        }
                        
                        NiecTask.Perform(delegate
                        {
                            NiecTask.SimulateAgainRuntimeFound();
                            NiecTask.SetNeedNoErrorRuntime(true);

                            Simulator.Sleep(1);

                            while (true)
                            {
                                if (!NiecRunCommand.loopdunusedsu)
                                {
                                    Simulator.Sleep(0);
                                    continue;
                                }
                                for (int i = 0; i < 85; i++) { Simulator.Sleep(0); } Simulator.Sleep(0);

                                NiecRunCommand.dunusedsu_command();
                            }
                        });
                        NiecTask.Perform(delegate {

                            NiecTask.SimulateAgainRuntimeFound();
                            NiecTask.SetNeedNoErrorRuntime(true);

                            while (true)
                            {
                                Simulator.Sleep(0);

                                if (ScriptCore.CameraController.Camera_GetTarget() == NFinalizeDeath.__Vector3_Em)
                                    continue;

                                try
                                {
                                    var sim_list = NFinalizeDeath.SC_GetObjects<Sim>();
                                    if (sim_list != null)
                                    {
                                        foreach (var item in sim_list)
                                        {
                                            if (item != null && NFinalizeDeath._SimRunningNHSInteraction(item))
                                            {
                                                NiecRunCommand.item_remove_iq_running_list(item, false);
                                            }
                                        }
                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch { NFinalizeDeath.SleepTask(150); }
                                
                            }
                        });

                        NiecTask.Perform(delegate
                        {
                            NiecTask.SimulateAgainRuntimeFound();
                            NiecTask.SetNeedNoErrorRuntime(true);

                            while (true)
                            {
                                Simulator.Sleep(0);
                                if (!NiecHelperSituation.kLoopAllSimFadnIn)
                                    continue;

                                NFinalizeDeath.SleepTask(15);
                                
                                try
                                {
                                    var sim_list = NFinalizeDeath.SC_GetObjects<Sim>();
                                    if (sim_list != null)
                                    {
                                        foreach (var sim_item in sim_list)
                                        {
                                            if (sim_item != null 
                                                && NFinalizeDeath._SimRunningNHSInteraction(sim_item))
                                            {
                                                var sim_object_id = sim_item.ObjectId; // check null

                                                ScriptCore.World.World_ObjectSetHiddenFlags (
                                                    sim_object_id.mValue, 
                                                   // (uint)((int)ScriptCore.World.World_ObjectGetHiddenFlags(sim_object_id.mValue) & -2)
                                                   0
                                                );

                                                ScriptCore.World.World_ObjectSetOpacity (
                                                    sim_object_id.mValue,
                                                    1,
                                                    1
                                                );
                                            }
                                        }
                                    }
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch { NFinalizeDeath.SleepTask(250); }

                            }
                        });

                        NiecTask.Perform(delegate
                        {
                            while (true)
                            {
                                NFinalizeDeath.SleepTask(45);

                                try
                                {
                                    var it = NFinalizeDeath.NeedRunNHSI;
                                    if (it == null)
                                        continue;

                                    if (it._size < 0)
                                        it._size = 0;

                                    if (it.Count == 0) 
                                        continue;

                                 reset:

                                    var needRunNHSI_items = it._items;
                                    if (needRunNHSI_items == null)
                                        continue;

                                    var yuCount = it._size;
                                    int sleep = 0;

                                    for (int i = 0, imaxLength = needRunNHSI_items.Length; i < imaxLength && i < yuCount; i++)
                                    {
                                        //if (i >= yuCount)
                                        //    break;

                                        var iteractionInstanceNHS = needRunNHSI_items[i] as InteractionInstance;
                                        needRunNHSI_items[i] = null;

                                        it._size--;
                                        it._version++;

                                        if (iteractionInstanceNHS == null)
                                            continue;

                                        if (NFinalizeDeath.InteractionIsNiecHelperSituation(iteractionInstanceNHS))
                                        {
                                            NFinalizeDeath.RunFuncDoIntRun(iteractionInstanceNHS);
                                        }
                                        if (sleep++ > 54)
                                        {
                                            NFinalizeDeath.SleepTask((uint)yuCount);
                                            NFinalizeDeath.SleepTask(65u + (uint)i);
                                            goto reset;
                                        }
                                    }
                                }
                                catch (ResetException)
                                { throw; }
                                catch { NFinalizeDeath.SleepTask(850); }
                                
                            }
                        });
                        if (NiecHelperSituation.__acorewIsnstalled__)
                        {
                            NiecTask.Perform(delegate
                            {
                                while (true)
                                {
                                    Simulator.Sleep(1);

                                    if (NiecRunCommand.loopraa_01_ObjectID.mValue == 0)
                                    {
                                        NiecRunCommand.loopraa_C = true;
                                        NiecRunCommand.loopraa_Command();
                                        NiecRunCommand.loopraa_C = false;
                                    }
                                }
                            });
                        }
                        NiecTask.Perform(delegate
                        {
                            Simulator.CheckYieldingContext(true);

                            NiecTask.SimulateAgainRuntimeFound();
                            NiecTask.SetNeedNoErrorRuntime(true);

                            while (true)
                            {
                                Simulator.Sleep(0);
                                try
                                {
                                    NFinalizeDeath.TestAddInteractionError();
                                }
                                catch (ResetException)
                                { throw; }
                                catch { Simulator.Sleep(1); }

                            }
                        });
                        for (int itemS = 0; itemS < 4; itemS++) NiecTask.Perform(delegate
                        {
                            while (true)
                            {
                                Sim.OneSimActive = false; // Anti-EvilMod :)
                                Simulator.Sleep(0);
                            }
                        });
                        if (NiecHelperSituation.__acorewIsnstalled__ && NiecHelperSituation.isdgmods)
                        {
                            NiecTask.Perform(delegate
                            {
                                while (true)
                                {
                                    Simulator.Sleep(0);
                                    var ev = EventTracker.Instance;
                                    if (ev == null) continue;
                                    var ti = ev.mActiveList;
                                    if (ti == null || ti.data == null) continue;
                                    if (ti.Count > 200)
                                    {
                                        ti.Clear();
                                        continue;
                                    }
                                    if (ti.Count > 40)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < 30; i++)
                                        {
                                            ti.Push(new List<EventListener>());
                                        }
                                    }

                                }
                            });
                        }
                        NiecTask.Perform(delegate
                        {
                            while (true)
                            {
                                Simulator.Sleep(0);
                                PlumbBob.sCurrentNonNullHousehold = Household.ActiveHousehold;
                            }
                        });
                        NiecTask.Perform(delegate
                        {
                            while (true)
                            {
                                Simulator.Sleep(0);

                                //SimRoutingComponent.kDefaultImmuneToPushesDuration = 150;
                                //SimRoutingComponent.kOnEmergencyGetAwayRouteStartedImmuneToPushesDuration = 350;
                                //SimRoutingComponent.kOnRouteStartedImmuneToPushesDuration = 100;

                                SimRoutingComponent.kDefaultImmuneToPushesDuration = 1;
                                SimRoutingComponent.kOnEmergencyGetAwayRouteStartedImmuneToPushesDuration = 1;
                                SimRoutingComponent.kOnRouteStartedImmuneToPushesDuration = 1;

                                SimRoutingComponent.kDefaultStandAndWaitDuration = 150;
                                SimRoutingComponent.kMaximumPostPushStandAndWaitDuration = 65;
                                SimRoutingComponent.kMinimumPostPushStandAndWaitDuration = 15f;

                                SimRoutingComponent.kEndOfPortalInvicibilityDuration = 0.5f;
                            }
                        });
                        NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                        {
                            while (true)
                            {
                                Simulator.Sleep(250);
                                try
                                {
                                    NiecHelperSituation.OnLoadingDialogDispose();
                                }
                                catch (ResetException) { throw; }
                                catch { }

                            }
                        });

                        NiecTask.Perform(delegate
                        {
                            while (true)
                            {
                                for (int i = 0; i < 3500; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                                GC.Collect();
                            }
                        });

                        NFinalizeDeath.field_NeedNewSituations = true;


                        if (CommandSystem.Exists())
                            CommandSystem.ExecuteCommandString("niecmod autosave");

                        //for (int i = 0; i < 3; i++)
                        {
                            NiecTask.Perform(ScriptExecuteType.Threaded, NFinalizeDeath.LoopReAllNHSOnTick);
                        }
                        
                        NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                        {
                            VisualEffect mGrimReaperSmoke = null;
                            Simulator.Sleep(1);
                            while (true)
                            {
                                Simulator.Sleep(0);
                                try
                                {
                                    GrimReaper grimReaperService = GrimReaper.sGrimReaper;
                                    if (grimReaperService != null && grimReaperService.mPool != null)
                                    {
                                        foreach (var item in grimReaperService.mPool.ToArray())
                                        {
                                            if (item == null)
                                                continue;
                                            if (item.CreatedSim != null)
                                            {
                                                if (!NFinalizeDeath.baCheckACoreThrowNRaasErrorTrap && !NiecHelperSituation.isdgmods)
                                                {
                                                    reytrjgosdfkr = item.CreatedSim;
                                                    item.CreatedSim.mIsAlreadyIdling = true;
                                                }
                                                continue;
                                            }
                                            //if (item.mHousehold == null)
                                            //    NFinalizeDeath.SimDescIsGrimReaperService(item, true);
                                            //else 
                                            //    NFinalizeDeath.SimDescIsGrimReaperService(item, false);
                                            NFinalizeDeath.SimDescIsGrimReaperService(item, item.mHousehold == null);
                                           var sim =  
                                               NFinalizeDeath.SimDesc_SafeInstantiate(item, World.SnapToFloor(CameraController.GetTarget()));
                                           if (sim != null && NFinalizeDeath.baCheckACoreThrowNRaasErrorTrap)
                                               sim.mInteractionQueue = null;
                                           if (sim != null && !NiecHelperSituation.isdgmods)
                                           {
                                               reytrjgosdfkr = sim;
                                               if (mGrimReaperSmoke != null)
                                               {
                                                   try
                                                   {
                                                       mGrimReaperSmoke.Stop();
                                                       mGrimReaperSmoke.Dispose();
                                                   }
                                                   catch (ResetException)
                                                   {

                                                       throw;
                                                   }
                                                   catch { mGrimReaperSmoke = null; }
                                                   
                                               }
                                               mGrimReaperSmoke = VisualEffect.Create("reaperSmokeConstant");
                                               if (mGrimReaperSmoke != null)
                                               {
                                                   mGrimReaperSmoke.ParentTo(sim, Sim.FXJoints.Pelvis);
                                                   mGrimReaperSmoke.Start();
                                               }

                                               sim.mIsAlreadyIdling = true;
                                               NiecHelperSituationPosture.ExistsOrCreatePosture(sim, true);

                                              
                                               //for (int i = 0; i < 40; i++)
                                               //{
                                               //    Simulator.Sleep(0);
                                               //}
                                               NiecRunCommand.fcreap_Icommand(sim, false, true);
                                               
                                               if (!dsffgherofhgfdig)
                                               {
                                                   dsffgherofhgfdig = true;
                                                   NiecTask.Perform(ScriptExecuteType.Task, delegate
                                                   {
                                                       try
                                                       {
                                                           while (true)
                                                           {
                                                               for (int i = 0; i < 450; i++)
                                                               {
                                                                   Simulator.Sleep(0);
                                                               }
                                                               Simulator.Sleep(0);
                                                               var Vsim = reytrjgosdfkr as Sim;
                                                               if (Vsim == null)
                                                                   continue;
                                                               if (Vsim.mPosture is NiecHelperSituationPosture) 
                                                                   continue;
                                                               if (Vsim == null || Simulator.GetProxy(Vsim.ObjectId) == null)
                                                                   continue;
                                                               var pt = Vsim.mPosture;
                                                               if (pt != null)
                                                               {
                                                                   pt.PreviousPosture = null;
                                                                   pt.HasBeenCanceled = true;
                                                               }
                                                               NiecHelperSituationPosture.ExistsOrCreatePosture(Vsim, true);
                                                               NiecRunCommand.fcreap_Icommand(sim, false, true);
                                                               sim.FadeIn();
                                                           }
                                                       }
                                                       finally
                                                       {
                                                           dsffgherofhgfdig = false;
                                                       }

                                                   });
                                               }
                                               //NiecRunCommand.fcreap_Icommand(sim, false, true);
                                           }
                                           //if (sim != null)
                                           //    NiecHelperSituationPosture.ExistsOrCreatePosture(sim, true);
                                        }
                                    }
                                }
                                catch (ResetException)
                                { throw; }
                                catch (Exception)
                                {
                                    for (int i = 0; i < 200; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }
                                }

                            }
                        });
                        if (!Instantiator.osdiertoeryo) //!AssemblyCheckByNiec.IsInstalled(DGSModsAssembly))
                            NiecTask.Perform(delegate
                            {
                                List<ulong> ul = new List<ulong>();
                                while (true)
                                {
                                    Simulator.Sleep(0);
                                    try
                                    {
                                        NiecSocialWorkerChildAbuseSituation niecSWCAS;
                                        SocialWorkerChildAbuse swork = SocialWorkerChildAbuse.sSocialWorker;
                                        if (swork != null)
                                        {
                                            Dictionary<ulong, Service.ServiceRequest> mlot = swork.mLotsRequested;
                                            if (mlot != null && mlot.Count > 0 && mlot.Keys != null)
                                            {
                                                ul.AddRange(mlot.Keys);
                                                foreach (var item in ul)
                                                {
                                                    Lot lotTarget = LotManager.GetLot(item);
                                                    try
                                                    {
                                                        if (lotTarget != null)
                                                            NFinalizeDeath.CreateSocialWorkerToTargetLot(lotTarget, NFinalizeDeath.IsNPCSimTest_NiecSocialWorkerChildAbuseSituation, true, out niecSWCAS);
                                                    }
                                                    catch (ResetException)
                                                    { throw; }
                                                    catch (Exception)
                                                    { }

                                                    mlot.Remove(item);
                                                }
                                                ul.Clear();

                                            }
                                        }
                                    }
                                    catch (ResetException)
                                    { throw; }
                                    catch (Exception)
                                    {
                                        for (int i = 0; i < 200; i++)
                                        {
                                            Simulator.Sleep(0);
                                        }
                                    }

                                }
                            });
                        NiecTask.Perform(delegate
                        {


                            Simulator.Sleep(5);

                            while (true)
                            {
                                Simulator.Sleep(0);

                                foreach (var ActorFor in NFinalizeDeath.SC_GetObjects<Sim>())
                                {
                                    Simulator.Sleep(0);

                                    SimDescription simd = ActorFor.SimDescription;

                                    if (simd == null)
                                        continue;

                                    if (ActorFor.HasBeenDestroyed) continue;

                                    Sims3.Gameplay.ActorSystems.InteractionQueue iInteractionQueue = ActorFor.InteractionQueue;
                                    if (iInteractionQueue == null || iInteractionQueue.mInteractionList == null)
                                        continue;

                                    Autonomy automoy = ActorFor.Autonomy;
                                    if (automoy == null)
                                        continue;

                                    SituationComponent sSituationComponent = automoy.SituationComponent;
                                    if (sSituationComponent == null)
                                        continue;

                                    List<Situation> listSituations = sSituationComponent.Situations;
                                    if (listSituations == null)
                                        continue;

                                    GrimReaperSituation grimReaperSituation = ServiceSituation.FindServiceSituationInvolving(ActorFor) as GrimReaperSituation;
                                    if (grimReaperSituation != null)
                                    {
                                        NiecHelperSituation niecHelperSituation = ActorFor.GetSituationOfType<NiecHelperSituation>();
                                        if (niecHelperSituation == null)
                                        {
                                            var nhs = NiecHelperSituation.Create(ActorFor.LotCurrent, ActorFor);
                                            if (nhs != null)
                                                listSituations.Add(nhs);
                                            else { NFinalizeDeath.ForceDestroyObject(ActorFor, false); continue; }
                                            listSituations.Remove(grimReaperSituation);

                                            for (int i = 0; i < 50; i++)
                                            {
                                                Simulator.Sleep(0);
                                                if (ActorFor.mSimDescription == null || ActorFor.HasBeenDestroyed) break;
                                                foreach (var item in iInteractionQueue.mInteractionList.ToArray())
                                                {
                                                    if (item is GrimReaperSituation.LeaveLot)
                                                    {
                                                        item.mbOnStopCalled = true;
                                                        iInteractionQueue.mInteractionList.Remove(item);
                                                    }
                                                    if (item is GrimReaperSituation.GrimReaperAppear)
                                                    {
                                                        item.mbOnStopCalled = true;
                                                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(ActorFor);
                                                        try
                                                        {
                                                            ActorFor.DoReset(new GameObject.ResetInformation());
                                                        }
                                                        catch (ResetException)
                                                        {
                                                            if (!Simulator.CheckYieldingContext(false))
                                                                throw;
                                                        }
                                                        catch { }
                                                        break;
                                                    }
                                                }
                                            }
                                            for (int i = 0; i < 500; i++)
                                            {
                                                Simulator.Sleep(0);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        });
                        CreateTaskAutoKillSim();
                        NiecTask.Perform(delegate
                        {

                            List<Sim> foundkillsimlist = new List<Sim>();

                            Random random = new Random(105210);

                            while (!GameStates.IsLiveState)
                            {
                                Simulator.Sleep(0);
                            }
                            while (true)
                            {
                                while (!GameStates.IsLiveState)
                                {
                                    Simulator.Sleep(0);
                                }
                                Simulator.Sleep(0);
                                try
                                {
                                    if (NiecHelperSituation.WorkingNiecHelperSituationCount == 0)
                                    {
                                        bool foundkillsim = false;

                                        Sim[] simlist = NFinalizeDeath.SC_GetObjects<Sim>();



                                        foreach (var ActorFor in simlist)
                                        {
                                            if (ActorFor == null)
                                                continue;

                                            SimDescription simd = ActorFor.SimDescription;
                                            if (simd == null)
                                                continue;

                                            global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = ActorFor.InteractionQueue;
                                            if (yInteractionQueue == null || yInteractionQueue.mInteractionList == null)
                                                continue;

                                            niec_std.list_remove(yInteractionQueue.mInteractionList, null);

                                            if (!simd.IsGhost && yInteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                                            {
                                                foundkillsim = true;
                                                foundkillsimlist.Add(ActorFor);
                                            }

                                            Simulator.Sleep(0);
                                        }



                                        if (foundkillsim && foundkillsimlist.Count > 0)
                                        {
                                            int itemNiecHelperS = 0;

                                            NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
                                            NiecHelperSituation.Spawn._bUnSafeRunAll = true;

                                            foreach (var ActorFor in simlist)
                                            {
                                                Simulator.Sleep(0);

                                                if (ActorFor == null)
                                                    continue;

                                                if (foundkillsimlist.Contains(ActorFor))
                                                    continue;

                                                SimDescription simd = ActorFor.SimDescription;
                                                if (simd == null)
                                                    continue;

                                                if (simd.ChildOrBelow)
                                                    continue;

                                                if (ActorFor.HasBeenDestroyed)
                                                    continue;

                                                global::Sims3.Gameplay.ActorSystems.InteractionQueue yInteractionQueue = ActorFor.InteractionQueue;
                                                if (yInteractionQueue == null || yInteractionQueue.mInteractionList == null)
                                                    continue;

                                                if (yInteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton))
                                                    continue;

                                                Autonomy automoy = ActorFor.Autonomy;
                                                if (automoy == null)
                                                    continue;

                                                SituationComponent sSituationComponent = automoy.SituationComponent;
                                                if (sSituationComponent == null)
                                                    continue;

                                                List<Situation> listSituations = sSituationComponent.Situations;
                                                if (listSituations == null)
                                                    continue;

                                                NiecHelperSituation situationOfTypex = ActorFor.GetSituationOfType<NiecHelperSituation>();

                                                Sim SimDead = (RandomUtil.GetRandomObjectFromList<Sim>(foundkillsimlist, random));

                                                if (situationOfTypex != null)
                                                {
                                                    //if (!foundkillsimlist.Contains(ActorFor))
                                                    {
                                                        SimDead.SimDescription.IsGhost = true;

                                                        yInteractionQueue.Add(

                                                            (!situationOfTypex.OkSuusse ?
                                                                Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton
                                                            : Sims3.Gameplay.NiecRoot.NiecHelperSituation.ReapSoul.Singleton
                                                            )

                                                            .CreateInstance(
                                                                SimDead,
                                                                ActorFor,
                                                                new InteractionPriority((InteractionPriorityLevel)12, 999f
                                                            ),

                                                            isAutonomous: false,
                                                            cancellableByPlayer: true

                                                        ));
                                                    }
                                                    //else continue;
                                                }
                                                else
                                                {
                                                    //if (!foundkillsimlist.Contains(ActorFor))
                                                    {
                                                        var nhs = NiecHelperSituation.Create(ActorFor.LotCurrent, ActorFor);
                                                        if (nhs != null)
                                                            listSituations.Add(nhs);

                                                        situationOfTypex = nhs ?? ActorFor.GetSituationOfType<NiecHelperSituation>();
                                                        if (situationOfTypex == null)
                                                            continue;

                                                        SimDead.SimDescription.IsGhost = true;

                                                        yInteractionQueue.Add(

                                                            (!situationOfTypex.OkSuusse ?
                                                                Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton
                                                            : NiecHelperSituation.ReapSoul.Singleton)

                                                            .CreateInstance(
                                                                SimDead,
                                                                ActorFor,
                                                                new InteractionPriority((InteractionPriorityLevel)12, 999f
                                                            ),

                                                            isAutonomous: false,
                                                            cancellableByPlayer: true

                                                        ));
                                                    }
                                                    //else continue;
                                                }

                                                try
                                                {
                                                    global::Sims3.Gameplay.Core.
                                                    Camera.CameraNotification.ShowNotificationAndFocusOnSim(
                                                        ActorFor.ObjectId,
                                                        ActorFor.GetLocalizedName() + ": NiecHelperSituation Created :)",
                                                        ActorFor
                                                    );
                                                }
                                                catch (ResetException)
                                                { throw; }
                                                catch { }

                                                foundkillsimlist.Remove(SimDead);

                                                itemNiecHelperS++;
                                                if (itemNiecHelperS == 2 || foundkillsimlist.Count == 0)
                                                { itemNiecHelperS = 0; break; }
                                            }
                                        }

                                    }
                                }
                                catch (ResetException)
                                { throw; }
                                catch
                                {
                                    for (int i = 0; i < 150; i++)
                                        Simulator.Sleep(0);
                                }
                                if (foundkillsimlist.Count != 0)
                                    foundkillsimlist.Clear();
                            }
                        });
                    }
                }
                else
                {
                    NFinalizeDeath.sObjectsGameObjectIsValid = true;
                    NiecHelperSituation.asdoetr = null; 
                    if (NiecHelperSituation.ShouldOnSavingGame_NonOpenDGS)
                    {
                        NiecTask.Perform(delegate
                        {
                            Simulator.Sleep(1);
                            if (NiecHelperSituation.ShouldOnSavingGame_NonOpenDGS)
                            {
                                NiecHelperSituation.ShouldOnSavingGame_NonOpenDGS = false;
                                NiecRunCommand.clearetdata_Command();
                            }
                        });
                    }
                    if (!craetedTaskD_02)
                    {
                        craetedTaskD_02 = true;
                        if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap"))
                        {
                            NiecTask.Perform(delegate
                            {
                                goto_reset:Simulator.Sleep(1);

                                Dictionary<ObjectGuid, bool> sAllRunning;

                                var NRaasErrorTrapType = Type.GetType("NRaas.ErrorTrap, NRaasErrorTrap", false);
                                if (NRaasErrorTrapType == null) 
                                    return;

                                var fi = NRaasErrorTrapType.GetField("sAllRunning", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (fi == null)
                                    return;

                                while (NotificationManager.sNotificationManager == null)
                                {
                                    Simulator.Sleep(0);
                                    if (NotificationManager.sNotificationManager != null)
                                        goto goto_reset;
                                }

                                sAllRunning = fi.GetValue(null) as Dictionary<ObjectGuid, bool>;
                                while (sAllRunning == null)
                                {
                                    sAllRunning = fi.GetValue(null) as Dictionary<ObjectGuid, bool>;
                                    Simulator.Sleep(5);
                                    while (NotificationManager.sNotificationManager == null)
                                    {
                                        Simulator.Sleep(0);
                                        if (NotificationManager.sNotificationManager != null)
                                            goto goto_reset;
                                    }
                                }

                                if (sAllRunning == null)
                                {
                                    niec_std.printf("sAllRunning == null");
                                    return;
                                }

                                while (true)
                                {
                                    Simulator.Sleep(20);
                                    sAllRunning.Clear();
                                    while (NotificationManager.sNotificationManager == null)
                                    {
                                        Simulator.Sleep(0);
                                        if (NotificationManager.sNotificationManager != null)
                                            goto goto_reset;
                                    }
                                }
                            });
                        }
                    }
                }

                try
                {
                    if (!AssemblyCheckByNiec.IsInstalled("AweCore") && !AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        if (AllDisgracefulActionEventListener != null)
                            EventTracker.RemoveListener(AllDisgracefulActionEventListener);

                        AllDisgracefulActionEventListener =
                            EventTracker.AddListener(EventTypeId.kSimCommittedDisgracefulAction, NPCSimCanDisgraced.OnFindSimCommittedDisgracefulAction);

                        NiecTask.Perform(delegate
                        {
                            while (true) {
                                Simulator.Sleep(51200);
                                foreach (var simitem in ListCollon.NiecSimDescriptions.ToArray())
                                {
                                    Simulator.Sleep(0);
                                    try
                                    {
                                        if (simitem == null || !simitem.IsValid || !simitem.IsValidDescription || !simitem.IsCelebrity)
                                            continue;

                                        CelebrityManager celma = simitem.CelebrityManager;
                                        if (celma == null || NPCSimCanDisgraced.CantBeDisgraced(celma))
                                            continue;

                                        NPCSimCanDisgraced.FalselyAccuseCheck(celma);
                                    }
                                    catch (ResetException)
                                    {throw;}
                                    catch { }
                                    
                                }
                            }
                        });
                    }

                }
                catch (Exception)
                { }

                try
                {
                    if (NiecRunCommand.AutoAllNewNiecSWLoad)
                    {
                        //NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
                        //NiecHelperSituation.Spawn._bUnSafeRunAll = true;

                        if (NiecRunCommand.autoAllnewniechs.mValue == 0)
                        {
                            NiecRunCommand.AutoAllNewNiecSW
                                (NiecRunCommand.AutoAllNewNiecSW_bAddIfIsPet, NiecRunCommand.AutoAllNewNiecSW_bAddIfIsSelectable, true);
                        }
                    }
                }
                catch (Exception)
                { }
                
                try
                {
                    NiecTask.Perform(delegate
                    {
                        if (SimDied_AHNHSGoHome != null)
                            EventTracker.RemoveListener(SimDied_AHNHSGoHome);

                        //if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        //{
                        //    SimDied_AHNHSGoHome = EventTracker.AddListener(EventTypeId.kSimDied, OpenDGS_OnSimDied);
                        //}
                        //else
                        if (!RootIsOpenDGSInstalled)
                        {
                            SimDied_AHNHSGoHome = EventTracker.AddListener(EventTypeId.kSimDied, NonOpenDGS_OnSimDied);
                        }
                    });
                }
                catch (Exception)
                { }
                if (NiecHelperSituation.NeedCreateNHSTask && AssemblyCheckByNiec.IsInstalled("OpenDGS")) {
                    NiecHelperSituation.NeedCreateNHSTask = false;
                    NiecTask.Perform(delegate {
                        Simulator.Sleep(1);
                        NFinalizeDeath.ReAllNHSOnTickSleep(null);
                    });
                }
                if (AssemblyCheckByNiec.IsInstalled("NRaasCareer")) {
                    
                    NiecTask.Perform(delegate
                    {
                        
                        Simulator.Sleep(10);

                        Assembly nrasscreer = AssemblyCheckByNiec.FindAssemblyPro("NRaasCareer") ?? AssemblyCheckByNiec.FindAssembly("NRaasCareer");
                        if (nrasscreer == null)
                        {
                            NFinalizeDeath.Assert("nrasscreer == null");
                            return;
                        }
                        // else // debug check
                        //     NiecException.WriteLog("nrasscreer: " + nrasscreer.GetTypes()[0].AssemblyQualifiedName);


                       // StringBuilder debug = new StringBuilder();
                       // int debugcount = 0;

                        Predicate<DelegateListener> dfunc = delegate(DelegateListener test)
                        {
                            //debugcount++;
                            if (test == null)
                                return false;

                            var processcalli = test.mProcessEvent;
                            if (processcalli == null) 
                                return false;

                            object targetNRaasEventListenerTask = processcalli.Target;
                            if (targetNRaasEventListenerTask == null) 
                                return false;

                            Type typeNRaasEventListenerTask = targetNRaasEventListenerTask.GetType();
                            if (typeNRaasEventListenerTask  == null || typeNRaasEventListenerTask.Assembly != nrasscreer) 
                                return false;

                            // debug check
                            //debug.Append
                            //    ("\n------------------------------------------------" + "debugcount: "  + debugcount + "\n" + "typeNRaasEventListenerTask: " + typeNRaasEventListenerTask.AssemblyQualifiedName);
                            //debug.AppendLine();

                            var fi = typeNRaasEventListenerTask.GetField("mFunc", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                            if (fi == null) 
                                return false;

                            // debug check
                            //debug.Append("fi: " + fi.ToString());
                            //debug.AppendLine();

                            var fiobj = fi.GetValue(targetNRaasEventListenerTask);
                            if (fiobj == null) 
                                return false;

                            MulticastDelegate nraasEventListenerTask_mFunc = fiobj as MulticastDelegate;

                            // debug check
                            //debug.Append("fi.GetValue: " + fiobj + "\nType: " + fiobj.GetType().AssemblyQualifiedName);
                            //debug.AppendLine();

                            if (nraasEventListenerTask_mFunc == null)
                                return false;

                            MethodInfo method = nraasEventListenerTask_mFunc.Method;
                            if (method == null) 
                                return false;
                            //if (method.Name.Contains("OnSimDied")) {
                            //    return true;
                            //}
                            return method.Name.Contains("OnSimDied");
                        };
                        try
                        {
                            var foundEvent = NFinalizeDeath.EventTracker_FindAllDelegateListener(dfunc);
                            if (foundEvent != null)
                            {
                                //int countfoundEvent = foundEvent.Count;
                                foreach (var item in foundEvent)
                                {
                                    if (item == null)
                                        continue;

                                    EventTracker.RemoveListener(item);
                                }
                                //NiecException.WriteLog("Done fix niecmod remove NRaasCareer OnKillSim\ncountfoundEvent: " + countfoundEvent);
                            }
                            else
                            {
                                //NiecException.WriteLog("failed fix niecmod remove NRaasCareer OnKillSim");
                            }
                        }
                        catch (Exception ex)
                        {
                            //NiecException.WriteLog(debug.ToString());
                            //debug = null;
                            NiecException.WriteLog(ex.ToString());
                            NFinalizeDeath.Assert("TargetSite: " + ex.TargetSite + "\nSource: " + ex.Source);
                        }
                       // finally {if (debug != null) NiecException.WriteLog(debug.ToString());}
                    });
                }
                //Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Clear();
                if (NFinalizeDeath.Adertyrty)
                {
                    foreach (SimDescription sdtyf in NFinalizeDeath.TattoaX()) // OK Full One World!
                    {
                        try
                        {
                            if (!ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                ListCollon.NiecSimDescriptions.Add(sdtyf);
                        }
                        catch
                        { }

                    }
                    //CommandSystem.ExecuteCommandString("ndelalldesc all");
                    NiecTask.Perform(delegate {
                        if (CancelActiveActorOnly)
                            NNiecDelAllDesc(new object[] { "all" });
                        else
                        {
                            try
                            {
                                while (LoadingScreenController.IsLayoutLoaded())
                                    Simulator.Sleep(0);
                                while (NotificationManager.Instance == null)
                                    Simulator.Sleep(0);
                                try { for (int i = 0; i < 1000; i++)Simulator.Sleep(0); }
                                catch (NotSupportedException) { }
                            }
                            catch (NotSupportedException)
                            { }
                            while (NFinalizeDeath.ActiveHousehold == null) 
                                Simulator.Sleep(0);
                            NiecTask.Perform(delegate
                            {


                                bool aOpenDGS = AssemblyCheckByNiec.IsInstalled("OpenDGS");


                                SimDescription activeactor = null;

                                Household activehousehold = null;
                                try
                                {
                                    activeactor = PlumbBob.sSingleton.mSelectedActor.mSimDescription; // Why OpenDGS?
                                }
                                catch (Exception)
                                { }

                                if (activeactor == null)
                                    throw new NullReferenceException("activeactor is null.");

                                activehousehold = activeactor.Household;
                                if (activehousehold == null)
                                    throw new NullReferenceException("ActiveHousehold is null.");









                                //try
                                //{
                                //    if (ListCollon.NullSimSimDescription == null)
                                //    {
                                //        foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
                                //        {
                                //            if (item == null) continue;
                                //            if (item == activeactor) continue;
                                //            if (item.IsValidDescription) continue;
                                //            NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(item));
                                //            ListCollon.NullSimSimDescription = item;
                                //            break;
                                //        }
                                //    }
                                //    if (ListCollon.NullSimSimDescription == null)
                                //    {
                                //        ListCollon.NullSimSimDescription = new SimDescription();
                                //        ListCollon.NullSimSimDescription.mIsValidDescription = false;
                                //    }
                                //}
                                //catch { }





                                Create.NiecNullSimDescription(true, false, false);











                                //NFinalizeDeath.SimDescCleanse(ListCollon.NullSimSimDescription, true, false);
                                NNiecDelAllDesc(new object[] { "activeactor" });

                                if (!aOpenDGS)
                                {
                                    NiecTask.Perform(delegate
                                    {

                                        while (true)
                                        {
                                            Simulator.Sleep(0);

                                            if (CancelActiveActorOnly)
                                                throw new OperationCanceledException();

                                            SimDescription asdr = ListCollon.NullSimSimDescription;
                                            foreach (GenieLamp genieLamp in NFinalizeDeath.SC_GetObjects<GenieLamp>())
                                            {
                                                if (genieLamp == null)
                                                    continue;
                                                genieLamp.mRemainingWishes = 9999;
                                                if (genieLamp.mGenieDescription == null)
                                                    genieLamp.mGenieDescription = asdr;
                                            }
                                            Simulator.Sleep(0);
                                            foreach (BonehildaCoffin Coffin in NFinalizeDeath.SC_GetObjects<BonehildaCoffin>())
                                            {
                                                if (Coffin == null) continue;
                                                if (Coffin.mBonehilda == null)
                                                    Coffin.mBonehilda = asdr;
                                            }
                                        }

                                    });
                                    NiecTask.Perform(delegate
                                    {
                                        while (true)
                                        {
                                            Simulator.Sleep(100);

                                            if (CancelActiveActorOnly)
                                                throw new OperationCanceledException();
                                            try
                                            {
                                                if (SimDescription.sLoadedSimDescriptions != null)
                                                    SimDescription.sLoadedSimDescriptions.Clear();
                                            }
                                            catch
                                            { }


                                            Simulator.Sleep(100);
                                        }
                                    });
                                    NiecTask.Perform(delegate
                                    {
                                        while (true)
                                        {
                                            if (CancelActiveActorOnly)
                                                throw new OperationCanceledException();
                                            foreach (var item in SimDescription.sLoadedSimDescriptions)
                                                ListCollon.NiecSimDescriptions.Add(item);


                                            Simulator.Sleep(0);
                                        }
                                    });
                                }


                                NiecTask.Perform(delegate
                                {
                                    try
                                    {
                                        while (true)
                                        {
                                            Simulator.Sleep(0);

                                            if (CancelActiveActorOnly)
                                            {
                                                RunningActiveActorOnly = false;
                                                throw new OperationCanceledException();
                                            }
                                            RunningActiveActorOnly = true;

                                            try
                                            {
                                                foreach (Lot item in LotManager.AllLots)
                                                {
                                                    Simulator.Sleep(0);
                                                    if (item == null) continue;
                                                    if (item.mHousehold == null) continue;
                                                    if (item.mHousehold == activehousehold) continue;
                                                    NFinalizeDeath.HouseholdCleanse(item.mHousehold, true, false);
                                                    item.mHousehold = null;
                                                }
                                            }
                                            catch
                                            { }
                                            Simulator.Sleep(0);
                                        }
                                    }
                                    finally
                                    {
                                        RunningActiveActorOnly = false;
                                    }
                                    
                                });





                                NiecTask.Perform(delegate
                                {
                                    while (true)
                                    {
                                        Simulator.Sleep(0);

                                        try
                                        {
                                            AlarmManager.Global.RemoveAlarm(PetPoolManager.sPoolAlarm);
                                            PetPoolManager.sPoolAlarm = AlarmHandle.kInvalidHandle;
                                        }
                                        catch
                                        { }


                                        if (CancelActiveActorOnly)
                                            throw new OperationCanceledException();

                                        if (!activeactor.mIsValidDescription && activeactor.OccultManager == null)
                                        {
                                            CancelActiveActorOnly = true;
                                            throw new OperationCanceledException();
                                        }

                                        Simulator.Sleep(0);

                                        activehousehold = activeactor.mHousehold;


                                        try
                                        {
                                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                                            {
                                                if (item == null || item == activehousehold)
                                                    continue;
                                                NFinalizeDeath.HouseholdCleanse(item, true);
                                            }
                                            if (Household.sHouseholdList != null)
                                            foreach (var item in Household.sHouseholdList.ToArray())
                                            {
                                                if (item == null || item == activehousehold)
                                                    continue;
                                                NFinalizeDeath.HouseholdCleanse(item, true);
                                            }
                                        }
                                        catch
                                        { }

                                        activehousehold = activeactor.mHousehold;

                                        
                                    }
                                });





                                if (aOpenDGS)
                                {
                                    NiecTask.Perform(delegate
                                    {
                                        while (true)
                                        {
                                            Simulator.Sleep(20);

                                            if (CancelActiveActorOnly)
                                                throw new OperationCanceledException();

                                            if (!activeactor.mIsValidDescription && activeactor.OccultManager == null)
                                            {
                                                NiecMod.Instantiator.CancelActiveActorOnly = true;
                                                CancelActiveActorOnly = true;
                                                throw new OperationCanceledException();
                                            }

                                            try
                                            {
                                                if (activeactor.CreatedSim == null)
                                                {
                                                    activeactor.Instantiate(activeactor.LotHome.Position);
                                                    PlumbBob.ForceSelectActor(activeactor.CreatedSim);
                                                }
                                            }
                                            catch
                                            { }

                                            Simulator.Sleep(20);
                                        }
                                    });

                                }




                                NiecTask.Perform(delegate
                                {
                                    while (true)
                                    {
                                        Simulator.Sleep(0);

                                        if (CancelActiveActorOnly)
                                            throw new OperationCanceledException();

                                        foreach (SimDescription sdtyf in NFinalizeDeath.TattoaX())
                                        {
                                            try
                                            {
                                                if (!ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                                    ListCollon.NiecSimDescriptions.Add(sdtyf);
                                                Simulator.Sleep(0);
                                            }
                                            catch
                                            { }
                                        }
                                        Simulator.Sleep(0);
                                    }
                                });




                                NiecTask.Perform(delegate
                                {

                                    try
                                    {
                                        if (Relationship.sAllRelationships != null)
                                            Relationship.sAllRelationships.Clear();
                                        Relationship.sAllRelationships = null;
                                        Relationship.sAllRelationships = new Dictionary<SimDescription, Dictionary<SimDescription, Relationship>>();
                                    }
                                    catch (Exception)
                                    { }
                                    while (true)
                                    {
                                        Simulator.Sleep(0);

                                        if (CancelActiveActorOnly) 
                                            throw new OperationCanceledException();

                                        try
                                        {
                                            if (aOpenDGS)
                                            {
                                                foreach (SimDescription description in ListCollon.NiecSimDescriptions.ToArray())
                                                {
                                                    if (description == null) continue;

                                                    if (description == activeactor) continue;

                                                    NFinalizeDeath.SimDescCleanse(description, true, false);
                                                    try
                                                    {
                                                        NFinalizeDeath.DeleteAllMiniSimDescription();
                                                    }
                                                    catch (Exception)
                                                    { }
                                                }
                                            }
                                            else
                                            {
                                                Simulator.Sleep(0);
                                                foreach (SimDescription sdtyf in NFinalizeDeath.TattoaX()) // OK Full One World!
                                                {
                                                    try
                                                    {
                                                        if (!ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                                            ListCollon.NiecSimDescriptions.Add(sdtyf);
                                                    }
                                                    catch
                                                    { }
                                                }
                                                Simulator.Sleep(0);
                                                foreach (SimDescription description in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.ToArray())
                                                {
                                                    if (description == null) continue;

                                                    if (description == activeactor) continue;

                                                    NFinalizeDeath.SimDescCleanse(description, true, false);
                                                    try
                                                    {
                                                        NFinalizeDeath.DeleteAllMiniSimDescription();
                                                    }
                                                    catch (Exception)
                                                    { }
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        { }

                                        Simulator.Sleep(0);
                                    }

                                });


                                NiecTask.Perform(delegate
                                {
                                    try
                                    {
                                        if (!aOpenDGS)
                                            SimDescription.sLoadedSimDescriptions = new List<SimDescription>();

                                        List<Service> saad = Services.sAllServices != null ? new List<Service>(Services.sAllServices) : new List<Service>();
                                        Dictionary<Role.RoleType, List<Role>> saiad = null;
                                        try
                                        {
                                            saiad = RoleManager.sRoleManager != null && RoleManager.sRoleManager.mRoles != null ? new Dictionary<Role.RoleType, List<Role>>(RoleManager.sRoleManager.mRoles) : new Dictionary<Role.RoleType, List<Role>>();
                                        }
                                        catch (Exception)
                                        {
                                            saiad = new Dictionary<Role.RoleType, List<Role>>();
                                        }
                                        try
                                        {
                                            while (true)// (HelperNra.TFindGhostsGrave(null) == null)
                                            {
                                                Simulator.Sleep(0);

                                                if (CancelActiveActorOnly)
                                                    throw new OperationCanceledException();

                                                Services.sAllowAddNPC = false;

                                                try
                                                {
                                                    if (aOpenDGS && SimDescription.sLoadedSimDescriptions != null)
                                                    {
                                                        SimDescription.sLoadedSimDescriptions.Clear();
                                                        SimDescription.sLoadedSimDescriptions = null;
                                                    }
                                                    if (Services.sAllServices != null && Services.sAllServices.Count != 0)
                                                        Services.sAllServices.Clear();
                                                    RoleManager sr = RoleManager.sRoleManager;
                                                    if (sr != null && sr.mRoles != null && sr.mRoles.Count != 0)
                                                        RoleManager.sRoleManager.mRoles.Clear();
                                                }
                                                catch (NullReferenceException)
                                                { }
                                                Simulator.Sleep(0);
                                                try
                                                {
                                                    NFinalizeDeath.HouseholdCleanse(Household.sNpcHousehold, true);
                                                    Household.sNpcHousehold = null;
                                                    NFinalizeDeath.HouseholdCleanse(Household.sPetHousehold, true);
                                                    Household.sPetHousehold = null;
                                                    NFinalizeDeath.HouseholdCleanse(Household.sMermaidHousehold, true);
                                                    Household.sMermaidHousehold = null;
                                                    NFinalizeDeath.HouseholdCleanse(Household.sPreviousTravelerHousehold, true);
                                                    Household.sPreviousTravelerHousehold = null;
                                                    NFinalizeDeath.HouseholdCleanse(Household.sServobotHousehold, true);
                                                    Household.sServobotHousehold = null;
                                                    NFinalizeDeath.HouseholdCleanse(Household.sTouristHousehold, true);
                                                    Household.sTouristHousehold = null;
                                                    NFinalizeDeath.HouseholdCleanse(Household.sAlienHousehold, true);
                                                    Household.sAlienHousehold = null;
                                                }
                                                catch (Exception)
                                                { }

                                            }
                                        }
                                        finally
                                        {
                                            SimDescription.sLoadedSimDescriptions = null;
                                            Services.sAllowAddNPC = true;
                                            Services.sAllServices = saad;
                                            saad = null;
                                            if (RoleManager.sRoleManager != null && RoleManager.sRoleManager.mRoles != null)
                                                RoleManager.sRoleManager.mRoles = saiad;
                                            saiad = null;
                                        }

                                    }
                                    catch (OperationCanceledException) { }
                                    catch (NotSupportedException)
                                    { }
                                });
                            });
                        }
                    });


                    
                     //NiecTask.Perform(AintAllDelDescX);

                    /*
                     try
                     {
                         while (true)
                         {

                             if (testwihe)
                                break;
                         }
                     }
                     catch (NiecModException)
                     { }
                     */
                }
                else
                {
                    foreach (SimDescription sdtyf in NiecMod.Nra.NFinalizeDeath.TattoaX()) // OK Full One World!
                    {
                        try
                        {
                            if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdtyf);
                        }
                        catch
                        { }

                    }
                }
            }
            catch
            { }
            try
            {
                //foreach (Sim sim in NFinalizeDeath.SC_GetObjects<Sim>())
                //{
                //    if (sim != null)
                //    {
                //        AddInteractions(sim);
                //    }
                //}


                NInteractionHelper.InitInjection();

            }  
            catch (Exception exception)
            {
                Exception(exception);
            } 
        }



        public static void TestLoadDll()
        {
            XmlDbData d = XmlDbData.ReadData("xmldgsdll");
            XmlDbTable xmlDbTable = null;
            d.Tables.TryGetValue("dgsdll", out xmlDbTable);
            if (xmlDbTable == null)
                xmlDbTable = d.Tables["xmldgsdll"];
            foreach (XmlDbRow xmlDbRow in xmlDbTable.Rows)
            {
                string text = xmlDbRow["Hex"];
                if (text != null)
                {
                    text = text.Trim().Replace(" ", "");
                    string[] subs = text.Split(',');
                    if (subs != null)
                    {
                        List<byte> temp = new List<byte>();
                        foreach (var item in subs)
                        {
                            byte t = 0;
                            byte.TryParse(item, System.Globalization.NumberStyles.HexNumber, null, out t);
                            temp.Add(t);
                        }
                        byte[] by = temp.ToArray();
                        Assembly att = AppDomain.CurrentDomain.Load(by);

                    }
                }
            }
        }

        public unsafe static int  Size
        {
            get
            {
                return sizeof(void*);
            }
            private set
            {
                int i = (8 / (value + 4)) + (Size * value) & sizeof(void*) * sizeof(TaskCreationStaticData*);
                i ^= value;
                NFinalizeDeath.M(value + i);
            }
        }

        public static void ForceSetTrueCacheIsDevBuild() { NFinalizeDeath.DownloadCoutext_CacheBoolIsDevBuild = true; }

        public static void OnStartupApp(object sender, System.EventArgs e)
        {

            if (!AddedNiecCore)
            {
               //if (Instantiator.otryirtuyortyoerd)
               //{
               //    NFinalizeDeath.CallingAssemblyDebuggerDEBUG();
               //}
                try
                {
                    Sims3.Gameplay.NiecInteractions.InteractionOverrideClass.Init();
                }
                catch (Exception)
                { }

                AddedNiecCore = true;

                //if (!RootIsOpenDGSInstalled)
                {
                    try
                    {
                        NFinalizeDeath.SafeCall(ForceSetTrueCacheIsDevBuild);
                    }
                    catch (Exception)
                    { }
                }

                // Garbage Collector BUG Game Crash Fixed.

                // Good CommandSystem.RegisterCommand("niecmod", "Usage: niecmod " + "[...]", (object[] p) => NiecRunCommand.OnRunCommands(p), false); 
                // Do not use CommandSystem.RegisterCommand("niecmod", "Usage: niecmod " + "[...]", NiecRunCommand.OnRunCommands, false); <= Game Crash!
                // Except Commands.sGameCommands.Register GC Safe

                CommandHandler t = (object[] p) => NiecRunCommand.OnRunCommands(p);
                CommandSystem.RegisterCommand("niecmod", "Usage: niecmod " + "[...]", t, false);
                CommandSystem.RegisterCommand("nm", "Usage: nm " + "[...]", t, false);

                Commands.sGameCommands.Register("nhelpernra", "On or Off HelperNra CheckKillSim. Usage: nhelpernra true|false ", Commands.CommandType.General, new CommandHandler(NHelperNra));
                Commands.sGameCommands.Register("nminekill", "On or Off MineKill CanBeKilled. Usage: nminekill true|false ", Commands.CommandType.General, new CommandHandler(NMineKillCanBeKilled));
                Commands.sGameCommands.Register("nmklog", "On or Off MineKill Log Created. Usage: nmklog true|false ", Commands.CommandType.General, new CommandHandler(NiecMineKillLog));
                Commands.sGameCommands.Register("nmkloga", "MineKill Log Add Create. Usage: nmkloga", Commands.CommandType.General, new CommandHandler(NMineKillLogA));
                Commands.sGameCommands.Register("nmklogc", "MineKill Log ClearUp. Usage: nmklogc", Commands.CommandType.General, new CommandHandler(NMineKillLogC));
                Commands.sGameCommands.Register("ncheckfailed", "On or Off FailedCallBookSleep. Usage: ncheckfailed true|false ", Commands.CommandType.General, new CommandHandler(NCheckFailed));
                Commands.sGameCommands.Register("nfailedkill", "nfailedkill is Added. Usage: nfailedkill", Commands.CommandType.General, new CommandHandler(NnFailedcallbooksleep));
                Commands.sGameCommands.Register("nniecdesca", "nniecdesca is Added. Usage: nniecdesca", Commands.CommandType.General, new CommandHandler(NNiecDescAdded));
                Commands.sGameCommands.Register("nniecdescr", "nniecdescr is Removeed. Usage: nniecdescr", Commands.CommandType.General, new CommandHandler(NNiecDescRemoved));
                Commands.sGameCommands.Register("ndelalldesc", "ndelalldesc is Desc Del All. Usage: ndelalldesc [diedall|died|active|vaild|delallcopydesc|alldelmsim|pethousehold|targeth|npchousehold|npchouseholdandservice|killallnohouse|cleanup|servicepool]", Commands.CommandType.General, new CommandHandler(NNiecDelAllDesc));
                Commands.sGameCommands.Register("ndelalldesckeep", "ndelalldesckeep is Desc Del All Safe Keep. Usage: ndelalldesckeep", Commands.CommandType.General, new CommandHandler(NNiecDelAllDescKeep));
                Commands.sGameCommands.Register("ncload", "ncload is Desc Del All. Usage: ncload", Commands.CommandType.General, new CommandHandler(NDelAll));





                Commands.sGameCommands.Register("ntestmap", "Usage: ntestmap. Test", Commands.CommandType.General, new CommandHandler(ForceErrorMineKill));
                Commands.sGameCommands.Register("ntest", "Usage: ncload. Test Fix Error", Commands.CommandType.General, new CommandHandler(TestCommandI));

                Commands.sGameCommands.Register("nforcecrachgame", "Usage: nforcecrachgame. Force Sims3 Game Crash", Commands.CommandType.General, new CommandHandler(Nforcecrachgame));


              

                if (!RootIsOpenDGSInstalled)
                {
                    if (ListCollon.SafeObjectGC != null)
                    {
                        try
                        {
                            ListCollon.SafeObjectGC.Add(Commands.sGameCommands.mCommands.table.Clone());
                        }
                        catch (Exception)
                        { }
                    }

                    try
                    {
                        NiecTask.Perform(TestPreventSetYieldingDisabled);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public static void TestPreventSetYieldingDisabled()
        {
            //try
            //{
            //    var yy = typeof(ScriptCore.Simulator);
            //    if (yy != null)
            //        Marshal.PrelinkAll(yy);
            //}
            //catch (Exception)
            //{ }

            NFinalizeDeath.SafeCall(NFinalizeDeath.UnusedGetFuncPtr);

            if (NFinalizeDeath.PreventSetYieldingDisabled())
            {
                ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(false);
                ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(true);
                var p = Simulator.CheckYieldingContext(false);

                if (Simulator.YieldingDisabled)
                    Simulator.YieldingDisabled = false;

                ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(false);

                NFinalizeDeath.Assert(p, "TestPreventSetYieldingDisabled\nCheckYieldingContext() failed");
            }
        }
        public static void TestPreventSetYieldingDisabled2()
        {
            //try
            //{
            //    var yy = typeof(ScriptCore.Simulator);
            //    if (yy != null)
            //        Marshal.PrelinkAll(yy);
            //}
            //catch (Exception)
            //{ }

            if (NFinalizeDeath.PreventSetYieldingDisabled())
            {
                var p = Simulator.CheckYieldingContext(false);

                ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(false);

                NFinalizeDeath.Assert(p, "TestPreventSetYieldingDisabled\nCheckYieldingContext() failed");
            }
        }

        private class CheckCrach
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            public static extern Guid GetCallGUID(Type type, bool throwException);
        }

        //[DllImport("NiecModCommon.dll")]
        //private static extern Guid Instantiator_GetCELD(Type type, ulong idGuid, Vector3 verBuild);

        //[DllImport("NiecModCommon.dll")]
        private static Guid Instantiator_GetArrayCELD(Type type, ulong idGuid, Vector3 verBuild, /* [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_ARRAY)] */ Sim[] simlist)
        {
            return Guid.Empty;
        }

        public static Guid GetCELD(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (type.IsSubclassOf(typeof(AbsoluteTime)))
            {
                throw new NiecModException("Could find type is AbsoluteTime. " + type.ToString());
            }
            if (type.IsImport)
            {
                return type.GUID;
            }
            try
            {
                for (Type baseType = type.BaseType; baseType != typeof(object); baseType = baseType.BaseType)
                {
                    if (baseType == null) break;
                    try
                    {
                        if (baseType.IsImport)
                        {
                            return baseType.GUID;
                        }
                        if (baseType.IsSpecialName)
                        {
                            Sim[] list = NFinalizeDeath.SC_GetObjects<Sim>();
                            foreach (var item in list)
                            {
                                if (item.Service is GrimReaper)
                                {
                                    return Instantiator_GetArrayCELD(baseType, item.SimDescription.SimDescriptionId, item.Position, list);
                                }
                            }
                            return Instantiator_GetArrayCELD(baseType, Sim.ActiveActor.SimDescription.SimDescriptionId, Household.NpcHousehold.LotHome.Position, null);
                        }
                    }
                    catch (Exception exception)
                    { NiecException.WriteLog("Error: " + System.Environment.NewLine + NiecException.LogException(exception), true, true, false); }

                }
            }
            catch (Exception er)
            {
                NiecException.WriteLog("Error For: " + System.Environment.NewLine + NiecException.LogException(er), true, true, false);
            }
            
            //return GetCallGUID(type, true);
            return Instantiator_GetArrayCELD(type, Sim.ActiveActor.SimDescription.SimDescriptionId, Household.NpcHousehold.LotHome.Position, null);
        }

        private unsafe static void NforcecrachgameX()
        {




            //NiecException.WriteLog("Lets Go ", true, false, false);
            string test = "";
        start:
            test = StringInputDialog.Show("NiecMod", "Please your password.", "", 256, StringInputDialog.Validation.None);

            if (string.IsNullOrEmpty(test)) { return; }

            ulong key = ResourceUtils.HashString64(test);

            if (key == 0x7E386882336CE5BE)
            {


                //Audio.StartSound("ui_camera_photo");
                VideoRecorder.SnapshotFileName = "NiecScreenshot";
                //CameraFlash.Flash();
                VideoRecorder.TakeSnapshot();

                NFinalizeDeath.Assert(key != 0x7E386882336CE5BE, "Done Goodbye Sims3 \nFor Master X Force Game Crash\n" + test);

                //SimpleMessageDialog.Show("NiecMod", "Done Goodbye Sims3");
                if (TwoButtonDialog.Show("Done Goodbye Sims3 \nFor Master X Force Game Crash", "yes", "no"))
                    NforcecrachgameXX();
                else
                {
                   // for (int i = 0; i < ; i++)
                    NiecTask.Perform(delegate
                    {
                        Commands.sGameCommands.Register("ndfgitrfuggutdftodafafybtisti", "", Commands.CommandType.General, new CommandHandler(delegate(object[] parameters)
                        {
                            TwoButtonDialog.Show("", "", "");
                            return 0;
                        }));
                        CommandSystem.ExecuteCommandString("ndfgitrfuggutdftodafafybtisti");
                        while (true)
                        {
                            SpeedTrap.Sleep();
                            
                            NiecTask.Perform(delegate
                            {
                                int teEst = (int)Niec.iCommonSpace.KillPro.UnSace((int*)3);
                                NiecTask.Perform(delegate
                                {
                                    Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                    NiecTask.Perform(delegate
                                    {
                                        Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                        NiecTask.Perform(delegate
                                        {
                                            Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                            NiecTask.Perform(delegate
                                            {
                                                Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                NiecTask.Perform(delegate
                                                {
                                                    Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                    NiecTask.Perform(delegate
                                                    {
                                                        Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                        NiecTask.Perform(delegate
                                                        {
                                                            Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                            NiecTask.Perform(delegate
                                                            {
                                                                Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                NiecTask.Perform(delegate
                                                                {
                                                                    Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                    NiecTask.Perform(delegate
                                                                    {
                                                                        Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                        NiecTask.Perform(delegate
                                                                        {
                                                                            Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                            NiecTask.Perform(delegate
                                                                            {
                                                                                Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                NiecTask.Perform(delegate
                                                                                {
                                                                                    Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                    NiecTask.Perform(delegate
                                                                                    {
                                                                                        Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                        NiecTask.Perform(delegate
                                                                                        {
                                                                                            Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                            NiecTask.Perform(delegate
                                                                                            {
                                                                                                Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                                NiecTask.Perform(delegate
                                                                                                {
                                                                                                    Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                                    NiecTask.Perform(delegate
                                                                                                    {
                                                                                                        Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                                        NiecTask.Perform(delegate
                                                                                                        {
                                                                                                            Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                                                                                        });
                                                                                                    });
                                                                                                });
                                                                                            });
                                                                                        });
                                                                                    });
                                                                                });
                                                                            });
                                                                        });
                                                                    });
                                                                });
                                                            });
                                                        });
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });
                            });
                            NiecTask.Perform(delegate
                            {
                                List<HelperNra> ss = new List<HelperNra>(int.MaxValue);
                                ss.Capacity = 1999999999;
                                while (true)
                                {
                                    NiecTask.Perform(delegate { ss.Capacity = int.MaxValue; });
                                    ss.Add(null);
                                }
                            });
                            
                            NiecTask.Perform(delegate
                            {
                                /*
                                for (int i = 0; i < 2; i++)
                                {
                                    NiecTask.Perform(delegate
                                    {
                                        Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                    });
                                }
                                 */
                               // Instantiator_GetArrayCELD(null, 3, Vector3.Empty, null);
                                //SpeedTrap.Sleep();
                                CheckCrach.GetCallGUID(null, false);
                            });
                        }
                    });
                }
            }
            else
            {
                //Guid adas = GetCELD(typeof(InteractionDefinition));
                /*
                byte[] rawData = {
	0xE6, 0x02, 0x05, 0x21, 0x63, 0x00, 0x92, 0x43, 0x00, 0x3A, 0x00, 0x5C,
	0x00, 0x55, 0x00, 0x73, 0x00, 0x65, 0x00, 0x72, 0x00, 0x73, 0x00, 0x5C,
	0x00, 0x4C, 0x00, 0x69, 0x00, 0x6E, 0x00, 0x63, 0x00, 0x5C, 0x00, 0x44,
	0x00, 0x6F, 0x00, 0x63, 0x00, 0x75, 0x00, 0x6D, 0x00, 0x65, 0x00, 0x6E,
	0x00, 0x74, 0x00, 0x73, 0x00, 0x5C, 0x00, 0x45, 0x00, 0x6C, 0x00, 0x65,
	0x00, 0x63, 0x00, 0x74, 0x00
};
                 */
                SimpleMessageDialog.Show("NiecMod", "Wrong Password."); // \nGUID:" + adas.ToString() + "\nData:" + rawData.ToString());
                test = "";
                
                goto start;
            }
        }

        private unsafe static void NforcecrachgameXX()
        {
            
            int test = (int)Niec.iCommonSpace.KillPro.UnSace((int*)3);
            NiecException.WriteLog(test.ToString(), test != 0);
        }



        











        private static int Nforcecrachgame(object[] parameters)
        { 
            try
            {
                NiecException.WriteLog("OK ", true, false, false);
                NiecTask.Perform(NforcecrachgameX);
            }
            catch //(object ex) //(Exception ex)
            {
                NiecException.WriteLog("UnSace ", true, false, false);
                
            }
            return 0;
        }

        public static void TestCommand()
        {
            /*
            if (NFinalizeDeath.CheckAccept("Test Game Is Stopped Working"))
            {
                return;
            }
            else
            {
                string msg = null;
                msg.ToString();
            }
             */
            try
            {
                 GameStates.sSingleton.mInWorldState.GotoReturnState();
            }
            catch (Exception)
            {}
            try
            {
                EditTownPuck.sInstance.mChangeSelectedHouseholdButton.Enabled = true;
            }
            catch (Exception)
            { }
            try
            {
                //EditTownPuck.sInstance.ReturnToPlayFlow();
                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS") && !AssemblyCheckByNiec.IsInstalled("NRaasTraveler") && Household.sNpcHousehold == null) // Custom
                // Show Error
                /*
                Stack Trace:
System.NullReferenceException: Object reference not set to an instance of an object.
#0: 0x000b1 callvirt   in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.Household:FindSuitableServiceAndTownieAccomodations (bool) ([0] )
#1: 0x00001 call       in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.Household:FindSuitableServiceAndTownieAccomodations () ()
#2: 0x0005a call       in Sims3.Gameplay.Sims3.Gameplay.PlayFlowModel:Shutdown () ()
#3: 0x0008b callvirt   in Sims3.UI.GameEntry.Sims3.UI.GameEntry.PlayFlowController:Shutdown () ()
#4: 0x00008 callvirt   in Sims3.UI.GameEntry.Sims3.UI.GameEntry.PlayFlowController:Unload () ()
#5: 0x00007 call       in Sims3.Gameplay.Sims3.Gameplay.PlayFlowState:Shutdown () ()
#6: 0x00012 callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:ShutdownCurState () ()
#7: 0x0000a call       in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:SetState (Sims3.SimIFace.StateMachineState) (42927F20 [390C3498] )
#8: 0x0009c callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Update (single) (42856CC0 [0] )
#9: 0x00017 callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Simulate () ()
                 */
                {
                    Household.sNpcHousehold = Household.Create();
                    Household.sNpcHousehold.Name = "World/Household:ServiceNpcFamilyName";
                }
                EditTownPuck.sInstance.ReturnToLive();
            }
            catch (Exception)
            { }
            //GameUtils.Unpause();
        }

        public static int TestCommandI(object[] parameters)
        {
            try
            {
                NiecTask.Perform(TestCommand);
            }
            catch
            { }
            return -1;
        }

        public static int ForceErrorMineKill(object[] parameters)
        {
            try
            {
                /*
                bool bRet = true;
                ParseParamAsBool(parameters, out bRet, true);
                Niec.iCommonSpace.KillPro.sForceError = bRet;
                return -1;
                 * */


                NiecTask.Perform(AntiEA);
                
            }
            catch
            { }
            return -1;
        }



        public static void AntiEA () {
            try
            {
                LotManager.UnlockActiveLot();
            }
            catch (Exception)
            { }
            try
            {
                ScreenCaptureOverlay.Display(false, true);
            }
            catch (Exception)
            { }
            try
            {
                PlayFlowController.Singleton.HidePlayFlowUI();
            }
            catch (Exception)
            { }
            try
            {
                Sims3.Gameplay.Core.Camera.SetMapViewActiveLotMode(true);
            }
            catch (Exception)
            { }
            
            
            
            
            GameStates.sSingleton.mInWorldState.GotoLiveMode();
        }

        internal static void AllDeleteSimDesc()
        {
            NiecTask.Perform(delegate
            {
                var b = AssemblyCheckByNiec.IsInstalled("Oniki_KinkyMod") && NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.___bOpenDGSIsInstalled_;
                try
                {
                    if (b)
                    {
                        NFinalizeDeath.SafeCall(() =>
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                NFinalizeDeath.ActiveActor = null;
                            }
                        });
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            NFinalizeDeath.ActiveActor = null;
                        }
                    }
                    if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommandsNoStatic, Sims3GameplaySystems");
                        if (type != null)
                        {
                            FieldInfo mField = type.GetField("kFakeActiveActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (mField != null)
                            {
                                mField.SetValue(null, false);
                                mField = type.GetField("kDGSPlayerTwo", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (mField != null)
                                {
                                    mField.SetValue(null, false);
                                }
                            }
                        }
                        //CommandSystem.ExecuteCommandString("dgspx false");
                        CommandSystem.ExecuteCommandString("dgsunsafekill false");
                    }
                }
                catch (Exception)
                { }

                SimDescription[] silit = Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.ToArray();
                if (silit == null) throw new ArgumentNullException();
                try
                {
                    foreach (SimDescription description in silit)
                    {
                        

                        //Household mec = description.Household;
                        if (b)
                        {
                            SimDescCleanseTask.SafeCallSimDescCleanseO(description);
                        }
                        else NFinalizeDeath.SimDescCleanse(description, true, false);
                        //NFinalizeDeath.HouseholdCleanse(mec);
                    }
                }
                catch (Exception)
                { }
               
                //if (MiniSimDescription.sMiniSims != null)
                //MiniSimDescription.sMiniSims.Clear();
                //MiniSimDescription.sMiniSims = null;
                //MiniSimDescription.sMiniSims = new Dictionary<ulong, MiniSimDescription>();
                if (b)
                {
                    try
                    {
                        foreach (var itaaem in Household.sHouseholdList.ToArray())
                        {
                            if (itaaem == null)
                                continue;
                            NFinalizeDeath.SafeCall(() =>
                            {
                                NFinalizeDeath.HouseholdCleanse(itaaem, true, false);
                            });
                        }
                    }
                    catch (Exception)
                    { Household.sHouseholdList = new List<Household>(); }
                }
                else
                {
                    try
                    {
                        foreach (var itaaem in Household.sHouseholdList.ToArray())
                        {
                            if (itaaem == null)
                                continue;
                            NFinalizeDeath.HouseholdCleanse(itaaem, true, false);
                        }
                    }
                    catch (Exception)
                    { Household.sHouseholdList = new List<Household>(); }
                }

                if (b)
                {
                    foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                    {
                        if (item == null)
                            continue;
                        NFinalizeDeath.SafeCall(() =>
                        {
                            NFinalizeDeath.HouseholdCleanse(item, true, false);
                        });
                    }
                }
                else
                {
                    foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                    {
                        if (item == null)
                            continue;
                        NFinalizeDeath.HouseholdCleanse(item, true, false);
                    }
                }
                //NFinalizeDeath.DeleteAllMiniSimDescription();
                if (b)
                {
                    try
                    {
                        foreach (Lot item in LotManager.AllLots)
                        {
                            if (item == null) continue;
                            if (item.mHousehold == null) continue;
                            NFinalizeDeath.SafeCall(() =>
                            {
                                NFinalizeDeath.HouseholdCleanse(item.mHousehold, true, false);
                            });
                            item.mHousehold = null;
                        }
                    }
                    catch
                    { }
                }
                else
                {
                    try
                    {
                        foreach (Lot item in LotManager.AllLots)
                        {
                            if (item == null) continue;
                            if (item.mHousehold == null) continue;
                            NFinalizeDeath.HouseholdCleanse(item.mHousehold, true, false);
                            item.mHousehold = null;
                        }
                    }
                    catch
                    { }
                }
                if (b)
                {
                    NFinalizeDeath.SafeCall(NFinalizeDeath.DeleteAllMiniSimDescription);
                }
                else
                    NFinalizeDeath.DeleteAllMiniSimDescription();

                try
                {
                    if (Relationship.sAllRelationships != null)
                        Relationship.sAllRelationships.Clear();
                    Relationship.sAllRelationships = null;
                    Relationship.sAllRelationships = new Dictionary<SimDescription, Dictionary<SimDescription, Relationship>>();
                }
                catch (Exception)
                { }

                try
                {
                    Type typex = Type.GetType("NRaas.ErrorTrapSpace.ObjectLookup, NRaasErrorTrap", false);
                    if (typex != null)
                    {
                        MethodInfo  getho = typex.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        if (getho != null)
                        {
                            getho.Invoke(null, new object[0]);
                        }
                    }
                }
                catch { }
                try
                {
                    AlarmManager alram = AlarmManager.Global;
                    foreach (HelperNra helperNra in HelperNra.HelperNraLists.ToArray())
                    {
                        if (helperNra == null)
                            continue;
                        if (alram != null)
                            alram.RemoveAlarm(helperNra.this_alarm);
                        helperNra.Dispose();
                    }
                }
                catch {}
                if (NFinalizeDeath.CheckAccept("Unsafe GC.SuppressFinalize(item)"))
                {
                    foreach (var item in silit)
                    {
                        if (item == null) 
                            continue;
                        GC.SuppressFinalize(item);
                    }
                }
            });
        }

        public static int NNiecDelAllDesc(object[] parameters)
        {
            try
            {
                /*
                NiecTask.Perform(delegate
                {
                    try
                    {

                        //Sleep(3.0);
                        foreach (SimDescription sdtyf in NiecMod.Nra.NFinalizeDeath.TattoaX())
                        {
                            try
                            {
                                if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdtyf);
                            }
                            catch
                            { }

                        }
                    }
                    catch
                    { }
                    SpeedTrap.Sleep();
                });
                 */
                NiecTask.Perform(delegate {
                    try
                    {
                        //foreach (Household household in Household.sHouseholdList)
                        foreach (var household in NFinalizeDeath.SC_GetObjects<Household>())
                        {
                            if (household == null) continue;
                            if (household == NFinalizeDeath.ActiveHousehold) continue;
                            if (household.AllSimDescriptions == null || household.AllSimDescriptions.Count == 0) continue;
                            foreach (SimDescription sda in household.AllSimDescriptions)
                            {
                                if (sda == null) continue;
                                if (!sda.mIsValidDescription && sda.OccultManager == null)
                                {
                                    NFinalizeDeath.SimDescCleanse(sda, true, false);
                                    try
                                    {
                                        if (household.mMembers != null)
                                        {
                                            if (household.mMembers.mSimDescriptions != null)
                                                household.mMembers.mSimDescriptions.Remove(sda);
                                            if (household.mMembers.mPetSimDescriptions != null)
                                                household.mMembers.mPetSimDescriptions.Remove(sda);
                                            if (household.mMembers.mAllSimDescriptions != null)
                                                household.mMembers.mAllSimDescriptions.Remove(sda);
                                        }
                                        household.Remove(sda, !household.IsServiceNpcHousehold);
                                    }
                                    catch (Exception)
                                    { }
                                } 
                            }
                        }
                        
                    }
                    catch (Exception)
                    {}
                    foreach (Lot ca in LotManager.AllLots)
                    {
                        if (ca == null) continue;
                        if (ca.Household == null) continue;

                        Household household = ca.Household;
                        if (household.IsServiceNpcHousehold) continue;
                        if (household == NFinalizeDeath.ActiveHousehold) continue;
                        if (household.AllSimDescriptions == null) continue;
                        try
                        {
                            if (household.AllSimDescriptions.Count == 0)
                            {
                                household.Dispose(true);
                                household.Destroy();
                                continue;
                            }
                        }
                        catch (Exception)
                        { continue; }

                        foreach (SimDescription sda in household.AllSimDescriptions)
                        {
                            if (sda == null) continue;
                            if (!sda.mIsValidDescription && sda.OccultManager == null)
                            {
                                NFinalizeDeath.SimDescCleanse(sda, true, false);
                                try
                                {
                                    try
                                    {
                                        household.Remove(sda, !household.IsServiceNpcHousehold);
                                    }
                                    catch (Exception)
                                    { }

                                    if (household.mMembers != null)
                                    {
                                        if (household.mMembers.mSimDescriptions != null)
                                            household.mMembers.mSimDescriptions.Remove(sda);
                                        if (household.mMembers.mPetSimDescriptions != null)
                                            household.mMembers.mPetSimDescriptions.Remove(sda);
                                        if (household.mMembers.mAllSimDescriptions != null)
                                            household.mMembers.mAllSimDescriptions.Remove(sda);
                                    }

                                    try
                                    {
                                        household.Remove(sda, !household.IsServiceNpcHousehold);
                                    }
                                    catch (Exception)
                                    { }
                                }
                                catch (Exception)
                                { }
                            }
                        }
                        // ca.ResetReset();
                    }
                });



                NiecTask.Perform(delegate
                {
                    foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                    {
                        //if (item == null && LotManager.Actors != null)
                        //{
                        //    LotManager.Actors.Remove(item);
                        //    continue;
                        //}
                        if (item.SimDescription == null)
                        {
                            NFinalizeDeath.UnSafe_OrgToNull_SimDesc(item);
                            NFinalizeDeath.ForceDestroyObject(item);
                        }
                    }
                });






                try
                {

                    //Sleep(3.0);
                    foreach (SimDescription sdtyf in NiecMod.Nra.NFinalizeDeath.TattoaX())
                    {
                        try
                        {
                            if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdtyf);
                        }
                        catch
                        { }

                    }
                }
                catch
                { }
                if (parameters != null && parameters.Length == 1 && (parameters[0] is string))
                {
                    string temp = (parameters[0] as string).ToLower();
                    if (temp == "diedall" || temp == "died")
                    {
                        NiecTask.Perform(delegate
                        {
                            try
                            {
                                List<SimDescription> temxplist = new List<SimDescription>(Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions);








                                foreach (SimDescription description in temxplist)
                                {
                                    if (description == null) continue;
                                    Sim sim = description.CreatedSim;
                                    if (sim == null) continue;

                                    BuffManager buff = sim.BuffManager;
                                    if (buff == null) continue;
                                    
                                    try
                                    {
                                        //if (!buff.HasElement(BuffNames.Mourning) || !buff.HasElement(BuffNames.HeartBroken)) continue;
                                        try
                                        {
                                            BuffHeartBroken.BuffInstanceHeartBroken buffInstanceHeartBroken = buff.GetElement(BuffNames.HeartBroken) as BuffHeartBroken.BuffInstanceHeartBroken;
                                            if (buffInstanceHeartBroken != null)
                                            {
                                                try
                                                {
                                                    Create.AddNiecSimDescription(buffInstanceHeartBroken.MissedSim as SimDescription);
                                                }
                                                catch (Exception)
                                                { }

                                                buffInstanceHeartBroken.MissedSim = null;
                                            }
                                        }
                                        catch (Exception)
                                        { }
                                        try
                                        {
                                            BuffMourning.BuffInstanceMourning mBuffInstanceMourning = buff.GetElement(BuffNames.Mourning) as BuffMourning.BuffInstanceMourning;
                                            if (mBuffInstanceMourning != null)
                                            {
                                                try
                                                {
                                                    Create.AddNiecSimDescription(mBuffInstanceMourning.MissedSim as SimDescription);
                                                }
                                                catch (Exception)
                                                { }
                                                mBuffInstanceMourning.MissedSim = null;
                                            }
                                        }
                                        catch (Exception)
                                        { }
                                        try
                                        {
                                            BuffNegligent.BuffInstanceNegligent mNegligent = buff.GetElement(BuffNames.Negligent) as BuffNegligent.BuffInstanceNegligent;
                                            if (mNegligent != null)
                                            {
                                                if (mNegligent.MissedSims != null)
                                                {
                                                    foreach (var item in mNegligent.MissedSims)
                                                    {
                                                        try
                                                        {
                                                            Create.AddNiecSimDescription(item);
                                                        }
                                                        catch (Exception)
                                                        { }
                                                    }
                                                    mNegligent.MissedSims.Clear();
                                                }
                                                mNegligent.MissedSims = null;
                                            }
                                        }
                                        catch (Exception)
                                        { }
                                    }
                                    catch (Exception)
                                    { }
                                    
                                    try
                                    {
                                        buff.RemoveElement(BuffNames.Negligent);
                                        buff.RemoveElement(BuffNames.Mourning);
                                        buff.RemoveElement(BuffNames.HeartBroken);
                                    }
                                    catch (Exception)
                                    { }
                                }




                                List<SimDescription> temxplista = new List<SimDescription>(Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions);

                                bool sfasts = temp == "diedall";

                                Household ah = NFinalizeDeath.ActiveHousehold;
                                Household ah2 = Household.ActiveHousehold;
                                //bool ahnull = ah != null;
                                int lssep = 0;
                                foreach (SimDescription description in temxplista)
                                //foreach (SimDescription description in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                                {
                                    
                                    if (description == null) continue;

                                    try
                                    {
                                        if ((description.CreatedByService != null) && (description.CreatedByService is GrimReaper) && (description.CreatedByService.IsSimDescriptionInPool(description))) continue;
                                        if ((description.Service != null) && (description.Service is GrimReaper) && (description.Service.IsSimDescriptionInPool(description))) continue;
                                    }
                                    catch (Exception)
                                    { }
                                    var dh = description.Household;
                                    if (sfasts)
                                    {
                                        //if (ahnull && dh == ah) continue;
                                        if (dh != null && (dh == ah2 || dh == ah)) continue;
                                        if (!description.IsDead)
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        if (description.IsDead)
                                        {
                                            
                                            if (dh != null  && (dh == ah2 || dh == ah)) continue;
                                            Urnstone adasd = HelperNra.TFindGhostsGrave(description);
                                            if (adasd != null)
                                            {
                                                if (adasd.LotCurrent != null && adasd.LotCurrent.IsCommunityLotOfType(CommercialLotSubType.kGraveyard)) continue;
                                            }
                                        }
                                        else continue;
                                    }
                                    
                                    NFinalizeDeath.SimDescCleanse(description, true);
                                    lssep++;
                                    if (lssep > 25)
                                    {
                                        lssep = 0;
                                        for (int _s = 0; _s < 35; _s++)
                                        {
                                            Simulator.Sleep(0);
                                        }
                                    }
                                }
                                temxplista.Clear();
                                temxplista = null;
                                temxplist.Clear();
                                temxplist = null;
                            }
                                
                            catch (Exception)
                            { }
                            
                            
                        });
                        return 1;
                    }
                    else if ((temp == "npchousehold" || temp == "npchouseholdandservice") && AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        NiecTask.Perform(delegate
                        {
                            if (temp == "npchouseholdandservice")
                            {
                                if (Services.sAllServices != null)
                                {
                                    foreach (var item in Services.sAllServices)
                                    {

                                        if (item == null)
                                            continue;
                                        if (item.mPool != null)
                                            item.mPool.Clear();
                                        if (item.mLotsRequested != null)
                                            item.mLotsRequested.Clear();
                                    }
                                }
                            }
                            NFinalizeDeath.HouseholdCleanse(Household.sNpcHousehold, true, false);
                            Household.sNpcHousehold = Household.Create(true);
                            Household.sNpcHousehold.Name = "World/Household:ServiceNpcFamilyName";
                        });
                        return 0;
                    }
                    
                    else if (temp == "servicepool")
                    {
                        NiecTask.Perform(delegate {
                            NiecException.PrintMessage(HelperNra.TestUnsafe("saasdasasddsd"));
                            NFinalizeDeath.ServicePoolCleanUp_Perform();
                        });
                       return 0;
                    }
                    else if (temp == "cleanup")
                    {
                        NFinalizeDeath.Household_CleanUp();
                        return 0;
                    }
                    else if ((temp == "killallnohouse") && AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        NiecTask.Perform(delegate
                        {
                            try
                            {
                                foreach (var sHousehold in Household.sHouseholdList.ToArray())
                                {
                                    if (sHousehold == null) continue;
                                    try
                                    {
                                        if (NFinalizeDeath.IsSpecialHousehold(sHousehold)|| sHousehold.InWorld || NFinalizeDeath.HouseholdIsRole(sHousehold))
                                            continue;
                                    }
                                    catch
                                    { }
                                    if (sHousehold.LotHome != null) continue;
                                    NFinalizeDeath.HouseholdCleanse(sHousehold, false, false);

                                }
                            }
                            catch
                            { }

                            foreach (var sHousehold in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (sHousehold == null) continue;
                                try
                                {
                                    if (NFinalizeDeath.IsSpecialHousehold(sHousehold) || sHousehold.InWorld || NFinalizeDeath.HouseholdIsRole(sHousehold))
                                        continue;
                                }
                                catch
                                { }
                                if (sHousehold.LotHome != null) continue;
                                NFinalizeDeath.HouseholdCleanse(sHousehold, false, false);
                            }
                        });
                        return 0;
                    }
                    else if (temp == "targeth")
                    {
                        NiecTask.Perform(delegate
                        {
                            SceneMgrWindow t = UIManager.GetSceneWindow();
                            if (t != null)
                            {
                                ScenePickArgs sad = t.GetPickArgs();
                                if (sad.mObjectId != 0)
                                {
                                    IScriptProxy proxy = Simulator.GetProxy(new ObjectGuid(sad.mObjectId));
                                    if (proxy != null)
                                    {
                                        Sim sGameObject = proxy.Target as Sim;
                                        if (sGameObject != null)
                                        {
                                            Household st = sGameObject.Household;
                                            if (st == Household.sNpcHousehold && NFinalizeDeath.CheckAccept("Delete NPC Household?"))
                                            {
                                                NFinalizeDeath.HouseholdCleanse(Household.sNpcHousehold, true, false);
                                                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                                    Household.sNpcHousehold = null;
                                                else
                                                {
                                                    Household.sNpcHousehold = Household.Create(true);
                                                    Household.sNpcHousehold.Name = "World/Household:ServiceNpcFamilyName";
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else if (st == Household.sPetHousehold && NFinalizeDeath.CheckAccept("Delete Pet Household?"))
                                            {
                                                NFinalizeDeath.HouseholdCleanse(Household.sPetHousehold, true, false);
                                                PetPoolManager.sPetPoolManager = new Dictionary<PetPoolType, PetPool>();
                                                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                                    Household.sPetHousehold = null;
                                                else
                                                {
                                                    Household.sPetHousehold = Household.Create(true);
                                                    Household.sPetHousehold.Name = "Pet Household";
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else if (st == Household.sAlienHousehold && NFinalizeDeath.CheckAccept("Delete Alien Household?"))
                                            {
                                                NFinalizeDeath.HouseholdCleanse(Household.sAlienHousehold, true, false);
                                                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                                    Household.sAlienHousehold = null;
                                                else
                                                {
                                                    Household.sAlienHousehold = Household.Create(true);
                                                    Household.sAlienHousehold.Name = "Pet Household";
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else if (st == Household.sMermaidHousehold && NFinalizeDeath.CheckAccept("Delete Mermaid Household?"))
                                            {
                                                NFinalizeDeath.HouseholdCleanse(Household.sMermaidHousehold, true, false);
                                                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                                    Household.sMermaidHousehold = null;
                                                else
                                                {
                                                    Household.sMermaidHousehold = Household.Create(true);
                                                    Household.sMermaidHousehold.Name = "Mermaid Household";
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else if (st == Household.sPreviousTravelerHousehold && NFinalizeDeath.CheckAccept("Delete Previous Traveler Household?"))
                                            {
                                                NFinalizeDeath.HouseholdCleanse(Household.sPreviousTravelerHousehold, true, false);
                                                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                                    Household.sPreviousTravelerHousehold = null;
                                                else
                                                {
                                                    Household.sPreviousTravelerHousehold = Household.Create(true);
                                                    Household.sPreviousTravelerHousehold.Name = "Previous Traveler Household";
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else if (st == Household.sServobotHousehold && NFinalizeDeath.CheckAccept("Delete Servobot Household?"))
                                            {
                                                NFinalizeDeath.HouseholdCleanse(Household.sServobotHousehold, true, false);
                                                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                                    Household.sServobotHousehold = null;
                                                else
                                                {
                                                    Household.sServobotHousehold = Household.Create(true);
                                                    Household.sServobotHousehold.Name = "Servo Bot Household";
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else if (st == Household.sTouristHousehold && NFinalizeDeath.CheckAccept("Delete Tourist Household?"))
                                            {
                                                NFinalizeDeath.HouseholdCleanse(Household.sTouristHousehold, true, false);
                                                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                                    Household.sTouristHousehold = null;
                                                else
                                                {
                                                    Household.sTouristHousehold = Household.Create(true);
                                                    Household.sTouristHousehold.Name = "Tourist Household";
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else if (st != Household.ActiveHousehold && st != NFinalizeDeath.ActiveHousehold)
                                            {
                                                if (!NFinalizeDeath.CheckAccept("Delete Target Household?")) return;
                                                NFinalizeDeath.HouseholdCleanse(st, true, false);
                                                for (int i = 0; i < 100; i++)
                                                {
                                                    Simulator.Sleep(0);
                                                }
                                                SimpleMessageDialog.Show("Done", NiecException.GetHouseholdInfo(st, false, null));
                                            }
                                            else
                                                NiecException.PrintMessage("NiecMod\nSorry, Can't Delete Active Household.");
                                            return;
                                        }

                                    }

                                }

                            }
                            NiecException.PrintMessage("NiecMod\nSorry, Target Object don't have Sim.");
                        });
                        return 0;
                    }
                    else if (temp == "pethousehold" && AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                    {
                        NiecTask.Perform(delegate
                        {
                            NFinalizeDeath.HouseholdCleanse(Household.sPetHousehold, true, false);
                            PetPoolManager.sPetPoolManager = new Dictionary<PetPoolType, PetPool>();
                            Household.sPetHousehold = Household.Create(true);
                            Household.sPetHousehold.Name = "PetHousehold";
                        });
                        return 0;
                    }
                    else if (temp == "vaild" || temp == "valid")
                    {
                        NiecTask.Perform(delegate
                        {
                            try
                            {
                                Household ah = NFinalizeDeath.ActiveHousehold;
                                bool ahnull = ah != null;

                                foreach (SimDescription description in new List<SimDescription>(Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions))
                                //foreach (SimDescription description in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                                {
                                    try
                                    {
                                        if (description == null) continue;

                                        

                                        try
                                        {
                                            if ((description.CreatedByService != null) && (description.CreatedByService is GrimReaper) && (description.CreatedByService.IsSimDescriptionInPool(description))) continue;
                                            if ((description.Service != null) && (description.Service is GrimReaper) && (description.Service.IsSimDescriptionInPool(description))) continue;
                                        }
                                        catch (Exception)
                                        { }
                                        if (ahnull && description.Household == ah) continue;


                                        if (description.mIsValidDescription) continue;
                                        //Household mec = description.Household;
                                        NFinalizeDeath.SimDescCleanse(description, true);
                                        //NFinalizeDeath.HouseholdCleanse(mec);
                                    }
                                    catch (Exception)
                                    { }

                                }
                            }
                            catch (Exception ex)
                            { NiecException.WriteLog("Dispose SimDesc: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false); }
                        });
                        return 1;
                    }
                    else if (temp == "all")
                    {
                        NiecTask.Perform(AllDeleteSimDesc);
                        return 1;
                    }
                    else if (temp == "delallcopydesc")
                    {
                        NiecTask.Perform(delegate
                        {
                            Household ah = Household.ActiveHousehold;
                            Household ah2 = NFinalizeDeath.ActiveHousehold;
                            //foreach (var item in Household.sHouseholdList)
                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null || item.mName == null || item == ah || item == ah2) continue;
                                if (item.mName.Contains("--The All Copy SimDesc--"))
                                {
                                    foreach (var iteam in item.AllSimDescriptions)
                                    {
                                        if (iteam == null) continue;
                                        iteam.mOutfits = null;
                                    }
                                    NFinalizeDeath.HouseholdCleanse(item, false, false);
                                    break;
                                }
                            }
                        });
                        return 0;
                    }
                    else if (temp == "activeactor")
                    {
                        SimDescription activeactor = null;
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        {
                            Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommandsNoStatic, Sims3GameplaySystems");
                            if (type != null)
                            {
                                FieldInfo mField = type.GetField("kFakeActiveActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (mField != null)
                                {
                                    mField.SetValue(null, false);
                                    mField = type.GetField("kDGSPlayerTwo", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                    if (mField != null)
                                    {
                                        mField.SetValue(null, false);
                                    }
                                }
                            }
                            //CommandSystem.ExecuteCommandString("dgspx false");
                            CommandSystem.ExecuteCommandString("dgsunsafekill false");
                        }
                        try
                        {
                            if (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null)
                                activeactor = PlumbBob.sSingleton.mSelectedActor.SimDescription; // Why OpenDGS?
                        }
                        catch (Exception)
                        { }

                        Household ah0 = activeactor != null ? activeactor.Household : null; 

                        // goto asdasd;
                        NiecTask.Perform(delegate
                        {

                            try
                            {

                                foreach (SimDescription description in new List<SimDescription>(Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions))
                                {
                                    try
                                    {
                                        if (description == null) continue;

                                        if (description == activeactor) continue;
                                        try
                                        {
                                            if ((description.CreatedByService != null) && (description.CreatedByService is GrimReaper) && (description.CreatedByService.IsSimDescriptionInPool(description))) continue;
                                            if ((description.Service != null) && (description.Service is GrimReaper) && (description.Service.IsSimDescriptionInPool(description))) continue;
                                        }
                                        catch (Exception)
                                        { }

                                    }
                                    catch (Exception)
                                    { }

                                    //Household mec = description.Household;
                                    NFinalizeDeath.SimDescCleanse(description, true);
                                    //NFinalizeDeath.HouseholdCleanse(mec);
                                }
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                if (Relationship.sAllRelationships != null)
                                    Relationship.sAllRelationships.Clear();
                                Relationship.sAllRelationships = null;
                                Relationship.sAllRelationships = new Dictionary<SimDescription, Dictionary<SimDescription, Relationship>>();
                            }
                            catch (Exception)
                            { }
                            //if (MiniSimDescription.sMiniSims != null)
                            //    MiniSimDescription.sMiniSims.Clear();
                            //MiniSimDescription.sMiniSims = null;
                            //MiniSimDescription.sMiniSims = new Dictionary<ulong, MiniSimDescription>();
                            NFinalizeDeath.DeleteAllMiniSimDescription();




                            try
                            {
                                foreach (var itaaem in Household.sHouseholdList.ToArray())
                                {
                                    if (itaaem == null)
                                        continue;
                                    NFinalizeDeath.HouseholdCleanse(itaaem, true, false);
                                }
                            }
                            catch (Exception)
                            { Household.sHouseholdList = new List<Household>(); }

                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null)
                                    continue;
                                NFinalizeDeath.HouseholdCleanse(item, true, false);
                            }
                            //NFinalizeDeath.DeleteAllMiniSimDescription();
                            try
                            {
                                foreach (Lot item in LotManager.AllLots)
                                {
                                    if (item == null) 
                                        continue;
                                    if (item.mHousehold == null)
                                        continue;
                                    if (item.mHousehold == ah0)
                                        continue;

                                    NFinalizeDeath.HouseholdCleanse(item.mHousehold, true, false);
                                    item.mHousehold = null;
                                }
                            }
                            catch
                            { }







                        });
                        return 1;
                    }
                    else if (temp == "alldelmsim")
                    {
                        NiecTask.Perform(NFinalizeDeath.DeleteAllMiniSimDescription);
                        return 0;
                    }
                    else if (temp == "createfamily")
                    {
                        try
                        {
                            if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            {
                                CommandSystem.ExecuteCommandString("dgspx false");
                                CommandSystem.ExecuteCommandString("dgsunsafekill false");
                            }
                        }
                        catch (Exception)
                        { }
                        NiecTask.Perform(delegate
                        {
                            try
                            {
                                foreach (SimDescription description in new List<SimDescription>(Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions))
                                {
                                    try
                                    {
                                        if (description == null) continue;
                                        try
                                        {
                                            if ((description.CreatedByService != null) && (description.CreatedByService is GrimReaper) && (description.CreatedByService.IsSimDescriptionInPool(description))) continue;
                                            if ((description.Service != null) && (description.Service is GrimReaper) && (description.Service.IsSimDescriptionInPool(description))) continue;
                                        }
                                        catch (Exception)
                                        { }


                                    }
                                    catch (Exception)
                                    { }


                                    //Household mec = description.Household;
                                    NFinalizeDeath.SimDescCleanse(description, true);
                                    //NFinalizeDeath.HouseholdCleanse(mec);
                                }
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                if (Relationship.sAllRelationships != null)
                                    Relationship.sAllRelationships.Clear();
                                Relationship.sAllRelationships = null;
                                Relationship.sAllRelationships = new Dictionary<SimDescription, Dictionary<SimDescription, Relationship>>();
                            }
                            catch (Exception)
                            { }
                            // if (MiniSimDescription.sMiniSims != null)
                            //    MiniSimDescription.sMiniSims.Clear();
                            //MiniSimDescription.sMiniSims = null;
                            //MiniSimDescription.sMiniSims = new Dictionary<ulong, MiniSimDescription>();
                            NFinalizeDeath.DeleteAllMiniSimDescription();
                            Create.CreateActiveHouseholdAndActiveActor(null, false);





                        });
                        return 1;
                    }
                    else if (temp == "active")
                    {
                        NiecTask.Perform(delegate
                        {
                            try
                            {
                                foreach (SimDescription description in new List<SimDescription>(Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions))
                                {
                                    try
                                    {
                                        if (description == null) continue;

                                        if (description.Household == NFinalizeDeath.ActiveHousehold) continue;
                                        try
                                        {
                                            if ((description.CreatedByService != null) && (description.CreatedByService is GrimReaper) && (description.CreatedByService.IsSimDescriptionInPool(description))) continue;
                                            if ((description.Service != null) && (description.Service is GrimReaper) && (description.Service.IsSimDescriptionInPool(description))) continue;
                                        }
                                        catch (Exception)
                                        { }

                                    }
                                    catch (Exception)
                                    { }


                                    //Household mec = description.Household;
                                    NFinalizeDeath.SimDescCleanse(description, true);
                                    //NFinalizeDeath.HouseholdCleanse(mec);
                                }
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                if (Relationship.sAllRelationships != null)
                                    Relationship.sAllRelationships.Clear();
                                Relationship.sAllRelationships = null;
                                Relationship.sAllRelationships = new Dictionary<SimDescription, Dictionary<SimDescription, Relationship>>();
                            }
                            catch (Exception)
                            { }
                            //if (MiniSimDescription.sMiniSims != null)
                            //    MiniSimDescription.sMiniSims.Clear();
                            //MiniSimDescription.sMiniSims = null;
                            //MiniSimDescription.sMiniSims = new Dictionary<ulong, MiniSimDescription>();
                            NFinalizeDeath.DeleteAllMiniSimDescription();

                        });
                        return 1;
                    }
                }
                NiecTask.Perform(delegate {
                    if (NFinalizeDeath.CheckAccept("NiecMod\nAre you sure delete all SimDescription"))
                    {
                        //AintAllDelDesc();
                        AllDeleteSimDesc();
                        if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        {
                            Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommandsNoStatic, Sims3GameplaySystems");
                            if (type != null)
                            {
                                FieldInfo mField = type.GetField("kFakeActiveActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                if (mField != null)
                                {
                                    mField.SetValue(null, false);
                                    mField = type.GetField("kDGSPlayerTwo", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                    if (mField != null)
                                    {
                                        mField.SetValue(null, false);
                                    }
                                }
                            }
                        }
                        if (!GameStates.IsInMainMenuState && !GameStates.IsEditTownState && GameStates.IsLiveState)
                        {
                            if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                            {
                                GameStates.sSingleton.mInWorldState.GotoEditTown();
                            }
                            else
                            {
                                //Sim ActiveActor = PlumbBob.SelectedActor;
                                //try
                                //{
                                //    PlumbBob.sSingleton.mSelectedActor = null;
                                //    GameStates.sSingleton.mInWorldState.GotoSubState(Sims3.Gameplay.InWorldState.SubState.EditTown);
                                //}
                                //finally
                                //{
                                //    PlumbBob.sSingleton.mSelectedActor = ActiveActor;
                                //}
                                PlumbBob.sSingleton.mSelectedActor = null;
                                GameStates.sSingleton.mInWorldState.GotoSubState(Sims3.Gameplay.InWorldState.SubState.EditTown);
                            }
                        }
                    }
                });
            }
            catch
            { }
            return -1;
        }


        public static int NNiecDelAllDescKeep(object[] parameters)
        {
            try
            {
                NiecTask.Perform(AintAllDelDescKeep);
            }
            catch
            { }
            return -1;
        }



        public static void AITIA(SimDescription sd)
        {
            
            sd.mGenealogy = null;
        }


        private static void AintAllDelDescX()
        {
            LoadingScreenController.sTotalPointsEarned += 400000;
            try
            {

                GameUtils.EnableSceneDraw(true);
            }
            catch
            { }
            try
            {
                UIManager.BlackBackground(false);
               
                //GameStates.TransitionToEditTown();
            }
            catch (Exception)
            { }
            
            try
            {
                Sims3.Gameplay.Core.Camera.OnExitBuildBuy();
                LotManager.UnlockActiveLot();
               // Sims3.Gameplay.Core.Camera.SetView(CameraView.MapView, false, true);
            }
            catch (Exception)
            { }
            try
            {
                CameraController.Unlock();
            }
            catch (Exception)
            { }
            
            /*
            if (LoadingScreenController.Instance != null)
            {
                try
                {
                    ScreenCaptureOverlay.Display(false, true);
                }
                catch (Exception)
                { }
                //LoadingScreenController.Instance.Enabled = false;
                try
                {
                    try
                    {
                        ModalDialog.EnableModalDialogs = true;
                        GameUtils.EnableSceneDraw(true);
                    }
                    catch (Exception)
                    { }
                    LoadingScreenController.Unload();
                    try
                    {
                        GameStates.sSingleton.mInWorldState.GotoLiveMode();
                    }
                    catch (Exception)
                    { }
                    LoadingScreenController.UnloadNow();
                }
                catch (Exception)
                { }
                try
                {
                    LoadingScreenController.Instance.Dispose();
                }
                catch (Exception)
                { }
                
                LoadingScreenController.sInstance = null;
            }
            */
            //AintAllDelDesc(LoadingScreenController.sInstance != null);
            AintAllDelDesc(true);


            try
            {
                if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Count == 0)
                {
                    try
                    {
                        foreach (SimDescription sdtyf in NiecMod.Nra.NFinalizeDeath.TattoaX())
                        {
                            try
                            {
                                if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdtyf);
                            }
                            catch
                            { }

                        }
                    }
                    catch
                    { }
                }
                int sLogEnumerator = 0;
                string sims = null;
                if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Count != 0)
                {
                    foreach (SimDescription sdtyf in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions) // OK Full One World!
                    {
                        sLogEnumerator++;
                        try
                        {
                            sims += NiecException.NewLine;
                            sims += NiecException.NewLine + "No: " + sLogEnumerator + NiecException.NewLine + NiecException.GetDescription(sdtyf);
                        }
                        catch
                        { sims += NiecException.NewLine + sLogEnumerator + NiecException.NewLine + "Error"; }

                    }
                    NiecException.WriteLog(sims, true, false, false);
                }
            }
            catch
            { }
            //testwihe = true;
            //throw new NiecModException("Reset");

            // asdrt;
            /*
            try
            {
                NiecMod.Helpers.Create.CreateActiveHouseholdAndActiveActor();
            }
            catch {
            }
            */
        }
        private static void AintAllDelDesc()
        {
            AintAllDelDesc(false, false);
        }


        private static void AintAllDelDescKeep()
        {
            AintAllDelDesc(false, true);
        }


        private static void AintAllDelDesc(bool loadworld)
        {
            AintAllDelDesc(loadworld, false);
        }

        private static void AintAllDelDesc(bool loadworld, bool noDelNiecDesc)
        {
            try
            {
                if (NiecMod.KillNiec.AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    bool checkrcheck = false;
                    bool eadr = false;
                    if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Count > 499) eadr = true;
                    if (!loadworld && !noDelNiecDesc && Simulator.CheckYieldingContext(false))
                    {
                        if (TwoButtonDialog.Show("Del Keep?", "Yes", "No")) checkrcheck = true;
                    }
                    //bool checkkillsimxxx = false;
                    try
                    {

                        //Sleep(3.0);
                        foreach (SimDescription sdtyf in NiecMod.Nra.NFinalizeDeath.TattoaX())
                        {
                            try
                            {
                                if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdtyf);
                            }
                            catch
                            { }

                        }
                    }
                    catch
                    { }

                    //Sleep(3.0);
                    List<SimDescription> arsradr = new List<SimDescription>();

                    try
                    {
                        
                        foreach (SimDescription sdtyef in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                        {
                            try
                            {
                                if (sdtyef == null) continue;
                                if (sdtyef.mPartner == null) continue;
                                arsradr.Add(sdtyef.mPartner);
                            }
                            catch (Exception)
                            { }
                            
                        }
                    }
                    catch (Exception)
                    { }

                    try
                    {

                        foreach (SimDescription sdttyef in arsradr)
                        {
                            if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdttyef))
                                Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdttyef);
                        }
                    }
                    catch (Exception)
                    { }

                    try
                    {
                        CommandSystem.ExecuteCommandString("dgsunsafekill false");
                        if (!loadworld)
                            CommandSystem.ExecuteCommandString("dgspx false");
                        PlumbBob.ForceSelectActor(null);
                        if (noDelNiecDesc)
                        {
                            Sims3.NiecModList.Persistable.ListCollon.NiecMiniSimDescriptions = new Dictionary<ulong, MiniSimDescription>(MiniSimDescription.sMiniSims);
                        }
                    }
                    catch
                    { }
                    
                    try
                    {


                        try
                        {
                            PlumbBob.sSingleton.mSelectedActor = null;
                        }
                        catch
                        { }
                    }
                    catch
                    { }

                    try
                    {
                        List<MiniSimDescription> asdr = new List<MiniSimDescription>(MiniSimDescription.sMiniSims.Values);
                        foreach (MiniSimDescription esdtyef in asdr)
                        {
                            try
                            {
                                if (esdtyef == null) continue;

                                if (esdtyef.mProtectionFlags != null)
                                    esdtyef.mProtectionFlags.Clear();


                                esdtyef.Instantiated = false;
                                esdtyef.mGenealogy = null;
                                try
                                {
                                    foreach (MiniRelationship miniRelationship in esdtyef.mMiniRelationships)
                                    {
                                        if (miniRelationship == null) continue;
                                        try
                                        {
                                            MiniSimDescription miniSimDescription2 = MiniSimDescription.Find(miniRelationship.SimDescriptionId);
                                            if (miniSimDescription2 != null)
                                            {
                                                if (miniSimDescription2.mProtectionFlags != null)
                                                    miniSimDescription2.mProtectionFlags.Clear();


                                                miniSimDescription2.Instantiated = false;
                                                miniSimDescription2.RemoveMiniRelatioship(esdtyef.mSimDescriptionId);
                                                miniSimDescription2.mGenealogy = null;
                                            }
                                        }
                                        catch
                                        { }

                                    }
                                }
                                catch
                                { }
                                if (esdtyef.mMiniRelationships != null)
                                    esdtyef.mMiniRelationships.Clear();
                                //MiniSimDescription.sMiniSims.Remove(esdtyef.mSimDescriptionId);
                            }
                            catch
                            { }

                        }
                    }
                    catch
                    { }

                    
                    ulong newid = 510000;
                    
                    foreach (SimDescription sdtyef in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                    {
                        
                        try
                        {
                            
                            if (sdtyef == null) continue;
                            if (eadr && Simulator.CheckYieldingContext(false))
                            {
                                Simulator.Sleep(0);
                            }
                            //sdtyef.RemoveOutfits(OutfitCategories.All, true);
                            //sdtyef.RemoveOutfit(OutfitCategories.All, 0, true);

                            if (!sdtyef.mIsValidDescription && !loadworld) continue;

                            try
                            {
                                if (sdtyef.AssignedRole != null)
                                {
                                    sdtyef.AssignedRole.RemoveSimFromRole();
                                }

                            }
                            catch (Exception)
                            { }



                            sdtyef.AssignedRole = null;
                            try
                            {
                                try
                                {
                                    if (sdtyef.OccultManager != null)
                                    {
                                        sdtyef.OccultManager.RemoveAllOccultTypes();
                                    }
                                }
                                catch
                                {

                                }

                                sdtyef.OccultManager = null;

                            }
                            catch
                            { }

                            try
                            {
                                if (sdtyef.IsPregnant)
                                {
                                    SafeNRaas.NRCASParts_RemoveOutfits(sdtyef, OutfitCategories.All, false);
                                }
                                else
                                {
                                    SafeNRaas.NRCASParts_RemoveOutfits(sdtyef, OutfitCategories.All, true);
                                }
                            }
                            catch
                            { }
                            sdtyef.Protected = false;
                            MiniSimDescription inim = MiniSimDescription.Find(sdtyef.mSimDescriptionId);
                            if (inim != null)
                            {
                                if (inim.mProtectionFlags != null)
                                    inim.mProtectionFlags.Clear();
                                inim.Instantiated = false;
                                inim.mGenealogy = null;
                                inim.ClearMiniRelationships();
                            }
                        }
                        catch
                        { }
                        try
                        {
                            Niec.iCommonSpace.KillPro.RemoveSimDescriptionRelationships(sdtyef);
                        }
                        catch
                        { }
                        try
                        {
                            Niec.iCommonSpace.KillPro.CleanseGenealogy(sdtyef);
                            sdtyef.mGenealogy = null;
                        }
                        catch
                        { }
                        try
                        {
                            Niec.iCommonSpace.KillPro.RemoveSimDescriptionRelationships(sdtyef);
                        }
                        catch
                        { }

                    }

                    List<Sim> asdo = new List<Sim>();
                    try
                    {

                        try
                        {
                            foreach (Sim simau in NFinalizeDeath.SC_GetObjects<Sim>())
                            {
                                try
                                {
                                    if (!asdo.Contains(simau))
                                        asdo.Add(simau);
                                }
                                catch
                                { }
                            }

                            foreach (Sim simau in LotManager.Actors)
                            {
                                try
                                {
                                    if (!asdo.Contains(simau))
                                        asdo.Add(simau);
                                }
                                catch
                                { }
                            }
                        }
                        catch
                        { }


                        try
                        {
                            foreach (Sim simaue in asdo)
                            {
                                try
                                {
                                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(simaue);
                                }
                                catch
                                { }
                                try
                                {
                                    simaue.Genealogy.ClearAllGenealogyInformation();

                                }
                                catch
                                { }

                                try
                                {
                                    simaue.Genealogy.ClearMiniSimDescription();
                                }
                                catch
                                { }

                                try
                                {
                                    simaue.Destroy();
                                }
                                catch
                                { }

                                try
                                {
                                    (simaue as ScriptObject).Destroy();
                                }
                                catch
                                { }
                            }
                        }
                        catch
                        { }
                    }
                    catch
                    { }
                    finally
                    {
                        //goto asad;
                        try
                        {
                            asdo.Clear();
                        }
                        catch
                        { }

                        asdo = null;
                    }
                //asad:

                    foreach (SimDescription description in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                    {

                        if (checkrcheck)
                        {
                            newid++;
                        }
                        try
                        {
                            if (description == null) continue;
                            if (eadr && Simulator.CheckYieldingContext(false))
                            {
                                Simulator.Sleep(0);
                            }
                            if (!description.mIsValidDescription && !loadworld && noDelNiecDesc)
                            {

                                try
                                {
                                    while (true)
                                    {
                                        Urnstone urnstone = null;
                                        urnstone = HelperNra.TFindGhostsGrave(description);

                                        if (urnstone != null)
                                        {
                                            urnstone.DeadSimsDescription = null;
                                            try
                                            {

                                                urnstone.Dispose();
                                            }
                                            catch
                                            { }
                                            try
                                            {
                                                urnstone.Destroy();
                                            }
                                            catch
                                            { }

                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                catch
                                { }
                                continue;
                            }
                        }
                        catch
                        { }

                        try
                        {
                            if (description.IsPregnant)
                            {
                                SafeNRaas.NRCASParts_RemoveOutfits(description, OutfitCategories.All, false);
                            }
                            else
                            {
                                SafeNRaas.NRCASParts_RemoveOutfits(description, OutfitCategories.All, true);
                            }
                        }
                        catch
                        { }



                        try
                        {
                            description.Genealogy.ClearMiniSimDescription();
                        }
                        catch
                        { }

                        try
                        {
                            description.Genealogy.ClearDerivedData();
                        }
                        catch
                        { }

                        try
                        {
                            description.Genealogy.ClearSimDescription();
                        }
                        catch
                        { }

                        try
                        {
                            description.Genealogy.ClearAllGenealogyInformation();
                        }
                        catch
                        { }



                        try
                        {
                            if (description.CreatedSim != null)
                            {
                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(description.CreatedSim);
                            }
                        }
                        catch
                        { }


                        try
                        {
                            Household household = description.Household;
                            if (household != null)
                            {
                                household.Remove(description, !household.IsSpecialHousehold);
                                household.Dispose(false);
                            }
                            
                        }
                        catch
                        { }

                        try
                        {
                            while (true)
                            {
                                Urnstone urnstone = null;
                                urnstone = HelperNra.TFindGhostsGrave(description);
                                if (urnstone != null)
                                {
                                    urnstone.DeadSimsDescription = null;
                                    try
                                    {
                                        urnstone.Dispose();
                                    }
                                    catch
                                    { }
                                    try
                                    {
                                        urnstone.Destroy();
                                    }
                                    catch
                                    { }

                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        catch
                        { }
                        MiniSimDescription imini = null;
                        try
                        {
                            imini = MiniSimDescription.Find(description.SimDescriptionId);
                        }
                        catch (Exception)
                        { }

                        try
                        {
                            MiniSimDescription.RemoveMSD(description.SimDescriptionId);
                        }
                        catch
                        { }
                        try
                        {
                            if (imini != null)
                            {
                                if (!noDelNiecDesc)
                                {
                                    imini.mAgeGenderFlags = CASAgeGenderFlags.None;
                                    imini.mAlmaMater = AlmaMater.None;
                                    imini.mAlmaMaterName = null;
                                    imini.mbAgingEnabled = false;
                                    imini.mCelebrityLevel = 0;
                                    imini.mDeathStyle = SimDescription.DeathType.None;
                                    imini.mDegrees = null;
                                    imini.mFirstName = null;
                                    imini.mHomeLotId = 0;
                                    imini.mGenealogy = null;
                                    imini.mHomeWorld = WorldName.Undefined;
                                    imini.mFirstName = null;
                                    imini.mHouseholdMembers = null;
                                    imini.mMiniRelationships = null;
                                    imini.mLastName = null;
                                    imini.mMotherDescId = 0;
                                    imini.mNumPetsInHousehold = 0;
                                    imini.mNumSimsInHousehold = 0;
                                    imini.mProtectionFlags = null;
                                    if (checkrcheck)
                                        imini.mSimDescriptionId = newid;
                                    else
                                        imini.mSimDescriptionId = 0;
                                    imini.mStatusFlags = MiniSimDescription.SimDescriptionStatus.None;
                                    imini.mThumbKey = ThumbnailKey.kInvalidThumbnailKey;
                                    imini.mTraits = null;
                                    imini.mTravelKey = ResourceKey.kInvalidResourceKey;
                                    imini.mZodiac = Zodiac.Cancer;
                                    imini.JobIcon = null;
                                    imini.JobOrServiceName = null;
                                }
                            }
                        }
                        catch (Exception)
                        { }
                        imini = null;



                        try
                        {
                            description.Dispose();
                        }
                        catch
                        { }

                        /*
                        try
                        {
                            NRaas.CommonSpace.Helpers.Annihilation.Cleanse(description);
                        }
                        catch
                        { }
                         */
                        try
                        {
                            description.mDeathStyle = KillTask.GetDeathType(null);
                        }
                        catch (Exception)
                        {

                            //throw;

                        }
                        try
                        {
                            description.ClearOutfits(true);
                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                        
                        
                        
                        



                        if (!noDelNiecDesc)// && checkrcheck)
                        {










                            try
                            {
                                foreach (Trait trait in description.mTraitManager.List)
                                {
                                    description.mTraitManager.RemoveTraitEffects(description, trait.Guid);
                                    description.mTraitManager.mRewardTraits.Remove(trait);
                                }

                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.mTraitManager.RemoveAllElements();

                            }
                            catch (Exception)
                            { }

                            try
                            {
                                description.mTraitChipManager.OnSimDisposed();
                            }
                            catch (Exception)
                            { }








                            try
                            {
                                List<Skill> nrsa = new List<Skill>(description.SkillManager.List);
                                foreach (var item in nrsa)
                                {
                                    if (item == null) continue;
                                    try
                                    {
                                        item.ResetStats();
                                    }
                                    catch (Exception)
                                    { }
                                    try
                                    {
                                        description.SkillManager.RemoveElement(item.mSkillGuid);
                                    }
                                    catch (Exception)
                                    { }

                                }
                            }
                            catch (Exception)
                            { }















                            try
                            {
                                description.CelebrityManager.OnDispose();
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.CelebrityManager = null;
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.mTraitManager = null;
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.mTraitChipManager = null;
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.SkillManager = null;
                            }
                            catch (Exception)
                            { }


                            try
                            {
                                description.mHomeWorld = WorldName.Undefined;
                            }
                            catch (Exception)
                            { }





                            if (description.FirstName == "Fullham" && description.LastName == "A")
                            {
                                NiecException.PrintMessage("Thanks you");
                            }

















                            try
                            {
                                description.PetManager.Dispose();
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.Occupation.FireSim(true);
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.Occupation.OnDispose();
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.Occupation.FireSim(true);
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.CareerManager.mJob = null;
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                //description.CareerManager.mJob = null;
                                description.PetManager = null;
                                description.mFirstName = null;
                                description.mDescription = null;
                                description.mSupernaturalData = null;
                                description.mPartner = null;
                            }
                            catch (Exception)
                            { }

                            try
                            {
                                description.Service.EndService(description);
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.CreatedByService.EndService(description);
                            }
                            catch (Exception)
                            { }
                            try
                            {
                                description.Service = null;
                                description.CreatedByService = null;
                                description.mReputation = null;
                            }
                            catch (Exception)
                            { }

                            try
                            {
                                try
                                {
                                    description.CareerManager.OnRemoved(null);
                                }
                                catch (Exception)
                                { }
                                try
                                {
                                    description.MidlifeCrisisManager.ForceEndCrisis(true);
                                }
                                catch (Exception)
                                { }
                                try
                                {
                                    description.Pregnancy.ClearPregnancyData();
                                }
                                catch (Exception)
                                { }
                                description.CareerManager = null;
                                description.MidlifeCrisisManager = null;
                                description.HealthManager = null;

                                description.mSimFlags = CASAgeGenderFlags.None;
                                description.ReadBookDataList = null;
                                description.Pregnancy = null;
                                description.OpportunityHistory = null;
                            }
                            catch (Exception)
                            { }

                            try
                            {
                                try
                                {
                                    description.VisaManager.RemoveAllElements();
                                }
                                catch (Exception)
                                { }
                               
                                description.VisaManager = null;
                                description.RelicStats = null;
                                description.TombStats = null;

                                description.Singing = null;

                                description.mHairColors = null;
                                description.mEyebrowColor = null;
                                description.mFacialHairColors = null;
                                description.mBodyHairColor = null;
                            }
                            catch (Exception)
                            { }






                            try
                            {
                                description.mSkinToneKey = ResourceKey.kInvalidResourceKey;
                                description.mDefaultOutfitKey = ResourceKey.kInvalidResourceKey;
                            }
                            catch (Exception)
                            { }


                            try
                            {
                                description.mLastName = null;


                                try
                                {
                                    description.mOutfits.Clear();
                                }
                                catch (Exception)
                                { }
                                try
                                {
                                    description.mMaternityOutfits.Clear();
                                }
                                catch (Exception)
                                { }
                                try
                                {
                                    description.mSpecialOutfitIndices.Clear();
                                }
                                catch (Exception)
                                { }
                                description.AgingState = null;

                                description.mOutfits = null;
                                description.mMaternityOutfits = null;
                                description.mSpecialOutfitIndices = null;

                                if (checkrcheck)
                                {
                                    description.mSimDescriptionId = newid;
                                    description.mOldSimDescriptionId = newid;
                                }
                                else
                                {
                                    description.mSimDescriptionId = 0;
                                    description.mOldSimDescriptionId = 0;
                                }
                            }
                            catch (Exception)
                            { }
                            

                        }
                        description.mIsValidDescription = false;
                        /*
                        try
                        {
                            if (!noDelNiecDesc && !checkrcheck)
                                GC.SuppressFinalize(description);
                        }
                        catch (Exception)
                        { }
                        */
                    }


                    try
                    {
                        //Sleep(3.0);
                        foreach (Service allService in Services.AllServices)
                        {
                            try
                            {
                                if (!(allService is GrimReaper) && !noDelNiecDesc)
                                {
                                    allService.ClearServicePool();
                                }

                            }
                            catch
                            { }

                        }
                    }
                    catch
                    { }
                    try
                    {
                        //Sleep(3.0);
                        foreach (Service allService in Services.AllServices)
                        {
                            try
                            {
                                if (!(allService is GrimReaper) && !noDelNiecDesc)
                                {
                                    Service.Destroy(allService);
                                }

                            }
                            catch
                            { }

                        }
                    }
                    catch
                    { }

                    try
                    {
                        try
                        {
                            try
                            {
                                SimDescription.sLoadedSimDescriptions.Clear();
                            }
                            catch
                            { }

                            SimDescription.sLoadedSimDescriptions = null;
                            //SimDescription.sLoadedSimDescriptions = new List<SimDescription>();

                        }
                        catch
                        {
                            StyledNotification.Format afra = new StyledNotification.Format("Failed 1", StyledNotification.NotificationStyle.kSystemMessage);
                            StyledNotification.Show(afra);
                        }









                        if (!loadworld)
                        {
                            try
                            {
                                if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Count == 0)
                                {
                                    try
                                    {
                                        foreach (SimDescription sdtyf in NiecMod.Nra.NFinalizeDeath.TattoaX())
                                        {
                                            try
                                            {
                                                if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdtyf))
                                                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdtyf);
                                            }
                                            catch
                                            { }

                                        }
                                    }
                                    catch
                                    { }
                                }
                                int sLogEnumerator = 0;
                                string sims = "Done All Del Sim Description. \n";
                                if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Count != 0)
                                {
                                    foreach (SimDescription sdtyf in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions) // OK Full One World!
                                    {
                                        sLogEnumerator++;
                                        try
                                        {
                                            sims += NiecException.NewLine;
                                            sims += NiecException.NewLine + "No: " + sLogEnumerator + NiecException.NewLine + NiecException.GetDescription(sdtyf);
                                        }
                                        catch
                                        { sims += NiecException.NewLine + sLogEnumerator + NiecException.NewLine + "Error"; }

                                    }
                                    NiecException.WriteLog(sims, true, false, false);
                                }
                            }
                            catch
                            { }
                            if (!noDelNiecDesc && !checkrcheck)
                            {
                                try
                                {
                                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Clear();

                                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions = null;
                                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions = new List<SimDescription>();
                                }
                                catch
                                {
                                    StyledNotification.Format afra = new StyledNotification.Format("Failed 2", StyledNotification.NotificationStyle.kSystemMessage);
                                    StyledNotification.Show(afra);
                                }
                            }
                        }
                        try
                        {
                            //Sims3.NiecModList.Persistable.ListCollon.NiecMiniSimDescriptions = new Dictionary<ulong, MiniSimDescription>(MiniSimDescription.sMiniSims);
                            //MiniSimDescription.sMiniSims.Clear();
                            //MiniSimDescription.sMiniSims = null;
                            //MiniSimDescription.sMiniSims = new Dictionary<ulong, MiniSimDescription>();
                            NFinalizeDeath.DeleteAllMiniSimDescription();
                        }
                        catch
                        {
                            StyledNotification.Format afra = new StyledNotification.Format("Failed 3", StyledNotification.NotificationStyle.kSystemMessage);
                            StyledNotification.Show(afra);
                        }
                        if (NiecMod.KillNiec.AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                        {
                            try
                            {
                                CommandSystem.ExecuteCommandString("dgsnocreate true");
                                StyledNotification.Format afra = new StyledNotification.Format("Termination Status: Perfect Execution!", StyledNotification.NotificationStyle.kGameMessageNegative);
                                afra.mTNSCategory = NotificationManager.TNSCategory.Chatty;

                                StyledNotification.Show(afra);
                            }
                            catch
                            { }

                            try
                            {
                                CommandSystem.ExecuteCommandString("dgsnocreate true");
                            }
                            catch
                            { }

                            OptionsModel optionsModel = Sims3.Gameplay.UI.Responder.Instance.OptionsModel as OptionsModel;
                            if (optionsModel != null)
                            {
                                optionsModel.SaveName = "ClearSave " + "No Name";

                            }
                            if (!loadworld)
                            {
                                try
                                {
                                    GameStates.TransitionToEditTown();
                                }
                                catch
                                { }
                            }
                        }
                    }
                    catch
                    { }
                }
                else
                {
                    if (!loadworld)
                    StyledNotification.Show(new StyledNotification.Format("Sorry, Can't Use Del All Desc \nDel SimDesc To Create SimDesc \nYou need OpenDGS", StyledNotification.NotificationStyle.kGameMessagePositive));
                    
                }
            }
            catch
            { }
            
            return;
        }


        public static int NNiecDescRemoved(object[] parameters)
        {
            try
            {
                Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Clear();
                Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions = null;
                Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions = new List<SimDescription>();
            }
            catch
            { }
            return -1;
        }

        public static int NNiecDescAdded(object[] parameters)
        {
            try
            {
                foreach (SimDescription sdtyf in NiecMod.Nra.NFinalizeDeath.TattoaX())
                {
                    try
                    {
                        if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(sdtyf))
                        Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(sdtyf);

                    }
                    catch
                    { }

                }
            }
            catch
            { }
            return -1;
        }

        public static int NMineKillCanBeKilled(object[] parameters)
        {
            bool bRet = true;
            ParseParamAsBool(parameters, out bRet, true);
            NTunable.kDedugNotificationCheckNiecKill = bRet;
            return -1;
        }



        public static int NiecMineKillLog(object[] parameters)
        {
            bool bRet = true;
            ParseParamAsBool(parameters, out bRet, true);
            Niec.iCommonSpace.KillPro.sLoaderLogTraneEx = bRet;
            return -1;
        }

        public static int NMineKillLogA(object[] parameters)
        {
            try
            {
                if (NiecException.WriteLog(Niec.iCommonSpace.KillPro.LogTraneEx.ToString(), true, false, false))
                {
                    NiecException.PrintMessage("WriteLog" + NiecException.NewLine + "Created MineKillLog No: " + Niec.iCommonSpace.KillPro.sLogEnumeratorTrane);
                }
            }
            catch
            { }

            return 0;
        }

        public static int NMineKillLogC(object[] parameters)
        {
            try
            {
                Niec.iCommonSpace.KillPro.sLogEnumeratorTrane = 0;
                //GC.SuppressFinalize(Niec.iCommonSpace.KillPro.LogTraneEx);
                Niec.iCommonSpace.KillPro.LogTraneEx = null;
                Niec.iCommonSpace.KillPro.LogTraneEx = new StringBuilder();
            }
            catch
            { }
            return -1;
        }



        public static bool CheckKillSim( Sim nlist )
        {
            if (nlist.InteractionQueue.HasInteractionOfType(ExtKillSimNiec.Singleton)) return true;
            if (nlist.InteractionQueue.HasInteractionOfType(Urnstone.KillSim.Singleton)) return true;
            return false;
        }


        public static int NnFailedcallbooksleep(object[] parameters)
        {
            try
            {
                var list = new List<Sim>();
                foreach (Sim sim in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (sim.InteractionQueue != null && CheckKillSim(sim))
                    {
                        list.Add(sim);
                    }
                }
                /*
                if (list.Count == 0)
                {
                    return list.Count;
                }
                 */
                if (list.Count != 0)
                {
                    foreach (Sim nlist in list)
                    {
                        try
                        {

                            
                            HelperNraPro helperNra = new HelperNraPro();

                            //helperNra = HelperNra;

                            helperNra.mSim = nlist;

                            helperNra.mdeathtype = nlist.SimDescription.DeathStyle;

                            if (nlist.Household != null)
                            {
                                helperNra.mHousehold = nlist.Household;
                            }

                            helperNra.mSimdesc = nlist.SimDescription;

                            if (!nlist.LotCurrent.IsWorldLot)
                            {
                                helperNra.mHouseVeri3 = nlist.Position;
                            }

                            else if (Sim.ActiveActor != null && !Sim.ActiveActor.LotCurrent.IsWorldLot)
                            {
                                helperNra.mHouseVeri3 = Sim.ActiveActor.Position;
                            }
                            

                            //helperNra.mdeathtype = simDeathType;

                            /*helperNra.malarmx =  */
                            helperNra.this_alarm = AlarmManager.Global.AddAlarm(3f, TimeUnit.Hours, new AlarmTimerCallback(helperNra.FailedCallBookSleep), "FailedCallBookSleep " + nlist.Name, AlarmType.NeverPersisted, null);
                        }
                        catch (Exception exception)
                        { NiecException.WriteLog("helperNra " + NiecException.NewLine + NiecException.LogException(exception), true, true, false); }
                    }
                }
                //return;
            }
            catch
            { }
            return 1;
        }

        public static int NCheckFailed(object[] parameters)
        {
            bool bRet = true;
            ParseParamAsBool(parameters, out bRet, true);
            NTunable.kCheckFailed = bRet;
            return -1;
        }


        



        public static int NDelAll(object[] parameters)
        {
            bool bRet = true;
            ParseParamAsBool(parameters, out bRet, true);
            NFinalizeDeath.Adertyrty = bRet;
            return -1;
        }



        public static int NHelperNra(object[] parameters)
        {
            bool bRet = true;
            ParseParamAsBool(parameters, out bRet, true);
            NTunable.kHelperNraNoCheckKillSim = bRet;
            return -1;
        }


        private static bool ParseParamAsBool(object[] param, out bool bRet, bool defaultVal)
        {
            bRet = defaultVal;
            /*
            if (param == null)
            {
                throw new ArgumentNullException("param");
            }
             * */
            if (param.Length != 1)
            {
                return false;
            }
            bool result = false;
            if (param[0] is bool)
            {
                bRet = (bool)param[0];
                result = true;
            }
            else if (param[0] is int || param[0] is uint)
            {
                bRet = ((int)param[0] != 0);
                result = true;
            }
            else if (param[0] is string)
            {
                string a = (param[0] as string).ToLower();
                bRet = (a == "on");
                result = (a == "on" || a == "off");
            }
            return result;
        }

        public static void AddInteractionsGO(GameObject o)
        {
            if (o == null)
                return;

            if (o is Computer || o is CityHall)
            {
                NFinalizeDeath.GO_AddInteraction(o, NiecMod.Interactions.Objects.NRCODImmediateInteraction.Singleton, true);
            }
        }

        public static void AddInteractions(Sim sim) 
        {
            if (sim == null) 
                return;

            if (sim.mInteractions == null)
            {
                sim.mInteractions = new List<InteractionObjectPair>();
            }

            var typee = ObjectNiec.Singleton.GetType(); // fast code ;)
            foreach (InteractionObjectPair pair in sim.mInteractions)
            {
                if (pair == null)
                    return;

                if (pair.mInteraction.GetType() == typee)
                    return;

            }

            sim.AddInteraction(ForceEnableSave.Singleton);
            sim.AddInteraction(ForceAddFamily.Singleton);
            sim.AddInteraction(ObjectNiec.Singleton);
            sim.AddInteraction(ForceRequestGrimReaper.Singleton);
            sim.AddInteraction(ReapSoul.Singleton);
            sim.AddInteraction(ForceExitXXX.Singleton);
            sim.AddInteraction(ForceKillSimNiec.Singleton);
            sim.AddInteraction(ForceTestGrim.Singleton);
            sim.AddInteraction(TestAllKillSim.Singleton);
            sim.AddInteraction(AllPauseNiec.Singleton);
            sim.AddInteraction(LincSAT.Singleton);
            sim.AddInteraction(ExtKillSimNiec.Singleton);
            sim.AddInteraction(ResetIntroTutorial.Singleton);
            sim.AddInteraction(AllActorsKillSim.Singleton);
            //sim.AddInteraction(TheNiecReapSoul.Singleton);
            sim.AddInteraction(CancelAllInteractions.Singleton);
            sim.AddInteraction(KillForce.Singleton);
            sim.AddInteraction(HelloChatESRB.Singleton);
            sim.AddInteraction(KillInLotCurrent.Singleton);

            // Niec Helper Situation
            sim.AddInteraction(Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton);
            sim.AddInteraction(Sims3.Gameplay.NiecRoot.NiecHelperSituation.ReapSoul.Singleton);
        }

        public static bool Exception(Exception exception)
        {
            try
            {
                return ((IScriptErrorWindow)AppDomain.CurrentDomain.GetData("ScriptErrorWindow")).DisplayScriptError(null, exception);
            }
            catch
            {
                WriteLog(exception);
                return true;
            }
        }


      

        public static bool WriteLog(Exception exception)
        {
            try
            {
                NiecException.SendTextExceptionToDebugger(exception);
                new ScriptError(null, exception, 0).WriteMiniScriptError();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}