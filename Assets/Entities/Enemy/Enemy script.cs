using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed, detectionRange, baseAttack, health;
    [SerializeField] Player player;

    bool enemyTargetted = false;
    int maxHealth;
    EnemysTarget targettedEnemy;
    EnemysTarget[] oneTimeCalledList;
    List<GameObject> friendlyPositions = new();
    GameObject closestFriendly;
    Rigidbody2D rb;
    Player[] playerlist;
    Vector2 direction, spareVector2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        player.enemyList.Add(this);
        oneTimeCalledList = (EnemysTarget[])FindObjectsByType(typeof(EnemysTarget), FindObjectsSortMode.None);
        targettedEnemy = oneTimeCalledList[0];
        friendlyPositions = targettedEnemy.friendlyPositions;
        //closestFriendly = friendlyPositions[0];
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("reached end of start");
    }
    void Attack(Soldier damagee)
    {
        damagee.TakeDamage(baseAttack);
    }
    void Attack(Player damagee)
    {
        damagee.TakeDamage(baseAttack);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    void ThisMethodToDetectFriendlies()
    {
        friendlyPositions = targettedEnemy.friendlyPositions;
        if (closestFriendly == null)
        {
            closestFriendly = friendlyPositions[0];
        }
        foreach (GameObject friendly in friendlyPositions)
        {
            Debug.Log(friendly);
            if (Vector2.Distance(transform.position, friendly.transform.position) <= detectionRange)
            {
                targettedEnemy.EnemyTargettedFriendly = true;
            }
            spareVector2 = new Vector2(Math.Abs(transform.position.x - friendly.transform.position.x), Math.Abs(transform.position.y - friendly.transform.position.y));
            if (spareVector2.magnitude < new Vector2(Math.Abs(transform.position.x - closestFriendly.transform.position.x), Math.Abs(transform.position.y - closestFriendly.transform.position.y)).magnitude)
            {
                closestFriendly = friendly;
            }

            try
            {
                enemyTargetted = targettedEnemy.EnemyTargettedFriendly;
            }
            catch { }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0.1f;
        InvokeRepeating("ThisMethodToDetectFriendlies", 0f, 1f);
    }
    private void FixedUpdate()
    {
        if (enemyTargetted)
        {
            direction = new Vector2(-transform.position.x + closestFriendly.transform.position.x, -transform.position.y + closestFriendly.transform.position.y);
            direction = direction.normalized;
            rb.linearVelocity = new Vector2(moveSpeed * direction.x, moveSpeed * direction.y);
            if (Vector2.Min(new Vector2(Math.Abs(transform.position.x - closestFriendly.transform.position.x), Math.Abs(transform.position.y - closestFriendly.transform.position.y)), direction) == new Vector2(Math.Abs(transform.position.x - closestFriendly.transform.position.x), Math.Abs(transform.position.y - closestFriendly.transform.position.y)))
            {
                try
                {
                    Attack(closestFriendly.GetComponent<Soldier>());
                }
                catch
                {
                    Attack(closestFriendly.GetComponent<Player>());
                }
            }
        }
    }
}
