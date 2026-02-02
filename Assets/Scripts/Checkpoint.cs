using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
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

        else if (other.CompareTag("Player"))
        {
            RespawnPlayer.Instance.spawnTransform = transform;
            trigger.enabled = false;
        }

    }
}
