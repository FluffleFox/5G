﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : Item
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NPC_ControlScript>() != null)
        {
            other.GetComponent<NPC_ControlScript>().Effect(NPC_ControlScript.effects.Bonus);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<NPC_ControlScript>() != null)
        {
            other.GetComponent<NPC_ControlScript>().StopEffect(NPC_ControlScript.effects.Bonus);
        }
    }
}