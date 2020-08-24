using UnityEngine;
public class DisableOnSwitchingGameState : MonoBehaviour
{
    public GeneralGameMenager.gameState gameState;
    public GameObject gameObjectToDisable;
    void Start()
    {
        switch (gameState)
        {
            case GeneralGameMenager.gameState.Normal: { GeneralGameMenager.instance.SwitchToNormal.AddListener(DisableObject); break; }
            case GeneralGameMenager.gameState.Rage: { GeneralGameMenager.instance.SwitchToRage.AddListener(DisableObject); break; }
            case GeneralGameMenager.gameState.Shop: { GeneralGameMenager.instance.SwitchToShop.AddListener(DisableObject); break; }
        }
    }
    void DisableObject()
    {
        gameObjectToDisable.SetActive(false);
    }
}
