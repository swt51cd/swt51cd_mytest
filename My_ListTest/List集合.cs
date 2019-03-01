using System;
using System.Collections.Generic;
using System.Linq;

namespace My_ListTest
{
    class List集合
    {
        public static void test()
        {
            List<Person> personList = new List<Person>
            {
                new Person
                {
                    Name = "P1", Age = 18, Gender = "Male",
                    Dogs = new Dog[]
                    {
                        new Dog { Name = "D1" },
                        new Dog { Name = "D2" }
                    }
                },
                new Person
                {
                    Name = "P2", Age = 19, Gender = "Male",
                    Dogs = new Dog[]
                    {
                        new Dog { Name = "D3" }
                    }
                },
                new Person
                {
                    Name = "P3", Age = 17,Gender = "Female",
                    Dogs = new Dog[]
                    {
                        new Dog { Name = "D4" },
                        new Dog { Name = "D5" },
                        new Dog { Name = "D6" }
                    }
                }
            };
            var dogs = personList.SelectMany(p => p.Dogs);
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog.Name);
            }
        }

    }
    class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public string Gender { set; get; }
        public Dog[] Dogs { set; get; }
    }
    public class Dog
    {
        public string Name { set; get; }
    }


}
