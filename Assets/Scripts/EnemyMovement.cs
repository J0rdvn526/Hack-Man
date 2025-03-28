using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveTime;
    public float minTime = 0.25f;
    public float maxTime = 1.25f;
    private float startTime;


    private float HighBound = 6.0f;
    private float LowBound = -6.0f;
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
        moveTime = Random.Range(minTime, maxTime);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);

        // Portal
        if (transform.position.y <= LowBound) {
            transform.position = new Vector2(0.0f, HighBound - 0.1f);
        }
        if (transform.position.y >= HighBound) {
            transform.position = new Vector2(0.0f, LowBound + 0.1f);
        }
        
    }

    void setTargetPosition() {
        targetPosition = (Vector2)transform.position + movements[Random.Range(0, 4)];
        startTime = Time.time;
    }
    
    // Don't get stuck on walls or each other
    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy")) {
            setTargetPosition();
        }
    }
}
