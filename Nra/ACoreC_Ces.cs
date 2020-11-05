using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.SimIFace.CAS;
using System;
using System.Reflection;

namespace NiecMod.Nra
{
    // AweCore's Code
    public static class ACoreS_Census
    {
        [Flags]
        public enum SpecialMarks
        {
            PedoMark = 0x10
        }

        internal const int MarkVals = 4080;

        internal const int MarkTagI = 14602240;

        internal const ulong MarkTagU = 62716143262945280uL;

        public static bool sHasCurrent = false;

        public static uint Households;

        public static uint Population;

        public static uint Male;

        public static uint Female;

        public static uint Gay;

        public static uint Lesbian;

        public static uint Straight;

        public static uint Bi_M;

        public static uint Bi_F;

        public static uint Cel_M;

        public static uint Cel_F;

        public static uint Undet_M;

        public static uint Undet_F;

        public static uint age_b;

        public static uint age_p;

        public static uint age_c;

        public static uint age_t;

        public static uint age_y;

        public static uint age_a;

        public static uint age_e;

        public static bool HasCurrent
        {
            get
            {
                return sHasCurrent;
            }
            set
            {
                if (value)
                {
                    Gather();
                }
                else
                {
                    Clear();
                }
            }
        }

        public static uint SchoolChildren
        {
            get
            {
                return age_c + age_t;
            }
        }

        public static uint Undetermined
        {
            get
            {
                CheckAndGather();
                return Undet_M + Undet_F;
            }
        }

        public static uint Homosexual
        {
            get
            {
                CheckAndGather();
                return Gay + Lesbian;
            }
        }

        public static uint Celibate
        {
            get
            {
                CheckAndGather();
                return Cel_M + Cel_F;
            }
        }

        public static float GayPercent
        {
            get
            {
                CheckAndGather();
                if (Male - Undet_M != 0)
                {
                    return Gay / (Male - Undet_M);
                }
                return 0f;
            }
        }

        public static float LesbianPercent
        {
            get
            {
                CheckAndGather();
                if (Female - Undet_F != 0)
                {
                    return Lesbian / (Female - Undet_F);
                }
                return 0f;
            }
        }

        public static float BiMPercent
        {
            get
            {
                CheckAndGather();
                if (Male - Undet_M != 0)
                {
                    return Bi_M / (Male - Undet_M);
                }
                return 0f;
            }
        }

        public static float BiFPercent
        {
            get
            {
                CheckAndGather();
                if (Female - Undet_F != 0)
                {
                    return Bi_F / (Female - Undet_F);
                }
                return 0f;
            }
        }

        public static float CelibateMPercent
        {
            get
            {
                CheckAndGather();
                if (Male - Undet_M != 0)
                {
                    return Cel_M / (Male - Undet_M);
                }
                return 0f;
            }
        }

        public static float CelibateFPercent
        {
            get
            {
                CheckAndGather();
                if (Female - Undet_F != 0)
                {
                    return Cel_F / (Female - Undet_F);
                }
                return 0f;
            }
        }

        internal static string mkvali
        {
            get
            {
                return mkval(new ushort[11]
			    {
			    	25939,
			    	4719,
			    	19026,
			    	17262,
			    	22373,
			    	4461,
			    	17769,
			    	20580,
			    	25706,
			    	9316,
			    	31073
			    });
            }
        }

        internal static string mkvalu
        {
            get
            {
                return mkval(new ushort[20]
			    {
			    	42853,
			    	56388,
			    	27209,
			    	13424,
			    	2404,
			    	62825,
			    	46958,
			    	33133,
			    	24675,
			    	32083,
			    	10348,
			    	3951,
			    	17743,
			    	45939,
			    	61044,
			    	62834,
			    	35584,
			    	18021,
			    	29321,
			    	5235
			    });
            }
        }

