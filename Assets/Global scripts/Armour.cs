using UnityEngine;
using static Item;

public class Armour : Item{
    public enum Equipable
    {
        hand, chest, helmet, leggings, boots
    }
    public Armour(string name, string description, int price, int weight, Equipable equipable, int? requiredStrength = null, int? requiredDexterity = null, int? requiredIntelligence = null) : base(name, description, price, weight) { 
    }
}