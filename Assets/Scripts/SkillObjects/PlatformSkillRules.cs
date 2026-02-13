using System.IO.Enumeration;
using UnityEngine;


[CreateAssetMenu(
    fileName = "SkillRules",
    menuName = "Skill level model object")]
// need to rename class feel like its not very obvious.
public class PlatformSkillRules : ScriptableObject
{
    // All the weighting factors for deaths, time etc gonna go here.

    [Header("Skill Weights")]
    [Range(0.0f,1f)] public float deathWeighting = 0.7f;
    [Range(0.0f,1f)] public float timeWeighting = 0.3f;

    [Header("Deaths")] 
    public int maxDeaths = 10;

    [Header("Times")]
    // 60f per minute - max level time is 1 min rn.
    public float maxTime = 60f;
    public float fastTime = 20f;


    [Header("Skill Level Curves")]
    public AnimationCurve beginnerCurve;
    public AnimationCurve intermediateCurve;
    public AnimationCurve advancedCurve;

    [Header("Skill level thresholds")]
    [Range(0.0f, 1f)] public float beginnerThreshold = 0.4f;
    [Range(0.0f, 1f)] public float intermediateThreshold = 0.8f;




}
