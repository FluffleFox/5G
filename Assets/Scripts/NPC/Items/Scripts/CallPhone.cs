using UnityEngine;

public class CallPhone : Item
{
    public override void ItemAction()
    {
        model.SetActive(false);
        if (DeadRay.tower!=null)
        {
            float speed = transform.parent.forward.x * GetComponentInParent<NPC_ControlScript>().movementSpeed;
            float time = Random.Range(0.0f, Mathf.Abs(transform.parent.position.x / speed));
            Invoke("Activate", time);
        }
    }

    void Activate()
    {
        model.SetActive(true);
        GetComponentInParent<NPC_ControlScript>().priorityToDestroy = true;
        GetComponentInParent<NPC_ControlScript>().score += 1;
    }
}
