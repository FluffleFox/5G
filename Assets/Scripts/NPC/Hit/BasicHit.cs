using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHit : Hit
{
    public float explosionTime;
    public float growSpeed;
    public override void GetHit()
    {
        if (DeadRay.tower != null)
        {
            StartCoroutine(DIE());
        }
    }

    IEnumerator DIE()
    {
        GetComponent<Collider>().enabled = false;
        float step = control.movementSpeed / explosionTime;
        for (int i = 0; i < explosionTime; i++)
        {
            yield return new WaitForSecondsRealtime(0.01f);
            transform.GetChild(0).GetChild(1).localScale *= growSpeed;
            control.movementSpeed -= step;
        }

        control.GetScore();

        control.movementSpeed = step * explosionTime;
        transform.GetChild(0).GetChild(1).localScale = Vector3.one * 0.55f;
        GetComponent<Collider>().enabled = true;
        GameObject GO = (GameObject)Instantiate(Resources.Load("NPCDestroy", typeof(GameObject))as GameObject, transform.position, Quaternion.Euler(-90, 0, 0));
        GO.GetComponent<Renderer>().material.color = transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color;
        Destroy(GO, 1.0f);
        GetComponent<NPC_ControlScript>().Prepare();
    }
}
