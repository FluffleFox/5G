using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class KarenAI : MonoBehaviour
{
    Vector3 Target;
    float speed;
    float currentSpeed;
    public LayerMask mask;
    public GameObject particle;
    float detonate;
    float reload;
    bool rage = false;
    public GameObject phone;
    public GameObject weapon;
    void Start()
    {
        int dir = Mathf.RoundToInt(Mathf.Sign(Random.Range(-1.0f, 1.0f)));
        float Targetz = Random.Range(-6.5f, -1.5f);
        float Startz = Random.Range(-6.5f, -1.5f);
        transform.position = new Vector3(4*dir, 0.5f, Startz);
        if (!rage)
        { 
            Target = new Vector3(4.5f * (-dir), 0.5f, Targetz); weapon.SetActive(false);
            speed = Random.Range(0.8f, 2.0f);
            detonate = Random.Range(1.0f, 8.0f / speed - 1.0f);
        }
        else
        {
            if (DeadRay.tower != null)
            { Target = DeadRay.tower.gameObject.transform.position; }
            weapon.SetActive(true);
            speed += Random.Range(0.8f, 2.0f);
            detonate = float.MaxValue;
        }
        transform.rotation = Quaternion.LookRotation(transform.position-Target);
        currentSpeed = speed;

        //phone.transform.localPosition = new Vector3(dir * 0.09f, 0.38f, 0.0f);
        transform.GetChild(0).GetComponent<Animator>().SetFloat("Direction", dir);
        phone.SetActive(false);

        //GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color= new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Target - transform.position).normalized*currentSpeed * Time.deltaTime, Space.World);
        if (Mathf.Abs(transform.position.x) >= 4.1f) { Start(); }

        foreach(Collider k in Physics.OverlapSphere(transform.position, 0.3f, mask))
        {
            k.transform.Translate((k.transform.position - transform.position).normalized * Time.deltaTime, Space.World);
        }
        detonate -= Time.deltaTime;
        if (detonate <= 0 && !rage)
        {
            detonate = float.MaxValue;
            //GetComponent<Renderer>().material.color = Color.red;
            phone.SetActive(true);
            reload = 1.5f;
        }
        if (reload > 0)
        {
            reload -= Time.deltaTime;
            currentSpeed = speed * 0.3f;
        }
        else
        {
            currentSpeed = speed;
        }

        if(rage&& Vector3.Distance(transform.position, Target) < 0.4f)
        {
            if (DeadRay.tower != null)
            { DeadRay.tower.Burn(); }
        }
        if(rage&& DeadRay.tower == null)
        {
            rage = false;
            Vector3 tmp = (transform.position - Target).normalized * 10.0f;
            if (Mathf.Abs(tmp.x) < 4.5f) { tmp.x = 4.5f*Mathf.Sign(tmp.x); }
            Target = transform.position+tmp;
            Target.y = 0.5f;
            transform.rotation = Quaternion.LookRotation(transform.position - Target);
            weapon.SetActive(false);
            speed = Random.Range(0.8f, 2.0f);
        }
    }

    private void OnMouseDown()
    {
        if (DeadRay.tower != null)
        {

            if (detonate > 1000)
            {
                ScoreCounter.counter.AddScore();
            }
            else if (!rage)
            {
                ScoreCounter.counter.LostHP();
            }
            

            GameObject GO = (GameObject)Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(GO, 1.0f);
            Start();
        }

    }

    public void Rage()
    {
        rage = true;
        weapon.SetActive(true);
        phone.SetActive(false);
        detonate = float.MaxValue;
        if (DeadRay.tower != null)
        { Target = DeadRay.tower.gameObject.transform.position; }
        transform.rotation = Quaternion.LookRotation(transform.position - Target);
    }
}
