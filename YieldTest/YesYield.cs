using System;
using System.Collections;

namespace YieldTest
{
    class YesYield
    {
       public static void YesMain()
        {
            //得到一个迭代结果
            var result = GetResultByYield();
            //输出当前的值
            Console.WriteLine(result.Current);
            Console.WriteLine("开始遍历");
            while (result.MoveNext())
            {
                Console.WriteLine(result.Current);
            }

            Console.WriteLine("遍历结束");
            Console.ReadLine();
        }
        //使用yield来进行迭代
        static IEnumerator GetResultByYield()
        {
            var arr = new int[] { 1, 6, 8, 12, 15 };
            foreach (var item in arr)
            {
                yield return item;
                if (item == 12)
                    yield break;
            }
        }
    }
}
