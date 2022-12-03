using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        class TestException : Exception
        {}
        static void Main(string[] args)
        {
            try
            {
                // 1. 0으로 나눌 때
                //int a = 10;
                //int b = 0;
                //int c = a / b;

                // 2. 잘못된 메모리를 참조(ex. null)

                // 3. 오버플로우

                // 4. 사용자 설정
                throw new TestException();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("DivideByZeroException!");
            }
            catch (TestException e)
            {
                Console.WriteLine("TestException!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception!");
            }
            finally
            {
                // DB, File정리 등등
                Console.WriteLine("Final!");
            }
        }
    }
}