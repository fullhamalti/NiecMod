using System;
using System.Collections.Generic;
using System.Text;

namespace NiecMod.Nra
{
    public class NHousehold
    {
        public static bool runI = true;
        public static void _CleanUp()
        {
            if (runI)
                return;
            NFinalizeDeath.Household_CleanUp();
        }
    }
}
