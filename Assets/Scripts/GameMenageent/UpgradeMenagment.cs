using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenagment : MonoBehaviour
{
    //public Text levelText;
    //public Text armorLevelText;
    //public Text armorUpgradeButonText;
    public Text forceLevelText;
    public Text forceUpgradeButonText;
    public Text accurateLevelText;
    public Text accurateUpgradeButonText;
    public Text moneyText;

    int money;
    int armorUpgradeCost;
    int forceUpgradeCost;
    int accurateUpgradeCost;

    int level;
    int experience;
    int armorLevel;
    int forceLevel;
    int accurateLevel;


    private void Start()
    {
        GeneralGameMenager.instance.SwitchToShop.AddListener(Prepare);
        Prepare();
    }

    void Prepare()
    {
        PlayerData data = GeneralGameMenager.instance.data;
        money = data.money;
        moneyText.text = data.money.ToString();
        level = data.level;
        experience = data.experience;
        //levelText.text = data.level.ToString();

        // armorLevelText.text = data.armorLevel.ToString();
        armorLevel = data.armorLevel;
        armorUpgradeCost = data.armorLevel * 100;

        forceLevelText.text = "Force lvl " + data.forceLevel.ToString();
        forceLevel = data.forceLevel;
        forceUpgradeCost = data.forceLevel * 100;
        forceUpgradeButonText.text = "Upgrade\n" + forceUpgradeCost.ToString();

        accurateLevelText.text = "Accurate lvl " + data.accurateLevel.ToString();
        accurateLevel = data.accurateLevel;
        accurateUpgradeCost = data.accurateLevel * 100;
        accurateUpgradeButonText.text = "Upgrade\n" + accurateUpgradeCost.ToString();
    }

    public void Ready()
    {
        GeneralGameMenager.instance.ChangeGameState(GeneralGameMenager.gameState.Normal);
    }

    
    public void UpgradeAccurate()
    {
        if (money >= accurateUpgradeCost)
        {
            money -= accurateUpgradeCost;
            accurateLevel++;
            accurateLevelText.text = accurateLevel.ToString();
            accurateLevelText.text = "Accurate lvl " + accurateLevel.ToString();
            moneyText.text = money.ToString();
            accurateUpgradeCost = accurateLevel * 100;
            accurateUpgradeButonText.text = "Upgrade\n" + accurateUpgradeCost.ToString();
            SaveMenager.Save(new PlayerData(level, experience, money, armorLevel, forceLevel, accurateLevel));
        }
    }

   /* public void UpgradeArmor()
    {
        if (money >= armorUpgradeCost)
        {
            money -= armorUpgradeCost;
            armorLevel++;
            //armorLevelText.text = armorLevel.ToString();
            moneyText.text = money.ToString();
            armorUpgradeCost = armorLevel * 100;
            SaveMenager.Save(new PlayerData(level, money, armorLevel, forceLevel, accurateLevel));
        }
    }*/

    public void UpgradeForce()
    {
        if (money >= forceUpgradeCost)
        {
            money -= forceUpgradeCost;
            forceLevel++;
            forceLevelText.text = "Force lvl "+forceLevel.ToString();
            moneyText.text = money.ToString();
            forceUpgradeCost = forceLevel * 100;
            forceUpgradeButonText.text = "Upgrade\n" + forceUpgradeCost.ToString();
            SaveMenager.Save(new PlayerData(level, experience, money, armorLevel, forceLevel, accurateLevel));
        }
    }

}
