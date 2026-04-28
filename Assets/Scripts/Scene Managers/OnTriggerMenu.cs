using System;
using UnityEngine;

public class OnTriggerMenu : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        //GameSceneManager.Instance.LoadMenu();
        Application.Quit();
    }
}
