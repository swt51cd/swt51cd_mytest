using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO
{
    class 接口
    {
        public static void TestMain()
        {
            IFly fly=new Bird();
            fly.Fly();
            Console.ReadLine();
        }
    }

    public interface IFly
    {
        void Fly();
    }
    public  class Bird:IFly
    {
        public void Fly()
        {
            Console.WriteLine("鸟在飞");
        }
    }

    public interface IM1
    {
        void Fly1();
    }
    public interface IM2
    {
        void Fly2();
    }
    public interface IM1M2 : IM1, IM2
    {
        
    }
    public class BirdTest : IM1, IM2
    {
        void IM1.Fly1()
        {
            throw new NotImplementedException();
        }

        void IM2.Fly2()
        {
            throw new NotImplementedException();
        }
    }
}
