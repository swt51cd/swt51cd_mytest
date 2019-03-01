using System;

namespace Virtual
{
    public class ExerciseA
    {
        public void EntityMethod()
        {
            Console.WriteLine("A.EntityMethod");
        }

        public virtual void VirtualMethod()
        {
            Console.WriteLine("A.VirtualMethod");
        }
    }

    public class ExerciseB : ExerciseA
    {
         public new void EntityMethod()
        {
            Console.WriteLine("B.EntityMethod");
        }

        public override void VirtualMethod()
        {
            Console.WriteLine("B.overrideVirtualMethod");
        }
    }

    class Exercise
    {
       public static void ExerciseMain()
        {

            //它仅是一个引用，保存在线程的栈上，用于将来存放B对象的有效地址。此时 b 未指向任何有效的实例，值为null，
            ExerciseB b;
            #region b = new ExerciseB() 解释
            /**
             * 对象的实例保存在托管堆上，CLR在创建一个新对象的同时，还会创建它的类型对象(如果类型对象不存在)。
             * 对象实例在堆中的内存包括实例字段、类型对象指针、同步索引块，类型对象指针指向类型对象。
　　           类型对象在堆中分配的内存包括类型对象指针、同步索引块、静态字段、方法表。
             */
            #endregion
            b = new ExerciseB();
            // A a = b;  这行代码首先声明一个类型为A的引用类型变量a，并将其实际地址指向b所指向的对象实例。
            ExerciseA a = b;
            #region a.EntityMethod 解释
            /**
             *当调用一个对象的方法时，会直接检查这个对象变量(a)的类型 ，找到堆中的类型对象，查看是否有该方法，
             * 没有则通过类型对象的类型对象指针向上回溯查找，直至找到，然后检查该方法是否为虚方法，
             * 如果非虚，直接调用，EntityMethod 方法是非虚的，因此直接调用输出A.F。
             */
            #endregion
            a.EntityMethod();
            b.EntityMethod();
            #region a.VirtualMethod() 解释
            /**
             * 如果该方法为虚方法，即有virtual 关键字，则根据对象变量(a)，去找到对象的实例类B，
             * 查找该类型对象中是否重新实现过该虚方法(override 关键字)，如果有，OK执行，如果没有，向上检查其父类，
             * 直至找到然后执行，VirtualMethod，则会查找实例B，由于B中重写了VirtualMethod，因此此处输出B.G。
            */
            #endregion
            a.VirtualMethod();
            b.VirtualMethod();
        }
    }

}
