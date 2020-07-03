using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    protected bool rage;
    protected NPC_ControlScript control;

    private void Start()
    {
        control = GetComponent<NPC_ControlScript>();
    }
    public virtual void GetHit()
    {

    }

    public void SetRage(bool value)
    {
        rage = value;
    }
}
