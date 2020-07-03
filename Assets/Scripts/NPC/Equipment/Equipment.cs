using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public List<GameObject> regularItems;
    public List<int> chaceForItem;
    public List<GameObject> endGameItems;
    protected NPC_ControlScript control;

    private void Awake()
    {
        control = GetComponent<NPC_ControlScript>();
    }

    public virtual void PrepareItem() { Destroy(control.item); }
}
