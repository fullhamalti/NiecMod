using System;
using System.Collections.Generic;
using System.Text;
using NiecMod.Nra;
using Sims3.SimIFace;
using System.Reflection;
using NiecMod.KillNiec;
using Sims3.UI;

namespace Sims3.NiecHelp.Tasks
{



    public class MethodStore
    {
        string mAssemblyName;
        string mClassName;
        string mRoutineName;
        Type[] mParameters;

        StringBuilder mError = new StringBuilder();

        public MethodInfo mMethod = null;
        public bool mChecked = false;

        public MethodStore(string assemblyName, string className, string routineName, Type[] parameters)
        {
            mAssemblyName = assemblyName;
            mClassName = className;
            mRoutineName = routineName;
            mParameters = parameters;
        }
        public MethodStore(string methodName, Type[] parameters)
        {
            if ((methodName != null) && (methodName.Contains(",")))
            {
                string[] strArray = methodName.Split(new char[] { ',' });

                mClassName = strArray[0];
                mAssemblyName = strArray[1];
                mRoutineName = strArray[2].Replace(" ", "");
            }

            mParameters = parameters;
        }

        public bool Valid
        {
            get { return LookupRoutine(); }
        }

        public string Error
        {
            get
            {
                LookupRoutine();
                return mError.ToString();
            }
        }

        public MethodInfo Method
        {
            get
            {
                LookupRoutine();
                return mMethod;
            }
        }

        public override string ToString()
        {
            return mMethod + " (" + mAssemblyName + "." + mClassName + "." + mRoutineName + ")";
        }

