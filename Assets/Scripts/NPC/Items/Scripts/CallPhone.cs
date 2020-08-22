using UnityEngine;

public class CallPhone : Item
{
    public override void ItemAction()
    {
        model.SetActive(true);
        GetComponentInParent<NPC_ControlScript>().priorityToDestroy = true;
        GetComponentInParent<NPC_ControlScript>().score += 1;
    }
}
