

using System;

using System.Collections.Generic;
using System.Text;
using Sims3.SimIFace;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Services;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.SimIFace.CAS;
using NiecMod.Helpers.MakeSimPro;
using NiecMod.KillNiec;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Objects.Island;
using Sims3.Gameplay.Socializing;
using Sims3.UI.Controller;
using NiecMod.Nra;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.NiecRoot;
using Sims3.Gameplay.Autonomy;
using Sims3.UI;
using NiecMod.Interactions;
using Sims3.Gameplay.Interactions;
using System.Reflection;
using Sims3.NiecModList.Persistable;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Utilities;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects.Beds;
using Sims3.Gameplay.ChildAndTeenUpdates;
using Sims3.Gameplay.Objects.Environment;
using Sims3.Gameplay.Objects.Rewards;
using Sims3.SimIFace.CustomContent;
using Sims3.Gameplay.StoryProgression;
using Sims3.Gameplay.NiecNonOpenDGS.Interactions;
using Sims3.Gameplay.Objects.Miscellaneous;
using Sims3.UI.GameEntry;
using Sims3.SimIFace.VideoRecording;

namespace NiecMod.Helpers
{
    public static class NiecRunCommand // Thanks x64dbg is 32/64bit hide debugger free and open-source  Home: x64dbg.com
    {

        //public static
        //    string GetNiecModCommandList0N()
        //{
        //    return
        //        "[a|b" +
        //        "|c" +
        //        "]";
        //}


        public static
            string GetNiecModCommandList() // if (current.Width >= 1366) is recommended Resolution
        {
            return // Don't need return @"Hello World";
                "[exitniechs|killsim|cancelkillsim|addloopfire|rallfloop|deltargetsimdesc" +
                "|forcesetaa|clearetdata|settextpos|deadsimtosim|cdeadsimtosim|destroyalltargetlot|fixisghost" +
                "|addniechelpershouse|unsafeallrunnhs|rnewniechs|removeallhelpernra|removetask|targetnhs|allnewniechs" +
                "|targetniecsw|rnewass|rcreatehousehold|finddeldesc|infoaa|fixonisplayer|rlooppsim|looppsim|unsaddmnil" +
                "|removeallhouseholdlist|forcecalli|fixoccults|coccults|dtargetobj|targetocc|tbobj|targetpsmc|targetct" +
                "|cfakegrave|cchildallhouse|newlothouse|aexlot|rexlot|fhhmem|grtwotone|fixmshouse|dallgravelot|savesimdesc|loadsimdesc|loadsimdesc10" +
                "|fixemtpy|trimhouse|bioclear|fakelothome|cforac|autogmd|allexhouse|aallnewniechs|testex|testext|stoaa|allnewnsw|stoa|dtoa" +
                "|addbuff|slotlist|testexs|testexi|setidpos|fixhlist|acinfo|savelot|autop|fixsimlist|automantinpc|mrt|mrtr|mrtd|mrtc|mrtn|asimnohouse" +
                "|spt|importlot|bulot|removetaskp|testcpu|rallg|cd|rclock|unpl|dsavename|ps|mydesctoalldesc|wtimer|ustsim|ustsimall|rp|removelms" +
                "|fixsimlots|etex|slde|minecn|scpt|camst|ltrimhouse|targetctl|trimallsim|renhstick|rsneedhome|nvsc|targetds|nhsnoah|autosave|fixsimbad|ddcs"+
                "|simssp|simss|acss|ndgstf|ndgstfa|testlist|ctl|hhr2|sdnoage|ahmh|hmh|maxmood|fhlot|rfhlot|nndsdc|clc|csc|nre|rnhs|revlist|ddsd|dsauto"+
                "|dpetdr|tunnhs|spnhs|alllotclean]"; 
                                                                                // next 02()
        }

        public static
            string GetNiecModCommandList02()
        {
            return // Don't need return @"Hello World";
                "[psloop|cnhsp|tnhs|uloopnhs|dsup|swb|dreslist|looppaa|nstload|allcnhsp|tpsim|wrallsim|setfunctest|allinvsim|rcfunc|rwrallsim|ishlistbad" +
                "|csimdescl|tsimcopyh|fakeh|fcreap|rallbuff|rallirunlist|loopaadied|looppaa2|forcesetaa2|fakehp|finddelvaild|loopraa|mpush|nhsptick" +
                "|devc|rallrlot|usev|minecnpro|tsetype|rtnodark|looptargetdied|nhsaht|allbulot|forcesetaa3|forcesetaa4|ustsimallpro|ustsimallloop" +
                "|dnst|infoplib|aforcesetaa3|allfdp|findinvdesc|loopaadied2f|hitloopdied|killsimforlot|createfakesim|excashousehold|forcefastdoinhs" +
                "|isstsleepmax|hitloopdied2|alldviewsim|allcreatefakesim|alldinv|allpsimtopos|dallvsimdesc|setsimnull|miexh|debugnhsi|dtclist|firs|firsp" +
                "|looplightcp|clc2|tnhsid|riqrlist|riqrlistloop|guspeedf|guspeedl|guptime|usam|sdjig|nhsexaa|dnoneedall|testdmymod|setisstsleep|dunusedsu" +
                "|debugdebuginfo|nhsfsactor|tnhsfsactor|nhslsfi|loopreappet|ussmcreapsoulpet|sworldflags|simisf|gccollect|fnsptrimhouse|simu2f|maxmoodloop" +
                "|clsave|uacsmcreapsoul|addsimtohousehold/2|unwiz|unsaferunnnull|fakemeteor|unsaferunfuncnull|unsaferunfuncnullpro|debugvfxnhs|aruns" +
                "|fakemeteorpro|ussdjig|allresetsim|resetnpchousehold|unsafesmcsmcpro|unruncn|ffindgood|alldinvloop|testassert|looptargetdied2|looptargetdied3" +
                "|unruncnpro|unsaferunnnullpro|dkeyname|pdats|dkeygivename|dipetname|dipetname2|cukeyname|testfastcode01|tev" +
                //"|c" +
                "]";
        }


       
        public static
            string GetNiecModCommandList03()
        {
            return
                "[dasc2020|tevcopy|testgetunsace|tevs|backuptevc|tmynfunc|tmnfunc2|chouselot|dnf|testhinlothome|tmnfunc3|exlists" +
                "|testdttod|testloadlib|tmnfunc3x|loadlib|fixuphinlothome|exitgame|testyia|testye|tmnfunc4|looptargetdied4|tmnfunc5|testpyd|testmbox" +
                "|testagssd|testagssdall|tmsfunc1|pmgas|tmsfunc2|setfuncptr|testksmym|saatwo|keepcreatesim|delallsim|dcdgs|agrss|drawd|importhouse" +
                "|exlists2|exlists3|extestcpu|unsafenullbimdesc|chouselotnos|chouselotnosall|usev2" +
                //"|c" +
                //"|c" +
                //"|c" +
                //"|c" +
                //"|c" +
                //"|c" +
                "]";
        }


        public static
            void TestRouteOpenDGS()
        {
            SimRoutingComponent.kDefaultImmuneToPushesDuration = 1;
            SimRoutingComponent.kOnEmergencyGetAwayRouteStartedImmuneToPushesDuration = 1;
            SimRoutingComponent.kOnRouteStartedImmuneToPushesDuration = 1;

            SimRoutingComponent.kDefaultStandAndWaitDuration = 150;
            SimRoutingComponent.kMaximumPostPushStandAndWaitDuration = 65;
            SimRoutingComponent.kMinimumPostPushStandAndWaitDuration = 15f;

            SimRoutingComponent.kEndOfPortalInvicibilityDuration = 0.5f;
        }

        public static Sims3.Gameplay.EventSystem.EventTracker tusev = null;
        public static Sims3.Gameplay.EventSystem.EventTracker tevdata = null;
        public static Dictionary<Lot, object> tausevAlarm = null;
        public static object tausevGAlarm = null;
        public static Sims3.NiecHelp.Tasks.NiecNraTask.NraFunction DGSMODS_Func_stload = null;

        public static List<StateMachineClient> nonOpendgsList01 = null;
        public static Sims3.NiecHelp.Tasks.NiecNraTask.NraFunction DGSMODS_TestFunc = null;

        public static Sims3.NiecHelp.Tasks.NiecNraTask.NraFunction DGSMODS_TestFunc02 = null; 

        public static bool ltrimhouse_bb = false;
        public static bool loopdunusedsu = false;
        public static string DEBUG_LoadFileName(string worldName, bool useTravelData)
        {
            string text = useTravelData && GameStates.sTravelData != null ? GameStates.sTravelData.mSaveName : GameStates.sEditOtherWorldData.mSaveName;
            int num = text.IndexOf(':');
            if (num > 0 && !(0 > text.Length - num))
            {
                return text.Substring(0, num) + ":" + worldName;
            }
            else
            {
                return text + ":" + worldName;
            }
        }

        /*

        public static bool DEBUGStackOneCall = false;
        public static string DADEBUGASS = null;

        public static bool DEBUGStackOneCall2 = false;
        public static bool DEBUGStackOneCall3 = false;
        public static bool DEBUGStackOneCall4 = false;
        public static bool DEBUGStackOneCall5 = false;

        public static string AppGCID = "";
        public static string AppGCID2 = "";
        public static Assembly AppGCID3 = null;
        
        public static Assembly AssIsAss = null;
        public static Assembly AssIsAss1 = null;
        
         */
        public static
            void dcdgs_command()
        {
            Instantiator.kDontCallDGSACore = !Instantiator.kDontCallDGSACore;

            if (niec_native_func.cache_done_niecmod_native_message_box)
                niec_native_func.MessageBox(0, "DontCallDGSACore: " + Instantiator.kDontCallDGSACore, "NiecMod", (niec_native_func.MB_Type)0);
            else
                NFinalizeDeath.Show_MessageDialog("DontCallDGSACore: " + Instantiator.kDontCallDGSACore);
        }

        public static
            void unsafenullbimdesc_command()
        {
            BimDesc.UnsafeFixNUllSimDESC = !BimDesc.UnsafeFixNUllSimDESC;

            if (niec_native_func.cache_done_niecmod_native_message_box)
                niec_native_func.MessageBox(0, "UnsafeFixNUllSimDESC: " + BimDesc.UnsafeFixNUllSimDESC, "NiecMod", (niec_native_func.MB_Type)0);
            else
                NFinalizeDeath.Show_MessageDialog("UnsafeFixNUllSimDESC: " + BimDesc.UnsafeFixNUllSimDESC);
        }

        public static
            void usev2_command()
        {
            NJOClass.unsaferunpe = !NJOClass.unsaferunpe;
            if (niec_native_func.cache_done_niecmod_native_message_box)
                niec_native_func.MessageBox(0, "NJOClass.unsaferunpe: " + NJOClass.unsaferunpe, "NiecMod", (niec_native_func.MB_Type)0);
            else
                NFinalizeDeath.Show_MessageDialog("NJOClass.unsaferunpe: " + NJOClass.unsaferunpe);
        }

        public static
            void dasc2020_command()
        {
            Type type = typeof(ScriptCore.ScriptProxy); //Type.GetType("ScriptCore.ScriptProxy,ScriptCore", true);
            if (type != null)
            {
                FieldInfo vfield00 = null;
                FieldInfo vfield01 = null;
                FieldInfo vfield02 = null;
                FieldInfo vfield03 = null;
                FieldInfo vfield04 = null;
                FieldInfo vfield05 = null;

                //FieldInfo vfield06 = null;

                FieldInfo vfield07 = null;
                FieldInfo vfield08 = null;
                FieldInfo vfield09 = null;

                FieldInfo vfield10 = null;
                FieldInfo vfield11 = null;

                // PC: 0x007FF100AFFFE3BC
                // SP: 0x00000000502EAFCB

                try
                {
                    vfield01 = type.
                        GetField("DEBUGStackOneCall", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield00 = type.
                        GetField("DADEBUGASS", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield02 = type.
                        GetField("DEBUGStackOneCall2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield03 = type.
                        GetField("DEBUGStackOneCall3", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield04 = type.
                        GetField("DEBUGStackOneCall4", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield05 = type.
                        GetField("DEBUGStackOneCall5", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield07 = type.
                        GetField("AppGCID", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield08 = type.
                        GetField("AppGCID2", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield09 = type.
                        GetField("AppGCID3", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    vfield10 = type.
                        GetField("AssIsAss", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
                try
                {
                    vfield11 = type.
                        GetField("AssIsAss1", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                string debug = "";

                try
                {
                    debug += "Assembly Name: " + (vfield00.GetValue(null) as string ?? "Unknown") + "\n\nStackOneCall: " + (bool)vfield01.GetValue(null);
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
               
                try
                {
                    debug += "\n\nDEBUGStackOneCall2: " + (bool)vfield02.GetValue(null) + "\n"
                             + "DEBUGStackOneCall3: " + (bool)vfield03.GetValue(null) + "\n"
                             + "DEBUGStackOneCall4: " + (bool)vfield04.GetValue(null) + "\n"
                             + "DEBUGStackOneCall5: " + (bool)vfield05.GetValue(null) + "\n";
                             //+ "\nDEBUGStackOneCallN: " + (bool)vfield02.GetValue(null) + "\n";
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    debug += "\n\nAppGCID: " + vfield07.GetValue(null) as string ?? "Unknown";
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    debug += "\n\nAppGCID2: " + vfield08.GetValue(null) as string ?? "Unknown";
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    debug += "\n\nAppGCID3: 0x" + ((uint)((vfield09.GetValue(null) as Assembly).obj_address().ToInt32())).ToString("X");
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    debug += "\n\nAssIsAss: 0x" + ((uint)((vfield10.GetValue(null) as Assembly).obj_address().ToInt32())).ToString("X");
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    debug += "\nAssIsAss1: 0x" + ((uint)((vfield11.GetValue(null) as Assembly).obj_address().ToInt32())).ToString("X");
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    debug += "\n\nAssIsAssMonoX: 0x" + ((uint)((vfield10.GetValue(null) as Assembly)._mono_assembly.ToInt32())).ToString("X");
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                try
                {
                    debug += "\nAssIsAssMonoX1: 0x" + ((uint)((vfield11.GetValue(null) as Assembly)._mono_assembly.ToInt32())).ToString("X");
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }

                if (debug == null)
                    throw new NullReferenceException();

                new NCopyableTextDialog(debug).SafeShow("dasc2020 command");

                NFinalizeDeath.Assert((vfield10.GetValue(null) as Assembly) == (vfield11.GetValue(null) as Assembly), "ScriptCoreAssembly == ScriptCoreAssembly failed");
                NFinalizeDeath.Assert((vfield10.GetValue(null) as Assembly)._mono_assembly == (vfield11.GetValue(null) as Assembly)._mono_assembly, "ScriptCoreAssembly._mono_assembly == ScriptCoreAssembly._mono_assembly failed");
            }
        }

        [PersistableStatic]
        public static List<object> BackupTEV = null;

        public unsafe static
            void testgetunsace_command()
        {
            if (IsOpenDGSInstalled) 
                return;

            niec_std.mono_runtime_install_handlers();
            NFinalizeDeath.SafeCall(() => { 
                if (IsOpenDGSInstalled) 
                    return;
                Niec.iCommonSpace.KillPro.UnSace((int*)0);
            });
        }

        public static object testgcnavtive = null;
        public static object testgcnavtive2 = null;
        public static object testgcnavtive3 = null;
        public static object testgcnavtive4 = null;
        public static object testgcnavtive5 = null;
        public static IntPtr asdosire = default(IntPtr);
        public static IntPtr asdosire2 = default(IntPtr);
        public static object emtpyobj = new object();

        public static void loadlib_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            if (ScriptCore.DeviceConfig.DeviceConfig_IsMac()) // Wine for macOS Runtime Windows
                return;

            Simulator.Sleep(0); // check yield

            var p = StringInputDialog.Show
                ("Load Dll Native Library",
                "Path or Dll file?\nExample: C:\\DLL List\\libName.dll or libName.dll",
                "libNiecModCommon.dll",
                256,
                StringInputDialog.Validation.None); // StringInputDialog.Validation.Filename);

            if (p == null || p.Length == 0)
                return;

            niec_native_func.init_class();
            niec_native_func.LoadDLLNativeLibrary(p);
        }

        public unsafe static void testdttod_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            Simulator.Sleep(0); // check yield
            niec_std.mono_runtime_install_handlers();

            if (testgcnavtive4 == null)
            {
                testgcnavtive4 = string.InternalAllocateStr(1000);
                //fixed (char* a = (string)testgcnavtive4)
                //{
                //    for (int i = 0; i < 999; i++)
                //    {
                //        a[i] = (char)0xCC; //'\0';
                //    }
                //}

                // Code for x86:
                //  CC: int3

                uint* at = (uint*)((int)testgcnavtive4.obj_address());
                for (int i = 0x12; i < 980; i++)
                {
                    at[i] = 0xCCCCCCCC;
                }
            }

            new NCopyableTextDialog("you can patch.\n\nNew Address: " + ((uint)testgcnavtive4.obj_address() + 0x12).ToString("X")).SafeShow("testdttod command");

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_debug_text_to_debugger Debugger??"))
                NFinalizeDeath.Debugger_Break();

            niec_native_func.niecmod_native_debug_text_to_debugger(StringInputDialog.Show("NiecMod", "Send Text to Debugger", "Hello NiecMod", 256, StringInputDialog.Validation.None) ?? "Hello NiecMod");
        }

        public static void testagssd_command()
        {
            Simulator.Sleep(0);
            var sim = HitTargetSim() ?? PlumbBob.SelectedActor;
            if (sim == null) 
                return;

            var simd = sim.SimDescription;
            if (simd == null || simd.IsPregnant || simd.mOutfits == null) 
                return;

            var everydayOutfit = simd.GetOutfit(OutfitCategories.Everyday, 0);
            if (everydayOutfit == null || !everydayOutfit.IsValid)
                return;

            if (simd.IsPet && NFinalizeDeath.CheckAccept("Human?"))
            {
                simd.Species = CASAgeGenderFlags.Human;
            }
            else if (simd.Species == CASAgeGenderFlags.Human && NFinalizeDeath.CheckAccept("Pet?")) 
            {
                simd.Species = CASAgeGenderFlags.Dog;
            }

            if (!simd.IsFemale && NFinalizeDeath.CheckAccept("Female?"))
            {
                simd.Gender = CASAgeGenderFlags.Female;
            }
            else if (simd.IsFemale && NFinalizeDeath.CheckAccept("Male?"))
            {
                simd.Gender = CASAgeGenderFlags.Male;
            }

            if (!simd.Teen && NFinalizeDeath.CheckAccept("Teen?")) 
            {
                simd.Age = CASAgeGenderFlags.Teen;
            }
            else if (!simd.Child && NFinalizeDeath.CheckAccept("Childen?"))
            {
                simd.Age = CASAgeGenderFlags.Child;
            }

            if (typeof(OutfitCategories) != null && NFinalizeDeath.CheckAccept("UnsafeReOutfit(...)?")) 
            {
                var os = simd.mOutfits;

                NFinalizeDeath.GCoutfitsBackup.Add(os); // Safe Cache

                simd.mOutfits = new OutfitCategoryMap();

                OutfitCategories[] t = (OutfitCategories[])Enum.GetValues(typeof(OutfitCategories));

                if (NFinalizeDeath.CheckAccept("Check Non Yield?"))
                {
                    nonYieldRunFunc.RunFunc(() =>
                    {
                        //foreach (var item in NFinalizeDeath.OutfitCategories_OnlyEveryday)
                        //{
                        //    NFinalizeDeath.UnsafeReOutfit(simd, item, os);
                        //}

                        foreach (OutfitCategories value in t)
                        {
                            var aList = os[value] as System.Collections.ArrayList;
                            if (aList == null)
                                continue;

                            int count = aList.Count;
                            for (int i = 0; i < count; i++)
                            {
                                NFinalizeDeath.UnsafeReOutfit(simd, value, os, false, i);
                            }
                        }
                    });
                }
                else
                {
                    //foreach (var item in NFinalizeDeath.OutfitCategories_OnlyEveryday)
                    //{
                    //    NFinalizeDeath.UnsafeReOutfit(simd, item, os);
                    //}

                    foreach (OutfitCategories value in t)
                    {
                        var aList = os[value] as System.Collections.ArrayList;
                        if (aList == null)
                            continue;

                        int count = aList.Count;
                        for (int i = 0; i < count; i++)
                        {
                            NFinalizeDeath.UnsafeReOutfit(simd, value, os, false, i);
                        }
                    }
                }

                var testOutfit = simd.GetOutfit(OutfitCategories.Everyday, 0);

                NFinalizeDeath.Assert(testOutfit != null, "GetOutfit(OutfitCategories.Everyday, 0) testOutfit != null failed.");

                if (testOutfit == null)
                    return;

                NFinalizeDeath.Assert(testOutfit.IsValid, "GetOutfit(OutfitCategories.Everyday, 0) testOutfit.IsValid failed.");
            }
        }

        // Kill Mono Security :D
        public static void pmgas_command() {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            if (NFinalizeDeath.func_address_GetAssemblies == 0)
            {
                if (NFinalizeDeath.CheckAccept("Call SafePreventGetAssemblies()?"))
                {
                    NFinalizeDeath.SafePreventGetAssemblies();
                }
                else if (NFinalizeDeath.CheckAccept("Call SafePreventGetAssembliesPro()?"))
                {
                    NFinalizeDeath.SafePreventGetAssembliesPro();
                }
                else if (NFinalizeDeath.CheckAccept("Call UnsafePreventGetAssemblies()?"))
                {
                    NFinalizeDeath.UnsafePreventGetAssemblies();
                }
                else
                {
                    NFinalizeDeath.PreventGetAssemblies();
                }
            }
            else
            {
                NFinalizeDeath.RemovePreventGetAssemblies();
            }
        }

        public static void tmsfunc1_oaseritert()
        {
            NFinalizeDeath.DTESTM();
            NFinalizeDeath.DTESTMOK();
        }

        public static void tmsfunc1_oaseritertX()
        {
            try
            {
                if (NFinalizeDeath.CheckAccept("Call DTESTM Debugger??"))
                    NFinalizeDeath.Debugger_Break();

                if (NFinalizeDeath.DTESTM())
                {
                    NFinalizeDeath.Show_MessageDialog("Done you can set IL custom your script function :)");
                }
                else
                {
                    NFinalizeDeath.Show_MessageDialog("Failed. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Show_MessageDialog("Exception. Try Again"); }
        }

        // Kill Mono Security :D
        public static void tmsfunc1_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            Simulator.Sleep(0); // check yield

            niec_std.mono_runtime_install_handlers();

            var type = typeof(NFinalizeDeath);
            var m01 = (MonoMethod)type.GetMethod("DTESTMOK");
            if (m01 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"DTESTMOK\") failed");
                return;
            }

            var m00address00 = m01.obj_address();
            var m00address01 = m01.mhandle;
            var m00address02 = new NFinalizeDeath.FunctionX(NFinalizeDeath.DTESTMOK).method_ptr;

            var m02 = (MonoMethod)type.GetMethod("DTESTM");
            if (m02 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"DTESTM\") failed");
                return;
            }

            var m01address00 = m02.obj_address();
            var m01address01 = m02.mhandle;
            var m01address02 = new NFinalizeDeath.FunctionX(NFinalizeDeath.DTESTM).method_ptr;

            new NCopyableTextDialog("you can patch.\n\n" +

                "DTESTMOK:\nOA: 0x" + ((uint)m00address00).ToString("X") +
                "\nH: 0x" + ((uint)m00address01).ToString("X") +
                "\nD: 0x" + ((uint)m00address02).ToString("X") +

                "\n\nDTESTM:\nOA: 0x" + ((uint)m01address00).ToString("X") +
                "\nH: 0x" + ((uint)m01address01).ToString("X") +
                "\nD: 0x" + ((uint)m01address02).ToString("X")

            ).SafeShow("tmsfunc1 command");

            niec_std.mono_runtime_install_handlers();

            if (NFinalizeDeath.CheckAccept("Call DTESTM() And DTESTMOK()??"))
            {
                tmsfunc1_oaseritert();
            }

            tmsfunc1_oaseritertX();
        }

        public static void exlists2_command()
        {
            NFinalizeDeath.MsCorlibModifed_Exlists(false);
        }

        public static void exlists3_command()
        {
            if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) == 0)
                NFinalizeDeath.MsCorlibModifed_Exlists(false);
        }

        public static void testagssdall_command()
        {
            Simulator.Sleep(0); // check yield
            var sim = HitTargetSim() ?? PlumbBob.SelectedActor;
            if (sim == null)
                return;

            var simd = sim.SimDescription;
            if (simd == null || simd.IsPregnant || simd.mOutfits == null)
                return;

            var everydayOutfit = simd.GetOutfit(OutfitCategories.Everyday, 0);
            if (everydayOutfit == null || !everydayOutfit.IsValid)
                return;

            //CASAgeGenderFlags vS = CASAgeGenderFlags.Human;
            //CASAgeGenderFlags vG = CASAgeGenderFlags.Male;
            //CASAgeGenderFlags vA = CASAgeGenderFlags.Adult;
            //
            //if (NFinalizeDeath.CheckAccept("Pet?"))
            //{
            //    vS = CASAgeGenderFlags.Dog;
            //}
            //if (vS == CASAgeGenderFlags.Human && NFinalizeDeath.CheckAccept("Pet?"))
            //{
            //    vS = CASAgeGenderFlags.Dog;
            //}
            //
            //if (NFinalizeDeath.CheckAccept("Female?"))
            //{
            //    vG = CASAgeGenderFlags.Female;
            //}
            //if (vG == CASAgeGenderFlags.Female && NFinalizeDeath.CheckAccept("Male?"))
            //{
            //    vG = CASAgeGenderFlags.Male;
            //}
            //
            //if (NFinalizeDeath.CheckAccept("Teen?"))
            //{
            //    vA = CASAgeGenderFlags.Teen;
            //}
            //else if (NFinalizeDeath.CheckAccept("Childen?"))
            //{
            //    vA = CASAgeGenderFlags.Child;
            //}

            if (typeof(OutfitCategories) != null && NFinalizeDeath.CheckAccept("UnsafeReOutfit(...)?"))
            {
                bool a = NFinalizeDeath.CheckAccept("Check Non Yield?");
                OutfitCategories[] t = (OutfitCategories[])Enum.GetValues(typeof(OutfitCategories));
                var os = simd.mOutfits;

                NFinalizeDeath.GCoutfitsBackup.Add(os); // Safe SimOutfit Cache
                var pSIMLIST = NFinalizeDeath.UpdateNiecSimDescriptions(true, false, true).ToArray();
                ListCollon.SafeObjectGC.Add(pSIMLIST);

                foreach (var item_simd in pSIMLIST)
                {
                    if (item_simd == null || item_simd.mHairColors == null)
                        continue;

                    if (item_simd == simd)
                        continue;

                    if (!item_simd.IsValidDescription || !item_simd.IsValid)
                        continue;

                    //if (!NFinalizeDeath.SD_OutfitsIsValid2(item_simd, true))
                    //    continue;
                    //if (item_simd.mOutfits == null || item_simd.IsPregnant)
                    //    continue;

                    if (item_simd.Pregnancy != null)
                        continue;

                    if (item_simd.mFirstName == null || item_simd.mFirstName.Length == 0)
                        continue;

                    if (!item_simd.IsEP11Bot && (item_simd.mLastName == null || item_simd.mLastName.Length == 0))
                        continue;

                    item_simd.mOutfits = new OutfitCategoryMap();

                    if (a)
                    {
                        nonYieldRunFunc.RunFunc(() =>
                        {
                            foreach (OutfitCategories value in t)
                            {
                                var aList = os[value] as System.Collections.ArrayList;
                                if (aList == null)
                                    continue;

                                int count = aList.Count;
                                for (int i = 0; i < count; i++)
                                {
                                    NFinalizeDeath.UnsafeReOutfit(item_simd, value, os, false, i);
                                }
                            }
                        });
                    }
                    else
                    {
                        foreach (OutfitCategories value in t)
                        {
                            var aList = os[value] as System.Collections.ArrayList;
                            if (aList == null)
                                continue;

                            int count = aList.Count;
                            for (int i = 0; i < count; i++)
                            {
                                NFinalizeDeath.UnsafeReOutfit(item_simd, value, os, false, i);
                            }
                        }
                    }
                }

                if (NFinalizeDeath.IsOpenDGSInstalled || !NiecHelperSituation.__acorewIsnstalled__)
                    Simulator.Sleep(0);

                
                //nonYieldRunFunc.GCSafe.Clear();
            }
        }


        public static void keepcreatesim_command()
        {
            bool t = NiecHelperSituation.__acorewIsnstalled__ && !NFinalizeDeath.IsOpenDGSInstalled;
            foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(true, false, true).ToArray())
            {
                if (item == null) 
                    continue;
                if (item.CreatedSim == null)
                {
                    if (t)
                        SimDescCleanseTask.SafeCallSimDescCleanseO(item);
                    else
                    {
                        NFinalizeDeath.SimDescCleanse(item, true, true);
                    }
                }
            }
        }


        public static void importhouse_command()
        {
            if (!Simulator.CheckYieldingContext(false))
                return;

            if (NFinalizeDeath.CheckAccept("Clean SimDesc Disposed?")) {
                foreach (var item in ListCollon.NiecDisposedSimDescriptions)
                {
                    SimDescCleanseTask.SafeCallSimDescCleanseO(item);
                }
            }

            var lot = NFinalizeDeath.GetCameraTargetLotOrTargetLot();
            if (lot != null && !(lot is WorldLot))
            {
                if (lot.Household == null)
                {
                    HouseholdContents aa;
                    string packageFileName = NFinalizeDeath.GetLastPackageName(false);
                    Household hoc = NiecMod.Commom.Proxies.NLibraryUtls._ImportHousehold
                        (Simulator.CheckYieldingContext(false) ? StringInputDialog.Show("Package File", "", packageFileName ?? "Funke.package", 256, StringInputDialog.Validation.None) : "", lot, false, true, out aa);
                    if (hoc != null)
                    {
                        NiecException.PrintMessagePro("Imported Household ID: " + hoc.mHouseholdId, false, float.MaxValue);
                        foreach (var item in NFinalizeDeath.Household_GetAllActors(hoc))
                        {
                            NFinalizeDeath.SendHomeForSim(item);
                        }
                        var hocCount = hoc.AllSimDescriptions.Count;
                        if (hocCount > 0 && hoc.mMembers.ActorList.Count > 0 && !ScriptCore.World.World_IsEditInGameFromWBModeImpl() && GameStates.IsLiveState && PlumbBob.SelectedActor == null && NFinalizeDeath.FixUpPlumbBobSingletonNull() && Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Force Set Active Actor?"))
                        {
                            PlumbBob.ForceSelectActor(NFinalizeDeath.HouseholdMembersToSim(hoc, false, false));
                        }
                    }

                }
                else
                {
                    if (NFinalizeDeath.CheckAccept("Merge Household?"))
                    {
                        NFinalizeDeath.RemoveNullForHouseholdMembers(lot.Household);
                        string packageFileName = NFinalizeDeath.GetLastPackageName(false);
                        HouseholdContents contents;

                        Household householdImported = NiecMod.Commom.Proxies.NLibraryUtls._ImportHousehold(
                            Simulator.CheckYieldingContext(false) ?
                                StringInputDialog.Show("Package File", "", packageFileName ?? "Funke.package", 256, StringInputDialog.Validation.None)
                                :
                                ""
                            ,
                            (lot.Household == null) ? lot : null,
                            false,
                            false,
                            out contents
                        );

                        if (householdImported != null)
                        {
                            var lotHousehold = lot.Household;
                            if (lotHousehold == null)
                            {
                                lot.MoveIn(householdImported);
                                NiecException.PrintMessagePro("lotHousehold == null", false, 500f);
                                return;
                            }

                            var memberHoc = householdImported.mMembers;
                            if (memberHoc == null)
                            {
                                NiecException.PrintMessagePro("Error: memberHoc == null", false, 500f);
                                return;
                            }

                            if (memberHoc.mAllSimDescriptions == null)
                            {
                                NiecException.PrintMessagePro("Error: memberHoc.mAllSimDescriptions == null", false, 500f);
                                return;
                            }

                            var householdSimMembers = memberHoc.mAllSimDescriptions.ToArray();
                            foreach (SimDescription simd in householdSimMembers)
                            {
                                if (simd != null)
                                {
                                    NFinalizeDeath.Household_Remove(simd, true);
                                    simd.mHousehold = null;
                                }
                            }

                            memberHoc.mAllSimDescriptions.Clear();
                            memberHoc.mPetSimDescriptions.Clear();
                            memberHoc.mSimDescriptions.Clear();

                            lotHousehold.mFamilyFunds += householdImported.mFamilyFunds;

                            householdImported.Destroy();
                            //householdImported.Dispose(); auto dispose :)
                            householdImported = null;

                            foreach (SimDescription simDesc in householdSimMembers)
                            {
                                if (NFinalizeDeath.Household_Add(lotHousehold, simDesc, false))
                                {
                                    NFinalizeDeath.SendHomeForSim(NFinalizeDeath.SimDesc_SafeInstantiate(simDesc, Vector3.OutOfWorld));
                                }
                            }

                            for (int i = 0; i < 15; i++)
                            {
                                Simulator.Sleep(0);
                            }
                            
                            foreach (SimDescription simDesc in householdSimMembers)
                            {
                                if (simDesc.mSim != null)
                                {
                                    try
                                    {
                                        simDesc.Fixup();
                                    }
                                    catch (ResetException)
                                    { throw; }
                                    catch { }
                                    simDesc.SendSimHome();
                                }
                            }

                            if (GameStates.IsLiveState && PlumbBob.SelectedActor == null && lotHousehold.mMembers.mAllSimDescriptions.Count > 0 && lotHousehold.mMembers.ActorList.Count > 0 && !ScriptCore.World.World_IsEditInGameFromWBModeImpl() && NFinalizeDeath.FixUpPlumbBobSingletonNull() && Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Force Set Active Actor?"))
                            {
                                PlumbBob.ForceSelectActor(NFinalizeDeath.HouseholdMembersToSim(lotHousehold, false, false));
                            }
                        }
                    }
                    else NiecException.PrintMessagePro("Lot Household Name: " + lot.Household.Name, false, 100);
                }
            }
        }


        public unsafe static void testloadlib_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            if (testgcnavtive5 == null)
            {
                testgcnavtive5 = string.InternalAllocateStr(1000);
                //fixed (char* a = (string)testgcnavtive4)
                //{
                //    for (int i = 0; i < 999; i++)
                //    {
                //        a[i] = (char)0xCC; //'\0';
                //    }
                //}

                // Code for x86:
                //  CC: int3

                uint* at = (uint*)((int)testgcnavtive5.obj_address());
                for (int i = 8; i < 980; i++)
                {
                    at[i] = 0xCCCCCCCC;
                }
            }

            new NCopyableTextDialog("you can patch.\n\nNew Address: " + ((uint)testgcnavtive5.obj_address() + 0x12).ToString("X")).SafeShow("testloadlib command");

            niec_std.mono_runtime_install_handlers();

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_load_library Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                if ((int)niec_native_func.niecmod_native_load_library("Vrty.dll") != 0)
                { 
                    NFinalizeDeath.Show_MessageDialog("Done Valid :)"); 
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }

            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_load_library(String)"); }
         
          
        }

       //public static void SafeADumpNativeFunction()
       //{
       //
       //}

        public static void DumpNativeFunction64bit()
        {
            if (NFinalizeDeath.NiecModIs64Bit() && NFinalizeDeath.GameIs64Bit(false))
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new InvalidOperationException("Sims 3 (32 bit)!");
            }
        }

        public static void DumpNativeFunction()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
            {
                DumpNativeFunction64bit();
                return;
            }

            if (AppDomain.CurrentDomain == null)
                throw new NotSupportedException();

            if (!NFinalizeDeath.CheckAccept("Are you sure Run DumpNativeFunction()?"))
                return;

            StringBuilder str = new StringBuilder();
            StringBuilder str2 = niec_native_func.cache_done_niecmod_native_debug_text_to_debugger ? new StringBuilder() : null;
            if (str2 != null)
                niec_native_func.OutputDebugString("Start DumpNativeFunction()");

            str.Append("DumpNativeFunction()\n\n\n");

            bool fast = NFinalizeDeath.CheckAccept("Fast ScriptCore, mscorlib?");
            bool fastc = !fast && NFinalizeDeath.CheckAccept("Fast ScriptCore");

            uint an = 0;
            uint am = 0;

            if (fast)
            {
                an = 0x00400000u;
                am = 0x00FFFFFFu;
            }

            bool isdone = false, isdone1 = false;

            IntPtr a01 = default(IntPtr);
            IntPtr a02 = AssemblyCheckByNiec.FindAssembly("mscorlib")._mono_assembly;
            //IntPtr a03 = default(IntPtr);

            var typeObject = typeof(object);

            if (fast)
            {
                a01 = AssemblyCheckByNiec.FindAssembly("ScriptCore")._mono_assembly;
               
                //a03 = AssemblyCheckByNiec.FindAssembly("UI")._mono_assembly;
            }

            foreach (var item in fastc ? new Assembly[] { AssemblyCheckByNiec.FindAssembly("ScriptCore") } : NFinalizeDeath.GetAssemblies())//AppDomain.CurrentDomain.GetAssemblies())
            {
                if (item == null) 
                    continue;

                if (fast)
                {
                    if (item._mono_assembly != a01 && item._mono_assembly != a02) //&& item._mono_assembly != a03)
                    {
                        continue;
                    }
                }

                bool is_mscorlib = item._mono_assembly == a02;

                try
                {
                    foreach (var moduleChild in item.GetModulesInternal())
                    {
                        if (moduleChild == null)
                            continue;

                        try
                        {
                            foreach (var itemTypeChild in moduleChild.GetTypes())
                            {
                                if (itemTypeChild == null)
                                    continue;
                                try
                                {
                                    foreach (var itemMethed in itemTypeChild.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                                    {
                                        if (itemMethed == null || itemMethed.IsConstructor)
                                            continue;

                                       

                                        bool isNativeFunc = false;
                                        try
                                        {
                                            niec_native_func.OutputDebugString("Methed Name: " + itemMethed.Name + "\nIsGenericMethod: " + itemMethed.IsGenericMethod);
                                            System.Runtime.InteropServices.Marshal.Prelink(itemMethed);

                                            if (!is_mscorlib)
                                            {
                                                if (itemMethed.DeclaringType.Assembly._mono_assembly == a02)
                                                    continue;
                                            }
                                            else
                                            {
                                                if (typeObject != itemTypeChild && typeObject == itemMethed.DeclaringType)
                                                {
                                                    continue;
                                                }
                                            }
                                            //var p = itemMethed.GetCustomAttributes(false);
                                            //if (p != null)
                                            //{
                                            //    foreach (var itemAttribute in p)
                                            //    {
                                            //        if (itemAttribute == null)
                                            //            continue;
                                            //
                                            //        try
                                            //        {
                                            //            var a = itemAttribute as System.Runtime.CompilerServices.MethodImplAttribute;
                                            //            if (a != null && a.Value == System.Runtime.CompilerServices.MethodImplOptions.InternalCall)
                                            //            {
                                            //                isNativeFunc = true;
                                            //                break;
                                            //            }
                                            //            var a1 = itemAttribute as System.Runtime.InteropServices.DllImportAttribute;// ?? MonoMethod.GetDllImportAttribute(itemMethed.MethodHandle.Value);
                                            //            if (a1 != null && a1.Value != null && a1.Value.Length > 0)
                                            //            {
                                            //                isNativeFunc = true;
                                            //                break;
                                            //            }
                                            //        }
                                            //        catch (Exception)
                                            //        { }
                                            //    }
                                            //}
                                            //try
                                            //{
                                            //    var p = itemMethed.GetCustomAttributes(typeof(System.Runtime.CompilerServices.MethodImplAttribute), true);
                                            //    for (int i = 0; i < p.Length; i++)
                                            //    {
                                            //        //var a = p[i] as System.Runtime.CompilerServices.MethodImplAttribute;
                                            //        //if (a != null && a.Value == System.Runtime.CompilerServices.MethodImplOptions.InternalCall)
                                            //        //{
                                            //        //    isNativeFunc = true;
                                            //        //    break;
                                            //        //}
                                            //        isNativeFunc = true;
                                            //    }
                                            //    if (!isNativeFunc)
                                            //    {
                                            //        p = itemMethed.GetCustomAttributes(typeof(System.Runtime.InteropServices.DllImportAttribute), true);
                                            //        for (int i = 0; i < p.Length; i++)
                                            //        {
                                            //            //var a = p[i] as System.Runtime.InteropServices.DllImportAttribute;
                                            //            //if (a != null && a.Value != null && a.Value.Length > 0)
                                            //            //{
                                            //            //    isNativeFunc = true;
                                            //            //    break;
                                            //            //}
                                            //            isNativeFunc = true;
                                            //        }
                                            //    }
                                            //}
                                            //catch (Exception)
                                            //{}
                                            uint funca;
                                            try
                                            {
                                                funca = niec_script_func.niecmod_safecall_script_get_func_ptr_all(((MonoMethod)itemMethed).mhandle, am, an);
                                                if (funca != 0 && funca > an && funca < am)
                                                    isNativeFunc = true;
                                            }
                                            catch (Exception)
                                            { continue; }


                                            if (isNativeFunc)
                                            {
                                                isdone1 = true;
                                                var monom = itemMethed as MonoMethod;
                                                if (monom != null)
                                                {
                                                    isdone = true;
                                                    str.Append("---------------------------------------");
                                                    str.AppendLine();
                                                    str.AppendLine();

                                                    if (str2 != null)
                                                    {
                                                        str2.Append("DNF ---------------------------------------");
                                                        str2.AppendLine();
                                                        str2.AppendLine();
                                                    }

                                                    var funcAddress = "0x" + funca//niec_script_func.niecmod_safecall_script_get_func_ptr_dll2(monom.mhandle)
                                                        .ToString("X");

                                                    str.Append(funcAddress);
                                                    str.AppendLine();

                                                    if (str2 != null)
                                                    {
                                                        str2.Append(funcAddress);
                                                        str2.AppendLine();
                                                    }

                                                    string funcName;

                                                    try
                                                    {
                                                        funcName = NFinalizeDeath.GetGoodMethodName(itemMethed);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        try
                                                        {
                                                            funcName = monom.ToString();
                                                        }
                                                        catch (Exception)
                                                        {
                                                            funcName = itemMethed.Name;
                                                        }
                                                    }

                                                    var typeName = itemTypeChild.AssemblyQualifiedName;

                                                    str.Append(funcName);
                                                    str.AppendLine();

                                                    str.Append(typeName);

                                                    str.AppendLine();
                                                    str.AppendLine();
                                                    str.Append("---------------------------------------");

                                                    if (str2 != null)
                                                    {
                                                        str2.Append(funcName);
                                                        str2.AppendLine();

                                                        str2.Append(typeName);

                                                        str2.AppendLine();
                                                        str2.AppendLine();
                                                        str2.Append("--------------------------------------- DNF END");

                                                        niec_native_func.OutputDebugString(str2.ToString());

                                                        str2 = new StringBuilder();
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        { NFinalizeDeath.M(e); }
                                    }
                                }
                                catch (Exception e)
                                { NFinalizeDeath.M(e); }
                            }
                        }
                        catch (Exception e)
                        { NFinalizeDeath.M(e); }
                    }
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
            }

            
            if (!isdone && !isdone1)
            {
                NFinalizeDeath.Assert("Failed dnf command");
            }

            //new NCopyableTextDialog("isdone: " + isdone + "\nisdone1: " + isdone1).SafeShow("dnf command");

            str.Append("\n\n\nEnd DumpNativeFunction");

            uint fileHandle = 0;
            string s = Simulator.CreateExportFile(ref fileHandle, "DNF");
            if (fileHandle == 0)
                throw new NotSupportedException();

            str.Append("\nFile Name: " + s + "\nDate: " + DateTime.Now.ToString());
            str.Append('\0');

            if (!Simulator.AppendToScriptErrorFile(fileHandle, str.ToString().ToCharArray()))
            {
                Simulator.CloseScriptErrorFile(fileHandle);
                throw new NotSupportedException();
            }

            Simulator.CloseScriptErrorFile(fileHandle);
        }

        public static void testhinlothome_command()
        {
            var ahousehold = Household.ActiveHousehold;
            if (ahousehold == null || ahousehold.LotHome == null)
                goto r;

            NFinalizeDeath.Assert(ahousehold.LotHome.mHousehold != null, "ActiveHousehold.LotHome.mHousehold != null failed.");

            r:foreach (var household in NFinalizeDeath.SC_GetObjects<Household>())
            {
                if (household == null || household.LotHome == null)
                    continue;

                NFinalizeDeath.Assert(household.LotHome.mHousehold != null, "household.LotHome.mHousehold != null failed.\nID: " + household.HouseholdId);
            }
        }

        public static void chouselot_command()
        {
            var lot = NFinalizeDeath.GetCameraTargetLotOrTargetLot();
            if (lot == null || lot.Household != null || lot is WorldLot) 
                return;

            Create.CreateActiveHouseholdAndActiveActor(lot, false);
        }

        public unsafe static void tmnfunc3x_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            try
            {
                niec_native_func.init_class();
            }
            catch (Exception)
            {
                NFinalizeDeath.Assert("(SIGSEGV) Exception. niec_native_func.init_class(void)");
            }

            try
            {
                if (NFinalizeDeath.CheckAccept("Debugger Break"))
                    NFinalizeDeath.Debugger_Break();
                niec_native_func.niecmod_native_debug_text_to_debugger("test");
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. OutputDebugString(String)"); }

            try
            {
                if (NFinalizeDeath.CheckAccept("Debugger Break"))
                    NFinalizeDeath.Debugger_Break();
                niec_native_func.niecmod_native_load_library("Vrty.dll");
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. LoadLibrary(String)"); }
        }

        public unsafe static void tmnfunc2_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            var type = typeof(niec_native_func);
            var m01 = (MonoMethod)type.GetMethod("niecmod_native_custom_test");

            if (m01 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_custom_test\") failed");
                return;
            }

            var m00address01 = m01.mhandle;
            uint funcPtr = ((uint)m00address01.ToInt32()) + 0x20u;

            if (*(uint*)funcPtr == 0x00000000)
            {
                var objAddress = new IntPtr(0);
                if (testgcnavtive2 == null)
                {
                    testgcnavtive2 = string.InternalAllocateStr(1000);

                    //fixed (char* a = (string)testgcnavtive2)
                    //{
                    //    for (int i = 0; i < 999; i++)
                    //    {
                    //        a[i] = (char)0xCC; //'\0';
                    //    }
                    //}

                    // Code for x86:
                    //  CC: int3

                    uint* at = (uint*)((int)testgcnavtive2.obj_address());
                    for (int i = 12; i < 980; i++)
                    {
                        at[i] = 0xCCCCCCCC;
                    }

                    objAddress = testgcnavtive2.obj_address();

                    /*
                        Code for x86:
                        B0 01: mov al,1 
                        C3: ret 
                        90: nop 
                     
                        C code:
                        return 1;
                     */

                    // Little endian to Big endian

                    *(uint*)((uint)objAddress + 0x12) = NFinalizeDeath.SwapOrgerBit32(0xB001C390u);

                    *(uint*)funcPtr = (uint)objAddress.ToInt32() + 0x12;
                }
                else
                {
                    /*
                        Code for x86:
                        B0 01: mov al,1 
                        C3: ret 
                        90: nop
                     
                        C code:
                        return 1;
                     */

                    // Little endian to Big endian

                    *(uint*)((uint)testgcnavtive2.obj_address() + 0x12) = NFinalizeDeath.SwapOrgerBit32(0xB001C390u);
                    *(uint*)funcPtr = (uint)testgcnavtive2.obj_address().ToInt32() + 0x12;
                }
            }

            testgcnavtive2.obj_address(); // check SIGSEGV 
            GC.KeepAlive(testgcnavtive2);

            try
            {
                niec_std.mono_runtime_install_handlers();

                if (NFinalizeDeath.CheckAccept("Call niecmod_native_custom_test Debugger??"))
                {
                    NFinalizeDeath.Debugger_Break();
                }

                if (niec_native_func.niecmod_native_custom_test())
                {
                    NFinalizeDeath.Show_MessageDialog("Done Valid");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_custom_test()"); }
        }

        public static void testye_command() {
            Simulator.YieldingDisabled = false;
        }

        public static void testyia_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            if (NFinalizeDeath.CheckAccept("Call PreventSetYieldingDisabled??"))
                NFinalizeDeath.PreventSetYieldingDisabled();

        
            var type = typeof(ScriptCore.Simulator);
            var m01 = (MonoMethod)type.GetMethod("Simulator_SetYieldingDisabledImpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (NFinalizeDeath.CheckAccept("Call niecmod_script_set_custom_native_function_dll_created??"))
            {
                if (!niec_script_func.niecmod_script_set_custom_native_function_dll_created(m01.mhandle, 0x0FFFFFFF)) {
                    NFinalizeDeath.Assert("niecmod_script_set_custom_native_function_dll_created() failed");
                    return;
                }
            }

            type = typeof(niec_native_func);
            var m02 = (MonoMethod)type.GetMethod("niecmod_native_load_library", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            new NCopyableTextDialog("you can patch.\n\nSimulator_SetYieldingDisabledImpl address: 0x"  + ((uint)m01.mhandle).ToString("X")
                + "\n\nniecmod_native_load_library Address: 0x" + ((uint)m02.mhandle).ToString("X") +
                "\n\nSA: 0x" + ((uint)m01.obj_address()).ToString("X") 
                + "\nNFUNCA: 0x" + ((uint)m02.obj_address()
                ).ToString("X")).SafeShow("testyia command");

            if (NFinalizeDeath.CheckAccept("Call Simulator_SetYieldingDisabledImpl Debugger??"))
            {
                NFinalizeDeath.Debugger_Break();
            }

            ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(true);
        }
        public unsafe static void tmnfunc5_Command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            //var type = typeof(niec_native_func);
            if (asdosire2.value == null)
            {
                asdosire2 = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUni(string.InternalAllocateStr(1000));
                if (asdosire2.value == null)
                {
                    NFinalizeDeath.Assert("tmnfunc5_Command() asdosire.value == NULL");
                    return;
                }
                niec_native_func.OutputDebugString("tmnfunc5 adderss: 0x" + ((uint)asdosire2).ToString("X"));
            }

            new NCopyableTextDialog("you can patch.\n\nNew Address: " + ((uint)asdosire2 + 0x8).ToString("X")).SafeShow("tmnfunc5 command");

            niec_std.mono_runtime_install_handlers();

            var eax2ptr = emtpyobj.obj_address();
            var eax2 = (uint)eax2ptr;
            
            if (NFinalizeDeath.CheckAccept("Call niecmod_native_obj_get_address Debugger??"))
                NFinalizeDeath.Debugger_Break();

            var eaxptr = niec_native_func.niecmod_native_obj_get_address(emtpyobj);
            uint eax = 0;

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_obj_get_address_nonptr Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                eax = niec_native_func.niecmod_native_obj_get_address_nonptr(emtpyobj);
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_obj_get_address_nonptr(obj)"); }
           

            try
            {
                if (eax != 0)
                {
                    // NFinalizeDeath.Show_MessageDialog("Done Valid\nnm_obj_get_address: 0x" + eax.ToString("X") + "\nMono obj_adderss: 0x" + eax2.ToString("X"));
                    new NCopyableTextDialog("Done Valid\nnm_obj_get_address: 0x" + eax.ToString("X") + "\nMono obj_adderss: 0x" + eax2.ToString("X")).SafeShow("tmnfunc5 command");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_obj_get_address(obj)"); }

            if (eax == 0)
                return;

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_get_object_for_ptr Debugger??"))
                NFinalizeDeath.Debugger_Break();
         
            try
            {
                var r = niec_native_func.niecmod_native_get_object_for_ptr(eaxptr);
                eaxptr = niec_native_func.niecmod_native_obj_get_address(r);

                if (r != null)
                    eax2ptr = r.obj_address();
                else 
                    eax2ptr = new IntPtr(0);

                eax = (uint)eaxptr;
                eax2 = (uint)eax2ptr;

                if (r != null)
                {
                    // NFinalizeDeath.Show_MessageDialog("Done Valid\nnm_obj_get_address: 0x" + eax.ToString("X") + "\nMono obj_adderss: 0x" + eax2.ToString("X"));
                    new NCopyableTextDialog("Done Valid\nniecmod_native_get_object_for_ptr\nnm_obj_get_address: 0x" + eax.ToString("X") + "\nMono obj_adderss: 0x" + eax2.ToString("X")).SafeShow("tmnfunc5 command");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_get_object_for_ptr(ptr)"); }

            if (eax == 0)
                return;

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_get_object_for_nonptr Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                 var r = niec_native_func.niecmod_native_get_object_for_nonptr(eax);
                 eaxptr = niec_native_func.niecmod_native_obj_get_address(r);

                 if (r != null)
                     eax2ptr = r.obj_address();
                 else
                     eax2ptr = new IntPtr(0);

                 eax = (uint)eaxptr;
                 eax2 = (uint)eax2ptr;

                 if (r != null)
                 {
                     // NFinalizeDeath.Show_MessageDialog("Done Valid\nnm_obj_get_address: 0x" + eax.ToString("X") + "\nMono obj_adderss: 0x" + eax2.ToString("X"));
                     new NCopyableTextDialog("Done Valid\nniecmod_native_get_object_for_nonptr\nnm_obj_get_address: 0x" + eax.ToString("X") + "\nMono obj_adderss: 0x" + eax2.ToString("X")).SafeShow("tmnfunc5 command");
                 }
                 else
                 {
                     NFinalizeDeath.Assert("Invalid. Try Again?");
                 }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_get_object_for_nonptr(...)"); }

            object newtemp = new object();
            ListCollon.SafeObjectGC.Add(newtemp);
            Bim newtemp2 = Bim.GetStatic();
            ListCollon.SafeObjectGC.Add(newtemp2);

            var aa = newtemp.obj_address();
            var aa2 = newtemp2.obj_address();

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_get_classobject_for_ptr<object> Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                if ((object)niec_native_func.niecmod_native_get_classobject_for_ptr<object>(aa) == (object)newtemp)
                {
                    NFinalizeDeath.Assert("Valid Done :)");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_get_classobject_for_ptr<object>(...)"); }

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_get_classobject_for_ptr<Bim> Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                if ((object)niec_native_func.niecmod_native_get_classobject_for_ptr<Bim>(aa2) == (object)newtemp2)
                {
                    NFinalizeDeath.Assert("Valid Done :)");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_get_classobject_for_ptr<Bim>(...)"); }

            ///////////////////////////////

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_get_classobject_for_nonptr<object> Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                if ((object)niec_native_func.niecmod_native_get_classobject_for_nonptr<object>(newtemp) == (object)newtemp)
                {
                    NFinalizeDeath.Assert("Valid Done :)");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_get_classobject_for_ptr<object>(...)"); }

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_get_classobject_for_nonptr<Bim> Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                if ((object)niec_native_func.niecmod_native_get_classobject_for_nonptr<Bim>(newtemp2) == (object)newtemp2)
                {
                    NFinalizeDeath.Assert("Valid Done :)");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_get_classobject_for_nonptr<Bim>(...)"); }

        }
        public unsafe static void tmnfunc4_Command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            var type = typeof(niec_native_func);
            if (asdosire.value == null)
            {
                //asdosire = System.Runtime.InteropServices.Marshal.StringToHGlobalUni(string.InternalAllocateStr(1000));
                if (asdosire.value == null)
                    asdosire = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUni(string.InternalAllocateStr(1000));
                if (asdosire.value == null)
                {
                    NFinalizeDeath.Assert("tmnfunc4_Command() asdosire.value == NULL");
                    return;
                }

                niec_native_func.OutputDebugString("tmnfunc4 adderss: 0x" + ((uint)asdosire).ToString("X"));

                // Code for x86:
                //  CC: int3

                uint* at = (uint*)((int)asdosire.value);
                for (int i = 0x8; i < 900; i++)
                {
                    at[i] = 0xCCCCCCCC;
                }
            }

            new NCopyableTextDialog("you can patch.\n\nNew Address: " + ((uint)asdosire + 0x8).ToString("X")).SafeShow("tmnfunc4 command");

            niec_std.mono_runtime_install_handlers();

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_cpuid Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                uint eax = 1;
                uint ebx = 2;
                uint ecx = 3;
                uint edx = 4;

                niec_native_func.niecmod_native_cpuid(ref eax, ref ebx, ref ecx, ref edx);

                if (eax != 0)
                {
                    NFinalizeDeath.Show_MessageDialog("Done Valid eax: 0x" + eax.ToString("X"));
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_cpuid(String)"); }

            niec_std.mono_runtime_install_handlers();

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_PRT_FS Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                uint fsptr = (uint)niec_native_func.niecmod_native_ptr_fs_zero(0).value;
                if (fsptr != 0)
                {
                    NFinalizeDeath.Show_MessageDialog("Done Valid fsptr: 0x" + fsptr.ToString("X"));
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_PRT_FS(int)"); }

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_message_box Debugger??"))
                NFinalizeDeath.Debugger_Break();

            try
            {
                int r = (int)niec_native_func.niecmod_native_message_box(0, "Hello Debugger", "NiecMod", (niec_native_func.MB_Type)0x31); //niec_native_func.MB_Type.MB_ICONEXCLAMATION | niec_native_func.MB_Type.MB_YESNO);
                if (r != 0)
                {
                    niec_native_func.OutputDebugString("Done Valid r: 0x" + r.ToString("X"));
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_message_box(...)"); }

            try
            {
                var v0 = niec_script_func.niecmod_script_get_func_ptr(((MonoMethod)type.GetMethod("DebuggerBreak", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)).mhandle);
                var v1 = new IntPtr(v0);
                var v2 = new IntPtr(0);

                if (NFinalizeDeath.CheckAccept("Call niecmod_native_create_thread Debugger??"))
                    NFinalizeDeath.Debugger_Break();

                int r = (int)niec_native_func.niecmod_native_create_thread(v1, v2, 3000);
                if (r != 0)
                {
                    NFinalizeDeath.Show_MessageDialog("Done Valid r: 0x" + r.ToString("X"));
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_create_thread(...)"); }
         
        }

        public static void exlt_command()
        {
            if (!NFinalizeDeath.NiecModIs64Bit() && NFinalizeDeath.GameIs64Bit(true))
                return;
            if (!niec_native_func.cache_done_niecmod_native_load_library)
                return; 
            if (ScriptCore.DeviceConfig.DeviceConfig_IsMac())
                return;
            if (!NFinalizeDeath.CheckAccept("Are you sure Force Exit Game?"))
                return;
            

            if (NiecHelperSituation.__acorewIsnstalled__ && NInjetMethed.DoneInjectOuit)
                ScriptCore.GameUtils.GameUtils_TransitionToQuitImpl();

            niec_native_func.LoadDLLNativeLibrary("exitgame.dll");
        }

        public static void tmsfunc2_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            Simulator.Sleep(0); // check yield

            niec_std.mono_runtime_install_handlers();

            var type = typeof(NFinalizeDeath);
            var m01 = (MonoMethod)type.GetMethod("TestRunSEDInitProductFlags");
            if (m01 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"TestRunSEDInitProductFlags\") failed");
                return;
            }

            var m00address00 = m01.obj_address();
            var m00address01 = m01.mhandle;
            var m00address02 = new NFinalizeDeath.Function(NFinalizeDeath.TestRunSEDInitProductFlags).method_ptr;

            var m02 = (MonoMethod)typeof(GameUtils).GetMethod("InitProductFlags");
            if (m02 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"InitProductFlags\") failed");
                return;
            }

            var m01address00 = m02.obj_address();
            var m01address01 = m02.mhandle;
            var m01address02 = new NFinalizeDeath.Function(GameUtils.InitProductFlags).method_ptr;

            new NCopyableTextDialog("you can patch.\n\n" +

                "TestRunSEDInitProductFlags:\nOA: 0x" + ((uint)m00address00).ToString("X") +
                "\nH: 0x" + ((uint)m00address01).ToString("X") +
                "\nD: 0x" + ((uint)m00address02).ToString("X") +

                "\n\nInitProductFlags:\nOA: 0x" + ((uint)m01address00).ToString("X") +
                "\nH: 0x" + ((uint)m01address01).ToString("X") +
                "\nD: 0x" + ((uint)m01address02).ToString("X")

            ).SafeShow("tmsfunc2 command");

            niec_std.mono_runtime_install_handlers();

            if (NFinalizeDeath.CheckAccept("Call TestRunSEDInitProductFlags??"))
            {
                NFinalizeDeath.TestRunSEDInitProductFlags();
                NFinalizeDeath.asoeoertery = false;

                if (NFinalizeDeath.CheckAccept("Call niecmod_script_copy_ptr_func_to_func??"))
                    niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m02, false, false, true, false);
            }
            else if (NFinalizeDeath.CheckAccept("Call niecmod_script_copy_ptr_func_to_func??"))
            {
                niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m02, true, false, true, false);
            }

            if (NFinalizeDeath.CheckAccept("Call GameUtils.InitProductFlags() Debugger??"))
                NFinalizeDeath.Debugger_Break();

            NFinalizeDeath.asoeoertery = false;

            GameUtils.InitProductFlags();

            if (NFinalizeDeath.asoeoertery)
            {
                NFinalizeDeath.Show_MessageDialog("Done you can set IL custom your script function :)");
            }
            else
            {
                NFinalizeDeath.Show_MessageDialog("Failed. Try Again?");
            }
        }

        public static void fixuphinlothome_command()
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
            {
                if (item == null) 
                    continue;

                var h = item.LotHome;
                if (h == null)
                    continue;

                h.mHousehold = item;
            }
            testhinlothome_command();
        }

        public static void tmnfunc3_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            var type = typeof(niec_native_func);
            var m01 = (MonoMethod)type.GetMethod("niecmod_native_custom_test_C");

            if (m01 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_custom_test_C\") failed");
                return;
            }

            var m00address01 = m01.mhandle;
            uint funcPtr = ((uint)m00address01) + 0x20u;

            if ((uint)global::System.Runtime.InteropServices.Marshal.ReadInt32(new IntPtr((int)funcPtr)) == 0x00000000)
            {
                var objAddress = new IntPtr(0);
                if (testgcnavtive3 == null)
                {
                    testgcnavtive3 = string.InternalAllocateStr(1000);

                    objAddress = testgcnavtive3.obj_address();

                    /*
                        Code for x86:
                        B0 01: mov al,1 
                        C3:    ret 
                        90:    nop 
                     
                        C code:
                        return 1;
                     */

                    // Little endian to Big endian


                    global::System.Runtime.InteropServices.Marshal.WriteInt32(new IntPtr((int)objAddress + 0x12), (int)NFinalizeDeath.SwapOrgerBit32(0xB001C390u));
                    global::System.Runtime.InteropServices.Marshal.WriteInt32(new IntPtr((int)funcPtr), (int)objAddress + 0x12);
                }
                else
                {
                    /*
                        Code for x86:
                        B0 01: mov al,1 
                        C3:    ret 
                        90:    nop
                     
                        C code:
                        return 1;
                     */

                    // Little endian to Big endian

                    global::System.Runtime.InteropServices.Marshal.WriteInt32(new IntPtr((int)testgcnavtive3.obj_address() + 0x12), (int)NFinalizeDeath.SwapOrgerBit32(0xB001C390u));
                    global::System.Runtime.InteropServices.Marshal.WriteInt32(new IntPtr((int)funcPtr), (int)objAddress + 0x12);
                }
            }

            testgcnavtive3.obj_address(); // check SIGSEGV 
            GC.KeepAlive(testgcnavtive3);

            try
            {
                niec_std.mono_runtime_install_handlers();

                if (NFinalizeDeath.CheckAccept("Call niecmod_native_custom_test_C Debugger??"))
                {
                    NFinalizeDeath.Debugger_Break();
                }

                if (niec_native_func.niecmod_native_custom_test_C())
                {
                    NFinalizeDeath.Show_MessageDialog("Done Valid");
                }
                else
                {
                    NFinalizeDeath.Assert("Invalid. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Assert("(SIGSEGV) Exception. niecmod_native_custom_test_C()"); }
        }




        public static void tmynfunc_command() //test_my_native_func()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            niec_std.mono_runtime_install_handlers();

            var type = typeof(niec_native_func);
            var m01 = (MonoMethod)type.GetMethod("niecmod_native_custom_test");
            if (m01 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_custom_test\") failed");
                return;
            }

            var m00address00 = m01.obj_address();
            var m00address01 = m01.mhandle;
            //IntPtr m00adderss02 = new IntPtr((int)0);
            uint m00adderss03 = 0;

            //try
            //{
            //    if (NFinalizeDeath.CheckAccept("RuntimeMethodHandle.GetFunctionPointer(m00address01) Debugger??"))
            //    {
            //        NFinalizeDeath.Debugger_Break();
            //    }
            //    m00adderss02 = RuntimeMethodHandle.GetFunctionPointer(m00address01);
            //}
            //catch (Exception)
            //{ }

            try
            {
                if (NFinalizeDeath.CheckAccept("(uint)(Assembly.MonoDebugger_GetMethodToken(m01)) Debugger??"))
                {
                    NFinalizeDeath.Debugger_Break();
                }
                m00adderss03 = (uint)(Assembly.MonoDebugger_GetMethodToken(m01));
            }
            catch (Exception)
            { }

            var debug00 = "\nm00address00: " + ((uint)(m00address00.ToInt32())).ToString("X");
            var debug01 = "\nm00address01: " + ((uint)(m00address01.ToInt32())).ToString("X");
            //var debug02 = "\nm00address02: " + ((uint)(m00adderss02.ToInt32())).ToString("X");
            var debug03 = "\nm00address03: " + m00adderss03.ToString("X");

            var infodebug = "\n\nB0 01 C3 90\nmov al,1\nret\nnop\n\n" + debug00 
                                                                     + debug01 
                                                                     //+ debug02 
                                                                     + debug03;


            string infodebug2 =
            ((uint)(m00address01.ToInt32())).ToString("X") + ":\n" +
            "1:  [eax+4]   ????????\n" +
            "2:  [eax+8]   ????????\n" +
            "3:  [eax+C]   ????????\n" +
            "4:  [eax+10]  00000000\n" +
            "5:  [eax+14]  ????????\n" +
            "6:  [eax+18]  ???????? \"niecmod_native_custom_test\"\n" +
            "7:  [eax+1C]  FFFFF000\n" +
            "8:  [eax+20]  00000000 // <--- you can custom func :)\n" +
            "9:  [eax+24]  00000000\n" +
            "10: [eax+28]  10000096";


            IntPtr newNativeFuncAdderss = new IntPtr((int)0);

            if (testgcnavtive == null)
            {
                var objectgcAllocateStr = string.InternalAllocateStr(1000);
                if (objectgcAllocateStr == null)
                {
                    NFinalizeDeath.Assert("InternalAllocateStr() failed");
                }
                newNativeFuncAdderss = objectgcAllocateStr.obj_address();
                testgcnavtive = objectgcAllocateStr;
            }
            else
            {
                newNativeFuncAdderss = testgcnavtive.obj_address();
            }

            string newNativeFuncAdderssDEBUG = ((uint)newNativeFuncAdderss + 0x12).ToString("X");

            infodebug += "\n\nNewNativeFuncAdderss: " + newNativeFuncAdderssDEBUG;

            new NCopyableTextDialog("you can patch.\nnot: 20u\ngood: 0x20u\n" + infodebug + "\n\n\n" + infodebug2).SafeShow("tmynfunc command");

            if (NFinalizeDeath.CheckAccept("Call niecmod_native_custom_test() Debugger??"))
            {
                NFinalizeDeath.Debugger_Break();
            }

            try
            {
                if (niec_native_func.niecmod_native_custom_test())
                {
                    NFinalizeDeath.Show_MessageDialog("Done you can add custom your native function :)");
                }
                else
                {
                    NFinalizeDeath.Show_MessageDialog("Failed. Try Again?");
                }
            }
            catch (Exception)
            { NFinalizeDeath.Show_MessageDialog("Exception. Try Again"); }
          
        }

        public static void backuptevc_command()
        {
            if (BackupTEV == null)
                return;
            BackupTEV.Clear();
        }

        public static void tevs_command() {
            if (BackupTEV == null || BackupTEV._items.Length == 0)
                return;

            for (int iX = 0; iX < 5000; iX++)
            {
                if (!BackupTEV.Remove(null))
                    break;
            }

            if (BackupTEV.Count == 0)
                return;

            t:int i = NFinalizeDeath.GetIntDialog("tevs: BackupsTEV Count: " + BackupTEV.Count + "\nCountItems: "  + BackupTEV._items.Length + "\nWhat do you want?");
            if (i == -101)
                return;

            if (i == -102)
            {
                NFinalizeDeath.Show_MessageDialog("Invaild text.");
                goto t;
            }

            if (!(i < BackupTEV._items.Length))
            {
                NFinalizeDeath.Show_MessageDialog("Out of range.");
                goto t;
            }

            var eventev = ReEventTracker(BackupTEV._items[i] as List<object>); //BackupTEV._items[i] as Sims3.Gameplay.EventSystem.EventTracker;
            if (eventev == null)
            {
                NFinalizeDeath.Show_MessageDialog("BackupTEVs[i] as List<object> is null");//as EventTracker is null");
                goto t;
            }

            var count = eventev.mListeners != null ? eventev.mListeners.Count : 0;
            if (NFinalizeDeath.CheckAccept("Are you sure\nCount: " + count))
            {
                if (Sims3.Gameplay.EventSystem.EventTracker.sInstance != null)
                    BackupTEV.Add(NewEventTracker(Sims3.Gameplay.EventSystem.EventTracker.sInstance));

                niec_std.list_remove(BackupTEV, eventev);
                Sims3.Gameplay.EventSystem.EventTracker.sInstance = eventev;
            }
        }



        public static List<object> NewEventTracker(Sims3.Gameplay.EventSystem.EventTracker e) {
            if (e == null)
                return new List<object>();

            var l = new List<object>();

            l.Add(e.mActiveList);
            l.Add(e.mAddList);
            l.Add(e.mRemoveList);
            l.Add(e.mListeners);

            return l;
        }

        public static Sims3.Gameplay.EventSystem.EventTracker ReEventTracker(List<object> e)
        {
            if (e == null) 
                return null;

            var etar = new Sims3.Gameplay.EventSystem.EventTracker();

            etar.mActiveList      = (Stack<List<Sims3.Gameplay.EventSystem.EventListener>>)e._items[0] ?? new Stack<List<Sims3.Gameplay.EventSystem.EventListener>>();
            etar.mAddList         = (List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>)e._items[1] ?? new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();
            etar.mRemoveList      = (List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>)e._items[2] ?? new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();
            etar.mListeners       = (Dictionary<ulong, Dictionary<ulong, List<Sims3.Gameplay.EventSystem.EventListener>>>)e._items[3] ?? new Dictionary<ulong, Dictionary<ulong, List<Sims3.Gameplay.EventSystem.EventListener>>>();

            return etar;
        }

        public static
            void tevcopy_command()
        {
            if (tevdata == null)
            {
                if (BackupTEV == null)
                    BackupTEV = new List<object>(100);
                BackupTEV.Add(NewEventTracker(Sims3.Gameplay.EventSystem.EventTracker.sInstance));
                if (tusev != null)
                    BackupTEV.Add(NewEventTracker(tusev));
                return;
            }
            if (BackupTEV == null)
                BackupTEV = new List<object>(100);

            var p = tevdata;
            var pcopy = new Sims3.Gameplay.EventSystem.EventTracker(); //(Sims3.Gameplay.EventSystem.EventTracker) tevdata.MemberwiseClone();
            if (p.mActiveList != null)
            {
                try
                {
                    pcopy.mActiveList = new Stack<List<Sims3.Gameplay.EventSystem.EventListener>>();

                    pcopy.mActiveList.size = p.mActiveList.size;
                    pcopy.mActiveList.ver = p.mActiveList.ver;
                    pcopy.mActiveList.defaultCapacity = p.mActiveList.defaultCapacity;

                    if (p.mActiveList.data != null)
                    {
                        var ic = p.mActiveList.data.Length;
                        pcopy.mActiveList.data = new List<Sims3.Gameplay.EventSystem.EventListener>[ic];

                        var temp = pcopy.mActiveList.data;
                        var temp1 = p.mActiveList.data;

                        for (int i = 0; i < ic; i++)
                        {
                            if (temp1[i] == null)
                            {
                                temp[i] = null;
                                continue;
                            }

                            try
                            {
                                var copuList = new List<Sims3.Gameplay.EventSystem.EventListener>();
                                copuList._items = temp1[i].ToArray();
                                copuList._version = 0;
                                copuList._size = copuList._items.Length;

                                temp[i] = copuList;
                            }
                            catch (Exception)
                            { temp[i] = temp1[i]; }
                        }
                    }
                    else
                    {
                        pcopy.mActiveList.data = null;
                    }
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
            }
            if (p.mAddList != null)
            {
                try
                {
                    pcopy.mAddList = new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();
                    pcopy.mAddList._items = p.mAddList.ToArray();
                    pcopy.mAddList._version = 0;
                    pcopy.mAddList._size = pcopy.mAddList._items.Length;
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
            }
            if (p.mRemoveList != null)
            {
                try
                {
                    pcopy.mRemoveList = new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();
                    pcopy.mRemoveList._items = p.mRemoveList.ToArray();
                    pcopy.mRemoveList._version = 0;
                    pcopy.mRemoveList._size = pcopy.mRemoveList._items.Length;
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
            }
            if (p.mListeners != null)
            {
                try
                {
                    pcopy.mListeners = new Dictionary<ulong, Dictionary<ulong, List<Sims3.Gameplay.EventSystem.EventListener>>>();
                    var temp = pcopy.mListeners;

                    foreach (var item in p.mListeners)
                    {
                        if (item.value != null)
                        {
                            var temp1 = new Dictionary<ulong, List<Sims3.Gameplay.EventSystem.EventListener>>();
                            foreach (var itemChild in item.value)
                            {
                                if (itemChild.value != null)
                                {
                                    var itemChild0 = new List<Sims3.Gameplay.EventSystem.EventListener>();

                                    itemChild0._items = itemChild.value.ToArray();
                                    itemChild0._version = 0;
                                    itemChild0._size = itemChild0._items.Length;

                                    try
                                    {
                                        temp1.Add(itemChild.key, itemChild0);
                                    }
                                    catch (Exception e)
                                    { NFinalizeDeath.M(e); }

                                }
                                else
                                {
                                    try
                                    {
                                        temp1.Add(itemChild.key, itemChild.value);
                                    }
                                    catch (Exception e)
                                    { NFinalizeDeath.M(e); }
                                }
                            }

                            try
                            {
                                temp.Add(item.key, temp1);
                            }
                            catch (Exception e)
                            { NFinalizeDeath.M(e); }
                        }
                        else
                        {
                            try
                            {
                                temp.Add(item.key, item.value);
                            }
                            catch (Exception e)
                            { NFinalizeDeath.M(e); }
                        }
                    }
                }
                catch (Exception e)
                { NFinalizeDeath.M(e); }
            }

            if (Sims3.Gameplay.EventSystem.EventTracker.sInstance == null)
                Sims3.Gameplay.EventSystem.EventTracker.sInstance = new Sims3.Gameplay.EventSystem.EventTracker();

            BackupTEV.Add(NewEventTracker(Sims3.Gameplay.EventSystem.EventTracker.sInstance));
            BackupTEV.Add(NewEventTracker(pcopy));
            BackupTEV.Add(NewEventTracker(p));

            if (tusev != null)
                BackupTEV.Add(NewEventTracker(tusev));

            Sims3.Gameplay.EventSystem.EventTracker.sInstance = pcopy;
        }

        public static
            void testassert_command()
        {
            NFinalizeDeath.Assert(true, "Test True");
            NFinalizeDeath.Assert(false,"Test False");

            nonYieldRunFunc.RunFunc(() =>
            {
                NFinalizeDeath.Assert(true, "Test True Without Yield");
                NFinalizeDeath.Assert(false, "Test False Without Yield");
            });
        }

        public static
            void alldinvloop_command()
        {
            if (alldinvloop_ObjectID.mValue == 0)
            {
                alldinvloop_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    bool acore = NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.___bOpenDGSIsInstalled_;
                    bool p = false;

                    while (true)
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        for (int i = 0; i < 75; i++)
                        {
                            Simulator.Sleep(0);
                        }

                        int sleep = 0;

                        foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            sleep++;
                            if (sleep > 50)
                            {
                                sleep = 0;
                                Simulator.Sleep(0);
                            }

                            if (item == null)
                                continue;

                            if (item.mObjComponents == null)
                                continue;

                            if (acore)
                            {
                                const string msg = "Attempt to call SafeCall() in a if (alldinv_command_bool). Game Crash caused by StackOverflow";

                                if (alldinv_command_bool)
                                    throw new StackOverflowException(msg);

                                NFinalizeDeath.SafeCall(() =>
                                {
                                    if (alldinv_command_bool)
                                        throw new StackOverflowException(msg);
                                    try
                                    {
                                        alldinv_command_bool = true;
                                        AddInventoryAndStoreInListToData(item); // awecode unsafe: GC Evil
                                    }
                                    catch (ResetException)
                                    { throw; }
                                    catch (Exception)
                                    { }
                                    finally { alldinv_command_bool = false; }
                                });

                            }

                            var i = item.Inventory;
                            if (i == null)
                                continue;

                            NFinalizeDeath.DeleteInvSim(item);


                            //////////////////////////////////////////////////////////////////


                            if (!NFinalizeDeath.GameObjectIsValid(item.ObjectId.mValue))
                                continue;

                            if (item.mObjComponents == null || item.SimDescription == null)
                                continue;

                            try
                            {
                                if (item.InventoryComp == null)
                                {
                                    item.mObjComponents.Add(new Sims3.Gameplay.ObjectComponents.InventoryComponent(item));
                                    //   item.AddComponent<Sims3.Gameplay.ObjectComponents.InventoryComponent>(item);
                                }
                            }
                            catch (ResetException)
                            { throw; }
                            catch (Exception)
                            { }

                            if (!p && item.InventoryComp == null)
                            {
                                NFinalizeDeath.Assert("item.InventoryComp == null failed!");
                                p = true;
                            }

                            var ic = item.InventoryComp;
                            if (ic != null && ic.Inventory == null)
                            {
                                ic.mScriptObject = item;
                                try
                                {
                                    ic.Inventory = new Inventory(item);
                                }
                                catch (ResetException)
                                { throw; }
                                catch (Exception)
                                {
                                    if (!p)
                                    {
                                        NFinalizeDeath.Assert("Inventory create failed!");
                                        p = true;
                                    }
                                }
                            }
                            //try
                            //{
                            //    item.FixUpCellPhone();
                            //}
                            //catch (ResetException)
                            //{ throw; }
                            //catch (Exception)
                            //{ }
                          
                        }

                        sleep = 0;

                        //foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                        //{
                        //    sleep++;
                        //    if (sleep > 100)
                        //    {
                        //        sleep = 0;
                        //        Simulator.Sleep(0);
                        //    }
                        //
                        //    if (item == null)
                        //        continue;
                        //
                        //    if (item.mObjComponents == null || item.SimDescription == null || item.SimDescription.mSim != item)
                        //        continue;
                        //
                        //    try
                        //    {
                        //        if (item.InventoryComp == null)
                        //        {
                        //            item.mObjComponents.Add(new Sims3.Gameplay.ObjectComponents.InventoryComponent(item));
                        //            //   item.AddComponent<Sims3.Gameplay.ObjectComponents.InventoryComponent>(item);
                        //        }
                        //    }
                        //    catch (ResetException)
                        //    { throw; }
                        //    catch (Exception)
                        //    { }
                        //
                        //    if (!p && item.InventoryComp == null)
                        //    {
                        //        NFinalizeDeath.Assert("item.InventoryComp == null failed");
                        //        p = true;
                        //    }
                        //    var ic = item.InventoryComp;
                        //    if (ic != null && ic.Inventory == null)
                        //    {
                        //        ic.mScriptObject = item;
                        //        try
                        //        {
                        //            ic.Inventory = new Inventory(item);
                        //        }
                        //        catch (ResetException)
                        //        { throw; }
                        //        catch (Exception)
                        //        {
                        //            if (!p)
                        //            {
                        //                NFinalizeDeath.Assert("Inventory create failed");
                        //                p = true;
                        //            }
                        //        }
                        //
                        //    }
                        //}

                        if (slist_data_alldinv_command != null && slist_data_alldinv_command.Count > 0)
                        {
                            sleep = 0;
                            try
                            {
                                foreach (var item in slist_data_alldinv_command.ToArray())
                                {
                                    if (item == null)
                                        continue;

                                    sleep++;
                                    if (sleep > 50)
                                    {
                                        sleep = 0;
                                        Simulator.Sleep(0);
                                    }


                                    niec_std.list_remove(slist_data_alldinv_command, item);

                                    foreach (var itemChild in item.ToArray())
                                    {
                                        if (itemChild == null)
                                            continue;

                                        var itemObject = itemChild.Object;
                                        if (itemObject == null)
                                            continue;

                                        if (!IsOpenDGSInstalled)
                                        {

                                            var iGameObject = itemObject as GameObject;
                                            if (iGameObject != null)
                                            {
                                                NFinalizeDeath.ForceDestroyObject(iGameObject, false);
                                            }
                                            else
                                            {
                                                var proxyobject = itemObject.Proxy as ScriptCore.ScriptProxy;
                                                ScriptCore.Simulator.Simulator_DestroyObjectImpl(itemObject.ObjectId.mValue);
                                                if (proxyobject != null)
                                                {
                                                    proxyobject.mObjectId = new ObjectGuid(0);
                                                    proxyobject.mTarget = null;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            itemObject.Destroy();
                                        }
                                    }
                                }
                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch { }

                            slist_data_alldinv_command.Clear();
                        }
                        sleep = 0;
                    }
                });
            }
            else
            {
                var o = new ObjectGuid(alldinvloop_ObjectID.mValue);
                alldinvloop_ObjectID.mValue = 0;
                Simulator.DestroyObject(o);
                o.mValue = 0;
            }
        }

        public static
            void nhsfsactor_command()
        {
             Simulator.CheckYieldingContext(true);
             if (NFinalizeDeath.CheckAccept("Active?\nValue: " + NiecHelperSituation.sFakeSetActor))
             {
                 NiecHelperSituation.sFakeSetActor = true;
                 if (NFinalizeDeath.CheckAccept("Active Household ?\nValue: " + NiecHelperSituation.sFakeSetActorA))
                 {
                     NiecHelperSituation.sFakeSetActorA = !NiecHelperSituation.sFakeSetActorA;
                 }
                 if (NFinalizeDeath.CheckAccept("Random Sim ?\nValue: " + NiecHelperSituation.sFakeSetActorR))
                 {
                     NiecHelperSituation.sFakeSetActorR = !NiecHelperSituation.sFakeSetActorR;
                 }
                 if (NFinalizeDeath.CheckAccept("FadnIn Sim ?\nValue: " + NiecHelperSituation.sFakeSetActorFoFadeIn))
                 {
                     NiecHelperSituation.sFakeSetActorFoFadeIn = !NiecHelperSituation.sFakeSetActorFoFadeIn;
                 }
                 if (NFinalizeDeath.CheckAccept("Set MaxCIA ?\nValue: " + NiecHelperSituation.kFakeSetActorACacheIMax))
                 {
                     string et = (NiecHelperSituation.kFakeSetActorACacheIMax).ToString();
                     string text = StringInputDialog.Show
                         ("NiecMod: Text SetActorACacheIMax", "Current: " + et, et, 256, StringInputDialog.Validation.None);

                     if (!string.IsNullOrEmpty(text))
                     {
                         uint t;
                         if (uint.TryParse(text, out t))
                         {
                             NiecHelperSituation.kFakeSetActorACacheIMax = t;
                         }
                     }
                 }
                 if (NFinalizeDeath.CheckAccept("Set MaxCIR ?\nValue: " + NiecHelperSituation.kFakeSetActorRCacheIMax))
                 {
                     string et = (NiecHelperSituation.kFakeSetActorRCacheIMax).ToString();
                     string text = StringInputDialog.Show
                         ("NiecMod: Text SetActorRCacheIMax", "Current: " + et, et, 256, StringInputDialog.Validation.None);

                     if (!string.IsNullOrEmpty(text))
                     {
                         uint t;
                         if (uint.TryParse(text, out t))
                         {
                             NiecHelperSituation.kFakeSetActorRCacheIMax = t;
                         }
                     }
                 }
             }
             else
             {
                 NiecHelperSituation.sFakeSetActor = false;
             }
        }
        public static
            void tnhsfsactor_command()
        {
            NiecHelperSituation.sFakeSetActorC = HitTargetSim();
        }

        public static
            void sworldflags_command()
        {
             Simulator.CheckYieldingContext(true);
             if (!GameStates.IsInMainMenuState && NFinalizeDeath.CheckAccept("Set?"))
             {
                 string et = (NFinalizeDeath.World_NativeFlags).ToString();

                 string text = StringInputDialog.Show("NiecMod: Text World_NativeFlags", "Current: " + et, et, 256, StringInputDialog.Validation.None);
                 if (string.IsNullOrEmpty(text))
                     return;

                 uint t;

                 if (!uint.TryParse(text, out t))
                     return;

                 NFinalizeDeath.World_NativeFlags = t;
                 if (t == 2 && !ScriptCore.World.World_IsEditInGameFromWBModeImpl())
                 {
                     NFinalizeDeath.Assert(
                        false,
                        "NF.World_IsEditInGameFromWBModeImpl(): " + NFinalizeDeath.World_IsEditInGameFromWBModeImpl().ToString() +
                        "\n" +
                        "SC.World_IsEditInGameFromWBModeImpl(): " + ScriptCore.World.World_IsEditInGameFromWBModeImpl().ToString() +
                        "\n" +
                        "NF.World_NativeFlags: " + NFinalizeDeath.World_NativeFlags.ToString()
                    );
                 }
             }
             else if (NFinalizeDeath.CheckAccept("Info?"))
             {
                 new NCopyableTextDialog
                     ("NF.World_IsEditInGameFromWBModeImpl(): " + NFinalizeDeath.World_IsEditInGameFromWBModeImpl().ToString() +
                     "\n" +
                     "SC.World_IsEditInGameFromWBModeImpl(): " + ScriptCore.World.World_IsEditInGameFromWBModeImpl().ToString() +
                     "\n" +
                     "NF.World_NativeFlags: " + NFinalizeDeath.World_NativeFlags.ToString() +
                     "\n" +
                     "NF.World_NativeInstance: " + NFinalizeDeath.World_NativeInstance.ToString("X")).

                     SafeShow("sworldflags_command");
             }
             else if (NFinalizeDeath.CheckAccept("Test?"))
             {
                 NFinalizeDeath.Assert(
                     NFinalizeDeath.World_IsEditInGameFromWBModeImpl() == ScriptCore.World.World_IsEditInGameFromWBModeImpl(),
                     "NFinalizeDeath.World_IsEditInGameFromWBModeImpl() failed"
                 );

                 if (!GameStates.IsInMainMenuState)
                 {
                     NFinalizeDeath.Assert(
                        NFinalizeDeath.World_NativeInstance != 0,
                        "World_NativeInstance invalid"
                     );
                 }
             }
        }

        public static
            void debugdebuginfo_command()
        {
            Simulator.CheckYieldingContext(true);
            if (NFinalizeDeath.CheckAccept("Set?"))
            {
                const string info = 
                    "\n0: Off\n" +
                    "1: FPS info\n" +
                    "2: Debug info";

                if (NFinalizeDeath.CheckAccept("Unsafe"))
                {
                    string et = (NFinalizeDeath.UnSafeTestGetDEBUGEAINFO()).ToString();

                    string text = StringInputDialog.Show("NiecMod: Text ToggleDebugInfo", "Current: " + et + info, et, 256, StringInputDialog.Validation.None);
                    if (string.IsNullOrEmpty(text))
                        return;

                    short t;

                    if (!short.TryParse(text, out t)) 
                        return;

                    if (t < 0 || t > 2) 
                        return; // not >= 2 no work

                    NFinalizeDeath.Assert
                        (NFinalizeDeath.UnSafeTestSetDEBUGEAINFO(t), "UnSafeTestSetDEBUGEAINFO() failed");
                   
                    NFinalizeDeath.Assert
                        (NFinalizeDeath.UnSafeTestGetDEBUGEAINFO() == t, "UnSafeTestGetDEBUGEAINFO() failed");
                }
                else
                {
                    string et = (NFinalizeDeath.TestGetDEBUGEAINFO()).ToString();
                    string text = StringInputDialog.Show("NiecMod: Text ToggleDebugInfo", "Current: " + et + info, et, 256, StringInputDialog.Validation.None);
                    if (string.IsNullOrEmpty(text))
                        return;

                    short t;

                    if (!short.TryParse(text, out t)) 
                        return;

                    if (t < 0 || t > 2) // not >= 2 no work
                        return;

                    NFinalizeDeath.Assert
                        (NFinalizeDeath.TestSetDEBUGEAINFO(t), "TestSetDEBUGEAINFO() failed");

                    NFinalizeDeath.Assert
                        (NFinalizeDeath.TestGetDEBUGEAINFO() == t, "TestGetDEBUGEAINFO() failed");
                }
            }
            else if (NFinalizeDeath.CheckAccept("Info?"))
            {
                new NCopyableTextDialog
                    ("NFinalizeDeath.UnSafeTestGetDEBUGEAINFO(): " + NFinalizeDeath.UnSafeTestGetDEBUGEAINFO().ToString() +
                    "\n" + "NFinalizeDeath.TestGetDEBUGEAINFO(): " + NFinalizeDeath.TestGetDEBUGEAINFO().ToString()).

                    SafeShow("debugdebuginfo_command");
            }
            else if (NFinalizeDeath.CheckAccept("Test?"))
            {
                NFinalizeDeath.Assert(NFinalizeDeath.UnSafeTestGetDEBUGEAINFO() != -2, "UnSafeTestGetDEBUGEAINFO() failed");
                NFinalizeDeath.Assert(NFinalizeDeath.TestGetDEBUGEAINFO() != -2, "TestGetDEBUGEAINFO() failed");

                NFinalizeDeath.Assert
                    (NFinalizeDeath.UnSafeTestGetDEBUGEAINFO() == NFinalizeDeath.TestGetDEBUGEAINFO(),
                    "NFinalizeDeath.UnSafeTestGetDEBUGEAINFO(): " + NFinalizeDeath.UnSafeTestGetDEBUGEAINFO().ToString() +
                    "\n" + "NFinalizeDeath.TestGetDEBUGEAINFO(): " + NFinalizeDeath.TestGetDEBUGEAINFO().ToString());

                NFinalizeDeath.Assert
                    (NFinalizeDeath.TestSetDEBUGEAINFO(NFinalizeDeath.TestGetDEBUGEAINFO()), "TestSetDEBUGEAINFO() failed");

                NFinalizeDeath.Assert
                    (NFinalizeDeath.UnSafeTestSetDEBUGEAINFO(NFinalizeDeath.UnSafeTestGetDEBUGEAINFO()), "UnSafeTestSetDEBUGEAINFO() failed");

            }
        }
        public static
            bool testdmymod_command()
        {
            NiecHelperSituationPosture.TestDEBUGMyMod = !NiecHelperSituationPosture.TestDEBUGMyMod;
            NiecException.PrintMessagePro("TestDEBUGMyMod All: " + NiecHelperSituationPosture.TestDEBUGMyMod, false, 50f);
            return NiecHelperSituationPosture.TestDEBUGMyMod;
        }

        public static
            bool ffindgood_command()
        {
            NiecHelperSituation.Spawn.FastGoodFindPOS = !NiecHelperSituation.Spawn.FastGoodFindPOS;
            NiecException.PrintMessagePro("FastGoodFindPOS: " + NiecHelperSituation.Spawn.FastGoodFindPOS, false, 50f);
            return NiecHelperSituation.Spawn.FastGoodFindPOS;
        }

        public static
            void sdjig_command()
        {
            Sims3.NiecHelp.Tasks.NiecTask.Perform(() =>
            {
                foreach (var itemJig in NFinalizeDeath.SC_GetObjects<Jig>())
                {
                    if (itemJig == null)
                        continue;

                    ulong objID = itemJig.ObjectId.mValue;
                    ScriptCore.ScriptProxy proxy = objID != 0 ? itemJig.Proxy as ScriptCore.ScriptProxy : null;

                    ScriptCore.Simulator.Simulator_DestroyObjectImpl(objID);
                    if (proxy != null) // Stop Auto ScriptProxy::Dispose()
                    {
                        proxy.mTarget = null;
                        proxy.mObjectId.mValue = 0;
                    }

                }
                for (int i = 0; i < 10600; i++) // GC Temp Safe
                {
                    Simulator.Sleep(0);
                }
            });
        }
        public static
            void ussdjig_command()
        {
            foreach (var itemJig in NFinalizeDeath.SC_GetObjects<Jig>())
            {
                if (itemJig == null)
                    continue;

                ulong objID = itemJig.ObjectId.mValue;

                ScriptCore.Simulator.Simulator_DestroyObjectImpl(objID);

            }
        }

        public static
            bool uacsmcreapsoul_command()
        {
            NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask = !NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask;
            NiecException.PrintMessagePro("UnSafeAwCoreSMCRS: " + NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask, false, 50f);
            return NFinalizeDeath.vbb_UnSafeAwCoreSMCHEATask;
        }

        public static
            void testmbox_command()
        {
            if (!NFinalizeDeath.NiecModIs64Bit() && NFinalizeDeath.GameIs64Bit(true))
                return;

            if (!niec_native_func.cache_done_niecmod_native_message_box)
                return;

            NFinalizeDeath.testnomessbox_b = !NFinalizeDeath.testnomessbox_b;
            Simulator.Sleep(0);

            string text = StringInputDialog.Show("testmbox command", "text", "Hello :)", 256, StringInputDialog.Validation.None);
            if (string.IsNullOrEmpty(text))
                return;

            Simulator.Sleep(0);

            string textcaption = StringInputDialog.Show("testmbox command", "caption", "NiecMod", 256, StringInputDialog.Validation.None);
            if (string.IsNullOrEmpty(textcaption))
                return;

            var t = niec_native_func.MessageBox(0, text, textcaption, (niec_native_func.MB_Type)0x31);
            NFinalizeDeath.Show_MessageDialog("DEBUG Result: " + t);
        }

        public static
            void testpyd_command()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            bool p = false;
            if (NFinalizeDeath.CheckAccept("Call Simulator_SetYieldingDisabledImpl(true)??"))
            {
                p = true;
                ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(true);
            }

            Instantiator.TestPreventSetYieldingDisabled2();

            if (p)
            {
                ScriptCore.Simulator.Simulator_SetYieldingDisabledImpl(false);
            }
        }

        public static
            bool nhsexaa_command()
        {
            NiecHelperSituation.ExAA = !NiecHelperSituation.ExAA;
            NiecException.PrintMessagePro("NHS ExAA: " + NiecHelperSituation.ExAA, false, 50f);
            return NiecHelperSituation.ExAA;
        }

        public static
            bool loopreappet_command()
        {
            NiecHelperSituation.klooppet = !NiecHelperSituation.klooppet;
            NiecException.PrintMessagePro("NHS kLoopSMCReapPet: " + NiecHelperSituation.klooppet, false, 50f);
            return NiecHelperSituation.klooppet;
        }
        public static
            bool ussmcreapsoulpet_command()
        {
            if (IsOpenDGSInstalled)
                NiecHelperSituation.kUnsafeOpenDGSReapSoulPetHoruse = !NiecHelperSituation.kUnsafeOpenDGSReapSoulPetHoruse;
            NiecException.PrintMessagePro("NHS kUnsafeOpenDGSReapSoulPetHoruse: " + NiecHelperSituation.kUnsafeOpenDGSReapSoulPetHoruse, false, 50f);
            return NiecHelperSituation.kUnsafeOpenDGSReapSoulPetHoruse;
        }

        [PersistableStatic]
        public static bool kForcebooltrimhouse_NRaasStoryProgression = true;

        public static
            bool fnsptrimhouse_command()
        {
            kForcebooltrimhouse_NRaasStoryProgression = !kForcebooltrimhouse_NRaasStoryProgression;
            NiecException.PrintMessagePro("kForcebooltrimhouse: " + kForcebooltrimhouse_NRaasStoryProgression, false, 50f);
            return kForcebooltrimhouse_NRaasStoryProgression;
        }

        public static
            bool nhslsfi_command()
        {
            if (!IsOpenDGSInstalled)
            {
                NiecHelperSituation.kLoopAllSimFadnIn = !NiecHelperSituation.kLoopAllSimFadnIn;
                NiecException.PrintMessagePro("NHS LoopAllSimFadnIn: " + NiecHelperSituation.kLoopAllSimFadnIn, false, 50f);
            }
            return NiecHelperSituation.kLoopAllSimFadnIn;
        }

        public static bool dnoneedall_commandb = false;
        public static
            bool dnoneedall_command()
        {
            dnoneedall_commandb = !dnoneedall_commandb;

            neednodisposesmc = dnoneedall_commandb;
            neednoupdategameobjlot = dnoneedall_commandb;

            NiecException.PrintMessagePro("neednodisposesmc: " + neednodisposesmc + "\nneednoupdategameobjlot: " + neednoupdategameobjlot, false, 50f);
            return dnoneedall_commandb;
        }

        public static
            bool ShouldCreatedBackupAlarmWorldManager()
        {
            return tausevGAlarm != null || abackup != null || tausevAlarm != null;
        }

        public static
            void usam_Command()
        {
            if (tausevAlarm == null)
            {
                tausevAlarm = new Dictionary<Lot, object>();

                tausevGAlarm = AlarmManager.sWorldAlarmManager;
                AlarmManager.sWorldAlarmManager = null;

                try
                {
                    var world_lot = LotManager.GetWorldLot();
                    var lots = LotManager.sLots;
                    if (lots != null)
                    {
                        foreach (var item in lots)
                        {
                            var valueLOT = item.Value;
                            if (valueLOT == null)
                                continue;

                            if (valueLOT == world_lot)
                                continue;

                            if (tausevAlarm.ContainsKey(valueLOT))
                                continue;

                            var savedData = valueLOT.mSavedData;
                            if (savedData != null)
                            {
                                tausevAlarm.Add(valueLOT, savedData.mAlarmManager);
                                savedData.mAlarmManager = null;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    AlarmManager.sWorldAlarmManager = tausevGAlarm as AlarmManager;
                    tausevGAlarm = null;

                    foreach (var item in tausevAlarm)
                    {
                        var valueLot = item.key;
                        if (valueLot != null && valueLot.mSavedData != null && item.value is AlarmManager)
                        {
                            valueLot.mSavedData.mAlarmManager = item.value as AlarmManager;
                        }
                    }
                    tausevAlarm = null;
                    //throw; // safe
                }
            }
            else
            {
                AlarmManager.sWorldAlarmManager = tausevGAlarm as AlarmManager;
                if (AlarmManager.sWorldAlarmManager == null) // TODO: test?
                    AlarmManager.sWorldAlarmManager = new AlarmManager();
                tausevGAlarm = null;

                foreach (var item in tausevAlarm)
                {
                    var valueLot = item.key;
                    if (valueLot != null && valueLot.mSavedData != null && item.value is AlarmManager)
                    {
                        valueLot.mSavedData.mAlarmManager = item.value as AlarmManager;
                    }
                }
                tausevAlarm.Clear();
                tausevAlarm = null;
            }
        }

        public static
            void usev_Command(bool noDis, bool isACore)
        {
            if (tusev == null)
            {
                tusev = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
                Sims3.Gameplay.EventSystem.EventTracker.sInstance = new Sims3.Gameplay.EventSystem.EventTracker();
                var sdot = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
                if (isACore || (!noDis && NFinalizeDeath.CheckAccept("AweCore?")))
                { 
                    if (sdot.mListeners == null)
                        sdot.mListeners = new Dictionary<ulong, Dictionary<ulong, List<Sims3.Gameplay.EventSystem.EventListener>>>();
                    var tt = sdot.mListeners;
                    tt.table = null;
                    if (sdot.mRemoveList == null)
                        sdot.mRemoveList = new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();
                    var rr = sdot.mRemoveList;
                    //rr._size = 5455;
                    rr._items = null;
                    if (sdot.mActiveList == null)
                        sdot.mActiveList = new Stack<List<Sims3.Gameplay.EventSystem.EventListener>>();
                    var aa = sdot.mActiveList;
                    //rr._size = 5455;
                    aa.size = 500;
                    aa.data = new List<Sims3.Gameplay.EventSystem.EventListener>[0];
                }
                else
                {
                    sdot.mActiveList = null;
                    sdot.mRemoveList = null;
                    sdot.mListeners = null;
                }
            }
            else {
                if (Sims3.Gameplay.EventSystem.EventTracker.sInstance != null) {
                    var tta = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
                    tta.mRemoveList = null;
                    tta.mListeners = null;
                    tta.mActiveList = null;
                }
                Sims3.Gameplay.EventSystem.EventTracker.sInstance = tusev;
                tusev = null;
            }
        }

        public static bool pta = false;

        public static
            void tev_command(bool noask)
        {
            
            if (tevdata == null)
            {
                if (!noask && Instantiator.ahHHHHHh)
                {
                    if (NFinalizeDeath.CheckAccept("pta: " + pta))
                    {
                        pta = !pta;
                        return;
                    }
                }

                tevdata = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
                Sims3.Gameplay.EventSystem.EventTracker.sInstance = new Sims3.Gameplay.EventSystem.EventTracker();

                var i = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
                if (i.mListeners == null)
                    i.mListeners = new Dictionary<ulong, Dictionary<ulong, List<Sims3.Gameplay.EventSystem.EventListener>>>();

                if (i.mRemoveList == null)
                    i.mRemoveList = new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();

                if (i.mActiveList == null)
                    i.mActiveList = new Stack<List<Sims3.Gameplay.EventSystem.EventListener>>();
            }
            else
            {
                if (Sims3.Gameplay.EventSystem.EventTracker.sInstance != null) {
                    var tta = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
                    tta.mRemoveList = null;
                    tta.mListeners = null;
                    tta.mActiveList = null;
                }

                Sims3.Gameplay.EventSystem.EventTracker.sInstance = tevdata;
                tevdata = null;
            }
        }




        public static bool asodase = false;

        public static
            void dallvsimdesc_command()
        {
            var asd = NFinalizeDeath.SelectedActor_SimDescription;
            var asd01 = NFinalizeDeath.ActiveActor_SimDescription;
            foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, false).ToArray())
            {
                if (item == null) continue;
                if (item == asd || item == asd01) 
                    continue;
                if (!item.mIsValidDescription || !NFinalizeDeath.SimDesc_OutfitsIsValid(item))
                {
                    NFinalizeDeath.Household_Remove(item, false);
                    NFinalizeDeath.SimDescCleanse(item, true, false);
                    NFinalizeDeath.ValidateSimCreated(item, null);
                }
            }
            NFinalizeDeath.Household_RefrashAllActors(Household.ActiveHousehold);
        }

        public static
            void unruncn_command()
        {
            if (IsOpenDGSInstalled) return;
            niec_std.mono_runtime_install_handlers();
            var g = Niec.iCommonSpace.KillPro.YGeneration;
            NFinalizeDeath.M(g);
        }

        public static
            void unruncnpro_command()
        {
            if (IsOpenDGSInstalled) 
                return;

            niec_std.mono_runtime_install_handlers();
           
            NFinalizeDeath.SafeCall(() =>
            {
                var g = Niec.iCommonSpace.KillPro.YGeneration;
                NFinalizeDeath.M(g);
            });

            //var exList = NFinalizeDeath.MsCorlibModifed_GetExLists();
            //if (exList != null)
            //{
            //    return exList._size == 0 ? -1 : exList._size;
            //}
            //else
            //{
            //    return -1;
            //}

        }

        public static
            void setsimnull_command()
        {
            Sim sim = HitTargetSim();
            if (sim != null)
            {
                bool destroySimUpdateTask = NFinalizeDeath.CheckAccept("Destroy Sim Update Task");
                SimDescription sd = null;
                sd = sim.mSimDescription;
                sim.mSimDescription = global::NiecMod.Helpers.Create.NiecNullSimDescription();
                if (sd != null)
                    sd.mSim = null;
                if (destroySimUpdateTask)
                    ScriptCore.Simulator.Simulator_DestroyObjectImpl(sim.mSimUpdateId.mValue);
            }
        }

        public static
            void exlists_command()
        {
            NFinalizeDeath.MsCorlibModifed_ExlistsX(false, true);
        }

        public static
            void allpsimtopos_command()
        {
            bool check_yield = Simulator.CheckYieldingContext(false);
            foreach (var item in NFinalizeDeath.SC_GetObjects<CASGeneticsPreviewSim>())
            {
                var rt = World.SnapToFloor(CameraController.GetTarget());
                if (!NFinalizeDeath.Vector3_IsUnsafe(rt))
                    item.SetPosition(rt);

                if (check_yield)
                    Simulator.Sleep(0);
            }
           
        }
        public static bool abackupBool = true;
        public static object abackup = null;
        public static object aLotbackup = null;
        public static
            void ustsimallpro_Command()
        {
            if (!abackupBool)
            {
                abackupBool = true;
                if (abackup is AlarmManager)
                {
                    AlarmManager.sWorldAlarmManager = abackup as AlarmManager;
                }
                if (aLotbackup is AlarmManager)
                {
                    var lotworld = LotManager.GetWorldLot();
                    if (lotworld != null && lotworld.mSavedData != null)
                    {
                        lotworld.mSavedData.mAlarmManager = aLotbackup as AlarmManager;
                    }
                }
                abackup = null;
                aLotbackup = null;
                if (GCLotA_MBRACKUP != null)
                {
                    foreach (var item in GCLotA_MBRACKUP)
                    {
                        var valueLot = item.key;
                        if (valueLot != null && valueLot.mSavedData != null && item.value is AlarmManager)
                        {
                            valueLot.mSavedData.mAlarmManager = item.value as AlarmManager;
                        }
                    }
                    GCLotA_MBRACKUP.Clear();
                }
                GCLotA_MBRACKUP = null;
                return;
            }
            abackupBool = false;
            ustsimallpro_CommandI();

            neednodisposesmc = false;
            neednoupdategameobjlot = false;

            abackupBool = true;

            if (!NiecHelperSituation.__acorewIsnstalled__ || NiecHelperSituation.___bOpenDGSIsInstalled_) // if not AweCore Installed
                simu2f_command(false);
        }

        public static void test_read_mem()
        {
            if (!NFinalizeDeath.NiecModIs64Bit() && NFinalizeDeath.GameIs64Bit(true))
                return;

            // Prevent game crash Caused by SIGSEGV.  Need call mono_runtime_install_handlers();
            try {
            NFinalizeDeath.SafeCall(() => {
            try
            {
                NFinalizeDeath.Function func = delegate{
                    niec_std.mono_runtime_install_handlers();
                    uint g = 0xFFEEAC21;
                    System.Runtime.InteropServices.Marshal.ReadInt64((IntPtr)(int)g);
                };
                func.DynamicInvoke(null);
            }
            catch (Exception ex)
            {
                //ex.stack_trace = null;
                //ex.message = "";
                //ex.inner_exception = null;
                //ex.trace_ips = null;
                //ex.source = null;
                //ex._data = null;
                var l = NFinalizeDeath.MsCorlibModifed_GetExLists();
                if (l != null)
                    l.Add(ex);
            }
#pragma warning disable 1058
            catch { }
#pragma warning restore 1058
            try
            {
                NFinalizeDeath.Function func = delegate
                {
                    niec_std.mono_runtime_install_handlers();
                    NFinalizeDeath.UnSafeReadByte64(0xFFEEAC21);
                }; func.DynamicInvoke(null);
            }
            catch (Exception ex)
            {
                var l = NFinalizeDeath.MsCorlibModifed_GetExLists();
                if (l != null)
                    l.Add(ex);
            }
#pragma warning disable 1058
            catch { }
#pragma warning restore 1058
            try
            {
                NFinalizeDeath.Function func = delegate
                {
                    niec_std.mono_runtime_install_handlers();
                    niec_std.write_byte_bit64(0xFFEEAC21, 0xDEAD0000);
                }; func.DynamicInvoke(null);
            }
            catch (Exception ex)
            {
                var l = NFinalizeDeath.MsCorlibModifed_GetExLists();
                if (l != null)
                    l.Add(ex);
            }
#pragma warning disable 1058
            catch { }
#pragma warning restore 1058
            });
            } catch{}
        }
        public static 
            //ScriptCore.TaskContext?
            object
            GetTaskContextWorldLot()
        {
            ITask outTask = null;
            var t = NFinalizeDeath.FindTaskPro(null, "Sims3.Gameplay.Core.WorldLot", out outTask);
            if (t.mValue != 0)
            {
                ScriptCore.TaskContext context;
                if (ScriptCore.TaskControl.TaskControl_GetTaskContext(t.mValue, false, out context))
                    return context;
            }
            return null;
        }

        public static
            object GetTaskContextLot()
        {
            ITask outTask = null;
            var t = NFinalizeDeath.FindTaskPro(null, "Sims3.Gameplay.Core.Lot", out outTask);
            if (t.mValue != 0)
            {
                ScriptCore.TaskContext context;
                if (ScriptCore.TaskControl.TaskControl_GetTaskContext(t.mValue, false, out context))
                    return context;
            }
            return null;
        }

        public static
            object GetTaskContextLoadSaveManager()
        {
            ITask outTask = null;
            var t = NFinalizeDeath.FindTaskPro(null, "ScriptCore.LoadSaveManagerTask", out outTask);
            if (t.mValue != 0)
            {
                ScriptCore.TaskContext context;
                if (ScriptCore.TaskControl.TaskControl_GetTaskContext(t.mValue, false, out context))
                    return context;
            }
            return null;
        }

        public static
            object GetTaskContextGameflow()
        {
            ITask outTask = null;
            var t = NFinalizeDeath.FindTaskPro(null, "Sims3.Gameplay.Gameflow", out outTask);
            if (t.mValue != 0)
            {
                ScriptCore.TaskContext context;
                if (ScriptCore.TaskControl.TaskControl_GetTaskContext(t.mValue, false, out context))
                    return context;
            }
            return null;
        }

        public static
            object GetPreCopyTaskContext(ulong objID)
        {
            //ITask outTask = null;
            //var t = NFinalizeDeath.FindTaskPro(null, "Sims3.Gameplay.Core.WorldLot", out outTask);
            if (objID != 0)
            {
                ScriptCore.TaskContext context;
                if (ScriptCore.TaskControl.TaskControl_GetTaskContext(objID, false, out context) && context.mFrames != null)
                    return CopyTaskContext(context, true);
            }
            return null;
        }
        public static List<object> GCKeepGameCrash = new List<object>(1000);
        public static Dictionary<Lot,object> GCLotA_MBRACKUP = null;
        public static 
            void dtclist_command()
        {
            int no = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in GCKeepGameCrash)
            {
                if (!(item is ScriptCore.TaskContext)) 
                    continue;

                no++;
                ScriptCore.TaskContext taskcontext = (ScriptCore.TaskContext)item;

                sb.AppendLine();
                sb.AppendLine();

                sb.Append("No: " + no);
                sb.AppendLine();

                sb.Append("------------------------------------");
                sb.AppendLine();

                sb.Append(NFinalizeDeath.TaskContext_GetToString(taskcontext));

                sb.AppendLine();
                sb.Append("------------------------------------");
            }
            if (sb.Length != 0)
                NiecException.WriteLog(sb.ToString(), true, false, false);
        }

        public static 
            void unsaferunnnull_command()
        {
            if (unsaferunnnull_ObjectID.mValue == 0)
            {
                unsaferunnnull_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                {
                    while (true)
                    {
                        Simulator.Sleep(0);

                        niec_std.mono_runtime_install_handlers();

                        try
                        {
                            ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(null);
                        }
                        catch (ResetException)
                        {
                            if (!Simulator.CheckYieldingContext(false))
                                throw;
                            continue;
                        }
                        catch (Exception ex)
                        {
                            ex.stack_trace = null;
                            ex.message = "";
                            ex.trace_ips = null;
                            ex.source = null;
                            ex._data = null;
                            ex.class_name = null;
                            ex.inner_exception = null;

                            var exList = NFinalizeDeath.MsCorlibModifed_GetExLists();
                            if (exList != null && exList._items != null)
                            {
                                var index = niec_std.array_indexof(exList._items, ex);
                                if (index != -1)
                                {
                                    exList._items[index] = null;
                                    if (exList._size != 0)
                                    {
                                        exList._size--;
                                        exList._version--;
                                    }
                                }
                            }
                            ex = null;
                            continue;
                        }

                        NFinalizeDeath.Assert(false, "EA Bug Fixed!!");
                        unsaferunnnull_ObjectID.mValue = 0;
                        return;
                    }
                });
            }
            else
            {
                var o = new ObjectGuid(unsaferunnnull_ObjectID.mValue);
                unsaferunnnull_ObjectID.mValue = 0;
                Simulator.DestroyObject(o);
                o.mValue = 0;
            }
        }

        public static
            void unsaferunnnullpro_command()
        {
            if (unsaferunnnullpro_ObjectID.mValue == 0)
            {
                unsaferunnnullpro_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                {
                    while (true)
                    {
                        Simulator.Sleep(1);

                        try
                        {
                            unruncnpro_command();
                        }
                        catch (ResetException)
                        {
                            if (!Simulator.CheckYieldingContext(false))
                                throw;
                            continue;
                        }
                        catch (Exception ex)
                        {
                            var et = ex.inner_exception;

                            ex.stack_trace = null;
                            ex.message = "";
                            ex.trace_ips = null;
                            ex.source = null;
                            ex._data = null;
                            ex.class_name = null;
                            ex.inner_exception = null;

                            if (et != null)
                            {
                                et.stack_trace = null;
                                et.message = "";
                                et.trace_ips = null;
                                et.source = null;
                                et._data = null;
                                et.class_name = null;
                                et.inner_exception = null;
                            }


                            var exList = NFinalizeDeath.MsCorlibModifed_GetExLists();
                            if (exList != null && exList._items != null)
                            {
                                var index = niec_std.array_indexof(exList._items, ex);
                                if (index != -1)
                                {
                                    exList._items[index] = null;
                                    if (exList._size != 0)
                                    {
                                        exList._size--;
                                        exList._version--;
                                    }
                                }
                                index = niec_std.array_indexof(exList._items, et);
                                if (index != -1)
                                {
                                    exList._items[index] = null;
                                    if (exList._size != 0)
                                    {
                                        exList._size--;
                                        exList._version--;
                                    }
                                }
                            }

                            et = null;
                            ex = null;

                            continue;
                        }

                        NFinalizeDeath.Assert(false, "Fixed Mono Throw?");
                        unsaferunnnullpro_ObjectID.mValue = 0;
                        return;


                        //int t;
                        //
                        //try
                        //{
                        //   t = unruncnpro_command();
                        //}
                        //catch (Exception)
                        //{
                        //    NFinalizeDeath.Assert(false, "Fixed Mono Throw?");
                        //    unsaferunnnullpro_ObjectID.mValue = 0;
                        //    return;
                        //}
                        //
                        //if (t == -1)
                        //{
                        //    continue;
                        //}
                        //else
                        //{
                        //    var exList = NFinalizeDeath.MsCorlibModifed_GetExLists();
                        //    if (exList != null && exList._items != null)
                        //    {
                        //        int index = t == 0 ? -1 : t - 1;
                        //        if (index != -1)
                        //        {
                        //            var ex = exList._items[index];
                        //            if (ex != null)
                        //            {
                        //                ex.stack_trace = null;
                        //                ex.message = "";
                        //                ex.trace_ips = null;
                        //                ex.source = null;
                        //                ex._data = null;
                        //                ex.class_name = null;
                        //                ex.inner_exception = null;
                        //            }
                        //            ex = null;
                        //            exList._items[index] = null;
                        //            if (exList._size != 0)
                        //                exList._size--;
                        //        }
                        //    }
                        //}
                    }
                });
            }
            else
            {
                var o = new ObjectGuid(unsaferunnnullpro_ObjectID.mValue);
                unsaferunnnullpro_ObjectID.mValue = 0;
                Simulator.DestroyObject(o);
                o.mValue = 0;
            }
        }

        public static
            void unsaferunfuncnull_command()
        {
            if (IsOpenDGSInstalled) 
                return;
            NFinalizeDeath.Function ft = delegate
            {
                NiecException.PrintMessagePro("test unsaferunfuncnull_command", false, 100);
            };



            ft.method_ptr = new IntPtr(0);
            ft.method_info = null;
            ft();

            NiecException.PrintMessagePro("unsaferunfuncnull_command: Test?", false, 100);
        }

        public static
            void debugvfxnhs_command()
        {
            Sim sim = HitTargetSim();
            if (sim != null && sim.InteractionQueue != null)
            {
                var nhsI = NFinalizeDeath.GetFirstObjectForTaskFrames<NiecHelperSituation.ReapSoul>(sim.ObjectId.mValue) ?? sim.InteractionQueue.GetHeadInteraction() as NiecHelperSituation.ReapSoul;
                if (nhsI != null && nhsI.mSMCDeath != null)
                {
                    var o = nhsI.mSMCDeath;
                    if (o.mVirtualAddRefs != null)
                    {
                        string ad = "";
                        foreach (var item in o.mVirtualAddRefs)
                        {
                            ad += "Name: " + item.Key;
                            if (item.Value == null)
                                goto aV;

                            VisualEffect visualEffect = item.Value as VisualEffect;
                            if (visualEffect != null)
                            {
                                ad += "\nEffect Name: " + visualEffect.EffectName;
                            }
                            else
                            {
                                ad += "\nValue Name: " + item.Value.ToString();
                            }
                            aV:ad += "\n";
                        }
                        if (NotificationManager.sNotificationManager != null && IsVisibleTreatmentsController())
                        {
                            NiecException.PrintMessagePro(ad, false, 100);
                        }
                        else new NCopyableTextDialog(ad).SafeShow("debugvfxnhs command");
                    }
                }
            }
        }

        public static
            void unsaferunfuncnullpro_command()
        {
            if (IsOpenDGSInstalled)
                return;
            if (!Simulator.CheckYieldingContext(false)) return;
            var p = new NiecPosture();
            NFinalizeDeath.Function ft = p.PopulateInteractions;
            ft.m_target = null;
            p = null;
            GC.Collect();
            for (int i = 0; i < 200; i++)
            {
                Simulator.Sleep(0);
            }
            GC.Collect();
            ft();
            NiecException.PrintMessagePro("unsaferunfuncnullpro_command: Test?", false, 100);
        }

        public static
            void drawd_command()
        {
            niec_native_func.init_class();
            if (niec_native_func.cache_done_niecmod_native_message_box)
            {
                UIManager.DarkenBackground(true);
                GameUtils.EnableSceneDraw(false);
                niec_native_func.MessageBox(0, "Ready?", "NiecMod", niec_native_func.MB_Type.MB_OK);
                GameUtils.EnableSceneDraw(true);
                UIManager.DarkenBackground(false);
            }
        }

        public static
            void fixsimlist_command()
        {
            if (LotManager.sActorList == null)
                LotManager.sActorList = new List<Sim>();

            try
            {
                LotManager.sActorList.Clear();
            }
            catch (Exception)
            { LotManager.sActorList = new List<Sim>(); }

            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null) continue;
                LotManager.sActorList.Add(item);
            }
        }

        public static
            void agrss_command()
        {
            Bim.AOrGROnlyRunningSim = !Bim.AOrGROnlyRunningSim;
            if (niec_native_func.cache_done_niecmod_native_message_box)
                niec_native_func.MessageBox(0, "AOrGROnlyRunningSim: " + Bim.AOrGROnlyRunningSim, "NiecMod", (niec_native_func.MB_Type)0);
            else
                NFinalizeDeath.Show_MessageDialog("AOrGROnlyRunningSim: " + Bim.AOrGROnlyRunningSim);
        }

        public static bool stee = false;

        public unsafe static
            void aruns_command()
        {
            Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
            {
                if (NFinalizeDeath.CheckAccept("Are you sure?"))
                {
                    ScriptCore.GameUtils.GameUtils_UnpauseImpl();
                    ScriptCore.GameUtils.GameUtils_SetGameTimeScaleImpl(100);

                    if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);

                    uint* ptr = stackalloc uint[0x2FFFF];

                    Sims3.NiecHelp.Tasks.NiecTask.Perform(() =>
                    {
                        while (true)
                        {
                            Simulator.Sleep(0);
                            if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                                NFinalizeDeath.MsCorlibModifed_Exlists(false);
                        }
                    });

                    for (int i = 0; i < 0x2FFF0; i++)
                    {
                        ptr[i] = (uint)niec_std.yuv2rgb((i + 1) % 5 + (i * 5));
                    }

                    if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);

                    ScriptCore.GameUtils.GameUtils_UnpauseImpl();
                    ScriptCore.GameUtils.GameUtils_SetGameTimeScaleImpl(100);

                    stee = true;

                    if (NiecHelperSituation.__acorewIsnstalled__ && NInjetMethed.DoneInjectOuit)
                        ScriptCore.GameUtils.GameUtils_TransitionToQuitImpl();

                    stee = false;

                    NFinalizeDeath.World_NativeInstance = (uint)ptr;

                    NFinalizeDeath.unsafeForceSaveGameNoDialog();

                    if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);

                    try
                    {
                        NFinalizeDeath.SafeCall(() => { Niec.iCommonSpace.KillPro.UnSace((int*)0x10000000u); });
                    }
                    catch (Exception)
                    { ptr = null; }

                    if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);

                    try
                    {
                        NFinalizeDeath.SafeCall(() => { niec_std.reduce((int*)5, (int*)5, 500, 1); });
                    }
                    catch (Exception)
                    { ptr = null; }

                    if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);

                    for (int i = 0; i < 500; i++)
                    {
                        try
                        {
                            niec_std.all_call_native();
                        }
                        catch (Exception)
                        {
                            if (i > 498)
                            {
                                if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                                    NFinalizeDeath.MsCorlibModifed_Exlists(false); throw;
                            }
                        }
                    }

                    if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);
                }
            });
        }

        public static 
            void fakemeteor_command()
        {
            if (!Simulator.CheckYieldingContext(false) || !GameUtils.IsInstalled(ProductVersion.EP2)) 
                return;

            if (fakemeteor_ObjectID.mValue == 0)
            {
                fakemeteor_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    while (true)
                    { 
                        Simulator.Sleep(350);
                        int maxCount = MathUtils.Clamp(ListCollon.SafeRandomPart2.Next(3, 10), 3, 10);
                        for (int i = 0; i < maxCount; i++)
                        {
                            Simulator.Sleep(5);
                            VisualEffect visualEffect = VisualEffect.Create("ep2meteorShower");
                            if (visualEffect == null || visualEffect.ObjectId.mValue == 0)
                                return;

                            Vector3 pos, fwd; NFinalizeDeath.GetCameraPositionAndForward(true, out pos, out fwd);
                            visualEffect.SetPosAndOrient(pos, fwd, Vector3.UnitY);
                            visualEffect.SubmitOneShotEffect(VisualEffect.TransitionType.SoftTransition);
                        }
                       
                    }
                });
            }
            else
            {
                var o = new ObjectGuid(fakemeteor_ObjectID.mValue);
                fakemeteor_ObjectID.mValue = 0;
                Simulator.DestroyObject(o);
                o.mValue = 0;
            }
           
        }
        public static
            void fakemeteorpro_command()
        {
            if (!Simulator.CheckYieldingContext(false) || !GameUtils.IsInstalled(ProductVersion.EP2))
                return;

            if (fakemeteorpro_ObjectID.mValue == 0)
            {
                fakemeteorpro_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    while (true)
                    {
                        Simulator.Sleep(0);
                        int maxCount = MathUtils.Clamp(ListCollon.SafeRandomPart2.Next(5, 20), 5, 20);
                        for (int i = 0; i < maxCount; i++)
                        {
                            Simulator.Sleep(5);
                            VisualEffect visualEffect = VisualEffect.Create("ep2meteorShower");
                            if (visualEffect == null || visualEffect.ObjectId.mValue == 0)
                                return;

                            Vector3 pos, fwd; NFinalizeDeath.GetCameraPositionAndForward(true, out pos, out fwd);
                            visualEffect.SetPosAndOrient(pos, fwd, Vector3.UnitY);
                            visualEffect.SubmitOneShotEffect(VisualEffect.TransitionType.SoftTransition);
                        }

                    }
                });
            }
            else
            {
                var o = new ObjectGuid(fakemeteorpro_ObjectID.mValue);
                fakemeteorpro_ObjectID.mValue = 0;
                Simulator.DestroyObject(o);
                o.mValue = 0;
            }

        }

        public static
            void resetnpchousehold_command()
        {
            NFinalizeDeath.FixUpHouseholdListObjects(true);

            Household.sPetHousehold = Household.Create(true);
            Household.sNpcHousehold = Household.Create(true);

            NFinalizeDeath.FixUpHouseholdListObjects(true);

            trimhouse_command();

            bool p = kForcebooltrimhouse_NRaasStoryProgression;
            kForcebooltrimhouse_NRaasStoryProgression = true;

            trimhouse_command();

            kForcebooltrimhouse_NRaasStoryProgression = p;

            NFinalizeDeath.FixUpHouseholdListObjects(true);
        }

        public static bool ShouldUseUnWiz = false;
        public static bool extestcpudata = false;

        public static
            void extestcpu_command()
        {
            extestcpudata = !extestcpudata;
            if (niec_native_func.cache_done_niecmod_native_message_box)
                niec_native_func.MessageBox(0, "extestcpudata: " + extestcpudata, "NiecMod", (niec_native_func.MB_Type)0);
            else
                NFinalizeDeath.Show_MessageDialog("extestcpudata: " + extestcpudata);
        }

        public static
            void unwiz_command()
        {
            Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
            {
                if (NFinalizeDeath.CheckAccept("Are you sure?"))
                {
                    NFinalizeDeath.MsCorlibModifed_Exlists(false);

                    Sims3.NiecHelp.Tasks.NiecTask.Perform(() =>
                    {
                        while (true)
                        {
                            Simulator.Sleep(0);
                            if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                                NFinalizeDeath.MsCorlibModifed_Exlists(false);
                        }
                    });

                    ScriptCore.GameUtils.GameUtils_UnpauseImpl();
                    ScriptCore.GameUtils.GameUtils_SetGameTimeScaleImpl(1E+07f);

                    NFinalizeDeath.testnomessbox_b = true;
                    if (NFinalizeDeath.CheckAccept("Unsafe"))
                    {
                        NFinalizeDeath.World_NativeInstance = 0x10000000u;
                    }
                    else
                    {
                        ShouldUseUnWiz = true;
                        NFinalizeDeath.World_NativeInstance = 0;
                    }

                    stee = true;
                    if (NiecHelperSituation.__acorewIsnstalled__ && NInjetMethed.DoneInjectOuit)
                        ScriptCore.GameUtils.GameUtils_TransitionToQuitImpl();
                    stee = false;

                    NFinalizeDeath.unsafeForceSaveGameNoDialog();

                    if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                        NFinalizeDeath.MsCorlibModifed_Exlists(false);


                 

                    for (int i = 0; i < 500; i++)
                    {
                        try
                        {
                            niec_std.all_call_native();
                        }
                        catch (Exception)
                        { 
                            if (i > 498) {
                                if (NFinalizeDeath.MsCorlibModifed_ExlistsX(false, false) != 0)
                                    NFinalizeDeath.MsCorlibModifed_Exlists(false);
                                throw; 
                            } 
                        }
                    }
                }
            });
        }

        public static bool neednodisposesmc = false;
        public static bool neednoupdategameobjlot = false;
        public static 
            void ustsimallpro_CommandI()
        {
            if (ScriptCore.CameraController.Camera_GetTarget() == NFinalizeDeath.__Vector3_Em)
                return;

            bool isPbobsNull = false;
            bool acroe = !IsOpenDGSInstalled && NiecHelperSituation.__acorewIsnstalled__;

            if (acroe)
            {
                NFinalizeDeath.testnomessbox_b = true;
            }

            bool forcederSim = false;
            bool ispac = ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl() == 0 || ScriptCore. GameUtils.GameUtils_IsPausedImpl();
            bool issave = acroe && NFinalizeDeath.CheckAccept("Save Game?");
            bool unsafe_test_readmem = acroe && NFinalizeDeath.CheckAccept("Test RW Mem");
            object task_context_org = null;

            if (acroe)
            {
                niec_std.mono_runtime_install_handlers();
                task_context_org = GetTaskContextGameflow() ?? GetTaskContextLoadSaveManager() ?? GetTaskContextLot() ?? GetTaskContextWorldLot();
                if (task_context_org is ScriptCore.TaskContext)
                {
                    ScriptCore.TaskContext a = (ScriptCore.TaskContext)task_context_org;
                    if (a.mFrames == null)
                        task_context_org = null;
                    
                }
                else 
                    task_context_org = null;
            }

            if (task_context_org != null && !(task_context_org is ScriptCore.TaskContext))
            {
                throw new ArgumentException("!(task_context_org is ScriptCore.TaskContext)");
            }

            bool is_goto_failed = false;
            List<Sim> sim_list = null;
            Sim[] backup = null;
            bool keep_active = false;
            bool exaa = false;
            bool pm = NFinalizeDeath.func_address_GetAssemblies != 0;

            failed:
            if (is_goto_failed)
            {
                ispac = ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl() == 0 || ScriptCore.GameUtils.GameUtils_IsPausedImpl();
                sim_list = null;

                task_context_org = GetTaskContextGameflow() ?? GetTaskContextLoadSaveManager() ?? GetTaskContextLot() ?? GetTaskContextWorldLot();
                if (task_context_org is ScriptCore.TaskContext)
                {
                    ScriptCore.TaskContext a = (ScriptCore.TaskContext)task_context_org;
                    if (a.mFrames == null)
                        task_context_org = null;
                }
                else task_context_org = null;
            }

            var aor = new List<Sim>();

            if (!is_goto_failed)
                forcederSim = NFinalizeDeath.CheckAccept("All Kill Sim?");

            if (!issave && forcederSim)
                forcesetaa3_Command(null, false, false);

            if (!is_goto_failed)
            {
                keep_active = !forcederSim && NFinalizeDeath.CheckAccept("Keep Active Household?");

                exaa = keep_active && NFinalizeDeath.CheckAccept("Keep Active Actor?");

                if (!forcederSim && !exaa && !keep_active)
                {
                    NiecException.PrintMessagePro("ustsimallpro() Cancelled.", false, 0);
                    return;
                }
            }

            if (issave)
            {
                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause, false);

                if (IsVisibleTreatmentsController())
                {
                    if (acroe && NFinalizeDeath.testnomessbox_b && niec_native_func.cache_done_niecmod_native_message_box)
                    {
                        Simulator.Sleep(0);
                    }
                    else
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            Simulator.Sleep(0);
                        }
                    }
                }

                if (forcederSim)
                    forcesetaa3_Command(null, false, false);

                if (NFinalizeDeath.SC_GetObjects<Sim>().Length != 0)
                {
                    isPbobsNull = PlumbBob.sSingleton == null;
                    VideoRecorder.SnapshotFileName = "ustsimallpro_s_Screenshot";
                    Sims3.UI.Hud.CameraFlash.Flash();
                    VideoRecorder.TakeSnapshot();
                }

                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Triple, false);
            }
            if (exaa || forcederSim)
            {
                Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommandsNoStatic, Sims3GameplaySystems", false);
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

                if (acroe)
                {
                    if (!pm)
                        NFinalizeDeath.UnsafePreventGetAssemblies();
                    neednodisposesmc = true;
                    neednoupdategameobjlot = true;
                    usev_Command(true, NiecHelperSituation.__acorewIsnstalled__);
                    abackup = AlarmManager.sWorldAlarmManager;
                    AlarmManager.sWorldAlarmManager = null;

                    var lotworld = LotManager.GetWorldLot();
                    if (lotworld != null && lotworld.mSavedData != null)
                    {
                        aLotbackup = lotworld.mSavedData.mAlarmManager;
                        lotworld.mSavedData.mAlarmManager = null;
                    }

                    if (GCLotA_MBRACKUP == null)
                    {
                        GCLotA_MBRACKUP = new Dictionary<Lot, object>();
                    }

                    var lots = LotManager.sLots;
                    if (lots != null)
                    {
                        foreach (var item in lots)
                        {
                            var valueLOT = item.Value;
                            if (valueLOT == null)
                                continue;

                            if (valueLOT == lotworld)
                                continue;

                            if (GCLotA_MBRACKUP.ContainsKey(valueLOT))
                                continue;

                            var savedData = valueLOT.mSavedData;
                            if (savedData != null)
                            {
                                GCLotA_MBRACKUP.Add(valueLOT, savedData.mAlarmManager);
                                savedData.mAlarmManager = null;
                            }
                        }
                    }
                }
            }

            var aa = NFinalizeDeath.ActiveActor;
            var o = backup ?? (backup = NFinalizeDeath.SC_GetObjects<Sim>());
            var oC = o.Length + 10;

            if (!issave)
            {
                if (o.Length != 0)
                {
                    isPbobsNull = PlumbBob.sSingleton == null;
                    VideoRecorder.SnapshotFileName = "ustsimallpro_s_Screenshot";
                    Sims3.UI.Hud.CameraFlash.Flash();
                    VideoRecorder.TakeSnapshot();
                }
            }

            sim_list = new List<Sim>(oC < 0 ? 0 : oC);

            foreach (var objSim in o)
            {
                if (objSim == null)
                    continue;
                ulong objID = objSim.ObjectId.mValue;

                ScriptCore.ScriptProxy proxy = objID != 0 ? objSim.Proxy as ScriptCore.ScriptProxy : null;
                if (!forcederSim && keep_active && NFinalizeDeath.IsAllActiveHousehold_SimObject(objSim))
                {
                    if (exaa)
                    {
                        if (objSim == aa)
                        {
                            objSim.SetPosition(Vector3.OutOfWorld);
                            aor.Add(objSim);
                            continue;
                        }
                        else { }
                    }
                    else continue;
                }

                if (!forcederSim && !keep_active && !exaa && objSim == aa)
                {
                    objSim.SetPosition(Vector3.OutOfWorld);
                    aor.Add(objSim);
                    continue;
                }

                if (acroe)
                {
                    var t = objSim.mThoughtBalloonManager;
                    if (t != null)
                    {
                        ListCollon.SafeObjectGC.Add(t);

                        if (t.CurrentBalloon != null)
                            ListCollon.SafeObjectGC.Add(t.CurrentBalloon);
                        if (t.mPendingBalloons != null)
                            ListCollon.SafeObjectGC.Add(t.mPendingBalloons);

                        if (t.mEffect != null)
                        {
                            ListCollon.SafeObjectGC.Add(t.mEffect);
                            t.mEffect.SetAutoDestroy(false);
                        }

                        t.mPendingBalloons = null;
                        t.mCurrentBalloon = null;
                        t.mEffect = null;

                        objSim.mThoughtBalloonManager = null;
                    }
                }


                NFinalizeDeath.UnSafeForceErrorTargetSim(objSim);

                SimDescription sd = null;
                sd = objSim.mSimDescription;
                objSim.mSimDescription = null;

                if (sd != null)
                    sd.mSim = null;

                if (objID != 0 && task_context_org != null && task_context_org is ScriptCore.TaskContext)
                {
                    var p = GetPreCopyTaskContext(objID);
                    if (p != null)
                    {
                        if (GCKeepGameCrash != null)
                            GCKeepGameCrash.Add(p);

                        var e = (ScriptCore.TaskContext)CopyTaskContext(task_context_org, true);
                        if (e.mFrames != null)
                            ScriptCore.TaskControl.TaskControl_SetTaskContext(objID, ref e);
                    }
                }

                ScriptCore.Simulator.Simulator_DestroyObjectImpl(objSim.mSimUpdateId.mValue);
                objSim.mSimUpdateId.mValue = 0;

                if (acroe)
                {
                    NFinalizeDeath.UnsafeAllThatBugSimCantUse(objSim);
                    ScriptCore.Simulator.Simulator_DestroyObjectImpl(objID);
                }
                else
                {
                    NFinalizeDeath.ForceDestroyObject(objSim, false);
                }

                if (acroe && proxy != null)
                {
                    proxy.mTarget = null;
                    proxy.mObjectId.mValue = 0;
                }

                NFinalizeDeath.AddItemToList(sim_list, objSim);

                if (acroe)
                    NFinalizeDeath.AddItemToList(ListCollon.SafeObjectGC_TempBim, objSim);

            }

            if (o.Length != 0)
            {
                if (acroe)
                {
                    ITask iFinalizerTask;
                    NFinalizeDeath.FindTaskPro("at Void Sims3.SimIFace.FinalizerTask.Simulate()", null, out iFinalizerTask);
                    var finalizerTask = iFinalizerTask as FinalizerTask;
                    if (finalizerTask != null)
                    {
                        finalizerTask.mQueue = new FinalizerQueue();
                    }
                }

                VideoRecorder.SnapshotFileName = "ustsimallpro_f_Screenshot";
                Sims3.UI.Hud.CameraFlash.Flash();
                VideoRecorder.TakeSnapshot();
            }

            if (issave)
            {
                AllLotCleanUpAndRepair(true, true);
                NFinalizeDeath.RemoveAllSimNiecNullForGrave(true);
                var grave_all = NFinalizeDeath.SC_GetObjects<Urnstone>();
                var pos_outofWorld = NFinalizeDeath.Vector3_OutOfWorld;

                if (grave_all != null)
                {
                    foreach (var grave in grave_all)
                    {
                        if (ScriptCore.Objects.Objects_GetPosition(grave.ObjectId.mValue) == pos_outofWorld)
                            NFinalizeDeath.ForceDestroyObject(grave, false);
                    }
                }

                NFinalizeDeath.Assert(aLotbackup != null, "aLotbackup == null");

                niec_std.mono_runtime_install_handlers();

                goto t;

            }
            else if (acroe && niec_native_func.cache_done_niecmod_native_message_box)
                niec_native_func.MessageBox(0, "Play Ready?", "NiecMod", 0);

            if (!ispac)
            {
                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Triple, false);
                Simulator.Sleep(55);
            }

            asodase = true;
            if (CommandSystem.Exists() && CommandSystem.GetCommandHelp("dgsmods") != null)
                CommandSystem.ExecuteCommandString("dgsmods exlists");

            Simulator.Sleep(0);

            if (forcederSim)
                NFinalizeDeath.TestSetActiveActor(null, !isPbobsNull);

            asodase = true;
            if (CommandSystem.Exists() && CommandSystem.GetCommandHelp("dgsmods") != null)
                CommandSystem.ExecuteCommandString("dgsmods exlists");

            t:;

            asodase = false;
            if (tusev != null)
                usev_Command(false, false);

            if (acroe)
            {
                if (!pm)
                    NFinalizeDeath.RemovePreventGetAssemblies();
                if (abackup is AlarmManager)
                {
                    AlarmManager.sWorldAlarmManager = abackup as AlarmManager;
                }
                if (aLotbackup is AlarmManager)
                {
                    var lotworld = LotManager.GetWorldLot();
                    if (lotworld != null && lotworld.mSavedData != null)
                    {
                        lotworld.mSavedData.mAlarmManager = aLotbackup as AlarmManager;
                    }
                }

                abackup = null;
                aLotbackup = null;

                if (GCLotA_MBRACKUP != null)
                {
                    foreach (var item in GCLotA_MBRACKUP)
                    {
                        var valueLot = item.Key;
                        if (valueLot != null && valueLot.mSavedData != null && item.value is AlarmManager)
                        {
                            valueLot.mSavedData.mAlarmManager = item.value as AlarmManager;
                        }
                    }
                    GCLotA_MBRACKUP.Clear();
                }
                GCLotA_MBRACKUP = null;
            }


            if (acroe)
            {
                ITask iFinalizerTask;
                NFinalizeDeath.FindTaskPro("at Void Sims3.SimIFace.FinalizerTask.Simulate()", null, out iFinalizerTask);
                var finalizerTask = iFinalizerTask as FinalizerTask;
                if (finalizerTask != null)
                {
                    finalizerTask.mQueue = new FinalizerQueue();
                }
            }

            if (issave)
            {
                var simd = Create.NiecNullSimDescription(true, false, false) ?? new SimDescription(); 
                foreach (var item in sim_list._items)
                {
                    if (item == null)
                        continue;

                    if (acroe)
                        NFinalizeDeath.UnSafeForceErrorTargetSim(item);

                    item.mSimDescription = simd;
                }

                var ep = GCKeepGameCrash;

                GCKeepGameCrash = null;
            
                if (NFinalizeDeath.unsafeForceSaveGameNoDialog() != LoadSaveManager.eLoadSaveErrorCode.kNoError && !is_goto_failed)
                {
                    is_goto_failed = true;
                    issave = false;
                    goto failed;
                }

                foreach (var item in sim_list._items)
                {
                    if (item == null)
                        continue;
                    item.mSimDescription = null;
                }

                GCKeepGameCrash = ep;

                NFinalizeDeath.MsCorlibModifed_Exlists(false);

                if (acroe && niec_native_func.cache_done_niecmod_native_message_box)
                {
                    niec_native_func.MessageBox(0, "Saved Game Play Ready?", "NiecMod", 0);
                    //niec_native_func.MessageBox(0, "Saved Game Play Ready Again?", "NiecMod", 0);
                }
                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause, false);
            }

            if (aor.Count > 0)
            {
                Vector3 pos, fwd; NFinalizeDeath.GetCameraPositionAndForward(true, out pos, out fwd);
                foreach (var item in aor.ToArray())
                {
                    item.SetPosition(pos);
                    item.SetForward(fwd);
                }
            }

            if (forcederSim)
                NFinalizeDeath.TestSetActiveActor(null, true);

            Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause, false);

            if (sim_list != null)
            {
                if (acroe)
                {
                    ITask iFinalizerTask;
                    NFinalizeDeath.FindTaskPro("at Void Sims3.SimIFace.FinalizerTask.Simulate()", null, out iFinalizerTask);
                    var finalizerTask = iFinalizerTask as FinalizerTask;
                    if (finalizerTask != null)
                    {
                        finalizerTask.mQueue = new FinalizerQueue();
                    }
                }

                for (int i = 0; i < 200; i++)
                {
                    Simulator.Sleep(0);
                }

                SimDescription simd = Create.NiecNullSimDescription(true, false, false) ?? new SimDescription();
                foreach (var item in sim_list._items)
                {
                    if (item == null) continue;

                    if (acroe) NFinalizeDeath.UnSafeForceErrorTargetSim(item);
                    item.mSimDescription = simd;
                }

                sim_list.Clear();
            }

            if (isPbobsNull)
            {
                NFinalizeDeath.FixUpPlumbBobSingletonNull();
                NFinalizeDeath.TestSetActiveActor(null, false);
            }

            NFinalizeDeath.MsCorlibModifed_Exlists(false);

            if (unsafe_test_readmem)
            {
                test_read_mem();
                GC.Collect();
                Sims3.NiecHelp.Tasks.NiecTask.Perform(() =>
                {
                    for (int i = 0; i < 200; i++)
                    {
                        Simulator.Sleep(0);
                    }
                    GC.Collect();
                });
            }

            NFinalizeDeath.MsCorlibModifed_Exlists(false);
        }


        public static
            int GetCommandHelp(params object[] parameters)
        {
            string text = "NiecMod\nUsage: niecmod [text]";

            text += "\n" + "[text] = Other Mode";
            text += "\n" + "Try: niecmod exitniechs";
            text += "\n" + "Helps: 01";
            text += "\n" + GetNiecModCommandList();

            if (global:: Sims3.UI.NotificationManager.Instance != null && IsVisibleTreatmentsController())
            {
                NiecException.PrintMessagePro(text, true, 10);
                NiecException.PrintMessagePro("Helps: 02\n" + GetNiecModCommandList02(), true, 10);
                NiecException.PrintMessagePro("Helps: 03\n" + GetNiecModCommandList03(), true, 10);
            }
            else {

                NCopyableTextDialog copyableTextDialog = new NCopyableTextDialog();
                copyableTextDialog.Text = text; 
                copyableTextDialog.Text += "\n\nHelps: 02\n" + GetNiecModCommandList02();
                copyableTextDialog.Text += "\n\nHelps: 03\n" + GetNiecModCommandList03();

                

                if (Simulator.CheckYieldingContext(false))
                    copyableTextDialog.Show("Command Help");
                else 
                    Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate { copyableTextDialog.Show("Command Help"); });
            }

            return 0;
        }

        public static 
            bool aforcesetaa3_Command(bool Safe)
        {
            if (PlumbBob.sSingleton == null) 
                return false;
            if (PlumbBob.sSingleton.mSelectedActor == null)
            {
                if (!Safe && NiecHelperSituation.__acorewIsnstalled__)
                {
                    forcesetaa3_Command(NFinalizeDeath.GetRandomSim(), false, false);
                }
                else if (LoadingScreenController.IsLayoutLoaded())
                {
                    forcesetaa3_Command(NFinalizeDeath.GetRandomSim(NFinalizeDeath.SimIsValidFromLoadingSaveFile), false, false);
                }
                else
                {
                    forcesetaa3_Command(NFinalizeDeath.GetRandomSim(NFinalizeDeath.SimIsValid), false, false);
                }
                return PlumbBob.sSingleton.mSelectedActor != null;
            }
            return true;
        }

        public static bool GameObjectHasDestroyed(GameObject gameObject) {
            try
            {
                if (gameObject == null) return true;
                return gameObject.HasBeenDestroyed;
            }
            catch (ResetException)
            { throw; }
            catch { }
            return true;
         }

        [PersistableStatic]
            public static bool AutoAllNewNiecSWLoad = false;

        [PersistableStatic]
            public static bool AutoAllNewNiecSW_bAddIfIsPet = false;

        [PersistableStatic]
            public static bool AutoAllNewNiecSW_bAddIfIsSelectable = false;

        //[PersistableStatic(false)]
        //    public static bool AutoAllNewNiecSW_bNoDialog = false;

        public static 
            void AutoAllNewNiecSW(bool bAddIfIsPet = true, bool bAddIfIsSelectable = true, bool bNoDialog = true)
        {
            //ObjectGuid.InvalidObjectGuid = new ObjectGuid(33);

            if (autoAllnewniechs.mValue != 0)
            {
                //Simulator.DestroyObject(autoAllnewniechs);
                //autoAllnewniechs = ObjectGuid.InvalidObjectGuid;
                return;
            }

            NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
            NiecHelperSituation.Spawn._bUnSafeRunAll = true;

            //AutoAllNewNiecSW_bAddIfIsPet = bAddIfIsPet;
            //AutoAllNewNiecSW_bAddIfIsSelectable = bAddIfIsSelectable;

            autoAllnewniechs = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
            {

                bool AddIfIsPet = bAddIfIsPet || !bNoDialog && Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Add if IsPet?");

                bool AddIfIsSelectable = bAddIfIsSelectable || !bNoDialog && Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Add if IsSelectable?");

                AutoAllNewNiecSW_bAddIfIsPet = AddIfIsPet;
                AutoAllNewNiecSW_bAddIfIsSelectable = AddIfIsSelectable;

                Sim vActiveActor_OpenDGS = NFinalizeDeath.ActiveActor;
                Sim vActiveActor_NonOpenDGS = PlumbBob.SelectedActor;

                int isleep = 0;
                
                //while (true)
                do
                {
                    AutoAllNewNiecSWLoad = true;
                    Simulator.Sleep(50);

                    try
                    {
                        var simList = NFinalizeDeath.SC_GetObjects<Sim>();
                        foreach (var ActorFor in simList)
                        {

                            isleep++;
                            if (isleep > 40)
                            {
                                NFinalizeDeath.SleepTask(15);
                                isleep = 0;
                            }

                            if (ActorFor == vActiveActor_OpenDGS || ActorFor == vActiveActor_NonOpenDGS)
                                continue;

                            SimDescription simd = ActorFor.SimDescription;

                            if (simd == null || GameObjectHasDestroyed(ActorFor))
                                continue;
                           
                            

                            InteractionQueue iInteractionQueue = ActorFor.InteractionQueue;
                            if (iInteractionQueue == null)
                                continue;

                            Autonomy automoy = ActorFor.Autonomy;
                            if (automoy == null)
                                continue;
                            if (!IsOpenDGSInstalled && !AddIfIsPet)
                            {
                                if ( automoy.mSituationComponent == null )
                                {
                                    if (!simd.IsPet) { }
                                    else automoy.mSituationComponent = new SituationComponent(ActorFor);
                                }
                            }
                            SituationComponent sSituationComponent = automoy.SituationComponent;
                            if (sSituationComponent == null)
                                continue;

                            List<Situation> listSituations = sSituationComponent.Situations;
                            if (listSituations == null)
                                continue;

                            if (IsOpenDGSInstalled)
                            {
                                NFinalizeDeath.SimRemove_SituationList(ActorFor, null, true);
                                if (((simd.Service as GrimReaper ?? simd.CreatedByService as GrimReaper) != null) && ServiceSituation.FindServiceSituationInvolving(ActorFor) is GrimReaperSituation)//(simd.Service ?? simd.CreatedByService) is GrimReaper)
                                    continue;
                            }

                            if (AddIfIsPet && simd.IsPet)
                                continue;

                            if (AddIfIsSelectable && ActorFor.IsSelectable)
                                continue;

                            NiecHelperSituation niecHelperSituation = NFinalizeDeath.GetSituationFromSituationList<NiecHelperSituation>(listSituations);// = ActorFor.GetSituationOfType<NiecHelperSituation>();
                            if (niecHelperSituation != null)
                            {
                                //NiecHelperSituation.Spawn nhsSp = niecHelperSituation.Child as NiecHelperSituation.Spawn;
                                //if (nhsSp != null)
                                //    nhsSp.ReCreateTick(null);
                                continue;
                            }
                            else
                            {
                                var nhs = NiecHelperSituation.Create(ActorFor.LotCurrent, ActorFor);
                                if (nhs != null)
                                    listSituations.Add(nhs);
                                //else no debug sorry
                            }
                        }
                        //for (int _Sleep = 0; _Sleep < 25; _Sleep++)
                        //    Simulator.Sleep(0);
                        NFinalizeDeath.SleepTask((uint)simList.Length);
                        NFinalizeDeath.ReAllNHSOnTickSleep(simList);
                    }
                    catch (ResetException)
                    { AutoAllNewNiecSWLoad = false; throw; }
                    catch
                    {
                        if (!Simulator.CheckYieldingContext(false)) { autoAllnewniechs = ObjectGuid.InvalidObjectGuid; AutoAllNewNiecSWLoad = false; throw; }
                        for (int _Sleep = 0; _Sleep < 150; _Sleep++)
                            Simulator.Sleep(0);
                    }

                    vActiveActor_OpenDGS = NFinalizeDeath.ActiveActor;
                    vActiveActor_NonOpenDGS = PlumbBob.SelectedActor;

                    Simulator.Sleep(85);
                }
                while(true);
            });
        }
        //public static int MyRand_Range(int min, int max)
        //{
        //    return g_pcgrand.range(min, max);
        //}

        

        //public delegate void TempSCSCP____(ScriptCore.ScriptProxy proxy, Exception e);

        public static
            Sim HitTargetSim()
        {
            if (IsOpenDGSInstalled && (GameStates.IsInMainMenuState || GameStates.IsEditTownState || GameStates.IsCasState))
                return null;
            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                ScenePickArgs p = t.GetPickArgs();
                if (p.mObjectId != 0)
                {
                    IScriptProxy proxy = Simulator.GetProxy(new ObjectGuid(p.mObjectId));
                    if (proxy != null)
                    {
                        /*
                        Sim sGameObject = proxy.Target as Sim;
                        if (sGameObject != null)
                        {
                            return sGameObject;
                        }*/
                        return proxy.Target as Sim;
                    }
                }
            }
            return null;
        }

        public static
           T GetHitTarget<T>() where T : class
        {
            if (IsOpenDGSInstalled && (GameStates.IsInMainMenuState || GameStates.IsEditTownState || GameStates.IsCasState))
                return null;
            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                ScenePickArgs p = t.GetPickArgs();
                if (p.mObjectId != 0)
                {
                    IScriptProxy proxy = Simulator.GetProxy(new ObjectGuid(p.mObjectId));
                    if (proxy != null)
                    {
                        return proxy.Target as T;
                    }
                }
            }
            return null;
        }

        public static
            GameObjectHit GetGameObjectHit()
        {
            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                //ScenePickArgs p = t.GetPickArgs();
                return t.GetPickArgs().AsGameObjectHit();
            }
            return new GameObjectHit();
        }

        public static
           GameObject HitTargetGameObject()
        {
            if (IsOpenDGSInstalled && (GameStates.IsInMainMenuState || GameStates.IsEditTownState || GameStates.IsCasState))
                return null;
            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                
                ScenePickArgs p = t.GetPickArgs();
                if (p.mObjectId != 0)
                {
                    IScriptProxy proxy = Simulator.GetProxy(new ObjectGuid(p.mObjectId));
                    if (proxy != null)
                    {
                        return proxy.Target as GameObject;
                    }
                }
            }
            return null;
        }
        public static
           ulong HitTargetObjectDontHaveScript()
        {
            
            if (IsOpenDGSInstalled && (GameStates.IsInMainMenuState || GameStates.IsEditTownState || GameStates.IsCasState))
                return 0;
            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                return t.GetPickArgs().mObjectId;
            }
            return 0;
        }
        public static
           Lot HitTargetLot()
        {
            if (IsOpenDGSInstalled && (GameStates.IsInMainMenuState || GameStates.IsEditTownState || GameStates.IsCasState))
                return null;
            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                ScenePickArgs p = t.GetPickArgs();
               if (p.mObjectId != 0)
               {
                   IScriptProxy proxy = Simulator.GetProxy(new ObjectGuid(p.mObjectId));
                   if (proxy != null && proxy.Target is Lot)
                   {
                       return proxy.Target as Lot;
                   }
                   else if (p.mObjectId != 0 && LotManager.sLots != null) 
                   { 
                       Lot lot;
                       LotManager.sLots.TryGetValue(p.mObjectId, out lot);
                       if (lot != null && lot.Proxy != null)
                       {
                           return lot;
                       }
                       else
                       {
                           ObjectGuid lotObjectGuid = LotManager.GetLotObjectGuid(p.mObjectId);
                           if (lotObjectGuid != NiecInvalidObjectGuid)
                           {
                               return GameObject.GetObject<Lot>(lotObjectGuid);
                           }
                           return LotManager.GetLot(p.mObjectId);
                       }
                   }
               }
            }
            return null;
        }
        public static
           IScriptLogic HitTargetIScriptLogic()
        {
            if (IsOpenDGSInstalled && (GameStates.IsInMainMenuState || GameStates.IsEditTownState || GameStates.IsCasState))
                return null;
            SceneMgrWindow t = UIManager.GetSceneWindow();
            if (t != null)
            {
                ScenePickArgs p = t.GetPickArgs();
                if (p.mObjectId != 0)
                {
                    IScriptProxy proxy = Simulator.GetProxy(new ObjectGuid(p.mObjectId));
                    if (proxy != null)
                    {
                        return proxy.Target;
                    }
                }
            }
            return null;
        }

        public static
            void trimhouse_command()
        {
            NFinalizeDeath.TrimHouse(5);
            if (kForcebooltrimhouse_NRaasStoryProgression || AssemblyCheckByNiec.IsInstalled("NRaasStoryProgression"))
            {
                NFinalizeDeath.FixUpHouseholdListObjects(true);
                List<SimDescription> removedSimDescList = new List<SimDescription>();
                Household ah = NFinalizeDeath.ActiveHousehold;
                foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                {
                    if (item == null || ah == item) 
                        continue;

                    try
                    {
                        NFinalizeDeath.RemoveNullForHouseholdMembers(item);
                        if (item.IsSpecialHousehold)
                            continue;
                    }
                    catch (ResetException)
                    { throw; }
                    catch { }
                    Household.Members memList = item.CurrentMembers;
                    if (memList == null) continue;
                    if (item.LotHome == null)
                    {
                        try
                        {
                            if (memList.mAllSimDescriptions != null)
                            {
                                foreach (var itemMember in memList.mAllSimDescriptions.ToArray())
                                {
                                    if (itemMember == null)
                                    {
                                        continue;
                                    }
                                    NFinalizeDeath.Household_Remove(itemMember, true);
                                    removedSimDescList.Add(itemMember);
                                }
                                memList.mAllSimDescriptions.Clear();
                            }
                            if (memList.mPetSimDescriptions != null)
                                memList.mPetSimDescriptions.Clear();
                            if (memList.mSimDescriptions != null)
                                memList.mSimDescriptions.Clear();
                            NFinalizeDeath.HouseholdCleanse(item, false, true);
                            continue;
                        }
                        catch (ResetException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                    }
                }
                if (removedSimDescList.Count > 0)
                {
                    foreach (var item in removedSimDescList.ToArray())
                    {
                        if (item == null)
                        {
                            continue;
                        }

                        NFinalizeDeath.Household_Add
                        (
                            NFinalizeDeath.GetRandomGameObject<Household> // targethousehold
                            (
                                //delegate(Household test) // customTest
                                //{
                                //    if (test == null)
                                //        return false;
                                //    Simulator.Sleep(0);
                                //    try
                                //    {
                                //        if (test.IsSpecialHousehold)
                                //            return false;
                                //        if (test.LotHome == null)
                                //            return false;
                                //        if (IsOpenDGSInstalled && (test == ah))
                                //            return false;
                                //    }
                                //    catch (ResetException)
                                //    {
                                //        throw;
                                //    }
                                //    catch (Exception)
                                //    {
                                //        return false;
                                //    }
                                //    return true;
                                //}
                                NFinalizeDeath.Household_IsNoActiveOrSpecialOrHomeless
                            ),
                            item, // simDesc
                            true
                        );
                        if (item.Household == null)
                        {
                            Create.AutoMoveInLotFromHousehold(NFinalizeDeath.Household_Create(item));
                        }
                        Simulator.Sleep(0);
                    }
                }
                removedSimDescList.Clear();
                NFinalizeDeath.Household_CleanUp();
            }
        }

        public static
            void excashousehold_Command()
        {
            if (Bin.sSingleton == null)
                return;
            var casCore = CASLogic.sSingleton;
            if (casCore == null)
                return;
            if (casCore.mHouseholdScriptHandle.mValue != 0)
            {
                var household = NFinalizeDeath.GetObject_internalFastTask(casCore.mHouseholdScriptHandle.mValue) as Household;
                if (household != null)
                {
                    NFinalizeDeath.RemoveNullForHouseholdMembers(household);
                    if (household.mMembers != null && household.mMembers.mAllSimDescriptions != null && household.mMembers.mAllSimDescriptions.Count != 0)
                    {
                        if (household.mName == null || household.mName == "")
                        {
                            household.SetName("CASHousehold " + NFinalizeDeath.GetNowTimeToStr());
                        }
                        if (household.mBioText == null || household.mBioText == "")
                        {
                            household.mBioText = "";
                        }
                        try
                        {
                            casCore.SetHouseholdStartingFunds();
                        }
                        catch (Exception)
                        { }
                        if (household.mFamilyFunds == 0)
                        {
                            household.mFamilyFunds = 50000;
                        }
                        var ty = household.mMembers.mAllSimDescriptions;
                        foreach (var item in ty.ToArray())
                        {
                            if (item == null)
                            {
                                ty.Remove(null);
                                continue;
                            }
                            if (item.mFirstName == null || item.mFirstName == "")
                            {
                                item.mFirstName = "No name";
                            }
                            if (item.mLastName == null || item.mLastName == "")
                            {
                                item.mLastName = "No name";
                            }
                            if (item.mBio == null || item.mBio == "")
                            {
                                item.mBio = "";
                            }
                        }

                        string packageFile = null;
                        packageFile = Commom.Proxies.HouseholdContentsProxy.NExportHousehold
                            (Bin.Singleton, household, false, false, true, false);
                        NiecException.PrintMessagePro(packageFile, false, 4000);

                    }
                }
            }
        }

        public static
            void ActorSimDesc_Switch_TargetSimDesc(Sim pActor, Sim pTarget)
        {
            if (pActor == null)
                return;
            if (pTarget == null)
            {
                pTarget = HitTargetSim();
                if (pTarget == null) 
                    return;
            }

            if (pActor == pTarget) 
                return;

            SimDescription SimDescActor = pActor.SimDescription;
            SimDescription SimDescTarget = pTarget.SimDescription;


            pTarget.mSimDescription = SimDescActor;
            if (SimDescTarget != null)
                SimDescTarget.mSim = pActor;

            pActor.mSimDescription = SimDescTarget;
            if (SimDescActor != null)
                SimDescActor.mSim = pTarget;
        }

        internal static
            void astsimdescp_Internal(Sim pActor)
        {
            Simulator.CheckYieldingContext(true);

            Sim actor = pActor ?? HitTargetSim();
            if (actor == null)
                return;

            Sim target;
            do
            {
                for (int _ = 0; _ < 150; _++)
                    Simulator.Sleep(0);

                Simulator.Sleep(0);
                target = HitTargetSim() ?? actor;
            }
            while (target == actor);

            NFinalizeDeath.Assert(target != actor, "target == actor");

            SimDescription SimDescActor = actor.SimDescription;
            SimDescription SimDescTarget = target.SimDescription;

            target.mSimDescription = SimDescActor;
            if (SimDescTarget != null)
                SimDescTarget.mSim = actor;

            actor.mSimDescription = SimDescTarget;
            if (SimDescActor != null)
                SimDescActor.mSim = target;
        }

        public static
            void ActorSimDesc_Switch_TargetSimDescP(Sim pActor)
        {
            Sim actor = pActor ?? HitTargetSim();
            if (actor == null) 
                return;

            if (Simulator.CheckYieldingContext(false))
                astsimdescp_Internal(actor);
            else Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate {
                astsimdescp_Internal(actor);
            });
        }

        public static void item_remove_iq_running_list(Sim item, bool safe)
        {
            var iq = item.mInteractionQueue;
            if (iq != null)
            {
                //if (iq.mRunningInteractions == null) {
                iq.mRunningInteractions = new Stack<InteractionInstance>();

                iq.mCurrentTransitionInteraction = null; 
                if (safe)
                {
                    iq.mBabyOrToddlerTransitionTargetInteraction = null;
                    iq.mInteractionTimerRunning = false;
                    iq.mIsHeadInteractionActive = false;
                    iq.mIsHeadInteractionLocked = false;
                }
                if (iq.mInteractionList != null && iq.mInteractionList._items != null && iq.mInteractionList._items.Length > 0)
                {
                    var ii = iq.mInteractionList._items[0];
                    if (ii != null)
                    {
                        ii.mInteractionState = InteractionInstance.InteractionState.None;
                    }
                }
                // } else iq.mRunningInteractions.Clear();
            }
        }
        public static ulong CreateRUQRLLISTLoopTask_objectID = 0;
        public static ulong CreateRUQRLLISTLoopTask(bool nodialog)
        {
            if (CreateRUQRLLISTLoopTask_objectID == 0) {
                CreateRUQRLLISTLoopTask_objectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate {
                    while (true)
                    {
                        Simulator.Sleep(0);
                        @munsafe_remove_iq_runinng_list((Sim p) => NFinalizeDeath._SimRunningNHSInteraction(p));
                    }
                }).mValue;
            }
            else
            {
                Simulator.DestroyObject(new ObjectGuid(CreateRUQRLLISTLoopTask_objectID));
                CreateRUQRLLISTLoopTask_objectID = 0;
            }
            return CreateRUQRLLISTLoopTask_objectID;
        }

        public static void @munsafe_remove_iq_runinng_list(Predicate<Sim> custom_test = null, bool safe = false)
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>()) 
            {
                if (item == null) 
                    continue;

                if (custom_test != null && !custom_test(item)) 
                    continue;

                item_remove_iq_running_list(item, safe);
            }
        }

        public static
            void ActiveActorSimDesc_Switch_TargetSimDesc(Sim pTarget)
        {
            Sim target = pTarget ?? HitTargetSim();
            Sim activeActor = NFinalizeDeath.ActiveActor;
            if (target != null && activeActor != null && target.SimDescription != null && target != activeActor)
            {
                SimDescription SimDescActor = activeActor.SimDescription;
                SimDescription SimDescTarget = target.SimDescription;

                target.mSimDescription = SimDescActor;
                if (SimDescTarget != null)
                    SimDescTarget.mSim = activeActor;

                activeActor.mSimDescription = SimDescTarget;
                if (SimDescActor != null)
                    SimDescActor.mSim = target;

                PlumbBob.sCurrentNonNullHousehold = NFinalizeDeath.ActiveHousehold;

                if (!IsOpenDGSInstalled)
                    AllCommandI(new object[] { "fixonisplayer" });
            }
        }

        public static
            void ScolidSim(Sim Target)
        {
            if (Target != null)
            {
                if (Target.SimDescription != null && Target.SimDescription.TeenOrBelow && !Target.IsSelectable)
                {
                    loopp_listobjectguild.Add(global::Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                    {
                        try
                        {
                            while (true)
                            {
                                Simulator.Sleep(5);

                                if (Target.SimDescription == null || Target.HasBeenDestroyed || Target.InteractionQueue == null)
                                    break;
                                else if (!Target.SimDescription.TeenOrBelow)
                                    break;
                                else if (Target.IsSelectable)
                                    continue;
                                else if (Target.InteractionQueue.HasInteractionOfType(typeof(Punishment.DoTimeOut)))
                                    continue;

                                Punishment punishmentManagerFromSim = Punishment.GetPunishmentManagerFromSim(Target);
                                if (punishmentManagerFromSim != null)
                                {
                                    NFinalizeDeath.CustomApplyDeviantBehaviorToSim
                                        (punishmentManagerFromSim, Punishment.DeviantBehaviorType.BadGrades, false, false, 3);
                                    Simulator.Sleep(0);
                                }
                                else break;
                            }
                        }
                        finally
                        {
                            loopp_listobjectguild.Remove(Simulator.CurrentTask);
                        }

                    }));
                }
            }
        }

        public static Household addsimtohousehold_cdata = null;

        public static Household hmhHousehold = null;

        public static GameObject objstoa = null;

        public static bool OnHouseholdList = false;

        public static bool IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");

       
        public static List<ObjectGuid> loopfire_listobjectguild = new List<ObjectGuid>();

        public static List<ObjectGuid> loopp_listobjectguild = new List<ObjectGuid>();

        public static readonly ObjectGuid NiecInvalidObjectGuid = new ObjectGuid(0);

        public static ObjectGuid auto_maxmoodloop = NiecInvalidObjectGuid;

        public static ObjectGuid auto_rtnodark = NiecInvalidObjectGuid;

        public static ObjectGuid autoAllnewniechs = NiecInvalidObjectGuid;

        public static ObjectGuid autoAntiNPCAutoManger = NiecInvalidObjectGuid;

        public static ObjectGuid autoPlayCollaner = NiecInvalidObjectGuid;

        public static ObjectGuid debugsavenamefileTask = NiecInvalidObjectGuid;

        public static List<Household> listHouseholdbackup = new List<Household>();

        public static string noPSaveSimDesc = null;

        public static bool adsrt = false;

        public static GameObject psLoop_Sim = null;

        public static List<Lot> exLotList = new List<Lot>();

        public static ObjectGuid ustsimallloop_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid psLoop_ObjectID = NiecInvalidObjectGuid;

        public static ObjectGuid looppaa_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid hitloopdied_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid hitloopdied2_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid looppaa02_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid alldinvloop_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid unsaferunnnull_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid unsaferunnnullpro_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid fakemeteor_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid fakemeteorpro_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid looppaa2_01_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid loopraa_01_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid TargetCTLoop_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid autosave_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid loopaadied_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid looptargetdied2_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid looptargetdied3_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid looptargetdied4_ObjectID = NiecInvalidObjectGuid;
        public static ObjectGuid looptargetdied_ObjectID = NiecInvalidObjectGuid;

        public static List<ObjectGuid> nonopendgslistObject00 = new List<ObjectGuid>();
        public static List<ObjectGuid> nonopendgslistObject01 = new List<ObjectGuid>();
        public static List<ObjectGuid> nonopendgslistObject02 = new List<ObjectGuid>();
        public static List<ObjectGuid> nonopendgslistObject03 = new List<ObjectGuid>();
        public static List<ObjectGuid> nonopendgslistObject04 = new List<ObjectGuid>();
        public static List<ObjectGuid> nonopendgslistObject05 = new List<ObjectGuid>();
        public static List<ObjectGuid> nonopendgslistObject06 = new List<ObjectGuid>();
        public static List<ObjectGuid> nonopendgslistObject07 = new List<ObjectGuid>();

        public static Dictionary<ulong, List<ObjectGuid>> nonopendgslistObjectAll = new Dictionary<ulong, List<ObjectGuid>>();

        public static
            void TargetCTLoop(Sim obj)
        {
            string backst = "";// = NFinalizeDeath.GetObjectSTLite(obj.ObjectId.mValue);
            while (true)
            {
                Simulator.Sleep(5);
                string rbackst = NFinalizeDeath.GetObjectSTLite01(obj.ObjectId.mValue);
                if (backst == rbackst) { continue; }
                ScriptCore.TaskContext context;
                if (!ScriptCore.TaskControl.GetTaskContext(obj.ObjectId.mValue, true, out context) || context.mFrames == null)
                    continue;

                StringBuilder stringBuilder = new StringBuilder();

                for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
                {
                    ScriptCore.TaskFrame taskFrame = context.mFrames[stack];


                    if (taskFrame.mMethodHandle.Value == IntPtr.Zero)
                        continue;

                    MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                    Type declaringType = methodInfo.DeclaringType;
                    stringBuilder.Append(declaringType.Name);
                    stringBuilder.Append("::");
                    stringBuilder.Append(methodInfo.Name);
                    stringBuilder.Append('\n');
                }
                NiecException.PrintMessagePro("NiecMod\nCall Stack\nSleep: " + context.mSleepTicks + "\n" + stringBuilder.ToString(), true, 1000);
            }
        }

        public static
            void maxmood_command()
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null)
                    continue;

                var sd = item.SimDescription;
                if (sd == null || sd.Household == null)
                    continue;

                if (sd.IsValidDescription && sd.IsValid)
                    NFinalizeDeath.Sim_MaxMood(item);
            }
        }

        public static
            void clsave_command()
        {
            if (!Simulator.CheckYieldingContext(false)) return;
            try
            {
                rallbuff_command(); 
                rallbuff_command();
            }
            catch (Exception)
            { }
            try
            {
                rallirunlist_command();
            }
            catch (Exception)
            { }
            try
            {
                RemoveSafeAllCleanLotData();
            }
            catch (Exception)
            { }
            try
            {
                AllLotCleanUpAndRepair();
            }
            catch (Exception)
            { }
        }

        public static
            void maxmoodloop_command() 
        {
            if (auto_maxmoodloop == NiecInvalidObjectGuid)
            {
                auto_maxmoodloop = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    try
                    {
                        while (true)
                        {
                            for (int i = 0; i < 250; i++) { Simulator.Sleep(tickCount: 0); } Simulator.Sleep(tickCount: 0);

                            try
                            {

                            }
                            catch (ResetException)
                            {
                                throw;
                            }
                            catch
                            {
                                for (int i = 0; i < 500; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                            }
                            maxmood_command();
                        }
                    }
                    finally
                    {
                        NFinalizeDeath.RemoveTaskFromSimulator(ref auto_maxmoodloop);
                    }
                });
            }
            else
            {
                NFinalizeDeath.RemoveTaskFromSimulator(ref auto_maxmoodloop);
            }
        }
        public static
            void dunusedsu_command()
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<SimUpdate>())
            {
                if (item == null)
                {
                    continue;
                }
                var sim = item.mSim;
                if (sim == null || !NFinalizeDeath.GameObjectIsValid(sim.ObjectId.mValue))
                {
                    Simulator.DestroyObject(item.Proxy.ObjectId);
                    if (sim != null)
                    {
                        sim.mSimUpdateId = default(ObjectGuid);
                    }
                }
               
            }
        }

        public static
            void unsafesmcsmcpro_command()
        {
            NiecHelperSituation.kUnsafeSMCNULLSIM = !NiecHelperSituation.kUnsafeSMCNULLSIM;
            NiecException.PrintMessagePro("NHS kUnsafeSMCNULLSIM: " + NiecHelperSituation.kUnsafeSMCNULLSIM, false, 50f);
        }

        public static
            void rtnodark_command()
        {
            if (auto_rtnodark == NiecInvalidObjectGuid)
            {
                auto_rtnodark = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    try
                    {
                        while (true)
                        {
                            Simulator.Sleep (tickCount: 0u);
                            try
                            {
                                UIManager.BlackBackground  (set:    false               );
                                GameUtils.EnableSceneDraw  (enable: true                );
                                UIManager.DarkenBackground (darken: false, force: true  );
                            } 
                            catch (ResetException) { throw; }
                            catch (Exception ex)
                            {
                                ex.trace_ips = null;
                                ex.stack_trace = null;
                                ex.message = "";
                                ex.inner_exception = null;
                            }
                        }
                    }
                    finally
                    {
                        auto_rtnodark = NiecInvalidObjectGuid;
                    }
                });
            }
            else
            {
                NFinalizeDeath.RemoveTaskFromSimulator(ref auto_rtnodark);
            }
        }

        public static
            void AllLotCleanUpAndRepair(bool no_dialog = false, bool force_clean_bill = false)
        {
            var Lots = LotManager.sLots;
            if (Lots == null) {
                if (!GameStates.IsInMainMenuState)
                    niec_std.assert("LotManager.sLots == null");
                return;
            }

            bool ForceCleanBill = force_clean_bill || (!no_dialog && NFinalizeDeath.CheckAccept("Force Clean Bill?"));

            var ActiveLotHome = ForceCleanBill ? null : NFinalizeDeath.ActiveLotHome;
            var CopyLots = new Dictionary<ulong, Lot>(Lots);

            try
            {
                foreach (var itemLot in CopyLots.Values)
                {
                    if (itemLot == null || itemLot.LotId == 0 || itemLot.LotId == ulong.MaxValue) 
                        continue;

                    try {
                        NFinalizeDeath.RepairAllForLot(itemLot);
                        NFinalizeDeath.CleanUpAllForLot(itemLot, ForceCleanBill || ActiveLotHome != itemLot);
                    }
                    catch (StackOverflowException) {
                        throw;
                    }
                    catch (ResetException) {
                        throw;
                    }
                    catch { }
                }
            }
            finally
            {
                CopyLots.Clear();
            }
        }

        public static
           void spnhs_Command()
        {
            if (!IsOpenDGSInstalled) return;
            NiecHelperSituation.b_SafePosNHSTickOnly = !NiecHelperSituation.b_SafePosNHSTickOnly;
            NiecException.PrintMessagePro("NHS SafePosNHSTickOnly: " + NiecHelperSituation.b_SafePosNHSTickOnly, false, 50f);
        }

        public static
           void dreslist_Command()
        {
            var d = NFinalizeDeath.debugRemoveSituationList;
            niec_std.checkf(d);

            new NCopyableTextDialog(d.ToString()).SafeShow("dreslist_Command");

            NFinalizeDeath.debugRemoveSituationList = new StringBuilder();
        }

        public static
            void ustsimall_Command()
        {
            int i = 0;
            foreach (var objSim in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (objSim != null && !NFinalizeDeath.IsAllActiveHousehold_SimObject(objSim))
                {
                    NFinalizeDeath.UnSafeForceErrorTargetSim(objSim);
                }
                i++;
                if (i > 150 && Simulator.CheckYieldingContext(false))
                {
                    i = 0;
                    Simulator.Sleep(0);
                }
            }
        }

        public static
            int setisstsleep_command()
        {
            if (!Simulator.CheckYieldingContext(false))
                goto ret;

            string st = NiecHelperSituation.IsSTAwesomeModFast_Sleep.ToString();
            string stMax = NiecHelperSituation.IsSTAwesomeModFast_SleepMax.ToString();


            string textpos = StringInputDialog.Show(
                "NiecMod: STACoreFast Text", "TickSleep Current: " + st + "\nMaxSleep Current: " + stMax, stMax, 256, StringInputDialog.Validation.None
            );

            if (string.IsNullOrEmpty(textpos)) {
                goto ret;
            }

            int t;
            if (!int.TryParse(textpos, out t))
            {
                goto ret;
            }

            if (t < 0 || t > 0x1000) 
                goto ret;

            NiecHelperSituation.IsSTAwesomeModFast_SleepMax = t;
        ret:return NiecHelperSituation.IsSTAwesomeModFast_SleepMax;
        }

        public static
            void ustsimallloop_Command()
        {
            if (ustsimallloop_ObjectID == NiecInvalidObjectGuid)
            {
                ustsimallloop_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    while (true)
                    {
                        Simulator.Sleep(0);
                        ustsimall_Command();
                    }
                });
            }
            else
            {
                NFinalizeDeath.RemoveTaskFromSimulator(ref ustsimallloop_ObjectID);
            }
        }

        public static
            void alldviewsim_Command()
        {
            int sleep = 0;
            foreach (var previewSim in NFinalizeDeath.SC_GetObjects<CASGeneticsPreviewSim>())
            {
                if (previewSim == null) 
                    continue;
                sleep++;
                if (sleep > 100 && Simulator.CheckYieldingContext(false))
                {
                    sleep=0;
                    Simulator.Sleep(0);
                }
                NFinalizeDeath.ForceDestroyObject(previewSim, false);
            }
        }

        public static
            void allcreatefakeSim_Command(bool playAnimGrimReaper, bool animLoop, bool createGhost, bool oNoWait)
        {
            Simulator.CheckYieldingContext(true);
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null || item.SimDescription == null || ScriptCore.Simulator.Simulator_GetTaskImpl(item.ObjectId.mValue, false) == null) 
                    continue;

                var itemPos = ScriptCore.Objects.Objects_GetPosition(item.ObjectId.mValue);
                if (NFinalizeDeath.Vector3_IsUnsafe(itemPos) || itemPos == NFinalizeDeath.__Vector3_Em)
                    continue;

                var itemFwd = ScriptCore.Objects.Objects_GetForward(item.ObjectId.mValue);

                try
                {
                    createfakesim_command(item.SimDescription, itemPos, itemFwd, false, playAnimGrimReaper, animLoop, createGhost, oNoWait);
                    Simulator.Sleep(0);
                }
                catch (ResetException)
                { throw; }
                catch { }
            }
        }

        public static
            void psloop_Command()
        {
            if (psLoop_ObjectID == NiecInvalidObjectGuid)
            {
                psLoop_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate {
                    while (true)
                    {
                        for (int i = 0; i < 54; i++)
                        {
                            Simulator.Sleep(0);
                        } Simulator.Sleep(0);

                        if (PlumbBob.sSingleton == null) 
                            continue;

                        Sim simObj = psLoop_Sim as Sim;
                        CASGeneticsPreviewSim previewSim = psLoop_Sim as CASGeneticsPreviewSim;

                        //if (simObj == null || PlumbBob.sSingleton == null || simObj.Posture == null || NiecHelperSituation.SimHasBeenDestroyed(simObj))
                        if (simObj != null && simObj.Posture != null && !NiecHelperSituation.SimHasBeenDestroyed(simObj))
                        {
                            PlumbBob.ParentTo(simObj);
                            continue;
                        }
                        if (previewSim != null && !previewSim.HasBeenDestroyed)
                        {
                            NFinalizeDeath.PlumbBob_ParentToPreviewSim(PlumbBob.sSingleton, previewSim);
                            continue;
                        }
                    }
                });
            }
            else
            {
                NFinalizeDeath.RemoveTaskFromSimulator(ref psLoop_ObjectID);
            }
        }

        public static 
            void ishlistbad_Command() 
        {
            if (NotificationManager.Instance != null)
                NiecException.PrintMessagePro("IsHouseholdListBad: " + NFinalizeDeath.IsHouseholdListBad(), false, 50f);
            else new NCopyableTextDialog("IsHouseholdListBad: " + NFinalizeDeath.IsHouseholdListBad()).SafeShow("ishlistbad_Command");
        }

        public static bool unsafeCloopaadied = false;

        public static Sim looptargetdied_data = null;
        public static Sim looptargetdied2_data = null;
        public static bool looptargetdied3_data = false;
        public static Household looptargetdied4_data = null;

        public static
            void looptargetdied_Command()
        {
            if (looptargetdied_ObjectID == NiecInvalidObjectGuid)
            {
                looptargetdied_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    Sim target = HitTargetSim();
                    while (target == null) {
                        Simulator.Sleep(0);
                        target = HitTargetSim();
                    }

                    //do
                    //{
                    //   Simulator.Sleep(0);
                    //    target = HitTargetSim();
                    //}
                    //while(target == null);

                    looptargetdied_data = target;

                    try
                    {
                        while (Simulator.GetProxy(target.ObjectId) != null)
                        {
                            Simulator.Sleep(1);

                            if (!unsafeCloopaadied)
                            {
                                if (NiecHelperSituation.isdgmods)
                                    NFinalizeDeath.SleepTask(170);
                                else 
                                    NFinalizeDeath.SleepTask(65);

                                if ( looppaa2bool)
                                    NFinalizeDeath.SleepTask(550);
                            }
                            var simDesc = target.SimDescription;
                            if (simDesc == null)
                                continue;

                            simDesc.IsGhost = false;
                            simDesc.mDeathStyle = SimDescription.DeathType.Drown;
                        }
                    }
                    finally
                    {
                        looptargetdied_data = null;
                        looptargetdied_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else
            {
                looptargetdied_data = null;
                NFinalizeDeath.RemoveTaskFromSimulator(ref looptargetdied_ObjectID);
            }
        }

        public static
            void loopaadied_Command()
        {
            if (loopaadied_ObjectID == NiecInvalidObjectGuid)
            {
                loopaadied_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    try
                    {
                        while (PlumbBob.Singleton != null)
                        {
                            Simulator.Sleep(1);

                            if (!unsafeCloopaadied)
                            {
                                NFinalizeDeath.SleepTask(400);

                                if (looppaa2bool)
                                    NFinalizeDeath.SleepTask(850);
                            }
                            var simDesc = NFinalizeDeath.SelectedActor_SimDescription;
                            if (simDesc == null)
                                continue;

                            simDesc.IsGhost = false;
                            simDesc.mDeathStyle = SimDescription.DeathType.Drown;
                        }
                    }
                    finally
                    {
                        loopaadied_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else
            {
                NFinalizeDeath.RemoveTaskFromSimulator(ref loopaadied_ObjectID);
            }
        }
        public static
            void looptargetdied2_command()
        {
            if (looptargetdied2_ObjectID == NiecInvalidObjectGuid)
            {
                looptargetdied2_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    Sim target = HitTargetSim();
                    while (target == null)
                    {
                        Simulator.Sleep(0);
                        target = HitTargetSim();
                    }

                    looptargetdied2_data = target;

                    try
                    {
                        while (looptargetdied2_data != null && NFinalizeDeath.GameObjectIsValid(looptargetdied2_data.ObjectId.mValue))
                        {
                            Simulator.Sleep(1);

                            if (!unsafeCloopaadied)
                            {
                                NFinalizeDeath.SleepTask(400);

                                if (looppaa2bool)
                                    NFinalizeDeath.SleepTask(850);
                            }
                            var simDesc = looptargetdied2_data.SimDescription;
                            if (simDesc == null)
                                continue;

                            simDesc.IsGhost = false;
                            simDesc.mDeathStyle = SimDescription.DeathType.Drown;
                        }
                    }
                    finally
                    {
                        looptargetdied2_data = null;
                        looptargetdied2_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else
            {
                looptargetdied2_data = null;
                NFinalizeDeath.RemoveTaskFromSimulator(ref looptargetdied2_ObjectID);
            }
        }
        public static
            void looptargetdied4_command()
        {
            if (looptargetdied4_ObjectID == NiecInvalidObjectGuid)
            {
                looptargetdied4_data = null;
                looptargetdied4_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    try
                    {
                        while (true)
                        {
                            Simulator.Sleep(1);
                            for (int i = 0; i < 250; i++)
                            {
                                Simulator.Sleep(0);
                            }

                            var ah = NFinalizeDeath.ActiveHousehold_AllSimDesc2;
                            if (ah == null)
                                continue;

                            looptargetdied4_data = Household.ActiveHousehold;

                            foreach (var item in ah)
                            {
                                if (item == null) 
                                    continue;

                                if (NiecHelperSituation.ExAA && (item.mSim == PlumbBob.SelectedActor))
                                    continue;

                                item.IsGhost = false;
                                item.mDeathStyle = SimDescription.DeathType.Drown;
                            }
                        }
                    }
                    finally
                    {
                        looptargetdied4_data = null;
                        looptargetdied4_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else
            {
                looptargetdied4_data = null;
                NFinalizeDeath.RemoveTaskFromSimulator(ref looptargetdied4_ObjectID);
            }
        }

        public static
            void looptargetdied3_command()
        {
            if (looptargetdied3_ObjectID == NiecInvalidObjectGuid)
            {
                looptargetdied3_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    try
                    {
                        while (true)
                        {
                            Simulator.Sleep(1);

                            looptargetdied3_data = true;

                            if (!unsafeCloopaadied)
                            {
                                NFinalizeDeath.SleepTask(400);

                                if (looppaa2bool)
                                    NFinalizeDeath.SleepTask(850);
                            }

                            for (int i = 0; i < 4; i++)
                            {
                                var sim = NFinalizeDeath.GetRandomSim();
                                if (sim == null) 
                                    continue;

                                var simDesc = sim.SimDescription;
                                if (simDesc == null)
                                    continue;

                                simDesc.IsGhost = false;
                                simDesc.mDeathStyle = SimDescription.DeathType.Drown;
                            }
                           
                        }
                    }
                    finally
                    {
                        looptargetdied3_data = false;
                        looptargetdied3_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else
            {
                looptargetdied3_data = false;
                NFinalizeDeath.RemoveTaskFromSimulator(ref looptargetdied3_ObjectID);
            }
        }


        internal static 
            bool looppaa2bool = false;

        public static
            void looppaa2_command()
        {
            if (looppaa2_01_ObjectID == NiecInvalidObjectGuid)
            {
                looppaa2_01_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    Sim activeActor = NFinalizeDeath.ActiveActor;
                    Household currentNonNullHousehold = PlumbBob.sCurrentNonNullHousehold;

                    try
                    {
                        while (PlumbBob.Singleton!= null)
                        {
                            looppaa2bool = true;
                            Simulator.Sleep(0);
                            PlumbBob.Singleton.mSelectedActor = ((activeActor != null) ?
                                    NFinalizeDeath.GetRandomSim((Sim test) => test != null && test.Household != activeActor.Household) :
                                NFinalizeDeath.GetRandomSim()) ?? PlumbBob.Singleton.mSelectedActor;
                            PlumbBob.sCurrentNonNullHousehold = Household.ActiveHousehold ?? PlumbBob.sCurrentNonNullHousehold;
                        }
                    }
                    finally
                    {
                        looppaa2bool = false;
                        looppaa2_01_ObjectID = new ObjectGuid(0);
                        if (PlumbBob.Singleton != null)
                        {
                            PlumbBob.Singleton.mSelectedActor = activeActor;
                            PlumbBob.sCurrentNonNullHousehold = currentNonNullHousehold;
                        }
                    }
                });
            }
            else NFinalizeDeath.RemoveTaskFromSimulator(ref looppaa2_01_ObjectID);
        }

        public static IGameObject CustomCObjectOverrides(
            string instanceName, 
            ProductVersion version,
            Vector3 initPos, 
            int level, 
            Vector3 initFwd, 
            System.Collections.Hashtable overrides, 
            Simulator.ObjectInitParameters initData)
        {
            if (instanceName == null) {
                throw new ArgumentNullException("instanceName");
            }

            GlobalFunctions.FillInInitData(initPos, level, initFwd, ref initData);
            IGameObject createObject = GlobalFunctions.CreateObjectInternal(instanceName, version, overrides, initData);

            if (createObject != null)
            {
                GlobalFunctions.CheckForFailure
                    (createObject, "Missing object resource instance " + instanceName + "\nObject ID: " + createObject.ObjectId.ToString());
            }
            return createObject;
        }

        public static void CASGeneticsPreviewSim_PlayAnimPieMenu(CASGeneticsPreviewSim _this, StateMachineClient smc, SimDescription simd)
        {
            if (_this == null)
                throw new NullReferenceException();
            if (simd == null)
                throw new ArgumentNullException("simd");

            if (smc == null)
            {
                smc = StateMachineClient.Acquire(_this.Proxy.ObjectId, "cas_idle", AnimationPriority.kAPUltra, Simulator.CheckYieldingContext(false));
                smc.AddInterest<TraitNames>();
                smc.AddInterest<BuffNames>();
                smc.AddInterest<MoodFlavor>();
                smc.SetActor("x", _this);
                smc.EnterState("x", "standing");
                _this.smc = smc;
            }

            NFinalizeDeath.SimDesc_SMCSetActor(simd, smc, "x");
            smc.RequestState(false, "x", "cas_idle");
        }

        public static
            ObjectGuid createfakesim_command(SimDescription pSimDesc, Vector3? initPos, Vector3? initFwd, bool showWindow, bool playAnimGrimReaper, bool animLoop, bool createGhost, bool oNoWait)
        {
            Simulator.CheckYieldingContext(true);
            var simd = pSimDesc ?? (showWindow ? Create.FindDescOrTargetSimDesc(0, 0, true) : null);
            if (simd != null && simd.IsValidDescription && simd.IsValid && simd.mHairColors != null && NFinalizeDeath.SimDesc_OutfitsIsValid(simd))
            {
                ResourceKey key = simd.GetOutfit(OutfitCategories.Everyday, 0).Key;
                if (key == ResourceKey.kInvalidResourceKey) {
                    return default(ObjectGuid);
                }

                var objectData = new System.Collections.Hashtable(5);

                objectData["simOutfitKey"] = key;
                objectData["scriptClass"] = "Sims3.Gameplay.CAS.CASGeneticsPreviewSim";
                objectData["rigKey"] = CASUtils.GetRigKeyForAgeGenderSpecies(simd.AgeGenderSpecies);
                objectData["enableSimPoseProcessing"] = 1;
                objectData["animationRunsInRealtime"] = 1;

                var parms = new SimInitParameters(simd);
                parms.AddToObjectManager = false;

                var createGameObject = CustomCObjectOverrides
                    ("GameSim",ProductVersion.BaseGame, Vector3.Zero, 0, Vector3.UnitZ, objectData, parms);

                var previewSim = createGameObject as CASGeneticsPreviewSim;
                if (previewSim == null)
                {
                    if (createGameObject != null) {
                        createGameObject.Destroy();
                    }
                    throw new NullReferenceException("previewSim == null");
                }
                if (playAnimGrimReaper)
                {
                    try
                    {
                        StateMachineClient antiNPCReapSoul = null;
                        try
                        {
                            antiNPCReapSoul = StateMachineClient.Acquire(previewSim.ObjectId, "DGSDeath", AnimationPriority.kAPUltraPlus, true);
                        }
                        catch (SacsErrorException)
                        {
                            playAnimGrimReaper = false;
                            goto acquireFailedSMC;
                        }

                        if (antiNPCReapSoul == null)
                        {
                            playAnimGrimReaper = false;
                            goto acquireFailedSMC;
                        }

                        if (!IsOpenDGSInstalled)
                            NFinalizeDeath.StateMachineClient_SetActor(antiNPCReapSoul, "x", previewSim);
                        else
                            antiNPCReapSoul.SetActor("x", previewSim);

                        uint ageHash = 499670524u;
                        uint inBadMoodHash = 3485968198u;
                        uint sexHash = 1341508501u;
                        //uint scriptPostureHash = 2555509350u;
                        uint speciesHash = 3242275675u;

                        antiNPCReapSoul.SetParameter(ageHash, typeof(Sims3.SimIFace.Enums.Age), NFinalizeDeath.GetAgeHashSMC(simd));
                        antiNPCReapSoul.SetParameter(inBadMoodHash, (uint)1668749452);
                        antiNPCReapSoul.SetParameter(sexHash, (uint)((simd.Gender == CASAgeGenderFlags.Male) ? (-1183391106) : (-2090525483)));
                        antiNPCReapSoul.SetParameter(speciesHash, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);

                        //if (simd.IsPet)
                        //{
                        //    antiNPCReapSoul.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                        //}

                        antiNPCReapSoul.EnterState("x", "Enter");
                        antiNPCReapSoul.RequestState(false, "x", "Float");

                        previewSim.smc = antiNPCReapSoul;
                    }
                    catch 
                    {
                        NFinalizeDeath.ForceDestroyObject(previewSim, false);
                        throw;
                    }
                }
            acquireFailedSMC:
                if (!playAnimGrimReaper)
                {
                    try
                    {
                        if (animLoop)
                        {
                            CASGeneticsPreviewSim_PlayAnimPieMenu(previewSim, null, simd);
                        }
                        else
                        {
                            previewSim.SetSpecies(simd.Species);
                            previewSim.SetAge(simd.Age);
                            previewSim.SetIdle();
                        }
                    }
                    catch
                    {
                        NFinalizeDeath.ForceDestroyObject(previewSim, false);
                        throw;
                    }
                }

                bool isReady = false;
                CASUtils.SwapReadyCallback finishedCallback; // = () => isReady = true;
                if (oNoWait) {
                    finishedCallback = () => {};
                }
                else {
                   finishedCallback = () => isReady = true;
                }
                CASUtils.SetOutfitInGameObjectDelayed(key, previewSim.ObjectId, finishedCallback);

                try
                {
                    while (!oNoWait && !isReady)
                    {
                        Simulator.Sleep(0);
                    }
                }
                catch (ResetException)
                {
                    NFinalizeDeath.ForceDestroyObject(previewSim, false);
                    try
                    {
                        throw;
                    }
                    catch (ExecutionEngineException) 
                    {
                        NFinalizeDeath.ThrowResetException(null);
                    }
                    
                }

                if (initPos != null && initPos.HasValue && !NFinalizeDeath.Vector3_IsUnsafe(initPos.Value))
                    previewSim.SetPosition
                        (initPos.Value);

                else previewSim.SetPosition
                    (NFinalizeDeath.Fast_SnapToFloor(ScriptCore.CameraController.Camera_GetTarget()));

                if (initFwd != null && initFwd.HasValue)
                {
                    var fwd = initFwd.Value;
                    if (!NFinalizeDeath.Vector3_IsUnsafe(fwd))
                    {
                        if (fwd != NFinalizeDeath.__Vector3_Em)
                        {
                            previewSim.SetForward
                              (fwd);
                        }
                    }
                }
                previewSim.FadeIn();

                CASUtils.CompleteDelayedModelSwap(previewSim.ObjectId);
                if (createGhost) {
                    var supernaturalData = simd.SupernaturalData;
                    if (supernaturalData != null)
                    {
                        switch (supernaturalData.OccultType)
                        {
                        case Sims3.UI.Hud.OccultTypes.Ghost:
                            CASGhostData casGhostData = supernaturalData as CASGhostData;
                            if (casGhostData != null)
                            {
                                World.ObjectSetGhostState(previewSim.ObjectId, (uint)casGhostData.DeathStyle, 32);
                            }
                            break;
                        case Sims3.UI.Hud.OccultTypes.Vampire:
                            World.ObjectSetVisualOverride(previewSim.ObjectId, eVisualOverrideTypes.Vampire, null);
                            break;
                        case Sims3.UI.Hud.OccultTypes.Genie:
                            World.ObjectSetVisualOverride(previewSim.ObjectId, eVisualOverrideTypes.Genie, null);
                            break;
                        case Sims3.UI.Hud.OccultTypes.Werewolf:
                            World.ObjectSetVisualOverride(previewSim.ObjectId, eVisualOverrideTypes.Werewolf, null);
                            break;
                        }
                    }
                }
                return previewSim.ObjectId;
            }
            else if (showWindow) {
                if (Create.GetErrorFindDescOrTargetSimDesc() != 2)
                    SimpleMessageDialog.Show("NiecMod", "Could not find the SimDesc.");
                else
                    SimpleMessageDialog.Show("NiecMod", "SimDesc is invalid.");
            }
            return default(ObjectGuid);
        }

        public static
            void debugnhsi_command()
        {
            Sim sim = HitTargetSim();
            if (sim != null)
            {
                var nhsI = sim.InteractionQueue.GetHeadInteraction() as NiecHelperSituation.ReapSoul ?? NFinalizeDeath.GetFirstObjectForTaskFrames<NiecHelperSituation.ReapSoul>(sim.ObjectId.mValue);
                if (nhsI != null)
                {
                    if (NotificationManager.sNotificationManager != null && IsVisibleTreatmentsController()) {
                        NiecException.PrintMessagePro("DEBUG NHS ReapSoul: " + nhsI.debug_runtime.ToString()+ "\nDeath Progress: " + nhsI.mDeathProgress.ToString(), false, 100);
                    }
                    else new NCopyableTextDialog("DEBUG NHS ReapSoul: " + nhsI.debug_runtime.ToString() + "\nDeath Progress: " + nhsI.mDeathProgress.ToString()).SafeShow("debugnhsi command");
                    //if (Simulator.CheckYieldingContext(false)) {
                    //    while (UIManager.GetModalWindow() != null)
                    //    {
                    //        Simulator.Sleep(0);
                    //    }
                    //    for (int i = 0; i < 20; i++)
                    //    {
                    //        Simulator.Sleep(0);
                    //    }
                    //    
                    //}
                }
            }
        }

        public static
            void hitloopdied_command()
        {
            if (hitloopdied_ObjectID == NiecInvalidObjectGuid)
            {
                hitloopdied_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    try
                    {
                        while (true)
                        {
                            NFinalizeDeath.SleepTask(20);
                            var targetSim = HitTargetSim();
                            if (targetSim != null)
                            {
                                var simd = targetSim.SimDescription;
                                if (simd != null)
                                {
                                    simd.mDeathStyle = SimDescription.DeathType.Drown;
                                    simd.IsGhost = false;
                                }
                            }
                        }
                    }
                    finally
                    {
                        hitloopdied_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else NFinalizeDeath.RemoveTaskFromSimulator(ref hitloopdied_ObjectID);
        }


        public static
            void hitloopdied2_command()
        {
            if (hitloopdied2_ObjectID == NiecInvalidObjectGuid)
            {
                hitloopdied2_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    try
                    {
                        Sim targetsimLock = HitTargetSim();

                        while (targetsimLock == null) {
                            targetsimLock = HitTargetSim();
                            Simulator.Sleep(0);
                        }

                        ulong targetSimObjectIDLock = targetsimLock.ObjectId.mValue;

                        while (NFinalizeDeath.GameObjectIsValid(targetSimObjectIDLock))
                        {
                            NFinalizeDeath.SleepTask(50);
                            var targetSim = HitTargetSim();
                            if (targetSim == targetsimLock)
                            {
                                var simd = targetSim.SimDescription;
                                if (simd != null)
                                {
                                    simd.mDeathStyle = SimDescription.DeathType.Drown;
                                    simd.IsGhost = false;
                                }
                            }
                        }
                    }
                    finally
                    {
                        hitloopdied2_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else NFinalizeDeath.RemoveTaskFromSimulator(ref hitloopdied2_ObjectID);
        }


        internal static Sim looppaa_SIM = null;

        public static
            void looppaa_Command()
        { 
            looppaaCreateTask_SCTask();
            if (!IsOpenDGSInstalled)
                looppaaCreateTask_SCThreaded();
        }

        internal static
            void looppaaCreateTask_SCThreaded()
        {
            if (looppaa02_ObjectID == NiecInvalidObjectGuid)
            {
                looppaa02_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Threaded, delegate
                {
                    Simulator.Sleep(0);

                    Sim activeActor = NFinalizeDeath.ActiveActor;
                    Household currentNonNullHousehold = PlumbBob.sCurrentNonNullHousehold;

                    if (IsOpenDGSInstalled)
                        looppaa_SIM = activeActor;
                    //TempSetActiveActorAndHousehold te = new TempSetActiveActorAndHousehold();
                    try
                    {
                        //PlumbBob.Singleton.mSelectedActor = NFinalizeDeath.GetRandomSim();
                        while (PlumbBob.Singleton != null)
                        {
                            Simulator.Sleep(0);
                            PlumbBob.Singleton.mSelectedActor = (activeActor != null) ?
                                    NFinalizeDeath.GetRandomSim((Sim test) => test != null && test.Household != activeActor.Household) :
                                NFinalizeDeath.GetRandomSim() ?? PlumbBob.Singleton.mSelectedActor;

                            PlumbBob.sCurrentNonNullHousehold = Household.ActiveHousehold ?? PlumbBob.sCurrentNonNullHousehold;

                            //using (TempSetActiveActorAndHousehold.SetAndRun(te, NFinalizeDeath.GetRandomSim()))
                            //{
                            //    for (int i = 0; i < 3; i++)
                            //    {
                            //        Simulator.Sleep(0);
                            //    }
                            //}
                        }
                        
                    }
                    finally
                    {
                        if (IsOpenDGSInstalled)
                            looppaa_SIM = null;
                        looppaa02_ObjectID = new ObjectGuid(0);
                        if (PlumbBob.Singleton != null)
                        {
                            PlumbBob.Singleton.mSelectedActor = activeActor;
                            PlumbBob.sCurrentNonNullHousehold = currentNonNullHousehold;
                        }
                    }
                });
            }
            else
            {
                NFinalizeDeath.RemoveTaskFromSimulator(ref looppaa02_ObjectID);
            }
        }

        internal static
            void looppaaCreateTask_SCTask()
        {
            if (looppaa_ObjectID == NiecInvalidObjectGuid)
            {
                looppaa_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    Sim activeActor = NFinalizeDeath.ActiveActor;
                    if (IsOpenDGSInstalled)
                    looppaa_SIM = activeActor;
                    //TempSetActiveActorAndHousehold te = new TempSetActiveActorAndHousehold();
                    try
                    {
                        //PlumbBob.Singleton.mSelectedActor = NFinalizeDeath.GetRandomSim();
                        while (PlumbBob.Singleton != null)
                        {
                            NFinalizeDeath.SleepTask(IsOpenDGSInstalled ? 0u : 20u);
                            PlumbBob.Singleton.mSelectedActor = (activeActor != null) ? 
                                    NFinalizeDeath.GetRandomSim((Sim test) => test != null && test.Household != activeActor.Household) :
                                NFinalizeDeath.GetRandomSim() ?? PlumbBob.Singleton.mSelectedActor;
                            //using (TempSetActiveActorAndHousehold.SetAndRun(te, NFinalizeDeath.GetRandomSim()))
                            //{
                            //    for (int i = 0; i < 3; i++)
                            //    {
                            //        Simulator.Sleep(0);
                            //    }
                            //}
                        }
                    }
                    finally
                    {
                        if (IsOpenDGSInstalled)
                            looppaa_SIM = null;
                        looppaa_ObjectID = new ObjectGuid(0);
                        if ( PlumbBob.Singleton != null)
                            PlumbBob.Singleton.mSelectedActor = activeActor;
                    }
                });
            }
            else
            {
                NFinalizeDeath.RemoveTaskFromSimulator(ref looppaa_ObjectID);
            }
        }

        public static
            void RemoveSafeAllCleanLotData()
        {
            var lots = LotManager.sLots;
            if (lots == null) 
                return;

            if (!IsOpenDGSInstalled)
            {
                var worldLot = LotManager.GetWorldLot();
                foreach (var item in NFinalizeDeath.SC_GetObjects<GameObject>())
                {
                    if (item == null) continue;
                    if (item.mLotCurrent != null) 
                        continue;
                    item.mLotCurrent = worldLot;
                }
            }
           
            foreach (Lot itemLot in lots.Values)
            {
                if (itemLot == null) continue;
                var savedData = itemLot.mSavedData;
                if (savedData == null) continue;
                if (savedData.mReactions != null)
                {
                    foreach (var item in savedData.mReactions.ToArray())
                    {
                        try
                        {

                            if (item == null) continue;
                            item.Dispose();

                        }
                        catch (StackOverflowException) { break; }
                        catch (ResetException) { throw; }
                        catch { }
                    }
                    NFinalizeDeath.List_FastClearEx(ref savedData.mReactions);
                }
                if (savedData.mBroadcastersWithSims != null)
                {
                    foreach (var item in savedData.mBroadcastersWithSims.ToArray())
                    {
                        try
                        {

                            if (item == null)
                                continue;
                            item.Dispose();

                        }
                        catch (StackOverflowException) { break; }
                        catch (ResetException) { throw; }
                        catch { }
                    }
                    NFinalizeDeath.List_FastClearEx(ref savedData.mBroadcastersWithSims);
                }
            }
        }

        public static
            string DEBUG_ETCount()
        {
            var a = Sims3.Gameplay.EventSystem.EventTracker.sInstance;
            if (a == null) 
                return null;

            string debugtext = "DET\n";

            var aa = a.mActiveList;
            var ab = a.mAddList;
            var ac = a.mRemoveList;

            if (aa != null) {
                debugtext += "Active List Count: " + aa.Count + "\n";
            } else {
                debugtext += "Active List NULL!\n";
            }

            if (ab != null) {
                debugtext += "Add List Count: " + ab.Count + "\n";
            } else {
                debugtext += "Add List NULL!\n";
            }

            if (ac != null) {
                debugtext += "Remove List Count: " + ac.Count + "\n";
            } else {
                debugtext += "Remove List NULL!\n";
            }

            if (NotificationManager.Instance != null) {
                NiecException.PrintMessagePro(debugtext, false, 100);
            }
            else {
                new NCopyableTextDialog(debugtext).SafeShow("DEBUG_ETCount()");
            }
            return debugtext;
        }

        public static
           void ResetEventTracker()
        {
            if (!GameStates.IsInWorld()) 
                return;

            Sims3.Gameplay.EventSystem.EventTracker.PreWorldShutdown();
            Sims3.Gameplay.EventSystem.EventTracker.PreWorldStartup();
        }
        public static
           void FastCodeEventTrackerV2()
        {
            var i = Sims3.Gameplay.EventSystem.EventTracker.Instance;
            if (i == null)
                return;

            i.mActiveList = new Stack<List<Sims3.Gameplay.EventSystem.EventListener>>();
            i.mAddList = new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();
            i.mRemoveList = new List<Pair<List<Sims3.Gameplay.EventSystem.EventListener>, Sims3.Gameplay.EventSystem.EventListener>>();
        }
        public static 
            bool ShuoldOrgHousehold(Household orghousehold)
        {
            if (orghousehold == null) 
                return false;
            if (IsOpenDGSInstalled) {
                if (orghousehold == Household.ActiveHousehold) return false;
                if (orghousehold == Household.sNpcHousehold) return false;
            }
            else {
                if (NFinalizeDeath.IsSpecialHousehold(orghousehold)) return false;
                if (orghousehold == (Household.sNpcHousehold ?? Household.NpcHousehold)) return false;
                if (orghousehold.LotHome == null) return false;
            }
            return true;
        }

        public static
            object CopyTaskContext(object taskContext, bool debug_Assert)
        {
            if (!(taskContext is ScriptCore.TaskContext)) throw new ArgumentException("CopyTaskContext(): taskContext is not ScriptCore.TaskContext", "taskContext");
            var context = (ScriptCore.TaskContext)taskContext;
            ScriptCore.TaskFrame[] frames = context.mFrames;
            if (frames == null)
            {
                if (debug_Assert)
                    NFinalizeDeath.Assert("CopyTaskContext(): frames == NULL");
                throw new ArgumentException("CopyTaskContext(): context.mFrames == NULL", "taskContext");
            }

            ScriptCore.TaskContext copyContext = new ScriptCore.TaskContext();
            try
            {
                copyContext.mYieldedMethodHandle = context.mYieldedMethodHandle;

                ScriptCore.TaskFrame[] copyFrames = null;
                try
                {
                    copyFrames = new ScriptCore.TaskFrame[frames.Length];
                    for (int i = 0; i < frames.Length; i++)
                    {
                        copyFrames[i].mMethodHandle = frames[i].mMethodHandle;
                        copyFrames[i].mMethodChecksum = frames[i].mMethodChecksum;
                        copyFrames[i].mIPOffset = frames[i].mIPOffset;
                        copyFrames[i].mSPOffset = frames[i].mSPOffset;
                        copyFrames[i].mVTSPOffset = frames[i].mVTSPOffset;
                        copyFrames[i].mRetValOffset = frames[i].mRetValOffset;
                        copyFrames[i].mArgsOffset = frames[i].mArgsOffset;
                        copyFrames[i].mThisObj = frames[i].mThisObj;
                        if (frames[i].mFields != null)
                            copyFrames[i].mFields = (ScriptCore.TaskFieldInfo[])frames[i].mFields.Clone();
                        if (frames[i].mEvalStack != null)
                            copyFrames[i].mEvalStack = (object[])frames[i].mEvalStack.Clone();
                    }
                }
                catch (Exception te)
                {
                    NiecException.WriteLog(te.ToString());
                    NFinalizeDeath.Assert("CopyTaskContext: TargetSite: " + te.TargetSite + "\nSource: " + te.Source);
                    copyFrames = null;
                }


                copyContext.mFrames = copyFrames ?? (ScriptCore.TaskFrame[])frames.Clone();
                copyContext.mSleepTicks = context.mSleepTicks;
                if (context.mYieldCallback != null)
                    copyContext.mYieldCallback = (Delegate)context.mYieldCallback.Clone();
                copyContext.mNativeYieldCall = context.mNativeYieldCall;
            }
            catch (Exception ex)
            {
                NiecException.WriteLog(ex.ToString());
                NFinalizeDeath.Assert("CopyTaskContext(): failed\nTargetSite: " + ex.TargetSite + "\nSource: " + ex.Source);
            }
            return copyContext;
        }
        public static object testfastcode01_command_data = null;
        public static
            void testfastcode01_command()
        {
            NFinalizeDeath.FixUpHouseholdListObjects(true);
            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
            {
                NFinalizeDeath.RemoveNullForHouseholdMembers(item);
            }

            string p = null;

            var stopWatch = StopWatch.Create(StopWatch.TickStyles.Seconds);
            if (stopWatch == null)
            {
                NFinalizeDeath.Assert("StopWatch == null");
                return;
            }
            var pList = NFinalizeDeath.SC_GetObjects<Household>();
            stopWatch.Reset();
            stopWatch.Start();

            try {

            // {
            for (int i = 0; i < 2200; i++)
            {
                foreach (var item in pList)
                {
                    //foreach (var unused in item.AllActors) { }
                    var unused = item.AllActors;
                }
            }

            p = "Household's AllActors Test Fast Code()" + "\nTotal time in seconds: " + stopWatch.GetElapsedTimeFloat();
            stopWatch.Restart();
            // }

            // {
            for (int i = 0; i < 2200; i++)
            {
                foreach (var item in pList)
                {
                    var unused = item.Sims;
                    var unused1 = item.Pets;
                }
            }

            p += "\n\nHousehold's Sims and Pets Test Fast Code()" + "\nTotal time in seconds: " + stopWatch.GetElapsedTimeFloat();
            stopWatch.Restart();
            // }

            // {
            for (int i = 0; i < 2200; i++)
            {
                foreach (var item in pList)
                {
                    //foreach (var unused in item.AllActors) { }
                    var unused = item.Name;
                }
            }

            p += "\n\nHousehold's Name Test Fast Code()" + "\nTotal time in seconds: " + stopWatch.GetElapsedTimeFloat();
            var simdesclist = NFinalizeDeath.UpdateNiecSimDescriptions(true, false, true).ToArray();
            stopWatch.Restart();
            // }

            // {
            for (int i = 0; i < 2200; i++)
            {
                foreach (var item in simdesclist)
                {
                    var unused0 = item.FirstName;
                    var unused1 = item.LastName;
                }
            }

            p += "\n\nFirstName and LastName Test Fast Code()" + "\nTotal time in seconds: " + stopWatch.GetElapsedTimeFloat();
            stopWatch.Restart();
            // }

            // {
            for (int i = 0; i < 2200; i++)
            {
                foreach (var item in simdesclist)
                {
                    var unused = item.FullName;
                }
            }

            p += "\n\nFullName Test Fast Code()" + "\nTotal time in seconds: " + stopWatch.GetElapsedTimeFloat();
            stopWatch.Stop();
            // }

            } catch {}

            stopWatch.Dispose();
            stopWatch = null;

            new NCopyableTextDialog(p).SafeShow("testfastcode01 command");
        }

        public static
            object csc_command()
        {
            GameObject objectObject = HitTargetGameObject();
            if (objectObject != null)
            {

                ScriptCore.TaskContext context;
                if (!ScriptCore.TaskControl.GetTaskContext(objectObject.ObjectId.mValue, true, out context) || context.mFrames == null)
                    return null;

                //ScriptCore.TaskContext copyContext = new ScriptCore.TaskContext();
                //
                //try
                //{
                //    copyContext.mYieldedMethodHandle = context.mYieldedMethodHandle;
                //
                //    ScriptCore.TaskFrame[] frames = context.mFrames;
                //    if (frames == null)
                //    {
                //        NFinalizeDeath.Assert("csc_command(): frames == NULL");
                //        return null;
                //    }
                //    ScriptCore.TaskFrame[] copyFrames = null;
                //    try
                //    {
                //        copyFrames = new ScriptCore.TaskFrame[frames.Length];
                //        for (int i = 0; i < frames.Length; i++)
                //        {
                //            copyFrames[i].mMethodHandle = frames[i].mMethodHandle;
                //            copyFrames[i].mMethodChecksum = frames[i].mMethodChecksum;
                //            copyFrames[i].mIPOffset = frames[i].mIPOffset;
                //            copyFrames[i].mSPOffset = frames[i].mSPOffset;
                //            copyFrames[i].mVTSPOffset = frames[i].mVTSPOffset;
                //            copyFrames[i].mRetValOffset = frames[i].mRetValOffset;
                //            copyFrames[i].mArgsOffset = frames[i].mArgsOffset;
                //            copyFrames[i].mThisObj = frames[i].mThisObj;
                //            if (frames[i].mFields != null)
                //                copyFrames[i].mFields = (ScriptCore.TaskFieldInfo[])frames[i].mFields.Clone();
                //            if (frames[i].mEvalStack != null)
                //                copyFrames[i].mEvalStack = (object[])frames[i].mEvalStack.Clone();
                //        }
                //    }
                //    catch (Exception te)
                //    {
                //        NiecException.WriteLog(te.ToString());
                //        NFinalizeDeath.Assert("copyFrames: TargetSite: " + te.TargetSite + "\nSource: " + te.Source);
                //        copyFrames = null;
                //    }
                //
                //
                //    copyContext.mFrames = copyFrames ?? (ScriptCore.TaskFrame[])frames.Clone();
                //    copyContext.mSleepTicks = context.mSleepTicks;
                //    if (context.mYieldCallback != null)
                //        copyContext.mYieldCallback = (Delegate)context.mYieldCallback.Clone();
                //    copyContext.mNativeYieldCall = context.mNativeYieldCall;
                //}
                //catch (Exception ex)
                //{
                //    NiecException.WriteLog(ex.ToString());
                //    NFinalizeDeath.Assert("csc_command(): failed\nTargetSite: " + ex.TargetSite + "\nSource: " + ex.Source);
                //}
                var copyContext = (ScriptCore.TaskContext)CopyTaskContext(context, true);
                //NContext ncontext = new NContext();
                //ncontext.TaskContext = copyContext;
                //
                //
                //IntPtr zero = new IntPtr(0);
                //
                //ScriptCore.TaskFieldReference tempFieldRef = default(ScriptCore.TaskFieldReference);
                //
                //
                //var tempFieldData = new List<object>();
                //
                //
                //
                //for (int istackindex = copyContext.mFrames.Length - 1; istackindex >= 0; istackindex--)
                //{
                //    ScriptCore.TaskFrame istackindex_taskFrame = copyContext.mFrames[istackindex];
                //    tempFieldRef.mFrameIndex = istackindex;
                //    if (istackindex_taskFrame.mMethodHandle.Value == zero)
                //        continue;
                //
                //    MethodInfo methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(istackindex_taskFrame.mMethodHandle);
                //    if (methodInfo == null)
                //    {
                //        NFinalizeDeath.Assert("csc_command(): methodInfo == null\nistackindex:" + istackindex);
                //        continue;
                //    }
                //
                //    ParameterInfo[] parameters = methodInfo.GetParameters();
                //    if (parameters == null)
                //    {
                //        NFinalizeDeath.Assert("csc_command(): parameters == null\nistackindex:" + istackindex);
                //        continue;
                //    }
                //
                //    for (int iparameters = 0; iparameters < parameters.Length; iparameters++)
                //    {
                //        tempFieldRef.mFieldIndex = iparameters;
                //        var objfild = ScriptCore.TaskControl.GetFieldValue(objectObject.ObjectId.mValue, tempFieldRef);
                //        tempFieldData.Add(objfild);
                //    }
                //}
                //
                //
                //
                //if (ListCollon.NContexts == null)
                //    ListCollon.NContexts = new List<NContext>();
                //
                //ncontext.FieldData = tempFieldData.ToArray();
                //tempFieldData.Clear();
                //
                //ListCollon.NContexts.Add(ncontext);

                GetUnSafeContextList<ScriptCore.TaskContext>().Add(copyContext);

                return copyContext;
            } 
            return null;
        }
        public static // unprotected mono mscorlib 
            void clc_command()
        {
            GameObject objectObject = HitTargetGameObject();
            if (objectObject != null)
            {
                if (GetUnSafeContextList<ScriptCore.TaskContext>().Count == 0)
                    return;
                Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate{
                ScriptCore.TaskContext context;
                if (!ScriptCore.TaskControl.GetTaskContext(objectObject.ObjectId.mValue, false, out context))
                    return;

                var scriptProxy = NFinalizeDeath.GetProxyWithoutSimIFace(objectObject);
                if (scriptProxy == null) 
                    return;

                string str = StringInputDialog.Show (
                    "NiecMod",
                    "clc_command()\nCount: " + GetUnSafeContextList<ScriptCore.TaskContext>().Count,
                    "0",
                    StringInputDialog.Validation.None
                );

                if (NFinalizeDeath.IsNullOrEmpty(str)) 
                    return;

                int ix;
                int.TryParse(
                       str,
                       out ix
                );

                //if (ix < 0 || ix > GetUnSafeContextList<ScriptCore.TaskContext>().Count)
                //{
                //    SimpleMessageDialog.Show("NiecMod", "clc_command():\nresult is out of range.");
                //    return;
                //}
                //ix -= 1;
                if ((uint)ix >= (uint)GetUnSafeContextList<ScriptCore.TaskContext>().Count)
                {
                    SimpleMessageDialog.Show("NiecMod", "clc_command():\nresult is out of range.");
                    return;
                }
                ScriptCore.TaskContext ctask;
                try
                {
                    ctask = GetUnSafeContextList<ScriptCore.TaskContext>()[ix];
                }
                catch (Exception ex)
                {
                    ex.stack_trace = null;
                    ex.trace_ips = null;
                    ex.message = "";
                    throw new NotSupportedException("failed: Exception!");
                }

                if (NFinalizeDeath.CheckAccept("Info?"))
                {
                    NiecException.WriteLog(NFinalizeDeath.TaskContext_GetToString(ctask));
                    NiecException.PrintMessagePro("clc_command(): Show Script Error File :)", false, 10);
                    return;
                }

                //GetUnSafeContextList<ScriptCore.TaskContext>().RemoveAt(ix);
                if (scriptProxy.ExecuteType == ScriptExecuteType.None) {
                    scriptProxy.mExecuteType = ScriptExecuteType.Threaded;
                }

                if (ScriptCore.TaskControl.SetTaskContext(objectObject.ObjectId.mValue, ref ctask))
                {
                    NiecException.PrintMessagePro("clc_command(): Done", false, 10);
                }
                else
                {
                    NiecException.PrintMessagePro("clc_command(): Failed", false, 10);
                }

                });
                if (objectObject.ObjectId == Simulator.CurrentTask)
                    Simulator.Sleep(100);
            }
        }
        public static // unprotected mono mscorlib 
            void clc2_command()
        {
            GameObject objectObject = HitTargetGameObject();
            if (objectObject != null)
            {
                if (niec_std.list_nonnull_item_count_int32(GCKeepGameCrash) == 0)
                    return;
                Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    niec_std.mono_runtime_install_handlers();
                    ScriptCore.TaskContext context;
                    if (!ScriptCore.TaskControl.GetTaskContext(objectObject.ObjectId.mValue, false, out context))
                        return;

                    var scriptProxy = NFinalizeDeath.GetProxyWithoutSimIFace(objectObject);
                    if (scriptProxy == null)
                        return;

                    string str = StringInputDialog.Show(
                        "NiecMod",
                        "clc_command()\nCount: " + niec_std.list_nonnull_item_count_int32(GCKeepGameCrash),
                        "0",
                        StringInputDialog.Validation.None
                    );

                    if (NFinalizeDeath.IsNullOrEmpty(str))
                        return;

                    int ix;
                    int.TryParse(
                           str,
                           out ix
                    );

                    //if (ix < 0 || ix > GetUnSafeContextList<ScriptCore.TaskContext>().Count)
                    //{
                    //    SimpleMessageDialog.Show("NiecMod", "clc_command():\nresult is out of range.");
                    //    return;
                    //}
                    //ix -= 1;
                    if ((uint)ix >= niec_std.list_nonnull_item_count_int32(GCKeepGameCrash))
                    {
                        SimpleMessageDialog.Show("NiecMod", "clc_command():\nresult is out of range.");
                        return;
                    }
                    ScriptCore.TaskContext ctask;
                    try
                    {
                        ctask = (ScriptCore.TaskContext)GCKeepGameCrash._items[ix];
                    }
                    catch (Exception ex)
                    {
                        ex.stack_trace = null;
                        ex.trace_ips = null;
                        ex.message = "";
                        throw new NotSupportedException("failed: Exception!");
                    }

                    if (NFinalizeDeath.CheckAccept("Info?"))
                    {
                        NiecException.WriteLog(NFinalizeDeath.TaskContext_GetToString(ctask));
                        NiecException.PrintMessagePro("clc2_command(): Show Script Error File :)", false, 10);
                        return;
                    }

                    //GetUnSafeContextList<ScriptCore.TaskContext>().RemoveAt(ix);
                    if (scriptProxy.ExecuteType == ScriptExecuteType.None)
                    {
                        scriptProxy.mExecuteType = ScriptExecuteType.Threaded;
                    }

                    if (ScriptCore.TaskControl.SetTaskContext(objectObject.ObjectId.mValue, ref ctask))
                    {
                        NiecException.PrintMessagePro("clc2_command(): Done", false, 10);
                    }
                    else
                    {
                        NiecException.PrintMessagePro("clc2_command(): Failed", false, 10);
                    }

                });
                if (objectObject.ObjectId == Simulator.CurrentTask)
                    Simulator.Sleep(100);
            }
        }
        //internal static
        //    List<Type> GetUnSafeContextList<Unused, Type>(_NI unused_P)
        //{
        //    //if (Assembly.GetExecutingAssembly() == Assembly.GetCallingAssembly() && unused_P == null)
        //    {
        //        object.Equals(null, _niecinternal<Unused>.data03);
        //        if (_niecinternal<List<Type>>.data01 == null)
        //            _niecinternal<List<Type>>.data01 = new List<Type>();
        //        return _niecinternal<List<Type>>.data01;
        //    }
        //    //else throw new NotImplementedException();
        //}

        internal static
            List<Type> GetUnSafeContextList<Type>()
        {
            if (Assembly.GetExecutingAssembly() == Assembly.GetCallingAssembly())
            {
                if (_niecinternal<List<Type>>.data01 == null)
                    _niecinternal<List<Type>>.data01 = new List<Type>();
                return _niecinternal<List<Type>>.data01;
            }
            else return null;
        }

        public static void dkeyname_command() // Unlocalized String?
        {
            var st = "";
            var isMale = false;
            var sim = HitTargetSim();
            var worldName = !GameStates.IsInWorld() ? WorldName.Undefined : GameUtils.GetCurrentWorld();

            if (worldName == WorldName.Undefined)
                worldName = WorldName.SunsetValley;

            if (sim != null && sim.mSimDescription != null)
            {
                st += "Sim Bio: " + sim.mSimDescription.mBio;
                st += "\n\n\nSim Bio2: " + StringTable.GetLocalizedString(sim.mSimDescription.mBio ?? "");

                st += "\n\n\nSim FName: " + sim.mSimDescription.mFirstName;
                st += "\nSim LName: " + sim.mSimDescription.mLastName;

                st += "\nSim FName2: " + StringTable.GetLocalizedString(sim.mSimDescription.mFirstName ?? "");//sim.mSimDescription.FirstName;
                st += "\nSim LName2: " + StringTable.GetLocalizedString(sim.mSimDescription.mLastName ?? "");// sim.mSimDescription.LastName;

                var simHousehold = sim.Household;
                if (simHousehold != null)
                {
                    st += "\n\nHousehold Name: " + simHousehold.mName;
                    st += "\nHousehold Name2: " + StringTable.GetLocalizedString(simHousehold.mName ?? ""); //simHousehold.Name;
                }

                isMale = sim.mSimDescription.IsMale;

                if (sim.mSimDescription.IsPet)
                {
                    st += "\n\nGive PFName: " + SimUtils.GetRandomPetName(isMale, sim.mSimDescription.Species, true);
                    st += "\nGive PLName: " + SimUtils.GetRandomPetName(isMale, sim.mSimDescription.Species, false);

                    st += "\nSpecies: " + sim.mSimDescription.Species.ToString();
                }
            }

            st += (st == "" ? "Give FName: " : "\n\nGive FName: ") + SimUtils.GetRandomGivenName(isMale, worldName);
            st += "\nGive LName: " + SimUtils.GetRandomFamilyName(worldName);

            st += "\n\nWorld Name: " + worldName.ToString();

            new NCopyableTextDialog(st).SafeShow("dkeyname command");
        }

        public static void pdats_command()
        {
            var sim = HitTargetSim();
            if (sim != null)
            {
                PlayDeathAnimTargetSim(sim, SimDescription.DeathType.OldAge, Simulator.CheckYieldingContext(false));
            }
        }
        /// <summary>
        /// Create Death Anim
        /// </summary>
        /// <param name="targetSim">Target Sim</param>
        /// <param name="simDeathType">Death Type</param>
        /// <param name="yield">Yield</param>
        /// <returns>StateMachineClient</returns>
        public static
            StateMachineClient PlayDeathAnimTargetSim(Sim targetSim, SimDescription.DeathType simDeathType, bool yield)
        {
            if (Urnstone.DeathAnimns == null) 
                return null;

            if (yield)
                Simulator.CheckYieldingContext(true);

            if (targetSim == null || targetSim.mSimDescription == null)
                throw new ArgumentNullException("targetSim","targetSim == null || targetSim.mSimDescription == null");

            if (targetSim.ObjectId.mValue == 0)
                return null;

            var smc = StateMachineClient.Acquire(targetSim, "DeathTypes");
            if (smc == null) 
                return null;

            smc.SetActor("x", targetSim);

            if (NFinalizeDeath.StateMachineClient_SimIsPet(targetSim))
                smc.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);

            if (NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(targetSim))
                smc.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);

            if (simDeathType == SimDescription.DeathType.OldAge && targetSim.SimDescription.Age != CASAgeGenderFlags.Elder)
                smc.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.elder);

            smc.EnterState("x", "Enter");

            if (yield)
                NFinalizeDeath.CheckYieldingContext();

            if (!NiecHelperSituation.___bOpenDGSIsInstalled_)
            {
                NFinalizeDeath.SMCIsValid("x", true, smc);
                NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, smc);
                NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, smc);
                NFinalizeDeath.SMCIsValid("x", true, smc);
            }

            smc.RequestState(yield, "x", Urnstone.DeathAnimns[(uint)simDeathType]);

            if (yield)
            {
                NFinalizeDeath.CheckYieldingContext();
                smc.RequestState(yield, "x", "Exit");
            }

            return smc;
        }

        public static
            void saatwo_command()
        {
            NPlumbBob.sCurrentSimTwo = HitTargetSim();
        }

        public static
           void rwrallsim_command()
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null)
                    continue;
                try
                {
                    var simr = item.SimRoutingComponent;
                    if (simr == null) 
                        continue;
                    if (simr.mWalkStyleRequests != null)
                    {
                        simr.mWalkStyleRequests.Clear();
                        simr.InitializeWalkStylePriorities();
                    }
                    else { simr.InitializeWalkStylePriorities(); }
                }
                catch (StackOverflowException)
                { throw; }
                catch (ResetException)
                { throw; }
                catch { }
                
            }
        }

        public static
            void chouselotnosall_command()
        {
            var lots = LotManager.sLots;
            if (lots == null)
                return;
            foreach (var item in lots.Values)
            {
                if (item == null || item.Household != null || item is WorldLot)
                    continue;

                var h = Create.CreateActiveHouseholdAndActiveActor(item, true);
                if (h != null)
                {
                    var packageFile = Commom.Proxies.HouseholdContentsProxy.NExportHousehold(Bin.Singleton, h, false, false, true, false);
                    NiecException.PrintMessagePro("chouselotnosall: " + packageFile, false, float.MaxValue);
                }
            }
        }

        public static
            void chouselotnos_command()
        {
            var lot = NFinalizeDeath.GetCameraTargetLotOrTargetLot();
            if (lot == null || lot.Household != null || lot is WorldLot)
                return;

            var h = Create.CreateActiveHouseholdAndActiveActor(lot, true);
            if (h != null)
            {
                var packageFile = Commom.Proxies.HouseholdContentsProxy.NExportHousehold(Bin.Singleton, h, false, false, true, false);
                //niec_native_func.OutputDebugString("chouselotnos: " + packageFile);
                NiecException.PrintMessagePro("chouselotnos: " + packageFile, false, float.MaxValue);
            }
        }

        public static
            void wrallsim_command() 
        {
            if (NFinalizeDeath.SC_GetObjects<Sim>().Length == 0) 
                return;

            int i = NFinalizeDeath.GetIntDialog("WalkStyle Code?");
            if (i == -101) 
                return;
            else if (i == -102) {
                NFinalizeDeath.Show_MessageDialog("text error."); 
                return;
            }

            Sim.WalkStyle vWalkStyle = (Sim.WalkStyle)i;
            if (!Enum.IsDefined(typeof(Sim.WalkStyle), vWalkStyle))
            {
                NFinalizeDeath.Show_MessageDialog("result is undefined."); 
                return;
            }

            if (!NFinalizeDeath.CheckAccept("Are you sure\nAll Sim Set WalkStyle: " + vWalkStyle)) 
                return;

            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null) 
                    continue;

                try
                {
                    item.RequestWalkStyle(vWalkStyle);
                }
                catch (StackOverflowException)
                { throw; }
                catch (ResetException)
                { throw; }
                catch { }
            }
        }

        public static int testFuncCPUC = 1350;
        public static Vector3 xverTest = new Vector3(0, 0, 0);
        public static void testFuncCPU() {
            Simulator.CheckYieldingContext(true);
            Vector3 verTest = new Vector3(0, 0, 0);
            while (true) {
                Simulator.Sleep(0);
#if !RemoveCode_ACorewIsnstalled
                if (!NiecHelperSituation.__acorewIsnstalled__) 
                    continue;
#endif
                if (extestcpudata)
                    continue;

                int maxCount = MathUtils.Clamp(testFuncCPUC, 1, 2000);
                for (int i = 0; i < maxCount; i++)
                {
                    ulong _ID = NFinalizeDeath.GetRandomID();
                    Sim.OneSimActive = false;
                    var simDesc = Create.NiecNullSimDescription();
                    simDesc.mSenderNucleusID = (long)_ID + (long)simDesc.SimDescriptionId;

                    //verTest.Set (
                    //    simDesc.mAlienDNAPercentage / NFinalizeDeath.MathU_CatMullRom(0x5 * simDesc.mAlienDNAPercentage) * maxCount,
                    //    0x10 + 0xFF * simDesc.mAlienDNAPercentage * (verTest.GetHashCode() >> simDesc.mAlienDNAPercentage.GetHashCode() + _ID.GetHashCode()),
                    //    i << (i + 0xFFAA / maxCount & simDesc.mSenderNucleusID.GetHashCode())
                    //);

                    verTest.Set (
                        xverTest.x + (simDesc.mAlienDNAPercentage / NFinalizeDeath.MathU_CatMullRom(0x5 * simDesc.mAlienDNAPercentage) * maxCount) - i,
                        xverTest.y + i + (0x10 + 0xFF * simDesc.mAlienDNAPercentage * (verTest.GetHashCode() + _ID.GetHashCode())),
                        xverTest.z + (i << (i + 0xFFAA / maxCount & simDesc.mSenderNucleusID.GetHashCode()))
                    );

                    if (NFinalizeDeath.Vector3_Is_NAN_Or_Zero(verTest) || NFinalizeDeath.Vector3_IsUnsafe(verTest))
                    {
                        NFinalizeDeath.CheckMorun();
                        NFinalizeDeath.ResetError();
                    }
                }
            }
        }
        public static void vative_auto_nullp(WindowBase sender, UIEventArgs args)
        {
            foreach (var ActorFor in NFinalizeDeath.SC_GetObjects<Sim>())
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
        }
        public static void SetFiendDGSSimIFace(bool is_unsafe_error, bool is_force_error, bool mthrow_on_error)
        {
            //try
            //{
            var tStateMachineClient = typeof(Sims3.SimIFace.StateMachineClient);
            if (tStateMachineClient != null)
            {
                FieldInfo f;
                try
                {
                    f = tStateMachineClient.GetField("isunsafeerror", BindingFlags.Static | BindingFlags.Public);
                    if (f != null)
                    {
                        f.SetValue(null, is_unsafe_error);
                    }
                }
                catch (Exception)
                { if (mthrow_on_error) throw; }

                try
                {
                    f = tStateMachineClient.GetField("isforceerror", BindingFlags.Static | BindingFlags.Public);
                    if (f != null)
                    {
                        f.SetValue(null, is_force_error);
                    }
                }
                catch (Exception)
                { if (mthrow_on_error) throw; }
            }
            //}
            //catch (Exception)
            //{ if (mthrow_on_error) throw; }

        }

        public static Dictionary<string, int> cacheGetIntPetName = new Dictionary<string, int>();
        public static int GetIntPetName(bool male, CASAgeGenderFlags species, bool firstName)
        {
            try
            {
                int maxValue;
                //string obj = firstName ? (male ? "/MaleName:Name" : "/FemaleName:Name") : "/FamilyName:Name";
                //string key = "Gameplay/SimNames/Pets/" + species + obj;

                string key = "Gameplay/SimNames/Pets/" + species + (firstName ? (male ? "/MaleName:Name" : "/FemaleName:Name") : "/FamilyName:Name");

                if (cacheGetIntPetName.TryGetValue(key ?? "", out maxValue))
                    return maxValue;

                string entryKey = ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(key ?? "");
                string valuestr;

                if (entryKey == null || entryKey == "" || !entryKey.Contains("Variation"))
                {
                    cacheGetIntPetName.Add(key ?? "", -1);
                    return -1;
                }

                valuestr = entryKey.Replace("{Variation.", "").Replace("}", "");
                if (valuestr == null || valuestr.Length == 0)
                {
                    cacheGetIntPetName.Add(key ?? "", -1);
                    return -1;
                }

                try
                {
                    maxValue = int.Parse(valuestr ?? "");
                }
                catch (Exception ex)
                {
                    ex.message = valuestr + " failed should?";
                    throw;
                }

                cacheGetIntPetName.Add(key, maxValue);
                return maxValue;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string GetUnKeyPetNames(bool male, CASAgeGenderFlags species, bool firstName)
        {
            try
            {
                int max = GetIntPetName(male, species, firstName);
                string key = "Gameplay/SimNames/Pets/" + species + (firstName ? (male ? "/MaleName:Name" : "/FemaleName:Name") : "/FamilyName:Name");
                if (max == -1)
                    return key;

                string petNames = key + "_" + RandomUtil.GetInt(1, max);
#if NIECMOD_DEBUG_MESSAGE
                niec_native_func.OutputDebugString("PetNames: " + key + "\nMax: " + max + "\nNames: " + petNames);
#endif
                return petNames;
            }
            catch (Exception ex)
            {
                NiecException.SendTextExceptionToDebugger(ex);
                return "GetUnKeyPetNames(): Error";
            }
        }

        public static string cukeyname_LocalizeString(bool isFemale, string key, object[] parameters)
        {
            string text = null;
            try
            {
                text = Localization.LocalizeString(isFemale, key, parameters);
            }
            catch (Exception)
            { text += key + " is EX: error"; }
            if (string.IsNullOrEmpty(text))
            {
                return key;
            }
            return text;
        }

        public static string cukeyname_LocalizeStringX(string key)
        {
            string text = ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(key ?? "");
            if (string.IsNullOrEmpty(text))
            {
                return key;
            }
            return text;
        }

        public static void cukeyname_command()
        {
            NFinalizeDeath.CheckYieldingContext();

            string untranslatedKey = null;
            string debug = "";

            while (true)
            {
                Simulator.Sleep(0);

                debug = "";
                untranslatedKey = StringInputDialog.Show("Convert Untranslated Key", "Enter untranslated key:", untranslatedKey, false, 2048);
                if (string.IsNullOrEmpty(untranslatedKey))
                    break;

                debug += "Untranslated Key: " + untranslatedKey;
                debug += "\n\n\nTranslated: " + cukeyname_LocalizeStringX(untranslatedKey ?? "");
                debug += "\n\n\nFix Translated: " + cukeyname_LocalizeString(false, untranslatedKey, new object[0]);

                //var p = "";
                //if (p == "")
                //{
                //    p = 
                //    SimpleMessageDialog.Show(text, p);
                //}
                //else
                //{
                //    SimpleMessageDialog.Show(text, p);
                //}

                new NCopyableTextDialog(debug).SafeShow("cukeyname command");
            }
        }

        public static 
            void dipetname2_command()
        {
            string debug = "";

            debug += "DogFirstName: " + GetUnKeyPetNames(true, CASAgeGenderFlags.Dog, true);
            debug += "\nFDogFirstName: " + GetUnKeyPetNames(false, CASAgeGenderFlags.Dog, true);

            debug += "\n\nHorseFirstName: " + GetUnKeyPetNames(true, CASAgeGenderFlags.Horse, true);
            debug += "\nFHorseFirstName: " + GetUnKeyPetNames(false, CASAgeGenderFlags.Horse, true);

            debug += "\n\nCatFirstName: " + GetUnKeyPetNames(true, CASAgeGenderFlags.Cat, true);
            debug += "\nFCatFirstName: " + GetUnKeyPetNames(false, CASAgeGenderFlags.Cat, true);

            debug += "\n\nLittleDogFirstName: " + GetUnKeyPetNames(true, CASAgeGenderFlags.LittleDog, true);
            debug += "\nFLittleDogFirstName: " + GetUnKeyPetNames(false, CASAgeGenderFlags.LittleDog, true);

            debug += "\n\nDeerFirstName: " + GetUnKeyPetNames(true, CASAgeGenderFlags.Deer, true);
            debug += "\nFDeerFirstName: " + GetUnKeyPetNames(false, CASAgeGenderFlags.Deer, true);

            debug += "\n\nRaccoonFirstName: " + GetUnKeyPetNames(true, CASAgeGenderFlags.Raccoon, true);
            debug += "\nFRaccoonFirstName: " + GetUnKeyPetNames(false, CASAgeGenderFlags.Raccoon, true);

            debug += "\n\nDogFamilyName: " +     GetUnKeyPetNames(true, CASAgeGenderFlags.Dog, false);
            debug += "\nHorseFamilyName: " +     GetUnKeyPetNames(true, CASAgeGenderFlags.Horse, false);
            debug += "\nCatFamilyName: " +       GetUnKeyPetNames(true, CASAgeGenderFlags.Cat, false);
            debug += "\nLittleDogFamilyName: " + GetUnKeyPetNames(true, CASAgeGenderFlags.LittleDog, false);
            debug += "\nDeerFamilyName: " +      GetUnKeyPetNames(true, CASAgeGenderFlags.Deer, false);
            debug += "\nRaccoonFamilyName: " +   GetUnKeyPetNames(true, CASAgeGenderFlags.Raccoon, false);


            debug += "\n\n\n\n";


            debug += "LocalizedDogFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Dog, true) ?? "");
            debug += "\nLocalizedFDogFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(false, CASAgeGenderFlags.Dog, true) ?? "");

            debug += "\n\nLocalizedHorseFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Horse, true) ?? "");
            debug += "\nLocalizedFHorseFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(false, CASAgeGenderFlags.Horse, true) ?? "");

            debug += "\n\nLocalizedCatFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Cat, true) ?? "");
            debug += "\nLocalizedFCatFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(false, CASAgeGenderFlags.Cat, true) ?? "");

            debug += "\n\nLocalizedLittleDogFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.LittleDog, true) ?? "");
            debug += "\nLocalizedFLittleDogFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(false, CASAgeGenderFlags.LittleDog, true) ?? "");

            debug += "\n\nLocalizedDeerFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Deer, true) ?? "");
            debug += "\nLocalizedFDeerFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(false, CASAgeGenderFlags.Deer, true) ?? "");

            debug += "\n\nLocalizedRaccoonFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Raccoon, true) ?? "");
            debug += "\nLocalizedFRaccoonFirstName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(false, CASAgeGenderFlags.Raccoon, true) ?? "");

            debug += "\n\nLocalizedDogFamilyName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Dog, false) ?? "");
            debug += "\nLocalizedHorseFamilyName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Horse, false) ?? "");
            debug += "\nLocalizedCatFamilyName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Cat, false) ?? "");
            debug += "\nLocalizedLittleDogFamilyName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.LittleDog, false) ?? "");
            debug += "\nLocalizedDeerFamilyName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Deer, false) ?? "");
            debug += "\nLocalizedRaccoonFamilyName: " + global::ScriptCore.LocalizedStringService.LocalizedStringService_GetLocalizedStringByString(GetUnKeyPetNames(true, CASAgeGenderFlags.Raccoon, false) ?? "");

            new NCopyableTextDialog(debug).SafeShow("dipetname2 command");
        }

        public static
            void dipetname_command()
        {
            string debug = "";

            debug += "DogFirstName: " + GetIntPetName(true, CASAgeGenderFlags.Dog, true);
            debug += "\nFDogFirstName: " + GetIntPetName(false, CASAgeGenderFlags.Dog, true);

            debug += "\n\nHorseFirstName: " + GetIntPetName(true, CASAgeGenderFlags.Horse, true);
            debug += "\nFHorseFirstName: " + GetIntPetName(false, CASAgeGenderFlags.Horse, true);

            debug += "\n\nCatFirstName: " + GetIntPetName(true, CASAgeGenderFlags.Cat, true);
            debug += "\nFCatFirstName: " + GetIntPetName(false, CASAgeGenderFlags.Cat, true);

            debug += "\n\nLittleDogFirstName: " + GetIntPetName(true, CASAgeGenderFlags.LittleDog, true);
            debug += "\nFLittleDogFirstName: " + GetIntPetName(false, CASAgeGenderFlags.LittleDog, true);

            debug += "\n\nDeerFirstName: " + GetIntPetName(true, CASAgeGenderFlags.Deer, true);
            debug += "\nFDeerFirstName: " + GetIntPetName(false, CASAgeGenderFlags.Deer, true);

            debug += "\n\nRaccoonFirstName: " + GetIntPetName(true, CASAgeGenderFlags.Raccoon, true);
            debug += "\nFRaccoonFirstName: " + GetIntPetName(false, CASAgeGenderFlags.Raccoon, true);


            debug += "\n\nDogFamilyName: " + GetIntPetName(true, CASAgeGenderFlags.Dog, false);
            debug += "\nHorseFamilyName: " + GetIntPetName(true, CASAgeGenderFlags.Horse, false);
            debug += "\nCatFamilyName: " + GetIntPetName(true, CASAgeGenderFlags.Cat, false);
            debug += "\nLittleDogFamilyName: " + GetIntPetName(true, CASAgeGenderFlags.LittleDog, false);
            debug += "\nDeerFamilyName: " + GetIntPetName(true, CASAgeGenderFlags.Deer, false);
            debug += "\nRaccoonFamilyName: " + GetIntPetName(true, CASAgeGenderFlags.Raccoon, false);

            new NCopyableTextDialog(debug).SafeShow("dipetname command");
        }


        public static bool GetFiendDGSSimIFace(out bool is_unsafe_error, out bool is_force_error)
        {
            is_unsafe_error = false;
            is_force_error = false;

            var tStateMachineClient = typeof(Sims3.SimIFace.StateMachineClient);
            if (tStateMachineClient != null)
            {
                FieldInfo f;
                try
                {
                    f = tStateMachineClient.GetField("isunsafeerror", BindingFlags.Static | BindingFlags.Public);
                    if (f != null)
                    {
                        is_unsafe_error = (bool)f.GetValue(null);
                    }
                }
                catch (Exception)
                { }

                try
                {
                    f = tStateMachineClient.GetField("isforceerror", BindingFlags.Static | BindingFlags.Public);
                    if (f != null)
                    {
                       is_force_error = (bool)f.GetValue(null);
                    }
                }
                catch (Exception)
                { }
                return true;
            }
            return false;
        }

        public static void simisf_command() {
            Simulator.CheckYieldingContext();
            if (AssemblyCheckByNiec.DGSSimIFaceIsInstalled())
            {
                bool a, b;

                GetFiendDGSSimIFace
                    (out a, out b);

                SetFiendDGSSimIFace
                    (NFinalizeDeath.CheckAccept("Is Unsafe Error?\nValue: " + a), NFinalizeDeath.CheckAccept("Is Force Error\nValue: " + b), true);
            }
        }

        public static int native_testFuncCPUC = 1350;
        public static void native_testcpu_debug(WindowBase sender, UIEventArgs args)
        {
#if !RemoveCode_ACorewIsnstalled
            if (!NiecHelperSituation.__acorewIsnstalled__) return;
#endif
            if (extestcpudata)
                return;

            int maxCount = MathUtils.Clamp(native_testFuncCPUC, 650, 1550);
            for (int i = 0; i < maxCount; i++)
            {
                ulong _ID = NFinalizeDeath.GetRandomID();
                Sim.OneSimActive = false;
                var simDesc = Create.NiecNullSimDescription();
                simDesc.mSenderNucleusID = (long)_ID + (long)simDesc.SimDescriptionId;
                xverTest.Set(
                    simDesc.mAlienDNAPercentage / NFinalizeDeath.MathU_CatMullRom((0x5 * simDesc.mAlienDNAPercentage) + (sender != null ? sender.CursorID : 1)),
                    0x10 + 0xFF * simDesc.mAlienDNAPercentage + (args != null ? args.mArg1 : 1),
                    i << (i + 0xFFAA / maxCount & simDesc.mSenderNucleusID.GetHashCode())
                );

                xverTest.Normalize();

                if (NFinalizeDeath.Vector3_Is_NAN_Or_Zero(xverTest) || NFinalizeDeath.Vector3_IsUnsafe(xverTest))
                {
                    NFinalizeDeath.CheckMorun();
                }
            }
            //if (!IsOpenDGSInstalled)
            //NiecHelperSituation.OnLoadingDialogDispose();
        }

        public static string setfunctest_commnad_cache_Claas = null;

        public static string setfunctest_commnad_methed = null;

        public static string setfuncptr_commnad_cache_Claas = null;

        public static string setfuncptr_commnad_methed = null;

       

        

        public static
            void setfuncptr_commnad()
        {
            if (NFinalizeDeath.GameIs64Bit(true))
                return;

            Simulator.Sleep(0); // check yield

            NFinalizeDeath.DTESTMOK_();
            NFinalizeDeath.DTESTM_();

            nobjecoD.Home.boolFalse();
            nobjecoD.Home.boolTrue();

            //IntPtr methedptr = new NFinalizeDeath.FunctionX(NFinalizeDeath.DTESTMOK).method_ptr;
            bool falseBoolType = NFinalizeDeath.CheckAccept("False?");
            var m01 = falseBoolType ? 
                (MonoMethod)typeof(NFinalizeDeath).GetMethod("DTESTM_") :
                (MonoMethod)typeof(NFinalizeDeath).GetMethod("DTESTMOK_");

            if (m01 == null)
                return;

            string claasNameMod = StringInputDialog.Show
                ("NiecMod", "Class?", setfuncptr_commnad_cache_Claas ?? "Sims3.Gameplay.Actors.Sim, Sims3GameplaySystems", 256, StringInputDialog.Validation.None);

            if (NFinalizeDeath.IsNullOrEmpty(claasNameMod))
            {
                return;
            }

            setfuncptr_commnad_cache_Claas = claasNameMod;

            if (claasNameMod == null)
                return;

            Type type;
            try
            {
                type = Type.GetType(claasNameMod, true);
            }
            catch (Exception exr)
            {
                exr.trace_ips = null;
                exr.stack_trace = null;
                exr.message = "";

                NFinalizeDeath.Show_MessageDialog("internal error type:\n" + claasNameMod);
                return;
            }

            Simulator.Sleep(0); // check yield

            if (type != null)
            {
                string methodNameMod = StringInputDialog.Show
                    ("NiecMod", "Method Name?", setfuncptr_commnad_methed ?? "CanBeKilled", 256, StringInputDialog.Validation.None);

                if (NFinalizeDeath.IsNullOrEmpty(methodNameMod))
                { return; }

                setfuncptr_commnad_methed = methodNameMod;

                bool done = false;
                Type booleanType = typeof(bool);

                foreach (var item in type.GetMethods())
                {
                    if (item == null)
                        continue;

                    if (item.ContainsGenericParameters)
                        continue;

                    if (item.IsAbstract)// || !item.IsStatic)
                        continue;

                    if (item.ReturnType != booleanType)
                        continue;

                    var parInfo = item.GetParameters();
                    if (parInfo == null)
                        continue;

                    if (parInfo.Length == 0)
                    {
                        var name = item.Name;
                        if (name == null)
                            continue;

                      

                        if (name.Contains(methodNameMod))
                        {
                            done = true;

                            if (!item.IsStatic)
                            {
                                var m02 =
                                    falseBoolType ? typeof(nobjecoD).GetMethod("boolFalse", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                    : typeof(nobjecoD).GetMethod("boolTrue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                                if (m02 == null)
                                {
                                    NFinalizeDeath.Assert("m02 == null");
                                    return;
                                }
                                else m01 = (MonoMethod)m02;
                            }
                            try
                            {
                                //if (!item.IsStatic)
                                //NFinalizeDeath.FindGetFunctionPointer(claasNameMod, methodNameMod, , BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)

                                niec_native_func.init_class();

                                if (!niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, item, false, true, true, false))
                                    NFinalizeDeath.Show_MessageDialog("Could not copy pointer!\nName: " + name);
                                else NFinalizeDeath.Show_MessageDialog("Done!");
                            }
                            catch (Exception)
                            {
                                NFinalizeDeath.Show_MessageDialog("Failed to copying pointer!\nName: " + name);
                            }
                           
                            break;
                        }
                    }
                }
                if (done)
                { }
                else
                {
                    NFinalizeDeath.Show_MessageDialog("Could not find Method Name:\n" + methodNameMod);
                }
            }
            else
            {
                NFinalizeDeath.Show_MessageDialog("Could not find Type Name:\n" + claasNameMod);
            }
        }

        public static
            void setfunctest_commnad() // unprotected mono mscorlib 
        {
            Simulator.CheckYieldingContext(true);

            int i = NFinalizeDeath.GetIntDialog("testFuncCPUC: " + testFuncCPUC);
            if (!(i == -101 || i == -102))
                testFuncCPUC = i;

            int ic = NFinalizeDeath.GetIntDialog("native_testFuncCPUC: " + testFuncCPUC);
            if (!(ic == -101 || ic == -102))
                native_testFuncCPUC = ic;

            Simulator.CheckYieldingContext(true);

            if (NFinalizeDeath.CheckAccept("Clear FuncTests?")) {
                DGSMODS_TestFunc = null;
                DGSMODS_TestFunc02 = null;
                return;
            }

            Simulator.CheckYieldingContext(true);

            string claasNameMod = StringInputDialog.Show
                ("NiecMod", "Class?", setfunctest_commnad_cache_Claas ?? typeof(NiecRunCommand).ToString(), 256, StringInputDialog.Validation.None);

            if (NFinalizeDeath.IsNullOrEmpty(claasNameMod))
            { return; }

            setfunctest_commnad_cache_Claas = claasNameMod;

            Type type;
            try
            {
                type = Type.GetType(claasNameMod, false);
            }
            catch (Exception exr)
            { 
                exr.trace_ips = null;
                exr.message = "";
                NFinalizeDeath.Show_MessageDialog("internal error type:\n" + claasNameMod);
                return;
            }

            Simulator.CheckYieldingContext(true);

            if (type != null) {
                string methodNameMod = StringInputDialog.Show("NiecMod", "Method Name?", setfunctest_commnad_methed ?? "FastCodeEventTrackerV2", 256, StringInputDialog.Validation.None);
                if (NFinalizeDeath.IsNullOrEmpty(methodNameMod))
                { return; }

                setfunctest_commnad_methed = methodNameMod;
                bool done = false;
                Type voidType = typeof(void);
                foreach (var item in type.GetMethods())
                {
                    if (done) 
                        break;

                    if (item == null) 
                        continue;

                    if (item.ContainsGenericParameters) 
                        continue;

                    if (item.IsAbstract || !item.IsStatic) 
                        continue;

                    if (item.ReturnType != voidType) 
                        continue;

                    var parInfo = item.GetParameters();
                    if (parInfo == null) 
                        continue;

                    if (parInfo.Length == 0) {
                        var name = item.Name;
                        if (name == null) 
                            continue;

                        if (name.Contains(methodNameMod))
                        {
                            if (IsOpenDGSInstalled)
                            {
                                try
                                {
                                    DGSMODS_TestFunc = (Sims3.NiecHelp.Tasks.NiecNraTask.NraFunction)
                                        Delegate.CreateDelegate
                                        (typeof(Sims3.NiecHelp.Tasks.NiecNraTask.NraFunction), item);

                                    if (DGSMODS_TestFunc == null)
                                        continue;

                                    done = true;
                                }
                                catch (Exception exr)
                                {
                                    exr.trace_ips = null;
                                    exr.message = "";
                                    continue;
                                }

                            }
                            else {
                                try
                                {
                                    DGSMODS_TestFunc02 = (Sims3.NiecHelp.Tasks.NiecNraTask.NraFunction)
                                        Delegate.CreateDelegate
                                        (typeof(Sims3.NiecHelp.Tasks.NiecNraTask.NraFunction), item);

                                    if (DGSMODS_TestFunc02 == null)
                                        continue;

                                    done = true;
                                }
                                catch (Exception exr)
                                {
                                    exr.trace_ips = null;
                                    exr.message = "";
                                    continue;
                                }
                            }
                        }
                    }
                }
                if (done) {
                    //NFinalizeDeath.Show_MessageDialog("Done :)");
                    if (NFinalizeDeath.CheckAccept("Done\nRun Func?"))
                    {
                        rcfunc_command();
                        CommandConsoleDialog.smLastCommandString = "niecmod rcfunc";
                    }
                }
                else {
                    NFinalizeDeath.Show_MessageDialog("Could not find Method Name:\n" + methodNameMod);
                }
            }
            else
            {
                NFinalizeDeath.Show_MessageDialog("Could not find Type Name:\n" + claasNameMod);
            }
        }



        public static
            void clearetdata_Command()
        {
            try
            {
                Type typex = Type.GetType("NRaas.ErrorTrapSpace.ObjectLookup, NRaasErrorTrap", false);
                if (typex != null)
                {
                    MethodInfo getho = typex.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (getho != null)
                    {
                        getho.Invoke(null, new object[0]);

                    }
                }
            }
            catch
            { }
        }


        public static
            void delallsim_command()
        {

            if (!IsOpenDGSInstalled && AssemblyCheckByNiec.IsInstalled("AweCore"))
            {
                VideoRecorder.SnapshotFileName = "delallsim_s_Screenshot";
                VideoRecorder.TakeSnapshot();

                if (Simulator.CheckYieldingContext(false))
                    Simulator.Sleep(0);


                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause, false);

                if (IsVisibleTreatmentsController() && Simulator.CheckYieldingContext(false))
                    Simulator.Sleep(0);

                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Triple, false);

                bool r = niec_native_func.cache_done_niecmod_native_message_box;
                bool r01 = false;

                if (!r)
                {
                    r01 = NFinalizeDeath.CheckAccept("Save Game?");
                }

                NPlumbBob.sCurrentSimTwo = null;

                Sim aa = null;
                Sim aa2 = null;

                if (PlumbBob.sSingleton != null)
                {
                    PlumbBob.sCurrentNonNullHousehold = null;
                    aa = PlumbBob.sSingleton.mSelectedActor;
                    PlumbBob.sSingleton.mSelectedActor = null;

                    NPlumbBob.sCurrentNonNullHousehold = null;
                    aa2 = NPlumbBob.sCurrentSim;
                    NPlumbBob.sCurrentSim = null;
                    
                }

                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (item == null) 
                        continue;
                    Bim.bSDestroy(item);
                }

                NFinalizeDeath.MsCorlibModifed_Exlists(false);

                NFinalizeDeath.SafeCall(() =>
                {
                    for (int i = 0; i < 2; i++)
                    {
                        PlumbBob.sCurrentNonNullHousehold = null;
                        NPlumbBob.sCurrentNonNullHousehold = null;
                        PlumbBob.DoSelectActor(aa, true);

                        PlumbBob.sCurrentNonNullHousehold = null;
                        NPlumbBob.sCurrentNonNullHousehold = null;
                        PlumbBob.DoSelectActor(aa2, true);
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        PlumbBob.DoSelectActor(null, true);
                    }
                });

                VideoRecorder.SnapshotFileName = "delallsim_f_Screenshot";
                VideoRecorder.TakeSnapshot();

                if (r01 || (r && NFinalizeDeath.CheckAccpetWithoutYield("Save Game?")))
                    NFinalizeDeath.unsafeForceSaveGameNoDialog();

                NFinalizeDeath.MsCorlibModifed_Exlists(false);

                if (niec_native_func.cache_done_niecmod_native_message_box)
                {
                    niec_native_func.MessageBox(0, "Play Ready?", "NiecMod", 0);
                }

                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause, false);
            }
            else
            {
                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (item == null)
                        continue;
                    NFinalizeDeath.ForceDestroyObject(item, false);
                }
            }
        }

        public static
            void allinvsim_command()
        {
            bool acore = !IsOpenDGSInstalled && AssemblyCheckByNiec.IsInstalled("AweCore");
            if (acore)
            {
                GC.Collect();
            }

            bool a = NFinalizeDeath.AutoMET != null;
            bool b = NFinalizeDeath.AutoMET_NTaskNeedAddToQure;
            bool tevis = false;

            if (!IsOpenDGSInstalled && !((tevdata != null || pta)))
            {
                if (NFinalizeDeath.CheckAccept("tev?"))
                {
                    tev_command(false);
                    tevis = true;
                }
            }

            var portal = NFinalizeDeath.AutoMET_TimePortal;

            if (a)
            {
                try
                {
                    NFinalizeDeath.AutoMET_ShutDown();
                }
                catch (Exception)
                { }
            }

            if (acore)
            {
                NFinalizeDeath.SafeCall(() =>
                {
                    foreach (var simDesc in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                    {
                        if (simDesc == null || simDesc.mOutfits == null || simDesc.mHairColors == null)
                            continue;

                        if (!NFinalizeDeath.SimDesc_OutfitsIsValid(simDesc))
                            continue;

                        var sim = simDesc.CreatedSim;
                        if (sim != null)
                        {
                            if (!NFinalizeDeath.GameObjectIsValid(sim.ObjectId.mValue) || sim.mSimDescription != simDesc)
                            {
                                NFinalizeDeath.ForceDestroyObject(sim, false);
                                simDesc.mSim = null;
                            }
                        }

                        NFinalizeDeath.ValidateSimCreated(simDesc, null);

                        if (simDesc.mSim == null)
                        {
                            niec_native_func.OutputDebugString("ACore allinvsim Name: " + simDesc.FullName);
                            var s = NFinalizeDeath.SimDesc_SafeInstantiate(simDesc, World.SnapToFloor(CameraController.GetTarget()));
                            if (s != null)
                            {
                                if (NFinalizeDeath.FixUpFullSim(s))
                                {
                                    s.mSimDescription = simDesc;
                                    simDesc.mSim = s;
                                    if (s.mInteractionQueue == null)
                                        s.mInteractionQueue = new InteractionQueue(s);
                                }
                                else
                                {
                                    NFinalizeDeath.ForceDestroyObject(s, false);
                                }
                            }
                        }
                    }
                });
            }
            else
            {
                foreach (var simDesc in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                {
                    if (simDesc == null || simDesc.mOutfits == null || (IsOpenDGSInstalled && simDesc.SimDescriptionId == 0) || simDesc.mHairColors == null)
                        continue;

                    if (!NFinalizeDeath.SimDesc_OutfitsIsValid(simDesc))
                        continue;
                    if (simDesc.mSim == null)
                    {
                        niec_native_func.OutputDebugString("allinvsim Name: " + simDesc.FullName);
                        var s = NFinalizeDeath.SimDesc_SafeInstantiate(simDesc, World.SnapToFloor(CameraController.GetTarget()));
                        if (s != null)
                        {
                            if (NFinalizeDeath.FixUpFullSim(s))
                            {
                                s.mSimDescription = simDesc;
                                simDesc.mSim = s;
                                if (s.mInteractionQueue == null)
                                    s.mInteractionQueue = new InteractionQueue(s);
                            }
                            else
                            {
                                NFinalizeDeath.ForceDestroyObject(s, false);
                            }
                        }
                        if (IsOpenDGSInstalled)
                        {
                            for (int i = 0; i < 25; i++)
                            {
                                Simulator.Sleep(0);
                            }
                        }
                    }
                }
            }

            if (tevis)
            {
                if (pta)
                    pta = false;
                else tev_command(true);
            }

            if (a)
            {
                NFinalizeDeath.AutoMET_StartUp(portal, b);
            }

            if (acore)
            {
                GC.Collect();
            }
        }

        public static
            bool loopraa_C = false;

        public static
            bool forcefastdoinhs = false;

        public static
            bool isstsleepmax = false;

        public static
            void allbulot_Command()
        {
            Simulator.CheckYieldingContext(true);
            bool t = NiecHelperSituation.__acorewIsnstalled__ && NFinalizeDeath.CheckAccept("Kill All NPC Sim?");
            try
            {
                rallbuff_command();
            }
            catch (Exception)
            { }

           

            var lotM = LotManager.sLots;
            if (lotM == null) 
                return;



            //int i = 0;
            int a = 0;
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null) 
                    continue;

                item.SetPosition(World.SnapToFloor(CameraController.GetTarget()));

                //i++;
                //if (i > 50)
                //{
                //    Simulator.Sleep(0);
                //    ustsimallpro_Command();
                //    i = 0;
                //}

                if (t)
                {
                    a++;
                    if (a == 3)
                    {
                        try
                        {
                            try
                            {
                                usev_Command(true, NiecHelperSituation.__acorewIsnstalled__);
                                foreach (var objSim in NFinalizeDeath.SC_GetObjects<Sim>())
                                {
                                    if (objSim == null || NFinalizeDeath.IsAllActiveHousehold_SimObject(objSim))
                                        continue;
                                    NFinalizeDeath.UnSafeForceErrorTargetSim(objSim);

                                    SimDescription sd = null;
                                    sd = objSim.mSimDescription;
                                    objSim.mSimDescription = null;
                                    if (sd != null)
                                        sd.mSim = null;
                                    NFinalizeDeath.ForceDestroyObject(objSim);
                                }
                            }
                            finally
                            {
                                if (tusev != null)
                                    usev_Command(false, false);
                            }



                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        { }
                        try
                        {
                            var activeActor = NFinalizeDeath.ActiveActor;

                            PlumbBob.sCurrentNonNullHousehold = null;
                            if (PlumbBob.sSingleton != null)
                                PlumbBob.sSingleton.mSelectedActor = null;
                            NFinalizeDeath.ActiveActor = activeActor;

                            NFinalizeDeath.Household_RefrashAllActors(NFinalizeDeath.ActiveHousehold);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        { }
                    }
                }
            }

            foreach (Lot item in lotM.Values)
            {
                if (item == null)
                    continue;

                NFinalizeDeath.BuLot(item, NiecHelperSituation.__acorewIsnstalled__);
            }
        }

        public static
            void forcesetaa3_Command(Sim Target, bool Update, bool Update1)
        {
            if (PlumbBob.sSingleton == null) 
                return;

            Sim sim = Target ?? HitTargetSim();

            PlumbBob.sSingleton.mSelectedActor = sim;
            PlumbBob.sCurrentNonNullHousehold = sim != null ? sim.Household : null;

            if (Update1)
            {
                try
                {
                    Sims3.Gameplay.UI.HudModel hudmodel = (Sims3.UI.Responder.Instance.HudModel as Sims3.Gameplay.UI.HudModel);
                    if (hudmodel != null)
                    {
                        NFinalizeDeath.List_FastClearEx(ref hudmodel.mSimList);
                        NFinalizeDeath.List_FastClearEx(ref hudmodel.mVisitorList);
                    }
                }
                catch (Exception) { }
            }
            if (Update)
            {
                if (sim != null)
                {
                    if (!PlumbBob.SelectActor(sim) || !PlumbBob.SelectActor(sim))
                    {
                        PlumbBob.sCurrentNonNullHousehold = null;
                        PlumbBob.ForceSelectActor(sim);
                    }
                }
                else {
                    PlumbBob.sCurrentNonNullHousehold = null;
                    PlumbBob.ForceSelectActor(null);
                }
            }
        }

        public static
            void loopraa_Command()
        {
            if (loopraa_01_ObjectID == NiecInvalidObjectGuid)
            {
                if (!loopraa_C)
                    NiecException.PrintMessagePro("loopraa Task Created.", false, 100);
                loopraa_01_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {


                    try
                    {
                        int sleep =0;
                        while (true)
                        {
                            Simulator.Sleep(0);
                            Sim activeActor = NFinalizeDeath.SelectedActor_ChildAndTeen;
                            if (activeActor == null || activeActor.mLotCurrent == null)
                                continue;

                            foreach (var item in NFinalizeDeath.SC_GetObjectsOnLot<Sim>(activeActor.LotCurrent))
                            {
                                try
                                {
                                    sleep++;
                                    if (sleep > 35)
                                    {
                                        sleep = 0;
                                        Simulator.Sleep(0);
                                    }

                                    if (item == null || item.Posture == null || item == activeActor || item.mAutonomy == null || item.SimDescription == null || item.IsPet || item.SimDescription.ToddlerOrBelow || item.HasBeenDestroyed || item.InteractionQueue == null || item.InteractionQueue.mInteractionList == null)
                                    {
                                        continue;
                                    }

                                    if (IsOpenDGSInstalled && item.CurrentInteraction != null)
                                        continue;

                                    if (!IsOpenDGSInstalled && item.InteractionQueue.HasInteractionOfType(ReactionInteraction.Singleton))
                                        continue;

                                    if (NFinalizeDeath._SimRunningNHSInteraction(item)) 
                                        continue;

                                    if (item.IsSleeping)
                                    {
                                        item.AddExitReason(ExitReason.Finished);
                                    }

                                   

                                    ReactionTypes[] randomList =

                                    (!item.HasTrait(TraitNames.Evil))
                                    ? new ReactionTypes[3]
			                        {
			                        	ReactionTypes.Cheer,
			                        	ReactionTypes.PointLaugh,
			                        	ReactionTypes.Watch
			                        }
                                    : new ReactionTypes[4]
			                        {
			                        	ReactionTypes.Cheer,
			                        	ReactionTypes.PointLaugh,
			                        	ReactionTypes.Watch,
			                        	ReactionTypes.EvilLaugh
			                        };

                                    item.PlayReaction(RandomUtil.GetRandomObjectFromList(randomList), activeActor, ReactionSpeed.CriticalWithRoute);
                                }
                                catch (ResetException)
                                {
                                    throw;
                                }
                                catch {
                                    if (!IsOpenDGSInstalled)
                                        NFinalizeDeath.SleepTask(60);
                                    else break;
                                }
                            }
                            


                            Simulator.Sleep(IsOpenDGSInstalled ? 455u : 10u);
                        }
                    }
                    finally
                    {
                        loopraa_01_ObjectID = new ObjectGuid(0);
                    }
                });
            }
            else
            {
                if (!loopraa_C)
                    NFinalizeDeath.RemoveTaskFromSimulator(ref loopraa_01_ObjectID);
                NiecException.PrintMessagePro("loopraa Task Removed.", false, 100);
            }
        }

        public static 
            void ThrowDefault() 
        {
            //NFinalizeDeath.ThrowOtherException(new NiecModException());
            throw new NiecModException();
        }

        public static
            void tpsim_command()
        {
            //if (IsOpenDGSInstalled) return;
            //Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Threaded,delegate
            //{
            //    DGSMODS_TestFunc();
            //});
            Sim TargetSim = HitTargetSim();
            if (TargetSim != null && TargetSim.InteractionQueue != null && TargetSim.InteractionQueue.mInteractionList != null)
            {
                NinecReaper custi = TargetSim.CurrentInteraction as NinecReaper;
                if (custi != null && (custi.CustomRunName == "tpsim" || custi.CustomRunName == "uloopnhs"))
                {
                    TargetSim.SetToResetAndSendHome();
                }
                else
                {
                    NinecReaper.CustomRun cuRun = delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                    {
                        try
                        {
                            if (IsOpenDGSInstalled) {
                                Sims3.NiecHelp.Tasks.NiecTask.CreateWaitPerformWithExecuteType
                                    (NFinalizeDeath.GetCurrentExecuteType(), DGSMODS_TestFunc).WaitingCanThrow();
                            }
                            else {
                                bool a = false;
                                if (DGSMODS_TestFunc02 != null)
                                {
                                    Sims3.NiecHelp.Tasks.NiecTask.CreateWaitPerformWithExecuteType
                                        (ScriptExecuteType.Threaded, DGSMODS_TestFunc02).WaitingCanThrow();
                                }
                                //else if (DGSMODS_TestFunc != null)
                                //{
                                //    //Sims3.NiecHelp.Tasks.NiecTask.CreateWaitPerformWithExecuteType
                                //    //    (ScriptExecuteType.Threaded, DGSMODS_TestFunc).WaitingCanThrow();
                                //    DGSMODS_TestFunc();
                                //}
                                else 
                                {
                                    if (!a)
                                    {
                                        fcreap_Icommand(Actor, true, false);
                                    }
                                    testFuncCPU(); 
                                }
                            }
                        }
                        catch
                        {
                            NFinalizeDeath.CheckYieldingContext();
                            if (!IsOpenDGSInstalled)
                            {
                                if (NFinalizeDeath.Random_GetFloat(0, 100, null) < 25)
                                {
                                    NiecHelperSituationPosture.r_internal(Actor);
                                    DGSMODS_Func_stload();
                                }
                                NFinalizeDeath.ThrowOtherException(new NullReferenceException("A null value was found where an object instance was required."));
                            }
                            throw;
                        }
                        return true;
                    };
                    //NinecReaper niecr = NinecReaper.AddToInteranctionQueue(TargetSim, TargetSim, cuRun);
                    //niecr.CustomRunName = "tpsim";
                    NinecReaper.AddToInteranctionQueue(TargetSim, TargetSim, cuRun).CustomRunName = "tpsim";
                }
            }
        }

        public static
            void rallbuff_command() { NFinalizeDeath.RemoveAllSimBuffInstance(); }

        public static
            void rallirunlist_command() { NFinalizeDeath.RemoveAllIQRunningIList(); }

        public static
            void kill_sim_for_lot()
        {
            int i = NFinalizeDeath.GetIntDialog("killsimforlot() Count?");
            if (i == 0 || i == -101 || i == -102) return;
            LotLocation LotLocation = default(LotLocation);
            ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
            Lot TargetLot = LotManager.GetLot(Location);
            if (TargetLot != null)
            {
               
                foreach (var item in NFinalizeDeath.SC_GetObjectsOnLot<Sim>(TargetLot))
                {
                    if (i == 0) return;
                    i--;
                    if (item == null || item.mInteractionQueue == null || item.mInteractionQueue.mInteractionList == null) 
                        continue;
                    try
                    {
                        var createKillSim = NFinalizeDeath.Interaction_CreateKillSim(item, SimDescription.DeathType.Drown);
                        if (createKillSim == null)
                            continue;
                        item.mInteractionQueue.Add(createKillSim);
                    }
                    catch (StackOverflowException) { return; }
                    catch (ExecutionEngineException) { return; }
                    catch (ResetException) { throw; }
                    catch (Exception) {}
                   
                }
            }
        }

        public static List<List<InventoryItem>> slist_data_alldinv_command = null;
        public static bool alldinv_command_bool = false;

        public static void AddInventoryAndStoreInListToData(Sim sim)
        {
            if (slist_data_alldinv_command == null)
            {
                slist_data_alldinv_command = new List<List<InventoryItem>>(100);
            }
            if (sim != null && sim.Inventory != null)
                slist_data_alldinv_command.Add(sim.Inventory.DestroyInventoryAndStoreInList());
        }

        public static
            void simu2f_command(bool c)
        {
            Dictionary<Sim, List<SimUpdate>> simAndSimUpdateList = new Dictionary<Sim, List<SimUpdate>>();
            foreach (var item in NFinalizeDeath.SC_GetObjects<SimUpdate>())
            {
                if (item == null) 
                    continue;

                var sim = item.mSim;
                if (sim == null || !NFinalizeDeath.GameObjectIsValid(sim.ObjectId.mValue))
                {
                    var p = item.Proxy;
                    if (p != null)
                        Simulator.DestroyObject(p.ObjectId);
                    continue;
                }

                List<SimUpdate> simUpdateList;
                if (simAndSimUpdateList.ContainsKey(sim))
                {
                    if (!simAndSimUpdateList.TryGetValue(sim, out simUpdateList))
                        NFinalizeDeath.Assert("simAndSimUpdateList.TryGetValue(sim, out simAndSimUpdateList) failed");
                    else
                    {
                        //if (simUpdateList.Contains(item))
                        //    continue;
                        simUpdateList.Add(item);
                    }
                }
                else
                {
                    simUpdateList = new List<SimUpdate>();
                    //if (!simUpdateList.Contains(item))
                    //    simUpdateList.Add(item);
                    simAndSimUpdateList.Add(sim, simUpdateList);
                }
            }
            bool done = false;
            foreach (var item in simAndSimUpdateList)
            {
                var sim = item.key;
                var listSimUpdate = item.value;

                SimUpdate oneSimUpdate = null;

                bool found2 = false;

                foreach (var itemSimUpdate in listSimUpdate)
                {
                    if (oneSimUpdate == null && itemSimUpdate != null && itemSimUpdate.Proxy != null)
                    {
                        oneSimUpdate = itemSimUpdate;
                        sim.mSimUpdateId = oneSimUpdate.Proxy.ObjectId;
                        oneSimUpdate.mSim = sim;
                        found2 = true;
                        continue;
                    }

                    if (!found2 || itemSimUpdate == oneSimUpdate)
                        continue;

                    done = true;

                    var p = itemSimUpdate.Proxy;
                    if (p != null)
                        Simulator.DestroyObject(p.ObjectId);
                }
                if (!found2)
                {
                    sim.mSimUpdateId = Simulator.AddObject(new SimUpdate(sim));
                }
                if (oneSimUpdate != null)
                {
                    sim.mSimUpdateId = oneSimUpdate.Proxy.ObjectId;
                    oneSimUpdate.mSim = sim;
                }
            }
            if (done && c)
                SimpleMessageDialog.Show("NiecMod", "Sim Update 2 Found :)");
        }

        public static
            void allresetsim_command()
        {
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null || item.ObjectId.mValue == 0) 
                    continue;

                ScriptCore.ScriptProxy.ScriptProxy_SetResetState(item.ObjectId.mValue, ScriptCore.ScriptProxy.eResetStatus.kResetRequested);
            }
        }

        public static
            void dkeygivename_command()
        {
            string debug = "";
            debug += "RobotFirstName: " + SimUtils.GetRandomRobotGivenName(true);
            debug += "\nRobotFamily: " + SimUtils.GetRandomRobotFamilyName();
            debug += "\nHumanFirstName: " + SimUtils.GetRandomGivenName(true, WorldName.SunsetValley);
            debug += "\nDogFirstName: " + SimUtils.GetRandomPetName(true, CASAgeGenderFlags.Dog, true);
            debug += "\nHorseFirstName: " + SimUtils.GetRandomPetName(true, CASAgeGenderFlags.Horse, true);
            debug += "\nCatFirstName: " + SimUtils.GetRandomPetName(true, CASAgeGenderFlags.Cat, true);
            debug += "\nLittleDogFirstName: " + SimUtils.GetRandomPetName(true, CASAgeGenderFlags.LittleDog, true);
            debug += "\nDeerFirstName: " + SimUtils.GetRandomPetName(true, CASAgeGenderFlags.Deer, true);
            debug += "\nRaccoonFirstName: " + SimUtils.GetRandomPetName(true, CASAgeGenderFlags.Raccoon, true);
            debug += "\nFamilyFirstName: " + SimUtils.GetRandomFamilyName(WorldName.SunsetValley);

            new NCopyableTextDialog(debug).SafeShow("dkeygivename command");
        }

        public static
            void alldinv_command()
        {
            if (NFinalizeDeath.CheckAccept("Are you sure?"))//("Safe"))
            {
                bool acore = NiecHelperSituation.__acorewIsnstalled__ && !NiecHelperSituation.___bOpenDGSIsInstalled_;
                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (item == null)
                        continue;

                    if (item.mObjComponents == null)
                        continue;

                    if (acore)
                    {
                        const string msg = "Attempt to call SafeCall() in a if (alldinv_command_bool). Game Crash caused by StackOverflow";

                        if (alldinv_command_bool)
                            throw new StackOverflowException (msg);

                        NFinalizeDeath.SafeCall(() =>
                        {
                            if (alldinv_command_bool)
                                throw new StackOverflowException (msg);
                            try
                            {
                                alldinv_command_bool = true;
                                AddInventoryAndStoreInListToData(item); // awecode unsafe: gc evil
                            }
                            catch (Exception)
                            { }
                            finally { alldinv_command_bool = false; }
                        });
                       
                    }

                    var i = item.Inventory;
                    if (i == null)
                        continue;

                    NFinalizeDeath.DeleteInvSim(item);
                }
                bool p = false;
                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                {
                    if (item == null)
                        continue;

                    if (item.mObjComponents == null || item.SimDescription == null || item.SimDescription.mSim != item)
                        continue;

                    try
                    {
                        if (item.InventoryComp == null)
                        {
                            item.mObjComponents.Add(new Sims3.Gameplay.ObjectComponents.InventoryComponent(item));
                            //   item.AddComponent<Sims3.Gameplay.ObjectComponents.InventoryComponent>(item);
                        }
                    }
                    catch (Exception)
                    { }

                    if (!p && item.InventoryComp == null)
                    {
                        NFinalizeDeath.Assert("item.InventoryComp == null failed");
                        p = true;
                    }
                    var ic = item.InventoryComp;
                    if (ic != null && ic.Inventory == null)
                    {
                        ic.mScriptObject = item;
                        try
                        {
                            ic.Inventory = new Inventory(item);
                        }
                        catch (Exception)
                        {
                            if (!p)
                            {
                                NFinalizeDeath.Assert("Inventory create failed");
                                p = true;
                            }
                        }
                      
                    }
                }
                return;
            }
            //alldinv_command_bool = false;
            //foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            //{
            //    if (item == null)
            //        continue;
            //
            //    if (item.mObjComponents == null) 
            //        continue;
            //
            //    var i = item.Inventory;
            //    if (i == null)
            //        continue;
            //
            //    try
            //    {
            //        var t = i.DestroyInventoryAndStoreInList();
            //        if (t != null)
            //        {
            //            foreach (var itemI in t.ToArray())
            //            {
            //                if (itemI == null)
            //                    continue;
            //
            //                var objectItem = itemI.Object;
            //                if (objectItem != null && !objectItem.InUse)
            //                    NFinalizeDeath.ForceDestroyObjectI(objectItem);
            //            }
            //            t.Clear();
            //        }
            //        else continue;
            //
            //        try
            //        {
            //            item.FixUpCellPhone();
            //        }
            //        catch (StackOverflowException) { return; }
            //        catch (ExecutionEngineException) { return; }
            //        catch (ResetException) { throw; }
            //        catch { }
            //    }
            //    catch (StackOverflowException) { return; }
            //    catch (ExecutionEngineException) { return; }
            //    catch (ResetException) { throw; }
            //    catch
            //    {
            //        NFinalizeDeath.DeleteInvSim(item);
            //        if (item.mObjComponents == null) 
            //            continue;
            //
            //        item.AddComponent<Sims3.Gameplay.ObjectComponents.InventoryComponent>();
            //
            //        try
            //        {
            //            item.FixUpCellPhone();
            //        }
            //        catch (StackOverflowException) { return; }
            //        catch (ExecutionEngineException) { return; }
            //        catch (ResetException) { throw; }
            //        catch { }
            //
            //    }
            //}
        } 

        public static 
            void fcreap_command() 
        {
            fcreap_Icommand(null, false, true);
        }

        public static 
            StateMachineClient fcreap_Icommand(Sim actor, bool yield, bool bGCKeepObject)
        {
            if (!NiecHelperSituation.IsGrimReaperFast())
                return null;

            Sim Actor = actor ?? HitTargetSim();
            if (Actor == null || Actor.ObjectId.mValue == 0) 
                return null;

            if (yield)
                Simulator.CheckYieldingContext(true);

            try
            {
                StateMachineClient antiNPCReapSoul = StateMachineClient.Acquire(Actor.ObjectId, "DGSDeath", AnimationPriority.kAPUltraPlus, yield);
                if (antiNPCReapSoul == null)
                    return null; // Can't find DGSDeath ResourceKey
                
                if (!IsOpenDGSInstalled)
                    NFinalizeDeath.StateMachineClient_SetActor(antiNPCReapSoul, "x", Actor);
                else
                    antiNPCReapSoul.SetActor("x", Actor);

                if (NFinalizeDeath.StateMachineClient_SimIsPet(Actor))
                {
                    antiNPCReapSoul.SetParameter(3242275675u, typeof(Sims3.SimIFace.Enums.Species), (ulong)Sims3.SimIFace.Enums.Species.human);
                }

                if (NFinalizeDeath.NonOpenDGSStateMachineClient_HumanIsBaby(Actor))
                    antiNPCReapSoul.SetParameter(499670524u, typeof(Sims3.SimIFace.Enums.Age), (ulong)Sims3.SimIFace.Enums.Age.adult);

                antiNPCReapSoul.EnterState("x", "Enter");
                if (NiecHelperSituation.__acorewIsnstalled__)
                {
                    NFinalizeDeath.SMCIsValid("x", true, antiNPCReapSoul);
                    NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, antiNPCReapSoul);
                    NFinalizeDeath.SMCIsHandleEventsAsynchronously("x", true, antiNPCReapSoul);
                    NFinalizeDeath.SMCIsValid("x", true, antiNPCReapSoul);
                }
                antiNPCReapSoul.RequestState(yield, "x", "Float");

                if (bGCKeepObject)
                    GC.KeepAlive(antiNPCReapSoul);

                return antiNPCReapSoul;
            }
            catch (NotSupportedException)
            { return null; }
            catch (SacsErrorException)
            { return null; }
            
        }

        public static 
            void rcfunc_command() 
        {
            Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate 
            {
                if (IsOpenDGSInstalled)
                {
                    DGSMODS_TestFunc();
                }
                else
                {
                    DGSMODS_TestFunc02();
                }
            });
        }

        public static ulong looplightcpID = 0;

        public static
            void looplightcp_command()
        {
            if (!GameStates.IsInWorld()) 
                return;
            if (looplightcpID == 0)
            {
                looplightcpID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                {
                    var campos = ScriptCore.CameraController.Camera_GetPosition();
                    var pos = ScriptCore.CameraController.Camera_GetPosition();

                    var t = new Random((int)campos.y);

                    while (GameStates.IsInWorld())
                    {
                        //for (int i = 0; i < 20; i++) {
                        //    Simulator.Sleep(0);
                        //}
                        Simulator.Sleep(5);

                        pos.x = NFinalizeDeath.Random_CoinFlip() ? (pos.x + (float)t.Next(1, 9)) : (pos.x - -(float)t.Next(3, 7));
                        pos.z = NFinalizeDeath.Random_CoinFlip() ? (pos.z + (float)t.Next(3, 6)) : (pos.z - -(float)t.Next(2, 4));
                        pos.y = ScriptCore.World.World_GetTerrainHeightImpl(pos.x, pos.z, false);

                        if (!NFinalizeDeath.RunLightning(null, pos, false) || NFinalizeDeath.Random_GetFloat(0, 100, t) < 25)
                            campos = ScriptCore.CameraController.Camera_GetPosition();

                        pos.x = campos.x;
                        pos.z = campos.z;
                        pos.y = campos.y;

                    }
                    looplightcpID = 0;
                }).mValue;
            }
            else
            {
                ScriptCore.Simulator.Simulator_DestroyObjectImpl(looplightcpID);
                looplightcpID = 0;
            }
        }

        public static
            void addsimtohousehold2_command()
        {
            if (!Simulator.CheckYieldingContext(false))
                return;

            if (!GameStates.IsInWorld()) 
                return;

            var addsimtohousehold_data = addsimtohousehold_cdata ?? NFinalizeDeath.GetTargetSimHousehold();
            if (addsimtohousehold_data == null)
            {
                NiecException.PrintMessagePro("Please Target Household", false, 5);
                while (true)
                {
                    addsimtohousehold_data = NFinalizeDeath.GetTargetSimHousehold();
                    if (addsimtohousehold_data != null) 
                        break;
                    Simulator.Sleep(0);
                }
            }
            
            var simHousehold = HitTargetSim();
            NFinalizeDeath.RemoveNullForHouseholdMembers(addsimtohousehold_data);

            Sim sim = null;
            SimDescription simd = null;

            while (sim == null || sim == simHousehold)
            {
                simd = null;
                sim = HitTargetSim();
                if (sim != null)
                {
                    simd = sim.mSimDescription;
                    if (simd == null || simd.mHousehold == addsimtohousehold_data)
                    {
                        sim = null;
                    }
                }
                Simulator.Sleep(0);
            }

            if (simd == null)
            {
                NFinalizeDeath.Assert(false, "simd is null");
                return;
            }
            if (simd.Household == addsimtohousehold_data)
            {
                NFinalizeDeath.Assert(false, "simd.Household == addsimtohousehold_data");
                return;
            }

            bool unsafeb = !IsOpenDGSInstalled 
                && NiecHelperSituation.__acorewIsnstalled__;

            if (unsafeb)
            {
                simd.mIsValidDescription = true;
                simd.IsNeverSelectable = false;

                if (simd.mSimDescriptionId == 0)
                    simd.mSimDescriptionId = NFinalizeDeath.GetRandomID();

                

                if (simd == Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription)
                {
                    simd.mFirstName = "NiecMod/Name:Arotia";
                    simd.mLastName = "NiecMod/Name:Null";

                    simd.mHairColors = new GeneticColor[4] {
                	    new GeneticColor(),
                	    new GeneticColor(),
                	    new GeneticColor(),
                	    new GeneticColor()
                    };

                    sim.mSimDescription = simd;
                    simd.mSim = sim;

                    if (!AssemblyCheckByNiec.SafeIsInstalled("OpenDGS"))
                    {
                        try
                        {
                            simd.mOutfits = new OutfitCategoryMap();

                            simd.mOutfits[OutfitCategories.Everyday] = new global::System.Collections.ArrayList()
                                .Add(new Sims3.SimIFace.CAS.SimOutfit() { mIsLoaded = true, mHandle = 1 });

                            simd.mOutfits[OutfitCategories.Naked] = new global::System.Collections.ArrayList()
                                .Add(new Sims3.SimIFace.CAS.SimOutfit() { mIsLoaded = true, mHandle = 1 });
                        }
                        catch (ResetException) { throw; }
                        catch (Exception e)
                        {
                            e.message = "";
                            e.source = null;
                            e.stack_trace = null;
                            e.trace_ips = null;
                            e.class_name = null;
                        }
                    }

                    if (ListCollon.NiecDisposedSimDescriptions != null)
                        ListCollon.NiecDisposedSimDescriptions.Remove(simd);

                    Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription = null;
                }
                else 
                    unsafeb = false;
            }
            else if (simd == Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription) 
                return;

            if (unsafeb)
            {
                NFinalizeDeath.Household_Remove(simd, false);
                NFinalizeDeath.Household_Add(addsimtohousehold_data, simd, true);
                simd.mHousehold = addsimtohousehold_data;

                NFinalizeDeath.M(Create.NiecNullSimDescription(true, false, false));

                try
                {
                    if (addsimtohousehold_data == Household.ActiveHousehold && simd.CreatedSim != null && simd.CreatedSim.mDreamsAndPromisesManager == null)
                        simd.CreatedSim.OnBecameSelectable();
                }
                catch (Exception)
                { }
            }
            else
            {
                NFinalizeDeath.Household_Add(addsimtohousehold_data, simd, false);
                simd.IsNeverSelectable = false;

                try
                {
                    if (addsimtohousehold_data == Household.ActiveHousehold && simd.CreatedSim != null && simd.CreatedSim.mDreamsAndPromisesManager == null)
                        simd.CreatedSim.OnBecameSelectable();
                }
                catch (Exception)
                { }
            }

            if (addsimtohousehold_data == Household.ActiveHousehold)
                NFinalizeDeath.Household_RefrashAllActors(addsimtohousehold_data);

        }
        public static
            void addsimtohousehold_command()
        {
            
            var addsimtohousehold_data = Household.ActiveHousehold;
            if (addsimtohousehold_data == null)
                return;

            if (!Simulator.CheckYieldingContext(false))
                return;

            NFinalizeDeath.RemoveNullForHouseholdMembers(addsimtohousehold_data);

            var sim = HitTargetSim();
            if (sim == null)
                return;

            var simd = sim.mSimDescription;
            if (simd == null)
                return;

            if (simd.Household == addsimtohousehold_data)
                return;

            bool unsafeb = !IsOpenDGSInstalled && NiecHelperSituation.__acorewIsnstalled__;
            if (unsafeb)
            {
                simd.mIsValidDescription = true;
                simd.IsNeverSelectable = false;

                if (simd.mSimDescriptionId == 0)
                    simd.mSimDescriptionId = NFinalizeDeath.GetRandomID();

                if (simd == Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription)
                {
                    sim.mSimDescription = simd;
                    simd.mSim = sim;

                    simd.mFirstName = "NiecMod/Name:Arotia";
                    simd.mLastName = "NiecMod/Name:Null";

                    simd.mHairColors = new GeneticColor[4] {
                	    new GeneticColor(),
                	    new GeneticColor(),
                	    new GeneticColor(),
                	    new GeneticColor()
                    };

                    if (ListCollon.NiecDisposedSimDescriptions != null)
                        ListCollon.NiecDisposedSimDescriptions.Remove(simd);

                    Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription = null;
                }
                else
                    unsafeb = false;
            }
            else if (simd == Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription)
                return;

            if (unsafeb)
            {
                NFinalizeDeath.Household_Remove(simd, false);
                NFinalizeDeath.Household_Add(addsimtohousehold_data, simd, false);
                simd.mHousehold = addsimtohousehold_data;

                NFinalizeDeath.M(Create.NiecNullSimDescription(true, false, false));

                try
                {
                    if (simd.Household == Household.ActiveHousehold && simd.CreatedSim != null && simd.CreatedSim.mDreamsAndPromisesManager == null)
                        simd.CreatedSim.OnBecameSelectable();
                }
                catch (Exception)
                { }
            }
            else
            {
                NFinalizeDeath.Household_Add(addsimtohousehold_data, simd, false);
                simd.IsNeverSelectable = false;

                try
                {
                    if (simd.Household == Household.ActiveHousehold && simd.CreatedSim != null && simd.CreatedSim.mDreamsAndPromisesManager == null)
                        simd.CreatedSim.OnBecameSelectable();
                }
                catch (Exception)
                { }
            }

            NFinalizeDeath.Household_RefrashAllActors(addsimtohousehold_data);
        }

        public static 
            void loadsimdesc10_command()
        {
            Simulator.CheckYieldingContext(true);
            ResourceKey result = default(ResourceKey);
            var text = StringInputDialog.Show("NiecMod", "Resource Key", noPSaveSimDesc ?? "", 256, StringInputDialog.Validation.None);
            int isl = 115;
            if (ResourceKey.Parse(text, ref result))
            {
                Household household = null;
                try
                {
                    if (NFinalizeDeath.GetLotHouseholdLeft02() == 0)
                    {
                        household = Household.ActiveHousehold;
                    }
                }
                catch (Exception)
                {}
                
                if (World.ResourceExists(result))
                {
                    int ix;
                    int.TryParse(
                           StringInputDialog.Show(
                               "NiecMod", "Count?", "", StringInputDialog.Validation.None
                           ),
                           out ix
                    );
                    if (ix < 0 || ix == 0) return;
                    ulong idsimdesc = NFinalizeDeath.GetRandomID(); //(ulong)(NFinalizeDeath.Random_GetFloat(1576, 4740000, null) * NFinalizeDeath.Random_GetFloat(531, 154449, null) / NFinalizeDeath.Random_GetFloat(64, 6746565, null));
                    idsimdesc -= 1055011;
                    for (int i = 0; i < ix; i++)
                    {
                        Simulator.Sleep(0);
                        if (ix > 40)
                        {
                            for (int vi = 0; vi < isl; vi++)
                            {
                                Simulator.Sleep(0);
                            }
                            isl += 5;
                        }
                        SimDescription newSimDesc = NFinalizeDeath.SimDesc_Empty(null);

                        ResourceKeyContentCategory categoryInstalled = ResourceKeyContentCategory.kInstalled;
                        //ResourceKeyContentCategory categoryUserCreated = ResourceKeyContentCategory.kUserCreated;

                        bool checkerror;
                        try
                        {
                            checkerror = DownloadContent.ImportSimDescription(result, newSimDesc, ref categoryInstalled);
                            newSimDesc.UpdateFromOutfit(OutfitCategories.Everyday);
                        }
                        catch
                        {
                            NFinalizeDeath.SimDescCleanse(newSimDesc, true, false);
                            break;
                        }
                        
                        //if (DownloadContent.ImportSimDescription(result, newSimDesc, ref categoryInstalled))
                        //|| DownloadContent.ImportSimDescription(result, newSimDesc, ref categoryUserCreated))
                        if (checkerror)
                        {
                            NFinalizeDeath.SimDesc_SetID(newSimDesc, idsimdesc++);
                            newSimDesc.mHomeWorld = GameUtils.GetCurrentWorld();

                            if (household == null)
                            {
                                household = Household.Create(true);
                                household.Name = newSimDesc.mLastName;
                                //for (OutfitCategories i = 0; i < length; i++)


                                Create.AutoMoveInLotFromHousehold(household);
                            }

                            //household.Add(newSimDesc);
                            NFinalizeDeath.Household_Add(household, newSimDesc, true);


                            Sim checkSim;
                            try
                            {
                                checkSim = newSimDesc.Instantiate(World.SnapToFloor(CameraController.GetTarget()), IsOpenDGSInstalled);
                            }
                            catch
                            {
                                NFinalizeDeath.Household_Remove(newSimDesc, true);
                                NFinalizeDeath.SimDescCleanse(newSimDesc, true, false);
                                if (household.mMembers.mAllSimDescriptions.Count == 0)
                                    NFinalizeDeath.HouseholdCleanse(household, false, true);
                                break;
                            }

                            if (!IsOpenDGSInstalled && household.mMembers.mAllSimDescriptions.Count == 1 && NiecSocialWorkerChildAbuseSituation.IsHouseholdOnlyChildOrPet(household))
                            {
                                var csd = NFinalizeDeath.CreateRandomSimDescription();
                                //household.Add(csd);
                                NFinalizeDeath.Household_Add(household, csd, false);
                                NFinalizeDeath.SimDesc_SafeInstantiate(csd, World.SnapToFloor(CameraController.GetTarget()));

                            }


                            NFinalizeDeath.UnSafeRemoveOutfitsExEveryday(newSimDesc);
                            NFinalizeDeath.UnSafeEverydayToAddOtherOutfits(newSimDesc, true);
                        }
                        else
                        {
                            NFinalizeDeath.SimDescCleanse(newSimDesc, true, false);
                            break;
                        }
                    }
                    if (!IsOpenDGSInstalled)
                    {
                        Commom.Proxies.HouseholdContentsProxy.NExportHousehold
                            (Bin.Singleton, household, false, false, true, false);
                    }
                }
                else SimpleMessageDialog.Show("NiecMod", "Could not find Resource Key.\n" + result);
            }
            else SimpleMessageDialog.Show("NiecMod", "Text is invalid.");
        }



        public static bool IsVisibleTreatmentsController()
        {
            if (Sims3.UI.Hud.BorderTreatmentsController.sInstance != null)
            {
               return Sims3.UI.Hud.BorderTreatmentsController.sInstance.Visible;
            }
            return false;
        }


        public static
            void allfdp_Command()
        {
            var a = NFinalizeDeath.CheckAccept("Posture Safe?");
            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (item == null) 
                    continue;

                var pa = item.Parent as GameObject;
                if (pa != null)
                {
                    NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(pa, true);
                }

                NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(item, true);

                if (a)
                {
                    item.mPosture = item.Standing;
                }
            }
        }

        

        public static
           int OnRunCommands(object[] parameters) 
        {
            //try
            //{
            //    System.Runtime.InteropServices.Marshal.ReadInt64((IntPtr)0xFFEEAC21);
            //}
            //catch (Exception ex)
            //{
            //    if (ex is ArgumentException)
            //    {
            //        ex.stack_trace = null;
            //        ex.message = "EA Failed";
            //        ex.trace_ips = null;
            //    }
            //}
            //if (Simulator.CheckYieldingContext(false))
            //    AllCommandI(parameters);
            //else
            //{
            //    object o = null;
            //    object oc = null;
            //    Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Task, delegate { if (o == null || oc == null) AllCommandI(parameters); });
            //    //new NiecTask(executeType, func).AddToSimulator();
            //}
            return AllCommandI(parameters);
        }
        public static 
            int AllCommandI(object[] parameters)
        {
            //const string textC = "test";
            //string textCC = " GC BUG ";
            //const int dss = 0;
            //object objN = null;
            if (parameters == null || parameters.Length == 0) return GetCommandHelp();
            //object objC = new object();
            
            
            global::Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Task, delegate
            {
                //if (objN == null)
                //    NFinalizeDeath.M(textC + textCC + dss.ToString());
                //if (parameters == null || parameters.Length == 0) { GetCommandHelp(); return; }
                if (parameters != null && (parameters[0] is string)) {
                    string temp = (parameters[0] as string).ToLower();
                    if (temp == "ltrimhouse") {
                        ltrimhouse_bb = !ltrimhouse_bb;
                    }
                    else if (temp == "csc") {
                        csc_command();
                    }
                    else if (temp == "simu2f")
                    {
                        simu2f_command(true);
                    }
                    else if (temp == "excashousehold")
                    {
                        excashousehold_Command();
                    }
                    else if (temp == "allfdp")
                    {
                        allfdp_Command();
                    }
                    else if (temp == "psloop") { psloop_Command(); }
                    else if (temp == "clc")
                    {
                        clc_command();
                    }
                    else if (temp == "rfhlot")
                    {
                        NFinalizeDeath.FixUpHouseholdListObjects(false);
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                        {
                            NFinalizeDeath.Household_ForceMoveOut(item);
                        }
                        try
                        {
                            foreach (var item in Household.sHouseholdList)
                            {
                                NFinalizeDeath.Household_ForceMoveOut(item);
                            }
                        }
                        catch (Exception)
                        { Simulator.Sleep(1); }

                        NFinalizeDeath.MoveOutAllHousehold();
                        Create.AutoMoveInLotFromHousehold(Household.ActiveHousehold);
                        Create.AutoMoveInLotFromHousehold(NFinalizeDeath.ActiveHousehold);
                        NFinalizeDeath.ForceAllMoveIn(null);
                        //foreach (var item in NFinalizeDeath.SC_GetObjects<TempSetActiveActorAndHousehold>())
                        //{
                        //    item.Dispose();
                        //}
                    }
                    else if (temp == "dreslist")
                    {
                        dreslist_Command();
                    }
                    else if (temp == "fhlot")
                    {
                        NFinalizeDeath.FixUpAllHouseholdNoLotHome();
                    }
                    else if (temp == "unsafesmcsmcpro")
                    {
                        unsafesmcsmcpro_command();
                    }
                    else if (temp == "maxmood")
                    {
                        maxmood_command();
                    }
                    else if (temp == "hmh")
                    {
                        if (hmhHousehold == null)
                        {
                            var hmhSimv = HitTargetSim();
                            if (hmhSimv != null)
                            {
                                hmhHousehold = hmhSimv.Household;
                            }
                        }
                        else
                        {
                            if (!Simulator.CheckYieldingContext(false)) return;
                            SimDescription simd = Create.FindDescOrTargetSimDesc(0, 0, true);
                            if (simd != null)
                            {
                                var simdHH = simd.Household;
                                if (simdHH != null)
                                {
                                    if (simdHH != hmhHousehold && (!simdHH.IsSpecialHousehold || NFinalizeDeath.CheckAccept("simdHH Is Special Household Run?")))
                                        NFinalizeDeath.MergeHousehold(simdHH, hmhHousehold, true);
                                    hmhHousehold = null;
                                }
                                else { hmhHousehold = null; SimpleMessageDialog.Show("NiecMod", "SimDesc doesn't have a household!"); }
                            }
                            else { hmhHousehold = null; SimpleMessageDialog.Show("NiecMod", "Could not find sim desc."); }
                        }
                    }
                    else if (temp == "ahmh")
                    {
                        if (!Simulator.CheckYieldingContext(false)) return;
                        var ah = NFinalizeDeath.ActiveHousehold;
                        if (ah == null)
                            return;

                        SimDescription simd = Create.FindDescOrTargetSimDesc(0, 0, true);
                        if (simd != null)
                        {
                            var simdHH = simd.Household;
                            if (simdHH != null)
                            {
                                if (simdHH != ah && (!simdHH.IsSpecialHousehold || NFinalizeDeath.CheckAccept("simdHH Is Special Household Run?")))
                                    NFinalizeDeath.MergeHousehold(simdHH, ah, true);
                            }
                            else SimpleMessageDialog.Show("NiecMod", "SimDesc doesn't have a household!");
                        }
                        else SimpleMessageDialog.Show("NiecMod", "Could not find sim desc.");
                    }
                    else if (temp == "addsimtohousehold2") { addsimtohousehold2_command(); }
                    else if (temp == "fixsimbad") { NFinalizeDeath.FixUpSimIsBad(null); }
                    else if (temp == "ctl")
                    {
                        TempSetActiveActor nte = IsOpenDGSInstalled ? null : new TempSetActiveActor();
                        foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                        {
                            if (item == null)
                                continue;

                            if (!item.IsValidDescription)
                                continue;

                            if (NFinalizeDeath.IsNullOrEmpty(item.mFirstName) && NFinalizeDeath.IsNullOrEmpty(item.mLastName))
                                continue;

                            var tm = item.TraitManager;
                            if (tm != null && tm.mValues != null)
                            {
                                try
                                {
                                    var tmList = tm.List;
                                    if (tmList != null && !IsOpenDGSInstalled)
                                    {
                                        using (TempSetActiveActor.SetAndRun(nte, item.CreatedSim ?? NFinalizeDeath.GetRandomSim() ?? NFinalizeDeath.ActiveActor))
                                        {
                                            tm.mSimDescription = item;
                                            foreach (Trait itemTrait in new List<Trait>(tmList))
                                            {
                                                tm.RemoveTraitEffects(item, itemTrait.Guid);
                                                tm.RemoveElement(itemTrait.Guid);
                                            }
                                        }
                                    }

                                    var tmRT = tm.RewardTraits;
                                    if (tmRT != null)
                                        tmRT.Clear();

                                    tm.RemoveAllElements();
                                }
                                catch (StackOverflowException) { throw; }
                                catch (ResetException) { throw; }
                                catch (Exception) { if (IsOpenDGSInstalled) throw; }

                            }
                        }
                        if (ListCollon.NiecSimDescriptions.Count > 0 && NFinalizeDeath.CheckAccept("New Trait"))
                        {
                            foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                            {
                                if (item == null)
                                    continue;

                                if (!item.IsValidDescription)
                                    continue;

                                if (NFinalizeDeath.IsNullOrEmpty(item.mFirstName) && NFinalizeDeath.IsNullOrEmpty(item.mLastName))
                                    continue;

                                var tm = item.TraitManager;
                                if (tm != null && tm.mValues != null)
                                    Genetics.AssignRandomTraits(item);
                            }
                        }

                    }
                    else if (temp == "finddelvaild")
                    {
                        var simDesc = NFinalizeDeath.ActiveActor_SimDescription;
                        foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                        {
                            if (item == null || item == simDesc) continue;
                            if (item.mHairColors == null)
                                NFinalizeDeath.SimDescCleanse(item, true, false);
                        }
                    }
                    else if (temp == "fakeh")
                    {
                        Sim sim = HitTargetSim();
                        if (sim == null)
                            return;

                        var simDescSim = sim.SimDescription;
                        if (simDescSim == null)
                            return;

                        Sim activeActor = PlumbBob.SelectedActor;
                        if (activeActor == null)
                            return;

                        var simDescActiveActor = activeActor.SimDescription;
                        if (simDescActiveActor == null)
                            return;

                        NFinalizeDeath.FakeHousehold(simDescSim, simDescActiveActor);

                        // Keep DreamsAndPromisesManager
                        PlumbBob.sCurrentNonNullHousehold = NFinalizeDeath.ActiveHousehold;

                        for (int i = 0; i < 2; i++)
                        {
                            PlumbBob.SelectActor(activeActor);
                        }

                    }
                    else if (temp == "tsimcopyh")
                    {
                        Household ah = Household.ActiveHousehold;
                        if (ah == null) return;
                        NFinalizeDeath.RemoveNullForHouseholdMembers(ah);
                        Sim sim = HitTargetSim();
                        if (sim == null || sim.Household == null)
                            return;
                        var copyHousehold = NFinalizeDeath.Household_CloneHousehold(sim.Household, NFinalizeDeath.CheckAccept("Delete File?"));
                        if (copyHousehold == null)
                            return;
                        NFinalizeDeath.MergeHousehold(copyHousehold, ah, true);
                    }
                    else if (temp == "csimdescl")
                    {
                        var simListOld = NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray();
                        if (simListOld.Length == 0) return;
                        var simListNew = NFinalizeDeath.CopyFullSimDesc();
                        if (simListNew == null || simListNew.Count == 0)
                            return;

                        if (NFinalizeDeath.CheckAccept("Safe"))
                        {
                            foreach (var itemNew in simListNew)
                            {
                                if (itemNew.LotHome == null) break;
                                NFinalizeDeath.SimDesc_SafeInstantiate(itemNew, NFinalizeDeath.Vector3_OutOfWorld);
                            }
                            return;
                        }
                        else if (NFinalizeDeath.CheckAccept("Trim Household List?"))
                        {
                            NFinalizeDeath.TrimHouse(10);
                            foreach (var itemNew in simListNew)
                            {
                                if (itemNew.LotHome == null) continue;
                                NFinalizeDeath.SimDesc_SafeInstantiate(itemNew, NFinalizeDeath.Vector3_OutOfWorld);
                            }
                            return;
                        }
                        else
                        {
                            foreach (var itemOld in simListOld)
                            {
                                if (itemOld == null || itemOld.Household == null) continue;
                                foreach (var itemNew in simListNew)
                                {
                                    if (itemNew == null) continue;
                                    if (itemOld.mFirstName == itemNew.mFirstName && itemOld.mLastName == itemNew.mLastName)
                                    {
                                        NFinalizeDeath.Household_Add(itemOld.Household, itemNew, true);
                                        if (itemNew.LotHome != null)
                                            NFinalizeDeath.SimDesc_SafeInstantiate(itemNew, NFinalizeDeath.Vector3_OutOfWorld);
                                    }
                                }
                            }
                        }
                    }
                    else if (temp == "looptargetdied") { looptargetdied_Command(); }
                    else if (temp == "dsauto")
                    {
                        Sim targetSim = HitTargetSim();
                        if (targetSim != null && targetSim.Autonomy != null)
                        {
                            if (NotificationManager.Instance != null)
                                NiecException.PrintMessagePro("Autonomy Disabled Count: " + targetSim.Autonomy.mAutonomyDisabledCount + "\nAutonomy Enabled: " + NFinalizeDeath.debug_AutoMCan(targetSim.Autonomy) + "\nInAutonomyManagerQueue: " + targetSim.Autonomy.InAutonomyManagerQueue, false, 100);
                            else
                                SimpleMessageDialog.Show("NiecMod", "Autonomy Disabled Count: " + targetSim.Autonomy.mAutonomyDisabledCount + "\nAutonomy Enabled: " + NFinalizeDeath.debug_AutoMCan(targetSim.Autonomy) + "\nInAutonomyManagerQueue: " + targetSim.Autonomy.InAutonomyManagerQueue);
                        }
                    }
                    else if (temp == "loopaadied2f")
                    {
                        looppaa2bool = !looppaa2bool;
                        NiecException.PrintMessagePro("looppaa2boolf: " + looppaa2bool, false, 100);
                    }
                    else if (temp == "maxmoodloop")
                    {
                        maxmoodloop_command();
                    }
                    else if (temp == "forcesetaa3")
                    {
                        forcesetaa3_Command(null, false, false);
                    }
                    else if (temp == "forcesetaa4")
                    {
                        forcesetaa3_Command(null, true, true);
                    }
                    else if (temp == "ddsd")
                    {
                        var fouent = ListCollon.NiecDisposedSimDescriptions;
                        if (fouent == null || fouent.Count == 0)
                        {
                            if (NotificationManager.Instance != null)
                                NiecException.PrintMessagePro("Dispose sim desc list is empty.", false, 100);
                            else
                                SimpleMessageDialog.Show("NiecMod", "Dispose sim desc list is empty.");
                        }
                        else
                        {
                            if (NotificationManager.Instance != null)
                                NiecException.PrintMessagePro("SimDesc Disposed: " + fouent.Count, false, 100);
                            else
                                SimpleMessageDialog.Show("NiecMod", "SimDesc Disposed: " + fouent.Count);
                        }
                    }
                    else if (temp == "nre")
                    {
                        var fouent = Sims3.NiecHelp.Tasks.NiecTask.ErrorRuntimeFound;
                        if (fouent == null || fouent.Length == 0)
                        {
                            NiecException.PrintMessagePro("There are no Runtime errors.", false, 100);
                        }
                        else
                        {
                            NiecException.WriteLog(fouent.ToString());
                            NiecException.PrintMessagePro("NiecTask: Runtime errors found: " + fouent.Length + "\nShow Script Error File.\nError Data Cleared", false, 100);
                            Sims3.NiecHelp.Tasks.NiecTask.ErrorRuntimeFound = new StringBuilder();
                        }
                    }
                    else if (temp == "testlist")
                    {
                        Sim simobj = HitTargetSim();
                        if (simobj != null)
                        {
                            List<Situation> outsitList;
                            if (NFinalizeDeath.CanAddSituation(simobj, null, out outsitList) && outsitList != null)
                            {
                                NiecException.PrintMessagePro
                                        ("ListSize: " + outsitList._size + "\nListLength: " + outsitList._items.Length, false, 100);
                                //NFinalizeDeath.TestFixList(outsitList);
                            }
                        }
                    }
                    else if (temp == "loopreappet")
                    {
                        loopreappet_command();
                    }
                    else if (temp == "sdnoage")
                    {
                        int myAge = -264;
                        foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                        {
                            if (item == null)
                                continue;

                            if (!item.IsValidDescription)
                                continue;

                            if (NFinalizeDeath.IsNullOrEmpty(item.mFirstName) && NFinalizeDeath.IsNullOrEmpty(item.mLastName))
                                continue;

                            if (item.AgingState != null)
                            {
                                int simDesc_Age;
                                int simDesc_maxAge;

                                NFinalizeDeath.SimDesc_GetAging(item, out simDesc_Age, out simDesc_maxAge);

                                simDesc_Age = myAge;
                                if (item.Age != CASAgeGenderFlags.Elder && myAge > simDesc_maxAge)
                                {
                                    simDesc_Age = simDesc_maxAge;
                                }

                                NFinalizeDeath.SimDesc_SetAging(item, simDesc_Age, true);
                            }
                        }
                    }
                    else if (temp == "minecnpro") { NFinalizeDeath.sims3NameToMinecraftNamePlayer(NFinalizeDeath.CheckAccept("forcesp")); }
                    else if (temp == "devc") { DEBUG_ETCount(); }
                    else if (temp == "usev") { usev_Command(false, false); }
                    else if (temp == "rallrlot") { RemoveSafeAllCleanLotData(); }
                    else if (temp == "nstload")
                    {
                        var nRun = DGSMODS_Func_stload;
                        if (nRun != null)
                        {
                            nRun();
                        }
                        else SimpleMessageDialog.Show("NiecMod", " DGSMODS_Func_stload not found.");
                    }
                    else if (temp == "hhr2")
                    {
                        var hhlist = Household.sHouseholdList;
                        if (hhlist == null)
                            return;

                        //if (NFinalizeDeath.CheckAccept("NFinalizeDeath.TestFixList(hhlist);"))
                        //    NFinalizeDeath.TestFixList(hhlist);

                        var householdTempList = new List<Household>();
                        foreach (var item in hhlist)
                        {
                            if (item == null)
                                continue;
                            if (householdTempList.Contains(item))
                                continue;

                            householdTempList.Add(item);
                        }

                        try
                        {
                            hhlist.Clear();
                        }
                        catch
                        { }

                        hhlist = Household.sHouseholdList = new List<Household>();

                        NFinalizeDeath.Assert(Household.sHouseholdList != null, "Household.sHouseholdList == null");

                        foreach (var item in householdTempList)
                        {
                            hhlist.Add(item);
                        }

                        NFinalizeDeath.FixHouseholdList();
                        NFinalizeDeath.FixUpHouseholdListObjects(false);
                    }
                    else if (temp == "ndgstfa")
                    {
                        if (IsOpenDGSInstalled || GameStates.IsInMainMenuState)
                            return;

                        var hhlist = Household.sHouseholdList ?? (Household.sHouseholdList = new List<Household>());
                        NFinalizeDeath.Assert(hhlist != null, "Household.sHouseholdList == null");

                        if (NFinalizeDeath.CheckAccept("Remove 2000"))
                        {
                            if (NFinalizeDeath.CheckAccept("Household Remove 2"))
                            {
                                var householdTempList = new List<Household>();
                                foreach (var item in hhlist)
                                {
                                    if (item == null)
                                        continue;
                                    if (householdTempList.Contains(item))
                                        continue;

                                    householdTempList.Add(item);
                                }

                                try
                                {
                                    hhlist.Clear();
                                }
                                catch
                                {
                                    hhlist = Household.sHouseholdList = new List<Household>();
                                }

                                foreach (var item in householdTempList)
                                {
                                    hhlist.Add(item);
                                }

                                NFinalizeDeath.FixUpHouseholdListObjects(false);
                            }
                            else
                            {
                                while (hhlist.Remove(Household.NpcHousehold)) { }
                                while (hhlist.Remove(Household.ActiveHousehold)) { }
                                hhlist.Add(Household.NpcHousehold);
                                hhlist.Add(Household.ActiveHousehold);
                            }
                            while (hhlist.Remove(null)) { }
                            return;
                        }

                        short i;
                        var npcHousehold = Household.NpcHousehold;
                        if (npcHousehold != null)
                        {
                            for (i = 0; i < 1000; i++)
                            {
                                hhlist.Add(npcHousehold);
                            }
                        }
                        if (NFinalizeDeath.CheckAccept("UnSafe"))
                        {
                            NFinalizeDeath.Assert(PlumbBob.Singleton != null, "PlumbBob.Singleton == null 1");

                            var activeActor = PlumbBob.SelectedActor;
                            var vTSAAAH = new TempSetActiveActorAndHousehold();

                            for (i = 0; i < 1500; i++)
                            {
                                using (TempSetActiveActorAndHousehold.SetAndRun(vTSAAAH, NFinalizeDeath.GetRandomSim() ?? activeActor))
                                {
                                    var hh = Household.ActiveHousehold;
                                    if (hh != null)
                                        hhlist.Add(hh);
                                }
                            }

                            NFinalizeDeath.Assert(PlumbBob.Singleton != null, "PlumbBob.Singleton == null 2");

                            if (PlumbBob.Singleton != null && NFinalizeDeath.CheckAccept("SelectActor?"))
                            {
                                if (activeActor != null)
                                {
                                    PlumbBob.Singleton.mSelectedActor = activeActor;
                                    PlumbBob.sCurrentNonNullHousehold = activeActor.Household;

                                    for (i = 0; i < 3; i++)
                                    {
                                        if (!PlumbBob.SelectActor(activeActor))
                                        {
                                            PlumbBob.ForceSelectActor(activeActor);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    PlumbBob.Singleton.mSelectedActor = null;
                                    PlumbBob.sCurrentNonNullHousehold = null;
                                    PlumbBob.ForceSelectActor(null);
                                }
                            }
                        }
                        else if (Household.ActiveHousehold != null)
                        {
                            for (i = 0; i < 1000; i++)
                            {
                                hhlist.Add(Household.ActiveHousehold);
                            }
                        }
                        while (hhlist.Remove(null)) { }
                    }
                    else if (temp == "tevcopy")
                    {
                        tevcopy_command();
                    }
                    else if (temp == "ndgstf")
                    {
                        if (IsOpenDGSInstalled) return;
                        if (nonopendgslistObject01 == null) nonopendgslistObject01 = new List<ObjectGuid>();
                        if (nonopendgslistObject01.Count > 170)
                        {
                            foreach (var item in nonopendgslistObject01.ToArray())
                            {
                                Simulator.DestroyObject(item);
                            }
                            nonopendgslistObject01.Clear();
                        }
                        else
                        {
                            for (int i = 0; i < 200; i++)
                            {
                                nonopendgslistObject01.Add(Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Threaded, NFinalizeDeath.LoopReAllNHSOnTick));
                            }
                        }
                    }
                    else if (temp == "gccollect")
                    {
                        GC.Collect();
                    }
                    else if (temp == "simssp")
                    {
                        ActorSimDesc_Switch_TargetSimDescP(HitTargetSim());
                    }
                    else if (temp == "simss")
                    {
                        Sim SimActor = PlumbBob.SelectedActor;
                        if (SimActor == null)
                            return;

                        Sim SimTarget = HitTargetSim();
                        if (SimTarget == null)
                            return;

                        ActorSimDesc_Switch_TargetSimDesc(SimActor, SimTarget);
                    }
                    else if (temp == "acss")
                    {
                        ActiveActorSimDesc_Switch_TargetSimDesc(HitTargetSim());
                    }
                    else if (temp == "autosave")
                    {
                        if (autosave_ObjectID == NiecInvalidObjectGuid)
                        {
                            NiecException.PrintMessagePro("Auto Save Task Created", false, 100);
                            autosave_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                            {
                            e: Simulator.Sleep(0);
                                if (GameStates.IsBlueprintState || GameStates.IsBuildState || GameStates.IsBuyState)
                                {
                                    while (true)
                                    {
                                        for (int i = 0; i < 6000; i++)
                                        {
                                            Simulator.Sleep(0);
                                        }
                                        Simulator.Sleep(0);
                                        try
                                        {
                                            if (GameStates.IsBlueprintState || GameStates.IsBuildState || GameStates.IsBuyState)
                                                NFinalizeDeath.AutoSave();
                                            else goto e;
                                        }
                                        catch (ResetException)
                                        { throw; }
                                        catch { }

                                    }
                                }
                                else
                                {
                                    while (true)
                                    {
                                        Simulator.Sleep(23050);
                                        try
                                        {
                                            if (GameStates.IsBlueprintState || GameStates.IsBuildState || GameStates.IsBuyState) { goto e; }
                                            else
                                                NFinalizeDeath.AutoSave();
                                        }
                                        catch (ResetException)
                                        { throw; }
                                        catch { }

                                    }
                                }
                            });
                        }
                        else { NiecException.PrintMessagePro("Auto Save Task Removed", false, 100); NFinalizeDeath.RemoveTaskFromSimulator(ref autosave_ObjectID); }
                    }
                    else if (temp == "allresetsim") { allresetsim_command(); }
                    else if (temp == "allinvsim") { allinvsim_command(); }
                    else if (temp == "nhsnoah")
                    {
#if AddCodeIsOpenDGSInstalled 
                        if (IsOpenDGSInstalled)
#else
                        if (!NiecHelperSituation.__acorewIsnstalled__)
#endif
                        {
                            NiecHelperSituation._bNoActiveHousehold = !NiecHelperSituation._bNoActiveHousehold;
                            NiecException.PrintMessagePro("NHS NoActiveHousehold: " + NiecHelperSituation._bNoActiveHousehold, false, 50f);
                        }
                    }
                    else if (temp == "nhsaht")
                    {
                        if (IsOpenDGSInstalled)
                        {
                            NiecHelperSituation._bTargetNoActiveHouseholdExAA = !NiecHelperSituation._bTargetNoActiveHouseholdExAA;
                            NiecException.PrintMessagePro("NHS\nTargetDiedNoAHExAA: " + NiecHelperSituation._bTargetNoActiveHouseholdExAA, false, 50f);
                        }
                    }
                    else if (temp == "forcesetaa")
                    {
                        if (GameStates.IsLiveState)
                        {
                            if (global:: ScriptCore.World.World_IsEditInGameFromWBModeImpl())
                            {
                                if (NFinalizeDeath.ActiveActor == null)
                                    PlumbBob.sCurrentNonNullHousehold = null;
                                if (!AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                                {
                                    if (PlumbBob.sSingleton != null)
                                    {
                                        Sim Target = HitTargetSim();
                                        if (Target == null && NFinalizeDeath.CheckAccept("HitTargetSim: Failed Random Sim?"))
                                        {
                                            List<Sim> list = new List<Sim>();
                                            foreach (Sim actora in NFinalizeDeath.SC_GetObjects<Sim>())
                                            {
                                                try
                                                {
                                                    if (actora == null) continue;
                                                    SimDescription simd = actora.SimDescription;
                                                    if (simd == null) continue;
                                                    //if (!simd.IsHuman) continue;

                                                    if (simd.Household == null) continue;
                                                    if (!actora.IsInActiveHousehold)
                                                    {
                                                        list.Add(actora);
                                                    }
                                                }
                                                catch (ResetException) { throw; }
                                                catch
                                                { }
                                            }
                                            if (list.Count > 0)
                                                Target = RandomUtil.GetRandomObjectFromList(list);
                                        }
                                        PlumbBob.sSingleton.mSelectedActor = Target;
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        Type type = Type.GetType("Sims3.Gameplay.Moded.DGSHelperCommandsNoStatic, Sims3GameplaySystems");
                                        if (type != null)
                                        {
                                            FieldInfo mField = type.GetField("kFakeActiveActor", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                            if (mField != null)
                                            {
                                                mField.SetValue(null, true);
                                                mField = type.GetField("kDGSPlayerTwo", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                                if (mField != null)
                                                {
                                                    mField.SetValue(null, false);
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    { }

                                    Type typxe = Type.GetType("Sims3.Gameplay.Core.PlumbBob, Sims3GameplaySystems");
                                    if (typxe != null)
                                    {
                                        FieldInfo mFieldx = typxe.GetField("dgs_simcache", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                                        if (mFieldx != null)
                                        {
                                            mFieldx.SetValue(null, HitTargetSim());

                                        }
                                    }
                                }
                            }
                            else
                            {
                                Sim Target = HitTargetSim();
                                if (Target != null)
                                { NFinalizeDeath.ActiveActor = Target; PlumbBob.ForceSelectActor(Target); }
                                else if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Are you sure PlumbBob.ForceSelectActor(null)"))
                                {
                                    NFinalizeDeath.ActiveActor = null;
                                    PlumbBob.ForceSelectActor(null);
                                    PlumbBob.sCurrentNonNullHousehold = null;
                                }
                            }
                        }
                    }
                    /*
                    EIP : 00E549DC     ts3w.00E549DC 00E5488C / EIP : 00E5490A     ts3w.00E5490A 00E54A11

                    System.ExecutionEngineException: Unimplemented opcode
                    #0: 0x00000 superop    in NiecMod.Helpers.NiecRunCommand+<>c__DisplayClass#+...:<AllCommand>b__# () ()
                    #1: 0x00000            in Sims3.NiecHelp.Tasks.NiecNraTask+NraFunction:Invoke () ()
                    #2: 0x00007 leave.s    in Sims3.NiecHelp.Tasks.Sims3.NiecHelp.Tasks.NiecTask:Simulate () ()
                     */
                    else if (temp == "testcpu")
                    {
                        //if (!GameUtils.IsSingleThreadedMode()) {
                        //    NiecException.PrintMessagePro("Need Single Threaded Mode", false, 10);
                        //}
                        Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                        {
                            SimpleMessageDialog.Show(
                                "NiecMod", "Please Use x32dbg attach to\nTS3.exe or TS3W.exe\n" +
                                 "EIP : ???????"
                            );
                            if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("NiecMod\nToggle Debug Info?"))
                            {
                                ScriptCore.GameUtils.GameUtils_ToggleDebugInfo(true);
                                for (int i = 0; i < 100; i++)
                                {
                                    Simulator.Sleep(0);
                                }
                            }
                            string startdate = DateTime.Now.ToString();
                            try
                            {

                                long x32dbg = 0;
                                while (true)
                                {
                                    //Sleep(0);
                                    x32dbg++;
                                    //if (x32dbg > 10000000)
                                    if (x32dbg > 5000000000)
                                        break;
                                }

                            }
                            catch (StackOverflowException ex)
                            {
                                SimpleMessageDialog.Show("NiecMod", "Debugger Found :)\nResult: " + ex.Message +
                                    "\nStart Date: " + startdate + "\nEnd Date: " + DateTime.Now.ToString());
                                goto end;
                            }
                            catch (ExecutionEngineException ex)
                            {
                                SimpleMessageDialog.Show("NiecMod", "Debugger Found :)\nResult: " + ex.Message +
                                    "\nStart Date: " + startdate + "\nEnd Date: " + DateTime.Now.ToString());
                                goto end;
                            }
                            string enddate = DateTime.Now.ToString();
                            SimpleMessageDialog.Show("NiecMod", "Failed Debugger!\nStart Date: " + startdate + "\nEnd Date: " + enddate);
                        end: ;
                        });
                    }
                    else if (temp == "ustsimallpro")
                    {
                        ustsimallpro_Command();
                    }
                    else if (temp == "ddcs")
                    {
                        GameObject gameObject = HitTargetGameObject();
                        if (gameObject != null)
                        {
                            ScriptCore.TaskContext context;
                            if (!ScriptCore.TaskControl.GetTaskContext(gameObject.ObjectId.mValue, NFinalizeDeath.CheckAccept("Methods Only?"), out context))
                            {
                                NiecException.PrintMessagePro("Get Task Context Failed!", false, 10);
                                return;
                            }
                            string debug_mFrames = "Frames: " + (context.mFrames != null);
                            string debug_mNativeYieldCall = "NativeYieldCall: " + context.mNativeYieldCall;
                            string debug_mSleepTicks = "SleepTicks: " + context.mSleepTicks;
                            string debug_mYieldCallback = "YieldFunc: " + NFinalizeDeath.GetCallbackToString(context.mYieldCallback);
                            string debug_mYieldedMethodHandle = "YieldMHandle: " + NFinalizeDeath.GetRuntimeMethedToString(context.mYieldedMethodHandle);
                            string debug_all = debug_mFrames +
                                        "\n" + debug_mNativeYieldCall +
                                        "\n" + debug_mSleepTicks +
                                        "\n" + debug_mYieldCallback +
                                        "\n" + debug_mYieldedMethodHandle + "\n";
                            string tempb = "DDS:\n" + debug_all;
                            NiecException.PrintMessagePro(tempb, true, 1000);
                            NiecException.WriteLog(tempb);
                        }
                    }
                    else if (temp == "miexh")
                    {
                        niec_std.mono_runtime_install_handlers();
                    }
                    else if (temp == "fnsptrimhouse")
                    {
                        fnsptrimhouse_command();
                    }
                    else if (temp == "testassert")
                    {
                        testassert_command();
                    }
                    else if (temp == "setfunctest") { setfunctest_commnad(); }
                    else if (temp == "nndsdc") { NFinalizeDeath.NiecDisposedList_Clear(); }
                    else if (temp == "targetds")
                    {
                        Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                        {
                            GameObject gameObject = HitTargetGameObject();
                            if (gameObject != null)
                            {
                                ScriptCore.TaskContext context;
                                if (!ScriptCore.TaskControl.TaskControl_GetTaskContext(gameObject.ObjectId.mValue, false, out context) || context.mFrames == null)
                                {
                                    return;
                                }
                                ScriptCore.TaskContext contextWorldLot;
                                ITask utask;
                                if (!ScriptCore.TaskControl.TaskControl_GetTaskContext(NFinalizeDeath.FindTaskPro(null, "Sims3.Gameplay.Core.Camera", out utask).mValue, false, out contextWorldLot) || contextWorldLot.mFrames == null)
                                {
                                    return;
                                }
                                // var newTaskContext = new ScriptCore.TaskContext();
                                //context.mFrames = new ScriptCore.TaskFrame[0];
                                //context.mSleepTicks = 0;
                                contextWorldLot = (ScriptCore.TaskContext)CopyTaskContext(contextWorldLot, true);
                                if (ScriptCore.TaskControl.TaskControl_SetTaskContext(gameObject.ObjectId.mValue, ref contextWorldLot))
                                    NiecException.PrintMessagePro("targetds Done :)", false, 10);
                                ScriptCore.ScriptProxy.ScriptProxy_SetResetState(gameObject.ObjectId.mValue, ScriptCore.ScriptProxy.eResetStatus.kResetRequested);
                            }
                            else if (NFinalizeDeath.CheckAccept("UnSafe All Sim"))
                            {
                                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause, false);
                                Simulator.Sleep(0);
                                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                                {
                                    if (item == null) continue;
                                    ScriptCore.TaskContext context;
                                    if (!ScriptCore.TaskControl.GetTaskContext(item.ObjectId.mValue, true, out context) || context.mFrames == null)
                                    {
                                        continue;
                                    }
                                    //var newTaskContext = new ScriptCore.TaskContext();
                                    context.mFrames = new ScriptCore.TaskFrame[0];
                                    context.mSleepTicks = 0;
                                    ScriptCore.TaskControl.SetTaskContext(item.ObjectId.mValue, ref context);
                                }
                            }
                            else if (NFinalizeDeath.CheckAccept("UnSafe All GameObject"))
                            {
                                Sims3.Gameplay.Gameflow.SetGameSpeed(Sims3.SimIFace.Gameflow.GameSpeed.Pause, false);
                                Simulator.Sleep(0);
                                foreach (var item in NFinalizeDeath.SC_GetObjects<GameObject>())
                                {
                                    if (item == null) continue;
                                    ScriptCore.TaskContext context;
                                    if (!ScriptCore.TaskControl.GetTaskContext(item.ObjectId.mValue, true, out context) || context.mFrames == null)
                                    {
                                        continue;
                                    }
                                    //var newTaskContext = new ScriptCore.TaskContext();
                                    context.mFrames = new ScriptCore.TaskFrame[0];
                                    context.mSleepTicks = 0;
                                    ScriptCore.TaskControl.SetTaskContext(item.ObjectId.mValue, ref context);
                                }
                            }
                        });
                    }
                    else if (temp == "tmnfunc3")
                    {
                        tmnfunc3_command();
                    }
                    else if (temp == "dnst")
                    {
                        NFinalizeDeath.DEBUG_NSTack();
                    }
                    else if (temp == "allbulot")
                    {
                        allbulot_Command();
                    }
                    else if (temp == "bulot")
                    {
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null && !TargetLot.IsWorldLot)
                        {
                            Sim ActiveActor = NFinalizeDeath.ActiveActor;
                            if (ActiveActor != null && ActiveActor.LotCurrent == TargetLot)
                            {
                                ActiveActor.SetPosition(Create.GetPositionInRandomLot(LotManager.GetWorldLot()));
                                try
                                {
                                    if (ActiveActor.SimRoutingComponent != null)
                                        ActiveActor.SimRoutingComponent.ForceUpdateDynamicFootprint();
                                    ActiveActor.ModifyFunds(+(Create.GetAllCostLot(TargetLot) + World.GetLotWorth(TargetLot.LotId)));
                                }
                                catch
                                { }

                            }
                            //PlumbBob bob = PlumbBob.sSingleton;
                            //int sleep = 0;
                            //foreach (var iteam in TargetLot.GetObjects<IScriptLogic>())
                            //{
                            //
                            //
                            //    if (iteam == null)
                            //        continue;
                            //    if (iteam == ActiveActor || iteam == bob)
                            //        continue;
                            //    GameObject item = iteam as GameObject;
                            //    if (item == null)
                            //        continue;
                            //    //var grave = iteam as Urnstone;
                            //    //if (grave != null)
                            //    //{
                            //    //    SimDescription DeadSimDesc = grave.DeadSimsDescription;
                            //    //    if (DeadSimDesc != null)
                            //    //    {
                            //    //        if (!NFinalizeDeath.ResuetSim
                            //    //            (DeadSimDesc, NFinalizeDeath.Find_SCGetHouseholds(grave.mOriginalHouseholdId), IsOpenDGSInstalled))
                            //    //            NFinalizeDeath.SimDescCleanse(DeadSimDesc, true, false);
                            //    //    }
                            //    //    grave.mOriginalHouseholdId = 0;
                            //    //    grave.DeadSimsDescription = null;
                            //    //}
                            //    NFinalizeDeath.ForceDestroyObject(item, false);
                            //    sleep++;
                            //    if (sleep > 350)
                            //    {
                            //        sleep = 0;
                            //        SpeedTrap.Sleep(0);
                            //    }
                            //}
                            NFinalizeDeath.DestroyAllObjectsOnLot(TargetLot, true, true, AssemblyCheckByNiec.IsInstalled("AweCore"));
                            ActiveActor = NFinalizeDeath.ActiveActor;
                            if (ActiveActor != null && ActiveActor.LotCurrent == TargetLot)
                            {
                                ActiveActor.SetPosition(Create.GetPositionInRandomLot(LotManager.GetWorldLot()));
                                try
                                {
                                    if (ActiveActor.SimRoutingComponent != null)
                                        ActiveActor.SimRoutingComponent.ForceUpdateDynamicFootprint();
                                    ActiveActor.ModifyFunds(+(Create.GetAllCostLot(TargetLot) + World.GetLotWorth(TargetLot.LotId)));
                                }
                                catch
                                { }

                            }
                            TargetLot.Bulldoze(false, true, true, false);
                        }
                    }
                    else if (temp == "resetnpchousehold") { resetnpchousehold_command(); }
                    else if (temp == "clsave") { clsave_command(); }
                    else if (temp == "dunusedsu")
                    {
                        dunusedsu_command();
                    }
                    else if (temp == "nvsc")
                    {
                        foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true))
                        {
                            try
                            {
                                NFinalizeDeath.ValidateSimCreated(item, null);
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception) { }
                        }

                    }
                    else if (temp == "rsneedhome")
                    {
                        NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true);
                        foreach (var item in ListCollon.NiecSimDescriptions)
                        {
                            if (item == null)
                                continue;
                            if (!item.IsValid)
                                continue;
                            if (!item.IsValidDescription)
                                continue;

                            NFinalizeDeath.SafeSimHaveHomeInstantiate(item);
                        }
                    }
                    else if (temp == "mrtc")
                    {
                        if (NFinalizeDeath.AutoMETask != NiecInvalidObjectGuid)
                        {
                            NFinalizeDeath.AutoMET_TimePortal.State = TimePortal.PortalState.Inactive;
                            NFinalizeDeath.AutoMET_TimePortal = GetHitTarget<TimePortal>() ?? HitTargetGameObject() as TimePortal ?? NFinalizeDeath.AutoMET_TimePortal;
                        }
                    }
                    else if (temp == "mrtr")
                    {
                        NFinalizeDeath.AutoMET_Reset();
                    }
                    else if (temp == "mrtn")
                    {
                        NFinalizeDeath.AutoMET_NTaskNeedAddToQure = !NFinalizeDeath.AutoMET_NTaskNeedAddToQure;
                    }
                    else if (temp == "mrt")
                    {
                        if (NFinalizeDeath.AutoMET_TimePortal == null)
                            if (!NFinalizeDeath.AutoMET_StartUp
                                (GetHitTarget<TimePortal>() ?? HitTargetGameObject() as TimePortal, NFinalizeDeath.CheckAccept("NATQ")))
                                SimpleMessageDialog.Show("NiecMod", "AutoMET Start Up failed!");
                    }
                    else if (temp == "mrtd")
                    {
                        NFinalizeDeath.AutoMET_ShutDown();
                    }
                    else if (temp == "autop")
                    {
                        if (autoPlayCollaner == NiecInvalidObjectGuid)
                        {
                            if (GameStates.IsInMainMenuState || !GameStates.IsLiveState) return;
                            autoPlayCollaner = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                            {
                                while (true)
                                {
                                    Simulator.Sleep(0);
                                    if (GameStates.IsInMainMenuState) { return; }
                                    Responder.Instance.ClockSpeedModel.UnlockGameSpeed();
                                    if (ScriptCore.World.World_IsEditInGameFromWBModeImpl())
                                    {
                                        ProgressDialog.Close();
                                        Sims3.UI.GameEntry.ScreenCaptureOverlay.Display(false, Simulator.CheckYieldingContext(false));
                                    }
                                    else if (!IsOpenDGSInstalled)
                                    {
                                        if (ProgressDialog.sDialog != null && Responder.Instance.OptionsModel.SaveGameInProgress)
                                        {
                                            ProgressDialog.Close();
                                            Sims3.UI.GameEntry.ScreenCaptureOverlay.Display(false, Simulator.CheckYieldingContext(false));
                                            try
                                            {
                                                (Responder.Instance.OptionsModel as Sims3.Gameplay.UI.OptionsModel).mSaveInProgress = false;
                                            }
                                            catch
                                            { }
                                        }
                                        if (GameUtils.IsPaused() && !GameStates.IsLiveState)
                                        {
                                            GameUtils.Unpause();
                                        }
                                        if (GameStates.IsCasState)
                                        {
                                            //CASUtils.CASCamera(false);
                                            CameraController.SetControllerType(CameraControllerType.Main);
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            InWorldSubState inworld = GameStates.GetInWorldSubState();
                                            if (inworld is BuildModeState || inworld is BuyModeState || inworld is BlueprintModeState)
                                            {
                                                Responder.Instance.ClockSpeedModel.UnlockGameSpeed();
                                                GameUtils.Unpause();
                                            }
                                        }
                                        catch (ResetException) { throw; }
                                        catch (Exception)
                                        {
                                            for (int isleep = 0; isleep < 150; isleep++)
                                            {
                                                Simulator.Sleep(0);
                                            }
                                        }
                                    }
                                }
                            });
                        }
                        else
                        {
                            NFinalizeDeath.RemoveTaskFromSimulator(ref autoPlayCollaner);
                        }
                    }
                    else if (temp == "looptargetdied3")
                    {
                        looptargetdied3_command();
                    }
                    else if (temp == "looptargetdied2")
                    {
                        looptargetdied2_command();
                    }
                    else if (temp == "minecn") // Minecraft Name
                    {
                        NFinalizeDeath.MineCraftName();
                    }
                    else if (temp == "fixhlist")
                    {
                        NFinalizeDeath.FixHouseholdList(Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("NeedLastName"));
                    }
                    else if (temp == "drawd")
                    {
                        drawd_command();
                    }
                    else if (temp == "fixsimlist")
                    {
                        fixsimlist_command();
                    }
                    else if (temp == "allexhouse")
                    {
                        Create.AllHouseholdToExportHousehold
                            (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("All Include Lot Contents"),
                             Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Export Household And Lot Contents"),
                             true,
                             !IsOpenDGSInstalled,
                             false);
                    }
                    else if (temp == "slde")
                    {
                        var gameObject = HitTargetGameObject();
                        if (gameObject != null)
                        {
                            NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(gameObject, false);
                        }
                    }
                    else if (temp == "fakemeteorpro") { fakemeteorpro_command(); }
                    else if (temp == "addsimtohousehold")
                    {
                        addsimtohousehold_command();
                    }
                    else if (temp == "autogmd")
                    {
                        if (!IsOpenDGSInstalled) return;
                        SimDescription at = null;
                        foreach (SimDescription item in ListCollon.NiecSimDescriptions)
                        {
                            if (item == null)
                                continue;
                            if (item.Service is GrimReaper || item.CreatedByService is GrimReaper)
                            {
                                if (item.CreatedSim != null)
                                { at = item; break; }
                            }
                        }
                        if (at == null || loopfire_listobjectguild == null) return;
                        loopfire_listobjectguild.Add(global::Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                        {

                            while (true)
                            {
                                at.mDeathStyle = SimDescription.DeathType.Drown;
                                at.IsGhost = false;
                                Simulator.Sleep(0);
                            }

                        }));
                    }
                    else if (temp == "fixuphinlothome") { fixuphinlothome_command(); }
                    else if (temp == "ishlistbad") { ishlistbad_Command(); }
                    else if (temp == "rwrallsim") { rwrallsim_command(); }
                    else if (temp == "savesimdesc")
                    {
                        SimDescription simd = Create.FindDescOrTargetSimDesc(0, 0, true);
                        if (simd != null && simd.mOutfits != null && simd.mOutfits.Count > 0)
                        {
                            ResourceKey travelKey = ResourceKey.kInvalidResourceKey;
                            SimOutfit outfit = simd.GetOutfit(OutfitCategories.Everyday, 0);
                            if (outfit != null && outfit.IsValid)
                            {
                                if (DownloadContent.SaveTravelSim(simd, outfit.Key, ref travelKey))
                                {
                                    noPSaveSimDesc = travelKey.ToString();
                                    NiecException.WriteLog("TravelKey: " + travelKey + "\nName: " + simd.mFirstName + " " + simd.mLastName);
                                }
                                else SimpleMessageDialog.Show("NiecMod", "Save sim description failed!");
                            }
                            else SimpleMessageDialog.Show("NiecMod", "Sim description is invalid.");
                        }
                        else SimpleMessageDialog.Show("NiecMod", "Could not find sim desc.");
                    }
                    else if (temp == "killsimforlot") { kill_sim_for_lot(); }
                    else if (temp == "dsavename")
                    {
                        if (debugsavenamefileTask != NiecInvalidObjectGuid)
                        {
                            Simulator.DestroyObject(debugsavenamefileTask);
                            debugsavenamefileTask = NiecInvalidObjectGuid;
                        }

                        if (GameStates.sLoadFileName == null)
                            GameStates.sLoadFileName = "LoadFileName_None.sims3";

                        string text = StringInputDialog.Show(
                            //tile
                            "NiecMod: Text Edit",

                            // desc
                            "TravelDataSaveName: " + (GameStates.HasTravelData ? GameStates.sTravelData.mSaveName : "None") +
                            (GameStates.HasTravelData ? "\nTDLoadFileName: " + DEBUG_LoadFileName(GameStates.sTravelData.mHomeWorld, true) : "") +
                            "\nGameStates.LoadFileName: " + GameStates.sLoadFileName,

                            // text edit
                            GameStates.sLoadFileName ?? "",

                            256,
                            StringInputDialog.Validation.None
                        );

                        if (!string.IsNullOrEmpty(text))
                            GameStates.sLoadFileName = text;

                        if (GameStates.HasTravelData)
                        {
                            text = StringInputDialog.Show(
                                //tile
                                "NiecMod: Text Edit",

                                // desc
                                "GameStates.TravelData.HomeWorld: " + GameStates.sTravelData.mHomeWorld,

                                // text edit
                                GameStates.sTravelData.mHomeWorld ?? "",

                                256,
                                StringInputDialog.Validation.None
                            );
                            if (!string.IsNullOrEmpty(text))
                                GameStates.sTravelData.mHomeWorld = text;
                        }

                        NiecException.PrintMessagePro
                            ("IsValidSaveGame: " + GameUtils.IsValidSavegame(GameStates.sLoadFileName) +
                            "\nFileName: " + GameStates.sLoadFileName, false, 10);

                        if (GameStates.HasTravelData)
                            NiecException.PrintMessagePro
                                ("HasTravelData\nIsValidSaveGame: " + GameUtils.IsValidSavegame(GameStates.sTravelData.mSaveName ?? "None.sims3") +
                                "\nFileName: " + GameStates.sTravelData.mSaveName ?? "None.sims3", false, 10);

                        string savefilebackup = GameStates.sLoadFileName;

                        if (GameStates.HasTravelData)
                        {

                            if (GameStates.sTravelData.mSaveName == null)
                                GameStates.sTravelData.mSaveName = "HasTravelData_None.sims3";

                            if ((!GameUtils.IsValidSavegame(GameStates.sTravelData.mSaveName) || !NFinalizeDeath.SaveFileNameExists_(GameStates.sTravelData.mSaveName, true)) && NFinalizeDeath.CheckAccept("HasTravelData\nFix Save Game File?"))
                            {

                                List<string> listsave = new List<string>();
                                foreach (string item in new WorldFileSearch(1u))
                                    listsave.Add(item);

                                GameStates.sTravelData.mSaveName = RandomUtil.GetRandomObjectFromList(listsave, ListCollon.SafeRandomPart2);
                                savefilebackup = GameStates.sTravelData.mSaveName;
                                listsave.Clear();

                                NiecException.PrintMessagePro
                                    ("HasTravelData\nFix ValidSaveGame: " + GameUtils.IsValidSavegame(GameStates.sTravelData.mSaveName) +
                                    "\nFileName: " + GameStates.sTravelData.mSaveName, false, 10);

                            }
                        }
                        if ((!GameUtils.IsValidSavegame(GameStates.sLoadFileName) || !NFinalizeDeath.SaveFileNameExists_(GameStates.sLoadFileName, true)) && NFinalizeDeath.CheckAccept("Fix Save Game File?"))
                        {

                            List<string> listsave = new List<string>();
                            foreach (string item in new WorldFileSearch(1u))
                                listsave.Add(item);

                            GameStates.sLoadFileName = RandomUtil.GetRandomObjectFromList(listsave, ListCollon.SafeRandomPart2);
                            savefilebackup = GameStates.sLoadFileName;
                            listsave.Clear();

                            NiecException.PrintMessagePro
                                ("Fix ValidSaveGame: " + GameUtils.IsValidSavegame(GameStates.sLoadFileName) +
                                "\nFileName: " + GameStates.sLoadFileName, false, 10);

                        }
                        if (savefilebackup != null && NFinalizeDeath.SaveFileNameExists_(savefilebackup ?? "None.sims3", true) && NFinalizeDeath.CheckAccept("While True?\nSaveFileBackup: " + savefilebackup))
                        {
                            debugsavenamefileTask = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                            {
                                while (true)
                                {
                                    Simulator.Sleep(0);
                                    GameStates.sLoadFileName = savefilebackup;
                                    if (GameStates.sTravelData != null)
                                        GameStates.sTravelData.mSaveName = savefilebackup;
                                }
                            });
                        }
                    }
                    else if (temp == "loadsimdesc10")
                    {
                        loadsimdesc10_command();
                    }
                    else if (temp == "hitloopdied")
                    {
                        hitloopdied_command();
                    }
                    else if (temp == "swb")
                    {
                        NFinalizeDeath.ServiceGRImp_WaitBool = !NFinalizeDeath.ServiceGRImp_WaitBool;
                        NiecException.PrintMessagePro("ServiceGRImp_WaitBool: " + NFinalizeDeath.ServiceGRImp_WaitBool, false, 50f);
                    }
                    else if (temp == "tunnhs")
                    {
                        NiecHelperSituation.fUnSafe_FakeThrowRunInteraction = !NiecHelperSituation.fUnSafe_FakeThrowRunInteraction;
                        NiecException.PrintMessagePro("NHS FakeThrowRunInteraction: " + NiecHelperSituation.fUnSafe_FakeThrowRunInteraction, false, 50f);
                    }
                    else if (temp == "unsaferunfuncnull")
                    {
                        unsaferunfuncnull_command();
                    }
                    else if (temp == "spnhs")
                    {
                        spnhs_Command();
                    }
                    else if (temp == "tnhs")
                    {
                        if (IsOpenDGSInstalled)
                        {
                            NiecHelperSituation.Spawn.DisableOnTick_OpenDGSOnly = !NiecHelperSituation.Spawn.DisableOnTick_OpenDGSOnly;
                            NiecException.PrintMessagePro("NHS DisableOnTick_ODGSO: " + NiecHelperSituation.Spawn.DisableOnTick_OpenDGSOnly, false, 50f);
                        }
                        else
                        {
                            NiecHelperSituation.Spawn.DisableOnTick = !NiecHelperSituation.Spawn.DisableOnTick;
                            NiecException.PrintMessagePro("NHS DisableOnTick: " + NiecHelperSituation.Spawn.DisableOnTick, false, 50f);
                        }
                    }
                    else if (temp == "alllotclean") { AllLotCleanUpAndRepair(); }
                    else if (temp == "rnhs")
                    {
                        if (IsOpenDGSInstalled)
                        {
                            NiecHelperSituation.bRandomAntiNPCOpenDGSOnly = !NiecHelperSituation.bRandomAntiNPCOpenDGSOnly;
                            NiecException.PrintMessagePro("NHS RandomAntiNPC: " + NiecHelperSituation.bRandomAntiNPCOpenDGSOnly, false, 50f);
                        }
                    }
                    else if (temp == "looppaa") { looppaa_Command(); }
                    else if (temp == "revlist")
                    {
                        Simulator.CheckYieldingContext(true);

                        string str = StringInputDialog.Show(
                             "NiecMod",
                             "Assembly Name?",
                             "",
                             StringInputDialog.Validation.None
                        );

                        if (NFinalizeDeath.IsNullOrEmpty(str))
                            return;

                        Assembly ably = AssemblyCheckByNiec.FindAssemblyPro(str) ?? AssemblyCheckByNiec.FindAssembly(str);
                        if (ably == null)
                        {
                            SimpleMessageDialog.Show("NiecMod", "Could not find Assembly.\n '" + str + "'");
                            return;
                        }

                        bool iNeedStatic = NFinalizeDeath.CheckAccept("Need Method Static?");

                        if (NFinalizeDeath.CheckAccept("Are you sure remove all EventLister?\nAssembly: " + ably.GetName().Name))
                        {
                            Predicate<Sims3.Gameplay.EventSystem.DelegateListener> dfunc = delegate(Sims3.Gameplay.EventSystem.DelegateListener test)
                            {
                                if (test == null)
                                    return false;

                                var processcalli = test.mProcessEvent;
                                if (processcalli == null)
                                    return false;

                                Type typeObject;
                                object targetEventListenerTask = processcalli.Target;
                                if (targetEventListenerTask == null || iNeedStatic)
                                {
                                    var methed = processcalli.Method;
                                    if (methed == null)
                                        return false;

                                    typeObject = methed.DeclaringType;
                                    if (typeObject == null)
                                        return false;

                                    return typeObject.Assembly == ably;
                                }
                                else if (!iNeedStatic && targetEventListenerTask != null)
                                {
                                    typeObject = targetEventListenerTask.GetType();
                                    if (typeObject == null)
                                        return false;

                                    return typeObject.Assembly == ably;
                                }
                                return false;
                            };
                            var foundEvent = NFinalizeDeath.EventTracker_FindAllDelegateListener(dfunc);
                            if (foundEvent != null)
                            {
                                int countfoundEvent = foundEvent.Count;
                                foreach (var item in foundEvent)
                                {
                                    if (item == null)
                                        continue;
                                    try
                                    {
                                        Sims3.Gameplay.EventSystem.EventTracker.RemoveListener(item);
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception) { }

                                }
                                SimpleMessageDialog.Show("NiecMod", "Removed.\nFound EventListener Count: " + countfoundEvent);
                            }
                            else SimpleMessageDialog.Show("NiecMod", "There no " + ably.GetName().Name + "'s EventListeners.");
                        }
                    }
                    else if (temp == "alldinvloop")
                    {
                        alldinvloop_command();
                    }
                    else if (temp == "unruncn")
                    {
                        unruncn_command();
                    }
                    else if (temp == "dpetdr")
                    {
                        var activeActor = NFinalizeDeath.ActiveActor;
                        bool noPetHousehold = NFinalizeDeath.CheckAccept("No Pet Household?");

                        foreach (var item in NFinalizeDeath.UpdateNiecSimDescriptions(false, false, true).ToArray())
                        {
                            if (item == null)
                                continue;

                            var createSim = item.CreatedSim;
                            if (createSim != null && createSim.SimDescription == item && createSim == activeActor)
                                continue;

                            if (item.IsDeer || item.IsRaccoon)
                            {
                                if (!noPetHousehold)
                                {
                                    var household = item.Household;
                                    if (household != null && household == Household.PetHousehold)
                                        continue;
                                }

                                NFinalizeDeath.Household_Remove(item, true);
                                NFinalizeDeath.SimDescCleanse(item, true, false);
                            }

                        }
                    }
                    else if (temp == "ussmcreapsoulpet")
                    {
                        ussmcreapsoulpet_command();
                    }
                    else if (temp == "loopraa") { loopraa_Command(); }
                    else if (temp == "cnhsp")
                    {
                        var Sim = HitTargetSim();
                        if (Sim != null)
                        {
                            //NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Sim, null);
                            NiecHelperSituationPosture.ExistsOrCreatePosture(Sim, false);
                        }
                    }
                    else if (temp == "tpsim")
                    {
                        tpsim_command();
                    }
                    else if (temp == "allcnhsp")
                    {
                        NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
                        NiecHelperSituation.Spawn._bUnSafeRunAll = true;

                        NFinalizeDeath.FixUpSimIsBad(null);

                        var simAC = NFinalizeDeath.ActiveActor;
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            if (item == null || simAC == item)
                                continue;
                            NiecHelperSituationPosture.ExistsOrCreatePosture(item, true);
                        }
                    }
                    else if (temp == "chouselotnosall")
                    {
                        chouselotnosall_command();
                    }
                    else if (temp == "ps")
                    {
                        var gameObj = HitTargetGameObject();
                        var previewSim = gameObj as CASGeneticsPreviewSim;
                        var sim = gameObj as Sim;

                        if (sim != null)
                        {
                            PlumbBob.ParentTo(sim);
                        }

                        if (previewSim != null)
                        {
                            NFinalizeDeath.PlumbBob_ParentToPreviewSim(PlumbBob.sSingleton, previewSim);

                        }

                        psLoop_Sim = gameObj;
                        if (gameObj != null)
                            PlumbBob.ShowPlumbBob();
                    }
                    else if (temp == "dallvsimdesc")
                    {
                        dallvsimdesc_command();
                    }
                    else if (temp == "setsimnull")
                    {
                        setsimnull_command();
                    }
                    else if (temp == "loadsimdesc")
                    {
                        Simulator.CheckYieldingContext(true);
                        bool needCreateActiveHousehold = false;
                        bool createdHousehold = false;
                        //bool bTargetHousehold = NFinalizeDeath.CheckAccept("Target Household");
                        Household activeHousehold = Household.ActiveHousehold;

                        if (activeHousehold == null || activeHousehold.mMembers == null)
                        {
                            if (NFinalizeDeath.CheckAccept("Target Household"))
                            {
                                var sim = HitTargetSim();
                                if (sim != null)
                                {
                                    activeHousehold = sim.Household;
                                }
                                if (activeHousehold == null || activeHousehold.mMembers == null)
                                    needCreateActiveHousehold = true;
                            }
                            else return;
                        }

                        ResourceKey result = default(ResourceKey);


                        var text = StringInputDialog.Show("NiecMod", "Resource Key", noPSaveSimDesc ?? "", 256, StringInputDialog.Validation.None);

                        if (ResourceKey.Parse(text, ref result))
                        {
                            if (World.ResourceExists(result))
                            {
                                SimDescription newSimDesc = NFinalizeDeath.SimDesc_Empty(null);

                                ResourceKeyContentCategory categoryInstalled = ResourceKeyContentCategory.kInstalled;
                                //ResourceKeyContentCategory categoryUserCreated = ResourceKeyContentCategory.kUserCreated;
                                bool checkerror;
                                try
                                {
                                    checkerror = DownloadContent.ImportSimDescription(result, newSimDesc, ref categoryInstalled);
                                    newSimDesc.UpdateFromOutfit(OutfitCategories.Everyday);
                                }
                                catch (Exception ex)
                                {
                                    NiecException.WriteLog("loadsimdesc Ex:\n" + ex.ToString());
                                    NFinalizeDeath.Assert("loadsimdesc_cmd: ImportSimDescription() failed\nEx Message: " + ex.Message + "Source: " + ex.Source);
                                    NFinalizeDeath.SimDescCleanse(newSimDesc, true, false);
                                    return;
                                }

                                if (checkerror)
                                //|| DownloadContent.ImportSimDescription(result, newSimDesc, ref categoryUserCreated))
                                {


                                    if (needCreateActiveHousehold || activeHousehold == null)
                                    {
                                        needCreateActiveHousehold = true;
                                        activeHousehold = Household.Create(true);
                                        createdHousehold = activeHousehold != null;
                                        activeHousehold.Name = newSimDesc.mLastName;
                                        //for (OutfitCategories i = 0; i < length; i++)


                                        Create.AutoMoveInLotFromHousehold(activeHousehold);
                                    }

                                    NFinalizeDeath.SimDesc_SetID(newSimDesc, (ulong)ListCollon.SafeRandomPart2.Next(1445, 6543556));
                                    newSimDesc.mHomeWorld = GameUtils.GetCurrentWorld();

                                    //activeHousehold.Add(newSimDesc);
                                    NFinalizeDeath.Household_Add(activeHousehold, newSimDesc, true);


                                    Sim checkSim;
                                    try
                                    {
                                        checkSim = newSimDesc.Instantiate(World.SnapToFloor(CameraController.GetTarget()));
                                    }
                                    catch (Exception e)
                                    {
                                        if (e is NullReferenceException && e.Message.StartsWith("GlobalFunctions.CreateObject: ") && AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap"))
                                        {
                                            try
                                            {
                                                activeHousehold.Remove(newSimDesc);
                                            }
                                            catch (Exception)
                                            { }

                                            NFinalizeDeath.Household_Remove(newSimDesc, true);
                                            NFinalizeDeath.SimDescCleanse(newSimDesc, true, false);
                                        }
                                        else if (IsOpenDGSInstalled && e is ArgumentException && e.Message.StartsWith("OpenDGS: "))
                                        {
                                            try
                                            {
                                                activeHousehold.Remove(newSimDesc);
                                            }
                                            catch (Exception)
                                            { }

                                            NFinalizeDeath.Household_Remove(newSimDesc, true);
                                            NFinalizeDeath.SimDescCleanse(newSimDesc, true, false);
                                        }

                                        if (newSimDesc.mSim != null)
                                            checkSim = newSimDesc.mSim;
                                        else
                                        {
                                            if (createdHousehold && activeHousehold.mMembers.mAllSimDescriptions.Count == 0)
                                                NFinalizeDeath.HouseholdCleanse(activeHousehold, false, true);
                                            SimpleMessageDialog.Show("NiecMod", "Failed to Instantiate Sim Description!\nException Message:\n" + e.Message + "\nResource Key:" + result);
                                            return;
                                        }
                                    }

                                    if (needCreateActiveHousehold && !IsOpenDGSInstalled && NiecSocialWorkerChildAbuseSituation.IsHouseholdOnlyChildOrPet(activeHousehold))
                                    {
                                        try
                                        {
                                            var csd = NFinalizeDeath.CreateRandomSimDescription();
                                            //activeHousehold.Add(csd);
                                            NFinalizeDeath.Household_Add(activeHousehold, csd, false);
                                            csd.Instantiate(World.SnapToFloor(CameraController.GetTarget()));
                                        }
                                        catch (Exception ex)
                                        {
                                            NiecException.PrintMessagePro("Create Active Household failed: " + ex.Message, false, 10);
                                            needCreateActiveHousehold = false;
                                        }

                                    }

                                    if (needCreateActiveHousehold)
                                        NFinalizeDeath.ActiveActor = checkSim;
                                    else
                                        PlumbBob.SelectActor(checkSim);

                                    noPSaveSimDesc = text;
                                    NFinalizeDeath.UnSafeRemoveOutfitsExEveryday(newSimDesc);
                                    SimpleMessageDialog.Show("NiecMod", "Done :)");
                                }
                                else
                                {
                                    SimpleMessageDialog.Show("NiecMod", "Failed to Import Sim Description!");
                                    NFinalizeDeath.SimDescCleanse(newSimDesc, true, false);
                                }
                            }
                            else SimpleMessageDialog.Show("NiecMod", "Could not find Resource Key.\n" + result);
                        }
                        else SimpleMessageDialog.Show("NiecMod", "Text is invalid.");
                    }
                    else if (temp == "unsaferunfuncnullpro")
                    {
                        unsaferunfuncnullpro_command();
                    }
                    else if (temp == "fakemeteor")
                    {
                        fakemeteor_command();
                    }
                    else if (temp == "aruns")
                    {
                        aruns_command();
                    }
                    else if (temp == "wrallsim") { wrallsim_command(); }
                    else if (temp == "tbobj")
                    {
                        GameObject obj = HitTargetGameObject();
                        if (obj != null)
                        {
                            BonehildaCoffin bobj = obj as BonehildaCoffin;
                            if (bobj != null)
                            {
                                if (bobj.mBonehilda == null)
                                {
                                    SimDescription simd = Create.FindDescOrTargetSimDesc(0, 0, true);
                                    if (simd != null)
                                    {
                                        bobj.mBonehilda = simd;
                                        bobj.SetCoffinActive(false);
                                        bobj.mBonehildaActive = false;
                                    }
                                    else if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Auto Random?"))
                                    {
                                        Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                                        Household ActiveHouseholdX = Household.ActiveHousehold;
                                        List<SimDescription> sSimDescriptionList = new List<SimDescription>();
                                        foreach (SimDescription item in ListCollon.NiecSimDescriptions)
                                        {
                                            if (item == null)
                                                continue;

                                            if (!item.IsValidDescription)
                                                continue;

                                            if (item.CreatedSim != null)
                                                continue;
                                            if (item.LotHome != null)
                                                continue;

                                            if (item.Household == null)
                                                continue;
                                            if (item.Household == ActiveHousehold)
                                                continue;
                                            if (item.Household == ActiveHouseholdX)
                                                continue;

                                            sSimDescriptionList.Add(item);
                                        }
                                        if (sSimDescriptionList.Count > 0)
                                        {
                                            simd = RandomUtil.GetRandomObjectFromList<SimDescription>(sSimDescriptionList, ListCollon.SafeRandom);
                                            sSimDescriptionList.Clear();
                                            if (simd != null)
                                            {
                                                bobj.mBonehilda = simd;
                                                bobj.SetCoffinActive(false);
                                                bobj.mBonehildaActive = false;
                                            }
                                        }
                                        else SimpleMessageDialog.Show("NiecMod", "Could not find sim desc.");
                                    }
                                }
                                else
                                {
                                    if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Remove"))
                                    {
                                        bobj.mBonehilda = null;
                                        bobj.mBonehildaSim = null;
                                        bobj.SetCoffinActive(false);
                                    }
                                }
                            }
                            else
                            {
                                GenieLamp globj = obj as GenieLamp;
                                if (globj != null)
                                {
                                    if (globj.mGenieDescription == null)
                                    {
                                        globj.mRemainingWishes = 500;
                                        SimDescription simd = Create.FindDescOrTargetSimDesc(0, 0, true);
                                        if (simd != null)
                                        {
                                            OccultGenie occultGenie = simd.OccultManager.GetOccultType(Sims3.UI.Hud.OccultTypes.Genie) as OccultGenie;
                                            if (occultGenie == null)
                                                simd.OccultManager.AddOccultType(Sims3.UI.Hud.OccultTypes.Genie, true, false, false);
                                            occultGenie = simd.OccultManager.GetOccultType(Sims3.UI.Hud.OccultTypes.Genie) as OccultGenie;



                                            occultGenie.Summoner = HitTargetSim() ?? NFinalizeDeath.GetRandomGameObject<Sim>() ?? PlumbBob.SelectedActor;
                                            occultGenie.LampOfGenie = globj;

                                            if (occultGenie.LampOfGenie != null)
                                            {
                                                simd.MotivesDontDecay = true;
                                                simd.Marryable = false;
                                                simd.AgingEnabled = false;
                                            }







                                            globj.mGenieDescription = simd;
                                        }
                                        else if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Auto Random?"))
                                        {
                                            Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                                            Household ActiveHouseholdX = Household.ActiveHousehold;
                                            List<SimDescription> sSimDescriptionList = new List<SimDescription>();
                                            foreach (SimDescription item in ListCollon.NiecSimDescriptions)
                                            {
                                                if (item == null)
                                                    continue;

                                                if (!item.IsValidDescription)
                                                    continue;

                                                if (item.CreatedSim != null)
                                                    continue;
                                                if (item.LotHome != null)
                                                    continue;

                                                if (item.Household == null)
                                                    continue;
                                                if (item.Household == ActiveHousehold)
                                                    continue;
                                                if (item.Household == ActiveHouseholdX)
                                                    continue;

                                                sSimDescriptionList.Add(item);
                                            }

                                            if (sSimDescriptionList.Count > 0)
                                            {
                                                simd = RandomUtil.GetRandomObjectFromList<SimDescription>(sSimDescriptionList, ListCollon.SafeRandom);
                                                sSimDescriptionList.Clear();
                                                if (simd != null)
                                                {
                                                    OccultGenie occultGenie = simd.OccultManager.GetOccultType(Sims3.UI.Hud.OccultTypes.Genie) as OccultGenie;
                                                    if (occultGenie == null)
                                                        simd.OccultManager.AddOccultType(Sims3.UI.Hud.OccultTypes.Genie, true, false, false);
                                                    occultGenie = simd.OccultManager.GetOccultType(Sims3.UI.Hud.OccultTypes.Genie) as OccultGenie;



                                                    occultGenie.Summoner = HitTargetSim() ?? PlumbBob.SelectedActor;
                                                    occultGenie.LampOfGenie = globj;

                                                    if (occultGenie.LampOfGenie != null)
                                                    {
                                                        simd.MotivesDontDecay = true;
                                                        simd.Marryable = false;
                                                        simd.AgingEnabled = false;
                                                    }







                                                    globj.mGenieDescription = simd;
                                                }
                                            }
                                            else SimpleMessageDialog.Show("NiecMod", "Could not find sim desc.");
                                        }
                                    }
                                    else if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Remove"))
                                    {
                                        SimDescription simd = globj.mGenieDescription;

                                        if (simd.OccultManager != null)
                                        {
                                            OccultGenie occultGenie = simd.OccultManager.GetOccultType(Sims3.UI.Hud.OccultTypes.Genie) as OccultGenie;
                                            if (occultGenie != null)
                                            {

                                                //if (occultGenie.mLamp != null)
                                                //{
                                                //    occultGenie.mLamp.RemoveFromWorld();
                                                //    occultGenie.mLamp.Destroy();
                                                //}
                                                occultGenie.mLamp = null;
                                                globj.mHasMadeAWish = false;
                                                try
                                                {
                                                    simd.OccultManager.RemoveOccultType(Sims3.UI.Hud.OccultTypes.Genie);
                                                }
                                                catch (Exception)
                                                { }

                                            }
                                        }


                                        simd.MotivesDontDecay = false;
                                        simd.Marryable = true;
                                        simd.AgingEnabled = true;

                                        globj.mGenieDescription = null;
                                    }
                                }
                            }
                        }
                    }
                    else if (temp == "rexlot")
                    {
                        if (exLotList == null) return;
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null && !TargetLot.IsWorldLot)
                        {
                            exLotList.Remove(TargetLot);
                        }
                        else { exLotList.Clear(); }
                    }
                    else if (temp == "riqrlist")
                    {
                        @munsafe_remove_iq_runinng_list(null, true);
                    }
                    else if (temp == "fixemtpy")
                    {
                        NFinalizeDeath.AllEmptyFixUp(null);
                        if (!IsOpenDGSInstalled)
                            NFinalizeDeath.FixAllHouseholdMembers();
                    }
                    else if (temp == "fcreap")
                    {
                        if (NFinalizeDeath.CheckAccept("All Sim?"))
                        {
                            if (nonOpendgsList01 == null && !IsOpenDGSInstalled)
                                nonOpendgsList01 = new List<StateMachineClient>();
                            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                            {
                                var smc = fcreap_Icommand(item, false, true);
                                if (!IsOpenDGSInstalled)
                                {
                                    nonOpendgsList01.Add(smc);
                                }
                            }
                        }
                        else { fcreap_command(); }
                    }
                    else if (temp == "aexlot")
                    {
                        if (exLotList == null) exLotList = new List<Lot>();
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null && !TargetLot.IsWorldLot && !exLotList.Contains(TargetLot))
                        {
                            exLotList.Add(TargetLot);
                        }
                    }
                    else if (temp == "forcefastdoinhs")
                    {

                        forcefastdoinhs = !forcefastdoinhs;
                        NiecException.PrintMessagePro("forcefastdoinhs: " + forcefastdoinhs, false, 50f);
                    }
                    else if (temp == "isstsleepmax")
                    {
                        isstsleepmax = !isstsleepmax;
                        NiecException.PrintMessagePro("isstsleepmax: " + isstsleepmax, false, 50f);
                    }
                    else if (temp == "hitloopdied2")
                    {
                        hitloopdied2_command();
                    }
                    else if (temp == "tmnfunc5")
                    {
                        tmnfunc5_Command();
                    }
                    else if (temp == "fhhmem") { NFinalizeDeath.FixAllHouseholdMembers(); }
                    else if (temp == "newlothouse")
                    {
                        Create.AllCreateHouseholdToLot();
                    }
                    else if (temp == "cfakegrave")
                    {
                        bool bUnsafe = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Unsafe?");
                        bool setSimDesc = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("SetSimDesc?");
                        foreach (SimDescription item in ListCollon.NiecSimDescriptions)
                        {


                            if (item == null)
                                continue;
                            //if (item.mDeathStyle == SimDescription.DeathType.None)
                            SimDescription.DeathType deathtype = Sims3.NiecHelp.Tasks.KillTask.SafeGetDeathType(item);

                            if (bUnsafe)
                            {
                                item.mDeathStyle = deathtype;
                                item.IsGhost = true;
                            }

                            Urnstone mGrave = HelperNra.TFindGhostsGrave(item) ?? Create.DeadSimGrave(deathtype, item, false, true, true);
                            if (mGrave != null)
                            {
                                if (setSimDesc)
                                    mGrave.DeadSimsDescription = item;
                                mGrave.RemoveFlags(GameObject.FlagField.InInventory);

                                if (!GlobalFunctions.PlaceAtGoodLocation(mGrave, new World.FindGoodLocationParams(CameraController.GetTarget()), false))
                                    mGrave.SetPosition(CameraController.GetTarget());

                                mGrave.SetOpacity(1f, 0f);
                                mGrave.AddToWorld();

                                mGrave.OnHandToolMovement();
                                mGrave.FadeIn(false, 5f);


                                if (!item.IsFrankenstein)
                                {
                                    switch (deathtype)
                                    {
                                        case SimDescription.DeathType.PetOldAgeGood:
                                        case SimDescription.DeathType.PetOldAgeBad:
                                            break;
                                        case SimDescription.DeathType.Burn:
                                            mGrave.SetMaterial("tombstonePlackFire");
                                            break;
                                        case SimDescription.DeathType.Drown:
                                        case SimDescription.DeathType.ScubaDrown:
                                            mGrave.SetMaterial("tombstonePlackDrowning");
                                            break;
                                        case SimDescription.DeathType.Electrocution:
                                            mGrave.SetMaterial("tombstonePlackElectrocution");
                                            break;
                                        case SimDescription.DeathType.OldAge:
                                            mGrave.SetMaterial("tombstonePlackOldAge");
                                            break;
                                        case SimDescription.DeathType.Starve:
                                            mGrave.SetMaterial("tombstonePlackHunger");
                                            break;
                                        case SimDescription.DeathType.MummyCurse:
                                            mGrave.SetMaterial("tombstonePlackMummy");
                                            break;
                                        case SimDescription.DeathType.Meteor:
                                            mGrave.SetMaterial("tombstonePlackMeteor");
                                            break;
                                        case SimDescription.DeathType.Thirst:
                                            mGrave.SetMaterial("tombstonePlackVampire");
                                            break;
                                        case SimDescription.DeathType.HumanStatue:
                                            mGrave.SetMaterial("tombstonePlackBurriedAlive");
                                            break;
                                        case SimDescription.DeathType.Transmuted:
                                            mGrave.SetMaterial("tombstonePlackAlchemy");
                                            break;
                                        case SimDescription.DeathType.HauntingCurse:
                                            mGrave.SetMaterial("tombstonePlackHaunted");
                                            break;
                                        case SimDescription.DeathType.JellyBeanDeath:
                                            mGrave.SetMaterial("tombstonePlackMagicJellyBean");
                                            break;
                                        case SimDescription.DeathType.Freeze:
                                            mGrave.SetMaterial("tombstonePlackFrozen");
                                            break;
                                        case SimDescription.DeathType.BluntForceTrauma:
                                            mGrave.SetMaterial("tombstoneBluntForceTrauma");
                                            break;
                                        case SimDescription.DeathType.Ranting:
                                            mGrave.SetMaterial("tombstoneRanting");
                                            break;
                                        case SimDescription.DeathType.Shark:
                                            mGrave.SetMaterial("tombstonePlackShark");
                                            break;
                                        case SimDescription.DeathType.MermaidDehydrated:
                                            mGrave.SetMaterial("tombstonePlackDehydration");
                                            break;
                                        case SimDescription.DeathType.Jetpack:
                                            mGrave.SetMaterial("tombstoneJetpack");
                                            break;
                                        case SimDescription.DeathType.Causality:
                                            mGrave.SetMaterial("tombstoneCausality");
                                            break;
                                        default:
                                            mGrave.SetMaterial("tombstonePlackDrowning");
                                            break;
                                    }
                                }
                                else
                                {
                                    mGrave.SetMaterial("tombstonePlackFrankensim");
                                }

                            }
                        }

                    }
                    else if (temp == "allpsimtopos")
                    {
                        allpsimtopos_command();
                    }
                    else if (temp == "cforac")
                    {

                        Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                        Household ActiveHouseholdX = Household.ActiveHousehold;

                        foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                        {
                            if (item == null) continue;
                            if (item == ActiveHousehold || item == ActiveHouseholdX)
                                continue;

                            if (item.IsSpecialHousehold)
                                continue;

                            NiecSocialWorkerChildAbuseSituation.CheckForAbandonedChildren(item);
                        }
                        //NFinalizeDeath.FixAllHouseholdMembers();
                        NFinalizeDeath.AllEmptyFixUp(null);
                    }
                    else if (temp == "fakelothome")
                    {


                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);

                        if (TargetLot != null)
                        {
                            NFinalizeDeath.MoveOutAllHousehold();

                            Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                            Household ActiveHouseholdX = Household.ActiveHousehold;

                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null) continue;
                                if (item == ActiveHousehold || item == ActiveHouseholdX)
                                    continue;

                                if (item.IsSpecialHousehold)
                                    continue;

                                item.mLotHome = TargetLot;
                                item.mLotId = TargetLot.LotId;
                                TargetLot.mHousehold = item;
                            }
                        }

                    }
                    else if (temp == "allcreatefakesim")
                    {
                        bool g = NFinalizeDeath.CheckAccept("Play Anim ReapSoul?");
                        allcreatefakeSim_Command(g, !g && NFinalizeDeath.CheckAccept("AnimLoop"), NFinalizeDeath.CheckAccept("Create Ghost"), NFinalizeDeath.CheckAccept("No Wait"));
                    }
                    else if (temp == "alldviewsim")
                    {
                        alldviewsim_Command();
                    }
                    else if (temp == "tsetype")
                    {
                        if (typeof(ScriptExecuteType) == null) return;
                        var gameObj = HitTargetGameObject();
                        if (gameObj != null)
                        {
                            ScriptCore.ScriptProxy sci = NFinalizeDeath.GetProxyWithoutSimIFace(gameObj);
                            if (sci == null)
                                return;

                            int i = NFinalizeDeath.GetIntDialog("ScriptExecuteType Code?");
                            if (i == -101)
                                return;
                            else if (i == -102)
                            {
                                NFinalizeDeath.Show_MessageDialog("text error.");
                                return;
                            }
                            ScriptExecuteType vScriptExecuteType = (ScriptExecuteType)i;

                            if (!Enum.IsDefined(typeof(ScriptExecuteType), vScriptExecuteType))
                            {
                                NFinalizeDeath.Show_MessageDialog("result is undefined.");
                                return;
                            }
                            if (!NFinalizeDeath.CheckAccept("Are you sure\nSet ScriptExecuteType: " + vScriptExecuteType))
                                return;
                            sci.mExecuteType = vScriptExecuteType;
                        }
                    }
                    else if (temp == "testdmymod")
                    {
                        testdmymod_command();
                    }
                    else if (temp == "etex")
                    {
                        var vObj = HitTargetGameObject();
                        if (vObj != null)
                        {
                            ScriptCore.ScriptProxy sci = NFinalizeDeath.GetProxyWithoutSimIFace(vObj);
                            if (sci == null) return;

                            MethodInfo mebinfo = typeof(ScriptCore.ScriptProxy).GetMethod("OnScriptError");
                            try
                            {
                                if (!(bool)mebinfo.Invoke(sci, new object[] { new ResetException() }))
                                    SimpleMessageDialog.Show("NiecMod", "Failed to OnScriptError!");
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception ex)
                            {
                                SimpleMessageDialog.Show("NiecMod", "Failed to OnScriptError!\nMessage: " + ex.Message);
                            }
                        }
                    }
                    else if (temp == "unwiz")
                    {
                        unwiz_command();
                    }
                    else if (temp == "cchildallhouse")
                    {
                        float f = 0;
                        WorldName nameWorld = GameUtils.GetCurrentWorld();
                        CASAgeGenderFlags gen = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Male?") ? CASAgeGenderFlags.Male : CASAgeGenderFlags.Female;
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                        {
                            if (item == null) continue;
                            if (item.LotHome == null) continue;

                            Household.Members mem = item.mMembers;
                            if (mem == null || mem.mAllSimDescriptions == null)
                                continue;

                            if (item.IsSpecialHousehold) continue;
                            try
                            {
                                if (!item.CanAddSpeciesToHousehold(CASAgeGenderFlags.Human)) continue;
                            }
                            catch (Exception) // EA BUG
                            { }
                            var Sim = NFinalizeDeath.MakeSim
                                (null, CASAgeGenderFlags.Child, gen, Genetics.RandomSkin(false, nameWorld, ref f), f, Genetics.Black1, nameWorld, uint.MaxValue, false);

                            Sim.FirstName = SimUtils.GetRandomGivenName(false, WorldName.France);
                            Sim.LastName = SimUtils.GetRandomFamilyName(WorldName.Egypt);

                            Genetics.AssignRandomTraits(Sim);

                            mem.mAllSimDescriptions.Add(Sim);
                            mem.mSimDescriptions.Add(Sim);
                            Sim.mHousehold = item;
                            try
                            {
                                Sim.Fixup();

                                PlumbBob.SelectActor(Sim.Instantiate(CameraController.GetTarget()));
                            }
                            catch (Exception)
                            { }
                        }
                        if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Create Teen?"))
                        {
                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null) continue;
                                if (item.LotHome == null) continue;
                                if (item.IsSpecialHousehold) continue;

                                Household.Members mem = item.mMembers;
                                if (mem == null || mem.mAllSimDescriptions == null)
                                    continue;

                                try
                                {
                                    if (!item.CanAddSpeciesToHousehold(CASAgeGenderFlags.Human)) continue;
                                }
                                catch (Exception)
                                { }
                                var Sim = NFinalizeDeath.MakeSim
                                    (null, CASAgeGenderFlags.Teen, gen, Genetics.RandomSkin(false, nameWorld, ref f), f, Genetics.Black1, nameWorld, uint.MaxValue, false);
                                //item.Add(Sim);

                                Genetics.AssignRandomTraits(Sim);

                                Sim.FirstName = SimUtils.GetRandomGivenName(false, WorldName.France);
                                Sim.LastName = SimUtils.GetRandomFamilyName(WorldName.Egypt);

                                mem.mAllSimDescriptions.Add(Sim);
                                mem.mSimDescriptions.Add(Sim);


                                Sim.mHousehold = item;
                                try
                                {
                                    Sim.Fixup();
                                    if (gen == CASAgeGenderFlags.Female)
                                        PlumbBob.SelectActor(Sim.Instantiate(CameraController.GetTarget()));
                                    else
                                        Sim.Instantiate(CameraController.GetTarget());
                                }
                                catch (Exception)
                                { }
                            }
                        }


                        NFinalizeDeath.FixAllHouseholdMembers();

                    }
                    else if (temp == "wtimer")
                    {
                        Sim TargetSim = HitTargetSim();
                        if (TargetSim != null && TargetSim.InteractionQueue != null)
                        {
                            NFinalizeDeath.FastProCancel(TargetSim);
                            NinecReaper.AddToInteranctionQueue(
                                // Actor
                                TargetSim,
                                // Target
                                TargetSim,
                                // Custom Run
                                delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                                {
                                    using (SafeSimUpdate.Run(Actor))
                                    {
                                        while (true)
                                        {
                                            NFinalizeDeath.SimulateAlarm(AlarmManager.Global, !IsOpenDGSInstalled, false, false);
                                            Simulator.Sleep(0);
                                        }
                                    }
                                }
                            );
                        }
                    }
                    else if (temp == "dipetname2")
                    {
                        dipetname2_command();
                    }
                    else if (temp == "firs")
                    {
                        NiecHelperSituation.ForceRunReapSoul = !NiecHelperSituation.ForceRunReapSoul;
                        NiecException.PrintMessagePro("ForceRunReapSoul: " + NiecHelperSituation.ForceRunReapSoul, false, 50f);
                    }
                    else if (temp == "firsp")
                    {
                        NiecHelperSituation.ForceRunReapSoulPet = !NiecHelperSituation.ForceRunReapSoulPet;
                        NiecException.PrintMessagePro("ForceRunReapSoulPet: " + NiecHelperSituation.ForceRunReapSoulPet, false, 50f);
                    }
                    else if (temp == "sworldflags")
                    {
                        sworldflags_command();
                    }
                    else if (temp == "importhouse")
                    {
                        importhouse_command();
                    }
                    else if (temp == "rp")
                    {
                        if (NFinalizeDeath.ActiveActor == null)
                        {
                            if (NFinalizeDeath.SC_GetObjects<Sim>().Length > 0)
                            {
                                Sim objSim = NFinalizeDeath.GetRandomGameObject<Sim>(delegate(Sim sim)
                                {
                                    if (sim == null)
                                        return false;
                                    var simd = sim.SimDescription;
                                    if (simd == null || !simd.IsValidDescription)
                                        return false;
                                    if (GameObjectHasDestroyed(sim))
                                        return false;
                                    if (simd.IsPet)
                                        return false;

                                    if (!IsOpenDGSInstalled && simd.LotHome == null)
                                        return false;
                                    else if (IsOpenDGSInstalled && !simd.Child)
                                        return false;

                                    if (NFinalizeDeath.IsAllActiveHousehold_SimObject(sim)) return false;
                                    return true;
                                });
                                if (objSim == null)
                                {
                                    objSim = NFinalizeDeath.GetRandomGameObject<Sim>(delegate(Sim sim)
                                    {
                                        if (sim == null)
                                            return false;


                                        var simd = sim.SimDescription;
                                        if (simd == null || !simd.IsValidDescription)
                                            return false;
                                        if (GameObjectHasDestroyed(sim))
                                            return false;
                                        if (simd.IsPet)
                                            return false;

                                        if (NFinalizeDeath.IsAllActiveHousehold_SimObject(sim)) return false;
                                        return true;
                                    });
                                }
                                if (objSim == null)
                                {
                                    objSim = NFinalizeDeath.GetRandomGameObject<Sim>(delegate(Sim sim)
                                    {
                                        if (sim == null)
                                            return false;


                                        var simd = sim.SimDescription;
                                        if (simd == null || !simd.IsValidDescription)
                                            return false;
                                        if (GameObjectHasDestroyed(sim))
                                            return false;
                                        if (NFinalizeDeath.IsAllActiveHousehold_SimObject(sim))
                                            return false;
                                        return true;
                                    });

                                }
                                if (objSim != null)
                                {
                                    if (!IsOpenDGSInstalled)
                                    {
                                        var simd = objSim.SimDescription;
                                        var createActiveHousehold = simd.Household;
                                        if (createActiveHousehold == null)
                                        {

                                            createActiveHousehold = Household.Create(true);
                                            createActiveHousehold.Name = simd.mLastName;

                                            NFinalizeDeath.Household_Add(createActiveHousehold, simd, false);

                                            if (simd.IsDead || simd.IsGhost)
                                                NFinalizeDeath.ResuetSim(simd, createActiveHousehold, false, false);

                                            Create.AutoMoveInLotFromHousehold(createActiveHousehold);

                                            if (createActiveHousehold.LotHome == null)
                                            {
                                                NFinalizeDeath.MoveOutAllHousehold();
                                                Create.AutoMoveInLotFromHousehold(createActiveHousehold);
                                                NFinalizeDeath.ForceAllMoveIn();
                                            }
                                            if (createActiveHousehold.LotHome == null)
                                            {
                                                SimpleMessageDialog.Show("NiecMod", "objSim.LotHome == null");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            Create.AutoMoveInLotFromHousehold(createActiveHousehold);
                                            if (createActiveHousehold.LotHome == null)
                                            {
                                                NFinalizeDeath.MoveOutAllHousehold();
                                                Create.AutoMoveInLotFromHousehold(createActiveHousehold);
                                                NFinalizeDeath.ForceAllMoveIn();
                                            }
                                            if (createActiveHousehold.LotHome == null)
                                            {
                                                SimpleMessageDialog.Show("NiecMod", "objSim.LotHome == null");
                                                return;
                                            }
                                        }
                                    }

                                    if (objSim.mInteractionQueue == null)
                                        objSim.mInteractionQueue = new InteractionQueue(objSim);

                                    NFinalizeDeath.ActiveActor = objSim;
                                }
                                else SimpleMessageDialog.Show("NiecMod", "Could not Find Sim!");
                            }
                            else SimpleMessageDialog.Show("NiecMod", "The Sim List == 0");
                        }
                    }
                    else if (temp == "simisf")
                    {
                        simisf_command();
                    }
                    else if (temp == "importlot")
                    {
                        if (!Simulator.CheckYieldingContext(false))
                            return;

                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null && !TargetLot.IsWorldLot && (World.LotIsEmpty(TargetLot.LotId) && TargetLot.IsLotEmptyFromObjects() || NFinalizeDeath.CheckAccept("UnSafe")))
                        {
                            try
                            {
                                if (!IsOpenDGSInstalled && BinModel.Singleton.mExportBin != null)
                                {
                                    ExportBin.RefreshExportBin();
                                    foreach (var item in BinModel.Singleton.mExportBin)
                                    {
                                        if (item == null) continue;
                                        if (item.HouseholdContents == null) continue;
                                        item.HouseholdContents.mHousehold = null;
                                    }
                                }
                            }
                            catch (StackOverflowException) { throw; }
                            catch (ResetException) { throw; }
                            catch (Exception)
                            { }

                            LotRotationAngle LotAngle = LotRotationAngle.kLotRotateAuto;
                            if (typeof(LotRotationAngle) != null)
                            {
                                LotRotationAngle result = (LotRotationAngle)NFinalizeDeath.GetIntDialog
                                   ("LotRotate Code\nkLotRotateNone = 0\nkLotRotate90 = 1\nkLotRotate180 = 2\nkLotRotate270 = 3\nkLotRotateAuto = 4");
                                if (!Enum.IsDefined(typeof(LotRotationAngle), result)) { }
                                else
                                {
                                    LotAngle = result;
                                }
                            }

                            LotPosition LotPosition = LotPosition.kLotPositionCenter;
                            Create.ReDEBUG re = Create.ImportLot(
                                TargetLot,
                                StringInputDialog.Show(
                                    "Package File",
                                    "",
                                    NFinalizeDeath.GetLastPackageName(true) ?? "",
                                    256,
                                    StringInputDialog.Validation.None
                               ),
                               ref LotAngle,
                               ref LotPosition
                            );
                            if (re != Create.ReDEBUG.Success)
                            {
                                SimpleMessageDialog.Show("NiecMod", "Failed to Import Lot!\nResult: " + re);
                            }
                        }
                    }
                    else if (temp == "targetpsmc")
                    {
                        Sim obj = HitTargetSim();
                        if (obj != null)
                        {
                            ScriptCore.TaskContext context;
                            if (!ScriptCore.TaskControl.GetTaskContext(obj.ObjectId.mValue, true, out context) || context.mFrames == null)
                            {
                                return;
                            }

                            Type StrType = typeof(string);

                            string toat = null;

                            bool found = false;

                            ScriptCore.TaskFieldReference fieldRef = default(ScriptCore.TaskFieldReference);
                            for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
                            {
                                ScriptCore.TaskFrame taskFrame = context.mFrames[stack];
                                fieldRef.mFrameIndex = stack;
                                if (taskFrame.mMethodHandle.Value != IntPtr.Zero)
                                {
                                    MethodInfo methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle) as MethodInfo;
                                    if (methodInfo != null)
                                    {
                                        StateMachineClient smc = taskFrame.mThisObj as StateMachineClient;
                                        if (smc != null && !found)
                                        {
                                            found = true;
                                            SimpleMessageDialog.Show("NiecMod_DEBUG", "StateMachineClient Found ID: " + smc.mDriver.mHandle);
                                        }
                                        if (smc != null && methodInfo.Name == "RequestState")
                                        {


                                            ParameterInfo[] parametersx = methodInfo.GetParameters();
                                            for (int i = 0; i < parametersx.Length; i++)
                                            {
                                                ParameterInfo parameterInfo = parametersx[i];
                                                fieldRef.mFieldIndex = i;
                                                if (parameterInfo != null && parameterInfo.Name == "actorName" && parameterInfo.ParameterType == StrType)
                                                {


                                                    toat = ScriptCore.TaskControl.GetFieldValue(obj.ObjectId.mValue, fieldRef) as string;
                                                    if (toat != null) break;
                                                }
                                            }


                                            if (toat != null && smc != null)
                                            {

                                                if (smc.Pause(toat))
                                                {
                                                    SimpleMessageDialog.Show("NiecMod_DEBUG", "Hack Target SMC Pause\nActorName: " + toat);
                                                    if (smc.mVirtualAddRefs != null)
                                                    {
                                                        foreach (var item in smc.mVirtualAddRefs.Keys)
                                                        {
                                                            if (item == null)
                                                                continue;
                                                            if (item == toat)
                                                                continue;

                                                            smc.Pause(item);
                                                        }
                                                    }
                                                    return;
                                                }
                                                else SimpleMessageDialog.Show("NiecMod_DEBUG", "Failed to Pause!\nActorName: " + toat);
                                                toat = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (temp == "renhstick") { NFinalizeDeath.ReAllNHSOnTick(null); }
                    else if (temp == "trimallsim")
                    {
                        NFinalizeDeath.AllTrimSimsAndPets(AssemblyCheckByNiec.IsInstalled("AweCore"), AssemblyCheckByNiec.IsInstalled("OpenDGS"), NFinalizeDeath.CheckAccept("Validate Sim Created?"));
                    }
                    else if (temp == "nhslsfi")
                    {
                        nhslsfi_command();
                    }
                    else if (temp == "targetctl")
                    {
                        if (TargetCTLoop_ObjectID == NiecInvalidObjectGuid)
                        {
                            Sim obj = HitTargetSim();
                            if (obj != null)
                            {
                                TargetCTLoop_ObjectID = Sims3.NiecHelp.Tasks.NiecTask.Perform(ScriptExecuteType.Threaded, delegate { TargetCTLoop(obj); });
                            }
                        }
                        else { NFinalizeDeath.RemoveTaskFromSimulator(ref TargetCTLoop_ObjectID); }
                    }
                    else if (temp == "targetct")
                    {
                        GameObject obj = HitTargetGameObject();
                        if (obj != null)
                        {
                            string st = NFinalizeDeath.____GetObjectStackTrace(obj.ObjectId.mValue);
                            if (st != "<no call stack>")
                            {
                                ScriptCore.TaskContext context;
                                /*
                                if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Set TickCount Sleep ?"))
                                {
                                    if (!ScriptCore.TaskControl.GetTaskContext(obj.ObjectId.mValue, true, out context) || context.mFrames == null)
                                        return;
                                    int.TryParse(
                                        StringInputDialog.Show(
                                            "NiecMod", "Tick\nNoSleep: -1\nInfiniteSleep: -2\nForceReset: -3", "5", 50, StringInputDialog.Validation.None
                                        ),
                                        out context.mSleepTicks
                                    );
                                    if (ScriptCore.TaskControl.SetTaskContext(obj.ObjectId.mValue, ref context))
                                        SimpleMessageDialog.Show("NiecMod_DEBUG", "Done Set Sleep.");
                                    return;
                                }

                                */


                                if (!ScriptCore.TaskControl.GetTaskContext(obj.ObjectId.mValue, true, out context) || context.mFrames == null)
                                    return;

                                StringBuilder stringBuilder = new StringBuilder();

                                for (int stack = context.mFrames.Length - 1; stack >= 0; stack--)
                                {
                                    ScriptCore.TaskFrame taskFrame = context.mFrames[stack];


                                    if (taskFrame.mMethodHandle.Value == IntPtr.Zero)
                                        continue;

                                    MethodBase methodInfo = MethodBase.GetMethodFromHandle(taskFrame.mMethodHandle);
                                    Type declaringType = methodInfo.DeclaringType;
                                    stringBuilder.Append(declaringType.Name);
                                    stringBuilder.Append("::");
                                    stringBuilder.Append(methodInfo.Name);
                                    stringBuilder.Append('\n');
                                }
                                //SimpleMessageDialog.Show("NiecMod\nCall Stack\nSleep: " + context.mSleepTicks, stringBuilder.ToString());
                                NiecException.PrintMessagePro("NiecMod\nCall Stack\nSleep: " + context.mSleepTicks + "\n" + stringBuilder.ToString(), true, 20);
                                //stringBuilder.Append("Sleep: " + context.mSleepTicks);
                                NiecException.WriteLog(st);
                                if (!IsVisibleTreatmentsController() || AssemblyCheckByNiec.IsInstalled("AweCore"))
                                    new NCopyableTextDialog(st).SafeShow("targetct command");
                            }
                        }
                    }
                    else if (temp == "uacsmcreapsoul") { uacsmcreapsoul_command(); }
                    else if (temp == "loopaadied") { loopaadied_Command(); }
                    else if (temp == "looppaa2") { looppaa2_command(); }
                    else if (temp == "fakehp")
                    {
                        Sim sim = HitTargetSim();
                        if (sim == null) return;
                        NFinalizeDeath.RunSwapHousehold(sim);
                    }
                    else if (temp == "backuptevc")
                    {
                        backuptevc_command();
                    }
                    else if (temp == "forcesetaa2")
                    {
                        //Sim sim = HitTargetSim();
                        //if (sim == null) return;
                        NFinalizeDeath.TestSetActiveActor(HitTargetSim(), true);
                    }
                    else if (temp == "targetocc")
                    {
                        Sim TargetSim = HitTargetSim();
                        if (TargetSim != null)
                        {
                            SimDescription ActiveDesc = NFinalizeDeath.SelectedActor_SimDescription;
                            SimDescription simd = Create.FindDescOrTargetSimDesc(0, ActiveDesc != null ? ActiveDesc.SimDescriptionId : 0, true);
                            if (simd != null && simd.mOutfits != null)
                            {
                                SimOutfit targetSimOutfit = new SimOutfit(CASUtils.GetOutfitInGameObject(TargetSim.Proxy.ObjectId));
                                if (targetSimOutfit.IsValid)
                                {

                                    SimBuilder simBuilder = new SimBuilder();
                                    simBuilder.UseCompression = true;
                                    //simBuilder.Age = CASAgeGenderFlags.Adult;

                                    OutfitUtils.SetAutomaticModifiers(simBuilder);

                                    OutfitUtils.SetOutfit(simBuilder, targetSimOutfit, null);

                                    if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Safe"))
                                    {

                                        simBuilder.Age = simd.Age;
                                        simBuilder.Gender = simd.Gender;
                                        simBuilder.Species = simd.Species;

                                    }
                                    ResourceKey outfitKey = simBuilder.CacheOutfit("NiecMod ID" + simd.SimDescriptionId, true);

                                    NiecException.WriteLog(outfitKey.ToString()); // Debug

                                    SimOutfit simOutfit = new SimOutfit(outfitKey);

                                    if (simOutfit != null && simOutfit.IsValid)
                                    {
                                        simd.AddOutfit(simOutfit, OutfitCategories.Everyday, true);
                                    }
                                    else
                                    {
                                        if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Unsafe"))
                                            simd.AddOutfit(targetSimOutfit, OutfitCategories.Everyday, true);
                                        else
                                            SimpleMessageDialog.Show("NiecMod", "simOutfit is invalid.");
                                    }

                                }
                                else
                                    SimpleMessageDialog.Show("NiecMod", "Target Sim Outfit is invalid.");
                            }
                            else
                                SimpleMessageDialog.Show("NiecMod", "Could not Find Sim Desc.");
                        }
                    }
                    else if (temp == "debugdebuginfo")
                    {
                        debugdebuginfo_command();
                    }
                    else if (temp == "cukeyname")
                    {
                        cukeyname_command();
                    }
                    else if (temp == "coccults")
                    {

                        string text;
                        string[] array = new string[3]
		                {
		                	"afBonehilda1",
		                	"afBonehilda2",
		                	"afBonehilda3"
		                };

                        bool ifActiveHousehold = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Add If ActiveHousehold");
                        Household ActiveHousehold = !ifActiveHousehold ? null : Household.ActiveHousehold;
                        foreach (var item in ListCollon.NiecSimDescriptions)
                        {
                            if (item == null || !item.IsValidDescription)
                                continue;

                            if (item.mSimDescriptionId == 0)
                                continue;

                            if (string.IsNullOrEmpty(item.mFirstName) && string.IsNullOrEmpty(item.mLastName))
                                continue;

                            if (ifActiveHousehold && item.Household != null && item.Household == ActiveHousehold)
                                continue;

                            if (item.mOutfits == null)
                                item.mOutfits = new OutfitCategoryMap();

                            if (item.mOutfits != null && item.mOutfits.Count != 0)
                                continue;




                            text = array[RandomUtil.GetInt(0, 3, ListCollon.SafeRandom)];

                            ResourceKey key = ResourceKey.CreateOutfitKeyFromProductVersion(text, ProductVersion.EP7);
                            SimOutfit simOutfit = new SimOutfit(key);
                            if (simOutfit.IsValid)
                            {
                                SimBuilder simBuilder = new SimBuilder();
                                simBuilder.UseCompression = true;
                                simBuilder.Age = CASAgeGenderFlags.Adult;
                                OutfitUtils.SetAutomaticModifiers(simBuilder);
                                OutfitUtils.SetOutfit(simBuilder, simOutfit, null);

                                ResourceKey key2 = simBuilder.CacheOutfit(text);
                                SimOutfit simOutfit2 = new SimOutfit(key2);
                                if (simOutfit2 != null && simOutfit2.IsValid)
                                {
                                    item.AddOutfit(simOutfit2, OutfitCategories.Everyday, true);
                                }
                                else break; // Safe
                            }
                            else break; // Safe

                        }

                    }
                    else if (temp == "mydesctoalldesc")
                    {

                        SimDescription aDesc = NFinalizeDeath.SelectedActor_SimDescription;
                        SimDescription simd = Create.FindDescOrTargetSimDesc(0, aDesc != null ? aDesc.SimDescriptionId : 0, true);
                        if (simd != null && simd.mOutfits != null && simd.mOutfits.Count > 0)
                        {

                            var oC =
                                aDesc != null && aDesc.SimDescriptionId == simd.SimDescriptionId ?
                                    PlumbBob.SelectedActor.CurrentOutfitCategory
                                : OutfitCategories.Everyday;

                            SimOutfit activeDescSimOutfit = simd.GetOutfit(oC, 0);
                            if (activeDescSimOutfit == null || !activeDescSimOutfit.IsValid)
                            { SimpleMessageDialog.Show("NiecMod", "Sim Outfit is invalid."); return; }

                            bool ifActiveHousehold = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Add If ActiveHousehold");
                            bool unsafeC = NFinalizeDeath.CheckAccept("Clear Outfits");
                            bool bUnSafeEverydayToAddOtherOutfits = NFinalizeDeath.CheckAccept("UnSafeEverydayToAddOtherOutfits");
                            bool rSwitchToOutfitWithoutSpin = !unsafeC && NFinalizeDeath.CheckAccept("Switch To Outfit Without Spin");

                            Household ActiveHousehold = !ifActiveHousehold ? null : Household.ActiveHousehold;
                            foreach (var item in ListCollon.NiecSimDescriptions)
                            {
                                if (item == null || !item.IsValidDescription)
                                    continue;

                                if (item == simd) continue;

                                if (item.mSimDescriptionId == 0)
                                    continue;

                                if (string.IsNullOrEmpty(item.mFirstName) && string.IsNullOrEmpty(item.mLastName))
                                    continue;

                                if (ifActiveHousehold && item.Household != null && item.Household == ActiveHousehold)
                                    continue;

                                if (item.mOutfits == null)
                                    item.mOutfits = new OutfitCategoryMap();



                                SimBuilder simBuilder = new SimBuilder();
                                simBuilder.UseCompression = true;
                                simBuilder.Age = aDesc.Age;
                                simBuilder.Gender = aDesc.Gender;
                                simBuilder.Species = aDesc.Species;

                                OutfitUtils.SetAutomaticModifiers(simBuilder);
                                OutfitUtils.SetOutfit(simBuilder, activeDescSimOutfit, null);

                                SimOutfit newSimOutfit = new SimOutfit(simBuilder.CacheOutfit("NiecMod IC" + ListCollon.SafeRandomPart2.Next(0, 100000000)));
                                if (newSimOutfit != null && newSimOutfit.IsValid)
                                {


                                    try
                                    {
                                        if (unsafeC)
                                        {
                                            item.mOutfits.Clear();
                                            if (item.mMaternityOutfits != null)
                                            {
                                                item.mMaternityOutfits.Clear();
                                            }
                                        }
                                        else if (rSwitchToOutfitWithoutSpin)
                                        {
                                            var createdSim = item.CreatedSim;
                                            if (createdSim != null)
                                                createdSim.SwitchToOutfitWithoutSpin(Sim.ClothesChangeReason.Force, OutfitCategories.Everyday);
                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }

                                    item.AddOutfit(newSimOutfit, OutfitCategories.Everyday, true);

                                    if (bUnSafeEverydayToAddOtherOutfits)
                                        NFinalizeDeath.UnSafeEverydayToAddOtherOutfits(item, true);

                                    try
                                    {
                                        if (unsafeC)
                                        {
                                            var createdSim = item.CreatedSim;
                                            if (createdSim != null)
                                                createdSim.SwitchToOutfitWithoutSpin(Sim.ClothesChangeReason.Force, OutfitCategories.Everyday);
                                        }
                                    }
                                    catch (StackOverflowException) { throw; }
                                    catch (ResetException) { throw; }
                                    catch (Exception)
                                    { }
                                }
                                else break; // Safe
                            }
                        }
                        else
                            SimpleMessageDialog.Show("NiecMod", "Could not find Sim Desc.");
                    }
                    else if (temp == "forcecalli")
                    {
                        Sim Target = HitTargetSim();
                        if (Target != null)
                        {
                            try
                            {
                                foreach (InteractionInstance interactionInstance in Target.mInteractionQueue.mInteractionList.ToArray()) // Cant Cancel Fix
                                {
                                    interactionInstance.mbOnStopCalled = true;
                                    interactionInstance.mbOnStartCalled = true;
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
                            if (Target.mReferenceList != null)
                            {
                                Target.mReferenceList.Clear();
                            }

                            if (Target.mRoutingReferenceList != null && Target.mRoutingReferenceList.Count != 0)
                                Target.mRoutingReferenceList.Clear();

                            Target.AddExitReason(ExitReason.SuspensionRequested);


                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);


                            Target.AddExitReason(ExitReason.Default);
                            if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Target.DoReset();"))
                            {
                                Target.DoReset(new GameObject.ResetInformation());
                            }
                        }
                        //NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                    }
                    else if (temp == "infoaa")
                    {
                        Sim ActiveActorOpenDGS = NFinalizeDeath.ActiveActor;
                        Sim ActiveActorNonOpenDGS = PlumbBob.SelectedActor;
                        if (ActiveActorOpenDGS != null && ActiveActorNonOpenDGS != null && ActiveActorOpenDGS != ActiveActorNonOpenDGS)
                        {
                            SimpleMessageDialog.Show("NFinalizeDeath.ActiveActor"
                                , NiecException.GetDescriptionPro(ActiveActorOpenDGS.SimDescription) ?? "sim don't have simdesc.");
                            SimpleMessageDialog.Show("PlumbBob.SelectedActor"
                                , NiecException.GetDescriptionPro(ActiveActorNonOpenDGS.SimDescription) ?? "sim don't have simdesc.");
                        }
                        else
                        {
                            if (ActiveActorOpenDGS != null)
                                SimpleMessageDialog.Show("NFinalizeDeath.ActiveActor"
                                    , NiecException.GetDescriptionPro(ActiveActorOpenDGS.SimDescription) ?? "sim don't have simdesc.");
                            else if (ActiveActorNonOpenDGS != null)
                                SimpleMessageDialog.Show("PlumbBob.SelectedActor"
                                    , NiecException.GetDescriptionPro(ActiveActorNonOpenDGS.SimDescription) ?? "sim don't have simdesc.");
                        }
                    }
                    else if (temp == "targetniecsw")
                    {
                        if (Simulator.CheckYieldingContext(false))
                        {
                            if (NFinalizeDeath.CheckAccept("SocialWorkerChildAbuse.SocialWorker"))
                            {
                                LotLocation LotLocation = default(LotLocation);
                                ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                                Lot TargetLot = LotManager.GetLot(Location);
                                if (TargetLot != null && !TargetLot.IsWorldLot)
                                {
                                    if (TargetLot.Household != null)
                                    {
                                        SocialWorkerChildAbuse asdot = SocialWorkerChildAbuse.sSocialWorker;
                                        if (asdot != null && asdot.mPool != null)
                                        {
                                            foreach (var item in asdot.mPool)
                                            {
                                                if (item == null || !item.IsValidDescription)
                                                    continue;
                                                if (item.Household == null)
                                                    continue;

                                                Sim simat = item.CreatedSim;
                                                if (simat != null)
                                                    continue;

                                                simat = item.Instantiate(Service.GetPositionInRandomLot(TargetLot));
                                                SpeedTrap.Sleep(0);

                                                Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                                                {
                                                    if (!item.IsEP11Bot)
                                                    {
                                                        simat.SwitchToOutfitWithoutSpin(OutfitCategories.Career);
                                                    }
                                                });

                                                var niecsw = NiecSocialWorkerChildAbuseSituation.Create(TargetLot, simat, true,
                                                    Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("UnSafe"));
                                                if (niecsw != null)
                                                    niecsw.NeedDestroyWorker = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                        SimpleMessageDialog.Show("NiecMod", "TargetLot.Household == null");
                                }
                                else SimpleMessageDialog.Show("NiecMod", "TargetLot == null");
                            }
                            else if (NFinalizeDeath.CheckAccept("Auto Create"))
                            {
                                NiecSocialWorkerChildAbuseSituation niecSWCAS;
                                LotLocation LotLocation = default(LotLocation);
                                ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                                Lot TargetLot = LotManager.GetLot(Location);
                                if (TargetLot != null && !TargetLot.IsWorldLot)
                                {
                                    if (TargetLot.Household != null)
                                    {
                                        NFinalizeDeath.CreateSocialWorkerToTargetLot(TargetLot,
                                            NFinalizeDeath.DefaultTest_NiecSocialWorkerChildAbuseSituation, Simulator.CheckYieldingContext(false)
                                            && NFinalizeDeath.CheckAccept("bUnSafe"), out niecSWCAS);
                                    }
                                    else
                                        SimpleMessageDialog.Show("NiecMod", "TargetLot.Household == null");
                                }
                                else SimpleMessageDialog.Show("NiecMod", "TargetLot == null");
                            }
                        }
                        else
                        {
                            Sim TargetSim = HitTargetSim();
                            if (TargetSim != null && TargetSim.SimDescription.YoungAdultOrAbove)
                            {
                                LotLocation LotLocation = default(LotLocation);
                                ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                                Lot TargetLot = LotManager.GetLot(Location);
                                if (TargetLot != null)
                                {
                                    if (TargetLot.Household != null)
                                        NiecSocialWorkerChildAbuseSituation.Create(TargetLot, TargetSim, true,
                                            Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("bUnSafe"));
                                    else
                                        SimpleMessageDialog.Show("NiecMod", "TargetLot.Household == null");
                                }
                                else SimpleMessageDialog.Show("NiecMod", "TargetLot == null");
                            }
                        }
                    }
                    else if (temp == "pmgas")
                    {
                        pmgas_command();
                    }
                    else if (temp == "debugnhsi")
                    {
                        debugnhsi_command();
                    }
                    else if (temp == "dallgravelot")
                    {
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null)
                        {
                            Vector3 em = Vector3.OutOfWorld;
                            int sieeo = 0;
                            foreach (var grave in NFinalizeDeath.SC_GetObjectsOnLot<Urnstone>(TargetLot))
                            {
                                if (grave == null)
                                    continue;

                                sieeo++;
                                if (sieeo > 50) { sieeo = 0; Simulator.Sleep(0); }
                                grave.SetPosition(em);
                                grave.DeadSimsDescription = null;
                                NFinalizeDeath.ForceDestroyObject(grave);

                            }
                        }
                    }
                    else if (temp == "tmsfunc1")
                    {
                        tmsfunc1_command();
                    }
                    else if (temp == "tevs")
                    {
                        tevs_command();
                    }
                    else if (temp == "fixmshouse")
                    {
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                        {
                            if (item == null)
                                continue;
                            if (item.mMoneySaved == null || item.mMoneySaved.Length == 0)
                                item.mMoneySaved = new uint[3];

                        }
                    }

                    else if (temp == "addniechelpershouse")
                    {

                        bool isactivehousehold = false;

                        Sim TargetSim = HitTargetSim();

                        Household TargetHousehold = TargetSim != null ? TargetSim.Household : null;

                        if (TargetHousehold == null)
                        {
                            isactivehousehold = true;
                            TargetHousehold = Household.ActiveHousehold;
                        }

                        if (TargetHousehold == null)
                            return;

                        NiecHelperSituation.Spawn._bUnSafeRunAll = true;

                        if (!isactivehousehold)
                            NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;

                        foreach (var item in TargetHousehold.AllActors)
                        {
                            try
                            {
                                if (item == null) continue;
                                //NiecHelperSituation situationOfType = item.GetSituationOfType<NiecHelperSituation>();
                                //if (situationOfType != null)
                                //{
                                //    continue;
                                //}
                                if (item.GetSituationOfType<NiecHelperSituation>() != null)
                                    continue;
                                else
                                {
                                    var nhs = NiecHelperSituation.Create(item.LotCurrent, item);
                                    if (nhs != null)
                                        item.Autonomy.SituationComponent.Situations.Add(nhs);
                                }
                            }
                            catch (Exception)
                            { continue; }

                        }
                        for (int i = 0; i < 150; i++)
                            Simulator.Sleep(0);
                        Sim Target = HitTargetSim();
                        if (Target != null && Target.SimDescription != null)
                        {
                            Target.SimDescription.IsGhost = false;
                            Target.SimDescription.mDeathStyle = SimDescription.DeathType.ScubaDrown;
                        }
                    }
                    else if (temp == "nhsptick")
                    {
                        if (NFinalizeDeath.CheckAccept("Value: " + NiecHelperSituationPosture.Disallowr_internal))
                        {
                            NiecHelperSituationPosture.Disallowr_internal = true;
                            NiecException.PrintMessagePro("NHSP Disallowr_internal: " + NiecHelperSituationPosture.Disallowr_internal, false, 50f);
                        }
                        else
                        {
                            NiecHelperSituationPosture.Disallowr_internal = false;
                            NiecException.PrintMessagePro("NHSP Disallowr_internal: " + NiecHelperSituationPosture.Disallowr_internal, false, 50f);
                        }
                    }
                    else if (temp == "mpush")
                    {
                        if (NFinalizeDeath.CheckAccept("EA Default"))
                        {
                            SimRoutingComponent.kMinimumPostPushStandAndWaitDuration = 1.5f;
                            SimRoutingComponent.kMaximumPostPushStandAndWaitDuration = 5f;
                            SimRoutingComponent.kDefaultStandAndWaitDuration = 50f;

                            SimRoutingComponent.kDefaultImmuneToPushesDuration = 15f;
                            SimRoutingComponent.kOnEmergencyGetAwayRouteStartedImmuneToPushesDuration = 30f;
                            SimRoutingComponent.kOnRouteStartedImmuneToPushesDuration = 5f;

                            SimRoutingComponent.kEndOfPortalInvicibilityDuration = 5;
                        }
                        else if (NFinalizeDeath.CheckAccept("Low"))
                        {
                            SimRoutingComponent.kMinimumPostPushStandAndWaitDuration = 0.1f;
                            SimRoutingComponent.kMaximumPostPushStandAndWaitDuration = 1f;
                            SimRoutingComponent.kDefaultStandAndWaitDuration = 5f;

                            SimRoutingComponent.kDefaultImmuneToPushesDuration = 50f;
                            SimRoutingComponent.kOnEmergencyGetAwayRouteStartedImmuneToPushesDuration = 95f;
                            SimRoutingComponent.kOnRouteStartedImmuneToPushesDuration = 35f;

                            SimRoutingComponent.kEndOfPortalInvicibilityDuration = 55;
                        }
                        else if (NFinalizeDeath.CheckAccept("High"))
                        {
                            SimRoutingComponent.kMinimumPostPushStandAndWaitDuration = 10.5f;
                            SimRoutingComponent.kMaximumPostPushStandAndWaitDuration = 25f;
                            SimRoutingComponent.kDefaultStandAndWaitDuration = 100f;

                            SimRoutingComponent.kDefaultImmuneToPushesDuration = 1f;
                            SimRoutingComponent.kOnEmergencyGetAwayRouteStartedImmuneToPushesDuration = 1f;
                            SimRoutingComponent.kOnRouteStartedImmuneToPushesDuration = 1f;

                            SimRoutingComponent.kEndOfPortalInvicibilityDuration = 1f;
                        }
                    }
                    else if (temp == "debugvfxnhs")
                    {
                        debugvfxnhs_command();
                    }
                    else if (temp == "rallfloop")
                    {
                        foreach (var item in loopfire_listobjectguild.ToArray())
                        {
                            Simulator.DestroyObject(item);
                            loopfire_listobjectguild.Remove(item);
                        }
                    }
                    else if (temp == "addloopfire")
                    {
                        Sim activeActor = PlumbBob.SelectedActor;
                        if (activeActor != null)// && activeActor.LotCurrent != null)
                        {

                            Vector3 PosStart = activeActor.Position;
                            Lot TargetLot = activeActor.LotCurrent;

                            if (TargetLot != null && !TargetLot.IsWorldLot && TargetLot.FireManager != null)
                            {
                                loopfire_listobjectguild.Add(global::Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                                {
                                    try
                                    {
                                        if (TargetLot.FireManager.mFireSource != null)
                                            TargetLot.FireManager.mFireSource.Destroy();

                                        TargetLot.FireManager.mFires = null;
                                        TargetLot.FireManager.mFireSource = null;

                                        while (true)
                                        {
                                            Simulator.Sleep(50);
                                            if (NFinalizeDeath.SC_GetObjectsOnLot<FireSource>(TargetLot).Length != 0)
                                                continue;

                                            if (TargetLot.FireManager.mFireSource != null)
                                                TargetLot.FireManager.mFireSource.Destroy();

                                            TargetLot.FireManager.mFires = null;
                                            TargetLot.FireManager.mFireSource = null;

                                            FireManager.AddFire(PosStart, true);

                                        }
                                    }
                                    finally
                                    {
                                        loopfire_listobjectguild.Remove(Simulator.CurrentTask);
                                    }

                                }));
                            }
                        }
                    }
                    else if (temp == "createfakesim")
                    {
                        bool g = NFinalizeDeath.CheckAccept("Play Anim ReapSoul?");
                        createfakesim_command(null, null, null, true, g, !g && NFinalizeDeath.CheckAccept("Anim Loop?"), NFinalizeDeath.CheckAccept("Preview Ghost?"), false);
                    }
                    else if (temp == "deadsimtosim")
                    {
                        Simulator.CheckYieldingContext(true);
                        bool exGraveLot = NFinalizeDeath.CheckAccept("Check Grave Lot?");
                        NFinalizeDeath.FixAllHouseholdMembers();
                        Vector3 camera = World.SnapToFloor(CameraController.GetTarget());
                        bool cacheISEditWorld = ScriptCore.World.World_IsEditInGameFromWBModeImpl();


                        if (Household.sHouseholdList == null) Household.sHouseholdList = new List<Household>();
                        NFinalizeDeath.FixHouseholdList();
                        foreach (var item in Household.sHouseholdList.ToArray())
                        {
                            if (item == null)
                                Household.sHouseholdList.Remove(item);
                        }
                        HelperNra[] helperlist = HelperNra.HelperNraLists.ToArray();
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Urnstone>())
                        {
                            if (exGraveLot)
                            {
                                var lot = item.LotCurrent;
                                if (lot != null && lot.CommercialLotSubType == CommercialLotSubType.kGraveyard)
                                {
                                    continue;
                                }
                                if (NFinalizeDeath.IsGraveToInventoryMausoleum(item)) continue;
                            }
                            SimDescription deadsimdesc = item.DeadSimsDescription;
                            if (deadsimdesc != null && deadsimdesc.mSim == null)
                            {
                                if (string.IsNullOrEmpty(deadsimdesc.mFirstName) && string.IsNullOrEmpty(deadsimdesc.mLastName))
                                {
                                    if (!IsOpenDGSInstalled)
                                        SimDescCleanseTask.Add(deadsimdesc, true);
                                    continue;
                                }
                                if (!deadsimdesc.IsValidDescription)
                                {
                                    if (!IsOpenDGSInstalled)
                                        SimDescCleanseTask.Add(deadsimdesc, true);
                                    continue;
                                }
                                Sim deadsim = null;

                                bool isghost = deadsimdesc.IsGhost;
                                Sims3.Gameplay.CAS.SimDescription.DeathType asdr = deadsimdesc.mDeathStyle;
                                Household orahousehold =
                                    (IsOpenDGSInstalled) ? NFinalizeDeath.Find_SCGetHouseholds(item.mOriginalHouseholdId)
                                    : item.OriginalHousehold;

                                try
                                {
                                    deadsimdesc.IsGhost = false;
                                    deadsimdesc.mDeathStyle = SimDescription.DeathType.None;
                                    if (ShuoldOrgHousehold(orahousehold))// && orahousehold != Household.ActiveHousehold)
                                    {
                                        //orahousehold.Add(deadsimdesc);
                                        NFinalizeDeath.Household_Add(orahousehold, deadsimdesc, false);
                                    }
                                    else
                                    {
                                        if (ListCollon.__NiecDeadSimDescriptionsHousehold == null)
                                        {
                                            ListCollon.__NiecDeadSimDescriptionsHousehold = Household.Create(IsOpenDGSInstalled);
                                            ListCollon.__NiecDeadSimDescriptionsHousehold.Name = //"NiecMod: Ghost Household " + 
                                                deadsimdesc.mLastName;
                                            if (!IsOpenDGSInstalled)
                                            {
                                                ListCollon.__NiecDeadSimDescriptionsHousehold.mHouseholdId = 0; //45006000;
                                                ListCollon.__NiecDeadSimDescriptionsHousehold.mHouseholdTelemetryId = 0;
                                                //if (!IsOpenDGSInstalled)
                                                Create.AutoMoveInLotFromHousehold(ListCollon.__NiecDeadSimDescriptionsHousehold);
                                            }
                                        }
                                        if (ListCollon.__NiecDeadSimDescriptionsHousehold != null)
                                        {

                                            List<Household> outhouseholdlist;

                                            if (NFinalizeDeath.Should_SimNoHousehold_HouseholdFound(deadsimdesc, true, out outhouseholdlist))// && outhouseholdlist.Count > 1)
                                            {
                                                foreach (var itemHousehold in outhouseholdlist)
                                                {
                                                    if (itemHousehold == null) continue;
                                                    Household.Members mem = itemHousehold.mMembers;
                                                    if (mem == null)
                                                        continue;
                                                    for (int i = 0; i < 100; i++)
                                                    {
                                                        if (mem.mAllSimDescriptions != null)
                                                            mem.mAllSimDescriptions.Remove(deadsimdesc);
                                                        if (mem.mPetSimDescriptions != null)
                                                            mem.mPetSimDescriptions.Remove(deadsimdesc);
                                                        if (mem.mSimDescriptions != null)
                                                            mem.mSimDescriptions.Remove(deadsimdesc);
                                                        deadsimdesc.mHousehold = null;
                                                    }
                                                }
                                                outhouseholdlist.Clear();
                                            }
                                            Household.Members __NiecDeadSimDescriptionsHousehold_Members = ListCollon.__NiecDeadSimDescriptionsHousehold.mMembers;
                                            if (__NiecDeadSimDescriptionsHousehold_Members != null && !__NiecDeadSimDescriptionsHousehold_Members.mAllSimDescriptions.Contains(deadsimdesc))
                                            {
                                                __NiecDeadSimDescriptionsHousehold_Members.mAllSimDescriptions.Add(deadsimdesc);
                                                if (deadsimdesc.IsPet)
                                                    __NiecDeadSimDescriptionsHousehold_Members.mPetSimDescriptions.Add(deadsimdesc);
                                                else
                                                    __NiecDeadSimDescriptionsHousehold_Members.mSimDescriptions.Add(deadsimdesc);
                                            }
                                            deadsimdesc.mHousehold = ListCollon.__NiecDeadSimDescriptionsHousehold;
                                        }
                                    }

                                    deadsim = deadsimdesc.Instantiate(camera, IsOpenDGSInstalled || cacheISEditWorld);

                                }
                                catch  // Exception info  please use command 'dgsmods exlists' :)
                                {

                                    if (deadsimdesc.mSim == null)
                                    {

                                        if (orahousehold != null && ShuoldOrgHousehold(orahousehold))// && orahousehold != Household.ActiveHousehold)
                                        {
                                            try
                                            {
                                                orahousehold.Remove(deadsimdesc);
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    Household.Members __orahousehold_Members = orahousehold.mMembers;
                                                    if (__orahousehold_Members != null)
                                                    {

                                                        for (int next = 0; next < 5; next++)
                                                        {
                                                            __orahousehold_Members.mAllSimDescriptions.Remove(deadsimdesc);


                                                            __orahousehold_Members.mPetSimDescriptions.Remove(deadsimdesc);

                                                            __orahousehold_Members.mSimDescriptions.Remove(deadsimdesc);
                                                        }

                                                    }


                                                    deadsimdesc.mHousehold = null;
                                                }
                                                catch
                                                { }
                                            }

                                        }
                                        else if (ListCollon.__NiecDeadSimDescriptionsHousehold != null)
                                        {
                                            Household.Members __NHousehold_Members = ListCollon.__NiecDeadSimDescriptionsHousehold.mMembers;
                                            if (__NHousehold_Members != null && __NHousehold_Members.mAllSimDescriptions != null)
                                            {
                                                __NHousehold_Members.mAllSimDescriptions.Remove(deadsimdesc);


                                                __NHousehold_Members.mPetSimDescriptions.Remove(deadsimdesc);

                                                __NHousehold_Members.mSimDescriptions.Remove(deadsimdesc);
                                            }


                                            deadsimdesc.mHousehold = null;
                                        }









                                        deadsimdesc.IsGhost = isghost;
                                        deadsimdesc.mDeathStyle = asdr;
                                        continue;
                                    }
                                    else deadsim = deadsimdesc.mSim;
                                }
                                deadsimdesc.IsNeverSelectable = false;

                                if (deadsim != null || deadsimdesc.mSim != null)
                                {
                                    if (AlarmManager.Global != null)
                                    {
                                        foreach (HelperNra helperNra in helperlist)
                                        {
                                            if (helperNra == null) continue;
                                            if (helperNra.mSimdesc == deadsimdesc)
                                            {
                                                AlarmManager.Global.RemoveAlarm(helperNra.this_alarm);
                                                helperNra.Dispose();
                                            }
                                        }
                                    }

                                    ListCollon.__NiecDeadSimDescriptions.Add(deadsimdesc);

                                    item.DeadSimsDescription = null;
                                    ObjectGuid arss = item.ObjectId;
                                    try
                                    {
                                        item.Destroy();
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            Simulator.DestroyObject(arss);
                                        }
                                        catch
                                        { }

                                    }
                                }
                            }
                        }
                    }
                    else if (temp == "spt" && parameters.Length == 2 && (parameters[1] is int))
                    {
                        int num = (int)parameters[1];
                        if (num < 0 || num > 4) return;
                        if (num != 0 && ScriptCore.GameUtils.GameUtils_IsPausedImpl() && NFinalizeDeath.CheckAccept("UnPaused off?"))
                        {
                            ScriptCore.GameUtils.GameUtils_UnpauseImpl();
                            Responder.Instance.ClockSpeedModel.UnlockGameSpeed();
                        }
                        Sims3.Gameplay.Gameflow.SetGameSpeed((Sims3.SimIFace.Gameflow.GameSpeed)num, false);
                    }
                    else if (temp == "clc2")
                    {
                        clc2_command();
                    }
                    else if (temp == "testyia")
                    {
                        testyia_command();
                    }
                    else if (temp == "exitgame")
                    {
                        exlt_command();
                    }
                    else if (temp == "tmnfunc3x")
                    {
                        tmnfunc3x_command();
                    }
                    else if (temp == "riqrlistloop")
                    {
                        CreateRUQRLLISTLoopTask(false);
                    }
                    else if (temp == "tnhsid")
                    {
                        NiecHelperSituation.TestDivingPool = !NiecHelperSituation.TestDivingPool;
                        NiecException.PrintMessagePro("NHS TestDivingPool: " + NiecHelperSituation.TestDivingPool, false, 50f);
                    }
                    else if (temp == "asimnohouse")
                    {
                        bool bUnSafe = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("bUnSafe");
                        if (ListCollon.NiecSimDescriptions == null)
                            return;

                        NFinalizeDeath.UpdateNiecSimDescriptions();

                        List<Household> householdlist = new List<Household>();

                        foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                        {
                            if (item == null) continue;
                            if (item.IsSpecialHousehold)
                                continue;

                            Household.Members mem = item.mMembers;
                            if (mem == null || mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                                continue;

                            if (!IsOpenDGSInstalled && item.LotHome == null)
                                continue;

                            householdlist.Add(item);
                        }

                        List<SimDescription> hSimlist = new List<SimDescription>();
                        foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
                        {
                            if (item == null) continue;
                            if (string.IsNullOrEmpty(item.mFirstName) && string.IsNullOrEmpty(item.mLastName))
                                continue;
                            if (bUnSafe && !item.IsValidDescription)
                            {
                                try
                                {
                                    item.Fixup();
                                }
                                catch
                                { continue; }
                            }
                            if (item.IsValidDescription && item.Household == null)
                            {
                                hSimlist.Add(item);
                            }
                        }
                        foreach (var item in hSimlist)
                        {
                            Household household = RandomUtil.GetRandomObjectFromList(householdlist, ListCollon.SafeRandom);
                            NFinalizeDeath.Household_Add(household, item, false);
                        }
                        hSimlist.Clear();
                        householdlist.Clear();
                        NFinalizeDeath.TrimHouse(6);
                    }
                    else if (temp == "unpl")
                    {
                        MethodInfo mebinfo = typeof(ScriptCore.ScriptProxy).GetMethod("PostLoad");

                        if (mebinfo != null)
                        {
                            object[] t = new object[0];
                            foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                            {
                                if (item == null) continue;
                                ScriptCore.ScriptProxy sci = NFinalizeDeath.GetProxyWithoutSimIFace(item);
                                if (sci == null) continue;
                                try
                                {
                                    item.mbInited = false;
                                    mebinfo.Invoke(sci, t);
                                }
                                catch (StackOverflowException) { throw; }
                                catch (ResetException) { throw; }
                                catch (Exception)
                                { }

                            }
                        }
                    }
                    else if (temp == "cd")
                    {
                        bool unsafeb = !IsOpenDGSInstalled && NiecHelperSituation.__acorewIsnstalled__;
                        Sim TargetSim = HitTargetSim();
                        if (TargetSim != null && TargetSim != NFinalizeDeath.ActiveActor)
                        {

                            if (TargetSim.mInteractionQueue == null)
                                TargetSim.mInteractionQueue = new InteractionQueue(TargetSim);
                            if (TargetSim.mInteractionQueue.mInteractionList == null)
                            {
                                TargetSim.mInteractionQueue.mInteractionList = new List<InteractionInstance>();
                            }
                            if (unsafeb)
                            {
                                try
                                {
                                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(TargetSim);
                                }
                                catch (Exception)
                                {
                                    TargetSim.mInteractionQueue.mInteractionList = new List<InteractionInstance>();
                                }
                            }
                            var killSim = Urnstone.KillSim.Singleton.CreateInstance
                                    (TargetSim, TargetSim, KillSimNiecX.DGSAndNonDGSPriority(), false, false) as Urnstone.KillSim;

                            killSim.simDeathType = SimDescription.DeathType.Drown;
                            killSim.PlayDeathAnimation = true;

                            TargetSim.InteractionQueue.Add(killSim);
                            if (unsafeb)
                            {
                                item_remove_iq_running_list(TargetSim, true);
                            }
                            ulong objID = unsafeb ? TargetSim.ObjectId.mValue : 0;
                            NFinalizeDeath.ForceDestroyObject(TargetSim);
                            if (objID != 0)
                            {
                                ScriptCore.ScriptProxy proxy = TargetSim.Proxy as ScriptCore.ScriptProxy;
                                if (proxy != null)
                                {
                                    proxy.mTarget = null;
                                    proxy.mObjectId.mValue = 0;
                                }
                            }
                        }
                    }
                    else if (temp == "testgetunsace")
                    {
                        testgetunsace_command();
                    }
                    else if (temp == "aforcesetaa3")
                    {
                        aforcesetaa3_Command(false);
                    }
                    else if (temp == "fixsimlots")
                    {

                        foreach (var item in LotManager.sLots.Values)
                        {
                            if (item == null) continue;
                            if (item.mSims == null)
                                item.mSims = new List<Sim>();
                            else if (item.mAnimals == null)
                                item.mAnimals = new List<Sim>();

                        }
                    }
                    else if (temp == "pdats")
                    {
                        pdats_command();
                    }
                    else if (temp == "alldinv")
                    {
                        alldinv_command();
                    }
                    else if (temp == "ustsimallloop")
                    {
                        ustsimallloop_Command();
                    }
                    else if (temp == "infoplib")
                    {
                        NFinalizeDeath.GC_Emp(NFinalizeDeath.InfoPackagesLib());
                    }
                    else if (temp == "removelms")
                    {
                        LotManager.sActorList.Clear();
                        foreach (var item in LotManager.sLots.Values)
                        {
                            if (item == null) continue;
                            if (item.mSims == null)
                                throw new NullReferenceException("item.mSims == null");
                            else if (item.mAnimals == null)
                                throw new NullReferenceException("item.mAnimals == null");
                            item.mSims.Clear();
                            item.mAnimals.Clear();
                        }
                    }
                    else if (temp == "agrss")
                    {
                        agrss_command();
                    }
                    else if (temp == "removetaskp")
                    {
                        string text = StringInputDialog.Show("NiecMod: Text", "Find Class Name", "Sims3.Gameplay.Core.WorldLot", 256, StringInputDialog.Validation.None);
                        if (string.IsNullOrEmpty(text))
                            return;
                        ITask t;
                        ObjectGuid or;
                        or = NFinalizeDeath.FindTaskPro(null, text, out t);
                        if (or != ObjectGuid.InvalidObjectGuid)
                        {
                            if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Set TickCount Sleep ?"))
                            {
                                ScriptCore.TaskContext context;
                                if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Alarm = null?"))
                                {
                                    Lot oWorldLot = LotManager.GetWorldLot();
                                    if (oWorldLot is WorldLot)
                                    {
                                        if (oWorldLot.mSavedData.mAlarmManager != null)
                                            oWorldLot.mSavedData.mAlarmManager = null;
                                        else
                                            oWorldLot.mSavedData.mAlarmManager = AlarmManager.Global;
                                        return;
                                    }

                                }
                                if (!ScriptCore.TaskControl.GetTaskContext(or.mValue, true, out context) || context.mFrames == null)
                                {
                                    if (text == "Sims3.Gameplay.Core.WorldLot")
                                    {
                                        //AlarmHandle handle = AlarmManager.Global.AddAlarm(1, TimeUnit.Seconds, delegate { Simulator.Sleep(uint.MaxValue); }, null, AlarmType.NeverPersisted, null);
                                        //AlarmManager.Global.mTimerQueue.mItems[0].mValue = handle;

                                        long ticks = SimClock.ConvertToTicks(1, TimeUnit.Seconds);

                                        var alarmHandle = new AlarmHandle(AlarmManager.Global.mLotId, ++AlarmManager.Global.mAlarmCounter);
                                        var timer = new AlarmManager.Timer(
                                            ticks,
                                            delegate
                                            {
                                                if (!IsOpenDGSInstalled)
                                                    Simulator.Sleep(uint.MaxValue);
                                            },
                                            alarmHandle,
                                            null, // EA DEBUG?
                                            AlarmType.NeverPersisted,
                                            null
                                        );

                                        AlarmManager.Global.InternalAddAlarm(timer);

                                        Sims3.Collections.PriorityQueue.QueueItem[] ay = AlarmManager.Global.mTimerQueue.mItems;
                                        int i;
                                        for (i = 0; i < ay.Length; i++)
                                        {
                                            if (ay[i].mValue == timer)
                                            {
                                                break;
                                            }
                                        }




                                        long keylong = ay[0].mKey;

                                        object obj = ay[0].mValue;

                                        ay[0].mKey = timer.AlarmDateAndTime.Ticks;
                                        ay[0].mValue = timer;


                                        ay[i].mKey = keylong;
                                        ay[i].mValue = obj;

                                        //if (!IsOpenDGSInstalled)
                                        //{
                                        //
                                        //    long dayticks = SimClock.ConvertToTicks(1, TimeUnit.Days);
                                        //    long nowTime = SimClock.CurrentTime().Ticks;
                                        //
                                        //    //foreach (var item in ay) // VS 2010 bug build
                                        //    for (int ai = 0; ai < ay.Length; ai++)
                                        //    {
                                        //        if (ai == 0)
                                        //            continue;
                                        //        dayticks++;
                                        //
                                        //        DateAndTime dateandtime = new DateAndTime(nowTime + dayticks);
                                        //
                                        //        Sims3.Collections.PriorityQueue.QueueItem item = ay[ai];
                                        //
                                        //        item.mKey = dateandtime.Ticks;
                                        //        AlarmManager.Timer aiTimer = item.mValue as AlarmManager.Timer;
                                        //        if (aiTimer == null) continue;
                                        //        aiTimer.AlarmDateAndTime = dateandtime;//.Ticks = dayticks;
                                        //    }
                                        //}
                                        //AlarmManager.Global.mTimerQueue.Add(keyLoung, obj);
                                    }
                                    return;
                                }

                                int.TryParse(
                                    StringInputDialog.Show(
                                        "NiecMod", "Tick: " + context.mSleepTicks + "\nNoSleep: -1\nInfiniteSleep: -2\nForceReset: -3", context.mSleepTicks.ToString(), 50, StringInputDialog.Validation.None
                                    ),
                                    out context.mSleepTicks
                                );
                                if (ScriptCore.TaskControl.SetTaskContext(or.mValue, ref context))
                                    SimpleMessageDialog.Show("NiecMod_DEBUG", "Done Set Sleep.");

                            }
                            else if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Simulator.Wake"))
                            {
                                Simulator.Wake(or, false);
                            }
                            else
                            {
                                IDisposable sdispose = t as IDisposable;
                                if (sdispose != null && !(t is Sim))
                                {
                                    try
                                    {
                                        sdispose.Dispose();
                                    }
                                    catch
                                    { }
                                    Simulator.Sleep(0);

                                }
                                Simulator.DestroyObject(or);
                                SimpleMessageDialog.Show("NiecMod", "Task Destroyed.\nID: " + or.ToString());
                            }
                        }
                        else
                            SimpleMessageDialog.Show("NiecMod", "Could not find Text:\n" + text);
                    }
                    else if (temp == "ffindgood")
                    {
                        ffindgood_command();
                    }
                    else if (temp == "dtclist")
                    {
                        dtclist_command();
                    }
                    else if (temp == "exlists")
                    {
                        exlists_command();
                    }
                    else if (temp == "extestcpu")
                    {
                        extestcpu_command();
                    }
                    else if (temp == "exlists2")
                    {
                        exlists2_command();
                    }
                    else if (temp == "exlists3")
                    {
                        exlists3_command();
                    }
                    else if (temp == "usam")
                    {
                        usam_Command();
                    }
                    else if (temp == "removetask")
                    {
                        if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Custom Text?"))
                        {
                            string text = StringInputDialog.Show("NiecMod: Text", "Find Call Stack", "at Void Sims3.Gameplay.Roles.RoleManagerTask.Simulate()", 256, StringInputDialog.Validation.None);
                            if (string.IsNullOrEmpty(text))
                                return;
                            ObjectGuid or;// = NFinalizeDeath.FindTask(text, null);
                            if (NFinalizeDeath.CheckAccept("for (int i = 0; i < 1000; i++)"))
                            {
                                int isleep = -5;
                                if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Set TickCount Sleep ?"))
                                {

                                    int.TryParse(
                                        StringInputDialog.Show(
                                            "NiecMod", "Tick\nNoSleep: -1\nInfiniteSleep: -2\nForceReset: -3", "5", 50, StringInputDialog.Validation.None
                                        ),
                                        out isleep
                                    );
                                    try
                                    {
                                        Simulator.YieldingDisabled = true;
                                        foreach (var item in ScriptCore.Simulator.mObjHash)
                                        {
                                            if (item.Value == null)
                                                continue;
                                            string st = NFinalizeDeath.____GetObjectStackTrace(item.Key);

                                            if (st == null || st == "<no call stack>")
                                                continue;
                                            if (st.Contains(text))
                                            {
                                                ScriptCore.TaskContext context;
                                                if (!ScriptCore.TaskControl.GetTaskContext(item.Key, true, out context) || context.mFrames == null)
                                                    continue;
                                                context.mSleepTicks = isleep;
                                                ScriptCore.TaskControl.SetTaskContext(item.Key, ref context);

                                            }
                                        }
                                    }
                                    finally
                                    {
                                        Simulator.YieldingDisabled = false;
                                    }

                                    return;
                                }
                                for (int i = 0; i < 1000; i++)
                                {
                                    ITask t;
                                    or = NFinalizeDeath.FindTaskPro(text, null, out t);
                                    if (or != ObjectGuid.InvalidObjectGuid)
                                    {
                                        //if (isleep == -5)
                                        //{
                                        //    IDisposable sdispose = t as IDisposable; // NRaas Task Evil NRaas.CommonSpace.Tasks.RepeatingTask.Simulate()?
                                        //    if (sdispose != null && !(t is Sim))
                                        //    {
                                        //        try
                                        //        {
                                        //            sdispose.Dispose();
                                        //        }
                                        //        catch
                                        //        { }
                                        //        Simulator.Sleep(0);
                                        //
                                        //    }
                                        //    Simulator.DestroyObject(or);
                                        //    Simulator.Sleep(0);
                                        //}
                                        //else
                                        //{
                                        //    ScriptCore.TaskContext context;
                                        //    if (!ScriptCore.TaskControl.GetTaskContext(or.mValue, true, out context) || context.mFrames == null)
                                        //        continue;
                                        //    if (context.mSleepTicks != isleep)
                                        //        continue;
                                        //    context.mSleepTicks = isleep;
                                        //    ScriptCore.TaskControl.SetTaskContext(or.mValue, ref context);
                                        //}
                                        IDisposable sdispose = t as IDisposable; // NRaas Task Evil NRaas.CommonSpace.Tasks.RepeatingTask.Simulate()?
                                        if (sdispose != null && !(t is Sim))
                                        {
                                            try
                                            {
                                                sdispose.Dispose();
                                            }
                                            catch
                                            { }
                                            Simulator.Sleep(0);

                                        }
                                        Simulator.DestroyObject(or);
                                        Simulator.Sleep(0);
                                    }
                                    else break;
                                }
                            }
                            else
                            {
                                ITask t;
                                or = NFinalizeDeath.FindTaskPro(text, null, out t);
                                if (or != ObjectGuid.InvalidObjectGuid)
                                {
                                    if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Set TickCount Sleep ?"))
                                    {
                                        ScriptCore.TaskContext context;
                                        if (!ScriptCore.TaskControl.GetTaskContext(or.mValue, true, out context) || context.mFrames == null)
                                            return;
                                        int.TryParse(
                                            StringInputDialog.Show(
                                                "NiecMod", "Tick: " + context.mSleepTicks + "\nNoSleep: -1\nInfiniteSleep: -2\nForceReset: -3" + "-2", "5", 50, StringInputDialog.Validation.None
                                            ),
                                            out context.mSleepTicks
                                        );
                                        if (ScriptCore.TaskControl.SetTaskContext(or.mValue, ref context))
                                            SimpleMessageDialog.Show("NiecMod_DEBUG", "Done Set Sleep.");

                                    }
                                    else if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Simulator.Wake"))
                                    {
                                        Simulator.Wake(or, false);
                                    }
                                    else
                                    {
                                        IDisposable sdispose = t as IDisposable; // NRaas Task Evil NRaas.CommonSpace.Tasks.RepeatingTask.Simulate()?
                                        if (sdispose != null && !(t is Sim))
                                        {
                                            try
                                            {
                                                sdispose.Dispose();
                                            }
                                            catch
                                            { }
                                            Simulator.Sleep(0);

                                        }
                                        Simulator.DestroyObject(or);
                                        SimpleMessageDialog.Show("NiecMod", "Task Destroyed.\nID: " + or.ToString());
                                    }
                                }
                                else
                                    SimpleMessageDialog.Show("NiecMod", "Could not find Text:\n" + text);
                            }
                        }
                        else
                        {
                            Simulator.DestroyObject(NFinalizeDeath.FindTask("at Void NRaas.RegisterSpace.Tasks.RoleManagerTaskEx.Simulate()", null));
                            Simulator.DestroyObject(NFinalizeDeath.FindTask("at Void Sims3.Gameplay.Roles.RoleManagerTask.Simulate()", null));
                            if (!IsOpenDGSInstalled)
                            {
                                Simulator.DestroyObject(NFinalizeDeath.FindTask("at Void Sims3.Gameplay.Services.Services.Simulate()", null));
                            }
                        }
                    }
                    else if (temp == "removeallhelpernra")
                    {
                        AlarmManager alram = AlarmManager.Global;
                        //if (alram == null) 
                        //    return;
                        foreach (HelperNra helperNra in HelperNra.HelperNraLists.ToArray())
                        {
                            if (helperNra == null)
                                continue;
                            if (alram != null)
                                alram.RemoveAlarm(helperNra.this_alarm);
                            helperNra.Dispose();
                        }
                    }
                    else if (temp == "rallg")
                    {


                        if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Unsafe"))
                            goto st;
                        if (ListCollon.NiecSimDescriptions == null)
                            goto st;
                        try
                        {
                            NFinalizeDeath.UpdateNiecSimDescriptions();

                            List<Household> householdlist = new List<Household>();

                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null) continue;
                                if (item.IsSpecialHousehold)
                                    continue;

                                Household.Members mem = item.mMembers;
                                if (mem == null || mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                                    continue;

                                if (!IsOpenDGSInstalled && item.LotHome == null)
                                    continue;

                                householdlist.Add(item);
                            }
                            if (householdlist.Count == 0 && RandomUtil.RandomChance(10))
                            {
                                householdlist.Add(Household.sNpcHousehold ?? Household.sServobotHousehold ?? Household.sPetHousehold ?? Household.ActiveHousehold);
                            }
                            if (householdlist.Count == 0)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    Household va = Household.Create();
                                    SimDescription simd = NFinalizeDeath.CreateRandomSimDescription();
                                    va.Name = simd.mLastName ?? "";
                                    va.Add(simd);
                                    Create.AutoMoveInLotFromHousehold(va);
                                    householdlist.Add(va);
                                }

                            }

                            if (householdlist.Count == 0)
                            {
                                goto st;
                            }
                            List<SimDescription> hSimlist = new List<SimDescription>();
                            foreach (var item in ListCollon.NiecSimDescriptions.ToArray())
                            {
                                if (item == null) continue;
                                if (string.IsNullOrEmpty(item.mFirstName) && string.IsNullOrEmpty(item.mLastName))
                                    continue;
                                if (!item.IsValidDescription)
                                {
                                    try
                                    {
                                        item.Fixup();
                                    }
                                    catch
                                    { item.mIsValidDescription = false; continue; }
                                }
                                if (item.IsValidDescription && item.Household == null)
                                {
                                    item.mDeathStyle = SimDescription.DeathType.None;
                                    item.IsGhost = false;
                                    hSimlist.Add(item);
                                }
                            }
                            if (hSimlist.Count == 0) { }
                            else
                            {
                                foreach (var item in hSimlist)
                                {
                                    Household household = RandomUtil.GetRandomObjectFromList(householdlist, ListCollon.SafeRandom);
                                    NFinalizeDeath.Household_Add(household, item, false);
                                }

                                hSimlist.Clear();
                            }
                            householdlist.Clear();

                            NFinalizeDeath.TrimHouse(6);

                        }
                        catch (ResetException)
                        { throw; }
                        catch { }

                    st: Vector3 em = Vector3.OutOfWorld;
                        int sieeo = 0;
                        foreach (var item in NFinalizeDeath.SC_GetObjects<Urnstone>())
                        {
                            sieeo++;
                            if (sieeo > 150) { sieeo = 0; Simulator.Sleep(0); }
                            if (NFinalizeDeath.IsKeepGrave(item))
                                continue;
                            item.SetPosition(em);
                            item.DeadSimsDescription = null;
                            NFinalizeDeath.ForceDestroyObject(item, false);
                        }
                    }
                    else if (temp == "dcdgs")
                    {
                        dcdgs_command();
                    }
                    else if (temp == "testpyd")
                    {
                        testpyd_command();
                    }
                    else if (temp == "unsaferunnnull")
                    {
                        unsaferunnnull_command();
                    }
                    else if (temp == "testfastcode01")
                    {
                        testfastcode01_command();
                    }
                    else if (temp == "chouselotnos")
                    {
                        chouselotnos_command();
                    }
                    else if (temp == "cdeadsimtosim")
                    {

                        // Create NiecNullSimDescription

                        Create.NiecNullSimDescription();

                        // OpenDGS?

                        Sim activeActor_ChildAndTeen = NFinalizeDeath.ActiveActor_AAndChildAndTeen;
                        Sim selectedActor_ChildAndTeen = NFinalizeDeath.SelectedActor_ChildAndTeen;
                        Sim targetSim = HitTargetSim();


                        Vector3 pos =
                            (activeActor_ChildAndTeen != null) ?
                                activeActor_ChildAndTeen.Position :
                            (selectedActor_ChildAndTeen != null) ?
                                selectedActor_ChildAndTeen.Position :
                            (targetSim != null) ?
                                targetSim.Position :
                            CameraController.GetTarget();
                        //if (NFinalizeDeath.CheckAccept("Clear Death?")) { }


                        Urnstone[] eras = NFinalizeDeath.SC_GetObjects<Urnstone>();
                        bool t299 = eras.Length > 299;
                        if (NFinalizeDeath.CheckAccept("Clear Death?"))
                        {
                            int sleep = 0;
                            foreach (var item in eras)
                            {
                                if (t299)
                                {
                                    sleep++;
                                    if (sleep > 11)
                                    {
                                        sleep = 0;
                                        Simulator.Sleep(0);
                                    }
                                }
                                SimDescription deadsimdesc = item.DeadSimsDescription;
                                if (deadsimdesc != null)
                                {
                                    item.mPlayerMoveable = true;
                                    item.DeadSimsDescription = deadsimdesc;
                                    item.SetHiddenFlags(HiddenFlags.Nothing);
                                    item.SetOpacity(1f, 0f);
                                    item.AddToWorld();
                                    item.FadeIn();
                                    if (t299)
                                        pos =
                                            (activeActor_ChildAndTeen != null) ?
                                                activeActor_ChildAndTeen.Position :
                                            (selectedActor_ChildAndTeen != null) ?
                                                selectedActor_ChildAndTeen.Position :
                                            (targetSim != null) ?
                                                targetSim.Position :
                                            CameraController.GetTarget();
                                    item.SetPosition(pos);
                                    item.SetFlags(GameObject.FlagField.InInventory, false);
                                    try
                                    {
                                        item.FogEffectStop(VisualEffect.TransitionType.HardTransition);
                                        if (item.mActorsUsingMe != null)
                                            item.mActorsUsingMe.Clear();
                                    }
                                    catch
                                    { }

                                }
                                else if (item.LotCurrent != null && item.LotCurrent.IsWorldLot)
                                {
                                    ObjectGuid arss = item.ObjectId;
                                    try
                                    {
                                        item.Destroy();
                                    }
                                    catch // Force Destroy Object
                                    {
                                        try
                                        {
                                            Simulator.DestroyObject(arss);
                                        }
                                        catch
                                        { }

                                    }

                                }
                            }
                            goto ra;
                        }
                        else
                        {
                            Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                            foreach (var item in ListCollon.__NiecDeadSimDescriptions.ToArray())
                            {
                                ListCollon.__NiecDeadSimDescriptions.Remove(item);
                                if (item == null)
                                {
                                    continue;
                                }
                                if (item.Household != null && item.Household == ActiveHousehold)
                                    continue;
                                Urnstone grage = Create.DeadSimGrave(item.mDeathStyle, item, false, false, true);
                                if (grage != null)
                                {
                                    if (item.Household != null && item.Household != ListCollon.__NiecDeadSimDescriptionsHousehold)
                                        grage.mOriginalHouseholdId = item.Household.mHouseholdId;



                                    grage.DeadSimsDescription = item;

                                    grage.SetHiddenFlags(HiddenFlags.Nothing);
                                    grage.FadeIn();
                                    grage.SetPosition(pos);


                                    Sim CreateSim = item.mSim;

                                    try
                                    {
                                        if (CreateSim != null)
                                        {
                                            NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(CreateSim);
                                            CreateSim.mPosture = CreateSim.Standing;
                                            ObjectGuid arss = CreateSim.ObjectId;
                                            try
                                            {
                                                CreateSim.Destroy();
                                            }
                                            catch
                                            {
                                                try
                                                {
                                                    Simulator.DestroyObject(arss);
                                                }
                                                catch
                                                { }

                                            }
                                        }
                                    }
                                    catch
                                    { }






                                    CreateSim.mSimDescription = ListCollon.NullSimSimDescription;
                                    //item.mHousehold = null;
                                    NFinalizeDeath.Household_Remove(item, false);

                                }
                                else throw new NotSupportedException("NiecMod: Failed to Create Grave!");
                            }
                        }

                        if (ListCollon.__NiecDeadSimDescriptionsHousehold != null)
                        {
                            Household.Members memx = ListCollon.__NiecDeadSimDescriptionsHousehold.mMembers;
                            if (memx != null)
                            {

                                memx.mAllSimDescriptions.Clear();  // = new List<SimDescription>();

                                memx.mPetSimDescriptions.Clear();// = new List<SimDescription>();

                                memx.mSimDescriptions.Clear();// = new List<SimDescription>();
                            }
                        }

                        NFinalizeDeath.HouseholdCleanse(ListCollon.__NiecDeadSimDescriptionsHousehold, true, false);
                        ListCollon.__NiecDeadSimDescriptionsHousehold = null;

                    ra: ;

                        if (NFinalizeDeath.CheckAccept("ListCollon.__NiecDeadSimDescriptions.Clear();"))
                            ListCollon.__NiecDeadSimDescriptions.Clear();

                    }
                    else if (temp == "destroyalltargetlot")
                    {
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);

                        int rara = 0;
                        if (TargetLot != null)
                        {
                            Sim sim = NFinalizeDeath.ActiveActor;
                            Household ActiveHousehold = null;
                            if (sim != null)
                                ActiveHousehold = sim.Household;
                            PlumbBob bob = PlumbBob.sSingleton;
                            foreach (var iteam in NFinalizeDeath.SC_GetObjectsOnLot<IScriptLogic>(TargetLot))
                            {


                                if (iteam == null)
                                    continue;
                                if (iteam == sim || iteam == bob)
                                    continue;
                                GameObject item = iteam as GameObject;
                                if (item == null)
                                    continue;
                                int Cost = 0;
                                if (item is Sim)
                                    Cost = 11000;
                                else
                                {
                                    try
                                    {
                                        Cost = item.Cost;
                                    }
                                    catch
                                    { Cost = 105; }
                                }
                                //ObjectGuid arss = item.ObjectId;
                                //try
                                //{
                                //    item.Destroy();
                                //    if (!item.HasBeenDestroyed)
                                //    {
                                //        try
                                //        {
                                //            Simulator.DestroyObject(arss);
                                //        }
                                //        catch
                                //        { }
                                //    }
                                //}
                                //catch
                                //{
                                //    try
                                //    {
                                //        Simulator.DestroyObject(arss);
                                //    }
                                //    catch
                                //    { }
                                //
                                //
                                //}
                                NFinalizeDeath.ForceDestroyObject(item, false);
                                if (ActiveHousehold != null)
                                {
                                    rara += Cost;
                                }
                            }
                            if (ActiveHousehold != null)
                            {
                                ActiveHousehold.SetFamilyFunds(rara + 10, false);
                            }
                        }
                    }
                    else if (temp == "unsaferunnnullpro")
                    {
                        unsaferunnnullpro_command();
                    }
                    else if (temp == "tev")
                    {
                        tev_command(false);
                    }
                    else if (temp == "dipetname")
                    {
                        dipetname_command();
                    }
                    else if (temp == "setfuncptr")
                    {
                        setfuncptr_commnad();
                    }
                    else if (temp == "dkeyname")
                    {
                        dkeyname_command();
                    }
                    else if (temp == "settextpos")
                    {
                        if (!Simulator.CheckYieldingContext(false)) return;

                        //Sim sim = HitTargetSim() ?? PlumbBob.SelectedActor;
                        //if (sim != null)
                        {

                            string textpos = StringInputDialog.Show("NiecMod: Text Pos", "X: Y: Z:", CameraController.GetTarget().ToString(), 256, StringInputDialog.Validation.None);
                            if (string.IsNullOrEmpty(textpos))
                                return;

                            textpos = textpos.Trim();

                            textpos = textpos.Replace("(", "").Replace(")", "");

                            if (string.IsNullOrEmpty(textpos))
                                return;

                            float x, y, z;

                            string[] pos = textpos.Split(new string[] { ", ", "," }, StringSplitOptions.None);

                            if (pos.Length == 3)
                            {

                                float.TryParse(pos[0], out x);
                                float.TryParse(pos[1], out y);
                                float.TryParse(pos[2], out z);




                                Sim sim = null;

                                sim = PlumbBob.SelectedActor;

                                if (sim != null && NFinalizeDeath.CheckAccept("Active Actor"))
                                {
                                    sim.SetPosition(new Vector3(x, y, z));

                                    if (sim.SimRoutingComponent != null)
                                        sim.SimRoutingComponent.ForceUpdateDynamicFootprint();

                                    return;
                                }

                                sim = null;

                                SimpleMessageDialog.Show("NiecMod", "Please Hit Target Sim :)");


                                for (int i = 0; i < 550; i++)
                                {
                                    Simulator.Sleep(0);



                                    if (sim != null)
                                    {
                                        sim.SetPosition(new Vector3(x, y, z));

                                        if (sim.SimRoutingComponent != null)
                                            sim.SimRoutingComponent.ForceUpdateDynamicFootprint();

                                        return;
                                    }
                                    sim = HitTargetSim();
                                }

                                if (sim == null)
                                    sim = PlumbBob.SelectedActor;

                                if (sim != null)
                                {
                                    sim.SetPosition(new Vector3(x, y, z));

                                    if (sim.SimRoutingComponent != null)
                                        sim.SimRoutingComponent.ForceUpdateDynamicFootprint();
                                }
                            }
                            else NiecException.PrintMessage("Text Invalid");
                        }
                    }
                    else if (temp == "ussdjig")
                    {
                        ussdjig_command();
                    }
                    else if (temp == "nhsexaa")
                    {
                        nhsexaa_command();
                    }
                    else if (temp == "clearetdata")
                    {
                        NiecRunCommand.clearetdata_Command();
                    }
                    else if (temp == "fixisghost")
                    {
                        int isleep = 0;
                        if (NFinalizeDeath.CheckAccept("Fix Household is Null"))
                        {
                            foreach (var AllActor in NFinalizeDeath.SC_GetObjects<Sim>())
                            {
                                isleep++;
                                if (isleep > 85)
                                {
                                    isleep = 0;
                                    NFinalizeDeath.SleepTask(10);
                                }

                                SimDescription AllActorSimDesc = AllActor.SimDescription;
                                if (AllActorSimDesc == null)
                                    continue;

                                if (AllActorSimDesc.IsGhost || AllActorSimDesc.mDeathStyle != 0)
                                {
                                    bool isSpecialHousehold = false;
                                    if (AllActorSimDesc.Household == Household.sNpcHousehold)
                                    {
                                        isSpecialHousehold = true;
                                        NFinalizeDeath.Household_Remove(AllActorSimDesc, true);
                                        AllActorSimDesc.mHousehold = null;
                                    }

                                    Household originalHousehold = null;

                                    var grave = HelperNra.TFindGhostsGrave(AllActorSimDesc);
                                    if (grave != null && grave.mOriginalHouseholdId != 0)
                                        originalHousehold =
                                            NFinalizeDeath.Find_SCGetHouseholds(grave.mOriginalHouseholdId) ??
                                            NFinalizeDeath.Find_HouseholdList(grave.mOriginalHouseholdId);

                                    if (originalHousehold == Household.sNpcHousehold)
                                        originalHousehold = null;
                                    if (NFinalizeDeath.IsSpecialHousehold(AllActorSimDesc.Household))
                                    {
                                        isSpecialHousehold = true;
                                        NFinalizeDeath.Household_Remove(AllActorSimDesc, true);
                                    }
                                    try
                                    {
                                        NFinalizeDeath.ResuetSim(AllActorSimDesc, originalHousehold, true, isSpecialHousehold);
                                    }
                                    catch (StackOverflowException)
                                    {
                                        throw;
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                    }
                                    catch { }

                                }
                            }
                        }
                        isleep = 0;
                        foreach (var AllActor in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            isleep++;
                            if (isleep > 85)
                            {
                                isleep = 0;
                                NFinalizeDeath.SleepTask(10);
                            }

                            SimDescription AllActorSimDesc = AllActor.SimDescription;
                            if (AllActorSimDesc == null || AllActorSimDesc.mHairColors == null)
                                continue;

                            if (AllActorSimDesc.Household == null)
                                continue;

                            if (AllActorSimDesc.Household == Household.sNpcHousehold && HelperNra.TFindGhostsGrave(AllActorSimDesc) != null)
                                continue;

                            AllActorSimDesc.IsGhost = false;
                            AllActorSimDesc.mDeathStyle = SimDescription.DeathType.None;
                            AllActorSimDesc.IsNeverSelectable = false;

                            if (NFinalizeDeath.GameObjectAllIsValid(AllActor.ObjectId.mValue)) //Simulator.GetProxy(AllActor.ObjectId) != null)
                                World.ObjectSetGhostState(AllActor.ObjectId, 0, (uint)AllActorSimDesc.AgeGenderSpecies);
                        }
                    }

                    else if (temp == "rtnodark")
                    {
                        rtnodark_command();
                    }
                    else if (temp == "exitniechs")
                    {
                        //var st = Situation.sAllSituations;
                        foreach (var Target in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            NiecHelperSituation situationOfType = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(Target);//Target.GetSituationOfType<NiecHelperSituation>();
                            if (situationOfType != null)
                            {
                                situationOfType.Exit();
                                Target.Autonomy.SituationComponent.RemoveRole(situationOfType);


                                //foreach (var item in st)
                                //{
                                //    if (item == situationOfType)
                                //        st.Remove(situationOfType);
                                //}
                            }
                        }
                    }
                    else if (temp == "deltargetsimdesc")
                    {
                        Sim Target = HitTargetSim();
                        if (Target != null)// && !NFinalizeDeath.IsSimFastActiveHousehold(Target) && !Target.IsInActiveHousehold)
                        {

                            if (Target == NFinalizeDeath.ActiveActor)
                            {
                                NiecException.PrintMessagePro("Active Actor is not allowed.\nObjectID: " + Target.ObjectId, false, 10);
                            }
                            else if (NFinalizeDeath.IsAllActiveHousehold_SimObject(Target) //(NFinalizeDeath.IsSimFastActiveHousehold(Target) || Target.IsInActiveHousehold)
                                        && !NFinalizeDeath.CheckAccept("Are you sure Delete SimDescription?"))
                            {
                                return;
                            }
                            else
                            {
                                SimDescription asdirr = Target.SimDescription;
                                if (!IsOpenDGSInstalled)
                                {
                                    NFinalizeDeath.Household_Remove(asdirr, false);
                                    var createSim = asdirr.CreatedSim; // i not Target
                                    if (createSim != null)
                                    {
                                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(createSim);
                                        try
                                        {
                                            if (createSim.mActorsUsingMe != null && createSim.mActorsUsingMe.Count != 0)
                                                createSim.mActorsUsingMe.Clear();

                                            if (createSim.mReferenceList != null && createSim.mReferenceList.Count != 0)
                                                createSim.mReferenceList.Clear();

                                            if (createSim.mRoutingReferenceList != null && createSim.mRoutingReferenceList.Count != 0)
                                                createSim.mRoutingReferenceList.Clear();
                                        }
                                        catch (Exception)
                                        { }
                                    }
                                }
                                for (int i = 0; i < 5; i++)
                                {
                                    NFinalizeDeath.SimDescCleanse(asdirr, true, false);
                                    Simulator.Sleep(0);
                                }
                            }
                        }
                    }
                    else if (temp == "dnoneedall")
                    {
                        dnoneedall_command();
                    }
                    else if (temp == "sdjig")
                    {
                        sdjig_command();
                    }
                    else if (temp == "allnewnsw")
                    {
                        //NiecSocialWorkerChildAbuseSituation niecSWCAS;
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null && !TargetLot.IsWorldLot)
                        {
                            if (TargetLot.Household != null)
                            {
                                // NFinalizeDeath.CreateSocialWorkerToTargetLot(TargetLot,
                                //     NFinalizeDeath.DefaultTest_NiecSocialWorkerChildAbuseSituation, Simulator.CheckYieldingContext(false)
                                //     && NFinalizeDeath.CheckAccept("bUnSafe"), out niecSWCAS);
                                foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                                {
                                    if (item.LotCurrent == TargetLot)
                                        continue;
                                    if (!NFinalizeDeath.DefaultTest_NiecSocialWorkerChildAbuseSituation(item))
                                        continue;
                                    NiecSocialWorkerChildAbuseSituation.Create(
                                         TargetLot, // Target Lot
                                         item, // Worker Sim
                                         true, // Add Situation List
                                         true // UnSafe
                                    );
                                }

                            }
                            else
                                SimpleMessageDialog.Show("NiecMod", "TargetLot.Household == null");
                        }
                        else SimpleMessageDialog.Show("NiecMod", "TargetLot == null");
                    }
                    else if (temp == "testmbox")
                    {
                        testmbox_command();
                    }
                    else if (temp == "dasc2020")
                    {
                        dasc2020_command();
                    }
                    else if (temp == "dtoa")
                    {
                        GameObject TargetGameObject = HitTargetGameObject();
                        if (TargetGameObject != null)
                        {
                            Slots.DetachFromSlot(TargetGameObject.ObjectId);
                        }
                    }
                    else if (temp == "stoa")
                    {
                        if (!Simulator.CheckYieldingContext(false)) return;

                        if (objstoa == null || GameObjectHasDestroyed(objstoa))
                        {
                            objstoa = HitTargetGameObject();
                        }
                        else
                        {
                            GameObject TargetGameObject = HitTargetGameObject();
                            if (TargetGameObject != null && objstoa != TargetGameObject)
                            {
                                ulong i;
                                ulong.TryParse(
                                    StringInputDialog.Show(
                                       "NiecMod", "Slot Name Hash", "1318179674", 10, StringInputDialog.Validation.None
                                    ),
                                    out i
                                );
                                if (i > uint.MaxValue || i < uint.MinValue)
                                {
                                    objstoa = null;
                                    return;
                                }
                                bool OccupySlot = NFinalizeDeath.CheckAccept("Occupy Slot");
                                var tr = Slots.CanAttachToSlot(TargetGameObject.ObjectId, objstoa.ObjectId, (uint)i, OccupySlot);
                                if (!Slots.IsSuccess(tr))
                                {
                                    SimpleMessageDialog.Show("NiecMod", "Could not attach\nResult: " + tr + "\nSlotHash: " + i);
                                }
                                else Slots.AttachToSlot(TargetGameObject.ObjectId, objstoa.ObjectId, (uint)i, OccupySlot);
                                objstoa = null;
                            }

                        }
                    }
                    else if (temp == "delallsim")
                    {
                        delallsim_command();
                    }
                    else if (temp == "keepcreatesim")
                    {
                        keepcreatesim_command();
                    }
                    else if (temp == "addbuff")
                    {
                        Sim ActiveActor = PlumbBob.SelectedActor;
                        if (ActiveActor != null)
                        {
                            ActiveActor.BuffManager.AddBuff(BuffNames.FeelingGood, 150, 200.5f, true, MoodAxis.Happy, Origin.FromAmbrosia, true);
                            /*
                            if (!IsOpenDGSInstalled) {
                                adsrt = !adsrt;
                                if (adsrt)
                                {
                                    var list = (Simulator.ProfilerNames[])Enum.GetValues(typeof(Simulator.ProfilerNames));// as Simulator.ProfilerNames[];
                                    foreach (var item in list)
                                    {
                                        Simulator.StartProfiler(item);
                                        //Simulator.ProfilerDoAction(Simulator.ProfilerAction.ActionBegin, Simulator.ProfilerNames.ProfilerEcho);
                                    }
                                }
                                else
                                {
                                    var list = (Simulator.ProfilerNames[])Enum.GetValues(typeof(Simulator.ProfilerNames));// as Simulator.ProfilerNames[];
                                    foreach (var item in list)
                                    {
                                        Simulator.StopProfiler(item);
                                    }
                                }
                                
                            }
                             * */
                        }
                    }
                    else if (temp == "tmsfunc2")
                    {
                        tmsfunc2_command();
                    }
                    else if (temp == "dkeygivename")
                    {
                        dkeygivename_command();
                    }
                    else if (temp == "slotlist")
                    {
                        GameObject TargetGameObject = HitTargetGameObject();
                        if (TargetGameObject != null)
                        {
                            ObjectGuid oId = TargetGameObject.ObjectId;
                            Slot[] slots = Slots.GetContainmentSlotNames(oId);
                            if (slots == null || slots.Length == 0) return;
                            StringBuilder st = new StringBuilder();
                            foreach (var item in slots)
                            {
                                // if (item == null) 
                                //     continue;
                                st.Append("\nSlot: " + ((uint)item).ToString() + "\nObject List: " + NFinalizeDeath.GetObjectGuidListInfo(Slots.GetChildren(oId, item)) + "\nEnd Object List\n");
                            }
                            NiecException.WriteLog(st.ToString());
                        }
                    }
                    else if (temp == "usev2")
                    {
                        usev2_command();
                    }
                    else if (temp == "dsup")
                    {
                        Sim HitTarget = HitTargetSim();
                        if (HitTarget == null) return;
                        var _SimUpdate = NFinalizeDeath.GetSimUpdate(HitTarget);
                        if (_SimUpdate != null)
                        {
                            Simulator.DestroyObject(HitTarget.mSimUpdateId);
                            HitTarget.mSimUpdateId = new ObjectGuid(0);
                        }
                    }
                    else if (temp == "uloopnhs")
                    {
                        Sim HitTarget = HitTargetSim();
                        if (HitTarget != null && HitTarget.InteractionQueue != null)
                        {
                            NinecReaper custi = HitTarget.CurrentInteraction as NinecReaper;
                            if (custi != null && custi.CustomRunName == "uloopnhs")
                            {
                                HitTarget.SetToResetAndSendHome();
                            }
                            else
                            {
                                NinecReaper.CustomRun cuRun = delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                                {
                                    Sim target = Target;
                                    if (target == Actor)
                                    {
                                        target = null;
                                        do
                                        {
                                            target = HitTargetSim() ?? Actor;
                                            if (NFinalizeDeath.GetCurrentExecuteType() == ScriptExecuteType.Threaded)
                                                Simulator.Sleep(0);
                                            else
                                                Simulator.Sleep(1);
                                        }
                                        while (target == Actor);
                                    }

                                    var it = NiecHelperSituation.ExistsOrCreateAndAddToSituationList(Actor).CreateInteraction(target);
                                    while (it != null && it.Target != null)
                                    {
                                        NFinalizeDeath._RunInteraction(it);
                                        if (IsOpenDGSInstalled)
                                        {
                                            var simIQ = HitTarget.InteractionQueue;
                                            if (simIQ != null)
                                                simIQ.PutDownCarriedObjects(it);
                                        }
                                        Simulator.Sleep(0);
                                    }
                                    return true;
                                };
                                NinecReaper niecr = NinecReaper.AddToInteranctionQueue(HitTarget, HitTarget, cuRun);
                                niecr.CustomRunName = "uloopnhs";
                            }
                        }
                    }
                    else if (temp == "testksmym")
                    {
                        NInjetMethed.Bim_InjectKillMethed();
                    }
                    else if (temp == "testexs")
                    {
                        Sim HitTarget = HitTargetSim();
                        if (HitTarget != null)
                        {
                            NinecReaper custi = HitTarget.CurrentInteraction as NinecReaper;
                            if (custi != null && custi.CustomRunName == "ForceLoopIdleNoSimUpdate")
                            {
                                Simulator.Wake(HitTarget.ObjectId, false);
                            }
                            else
                            {
                                NinecReaper.CustomRun cuRun = delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                                {

                                    using (SafeSimUpdate.Run(Actor))
                                    {
                                        Actor.LoopIdle();
                                        Simulator.Sleep(uint.MaxValue);
                                    }
                                    Actor.ClearExitReasons();

                                    if (!IsOpenDGSInstalled)
                                        return new Object_ActorsSim.NReadSomethingInInventory() { Actor = Actor, Target = Target }.Run();
                                    return true;
                                };
                                NinecReaper niecr = NinecReaper.AddToInteranctionQueue(HitTarget, HitTarget, cuRun);
                                niecr.CustomRunName = "ForceLoopIdleNoSimUpdate";
                            }
                        }
                    }
                    else if (temp == "looptargetdied4")
                    {
                        looptargetdied4_command();
                    }
                    else if (temp == "testexi")
                    {
                        Sim HitTarget = HitTargetSim();
                        if (HitTarget != null)
                        {
                            NinecReaper custi = HitTarget.CurrentInteraction as NinecReaper;
                            if (custi != null && custi.CustomRunName == "ForceLoopIdle")
                            {
                                Simulator.Wake(HitTarget.ObjectId, false);
                            }
                            else
                            {
                                NinecReaper.CustomRun cuRun = delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                                {
                                    Actor.LoopIdle();
                                    Simulator.Sleep(uint.MaxValue);
                                    Actor.ClearExitReasons();
                                    if (!IsOpenDGSInstalled)
                                        return new Sims3.Gameplay.NiecNonOpenDGS.Interactions.Object_ActorsSim.NReadSomethingInInventory() { Actor = Actor, Target = Target }.Run();
                                    return true;
                                };
                                NinecReaper niecr = NinecReaper.AddToInteranctionQueue(HitTarget, HitTarget, cuRun);
                                niecr.CustomRunName = "ForceLoopIdle";
                            }
                        }
                    }
                    else if (temp == "setidpos")
                    {
                        ulong it;
                        ulong.TryParse(
                            StringInputDialog.Show(
                               "NiecMod",
                               "Object Guid",
                               "",
                               25,
                               StringInputDialog.Validation.None
                            ),
                            System.Globalization.NumberStyles.AllowHexSpecifier,
                            null,
                            out it
                        );
                        //ObjectGuid objectt = new ObjectGuid(i);
                        if (NFinalizeDeath.GameObjectIsValid(it))
                        {
                            string textpos = StringInputDialog.Show("NiecMod: Text Pos", "X: Y: Z:", ScriptCore.Objects.Objects_GetPosition(it).ToString(), 256, StringInputDialog.Validation.None);
                            if (string.IsNullOrEmpty(textpos))
                                return;

                            textpos = textpos.Trim();

                            textpos = textpos.Replace("(", "").Replace(")", "");

                            if (string.IsNullOrEmpty(textpos))
                                return;

                            float x, y, z;

                            string[] pos = textpos.Split(new string[] { ", ", "," }, StringSplitOptions.None);

                            if (pos.Length == 3)
                            {

                                float.TryParse(pos[0], out x);
                                float.TryParse(pos[1], out y);
                                float.TryParse(pos[2], out z);

                                ScriptCore.Objects.Objects_SetPosition(it, new Vector3(x, y, z));
                            }
                            else SimpleMessageDialog.Show("NiecMod", "Text Invalid");
                        }
                        else SimpleMessageDialog.Show("NiecMod", "Could not find\nObjectGuid ID: " + it);

                    }
                    else if (temp == "camst")
                    {
                        string et = ((CameraControllerType)ScriptCore.CameraController.Camera_GetControllerType()).ToString();
                        string textpos = StringInputDialog.Show("NiecMod: Text CameraControllerType", "Current: " + et, ScriptCore.CameraController.Camera_GetControllerType().ToString(), 256, StringInputDialog.Validation.None);
                        if (string.IsNullOrEmpty(textpos))
                            return;
                        uint t;
                        if (!uint.TryParse(textpos, out t)) return;
                        if (t > 8) return;
                        ScriptCore.CameraController.Camera_SetControllerType(t);
                    }
                    else if (temp == "guspeedf")
                    {
                        //if (ScriptCore.GameUtils.GameUtils_IsPausedImpl()) return;
                        string st = ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl().ToString();
                        string textpos = StringInputDialog.Show("NiecMod: Text", "GameUtils: Game Time Scale\nCurrent: " + st, st, 256, StringInputDialog.Validation.None);
                        if (string.IsNullOrEmpty(textpos))
                            return;
                        float t;
                        if (!float.TryParse(textpos, out t)) return;
                        ScriptCore.GameUtils.GameUtils_SetGameTimeScaleImpl(t);
                    }
                    else if (temp == "guptime")
                    {

                        if (ScriptCore.GameUtils.GameUtils_IsPausedImpl())
                        {
                            ScriptCore.GameUtils.GameUtils_UnpauseImpl();
                        }
                        else
                        {
                            ScriptCore.GameUtils.GameUtils_PauseImpl();
                        }

                    }
                    else if (temp == "guspeedl")
                    {
                        //if (ScriptCore.GameUtils.GameUtils_IsPausedImpl()) return;
                        string st = ScriptCore.GameUtils.GameUtils_GetGameTimeSpeedLevel().ToString();
                        string textpos = StringInputDialog.Show("NiecMod: Text", "GameUtils: Game Time Level\nCurrent: " + st, st, 256, StringInputDialog.Validation.None);
                        if (string.IsNullOrEmpty(textpos))
                            return;
                        int t;
                        if (!int.TryParse(textpos, out t)) return;
                        ScriptCore.GameUtils.GameUtils_SetGameTimeSpeedLevel(t);
                    }
                    else if (temp == "scpt")
                    {
                        string textpos = StringInputDialog.Show("NiecMod: Text Vector3", "P(X: Y: Z:)//T(X: Y: Z:)", ScriptCore.CameraController.Camera_GetPosition().ToString() + "//" + ScriptCore.CameraController.Camera_GetTarget().ToString(), 256, StringInputDialog.Validation.None);
                        if (string.IsNullOrEmpty(textpos))
                            return;
                        string[] pt = textpos.Split(new string[] { "//" }, StringSplitOptions.None);
                        if (pt.Length != 2) return;
                        Vector3[] art = new Vector3[2];
                        for (int i = 0; i < pt.Length; i++)
                        {
                            string bpos = pt[i].Trim();

                            bpos = bpos.Replace("(", "").Replace(")", "");

                            if (string.IsNullOrEmpty(bpos))
                                return;

                            float x, y, z;

                            string[] pos = bpos.Split(new string[] { ", ", "," }, StringSplitOptions.None);

                            if (pos.Length == 3)
                            {
                                float.TryParse(pos[0], out x);
                                float.TryParse(pos[1], out y);
                                float.TryParse(pos[2], out z);
                                if (float.IsNaN(x) || float.IsNaN(y) || float.IsNaN(z))
                                {
                                    SimpleMessageDialog.Show("NiecMod", "Text NAN Is not allowed!");
                                    return;
                                }
                                art[i] = new Vector3(x, y, z);
                            }
                            else
                            {
                                SimpleMessageDialog.Show("NiecMod", "Text Invalid");
                                return;
                            }
                        }
                        Vector3 p1 = art[0];
                        Vector3 p2 = art[1];
                        if (!(NFinalizeDeath.Vector3_Is_NAN_Or_Zero(p1) || NFinalizeDeath.Vector3_Is_NAN_Or_Zero(p2)))
                            ScriptCore.CameraController.Camera_SetPositionAndTarget(p1, p2);
                        else
                        {
                            SimpleMessageDialog.Show("NiecMod", "Text is Illegal");
                            return;
                        }
                    }
                    else if (temp == "stoaa")
                    {
                        if (!Simulator.CheckYieldingContext(false)) return;
                        Sim ActiveActor = PlumbBob.SelectedActor;
                        if (ActiveActor == null)
                            return;
                        GameObject TargetGameObject = HitTargetGameObject();
                        if (TargetGameObject != null && TargetGameObject != ActiveActor)
                        {
                            ulong i;
                            ulong.TryParse(
                                StringInputDialog.Show(
                                   "NiecMod", "Slot Name Hash", "1318179674", 10, StringInputDialog.Validation.None
                                ),
                                out i
                            );
                            if (i > uint.MaxValue || i < uint.MinValue)
                            {
                                return;
                            }
                            bool OccupySlot = NFinalizeDeath.CheckAccept("Occupy Slot"); //NFinalizeDeath.CheckAccept("Occupy Slot");
                            var tr = Slots.CanAttachToSlot(TargetGameObject.ObjectId, ActiveActor.ObjectId, (uint)i, OccupySlot);
                            if (!Slots.IsSuccess(tr))
                            {
                                SimpleMessageDialog.Show("NiecMod", "Could not attach\nResult: " + tr + "\nSlotHash: " + i);
                            }
                            else Slots.AttachToSlot(TargetGameObject.ObjectId, ActiveActor.ObjectId, (uint)i, OccupySlot);
                        }
                    }
                    else if (temp == "testagssd")
                    {
                        testagssd_command();
                    }
                    else if (temp == "loadlib")
                    {
                        loadlib_command();
                    }
                    else if (temp == "unruncnpro")
                    {
                        unruncnpro_command();
                    }
                    else if (temp == "tmynfunc")
                    {
                        tmynfunc_command();
                    }
                    else if (temp == "testex")
                    {
                        bool bPauseNiecS3Mod = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Test Like NiecS3Mod");

                        bool bForceCancel = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Force Cancel");

                        bool bTestOpenDGS = !IsOpenDGSInstalled || Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Test OpenDGS");

                        Sim Targetv = HitTargetSim();
                        if (Targetv != null)
                        {

                            NinecReaper.CustomRun cuRun = delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                            {
                                if (bPauseNiecS3Mod)
                                {
                                    (CurrentInteraction as NinecReaper).dataBoolens[0] = false; // fix i dont know 
                                    Actor.LoopIdle();
                                    Simulator.Sleep(0);
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Actor.InteractionQueue.mInteractionList.Add(CurrentInteraction);
                                    }
                                    Actor.InteractionQueue.CancelAllInteractions();
                                    for (int i = 0; i < 11; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }
                                    for (int i = 0; i < 7; i++)
                                    {
                                        Actor.InteractionQueue.mInteractionList.Add(CurrentInteraction);
                                    }
                                    Actor.InteractionQueue.CancelAllInteractions();
                                    return NFinalizeDeath._RunInteractionWithoutCleanUp(CurrentInteraction);
                                }
                                if (bTestOpenDGS)// || !IsOpenDGSInstalled)
                                {
                                    Simulator.Sleep(0);

                                    if (bForceCancel)
                                    {
                                        NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                                        Actor.mInteractionQueue = new InteractionQueue(Actor);
                                    }
                                    //CurrentInteraction.CallCallbackOnCompletion(Actor);
                                    Actor.Simulate();
                                }
                                Simulator.Sleep(0);
                                NFinalizeDeath._RunInteractionWithoutCleanUp(CurrentInteraction);
                                NFinalizeDeath.StateMachineClient_SetActor(null, null, null);
                                return true;
                            };

                            NFinalizeDeath.FastProCancel(Targetv);

                            NinecReaper niecr = NinecReaper.AddToInteranctionQueue(Targetv, Targetv, cuRun);

                            if (bPauseNiecS3Mod && niecr != null)
                            {
                                niecr.customCleanUp = delegate(InteractionInstance CurrentInteraction)
                                {

                                    NinecReaper ci = CurrentInteraction as NinecReaper;
                                    if (ci != null)
                                    {
                                        if (ci.dataBoolens[0])
                                            return;
                                        ci.mCancelled = true;

                                        Sim Actor = ci.Actor;
                                        //Sim Target = ci.Target;

                                        try
                                        {
                                            if (Actor == null || Actor.InteractionQueue == null)
                                                return;

                                            int ilee = IsOpenDGSInstalled ? 16 : 27;

                                            for (int i = 0; i < ilee; i++)
                                            {
                                                Actor.InteractionQueue.mInteractionList.Add(CurrentInteraction);
                                            }

                                            Actor.InteractionQueue.CancelAllInteractions();
                                        }
                                        catch (StackOverflowException)
                                        {
                                            if (IsOpenDGSInstalled)
                                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                                            ci.dataBoolens[0] = true;
                                            throw;
                                        }
                                    }
                                };
                            }
                        }
                    }
                    else if (temp == "testagssdall")
                    {
                        testagssdall_command();
                    }
                    else if (temp == "nhsfsactor")
                    {
                        nhsfsactor_command();
                    }
                    else if (temp == "unsafenullbimdesc")
                    {
                        unsafenullbimdesc_command();
                    }
                    else if (temp == "tnhsfsactor")
                    {
                        tnhsfsactor_command();
                    }
                    else if (temp == "rallirunlist") { rallirunlist_command(); }
                    else if (temp == "rallbuff") { rallbuff_command(); }
                    else if (temp == "testext")
                    {
                        Sim Targetv = HitTargetSim();
                        if (Targetv != null)
                        {
                            NinecReaper.CustomRun cuRun = delegate(Sim Actor, Sim Target, InteractionInstance CurrentInteraction)
                            {
                                Simulator.Sleep(0);
                                NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Actor);
                                Actor.mInteractionQueue = new InteractionQueue(Actor);

                                while (true)
                                {
                                    try
                                    {


                                        if (IsOpenDGSInstalled)
                                            Actor.Simulate();
                                        else
                                        {
                                            ScriptCore.ScriptProxy proxy = NFinalizeDeath.GetProxyWithoutSimIFace(Actor);
                                            if (proxy != null)
                                                proxy.Simulate();
                                            else
                                                Actor.Simulate();
                                        }
                                        if (!Simulator.CheckYieldingContext(false)) throw new ResetException();
                                        break;
                                    }
                                    catch (ResetException)
                                    {
                                        throw;
                                        //if (IsOpenDGSInstalled)
                                        //    throw;
                                        //else 
                                        //    throw new Exception("",e);
                                    }
                                    catch (Exception e)
                                    {
                                        //NFinalizeDeath._RunInteractionWithoutCleanUp(CurrentInteraction);
                                        //Actor.mInteractionQueue = new InteractionQueue(Actor);
                                        NFinalizeDeath.ForceNHSReapSoul(Target, Actor);
                                        ScriptCore.ScriptProxy proxy = NFinalizeDeath.GetProxyWithoutSimIFace(Actor);
                                        if (proxy != null && !IsOpenDGSInstalled)
                                            proxy.Simulate();
                                        else if (proxy != null)
                                            proxy.OnScriptError(e);
                                    }
                                    if (!Simulator.CheckYieldingContext(false)) throw new ResetException();
                                    Simulator.Sleep(0);
                                }
                                return true;
                            };

                            NFinalizeDeath.FastProCancel(Targetv);

                            NinecReaper.AddToInteranctionQueue(Targetv, Targetv, cuRun);
                        }
                    }
                    else if (temp == "killsim")
                    {
                        Sim Target = HitTargetSim();
                        if (Target != null)
                        {
                            ForceRequestGrimReaper sddf = ForceRequestGrimReaper.Singleton.CreateInstance(Target, Target, new InteractionPriority(InteractionPriorityLevel.UserDirected, 10), true, true) as ForceRequestGrimReaper;
                            sddf.NoAutoCreateNiecHelperSituation = true;
                            sddf.Run();

                            if (GrimReaper.Instance.mPool.Count == 0)
                            {
                                Sim ActiveActor = NFinalizeDeath.ActiveActor;
                                foreach (var ActorFor in NFinalizeDeath.SC_GetObjects<Sim>())
                                {
                                    if (ActorFor == ActiveActor) continue;
                                    if (!ActorFor.IsSelectable)
                                    {
                                        continue;
                                    }
                                    //Actor.Autonomy.SituationComponent.Situations.Add(NiecHelperSituation.Create(Actor.LotCurrent, Actor));
                                    SpeedTrap.Sleep(0);

                                    NiecHelperSituation situationOfTypex = ActorFor.GetSituationOfType<NiecHelperSituation>();
                                    if (situationOfTypex != null)
                                    {
                                        if (Target != ActorFor)
                                        {
                                            ActorFor.InteractionQueue.Add(
                                                NiecHelperSituation.NiecAppear.Singleton.CreateInstance(Target, ActorFor,
                                                new InteractionPriority((InteractionPriorityLevel)100, 999f),
                                            isAutonomous: false,
                                            cancellableByPlayer: true));
                                        }
                                    }
                                    else
                                    {
                                        var nhs = NiecHelperSituation.Create(ActorFor.LotCurrent, ActorFor);
                                        if (nhs != null)
                                            ActorFor.Autonomy.SituationComponent.Situations.Add(nhs);
                                        else continue;
                                        situationOfTypex = ActorFor.GetSituationOfType<NiecHelperSituation>();
                                        if (Target != ActorFor)
                                        {
                                            ActorFor.InteractionQueue.Add(
                                                (!situationOfTypex.OkSuusse ?
                                                    Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                                .CreateInstance(Target, ActorFor, new InteractionPriority((InteractionPriorityLevel)100, 999f),
                                            isAutonomous: false,
                                            cancellableByPlayer: true));
                                        }
                                    }
                                    break;
                                }

                            }
                            else if (!IsOpenDGSInstalled)
                            {
                                foreach (var Actor__ in NFinalizeDeath.SC_GetObjects<Sim>())
                                {
                                    NiecHelperSituation situationOfType = Actor__.GetSituationOfType<NiecHelperSituation>();
                                    if (situationOfType != null && Actor__.mInteractionQueue != null && Actor__.mInteractionQueue.mInteractionList != null)
                                    {
                                        Actor__.mInteractionQueue.Add(
                                            (!situationOfType.OkSuusse ?
                                                Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton
                                            : NiecHelperSituation.ReapSoul.Singleton)

                                            .CreateInstance(Target, Actor__, new InteractionPriority

                                            ((InteractionPriorityLevel)100, 999f),
                                            isAutonomous: false,
                                            cancellableByPlayer: true));
                                    }
                                }
                            }
                        }
                    }
                    else if (temp == "rcreatehousehold")
                    {
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null && TargetLot.Household == null)
                        {
                            Household household; //= null;
                            bool aot = Instantiator.OpenDGS_GetNoCreate();
                            try
                            {
                                Instantiator.OpenDGS_SetNoCreate(false);

                                if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Custom"))
                                {
                                    Create.CreateRandomHousehold(TargetLot, RandomUtil.CoinFlip(), out household);

                                    if (household != null)
                                    {
                                        if (household.LotHome == null)
                                            TargetLot.MoveIn(household);
                                        foreach (SimDescription siteem in household.AllSimDescriptions)
                                        {
                                            try
                                            {
                                                //if ((siteem.Service ?? siteem.CreatedByService) is GrimReaper) && 
                                                //    (siteem.Service ?? siteem.CreatedByService).IsSimDescriptionInPool(siteem) 
                                                if (((siteem.Service ?? siteem.CreatedByService) is GrimReaper) && (siteem.Service ?? siteem.CreatedByService).IsSimDescriptionInPool(siteem))
                                                    siteem.Instantiate(Create.GetPositionInRandomLot(TargetLot));
                                            }
                                            catch (Exception)
                                            { }
                                        }

                                        Create.ForceSendHomeAllActors(household);

                                    }
                                }
                                else
                                {
                                    SimUtils.HouseholdCreationSpec householdCreationSpec = SimUtils.HouseholdCreationSpec.MakeTypicalFamily();
                                    household = householdCreationSpec.Instantiate();
                                    if (household != null)
                                    {
                                        TargetLot.MoveIn(household);

                                        foreach (SimDescription siteem in household.AllSimDescriptions)
                                        {
                                            try
                                            {
                                                siteem.Instantiate(Create.GetPositionInRandomLot(TargetLot));
                                            }
                                            catch (Exception)
                                            { }
                                        }

                                        Create.ForceSendHomeAllActors(household);
                                    }
                                }
                            }
                            finally
                            {
                                Instantiator.OpenDGS_SetNoCreate(aot);
                            }
                        }
                    }
                    else if (temp == "rnewass")
                    {
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null)
                        {
                            Sim TargetSim = HitTargetSim();
                            if (TargetSim != null)
                            {
                                CopMod.ArrestSuspectSituation.Create(TargetLot, TargetSim, true);
                            }
                        }
                    }
                    else if (temp == "targetnhs")
                    {
                        Sim Target = HitTargetSim();
                        if (Target != null)
                        {
                            NiecHelperSituation niecHelperSituation = Target.GetSituationOfType<NiecHelperSituation>();
                            if (niecHelperSituation != null)
                            {
                                Target.InteractionQueue.Add(
                                    (!niecHelperSituation.OkSuusse ?
                                        Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                        .CreateInstance(Target, Target, new InteractionPriority(
                                            IsOpenDGSInstalled ?
                                            (InteractionPriorityLevel)100 :
                                            (InteractionPriorityLevel)12, 999f),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                ));
                            }
                            else
                            {
                                var nhs = NiecHelperSituation.Create(Target.LotCurrent, Target);
                                if (nhs != null)
                                    Target.Autonomy.SituationComponent.Situations.Add(nhs);
                                else return;
                                niecHelperSituation = Target.GetSituationOfType<NiecHelperSituation>();

                                Target.InteractionQueue.Add(
                                    (!niecHelperSituation.OkSuusse ?
                                        Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                        .CreateInstance(Target, Target, new InteractionPriority(
                                            IsOpenDGSInstalled ?
                                            (InteractionPriorityLevel)100 :
                                            (InteractionPriorityLevel)12, 999f
                                        ),

                                    isAutonomous: false,
                                    cancellableByPlayer: true
                                ));

                                if (Simulator.CheckYieldingContext(false) && !NFinalizeDeath.CheckAccept("Add InteractionQueue?"))
                                {
                                    NFinalizeDeath.ForceCancelAllInteractionsWithoutCleanup(Target);
                                }
                            }
                        }
                    }
                    else if (temp == "aallnewniechs")
                    {
                        NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
                        NiecHelperSituation.Spawn._bUnSafeRunAll = true;

                        if (autoAllnewniechs == ObjectGuid.InvalidObjectGuid)
                        {
                            AutoAllNewNiecSW(false, false, false);
                        }
                        else
                        {
                            AutoAllNewNiecSWLoad = false;
                            Simulator.DestroyObject(autoAllnewniechs);
                            autoAllnewniechs = ObjectGuid.InvalidObjectGuid;
                        }
                    }
                    else if (temp == "looplightcp")
                    {
                        looplightcp_command();
                    }
                    else if (temp == "allnewniechs")
                    {
                        //if (autoAllnewniechs != ObjectGuid.InvalidObjectGuid) return;

                        NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
                        NiecHelperSituation.Spawn._bUnSafeRunAll = true;

                        Sim ActiveActorOpenDGS = NFinalizeDeath.ActiveActor;
                        Sim ActiveActorNonOpenDGS = PlumbBob.SelectedActor;

                        bool AddIfIsPet = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Add if IsPet?");

                        foreach (var ActorFor in NFinalizeDeath.SC_GetObjects<Sim>())
                        {
                            if (ActorFor == ActiveActorOpenDGS || ActorFor == ActiveActorNonOpenDGS)
                                continue;

                            SimDescription simd = ActorFor.SimDescription;

                            if (simd == null)
                                continue;
                            if (AddIfIsPet && simd.IsPet)
                                continue;

                            if (ActorFor.IsSelectable)
                                continue;

                            InteractionQueue iInteractionQueue = ActorFor.InteractionQueue;
                            if (iInteractionQueue == null)
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

                            if (IsOpenDGSInstalled && ((simd.Service as GrimReaper ?? simd.CreatedByService as GrimReaper) != null))
                                continue;

                            NiecHelperSituation niecHelperSituation = NFinalizeDeath.SafeGetSituationOfType<NiecHelperSituation>(ActorFor);
                            if (niecHelperSituation != null)
                            {
                                Sim Target = HitTargetSim() ?? PlumbBob.SelectedActor ?? ActorFor;

                                iInteractionQueue.Add(
                                         (!niecHelperSituation.OkSuusse ?
                                             Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                             .CreateInstance(Target, ActorFor, new InteractionPriority(
                                                 IsOpenDGSInstalled ?
                                                 (InteractionPriorityLevel)100 :
                                                 (InteractionPriorityLevel)12, 999f
                                             ),

                                         isAutonomous: false,
                                         cancellableByPlayer: true
                                ));
                            }
                            else
                            {
                                var nhs = NiecHelperSituation.Create(ActorFor.LotCurrent, ActorFor);
                                if (nhs != null)
                                {
                                    niecHelperSituation = nhs;
                                    listSituations.Add(nhs);
                                }
                                else continue;
                                //niecHelperSituation = ActorFor.GetSituationOfType<NiecHelperSituation>();

                                Sim Target = HitTargetSim() ?? PlumbBob.SelectedActor ?? ActorFor;

                                //if (Target != ActorFor)
                                {
                                    iInteractionQueue.Add(
                                        (!niecHelperSituation.OkSuusse ?
                                            Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                            .CreateInstance(Target, ActorFor, new InteractionPriority(
                                                IsOpenDGSInstalled ?
                                                (InteractionPriorityLevel)100 :
                                                (InteractionPriorityLevel)12, 999f
                                        ),

                                        isAutonomous: false,
                                        cancellableByPlayer: true
                                    ));
                                }
                            }
                        }
                    }
                    else if (temp == "rnewniechs")
                    {
                        Create.CreateRandomNiecHelperSituation(null, false, false, true);

                    }
                    else if (temp == "unsafeallrunnhs")
                    {
                        SimpleMessageDialog.Show("NiecMod", "NiecHelperSituation\nWorkingCount: " + NiecHelperSituation.WorkingNiecHelperSituationCount + "\nAHWorkingCount: " + NiecHelperSituation.Spawn.ActiveHouseholdWorkingNHS_Count() + "\nSimsCount: " + NFinalizeDeath.SC_GetObjects<Sim>().Length);
                        if (Simulator.CheckYieldingContext(false))
                        {

                            bool value = TwoButtonDialog.Show(
                                "ReapSoulIsSelectable: " + NiecHelperSituation.bUnsafeRunReapSoulIsSelectable +
                                 "\nUnSafeRunAll: " + NiecHelperSituation.Spawn._bUnSafeRunAll,
                                "Set True",
                                "Set False"
                            );

                            NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = value;
                            NiecHelperSituation.Spawn._bUnSafeRunAll = value;
                        }
                        else
                        {
                            NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = !NiecHelperSituation.bUnsafeRunReapSoulIsSelectable;
                            NiecHelperSituation.Spawn._bUnSafeRunAll = !NiecHelperSituation.Spawn._bUnSafeRunAll;
                        }
                    }
                    else if (temp == "testdttod")
                    {
                        testdttod_command();
                    }
                    else if (temp == "dtargetobj")
                    {
                        GameObject obj = HitTargetGameObject();
                        if (obj != null)
                        {
                            if (obj == NFinalizeDeath.ActiveActor || obj == PlumbBob.sSingleton)
                                SimpleMessageDialog.Show("NiecMod", "Destroy Active Actor is not allowed.");
                            else
                            {
                                NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(obj, false);
                                NFinalizeDeath.ForceDeAttachAndDestroyAllSlots(obj, true);
                                NFinalizeDeath.ForceDestroyObject(obj);
                            }
                        }
                        else
                        {
                            var objectID = HitTargetObjectDontHaveScript();
                            if (objectID != 0)
                            {
                                var gameObjectID = NFinalizeDeath.GetObject_internalFast(objectID);
                                if (gameObjectID != null && (gameObjectID == NFinalizeDeath.ActiveActor || gameObjectID == PlumbBob.sSingleton))
                                {
                                    SimpleMessageDialog.Show("NiecMod", "Destroy Active Actor is not allowed.");
                                }
                                else if (NFinalizeDeath.CheckAccept("Destroy Object?\n(ObjectID: " + objectID + ")"))
                                {
                                    NFinalizeDeath.ForceDeAttachAndDestroyAllSlotsWithObjectID(objectID, false);
                                    Simulator.DestroyObject(new ObjectGuid(objectID));
                                }
                            }
                        }
                    }
                    else if (temp == "tmnfunc2")
                    {
                        tmnfunc2_command();
                    }
                    else if (temp == "finddeldesc")
                    {
                        SimDescription simd = Create.FindDescOrTargetSimDesc(0, 0, true);
                        Sim ActiveActor = NFinalizeDeath.ActiveActor;

                        if (simd != null)
                        {

                            if (ActiveActor != null && ActiveActor.SimDescription == simd)
                            {
                                SimpleMessageDialog.Show("NiecMod", "Active Actor is not allowed.");
                            }
                            else
                            {
                                Create.NiecNullSimDescription(true);

                                ulong uid = simd.SimDescriptionId;
                                Sim CreatedSim = simd.CreatedSim;

                                if (CreatedSim != null)
                                {
                                    NFinalizeDeath.ForceDestroyObject(CreatedSim);
                                    CreatedSim.mSimDescription = ListCollon.NullSimSimDescription;
                                    simd.mSim = null;
                                }

                                for (int i = 0; i < 5; i++)
                                    NFinalizeDeath.SimDescCleanse(simd, true, false);

                                SimpleMessageDialog.Show("NiecMod", "SimDescription Destroyed.\nID: " + uid);
                            }
                        }
                        else
                            SimpleMessageDialog.Show("NiecMod", "Could not find the SimDesc.");
                    }
                    else if (temp == "findinvdesc")
                    {
                        bool t = false;
                        if (!AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap"))
                        {
                            if (!NFinalizeDeath.CheckAccept("You don't have 'NRaasErrorTrap Mod'\nPlease install mod\nRun?"))
                            {
                                return;
                            }
                            else t = true;
                        }
                        SimDescription simd = Create.FindDescOrTargetSimDesc(0, 0, true);
                        if (simd != null)
                        {

                            var createdsim = simd.CreatedSim;
                            if (createdsim != null)
                            {
                                if (createdsim.SimDescription == simd)
                                {
                                    if (!NFinalizeDeath.GameObjectIsValid(createdsim.ObjectId.mValue))
                                    {
                                        simd.mSim = null;
                                    }
                                    else
                                    {
                                        createdsim.SetPosition(NFinalizeDeath.Fast_SnapToFloor(ScriptCore.CameraController.Camera_GetTarget()));
                                        createdsim.FadeIn();
                                        return;
                                    }
                                }
                                else
                                {
                                    simd.mSim = null;
                                    if (NFinalizeDeath.GameObjectIsValid(createdsim.ObjectId.mValue))
                                    {
                                        SimDescription osimd;
                                        if (ListCollon.NiecSimDescriptions != null &&
                                            NFinalizeDeath.IsSimDescAndCreateSimValid(ListCollon.NiecSimDescriptions.ToArray(), createdsim, out osimd))
                                        {
                                            osimd.mSim = createdsim;
                                            createdsim.SetPosition(NFinalizeDeath.Fast_SnapToFloor(ScriptCore.CameraController.Camera_GetTarget()));
                                            createdsim.FadeIn();
                                            return;
                                        }
                                        NFinalizeDeath.ForceDestroyObject(createdsim);
                                    }

                                }
                            }
                            if (t)
                            {
                                try
                                {
                                    simd.Fixup();
                                }
                                catch (Exception ex)
                                {
                                    SimpleMessageDialog.Show("NiecMod", "Can't Fix Sim Desc!!\nExMessage: " + ex.Message + "\nCan't Create Sim");
                                    return;
                                }
                                if (!simd.IsValidDescription)
                                {
                                    SimpleMessageDialog.Show("NiecMod", "Can't Fix Sim Desc!!\nCan't Create Sim");
                                    return;
                                }
                            }
                            if (!NFinalizeDeath.SimDesc_OutfitsIsValid(simd))
                            {
                                SimpleMessageDialog.Show("NiecMod", "SimDesc don't have Outfits!!\nCan't Create Sim");
                                return;
                            }
                            if (simd.Household == null)
                            {
                                if (t || NFinalizeDeath.CheckAccept(simd.FirstName + " " + simd.LastName + " don't have Household\nFix?"))
                                {
                                    if (!NFinalizeDeath.Household_Add(NFinalizeDeath.GetRandomGameObject<Household>(NFinalizeDeath.Household_IsSafeHouseholdFromLoadingSaveFile), simd, false) || simd.Household == null)
                                    {
                                        if (t || !NiecHelperSituation.__acorewIsnstalled__)
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                            var sim = NFinalizeDeath.SimDesc_SafeInstantiate(simd, NFinalizeDeath.Fast_SnapToFloor(ScriptCore.CameraController.Camera_GetTarget()));
                            if (sim != null && NFinalizeDeath.ActorIsValidExNull(sim) && NFinalizeDeath.ActiveActor == null && GameStates.IsLiveState && NFinalizeDeath.CheckAccept("forcesetaa2?"))
                            {
                                NFinalizeDeath.TestSetActiveActor(sim, true);
                            }
                            if (sim == null)
                            {
                                SimpleMessageDialog.Show("NiecMod", "Failed to Create Sim!\nPlease Fix Sim Desc");
                            }
                        }
                        else if (Create.GetErrorFindDescOrTargetSimDesc() != 2)
                            SimpleMessageDialog.Show("NiecMod", "Could not find the SimDesc.");
                    }
                    else if (temp == "tmnfunc4")
                    {
                        tmnfunc4_Command();
                    }
                    else if (temp == "cancelkillsim")
                    {
                        Sim Target = HitTargetSim();
                        if (Target != null)
                        {
                            SimDescription simd = Target.SimDescription;
                            if (simd != null)// && simd != Sims3.NiecModList.Persistable.ListCollon.NullSimSimDescription)
                            {
                                simd.mDeathStyle = SimDescription.DeathType.None;
                                simd.IsGhost = false;
                            }
                        }
                    }
                    else if (temp == "removeallhouseholdlist")
                    {
                        OnHouseholdList = !OnHouseholdList;

                        if (OnHouseholdList)
                        {
                            try
                            {
                                foreach (var item in Household.sHouseholdList)
                                {
                                    if (item == null || listHouseholdbackup.Contains(item))
                                        continue;

                                    listHouseholdbackup.Add(item);

                                    if (item.HasBeenDestroyed)
                                    {
                                        item.mbInited = false;
                                        item.mHouseholdId = (ulong)
                                            ListCollon.SafeRandomPart2.Next(100000);

                                        Simulator.AddObject(item);
                                    }
                                }
                            }
                            catch
                            { }

                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null || listHouseholdbackup.Contains(item))
                                    continue;
                                listHouseholdbackup.Add(item);
                            }
                            Household.sHouseholdList.Clear();
                        }
                        else
                        {

                            if (listHouseholdbackup == null)
                                listHouseholdbackup = new List<Household>();

                            if (Household.sHouseholdList == null)
                                Household.sHouseholdList = new List<Household>(listHouseholdbackup);

                            foreach (var itfdgem in listHouseholdbackup)
                            {
                                if (itfdgem == null || Household.sHouseholdList.Contains(itfdgem))
                                    continue;
                                Household.sHouseholdList.Add(itfdgem);
                            }
                            listHouseholdbackup.Clear();

                        }
                    }
                    else if (temp == "fixoccults")
                    {

                        bool ifActiveHousehold = Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Add If ActiveHousehold");
                        Household ActiveHousehold = !ifActiveHousehold ? null : Household.ActiveHousehold;
                        foreach (var item in ListCollon.NiecSimDescriptions)
                        {
                            if (item == null)
                                continue;

                            if (ifActiveHousehold && item.Household != null && item.Household == ActiveHousehold)
                                continue;
                            try
                            {
                                if (item.mOutfits != null)
                                    item.mOutfits.Clear();
                            }
                            catch (NotSupportedException)
                            { }


                            item.mOutfits = new OutfitCategoryMap();
                            item.mDefaultOutfitKey = ResourceKey.kInvalidResourceKey;

                        }
                    }
                    else if (temp == "saatwo")
                    {
                        saatwo_command();
                    }
                    else if (temp == "fixonisplayer")
                    {
                        Household ActiveHousehold = Household.ActiveHousehold;
                        if (ActiveHousehold != null)
                        {
                            foreach (var item in ActiveHousehold.AllActors)
                            {
                                if (item == null) continue;
                                NFinalizeDeath.SimRemove_SituationList(item, null, true);
                                if (item.IsSelectable)
                                {
                                    item.OnBecameSelectable();
                                }
                            }
                        }
                    }
                    else if (temp == "grtwotone")
                    {
                        Dictionary<SimDescription, List<Urnstone>> grList;
                        if (NFinalizeDeath.GraveTwoToGraveOne(ListCollon.NiecSimDescriptions.ToArray(), null, false, out grList))
                        {
                            //NiecException.PrintMessagePro("DEBUG grtwotone", false, 10);
                            foreach (var urnlist_Value in grList.Values)
                            {
                                //Simulator.Sleep(0);
                                //if (grList.Count == 1) ;
                                if (urnlist_Value == null)
                                    continue;


                                if (urnlist_Value.Count == 1)
                                {
                                    urnlist_Value.Clear();
                                    continue;
                                }

                                //int urnListCount = urnlist_Value.Count;

                                foreach (var grave in urnlist_Value)
                                {
                                    //Simulator.Sleep(0);

                                    //urnListCount--;

                                    if (grave == null)
                                        continue;



                                    if (urnlist_Value.Count == 1)// || urnListCount < 0)
                                        break;

                                    grave.DeadSimsDescription = null;
                                    NFinalizeDeath.ForceDestroyObject(grave);
                                    //NiecException.PrintMessagePro("urnlist_Value Done", false, 10);
                                }
                                urnlist_Value.Clear();
                                //NiecException.PrintMessagePro("urnlist_Value Done X", false, 10);
                            }
                            grList.Clear();
                        }
                    }
                    else if (temp == "bioclear")
                    {
                        foreach (SimDescription item in ListCollon.NiecSimDescriptions)
                        {
                            if (item == null)
                                continue;
                            item.mBio = "";
                        }
                    }
                    else if (temp == "trimhouse")
                    {
                        trimhouse_command();

                    }
                    else if (temp == "dnf")
                    {
                        DumpNativeFunction();
                    }
                    else if (temp == "testhinlothome")
                    {
                        testhinlothome_command();
                    }
                    else if (temp == "chouselot")
                    {
                        chouselot_command();
                    }
                    else if (temp == "rlooppsim")
                    {
                        foreach (var item in loopp_listobjectguild.ToArray())
                        {
                            Simulator.DestroyObject(item);
                            loopp_listobjectguild.Remove(item);
                        }
                    }
                    else if (temp == "looppsim")
                    {
                        if (loopp_listobjectguild == null)
                            loopp_listobjectguild = new List<ObjectGuid>();

                        if (IsOpenDGSInstalled)
                        {
                            if (Simulator.CheckYieldingContext(false))
                            {
                                if (NFinalizeDeath.CheckAccept("All Sim?"))
                                {
                                    if (loopp_listobjectguild == null)
                                        loopp_listobjectguild = new List<ObjectGuid>();

                                    foreach (var item in loopp_listobjectguild.ToArray())
                                    {
                                        Simulator.DestroyObject(item);
                                        loopp_listobjectguild.Remove(item);
                                    }

                                    foreach (var item in NFinalizeDeath.SC_GetObjects<Sim>())
                                    {
                                        if (item == null)
                                            continue;

                                        ScolidSim(item);
                                    }
                                    return;

                                }
                                else if (NFinalizeDeath.CheckAccept("TargetLot All Sim?"))
                                {
                                    LotLocation LotLocation = default(LotLocation);
                                    ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                                    Lot TargetLot = LotManager.GetLot(Location);
                                    if (TargetLot != null && !TargetLot.IsWorldLot)
                                    {

                                        foreach (var item in TargetLot.GetAllActors())
                                        {
                                            if (item == null)
                                                continue;

                                            ScolidSim(item);
                                        }
                                    }
                                    return;
                                }
                            }
                            ScolidSim(HitTargetSim());
                        }
                        else
                        {
                            Household activeHousehold = Household.ActiveHousehold;
                            if (activeHousehold != null)
                            {
                                Sim activeActor = PlumbBob.SelectedActor;

                                Punishment activePunishment = Punishment.GetPunishmentManagerFromSim(activeActor);

                                if (activePunishment == null)
                                    return;

                                loopp_listobjectguild.Add(global::Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                                {
                                    try
                                    {
                                        while (true)
                                        {
                                            Simulator.Sleep(0);
                                            foreach (var actor in activeHousehold.Sims)
                                            {
                                                if (actor == null || activeActor == actor) continue;

                                                Simulator.Sleep(0);

                                                if (!NFinalizeDeath.CustomApplyDeviantBehaviorToSim(activePunishment, Punishment.DeviantBehaviorType.BadGrades, true, true, 30))
                                                    break;

                                                actor.Motives.MaxEverything();
                                            }

                                            if (!NFinalizeDeath.CustomApplyDeviantBehaviorToSim(activePunishment, Punishment.DeviantBehaviorType.BadGrades, true, true, 30))
                                                break;

                                            Simulator.Sleep(1500);
                                        }
                                    }
                                    finally
                                    {
                                        loopp_listobjectguild.Remove(Simulator.CurrentTask);
                                    }
                                }));
                            }
                        }
                    }
                    else if (temp == "setisstsleep")
                    {
                        setisstsleep_command();
                    }
                    else if (temp == "automantinpc")
                    {
                        if (autoAntiNPCAutoManger == NiecInvalidObjectGuid)
                        {
                            autoAntiNPCAutoManger = Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                            {
                                bool done = false;
                                AutonomyManager autoManager = AutonomyManager.sInstance; //NFinalizeDeath.GetProxyPro<AutonomyManager>();
                                if (autoManager == null)
                                { autoAntiNPCAutoManger = NiecInvalidObjectGuid; return; }
                                try
                                {

                                    //ITask autoManagerTask;
                                    //ObjectGuid auManagerGuid = NFinalizeDeath.FindTaskPro
                                    //    ("AutonomyManager.Simulate", "Sims3.Gameplay.Autonomy.AutonomyManager", out autoManagerTask);
                                    //if (auManagerGuid == NiecInvalidObjectGuid || autoManagerTask == null) { return; }
                                    Simulator.DestroyObject(autoManager.ObjectId);
                                    done = true;
                                    Simulator.Sleep(uint.MaxValue);
                                }
                                finally
                                {
                                    autoAntiNPCAutoManger = NiecInvalidObjectGuid;
                                    if (done && autoManager != null && autoManager.HasBeenDestroyed)
                                        Simulator.AddObject(autoManager);
                                }

                            });
                        }
                        else Simulator.DestroyObject(autoAntiNPCAutoManger);
                    }
                    else if (temp == "savelot")
                    {
                        if (GameStates.IsInMainMenuState) return;
                        LotLocation LotLocation = default(LotLocation);
                        ulong Location = World.GetLotLocation(CameraController.GetTarget(), ref LotLocation);
                        Lot TargetLot = LotManager.GetLot(Location);
                        if (TargetLot != null && !TargetLot.IsWorldLot)
                        {
                            string result = null;
                            ulong lotContentsID = DownloadContent.StoreLotContents(TargetLot, TargetLot.LotId);
                            if (lotContentsID != 0)
                            {
                                if (VideoRecorder.Instance != null)
                                {
                                    var name = TargetLot.Name;
                                    if (name != null && name.Length > 0)
                                    {
                                        VideoRecorder.SnapshotFileName = name + " Photo";
                                        VideoRecorder.TakeSnapshot();
                                    }
                                }
                                //if (!IsOpenDGSInstalled) { }
                                var o = NFinalizeDeath.is_d_scobjectscmd;
                                float fTime = -1f;
                                if (!IsOpenDGSInstalled && o)
                                {
                                    fTime = ScriptCore.GameUtils.GameUtils_GetGameTimeScaleImpl();
                                    if (fTime == 0f)
                                        fTime = -1f;
                                }
                                ThumbnailHelper.GenerateLotThumbnailSet(TargetLot.LotId, lotContentsID, ThumbnailSizeMask.ExtraLarge);
                                ThumbnailHelper.GenerateLotThumbnail(TargetLot.LotId, lotContentsID, 0x0, ThumbnailSizeMask.Medium | ThumbnailSizeMask.Large);
                                if (!IsOpenDGSInstalled && o)
                                {
                                    if (fTime != -1f)
                                        ScriptCore.GameUtils.GameUtils_SetGameTimeScaleImpl(0);
                                    CommandSystem.ExecuteCommandString("dgsmods scobj");
                                    for (int i = 0; i < 100; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }

                                }
                                NFinalizeDeath.Assert(IsOpenDGSInstalled || !NFinalizeDeath.is_d_scobjectscmd, "NFinalizeDeath.is_d_scobjectscmd failed 1.");
                                result = DownloadContent.ExportLotContentsToExportBin(lotContentsID);
                                ThumbnailManager.InvalidateLotThumbnails(TargetLot.LotId, lotContentsID, ThumbnailSizeMask.ExtraLarge);
                                ThumbnailManager.InvalidateLotThumbnailsForGroup(TargetLot.LotId, lotContentsID, ThumbnailSizeMask.Medium, 0x0);
                                NFinalizeDeath.Assert(IsOpenDGSInstalled || !NFinalizeDeath.is_d_scobjectscmd, "NFinalizeDeath.is_d_scobjectscmd failed 2.");
                                if (!IsOpenDGSInstalled && o)
                                {
                                    if (fTime != -1f)
                                        ScriptCore.GameUtils.GameUtils_SetGameTimeScaleImpl(fTime);
                                    CommandSystem.ExecuteCommandString("dgsmods scobj");
                                    for (int i = 0; i < 100; i++)
                                    {
                                        Simulator.Sleep(0);
                                    }
                                }
                                NFinalizeDeath.Assert(IsOpenDGSInstalled || NFinalizeDeath.is_d_scobjectscmd, "NFinalizeDeath.is_d_scobjectscmd ok failed 1.");
                            }
                            NiecException.PrintMessagePro(result, false, 100000F);
                        }
                    }
                    else if (temp == "testloadlib")
                    {
                        testloadlib_command();
                    }
                    else if (temp == "rcfunc") { rcfunc_command(); }
                    else if (temp == "ustsim")
                    {
                        var objSim = HitTargetSim();
                        if (objSim != null)
                        {
                            NFinalizeDeath.UnSafeForceErrorTargetSim(objSim);
                        }
                    }
                    else if (temp == "ustsimall")
                    {
                        ustsimall_Command();
                    }
                    else if (temp == "acinfo")
                    {
                        GameObject obj = HitTargetGameObject();
                        if (obj != null)
                        {
                            AnimationUtil.ActiveClips activeClips = AnimationUtil.GetActiveClips(obj.ObjectId);
                            //if (!object.ReferenceEquals(activeClips, null) && activeClips.Count > 0)
                            if (activeClips.Count > 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("Clip Info:\n" + "ObjectID: '" + obj.ObjectId.ToString() + "'\n\n");

                                for (uint i = 0; i < activeClips.Count; i++)
                                {
                                    ClipInfo ci = activeClips[i];
                                    if (ci == null) continue;
                                    sb.Append("Clip Name: " + ci.mName);
                                    sb.Append("\nPriority: " + ci.mPriority);
                                    sb.AppendLine();
                                }

                                NiecException.PrintMessagePro(sb.ToString(), false, 10);

                                uint b = 0;
                                string file = Simulator.CreateExportFile(ref b, "ClipInfo");

                                sb.Append("\nFile Name: " + file + "\nDate: " + DateTime.Now.ToString());
                                sb.Append('\0');

                                Simulator.AppendToScriptErrorFile(b, sb.ToString().ToCharArray());
                                Simulator.CloseScriptErrorFile(b);
                            }
                        }
                    }
                    else if (temp == "testye")
                    {
                        testye_command();
                    }
                    else if (temp == "rclock") { (Responder.Instance.HudModel as Sims3.Gameplay.UI.HudModel).OnMinuteChanged(); }
                    else if (temp == "unsaddmnil")
                    {
                        Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;
                        Create.ofunsaddmnil = !Create.ofunsaddmnil;
                        if (Create.ofunsaddmnil)
                        {
                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null || item == ActiveHousehold) continue;
                                Household.Members mem = item.mMembers;
                                if (mem != null)
                                {
                                    mem.mAllSimDescriptions.Add(null);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in NFinalizeDeath.SC_GetObjects<Household>())
                            {
                                if (item == null)
                                    continue;
                                Household.Members mem = item.mMembers;

                                int checkloop = 10000;

                                if (mem != null)
                                {
                                    //Create.GetHelperNraPro(IntPtr.Zero);
                                    while (mem.mAllSimDescriptions.Remove(null))
                                    {
                                        checkloop--;
                                        if (checkloop < 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                        GetCommandHelp();
                } 
                else
                    GetCommandHelp();
            });
            return 0;
        }
    }

    

    public static class Create
    {
        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.InternalCall)]
        //public static extern HelperNraPro GetHelperNraPro(IntPtr mhandle);

        public static int GetAllCostLot(Lot TargetLot)
        {
            int resultPrice = 0;
            if (TargetLot != null)
            {
                GameObject[] objects = NFinalizeDeath.SC_GetObjectsOnLot<GameObject>(TargetLot);
                foreach (GameObject gameObject in objects)
                {
                    if (!(gameObject is Sim) && !(gameObject is PlumbBob))
                    {
                        try
                        {
                            resultPrice += gameObject.Value;
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch
                        { }
                    }
                }
            }
            return resultPrice;
        }

        public static bool ImportLot_CanBePlacedOnLot(UIBinInfo lotToPlace, UIBinInfo targetLot)
        {
            if (lotToPlace == null || targetLot == null)
            {
                return false;
            }
            float num = Math.Max(lotToPlace.LotSizeX, lotToPlace.LotSizeY);
            float num2 = Math.Min(lotToPlace.LotSizeX, lotToPlace.LotSizeY);
            float num3 = Math.Max(targetLot.LotSizeX, targetLot.LotSizeY);
            float num4 = Math.Min(targetLot.LotSizeX, targetLot.LotSizeY);
            if (Math.Round((double)num) > Math.Round((double)num3))
            {
                return false;
            }
            if (Math.Round((double)num2) > Math.Round((double)num4))
            {
                return false;
            }
            //if (World.LotIsEmpty(lotItem.LotId) && lotItem.IsLotEmptyFromObjects()) return false;
            return true;
        }


        public static 
            bool ImportLot_PlaceLotContents
            (Lot targetLot, ulong contentId, ref LotRotationAngle angle, ref LotPosition position, bool bShowProgressDialog, bool forceBulldozeSpawners)
        {
            bool result;// = BinCommon.PlaceLotContents(targetLot, contentId, ref angle, ref position, bShowProgressDialog, forceBulldozeSpawners);

            try
            {
                Sim ActiveActor = NFinalizeDeath.ActiveActor;
                if (ActiveActor != null && ActiveActor.LotCurrent == targetLot)
                {
                    ActiveActor.SetPosition(Create.GetPositionInRandomLot(LotManager.GetWorldLot()));
                    try
                    {
                        if (ActiveActor.SimRoutingComponent != null)
                            ActiveActor.SimRoutingComponent.ForceUpdateDynamicFootprint();
                        ActiveActor.ModifyFunds(+Create.GetAllCostLot(targetLot));
                    }
                    catch
                    { }

                }
            }
            catch (Exception)
            { return false; }
            try
            {
                if (!bShowProgressDialog)
                    NFinalizeDeath.DestroyAllObjectsOnLot(targetLot);
                targetLot.Bulldoze(false, false, forceBulldozeSpawners, false);
            }
            catch
            {}
            result = DownloadContent.ImportLotContents(contentId, targetLot, targetLot.LotId, ref angle, ref position);
            if (result)
            {
                ThumbnailManager.UpdateDirtyLotThumbnails();
                SeasonalLotMarker[] objects = NFinalizeDeath.SC_GetObjectsOnLot<SeasonalLotMarker>(targetLot);
                if (objects.Length > 0)
                {
                    objects[0].InitialUpdate();
                }
                targetLot.SetDisplayLevel(targetLot.RoofLevel + 1);
            }
            return result;
        }

        public static ulong ImportLot_ContentImportLotInfo(UIBinInfo ImportInfo)
        {
            ExportBinContents exportBinContents = BinModel.Singleton.FindExportBinItem(ImportInfo.ContentId);
            if (exportBinContents != null)
            {
                bool asdot = exportBinContents.IsLoaded();
                if (!asdot)
                {
                    exportBinContents.Import(true);
                }
                return exportBinContents.ContentId;
               
            }
            else
            {
                LotContents lotContents = Bin.Singleton.FindLot(ImportInfo.ContentId);
                if (lotContents != null)
                {
                    return lotContents.ContentId;
                }
            }
            return 0;
        }

        public static bool ImportLot_PackageFileInfoIsPackageFile(string packageFileInfo, string packageFile)
        {
            if (packageFileInfo == null) return false;
            try
            {
                string[] separator = new string[1]
			{
				"\u0019"
			};
                string[] separator2 = new string[1]
			{
				"\u001d"
			};
                string[] array = packageFileInfo.Split(separator, StringSplitOptions.None);
                if (array != null && array.Length > 0)
                {
                    if (array[0].Split(separator2, StringSplitOptions.None)[0] == packageFile)
                        return true;
                }
            }
            catch (Exception)
            { }
            
            return false;
        }

        public static ExportBinContents InternalExportBinContents_ImportLot(BinModel bin, string packageFile)
        {
            if (packageFile == null) return null;
            ExportBin.RefreshExportBin();
            //string packageInfo = ExportBin.GetPackageInfo(packageFile);
            ExportBinContents package = BinCommon.GetPackage(ExportBin.GetPackageInfo(packageFile) ?? "");
            if (package != null)
            {
                if (bin != null && bin.mExportBin!= null && !bin.mExportBin.Contains(package))
                    bin.mExportBin.Add(package);
                return package;
            }
            //if (bin != null) {
            //    ulong cID = bin.AddToExportBin(packageFile);
            //    if (cID != ulong.MaxValue) {
            //        return bin.FindExportBinItem(cID);
            //    }
            //}
            return null;
        }

        public static ExportBinContents ImportLot_ExportBinContents(BinModel bin, string packageFile, bool strContains)
        {
            if (bin == null || bin.mExportBin == null) return null;
            if (string.IsNullOrEmpty(packageFile)) return null;

            if (!NiecRunCommand.IsOpenDGSInstalled && !bin.IsClear()) {
                ExportBin.RefreshExportBin();
                bin.mExportBin.Clear();
                bin.PopulateExportBin();
            }





            //packageFile = packageFile.ToLower();
            foreach (var item in bin.mExportBin)
            {
                if (item == null) 
                    continue;
                
                if (strContains) {
                    string pN = item.PackageName;
                    if (pN == null) continue;
                    if (pN.Contains(packageFile))
                    {
                        return item;
                    }
                }
                else
                {
                    if (item.PackageName == packageFile)
                    {
                        return item;
                    }
                }
            }
            //string[] packageNames = ExportBin.GetPackageNames();
            //if (packageNames != null)
            //{
            //    foreach (string info in packageNames)
            //    {
            //        if (!ImportLot_PackageFileInfoIsPackageFile(info, packageFile)) 
            //            continue;
            //        ExportBinContents package = BinCommon.GetPackage(info);
            //        if (package != null)
            //        {
            //            if (!bin.mExportBin.Contains(package))
            //                bin.mExportBin.Add(package);
            //            return package;
            //        }
            //    }
            //}
            return InternalExportBinContents_ImportLot(bin, packageFile);
        }

        public enum ReDEBUG : short
        {
            Success,
            Failed,
            ExportBinTypeIsHousehold,
            FailedImport,
            ContentFailure,
            LotTooLowSize,
            NoUIInfo,
            NoContentInfo,
            Error,
            CouldNotFind,
            NeedLoad,
            @unsafe,
            ArgCantNull
        }

        public static 
            void ImportLot_AndImportHousehold(Lot targetLot, IEditTownModel editTownModel, UIBinInfo importLotInfo, UIBinInfo targetLotInfo, ExportBinContents exBinLotC)
        {
            editTownModel.PlaceFromExportBin(importLotInfo, targetLotInfo.LotId, PlaceAction.MoveIn);
            try
            {
                if (!BinCommon.PayForLot(exBinLotC.Household, targetLot, true))
                {
                    exBinLotC.Household.SetFamilyFunds(0, false);
                }
            }
            catch (Exception)
            { }

            // No STBL Sorry :)
            if (Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Move In Activate"))
            {
                Household cads = PlumbBob.sCurrentNonNullHousehold;
                Sim NFActive = NFinalizeDeath.ActiveActor;
                PlumbBob.sCurrentNonNullHousehold = null;
                NFinalizeDeath.ActiveActor = null;
                if (BinCommon.ActivateSim(exBinLotC.Household, targetLot) == null)
                    NFinalizeDeath.ActiveActor = NFActive;
                else
                {
                    PlumbBob.sCurrentNonNullHousehold = cads;// NFActive == null ? null : NFActive.Household;
                    PlumbBob.CheckForChangeInActiveHousehold(NFinalizeDeath.ActiveHousehold, true);
                }
            }
        }

        public static ReDEBUG ImportLot(
                Lot targetLot,
                string packageFile,
                ref LotRotationAngle lotAngle,
                ref LotPosition lotPosition
        ){

            if (targetLot == null || NFinalizeDeath.IsNullOrEmpty(packageFile)) return ReDEBUG.ArgCantNull;

            IEditTownModel editTownModel = Sims3.UI.Responder.Instance.EditTownModel;
            if (editTownModel == null)
                return ReDEBUG.NeedLoad;

           
           



            ExportBinContents exBinLotC = ImportLot_ExportBinContents(BinModel.Singleton, packageFile, false);
            if (exBinLotC == null) 
                return ReDEBUG.CouldNotFind;

           

            ulong lotId = targetLot.LotId;

            UIBinInfo targetLotInfo = editTownModel.FindLotBinInfo(lotId) ??
                editTownModel.FindCommunityLotBinInfo(lotId) ??
                editTownModel.FindHouseholdBinInfo(lotId);



            //UIBinInfo uIBinInfo2 = editTownModel.FindHouseholdBinInfo(lotId);
            //if (uIBinInfo2 == null)
            //{
            //    uIBinInfo2 = editTownModel.FindLotBinInfo(lotId);
            //}
            //if (uIBinInfo2 == null)
            //{
            //    uIBinInfo2 = editTownModel.FindCommunityLotBinInfo(lotId);
            //}

            if (targetLotInfo == null)
                return ReDEBUG.NoUIInfo;

            UIBinInfo importLotInfo = exBinLotC.BinInfo;
            if (importLotInfo == null) return ReDEBUG.NoContentInfo;

            if (exBinLotC.mExportBinType == ExportBinType.Household)
                return ReDEBUG.ExportBinTypeIsHousehold;

            if (!ImportLot_CanBePlacedOnLot(importLotInfo, targetLotInfo))
                return ReDEBUG.LotTooLowSize;

            if (!exBinLotC.IsLoaded())
                exBinLotC.Import(true);


            if (exBinLotC.LotContents == null) return ReDEBUG.ContentFailure;
            

            ulong cId = exBinLotC.LotContents.ContentId;//ImportLot_ContentImportLotInfo(exBinLotC.BinInfo);

            if (cId == 0 || cId == ulong.MaxValue)
                return ReDEBUG.ContentFailure;


            Household oldHousehold = targetLot.Household;

            Sim ActiveActor = NFinalizeDeath.ActiveActor;
            if (ActiveActor != null && ActiveActor.LotCurrent == targetLot)
            {
                ActiveActor.SetPosition(Create.GetPositionInRandomLot(LotManager.GetWorldLot()));
                try
                {
                    if (ActiveActor.SimRoutingComponent != null)
                        ActiveActor.SimRoutingComponent.ForceUpdateDynamicFootprint();
                    ActiveActor.ModifyFunds(+Create.GetAllCostLot(targetLot));
                }
                catch
                { }

            }

            try
            {
                if (!ImportLot_PlaceLotContents(targetLot, cId, ref lotAngle, ref lotPosition, false, true))
                {
                    NFinalizeDeath.DestroyAllObjectsOnLot(targetLot);
                    Simulator.Sleep(0); 
                    targetLot.Bulldoze(false, true, false, false); 
                    Simulator.Sleep(0);
                    NFinalizeDeath.DestroyAllObjectsOnLot(targetLot);

                    targetLot.CommercialLotSubType = CommercialLotSubType.kMisc_NoVisitors;
                    targetLot.ResidentialLotSubType = ResidentialLotSubType.kResidentialUndefined;
                    targetLot.LotType = LotType.Residential;

                    return ReDEBUG.FailedImport; 
                }

                try
                {
                    SeasonalLotMarker[] objects = NFinalizeDeath.SC_GetObjectsOnLot<SeasonalLotMarker>(targetLot);
                    if (objects.Length > 0)
                    {
                        objects[0].InitialUpdate();
                    }
                }
                catch (StackOverflowException) { throw; }
                catch (ResetException) { throw; }
                catch {}
                


                targetLot.LotType = importLotInfo.LotType;
                targetLot.CommercialLotSubType = importLotInfo.CommercialLotSubType;
                targetLot.ResidentialLotSubType = importLotInfo.ResidentialLotSubType;
                targetLot.Name = importLotInfo.LotName;
                targetLot.Description = importLotInfo.LotDescription;

                targetLot.UpdateCachedValues();

                var householdContents = exBinLotC.HouseholdContents;
                if (householdContents != null)
                {
                    var household = householdContents.Household;

                    if (household != null)
                    {
                        try
                        {
                            if (oldHousehold != null)
                            {
                                oldHousehold.MoveOut();
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }
                       

                        try
                        {
                            foreach (SimDescription siteem in household.AllSimDescriptions)
                                siteem.Fixup();
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }

                        NFinalizeDeath.CreateActorsPro(household,targetLot,householdContents, false, true, false);

                        try
                        {
                            if (oldHousehold != null)
                                AutoMoveInLotFromHousehold(oldHousehold);
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }

                        try
                        {
                            if (!ScriptCore.World.World_IsEditInGameFromWBModeImpl() && Simulator.CheckYieldingContext(false) && ((NFinalizeDeath.ActiveActor == null && GameStates.IsLiveState) || (!NFinalizeDeath.IsOnVacation(true) && !GameStates.IsPlayFlowState && !GameStates.IsEditTownState && NFinalizeDeath.CheckAccept("Move In Activate"))))
                            {
                                Household cads = PlumbBob.sCurrentNonNullHousehold;
                                Sim NFActive = NFinalizeDeath.ActiveActor;
                                PlumbBob.sCurrentNonNullHousehold = null;
                                NFinalizeDeath.ActiveActor = null;
                                //var newActiveActor = BinCommon.ActivateSim(household, targetLot);
                                //if (newActiveActor == null)
                                if (NFinalizeDeath.HouseholdMembersToSim(household, !NiecRunCommand.IsOpenDGSInstalled, true) == null)
                                    NFinalizeDeath.ActiveActor = NFActive;
                                else
                                {
                                    PlumbBob.sCurrentNonNullHousehold = cads;// NFActive == null ? null : NFActive.Household;
                                    //NFinalizeDeath.ActiveActor = newActiveActor;
                                    PlumbBob.CheckForChangeInActiveHousehold(NFinalizeDeath.ActiveHousehold, true);
                                }
                            }
                        }
                        catch (StackOverflowException) { throw; }
                        catch (ResetException) { throw; }
                        catch { }
                        
                    }

                    

                }

                //try
                //{
                //    if (importLotInfo.HouseholdId != ulong.MaxValue)
                //    {
                //        if (Simulator.CheckYieldingContext(false))
                //        {
                //            ImportLot_AndImportHousehold(targetLot, editTownModel, importLotInfo, targetLotInfo, exBinLotC);
                //        }
                //        else Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate { ImportLot_AndImportHousehold(targetLot, editTownModel, importLotInfo, targetLotInfo, exBinLotC); });
                //    }
                //}
                //catch (Exception)
                //{ }

                /*
                if (targetLot != null) {
                    Simulator.Sleep(0u);
                    targetLot.EnsureLotObjects();
                    Simulator.Sleep(0u);
                }
                */



                return ReDEBUG.Success;
            }
            catch (Exception)
            { return ReDEBUG.Error; }
            finally {
                try
                {
                    string name = targetLot.Name;
                    if (name != null && !Lot.IsValidName(name))
                    {
                        targetLot.Name = Lot.GetDefaultLotName(targetLotInfo.LotType);
                        targetLot.Description = "";
                    }
                    if (!Simulator.CheckYieldingContext(false))
                        Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate { World.LotClusterTrees(targetLot.LotId, false); ThumbnailManager.UpdateDirtyLotThumbnails(); });
                    else ThumbnailManager.UpdateDirtyLotThumbnails();

                    if (!NiecRunCommand.IsOpenDGSInstalled && BinModel.Singleton.mExportBin != null)
                    {
                        foreach (var item in BinModel.Singleton.mExportBin)
                        {
                            if (item == null) continue;
                            if (item.HouseholdContents == null) continue;
                            item.HouseholdContents.mHousehold = null;
                        }
                    }
                }
                catch (Exception)
                {}
               
                exBinLotC.Flush(); 
            }
            
        }


        public static
            bool AllHouseholdToExportHousehold(bool allIncludeLotContents, bool exportLotAndHousehold, bool needFixHouseholdList, bool checkChild, bool saveSpecialHousehold)
        {

            try
            {
                NFinalizeDeath.FixAllHouseholdMembers();
                NFinalizeDeath.AllEmptyFixUp(null);


                if (needFixHouseholdList)
                    NFinalizeDeath.FixHouseholdList();
            }
            catch (StackOverflowException) { throw; }
            catch (ResetException) { throw; }
            catch (Exception) {}

            for (int iv = 0; iv < 100; iv++)
                Simulator.Sleep(0);

            NFinalizeDeath.UpdateNiecSimDescriptions();
            NFinalizeDeath.Ndelalldesc_Valid();

            if (needFixHouseholdList)
                NFinalizeDeath.FixHouseholdList();

            Household[] householdList = NFinalizeDeath.SC_GetObjects<Household>();
            if (householdList.Length == 0) { NiecException.PrintMessagePro("householdList.Length == 0", false, 10); return false; }

            StringBuilder sb = new StringBuilder();
            sb.Append("Start All Household To Export Household:\n\n\n");
            int idone = 0;
            try
            {
                foreach (var item in householdList)
                {
                    if (item == null)
                        continue;

                    if (!item.mbInited) 
                        continue;

                    if (!saveSpecialHousehold && item.IsSpecialHousehold)
                        continue;

                    Household.Members mem = item.mMembers;
                    if (mem == null || mem.mAllSimDescriptions == null || mem.mAllSimDescriptions.Count == 0)
                        continue;

                    if (checkChild && NiecSocialWorkerChildAbuseSituation.IsHouseholdOnlyChildOrPet(mem.mAllSimDescriptions.ToArray())) 
                        continue;


                    try
                    {
                        string lotEx;// = "";
                        if (!exportLotAndHousehold && allIncludeLotContents)
                        {
                            string tDoneFile = (ExportHousehold(Bin.Singleton, item, false, false, true) ?? "None");

                            //string ts = "File Name: " + tDoneFile + "\n" + NiecException.GetHouseholdInfo(item, false, " ");//"Household Name: " + item.Name + 
                                


                            

                            if (allIncludeLotContents && item.LotHome != null)
                            {
                                //lotEx = "";
                                string backupD = item.LotHome.mDescription;

                                if (string.IsNullOrEmpty(item.LotHome.mDescription))
                                    item.LotHome.mDescription = "File Name: " + tDoneFile + "\nHHInfo: " + item.mName + ", Id: " + item.HouseholdId;
                                else
                                    item.LotHome.mDescription += "\nFile Name: " + tDoneFile + "\nHHInfo: " + item.mName + ", Id: " + item.HouseholdId;

                               

                                try
                                {
                                    lotEx = ExportLot(item.LotHome) ?? "None";
                                }
                                catch (ResetException) // Cancel :) Command Run: niecmod removetask
                                { throw; }
                                catch (Exception) { lotEx = "None"; }
                                finally
                                {
                                    item.LotHome.mDescription = backupD;
                                }

                                //if (!string.IsNullOrEmpty(lotEx))
                                //    sb.Append("Lot File Name: " + lotEx + "\n" + ts + "\n\n");
                                //else
                                sb.Append (
                                    "File Name: " + tDoneFile + 
                                    "\nLot File Name: " + lotEx + "\n" + 
                                    NiecException.GetHouseholdInfo(item, false, " ") + 
                                    "\n\n/////////////////////////////////\n"
                                );
                                //(ts + "\n\n/////////////////////////////");
                            }
                            else sb.Append (
                                "File Name: " + tDoneFile + "\n" + 
                                NiecException.GetHouseholdInfo(item, false, " ") + 
                                "\n\n////////////////////////////////\n"
                            );
                        }
                        else
                        {
                            /*
                            sb.Append (
                                NiecException.GetHouseholdInfo(item, false, " ") +
                                "\nFile Name: " +
                                (ExportHousehold(Bin.Singleton, item, allIncludeLotContents && item.LotHome != null, false, true) ?? "None")  +
                                "\n\n"
                            );*/
                            sb.Append (
                                "File Name: " + (ExportHousehold(Bin.Singleton, item, allIncludeLotContents && item.LotHome != null, false, true) ?? "None")
                                + "\n" + 
                                NiecException.GetHouseholdInfo(item, false, " ") + 
                                "\n\n////////////////////////////////\n"
                            );
                        }
                    }
                    catch (ResetException) // Cancel :) Command Run: niecmod removetask
                    { throw; }
                    catch { }
                    idone++;
                }
            }
            //catch (ResetException)
            //{ throw; }
            catch (Exception)
            { }

            if (idone == 0) { 
                NiecException.PrintMessagePro("idone == 0", false, 10); 
                return false; 
            }

            sb.Append("\n\nEnd All Household To Export Household");

            NiecException.PrintMessagePro("AllExport Household: Done", false, 10);

            NiecException.WriteLog(sb.ToString());

            uint i =  (uint)ListCollon.SafeRandom.Next(45, 4545666);

            string asdt = Simulator.CreateExportFile(ref i, "ExHouseholdAll");

            sb.Append("\nFile Name: " + asdt + "\nDate: " + DateTime.Now.ToString());
            sb.Append('\0');

            Simulator.AppendToScriptErrorFile(i, sb.ToString().ToCharArray());

            Simulator.CloseScriptErrorFile(i);
            return true;
        }

        public static string ExportLot(Lot TargetLot)
        {
            try
            {
                string result = null;
                ulong lotContentsID = DownloadContent.StoreLotContents(TargetLot, TargetLot.LotId);
                if (lotContentsID != 0)
                {
                    ThumbnailHelper.GenerateLotThumbnailSet(TargetLot.LotId, lotContentsID, ThumbnailSizeMask.ExtraLarge);
                    ThumbnailHelper.GenerateLotThumbnail(TargetLot.LotId, lotContentsID, 0x0, ThumbnailSizeMask.Medium | ThumbnailSizeMask.Large);
                    result = DownloadContent.ExportLotContentsToExportBin(lotContentsID);
                    ThumbnailManager.InvalidateLotThumbnails(TargetLot.LotId, lotContentsID, ThumbnailSizeMask.ExtraLarge);
                    ThumbnailManager.InvalidateLotThumbnailsForGroup(TargetLot.LotId, lotContentsID, ThumbnailSizeMask.Medium, 0x0);
                }
                return result;
            } 
            catch (ResetException)
            {
                throw;
            }
            catch
            {
                return null;
            }
            
        }


        public static string ExportHousehold(Bin ths, Household household, bool includeLotContents, bool isMovingPacked, bool noReset)
        {
            try
            {
                string str = null;
                if (GameUtils.IsInstalled(ProductVersion.EP4))
                {
                    OccultImaginaryFriend.ForceHouseholdImaginaryFriendsBackToInventory(household);
                }
                if (!noReset)
                {
                    foreach (Sim sim in household.AllActors)
                    {
                        sim.SetObjectToReset();
                    }
                }
                SpeedTrap.Sleep(0);

                if (includeLotContents)
                {
                    Lot lotHome = household.LotHome;
                    if (lotHome != null)
                    {
                        int num = household.FamilyFunds;
                        int num2 = World.GetEmptyLotWorth(lotHome.LotId) + ((int)World.GetLotAdditionalPropertyValue(lotHome.LotId));
                        household.SetFamilyFunds(household.FamilyFunds + num2, false);
                        EditTownModel.SendObjectsToProperLot(lotHome);
                        ulong contentId = DownloadContent.StoreLotContents(lotHome, lotHome.LotId);
                        if (contentId != 0x0)
                        {
                            ThumbnailHelper.GenerateLotThumbnailSet(lotHome.LotId, contentId, ThumbnailSizeMask.ExtraLarge);
                            ThumbnailHelper.GenerateLotThumbnail(lotHome.LotId, contentId, 0x0, ThumbnailSizeMask.Large | ThumbnailSizeMask.Medium);
                            ThumbnailSizeMask mask = ThumbnailSizeMask.Large | ThumbnailSizeMask.ExtraLarge | ThumbnailSizeMask.Medium;
                            ThumbnailManager.GenerateHouseholdThumbnail(household.HouseholdId, contentId, mask);
                            if (household.AllSimDescriptions.Count < 8)
                                ths.GenerateSimThumbnails(household, contentId, ThumbnailSizeMask.Large | ThumbnailSizeMask.ExtraLarge);
                            NiecMod.Commom.Proxies.HouseholdContentsProxy contents = new NiecMod.Commom.Proxies.HouseholdContentsProxy(household);
                            if (DownloadContent.StoreHouseholdContents(contents, contentId))
                            {
                                str = DownloadContent.ExportLotContentsToExportBin(contentId);
                            }
                            ThumbnailManager.InvalidateLotThumbnails(lotHome.LotId, contentId, ThumbnailSizeMask.ExtraLarge);
                            ThumbnailManager.InvalidateLotThumbnailsForGroup(lotHome.LotId, contentId, ThumbnailSizeMask.Medium, 0x0);
                            ThumbnailManager.InvalidateHouseholdThumbnail(household.HouseholdId, contentId, mask);
                            ths.InvalidateSimThumbnails(household, contentId);
                        }
                        household.SetFamilyFunds(num, false);
                    }
                    return str;
                }

                int familyFunds = household.FamilyFunds;
                int realEstateFunds = 0;
                if (household.RealEstateManager != null)
                {
                    foreach (IPropertyData data in household.RealEstateManager.AllProperties)
                    {
                        realEstateFunds += data.TotalValue;
                    }
                }
                if (household.LotHome != null)
                {
                    int lotWorth = 0;
                    if (isMovingPacked)
                    {
                        lotWorth = World.GetUnfurnishedLotWorth(household.LotHome.LotId) + realEstateFunds;
                    }
                    else
                    {
                        lotWorth = World.GetLotWorth(household.LotHome.LotId) + realEstateFunds;
                    }

                    household.SetFamilyFunds(household.FamilyFunds + lotWorth, false);
                }

                if (household.FamilyFunds < 0x4e20)
                {
                    household.SetFamilyFunds(0x4e20, false);
                }

                ulong cacheId = DownloadContent.GenerateGUID();
                NiecMod.Commom.Proxies.HouseholdContentsProxy householdContents = new NiecMod.Commom.Proxies.HouseholdContentsProxy(household);
                householdContents.Contents.ContentId = cacheId;
                ThumbnailSizeMask sizeMask = ThumbnailSizeMask.Large | ThumbnailSizeMask.ExtraLarge | ThumbnailSizeMask.Medium;
                if (household.AllSimDescriptions.Count < 8)
                {
                    ThumbnailManager.GenerateHouseholdThumbnail(household.HouseholdId, cacheId, sizeMask);
                    ths.GenerateSimThumbnails(household, cacheId, ThumbnailSizeMask.Large | ThumbnailSizeMask.ExtraLarge);
                }
                if (DownloadContent.StoreHouseholdContents(householdContents, cacheId))
                {
                    str = DownloadContent.ExportLotContentsToExportBin(cacheId);
                }

                ThumbnailManager.InvalidateHouseholdThumbnail(household.HouseholdId, cacheId, sizeMask);
                ths.InvalidateSimThumbnails(household, cacheId);
                household.SetFamilyFunds(familyFunds, false);
                return str;
            }
            catch //(Exception)
            {  return null; }
        }
        public static bool AllCreateHouseholdToLot()
        {
            if (!Simulator.CheckYieldingContext(false)) 
                return false;

            try
            {
                NFinalizeDeath.FixAllHouseholdMembers();
            }
            catch (Exception)
            {
                if (!Simulator.CheckYieldingContext(false))
                    throw;
            }

            bool world_IsEditInGameFromWBMode = ScriptCore.World.World_IsEditInGameFromWBModeImpl();

            bool isNeedForceSelectActor =
                Simulator.CheckYieldingContext(false) &&
                !world_IsEditInGameFromWBMode &&
                NFinalizeDeath.CheckAccept("PlumbBob.ForceSelectActor(Sim);");

            bool doneSelectActor = false;

            bool noCreateSimDesc = Instantiator.OpenDGS_GetNoCreate();


            try
            {
                List<Lot> lit = NFinalizeDeath.GetAllResidentialLots();
                if (lit == null)
                    return false;

                int AllLotCount = 0x0FF0AA00;
                int left = -1;

                if (NiecRunCommand.exLotList == null || NiecRunCommand.exLotList.Count == 0)
                {

                    AllLotCount = lit.Count;

                    if (!int.TryParse(
                        StringInputDialog.Show(
                           "NiecMod", "Residentials Count: " + AllLotCount.ToString(), "3", 5, StringInputDialog.Validation.None
                        ),
                        out left
                    )) return false;
                }


                Instantiator.OpenDGS_SetNoCreate(false);
                foreach (Lot lotItem in lit)//LotManager.AllLots)
                {
                    if (AllLotCount != 0x0FF0AA00)
                    {
                        AllLotCount--;

                        if (AllLotCount == left)
                            return true;

                        if (lotItem == null)
                            continue;

                        if (World.LotIsEmpty(lotItem.LotId) && lotItem.IsLotEmptyFromObjects())
                            continue;
                    }


                    else if (lotItem == null || (NiecRunCommand.exLotList != null && NiecRunCommand.exLotList.Contains(lotItem)))
                        continue;


                    //if (!item.IsResidentialLot)
                    //    continue;

                    if (lotItem.IsWorldLot)
                        continue;

                    if (lotItem.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) || UnchartedIslandMarker.IsUnchartedIsland(lotItem))
                        continue;

                    if (lotItem.Household != null)
                        continue;


                    int bedCount = (int)(lotItem.CountObjects<IBedDouble>() * 2 + lotItem.CountObjects<IBedSingle>());
                    if (bedCount == 0 || bedCount < 0)
                        continue;
                    if (bedCount > 7) {
                        bedCount = 5;
                    }
                    int cribCount = (int)(lotItem.CountObjects<ICrib>());
                    if (cribCount == 0 || cribCount < 0) cribCount = 0;
                    else cribCount = ListCollon.SafeRandomPart2.Next(0, cribCount);

                    Household hHousehold;

                    try
                    {
                        hHousehold = SimUtils.HouseholdCreationSpec.MakeTypicalFamily (

                             numSims: ListCollon.SafeRandomPart2.Next(0, bedCount + cribCount),
                             minToddlers: cribCount,
                             minChildren: ListCollon.SafeRandomPart2.Next(0, 2),
                             minTeens: ListCollon.SafeRandomPart2.Next(0, 1)

                        ).Instantiate();
                    }
                    catch
                    {
                        continue;
                    }

                    if (hHousehold == null) continue;

                    int petBedCount = (int)(lotItem.CountObjects<IPetBed>());
                    if (petBedCount == 0 || petBedCount < 0) { }
                    else Create.AddPetToHousehold(hHousehold, ListCollon.SafeRandomPart2.Next(0, petBedCount));

                    foreach (SimDescription siteem in hHousehold.AllSimDescriptions)
                    {
                        try
                        {
                            siteem.Fixup();
                        }
                        catch (Exception)
                        { }

                        try
                        {
                            if (isNeedForceSelectActor && !doneSelectActor)
                            {
                                doneSelectActor = true;
                                var si = NFinalizeDeath.SimDesc_SafeInstantiate(siteem, NFinalizeDeath.Vector3_OutOfWorld);
                                if (si != null)
                                PlumbBob.ForceSelectActor(
                                    //siteem.Instantiate
                                    //(Vector3.OutOfWorld, NiecRunCommand.IsOpenDGSInstalled || world_IsEditInGameFromWBMode)
                                    si
                                );
                                if (PlumbBob.SelectedActor == null)
                                    doneSelectActor = false;
                            }
                            else
                                NFinalizeDeath.SimDesc_SafeInstantiate(siteem, NFinalizeDeath.Vector3_OutOfWorld);
                                //siteem.Instantiate
                                //    (Vector3.OutOfWorld, NiecRunCommand.IsOpenDGSInstalled || world_IsEditInGameFromWBMode);
                        }
                        catch (Exception)
                        { }
                    }

                    if (hHousehold.LotHome == null && lotItem.Household == null) // i dont know OpenDGS Auto
                        lotItem.MoveIn(hHousehold);

                    try
                    {
                        NFinalizeDeath.SetStartingFunds(hHousehold);
                    }
                    catch (Exception)
                    {
                        if (ListCollon.SafeRandomPart2 != null)
                            hHousehold.mFamilyFunds = ListCollon.SafeRandomPart2.Next(3500, 20000);
                        else
                            hHousehold.mFamilyFunds = RandomUtil.GetInt(3500, 20000);
                    }

                    Sims3.NiecHelp.Tasks.NiecTask.Perform(delegate
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            Simulator.Sleep(0);
                        }
                        Create.ForceSendHomeAllActors(hHousehold);
                    });

                    try
                    {
                        if (Instantiator.RootIsOpenDGSInstalled) {

                            Lot HouseholdLotHome = hHousehold.LotHome;
                            if (HouseholdLotHome != null) {
                                if (hHousehold.FamilyFunds >= HouseholdLotHome.Cost)
                                {
                                    hHousehold.ModifyFamilyFunds(-HouseholdLotHome.Cost);
                                    hHousehold.ModifyFamilyFunds(ListCollon.SafeRandomPart2.Next(700, 8000));
                                }
                                else hHousehold.ModifyFamilyFunds(ListCollon.SafeRandomPart2.Next(2750));
                            }
                        }
                        else
                        {
                            if (hHousehold.FamilyFunds >= lotItem.Cost)
                            {
                                hHousehold.ModifyFamilyFunds(-lotItem.Cost);
                                hHousehold.ModifyFamilyFunds(ListCollon.SafeRandomPart2.Next(700, 8000));
                            }
                            else hHousehold.ModifyFamilyFunds(ListCollon.SafeRandomPart2.Next(2750));
                        }
                    }
                    catch (Exception)
                    { }

                }
                NFinalizeDeath.FixAllHouseholdMembers();
                NFinalizeDeath.AllEmptyFixUp(null);
                NFinalizeDeath.UpdateNiecSimDescriptions();
            }
            finally
            {
                Instantiator.OpenDGS_SetNoCreate(noCreateSimDesc);
            }
            return true;
        }




        public static void AddPetToHousehold(Household household, int numPet)
        {
            try
            {
                if (GameUtils.IsInstalled(ProductVersion.EP5) && !GameStates.IsOnVacation && !GameUtils.IsUniversityWorld() && !GameUtils.IsFutureWorld() && household.CanAddSpeciesToHousehold(CASAgeGenderFlags.Dog))
                {
                    int catWeight = 1;
                    int dogWeight = 1;
                    float chanceOfAddingAPet = CreateHousehold.kChanceOfAddingAPet;

                    foreach (SimDescription member in household.SimDescriptions)
                    {
                        if (member == null) continue;

                        TraitManager tm = member.TraitManager;

                        if (tm == null) 
                            continue;

                        if (tm.HasAnyElement(CreateHousehold.kPositiveTraits))
                        {
                            chanceOfAddingAPet += CreateHousehold.kPositiveTraitChanceChange;
                        }
                        if (tm.HasAnyElement(CreateHousehold.kNegativeTraits))
                        {
                            chanceOfAddingAPet += CreateHousehold.kNegativeTraitChanceChange;
                        }
                        AddPet.UpdatePetWeightsForDescription(member, ref catWeight, ref dogWeight);
                    }

                    chanceOfAddingAPet = Math.Min(chanceOfAddingAPet, 1f);
                    chanceOfAddingAPet = Math.Max(chanceOfAddingAPet, 0f);

                    for (int i = 0; i < numPet; i++)
                    {
                        if (RandomUtil.RandomChance01(chanceOfAddingAPet))
                        {
                            int petWeight = catWeight + dogWeight;

                            SimUtils.PetCreationSpec petCreationSpec = new SimUtils.PetCreationSpec();
                            petCreationSpec.Species = CASAgeGenderFlags.Cat;

                            if (RandomUtil.GetInt(petWeight - 1) < dogWeight)
                                petCreationSpec.Species = (RandomUtil.CoinFlip() ? CASAgeGenderFlags.Dog : CASAgeGenderFlags.LittleDog);


                            petCreationSpec.Normalize();
                            SimDescription simDescription = petCreationSpec.Instantiate();
                            if (simDescription != null)
                                household.Add(simDescription);
                        }
                    }
                    
                }
            }
            catch (ResetException)
            {throw;}
            catch { }
            
        }


        public static bool ofunsaddmnil = false;
        public static float MaleRatio = 0.5f;

        public static NiecHelperSituation CreateRandomNiecHelperSituation(Sim ArgSim, bool NoDialog, bool ArgAddIfIsSelectable, bool ShowSimTalking)
        {
            Sim ActiveActorOpenDGS = NFinalizeDeath.ActiveActor;
            Sim ActiveActorNonOpenDGS = PlumbBob.SelectedActor;

            bool AddIfIsSelectable = ArgAddIfIsSelectable || !NoDialog && Simulator.CheckYieldingContext(false) && NFinalizeDeath.CheckAccept("Add if IsPlayer?");
            if (!AddIfIsSelectable)
            {
                NiecHelperSituation.bUnsafeRunReapSoulIsSelectable = true;
                NiecHelperSituation.Spawn._bUnSafeRunAll = true;
            }
            List<Sim> SimListRandom = new List<Sim>();

            foreach (var ActorFor in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (ActorFor == ActiveActorOpenDGS || ActorFor == ActiveActorNonOpenDGS)
                    continue;

                SimDescription simd = ActorFor.SimDescription;

                if (simd == null)
                    continue;
                if (simd.IsPet)
                    continue;

                if (AddIfIsSelectable && ActorFor.IsSelectable)
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
                if (situationOfTypex != null)
                    continue;

                if (NiecRunCommand.IsOpenDGSInstalled && ((simd.Service as GrimReaper ?? simd.CreatedByService as GrimReaper) != null))
                    continue;

                SimListRandom.Add(ActorFor);

            }
            if (SimListRandom.Count > 0)
            {
                Sim SimNew = RandomUtil.GetRandomObjectFromList<Sim>(SimListRandom, ListCollon.SafeRandom);
                if (SimNew != null)
                {

                    SimListRandom.Clear();
                    var nhs = NiecHelperSituation.ExistsOrCreate(SimNew);
                    if (nhs != null)
                        SimNew.Autonomy.SituationComponent.Situations.Add(nhs);
                    else { NiecException.PrintMessagePro("ExistsOrCreate Failed: nhs == null", false, 10f); return null; }
                    if (ShowSimTalking)
                        StyledNotification.Show (
                            new StyledNotification.Format("Hello My Name: " + SimNew.FullName + "\nNiec Helper Situation Created :)", SimNew.ObjectId,
                                StyledNotification.NotificationStyle.kSimTalking
                        ));


                    NiecHelperSituation niecHelperSituation = SimNew.GetSituationOfType<NiecHelperSituation>();

                    Sim Target = ArgSim ?? NiecRunCommand.HitTargetSim() ?? PlumbBob.SelectedActor ?? SimNew;

                    if (Target != SimNew)
                    {
                        SimNew.InteractionQueue.Add(
                            (!niecHelperSituation.OkSuusse ?
                                Sims3.Gameplay.NiecRoot.NiecHelperSituation.NiecAppear.Singleton : NiecHelperSituation.ReapSoul.Singleton)
                                .CreateInstance(Target, SimNew, new InteractionPriority(
                                    NiecRunCommand.IsOpenDGSInstalled ?
                                    (InteractionPriorityLevel)100 :
                                    (InteractionPriorityLevel)12, 999f),

                            isAutonomous: false,
                            cancellableByPlayer: true
                        ));
                    }
                    return niecHelperSituation;
                }
            }
            else { if (!NoDialog) SimpleMessageDialog.Show("NiecMod", "Failed to Random\nCreate Niec Helper Situation!"); }

            return null;
        }

        private static int failFindDescOrTargetSimDesc = 0;

        public static int GetErrorFindDescOrTargetSimDesc()
        {
            var i = failFindDescOrTargetSimDesc;
            failFindDescOrTargetSimDesc = 0;
            return i;
        }

        public static SimDescription FindDescOrTargetSimDesc(ulong SimDescID, ulong DefaultSimDescID, bool TargetSim)
        {
            failFindDescOrTargetSimDesc = 0;
            if (!Simulator.CheckYieldingContext(false) && SimDescID == 0)
            {
                failFindDescOrTargetSimDesc = 1;
                return null;
            }
            string text = null;



            if (TargetSim)
            {
                Sim SimA = NiecRunCommand.HitTargetSim();
                if (DefaultSimDescID != 0)
                    text = StringInputDialog.Show("Find SimDescription", "SimDescription's Id", DefaultSimDescID.ToString()
                        , 256, StringInputDialog.Validation.None);
                else if (SimA != null && SimA.SimDescription != null)
                    text = StringInputDialog.Show("Find SimDescription", "SimDescription's Id", SimA.SimDescription.SimDescriptionId.ToString()
                        , 256, StringInputDialog.Validation.None);
                else if (PlumbBob.SelectedActor != null && PlumbBob.SelectedActor.SimDescription != null)
                    text = StringInputDialog.Show("Find SimDescription", "SimDescription's Id", PlumbBob.SelectedActor.SimDescription.SimDescriptionId.ToString()
                        , 256, StringInputDialog.Validation.None);
                else
                    text = StringInputDialog.Show("Find SimDescription", "SimDescription's Id", "0" //"00000000000000000000"
                        , 256, StringInputDialog.Validation.None);

                if (string.IsNullOrEmpty(text))
                {
                    failFindDescOrTargetSimDesc = 2;
                    return null;
                }

                ulong newValuex;

                if (!ulong.TryParse(text, out newValuex))
                {
                    failFindDescOrTargetSimDesc = 3;
                    return null;
                }

                SimDescription simatx = null;

                try
                {
                    simatx = SimDescription.Find(newValuex);
                    if (simatx != null)
                    {
                        return simatx;
                    }
                }
                catch (ResetException)
                { throw; }
                catch
                { }

                if (simatx == null && Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions != null)
                {
                    foreach (SimDescription item in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                    {
                        if (item != null && item.SimDescriptionId == newValuex)
                        {
                            return item;
                        }
                    }
                }





                failFindDescOrTargetSimDesc = 8;
                return null;
            }
            //if (text == null && SimDescID == 0)
            if (SimDescID == 0)
            {
                //text = StringInputDialog.Show("Find SimDescription", "SimDescription's Id", "00000000000000000000", 256, StringInputDialog.Validation.None);
                text = StringInputDialog.Show("Find SimDescription", "SimDescription's Id", DefaultSimDescID.ToString(), 256, StringInputDialog.Validation.None);
            }
            //else if (!TargetSim && SimDescID == 0)
            else
            {
                text = SimDescID.ToString(); //StringInputDialog.Show("Find SimDescription", "SimDescription's Id", SimDescID.ToString(), 256, StringInputDialog.Validation.None);
            }

            if (string.IsNullOrEmpty(text))
            {
                failFindDescOrTargetSimDesc = 2;
                return null;
            }
            ulong newValue;
            if (!ulong.TryParse(text, out newValue))
            {
                failFindDescOrTargetSimDesc = 3;
                return null;
            }
            SimDescription simat = SimDescription.Find(newValue);
            if (simat != null)
            {
                return simat;
            }
            else if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions != null)
            {
                foreach (SimDescription item in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                {
                    if (item.SimDescriptionId == newValue)
                    {

                        return item;
                    }
                }
                failFindDescOrTargetSimDesc = 8;
                return null;
            }
            else
            {
                failFindDescOrTargetSimDesc = 8;
                return null;
            }
        }

        public static void ForceSendHomeAllActors(Household hh) {
            if (hh.LotHome == null) 
                return;
            foreach (var item in hh.AllActors)
            {
                if (item == null)
                    continue;
                SimDescription simd = item.SimDescription;
                if (simd == null)
                    continue;

                if (simd.LotHome == null)
                    continue;
                if (item.LotCurrent == simd.LotHome)
                    continue;
               
                Vector3 pos = Vector3.OutOfWorld;
                Vector3 fwd = Vector3.OutOfWorld;


                try
                {
                    if (item.AttemptToFindSafeLocation(true, out pos, out fwd))
                    {

                        item.SetPosition(pos);
                        item.SetForward(fwd);

                        if (item.SimRoutingComponent != null)
                            item.SimRoutingComponent.ForceUpdateDynamicFootprint();

                        Simulator.Sleep(0);
                        if (item.LotCurrent == item.LotHome)
                            continue;
                    }
                }
                catch (ResetException) { throw; }
                catch (Exception)
                {
                    if (item.LotCurrent == item.LotHome)
                        continue;
                }


                Mailbox mailbox = item.LotHome.FindMailbox();
                World.FindGoodLocationParams fglParams = new World.FindGoodLocationParams(mailbox != null ? mailbox.Position : item.LotHome.Position);
                fglParams.InitialSearchDirection = RandomUtil.GetInt(0x0, 0xF);
                fglParams.BooleanConstraints = FindGoodLocationBooleans.None;



                if (!GlobalFunctions.FindGoodLocation(item, fglParams, out pos, out fwd))
                {
                    if (mailbox != null)
                    {
                        pos = mailbox.Position;
                        fwd = mailbox.ForwardVector;
                    }
                    else
                    {
                        pos = item.LotHome.Position;
                        fwd = item.LotHome.ForwardVector;
                    }

                }

                item.SetPosition(pos);
                item.SetForward(fwd);

                if (item.SimRoutingComponent != null)
                    item.SimRoutingComponent.ForceUpdateDynamicFootprint();
            }
        }





        public static uint CreateRandomHousehold(Lot lot, bool needPet, out Household createdHousehold)
        {
            createdHousehold = null;
            if (lot == null || lot.Household != null) 
                return 0;

            int bedDouble = (int)(lot.CountObjects<IBedDouble>() * 2 + lot.CountObjects<IBedSingle>());
            int crib = (int)lot.CountObjects<Crib>();

            int parent = 0;
            int childern = 0;

            int male = 0;
            int female = 0;

            bedDouble = RandomUtil.GetInt(Math.Min(1, bedDouble / 2), bedDouble);
            if (!lot.CanSupportPopulation(bedDouble))
                return 0;

            SimUtils.HouseholdCreationSpec householdCreationSpec = new SimUtils.HouseholdCreationSpec();

            for (int i = 0; i < bedDouble; i++)
            {
                householdCreationSpec.Sims.Add(new SimUtils.SimCreationSpec());
            }
            if (needPet) {
                int d = ListCollon.SafeRandomPart2.Next(3);
                for (int i = 0; i < d; i++)
                {
                    householdCreationSpec.Sims.Add(new SimUtils.PetCreationSpec());
                }
            }
            if (crib <= 0)
            {
                householdCreationSpec.Roommates = RandomUtil.RandomChance(SimUtils.kPercentChanceOfRoommatesHousehold);
            }



            foreach (SimUtils.SimCreationSpec sim in householdCreationSpec.Sims)
            {
                if (parent < 2 || householdCreationSpec.Roommates || male == 0 || female == 0)
                {
                    sim.Age = (CASAgeGenderFlags.YoungAdult | CASAgeGenderFlags.Adult);
                    if (male / Math.Max(1f, male + female) == MaleRatio)
                    {
                        sim.Gender = (RandomUtil.RandomChance01(MaleRatio) ? CASAgeGenderFlags.Male : CASAgeGenderFlags.Female);
                        if (sim.Gender == CASAgeGenderFlags.Male)
                        {
                            male++;
                        }
                        else
                        {
                            female++;
                        }
                    }
                    else if (MaleRatio >= male + 1 / 1 + male + female)
                    {
                        sim.Gender = CASAgeGenderFlags.Male;
                        male++;
                    }
                    else
                    {
                        sim.Gender = CASAgeGenderFlags.Female;
                        female++;
                    }
                    parent++;
                }
                else
                {
                    if (crib > 0)
                    {
                        sim.Age = (CASAgeGenderFlags.Baby | CASAgeGenderFlags.Toddler | CASAgeGenderFlags.Child | CASAgeGenderFlags.Teen);
                        childern++;
                        crib--;
                    }
                    else
                    {
                        sim.Age = (CASAgeGenderFlags.Child | CASAgeGenderFlags.Teen);
                        childern++;
                    }
                    sim.Gender = (RandomUtil.RandomChance01(MaleRatio) ? CASAgeGenderFlags.Male : CASAgeGenderFlags.Female);
                }
                if (parent > 2 && childern == 0)
                {
                    householdCreationSpec.Roommates = true;
                }
            }

            Household household = householdCreationSpec.Instantiate();
            NFinalizeDeath.SetStartingFunds(household);

            if (household != null)
            {
                household.ModifyFamilyFunds(-lot.Cost);
                lot.MoveIn(household);

                createdHousehold = household;
                return (uint)household.AllSimDescriptions.Count;

            }
            return 0;
        }





        public static bool AutoMoveInLotFromHousehold(Household household)
        {
            if (household == null || household.LotHome != null) 
                return false;

            List<Lot> templotrandom = new List<Lot>();
            Lot Rlot = null;

            foreach (object obj in LotManager.AllLots)
            {
                Lot lot2 = (Lot)obj;
                if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null && !World.LotIsEmpty(lot2.LotId) && !lot2.IsLotEmptyFromObjects())
                {
                    templotrandom.Add(lot2);
                }
                if (templotrandom.Count == 0)
                {
                    if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null)
                    {
                        templotrandom.Add(lot2);
                    }
                }
            }

            if (templotrandom.Count > 0)
            {
                Rlot = RandomUtil.GetRandomObjectFromList<Lot>(templotrandom, ListCollon.SafeRandom);

                try
                {
                    Rlot.MoveIn(household);
                }
                catch
                { }
            }
            else return false;

            return Rlot.Household != null;
        }

        public static SimDescription NiecNullSimDescription(bool needDeleteSimDesc = false, bool noToArray = false, bool noCreate = false)
        {
            if (ListCollon.NullSimSimDescription == null && ListCollon.NiecSimDescriptions != null && ListCollon.NiecSimDescriptions.Count > 0)
            {
                Household ActiveHousehold = NFinalizeDeath.ActiveHousehold;


                if (!noToArray)
                {
                    if (ListCollon.NiecDisposedSimDescriptions != null)
                    {
                        foreach (var itatem in ListCollon.NiecDisposedSimDescriptions.ToArray())
                        {
                            if (itatem == null) continue;

                            if (itatem.Species != CASAgeGenderFlags.None)
                                continue;

                            ListCollon.NullSimSimDescription = itatem;
                            NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(ListCollon.NullSimSimDescription));
                            ListCollon.NiecDisposedSimDescriptions.Remove(itatem);
                            break;
                        }
                    }
                    if (ListCollon.NullSimSimDescription == null)
                    {
                        foreach (var itatem in ListCollon.NiecSimDescriptions.ToArray())
                        {
                            if (itatem == null) continue;

                            if (itatem.Species != CASAgeGenderFlags.None)// && itatem.mIsValidDescription && itatem.mSimDescriptionId != 0) 
                                continue;
                            if (itatem.mHousehold != null && itatem.mHousehold == ActiveHousehold)
                                continue;

                            ListCollon.NullSimSimDescription = itatem;
                            NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(ListCollon.NullSimSimDescription));
                            if (needDeleteSimDesc)
                                NFinalizeDeath.SimDescCleanse(ListCollon.NullSimSimDescription, true, false);

                            break;
                        }
                    }
                }
                else
                {
                    if (ListCollon.NiecDisposedSimDescriptions != null)
                    {
                        foreach (var itatem in ListCollon.NiecDisposedSimDescriptions)
                        {
                            if (itatem == null) continue;

                            if (itatem.Species != CASAgeGenderFlags.None)
                                continue;

                            ListCollon.NullSimSimDescription = itatem;
                            NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(ListCollon.NullSimSimDescription));
                            ListCollon.NiecDisposedSimDescriptions.Remove(itatem);
                            break;
                        }
                    }
                    if (ListCollon.NullSimSimDescription == null)
                    {
                        foreach (var itatem in ListCollon.NiecSimDescriptions)
                        {
                            if (itatem == null) continue;

                            if (itatem.Species != CASAgeGenderFlags.None)// && itatem.mIsValidDescription && itatem.mSimDescriptionId != 0) 
                                continue;
                            if (itatem.mHousehold != null && itatem.mHousehold == ActiveHousehold)
                                continue;

                            ListCollon.NullSimSimDescription = itatem;
                            NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(ListCollon.NullSimSimDescription));
                            if (needDeleteSimDesc)
                                NFinalizeDeath.SimDescCleanse(ListCollon.NullSimSimDescription, true, false);

                            break;
                        }
                    }
                }
            }
            if (ListCollon.NullSimSimDescription == null)
            {
                if (!noToArray)
                {
                    foreach (var itatem in ListCollon.NiecSimDescriptions.ToArray())
                    {
                        if (itatem == null) continue;
                        if (itatem.mIsValidDescription)
                            continue;

                        ListCollon.NullSimSimDescription = itatem;
                        NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(ListCollon.NullSimSimDescription));
                        if (needDeleteSimDesc)
                            NFinalizeDeath.SimDescCleanse(ListCollon.NullSimSimDescription, true, false);

                        break;
                    }
                }
                else
                {
                    foreach (var itatem in ListCollon.NiecSimDescriptions)
                    {
                        if (itatem == null) continue;
                        if (itatem.mIsValidDescription)
                        continue;

                        ListCollon.NullSimSimDescription = itatem;
                        NiecException.WriteLog("Add NullSimSimDescription:\n" + NiecException.GetDescription(ListCollon.NullSimSimDescription));
                        if (needDeleteSimDesc)
                            NFinalizeDeath.SimDescCleanse(ListCollon.NullSimSimDescription, true, false);

                        break;
                    }
                }
            }
            if (!noCreate && ListCollon.NullSimSimDescription == null)
            {
                ListCollon.NullSimSimDescription = NFinalizeDeath.SimDesc_Empty(null);
                ListCollon.NullSimSimDescription.mIsValidDescription = false;

                if (needDeleteSimDesc)
                    NFinalizeDeath.SimDescCleanse(ListCollon.NullSimSimDescription, true, false);
            }
            return ListCollon.NullSimSimDescription;
        }

        

        public static Urnstone DeadSimGrave(SimDescription.DeathType deathType, SimDescription deadsim, bool createSimDesc, bool randomInstance, bool dontModSimDesc )
        {
            if (deathType == SimDescription.DeathType.None)
                deathType = Sims3.NiecHelp.Tasks.KillAnnihilationTask.GetDeathType(null);
            string instanceName = null;
            bool flag = false;
            if (GameUtils.IsFutureWorld() && GameUtils.IsInstalled(ProductVersion.EP11))
            {
                flag = true;
            }
            if (Urnstone.kFutureDeathType == null)
                Urnstone.kFutureDeathType = new SimDescription.DeathType[0];
            List<SimDescription.DeathType> list = new List<SimDescription.DeathType>(Urnstone.kFutureDeathType);
            if (list.Contains(deathType))
            {
                flag = true;
            }
            if (randomInstance)
            {
                
                switch (RandomUtil.GetInt(2))
                {
                    case 0:
                        instanceName = ((!flag) ? "UrnstoneHumanWealthy" : "UrnstoneFutureWealthy");
                        break;
                    case 1:
                        instanceName = ((!flag) ? "UrnstoneHumanPoor" : "UrnstoneFuturePoor");
                        break;
                    case 2:
                        instanceName = ((!flag) ? "UrnstoneHuman" : "UrnstoneFutureModerate");
                        break;
                }
            }
            else
                instanceName = ((!flag) ? "UrnstoneHuman" : "UrnstoneFutureModerate");

            Urnstone urnstone = GlobalFunctions.CreateObject(instanceName, Vector3.OutOfWorld, 0, Vector3.UnitZ) as Urnstone;
            if (urnstone == null)
            {
                throw new NotSupportedException("NiecMod: Failed to Create Grave!");
            }
            if (!dontModSimDesc && deadsim != null)
            {
                deadsim.IsGhost = true;
                Genetics.AssignRandomTraits(deadsim);
                WorldName currentWorld = GameUtils.GetCurrentWorld();
                deadsim.FirstName = SimUtils.GetRandomGivenName(deadsim.IsMale, currentWorld);
                deadsim.LastName = SimUtils.GetRandomFamilyName(currentWorld);
                deadsim.SetDeathStyle(deathType, false);
                urnstone.SetDeadSimDescription(deadsim);
                urnstone.mPlayerMoveable = true;
                urnstone.OnHandToolMovement();
            }
            else if (createSimDesc)
            {
                SimDescription simDescription = Genetics.MakeSim(CASAgeGenderFlags.Elder);
                if (simDescription != null) // Custom Bug
                {
                    Genetics.AssignRandomTraits(simDescription);
                    WorldName currentWorld = GameUtils.GetCurrentWorld();
                    simDescription.FirstName = SimUtils.GetRandomGivenName(simDescription.IsMale, currentWorld);
                    simDescription.LastName = SimUtils.GetRandomFamilyName(currentWorld);
                    simDescription.SetDeathStyle(deathType, false);
                    urnstone.SetDeadSimDescription(simDescription);
                    urnstone.mPlayerMoveable = true;
                    urnstone.OnHandToolMovement();
                }
                else
                {
                    urnstone.mPlayerMoveable = true;
                    urnstone.OnHandToolMovement();
                }
            }
            else
            {
                urnstone.mPlayerMoveable = true;
                urnstone.OnHandToolMovement();
            }
            return urnstone;
        }

        public static bool  FindFoundSimIDNiecSimDesc(ulong newValueid)
        {
            if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions != null)
            {
                foreach (SimDescription item in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                {
                    if (item != null   &&item.SimDescriptionId == newValueid)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static SimDescription FindNiecSimDescription(ulong newValueid)
        {
            if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions != null)
            {
                foreach (SimDescription item in Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions)
                {
                    if (item.SimDescriptionId == newValueid)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public static bool AddNiecSimDescription(SimDescription simdesc)
        {

            if (simdesc == null) return false;
            
            //NiecMod.Nra.NiecException.WriteLog("AddNiecSimDescription DEBUG", true, true);
            if (Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions == null) Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions = new List<SimDescription>(200);
            try
            {
                if (niec_std.array_indexof(Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions._items, simdesc) == -1) //if (!Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Contains(simdesc))
                {
                    
                    //NiecMod.Nra.NiecException.WriteLog("AddNiecSimDescription DEBUG OK", true, true);
                    Sims3.NiecModList.Persistable.ListCollon.NiecSimDescriptions.Add(simdesc);
                    if (FindFoundSimIDNiecSimDesc(simdesc.SimDescriptionId))
                    {
                        simdesc.mSimDescriptionId += (ulong)RandomUtil.GetInt(100, 900000);
                        simdesc.mSimDescriptionId++;
                        try
                        {
                            if (simdesc.CelebrityManager != null)
                            {
                                simdesc.CelebrityManager.ResetOwnerSimDescription(simdesc.mSimDescriptionId);
                            }
                            if (simdesc.PetManager != null)
                            {
                                simdesc.PetManager.ResetOwnerSimDescription(simdesc.mSimDescriptionId);
                            }
                            if (simdesc.TraitChipManager != null)
                            {
                                simdesc.TraitChipManager.ResetOwnerSimDescription(simdesc.mSimDescriptionId);
                            }
                        }
                        catch (ResetException)
                        { throw; }
                        catch
                        { }
                    }
                    return true;
                }
            }
            catch (ResetException)
            { throw; }
            catch (Exception ex)
            {
                NiecMod.Nra.NiecException.WriteLog("AddNiecSimDescription" + NiecMod.Nra.NiecException.NewLine + NiecMod.Nra.NiecException.LogException(ex), true, true);
            }
            //NiecMod.Nra.NiecException.WriteLog("AddNiecSimDescription DEBUG Failed", true, true);
            return false;
        }

        public static Urnstone GhostsGrave(SimDescription sim)
        {
            foreach (Urnstone urnstone in NFinalizeDeath.SC_GetObjects<Urnstone>())
            {
                if (object.ReferenceEquals(urnstone.DeadSimsDescription, sim))
                {
                    return urnstone;
                }
            }

            return null;
        }





        public static bool RandomActiveHouseholdAndActiveActor()
        {
            if (GameStates.IsGameShuttingDown /* || Sims3.SimIFace.Environment.HasEditInGameModeSwitch */
                && !GameStates.IsLiveState) return false;
            List<Sim> list = new List<Sim>();
            foreach (Sim actor in NFinalizeDeath.SC_GetObjects<Sim>())
            {
                if (actor.SimDescription.CreatedSim != null && !actor.IsInActiveHousehold && actor.IsHuman && !actor.SimDescription.IsGhost && actor.SimDescription.Household != Household.NpcHousehold && actor.SimDescription.Household != Household.PetHousehold && actor.SimDescription.Household != Household.MermaidHousehold && actor.SimDescription.Household != Household.TouristHousehold && actor.SimDescription.Household != Household.PreviousTravelerHousehold && actor.SimDescription.Household != Household.AlienHousehold && actor.SimDescription.Household != Household.ServobotHousehold)
                {
                    list.Add(actor);
                }
            }
            if (list.Count == 0)
                return false;

            else if (list.Count > 0)
            {
                Sim randomObjectFromList = RandomUtil.GetRandomObjectFromList(list);
                if (!randomObjectFromList.InWorld)
                {
                    randomObjectFromList.AddToWorld();
                }
                PlumbBob.ForceSelectActor(randomObjectFromList);
                return true;
            }
            return false;
        }

        public static Household CreateActiveHouseholdAndActiveActor(Lot plot, bool noSetAA)
        {
            if (!GameStates.IsLiveState) 
                return null;

            if (GameStates.IsGameShuttingDown || (!noSetAA && PlumbBob.Singleton == null))
                return null;


            if (plot != null && !noSetAA && PlumbBob.SelectedActor != null)
            {
                NFinalizeDeath.TestSetActiveActor(null, true);
            }

            if (!noSetAA && PlumbBob.SelectedActor != null)
                return null;

            List<Lot> lieast = new List<Lot>();
            Lot lot = null;

            //foreach (object obj in LotManager.AllLotsWithoutCommonExceptions)
            if (plot == null)
            {
                foreach (object obj in LotManager.AllLots)
                {
                    //Lot lot2 = (Lot)obj;
                    //if (lot2.IsResidentialLot && lot2.Household == null)
                    Lot lot2 = (Lot)obj;
                    if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null && !World.LotIsEmpty(lot2.LotId) && !lot2.IsLotEmptyFromObjects())
                    {
                        lieast.Add(lot2);
                    }
                    if (lieast.Count == 0)
                    {
                        if (!lot2.IsWorldLot && !lot2.IsCommunityLotOfType(CommercialLotSubType.kEP10_Diving) && !UnchartedIslandMarker.IsUnchartedIsland(lot2) && lot2.IsResidentialLot && lot2.Household == null)
                        {
                            lieast.Add(lot2);
                        }
                    }
                }
            }

            if (plot != null || lieast.Count > 0)
            {

                string simlastnamehousehold = "No Name";

                lot = plot ?? RandomUtil.GetRandomObjectFromList<Lot>(lieast);

                List<Sim> siml = new List<Sim>();

                Sim sim = null;
                Sim sim2 = null;
                Sim sim3 = null;
                Sim sim4 = null;



                if (AssemblyCheckByNiec.IsInstalled("OpenDGS"))
                {
                    try
                    {
                        CommandSystem.ExecuteCommandString("dgspx false");
                    }
                    catch
                    { }
                    sim4 = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.Child, CASAgeGenderFlags.Female, GameUtils.GetCurrentWorld());
                    sim = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.YoungAdult, CASAgeGenderFlags.Male, WorldName.RiverView);
                    sim2 = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.YoungAdult, CASAgeGenderFlags.Female, WorldName.IslaParadiso);
                    sim3 = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.Child, CASAgeGenderFlags.Male, GameUtils.GetCurrentWorld());

                }
                else
                {
                    sim = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.YoungAdult, CASAgeGenderFlags.Male, GameUtils.GetCurrentWorld());
                    sim2 = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.YoungAdult, CASAgeGenderFlags.Female, GameUtils.GetCurrentWorld());
                    sim3 = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.Child, CASAgeGenderFlags.Male, GameUtils.GetCurrentWorld());
                    sim4 = DGSMakeSim.DGSMakeRandomSimNoCheck(lot.Position, CASAgeGenderFlags.Child, CASAgeGenderFlags.Female, GameUtils.GetCurrentWorld());
                }



                if (sim != null)
                {
                    simlastnamehousehold = sim.SimDescription.mLastName;
                    siml.Add(sim);
                }

                if (sim2 != null)
                {
                    simlastnamehousehold = sim2.SimDescription.mLastName;
                    siml.Add(sim2);
                }
                if (sim3 != null) siml.Add(sim3);
                if (sim4 != null) siml.Add(sim4);






                try
                {
                    Relationship relation = Relationship.Get(sim.SimDescription, sim2.SimDescription, true);
                    if (relation != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation, LongTermRelationshipTypes.Spouse);
                    }
                    /*
                    try
                    {
                        sim.Genealogy.RemoveDirectRelation(sim2.Genealogy);
                        sim2.Genealogy.RemoveDirectRelation(sim.Genealogy);
                    }
                    catch
                    { }


                    sim2.Genealogy.AddSibling(sim.Genealogy);
                     */
                }
                catch
                { }







                try
                {
                    Relationship childfrined = Relationship.Get(sim3.SimDescription, sim4.SimDescription, true);
                    if (childfrined != null)
                    {
                        NFinalizeDeath.ForceChangeState(childfrined, LongTermRelationshipTypes.GoodFriend);
                    }










                    Relationship relation2 = Relationship.Get(sim.SimDescription, sim3.SimDescription, true);
                    if (relation2 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation2, LongTermRelationshipTypes.GoodFriend);
                    }

                    Relationship relation3 = Relationship.Get(sim.SimDescription, sim4.SimDescription, true);
                    if (relation3 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation3, LongTermRelationshipTypes.GoodFriend);
                    }








                    Relationship relation4 = Relationship.Get(sim2.SimDescription, sim3.SimDescription, true);
                    if (relation4 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation4, LongTermRelationshipTypes.GoodFriend);
                    }

                    Relationship relation5 = Relationship.Get(sim2.SimDescription, sim4.SimDescription, true);
                    if (relation5 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation5, LongTermRelationshipTypes.GoodFriend);
                    }









                    Relationship relation6 = Relationship.Get(sim3.SimDescription, sim.SimDescription, true);
                    if (relation6 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation6, LongTermRelationshipTypes.GoodFriend);
                    }

                    Relationship relation7 = Relationship.Get(sim3.SimDescription, sim2.SimDescription, true);
                    if (relation7 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation7, LongTermRelationshipTypes.GoodFriend);
                    }






                    Relationship relation8 = Relationship.Get(sim4.SimDescription, sim.SimDescription, true);
                    if (relation8 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation8, LongTermRelationshipTypes.GoodFriend);
                    }

                    Relationship relation9 = Relationship.Get(sim4.SimDescription, sim2.SimDescription, true);
                    if (relation9 != null)
                    {
                        NFinalizeDeath.ForceChangeState(relation9, LongTermRelationshipTypes.GoodFriend);
                    }




                }
                catch
                { }







                try
                {
                    if (sim.SimDescription != null && sim.SimDescription.Genealogy != null)
                    {
                        sim.SimDescription.Genealogy.AddChild(sim3.SimDescription.Genealogy);
                    }
                    if (sim2.SimDescription != null && sim2.SimDescription.Genealogy != null)
                    {
                        sim2.SimDescription.Genealogy.AddChild(sim3.SimDescription.Genealogy);
                    }
                }
                catch
                { }


                try
                {
                    if (sim.SimDescription != null && sim.SimDescription.Genealogy != null)
                    {
                        sim.SimDescription.Genealogy.AddChild(sim4.SimDescription.Genealogy);
                    }
                    if (sim2.SimDescription != null && sim2.SimDescription.Genealogy != null)
                    {
                        sim2.SimDescription.Genealogy.AddChild(sim4.SimDescription.Genealogy);
                    }
                }
                catch
                { }



                if (siml.Count > 0)
                {
                    bool checknullsim = false;
                    try
                    {
                        if (sim4 != null)
                        {
                            if (!noSetAA)
                                checknullsim = !PlumbBob.ForceSelectActor(sim4);
                            else checknullsim = false;
                        }
                        else
                        {
                            checknullsim = true;
                        }
                        sim2.SimDescription.Household.SetName(sim2.SimDescription.mLastName ?? "");
                    }
                    catch
                    { }
                    try
                    {
                        foreach (Sim sitem in siml)
                        {
                            if (sitem == null) continue;

                            try
                            {
                                if (checknullsim)
                                {
                                    PlumbBob.ForceSelectActor(sitem);
                                    checknullsim = false;
                                }
                                sitem.SimDescription.LastName = simlastnamehousehold;

                                sitem.SimDescription.Household.SetName(sim.SimDescription.mLastName ?? "");
                                try
                                {
                                    if (sitem.SimDescription.Child || sitem.SimDescription.Teen)
                                    {
                                        sitem.SimDescription.AssignSchool();
                                    }
                                    GlobalFunctions.PlaceAtGoodLocation(sitem, new World.FindGoodLocationParams(lot.Position), false);
                                }
                                catch
                                { }
                                try
                                {
                                    if (sitem.IsSelectable)
                                    {
                                        sitem.OnBecameSelectable();
                                    }
                                }
                                catch
                                { }

                            }
                            catch (Exception ex2)
                            {
                                NiecMod.Nra.NiecException.WriteLog("SetName Household" + " SetName: " + NiecMod.Nra.NiecException.NewLine + NiecMod.Nra.NiecException.LogException(ex2), true, true);
                            }
                            try
                            {
                                if (sitem.SimDescription.TraitManager.HasElement(TraitNames.Evil))
                                {
                                    sitem.SimDescription.TraitManager.RemoveElement(TraitNames.Evil);
                                    sitem.SimDescription.TraitManager.AddElement(TraitNames.Good);
                                }
                                sitem.AddInitialObjects(sitem.IsSelectable);
                            }
                            catch
                            { }
                        }
                    }
                    catch
                    { }
                }

                return lot.Household;
            }
            else if (lieast.Count == 0)
            {
                return null;
            }
            return null;
        }



        public static Vector3 GetPositionInRandomLot(Lot lot)
        {
            if (LotManager.sLots == null)
                return Vector3.Empty;
            List<Lot> lots = new List<Lot>(LotManager.sLots.Values);
            lots.Remove(lot);

            if (lot != null && lots.Count == 0)
            {
                lots.Add(lot);
            } 
            if (lots.Count == 0)
                return Vector3.OutOfWorld;
            try
            {
                return Service.GetPositionInRandomLot(RandomUtil.GetRandomObjectFromList(lots, ListCollon.SafeRandomPart2));
            }
            finally
            {
                lots.Clear();
            }
            
        }
        public static Vector3 AttemptToFindSafeLocation(Lot lot, bool isHorse)
        {
            if (lot == null) return Vector3.Invalid;

            if (isHorse)
            {
                Mailbox mailbox = lot.FindMailbox();
                if (mailbox != null)
                {
                    return mailbox.Position;
                }
                else
                {
                    Door frontDoor = lot.FindFrontDoor();
                    if (frontDoor != null)
                    {
                        int roomId = frontDoor.GetRoomIdOfDoorSide(CommonDoor.tSide.Front);
                        if (roomId != 0)
                        {
                            roomId = frontDoor.GetRoomIdOfDoorSide(CommonDoor.tSide.Back);
                        }

                        if (roomId == 0)
                        {
                            List<GameObject> objects = lot.GetObjectsInRoom<GameObject>(roomId);
                            if (objects.Count > 0)
                            {
                                return RandomUtil.GetRandomObjectFromList(objects).Position;
                            }
                        }
                    }
                }
            }

            return lot.EntryPoint();
        }
    }


}
