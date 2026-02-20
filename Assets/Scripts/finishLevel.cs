using UnityEngine;

public class finishLevel : MonoBehaviour
{
    [SerializeField] private DataEvaluator dataEvaluator;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dataEvaluator.EvaulatePlayerData();
            Debug.Log("Level Finished!");
        }
    }
}
