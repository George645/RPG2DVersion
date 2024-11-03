using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private protected int health, baseAttack;
    public new string name;
    int intelligence = 5;
    public int Intelligence { get; }
    private int dexterity = 5;
    public int Dexterity { get; }
    public int constitution = 5;
    public int strength = 5;

    public Entity(string name, int health, int baseAttack /*There will be more once I have done the item class*/, int strength, int dexterity, int constitution, int intelligence = 10)
    {
        this.intelligence = intelligence;
        this.strength = strength;
        this.dexterity = dexterity;
        this.constitution = constitution;
        this.name = name;
        this.health = health;
        this.baseAttack = baseAttack;
    }
}
