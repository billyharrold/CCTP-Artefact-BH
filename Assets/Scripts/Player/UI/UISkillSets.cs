using UnityEngine;



public enum UISkillState
{
    Checkpoints,
    JumpingTeaching,
    MovingSpikes,
    MovingPlatforms,
    WorldSpaceUI,
    LevelCompletion

}

[System.Serializable]
public class UISkillSets
{
    [Header("UI Elements")]
    public GameObject beginnerUI;
    public GameObject intermediateUI;
    public GameObject advancedUI;


    public void ShowUI(SkillLevel level)
    {
        beginnerUI.SetActive(level == SkillLevel.Beginner);
        intermediateUI.SetActive(level == SkillLevel.Intermediate);
        advancedUI.SetActive(level == SkillLevel.Advanced);
    }

    public void HideAllUI()
    {
        beginnerUI.SetActive(false);
        intermediateUI.SetActive(false);
        advancedUI.SetActive(false);
    }


}
