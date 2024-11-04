using UnityEngine;

public class Marker : MonoBehaviour{
//    public Rigidbody2D rb;
    private Vector2 target, direction;
    public Soldier soldier;
    public Player player;
    public LineRenderer lineRenderer;
    private int multiplier;
    void Update(){
        if (lineRenderer.enabled == true && soldier.selected == true){
            multiplier = soldier.orderInArmy;
            direction = (lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1)).normalized;
            target = (Vector2)lineRenderer.GetPosition(0) - direction * multiplier;
            transform.position = target;
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position = target;
        //}
    }
}