using System;
using System.Collections.Generic;

namespace 委托orList
{
    class MyMain
    {
        static void Main(string[] args)
        {
            string AtoB = "参数(测试)";
            string age = "10";

            #region String.Format的改进
            //string s2 = string.Format("姓名={0},年龄={1}", AtoB, age);
            string BtoA = $"姓名={AtoB},年龄={age}";
            #endregion

            #region 开始
            Console.WriteLine("测试!");
            #endregion

            #region List的操作
            //MyTestWT();
            //StrArrtoList();
            ListtoStrArr();
            #endregion

            #region 事件绑定方法或者注册  触发事件代码在类里
            Console.WriteLine("<注册事件>");
            MyTestClass.myDelegateEvent += MyTestClass.myEventOperate;
            Console.WriteLine("<注册事件>");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            #endregion

            #region 委托
            Console.WriteLine("<委托>");
            myMessageDelegate testDelegate = new myMessageDelegate(MyTestClass.myStaticWrite);
            MyTestClass myTestClass = new MyTestClass();
            testDelegate += new myMessageDelegate(myTestClass.Write);
            //testDelegate += new myMessageDelegate(myDelegateClass.twoWrite);
            //testDelegate += myTestClass.twoWrite; //另一种引用
            testDelegate();
            Console.WriteLine("<委托>");
            Console.WriteLine("^^^^^^^^^^^^^^^^");
            #endregion

            #region Action Func 无返回就用action，有返回就用Func
            //方法一：采用匿名委托，方法二：指定一个实际的方法。方法三：使用Lamda表达式
            Console.WriteLine("<Action>");
            //myTestClass.strAction = delegate(string var){ varstr = var; Console.WriteLine("匿名函数 varstr=" + varstr);  };
            myTestClass.strAction = new Action<string>(MyTestClass.myAction);
            //myTestClass.strAction = (string str)=>{ Console.WriteLine("lamda"); };
            myTestClass.strAction(BtoA);
            Console.WriteLine("<Action>");
            Console.WriteLine("^^^^^^^^^^^^^^^^^");
            #endregion


            #region Dictionary
            Console.WriteLine("******Dictionary******");
            int? myint = null;
            DictionayOperate.MyDictionary(myint);
            Console.WriteLine("******Dictionary******");
            #endregion

            #region 结束
            Console.WriteLine("END结束!");
            Console.ReadKey();

            #endregion
        }

        #region List<Add,AddRange,Insert>
        public static void MyMethod()
        {
            List<string> myList = new List<string>();
            string[] Arr = { "a", "b", "c" };
            string[] Arr2 = { "f", "g", "h" };

            myList.Add("p");
            myList.AddRange(Arr2);
            myList.Insert(1, "dd");

            foreach (string item in myList)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region list.AddRange =Concat 要复杂些，与 AddRange 最明显的区别是不直接改变原对象的值，而是通过返回值赋值的形式改变
        public static void MyTest()
        {
            List<int> l1 = new List<int>();
            l1.Add(1);
            l1.Add(2);

            List<int> l2 = new List<int>();
            l2.Add(3);
            l2.Add(4);
            l1.AddRange(l2);
            //Concat 要复杂些，与 AddRange 最明显的区别是不直接改变原对象的值，而是通过返回值赋值的形式改变
            //l1 = l1.Concat<int>(l2).ToList(); 结果==l1.AddRange(l2);
            for (int i = 0; i < l1.Count; i++)
            {
                Console.WriteLine(l1[i]);
            }
        }
        #endregion


        public static void MyTestWT()
        {
            List<string> myList = new List<string>();
            string[] temArr = { "Ha", "Hunter", "Tomtutsldfsf", "Lily", "Jay", "Jim", "Kuku", "Locu" };
            myList.AddRange(temArr);
            //string listFind = myList.Find(Tom =>  //name是变量，myList
            //{                              //中元素，自己设定
            //    if (Tom.Length >2)
            //    {
            //        return true;
            //    }
            //    return false;
            //});
            string listFind1 = myList.Find(ListFind);  //委托给ListFind函数

            #region Predicate是对方法的委托
            //Predicate是对方法的委托，如果传递给它的对象与委托中定义的条件匹配，则该方法返回 true。当前 List 的元素被逐个传递给Predicate委托，并在 List 中向前移动，从第一个元素开始，到最后一个元素结束。当找到匹配项时处理即停止。
            // Predicate 可以委托给一个函数或者一个拉姆达表达式:
            // 委托给拉姆达表达式：
            #endregion

            Console.WriteLine(listFind1);              //输出是Hunter
        }

        public static bool ListFind(string name)
        {
            if (name.Length > 9)
            {
                return true;
            }
            return false;
        }
        public static void StrArrtoList()
        {
            List<string> myist = new List<string>();
            string[] str = { "1", "2", "3" };
            myist = new List<string>(str);
            foreach (string item in myist)
            {
                Console.WriteLine(item);
            }
            // Console.WriteLine(myist);
        }
        public static void ListtoStrArr()
        {
            List<System.String> list = new List<System.String>();
            list.Add("1"); list.Add("2"); list.Add("3");
            var strArr = list.ToArray();
            foreach (string item in strArr)
            {
                Console.WriteLine(item);
            }
        }
    }

}


