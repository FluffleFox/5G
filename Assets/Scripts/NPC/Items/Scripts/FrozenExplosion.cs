using UnityEngine;

public class FrozenExplosion : Item
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
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().AddScore(5);
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
                k.transform.Find("FrozenEffect").GetComponent<FrozenEffect>().ItemAction();
            }
            model.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HPCheeck")
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

    public override void LastFrameAction()
    {
        base.LastFrameAction();
    }
}