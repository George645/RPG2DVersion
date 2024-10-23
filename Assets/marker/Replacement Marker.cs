using UnityEngine;
using System.Collections;
using System;

public class MouseDragSelect : MonoBehaviour{
    public bool turnInvisible;
    Vector2 startPos;
    Vector2 endPos;
    LineRenderer lr;
    private void Start(){
        lr = GetComponent<LineRenderer>();
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("1");
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("2");
            lr.SetPosition(0, startPos);
            Debug.Log("3");
            lr.enabled = true;
            Debug.Log("4");
        }
        else if (Input.GetMouseButton(0)){
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(1, endPos);
        }
        else if (Input.GetMouseButtonDown(0) && turnInvisible){
            lr.enabled = false;
        }
    }
}