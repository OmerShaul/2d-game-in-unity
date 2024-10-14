using UnityEngine;

public class Enemy_UpAndDown : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private Vector3 initPosition;
    private bool movingUp;
    private float topPoint;
    private float bottomPoint;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    private void Awake()
    {
        initPosition = enemy.position;
        topPoint = initPosition.y + movementDistance;
        bottomPoint = initPosition.y;
    }


    private void Update()
    {
        if (movingUp)
        {
            if (enemy.position.y <= topPoint)
                MoveInDirection(1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.y >= bottomPoint)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
     
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingUp = !movingUp;
    }

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        float movementStep = speed * Time.deltaTime * direction;
        enemy.position = new Vector3(enemy.position.x, enemy.position.y + movementStep, enemy.position.z);
    }
}