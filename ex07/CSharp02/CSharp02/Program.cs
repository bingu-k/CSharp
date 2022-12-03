using System;
using System.Collections.Generic;

namespace CSharp
{
    class Program
    {
        //추상 클래스
        abstract class Monster
        {
            //반드시 override 해주어야 함.
            public abstract void Shout();
        }

        interface IFlyable
        {
            void Fly();
        }

        class Orc : Monster
        {
            public override void Shout() { Console.WriteLine("록타르 오가르!"); }
        }
        //다중 상속은 안되지만 인터페이스를 가져올수는 있다.
        class FlyableOrc : Monster, IFlyable
        {
            public override void Shout() { Console.WriteLine("록타르 오가르!"); }
            public void Fly() { Console.WriteLine("Fly!"); }
        }
        class Skeleton : Monster
        {
            public override void Shout() { Console.WriteLine("꾸엑!"); }
        }

        static void DoFly(IFlyable flyalbe)
        {
            flyalbe.Fly();
        }

        static void Main(string[] args)
        {
            FlyableOrc orc = new FlyableOrc();
            DoFly(orc);
        }
    }
}