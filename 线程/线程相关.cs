using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程
{
    class 线程相关
    {
        public static void 主程序()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(i + "---主程序");
            }
        }
        public static void MyThread()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("我的私有线程^^^" + i);
            }
        }

    }
    static class MyMain
    {
        public static void main()
        {
            Console.WriteLine("Starting------------");
            Thread t = new Thread(线程相关.主程序);
            t.Start();
            //t.Join();
            t.IsBackground = true;
            线程相关.MyThread();
            Console.ReadKey();
        }

    }

    /*
     * 如果你的任务是射出一万支箭，如果只有你一个人射箭，那你就只能一箭一箭慢慢地射个老半天。如果你找一万个人，来个万箭齐发，
     * 岂不是一下子就完事了。Thread就是能让你万箭齐发的好办法。
     * 
     如果你的任务还需要汇报射箭的成绩的话，Thread就不行了。async/await可以帮你还是来个万箭齐发，但你射完不能走，得等那一万个射手给你回报成绩。

     如果你本来就只要射一箭就好，那么，async/await能让你在等待报靶的时间里面干点别的小事情，譬如赚上1个亿。
     如果你射完箭除了等待成绩之外也没别的事情可做，那么，async/await就白用了，和同步没有任何区别。
     */
    #region Async/Await
    class AsyncAwait
    {
        /// <summary>
        /// async用来修饰方法，表明这个方法是异步的，声明的方法的返回类型必须为：void，Task或Task<TResult>。
        /// </summary>
        static async Task<int> GetStrLengthAsync()
        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");
            //此处返回的<string>中的字符串类型，而不是Task<string>
            string str = await GetString();
            Console.WriteLine("GetStrLengthAsync方法执行结束");
            return str.Length;
        }


        static Task<string> GetString()
        {
            //Console.WriteLine("GetString方法开始执行");
            return Task<string>.Run(() =>
            {
                Thread.Sleep(10000);
                return "GetString的返回值";
            });
        }

        public static void AsyncAwaitMain()
        {
            Console.WriteLine("-------主线程启动-------");
            Task<int> task = GetStrLengthAsync();
            Console.WriteLine("主线程继续执行");
            Console.WriteLine("Task返回的值" + task.Result);
            Console.WriteLine("-------主线程结束-------");
            Console.ReadLine();

        }

    }
    /*
     * async 和await不是用来万箭齐发的，=。=。他是让你以类似同步的编程习惯来进行异步编程的。万箭齐发最好是用Parallel吧。
     * 第二点：你射箭完了不用管了，那么你直接开一个线程去跑就好了。然后你的主线程该干嘛干嘛这是异步最基本的诉求。
     * 用async 和await实现就是await代码后面不写任何代码，就达到了射箭完了不管的意思，如果要管的话就是await后面的代码，
     * 你可以理解await代码后面就是异步执行完await执行内容以后进行回调的代码。
     */
    #endregion

}
