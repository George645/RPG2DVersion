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
    private int constitution = 5;
    public int Constitution { get { return constitution; } }
    private int strength = 5;
    public int Strength { get { return strength; } }

    public Entity(string name, int health, int baseAttack /*There will be more once I have done the item class*/, int intelligence, int strength, int dexterity, int constitution)
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
