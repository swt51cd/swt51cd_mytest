using System;
using System.Collections.Generic;
using System.Text;

namespace 面试题
{
    class 基础
    {
        public static bool GetFlag(int num)
        {
            if (num < 1) return false;
            return (num & num - 1) == 0;
        }
    }
}
