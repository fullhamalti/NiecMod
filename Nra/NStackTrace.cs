using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace NiecMod.Nra
{
    public class NStackTrace // : StackTrace
    {
        public StackFrame[] Frames = null;

        public bool DebugInfo = false;

        public int FrameCountFast = 0;

        public int FrameCount
        {
            get
            {
                if (Frames != null)
                {
                    return Frames.Length;
                }
                return 0;
            }
        }

        public StackFrame GetFrame(int index)
        {
            if (Frames == null || index < 0 || index >= FrameCount)
            {
                return null;
            }
            return Frames[index];
        }

        public StackFrame GetFrameFast(int index)
        {
            if (Frames == null || index < 0 || index >= FrameCountFast)
            {
                return null;
            }
            return Frames[index];
        }

        public string GetNameMethod(int index) {
            var frame = GetFrameFast(index);
            if (frame == null) 
                return null;
            var methodInfo = frame.methodBase;
            if (methodInfo == null)
                return null;
            return methodInfo.DeclaringType.FullName + "." + methodInfo.Name + "()";
        }

        public NStackTrace() { }

        public NStackTrace(bool needFileInfo)
        {
            InitFrames(0, needFileInfo);
        }

        public NStackTrace(int skipFrames)
        {
            InitFrames(skipFrames, false);
        }

        public NStackTrace(int skipFrames, bool needFileInfo)
        {
            InitFrames(skipFrames, needFileInfo);
        }
        // unprotected mono mscorlib 
        public static void InitFrame(StackFrame frame, int skipFrames, bool needFileInfo) // fast code.  Mono Interpreter only
        {
            if (frame == null)
                throw new NullReferenceException();
            StackFrame.get_frame_info(skipFrames + 2, needFileInfo, out frame.methodBase, out frame.ilOffset, out frame.nativeOffset, out frame.fileName, out frame.lineNumber, out frame.columnNumber);
        }
        public static void InitFrameLast(StackFrame frame, int skipFrames, bool needFileInfo) // fast code.  Mono Interpreter only
        {
            if (frame == null)
                throw new NullReferenceException();
            StackFrame.get_frame_info(skipFrames, needFileInfo, out frame.methodBase, out frame.ilOffset, out frame.nativeOffset, out frame.fileName, out frame.lineNumber, out frame.columnNumber);
        }
        private static StackFrame s_stack_frame_ = null;
        public static bool FastIsCallStackMethed(System.Reflection.MethodBase methed, bool last) // fast code.  Mono Interpreter only
        {
            if (methed == null)
                throw new ArgumentNullException();
            if (s_stack_frame_ == null) // GC low ram
            {
                s_stack_frame_ = new StackFrame();
            }
            if (last)
            {
                for (int stack = 64 - 1; stack >= 0; stack--)
                {
                    InitFrameLast(s_stack_frame_, stack, false);
                   // var mb = s_stack_frame_.methodBase;
                    if (s_stack_frame_.methodBase == methed)
                        return true;
                }
            }
            else
            {
                for (int stack = 1; stack < 64; stack++)
                {
                    // var stackFrame = new StackFrame(i, false);
                    InitFrame(s_stack_frame_, stack, false);
                    var mb = s_stack_frame_.methodBase;
                    if (mb == null)
                        break;
                    if (mb == methed)
                        return true;

                }
            }
            return false;
        }
        public static bool IsCallingMyMethedLite(string text, bool co, int skip)
        {
            if (text == null)
                throw new ArgumentNullException();

            StackFrame sf = new StackFrame(skip);

            var _method = sf.GetMethod(); // unport mscorlib
            if (_method == null)
                return false;

            string temp = _method.DeclaringType.FullName + "::" + _method.Name;

            if ((co && temp.Contains(text)) || temp == text)
                return true;

            return false;
        }
        public void InitFrames(int skipFrames, bool needFileInfo)
        {
            if (skipFrames < 0)
                throw new ArgumentOutOfRangeException("skipFrames", "Can't be less than 0.");

            if (skipFrames > 63)
                throw new ArgumentOutOfRangeException("skipFrames", "skipFrames >= 64");

            //List<StackFrame> arrayList = new List<StackFrame>(63);
            var arrayList = new StackFrame[64];

            skipFrames += 2;
            StackFrame stackFrame;
            int i;

            for (i = 0; i < arrayList.Length; i++)
            {
                stackFrame = new StackFrame(skipFrames, needFileInfo);
                if (stackFrame.methodBase == null) 
                    break;

                //arrayList.Add(stackFrame);
                arrayList[i] = stackFrame;

                skipFrames++;
            }

            if (i != 0)
                FrameCountFast = i + 1;

            

            DebugInfo = needFileInfo;

            //frames = arrayList.ToArray();
            Frames = arrayList;
            //NFinalizeDeath.Assert(FrameCountFast == FrameCount, "FrameCountFast == FrameCount failed.\nFrameCountFast: " + FrameCountFast + "FrameCount: " + FrameCount);
        }
    }
}
