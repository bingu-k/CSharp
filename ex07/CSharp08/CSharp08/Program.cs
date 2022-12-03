using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;

namespace CSharp
{
    class Program
    {
        // Reflection

        class Important : System.Attribute
        {
            string msg;
            public Important(string msg)
            {
                this.msg = msg;
            }
        }
        class Monster
        {
            // hp의 attribute
            [Important("Very Important")]
            public int hp;
            protected int attack;
            private float speed;

            void Attack() { attack = 0; }
        }
        public static void Main(string[] args)
        {
            Monster monster = new Monster();

            Type type = monster.GetType(); // Object에 이미 존재함.
            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                                        | System.Reflection.BindingFlags.NonPublic
                                        | System.Reflection.BindingFlags.Instance
                                        | System.Reflection.BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";
                var attribute = field.GetCustomAttributes();
                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}