using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp
{
    //Event 사용법(CallBack 방식)
    class Program
    {
        static void OnInputTest()
        {
            Console.WriteLine("Input Received!");
        }
        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            inputManager.inputKey += OnInputTest;
            while (true)
                inputManager.Update();
        }
    }
}