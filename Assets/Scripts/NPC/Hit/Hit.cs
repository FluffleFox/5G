using System.Collections;
using UnityEngine;

public class Hit : MonoBehaviour
{
    protected NPC_ControlScript control;
    public float explosionTime;
    public float maxHeadSize;

    private void Start()
    {
        control = GetComponent<NPC_ControlScript>();
    }
    public virtual void GetHit()
    {

    }

    protected IEnumerator DIE()
    {
        GetComponent<Collider>().enabled = false;
        float baseSpeed = control.movementSpeed;
        float tmp = explosionTime;
        while (tmp > 0)
        {
            tmp -= Time.deltaTime;
            control.movementSpeed = baseSpeed * tmp / explosionTime;
            transform.GetChild(0).GetChild(1).localScale = Vector3.one * (0.55f + ((maxHeadSize - 0.55f) * (1.0f - (tmp / explosionTime))));
            yield return null;
        }

        control.GetScore();

        control.movementSpeed = baseSpeed;
        transform.GetChild(0).GetChild(1).localScale = Vector3.one * 0.55f;
        GetComponent<Collider>().enabled = true;
        GameObject GO = (GameObject)Instantiate(Resources.Load("NPCDestroy", typeof(GameObject)) as GameObject, transform.position, Quaternion.Euler(-90, 0, 0));
        GO.GetComponent<Renderer>().material.color = transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color;
        GetComponent<NPC_ControlScript>().Prepare();
    }
}
