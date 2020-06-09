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

    public GameObject eta;
    public Image evacBar;
    public float evacTime;
    float evac=0.0f;

    float cooldown;
    int reload = 0;

    private void Start()
    {
        counter = this;
        eta.SetActive(false);
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
            evac = evacTime;
            eta.SetActive(true);
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
            eta.SetActive(false);
        }
        if(DeadRay.tower != null) { cooldown = 2.5f; }
        else { cooldown -= Time.deltaTime; }

        if (Rage() && DeadRay.tower != null && evac>=0.0f)
        {
            evac -= Time.deltaTime;
            evacBar.fillAmount = evac / evacTime;
            if (evac <= 0.0f) Debug.Log("Success!");
        }
    }

    public bool Rage()
    {
        if (hp <= 0) return true;
        else return false;
    }
}
