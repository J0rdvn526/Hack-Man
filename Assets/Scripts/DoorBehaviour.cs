using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private float timeSinceContact;
    private float doorTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentTime = Time.time;
        float elapsedTime = currentTime - timeSinceContact;
        if (elapsedTime > doorTime) {
            gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            gameObject.SetActive(false);
            timeSinceContact = Time.time;
        }
    }
}
