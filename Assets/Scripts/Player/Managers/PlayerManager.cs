using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerData playerData = new PlayerData();

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

    public void setDeathCount()
    {
        playerData.deathCount++;
    }

    public int getDeathCount()
    {
        return playerData.deathCount;
    }
}
