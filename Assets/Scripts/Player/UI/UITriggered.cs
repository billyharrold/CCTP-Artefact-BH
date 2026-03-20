using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UITriggered : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PopUpContent content;

    public GameObject popUpPanel;

    [SerializeField] private Image icon;

    void Awake()
    {
        popUpPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        popUpPanel.SetActive(true);
        icon.sprite = content.UIicon;
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().text = content.prompt;
    }

    private void OnTriggerExit(Collider other)
    {
        popUpPanel.SetActive(false);
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().text = "null";
    }

}
