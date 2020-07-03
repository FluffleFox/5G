using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPhone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float speed = transform.parent.forward.x * GetComponentInParent<NPC_ControlScript>().movementSpeed;
        float time = Random.Range(0.0f,Mathf.Abs(transform.parent.position.x / speed));
        transform.GetChild(0).gameObject.SetActive(false);
        Invoke("Activate", time);
    }

    void Activate()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponentInParent<NPC_ControlScript>().priorityToDestroy = true;
    }
}
