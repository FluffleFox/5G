using UnityEngine;
public class EnableOnQuitingGameState : MonoBehaviour
{
    public GeneralGameMenager.gameState quitingGameState;
    public GameObject gameObjectToEnable;
    void Start()
    {
        switch (quitingGameState)
        {
            case GeneralGameMenager.gameState.Normal: { GeneralGameMenager.instance.QuitingNormal.AddListener(EnableObject); break; }
            case GeneralGameMenager.gameState.Rage: { GeneralGameMenager.instance.QuitingRage.AddListener(EnableObject); break; }
            case GeneralGameMenager.gameState.Shop: { GeneralGameMenager.instance.QuitingShop.AddListener(EnableObject); break; }
        }
    }
    void EnableObject()
    {
        gameObjectToEnable.SetActive(true);
    }
}
