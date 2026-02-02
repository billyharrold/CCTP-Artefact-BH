using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RespawnPlayer : MonoBehaviour
{

    public static RespawnPlayer Instance; 
    
    [Header("References")]
    public Transform spawnTransform;
    public CharacterController controller;

    //public ClassSystem classSystem;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;  
        }

        //PlayerManager.Instance.SetDeathCount();
        //Debug.Log(PlayerManager.Instance.GetDeathCount());

        controller.enabled = false;
        Debug.Log("Death");
        controller.transform.position = spawnTransform.position;
        controller.enabled = true;
        //classSystem.UpdateSkillLevels(PlayerManager.Instance.GetDeathCount());
    }
}
