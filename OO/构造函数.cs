using System;

namespace OO
{
    class 构造函数
    {
        public static void TestMain()
        {
            Animal animal = new Dog(20, "this");
            Console.ReadLine();
        }
    }

    public class Animal
    {
        public int Age;
        public string Str;
        public Animal()
        {
            Console.WriteLine("父类构造函数");
        }
        public Animal(int age)
        {
            Console.WriteLine("父类---构造函数");
            this.Age = age;
        }
    }

    public class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("子类构造函数");
        }
        public Dog(int age) : base(age)
        {
            Console.WriteLine("子类---构造函数");
        }
        public Dog(int age, string str) : this(age)
        {
            this.Str = str;
            Console.WriteLine($@"this---构造函数{this.Age},{this.Str}");
        }
    }
}
