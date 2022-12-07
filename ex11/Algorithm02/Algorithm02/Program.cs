using System;
using static System.Net.Mime.MediaTypeNames;

namespace Algorithm
{
    // 그래프
        // Vertex[정점] : 데이터를 표현
        // Adjacent[간선] : 정점들을 연결
    class Graph
    {
        // 메모리 소모가 크지만, 접근이 용이함
        int[,] adjacent1 = new int[6, 6]
        {
            {0, 1, 0, 1, 0, 0 },
            {1, 0, 1, 1, 0, 0 },
            {0, 1, 0, 0, 0, 0 },
            {1, 1, 0, 0, 1, 0 },
            {0, 0, 0, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0 },
        };
        // 메모리 소모가 적지만, 접근시 훑어야한다.
        List<int>[] adjacent2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3, 5 },
            new List<int>() { 4 }
        };

        bool[] visited = new bool[6];
        public void DFS1(int now)
        {
            // now부터 방문
            // 연결된 정점들을 하나씩 확인해서 방문
            Console.WriteLine(now);
            visited[now] = true;

            for (int next = 0; next < 6; ++next)
            {
                // 연결되어있지 않거나, 방문했었다면 SKIP
                if (adjacent1[now, next] == 0 || visited[next])
                    continue;
                DFS1(next);
            }
        }
        public void DFS2(int now)
        {
            // now부터 방문
            // 연결된 정점들을 하나씩 확인해서 방문
            Console.WriteLine(now);
            visited[now] = true;

            foreach (int next in adjacent2[now])
            {
                // 방문했었다면 SKIP
                if (visited[next])
                    continue;
                DFS2(next);
            }
        }

        public void BFS1(int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count != 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);
                for (int next = 0; next < 6; ++next)
                {
                    if (adjacent1[now, next] == 0 || visited[next])
                        continue;
                    queue.Enqueue(next);
                    visited[next] = true;
                }
            }
        }
        public void BFS2(int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count != 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);
                foreach (int next in adjacent2[now])
                {
                    if (visited[next])
                        continue;
                    queue.Enqueue(next);
                    visited[next] = true;
                }
            }
        }

        // 모든 정점이 연결되어있지 않을때, 모든 정점들을 확인하는 작업.
        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; ++now)
            {
                if (visited[now] == false)
                    DFS1(now);
            }
        }
    }
    class Program
    {
        // 그래프를 추출하는 방식
            // DFS(Depth First Search)[깊이 우선 탐색]
            // BFS(Breadth First Search)[너비 우선 탐색]
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            //graph.SearchAll();    DFS 접근
            graph.BFS2(3);
        }
    }
}