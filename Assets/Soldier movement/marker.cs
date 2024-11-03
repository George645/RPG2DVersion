using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Marker : MonoBehaviour
{
//    public Rigidbody2D rb;
    private Vector2 target, direction;
    public Soldier soldier;
    public LineRenderer lineRenderer;
    private int multiplier;
    void Update()
    {
        if (lineRenderer.enabled == true)
        {
            multiplier = soldier.orderInLine;
            Debug.Log("marker correct");
            direction = (lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1)).normalized;
            Debug.Log(direction);
            target = (Vector2)lineRenderer.GetPosition(0) - direction * multiplier;
            Debug.Log(target + " " + (Vector2)lineRenderer.GetPosition(0) + " " + multiplier);
            transform.position = target;
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position = target;
        //}
    }
}