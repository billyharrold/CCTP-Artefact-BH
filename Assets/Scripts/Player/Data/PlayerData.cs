using UnityEngine;

[System.Serializable]


public enum SkillLevel
{
    Beginner,     // 0.0
    Intermediate, // 0.65
    Advanced      // 1.0
}
public class PlayerData
{
    // Where all player data is stored related to skill classification.
    // Data here will be consumed by other scripts and systems to adjust UI delivery etc.


    public int deathCount;

    public SkillLevel playerLevel = SkillLevel.Beginner;

    public float skillScore;
    public float beginnerValue;
    public float intermediateValue;
    public float advancedValue;

    public float elapsedTime;

}
