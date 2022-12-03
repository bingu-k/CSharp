using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        // Delegate(대리자)

        delegate int OnClicked();
        // delegate -> 형식은 형식인데, 함수 자체를 인자로 넘겨주는 그런 형식
        // 반환:int, 입력:void
        // OnClicked가 delegate형식의 이름.

        static void ButtonPressed(OnClicked clickedFunc)
        {
            clickedFunc();
        }

        static int TestDelegate()
        {
            Console.WriteLine("Hello Delegate");
            return 0;
        }
        static int TestDelegate2()
        {
            Console.WriteLine("Hello Delegate2");
            return 0;
        }

        static void Main(string[] args)
        {
            ButtonPressed(TestDelegate);
            OnClicked clicked = new OnClicked(TestDelegate);
            clicked += TestDelegate2;
            ButtonPressed(clicked);
        }
    }
}