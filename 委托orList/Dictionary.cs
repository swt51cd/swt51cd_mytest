using System;
using System.Collections.Generic;

namespace 委托orList
{
    class DictionayOperate
    {
        public static void MyDictionary(int? vint)
        {   /*
            Dictionary<string, string> openWith = new Dictionary<string, string>();
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");
            */
            Dictionary<string, string> openWith = new Dictionary<string, string> {
                
                ["txt"] = "notepad.exe",
                ["bmp"] = "paint.exe"
        };
            
            //字典的值
            Dictionary<string, string>.ValueCollection valueColl = openWith.Values;
            //foreach (string s in openWith.Values)
            foreach (string s in valueColl)
            {
                Console.WriteLine($"Second Method, Value = {s}");
            }

            #region int=null??值
            int myint = vint ?? 45;
            var myVar=3;
            Console.WriteLine($"myint:{myint}***myVar={myVar}");
            #endregion

            #region nameof
            Console.WriteLine("GetType:" + myint.GetType());
            Console.WriteLine("nameof:"+nameof(myint));
            #endregion

            #region int.TryParse与 int.Parse 又较为类似，但它不会产生异常，转换成功返回 true，转换失败返回 false。 
            // 最后一个参数为输出值，如果转换失败，输出值为 0，如果转换成功，输出值为转换后的int值
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                Console.WriteLine("您输入的数字是：{0}", result);
            }
            else
            {
                Console.WriteLine("无法解析输入...{0}", result);
            }
            #endregion


        }

    }
}
