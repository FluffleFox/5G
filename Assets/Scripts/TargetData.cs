using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] rageModeItems;

    public TargetData(GameObject[] _items, GameObject[] _rageModeItems)
    {
        items = _rageModeItems;
        rageModeItems = _rageModeItems;
    }
}
