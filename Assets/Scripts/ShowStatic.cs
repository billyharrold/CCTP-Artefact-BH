using System;
using UnityEngine;

public class ShowStatic : MonoBehaviour
{

    public GameObject staticUI;

    void Start()
    {
        staticUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        staticUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        staticUI.SetActive(false);
    }


}
