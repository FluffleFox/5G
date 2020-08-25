using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    public Text score;
    public Text money;
    public Text currentLevel;
    public Text nextLevel;
    public Image levelProgressBar;
    private void Start()
    {
        GeneralGameMenager.instance.SwitchToSummary.AddListener(DisplayResult);
        DisplayResult();
    }

    void DisplayResult()
    {
        score.text = ScoreCounter.counter.GetScore().ToString();
        int moneyToAdd = ScoreCounter.counter.GetScore() / 10;
        money.text = moneyToAdd.ToString();
        int experienceToAdd = ScoreCounter.counter.GetScore() / 20;
        PlayerData data = GeneralGameMenager.instance.data;
        currentLevel.text = data.level.ToString();
        nextLevel.text = (data.level + 1).ToString();
        float progress=(float)(data.experience + experienceToAdd) / (float)(data.level * 10);
        levelProgressBar.fillAmount = progress;
        int levelToAdd = (progress >= 1.0f) ? 1 : 0;
        int experience = data.experience + experienceToAdd - (levelToAdd * data.level * 10);

        SaveMenager.Save(new PlayerData(data.level + levelToAdd, experience, data.money + moneyToAdd, data.armorLevel, data.forceLevel, data.accurateLevel));
    }
}
