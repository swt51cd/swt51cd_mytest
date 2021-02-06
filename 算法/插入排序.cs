using System;
using System.Collections.Generic;
using System.Text;

namespace 算法
{
    class 插入排序
    {
        public static void SortMain()
        {
            int[] intArr = { 12, 16,1, 23, 45, 3, 7, 33, 12, 23 };
            Console.WriteLine("------排序前-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
            //InsertionSort(intArr, intArr.Length);
            ShellSort(intArr,intArr.Length);
            Console.WriteLine("\n------排序后-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
        }

        private static void Insert(int[] arr, int n)
        {
            var key = arr[n]; //n,代表第N个值
            var i = n;
            while (arr[i - 1] > key)
            {
                arr[i] = arr[i - 1];
                i--;
                if (i == 0) break;
            }
            arr[i] = key;
        }

        private static void InsertionSort(int[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                Insert(arr, i);
            }
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        private static void ShellSort(int[] arr,int n)
        {
            int gap=arr.Length/2;

            //while (1 <= gap)
            //{
            //    for (int i = gap; i < arr.Length; i++)
            //    {
            //        int j = 0;
            //        int temp = arr[i];
            //        // 对距离为 gap 的元素组进行排序
            //        for (j = i - gap; j >= 0 && temp < arr[j]; j = j - gap)
            //        {
            //            arr[j + gap] = arr[j];
            //        }
            //        arr[j + gap] = temp;
            //    }
            //    gap = gap / 2;
            //}
            for (int z = gap; gap >=1 ; gap/=2)
            {
                //从第gap个元素，逐个对其所在组进行直接插入排序操作
                for (int i = z; i < arr.Length; i++)
                {
                    int j = i;
                    int temp = arr[j];
                    if (arr[j] < arr[j - z])
                    {
                        while (j - z >= 0 && temp < arr[j - z])
                        {
                            //移动法
                            arr[j] = arr[j - z];
                            j -= z;
                        }
                        arr[j] = temp;
                    }
                }
            }

        }
    }
}