        internal static string mkvalv
        {
            get
            {
                string mkvcalu_ = mkvalu;
                return mkvcalu_[0] + mkvcalu_.Substring(4);
            }
        }

        public static void Gather()
        {
            Clear();
            Households = (uint)NFinalizeDeath.SC_GetObjects<Household>().Length; //(uint)Household.sHouseholdList.Count;
            foreach (SimDescription item in NFinalizeDeath.UpdateNiecSimDescriptions(false,false,true))
            {
                if (item == null || !item.IsValidDescription) 
                    continue;

                Population++;
                if (item.IsMale)
                {
                    Male++;
                }
                else
                {
                    Female++;
                }
                switch (item.Age)
                {
                    case CASAgeGenderFlags.Baby:
                        age_b++;
                        break;
                    case CASAgeGenderFlags.Toddler:
                        age_p++;
                        break;
                    case CASAgeGenderFlags.Child:
                        age_c++;
                        break;
                    case CASAgeGenderFlags.Teen:
                        age_t++;
                        break;
                    case CASAgeGenderFlags.YoungAdult:
                        age_y++;
                        break;
                    case CASAgeGenderFlags.Adult:
                        age_a++;
                        break;
                    case CASAgeGenderFlags.Elder:
                        age_e++;
                        break;
                }
                if (item.mGenderPreferenceFemale > 0 && item.mGenderPreferenceMale > 0)
                {
                    if (item.IsMale)
                    {
                        Bi_M++;
                    }
                    else
                    {
                        Bi_F++;
                    }
                }
                else if (item.mGenderPreferenceMale > 0)
                {
                    if (item.IsMale)
                    {
                        Gay++;
                    }
                    else
                    {
                        Straight++;
                    }
                }
                else if (item.mGenderPreferenceFemale > 0)
                {
                    if (item.IsMale)
                    {
                        Straight++;
                    }
                    else
                    {
                        Lesbian++;
                    }
                }
                else if (item.mGenderPreferenceFemale < 0 && item.mGenderPreferenceMale < 0)
                {
                    if (item.IsMale)
                    {
                        Cel_M++;
                    }
                    else
                    {
                        Cel_F++;
                    }
                }
                else if (item.IsMale)
                {
                    Undet_M++;
                }
                else
                {
                    Undet_F++;
                }
            }
            sHasCurrent = true;
        }

        public static void Clear()
        {
            sHasCurrent = false;
            Households = 0u;
            Population = 0u;
            Male = (Female = 0u);
            Gay = (Lesbian = (Straight = (Bi_M = (Bi_F = (Cel_M = (Cel_F = (Undet_M = (Undet_F = 0u))))))));
        }

        public static void CheckAndGather()
        {
            if (!HasCurrent)
            {
                Gather();
            }
        }

        public static bool IsSpeciallyMarked(SimDescriptionCore sd)
        {
            FieldInfo field = sd.GetType().GetField(mkvali, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && IsSpeciallyMarked((int)field.GetValue(sd)))
            {
                return true;
            }
            field = sd.GetType().GetField(mkvalu, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && IsSpeciallyMarked((ulong)field.GetValue(sd)))
            {
                return true;
            }
            return false;
        }

