#if ENDBLE_SCTESTINGERROR
using System;
using System.Collections.Generic;
using System.Text;
using Sims3.SimIFace;
using System.Reflection;
using Sims3.Gameplay.NiecRoot;
#endif

#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
#if !ENDBLE_SCTESTINGERROR
    #error Must ENDBLE_SCTESTINGERROR
#endif

namespace NRaas
{
    internal class ErrorTrap
    {
        private static object oertiertieruterut = null;
        internal static void OnScriptError(ScriptCore.ScriptProxy proxy, Exception exception)
        {
            if (oertiertieruterut == null)
            {
                oertiertieruterut = (MonoMethod)MethodBase.GetCurrentMethod();
            }
        }
        internal static bool InjectMethod()
        {
            NRaas.ErrorTrap.OnScriptError(null, null);

            NiecMod.Nra.SCOSR.dontcall = true;
            NiecMod.Nra.SCOSR.OnScriptError(null, null);
            NiecMod.Nra.SCOSR.dontcall = false;

            var m00 = (MonoMethod)(NiecMod.Nra.SCOSR.GetFuncNROnErrorTrap() ?? oertiertieruterut);
            if (m00 == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)NErrorTrap.OnScriptError is null.");
                return false;
            }

            ////

            var v00_i = (MonoMethod)typeof(NiecMod.Nra.SCOSR).GetMethod("OnScriptError", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (v00_i == null)
            {
                NiecMod.Nra.NFinalizeDeath.Assert("(MonoMethod)typeof(SCOSR).GetMethod(\"OnScriptError\"); is null.");
                return false;
            }

            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(v00_i, m00, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NErrorTrap_InjectMethod: copy_ptr_func_to_func(v00_i, m00) failed.");
                return false;
            }

            return true;
        }
    }
}
namespace ScriptCore
{
    public class ExceptionTrap
    {
        public delegate void PostLoad(ScriptCore.ScriptProxy proxy, IScriptLogic logic, bool postLoad);

        public delegate void ScriptError(ScriptCore.ScriptProxy proxy, System.Exception e);

        public delegate bool ScriptErrorV2(object[] args, System.Exception e);

        public delegate void RemoveObjectFunc(ObjectGuid id);

        public delegate void NotifyFunc(object[] objects);

        public delegate void ProcessObjectGuidFunc(ObjectGuid guid, bool added);

        public delegate void LoadObjectFunc(int index, ref object obj);

        public delegate void LoadArrayReferenceFunc(object child, ref object parent);

        public delegate void LoadReferenceFunc(ref object child, ref object parent, System.Reflection.FieldInfo field);

        public static NotifyFunc OnNotify = null;

        public static ScriptError OnScriptError;

        public static ScriptErrorV2 OnScriptErrorV2;

        public static PostLoad OnPrePostLoad;

        public static PostLoad OnPostPostLoad;

        public static ProcessObjectGuidFunc OnProcessObjectGuid;

        public static LoadObjectFunc OnLoadObject;

        public static LoadReferenceFunc OnLoadReference;

        public static LoadArrayReferenceFunc OnLoadArrayReference;

        public static RemoveObjectFunc OnRemoveObject;

        public static int sDepth = 0;

        public static void Notify(string text)
        {
            Notify(new object[1]
		    {
			    text
		    });
        }

        public static void Notify(object[] objects)
        {
            if (OnNotify != null)
            {
                OnNotify(objects);
            }
        }

        public static bool Exception(ScriptCore.ScriptProxy proxy, Exception e)
        {
            if (OnScriptError != null)
            {
                OnScriptError(proxy, e);
                return true;
            }
            return false;
        }

        public static bool ExceptionV2(object[] args, Exception e)
        {
            if (OnScriptErrorV2 != null)
            {
                return OnScriptErrorV2(args, e);
            }
            return false;
        }

        public static void RemoveObject(ObjectGuid id)
        {
            if (OnRemoveObject != null)
            {
                OnRemoveObject(id);
            }
        }

        public static ObjectGuid ProcessObjectGuid(ObjectGuid guid, bool added)
        {
            if (OnProcessObjectGuid != null)
            {
                OnProcessObjectGuid(guid, added);
            }
            return guid;
        }

        public static void LoadObject(int index, ScriptCore.PersistReader.ObjectLoadMode loadMode, ref object obj)
        {
            if (OnLoadObject != null && loadMode == ScriptCore.PersistReader.ObjectLoadMode.Create)
            {
                OnLoadObject(index, ref obj);
            }
        }

