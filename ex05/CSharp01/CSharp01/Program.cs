using System;

namespace CSharp01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player player1 = new Knight();
            //Player player2 = new Archer();
            //Monster monster = new Orc();

            //monster.OnDamaged(player1.GetAttack());
            //player1.OnDamaged(player2.GetAttack());

            Game game = new Game();

            while (true)
            {
                game.Process();

            }
        }
    }
}