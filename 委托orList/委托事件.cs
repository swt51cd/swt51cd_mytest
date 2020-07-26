using System;

namespace 委托orList
{
   
    class Person
    {
        private string _name;
        public int MyCount { get; set; } = 1;
        public string Name { get => _name; set => _name = value; }
        public Person(string strName)
        {
            this._name = strName;
            Console.WriteLine("构造函数");
        }
    }
    abstract class Finery
    {
        public abstract void show();
    }
    class TSh :Finery
    {
        public override void show()
        {
            Console.WriteLine("T恤");
        }
    }
    class Shoes:Finery
    {
        public override void show()
        {
            Console.WriteLine("穿鞋");
        }
    }
}
