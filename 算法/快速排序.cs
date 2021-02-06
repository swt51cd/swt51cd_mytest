using System;


namespace 算法
{
    class 快速排序
    {

        public static void SortMain()
        {
            int[] intArr = { 12, 16, 23, 45, 3, 7, 33, 12, 23 };
            Console.WriteLine("------排序前-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n------排序后-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
        }

        public static void QuickSort ()
        {
            
        }

    }
}
