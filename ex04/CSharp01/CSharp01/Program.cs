using System;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace CSharp
{
    // 객체[OOP](Object Oriented Programming)

    // Knight
    // 속성 : HP, Damege, Position
    // 기능 : Move, Attack, Die

    class Knight
    {

        public int hp;
        public int damege;
        public int position;

        // 생성자를 이용한 방식[Default]
        public Knight()
        {
            this.hp = 100;
            this.damege = 10;
            this.position = 1;
            Console.WriteLine("생성자 호출!");
        }

        // 생성자를 이용한 방식1[overloading]
        public Knight(int hp) : this() // this()를 붙이게 되면 Default 생성자를 먼저 호출
        {
            this.hp = hp;
            Console.WriteLine("Overloading 생성자 호출!");
        }

        // 생성자를 이용한 방식2[overloading]
        public Knight(int hp, int damege, int position)
        {
            this.hp = hp;
            this.damege = damege;
            this.position = position;
            Console.WriteLine("Overloading 생성자 호출!");
        }

        public Knight Clone()
        {
            Knight knight = new Knight {
                hp = this.hp,
                damege = this.damege,
                position = this.position
            };
            return (knight);
        }

        public void Move()
        {
            Console.WriteLine("Knight Move");
        }
        public void Attack()
        {
            Console.WriteLine("Knight Attack");
        }
    }

    struct Mage
    {
        public int hp;
        public int damege;
    }

    class Program
    {
        static void KillMage(Mage mage)
        {
            mage.hp = 0;
        }

        static void KillKnight(Knight knight)
        {
            knight.hp = 0;
        }

        static void Main(string[] args)
        {
            Mage mage;
            mage.hp = 100;
            mage.damege = 15;

            Mage mage2 = mage;
            mage2.hp = 0;

            Knight knight = new Knight
            {
                hp = 100,
                damege = 10,
                position = 1
            };

            // Deep Copy를 위한 방식 1
            Knight knight2 = new Knight
            {
                hp = knight.hp,
                damege = knight.damege,
                position = knight.position
            };

            // Deep Copy를 위한 방식 2
            Knight knight3 = knight.Clone();
            knight3.hp = 0;


            knight.Move();
            knight.Attack();
        }
    }
}