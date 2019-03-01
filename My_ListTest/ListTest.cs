using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_ListTest
{
    
    /// <summary>
    /// 泛型参数
    /// </summary>
    class ListTest
    {
        public static void MySay<T>(T spk)
        {
            Console.WriteLine("wo 说"+spk);
            
        }

        public void Test()
        {
            
        }

        /// <summary>
        /// 泛型 参数类型判断 三种方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="test"></param>
        /// <returns></returns>
        public static T MyTest<T>(T test)
        {
            //string _test = "";
            T temp = default(T);

            //1 类型判断 类的实例
            Type mytype = test.GetType();
            if (mytype.Name=="String")
            {
                Console.WriteLine("泛型参数【String】参数：" + test);
            }

            //2 类型判断 类
            Type type = typeof(T);

            //3 类型判断
            if (test is int)
            {
                Console.WriteLine("泛型参数是【int】 参数："+test);
            }
            
            return test;
        }
          
    }
    /// <summary>
    /// 泛型重载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Node<T, V>
    {
        public T add(T a, V b)          //第一个add
        {
            return a;
        }
        public T add(V a, T b)          //第二个add
        {
            return b;
        }
        public int add(int a, int b)    //第三个add
        {
            return a + b;
        }

    }
}
