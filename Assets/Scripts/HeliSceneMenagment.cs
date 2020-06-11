using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeliSceneMenagment : MonoBehaviour
{
    public Transform[] moveOnDropObject;
    public float[] moveOnDropSpeed;
    public int dropTime = 30;
    float dropSpeed = 0.01f;
    bool ready = false;

    public Text levelText;
    public Text armorLevelText;
    public Text forceLevelText;
    public Text heliLevelText;
    public Text moneyText;

    int money;
    int armorUpgradeCost;
    int forceUpgradeCost;
    int heliUpgradeCost;

    int level;
    int armorLevel;
    int forceLevel;
    int heliLevel;


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

        heliLevelText.text = data.heliLevel.ToString();
        heliLevel = data.heliLevel;
        heliUpgradeCost = data.heliLevel * 100;
        SaveMenager.Save(new PlayerData(level, money, armorLevel, heliLevel, forceLevel, 2));
    }

    public void Ready()
   {
        if (!ready)
        {
            SaveMenager.Save(new PlayerData(level, money, armorLevel, heliLevel, forceLevel, 1));
            ready = true;
            StartCoroutine(Drop()); 
        }
   }

    IEnumerator Drop()
    {
        for(int i=0; i<dropTime; i++)
        {
            for(int j=0; j<moveOnDropObject.Length; j++)
            {
                moveOnDropObject[j].transform.position += Vector3.up * i * 9.81f * dropSpeed * moveOnDropSpeed[j];
                yield return new WaitForSecondsRealtime(dropSpeed);
            }
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void UpgradeHeli()
    {
        if (money >= heliUpgradeCost)
        {
            money -= heliUpgradeCost;
            heliLevel++;
            heliLevelText.text = heliLevel.ToString();
            moneyText.text = money.ToString();
            heliUpgradeCost = heliLevel * 100;
            SaveMenager.Save(new PlayerData(level, money, armorLevel, heliLevel, forceLevel, 1));
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
            SaveMenager.Save(new PlayerData(level, money, armorLevel, heliLevel, forceLevel, 1));
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
            SaveMenager.Save(new PlayerData(level, money, armorLevel, heliLevel, forceLevel, 1));
        }
    }

}
