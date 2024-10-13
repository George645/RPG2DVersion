using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Marker : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 target;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = target;
        }
    }
}
