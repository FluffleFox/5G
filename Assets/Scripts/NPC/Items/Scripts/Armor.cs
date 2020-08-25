public class Armor : Item
{
    void Start()
    {
        GeneralGameMenager.instance.SwitchToNormal.AddListener(SetChance);
        GeneralGameMenager.instance.SwitchToRage.AddListener(DivideChance);
        GeneralGameMenager.instance.QuitingRage.AddListener(ResetChance);
        ResetChance();
    }

    public override void ItemAction()
    {
        base.ItemAction();
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().AddScore(5);
        transform.parent.gameObject.GetComponent<ArmoredHit>().AddHP(2);
    }

    private void Update()
    {
        if (model.activeSelf)
        {
            model.transform.position = transform.parent.GetChild(0).GetChild(1).position;
        }
    }

    void DivideChance()
    {
        chance /= 2;
    }
}
