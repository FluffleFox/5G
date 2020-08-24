using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenagment : MonoBehaviour
{
    public Text levelText;
    public Text armorLevelText;
    public Text forceLevelText;
    public Text accurateLevelText;
    public Text moneyText;

    int money;
    int armorUpgradeCost;
    int forceUpgradeCost;
    int accurateUpgradeCost;

    int level;
    int armorLevel;
    int forceLevel;
    int accurateLevel;


    bool ready = false;

    private void Start()
    {
        PlayerData data = GeneralGameMenager.instance.data;
        money = data.money;
        moneyText.text = data.money.ToString();
        level = data.level;
        levelText.text = data.level.ToString();

        armorLevelText.text = data.armorLevel.ToString();
        armorLevel = data.armorLevel;
        armorUpgradeCost = data.armorLevel * 100;

        forceLevelText.text = data.accurateLevel.ToString();
        forceLevel = data.accurateLevel;
        forceUpgradeCost = data.accurateLevel * 100;

        accurateLevelText.text = data.heliLevel.ToString();
        accurateLevel = data.heliLevel;
        accurateUpgradeCost = data.heliLevel * 100;
        SaveMenager.Save(new PlayerData(level, money, armorLevel, accurateLevel, forceLevel));
    }

   public void Ready()
   {
        if (!ready)
        {
            ready = true;
            GeneralGameMenager.instance.ChangeGameState(GeneralGameMenager.gameState.Normal);
        }
   }

    
    public void UpgradeAccurate()
    {
        if (money >= accurateUpgradeCost)
        {
            money -= accurateUpgradeCost;
            accurateLevel++;
            accurateLevelText.text = accurateLevel.ToString();
            moneyText.text = money.ToString();
            accurateUpgradeCost = accurateLevel * 100;
            SaveMenager.Save(new PlayerData(level, money, armorLevel, accurateLevel, forceLevel));
        }
    }

    public void UpgradeArmor()
    {
        if (money >= armorUpgradeCost)
        {
            money -= armorUpgradeCost;
            armorLevel++;
            armorLevelText.text = armorLevel.ToString();
            moneyText.text = money.ToString();
            armorUpgradeCost = armorLevel * 100;
            SaveMenager.Save(new PlayerData(level, money, armorLevel, accurateLevel, forceLevel));
        }
    }

    public void UpgradeForce()
    {
        if (money >= forceUpgradeCost)
        {
            money -= forceUpgradeCost;
            forceLevel++;
            forceLevelText.text = forceLevel.ToString();
            moneyText.text = money.ToString();
            forceUpgradeCost = forceLevel * 100;
            SaveMenager.Save(new PlayerData(level, money, armorLevel, accurateLevel, forceLevel));
        }
    }

}
