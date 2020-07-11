using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : Item
{
    void Start()
    {
        Invoke("Action", 0.5f);
    }

    void Action()
    {
        if (transform.parent!=null && transform.parent.GetComponent<NPC_ControlScript>() != null)
        { transform.parent.GetComponent<NPC_ControlScript>().SetMovementMethod(new DrunkMovement()); }
    }
}
