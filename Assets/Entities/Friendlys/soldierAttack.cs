using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : MonoBehaviour
{
    public Soldier overallSoldier;
    CircleCollider2D circleCollider;
    List<Enemy> enemysInRange = new();
    Enemy closest;
    [SerializeField] float spawnTime = 3f; //timeframe variable
    [SerializeField] float tempCounter = 0f; //timeframe temp variable
    void Start(){
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name.Contains("Enemy")){
            enemysInRange.Add(collision.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            enemysInRange.Remove(collision.GetComponent<Enemy>());
        }
    }
    void Update(){
        if (tempCounter <= 0f){  //check if the counter equals 0
            //Debug.Log(enemysInRange[0]);
            if (enemysInRange.Count > 0){
                closest = enemysInRange[0];
                foreach (Enemy enemy in enemysInRange){
                    if (Vector2.Distance(enemy.transform.position, transform.position) < Vector2.Distance(closest.transform.position, transform.position)){
                        closest = enemy;
                    }
                }
                overallSoldier.Attack(closest);
            }
            tempCounter = spawnTime;  //reset the timer or cd
        }
        else{
            tempCounter -= Time.deltaTime;  //take down time 
        }
    }
}
