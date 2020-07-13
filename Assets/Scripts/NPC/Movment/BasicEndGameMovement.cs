using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEndGameMovement : Movment
{
    Vector3 destination;
    float baseSpeed;
    private void Start()
    {
        baseSpeed = Random.Range(0.8f, 1.2f);
        destination = DeadRay.tower.transform.position;
        destination.y = 0.0f;
        transform.rotation = Quaternion.LookRotation(transform.position - destination);
    }
    protected override void Move()
    {
        transform.Translate((destination - transform.position).normalized * movmentSpeed * Time.deltaTime, Space.World);
        if(baseSpeed<=0.5f || movmentSpeed <= 0.5f)
        {
            movmentSpeed = Random.Range(0.8f, 1.2f);
            control.movementSpeed = movmentSpeed;
            baseSpeed = movmentSpeed;
        }
    }

    public override void MovmentPrepare()
    {
        if (DeadRay.tower != null)
        {
            float angle = Random.Range(-90.0f, 90.0f) * Mathf.Deg2Rad;
            transform.position = new Vector3(Mathf.Sin(angle) * 4.5f, 0.0f, -Mathf.Cos(angle) * 4.5f + 6.0f);
            destination = DeadRay.tower.transform.position;
            destination.y = 0.0f;
            movmentSpeed = baseSpeed + Random.Range(0.8f, 1.2f);
            control.movementSpeed = movmentSpeed;
            baseSpeed = movmentSpeed;
            transform.rotation = Quaternion.LookRotation(transform.position - destination);
        }
        else
        {
            control.StopRageMode();
        }
    }
}
