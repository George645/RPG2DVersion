using UnityEngine;

public class Healthbarscript : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] Soldier soldier;
    float healthHeight = 2.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update(){

        if (lineRenderer != null){
            if (soldier.canPlayerControl){
                lineRenderer.SetPosition(1, new Vector3((soldier.health /* 1.5f*/ / soldier.maxhealth) - 0.5f/* + transform.position.x*/, healthHeight/* + transform.position.y*/));
            }
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3(-0.5f/* + transform.position.x*/, healthHeight/* + transform.position.y*/));
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
        else{
            new MissingComponentException();
        }
    }
}