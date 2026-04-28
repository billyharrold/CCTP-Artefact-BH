using UnityEngine;

public class DropShadow : MonoBehaviour
{
    // A quality of life script because it is a common feature in platformers, makes jumping easier.
   public GameObject shadowPrefab;

   public float maxDistance = 5;
   public float minScale = 0.3f;
   public float maxScale = 1f;

   public float minAlpha = 0.1f;
   public float maxAlpha = 0.8f;

   public LayerMask groundLayer;

   private Renderer renderer;

   void Start()
    {
        renderer = shadowPrefab.GetComponent<Renderer>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance, groundLayer))
        {
            // do position and rotation of ground underneath
            shadowPrefab.transform.position = hit.point + Vector3.up * 0.02f;
            //shadowPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            float ratio = hit.distance / maxDistance;

            float scale = Mathf.Lerp(maxScale, minScale, ratio);
            shadowPrefab.transform.localScale = new Vector3(scale, 0.6f, scale);


            shadowPrefab.SetActive(true);
        }
        else
        {
            shadowPrefab.SetActive(false);
        }
    }



}
