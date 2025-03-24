using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 target;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        SetAgentPosition();
    }

    void SetTarget() {
        if (player != null) {
            target = player.position;
        }
    }
    void SetAgentPosition() {
        if (player != null) {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        }
    }
        
    
}
