using UnityEngine;

public class TimeCheckPoint : MonoBehaviour
{
    // Class for tracking time between 2 checkpoints. 
    // Separate to normal checkpoints as this is specifically for time tracking.
    public enum CheckpointType
    {
        Start,
        End
    };
    public CheckpointType checkpointType;

    public TimeTracker timeTracker;

    private void OnTriggerEnter(Collider other)
    {
        
        if (timeTracker != null)
        {
            if (checkpointType == CheckpointType.Start)
            {
                timeTracker.StartTimer();
            }
            else if (checkpointType == CheckpointType.End)
            {
                float elapsedTime = timeTracker.StopTimer();
                Debug.Log("Elapsed Time: " + elapsedTime + " seconds");
            }
        }
    }
}

