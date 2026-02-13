using UnityEngine;

public static class SkillClassifier
{
    public static PlayerData EvaluateSkill(PlatformSkillRules skillRules, float performanceScore)
    {

        // fuzzifying the data based on curves from skill rules.
        float beginnerValue = Mathf.Clamp01(skillRules.beginnerCurve.Evaluate(performanceScore));
        float intermediateValue = Mathf.Clamp01(skillRules.intermediateCurve.Evaluate(performanceScore));
        float advancedValue = Mathf.Clamp01(skillRules.advancedCurve.Evaluate(performanceScore));

        float numerator =
            (beginnerValue * 0.0f) +
            (intermediateValue * 0.65f) +
            (advancedValue * 1.0f);

        float denominator =
            beginnerValue +
            intermediateValue +
            advancedValue;



        float score;
        if (denominator == 0)
        {
            score = 0.0f;
        }
        else
        {
            score = numerator / denominator;
        }  

        // sends back data to player data.
        return new PlayerData
        {

        };
    }


}
