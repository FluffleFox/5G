using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField]
    public GameObject[] normalModeItems;
    protected NPC_ControlScript control;
    [SerializeField]
    protected GameObject[] rageModeItems;

    private void Awake()
    {
        control = GetComponent<NPC_ControlScript>();
    }

    public virtual void PrepareItem()
    {

        for (int i = 0; i < normalModeItems.Length; i++)
        {
            normalModeItems[i].GetComponent<Item>().LastFrameAction();
            normalModeItems[i].SetActive(false);
        }
        for (int i = 0; i < rageModeItems.Length; i++)
        {
            //rageModeItems[i].GetComponent<Item>().LastFrameAction();
            rageModeItems[i].SetActive(false);
        }
    }
}
