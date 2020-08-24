using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadRay : MonoBehaviour
{
    public static DeadRay tower;
    Transform center;
    LineRenderer line;
    public float raySpeed = 4;
    Vector3 lastHit;
    Vector3 currentPos;
    float currentSpeed;
    bool ready;
    TowerAnimation towerAnimation;
    public float distanceFromCam = 12.0f;

    

    private void Start()
    {
        Destroy(tower);
        tower = this;
        center = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
        line = GetComponent<LineRenderer>();
        currentPos = center.position;// + (Camera.main.transform.position-center.position).normalized*distance;
        line.SetPosition(0, currentPos);
        line.SetPosition(1, currentPos);
        towerAnimation = GetComponent<TowerAnimation>();
        towerAnimation.midDropAngle = new Vector3(Random.Range(90.0f, 100.0f), Random.Range(0.0f, 360.0f), 0.0f);
        towerAnimation.topDropAngle = towerAnimation.midDropAngle+ new Vector3(Random.Range(-40.0f, 10.0f), Random.Range(-45.0f, 45.0f), Random.Range(-180.0f,180.0f));
        GeneralGameMenager.instance.SwitchToNormal.AddListener(Respawn);
    }

    private void Update()
    {
        float distance = Vector3.Distance(center.position, Camera.main.transform.position) - distanceFromCam;
        Vector3 source = center.position + (Camera.main.transform.position - center.position).normalized * distance;
        line.SetPosition(0, source);

        if (!ready)
        {
            currentSpeed += currentSpeed * Time.deltaTime;
            if (Vector3.Distance(source, currentPos) > Vector3.Distance(source, currentPos - (lastHit - source).normalized * Time.deltaTime * currentSpeed * raySpeed))
            {
                currentPos -= (lastHit - source).normalized * Time.deltaTime * currentSpeed * raySpeed;
                line.SetPosition(0, source);
                line.SetPosition(1, currentPos);
            }
            else { ready = true; line.SetPosition(1, source); }
        }
        else { line.SetPosition(1, source); }
    }

    public void Shoot(Vector3 _point)
    {
        distanceFromCam = 5.0f;
        currentPos = _point;// info.point;
        lastHit = _point;// info.point;
        line.SetPosition(1, currentPos);
        ready = false;
        currentSpeed = 1.5f;
        towerAnimation.AddShootForce(center.position - currentPos);
    }

    public void Burn()
    {
        GameObject particle = Resources.Load("TowerDown", typeof(GameObject)) as GameObject;
        GameObject GO = (GameObject)Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(GO, 3);
        GO = (GameObject)Instantiate(particle, transform.position+Vector3.up*0.5f, Quaternion.Euler(-90, 0, 0));
        Destroy(GO, 3);
        GO = (GameObject)Instantiate(particle, transform.position+Vector3.up, Quaternion.Euler(-90, 0, 0));
        Destroy(GO, 3);
        GetComponent<TowerAnimation>().BurnThisTower();
        line.SetPosition(0, Vector3.down);
        line.SetPosition(1, Vector3.down);
        tower = null;
    }

    void Respawn()
    {
        tower = this;
    }
}
