using System;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class ClassSystem : MonoBehaviour
{
    [Header("Skill Level Curve")] 
    public AnimationCurve beginnerCurve;
    public AnimationCurve intermediateCurve;
    public AnimationCurve advancedCurve;

    [Header("Skill Level Texts")]
    public TextMeshProUGUI beginnerText;
    public TextMeshProUGUI intermediateText;
    public TextMeshProUGUI advancedText;

    private float advancedValue = 0.0f;
    private float intermediateValue = 0.0f;
    private float beginnerValue = 0.0f;

    private const string labelText = "{0} true";

    private int deaths;

    private void Start()
    {
        SetText();
    }

    public void UpdateSkillLevels(int deathCount)
    {
        deaths = deathCount;

        beginnerValue = beginnerCurve.Evaluate(deaths);
        intermediateValue = intermediateCurve.Evaluate(deaths);
        advancedValue = advancedCurve.Evaluate(deaths);

        beginnerValue = (float)Math.Round(beginnerValue, 2);
        intermediateValue = (float)Math.Round(intermediateValue, 2);
        advancedValue = (float)Math.Round(advancedValue, 2);

        SetText();
    }




    void SetText()
    {
        beginnerText.text = string.Format(labelText, beginnerValue);
        intermediateText.text = string.Format(labelText, intermediateValue);
        advancedText.text = string.Format(labelText, advancedValue);

    }
}
