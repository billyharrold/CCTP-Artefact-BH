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
            dataEvaluator.ApplyNewSkillData(sectionSkillRules);
            Debug.Log("Level Finished!");
            SetNextTeachingState(nextTeachingZone);
        }
    }

    private void SetNextTeachingState(UITeachingZone nextZone)
    {
        nextTeachingZone = nextZone;

        UIController.Instance.SetUIState(nextZone);
    }

}
