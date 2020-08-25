using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter counter;
    public Text score;
    int currentScore = 0;
    int hp=3;
    public Image[] hpDisplay;

    int reload = 0;

    private void Start()
    {
        counter = this;
        GeneralGameMenager.instance.SwitchToNormal.AddListener(ResetScore);
    }


    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        score.text = currentScore.ToString();

        reload++;
        if (reload >= 10)
        {
            reload = 0;
            NPCDispository.Dispository.SetAnother();
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void LostHP()
    {
        if (hp > 0)
        {
            hpDisplay[hp].enabled = false;
            hp--;
            if (hp == 0)
            {
                GeneralGameMenager.instance.ChangeGameState(GeneralGameMenager.gameState.Rage);
            }
        }
    }

    public void AddHP()
    {
        if (hp < 3)
        {
            hp++;
            hpDisplay[hp].enabled = true;
        }
    }

    public int GetCurrentHP()
    {
        return hp;
    }

    private void ResetScore()
    {
        currentScore = 0;
        hp = 3;
        for(int i=0; i < hpDisplay.Length; i++)
        {
            hpDisplay[i].enabled = true;
        }
        score.text = currentScore.ToString();
    }
}
