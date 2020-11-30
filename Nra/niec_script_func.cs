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

        public unsafe static int niecmod_script_size_str_utf16_to_ansi(string str) // untested
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

        public static Dictionary<IntPtr, uint> sCheckMethodChecksum = new Dictionary<IntPtr, uint>();

        public unsafe static bool niecmod_script_copy_ptr_func_to_func(MethodBase a, MethodBase t, bool prelink, bool check, bool shouldThrowOnFailure, bool copy_methed_info)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentException("Sims 3 64 Bit Found.");
                return false;
            }

            niec_native_func.OutputDebugString("niecmod_script_copy_ptr_func_to_func(...) called");


            if (a == null)
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentNullException("a");
                return false;
            }

            if (t == null)
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentNullException("t");
                return false;
            }

            niec_native_func.OutputDebugString("Name A: " + a.Name + " | IsGeneric: " + a.IsGenericMethod + " | Type: " + a.GetType().ToString());
            niec_native_func.OutputDebugString("Name T: " + t.Name + " | IsGeneric: " + t.IsGenericMethod + " | Type: " + t.GetType().ToString());

            if (a is ConstructorInfo && t is ConstructorInfo)
            {
                niec_native_func.OutputDebugString("a && t is System.Reflection.ConstructorInfo");

                var cah = ((MonoCMethod)a).mhandle;
                var cth = ((MonoCMethod)t).mhandle;

                uint camethod_ptr = *(uint*)((uint)cah + 0x14);
                uint ctmethod_ptr = *(uint*)((uint)cth + 0x14);

                return niecmod_script_copy_ptr_methed_to_methed_internal<ConstructorInfo>(
                    new IntPtr() { value = (void*)camethod_ptr },
                    new IntPtr() { value = (void*)ctmethod_ptr },
                    copy_methed_info
                );
            }

            uint tuint;
            if (sCheckMethodChecksum != null && sCheckMethodChecksum.TryGetValue(((MonoMethod)t).mhandle, out tuint))
                return true;

            uint au = 0;
            uint tu = 0;

            try
            {
                niec_native_func.OutputDebugString("calling GetMethodImplementationFlags");
                a.GetMethodImplementationFlags();
                niec_native_func.OutputDebugString("calling GetParameters");
                a.GetParameters();
                niec_native_func.OutputDebugString("calling GetMethodImplementationFlags T");
                t.GetMethodImplementationFlags();
                niec_native_func.OutputDebugString("calling GetParameters T");
                t.GetParameters();

                niec_native_func.OutputDebugString("calling NFinalizeDeath.M(a.Attributes)");
                NFinalizeDeath.M(a.Attributes);
                niec_native_func.OutputDebugString("calling NFinalizeDeath.M(t.Attributes)");
                NFinalizeDeath.M(t.Attributes);
                

                niec_native_func.OutputDebugString("calling ScriptCore.TaskControl.GetMethodChecksum(t.MethodHandle, out tu);");
                ScriptCore.TaskControl.TaskControl_GetMethodChecksum(((MonoMethod)t).mhandle, out tu);
                niec_native_func.OutputDebugString("tu: 0x" + tu.ToString("X"));

                niec_native_func.OutputDebugString("calling ScriptCore.TaskControl.GetMethodChecksum(a.MethodHandle, out au);");
                ScriptCore.TaskControl.TaskControl_GetMethodChecksum(((MonoMethod)a).mhandle, out au);
                niec_native_func.OutputDebugString("au: 0x" + au.ToString("X"));
            }
            catch (Exception)
            {}
            try
            {
                if (check)
                {
                    if (a is MethodInfo && t is MethodInfo)
                    {
                        if (!niecmod_script_check_func_e_func((MethodInfo)a, (MethodInfo)t, shouldThrowOnFailure))
                        {
                            niec_native_func.OutputDebugString("niecmod_script_check_func_e_func(a, t, shouldThrowOnFailure) failed");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (shouldThrowOnFailure)
                    niec_native_func.OutputDebugString(ex.Message);
                throw;
            }
            

            var ah = ((MonoMethod)a).mhandle;
            var th = ((MonoMethod)t).mhandle;

            niec_native_func.OutputDebugString("ahandle: " + ((uint)ah).ToString("X"));
            niec_native_func.OutputDebugString("thandle: " + ((uint)th).ToString("X"));

            if (ah == null || th == null)
            {
                niec_native_func.OutputDebugString("if (ah == null || th == null)");
                return false;
            }

            if (prelink)
            {
                try
                {
                    niec_native_func.OutputDebugString("calling MethodInfo.GetMethodBody(ah)");
                    MethodInfo.GetMethodBody(ah);
                    niec_native_func.OutputDebugString("calling MethodInfo.GetMethodBody(th)");
                    MethodInfo.GetMethodBody(th);
                }
                catch (Exception)
                { }

                try
                {

                    if (a is MethodInfo)
                    {
                        niec_native_func.OutputDebugString("calling MethodInfo:Prelink A");//: Methed Name: " + a.Name + " | IsGenericMethod: " + a.IsGenericMethod);
                        System.Runtime.InteropServices.Marshal.Prelink((MethodInfo)a);
                    } 
                    if (t is MethodInfo)
                    {
                        niec_native_func.OutputDebugString("calling MethodInfo:Prelink T");//: Methed Name: " + t.Name + " | IsGenericMethod: " + t.IsGenericMethod);
                        System.Runtime.InteropServices.Marshal.Prelink((MethodInfo)t);
                    }
                }
                catch (Exception)
                {
                    niec_native_func.OutputDebugString("Prelink failed");

                    if (shouldThrowOnFailure)
                        throw;

                    return false;
                }
            }

            uint amethod_ptr = *(uint*)((uint)ah + 0x14);
            uint tmethod_ptr = *(uint*)((uint)th + 0x14);

            niec_native_func.OutputDebugString("amethod_ptr: " + amethod_ptr.ToString("X"));
            niec_native_func.OutputDebugString("tmethod_ptr: " + tmethod_ptr.ToString("X"));

            if (amethod_ptr == 0 || amethod_ptr == 0xAA || tmethod_ptr == 0 || tmethod_ptr == 0xAA)
            {
                niec_native_func.OutputDebugString("if (amethod_ptr == 0 || amethod_ptr == 0xAA || tmethod_ptr == 0 || tmethod_ptr == 0xAA)");
                return false;
            }

            var tx = niecmod_script_copy_ptr_methed_to_methed_internal<niec_script_func> (
                new IntPtr() { value = (void*)amethod_ptr },
                new IntPtr() { value = (void*)tmethod_ptr },
                copy_methed_info
            );

            if (tx && sCheckMethodChecksum != null)
            {
                sCheckMethodChecksum.Add(((MonoMethod)t).mhandle, (au * (50 & 10 / au + 5) + 20));
            }

            niec_native_func.OutputDebugString("copy_ptr_methed_to_methed_internal: " + tx);
            niec_native_func.OutputDebugString("niecmod_script_copy_ptr_func_to_func(...) Done!");

            return tx;
        }

        public static bool niecmod_script_check_func_e_func(MethodInfo a, MethodInfo t, bool shouldThrowOnFailure) 
        {
            if (a == null)
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentNullException("a");
                return false;
            }

            if (t == null)
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentNullException("t");
                return false;
            }

            Type returnType_t = a.ReturnType;
            Type returnType_a = t.ReturnType;

            bool rCompatible = returnType_a == returnType_t;

            if (!rCompatible && !returnType_t.IsValueType && returnType_t != typeof(ValueType) && returnType_t.IsAssignableFrom(returnType_a))
            {
                rCompatible = true;
            }

            if (a.IsStatic != t.IsStatic)
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentException("if (a.IsStatic != t.IsStatic)");
                return false;
            }

            if (!rCompatible)
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentException("Method return type is incompatible.");
                return false;
            }

            var parametersTList = t.GetParameters();
            var parametersAList = a.GetParameters();

            if (parametersAList.Length != parametersTList.Length)
            {
                if (shouldThrowOnFailure)
                    throw new ArgumentException("Method argument length mismatch.\nTLength: " + parametersTList.Length + "ALength: " + parametersAList.Length);
                return false;
            }

            int numLength = parametersTList.Length;
            for (int i = 0; i < numLength; i++)
            {
                bool argumentsCompatible = parametersTList[i].ParameterType == parametersAList[i].ParameterType;
                if (!argumentsCompatible)
                {
                    Type parameterTypeT = parametersTList[i].ParameterType;
                    if (!parameterTypeT.IsValueType &&
                        parameterTypeT != typeof(ValueType) &&
                        parametersAList[i].ParameterType.IsAssignableFrom(parameterTypeT))
                    {
                        argumentsCompatible = true;
                    }
                }

                if (!argumentsCompatible)
                {
                    if (shouldThrowOnFailure)
                        throw new ArgumentException("Method arguments are incompatible.");
                    return false;
                }
            }

            return true;
        }

        public unsafe static long DoubleToInt64Bits(double value)
        {
            return *(long*)(&value);
        }


        public unsafe static double Int64BitsToDouble(long value)
        {
            return *(double*)(&value);
        }


        public unsafe static int FloatToInt32Bits(float value)
        {
            return *(int*)(&value);
        }


        public unsafe static float Int32BitsToFloat(int value)
        {
            return *(float*)(&value);
        }

        public unsafe static void niecmod_script_zeromemory64(byte* src, long len)
        {
            while (len-- > 0)
            {
                src[len] = 0;
            }
        }

        public unsafe static void niecmod_script_zeromemory32(byte* src, int len)
        {
            while (len-- > 0)
            {
                src[len] = 0;
            }
        }

        public unsafe static bool niecmod_script_copy_ptr_methed_to_methed_internal<T>(IntPtr method_ptr_a, IntPtr method_ptr_t, bool copy_methed_info)
        {
            if (NFinalizeDeath.GameIs64Bit(false))
                throw new NotSupportedException("Sims 3 64 bit version not supported.");

#if !GameVersion_0_Release_2_0_209
            throw new NotSupportedException("Game versions not supported. Only Patch 1.67.2");
#else
            if (method_ptr_a.value == null || method_ptr_t.value == null)
                return false;

            uint ptr_a = (uint)method_ptr_a.value;
            uint ptr_t = (uint)method_ptr_t.value;

            if (*(uint*)(ptr_a) == 0x00000000)
            {
                NFinalizeDeath.AssertX
                    (false, "*(uint*)(ptr_a) == 0x00000000\nST:\n" + NFinalizeDeath.GetSTLite01());
                return false;
            }

            if (*(uint*)(ptr_t) == *(uint*)(ptr_a))
                return true;

            *(uint*)(ptr_t)       = *(uint*)(ptr_a);       // IL list runtime IP
            *(uint*)(ptr_t + 0x4) = *(uint*)(ptr_a + 0x4); // info method virtaul?

            if (copy_methed_info)
            {
                *(uint*)(ptr_t + 0x8) = *(uint*)(ptr_a + 0x8); // info method if not pre link?
                *(uint*)(ptr_t + 0xC) = *(uint*)(ptr_a + 0xC); // info method virtaul? if created?
            } 
            else if (*(uint*)(ptr_t + 0xC) == 0x00000000)
            {
                *(uint*)(ptr_t + 0xC) = *(uint*)(ptr_t + 0x8); // info method virtaul? if created? or info method if not pre link?
            }

            *(uint*)(ptr_t + 0x10) = *(uint*)(ptr_a + 0x10); // Unknown

            *(uint*)(ptr_t + 0x14) = *(uint*)(ptr_a + 0x14); // set filend? by sfsfld or newobj
            *(uint*)(ptr_t + 0x18) = *(uint*)(ptr_a + 0x18); // set filend? by sfsfld or newobj

            *(uint*)(ptr_t + 0x1C) = *(uint*)(ptr_a + 0x1C); // IL call method?
            *(uint*)(ptr_t + 0x20) = *(uint*)(ptr_a + 0x20); // IL call method?

            *(uint*)(ptr_t + 0x24) = *(uint*)(ptr_a + 0x24); // Unknown
            *(uint*)(ptr_t + 0x28) = *(uint*)(ptr_a + 0x28); // Unknown
            *(uint*)(ptr_t + 0x2C) = *(uint*)(ptr_a + 0x2C); // Unknown

            *(uint*)(ptr_t + 0x30) = *(uint*)(ptr_a + 0x30); // Unknown
            *(uint*)(ptr_t + 0x34) = *(uint*)(ptr_a + 0x34); // count?

            *(uint*)(ptr_t + 0x38) = *(uint*)(ptr_a + 0x38); // Unknown
            *(uint*)(ptr_t + 0x3C) = *(uint*)(ptr_a + 0x3C); // Unknown
            *(uint*)(ptr_t + 0x40) = *(uint*)(ptr_a + 0x40); // Unknown count?
            *(uint*)(ptr_t + 0x44) = *(uint*)(ptr_a + 0x44); // created or not created flag

            return true;
#endif // GameVersion_0_Release_2_0_209
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
