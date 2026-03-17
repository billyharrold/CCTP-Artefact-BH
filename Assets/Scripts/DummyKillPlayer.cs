using UnityEngine;

public class DummyKillPlayer : MonoBehaviour
{
    // Script managing what happens when the player collides with a kill box.
    // Increases death count in player data. Decoupled from respawn logic.

    // seperate script so can use deaths as fails but not respawn player


    //public ClassSystem classSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        //RespawnPlayer.Instance.OnTriggerEnter(other);
        PlayerManager.Instance.SetDeathCount();
        Debug.Log(PlayerManager.Instance.GetDeathCount());
        // classSystem.UpdateSkillLevels(PlayerManager.Instance.GetDeathCount());
    }
}
