using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        static int Find()
        { return 0; }
        class Monster
        {
            public int Id { get; set; }
        }
        static void Main(string[] args)
        {
            // Nullable = Null + able

            int? number = null;
            number = 33;
            int a = number.Value; // 명시적으로 꺼내서 확인해야함.

            if (number != null)
            {
                int b = number.Value;
                Console.WriteLine(b);
            }
            if (number.HasValue)
            {
                int b = number.Value;
                Console.WriteLine(b);
            }
            // number가 NULL이면 지정값 0를 사용, 아니면 number.Value를 사용.
            int c = number ?? 0;
            Console.WriteLine(c);

            Monster monster = null;
            if (monster != null)
            {
                int monsterId = monster.Id;
            }
            int? id = monster?.Id;
        }
    }
}