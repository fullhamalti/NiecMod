using System;
using System.Collections.Generic;
using System.Text;

namespace NiecMod.Nra
{
    public static class NDebugger
    {
        private static IntPtr fileLogHandle = default(IntPtr); //= new IntPtr((int)uint.MaxValue);
        public static int fileLogHandleC = 0;
        private static IntPtr fileLogHandleL = default(IntPtr); //= new IntPtr((int)uint.MaxValue);
        public static int fileLogHandleCL = 0;

        public enum LogLevel
        {
            None,
            Debug,
            Trace,
            Error,
            FatelError,
            Warning,
            Info,
            Panic,
            Message,
            Note,
            Verbose
        }

        public enum TypeBreak
        {
            MessageBox,
            GameScriptFreeze,
            NativeBreak
        }

        public static bool IsAttached
        {
            get
            {
                return niec_native_func.IsDebuggerAttached();
            }
        }

        public static void Assert(string message)
        {
            NFinalizeDeath.AssertX(false, message);
        }

        //public static void Break()
        //{
        //    Break(TypeBreak.GameScriptFreeze, true);
        //}
        //public static void Break(TypeBreak type)
        //{
        //    Break(type, false);
        //}

        public static void Break(TypeBreak type = TypeBreak.GameScriptFreeze, bool force = true)
        {
            if (!IsAttached && !force)
                return;

            niec_native_func.OutputDebugString("Script Debugger Break!");
            NiecException.NewSendTextExceptionToDebugger();

            switch(type) {
                case TypeBreak.MessageBox:
                    niec_native_func.MessageBox(0, "NDBreak ST:\n" + GetCurrentStackLite(), "NiecMod", 0);
                    break;
                case TypeBreak.GameScriptFreeze:
                    try
                    {
                        while (true)
                        {
                            // Do nothing
                        }
                    }
                    catch (Exception)
                    { return; }
                case TypeBreak.NativeBreak:
                     niec_native_func.DebuggerBreak();
                     break;
                default:
                     throw new NotSupportedException();
            }
        }

        public static bool IsLogging()
        {
            return niec_native_func.cache_done_niecmod_native_debug_text_to_debugger || (niec_native_func.cache_done_niecmod_native_file_create && niec_native_func.cache_done_niecmod_native_file_write);
        }

        public static bool Launch()
        {
            if (IsAttached)
                return true;
            if ((int)niec_native_func.LoadDLLNativeLibrary("libDebuggerToSims3.dll") != 0)
                return true;
            return false;
        }

        public static bool LogLite(string text)
        {
            if (!(niec_native_func.cache_done_niecmod_native_file_create && niec_native_func.cache_done_niecmod_native_file_write))
                return false;

            if (text == null || text.Length == 0)
            {
                text = "LogLite: no text";
            }
            if (!niec_std.is_valid_handle(fileLogHandleL))
            {
                if (!niec_std.is_valid_handle(fileLogHandleL))
                {
                    fileLogHandleL = niec_native_func.niecmod_native_file_create("Sims 3 Logs\\" + "NiecMod LogL " + NFinalizeDeath.GetNowTimeToStr() + ".log");
                }
                if (!niec_std.is_valid_handle(fileLogHandleL))
                {
                    fileLogHandleL = niec_native_func.niecmod_native_file_create("C:\\Sims 3 Logs\\" + "NiecMod LogL " + NFinalizeDeath.GetNowTimeToStr() + ".log");
                }
                if (!niec_std.is_valid_handle(fileLogHandleL))
                {
                    niec_native_func.OutputDebugString("NDebugger:LogLite failed to create file!");
                    return false;
                }
            }

            var yyy = DateTime.Now.ToString("T") + ": " + text;
            var ttt = niec_native_func.WriteTextToFileA(fileLogHandleL, yyy) == 1;

            if (ttt)
            {
                fileLogHandleCL += yyy.Length;
                if (fileLogHandleCL > 1500000)
                {
                    fileLogHandleCL = 0; 
                    niec_native_func.niecmod_native_file_close(fileLogHandleL);
                    fileLogHandleL = default(IntPtr);
                }
            }
            else { fileLogHandleCL = 0; fileLogHandleL = default(IntPtr); }

            return ttt;
        }

