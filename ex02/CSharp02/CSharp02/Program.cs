using System;

namespace CSharp
{
    class Program
    {
        enum Choic
        {
            Rock = 1, Paper = 2, Scissors = 0
        }

        static void Main(string[] arg)
        {
            // 0:가위 1:바위 2:보
            Random rand = new Random();
            int aiChoic = rand.Next(0, 3);  // 0~2사이의 랜덤값
            int yourChoic = Convert.ToInt32(Console.ReadLine());

            switch (yourChoic)
            {
                case (int)Choic.Scissors:
                    Console.WriteLine("당신은 가위 선택.");
                    break;
                case (int)Choic.Rock:
                    Console.WriteLine("당신은 바위 선택.");
                    break;
                case (int)Choic.Paper:
                    Console.WriteLine("당신은 보 선택.");
                    break;
                default:
                    Console.WriteLine("당신은 잘못된 입력입니다.");
                    break;
            }

            switch (aiChoic)
            {
                case (int)Choic.Scissors:
                    Console.WriteLine("나는 가위 선택.");
                    break;
                case (int)Choic.Rock:
                    Console.WriteLine("나는 바위 선택.");
                    break;
                case (int)Choic.Paper:
                    Console.WriteLine("나는 보 선택.");
                    break;
                default:
                    Console.WriteLine("나는 잘못된 입력입니다.");
                    break;
            }
            if (aiChoic == yourChoic)
                Console.WriteLine("무승부");
            else if (aiChoic == (int)Choic.Paper && yourChoic == (int)Choic.Scissors)
                Console.WriteLine("당신의 승리");
            else if (aiChoic == (int)Choic.Scissors && yourChoic == (int)Choic.Rock)
                Console.WriteLine("당신의 승리");
            else if (aiChoic == (int)Choic.Rock && yourChoic == (int)Choic.Paper)
                Console.WriteLine("당신의 승리");
            else
                Console.WriteLine("당신의 패배");
        }
    }
}