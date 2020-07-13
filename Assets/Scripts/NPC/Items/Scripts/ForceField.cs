using System.Collections;
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

    public override void LastFrameAction()
    {
        foreach(Collider k in Physics.OverlapSphere(transform.position, 1.5f))
        {
            if (k.gameObject.GetComponent<NPC_ControlScript>()!=null)
            {
                k.gameObject.GetComponent<NPC_ControlScript>().StopEffect(NPC_ControlScript.effects.Bonus);
            }
        }
    }
}
