using System;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    public ClassSystem classSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PlayerManager.Instance.SetDeathCount();
        Debug.Log(PlayerManager.Instance.GetDeathCount());
        classSystem.UpdateSkillLevels(PlayerManager.Instance.GetDeathCount());
    }
}
