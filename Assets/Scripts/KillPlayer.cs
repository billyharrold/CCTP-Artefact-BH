using System;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Script managing what happens when the player collides with a kill box.
    // Increases death count in player data. Decoupled from respawn logic.


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
