using System;
using System.Collections.Generic;

namespace Algorithm
{
    class Program
    {
        // 스택   : LIFO(Last in First out)
        // [1][2][3][4] <- IN -> OUT
        // 큐    : FIFO(First in First out)
        // OUT <- [1][2][3][4] <- IN

        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(101);
            stack.Push(102);
            stack.Push(103);
            stack.Push(104);
            stack.Push(105);
            stack.Push(106);
            // [101][102][103][104][105][106]
            int data1 = stack.Pop();    // [106] 뽑기
            int data2 = stack.Peek();   // [105] 보기

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(101);
            queue.Enqueue(102);
            queue.Enqueue(103);
            queue.Enqueue(104);
            queue.Enqueue(105);
            queue.Enqueue(106);
            // [101][102][103][104][105][106]
            int data3 = queue.Dequeue();// [101] 뽑기
            int data4 = queue.Peek();   // [102] 보기

            // 같은 행동을 하지만 Node를 생성하는 과정이 있기에 굳이 사용하진 않는다.
            LinkedList<int> Llist = new LinkedList<int>();
            Llist.AddLast(101);
            Llist.AddLast(102);
            Llist.AddLast(103);

            int val1 = Llist.First.Value;
            Llist.RemoveFirst();
            int val2 = Llist.Last.Value;
            Llist.RemoveLast();
        }
    }
}