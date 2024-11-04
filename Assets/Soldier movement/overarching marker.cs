using UnityEngine;

public class MouseDragSelect : MonoBehaviour{
    public bool turnInvisible;
    Vector2 startPos;
    Vector2 endPos;
    Vector2 dir;
    LineRenderer lr;
    int distancePerUnit = 1;
    float lengthOfLine;
    public Player player;
    int maxLengthOfLine;
    private void Start(){
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }
    void Update() {
        maxLengthOfLine= player.totalSelectedSoldiers*distancePerUnit;
        if (Input.GetMouseButtonDown(1)){
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(0, startPos);
            lr.SetPosition(1, startPos);
            lr.enabled = true;
        }
        else if (Input.GetMouseButton(1)){
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = endPos - startPos;
            lengthOfLine = Mathf.Clamp(Vector2.Distance(endPos, startPos), 0, maxLengthOfLine);
            endPos = startPos + (dir.normalized * lengthOfLine);
            lr.SetPosition(1, endPos);

        }
        else if (Input.GetMouseButtonUp(1) && turnInvisible){
            Debug.Log(" ");
            lr.enabled = false;
        }
    }
}