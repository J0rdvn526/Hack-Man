using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject enemy;
    private GameObject newEnemy;
    private float time;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnEnemy();
    }

    void FixedUpdate() {
        time = Time.time;
        if (time == 10 || time == 20) {
            spawnEnemy();
        }
    }

    public void spawnEnemy() {
        newEnemy = Instantiate(enemy, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }
}
