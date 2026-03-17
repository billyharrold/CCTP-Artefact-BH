using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform startPoint;
    public Transform endPoint;

    public float speed = 1f;

    private float moveProgress = 0f;
    private bool movingToEnd = true;


    // Update is called once per frame
    void Update()
    {
        if (startPoint == null || endPoint == null)
        {
            return;
        }

        float distance = Vector3.Distance(startPoint.position, endPoint.position);

        if (movingToEnd)
        {
            moveProgress += (speed / distance) * Time.deltaTime;
        }
        else
        {
            moveProgress -= (speed / distance) * Time.deltaTime;
        }

        if (moveProgress >= 1f)
        {
            moveProgress = 1f;
            movingToEnd = false;
        }
        else if (moveProgress <= 0f)
        {
            moveProgress = 0f;
            movingToEnd = true;
        }

        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, moveProgress);


    }
}
