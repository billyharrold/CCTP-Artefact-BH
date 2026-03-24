using System.Collections;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    //public ClassSystem classSystem;
    //public GameObject beginnerText;
    //public GameObject intermediateText;
    //public GameObject advancedText;

    // from original version where it was only 3 panels, one for each skill level.
    //public GameObject[] panels;


    public static UIController Instance;

    [Header("UI Groups for different level sections")]
    public UISkillSets introUI;
    public UISkillSets goalUI;
    public UISkillSets checkpointUI;
    public UISkillSets jumpingTeachingUI;
    public UISkillSets movingSpikesUI;
    public UISkillSets movingPlatformsUI;


    public UITeachingZone skillState;
    
    private SkillLevel currentSkillLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    private void OnEnable()
    {
        PlayerManager.Instance.OnPlayerDataUpdated += UpdateSkillLevel;
    }

    private void OnDisable()
    {
        PlayerManager.Instance.OnPlayerDataUpdated -= UpdateSkillLevel;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentSkillLevel = PlayerManager.Instance.GetSkillLevel();

       SetUIState(UITeachingZone.Intro);

        //checkpointUI.HideAllUI();
        //jumpingTeachingUI.HideAllUI();
        //movingSpikesUI.HideAllUI();

        // set all panels hidden except first one
        //foreach (var panel in panels)
        //{
        //    panel.SetActive(false);
        //}

        //panels[0].SetActive(true);

    }

    // going to use this to set state - making a trigger object so it triggers when players enter certain section.
    // e.g dying, entering section where being taught about jumping.


    public void UpdateSkillLevel(PlayerData data)
    {
        currentSkillLevel = data.playerLevel;
        UpdatePanels();
    }

    public void SetUIState(UITeachingZone state)
    {
        skillState = state;
        UpdatePanels();
    }

    

    public void UpdatePanels()
    {
        introUI.HideAllUI();
        goalUI.HideAllUI();
        checkpointUI.HideAllUI();
        jumpingTeachingUI.HideAllUI();
        movingSpikesUI.HideAllUI();
        movingPlatformsUI.HideAllUI();

        switch (skillState)
        {
            case UITeachingZone.Intro:
                introUI.ShowUI(currentSkillLevel);
                goalUI.ShowUI(currentSkillLevel);
                break;
            case UITeachingZone.Checkpoints:
                checkpointUI.ShowUI(currentSkillLevel);
                goalUI.ShowUI(currentSkillLevel);
                break;
            case UITeachingZone.JumpingTeaching:
                jumpingTeachingUI.ShowUI(currentSkillLevel);
                goalUI.ShowUI(currentSkillLevel);
                
                break;
            case UITeachingZone.MovingSpikes:
                movingSpikesUI.ShowUI(currentSkillLevel);
                goalUI.ShowUI(currentSkillLevel);
                break;
            case UITeachingZone.MovingPlatforms:
                goalUI.ShowUI(currentSkillLevel);
                movingPlatformsUI.ShowUI(currentSkillLevel);
                break;
        }

       
      
    }

    // Update is called once per frame


    //private void UpdatePanels(PlayerData data)
    //{
        
    //    switch (data.playerLevel)
    //    {
    //        case SkillLevel.Beginner:
    //            panels[0].SetActive(true);
    //            panels[1].SetActive(false);
    //            panels[2].SetActive(false);
    //            break;
    //        case SkillLevel.Intermediate:
    //            panels[0].SetActive(false);
    //            panels[1].SetActive(true);
    //            panels[2].SetActive(false);
    //            break;
    //        case SkillLevel.Advanced:
    //            panels[0].SetActive(false);
    //            panels[1].SetActive(false);
    //            panels[2].SetActive(true);
    //            break;
    //    }



    //    //switch (classSystem.GetDominantSkillLevel())
    //    //{
    //    //    case ClassSystem.SkillLevel.Beginner:
    //    //        panels[0].SetActive(true);
    //    //        panels[1].SetActive(false);
    //    //        panels[2].SetActive(false);
    //    //        break;
    //    //    case ClassSystem.SkillLevel.Intermediate:
    //    //        panels[0].SetActive(false);
    //    //        panels[1].SetActive(true);
    //    //        panels[2].SetActive(false);
    //    //        break;
    //    //    case ClassSystem.SkillLevel.Advanced:
    //    //        panels[0].SetActive(false);
    //    //        panels[1].SetActive(false);
    //    //        panels[2].SetActive(true);
    //    //        break;
    //    //}

    //}


}
