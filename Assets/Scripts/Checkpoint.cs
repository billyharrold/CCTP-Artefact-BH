using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Class for setting player spawn points when colliding with a checkpoint.
    
    private Collider trigger;

    //public GameObject checkpointUI;

    [SerializeField] private UIController uiController;

    private UITeachingZone currentZone = UITeachingZone.Checkpoints;

    public UITeachingZone nextZone;



    private void Awake()
    {
        trigger = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        // Check to disable the checkpoint after being triggered so player can't spawn backwards.
        else if (other.CompareTag("Player"))
        {
            uiController.SetUIState(currentZone);
            RespawnPlayer.Instance.spawnTransform = transform;
            trigger.enabled = false;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        uiController.SetUIState(nextZone);
    }
}
