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
            transform.parent.gameObject.GetComponent<NPC_ControlScript>().score += 1;
        }
        else
        {
            model.SetActive(false);
            this.enabled = false;
        }
    }
    public override void ItemHitAction()
    {
        if (this.enabled && GeneralGameMenager.instance.currentGameState == GeneralGameMenager.gameState.Normal)
        { 
            if (ScoreCounter.counter.GetCurrentHP() < 3) 
            { 
                ScoreCounter.counter.AddHP(); 
            }
            else
            {
                ScoreCounter.counter.AddScore(49);
            }
        }
    }


    void RemoveItemEffect()
    {
        transform.parent.gameObject.GetComponent<NPC_ControlScript>().score = 0;
    }
}
