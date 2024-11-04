using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Player : Entity {
    PlayerInventory playerInventory;
    public List<Soldier> soldiersUnderCommand = new List<Soldier>(); // WHY DOES THIS NEED TO BE PUBLIC????????!??!?
    public int totalSoldiers;
    public List<Soldier> selectedSoldiers = new List<Soldier>();
    public int totalSelectedSoldiers;
    private int level = 0;
    public int Level { get { return level; } }
    private int experience = 0;
    public int Experience { set { experience = value; } }
    //Ability ability1, ability2
    public Player(string name, int intelligence, int strength, int dexterity, int constitution) : base(name, constitution * 10, strength/2, strength, dexterity, constitution, intelligence){
        health = constitution * 10;
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
    public void SoldiersInList(List<Soldier> AttemptedSelectedSoldiers)
    {
        int count = 0;
        foreach (Soldier soldier in AttemptedSelectedSoldiers)
        {
            if (soldiersUnderCommand.Contains(soldier))
            {
                selectedSoldiers.Add(soldier);
                soldier.selected = true;
                soldier.orderInLine = count;
                count++;
            }
        }
        selectedSoldiers.OrderBy(Soldier => Soldier.orderInArmy);
        //foreach (Soldier soldier in selectedSoldiers)
        //{
        //    Debug.Log(soldier.orderInArmy);
        //}
        totalSelectedSoldiers = selectedSoldiers.Count();
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
