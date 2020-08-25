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
        model.SetActive(true);
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().AddScore(1);
        itemIndex = Random.Range(0, model.transform.childCount);
        model.transform.GetChild(itemIndex).gameObject.SetActive(true);
    }

    public override void LastFrameAction()
    {
        model.transform.GetChild(itemIndex).gameObject.SetActive(false);
    }

    void RemoveItemEffect()
    {
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().SetScore(0);
    }
}
