using System;
using System.Collections.Generic;
using System.Text;

namespace 算法
{
    public class 计数排序
    {
        public static void SortMain()
        {
            CountArr();
        }


        private static void CountArr()
        {
            int[] arr = { 2, 6, 4, 9, 2, 6, 5, 8, 9, 7 };
            var intArrLength = arr.Length;
            int[] countArr = new int[arr.Length];
            int[] tempArr = new int[arr.Length];

            #region 排序
            //Array.Sort(arr); //排序
            //Array.Reverse(arr);//排序后再倒序
            #endregion

            Console.WriteLine("--------排序------");
            foreach (int i in arr)
            {
                countArr[i] += 1;//arr值当做count下标
                Console.WriteLine(i);
            }

            Console.WriteLine("------arr值当做count下标时重复次数--------");
            foreach (int i in countArr)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("-------------------");
            int index = 0;
            for (int i = 0,j=0; i < countArr.Length; i++)
            {
                if (countArr[i] > 0)
                {
                    #region 模式1
                    //for (int j = 0; j < countArr[i]; j++)
                    //{
                    //    tempArr[index++] = i;
                    //}
                    #endregion
                    //模式2
                    while (countArr[i]-- >0)
                    {
                        tempArr[j++] = i;
                    }
                }
            }
            Console.WriteLine("--------最新排序数组-----------");
            foreach (int i in tempArr)
            {
                Console.WriteLine(i);
            }
        }

    }
}
