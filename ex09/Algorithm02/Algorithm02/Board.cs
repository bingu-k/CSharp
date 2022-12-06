using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    // 연결 리스트 구현
    class Room<T>
    {
        public T _data;
        public Room<T> _Next;
        public Room<T> _Prev;
    }
    class RoomList<T>
    {
        public Room<T> _Head = null;
        public Room<T> _Tail = null;
        public int _Count = 0;

        // O(1)
        public Room<T> AddLast(T data)
        {
            Room<T> newRoom = new Room<T>();
            newRoom._data = data;

            // 첫 방 추가
            if (_Head == null)
                _Head = newRoom;
            // 새로운 방을 기존 마지막 방과 엮어줌
            if (_Tail != null)
            {
                _Tail._Next = newRoom;
                newRoom._Prev = _Tail;
            }
            // 마지막 방 최신화
            _Tail = newRoom;
            ++_Count;
            return newRoom;
        }

        // O(1)
        public void Remove(Room<T> room)
        {
            if (_Head == room)
                _Head = _Head._Next;
            if (_Tail == room)
                _Tail = _Tail._Prev;
            if (room._Prev != null)
                room._Prev._Next = room._Next;
            if (room._Next != null)
                room._Next._Prev = room._Prev;
        }
    }
    class Board
    {
        // 선형 구조 : 순차적으로 나열한 형태.
        public int[] _dataArr = new int[25];
        // 배열
            // 메모리 구조상 정해진 크기의 메모리를 연속적으로 나열되어 있다.
            // 메모리 크기의 확장, 축소 불가
        public List<int> _dataList = new List<int>();
        // 동적 배열
            // 정해진 크기가 없기에 확장, 축소가 자유롭다.
            // 기존의 범위를 넘어갔을 때, 복사 비용 발생(추가 할당 필요)
        //public LinkedList<int> _dataLinkedList = new LinkedList<int>();
        public RoomList<int> _dataLinkedList = new RoomList<int>();
        // 연결 리스트
            // 연속되지 않은 메모리를 사용한다.
            // Random Access 불가능.
            // 중간 삽입, 삭제 불편

        public void Initialize()
        {
            _dataLinkedList.AddLast(101);
            _dataLinkedList.AddLast(102);
            //LinkedListNode<int> node = _dataLinkedList.AddLast(103);
            Room<int> node = _dataLinkedList.AddLast(103);
            _dataLinkedList.AddLast(104);
            _dataLinkedList.AddLast(105);

            _dataLinkedList.Remove(node);
        }
    }
}