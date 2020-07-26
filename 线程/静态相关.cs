using System;
using System.Collections.Generic;
using System.Text;

namespace 线程
{
    class 静态相关类
    {
        /*
         * 存储区别：对于静态成员而言，它是存储在程序中全局变量存储区中，并且在整个程序运行期间只在内存中有一个位置，既不会拷贝也不会复制。
         * 归属区别：静态成员属于类的成员变量，无论对一个类实例化多少次，这个类的静态成员都只有一个副本，程序中各个地方对它的调用都会改变它的值；
         * 而非静态成员属于他的对象，各自对象对自身实例的改变不会各自影响。
         * 初始化顺序的区别：初始化时首先初始化类的静态成员，然后才是非静态成员
         */
        int j = getNum();
        private static int i = getNum();
        private static int num = 1;
        private static int getNum()
        {
            return num;
        }
        /// <summary>
        /// //线程是有前后之分的，默认显示创建的线程都是前台线程，而进程会等待所有的前台线程结束后自动关闭程序，
        /// 不管后台线程的死活，不过如果程序定义了一个永远不会执行完的线程那么就可以等待后台线程执行完了，比如 Console.ReadKey()，
        /// </summary>
        public static void main()
        {
            Console.WriteLine("Hello World!");
            //MyMain.main();
            Console.WriteLine($"num={num}");
            Console.WriteLine("i={0}", i);
            //num = 2;
            Console.WriteLine("---------------------");
            静态相关类 myObject = new 静态相关类();//默认构造函数
            Console.WriteLine($"num={num}");
            Console.WriteLine("j={0}", myObject.j);
            Console.WriteLine("i={0}", i);
            Console.ReadKey();

        }
    }
    /// <summary>
    /// 静态类的主要功能如下：类中仅包含静态成员和静态方法。并且必须被static修饰。
    /// 它们不能被实例化。 它们是密封的。那么此时编译器编译时会自动生成sealed标记。
    /// 项目中使用静态类的优点在于，对于静态类的创建，编译器能够执行检查以确保不会偶然的添加实例成员。同时，静态类时密封的，因此也不允许被继承。
    /// </summary>
    static class 静态类
    {
        public static void Test()
        {
            Console.WriteLine("静态类里的静态方法");
        }

    }
}
