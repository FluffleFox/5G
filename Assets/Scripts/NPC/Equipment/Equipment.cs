using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    protected List<GameObject>currentItems = new List<GameObject>();
    protected NPC_ControlScript control;
    protected GameObject[] rageModeItems;

    private void Awake()
    {
        control = GetComponent<NPC_ControlScript>();
    }

    public virtual void PrepareItem() 
    {
        for (int i = currentItems.Count - 1; i >= 0; i--)
        {
            if (currentItems[i].GetComponent<Item>() != null)
            { currentItems[i].GetComponent<Item>().LastFrameAction(); }
            Destroy(currentItems[i]);
        }
        currentItems.Clear();
    }
}
