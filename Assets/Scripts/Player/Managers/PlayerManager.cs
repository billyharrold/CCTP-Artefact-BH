using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerData playerData = new PlayerData();

    public event Action<PlayerData> OnPlayerDataUpdated;

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
        playerData = data;
        OnPlayerDataUpdated?.Invoke(data);
    }
}
