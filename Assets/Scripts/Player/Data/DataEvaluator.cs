using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DataEvaluator : MonoBehaviour
{
    // this is gonna recieve gameplay data like deaths etc, process it then send it to classifier to determine the skill level of the player.
    // uses scriptable objects to define rules for data weighting and classification.

   [SerializeField] private PlatformSkillRules DefaultskillModel;

   private int rollingDeaths;
   private float rollingTime;


    private int deaths;
    private float elapsedTime;

    private float evalTimer;
    [SerializeField] private float interval = 5f;

    // spelt this function wrong - FIX
    public PlayerData EvaluatePlayerData(PlatformSkillRules skillModel)
    {
        float timedPerformance = Mathf.InverseLerp(skillModel.maxTime, skillModel.fastTime, rollingTime);

        float deathPerformance = 1f - Mathf.InverseLerp(0, skillModel.maxDeaths, rollingDeaths);

        float performanceScore = timedPerformance * skillModel.timeWeighting + deathPerformance * skillModel.deathWeighting;

        return SkillClassifier.EvaluateSkill(skillModel, performanceScore);
    }


    public void ApplyNewSkillData(PlatformSkillRules skillModel = null)
    {
        PlatformSkillRules model;
        if (skillModel != null)
        {
            model = skillModel;
        }
        else
        {
            model = DefaultskillModel;
        }


        PlayerData newData = EvaluatePlayerData(model);
        PlayerManager.Instance.UpdatePlayerData(newData);
    }


    private void Update()
    {
        rollingTime += Time.deltaTime;
        evalTimer += Time.deltaTime;

        if (evalTimer >= interval)
        {
            Debug.Log("Eval occuring");
            ApplyNewSkillData();
            evalTimer = 0f;
        }
    }

    public void TrackDeath()
    {
        rollingDeaths++;
        ApplyNewSkillData();
        
    }
}
