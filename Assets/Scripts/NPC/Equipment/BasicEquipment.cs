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
            int total = 0;
            foreach(int k in chaceForItem)
            {
                total += k;
            }
            int rand = Random.Range(0, total);
            int i = 0;
            int curr = 0;
            do
            {
                curr += chaceForItem[i];
                i++;
            } while (curr < rand);
            GameObject GO = (GameObject)Instantiate(regularItems[i-1], transform.position, transform.rotation);
            GO.transform.parent = transform;
            control.item = GO;
        }
        else
        {
            GameObject GO = (GameObject)Instantiate(endGameItems[Random.Range(0,endGameItems.Count)], transform.position, transform.rotation);
            GO.transform.parent = transform;
            control.item = GO;
        }
    }
}