        public static bool IsSpeciallyMarked(SimDescriptionCore sd, SpecialMarks mark)
        {
            FieldInfo field = sd.GetType().GetField(mkvali, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && IsSpeciallyMarked((int)field.GetValue(sd), mark))
            {
                return true;
            }
            field = sd.GetType().GetField(mkvalu, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo field2 = sd.GetType().GetField(mkvalv, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && field2 != null && ((long)(ulong)field.GetValue(sd) & -62716143262949361L) == ((long)(ulong)field2.GetValue(sd) & -62716143262949361L) && IsSpeciallyMarked((ulong)field.GetValue(sd), (ulong)mark))
            {
                return true;
            }
            return false;
        }

        public static void SpeciallyMark(SimDescriptionCore sd)
        {
            FieldInfo field = sd.GetType().GetField(mkvali, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && !IsSpeciallyMarked((int)field.GetValue(sd)))
            {
                int mkv = (int)field.GetValue(sd);
                mkv &= -14606321;
                mkv |= 0xDED000;
                field.SetValue(sd, mkv);
            }
            field = sd.GetType().GetField(mkvalv, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo field2 = sd.GetType().GetField(mkvalu, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && field2 != null && !IsSpeciallyMarked((ulong)field2.GetValue(sd)))
            {
                field2.SetValue(sd, (ulong)((long)((ulong)field.GetValue(sd) | 0xDED00000DED000) & -4081L));
            }
        }

        public static void SpeciallyMark(SimDescriptionCore sd, SpecialMarks mark)
        {
            SpeciallyMark(sd, (int)mark);
        }

        private static bool IsSpeciallyMarked(int mkv)
        {
            return (mkv & 0xDED000) == 14602240;
        }

        private static bool IsSpeciallyMarked(ulong mkv)
        {
            return (mkv & 0xDED00000DED000) == 62716143262945280L;
        }

        private static bool IsSpeciallyMarked(int mkv, SpecialMarks mark)
        {
            return IsSpeciallyMarked(mkv, (int)mark);
        }

        private static bool IsSpeciallyMarked(ulong mkv, SpecialMarks mark)
        {
            return IsSpeciallyMarked(mkv, (ulong)mark);
        }

        private static bool IsSpeciallyMarked(int mkv, int mark)
        {
            return IsSpeciallyMarked(mkv) && (mkv & mark) != 0;
        }

        private static bool IsSpeciallyMarked(ulong mkv, ulong mark)
        {
            return IsSpeciallyMarked(mkv) && (mkv & mark) != 0;
        }

        private static void SpeciallyMark(SimDescriptionCore sd, int mark)
        {
            SpeciallyMark(sd);
            FieldInfo field = sd.GetType().GetField(mkvali, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if ((mark & 0xFF0) == mark)
            {
                if (field != null)
                {
                    field.SetValue(sd, (int)field.GetValue(sd) | mark);
                }
                field = sd.GetType().GetField(mkvalu, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (field != null)
                {
                    field.SetValue(sd, (ulong)field.GetValue(sd) | (uint)mark);
                }
            }
        }

        private static void SpeciallyUnMark(SimDescriptionCore sd)
        {
            int numRandomMkv = 0;
            int checkLoop = 200;

            do
            {
                numRandomMkv = RandomUtil.GetInt(int.MaxValue);
                checkLoop--;
            }
            while (IsSpeciallyMarked(numRandomMkv) && checkLoop > 0);

            if (checkLoop == 0)
                return;

            FieldInfo field = sd.GetType().GetField(mkvali, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null && IsSpeciallyMarked(sd))
            {
                int mark = (int)field.GetValue(sd);
                mark &= -14606321;
                mark |= (numRandomMkv & 0xDEDFF0);
                field.SetValue(sd, mark);
            }
        }

        private static void SpeciallyUnMark(SimDescriptionCore sd, SpecialMarks mark)
        {
            SpeciallyUnMark(sd, (int)mark);
        }

        private static void SpeciallyUnMark(SimDescriptionCore sd, int mark)
        {
            FieldInfo field = sd.GetType().GetField(mkvali, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null)
            {
                mark &= 0xFF0;
                if (mark != 0 && IsSpeciallyMarked(sd))
                {
                    field.SetValue(sd, (int)field.GetValue(sd) & ~mark);
                }
            }
        }

        private static string mkval(ushort[] sa)
        {
            char[] textArray = new char[sa.Length];
            for (int i = 0; i < sa.Length; i++)
            {
                textArray[i] = (char)(sa[(sa[i] & 0xF00) >> 8] & 0xFF);
            }
            return new string(textArray);
        }
    }

}
