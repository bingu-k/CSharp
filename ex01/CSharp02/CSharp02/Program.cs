using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 비트 연산
            int num = 1;    // 0b01
            Console.WriteLine(num);

            num = num << 3; // 0b1000
            Console.WriteLine(num);
            
            num = num >> 1; // 0b100
            Console.WriteLine(num);

            int limitNum = 1;
            limitNum = limitNum >> 1;
            Console.WriteLine(limitNum);
            limitNum = limitNum >> 3;
            Console.WriteLine(limitNum);

            int num1 = 15;  //0b0000 1111
            int num2 = 7;   //0b0000 0111
            Console.WriteLine(num1 & num2); //0b0000 0111[AND]
            Console.WriteLine(num1 | num2); //0b0000 1111[OR]
            Console.WriteLine(num1 ^ num2); //0b0000 1000[XOR]
            Console.WriteLine(~num1);       //0b1111 0000[NOT]

            // c++에서 auto같은 느낌
                // 남용하면 안된다.(읽는 사람을 배려하지 않은 행동!)
            var Number = 3;
            var String = "Hello World!";
        }
    }
}