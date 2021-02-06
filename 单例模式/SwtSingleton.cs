using System;


namespace 单例模式
{
    //双重锁
    public class SwtSingleton
    {
        private static SwtSingleton Singleton;
        private static readonly Object MyLock = new object();
        private SwtSingleton() { }

        //公布出来调用
        public static SwtSingleton GetSingleton()
        {
            if (Singleton == null)
            {
                lock (MyLock)
                {
                    if (Singleton == null)
                    {
                        Singleton = new SwtSingleton();
                        Console.WriteLine("构造成功");
                    }
                }
            }
            return Singleton;
        }
        public static void DoNothing()
        {
            Console.WriteLine("进入DoNothing");
        }
    }

    //饿汉模式1 静态成员  生成
    public class TwoSingleton
    {
        private static readonly TwoSingleton Singleton = new TwoSingleton();

        private TwoSingleton() { }
        //公布出来调用
        public static TwoSingleton GetSingleton()
        {
            return Singleton;
        }
        public static void DoNothing()
        {
            Console.WriteLine("进入DoNothing");
        }
        public void Show()
        {
            Console.WriteLine("进入Show");
        }
    }

    //饿汉模式2 静态构造函数 生成
    public class SingletonThree
    {
        private static readonly SingletonThree Singleton=null;
        private SingletonThree() { }
        //1与2的区别只是 一个静态构造函数，一个静态成员 生成
        static SingletonThree() 
        {
            Singleton=new SingletonThree();
        }
        public static SingletonThree GetSingleton()
        {
            return Singleton;
        }
        public static void DoNothing()
        {
            Console.WriteLine("进入DoNothing");
        }
        public void Show()
        {
            Console.WriteLine("进入Show");
        }
    }

}
