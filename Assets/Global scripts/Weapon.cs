using NUnit.Framework.Constraints;
using UnityEngine;
using static Item;

public class Weapon : Item{
    public enum oneOrTwo
    {
        oneHanded, twoHanded
    }
    oneOrTwo equipable;
    public Weapon(string name, string description, int price, int weight, oneOrTwo equipable, int? requiredStrength = null, int? requiredDexterity = null, int? requiredIntelligence = null) : base(name, description, price, weight){

    }
}
