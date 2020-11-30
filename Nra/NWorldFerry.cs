
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Sims3.Gameplay;

using Sims3.SimIFace;

namespace NiecMod.Nra
{
    public static class NWorldFerry<T> // lizcandor fail
    {
        private static readonly Dictionary<FieldInfo, object> _mCargo;

        static NWorldFerry()
        {
            FieldInfo[] list;
            try
            {
                list = FindPersistableStatics();
            }
            catch (Exception ex)
            {
                niec_native_func.OutputDebugString("NM: FindPersistableStatics() failed.");
                NiecException.SendTextExceptionToDebugger(ex);
                _mCargo = new Dictionary<FieldInfo, object>();
                return;
            }
            
            if (list == null || list.Length == 0)
            {
                niec_native_func.OutputDebugString(string.Format("NM: There are no PersistableStatic fields declared in {0}.", typeof(T)));
                _mCargo = new Dictionary<FieldInfo, object>();
                return;
            }

            _mCargo = new Dictionary<FieldInfo, object>(list.Length);

            foreach (FieldInfo field in list)
            {
                if (field == null)
                {
                    //niec_native_func.OutputDebugString("NWorldFerry(): field == null. Should mono bug");
                    continue;
                }
                _mCargo[field] = null;
            }
        }

        private static FieldInfo[] FindPersistableStatics()
        {
            var foundList = typeof(T).FindMembers(
                MemberTypes.Field, BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                (MemberInfo info, object criteria) => {
                    if (info == null)
                        return false;
                    return info.GetCustomAttributes(typeof(PersistableStaticAttribute), false).Length != 0;
                },
                null
            );

            //return Array.ConvertAll(foundList, (MemberInfo x) => (FieldInfo)x);

            // fast code :)
            var count = foundList.Length;
            var r = new FieldInfo[count];

            for (int i = 0; i < count; i++)
            {
                r[i] = (FieldInfo)foundList[i];
            }

            return r;
        }

        public static void UnloadCargo(bool force)
        {
            if (_mCargo == null)
            {
                NFinalizeDeath.Assert("UnloadCargo: _mCargo is null.");
                return;
            }

            if (force || GameStates.IsTravelling)
            {
                foreach (FieldInfo item in new List<FieldInfo>(_mCargo.Keys))
                {
                    if (item == null)
                        continue;

                    try
                    {
                        item.SetValue(null, _mCargo[item]);
                    }
                    catch (Exception)
                    {
                        niec_native_func.OutputDebugString("Failed to SetValue() Type: " + typeof(T).ToString() + " | T: " + item.FieldType + " | Name: " + item.Name);
                    }

                    _mCargo[item] = null;
                }
            }
        }

        public static void LoadCargo(bool force)
        {
            if (_mCargo == null)
            {
                NFinalizeDeath.Assert("LoadCargo: _mCargo is null.");
                return;
            }

            if (force || GameStates.IsTravelling)
            {
                foreach (FieldInfo item in new List<FieldInfo>(_mCargo.Keys))
                {
                    if (item == null)
                        continue;

                    try
                    {
                        _mCargo[item] = item.GetValue(null);
                    }
                    catch (Exception)
                    {
                        niec_native_func.OutputDebugString("Failed to GetValue() Type: " + typeof(T).ToString() + " | T: " + item.FieldType + " | Name: " + item.Name);
                    }
                }
            }
        }
    }
}
