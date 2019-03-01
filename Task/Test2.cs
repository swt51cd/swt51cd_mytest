using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task
{
    class Test2
    {
        public static void Test2_Main()
        {

            Console.WriteLine("-------主线程启动-------");
            Task<int> task = Test2.GetStrLengthAsync();
            Console.WriteLine("主线程继续执行");
            Console.WriteLine("Task返回的值" + task.Result);
            Console.WriteLine("-------主线程结束-------");
        }

        public static async Task<int> GetStrLengthAsync()

        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");

            //此处返回的<string>中的字符串类型，而不是Task<string>

            string str = await GetString();

            Console.WriteLine("GetStrLengthAsync方法执行结束");

            return str.Length;

        }

        public  static Task<string> GetString()
        {
            Console.WriteLine("GetString方法开始执行");
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                return "GetString的返回值";
            });

        }
    }
}
