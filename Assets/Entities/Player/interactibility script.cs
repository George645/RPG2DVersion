using UnityEngine;

public class interactibilityscript : MonoBehaviour{
    public PlayerController followee;
    private Vector2 target;
    public bool visible;
    private LineRenderer lr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        lr = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update() {
        //if (settings.visibleinteractible){
        //lr.enabled = true;
        //}
        //else{
        //lr.enabled = false;
        //}
        target = followee.rb.position;
        if (followee.directionFacing == PlayerController.direction.up) {
            target.y += 1;
        }
        else if (followee.directionFacing == PlayerController.direction.right) {
            target.x += (float)1.65;
        }
        else if (followee.directionFacing == PlayerController.direction.down) {
            target.y -= 1;
        }
        else if (followee.directionFacing == PlayerController.direction.left) {
            target.x -= (float)1.65;
        }
        else {
            Debug.Log(followee.directionFacing);
        }
    }
    private void FixedUpdate()
    {
    transform.position = target;
    }
}
