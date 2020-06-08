using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter counter;
    public Text score;
    int currentScore = 0;
    int hp=3;
    public Text hpText;

    public GameObject tower;

    float cooldown;
    int reload = 0;

    private void Start()
    {
        counter = this;
    }

    public void AddScore()
    {
        currentScore++;
        score.text = currentScore.ToString();
        reload++;
        if (reload >= 10)
        {
            reload = 0;
            NPCDispository.Dispository.SetAnother();
        }
    }

    public void LostHP()
    {
        hp--;
        hpText.text = hp.ToString();
        if (hp <= 0)
        {
            foreach(KarenAI karen in GameObject.FindObjectsOfType<KarenAI>())
            {
                karen.Rage();
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && DeadRay.tower == null && cooldown<=0.0f)
        {
            currentScore = 0;
            hp = 3;
            tower.GetComponent<TowerAnimation>().Rebulid();
            tower.AddComponent<DeadRay>();
            score.text = currentScore.ToString();
            hpText.text = hp.ToString();
        }
        if(DeadRay.tower != null) { cooldown = 2.5f; }
        else { cooldown -= Time.deltaTime; }
    }
}