        protected bool LookupRoutine()
        {
            
            if (!mChecked)
            {
                //mError += "Assembly: " + mAssemblyName + NiecException.NewLine + "ClassName: " + mClassName + NiecException.NewLine + "RoutineName: " + mRoutineName;

                try
                {
                    mChecked = true;

                    if (!string.IsNullOrEmpty(mAssemblyName))
                    {
                        Assembly assembly = AssemblyCheckByNiec.FindAssembly(mAssemblyName);
                        if (assembly != null)
                        {
                            //mError += NiecException.NewLine + " Assembly Found: " + assembly.FullName;

                            Type type = assembly.GetType(mClassName);
                            if (type != null)
                            {
                                //mError += Common.NewLine + " Class Found: " + type.ToString();

                                if (mParameters != null)
                                {
                                    mMethod = type.GetMethod(mRoutineName, mParameters);
                                }
                                else
                                {
                                    mMethod = type.GetMethod(mRoutineName);
                                }

                                //if (mMethod != null)
                                //{
                                //    //mError += Common.NewLine + " Routine Found";
                                //}
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    //mError += Common.NewLine + "Exception";
                    NiecException.WriteLog("Error " + e.ToString(), true, true);
                }
                finally
                {
                    //Common.WriteLog(mError);
                }
            }
            
            return (mMethod != null);
        }

        public T Invoke<T>(object[] parameters)
        {
            return Invoke<T>(null, parameters);
        }
        public T Invoke<T>(object obj, object[] parameters)
        {
            if (!Valid) return default(T);

            try
            {
                return (T)mMethod.Invoke(obj, parameters);
            }
            catch (Exception e)
            {
                NiecException.WriteLog("Error Invoke: " + e.ToString(), true, true);
                return default(T);
            }
        }
    }


    public class NDelayFunctionTask : Task // Battery user Fail Fix
    {
        private StopWatch mTimer;

        private readonly int mDelay;

        private readonly object mParam;

        private readonly object mParam_1;

        private readonly FunctionWithParam mFunction;

        private ScriptExecuteType _ScriptExecuteType = ScriptExecuteType.Task;

        public bool shouldRun = false;

        public NDelayFunctionTask(FunctionWithParam function, object param)
        {
            if (function == null)
                throw new ArgumentNullException("function");

            mFunction = function;
            mParam = param;
            mDelay = 500;
        }

        public NDelayFunctionTask(FunctionWithParam function, object param, int delay)
        {
            if (function == null)
                throw new ArgumentNullException("function");

            mFunction = function;
            mParam = param;
            mDelay = delay;
        }

        public NDelayFunctionTask(FunctionWithParam function, object param, object param_1, int delay)
        {
            if (function == null)
                throw new ArgumentNullException("function");

            mFunction = function;
            mParam = param;
            mParam_1 = param_1;
            mDelay = delay;
        }

        public override void Dispose()
        {
            if (mTimer != null)
            {
                mTimer.Dispose();
                mTimer = null;
            }

            if (base.ObjectId.mValue != 0)
            {
                Simulator.DestroyObject(base.ObjectId);
                base.ObjectId = ObjectGuid.InvalidObjectGuid;
            }

            base.Dispose();
        }

        public override void Simulate()
        {
            mTimer = StopWatch.Create(StopWatch.TickStyles.Milliseconds);
            if (mTimer == null)
            {
                Dispose();
                return;
            }

            if (shouldRun)
            {
                Dispose();
                return;
            }

            shouldRun = true;

            mTimer.Start();

            while (true)
            {
                if (mTimer != null && mTimer.GetElapsedTime() == mDelay)
                {
                    mFunction(mParam);
                    Simulator.Sleep(0);
                    continue;
                }

                Simulator.Sleep(0);

                if (mTimer == null)
                {
                    break;
                }
            }
        }

        // my custom methed
        public ObjectGuid AddToSimulator()
        {
            return Simulator.AddObject(this);
        }

        public static NDelayFunctionTask GetCurrentTask()  // fast code
        {
            return ScriptCore.Simulator.Simulator_GetTaskImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl(), false) as NDelayFunctionTask;
        }

        public void SetExecuteType(ScriptExecuteType type)
        {
            if (type == ScriptExecuteType.None || type == ScriptExecuteType.InitFailed)
                _ScriptExecuteType = ScriptExecuteType.Task;
            else
                _ScriptExecuteType = type;
        }

        public override ScriptExecuteType ExecuteType
        {
            get
            {
                return _ScriptExecuteType;
            }
        }

        public static ObjectGuid CreateAndAddToSimulator(ScriptExecuteType executeType, FunctionWithParam func, object pobj, object pobj1, int delay)
        {
            var p = new NDelayFunctionTask(func, pobj, pobj1, delay);
            p.SetExecuteType(executeType);
            return p.AddToSimulator();
        }
    }


    public class NRepeatingFunctionTask : Task // Battery user Fail Fix
    {
        private StopWatch mTimer;

        private readonly int mDelay;

        private readonly object mParam;

        private readonly FunctionWithParam mFunction;

        private ScriptExecuteType _ScriptExecuteType = ScriptExecuteType.Task;

        public bool shouldRun = false;

        public NRepeatingFunctionTask(FunctionWithParam function, object param)
        {
            if (function == null)
                throw new ArgumentNullException("function");

            mFunction = function;
            mParam = param;
            mDelay = 500;
        }

        public NRepeatingFunctionTask(FunctionWithParam function, object param, int delay)
        {
            if (function == null)
                throw new ArgumentNullException("function");

            mFunction = function;
            mParam = param;
            mDelay = delay;
        }

        public override void Dispose()
        {
            if (mTimer != null)
            {
                mTimer.Dispose();
                mTimer = null;
            }

            if (base.ObjectId.mValue != 0)
            {
                Simulator.DestroyObject(base.ObjectId);
                base.ObjectId = ObjectGuid.InvalidObjectGuid;
            }

            base.Dispose();
        }

        public override void Simulate()
        {
            mTimer = StopWatch.Create(StopWatch.TickStyles.Milliseconds);
            if (mTimer == null)
            {
                Dispose();
                return;
            }
           
            if (shouldRun)
            {
                Dispose();
                return;
            }

            shouldRun = true;

            mTimer.Start();

            do
            {
                if (GameUtils.IsPaused())
                {
                    Simulator.Sleep(0);
                    mTimer.Stop();
                }
                else
                {
                    if (GameUtils.IsPaused())
                    {
                        Simulator.Sleep(0);
                        continue;
                    }

                    mTimer.Restart();

                    while (mTimer != null && mTimer.GetElapsedTime() < mDelay)
                    {
                        Simulator.Sleep(0);
                    }

                    mFunction(mParam);

                    Simulator.Sleep(0);
                }
            }
            while (mTimer != null);
        }

        // my custom methed
        public ObjectGuid AddToSimulator()
        {
            return Simulator.AddObject(this);
        }

        public static NRepeatingFunctionTask GetCurrentTask() // fast code
        {
            return ScriptCore.Simulator.Simulator_GetTaskImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl(), false) as NRepeatingFunctionTask;
        }

        public void SetExecuteType(ScriptExecuteType type)
        {
            if (type == ScriptExecuteType.None || type == ScriptExecuteType.InitFailed)
                _ScriptExecuteType = ScriptExecuteType.Task;
            else 
                _ScriptExecuteType = type;
        }

        public override ScriptExecuteType ExecuteType
        {
            get
            {
                return _ScriptExecuteType;
            }
        }

        public static ObjectGuid CreateAndAddToSimulator(ScriptExecuteType executeType, FunctionWithParam func, object paramobj, int delay)
        {
            var p = new NRepeatingFunctionTask(func, paramobj, delay);
            p.SetExecuteType(executeType);
            return p.AddToSimulator();
        }
    }







