using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEquipment : Equipment
{
    GameObject[] items;

    public override void PrepareItem()
    {
        base.PrepareItem();
        if (!control.rage)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (Random.Range(0, 100) < items[i].GetComponent<Item>().chance)
                {
                    currentItems.Add((GameObject)Instantiate(items[i], transform.position, Quaternion.identity));
                    currentItems[currentItems.Count - 1].transform.parent = transform;
                }
            }
        }
        else
        {
            currentItems.Add((GameObject)Instantiate(rageModeItems[Random.Range(0,rageModeItems.Length)], transform.position, Quaternion.identity));
            currentItems[currentItems.Count - 1].transform.parent = transform;
        }
    }

    public void Prepare(GameObject[] _items, GameObject[] _rageModeItems)
    {
        items = _items;
        rageModeItems = _rageModeItems;
    }

}
