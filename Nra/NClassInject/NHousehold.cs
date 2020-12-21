using System;
using System.Collections.Generic;
using System.Text;
using Sims3.Gameplay.CAS;

namespace NiecMod.Nra
{
    public class NHousehold
    {
        public static bool runI = true;
        public static object OV = null;
        public static void InitNCreate()
        {
            if ((OV as NHousehold) != null)
                return;
            OV = new NHousehold();
           
        }

        public static NHousehold GetStatic()
        {
            InitNCreate();
            return (NHousehold)OV;
        }

        public static void InitClass()
        {
            var g = GetStatic();

            runI = true;
            NFinalizeDeath.M(g.NAllSimDescriptions);
            _CleanUp();
            runI = false;
        }


        public List<SimDescription> NAllSimDescriptions
        {
            get
            {
                Household _this = ((object)this) as Household;
                if (_this == null || _this.mMembers == null)
                    return null;
                return _this.mMembers.AllSimDescriptionList;
            }
        }

        public static void _CleanUp()
        {
            if (runI)
                return;
            NFinalizeDeath.Household_CleanUp();
        }
    }
}