    public class NiecNraTask
    {
        public delegate void NraFunction();

    }

    public class NiecTask : Task
    {
        internal static StringBuilder ErrorRuntimeFound = new StringBuilder();
        public static bool IsOpenDGSInstalled = AssemblyCheckByNiec.IsInstalled("OpenDGS");
        public static void SSetFakeObjectId(ObjectGuid value, out NiecTask currentTask)
        {

            currentTask = null;

            NiecTask task = Simulator.GetTask(Simulator.CurrentTask) as NiecTask;
            if (task != null) {
                currentTask = task;
                task.mObjectId = value;
            }


            if (Simulator.CurrentTask == value)
                NiecException.WriteLog("DEBUG: SetFakeObjectId ok");
            else 
                NiecException.WriteLog("DEBUG: SetFakeObjectId failed");
        }

        public void ResetFakeObjectId()
        {
            /*
            NiecTask task = Simulator.GetTask(Simulator.CurrentTask) as NiecTask;
            if (task != null)
            {
                task.mFakeObjectId = new ObjectGuid(0);
            }*/
            //mObjectId = mTaskC;
        }


        //ObjectGuid mFakeObjectId = new ObjectGuid(0);

        //ObjectGuid mTaskC = new ObjectGuid(0);


        private Exception exThrow  = null;

        public bool errorRuntimeFound = false;
        public bool needNoErrorRuntimeNoFound = false;
        public bool needNoErrorRuntime = false;
        public object nData = null;


        NiecNraTask.NraFunction mFunction;
        ScriptExecuteType _ScriptExecuteType;

        ObjectGuid WaitPerform_WaitingCurrentTask;
        public object WaitPerform_DoneResult;
        public ObjectGuid WaitPerform_CreatedTask;

        
        

        public NiecTask()
        {
            mFunction = OnPerform;
            _ScriptExecuteType = ScriptExecuteType.Task;

            WaitPerform_WaitingCurrentTask = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;
            WaitPerform_CreatedTask = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;

            WaitPerform_DoneResult = null;
        }
        public NiecTask(NiecNraTask.NraFunction func)
        {
            mFunction = func;
            _ScriptExecuteType = ScriptExecuteType.Task;

            WaitPerform_WaitingCurrentTask = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;
            WaitPerform_CreatedTask = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;

            WaitPerform_DoneResult = null;
        }
        public NiecTask(ScriptExecuteType executeType, NiecNraTask.NraFunction func)
        {
            if (executeType == ScriptExecuteType.None || executeType == ScriptExecuteType.InitFailed)
                _ScriptExecuteType = ScriptExecuteType.Task;
            else
                _ScriptExecuteType = executeType;
            mFunction = func;

            WaitPerform_WaitingCurrentTask = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;
            WaitPerform_CreatedTask = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;

            WaitPerform_DoneResult = null;
        }

        public static NiecTask CreateWaitPerform(NiecNraTask.NraFunction func)
        {
            Simulator.CheckYieldingContext(true);
            if (func == null)
                throw new ArgumentNullException("func");

            var niecTask = new NiecTask(func);
            niecTask.WaitPerform_WaitingCurrentTask = Simulator.CurrentTask;
            niecTask.WaitPerform_CreatedTask = niecTask.AddToSimulator();
            return niecTask;
        }

        public static NiecTask CreateWaitPerformWithExecuteType(ScriptExecuteType executeType, NiecNraTask.NraFunction func)
        {
            Simulator.CheckYieldingContext(true);
            if (func == null)
                throw new ArgumentNullException("func");

            var niecTask = new NiecTask(executeType, func);
            niecTask.WaitPerform_WaitingCurrentTask = Simulator.CurrentTask;
            niecTask.WaitPerform_CreatedTask = niecTask.AddToSimulator();
            return niecTask;
        }

