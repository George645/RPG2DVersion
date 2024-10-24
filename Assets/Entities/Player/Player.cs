using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Player : Entity {
    PlayerInventory playerInventory;
    public List<Soldier> soldiers = new List<Soldier>();
    private int level = 0;
    public int Level { get { return level; } }
    private int experience = 0;
    public int Experience { set { experience = value; } }
    //Ability ability1, ability2
    public Player(string name, int intelligence, int strength, int dexterity, int constitution) : base(name, constitution * 10, strength/2, intelligence, strength, dexterity, constitution)
    {
        health = constitution * 10;
    }
    public void AddSoldier(Soldier soldier){
        soldiers.Add(soldier);
    }
    public void RemoveSoldier(Soldier soldier){
        try{
            soldiers.Remove(soldier);
            Destroy(soldier);
        }
        catch{
            Debug.Log(message: "there was no soldier with id " + soldier.name);
        }
    }
    public void LevelUp()
    {
        Debug.Log(message: "This is not yet implemented, needs to run into the other attributes");
    }
    private void AddStrength(int amountToAdd){
        strength += amountToAdd;
        baseAttack = strength / 2;
    }
    private void AddConstitution(int amountToAdd)
    {
        constitution += amountToAdd;
        health = constitution * 10;
    }
}
