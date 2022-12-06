using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    // 동적 배열 구현
    class MyList<T>
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        // 실제 사용중인 데이터의 수
        public int _Count = 0;
        // 사용가능한 데이터의 수
        public int _Capacity { get { return _data.Length; } }

        // O(1)
        public void Add(T item)
        {
            // 데이터 공간 확인.
            if (_Count >= _Capacity)
            {
                // 데이터 공간 확보
                T[] newData = new T[_Count * 2];
                for (int i = 0; i < _Count; ++i)
                    newData[i] = _data[i];
                _data = newData;
            }
            // 데이터 추가
            _data[_Count++] = item;
        }

        // O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            if (_Count <= index)
                return;
            for (int i = index; i < _Count - 1; ++i)
                _data[i] = _data[i + 1];
            _data[--_Count] = default(T);
        }
    }
    class Board
    {
        // 선형 구조 : 순차적으로 나열한 형태.
        public int[] _dataArr = new int[25];
        // 배열
            // 메모리 구조상 정해진 크기의 메모리를 연속적으로 나열되어 있다.
            // 메모리 크기의 확장, 축소 불가
        //public List<int> _dataList = new List<int>();
        public MyList<int> _dataList = new MyList<int>();
        // 동적 배열
            // 정해진 크기가 없기에 확장, 축소가 자유롭다.
            // 기존의 범위를 넘어갔을 때, 복사 비용 발생(추가 할당 필요)
        public LinkedList<int> _dataLinkedList = new LinkedList<int>();
        // 연결 리스트
            // 연속되지 않은 메모리를 사용한다.
            // Random Access 불가능.
            // 중간 삽입, 삭제 불편

        public void Initialize()
        {
            _dataList.Add(101);
            _dataList.Add(102);
            _dataList.Add(103);
            _dataList.Add(104);
            _dataList.Add(105);

            int tmp = _dataList[2];

            _dataList.RemoveAt(2);
        }
    }
}