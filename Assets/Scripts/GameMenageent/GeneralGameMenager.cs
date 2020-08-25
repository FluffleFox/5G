using UnityEngine;
using UnityEngine.Events;

public class GeneralGameMenager : MonoBehaviour
{   
    public enum gameState { Normal, Rage, Shop, Summary};
    public gameState currentGameState = gameState.Shop;

    public static GeneralGameMenager instance;
    public PlayerData data;

    public UnityEvent SwitchToNormal;
    public UnityEvent QuitingNormal;
    public UnityEvent SwitchToRage;
    public UnityEvent QuitingRage;
    public UnityEvent SwitchToShop;
    public UnityEvent QuitingShop;
    public UnityEvent SwitchToSummary;
    public UnityEvent QuitingSummary;



    void Awake()
    {
        if (instance != null) { Destroy(gameObject); }
        else { instance = this; }
        data = SaveMenager.Load();
        SwitchToShop.Invoke();
        SwitchToNormal.AddListener(LoadData);
    }

    public void ChangeGameState(gameState _newState)
    {
        switch (currentGameState)
        {
            case gameState.Normal: { QuitingNormal.Invoke(); break; }
            case gameState.Rage: { QuitingRage.Invoke(); break; }
            case gameState.Shop: { QuitingShop.Invoke(); break; }
            case gameState.Summary: { QuitingSummary.Invoke(); break; }
        }
        currentGameState = _newState;
        switch (currentGameState)
        {
            case gameState.Normal: { SwitchToNormal.Invoke(); break; }
            case gameState.Rage: { SwitchToRage.Invoke(); break; }
            case gameState.Shop: { SwitchToShop.Invoke(); break; }
            case gameState.Summary: { SwitchToSummary.Invoke(); break; }
        }
    }

    void LoadData()
    {
        data = SaveMenager.Load();
    }
}
