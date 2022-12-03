using System;
using System.Collections.Generic;

namespace CSharp
{
    //객체지향 -> 은닉성
    class Knight
    {
        protected int _hp = 100;
        public int GetHp() { return _hp; }
        public void SetHp(int hp) { this._hp = hp; }
        //public int Hp
        //{
        //    get { return hp; }
        //    private set { hp = value; } // 외부에서 사용금지
        //}
        // 결국엔 한정자를 따라가고 각자 한정할 수 있다.
        public int Hp { get; set; } = 100;


    }
    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.Hp = 100;
            int hp = knight.Hp;
        }
    }
}