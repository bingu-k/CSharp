using System;

namespace CSharp
{
    // OOP(상속성)

    class Player    // 부모 클래스 혹은 기반 클래스
    {
        static public int counter = 1;
        public int id;
        public int hp;
        public int damage;

        public Player()
        {
            Console.WriteLine("Player 생성자 호출");
        }

        public Player(int hp)
        {
            this.hp = hp;
            Console.WriteLine("Player hp 생성자 호출");
        }
        public void Move() { Console.WriteLine("Player Move"); }
    }

    // 자식 클래스 혹은 파생클래스
    class Mage : Player
    {

    }
    class Archer : Player
    {

    }
    class Knight : Player
    {
        public Knight() : base(100) // 기본적인 수치 지정시 맞는 생성자로 접근
        {
            Console.WriteLine("Knight 생성자 호출");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            // Player 생성자가 먼저 호출되는 것을 볼 수 있음
            
            knight.Move();
            // 부모의 함수도 접근 가능
        }
    }

}