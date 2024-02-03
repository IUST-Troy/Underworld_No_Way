using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    private Vector3 initScale;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float idleDuration;
    private bool movingLeft;
    private float idleTimer;

    [Header("Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
                ChangeDirection();

        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
                ChangeDirection();
        }
    }

    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }
    private void ChangeDirection()
    {
        idleTimer += Time.deltaTime;
        anim.SetBool("Moving", false);
        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Moving", true);

        // Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);
        // Move in that position
        enemy.localPosition = new Vector3(enemy.localPosition.x + Time.deltaTime * _direction * speed,
            enemy.localPosition.y, enemy.localPosition.z);
    }
}
