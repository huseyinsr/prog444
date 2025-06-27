using UnityEngine;

public class FollowAndReturn : MonoBehaviour
{
    public Transform target;          
    public float followSpeed = 2f;     
    public float returnSpeed = 3f;      
    public float stopDistance = 0.5f;   

    private Vector3 startPos;
    private bool isReturning = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float distanceToStart = Vector3.Distance(transform.position, startPos);

        if (!isReturning)
        {
            FollowTarget(distanceToTarget);
        }
        else
        {
            ReturnToStart(distanceToStart);
        }
    }

    private void FollowTarget(float distance)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);

        if (distance < stopDistance)
        {
            isReturning = true;
        }
    }

    private void ReturnToStart(float distance)
    {
        Vector3 direction = (startPos - transform.position).normalized;
        transform.Translate(direction * returnSpeed * Time.deltaTime, Space.World);

        if (distance < stopDistance)
        {
            isReturning = false;
        }
    }
}
