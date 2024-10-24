using UnityEngine;

public class Soldier : Entity
{
    int level, experience, dexterity, strength = 5, constitution = 5;
    //Ability ability
    //string dialogue option? so that the player can interact with them
    Soldier(int baseAttack, string name, int level = 0, int experience = 0, int dexterity = 5, int strength = 5, int constitution = 5) : base(name, constitution * 10, baseAttack, intelligence, strength, dexterity, constitution) {
        this.level = level;
        this.experience = experience;
        this.dexterity = dexterity;
        this.dexterity = dexterity;
        this.strength = strength;
        this.constitution = constitution;
    }
}
