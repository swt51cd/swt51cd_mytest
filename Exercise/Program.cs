using System;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var child = (int)EnumPractice.Child;
            Console.WriteLine("枚举值：" + child);
            Console.WriteLine("枚举:" + EnumPractice.Child);

            var str1 = int.Parse("123");
            Console.WriteLine(str1.ToString());
            EnumPractice enup = EnumPractice.Parent;
            Console.WriteLine(enup);
            var x3 = Enum.Parse(typeof(EnumPractice), "1");
            //var x3 = Enum.Parse(typeof(EnumPractice), "Child");相同
            Console.WriteLine("枚举:" + x3);
            foreach (var item in Enum.GetValues(typeof(EnumPractice)))
            {
                var v = item;//child/parent
                var v2 = (int)item;//1/2
                var t = item.GetType();//{Name = "EnumPractice" FullName = "Exercise.Enum.EnumPractice"}
                var g = item.ToString();//"child/parent"]
            }
            Console.ReadLine();
        }

    }

}
