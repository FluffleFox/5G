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
    [HideInInspector]
    public float detonate;
    float reload;
    bool rage = false;
    public GameObject phone;
    public GameObject weapon;

    public int explosionTime;
    public float growSpeed;

    int index;

    void Start()
    {
        if (NPCDispository.Dispository.CanIRespawn(index, transform.parent))
        {
            int dir = Mathf.RoundToInt(Mathf.Sign(Random.Range(-1.0f, 1.0f)));
            float Targetz = Random.Range(-5.5f, 0.5f);
            float Startz = Random.Range(-5.5f, 0.5f);
            transform.position = new Vector3(4 * dir, 0.5f, Startz);
            if (!rage)
            {
                Target = new Vector3(4.5f * (-dir), 0.5f, Targetz); weapon.SetActive(false);
                speed = Random.Range(0.8f, 2.0f);
                if (Random.Range(0.0f, 100.0f) > 50.0f)
                { detonate = Random.Range(0.0f, Mathf.Abs(5.0f / speed)); }
                else { detonate = 999.99f; }
            }
            else
            {
                if (DeadRay.tower != null)
                { Target = DeadRay.tower.gameObject.transform.position; }
                weapon.SetActive(true);
                speed += Random.Range(0.8f, 2.0f);
                detonate = float.MaxValue;
            }
            transform.rotation = Quaternion.LookRotation(transform.position - Target);
            currentSpeed = speed;

            //phone.transform.localPosition = new Vector3(dir * 0.09f, 0.38f, 0.0f);
            transform.GetChild(0).GetComponent<Animator>().SetFloat("Direction", dir);
            phone.SetActive(false);

            //GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        }
        else { gameObject.SetActive(false); }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Target - transform.position).normalized*currentSpeed * Time.deltaTime, Space.World);
        if (Mathf.Abs(transform.position.x) >= 4.1f)
        { 
            if(detonate > 1000) { ScoreCounter.counter.LostHP(); }
            Start();
        }

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
            { DeadRay.tower.Burn(); NPCDispository.Dispository.ResetAll(); }
        }
        if(rage&& DeadRay.tower == null)
        {
            StopRage();
        }
    }

    public void Hit()
    {
        if (DeadRay.tower != null)
        {
            StartCoroutine(DIE());
        }
    }

    IEnumerator DIE()
    {
        GetComponent<Collider>().enabled = false;
        float step = speed / explosionTime;
        for(int i=0; i<explosionTime; i++)
        {
            yield return new WaitForSecondsRealtime(0.005f);
            transform.GetChild(0).GetChild(1).localScale *= growSpeed;
            speed -= step;
        }

        if (detonate > 1000)
        {
            ScoreCounter.counter.AddScore();
        }
        else if (!rage)
        {
            ScoreCounter.counter.LostHP();
        }

        transform.GetChild(0).GetChild(1).localScale = Vector3.one*0.55f;
        GetComponent<Collider>().enabled = true;
        GameObject GO = (GameObject)Instantiate(particle, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(GO, 1.0f);
        speed = step * explosionTime;
        Start();
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

    public void SetIndex(int value)
    {
        index = value;
    }

    public void StopRage()
    {
        rage = false;
        Vector3 tmp = (transform.position - Target).normalized * 10.0f;
        if (Mathf.Abs(tmp.x) < 4.5f) { tmp.x = 4.5f * Mathf.Sign(tmp.x); }
        Target = transform.position + tmp;
        Target.y = 0.5f;
        transform.rotation = Quaternion.LookRotation(transform.position - Target);
        weapon.SetActive(false);
        speed = Random.Range(0.8f, 2.0f);
    }
}
