using UnityEngine;
using System.Collections.Generic;

public class Player : Entity
{
    PlayerInventory playerInventory;
    int intelligence = 5, strength = 5, dexterity = 5, constitution = 5, level = 0, experience = 0;
    public List<Soldier> soldiers = new List<Soldier>();
    //Ability ability1, ability2
    public Player(string name, int health, int baseAttack, int intelligence, int strength, int dexterity, int constitution) : base(name, health, baseAttack){
        base.health = constitution * 10;
    }
}
