namespace 单例模式
{
    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class MySingleton
    {
        // 定义一个静态变量来保存类的实例
        private static MySingleton _uniqueInstance;

        // 定义私有构造函数，使外界不能创建该类实例
        private MySingleton()
        {
        }
        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// 提供外部一个静态实例。
        /// </summary>
        /// <returns></returns>
        public static MySingleton GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (_uniqueInstance == null)
            {
                _uniqueInstance = new MySingleton();
            }
            return _uniqueInstance;
        }
    }

    /**
    上面的单例模式的实现在单线程下确实是完美的,然而在多线程的情况下会得到多个Singleton实例,因为在两个线程同时运行GetInstance方法时，
    此时两个线程判断(uniqueInstance ==null)这个条件时都返回真，此时两个线程就都会创建Singleton的实例，这样就违背了我们单例模式初衷了，
    既然上面的实现会运行多个线程执行，那我们对于多线程的解决方案自然就是使GetInstance方法在同一时间只运行一个线程运行就好了，
    也就是我们线程同步的问题了(对于线程同步大家也可以参考我线程同步的文章),具体的解决多线程的代码如下:
    **/
    public class ThreadSingleton
    {
        private ThreadSingleton() { }
        private static ThreadSingleton _uniqueInstance;
        private static readonly object Locker = new object();
        public static ThreadSingleton GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            lock (Locker)
            {
                if (_uniqueInstance == null)// 如果类的实例不存在则创建，否则直接返回
                {
                    _uniqueInstance = new ThreadSingleton();
                }
            }
            return _uniqueInstance;
        }

    }
    /**
    上面这种解决方案确实可以解决多线程的问题,但是上面代码对于每个线程都会对线程辅助对象locker加锁之后再判断实例是否存在，
    对于这个操作完全没有必要的，因为当第一个线程创建了该类的实例之后，后面的线程此时只需要直接判断（uniqueInstance==null）为假，
    此时完全没必要对线程辅助对象加锁之后再去判断，所以上面的实现方式增加了额外的开销，损失了性能，为了改进上面实现方式的缺陷，
    我们只需要在lock语句前面加一句（uniqueInstance==null）的判断就可以避免锁所增加的额外开销，这种实现方式我们就叫它 “双重锁定”，
    下面具体看看实现代码的：
      public static ThreadSingleton GetInstance()
        {
        if (uniqueInstance == null)

            lock (locker)
            {
               if (uniqueInstance == null)// 如果类的实例不存在则创建，否则直接返回
                {
                    uniqueInstance = new ThreadSingleton();
                }
            }
            return uniqueInstance;
        }
    **/

    //*****************第三种可能是C#这样的高级语言特有的，实在懒得出奇
    //下面是利用.NET Framework平台优势实现Singleton模式的代码：
    sealed class ThreeSingleton
    {
        private ThreeSingleton() { }
        public static readonly ThreeSingleton Instance = new ThreeSingleton();
    }

    //这使得代码减少了许多，同时也解决了线程问题带来的性能上损失。
    /**
    注意到，Singleton类被声明为sealed，以此保证它自己不会被继承，其次没有了Instance的方法，
    将原来_instance成员变量变成public readonly，并在声明时被初始化。通过这些改变，我们确实得到了Singleton的模式，
    原因是在JIT的处理过程中，如果类中的static属性被任何方法使用时，.NET Framework将对这个属性进行初始化，
    于是在初始化Instance属性的同时Singleton类实例得以创建和装载。而私有的构造函数和readonly(只读)保证了Singleton不会被再次实例化，
    这正是Singleton设计模式的意图。
    **/

    //???不过这也带来了一些问题，比如无法继承，实例在程序一运行就被初始化，无法实现延迟初始化等。

    //-------------第四版本更好
    //public sealed  class FourthSingleton 也可以看情况使用
    public class FourthSingleton
    {
        private static readonly FourthSingleton instance = new FourthSingleton();

        private FourthSingleton()
        {
        }

        static FourthSingleton()
        {
        }

        public static FourthSingleton Instance => instance;
        //public static FourthSingleton Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}
    }

    /**
 下面对静态构造函数做一个科普：

静态构造函数用来初始化静态变量，这个构造函数是属于类的，而不是属于哪个实例的。
就是说这个构造函数只会被执行一次。也就是在创建第一个实例或引用任何静态成员之前，由.NET自动调用。

静态构造函数的特点：

1.静态构造函数既没有访问修饰符，也没有参数。
2.在创建第一个实例或引用任何静态成员之前，将自动调用静态构造函数来初始化类，也就是无法直接调用静态构造函数，也无法控制什么时候执行静态构造函数。
3.一个类只能有一个静态构造函数，最多只能运行一次。
4.静态构造函数不可以被继承。
5.如果没有静态构造函数，而类中的静态成员有初始值，那么编译器会自动生成默认的静态构造函数。

从这里可以看出静态构造函数的调用时机不是由程序员掌控的，而是当.NET运行时发现第一次使用一个类型的时候自动调用该类型的静态构造函数。

但是这种方法会过早的穿件实例，从而降低了内存的使用效率。
     * 
 依赖公共语言运行库负责处理变量初始化 
公共静态属性为访问实例提供了一个全局访问点
对实例化机制的控制权较少(.NET代为实现)
静态初始化是在 .NET 中实现 Singleton 的首选方法
     **/

    //------------------------------第5555555完全懒惰的实例化
    public class FiveSingleton
    {
        private FiveSingleton() { }

        public static FiveSingleton GetInstance()
        {
            return Nested.instance;
        }

        //外部类只可以访问内部类的public和interal权限的字段、方法、属性
        //嵌套类可以访问外部类的方法、属性、字段而不受访问修饰符的限制
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly FiveSingleton instance = new FiveSingleton();
        }
    }

}
