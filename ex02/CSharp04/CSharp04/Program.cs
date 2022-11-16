using System;

namespace CSharp
{
    class Program
    {
        // Method, Function
        //static void HelloWorld(int num = 1)
        //{
        //    for (int i = 0; i < num; ++i)
        //        Console.WriteLine("Hello World!");
        //}

        static int Add(int a, int b)
        {
            return (a + b);
        }
        static double   Add(double a, double b)
        {
            return (a + b);
        }
        static float    Add(float a, float b)
        {
            return (a + b);
        }

        static void AddOneRef(ref int num)
        {
            ++num;
        }

        static void AddOne(int num)
        {
            ++num;
        }

        static int  AddOne2(int num)
        {
            return (num + 1);
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Divide(int a, int b, out int result1, out int result2)
        {
            result1 = a / b;
            result2 = a % b;
        }

        static void Main(string[] arg)
        {
            Console.WriteLine(Program.Add(4, 5));
            Console.WriteLine(Program.Add(4.0, 5.0));
            Console.WriteLine(Program.Add(4.0f, 5.0f));

            int num = 0;
            Program.AddOne(num);
            Console.WriteLine(num);
            Program.AddOneRef(ref num);
            Console.WriteLine(num);
            Console.WriteLine(Program.AddOne2(num));

            int a = 1;
            int b = 2;
            Program.Swap(ref a, ref b);
            Console.WriteLine($"Numbers : a = {a}, b = {b}");

            Program.Divide(10, 3, out a, out b);
            Console.WriteLine($"Numbers : a = {a}, b = {b}");
        }
    }
}