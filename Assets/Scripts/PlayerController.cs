using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    public int count;
    private float movementX;
    private float movementY;
    // private Rigidbody2D rb;
    public Vector2 targetPosition;
    public Vector2 up;
    public Vector2 down;
    public Vector2 left;
    public Vector2 right;

    public float speed = 0;
    public TextMeshProUGUI countText;

   
    void Start()
    {
        count = 0;
        targetPosition = transform.position;
        up = new Vector2(0.0f, 15.0f);
        down = new Vector2(0.0f, -15.0f);
        left = new Vector2(-15.0f, 0.0f);
        right = new Vector2(15.0f, 0.0f);
        // rb = GetComponent<Rigidbody2D>();
        SetCountText();
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() {
        countText.text = count.ToString();
        if (count == 105) {
            //Victory
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void FixedUpdate() {
        // Vector2 movement = new Vector2(movementX, movementY);
        // rb.AddForce(movement * speed);
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            direction = up;
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            direction = down;
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            direction = left;
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            direction = right;
        }

        if (direction != Vector2.zero) {
            targetPosition = (Vector2)transform.position + direction;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
