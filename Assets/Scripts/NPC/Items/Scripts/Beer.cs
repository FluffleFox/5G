using UnityEngine;

public class Beer : Item
{
    private void Start()
    {
        GeneralGameMenager.instance.SwitchToNormal.AddListener(SetChance);
        GeneralGameMenager.instance.SwitchToRage.AddListener(ResetChance);
        GeneralGameMenager.instance.SwitchToRage.AddListener(Hide);
        if (GeneralGameMenager.instance.currentGameState == GeneralGameMenager.gameState.Rage)
        {
            ResetChance();
            Hide();
        }
    }

    private void Update()
    {
        if (model.activeSelf)
        { 
            transform.parent.Translate(transform.parent.right * Mathf.Sin(Time.realtimeSinceStartup) * Time.deltaTime * 0.5f, Space.World); 
        }
    }

    void Hide()
    {
        model.SetActive(false);
    }
}
