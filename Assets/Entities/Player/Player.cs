using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;
public class Player : Entity {
    PlayerInventory playerInventory;
    public List<Soldier> soldiersUnderCommand = new List<Soldier>(); // WHY DOES THIS NEED TO BE PUBLIC????????!??!?
    public int totalSoldiers;
    public List<Soldier> selectedSoldiers = new List<Soldier>();
    public int totalSelectedSoldiers;
    private int level = 0, experience = 0, strength, dexterity, constitution = 5, maxhealth, baseAttack;
    private float health;
    public int Level { get { return level; } }
    public int Experience { set { experience = value; } }
    EnemysTarget singleUseAddToList;
    public List<Enemy> enemyList = new();
    EnemysTarget assignTo;
    EnemysTarget[] enemyArray;
    //Ability ability1, ability2
    private void Start()
    {
        enemyArray = (EnemysTarget[])FindObjectsByType(typeof(EnemysTarget), FindObjectsSortMode.None);
        if (enemyArray.Count() == 1)
        {
            assignTo = enemyArray[0];
        }
        else
        {
            new UnhandledExceptionEventArgs(enemyArray, true);
        }
        assignTo.friendlyPositions.Add(gameObject);
        constitution = 5;
        health = constitution * 10;
        maxhealth = (int)health;
        totalSoldiers = soldiersUnderCommand.Count;
    }
    public Player(string name, int intelligence, int strength, int dexterity, int constitution, int baseAttack){
        this.strength = strength;
        this.dexterity = dexterity;
        this.constitution = constitution;
        this.baseAttack = baseAttack;
    }
    public void AddSoldier(Soldier soldier){
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
    public void TakeDamage(float damage)
    {
        health -= damage;
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
    private void Update()
    {
        if (health <= 0)
        {
            SceneChanger.ChangeScene("game over");
        }
    }
}
