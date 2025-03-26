using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    private int moveTime;
    private Rigidbody2D body;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = body.position;
    }
    
}
