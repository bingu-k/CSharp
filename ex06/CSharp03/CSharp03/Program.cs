using System;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        class Monster
        {
            public Monster(int id) { this.id = id; }
            public int id;
        }
        static void Main(string[] args)
        {
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

            //dic.Add(1, new Monster(1));
            //dic[5] = new Monster(5);
            for (int i = 0; i < 10000; ++i)
                dic.Add(i, new Monster(i));

            Monster mon;
            bool found = dic.TryGetValue(20000, out mon); //false

            dic.Remove(777);
            dic.Clear();
        }
    }
}