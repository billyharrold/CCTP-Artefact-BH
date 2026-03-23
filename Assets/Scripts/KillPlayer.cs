using System;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Script managing what happens when the player collides with a kill box.
    // Increases death count in player data. Decoupled from respawn logic.


    [SerializeField] private DataEvaluator evaluator;

    //public ClassSystem classSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        RespawnPlayer.Instance.OnTriggerEnter(other);
        PlayerManager.Instance.SetDeathCount();
        Debug.Log(PlayerManager.Instance.GetDeathCount());
        evaluator.TrackDeath();
       // classSystem.UpdateSkillLevels(PlayerManager.Instance.GetDeathCount());
    }
}