        public static void Log(LogLevel level, string category, string message, bool stackTrace)
        {
            if (level == LogLevel.None && category == null && message == null && !stackTrace)
                return;

            if (IsLogging())
            {
                bool c = true;
                if (niec_native_func.cache_done_niecmod_native_file_create && niec_native_func.cache_done_niecmod_native_file_write)
                {
                    if (!niec_std.is_valid_handle(fileLogHandle))
                    {
                        fileLogHandle = niec_native_func.niecmod_native_file_create("Sims 3 Logs\\" + "NiecMod Log " + NFinalizeDeath.GetNowTimeToStr() + ".log");
                    }
                    if (!niec_std.is_valid_handle(fileLogHandle))
                    {
                        fileLogHandle = niec_native_func.niecmod_native_file_create("C:\\Sims 3 Logs\\" + "NiecMod Log " + NFinalizeDeath.GetNowTimeToStr() + ".log");
                    }
                    if (niec_std.is_valid_handle(fileLogHandle))
                    {
                        //if (level != LogLevel.None)
                        //    niec_native_func.niecmod_native_file_writetext(fileLogHandle,DateTime.Now.ToString("T") + " Level: " + level);
                        //if (category != null)
                        //    niec_native_func.niecmod_native_file_writetext(fileLogHandle, DateTime.Now.ToString("T") + " Category: " + category);
                        //
                        //niec_native_func.niecmod_native_file_writetext(fileLogHandle, DateTime.Now.ToString("T") + (message != null && message.Length > 0 ? " Message: " + message : " No Message"));
                        //
                        //if (stackTrace)
                        //    niec_native_func.niecmod_native_file_writetext(fileLogHandle, DateTime.Now.ToString("T") + " Stack Trace:\n" + CurrentStack());
                        //

                        if (level != LogLevel.None)
                           c = niec_native_func.WriteTextToFileA(fileLogHandle,DateTime.Now.ToString("T") + ": Level: " + level + "\n") == 1;

                        if (!c)
                            goto t;

                        if (category != null)
                            c = niec_native_func.WriteTextToFileA(fileLogHandle, DateTime.Now.ToString("T") + ": Category: " + category + "\n") == 1;

                        if (!c)
                            goto t;

                        c = niec_native_func.WriteTextToFileA
                            (fileLogHandle, DateTime.Now.ToString("T") + (message != null && message.Length > 0 ? ": Message: " + message : ": No Message") + "\n") == 1;

                        if (!c)
                            goto t;

                        if (stackTrace)
                        {
                            var ttt = DateTime.Now.ToString("T") + ": Stack Trace:\n" + GetCurrentStack() + "\n";
                            fileLogHandleC += ttt.Length;
                            c = niec_native_func.WriteTextToFileA(fileLogHandle, ttt) == 1;
                        }
                        if (!c)
                            goto t;

                       // niec_native_func.WriteTextToFileA(fileLogHandle, "\n\n\n");

                        fileLogHandleC += (message != null ? message.Length : 0);
                        if (fileLogHandleC > 3500000)
                        {
                            fileLogHandleC = 0;
                            niec_native_func.niecmod_native_file_close(fileLogHandle);
                            fileLogHandle = default(IntPtr);
                        }

                        niec_native_func.OutputDebugString("NDebugger created log Done.");
                        return;
                    }
                    else c = false;
                }

            t:
                if (!c)
                {
                    fileLogHandleC = 0;
                    fileLogHandle = default(IntPtr);
                }

               niec_native_func.OutputDebugString("NDebugger log");

                if (level != LogLevel.None)
                    niec_native_func.OutputDebugString("Level: " + level);
                if (category != null)
                    niec_native_func.OutputDebugString("Category: " + category);

                niec_native_func.OutputDebugString(message != null && message.Length > 0 ? "Message: " + message : "No Message");

                if (stackTrace)
                    niec_native_func.OutputDebugString("Stack Trace:\n" + GetCurrentStack());
            }
        }

        public static string GetCurrentStack()
        {
            try
            {
                throw new Exception("");
            }
            catch (Exception ex)
            {
                return ex.stack_trace; // Created if mono native ex.StackTrace
            }
        }

        public static string GetCurrentStackLite()
        {
            var st = new NStackTrace(1);
            var sb = new StringBuilder();

            for (int stack = 0; stack < st.FrameCount; stack++)
            {
                var sf = st.GetFrame(stack);
                if (sf == null)
                    continue;

                var m = sf.methodBase;
                if (m == null)
                    continue;

                sb.Append(m.DeclaringType.Name);
                sb.Append("::");
                sb.Append(m.Name);
                sb.Append('\n');
            }

            return sb.ToString();
        }

        public static string GetCurrentStackLiteLast()
        {
            var st = new NStackTrace(1);
            var sb = new StringBuilder();

            for (int stack = st.FrameCount - 1; stack >= 0; stack--)
            {
                var sf = st.GetFrame(stack);
                if (sf == null)
                    continue;

                var m = sf.methodBase;
                if (m == null)
                    continue;

                sb.Append(m.DeclaringType.Name);
                sb.Append("::");
                sb.Append(m.Name);
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
