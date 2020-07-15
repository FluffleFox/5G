using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEquipment : Equipment
{
    public override void PrepareItem()
    {
        base.PrepareItem();
        if (!control.rage)
        {
            for (int i = 0; i < normalModeItems.Length; i++)
            {
                if (Random.Range(0, 100) < normalModeItems[i].GetComponent<Item>().chance)
                {
                    normalModeItems[i].SetActive(true);
                }
            }
        }
        else
        {
            rageModeItems[Random.Range(0, rageModeItems.Length)].SetActive(true);
        }
    }
}
