using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject enemy;
    private GameObject newEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnEnemy() {
        newEnemy = Instantiate(enemy, new Vector3(0.0f, 1.25f, 0.0f), Quaternion.identity);
    }
}
