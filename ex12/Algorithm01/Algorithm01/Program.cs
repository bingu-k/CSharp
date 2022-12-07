using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Algorithm
{
    // TREE
    // 나무뿌리 혹은 나무를 뒤집어 놓은것 같은 느낌
    // 순환 구조가 있으면 안된다.
    // 자식(Child) 노드는 단 하나의 부모(Parent) 노드를 갖는다.
    // 형제(Sibling) 노드같은 부모(Parent) 노드를 갖는다.
    // root 노드는 최상위 노드를 뜻한다.
    // leaf 노드는 자식(Child) 노드가 없는 노드를 뜻한다.
    
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }
    class PriorityQueue<T> where T : IComparable<T> // T에 대한 인터페이스를 가져옴
    {
        List<T> _heap = new List<T>();

        // O(log_2(N)) -> heap의 높이에 관련있다.
        public void Push(T data)
        {
            // heap의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            // 도장깨기
            int now = _heap.Count - 1;
            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                // 교체
                T tmp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = tmp;

                // 이동
                now = next;
            }
        }
        // O(log_2(N)) -> heap의 높이에 관련있다.
        public T Pop()
        {
            // return data 저장
            T ret = _heap[0];

            // 마지막 데이터를 root 노드로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            --lastIndex;

            // 도장깨기
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;
                int next = now;
                // 좌우 데이터 확인후 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;
                // 좌우 데이터가 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 교체
                T tmp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = tmp;

                // 이동
                now = next;
            }
            return ret;
        }
        public int Count()
        { return _heap.Count(); }
    }

    class Knight : IComparable<Knight>  // 인터페이스를 가져온다.
    {
        public int Id { get; set; }

        // 인터페이스에서 가져온 Function을 다시 작성
        public int CompareTo(Knight other)
        {
            if (Id == other.Id)
                return 0;
            // 등호의 방향따라 오름차순, 내림차순을 결정할 수 있음.
            return Id > other.Id ? 1 : -1;
        }
    }

    class Program
    {
        // Tree
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인 팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍 팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라이언트" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트 팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }
            }
            return (root);
        }
        static void PrintTree(TreeNode<string> node)
        {
            Console.WriteLine(node.Data);
            foreach (TreeNode<string> child in node.Children)
                PrintTree(child);
        }
        static int GetTreeHeight(TreeNode<string> node)
        {
            int height = 0;
            foreach (TreeNode<string> child in node.Children)
            {
                height = Math.Max(height, GetTreeHeight(child) + 1);
                //int newHeight = GetHeight(child) + 1;
                //if (newHeight > height ) height = newHeight;
            }
            return height;
        }

        // PriorityQueue
        static void Main(string[] args)
        {
            // Tree
            TreeNode<string> root = MakeTree();
            PrintTree(root);
            Console.WriteLine(GetTreeHeight(root));

            // PriorityQueue
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight() { Id = 20 });
            q.Push(new Knight() { Id = 30 });
            q.Push(new Knight() { Id = 40 });
            q.Push(new Knight() { Id = 10 });
            q.Push(new Knight() { Id = 100 });

            Console.WriteLine();
            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop().Id);
            }
        }
    }
}