using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    void Start()
    {
        Invoke("Action", 0.5f);
    }

    void Action()
    {
        transform.parent.GetComponent<NPC_ControlScript>().SetMovementMethod(new DrunkMovement());
    }
}
