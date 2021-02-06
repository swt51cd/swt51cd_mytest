using System;

namespace 依赖倒置
{
    //高层模块不应该依赖低层模块，两者都应该依赖其抽象；抽象不应该依赖细节，细节应该依赖抽象。
    //接口和抽象类不应该依赖于实现类，而实现类依赖接口或抽象类。这一点其实不用多说，很好理解，“面向接口编程”思想正是这点的最好体现。
   public class Dip
    {
      public  static void Dip_Main()
        {
            var oSpider = new DipDeviceService(new DipDeviceTl5());
            oSpider.LoginDevice();
            var bRes = oSpider.DeviceSpider();
          
        }
    }
    //定义一个统一接口用于依赖
    public interface IDevice
    {
        void Login();
        bool Spider();
    }
    //Mml类型的设备
    public partial class DipDeviceMml : IDevice
    {
        public void Login()
        {
            Console.WriteLine("MML设备登录");
        }
        public bool Spider()
        {
            Console.WriteLine("MML设备采集");
            return true;
        }
    }
    //TL2类型设备
    public class DipDeviceTl2 : IDevice
    {
        public void Login()
        {
            Console.WriteLine("TL2设备登录");
        }
        public bool Spider()
        {
            Console.WriteLine("TL2设备采集");
            return true;
        }
    }
    //TELNET类型设备
    public class DipDeviceTelnet : IDevice
    {
        public void Login()
        {
            Console.WriteLine("TELNET设备登录");
        }
        public bool Spider()
        {
            Console.WriteLine("TELNET设备采集");
            return true;
        }
    }
    //TL5类型设备
    public class DipDeviceTl5 : IDevice
    {
        public void Login()
        {
            Console.WriteLine("TL5设备登录");
        }
        public bool Spider()
        {
            Console.WriteLine("TL5设备采集");
            return true;
        }
    }
    //设备采集的服务
    public class DipDeviceService
    {
        private readonly IDevice _mDevice;
        public DipDeviceService(IDevice oDevice)
        {
            _mDevice = oDevice;
        }
        public void LoginDevice()
        {
            _mDevice.Login();
        }
        public bool DeviceSpider()
        {
            return _mDevice.Spider();
        }
    }
}
