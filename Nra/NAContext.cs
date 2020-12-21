using System;
using System.Collections.Generic;
using System.Text;

namespace NiecMod.Nra
{
    public class NAContext
    {
        public static string GetOthersModError()
        {
            return @"Let's decompile Other mods ;)

Decompiling Other Mods :)

Make mod's code decompiled 

Compile to Other Mods :) Fixed Bug


Source: Oniki_KinkyMod
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00031 ldfld.o    in Oniki.Services.Oniki.Services.KWServices:OnDestroyService (Sims3.Gameplay.Services.Service) ([35F8A6C8] )
#1: 0x00018 call       in Oniki.Services.Oniki.Services.KWFakeMetaAutonomy:.ctor () ()
#2: 0x00007 newobj     in Oniki.Services.Oniki.Services.KWFakeMetaAutonomy:Start () ()
#3: 0x00139 call       in Oniki.Oniki.Main:Start () ()
#4: 0x0014a call       in Oniki.Oniki.KinkyMod:OnWorldLoadFinishedHandler (object,System.EventArgs) ([35E58720] [46E27480] )

Source: NRaasMasterController
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00138 ret.void   in NRaas.CommonSpace.Helpers.DreamCatcher+DreamStore:.ctor (Sims3.Gameplay.Actors.Sim,bool,bool) (699EF0E0 [68FE1800] [1] [1] )
#1: 0x00020 newobj     in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.DreamCatcher:StoreAllDreams () ()
#2: 0x00000 call       in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.DreamCatcher:OnWorldLoadFinishedDreams () ()
#3: 0x00000 call       in NRaas.NRaas.MasterController:OnWorldLoadFinished () ()
#4: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )


Source: NRaasGoHere
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x000af brfalse.i4.s in NRaas.Common+DerivativeSearch:FindOfType (System.Type,NRaas.Common/DerivativeSearch/Caching,NRaas.Common/DerivativeSearch/Scope) ([3661A2C0] [0] [0] )
#1: 0x00010 call       in NRaas.Common+DerivativeSearch:Find (NRaas.Common/DerivativeSearch/Caching,NRaas.Common/DerivativeSearch/Scope) ([0] [0] )
#2: 0x00002 call       in NRaas.Common+DerivativeSearch:Find () ()
#3: 0x00017 call       in NRaas.NRaas.Common:OnStartupApp (object,System.EventArgs) ([37B05FB0] [49732EC0] )

Source: CCLoader
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00038 brfalse.i4.s in CCL.CCL.CCLoader:ParseData () ()
#1: 0x00017 call       in CCL.CCL.CCLoader:OnWorldLoadStarted (object,System.EventArgs) ([37B05FB0] [3723C258] )
#2: 0x00000            in System.System.EventHandler:Invoke (object,System.EventArgs) (35B4A000 [37B05FB0] [3723C258] )
#3: 0x00013 callvirt   in Sims3.SimIFace.Sims3.SimIFace.World:OnWorldLoadStarted () ()

Source: RoommatesFix
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00049 stloc.o    in LeapsForCauchy.LeapsForCauchy.RoommatesFix:NewRoommateValidation () ()
#1: 0x00000            in NiecMod.Nra.NFinalizeDeath+Function:Invoke () ()
#2: 0x0025c callvirt   in NiecMod.Nra.NiecMod.Nra.NFinalizeDeath:SimulateAlarm (Sims3.Gameplay.Utilities.AlarmManager,bool,bool,bool) ([46A0AD70] [1] [1] [0] )
#3: 0x00220 call       in NRaas.NRaas.ErrorTrap:OnScriptError (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#4: 0x00000            in ScriptCore.ExceptionTrap+ScriptError:Invoke (ScriptCore.ScriptProxy,System.Exception) (3837A3C0 [3615AD98] [00000000] )
#5: 0x00014 ldc.i4.1   in ScriptCore.ScriptCore.ExceptionTrap:Exception (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#6: 0x00007 brfalse.i4.s in ScriptCore.ScriptCore.ScriptProxy:OnScriptError (System.Exception) (3615AD98 [00000000] )
#7: 0x00081 brtrue.i4.s in ScriptCore.ScriptCore.ScriptProxy:Simulate () ()

Source: NRaasWoohooer
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00029 ldthis     in NRaas.WoohooerSpace.Interactions.NRaas.WoohooerSpace.Interactions.HaveBabyHospitalEx:Cleanup () ()
#1: 0x00077 callvirt   in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.InteractionQueue:CleanupInteraction (Sims3.Gameplay.Interactions.InteractionInstance,bool,bool) (46B49708 [7F1A60E0] [1] [1] )
#2: 0x000a9 call       in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.InteractionQueue:RemoveInteraction (int,bool,bool) (46B49708 [0] [1] [1] )
#3: 0x0002b call       in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.InteractionQueue:ImmediatelyStopInteraction (ulong) (46B49708 [91788/0x1668c] )
#4: 0x00070 call       in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.InteractionQueue:OnReset () ()
#5: 0x00008 call       in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.InteractionQueue:Dispose (bool) (46B49708 [1] )
#6: 0x00002 call       in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.InteractionQueue:Finalize () ()

Source: cmarXmods.PregnancyController
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x0000c brfalse.i4.s in cmarXmods.cmarXmods.PregControl:isValid (Sims3.Gameplay.Actors.Sim) ([68FE1800] )
#1: 0x00008 call       in cmarXmods.cmarXmods.PregControl:AddInteractions (Sims3.Gameplay.Actors.Sim) ([68FE1800] )
#2: 0x00014 call       in cmarXmods.cmarXmods.PregControl:OnWorldLoadFinishedHandler (object,System.EventArgs) ([35E58720] [46E27480] )

Source: Motives
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x0000c brfalse.i4.s in S3_Passion.Motives.S3_Passion.Motives.ModLoader:AddSimInteractions (Sims3.Gameplay.Actors.Sim) ([68FE1800] )
#1: 0x0001e call       in S3_Passion.Motives.S3_Passion.Motives.ModLoader:OnWorldLoadFinishedHandler (object,System.EventArgs) ([35E58720] [46E27480] )


Source: NRaasRegister
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00025 ldfld.o    in NRaas.NRaas.Register:StoreRoles () ()
#1: 0x00006 call       in NRaas.NRaas.Register:OnWorldLoadFinished () ()
#2: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )


Source: NRaasSelector
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00176 ret.void   in NRaas.CommonSpace.Helpers.DreamCatcher+DreamStore:.ctor (Sims3.Gameplay.Actors.Sim,bool,bool) (3749B8A0 [68FE1800] [1] [1] )
#1: 0x00025 newobj     in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.DreamCatcher:StoreAllDreams () ()
#2: 0x00000 call       in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.DreamCatcher:OnWorldLoadFinishedDreams () ()
#3: 0x00000 call       in NRaas.NRaas.Selector:OnWorldLoadFinished () ()
#4: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )


Source: TwoBTech.Mods.Commons
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x0000c ret        in TwoBTech.Mods.Commons.Managers.AbstractManager+<>c__DisplayClass1`1:<FindClasses>b__0 (System.Reflection.Assembly) (355274C0 [00000000] )
#1: 0x00000            in System.System.Predicate`1:Invoke (System.Reflection.Assembly) (466D6D70 [00000000] )
#2: 0x00034 callvirt   in System.System.Array:FindAll (System.Reflection.Assembly[],System.Predicate`1) ([4643F990] [488334896518753648/0x6c6ea00466d6d70] )
#3: 0x00008 call       in System.System.ArrayExtensions:FindAll (System.Reflection.Assembly[],System.Predicate`1) ([4643F990] [3934186745782693232/0x36990a00466d6d70] )
#4: 0x00020 call       in TwoBTech.Mods.Commons.Managers.TwoBTech.Mods.Commons.Managers.AbstractManager:FindClasses () ()
#5: 0x0000f call       in TwoBTech.Mods.Commons.Managers.TwoBTech.Mods.Commons.Managers.InteractionManager:OnPreload () ()

Source: TwoBTech.Mods.MoarInteractions
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00071 ldfld.o    in TwoBTech.Mods.MoarInteractions.Services.Socializing.TwoBTech.Mods.MoarInteractions.Services.Socializing.Socialize:IsEitherSocializingAlready (Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Interactions.InteractionDefinition) ([72333800] [378AE000] [371A0D60] )
#1: 0x0002c call       in TwoBTech.Mods.MoarInteractions.Services.Socializing.Socialize+Definition:Test (Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Actors.Sim,bool,Sims3.SimIFace.GreyedOutTooltipCallback&) (371A0D60 [72333800] [378AE000] [1] [6538249C] )
#2: 0x0014b callvirt   in Sims3.Gameplay.Interactions.Sims3.Gameplay.Interactions.InteractionDefinition`3:Test (Sims3.Gameplay.Interactions.InteractionInstanceParameters&,Sims3.SimIFace.GreyedOutTooltipCallback&) (371A0D60 [vt:65382464] [6538249C] )
#3: 0x00009 call       in TwoBTech.Mods.MoarInteractions.Services.Socializing.Socialize+Definition:Test (Sims3.Gameplay.Interactions.InteractionInstanceParameters&,Sims3.SimIFace.GreyedOutTooltipCallback&) (371A0D60 [vt:65382464] [6538249C] )
#4: 0x0004a callvirt   in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.InteractionObjectPair:TestAndCalculateScore (Sims3.Gameplay.Autonomy.Autonomy,Sims3.Gameplay.Autonomy.AutonomySearchType,Sims3.Gameplay.Interactions.InteractionFlags) (88D3F408 [667F7000] [1] [1] )
#5: 0x0000b callvirt   in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:CalculateScore (Sims3.Gameplay.Autonomy.InteractionObjectPair) (667F7000 [88D3F408] )
#6: 0x0001a call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:CalculateScoreAndAddToCandidates (Sims3.Gameplay.Autonomy.InteractionObjectPair) (667F7000 [88D3F408] )
#7: 0x00022 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:ScoreInteractionsForCommodity (Sims3.Gameplay.Autonomy.CommodityInteractionMap,Sims3.Gameplay.Autonomy.CommodityKind) (667F7000 [88EF0E28] [17774816] )
#8: 0x00083 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:ScoreInteractions (Sims3.Gameplay.Autonomy.CommodityInteractionMap) (667F7000 [88EF0E28] )
#9: 0x00010 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:ScoreInteractions (Sims3.Gameplay.Autonomy.CommodityInteractionMap,Sims3.Gameplay.Autonomy.CommodityKind) (667F7000 [88EF0E28] [0] )
#10: 0x0006a call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:ScoreInteractionsForLocalAutonomy (Sims3.Gameplay.Autonomy.CommodityKind) (667F7000 [0] )
#11: 0x00019 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:ScoreInteractionsOnObjects (Sims3.Gameplay.Autonomy.CommodityKind,bool) (667F7000 [0] [1] )
#12: 0x000c7 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:RunAutonomy (Sims3.Gameplay.Autonomy.CommodityKind,bool) (667F7000 [0] [1] )
#13: 0x00021 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:RunAutonomy (bool) (667F7000 [1] )
#14: 0x00002 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:TryFindBestAction () ()
#15: 0x0007b callvirt   in Veitc.ForceRunAuto.Veitc.ForceRunAuto._Main:ForceRunAutoOnlyAH () ()
#16: 0x00000            in Veitc.ForceRunAuto.Comman+FuncTask_Function:Invoke () ()
#17: 0x0002b leave.s    in Veitc.ForceRunAuto.Comman+FuncTask:Simulate () ()

Source: AweCore
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00037 ceq0.i4    in Awesome.StoryBus.Awesome.StoryBus.Core:IsSacred (Sims3.Gameplay.CAS.Household) ([52790E00] )
#1: 0x0001a call       in Awesome.MapTags.Awesome.MapTags.Manager:ShouldTrackLot (Sims3.Gameplay.Core.Lot) ([37E5E2A8] )
#2: 0x00016 call       in Awesome.MapTags.Awesome.MapTags.Manager:AddAwesomeMapTags (System.Collections.Generic.List`1) ([1243521624/0x4a1ea258] )
#3: 0x000b6 call       in Sims3.Gameplay.Sims3.Gameplay.GameEntryMaptagManager:GetCurrentMapTags () ()
#4: 0x0000a callvirt   in Sims3.Gameplay.MapTags.Sims3.Gameplay.MapTags.MapTagsModel:GetCurrentMapTags () ()
#5: 0x00024 callvirt   in NRaas.NRaas.Tagger:InitTags (bool) ([0] )
#6: 0x00053 call       in NRaas.NRaas.Tagger:SetupMapTags (bool,bool) ([0] [0] )
#7: 0x00005 call       in NRaas.NRaas.Tagger:SetupMapTags (bool) ([0] )
#8: 0x00005 call       in NRaas.NRaas.Tagger:OnRefreshed (object,System.EventArgs) ([4874A560] [361AB8C0] )
#9: 0x00000            in System.System.EventHandler:Invoke (object,System.EventArgs) (494878C0 [4874A560] [361AB8C0] )
#10: 0x0000b callvirt   in Sims3.Gameplay.MapTags.Sims3.Gameplay.MapTags.MapTagsModel:FireMapTagRefreshAll () ()
#11: 0x00008 callvirt   in Sims3.Gameplay.Sims3.Gameplay.GameEntryMaptagManager:RefreshMaptags () ()
#12: 0x00002 callvirt   in Sims3.Gameplay.Sims3.Gameplay.EditTownModel:RefreshMaptags () ()
#13: 0x00003 callvirt   in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownMaptagController:ResetMaptags () ()
#14: 0x00005 call       in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownMaptagController:OnItemSelected (Sims3.UI.GameEntry.UIBinInfo,Sims3.UI.GameEntry.InfoSource) (5234DC60 [00000000] [0] )
#15: 0x00000            in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownItemSelection:Invoke (Sims3.UI.GameEntry.UIBinInfo,Sims3.UI.GameEntry.InfoSource) (66B44280 [00000000] [0] )
#16: 0x00015 callvirt   in Sims3.Gameplay.Sims3.Gameplay.EditTownModel:SetCurrentSelection (Sims3.UI.GameEntry.UIBinInfo,Sims3.UI.GameEntry.InfoSource) (360791E0 [00000000] [0] )
#17: 0x0009c callvirt   in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownTool:SelectTool (bool) (5290EA38 [0] )
#18: 0x00013 callvirt   in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownTool:set_CurrentTool (Sims3.UI.GameEntry.EditTownTool) ([00000000] )
#19: 0x00020 call       in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownController:Dispose (bool) (BC206318 [0] )
#20: 0x00002 call       in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownController:Dispose () ()
#21: 0x00008 callvirt   in Sims3.UI.GameEntry.Sims3.UI.GameEntry.EditTownController:Unload () ()
#22: 0x00003 call       in Sims3.Gameplay.Sims3.Gameplay.EditTownState:Shutdown () ()
#23: 0x00012 callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:ShutdownCurState () ()
#24: 0x0000a call       in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:SetState (Sims3.SimIFace.StateMachineState) (480E5680 [49087C78] )
#25: 0x0009a callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Update (single) (36079F60 [0] )
#26: 0x00017 callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Simulate () ()

Source: AweCore
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x0003f stloc.np.o in Awesome.Schtick.Awesome.Schtick.Brynne:SmellsLikePee (Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Autonomy.ReactionBroadcaster) ([8502D000] [83608E40] )
#1: 0x0004f call       in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.BuffSmelly:OnEnterBroadcastCallback (Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Autonomy.ReactionBroadcaster) ([8502D000] [83608E40] )
#2: 0x00000            in Sims3.Gameplay.Autonomy.ReactionBroadcaster+BroadcastCallback:Invoke (Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Autonomy.ReactionBroadcaster) (68F41E60 [8502D000] [83608E40] )
#3: 0x00012 callvirt   in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.ReactionBroadcaster:CallOnEnterCallback (Sims3.Gameplay.Actors.Sim) (83608E40 [8502D000] )
#4: 0x00140 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.ReactionBroadcaster:PulseSims (single,bool) (83608E40 [5] [1] )
#5: 0x00062 call       in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.ReactionBroadcaster:Simulate (single,bool) (83608E40 [0.265625] [1] )
#6: 0x00076 callvirt   in Sims3.Gameplay.Core.Sims3.Gameplay.Core.Lot:UpdateReactions (single,bool) (37E5E2A8 [0.265625] [1] )
#7: 0x00278 callvirt   in NRaas.NRaas.ErrorTrap:OnScriptError (ScriptCore.ScriptProxy,System.Exception) ([46713A78] [00000000] )
#8: 0x00000            in ScriptCore.ExceptionTrap+ScriptError:Invoke (ScriptCore.ScriptProxy,System.Exception) (3837A3C0 [46713A78] [00000000] )
#9: 0x00014 ldc.i4.1   in ScriptCore.ScriptCore.ExceptionTrap:Exception (ScriptCore.ScriptProxy,System.Exception) ([46713A78] [00000000] )
#10: 0x00007 brfalse.i4.s in ScriptCore.ScriptCore.ScriptProxy:OnScriptError (System.Exception) (46713A78 [00000000] )
#11: 0x00081 brtrue.i4.s in ScriptCore.ScriptCore.ScriptProxy:Simulate () ()

Source: AweCore
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00042 ldarg.o    in Awesome.Aging.Awesome.Aging.Controllers:UpdatePregTimer (Sims3.Gameplay.ActorSystems.Pregnancy) ([0FD5EC00] )
#1: 0x00001 call       in Sims3.Gameplay.ActorSystems.Sims3.Gameplay.ActorSystems.Pregnancy:HourlyCallback () ()
#2: 0x00000            in NiecMod.Nra.NFinalizeDeath+Function:Invoke () ()
#3: 0x00248 callvirt   in NiecMod.Nra.NiecMod.Nra.NFinalizeDeath:SimulateAlarm (Sims3.Gameplay.Utilities.AlarmManager,bool,bool,bool) ([46A0AD70] [1] [1] [0] )
#4: 0x00220 call       in NRaas.NRaas.ErrorTrap:OnScriptError (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#5: 0x00000            in ScriptCore.ExceptionTrap+ScriptError:Invoke (ScriptCore.ScriptProxy,System.Exception) (3837A3C0 [3615AD98] [00000000] )
#6: 0x00014 ldc.i4.1   in ScriptCore.ScriptCore.ExceptionTrap:Exception (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#7: 0x00007 brfalse.i4.s in ScriptCore.ScriptCore.ScriptProxy:OnScriptError (System.Exception) (3615AD98 [00000000] )
#8: 0x00081 brtrue.i4.s in ScriptCore.ScriptCore.ScriptProxy:Simulate () ()

Source: AweCore
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00084 brfalse.i4.s in Awesome.Awesome.Motivator:Update (Sims3.Gameplay.Autonomy.Autonomy) ([37D68380] )
#1: 0x00003 ret.void   in Sims3.Gameplay.Autonomy.Sims3.Gameplay.Autonomy.Autonomy:Update () ()
#2: 0x00294 ldthis     in Sims3.Gameplay.Actors.Sims3.Gameplay.Actors.SimUpdate:Simulate () ()
#3: 0x000d1 leave.s    in ScriptCore.ScriptCore.ScriptProxy:Simulate () ()

Source: TwoBTech.Mods.MoarInteractions
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00045 brfalse.i4.s in TwoBTech.Mods.MoarInteractions.Services.CarpoolDisabler.TwoBTech.Mods.MoarInteractions.Services.CarpoolDisabler.Manager:OnSimSelected (Sims3.Gameplay.EventSystem.Event) (36BAC500 [69753798] )
#1: 0x00000            in TwoBTech.Mods.Commons.Delegates.TwoBTech.Mods.Commons.Delegates.VoidEventDelegate:Invoke (Sims3.Gameplay.EventSystem.Event) (36BAC488 [69753798] )
#2: 0x00000            in TwoBTech.Mods.Commons.Delegates.TwoBTech.Mods.Commons.Delegates.VoidEventDelegate:Invoke (Sims3.Gameplay.EventSystem.Event) (893159D8 [69753798] )
#3: 0x00025 callvirt   in TwoBTech.Mods.Commons.Managers.TwoBTech.Mods.Commons.Managers.InformationBroker:OnAnyEvent (Sims3.Gameplay.EventSystem.Event) (36BAC708 [69753798] )
#4: 0x00000            in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.ProcessEventDelegate:Invoke (Sims3.Gameplay.EventSystem.Event) (480EA320 [69753798] )
#5: 0x00083 callvirt   in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.EventTracker:ProcessEvent (Sims3.Gameplay.EventSystem.Event) (363B73C0 [69753798] )
#6: 0x00045 callvirt   in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.EventTracker:SendEvent (Sims3.Gameplay.EventSystem.Event) ([69753798] )
#7: 0x0000e call       in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.EventTracker:SendEvent (Sims3.Gameplay.EventSystem.EventTypeId,Sims3.Gameplay.Interfaces.IActor,Sims3.Gameplay.Interfaces.IGameObject) ([2] [85383800] [00000000] )
#8: 0x001fc call       in Sims3.Gameplay.Core.Sims3.Gameplay.Core.PlumbBob:DoSelectActor (Sims3.Gameplay.Actors.Sim,bool) ([85383800] [1] )
#9: 0x00005 call       in Sims3.Gameplay.Core.Sims3.Gameplay.Core.PlumbBob:ForceSelectActor (Sims3.Gameplay.Actors.Sim) ([85383800] )
#10: 0x00059 call       in Veitc.AddsCommandPlus.Veitc.AddsCommandPlus.VCommands:TestSetActiveActor (Sims3.Gameplay.Actors.Sim) ([85383800] )
#11: 0x00042 call       in Veitc.AddsCommandPlus.Veitc.AddsCommandPlus.VCommands:forcesetaa2_command (bool) ([0] )
#12: 0x00416 call       in Veitc.AddsCommandPlus.Veitc.AddsCommandPlus.VCommands:_RunCommands (object[]) ([6671DF80] )
#13: 0x0000f call       in Veitc.AddsCommandPlus._Main+<>c__DisplayClass3:<World_OnStartupAppEventHandler>b__1 () ()
#14: 0x00000            in Veitc.AddsCommandPlus.Comman+FuncTask_Function:Invoke () ()
#15: 0x00034 callvirt   in Veitc.AddsCommandPlus.Comman+FuncTask:Simulate () ()

Source: icarusallsorts.Scolding
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x0006d stloc.np.o in Sims3.Gameplay.ChildAndTeenUpdates.icarusallsorts.Sims3.Gameplay.ChildAndTeenUpdates.icarusallsorts.ScoldDefinition:PopulatePieMenuPicker (Sims3.Gameplay.Interactions.InteractionInstanceParameters&,System.Collections.Generic.List`1&,System.Collections.Generic.List`1&,int&) (36CDA420 [vt:35E64C6C] [1433270944640421652/0x13e40054922e4f14] [2452508440/0x922e4f18] [-1842458736] )
#1: 0x0008d callvirt   in Sims3.Gameplay.UI.Sims3.Gameplay.UI.PieMenu:CreateInteractionMenuItem (Sims3.Gameplay.Interactions.InteractionInstanceParameters&,Sims3.SimIFace.GreyedOutTooltipCallback&,bool) ([vt:35E64C6C] [35E64CA4] [1] )
#2: 0x00196 call       in Sims3.Gameplay.UI.Sims3.Gameplay.UI.PieMenu:InitInteractionMenuItems (Sims3.UI.Hud.MenuTree,Sims3.Gameplay.Interactions.InteractionInstanceParameters&,Sims3.SimIFace.GreyedOutTooltipCallback&,bool) ([6952DF40] [vt:35E64C6C] [35E64CA4] [1] )
#3: 0x000b7 call       in Sims3.Gameplay.UI.Sims3.Gameplay.UI.PieMenu:TestAndBringUpPieMenu (Sims3.Gameplay.Interfaces.IGameObject,Sims3.UI.UIMouseEventArgs,Sims3.SimIFace.GameObjectHit,System.Collections.Generic.List`1,Sims3.Gameplay.Core.InteractionMenuTypes,string,bool,Sims3.SimIFace.GreyedOutTooltipCallback) ([8640C000] [B6768D90] [vt:35E64B2C] [5324767690612991416/0x49e56000b676e5b8] [0] [695CCC40] [0] [00000000] )
#4: 0x00038 call       in Sims3.Gameplay.UI.Sims3.Gameplay.UI.PieMenu:TestAndBringUpPieMenu (Sims3.Gameplay.Interfaces.IGameObject,Sims3.UI.UIMouseEventArgs,Sims3.SimIFace.GameObjectHit,System.Collections.Generic.List`1,Sims3.Gameplay.Core.InteractionMenuTypes) ([8640C000] [B6768D90] [vt:35E64A4C] [5324767690612991416/0x49e56000b676e5b8] [0] )
#5: 0x002e6 call       in NRaas.SelectorSpace.Tasks.NRaas.SelectorSpace.Tasks.GameObjectEx:OnPick (Sims3.Gameplay.Abstracts.GameObject,Sims3.UI.UIMouseEventArgs,Sims3.SimIFace.GameObjectHit) ([8640C000] [B6768D90] [vt:35E649A4] )
#6: 0x00114 call       in NRaas.SelectorSpace.Tasks.NRaas.SelectorSpace.Tasks.PickTask:CustomProcessClick (Sims3.UI.ScenePickArgs) (658B0F50 [vt:35E64904] )
#7: 0x0000b call       in NRaas.SelectorSpace.Tasks.NRaas.SelectorSpace.Tasks.PickTask:ProcessClick (Sims3.UI.ScenePickArgs) (658B0F50 [vt:35E6482C] )
#8: 0x00017 callvirt   in Sims3.Gameplay.Abstracts.Sims3.Gameplay.Abstracts.UiMouseClickProcessorTask:Simulate () ()


Source: lizcandorPolyamory
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x0002d ldflda     in lizcandor.Polyamory.lizcandor.Polyamory.HotInstaller:AddCommodityKindToTrait () ()
#1: 0x00003 call       in lizcandor.Polyamory.lizcandor.Polyamory.HotInstaller:Load () ()
#2: 0x0001e callvirt   in lizcandor.Polyamory.lizcandor.Polyamory.Instantiator:OnStartupApp (object,System.EventArgs) ([37B05FB0] [49732EC0] )

Source: TwoBTech.Mods.MoarInteractions
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00012 call       in TwoBTech.Mods.MoarInteractions.Services.CarpoolDisabler.TwoBTech.Mods.MoarInteractions.Services.CarpoolDisabler.Manager:AddInteractions (Sims3.Gameplay.Actors.Sim) (36BAC500 [92CDC800] )
#1: 0x00000            in TwoBTech.Mods.Commons.Delegates.TwoBTech.Mods.Commons.Delegates.NewSimEventDelegate:Invoke (Sims3.Gameplay.Actors.Sim) (36BAC460 [92CDC800] )
#2: 0x00000            in TwoBTech.Mods.Commons.Delegates.TwoBTech.Mods.Commons.Delegates.NewSimEventDelegate:Invoke (Sims3.Gameplay.Actors.Sim) (66839118 [92CDC800] )
#3: 0x00014 callvirt   in TwoBTech.Mods.Commons.Managers.TwoBTech.Mods.Commons.Managers.InformationBroker:RaiseEvent (TwoBTech.Mods.Commons.Delegates.NewSimEventDelegate,Sims3.Gameplay.Actors.Sim) (36BAC708 [36BAC460] [92CDC800] )
#4: 0x00012 call       in TwoBTech.Mods.Commons.Managers.TwoBTech.Mods.Commons.Managers.InformationBroker:OnSimInstantiated (Sims3.Gameplay.EventSystem.Event) (36BAC708 [8958AC78] )
#5: 0x00000            in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.ProcessEventDelegate:Invoke (Sims3.Gameplay.EventSystem.Event) (480EA118 [8958AC78] )
#6: 0x00083 callvirt   in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.EventTracker:ProcessEvent (Sims3.Gameplay.EventSystem.Event) (363B73C0 [8958AC78] )
#7: 0x00045 callvirt   in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.EventTracker:SendEvent (Sims3.Gameplay.EventSystem.Event) ([8958AC78] )
#8: 0x0000e call       in Sims3.Gameplay.EventSystem.Sims3.Gameplay.EventSystem.EventTracker:SendEvent (Sims3.Gameplay.EventSystem.EventTypeId,Sims3.Gameplay.Interfaces.IActor,Sims3.Gameplay.Interfaces.IGameObject) ([311] [00000000] [92CDC800] )
#9: 0x0017a call       in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.SimDescription:Instantiate (Sims3.SimIFace.Vector3,Sims3.SimIFace.ResourceKey,bool,bool) (36FC0AA0 [vt:868282F4] [vt:86828304] [0] [0] )
#10: 0x00016 call       in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.SimDescription:Instantiate (Sims3.SimIFace.Vector3,Sims3.SimIFace.ResourceKey,bool) (36FC0AA0 [vt:8682825C] [vt:8682826C] [0] )
#11: 0x00012 call       in Sims3.Gameplay.CAS.Sims3.Gameplay.CAS.SimDescription:Instantiate (Sims3.SimIFace.Vector3,bool) (36FC0AA0 [vt:868281CC] [0] )
#12: 0x0013e callvirt   in NiecMod.Nra.NiecMod.Nra.NFinalizeDeath:SimDesc_SafeInstantiate (Sims3.Gameplay.CAS.SimDescription,Sims3.SimIFace.Vector3) ([36FC0AA0] [vt:8682815C] )
#13: 0x0006f call       in NiecMod.NiecMod.Instantiator:<OnWorldLoadFinishedHandler>b__32 () ()
#14: 0x00000            in Sims3.NiecHelp.Tasks.NiecNraTask+NraFunction:Invoke () ()
#15: 0x00079 callvirt   in Sims3.NiecHelp.Tasks.Sims3.NiecHelp.Tasks.NiecTask:Simulate () ()

Source: NRaasCareer
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00081 callvirt   in NRaas.CareerSpace.Interactions.WriteReport+Definition:PopulatePieMenuPicker (Sims3.Gameplay.Interactions.InteractionInstanceParameters&,System.Collections.Generic.List`1&,System.Collections.Generic.List`1&,int&) (36729150 [vt:87B8F0EC] [-183239455942315736/0xfd7500af87b8f128] [2277044524/0x87b8f12c] [-2017922780] )
#1: 0x00097 callvirt   in a:_ (Sims3.Gameplay.Interactions.InteractionDefinition,Sims3.Gameplay.Autonomy.InteractionObjectPair,Sims3.Gameplay.Actors.Sim) ([36729150] [382DE318] [826BB800] )


Source: LeapsForCauchy.HorseBoarding
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00331 brfalse.i4.s in LeapsForCauchy.LeapsForCauchy.HorseBoarding:RecallBoarding () ()
#1: 0x00004 call       in LeapsForCauchy.LeapsForCauchy.HorseBoarding:OnWorldLoadStuff () ()
#2: 0x00000            in NiecMod.Nra.NFinalizeDeath+Function:Invoke () ()
#3: 0x0025c callvirt   in NiecMod.Nra.NiecMod.Nra.NFinalizeDeath:SimulateAlarm (Sims3.Gameplay.Utilities.AlarmManager,bool,bool,bool) ([46A0AD70] [1] [1] [0] )
#4: 0x00220 call       in NRaas.NRaas.ErrorTrap:OnScriptError (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#5: 0x00000            in ScriptCore.ExceptionTrap+ScriptError:Invoke (ScriptCore.ScriptProxy,System.Exception) (3837A3C0 [3615AD98] [00000000] )
#6: 0x00014 ldc.i4.1   in ScriptCore.ScriptCore.ExceptionTrap:Exception (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#7: 0x00007 brfalse.i4.s in ScriptCore.ScriptCore.ScriptProxy:OnScriptError (System.Exception) (3615AD98 [00000000] )
#8: 0x00081 brtrue.i4.s in ScriptCore.ScriptCore.ScriptProxy:Simulate () ()


Source: OutfitChanger
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x0000c brfalse.i4.s in S3_Passion.Outfit.Changer.S3_Passion.Outfit.Changer.ModLoader:AddSimInteractions (Sims3.Gameplay.Actors.Sim) ([68FE1800] )
#1: 0x0001e call       in S3_Passion.Outfit.Changer.S3_Passion.Outfit.Changer.ModLoader:OnWorldLoadFinishedHandler (object,System.EventArgs) ([35E58720] [46E27480] )


Source: NRaasCareer
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00016 ldfld.o    in NRaas.CommonSpace.Booters.NRaas.CommonSpace.Booters.SkillBooter:OnWorldLoadFinished () ()
#1: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )


Source: NRaasCareer
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00024 ldloc.o    in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.SimListing:GetResidents (bool) ([0] )
#1: 0x00012 call       in NRaas.CareerSpace.Helpers.NRaas.CareerSpace.Helpers.AcademicHelper:OnWorldLoadFinished () ()
#2: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )


Source: NRaasCareer
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00016 ldfld.o    in NRaas.CareerSpace.Booters.AfterschoolActivityBooter+AfterschoolActivityFixup:OnWorldLoadFinished () ()
#1: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )

Source: NRaasCareer
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00159 stloc.o    in NRaas.CareerSpace.Skills.NRaas.CareerSpace.Skills.Assassination:Allow (Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.CAS.SimDescription/DeathType,bool,bool,bool,Sims3.SimIFace.GreyedOutTooltipCallback&) ([49E56000] [378AE000] [3] [0] [1] [0] [35E64BB4] )
#1: 0x00029 call       in NRaas.CareerSpace.Interactions.Kill+Definition:Test (Sims3.Gameplay.Actors.Sim,Sims3.Gameplay.Actors.Sim,bool,Sims3.SimIFace.GreyedOutTooltipCallback&) (4B963540 [49E56000] [378AE000] [0] [35E64BB4] )
#2: 0x0014b callvirt   in Sims3.Gameplay.Interactions.Sims3.Gameplay.Interactions.InteractionDefinition`3:Test (Sims3.Gameplay.Interactions.InteractionInstanceParameters&,Sims3.SimIFace.GreyedOutTooltipCallback&) (4B963540 [vt:35E64B7C] [35E64BB4] )
#3: 0x0009e callvirt   in NRaas.SelectorSpace.Tasks.NRaas.SelectorSpace.Tasks.GameObjectEx:TestInteractions (Sims3.Gameplay.Actors.Sim,Sims3.SimIFace.GameObjectHit,System.Collections.Generic.List`1) ([49E56000] [vt:35E64A4C] [-8968607168427747888/0x83891b4c4bd795d0] )
#4: 0x002bc call       in NRaas.SelectorSpace.Tasks.NRaas.SelectorSpace.Tasks.GameObjectEx:OnPick (Sims3.Gameplay.Abstracts.GameObject,Sims3.UI.UIMouseEventArgs,Sims3.SimIFace.GameObjectHit) ([378AE000] [7235DFC0] [vt:35E649A4] )
#5: 0x00114 call       in NRaas.SelectorSpace.Tasks.NRaas.SelectorSpace.Tasks.PickTask:CustomProcessClick (Sims3.UI.ScenePickArgs) (658B0F50 [vt:35E64904] )
#6: 0x0000b call       in NRaas.SelectorSpace.Tasks.NRaas.SelectorSpace.Tasks.PickTask:ProcessClick (Sims3.UI.ScenePickArgs) (658B0F50 [vt:35E6482C] )
#7: 0x00017 callvirt   in Sims3.Gameplay.Abstracts.Sims3.Gameplay.Abstracts.UiMouseClickProcessorTask:Simulate () ()


Source: NRaasCareer
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00026 ldloc.o    in NRaas.CommonSpace.Stores.NRaas.CommonSpace.Stores.CareerStore:StoreAll () ()
#1: 0x00000 call       in NRaas.CommonSpace.Stores.NRaas.CommonSpace.Stores.CareerStore:OnWorldLoadFinished () ()
#2: 0x00000 call       in NRaas.NRaas.Careers:OnWorldLoadFinished () ()
#3: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )

Source: Gamefreak130.SkillsLoseProgress
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00006 callvirt   in Gamefreak130.SkillsLoseProgressSpace.Gamefreak130.SkillsLoseProgressSpace.Helpers:DecaySkills () ()
#1: 0x00000            in NiecMod.Nra.NFinalizeDeath+Function:Invoke () ()
#2: 0x0025c callvirt   in NiecMod.Nra.NiecMod.Nra.NFinalizeDeath:SimulateAlarm (Sims3.Gameplay.Utilities.AlarmManager,bool,bool,bool) ([46A0AD70] [1] [1] [0] )
#3: 0x00220 call       in NRaas.NRaas.ErrorTrap:OnScriptError (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#4: 0x00000            in ScriptCore.ExceptionTrap+ScriptError:Invoke (ScriptCore.ScriptProxy,System.Exception) (3837A3C0 [3615AD98] [00000000] )
#5: 0x00014 ldc.i4.1   in ScriptCore.ScriptCore.ExceptionTrap:Exception (ScriptCore.ScriptProxy,System.Exception) ([3615AD98] [00000000] )
#6: 0x00007 brfalse.i4.s in ScriptCore.ScriptCore.ScriptProxy:OnScriptError (System.Exception) (3615AD98 [00000000] )
#7: 0x00081 brtrue.i4.s in ScriptCore.ScriptCore.ScriptProxy:Simulate () ()


Source: NRaasOverwatch
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00016 ldfld.o    in NRaas.CommonSpace.Booters.NRaas.CommonSpace.Booters.SkillBooter:OnWorldLoadFinished () ()
#1: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )


Source: NRaasOverwatch
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00024 ldloc.o    in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.SimListing:GetResidents (bool) ([0] )
#1: 0x00003 call       in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.Corrections:CleanupAcademics (NRaas.CommonSpace.Helpers.Corrections/Logger) ([4A6AED20] )
#2: 0x0000c call       in NRaas.OverwatchSpace.Loadup.NRaas.OverwatchSpace.Loadup.CleanupAcademics:OnWorldLoadFinished () ()
#3: 0x0004f callvirt   in NRaas.NRaas.Common:OnWorldLoadFinished (object,System.EventArgs) ([35E58720] [46E27480] )

Source: NRaasDecensor
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00024 ldfld.o    in NRaas.CommonSpace.Helpers.NRaas.CommonSpace.Helpers.Households:AllSims (Sims3.Gameplay.CAS.Household) ([5A555700] )
#1: 0x00043 call       in NRaas.Decensor+LotTask:OnPerform () ()
#2: 0x0002f callvirt   in NRaas.CommonSpace.Tasks.NRaas.CommonSpace.Tasks.RepeatingTask:Simulate () ()


Source: NRaasTraveler
System.NotSupportedException: Attempting to yield in a non-yielding context!
#0: 0x00238 ldfld.o    in NRaas.TravelerSpace.States.NRaas.TravelerSpace.States.InWorldStateEx:Startup () ()
#1: 0x00012 callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:StartupCurState () ()
#2: 0x00018 call       in Sims3.SimIFace.Sims3.SimIFace.StateMachineStatus:SetState (Sims3.SimIFace.StateMachineState) (35E85640 [48CB3DC0] )
#3: 0x0009a callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Update (single) (35EC0F60 [0] )
#4: 0x00017 callvirt   in Sims3.SimIFace.Sims3.SimIFace.StateMachine:Simulate () ()";
        }
    }
}
