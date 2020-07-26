
using System;
using System.Collections.Generic;
using System.Linq;


namespace Linq
{
    public class StudentLinq
    {
        public static void Linqs()
        {
            List<StudentTest> studentTests = new List<StudentTest> {
                new StudentTest { Name = "Swt", Age = 30 },
                new StudentTest { Name = "Hhh", Age = 18 },
                new StudentTest { Name = "Sbx", Age = 5 },
                new StudentTest("aaa",23){Id = 10}//初始化器
            };
            foreach (var students in studentTests)
            {
                Console.WriteLine(students.Name + "-" + students.Age);
            }
            Console.WriteLine("~~~~~~~~~方法一：linq~~~~~~~~~~~");
            //方法一：linq
            var studentQuery = from test in studentTests
                               where test.Age > 15
                               select new { Name = test.Name, test.Age,test.Id };

            foreach (var student in studentQuery)
            {
                Console.WriteLine(student.Name + "-" + student.Age + "-" + student.Id);
            }
            Console.WriteLine("~~~~~~~~~方法二：函数~~~~~~~~~~~");
            //方法二：函数
            var testSelects = studentTests.Where(a => a.Age < 15);
            foreach (var testSelect in testSelects)
            {
                Console.WriteLine(testSelect.Name);
                Console.WriteLine($"拓展方法结果：{testSelect.NameTend()}");
                Console.WriteLine($"重写ToString：{testSelect.ToString()}");
            }
        }
    }

    public class StudentTest
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public int Id { set; get; }

        public StudentTest()
        {

        }

        public StudentTest(string v1, int v2)
        {
            this.Name = v1;
            this.Age = v2;
        }


        public override string ToString()
        {
            return "年龄" + Age.ToString();
        }
    }

    public static class Dog
    {
        public static string NameTend(this StudentTest studentTest)
        {
            return "年龄" + studentTest.Age.ToString();
        }
    }

}
