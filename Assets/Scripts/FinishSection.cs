using UnityEngine;

// similar to finish level but this caters to more dynamic system
// this will reset timer, and apply new skill level and next skill model for eval.
public class FinishSection : MonoBehaviour
{

    [SerializeField] private DataEvaluator dataEvaluator;
    //[SerializeField] private PlatformSkillRules sectionSkillRules;

    public UITeachingZone nextTeachingZone;


    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            dataEvaluator.resetRollingData();
            SetNextTeachingState(nextTeachingZone);
            Debug.Log(nextTeachingZone);
        }
       
    }



    private void SetNextTeachingState(UITeachingZone nextZone)
    {
        nextTeachingZone = nextZone;

        UIController.Instance.SetUIState(nextZone);
    }


}
