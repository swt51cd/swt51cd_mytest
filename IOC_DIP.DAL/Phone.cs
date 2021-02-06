using System;
using IOC_DIP.IDAL;

namespace IOC_DIP.DAL
{
    public class Phone : AbstractPhone
    {
        /// <summary>
        /// 电话
        /// </summary>
        public override void Call()
        {
            Console.WriteLine($"{this.GetType().Name}");
        }
        /// <summary>
        /// 短信
        /// </summary>
        public override void Text()
        {
            Console.WriteLine($"{this.GetType().Name}");
        }
    }
}