        public static NiecTask CreateWaitPerformWithExecuteTypeSID(ScriptExecuteType executeType, NiecNraTask.NraFunction func)
        {
            Simulator.CheckYieldingContext(true);
            if (func == null)
                throw new ArgumentNullException("func");

            var niecTask = new NiecTask(executeType, func);
            niecTask.WaitPerform_WaitingCurrentTask = Simulator.CurrentTask;
            niecTask.WaitPerform_CreatedTask = niecTask.AddToSimulatorSID();
            return niecTask;
        }

        public static object SWaiting(NiecTask niecTask)
        {
            Simulator.CheckYieldingContext(true);
            if (niecTask == null)
                throw new ArgumentNullException("niecTask");

            if (niecTask.WaitPerform_DoneResult == null)
                Simulator.Sleep(uint.MaxValue);

            return niecTask.WaitPerform_DoneResult;
        }

        public object Waiting()
        {
            if (WaitPerform_DoneResult == null)
                Simulator.Sleep(uint.MaxValue);
            return WaitPerform_DoneResult;
        }

        public object WaitingCanThrow()
        {
            if (WaitPerform_DoneResult == null)
            {
                try
                {
                    Simulator.Sleep(uint.MaxValue);
                }
                catch (ResetException)
                {
                    if (!IsOpenDGSInstalled && UIManager.GetModalWindow() == null) 
                    {
                        ScriptCore.Simulator.Simulator_DestroyObjectImpl(ObjectId.Value); 
                    }

                    try
                    {
                        throw;
                    }
                    catch (ExecutionEngineException ex) // unprotected mono mscorlib 
                    {
                        ex.trace_ips = null;
                        ex.stack_trace = "";
                        ex.message = "";
                        NFinalizeDeath.ThrowResetException(null);
                        throw;
                    }
                    
                }
               
            }
            if (exThrow != null)
            {
                try
                {
                    throw new TargetInvocationException(exThrow);
                }
                finally
                {
                    exThrow = null;
                }
            }
            return WaitPerform_DoneResult;
        }

       

        public static NiecTask GetCurrentNiecTask() { 
            //return Simulator.GetTask(Simulator.CurrentTask) as NiecTask; // slow code
            return ScriptCore.Simulator.Simulator_GetTaskImpl(ScriptCore.Simulator.Simulator_GetCurrentTaskImpl(), false) as NiecTask; // fast code
        }

        public bool WaitingCurrentTaskIsDestroyed()
        {
            return NFinalizeDeath.ObjectGuid_IsDestroyed(WaitPerform_WaitingCurrentTask);
        }
        public virtual object TargetObject 
        {
            get
            {
                return GetTargetObject();
            }
        }

        public object GetTargetObject()
        {
            var fuc = mFunction;
            if (fuc == null)
                return null;
            return fuc.Target;
        }

        public static ObjectGuid Perform(NiecNraTask.NraFunction func)
        {
            try
            {
                if (func == null) 
                    throw new ArgumentNullException("func");
            }
            catch (Exception ex)
            {

                NiecException.WriteLog(ex.ToString(), true, true, false);
                throw;
            }
           
            return new NiecTask(func).AddToSimulator();
        }


        public static ObjectGuid Perform(ScriptExecuteType executeType, NiecNraTask.NraFunction func)
        {
            if (executeType == ScriptExecuteType.None || executeType == ScriptExecuteType.InitFailed)
                executeType = ScriptExecuteType.Task;

            if (func == null)
                return ObjectGuid.InvalidObjectGuid;

            return new NiecTask(executeType, func).AddToSimulator();
        }

        public static ObjectGuid PerformSID(ScriptExecuteType executeType, NiecNraTask.NraFunction func)
        {
            if (executeType == ScriptExecuteType.None || executeType == ScriptExecuteType.InitFailed)
                executeType = ScriptExecuteType.Task;

            if (func == null)
                return ObjectGuid.InvalidObjectGuid;

            return new NiecTask(executeType, func).AddToSimulatorSID();
        }




        public override ScriptExecuteType ExecuteType
        {
            get
            {
                return _ScriptExecuteType;
            }
        }

        public static ulong NonOpenDGSID = 0x00cfc00270000000;

