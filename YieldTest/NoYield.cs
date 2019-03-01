using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldTest
{
    class NoYield
    {
       public static void NMain()
        {
            //得到一个迭代结果
            var result = GetResult();
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
        //不使用yield来进行迭代
        static IEnumerator<int> GetResult()
        {
            var arr = new int[] { 1, 6, 8, 12, 15 };
            List<int> list = new List<int>();
            foreach (int item in arr)
            {
                if (item < 12)
                    list.Add(item);
            }
            return list.GetEnumerator();
        }

    }
  
}
