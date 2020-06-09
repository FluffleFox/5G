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
                if (info.collider.GetComponent<KarenAI>() != null)
                {
                    KarenAI karen = info.collider.GetComponent<KarenAI>();
                    if (first == null) { first = karen.gameObject; }
                    if (karen.detonate > 1000.0f) { karen.Hit(); return; }
                    //else if (Vector3.Distance(info.point, karen.transform.position + Vector3.up * 0.37f-karen.transform.forward*0.03f) < tolerance)
                    //{ karen.Hit(); break; }
                    else { ray.origin = info.point + ray.direction.normalized * 0.1f; }
                }
                else { break; }
            }
            else { break; }
        } while (true);

        if (first != null)
        {
            first.GetComponent<KarenAI>().Hit();
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
            if (inRange.Length == 1) { inRange[0].gameObject.GetComponent<KarenAI>().Hit(); return; }
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
            toDestroy.GetComponent<KarenAI>().Hit();
        }
    }
}
