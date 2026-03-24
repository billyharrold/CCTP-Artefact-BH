using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class DataEvaluator : MonoBehaviour
{
    // this is gonna recieve gameplay data like deaths etc, process it then send it to classifier to determine the skill level of the player.
    // uses scriptable objects to define rules for data weighting and classification.

   [SerializeField] private PlatformSkillRules DefaultskillModel;
   private PlatformSkillRules currentModel;

   private int rollingDeaths;
   private float rollingTime;


    private int deaths;
    private float elapsedTime;

    private float evalTimer;
    [SerializeField] private float interval = 5f;

    private float smoothing = 0.5f;
    private float smoothingEffect = 0.45f;



    private void Start()
    {
        currentModel = DefaultskillModel;
    }

    // spelt this function wrong - FIX
    public PlayerData EvaluatePlayerData(PlatformSkillRules skillModel)
    {
        Debug.Log($" Using Name: {skillModel.name}");
        float timedPerformance = 1f - Mathf.InverseLerp(skillModel.fastTime, skillModel.maxTime, rollingTime);

        float deathPerformance = 1f - Mathf.InverseLerp(0, skillModel.maxDeaths, rollingDeaths);

        float performanceScore = timedPerformance * skillModel.timeWeighting + deathPerformance * skillModel.deathWeighting;

        float smoothedScore = smoothingEffect * performanceScore + (1 - smoothingEffect) * smoothing;

        return SkillClassifier.EvaluateSkill(skillModel, smoothedScore);
    }


    public void ApplyNewSkillData()
    {
        PlatformSkillRules model;

        if (currentModel != null)
        {
            model = currentModel;
        }
        else
        {
            model = DefaultskillModel;
        }

        PlayerData newData = EvaluatePlayerData(model);
        PlayerManager.Instance.UpdatePlayerData(newData);
    }

    public void SetNewModel(PlatformSkillRules newModel)
    {
        if (newModel == null)
        {
            return;
        }

        currentModel = newModel;

        ResetRollingData();
        Debug.Log($"Updated to {newModel.name}");


    }

    private void Update()
    {
        rollingTime += Time.deltaTime;
        evalTimer += Time.deltaTime;

        if (evalTimer >= interval)
        {
            //Debug.Log("Eval occuring");
            ApplyNewSkillData();
            evalTimer = 0f;
        }
    }

    public void TrackDeath()
    {
        Debug.Log("DEAD");
        rollingDeaths++;
        ApplyNewSkillData();
        
    }

    public void ResetRollingData()
    {
        rollingDeaths = 0;
        rollingTime = 0f;
    }
}
