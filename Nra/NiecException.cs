
using System;
using System.Collections.Generic;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.Interactions;
using Sims3.SimIFace;
using Sims3.Gameplay.Utilities;
using System.Text;
using Sims3.UI;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Objects;
using Sims3.Gameplay.UI;
using Sims3.UI.Hud;
using Sims3.UI.CAS;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.ActorSystems;
using Sims3.NiecHelp.Tasks;
using Sims3.Gameplay.Controllers.Niec;

namespace NiecMod.Nra
{
    public static class NiecException
    {

        #region PrintMessage
        /// <summary>
        /// Print message on screen
        /// </summary>
        /// <param name="message"></param>
        public static void PrintMessage(string message)
        {
            StyledNotification.Show(new StyledNotification.Format(message, StyledNotification.NotificationStyle.kGameMessagePositive));
        }

        public static bool sAcceptCancelDialogWithoutCommonException(string message)
        {
            try
            {
                throw new NiecModException("AcceptCancelDialogWithoutCommonException: Not Error");
            }
            catch (ResetException)
            {
                throw;
            }
            catch (NiecModException ex)
            {
                WriteLog("AcceptCancelDialogWithoutCommonException: " + NiecException.NewLine + NiecException.LogException(ex), true, true, false);
            }
            return NFinalizeDeath.CheckAccept(message);
        }

        #endregion

        public static readonly string NewLine = System.Environment.NewLine;

        public static int sLogEnumerator = 0;

        public static InteractionInstance CreateInstance<INTERACTION>(ref InteractionInstanceParameters parameters) where INTERACTION : InteractionInstance
        {
            var instance = Activator.CreateInstance<INTERACTION>();
            instance.Init(ref parameters);
            return instance;
        }

        public static string GetCanvasSizeLocalizedString(string size)
        {
            return Localization.LocalizeString("Gameplay/Objects/HobbiesSkills/Easel/CanvasSize:" + size, new object[0]);
        }

        public static string LogException(Exception ex)
        {
            return ex.ToString() + NewLine;
        }

        public static void SendTextExceptionToDebugger(Exception ex)
        {
            if (ex == null)
            {
                niec_native_func.OutputDebugString("NMScript Exception Log\n" + "Exception is a NULL" + "\nEnd");
            }
            else niec_native_func.OutputDebugString("NMScript Exception Log\n" + ex.ToString() + "\nEnd");
        }

        public static void NewSendTextExceptionToDebugger()
        {
            try
            {
                throw new Exception("");
            }
            catch (Exception ex)
            {
                niec_native_func.OutputDebugString("NMScriptN Exception Log\n" + ex.stack_trace + "\nEnd");
            }
        }

        public static string ScriptError()
        {
            return "Script Error:" + NewLine;
        }

        public static bool WriteLog(string text)
        {
            return WriteLog(text, true, false);
        }

        public static bool WriteLog(string text, bool addHeader)
        {
            return WriteLog(text, addHeader, false);
        }

        public static bool WriteLog(string text, bool addHeader, bool scripterror)
        {
            return WriteLog(text, addHeader, scripterror, false);
        }

