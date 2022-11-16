using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] arg)
        {
            //---------------- 조건문 ------------------
            //int hp = 100;
            //bool isDead = (hp <= 0);

            //if (isDead)
            //    Console.WriteLine("You are dead.");
            //else
            //    Console.WriteLine("You still alive.");

            //int choic = 0; //0:가위 1:바위 2:보
            //if (choic == 0)
            //    Console.WriteLine("가위입니다.");
            //else if (choic == 1)
            //    Console.WriteLine("바위입니다.");
            //else if (choic == 2)
            //    Console.WriteLine("보입니다.");
            //else
            //    Console.WriteLine("치트키입니다.");

            //---------------- Switch ----------------
            int choic = 0;

            switch (choic)
            {
                case 0:
                    Console.WriteLine("가위입니다.");
                    break;
                case 1:
                    Console.WriteLine("바위입니다.");
                    break;
                case 2:
                    Console.WriteLine("보입니다.");
                    break;
                default:
                    Console.WriteLine("치트키입니다.");
                    break;
            }

            //---------------- 삼항연산자 ---------------
            int num = 25;
            bool isPair = ((num % 2) == 0 ? true : false);
            Console.WriteLine(isPair);
        }
    }
}