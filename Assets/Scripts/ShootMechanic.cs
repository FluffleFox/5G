using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMechanic : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public LayerMask mask;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!ScoreCounter.counter.Rage()) Shoot();
            else DesperateShoot();
        }
    }


    void Shoot()
    {
        if (DeadRay.tower != null)
        { source.PlayOneShot(clip); }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        GameObject first=null;
        do
        {
            if (Physics.Raycast(ray, out info))
            {
                if (info.collider.GetComponent<NPC_ControlScript>() != null)
                {
                    if (first == null)
                    {
                        first = info.collider.gameObject;
                    }

                    if (info.collider.GetComponent<NPC_ControlScript>().priorityToDestroy)
                    {
                        info.collider.GetComponent<Hit>().GetHit();
                        return;
                    }

                    ray.origin = info.point + ray.direction.normalized * 0.05f;
                }
                else { break; }
            }
            else { break; }
        } while (true);

        if (first != null)
        {
            first.GetComponent<Hit>().GetHit();
        }
    }

    void DesperateShoot()
    {
        if (DeadRay.tower != null)
        { source.PlayOneShot(clip); }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            Collider[] inRange = Physics.OverlapSphere(info.point, 5.0f,mask);
            if (inRange.Length == 0) { return; }
            if (inRange.Length == 1) { inRange[0].gameObject.GetComponent<Hit>().GetHit(); return; }
            GameObject toDestroy=inRange[0].gameObject;
            float distance = float.MaxValue;
            for(int i=0; i<inRange.Length; i++)
            {
                float curr = Vector3.Distance(info.point, inRange[i].transform.position);
                if (curr < distance)
                {
                    distance = curr;
                    toDestroy = inRange[i].gameObject;
                }
            }
            toDestroy.GetComponent<Hit>().GetHit();
        }
    }
}
