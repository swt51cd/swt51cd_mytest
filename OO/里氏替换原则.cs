using System;
namespace OO
{
    class 里氏替换原则
    {
        public static void TestMain()
        {
            Person p = new Person();
            Person p1 = new Student();
            p1.Say();     //只能访问父类东东
            Student s2 = (Student)p1;
            s2.SayStude();//访问范围扩大了

            Student s222 = new SeniorStudent();
            SeniorStudent s3 = (SeniorStudent)s222;
            s3.SaySenior();
        }
    }
    class Person
    {
        //父类的私有成员
        private int _Age=12;
        public Person()
        {
            Console.WriteLine("我是Person构造函数，我是一个人！");
        }
        public void Say()
        {
            Console.WriteLine("我是一个人！"+_Age.ToString());
        }

    }

    class Student : Person
    {
        public Student()
        {
            Console.WriteLine("我是Student构造函数，我是一个学生！");
        }

        public void SayStude()
        {
            Console.WriteLine("我是一个学生！");
        }
    }

    class SeniorStudent : Student
    {
        public SeniorStudent()
        {
            Console.WriteLine("我是SeniorStudent构造函数，我是一个高中生！");
        }
        public void SaySenior()
        {
            Console.WriteLine("我是一个高中生！");
        }
    }
}
