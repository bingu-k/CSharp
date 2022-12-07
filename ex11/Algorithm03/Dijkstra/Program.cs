using System;

namespace Dijikstra
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, 35, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 }
        };
        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;
            while (true)
            {
                // 가장 가중치가 적고 연결된 후보를 찾는다.
                int closest = Int32.MaxValue;
                int now = -1;
                for (int i = 0; i < 6; ++i)
                {
                    if (visited[i] || distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;
                    // 적합한 후보 저장
                    closest = distance[i];
                    now = i;
                }
                // 후보가 없음
                if (now == -1)
                    break;
                // 적합한 후보 방문
                visited[now] = true;
                // 방문한 정점과 인접한 정점들을 조사
                // 상황에 따라 발견한 최단거리를 갱신한다.
                for (int next = 0; next < 6; ++next)
                {
                    if (adj[now, next] == -1 || visited[next])
                        continue;
                    // 새로 조사된 정점의 최단거리를 계산
                    int nextDist = distance[now] + adj[now , next];
                    // 만약에 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크다면,
                    // 정보를 갱신한다.
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.Dijikstra(0);
        }
    }
}