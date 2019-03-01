using System;
using System.Collections.Generic;

namespace YieldTest
{
    class YieldTest
    {
       public static void YieldTestMain()
        {
            HelloCollection helloCollection = new HelloCollection();
            foreach (string s in helloCollection)
            {
                Console.WriteLine(s);
            }
        }
    }
    public class HelloCollection
    {
        public IEnumerator<String> GetEnumerator()
        {
            // yield return语句返回集合的一个元素，并移动到下一个元素上；yield break可以停止迭代
            yield return "Hello";
            yield return "World";
        }
    }
}
