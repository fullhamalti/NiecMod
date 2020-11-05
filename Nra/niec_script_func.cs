using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NiecMod.Nra
{
    public class niec_script_func
    {
        public static IntPtr emtpyptr = new IntPtr(0);

        public static void init_class() { emtpyptr = new IntPtr(0); }

        public static int niecmod_script_size_str_safew(string str)
        {
            if (str.Length == 0)
                return 0;
            return str.Length * 2;
        }

        public static uint niecmod_script_get_str_data_address(string str)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;
            return (uint)str.obj_address() + (uint)System.Runtime.CompilerServices.RuntimeHelpers.OffsetToStringData;
        }

        public static uint niecmod_script_str_safe_maxaddress(string str)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                throw new InvalidOperationException("Sims 3 (64 bit)!");
            if (str.Length == 0)
                throw new ArgumentException();
            return (uint)((niecmod_script_get_str_data_address(str) + (uint)(str.Length * 2)) - System.Runtime.CompilerServices.RuntimeHelpers.OffsetToStringData);
        }

        public unsafe static int niecmod_script_size_str_utf16_to_ansi(string str) // not tested
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                throw new InvalidOperationException("Sims 3 (64 bit)!");

            uint* at = (uint*)((int)str.obj_address()) + 0x8;
            var tem = 0;

            while (*(short*)((uint*)at++) != (short)0x0000)
            {
                tem++;
            }

            return tem;
        }


        public unsafe static bool niecmod_script_set_custom_native_function(IntPtr funcHandle, IntPtr p_func_address)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            if (funcHandle == emtpyptr)
            {
                return false;
            }

            uint func_address = ((uint)funcHandle.ToInt32()) + 0x20u;
            *(uint*)func_address = (uint)p_func_address.value;

            return true;
        }
        public static bool niecmod_script_set_custom_native_function2(MethodInfo internal_function, uint p_func_address)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            var vfunc = internal_function as MonoMethod;
            if (vfunc == null)
            {
                return false;
            }

            if (vfunc.mhandle == emtpyptr)
            {
                return false;
            }

            uint func_address = ((uint)vfunc.mhandle.ToInt32()) + 0x20u;
            global::System.Runtime.InteropServices.Marshal.WriteInt32(new IntPtr((int)func_address), (int)p_func_address);

            return true;
        }

        public unsafe static bool niecmod_script_set_custom_native_function_dlln_created(IntPtr internaldll_function, uint p_func_address)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            if (internaldll_function == emtpyptr)
            {
                return false;
            }

            niec_native_func.OutputDebugString("set_custom_native_function_dlln_created() called");
            niec_native_func.OutputDebugString("internaldll_function adderss: 0x" + ((uint)(internaldll_function)).ToString("X"));

            uint func_address = 0;

            var dll = (uint)internaldll_function + 0xC;
            var unknown_i = *(uint*)dll;

            if (unknown_i == 0)
            {
                niec_native_func.OutputDebugString("Failed");
                return false;
            }
            else
            {
                niec_native_func.OutputDebugString("unknown_i adderss: 0x" + unknown_i.ToString("X"));

                func_address = unknown_i + 0xD4;

                niec_native_func.OutputDebugString("func_address adderss: 0x" + func_address.ToString("X"));

                *(uint*)func_address = (uint)p_func_address;

                niec_native_func.OutputDebugString("Done");
                return true;
            }
        }

        public unsafe static uint niecmod_script_get_custom_native_function_dlln_created(IntPtr internaldll_function)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (internaldll_function == emtpyptr)
            {
                return 0;
            }

            niec_native_func.OutputDebugString("get_custom_native_function_dlln_created() called");
            niec_native_func.OutputDebugString("internaldll_function adderss: 0x" + ((uint)(internaldll_function)).ToString("X"));

            uint func_address = 0;

            var dll = (uint)internaldll_function + 0xC;
            var unknown_i = *(uint*)dll;

            if (unknown_i == 0)
            {
                niec_native_func.OutputDebugString("Failed");
                return 0;
            }
            else
            {
                niec_native_func.OutputDebugString("unknown_i adderss: 0x" + unknown_i.ToString("X"));

                func_address = unknown_i + 0xD4;

                niec_native_func.OutputDebugString("func_address adderss: 0x" + func_address.ToString("X"));

                return *(uint*)func_address;
            }
        }

        public unsafe static bool niecmod_script_set_custom_native_function_dll_created(IntPtr internaldll_function, uint p_func_address)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            if (internaldll_function == emtpyptr)
            { 
                return false;
            }

            niec_native_func.OutputDebugString("set_custom_native_function_dll_created() called");
            niec_native_func.OutputDebugString("internaldll_function adderss: 0x" + ((uint)(internaldll_function)).ToString("X"));

            uint func_address = 0;

            var dll = (uint)internaldll_function + 0xC;
            var unknown_i = *(uint*)dll;

            if (unknown_i == 0)
            {
                niec_native_func.OutputDebugString("Failed");
                return false;
            }
            else
            {
                niec_native_func.OutputDebugString("unknown_i adderss: 0x" + unknown_i.ToString("X") + " unknown_i + 0x4Cu: 0x" + ((uint)(unknown_i + 0x4Cu)).ToString("X"));

                var unknown_a = unknown_i + 0x4Cu;
                niec_native_func.OutputDebugString("unknown_a adderss: 0x" + unknown_a.ToString("X"));

                if (unknown_a == 0 || unknown_a < 0x1000)
                {
                    niec_native_func.OutputDebugString("Failed");
                    return false;
                }

                var unknown_b = *(uint*)unknown_a;
                niec_native_func.OutputDebugString("unknown_b adderss: 0x" + unknown_b.ToString("X") + " unknown_b + 0x14u: 0x" + ((uint)(unknown_b + 0x14u)).ToString("X"));

                if (unknown_b == 0 || unknown_b < 0x1000)
                {
                    niec_native_func.OutputDebugString("Failed");
                    return false;
                }
              
                var unknown_bb = *(uint*)unknown_b + 0x14u;
                niec_native_func.OutputDebugString("unknown_bb adderss: 0x" + unknown_bb.ToString("X"));

                if (unknown_bb == 0 || unknown_bb < 0x1000 || unknown_bb == 0xFFFF0004)
                {
                    niec_native_func.OutputDebugString("Failed");
                    return false;
                }

                func_address = unknown_bb + 0xC;
                niec_native_func.OutputDebugString("func_address adderss: 0x" + (*(uint*)func_address).ToString("X"));
				
                *(uint*)func_address = (uint)p_func_address;
				
				niec_native_func.OutputDebugString("Done");
                return true;
            }
        }
        public unsafe static uint niecmod_script_get_custom_native_function_dll_created(IntPtr internaldll_function)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (internaldll_function == emtpyptr)
            {
                return 0;
            }

            niec_native_func.OutputDebugString("get_custom_native_function_dll_created() called");
            niec_native_func.OutputDebugString("internaldll_function adderss: 0x" + ((uint)(internaldll_function)).ToString("X"));

            uint func_address = 0;

            var dll = (uint)internaldll_function + 0xC;
            var unknown_i = *(uint*)dll;

            if (unknown_i == 0)
            {
                niec_native_func.OutputDebugString("Failed");
                return 0;
            }
            else
            {
                niec_native_func.OutputDebugString("unknown_i adderss: 0x" + unknown_i.ToString("X") + " unknown_i + 0x4Cu: 0x" + ((uint)(unknown_i + 0x4Cu)).ToString("X"));

                var unknown_a = unknown_i + 0x4Cu;
                niec_native_func.OutputDebugString("unknown_a adderss: 0x" + unknown_a.ToString("X"));

                if (unknown_a == 0 || unknown_a < 0x1000)
                {
                    niec_native_func.OutputDebugString("Failed");
                    return 0;
                }

                var unknown_b = *(uint*)unknown_a;
                niec_native_func.OutputDebugString("unknown_b adderss: 0x" + unknown_b.ToString("X") + " unknown_b + 0x14u: 0x" + ((uint)(unknown_b + 0x14u)).ToString("X"));

                if (unknown_b == 0 || unknown_b < 0x1000)
                {
                    niec_native_func.OutputDebugString("Failed");
                    return 0;
                }

                var unknown_bb = *(uint*)unknown_b + 0x14u;
                niec_native_func.OutputDebugString("unknown_bb adderss: 0x" + unknown_bb.ToString("X"));

                if (unknown_bb == 0 || unknown_bb < 0x1000 || unknown_bb == 0xFFFF0004)
                {
                    niec_native_func.OutputDebugString("Failed");
                    return 0;
                }



                func_address = unknown_bb + 0xC;
                niec_native_func.OutputDebugString("func_address adderss: 0x" + (*(uint*)func_address).ToString("X"));

                return *(uint*)func_address;
            }
        }

        public static bool niecmod_script_set_custom_native_function_dll(IntPtr internal_function, uint p_func_address)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return false;

            if (internal_function == emtpyptr)
            {
                return false;
            }

            var p = niecmod_script_set_custom_native_function_dlln_created(internal_function, p_func_address);
            var p1 = niecmod_script_set_custom_native_function_dll_created(internal_function, p_func_address);

            return p || p1;
        }

        public static object niecmod_script_get_obj_adderess(object obj)
        {
            bool gameIs64 = NFinalizeDeath.GameIs64Bit(false);
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                var s = "niecmod_script_get_obj_adderess (object) ([";
                var st = ex.StackTrace;
                if (st == null || st.Length == 0)
                    return 0;

                int index = st.IndexOf(s);
                if (index == -1)
                    return 0;

                if ((index + s.Length) > st.length - (gameIs64 ? 16 : 8))
                    return 0;

                return (gameIs64 ? 
                        ulong.Parse(st.Substring(index + s.Length, 16) ?? "0", System.Globalization.NumberStyles.AllowHexSpecifier) :
                    uint.Parse(st.Substring(index + s.Length, 8) ?? "0", System.Globalization.NumberStyles.AllowHexSpecifier));
            }
        }

        public unsafe static uint niecmod_safecall_script_get_func_ptr_dll2(MethodInfo internaldll_function)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (internaldll_function == null)
            {
                return 0;
            }

            uint func_address = 0;
            uint r = 0;

            NFinalizeDeath.SafeCall(() =>
            {
                var ptr = (uint)internaldll_function.obj_address();

                var dll = ptr + 0x8u;
                var func_i = *(uint*)dll;

                if (func_i == 0)
                {
                    r = 0;
                    return;
                }
                else
                {
                    func_address = func_i + 0x18u;
                    r = *(uint*)func_address;
                    return;
                }

                
            });
            return r;
        }

       
        public unsafe static uint niecmod_safecall_script_get_func_ptr_dll(IntPtr internaldll_function)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (internaldll_function.value == null)
            {
                return 0;
            }

            uint func_address = 0;
            uint r = 0;

            NFinalizeDeath.SafeCall(() =>
            {
                var ptr = (uint)internaldll_function.value;

                var dll = ptr + 0x8u;
                var func_i = *(uint*)dll;

                if (func_i == 0)
                {
                    r = 0;
                    return;
                }
                else
                {
                    func_address = func_i + 0x18u;
                    r = *(uint*)func_address;
                    return;
                }

            });
            return r;
        }


        public unsafe static uint niecmod_safecall_script_get_func_ptr_all(IntPtr internaldll_function, uint am, uint an)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (internaldll_function.value == null)
            {
                return 0;
            }
            var p = niecmod_safecall_script_get_func_ptr(internaldll_function);
            if (p != 0 && p > an && p < am)
            {
                return p;
            }
            else
            {
                return niecmod_safecall_script_get_func_ptr_dll(internaldll_function);
            }
        }

        public static uint niecmod_safecall_script_get_func_ptr_all2(MethodInfo internal_function, uint am, uint an)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (internal_function == null)
            {
                return 0;
            }
            var p = niecmod_script_get_func_ptr2(internal_function);
            if (p != 0 && p > an && p < am)
            {
                return p;
            }
            else
            {
                return niecmod_safecall_script_get_func_ptr_dll2(internal_function);
            }
        }




        public unsafe static uint niecmod_safecall_script_get_func_ptr(IntPtr funcHandle)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (funcHandle.value == null)
            {
                return 0;
            }

            uint r = 0;

            NFinalizeDeath.SafeCall(() =>
            {
                r = *(uint*)((uint)funcHandle.value) + 0x20u;
            });

            return r;
        }


        public unsafe static uint niecmod_script_get_func_ptr(IntPtr funcHandle)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            if (funcHandle == emtpyptr)
            {
                return 0;
            }

            uint func_address = ((uint)funcHandle.ToInt32()) + 0x20u;
            return *(uint*)func_address;
        }

        public static uint niecmod_script_get_func_ptr2(MethodInfo internal_function)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                return 0;

            var vfunc = internal_function as MonoMethod;
            if (vfunc == null)
            {
                return 0;
            }

            if (vfunc.mhandle == emtpyptr)
            {
                return 0;
            }

            uint func_address = ((uint)vfunc.mhandle.ToInt32()) + 0x20u;

            try
            {
                return (uint)global::System.Runtime.InteropServices.Marshal.ReadInt32(new IntPtr((int)func_address));
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }
    }
}
