using System;
using System.Collections.Generic;
using System.Text;

namespace 算法
{
    class 冒泡排序
    {
        public static void SortMain()
        {
            int[] intArr = { 12, 16, 23, 45, 3, 7, 33, 12, 23 };
            Console.WriteLine("------排序前-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
            Sort(intArr);
            //BubblingSort(intArr,intArr.Length);
            Console.WriteLine("\n------排序后-----");
            foreach (var i in intArr)
            {
                Console.Write(i + " ");
            }
        }


        #region 常规冒泡排序1
        public static void Sort(int[] arr)
        {//固定最前面1个，与后面依次比较<小于最前面就互换>，1次循环下来最前面的最小
            
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        #endregion

        #region 牛~冒泡排序2
        //一次冒泡
        private static void Bubbling(int[] arr, int n)
        {/*沉底排序
            n-1:从数组下标0开始两两比较一直到n-1,第一次比较完成.冒泡
          */
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {//最大的排最后
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }
        }
        //冒泡排序
        public static void BubblingSort(int[] arr, int n)
        { /*
            Bubbling(arr,n);    第一次比较
            Bubbling(arr, n-1); 第二次比较 
            Bubbling(arr, n-2); 第三次比较 
            ...
            Bubbling(arr,1);    
            = 
           */
            for (int i = n; i >= 1; i--)
            {
                Bubbling(arr,i);
            }
        }
        #endregion

        #region 网例
        public static void BubbleSort(int[] arr)
        {
            int i, j;
            int temp;
            bool isExchanged = true;//需要避免因已经有序的情况下的无意义循环判断

            for (j = 1; j < arr.Length && isExchanged; j++)
            {
                isExchanged = false;
                for (i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        // 核心操作：交换两个元素
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        // 附加操作：改变标志
                        isExchanged = true;
                    }
                }
            }
        }
        #endregion

    }
}
