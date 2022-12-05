using System;
using System.Collections;
using System.Text;

namespace Algorithm
{
    public class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tile { get; private set; }
        public int Size { get; private set; }

        public int DestX { get; private set; }
        public int DestY { get; private set; }

        Player _player;

        public enum TileType
        {
            Empty,
            Wall
        }

        public void Initialize(int size, Player player)
        {
            Tile = new TileType[size, size];
            Size = size;

            DestX = size - 2;
            DestY = size - 2;

            _player = player;
            for (int y = 0; y < Size; ++y)
            {
                for (int x = 0; x < Size; ++x)
                {
                    if (x == 0 || x == Size - 1 || y == 0 || y == Size - 1)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }
            //GenerateByBinaryTree();
            GenerateBySideWinder();

        }
        public void GenerateByBinaryTree()
        {
            // 중간 공간 채우는 방식.
            for (int y = 0; y < Size; ++y)
            {
                for (int x = 0; x < Size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                }
            }

            // 길 뚫는 작업( Binary Tree Algorithm )
            Random rand = new Random();
            for (int y = 0; y < Size; ++y)
            {
                for (int x = 0; x < Size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    else if (x == Size - 2 && y == Size - 2)
                        continue;
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    else if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0)
                        Tile[y, x + 1] = TileType.Empty;
                    else
                        Tile[y + 1, x] = TileType.Empty;
                }
            }
        }
        public void GenerateBySideWinder()
        {
            // 중간 공간 채우는 방식.
            for (int y = 0; y < Size; ++y)
            {
                for (int x = 0; x < Size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                }
            }

            // 길 뚫는 작업( Binary Tree Algorithm )
            Random rand = new Random();
            for (int y = 0; y < Size; ++y)
            {
                int count = 1;
                for (int x = 0; x < Size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    else if (x == Size - 2 && y == Size - 2)
                        continue;
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    else if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        ++count;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }
        public void Render()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            for (int y = 0; y < Size; ++y)
            {
                for (int x = 0; x < Size; ++x)
                {
                    // 플레이어 좌표를 가져와 플레이어의 위치를 다른 색으로 변경
                    if (y == _player.PosY && x == _player.PosX)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (y == DestY && x == DestX)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = defaultColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}

