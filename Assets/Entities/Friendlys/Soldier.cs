using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Soldier : Entity{
    [SerializeField]int  baseAttack = 5, /*dexterity = 5, strength = 5, */constitution = 5;
    public int maxhealth;
    public float health;
    public int orderInArmy = 0;
    public int orderInLine = 0;
    [SerializeField] Player player;
    Player[] playerlist;
    public bool selected = false;
    public bool canPlayerControl;
    EnemysTarget assignTo;
#nullable enable
    public List<Enemy>? enemyList = new();
#nullable disable
    EnemysTarget[] enemyArray;
    public GameObject parentObject;
    //Ability ability
    //string dialogue option? so that the player can interact with them
    private void Start(){
        enemyArray = (EnemysTarget[])FindObjectsByType(typeof(EnemysTarget), FindObjectsSortMode.None);
        if (enemyArray.Count() == 1){
            assignTo = enemyArray[0];
        }
        else{
            new UnhandledExceptionEventArgs(enemyArray, true);
        }
        assignTo.friendlyPositions.Add(gameObject);
        try{
            enemyList = player.enemyList;
        }
        catch { }
        if (canPlayerControl){
            playerlist = (Player[])FindObjectsByType(typeof(Player), FindObjectsSortMode.None);
            if (playerlist.Count() == 1){
                player = playerlist[0];
            }
            else{
                new UnhandledExceptionEventArgs(player, true);
            }
            //level = level;
            //experience = experience;
            //strength = strength;
            //dexterity = dexterity;
            //constitution = constitution;
            //baseattack = baseattack;
            health = constitution * 10; ;
            maxhealth = (int)health;
            player.AddSoldier(this);
            orderInArmy = player.totalSoldiers;
        }
    }
    public void TakeDamage(float damage){
        health -= damage;
    }
    public void Attack(Enemy enemy){
        enemy.TakeDamage(baseAttack);
    }
    void Update(){
        if (health <= 0){
            Destroy(parentObject);
        }
        try{
            enemyList = player.enemyList;
        }
        catch { }
    }
}