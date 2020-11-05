﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using NiecMod.KillNiec;

using Sims3.NiecHelp.Tasks;

using Sims3.Gameplay.NiecRoot;

using Sims3.SimIFace;
using Sims3.Gameplay.Actors;
using NiecMod.Helpers;
using Sims3.NiecModList.Persistable;
using Sims3.Gameplay.Utilities;

namespace NiecMod.Nra
{
    public class SCOSR
    {
        public static bool IsScriptCore2020cacheb0 = false;
        public static bool IsScriptCore2020cacheb1 = false;
        public static bool IsScriptCore2020()
        {
            if (!IsScriptCore2020cacheb1)
            {
                IsScriptCore2020cacheb1 = true;
                IsScriptCore2020cacheb0 = Type.GetType("ScriptCore.SData, ScriptCore", false) != null;
            }
            return IsScriptCore2020cacheb0;
        }

        public static bool IsDone()
        {

            return //!dDoneSafeErrorTrap && IsScriptCore2020cacheb0) || 
                IsScriptCore2020cacheb0 && DoneSafeErrorTrap && _SafeOnScriptError != null;
        }

        public static bool DoneSafeErrorTrap = false;
        public static bool dDoneSafeErrorTrap = false;

        public static _SafeScriptError _SafeOnScriptError = null;
        [global::Sims3.SimIFace.Persistable(false)]
        public delegate void _SafeScriptError(ScriptCore.ScriptProxy proxy, Exception e);

        private static Sims3.SimIFace.VisualEffect mGrimReaperSmoke = null;




