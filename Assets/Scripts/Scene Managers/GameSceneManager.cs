using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public static GameSceneManager Instance;

    private const string MenuName = "Menu";
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
        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateMouse(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMouse(scene.name);
    }

    private void UpdateMouse(string name)
    {
        if (name == MenuName)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
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

    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuName);
    }
}
