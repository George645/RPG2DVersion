using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Player : Entity {
    PlayerInventory playerInventory;
    public List<Soldier> soldiersUnderCommand = new List<Soldier>(); // WHY DOES THIS NEED TO BE PUBLIC????????!??!?
    public int totalSoldiers;
    public List<Soldier> selectedSoldiers = new List<Soldier>();
    public int totalSelectedSoldiers;
    private int level = 0, experience = 0, strength, dexterity, constitution, health, maxhealth, baseAttack;
    public int Level { get { return level; } }
    public int Experience { set { experience = value; } }
    //Ability ability1, ability2
    public Player(string name, int intelligence, int strength, int dexterity, int constitution, int baseAttack){
        health = constitution * 10;
        this.strength = strength;
        this.dexterity = dexterity;
        this.constitution = constitution;
        maxhealth = health;
        this.baseAttack = baseAttack;
        totalSoldiers = soldiersUnderCommand.Count;
    }
    public void AddSoldier(Soldier soldier){
        Debug.Log(soldiersUnderCommand.Capacity);
        Debug.Log(soldier);
        soldiersUnderCommand.Add(soldier);
        totalSoldiers = soldiersUnderCommand.Count();
    }
    public void RemoveSoldier(Soldier soldier){
        try{
            soldiersUnderCommand.Remove(soldier);
            Destroy(soldier);
            totalSoldiers = soldiersUnderCommand.Count();
        }
        catch{
            Debug.Log(message: "there was no soldier with id " + soldier.name);
        }
    }
    public void SoldiersInList(List<Soldier> AttemptedSelectedSoldiers){
        int count = 0;
        selectedSoldiers.OrderBy(Soldier => Soldier.orderInArmy);
        foreach (Soldier soldier in AttemptedSelectedSoldiers){
            if (soldiersUnderCommand.Contains(soldier)){
                selectedSoldiers.Add(soldier);
                soldier.selected = true;
                soldier.orderInLine = count;
                count++;
            }
        }
        //foreach (Soldier soldier in selectedSoldiers)
        //{
        //    Debug.Log(soldier.orderInArmy);
        //}
        totalSelectedSoldiers = selectedSoldiers.Count();
    }
    public void LevelUp(){
        Debug.Log(message: "This is not yet implemented, needs to run into the other attributes");
    }
    private void AddStrength(int amountToAdd){
        strength += amountToAdd;
        baseAttack = strength / 2;
    }
    private void AddConstitution(int amountToAdd){
        constitution += amountToAdd;
        health = constitution * 10;
    }
}
