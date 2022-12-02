using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp01
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }
    class Game
    {
        private GameMode _mode = GameMode.Lobby;
        private Player _player = null;
        private Monster _monster = null;
        private Random _random = new Random();

        public void Process()
        {
            switch (_mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
                default:
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _player = new Knight();
                    _mode= GameMode.Town;
                    break;
                case "2":
                    _player = new Archer();
                    _mode = GameMode.Town;
                    break;
                case "3":
                    _player = new Mage();
                    _mode = GameMode.Town;
                    break;
                default:
                    break;

            }
        }
        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다.");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _mode = GameMode.Field;
                    break;
                case "2":
                    _mode = GameMode.Lobby;
                    break;
                default:
                    break;
            }
        }
        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다.");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정 확률로 마을 돌아가기");

            CreateRandomMonster();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;
                default:
                    break;
            }
        }

        private void CreateRandomMonster()
        {
            int randVal = _random.Next(0, 3);
            switch (randVal)
            {
                case 0:
                    _monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다.");
                    break;
                case 1:
                    _monster = new Orc();
                    Console.WriteLine("오크가 생성되었습니다.");
                    break;
                case 2:
                    _monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 생성되었습니다.");
                    break;
                default:
                    break;
            }
        }
        private void ProcessFight()
        {
            while (true)
            {
                _monster.OnDamaged(_player.GetAttack());
                if (_monster.IsDead())
                {
                    Console.WriteLine("플레이어가 이겼습니다.");
                    Console.WriteLine($"플레이어 HP : {_player.GetHp()}");
                    break;
                }

                _player.OnDamaged(_monster.GetAttack());
                if (_player.IsDead())
                {
                    Console.WriteLine("플레이어가 죽었습니다.");
                    _mode = GameMode.Lobby;
                    break;
                }
            }
        }
        private void TryEscape()
        {
            int randVal = _random.Next(0, 101);
            if (randVal < 33)
            {
                Console.WriteLine("플레이어가 도망쳤습니다.");
                _mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("플레이어가 도망에 실패하여 전투를 시작합니다.");
                ProcessFight();
            }
        }
    }
}