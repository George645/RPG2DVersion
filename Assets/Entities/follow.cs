using UnityEngine;
public class follow : MonoBehaviour
{
    public Rigidbody2D followee;
    public Rigidbody2D marker;
    private Vector2 target;
    private Animator animator;
    public bool isSoldier;
    float verticalToMove;
    float horizontalToMove;
    private void Start(){
        if (isSoldier){
            animator = GetComponent<Animator>();
        }
    }
    private void FixedUpdate(){
        verticalToMove = marker.position.y - target.y;
        horizontalToMove = marker.position.x - target.x;
        target = followee.position;
        if (isSoldier){
            animator.SetBool("Moving", true);
            if (-1 < verticalToMove && verticalToMove < 1){
                if (-1 < horizontalToMove && horizontalToMove < 1){
                    animator.SetBool("Moving", false);
                }
                else if (horizontalToMove > 0){
                    animator.SetInteger("Direction", 3);
                }
                else if (horizontalToMove < 0){
                    animator.SetInteger("Direction", 7);
                }
            }
            else if ((int)verticalToMove < 0){
                if (-1 < horizontalToMove && horizontalToMove < 1){
                    animator.SetInteger("Direction", 5);
                }
                else if (horizontalToMove > 0){
                    animator.SetInteger("Direction", 4);
                }
                else if (horizontalToMove < 0){
                    animator.SetInteger("Direction", 6);
                }
            }
            else if ((int)verticalToMove > 0){
                if (-1 < horizontalToMove && horizontalToMove < 1){
                    animator.SetInteger("Direction", 1);
                }
                else if (horizontalToMove > 0){
                    animator.SetInteger("Direction", 2);
                }
                else if (horizontalToMove < 0){
                    animator.SetInteger("Direction", 8);
                }
            }
            else{
                Debug.Log((int)verticalToMove + "in the follow script");
            }
        }
        target.y -= (float)0.1;
        transform.position = target;
    }
}


