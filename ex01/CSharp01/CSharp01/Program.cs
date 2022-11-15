using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            // 정수
                // byte[1byte 0~255], short[2byte -3만~3만], int[4byte -21억~21억], long[8byte]
                // sbyte[1byte -128~127], ushort[2byte 0~6만], uint[4byte 0~43억], ulong[8byte]
            int hp = 100;
            short level = 100;
            long id = 0;

            byte attack = 0;
            --attack;   // UnderFlow
            Console.WriteLine("Hello, Number! {0}", attack);

                // 10진수
                // 표현 할 수 있는 숫자 : 0 1 2 3 4 5 6 7 8 9

                // 2진수
                // 표현 할 수 있는 숫자 : 0 1
                // ex) 0b00 0b01 0b10 0b11 0b100

                // 16진수
                // 표현 할 수 있는 숫자 : 0 1 2 3 4 5 6 7 8 9 A B C D E F
                // ex) 0x00 0x01 0x02 ... 0x0F

                // 0b10001111 => 0b 1000 1111 = 0x8F = 143

            // 불리언[1byte](참/거짓)
            bool boolean;
            boolean = true;
            boolean = false;

            // 소수
                // float[4byte], double[8byte]
            float f = 3.14f;
            double d = 3.14;

            // 문자, 문자열
                // char[2byte], string
            char c = 'A';
            string str = "Hello, World!";

            Console.WriteLine(str);

            // 형변환
                // 크기가 다른 형변환
            int iNum = 0x0FFFFFFF;
            short sNum = (short)iNum;
            Console.WriteLine(iNum + "\t" + sNum);
                // 부호가 다른 형변환
            byte bNum = 255;
            sbyte mNum = (sbyte)bNum;
            Console.WriteLine(bNum + "\t" + mNum);
            // 0xFF = 0b11111111 = -1

                // 소수
            float fNum = 3.1414f;
            double dNum = fNum;
            Console.WriteLine(fNum + "\t" + dNum);
        }
    }
}
