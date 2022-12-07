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

            //RightHand();
            //BFS();
            AStar();
        }
        void RightHand()
        {
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
        void BFS()
        {
            int[,] delta = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

            bool[,] found = new bool[_board.Size, _board.Size];
            Pos[,] parent = new Pos[_board.Size, _board.Size];


            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(PosY, PosX));
            found[PosY, PosX] = true;
            parent[PosY, PosX] = new Pos(PosY, PosX);
            while (q.Count > 0)
            {
                Pos pos = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int nextY = pos.Y + delta[i, 0];
                    int nextX = pos.X + delta[i, 1];

                    if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                        continue;
                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall || found[nextY, nextX])
                        continue;
                    q.Enqueue(new Pos(nextY, nextX));
                    found[nextY, nextX] = true;
                    parent[nextY, nextX] = new Pos(pos.Y, pos.X);
                }
            }
            CalPathFromParent(parent);
        }   // 가중치가 없을때 사용하는 방식.
        void CalPathFromParent(Pos[,] parent)
        {
            int y = _board.DestY;
            int x = _board.DestX;
            while (parent[y, x].Y != y || parent[y, x].X != x)
            {
                _point.Add(new Pos(y, x));
                Pos pos = parent[y, x];
                y = pos.Y;
                x = pos.X;
            }
            _point.Add(new Pos(y, x));
            _point.Reverse();
        }

        struct PQNode : IComparable<PQNode>
        {
            public int F;
            public int G;
            public int Y;
            public int X;

            public int CompareTo(PQNode other)
            {
                if (F == other.F)
                    return 0;
                return F < other.F ? 1 : -1;
            }
        }
        void AStar()
        {
            // 상하좌우 delta값
            int[,] delta = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };
            // 비용
            int[] cost = new int[] { 1, 1, 1, 1 };

            //    // 대각 이동 추가[U L D R UL DL DR UR]
            //// 상하좌우 delta값
            //int[,] delta = new int[8, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, -1 }, { 1, -1 }, { 1, 1 }, { -1, 1 } };
            //// 비용
            //int[] cost = new int[] { 10, 10, 10, 10, 14, 14, 14, 14 };

            // 점수 매기기
            // F = G + H
            // F : 최종 점수(작을수록 좋음)
            // G : 시작점에서 해당 좌표까지 이동하는데 드는 비용(작을수록 좋은, 경로에 따라 다름)
            // H : 목적지에서 얼마나 가까운지 (작을수록 좋음, 고정)

            // (y, x) 방문 여부 확인
            bool[,] closed = new bool[_board.Size, _board.Size];

            // (y, x) 가는 길을 한 번이라도 발견했는지?
                // 발견X => MaxValue;
                // 발견O => F = G + H
            int[,] open = new int[_board.Size, _board.Size];
            for (int y = 0; y < _board.Size; ++y)
                for (int x = 0; x < _board.Size; ++x)
                    open[y, x] = Int32.MaxValue;

            // 경로확인을 위한 부모 노드
            Pos[,] parent = new Pos[_board.Size, _board.Size];

            // Open에 있는 정보들 중, 가장 좋은 후보를 빠르게 뽑아오기 위한 도구
            PriorityQueue<PQNode>   pq = new PriorityQueue<PQNode>();

            // 시작점 발견 (예약 진행)
            open[PosY, PosX] = Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX);
            pq.Push(new PQNode
            {
                F = Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX),
                G = 0,
                Y = PosY,
                X = PosX
            });
            //open[PosY, PosX] = Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX) * 10; // 대각 이동시 10 곱해줌
            //pq.Push(new PQNode
            //{
            //    F = Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX) * 10,
            //    G = 0,
            //    Y = PosY,
            //    X = PosX
            //});
            parent[PosY, PosX] = new Pos(PosY, PosX);

            while (pq.Count() > 0)
            {
                // 빠르게 가장 좋은 후보 뽑기
                PQNode node = pq.Pop();
                
                // 동일한 좌표를 여러 경로로 찾아서, 더 빠른 경로로 인해서 이미 방문된 경우 스킵
                if (closed[node.Y, node.X])
                    continue;

                // 방문
                closed[node.Y, node.X] = true;

                // 목적지 도착여부 확인
                if (node.Y == _board.DestY && node.X == _board.DestX)
                    break;

                // 상하 좌우 등 이동할 수 있는 좌표인지 확인해서 예약함
                for (int i = 0; i < delta.Length / 2; ++i)
                {
                    int nextY = node.Y + delta[i, 0];
                    int nextX = node.X + delta[i, 1];

                    // 유효 범위 확인, 갈 수 있는지 확인, 방문했는지 확인
                    if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size)
                        continue;
                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall || closed[nextY, nextX])
                        continue;

                    // 비용 계산
                    int g = node.G + cost[i];
                    int h = Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestX - nextX);
                    //int h = Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestX - nextX) * 10; // 대각 이동시 10 곱해줌

                    // 다른 경로에서 더 빠른 길 이미 찾았으면 스킵
                    if (open[nextY, nextX] < g + h)
                        continue;

                    // 예약
                    open[nextY, nextX] = g + h;
                    pq.Push(new PQNode()
                    {
                        F = g + h,
                        G = g,
                        Y = nextY,
                        X = nextX
                    });
                    parent[nextY, nextX] = new Pos(node.Y, node.X);
                }
            }
            // 부모 노드를 따라 실행 순서 지정
            CalPathFromParent(parent);
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        int _lastIndex = 0;
        public void Update(int deltaTick)
        {
            if (_lastIndex >= _point.Count)
            {
                _lastIndex = 0;
                _point.Clear();
                _board.Initialize(_board.Size, this);
                Initialize(1, 1, _board);
            }
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

