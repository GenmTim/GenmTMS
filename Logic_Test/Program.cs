using System;

namespace Logic_Test
{
    class Test
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            String str = "/resr/ettsg/dsgg";
            foreach (var val in str.Split('/'))
            {
                Console.WriteLine(val);
            }

            Console.ReadKey();
        }
    }
}
