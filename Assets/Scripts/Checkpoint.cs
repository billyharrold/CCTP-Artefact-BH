using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Class for setting player spawn points when colliding with a checkpoint.
    
    private CapsuleCollider trigger;

    private void Awake()
    {
        trigger = GetComponent<CapsuleCollider>();
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
            RespawnPlayer.Instance.spawnTransform = transform;
            trigger.enabled = false;
        }

    }
}
