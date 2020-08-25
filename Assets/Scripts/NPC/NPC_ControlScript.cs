using UnityEngine;
public class NPC_ControlScript : MonoBehaviour
{
    public LayerMask mask;
    [HideInInspector]
    public float movementSpeed;

    int index;
    int score = 0;

    private void Start()
    {
        GeneralGameMenager.instance.SwitchToRage.AddListener(PrepareRageMode);
        if (GeneralGameMenager.instance.currentGameState == GeneralGameMenager.gameState.Rage) 
        {
            PrepareRageMode();
        }
        GeneralGameMenager.instance.QuitingRage.AddListener(StopRageMode);
    }


    void Update()
    {
        //Pseudo kolizje
        foreach (Collider k in Physics.OverlapSphere(transform.position, 0.3f, mask))
        {
            k.transform.Translate((k.transform.position - transform.position).normalized * Time.deltaTime, Space.World);
        }

        //Zniszczenie wieży
        if (DeadRay.tower != null)
        {
            if (Vector3.Distance(transform.position, DeadRay.tower.transform.position) < 0.75f && GeneralGameMenager.instance.currentGameState==GeneralGameMenager.gameState.Rage)
            {
                DeadRay.tower.Burn();
                GeneralGameMenager.instance.ChangeGameState(GeneralGameMenager.gameState.Summary);
            }
        }
    }

    public void Prepare()
    {
        if (NPCDispository.Dispository.CanIRespawn(index))
        {
            SetScore(0);
            GetComponent<ArmoredHit>().SetHP(1);
            foreach (Item k in GetComponentsInChildren<Item>())
            {
                k.LastFrameAction();
                if (Random.Range(0, 100) < k.chance)
                {
                    k.enabled = true;
                    k.ItemAction();
                }
                else
                {
                    k.enabled = false;
                }
            }
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), 1.0f);
            GetComponent<Movment>().MovmentPrepare();
        }
        else 
        {
            transform.position = new Vector3(4.75f, 0, Random.Range(5.5f, 10.5f));
            gameObject.SetActive(false); 
        }
    }

    public void PrepareRageMode()
    {
        Destroy(GetComponent<BasicMovment>());
        gameObject.AddComponent<BasicEndGameMovement>();
        transform.rotation = Quaternion.LookRotation(transform.position - DeadRay.tower.transform.position);
    }

    public void StopRageMode()
    {
        Destroy(GetComponent<BasicEndGameMovement>());
        gameObject.AddComponent<BasicMovment>();
    }

    public void SetIndex(int value)
    {
        index = value;
    }

    public void AddScore(int valueToAdd)
    {
        score += valueToAdd;
        if (score > 0)
        {
            GetComponent<AccurateLevel>().SetBigger();
        }
        else
        {
            GetComponent<AccurateLevel>().SetDefault();
        }
    }

    public void SetScore(int value)
    {
        score = value;
        if (score > 0)
        {
            GetComponent<AccurateLevel>().SetBigger();
        }
        else
        {
            GetComponent<AccurateLevel>().SetDefault();
        }
    }

    public void GetScore()
    {
        if (score == 0)
        {
            ScoreCounter.counter.LostHP();
        }
        else
        {
            ScoreCounter.counter.AddScore(score);
        }
        foreach(Item k in GetComponentsInChildren<Item>())
        {
            k.ItemHitAction();
        }
    }

    public int GetScoreValue()
    {
        return score;
    }
}
