using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    //public ClassSystem classSystem;
    //public GameObject beginnerText;
    //public GameObject intermediateText;
    //public GameObject advancedText;

    
    public GameObject[] panels;

    
    [Header("UI Groups for different level sections")]
    public UISkillSets checkpointUI;


    private void OnEnable()
    {
        PlayerManager.Instance.OnPlayerDataUpdated += UpdatePanels;
    }

    private void OnDisable()
    {
        PlayerManager.Instance.OnPlayerDataUpdated -= UpdatePanels;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // set all panels hidden except first one
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        //panels[0].SetActive(true);

    }

    

    // Update is called once per frame


    private void UpdatePanels(PlayerData data)
    {
        
        switch (data.playerLevel)
        {
            case SkillLevel.Beginner:
                panels[0].SetActive(true);
                panels[1].SetActive(false);
                panels[2].SetActive(false);
                break;
            case SkillLevel.Intermediate:
                panels[0].SetActive(false);
                panels[1].SetActive(true);
                panels[2].SetActive(false);
                break;
            case SkillLevel.Advanced:
                panels[0].SetActive(false);
                panels[1].SetActive(false);
                panels[2].SetActive(true);
                break;
        }



        //switch (classSystem.GetDominantSkillLevel())
        //{
        //    case ClassSystem.SkillLevel.Beginner:
        //        panels[0].SetActive(true);
        //        panels[1].SetActive(false);
        //        panels[2].SetActive(false);
        //        break;
        //    case ClassSystem.SkillLevel.Intermediate:
        //        panels[0].SetActive(false);
        //        panels[1].SetActive(true);
        //        panels[2].SetActive(false);
        //        break;
        //    case ClassSystem.SkillLevel.Advanced:
        //        panels[0].SetActive(false);
        //        panels[1].SetActive(false);
        //        panels[2].SetActive(true);
        //        break;
        //}

    }


}
