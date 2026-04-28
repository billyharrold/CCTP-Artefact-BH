using System;
using UnityEngine;

public class SelectTeachingZOne : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        UIController.Instance.SetUIState(UITeachingZone.JumpingTeaching);
    }
}
