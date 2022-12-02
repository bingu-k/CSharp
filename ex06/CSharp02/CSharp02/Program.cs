using System;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // List <- 동적 배열 [ 1 2 3 4 ]
            List<int> list = new List<int>();

            //list[0] = 1; 아무것도 없기 때문에 Crash!
            for (int i = 0; i < 5; i++)
                list.Add(i);
            for (int i = 0; i < 5; i++)
                Console.WriteLine(list[i]);
            foreach (int num in list)
                Console.WriteLine(num);

            // 삽입, 삭제
            list.Insert(2, 999);
            foreach (int num in list)
                Console.WriteLine(num);
            bool success = list.Remove(3);
            if (success)
                foreach (int num in list)
                    Console.WriteLine(num);
            list.RemoveAt(0);
            foreach (int num in list)
                Console.WriteLine(num);
            list.RemoveRange(1, 2);
            foreach (int num in list)
                Console.WriteLine(num);
        }
    }
}