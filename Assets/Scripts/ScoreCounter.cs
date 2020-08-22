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

    int multipler = 1;
    int nextMultipler = 1;
    float currentMultiplerValue;
    public Image multiplerFillZone;
    public Text multiplerText;


    private void Start()
    {
        counter = this;
        eta.SetActive(false);
    }


    public void AddScore(int scoreToAdd)
    {
        currentScore+=scoreToAdd*multipler;
        score.text = currentScore.ToString();

        currentMultiplerValue += 1;
        if (currentMultiplerValue > nextMultipler) 
        {
            multipler += 1;
            multiplerText.text = multipler.ToString();
            currentMultiplerValue -= nextMultipler;
        }
        multiplerFillZone.fillAmount = currentMultiplerValue / nextMultipler;

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
        if (hp >= 0)
        {
            hpText.text = hp.ToString();
        }

        if (hp == 0)
        {
            foreach(NPC_ControlScript karen in GameObject.FindObjectsOfType<NPC_ControlScript>())
            {
                karen.PrepareRageMode();
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
            if (evac <= 0.0f) 
            { 
                Debug.Log("Success!");
                Evacuation.instance.Evac();
            }
        }

        if (multipler > 1)
        {
            currentMultiplerValue -= Time.deltaTime * multipler*0.2f;
            if (currentMultiplerValue < 0.0f)
            {
                multipler -= 1;
                currentMultiplerValue += nextMultipler;
                multiplerText.text = multipler.ToString();
            }
        }
        else if (currentMultiplerValue > 0.0f)
        {
            currentMultiplerValue -= Time.deltaTime * multipler * 0.2f;
        }
        multiplerFillZone.fillAmount = currentMultiplerValue / nextMultipler;
        
    }

    public bool Rage()
    {
        if (hp <= 0) return true;
        else return false;
    }
}
