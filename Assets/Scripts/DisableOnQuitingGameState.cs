using UnityEngine;
public class DisableOnQuitingGameState : MonoBehaviour
{
    public GeneralGameMenager.gameState quitingGameState;
    public GameObject gameObjectToDisable;
    void Start()
    {
        switch (quitingGameState)
        {
            case GeneralGameMenager.gameState.Normal: { GeneralGameMenager.instance.QuitingNormal.AddListener(DisableObject); break; }
            case GeneralGameMenager.gameState.Rage: { GeneralGameMenager.instance.QuitingRage.AddListener(DisableObject); break; }
            case GeneralGameMenager.gameState.Shop: { GeneralGameMenager.instance.QuitingShop.AddListener(DisableObject); break; }
        }
    }
    void DisableObject()
    {
        gameObjectToDisable.SetActive(false);
    }
}