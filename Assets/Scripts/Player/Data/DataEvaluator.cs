using UnityEngine;

public class DataEvaluator : MonoBehaviour
{
    // this is gonna recieve gameplay data like deaths etc, process it then send it to classifier to determine the skill level of the player.
    // uses scriptable objects to define rules for data weighting and classification.

    [SerializeField] private PlatformSkillRules skillModel;
    


    private int deaths;
    private float elapsedTime;

    // spelt this function wrong - FIX
    public PlayerData EvaluatePlayerData()
    {
        float timedPerformance = Mathf.InverseLerp(skillModel.fastTime, skillModel.maxTime, PlayerManager.Instance.GetElapsedTime());

        float deathPerformance = 1f - Mathf.InverseLerp(0, skillModel.maxDeaths, PlayerManager.Instance.GetDeathCount());

        float performanceScore = timedPerformance * skillModel.timeWeighting + deathPerformance * skillModel.deathWeighting;

        return SkillClassifier.EvaluateSkill(skillModel, performanceScore);
    }


    public void ApplyNewSkillData()
    {
        PlayerData newData = EvaluatePlayerData();
        PlayerManager.Instance.UpdatePlayerData(newData);
    }
}
