using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NiecMod.Nra
{
    // Kill Mono Security ;)
    public class niec_native_func
    {
        [Flags]
        public enum MB_Type : uint
        {
            MB_OK = 0x00000000u,
            MB_OKCANCEL = 0x00000001u,
            MB_ABORTRETRYIGNORE = 0x00000002u,
            MB_YESNOCANCEL = 0x00000003u,
            MB_YESNO = 0x00000004u,
            MB_RETRYCANCEL = 0x00000005u,

            MB_CANCELTRYCONTINUE = 0x00000006u,

            MB_ICONHAND = 0x00000010u,
            MB_ICONQUESTION = 0x00000020u,
            MB_ICONEXCLAMATION = 0x00000030u,
            MB_ICONASTERISK = 0x00000040u,

            MB_USERICON = 0x00000080u,

            MB_DEFBUTTON1 = 0x00000000u,
            MB_DEFBUTTON2 = 0x00000100u,
            MB_DEFBUTTON3 = 0x00000200u,

            MB_DEFBUTTON4 = 0x00000300u,

            MB_APPLMODAL = 0x00000000u,
            MB_SYSTEMMODAL = 0x00001000u,
            MB_TASKMODAL = 0x00002000u,

            MB_HELP = 0x00004000u, // Heup Button

            MB_NOFOCUS = 0x00008000u,
            MB_SETFOREGROUND = 0x00010000u,
            MB_DEFAULT_DESKTOP_ONLY = 0x00020000u,

            MB_TOPMOST = 0x00040000u,
            MB_RIGHT = 0x00080000u,
            MB_RTLREADING = 0x00100000u,

            MB_SERVICE_NOTIFICATION = 0x00200000u,

            MB_SERVICE_NOTIFICATION2 = 0x00040000u,

            MB_SERVICE_NOTIFICATION_NT3X = 0x00040000u,

            MB_TYPEMASK = 0x0000000Fu,
            MB_ICONMASK = 0x000000F0u,
            MB_DEFMASK = 0x00000F00u,
            MB_MODEMASK = 0x00003000u,
            MB_MISCMASK = 0x0000C000u
        }

        public enum ResultMB : int
        {
            IDOK = 1,
            IDCANCEL = 2,
            IDABORT = 3,
            IDRETRY = 4,
            IDIGNORE = 5,
            IDYES = 6,
            IDNO = 7,
            IDCLOSE = 8,
            IDHELP = 9
        }

        internal static bool cache_done_niecmod_native_debug_text_to_debugger = false;
        internal static bool cache_done_niecmod_native_load_library           = false;
        internal static bool cache_done_IsDebuggerAttached_internal           = false;
        internal static bool cache_done_IsDebuggerBreak_internal              = false;
        internal static bool cache_done_niecmod_native_ptr_fs_zero            = false;
        internal static bool cache_done_niecmod_native_message_box            = false;
        internal static bool cache_done_niecmod_native_cpuid                  = false;
        internal static bool cache_done_niecmod_native_file_create            = false;
        internal static bool cache_done_niecmod_native_file_writetext         = false;
        internal static bool cache_done_niecmod_native_file_write             = false;
        internal static bool cache_done_niecmod_native_file_close             = false;
        private static bool done_init_class                                   = false;

        private const string native00 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM0";
        private const string native01 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM1";
        private const string native02 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM2";
        private const string native03 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM3";
        private const string native04 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM4";
        private const string native05 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM5";
        private const string native06 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM6";
        private const string native07 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM7";
        private const string native08 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM8";
        private const string native09 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM9";
        private const string native10 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM10";
        private const string native11 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM11";
        private const string native12 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM12";
        private const string native13 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM13";
        private const string native14 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM14";
        private const string native15 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM15";
        private const string native16 = "ÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌÌnM16";

        public unsafe static void init_class()
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                throw new NotSupportedException("Sims 3 64 bit version not supported.");

#if !GameVersion_0_Release_2_0_209
            throw new NotSupportedException("Game versions not supported. Only Patch 1.67.2");
#else

            if (done_init_class)
                return;

            done_init_class = true;

            var type = typeof(niec_native_func);
            var m01 = (MonoMethod)type.GetMethod("niecmod_native_load_library", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            //uint* at = (uint*)0;
            uint func_address = 0;
            int tem = 0;

            if (m01 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_load_library\") failed");
                done_init_class = false;
                goto skip2;
            }

            //at = (uint*)((int)m01.mhandle.obj_address());
            tem = native00.Length + native00.Length
                - 0x32;

            var native00_address = (uint)native00.obj_address();
            func_address = native00_address + 0x14;


            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native00_address + i) = 0xCCCCCCCC;
            }

            native00.obj_address(); // check SIGSEGV 

            *(uint*)(func_address)        =  NFinalizeDeath.SwapOrgerBit32(0x908B5C24u);
            *(uint*)(func_address + 0x4)  =  NFinalizeDeath.SwapOrgerBit32(0x0483C308u);
            *(uint*)(func_address + 0x8)  =  NFinalizeDeath.SwapOrgerBit32(0x53FF1580u);
            *(uint*)(func_address + 0xC)  =  NFinalizeDeath.SwapOrgerBit32(0x62F90090u);
            *(uint*)(func_address + 0x10) =  NFinalizeDeath.SwapOrgerBit32(0xC3909090u);

            cache_done_niecmod_native_load_library =
                niec_script_func.niecmod_script_set_custom_native_function(m01.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            skip2:
            var m02 = (MonoMethod)type.GetMethod("niecmod_native_debug_text_to_debugger", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m02 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_debug_text_to_debugger\") failed");
                done_init_class = false;
                goto skip3;
            }

            //at = (uint*)((int)m02.mhandle.obj_address());
            tem = native01.Length + native01.Length
                - 0x32;

            var native01_address = (uint)native01.obj_address();
            func_address = native01_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native01_address + i) = 0xCCCCCCCC;
            }

            native01.obj_address(); // check SIGSEGV 

            *(uint*)(func_address)        = NFinalizeDeath.SwapOrgerBit32(0x608B4C24u);
            *(uint*)(func_address + 0x4)  = NFinalizeDeath.SwapOrgerBit32(0x2483C108u);
            *(uint*)(func_address + 0x8)  = NFinalizeDeath.SwapOrgerBit32(0x51FF1514u);
            *(uint*)(func_address + 0xC)  = NFinalizeDeath.SwapOrgerBit32(0x63F90061u);
            *(uint*)(func_address + 0x10) = NFinalizeDeath.SwapOrgerBit32(0xC3909090u);

            cache_done_niecmod_native_debug_text_to_debugger = 
                niec_script_func.niecmod_script_set_custom_native_function(m02.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            skip3:
            var m03 = (MonoMethod)type.GetMethod("IsDebuggerAttached_internal", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m03 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"IsDebuggerAttached_internal\") failed");
                goto skip4;
            }

            tem = native02.Length + native02.Length
                - 0x32;

            var native02_address = (uint)native02.obj_address();
            func_address = native02_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native02_address + i) = 0xCCCCCCCC;
            }

            native02.obj_address(); // check SIGSEGV 

            *(uint*)(func_address)       = NFinalizeDeath.SwapOrgerBit32(0x64A13000u);
            *(uint*)(func_address + 0x4) = NFinalizeDeath.SwapOrgerBit32(0x00000FB6u);
            *(uint*)(func_address + 0x8) = NFinalizeDeath.SwapOrgerBit32(0x4002C390u);

            cache_done_IsDebuggerAttached_internal =
                niec_script_func.niecmod_script_set_custom_native_function(m03.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip4:
            var m04 = (MonoMethod)type.GetMethod("DebuggerBreak", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m04 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"DebuggerBreak\") failed");
                goto skip5;
            }

            tem = native03.Length + native03.Length
                - 0x32;

            var native03_address = (uint)native03.obj_address();
            func_address = native03_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native03_address + i) = 0xCCCCCCCC;
            }

            native03.obj_address(); // check SIGSEGV 

            *(uint*)(func_address) = NFinalizeDeath.SwapOrgerBit32(0xCCC3CCCCu);

            cache_done_IsDebuggerBreak_internal =
                niec_script_func.niecmod_script_set_custom_native_function(m04.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip5:
            var m05 = (MonoMethod)type.GetMethod("niecmod_native_ptr_fs_zero", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m05 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_ptr_fs_zero\") failed");
                goto skip6;
            }

            tem = native04.Length + native04.Length
                - 0x32;

            var native04_address = (uint)native04.obj_address();
            func_address = native04_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native04_address + i) = 0xCCCCCCCC;
            }

            native04.obj_address(); // check SIGSEGV 

            *(uint*)(func_address)       = NFinalizeDeath.SwapOrgerBit32(0x8B5C2404u);
            *(uint*)(func_address + 0x4) = NFinalizeDeath.SwapOrgerBit32(0x648B0331u);
            *(uint*)(func_address + 0x8) = NFinalizeDeath.SwapOrgerBit32(0xDBC3CCCCu);

            cache_done_niecmod_native_ptr_fs_zero =
                niec_script_func.niecmod_script_set_custom_native_function(m05.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip6:
            var m06 = (MonoMethod)type.GetMethod("niecmod_native_message_box", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m06 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_message_box\") failed");
                goto skip7;
            }

            tem = native05.Length + native05.Length
                - 0x32;

            var native05_address = (uint)native05.obj_address();
            func_address = native05_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native05_address + i) = 0xCCCCCCCC;
            }

            native05.obj_address(); // check SIGSEGV 

            byte[] nativefunc_messagebox = {
            	0x8B, 0x5C, 0x24, 0x08, 0x83, 0xC3, 0x08, 0x89, 0x5C, 0x24, 0x08, 0x8B,
            	0x5C, 0x24, 0x0C, 0x83, 0xC3, 0x08, 0x89, 0x5C, 0x24, 0x0C, 0x83, 0xEC,
            	0x08, 0x8B, 0x5C, 0x24, 0x08, 0x89, 0x5C, 0x24, 0x04, 0xFF, 0x74, 0x24,
            	0x18, 0xFF, 0x74, 0x24, 0x18, 0xFF, 0x74, 0x24, 0x18, 0xFF, 0x74, 0x24,
            	0x18, 0xFF, 0x15, 0x00, 0x68, 0xF9, 0x00, 0x83, 0xC4, 0x08, 0xC3, 0xCC
            };

            for (int i = 0; i < nativefunc_messagebox.Length; i++)
            {
                *(byte*)(func_address + i) = nativefunc_messagebox[i];
            }

            cache_done_niecmod_native_message_box =
                niec_script_func.niecmod_script_set_custom_native_function(m06.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip7:
            var m07 = (MonoMethod)type.GetMethod("niecmod_native_cpuid", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m07 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_cpuid\") failed");
                goto skip8;
            }

            tem = native06.Length + native06.Length
                - 0x32;

            var native06_address = (uint)native06.obj_address();
            func_address = native06_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native06_address + i) = 0xCCCCCCCC;
            }

            native06.obj_address(); // check SIGSEGV 

            byte[] nativefunc_cpuid = {
	            0x60, 0x8B, 0x44, 0x24, 0x24, 0x8B, 0x5C, 0x24, 0x28, 0x8B, 0x4C, 0x24,
	            0x2C, 0x8B, 0x54, 0x24, 0x30, 0x8B, 0x00, 0x8B, 0x1B, 0x8B, 0x09, 0x8B,
	            0x12, 0x0F, 0xA2, 0x55, 0x89, 0xE5, 0x83, 0xEC, 0x10, 0x89, 0x04, 0x24,
	            0x89, 0x5C, 0x24, 0x04, 0x89, 0x4C, 0x24, 0x08, 0x89, 0x54, 0x24, 0x0C,
	            0x8B, 0x44, 0x24, 0x38, 0x8B, 0x5C, 0x24, 0x3C, 0x8B, 0x4C, 0x24, 0x40,
	            0x8B, 0x54, 0x24, 0x44, 0x8B, 0x3C, 0x24, 0x89, 0x38, 0x8B, 0x7C, 0x24,
	            0x04, 0x89, 0x3B, 0x8B, 0x7C, 0x24, 0x08, 0x89, 0x39, 0x8B, 0x7C, 0x24,
	            0x0C, 0x89, 0x3A, 0x83, 0xC4, 0x10, 0x5D, 0x61, 0xC3
            };

            for (int i = 0; i < nativefunc_cpuid.Length; i++)
            {
                *(byte*)(func_address + i) = nativefunc_cpuid[i];
            }

            cache_done_niecmod_native_cpuid =
                niec_script_func.niecmod_script_set_custom_native_function(m07.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip8:
            var m08 = (MonoMethod)type.GetMethod("niecmod_native_file_create", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m08 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_file_create\") failed");
                goto skip9;
            }

            tem = native07.Length + native07.Length
                - 0x32;

            var native07_address = (uint)native07.obj_address();
            func_address = native07_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native07_address + i) = 0xCCCCCCCC;
            }

            native07.obj_address(); // check SIGSEGV 

            byte[] createfile_func = {
            	0x8B, 0x5C, 0x24, 0x04, 0x83, 0xC3, 0x08, 0x90, 0x90, 0x90, 0x90, 0x90,
            	0x90, 0x90, 0x31, 0xC0, 0x50, 0x68, 0x00, 0x00, 0x00, 0x80, 0x6A, 0x02,
            	0x50, 0x6A, 0x03, 0x68, 0x00, 0x00, 0x00, 0x40, 0x53, 0x90, 0x90, 0x90,
            	0x90, 0xFF, 0x15, 0x54, 0x63, 0xF9, 0x00, 0x31, 0xDB, 0xC3, 0x90, 0x90,
            	0x90, 0x90, 0x90, 0x90
            };

            for (int i = 0; i < createfile_func.Length; i++)
            {
                *(byte*)(func_address + i) = createfile_func[i];
            }

            cache_done_niecmod_native_file_create =
                niec_script_func.niecmod_script_set_custom_native_function(m08.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip9:
            var m09 = (MonoMethod)type.GetMethod("niecmod_native_file_writetext", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m09 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_file_writetext\") failed");
                goto skip10;
            }

            tem = native08.Length + native08.Length
                - 0x32;

            var native08_address = (uint)native08.obj_address();
            func_address = native08_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native08_address + i) = 0xCCCCCCCC;
            }

            native08.obj_address(); // check SIGSEGV 

            byte[] writetext_func = {
	            0x8B, 0x44, 0x24, 0x08, 0x83, 0xC0, 0x08, 0x8B, 0x5C, 0x24, 0x08, 0x83,
	            0xC3, 0x04, 0x8B, 0x1B, 0x01, 0xDB, 0x90, 0x90, 0x90, 0x31, 0xD2, 0x52,
	            0x52, 0x53, 0x50, 0xFF, 0x74, 0x24, 0x14, 0xFF, 0x15, 0x94, 0x63, 0xF9,
	            0x00, 0xC3
            };

            for (int i = 0; i < writetext_func.Length; i++)
            {
                *(byte*)(func_address + i) = writetext_func[i];
            }

            cache_done_niecmod_native_file_writetext =
                niec_script_func.niecmod_script_set_custom_native_function(m09.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip10:
            var m10 = (MonoMethod)type.GetMethod("niecmod_native_file_write", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m10 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_file_write\") failed");
                goto skip11;
            }

            tem = native09.Length + native09.Length
                - 0x32;

            var native09_address = (uint)native09.obj_address();
            func_address = native09_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native09_address + i) = 0xCCCCCCCC;
            }

            native09.obj_address(); // check SIGSEGV 

            byte[] write_func = {
	            0x31, 0xDB, 0x53, 0x53, 0xFF, 0x74, 0x24, 0x14, 0xFF, 0x74, 0x24, 0x14,
	            0xFF, 0x74, 0x24, 0x14, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90,
	            0x90, 0x90, 0x90, 0x90, 0x90, 0xFF, 0x15, 0x94, 0x63, 0xF9, 0x00, 0xC3
            };

            for (int i = 0; i < write_func.Length; i++)
            {
                *(byte*)(func_address + i) = write_func[i];
            }

            cache_done_niecmod_native_file_write =
                niec_script_func.niecmod_script_set_custom_native_function(m10.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            skip11:
            var m11 = (MonoMethod)type.GetMethod("niecmod_native_file_close", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (m11 == null)
            {
                NFinalizeDeath.Assert("type.GetMethod(\"niecmod_native_file_close\") failed");
                throw new NotSupportedException();
            }

            tem = native10.Length + native10.Length
                - 0x32;

            var native10_address = (uint)native10.obj_address();
            func_address = native10_address + 0x14;

            for (int i = 0x10; i < tem; i++)
            {
                *(uint*)(native10_address + i) = 0xCCCCCCCC;
            }

            native10.obj_address(); // check SIGSEGV 

            byte[] fileclose_func = {
	            0xFF, 0x74, 0x24, 0x04, 0x90, 0xFF, 0x15, 0x9C, 0x63, 0xF9, 0x00, 0xC3
            };

            for (int i = 0; i < fileclose_func.Length; i++)
            {
                *(byte*)(func_address + i) = fileclose_func[i];
            }

            cache_done_niecmod_native_file_close =
                niec_script_func.niecmod_script_set_custom_native_function(m11.mhandle, new IntPtr() { value = (void*)func_address });

            ////////////////////////////////////////////////////////////////////////////////

            if (m01 != null)
                OutputDebugString("niecmod_native_load_library: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m01.mhandle).ToString("X"));
            if (m02 != null)
                OutputDebugString("niecmod_native_debug_text_to_debugger: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m02.mhandle).ToString("X"));
            if (m03 != null)
                OutputDebugString("IsDebuggerAttached_internal: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m03.mhandle).ToString("X"));
            if (m04 != null)
                OutputDebugString("DebuggerBreak: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m04.mhandle).ToString("X"));
            if (m05 != null)
                OutputDebugString("niecmod_native_ptr_fs_zero: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m05.mhandle).ToString("X"));
            if (m06 != null)
                OutputDebugString("niecmod_native_message_box: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m06.mhandle).ToString("X"));
            if (m07 != null)
                OutputDebugString("niecmod_native_cpuid: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m07.mhandle).ToString("X"));
            if (m08 != null)
                OutputDebugString("niecmod_native_file_create: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m08.mhandle).ToString("X"));
            if (m09 != null)
                OutputDebugString("niecmod_native_file_writetext: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m09.mhandle).ToString("X"));
            if (m10 != null)
                OutputDebugString("niecmod_native_file_write: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m10.mhandle).ToString("X"));
            if (m11 != null)
                OutputDebugString("niecmod_native_file_close: func_address: 0x" + niec_script_func.niecmod_script_get_func_ptr(m11.mhandle).ToString("X"));
#endif // GameVersion_0_Release_2_0_209
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool niecmod_native_custom_test(); // DEBUG Only
      /*{
          Code for x86:
            mov al,1
            ret  
       
          C++ code:
            return true;
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool niecmod_native_custom_test_C(); // DEBUG Only
      /*{
          Code for x86:
            mov al,1
            ret  
       
          C++ code:
            return true;
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr niecmod_native_load_library(string pathOrDllFileName);
      /*{
          Code for x86:
           mov ebx,[esp+4]
           add ebx,8
           push ebx
           call [0x00F96280] // LoadLibraryW
           ret 
       
          C++ code:
           return LoadLibraryW(pathOrDllFileName);
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void niecmod_native_debug_text_to_debugger(string str);
      /*{
          Code for x86:
            pushad 
            mov ecx,[esp+24]
            add ecx,8
            push ecx
            call [0x00F96314] // OutputDebugStringW
            popad 
            ret  
       
          C++ code:
            OutputDebugStringW(str);
            return;
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int IsDebuggerAttached_internal();
      /*{
          Code for x86:
            mov eax,dword ptr fs:[30]
            movzx eax,byte ptr ds:[eax+2]
            ret 
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void DebuggerBreak();
      /*{
          Code for x86:
            int3
            ret 
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr niecmod_native_ptr_fs_zero(int offset);
      /*{
           Code for x86:
            mov ebx,[esp+4]
            mov eax,dword ptr fs:[ebx]
            xor ebx,ebx
            ret 
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern ResultMB niecmod_native_message_box(uint hWnd, string text, string caption, MB_Type uType);
      /*{
          Code for x86:
            mov ebx,[esp+8]
            add ebx,8
            mov [esp+8],ebx
            mov ebx,[esp+C]
            add ebx,8
            mov [esp+C],ebx
            sub esp,8
            mov ebx,[esp+8]
            mov [esp+4],ebx
            push [esp+18]
            push [esp+18]
            push [esp+18]
            push [esp+18]
            call [0x00F96800] // MessageBoxW
            add esp,8
            ret 
       
          C++ code:
            return MessageBoxW(hWnd, text, caption, uType);
        }*/

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void niecmod_native_cpuid(ref uint eax, ref uint ebx, ref uint ecx, ref uint edx);
      /*{
          Code for x86:
            pushad 
            mov eax,[esp+24]
            mov ebx,[esp+28]
            mov ecx,[esp+2C]
            mov edx,[esp+30]
            mov eax,[eax]
            mov ebx,[ebx]
            mov ecx,[ecx]
            mov edx,[edx]
            cpuid 
            push ebp
            mov ebp,esp
            sub esp,10
            mov [esp],eax
            mov [esp+4],ebx
            mov [esp+8],ecx
            mov [esp+C],edx
            mov eax,[esp+38]
            mov ebx,[esp+3C]
            mov ecx,[esp+40]
            mov edx,[esp+44]
            mov edi,[esp]
            mov [eax],edi
            mov edi,[esp+4]
            mov [ebx],edi
            mov edi,[esp+8]
            mov [ecx],edi
            mov edi,[esp+C]
            mov [edx],edi
            add esp,10
            pop ebp
            popad 
            ret 
       
          C++ code:
            _cpuid_(&eax, &ebx, &ecx, &edx);
            return;
        }*/

        

        public static bool IsDebuggerAttached()
        {
            if (cache_done_IsDebuggerAttached_internal && IsDebuggerAttached_internal() == 1)
                return true;
            return false;
        }

        public static void OutputDebugString(string str) { 
            //if (niec_script_func.niecmod_script_get_func_ptr((typeof(niec_native_func).GetMethod("niecmod_native_debug_text_to_debugger") as MonoMethod).mhandle) == 0)
            if (!cache_done_niecmod_native_debug_text_to_debugger)
                return;

            if (str == null)
                str = "NiecMod: message is null";

            if (str.Length == 0)
                str = "NiecMod: no message";

            str = str.Replace((char)0x0D, (char)0x0A); //str.Replace("\u4888", "");

            niecmod_native_debug_text_to_debugger(str);
        }

        public static IntPtr LoadDLLNativeLibrary(string pathOrDllFileName)
        {
            //if (niec_script_func.niecmod_script_get_func_ptr((typeof(niec_native_func).GetMethod("niecmod_native_load_library") as MonoMethod).mhandle) == 0)
            if (!cache_done_niecmod_native_load_library)
                return new IntPtr(0);

            if (pathOrDllFileName == null || pathOrDllFileName.Length == 0)
                throw new ArgumentNullException("pathOrDllFileName");

            return niecmod_native_load_library(pathOrDllFileName);
        }

        public static ResultMB MessageBox(uint hWnd, string text, string caption, MB_Type uType)
        {
            if (!cache_done_niecmod_native_message_box)
                return (ResultMB)0;

            if (text == null)
                throw new ArgumentNullException("text");
            if (caption == null)
                throw new ArgumentNullException("caption");

            return niecmod_native_message_box(hWnd, text, caption, uType);
        }

        //public static byte[] ReadFile(string path)
        //{
        //    if (path == null || path.Length == 0)
        //        throw new ArgumentNullException("path");
        //
        //    var p = niecmod_native_file_read(path);
        //    if ((uint)p == 0)
        //        throw new ArgumentException();
        //
        //    var r = new byte[20000];
        //    Marshal.Copy(p, r, 0, 100);
        //    return r;
        //}

        public unsafe static int WriteTextToFileA(IntPtr handle, string text) // UTF-8
        {
            if (!cache_done_niecmod_native_file_write || text == null || text.Length == 0 || !niec_std.is_valid_handle(handle))
                return 0;

            var tttl = text.Length;
            //if (tttl == 0)
            //    tttl = 1;
            var ttta = Marshal.StringToHGlobalAnsi(text);

            return niecmod_native_file_write(handle, ttta, tttl);
            //Marshal.FreeHGlobal(ttta);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void niecmod_native_rdtsc(out uint eax, out uint edx);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr niecmod_native_call_function(IntPtr funcAddress);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void niecmod_native_exit_game(int exitcode);


        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr niecmod_native_obj_get_address(object obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern uint niecmod_native_obj_get_address_nonptr(object obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern ulong niecmod_native_obj_get_address_nonptr_64bit(object obj);


        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern object niecmod_native_get_object_for_ptr(IntPtr obj_address);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern object niecmod_native_get_object_for_nonptr(uint obj_address);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern object niecmod_native_get_object_for_nonptr_64bit(ulong obj_address);


        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern T niecmod_native_get_classobject_for_ptr<T>(IntPtr obj_address);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern T niecmod_native_get_classobject_for_nonptr<T>(object obj);

        public unsafe static void* NonMonoObjectAsPointer(object obj) //void* ptr = (void*)obj; don't compile
        {
            if (obj == null)
                return (void*)0;
            return (void*)niecmod_native_get_classobject_for_nonptr<IntPtr>(obj).value;
        }

        public unsafe static void* MonoObjectAsPointer(object obj) //void* ptr = (void*)obj; don't compile
        {
            if (obj == null)
                return (void*)0;
            return (void*)obj.obj_address().value;
        }

        public unsafe static object[] GetNewPtrAllocStr(int len)
        {
            if (len < 0)
                throw new ArgumentOutOfRangeException("len");

            string eee = string.InternalAllocateStr(len);
            uint tt = (uint)(eee.obj_address()) + (uint)RuntimeHelpers.OffsetToStringData;
            IntPtr yyy = new IntPtr() { value = (void*)tt };
            int le = eee.Length * 2;

            return new object[] { eee, yyy, le };
        }

        public unsafe static IntPtr StringToCoTaskMemAnsi(string s)
        {
            int len2 = s.Length;
            int len = len2 + 1;

            IntPtr intPtr = Marshal.AllocCoTaskMem(len);
            uint t = (uint)intPtr.value;

            fixed (char* ptr = s)
            {
                for (int i = 0; i < len2; i++)
                {
                    *(short*)(t + i) = *(short*)(ptr + i);
                }
            }

            OutputDebugString("StringToCoTaskMemAnsi: 0x" + t.ToString("X"));

            return intPtr;
        }

        public unsafe static object[] StringToScriptMemAnsi(string s)
        {
            int len2 = s.Length;
            if (len2 == 0)
                return null;
            int len = len2 + 1;
            
            object[] objlist = GetNewPtrAllocStr(len);
            IntPtr intPtr = (IntPtr)objlist[1];

            uint t = (uint)intPtr.value;

            fixed (char* ptr = s)
            {
                for (int i = 0; i < len2; i++)
                {
                    *(short*)(t + i) = *(short*)(ptr + i);
                }
            }

            OutputDebugString("StringToScriptMemAnsi: 0x" + t.ToString("X"));

            return objlist;
        }

        public static uint MonoObjectAsPointerU(object obj) //void* ptr = (void*)obj; don't compile
        {
            if (obj == null)
                return 0;
            return (uint)obj.obj_address();
        }

        public static ulong MonoObjectAsPointerU64(object obj) //void* ptr = (void*)obj; don't compile
        {
            if (obj == null)
                return 0;
            return (ulong)obj.obj_address();
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int niecmod_native_check_yielding_context();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr niecmod_native_create_thread(IntPtr _StartAddress, IntPtr _ArgList, uint _StackSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void niecmod_native_destroy_thread(IntPtr threadHandle);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool niecmod_native_file_found(string path);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr niecmod_native_file_create(string path);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void niecmod_native_file_close(IntPtr handle);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool niecmod_native_file_delete(string path);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool niecmod_native_file_rename(string path, string fileName);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int niecmod_native_file_write(IntPtr handle, IntPtr data, int count);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int niecmod_native_file_writetext(IntPtr handle, string text);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr niecmod_native_file_read(string path);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string niecmod_native_file_readtext(string path);
    }
}