        public static
            void StartUpSafeErrorTrapAdded()
        {
            if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap"))
            {
                NiecTask.Perform(delegate
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Simulator.Sleep(0);
                    }
                    if (!DoneSafeErrorTrap && AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap"))
                        Type.GetType("NRaas.Common, NRaasErrorTrap").GetMethod("OnPreLoad", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Invoke(null, new object[0]);
                    if (AssemblyCheckByNiec.IsInstalled("NRaasErrorTrap"))
                    {
                        Type type = Type.GetType("ScriptCore.ExceptionTrap, ScriptCore", true);
                        if (type != null)
                        {
                            FieldInfo mField = type.GetField("OnScriptError", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                            if (mField != null)
                            {
                                MethodInfo mf = (mField.GetValue(null) as MulticastDelegate).method_info;
                                if (mf != null)
                                {
                                    NFinalizeDeath.sIs_m_OnScriptError = typeof(SCOSR).GetMethod("OnScriptError");
                                    if (mf == typeof(SCOSR).GetMethod("OnScriptError") || mf.DeclaringType == typeof(SCOSR))
                                        DoneSafeErrorTrap = true;
                                    else
                                    {
                                        SCOSR._SafeOnScriptError = (SCOSR._SafeScriptError)Delegate.CreateDelegate(typeof(SCOSR._SafeScriptError), mf);
                                        type = Type.GetType("ScriptCore.ExceptionTrap+ScriptError, ScriptCore", true);
                                        if (type != null)
                                        {
                                            mf = typeof(SCOSR).GetMethod("OnScriptError");
                                            if (mf != null)
                                            {
                                                mField.SetValue(null, Delegate.CreateDelegate(type, mf));
                                                DoneSafeErrorTrap = true;
                                                if (NiecHelperSituation.___bOpenDGSIsInstalled_)
                                                {
                                                    SetBoolScriptCore2020(false, false, false);
                                                }
                                                else
                                                {
                                                    SetBoolScriptCore2020(AssemblyCheckByNiec.IsInstalled("AweCore"), true, mField.GetValue(null) != null);
                                                }
                                                if (mField.GetValue(null) == null)
                                                    NiecException.WriteLog("StartUpSafeErrorTrapAdded() Found mField.GetValue(null) == null");
                                            }
                                            else throw new NotSupportedException("OnScriptError not find");
                                        }
                                    }
                                }
                                else NiecException.WriteLog("if (mf == null)");
                            }   else throw new NotSupportedException("OnScriptError not find");
                        }
                    }
                });
            }
        }

        public static bool SetBoolScriptCore2020(bool unSafeAcore, bool unSafeDMODS, bool unSafeFuncOnScriptErrorMod)
        {
            var tSData = Type.GetType("ScriptCore.SData, ScriptCore", false);
            if (tSData != null)
            {
                FieldInfo f = null;
                bool a = false;
                try
                {
                    f = tSData.GetField("UnsafeACore", BindingFlags.Static | BindingFlags.Public);
                    if (f != null)
                    {
                        a = true;
                        f.SetValue(null, unSafeAcore);
                    }
                }
                catch (Exception)
                { }

                try
                {
                    f = tSData.GetField("UnsafeDMODS", BindingFlags.Static | BindingFlags.Public);
                    if (f != null)
                    {
                        a = true;
                        f.SetValue(null, unSafeDMODS);
                    }
                }
                catch (Exception)
                { }

                try
                {
                    f = tSData.GetField("UnsafeFuncOnScriptErrorMod", BindingFlags.Static | BindingFlags.Public);
                    if (f != null)
                    {
                        a = true;
                        f.SetValue(null, unSafeFuncOnScriptErrorMod);
                    }
                }
                catch (Exception)
                { }
                return a;
            }
            return false;
        }


        public static bool safeerrorbool = false;

        public static void OnScriptError(ScriptCore.ScriptProxy proxy, Exception ex)
        {
            if (proxy == null) 
                NFinalizeDeath.ThrowResetException("");

            if (safeerrorbool)
            {
                if (_SafeOnScriptError != null && ex != null)
                {
                    try
                    {
                        _SafeOnScriptError(proxy, ex);
                    }
                    catch (Exception)
                    {
                        // NRaas Failed
                    }
                }
                return;
            }
            if (!Simulator.CheckYieldingContext(false))
            {
                if (NiecHelperSituation.___bOpenDGSIsInstalled_)
                {
                    if (_SafeOnScriptError != null && ex != null)
                    {
                        try
                        {
                            _SafeOnScriptError(proxy, ex);
                        }
                        catch (Exception)
                        {
                            // NRaas Failed
                        }
                    }
                }
                return;
            }

            else if (NiecHelperSituation.___bOpenDGSIsInstalled_)
            {
                if (_SafeOnScriptError != null && ex != null)
                {
                    try
                    {
                        _SafeOnScriptError(proxy, ex);
                    }
                    catch (Exception)
                    {
                        // NRaas Failed
                    }
                }
                return;
            }

            var proxyTarget = proxy.Target;
            if (proxyTarget == null)
                NFinalizeDeath.ThrowResetException("");

            global::Sims3.SimIFace.Simulator.Sleep(110);

            Sim proxySim = proxyTarget as Sim;
            if (proxySim != null)
            {
                if (proxySim.SimDescription == null)
                {
                    proxySim.mSimDescription = Create.NiecNullSimDescription();
                    proxySim.mSimDescription.mSim = proxySim;
                }

                if (NFinalizeDeath.SimIsGRReaper(proxySim.SimDescription)) {
                    while (true)
                    {
                        if (!(proxySim.mPosture is NiecHelperSituationPosture))
                            NiecRunCommand.fcreap_Icommand(proxySim, false, true);

                        if (mGrimReaperSmoke != null && !mGrimReaperSmoke.ParentTo(proxySim, Sim.FXJoints.Pelvis))
                        {
                            var p = mGrimReaperSmoke;
                            mGrimReaperSmoke = null;
                            p.Stop();
                            p.Dispose();
                            p = null;
                        }

                        if (mGrimReaperSmoke == null)
                        {
                            mGrimReaperSmoke = VisualEffect.Create("reaperSmokeConstant");
                            if (mGrimReaperSmoke != null)
                            {
                                proxySim.FadeIn();
                                mGrimReaperSmoke.ParentTo(proxySim, Sim.FXJoints.Pelvis);
                                mGrimReaperSmoke.Start();
                            }
                        }

                        if (NiecHelperSituation.ExistsOrCreateAndAddToSituationList(proxySim) != null)
                            NiecHelperSituationPosture.r_internal(proxySim);

                        NFinalizeDeath.CheckYieldingContext();

                        if (NFinalizeDeath.GetCurrentExecuteType() == Sims3.SimIFace.ScriptExecuteType.Task)
                            global::Sims3.SimIFace.Simulator.Sleep(10);
                        else
                            global::Sims3.SimIFace.Simulator.Sleep(0);
                    }
                }
                else while (true)
                {
                    try
                    {
                        //proxySim.DoInteraction();
                        Bim.FoundInteraction(proxySim);
                    }
                    catch (ResetException)
                    {
                        throw;
                    }
                    catch
                    {
                        NFinalizeDeath.CheckYieldingContext();
                        if (!proxySim.IsSelectable)
                            NiecHelperSituationPosture.r_internal(proxySim);
                        else
                        {
                            global::Sims3.SimIFace.Simulator.Sleep(100);
                        }
                    }

                    NFinalizeDeath.CheckYieldingContext();

                    if (NFinalizeDeath.GetCurrentExecuteType() == Sims3.SimIFace.ScriptExecuteType.Task)
                        global::Sims3.SimIFace.Simulator.Sleep(10);
                    else
                        global::Sims3.SimIFace.Simulator.Sleep(0);
                }
            }

            SimUpdate proxySimUpdate = proxyTarget as SimUpdate;
            if (proxySimUpdate != null)
            {
                var sim = proxySimUpdate.mSim;
                if (sim == null || !NFinalizeDeath.GameObjectIsValid(sim.ObjectId.mValue))
                {
                    var p = proxySimUpdate.Proxy;
                    if (p != null)
                        Simulator.DestroyObject(p.ObjectId);

                    NFinalizeDeath.CheckYieldingContext();
                    Simulator.Sleep(uint.MaxValue);
                    NFinalizeDeath.ThrowResetException("");
                    return;
                }
                Simulator.Sleep(500);
                if (NiecHelperSituation.__acorewIsnstalled__)
                    return;
            }

            var proxyLot = proxyTarget as Sims3.Gameplay.Core.Lot;
            if (proxyLot != null)
            {
                while (true)
                {
                    NFinalizeDeath.CheckYieldingContext();

                    if (NFinalizeDeath.GetCurrentExecuteType() == Sims3.SimIFace.ScriptExecuteType.Task)
                        global::Sims3.SimIFace.Simulator.Sleep(10);
                    else
                        global::Sims3.SimIFace.Simulator.Sleep(0);

                    try
                    {
                        Sims3.Gameplay.Utilities.AlarmManager alarmManger = proxyLot.mSavedData != null ? proxyLot.mSavedData.mAlarmManager : null;
                        if (alarmManger != null)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                NFinalizeDeath.SimulateAlarm(alarmManger, true, true, false);
                            }
                        }

                        if (proxyLot.mSavedData == null) 
                            continue;

                        proxyLot.UpdateDoorPrivacy();
                        proxyLot.UpdateDetailPriority();

                        if (proxyLot.DisplayLevelChanged)
                        {
                            proxyLot.UpdateDisplayLevelInfo();
                            proxyLot.DisplayLevelChanged = false;
                        }

                        if (proxyLot.ShouldSimulate)
                        {
                            if (proxyLot.mLastTime == 0f)
                            {
                                proxyLot.mLastTime = SimClock.ElapsedTime(TimeUnit.Minutes);
                            }
                            else
                            {
                                float timePassed = SimClock.ElapsedTimeInMinutes(ref proxyLot.mLastTime);

                                proxyLot.UpdateReactions(timePassed, true);

                                if (GameUtils.IsInstalled(ProductVersion.EP7))
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        proxyLot.UpdateNumZombiesOnLot(timePassed);
                                    }
                                }
                            }
                        }
                        else if (proxyLot.mSavedData.mBroadcastersWithSims != null && proxyLot.mSavedData.mBroadcastersWithSims.Count > 0)
                        {
                            if (proxyLot.mLastTime == 0f)
                            {
                                proxyLot.mLastTime = SimClock.ElapsedTime(TimeUnit.Minutes);
                            }
                            else
                            {
                                proxyLot.UpdateReactions(SimClock.ElapsedTimeInMinutes(ref proxyLot.mLastTime), false);
                            }
                        }

                        try
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                proxyLot.UpdateReactions(3 + i, true);
                            }
                        }
                        catch (global::Sims3.SimIFace.ResetException)
                        { throw; }
                        catch { }

                    }
                    catch (global::Sims3.SimIFace.ResetException exT)
                    {
                        NiecTask.Perform(delegate
                        {
                            if (_SafeOnScriptError != null)
                                _SafeOnScriptError(proxy, exT);
                        });
                        throw;
                    }
                    catch
                    {
                        NFinalizeDeath.CheckYieldingContext();

                        for (int i = 0; i < 200; i++)
                        {
                            Simulator.Sleep(0);
                        }
                    }
                }
            }

            Sims3.Gameplay.Autonomy.AutonomyManager proxyAutonomyManager = proxyTarget as Sims3.Gameplay.Autonomy.AutonomyManager;
            if (proxyAutonomyManager != null)
            {
                proxy.mExecuteType = ScriptExecuteType.Threaded;
                Simulator.Sleep(150);
                if (NiecHelperSituation.__acorewIsnstalled__)
                    return;
            }

            Sims3.Gameplay.Services.Services proxyServices = proxyTarget as Sims3.Gameplay.Services.Services;
            if (proxyServices != null)
            {
                proxyServices.mServiceIndex = 0;
                proxy.mExecuteType = ScriptExecuteType.Threaded;
                Simulator.Sleep(1000);
                if (NiecHelperSituation.__acorewIsnstalled__)
                    return;
            }

            var alarmOneShot = proxyTarget as Sims3.Gameplay.Utilities.AlarmManager.AlarmOneShot;
            if (alarmOneShot != null)
            {
                alarmOneShot.mStarted = true;
                var ofp = alarmOneShot.mFunction;
                if (ofp == null)
                {
                    try
                    {
                        Sims3.Gameplay.Abstracts.GameObject.RemoveOneShotFunctionOnFinish(Simulator.CurrentTask);
                    }
                    catch (Exception)
                    { }

                    Simulator.DestroyObject(Simulator.CurrentTask);
                    goto r;
                }

                try
                {
                    alarmOneShot.mFunction = null;
                    if (ofp != null)
                    {
                        ofp();
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch (Exception exX)
                {
                    if (!NiecHelperSituation.__acorewIsnstalled__)
                        alarmOneShot.HandleException(exX);
                }

                r:;
                try
                {
                    Sims3.Gameplay.Abstracts.GameObject.RemoveOneShotFunctionOnFinish(Simulator.CurrentTask);
                }
                catch (Exception)
                { }

                Simulator.DestroyObject(Simulator.CurrentTask);

                if (alarmOneShot.mAlarmManager != null && alarmOneShot.mAlarmManager.mAlarmOneShotList != null)
                {
                    alarmOneShot.mAlarmManager.mAlarmOneShotList.Remove(alarmOneShot);
                }

                proxy.mTarget = null;
                return;
            }

            var oneShotFunc = proxyTarget as Sims3.Gameplay.OneShotFunction;
            if (oneShotFunc != null)
            {
                var ofp = oneShotFunc.mFunction;
                if (ofp == null)
                {
                    try
                    {
                        Sims3.Gameplay.Abstracts.GameObject.RemoveOneShotFunctionOnFinish(Simulator.CurrentTask);
                    }
                    catch (Exception)
                    { }
                  
                    Simulator.DestroyObject(Simulator.CurrentTask);
                    return;
                }
                try
                {
                    oneShotFunc.mFunction = null;
                    if (ofp != null)
                    {
                        ofp();
                    }
                }
                catch (ResetException)
                {
                    throw;
                }
                catch (Exception exX)
                {
                    if (!NiecHelperSituation.__acorewIsnstalled__)
                        oneShotFunc.HandleException(exX);
                }

                try
                {
                    Sims3.Gameplay.Abstracts.GameObject.RemoveOneShotFunctionOnFinish(Simulator.CurrentTask);
                }
                catch (Exception)
                { }

                Simulator.DestroyObject(Simulator.CurrentTask);
                proxy.mTarget = null;
                return;
            }

           

            var roleMangerTask = proxyTarget as Sims3.Gameplay.Roles.RoleManagerTask;
            if (roleMangerTask != null)
            {
                if (AssemblyCheckByNiec.IsInstalled("NRaasRegister") && Simulator.CheckYieldingContext(false))
                {
                    Simulator.Sleep(uint.MaxValue);
                }
            }

            if (_SafeOnScriptError != null && ex != null)
            {
                _SafeOnScriptError(proxy, ex);
            }
        }
































        public static void OnLoading()
        {
            IsScriptCore2020();
            if (_SafeOnScriptError != null)
            {
                DoneSafeErrorTrap = _SafeOnScriptError.method_info.DeclaringType == typeof(SCOSR);
                return;
            }
            DoneSafeErrorTrap = false;
            if (NiecHelperSituation.isdgmods)
                return;
            if (!IsScriptCore2020()) 
                return;
            StartUpSafeErrorTrapAdded();
        }
    }
}