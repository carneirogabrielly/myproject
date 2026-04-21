using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum MovementType { Patrol, Chase }

    public MovementType movementType = MovementType.Patrol;
    public float speed = 2f;

    [Header("Patrol Settings")]
    public Vector2 patrolDirection = Vector2.right;
    public float patrolDistance = 3f;

    [Header("Chase Settings")]
    public float chaseRange = 100f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingToEnd = true;
    private Transform chaseTarget;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + (Vector3)patrolDirection.normalized * patrolDistance;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) chaseTarget = player.transform;
    }

    void Update()
    {
        if (GameController.gameOver) return;

        if (movementType == MovementType.Patrol)
        {
            PatrolMove();
        }
        else if (movementType == MovementType.Chase)
        {
            ChaseMove();
        }
    }

    void PatrolMove()
    {
        Vector3 target = movingToEnd ? endPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            movingToEnd = !movingToEnd;
        }
    }

    void ChaseMove()
    {
        if (chaseTarget == null) return;

        float distance = Vector3.Distance(transform.position, chaseTarget.position);
        if (distance <= chaseRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, chaseTarget.position, speed * Time.deltaTime);
        }
    }
}
