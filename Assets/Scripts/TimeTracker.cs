using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class TimeTracker : MonoBehaviour
{
    // A short script to track elapsed time between start and stop calls.
    // Can be reusable and attached to any GameObject as time tracking will
    //be needed for tracking skill levels based on time taken to complete areas.

    public bool isRunning;
    public float elapsedTime;

    float startTime;

    public void StartTimer()
    {
        isRunning = true;
        startTime = Time.time;
    }

    public float StopTimer()
    {
        if (!isRunning)
        {
            return elapsedTime;
        }


        isRunning = false;
        elapsedTime = Time.time - startTime;

        return elapsedTime;
    }

    public void ResetTimer()
    {
        isRunning = false;
        elapsedTime = 0f;
    }

}
