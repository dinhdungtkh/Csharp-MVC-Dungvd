using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeDirectionInterval = 2f;
    public Vector3 movementArea = new Vector3(10f, 0f, 10f);

    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        SetNewTargetPosition();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            SetNewTargetPosition();
            timer = 0f;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void SetNewTargetPosition()
    {
        float randomX = Random.Range(-movementArea.x / 2, movementArea.x / 2);
        float randomZ = Random.Range(-movementArea.z / 2, movementArea.z / 2);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}