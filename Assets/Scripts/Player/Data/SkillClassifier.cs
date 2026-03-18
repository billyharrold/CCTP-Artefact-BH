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

        SkillLevel playerLevel;

        if (score < skillRules.beginnerThreshold)
        {
            playerLevel = SkillLevel.Beginner;
        }
        else if (score < skillRules.advancedThreshold)
        {
            playerLevel = SkillLevel.Intermediate;
        }
        else
        {
            playerLevel = SkillLevel.Advanced;
        }

        Debug.Log($"Skill Score: {score}, Player Level: {playerLevel}");

        // sends back data to player data.
        return new PlayerData
        {
            skillScore = score,
            playerLevel = playerLevel,
            beginnerValue = beginnerValue,
            intermediateValue = intermediateValue,
            advancedValue = advancedValue,
        };
    }


}
