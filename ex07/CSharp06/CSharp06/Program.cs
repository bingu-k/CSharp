using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp
{
    enum ItemType
    {
        Weapon,
        Armor,
        Amulet,
        Ring
    }
    enum Rarity
    {
        Normal,
        Uncommon,
        Rare
    }

    class Item
    {
        public ItemType itemType;
        public Rarity rarity;
    }

    class Program
    {
        static List<Item> _items = new List<Item>();

        // delegate를 이용한 방식
        delegate bool ItemSelector(Item item);
        //delegate Return MyFunc<T, Return>(T item);
        // delegate를 직접 선언하지 않아도, 이미 만들어져 존재한다.
        // -> 반환 타입이 있을 경우 Func
        // -> 반환 타입이 없으면 Action

        static bool IsWeapon(Item item)
        {
            return item.itemType == ItemType.Weapon;
        }
        static Item FindItem(ItemSelector selector)
        //static Item FindItem(Func<Item, bool> selector) -> Func 예시
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;
        }
        static void Main(string[] args)
        {
            _items.Add(new Item()
            {
                itemType = ItemType.Weapon,
                rarity = Rarity.Normal
            });
            _items.Add(new Item()
            {
                itemType = ItemType.Armor,
                rarity = Rarity.Uncommon
            });
            _items.Add(new Item()
            {
                itemType = ItemType.Ring,
                rarity = Rarity.Rare
            });

            Item item = FindItem(IsWeapon);
            
            // Anonymous Function : 무명 함수 / 익명함수
            Item itemAnonymous = FindItem(delegate (Item item) { return item.itemType == ItemType.Weapon; });

            // Lambda : 일회용 함수를 만드는데 사용하는 문법
            Item itemLambda = FindItem((Item item) => { return item.itemType == ItemType.Weapon; });

            // Lambda를 다회용으로 만드는 방식
            ItemSelector selector = new ItemSelector((Item item) => { return item.itemType == ItemType.Weapon; });
        }
    }
}