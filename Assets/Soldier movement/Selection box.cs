using UnityEngine;
using System.Collections.Generic;

public class Selectionbox : MonoBehaviour
{
    LineRenderer lr;
    BoxCollider2D box;
    Soldier soldier;
    List<Soldier> attemptingselectedSoldier = new List<Soldier>();
    public Player player;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        box = GetComponent<BoxCollider2D>();
        Destroy(box);
        lr.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            soldier = other.gameObject.GetComponent<Soldier>();
            attemptingselectedSoldier.Add(soldier);
        }
        catch { }
    }
    void Update(){
        try {
            if (attemptingselectedSoldier.Count > 0){
                player.SoldiersInList(attemptingselectedSoldier);
                attemptingselectedSoldier = new List<Soldier>();
                Destroy(box);
            }
        }
        catch{
        }
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Soldier soldier in player.selectedSoldiers)
            {
                soldier.selected = false;
            }
            player.selectedSoldiers = new List<Soldier>();
            player.totalSelectedSoldiers = 0;
            lr.enabled = true;
            lr.SetPosition(9, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.SetPosition(11, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetMouseButton(0))
        {
            lr.SetPosition(0, new Vector3(lr.GetPosition(11).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
            lr.SetPosition(4, new Vector3(lr.GetPosition(11).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
            lr.SetPosition(2, new Vector3(lr.GetPosition(11).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
            lr.SetPosition(3, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.SetPosition(7, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.SetPosition(5, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.SetPosition(6, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, lr.GetPosition(11).y));
            lr.SetPosition(10, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, lr.GetPosition(11).y));
            lr.SetPosition(8, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, lr.GetPosition(11).y));
        }
        if (Input.GetMouseButtonUp(0)){
            box = gameObject.AddComponent<BoxCollider2D>();
            box.isTrigger = true;
            lr.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        
    }
}
