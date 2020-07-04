using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkMovement : Movment
{
    Vector3 destination;

    private void Start()
    {
        destination = new Vector3(-5.5f * Mathf.Sign(transform.forward.x), 0.0f, Random.Range(5.5f, 10.5f));
        movmentSpeed = Random.Range(0.8f, 1.2f);
        control.movementSpeed = movmentSpeed;
    }
    protected override void Move()
    {
        transform.Translate(((destination - transform.position).normalized+transform.right*Mathf.Sin(Time.realtimeSinceStartup*3.0f)).normalized * movmentSpeed * Time.deltaTime, Space.World);
    }

    public override void MovmentPrepare()
    {
        control.SetMovementMethod(new BasicMovment());
    }

}
