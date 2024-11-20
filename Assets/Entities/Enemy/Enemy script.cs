using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour{
    [SerializeField] float moveSpeed, detectionRange, baseAttack, health;
    [SerializeField] Player player;
    int maxHealth;
    EnemysTarget targettedEnemy;
    EnemysTarget[] oneTimeCalledList;
    List<GameObject> friendlyPositions = new();
    GameObject closestFriendly;
    Rigidbody2D rb;
    Player[] playerlist;
    Vector2 direction, spareVector2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        playerlist = (Player[])FindObjectsByType(typeof(Player), FindObjectsSortMode.None);
        if (playerlist.Count() == 1){
            player = playerlist[0];
        }
        else{
            new UnhandledExceptionEventArgs(player, true);
        }
        player.enemyList.Add(this);
        oneTimeCalledList = (EnemysTarget[])FindObjectsByType(typeof(EnemysTarget), FindObjectsSortMode.None);
        targettedEnemy = oneTimeCalledList[0];
        friendlyPositions = targettedEnemy.friendlyPositions;
        //closestFriendly = friendlyPositions[0];
        rb = GetComponent<Rigidbody2D>();
    }
    public void Attack(Player damagee){
        damagee.TakeDamage(baseAttack);
    }
    public void Attack(Soldier damagee){
        damagee.TakeDamage(baseAttack);
    }
    public void TakeDamage(float damage){
        health -= damage;
    }
    public void moveTowardsNearestEnemy(GameObject target){
        direction = new Vector2(-transform.position.x + target.transform.position.x, -transform.position.y + target.transform.position.y);
        direction = direction.normalized;
        rb.linearVelocity = new Vector2(moveSpeed * direction.x, moveSpeed * direction.y);
    }
    private void Update(){
        if (health <= 0){
            Destroy(this.gameObject); 
            return;
        }
    }
}
