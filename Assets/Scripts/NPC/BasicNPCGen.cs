using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNPCGen : MonoBehaviour
{
    float[] chances;
    public void Start()
    {
        if (GeneralGameMenager.instance.chances == null)
        {
            Generate();
        }
        else
        {
            chances = SaveMenager.LoadTargetData(ref chances);
            GetComponent<NPCDispository>().SetNPCs(chances);
        }
    }
    void Generate()
    {
        Debug.Log("Generate");
        GameObject sample = GameObject.FindGameObjectWithTag("NPC");
        GameObject[] tempItemList = sample.GetComponent<Equipment>().normalModeItems;
        chances=new float[tempItemList.Length];
        for (int i=0; i<tempItemList.Length; i++)
        {
            float tmpMaxChance = tempItemList[i].GetComponent<Item>().GetMaxChance(1);//zamiast 1 powinien być aktualny poziom
            if (tmpMaxChance <= 0.5f) continue;
            chances[i]= Random.Range(0.0f, tmpMaxChance);
        }
        SaveMenager.SaveTargetData(chances);
        GeneralGameMenager.instance.chances = chances;
        GetComponent<NPCDispository>().SetNPCs(chances);
    }
}
