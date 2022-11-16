using System;

namespace CSharp
{
    class Program
    {
        static void MulWrite(int a, int b)
        {
            Console.WriteLine($"{a} x {b} = {a * b}");
        }

        static void StarWrite(int num)
        {
            for (int i = 0; i < num; ++i)
                Console.Write("*");
            Console.WriteLine();
        }

        static int Factorial(int n)
        {
            if (n < 1)
                return (0);
            else if (n == 1)
                return (1);
            //for (int i = n - 1ß; i > 1; --i)
            //    n *= i;
            //return (n);
            return (n * Factorial(n - 1));
        }

        static void Main(string[] arg)
        {
            for (int a = 2; a < 10; ++a)
            {
                for (int b = 1; b < 10; ++b)
                    Program.MulWrite(a, b);
            }
            for (int i = 1; i <= 5; ++i)
                Program.StarWrite(i);
            Console.WriteLine(Program.Factorial(5));
        }
    }
}