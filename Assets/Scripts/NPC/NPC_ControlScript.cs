using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ControlScript : MonoBehaviour
{
    public LayerMask mask;
    [HideInInspector]
    public bool rage;
    [HideInInspector]
    public float movementSpeed;
    [HideInInspector]
    public bool priorityToDestroy = false;

    [SerializeField] Movment movmentScript=null;
    [SerializeField] Hit hitScript=null;

    int index;
    public int score = 0;


    void Update()
    {
        foreach (Collider k in Physics.OverlapSphere(transform.position, 0.3f, mask))
        {
            k.transform.Translate((k.transform.position - transform.position).normalized * Time.deltaTime, Space.World);
        }
        movmentScript.movmentSpeed = movementSpeed;

        if (DeadRay.tower != null)
        {
            if (rage && Vector3.Distance(transform.position, DeadRay.tower.transform.position) < 0.75f)
            {
                DeadRay.tower.Burn();
                NPCDispository.Dispository.ResetAll();
                StopRageMode();
            }
        }
    }

    public void Prepare()
    {
        if (NPCDispository.Dispository.CanIRespawn(index))
        {
            priorityToDestroy = false;
            score = 0;
            foreach (Item k in GetComponentsInChildren<Item>())
            {
                if (UnityEngine.Random.Range(0, 100) < k.chance)
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
            movmentScript.MovmentPrepare();
        }
        else 
        {
            transform.position = new Vector3(4.75f, 0, UnityEngine.Random.Range(5.5f, 10.5f));
            gameObject.SetActive(false); 
        }
    }

    public void PrepareRageMode()
    {
        if (!rage)
        {
            rage = true;
            Destroy(movmentScript);
            gameObject.AddComponent<BasicEndGameMovement>();
            movmentScript = GetComponent<BasicEndGameMovement>();
            hitScript.SetRage(true);
            transform.rotation = Quaternion.LookRotation(transform.position - DeadRay.tower.transform.position);
            //Zmienić przedmioty pod rage
        }
    }

    public void StopRageMode()
    {
        if (rage)
        {
            rage = false;
            Destroy(movmentScript);
            gameObject.AddComponent<BasicMovment>();
            movmentScript = GetComponent<BasicMovment>();
            hitScript.SetRage(false);
        }
    }

    public void SetIndex(int value)
    {
        index = value;
    }

    public void SetMovementMethod(Type type)
    {
        Destroy(movmentScript);
        gameObject.AddComponent(type);
        movmentScript = GetComponent(type) as Movment;
    }

    public void GetScore()
    {
        if (priorityToDestroy)
        {
            ScoreCounter.counter.AddScore(score);
        }
        else if (!rage)
        {
            ScoreCounter.counter.LostHP();
        }
        else { ScoreCounter.counter.AddScore(score); }
    }
}
