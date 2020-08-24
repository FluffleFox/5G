using UnityEngine;
public class SwitchGameState : MonoBehaviour
{
    public GeneralGameMenager.gameState stateToSwitch;
    public void SwitchState()
    {
        GeneralGameMenager.instance.ChangeGameState(stateToSwitch);
    }
}