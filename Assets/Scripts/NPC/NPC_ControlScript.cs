﻿using System.Collections;
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

    [SerializeField] Movment movmentScript;
    [SerializeField] Hit hitScript;

    int index;

    int score = 1;
    bool bonus = false;
    bool nerf = false;

    void Start()
    {
        Prepare();
    }

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
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            movmentScript.MovmentPrepare();
            foreach(Equipment eq in GetComponents<Equipment>())
            {
                eq.PrepareItem();
            }
        }
        else { gameObject.SetActive(false); }
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

    public void SetMovementMethod(Movment method)
    {
        Destroy(movmentScript);
        gameObject.AddComponent(method.GetType());
        movmentScript = GetComponent(method.GetType()) as Movment;
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

    public void Effect()
    {
        Debug.Log("Smoething");
    }
}
