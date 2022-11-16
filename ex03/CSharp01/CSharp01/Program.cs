using System;

namespace CSharp
{
    enum ClassType
    {
        NONE = 0, NIGHT = 1, ARCHER = 2, MAGE = 3
    }
    struct Player
    {
        public ClassType type;
        public int hp;
        public int attack;
    }

    enum MonsterType
    {
        NONE = 0, SLIME = 1, ORC = 2, SKELETON = 3
    }
    struct Monster
    {
        public MonsterType type;
        public int hp;
        public int attack;
    }
    class Program
    {
        static void ChoiceClass(ref ClassType job)
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("(1) : 기사");
            Console.WriteLine("(2) : 궁수");
            Console.WriteLine("(3) : 법사");

            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.Key)
            {
                case ConsoleKey.D1:
                    job = ClassType.NIGHT;
                    Console.WriteLine("전사를 선택하셨습니다.");
                    break;
                case ConsoleKey.D2:
                    job = ClassType.ARCHER;
                    Console.WriteLine("궁수를 선택하셨습니다.");
                    break;
                case ConsoleKey.D3:
                    job = ClassType.MAGE;
                    Console.WriteLine("법사를 선택하셨습니다.");
                    break;
                default:
                    Console.WriteLine("올바른 값을 입력해주세요.");
                    break;
            }
        }
        static void CreatePlayer(out Player player)
        {
            player.type = ClassType.NONE;
            while (player.type == ClassType.NONE)
                ChoiceClass(ref player.type);
            switch (player.type)
            {
                case ClassType.NIGHT:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.ARCHER:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.MAGE:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }
        static void CreateMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);
            switch (randMonster)
            {
                case (int)MonsterType.ORC:
                    Console.WriteLine("ORC이 스폰되었습니다.");
                    monster.type = MonsterType.ORC;
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.SKELETON:
                    Console.WriteLine("SKELETON이 스폰되었습니다.");
                    monster.type = MonsterType.SKELETON;
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.SLIME:
                    Console.WriteLine("SLIME이 스폰되었습니다.");
                    monster.type = MonsterType.SLIME;
                    monster.hp = 30;
                    monster.attack = 3;
                    break;
                default:
                    monster.type = MonsterType.NONE;
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }
        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"Player Status\nHP : {player.hp}");
                    break;
                }
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다.");
                    break;
                }
            }
        }
        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 접속했습니다.");

            while (player.hp >= 0)
            {
                Monster monster;
                CreateMonster(out monster);

                Console.WriteLine("(1) 전투 모드로 돌입");
                Console.WriteLine("(2) 일정 확률로 마을로 도망");

                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.D1)
                {
                    Fight(ref player, ref monster);

                }
                else if (info.Key == ConsoleKey.D2)
                {
                    Random rand = new Random();
                    int randVal = rand.Next(0, 101);
                    if (randVal <= 33)
                    {
                        Console.WriteLine("몬스터에게서 도망쳤습니다.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("몬스터에게서 도망치는 것을 실패했습니다.");
                        Fight(ref player, ref monster);
                        break;
                    }
                }
            }
            Console.WriteLine("사망하셨습니다.");
        }
        static void EnterGame(ref Player player)
        {
            Console.WriteLine("게임에 접속했습니다.");
            while (true)
            {
                Console.WriteLine("[1] 필드로 간다.");
                Console.WriteLine("[2] 로비로 돌아간다.");

                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                    EnterField(ref player);
                else if (input.Key == ConsoleKey.D2)
                    break;
            }
        }
        static void Main(string[] arg)
        {
            while (true)
            {
                Player player;
                CreatePlayer(out player);
                Console.WriteLine($"HP : {player.hp}, ATTACK : {player.attack}");

                EnterGame(ref player);
                Console.WriteLine("다시 시작하시겠습니까?");
                Console.WriteLine("(1) 다시 시작");
                Console.WriteLine("(2) 게임 종료");
                if (Console.ReadKey().Key == ConsoleKey.D2)
                    break;
            }
            Console.WriteLine("잘가요~");
        }
    }
}