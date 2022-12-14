using System;
namespace Algorithm
{
    class Pos
    {
        public Pos(int y, int x) { Y = y; X = x; }
        public int Y { get; set; }
        public int X { get; set; }
    }
	public class Player
	{
		public int PosY { get; private set; }
        public int PosX { get; private set; }
        Random _random = new Random();
		Board _board;
        List<Pos> _point = new List<Pos>();

        enum Dir
        {
            Up = 0,
            Left = 1,
            Down = 2,
            Right = 3
        }
        int _dir = (int)Dir.Up;

		public void Initialize(int posY, int posX, Board board)
		{
			PosY = posY;
			PosX = posX;

			_board = board;

            // 현재 바라보고 있는 방향을 기준으로, 좌표 변화를 나타내준다.
            int[] frontY = new int[] { -1, 0, 1, 0 };
            int[] frontX = new int[] { 0, -1, 0, 1 };
            int[] rightY = new int[] { 0, -1, 0, 1 };
            int[] rightX = new int[] { 1, 0, -1, 0 };

            // 기본 위치 지정
            _point.Add(new Pos(PosY, PosX));

            // 목적지에 도달할 때까지 진행
            while (PosY != _board.DestY || PosX != _board.DestX)
            {
                // 현재 방향을 기준으로 오른쪽으로 갈 수 있는지 확인
                if (_board.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    // 오른쪽 방향으로 90도 회전
                    _dir = (_dir - 1 + 4) % 4;

                    // 전진
                    PosY += frontY[_dir];
                    PosX += frontX[_dir];

                    // 저장
                    _point.Add(new Pos(PosY, PosX));
                }
                // 현재 방향을 기준으로 갈 수 있는지 확인
                else if (_board.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] == Board.TileType.Empty)
                {
                    // 전진
                    PosY += frontY[_dir];
                    PosX += frontX[_dir];

                    // 저장
                    _point.Add(new Pos(PosY, PosX));
                }
                else
                {
                    // 왼쪽 방향으로 90도 회전
                    _dir = (_dir + 1 + 4) % 4;
                }
            }
		}

		const int MOVE_TICK = 100;
		int _sumTick = 0;
        int _lastIndex = 0;
		public void Update(int deltaTick)
		{
            if (_lastIndex >= _point.Count)
                return;
			_sumTick += deltaTick;
			if (_sumTick >= MOVE_TICK)
			{
				_sumTick = 0;

                // 실행될 로직
                PosY = _point[_lastIndex].Y;
                PosX = _point[_lastIndex].X;
                ++_lastIndex;

                #region 기본 움직임 로직
                //int randVal = _random.Next(0, 4);
                //switch (randVal)
                //            {
                //                case 0: // 상
                //		if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                //			--PosY;
                //                    break;
                //                case 1: // 하
                //                    if (PosY + 1 <= _board.DestY && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                //                        ++PosY;
                //                    break;
                //                case 2: // 좌
                //                    if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                //                        --PosX;
                //                    break;
                //                case 3: // 우
                //                    if (PosX + 1 <= _board.DestX && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                //                        ++PosX;
                //                    break;
                //            }
                #endregion
            }
        }
    }
}

