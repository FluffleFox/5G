using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (Mathf.Abs(transform.position.x)>5f)
        {
            if (control.priorityToDestroy)
            { ScoreCounter.counter.LostHP(); }
            control.Prepare();
        }
    }
    protected virtual void Move()
    {

    }

    public virtual void MovmentPrepare()
    {

    }

}
