using UnityEngine;
using static Item;

public class Armour : Item{
    public enum Equipable
    {
        hand, chest, helmet, leggings, boots
    }
    public Armour(string name, string description, int price, int weight, Rarity rarity, Equipable equipable) : base(name, description, price, weight, rarity){

    }
}