        public static bool WriteLog(string text, bool addHeader, bool scripterror, bool printmessage)
        {
            try
            {
                if (string.IsNullOrEmpty(text)) 
                    return false;

                niec_native_func.OutputDebugString("Start\nNiecMod Log: " + text + "\nEnd\n");

                if (addHeader)
                {
                    sLogEnumerator++;

                    try
                    {
                        if (printmessage)
                        {
                            PrintMessage("Write Log is Created");
                        }
                        else if (scripterror)
                        {
                            PrintMessage("NiecMod" + NewLine + "Script Error is Found No: " + sLogEnumerator);
                        }
                    }
                    catch (Exception)
                    { }

                    string[] labels = GameUtils.GetGenericString(GenericStringID.VersionLabels).Split(new char[] { '\n' });
                    string[] data = GameUtils.GetGenericString(GenericStringID.VersionData).Split(new char[] { '\n' });

                    string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + NewLine;
                    header += "<" + "NiecMod" + ">" + NewLine;
                    try
                    {
                        header += "<ModVersion value=\"" + "1.7.20" + "\"/>" + NewLine;
                    }
                    catch (Exception)
                    {
                        header += "<ModVersion value=\"" + "1.7.20" + "\"/>" + NewLine;
                    }
                    

                    int num2 = (labels.Length > data.Length) ? data.Length : labels.Length;
                    for (int j = 0x0; j < num2; j++)
                    {
                        string label = labels[j].Replace(":", "").Replace(" ", "");

                        switch (label)
                        {
                            case "BuildVersion":
                                header += "<" + label + " value=\"" + data[j] + "\"/>" + NewLine;
                                break;
                        }
                    }

                    IGameUtils utils = (IGameUtils)AppDomain.CurrentDomain.GetData("GameUtils");
                    if (utils != null)
                    {
                        ProductVersion version = (ProductVersion)utils.GetProductFlags();

                        header += "<Installed value=\"" + version + "\"/>" + NewLine;
                        
                        
                    }

                    header += "<Enumerator value=\"" + sLogEnumerator + "\"/>" + NewLine;
                    header += "<Content>" + NewLine;
                    if (scripterror)
                    {
                        header += ScriptError() + NewLine;
                    }
                    text = header + text.Replace("&", "&amp;");

                    text += NewLine + "</Content>";
                    text += NewLine + "</" + "NiecMod" + ">";
                }

                uint fileHandle = 0x0;
                string str = Simulator.CreateScriptErrorFile(ref fileHandle);
                if (fileHandle != 0x0)
                {
                    CustomXmlWriter xmlWriter = new CustomXmlWriter(fileHandle);

                    xmlWriter.WriteToBuffer(text);

                    xmlWriter.WriteEndDocument();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static string InteractionList(SimDescription simd)
        {
            string logText = null;
            Sim sim = simd.CreatedSim;
            logText += sim.Name + NewLine;
            if (sim.InteractionQueue != null)
            {
                logText += NewLine + "Interactions:";

                int index = 0;
                foreach (InteractionInstance instance in sim.InteractionQueue.InteractionList)
                {
                    if (instance == null)
                    {
                        logText += NewLine + "Empty Interaction";
                    }
                    else
                    {
                        InteractionInstanceParameters parameters = instance.GetInteractionParameters();

                        index++;

                        try
                        {
                            logText += NewLine + index + ": " + instance.GetInteractionName();
                        }
                        catch
                        {
                            logText += NewLine + index + ": error";
                        }

                        if (instance.InteractionDefinition != null)
                        {
                            logText += NewLine + instance.InteractionDefinition.GetType();
                            logText += NewLine + instance.InteractionDefinition;
                            logText += NewLine + instance.GetPriority().Level;
                        }
                        else
                        {
                            logText += NewLine + "Invalid Definition";
                        }
                    }
                }

                logText += NewLine;
            }
            return logText;
        }


        public static string InteractionListLitePro(SimDescription simd)
        {
            if (simd == null) return "SimDescription is Null.";
            string logText = "";
            try
            {
                
                Sim sim = simd.CreatedSim;
                if (sim != null && sim.InteractionQueue != null)
                {
                    logText += NewLine + "Interactions:";

                    int index = 0;
                    foreach (InteractionInstance instance in sim.InteractionQueue.InteractionList)
                    {
                        if (instance == null)
                        {
                            logText += NewLine + "Empty Interaction";
                        }
                        else
                        {
                            InteractionInstanceParameters parameters = instance.GetInteractionParameters();

                            index++;

                            try
                            {
                                logText += NewLine + index + ": " + instance.GetInteractionName();
                            }
                            catch
                            {
                                logText += NewLine + index + ": error";
                            }

                            if (instance.InteractionDefinition != null)
                            {
                                logText += NewLine + instance.InteractionDefinition.GetType();
                                logText += NewLine + instance.InteractionDefinition;
                                logText += NewLine + instance.GetPriority().Level;
                            }
                            else
                            {
                                logText += NewLine + "Invalid Definition";
                            }
                        }
                    }

                    logText += NewLine;
                }
            }
            catch (Exception ex)
            {
                logText += NewLine + "Error: " + NewLine + ex.ToString();
            }
            
            return logText;
        }

        public static Sim ActiveActor
        {
            get
            {
                try
                {
                    return Sim.ActiveActor;
                }
                catch
                {
                    return NFinalizeDeath.ActiveActor;
                }
            }
        }


        public static string WhereActiveHousehold(SimDescription desc)
        {
            if (desc == null) return string.Empty;
            try
            {

                if (desc.CreatedSim != null && desc.CreatedSim == ActiveActor && NFinalizeDeath.ActiveHousehold != null && NFinalizeDeath.ActiveHousehold.AllSimDescriptions.Contains(desc))
                {
                    return " : Active Actor And Active Household";
                }
                else if (desc.CreatedSim != null && desc.CreatedSim == NFinalizeDeath.ActiveActor)
                {
                    return " : Active Actor";
                }
                else if (desc.Household == NFinalizeDeath.ActiveHousehold)
                {
                    return " : Active Household";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception exx)
            { return NewLine + " Error Active Household:" + NewLine + exx.ToString() + NewLine; }
        }

#if unused
        public static string GetHouseholdInfo(Household household, bool notile, string msg)
        {
            string logText = null;
            if (household != null)
            {
                if (msg == null) msg = "";
                logText = "";
                if (!notile)
                    logText += "Household Name: " + household.Name + NewLine;
                //else 
                //    logText += msg + "Household: " + household.Name + NewLine;
                logText += msg + " Id: " + household.HouseholdId + NewLine;
                try
                {
                    logText += msg + " Has Been Destroyed: " + household.HasBeenDestroyed + NewLine;
                    logText += msg + " Bio: " + household.mBioText + NewLine;

                    logText += msg + " Family Funds: " + household.mFamilyFunds + NewLine;
                    logText += msg + " Delinquent Funds: " + household.mDelinquentFunds + NewLine;
                    logText += msg + " Inited: " + household.mbInited + NewLine;
                    logText += msg + " Ancient Coin Count: " + household.mAncientCoinCount + NewLine;
                    logText += msg + " UnPaid Bills: " + household.mUnpaidBills + NewLine;
                }
                catch
                { }

                //if (household == Household.ActiveHousehold || (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && household == PlumbBob.sSingleton.mSelectedActor.Household))
                //{
                //    logText += " Active Household:" + NewLine;
                //}
                /*
                if (household.IsServiceNpcHousehold || household.IsPetHousehold)
                {
                    logText += " Is Service NPC Household: " + (household == Household.sNpcHousehold) + NewLine;
                }
                if (household.IsTouristHousehold)
                {
                    logText += " Tourist" + NewLine;
                }*/

                try
                {
                    logText += msg + " Active Household: " + (household == Household.ActiveHousehold || (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && household == PlumbBob.sSingleton.mSelectedActor.Household)) + NewLine;
                }
                catch
                {
                    logText += msg + " Active Household: False" + NewLine;
                }
                logText += msg + " Servobot Household: " + (household == Household.sServobotHousehold) + NewLine;
                logText += msg + " Alien Household: " + (household == Household.sAlienHousehold) + NewLine;
                logText += msg + " Mermaid Household: " + (household == Household.sMermaidHousehold) + NewLine;
                logText += msg + " Previous Traveler Household: " + (household == Household.sPreviousTravelerHousehold) + NewLine;
                logText += msg + " Service NPC Household: " + (household == Household.sNpcHousehold) + NewLine;
                logText += msg + " Pet Household: " + (household == Household.sPetHousehold) + NewLine;
                logText += msg + " Tourist Household: " + (household == Household.sTouristHousehold) + NewLine;
                try
                {
                    logText += msg + " Members: " + household.NumMembers + NewLine;
                }
                catch
                { }
                Household.Members me = household.mMembers;
                if (me != null && me.mAllSimDescriptions != null)
                {
                    try
                    {
                        foreach (SimDescription sim2 in me.mAllSimDescriptions)
                        {
                            if (sim2 != null)
                            {
                                logText += msg + "  Member: " + sim2.FullName + ", Id: " + sim2.mSimDescriptionId + NewLine;
                            }
                        }
                    }
                    catch
                    { }
                }
                try
                {
                    if (household.VirtualLotHome != null)
                    {
                        logText += msg + " Virtual Home Lot: " + household.VirtualLotHome.Name + NewLine;
                        logText += msg + " Virtual Home Lot Id: " + household.mVirtualLotId + NewLine;
                        logText += msg + " Virtual Home Address: " + household.VirtualLotHome.Address + NewLine;
                    }
                    else
                    {
                        logText += msg + " No Virtual Lot Home" + NewLine;
                    }
                }
                catch
                { }
                if (household.LotHome != null)
                {
                    logText += msg + " Home Lot: " + household.LotHome.Name + NewLine;
                    logText += msg + " Home Lot Id: " + household.mLotId + NewLine;
                    logText += msg + " Home Address: " + household.LotHome.Address;//+ NewLine;
                }
                else
                {
                    logText += msg + " No Lot Home";// + NewLine;
                }
            }
            return logText;
        }
#endif

        public static string GetHouseholdInfo(Household household, bool notile, string msg)
        {
            string logText = null;
            if (household != null)
            {
                if (msg == null) msg = "";
                logText = "";

                if (!notile)
                    logText += "Household Name: " + household.Name + NewLine;

                logText += msg + " Id: " + household.HouseholdId + NewLine;
                try
                {
                    logText += msg + " Has Been Destroyed: " + household.HasBeenDestroyed + NewLine;

                    if (!string.IsNullOrEmpty(household.BioText))
                        logText += msg + " Bio: " + household.BioText + NewLine;

                    logText += msg + " Family Funds: " + EAText.GetMoneyString(household.mFamilyFunds) + NewLine;
                    logText += msg + " Delinquent Funds: " + EAText.GetMoneyString(household.mDelinquentFunds) + NewLine;
                    logText += msg + " Inited: " + household.mbInited + NewLine;
                    logText += msg + " Ancient Coin Count: " + EAText.GetMoneyString(household.mAncientCoinCount) + NewLine;
                    logText += msg + " UnPaid Bills: " + EAText.GetMoneyString(household.mUnpaidBills) + NewLine;
                    try
                    {
                        if (household.mMoneySaved != null)
                        {
                            long it = 0;
                            foreach (var item in household.mMoneySaved)
                                it += item;
                            logText += msg + " Money Saved: " + EAText.GetMoneyString(it) + ", Length: " + household.mMoneySaved.Length + NewLine;
                        }
                    }
                    catch (ResetException)
                    { throw; }
                    catch
                    { }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { }

                logText += msg + " -----------------------------------------------" + NewLine;
                try
                {
                    logText += msg + "  Active Household: " + (household == Household.ActiveHousehold || (PlumbBob.sSingleton != null && PlumbBob.sSingleton.mSelectedActor != null && household == PlumbBob.sSingleton.mSelectedActor.Household)) + NewLine;
                }
                catch (ResetException)
                {

                    throw;
                }
                catch
                {
                    logText += msg + "  Active Household: False" + NewLine;
                }

                logText += msg + "  Servobot Household: " + (household == Household.sServobotHousehold) + NewLine;
                logText += msg + "  Alien Household: " + (household == Household.sAlienHousehold) + NewLine;
                logText += msg + "  Mermaid Household: " + (household == Household.sMermaidHousehold) + NewLine;
                logText += msg + "  Previous Traveler Household: " + (household == Household.sPreviousTravelerHousehold) + NewLine;
                logText += msg + "  Service NPC Household: " + (household == Household.sNpcHousehold) + NewLine;
                logText += msg + "  Pet Household: " + (household == Household.sPetHousehold) + NewLine;
                logText += msg + "  Tourist Household: " + (household == Household.sTouristHousehold) + NewLine;
                logText += msg + " -----------------------------------------------" + NewLine;
                Household.Members me = household.mMembers;
                if (me != null)
                {
                    try
                    {
                        logText += msg + " Members: " + household.NumMembers + NewLine;
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    { }
                }
                if (me != null && me.mAllSimDescriptions != null)
                {
                    try
                    {
                        foreach (SimDescription sim2 in me.mAllSimDescriptions)
                        {
                            if (sim2 != null)
                            {
                                logText += msg + "  Member: (" + sim2.FullName + ", Id: " + sim2.mSimDescriptionId + ")" + NewLine;
                            }
                            else logText += msg + "  Member: (NULL)" + NewLine;
                        }
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    { }
                }
                try
                {
                    if (household.VirtualLotHome != null)
                    {

                        logText += msg + " Virtual Home Lot: " + (string.IsNullOrEmpty(household.VirtualLotHome.Name) ? "No Name" : household.VirtualLotHome.Name) + NewLine;
                        logText += msg + " Virtual Home Lot Id: " + household.mVirtualLotId + NewLine;
                        logText += msg + " Virtual Home Address: " + (string.IsNullOrEmpty(household.VirtualLotHome.Address) ? "No Address" : household.VirtualLotHome.Address) + NewLine;
                    }
                    else
                    {
                        logText += msg + " No Virtual Lot Home" + NewLine;
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { }
                try
                {
                    if (household.LotHome != null)
                    {
                        logText += msg + " Home Lot: " + (string.IsNullOrEmpty(household.LotHome.Name) ? "No Name" : household.LotHome.Name) + NewLine;
                        logText += msg + " Home Lot Id: " + household.mLotId + NewLine;
                        logText += msg + " Home Address: " + (string.IsNullOrEmpty(household.LotHome.Address) ? "No Address" : household.LotHome.Address);//+ NewLine;
                    }
                    else
                    {
                        logText += msg + " No Lot Home";
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch
                { }

            }
            return logText;
        }

        public static
        void PrintMessagePro(string Message, bool NoNiecModText, float TimeOut) // Bypass if (Responder.Instance.TutorialModel.IsTutorialRunning())
        {
            try
            {

                niec_native_func.OutputDebugString("NMPrint: " + Message);

                if (NotificationManager.sNotificationManager == null)
                    return;
                StyledNotification.Format format = 
                    (!NoNiecModText) ? new StyledNotification.Format("NiecMod\n" + (Message == "" ? "No Message" : Message ?? "No Message"), StyledNotification.NotificationStyle.kGameMessagePositive) 
                    : new StyledNotification.Format((Message == "" ? "No Message" : Message ?? "No Message"), StyledNotification.NotificationStyle.kGameMessagePositive);

                format.mConnectionType = StyledNotification.ConnectionType.kSpeech;
                format.mTNSCategory = 
                    Instantiator.RootIsOpenDGSInstalled ? 
                        NotificationManager.TNSCategory.Information 
                    : NotificationManager.TNSCategory.Store;


                StyledNotification styledNotification = new StyledNotification(format, TimeOut, null, null, ProductVersion.BaseGame, ProductVersion.BaseGame);
                NFinalizeDeath.StyledNotification__Add(NotificationManager.sNotificationManager, styledNotification, format.mTNSCategory);
            }
            catch
            { }
        }

        public static string GetDescriptionPro(IMiniSimDescription obj)
        {
            if (obj == null)
            {
                return null;
            }
            else
            {
                string logText = null;

                if (obj is MiniSimDescription)
                    logText += NewLine + "MiniSimDescription:" + NewLine;
                else
                    logText += NewLine + "SimDescription:" + NewLine;
                logText += NewLine + " Name: " + obj.FullName;
                if ((obj is MiniSimDescription) && obj.Age == Sims3.SimIFace.CAS.CASAgeGenderFlags.None && obj.Gender == Sims3.SimIFace.CAS.CASAgeGenderFlags.None)
                {
                    try
                    {
                        logText += NewLine + " SchoolName: " + (obj as MiniSimDescription).SchoolName;
                        logText += NewLine + " JobName: " + (obj as MiniSimDescription).JobOrServiceName;
                        logText += NewLine + " PartnerId: " + (obj as MiniSimDescription).PartnerId;
                        logText += NewLine + " SchoolName: " + (obj as MiniSimDescription).JobIcon;
                        logText += NewLine + " SchoolIconName: " + (obj as MiniSimDescription).SchoolIconName;
                    }
                    catch
                    { }

                }
                else
                {
                    logText += NewLine + " Age: " + obj.Age;
                    logText += NewLine + " Gender: " + obj.Gender;
                }
                if (obj is MiniSimDescription)
                    logText += NewLine + " MiniSimDescriptionId: " + obj.SimDescriptionId;
                else
                    logText += NewLine + " SimDescriptionId: " + obj.SimDescriptionId;
                logText += NewLine + " LotHomeId: " + obj.LotHomeId;
                logText += NewLine + " HomeWorld: " + obj.HomeWorld;

                Genealogy genealogy = obj.CASGenealogy as Genealogy;
                if (genealogy != null)
                {
                    if ((genealogy.mSim != null) || (genealogy.mMiniSim != null))
                    {
                        logText += NewLine + " Proper Genealogy";
                    }
                    else
                    {
                        logText += NewLine + " Broken Genealogy";
                    }
                }
                else
                {
                    logText += NewLine + " No Genealogy";
                }

                if (obj.IsDead)
                {
                    logText += NewLine + " Dead";
                }

                if (obj.IsPregnant)
                {
                    logText += NewLine + " Pregnant";
                }

                SimDescription desc = obj as SimDescription;
                if (desc != null)
                {
                    logText += NewLine + " Valid: " + desc.IsValidDescription;

                    logText += NewLine + " CreatedSim: " + (desc.CreatedSim != null);

                    if (desc.Bio != null && desc.Bio.Length < 190)
                        logText += NewLine + " Bio: " + desc.Bio;

                    logText += NewLine + " Species: " + desc.Species;
                    logText += string.Format("\n Flag: {0}", desc.mFlags);
                    logText += NewLine + " Year: " + desc.AgingYearsSinceLastAgeTransition;
                    if (desc.Household != null)
                    {
                        logText += NewLine + " Household: " + desc.Household.Name;
                    }
                    else
                    {
                        logText += NewLine + " No Household";
                    }

                    if ((desc.CreatedByService != null) && (desc.CreatedByService.IsSimDescriptionInPool(desc)))
                    {
                        logText += NewLine + " Service: " + desc.CreatedByService.ServiceType;
                    }

                    if (desc.AssignedRole != null)
                    {
                        logText += NewLine + " Role: " + desc.AssignedRole.Type;
                    }

                    if (desc.OccultManager != null)
                    {
                        logText += NewLine + " Occult: " + desc.OccultManager.CurrentOccultTypes;
                    }
                    else
                    {
                        logText += NewLine + " No OccultManager";
                    }

                    logText += NewLine + " Alien: " + desc.AlienDNAPercentage;

                    try
                    {
                        if (desc.Occupation != null)
                        {
                            logText += NewLine + " Career: " + desc.Occupation.CareerName + " (" + desc.Occupation.CareerLevel + ")";
                        }
                        else
                        {
                            logText += NewLine + " Career: <Unemployed>";
                        }
                    }
                    catch
                    { }

                    try
                    {
                        if ((desc.CareerManager != null) && (desc.CareerManager.School != null))
                        {
                            logText += NewLine + " School: " + desc.CareerManager.School.CareerName + " (" + desc.CareerManager.School.CareerLevel + ")";
                        }
                        else
                        {
                            logText += NewLine + " School: <None>";
                        }
                    }
                    catch
                    { }

                    if (desc.LotHome != null)
                    {
                        logText += NewLine + " Lot: " + desc.LotHome.Name;
                        logText += NewLine + " Address: " + desc.LotHome.Address;
                    }

                    try
                    {
                        if (desc.SkillManager != null)
                        {
                            foreach (Skill skill in desc.SkillManager.List)
                            {
                                if (skill == null) continue;

                                string name = skill.Guid.ToString();

                                try
                                {
                                    name = skill.Name;
                                }
                                catch
                                { }

                                logText += NewLine + " Skill " + name + ": " + skill.SkillLevel;
                            }
                        }

                        if (desc.TraitManager != null)
                        {
                            foreach (Trait trait in desc.TraitManager.List)
                            {
                                if (trait == null) continue;

                                string name = trait.Guid.ToString();
                                try
                                {
                                    name = trait.TraitName(desc.IsFemale);
                                }
                                catch
                                { }

                                logText += NewLine + " Trait " + name;
                            }
                        }
                    }
                    catch
                    { }

                }

                return logText;
            }
        }

        public static string GetDescription(IMiniSimDescription obj)
        {
            if (obj == null)
            {
                return "IMiniSimDescription Is Null";
            }
            else
            {
                string logText = null;

                logText += NewLine + "SimDescription:" + NewLine;
                logText += NewLine + " Name: " + obj.FullName;
                logText += NewLine + " Age: " + obj.Age;
                logText += NewLine + " Gender: " + obj.Gender;
                logText += NewLine + " SimDescriptionId: " + obj.SimDescriptionId;
                logText += NewLine + " LotHomeId: " + obj.LotHomeId;
                logText += NewLine + " HomeWorld: " + obj.HomeWorld;


                




                Genealogy genealogy = obj.CASGenealogy as Genealogy;
                if (genealogy != null)
                {
                    if ((genealogy.mSim != null) || (genealogy.mMiniSim != null))
                    {
                        logText += NewLine + " Proper Genealogy";
                    }
                    else
                    {
                        logText += NewLine + " Broken Genealogy";
                    }
                }
                else
                {
                    logText += NewLine + " No Genealogy";
                }

                if (obj.IsDead)
                {
                    logText += NewLine + " Dead";
                }

                if (obj.IsPregnant)
                {
                    logText += NewLine + " Pregnant";
                }

                SimDescription desc = obj as SimDescription;
                if (desc != null)
                {
                    logText += NewLine + " Valid: " + desc.IsValidDescription;


                    logText += NewLine + " CreatedSim: " + (desc.CreatedSim != null);

                    logText += NewLine + " Species: " + desc.Species;

                    if (desc.Household != null)
                    {
                        logText += NewLine + " Household: " + desc.Household.Name + WhereActiveHousehold(desc);
                    }
                    else
                    {
                        logText += NewLine + " No Household";
                    }

                    if ((desc.CreatedByService != null) && (desc.CreatedByService.IsSimDescriptionInPool(desc)))
                    {
                        logText += NewLine + " Service: " + desc.CreatedByService.ServiceType;
                    }

                    if (desc.AssignedRole != null)
                    {
                        logText += NewLine + " Role: " + desc.AssignedRole.Type;
                    }

                    if (desc.OccultManager != null)
                    {
                        logText += NewLine + " Occult: " + desc.OccultManager.CurrentOccultTypes;
                    }
                    else
                    {
                        logText += NewLine + " No OccultManager";
                    }

                    logText += NewLine + " Alien: " + desc.AlienDNAPercentage;

                    try
                    {
                        if (desc.Occupation != null)
                        {
                            logText += NewLine + " Career: " + desc.Occupation.CareerName + " (" + desc.Occupation.CareerLevel + ")";
                        }
                        else
                        {
                            logText += NewLine + " Career: <Unemployed>";
                        }
                    }
                    catch
                    { }

                    try
                    {
                        if ((desc.CareerManager != null) && (desc.CareerManager.School != null))
                        {
                            logText += NewLine + " School: " + desc.CareerManager.School.CareerName + " (" + desc.CareerManager.School.CareerLevel + ")";
                        }
                        else
                        {
                            logText += NewLine + " School: <None>";
                        }
                    }
                    catch
                    { }

                    if (desc.LotHome != null)
                    {
                        logText += NewLine + " Lot: " + desc.LotHome.Name;
                        logText += NewLine + " Address: " + desc.LotHome.Address;
                    }
                    try
                    {
                        if (desc.SkillManager != null)
                        {
                            foreach (Skill skill in desc.SkillManager.List)
                            {
                                if (skill == null) continue;

                                string name = skill.Guid.ToString();

                                try
                                {
                                    name = skill.Name;
                                }
                                catch
                                { }

                                logText += NewLine + " Skill " + name + ": " + skill.SkillLevel;
                            }
                        }
                    }
                    catch
                    {}

                    try
                    {
                        if (desc.TraitManager != null)
                        {
                            foreach (Trait trait in desc.TraitManager.List)
                            {
                                if (trait == null) continue;

                                string name = trait.Guid.ToString();
                                try
                                {
                                    name = trait.TraitName(desc.IsFemale);
                                }
                                catch
                                { }

                                logText += NewLine + " Trait " + name;
                            }
                        }
                    }
                    catch
                    {}
                    
                }

                return logText;
            }
        }
    }
}