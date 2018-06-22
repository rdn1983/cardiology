using System;

namespace Cardiology.Utils
{
    public class CommonUtils
    {
        public static bool isNotBlank(string str)
        {
            return str != null && str.Length > 0;
        }

        public static bool isBlank(string str)
        {
            return str == null || str.Length == 0;
        }
    }
}


