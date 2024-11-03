using System;
using UnityEngine;

public class Soldier : Entity
{
    int level, experience;
    public int orderInLine = 0;
    public Player player;
    //Ability ability
    //string dialogue option? so that the player can interact with them
    Soldier(int baseAttack, string name, int level = 0, int experience = 0, int dexterity = 5, int strength = 5, int constitution = 5) : base(name, constitution * 10, baseAttack, strength, dexterity, constitution) {
        this.level = level;
        this.experience = experience;
    }
    private void Start()
    {
        player.AddSoldier(this);
        orderInLine = player.numberOfSoldiers;
    }
}
