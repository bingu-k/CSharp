using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp01
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }
    class Monster : Creature
    {
        protected MonsterType _type;

        protected Monster(MonsterType type) : base(CreatureType.Monster)
        {
            _type = type;
        }
        
        public MonsterType GetMonsterType() { return _type; }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            SetInfo(30, 10);
        }
    }
    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            SetInfo(40, 15);
        }
    }
    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton)
        {
            SetInfo(35, 20);
        }
    }
}
