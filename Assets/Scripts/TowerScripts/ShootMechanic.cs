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
            if (GeneralGameMenager.instance.currentGameState==GeneralGameMenager.gameState.Normal) Shoot();
            else if (GeneralGameMenager.instance.currentGameState == GeneralGameMenager.gameState.Rage) DesperateShoot();
        }
    }


    void Shoot()
    {
        if (DeadRay.tower != null)
        {
            source.PlayOneShot(clip);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            GameObject first = null;
            int maxScore = 0;
            GameObject toDestroy = null;
            Vector3 hitPoint = Vector3.zero;
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

                        if (info.collider.GetComponent<NPC_ControlScript>().GetScoreValue() > maxScore)
                        {
                            maxScore = info.collider.GetComponent<NPC_ControlScript>().GetScoreValue();
                            toDestroy = info.collider.gameObject;
                        }
                        ray.origin = info.point + ray.direction.normalized * 0.05f;
                    }
                    else { hitPoint = info.point; break; }
                }
                else { break; }
            } while (true);

            if (toDestroy != null)
            {
                DeadRay.tower.Shoot(toDestroy.transform.position);
                toDestroy.GetComponent<Hit>().GetHit();
            }
            else if (first != null)
            {
                DeadRay.tower.Shoot(first.transform.position);
                first.GetComponent<Hit>().GetHit();
            }
            else
            {
                DeadRay.tower.Shoot(hitPoint);
            }
        }
    }

    void DesperateShoot()
    {
        if (DeadRay.tower != null)
        {
            source.PlayOneShot(clip);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info))
            {
                Collider[] inRange = Physics.OverlapSphere(info.point, 1.5f, mask);
                if (inRange.Length == 0)
                {
                    DeadRay.tower.Shoot(info.point);
                    return;
                }
                if (inRange.Length == 1)
                {
                    DeadRay.tower.Shoot(inRange[0].gameObject.transform.position);
                    inRange[0].gameObject.GetComponent<Hit>().GetHit();
                    return;
                }
                GameObject toDestroy = inRange[0].gameObject;
                float distance = float.MaxValue;
                for (int i = 0; i < inRange.Length; i++)
                {
                    float curr = Vector3.Distance(info.point, inRange[i].transform.position);
                    if (curr < distance)
                    {
                        distance = curr;
                        toDestroy = inRange[i].gameObject;
                    }
                }
                DeadRay.tower.Shoot(toDestroy.transform.position);
                toDestroy.GetComponent<Hit>().GetHit();
            }
        }
    }
}
