using UnityEngine;
public class SwitchGameState : MonoBehaviour
{
    public GeneralGameMenager.gameState stateToSwitch;
    public void SwitchState()
    {
        Debug.Log("TAAAAAAAAP");
        GeneralGameMenager.instance.ChangeGameState(stateToSwitch);
    }
}