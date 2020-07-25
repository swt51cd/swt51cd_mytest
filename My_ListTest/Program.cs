using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_ListTest
{
    class Program
    {

        static void Main(string[] args)
        {

            //ListTest.MySay<string>("我饿了！");
            //ListTest.MySay<int>(123);

            #region  泛型重载
            //Node<string, int> node = new Node<string, int>();
            //object x = node.add(2, "11");
            ////object x = node.add(2, 11);
            //Console.WriteLine("**********  " + x);
            #endregion

            #region 泛型类型判断
            //ListTest.MyTest(520);
            #endregion

            #region List集合
            List集合.test();
            Console.ReadLine();
            #endregion
        }
    }
}
