using UnityEngine;

public class Explosion : Item
{
    public LayerMask mask;
    bool canIExplode = false;

    void Start()
    {
        GeneralGameMenager.instance.SwitchToNormal.AddListener(SetChance);
        GeneralGameMenager.instance.QuitingRage.AddListener(ResetChance);
        ResetChance();
        canIExplode = false;
    }

    public override void ItemAction()
    {
        base.ItemAction();
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().AddScore(10);
        canIExplode = false;
    }

    private void Update()
    {
        if (model.activeSelf)
        {
            model.transform.position = transform.parent.GetChild(0).GetChild(1).position;
        }
    }

    public override void ItemHitAction()
    {
        base.ItemHitAction();
        if (model.activeSelf && canIExplode)
        {
            foreach (Collider k in Physics.OverlapSphere(transform.position, 2.5f, mask))
            {
                k.gameObject.GetComponent<NPC_ControlScript>().AddScore(1);
                k.gameObject.GetComponent<Hit>().GetHit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "HPCheeck")
        {
            canIExplode = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "HPCheeck")
        {
            canIExplode = false;
        }
    }
}
