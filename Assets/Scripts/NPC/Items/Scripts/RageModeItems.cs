using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageModeItems : Item
{
    int itemIndex;
    private void Start()
    {
        GeneralGameMenager.instance.SwitchToNormal.AddListener(ResetChance);
        GeneralGameMenager.instance.SwitchToRage.AddListener(SetChance);
        GeneralGameMenager.instance.SwitchToRage.AddListener(ItemAction);
        GeneralGameMenager.instance.QuitingRage.AddListener(ResetChance);
        GeneralGameMenager.instance.QuitingRage.AddListener(RemoveItemEffect);
        ResetChance();
    }
    public override void ItemAction()
    {
        this.enabled = true;
        itemIndex = Random.Range(0, model.transform.childCount);
        model.transform.GetChild(itemIndex).gameObject.SetActive(true);
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().score += 1;
    }

    public override void LastFrameAction()
    {
        model.transform.GetChild(itemIndex).gameObject.SetActive(false);
    }

    void RemoveItemEffect()
    {
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().score = 0;
    }
}
