using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] arg)
        {
            // --------------- 반복문 ----------------

            //int count = 5;
            //while (count-- > 0)
            //    Console.WriteLine("Hello While!");
            //count = 5;
            //do
            //{
            //    Console.WriteLine("Hello Do While!");
            //} while (count-- > 0);

            //string ans = "n";
            //do
            //{
            //    Console.Write("넌 잘생겼니?(y/n) : ");
            //    ans = Console.ReadLine();
            //} while (ans != "y");
            //Console.WriteLine("ㅋㅋㅋㅋㅋㅋㅋㅋㅋ");

            //for (int i = 0; i < 5; ++i)
            //    Console.WriteLine("Hello For!");

            // --------------- 중단문 ----------------

                // 소수찾기 예제
            int num = 97;
            bool isPrime = true;
            for (int i = 2; i < num; ++i)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
                Console.WriteLine("소수 입니다!");
            else
                Console.WriteLine("소수가 아닙니다!");

            // --------------- 연속문 ---------------
            for (int i = 1; i <= 100; ++i)
            {
                if (i % 3 != 0)
                    continue;
                Console.WriteLine($"3으로 나뉘는 숫자 : {i}");
            }
        }
    }
}