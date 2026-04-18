using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public static GameSceneManager Instance;

    private const string AdaptiveSceneName = "AdaptiveScene";
    private const string StaticSceneName = "StaticScene";




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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadAdaptiveScene()
    {
        SceneManager.LoadScene(AdaptiveSceneName);
    }

    public void LoadStaticScene()
    {
        SceneManager.LoadScene(StaticSceneName);
    }

}