        public static ulong NonOpenDGSIDSID = 0x00afc00200000000;

        //public bool NonRandom = false;
        //public ObjectGuid CurrentTaskID = NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid;


        public ObjectGuid AddToSimulator()
        {
            if (IsOpenDGSInstalled)
                return Simulator.AddObject(this);
            else {
                
                //NonRandom = true;

                var objectid = new ObjectGuid(NonOpenDGSID);
                NonOpenDGSID += 0x10;
                //CurrentTaskID = objectid;
                return Simulator.AddObjectWithId(this, objectid); 
            }
        }

        public ObjectGuid AddToSimulatorSID()
        {
            if (IsOpenDGSInstalled)
                return Simulator.AddObject(this);
            else
            {

                //NonRandom = true;

                var objectid = new ObjectGuid(NonOpenDGSIDSID);
                NonOpenDGSIDSID += 0x10;
                //CurrentTaskID = objectid;
                return Simulator.AddObjectWithId(this, objectid);
            }
        }

        protected virtual void OnPerform()
        { }

        public static void SimulateAgainRuntimeFound()
        {
            var niecTask = GetCurrentNiecTask();
            if (niecTask != null && niecTask.needNoErrorRuntime && !niecTask.needNoErrorRuntimeNoFound)
            {
                niecTask.needNoErrorRuntime = false;
                if (niecTask._ScriptExecuteType == ScriptExecuteType.Task)
                {
                    niecTask = null; // i know Saving task context failed.
                    for (int i = 0; i < 500; i++)
                    {
                        Simulator.Sleep(0);
                    }
                }
                else
                {
                    niecTask = null; // i know Saving task context failed.
                    Simulator.Sleep(200);
                }
            }
        }
        public static void SetNeedNoErrorRuntime(bool @value)
        {
            var niecTask = GetCurrentNiecTask();
            if (niecTask != null)
            {
                niecTask.needNoErrorRuntime = @value;
                niecTask.needNoErrorRuntimeNoFound = true;
            } 
            
        }
        public override void Simulate()
        {
            //mTaskC = Simulator.CurrentTask;
            //if (NonRandom) {
            //    base.ObjectId = CurrentTaskID;
            //}
            if (errorRuntimeFound)
            {
                if (!needNoErrorRuntime)
                {
                    if (ErrorRuntimeFound != null)
                        ErrorRuntimeFound.Append("\nDate: " + DateTime.Now.ToString() + "\nFailed to Mono Runtime!\n" + ToString());
                    ScriptCore.Simulator.Simulator_DestroyObjectImpl(ObjectId.Value);
                    return;
                }
                else { errorRuntimeFound = false; needNoErrorRuntimeNoFound = false; goto r; }
            }
            needNoErrorRuntimeNoFound = true;
            r:
            try
            {
                errorRuntimeFound = true;
                
                if (mFunction == null || mFunction.method_info == null || (!mFunction.Method.IsStatic && mFunction.Target == null))
                {
                    throw new NotSupportedException("NiecTask: mFunction GC BUG!");
                }
                else mFunction();
            }
            catch (Exception exception)
            {
                if (exception.StackTrace != null)
                    NiecException.WriteLog(ToString() + System.Environment.NewLine + System.Environment.NewLine + NiecException.LogException(exception), true, true, false);
                if (WaitPerform_WaitingCurrentTask != NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid)
                    exThrow = exception;
            }
#pragma warning disable 1058
            catch {
                NiecException.PrintMessagePro("Failed to Mono Runtime!\n" + ToString(), false, 10);
            }
#pragma warning restore 1058
           //finally
           //{
           //    //ResetFakeObjectId();
           //    Simulator.DestroyObject(ObjectId);
           //}
            finally
            {
                
                if (WaitPerform_WaitingCurrentTask != NiecMod.Helpers.NiecRunCommand.NiecInvalidObjectGuid)
                    Simulator.Wake(WaitPerform_WaitingCurrentTask);
                ScriptCore.Simulator.Simulator_DestroyObjectImpl(ObjectId.Value);
                //NonOpenDGSID -= 10;
            }
        }

        public override string ToString()
        {
            if (mFunction == null)
            {
                return "(NiecTask) NULL function";
            }
            else
            {
                return ("(NiecTask) Function method: " + this.mFunction.Method.ToString() + ", Declaring Type: " + this.mFunction.Method.DeclaringType.ToString());
            }
        }
    }
}
