using UnityEngine;
using UnityEngine.XR;

public class TimeTracker : MonoBehaviour
{
    // A short script to track elapsed time between start and stop calls.
    // Can be reusable and attached to any GameObject as time tracking will
    //be needed for tracking skill levels based on time taken to complete areas.

    public bool IsRunning;
    public float ElapsedTime;

    float StartTime;

    public void StartTimer()
    {
        IsRunning = true;
        StartTime = Time.time;
    }

    public float StopTimer()
    {
        if (!IsRunning)
        {
            return ElapsedTime;
        }


        IsRunning = false;
        ElapsedTime = Time.time - StartTime;

        return ElapsedTime;
    }

    public void ResetTimer()
    {
        IsRunning = false;
        ElapsedTime = 0f;
    }

}
