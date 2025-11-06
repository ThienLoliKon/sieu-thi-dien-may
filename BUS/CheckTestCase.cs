using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CheckTestCase
    {
        public static bool checkKiTuDacBiet(params string[] str)
        {
            //char[] charlist = str.ToCharArray();
            foreach (string s in str)
            {
                char[] charlist = s.ToCharArray();
                foreach (int i in charlist)
                {
                    //int i = (int)ii;
                    if (!(i >= 48 && i <= 57) || (i >= 65 && i <= 90) || (i >= 97 && i <= 122))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool checkChuoiSo(params string[] str)
        {
            foreach (string s in str)
            {
                char[] charlist = s.ToCharArray();
                foreach (int i in charlist)
                {
                    if (!(i >= 48 && i <= 57))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool checkLenghtChuoi(string str, int maxleng, int minleng = 0)
        {
            if (str.Length >= minleng && str.Length <= maxleng)
            {
                return true;
            }
            return false;
        }
        public static bool checkValidDateInOut(DateTime time1, DateTime time2)
        {
            if (time1 > time2)
            {
                return false;
            }
            return true;
        }
        public static bool checkKhoangTrang(params string[] str)
        {
            foreach (string s in str)
            {
                if (s.Trim() == "")
                {
                    return false;
                }
            }
            return true;
        }
        public static bool checkNumberRange(int max, int min, params double[] nums)
        {
            foreach (double d in nums)
            {
                if (d < min || d > max)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
