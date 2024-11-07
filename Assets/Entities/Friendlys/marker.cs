using System;
using System.Linq;
using UnityEngine;

public class Marker : MonoBehaviour{
//    public Rigidbody2D rb;
    private Vector2 target, direction;
    [SerializeField] Soldier soldier;
    [SerializeField]Player player;
    Player[] playerlist;
    [SerializeField] LineRenderer lineRenderer;
    LineRenderer[] lineRendererList;
    MouseDragSelect om;
    private int multiplier;
    private void Start()
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
        lineRendererList= (LineRenderer[])FindObjectsByType(typeof(LineRenderer), FindObjectsSortMode.None);
        foreach(LineRenderer lr in lineRendererList)
        {
            if (lr.name == "formation line")
            {
                lineRenderer = lr;
            }
        }
    }
    void Update(){
        if (lineRenderer.enabled && soldier.selected && Input.GetMouseButtonUp(1)){
            multiplier = soldier.orderInLine;
            direction = (lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1)).normalized;
            target = (Vector2)lineRenderer.GetPosition(0) - direction * multiplier - direction/2;
            transform.position = target;
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position = target;
        //}
    }
}