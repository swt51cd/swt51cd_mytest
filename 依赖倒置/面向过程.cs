using System;

namespace 依赖倒置
{
    class 面向过程
    {
      public  static void DIP_Main()
        {
            var oSpider = new DeviceService("1");
            oSpider.LoginDevice();
            var bRes = oSpider.DeviceSpider();
            Console.ReadKey();
        }
    }

    //设备采集的服务
    public class DeviceService
    {
        private readonly DeviceMml _mml = null;
        private readonly DeviceTl2 _tl2 = null;
        private readonly string _mType = null;
        //构造函数里面通过类型来判断是哪种类型的设备
        public DeviceService(string type)
        {
            _mType = type;
            if (type == "0")
            {
                _mml = new DeviceMml();
            }
            else if (type == "1")
            {
                _tl2 = new DeviceTl2();
            }
        }

        public void LoginDevice()
        {
            if (_mType == "0")
            {
                _mml.Login();
            }
            else if (_mType == "1")
            {
                _tl2.Login();
            }
        }

        public bool DeviceSpider()
        {
            if (_mType == "0")
            {
                return _mml.Spider();
            }
            else if (_mType == "1")
            {
                return _tl2.Spider();
            }
            else
            {
                return true;
            }
        }
    }

    //MML类型的设备
    public class DeviceMml
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
    class DeviceTl2
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

}
