using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    public int count;
    private float movementX;
    private float movementY;
    // private Rigidbody2D rb;
    private Vector2 targetPosition;
    private Vector2 up;
    private Vector2 down;
    private Vector2 left;
    private Vector2 right;
    private float HighBound = 6.0f;
    private float LowBound = -6.0f;
    private float distance;

    public float speed = 0.0f;
    public TextMeshProUGUI countText;

    public int lifeCount = 2;
    public GameObject LifeIcon;
    public GameObject LifeIcon1;
    public GameObject LifeIcon2;
    
    public GameObject TeleportIcon;
    public GameObject TeleportIcon1;

    public AudioSource source;

    public AudioSource[] audiosources;

    private IEnumerator WaitForSoundAndTransition(string sceneName) {
        AudioSource source = GetComponent<AudioSource>();
        audiosources[2].Play();
        yield return new WaitForSeconds(source.clip.length); // wait for sound to finish
        SceneManager.LoadScene(sceneName); // Load next scene
    }
   
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

    void SetCountText() {
        countText.text = count.ToString();
        // 105 pickup objects
        if (count == 2520) {
            //Victory
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            audiosources[1].Play();
        }
    }

    private void FixedUpdate() {
    
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

        // Portal
        if (transform.position.y <= LowBound) {
            transform.position = new Vector2(0.0f, HighBound - 0.1f);
        }
        if (transform.position.y >= HighBound) {
            transform.position = new Vector2(0.0f, LowBound + 0.1f);
        }
    }

    // Pickups
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Pickup"))
        {
            source = col.gameObject.GetComponent<AudioSource>();
            source.Play();
            col.gameObject.SetActive(false);
            count = count + 24;
            SetCountText();
            SceneManager.LoadScene("Victory");
        }
    }

    // Enemy collision
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            if (lifeCount == 2) {
            LifeIcon2.SetActive(false);
        } else if (lifeCount == 1) {
            LifeIcon1.SetActive(false);
        } else if (lifeCount == 0) {
            LifeIcon.SetActive(false);
        }
            if (lifeCount > 0) {
                reset();
            } else {
            StartCoroutine(WaitForSoundAndTransition("GameOver"));
            }
        }
    }

    // Reset the player positions after a death
    void reset() {
        gameObject.SetActive(false);
        audiosources[0].Play();
        gameObject.transform.position = new Vector3(0.0f, -1.25f, 0.0f);
        lifeCount = lifeCount - 1;
        gameObject.SetActive(true);
        // Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        // spawn.spawnEnemy();
    }

    void teleport() {
        float mousePosG;
    }

}
