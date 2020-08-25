public class CallPhone : Item
{
    private void Start()
    {
        GeneralGameMenager.instance.SwitchToNormal.AddListener(SetChance);
        GeneralGameMenager.instance.QuitingNormal.AddListener(ResetChance);
        GeneralGameMenager.instance.QuitingNormal.AddListener(Hide);
    }
    public override void ItemAction()
    {
        if (GeneralGameMenager.instance.currentGameState == GeneralGameMenager.gameState.Normal)
        {
            model.SetActive(true);
            transform.parent.gameObject.GetComponent<NPC_ControlScript>().AddScore(1);
        }
    }

    void Hide()
    {
        if (model.activeSelf)
        {
            transform.parent.gameObject.GetComponent<NPC_ControlScript>().AddScore(-1);
            model.SetActive(false);
        }
    }
}
