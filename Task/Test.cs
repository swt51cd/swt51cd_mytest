using System;
using System.Threading;

namespace Task
{
    class MyTest
    {
        public static async System.Threading.Tasks.Task doo()
        {
            log("doo: Task结果：" + await System.Threading.Tasks.Task.Run(() => { Thread.Sleep(1000); log("Task"); return 1; }));
            log("doo: Task结果：" + await System.Threading.Tasks.Task.Run(() => { Thread.Sleep(1000); log("Task"); return 2; }));
            log("doo: Task结果：" + await System.Threading.Tasks.Task.Run(() => { Thread.Sleep(1000); log("Task"); return 3; }));
            Thread.Sleep(1000);
            Console.WriteLine(" doo中在Task外的Thread.Sleep执行完毕");
        }
        //输出方法：显示当前线程的ManagedThreadId
        public static void log(string msg)
        {
            Console.WriteLine("{0}: {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }
        public static async void test()
        {
            log("test: await之前");
            await doo();
            log("test: await之后");
        }
    }
}
