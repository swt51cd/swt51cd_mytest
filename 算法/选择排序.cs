using System;
using System.Collections.Generic;
using System.Text;

namespace 算法
{
    class 选择排序
    {
        public static void SortMain()
        {
            int[] intArr = { 12, 16, 23, 45, 3, 7, 33, 12, 23 };
            Console.WriteLine("------排序前-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
            SelectionSort(intArr,intArr.Length);
            Console.WriteLine("\n------排序后-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
        }

        public static void SelectionSort(int[] arr, int n)
        {
            while (n > 1)
            {
                int pos = FindMaxPosition(arr, n);
                //交换=最大值与这次循环的最后位置值交换
                int temp = arr[pos];
                arr[pos] = arr[n - 1];
                arr[n - 1] = temp;
                n--;
            }

        }
        /// <summary>
        /// 查找最大数，位置Position
        /// </summary>
        private static int FindMaxPosition(int[] arr, int n)
        {
            int max = arr[0], pos = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    pos = i;
                }
            }
            return pos;
        }
    }
}
