using UnityEngine;

[System.Serializable]


public enum SkillLevel
{
    Beginner,     // 0.0
    Intermediate, // 0.65
    Advanced      // 1.0
}
public struct PlayerData
{
    // Where all player data is stored related to skill classification.
    // Data here will be consumed by other scripts and systems to adjust UI delivery etc.


    public int deathCount;

    public SkillLevel playerLevel;

    public float skillScore;
    public float beginnerValue;
    public float intermediateValue;
    public float advancedValue;



}