        public static void ExternalLoadReference(object child, object parent, FieldInfo field)
        {
            LoadReference(ref child, ref parent, field);
        }

        public static void LoadReference(ref object child, ref object parent)
        {
            if (OnLoadReference != null)
            {
                OnLoadReference(ref child, ref parent, null);
            }
        }

        public static void LoadReference(ref object child, ref object parent, FieldInfo field)
        {
            if (OnLoadReference != null)
            {
                OnLoadReference(ref child, ref parent, field);
            }
        }

        public static void LoadReference<T>(T[] children, ref object parent)
        {
            if (OnLoadArrayReference != null)
            {
                OnLoadArrayReference(children, ref parent);
            }
        }
    }
}
#endif // ENDBLE_SCTESTINGERRORAddNRaasErrorTrap

#if ENDBLE_SCTESTINGERROR
namespace NiecMod.Nra
{
    public class NSC_ETRAP
    {
        private static object sHome = null; //new NSC_ETRAP();

        public static bool IsDone = false;

        private static bool a_core = NiecMod.KillNiec.AssemblyCheckByNiec.IsInstalled("AweCore");
        private static MethodInfo mDispose = null;
        private static MethodInfo mOnReset = null;
        private static MethodInfo mInit = null;

        private static NSC_ETRAP get_instance<T>()
        {
            if (sHome as NSC_ETRAP == null)
                sHome = new NSC_ETRAP();
            return (NSC_ETRAP)sHome;
        }

        private static bool __dontcall = false;

