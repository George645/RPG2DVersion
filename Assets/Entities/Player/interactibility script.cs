using UnityEngine;

public class interactibilityscript : MonoBehaviour
{
    public Rigidbody2D followee;
    public Rigidbody2D marker;
    private Vector2 target;
    public bool visible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = followee.position;
        transform.position = target;
    }
}
