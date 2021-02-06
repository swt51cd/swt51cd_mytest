using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO
{
    public class 假装饰
    {
       public static void XMain()
        {
            DisposeTest dispose=new DisposeTest(){ Age =11,Str = "No"};
            TestDispose Test = new TestDispose(dispose);
            Test.Close();
            Test.Dispose();
            if (dispose==null)
            {
                Console.WriteLine("ok清理干净了");
            }
            using (Test)
            { Console.WriteLine("Test清理干净了");
                
            }

         
           

            Console.ReadKey();
        }
        

    }

    public class DisposeTest
    {
        public int Age;
        public string Str;
        public DisposeTest()
        {
            Console.WriteLine("父类构造函数");
        }
    }
    public class TestDispose:IDisposable
    {
        private DisposeTest _disposeTest;
        public string Str;
        public TestDispose(DisposeTest dispose)
        {
            _disposeTest = dispose;
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
           
            GC.SuppressFinalize(_disposeTest);
        }
    }

}
