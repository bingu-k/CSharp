using System;
using System.Collections;
using System.Text;

namespace Algorithm
{
    public class Board
    {
        public TileType[,] _tile;
        public int _size;
        const char CIRCLE = '\u25cf';

        public enum TileType
        {
            Empty,
            Wall
        }

        public void Initialize(int size)
        {
            _tile = new TileType[size, size];
            _size = size;

            for (int y = 0; y < _size; ++y)
            {
                for (int x = 0; x < _size; ++x)
                {
                    if (x == 0 || x == _size - 1 || y == 0 || y == _size - 1)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }
            //GenerateByBinaryTree();
            GenerateBySideWinder();
        }
        public void GenerateByBinaryTree()
        {
            // 중간 공간 채우는 방식.
            for (int y = 0; y < _size; ++y)
            {
                for (int x = 0; x < _size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                }
            }

            // 길 뚫는 작업( Binary Tree Algorithm )
            Random rand = new Random();
            for (int y = 0; y < _size; ++y)
            {
                for (int x = 0; x < _size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    else if (x == _size - 2 && y == _size - 2)
                        continue;
                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    else if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0)
                        _tile[y, x + 1] = TileType.Empty;
                    else
                        _tile[y + 1, x] = TileType.Empty;
                }
            }
        }
        public void GenerateBySideWinder()
        {
            // 중간 공간 채우는 방식.
            for (int y = 0; y < _size; ++y)
            {
                for (int x = 0; x < _size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                }
            }

            // 길 뚫는 작업( Binary Tree Algorithm )
            Random rand = new Random();
            for (int y = 0; y < _size; ++y)
            {
                int count = 1;
                for (int x = 0; x < _size; ++x)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    else if (x == _size - 2 && y == _size - 2)
                        continue;
                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }
                    else if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        ++count;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        _tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }
        public void Render()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            for (int y = 0; y < _size; ++y)
            {
                for (int x = 0; x < _size; ++x)
                {
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
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

