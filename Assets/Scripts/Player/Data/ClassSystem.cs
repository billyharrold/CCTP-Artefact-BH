using System;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

// Moving the stuff and logic here into better structured SkillClassifier class as this was a prototype system.
// Aiming to decouple all the UI stuff into its own class/system so scaling up will be a bit easier and cleaner.
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
    public TextMeshProUGUI skillOutputText;

    private float advancedValue = 0.0f;
    private float intermediateValue = 0.0f;
    private float beginnerValue = 0.0f;

    private const string labelText = "{0} true";

    private int deaths;

    public enum SkillLevel
    {
        Beginner,     // 0.0
        Intermediate, // 0.65
        Advanced      // 1.0
    }
    
    
    


    private void Start()
    {
        SetText();
    }

    public void UpdateSkillLevels(int deathCount)
    {
        // fuzzifying on death count vs graphing curves //
        //deaths = deathCount;



        //beginnerValue = (float)Math.Round(beginnerValue, 2);
        //intermediateValue = (float)Math.Round(intermediateValue, 2);
        //advancedValue = (float)Math.Round(advancedValue, 2);

        FuzzData(deathCount);
        SetText();
    }

    private void FuzzData(int deaths)
    {
        // moved
        beginnerValue = Mathf.Clamp01(beginnerCurve.Evaluate(deaths));
        intermediateValue = Mathf.Clamp01(intermediateCurve.Evaluate(deaths));
        advancedValue = Mathf.Clamp01(advancedCurve.Evaluate(deaths));
    }

    public float GetSkillScore()
    {
        // moved
        float numerator =
            (beginnerValue * 0.0f) +
            (intermediateValue * 0.65f) +
            (advancedValue * 1.0f);

        float denominator =
            beginnerValue +
            intermediateValue +
            advancedValue;

        if (denominator == 0)
        {
            return 0.0f;
        }

        return numerator / denominator;
    }

    public SkillLevel GetDominantSkillLevel()
    {
        float score = GetSkillScore();
        if (score < 0.45f)
        {
            return SkillLevel.Beginner;
        }
        else if (score < 0.85f)
        {
            return SkillLevel.Intermediate;
        }
        else
        {
            return SkillLevel.Advanced;
        }
    }


    void SetText()
    {
        // Rounding strictly for UI display purposes //
        beginnerText.text = string.Format(labelText, (float)Math.Round(beginnerValue, 3));
        intermediateText.text = string.Format(labelText, (float)Math.Round(intermediateValue, 3));
        advancedText.text = string.Format(labelText, (float)Math.Round(advancedValue, 3));


        SkillLevel level = GetDominantSkillLevel();
        skillOutputText.text = "Skill level: " + level.ToString();

    }
}
