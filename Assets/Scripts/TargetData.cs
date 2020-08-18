using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] rageModeItems;

    public TargetData(GameObject[] _items, GameObject[] _rageModeItems)
    {
        items = _items;
        rageModeItems = _rageModeItems;
    }

    public TargetData(TargetDataInString data)
    {
        items = new GameObject[data.items.Length];
        for(int i=0; i < data.items.Length; i++)
        {
            items[i] = (GameObject)Instantiate(Resources.Load(data.items[i], typeof(GameObject)) as GameObject);
            items[i].transform.parent = transform;
        }
        rageModeItems = new GameObject[data.rageItems.Length];
        for(int i=0; i<data.rageItems.Length; i++)
        {
            rageModeItems[i] = (GameObject)Instantiate(Resources.Load(data.rageItems[i], typeof(GameObject)) as GameObject);
            rageModeItems[i].transform.parent = transform;
        }
    }
}
