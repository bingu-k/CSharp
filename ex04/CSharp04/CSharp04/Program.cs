using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace CSharp
{
    // OOP(다형성)
    class Player
    {
        protected int hp;
        protected int damage;

        public virtual void Move()
        {
            Console.WriteLine("Player 이동!");
        }
    }

    class Knight : Player
    {
        // 부모가 갖고 있던 Move함수가 아니라 새로 만들겠다 "new"
        //public new void Move()
        public override void Move()
        {
            Console.WriteLine("Knight 이동!");
        }
    }

    class Mage : Player
    {
        public int mp;

        // 부모가 갖고 있던 가상 함수를 OverRiding 하겠다.
        // 2중 3중도 가능(sealed override 사용 후에 더이상 불가)
        public override void Move()
        {
            Console.WriteLine("Mage 이동!");
        }
    }

    class Program
    {
        static void EnterGame(Knight knight)
        {
            Console.WriteLine("Knight 입장");
        }
        // OverLoading의 방식(비효율적)
        static void EnterGame(Mage mage)
        {
            Console.WriteLine("Mage 입장");
        }

        static void EnterGame1(Player player)
        {
            Console.WriteLine("Player 입장");
            // player.Move();   (new)이때 새로 만들어준 함수가 실행이 안됨.
            player.Move();      //(OverRiding) 가상함수에 의해 런타임에 타입을 체크

            // player.mp = 0;   Mage가 아니면 불러오는게 가능하지 않기에 오류

            // 만약 player가 Knight?
            // 컴파일 단계에서 오류가 없다.
            // 실행 전까지는 아~무도 모름.
            // Mage mage = (Mage)player;
            // mage.mp = 10;

            // is 를 이용한 구분방식
            if (player is Mage)
            {
                Mage mage1 = (Mage)player;
                mage1.mp = 10;
            }

            // as 를 이용한 구분방식
            Mage mage2 = player as Mage;
            if (mage2 != null)
            {
                mage2.mp = 10;
            }

        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Mage mage = new Mage();

                
            Player magePlayer = mage;       // Mage -> Player 가능
            // Mage mage2 = magePlayer;     // Player -> Mage 불가능
            Mage mage2 = (Mage)magePlayer;  // 강제적인 방식

            // 자식에서 부모로 캐스팅은 가능
            // 부모에서 자식으로 캐스팅은 가능하지만, 확신이 없기에 나쁜 방식

            EnterGame(knight);
            EnterGame(mage);
            EnterGame1(knight);
            EnterGame1(mage);
        }
    }
}