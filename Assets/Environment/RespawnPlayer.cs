using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [Header("References")]
    public Transform spawnPoint;
    public CharacterController controller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;  
        }

        PlayerManager.Instance.setDeathCount();
        Debug.Log(PlayerManager.Instance.getDeathCount());

        controller.enabled = false;
        Debug.Log("Death");
        controller.transform.position = spawnPoint.position;
        controller.enabled = true;
    }
}
