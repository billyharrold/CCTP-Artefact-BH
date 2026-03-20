using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerData playerData = new PlayerData();

    public event Action<PlayerData> OnPlayerDataUpdated;

    private SkillLevel lastSkillLevel;

    void Awake()
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

    // Update is called once per frame


    // functions

    public void SetDeathCount()
    {
        playerData.deathCount++;
        OnPlayerDataUpdated?.Invoke(playerData);
    }

    public int GetDeathCount()
    {
        return playerData.deathCount;
    }


    public void SetElapsedTime(float time)
    {
        playerData.elapsedTime = time;
        OnPlayerDataUpdated?.Invoke(playerData);
    }

    public float GetElapsedTime()
    {
        return playerData.elapsedTime;
    }

    public void UpdatePlayerData(PlayerData data)
    {
        // refactored to only update when skill level changes - was causing UI updates when any data cahanged.
        //playerData = data;
        //OnPlayerDataUpdated?.Invoke(data);

        if (data.playerLevel != playerData.playerLevel)
        {
            playerData = data;

            lastSkillLevel = data.playerLevel;

            OnPlayerDataUpdated?.Invoke(data);
        }
        else
        {
            playerData = data;
        }


    }
}
