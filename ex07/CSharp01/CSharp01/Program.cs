using System;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        class MyList<T> where T : new()     //Default 생성자가 있어야 한다.
        //class MyList<T> where T : Monster Monster를 상속받은 것만 받는다.
        //class MyList<T> where T : struct  값형식만 받겠다.
        //class MyList<T> where T : class   참조형식만 받겠다.
        {
            T[] arr = new T[10];
            public T GetItem(int index)
            {
                return arr[index];
            }
        }
        class Monster
        {}
        static void Test<T>(T input)
        {}
        static void Main(string[] args)
        {
            // 값을 가져오고 넣을때의 자원 소모가 크다.
            object obj1 = 3;
            object obj2 = "hello world";
            // 미리 지정되어있는 방식.
            var v1 = 3;
            var v2 = "hello world";

            int num = (int)obj1;
            int numV = v1;
            string str = (string)obj2;
            string strV = v2;

            MyList<int> listInt = new MyList<int>();
            MyList<float> listFloat = new MyList<float>();
            MyList<Monster> listMonster = new MyList<Monster>();

            Test<int>(3);
            Test<float>(3.3f);
        }
    }
}