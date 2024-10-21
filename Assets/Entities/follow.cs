using System;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class follow : MonoBehaviour
{
    public Rigidbody2D followee;
    private Vector2 target;
    private void FixedUpdate()
    {
        target = followee.position;
//        target.y -= (float)0.1;
        transform.position = followee.position;
    }
}


