using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class marker
{
    public Rigidbody2D rb;
    private Vector3 target;
    void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.Set(Mouse.position);
        }
    }
}
