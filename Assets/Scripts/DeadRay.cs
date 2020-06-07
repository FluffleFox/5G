using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadRay : MonoBehaviour
{
    public static DeadRay tower;
    Transform center;
    LineRenderer line;
    public float raySpeed = 4;
    //public GameObject particle;
    Vector3 lastHit;
    Vector3 currentPos;
    float currentSpeed;
    bool ready;
    TowerAnimation towerAnimation;

    

    private void Start()
    {
        Destroy(tower);
        tower = this;
        center = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
        line = GetComponent<LineRenderer>();
        currentPos = center.position;
        line.SetPosition(0, currentPos);
        line.SetPosition(1, currentPos);
        towerAnimation = GetComponent<TowerAnimation>();
        towerAnimation.midDropAngle = new Vector3(Random.Range(90.0f, 100.0f), Random.Range(0.0f, 360.0f), 0.0f);
        towerAnimation.topDropAngle = towerAnimation.midDropAngle+ new Vector3(Random.Range(-40.0f, 10.0f), Random.Range(-45.0f, 45.0f), Random.Range(-180.0f,180.0f));
    }

    private void Update()
    {
        line.SetPosition(0, center.position);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info))
            {
                lastHit = info.point;
                currentPos = info.point+(info.point-center.position).normalized;
                line.SetPosition(1, currentPos);
                ready = false;
                currentSpeed = 1.5f;
                Debug.DrawLine(center.position, center.position + (center.position - currentPos).normalized, Color.green, 5.0f);
                Debug.DrawLine(center.position, center.position - (center.position - currentPos).normalized, Color.red, 5.0f);
                towerAnimation.AddShootForce(center.position - currentPos);
            }
        }

        if (!ready)
        {
            currentSpeed += currentSpeed * Time.deltaTime;
            if (Vector3.Distance(center.position, currentPos) > Vector3.Distance(center.position, currentPos - (lastHit - center.position).normalized * Time.deltaTime * currentSpeed * raySpeed))
            {
                currentPos -= (lastHit - center.position).normalized * Time.deltaTime * currentSpeed * raySpeed;
                line.SetPosition(0, center.position);
                line.SetPosition(1, currentPos);
            }
            else { ready = true; line.SetPosition(1, center.position); }
        }
        else { line.SetPosition(1, center.position); }
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
        Destroy(this);
    }
}
