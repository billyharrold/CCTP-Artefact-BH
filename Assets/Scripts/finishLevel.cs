using UnityEngine;

public class finishLevel : MonoBehaviour
{
    [SerializeField] private DataEvaluator dataEvaluator;
    [SerializeField] private PlatformSkillRules sectionSkillRules;

    public UITeachingZone nextTeachingZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //dataEvaluator.EvaluatePlayerData(sectionSkillRules);
            dataEvaluator.SetNewModel(sectionSkillRules);
            Debug.Log("Level Finished!");
            SetNextTeachingState(nextTeachingZone);
            dataEvaluator.resetRollingData();
            //Debug.Log($"Updated to {sectionSkillRules.name}");
        }
    }

    private void SetNextTeachingState(UITeachingZone nextZone)
    {
        nextTeachingZone = nextZone;

        UIController.Instance.SetUIState(nextZone);
    }

}
