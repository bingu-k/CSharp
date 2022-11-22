using System;

namespace CSharp
{
    // OOP(은닉성)

    class Knight
    {
        // public, protected, private, ...
        // 해당 public은 모두에게 보여주는 것
        public int hp;

        // 설계시 사용자가 사용하지 못하게 할 수 있어야하는 부분
        private void SecretFunction()
        {
            Console.WriteLine("비밀~");
        }

        private int damage;

        public void SetDamage(int damage)
        { this.damage = damage; }

        // 본인과 자식 프로세스에게만 사용 권한 부여
        protected int position;

        // 기본 한정자는 private
        int think;
    }

    class SuperKngiht : Knight
    {
        void Test()
        {
            hp = 0;
            // damage = 0;
            position = 0;
            // think = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.hp = 100;

            // knight.SecretFunction(); 접근 불가

            knight.SetDamage(10);
            // knight.damage = 10; 접근 불가

        }
    }
}