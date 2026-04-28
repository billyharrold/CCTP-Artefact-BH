using UnityEngine;

public class SetNextZone : MonoBehaviour
{
    public UIController uiController;

    public UITeachingZone uiSkillSets;

    private void Start()
    {
      
    }


    private void OnTriggerEnter(Collider other)
    {
        

        uiController.SetUIState(uiSkillSets);
    }
}
