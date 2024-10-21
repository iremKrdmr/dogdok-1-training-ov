using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float MoveSpeed;
    public float Delay;
    public float MinDistance;
    public Transform LeftPoint;
    public Transform RightPoint;

    Transform selectedPoint;
    float delayTimer;
    bool waiting;

    private void Start()
    {
        selectedPoint = LeftPoint;
        delayTimer = 0f;
        waiting = false;
    }

    private void Update()
    {
        if (waiting)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer > 0f) return;

            waiting = false;
            if (selectedPoint == LeftPoint) selectedPoint = RightPoint;
            else selectedPoint = LeftPoint;
        }

        if (selectedPoint == null) return;

        if (Vector3.Distance(transform.position, selectedPoint.position) > MinDistance)
        {
            Vector3 moveDirection = (selectedPoint.position - transform.position).normalized;
            transform.Translate(moveDirection * MoveSpeed  * Time.deltaTime, Space.Self);
        }

        else 
        {
            waiting = true;
            delayTimer = Delay;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null, true);
        }
    }
}
