using UnityEngine;

public class finishLevel : MonoBehaviour
{
    [SerializeField] private DataEvaluator dataEvaluator;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dataEvaluator.EvaluatePlayerData();
            Debug.Log("Level Finished!");
        }
    }
}
