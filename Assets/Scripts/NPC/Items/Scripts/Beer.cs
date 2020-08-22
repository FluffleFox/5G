public class Beer : Item
{
    public override void ItemAction()
    {
        Invoke("Action", 0.5f);
    }

    void Action()
    {
        if (transform.parent!=null && transform.parent.GetComponent<NPC_ControlScript>() != null)
        { transform.parent.GetComponent<NPC_ControlScript>().SetMovementMethod(typeof(DrunkMovement)); }
    }
}
