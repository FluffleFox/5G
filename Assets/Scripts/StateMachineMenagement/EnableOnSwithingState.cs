
using UnityEngine;
public class EnableOnSwithingState : MonoBehaviour
{
    public GeneralGameMenager.gameState gameState;
    public GameObject gameObjectToEnable;
    void Start()
    {
        switch (gameState)
        {
            case GeneralGameMenager.gameState.Normal: { GeneralGameMenager.instance.SwitchToNormal.AddListener(EnableObject); break; }
            case GeneralGameMenager.gameState.Rage: { GeneralGameMenager.instance.SwitchToRage.AddListener(EnableObject); break; }
            case GeneralGameMenager.gameState.Shop: { GeneralGameMenager.instance.SwitchToShop.AddListener(EnableObject); break; }
            case GeneralGameMenager.gameState.Summary: { GeneralGameMenager.instance.SwitchToSummary.AddListener(EnableObject); break; }
            default: { Debug.LogError("Undefine state: " + gameState); break; }
        }
    }
    void EnableObject()
    {
        gameObjectToEnable.SetActive(true);
    }
}
