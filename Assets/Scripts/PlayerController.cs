using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int count;
    private float movementX;
    private float movementY;
    private Rigidbody2D rb;

    public float speed = 0;
    public TextMeshProUGUI countText;

   
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody2D>();
        SetCountText();
    }

    void OnMove(InputValue movementValue ) {
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
        Vector2 movement = new Vector2(movementX, movementY);
        rb.AddForce(movement * speed);
        // rb.MovePosition()
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
