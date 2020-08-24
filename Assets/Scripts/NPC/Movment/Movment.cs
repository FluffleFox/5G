﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Movment : MonoBehaviour
{
    public float movmentSpeed;
    protected NPC_ControlScript control;
    protected float a;
    private void Awake()
    {
        control = GetComponent<NPC_ControlScript>();
        a = Mathf.Tan(Camera.main.fieldOfView * Mathf.Deg2Rad * 0.5f);
    }
    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {

    }

    public virtual void MovmentPrepare()
    {

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController")
        {
            control.Prepare();
        }
        if (other.tag== "HPCheeck")
        {
            if (control.score>0)
            {
                ScoreCounter.counter.LostHP();
            }
        }
    }

}
