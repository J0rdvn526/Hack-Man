using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveTime = 1.0f;
    public float startTime;

    public float speed;
    private Vector2 up;
    private Vector2 down;
    private Vector2 left;
    private Vector2 right;
    private Vector2[] movements;
    private Vector2 targetPosition;
    private Rigidbody2D body;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        up = new Vector2(0.0f, 5.0f);
        down = new Vector2(0.0f, -5.0f);
        left = new Vector2(-5.0f, 0.0f);
        right = new Vector2(5.0f, 0.0f);
        movements = new Vector2[] {up, down, left, right};
        setTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Every 'moveTime' seconds move in a random direction
        float currentTime = Time.time;
        float timeElapsed = currentTime - startTime;
        if (timeElapsed > moveTime) {
            setTargetPosition();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        
    }

    void setTargetPosition() {
        targetPosition = (Vector2)transform.position + movements[Random.Range(0, 4)];
        startTime = Time.time;
    }
    
}
