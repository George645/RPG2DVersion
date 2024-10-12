using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Player : Entity{
    PlayerInventory playerInventory;
    int intelligence = 5, strength = 5, dexterity = 5, constitution = 5, level = 0, experience = 0;
    public List<Soldier> soldiers = new List<Soldier>();
    //Ability ability1, ability2
    public Player(string name, int health, int baseAttack, int intelligence, int strength, int dexterity, int constitution) : base(name, constitution * 10, baseAttack){
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
}
