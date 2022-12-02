using System;

namespace CSharp
{
    class Program
    {
        static int GetHighestScore(int[] scores)
        {
            int highestScore = 0;
            foreach (int score in scores)
            {
                if (score > highestScore)
                    highestScore = score;
            }
            return highestScore;
        }
        static int GetAverageScore(int[] scores)
        {
            int averageScore = 0;
            foreach (int score in scores)
                averageScore += score;
            return scores.Length == 0 ? 0 : (averageScore / scores.Length);
        }
        static int GetIndexof(int[] scores, int value)
        {
            for (int i = 0; i < scores.Length; ++i)
            {
                if (value == scores[i])
                    return i;
            }
            return -1;
        }
        static void Sort(int[] scores)
        {
            for (int i = 0; i < scores.Length - 1; ++i)
            {
                for (int j = i + 1; j < scores.Length; ++j)
                {
                    if (scores[i] > scores[j])
                    {
                        int tmp = scores[i];
                        scores[i] = scores[j];
                        scores[j] = tmp;
                    }
                }
            }
        }

        class Map
        {
            int[,] tiles =
            {
                { 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1 }
            };
            public void Render()
            {
                var DefaultColor = Console.ForegroundColor;
                for (int y = 0; y < tiles.GetLength(1); ++y)
                {
                    for (int x = 0; x < tiles.GetLength(0); ++x)
                    {
                        if (tiles[x, y] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('\u25cf');
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = DefaultColor;
            }
        }
        static void Main(string[] args)
        {
            //int[] scores = new int[5];
            ////int[] scores = new int[] { 10, 20, 30, 40, 50 };
            ////int[] scores = { 10, 20, 30, 40, 50 };
            //scores[0] = 10;
            //scores[1] = 20;
            //scores[2] = 30;
            //scores[3] = 40;
            //scores[4] = 50;

            //for (int i = 0; i < scores.Length; i++)
            //{
            //    Console.WriteLine(scores[i]);
            //}
            //foreach(int score in scores)
            //{
            //    Console.WriteLine(score);
            //}

            //int[] scores = { 10, 30, 40, 20, 50 };
            //Console.WriteLine(GetHighestScore(scores));
            //Console.WriteLine(GetAverageScore(scores));
            //Console.WriteLine(GetIndexof(scores, 20));
            //Console.WriteLine(GetIndexof(scores, 15));
            //Sort(scores);
            //foreach (int score in scores)
            //    Console.WriteLine(score);

            //int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            Map map = new Map();
            map.Render();
        }
    }
}