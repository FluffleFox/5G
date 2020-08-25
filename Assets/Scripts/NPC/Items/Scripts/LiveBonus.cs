public class LiveBonus : Item
{
    private void Start()
    {
        GeneralGameMenager.instance.SwitchToNormal.AddListener(SetChance);
        GeneralGameMenager.instance.SwitchToRage.AddListener(ResetChance);
        GeneralGameMenager.instance.QuitingRage.AddListener(RemoveItemEffect);
    }
    public override void ItemAction()
    {
        if (ScoreCounter.counter.GetCurrentHP()<3)
        {
            model.SetActive(true);
            transform.parent.gameObject.GetComponent<NPC_ControlScript>().AddScore(1);
        }
        else
        {
            model.SetActive(false);
        }
    }
    public override void ItemHitAction()
    {
        if (model.activeSelf && GeneralGameMenager.instance.currentGameState == GeneralGameMenager.gameState.Normal)
        { 
            if (ScoreCounter.counter.GetCurrentHP() < 3) 
            { 
                ScoreCounter.counter.AddHP(); 
            }
            else
            {
                ScoreCounter.counter.AddScore(4);
            }
        }
    }


    void RemoveItemEffect()
    {
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().SetScore(0);
    }
}
