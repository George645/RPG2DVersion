using UnityEngine;
using System;

public class SoldierMovement : MonoBehaviour{
    public Rigidbody2D rbMarker;
    public Rigidbody2D rbSelf;
    public float speed = 3;
    private Vector2 movement;
    void Update(){
        movement.y = 0;
        movement.x = 0;
        if (Math.Abs(rbSelf.position.x - rbMarker.position.x) > 0.1){
            if (rbMarker.position.x < rbSelf.position.x){
                movement.x = -1;
            }
            else if (rbMarker.position.x > rbSelf.position.x){
                movement.x = 1;
            }
            else{
            }
        }
        if(Math.Abs(rbSelf.position.y - rbMarker.position.y) > 0.1)
            if (rbMarker.position.y < rbSelf.position.y){
                movement.y = -1;
            }
            else if (rbMarker.position.y > rbSelf.position.y){
                movement.y = 1;
            }
            else{
            }
        movement.y /= 2;
        movement.Normalize();
    }
    void FixedUpdate(){
        // Apply horizontal movement
        rbSelf.MovePosition(rbSelf.position + movement * speed * Time.fixedDeltaTime);
    }
}
