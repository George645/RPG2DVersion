using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Soldier : Entity{
    [SerializeField]int  baseAttack = 5, /*dexterity = 5, strength = 5, */constitution = 5;
    int maxhealth;
    float health;
    public int orderInArmy = 0;
    public int orderInLine = 0;
    [SerializeField] Player player;
    Player[] playerlist;
    public bool selected = false;
    private LineRenderer lr;
    [SerializeField] bool canPlayerControl;
    float healthHeight = 2.1f;
    EnemysTarget assignTo;
    public List<Enemy>? enemyList = new();
    EnemysTarget[] enemyArray;
    //Ability ability
    //string dialogue option? so that the player can interact with them
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
        try
        {
            enemyList = player.enemyList;
        }
        catch { }
        if (canPlayerControl)
        {
            playerlist = (Player[])FindObjectsByType(typeof(Player), FindObjectsSortMode.None);
            if (playerlist.Count() == 1)
            {
                player = playerlist[0];
            }
            else
            {
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
            try
            {
                lr = GetComponent<LineRenderer>();
            }
            catch
            {
                lr = new LineRenderer();
                lr = GetComponent<LineRenderer>();
            }
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    void DealDamage(Enemy enemy)
    {
        enemy.TakeDamage(baseAttack);
    }
    void Update()
    {
        try
        {
            enemyList = player.enemyList;
        }
        catch { }
        if (lr != null)
        {
            if (canPlayerControl)
            {
                lr.SetPosition(1, new Vector3((health /* 1.5f*/ / maxhealth) - 0.5f + transform.position.x, healthHeight + transform.position.y));
            }
            lr.positionCount = 2;
            lr.SetPosition(0, new Vector3(-0.5f + transform.position.x, healthHeight + transform.position.y));
            lr.startColor = Color.red;
            lr.endColor = Color.red;
        }
        foreach (Enemy enemy in enemyList)
        {
            if (Vector2.Distance(enemy.transform.position, this.transform.position) < 1)
            {
                DealDamage(enemy);
            }
        }
    }
}