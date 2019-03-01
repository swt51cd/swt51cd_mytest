using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            #region test
            MyTest.test();
            MyTest.log("main：调用test后");
            //thread.sleep(timeout.infinite);
            #endregion

            #region test2
            //Test2.Test2_Main();
            #endregion

            //Test3.Test3_Main();
            // Test4.ParentChildTask();
            Console.ReadLine();
        }
    }
}
