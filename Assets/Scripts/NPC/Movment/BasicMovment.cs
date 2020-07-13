﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovment : Movment
{
    Vector3 destination;

    private void Start()
    {
        destination = new Vector3(5.5f * Mathf.Sign(Random.Range(-1.0f, 1.0f)), 0.0f, Mathf.Sign(Random.Range(-1.0f, 1.0f)));
        movmentSpeed = Random.Range(0.8f, 2.0f);
        control.movementSpeed = movmentSpeed;
        transform.rotation = Quaternion.LookRotation(transform.position - destination);
    }
    protected override void Move()
    {
        transform.Translate((destination - transform.position).normalized * movmentSpeed * Time.deltaTime, Space.World);
    }

    public override void MovmentPrepare()
    {
        int dir = Mathf.RoundToInt(Mathf.Sign(Random.Range(-1.0f, 1.0f)));
        float Targetz = Mathf.Sign(Random.Range(-1.0f, 1.0f));
        float Startz = Random.Range(5.5f, 10.5f);
        transform.position = new Vector3((Startz+0.1f)* Mathf.Tan(Camera.main.fieldOfView * Mathf.Deg2Rad * 0.5f) * dir, 0.0f, Startz);
        destination = new Vector3(5.5f * (-dir), 0.0f, Targetz);
        movmentSpeed = Random.Range(0.8f, 2.0f);
        control.movementSpeed = movmentSpeed;
        transform.rotation = Quaternion.LookRotation(transform.position - destination);
    }

}
