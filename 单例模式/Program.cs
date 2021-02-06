using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() =>
                {
                    //Singleton.GetInstance();

                    #region 双重锁定
                    //SwtSingleton.DoNothing();
                    //SwtSingleton.GetSingleton();
                    #endregion

                    #region 饿汉模式1
                    //TwoSingleton.DoNothing();
                    //var singleton = TwoSingleton.GetSingleton();
                    //singleton.Show();
                    #endregion

                    #region 饿汉模式2
                    SingletonThree.DoNothing();
                    var singleton = SingletonThree.GetSingleton();
                    singleton.Show();
                    #endregion

                });
            }
            Console.ReadKey();
        }
    }
}