        internal static bool _InitClass()
        {
            if (NiecHelperSituation.__acorewIsnstalled__ && mOnReset == null)
            {
                try
                {
                    Type type = typeof(IScriptLogic);
                    if (type != null)
                    {
                        mDispose = type.GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        mOnReset = type.GetMethod("OnReset", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        mInit = type.GetMethod("Init", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    }
                }
                catch (Exception)
                { }
            }

            libPtrSCAssembly = typeof(ScriptCore.ScriptProxy).Assembly._mono_assembly;

#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
            if (!NRaas.ErrorTrap.InjectMethod())
                return false;
#endif
            if (!_InjectMethod())
                return false;

#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
            MethodInfo methinfo = (MethodInfo)SCOSR.GetFuncNROnErrorTrap();
            if (methinfo != null)
            {
                ScriptCore.ExceptionTrap.OnScriptError = (ScriptCore.ExceptionTrap.ScriptError)
                    Delegate.CreateDelegate(typeof(ScriptCore.ExceptionTrap.ScriptError), methinfo);
            }
            else 
                ScriptCore.ExceptionTrap.OnScriptError = NRaas.ErrorTrap.OnScriptError;
#endif

            SCOSR.DoneSafeErrorTrap = true;
            SCOSR.ShouldInjectedMethodOnScriptError = true;
            SCOSR._SafeOnScriptError = SCOSR.Empty_OnScriptError;

            return true;
        }

        public static bool _InjectMethod()
        {
            __dontcall = true;
            get_instance<BimDesc>().sc_set_logic(null, false);
            get_instance<Bim>().SCP_onscripterror(null);
            get_instance<NJOClass>().script_proxy_simulate();
            get_instance<nobjecoD>().sc_post_Load();
            get_instance<NiecModException>().sc_create_Logic(null);
            get_instance<NiecObjectPlus>().sc_dispose();
            get_instance<NiecPosture>().sc_on_reset();
            get_instance<NiecHelperSituationPosture>().sc_try_create_Logic(null);
            get_instance<NiecHelperSituation>().sc_restore_saved_task_context();
            __dontcall = false;

            ScriptCore.ScriptProxy obj = null;
            if (obj != null)
            {
                obj.SetLogic(null, false);
                obj.OnScriptError(null);
                obj.Simulate();
                obj.PostLoad();
                obj.CreateLogic(null);
                obj.Dispose();
                obj.OnReset();
                obj.TryCreateLogic(null);
                obj.RestoreSavedTaskContext();
            }

            var m00 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("sc_set_logic", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m00 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"sc_set_logic\"); is null.");
                return false;
            }
            var m01 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("SCP_onscripterror", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"SCP_onscripterror\"); is null.");
                return false;
            }
            var m02 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("script_proxy_simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"script_proxy_simulate\"); is null.");
                return false;
            }
            var m03 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("sc_post_Load", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"sc_post_Load\"); is null.");
                return false;
            }
            var m04 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("sc_create_Logic", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"sc_create_Logic\"); is null.");
                return false;
            }
            var m05 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("sc_dispose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m05 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"sc_dispose\"); is null.");
                return false;
            }
            var m06 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("sc_on_reset", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m06 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"sc_on_reset\"); is null.");
                return false;
            }
            var m07 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("sc_try_create_Logic", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m07 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"sc_try_create_Logic\"); is null.");
                return false;
            }
            var m08 = (MonoMethod)typeof(NSC_ETRAP).GetMethod("sc_restore_saved_task_context", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m08 == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(NSC_ETRAP).GetMethod(\"sc_restore_saved_task_context\"); is null.");
                return false;
            }
            //////////
            var m00_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("SetLogic", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[] { typeof(IScriptLogic), typeof(bool) }, null);
            if (m00_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"SetLogic\"); is null.");
                return false;
            }
            var m01_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("OnScriptError", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m01_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"OnScriptError\"); is null.");
                return false;
            }
            var m02_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("Simulate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"Simulate\"); is null.");
                return false;
            }
            var m03_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("PostLoad", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"PostLoad\"); is null.");
                return false;
            }
            var m04_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("CreateLogic", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m04_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"CreateLogic\"); is null.");
                return false;
            }
            var m05_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m05_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"Dispose\"); is null.");
                return false;
            }
            var m06_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("OnReset", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m06_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"OnReset\"); is null.");
                return false;
            }
            var m07_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("TryCreateLogic", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m07_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"TryCreateLogic\"); is null.");
                return false;
            }
            var m08_i = (MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod("RestoreSavedTaskContext", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (m08_i == null)
            {
                NFinalizeDeath.Assert("(MonoMethod)typeof(ScriptCore.ScriptProxy).GetMethod(\"RestoreSavedTaskContext\"); is null.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m00, m00_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m00, m00_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m01, m01_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m01, m01_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m02, m02_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m02, m02_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m03, m03_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m03, m03_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m04, m04_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m04, m04_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m05, m05_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m05, m05_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m06, m06_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m06, m06_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m07, m07_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m07, m07_i) failed.");
                return false;
            }
            if (!NiecMod.Nra.niec_script_func.niecmod_script_copy_ptr_func_to_func(m08, m08_i, false, false, false, false))
            {
                NiecMod.Nra.NFinalizeDeath.Assert("NSC_ETRAP: copy_ptr_func_to_func(m08, m08_i) failed.");
                return false;
            }
            return true;
        }

        public bool sc_create_Logic(string className)
        {
            if (__dontcall)
                return true;

            var _this = (ScriptCore.ScriptProxy)(object)this;
            if (_this.mTarget != null)
            {
                return true;
            }

            string p = null;
            try
            {
                className = ScriptCore.ScriptProxy.SubstituteClass(className);
                if (className == null)
                {
                    return false;
                }
                p = className;
                IScriptLogic scriptLogic = _this.TryCreateLogic(className);
                if (scriptLogic == null)
                {
                    string text = ScriptCore.ScriptProxy.CreateLogicFailureName(className);
                    if (text != null)
                    {
                        scriptLogic = _this.TryCreateLogic(text);
                        if (scriptLogic == null)
                        {
                            throw new NullReferenceException("--- ERROR:  Unable to create failure logic '" + text + "'. ---");
                        }
                    }
                    if (scriptLogic == null)
                    {
                        throw new NullReferenceException("--- ERROR:  Unable to create logic type '" + className + "'. ---");
                    }
                }
                return _this.SetLogic(scriptLogic, false);
            }
            catch
            {
                if (p != null)
                {
                    try
                    {
                        Type tpye = null;
                        foreach (Assembly assembly in NFinalizeDeath.GetAssemblies())
                        {
                            tpye = assembly.GetType(p, false);
                            if (tpye != null)
                            {
                                break;
                            }
                        }
                        if (tpye == null)
                        {
                            throw new NullReferenceException("--- ERROR:  Could not find Class Name. ---");
                        }
                        var constructor = tpye.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, CallingConventions.Any, new Type[0], null);
                        if (constructor == null)
                        {
                            throw new NullReferenceException("--- ERROR:  Could not find Constructor ctor() of " + tpye.FullName);
                        }
                        IScriptLogic s = (IScriptLogic)constructor.Invoke(null);
                        if (s == null)
                        {
                            throw new NullReferenceException("--- ERROR:  Failed to create IScriptLogic TypeName: '" + tpye.FullName +"'. ---");
                        }
                        return _this.SetLogic(s, false);
                    }
                    catch (Exception)
                    { }
                }
                return true;
            }
        }

        public void sc_dispose()
        {
            if (__dontcall)
                return;

            var _this = (ScriptCore.ScriptProxy)(object)this;

            try
            {
                if (_this.mTarget != null)
                {
                    if (mDispose != null)
                    {
                        mDispose.Invoke(_this.mTarget, null);
                    }
                    else _this.mTarget.Dispose();
                }
            }
            catch { }

            _this.mTarget = null;
            _this.mObjectId = Sims3.SimIFace.Simulator.kBadObjectGuid;
        }

        public void sc_on_reset()
        {
            if (__dontcall)
                return;
            var _this = (ScriptCore.ScriptProxy)(object)this;
            if (_this.mTarget != null)
            {
                if (mOnReset != null)
                {
                    mOnReset.Invoke(_this.mTarget, null);
                }
                else _this.mTarget.OnReset();
            }
        }

        public void sc_post_Load()
        {
            if (__dontcall)
                return;

            var _this = (ScriptCore.ScriptProxy)(object)this;

            try
            {
                if (_this.mTarget != null)
                {
#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
                    if (ScriptCore.ExceptionTrap.OnPrePostLoad != null)
                    {
                        ScriptCore.ExceptionTrap.OnPrePostLoad(_this, _this.mTarget, true);
                    }
#endif
#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
                    try
#endif
                    {
                        if (mInit != null)
                        {
                            _this.mExecuteType = (ScriptExecuteType)mInit.Invoke(_this.mTarget, new object[1]
						    {
							    true
						    });
                        }
                        else
                        {
                            _this.mExecuteType = _this.mTarget.Init(true);
                        }
                    }

#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
                    finally
                    {
                        if (ScriptCore.ExceptionTrap.OnPostPostLoad != null)
                        {
                            ScriptCore.ExceptionTrap.OnPostPostLoad(_this, _this.mTarget, true);
                        }
                    }

                    ScriptCore.ExceptionTrap.Notify(new object[3]
				    {
					    "ScriptProxy:PostLoad",
					    _this.mExecuteType,
					    _this.mTarget
				    });
#endif
                    if (_this.mExecuteType == ScriptExecuteType.InitFailed)
                    {
                        if (NiecHelperSituation.__acorewIsnstalled__)
                        {
                            _this.mExecuteType = ScriptExecuteType.Threaded;
                        }
                        else
                        {
                            _this.mTarget.Proxy = null;
                            _this.mTarget = null;
                        }
                    }
                    if (NiecHelperSituation.__acorewIsnstalled__ && _this.mExecuteType == ScriptExecuteType.None)
                    {
                        _this.mExecuteType = ScriptExecuteType.Threaded;
                    }
                }
            }
            catch (Exception e)
            {
                try
                {
                    _this.OnScriptError(e);
                }
                catch (Exception)
                { }

                if (NiecHelperSituation.__acorewIsnstalled__ && _this.mExecuteType == ScriptExecuteType.None)
                {
                    _this.mExecuteType = ScriptExecuteType.Threaded;
                }
            }
        }

        public static IntPtr libPtrSCAssembly = new IntPtr(0);

        internal bool sc_set_logic(IScriptLogic obj, bool postLoad)
        {
            if (__dontcall)
                return true;

            var _this = (ScriptCore.ScriptProxy)(object)this;

            try
            {
                _this.mTarget = obj;
                _this.mTarget.Proxy = _this;

                try
                {
#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
                    if (ScriptCore.ExceptionTrap.OnPrePostLoad != null)
                    {
                        ScriptCore.ExceptionTrap.OnPrePostLoad(_this, _this.mTarget, postLoad);
                    }
#endif
#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
                    try
#endif
                    {
                        if (mInit != null)
                        {
                            _this.mExecuteType = (ScriptExecuteType)mInit.Invoke(_this.mTarget, new object[1]
						    {
							    postLoad
						    });
                        }
                        else
                        {
                            _this.mExecuteType = _this.mTarget.Init(postLoad);
                        }
                    }

#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
                    finally
                    {
                        if (ScriptCore.ExceptionTrap.OnPostPostLoad != null)
                        {
                            ScriptCore.ExceptionTrap.OnPostPostLoad(_this, _this.mTarget, postLoad);
                        }
                    }
#endif
                }
                catch (ResetException)
                {
                    _this.mExecuteType = ScriptExecuteType.InitFailed;
                }
#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
                ScriptCore.ExceptionTrap.Notify(new object[3]
			    {
				    "ScriptProxy:SetLogic",
				    _this.mExecuteType,
				    _this.mTarget
			    });
#endif
                if (_this.mExecuteType == ScriptExecuteType.InitFailed)
                {
                    _this.mExecuteType = ScriptExecuteType.Threaded;
                }
                if (_this.mExecuteType == ScriptExecuteType.None)
                {
                    _this.mExecuteType = ScriptExecuteType.Threaded;
                }
            }
            catch (StackOverflowException e2)
            {
                if (Sims3.SimIFace.Simulator.CheckYieldingContext(false))
                {
                    throw;
                }
                try
                {
                    _this.OnScriptError(e2);
                }
                catch (StackOverflowException)
                {
                    throw;
                }
                catch (Exception)
                { }
            }
            catch (Exception e)
            {
                try
                {
                    _this.OnScriptError(e.InnerException ?? e);
                }
                catch (Exception)
                { }
                if (_this.mExecuteType == ScriptExecuteType.None)
                {
                    _this.mExecuteType = ScriptExecuteType.Threaded;
                }
            }
            return true;
        }

        private IScriptLogic sc_try_create_Logic(string className)
        {
            if (className == null)
                return null;

            IScriptLogic scriptLogic = null;
            foreach (Assembly assembly in NFinalizeDeath.GetAssemblies())
            {
                scriptLogic = (IScriptLogic)assembly.CreateInstance(className);
                if (scriptLogic != null)
                {
                    break;
                }
            }
            return scriptLogic;
        }

        private void sc_restore_saved_task_context()
        {
            if (__dontcall)
                return;
            var _this = (ScriptCore.ScriptProxy)(object)this;
            var savedTaskContext = _this.mSavedTaskContext;
            _this.mSavedTaskContext = null;
            if (!a_core && savedTaskContext != null)
            {
                ScriptCore.LoadSaveManager.RequestTaskRestore(savedTaskContext);
                Sims3.SimIFace.Simulator.Sleep(uint.MaxValue);
                _this.OnReset();
            }
        }

        public void script_proxy_simulate()
        {
            if (__dontcall)
                return;

            var _this = (ScriptCore.ScriptProxy)(object)this;
            if (_this.mTarget == null)
            {
                return;
            }

            Assembly p = Assembly.GetCallingAssembly();
            bool StackOneCall = p == null || p._mono_assembly == libPtrSCAssembly;
            p = null;

            if (_this.mResetSavedObject || _this.mSavedTaskContext != null)
            {
                try
                {
                    _this.PreSimulate();
                }
                catch (Exception)
                {
                    if (!StackOneCall)
                    {
                        throw;
                    }
                    return;
                }
            }

            while (_this.mTarget != null)
            {
                try
                {
                    if (!_this.OnScriptError(null))
                    {
                        _this.SetObjectNotToReset();
                    }
                    break;
                }
                catch (ResetException)
                {
                    if (!StackOneCall)
                    {
                        throw;
                    }
                    return;
                }
                catch (Exception)
                { }

                if (!Sims3.SimIFace.Simulator.CheckYieldingContext(false))
                {
                    if (StackOneCall)
                    {
                        return;
                    }
                    else
                    {
                        NFinalizeDeath.ThrowResetException(null);
                    }
                }
                Sims3.SimIFace.Simulator.Sleep(0);
            }

            if (_this.mTarget == null)
                return;
            while (true)
            {
                try
                {
                    _this.mTarget.Simulate();
                    break;
                }
                catch (ResetException)
                {
                    if (!StackOneCall)
                    {
                        throw;
                    }
                    return;
                }
                catch (Exception ex)
                {
                    try
                    {
                        _this.OnScriptError(ex);
                    }
                    catch (Exception)
                    { }
                }

                if (!Sims3.SimIFace.Simulator.CheckYieldingContext(false))
                {
                    if (StackOneCall)
                        return;
                    else
                      NFinalizeDeath.ThrowResetException(null);
                }

                Sims3.SimIFace.Simulator.Sleep(0);
            }

            if (Simulator.CheckYieldingContext(false))
                Simulator.Sleep(5000);
        }

        public bool SCP_onscripterror(Exception e)
        {
            if (__dontcall)
                return false;
#if ENDBLE_SCTESTINGERRORAddNRaasErrorTrap
            if (ScriptCore.ExceptionTrap.Exception((ScriptCore.ScriptProxy)(object)this, e))
            {
                return true;
            }
            return false;
#else 
            if (Simulator.CheckYieldingContext(false))
            {
                Simulator.Sleep(350);
            }
            return true;
#endif
        }
    }
}
#endif // ENDBLE_SCTESTINGERROR
