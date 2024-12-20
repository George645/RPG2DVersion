using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    public float moveSpeed = 5;        // Horizontal movement speed
    public Rigidbody2D rb;              // Rigidbody2D component
    public Canvas canvas;
    private Vector2 movement;           // Store player movement input
    static Vector3Int currentPos;
    public enum direction{
        up, left, right, down
    }
    public direction directionFacing = direction.up;
    private string buttonPushed;


    void Update(){
        // Get the horizontal input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Set(movement.x, (float)movement.y/2);
        currentPos = new Vector3Int((int)rb.position.x, (int)rb.position.y);
        movement.Normalize();
        if (Input.GetKey("w")){
            directionFacing = direction.up;
        }
        if (Input.GetKey("a")){
            directionFacing = direction.left;
        }
        if (Input.GetKey("d")){
            directionFacing = direction.right;
        }
        if (Input.GetKey("s")){
            directionFacing = direction.down;
        }
    }
    void FixedUpdate(){
        // Apply horizontal movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.Escape)) {
            if (canvas.enabled == false)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            canvas.enabled = !canvas.enabled;
        }
    }

}

