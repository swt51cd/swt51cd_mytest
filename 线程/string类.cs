using System;
using System.Collections.Generic;
using System.Text;

namespace 线程
{
   public static class String类
    {
        /// <summary>
        /// 如何根据分隔符(比如逗号)，将List<string>泛型集合合并成一个string字符串？以往的开发中， 都是使用循环的方式来拼接成字符串，
        /// 不仅要写更多的代码不说，还会消耗更多的系统资源。现在一般使用string.Join(string separator, IEnumerable<T> values)这个方法来将集合通过分隔符合并成字符串。
        /// </summary>
        public static void Look_StringJoin()
        {
            List<string> testList = new List<string> { "Jim", "John", "Linda", "Sam" };
            string result = string.Join(",", testList);
            Console.WriteLine("字符串按[,]分割 :" + result);
        }
    }
}
