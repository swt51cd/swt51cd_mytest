using System;

namespace 委托orList
{
    public delegate void myMessageDelegate();
    class MyTestClass
    {
        public static event myMessageDelegate myDelegateEvent;

        public Action<string> strAction;
        public  static void myStaticWrite()
        {
            Console.WriteLine("委托****静态测试");
        }
        public void Write()
        {
            Console.WriteLine("委托***一个类实例方法");
            myDelegateEvent();//触发事件
        }
        public void twoWrite()
        {
            Console.WriteLine("委托***第二类实例方法");
        }
        public static void myEventOperate()
        {
            Console.WriteLine("==事件==操作方法");
        }
        public static void myAction(string str)
        {
            Console.WriteLine("我Action操作方法"+str);
        }
    }
}
