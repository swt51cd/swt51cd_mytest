using System;

namespace 面试题
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 63;
            if (基础.GetFlag(a))
            {
                Console.WriteLine(a+"---整数是2的N次方");
            }
            else
            {
                Console.WriteLine(a+"---NO");
            }
            Console.ReadKey();
        }
    }
}
