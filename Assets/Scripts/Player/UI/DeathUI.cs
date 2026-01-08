using TMPro;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Deaths: " + PlayerManager.Instance.getDeathCount();
    }
}
