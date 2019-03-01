using System;

namespace Task
{
    class Test3
    {
        public static void Test3_Main()
        {

            System.Threading.Tasks.Task t = example1();
            t.Wait();
        }

        public static async System.Threading.Tasks.Task DoWork()
        {
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Working..{0}", i);
                //await Task.Delay(1000);//以前我们用Thread.Sleep(1000)，这是它的替代方式。
                await System.Threading.Tasks.Task.Delay(1000);
            }
        }
        public static async System.Threading.Tasks.Task example1()
        {
            await DoWork();
            Console.WriteLine("First async Run End");
        }
    }
}
