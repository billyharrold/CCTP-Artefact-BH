using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UITriggered : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PopUpContent content;

    public GameObject popUpPanel;

    [SerializeField] private Image icon;

    public bool keepActive;

    void Awake()
    {
        popUpPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        popUpPanel.SetActive(true);
        icon.sprite = content.UIicon;
        UpdateText();
    }

    private void UpdateText()
    {
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().text = content.prompt;
    }

    private void OnTriggerExit(Collider other)
    {
        popUpPanel.SetActive(false);
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().text = "null";

        if (keepActive)
        {
            UpdateText();
            popUpPanel.SetActive(true);
        }

    }

}
