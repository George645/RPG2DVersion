using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionRange : MonoBehaviour{
    CircleCollider2D circleCollider;
    List<GameObject> friendlysInRange = new();
    GameObject closest;
    Soldier soldier;
    Player player;
    [SerializeField] Enemy enemy;
    [SerializeField] bool detection;//false is attacking
    [SerializeField] float attackSpeed = 3f; //timeframe variable
    private float tempCounter = 0f; //timeframe temp variable
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name.Contains("soldier") || collision.gameObject.name == "Character's movement hitbox"){
            friendlysInRange.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        try{
            friendlysInRange.Remove(collision.gameObject);
        }
        catch { }
    }
    // Update is called once per frame
    void Update(){
        if (detection){
            if (friendlysInRange.Count > 0){
                closest = friendlysInRange[0];
                foreach (GameObject enemy in friendlysInRange){
                    if (Vector2.Distance(enemy.transform.position, transform.position) < Vector2.Distance(closest.transform.position, transform.position)){
                        closest = enemy;
                    }
                }
                enemy.moveTowardsNearestEnemy(closest);
            }
        }
        else{
            if (tempCounter <= 0f){  //check if the counter equals 0
                if (friendlysInRange.Count > 0){
                    closest = friendlysInRange[0];
                    foreach (GameObject enemy in friendlysInRange){
                        if (Vector2.Distance(enemy.transform.position, transform.position) < Vector2.Distance(closest.transform.position, transform.position)){
                            closest = enemy;
                        }
                    }
                    try{
                        soldier = closest.GetComponent<Soldier>();
                        enemy.Attack(soldier);
                    }
                    catch{
                        player = closest.GetComponent<Player>();
                        enemy.Attack(player);
                    }
                }
                tempCounter = attackSpeed;  //reset the timer or cd
            }
            else{
                tempCounter -= Time.deltaTime;  //take down time 
            }
        }
    }
}
