using UnityEngine;

public class SoldierMovement : MonoBehaviour{
    public Rigidbody2D rbMarker;
    public Rigidbody2D rbSelf;
    public float speed = 3;
    private Vector2 movement;
    void Update(){
        if (rbMarker.position.x < rbSelf.position.x && rbMarker.position.x - rbSelf.position.x < 10){
            movement.x = -1;
        }
        else if (rbMarker.position.x > rbSelf.position.x){
            movement.x = 1;
        }
        else{
            movement.x = 0;
        }
        if (rbMarker.position.y < rbSelf.position.y){
            movement.y = -1;
        }
        else if (rbMarker.position.y > rbSelf.position.y){
            movement.y = 1;
        }
        else{
            movement.y = 0;
        }
        movement.Normalize();
    }
    void FixedUpdate(){
        // Apply horizontal movement
        rbSelf.MovePosition(rbSelf.position + movement * speed * Time.fixedDeltaTime);
    }
}
