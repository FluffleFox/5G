using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneralGameMenager : MonoBehaviour
{
    public static GeneralGameMenager instance;
    public PlayerData data;

    public UnityEvent SwitchToNormal;
    public UnityEvent QuitingNormal;
    public UnityEvent SwitchToRage;
    public UnityEvent QuitingRage;
    public UnityEvent SwitchToShop;
    public UnityEvent QuitingShop;

    public enum gameState { Normal, Rage, Shop};
    public gameState currentGameState = gameState.Shop;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); }
        else { instance = this; }
        data = SaveMenager.Load();
        SwitchToShop.Invoke();
    }

    public void ChangeGameState(gameState _newState)
    {
        switch (currentGameState)
        {
            case gameState.Normal: { QuitingNormal.Invoke(); break; }
            case gameState.Rage: { QuitingRage.Invoke(); break; }
            case gameState.Shop: { QuitingShop.Invoke(); break; }
        }
        currentGameState = _newState;
        switch (currentGameState)
        {
            case gameState.Normal: { SwitchToNormal.Invoke(); break; }
            case gameState.Rage: { SwitchToRage.Invoke(); break; }
            case gameState.Shop: { SwitchToShop.Invoke(); break; }
        }
    }
}
